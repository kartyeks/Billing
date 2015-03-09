namespace BillingManager.Forms
{
    partial class BillPending
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
            this.grdBill = new System.Windows.Forms.DataGridView();
            this.BillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BearerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.tblDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tblClose = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBearerCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdBill)).BeginInit();
            this.mainmenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdBill
            // 
            this.grdBill.AllowUserToAddRows = false;
            this.grdBill.AllowUserToDeleteRows = false;
            this.grdBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillID,
            this.BillNumber,
            this.BillDate,
            this.Member,
            this.MemberID,
            this.OTNo,
            this.ItemID,
            this.ItemCode,
            this.ItemName,
            this.Unit,
            this.Quantity,
            this.BearerCode});
            this.grdBill.Location = new System.Drawing.Point(12, 78);
            this.grdBill.Name = "grdBill";
            this.grdBill.ReadOnly = true;
            this.grdBill.Size = new System.Drawing.Size(838, 367);
            this.grdBill.TabIndex = 0;
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
            this.BillNumber.Visible = false;
            // 
            // BillDate
            // 
            this.BillDate.HeaderText = "Bill Date";
            this.BillDate.Name = "BillDate";
            this.BillDate.ReadOnly = true;
            // 
            // Member
            // 
            this.Member.HeaderText = "Member";
            this.Member.Name = "Member";
            this.Member.ReadOnly = true;
            this.Member.Width = 120;
            // 
            // MemberID
            // 
            this.MemberID.HeaderText = "MemberID";
            this.MemberID.Name = "MemberID";
            this.MemberID.ReadOnly = true;
            this.MemberID.Visible = false;
            // 
            // OTNo
            // 
            this.OTNo.HeaderText = "OT Number";
            this.OTNo.Name = "OTNo";
            this.OTNo.ReadOnly = true;
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Visible = false;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // BearerCode
            // 
            this.BearerCode.HeaderText = "Bearer Code";
            this.BearerCode.Name = "BearerCode";
            this.BearerCode.ReadOnly = true;
            // 
            // mainmenu
            // 
            this.mainmenu.BackColor = System.Drawing.Color.SteelBlue;
            this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tblDelete,
            this.tblClose});
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(882, 24);
            this.mainmenu.TabIndex = 26;
            this.mainmenu.Text = "menuStrip1";
            // 
            // tblDelete
            // 
            this.tblDelete.ForeColor = System.Drawing.Color.White;
            this.tblDelete.Name = "tblDelete";
            this.tblDelete.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.tblDelete.Size = new System.Drawing.Size(52, 20);
            this.tblDelete.Text = "&Delete";
            this.tblDelete.Click += new System.EventHandler(this.tblDelete_Click);
            // 
            // tblClose
            // 
            this.tblClose.ForeColor = System.Drawing.Color.White;
            this.tblClose.Name = "tblClose";
            this.tblClose.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tblClose.Size = new System.Drawing.Size(48, 20);
            this.tblClose.Text = "&Close";
            this.tblClose.Click += new System.EventHandler(this.tblClose_Click);
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(760, 43);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(108, 20);
            this.txtBillNumber.TabIndex = 27;
            this.txtBillNumber.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(296, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 48);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(201, 26);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(104, 20);
            this.dtTo.TabIndex = 33;
            this.dtTo.Value = new System.DateTime(2011, 9, 12, 0, 0, 0, 0);
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(49, 26);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(104, 20);
            this.dtFrom.TabIndex = 32;
            this.dtFrom.Value = new System.DateTime(2011, 9, 12, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(757, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Bill Number";
            this.label1.Visible = false;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(636, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 30;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(33, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Account Number";
            // 
            // txtAccNo
            // 
            this.txtAccNo.Location = new System.Drawing.Point(36, 45);
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Size = new System.Drawing.Size(108, 20);
            this.txtAccNo.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(161, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Bearer Code";
            // 
            // txtBearerCode
            // 
            this.txtBearerCode.Location = new System.Drawing.Point(164, 46);
            this.txtBearerCode.Name = "txtBearerCode";
            this.txtBearerCode.Size = new System.Drawing.Size(108, 20);
            this.txtBearerCode.TabIndex = 34;
            // 
            // BillPending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BillingManager.Properties.Resources.bg_gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 457);
            this.Controls.Add(this.txtBearerCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAccNo);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBillNumber);
            this.Controls.Add(this.mainmenu);
            this.Controls.Add(this.grdBill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillPending";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pending Bill Details";
            this.Load += new System.EventHandler(this.ItemPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBill)).EndInit();
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        

        #endregion

        private System.Windows.Forms.DataGridView grdBill;
        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem tblDelete;
        private System.Windows.Forms.ToolStripMenuItem tblClose;
        private System.Windows.Forms.TextBox txtBillNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBearerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BearerCode;



    }
}