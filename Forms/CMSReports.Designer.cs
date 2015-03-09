namespace BillingManager.Forms
{
    partial class CMSReports
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.datFrom = new System.Windows.Forms.DateTimePicker();
            this.datTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPOS = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenarate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpItemSale = new System.Windows.Forms.GroupBox();
            this.grpSalesSumm = new System.Windows.Forms.GroupBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRType = new System.Windows.Forms.ComboBox();
            this.datSFrom = new System.Windows.Forms.DateTimePicker();
            this.datSTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grpItemwise = new System.Windows.Forms.GroupBox();
            this.datWTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rdoItemSales = new System.Windows.Forms.RadioButton();
            this.rdoItemwise = new System.Windows.Forms.RadioButton();
            this.rdoSalesSumm = new System.Windows.Forms.RadioButton();
            this.grpItemStock = new System.Windows.Forms.GroupBox();
            this.cmbSGodown = new System.Windows.Forms.ComboBox();
            this.cmbSGrp = new System.Windows.Forms.ComboBox();
            this.rdoVal = new System.Windows.Forms.RadioButton();
            this.rdoWVal = new System.Windows.Forms.RadioButton();
            this.cmbSOpt = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbSStore = new System.Windows.Forms.ComboBox();
            this.cmbFor = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbSType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.datSTTo = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbSItem = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblItm = new System.Windows.Forms.Label();
            this.rdoStock = new System.Windows.Forms.RadioButton();
            this.datWFrom = new System.Windows.Forms.DateTimePicker();
            this.datSTFrom = new System.Windows.Forms.DateTimePicker();
            this.grpItemSale.SuspendLayout();
            this.grpSalesSumm.SuspendLayout();
            this.grpItemwise.SuspendLayout();
            this.grpItemStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member ID";
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(113, 23);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(84, 20);
            this.txtMemberID.TabIndex = 1;
            // 
            // datFrom
            // 
            this.datFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datFrom.Location = new System.Drawing.Point(113, 80);
            this.datFrom.Name = "datFrom";
            this.datFrom.Size = new System.Drawing.Size(120, 20);
            this.datFrom.TabIndex = 3;
            // 
            // datTo
            // 
            this.datTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datTo.Location = new System.Drawing.Point(111, 124);
            this.datTo.Name = "datTo";
            this.datTo.Size = new System.Drawing.Size(120, 20);
            this.datTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "To Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "POS";
            // 
            // cmbPOS
            // 
            this.cmbPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOS.FormattingEnabled = true;
            this.cmbPOS.Items.AddRange(new object[] {
            "BAR",
            "CAN",
            "ALL"});
            this.cmbPOS.Location = new System.Drawing.Point(112, 52);
            this.cmbPOS.Name = "cmbPOS";
            this.cmbPOS.Size = new System.Drawing.Size(121, 21);
            this.cmbPOS.TabIndex = 2;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Details",
            "Summary"});
            this.cmbType.Location = new System.Drawing.Point(112, 155);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Type";
            // 
            // btnGenarate
            // 
            this.btnGenarate.Location = new System.Drawing.Point(478, 106);
            this.btnGenarate.Name = "btnGenarate";
            this.btnGenarate.Size = new System.Drawing.Size(120, 23);
            this.btnGenarate.TabIndex = 6;
            this.btnGenarate.Text = "Genearate";
            this.btnGenarate.UseVisualStyleBackColor = true;
            this.btnGenarate.Click += new System.EventHandler(this.btnGenarate_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(478, 142);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(478, 180);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpItemSale
            // 
            this.grpItemSale.Controls.Add(this.cmbType);
            this.grpItemSale.Controls.Add(this.label1);
            this.grpItemSale.Controls.Add(this.txtMemberID);
            this.grpItemSale.Controls.Add(this.datFrom);
            this.grpItemSale.Controls.Add(this.datTo);
            this.grpItemSale.Controls.Add(this.label5);
            this.grpItemSale.Controls.Add(this.label2);
            this.grpItemSale.Controls.Add(this.cmbPOS);
            this.grpItemSale.Controls.Add(this.label3);
            this.grpItemSale.Controls.Add(this.label4);
            this.grpItemSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpItemSale.Location = new System.Drawing.Point(51, 55);
            this.grpItemSale.Name = "grpItemSale";
            this.grpItemSale.Size = new System.Drawing.Size(385, 194);
            this.grpItemSale.TabIndex = 9;
            this.grpItemSale.TabStop = false;
            this.grpItemSale.Text = "Item Sales Report";
            // 
            // grpSalesSumm
            // 
            this.grpSalesSumm.Controls.Add(this.cmbCategory);
            this.grpSalesSumm.Controls.Add(this.label15);
            this.grpSalesSumm.Controls.Add(this.cmbLocation);
            this.grpSalesSumm.Controls.Add(this.label14);
            this.grpSalesSumm.Controls.Add(this.cmbOrder);
            this.grpSalesSumm.Controls.Add(this.label6);
            this.grpSalesSumm.Controls.Add(this.cmbRType);
            this.grpSalesSumm.Controls.Add(this.datSFrom);
            this.grpSalesSumm.Controls.Add(this.datSTo);
            this.grpSalesSumm.Controls.Add(this.label7);
            this.grpSalesSumm.Controls.Add(this.label11);
            this.grpSalesSumm.Controls.Add(this.cmbFrom);
            this.grpSalesSumm.Controls.Add(this.label12);
            this.grpSalesSumm.Controls.Add(this.label13);
            this.grpSalesSumm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSalesSumm.Location = new System.Drawing.Point(49, 55);
            this.grpSalesSumm.Name = "grpSalesSumm";
            this.grpSalesSumm.Size = new System.Drawing.Size(385, 240);
            this.grpSalesSumm.TabIndex = 11;
            this.grpSalesSumm.TabStop = false;
            this.grpSalesSumm.Text = "Sales Summary Report";
            this.grpSalesSumm.Visible = false;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(112, 111);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Category";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(112, 81);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(121, 21);
            this.cmbLocation.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Location";
            // 
            // cmbOrder
            // 
            this.cmbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrder.FormattingEnabled = true;
            this.cmbOrder.Items.AddRange(new object[] {
            "NONE",
            "LOCATION"});
            this.cmbOrder.Location = new System.Drawing.Point(112, 53);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(121, 21);
            this.cmbOrder.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Order By";
            // 
            // cmbRType
            // 
            this.cmbRType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRType.FormattingEnabled = true;
            this.cmbRType.Items.AddRange(new object[] {
            "Details",
            "Summary"});
            this.cmbRType.Location = new System.Drawing.Point(112, 211);
            this.cmbRType.Name = "cmbRType";
            this.cmbRType.Size = new System.Drawing.Size(121, 21);
            this.cmbRType.TabIndex = 5;
            // 
            // datSFrom
            // 
            this.datSFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datSFrom.Location = new System.Drawing.Point(113, 142);
            this.datSFrom.Name = "datSFrom";
            this.datSFrom.Size = new System.Drawing.Size(120, 20);
            this.datSFrom.TabIndex = 3;
            // 
            // datSTo
            // 
            this.datSTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datSTo.Location = new System.Drawing.Point(111, 180);
            this.datSTo.Name = "datSTo";
            this.datSTo.Size = new System.Drawing.Size(120, 20);
            this.datSTo.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "From Date";
            // 
            // cmbFrom
            // 
            this.cmbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Items.AddRange(new object[] {
            "BAR",
            "CAN"});
            this.cmbFrom.Location = new System.Drawing.Point(112, 21);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(121, 21);
            this.cmbFrom.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "To Date";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "From";
            // 
            // grpItemwise
            // 
            this.grpItemwise.Controls.Add(this.datWFrom);
            this.grpItemwise.Controls.Add(this.datWTo);
            this.grpItemwise.Controls.Add(this.label8);
            this.grpItemwise.Controls.Add(this.cmbItem);
            this.grpItemwise.Controls.Add(this.label9);
            this.grpItemwise.Controls.Add(this.label10);
            this.grpItemwise.Location = new System.Drawing.Point(48, 52);
            this.grpItemwise.Name = "grpItemwise";
            this.grpItemwise.Size = new System.Drawing.Size(424, 171);
            this.grpItemwise.TabIndex = 10;
            this.grpItemwise.TabStop = false;
            this.grpItemwise.Text = "Item wise Sales Report";
            this.grpItemwise.Visible = false;
            // 
            // datWTo
            // 
            this.datWTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datWTo.Location = new System.Drawing.Point(89, 120);
            this.datWTo.Name = "datWTo";
            this.datWTo.Size = new System.Drawing.Size(120, 20);
            this.datWTo.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "From Date";
            // 
            // cmbItem
            // 
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(89, 54);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(325, 21);
            this.cmbItem.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "To Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Item";
            // 
            // rdoItemSales
            // 
            this.rdoItemSales.AutoSize = true;
            this.rdoItemSales.Checked = true;
            this.rdoItemSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoItemSales.Location = new System.Drawing.Point(26, 8);
            this.rdoItemSales.Name = "rdoItemSales";
            this.rdoItemSales.Size = new System.Drawing.Size(123, 19);
            this.rdoItemSales.TabIndex = 11;
            this.rdoItemSales.TabStop = true;
            this.rdoItemSales.Text = "Item Sales Report";
            this.rdoItemSales.UseVisualStyleBackColor = true;
            this.rdoItemSales.CheckedChanged += new System.EventHandler(this.rdoItemSales_CheckedChanged);
            // 
            // rdoItemwise
            // 
            this.rdoItemwise.AutoSize = true;
            this.rdoItemwise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoItemwise.Location = new System.Drawing.Point(153, 8);
            this.rdoItemwise.Name = "rdoItemwise";
            this.rdoItemwise.Size = new System.Drawing.Size(151, 19);
            this.rdoItemwise.TabIndex = 12;
            this.rdoItemwise.Text = "Item wise Sales Report";
            this.rdoItemwise.UseVisualStyleBackColor = true;
            this.rdoItemwise.CheckedChanged += new System.EventHandler(this.rdoItemwise_CheckedChanged);
            // 
            // rdoSalesSumm
            // 
            this.rdoSalesSumm.AutoSize = true;
            this.rdoSalesSumm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSalesSumm.Location = new System.Drawing.Point(309, 8);
            this.rdoSalesSumm.Name = "rdoSalesSumm";
            this.rdoSalesSumm.Size = new System.Drawing.Size(152, 19);
            this.rdoSalesSumm.TabIndex = 13;
            this.rdoSalesSumm.Text = "Sales Summary Report";
            this.rdoSalesSumm.UseVisualStyleBackColor = true;
            this.rdoSalesSumm.CheckedChanged += new System.EventHandler(this.rdoSalesSumm_CheckedChanged);
            // 
            // grpItemStock
            // 
            this.grpItemStock.Controls.Add(this.datSTFrom);
            this.grpItemStock.Controls.Add(this.cmbSGodown);
            this.grpItemStock.Controls.Add(this.cmbSGrp);
            this.grpItemStock.Controls.Add(this.rdoVal);
            this.grpItemStock.Controls.Add(this.rdoWVal);
            this.grpItemStock.Controls.Add(this.cmbSOpt);
            this.grpItemStock.Controls.Add(this.label21);
            this.grpItemStock.Controls.Add(this.cmbSStore);
            this.grpItemStock.Controls.Add(this.cmbFor);
            this.grpItemStock.Controls.Add(this.label20);
            this.grpItemStock.Controls.Add(this.cmbSType);
            this.grpItemStock.Controls.Add(this.label19);
            this.grpItemStock.Controls.Add(this.datSTTo);
            this.grpItemStock.Controls.Add(this.label16);
            this.grpItemStock.Controls.Add(this.cmbSItem);
            this.grpItemStock.Controls.Add(this.label17);
            this.grpItemStock.Controls.Add(this.lblItm);
            this.grpItemStock.Location = new System.Drawing.Point(43, 55);
            this.grpItemStock.Name = "grpItemStock";
            this.grpItemStock.Size = new System.Drawing.Size(424, 227);
            this.grpItemStock.TabIndex = 14;
            this.grpItemStock.TabStop = false;
            this.grpItemStock.Text = "Stock Summary Report";
            this.grpItemStock.Visible = false;
            // 
            // cmbSGodown
            // 
            this.cmbSGodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSGodown.FormattingEnabled = true;
            this.cmbSGodown.Location = new System.Drawing.Point(194, 90);
            this.cmbSGodown.Name = "cmbSGodown";
            this.cmbSGodown.Size = new System.Drawing.Size(210, 21);
            this.cmbSGodown.TabIndex = 19;
            this.cmbSGodown.Visible = false;
            // 
            // cmbSGrp
            // 
            this.cmbSGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSGrp.FormattingEnabled = true;
            this.cmbSGrp.Location = new System.Drawing.Point(89, 146);
            this.cmbSGrp.Name = "cmbSGrp";
            this.cmbSGrp.Size = new System.Drawing.Size(325, 21);
            this.cmbSGrp.TabIndex = 18;
            this.cmbSGrp.Visible = false;
            // 
            // rdoVal
            // 
            this.rdoVal.AutoSize = true;
            this.rdoVal.Location = new System.Drawing.Point(214, 172);
            this.rdoVal.Name = "rdoVal";
            this.rdoVal.Size = new System.Drawing.Size(77, 17);
            this.rdoVal.TabIndex = 17;
            this.rdoVal.Text = "With Value";
            this.rdoVal.UseVisualStyleBackColor = true;
            // 
            // rdoWVal
            // 
            this.rdoWVal.AutoSize = true;
            this.rdoWVal.Checked = true;
            this.rdoWVal.Location = new System.Drawing.Point(99, 174);
            this.rdoWVal.Name = "rdoWVal";
            this.rdoWVal.Size = new System.Drawing.Size(92, 17);
            this.rdoWVal.TabIndex = 16;
            this.rdoWVal.TabStop = true;
            this.rdoWVal.Text = "Without Value";
            this.rdoWVal.UseVisualStyleBackColor = true;
            // 
            // cmbSOpt
            // 
            this.cmbSOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSOpt.FormattingEnabled = true;
            this.cmbSOpt.Items.AddRange(new object[] {
            "Groupwise",
            "Itemwise"});
            this.cmbSOpt.Location = new System.Drawing.Point(88, 117);
            this.cmbSOpt.Name = "cmbSOpt";
            this.cmbSOpt.Size = new System.Drawing.Size(91, 21);
            this.cmbSOpt.TabIndex = 14;
            this.cmbSOpt.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(33, 119);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 13);
            this.label21.TabIndex = 15;
            this.label21.Text = "Option";
            // 
            // cmbSStore
            // 
            this.cmbSStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSStore.FormattingEnabled = true;
            this.cmbSStore.Location = new System.Drawing.Point(192, 90);
            this.cmbSStore.Name = "cmbSStore";
            this.cmbSStore.Size = new System.Drawing.Size(210, 21);
            this.cmbSStore.TabIndex = 13;
            // 
            // cmbFor
            // 
            this.cmbFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFor.FormattingEnabled = true;
            this.cmbFor.Items.AddRange(new object[] {
            "Godown",
            "POS",
            "ALL"});
            this.cmbFor.Location = new System.Drawing.Point(88, 88);
            this.cmbFor.Name = "cmbFor";
            this.cmbFor.Size = new System.Drawing.Size(91, 21);
            this.cmbFor.TabIndex = 11;
            this.cmbFor.SelectedIndexChanged += new System.EventHandler(this.cmbFor_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(33, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 13);
            this.label20.TabIndex = 12;
            this.label20.Text = "For";
            // 
            // cmbSType
            // 
            this.cmbSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSType.FormattingEnabled = true;
            this.cmbSType.Items.AddRange(new object[] {
            "Details",
            "Summary"});
            this.cmbSType.Location = new System.Drawing.Point(89, 196);
            this.cmbSType.Name = "cmbSType";
            this.cmbSType.Size = new System.Drawing.Size(121, 21);
            this.cmbSType.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(35, 201);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Type";
            // 
            // datSTTo
            // 
            this.datSTTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datSTTo.Location = new System.Drawing.Point(89, 59);
            this.datSTTo.Name = "datSTTo";
            this.datSTTo.Size = new System.Drawing.Size(120, 20);
            this.datSTTo.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "From Date";
            // 
            // cmbSItem
            // 
            this.cmbSItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSItem.FormattingEnabled = true;
            this.cmbSItem.Location = new System.Drawing.Point(88, 146);
            this.cmbSItem.Name = "cmbSItem";
            this.cmbSItem.Size = new System.Drawing.Size(325, 21);
            this.cmbSItem.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(33, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "To Date";
            // 
            // lblItm
            // 
            this.lblItm.AutoSize = true;
            this.lblItm.Location = new System.Drawing.Point(36, 149);
            this.lblItm.Name = "lblItm";
            this.lblItm.Size = new System.Drawing.Size(27, 13);
            this.lblItm.TabIndex = 6;
            this.lblItm.Text = "Item";
            // 
            // rdoStock
            // 
            this.rdoStock.AutoSize = true;
            this.rdoStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStock.Location = new System.Drawing.Point(467, 8);
            this.rdoStock.Name = "rdoStock";
            this.rdoStock.Size = new System.Drawing.Size(131, 19);
            this.rdoStock.TabIndex = 15;
            this.rdoStock.Text = "Item Stock Register";
            this.rdoStock.UseVisualStyleBackColor = true;
            // 
            // datWFrom
            // 
            this.datWFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datWFrom.Location = new System.Drawing.Point(89, 87);
            this.datWFrom.Name = "datWFrom";
            this.datWFrom.Size = new System.Drawing.Size(120, 20);
            this.datWFrom.TabIndex = 12;
            // 
            // datSTFrom
            // 
            this.datSTFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datSTFrom.Location = new System.Drawing.Point(88, 22);
            this.datSTFrom.Name = "datSTFrom";
            this.datSTFrom.Size = new System.Drawing.Size(120, 20);
            this.datSTFrom.TabIndex = 20;
            // 
            // CMSReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 304);
            this.Controls.Add(this.rdoStock);
            this.Controls.Add(this.grpItemStock);
            this.Controls.Add(this.grpItemSale);
            this.Controls.Add(this.rdoSalesSumm);
            this.Controls.Add(this.rdoItemwise);
            this.Controls.Add(this.rdoItemSales);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpSalesSumm);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGenarate);
            this.Controls.Add(this.grpItemwise);
            this.Name = "CMSReports";
            this.Text = "CMS Reports";
            this.Load += new System.EventHandler(this.CMSReports_Load);
            this.grpItemSale.ResumeLayout(false);
            this.grpItemSale.PerformLayout();
            this.grpSalesSumm.ResumeLayout(false);
            this.grpSalesSumm.PerformLayout();
            this.grpItemwise.ResumeLayout(false);
            this.grpItemwise.PerformLayout();
            this.grpItemStock.ResumeLayout(false);
            this.grpItemStock.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.DateTimePicker datFrom;
        private System.Windows.Forms.DateTimePicker datTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPOS;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenarate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpItemSale;
        private System.Windows.Forms.GroupBox grpItemwise;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpSalesSumm;
        private System.Windows.Forms.ComboBox cmbRType;
        private System.Windows.Forms.DateTimePicker datSFrom;
        private System.Windows.Forms.DateTimePicker datSTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdoItemSales;
        private System.Windows.Forms.RadioButton rdoItemwise;
        private System.Windows.Forms.RadioButton rdoSalesSumm;
        private System.Windows.Forms.GroupBox grpItemStock;
        private System.Windows.Forms.ComboBox cmbFor;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbSType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker datSTTo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbSItem;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblItm;
        private System.Windows.Forms.ComboBox cmbSOpt;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbSStore;
        private System.Windows.Forms.RadioButton rdoVal;
        private System.Windows.Forms.RadioButton rdoWVal;
        private System.Windows.Forms.RadioButton rdoStock;
        private System.Windows.Forms.ComboBox cmbSGrp;
        private System.Windows.Forms.ComboBox cmbSGodown;
        private System.Windows.Forms.DateTimePicker datWTo;
        private System.Windows.Forms.DateTimePicker datWFrom;
        private System.Windows.Forms.DateTimePicker datSTFrom;
    }
}