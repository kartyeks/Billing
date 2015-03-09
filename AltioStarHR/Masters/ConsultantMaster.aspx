<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantMaster.aspx.cs"
    Inherits="AltioStarHR.Masters.ConsultantMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Consultant Master</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <%--<link href="../Resources/css/New%20Css/Stylesheet1.css" rel="stylesheet" type="text/css" />--%>
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
        input[type=text]
        {
            margin-bottom: 5px;
            width: 95%;
            padding: 0.3em;
        }
        textarea
        {
            margin-bottom: 5px;
            width: 95%;
            padding: 0.3em;
        }
        fieldset
        {
            padding: 0;
            border: 0;
            margin-top: 25px;
        }
        .ui-dialog .ui-state-error
        {
            padding: .3em;
        }
        #Clientmaster
        {
            width: 217px;
        }
        
    </style>
</head>
<body>
<div style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png"style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
  <strong class="family1 imageheadercolor">Consultant Details</strong>
    </div>
</div>
    <div id="divConsultant" class="dialog" style="display: none;width:100%">
        <form id="signupForm" method="get" action="">
        <fieldset style="width: 97%;margin-left:2%;margin-top:0%">
            <table style="width:100%;background-color:#a4cd0f">
                <tbody>
                    <tr>
                     <td width="200" height="40" class="family">
                    Designation<span style="font-size: medium; color: Red">*</span>
                    </td>
                        <td width="200" height="40">
                        <select name="cmbdesignation" id="cmbdesignation" tabindex="10"
                            class="family" style="width: 250px;border:1px solid silver">
                        </select>
                        </td>
                    <td id="scmbdesignation" style="white-space:nowrap">
                    </td>
                    </tr>
                    <tr>
                        <td class="label" width="100" height="40">
                            <label id="lconsultantname" for="consultantname" class="family">
                                Consultant Name<span style="font-size: medium; color: Red"><b>*</b></span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="consultantname" name="consultantname" type="text" style="width: 240px;border:1px solid silver" tabindex="1"
                                value="" maxlength="50" class="family"/>
                        </td>
                        <td id="sconsultantname" style="white-space:nowrap">
                        </td>
                    </tr>
                     <tr>
                        <td class="label" width="100" height="40">
                            <label id="lcontactperson" for="contactperson" class="family">
                                Contact Person<span style="font-size: medium; color: Red"><b>*</b></span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="contactperson" name="contactperson" type="text" style="width: 240px;border:1px solid silver" tabindex="1"
                                value="" maxlength="50" class="family"/>
                        </td>
                        <td id="scontactperson" style="white-space:nowrap">
                        </td>
                    </tr>
                     <tr>
                        <td class="label" width="120" height="40">
                            <label id="ltelephoneno" for="telephoneno" class="family">
                                Telephone Number<span style="font-size: medium; color: Red"><b>*</b></span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="telephoneno" name="telephoneno" type="text" style="width: 240px;border:1px solid silver" tabindex="1"
                                value="" maxlength="50" class="family"/>
                        </td>
                        <td id="stelephoneno" >
                        </td>
                    </tr>
                     <tr>
                        <td class="label" width="100" height="40">
                            <label id="lemailID" for="emailID" class="family">
                                Email ID<span style="font-size: medium; color: Red"><b>*</b></span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="emailID" name="emailID" type="text" style="width: 240px;border:1px solid silver" tabindex="1"
                                value="" maxlength="50" class="family"/>
                        </td>
                        <td id="semailID" style="white-space:nowrap">
                        </td>
                    </tr>
                     <tr>
                        <td class="label" width="100" height="40">
                            <label id="laddress" for="address" class="family">
                                Address<span style="font-size: medium; color: Red"><b>*</b></span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <textarea id="address" name="address" style="width: 240px;border:1px solid silver" tabindex="1"
                                class="family" cols="25" rows="3"></textarea>
                                 
                        </td>
                        <td id="saddress" style="white-space:nowrap">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lisactive" class="family">
                                Active</label>
                        </td>
                        <td class="field">
                            <input id="isactive" tabindex="3" type="checkbox" style="border:1px solid silver" class="family"/>
                        </td>
                        <td class="status" id="sisactive">
                        </td>
                    </tr>
                    <tr>
                    <td></td>
                    <td>
                        <input id="signupsubmit" name="Submit" tabindex="4" class="family" type="submit" value="Save" />
                        <input id="Cancel" name="Cancel" tabindex="5" class="family" type="button" value="Cancel" />
                    </td>
                    </tr>
                </tbody>
            </table>
            <%--<table>
                <tr align="center">
                    <td class="field">
                        <input id="signupsubmit" name="Submit" tabindex="4" type="submit" value="Save" />
                    </td>
                    <td class="field">
                        <input id="Cancel" name="Cancel" tabindex="5" type="button" value="Cancel" />
                    </td>
                </tr>
            </table>--%>
        </fieldset>
        </form>
    </div>
    <div style="margin-left:2%;" id="box">
      <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>
    <input type="hidden" id='hdnEmployeeID' runat="server" />
    <input type="hidden" id='hdnmodule' runat="server" />
    <input type="hidden" id='hdnApprovlPermit' runat="server" />
    <input type="hidden" id="hdnApplyPermit" runat="server" />
    <input type="hidden" id="hdnViewPermit" runat="server" />
</body>

<script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

<script type="text/javascript" src="Resources/js/jquery-ui-1.8.16.custom.min.js"></script>

<script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="Resources/js/Webutility.js"></script>

<script type="text/javascript" src="Resources/js/toolbar.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

<script src="Resources/js/jquery.ui.button.js" type="text/javascript"></script>

<script type="text/javascript" src="Resources/js/jquery.validate.js"></script>


<script type="text/javascript">
    
    var mode = "";
    var activeStatus = true;
    
//    $(window).bind('resize', function() {
//        $("#list").setGridWidth($('#box').width() - 10, true);
//    }).trigger('resize');
    jQuery("#box").css({ width: "97%" });
    //    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg.gif)');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });
    
    jQuery(document).ready(function() {
    
        LoadPermits();  
        LoadDesignation();  
         
        $("#telephoneno").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }            
            if($("#telephoneno").val().length > 20)
            {
                return false;
            }
        });
             
        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\ \&\#\@\.\:\*\%\(\)\^\~\!\/\?\<\>\_\-\'\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        $('#Cancel').click(function() {
            onCancel();
        });

        var myGrid = $('#list');
    
        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_CONSULTANT_DETAILS%>', '');
        Response.ResponseObject.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'designationid', index: 'designationid', width: 100, editable: true , hidden: true},
            { name: 'consultantname', index: 'consultantname', width: 100, editable: true },  		            		            
            { name: 'contactperson', index: 'contactperson', width: 100,editable: true },
            { name: 'telephoneno', index: 'telephoneno', width: 100, editable: true },
            { name: 'emailID', index: 'emailID', width: 100, editable: true },
            { name: 'address', index: 'address', width: 100, editable: true },
            { name: 'isactive', index: 'isactive', width: 20, editable: true, hidden: true },
            { name: 'activestatus', index: 'activestatus', width: 40, align: 'center', editable: true, formatter: cboxFormatter,
                stype:'select', searchoptions:{value: ":All;True:Active;False:Inactive",defaultValue: "All"},
                search:true,edittype: 'checkbox', editoptions: { value: 'True:False' }, formatoptions: { disabled: true }
             },
             { name: 'loginname', index: 'loginname', width: 20, editable: true, hidden: true }
             
        ];

        Response.ResponseObject.caption = "Consultant";
        
        Response.ResponseObject.autowidth= true;
        
        myGrid.jqGrid(Response.ResponseObject);
        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        $("#t_list").append("<button type='button' id='add' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><div></div><span>Add</span></button>");
        $("#t_list").append("<button type='button' id='edit' value='Edit' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/edit_icon.png'height=18px;width=18px alt='' /><br/><div></div><span>Edit</span></button>");
        $("#t_list").append("<button type='button' id='User' value='Create Users' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/create_users.png'height=18px;width=18px alt='' /><br/><div></div><span>Create Users</span></button>");
        $("#t_list").append("<button type='button' id='reset' value='Reset Password' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/reset_password.png' height=18px;width=18px alt='' /><br/><div></div><span>Reset Password</span></button>");
//        $("#t_list").append("<input type='button' id='reset' value='Reset Password' style='font-size:12px;font-family:arial;margin:8px;'/> ");
        
//        if ($('#hdnEmployeeID').val() != "1") {
//            onGetPermissionDisplay();
//        }
        $("button ,input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "add") {
                validator.resetForm();
                mode = "add";
                clearLabels();
                $("#isactive").attr('checked', true);
                document.getElementById("divConsultant").style.display = "";
                
            }
            else if (id.currentTarget.id == "edit") {   
                 
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divConsultant").style.display = "";
                   
                    fillData();
                }
                else { alert("Please select a row"); }
            }
           
             else if (id.currentTarget.id == "User") {
            
             var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
//                $('#ChildWB', parent.document).attr("src", "default.aspx?serve=Users");
                  window.showModalDialog('default.aspx?serve=Users&consultantName='+  ret.consultantname + ' ' + '&cnsID=' + ret.id + '&mod=CNT' , window.self, "dialogHeight:140px; dialogWidth:500px; resizable:yes; status:no; scroll:no;");
//                window.location.href = "default.aspx?serve=Users&empName=" + ret.FirstName + " " + ret.LastName + "&empID=" + ret.EmpID;
                    var LoginResponse = SendApplicationRequest('<%=HRAppCommands.GET_ALL_CONSULTANT_DETAILS%>', '');
                    if (LoginResponse.ResponseObject.datastr == null)
                        jQuery("#list").jqGrid('clearGridData');
                    else {
                        jQuery("#list").jqGrid('setGridParam', LoginResponse.ResponseObject);
                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                    }
                    $('#gs_activestatus').val("");
                }
                 else { alert("Please select a row"); }
             }
             
                else if (id.currentTarget.id == "reset") {
                mode = "reset";
                var Request = new Object();
                var ID = "";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                 
                if (id) {
                    if (ret.loginname == "") {
                      alert("Login details not yet created"); return;  
                    }
                    if (confirm('Do you want to reset?') == false) return;
                    var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                    ID = ret.id;
                    Request.ID = ID;
                    Request.ChangedBy = 1;
                    var Response = SendApplicationRequest("<%=CommonAppCommands.RESET_PASSWORD%>", Request, true);
                    alert(Response.Message);
                    if (Response.ResponseCommand == 'SUCCESS') {
                        mode = "";
                        var Request = new Object();
                        Request.LoginType="CNT";
                        var Response = SendApplicationRequest('<%=CommonAppCommands.USER_DETAILS%>', Request, true);
                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                        jQuery("#list").jqGrid('setCaption', "User Detail: ").trigger('reloadGrid');
                    }
                    jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                }
                else {
                    alert("Please Select User to reset!");
                }

            }
        });

//        var mygrid = jQuery('#list'),
//        cDiv = mygrid[0].grid.cDiv;
//        mygrid.setCaption("");
//        $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
//        $(cDiv).hide();
       // $("#list").closest(".ui-jqgrid-bdiv").height("auto");
        
        //GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {
                cmbdesignation: {
                    required: true
                },
                consultantname: {
                    required: true,
                    alphaNumerix: true
                },
                contactperson: {
                    required: true,
                    alphaNumerix: true
                },
                telephoneno: {
                    required: true,
                    minlength:10                   
                },
                address: {
                    required: true                   
                },  
                emailID:
                {
                required: true,
                email: true
                }            
            },
            
            messages: {
             cmbdesignation: {
                    required: "Select designation"
                },
                consultantname: {
                    required: "Enter Consultant Name",
                    alphaNumerix: "Invalid Consultant"
                },
                contactperson: "Enter Contact Person",
                telephoneno: "Enter Phone Number minimum 10 digit",
                address: "Enter Address",
                emailID: "Enter Email ID"               
            },
            
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            
            submitHandler: function(id) {

                if (mode == "edit") {
                    if (confirm('Do you want to Update the Changes made?') == false) return false;
                }
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                var ID = "";
                if (mode == "edit") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    ID = ret.id;
                   
                }
                else {
                    ID = "0";
                }
          
                Request.UpdateBy = $("#hdnEmployeeID").val();
                Request.ID = ID;
                Request.DesignationID = $("#cmbdesignation").val();
                Request.ConsultantName = $("#consultantname").val();
                Request.ContactPerson = $("#contactperson").val();
                Request.TelephoneNo = $("#telephoneno").val();
                Request.EmailID = $("#emailID").val(); 
                Request.Address = $("#address").val();                 
                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }        
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_CONSULTANT%>', Request, true);                           
                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = "SUCCESS";
                   var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_CONSULTANT_DETAILS%>', Request, true);
                    if (Response.ResponseObject.datastr == null)
                        jQuery("#list").jqGrid('clearGridData');
                    else {
                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                    }
                    
                    $('#gs_activestatus').val("");
                    clearLabels();
                    onCancel();
                }
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });
         $(document).delegate('#list .jqgrow td input', 'click', function(obj) {
            
            var splitid = (obj.srcElement.id).split('_');
            var ROWID = splitid[1];
            var IsChecked = obj.srcElement.checked;
            if (IsChecked) {
                ActivateRow(ROWID);
            }
            else
                DeActivateRow(ROWID);
        });
        
        function cboxFormatter(cellvalue, options, rowObject) {

            var chkd = '';
            if (cellvalue == "True") chkd = 'checked';
            var ele = '<input type="checkbox" ' + chkd + ' id="chkRowId_' + options.rowId + '"/>';
            return ele;
        }
    });
    
   
    function ActivateRow(ROWID) { 
        var ret = jQuery("#list").jqGrid('getRowData', ROWID);
        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        
        if (confirm('Do you want to activate?') == false) {
            $("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
            return;
        };
        
        var Request = new Object();
        ID = ret.id;
        Request.ID = ID;
        Request.IsActive = true;

        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_CONSULTANT%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_CONSULTANT_DETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
        
        $('#gs_activestatus').val("");
    }

    function DeActivateRow(ROWID) {
        var ret = jQuery("#list").jqGrid('getRowData', ROWID);
        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        
        if (confirm('Do you want to deactivate?') == false) {
            $("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
            return;
        };
        
        var Request = new Object();
        ID = ret.id;
        Request.ID = ID;
        Request.IsActive = false;

        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_CONSULTANT%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_CONSULTANT_DETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
        $('#gs_activestatus').val("");
    }
        function onCancel() {
        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        
        document.getElementById("divConsultant").style.display = "none";
    }

    function LoadDesignation(){
    
      var optn = document.createElement("OPTION");
      optn.text = "Select Designation";
      optn.value = "";
      document.getElementById('cmbdesignation').options.add(optn);
      var Response = SendApplicationRequest("<%=HRAppCommands.DESIGNATIONCOMBO_DETAILS%>", '', true);
      if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
          var arr = Response.ResponseObject;
          for (var i = 0; i < arr.length; ++i) {
              var optn = document.createElement("OPTION");
              optn.text = arr[i]['DesignationName'];
              optn.value = arr[i]['ID'];
              document.getElementById('cmbdesignation').options.add(optn);
          }
      }
    }
    function fillData() {
    
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#cmbdesignation").val(ret.designationid);
        $("#consultantname").val(ret.consultantname);
        $("#contactperson").val(ret.contactperson);
        $("#telephoneno").val(ret.telephoneno);   
        $("#emailID").val(ret.emailID);
        $("#address").val(ret.address);     
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }      
        
    }

    function clearLabels() {
        $("#cmbdesignation").val("");
        $("#consultantname").val("");        
        $("#contactperson").val("");   
         $("#telephoneno").val("");        
         $("#emailID").val("");        
        $("#address").val("");       
        $("#isactive").attr('checked', false);         
    }    
     
    function LoadPermits() {
        var Response = LoadPermissions($('#hdnmodule').val(), $('#hdnEmployeeID').val());
        if (Response != null) {
            $('#hdnApplyPermit').val(Response['Apply']);
            $('#hdnApprovlPermit').val(Response['Approvals']);
            $('#hdnViewPermit').val(Response['ViewMode']);
        }
    }
    
    function onGetPermissionDisplay() {
        document.getElementById("add").style.display = "none";
        document.getElementById("edit").style.display = "none";
        document.getElementById("activate").style.display = "none";
        document.getElementById("deactivate").style.display = "none";

        if (document.getElementById("hdnApplyPermit").value == "true") {
            document.getElementById("add").style.display = "";            
        }
        if (document.getElementById("hdnApprovlPermit").value == "true") {
            document.getElementById("activate").style.display = "";
            document.getElementById("deactivate").style.display = "";
            document.getElementById("edit").style.display = "";
        }
    } 
     
</script>
<script type="text/javascript">
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('#t_list').css('background', 'none');
        $('#t_list').css('background-color', '#fff');
//        $('#t_list').css('padding', '10px 0px');
        $('#t_list input[type=button]').css('margin-left', '10px');
        $('body input[type=button]').button();
        $('body input[type=submit]').button();
        $('body button').button();
        $('body input[type=text]').addClass('text ui-widget-content ui-corner-all');
        $('body textarea').addClass('text ui-widget-content ui-corner-all');
        $('body select').addClass('text ui-widget-content ui-corner-all');
        $('#pager input[type=text]').css('width', '40px');
        $('#pager select').css('width', '50px');
        $('#pager select').css('margin-left', '15px');
    });
</script>

</html>
