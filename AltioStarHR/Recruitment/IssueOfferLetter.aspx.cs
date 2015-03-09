using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRManager.BusinessObjects;
using System.Data;

namespace AltioStarHR.Recruitment
{
    public partial class IssueOfferLetter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtTable = new Setting_ConfigurationBusinessObject().GetDataTable();
            if (dtTable != null && dtTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    if (dtTable.Rows[i]["Name"].ToString() == "Annual Conveyance Allowance")
                        hdnCA.Value = dtTable.Rows[i]["Value"].ToString();
                    if (dtTable.Rows[i]["Name"].ToString() == "Medical Reimbursement")
                        hdnMedicalReimb.Value = dtTable.Rows[i]["Value"].ToString();
                }
            }
        }
    }
}
