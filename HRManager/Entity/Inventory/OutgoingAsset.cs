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
    public class OutgoingAsset : JGridDataObject
    {
        private int _ID;
        private int _AssetID;
        private DateTime _dtOutgoingDate;
        private String _OutgoingDate;
        private DateTime _ReturningDate;
        private String _Reason;
        private String _AssetName;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private int _UpdatedBy;
        private bool _IsReturned;
        private String _AssetNumber;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int AssetID { get { return _AssetID; } set { _AssetID = value; } }
        public String AssetName { get { return _AssetName; } set { _AssetName = value; } }
        public String AssetNumber { get { return _AssetNumber; } set { _AssetNumber = value; } }
        public DateTime dtOutgoingDate { get { return _dtOutgoingDate; } set { _dtOutgoingDate = value; } }
        public String OutgoingDate { get { return _OutgoingDate; } set { _OutgoingDate = value; } }
        public DateTime ReturningDate { get { return _ReturningDate; } set { _ReturningDate = value; } }
        public String Reason { get { return _Reason; } set { _Reason = value; } }
        public int UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        public bool IsReturned { get { return _IsReturned; } set { _IsReturned = value; } }

         //Constructor
        public OutgoingAsset()
        {
        }
        //Constructor with ID parameter
        //get details using for a primary key ID
        public OutgoingAsset(int ID)
        {
            Update(new Asset_OutgoingDevicesBusinessObject().GetAsset_OutgoingDevices(ID));
        }

        public void Update(Asset_OutgoingDevices DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _AssetID = DTO.AssetID;
                if (DTO.OutgoingDate.Year.Equals(1900))
                {
                    _OutgoingDate = string.Empty;
                }
                else
                {
                    _OutgoingDate = DTO.OutgoingDate.ToString("dd/MM/yyyy");
                }
                _dtOutgoingDate = DTO.OutgoingDate;
               _ReturningDate = DTO.ReturningDate;
                _Reason = DTO.Reason;
                _ModifiedBy = DTO.ModifiedBy;
                _ModifiedDate = DTO.ModifiedDate;
                _CreatedBy = DTO.CreatedBy;
                _CreatedDate = DTO.CreatedDate;
                _IsReturned = DTO.IsReturned;
                if (DTO is Asset_OutgoingDevicesExt)
                {
                    _AssetName = ((Asset_OutgoingDevicesExt)DTO).AssetName;
                    _AssetNumber = ((Asset_OutgoingDevicesExt)DTO).AssetNumber;
                }
            }
        }
        //Getting from DB 
        private Asset_OutgoingDevices GetDTO()
        {
            Asset_OutgoingDevices DTO = new Asset_OutgoingDevices();
            DTO.ID = _ID;
            DTO.AssetID = _AssetID;

            if (_dtOutgoingDate.Year.Equals(0001))
            {
                DTO.OutgoingDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.OutgoingDate = _dtOutgoingDate;
            }
            DTO.Reason = _Reason;
            if (_ReturningDate.Year.Equals(0001))
            {
                DTO.ReturningDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.ReturningDate = _ReturningDate;
            }

            DTO.CreatedBy = _CreatedBy;
            DTO.CreatedDate = _CreatedDate;

            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = DateTime.Now;
            DTO.IsReturned = _IsReturned;
            return DTO;
        }
        public String IsOutgoingAssetReturned(int ID, int AssetID)
        {
            if (new Asset_OutgoingDevicesBusinessObject().IsAssetOutgoing(ID, AssetID))
            {
                return HRManagerDefs.OutgoingAssets.OUGOING_ASSET_EXISTS;
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
                Asset_OutgoingDevicesBusinessObject BO = new Asset_OutgoingDevicesBusinessObject();
                Asset_OutgoingDevices DTO = GetDTO();
                ////check the selected asset is already assign to someone and not at returned,then should not allow to assign
                //bool isExists =  new Assign_AssetesBusinessObject().IsAssetAssigned(_ID, _AssetID);
                //if (isExists)
                //{
                //    return HRManagerDefs.AssignAssets.ASSIGN_ASSET_EXISTS;
                //}
                ////check the selected asset is already outsourced to someone and not at returned,then should not allow to outsource
                //bool isOutExists = new Asset_OutgoingDevicesBusinessObject().IsAssetOutgoing(_ID, _AssetID);
                //if (isOutExists)
                //{
                //    return HRManagerDefs.OutgoingAssets.OUGOING_ASSET_EXISTS;
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

                return String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }
        //Get all Assigned Assets with details for grid display
        public static OutgoingAsset[] GetOutgoingAssetInfo()
        {
            Asset_OutgoingDevicesExt[] RolesDT = new Asset_OutgoingDevicesBusinessObject().GetOutgoingAssets(" IsReturned=0 ");
            OutgoingAsset[] Roles = new OutgoingAsset[RolesDT.Length];
            for (int i = 0; i < Roles.Length; i++)
            {
                Roles[i] = new OutgoingAsset();
                Roles[i].Update(RolesDT[i]);
            }
            return Roles;
        }
        //get the details for particular primary ID with details to display in edit mode
        public OutgoingAsset GetOutgoingAssetInfoDetails(int ID)
        {
            Asset_OutgoingDevicesExt objDT = new Asset_OutgoingDevicesBusinessObject().GetOutgoingAssetInfo(ID);
            OutgoingAsset objAsset = new OutgoingAsset();
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
