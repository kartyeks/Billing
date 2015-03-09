namespace TallySynchronizer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rchStatus = new System.Windows.Forms.RichTextBox();
            this.notifyServiceIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSynchronize = new System.Windows.Forms.Button();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCheckDuplicate = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rchStatus
            // 
            this.rchStatus.Location = new System.Drawing.Point(12, 70);
            this.rchStatus.Name = "rchStatus";
            this.rchStatus.Size = new System.Drawing.Size(1000, 444);
            this.rchStatus.TabIndex = 2;
            this.rchStatus.Text = "";
            this.rchStatus.TextChanged += new System.EventHandler(this.rchStatus_TextChanged);
            // 
            // notifyServiceIcon
            // 
            this.notifyServiceIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyServiceIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyServiceIcon.Icon")));
            this.notifyServiceIcon.Text = "Notify Service";
            this.notifyServiceIcon.Visible = true;
            this.notifyServiceIcon.DoubleClick += new System.EventHandler(this.notifyServiceIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRestore,
            this.mnuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 48);
            this.contextMenuStrip1.Text = "File";
            // 
            // mnuRestore
            // 
            this.mnuRestore.Name = "mnuRestore";
            this.mnuRestore.Size = new System.Drawing.Size(123, 22);
            this.mnuRestore.Text = "Restore";
            this.mnuRestore.Click += new System.EventHandler(this.mnuRestore_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(123, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // btnSynchronize
            // 
            this.btnSynchronize.Location = new System.Drawing.Point(531, 39);
            this.btnSynchronize.Name = "btnSynchronize";
            this.btnSynchronize.Size = new System.Drawing.Size(75, 23);
            this.btnSynchronize.TabIndex = 4;
            this.btnSynchronize.Text = "Synchronize";
            this.btnSynchronize.UseVisualStyleBackColor = true;
            this.btnSynchronize.Click += new System.EventHandler(this.btnSynchronize_Click);
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(97, 13);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(867, 20);
            this.txtDB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Base";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tally URL";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(97, 39);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(226, 20);
            this.txtURL.TabIndex = 8;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(412, 39);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(100, 20);
            this.txtCompany.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = " Company";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(612, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Start Date";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(682, 41);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(66, 20);
            this.txtFrom.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(754, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "End Date";
            // 
            // btnCheckDuplicate
            // 
            this.btnCheckDuplicate.Location = new System.Drawing.Point(889, 41);
            this.btnCheckDuplicate.Name = "btnCheckDuplicate";
            this.btnCheckDuplicate.Size = new System.Drawing.Size(75, 23);
            this.btnCheckDuplicate.TabIndex = 14;
            this.btnCheckDuplicate.Text = "Check Duplicate";
            this.btnCheckDuplicate.UseVisualStyleBackColor = true;
            this.btnCheckDuplicate.Click += new System.EventHandler(this.btnCheckDuplicate_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(812, 41);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(71, 20);
            this.txtTo.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(358, 517);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Ready...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 574);
            this.Controls.Add(this.btnCheckDuplicate);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rchStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSynchronize);
            this.Name = "Form1";
            this.Text = "Tally Synchronizer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchStatus;
        private System.Windows.Forms.NotifyIcon notifyServiceIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Button btnSynchronize;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCheckDuplicate;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblStatus;
    }
}

