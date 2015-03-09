<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleMaster.aspx.cs" Inherits="AltioStarHR.RoleMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Role Master</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    
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
    <img alt="" src="Resources/Images/NewImages/1.png" style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
    <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
    <strong class="family1 imageheadercolor">Role Details</strong>
    </div>
    </div>

    <div id="divRole" class="family" title="Role" style="display:none;background-color:White;width:100%;">
        <form id="signupForm" method="get" action="">
        <table style="width:100%;background-color:#a4cd0f">
            <td>
              <table style="width:100%">
                <tr>
                    <td style="width:20%;height:40px;">
                        <label id="lrole" for="role" class="family">
                            Role</label>
                            <span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td style="width:20%;height:40px;">
                        <input id="role" name="role" type="text" value="" style="width: 220px;border:1px solid silver" class="family"/>
                    </td>
                    <td >
                    </td>
                </tr>
                <tr>
                    <td style="width:20%;height:40px;" >
                        <label id="ldescription" for="description" class="family">
                            Description</label>
                            <span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td style="width:20%;height:40px;">
                        <textarea id="description" name="description" style="width: 220px;border:1px solid silver" cols="30" rows="3" class="family">
                        </textarea>
                    </td>
                    <td>
                    </td>
                </tr>
                   
        
                <tr>
                    <td class="label">
                        <label id="lisactive" class="family">
                            Active</label>
                    </td>
                    <td class="field">
                        <input id="isactive" type="checkbox" />
                    </td>
                    <td class="status" id="sisactive">
                    </td>
                </tr>
                </table>
            </td>
                <tr>
                    <td id="Td1" colspan="2" style="width: 600px" runat="server">
                        <span align="right" class="family" id='lblDesig'>Assign Permissions to Module: </span>
                        <br />
                        <span class="family">Select All :
                            <input id="chkAll" type="checkbox" onclick="return onCheckAll();" /></span>
                        <table id="permissions" class="family">
                        </table>
                        <div id="PagerPermissions" style="display: none;">
                        </div>
                    </td>
                    <td id="Td2" style="width: 200px;display:none" runat="server">
                        <span></span>
                        <br />
                        <span align="right" class="family" id='lblReports'>Assign Dashboard Reports: </span>
                        <table id="reports" style="width: 200px">
                        </table>
                    </td>
                </tr>
        <table>
            <tr align="center">
                <td class="field">
                    <input id="signupsubmit" name="Submit" type="submit" value="Save" style="background-color:#00DBF1" class="family"/>
                </td>
                <td class="field">
                    <input id="Cancel" name="Cancel" type="button" value="Cancel" style="background-color:#00DBF1" class="family"/>
                </td>
            </tr>
        </table>
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
    <input type="hidden" id="hdnApply" runat="server" />
    <input type="hidden" id="hdnApprove" runat="server" />
    <input type="hidden" id="hdnView" runat="server" />
    <input type="hidden" id="hdnRoleid" runat="server" />
    <input type="hidden" id="hdnModuleName" runat="server" />
    <input type="hidden" id="hdnLoggedUserID" runat="server" />
</body>
<script src="Resources/js/Newjs/jquery-1.9.1.js" type="text/javascript"></script>
<script src="Resources/js/Newjs/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>

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
//     $(window).bind('resize', function() {
//         $("#list").setGridWidth($('#box').width() - 10, true);
//     }).trigger('resize');

     jQuery(document).ready(function() {
     $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });
            LoadPermits();
            LoadReports();
            LoadPermission();
            $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\_\-\ \&\s ]*$/i.test(value);
            }, "Username must contain only letters, numbers, or dashes.");

            $('#Cancel').click(function() {
                onCancel();
            });
            var myGrid = $('#list');
            var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_ROLETYPE_DETAILS%>', '');            
            Response.ResponseObject.colModel = [
                { name: 'roleid', index: 'roleid', width: 20, hidden: true, sorttype: "int" },
                { name: 'role', index: 'role', width: 100, editable: true },
                { name: 'description', index: 'description', width: 100, editable: true },
                { name: 'isactive', index: 'isactive', width: 40, editable: true, hidden: true },
                { name: 'activestatus', index: 'activestatus', width: 40, align: 'center', editable: true, formatter: cboxFormatter,
                    stype:'select', searchoptions:{value: ":All;True:Active;False:Inactive",defaultValue: "All"},
                    search:true,edittype: 'checkbox', editoptions: { value: 'True:False' }, formatoptions: { disabled: true }
                 },
            ]
            
            Response.ResponseObject.caption = "";
            
            Response.ResponseObject.autowidth= true;
             
            myGrid.jqGrid(Response.ResponseObject);
            jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
            jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
            jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
                onClickButton: function() {
                    myGrid[0].toggleToolbar()
                }
            });
            
//        $("#t_permissions").closest(".ui-userdata").hide();
//        $("#t_reports").closest(".ui-userdata").hide();
        
            jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");            
            $("#t_list").append("<button type='button' id='add' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><div></div><span>Add</span></button>");
            $("#t_list").append("<button type='button' id='edit' value='Edit' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/edit_icon.png'height=18px;width=18px alt='' /><br/><div></div><span>Edit</span></button>");
           

            $("button ,input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "add") {
                onCheckAll();
                validator.resetForm();
                mode = "add";
                clearLabels();
                $("#isactive").attr('checked', true);
                document.getElementById("divRole").style.display = "";
                $('#divRole').dialog({
                    height: 600,
                    width: 920,
                    modal: true
                })
                $("input[type='text']:first", document.forms[0]).focus();
            }
            else if (id.currentTarget.id == "edit") {
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    onCheckAll();
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divRole").style.display = "";
                    $('#divRole').dialog({
                        height: 600,
                        width: 920,
                        modal: true
                    })
                    fillData();
                    resetreportsdata();
                    fillreportsdata();                    
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    fillpermissiondata(ret.roleid);
                    $("input[type='text']:first", document.forms[0]).focus();
                }
                else { alert("Please select a row"); }
            }
           
           
           });

           var mygrid = jQuery('#list'),
           cDiv = mygrid[0].grid.cDiv;
           mygrid.setCaption("");
           $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
           $(cDiv).hide();
          // $("#list").closest(".ui-jqgrid-bdiv").height("auto");
           GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {
                role: {
                    required: true,
                    alphaNumerix: true,
                    maxlength: 50
                },
                description: {
                    required: true,
                    maxlength: 250
                }
            },
            messages: {
                role: {
                    required: "Enter Role",                   
                    maxlength: jQuery.format("Max length is {0} characters"),
                    alphaNumerix: "Invalid Role"
                },
                description: {
                    required: "Enter Description",
                    maxlength: jQuery.format("Max length is {0} characters")
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                var ID = "";
                var reportids = "";
                var sortorder = 0;
                if (mode == "edit") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    ID = ret.roleid;
                    sortorder = ret.sortorder;
                }
                else {
                    ID = "0";
                }
                reportids = StoreReportIds("#reports");
                Request.UpdatedBy = $("#hdnEmployeeID").val();
                Request.RoleID = ID;
                Request.Role = $("#role").val();
                Request.Description = $("#description").val();
                Request.Reports = reportids;               
                var result = '';
                result = GetPermissionGridDatainfo("#permissions");
                Request.Permissions = result;
                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }                
                if(mode == "edit")
                {
                  if(confirm('Do you want to Update the Changes made?') == false)
                     return false;
                }
                                
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_ROLE%>', Request, true);
                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = "SUCCESS";
                    
                      var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_ROLETYPE_DETAILS%>', Request, true);
                    if (Response.ResponseObject.datastr == null)
                        jQuery("#list").jqGrid('clearGridData');
                    else {
                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                    }
                    
                    $('#gs_activestatus').val("");
                    GridActiveButton();
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
        ID = ret.roleid;
        Request.ID = ID;
        Request.ChangedBy = $('#hdnLoggedUserID').val();

        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_ROLE%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_ROLETYPE_DETAILS%>', Request, true);
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
        ID = ret.roleid;
        Request.ID = ID;
        Request.ChangedBy = $('#hdnLoggedUserID').val();

        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_ROLE%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_ROLETYPE_DETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
        $('#gs_activestatus').val("");
    }
    
    function GridActiveButton() {
     if (document.getElementById("hdnApprovlPermit").value == "true") {
        document.getElementById("activate").style.display = "none";
        document.getElementById("deactivate").style.display = "none";
        if (activeStatus == false)
            document.getElementById("activate").style.display = "";
        else
            document.getElementById("deactivate").style.display = "";
            }
    }
    function onCancel() {

        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        $("#divRole").dialog('close');
    }

    function fillData() { 
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#role").val(ret.role);
        $("#description").val(ret.description);
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }
    }
    
    function StoreReportIds(gridId) {
        var strvalues;
        var reports = "";
        var lista = jQuery(gridId).getGridParam('selarrrow');
        for (i = 0; i <= lista.length - 1; i++) {
            strvalues = null;
            strvalues = lista[i] + "?";
            if (reports == "")
                reports = strvalues;
            else
                reports = reports + strvalues;
        }
        return reports;
    }

    function resetreportsdata() {
        jQuery('#reports').jqGrid('resetSelection');
    }

    function fillreportsdata() {    
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        var Request = new Object();
        Request.RoleID = ret.roleid;
        var Response = SendApplicationRequest('<%=HRAppCommands.ROLE_REPORTSINFO%>', Request, true, '');
        if (Response.ResponseCommand == "SUCCESS") {
            var arr = Response.ResponseObject;
            var lista = jQuery("#reports").jqGrid('getRowData');
            for (i = 0; i <= lista.length - 1; i++) {
                for (j = 0; j < arr.length; ++j) {
                    if (arr[j]["ReportID"] == lista[i]["id"])
                        $('#reports').setSelection(lista[i]["id"], true);
                }
            }
        }
    }

    function LoadReports() {
        var myGrid = $('#reports');
        var Response = SendApplicationRequest('<%=HRAppCommands.DASHBOARDREPORTS_DETAILS%>', '');
        Response.ResponseObject.colModel = [
   		            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
		            { name: 'reportname', index: 'reportname', width: 100, editable: true }
   	            ]
        Response.ResponseObject.multiselect = true;
        Response.ResponseObject.caption="Report Details";
        myGrid.jqGrid(Response.ResponseObject);
        jQuery("#reports").jqGrid('setGridHeight', "250");
        jQuery("#reports").jqGrid('setGridWidth', "300");
        jQuery("#reports").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        jQuery("#reports").jqGrid('setGridParam', { rowNum: 2000 });
    }

    function LoadPermission() {      
        var myGrid = $('#permissions');
        var Request = new Object();
        Request.RoleID = "0";

        var Response = SendApplicationRequest('<%=HRAppCommands.PERMISSION_DETAILS%>', Request, true, '');
        Response.ResponseObject.colModel = [
   		            { name: 'functionid', index: 'functionid', hidden: true, sorttype: "int" },
   		            { name: 'functionname', index: 'functionname', width: 200, editable: false, hidden: true },
   		            { name: 'category', index: 'category', width: 100, hidden: true, editable: false },
   		            { name: 'title', index: 'title', width: 200, editable: false },
   		            { name: 'apply', index: 'apply', width: 60, align: 'center', editable: true, formatter: 'checkbox',
   		                edittype: 'checkbox', editoptions: { value: 'Yes:No' }, formatoptions: { disabled: false }
   		            },
   		            { name: 'approvals', index: 'approvals', width: 60, align: 'center', editable: true, formatter: 'checkbox',
   		                edittype: 'checkbox', editoptions: { value: 'Yes:No' }, formatoptions: { disabled: false }
   		            },
   		            { name: 'viewmode', index: 'viewmode', width: 60, align: 'center', editable: true, formatter: 'checkbox',
   		                edittype: 'checkbox', editoptions: { value: 'Yes:No' }, formatoptions: { disabled: false }
   		            }
   	            ]
   	            
   	    Response.ResponseObject.caption = "Permission details";
        Response.ResponseObject.rownumbers = true;
        //Response.ResponseObject.pager = "Pager";
        Response.ResponseObject.forceFit = true;
        Response.ResponseObject.cellEdit = true;
        Response.ResponseObject.beforeSelectRow = function(rowid, e) {
            if (rowid != "" || rowid != null) {
                var ret = jQuery("#permissions").jqGrid('getRowData', rowid);
                if (ret["approvals"] == "Yes")
                    jQuery("#permissions").jqGrid('setRowData', rowid, { viewmode: 'Yes' });
                if (ret["apply"] == "Yes")
                    jQuery("#permissions").jqGrid('setRowData', rowid, { viewmode: 'Yes' });
            }
        }

        myGrid.jqGrid(Response.ResponseObject);
        jQuery("#permissions").jqGrid('setGridHeight', "250");
        jQuery("#permissions").jqGrid('setGridWidth', "560");
        jQuery("#permissions").jqGrid('setGridParam', { rowNum: 2000 });
        jQuery("#permissions").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
    }

    function GetPermissionGridDatainfo(gridId) {
        var strvalues;
        var res = "";
        var lista = jQuery("#permissions").jqGrid('getRowData');
        for (i = 0; i <= lista.length - 1; i++) {
            strvalues = null;
            strvalues = lista[i];
            if (strvalues != null) {
                if (lista[i]["apply"] == "Yes" || lista[i]["approvals"] == "Yes" || lista[i]["viewmode"] == "Yes")
                    res = res + lista[i]["functionid"] + "," + lista[i]["apply"] + "," + lista[i]["approvals"] + "," + lista[i]["viewmode"] + "?";
            }
        }
        res = res + 1 + ",Yes,Yes,Yes?";
        return res;
    }
    function onCheckAll() {
        var lista = jQuery("#permissions").jqGrid('getRowData');
        if (document.getElementById("chkAll").checked) {
            for (i = 0; i <= lista.length - 1; i++) {
                jQuery("#permissions").jqGrid('setRowData', lista[i]["functionid"], { apply: 'Yes' });
                jQuery("#permissions").jqGrid('setRowData', lista[i]["functionid"], { approvals: 'Yes' });
                jQuery("#permissions").jqGrid('setRowData', lista[i]["functionid"], { viewmode: 'Yes' });
            }

            $("#permissions").attr("disabled", true);
        }
        else {
            $("#permissions").attr("disabled", false);
            for (i = 0; i <= lista.length - 1; i++) {
                jQuery("#permissions").jqGrid('setRowData', lista[i]["functionid"], { apply: 'No' });
                jQuery("#permissions").jqGrid('setRowData', lista[i]["functionid"], { approvals: 'No' });
                jQuery("#permissions").jqGrid('setRowData', lista[i]["functionid"], { viewmode: 'No' });
            }
        }
    }

    function fillpermissiondata(roleid) {
        var Request = new Object();
        Request.RoleID = roleid;
        var currPage = jQuery('#permissions').jqGrid('getGridParam', 'page');
        var Response = SendApplicationRequest('<%=HRAppCommands.PERMISSION_DETAILS%>', Request, true, '');
        jQuery("#permissions").jqGrid('clearGridData');
        Response.ResponseObject.rowNum = 2000;
        Response.ResponseObject.rowList = [120, 240, 360];
        jQuery("#permissions").jqGrid('setGridParam', Response.ResponseObject);
        jQuery("#permissions").jqGrid('setGridParam', { rowNum: 2000 });
        jQuery("#permissions").jqGrid('setCaption', "Permission  Details").trigger('reloadGrid');
        jQuery("#permissions").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
    }

    function LoadPermits() {
        var Response = LoadPermissions($('#hdnmodule').val(), $('#hdnRoleid').val());
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
       
     function clearLabels() {
        $("#role").val("");
        $("#description").val("");
        $("#isactive").attr('checked', false);
        $("#permissions").attr("disabled", false);
        document.getElementById("chkAll").checked = false;
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
