namespace BillingManager.Forms
{
    partial class MainScreen
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
            this.lnkBill = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lnkBill
            // 
            this.lnkBill.AutoSize = true;
            this.lnkBill.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBill.Location = new System.Drawing.Point(83, 18);
            this.lnkBill.Name = "lnkBill";
            this.lnkBill.Size = new System.Drawing.Size(87, 18);
            this.lnkBill.TabIndex = 0;
            this.lnkBill.TabStop = true;
            this.lnkBill.Text = "BAR Billing";
            this.lnkBill.Visible = false;
            this.lnkBill.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBill_LinkClicked);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(316, 353);
            this.Controls.Add(this.lnkBill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Billing";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkBill;


    }
}