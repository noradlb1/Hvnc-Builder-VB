Namespace HVNC
	Partial Public Class FrmMain
		''' <summary>
		''' Variable nécessaire au concepteur.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Nettoyage des ressources utilisées.
		''' </summary>
		''' <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Code généré par le Concepteur Windows Form"

		''' <summary>
		''' Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		''' le contenu de cette méthode avec l'éditeur de code.
		''' </summary>
		Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
            Me.HVNCList = New System.Windows.Forms.ListView()
            Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.HVNCListenBtn = New System.Windows.Forms.ToolStripMenuItem()
            Me.portToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.HVNCListenPort = New System.Windows.Forms.ToolStripTextBox()
            Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.listenningAtStartupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.listenning1 = New System.Windows.Forms.ToolStripComboBox()
            Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.buildHVNCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.startHVNCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
            Me.contextMenuStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'HVNCList
            '
            Me.HVNCList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.HVNCList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5, Me.columnHeader6, Me.columnHeader7})
            Me.HVNCList.FullRowSelect = True
            Me.HVNCList.GridLines = True
            Me.HVNCList.HideSelection = False
            Me.HVNCList.Location = New System.Drawing.Point(14, 12)
            Me.HVNCList.Name = "HVNCList"
            Me.HVNCList.Size = New System.Drawing.Size(998, 458)
            Me.HVNCList.SmallImageList = Me.imageList1
            Me.HVNCList.TabIndex = 1
            Me.HVNCList.UseCompatibleStateImageBehavior = False
            Me.HVNCList.View = System.Windows.Forms.View.Details
            '
            'columnHeader1
            '
            Me.columnHeader1.Text = "Identifier"
            Me.columnHeader1.Width = 135
            '
            'columnHeader2
            '
            Me.columnHeader2.Text = "IP / DNS"
            Me.columnHeader2.Width = 141
            '
            'columnHeader3
            '
            Me.columnHeader3.Text = "User@PC"
            Me.columnHeader3.Width = 176
            '
            'columnHeader4
            '
            Me.columnHeader4.Text = "Country"
            Me.columnHeader4.Width = 100
            '
            'columnHeader5
            '
            Me.columnHeader5.Text = "Operationg System"
            Me.columnHeader5.Width = 198
            '
            'columnHeader6
            '
            Me.columnHeader6.Text = "Install Date"
            Me.columnHeader6.Width = 153
            '
            'columnHeader7
            '
            Me.columnHeader7.Text = "Version"
            Me.columnHeader7.Width = 82
            '
            'imageList1
            '
            Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
            Me.imageList1.Images.SetKeyName(0, "ad.png")
            Me.imageList1.Images.SetKeyName(1, "ae.png")
            Me.imageList1.Images.SetKeyName(2, "af.png")
            Me.imageList1.Images.SetKeyName(3, "ag.png")
            Me.imageList1.Images.SetKeyName(4, "ai.png")
            Me.imageList1.Images.SetKeyName(5, "al.png")
            Me.imageList1.Images.SetKeyName(6, "am.png")
            Me.imageList1.Images.SetKeyName(7, "an.png")
            Me.imageList1.Images.SetKeyName(8, "ao.png")
            Me.imageList1.Images.SetKeyName(9, "ar.png")
            Me.imageList1.Images.SetKeyName(10, "as.png")
            Me.imageList1.Images.SetKeyName(11, "at.png")
            Me.imageList1.Images.SetKeyName(12, "au.png")
            Me.imageList1.Images.SetKeyName(13, "aw.png")
            Me.imageList1.Images.SetKeyName(14, "ax.png")
            Me.imageList1.Images.SetKeyName(15, "az.png")
            Me.imageList1.Images.SetKeyName(16, "ba.png")
            Me.imageList1.Images.SetKeyName(17, "bb.png")
            Me.imageList1.Images.SetKeyName(18, "bd.png")
            Me.imageList1.Images.SetKeyName(19, "be.png")
            Me.imageList1.Images.SetKeyName(20, "bf.png")
            Me.imageList1.Images.SetKeyName(21, "bg.png")
            Me.imageList1.Images.SetKeyName(22, "bh.png")
            Me.imageList1.Images.SetKeyName(23, "bi.png")
            Me.imageList1.Images.SetKeyName(24, "bj.png")
            Me.imageList1.Images.SetKeyName(25, "bm.png")
            Me.imageList1.Images.SetKeyName(26, "bn.png")
            Me.imageList1.Images.SetKeyName(27, "bo.png")
            Me.imageList1.Images.SetKeyName(28, "br.png")
            Me.imageList1.Images.SetKeyName(29, "bs.png")
            Me.imageList1.Images.SetKeyName(30, "bt.png")
            Me.imageList1.Images.SetKeyName(31, "bv.png")
            Me.imageList1.Images.SetKeyName(32, "bw.png")
            Me.imageList1.Images.SetKeyName(33, "by.png")
            Me.imageList1.Images.SetKeyName(34, "bz.png")
            Me.imageList1.Images.SetKeyName(35, "ca.png")
            Me.imageList1.Images.SetKeyName(36, "catalonia.png")
            Me.imageList1.Images.SetKeyName(37, "cc.png")
            Me.imageList1.Images.SetKeyName(38, "cd.png")
            Me.imageList1.Images.SetKeyName(39, "cf.png")
            Me.imageList1.Images.SetKeyName(40, "cg.png")
            Me.imageList1.Images.SetKeyName(41, "ch.png")
            Me.imageList1.Images.SetKeyName(42, "ci.png")
            Me.imageList1.Images.SetKeyName(43, "ck.png")
            Me.imageList1.Images.SetKeyName(44, "cl.png")
            Me.imageList1.Images.SetKeyName(45, "cm.png")
            Me.imageList1.Images.SetKeyName(46, "cn.png")
            Me.imageList1.Images.SetKeyName(47, "co.png")
            Me.imageList1.Images.SetKeyName(48, "cr.png")
            Me.imageList1.Images.SetKeyName(49, "cs.png")
            Me.imageList1.Images.SetKeyName(50, "cu.png")
            Me.imageList1.Images.SetKeyName(51, "cv.png")
            Me.imageList1.Images.SetKeyName(52, "cx.png")
            Me.imageList1.Images.SetKeyName(53, "cy.png")
            Me.imageList1.Images.SetKeyName(54, "cz.png")
            Me.imageList1.Images.SetKeyName(55, "de.png")
            Me.imageList1.Images.SetKeyName(56, "dj.png")
            Me.imageList1.Images.SetKeyName(57, "dk.png")
            Me.imageList1.Images.SetKeyName(58, "dm.png")
            Me.imageList1.Images.SetKeyName(59, "do.png")
            Me.imageList1.Images.SetKeyName(60, "dz.png")
            Me.imageList1.Images.SetKeyName(61, "ec.png")
            Me.imageList1.Images.SetKeyName(62, "ee.png")
            Me.imageList1.Images.SetKeyName(63, "eg.png")
            Me.imageList1.Images.SetKeyName(64, "eh.png")
            Me.imageList1.Images.SetKeyName(65, "england.png")
            Me.imageList1.Images.SetKeyName(66, "er.png")
            Me.imageList1.Images.SetKeyName(67, "es.png")
            Me.imageList1.Images.SetKeyName(68, "et.png")
            Me.imageList1.Images.SetKeyName(69, "europeanunion.png")
            Me.imageList1.Images.SetKeyName(70, "fam.png")
            Me.imageList1.Images.SetKeyName(71, "fi.png")
            Me.imageList1.Images.SetKeyName(72, "fj.png")
            Me.imageList1.Images.SetKeyName(73, "fk.png")
            Me.imageList1.Images.SetKeyName(74, "fm.png")
            Me.imageList1.Images.SetKeyName(75, "fo.png")
            Me.imageList1.Images.SetKeyName(76, "fr.png")
            Me.imageList1.Images.SetKeyName(77, "ga.png")
            Me.imageList1.Images.SetKeyName(78, "gb.png")
            Me.imageList1.Images.SetKeyName(79, "gd.png")
            Me.imageList1.Images.SetKeyName(80, "ge.png")
            Me.imageList1.Images.SetKeyName(81, "gf.png")
            Me.imageList1.Images.SetKeyName(82, "gh.png")
            Me.imageList1.Images.SetKeyName(83, "gi.png")
            Me.imageList1.Images.SetKeyName(84, "gl.png")
            Me.imageList1.Images.SetKeyName(85, "gm.png")
            Me.imageList1.Images.SetKeyName(86, "gn.png")
            Me.imageList1.Images.SetKeyName(87, "gp.png")
            Me.imageList1.Images.SetKeyName(88, "gq.png")
            Me.imageList1.Images.SetKeyName(89, "gr.png")
            Me.imageList1.Images.SetKeyName(90, "gs.png")
            Me.imageList1.Images.SetKeyName(91, "gt.png")
            Me.imageList1.Images.SetKeyName(92, "gu.png")
            Me.imageList1.Images.SetKeyName(93, "gw.png")
            Me.imageList1.Images.SetKeyName(94, "gy.png")
            Me.imageList1.Images.SetKeyName(95, "hk.png")
            Me.imageList1.Images.SetKeyName(96, "hm.png")
            Me.imageList1.Images.SetKeyName(97, "hn.png")
            Me.imageList1.Images.SetKeyName(98, "hr.png")
            Me.imageList1.Images.SetKeyName(99, "ht.png")
            Me.imageList1.Images.SetKeyName(100, "hu.png")
            Me.imageList1.Images.SetKeyName(101, "id.png")
            Me.imageList1.Images.SetKeyName(102, "ie.png")
            Me.imageList1.Images.SetKeyName(103, "il.png")
            Me.imageList1.Images.SetKeyName(104, "in.png")
            Me.imageList1.Images.SetKeyName(105, "io.png")
            Me.imageList1.Images.SetKeyName(106, "iq.png")
            Me.imageList1.Images.SetKeyName(107, "ir.png")
            Me.imageList1.Images.SetKeyName(108, "is.png")
            Me.imageList1.Images.SetKeyName(109, "it.png")
            Me.imageList1.Images.SetKeyName(110, "jm.png")
            Me.imageList1.Images.SetKeyName(111, "jo.png")
            Me.imageList1.Images.SetKeyName(112, "jp.png")
            Me.imageList1.Images.SetKeyName(113, "ke.png")
            Me.imageList1.Images.SetKeyName(114, "kg.png")
            Me.imageList1.Images.SetKeyName(115, "kh.png")
            Me.imageList1.Images.SetKeyName(116, "ki.png")
            Me.imageList1.Images.SetKeyName(117, "km.png")
            Me.imageList1.Images.SetKeyName(118, "kn.png")
            Me.imageList1.Images.SetKeyName(119, "kp.png")
            Me.imageList1.Images.SetKeyName(120, "kr.png")
            Me.imageList1.Images.SetKeyName(121, "kw.png")
            Me.imageList1.Images.SetKeyName(122, "ky.png")
            Me.imageList1.Images.SetKeyName(123, "kz.png")
            Me.imageList1.Images.SetKeyName(124, "la.png")
            Me.imageList1.Images.SetKeyName(125, "lb.png")
            Me.imageList1.Images.SetKeyName(126, "lc.png")
            Me.imageList1.Images.SetKeyName(127, "li.png")
            Me.imageList1.Images.SetKeyName(128, "lk.png")
            Me.imageList1.Images.SetKeyName(129, "lr.png")
            Me.imageList1.Images.SetKeyName(130, "ls.png")
            Me.imageList1.Images.SetKeyName(131, "lt.png")
            Me.imageList1.Images.SetKeyName(132, "lu.png")
            Me.imageList1.Images.SetKeyName(133, "lv.png")
            Me.imageList1.Images.SetKeyName(134, "ly.png")
            Me.imageList1.Images.SetKeyName(135, "ma.png")
            Me.imageList1.Images.SetKeyName(136, "mc.png")
            Me.imageList1.Images.SetKeyName(137, "md.png")
            Me.imageList1.Images.SetKeyName(138, "me.png")
            Me.imageList1.Images.SetKeyName(139, "mg.png")
            Me.imageList1.Images.SetKeyName(140, "mh.png")
            Me.imageList1.Images.SetKeyName(141, "mk.png")
            Me.imageList1.Images.SetKeyName(142, "ml.png")
            Me.imageList1.Images.SetKeyName(143, "mm.png")
            Me.imageList1.Images.SetKeyName(144, "mn.png")
            Me.imageList1.Images.SetKeyName(145, "mo.png")
            Me.imageList1.Images.SetKeyName(146, "mp.png")
            Me.imageList1.Images.SetKeyName(147, "mq.png")
            Me.imageList1.Images.SetKeyName(148, "mr.png")
            Me.imageList1.Images.SetKeyName(149, "ms.png")
            Me.imageList1.Images.SetKeyName(150, "mt.png")
            Me.imageList1.Images.SetKeyName(151, "mu.png")
            Me.imageList1.Images.SetKeyName(152, "mv.png")
            Me.imageList1.Images.SetKeyName(153, "mw.png")
            Me.imageList1.Images.SetKeyName(154, "mx.png")
            Me.imageList1.Images.SetKeyName(155, "my.png")
            Me.imageList1.Images.SetKeyName(156, "mz.png")
            Me.imageList1.Images.SetKeyName(157, "na.png")
            Me.imageList1.Images.SetKeyName(158, "nc.png")
            Me.imageList1.Images.SetKeyName(159, "ne.png")
            Me.imageList1.Images.SetKeyName(160, "nf.png")
            Me.imageList1.Images.SetKeyName(161, "ng.png")
            Me.imageList1.Images.SetKeyName(162, "ni.png")
            Me.imageList1.Images.SetKeyName(163, "nl.png")
            Me.imageList1.Images.SetKeyName(164, "no.png")
            Me.imageList1.Images.SetKeyName(165, "np.png")
            Me.imageList1.Images.SetKeyName(166, "nr.png")
            Me.imageList1.Images.SetKeyName(167, "nu.png")
            Me.imageList1.Images.SetKeyName(168, "nz.png")
            Me.imageList1.Images.SetKeyName(169, "om.png")
            Me.imageList1.Images.SetKeyName(170, "pa.png")
            Me.imageList1.Images.SetKeyName(171, "pe.png")
            Me.imageList1.Images.SetKeyName(172, "pf.png")
            Me.imageList1.Images.SetKeyName(173, "pg.png")
            Me.imageList1.Images.SetKeyName(174, "ph.png")
            Me.imageList1.Images.SetKeyName(175, "pk.png")
            Me.imageList1.Images.SetKeyName(176, "pl.png")
            Me.imageList1.Images.SetKeyName(177, "pm.png")
            Me.imageList1.Images.SetKeyName(178, "pn.png")
            Me.imageList1.Images.SetKeyName(179, "pr.png")
            Me.imageList1.Images.SetKeyName(180, "ps.png")
            Me.imageList1.Images.SetKeyName(181, "pt.png")
            Me.imageList1.Images.SetKeyName(182, "pw.png")
            Me.imageList1.Images.SetKeyName(183, "py.png")
            Me.imageList1.Images.SetKeyName(184, "qa.png")
            Me.imageList1.Images.SetKeyName(185, "re.png")
            Me.imageList1.Images.SetKeyName(186, "ro.png")
            Me.imageList1.Images.SetKeyName(187, "rs.png")
            Me.imageList1.Images.SetKeyName(188, "ru.png")
            Me.imageList1.Images.SetKeyName(189, "rw.png")
            Me.imageList1.Images.SetKeyName(190, "sa.png")
            Me.imageList1.Images.SetKeyName(191, "sb.png")
            Me.imageList1.Images.SetKeyName(192, "sc.png")
            Me.imageList1.Images.SetKeyName(193, "scotland.png")
            Me.imageList1.Images.SetKeyName(194, "sd.png")
            Me.imageList1.Images.SetKeyName(195, "se.png")
            Me.imageList1.Images.SetKeyName(196, "sg.png")
            Me.imageList1.Images.SetKeyName(197, "sh.png")
            Me.imageList1.Images.SetKeyName(198, "si.png")
            Me.imageList1.Images.SetKeyName(199, "sj.png")
            Me.imageList1.Images.SetKeyName(200, "sk.png")
            Me.imageList1.Images.SetKeyName(201, "sl.png")
            Me.imageList1.Images.SetKeyName(202, "sm.png")
            Me.imageList1.Images.SetKeyName(203, "sn.png")
            Me.imageList1.Images.SetKeyName(204, "so.png")
            Me.imageList1.Images.SetKeyName(205, "sr.png")
            Me.imageList1.Images.SetKeyName(206, "st.png")
            Me.imageList1.Images.SetKeyName(207, "sv.png")
            Me.imageList1.Images.SetKeyName(208, "sy.png")
            Me.imageList1.Images.SetKeyName(209, "sz.png")
            Me.imageList1.Images.SetKeyName(210, "tc.png")
            Me.imageList1.Images.SetKeyName(211, "td.png")
            Me.imageList1.Images.SetKeyName(212, "tf.png")
            Me.imageList1.Images.SetKeyName(213, "tg.png")
            Me.imageList1.Images.SetKeyName(214, "th.png")
            Me.imageList1.Images.SetKeyName(215, "tj.png")
            Me.imageList1.Images.SetKeyName(216, "tk.png")
            Me.imageList1.Images.SetKeyName(217, "tl.png")
            Me.imageList1.Images.SetKeyName(218, "tm.png")
            Me.imageList1.Images.SetKeyName(219, "tn.png")
            Me.imageList1.Images.SetKeyName(220, "to.png")
            Me.imageList1.Images.SetKeyName(221, "tr.png")
            Me.imageList1.Images.SetKeyName(222, "tt.png")
            Me.imageList1.Images.SetKeyName(223, "tv.png")
            Me.imageList1.Images.SetKeyName(224, "tw.png")
            Me.imageList1.Images.SetKeyName(225, "tz.png")
            Me.imageList1.Images.SetKeyName(226, "ua.png")
            Me.imageList1.Images.SetKeyName(227, "ug.png")
            Me.imageList1.Images.SetKeyName(228, "um.png")
            Me.imageList1.Images.SetKeyName(229, "us.png")
            Me.imageList1.Images.SetKeyName(230, "uy.png")
            Me.imageList1.Images.SetKeyName(231, "uz.png")
            Me.imageList1.Images.SetKeyName(232, "va.png")
            Me.imageList1.Images.SetKeyName(233, "vc.png")
            Me.imageList1.Images.SetKeyName(234, "ve.png")
            Me.imageList1.Images.SetKeyName(235, "vg.png")
            Me.imageList1.Images.SetKeyName(236, "vi.png")
            Me.imageList1.Images.SetKeyName(237, "vn.png")
            Me.imageList1.Images.SetKeyName(238, "vu.png")
            Me.imageList1.Images.SetKeyName(239, "wales.png")
            Me.imageList1.Images.SetKeyName(240, "wf.png")
            Me.imageList1.Images.SetKeyName(241, "ws.png")
            Me.imageList1.Images.SetKeyName(242, "ye.png")
            Me.imageList1.Images.SetKeyName(243, "yt.png")
            Me.imageList1.Images.SetKeyName(244, "za.png")
            Me.imageList1.Images.SetKeyName(245, "zm.png")
            Me.imageList1.Images.SetKeyName(246, "zw.png")
            '
            'contextMenuStrip1
            '
            Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HVNCListenBtn, Me.toolStripSeparator1, Me.buildHVNCToolStripMenuItem, Me.toolStripSeparator2, Me.startHVNCToolStripMenuItem})
            Me.contextMenuStrip1.Name = "contextMenuStrip1"
            Me.contextMenuStrip1.Size = New System.Drawing.Size(138, 82)
            '
            'HVNCListenBtn
            '
            Me.HVNCListenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.HVNCListenBtn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.portToolStripMenuItem, Me.HVNCListenPort, Me.toolStripSeparator3, Me.listenningAtStartupToolStripMenuItem, Me.listenning1})
            Me.HVNCListenBtn.Image = Global.My.Resources.Resources.server_disconnect
            Me.HVNCListenBtn.Name = "HVNCListenBtn"
            Me.HVNCListenBtn.Size = New System.Drawing.Size(137, 22)
            Me.HVNCListenBtn.Text = "Listen"
            '
            'portToolStripMenuItem
            '
            Me.portToolStripMenuItem.Image = Global.My.Resources.Resources.cog
            Me.portToolStripMenuItem.Name = "portToolStripMenuItem"
            Me.portToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
            Me.portToolStripMenuItem.Text = "Port :"
            '
            'HVNCListenPort
            '
            Me.HVNCListenPort.Name = "HVNCListenPort"
            Me.HVNCListenPort.Size = New System.Drawing.Size(100, 23)
            Me.HVNCListenPort.Text = "8081"
            '
            'toolStripSeparator3
            '
            Me.toolStripSeparator3.Name = "toolStripSeparator3"
            Me.toolStripSeparator3.Size = New System.Drawing.Size(185, 6)
            '
            'listenningAtStartupToolStripMenuItem
            '
            Me.listenningAtStartupToolStripMenuItem.Image = Global.My.Resources.Resources.monitoring
            Me.listenningAtStartupToolStripMenuItem.Name = "listenningAtStartupToolStripMenuItem"
            Me.listenningAtStartupToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
            Me.listenningAtStartupToolStripMenuItem.Text = "Listenning at startup :"
            '
            'listenning1
            '
            Me.listenning1.Items.AddRange(New Object() {"Disabled", "Enabled"})
            Me.listenning1.Name = "listenning1"
            Me.listenning1.Size = New System.Drawing.Size(121, 23)
            Me.listenning1.Text = "Disabled"
            '
            'toolStripSeparator1
            '
            Me.toolStripSeparator1.Name = "toolStripSeparator1"
            Me.toolStripSeparator1.Size = New System.Drawing.Size(134, 6)
            '
            'buildHVNCToolStripMenuItem
            '
            Me.buildHVNCToolStripMenuItem.Enabled = False
            Me.buildHVNCToolStripMenuItem.Image = Global.My.Resources.Resources.application_add
            Me.buildHVNCToolStripMenuItem.Name = "buildHVNCToolStripMenuItem"
            Me.buildHVNCToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
            Me.buildHVNCToolStripMenuItem.Text = "Build HVNC"
            '
            'toolStripSeparator2
            '
            Me.toolStripSeparator2.Name = "toolStripSeparator2"
            Me.toolStripSeparator2.Size = New System.Drawing.Size(134, 6)
            '
            'startHVNCToolStripMenuItem
            '
            Me.startHVNCToolStripMenuItem.Name = "startHVNCToolStripMenuItem"
            Me.startHVNCToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
            Me.startHVNCToolStripMenuItem.Text = "Start HVNC"
            '
            'imageList2
            '
            Me.imageList2.ImageStream = CType(resources.GetObject("imageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imageList2.TransparentColor = System.Drawing.Color.Transparent
            Me.imageList2.Images.SetKeyName(0, "server_delete.png")
            Me.imageList2.Images.SetKeyName(1, "server_disconnect.png")
            '
            'FrmMain
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1024, 482)
            Me.ContextMenuStrip = Me.contextMenuStrip1
            Me.Controls.Add(Me.HVNCList)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MinimumSize = New System.Drawing.Size(1040, 521)
            Me.Name = "FrmMain"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "{ HVNC 1.0.0.1 } VB- Connections: 0"
            Me.contextMenuStrip1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region
        Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
		Private WithEvents contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
		Private WithEvents HVNCListenBtn As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents HVNCListenPort As System.Windows.Forms.ToolStripTextBox
		Private WithEvents buildHVNCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
		Private columnHeader3 As System.Windows.Forms.ColumnHeader
		Private columnHeader4 As System.Windows.Forms.ColumnHeader
		Private columnHeader5 As System.Windows.Forms.ColumnHeader
		Private columnHeader6 As System.Windows.Forms.ColumnHeader
		Private columnHeader7 As System.Windows.Forms.ColumnHeader
		Private imageList1 As System.Windows.Forms.ImageList
		Private imageList2 As System.Windows.Forms.ImageList
		Private portToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
		Private listenningAtStartupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents listenning1 As System.Windows.Forms.ToolStripComboBox
		Private WithEvents HVNCList As System.Windows.Forms.ListView
		Private WithEvents startHVNCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	End Class
End Namespace

