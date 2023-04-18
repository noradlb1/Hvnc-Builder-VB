Namespace HVNC
	Partial Public Class FrmTransfer
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.DuplicateProgess = New System.Windows.Forms.ProgressBar()
			Me.FileTransferLabel = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' DuplicateProgess
			' 
			Me.DuplicateProgess.Location = New System.Drawing.Point(12, 12)
			Me.DuplicateProgess.Name = "DuplicateProgess"
			Me.DuplicateProgess.Size = New System.Drawing.Size(453, 23)
			Me.DuplicateProgess.TabIndex = 1
			' 
			' FileTransferLabel
			' 
			Me.FileTransferLabel.AutoSize = True
			Me.FileTransferLabel.Location = New System.Drawing.Point(225, 44)
			Me.FileTransferLabel.Name = "FileTransferLabel"
			Me.FileTransferLabel.Size = New System.Drawing.Size(24, 13)
			Me.FileTransferLabel.TabIndex = 4
			Me.FileTransferLabel.Text = "Idle"
			' 
			' FrmTransfer
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(475, 66)
			Me.Controls.Add(Me.FileTransferLabel)
			Me.Controls.Add(Me.DuplicateProgess)
			Me.Name = "FrmTransfer"
			Me.Opacity = 0R
			Me.ShowIcon = False
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
'			Me.Load += New System.EventHandler(Me.FrmTransfer_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region
		Private DuplicateProgess As System.Windows.Forms.ProgressBar
		Private FileTransferLabel As System.Windows.Forms.Label
	End Class
End Namespace