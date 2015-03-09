using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;
using IS91.Services.DataBlock;
using System.Collections;
using System.Data;
using HRManager.DTOEXT.Inventory;

namespace HRManager.Entity.Inventory
{
    public class AssignAsset : JGridDataObject
    {
        private int _ID;
        private int _AssetID;
        private bool _IsTeamAssigned;
        private int _TeamID;
        private int _EmployeeID;
        private DateTime _dtIssuedDate;
        private String _IssuedDate;
        private String _Reason;
        private bool _IsReturned;
        private DateTime _ReturnedDate;
        private string _Comments;
        private string _LocationOfAsset;
        private String _AssetName;
        private String _TeamName;
        private String _ManagerName;
        private String _UserName;
        private String _AssetNumber;

        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private int _UpdatedBy;

        //Set the property
        public int ID { get { return _ID; } set { _ID = value; } }
        public int AssetID { get { return _AssetID; } set { _AssetID = value; } }
        public bool IsTeamAssigned { get { return _IsTeamAssigned; } set { _IsTeamAssigned = value; } }
        public int TeamID { get { return _TeamID; } set { _TeamID = value; } }
        public int EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        public String AssetName { get { return _AssetName; } set { _AssetName = value; } }
        public String AssetNumber { get { return _AssetNumber; } set { _AssetNumber = value; } }
        public String TeamName { get { return _TeamName; } set { _TeamName = value; } }
        public String ManagerName { get { return _ManagerName; } set { _ManagerName = value; } }
        public String UserName { get { return _UserName; } set { _UserName = value; } }
        public DateTime dtIssuedDate { get { return _dtIssuedDate; } set { _dtIssuedDate = value; } }
        public String IssuedDate { get { return _IssuedDate; } set { _IssuedDate = value; } }
        public String Reason { get { return _Reason; } set { _Reason = value; } }
        public bool IsReturned { get { return _IsReturned; } set { _IsReturned = value; } }
        public DateTime ReturnedDate { get { return _ReturnedDate; } set { _ReturnedDate = value; } }
        public String LocationOfAsset { get { return _LocationOfAsset; } set { _LocationOfAsset = value; } }
        public String Comments { get { return _Comments; } set { _Comments = value; } }
        public int UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

        //Constructor
        public AssignAsset()
        {
        }
        //Constructor with ID parameter
        //get details using for a primary key ID
        public AssignAsset(int ID)
        {
            Update(new Assign_AssetesBusinessObject().GetAssign_Assetes(ID));
        }
         public void Update(Assign_Assetes DTO)
         {
             if (DTO != null)
             {
                 _ID = DTO.ID;
                 _AssetID = DTO.AssetID;
                 _TeamID = DTO.TeamID;
                 _IsTeamAssigned = DTO.IsTeamAssigned;
                 _EmployeeID = DTO.EmployeeID;
                 if (DTO.IssuedDate.Year.Equals(1900))
                 {
                     _IssuedDate = string.Empty;
                 }
                 else
                 {
                     _IssuedDate = DTO.IssuedDate.ToString("dd/MM/yyyy");
                 }
                 _Reason = DTO.Reason;
                 _IsReturned = DTO.IsReturned;
                 _ReturnedDate = DTO.ReturnedDate;
                 _Comments = DTO.Comments;
                 _LocationOfAsset = DTO.LocationOfAsset;
                 _dtIssuedDate = DTO.IssuedDate;

                 
                 _ModifiedBy = DTO.ModifiedBy;
                 _ModifiedDate = DTO.ModifiedDate;
                 _CreatedBy = DTO.CreatedBy;
                 _CreatedDate = DTO.CreatedDate;
                 //get the extended dto fields which are not exist in table
                 if (DTO is Assign_AssetesExt)
                 {
                     _AssetName = ((Assign_AssetesExt)DTO).AssetName;
                     _AssetNumber = ((Assign_AssetesExt)DTO).AssetNumber;
                     _TeamName = ((Assign_AssetesExt)DTO).TeamName;
                     _ManagerName = ((Assign_AssetesExt)DTO).ManagerName;
                     _UserName = ((Assign_AssetesExt)DTO).UserName;
                 }
             }
         }

        //Getting from DB 
         private Assign_Assetes GetDTO()
         {
             Assign_Assetes DTO = new Assign_Assetes();
             DTO.ID = _ID;
             DTO.AssetID = _AssetID;
             DTO.IsTeamAssigned = _IsTeamAssigned;
             DTO.TeamID = _TeamID;
             DTO.EmployeeID = _EmployeeID;
             if (_dtIssuedDate.Year.Equals(0001))
             {
                 DTO.IssuedDate = Convert.ToDateTime("1900-01-01");
             }
             else
             {
                 DTO.IssuedDate = _dtIssuedDate;
             }
             DTO.Reason = _Reason;
             DTO.IsReturned = _IsReturned;

             if (_ReturnedDate.Year.Equals(0001))
             {
                 DTO.ReturnedDate = Convert.ToDateTime("1900-01-01");
             }
             else
             {
                 DTO.ReturnedDate = _ReturnedDate;
             }
             DTO.LocationOfAsset = _LocationOfAsset;
             DTO.Comments = _Comments;
             DTO.CreatedBy = _CreatedBy;
             DTO.CreatedDate = _CreatedDate;
      
             DTO.ModifiedBy = _ModifiedBy;
             DTO.ModifiedDate = DateTime.Now;
             return DTO;
         }

         public String IsAssetAssigned(int ID, int AssetID)
         {
             if (new Assign_AssetesBusinessObject().IsAssetAssigned(ID, AssetID))
             {
                 return HRManagerDefs.AssignAssets.ASSIGN_ASSET_EXISTS;
             }
             else
             {
                 return "false";
             }
         }
        
        //Saving in DB with details
         public String Save()
         {
             try
             {
                 Assign_AssetesBusinessObject BO = new Assign_AssetesBusinessObject();
                 Assign_Assetes DTO = GetDTO();
                 //check the selected asset is already to someone and not at returned,then should not allow to assign
                 //bool isExists = BO.IsAssetAssigned(_ID, _AssetID);
                 //if (isExists)
                 //{
                 //    return HRManagerDefs.AssignAssets.ASSIGN_ASSET_EXISTS;
                 //}
                 if (_ID != 0)
                 {
                     DTO.ModifiedBy = _UpdatedBy;
                     DTO.ModifiedDate = DateTime.Now;
                     BO.Update(DTO);
                 }
                 else
                 {
                     DTO.CreatedDate = DateTime.Now;
                     DTO.CreatedBy = _UpdatedBy;
                    _ID = BO.Create(DTO);
                 }

                 return  String.Empty;
             }
             catch (Exception ex)
             {
                 IRCAExceptionHandler.HandleException(ex);
                 return ex.Message;
             }
         }
        //Get all Assigned Assets with details for grid display
         public static AssignAsset[] GetAssignAssetInfo()
         {
             Assign_AssetesExt[] RolesDT = new Assign_AssetesBusinessObject().GetAssignAssets(" IsReturned=0");
             AssignAsset[] Roles = new AssignAsset[RolesDT.Length];
             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new AssignAsset();
                 Roles[i].Update(RolesDT[i]);
             }
             return Roles;
         }
        //get the details for particular primary ID with details to display in edit mode
         public AssignAsset GetAssignAssetInfoDetails(int ID)
         {
             Assign_AssetesExt objDT = new Assign_AssetesBusinessObject().GetAssignAssetInfo(ID);
             AssignAsset objAsset = new AssignAsset();
             objAsset.Update(objDT);
             return objAsset;
         }
         #region JGridDataObject Members

         public object GetGridData()
         {
             return this;
         }

         #endregion
    }
}
