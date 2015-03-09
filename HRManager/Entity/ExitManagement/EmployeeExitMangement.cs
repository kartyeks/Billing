using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT;
namespace HRManager.Entity.ExitManagement
{ 
    public class EmployeeExitMangement : JGridDataObject
    {
        private int _ID;
        private int _EmployeeID;
        private int _ExitTypeID;
        private DateTime _ExitDate;
        private String _EmployeeName;
        private String _ExitType;
        private String _DocumentName;
        private String _EmployeeCode;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        public int ExitTypeID { get { return _ExitTypeID; } set { _ExitTypeID = value; } }
        public DateTime ExitDate { get { return _ExitDate; } set { _ExitDate = value; } }
        public String EmployeeName { get { return _EmployeeName; } set { _EmployeeName = value; } }
        public String ExitType { get { return _ExitType; } set { _ExitType = value; } }
        public String DocumentName { get { return _DocumentName; } set { _DocumentName = value; } }
        public String EmployeeCode { get { return _EmployeeCode; } set { _EmployeeCode = value; } }

        public void Update(Exit_Management DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _EmployeeID = DTO.EmployeeID;
                _ExitTypeID = DTO.ExitTypeID;
                _ExitDate = DTO.ExitDate;
                _DocumentName = DTO.DocumentName;
                if (DTO is Exit_ManagementEXT) 
                {
                    _EmployeeName = ((Exit_ManagementEXT)DTO).EmployeeName;
                    _ExitType = ((Exit_ManagementEXT)DTO).ExitType;
                    _EmployeeCode = ((Exit_ManagementEXT)DTO).EmployeeCode;
                }
            }            
        }
        public EmployeeExitMangement()
        {
        }
        public EmployeeExitMangement[] GetEMPExitManagement(int EmployeeID)
        {
            return LoadGrid(new ExitManagementBusinessObject().GetEMPExitManagement(EmployeeID));
        }
        private EmployeeExitMangement[] LoadGrid(Exit_ManagementEXT[] arr)
        {
            EmployeeExitMangement[] EM = new EmployeeExitMangement[arr.Length];

            for (int h = 0; h < arr.Length; h++)
            {
                EmployeeExitMangement ur = new EmployeeExitMangement();
                ur.Update(arr[h]);
                EM[h] = ur;
            }
            return EM;
        }
        #region JGridDataObject Members
        public object GetGridData()
        {
            EMPExitManagermentDisplay DT = new EMPExitManagermentDisplay();
            DT.ID = _ID;
            DT.EmployeeID = _EmployeeID;
            DT.ExitTypeID = _ExitTypeID;
            DT.ExitDate = _ExitDate.ToString("dd/MM/yyyy");
            DT.EmployeeName = _EmployeeName;
            DT.ExitType = _ExitType;
           // DT.NDFormView = "<input id='btn_" + _ID + "' type='button' value='View'  style='background-color: #CC3300; color: #000000;width:100px' onclick='viewDoc(" + _ID + ")'/>";
            DT.DocumentName = _DocumentName;
            DT.EmployeeCode = _EmployeeCode;
            return DT;
        }

        #endregion
    }
    public class EMPExitManagermentDisplay
    {
        public int ID;
        public int EmployeeID;
        public int ExitTypeID;
        public String EmployeeCode;
        public String EmployeeName;
        public String ExitType;
        public String ExitDate;
        //public String NDFormView;
        public String DocumentName;
    }

}
