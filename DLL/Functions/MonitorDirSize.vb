Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Namespace DLL.Functions
	Public Class MonitorDirSize
		Private newthread As Thread

		Public Sub StartMonitoring(ByVal directory As String)
			newthread = New Thread(Sub(a0 As Object) WorkerThread(Conversions.ToString(a0)))
			newthread.IsBackground = True
			newthread.SetApartmentState(ApartmentState.STA)
			newthread.Start(directory)
		End Sub

		Private Sub WorkerThread(ByVal directory As String)
			Do
				Try
					If System.IO.Directory.Exists(directory) Then
						Outils.SendInformation(Outils.nstream, "23|" & Conversions.ToString(Math.Round(CDbl((New GetDirSize()).GetDirSizez(directory)) / 1024.0 / 1024.0)))
					End If
				Catch projectError As Exception
					ProjectData.SetProjectError(projectError)
					ProjectData.ClearProjectError()
				End Try
				Thread.Sleep(100)
			Loop
		End Sub

		Public Sub StopMonitoring()
			newthread.Abort()
		End Sub
	End Class
End Namespace
