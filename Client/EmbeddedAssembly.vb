Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography

''' <summary>
''' A class for loading Embedded Assembly
''' </summary>
Public Class EmbeddedAssembly
	' Version 1.3

	Private Shared dic As Dictionary(Of String, System.Reflection.Assembly) = Nothing

	''' <summary>
	''' Load Assembly, DLL from Embedded Resources into memory.
	''' </summary>
	''' <param name="embeddedResource">Embedded Resource string. Example: WindowsFormsApplication1.SomeTools.dll</param>
	''' <param name="fileName">File Name. Example: SomeTools.dll</param>
	Public Shared Sub Load(ByVal embeddedResource As String, ByVal fileName As String)
		If dic Is Nothing Then
			dic = New Dictionary(Of String, System.Reflection.Assembly)()
		End If

		Dim ba() As Byte = Nothing
		Dim asm As System.Reflection.Assembly = Nothing
		Dim curAsm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()

		Using stm As Stream = curAsm.GetManifestResourceStream(embeddedResource)
			' Either the file is not existed or it is not mark as embedded resource
			If stm Is Nothing Then
				Throw New Exception(embeddedResource & " is not found in Embedded Resources.")
			End If

			' Get byte[] from the file from embedded resource
			ba = New Byte(CInt(stm.Length) - 1){}
			stm.Read(ba, 0, CInt(stm.Length))
			Try
				asm = System.Reflection.Assembly.Load(ba)

				' Add the assembly/dll into dictionary
				dic.Add(asm.FullName, asm)
				Return
			Catch
				' Purposely do nothing
				' Unmanaged dll or assembly cannot be loaded directly from byte[]
				' Let the process fall through for next part
			End Try
		End Using

		Dim fileOk As Boolean = False
		Dim tempFile As String = ""

		Using sha1 As New SHA1CryptoServiceProvider()
			' Get the hash value from embedded DLL/assembly
			Dim fileHash As String = BitConverter.ToString(sha1.ComputeHash(ba)).Replace("-", String.Empty)

			' Define the temporary storage location of the DLL/assembly
			tempFile = Path.GetTempPath() & fileName

			' Determines whether the DLL/assembly is existed or not
			If File.Exists(tempFile) Then
				' Get the hash value of the existed file
				Dim bb() As Byte = File.ReadAllBytes(tempFile)
				Dim fileHash2 As String = BitConverter.ToString(sha1.ComputeHash(bb)).Replace("-", String.Empty)

				' Compare the existed DLL/assembly with the Embedded DLL/assembly
				If fileHash = fileHash2 Then
					' Same file
					fileOk = True
				Else
					' Not same
					fileOk = False
				End If
			Else
				' The DLL/assembly is not existed yet
				fileOk = False
			End If
		End Using

		' Create the file on disk
		If Not fileOk Then
			System.IO.File.WriteAllBytes(tempFile, ba)
		End If

		' Load it into memory
		asm = System.Reflection.Assembly.LoadFile(tempFile)

		' Add the loaded DLL/assembly into dictionary
		dic.Add(asm.FullName, asm)
	End Sub

	''' <summary>
	''' Retrieve specific loaded DLL/assembly from memory
	''' </summary>
	''' <param name="assemblyFullName"></param>
	''' <returns></returns>
	Public Shared Function [Get](ByVal assemblyFullName As String) As System.Reflection.Assembly
		If dic Is Nothing OrElse dic.Count = 0 Then
			Return Nothing
		End If

		If dic.ContainsKey(assemblyFullName) Then
			Return dic(assemblyFullName)
		End If

		Return Nothing

		' Don't throw Exception if the dictionary does not contain the requested assembly.
		' This is because the event of AssemblyResolve will be raised for every
		' Embedded Resources (such as pictures) of the projects.
		' Those resources wil not be loaded by this class and will not exist in dictionary.
	End Function
End Class