using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Entity.EmployeesInfo;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services;
using IS91.Services.DataBlock;

namespace HRManager
{
    public class HREmployeeManager
    {
        public static String DeleteEmployee(int RequestID)
        {
            Master_Employees em = new Master_EmployeesBusinessObject().GetMaster_Employees(RequestID);
            em.IsDeleted = true;
            EmployeePersonalDetails e = new EmployeePersonalDetails();
            e.Update(em);
            return e.Save();
        }

        public static CTCDetails CalculateCTCDetails(Double CTC)
        {
            CTCDetails DTO = new CTCDetails();
            Master_Salary_Allowance[] Allowance = new Master_Salary_AllowanceBusinessObject().GetMaster_Salary_Allowance();
            Master_Salary_Deductions[] Deductions = new Master_Salary_DeductionsBusinessObject().GetMaster_Salary_Deductions();
            double tot = 0;
            foreach (Master_Salary_Allowance a in Allowance)
            {
                double val = 0;
                
                if (a.IsPercentage)
                {
                    val = a.Value/100 *CTC*0.40;
                }
                else
                {
                    val = a.Value;
                }
                if (a.IsOneMonthBasic)
                {
                    val = CTC * 0.40/12 ;
                }
                
                if (a.AllowanceCode == "HRA")
                {
                    DTO.HRA = val.ToString("0.00");
                    tot += val;
                }
                else if (a.AllowanceCode == "CON")
                {
                    DTO.CON = val.ToString("0.00");
                    tot += val;
                }
                else if (a.AllowanceCode == "LTA")
                {
                    DTO.LTA = val.ToString("0.00");
                    tot += val;
                }
                else if (a.AllowanceCode == "MED")
                {
                    DTO.MED = val.ToString("0.00");
                    tot += val;
                }
            }
            foreach (Master_Salary_Deductions d in Deductions)
            {
                double val = 0;
                if (d.IsPercentage)
                {
                    val = d.Limit/100*CTC*0.40;
                }
                else
                {
                    val = d.Limit;
                }
                if (d.DeductionCode == "PF")
                {
                    DTO.PF = val.ToString("0.00");
                    tot += val;
                }
            }
            DTO.SPL =(CTC - ((CTC * 0.40) + tot)).ToString("0.00");
            return DTO;
        }
        //public static Employees[] GetEmpDeptWise(int Dept)
        //{
        //    return Employees.GetEmpDeptWise(Dept);
        //}
    }
    //Data Structure For CTC Details

    public class CTCDetails
    {
        public String HRA;
        public String SPL;
        public String CON;
        public String LTA;
        public String MED;
        public String PF;

        public String GetValue(String code)
        {
            if (code == "HRA")
            {
                return HRA;
            }
            else if (code == "SPL")
            {
                return SPL;
            }
            else if (code == "CON")
            {
                return CON;
            }
            else if (code == "LTA")
            {
                return LTA;
            }
            else if (code == "MED")
            {
                return MED;
            }
            else
            {
                return PF;
            }
        }

    }

}