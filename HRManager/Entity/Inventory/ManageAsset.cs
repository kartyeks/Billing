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
    public class ManageAsset : JGridDataObject
    {
        private int _ID;
        private String _UniqueNumber;
        private String _AssetName;
        private int _AssetCategoryID;
        private int _AssetSubCategoryID;
        private int _ManufacturerID;
        private DateTime _dtManufacturerDate;
        private DateTime _dtWarrantyDate;
        private String _AssetCost;
        private String _VendorDetails;
        private bool _IsActive;
        private string _ManufacturerDate;
        private string _WarrantyDate;

        private string _AssetCategName;
        private string _AssetSubCateg;
        private string _ManufacturerName;

        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private int _UpdatedBy;


        public int ID { get { return _ID; } set { _ID = value; } }
        public String UniqueNumber { get { return _UniqueNumber; } set { _UniqueNumber = value; } }
        public String AssetName { get { return _AssetName; } set { _AssetName = value; } }
        public int AssetCategoryID { get { return _AssetCategoryID; } set { _AssetCategoryID = value; } }
        public int AssetSubCategoryID { get { return _AssetSubCategoryID; } set { _AssetSubCategoryID = value; } }
        public int ManufacturerID { get { return _ManufacturerID; } set { _ManufacturerID = value; } }
        public String AssetCategName { get { return _AssetCategName; } set { _AssetCategName = value; } }
        public String AssetSubCateg { get { return _AssetSubCateg; } set { _AssetSubCateg = value; } }
        public String ManufacturerName { get { return _ManufacturerName; } set { _ManufacturerName = value; } }
        public DateTime dtManufacturerDate { get { return _dtManufacturerDate; } set { _dtManufacturerDate = value; } }
        public DateTime dtWarrantyDate { get { return _dtWarrantyDate; } set { _dtWarrantyDate = value; } }
        public String ManufacturerDate { get { return _ManufacturerDate; } set { _ManufacturerDate = value; } }
        public String WarrantyDate { get { return _WarrantyDate; } set { _WarrantyDate = value; } }
        public String AssetCost { get { return _AssetCost; } set { _AssetCost = value; } }
        public String VendorDetails { get { return _VendorDetails; } set { _VendorDetails = value; } }

       


        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        public int UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
       
        public ManageAsset()
        {
        }
        public ManageAsset(int ID)
        {
            Update(new Manage_AssetsBusinessObject().GetManage_Assets(ID));
        }
        public void Update(Manage_Assets DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _UniqueNumber = DTO.UniqueNumber;
                _AssetName = DTO.AssetName;
                _AssetCategoryID = DTO.AssetCategoryID;
                _AssetSubCategoryID = DTO.AssetSubCategoryID;
                _ManufacturerID = DTO.ManufacturerID;
                if (DTO.ManufacturerDate.Year.Equals(1900))
                {
                    _ManufacturerDate = string.Empty;
                }
                else
                {
                    _ManufacturerDate = DTO.ManufacturerDate.ToString("dd/MM/yyyy");
                }
                if (DTO.WarrantyDate.Year.Equals(1900))
                {
                    _WarrantyDate = string.Empty;
                }
                else
                {
                    _WarrantyDate = DTO.WarrantyDate.ToString("dd/MM/yyyy");
                }

                //_ManufacturerDate = DTO.ManufacturerDate;
                //_WarrantyDate = DTO.WarrantyDate;
                _dtManufacturerDate = DTO.ManufacturerDate;
                _dtWarrantyDate = DTO.WarrantyDate;
                _AssetCost = DTO.AssetCost;
                _VendorDetails = DTO.VendorDetails;
                _IsActive = DTO.IsActive;
                _ModifiedBy = DTO.ModifiedBy;
                _ModifiedDate = DTO.ModifiedDate;
                _CreatedBy = DTO.CreatedBy;
                _CreatedDate = DTO.CreatedDate;

                //get the extended dto fields which are not exist in table
                if (DTO is Manage_AssetsExt)
                {
                    _AssetCategName = ((Manage_AssetsExt)DTO).AssetCategName;
                    _AssetSubCateg = ((Manage_AssetsExt)DTO).AssetSubCateg;
                    _ManufacturerName = ((Manage_AssetsExt)DTO).ManufacturerName;
                }
            }
        }
        private Manage_Assets GetDTO()
        {
            Manage_Assets DTO = new Manage_Assets();
            DTO.ID = _ID;
            DTO.UniqueNumber = _UniqueNumber;
            DTO.AssetName = _AssetName;
            DTO.AssetCategoryID = _AssetCategoryID;
            DTO.AssetSubCategoryID = _AssetSubCategoryID;
            DTO.ManufacturerID = _ManufacturerID;
            if (_dtManufacturerDate.Year.Equals(0001))
            {
                DTO.ManufacturerDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.ManufacturerDate = _dtManufacturerDate;
            }
            if (_dtWarrantyDate.Year.Equals(0001))
            {
                DTO.WarrantyDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.WarrantyDate = _dtWarrantyDate;
            }
            DTO.AssetCost = _AssetCost;
            DTO.VendorDetails = _VendorDetails;
            DTO.CreatedBy = _CreatedBy;
            DTO.CreatedDate = _CreatedDate;
            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = _ModifiedDate;
            DTO.IsActive = _IsActive;
            if (DTO.ID == 0)
            {
                byte[] code = null;
                code = new byte[1000 * 1000 * 3];
                DTO.BarCode = code;
                DTO.CreatedBy = _UpdatedBy;
                DTO.CreatedDate = DateTime.Now;
            }
            else
            {
                if (DTO.BarCode.Length == 0)
                {
                    byte[] code = null;
                    code = new byte[1000 * 1000 * 3];
                    DTO.BarCode = code;
                }
            }
           
            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = DateTime.Now;

            return DTO;
        }

        public String Save()
        {
            try
            {
                Manage_AssetsBusinessObject BO = new Manage_AssetsBusinessObject();
                Manage_Assets DTO = GetDTO();

                //bool isExists = BO.IsAssetNameExists(_AssetName, _ID);
                //if (isExists)
                //{
                //    return HRManagerDefs.ManageAssets.MANAGE_ASSET_EXISTS;
                //}
                if (_ID != 0)
                {
                    BO.Update(DTO);
                }
                else
                {
                   string prfx= IS91.Services.Common.GetAppSetting("AssetUniqueNo");
                   string nxtno = BO.GetNextAssetUniquember(prfx);
                   _UniqueNumber = prfx + nxtno;
                    DTO.UniqueNumber = _UniqueNumber;
                    _ID = BO.Create(DTO);
                }

                return _UniqueNumber;// String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }

        ////Get all Assigned Assets with details for grid display
        //public static ManageAsset[] GetManagedAssetInfo(int ID)
        //{
        //    Manage_AssetsExt[] RolesDT = new Manage_AssetsBusinessObject().GetManageAssets(ID);
        //    ManageAsset[] Roles = new ManageAsset[RolesDT.Length];
        //    for (int i = 0; i < Roles.Length; i++)
        //    {
        //        Roles[i] = new ManageAsset();
        //        Roles[i].Update(RolesDT[i]);
        //    }
        //    return Roles;
        //}
        public static ManageAsset[] GetAssetMaster()
        {
            Manage_AssetsExt[] RolesDT = new Manage_AssetsBusinessObject().GetAssetMaster("M.IsActive = 1");

            ManageAsset[] Roles = new ManageAsset[RolesDT.Length];

            for (int i = 0; i < Roles.Length; i++)
            {
                Roles[i] = new ManageAsset();

                Roles[i].Update(RolesDT[i]);
            }

            return Roles;
        }


        public ManageAsset GetManageAssetInfo(int AssetID)
        {
            Manage_Assets EdusDT = new Manage_AssetsBusinessObject().GetManageAssetInfo(AssetID);

            ManageAsset edu = new ManageAsset();
            edu.Update(EdusDT);

            return edu;
        }


        #region JGridDataObject Members

        public object GetGridData()
        {
            return this;
        }

        #endregion
    }
}
