using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity;
namespace HRManager.BusinessObjects
{
    public partial class Employee_Payroll_DeductionsBusinessObject
    {
        public Employee_Payroll_DeductionsBusinessObject(bool noLock)
        {
            persistent = new PersistentObject(mapped);
            persistent.ExecuteWithNoLocks = noLock;
        }

        #region PF for Payroll
        
        public void GetEmployeePF(int month, int year, int empId, PF PFValue)
        {
            const String Qry = "SELECT D.ID,P.Month,P.Year,P.EmployeeID,Limit Percentage,[Basic],Amount,SD.IsTaxExempted  FROM Employee_Payroll_Deductions D "
                             + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                             + " INNER JOIN Master_Salary_Deductions SD ON SD.ID=D.DeductionID"
                             + " WHERE SD.Name='PF' AND [Month]={0} AND [Year]={1} AND EmployeeID={2} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year, empId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    //PFValue = new PF();
                    PFValue.ID = (int)dr["ID"];
                    PFValue.Month = (int)dr["Month"];
                    PFValue.Year = (int)dr["Year"];
                    PFValue.EmployeeID = (int)dr["EmployeeID"];
                    PFValue.Basic = (double)dr["Basic"];
                    PFValue.Percentage = (double)dr["Percentage"];
                    PFValue.Amount = (double)dr["Amount"];
                    PFValue.IsTaxExempted = (bool)dr["IsTaxExempted"];
                }
            }

        }


        public void GetEmployeePF(int EmpID, double basic, PF PFValue)
        {
            try
            {
                //const String Qry = "SELECT ID,Name,Limit,IsPercentage,IsTaxExempted FROM Master_Salary_Deductions " +
                //                   "WHERE DeductionPeriod='MON' AND IsActive=1 AND IsEmployeeLevel=1 " +
                //                   "AND DeductionCode = 'PF'";
                 const String Qry="[Proc_GetEmployeeDeduction] 'PF',{0}";
                ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
                ExecutionQuery exQry = new ExecutionQuery();
                exQry.Query = string.Format(Qry, EmpID.ToString());
               // exQry.Query = string.Format(Qry);
                DataTable dt = EE.ExecuteDataTable(exQry);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        PFValue.DeductionID = (int)dr["ID"];
                        PFValue.Percentage = (double)dr["Limit"]; //(double)dr["Percentage"];
                        PFValue.Amount = (basic * ((double)dr["Limit"])) / 100;
                        PFValue.IsTaxExempted = (bool)dr["IsTaxExempted"];
                    }
                }
            }
            catch (Exception ex)
            {
                IS91.Services.Logger.LogThis(ex);
            }
        }
        public void GetEmployeePF(int Id, PF PFValue)
        {
            const String Qry = "SELECT D.ID,SD.ID DeductionID,P.Month,P.Year,P.EmployeeID,Limit Percentage,[Basic],Amount,SD.IsTaxExempted  FROM Employee_Payroll_Deductions D "
                             + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                             + " INNER JOIN Master_Salary_Deductions SD ON SD.ID=D.DeductionID"
                             + " WHERE SD.DeductionCode='PF' AND D.ID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Id);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    //PFValue = new PF();
                    PFValue.ID = (int)dr["ID"];
                    PFValue.DeductionID = (int)dr["DeductionID"];
                    PFValue.Month = (int)dr["Month"];
                    PFValue.Year = (int)dr["Year"];
                    PFValue.EmployeeID = (int)dr["EmployeeID"];
                    PFValue.Basic = (double)dr["Basic"];
                    PFValue.Percentage = (double)dr["Percentage"];
                    PFValue.Amount = (double)dr["Amount"];
                    PFValue.IsTaxExempted = (bool)dr["IsTaxExempted"];

                }
            }

        }
        public PF[] GetAllEmployeesPF(int month, int year)
        {
            const String Qry = "SELECT D.ID,SD.ID DeductionID,P.Month,P.Year,P.EmployeeID,Limit Percentage,[Basic],Amount,SD.IsTaxExempted  FROM Employee_Payroll_Deductions D "
                             + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                             + " INNER JOIN Master_Salary_Deductions SD ON SD.ID=D.DeductionID"
                             + " WHERE SD.Name='PF' AND P.Month={0} AND P.Year={1} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year);
            DataTable dt = EE.ExecuteDataTable(exQry);
            PF[] empPF = null;
            if (dt != null)
            {
                empPF = new PF[dt.Rows.Count];
                int k = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    empPF[k] = new PF();
                    empPF[k].ID = (int)dr["ID"];
                    empPF[k].DeductionID = (int)dr["DeductionID"];
                    empPF[k].Month = (int)dr["Month"];
                    empPF[k].Year = (int)dr["Year"];
                    empPF[k].EmployeeID = (int)dr["EmployeeID"];
                    empPF[k].Basic = (double)dr["Basic"];
                    empPF[k].Percentage = (double)dr["Percentage"];
                    empPF[k].Amount = (double)dr["Amount"];
                    empPF[k].IsTaxExempted = (bool)dr["IsTaxExempted"];
                    k++;
                }
            }
            return empPF;

        }

        #endregion

        #region ESI for Payroll

        public void GetEmployeeESI(int Id, ESI ESIValue)
        {
            const String Qry = "SELECT D.ID,SD.ID DeductionID,D.Amount, P.Month,P.Year,P.EmployeeID,Limit PercentageValue,SD.IsTaxExempted FROM Employee_Payroll_Deductions D "
                             + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                             + " INNER JOIN Master_Salary_Deductions SD ON SD.ID=D.DeductionID"
                             + " WHERE SD.Name='ESI' AND D.ID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Id);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    ESIValue.ID = (int)dr["ID"];
                    ESIValue.DeductionID = (int)dr["DeductionID"];
                    ESIValue.Month = (int)dr["Month"];
                    ESIValue.Year = (int)dr["Year"];
                    ESIValue.EmployeeID = (int)dr["EmployeeID"];
                    ESIValue.PercentageValue = (double)dr["PercentageValue"];
                    ESIValue.IsTaxExempted = (bool)dr["IsTaxExempted"];
                    ESIValue.Amount =(double)dr["Amount"];
                }
            }

        }
        public void GetEmployeeESI(int month, int year, int empId, ESI ESIValue)
        {
            const String Qry = "SELECT ID,Name,Limit,IsPercentage,IsTaxExempted FROM Master_Salary_Deductions " +
                               "WHERE DeductionPeriod='MON' AND IsActive=1 AND IsEmployeeLevel=0 " +
                               "AND DeductionCode = 'ESI'  AND ID NOT IN (SELECT DEDUCTIONID FROM Assign_Employee_Deductions WHERE EMPID={0}) " +
                               "AND EXISTS(SELECT EMPID FROM Employee_Salary WHERE HasESI=1 AND EMPID={0})" +
                               "UNION " +
                               "SELECT D.ID,Name,Deduction,IsPercentage,IsTaxExempted FROM Master_Salary_Deductions D " +
                               "INNER JOIN Assign_Employee_Deductions E ON E.DeductionID=D.ID " +
                               "INNER JOIN Employee_Salary S ON S.EmpID=E.EmpID " +
                               "WHERE DeductionPeriod='MON' AND D.IsActive=1 AND IsEmployeeLevel=0 " +
                               "AND DeductionCode = 'ESI' AND E.EMPID={0} AND S.HasESI=1 "; 

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    ESIValue.ID = 0;
                    ESIValue.DeductionID = (int)dr["ID"];
                    ESIValue.Month = month;
                    ESIValue.Year = year;
                    ESIValue.EmployeeID = empId;
                    ESIValue.PercentageValue = (double)dr["Limit"];
                    ESIValue.IsTaxExempted = (bool)dr["IsTaxExempted"];
                }
            }
        }
        public ESI[] GetAllEmployeesESI(int month, int year)
        {
            const String Qry = "SELECT D.ID,D.DeductionID,P.Month,P.Year,P.EmployeeID,Limit PercentageValue,SD.IsTaxExempted " +
                               " FROM Employee_Payroll_Deductions D " +
                               " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID " +
                               " INNER JOIN Master_Salary_Deductions SD ON SD.ID=D.DeductionID " +
                               " WHERE SD.Name='ESI' AND [Month]={0} AND [Year]={1}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year);
            DataTable dt = EE.ExecuteDataTable(exQry);
            ESI[] ESIDetails = new ESI[dt.Rows.Count];
            for (int i = 0; i < ESIDetails.Length; i++)
            {
                ESIDetails[i] = new ESI();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    ESIDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["DeductionID"].ToString() != string.Empty)
                    ESIDetails[i].DeductionID = (int)dt.Rows[i]["DeductionID"];
                if (dt.Rows[i]["EmployeeID"].ToString() != string.Empty)
                    ESIDetails[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                if (dt.Rows[i]["Month"].ToString() != string.Empty)
                    ESIDetails[i].Month = (int)dt.Rows[i]["Month"];
                if (dt.Rows[i]["Year"].ToString() != string.Empty)
                    ESIDetails[i].Year = (int)dt.Rows[i]["Year"];
                if (dt.Rows[i]["PercentageValue"].ToString() != string.Empty)
                    ESIDetails[i].PercentageValue = (Double)dt.Rows[i]["PercentageValue"];
                ESIDetails[i].IsTaxExempted = (bool)dt.Rows[i]["IsTaxExempted"];
            }
            return ESIDetails;
        }
        public Double getDeductionPercentage()
        {
            double dblValue = 0;
            string qry = "Select Limit PercentageValue From Master_Salary_Deductions WHERE Name='ESI'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(qry);
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out dblValue);
            return dblValue;
        }
      public Double GetESIPercentage(int empId)
        {
            double dblValue = 0;
            string qry = "Select Limit PercentageValue From Master_Salary_Deductions WHERE Name='ESI' " +
                        "AND ID NOT IN (SELECT DEDUCTIONID FROM Assign_Employee_Deductions WHERE EMPID={0}) " +
                        "UNION " +
                        "SELECT Deduction FROM Master_Salary_Deductions D " +
                        "INNER JOIN Assign_Employee_Deductions E ON E.DeductionID=D.ID " +
                        "AND DeductionCode = 'ESI' AND E.EMPID={0} ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(qry,empId);
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out dblValue);
            return dblValue;
        }
        #endregion
     
        #region Tax for Payroll

        public void GetEmployeeTax(int Id, PayrollTax taxValue)
        {
            const String Qry = "SELECT D.ID,Tx.ID TaxID, P.Month,P.Year,P.EmployeeID,Amount,TaxCode,TaxName,IsFixed,FixedPercentage FROM Employee_Payroll_Deductions D "
                             + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                             + " INNER JOIN Master_Tax Tx ON Tx.ID=D.DeductionID"
                             + " WHERE DeductionType='TDS' AND D.ID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Id);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    taxValue.ID = (int)dr["ID"];
                    taxValue.TaxID = (int)dt.Rows[0]["TaxID"];
                    taxValue.Month = (int)dr["Month"];
                    taxValue.Year = (int)dr["Year"];
                    taxValue.EmployeeID = (int)dr["EmployeeID"];
                    taxValue.PercentageValue =0;
                    taxValue.Amount = (double)dr["Amount"];
                    taxValue.TaxName= string.Concat(dt.Rows[0]["TaxName"]);
                    taxValue.TaxCode = string.Concat(dt.Rows[0]["TaxCode"]);
                    taxValue.IsFixedPercentage = (bool)dr["IsFixed"];
                    if (taxValue.IsFixedPercentage)
                    {
                        taxValue.PercentageValue = (double)dr["FixedPercentage"];
                    }
                }
            }

        }

        public void GetEmployeeTax(int fyear, double grossSal, int TaxId, PayrollTax taxValue)
        {
             String Qry = "SELECT ID,TaxName,IsFixed,FixedPercentage,TaxCode  FROM MASTER_TAX WHERE IsActive=1 AND TaxCode NOT IN ('TDS') AND ID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,  TaxId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    taxValue.TaxID = (int)dr["ID"];
                    taxValue.TaxName= string.Concat(dt.Rows[0]["TaxName"]);
                    taxValue.TaxCode = string.Concat(dt.Rows[0]["TaxCode"]);
                    taxValue.IsFixedPercentage = (bool)dr["IsFixed"];
                    if (taxValue.IsFixedPercentage)
                    {
                        taxValue.PercentageValue = (double)dr["FixedPercentage"];
                        taxValue.Amount = Math.Round(grossSal * taxValue.PercentageValue / 100,2,MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        Qry = "SELECT IsPercentage,Value FROM Master_Tax_Slabs S " +
                              " WHERE FinancialYear={2} AND TaxID={0} AND {1}>MinAmount AND ({1}<MaxAmount OR MaxAmount=0) " +
                              " AND S.StateID =(SELECT L.StateID FROM Master_Location L " +
                              " INNER JOIN Master_Branch B ON B.LocationID=L.ID " +
                              " INNER JOIN Assign_Emp_Branch E ON E.BranchID=B.ID " +
                              " INNER JOIN Master_Employees EM ON EM.ID =E.EmpID " +
                              " WHERE E.EMPID={3} AND ActivatedDate =(SELECT MAX(ActivatedDate) FROM Assign_Emp_Branch WHERE EmpID=E.EmpID) AND EM.EmploymentType<>4 )";
                        exQry.Query = string.Format(Qry, taxValue.TaxID, grossSal, fyear, taxValue.EmployeeID);
                        DataTable dttx = EE.ExecuteDataTable(exQry);
                        if (dttx != null)
                        {
                            if (dttx.Rows.Count > 0)
                            {
                                DataRow drtx=dttx.Rows[0];
                                if ((bool)drtx["IsPercentage"])
                                {
                                    taxValue.PercentageValue = (double)drtx["Value"];
                                    taxValue.Amount = Math.Round(grossSal * taxValue.PercentageValue / 100, 2, MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    taxValue.PercentageValue = 0;
                                    taxValue.Amount = Math.Round((double)drtx["Value"], 2, MidpointRounding.AwayFromZero);
                                }
                            }
                        }
                    }
                    
                }
            }
        }
        public string GetStateID(int empId,string asDate)
        {
            String Qry = "SELECT S.ID FROM Common_State S"
                        + " INNER JOIN Master_Location L ON L.StateID=S.ID"
                        + " INNER JOIN Master_Branch B ON B.LocationID=L.ID"
                        + " INNER JOIN Assign_Emp_Branch EB ON EB.BranchID=B.ID"
                        + " WHERE EB.ActivatedDate=(SELECT Max(ActivatedDate) FROM Assign_Emp_Branch WHERE EmpID=EB.EmpID AND ActivatedDate<'{1}')"
                        + " AND EB.EmpID={0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId,asDate);
            return string.Concat(EE.ExecuteScalar(exQry));
        }
        public void GetEmployeeTax(int fyear, PayrollEarnings earnings, int TaxId, PayrollTax taxValue)
        {
            String Qry = "SELECT ID,TaxName,IsFixed,FixedPercentage,TaxCode  FROM MASTER_TAX WHERE IsActive=1 AND TaxCode NOT IN ('TDS') AND ID={0}";
            double grossSal = earnings.TotalEarnings  ;
            double PrevGrossSal = 0;
            double ExcAllow = 0; 
            int NoOfMonths = 0;
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, TaxId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (string.Concat(dt.Rows[0]["TaxName"]) == "PT" || string.Concat(dt.Rows[0]["TaxCode"]) == "PT")
                    {
                        /*int ind1 = Array.FindIndex<Allowance>(earnings.Allowances, (x) => (x.Name == "LTA" || x.Code == "LTA"));
                          if (ind1 > -1)
                          {
                              grossSal = grossSal - earnings.Allowances[ind1].Amount;
                          }
                          ind1 = Array.FindIndex<Allowance>(earnings.Allowances, (x) => (x.Name == "Medical Allowance" || x.Code == "MRM"));
                          if (ind1 > -1)
                          {
                              grossSal = grossSal - earnings.Allowances[ind1].Amount;
                          }*/
                        string mnts = IS91.Services.Common.GetAppSetting("PTCalculationDuration");
                        string addns = IS91.Services.Common.GetAppSetting("PTCalculationExclusions");
                        string stateId = GetStateID(earnings.EmployeeId, new DateTime(earnings.Year, earnings.Month, 1).AddMonths(1).ToString("yyyy-MM-dd"));
                        string excludeAllow = "0";
                        if (addns.Length > 0)
                        {
                            string[] avals = addns.Split(",".ToCharArray());
                            if (avals.Length > 0)
                            {
                                foreach (string s in avals)
                                {
                                    string[] afin = s.Split("-".ToCharArray());
                                    if (afin.Length > 0)
                                    {
                                        if (afin[0] == stateId )
                                        {
                                            foreach (string vs in afin)
                                            {
                                                string[] aexs = vs.Split(";".ToCharArray());
                                                if (aexs.Length > 0)
                                                {
                                                    foreach (string vl in aexs)
                                                    {
                                                        int ind = Array.FindIndex<Allowance>(earnings.Allowances, (x) => (x.AllowanceID.ToString() == vl));
                                                        if (ind > -1)
                                                        {
                                                            excludeAllow = excludeAllow + "," + vl;
                                                            //grossSal = grossSal - earnings.Allowances[ind].Amount;
                                                            ExcAllow = ExcAllow + earnings.Allowances[ind].Amount;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        
                        if (mnts.Length > 0)
                        {
                            string[] mvals = mnts.Split(",".ToCharArray()); //13-9;6|3;6,24-9;6|3;6
                            if (mvals.Length > 0)
                            {
                                foreach (string s in mvals)
                                {
                                   string[] mfin = s.Split("-".ToCharArray());
                                   if (mfin.Length > 0)
                                   {  if(mfin[0]==stateId)
                                      {
                                          
                                          if (mfin.Length > 1)
                                          {
                                              grossSal = 0;
                                         // foreach (string vs in mfin)
                                         // {
                                              string[] avals = mfin[1].Split("|".ToCharArray());
                                              if (avals.Length > 0)
                                              {
                                                  foreach (string ss in avals)
                                                  {
                                                      string[] kk = ss.Split(";".ToCharArray());
                                                      if (kk.Length > 0)
                                                      {
                                                              if (string.Concat(earnings.Month) == kk[0])
                                                              {
                                                                  int.TryParse(kk[1], out NoOfMonths);
                                                                  PrevGrossSal = GetGrossSalary(earnings.EmployeeId, new DateTime(earnings.Year, earnings.Month, 1).AddMonths(-NoOfMonths), new DateTime(earnings.Year, earnings.Month, 1), excludeAllow);
                                                                  //grossSal = earnings.TotalEarnings + PrevGrossSal - ExcAllow; //earnings.TotalEarnings;
                                                                  grossSal = earnings.TotalEarnings + PrevGrossSal - ExcAllow; //earnings.TotalEarnings;
                                                                  break;
                                                              }
                                                              else if (earnings.LeavingDate.Year>1900)
                                                              {
                                                                  int.TryParse(kk[1], out NoOfMonths);
                                                                  DateTime fDate = new DateTime(earnings.Year, earnings.Month, 1).AddMonths(-NoOfMonths);
                                                                  if (fDate < new DateTime(fyear, 4, 1))
                                                                  {
                                                                      fDate = new DateTime(fyear, 4, 1);
                                                                  }
                                                                  PrevGrossSal = GetGrossSalary(earnings.EmployeeId,fDate, new DateTime(earnings.Year, earnings.Month, 1), excludeAllow);
                                                                  //grossSal = earnings.TotalEarnings + PrevGrossSal - ExcAllow; //earnings.TotalEarnings;
                                                                  grossSal = earnings.TotalEarnings + PrevGrossSal - ExcAllow; //earnings.TotalEarnings;
                                                                  break;
                                                              }
                                                              else
                                                              {
                                                                  grossSal = 0;
                                                              }


                                                      }
                                                  }
                                              }
                                         // }
                                   }
                                       }
                                   }

                                }

                            }
                        }
                      
                    }
                    DataRow dr = dt.Rows[0];
                    taxValue.TaxID = (int)dr["ID"];
                    taxValue.TaxName = string.Concat(dt.Rows[0]["TaxName"]);
                    taxValue.TaxCode = string.Concat(dt.Rows[0]["TaxCode"]);
                    taxValue.IsFixedPercentage = (bool)dr["IsFixed"];
                    if (taxValue.IsFixedPercentage)
                    {
                        taxValue.PercentageValue = (double)dr["FixedPercentage"];
                        taxValue.Amount = Math.Round(grossSal * taxValue.PercentageValue / 100, 2, MidpointRounding.AwayFromZero); //* (NoOfMonths == 0 ? 1 : NoOfMonths)
                    }
                    else
                    {
                        Qry = "SELECT IsPercentage,Value FROM Master_Tax_Slabs S " +
                              " WHERE  (FinancialYear=(SELECT max(FinancialYear) FROM Master_Tax_Slabs WHERE StateID=S.StateID AND TaxID=S.TaxID) OR FinancialYear={2}) AND TaxID={0} AND {1}>MinAmount AND ({1}<MaxAmount OR MaxAmount=0) " +
                              " AND S.StateID =(SELECT L.StateID FROM Master_Location L " +
                              " INNER JOIN Master_Branch B ON B.LocationID=L.ID " +
                              " INNER JOIN Assign_Emp_Branch E ON E.BranchID=B.ID " +
                              " INNER JOIN Master_Employees EM ON EM.ID =E.EmpID " +
                              " WHERE E.EMPID={3} AND ActivatedDate =(SELECT MAX(ActivatedDate) FROM Assign_Emp_Branch WHERE EmpID=E.EmpID AND ActivatedDate<'{4}') AND EM.EmploymentType<>4 )";
                        exQry.Query = string.Format(Qry, taxValue.TaxID, grossSal, fyear, taxValue.EmployeeID, new DateTime(earnings.Year, earnings.Month, 1).AddMonths(1).ToString("yyyy-MM-dd"));
                        DataTable dttx = EE.ExecuteDataTable(exQry);
                        if (dttx != null)
                        {
                            if (dttx.Rows.Count > 0)
                            {
                                DataRow drtx = dttx.Rows[0];
                                if ((bool)drtx["IsPercentage"])
                                {
                                    taxValue.PercentageValue = (double)drtx["Value"];
                                    taxValue.Amount = Math.Round(grossSal * taxValue.PercentageValue / 100, 2, MidpointRounding.AwayFromZero); //* (NoOfMonths == 0 ? 1 : NoOfMonths)
                                }
                                else
                                {
                                    taxValue.PercentageValue = 0;
                                    if(grossSal>0)
                                        taxValue.Amount = Math.Round((double)drtx["Value"], 2, MidpointRounding.AwayFromZero); //* (NoOfMonths == 0 ? 1 : NoOfMonths)
                                    else
                                        taxValue.Amount = Math.Round((double)drtx["Value"], 2, MidpointRounding.AwayFromZero); //* (NoOfMonths == 0 ? 1 : NoOfMonths)
                                }
                            }
                        }
                    }

                }
            }
        }


        public double GetGrossSalary(int EmployeeId,DateTime fromDate,DateTime toDate,string exclAllowId)
        {
            double dblGrs = 0;
            String Qry = "SELECT Basic+Special+totEarn Gross FROM"
                     + "("
                     + " SELECT PR.EmployeeID,SUM(Basic)Basic,SUM(Special)Special FROM  EMPLOYEE_PAYROLL PR"
                     + " WHERE PR.EmployeeID={0} AND CAST(CONVERT(varchar, PR.Year) + '-' + CONVERT(varchar, PR.Month) +  '-01' AS DATETIME)"
                     + " >='{1}' AND CAST(CONVERT(varchar, PR.Year) + '-' + CONVERT(varchar, PR.Month) +  '-01' AS DATETIME)<'{2}'"
                     + " GROUP BY PR.EmployeeID"
                     + " )PY"
                     + " LEFT JOIN ("
                     + " SELECT EmployeeID,SUM(E.Amount) totEarn FROM EMPLOYEE_PAYROLL P"
                     + " INNER JOIN EMPLOYEE_PAYROLL_EARNINGS E ON E.PayrollID=P.ID"
                     + " INNER JOIN Master_Salary_Allowance S ON S.ID=E.AllowanceID"
                     + " WHERE IsAllowance=1 AND P.EmployeeID={0} AND"
                     + " CAST(CONVERT(varchar, P.Year) + '-' + CONVERT(varchar, P.Month) +  '-01' AS DATETIME)"
                     + " >='{1}' AND CAST(CONVERT(varchar, P.Year) + '-' + CONVERT(varchar, P.Month) +  '-01' AS DATETIME)<'{2}'"
                     + " AND E.AllowanceID NOT IN ({3}) GROUP BY P.EmployeeID"
                     + " )ER ON ER.EmployeeID=PY.EmployeeID";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeId, fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), exclAllowId);
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out dblGrs);
            return dblGrs;
        }

        #endregion
        
        #region Loan for Payroll
        public void GetLoanDeduction(int payrollId, PayrollDeductions pded)
        {

           /* const String Qry = " SELECT  D.ID,M.ID LoanID, L.ID RequestID,LoanID,LoanName,L.LoanAmount,RepaymentMonths,MonthlyAmount,DueAmount FROM  Loan_Request L "
                             + " INNER JOIN Assign_Emp_Loan E ON E.LoanRequestID=L.ID"
                             + " INNER JOIN Master_Loan M ON M.ID=L.LoanID"
                             + " INNER JOIN Employee_Payroll_Deductions D ON D.DeductionID=L.ID"
                             + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                             + " WHERE P.ID={0} AND DeductionType='LON' ";*/
            const String Qry = " SELECT  DD.ID,M.ID LoanID, L.ID RequestID,LoanName,L.LoanAmount,RepaymentMonths,MonthlyAmount,L.LoanAmount-ISNULL(DN.Amount,0)-DD.Amount BalAmount FROM  Loan_Request L "
                              + " INNER JOIN Master_Loan M ON M.ID=L.LoanID"
                              + " INNER JOIN Employee_Payroll_Deductions DD ON DD.DeductionID=L.ID"
                              + " INNER JOIN Employee_Payroll PR ON PR.ID=DD.PayrollID AND PR.EmployeeID=L.EmpID "
                              + " LEFT JOIN(SELECT EmployeeID,DeductionID, ISNULL(SUM(Amount),0) Amount "
                              + "  FROM Employee_Payroll_Deductions D" //,cast(rtrim(P.Year*10000+ P.Month *100+ 1) as datetime) PDate
                              + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                              + " WHERE DeductionType='LON' AND cast(rtrim(P.Year*10000+ P.Month *100+ 1) as datetime)<"
                              + " (SELECT cast(rtrim(Year*10000+ Month *100+ 1) as datetime) FROM Employee_Payroll_Deductions"
                              + " WHERE ID={0})"
                              + " GROUP BY P.EmployeeID,DeductionID " //,P.Year,P.Month
                              + " )DN  ON DN.EmployeeID=L.EmpID AND DN.DeductionID=L.ID "
                             // + " AND DN.PDate<cast(rtrim(PR.Year*10000+ PR.Month *100+ 1) as datetime) "
                              + " WHERE PR.ID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (pded == null)
                        pded = new PayrollDeductions();
                    pded.Loan = new Loan[dt.Rows.Count];
                    Loan ln = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ln = new Loan();
                        ln.ID = (int)dr["ID"];
                        ln.LoanID = (int)dr["LoanID"];
                        ln.DeductionID = (int)dr["RequestID"];
                        ln.LoanAmount = (double)dr["LoanAmount"];
                        //ln.BalanceAmount = (double)dr["DueAmount"];
                        ln.Installments = (Int16)dr["RepaymentMonths"];
                        ln.LoanName = string.Concat(dr["LoanName"]);
                        ln.Amount = (double)dr["MonthlyAmount"];
                        ln.BalanceAmount = (double)dr["BalAmount"];
                        ln.EmployeeID = pded.EmployeeID;
                        ln.Month = pded.Month;
                        ln.Year = pded.Year;
                        pded.Loan[k] = ln;
                        k++;
                    }
                }
            }

        }

        public DataTable GetPayrollLoans(string payrollId)
        {
            const String Qry = "SELECT  0 ID,0 LoanID, 0 RequestID,0 LoanID,'' LoanName,0 Amount,0 RepaymentMonths,0 MonthlyAmount,0 DueAmount"
                             + " ,dbo.ufnGetLeavesByDate(0,'Annual Leave',P.EmployeeID,DATEADD(m,1,cast(rtrim(P.Year*10000+ P.Month*100+ 1) as datetime))) AL,"
                             + " dbo.ufnGetLeavesByDate(0,'Casual Leave',P.EmployeeID,DATEADD(m,1,cast(rtrim(P.Year*10000+ P.Month*100+ 1) as datetime))) CL,"
                             + " dbo.ufnGetLeavesByDate(0,'Sick Leave',P.EmployeeID,DATEADD(m,1,cast(rtrim(P.Year*10000+ P.Month*100+ 1) as datetime))) SL FROM Employee_Payroll P  " 
                             + " LEFT JOIN ASSIGN_EMP_LEAVE L ON P.EmployeeID=L.EMPID"
                             + " LEFT JOIN MASTER_LEAVE ML ON ML.ID=L.LeaveID"
                             + " WHERE P.ID={0} "
                             + " UNION"
                             + " SELECT  D.ID,M.ID LoanID, L.ID RequestID,LoanID,LoanName,(L.LoanAmount-ISNULL(DN.Amount,0)-D.Amount) Amount,RepaymentMonths,MonthlyAmount,(L.LoanAmount-ISNULL(DN.Amount,0)-D.Amount) DueAmount,0,0,0 FROM  Loan_Request L "
                             + " INNER JOIN Master_Loan M ON M.ID=L.LoanID"
                             + " INNER JOIN Employee_Payroll_Deductions D ON D.DeductionID=L.ID"
                             + " INNER JOIN Employee_Payroll PR ON PR.ID=D.PayrollID"
                             + " LEFT JOIN(SELECT EmployeeID,DeductionID, ISNULL(SUM(Amount),0) Amount,"
                             + " cast(rtrim(P.Year*10000+ P.Month *100+ 1) as datetime) PDate FROM Employee_Payroll_Deductions D"
                             + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                             + " WHERE DeductionType='LON' GROUP BY P.EmployeeID,DeductionID,P.Year,P.Month" 
                             + " )DN  ON DN.EmployeeID=L.EmpID AND DN.DeductionID=L.ID"
                             + " AND DN.PDate<cast(rtrim(PR.Year*10000+ PR.Month *100+ 1) as datetime)" 
                             + " WHERE PR.ID={0} AND DeductionType='LON' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            return EE.ExecuteDataTable(exQry);
        }

        public DataTable GetPayrollNarrations(string payrollId)
        {
            if (payrollId == "") payrollId = "0";
            const String Qry = "EXEC Proc_GetPayrollNarration {0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            return EE.ExecuteDataTable(exQry);
        }


        public string GetBalanceLeave(string empId,string month,string year,string ltype)
        {
            const String Qry = "SELECT dbo.ufnGetLeavesByDate(0,'{3}',{2}, DATEADD(m,1,cast(rtrim({1}*10000+ {0}*100+ 1) as datetime))) ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year, empId, ltype);
            return  string.Concat(EE.ExecuteScalar(exQry));
        }
        public void GetLoansForDeduction(int empId, PayrollDeductions pded,int Month,int Year)
        {
 
            const String Qry = " SELECT  M.ID, L.ID RequestID,LoanName,L.LoanAmount,RepaymentMonths,MonthlyAmount,L.LoanAmount-ISNULL(DN.Amount,0) BalAmount FROM  Loan_Request L "
                  + " INNER JOIN Loan_Activity E ON E.LoanRequestID=L.ID"
                  + " INNER JOIN Master_Loan M ON M.ID=L.LoanID"
                  + " LEFT JOIN(SELECT EmployeeID,DeductionID, ISNULL(SUM(Amount),0) Amount FROM Employee_Payroll_Deductions D"
                  + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                  + " INNER JOIN Loan_Request L ON L.ID=D.DeductionID"
                  + " WHERE DeductionType='LON' "
                  + " AND DeductionID NOT IN (SELECT DeductionID FROM Assign_Emp_MonthlyDeduction "
                  + " WHERE P.Month=Month AND P.Year=Year AND P.EmployeeID=EmpID)"
                  + " AND P.EmployeeID={0}"
                  + " AND L.StartDate<'{2}' AND CONVERT(DATE,(CAST(P.YEAR AS NVARCHAR)+'-' +CAST(P.MONTH AS NVARCHAR)+'-01' ))<'{2}'"
                  + " GROUP BY P.EmployeeID,DeductionID "
                  + " UNION"
                  + " SELECT P.EmployeeID,DeductionID, ISNULL(SUM(Amount),0) Amount FROM Assign_Emp_MonthlyDeduction D"
                  + " INNER JOIN Employee_Payroll P ON P.Month=D.Month AND P.Year=D.Year AND P.EmployeeID=D.EmpID"
                  + " WHERE DeductionType='LON' GROUP BY P.EmployeeID,DeductionID "
                  + " )DN  ON EmployeeID=L.EmpID AND DeductionID=L.ID "
                  + " WHERE L.EmpID={0} AND E.Status='CLS'  And StartDate<'{1}'"
                  + " AND L.LoanAmount>ISNULL(Amount,0) ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId, new DateTime(Year, Month, 1).AddMonths(1).ToString("yyyy-MM-dd"), new DateTime(Year, Month, 1).ToString("yyyy-MM-dd"));
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (pded == null)
                        pded = new PayrollDeductions();
                    pded.Loan = new Loan[dt.Rows.Count];
                    Loan ln = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ln = new Loan();
                        ln.ID = 0;
                        ln.LoanID = (int)dr["ID"];
                        ln.DeductionID = (int)dr["RequestID"];
                        ln.LoanAmount = (double)dr["LoanAmount"];
                       // ln.BalanceAmount = (double)dr["DueAmount"];
                        ln.Installments = (Int16)dr["RepaymentMonths"];
                        ln.LoanName = string.Concat(dr["LoanName"]);
                        ln.Amount = (double)dr["MonthlyAmount"];
                        ln.BalanceAmount = (double)dr["BalAmount"];
                        if (ln.BalanceAmount < ln.Amount)
                            ln.Amount = ln.BalanceAmount;
                        ln.EmployeeID = pded.EmployeeID;
                        ln.Month = pded.Month;
                        ln.Year = pded.Year;
                        pded.Loan[k] = ln;
                        k++;
                    }
                }
            }

        }

        public void GetEmployeeLoan(int Id, Loan LoanValue)
        {
            const String Qry = "SELECT D.ID,D.DeductionID,P.Month,P.Year,P.EmployeeID,Amount  " +
                               " FROM Employee_Payroll_Deductions D " +
                               " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID " +
                               " INNER JOIN Loan_Request L ON L.ID=D.DeductionID " +
                               " WHERE DeductionType='LON' And D.ID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Id);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    LoanValue.ID = (int)dr["ID"];
                    LoanValue.DeductionID = (int)dt.Rows[0]["DeductionID"];
                    LoanValue.Month = (int)dr["Month"];
                    LoanValue.Year = (int)dr["Year"];
                    LoanValue.EmployeeID = (int)dr["EmployeeID"];
                    LoanValue.Amount = (double)dr["Amount"];
                }
            }

        }
        public void GetEmployeeLoan(int month, int year, int empId, Loan LoanValue)
        {
            const String Qry = "SELECT D.ID,D.DeductionID,P.Month,P.Year,P.EmployeeID,Amount  " +
                               " FROM Employee_Payroll_Deductions D " +
                               " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID " +
                               " INNER JOIN Loan_Request L ON L.ID=D.DeductionID " +
                               " WHERE DeductionType='LON' And [Month]={0} AND [Year]={1} AND EmployeeID={2} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year, empId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    LoanValue.ID = (int)dr["ID"];
                    LoanValue.DeductionID = (int)dt.Rows[0]["DeductionID"];
                    LoanValue.Month = (int)dr["Month"];
                    LoanValue.Year = (int)dr["Year"];
                    LoanValue.EmployeeID = (int)dr["EmployeeID"];
                    LoanValue.Amount = (double)dr["Amount"];
                }
            }
        }
        public Loan[] GetAllEmployeesLoan(int month, int year)
        {
            const String Qry = "SELECT D.ID,D.DeductionID,P.Month,P.Year,P.EmployeeID,Amount  " +
                               " FROM Employee_Payroll_Deductions D " +
                               " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID " +
                               " INNER JOIN Loan_Request L ON L.ID=D.DeductionID " +
                               " WHERE DeductionType='LON' And [Month]={0} AND [Year]={1} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Loan[] LoanDetails = new Loan[dt.Rows.Count];
            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new Loan();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["DeductionID"].ToString() != string.Empty)
                    LoanDetails[i].DeductionID = (int)dt.Rows[i]["DeductionID"];
                if (dt.Rows[i]["EmployeeID"].ToString() != string.Empty)
                    LoanDetails[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                if (dt.Rows[i]["Month"].ToString() != string.Empty)
                    LoanDetails[i].Month = (int)dt.Rows[i]["Month"];
                if (dt.Rows[i]["Year"].ToString() != string.Empty)
                    LoanDetails[i].Year = (int)dt.Rows[i]["Year"];
                if (dt.Rows[i]["Amount"].ToString() != string.Empty)
                    LoanDetails[i].Amount = (Double)dt.Rows[i]["Amount"];
            }
            return LoanDetails;
        }
        public Loan GetEmployeeLoanBalanceAmount(int empId)
        {
            const String Qry = "SELECT  M.ID, L.ID RequestID,LoanName,L.LoanAmount,RepaymentMonths,MonthlyAmount FROM  Loan_Request L "
                  + " INNER JOIN Loan_Activity E ON E.LoanRequestID=L.ID"
                  + " INNER JOIN Master_Loan M ON M.ID=L.LoanID"
                  + " WHERE L.EmpID={0} AND E.Status='CLS'  And StartDate<'{1}'"
                  + " AND L.LoanAmount>(SELECT  ISNULL(SUM(Amount),0) from   Employee_Payroll_Deductions D"
                  + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                  + " WHERE P.EmployeeID=L.EmpID AND DeductionType='LON') ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Loan LoanDetails = new Loan();
            if (dt != null && dt.Rows.Count > 0)
            {
                LoanDetails.Amount = (Double)dt.Rows[0]["MonthlyAmount"];
                LoanDetails.BalanceAmount = (Double)dt.Rows[0]["BalanceAmount"];
                if ((Double)dt.Rows[0]["BalanceAmount"] < (Double)dt.Rows[0]["MonthlyAmount"])
                    LoanDetails.Amount = (Double)dt.Rows[0]["BalanceAmount"];
                else
                    LoanDetails.Amount = (Double)dt.Rows[0]["MonthlyAmount"];
            }
            return LoanDetails;
        }
        public Loan GetEmployeeLoanBalanceAmount(int empId,string forDate)
        {
            const String Qry = "SELECT L.LoanAmount-ISNULL(DL.Amount,0) BalanceAmount,MonthlyAmount FROM  Loan_Request L" 
	                          + " INNER JOIN Loan_Activity E ON E.LoanRequestID=L.ID"
	                          + " INNER JOIN Master_Loan M ON M.ID=L.LoanID"
	                          + " LEFT JOIN (SELECT  EmployeeID,DeductionID,ISNULL(SUM(Amount),0) Amount from   Employee_Payroll_Deductions D"
	                          + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
	                          + " WHERE  DeductionType='LON' GROUP BY EmployeeID,DeductionID"
	                          + " )DL ON EmployeeID=L.EmpID AND DeductionID=L.ID "
                              + " WHERE L.EmpID={0} AND E.Status='CLS' AND StartDate<'{1}' ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId, forDate);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Loan LoanDetails = new Loan();
            if (dt != null && dt.Rows.Count > 0)
            {
                LoanDetails.Amount = (Double)dt.Rows[0]["MonthlyAmount"];
                LoanDetails.BalanceAmount = (Double)dt.Rows[0]["BalanceAmount"];
                if ((Double)dt.Rows[0]["BalanceAmount"] < (Double)dt.Rows[0]["MonthlyAmount"])
                    LoanDetails.Amount = (Double)dt.Rows[0]["BalanceAmount"];
                else
                    LoanDetails.Amount = (Double)dt.Rows[0]["MonthlyAmount"];
            }
            return LoanDetails;
        }
        #endregion

        #region Loan Advance for Payroll

        public void GetAdvacneDeduction(int payrollId, PayrollDeductions pded)
        {

            int monyear = pded.Year * 100 + pded.Month;
            const String Qry = " SELECT D.ID, A.ID AdvanceID,'' AdvanceName,A.AdvanceAmount,RepaymentMonths,D.Amount MonthlyAmount"
                              + "  , (AdvanceAmount-isnULL(PD.Amount,0)) DueAmount FROM  Salary_Advance A "
                              + " LEFT JOIN  ("
                              + " SELECT AdvanceID,Sum(Amount)Amount From Salary_AdvanceRepayments"
                              + " Group By AdvanceID"
                              + " UNION ALL"
                              + " SELECT DeductionID,SUM(Amount) FROM Employee_Payroll_Deductions D"
                              + " INNER JOIN Employee_Payroll P ON P.ID=PayrollID"
                              + " WHERE DeductionType='ADV' AND 100 * [Year] + [Month] < {1}"
                              + " group by DeductionID"
                              + " )PD ON PD.AdvanceID=A.ID  "
                              + " INNER JOIN Employee_Payroll_Deductions D ON D.DeductionID=A.ID"
                              + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                              + "  WHERE P.ID={0} AND DeductionType='ADV' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId, monyear);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (pded == null)
                        pded = new PayrollDeductions();
                    pded.LoanAdvance = new LoanAdvance[dt.Rows.Count];
                    LoanAdvance adv = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        adv = new LoanAdvance();
                        adv.ID = (int)dr["ID"];
                        adv.DeductionID = (int)dr["AdvanceID"];
                        adv.AdvanceAmount = (double)dr["AdvanceAmount"];
                        adv.BalanceAmount = (double)dr["DueAmount"];
                        adv.Installments = (Int16)dr["RepaymentMonths"];
                        adv.AdvanceName = string.Concat(dr["AdvanceName"]);
                        adv.Amount = (double)dr["MonthlyAmount"];
                        adv.EmployeeID = pded.EmployeeID;
                        adv.Month = pded.Month;
                        adv.Year = pded.Year;
                        pded.LoanAdvance[k] = adv;
                        k++;
                    }
                }
            }

        }

        public DataTable GetPayrollAdvacnes(string payrollId,int month,int year)
        {

            string mnyr =string.Concat(100 * year + month);
            const String Qry = " SELECT D.ID, A.ID AdvanceID,'' AdvanceName,A.AdvanceAmount Amount,RepaymentMonths,D.Amount MonthlyAmount"
                              + "  , (AdvanceAmount-isnULL(PD.Amount,0)) DueAmount FROM  Salary_Advance A "
                              + " LEFT JOIN  ("
                              + " SELECT AdvanceID,Sum(Amount)Amount From Salary_AdvanceRepayments"
                              + " Group By AdvanceID"
                              + " UNION ALL"
                              + " SELECT DeductionID,SUM(Amount) FROM Employee_Payroll_Deductions SD"
                              + " INNER JOIN Employee_Payroll SP ON SP.ID=SD.PayrollID"
                              + " WHERE DeductionType='ADV' AND (100 * [Year] + [Month]) < {1}  "
                              + " group by DeductionID"
                              + " )PD ON PD.AdvanceID=A.ID  "
                              + " INNER JOIN Employee_Payroll_Deductions D ON D.DeductionID=A.ID"
                              + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID"
                              + "  WHERE P.ID={0} AND DeductionType='ADV' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId, mnyr);
            return EE.ExecuteDataTable(exQry);
           

        }

        public void GetAdvanceForDeduction(int empId, PayrollDeductions pded)
        {
                int monyear= pded.Year*100+pded.Month;
               const String Qry = " SELECT  A.ID,'' AdvanceName,A.AdvanceAmount,RepaymentMonths,MonthlyAmount"
                                 + "  , (AdvanceAmount-isnULL(PD.Amount,0)) DueAmount FROM  Salary_Advance A "
                                 + " LEFT JOIN  ("
	                             + " SELECT AdvanceID,Sum(Amount)Amount From Salary_AdvanceRepayments"
	                             + " Group By AdvanceID"
	                             + " UNION ALL"
	                             + " SELECT DeductionID,SUM(Amount) FROM Employee_Payroll_Deductions D"
	                             + " INNER JOIN Employee_Payroll P ON P.ID=PayrollID"
	                             + " WHERE DeductionType='ADV' AND 100 * [Year] + [Month] < {1}"
	                             + " group by DeductionID"
                                 + " )PD ON PD.AdvanceID=A.ID  WHERE A.EmpID={0} AND Status='CLS' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId,monyear);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (pded == null)
                        pded = new PayrollDeductions();
                    pded.LoanAdvance = new LoanAdvance[dt.Rows.Count];
                    LoanAdvance adv = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        adv = new LoanAdvance();
                        adv.ID = 0;// (int)dr["ID"];
                        adv.DeductionID = (int)dr["ID"];
                        adv.AdvanceAmount = (double)dr["AdvanceAmount"];
                        adv.BalanceAmount = (double)dr["DueAmount"];
                        adv.Installments = (Int16)dr["RepaymentMonths"];
                        adv.AdvanceName = string.Concat(dr["AdvanceName"]);
                        adv.Amount = (double)dr["MonthlyAmount"];
                        adv.EmployeeID = pded.EmployeeID;
                        adv.Month = pded.Month;
                        adv.Year = pded.Year;
                        pded.LoanAdvance[k] = adv;
                        k++;
                    }
                }
            }

        }


        public void GetEmployeeLoanAdvance(int Id, LoanAdvance LoanAdvValue)
        {
            const String Qry = "SELECT D.ID,D.DeductionID,P.Month,P.Year,P.EmployeeID,Amount  " +
                               " FROM Employee_Payroll_Deductions D " +
                               " Inner Join dbo.Employee_Payroll E ON E.ID=D.PayrollID " +
                               " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID " +
                               " INNER JOIN Loan_Request L ON L.ID=D.DeductionID " +
                               " WHERE DeductionType='ADV' And D.ID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Id);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    LoanAdvValue.ID = (int)dr["ID"];
                    LoanAdvValue.DeductionID = (int)dt.Rows[0]["DeductionID"];
                    LoanAdvValue.Month = (int)dr["Month"];
                    LoanAdvValue.Year = (int)dr["Year"];
                    LoanAdvValue.EmployeeID = (int)dr["EmployeeID"];
                    LoanAdvValue.Amount = (double)dr["Amount"];
                }
            }

        }
        public void GetEmployeeLoanAdvance(int month, int year, int empId, LoanAdvance LoanAdvValue)
        {
            const String Qry = "SELECT D.ID,D.DeductionID,P.Month,P.Year,P.EmployeeID,Amount  " +
                               " FROM Employee_Payroll_Deductions D " +
                               " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID " +
                               " INNER JOIN Salary_Advance A ON A.ID=D.DeductionID " +
                               " WHERE DeductionType='ADV' And [Month]={0} AND [Year]={1} AND EmployeeID={2} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year, empId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    LoanAdvValue.ID = (int)dr["ID"];
                    LoanAdvValue.DeductionID = (int)dt.Rows[0]["DeductionID"];
                    LoanAdvValue.Month = (int)dr["Month"];
                    LoanAdvValue.Year = (int)dr["Year"];
                    LoanAdvValue.EmployeeID = (int)dr["EmployeeID"];
                    LoanAdvValue.Amount = (double)dr["Amount"];
                }
            }
        }
        public LoanAdvance[] GetAllEmployeesLoanAdvance(int month, int year)
        {
            const String Qry = "SELECT D.ID,D.DeductionID,P.Month,P.Year,P.EmployeeID,Amount  " +
                               " FROM Employee_Payroll_Deductions D " +
                               " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID " +
                               " INNER JOIN Salary_Advance A ON A.ID=D.DeductionID " +
                               " WHERE DeductionType='ADV' And [Month]={0} AND [Year]={1} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year);
            DataTable dt = EE.ExecuteDataTable(exQry);
            LoanAdvance[] LoanDetails = new LoanAdvance[dt.Rows.Count];
            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new LoanAdvance();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["DeductionID"].ToString() != string.Empty)
                    LoanDetails[i].DeductionID = (int)dt.Rows[i]["DeductionID"];
                if (dt.Rows[i]["EmployeeID"].ToString() != string.Empty)
                    LoanDetails[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                if (dt.Rows[i]["Month"].ToString() != string.Empty)
                    LoanDetails[i].Month = (int)dt.Rows[i]["Month"];
                if (dt.Rows[i]["Year"].ToString() != string.Empty)
                    LoanDetails[i].Year = (int)dt.Rows[i]["Year"];
                if (dt.Rows[i]["Amount"].ToString() != string.Empty)
                    LoanDetails[i].Amount = (Double)dt.Rows[i]["Amount"];
            }
            return LoanDetails;
        }
        public LoanAdvance GetEmpLoanBalanceAdvAmount(int empId)
        {
            const String Qry = " Select MonthlyAmount,AdvanceAmount - sum(P.Amount + R.Amount)  BalanceAmount " +
                               " From dbo.Employee_Payroll_Deductions P " +
                               " INNER JOIN Employee_Payroll P1 ON P1.ID=P.PayrollID " +
                               " Inner Join dbo.Salary_AdvanceRepayments R ON R.ID=P.DeductionID " +
                               " Inner Join dbo.Salary_Advance A ON A.ID=R.AdvanceID WHERE DeductionType='ADV' AND EmployeeID={0} " +
                               " group by  P.Amount, R.Amount ,AdvanceAmount,MonthlyAmount ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId);
            DataTable dt = EE.ExecuteDataTable(exQry);

            LoanAdvance LoanDetails = new LoanAdvance();
            if (dt != null && dt.Rows.Count > 0)
            {
                LoanDetails.Amount = (Double)dt.Rows[0]["MonthlyAmount"];
                LoanDetails.BalanceAmount = (Double)dt.Rows[0]["BalanceAmount"];
                if ((Double)dt.Rows[0]["BalanceAmount"] < (Double)dt.Rows[0]["MonthlyAmount"])
                    LoanDetails.Amount = (Double)dt.Rows[0]["BalanceAmount"];
                else
                    LoanDetails.Amount = (Double)dt.Rows[0]["MonthlyAmount"];
            }
            return LoanDetails;
        }
        
        #endregion
        
        #region Payroll

        public void GetEmployeePayroll(int month, int year, int empId, PayrollDeductions dedudctions)
        {
            const String Qry = "SELECT ID, EmployeeID,[Month],[Year] FROM Employee_Payroll "
                             + " WHERE [Month]={0} AND [Year]={1} AND EmployeeID={2} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year, empId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (dedudctions == null)
                     dedudctions = new PayrollDeductions();
                    dedudctions.PayrollID = (int)dr["ID"];
                    dedudctions.EmployeeID= (int)dr["EmployeeId"];
                    dedudctions.Month = (int)dr["Month"];
                    dedudctions.Year = (int)dr["Year"];
             
                }
            }
        }
        public void GetEmployeePayrollDeductions(int payrollId, PayrollDeductions dedudctions)
        {
            const String Qry = "SELECT D.ID,PayrollID,DeductionID,Name,IsPercentage, Limit, Amount,DeductionType,'' Narration  FROM Employee_Payroll_Deductions D "
                             + " INNER JOIN Master_Salary_Deductions A ON A.ID=D.DeductionID "
                             + " WHERE PayrollID={0} AND DeductionCode NOT IN ('PF','ESI') AND DeductionType Not in ('TAX','EMP')  AND IsEmployeeLevel=0 "
                             + " UNION ALL"
                             + " SELECT D.ID,PayrollID,D.DeductionID,Name,IsPercentage,0 Deduction ,Amount,D.DeductionType,'' Narration FROM Employee_Payroll_Deductions D "
                             + " INNER JOIN Employee_Payroll P ON P.ID=D.PayrollID "
                             + " INNER JOIN Master_Salary_Deductions A ON A.ID=D.DeductionID "
                             //+ " INNER JOIN Assign_Employee_Deductions E ON E.DeductionID=D.DeductionID AND E.EmpID=P.EmployeeID "
                             + " WHERE PayrollID={0} AND DeductionCode NOT IN ('PF','ESI') AND D.DeductionType in ('EMP') AND IsEmployeeLevel=1 ";
            
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dedudctions == null)
                        dedudctions = new PayrollDeductions();
                    dedudctions.OtherDeductions = new OtherDeductions[dt.Rows.Count];
                    OtherDeductions other = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        other = new OtherDeductions();
                        other.ID = (int)dr["ID"];
                        other.DeductionID = (int)dr["DeductionID"];
                        other.DeductionName = string.Concat(dr["Name"]);
                        other.IsPercentage = (bool)dr["IsPercentage"];
                        if (other.IsPercentage)
                        {
                            other.Percentage = (double)dr["Limit"];
                        }
                        other.Deduction = (double)dr["Amount"];
                        other.DeductionType = string.Concat(dr["DeductionType"]);
                        other.Narration= string.Concat(dr["Narration"]); 
                        dedudctions.OtherDeductions[k] = other;
                        k++;
                    }
                }
            }
        }

        public DataTable GetPayrollDeductions(string payrollId)
        {
            const String Qry = "usp_GetPayslipDeductions {0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
           return EE.ExecuteDataTable(exQry);
            
        }


        public void GetPayrollOtherDeductions(double Basic, PayrollDeductions dedudctions)
        {
            const String Qry = "SELECT ID,Name,Limit,IsPercentage,'DED' DeductionType,'' Narration FROM Master_Salary_Deductions " +
                               "WHERE DeductionPeriod='MON' AND IsActive=1 AND IsEmployeeLevel=0 " + 
                               "AND DeductionCode NOT IN ('PF','ESI') " +
                               "UNION ALL " +
                               "SELECT D.ID,Name,Deduction,IsPercentage,'EMP' DeductionType,E.Narration FROM Master_Salary_Deductions D " +
                               "INNER JOIN Assign_Employee_Deductions E ON E.DeductionID=D.ID " + 
                               "WHERE DeductionPeriod='MON' AND E.IsActive=1 AND IsEmployeeLevel=1 " +
                               "AND E.EmpID={0} AND DeductionCode NOT IN ('PF','ESI') " +
                               "UNION ALL " +
                               "SELECT D.ID,Name,Amount Deduction,IsPercentage,'EMP' DeductionType,E.Narration FROM Master_Salary_Deductions D " +
                               "INNER JOIN Assign_Emp_MonthlyDeduction E ON E.DeductionID=D.ID " + 
                               "WHERE E.Month={1} AND E.Year={2} " +
                               "AND E.EmpID={0} AND DeductionCode NOT IN ('PF','ESI') " ; 
            
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, dedudctions.EmployeeID, dedudctions.Month, dedudctions.Year);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dedudctions == null)
                        dedudctions = new PayrollDeductions();
                    dedudctions.OtherDeductions = new OtherDeductions[dt.Rows.Count];
                    OtherDeductions other = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        other = new OtherDeductions();
                        other.DeductionID = (int)dr["ID"];
                        other.DeductionName = string.Concat(dr["Name"]);
                        other.Narration = string.Concat(dr["Narration"]);
                        other.Deduction = (double)dr["Limit"];
                        other.IsPercentage  = (bool)dr["IsPercentage"];
                        if (other.IsPercentage)
                        {
                            other.Percentage= (double)dr["Limit"];
                            other.Deduction = Basic * other.Percentage/100;
                        }
                        other.DeductionType = string.Concat(dr["DeductionType"]); 
                        dedudctions.OtherDeductions[k] = other;
                        k++;
                    }
                }
            }
        }

        public void GetPayrollTaxes(double gross, PayrollDeductions dedudctions)
        {
            
          const String Qry = "SELECT DISTINCT T.ID,TaxName FROM Master_Tax T "
                        + " INNER JOIN MASTER_TAX_SLABS SB ON SB.TaxID=T.ID"
                        + " INNER JOIN (SELECT STATEID FROM MASTER_LOCATION L "
                        + " INNER JOIN  MASTER_BRANCH B ON B.LocationID=L.ID"
                        + " INNER JOIN Assign_emp_branch C ON C.BRANCHID=B.ID "
                        + " WHERE C.EMPID={0} AND C.IsActive=1 AND ActivatedDate=(SELECT MAX(ActivatedDate) FROM Assign_emp_branch WHERE EMPID=C.EMPID   ) )S ON (S.StateID=SB.StateID OR SB.StateID=0)"
                        + " WHERE T.IsActive=1 AND TaxCode NOT IN ('TDS') "
                        + " AND TaxName NOT IN ('TDS') AND IsFixed=0"
                        + " UNION "
                        + " SELECT DISTINCT T.ID,TaxName FROM Master_Tax T" 
                        + " WHERE T.IsActive=1 AND TaxCode NOT IN ('TDS') "
                        + " AND TaxName NOT IN ('TDS') AND IsFixed=1;";
             
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,dedudctions.EmployeeID);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dedudctions == null)
                        dedudctions = new PayrollDeductions();
                    dedudctions.TaxDeduction = new PayrollTax[dt.Rows.Count];
                    PayrollTax tax = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        tax = new PayrollTax(dedudctions.Month, dedudctions.Year, dedudctions.EmployeeID, (int)dr["ID"], gross);
                        dedudctions.TaxDeduction[k] = tax;
                        k++;
                    }
                }
            }
        }
        public void GetPayrollTaxes(PayrollEarnings earnings, PayrollDeductions dedudctions)
        {

            const String Qry = "SELECT DISTINCT T.ID,TaxName FROM Master_Tax T "
                          + " INNER JOIN MASTER_TAX_SLABS SB ON SB.TaxID=T.ID"
                          + " INNER JOIN (SELECT STATEID FROM MASTER_LOCATION L "
                          + " INNER JOIN  MASTER_BRANCH B ON B.LocationID=L.ID"
                          + " INNER JOIN Assign_emp_branch C ON C.BRANCHID=B.ID "
                          + " WHERE C.EMPID={0} AND C.IsActive=1 AND ActivatedDate=(SELECT MAX(ActivatedDate) FROM Assign_emp_branch WHERE EMPID=C.EMPID   ) )S ON (S.StateID=SB.StateID OR SB.StateID=0)"
                          + " WHERE T.IsActive=1 AND TaxCode NOT IN ('TDS','TAX') "
                          + " AND TaxName NOT IN ('TDS') AND IsFixed=0"
                          + " UNION "
                          + " SELECT DISTINCT T.ID,TaxName FROM Master_Tax T"
                          + " WHERE T.IsActive=1 AND TaxCode NOT IN ('TDS','TAX') "
                          + " AND TaxName NOT IN ('TDS') AND IsFixed=1;";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, dedudctions.EmployeeID);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dedudctions == null)
                        dedudctions = new PayrollDeductions();
                    dedudctions.TaxDeduction = new PayrollTax[dt.Rows.Count];
                    PayrollTax tax = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        tax = new PayrollTax(dedudctions.Month, dedudctions.Year, dedudctions.EmployeeID, (int)dr["ID"], earnings);
                        dedudctions.TaxDeduction[k] = tax;
                        k++;
                    }
                }
            }
        }


        public void GetLoanBalance(int month,int year,string empid)
        {

            const String Qry = "SELECT ID,TaxName FROM Master_Tax T " +
                               " LEFT JOIN MASTER_BRANCH B ON B.LOCATIONID=T.LOCATIONID " +
                               " LEFT JOIN Assign_emp_branch C ON C.BRANCHID=B.ID " +
                               "WHERE C.EMPID={0} IsActive=1 AND TaxCode NOT IN ('TDS') AND TaxName NOT IN ('TDS') ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empid);
            DataTable dt = EE.ExecuteDataTable(exQry);
             DataTable dtPay = new DataTable("Payslip");
                dtPay.Columns.Add(new DataColumn("PayrollID", Type.GetType("System.String")));
                dtPay.Columns.Add(new DataColumn("LoanID", Type.GetType("System.String")));
                dtPay.Columns.Add(new DataColumn("LoanName", Type.GetType("System.String")));
                dtPay.Columns.Add(new DataColumn("Amount", Type.GetType("System.String")));
                dtPay.Columns.Add(new DataColumn("AL", Type.GetType("System.String")));
                dtPay.Columns.Add(new DataColumn("CL", Type.GetType("System.String")));
                dtPay.Columns.Add(new DataColumn("SL", Type.GetType("System.String")));
                if (dt != null)
                {


                }
        }
        public void GetEmployeePayrollTaxes(int payrollId, PayrollDeductions dedudctions)
        {
            const String Qry = "SELECT D.ID,PayrollID,DeductionID,TaxName,Amount FROM Employee_Payroll_Deductions D "
                             + " INNER JOIN Master_Tax T ON T.ID=D.DeductionID "
                             + " WHERE PayrollID={0} AND DeductionType in ('TAX') AND TaxCode NOT IN ('TDS') AND TaxName NOT IN ('TDS') ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dedudctions == null)
                        dedudctions = new PayrollDeductions();
                    dedudctions.TaxDeduction = new PayrollTax[dt.Rows.Count];
                    PayrollTax tax = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        tax = new PayrollTax();
                        tax.ID = (int)dr["ID"];
                        tax.TaxID = (int)dr["DeductionID"];
                        tax.TaxName = string.Concat(dr["TaxName"]);
                        tax.Amount = (double)dr["Amount"];
                        dedudctions.TaxDeduction[k] = tax;
                        k++;
                    }
                }
            }
        }

        public double GetTDS(int empId, int fyear)
        {
            const String Qry = "SELECT TDS FROM Payroll_AnnualConfiguration  "
                             + " WHERE FinancialYear={0} AND EmployeeID={1} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, fyear, empId);
            double dbl = 0;
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)),out dbl);
            return dbl;
        }
        public double GetTDS(int empId,double grossSal, int fyear)
        {
            const String Qry = "SELECT TDS FROM Payroll_AnnualConfiguration  "
                             + " WHERE FinancialYear={0} AND EmployeeID={1} AND "
                             + " EmployeeID NOT IN (SELECT EMPID FROM Assign_Employee_Deductions WHERE DeductionType='TAX')"
                             + " UNION "
                             + " SELECT Deduction*{2}/100 FROM Assign_Employee_Deductions WHERE EMPID={1} "
                             + " AND DeductionType='TAX'"
                             + " UNION "
                             + " SELECT Deduction FROM Assign_Employee_Deductions WHERE EMPID={1} "
                             + " AND DeductionType='TDS'"
                             + " UNION "
                             + " SELECT Deduction FROM Assign_Emp_MonthlyDeduction WHERE EMPID={1} "
                             + " AND DeductionType='TDS'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, fyear, empId,grossSal);
            double dbl = 0;
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out dbl);
            return dbl;
        }
        public double GetTDS(int empId, double grossSal, int month,int year)
        {
            const String Qry = " SELECT Deduction*{3}/100 FROM Assign_Employee_Deductions D  "
                             + " INNER JOIN Master_Tax T ON T.ID= D.DeductionID"
                             + " WHERE EMPID={0} AND T.TaxName='Income Tax'"
                             + " AND DeductionType='TAX'"
                             + " UNION "
                             + " SELECT Amount FROM Assign_Emp_MonthlyDeduction WHERE EMPID={0} "
                             + " AND DeductionType='TDS' AND Month={1} AND Year={2}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            string qry1 = "SELECT COUNT(*) FROM Assign_Employee_Deductions WHERE EmpID={0} AND DeductionType='TAX' AND IsActive=1 ";
            exQry.Query = string.Format(qry1, empId);
            int cnt = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            //if (cnt == 0)
            //{
            //    Master_Employees oEmp=new Master_EmployeesBusinessObject().GetMaster_Employees(empId);
            //    if (oEmp != null)
            //    {
            //        if (oEmp.EmploymentType == 4)
            //        {
            //            new Master_EmployeesBusinessObject().AssignEmployeeDeduction(oEmp);
            //        }
            //    }

            //}
            EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId,month,year, grossSal);
            double dbl = 0;
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out dbl);
            return dbl;
        }
        public int GetESIID(int payrollId)
        {

            const String Qry = "SELECT ID FROM Employee_Payroll_Deductions " +
                               "WHERE DeductionType = 'ESI' AND PayrollID={0} "; 

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            int esiid = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)),out esiid);
            
            return esiid;
        }
        public int GetPFID(int payrollId)
        {

            const String Qry = "SELECT ID FROM Employee_Payroll_Deductions " +
                               "WHERE DeductionType = 'PF' AND PayrollID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            int pfid = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out pfid);

            return pfid;
        }
        public int GetLOANID(int payrollId)
        {

            const String Qry = "SELECT ID FROM Employee_Payroll_Deductions " +
                               "WHERE DeductionType = 'LON' AND PayrollID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            int lonid = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out lonid);

            return lonid;
        }
        public int GetADVID(int payrollId)
        {

            const String Qry = "SELECT ID FROM Employee_Payroll_Deductions " +
                               "WHERE DeductionType = 'ADV' AND PayrollID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,payrollId);
            int advid = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out advid);

            return advid;
        }

        public int GetTDSID(int payrollId)
        {

            const String Qry = "SELECT ID FROM Employee_Payroll_Deductions " +
                               "WHERE DeductionType = 'TDS' AND PayrollID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            int tdsid = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out tdsid);

            return tdsid;
        }

        public double GetTDS(int payrollId)
        {

            const String Qry = "SELECT Amount FROM Employee_Payroll_Deductions " +
                               "WHERE DeductionType = 'TDS' AND PayrollID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            double tds = 0;
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out tds);

            return tds;
        }

        #endregion
        #region IncomeTax
        public int GetTDSID(int empId,int finyear)
        {

            const String Qry = "SELECT ID FROM Payroll_AnnualConfiguration WHERE EmployeeID={0} AND FinancialYear={1}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId,finyear);
            int tdsid = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out tdsid);

            return tdsid;
        }

        #endregion
    }
}
