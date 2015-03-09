using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
    public partial class Master_InvestmentGroupBusinessObject
    {
        public Master_InvestmentGroup GetInvestmentByInvestment(String Investment)
        {
            Master_InvestmentGroup[] Investments = GetInvestmentGroups(" Investment = '" + Investment + "'");

            if (Investments != null && Investments.Length > 0)
            {
                return Investments[0];
            }
            else
            {
                return null;
            }
        }

        public Master_InvestmentGroup[] GetAllInActiveInvestmentOrderByInvestment()
        {
            Master_InvestmentGroup[] Investment = GetAllInActiveInvestment();

            if (Investment != null && Investment.Length >= 0)
            {
                return Investment;
            }
            else
            {
                return null;
            }
        }

        public Master_InvestmentGroup[] GetAllInActiveInvestment()
        {
            const String Qry = "SELECT * FROM Master_InvestmentGroup WHERE IsActive=0 ORDER BY InvestmentGroupName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_InvestmentGroup[] InvestmentGroupDetails = new Master_InvestmentGroup[dt.Rows.Count];

            for (int i = 0; i < InvestmentGroupDetails.Length; i++)
            {
                InvestmentGroupDetails[i] = new Master_InvestmentGroup();
                InvestmentGroupDetails[i].ID = (int)dt.Rows[i]["ID"];
                InvestmentGroupDetails[i].InvestmentGroupName = (String)dt.Rows[i]["InvestmentGroupName"];
                InvestmentGroupDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return InvestmentGroupDetails;
        }

        public Master_InvestmentGroup[] GetAllActiveInvestment()
        {
            const String Qry = "SELECT * FROM Master_InvestmentGroup WHERE IsActive=1 ORDER BY InvestmentGroupName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_InvestmentGroup[] InvestmentGroupDetails = new Master_InvestmentGroup[dt.Rows.Count];

            for (int i = 0; i < InvestmentGroupDetails.Length; i++)
            {
                InvestmentGroupDetails[i] = new Master_InvestmentGroup();
                InvestmentGroupDetails[i].ID = (int)dt.Rows[i]["ID"];
                InvestmentGroupDetails[i].InvestmentGroupName = (String)dt.Rows[i]["InvestmentGroupName"];
                InvestmentGroupDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return InvestmentGroupDetails;
        }

        public Master_InvestmentGroup[] GetAllInvestmentGroupDetails()
        {
            const String Qry = "SELECT * FROM Master_InvestmentGroup ORDER BY InvestmentGroupName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_InvestmentGroup[] InvestmentGroupDetails = new Master_InvestmentGroup[dt.Rows.Count];

            for (int i = 0; i < InvestmentGroupDetails.Length; i++)
            {
                InvestmentGroupDetails[i] = new Master_InvestmentGroup();
                InvestmentGroupDetails[i].ID = (int)dt.Rows[i]["ID"];
                InvestmentGroupDetails[i].InvestmentGroupName = (String)dt.Rows[i]["InvestmentGroupName"];
                InvestmentGroupDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return InvestmentGroupDetails;
        }

        public Master_InvestmentGroup[] GetInvestmentGroups(String Filter)
        {
            const String Qry = " SELECT * FROM Master_InvestmentGroup WHERE IsActive=1 ORDER BY InvestmentGroupName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == String.Empty)
            {
                exQry.Query = string.Format(Qry);
            }
            else
            {
                exQry.Query = string.Format(Qry) + " WHERE " + Filter;
            }

            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_InvestmentGroup[] InvestmentGroup = new Master_InvestmentGroup[dt.Rows.Count];

            for (int i = 0; i < InvestmentGroup.Length; i++)
            {
                InvestmentGroup[i] = new Master_InvestmentGroup();
                InvestmentGroup[i].ID = (int)dt.Rows[i]["ID"];
                InvestmentGroup[i].InvestmentGroupName = (String)dt.Rows[i]["InvestmentGroupName"];
                InvestmentGroup[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return InvestmentGroup;
        }


        public bool IsInvestmentGroupExists(String InvestmentGroupName, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_InvestmentGroup WHERE InvestmentGroupName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, InvestmentGroupName, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

    }
}
