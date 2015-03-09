namespace CaddieManager.Forms
{
    partial class CaddieManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaddieManager));
            this.lblCaddieCode = new System.Windows.Forms.Label();
            this.txtCaddieCode = new System.Windows.Forms.TextBox();
            this.lblCaddieName = new System.Windows.Forms.Label();
            this.txtCaddieName = new System.Windows.Forms.TextBox();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.lblCodeError = new System.Windows.Forms.Label();
            this.lblbMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaddieCode
            // 
            this.lblCaddieCode.AutoSize = true;
            this.lblCaddieCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaddieCode.Location = new System.Drawing.Point(2, 13);
            this.lblCaddieCode.Name = "lblCaddieCode";
            this.lblCaddieCode.Size = new System.Drawing.Size(79, 13);
            this.lblCaddieCode.TabIndex = 0;
            this.lblCaddieCode.Text = "Caddie Code";
            // 
            // txtCaddieCode
            // 
            this.txtCaddieCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtCaddieCode.Location = new System.Drawing.Point(87, 12);
            this.txtCaddieCode.Name = "txtCaddieCode";
            this.txtCaddieCode.Size = new System.Drawing.Size(100, 20);
            this.txtCaddieCode.TabIndex = 1;
            this.txtCaddieCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCaddieCode_KeyDown);
            // 
            // lblCaddieName
            // 
            this.lblCaddieName.AutoSize = true;
            this.lblCaddieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaddieName.Location = new System.Drawing.Point(2, 46);
            this.lblCaddieName.Name = "lblCaddieName";
            this.lblCaddieName.Size = new System.Drawing.Size(82, 13);
            this.lblCaddieName.TabIndex = 2;
            this.lblCaddieName.Text = "Caddie Name";
            // 
            // txtCaddieName
            // 
            this.txtCaddieName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtCaddieName.Location = new System.Drawing.Point(87, 43);
            this.txtCaddieName.Name = "txtCaddieName";
            this.txtCaddieName.Size = new System.Drawing.Size(170, 20);
            this.txtCaddieName.TabIndex = 3;
            this.txtCaddieName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCaddieName_KeyDown);
            // 
            // btnEnroll
            // 
            this.btnEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.Location = new System.Drawing.Point(51, 147);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(100, 23);
            this.btnEnroll.TabIndex = 14;
            this.btnEnroll.Text = "Enroll Caddie";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(183, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picPhoto
            // 
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Location = new System.Drawing.Point(350, 3);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(109, 117);
            this.picPhoto.TabIndex = 16;
            this.picPhoto.TabStop = false;
            // 
            // lblCodeError
            // 
            this.lblCodeError.AutoSize = true;
            this.lblCodeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeError.ForeColor = System.Drawing.Color.Maroon;
            this.lblCodeError.Location = new System.Drawing.Point(193, 15);
            this.lblCodeError.Name = "lblCodeError";
            this.lblCodeError.Size = new System.Drawing.Size(12, 13);
            this.lblCodeError.TabIndex = 17;
            this.lblCodeError.Text = "*";
            // 
            // lblbMessage
            // 
            this.lblbMessage.AutoSize = true;
            this.lblbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbMessage.ForeColor = System.Drawing.Color.Maroon;
            this.lblbMessage.Location = new System.Drawing.Point(21, 128);
            this.lblbMessage.Name = "lblbMessage";
            this.lblbMessage.Size = new System.Drawing.Size(0, 16);
            this.lblbMessage.TabIndex = 18;
            // 
            // CaddieManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 189);
            this.Controls.Add(this.lblbMessage);
            this.Controls.Add(this.lblCodeError);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.txtCaddieName);
            this.Controls.Add(this.lblCaddieName);
            this.Controls.Add(this.txtCaddieCode);
            this.Controls.Add(this.lblCaddieCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaddieManager";
            this.ShowInTaskbar = false;
            this.Text = "CaddieManager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaddieCode;
        private System.Windows.Forms.TextBox txtCaddieCode;
        private System.Windows.Forms.Label lblCaddieName;
        private System.Windows.Forms.TextBox txtCaddieName;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label lblCodeError;
        private System.Windows.Forms.Label lblbMessage;
    }
}