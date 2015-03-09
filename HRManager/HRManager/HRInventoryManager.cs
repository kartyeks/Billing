using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Entity;
using IRCAKernel;
using IS91.Services;
using IS91.Services.DataBlock;
using HRManager.Entity.Inventory;
using  HRManager.BusinessObjects;

namespace HRManager
{
   public class HRInventoryManager
   {
       #region Manage Assets
       public static ManageAsset[] GetAllManageAssets()
       {
           return ManageAsset.GetAssetMaster();

       }
       public static ManageAsset GetManageAssetInfoDetails(int ID)
       {
           return new ManageAsset().GetManageAssetInfo(ID);
       }
      
       public static String UpdateManageAssets(int ID,string UniqueNumber,string AssetName,int AssetCategID,int AssetSubCategID,int ManufactID,
                                DateTime ManufactDate,DateTime WarrantyDate,string AssetCost,string VendorDetails,
                                int UpdatedBy, bool IsActive)
       {
           try
           {

               ManageAsset objAsset = new ManageAsset(ID);
               objAsset.UniqueNumber = UniqueNumber;
               objAsset.AssetName = AssetName;
               objAsset.AssetCategoryID = AssetCategID;
               objAsset.AssetSubCategoryID = AssetSubCategID;
               objAsset.ManufacturerID = ManufactID;
               objAsset.dtManufacturerDate = ManufactDate;
               objAsset.dtWarrantyDate = WarrantyDate;
               objAsset.AssetCost = AssetCost;
               objAsset.VendorDetails = VendorDetails;
               objAsset.UpdatedBy = UpdatedBy;
               objAsset.IsActive = IsActive;
               String Status = objAsset.Save();
               return Status;

           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.ManageAssets.MANAGE_ASSET_UPDATE_SUCCESS, ID.ToString())
                   );
               return HRManagerDefs.ManageAssets.MANAGE_ASSET_UPDATE_FAILURE;
           }
       }

       public static String DeleteAsset(int ID)
       {
           try
           {
               ManageAsset objAsset = new ManageAsset(ID);
               bool isExists = new Manage_AssetsBusinessObject().IsAssetRefered(ID);
               if (isExists)
               {
                   return HRManagerDefs.ManageAssets.MANAGE_ASSET_REFER;
               }
               objAsset.ID = ID;
               objAsset.IsActive = false;
               String result = objAsset.Save();
               return string.Empty;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.AssetCategoryMessages.ASSET_CATEGORY_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.AssetCategoryMessages.ASSET_CATEGORY_UPDATE_FAILURE;
           }
       }

       #endregion

    # region Assign Assets
      

       public static AssignAsset[] GetAllAssignAssets()
       {
           return AssignAsset.GetAssignAssetInfo();

       }
       public static AssignAsset GetAssignAssetInfoDetails(int ID)
       {
           return new AssignAsset().GetAssignAssetInfoDetails(ID);
       }
       public static String UpdateAssignAssets(int ID, int AssetID, bool IsTeamAssigned, int TeamID, int EmployeeID, DateTime IssuedDate,
                              String Reason, bool IsReturned, DateTime ReturnedDate, string Comments,string LocationOfAsset,int UpdatedBy)
       {
           try
           {

               AssignAsset objAsset = new AssignAsset(ID);
               objAsset.AssetID = AssetID;
               objAsset.IsTeamAssigned = IsTeamAssigned;
               objAsset.TeamID = TeamID;
               objAsset.EmployeeID = EmployeeID;
               objAsset.dtIssuedDate = IssuedDate;
               objAsset.Reason = Reason;
               objAsset.IsReturned = IsReturned;
               objAsset.ReturnedDate = ReturnedDate;
               objAsset.Comments = Comments;
               objAsset.LocationOfAsset = LocationOfAsset;
               objAsset.UpdatedBy = UpdatedBy;
               String Status = objAsset.Save();
               return Status;

           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.ManageAssets.MANAGE_ASSET_UPDATE_SUCCESS, ID.ToString())
                   );
               return HRManagerDefs.ManageAssets.MANAGE_ASSET_UPDATE_FAILURE;
           }
       }
     #endregion

# region outgoing Asset Devices
       public static OutgoingAsset[] GetAllOutgoingAssets()
       {
           return OutgoingAsset.GetOutgoingAssetInfo();

       }
       public static OutgoingAsset GetOutgoingAssetInfoDetails(int ID)
       {
           return new OutgoingAsset().GetOutgoingAssetInfoDetails(ID);
       }
       public static String UpdateOutgoingAssets(int ID, int AssetID, DateTime OutgoingDate, DateTime ReturningDate, string Reason,int UpdatedBy,bool isReturned)
       {
           try
           {

               OutgoingAsset objAsset = new OutgoingAsset(ID);
               objAsset.AssetID = AssetID;
               objAsset.dtOutgoingDate = OutgoingDate;
               objAsset.ReturningDate = ReturningDate;
               objAsset.Reason = Reason;
               objAsset.UpdatedBy = UpdatedBy;
               objAsset.IsReturned = isReturned;
               String Status = objAsset.Save();
               return Status;

           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.OutgoingAssets.OUTGOING_ASSET_UPDATE_SUCCESS, ID.ToString())
                   );
               return HRManagerDefs.OutgoingAssets.OUTGOING_ASSET_UPDATE_FAILURE;
           }
       }
 #endregion


   }
}
