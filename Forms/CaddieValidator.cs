using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDACommunications;
using IRCAKernel;
using System.Media;
using ICMSCaddieManager;


namespace CaddieManager.Forms
{
    public partial class CaddieValidator : Form
    {       
        private CaddieBasicDetails _caddie;
        private CaddieActionType _type;
        private CaddieController _caddieController;

        private NitGenFPReader _SGFR;

        private void Init(CaddieActionType type)
        {
            InitializeComponent();

            _SGFR = new NitGenFPReader();

            _SGFR.Open();

            _caddieController = CaddieController.CreateController();

            _type = type;

            if (_type == CaddieActionType.CaddieEntry)
            {
                this.Text = "Caddie Entry";
                btnCaddiAction.Text = "Caddie Entry";

                btnCaddiAction.Visible = false;
                btnClear.Visible = false;
                btnGetCaddie.Visible = true;
            }
            else if (_type == CaddieActionType.CaddieExit)
            {
                this.Text = "Caddie Exit";
                btnCaddiAction.Text = "Caddie Exit";

                btnCaddiAction.Visible = false;
                btnClear.Visible = false;
                btnGetCaddie.Visible = true;
            }
            else
            {
                this.Text = "Avail Lunch";
                btnCaddiAction.Text = "Avail Lunch";
                btnCaddiAction.Visible = true;
                btnClear.Visible = true;
                btnGetCaddie.Visible = true;
            }
        }

        public CaddieValidator(CaddieActionType type)
        {
            Init(type);

            CaddieBasicDetails[] caddieList = _caddieController.DataStore.GetAllCaddies();

            for (int i = 0; i < caddieList.Length; i++)
            {
                if (caddieList[i]._isEnrolled)
                {
                    FingerPrintTemplate fp = new FingerPrintTemplate();

                    fp.PersonID = caddieList[i]._caddieID;
                    fp.TemplateString = caddieList[i]._leftFPTemplate;
                    
                    _SGFR.Enroll(fp);
                }
            }
        }

        private void Verify()
        {
            do
            {
                FingerPrintTemplate CapturedTemplate = _SGFR.Capture();

                if (NitGenFPReader.IsUserCanceled(CapturedTemplate.ErrorMessage))
                {
                    break;
                }

                FingerPrintTemplate IdentifiedTemplate = _SGFR.Identify(CapturedTemplate);

                if (null != IdentifiedTemplate)
                {
                    _caddie = _caddieController.DataStore.GetCaddieByID(IdentifiedTemplate.PersonID);

                    if (LoadCaddie(_caddie))
                    {
                        this.lblCaddieMessages.ForeColor = System.Drawing.Color.DarkGreen;
                        lblbMessage.Text = CaddieDefs.CADDIE_VERIFIED;

                        BasicStatusMessagae response;

                        if (_type == CaddieActionType.CaddieEntry)
                        {
                            response = _caddieController.LogCaddieEntry(_caddie._caddieID);
                        }
                        else if (_type == CaddieActionType.CaddieExit)
                        {
                            response = _caddieController.LogCaddieExit(_caddie._caddieID);
                        }
                        else
                        {
                            btnCaddiAction.Enabled = true;
                            return;
                        }

                        if (response._isSuccess)
                        {
                            btnCaddiAction.Enabled = false;
                        }

                        this.lblCaddieMessages.ForeColor = System.Drawing.Color.Chartreuse;
                        lblbMessage.Text = response._message;
                        SystemSounds.Beep.Play();
                    }

                }
                else
                {
                    this.lblCaddieMessages.ForeColor = System.Drawing.Color.Red;
                    lblbMessage.Text = CaddieDefs.INVALID_CODE;
                    Clear();
                    SystemSounds.Beep.Play();
                }
            }
            while (_type != CaddieActionType.CaddieLunch);
        }

        private void txtCaddieCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;            
        }

        private void txtCaddieName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private bool LoadCaddie(CaddieBasicDetails caddie)
        {            
            _caddie = caddie;

            if (_caddie == null)
            {
                MessageBox.Show(CaddieDefs.INVALID_CODE, CaddieDefs.ERROR);
                txtCaddieCode.Text = "";
                txtCaddieCode.Focus();

                return false;
            }
            else
            {
                if (!_caddie._isActive)
                {
                    this.lblCaddieMessages.ForeColor = System.Drawing.Color.Red;
                    this.lblCaddieMessages.Text = CaddieDefs.CADDIE_INACTIVE;
                    SystemSounds.Hand.Play();
                    Clear();

                    return false;
                }
                else if (!_caddie._isEnrolled)
                {
                    MessageBox.Show(CaddieDefs.CADDIE_NOTENROLLED, CaddieDefs.ERROR);

                    SystemSounds.Question.Play();
                    Clear();

                    return false;
                }

                txtCaddieCode.Text = _caddie._caddieCode;
                txtCaddieName.Text = _caddie._caddieName;

                Image image = IRCAUtils.ByteArrayToImage(_caddieController.GetCaddiePhoto(_caddie._caddieID));

                picPhoto.Image = IRCAUtils.GetScalledImage(image, picPhoto.Width, picPhoto.Height);
                                
                return true;
            }
        }

        private void Clear()
        {
            txtCaddieCode.Text = "";
            txtCaddieName.Text = "";
            picPhoto.Image = null;
            btnCaddiAction.Enabled = false;
        }
      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnCaddiAction_Click(object sender, EventArgs e)
        {
            BasicStatusMessagae response;

            if (_type == CaddieActionType.CaddieEntry)
            {
                response = _caddieController.LogCaddieEntry(_caddie._caddieID);
            }
            else
            {
                response = _caddieController.LogCaddieLunch(_caddie._caddieID);
            }

            if (response._isSuccess)
            {
                btnCaddiAction.Enabled = false;
                MessageBox.Show(response._message, CaddieDefs.MSG);
            }
            else
            {
                MessageBox.Show(response._message, CaddieDefs.ERROR);
            }
        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnGetCaddie_Click(object sender, EventArgs e)
        {
            if (_type == CaddieActionType.CaddieLunch)
            {
                btnCaddiAction.Enabled = false;
            }
            Verify();            
        }
    }
}
