<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POSControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblBillNo = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.tblClear = New System.Windows.Forms.ToolStripMenuItem
        Me.label7 = New System.Windows.Forms.Label
        Me.tblViewm = New System.Windows.Forms.ToolStripMenuItem
        Me.label6 = New System.Windows.Forms.Label
        Me.tblPost = New System.Windows.Forms.ToolStripMenuItem
        Me.mainmenu = New System.Windows.Forms.MenuStrip
        Me.tblReadcard = New System.Windows.Forms.ToolStripMenuItem
        Me.tblFinalize = New System.Windows.Forms.ToolStripMenuItem
        Me.tblRePrint = New System.Windows.Forms.ToolStripMenuItem
        Me.tblBillCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.grpMember = New System.Windows.Forms.GroupBox
        Me.lblName = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.lblSteward = New System.Windows.Forms.Label
        Me.txtOTNo = New System.Windows.Forms.TextBox
        Me.lblOrderNo = New System.Windows.Forms.Label
        Me.dtBillDate = New System.Windows.Forms.DateTimePicker
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblBillNoDisplay = New System.Windows.Forms.Label
        Me.txtStewCode = New System.Windows.Forms.TextBox
        Me.lblstewnamedisplay = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbTable = New System.Windows.Forms.ComboBox
        Me.lblAccNo = New System.Windows.Forms.Label
        Me.txtAccNo = New System.Windows.Forms.TextBox
        Me.lblItem = New System.Windows.Forms.Label
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.grdBilling = New ICMSPOS.KeyPressAwareDataGridView
        Me.pnlReprint = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnReprint = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBillNumber = New System.Windows.Forms.TextBox
        Me.pnlAcChange = New System.Windows.Forms.Panel
        Me.grpBillCancel = New System.Windows.Forms.GroupBox
        Me.btnCCancel = New System.Windows.Forms.Button
        Me.btnDone = New System.Windows.Forms.Button
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.OTNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.itemid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.hrate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bunitid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.aqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.oqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItmDetailId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CessTax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServTax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServCharge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EnServCharge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesAccount = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainmenu.SuspendLayout()
        Me.grpMember.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBilling, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReprint.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlAcChange.SuspendLayout()
        Me.grpBillCancel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBillNo
        '
        Me.lblBillNo.AutoSize = True
        Me.lblBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillNo.Location = New System.Drawing.Point(17, 10)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(54, 13)
        Me.lblBillNo.TabIndex = 11
        Me.lblBillNo.Text = "BILL NO :"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(415, 60)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(0, 13)
        Me.label8.TabIndex = 11
        '
        'pictureBox1
        '
        Me.pictureBox1.Location = New System.Drawing.Point(469, 32)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(74, 81)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox1.TabIndex = 10
        Me.pictureBox1.TabStop = False
        '
        'tblClear
        '
        Me.tblClear.Name = "tblClear"
        Me.tblClear.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.tblClear.Size = New System.Drawing.Size(106, 20)
        Me.tblClear.Text = "&New Bill(F8)        "
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(15, 73)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(121, 17)
        Me.label7.TabIndex = 9
        Me.label7.Visible = False
        '
        'tblViewm
        '
        Me.tblViewm.Name = "tblViewm"
        Me.tblViewm.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.tblViewm.Size = New System.Drawing.Size(135, 20)
        Me.tblViewm.Text = " &View Pending(F5)       "
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(64, 33)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(0, 13)
        Me.label6.TabIndex = 8
        '
        'tblPost
        '
        Me.tblPost.Name = "tblPost"
        Me.tblPost.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.tblPost.Size = New System.Drawing.Size(84, 20)
        Me.tblPost.Text = "&Save(F3)       "
        '
        'mainmenu
        '
        Me.mainmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tblReadcard, Me.tblClear, Me.tblPost, Me.tblViewm, Me.tblFinalize, Me.tblRePrint, Me.tblBillCancel})
        Me.mainmenu.Location = New System.Drawing.Point(0, 0)
        Me.mainmenu.Name = "mainmenu"
        Me.mainmenu.Size = New System.Drawing.Size(844, 24)
        Me.mainmenu.TabIndex = 6
        Me.mainmenu.Text = "menuStrip1"
        '
        'tblReadcard
        '
        Me.tblReadcard.Name = "tblReadcard"
        Me.tblReadcard.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.tblReadcard.Size = New System.Drawing.Size(111, 20)
        Me.tblReadcard.Text = "&Read Card(F6)      "
        '
        'tblFinalize
        '
        Me.tblFinalize.Name = "tblFinalize"
        Me.tblFinalize.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.tblFinalize.Size = New System.Drawing.Size(113, 20)
        Me.tblFinalize.Text = "&Post and Print(F7)"
        '
        'tblRePrint
        '
        Me.tblRePrint.Name = "tblRePrint"
        Me.tblRePrint.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.tblRePrint.Size = New System.Drawing.Size(77, 20)
        Me.tblRePrint.Text = "R&ePrint(F4)"
        '
        'tblBillCancel
        '
        Me.tblBillCancel.Name = "tblBillCancel"
        Me.tblBillCancel.Size = New System.Drawing.Size(94, 20)
        Me.tblBillCancel.Text = "Bill Cancel(F9)"
        Me.tblBillCancel.Visible = False
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(15, 58)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(56, 13)
        Me.label5.TabIndex = 7
        Me.label5.Text = "Address:"
        Me.label5.Visible = False
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(15, 33)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(43, 13)
        Me.label4.TabIndex = 6
        Me.label4.Text = "Type :"
        Me.label4.Visible = False
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(291, 35)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(0, 13)
        Me.label3.TabIndex = 5
        '
        'grpMember
        '
        Me.grpMember.Controls.Add(Me.label7)
        Me.grpMember.Controls.Add(Me.label6)
        Me.grpMember.Controls.Add(Me.label5)
        Me.grpMember.Controls.Add(Me.label4)
        Me.grpMember.Controls.Add(Me.lblName)
        Me.grpMember.Location = New System.Drawing.Point(702, 6)
        Me.grpMember.Margin = New System.Windows.Forms.Padding(0)
        Me.grpMember.Name = "grpMember"
        Me.grpMember.Size = New System.Drawing.Size(15, 22)
        Me.grpMember.TabIndex = 4
        Me.grpMember.TabStop = False
        Me.grpMember.Visible = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(15, 16)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(43, 13)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Name:"
        Me.lblName.Visible = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(291, 60)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(118, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "CURRENT BALANCE :"
        '
        'lblSteward
        '
        Me.lblSteward.AutoSize = True
        Me.lblSteward.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSteward.Location = New System.Drawing.Point(18, 95)
        Me.lblSteward.Name = "lblSteward"
        Me.lblSteward.Size = New System.Drawing.Size(101, 13)
        Me.lblSteward.TabIndex = 17
        Me.lblSteward.Text = "STEWARD CODE :"
        '
        'txtOTNo
        '
        Me.txtOTNo.Location = New System.Drawing.Point(132, 61)
        Me.txtOTNo.Name = "txtOTNo"
        Me.txtOTNo.Size = New System.Drawing.Size(100, 20)
        Me.txtOTNo.TabIndex = 1
        '
        'lblOrderNo
        '
        Me.lblOrderNo.AutoSize = True
        Me.lblOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderNo.Location = New System.Drawing.Point(15, 64)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(115, 13)
        Me.lblOrderNo.TabIndex = 15
        Me.lblOrderNo.Text = "ORDER TICKET NO. :"
        '
        'dtBillDate
        '
        Me.dtBillDate.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.dtBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtBillDate.Location = New System.Drawing.Point(364, 6)
        Me.dtBillDate.Name = "dtBillDate"
        Me.dtBillDate.Size = New System.Drawing.Size(133, 20)
        Me.dtBillDate.TabIndex = 6
        Me.dtBillDate.Value = New Date(2010, 4, 22, 0, 0, 0, 0)
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(291, 10)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(67, 13)
        Me.lblDate.TabIndex = 13
        Me.lblDate.Text = "BILL DATE :"
        '
        'lblBillNoDisplay
        '
        Me.lblBillNoDisplay.AutoSize = True
        Me.lblBillNoDisplay.Location = New System.Drawing.Point(92, 10)
        Me.lblBillNoDisplay.Name = "lblBillNoDisplay"
        Me.lblBillNoDisplay.Size = New System.Drawing.Size(0, 13)
        Me.lblBillNoDisplay.TabIndex = 12
        '
        'txtStewCode
        '
        Me.txtStewCode.Location = New System.Drawing.Point(132, 92)
        Me.txtStewCode.Name = "txtStewCode"
        Me.txtStewCode.Size = New System.Drawing.Size(100, 20)
        Me.txtStewCode.TabIndex = 2
        '
        'lblstewnamedisplay
        '
        Me.lblstewnamedisplay.AutoSize = True
        Me.lblstewnamedisplay.Location = New System.Drawing.Point(291, 95)
        Me.lblstewnamedisplay.Name = "lblstewnamedisplay"
        Me.lblstewnamedisplay.Size = New System.Drawing.Size(0, 13)
        Me.lblstewnamedisplay.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(512, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "TABLE NO. :"
        '
        'cmbTable
        '
        Me.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTable.FormattingEnabled = True
        Me.cmbTable.Location = New System.Drawing.Point(597, 7)
        Me.cmbTable.Name = "cmbTable"
        Me.cmbTable.Size = New System.Drawing.Size(100, 21)
        Me.cmbTable.Sorted = True
        Me.cmbTable.TabIndex = 3
        '
        'lblAccNo
        '
        Me.lblAccNo.AutoSize = True
        Me.lblAccNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccNo.Location = New System.Drawing.Point(17, 35)
        Me.lblAccNo.Name = "lblAccNo"
        Me.lblAccNo.Size = New System.Drawing.Size(82, 13)
        Me.lblAccNo.TabIndex = 21
        Me.lblAccNo.Text = "A/C NUMBER :"
        '
        'txtAccNo
        '
        Me.txtAccNo.Location = New System.Drawing.Point(131, 32)
        Me.txtAccNo.Name = "txtAccNo"
        Me.txtAccNo.Size = New System.Drawing.Size(100, 20)
        Me.txtAccNo.TabIndex = 0
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItem.ForeColor = System.Drawing.Color.Green
        Me.lblItem.Location = New System.Drawing.Point(12, 340)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(157, 13)
        Me.lblItem.TabIndex = 22
        Me.lblItem.Text = " Press {F10} to View Items"
        Me.lblItem.Visible = False
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.PictureBox5)
        Me.pnlMain.Controls.Add(Me.PictureBox4)
        Me.pnlMain.Controls.Add(Me.PictureBox3)
        Me.pnlMain.Controls.Add(Me.PictureBox2)
        Me.pnlMain.Controls.Add(Me.lblItem)
        Me.pnlMain.Controls.Add(Me.lblBillNo)
        Me.pnlMain.Controls.Add(Me.pictureBox1)
        Me.pnlMain.Controls.Add(Me.lblBillNoDisplay)
        Me.pnlMain.Controls.Add(Me.label8)
        Me.pnlMain.Controls.Add(Me.lblDate)
        Me.pnlMain.Controls.Add(Me.lblAccNo)
        Me.pnlMain.Controls.Add(Me.dtBillDate)
        Me.pnlMain.Controls.Add(Me.txtAccNo)
        Me.pnlMain.Controls.Add(Me.cmbTable)
        Me.pnlMain.Controls.Add(Me.txtOTNo)
        Me.pnlMain.Controls.Add(Me.Label9)
        Me.pnlMain.Controls.Add(Me.lblSteward)
        Me.pnlMain.Controls.Add(Me.lblstewnamedisplay)
        Me.pnlMain.Controls.Add(Me.grpMember)
        Me.pnlMain.Controls.Add(Me.txtStewCode)
        Me.pnlMain.Controls.Add(Me.grdBilling)
        Me.pnlMain.Controls.Add(Me.label3)
        Me.pnlMain.Controls.Add(Me.label1)
        Me.pnlMain.Controls.Add(Me.lblOrderNo)
        Me.pnlMain.Location = New System.Drawing.Point(13, 27)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(828, 421)
        Me.pnlMain.TabIndex = 23
        '
        'PictureBox5
        '
        Me.PictureBox5.Location = New System.Drawing.Point(735, 35)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(57, 77)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 26
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Location = New System.Drawing.Point(677, 34)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(52, 79)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 25
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(616, 35)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(55, 77)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 24
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(549, 34)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(61, 78)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'grdBilling
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdBilling.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBilling.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OTNo, Me.itemcode, Me.itemname, Me.unit, Me.rate, Me.quantity, Me.amount, Me.itemid, Me.hrate, Me.bunitid, Me.aqty, Me.oqty, Me.ItmDetailId, Me.SalesTax, Me.CessTax, Me.ServTax, Me.ServCharge, Me.EnServCharge, Me.SalesAccount})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBilling.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdBilling.Location = New System.Drawing.Point(11, 118)
        Me.grdBilling.Name = "grdBilling"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdBilling.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdBilling.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdBilling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdBilling.Size = New System.Drawing.Size(754, 215)
        Me.grdBilling.TabIndex = 4
        '
        'pnlReprint
        '
        Me.pnlReprint.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pnlReprint.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlReprint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlReprint.Controls.Add(Me.GroupBox1)
        Me.pnlReprint.Location = New System.Drawing.Point(286, 88)
        Me.pnlReprint.Name = "pnlReprint"
        Me.pnlReprint.Size = New System.Drawing.Size(275, 191)
        Me.pnlReprint.TabIndex = 23
        Me.pnlReprint.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnReprint)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtBillNumber)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 151)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bill RePrint"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.Location = New System.Drawing.Point(122, 90)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnReprint
        '
        Me.btnReprint.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnReprint.Location = New System.Drawing.Point(15, 90)
        Me.btnReprint.Name = "btnReprint"
        Me.btnReprint.Size = New System.Drawing.Size(75, 23)
        Me.btnReprint.TabIndex = 2
        Me.btnReprint.Text = "Print"
        Me.btnReprint.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Enter Bill Number"
        '
        'txtBillNumber
        '
        Me.txtBillNumber.Location = New System.Drawing.Point(17, 48)
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(129, 23)
        Me.txtBillNumber.TabIndex = 0
        '
        'pnlAcChange
        '
        Me.pnlAcChange.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pnlAcChange.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlAcChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlAcChange.Controls.Add(Me.grpBillCancel)
        Me.pnlAcChange.Location = New System.Drawing.Point(269, 88)
        Me.pnlAcChange.Name = "pnlAcChange"
        Me.pnlAcChange.Size = New System.Drawing.Size(275, 191)
        Me.pnlAcChange.TabIndex = 24
        Me.pnlAcChange.Visible = False
        '
        'grpBillCancel
        '
        Me.grpBillCancel.Controls.Add(Me.btnCCancel)
        Me.grpBillCancel.Controls.Add(Me.btnDone)
        Me.grpBillCancel.Controls.Add(Me.txtReason)
        Me.grpBillCancel.Controls.Add(Me.Label10)
        Me.grpBillCancel.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBillCancel.Location = New System.Drawing.Point(14, 14)
        Me.grpBillCancel.Name = "grpBillCancel"
        Me.grpBillCancel.Size = New System.Drawing.Size(248, 151)
        Me.grpBillCancel.TabIndex = 0
        Me.grpBillCancel.TabStop = False
        Me.grpBillCancel.Text = "Bill Cancel"
        '
        'btnCCancel
        '
        Me.btnCCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCCancel.Location = New System.Drawing.Point(122, 120)
        Me.btnCCancel.Name = "btnCCancel"
        Me.btnCCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCCancel.TabIndex = 3
        Me.btnCCancel.Text = "Cancel"
        Me.btnCCancel.UseVisualStyleBackColor = False
        '
        'btnDone
        '
        Me.btnDone.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnDone.Location = New System.Drawing.Point(15, 120)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(75, 23)
        Me.btnDone.TabIndex = 2
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = False
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(15, 44)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(225, 70)
        Me.txtReason.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 16)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Enter Reason"
        '
        'OTNo
        '
        Me.OTNo.HeaderText = "OT No."
        Me.OTNo.Name = "OTNo"
        Me.OTNo.ReadOnly = True
        Me.OTNo.Width = 80
        '
        'itemcode
        '
        Me.itemcode.HeaderText = "Item Code"
        Me.itemcode.Name = "itemcode"
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item Name"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        Me.itemname.Width = 280
        '
        'unit
        '
        Me.unit.HeaderText = "Unit"
        Me.unit.Name = "unit"
        Me.unit.ReadOnly = True
        Me.unit.Visible = False
        '
        'rate
        '
        Me.rate.HeaderText = "Rate"
        Me.rate.Name = "rate"
        Me.rate.ReadOnly = True
        Me.rate.Width = 80
        '
        'quantity
        '
        Me.quantity.DataPropertyName = "Integer"
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        Me.quantity.Width = 80
        '
        'amount
        '
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        '
        'itemid
        '
        Me.itemid.HeaderText = "ItemID"
        Me.itemid.Name = "itemid"
        Me.itemid.Visible = False
        '
        'hrate
        '
        Me.hrate.HeaderText = "hrate"
        Me.hrate.Name = "hrate"
        Me.hrate.Visible = False
        '
        'bunitid
        '
        Me.bunitid.HeaderText = "bunitid"
        Me.bunitid.Name = "bunitid"
        Me.bunitid.Visible = False
        '
        'aqty
        '
        Me.aqty.HeaderText = "aqty"
        Me.aqty.Name = "aqty"
        Me.aqty.Visible = False
        '
        'oqty
        '
        Me.oqty.HeaderText = "oqty"
        Me.oqty.Name = "oqty"
        Me.oqty.Visible = False
        '
        'ItmDetailId
        '
        Me.ItmDetailId.HeaderText = "ItmDetailId"
        Me.ItmDetailId.Name = "ItmDetailId"
        Me.ItmDetailId.Visible = False
        '
        'SalesTax
        '
        Me.SalesTax.HeaderText = "SalesTax"
        Me.SalesTax.Name = "SalesTax"
        Me.SalesTax.Visible = False
        '
        'CessTax
        '
        Me.CessTax.HeaderText = "CessTax"
        Me.CessTax.Name = "CessTax"
        Me.CessTax.Visible = False
        '
        'ServTax
        '
        Me.ServTax.HeaderText = "ServTax"
        Me.ServTax.Name = "ServTax"
        Me.ServTax.Visible = False
        '
        'ServCharge
        '
        Me.ServCharge.HeaderText = "ServCharge"
        Me.ServCharge.Name = "ServCharge"
        Me.ServCharge.Visible = False
        '
        'EnServCharge
        '
        Me.EnServCharge.HeaderText = "EnServCharge"
        Me.EnServCharge.Name = "EnServCharge"
        Me.EnServCharge.Visible = False
        '
        'SalesAccount
        '
        Me.SalesAccount.HeaderText = "SalesAccount"
        Me.SalesAccount.Name = "SalesAccount"
        Me.SalesAccount.Visible = False
        '
        'POSControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlAcChange)
        Me.Controls.Add(Me.pnlReprint)
        Me.Controls.Add(Me.mainmenu)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "POSControl"
        Me.Size = New System.Drawing.Size(844, 458)
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainmenu.ResumeLayout(False)
        Me.mainmenu.PerformLayout()
        Me.grpMember.ResumeLayout(False)
        Me.grpMember.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBilling, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReprint.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlAcChange.ResumeLayout(False)
        Me.grpBillCancel.ResumeLayout(False)
        Me.grpBillCancel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblBillNo As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents tblClear As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents tblViewm As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents tblPost As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mainmenu As System.Windows.Forms.MenuStrip
    Private WithEvents tblReadcard As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents grdBilling As KeyPressAwareDataGridView ' System.Windows.Forms.DataGridView
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents grpMember As System.Windows.Forms.GroupBox
    Private WithEvents lblName As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents lblSteward As System.Windows.Forms.Label
    Private WithEvents txtOTNo As System.Windows.Forms.TextBox
    Private WithEvents lblOrderNo As System.Windows.Forms.Label
    Private WithEvents dtBillDate As System.Windows.Forms.DateTimePicker
    Private WithEvents lblDate As System.Windows.Forms.Label
    Private WithEvents lblBillNoDisplay As System.Windows.Forms.Label
    Friend WithEvents txtStewCode As System.Windows.Forms.TextBox
    Friend WithEvents tblFinalize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblstewnamedisplay As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbTable As System.Windows.Forms.ComboBox
    Private WithEvents lblAccNo As System.Windows.Forms.Label
    Private WithEvents txtAccNo As System.Windows.Forms.TextBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents tblRePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlReprint As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBillNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnReprint As System.Windows.Forms.Button
    Friend WithEvents pnlAcChange As System.Windows.Forms.Panel
    Friend WithEvents grpBillCancel As System.Windows.Forms.GroupBox
    Friend WithEvents btnCCancel As System.Windows.Forms.Button
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents tblBillCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents OTNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hrate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bunitid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents oqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItmDetailId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CessTax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServTax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServCharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnServCharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesAccount As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
