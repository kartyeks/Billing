namespace BillingManager.Forms
{
    partial class ItemPopup
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
            this.grdItem = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SRTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SRTax1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SRTax2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.tblSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tblClose = new System.Windows.Forms.ToolStripMenuItem();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            this.SuspendLayout();
            // 
            // grdItem
            // 
            this.grdItem.AllowUserToAddRows = false;
            this.grdItem.AllowUserToDeleteRows = false;
            this.grdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.HRate,
            this.ItemCode,
            this.ItemName,
            this.Unit,
            this.Rate,
            this.AQty,
            this.UnitID,
            this.STax,
            this.CTax,
            this.SRTax,
            this.SRTax1,
            this.SRTax2,
            this.CheckReq,
            this.StoreID});
            this.grdItem.Location = new System.Drawing.Point(2, 35);
            this.grdItem.Name = "grdItem";
            this.grdItem.ReadOnly = true;
            this.grdItem.Size = new System.Drawing.Size(502, 367);
            this.grdItem.TabIndex = 0;
            this.grdItem.DoubleClick += new System.EventHandler(this.grdItem_DoubleClick);
            this.grdItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdItem_KeyDown);
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Visible = false;
            // 
            // HRate
            // 
            this.HRate.HeaderText = "HRate";
            this.HRate.Name = "HRate";
            this.HRate.ReadOnly = true;
            this.HRate.Visible = false;
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
            this.ItemName.Width = 180;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // AQty
            // 
            this.AQty.HeaderText = "Quantity Avail.";
            this.AQty.Name = "AQty";
            this.AQty.ReadOnly = true;
            // 
            // UnitID
            // 
            this.UnitID.HeaderText = "UnitID";
            this.UnitID.Name = "UnitID";
            this.UnitID.ReadOnly = true;
            this.UnitID.Visible = false;
            // 
            // STax
            // 
            this.STax.HeaderText = "STax";
            this.STax.Name = "STax";
            this.STax.ReadOnly = true;
            this.STax.Visible = false;
            // 
            // CTax
            // 
            this.CTax.HeaderText = "CTax";
            this.CTax.Name = "CTax";
            this.CTax.ReadOnly = true;
            this.CTax.Visible = false;
            // 
            // SRTax
            // 
            this.SRTax.HeaderText = "SRTax";
            this.SRTax.Name = "SRTax";
            this.SRTax.ReadOnly = true;
            this.SRTax.Visible = false;
            // 
            // SRTax1
            // 
            this.SRTax1.HeaderText = "SRTax1";
            this.SRTax1.Name = "SRTax1";
            this.SRTax1.ReadOnly = true;
            this.SRTax1.Visible = false;
            // 
            // SRTax2
            // 
            this.SRTax2.HeaderText = "SRTax2";
            this.SRTax2.Name = "SRTax2";
            this.SRTax2.ReadOnly = true;
            this.SRTax2.Visible = false;
            // 
            // CheckReq
            // 
            this.CheckReq.HeaderText = "CheckReq";
            this.CheckReq.Name = "CheckReq";
            this.CheckReq.ReadOnly = true;
            this.CheckReq.Visible = false;
            // 
            // StoreID
            // 
            this.StoreID.HeaderText = "StoreID";
            this.StoreID.Name = "StoreID";
            this.StoreID.ReadOnly = true;
            this.StoreID.Visible = false;
            // 
            // mainmenu
            // 
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(504, 24);
            this.mainmenu.TabIndex = 26;
            this.mainmenu.Text = "menuStrip1";
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
            // cboItem
            // 
            this.cboItem.Enabled = false;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Items.AddRange(new object[] {
            "Name",
            "Code",
            "Rate"});
            this.cboItem.Location = new System.Drawing.Point(2, 409);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(121, 21);
            this.cboItem.TabIndex = 27;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(155, 410);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(163, 20);
            this.txtItem.TabIndex = 0;
            this.txtItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyUp);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(2, 409);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 27;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 410);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 28;
            // 
            // ItemPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(504, 457);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.cboItem);
            this.Controls.Add(this.mainmenu);
            this.Controls.Add(this.grdItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Details";
            this.Load += new System.EventHandler(this.ItemPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        
        

        

        #endregion

        private System.Windows.Forms.DataGridView grdItem;
        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem tblSelect;
        private System.Windows.Forms.ToolStripMenuItem tblClose;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STax;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRTax1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRTax2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreID;



    }
}