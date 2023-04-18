Namespace HVNC
	Partial Public Class FrmBuilder
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmBuilder))
			Me.button1 = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.txtIP = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.txtPORT = New System.Windows.Forms.TextBox()
			Me.txtIdentifier = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.checkBox1 = New System.Windows.Forms.CheckBox()
			Me.txtMutex = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.groupBox3 = New System.Windows.Forms.GroupBox()
			Me.button3 = New System.Windows.Forms.Button()
			Me.checkBox2 = New System.Windows.Forms.CheckBox()
			Me.textBox2 = New System.Windows.Forms.TextBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.comboBox1 = New System.Windows.Forms.ComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.button2 = New System.Windows.Forms.Button()
			Me.groupBox1.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(12, 228)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(512, 47)
			Me.button1.TabIndex = 0
			Me.button1.Text = "Build"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click)
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(7, 22)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(58, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "ID / DNS :"
			' 
			' txtIP
			' 
			Me.txtIP.Location = New System.Drawing.Point(71, 19)
			Me.txtIP.Name = "txtIP"
			Me.txtIP.Size = New System.Drawing.Size(157, 20)
			Me.txtIP.TabIndex = 2
			Me.txtIP.Text = "127.0.0.1"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(33, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(32, 13)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Port :"
			' 
			' txtPORT
			' 
			Me.txtPORT.Location = New System.Drawing.Point(71, 45)
			Me.txtPORT.Name = "txtPORT"
			Me.txtPORT.Size = New System.Drawing.Size(73, 20)
			Me.txtPORT.TabIndex = 4
			Me.txtPORT.Text = "8081"
			' 
			' txtIdentifier
			' 
			Me.txtIdentifier.Location = New System.Drawing.Point(349, 22)
			Me.txtIdentifier.Name = "txtIdentifier"
			Me.txtIdentifier.Size = New System.Drawing.Size(133, 20)
			Me.txtIdentifier.TabIndex = 6
			Me.txtIdentifier.Text = "Default"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(261, 25)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(82, 13)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Client Identifier :"
			' 
			' checkBox1
			' 
			Me.checkBox1.AutoSize = True
			Me.checkBox1.Location = New System.Drawing.Point(6, 0)
			Me.checkBox1.Name = "checkBox1"
			Me.checkBox1.Size = New System.Drawing.Size(96, 17)
			Me.checkBox1.TabIndex = 7
			Me.checkBox1.Text = "Enable Startup"
			Me.checkBox1.UseVisualStyleBackColor = True
			' 
			' txtMutex
			' 
			Me.txtMutex.Location = New System.Drawing.Point(349, 48)
			Me.txtMutex.Name = "txtMutex"
			Me.txtMutex.Size = New System.Drawing.Size(101, 20)
			Me.txtMutex.TabIndex = 9
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(301, 51)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(42, 13)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Mutex :"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.groupBox3)
			Me.groupBox1.Controls.Add(Me.groupBox2)
			Me.groupBox1.Location = New System.Drawing.Point(12, 12)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(512, 210)
			Me.groupBox1.TabIndex = 10
			Me.groupBox1.TabStop = False
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.button3)
			Me.groupBox3.Controls.Add(Me.checkBox2)
			Me.groupBox3.Controls.Add(Me.textBox2)
			Me.groupBox3.Controls.Add(Me.label7)
			Me.groupBox3.Controls.Add(Me.textBox1)
			Me.groupBox3.Controls.Add(Me.label6)
			Me.groupBox3.Controls.Add(Me.comboBox1)
			Me.groupBox3.Controls.Add(Me.label5)
			Me.groupBox3.Controls.Add(Me.checkBox1)
			Me.groupBox3.Location = New System.Drawing.Point(6, 95)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(500, 106)
			Me.groupBox3.TabIndex = 12
			Me.groupBox3.TabStop = False
			' 
			' button3
			' 
			Me.button3.Location = New System.Drawing.Point(361, 64)
			Me.button3.Name = "button3"
			Me.button3.Size = New System.Drawing.Size(121, 20)
			Me.button3.TabIndex = 16
			Me.button3.Text = "R"
			Me.button3.UseVisualStyleBackColor = True
'			Me.button3.Click += New System.EventHandler(Me.button3_Click)
			' 
			' checkBox2
			' 
			Me.checkBox2.AutoSize = True
			Me.checkBox2.Location = New System.Drawing.Point(205, 66)
			Me.checkBox2.Name = "checkBox2"
			Me.checkBox2.Size = New System.Drawing.Size(126, 17)
			Me.checkBox2.TabIndex = 15
			Me.checkBox2.Text = "Add to WD exclusion"
			Me.checkBox2.UseVisualStyleBackColor = True
			' 
			' textBox2
			' 
			Me.textBox2.Location = New System.Drawing.Point(71, 64)
			Me.textBox2.Name = "textBox2"
			Me.textBox2.Size = New System.Drawing.Size(101, 20)
			Me.textBox2.TabIndex = 14
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(10, 67)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(55, 13)
			Me.label7.TabIndex = 13
			Me.label7.Text = "Filename :"
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(361, 32)
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(121, 20)
			Me.textBox1.TabIndex = 12
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(312, 35)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(42, 13)
			Me.label6.TabIndex = 10
			Me.label6.Text = "Folder :"
			' 
			' comboBox1
			' 
			Me.comboBox1.FormattingEnabled = True
			Me.comboBox1.Items.AddRange(New Object() { "%AppData%\Local", "%AppData%\Roaming", "%AppData%\Local\Temp"})
			Me.comboBox1.Location = New System.Drawing.Point(71, 32)
			Me.comboBox1.Name = "comboBox1"
			Me.comboBox1.Size = New System.Drawing.Size(146, 21)
			Me.comboBox1.TabIndex = 9
			Me.comboBox1.Text = "%AppData%\Local"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(30, 35)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(35, 13)
			Me.label5.TabIndex = 8
			Me.label5.Text = "Path :"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.txtIdentifier)
			Me.groupBox2.Controls.Add(Me.label3)
			Me.groupBox2.Controls.Add(Me.txtIP)
			Me.groupBox2.Controls.Add(Me.button2)
			Me.groupBox2.Controls.Add(Me.txtPORT)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Controls.Add(Me.txtMutex)
			Me.groupBox2.Controls.Add(Me.label1)
			Me.groupBox2.Location = New System.Drawing.Point(6, 10)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(500, 79)
			Me.groupBox2.TabIndex = 11
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Connexion"
			' 
			' button2
			' 
			Me.button2.Location = New System.Drawing.Point(456, 48)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(26, 20)
			Me.button2.TabIndex = 11
			Me.button2.Text = "R"
			Me.button2.UseVisualStyleBackColor = True
'			Me.button2.Click += New System.EventHandler(Me.button2_Click)
			' 
			' FrmBuilder
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(536, 287)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.button1)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MaximumSize = New System.Drawing.Size(552, 326)
			Me.MinimizeBox = False
			Me.MinimumSize = New System.Drawing.Size(552, 326)
			Me.Name = "FrmBuilder"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Builder"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.FrmBuilder_FormClosing)
'			Me.Load += New System.EventHandler(Me.FrmBuilder_Load)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox3.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents button1 As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private txtIP As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private txtPORT As System.Windows.Forms.TextBox
		Private txtIdentifier As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private checkBox1 As System.Windows.Forms.CheckBox
		Private txtMutex As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private WithEvents button2 As System.Windows.Forms.Button
		Private groupBox3 As System.Windows.Forms.GroupBox
		Private textBox2 As System.Windows.Forms.TextBox
		Private label7 As System.Windows.Forms.Label
		Private textBox1 As System.Windows.Forms.TextBox
		Private label6 As System.Windows.Forms.Label
		Private comboBox1 As System.Windows.Forms.ComboBox
		Private label5 As System.Windows.Forms.Label
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private WithEvents button3 As System.Windows.Forms.Button
		Private checkBox2 As System.Windows.Forms.CheckBox
	End Class
End Namespace