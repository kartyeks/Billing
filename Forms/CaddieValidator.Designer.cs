namespace CaddieManager.Forms
{
    partial class CaddieValidator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaddieValidator));
            this.txtCaddieName = new System.Windows.Forms.TextBox();
            this.lblCaddieName = new System.Windows.Forms.Label();
            this.txtCaddieCode = new System.Windows.Forms.TextBox();
            this.lblCaddieCode = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.lblbMessage = new System.Windows.Forms.Label();
            this.btnGetCaddie = new System.Windows.Forms.Button();
            this.btnCaddiAction = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCaddieMessages = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCaddieName
            // 
            this.txtCaddieName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtCaddieName.Location = new System.Drawing.Point(91, 43);
            this.txtCaddieName.Name = "txtCaddieName";
            this.txtCaddieName.Size = new System.Drawing.Size(170, 20);
            this.txtCaddieName.TabIndex = 20;
            this.txtCaddieName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCaddieName_KeyDown);
            // 
            // lblCaddieName
            // 
            this.lblCaddieName.AutoSize = true;
            this.lblCaddieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaddieName.Location = new System.Drawing.Point(6, 46);
            this.lblCaddieName.Name = "lblCaddieName";
            this.lblCaddieName.Size = new System.Drawing.Size(82, 13);
            this.lblCaddieName.TabIndex = 19;
            this.lblCaddieName.Text = "Caddie Name";
            // 
            // txtCaddieCode
            // 
            this.txtCaddieCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtCaddieCode.Location = new System.Drawing.Point(91, 12);
            this.txtCaddieCode.Name = "txtCaddieCode";
            this.txtCaddieCode.Size = new System.Drawing.Size(100, 20);
            this.txtCaddieCode.TabIndex = 18;
            this.txtCaddieCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCaddieCode_KeyDown);
            // 
            // lblCaddieCode
            // 
            this.lblCaddieCode.AutoSize = true;
            this.lblCaddieCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaddieCode.Location = new System.Drawing.Point(6, 13);
            this.lblCaddieCode.Name = "lblCaddieCode";
            this.lblCaddieCode.Size = new System.Drawing.Size(79, 13);
            this.lblCaddieCode.TabIndex = 17;
            this.lblCaddieCode.Text = "Caddie Code";
            // 
            // picPhoto
            // 
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Location = new System.Drawing.Point(324, 12);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(140, 187);
            this.picPhoto.TabIndex = 22;
            this.picPhoto.TabStop = false;
            // 
            // lblbMessage
            // 
            this.lblbMessage.AutoSize = true;
            this.lblbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbMessage.ForeColor = System.Drawing.Color.Maroon;
            this.lblbMessage.Location = new System.Drawing.Point(12, 220);
            this.lblbMessage.Name = "lblbMessage";
            this.lblbMessage.Size = new System.Drawing.Size(0, 13);
            this.lblbMessage.TabIndex = 24;
            // 
            // btnGetCaddie
            // 
            this.btnGetCaddie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetCaddie.Location = new System.Drawing.Point(127, 269);
            this.btnGetCaddie.Name = "btnGetCaddie";
            this.btnGetCaddie.Size = new System.Drawing.Size(90, 23);
            this.btnGetCaddie.TabIndex = 26;
            this.btnGetCaddie.Text = "Verify Caddie";
            this.btnGetCaddie.UseVisualStyleBackColor = true;
            this.btnGetCaddie.Click += new System.EventHandler(this.btnGetCaddie_Click);
            // 
            // btnCaddiAction
            // 
            this.btnCaddiAction.Enabled = false;
            this.btnCaddiAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaddiAction.Location = new System.Drawing.Point(244, 269);
            this.btnCaddiAction.Name = "btnCaddiAction";
            this.btnCaddiAction.Size = new System.Drawing.Size(90, 23);
            this.btnCaddiAction.TabIndex = 27;
            this.btnCaddiAction.UseVisualStyleBackColor = true;
            this.btnCaddiAction.Click += new System.EventHandler(this.btnCaddiAction_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(25, 269);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(361, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCaddieMessages
            // 
            this.lblCaddieMessages.AutoSize = true;
            this.lblCaddieMessages.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblCaddieMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCaddieMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaddieMessages.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCaddieMessages.Location = new System.Drawing.Point(19, 241);
            this.lblCaddieMessages.Name = "lblCaddieMessages";
            this.lblCaddieMessages.Size = new System.Drawing.Size(2, 18);
            this.lblCaddieMessages.TabIndex = 30;
            // 
            // CaddieValidator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 298);
            this.Controls.Add(this.lblCaddieMessages);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCaddiAction);
            this.Controls.Add(this.btnGetCaddie);
            this.Controls.Add(this.lblbMessage);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.txtCaddieName);
            this.Controls.Add(this.lblCaddieName);
            this.Controls.Add(this.txtCaddieCode);
            this.Controls.Add(this.lblCaddieCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaddieValidator";
            this.ShowInTaskbar = false;
            this.Text = "CaddieValidator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCaddieName;
        private System.Windows.Forms.Label lblCaddieName;
        private System.Windows.Forms.TextBox txtCaddieCode;
        private System.Windows.Forms.Label lblCaddieCode;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label lblbMessage;
        private System.Windows.Forms.Button btnGetCaddie;
        private System.Windows.Forms.Button btnCaddiAction;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCaddieMessages;

    }
}