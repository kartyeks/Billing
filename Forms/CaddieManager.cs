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
    public partial class CaddieManager : Form
    {
        private CaddieController _caddieController;
        private bool _caddiCodeIsNotPresent;

        private Caddie _caddie;
        private CaddieType _CaddieType;

        private NitGenFPReader _SGFP;

        private void Init()
        {
            InitializeComponent();

            _caddieController = CaddieController.CreateController();

            _SGFP = new NitGenFPReader();

            _SGFP.Open();
        }

        public CaddieManager(String caddieCode)
        {
            Init();
      
            _caddiCodeIsNotPresent = false;

            LoadCaddie(caddieCode);

        }

        public CaddieManager(Caddie caddie)
        {
            Init();

            _caddiCodeIsNotPresent = false;

            _caddie = caddie;

            LoadCaddie(caddie._caddieCode);
        }

        public CaddieManager()
        {
            Init();

            _caddiCodeIsNotPresent = true;
        }

        private void LoadCaddie(String caddieCode)
        {
            if (_caddie == null)
            {
                _caddie = (Caddie)_caddieController.GetCaddie(_caddieController.DataStore.GetCaddieByCode(caddieCode)._caddieID);
            }

            if (_caddie == null)
            {
                MessageBox.Show(CaddieDefs.INVALID_CODE, CaddieDefs.ERROR);
                this.Dispose();
                return;
            }
            else
            {
                if (!_caddie._isActive)
                {
                    MessageBox.Show(CaddieDefs.CADDIE_INACTIVE, CaddieDefs.ERROR);
                    this.Dispose();                    
                    return;
                }
                else if (_caddie._isEnrolled)
                {
                    if (DialogResult.No == MessageBox.Show(CaddieDefs.CADDIE_ENROLLED, CaddieDefs.WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        this.Dispose();
                        return;
                    }
                }
                txtCaddieCode.Text = _caddie._caddieCode;
                txtCaddieName.Text = _caddie._caddieName;
                
                Image image = IRCAUtils.ByteArrayToImage(_caddieController.GetCaddiePhoto(_caddie._caddieID));

                picPhoto.Image = IRCAUtils.GetScalledImage(image, picPhoto.Width, picPhoto.Height);
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (null != _caddie)
            {
                FingerPrintTemplate _FPTemplate = _SGFP.Enroll(_caddie._caddieID);

                if (String.IsNullOrEmpty(_FPTemplate.ErrorMessage))
                {
                    _caddie._leftFPTemplate = _FPTemplate.TemplateString;

                    BasicStatusMessagae msg = _caddieController.EnrollCaddie(_caddie);

                    if (msg._isSuccess)
                    {
                        MessageBox.Show(msg._message, CaddieDefs.MSG);
                        Clear();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(CaddieDefs.ENROLL_ERROR + "\n" + msg._message, CaddieDefs.ERROR);
                    }                    
                }
                else
                {
                    MessageBox.Show(CaddieDefs.ENROLL_ERROR + "\n" + _FPTemplate.ErrorMessage, CaddieDefs.ERROR);
                }                
            }
            else
            {
                MessageBox.Show(CaddieDefs.NO_CADDIE, CaddieDefs.ERROR);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtCaddieCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txtCaddieName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Clear()
        {
            txtCaddieCode.Text = "";
            txtCaddieName.Text = "";
            btnEnroll.Enabled = false;
            picPhoto.Image = null;
        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
            _SGFP.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
