<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAssetDetails.aspx.cs" Inherits="AltioStarHR.Inventory.ManageAssetDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Manage Asset</title>
     <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
     <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
     <link type="text/css" rel="stylesheet" media="screen" href="../Resources/css/datePicker.css" />
 <link type="text/css" rel="stylesheet" href="../Resources/css/ajaxfileupload.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
     <style type="text/css">

     </style>
</head>
<body>
    <div id="div1" class="targetDiv" >
<h1 style="height:25px;width:100%;color:White;padding-left:2%;background-color:#02d9f5" class="family1">Manage Asset Details</h1>
 <form id="frmpersonaldetails" action="" enctype="multipart/form-data">
    
                <table style="width:100%;background-color:#a4cd0f">
                    <tr>
                        <td width="100" height="40" class="family">Asset Unique Number</td>
                        <td width="100" height="40">
                            <input id="txtUniqueNo" disabled="disabled" style="width: 225px;border:1px solid silver" name="txtUniqueNo"  
                                readonly class="family" type="text" tabindex="1" />
                        </td>
                        <td id="stxtUniqueNo"  width="100" height="40" style="white-space:nowrap" class="family">
                        </td>
                        <td width="100" height="40" class="family">Asset Name<span style="font-size: medium; color: Red">*</span></td>
                        <td width="100" height="40">
                            <input id="txtAssetName" style="width: 225px;border:1px solid silver" name="txtAssetName"  class="family"
                                                type="text" tabindex="2" />  
                        </td>
                        <td id="stxtAssetName"  width="100" height="40" style="white-space:nowrap" class="family">
                        </td>
                    </tr>
                    <tr>
                        <td width="100" height="40" class="family">Asset category<span style="font-size: medium; color: Red">*</span></td>
                        <td width="100" height="40">
                            <select name="cmbassetcategory" id="cmbassetcategory" tabindex="3" style="width: 225px;border:1px solid silver" class="family">
                            </select>
                        </td>
                        <td id="scmbassetcategory"  style="white-space:nowrap" class="family"></td>
                        <td width="100" height="40" class="family">
                            Asset Sub Category Name
                        </td>
                        <td width="100" height="40">
                            <select name="cmbassetsubcategory" id="cmbassetsubcategory" tabindex="4" style="width: 225px;border:1px solid silver" class="family">
                                </select>
                        </td>
                        <td id="scmbassetsubcategory" width="100" height="40" style="white-space:nowrap" class="family">
                        </td>
                    </tr>
                    <tr>
                        <td width="100" height="40" class="family">Manufacturer<span style="font-size: medium; color: Red">*</span></td>
                        <td width="100" height="40">
                             <select name="cmbmanufacturer" id="cmbmanufacturer" tabindex="5" style="width: 225px;border:1px solid silver"  class="family">
                                </select>
                        </td>
                        <td id="scmbmanufacturer"  style="white-space:nowrap" class="family">
                        </td>
                        <td width="100" height="40" class="family">Manufacturing Date<span style="font-size: medium; color: Red">*</span></td>
                        <td width="100" height="40">
                           <input type="text" id="manufacturedate" style="width: 205px;border:1px solid silver"  readonly class="family"
                                name="manufacturedate" tabindex="6" />
                        </td>
                        <td id="smanufacturedate" width="100" height="40" style="white-space:nowrap" class="family">
                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td width="100" height="40" class="family">
                                            Warranty Date<span style="font-size: medium; color: Red">*</span>
                                        </td>
                                        <td width="100" height="40">
                                            <input type="text" id="warrantydate" style="width: 205px;border:1px solid silver"  readonly class="family"
                                                name="warrantydate" tabindex="7" />
                                        </td>
                                        <td width="100" height="40" id="swarrantydate" style="white-space:nowrap" class="family">
                                        </td>
                                   
                                    
                                        <td width="100" height="40" class="family">
                                            Asset Cost <span style="font-size: medium; color: Red">*</span>
                                        </td>
                                        <td width="100" height="40">
                                             <input id="txtassetcost" style="width: 225px;border:1px solid silver" name="txtassetcost"  class="family"
                                                type="text" tabindex="8" />  
                                        </td>
                                        <td width="100" height="40" id='stxtassetcost' style="white-space:nowrap" class="family">
                                        </td>
                                     </tr>
                                        <tr>
                                        <td width="100" height="40" class="family">
                                           Vendor details<span style="font-size: medium; color: Red">*</span>
                                        </td>
                                        <td width="100" height="40">
                                       <textarea name="txtvendordetails" id="txtvendordetails" rows="3" cols="25" tabindex="9"  
                                        runat="server" style="width: 225px;border:1px solid silver" class="family"></textarea>

                                        </td>
                                        <td id='stxtvendordetails' width="100" height="40" style="white-space:nowrap" class="family">
                                        </td>
                                        <td></td><td></td><td></td>
                                    </tr>
                         </table>
                         <br />
                                <table >
                                    <tr>
                                        <td>
                                            <input id="btnSave1" name="Submit" type="submit" value="Save" tabindex="10" style="border:1px solid silver" class="family"/>
                                               
                                            <input id="btnCancel" name="btnCancel" type="button" value="Cancel" tabindex="11" onclick="return onCancel();" style="border:1px solid silver" class="family"/>
                                        </td>
                                    </tr>
                                </table>
                               
                                  
                               
   
           <%--<table>
                            <tr>
                                <td >
                                    <input id="btnSave1" name="Submit" type="submit" value="Save" tabindex="10"/>
                               
                                    <input id="btnCancel" name="btnCancel" type="button" value="Cancel" tabindex="11" onclick="return onCancel();" />
                                </td>
                            </tr>
                        </table>--%>
        
 <input type="hidden" id='hdnAssetID' runat="server" />
 <input id='hdnEmployeeID' runat="server" type="hidden" />
 <input id='hdnLoggedinID' runat="server" type="hidden" />
  </form>
 </div>
</body>

<script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

<script src="Resources/js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

<script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="Resources/js/Webutility.js"></script>

<script type="text/javascript" src="Resources/js/toolbar.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

<script type="text/javascript" src="Resources/js/jquery.validate.js"></script>

<script src="Resources/js/jquery.ui.button.js" type="text/javascript"></script>

<script type="text/javascript" src="Resources/js/Validation.js"></script>
<script type="text/javascript">
  var currentMonth = '';
    var currentDate = '';
    var currentYear = '';

    jQuery(document).ready(function() {
        var date = new Date();
        currentMonth = date.getMonth();
        currentDate = date.getDate();
        currentYear = date.getFullYear();

        LoadAssetCategory();
        LoadAssetSubCategory();
        LoadManufacturer();

        $(function() {
            $("#manufacturedate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
            }).change(function() {
                $("#manufacturedate").valid();
            });
            $("#manufacturedate").datepicker("option", "dateFormat", 'dd/mm/yy');

        });

        $(function() {
            $("#warrantydate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
                // maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
                $("#warrantydate").valid();
            });
            $("#warrantydate").datepicker("option", "dateFormat", 'dd/mm/yy');

        });

        jQuery.validator.addMethod("greaterThan", function(value, element, param) {
            return this.optional(element) || parseFloat(value) < parseFloat($(param).val());
        }, "");
        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]+$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        //Start of Employee Info  DIV1
        var Data = new Date();
        var validator = $("#frmpersonaldetails").validate({
            ignore: ":disabled",
            rules: {
                txtAssetName: {
                    required: true
                },
                cmbassetcategory: {
                    required: true
                },
                cmbassetsubcategory: {
                    required: true
                },
                cmbmanufacturer: {
                    required: true
                },
                manufacturedate: {
                    required: true
                },
                warrantydate: {
                    required: true
                },
                txtassetcost: {
                    required: true
                },
                txtvendordetails: {
                    required: true
                }
            },
            messages: {
                txtAssetName: {
                    required: "Enter asset name"
                },
                cmbassetcategory: {
                    required: "Select asset category"
                },
                cmbassetsubcategory: {
                    required: "Select asset sub category"
                },
                cmbmanufacturer: {
                    required: "Select manufacturer"
                },
                manufacturedate: {
                    required: "Select manufacturing date"
                },
                warrantydate: {
                    required: "Select warranty date"
                },
                txtassetcost: {
                    required: "Enter asset cost"
                },
                txtvendordetails: {
                    required: "Enter vendor details"
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {

                UpdateAssetInfo();
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });

        if ($("#hdnAssetID").val() != "0") {
            LoadManageAssetInfo();
        }
    });

    function LoadManageAssetInfo() {
        var Request = new Object();
        Request.ID = $("#hdnAssetID").val();
        var Response = SendApplicationRequest('<%=InventoryAppCommands.MANAGEASSET_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
           
               $("#txtUniqueNo").val(Response.ResponseObject.UniqueNumber);
               $("#txtAssetName").val(Response.ResponseObject.AssetName);
               $("#cmbassetcategory").val(Response.ResponseObject.AssetCategoryID);
               $("#cmbassetsubcategory").val(Response.ResponseObject.AssetSubCategoryID);
               $("#cmbmanufacturer").val(Response.ResponseObject.ManufacturerID);
               var manufdt = null;
               manufdt = Response.ResponseObject.dtManufacturerDate.substring(8, 10) + "/" + Response.ResponseObject.dtManufacturerDate.substring(5, 7) + "/" + Response.ResponseObject.dtManufacturerDate.substring(0, 4);
               $("#manufacturedate").datepicker({
                   showOn: "button",
                   buttonImage: "Resources/Images/calendar.gif",
                   buttonImageOnly: true,
                   changeMonth: true,
                   changeYear: true,
                   yearRange: '1930:2050'
               }).change(function() {
               $("#manufacturedate").valid();
               });
               $("#manufacturedate").datepicker("option", "dateFormat", 'dd/mm/yy');
               $("#manufacturedate").val(manufdt);
               $("#txtassetcost").val(Response.ResponseObject.AssetCost);
               var warntdt = null;
               warntdt = Response.ResponseObject.dtWarrantyDate.substring(8, 10) + "/" + Response.ResponseObject.dtWarrantyDate.substring(5, 7) + "/" + Response.ResponseObject.dtWarrantyDate.substring(0, 4);
               $("#warrantydate").datepicker({
                   showOn: "button",
                   buttonImage: "Resources/Images/calendar.gif",
                   buttonImageOnly: true,
                   changeMonth: true,
                   changeYear: true,
                   yearRange: '1930:2050'
               }).change(function() {
               $("#warrantydate").valid();
               });
               $("#warrantydate").datepicker("option", "dateFormat", 'dd/mm/yy');
               $("#warrantydate").val(warntdt);
               $("#txtvendordetails").val(Response.ResponseObject.VendorDetails);
           }
    }
    
 function UpdateAssetInfo() {
     var Request = new Object();
     var ID = "";
     if ($("#hdnAssetID").val() == "" || $("#hdnAssetID").val() == "0")
         ID = "0";
     else
         ID = $("#hdnAssetID").val();
     Request.ID = ID;
     Request.UniqueNumber = $("#txtUniqueNo").val();
     Request.AssetName = $("#txtAssetName").val();
     Request.AssetCategoryID = $("#cmbassetcategory").val();
     Request.AssetSubCategoryID = $("#cmbassetsubcategory").val();
     Request.ManufacturerID = $("#cmbmanufacturer").val();
     Request.ManufacturerDate = $("#manufacturedate").datepicker("getDate");
     Request.AssetCost = $("#txtassetcost").val();
     if (!CompareDateForForm(jQuery('#manufacturedate').val(), jQuery('#warrantydate').val())) {
         alert('Warranty date should be greater than manufacturing date');
          return false;
      }
     Request.WarrantyDate = $("#warrantydate").datepicker("getDate");
     Request.VendorDetails = $("#txtvendordetails").val();
     Request.UpdatedBy = $("#hdnLoggedinID").val();
     Request.IsActive = true;
     var Response = SendApplicationRequest('<%=InventoryAppCommands.UPDATE_MANAGEASSET%>', Request);
     if (Response.ResponseCommand == 'SUCCESS') {
         $("#txtUniqueNo").val(Response.Message);
         if (ID == "0") {
             var msg = "Asset added successfully with unique number : " + Response.Message;
             alert(msg);
         }
         else {
             alert('Asset saved successfully');
         }
         $('#ChildWB', parent.document).attr("src", "default.aspx?serve=ManageAssetSummary");
     }
     else {
         alert(Response.Message); return false;
     }
 }

 function onCancel() {
     if (confirm('Do you want to cancel?') == false) return;
     $('#ChildWB', parent.document).attr("src", "default.aspx?serve=ManageAssetSummary");
 }
 
 function LoadAssetCategory() {
     var optn = document.createElement("OPTION");
     optn.text = "Select asset category";
     optn.value = "";
     document.getElementById('cmbassetcategory').options.add(optn);
     var Response = SendApplicationRequest("<%=InventoryAppCommands.ASSET_CATEGORY_COMBO%>", '', true);
     if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
         var arr = Response.ResponseObject;
         for (var i = 0; i < arr.length; ++i) {
             var optn = document.createElement("OPTION");
             optn.text = arr[i]['Value'];
             optn.value = arr[i]['ID'];
             document.getElementById('cmbassetcategory').options.add(optn);
         }
     }
 }
 function LoadAssetSubCategory() {
     var optn = document.createElement("OPTION");
     optn.text = "Select asset sub category";
     optn.value = "";
     document.getElementById('cmbassetsubcategory').options.add(optn);
     var Response = SendApplicationRequest("<%=InventoryAppCommands.ASSET_SUBCATEGORY_COMBO%>", '', true);
     if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
         var arr = Response.ResponseObject;
         for (var i = 0; i < arr.length; ++i) {
             var optn = document.createElement("OPTION");
             optn.text = arr[i]['Value'];
             optn.value = arr[i]['ID'];
             document.getElementById('cmbassetsubcategory').options.add(optn);
         }
     }
 }
 function LoadManufacturer() {
     var optn = document.createElement("OPTION");
     optn.text = "Select manufacturer";
     optn.value = "";
     document.getElementById('cmbmanufacturer').options.add(optn);
     var Response = SendApplicationRequest("<%=InventoryAppCommands.ASSET_MANUFACTURER_COMBO%>", '', true);
     if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
         var arr = Response.ResponseObject;
         for (var i = 0; i < arr.length; ++i) {
             var optn = document.createElement("OPTION");
             optn.text = arr[i]['Value'];
             optn.value = arr[i]['ID'];
             document.getElementById('cmbmanufacturer').options.add(optn);
         }
     }
 }
</script>
</html>
