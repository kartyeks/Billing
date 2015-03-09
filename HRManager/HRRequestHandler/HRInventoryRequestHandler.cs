using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.Communication.Request;
using HRManager.DTO;
using HRManager.Entity.Inventory;
using IRCAKernel;
using System.Configuration;
using HRManager.BusinessObjects;
using HRManager.Communication.Request.Inventory;

namespace HRManager
{
    public class HRInventoryRequestHandler : IRCARequestHandler
    {
        public override string[] GetCommands()
        {
            if (_Commands.ContainsKey(typeof(InventoryAppCommands).Name))
            {
                return _Commands[typeof(InventoryAppCommands).Name].ToArray();
            }

            return new String[0];
        }
         public override CommunicationObject ProcessRequest(string RequestCommand, string RequestData)
        {

            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);

            try
            {
                if (RequestCommand == InventoryAppCommands.MANAGEASSET_GRID)
                {
                    Response = GetManageAssetDetailsGrid(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.UPDATE_MANAGEASSET)
                {
                    Response = UpdateManageAssets(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.DELETE_MANAGEASSET)
                {
                    Response = DeleteManageAsset(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.ASSET_CATEGORY_COMBO)
                {
                    Response = AsstCategoryCombo(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.ASSET_SUBCATEGORY_COMBO)
                {
                   Response = AssetSubCategoryCombo(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.ASSET_MANUFACTURER_COMBO)
                {
                   Response = ManufactureCombo(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.MANAGEASSET_INFO)
                {
                    Response = GetManagementAssetInfo(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.ASSIGNASSET_GRID)
                {
                  Response = GetAssignAssetDetailsGrid(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.UPDATE_ASSIGNASSET)
                {
                    Response = UpdateAssignAssets(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.ASSIGNASSET_INFO)
                {
                   Response = GetAssignAssetInfo(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.ASSET_COMBO)
                {
                    Response = AssetCombo(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.OUTGOINGASSET_GRID)
                {
                  Response = GetOutgoingAssetDetailsGrid(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.UPDATE_OUTGOINGASSET)
                {
                    Response = UpdateOutgoingAssets(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.OUTGOINGASSET_INFO)
                {
                    Response = GetOutgoingAssetInfo(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.ISASSET_ASSIGNED)
                {
                    Response = CheckIsAssetAssigned(RequestDataObject);
                }
                else if (RequestCommand == InventoryAppCommands.ISASSET_ALLOCATED)
                {
                    Response = CheckIsAssetAllocated(RequestDataObject);
                }
            }
            catch (IRCAException ex)
            {
                IRCAExceptionHandler.HandleException(ex);
            }
            catch (Exception ex)
            {
                Response = new CommunicationObject();
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Unknown Application Error");

                IRCAException Exception = new IRCAException(ex, WebResponse.Message, "Request Command = " + RequestCommand + "\n Request Data " + RequestData);

                IRCAExceptionHandler.HandleException(Exception);
            }

            return Response;
        }
      #region Manage Asset
        private CommunicationObject GetManagementAssetInfo(CommunicationObject RequestDataObject)
         {
             CommunicationObject Response = new CommunicationObject();

             EntityRequest Request = new EntityRequest();

             RequestDataObject.UpdateDataObject(Request);

             ManageAsset result =HRInventoryManager.GetManageAssetInfoDetails(Convert.ToInt32(Request.ID));

             if (result != null)
             {
                 Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                 Response.SetProperty(WebResponse.ResponseObject, result);
             }
             else
             {
                 Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                 Response.SetProperty(WebResponse.Message, String.Empty);
             }
             return Response;
         }
        private CommunicationObject GetManageAssetDetailsGrid(CommunicationObject RequestDataObject)
          {
              CommunicationObject Response = new CommunicationObject();

              EntityRequest Request = new EntityRequest();

              RequestDataObject.UpdateDataObject(Request);

              ManageAsset[] data = HRInventoryManager.GetAllManageAssets();

              JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(ManageAsset));

              Builder.AddRow(data);

              if (data != null || data.Length >= 0)
              {
                  Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                  Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
              }
              else
              {
                  Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                  Response.SetProperty(WebResponse.Message, String.Empty);
              }
              return Response;
          }
        private static CommunicationObject UpdateManageAssets(CommunicationObject RequestDataObject)
          {
              CommunicationObject Response = new CommunicationObject();

              ManageAssetRequest Request = new ManageAssetRequest();

              RequestDataObject.UpdateDataObject(Request);

              String ResponseString = HRInventoryManager.UpdateManageAssets(Request.ID, Request.UniqueNumber, Request.AssetName, Request.AssetCategoryID, Request.AssetSubCategoryID, Request.ManufacturerID,
                                                                   Request.ManufacturerDate, Request.WarrantyDate, Request.AssetCost, Request.VendorDetails, Request.UpdatedBy, Request.IsActive);

              if (ResponseString == String.Empty || ResponseString == "0" || ResponseString == HRManagerDefs.ManageAssets.MANAGE_ASSET_UPDATE_FAILURE || ResponseString == HRManagerDefs.ManageAssets.MANAGE_ASSET_EXISTS)
                  {
                      Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                  }
                  else
                  {
                      Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                  }
               Response.SetProperty(WebResponse.Message, ResponseString);

              //if (ResponseString == String.Empty)
              //{
              //    Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
              //    if (Request.ID == 0)
              //        Response.SetProperty(WebResponse.Message,HRManagerDefs.ManageAssets.MANAGE_ASSET_ADDED_SUCCESS);
              //    else
              //        Response.SetProperty(WebResponse.Message, HRManagerDefs.ManageAssets.MANAGE_ASSET_UPDATE_SUCCESS);
              //}
              //else
              //{
              //    Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
              //    Response.SetProperty(WebResponse.Message, ResponseString);
              //}

              return Response;
          }
        private static CommunicationObject DeleteManageAsset(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRInventoryManager.DeleteAsset(Convert.ToInt32(Request.ID));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.ManageAssets.MANAGE_ASSET_DELETE);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject AsstCategoryCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Master_AssetCategoryBusinessObject().GetAssetCategoryCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }
        private static CommunicationObject AssetSubCategoryCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Master_AssetSubCategoryBusinessObject().GetAssetSubCategoryCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }
        private static CommunicationObject ManufactureCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Master_ManufacturerBusinessObject().GetManufactureCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }
      #endregion

        #region Assign Assets
      
        private static CommunicationObject AssetCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Assign_AssetesBusinessObject().GetAssetCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }
        private CommunicationObject GetAssignAssetInfo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            AssignAsset result = HRInventoryManager.GetAssignAssetInfoDetails(Convert.ToInt32(Request.ID));

            if (result != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, result);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }
        private CommunicationObject GetAssignAssetDetailsGrid(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            AssignAsset[] data = HRInventoryManager.GetAllAssignAssets();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AssignAsset));

            Builder.AddRow(data);

            if (data != null || data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }
        private static CommunicationObject UpdateAssignAssets(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AssignAssetRequest Request = new AssignAssetRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRInventoryManager.UpdateAssignAssets(Request.ID, Request.AssetID, Request.IsTeamAssigned, Request.TeamID, Request.EmployeeID,
                                                                          Request.dtIssuedDate, Request.Reason, Request.IsReturned, Request.ReturnedDate,
                                                                          Request.Comments, Request.LocationOfAsset, Request.UpdatedBy);
                                        
            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.AssignAssets.ASSIGN_ASSET_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.AssignAssets.ASSIGN_ASSET_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion
        #region Outgoing Asset Devices

        private CommunicationObject GetOutgoingAssetDetailsGrid(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            OutgoingAsset[] data = HRInventoryManager.GetAllOutgoingAssets();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(OutgoingAsset));

            Builder.AddRow(data);

            if (data != null || data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject GetOutgoingAssetInfo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            OutgoingAsset result = HRInventoryManager.GetOutgoingAssetInfoDetails(Convert.ToInt32(Request.ID));

            if (result != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, result);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private static CommunicationObject UpdateOutgoingAssets(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            OutgoingAssetRequest Request = new OutgoingAssetRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRInventoryManager.UpdateOutgoingAssets(Request.ID, Request.AssetID, Request.OutgoingDate, Request.ReturningDate,
                                                                           Request.Reason, Request.UpdatedBy,Request.IsReturned);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.OutgoingAssets.OUTGOING_ASSET_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.OutgoingAssets.OUTGOING_ASSET_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject CheckIsAssetAssigned(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);
            String ResponseString = new AssignAsset().IsAssetAssigned(Convert.ToInt32(Request.ID),Request.ChangedBy);

            if (ResponseString == "false")
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }
            return Response;

        }
        private static CommunicationObject CheckIsAssetAllocated(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);
            String ResponseString = new OutgoingAsset().IsOutgoingAssetReturned(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == "false")
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }
            return Response;

        }

        #endregion


    }
}
