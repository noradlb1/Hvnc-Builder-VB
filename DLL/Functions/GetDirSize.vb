Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO

Namespace DLL.Functions
	Public Class GetDirSize
		Private TotalSize As Long

		Public Sub New()
			TotalSize = 0L
		End Sub

		Public Function GetDirSizez(ByVal RootFolder As String) As Long
			'Discarded unreachable code: IL_00a4, IL_00da, IL_00dc, IL_00e3, IL_00e6, IL_00e7, IL_00f4, IL_0116
			Dim num As Integer = Nothing
'INSTANT VB NOTE: The variable totalSize was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim totalSize_Renamed As Long
			Dim num3 As Integer = Nothing
			Try
				ProjectData.ClearProjectError()
				num = -2
				Dim num2 As Integer = 2
				Dim directoryInfo As New DirectoryInfo(RootFolder)
				num2 = 3
				Dim files() As FileInfo = directoryInfo.GetFiles()
'INSTANT VB TODO TASK: There is no equivalent to a 'checked' block in VB:
'				checked
					For Each fileInfo As FileInfo In files
						num2 = 4
						TotalSize += fileInfo.Length
						num2 = 5
					Next fileInfo
					num2 = 6
					Dim directories() As DirectoryInfo = directoryInfo.GetDirectories()
					For Each directoryInfo2 As DirectoryInfo In directories
						num2 = 7
						GetDirSizez(directoryInfo2.FullName)
						num2 = 8
					Next directoryInfo2
					num2 = 9
					totalSize_Renamed = TotalSize
'INSTANT VB TODO TASK: End of the original C# 'checked' block.
			Catch ex As Exception
				ProjectData.SetProjectError(CType(ex, Exception))
				'Error near IL_0114: Could not find block for branch target IL_00dc

				totalSize_Renamed = 0
			End Try
			If num3 <> 0 Then
				ProjectData.ClearProjectError()
			End If
			Return totalSize_Renamed
		End Function
	End Class
End Namespace
