using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using IRCA.Communication;

namespace HRManager.BusinessObjects
{
    public partial class Master_ProjectInformationBusinessObject
    {


        public Master_ProjectInformation GetInvestmentByInvestment(String ProjectName)
        {
            Master_ProjectInformation[] ProjectInfo = GetProjectInfo(" ProjectDetails = '" + ProjectName + "'");

            if (ProjectInfo != null && ProjectInfo.Length > 0)
            {
                return ProjectInfo[0];
            }
            else
            {
                return null;
            }
        }

        public Master_ProjectInformation[] GetAllInActiveProjectInfoOrderByProjectName()
        {
            Master_ProjectInformation[] ProjectDetails = GetAllInActiveProjectInfo();

            if (ProjectDetails != null && ProjectDetails.Length >= 0)
            {
                return ProjectDetails;
            }
            else
            {
                return null;
            }
        }

        public Master_ProjectInformation[] GetAllInActiveProjectInfo()
        {
            const String Qry = "SELECT * FROM Master_ProjectInformation WHERE IsActive=0 ORDER BY ProjectName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_ProjectInformation[] ProjectInfDetails = new Master_ProjectInformation[dt.Rows.Count];

            for (int i = 0; i < ProjectInfDetails.Length; i++)
            {
                ProjectInfDetails[i] = new Master_ProjectInformation();
                ProjectInfDetails[i].ID = (int)dt.Rows[i]["ID"];
                ProjectInfDetails[i].ProjectName = (String)dt.Rows[i]["ProjectName"];
                ProjectInfDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return ProjectInfDetails;
        }

        public Master_ProjectInformation[] GetAllActiveProjectInfo()
        {
            const String Qry = "SELECT * FROM Master_ProjectInformation WHERE IsActive=1 ORDER BY ProjectName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_ProjectInformation[] ProjectInfDetails = new Master_ProjectInformation[dt.Rows.Count];

            for (int i = 0; i < ProjectInfDetails.Length; i++)
            {
                ProjectInfDetails[i] = new Master_ProjectInformation();
                ProjectInfDetails[i].ID = (int)dt.Rows[i]["ID"];
                ProjectInfDetails[i].ProjectName = (String)dt.Rows[i]["ProjectName"];
                ProjectInfDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return ProjectInfDetails;
        }

        public Master_ProjectInformation[] GetAllProjectInfoDetails()
        {
            const String Qry = "SELECT * FROM Master_ProjectInformation ORDER BY ProjectName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_ProjectInformation[] ProjectInfDetails = new Master_ProjectInformation[dt.Rows.Count];

            for (int i = 0; i < ProjectInfDetails.Length; i++)
            {
                ProjectInfDetails[i] = new Master_ProjectInformation();
                ProjectInfDetails[i].ID = (int)dt.Rows[i]["ID"];
                ProjectInfDetails[i].CompanyID = (int)dt.Rows[i]["CompanyID"];
                ProjectInfDetails[i].ProjectGroup = (String)dt.Rows[i]["ProjectGroup"];
                ProjectInfDetails[i].ProjectType = (String)dt.Rows[i]["ProjectType"];
                ProjectInfDetails[i].ProjectCode = (String)dt.Rows[i]["ProjectCode"];
                ProjectInfDetails[i].Address = (String)dt.Rows[i]["Address"];
                ProjectInfDetails[i].checkcontractown = (String)dt.Rows[i]["checkcontractown"];
                ProjectInfDetails[i].ProjectName = (String)dt.Rows[i]["ProjectName"];
                ProjectInfDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return ProjectInfDetails;
        }

        public Master_ProjectInformation[] GetProjectInfo(String Filter)
        {
            const String Qry = " SELECT * FROM Master_ProjectInformation WHERE IsActive=1 ORDER BY ProjectName";

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

            Master_ProjectInformation[] InvestmentGroup = new Master_ProjectInformation[dt.Rows.Count];

            for (int i = 0; i < InvestmentGroup.Length; i++)
            {
                InvestmentGroup[i] = new Master_ProjectInformation();
                InvestmentGroup[i].ID = (int)dt.Rows[i]["ID"];
                InvestmentGroup[i].ProjectName = (String)dt.Rows[i]["ProjectName"];
                InvestmentGroup[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return InvestmentGroup;
        }


        public bool IsProjectInfoGroupExists(String ProjectName, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_ProjectInformation WHERE ProjectName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ProjectName, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public ComboBoxValues[] GetProjrctCombo()
        {
            String Query = "SELECT ID,ProjectName FROM Master_ProjectInformation Where IsActive = 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["ProjectName"];
            }
            return DTO;
        }


    }
}
