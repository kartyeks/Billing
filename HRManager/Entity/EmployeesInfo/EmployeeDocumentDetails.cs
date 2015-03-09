using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;

namespace HRManager.Entity.EmployeesInfo
{
    public class EmployeeDocument : EmployeeInfoList
    {
        public EmployeeDocument(int EmployeeID)
        {
            Employee_DocumentsBusinessObject BO = new Employee_DocumentsBusinessObject();
            Employee_Documents[] DTO = BO.GetDocuments(EmployeeID);
            for (int i = 0; i < DTO.Length; i++)
            {
                EmployeeDocumentDetails Edu = new EmployeeDocumentDetails();
                Edu.Update(DTO[i]);
                Add(Edu);
            }
        }

        public EmployeeDocument()
        {

        }

        public override String Delete(int EmployeeID)
        {
            try
            {
                new Employee_DocumentsBusinessObject().Delete(EmployeeID);
                return String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }
    }

   public class EmployeeDocumentDetails: EmployeeInfo
    {
        private int _ID = 0;
        private int _EmployeeID = 0;
        private String _DocumentTitle;
        private String _DocumentName;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        public String DocumentTitle { get { return _DocumentTitle; } set { _DocumentTitle = value; } }
        public String DocumentName { get { return _DocumentName; } set { _DocumentName = value; } }

        internal void Update(Employee_Documents DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _EmployeeID = DTO.EmployeeID;
                _DocumentName = DTO.DocumentName;
                _DocumentTitle = DTO.DocumentTitle;
            }
        }

        public String Save()
        {
            return String.Empty;
        }
       #region JGridDataObject Members

       public object GetGridData()
       {
           return this;
       }

       #endregion
    }
}
