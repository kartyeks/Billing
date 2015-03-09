using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
  public  class UpdateSalaryDedctionRequest
    {
        public int ID;
        public string Name;
        public string DeductionCode;
        public string Period;
        public bool IsPercentage;
        public bool IsEmployee;
        public double Limit;
        public string Code;
        public bool IsActive;
        public bool IsTaxExempted;
        public int UpdateBy;
    }
  public class UpdateSalaryAllowanceRequest
  {
      public int ID;
      public string AllowanceName;
      public string AllowanceCode;
      public string AllowancePeriod;
      public bool IsPercentage;
      public bool IsActive;
      public bool IsTaxExempted;
      public int UpdateBy;
      public bool IsOptional;
      public bool IsAllowance;
      public int DisplayOrder;
      public bool IsOneMonthBasic;
      public Double Value;
  }
}
