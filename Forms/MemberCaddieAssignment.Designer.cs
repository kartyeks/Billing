namespace CaddieManager.Forms
{
    partial class MemberCaddieAssignment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberCaddieAssignment));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberAccountNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCaddieCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.gbFingerSel = new System.Windows.Forms.GroupBox();
            this.rbLeftFinger = new System.Windows.Forms.RadioButton();
            this.rbRightFinger = new System.Windows.Forms.RadioButton();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.picFingerPrint = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.gbFingerSel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member Account Number";
            // 
            // txtMemberAccountNumber
            // 
            this.txtMemberAccountNumber.Location = new System.Drawing.Point(172, 13);
            this.txtMemberAccountNumber.Name = "txtMemberAccountNumber";
            this.txtMemberAccountNumber.Size = new System.Drawing.Size(77, 20);
            this.txtMemberAccountNumber.TabIndex = 1;
            this.txtMemberAccountNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMemberAccountNumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Caddie Code";
            // 
            // txtCaddieCode
            // 
            this.txtCaddieCode.Location = new System.Drawing.Point(349, 13);
            this.txtCaddieCode.Name = "txtCaddieCode";
            this.txtCaddieCode.ReadOnly = true;
            this.txtCaddieCode.Size = new System.Drawing.Size(144, 20);
            this.txtCaddieCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Remarks";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 312);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Enabled = false;
            this.btnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Location = new System.Drawing.Point(110, 312);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 7;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(217, 312);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(76, 45);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(188, 63);
            this.txtRemarks.TabIndex = 9;
            // 
            // gbFingerSel
            // 
            this.gbFingerSel.Controls.Add(this.rbLeftFinger);
            this.gbFingerSel.Controls.Add(this.rbRightFinger);
            this.gbFingerSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFingerSel.Location = new System.Drawing.Point(17, 133);
            this.gbFingerSel.Name = "gbFingerSel";
            this.gbFingerSel.Size = new System.Drawing.Size(132, 116);
            this.gbFingerSel.TabIndex = 26;
            this.gbFingerSel.TabStop = false;
            this.gbFingerSel.Text = "Select Finger";
            // 
            // rbLeftFinger
            // 
            this.rbLeftFinger.AutoSize = true;
            this.rbLeftFinger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLeftFinger.Location = new System.Drawing.Point(15, 70);
            this.rbLeftFinger.Name = "rbLeftFinger";
            this.rbLeftFinger.Size = new System.Drawing.Size(86, 17);
            this.rbLeftFinger.TabIndex = 1;
            this.rbLeftFinger.TabStop = true;
            this.rbLeftFinger.Text = "Left Finger";
            this.rbLeftFinger.UseVisualStyleBackColor = true;
            // 
            // rbRightFinger
            // 
            this.rbRightFinger.AutoSize = true;
            this.rbRightFinger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRightFinger.Location = new System.Drawing.Point(15, 33);
            this.rbRightFinger.Name = "rbRightFinger";
            this.rbRightFinger.Size = new System.Drawing.Size(94, 17);
            this.rbRightFinger.TabIndex = 0;
            this.rbRightFinger.TabStop = true;
            this.rbRightFinger.Text = "Right Finger";
            this.rbRightFinger.UseVisualStyleBackColor = true;
            // 
            // picPhoto
            // 
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Location = new System.Drawing.Point(349, 45);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(140, 204);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 25;
            this.picPhoto.TabStop = false;
            // 
            // picFingerPrint
            // 
            this.picFingerPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.picFingerPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFingerPrint.Location = new System.Drawing.Point(172, 133);
            this.picFingerPrint.Name = "picFingerPrint";
            this.picFingerPrint.Size = new System.Drawing.Size(109, 117);
            this.picFingerPrint.TabIndex = 24;
            this.picFingerPrint.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMessage.Location = new System.Drawing.Point(13, 278);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 27;
            // 
            // MemberCaddieAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(522, 347);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.gbFingerSel);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.picFingerPrint);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCaddieCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMemberAccountNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemberCaddieAssignment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member Caddie Assignment Details";
            this.Activated += new System.EventHandler(this.OnActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemberCaddieAssignment_FormClosing);
            this.gbFingerSel.ResumeLayout(false);
            this.gbFingerSel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMemberAccountNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCaddieCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.GroupBox gbFingerSel;
        private System.Windows.Forms.RadioButton rbLeftFinger;
        private System.Windows.Forms.RadioButton rbRightFinger;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.PictureBox picFingerPrint;
        private System.Windows.Forms.Label lblMessage;
    }
}