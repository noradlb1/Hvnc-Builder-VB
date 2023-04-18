Namespace HVNC
	Partial Public Class FrmVNC
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
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmVNC))
			Me.timer1 = New System.Windows.Forms.Timer(Me.components)
			Me.CopyBtn = New System.Windows.Forms.Button()
			Me.PasteBtn = New System.Windows.Forms.Button()
			Me.ShowStart = New System.Windows.Forms.Button()
			Me.StartExplorer = New System.Windows.Forms.Button()
			Me.ResizeLabel = New System.Windows.Forms.Label()
			Me.QualityLabel = New System.Windows.Forms.Label()
			Me.IntervalLabel = New System.Windows.Forms.Label()
			Me.VNCBox = New System.Windows.Forms.PictureBox()
			Me.IntervalScroll = New System.Windows.Forms.TrackBar()
			Me.QualityScroll = New System.Windows.Forms.TrackBar()
			Me.ResizeScroll = New System.Windows.Forms.TrackBar()
			Me.CloseBtn = New System.Windows.Forms.Button()
			Me.RestoreMaxBtn = New System.Windows.Forms.Button()
			Me.MinBtn = New System.Windows.Forms.Button()
			Me.StartBrowserBtn = New System.Windows.Forms.Button()
			Me.button1 = New System.Windows.Forms.Button()
			Me.button2 = New System.Windows.Forms.Button()
			Me.button3 = New System.Windows.Forms.Button()
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
			Me.closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
			Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
			Me.chkClone = New System.Windows.Forms.CheckBox()
			Me.timer2 = New System.Windows.Forms.Timer(Me.components)
			Me.button4 = New System.Windows.Forms.Button()
			Me.button5 = New System.Windows.Forms.Button()
			Me.textBoxEXE = New System.Windows.Forms.TextBox()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.groupBox3 = New System.Windows.Forms.GroupBox()
			Me.button6 = New System.Windows.Forms.Button()
			Me.groupBox4 = New System.Windows.Forms.GroupBox()
			Me.button8 = New System.Windows.Forms.Button()
			Me.button7 = New System.Windows.Forms.Button()
			Me.groupBox5 = New System.Windows.Forms.GroupBox()
			Me.groupBox6 = New System.Windows.Forms.GroupBox()
			DirectCast(Me.VNCBox, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.IntervalScroll, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.QualityScroll, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ResizeScroll, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.contextMenuStrip1.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.groupBox4.SuspendLayout()
			Me.groupBox5.SuspendLayout()
			Me.groupBox6.SuspendLayout()
			Me.SuspendLayout()
			' 
			' timer1
			' 
'			Me.timer1.Tick += New System.EventHandler(Me.timer1_Tick)
			' 
			' CopyBtn
			' 
			Me.CopyBtn.Image = My.Resources.Copy32x32
			Me.CopyBtn.Location = New System.Drawing.Point(6, 78)
			Me.CopyBtn.Name = "CopyBtn"
			Me.CopyBtn.Size = New System.Drawing.Size(40, 40)
			Me.CopyBtn.TabIndex = 0
			Me.CopyBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.CopyBtn.UseVisualStyleBackColor = True
'			Me.CopyBtn.Click += New System.EventHandler(Me.CopyBtn_Click)
			' 
			' PasteBtn
			' 
			Me.PasteBtn.Image = My.Resources.Copy32x32
			Me.PasteBtn.Location = New System.Drawing.Point(52, 78)
			Me.PasteBtn.Name = "PasteBtn"
			Me.PasteBtn.Size = New System.Drawing.Size(40, 40)
			Me.PasteBtn.TabIndex = 1
			Me.PasteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.PasteBtn.UseVisualStyleBackColor = True
'			Me.PasteBtn.Click += New System.EventHandler(Me.PasteBtn_Click)
			' 
			' ShowStart
			' 
			Me.ShowStart.Image = My.Resources.Windows32x32
			Me.ShowStart.Location = New System.Drawing.Point(6, 32)
			Me.ShowStart.Name = "ShowStart"
			Me.ShowStart.Size = New System.Drawing.Size(40, 40)
			Me.ShowStart.TabIndex = 2
			Me.ShowStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.ShowStart.UseVisualStyleBackColor = True
'			Me.ShowStart.Click += New System.EventHandler(Me.ShowStart_Click)
			' 
			' StartExplorer
			' 
			Me.StartExplorer.Image = My.Resources.Explorer32x32
			Me.StartExplorer.Location = New System.Drawing.Point(52, 32)
			Me.StartExplorer.Name = "StartExplorer"
			Me.StartExplorer.Size = New System.Drawing.Size(40, 40)
			Me.StartExplorer.TabIndex = 3
			Me.StartExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.StartExplorer.UseVisualStyleBackColor = True
'			Me.StartExplorer.Click += New System.EventHandler(Me.StartExplorer_Click)
			' 
			' ResizeLabel
			' 
			Me.ResizeLabel.AutoSize = True
			Me.ResizeLabel.Location = New System.Drawing.Point(397, 18)
			Me.ResizeLabel.Name = "ResizeLabel"
			Me.ResizeLabel.Size = New System.Drawing.Size(68, 13)
			Me.ResizeLabel.TabIndex = 4
			Me.ResizeLabel.Text = "Resize : 55%"
			' 
			' QualityLabel
			' 
			Me.QualityLabel.AutoSize = True
			Me.QualityLabel.Location = New System.Drawing.Point(213, 18)
			Me.QualityLabel.Name = "QualityLabel"
			Me.QualityLabel.Size = New System.Drawing.Size(68, 13)
			Me.QualityLabel.TabIndex = 5
			Me.QualityLabel.Text = "Quality : 50%"
			' 
			' IntervalLabel
			' 
			Me.IntervalLabel.AutoSize = True
			Me.IntervalLabel.Location = New System.Drawing.Point(9, 18)
			Me.IntervalLabel.Name = "IntervalLabel"
			Me.IntervalLabel.Size = New System.Drawing.Size(88, 13)
			Me.IntervalLabel.TabIndex = 6
			Me.IntervalLabel.Text = "Interval (ms): 500"
			' 
			' VNCBox
			' 
			Me.VNCBox.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.VNCBox.Location = New System.Drawing.Point(3, 52)
			Me.VNCBox.Name = "VNCBox"
			Me.VNCBox.Size = New System.Drawing.Size(1004, 524)
			Me.VNCBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.VNCBox.TabIndex = 7
			Me.VNCBox.TabStop = False
'			Me.VNCBox.Click += New System.EventHandler(Me.VNCBox_Click)
'			Me.VNCBox.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.VNCBox_MouseDown)
'			Me.VNCBox.MouseHover += New System.EventHandler(Me.VNCBox_MouseHover)
'			Me.VNCBox.MouseMove += New System.Windows.Forms.MouseEventHandler(Me.VNCBox_MouseMove)
'			Me.VNCBox.MouseUp += New System.Windows.Forms.MouseEventHandler(Me.VNCBox_MouseUp)
			' 
			' IntervalScroll
			' 
			Me.IntervalScroll.AutoSize = False
			Me.IntervalScroll.Location = New System.Drawing.Point(103, 11)
			Me.IntervalScroll.Maximum = 1000
			Me.IntervalScroll.Minimum = 10
			Me.IntervalScroll.Name = "IntervalScroll"
			Me.IntervalScroll.Size = New System.Drawing.Size(104, 26)
			Me.IntervalScroll.TabIndex = 8
			Me.IntervalScroll.TickStyle = System.Windows.Forms.TickStyle.None
			Me.IntervalScroll.Value = 500
'			Me.IntervalScroll.Scroll += New System.EventHandler(Me.IntervalScroll_Scroll)
			' 
			' QualityScroll
			' 
			Me.QualityScroll.AutoSize = False
			Me.QualityScroll.Location = New System.Drawing.Point(287, 11)
			Me.QualityScroll.Maximum = 100
			Me.QualityScroll.Name = "QualityScroll"
			Me.QualityScroll.Size = New System.Drawing.Size(104, 26)
			Me.QualityScroll.TabIndex = 9
			Me.QualityScroll.TickStyle = System.Windows.Forms.TickStyle.None
			Me.QualityScroll.Value = 50
'			Me.QualityScroll.Scroll += New System.EventHandler(Me.QualityScroll_Scroll)
			' 
			' ResizeScroll
			' 
			Me.ResizeScroll.AutoSize = False
			Me.ResizeScroll.Location = New System.Drawing.Point(471, 11)
			Me.ResizeScroll.Maximum = 100
			Me.ResizeScroll.Minimum = 10
			Me.ResizeScroll.Name = "ResizeScroll"
			Me.ResizeScroll.Size = New System.Drawing.Size(104, 26)
			Me.ResizeScroll.TabIndex = 10
			Me.ResizeScroll.TickStyle = System.Windows.Forms.TickStyle.None
			Me.ResizeScroll.Value = 55
'			Me.ResizeScroll.Scroll += New System.EventHandler(Me.ResizeScroll_Scroll)
			' 
			' CloseBtn
			' 
			Me.CloseBtn.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.CloseBtn.BackgroundImage = My.Resources.close_window
			Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
			Me.CloseBtn.Location = New System.Drawing.Point(972, 18)
			Me.CloseBtn.Name = "CloseBtn"
			Me.CloseBtn.Size = New System.Drawing.Size(26, 26)
			Me.CloseBtn.TabIndex = 11
			Me.CloseBtn.UseVisualStyleBackColor = True
'			Me.CloseBtn.Click += New System.EventHandler(Me.CloseBtn_Click)
			' 
			' RestoreMaxBtn
			' 
			Me.RestoreMaxBtn.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.RestoreMaxBtn.BackgroundImage = My.Resources.maximize_window
			Me.RestoreMaxBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
			Me.RestoreMaxBtn.Location = New System.Drawing.Point(947, 18)
			Me.RestoreMaxBtn.Name = "RestoreMaxBtn"
			Me.RestoreMaxBtn.Size = New System.Drawing.Size(26, 26)
			Me.RestoreMaxBtn.TabIndex = 12
			Me.RestoreMaxBtn.UseVisualStyleBackColor = True
'			Me.RestoreMaxBtn.Click += New System.EventHandler(Me.RestoreMaxBtn_Click)
			' 
			' MinBtn
			' 
			Me.MinBtn.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.MinBtn.BackgroundImage = My.Resources.minimize_window
			Me.MinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
			Me.MinBtn.Location = New System.Drawing.Point(922, 18)
			Me.MinBtn.Name = "MinBtn"
			Me.MinBtn.Size = New System.Drawing.Size(26, 26)
			Me.MinBtn.TabIndex = 13
			Me.MinBtn.UseVisualStyleBackColor = True
'			Me.MinBtn.Click += New System.EventHandler(Me.MinBtn_Click)
			' 
			' StartBrowserBtn
			' 
			Me.StartBrowserBtn.Image = My.Resources.Chrome32x32
			Me.StartBrowserBtn.Location = New System.Drawing.Point(6, 19)
			Me.StartBrowserBtn.Name = "StartBrowserBtn"
			Me.StartBrowserBtn.Size = New System.Drawing.Size(40, 40)
			Me.StartBrowserBtn.TabIndex = 14
			Me.StartBrowserBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.StartBrowserBtn.UseVisualStyleBackColor = True
'			Me.StartBrowserBtn.Click += New System.EventHandler(Me.StartBrowserBtn_Click)
			' 
			' button1
			' 
			Me.button1.Image = My.Resources.Edge32x32
			Me.button1.Location = New System.Drawing.Point(6, 65)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(40, 40)
			Me.button1.TabIndex = 16
			Me.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click)
			' 
			' button2
			' 
			Me.button2.Image = My.Resources.Firefox32x32
			Me.button2.Location = New System.Drawing.Point(52, 65)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(40, 40)
			Me.button2.TabIndex = 17
			Me.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.button2.UseVisualStyleBackColor = True
'			Me.button2.Click += New System.EventHandler(Me.button2_Click)
			' 
			' button3
			' 
			Me.button3.Image = My.Resources.FrmMiner
			Me.button3.Location = New System.Drawing.Point(6, 19)
			Me.button3.Name = "button3"
			Me.button3.Size = New System.Drawing.Size(40, 40)
			Me.button3.TabIndex = 18
			Me.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.button3.UseVisualStyleBackColor = True
'			Me.button3.Click += New System.EventHandler(Me.button3_Click)
			' 
			' statusStrip1
			' 
			Me.statusStrip1.ContextMenuStrip = Me.contextMenuStrip1
			Me.statusStrip1.Location = New System.Drawing.Point(0, 579)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(1133, 22)
			Me.statusStrip1.TabIndex = 19
			' 
			' contextMenuStrip1
			' 
			Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.closeToolStripMenuItem})
			Me.contextMenuStrip1.Name = "contextMenuStrip1"
			Me.contextMenuStrip1.Size = New System.Drawing.Size(165, 26)
			' 
			' closeToolStripMenuItem
			' 
			Me.closeToolStripMenuItem.Image = My.Resources.server_delete
			Me.closeToolStripMenuItem.Name = "closeToolStripMenuItem"
			Me.closeToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
			Me.closeToolStripMenuItem.Text = "Close Connexion"
'			Me.closeToolStripMenuItem.Click += New System.EventHandler(Me.closeToolStripMenuItem_Click)
			' 
			' toolStripStatusLabel1
			' 
			Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
			Me.toolStripStatusLabel1.Size = New System.Drawing.Size(44, 17)
			Me.toolStripStatusLabel1.Text = "Statut :"
			' 
			' toolStripStatusLabel2
			' 
			Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
			Me.toolStripStatusLabel2.Size = New System.Drawing.Size(26, 17)
			Me.toolStripStatusLabel2.Text = "Idle"
			' 
			' chkClone
			' 
			Me.chkClone.AutoSize = True
			Me.chkClone.Location = New System.Drawing.Point(7, 157)
			Me.chkClone.Name = "chkClone"
			Me.chkClone.Size = New System.Drawing.Size(85, 17)
			Me.chkClone.TabIndex = 20
			Me.chkClone.Text = "Clone Profile"
			Me.chkClone.UseVisualStyleBackColor = True
			' 
			' timer2
			' 
			Me.timer2.Enabled = True
			Me.timer2.Interval = 1000
'			Me.timer2.Tick += New System.EventHandler(Me.timer2_Tick)
			' 
			' button4
			' 
			Me.button4.Image = My.Resources.brave_browser_logo_icon_153013
			Me.button4.Location = New System.Drawing.Point(52, 19)
			Me.button4.Name = "button4"
			Me.button4.Size = New System.Drawing.Size(40, 40)
			Me.button4.TabIndex = 21
			Me.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.button4.UseVisualStyleBackColor = True
'			Me.button4.Click += New System.EventHandler(Me.button4_Click)
			' 
			' button5
			' 
			Me.button5.Enabled = False
			Me.button5.Image = My.Resources.opera_browser_logo_icon_152972
			Me.button5.Location = New System.Drawing.Point(6, 111)
			Me.button5.Name = "button5"
			Me.button5.Size = New System.Drawing.Size(40, 40)
			Me.button5.TabIndex = 22
			Me.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.button5.UseVisualStyleBackColor = True
'			Me.button5.Click += New System.EventHandler(Me.button5_Click)
			' 
			' textBoxEXE
			' 
			Me.textBoxEXE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.textBoxEXE.ForeColor = System.Drawing.Color.Gray
			Me.textBoxEXE.Location = New System.Drawing.Point(6, 33)
			Me.textBoxEXE.Name = "textBoxEXE"
			Me.textBoxEXE.Size = New System.Drawing.Size(88, 20)
			Me.textBoxEXE.TabIndex = 25
			Me.textBoxEXE.Text = "https://the.earth.li/~sgtatham/putty/latest/w64/putty.exe"
			'this.textBoxEXE.TextChanged += new System.EventHandler(this.textBoxEXE_TextChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.StartBrowserBtn)
			Me.groupBox1.Controls.Add(Me.button5)
			Me.groupBox1.Controls.Add(Me.button1)
			Me.groupBox1.Controls.Add(Me.button4)
			Me.groupBox1.Controls.Add(Me.chkClone)
			Me.groupBox1.Controls.Add(Me.button2)
			Me.groupBox1.Location = New System.Drawing.Point(7, 195)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(99, 185)
			Me.groupBox1.TabIndex = 26
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Browsers"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.button3)
			Me.groupBox2.Location = New System.Drawing.Point(7, 386)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(99, 66)
			Me.groupBox2.TabIndex = 27
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Miner"
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.button6)
			Me.groupBox3.Controls.Add(Me.textBoxEXE)
			Me.groupBox3.Location = New System.Drawing.Point(7, 458)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(99, 107)
			Me.groupBox3.TabIndex = 28
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Download / Execute"
			' 
			' button6
			' 
			Me.button6.Image = My.Resources.icons8_download_from_cloud_32
			Me.button6.Location = New System.Drawing.Point(6, 61)
			Me.button6.Name = "button6"
			Me.button6.Size = New System.Drawing.Size(40, 40)
			Me.button6.TabIndex = 26
			Me.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.button6.UseVisualStyleBackColor = True
'			Me.button6.Click += New System.EventHandler(Me.button6_Click)
			' 
			' groupBox4
			' 
			Me.groupBox4.Controls.Add(Me.button8)
			Me.groupBox4.Controls.Add(Me.button7)
			Me.groupBox4.Controls.Add(Me.CopyBtn)
			Me.groupBox4.Controls.Add(Me.ShowStart)
			Me.groupBox4.Controls.Add(Me.PasteBtn)
			Me.groupBox4.Controls.Add(Me.StartExplorer)
			Me.groupBox4.Location = New System.Drawing.Point(7, 15)
			Me.groupBox4.Name = "groupBox4"
			Me.groupBox4.Size = New System.Drawing.Size(99, 174)
			Me.groupBox4.TabIndex = 29
			Me.groupBox4.TabStop = False
			Me.groupBox4.Text = "Windows Functions"
			' 
			' button8
			' 
			Me.button8.Image = My.Resources.sss
			Me.button8.Location = New System.Drawing.Point(52, 124)
			Me.button8.Name = "button8"
			Me.button8.Size = New System.Drawing.Size(40, 40)
			Me.button8.TabIndex = 5
			Me.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.button8.UseVisualStyleBackColor = True
'			Me.button8.Click += New System.EventHandler(Me.button8_Click)
			' 
			' button7
			' 
			Me.button7.Image = My.Resources.Icon5
			Me.button7.Location = New System.Drawing.Point(7, 124)
			Me.button7.Name = "button7"
			Me.button7.Size = New System.Drawing.Size(40, 40)
			Me.button7.TabIndex = 4
			Me.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.button7.UseVisualStyleBackColor = True
'			Me.button7.Click += New System.EventHandler(Me.button7_Click)
			' 
			' groupBox5
			' 
			Me.groupBox5.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.groupBox5.ContextMenuStrip = Me.contextMenuStrip1
			Me.groupBox5.Controls.Add(Me.groupBox4)
			Me.groupBox5.Controls.Add(Me.groupBox1)
			Me.groupBox5.Controls.Add(Me.groupBox2)
			Me.groupBox5.Controls.Add(Me.groupBox3)
			Me.groupBox5.Location = New System.Drawing.Point(1013, -3)
			Me.groupBox5.Name = "groupBox5"
			Me.groupBox5.Size = New System.Drawing.Size(117, 571)
			Me.groupBox5.TabIndex = 30
			Me.groupBox5.TabStop = False
			' 
			' groupBox6
			' 
			Me.groupBox6.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.groupBox6.ContextMenuStrip = Me.contextMenuStrip1
			Me.groupBox6.Controls.Add(Me.IntervalScroll)
			Me.groupBox6.Controls.Add(Me.ResizeLabel)
			Me.groupBox6.Controls.Add(Me.QualityLabel)
			Me.groupBox6.Controls.Add(Me.IntervalLabel)
			Me.groupBox6.Controls.Add(Me.MinBtn)
			Me.groupBox6.Controls.Add(Me.QualityScroll)
			Me.groupBox6.Controls.Add(Me.RestoreMaxBtn)
			Me.groupBox6.Controls.Add(Me.ResizeScroll)
			Me.groupBox6.Controls.Add(Me.CloseBtn)
			Me.groupBox6.Location = New System.Drawing.Point(3, -3)
			Me.groupBox6.Name = "groupBox6"
			Me.groupBox6.Size = New System.Drawing.Size(1004, 49)
			Me.groupBox6.TabIndex = 31
			Me.groupBox6.TabStop = False
			' 
			' FrmVNC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1133, 601)
			Me.Controls.Add(Me.groupBox6)
			Me.Controls.Add(Me.groupBox5)
			Me.Controls.Add(Me.statusStrip1)
			Me.Controls.Add(Me.VNCBox)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MinimizeBox = False
			Me.MinimumSize = New System.Drawing.Size(1120, 632)
			Me.Name = "FrmVNC"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.VNCForm_FormClosing)
'			Me.Load += New System.EventHandler(Me.VNCForm_Load)
'			Me.Click += New System.EventHandler(Me.VNCForm_Click)
'			Me.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.VNCForm_KeyPress)
			DirectCast(Me.VNCBox, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.IntervalScroll, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.QualityScroll, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ResizeScroll, System.ComponentModel.ISupportInitialize).EndInit()
			Me.contextMenuStrip1.ResumeLayout(False)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox3.PerformLayout()
			Me.groupBox4.ResumeLayout(False)
			Me.groupBox5.ResumeLayout(False)
			Me.groupBox6.ResumeLayout(False)
			Me.groupBox6.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents timer1 As System.Windows.Forms.Timer
		Private WithEvents CopyBtn As System.Windows.Forms.Button
		Private WithEvents PasteBtn As System.Windows.Forms.Button
		Private WithEvents ShowStart As System.Windows.Forms.Button
		Private WithEvents StartExplorer As System.Windows.Forms.Button
		Private ResizeLabel As System.Windows.Forms.Label
		Private QualityLabel As System.Windows.Forms.Label
		Private IntervalLabel As System.Windows.Forms.Label
		Private WithEvents VNCBox As System.Windows.Forms.PictureBox
		Private WithEvents IntervalScroll As System.Windows.Forms.TrackBar
		Private WithEvents QualityScroll As System.Windows.Forms.TrackBar
		Private WithEvents ResizeScroll As System.Windows.Forms.TrackBar
		Private WithEvents CloseBtn As System.Windows.Forms.Button
		Private WithEvents RestoreMaxBtn As System.Windows.Forms.Button
		Private WithEvents MinBtn As System.Windows.Forms.Button
		Private WithEvents StartBrowserBtn As System.Windows.Forms.Button
		Private WithEvents button1 As System.Windows.Forms.Button
		Private WithEvents button2 As System.Windows.Forms.Button
		Private WithEvents button3 As System.Windows.Forms.Button
		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
		Private toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
		Private chkClone As System.Windows.Forms.CheckBox
		Private WithEvents timer2 As System.Windows.Forms.Timer
		Private WithEvents button4 As System.Windows.Forms.Button
		Private WithEvents button5 As System.Windows.Forms.Button
		Private contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
		Private textBoxEXE As System.Windows.Forms.TextBox
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private groupBox3 As System.Windows.Forms.GroupBox
		Private WithEvents button6 As System.Windows.Forms.Button
		Private groupBox4 As System.Windows.Forms.GroupBox
		Private groupBox5 As System.Windows.Forms.GroupBox
		Private WithEvents closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private groupBox6 As System.Windows.Forms.GroupBox
		Private WithEvents button7 As System.Windows.Forms.Button
		Private WithEvents button8 As System.Windows.Forms.Button
	End Class
End Namespace