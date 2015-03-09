using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.DTO;
using HRManager.DTOEXT.Recruitment;
using IRCAKernel;
using HRManager.Entity.EmployeeLeave;
using IRCA.Communication;

namespace HRManager.BusinessObjects
{
    public partial class Appraisal_EmployeeBusinessObject
    {
        public IntimationAppraisalEntity[] GetTeamMemberForAppraisal(int IntimationID, int MangerID)
        {
            String Query = "select row_number() over (order by EOD.EmployeeID) as Sno,isnull(AE.ID,0) ID,isnull(AE.IntimationID,0) IntimationID,EOD.EmployeeID,FirstName+' '+MiddleName+' '+LastName EmployeeName "
            + " ,isnull(Goals,'-') Goals,isnull(Grade,'-') Grade "
            + " ,isnull(GoalOn,'1900-01-01') GoalOn,isnull(GradeOn,'1900-01-01') GradeOn,isnull(PromotionOn,'1900-01-01') PromotionOn,isnull(SalaryHikeOn,'1900-01-01') SalaryHikeOn "
            + " ,isnull(GoalBy,0) GoalBy,isnull(GradeBy,0) GradeBy,isnull(PromotionBy,0) PromotionBy,isnull(SalaryHikeBy,0) SalaryHikeBy "
            + " ,isnull(PromotionTo,0) PromotionTo,isNull(SalaryHikeAmount,'0') SalaryHikeAmount,isnull(Status,'') Status,TeamID,TeamName "
            + " from Employee_OccupationDetails EOD "
            + " inner Join Master_Employees ME On EOD.EmployeeID=ME.ID  "
            + " inner Join Master_Team MT On EOD.TeamID=MT.ID   "
            + " left Join (select * from appraisal_employee where IntimationID={0} ) AE ON AE.EmployeeID= ME.ID "
            + " Inner Join Appraisal_Intimation  AI on AI.ID = {0} "
            + " where ME.IsDeleted =0 and TeamID in ( "
            + " select ID from master_team where ManagerID = {1} "
            + " ) and EOD.IsActive =1 and TypeOfExitID = 0 and (JoiningDate <= GoalIntimationDate or GoalIntimationDate is null)";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query, IntimationID.ToString(), MangerID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);
            IntimationAppraisalEntity[] DTO = new IntimationAppraisalEntity[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new IntimationAppraisalEntity();
                DTO[i].ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                DTO[i].Sno = Convert.ToInt32(dt.Rows[i]["Sno"]);
                DTO[i].IntimationID = IntimationID;
                DTO[i].EmployeeID = Convert.ToInt32(dt.Rows[i]["EmployeeID"]);
                DTO[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                DTO[i].Goals = (String)dt.Rows[i]["Goals"];
                DTO[i].Grade = (String)dt.Rows[i]["Grade"];
                DTO[i].GoalOn = (DateTime)dt.Rows[i]["GoalOn"];
                DTO[i].GradeOn = (DateTime)dt.Rows[i]["GradeOn"];
                DTO[i].PromotionOn = (DateTime)dt.Rows[i]["PromotionOn"];
                DTO[i].SalaryHikeOn = (DateTime)dt.Rows[i]["SalaryHikeOn"];
                DTO[i].GoalBy = Convert.ToInt32(dt.Rows[i]["GoalBy"]);
                DTO[i].GradeBy = Convert.ToInt32(dt.Rows[i]["GradeBy"]);
                DTO[i].PromotionBy = Convert.ToInt32(dt.Rows[i]["PromotionBy"]);
                DTO[i].SalaryHikeBy = Convert.ToInt32(dt.Rows[i]["SalaryHikeBy"]);
                DTO[i].PromotionTo = Convert.ToInt32(dt.Rows[i]["PromotionTo"]);
                DTO[i].SalaryHikeAmount = (String)dt.Rows[i]["SalaryHikeAmount"];
                DTO[i].Status = (String)dt.Rows[i]["Status"];
                DTO[i].TeamID = Convert.ToInt32(dt.Rows[i]["TeamID"]);
                DTO[i].Team = (String)dt.Rows[i]["TeamName"];
            }
            return DTO;
        }

        public IntimationAppraisalEntity[] GetTeamMemberForView(int IntimationID)
        {
            String Query = "select row_number() over (order by EOD.EmployeeID) as Sno,isnull(AE.ID,0) ID,isnull(AE.IntimationID,0) IntimationID,EOD.EmployeeID,FirstName+' '+MiddleName+' '+LastName EmployeeName "
            + " ,isnull(Goals,'-') Goals,isnull(Grade,'-') Grade "
            + " ,isnull(GoalOn,'1900-01-01') GoalOn,isnull(GradeOn,'1900-01-01') GradeOn,isnull(PromotionOn,'1900-01-01') PromotionOn,isnull(SalaryHikeOn,'1900-01-01') SalaryHikeOn "
            + " ,isnull(GoalBy,0) GoalBy,isnull(GradeBy,0) GradeBy,isnull(PromotionBy,0) PromotionBy,isnull(SalaryHikeBy,0) SalaryHikeBy "
            + " ,isnull(PromotionTo,0) PromotionTo,isNull(SalaryHikeAmount,'0') SalaryHikeAmount,isnull(Status,'') Status,TeamID,TeamName "
            + " from Employee_OccupationDetails EOD "
            + " inner Join Master_Employees ME On EOD.EmployeeID=ME.ID  "
            + " inner Join Master_Team MT On EOD.TeamID=MT.ID   "
            + " left Join (select * from appraisal_employee where IntimationID={0} ) AE ON AE.EmployeeID= ME.ID "
            + " inner Join Appraisal_Intimation  AI on AI.ID = {0} "
            + " where ME.IsDeleted =0 and EOD.IsActive =1 and TypeOfExitID = 0 and (JoiningDate <= GoalIntimationDate or GoalIntimationDate is not null)";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query, IntimationID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);
            IntimationAppraisalEntity[] DTO = new IntimationAppraisalEntity[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new IntimationAppraisalEntity();
                DTO[i].ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                DTO[i].Sno = Convert.ToInt32(dt.Rows[i]["Sno"]);
                DTO[i].IntimationID = Convert.ToInt32(dt.Rows[i]["IntimationID"]);
                DTO[i].EmployeeID = Convert.ToInt32(dt.Rows[i]["EmployeeID"]);
                DTO[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                DTO[i].Goals = (String)dt.Rows[i]["Goals"];
                DTO[i].Grade = (String)dt.Rows[i]["Grade"];
                DTO[i].GoalOn = (DateTime)dt.Rows[i]["GoalOn"];
                DTO[i].GradeOn = (DateTime)dt.Rows[i]["GradeOn"];
                DTO[i].PromotionOn = (DateTime)dt.Rows[i]["PromotionOn"];
                DTO[i].SalaryHikeOn = (DateTime)dt.Rows[i]["SalaryHikeOn"];
                DTO[i].GoalBy = Convert.ToInt32(dt.Rows[i]["GoalBy"]);
                DTO[i].GradeBy = Convert.ToInt32(dt.Rows[i]["GradeBy"]);
                DTO[i].PromotionBy = Convert.ToInt32(dt.Rows[i]["PromotionBy"]);
                DTO[i].SalaryHikeBy = Convert.ToInt32(dt.Rows[i]["SalaryHikeBy"]);
                DTO[i].PromotionTo = Convert.ToInt32(dt.Rows[i]["PromotionTo"]);
                DTO[i].SalaryHikeAmount = (String)dt.Rows[i]["SalaryHikeAmount"];
                DTO[i].Status = (String)dt.Rows[i]["Status"];
                DTO[i].TeamID = Convert.ToInt32(dt.Rows[i]["TeamID"]);
                DTO[i].Team = (String)dt.Rows[i]["TeamName"];
            }
            return DTO;
        }
        public Master_Employees[] GetTeamManagers(int IntimationID)
        {
            String Query = "select * from Master_Employees ME "
                         + " Inner Join Employee_OccupationDetails EOD ON EOD.EmployeeID =ME.ID  "
                         + " where ME.id in ( "
                         + " select Distinct  ManagerID from Master_Team MT "
                         + " where ManagerID != 0 ) and ME.IsDeleted =0 and EOD.IsActive=1 and TypeOfExitID = 0 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Employees[] DTO = new Master_Employees[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_Employees();
                DTO[i].ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                DTO[i].FirstName = (String)dt.Rows[i]["FirstName"];
                DTO[i].LastName = (String)dt.Rows[i]["LastName"];
            }
            return DTO;
        }
        public Master_Employees GetHRManager()
        {
            String Query = "select Top 1 * from Master_Employees ME "
                        + " Inner Join Employee_OccupationDetails EOD ON EOD.EmployeeID =ME.ID "
                        + " Inner Join Hr_Designation HD ON HD.ID=EOD.DesignationID "
                        + " Inner JOin Master_Role MR ON MR.ID = HD.RoleID "
                        + " where EOD.isactive=1 and Role='HR'  and ME.IsDeleted =0 and TypeOfExitID = 0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Employees DTO = new Master_Employees();

            //for (int i = 0; i < DTO.Length; i++)
            //{
            //DTO = new Master_Employees();
            if (dt.Rows.Count > 0)
            {
                DTO.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                DTO.PersonalEmailID = (String)dt.Rows[0]["EmailID"];
            }
            else
            {
                DTO = null;
            }
            //}
            return DTO;
        }

        public Master_Employees GetHRManagerComplete()
        {
            String Query = "select Top 1 * from Master_Employees ME "
                        + " Inner Join Employee_OccupationDetails EOD ON EOD.EmployeeID =ME.ID "
                        + " Inner Join Hr_Designation HD ON HD.ID=EOD.DesignationID "
                        + " Inner JOin Master_Role MR ON MR.ID = HD.RoleID "
                        + " where EOD.isactive=1 and Role='HR'  and ME.IsDeleted =0 and TypeOfExitID = 0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Employees DTO = new Master_Employees();

            if (dt.Rows.Count > 0)
            {
                DTO.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                DTO.PersonalEmailID = (String)dt.Rows[0]["EmailID"];
                DTO.FirstName = (String)dt.Rows[0]["FirstName"];
                DTO.MiddleName = (String)dt.Rows[0]["MiddleName"];
                DTO.LastName = (String)dt.Rows[0]["LastName"];
            }
            else
            {
                DTO = null;
            }
            return DTO;
        }

        public String GetTeams(int ID)
        {
            String Query = "select TeamName from Master_Team Where ManagerID={0} and IsActive=1 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query, ID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);
            String DTO = String.Empty;

            for (int i = 0; i < DTO.Length; i++)
            {
                //DTO = new Master_Employees();
                if (i == 0)
                {
                    DTO = (String)dt.Rows[i]["TeamName"];
                }
                else
                {
                    DTO = DTO + "," + (String)dt.Rows[i]["TeamName"];
                }
            }
            return DTO;
        }
        public IntimationAppraisalEntity[] GetAllTeamMemberForAppraisal(int IntimationID)
        {
            String Query = "select row_number() over (order by EOD.EmployeeID) as Sno,isnull(AE.ID,0) ID,isnull(AE.IntimationID,0) IntimationID,EOD.EmployeeID,FirstName+' '+MiddleName+' '+LastName EmployeeName "
            + " ,isnull(Goals,'-') Goals,isnull(Grade,'-') Grade "
            + " ,isnull(GoalOn,'1900-01-01') GoalOn,isnull(GradeOn,'1900-01-01') GradeOn,isnull(PromotionOn,'1900-01-01') PromotionOn,isnull(SalaryHikeOn,'1900-01-01') SalaryHikeOn "
            + " ,isnull(GoalBy,0) GoalBy,isnull(GradeBy,0) GradeBy,isnull(PromotionBy,0) PromotionBy,isnull(SalaryHikeBy,0) SalaryHikeBy "
            + " ,isnull(PromotionTo,0) PromotionTo,isNull(SalaryHikeAmount,'0') SalaryHikeAmount "
            + " from Employee_OccupationDetails EOD "
            + " inner Join Master_Employees ME On EOD.EmployeeID=ME.ID  "
            + " inner Join (select * from appraisal_employee where IntimationID={0} ) AE ON AE.EmployeeID= ME.ID "
            + " left Join Appraisal_Intimation  AI on AI.ID = AE.IntimationID "
            + " where ME.IsDeleted =0 and EOD.IsActive =1 and AE.Grade != '' and AE.Grade is not null and TypeOfExitID = 0 and (JoiningDate <= GoalIntimationDate or GoalIntimationDate is not null)";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query, IntimationID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);
            IntimationAppraisalEntity[] DTO = new IntimationAppraisalEntity[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new IntimationAppraisalEntity();
                DTO[i].ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                DTO[i].Sno = Convert.ToInt32(dt.Rows[i]["Sno"]);
                DTO[i].IntimationID = Convert.ToInt32(dt.Rows[i]["IntimationID"]);
                DTO[i].EmployeeID = Convert.ToInt32(dt.Rows[i]["EmployeeID"]);
                DTO[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                DTO[i].Goals = (String)dt.Rows[i]["Goals"];
                DTO[i].Grade = (String)dt.Rows[i]["Grade"];
                DTO[i].GoalOn = (DateTime)dt.Rows[i]["GoalOn"];
                DTO[i].GradeOn = (DateTime)dt.Rows[i]["GradeOn"];
                DTO[i].PromotionOn = (DateTime)dt.Rows[i]["PromotionOn"];
                DTO[i].SalaryHikeOn = (DateTime)dt.Rows[i]["SalaryHikeOn"];
                DTO[i].GoalBy = Convert.ToInt32(dt.Rows[i]["GoalBy"]);
                DTO[i].GradeBy = Convert.ToInt32(dt.Rows[i]["GradeBy"]);
                DTO[i].PromotionBy = Convert.ToInt32(dt.Rows[i]["PromotionBy"]);
                DTO[i].SalaryHikeBy = Convert.ToInt32(dt.Rows[i]["SalaryHikeBy"]);
                DTO[i].PromotionTo = Convert.ToInt32(dt.Rows[i]["PromotionTo"]);
                DTO[i].SalaryHikeAmount = (String)dt.Rows[i]["SalaryHikeAmount"];
            }
            return DTO;
        }

        public AppraisalEntity[] GetAllTeamMemberForRating(int IntimationID)
        {
            String Query = "select row_number() over (order by EOD.EmployeeID) as Sno,isnull(AE.ID,0) ID,isnull(AE.IntimationID,0) IntimationID,EOD.EmployeeID,FirstName+' '+MiddleName+' '+LastName EmployeeName "
            + " ,isnull(Goals,'-') Goals,isnull(Grade,'-') Grade "
            + " ,isnull(GoalOn,'1900-01-01') GoalOn,isnull(GradeOn,'1900-01-01') GradeOn,isnull(PromotionOn,'1900-01-01') PromotionOn,isnull(SalaryHikeOn,'1900-01-01') SalaryHikeOn "
            + " ,isnull(GoalBy,0) GoalBy,isnull(GradeBy,0) GradeBy,isnull(PromotionBy,0) PromotionBy,isnull(SalaryHikeBy,0) SalaryHikeBy "
            + " ,isnull(PromotionTo,0) PromotionTo,isNull(SalaryHikeAmount,'0') SalaryHikeAmount,HD.Designation ,CTC,isnull(HikePer,0) HikePer,isnull(HDN.Designation,'') NewDesignation,TeamID,TeamName,isnull(OldDesignation,0) OldDesignation,isnull(OldSalary,0) OldSalary  "
            + " from Employee_OccupationDetails EOD "
            + " inner Join Master_Employees ME On EOD.EmployeeID=ME.ID  "
            + " inner Join (select * from appraisal_employee where IntimationID={0} ) AE ON AE.EmployeeID= ME.ID "
            + " left Join Appraisal_Intimation  AI on AI.ID = AE.IntimationID "
            + " left Join HR_Designation HD On HD.ID = EOD.DesignationID "
            + " inner Join Master_Team MT On EOD.TeamID=MT.ID   "
            + " left Join HR_Designation HDN On HDN.ID = AE.PromotionTo "
            + " left Join Employee_Salary ES On ES.EmployeeID = ME.ID   "
            + " where ME.IsDeleted =0 and EOD.IsActive =1 and AE.Grade != '' and AE.Grade is not null  and (JoiningDate <= GoalIntimationDate or GoalIntimationDate is not null) and ES.Isactive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query, IntimationID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);
            AppraisalEntity[] DTO = new AppraisalEntity[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new AppraisalEntity();
                DTO[i].ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                DTO[i].Sno = Convert.ToInt32(dt.Rows[i]["Sno"]);
                DTO[i].IntimationID = IntimationID;// Convert.ToInt32(dt.Rows[i]["IntimationID"]);
                DTO[i].EmployeeID = Convert.ToInt32(dt.Rows[i]["EmployeeID"]);
                DTO[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                DTO[i].Goals = (String)dt.Rows[i]["Goals"];
                DTO[i].Grade = (String)dt.Rows[i]["Grade"];
                DTO[i].GoalOn = (DateTime)dt.Rows[i]["GoalOn"];
                DTO[i].GradeOn = (DateTime)dt.Rows[i]["GradeOn"];
                DTO[i].PromotionOn = (DateTime)dt.Rows[i]["PromotionOn"];
                DTO[i].SalaryHikeOn = (DateTime)dt.Rows[i]["SalaryHikeOn"];
                DTO[i].GoalBy = Convert.ToInt32(dt.Rows[i]["GoalBy"]);
                DTO[i].GradeBy = Convert.ToInt32(dt.Rows[i]["GradeBy"]);
                DTO[i].PromotionBy = Convert.ToInt32(dt.Rows[i]["PromotionBy"]);
                DTO[i].SalaryHikeBy = Convert.ToInt32(dt.Rows[i]["SalaryHikeBy"]);
                DTO[i].PromotionTo = Convert.ToInt32(dt.Rows[i]["PromotionTo"]);
                DTO[i].SalaryHikeAmount = (String)dt.Rows[i]["SalaryHikeAmount"];
                DTO[i].OldDesignation = dt.Rows[i]["Designation"].ToString();
                DTO[i].OldSalary = dt.Rows[i]["CTC"].ToString();
                DTO[i].HikePer = Convert.ToDouble(dt.Rows[i]["HikePer"]);
                DTO[i].NewDesignation = dt.Rows[i]["NewDesignation"].ToString();
                DTO[i].TeamID = Convert.ToInt32(dt.Rows[i]["TeamID"]);
                DTO[i].Team = (String)dt.Rows[i]["TeamName"];
                DTO[i].PreDesignation = dt.Rows[i]["OldDesignation"].ToString();
                DTO[i].PreSalary = dt.Rows[i]["OldSalary"].ToString();

            }
            return DTO;
        }

        public AppraisalEntity[] GetAllTeamMemberForRatingView(int IntimationID)
        {
            String Query = "select row_number() over (order by EOD.EmployeeID) as Sno,isnull(AE.ID,0) ID,isnull(AE.IntimationID,0) IntimationID,EOD.EmployeeID,FirstName+' '+MiddleName+' '+LastName EmployeeName "
            + " ,isnull(Goals,'-') Goals,isnull(Grade,'-') Grade "
            + " ,isnull(GoalOn,'1900-01-01') GoalOn,isnull(GradeOn,'1900-01-01') GradeOn,isnull(PromotionOn,'1900-01-01') PromotionOn,isnull(SalaryHikeOn,'1900-01-01') SalaryHikeOn "
            + " ,isnull(GoalBy,0) GoalBy,isnull(GradeBy,0) GradeBy,isnull(PromotionBy,0) PromotionBy,isnull(SalaryHikeBy,0) SalaryHikeBy "
            + " ,isnull(PromotionTo,0) PromotionTo,isNull(SalaryHikeAmount,'0') SalaryHikeAmount,HD.Designation ,isnull(CTC,0) CTC,isnull(HikePer,0) HikePer,isnull(HDN.Designation,'') NewDesignation,TeamID,TeamName,isnull(OldDesignation,0) OldDesignation,isnull(OldSalary,0) OldSalary  "
            + " from Employee_OccupationDetails EOD "
            + " left Join Master_Employees ME On EOD.EmployeeID=ME.ID  "
            + " left Join (select * from appraisal_employee where IntimationID={0} ) AE ON AE.EmployeeID= ME.ID "
            + " left Join Appraisal_Intimation  AI on AI.ID = AE.IntimationID "
            + " left Join HR_Designation HD On HD.ID = EOD.DesignationID "
            + " inner Join Master_Team MT On EOD.TeamID=MT.ID   "
            + " left Join HR_Designation HDN On HDN.ID = AE.PromotionTo "
            + " left Join Employee_Salary ES On ES.EmployeeID = ME.ID   "
            + " where ME.IsDeleted =0 and EOD.IsActive =1  and TypeOfExitID = 0 and ES.Isactive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query, IntimationID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);
            AppraisalEntity[] DTO = new AppraisalEntity[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new AppraisalEntity();
                DTO[i].ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                DTO[i].Sno = Convert.ToInt32(dt.Rows[i]["Sno"]);
                DTO[i].IntimationID = IntimationID;// Convert.ToInt32(dt.Rows[i]["IntimationID"]);
                DTO[i].EmployeeID = Convert.ToInt32(dt.Rows[i]["EmployeeID"]);
                DTO[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                DTO[i].Goals = (String)dt.Rows[i]["Goals"];
                DTO[i].Grade = (String)dt.Rows[i]["Grade"];
                DTO[i].GoalOn = (DateTime)dt.Rows[i]["GoalOn"];
                DTO[i].GradeOn = (DateTime)dt.Rows[i]["GradeOn"];
                DTO[i].PromotionOn = (DateTime)dt.Rows[i]["PromotionOn"];
                DTO[i].SalaryHikeOn = (DateTime)dt.Rows[i]["SalaryHikeOn"];
                DTO[i].GoalBy = Convert.ToInt32(dt.Rows[i]["GoalBy"]);
                DTO[i].GradeBy = Convert.ToInt32(dt.Rows[i]["GradeBy"]);
                DTO[i].PromotionBy = Convert.ToInt32(dt.Rows[i]["PromotionBy"]);
                DTO[i].SalaryHikeBy = Convert.ToInt32(dt.Rows[i]["SalaryHikeBy"]);
                DTO[i].PromotionTo = Convert.ToInt32(dt.Rows[i]["PromotionTo"]);
                DTO[i].SalaryHikeAmount = (String)dt.Rows[i]["SalaryHikeAmount"];
                if (dt.Rows[i]["Designation"].ToString() == String.Empty)
                {
                    DTO[i].OldDesignation = "0";
                }
                else
                {
                    DTO[i].OldDesignation = (String)dt.Rows[i]["Designation"];
                }
                //DTO[i].OldSalary = dt.Rows[i]["CTC"].ToString();
                if (dt.Rows[i]["CTC"].ToString() == String.Empty)
                {
                    DTO[i].OldSalary = "0";
                }
                else
                {
                    DTO[i].OldSalary = dt.Rows[i]["CTC"].ToString();
                }
                DTO[i].HikePer = Convert.ToDouble(dt.Rows[i]["HikePer"]);
                DTO[i].NewDesignation = dt.Rows[i]["NewDesignation"].ToString();
                DTO[i].TeamID = Convert.ToInt32(dt.Rows[i]["TeamID"]);
                DTO[i].Team = (String)dt.Rows[i]["TeamName"];
                DTO[i].PreDesignation = (String)dt.Rows[i]["OldDesignation"];
                DTO[i].PreSalary = (String)dt.Rows[i]["OldSalary"];

            }
            return DTO;
        }
        public Appraisal_Employee GetAppraisalEmpID(int IntimationID, int EmployeeID)
        {
            String Query = "Select Top 1 * from Appraisal_Employee Where IntimationID ={0} and EmployeeID ={1} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Query, IntimationID.ToString(), EmployeeID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);
            Appraisal_Employee[] DTO = new Appraisal_Employee[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Appraisal_Employee();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].IntimationID = (int)dt.Rows[i]["IntimationID"];
                DTO[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                DTO[i].Goals = (String)dt.Rows[i]["Goals"];
                DTO[i].Grade = (String)dt.Rows[i]["Grade"];
                DTO[i].GoalOn = (DateTime)dt.Rows[i]["GoalOn"];
                DTO[i].GradeOn = (DateTime)dt.Rows[i]["GradeOn"];
                DTO[i].PromotionOn = (DateTime)dt.Rows[i]["PromotionOn"];
                DTO[i].SalaryHikeOn = (DateTime)dt.Rows[i]["SalaryHikeOn"];
                DTO[i].GoalBy = (int)dt.Rows[i]["GoalBy"];
                DTO[i].GradeBy = (int)dt.Rows[i]["GradeBy"];
                DTO[i].PromotionBy = (int)dt.Rows[i]["PromotionBy"];
                DTO[i].SalaryHikeBy = (int)dt.Rows[i]["SalaryHikeBy"];
                DTO[i].PromotionTo = (int)dt.Rows[i]["PromotionTo"];
                DTO[i].SalaryHikeAmount = (String)dt.Rows[i]["SalaryHikeAmount"];
            }
            return DTO[0];
        }

        public void InactiveEmployeeDesgnation(int EmployeeID)
        {
            try
            {
                String Query = "Update Employee_OccupationDetails set Isactive=0 Where EmployeeID= {0}";

                ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
                ExecutionQuery exQry = new ExecutionQuery();

                exQry.Query = String.Format(Query, EmployeeID.ToString());

                int noOfRows = EE.ExecuteNonQuery(exQry);
                //return noOfRows;
            }
            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                //return 0;
            }
        }

        public void InactiveEmployeeSalary(int EmployeeID)
        {
            try
            {
                String Query = "Update Employee_Salary set Isactive=0 Where EmployeeID= {0}";

                ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
                ExecutionQuery exQry = new ExecutionQuery();

                exQry.Query = String.Format(Query, EmployeeID.ToString());

                int noOfRows = EE.ExecuteNonQuery(exQry);
                //return noOfRows;
            }
            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                //return 0;
            }
        }
        public bool CheckAllAppraisalDocSubmitted(int IntimationID, int TeamID, String Type)
        {
            String Qry = String.Empty;
            if (Type == "Goal")
            {
                Qry = " IF EXISTS (   select JoiningDate,* from Employee_OccupationDetails  EOD  "
 + " Inner Join Master_Employees ME On EOD.EmployeeID = ME.ID  "
 + " left Join Appraisal_Employee AE On EOD.EmployeeID = AE.EmployeeID  and AE.IntimationID = {0}"
 + " where ME.IsDeleted =0 and TeamID ={1} and EOD.IsActive=1 and TypeOfExitID = 0   "
 + " and JoiningDate <= (select GoalIntimationDate from Appraisal_Intimation where ID = {0}) "
 + " and Intimationid is null) "
                                    + " SELECT 0"
                                    + " ELSE"
                                    + " SELECT 1";
            }
            else
            {
                Qry = " IF EXISTS (   select JoiningDate,* from Employee_OccupationDetails  EOD  "
+ " Inner Join Master_Employees ME On EOD.EmployeeID = ME.ID  "
+ " left Join Appraisal_Employee AE On EOD.EmployeeID = AE.EmployeeID  and AE.IntimationID = {0} "
+ " where ME.IsDeleted =0 and TeamID ={1} and EOD.IsActive=1 and TypeOfExitID = 0  "
+ " and JoiningDate <= (select GoalIntimationDate from Appraisal_Intimation where ID = {0}) "
+ " and Intimationid is not null and Grade='') "
                                   + " SELECT 0"
                                   + " ELSE"
                                   + " SELECT 1";
            }

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, IntimationID.ToString(), TeamID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public bool CheckAnyAppraisalDocSubmitted(int IntimationID)
        {
            String Qry = String.Empty;

            Qry = " IF EXISTS (select * from Appraisal_Employee where IntimationID={0}) "
                                    + " SELECT 0"
                                    + " ELSE"
                                    + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, IntimationID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public void UpdateAppraisalStatus(String Status, int IntimationID, int TeamID)
        {
            try
            {
                String Query = "Update appraisal_employee set Status='{0}' where ID in ( "
                            + " select id from appraisal_employee where IntimationID = {1} and EmployeeID in ( "
                            + " select EmployeeID from Employee_OccupationDetails x"
                            + " Inner Join Master_Employees y ON x.EmployeeID =y.ID"
                            + " where TeamID={2} and x.IsActive =1 and y.IsDeleted=0))";

                ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
                ExecutionQuery exQry = new ExecutionQuery();

                exQry.Query = String.Format(Query, Status, IntimationID.ToString(), TeamID.ToString());

                int noOfRows = EE.ExecuteNonQuery(exQry);
                //return noOfRows;
            }
            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                //return 0;
            }
        }
        public ComboBoxValues[] GetDesignationCombo()
        {
            String Query = "SELECT ID,Designation FROM HR_Designation Where IsActive = 1 and RoleID != 0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["Designation"];
            }
            return DTO;
        }

        public ComboBoxValues[] IntimateDateCombo()
        {
            String Query = "SELECT ID,Convert(varchar(4),(datepart(year,GoalIntimationDate))) + '-'+ Convert(varchar(4),(datepart(year,GoalIntimationDate)+1)) GoalIntimationDate FROM Appraisal_Intimation order by ID desc";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["GoalIntimationDate"];
            }
            return DTO;
        }
    }
}
