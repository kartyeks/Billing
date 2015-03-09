namespace BillingManager.Forms
{
    partial class DependantMemberSearch
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
            this.grdDep = new System.Windows.Forms.DataGridView();
            this.DependantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DependantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Relation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.tblSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tblClose = new System.Windows.Forms.ToolStripMenuItem();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbRel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.picMem = new System.Windows.Forms.PictureBox();
            this.picDep = new System.Windows.Forms.PictureBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDep)).BeginInit();
            this.mainmenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDep)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDep
            // 
            this.grdDep.AllowUserToAddRows = false;
            this.grdDep.AllowUserToDeleteRows = false;
            this.grdDep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DependantID,
            this.DependantName,
            this.MemberName,
            this.AccountNumber,
            this.Category,
            this.Relation,
            this.DOB,
            this.MemberID});
            this.grdDep.Location = new System.Drawing.Point(7, 53);
            this.grdDep.Name = "grdDep";
            this.grdDep.ReadOnly = true;
            this.grdDep.Size = new System.Drawing.Size(712, 284);
            this.grdDep.TabIndex = 6;
            this.grdDep.DoubleClick += new System.EventHandler(this.grdDep_DoubleClick);
            this.grdDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDep_KeyDown);
            // 
            // DependantID
            // 
            this.DependantID.HeaderText = "DependantID";
            this.DependantID.Name = "DependantID";
            this.DependantID.ReadOnly = true;
            this.DependantID.Visible = false;
            // 
            // DependantName
            // 
            this.DependantName.HeaderText = "Depandant Name";
            this.DependantName.Name = "DependantName";
            this.DependantName.ReadOnly = true;
            this.DependantName.Width = 150;
            // 
            // MemberName
            // 
            this.MemberName.HeaderText = "Member Name";
            this.MemberName.Name = "MemberName";
            this.MemberName.ReadOnly = true;
            // 
            // AccountNumber
            // 
            this.AccountNumber.HeaderText = "Member ID";
            this.AccountNumber.Name = "AccountNumber";
            this.AccountNumber.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Relation
            // 
            this.Relation.HeaderText = "Relation";
            this.Relation.Name = "Relation";
            this.Relation.ReadOnly = true;
            // 
            // DOB
            // 
            this.DOB.HeaderText = "Date of Birth";
            this.DOB.Name = "DOB";
            this.DOB.ReadOnly = true;
            // 
            // MemberID
            // 
            this.MemberID.HeaderText = "MemberID";
            this.MemberID.Name = "MemberID";
            this.MemberID.ReadOnly = true;
            this.MemberID.Visible = false;
            // 
            // mainmenu
            // 
            this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tblSelect,
            this.tblClose});
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(689, 24);
            this.mainmenu.TabIndex = 26;
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
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(254, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 20);
            this.txtName.TabIndex = 2;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // cmbRel
            // 
            this.cmbRel.FormattingEnabled = true;
            this.cmbRel.Location = new System.Drawing.Point(457, 23);
            this.cmbRel.Name = "cmbRel";
            this.cmbRel.Size = new System.Drawing.Size(121, 21);
            this.cmbRel.TabIndex = 3;
            this.cmbRel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRel_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Dependant Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Relation";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(589, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.picMem);
            this.groupBox1.Controls.Add(this.picDep);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMobileNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPhoneNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAddr);
            this.groupBox1.Location = new System.Drawing.Point(15, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 116);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(581, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picMem
            // 
            this.picMem.Location = new System.Drawing.Point(488, 12);
            this.picMem.Name = "picMem";
            this.picMem.Size = new System.Drawing.Size(75, 89);
            this.picMem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMem.TabIndex = 41;
            this.picMem.TabStop = false;
            this.picMem.WaitOnLoad = true;
            // 
            // picDep
            // 
            this.picDep.Location = new System.Drawing.Point(398, 10);
            this.picDep.Name = "picDep";
            this.picDep.Size = new System.Drawing.Size(75, 89);
            this.picDep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDep.TabIndex = 40;
            this.picDep.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(247, 65);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(145, 20);
            this.txtEmail.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Mobile No.";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(247, 42);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(145, 20);
            this.txtMobileNo.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Email";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(247, 13);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(145, 20);
            this.txtPhoneNo.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Phone No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Address";
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(19, 32);
            this.txtAddr.Multiline = true;
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(145, 77);
            this.txtAddr.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Member ID";
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(69, 24);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(88, 20);
            this.txtMemberID.TabIndex = 1;
            this.txtMemberID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMemberID_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(668, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // DependantMemberSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(731, 468);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.mainmenu);
            this.Controls.Add(this.grdDep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DependantMemberSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dependant Member Search";
            this.Load += new System.EventHandler(this.DependantMemberSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDep)).EndInit();
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        

        

        
        

        

        #endregion

        private System.Windows.Forms.DataGridView grdDep;
        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem tblSelect;
        private System.Windows.Forms.ToolStripMenuItem tblClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn DependantID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DependantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Relation;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbRel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.PictureBox picMem;
        private System.Windows.Forms.PictureBox picDep;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;



    }
}