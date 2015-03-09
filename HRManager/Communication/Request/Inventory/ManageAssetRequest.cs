using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request.Inventory
{
  public  class ManageAssetRequest
    {
        public int ID;
        public String UniqueNumber;
        public String AssetName;
        public int AssetCategoryID;
        public int AssetSubCategoryID;
        public int ManufacturerID;
        public DateTime ManufacturerDate;
        public DateTime WarrantyDate;
        public String AssetCost;
        public String VendorDetails;
        public bool IsActive;
        public int UpdatedBy;
       
    }
}
