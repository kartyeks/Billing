namespace BillingManager.Forms
{
    partial class BillSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.tblSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tblClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tblClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tblBCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtKOT = new System.Windows.Forms.TextBox();
            this.pnlAcChange = new System.Windows.Forms.Panel();
            this.grpBillCancel = new System.Windows.Forms.GroupBox();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.btnCCancel = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPOSID = new System.Windows.Forms.TextBox();
            this.txtTotAmt = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grdBill = new System.Windows.Forms.DataGridView();
            this.Chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPaymentMode = new System.Windows.Forms.Panel();
            this.lblPaymentMode = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.pnlCardDetails = new System.Windows.Forms.Panel();
            this.lblBankName = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.cmbAcquirer = new System.Windows.Forms.ComboBox();
            this.cmbCardType = new System.Windows.Forms.ComboBox();
            this.lblAcquirer = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.btnPayBill = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.pnlMemberDetails = new System.Windows.Forms.Panel();
            this.lblAccNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.mainmenu.SuspendLayout();
            this.pnlAcChange.SuspendLayout();
            this.grpBillCancel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBill)).BeginInit();
            this.pnlPaymentMode.SuspendLayout();
            this.pnlCardDetails.SuspendLayout();
            this.pnlMemberDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainmenu
            // 
            this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tblSelect,
            this.tblClose,
            this.tblClear,
            this.tblBCancel});
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(661, 24);
            this.mainmenu.TabIndex = 15;
            this.mainmenu.Text = "menuStrip1";
            this.mainmenu.Visible = false;
            // 
            // tblSelect
            // 
            this.tblSelect.Name = "tblSelect";
            this.tblSelect.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.tblSelect.Size = new System.Drawing.Size(53, 20);
            this.tblSelect.Text = "&Select ";
            this.tblSelect.Click += new System.EventHandler(this.tblSelect_Click);
            // 
            // tblClose
            // 
            this.tblClose.Name = "tblClose";
            this.tblClose.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tblClose.Size = new System.Drawing.Size(48, 20);
            this.tblClose.Text = "&Close";
            this.tblClose.Click += new System.EventHandler(this.tblClose_Click);
            // 
            // tblClear
            // 
            this.tblClear.Name = "tblClear";
            this.tblClear.Size = new System.Drawing.Size(46, 20);
            this.tblClear.Text = "Clear";
            this.tblClear.Click += new System.EventHandler(this.tblClear_Click);
            // 
            // tblBCancel
            // 
            this.tblBCancel.Name = "tblBCancel";
            this.tblBCancel.Size = new System.Drawing.Size(71, 20);
            this.tblBCancel.Text = "Delete Bill";
            this.tblBCancel.Click += new System.EventHandler(this.tblBCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(441, 553);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total Amount";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(561, 68);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete Bill";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtKOT
            // 
            this.txtKOT.Location = new System.Drawing.Point(715, 9);
            this.txtKOT.Name = "txtKOT";
            this.txtKOT.Size = new System.Drawing.Size(48, 20);
            this.txtKOT.TabIndex = 18;
            this.txtKOT.Visible = false;
            this.txtKOT.TextChanged += new System.EventHandler(this.txtKOT_TextChanged);
            // 
            // pnlAcChange
            // 
            this.pnlAcChange.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.pnlAcChange.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlAcChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAcChange.Controls.Add(this.grpBillCancel);
            this.pnlAcChange.Location = new System.Drawing.Point(239, 351);
            this.pnlAcChange.Name = "pnlAcChange";
            this.pnlAcChange.Size = new System.Drawing.Size(275, 191);
            this.pnlAcChange.TabIndex = 13;
            this.pnlAcChange.Visible = false;
            // 
            // grpBillCancel
            // 
            this.grpBillCancel.Controls.Add(this.lblBillNo);
            this.grpBillCancel.Controls.Add(this.btnCCancel);
            this.grpBillCancel.Controls.Add(this.btnDone);
            this.grpBillCancel.Controls.Add(this.txtReason);
            this.grpBillCancel.Controls.Add(this.Label10);
            this.grpBillCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBillCancel.Location = new System.Drawing.Point(14, 14);
            this.grpBillCancel.Name = "grpBillCancel";
            this.grpBillCancel.Size = new System.Drawing.Size(248, 151);
            this.grpBillCancel.TabIndex = 0;
            this.grpBillCancel.TabStop = false;
            this.grpBillCancel.Text = "Bill Number";
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.Location = new System.Drawing.Point(39, 30);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(0, 16);
            this.lblBillNo.TabIndex = 0;
            // 
            // btnCCancel
            // 
            this.btnCCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCCancel.Location = new System.Drawing.Point(122, 120);
            this.btnCCancel.Name = "btnCCancel";
            this.btnCCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCCancel.TabIndex = 1;
            this.btnCCancel.Text = "Cancel";
            this.btnCCancel.UseVisualStyleBackColor = false;
            this.btnCCancel.Click += new System.EventHandler(this.btnCCancel_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDone.Location = new System.Drawing.Point(15, 120);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(15, 44);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(225, 16);
            this.txtReason.TabIndex = 3;
            this.txtReason.Visible = false;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(14, 28);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(95, 16);
            this.Label10.TabIndex = 4;
            this.Label10.Text = "Enter Reason";
            this.Label10.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(646, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "OT Number";
            this.label7.Visible = false;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtPOSID
            // 
            this.txtPOSID.Location = new System.Drawing.Point(610, 6);
            this.txtPOSID.Name = "txtPOSID";
            this.txtPOSID.Size = new System.Drawing.Size(30, 20);
            this.txtPOSID.TabIndex = 2;
            this.txtPOSID.Visible = false;
            this.txtPOSID.TextChanged += new System.EventHandler(this.txtPOSID_TextChanged);
            this.txtPOSID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPOSID_KeyDown);
            // 
            // txtTotAmt
            // 
            this.txtTotAmt.Location = new System.Drawing.Point(527, 548);
            this.txtTotAmt.Name = "txtTotAmt";
            this.txtTotAmt.ReadOnly = true;
            this.txtTotAmt.Size = new System.Drawing.Size(107, 20);
            this.txtTotAmt.TabIndex = 17;
            this.txtTotAmt.TabStop = false;
            this.txtTotAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(399, 68);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Search";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(49, 548);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(40, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 45);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(225, 15);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(104, 20);
            this.dtTo.TabIndex = 5;
            this.dtTo.Value = new System.DateTime(2011, 9, 12, 0, 0, 0, 0);
            this.dtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtTo_KeyDown);
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(51, 16);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(104, 20);
            this.dtFrom.TabIndex = 4;
            this.dtFrom.Value = new System.DateTime(2011, 9, 12, 0, 0, 0, 0);
            this.dtFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFrom_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "From";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(480, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(649, 67);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 20;
            this.btnPay.Text = "Settel Bill";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(558, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "POS ID";
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(672, 35);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(59, 20);
            this.txtMemberID.TabIndex = 1;
            this.txtMemberID.Visible = false;
            this.txtMemberID.TextChanged += new System.EventHandler(this.txtMemberID_TextChanged);
            this.txtMemberID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMemberID_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(672, 548);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(229, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Bill Number";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(292, 27);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(112, 20);
            this.txtBillNumber.TabIndex = 3;
            this.txtBillNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBillNumber_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(609, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Member ID";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // grdBill
            // 
            this.grdBill.AllowUserToAddRows = false;
            this.grdBill.AllowUserToDeleteRows = false;
            this.grdBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chk,
            this.BillID,
            this.BillNumber,
            this.BillDate,
            this.Member,
            this.MemberID,
            this.BillAmount,
            this.Counter,
            this.Status});
            this.grdBill.Location = new System.Drawing.Point(28, 235);
            this.grdBill.Name = "grdBill";
            this.grdBill.Size = new System.Drawing.Size(729, 307);
            this.grdBill.TabIndex = 11;
            this.grdBill.DoubleClick += new System.EventHandler(this.grdBill_DoubleClick);
            this.grdBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBill_CellContentClick);
            // 
            // Chk
            // 
            this.Chk.HeaderText = "Select";
            this.Chk.Name = "Chk";
            this.Chk.Visible = false;
            this.Chk.Width = 50;
            // 
            // BillID
            // 
            this.BillID.HeaderText = "BillID";
            this.BillID.Name = "BillID";
            this.BillID.ReadOnly = true;
            this.BillID.Visible = false;
            // 
            // BillNumber
            // 
            this.BillNumber.HeaderText = "Bill Number";
            this.BillNumber.Name = "BillNumber";
            this.BillNumber.ReadOnly = true;
            // 
            // BillDate
            // 
            this.BillDate.HeaderText = "Bill Date";
            this.BillDate.Name = "BillDate";
            this.BillDate.ReadOnly = true;
            this.BillDate.Width = 80;
            // 
            // Member
            // 
            this.Member.HeaderText = "Member";
            this.Member.Name = "Member";
            this.Member.ReadOnly = true;
            this.Member.Width = 200;
            // 
            // MemberID
            // 
            this.MemberID.HeaderText = "MemberID";
            this.MemberID.Name = "MemberID";
            this.MemberID.ReadOnly = true;
            this.MemberID.Visible = false;
            // 
            // BillAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BillAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.BillAmount.HeaderText = "Bill Amount";
            this.BillAmount.Name = "BillAmount";
            this.BillAmount.ReadOnly = true;
            // 
            // Counter
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Counter.DefaultCellStyle = dataGridViewCellStyle2;
            this.Counter.HeaderText = "Counter";
            this.Counter.Name = "Counter";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // pnlPaymentMode
            // 
            this.pnlPaymentMode.BackColor = System.Drawing.Color.Transparent;
            this.pnlPaymentMode.Controls.Add(this.lblPaymentMode);
            this.pnlPaymentMode.Controls.Add(this.cmbPaymentMode);
            this.pnlPaymentMode.Location = new System.Drawing.Point(40, 104);
            this.pnlPaymentMode.Name = "pnlPaymentMode";
            this.pnlPaymentMode.Size = new System.Drawing.Size(252, 26);
            this.pnlPaymentMode.TabIndex = 115;
            this.pnlPaymentMode.Visible = false;
            // 
            // lblPaymentMode
            // 
            this.lblPaymentMode.AutoSize = true;
            this.lblPaymentMode.Location = new System.Drawing.Point(3, 6);
            this.lblPaymentMode.Name = "lblPaymentMode";
            this.lblPaymentMode.Size = new System.Drawing.Size(94, 13);
            this.lblPaymentMode.TabIndex = 101;
            this.lblPaymentMode.Text = "PAYMENT MODE";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Items.AddRange(new object[] {
            "Cash",
            "Credit Card",
            "Member"});
            this.cmbPaymentMode.Location = new System.Drawing.Point(103, 3);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(140, 21);
            this.cmbPaymentMode.TabIndex = 103;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // pnlCardDetails
            // 
            this.pnlCardDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlCardDetails.Controls.Add(this.lblBankName);
            this.pnlCardDetails.Controls.Add(this.txtCardNumber);
            this.pnlCardDetails.Controls.Add(this.txtBankName);
            this.pnlCardDetails.Controls.Add(this.lblCardNumber);
            this.pnlCardDetails.Controls.Add(this.cmbAcquirer);
            this.pnlCardDetails.Controls.Add(this.cmbCardType);
            this.pnlCardDetails.Controls.Add(this.lblAcquirer);
            this.pnlCardDetails.Controls.Add(this.lblCardType);
            this.pnlCardDetails.Location = new System.Drawing.Point(40, 165);
            this.pnlCardDetails.Name = "pnlCardDetails";
            this.pnlCardDetails.Size = new System.Drawing.Size(465, 68);
            this.pnlCardDetails.TabIndex = 114;
            this.pnlCardDetails.Visible = false;
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Location = new System.Drawing.Point(3, 7);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(102, 13);
            this.lblBankName.TabIndex = 104;
            this.lblBankName.Text = "CUSTOMER NAME";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(168, 35);
            this.txtCardNumber.MaxLength = 4;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(39, 20);
            this.txtCardNumber.TabIndex = 109;
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(107, 4);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(100, 20);
            this.txtBankName.TabIndex = 105;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(6, 39);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(113, 13);
            this.lblCardNumber.TabIndex = 108;
            this.lblCardNumber.Text = "NUMBER(Last 4 Digit)";
            // 
            // cmbAcquirer
            // 
            this.cmbAcquirer.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbAcquirer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcquirer.FormattingEnabled = true;
            this.cmbAcquirer.Location = new System.Drawing.Point(287, 35);
            this.cmbAcquirer.Name = "cmbAcquirer";
            this.cmbAcquirer.Size = new System.Drawing.Size(172, 21);
            this.cmbAcquirer.TabIndex = 107;
            // 
            // cmbCardType
            // 
            this.cmbCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardType.FormattingEnabled = true;
            this.cmbCardType.Location = new System.Drawing.Point(287, 2);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.Size = new System.Drawing.Size(172, 21);
            this.cmbCardType.TabIndex = 107;
            // 
            // lblAcquirer
            // 
            this.lblAcquirer.AutoSize = true;
            this.lblAcquirer.Location = new System.Drawing.Point(217, 39);
            this.lblAcquirer.Name = "lblAcquirer";
            this.lblAcquirer.Size = new System.Drawing.Size(63, 13);
            this.lblAcquirer.TabIndex = 106;
            this.lblAcquirer.Text = "ACQUIRER";
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(213, 7);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(68, 13);
            this.lblCardType.TabIndex = 106;
            this.lblCardType.Text = "CARD TYPE";
            // 
            // btnPayBill
            // 
            this.btnPayBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayBill.Location = new System.Drawing.Point(633, 178);
            this.btnPayBill.Name = "btnPayBill";
            this.btnPayBill.Size = new System.Drawing.Size(114, 51);
            this.btnPayBill.TabIndex = 20;
            this.btnPayBill.Text = "Pay";
            this.btnPayBill.UseVisualStyleBackColor = true;
            this.btnPayBill.Visible = false;
            this.btnPayBill.Click += new System.EventHandler(this.btnPayBill_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(299, 107);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read Card";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Visible = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // pnlMemberDetails
            // 
            this.pnlMemberDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlMemberDetails.Controls.Add(this.lblAccNo);
            this.pnlMemberDetails.Controls.Add(this.label8);
            this.pnlMemberDetails.Controls.Add(this.txtAccNo);
            this.pnlMemberDetails.Controls.Add(this.txtBalance);
            this.pnlMemberDetails.Controls.Add(this.txtMemberName);
            this.pnlMemberDetails.Location = new System.Drawing.Point(40, 134);
            this.pnlMemberDetails.Name = "pnlMemberDetails";
            this.pnlMemberDetails.Size = new System.Drawing.Size(555, 30);
            this.pnlMemberDetails.TabIndex = 116;
            this.pnlMemberDetails.Visible = false;
            // 
            // lblAccNo
            // 
            this.lblAccNo.AutoSize = true;
            this.lblAccNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccNo.Location = new System.Drawing.Point(3, 10);
            this.lblAccNo.Name = "lblAccNo";
            this.lblAccNo.Size = new System.Drawing.Size(54, 13);
            this.lblAccNo.TabIndex = 21;
            this.lblAccNo.Text = "MEMBER";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(338, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 100;
            this.label8.Text = "MEMBER BALANCE :";
            // 
            // txtAccNo
            // 
            this.txtAccNo.Enabled = false;
            this.txtAccNo.Location = new System.Drawing.Point(63, 5);
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.ReadOnly = true;
            this.txtAccNo.Size = new System.Drawing.Size(65, 20);
            this.txtAccNo.TabIndex = 1;
            // 
            // txtBalance
            // 
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBalance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.ForeColor = System.Drawing.Color.Blue;
            this.txtBalance.Location = new System.Drawing.Point(452, 4);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(90, 23);
            this.txtBalance.TabIndex = 97;
            // 
            // txtMemberName
            // 
            this.txtMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemberName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberName.ForeColor = System.Drawing.Color.Blue;
            this.txtMemberName.Location = new System.Drawing.Point(134, 4);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(202, 23);
            this.txtMemberName.TabIndex = 65;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.BackColor = System.Drawing.Color.Transparent;
            this.lblTable.Location = new System.Drawing.Point(40, 30);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(41, 13);
            this.lblTable.TabIndex = 117;
            this.lblTable.Text = "TABLE";
            // 
            // cmbTable
            // 
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(87, 28);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(121, 21);
            this.cmbTable.TabIndex = 118;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Location = new System.Drawing.Point(416, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 119;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Paid"});
            this.cmbStatus.Location = new System.Drawing.Point(469, 28);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 120;
            // 
            // BillSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BillingManager.Properties.Resources.bg_gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 586);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.pnlMemberDetails);
            this.Controls.Add(this.pnlPaymentMode);
            this.Controls.Add(this.pnlCardDetails);
            this.Controls.Add(this.grdBill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBillNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mainmenu);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtTotAmt);
            this.Controls.Add(this.txtKOT);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.txtPOSID);
            this.Controls.Add(this.pnlAcChange);
            this.Controls.Add(this.btnPayBill);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BIll Summary";
            this.Load += new System.EventHandler(this.BillSummary_Load);
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.pnlAcChange.ResumeLayout(false);
            this.grpBillCancel.ResumeLayout(false);
            this.grpBillCancel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBill)).EndInit();
            this.pnlPaymentMode.ResumeLayout(false);
            this.pnlPaymentMode.PerformLayout();
            this.pnlCardDetails.ResumeLayout(false);
            this.pnlCardDetails.PerformLayout();
            this.pnlMemberDetails.ResumeLayout(false);
            this.pnlMemberDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        

        

        

        

        

        #endregion

        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem tblSelect;
        private System.Windows.Forms.ToolStripMenuItem tblClose;
        private System.Windows.Forms.ToolStripMenuItem tblClear;
        private System.Windows.Forms.ToolStripMenuItem tblBCancel;
        private System.Windows.Forms.DataGridView grdBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBillNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtTotAmt;
        private System.Windows.Forms.TextBox txtPOSID;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Panel pnlAcChange;
        internal System.Windows.Forms.GroupBox grpBillCancel;
        private System.Windows.Forms.Label lblBillNo;
        internal System.Windows.Forms.Button btnCCancel;
        internal System.Windows.Forms.Button btnDone;
        internal System.Windows.Forms.TextBox txtReason;
        internal System.Windows.Forms.Label Label10;
        private System.Windows.Forms.TextBox txtKOT;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Counter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Panel pnlPaymentMode;
        private System.Windows.Forms.Label lblPaymentMode;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Panel pnlCardDetails;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.ComboBox cmbCardType;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.ComboBox cmbAcquirer;
        private System.Windows.Forms.Label lblAcquirer;
        private System.Windows.Forms.Button btnPayBill;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Panel pnlMemberDetails;
        private System.Windows.Forms.Label lblAccNo;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtAccNo;
        private System.Windows.Forms.Label txtBalance;
        private System.Windows.Forms.Label txtMemberName;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;



    }
}