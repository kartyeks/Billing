using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.Entity;
using System.Data;
namespace HRManager.Entity
{
    /// <summary>
    /// Represents Payroll Earinngs fields and methods.
    /// </summary>
    public class PayrollSession 
    {
        private static PayrollSession _payrollsession;
        private Dictionary<String ,Payrolls[]>  _SessionPayroll;
        private Dictionary<String, TDSValues[]> _SessionTDS;
        
        
        public static PayrollSession CreatePayrollSession()
        {
            if(_payrollsession==null)
            {
                _payrollsession=new PayrollSession();
            }
            
            return _payrollsession;
        }

        public EmployeePayroll[]  GetEmployeePayroll(string sessonId,string uniqueId)
        {
            if(_payrollsession==null)
            {
                return null;
            }
            if (_payrollsession._SessionPayroll == null)
                return null;
            if(_payrollsession._SessionPayroll.ContainsKey(sessonId))
            {
              Payrolls[] _payroll= _payrollsession._SessionPayroll[sessonId];
              Payrolls _pay= Array.Find(_payroll,(x)=>(x.UniqueID==uniqueId));
              if(_pay!=null)
                return _pay.EmployeePays;
            }
            return null;
        }

        public DataTable GetEmployeeTDS(string sessonId, string uniqueId)
        {
            if (_payrollsession == null)
            {
                return null;
            }
            if (_payrollsession._SessionTDS== null)
                return null;
            if (_payrollsession._SessionTDS.ContainsKey(sessonId))
            {
                TDSValues[] _tdsval = _payrollsession._SessionTDS[sessonId];
                TDSValues _tds = Array.Find(_tdsval, (x) => (x.UniqueID == uniqueId));
                if (_tds != null)
                    return _tds.dtTDS;
            }
            return null;
        }

        public void  AddEmployeePayroll(string sessonId,string uniqueId,EmployeePayroll[] empPay )
        {
            if(_payrollsession==null)
            {
                return ;
            }
            if (_payrollsession._SessionPayroll == null)
                _payrollsession._SessionPayroll = new Dictionary<string, Payrolls[]>();

            if(_payrollsession._SessionPayroll.ContainsKey(sessonId))
            {
               Payrolls[] _pay = _payrollsession._SessionPayroll[sessonId];
               Payrolls epay=new Payrolls(uniqueId,empPay);
               int k = Array.FindIndex(_pay, (x) => (x.UniqueID == uniqueId));
               if (k > -1)
                   _pay[k] = epay;
               else
               {
                    int m = _pay.Length;
                    Array.Resize<Payrolls>(ref _pay,m+1);
                   _pay[m] = epay;
               }
               _payrollsession._SessionPayroll.Clear();
               _payrollsession._SessionPayroll.Add(sessonId, _pay); 
            }
            else
            {
                Payrolls[] _pay=new Payrolls[1];
                Payrolls epay=new Payrolls(uniqueId,empPay);
                _pay[0]=epay;             
                _payrollsession._SessionPayroll.Add(sessonId,_pay);
            }
        }
        public void AddEmployeeTDS(string sessonId, string uniqueId, DataTable dtTDS)
        {
            if (_payrollsession == null)
            {
                return;
            }
            if (_payrollsession._SessionTDS == null)
                _payrollsession._SessionTDS = new Dictionary<string,TDSValues[]>();

            if (_payrollsession._SessionTDS.ContainsKey(sessonId))
            {
                TDSValues[] _payTDS = _payrollsession._SessionTDS[sessonId];
                TDSValues _tds = new TDSValues(uniqueId, dtTDS);
                int k = Array.FindIndex(_payTDS, (x) => (x.UniqueID == uniqueId));
                if (k > -1)
                    _payTDS[k] = _tds;
                else
                {
                    int m = _payTDS.Length;
                    Array.Resize<TDSValues>(ref _payTDS, m + 1);
                    _payTDS[m] = _tds;
                }
                _payrollsession._SessionTDS.Clear();
                _payrollsession._SessionTDS.Add(sessonId, _payTDS);
            }
            else
            {
                TDSValues[] _payTDs = new TDSValues[1];
                TDSValues _tds = new TDSValues(uniqueId, dtTDS);
                _payTDs[0] = _tds;
                _payrollsession._SessionTDS.Add(sessonId, _payTDs);
            }
        }

        private PayrollSession()
        {

        }

        public void RemovePayrollSession(string sessonId,string uniqueId)
        {
            if (_payrollsession == null)
            {
                return;
            }
            if (_payrollsession._SessionPayroll == null)
                return;

            if (_payrollsession._SessionPayroll.ContainsKey(sessonId))
            {
                Payrolls[] _pay = _payrollsession._SessionPayroll[sessonId];
                if(_pay.Length>1)
                {
                    int k = Array.FindIndex(_pay, (x) => (x.UniqueID == uniqueId));
                    List<Payrolls> lst = new List<Payrolls>(_pay);
                    lst.RemoveAt(k);
                    _pay = lst.ToArray();
                }
                else
                {
                    _payrollsession._SessionPayroll.Remove(sessonId);
                }
                
                
            }
        }

        public void RemoveTDSSession(string sessonId, string uniqueId)
        {
            if (_payrollsession == null)
            {
                return;
            }
            if (_payrollsession._SessionTDS == null)
                return;

            if (_payrollsession._SessionTDS.ContainsKey(sessonId))
            {
                TDSValues[] _tds = _payrollsession._SessionTDS[sessonId];
                if (_tds.Length > 1)
                {
                    int k = Array.FindIndex(_tds, (x) => (x.UniqueID == uniqueId));
                    List<TDSValues> lst = new List<TDSValues>(_tds);
                    lst.RemoveAt(k);
                    _tds = lst.ToArray();
                }
                else
                {
                    _payrollsession._SessionPayroll.Remove(sessonId);
                }


            }
        }
       
    }

   public class Payrolls
   {
       private string _uniqueId;
       private EmployeePayroll[] _empPay;

       public  string UniqueID
       {
           get
           {
               return _uniqueId;
           }
           
       }
       public EmployeePayroll[] EmployeePays
       {
           get
           {
               return _empPay;
           }
           
       }
       public Payrolls(string uniId,EmployeePayroll[] epays )
       {
            _uniqueId=uniId;
           _empPay=epays;
       }

   }

   public class TDSValues
   {
       private string _uniqueId;
       private DataTable _dtTDS;

       public string UniqueID
       {
           get
           {
               return _uniqueId;
           }

       }
       public DataTable dtTDS
       {
           get
           {
               return _dtTDS;
           }

       }
       public TDSValues(string uniId, DataTable dtTDSVal)
       {
           _uniqueId = uniId;
           _dtTDS= dtTDSVal;
       }

   }
}
