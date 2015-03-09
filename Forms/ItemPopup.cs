using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IRCAKernel;
using System.Reflection;
using BillingManager;
using BillingManager.Forms;
using BillinManager.Forms;
using PDACommunications;

namespace BillingManager.Forms
{
    public partial class ItemPopup : Form
    {
        BillingItemDetails[] itms =null;
        public ItemPopup()
        {
            InitializeComponent();
        }
        void ItemPopup_Load(object sender, System.EventArgs e)
        {
            cboItem.SelectedIndex = 0;
            txtItem.Focus();
            if (((ICMSBill)this.Owner).OldStoreId == ((ICMSBill)this.Owner).StoreId)
            {
                itms = BillController._billController.DataStore.GetItemDetails();
                if (itms.Length == 0)
                {
                    string StoreId = ((ICMSBill)this.Owner).StoreId;
                    ((ICMSBill)this.Owner).OldStoreId = StoreId;
                    BillingBasicStatusMessagae status = BillController._billController.GetItemList(StoreId);
                    itms = BillController._billController.DataStore.GetItemDetails();
                }
            }
            else
            {
                string StoreId = ((ICMSBill)this.Owner).StoreId;
                ((ICMSBill)this.Owner).OldStoreId = StoreId;
                BillingBasicStatusMessagae status = BillController._billController.GetItemList(StoreId);
                itms = BillController._billController.DataStore.GetItemDetails();
            }
           grdItem.Rows.Clear();
           if (itms.Length > 0)
           {
               grdItem.Rows.Add(itms.Length);
               int k = 0;
               foreach (BillingItemDetails itm in itms)
               {
                   DataGridViewRow dr = grdItem.Rows[k];
                   dr.Cells["ItemID"].Value = itm._itemId;
                   dr.Cells["ItemCode"].Value = itm._itemCode;
                   dr.Cells["ItemName"].Value = itm._itemName;
                   dr.Cells["Unit"].Value = itm._baseUnit;
                   if (((ICMSBill)this.Owner).IsHappyHourRate)
                       dr.Cells["Rate"].Value = itm._happyhrRate;
                   else
                       dr.Cells["Rate"].Value = itm._rate;
                   dr.Cells["UnitID"].Value = itm._baseUnitId;
                   dr.Cells["AQty"].Value = itm._availableQuantity;
                   dr.Cells["CheckReq"].Value = itm._isStockCheckRequire;
                   dr.Cells["HRate"].Value = itm._happyhrRate;
                   dr.Cells["STax"].Value = itm._sAcc;
                   dr.Cells["StoreID"].Value = itm._storeId;
                   k++;
               }
           }
        }

        void txtItem_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back)
            {
                BillingItemDetails[] tmpitms = itms; 
                if (cboItem.Text == "Code")
                {
                    tmpitms = Array.FindAll(itms, (x) => (x._itemCode.ToLower().IndexOf(txtItem.Text.ToLower()) >= 0));
                }
                else if (cboItem.Text == "Name")
                {
                    if (txtItem.Text != "")
                    {
                        tmpitms = Array.FindAll(itms, (x) => (x._itemName.ToLower().IndexOf(txtItem.Text.ToLower()) == 0));
                    }
                    else
                    {
                        tmpitms = itms;
                    }
                }
                else if (cboItem.Text == "Rate")
                {
                    tmpitms = Array.FindAll(itms, (x) => (x._rate.ToString().ToLower().IndexOf(txtItem.Text.ToLower()) >= 0));
                }
                 
                grdItem.Rows.Clear();
                if (tmpitms.Length > 0)
                {
                    grdItem.Rows.Add(tmpitms.Length);
                    int k = 0;
                    foreach (BillingItemDetails itm in tmpitms)
                    {
                        DataGridViewRow dr = grdItem.Rows[k];
                        dr.Cells["ItemID"].Value = itm._itemId;
                        dr.Cells["ItemCode"].Value = itm._itemCode;
                        dr.Cells["ItemName"].Value = itm._itemName;
                        dr.Cells["Unit"].Value = itm._baseUnit;
                        if (((ICMSBill)this.Owner).IsHappyHourRate)
                            dr.Cells["Rate"].Value = itm._happyhrRate;
                        else
                            dr.Cells["Rate"].Value = itm._rate;
                        dr.Cells["UnitID"].Value = itm._baseUnitId;
                        dr.Cells["AQty"].Value = itm._availableQuantity;
                        dr.Cells["CheckReq"].Value = itm._isStockCheckRequire;
                        dr.Cells["HRate"].Value = itm._happyhrRate;
                        dr.Cells["STax"].Value = itm._sAcc;
                        dr.Cells["StoreID"].Value = itm._storeId;
                        k++;
                    }
                }
            }
        }
        private void tblSelect_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow crow = grdItem.CurrentRow;
            if (crow == null)
            {
                MessageBox.Show("Select Row","Billing");
                return;
            }
            DataGridView grd = ((ICMSBill)this.Owner).grdBilling;
            DataGridViewRow dr = ((ICMSBill)this.Owner).grdBilling.CurrentRow;
            string vItemCodes = IS91.Services.Common.GetAppSetting("ItemCodes");
            if (vItemCodes != string.Empty)
            {
                vItemCodes = "," + vItemCodes + ",";
                if (!vItemCodes.Contains("," + string.Concat(crow.Cells["ItemCode"].Value) + ","))//isStockCheckRequired &&
                {
                    MessageBox.Show("Invalid Item", "CMS Billing Details");
                    return;
                }
            }

            if ( string.Concat(crow.Cells["CheckReq"].Value).ToLower() == "true")
            {
                if ((double)crow.Cells["AQty"].Value <= 0)
                {
                    MessageBox.Show("Stock Not Avialable For This Item '" + crow.Cells["ItemName"].Value + "'", "CMS Billing");
                    return;
                }
            }
            for (int k = 0; k < grd.Rows.Count; k++)
            {
                if (string.Concat(grd.Rows[k].Cells[2].Value).ToUpper() == string.Concat(crow.Cells["ItemCode"].Value).ToUpper())
                {
                    MessageBox.Show("Item already exists", "CMS Billing Details");
                     return;
                }
                
            }
            ((ICMSBill)this.Owner).grdBilling.EndEdit();
            dr.Cells[2].Value = crow.Cells["ItemCode"].Value;
            dr.Cells[3].Value = crow.Cells["ItemName"].Value;
            dr.Cells[4].Value = crow.Cells["Unit"].Value;
            dr.Cells[6].Value = crow.Cells["Rate"].Value;
            dr.Cells[9].Value = crow.Cells["HRate"].Value; ;
            dr.Cells[8].Value = crow.Cells["ItemID"].Value;
            dr.Cells[10].Value = crow.Cells["UnitID"].Value;
            dr.Cells[11].Value = 0;
            dr.Cells[12].Value = 0;
            dr.Cells[17].Value = crow.Cells["StoreID"].Value;
            dr.Cells[13].Value = ((ICMSBill)this.Owner).itemSrNo +1;
            
            ((ICMSBill)this.Owner).itemSrNo = ((ICMSBill)this.Owner).itemSrNo + 1;
            ((ICMSBill)this.Owner).IsDecAllowed = crow.Cells["STax"].Value != "1";
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void tblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void grdItem_DoubleClick(object sender, System.EventArgs e)
        {
             tblSelect_Click(this.grdItem,new EventArgs());
        }
        void grdItem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tblSelect_Click(this.grdItem, new EventArgs());
                e.Handled = true;
            }

        }

    }
}
