<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetOutgoingDetails.aspx.cs" Inherits="AltioStarHR.Inventory.AssetOutgoingDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Outgoing Devices</title>
      <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
     <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
     <link type="text/css" rel="stylesheet" media="screen" href="../Resources/css/datePicker.css" />
 <link type="text/css" rel="stylesheet" href="../Resources/css/ajaxfileupload.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
     <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

     </style>
</head>
<body>
    <div id="div1" class="targetDiv"  >
<h1 style="border:none;background-color:#00daf5;width:98%;padding-left:2%;color:White" class="family1">Outgoing Devices</h1>
 <form id="frmpersonaldetails" action="" enctype="multipart/form-data">
    <%--  <table class="teble_bg" style="width: 100px" >--%>
<%--     <table  style="width: 100%;background-color:#a4cd0f" >
                    <tr>
                        <td width="auto" valign="top">
                            <table style="width: 700px">
                    <tr>
                                <td width="200" height="40">
                                        Reason<span style="font-size: medium; color: Red">*</span>
                                    </td>
                                    <td width="400" height="40">
                                      <textarea name="txtareason" id="txtareason"  rows="3" cols="25" tabindex="1"  runat="server" ></textarea>

                                    </td>
                                    <td id="stxtareason" width="200" height="40">
                                    </td>
                                </tr>
                               
                             <tr>
                              <td width="200" height="40">
                                        Asset Name<span style="font-size: medium; color: Red">*</span>
                               </td>
                               <td width="250" height="40">
                                      <select name="cmbAsset" id="cmbAsset" tabindex="2" style="width:auto;" onchange="return onChangeAsset();" >
                                            </select>
                                </td>
                                <td id="scmbAsset" width="200" height="40">
                                </td>
                              <td width="220" height="40">
                                        Asset Category 
                                    </td>
                                    <td width="200" height="40">
                                    <input id="txtAssetCategName" readonly style="width: 150px" name="txtAssetCategName"  
                                            type="text" tabindex="3" />  
                                    </td>
                                    <td id="stxtAssetCategName" width="200" height="40">
                                    </td>
                       </tr>
                                <tr>
                                    <td width="200" height="40">
                                        Asset Sub Category
                                    </td>
                                    <td width="200" height="40">
                                       <input id="txtAssetSubCateg" readonly style="width: 150px" name="txtAssetSubCateg"  
                                            type="text" tabindex="4" />  
                                    </td>
                                    <td id="stxtAssetSubCateg" width="200" height="40">
                                    </td>
                                    <td width="220" height="40">
                                        Manufacturer
                                    </td>
                                    <td width="200" height="40">
                                       <input id="txtmanufacturer" readonly style="width:auto;"  name="txtmanufacturer"  
                                            type="text" tabindex="5" />  
                                    </td>
                                    <td id="stxtmanufacturer" width="200" height="40">
                                    </td>
                                 
                                </tr>
                                <tr>
                                   <td width="200" height="40">
                                        Manufacturer Date
                                    </td>
                                    <td width="200" height="40">
                                          <input id="txtmanufacturerdate" readonly style="width: 150px" name="txtmanufacturerdate"  
                                            type="text" tabindex="6" />  
                                    </td>
                                    <td id="stxtmanufacturerdate" width="200" height="40">
                                    </td>
                                
                                <td width="200" height="40">
                                        Warranty Date
                                    </td>
                                    <td width="200" height="40">
                                       <input type="text" id="txtwarantydate" style="width: 80px"  readonly
                                            name="txtwarantydate" tabindex="7" />
                                    </td>
                                    <td id="stxtwarantydate" width="200" height="40">
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td width="220" height="40">
                                       Asset Cost
                                    </td>
                                    <td>
                                        <input type="text" id="txtassetcost" style="width: 80px"  readonly
                                            name="txtassetcost" tabindex="8" />
                                    </td>
                                    <td id="stxtassetcost" width="200" height="40">
                                    </td>
                               
                                
                                    <td width="200" height="40">
                                        Vendor Details 
                                    </td>
                                    <td>
                                      <textarea name="txtvendordetails" id="txtvendordetails" readonly rows="3" cols="25" tabindex="9"  runat="server" ></textarea>

                                    </td>
                                   <td id='stxtvendordetails' >
                                    </td>
                                 </tr>
                                  
                                     <tr>
                                   <td width="200" height="40">
                                       Outgoing Date<span style="font-size: medium; color: Red">*</span>
                                    </td>
                                    <td width="200" height="40">
                                          <input id="dtoutgoing" readonly   style="width: 100px" name="dtoutgoing"  
                                            type="text" tabindex="10" />  
                                    </td>
                                    <td id="sdtoutgoing" width="200" height="40">
                                    </td>
                                
                                <td width="200" height="40">
                                         Returning Date
                                    </td>
                                    <td width="200" height="40">
                                          <input id="dtreturned" disabled="disabled" style="width: 100px" name="dtreturned"  
                                            type="text" tabindex="11" />  
                                    </td>
                                    <td id="sdtreturned" width="200" height="40">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>--%>
 
        <table style="width: 100%;background-color:#a4cd0f" >
            <tr>
                <td width="100" height="40" class="family">
                        Reason<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td >
                      <textarea name="txtareason" id="txtareason"  rows="3" tabindex="1"  
                            runat="server" class="family" style=" width: 225px;border:none"></textarea>

                    </td>
                    <td id="stxtareason" width="100" height="40"  style="white-space:nowrap" class="family">
                    </td>
                </tr>
               
             <tr>
              <td width="100" height="40" class="family">
                        Asset Name<span style="font-size: medium; color: Red">*</span>
               </td>
               <td >
                      <select name="cmbAsset" id="cmbAsset" tabindex="2" style="width:225px" onchange="return onChangeAsset();" class="family">
                            </select>
                </td>
                <td id="scmbAsset" width="100" height="40" class="family">
                </td>
              <td width="220" height="40" class="family">
                        Asset Category 
                    </td>
                    <td >
                    <input id="txtAssetCategName" readonly style="width:225px" name="txtAssetCategName"  class="family"
                            type="text" tabindex="3" />  
                    </td>
                    <td id="stxtAssetCategName" width="100" height="40" class="family">
                    </td>
       </tr>
                <tr>
                    <td width="100" height="40" class="family">
                        Asset Sub Category
                    </td>
                    <td >
                       <input id="txtAssetSubCateg" readonly style="width:225px" name="txtAssetSubCateg"  class="family"
                            type="text" tabindex="4" />  
                    </td>
                    <td id="stxtAssetSubCateg" width="100" height="40" class="family">
                    </td>
                    <td width="220" height="40" class="family">
                        Manufacturer
                    </td>
                    <td >
                       <input id="txtmanufacturer" readonly style="width:225px"  name="txtmanufacturer"  class="family"
                            type="text" tabindex="5" />  
                    </td>
                    <td id="stxtmanufacturer" width="100" height="40" class="family">
                    </td>
                 
                </tr>
                <tr>
                   <td width="100" height="40" class="family">
                        Manufacturer Date
                    </td>
                    <td >
                          <input id="txtmanufacturerdate" readonly style="width:225px" name="txtmanufacturerdate"  class="family"
                            type="text" tabindex="6" />  
                    </td>
                    <td id="stxtmanufacturerdate" width="100" height="40" class="family">
                    </td>
                
                <td width="100" height="40" class="family">
                        Warranty Date
                    </td>
                    <td >
                       <input type="text" id="txtwarantydate" style="width:225px"  readonly class="family"
                            name="txtwarantydate" tabindex="7" />
                    </td>
                    <td id="stxtwarantydate" width="100" height="40" class="family">
                    </td>
                </tr>
                <tr>
                    
                    <td width="220" height="40" class="family">
                       Asset Cost
                    </td>
                    <td>
                        <input type="text" id="txtassetcost" style="width:225px"  readonly class="family"
                            name="txtassetcost" tabindex="8" />
                    </td>
                    <td id="stxtassetcost" width="100" height="40" class="family">
                    </td>
               
                
                    <td width="100" height="40" class="family">
                        Vendor Details 
                    </td>
                    <td>
                      <textarea name="txtvendordetails" id="txtvendordetails" readonly rows="3" cols="25" tabindex="9"  
                        runat="server" class="family" style=" width: 225px;border:none;"></textarea>

                    </td>
                   <td id='stxtvendordetails' width="100" height="40" class="family">
                    </td>
                 </tr>
                  
                     <tr>
                   <td width="100" height="40" class="family">
                       Outgoing Date<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td >
                          <input id="dtoutgoing" readonly   style="width:210px"name="dtoutgoing"  class="family"
                            type="text" tabindex="10" />  
                    </td>
                    <td id="sdtoutgoing" style="white-space:nowrap" width="100" height="40" class="family">
                    </td>
                
                <td width="100" height="40" class="family">
                         Returning Date
                    </td>
                    <td >
                          <input id="dtreturned" style="width:205px" name="dtreturned"   class="family"
                            type="text" tabindex="11" />  
                    </td>
                    <td id="sdtreturned" width="100" height="40" class="family">
                    </td>
                </tr>
            </table>
        <br />
        <table>
                            <tr>
                                <td >
                                    <input id="btnSave1" name="Submit" type="submit" value="Save" tabindex="18" class="family"/>
                               
                                    <input id="btnCancel" name="btnCancel" type="button" value="Cancel" tabindex="19" onclick="return onCancel();" class="family"/>
                                </td>
                            </tr>
                        </table>
        
 <input type="hidden" id='hdnOutgoingID' runat="server" />
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
        LoadAsset();
        $(function() {
        $("#dtoutgoing").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
               // maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
            $("#dtoutgoing").valid();
            });
            $("#dtoutgoing").datepicker("option", "dateFormat", 'dd/mm/yy');

        });

        $(function() {
            $("#dtreturned").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
                // maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
                $("#dtreturned").valid();
            });
            $("#dtreturned").datepicker("option", "dateFormat", 'dd/mm/yy');

        });
      
        //Start of Employee Info  DIV1
        var Data = new Date();
        var validator = $("#frmpersonaldetails").validate({
            ignore: ":disabled",
            rules: {
                txtareason: {
                    required: true
                },
                cmbAsset: {
                    required: true
                },
                dtoutgoing: {
                    required: true
                }
            },
            messages: {
              txtareason: {
                    required: "Enter reason"
                },
                cmbAsset: {
                    required: "Select asset "
                },
                dtoutgoing: {
                    required: "Select outgoing date"
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {

                UpdateAssetOutgoingInfo();
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });
        if ($("#hdnOutgoingID").val() != "0") {
            LoadAssetOutgoingInfo();
        }
       
    });

    function UpdateAssetOutgoingInfo() {
        var Request = new Object();
        var ID = "";
        if ($("#hdnOutgoingID").val() == "" || $("#hdnOutgoingID").val() == "0")
            ID = "0";
        else
            ID = $("#hdnOutgoingID").val();
        Request.ID = ID;
        Request.AssetID = $("#cmbAsset").val();
        Request.OutgoingDate = $("#dtoutgoing").datepicker("getDate");
        Request.Reason = $("#txtareason").val();
        Request.IsReturned = false;
        if (jQuery('#dtreturned').val() != "") {
            if (!CompareDateForForm(jQuery('#dtoutgoing').val(), jQuery('#dtreturned').val())) {
                alert('Returning date should be greater than outgoing date');
                return false;
            }
            Request.IsReturned = true;
        }
        Request.ReturningDate = $("#dtreturned").datepicker("getDate");
        Request.UpdatedBy = $("#hdnLoggedinID").val();
        var Response = SendApplicationRequest('<%=InventoryAppCommands.UPDATE_OUTGOINGASSET%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
             alert('Saved successfully');
             $('#ChildWB', parent.document).attr("src", "default.aspx?serve=AssetOutgoingSummary");
        }
        else {
            alert(Response.Message); return false;
        }
    }

    function onCancel() {
        if (confirm('Do you want to cancel?') == false) return;
        $('#ChildWB', parent.document).attr("src", "default.aspx?serve=AssetOutgoingSummary");
    }

    function LoadAssetOutgoingInfo() {
      var Request = new Object();
      Request.ID = $("#hdnOutgoingID").val();
      var Response = SendApplicationRequest('<%=InventoryAppCommands.OUTGOINGASSET_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
               $("#cmbAsset").val(Response.ResponseObject.AssetID);
               var issuedt = null;
               issuedt = Response.ResponseObject.dtOutgoingDate.substring(8, 10) + "/" + Response.ResponseObject.dtOutgoingDate.substring(5, 7) + "/" + Response.ResponseObject.dtOutgoingDate.substring(0, 4);
               $("#dtoutgoing").datepicker({
                   showOn: "button",
                   buttonImage: "Resources/Images/calendar.gif",
                   buttonImageOnly: true,
                   changeMonth: true,
                   changeYear: true,
                   yearRange: '1930:2050',
                   maxDate: new Date(currentYear, currentMonth, currentDate)
               }).change(function() {
               $("#dtoutgoing").valid();
               });
               $("#dtoutgoing").datepicker("option", "dateFormat", 'dd/mm/yy');
               $("#dtoutgoing").val(issuedt);
               $("#txtareason").val(Response.ResponseObject.Reason);
               if (Response.ResponseObject.ReturningDate.substring(0, 4) == "1900") {
                   $("#dtreturned").val("");
               }
               else {
                   var returndt = null;
                   returndt = Response.ResponseObject.ReturningDate.substring(8, 10) + "/" + Response.ResponseObject.ReturningDate.substring(5, 7) + "/" + Response.ResponseObject.ReturningDate.substring(0, 4);
                   $("#dtreturned").datepicker({
                       showOn: "button",
                       buttonImage: "Resources/Images/calendar.gif",
                       buttonImageOnly: true,
                       changeMonth: true,
                       changeYear: true,
                       yearRange: '1930:2050'
                   }).change(function() {
                       $("#dtIssued").valid();
                   });
                   $("#dtreturned").datepicker("option", "dateFormat", 'dd/mm/yy');
                   $("#dtreturned").val(returndt);
               }
              //Asset Info Load
                 LoadAssetDetails();
        }
    }

    function onChangeAsset() {
        if ($("#cmbAsset").val() == "") {
            $("#txtAssetCategName").val("");
            $("#txtAssetSubCateg").val("");
            $("#txtmanufacturer").val("");
            $("#txtmanufacturerdate").val("");
            $("#txtassetcost").val("");
            $("#txtwarantydate").val("");
            $("#txtvendordetails").val("");
            return;
        }
        var Request = new Object();
        Request.ID = $("#hdnOutgoingID").val();
        Request.ChangedBy = $("#cmbAsset").val();
        var Response = SendApplicationRequest('<%=InventoryAppCommands.ISASSET_ASSIGNED%>', Request);
        if (Response.ResponseCommand == 'ERROR') {
            alert(Response.Message);
            $("#cmbAsset").val('');
            $("#txtAssetCategName").val("");
            $("#txtAssetSubCateg").val("");
            $("#txtmanufacturer").val("");
            $("#txtmanufacturerdate").val("");
            $("#txtassetcost").val("");
            $("#txtwarantydate").val("");
            $("#txtvendordetails").val("");
            return;
        }
        var Request = new Object();
        Request.ID = $("#hdnOutgoingID").val();
        Request.ChangedBy = $("#cmbAsset").val();
        var Response = SendApplicationRequest('<%=InventoryAppCommands.ISASSET_ALLOCATED%>', Request);
        if (Response.ResponseCommand == 'ERROR') {
            alert(Response.Message);
            $("#cmbAsset").val('');
            $("#txtAssetCategName").val("");
            $("#txtAssetSubCateg").val("");
            $("#txtmanufacturer").val("");
            $("#txtmanufacturerdate").val("");
            $("#txtassetcost").val("");
            $("#txtwarantydate").val("");
            $("#txtvendordetails").val("");
            return;
        }
        LoadAssetDetails();
    }
    
    function LoadAssetDetails() {
        var Request1 = new Object();
        Request1.ID = $("#cmbAsset").val();
        var Response1 = SendApplicationRequest('<%=InventoryAppCommands.MANAGEASSET_INFO%>', Request1);
        if (Response1.ResponseCommand == 'SUCCESS') {
            $("#txtAssetCategName").val(Response1.ResponseObject.AssetCategName);
            $("#txtAssetSubCateg").val(Response1.ResponseObject.AssetSubCateg);
            $("#txtmanufacturer").val(Response1.ResponseObject.ManufacturerName);
            $("#txtmanufacturerdate").val(Response1.ResponseObject.ManufacturerDate);
            $("#txtassetcost").val(Response1.ResponseObject.AssetCost);
            $("#txtwarantydate").val(Response1.ResponseObject.WarrantyDate);
            $("#txtvendordetails").val(Response1.ResponseObject.VendorDetails);
        }
    }
    
    function LoadAsset() {
        var optn = document.createElement("OPTION");
        optn.text = "Select asset";
        optn.value = "";
        document.getElementById('cmbAsset').options.add(optn);
        var Response = SendApplicationRequest("<%=InventoryAppCommands.ASSET_COMBO%>", '', true);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbAsset').options.add(optn);
            }
        }
    }
</script>
</html>
