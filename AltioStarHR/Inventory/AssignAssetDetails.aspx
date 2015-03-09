<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignAssetDetails.aspx.cs" Inherits="AltioStarHR.Inventory.AssignAssetDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Assign Assets</title>
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
<h1 style="border:none;background-color:#00daf5;width:98%;padding-left:2%;color:White" class="family1">Assign Asset Details</h1>
 <form id="frmpersonaldetails" action="" enctype="multipart/form-data">
      <table style="width: 100%;background-color:#a4cd0f"  >
                        <tr>
                            <td width="auto" valign="top">
                                <table style="width: 100%">
                                <tr>
                                 <td width="200" height="40" class="family">
                                            Select Type<span style="font-size: medium; color: Red">*</span>
                                        </td>
                                  <td >
                                    <label>
                                        <input type="radio" name="rdouser" checked  value="radio" id="rdouser" tabindex="1" onclick="onUserChange(this.id)" class="family"/>
                                        <b class="family">User</b></label>
                                    <label>
                                        <input type="radio" name="rdoteam"  value="radio" id="rdoteam" tabindex="2" onclick="onUserChange(this.id)" class="family"/>
                                        <b class="family">Team</b></label>
                                </td>
                                <td></td>
                                </tr>
                                
                                   <tr id='trUser'>
                                        <td width="200" height="40" class="family">
                                            User Name<span style="font-size: medium; color: Red">*</span>
                                        </td>
                                        <td width="200" height="40">
                                            <select name="cmbuser" id="cmbuser" tabindex="3" style="width:225px;" class="family">
                                                </select>
                                        </td>
                                        <td id="Td1" width="200" height="40" class="family">
                                        </td>
                                        <td width="220" height="40" class="family">
                                        </td>
                                        <td width="200" height="40" class="family">
                                        </td>
                                        <td id="Td2" width="200" height="40" class="family">
                                        </td>
                                     
                                    </tr>
                                    
                                  <tr id='trteam' >
                                    <td width="200" height="40" class="family">
                                    Team<span style="font-size: medium; color: Red">*</span>
                                    </td>
                                        <td width="200" height="40" class="family">
                                        <select name="cmbteam" id="cmbteam" tabindex="4" style="width:225px;" disabled="disabled" onchange="onTeamChange();"  class="family">
                                                                        </select>
                                        </td>
                                    <td id="scmbteam" width="200" height="40" class="family">
                                    </td>
                                    <td width="200" height="40" class="family">
                                    Manager Name
                                    </td>
                                        <td width="200" height="40">
                                         <input type="text" id="txtmanagername" style="width:225px;" disabled="disabled" class="family"
                                                                            name="txtmanagername" tabindex="5" />
                                        </td>
                                    <td id="stxtmanagername" width="200" height="40">
                                    </td>
                                    </tr>
                                   
                                 <tr>
                                  <td width="200" height="40" class="family">
                                            Asset Name<span style="font-size: medium; color: Red">*</span>
                                   </td>
                                   <td width="250" height="40" class="family">
                                          <select name="cmbAsset" id="cmbAsset" tabindex="6" style="width:225px;" onchange="return onChangeAsset();" class="family">
                                                </select>
                                    </td>
                                    <td id="scmbAsset" width="200" height="40" class="family">
                                    </td>
                                     <td width="220" height="40" class="family">
                                            Asset Category 
                                        </td>
                                        <td width="200" height="40">
                                        <input id="txtAssetCategName" readonly style="width:225px;" name="txtAssetCategName"  class="family"
                                                type="text" tabindex="7" />  
                                        </td>
                                        <td id="stxtAssetCategName" width="200" height="40" class="family">
                                        </td>
                               
                           </tr>
                          
                           
                           
                                    <tr>
                                        <td width="200" height="40" class="family">
                                            Asset Sub Category
                                        </td>
                                        <td width="200" height="40">
                                           <input id="txtAssetSubCateg" readonly style="width:225px;" name="txtAssetSubCateg"  class="family"
                                                type="text" tabindex="8" />  
                                        </td>
                                        <td id="stxtAssetSubCateg" width="200" height="40" class="family">
                                        </td>
                                        <td width="220" height="40" class="family">
                                            Manufacturer
                                        </td>
                                        <td width="200" height="40">
                                           <input id="txtmanufacturer" readonly style="width:225px;" name="txtmanufacturer"  class="family"
                                                type="text" tabindex="9" />  
                                        </td>
                                        <td id="stxtmanufacturer" width="200" height="40" class="family">
                                        </td>
                                     
                                    </tr>
                                    <tr>
                                       <td width="200" height="40" class="family">
                                            Manufacturer Date
                                        </td>
                                        <td width="200" height="40">
                                              <input id="txtmanufacturerdate" readonly style="width:225px;" name="txtmanufacturerdate"  class="family"
                                                type="text" tabindex="10" />  
                                        </td>
                                        <td id="stxtmanufacturerdate" width="200" height="40" class="family">
                                        </td>
                                    
                                    <td width="200" height="40" class="family">
                                            Warranty Date
                                        </td>
                                        <td width="200" height="40">
                                           <input type="text" id="txtwarantydate" style="width:225px;" readonly class="family"
                                                name="txtwarantydate" tabindex="11" />
                                        </td>
                                        <td id="stxtwarantydate" width="200" height="40" class="family">
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td width="220" height="40" class="family">
                                           Asset Cost
                                        </td>
                                        <td>
                                            <input type="text" id="txtassetcost" style="width:225px;"  readonly class="family"
                                                name="txtassetcost" tabindex="12" />
                                        </td>
                                        <td id="stxtassetcost" width="200" height="40" class="family">
                                        </td>
                                   
                                    
                                        <td width="200" height="40" class="family">
                                            Vendor Details 
                                        </td>
                                        <td>
                                          <textarea name="txtvendordetails" id="txtvendordetails" readonly rows="3" cols="25" tabindex="13"  
                                            runat="server" class="family" style="width:225px;border:none"></textarea>

                                        </td>
                                       <td id='stxtvendordetails'  class="family">
                                        </td>
                                     </tr>
                                      
                                 <tr>
                                       <td width="200" height="40" class="family">
                                            Date Issued<span style="font-size: medium; color: Red">*</span>
                                        </td>
                                        <td width="200" height="40">
                                              <input id="dtIssued" readonly style="width:210px;" name="dtIssued"  class="family"
                                                type="text" tabindex="14" />  
                                        </td>
                                        <td id="sdtIssued" width="200" height="40" style="white-space:nowrap" class="family">
                                        </td>
                                    
                                    <td width="200" height="40" class="family">
                                            Reason<span style="font-size: medium; color: Red">*</span>
                                        </td>
                                        <td width="200" height="40" class="family">
                                          <textarea name="txtareason" id="txtareason"  rows="3" cols="25" tabindex="13"  
                                            runat="server" class="family"  style="width:225px;border:none"></textarea>

                                        </td>
                                        <td id="stxtareason" width="200" height="40" style="white-space:nowrap" class="family">
                                        </td>
                                    </tr>
                                    <tr><td width="200" height="40" class="family">
                                            Is Returned?
                                              <input id="isreturned" type="checkbox" tabindex="14" />
                                        </td>
                                        
                                        </tr>
                                         <tr>
                                       <td width="200" height="40" class="family">
                                           Returned Date
                                        </td>
                                        <td width="200" height="40">
                                              <input id="dtreturned" disabled="disabled" style="width:210px;" name="dtreturned"  class="family"
                                                type="text" tabindex="15" />  
                                        </td>
                                        <td id="sdtreturned" width="200" height="40" class="family">
                                        </td>
                                    
                                    <td width="200" height="40" class="family">
                                            Comments
                                        </td>
                                        <td width="200" height="40">
                                          <textarea name="txtacomments" id="txtacomments"  rows="3" cols="25" tabindex="16"  runat="server" class="family"  style="width:225px;border:none"></textarea>

                                        </td>
                                        <td id="stxtacomments" width="200" height="40" class="family">
                                        </td>
                                    </tr>
                                          <tr>
                                       <td width="200" height="40" class="family">
                                            Location of asset
                                        </td>
                                        <td width="200" height="40">
                                              <input id="txtassetlocation"  style="width:225px;" name="txtassetlocation"  class="family"
                                                type="text" tabindex="17" />  
                                        </td>
                                        <td id="stxtassetlocation" width="200" height="40" class="family">
                                        </td>
                                        </tr>
                                </table>
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
        
 <input type="hidden" id='hdnAssetAssignID' runat="server" />
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
        LoadEmployees();
        LoadTeam();

        $(function() {
            $("#dtIssued").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050',
                maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
                $("#dtIssued").valid();
            });
            $("#dtIssued").datepicker("option", "dateFormat", 'dd/mm/yy');

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
                cmbuser: {
                    required: true
                },
                cmbteam: {
                    required: true
                },
                cmbAsset: {
                    required: true
                },
                dtIssued: {
                    required: true
                },
                txtareason: {
                    required: true
                },
                dtreturned: {
                    required: true
                },
                txtacomments: {
                    required: true
                },
                txtassetlocation: {
                    required: true
                }
            },
            messages: {
                cmbuser: {
                    required: "Select user name"
                },
                cmbteam: {
                    required: "Select team name"
                },
                cmbAsset: {
                    required: "Select asset "
                },
                dtIssued: {
                    required: "Select issue date"
                },
                txtareason: {
                    required: "Enter reason"
                },
                dtreturned: {
                    required: "Select return date"
                },
                txtacomments: {
                    required: "Enter comments"
                },
                txtassetlocation: {
                    required: "Enter asset location"
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {

                UpdateAssetAssignInfo();
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });

        $("#dtreturned").datepicker('disable');
        $("#txtacomments").attr("disabled", true);
        $("#txtassetlocation").attr("disabled", true);
        $("#dtreturned").val("");
        $("#txtacomments").val("");
        $("#isreturned").click(function() {
            if ($(this).is(':checked')) {
                $("#dtreturned").datepicker('enable');
                // $("#dtreturned").attr("disabled", false);
                $("#txtacomments").attr("disabled", false);
                $("#txtassetlocation").attr("disabled", false);
            }
            else {
                $("#dtreturned").datepicker('disable');
                $("#txtacomments").attr("disabled", true);
                $("#txtassetlocation").attr("disabled", true);
                $("#dtreturned").val("");
                $("#txtacomments").val("");
                $("#txtassetlocation").val("");
            }
        });
        if ($("#hdnAssetAssignID").val() != "0") {
            LoadAssetAssignInfo();
        }
       
    });

    function onUserChange(id) {
    
    if (id == "rdoteam") {
        if ($("#rdoteam").is(':checked')) {
                $("#cmbuser").attr("disabled", true);
                $("#cmbteam").attr("disabled", false);
                $("#rdouser").attr("checked", false);
                $("#cmbuser").val("");
            }
        }
        else {
            if ($("#rdouser").is(':checked')) {
                $("#cmbuser").attr("disabled", false);
                $("#cmbteam").attr("disabled", true);
                $("#rdoteam").attr("checked", false);
                $("#cmbteam").val("");
                $("#txtmanagername").val("");
            }
        }
    }
    
    
    function UpdateAssetAssignInfo() {
        var Request = new Object();
        var ID = "";
        if ($("#hdnAssetAssignID").val() == "" || $("#hdnAssetAssignID").val() == "0")
            ID = "0";
        else
            ID = $("#hdnAssetAssignID").val();
        Request.ID = ID;
        Request.AssetID = $("#cmbAsset").val();
        if ($("#rdoteam").is(':checked')) {
            Request.IsTeamAssigned = 'True';
            Request.TeamID = $("#cmbteam").val(); 
        }
        else {
            Request.IsTeamAssigned = 'False';
            Request.EmployeeID = $("#cmbuser").val();
        }

        Request.dtIssuedDate = $("#dtIssued").datepicker("getDate");
        Request.Reason = $("#txtareason").val();
        if ($("#isreturned").is(':checked')) { Request.IsReturned = true; }
        else { Request.IsReturned = false; }
        if (jQuery('#dtreturned').val() != "") {
            if (!CompareDateForForm(jQuery('#dtIssued').val(), jQuery('#dtreturned').val())) {
                alert('Returned date should be greater than issued date');
                return false;
            }
        }
        Request.Comments = $("#txtacomments").val();
        Request.ReturnedDate = $("#dtreturned").datepicker("getDate");
        Request.LocationOfAsset = $("#txtassetlocation").val();
        Request.UpdatedBy = $("#hdnLoggedinID").val();

        var Response = SendApplicationRequest('<%=InventoryAppCommands.UPDATE_ASSIGNASSET%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
            if ($("#isreturned").is(':checked')) {
                alert('Asset returned successfully');
            }
            else {
                alert('Asset assigned successfully');
            }
             $('#ChildWB', parent.document).attr("src", "default.aspx?serve=AssignAssetSummary");
        }
        else {
            alert(Response.Message); return false;
        }
    }

    function onCancel() {
        if (confirm('Do you want to cancel?') == false) return;
        $('#ChildWB', parent.document).attr("src", "default.aspx?serve=AssignAssetSummary");
    }


    function LoadAssetAssignInfo() {
      var Request = new Object();
       Request.ID = $("#hdnAssetAssignID").val();
        var Response = SendApplicationRequest('<%=InventoryAppCommands.ASSIGNASSET_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {

            if (Response.ResponseObject.IsTeamAssigned == true) {
                $("#rdoteam").attr('checked', true);
                $("#cmbuser").attr("disabled", true);
                $("#cmbteam").attr("disabled", false);
                $("#cmbteam").val(Response.ResponseObject.TeamID);
                $("#txtmanagername").val(Response.ResponseObject.ManagerName);
                $("#rdouser").attr('checked', false);
              }
              else {
                  $("#rdouser").attr('checked', true);
                  $("#cmbuser").attr("disabled", false);
                  $("#cmbteam").attr("disabled", true);
                  $("#cmbuser").val(Response.ResponseObject.EmployeeID);
                  $("#rdoteam").attr('checked', false);
               }
               $("#cmbAsset").val(Response.ResponseObject.AssetID);
               var issuedt = null;
               issuedt = Response.ResponseObject.dtIssuedDate.substring(8, 10) + "/" + Response.ResponseObject.dtIssuedDate.substring(5, 7) + "/" + Response.ResponseObject.dtIssuedDate.substring(0, 4);
               $("#dtIssued").datepicker({
                   showOn: "button",
                   buttonImage: "Resources/Images/calendar.gif",
                   buttonImageOnly: true,
                   changeMonth: true,
                   changeYear: true,
                   yearRange: '1930:2050',
                   maxDate: new Date(currentYear, currentMonth, currentDate)
               }).change(function() {
               $("#dtIssued").valid();
               });
               $("#dtIssued").datepicker("option", "dateFormat", 'dd/mm/yy');
               $("#dtIssued").val(issuedt);
               $("#txtareason").val(Response.ResponseObject.Reason);
               if (Response.ResponseObject.IsReturned == true) {
                   $("#isreturned").attr('checked', true);
                   $("#txtacomments").val(Response.ResponseObject.Comments);
                   $("#txtassetlocation").val(Response.ResponseObject.LocationOfAsset);
                   var returndt = null;
                   returndt = Response.ResponseObject.ReturnedDate.substring(8, 10) + "/" + Response.ResponseObject.ReturnedDate.substring(5, 7) + "/" + Response.ResponseObject.ReturnedDate.substring(0, 4);
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
                else {
                    $("#isreturned").attr('checked', false);
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
        Request.ID = $("#hdnAssetAssignID").val();
        Request.ChangedBy = $("#cmbAsset").val(); 
        var Response = SendApplicationRequest('<%=InventoryAppCommands.ISASSET_ASSIGNED%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
            LoadAssetDetails();
        }
        else {
            alert(Response.Message);
            $("#cmbAsset").val('');
            $("#txtAssetCategName").val("");
            $("#txtAssetSubCateg").val("");
            $("#txtmanufacturer").val("");
            $("#txtmanufacturerdate").val("");
            $("#txtassetcost").val("");
            $("#txtwarantydate").val("");
            $("#txtvendordetails").val("");
        }
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
    function LoadTeam() {

        var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Choose Team";
        optn.value = "";
        document.getElementById('cmbteam').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;

            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbteam').options.add(optn);
            }
        }
    }

    function onTeamChange() {
        var Request = new Object();
        Request.ID = $("#cmbteam").val();
        var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_DETAILS_BYID%>", Request, true);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            $("#txtmanagername").val(arr[0]["ManagerName"]);
        }
    }

    function LoadEmployees() {
        var Response = SendApplicationRequest("<%=HRAppCommands.MANAGER_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Select User";
        optn.value = "";
        document.getElementById('cmbuser').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbuser').options.add(optn);
            }
        }
    }

</script>



</html>
