using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
    public partial class Master_LoanBusinessObject
    {
        /// <summary>
        /// Get Grade By Grade Name
        /// </summary>
        /// <param name="GradeName">field contaions Grade Name</param>
        /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
        public Master_Loan GetLoanByLoan(String LoanName)
        {
            Master_Loan[] Loan = GetLoans(" LoanName = '" + LoanName + "'");

            if (Loan != null && Loan.Length > 0)
            {
                return Loan[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Loan[] GetAllLoans()
        {
            const String Qry = " SELECT * FROM Master_Loan WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Loan[] LoanDetails = new Master_Loan[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new Master_Loan();
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                LoanDetails[i].MaxAmount = (Double)dt.Rows[i]["MaxAmount"];
                LoanDetails[i].Interest = (Double)dt.Rows[i]["Interest"];
                LoanDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                LoanDetails[i].MaxBasicPercentage = (Double)dt.Rows[i]["MaxBasicPercentage"];
                LoanDetails[i].MinServicePeriod = (int)dt.Rows[i]["MinServicePeriod"];
                LoanDetails[i].MinLeaveBalance = (int)dt.Rows[i]["MinLeaveBalance"];
                LoanDetails[i].RemainingService = (int)dt.Rows[i]["RemainingService"];
                LoanDetails[i].Installment = (String)dt.Rows[i]["Installment"];
            }

            return LoanDetails;
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Loan[] GetLoansForTxt(int LoanID)
        {
            const String Qry = " SELECT * FROM Master_Loan WHERE id={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LoanID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Loan[] LoanDetails = new Master_Loan[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new Master_Loan();
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                LoanDetails[i].MaxAmount = (Double)dt.Rows[i]["MaxAmount"];
                LoanDetails[i].Interest = (Double)dt.Rows[i]["Interest"];
                LoanDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                LoanDetails[i].MaxBasicPercentage = (Double)dt.Rows[i]["MaxBasicPercentage"];
                LoanDetails[i].MinServicePeriod = (int)dt.Rows[i]["MinServicePeriod"];
                LoanDetails[i].MinLeaveBalance = (int)dt.Rows[i]["MinLeaveBalance"];
                LoanDetails[i].RemainingService = (int)dt.Rows[i]["RemainingService"];
                LoanDetails[i].Installment = (String)dt.Rows[i]["Installment"];
            }

            return LoanDetails;
        }
        /// <summary>
        /// Get Designation By Designation Name
        /// </summary>
        /// <param name="DesignationName">field contaions Designation Name</param>
        /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
        public Master_Loan[] GetAllInActiveLoansOrderByLoan()
        {
            Master_Loan[] Loan = GetAllInActiveLoan();

            if (Loan != null && Loan.Length >= 0)
            {
                return Loan;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Loan[] GetAllInActiveLoan()
        {
            const String Qry = "SELECT * FROM Master_Loan WHERE IsActive=0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

         

            Master_Loan[] LoanDetails = new Master_Loan[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new Master_Loan();
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                LoanDetails[i].MaxAmount = (double)dt.Rows[i]["MaxAmount"];
                LoanDetails[i].Interest = (double)dt.Rows[i]["Interest"];
                LoanDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                LoanDetails[i].MaxBasicPercentage = (Double)dt.Rows[i]["MaxBasicPercentage"];
                LoanDetails[i].MinServicePeriod = (int)dt.Rows[i]["MinServicePeriod"];
                LoanDetails[i].MinLeaveBalance = (int)dt.Rows[i]["MinLeaveBalance"];
                LoanDetails[i].RemainingService = (int)dt.Rows[i]["RemainingService"];
                LoanDetails[i].Installment = (String)dt.Rows[i]["Installment"];
            }

            return LoanDetails;
        }

        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Loan[] GetAllActiveLoan()
        {
            const String Qry = "SELECT * FROM Master_Loan WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Loan[] LoanDetails = new Master_Loan[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new Master_Loan();
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                LoanDetails[i].MaxAmount = (double)dt.Rows[i]["MaxAmount"];
                LoanDetails[i].Interest = (double)dt.Rows[i]["Interest"];
                LoanDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                LoanDetails[i].MaxBasicPercentage = (Double)dt.Rows[i]["MaxBasicPercentage"];
                LoanDetails[i].MinServicePeriod = (int)dt.Rows[i]["MinServicePeriod"];
                LoanDetails[i].MinLeaveBalance = (int)dt.Rows[i]["MinLeaveBalance"];
                LoanDetails[i].RemainingService = (int)dt.Rows[i]["RemainingService"];
                LoanDetails[i].Installment = (String)dt.Rows[i]["Installment"];
            }

            return LoanDetails;
        }


        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Hr_Grade object</returns>
        public Master_Loan[] GetLoans(String Filter)
        {
            const String Qry = " SELECT * FROM Master_Loan";

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

            Master_Loan[] LoanDetails = new Master_Loan[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new Master_Loan();
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                LoanDetails[i].MaxAmount = (double)dt.Rows[i]["MaxAmount"];
                LoanDetails[i].Interest = (double)dt.Rows[i]["Interest"];
                LoanDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                LoanDetails[i].MaxBasicPercentage = (Double)dt.Rows[i]["MaxBasicPercentage"];
                LoanDetails[i].MinServicePeriod = (int)dt.Rows[i]["MinServicePeriod"];
                LoanDetails[i].MinLeaveBalance = (int)dt.Rows[i]["MinLeaveBalance"];
                LoanDetails[i].RemainingService = (int)dt.Rows[i]["RemainingService"];
                LoanDetails[i].Installment = (String)dt.Rows[i]["Installment"];
            }

            return LoanDetails;
        }

        
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public String GetLoanAmountByLoanId(int LoanId,int EmpID)
        {

            const String Qry = "usp_GetLoanByLoanIDDetails {0},{1} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LoanId, EmpID);
            DataTable dt = EE.ExecuteDataTable(exQry);
            /////
                Double ServicePeriod = Convert.ToDouble(dt.Rows[0]["ServicePeriod"].ToString());
                String Installment = dt.Rows[0]["Installment"].ToString();

                string[] words = Installment.Split('|');
                Array.Sort(words);
                int RepaymentMonth = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    string[] SerInst = words[words.Length - i - 1].Split(',');
                    if (ServicePeriod >= Convert.ToDouble(SerInst[0]))
                    {
                        RepaymentMonth = Convert.ToInt32(SerInst[1]);
                        break;
                    }
                }

                //////
                String rMaxAmount = dt.Rows[0]["MaxLoanAmount"].ToString() + "%" + dt.Rows[0]["Interest"].ToString() + "%" + RepaymentMonth.ToString();
            
                return rMaxAmount;
            
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Loan[] GetAllActLoans(string LoanID)
        {
            const String Qry = " SELECT * FROM Master_Loan WHERE IsActive=1 and id in ({0}) ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LoanID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Loan[] LoanDetails = new Master_Loan[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new Master_Loan();
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                LoanDetails[i].MaxAmount = (double)dt.Rows[i]["MaxAmount"];
                LoanDetails[i].Interest = (double)dt.Rows[i]["Interest"];
                LoanDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                LoanDetails[i].MaxBasicPercentage = (Double)dt.Rows[i]["MaxBasicPercentage"];
                LoanDetails[i].MinServicePeriod = (int)dt.Rows[i]["MinServicePeriod"];
                LoanDetails[i].MinLeaveBalance = (int)dt.Rows[i]["MinLeaveBalance"];
                LoanDetails[i].RemainingService = (int)dt.Rows[i]["RemainingService"];
                LoanDetails[i].Installment = (String)dt.Rows[i]["Installment"];
            }

            return LoanDetails;
        }
         /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Loan[] GetAllActLoansByGrade(int GradeId)
        {
            const String Qry =  " SELECT ml.id as ID,ml.Loanname as LoanName,mlg.MaxAmount as MaxAmount, " +
                                " mlg.Interest as Interest,ml.RepaymentMonth as RepaymentMonth,ml.IsActive as IsActive " +
                                " FROM Master_Loan ml " +
                                " inner join Master_Loan_Grade mlg on  (ml.id=mlg.loanid) " +
                                " WHERE ml.IsActive=1 and mlg.gradeid={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, GradeId.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Loan[] LoanDetails = new Master_Loan[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new Master_Loan();
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                LoanDetails[i].LoanName = (String)dt.Rows[i]["LoanName"];
                LoanDetails[i].MaxAmount = (double)dt.Rows[i]["MaxAmount"];
                LoanDetails[i].Interest = (double)dt.Rows[i]["Interest"];
                LoanDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return LoanDetails;
        }
        
        /// <summary>
        /// check Grade Existance in the database.
        /// </summary>
        /// <param name="Grade">field contains Grade name</param>
        /// <param name="ID">field contains Grade ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsLoanExists(String Loan, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Loan WHERE LoanName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Loan, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        /// <summary>
        /// check PolicyType Existance in the database.
        /// </summary>
        /// <param name="PolicyType">field contains PolicyType name</param>
        /// <param name="ID">field contains PolicyType ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsLoanRefered(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Master_Loan_Grade WHERE LoanID = '{0}' "
                               // + " Union SELECT ID FROM Assign_Emp_Loan WHERE LoanID = '{0}'  "
                                + " Union SELECT ID FROM Loan_Request WHERE LoanID = '{0}' ) "
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        } 
    }
}
