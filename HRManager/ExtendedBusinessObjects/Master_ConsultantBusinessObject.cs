using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.BusinessObjects;
using HRManager.DTO;
using System.Data;
using HRManager.Entity;
using HRManager.DTOEXT;

namespace HRManager.BusinessObjects
{
    public partial class Master_ConsultantBusinessObject
    {
    
        public Master_Consultant GetConsultantByConsultant(String Consultant)
        {
            Master_Consultant[] Consultants = GetConsultant(" Consultant = '" + Consultant + "'");

            if (Consultants != null && Consultants.Length > 0)
            {
                return Consultants[0];
            }
            else
            {
                return null;
            }
        }
        
        public Master_Consultant[] GetConsultant(String Filter)
        {
            const String Qry = " SELECT * FROM Master_Consultant";

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

            Master_Consultant[] DTO = new Master_Consultant[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_Consultant();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                DTO[i].ConsultantName = (String)dt.Rows[i]["ConsultantName"];
                DTO[i].ContactPerson = (String)dt.Rows[i]["ContactPerson"];
                DTO[i].TelephoneNo = (String)dt.Rows[i]["TelephoneNo"];
                DTO[i].EmailID = (String)dt.Rows[i]["EmailID"];
                DTO[i].Address = (String)dt.Rows[i]["Address"];            
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return DTO;
        }
        public Master_ConsultantEXT[] GetAllInActiveConsultant()
        {
            const String Qry = "SELECT DISTINCT"
                                  + " 	ISNULL(LoginName,'')LoginName,MC.*"
                                  + " FROM"
                                  + " 	Master_Consultant MC"
                                  + " LEFT JOIN "
                                  + " 	Common_User CU"
                                  + " ON"
                                  + " 	CU.EmployeeID=MC.ID AND LoginType='CNT'  WHERE MC.IsActive=0 ORDER BY MC.ID";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_ConsultantEXT[] DTO = new Master_ConsultantEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_ConsultantEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                DTO[i].ConsultantName = (String)dt.Rows[i]["ConsultantName"];
                DTO[i].ContactPerson = (String)dt.Rows[i]["ContactPerson"];
                DTO[i].TelephoneNo = (String)dt.Rows[i]["TelephoneNo"];
                DTO[i].EmailID = (String)dt.Rows[i]["EmailID"];
                DTO[i].Address = (String)dt.Rows[i]["Address"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].LoginName = (String)dt.Rows[i]["LoginName"];   
            
            }

            return DTO;
        }

        public ConsultantEntity[] GetAllActiveConsultants()
        {
            const String Qry = "SELECT * FROM Master_Consultant WHERE IsActive=1 order by ltrim(ConsultantName) asc";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            ConsultantEntity[] DTO = new ConsultantEntity[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ConsultantEntity();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                DTO[i].ConsultantName = (String)dt.Rows[i]["ConsultantName"];
                DTO[i].ContactPerson = (String)dt.Rows[i]["ContactPerson"];
                DTO[i].TelephoneNo = (String)dt.Rows[i]["TelephoneNo"];
                DTO[i].EmailID = (String)dt.Rows[i]["EmailID"];
                DTO[i].Address = (String)dt.Rows[i]["Address"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];         
            }

            return DTO;
        }

        public Master_ConsultantEXT[] GetAllConsultants()
        {
            const String Qry = " SELECT DISTINCT"
                                  + " 	ISNULL(LoginName,'')LoginName,MC.*"
                                  + " FROM"
                                  + " 	Master_Consultant MC"
                                  + " LEFT JOIN "
                                  + " 	Common_User CU"
                                  + " ON"
                                  + " 	CU.EmployeeID=MC.ID AND LoginType='CNT' WHERE MC.IsActive=1 ORDER BY MC.ID";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_ConsultantEXT[] DTO = new Master_ConsultantEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_ConsultantEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                DTO[i].ConsultantName = (String)dt.Rows[i]["ConsultantName"];
                DTO[i].ContactPerson = (String)dt.Rows[i]["ContactPerson"];
                DTO[i].TelephoneNo = (String)dt.Rows[i]["TelephoneNo"];
                DTO[i].EmailID = (String)dt.Rows[i]["EmailID"];
                DTO[i].Address = (String)dt.Rows[i]["Address"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].LoginName = (String)dt.Rows[i]["LoginName"];   
            }

            return DTO;
        }

        public Master_Consultant[] GetAllInActiveConsultantsOrderByConsultant()
        {
            Master_Consultant[] Consultant = GetAllInActiveConsultant();

            if (Consultant != null && Consultant.Length >= 0)
            {
                return Consultant;
            }
            else
            {
                return null;
            }
        }

        public bool IsConsultantExists(String ConsultantName, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Consultant WHERE ConsultantName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ConsultantName, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public bool IsConsultantEmailIDExists(String EmailID, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Consultant WHERE EmailID = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmailID, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public bool IsConsultantTeliPhonenoExists(String TelephoneNo, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Consultant WHERE TelephoneNo = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, TelephoneNo, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public bool IConsultantReferedinCandidate(int ID)
        {
            const String Qry = " IF EXISTS ("
                                 + "	SELECT "
                                 + "	* "
                                 + "	FROM "
                                 + "		Master_Candidate  MC "
                                 + "	INNER JOIN"
                                 + "		Common_User CU "
                                 + "	ON"
                                 + "		CU.ID = MC.CreatedBy "
                                 + "	WHERE "
                                 + "		CU.EmployeeID = {0} AND CU.LoginType = 'CNT' AND MC.RecruitmentType = 'CNT' "
                                 + " ) SELECT 0 ELSE SELECT 1 ";                                
            
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ID);
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public Master_ConsultantEXT[] GetAllConsultantDetails()
        {
            const String Qry = " SELECT DISTINCT"  
                                  + " 	ISNULL(LoginName,'')LoginName,MC.*"  
                                  + " FROM"  
                                  + " 	Master_Consultant MC"  
                                  + " LEFT JOIN "  
                                  + " 	Common_User CU"  
                                  + " ON"
                                  + " 	CU.EmployeeID=MC.ID AND LoginType='CNT' ORDER BY MC.ID";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery {Query = string.Format(Qry)};
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_ConsultantEXT[] DTO = new Master_ConsultantEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_ConsultantEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                DTO[i].ConsultantName = (String)dt.Rows[i]["ConsultantName"];
                DTO[i].ContactPerson = (String)dt.Rows[i]["ContactPerson"];
                DTO[i].TelephoneNo = (String)dt.Rows[i]["TelephoneNo"];
                DTO[i].EmailID = (String)dt.Rows[i]["EmailID"];
                DTO[i].Address = (String)dt.Rows[i]["Address"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].LoginName = (String)dt.Rows[i]["LoginName"];
            }

            return DTO;
        }
    }
}
