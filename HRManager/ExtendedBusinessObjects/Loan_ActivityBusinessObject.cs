using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Loan_ActivityBusinessObject
    {
        
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public LoanActivity[] GetRequestedLoanForMD()
        {
            const String Qry =  "SELECT " +
                                " 	LA.ID,LA.LoanRequestID,MC.Firstname+' '+isnull(MC.Lastname,'') EmpName,ME.EmpCode,HD.DepartmentName , " +
                                "  	ML.LoanName,LR.LoanAmount,LR.Interest,LR.RepaymentMonths,LA.Status, " +
                                "   LR.MaxAmount,LR.ActualRepaymentMonth,LR.Reason,LR.Interest,isnull([dbo].[GetPreviousLoanComment](LR.ID),'') preComment " +

                                " FROM " +
                                " 	Loan_Activity LA " +
                                " INNER JOIN " +
                                "	Loan_Request LR ON (LR.ID=LA.LoanRequestID) " +
                                " INNER JOIN " +
                                "	Master_Employees ME ON (LR.EmpID=ME.ID) " +
                                " INNER JOIN " +
                                " 	Master_Candidate MC ON (ME.CandidateID=MC.ID) " +
                                " INNER JOIN " +
                                "	Hr_Department HD ON (HD.ID=ME.DepartmentID) " +
                                " INNER JOIN " +
                                "	Master_Loan ML ON (ML.ID=LR.loanid) " +
                                " WHERE " +
                                "	LA.ActivityDate = (SELECT  MAX(activitydate) FROM loan_activity WHERE loanrequestid=LA.LoanRequestID) " +
                                " AND " +
                                " 	 LA.Status ='MDA' ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            LoanActivity[] LoanDetails = new LoanActivity[dt.Rows.Count];
           
            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new LoanActivity();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["LoanRequestID"].ToString() != string.Empty)
                LoanDetails[i].LoanRequestID = (int)dt.Rows[i]["LoanRequestID"];
                if (dt.Rows[i]["EmpName"].ToString() != string.Empty)
                LoanDetails[i].EmpName = (String)dt.Rows[i]["EmpName"];
                if (dt.Rows[i]["EmpCode"].ToString() != string.Empty)
                LoanDetails[i].EmpCode = (String)dt.Rows[i]["EmpCode"];
                if (dt.Rows[i]["DepartmentName"].ToString() != string.Empty)
                LoanDetails[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                if (dt.Rows[i]["LoanName"].ToString() != string.Empty)
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                if (dt.Rows[i]["LoanAmount"].ToString() != string.Empty)
                LoanDetails[i].LoanAmount = (Double)dt.Rows[i]["LoanAmount"];
                if (dt.Rows[i]["RepaymentMonths"].ToString() != string.Empty)
                LoanDetails[i].RepaymentMonths = Convert.ToInt32(dt.Rows[i]["RepaymentMonths"]);
                if (dt.Rows[i]["Status"].ToString() != string.Empty)
                LoanDetails[i].Status = (String)dt.Rows[i]["Status"];
                if (dt.Rows[i]["MaxAmount"].ToString() != string.Empty)
                LoanDetails[i].MaxAmount = (Double)dt.Rows[i]["MaxAmount"];
                if (dt.Rows[i]["ActualRepaymentMonth"].ToString() != string.Empty)
                LoanDetails[i].ActualRepaymentMonth = Convert.ToInt32(dt.Rows[i]["ActualRepaymentMonth"]);
                if (dt.Rows[i]["Reason"].ToString() != string.Empty)
                LoanDetails[i].Reason = (String)dt.Rows[i]["Reason"];
                if (dt.Rows[i]["Interest"].ToString() != string.Empty)
                LoanDetails[i].Interest = (Double)dt.Rows[i]["Interest"];
                if (dt.Rows[i]["preComment"].ToString() != string.Empty)
                    LoanDetails[i].preComment = (String)dt.Rows[i]["preComment"];
                
            }

            return LoanDetails;
        }
        
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public LoanActivity[] GetProcessedLoanForCOO()
        {
            const String Qry =  "SELECT  " +
                                " 	LA.ID,LA.LoanRequestID,MC.Firstname+' '+isnull(MC.Lastname,'') EmpName,ME.EmpCode,HD.DepartmentName , " +
                                "  	ML.LoanName,LR.LoanAmount,LR.Interest,LR.RepaymentMonths,LA.Status, " +
                                "   LR.MaxAmount,LR.ActualRepaymentMonth,LR.Reason,LR.Interest,isnull([dbo].[GetPreviousLoanComment](LR.ID),'') preComment, " +
                                " [dbo].[GetCurrentLoanStatus](LR.ID) getLoanStatus " +
                                " FROM " +
                                " 	Loan_Activity LA " +
                                " INNER JOIN " +
                                "	Loan_Request LR ON (LR.ID=LA.LoanRequestID) " +
                                " INNER JOIN " +
                                "	Master_Employees ME ON (LR.EmpID=ME.ID) " +
                                " INNER JOIN " +
                                " 	Master_Candidate MC ON (ME.CandidateID=MC.ID) " +
                                " INNER JOIN " +
                                "	Hr_Department HD ON (HD.ID=ME.DepartmentID) " +
                                " INNER JOIN " +
                                "	Master_Loan ML ON (ML.ID=LR.loanid) " +
                                " WHERE " +
                                "	LA.id in (SELECT  max(id) FROM loan_activity WHERE loanrequestid=LA.LoanRequestID group by loanrequestid) " +
                                " AND " +
                                " 	 LA.Status ='COO' "; 
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            LoanActivity[] LoanDetails = new LoanActivity[dt.Rows.Count];
           
            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new LoanActivity();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["LoanRequestID"].ToString() != string.Empty)
                LoanDetails[i].LoanRequestID = (int)dt.Rows[i]["LoanRequestID"];
                if (dt.Rows[i]["EmpName"].ToString() != string.Empty)
                LoanDetails[i].EmpName = (String)dt.Rows[i]["EmpName"];
                if (dt.Rows[i]["EmpCode"].ToString() != string.Empty)
                LoanDetails[i].EmpCode = (String)dt.Rows[i]["EmpCode"];
                if (dt.Rows[i]["DepartmentName"].ToString() != string.Empty)
                LoanDetails[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                if (dt.Rows[i]["LoanName"].ToString() != string.Empty)
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                if (dt.Rows[i]["LoanAmount"].ToString() != string.Empty)
                LoanDetails[i].LoanAmount = (Double)dt.Rows[i]["LoanAmount"];
                if (dt.Rows[i]["RepaymentMonths"].ToString() != string.Empty)
                LoanDetails[i].RepaymentMonths = Convert.ToInt32(dt.Rows[i]["RepaymentMonths"]);
                if (dt.Rows[i]["Status"].ToString() != string.Empty)
                LoanDetails[i].Status = (String)dt.Rows[i]["Status"];
                if (dt.Rows[i]["MaxAmount"].ToString() != string.Empty)
                LoanDetails[i].MaxAmount = (Double)dt.Rows[i]["MaxAmount"];
                if (dt.Rows[i]["ActualRepaymentMonth"].ToString() != string.Empty)
                LoanDetails[i].ActualRepaymentMonth = Convert.ToInt32(dt.Rows[i]["ActualRepaymentMonth"]);
                if (dt.Rows[i]["Reason"].ToString() != string.Empty)
                LoanDetails[i].Reason = (String)dt.Rows[i]["Reason"];
                if (dt.Rows[i]["Interest"].ToString() != string.Empty)
                LoanDetails[i].Interest = (Double)dt.Rows[i]["Interest"];
                if (dt.Rows[i]["preComment"].ToString() != string.Empty)
                    LoanDetails[i].preComment = (String)dt.Rows[i]["preComment"];
                if (dt.Rows[i]["getLoanStatus"].ToString() != string.Empty)
                    LoanDetails[i].getLoanStatus = (String)dt.Rows[i]["getLoanStatus"];
                
            }

            return LoanDetails;
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public LoanActivity[] GetRequestedLoanForCOO()
        {
            const String Qry = "SELECT " +
                                " 	LA.ID,LA.LoanRequestID,MC.Firstname+' '+isnull(MC.Lastname,'') EmpName,ME.EmpCode,HD.DepartmentName , " +
                                "  	ML.LoanName,LR.LoanAmount,LR.Interest,LR.RepaymentMonths,LA.Status, " +
                                "   LR.MaxAmount,LR.ActualRepaymentMonth,LR.Reason,LR.Interest,isnull([dbo].[GetPreviousLoanComment](LR.ID),'') preComment, " +
                                //" [dbo].[GetCurrentLoanStatus](LR.ID) getLoanStatus " +
                                " 'New' getLoanStatus " +
                                " FROM " +
                                " 	Loan_Activity LA " +
                                " INNER JOIN " +
                                "	Loan_Request LR ON (LR.ID=LA.LoanRequestID) " +
                                " INNER JOIN " +
                                "	Master_Employees ME ON (LR.EmpID=ME.ID) " +
                                " INNER JOIN " +
                                " 	Master_Candidate MC ON (ME.CandidateID=MC.ID) " +
                                " INNER JOIN " +
                                "	Hr_Department HD ON (HD.ID=ME.DepartmentID) " +
                                " INNER JOIN " +
                                "	Master_Loan ML ON (ML.ID=LR.loanid) " +
                                " WHERE " +
                                "	LA.ActivityDate = (SELECT  max(activitydate) FROM loan_activity WHERE loanrequestid=LA.LoanRequestID) " +
                                " AND " +
                                " 	 LA.Status ='COO' ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            LoanActivity[] LoanDetails = new LoanActivity[dt.Rows.Count];
           
            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new LoanActivity();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["LoanRequestID"].ToString() != string.Empty)
                LoanDetails[i].LoanRequestID = (int)dt.Rows[i]["LoanRequestID"];
                if (dt.Rows[i]["EmpName"].ToString() != string.Empty)
                LoanDetails[i].EmpName = (String)dt.Rows[i]["EmpName"];
                if (dt.Rows[i]["EmpCode"].ToString() != string.Empty)
                LoanDetails[i].EmpCode = (String)dt.Rows[i]["EmpCode"];
                if (dt.Rows[i]["DepartmentName"].ToString() != string.Empty)
                LoanDetails[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                if (dt.Rows[i]["LoanName"].ToString() != string.Empty)
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                if (dt.Rows[i]["LoanAmount"].ToString() != string.Empty)
                LoanDetails[i].LoanAmount = (Double)dt.Rows[i]["LoanAmount"];
                if (dt.Rows[i]["RepaymentMonths"].ToString() != string.Empty)
                LoanDetails[i].RepaymentMonths = Convert.ToInt32(dt.Rows[i]["RepaymentMonths"]);
                if (dt.Rows[i]["Status"].ToString() != string.Empty)
                LoanDetails[i].Status = (String)dt.Rows[i]["Status"];
                if (dt.Rows[i]["MaxAmount"].ToString() != string.Empty)
                LoanDetails[i].MaxAmount = (Double)dt.Rows[i]["MaxAmount"];
                if (dt.Rows[i]["ActualRepaymentMonth"].ToString() != string.Empty)
                LoanDetails[i].ActualRepaymentMonth = Convert.ToInt32(dt.Rows[i]["ActualRepaymentMonth"]);
                if (dt.Rows[i]["Reason"].ToString() != string.Empty)
                LoanDetails[i].Reason = (String)dt.Rows[i]["Reason"];
                if (dt.Rows[i]["Interest"].ToString() != string.Empty)
                LoanDetails[i].Interest = (Double)dt.Rows[i]["Interest"];
                if (dt.Rows[i]["preComment"].ToString() != string.Empty)
                    LoanDetails[i].preComment = (String)dt.Rows[i]["preComment"];
                if (dt.Rows[i]["getLoanStatus"].ToString() != string.Empty)
                    LoanDetails[i].getLoanStatus = (String)dt.Rows[i]["getLoanStatus"];
                
            }

            return LoanDetails;
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        /// 
        //kartyek 12.2.2015 for employee requested details via manager login
        public LoanActivity[] GetRequestedLoanDetails(int DeptID)
        {
            const String Qry = " SELECT " +
                                " 	LA.ID,LA.LoanRequestID,MC.Firstname+' '+isnull(MC.Lastname,'') EmpName,MC.EmpCode,HD.TeamName , " +
                                "  	ML.LoanName,LR.LoanAmount,LR.Interest,LR.RepaymentMonths,LA.Status, " +
                                "   LR.MaxAmount,LR.ActualRepaymentMonth,LR.Reason,LR.Interest,isnull([dbo].[GetPreviousLoanComment](LR.ID),'') preComment ," +
                //" [dbo].[GetCurrentLoanStatus](LR.ID) getLoanStatus " +
                //" 'New' getLoanStatus " +
                                " 'getLoanStatus' = CASE WHEN LA.Status = 'RRE' THEN 'Pending For Approval' " +
                                " WHEN LA.Status = 'CLS' THEN 'Disbursed' ELSE 'NEW' END  " +
                                " FROM " +
                                " 	Loan_Activity LA " +
                                " INNER JOIN " +
                                "	Loan_Request LR ON (LR.ID=LA.LoanRequestID) " +
                                " INNER JOIN " +
                                "	Employee_OccupationDetails ME ON (LR.EmpID=ME.ID) " +
                                " INNER JOIN " +
                                " 	Master_Employees MC ON (ME.EmployeeID=MC.ID) " +
                                " INNER JOIN " +
                                "	Master_Team HD ON (HD.ID=ME.TeamID) " +
                                " INNER JOIN " +
                                "	Master_Loan ML ON (ML.ID=LR.loanid) " +
                                " WHERE " +
                                "	LA.ActivityDate = (SELECT  MAX(activitydate) FROM loan_activity WHERE loanrequestid=LA.LoanRequestID) " +
                                " AND " +
                                " 	 LA.Status NOT IN ('CLS','REJ') " +
                                " AND " +
                                " LA.Initiator={0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, DeptID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            LoanActivity[] LoanDetails = new LoanActivity[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new LoanActivity();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["LoanRequestID"].ToString() != string.Empty)
                    LoanDetails[i].LoanRequestID = (int)dt.Rows[i]["LoanRequestID"];
                if (dt.Rows[i]["EmpName"].ToString() != string.Empty)
                    LoanDetails[i].EmpName = (String)dt.Rows[i]["EmpName"];
                if (dt.Rows[i]["EmpCode"].ToString() != string.Empty)
                    LoanDetails[i].EmpCode = (String)dt.Rows[i]["EmpCode"];
                if (dt.Rows[i]["TeamName"].ToString() != string.Empty)
                    LoanDetails[i].DepartmentName = (String)dt.Rows[i]["TeamName"];
                if (dt.Rows[i]["LoanName"].ToString() != string.Empty)
                    LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                if (dt.Rows[i]["LoanAmount"].ToString() != string.Empty)
                    LoanDetails[i].LoanAmount = (Double)dt.Rows[i]["LoanAmount"];
                if (dt.Rows[i]["RepaymentMonths"].ToString() != string.Empty)
                    LoanDetails[i].RepaymentMonths = Convert.ToInt32(dt.Rows[i]["RepaymentMonths"]);
                if (dt.Rows[i]["Status"].ToString() != string.Empty)
                    LoanDetails[i].Status = (String)dt.Rows[i]["Status"];
                if (dt.Rows[i]["MaxAmount"].ToString() != string.Empty)
                    LoanDetails[i].MaxAmount = (Double)dt.Rows[i]["MaxAmount"];
                if (dt.Rows[i]["ActualRepaymentMonth"].ToString() != string.Empty)
                    LoanDetails[i].ActualRepaymentMonth = Convert.ToInt32(dt.Rows[i]["ActualRepaymentMonth"]);
                if (dt.Rows[i]["Reason"].ToString() != string.Empty)
                    LoanDetails[i].Reason = (String)dt.Rows[i]["Reason"];
                if (dt.Rows[i]["Interest"].ToString() != string.Empty)
                    LoanDetails[i].Interest = (Double)dt.Rows[i]["Interest"];
                if (dt.Rows[i]["preComment"].ToString() != string.Empty)
                    LoanDetails[i].preComment = (String)dt.Rows[i]["preComment"];
                if (dt.Rows[i]["getLoanStatus"].ToString() != string.Empty)
                    LoanDetails[i].getLoanStatus = (String)dt.Rows[i]["getLoanStatus"];


            }

            return LoanDetails;
        }



        //kartyek 11.02.2015 newly added employeeID as argument
        public LoanActivity[] GetRequestedLoan(int DeptID)
        {
            const String Qry =  " SELECT " +
                                " 	LA.ID,LA.LoanRequestID,MC.Firstname+' '+isnull(MC.Lastname,'') EmpName,MC.EmpCode,HD.TeamName , " +
                                "  	ML.LoanName,LR.LoanAmount,LR.Interest,LR.RepaymentMonths,LA.Status, " +
                                "   LR.MaxAmount,LR.ActualRepaymentMonth,LR.Reason,LR.Interest,isnull([dbo].[GetPreviousLoanComment](LR.ID),'') preComment ," +
                                //" [dbo].[GetCurrentLoanStatus](LR.ID) getLoanStatus " +
                                //" 'New' getLoanStatus " +
                                " 'getLoanStatus' = CASE WHEN LA.Status = 'RRE' THEN 'Pending For Approval' " +
                                " WHEN LA.Status = 'CLS' THEN 'Disbursed' ELSE 'NEW' END  " +
                                " FROM " +
                                " 	Loan_Activity LA " +
                                " INNER JOIN " +
                                "	Loan_Request LR ON (LR.ID=LA.LoanRequestID) " +
                                " INNER JOIN " +
                                "	Employee_OccupationDetails ME ON (LR.EmpID=ME.ID) " +
                                " INNER JOIN " +
                                " 	Master_Employees MC ON (ME.EmployeeID=MC.ID) " +
                                " INNER JOIN " +
                                "	Master_Team HD ON (HD.ID=ME.TeamID) " +
                                " INNER JOIN " +
                                "	Master_Loan ML ON (ML.ID=LR.loanid) " +
                                " WHERE " +
                                "	LA.ActivityDate = (SELECT  MAX(activitydate) FROM loan_activity WHERE loanrequestid=LA.LoanRequestID) " +
                                " AND " +
                                " 	 LA.Status NOT IN ('CLS','REJ') " +
                                " AND " +            
                                " Receiver={0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, DeptID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            LoanActivity[] LoanDetails = new LoanActivity[dt.Rows.Count];
           
            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new LoanActivity();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["LoanRequestID"].ToString() != string.Empty)
                LoanDetails[i].LoanRequestID = (int)dt.Rows[i]["LoanRequestID"];
                if (dt.Rows[i]["EmpName"].ToString() != string.Empty)
                LoanDetails[i].EmpName = (String)dt.Rows[i]["EmpName"];
                if (dt.Rows[i]["EmpCode"].ToString() != string.Empty)
                LoanDetails[i].EmpCode = (String)dt.Rows[i]["EmpCode"];
                if (dt.Rows[i]["TeamName"].ToString() != string.Empty)
                    LoanDetails[i].DepartmentName = (String)dt.Rows[i]["TeamName"];
                if (dt.Rows[i]["LoanName"].ToString() != string.Empty)
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                if (dt.Rows[i]["LoanAmount"].ToString() != string.Empty)
                LoanDetails[i].LoanAmount = (Double)dt.Rows[i]["LoanAmount"];
                if (dt.Rows[i]["RepaymentMonths"].ToString() != string.Empty)
                LoanDetails[i].RepaymentMonths = Convert.ToInt32(dt.Rows[i]["RepaymentMonths"]);
                if (dt.Rows[i]["Status"].ToString() != string.Empty)
                LoanDetails[i].Status = (String)dt.Rows[i]["Status"];
                if (dt.Rows[i]["MaxAmount"].ToString() != string.Empty)
                LoanDetails[i].MaxAmount = (Double)dt.Rows[i]["MaxAmount"];
                if (dt.Rows[i]["ActualRepaymentMonth"].ToString() != string.Empty)
                LoanDetails[i].ActualRepaymentMonth = Convert.ToInt32(dt.Rows[i]["ActualRepaymentMonth"]);
                if (dt.Rows[i]["Reason"].ToString() != string.Empty)
                LoanDetails[i].Reason = (String)dt.Rows[i]["Reason"];
                if (dt.Rows[i]["Interest"].ToString() != string.Empty)
                LoanDetails[i].Interest = (Double)dt.Rows[i]["Interest"];
                if (dt.Rows[i]["preComment"].ToString() != string.Empty)
                    LoanDetails[i].preComment = (String)dt.Rows[i]["preComment"];
                if (dt.Rows[i]["getLoanStatus"].ToString() != string.Empty)
                    LoanDetails[i].getLoanStatus = (String)dt.Rows[i]["getLoanStatus"];
                
                
            }

            return LoanDetails;
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public LoanActivity[] GetProcessedLoan(int DeptID)
        {
            const String Qry = " SELECT " +
                                " 	LA.ID,LA.LoanRequestID,MC.Firstname+' '+isnull(MC.Lastname,'') EmpName,ME.EmpCode,HD.DepartmentName , " +
                                "  	ML.LoanName,LR.LoanAmount,LR.Interest,LR.RepaymentMonths,LA.Status, " +
                                "   LR.MaxAmount,LR.ActualRepaymentMonth,LR.Reason,LR.Interest,isnull([dbo].[GetPreviousLoanComment](LR.ID),'') preComment ," +
                                " [dbo].[GetCurrentLoanStatus](LR.ID) getLoanStatus " +
                                //" 'New' getLoanStatus " +
                                " FROM " +
                                " 	Loan_Activity LA " +
                                " INNER JOIN " +
                                "	Loan_Request LR ON (LR.ID=LA.LoanRequestID) " +
                                " INNER JOIN " +
                                "	Master_Employees ME ON (LR.EmpID=ME.ID) " +
                                " INNER JOIN " +
                                " 	Master_Candidate MC ON (ME.CandidateID=MC.ID) " +
                                " INNER JOIN " +
                                "	Hr_Department HD ON (HD.ID=ME.DepartmentID) " +
                                " INNER JOIN " +
                                "	Master_Loan ML ON (ML.ID=LR.loanid) " +
                                " WHERE " +
                                "	LA.id in (SELECT  max(id) FROM loan_activity WHERE loanrequestid=LA.LoanRequestID and receiver={0} GROUP BY loanrequestid) " +
                                " AND " +
                                " 	 [dbo].[GetCurrentLoanStatus](LR.ID) NOT IN ('NEW') ";
            
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, DeptID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            LoanActivity[] LoanDetails = new LoanActivity[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new LoanActivity();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["LoanRequestID"].ToString() != string.Empty)
                    LoanDetails[i].LoanRequestID = (int)dt.Rows[i]["LoanRequestID"];
                if (dt.Rows[i]["EmpName"].ToString() != string.Empty)
                    LoanDetails[i].EmpName = (String)dt.Rows[i]["EmpName"];
                if (dt.Rows[i]["EmpCode"].ToString() != string.Empty)
                    LoanDetails[i].EmpCode = (String)dt.Rows[i]["EmpCode"];
                if (dt.Rows[i]["DepartmentName"].ToString() != string.Empty)
                    LoanDetails[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                if (dt.Rows[i]["LoanName"].ToString() != string.Empty)
                    LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                if (dt.Rows[i]["LoanAmount"].ToString() != string.Empty)
                    LoanDetails[i].LoanAmount = (Double)dt.Rows[i]["LoanAmount"];
                if (dt.Rows[i]["RepaymentMonths"].ToString() != string.Empty)
                    LoanDetails[i].RepaymentMonths = Convert.ToInt32(dt.Rows[i]["RepaymentMonths"]);
                if (dt.Rows[i]["Status"].ToString() != string.Empty)
                    LoanDetails[i].Status = (String)dt.Rows[i]["Status"];
                if (dt.Rows[i]["MaxAmount"].ToString() != string.Empty)
                    LoanDetails[i].MaxAmount = (Double)dt.Rows[i]["MaxAmount"];
                if (dt.Rows[i]["ActualRepaymentMonth"].ToString() != string.Empty)
                    LoanDetails[i].ActualRepaymentMonth = Convert.ToInt32(dt.Rows[i]["ActualRepaymentMonth"]);
                if (dt.Rows[i]["Reason"].ToString() != string.Empty)
                    LoanDetails[i].Reason = (String)dt.Rows[i]["Reason"];
                if (dt.Rows[i]["Interest"].ToString() != string.Empty)
                    LoanDetails[i].Interest = (Double)dt.Rows[i]["Interest"];
                if (dt.Rows[i]["preComment"].ToString() != string.Empty)
                    LoanDetails[i].preComment = (String)dt.Rows[i]["preComment"];
                if (dt.Rows[i]["getLoanStatus"].ToString() != string.Empty)
                    LoanDetails[i].getLoanStatus = (String)dt.Rows[i]["getLoanStatus"];


            }

            return LoanDetails;
        }

    }
}
