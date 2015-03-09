using System.Windows.Forms;
namespace MemberManager.Forms
{
    partial class MemberEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberEntry));
            this.lblCaddieName = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.lblFatherName = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblQualification = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkIsGuest = new System.Windows.Forms.CheckBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.cmbClub = new System.Windows.Forms.ComboBox();
            this.lblCaddieCode = new System.Windows.Forms.Label();
            this.txtSmartCardNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.lblChqNo = new System.Windows.Forms.Label();
            this.dpChequeDate = new System.Windows.Forms.DateTimePicker();
            this.lblChqDate = new System.Windows.Forms.Label();
            this.txtChequeAmt = new System.Windows.Forms.TextBox();
            this.lblChqAmt = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.chkLostCard = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblCaddieName
            // 
            this.lblCaddieName.AutoSize = true;
            this.lblCaddieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaddieName.Location = new System.Drawing.Point(4, 129);
            this.lblCaddieName.Name = "lblCaddieName";
            this.lblCaddieName.Size = new System.Drawing.Size(87, 13);
            this.lblCaddieName.TabIndex = 2;
            this.lblCaddieName.Text = "Member Name";
            // 
            // txtMemberName
            // 
            this.txtMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberName.Location = new System.Drawing.Point(112, 126);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(242, 20);
            this.txtMemberName.TabIndex = 3;
            // 
            // lblFatherName
            // 
            this.lblFatherName.AutoSize = true;
            this.lblFatherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFatherName.Location = new System.Drawing.Point(5, 158);
            this.lblFatherName.Name = "lblFatherName";
            this.lblFatherName.Size = new System.Drawing.Size(101, 13);
            this.lblFatherName.TabIndex = 4;
            this.lblFatherName.Text = "Account Number";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.Location = new System.Drawing.Point(112, 158);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(131, 20);
            this.txtAccountNumber.TabIndex = 4;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(5, 191);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(49, 13);
            this.lblPhoneNumber.TabIndex = 6;
            this.lblPhoneNumber.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(112, 184);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(125, 56);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(34, 13);
            this.lblDOB.TabIndex = 8;
            this.lblDOB.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Enabled = false;
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(165, 51);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(96, 20);
            this.dtDate.TabIndex = 10;
            // 
            // lblQualification
            // 
            this.lblQualification.AutoSize = true;
            this.lblQualification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualification.Location = new System.Drawing.Point(5, 218);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(99, 13);
            this.lblQualification.TabIndex = 12;
            this.lblQualification.Text = "Balance Amount";
            // 
            // txtBalance
            // 
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(113, 215);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(100, 20);
            this.txtBalance.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(12, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Fill";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFill
            // 
            this.btnFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFill.Location = new System.Drawing.Point(140, 465);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(103, 23);
            this.btnFill.TabIndex = 12;
            this.btnFill.Text = "&Clear";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(275, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkIsGuest
            // 
            this.chkIsGuest.AutoSize = true;
            this.chkIsGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsGuest.Location = new System.Drawing.Point(7, 54);
            this.chkIsGuest.Name = "chkIsGuest";
            this.chkIsGuest.Size = new System.Drawing.Size(73, 17);
            this.chkIsGuest.TabIndex = 2;
            this.chkIsGuest.Text = "Is Guest";
            this.chkIsGuest.UseVisualStyleBackColor = true;
            this.chkIsGuest.CheckedChanged += new System.EventHandler(this.chkIsGuest_CheckedChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(5, 312);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(105, 13);
            this.lblType.TabIndex = 26;
            this.lblType.Text = "Mode of Payment";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Cash",
            "Card",
            "Cheque"});
            this.cmbType.Location = new System.Drawing.Point(112, 309);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(100, 21);
            this.cmbType.TabIndex = 7;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.Location = new System.Drawing.Point(5, 251);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(90, 13);
            this.lblReference.TabIndex = 28;
            this.lblReference.Text = "Reference No.";
            // 
            // txtReference
            // 
            this.txtReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReference.Location = new System.Drawing.Point(112, 244);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(100, 20);
            this.txtReference.TabIndex = 8;
            // 
            // btnEnroll
            // 
            this.btnEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.Location = new System.Drawing.Point(7, 12);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(110, 23);
            this.btnEnroll.TabIndex = 12;
            this.btnEnroll.Text = "&Enroll";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // cmbClub
            // 
            this.cmbClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClub.FormattingEnabled = true;
            this.cmbClub.Location = new System.Drawing.Point(112, 91);
            this.cmbClub.Name = "cmbClub";
            this.cmbClub.Size = new System.Drawing.Size(242, 21);
            this.cmbClub.TabIndex = 29;
            // 
            // lblCaddieCode
            // 
            this.lblCaddieCode.AutoSize = true;
            this.lblCaddieCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaddieCode.Location = new System.Drawing.Point(5, 94);
            this.lblCaddieCode.Name = "lblCaddieCode";
            this.lblCaddieCode.Size = new System.Drawing.Size(86, 13);
            this.lblCaddieCode.TabIndex = 0;
            this.lblCaddieCode.Text = "Affiliated Club";
            // 
            // txtSmartCardNo
            // 
            this.txtSmartCardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSmartCardNo.Location = new System.Drawing.Point(112, 276);
            this.txtSmartCardNo.Name = "txtSmartCardNo";
            this.txtSmartCardNo.Size = new System.Drawing.Size(100, 20);
            this.txtSmartCardNo.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Smart Card No.";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(113, 346);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(100, 20);
            this.txtChequeNo.TabIndex = 32;
            this.txtChequeNo.Visible = false;
            // 
            // lblChqNo
            // 
            this.lblChqNo.AutoSize = true;
            this.lblChqNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChqNo.Location = new System.Drawing.Point(5, 349);
            this.lblChqNo.Name = "lblChqNo";
            this.lblChqNo.Size = new System.Drawing.Size(74, 13);
            this.lblChqNo.TabIndex = 33;
            this.lblChqNo.Text = "Cheque No.";
            this.lblChqNo.Visible = false;
            // 
            // dpChequeDate
            // 
            this.dpChequeDate.CustomFormat = "dd/MM/yyyy";
            this.dpChequeDate.Enabled = false;
            this.dpChequeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpChequeDate.Location = new System.Drawing.Point(113, 380);
            this.dpChequeDate.Name = "dpChequeDate";
            this.dpChequeDate.Size = new System.Drawing.Size(96, 20);
            this.dpChequeDate.TabIndex = 35;
            this.dpChequeDate.Visible = false;
            // 
            // lblChqDate
            // 
            this.lblChqDate.AutoSize = true;
            this.lblChqDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChqDate.Location = new System.Drawing.Point(5, 380);
            this.lblChqDate.Name = "lblChqDate";
            this.lblChqDate.Size = new System.Drawing.Size(81, 13);
            this.lblChqDate.TabIndex = 34;
            this.lblChqDate.Text = "Cheque Date";
            this.lblChqDate.Visible = false;
            // 
            // txtChequeAmt
            // 
            this.txtChequeAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeAmt.Location = new System.Drawing.Point(112, 406);
            this.txtChequeAmt.Name = "txtChequeAmt";
            this.txtChequeAmt.Size = new System.Drawing.Size(100, 20);
            this.txtChequeAmt.TabIndex = 36;
            this.txtChequeAmt.Visible = false;
            // 
            // lblChqAmt
            // 
            this.lblChqAmt.AutoSize = true;
            this.lblChqAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChqAmt.Location = new System.Drawing.Point(5, 413);
            this.lblChqAmt.Name = "lblChqAmt";
            this.lblChqAmt.Size = new System.Drawing.Size(96, 13);
            this.lblChqAmt.TabIndex = 37;
            this.lblChqAmt.Text = "Cheque Amount";
            this.lblChqAmt.Visible = false;
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(210, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(110, 23);
            this.btnRead.TabIndex = 38;
            this.btnRead.Text = "&Read Card";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.Enabled = false;
            this.btnRefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefund.Location = new System.Drawing.Point(326, 12);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(97, 23);
            this.btnRefund.TabIndex = 39;
            this.btnRefund.Text = "&Refund";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // chkLostCard
            // 
            this.chkLostCard.AutoSize = true;
            this.chkLostCard.Enabled = false;
            this.chkLostCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLostCard.Location = new System.Drawing.Point(299, 55);
            this.chkLostCard.Name = "chkLostCard";
            this.chkLostCard.Size = new System.Drawing.Size(80, 17);
            this.chkLostCard.TabIndex = 40;
            this.chkLostCard.Text = "Lost Card";
            this.chkLostCard.UseVisualStyleBackColor = true;
            // 
            // MemberEntry
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(435, 500);
            this.ControlBox = false;
            this.Controls.Add(this.chkLostCard);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.txtChequeAmt);
            this.Controls.Add(this.lblChqAmt);
            this.Controls.Add(this.dpChequeDate);
            this.Controls.Add(this.lblChqDate);
            this.Controls.Add(this.txtChequeNo);
            this.Controls.Add(this.lblChqNo);
            this.Controls.Add(this.txtSmartCardNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClub);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.chkIsGuest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.lblQualification);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.lblFatherName);
            this.Controls.Add(this.txtMemberName);
            this.Controls.Add(this.lblCaddieName);
            this.Controls.Add(this.lblCaddieCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MemberEntry";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member Card Details";
            this.Load += new System.EventHandler(this.MemberEntry_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemberEntry_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.Label lblCaddieName;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Label lblFatherName;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkIsGuest;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox txtReference;
        private Button btnEnroll;
        private ComboBox cmbClub;
        private Label lblCaddieCode;
        private TextBox txtSmartCardNo;
        private Label label1;
        private TextBox txtChequeNo;
        private Label lblChqNo;
        private DateTimePicker dpChequeDate;
        private Label lblChqDate;
        private TextBox txtChequeAmt;
        private Label lblChqAmt;
        private Button btnRead;
        private Button btnRefund;
        private CheckBox chkLostCard;

    }
}