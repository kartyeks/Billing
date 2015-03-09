using System.Windows.Forms;
namespace BillingManager.Forms
{
    partial class ICMSBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ICMSBill));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBillTo = new System.Windows.Forms.Label();
            this.cmbBillTo = new System.Windows.Forms.ComboBox();
            this.pnlMemberDetails = new System.Windows.Forms.Panel();
            this.lblAccNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.Label();
            this.cmbBillMode = new System.Windows.Forms.ComboBox();
            this.lblBillMode = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.txtVat = new System.Windows.Forms.TextBox();
            this.lblvat = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.chkHappyHour = new System.Windows.Forms.CheckBox();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.txtBearerName = new System.Windows.Forms.Label();
            this.btnMemSearch = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnKOTCancelSave = new System.Windows.Forms.Button();
            this.btnKOTSave = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.grpDep = new System.Windows.Forms.GroupBox();
            this.txtRelation = new System.Windows.Forms.TextBox();
            this.txtDependantName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblAvialableQty = new System.Windows.Forms.Label();
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Labe20 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.lblBAmt = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.lblBillNoDisplay = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtBillDate = new System.Windows.Forms.DateTimePicker();
            this.txtCounterName = new System.Windows.Forms.Label();
            this.lblSteward = new System.Windows.Forms.Label();
            this.txtStewCode = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunitid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItmDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CessTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnServCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.tblReadcard = new System.Windows.Forms.ToolStripMenuItem();
            this.tblClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tblPost = new System.Windows.Forms.ToolStripMenuItem();
            this.tblViewm = new System.Windows.Forms.ToolStripMenuItem();
            this.tblFinalize = new System.Windows.Forms.ToolStripMenuItem();
            this.tblRePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tblBillTo = new System.Windows.Forms.ToolStripMenuItem();
            this.tblModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tblBillCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.tblPending = new System.Windows.Forms.ToolStripMenuItem();
            this.tblExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn66 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn67 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn68 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn69 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn76 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdBilling = new BillingManager.KeyPressAwareDataGridView();
            this.SlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn77 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn79 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn82 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn81 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn83 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn84 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn85 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn86 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn87 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn88 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn89 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn95 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn96 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn97 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlMemberDetails.SuspendLayout();
            this.grpDep.SuspendLayout();
            this.mainmenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBilling)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.pnlMemberDetails);
            this.pnlMain.Controls.Add(this.cmbBillMode);
            this.pnlMain.Controls.Add(this.lblBillMode);
            this.pnlMain.Controls.Add(this.lblTable);
            this.pnlMain.Controls.Add(this.txtVat);
            this.pnlMain.Controls.Add(this.lblvat);
            this.pnlMain.Controls.Add(this.btnReport);
            this.pnlMain.Controls.Add(this.chkHappyHour);
            this.pnlMain.Controls.Add(this.btnFinalize);
            this.pnlMain.Controls.Add(this.txtBearerName);
            this.pnlMain.Controls.Add(this.btnMemSearch);
            this.pnlMain.Controls.Add(this.btnPending);
            this.pnlMain.Controls.Add(this.btnModify);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.btnKOTCancelSave);
            this.pnlMain.Controls.Add(this.btnKOTSave);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.btnNew);
            this.pnlMain.Controls.Add(this.btnReadCard);
            this.pnlMain.Controls.Add(this.grpDep);
            this.pnlMain.Controls.Add(this.lblAvialableQty);
            this.pnlMain.Controls.Add(this.txtBillAmount);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.txtNetAmount);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.cmbTable);
            this.pnlMain.Controls.Add(this.txtTax);
            this.pnlMain.Controls.Add(this.Label9);
            this.pnlMain.Controls.Add(this.Labe20);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtBillNo);
            this.pnlMain.Controls.Add(this.lblBAmt);
            this.pnlMain.Controls.Add(this.btnRemove);
            this.pnlMain.Controls.Add(this.grdBilling);
            this.pnlMain.Controls.Add(this.lblItem);
            this.pnlMain.Controls.Add(this.lblBillNo);
            this.pnlMain.Controls.Add(this.lblBillNoDisplay);
            this.pnlMain.Controls.Add(this.lblDate);
            this.pnlMain.Controls.Add(this.dtBillDate);
            this.pnlMain.Controls.Add(this.txtCounterName);
            this.pnlMain.Controls.Add(this.lblSteward);
            this.pnlMain.Controls.Add(this.txtStewCode);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(10);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(993, 635);
            this.pnlMain.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(964, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBillTo);
            this.panel1.Controls.Add(this.cmbBillTo);
            this.panel1.Location = new System.Drawing.Point(35, 502);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 36);
            this.panel1.TabIndex = 114;
            this.panel1.Visible = false;
            // 
            // lblBillTo
            // 
            this.lblBillTo.AutoSize = true;
            this.lblBillTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillTo.Location = new System.Drawing.Point(13, 10);
            this.lblBillTo.Name = "lblBillTo";
            this.lblBillTo.Size = new System.Drawing.Size(63, 13);
            this.lblBillTo.TabIndex = 95;
            this.lblBillTo.Text = "BILL TYPE:";
            this.lblBillTo.Visible = false;
            // 
            // cmbBillTo
            // 
            this.cmbBillTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBillTo.FormattingEnabled = true;
            this.cmbBillTo.Location = new System.Drawing.Point(75, 7);
            this.cmbBillTo.Name = "cmbBillTo";
            this.cmbBillTo.Size = new System.Drawing.Size(207, 21);
            this.cmbBillTo.Sorted = true;
            this.cmbBillTo.TabIndex = 96;
            this.cmbBillTo.Visible = false;
            this.cmbBillTo.SelectedIndexChanged += new System.EventHandler(this.cmbBillTo_SelectedIndexChanged);
            this.cmbBillTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBillTo_KeyDown);
            // 
            // pnlMemberDetails
            // 
            this.pnlMemberDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlMemberDetails.Controls.Add(this.lblAccNo);
            this.pnlMemberDetails.Controls.Add(this.label1);
            this.pnlMemberDetails.Controls.Add(this.txtAccNo);
            this.pnlMemberDetails.Controls.Add(this.txtBalance);
            this.pnlMemberDetails.Controls.Add(this.txtMemberName);
            this.pnlMemberDetails.Location = new System.Drawing.Point(14, 159);
            this.pnlMemberDetails.Name = "pnlMemberDetails";
            this.pnlMemberDetails.Size = new System.Drawing.Size(936, 30);
            this.pnlMemberDetails.TabIndex = 113;
            this.pnlMemberDetails.Visible = false;
            // 
            // lblAccNo
            // 
            this.lblAccNo.AutoSize = true;
            this.lblAccNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccNo.Location = new System.Drawing.Point(13, 9);
            this.lblAccNo.Name = "lblAccNo";
            this.lblAccNo.Size = new System.Drawing.Size(71, 13);
            this.lblAccNo.TabIndex = 21;
            this.lblAccNo.Text = "MEMBER ID ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(565, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "MEMBER BALANCE :";
            // 
            // txtAccNo
            // 
            this.txtAccNo.Location = new System.Drawing.Point(90, 4);
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Size = new System.Drawing.Size(147, 20);
            this.txtAccNo.TabIndex = 1;
            this.txtAccNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccNo_KeyDown);
            this.txtAccNo.Leave += new System.EventHandler(this.txtAccNo_Leave);
            // 
            // txtBalance
            // 
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBalance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.ForeColor = System.Drawing.Color.Blue;
            this.txtBalance.Location = new System.Drawing.Point(677, 4);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(132, 23);
            this.txtBalance.TabIndex = 97;
            // 
            // txtMemberName
            // 
            this.txtMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemberName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberName.ForeColor = System.Drawing.Color.Blue;
            this.txtMemberName.Location = new System.Drawing.Point(255, 4);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(296, 23);
            this.txtMemberName.TabIndex = 65;
            // 
            // cmbBillMode
            // 
            this.cmbBillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBillMode.FormattingEnabled = true;
            this.cmbBillMode.Items.AddRange(new object[] {
            "Walkin",
            "Member",
            "Affiliated Member",
            "Director"});
            this.cmbBillMode.Location = new System.Drawing.Point(549, 109);
            this.cmbBillMode.Name = "cmbBillMode";
            this.cmbBillMode.Size = new System.Drawing.Size(121, 21);
            this.cmbBillMode.TabIndex = 112;
            this.cmbBillMode.SelectedIndexChanged += new System.EventHandler(this.cmbBillMode_SelectedIndexChanged);
            // 
            // lblBillMode
            // 
            this.lblBillMode.AutoSize = true;
            this.lblBillMode.Location = new System.Drawing.Point(482, 111);
            this.lblBillMode.Name = "lblBillMode";
            this.lblBillMode.Size = new System.Drawing.Size(60, 13);
            this.lblBillMode.TabIndex = 111;
            this.lblBillMode.Text = "BILL TYPE";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(676, 112);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(91, 13);
            this.lblTable.TabIndex = 102;
            this.lblTable.Text = "TABLE NUMBER";
            // 
            // txtVat
            // 
            this.txtVat.Enabled = false;
            this.txtVat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtVat.Location = new System.Drawing.Point(732, 530);
            this.txtVat.Name = "txtVat";
            this.txtVat.ReadOnly = true;
            this.txtVat.Size = new System.Drawing.Size(100, 20);
            this.txtVat.TabIndex = 94;
            this.txtVat.TabStop = false;
            // 
            // lblvat
            // 
            this.lblvat.AutoSize = true;
            this.lblvat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvat.Location = new System.Drawing.Point(646, 534);
            this.lblvat.Name = "lblvat";
            this.lblvat.Size = new System.Drawing.Size(28, 14);
            this.lblvat.TabIndex = 93;
            this.lblvat.Text = "VAT";
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(845, 465);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(120, 23);
            this.btnReport.TabIndex = 66;
            this.btnReport.Text = "Reports";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // chkHappyHour
            // 
            this.chkHappyHour.AutoSize = true;
            this.chkHappyHour.Enabled = false;
            this.chkHappyHour.Location = new System.Drawing.Point(323, 555);
            this.chkHappyHour.Name = "chkHappyHour";
            this.chkHappyHour.Size = new System.Drawing.Size(113, 17);
            this.chkHappyHour.TabIndex = 63;
            this.chkHappyHour.Text = "Happy Hour Billing";
            this.chkHappyHour.UseVisualStyleBackColor = true;
            this.chkHappyHour.Visible = false;
            // 
            // btnFinalize
            // 
            this.btnFinalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalize.Location = new System.Drawing.Point(845, 344);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(120, 23);
            this.btnFinalize.TabIndex = 62;
            this.btnFinalize.Text = "&View OT F8 ";
            this.btnFinalize.UseVisualStyleBackColor = true;
            this.btnFinalize.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBearerName
            // 
            this.txtBearerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBearerName.Location = new System.Drawing.Point(268, 133);
            this.txtBearerName.Name = "txtBearerName";
            this.txtBearerName.Size = new System.Drawing.Size(296, 23);
            this.txtBearerName.TabIndex = 61;
            // 
            // btnMemSearch
            // 
            this.btnMemSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemSearch.Location = new System.Drawing.Point(845, 494);
            this.btnMemSearch.Name = "btnMemSearch";
            this.btnMemSearch.Size = new System.Drawing.Size(120, 23);
            this.btnMemSearch.TabIndex = 15;
            this.btnMemSearch.Text = "&Dep Search F4";
            this.btnMemSearch.UseVisualStyleBackColor = true;
            this.btnMemSearch.Visible = false;
            this.btnMemSearch.Click += new System.EventHandler(this.btnMemSearch_Click);
            // 
            // btnPending
            // 
            this.btnPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPending.Location = new System.Drawing.Point(845, 404);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(120, 23);
            this.btnPending.TabIndex = 14;
            this.btnPending.Text = "&View Pending F11";
            this.btnPending.UseVisualStyleBackColor = true;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(845, 374);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(120, 23);
            this.btnModify.TabIndex = 13;
            this.btnModify.Text = "&List F2";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(845, 436);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Log &off (Esc)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnKOTCancelSave
            // 
            this.btnKOTCancelSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKOTCancelSave.Location = new System.Drawing.Point(845, 314);
            this.btnKOTCancelSave.Name = "btnKOTCancelSave";
            this.btnKOTCancelSave.Size = new System.Drawing.Size(120, 23);
            this.btnKOTCancelSave.TabIndex = 53;
            this.btnKOTCancelSave.Text = "&OT Update/Print ";
            this.btnKOTCancelSave.UseVisualStyleBackColor = true;
            this.btnKOTCancelSave.Click += new System.EventHandler(this.btnKOTCancelSave_Click);
            // 
            // btnKOTSave
            // 
            this.btnKOTSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKOTSave.Location = new System.Drawing.Point(845, 284);
            this.btnKOTSave.Name = "btnKOTSave";
            this.btnKOTSave.Size = new System.Drawing.Size(120, 23);
            this.btnKOTSave.TabIndex = 53;
            this.btnKOTSave.Text = "&OT Bill/Print F7";
            this.btnKOTSave.UseVisualStyleBackColor = true;
            this.btnKOTSave.Click += new System.EventHandler(this.btnKOTSave_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(845, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Bill F5";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(845, 224);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 23);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "&New F3";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnReadCard
            // 
            this.btnReadCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadCard.Location = new System.Drawing.Point(845, 194);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(120, 23);
            this.btnReadCard.TabIndex = 10;
            this.btnReadCard.Text = "&Read Card  F6";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // grpDep
            // 
            this.grpDep.Controls.Add(this.txtRelation);
            this.grpDep.Controls.Add(this.txtDependantName);
            this.grpDep.Controls.Add(this.label12);
            this.grpDep.Controls.Add(this.label15);
            this.grpDep.Location = new System.Drawing.Point(346, 476);
            this.grpDep.Name = "grpDep";
            this.grpDep.Size = new System.Drawing.Size(294, 65);
            this.grpDep.TabIndex = 49;
            this.grpDep.TabStop = false;
            this.grpDep.Visible = false;
            // 
            // txtRelation
            // 
            this.txtRelation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRelation.Location = new System.Drawing.Point(125, 42);
            this.txtRelation.Name = "txtRelation";
            this.txtRelation.ReadOnly = true;
            this.txtRelation.Size = new System.Drawing.Size(157, 20);
            this.txtRelation.TabIndex = 62;
            this.txtRelation.TabStop = false;
            // 
            // txtDependantName
            // 
            this.txtDependantName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDependantName.Location = new System.Drawing.Point(125, 16);
            this.txtDependantName.Name = "txtDependantName";
            this.txtDependantName.ReadOnly = true;
            this.txtDependantName.Size = new System.Drawing.Size(157, 20);
            this.txtDependantName.TabIndex = 61;
            this.txtDependantName.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "RELATION";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(10, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "DEPENDANT NAME";
            // 
            // lblAvialableQty
            // 
            this.lblAvialableQty.AutoSize = true;
            this.lblAvialableQty.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvialableQty.ForeColor = System.Drawing.Color.Blue;
            this.lblAvialableQty.Location = new System.Drawing.Point(17, 522);
            this.lblAvialableQty.Name = "lblAvialableQty";
            this.lblAvialableQty.Size = new System.Drawing.Size(0, 22);
            this.lblAvialableQty.TabIndex = 48;
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Enabled = false;
            this.txtBillAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBillAmount.Location = new System.Drawing.Point(733, 476);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.ReadOnly = true;
            this.txtBillAmount.Size = new System.Drawing.Size(100, 20);
            this.txtBillAmount.TabIndex = 42;
            this.txtBillAmount.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(645, 486);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 14);
            this.label8.TabIndex = 41;
            this.label8.Text = "BILL Amount";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Enabled = false;
            this.txtNetAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNetAmount.Location = new System.Drawing.Point(731, 554);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(100, 20);
            this.txtNetAmount.TabIndex = 40;
            this.txtNetAmount.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(645, 558);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 39;
            this.label7.Text = "Net Amount";
            // 
            // cmbTable
            // 
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTable.Location = new System.Drawing.Point(772, 110);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(107, 21);
            this.cmbTable.Sorted = true;
            this.cmbTable.TabIndex = 0;
            this.cmbTable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTable_KeyPress);
            this.cmbTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTable_KeyDown);
            // 
            // txtTax
            // 
            this.txtTax.Enabled = false;
            this.txtTax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTax.Location = new System.Drawing.Point(731, 505);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(100, 20);
            this.txtTax.TabIndex = 38;
            this.txtTax.TabStop = false;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(579, 138);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(100, 13);
            this.Label9.TabIndex = 98;
            this.Label9.Text = "COUNTER NAME :";
            // 
            // Labe20
            // 
            this.Labe20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Labe20.Location = new System.Drawing.Point(829, 133);
            this.Labe20.Name = "Labe20";
            this.Labe20.Size = new System.Drawing.Size(124, 23);
            this.Labe20.TabIndex = 0;
            this.Labe20.TabStop = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(645, 509);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 14);
            this.label6.TabIndex = 37;
            this.label6.Text = "Service Tax";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(644, 489);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 35;
            this.label5.Text = "Total Discount";
            this.label5.Visible = false;
            // 
            // txtBillNo
            // 
            this.txtBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillNo.Location = new System.Drawing.Point(106, 109);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.ReadOnly = true;
            this.txtBillNo.Size = new System.Drawing.Size(147, 20);
            this.txtBillNo.TabIndex = 0;
            this.txtBillNo.TabStop = false;
            // 
            // lblBAmt
            // 
            this.lblBAmt.AutoSize = true;
            this.lblBAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBAmt.Location = new System.Drawing.Point(420, 527);
            this.lblBAmt.Name = "lblBAmt";
            this.lblBAmt.Size = new System.Drawing.Size(13, 13);
            this.lblBAmt.TabIndex = 33;
            this.lblBAmt.Text = "0";
            this.lblBAmt.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(845, 465);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(91, 23);
            this.btnRemove.TabIndex = 30;
            this.btnRemove.Text = "Remove Items F9";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Visible = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.Green;
            this.lblItem.Location = new System.Drawing.Point(32, 485);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(187, 13);
            this.lblItem.TabIndex = 22;
            this.lblItem.Text = " Enter ? + {Enter} to View Items";
            this.lblItem.Visible = false;
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.Location = new System.Drawing.Point(27, 111);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(54, 13);
            this.lblBillNo.TabIndex = 11;
            this.lblBillNo.Text = "BILL NO :";
            // 
            // lblBillNoDisplay
            // 
            this.lblBillNoDisplay.AutoSize = true;
            this.lblBillNoDisplay.Location = new System.Drawing.Point(103, 111);
            this.lblBillNoDisplay.Name = "lblBillNoDisplay";
            this.lblBillNoDisplay.Size = new System.Drawing.Size(0, 13);
            this.lblBillNoDisplay.TabIndex = 12;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(265, 111);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 13);
            this.lblDate.TabIndex = 99;
            this.lblDate.Text = "BILL DATE :";
            // 
            // dtBillDate
            // 
            this.dtBillDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtBillDate.Enabled = false;
            this.dtBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBillDate.Location = new System.Drawing.Point(338, 109);
            this.dtBillDate.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dtBillDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtBillDate.Name = "dtBillDate";
            this.dtBillDate.Size = new System.Drawing.Size(137, 20);
            this.dtBillDate.TabIndex = 0;
            this.dtBillDate.Value = new System.DateTime(2011, 9, 12, 0, 0, 0, 0);
            // 
            // txtCounterName
            // 
            this.txtCounterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCounterName.Location = new System.Drawing.Point(691, 133);
            this.txtCounterName.Name = "txtCounterName";
            this.txtCounterName.Size = new System.Drawing.Size(132, 23);
            this.txtCounterName.TabIndex = 0;
            this.txtCounterName.TabStop = true;
            // 
            // lblSteward
            // 
            this.lblSteward.AutoSize = true;
            this.lblSteward.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteward.Location = new System.Drawing.Point(27, 138);
            this.lblSteward.Name = "lblSteward";
            this.lblSteward.Size = new System.Drawing.Size(76, 13);
            this.lblSteward.TabIndex = 2;
            this.lblSteward.Text = "STEWARD ID";
            // 
            // txtStewCode
            // 
            this.txtStewCode.Location = new System.Drawing.Point(104, 133);
            this.txtStewCode.Name = "txtStewCode";
            this.txtStewCode.Size = new System.Drawing.Size(146, 20);
            this.txtStewCode.TabIndex = 7;
            this.txtStewCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStewCode_KeyDown);
            this.txtStewCode.Leave += new System.EventHandler(this.txtStewCode_Leave);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 80;
            // 
            // OTNo
            // 
            this.OTNo.HeaderText = "OT No.";
            this.OTNo.Name = "OTNo";
            this.OTNo.ReadOnly = true;
            this.OTNo.Width = 80;
            // 
            // itemcode
            // 
            this.itemcode.HeaderText = "Item Code";
            this.itemcode.Name = "itemcode";
            // 
            // itemname
            // 
            this.itemname.HeaderText = "Item Name";
            this.itemname.Name = "itemname";
            this.itemname.ReadOnly = true;
            this.itemname.Width = 280;
            // 
            // unit
            // 
            this.unit.HeaderText = "Unit";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Visible = false;
            // 
            // rate
            // 
            this.rate.HeaderText = "Rate";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            this.rate.Width = 80;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "Integer";
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.Width = 80;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // itemid
            // 
            this.itemid.HeaderText = "ItemID";
            this.itemid.Name = "itemid";
            this.itemid.Visible = false;
            // 
            // hrate
            // 
            this.hrate.HeaderText = "hrate";
            this.hrate.Name = "hrate";
            this.hrate.Visible = false;
            // 
            // bunitid
            // 
            this.bunitid.HeaderText = "bunitid";
            this.bunitid.Name = "bunitid";
            this.bunitid.Visible = false;
            // 
            // aqty
            // 
            this.aqty.HeaderText = "aqty";
            this.aqty.Name = "aqty";
            this.aqty.Visible = false;
            // 
            // oqty
            // 
            this.oqty.HeaderText = "oqty";
            this.oqty.Name = "oqty";
            this.oqty.Visible = false;
            // 
            // ItmDetailId
            // 
            this.ItmDetailId.HeaderText = "ItmDetailId";
            this.ItmDetailId.Name = "ItmDetailId";
            this.ItmDetailId.Visible = false;
            // 
            // StoreID
            // 
            this.StoreID.HeaderText = "StoreID";
            this.StoreID.Name = "StoreID";
            this.StoreID.ReadOnly = true;
            this.StoreID.Width = 80;
            // 
            // SalesTax
            // 
            this.SalesTax.HeaderText = "SalesTax";
            this.SalesTax.Name = "SalesTax";
            this.SalesTax.Visible = false;
            // 
            // CessTax
            // 
            this.CessTax.HeaderText = "CessTax";
            this.CessTax.Name = "CessTax";
            this.CessTax.Visible = false;
            // 
            // ServTax
            // 
            this.ServTax.HeaderText = "ServTax";
            this.ServTax.Name = "ServTax";
            this.ServTax.Visible = false;
            // 
            // ServCharge
            // 
            this.ServCharge.HeaderText = "ServCharge";
            this.ServCharge.Name = "ServCharge";
            this.ServCharge.Visible = false;
            // 
            // EnServCharge
            // 
            this.EnServCharge.HeaderText = "EnServCharge";
            this.EnServCharge.Name = "EnServCharge";
            this.EnServCharge.Visible = false;
            // 
            // SalesAccount
            // 
            this.SalesAccount.HeaderText = "SalesAccount";
            this.SalesAccount.Name = "SalesAccount";
            this.SalesAccount.Visible = false;
            // 
            // mainmenu
            // 
            this.mainmenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tblReadcard,
            this.tblClear,
            this.tblPost,
            this.tblViewm,
            this.tblFinalize,
            this.tblRePrint,
            this.tblBillTo,
            this.tblModify,
            this.tblBillCancel,
            this.tblPending,
            this.tblExit});
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(922, 24);
            this.mainmenu.TabIndex = 25;
            this.mainmenu.Text = "menuStrip1";
            this.mainmenu.Visible = false;
            // 
            // tblReadcard
            // 
            this.tblReadcard.Name = "tblReadcard";
            this.tblReadcard.Size = new System.Drawing.Size(111, 20);
            this.tblReadcard.Text = "&Read Card(F6)      ";
            this.tblReadcard.Click += new System.EventHandler(this.tblReadcard_Click);
            // 
            // tblClear
            // 
            this.tblClear.Name = "tblClear";
            this.tblClear.Size = new System.Drawing.Size(106, 20);
            this.tblClear.Text = "&New Bill(F8)        ";
            this.tblClear.Click += new System.EventHandler(this.tblClear_Click);
            // 
            // tblPost
            // 
            this.tblPost.Name = "tblPost";
            this.tblPost.Size = new System.Drawing.Size(84, 20);
            this.tblPost.Text = "&Save(F3)       ";
            this.tblPost.Click += new System.EventHandler(this.tblPost_Click);
            // 
            // tblViewm
            // 
            this.tblViewm.Name = "tblViewm";
            this.tblViewm.Size = new System.Drawing.Size(102, 20);
            this.tblViewm.Text = " &Finalize(F5)       ";
            this.tblViewm.Click += new System.EventHandler(this.tblViewm_Click);
            // 
            // tblFinalize
            // 
            this.tblFinalize.Name = "tblFinalize";
            this.tblFinalize.Size = new System.Drawing.Size(65, 20);
            this.tblFinalize.Text = "&Post (F7)";
            this.tblFinalize.Click += new System.EventHandler(this.tblFinalize_Click);
            // 
            // tblRePrint
            // 
            this.tblRePrint.Name = "tblRePrint";
            this.tblRePrint.Size = new System.Drawing.Size(77, 20);
            this.tblRePrint.Text = "R&ePrint(F4)";
            this.tblRePrint.Visible = false;
            // 
            // tblBillTo
            // 
            this.tblBillTo.Enabled = false;
            this.tblBillTo.Name = "tblBillTo";
            this.tblBillTo.Size = new System.Drawing.Size(126, 20);
            this.tblBillTo.Text = "Bill To Account(F11)";
            this.tblBillTo.Click += new System.EventHandler(this.tblBillTo_Click);
            // 
            // tblModify
            // 
            this.tblModify.Name = "tblModify";
            this.tblModify.Size = new System.Drawing.Size(89, 20);
            this.tblModify.Text = "View Bill(&F12)";
            this.tblModify.Click += new System.EventHandler(this.tblModify_Click);
            // 
            // tblBillCancel
            // 
            this.tblBillCancel.Name = "tblBillCancel";
            this.tblBillCancel.Size = new System.Drawing.Size(97, 20);
            this.tblBillCancel.Text = "Cancel Bill (F9)";
            // 
            // tblPending
            // 
            this.tblPending.Name = "tblPending";
            this.tblPending.Size = new System.Drawing.Size(146, 20);
            this.tblPending.Text = "View Pending(Alt + F12)";
            this.tblPending.Click += new System.EventHandler(this.tblPending_Click);
            // 
            // tblExit
            // 
            this.tblExit.Name = "tblExit";
            this.tblExit.Size = new System.Drawing.Size(37, 20);
            this.tblExit.Text = "&Exit";
            this.tblExit.Click += new System.EventHandler(this.tblExit_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "OT No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Item Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 280;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Integer";
            this.dataGridViewTextBoxColumn6.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "ItemID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "hrate";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "bunitid";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "aqty";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "oqty";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "ItmDetailId";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "SalesTax";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "CessTax";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "ServTax";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "ServCharge";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "EnServCharge";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Visible = false;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "SalesAccount";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Visible = false;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "OT No.";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 80;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "Item Code";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 280;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Visible = false;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 80;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Integer";
            this.dataGridViewTextBoxColumn25.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.Width = 80;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.HeaderText = "ItemID";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Visible = false;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.HeaderText = "hrate";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Visible = false;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.HeaderText = "bunitid";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Visible = false;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.HeaderText = "aqty";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.Visible = false;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "oqty";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.Visible = false;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.HeaderText = "ItmDetailId";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.Visible = false;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.HeaderText = "SalesTax";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.Visible = false;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.HeaderText = "CessTax";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.Visible = false;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.HeaderText = "ServTax";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.Visible = false;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.HeaderText = "ServCharge";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.Visible = false;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.HeaderText = "EnServCharge";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.Visible = false;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.HeaderText = "SalesAccount";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.Visible = false;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.HeaderText = "OT No.";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Width = 80;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.HeaderText = "Item Code";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            this.dataGridViewTextBoxColumn41.Width = 280;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Visible = false;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            this.dataGridViewTextBoxColumn43.Width = 80;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "Integer";
            this.dataGridViewTextBoxColumn44.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.Width = 80;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.HeaderText = "ItemID";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.Visible = false;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.HeaderText = "hrate";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.Visible = false;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.HeaderText = "bunitid";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.Visible = false;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.HeaderText = "aqty";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.Visible = false;
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.HeaderText = "oqty";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.Visible = false;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.HeaderText = "ItmDetailId";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.Visible = false;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.HeaderText = "SalesTax";
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.Visible = false;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.HeaderText = "CessTax";
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.Visible = false;
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.HeaderText = "ServTax";
            this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            this.dataGridViewTextBoxColumn54.Visible = false;
            // 
            // dataGridViewTextBoxColumn55
            // 
            this.dataGridViewTextBoxColumn55.HeaderText = "ServCharge";
            this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            this.dataGridViewTextBoxColumn55.Visible = false;
            // 
            // dataGridViewTextBoxColumn56
            // 
            this.dataGridViewTextBoxColumn56.HeaderText = "EnServCharge";
            this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
            this.dataGridViewTextBoxColumn56.Visible = false;
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.HeaderText = "SalesAccount";
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            this.dataGridViewTextBoxColumn57.Visible = false;
            // 
            // dataGridViewTextBoxColumn58
            // 
            this.dataGridViewTextBoxColumn58.HeaderText = "OT No.";
            this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
            this.dataGridViewTextBoxColumn58.ReadOnly = true;
            this.dataGridViewTextBoxColumn58.Width = 80;
            // 
            // dataGridViewTextBoxColumn59
            // 
            this.dataGridViewTextBoxColumn59.HeaderText = "Item Code";
            this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
            this.dataGridViewTextBoxColumn60.ReadOnly = true;
            this.dataGridViewTextBoxColumn60.Width = 280;
            // 
            // dataGridViewTextBoxColumn61
            // 
            this.dataGridViewTextBoxColumn61.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
            this.dataGridViewTextBoxColumn61.ReadOnly = true;
            this.dataGridViewTextBoxColumn61.Visible = false;
            // 
            // dataGridViewTextBoxColumn62
            // 
            this.dataGridViewTextBoxColumn62.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
            this.dataGridViewTextBoxColumn62.ReadOnly = true;
            this.dataGridViewTextBoxColumn62.Width = 80;
            // 
            // dataGridViewTextBoxColumn63
            // 
            this.dataGridViewTextBoxColumn63.DataPropertyName = "Integer";
            this.dataGridViewTextBoxColumn63.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
            this.dataGridViewTextBoxColumn63.Width = 80;
            // 
            // dataGridViewTextBoxColumn64
            // 
            this.dataGridViewTextBoxColumn64.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
            this.dataGridViewTextBoxColumn64.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn65
            // 
            this.dataGridViewTextBoxColumn65.HeaderText = "ItemID";
            this.dataGridViewTextBoxColumn65.Name = "dataGridViewTextBoxColumn65";
            this.dataGridViewTextBoxColumn65.Visible = false;
            // 
            // dataGridViewTextBoxColumn66
            // 
            this.dataGridViewTextBoxColumn66.HeaderText = "hrate";
            this.dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
            this.dataGridViewTextBoxColumn66.Visible = false;
            // 
            // dataGridViewTextBoxColumn67
            // 
            this.dataGridViewTextBoxColumn67.HeaderText = "bunitid";
            this.dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
            this.dataGridViewTextBoxColumn67.Visible = false;
            // 
            // dataGridViewTextBoxColumn68
            // 
            this.dataGridViewTextBoxColumn68.HeaderText = "aqty";
            this.dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
            this.dataGridViewTextBoxColumn68.Visible = false;
            // 
            // dataGridViewTextBoxColumn69
            // 
            this.dataGridViewTextBoxColumn69.HeaderText = "oqty";
            this.dataGridViewTextBoxColumn69.Name = "dataGridViewTextBoxColumn69";
            this.dataGridViewTextBoxColumn69.Visible = false;
            // 
            // dataGridViewTextBoxColumn70
            // 
            this.dataGridViewTextBoxColumn70.HeaderText = "ItmDetailId";
            this.dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
            this.dataGridViewTextBoxColumn70.Visible = false;
            // 
            // dataGridViewTextBoxColumn71
            // 
            this.dataGridViewTextBoxColumn71.HeaderText = "SalesTax";
            this.dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
            this.dataGridViewTextBoxColumn71.Visible = false;
            // 
            // dataGridViewTextBoxColumn72
            // 
            this.dataGridViewTextBoxColumn72.HeaderText = "CessTax";
            this.dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
            this.dataGridViewTextBoxColumn72.Visible = false;
            // 
            // dataGridViewTextBoxColumn73
            // 
            this.dataGridViewTextBoxColumn73.HeaderText = "ServTax";
            this.dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
            this.dataGridViewTextBoxColumn73.Visible = false;
            // 
            // dataGridViewTextBoxColumn74
            // 
            this.dataGridViewTextBoxColumn74.HeaderText = "ServCharge";
            this.dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
            this.dataGridViewTextBoxColumn74.Visible = false;
            // 
            // dataGridViewTextBoxColumn75
            // 
            this.dataGridViewTextBoxColumn75.HeaderText = "EnServCharge";
            this.dataGridViewTextBoxColumn75.Name = "dataGridViewTextBoxColumn75";
            this.dataGridViewTextBoxColumn75.Visible = false;
            // 
            // dataGridViewTextBoxColumn76
            // 
            this.dataGridViewTextBoxColumn76.HeaderText = "SalesAccount";
            this.dataGridViewTextBoxColumn76.Name = "dataGridViewTextBoxColumn76";
            this.dataGridViewTextBoxColumn76.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pnlMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(8, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 635);
            this.panel2.TabIndex = 26;
            // 
            // grdBilling
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBilling.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBilling.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlNo,
            this.dataGridViewTextBoxColumn77,
            this.dataGridViewTextBoxColumn78,
            this.dataGridViewTextBoxColumn79,
            this.dataGridViewTextBoxColumn80,
            this.dataGridViewTextBoxColumn82,
            this.dataGridViewTextBoxColumn81,
            this.dataGridViewTextBoxColumn83,
            this.dataGridViewTextBoxColumn84,
            this.dataGridViewTextBoxColumn85,
            this.dataGridViewTextBoxColumn86,
            this.dataGridViewTextBoxColumn87,
            this.dataGridViewTextBoxColumn88,
            this.dataGridViewTextBoxColumn89,
            this.dataGridViewTextBoxColumn95,
            this.dataGridViewTextBoxColumn96,
            this.dataGridViewTextBoxColumn97,
            this.TotalTax});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdBilling.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdBilling.Location = new System.Drawing.Point(21, 195);
            this.grdBilling.Name = "grdBilling";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBilling.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdBilling.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdBilling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBilling.Size = new System.Drawing.Size(810, 275);
            this.grdBilling.TabIndex = 8;
            this.grdBilling.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdBilling_UserDeletingRow);
            this.grdBilling.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdBilling_CellBeginEdit);
            this.grdBilling.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdBilling_UserDeletedRow);
            this.grdBilling.keyPressHook += new System.Windows.Forms.KeyPressEventHandler(this.grdBilling_keyPressHook);
            this.grdBilling.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdBilling_CellValidating);
            this.grdBilling.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBilling_CellEndEdit);
            this.grdBilling.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdBilling_EditingControlShowing);
            this.grdBilling.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBilling_CellEnter);
            this.grdBilling.keyDownHook += new System.Windows.Forms.KeyEventHandler(this.grdBilling_keyDownHook);
            // 
            // SlNo
            // 
            this.SlNo.HeaderText = "SNo.";
            this.SlNo.Name = "SlNo";
            this.SlNo.ReadOnly = true;
            this.SlNo.Width = 40;
            // 
            // dataGridViewTextBoxColumn77
            // 
            this.dataGridViewTextBoxColumn77.HeaderText = "OT No.";
            this.dataGridViewTextBoxColumn77.Name = "dataGridViewTextBoxColumn77";
            this.dataGridViewTextBoxColumn77.ReadOnly = true;
            this.dataGridViewTextBoxColumn77.Visible = false;
            this.dataGridViewTextBoxColumn77.Width = 120;
            // 
            // dataGridViewTextBoxColumn78
            // 
            this.dataGridViewTextBoxColumn78.HeaderText = "Item Code";
            this.dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
            // 
            // dataGridViewTextBoxColumn79
            // 
            this.dataGridViewTextBoxColumn79.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn79.Name = "dataGridViewTextBoxColumn79";
            this.dataGridViewTextBoxColumn79.Width = 270;
            // 
            // dataGridViewTextBoxColumn80
            // 
            this.dataGridViewTextBoxColumn80.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
            this.dataGridViewTextBoxColumn80.ReadOnly = true;
            this.dataGridViewTextBoxColumn80.Width = 80;
            // 
            // dataGridViewTextBoxColumn82
            // 
            this.dataGridViewTextBoxColumn82.DataPropertyName = "Integer";
            this.dataGridViewTextBoxColumn82.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn82.Name = "dataGridViewTextBoxColumn82";
            this.dataGridViewTextBoxColumn82.Width = 60;
            // 
            // dataGridViewTextBoxColumn81
            // 
            this.dataGridViewTextBoxColumn81.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn81.Name = "dataGridViewTextBoxColumn81";
            this.dataGridViewTextBoxColumn81.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn83
            // 
            this.dataGridViewTextBoxColumn83.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn83.Name = "dataGridViewTextBoxColumn83";
            this.dataGridViewTextBoxColumn83.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn84
            // 
            this.dataGridViewTextBoxColumn84.HeaderText = "ItemID";
            this.dataGridViewTextBoxColumn84.Name = "dataGridViewTextBoxColumn84";
            this.dataGridViewTextBoxColumn84.Visible = false;
            // 
            // dataGridViewTextBoxColumn85
            // 
            this.dataGridViewTextBoxColumn85.HeaderText = "hrate";
            this.dataGridViewTextBoxColumn85.Name = "dataGridViewTextBoxColumn85";
            this.dataGridViewTextBoxColumn85.Visible = false;
            // 
            // dataGridViewTextBoxColumn86
            // 
            this.dataGridViewTextBoxColumn86.HeaderText = "bunitid";
            this.dataGridViewTextBoxColumn86.Name = "dataGridViewTextBoxColumn86";
            this.dataGridViewTextBoxColumn86.Visible = false;
            // 
            // dataGridViewTextBoxColumn87
            // 
            this.dataGridViewTextBoxColumn87.HeaderText = "aqty";
            this.dataGridViewTextBoxColumn87.Name = "dataGridViewTextBoxColumn87";
            this.dataGridViewTextBoxColumn87.Visible = false;
            // 
            // dataGridViewTextBoxColumn88
            // 
            this.dataGridViewTextBoxColumn88.HeaderText = "oqty";
            this.dataGridViewTextBoxColumn88.Name = "dataGridViewTextBoxColumn88";
            this.dataGridViewTextBoxColumn88.Visible = false;
            // 
            // dataGridViewTextBoxColumn89
            // 
            this.dataGridViewTextBoxColumn89.HeaderText = "ItmDetailId";
            this.dataGridViewTextBoxColumn89.Name = "dataGridViewTextBoxColumn89";
            this.dataGridViewTextBoxColumn89.Visible = false;
            // 
            // dataGridViewTextBoxColumn95
            // 
            this.dataGridViewTextBoxColumn95.HeaderText = "SalesAccount";
            this.dataGridViewTextBoxColumn95.Name = "dataGridViewTextBoxColumn95";
            this.dataGridViewTextBoxColumn95.Visible = false;
            // 
            // dataGridViewTextBoxColumn96
            // 
            this.dataGridViewTextBoxColumn96.HeaderText = "ID";
            this.dataGridViewTextBoxColumn96.Name = "dataGridViewTextBoxColumn96";
            this.dataGridViewTextBoxColumn96.ReadOnly = true;
            this.dataGridViewTextBoxColumn96.Visible = false;
            this.dataGridViewTextBoxColumn96.Width = 80;
            // 
            // dataGridViewTextBoxColumn97
            // 
            this.dataGridViewTextBoxColumn97.HeaderText = "StoreID";
            this.dataGridViewTextBoxColumn97.Name = "dataGridViewTextBoxColumn97";
            this.dataGridViewTextBoxColumn97.ReadOnly = true;
            this.dataGridViewTextBoxColumn97.Visible = false;
            this.dataGridViewTextBoxColumn97.Width = 80;
            // 
            // TotalTax
            // 
            this.TotalTax.HeaderText = "TotalTax";
            this.TotalTax.Name = "TotalTax";
            this.TotalTax.ReadOnly = true;
            this.TotalTax.Visible = false;
            // 
            // ICMSBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1009, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.mainmenu);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ICMSBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ICMSBill";
            this.Load += new System.EventHandler(this.ICMSBill_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ICMSBill_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ICMSBill_KeyDown);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMemberDetails.ResumeLayout(false);
            this.pnlMemberDetails.PerformLayout();
            this.grpDep.ResumeLayout(false);
            this.grpDep.PerformLayout();
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBilling)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.Label lblBillNoDisplay;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAccNo;
        private System.Windows.Forms.DateTimePicker dtBillDate;
        internal System.Windows.Forms.TextBox txtAccNo;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Labe20;
        private System.Windows.Forms.Label lblSteward;
        internal System.Windows.Forms.TextBox txtStewCode;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ID;
        internal System.Windows.Forms.DataGridViewTextBoxColumn OTNo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        internal System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        internal System.Windows.Forms.DataGridViewTextBoxColumn unit;
        internal System.Windows.Forms.DataGridViewTextBoxColumn rate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        internal System.Windows.Forms.DataGridViewTextBoxColumn amount;
        internal System.Windows.Forms.DataGridViewTextBoxColumn itemid;
        internal System.Windows.Forms.DataGridViewTextBoxColumn hrate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn bunitid;
        internal System.Windows.Forms.DataGridViewTextBoxColumn aqty;
        internal System.Windows.Forms.DataGridViewTextBoxColumn oqty;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ItmDetailId;
        internal System.Windows.Forms.DataGridViewTextBoxColumn StoreID;
        internal System.Windows.Forms.DataGridViewTextBoxColumn SalesTax;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CessTax;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ServTax;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ServCharge;
        internal System.Windows.Forms.DataGridViewTextBoxColumn EnServCharge;
        internal System.Windows.Forms.DataGridViewTextBoxColumn SalesAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem tblReadcard;
        private System.Windows.Forms.ToolStripMenuItem tblClear;
        private System.Windows.Forms.ToolStripMenuItem tblPost;
        private System.Windows.Forms.ToolStripMenuItem tblViewm;
        internal System.Windows.Forms.ToolStripMenuItem tblFinalize;
        internal System.Windows.Forms.ToolStripMenuItem tblRePrint;
        internal System.Windows.Forms.ToolStripMenuItem tblBillCancel;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;
        internal DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;
        
        internal BillingManager.KeyPressAwareDataGridView grdBilling;
        private ToolStripMenuItem tblBillTo;
        private Button btnRemove;
        private ToolStripMenuItem tblExit;
        private Label lblBAmt;
        private ToolStripMenuItem tblModify;
        private ToolStripMenuItem tblPending;
        private TextBox txtBillNo;
        private TextBox txtBillAmount;
        private Label label8;
        private TextBox txtNetAmount;
        private Label label7;
        private TextBox txtTax;
        private Label label6;
        private Label label5;
        private Label lblAvialableQty;
        private GroupBox grpDep;
        private Label label15;
        private Button btnModify;
        private Button btnExit;

        private Button btnKOTCancelSave;
        private Button btnKOTSave;
        private Button btnSave;
        private Button btnNew;
        private Button btnReadCard;
        private Button btnPending;
        private Button btnMemSearch;
        private Label txtBearerName;
        private TextBox txtRelation;
        private TextBox txtDependantName;
        private Label label12;
        private Button btnFinalize;
        private CheckBox chkHappyHour;
        private Label txtBalance;
     
        private Label txtMemberName;
        private Label txtCounterName;
        private Button btnReport;
        internal Label lblBillTo;
        internal ComboBox cmbBillTo;
        private TextBox txtVat;
        private Label lblvat;
        internal ComboBox cmbTable;
        private Label lblTable;
        private ComboBox cmbBillMode;
        private Label lblBillMode;
        private Panel pnlMemberDetails;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private DataGridViewTextBoxColumn SlNo;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn83;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn84;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn88;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn89;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn95;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn96;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn97;
        private DataGridViewTextBoxColumn TotalTax;
    }
}