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

namespace CaddieManager.Forms
{
    public partial class MemberCaddieAssignment : Form
    {
        private delegate void DisplayStatus(String text);
        private delegate void DrawImage(Bitmap image);
        
        private CaddieController _caddieController;
        private MemberCaddieAssignDetails _caddieMemberCaddieDetails;
        private CaddieBasicDetails _caddie;

        NitGenFPReader _NitGenReader = new NitGenFPReader();

        public MemberCaddieAssignment()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemberCaddieAssignment_FormClosing);

            _caddieController = CaddieController.CreateController();
            txtMemberAccountNumber.Focus();
            this.ActiveControl = txtMemberAccountNumber;

            _NitGenReader.Open();

            CaddieBasicDetails[] caddieList = _caddieController.DataStore.GetAllCaddies();

            for (int i = 0; i < caddieList.Length; i++)
            {
                if (caddieList[i]._isEnrolled)
                {
                    FingerPrintTemplate fp = new FingerPrintTemplate();

                    fp.PersonID = caddieList[i]._caddieID;

                    fp.TemplateString = caddieList[i]._leftFPTemplate;

                    _NitGenReader.Enroll(fp);
                }
            }

        }

        private void txtMemberAccountNumber_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                _caddieMemberCaddieDetails = null;
                
                String MemberAccountNumber = txtMemberAccountNumber.Text;

                if (!MemberAccountNumber.Equals(""))
                {
                    LoadCaddieDetails(MemberAccountNumber);                    
                }
            }
        }

        public void LoadCaddieDetails(String MemberAccountNumber)
        {
            CommunicationObject response = _caddieController.GetMemberCaddieDetails(MemberAccountNumber);
            
              
            if (response is BasicStatusMessagae)
            {
                if (((BasicStatusMessagae)response)._isSuccess)
                {
                    if (((BasicStatusMessagae)response)._message == "No Assignment found")
                    {
                        MessageBox.Show(((BasicStatusMessagae)response)._message, CaddieDefs.CADDIE_NOT_ASSIGNED, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    _caddieMemberCaddieDetails = new MemberCaddieAssignDetails();
                    _caddieMemberCaddieDetails._ID = 0;
                    btnEnd.Enabled = false;
                    btnStart.Enabled = true;


                    FingerPrintTemplate fp = _NitGenReader.Capture();
                                        
                    FingerPrintTemplate enrolled = _NitGenReader.Identify(fp);
                                        

                    if (enrolled != null)
                    {
                        _caddie = _caddieController.DataStore.GetCaddieByID(enrolled.PersonID);

                        txtCaddieCode.Text = _caddie.CaddieCode;
                        Caddie Caddie = (Caddie)_caddieController.GetCaddie(_caddie._caddieID);
                        picPhoto.Image = IRCAUtils.GetScalledImage(Caddie._photo, picPhoto.Width, picPhoto.Height);

                    }   
                }
                else
                {
                    MessageBox.Show(((BasicStatusMessagae)response)._message, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (response is ErrorMessage)
            {
                MessageBox.Show(((ErrorMessage)response)._errorMessage, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemberAccountNumber.Text = "";
                txtMemberAccountNumber.Focus();
            }        
            else
            {
                _caddieMemberCaddieDetails = (MemberCaddieAssignDetails)response;

                if (_caddieMemberCaddieDetails._ID <= 0)
                {
                    btnStart.Enabled = true;
                    btnEnd.Enabled = false;
                }
                else
                {
                    _caddie = _caddieController.DataStore.GetCaddieByID(_caddieMemberCaddieDetails._CaddieID);
                    
                    Caddie Caddie = (Caddie)_caddieController.GetCaddie(_caddie._caddieID);
                    picPhoto.Image = IRCAUtils.GetScalledImage(Caddie._photo, picPhoto.Width, picPhoto.Height);

                    btnStart.Enabled = false;
                    btnEnd.Enabled = true;
                    txtCaddieCode.Text = _caddie._caddieCode;
                    txtRemarks.Text = _caddieMemberCaddieDetails._Remarks;
                }
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            _NitGenReader.Close();
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtMemberAccountNumber.Text.Trim() == "")
            {
                MessageBox.Show(CaddieDefs.ACC_NO_NOT_FOUND, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_caddie == null)
            {
                MessageBox.Show(CaddieDefs.INVALID_CODE, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_caddie._isActive == false)
            {
                MessageBox.Show(CaddieDefs.CADDIE_INACTIVE, CaddieDefs.ERROR);
            } 
            else
            {
                _caddieMemberCaddieDetails = new MemberCaddieAssignDetails();
                _caddieMemberCaddieDetails._AccountNumber = txtMemberAccountNumber.Text;
                _caddieMemberCaddieDetails._CaddieID = _caddie._caddieID;
                _caddieMemberCaddieDetails._Remarks = txtRemarks.Text;
                _caddieMemberCaddieDetails._StartDateTime = DateTime.Now;
                _caddieMemberCaddieDetails._EndDateTime = GetEndOfDay(DateTime.Today);
                _caddieMemberCaddieDetails._CreatedBy = _caddieController.DataStore.LoggedInUser;
                _caddieMemberCaddieDetails._CreatedDate = DateTime.Now;
                _caddieMemberCaddieDetails._ModifiedBy = _caddieController.DataStore.LoggedInUser;
                _caddieMemberCaddieDetails._ModifiedDate = DateTime.Now;

                CommunicationObject response = _caddieController.UpdateMemberCaddieAssignment(_caddieMemberCaddieDetails);

                if (response is ErrorMessage)
                {
                    MessageBox.Show(((ErrorMessage)response)._errorMessage, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (response is BasicStatusMessagae)
                {
                    MessageBox.Show(((BasicStatusMessagae)response)._message, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _caddieMemberCaddieDetails = (MemberCaddieAssignDetails)response;

                    MessageBox.Show(CaddieDefs.ASSIGN_SUCCESS, CaddieDefs.MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clear();
                }
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_caddie == null)
            {
                MessageBox.Show(CaddieDefs.INVALID_CODE, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _caddieMemberCaddieDetails._AccountNumber = txtMemberAccountNumber.Text;
                _caddieMemberCaddieDetails._CaddieID = _caddie._caddieID;
                _caddieMemberCaddieDetails._Remarks = txtRemarks.Text;
                _caddieMemberCaddieDetails._EndDateTime = DateTime.Now;
                _caddieMemberCaddieDetails._ModifiedBy = _caddieController.DataStore.LoggedInUser;
                _caddieMemberCaddieDetails._ModifiedDate = DateTime.Now;

                CommunicationObject response = _caddieController.UpdateMemberCaddieAssignment(_caddieMemberCaddieDetails);

                if (response is ErrorMessage)
                {
                    MessageBox.Show(((ErrorMessage)response)._errorMessage, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (response is BasicStatusMessagae)
                {
                    MessageBox.Show(((BasicStatusMessagae)response)._message, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(CaddieDefs.DEASSIGN_SUCCESS, CaddieDefs.MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear();
            }
        }

        private DateTime GetEndOfDay(DateTime ThisTime)
        {
            return new DateTime(ThisTime.Year, ThisTime.Month, ThisTime.Day,23,59,59);
        }

        private void clear()
        {
            _caddieMemberCaddieDetails = null;
            _caddie = null;

            txtMemberAccountNumber.Text = "";
            txtCaddieCode.Text = "";
            picFingerPrint.Image = null;
            picPhoto.Image = null;            
            txtRemarks.Text = "";
            btnStart.Enabled = true;
            btnEnd.Enabled = false;

            ClearReader();
            txtMemberAccountNumber.Focus();
        }
                
        private void SetImage(Bitmap Image)
        {
            if (this.picFingerPrint.InvokeRequired)
            {
                this.Invoke(new DrawImage(SetImage), Image);
            }
            else
            {
                picFingerPrint.Image = IRCAUtils.GetScalledImage(Image, picFingerPrint.Width, picFingerPrint.Height);
            }

            if (_caddie == null)
            {
                MessageBox.Show(CaddieDefs.INVALID_CODE, CaddieDefs.ERROR);
                return;
            }
            else if (!_caddie._isActive)
            {
                MessageBox.Show(CaddieDefs.CADDIE_INACTIVE, CaddieDefs.ERROR);
                return;
            }
            else
            {
                txtCaddieCode.Text = _caddie._caddieCode;
                Caddie Caddie = (Caddie)_caddieController.GetCaddie(_caddie._caddieID);

                picPhoto.Image = IRCAUtils.ByteArrayToImage(Caddie._photo);
            }
        }

        private void SetStatus(String message)
        {
            if (this.lblMessage.InvokeRequired)
            {
                this.Invoke(new DisplayStatus(SetStatus), message);
            }
            else
            {
                this.lblMessage.Text = message;
            }
        }

        private void OnActivated(object sender, EventArgs e)
        {
            ClearReader();
        }

        private void ClearReader()
        {
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //txtMemberAccountNumber.Focus();
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MemberCaddieAssignment_FormClosing(object sender, FormClosingEventArgs e)
        {
                        
        }


    }
}
