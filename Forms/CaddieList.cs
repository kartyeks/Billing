using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDACommunications;

namespace CaddieManager.Forms
{
    public partial class CaddieList : Form
    {
        private CaddieController _caddieController;
        private int _selectedRow;
        private bool _filterSelected;
        private Caddie _caddie;
        private CaddieDataStore _dataStore;


        private List<String> _FilterType = new List<string>();
        private List<String> _FilterMethod = new List<string>();

        public CaddieList()
        {
            InitializeComponent();

            _caddieController = CaddieController.CreateController();

            RefreshCaddieList();

            _FilterType.Add(CaddieDefs.FILTER_CODE);
            _FilterType.Add(CaddieDefs.FILTER_NAME);

            _FilterMethod.Add(CaddieDefs.FILTER_LIKE);
            _FilterMethod.Add(CaddieDefs.FILTER_CONTAINS);

            cmbType.DataSource = _FilterType;
            cmbType.SelectedIndex = 0;

            cmbMehotd.DataSource = _FilterMethod;
            cmbType.SelectedIndex = 0;
        }

        public void RefreshCaddieList()
        {
            CaddieListView.DataSource = null;
            CaddieListView.Refresh();

            String CaddieCode = "";
            String CaddieName = "";

            if (cmbType.Text == CaddieDefs.FILTER_CODE)
            {
                CaddieCode = txtValue.Text.Trim();
            }
            else if (cmbType.Text == CaddieDefs.FILTER_NAME)
            {
                CaddieName = txtValue.Text.Trim();
            }

            CaddieListView.DataSource = _caddieController.DataStore.GetAllCaddies(CaddieCode, CaddieName, cmbMehotd.Text);

            CaddieListView.Refresh();

            _filterSelected = false;
        }

        private void OnActivat(object sender, EventArgs e)
        {
            RefreshCaddieList();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            BasicStatusMessagae status = _caddieController.GetCaddieList();

            if (!status._isSuccess)
            {
                MessageBox.Show(CaddieDefs.LoadError + "\n" + status._message, CaddieDefs.ERROR);
                CaddieListView.DataSource = null;
                CaddieListView.Refresh();
            }
            else
            {
                RefreshCaddieList();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CaddieDetails_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection rowCol = CaddieListView.SelectedRows;
            if (rowCol.Count == 0)
            {
                MessageBox.Show(this, CaddieDefs.NO_RowSelected, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (rowCol.Count > 0)
            {
                DataGridViewRow[] rows = new DataGridViewRow[rowCol.Count];
                rowCol.CopyTo(rows, 0);
                try
                {
                    new CaddieEntry(rows[0].Cells[0].Value.ToString().Trim()).ShowDialog(this);
                }
                catch (Exception e1) { }
            }



        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rowCol = CaddieListView.SelectedRows;
            if (rowCol.Count == 0)
            {
                MessageBox.Show(this, CaddieDefs.NO_RowSelectedForDelete, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (rowCol.Count > 0)
                {
                    DataGridViewRow[] rows = new DataGridViewRow[rowCol.Count];
                    rowCol.CopyTo(rows, 0);
                    String caddieCode = rows[0].Cells[0].Value.ToString().Trim();
                    DialogResult dr = MessageBox.Show(this, CaddieDefs.DELETE_CONFIRM, CaddieDefs.WARNING, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dr != DialogResult.Cancel)
                    {
                        CaddieDelete objCaddieDelete = new CaddieDelete();
                        try
                        {
                            objCaddieDelete._caddieCode = caddieCode;
                            CommunicationObject response = _caddieController.DeleteCaddie(objCaddieDelete);


                            if (response is ErrorMessage)
                            {
                                MessageBox.Show(((ErrorMessage)response)._errorMessage, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (response is BasicStatusMessagae)
                            {
                                if (((BasicStatusMessagae)response)._isSuccess == true)
                                {
                                    MessageBox.Show(((BasicStatusMessagae)response)._message, CaddieDefs.MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _caddieController.DataStore.RemoveCaddie(objCaddieDelete._caddieCode);
                                    RefreshCaddieList();
                                }
                                else
                                {
                                    MessageBox.Show(((BasicStatusMessagae)response)._message, CaddieDefs.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                        }

                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }

        private void CaddieEntry_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rowCol = CaddieListView.SelectedRows;
            new CaddieValidator(CaddieActionType.CaddieEntry).ShowDialog(this);            
        }

        private void AvailLunch_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rowCol = CaddieListView.SelectedRows;

            new CaddieValidator(CaddieActionType.CaddieLunch).ShowDialog(this);            
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAddCaddie_Click(object sender, EventArgs e)
        {
            new CaddieEntry().ShowDialog(this);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            _filterSelected = true;

            RefreshCaddieList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtValue.Text = "";
            cmbType.SelectedIndex = 0;
            btnFilter_Click(sender, e);
        }
    }
}
