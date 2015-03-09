using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDACommunications;
using IRCAKernel;
using ICMSCaddieManager;
using ICMSMemberManager;
using ICMSPOS;

namespace MemberManager.Forms
{
    public partial class MemberEntry : Form
    {
        private Member _member;
        private MemberDetails _memberdet;
        private bool IsNewMember = false;
        private MemberController _memberController;

        private bool IsEnrollSelected = false;
        private bool IsValidated = true;


        private bool btnCaptureClicked = false;
        private NitGenFPReader _SGFR;
        private bool _isClosing=false;

        private void MemberEntry_Load(object sender, EventArgs e)
        {
            LoadMembers();
            cmbType.Text = "Cash";
             
        }

        private void LoadMembers()
        {
             MemberDetails[] mList = _memberController.DataStore.GetAllMembers();

            for (int i = 0; i < mList.Length; i++)
            {
                if (mList[i]._isEnrolled)
                {
                    FingerPrintTemplate fp = new FingerPrintTemplate();

                    fp.MemberID = mList[i]._memberID;
                    fp.TemplateString = mList[i]._MFPTemplate;
                    _SGFR.Enroll(fp);
                }
            }

 
        }

        public MemberEntry()
        {
            Init();

            _member = null;

            IsNewMember = true;
            
        }

        private void Init()
        {
            InitializeComponent();
            
            LoadClubDetails();
            
            _memberController = MemberController.CreateController();

            _SGFR = new NitGenFPReader();

            _SGFR.Open();

            dtDate.MaxDate = DateTime.Today;

        }
        private void LoadClubDetails()
        {
            _memberController = MemberController.CreateController();
            //CommunicationObject _clubs = _memberController.GetClubDetails();
            cmbClub.ValueMember = "_clubID";
            cmbClub.DisplayMember = "_clubName";
            cmbClub.DataSource = _memberController.DataStore.GetAllClubs();
            if(cmbClub.Items.Count>0)
                cmbClub.SelectedIndex = 0;
        }
        private void LoadMember()
        {
            cmbClub.Enabled = true;
            chkLostCard.Enabled = true;
            if (_member != null)
            {
                if (_member._memberExists)
                {
                    txtMemberName.Text = _member._memberName;
                    chkIsGuest.Checked = _member._isGuest;
                    txtAccountNumber.Text = _member._accountNumber;
                    dtDate.Value = _memberdet._fillDate;
                    txtBalance.Text = string.Concat(_memberdet._balAmt);
                    ClubDetails objClub = new ClubDetails();
                    objClub._clubID = _memberdet.ClubID;
                    objClub._clubName = _memberdet.ClubName;
                    cmbClub.SelectedItem = objClub;
                    if (chkIsGuest.Checked)
                    {
                        if (cmbClub.Items.Count > 0)
                            cmbClub.SelectedIndex = 0;
                        cmbClub.Enabled = false;
                    }

                    txtAmount.Text = string.Concat(_member._amount);

                    txtReference.Text = _member._referenceNo;
                    txtChequeNo.Text = _member._chequeNo;
                    dpChequeDate.Value = _member._createdDate;
                    cmbType.Text = _member._paymentMode;
                    if (_member._memberStatus == "F")
                    {
                        if (_member._currentDate.Date == _member._FillDate.Date)
                        {
                            chkLostCard.Enabled = false;
                            btnRead.Enabled = false;
                        }
                    }
                    else if (_member._memberStatus != "U")
                    {
                        btnRefund.Enabled = true;
                    }
                }
            }
        }

 
        private void btnSave_Click(object sender, EventArgs e)
        {
            IsValidated = IsValid();

            if (!IsValidated)
            {
                return;
            }
            bool blnRes = new SmartCardReader().IsCardConnected();
            if (!blnRes)
            {
                MessageBox.Show("Place the card");
                return;
            }

            if (_member == null)
            {
                _member = new Member();
            }

            _member._memberName = txtMemberName.Text;
            _member._accountNumber= txtAccountNumber.Text;
            _member._clubID = string.Concat(cmbClub.SelectedValue);
            _member._clubName = string.Concat(cmbClub.SelectedText);
            _member._FillDate = dtDate.Value;
            _member._isGuest = chkIsGuest.Checked;
            double amt = 0;
            double.TryParse(txtBalance.Text, out amt );
            _member._balAmt = amt;
            _member._referenceNo = txtReference.Text;
            amt = 0;
            double.TryParse(txtAmount.Text, out amt);
            _member._amount=amt ;
            _member._paymentMode = string.Concat(cmbType.SelectedValue);
            _member._smartcardNo = txtSmartCardNo.Text;
            _member._isGuest= chkIsGuest.Checked;
//            _member._chequeNo=
            if (IsNewMember)
            {
                _member._isEnrolled = false;
                _member._FPTemplate = new byte[1]; ;
                _member._createdBy = _memberController.DataStore.LoggedInUser;
                _member._createdDate = DateTime.Now;
                _member._memberID = "-1";
            }

            _member._modifiedBy = _memberController.DataStore.LoggedInUser;
            _member._modifiedDate = DateTime.Now;

            CommunicationObject response = _memberController.UpdateCaddie(_member);

            if (response is ErrorMessage)
            {
                MessageBox.Show(this, MemberDefs.MEMBER_SAVE_ERROR + "\n" + ((ErrorMessage)response)._errorMessage, 
                MemberDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            else if (response is BasicStatusMessagae)
            {
                if (!((BasicStatusMessagae)response)._isSuccess)
                {
                    MessageBox.Show(this, ((BasicStatusMessagae)response)._message, MemberDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string wrstr=_member._cardPrefix + _member._memberID +"$"+_member._cardSerialNo;
                
                bool  bln =new SmartCardReader().Write2SmartCard(wrstr);
                if(bln==false)
                {
                  MessageBox.Show("Place the card");
                  return ;
                }
                if (((BasicStatusMessagae)response)._isSuccess)
                {
                    MessageBox.Show(this, ((BasicStatusMessagae)response)._message, MemberDefs.MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private bool IsValid()
        {
            IsValidated = false;

            if (txtMemberName.Text == "")
            {
                MessageBox.Show(this, MemberDefs.NO_MEMBERNAME, MemberDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!chkIsGuest.Checked)
            {
                if (cmbClub.SelectedIndex == 0)
                {
                    MessageBox.Show(this, MemberDefs.NO_CLUBNAME, MemberDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //else if (txtAccountNumber.Text  == "")
            //{
            //    MessageBox.Show(this, MemberDefs.NO_ACCOUNTNUMBER, MemberDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else if (txtPhoneNumber.Text == "")
            //{
            //    MessageBox.Show(this, MemberDefs.NO_PHONENUMBER, MemberDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            else if (txtSmartCardNo.Text == "")
            {
                MessageBox.Show(this, MemberDefs.NO_SMARTCARDNO, MemberDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtReference.Text == "")
            {
                MessageBox.Show(this, MemberDefs.NO_REFERENCE, MemberDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtAmount.Text == "")
            {
                MessageBox.Show(this, MemberDefs.NO_AMOUNT, MemberDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return true;
            }

            return false;
        }

        private void Clear()
        {
            txtMemberName.Text = "";
            chkIsGuest.Checked = false;
            txtSmartCardNo.Text = "";
            txtAccountNumber.Text = "";
            txtAmount.Text = "";
            txtBalance.Text = "";
            txtReference.Text = "";
            cmbType.Text = "";
            dtDate.Value = DateTime.Today;
            IsNewMember = true;
            IsEnrollSelected = false;
            if(cmbClub.Items.Count>0)
                cmbClub.SelectedIndex = 0;
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            Clear();

          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            _isClosing = true;
            Application.Exit();
        }

        void MemberEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isClosing)
            {
                if (DialogResult.Yes == MessageBox.Show(MemberDefs.EXIT_CONFIRM, MemberDefs.EXIT, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _isClosing = true;

                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                    _isClosing = false;
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
             
                FingerPrintTemplate CapturedTemplate = _SGFR.Capture();

                if (NitGenFPReader.IsUserCanceled(CapturedTemplate.ErrorMessage))
                {
                    return;
                }

                FingerPrintTemplate IdentifiedTemplate = _SGFR.Identify(CapturedTemplate);

                if (null != IdentifiedTemplate)
                {
                    _member = _memberController.GetMember(IdentifiedTemplate.MemberID);

                    if (_member != null)
                    {

                        LoadMember();

                    }

                }
                else
                {
                    try
                    {
                        _member=new Member();
                       FingerPrintTemplate _FPTemplate = _SGFR.Enroll("0");

                      if (String.IsNullOrEmpty(_FPTemplate.ErrorMessage))
                      {
                        _member._MFPTemplate = _FPTemplate.TemplateString;
                      }
                    }
                    catch (Exception e1) { MessageBox.Show(e1.Message); }
                }
         }
        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;
            if (x >= 48 && x <= 57 || (Char.IsControl(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.Text == "Cheque")
            {
                lblChqNo.Visible = true;
                lblChqAmt.Visible = true;
                lblChqDate.Visible = true;
                txtChequeNo.Visible = true;
                txtChequeAmt.Visible = true;
                dpChequeDate.Visible = true;
            }
            else
            {
                lblChqNo.Visible = false;
                lblChqAmt.Visible = false;
                lblChqDate.Visible = false;
                txtChequeNo.Visible = false;
                txtChequeAmt.Visible = false;
                dpChequeDate.Visible = false;
            }
        }

        private void chkIsGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsGuest.Checked)
            {
                cmbClub.SelectedIndex = 0;
                cmbClub.Enabled = false;
            }
            else
            {
                cmbClub.Enabled = true;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            SmartCardReader objSmart = new SmartCardReader();
            if (!objSmart.IsCardConnected())
            {
                return;
            }
            string cdata = objSmart.ReadSmartCardDataStr();
            if (cdata == string.Empty)
            {
                MessageBox.Show("Invalid Card", "ICMS Cash Card Details");
                return;
            }
            string[] arrVal = cdata.Split("$".ToCharArray());

            if (arrVal.Length < 3)
            {
                MessageBox.Show("Invalid Card", "ICMS Cash Card Details");
                return;
            }
            if (arrVal[0] != _member._cardPrefix)
            {
                MessageBox.Show("Invalid Card", "ICMS Cash Card Details");
                return;
            }
            string mId = arrVal[1];
            _member = _memberController.GetMember(mId);

            if (_member != null)
            {
                LoadMember();
                chkLostCard.Enabled = false;
                btnEnroll.Enabled = false;
                btnSave.Enabled = false;
                btnRead.Enabled = false;
                btnRefund.Enabled = true;
            }
    
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to refund?", "ICMS Cash Card Details", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

        }



      }
}
