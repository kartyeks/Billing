using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IRCAKernel;
using BillingManager;

namespace BillinManager.Forms
{
    public partial class URLEntryForm : Form
    {
        public URLEntryForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            IRCARegistery registery = new IRCARegistery();

            String tmp = registery.Read(BillDefs.URLRegKey);

            if (null != tmp)
            {
                txtServerURL.Text = tmp;
            }

            tmp = registery.Read(BillDefs.TIMEOUT);

            if (null != tmp)
            {
                txtTimeout.Text = tmp;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                IRCARegistery registery = new IRCARegistery();

                registery.Write(BillDefs.URLRegKey, txtServerURL.Text.Trim());
                registery.Write(BillDefs.TIMEOUT, txtTimeout.Text.Trim());

                this.Dispose();
            }
        }

        private void txtTimeOut_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                e.Handled = true;
            }
        }

        public bool validate()
        {
            if (txtServerURL.Text.Trim().Equals(""))
            {
                lblError.Text = BillDefs.NO_URL;
                return false;
            }
            else if (txtTimeout.Text.Trim().Equals(""))
            {
                lblError.Text = BillDefs.NO_TIMEOUT;
                return false;
            }
            else
            {
                try
                {
                    int timeOut = Convert.ToInt32(txtTimeout.Text.Trim());

                    if (timeOut > BillDefs.MaxTimeOut)
                    {
                        lblError.Text = BillDefs.TIMEOUT_LIMIT;
                        return false;
                    }
                }
                catch (Exception e)
                {
                    lblError.Text = BillDefs.TIMEOUT_LIMIT;
                    return false;
                }
            }

            return true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtTimeout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUpdate_Click(null, null);
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
    }
}
