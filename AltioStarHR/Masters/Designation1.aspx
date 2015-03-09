<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Designation1.aspx.cs" Inherits="AltioStarHR.Masters.Designation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Designation</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
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
    </style>
</head>
<body>
    <%--<form id="form1" runat="server">
    <div>
    <div>Welcome to Designation</div>
    </div>
    </form>--%>
     <div>
        <div class="header_title2">
            Designations</div>
        <div class="dvGrid">
            <div id="t_list">
            </div>
            <table id="list">
            </table>
        </div>
    </div>
    <%--<div id="divInactiveDesignation" class="dialog" title="Inactive Designation" style="display: none;">
        <table class="teble_bg" style="width: 200px">
            <tbody>
                <tr align="center">
                    <td>
                        <input id="activate" name="activate" type="button" value="Acivate" />
                        <input id="closeactivatedialog" name="closeactivatedialog" type="button" value="Close" />
                    </td>
                </tr>
                <tr align="center">
                    <td>
                       <select id="reptdesignation" name="reptdesignation" runat="server" style="width: auto">
                       </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="InactiveGrid">
                        </table>
                        <div id="InactivePager">
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>--%>
    <div id="divDesignation" class="dialog" title="Designation" style="display: none;">
        <form id="signupForm" method="get" action="">
        <fieldset>
            <table class="teble_bg" style="width: 200px">
                <tbody>
                    <tr>
                        <td>
                            <table style="width: 500px">
                                <tr>
                                    <td class="label" width="200" height="40">
                                        <label id="ldesignation" for="designation">
                                            Designation</label>
                                            <span style="font-size: medium; color: Red">*</span>
                                    </td>
                                    <td class="field" width="200" height="40">
                                        <input id="designation" name="designation" type="text" style="width: 200px" value=""
                                            maxlength="100" />
                                    </td>
                                    <td id="sdesignation" width="200" height="40">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label" width="200" height="40">
                                        <label id="ldescription" for="description">
                                            Description</label>
                                            <span style="font-size: medium; color: Red">*</span>
                                    </td>
                                    <td class="field" width="200" height="40">
                                        <textarea id="description" name="description" style="width: 200px" maxlength="100"
                                            rows="3"></textarea>
                                    </td>
                                    <td id="sdescription" width="200" height="40">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <span class="label" id='lblDesig'>Functional Reporting To : </span>
                                        <table id="leavedesignation">
                                        </table>
                                    </td>
                                    <td>
                                        <span class="label" id='lbladminreport'>Administration Reporting To : </span>
                                        <table id="AdminRepoDesign">
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="label" id='lblrole'>Assign Role: </span>
                            <table id="role">
                            </table>
                            <div id="rolepager">
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table>
                <tr align="center">
                    <td class="field">
                        <input id="signupsubmit" name="Submit" type="submit" value="Save" />
                    </td>
                    <td class="field">
                        <input id="Cancel" name="Cancel" type="button" value="Cancel" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <input type="hidden" id="hdnEmployeeID" runat="server" />
        <input type="hidden" id='hdnmodule' runat="server" />
        <input type="hidden" id='hdnApprovlPermit' runat="server" />
        <input type="hidden" id="hdnApplyPermit" runat="server" />
        <input type="hidden" id="hdnViewPermit" runat="server" />
        </form>
    </div>
   
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

    // Code to Prevent the BackSpace key from Working as "Go To Back Page."
    //    $(document).keydown(function(e) {

    //        var nodeName = e.target.nodeName.toLowerCase();
    //        if (e.which == 8) {
    //            if ((nodeName == 'input' && e.target.type == 'text') || nodeName == 'textarea') {
    //                /* do nothing */
    //            }
    //            else { e.preventDefault(); }
    //        }
    //    });


    var mode = "";
    jQuery(document).ready(function() {

        // LoadPermits();
        //LoadLeaveDesignation();
        //LoadAdminRepoDesign();
        LoadRoles();
        LoadDesignation()
        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");


        $('#activate').click(function() {
            onActivate();
        });
        $('#Cancel').click(function() {
            onCancel();
        });
        $('#closeactivatedialog').click(function() {
            onCancelActivateDialog();
        });

        var myInactiveGrid = $('#InactiveGrid');
        var Responses = SendApplicationRequest('<%=HRAppCommands.INACTIVE_DESIGNATION%>', '');
        Responses.ResponseObject.colModel = [
           		            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
           		            { name: 'desc', index: 'desc', width: 100, editable: true }
           	            ]
        Responses.ResponseObject.height = "200";
        Responses.ResponseObject.width = "250";
        Responses.ResponseObject.pager = "";
        Responses.ResponseObject.rownum = "500";
        myInactiveGrid.jqGrid(Responses.ResponseObject);
        //jQuery("#InactiveGrid").jqGrid('navGrid', '#InactivePager', { del: false, add: false, edit: false, search: false });
        jQuery("#InactiveGrid").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        //        jQuery("#InactiveGrid").jqGrid('navButtonAdd', "#InactivePager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
        //            onClickButton: function() {
        //                myGrid[0].toggleToolbar()
        //            }
        //        });

        jQuery("#InactiveGrid").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '');
        $("#list").jqGrid({
            datatype: 'jsonstring',
            datastr: Response.ResponseObject.datastr,
            colNames: ["ID", " "], //scription
            colModel: [
                       { name: 'id', index: 'id', width: 1, hidden: true, key: true },
                       { name: 'desc', index: 'desc', hidden: false, sortable: true }
                      ],
            treeGridModel: 'adjacency',
            rowNum: '1000',
            height: '375',
            width: '800',
            pager: 'ptreegrid',
            treeGrid: true,
            ExpandColumn: 'desc',
            ExpandColClick: true,
            caption: "Designation Details"
        });
        Response.ResponseObject.caption = "";
        myGrid.jqGrid(Response.ResponseObject);
        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        $("#t_list").append("<input type='button' id='add' value='Add'  style='height:30px;font-size:-3;text-align: center'/> ");
        $("#t_list").append("<input type='button' id='edit' value='Edit' style='height:30px;font-size:-3;text-align: center'/> ");
        $("#t_list").append("<input type='button' id='activate' value='Activate' style='height:30px;font-size:-3;text-align: center'/> ");
        $("#t_list").append("<input type='button' id='deactivate' value='Deactivate' style='height:30px;font-size:-3;text-align: center'/> ");
        //            $("#t_list").append("<input type='button' id='reset' value='Refresh' style='height:30px;font-size:-3;text-align: center'/> ");
        $("#t_list").append("Active <input type='checkbox' id='activedata' value='activedata' checked /> ");

        if ($('#hdnEmployeeID').val() != "1") {
            onGetPermissionDisplay();
        }
        $("input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "add") {
                validator.resetForm();
                mode = "add";
                clearLabels();
                $("#isactive").attr('checked', true);
                document.getElementById("divDesignation").style.display = "";
                $('#divDesignation').dialog({
                    height: 400,
                    width: 550,
                    modal: true
                })
            }
            else if (id.currentTarget.id == "edit") {
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divDesignation").style.display = "";
                    $('#divDesignation').dialog({
                        height: 400,
                        width: 550,
                        modal: true
                    })
                    fillData();
                }
                else { alert("Please select a row"); }
            }
            else if (id.currentTarget.id == "activedata") {
                mode = "activedata";
                BindGrid(currPage);
            }

            else if (id.currentTarget.id == "deactivate") {
                mode = "deactivate";
                var Request = new Object();
                var ID = "";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if (id) {
                    if (ret.isactive == 'True') {
                        if (confirm('Do you want to deactivate?') == false) return;
                        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                        ID = ret.id;
                        Request.ID = ID;
                        Request.ChangedBy = $("#hdnEmployeeID").val();
                        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_DESIGNATION%>", Request, true);
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '', true);

                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else alert("Selected Designation is already deactivated!");
                }
                else alert("Please Select a Designation to deactivate!");
            }
            else if (id.currentTarget.id == "activate") {
                mode = "activate";
                var Request = new Object();
                var ID = "";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if (id) {
                    if (ret.isactive == 'False') {
                        if (confirm('Do you want to activate?') == false) return;
                        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                        ID = ret.id;
                        Request.ID = ID;
                        Request.ChangedBy = $("#hdnEmployeeID").val();
                        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_DESIGNATION%>", Request, true);
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=HRAppCommands.INACTIVE_DESIGNATION%>', '', true);

                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else alert("Selected Designation is already activated!");
                }
                else alert("Please Select a Designation to activate!");
            }
        });
        //  ***          $("input", "#t_list").click(function(id) {
        //                if (id.currentTarget.id == "add") {
        //                    validator.resetForm();
        //                    ;
        //                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        //                    if (id) {
        //                        mode = "add";
        //                        clearLabels();
        //                        document.getElementById("divDesignation").style.display = "";
        //                        $('#divDesignation').dialog({
        //                            height: 400,
        //                            width: 700,
        //                            modal: true
        //                        })
        //                        //                        var Request = new Object();
        //                        //                        Request.DesignationID = "0";
        //                        //                        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_HIRE_INFO%>', Request, true);
        //                        //                        jQuery("#leavedesignation").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
        //                        //                        jQuery("#leavedesignation").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");

        //                        //                        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_HIRE_INFO%>', Request, true);
        //                        //                        jQuery("#AdminRepoDesign").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
        //                        //                        jQuery("#AdminRepoDesign").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");

        //                        $("input[type='text']:first", document.forms[0]).focus();
        //                    }
        //                    else { alert("Please select root node to add"); }
        //                }
        //                else if (id.currentTarget.id == "edit") {
        //                    validator.resetForm();
        //                    ;
        //                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        //                    if (id) {
        //                        var ret = jQuery("#list").jqGrid('getRowData', id);
        //                        var ID = ret.id;
        //                        var NodeName = ret.desc;
        //                        if (ID != 0) {
        //                            mode = "edit";
        //                            clearLabels();
        //                            document.getElementById("divDesignation").style.display = "";
        //                            $('#divDesignation').dialog({
        //                                height: 400,
        //                                width: 700,
        //                                modal: true
        //                            })
        //                            fillData();
        //                            //                            var Request = new Object();
        //                            //                            var ID = ret.id;
        //                            //                            Request.DesignationID = ID;
        //                            //                            var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_HIRE_INFO%>', Request, true);
        //                            //                            jQuery("#leavedesignation").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
        //                            //                            jQuery("#leavedesignation").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");

        //                            //                            var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_HIRE_INFO%>', Request, true);
        //                            //                            jQuery("#AdminRepoDesign").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
        //                            //                            jQuery("#AdminRepoDesign").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");

        //                            $("input[type='text']:first", document.forms[0]).focus();
        //                        }
        //                        else { alert(NodeName + " cannot be edited"); }
        //                    }
        //                    else { alert("Select Designation"); }
        //                }
        //                else if (id.currentTarget.id == "deactivate") {
        //                    mode = "deactivate";
        //                    ;
        //                    var Request = new Object();
        //                    var ID = "";
        //                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        //                    var ret = jQuery("#list").jqGrid('getRowData', id);
        //                    if (id) {
        //                        if (confirm('Do you want to deactivate?') == false) return;
        //                        ID = ret.id;
        //                        Request.ID = ID;
        //                        Request.ChangedBy = $("#hdnEmployeeID").val();
        //                        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_DESIGNATION%>", Request, true);
        //                        alert(Response.Message);
        //                        if (Response.ResponseCommand == 'SUCCESS') {
        //                            var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '');
        ////                            jQuery("#list").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
        ////                            jQuery("#list").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");
        //                            //                            jQuery("#list").jqGrid('resetSelection');
        //                            if (Response.ResponseObject.datastr == null)
        //                                jQuery("#list").jqGrid('clearGridData');
        //                            else {
        //                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
        //                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        //                            }

        //                            var Responsee = SendApplicationRequest('<%=HRAppCommands.INACTIVE_DESIGNATION%>', '', true);
        //                            if (Responsee.ResponseObject.datastr == null)
        //                                jQuery("#InactiveGrid").jqGrid('clearGridData');
        //                            else {
        //                                jQuery("#InactiveGrid").jqGrid('setGridParam', Responsee.ResponseObject);
        //                                jQuery("#InactiveGrid").jqGrid('setCaption', "DesignationDetails").trigger('reloadGrid');
        //                                jQuery("#InactiveGrid").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
        //                                mode = "SUCCESS";
        //                                onCancelActivateDialog();
        //                            }
        //                        }
        //                    }
        //                    else { alert("Select Designation"); }
        //                }
        //                else if (id.currentTarget.id == "deactivatelist") {
        //                    $("#reptdesignation").val("");
        //                    mode = "deactivatelist";
        //                    document.getElementById("divInactiveDesignation").style.display = "";
        //                    $('#divInactiveDesignation').dialog({
        //                        height: 430,
        //                        width: 280,
        //                        modal: true
        //                    })
        //                }

        //                else if (id.currentTarget.id == "reset") {
        //                    var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '');
        //                    jQuery("#list").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
        //                    jQuery("#list").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");
        //                    jQuery("#list").jqGrid('resetSelection');
        //                }
        //            ***});
        GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {
                designation: {
                    required: true//,
                    //alphaNumerix:true
                },

                description: {
                    required: true,
                    maxlength: 250
                }
            },
            messages: {
                designation: {
                    required: "Enter Designation"//,
                    //alphaNumerix: "Invalid Designation"
                },
                description: {
                    required: "Enter Description",
                    maxlength: jQuery.format("Max length is {0} characters")
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            //                ***submitHandler: function() {
            //                    ;
            //                    var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
            //                    var Request = new Object();
            //                    var ID = "";
            //                    var ParentID = "";
            //                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
            //                    var ret = jQuery("#list").jqGrid('getRowData', id);
            //                    var parentid = jQuery("#list").jqGrid('getGridParam', 'selrow');
            //                    var parentret = jQuery("#list").jqGrid('getRowData', parentid);
            //                    // var parentid = jQuery("#AdminRepoDesign").jqGrid('getGridParam', 'selrow');
            //                    //  var parentret = jQuery("#AdminRepoDesign").jqGrid('getRowData', parentid);
            //                    if (!parentid) ParentID = "0";
            //                    if (mode == "edit") {
            //                        ID = ret.id;
            //                    }
            //                    else {
            //                        ID = "0";
            //                        //ParentID = ret.id;
            //                    }
            //                    Request.UpdateBy = $("#hdnEmployeeID").val();
            //                    Request.DesignationID = ID;
            //                    Request.ParentDesignationID = parentret.id;
            //                    //  var leaveid = jQuery("#leavedesignation").jqGrid('getGridParam', 'selrow');
            //                    //  var ret = jQuery("#leavedesignation").jqGrid('getRowData', leaveid);
            //                    //if (!leaveid) leaveid = "0";
            //                    Request.LeaveAppliedTo = "0"; // leaveid;

            //                    // ParentID = parentret.id;
            //                    var roleid = jQuery("#role").jqGrid('getGridParam', 'selrow');
            //                    var ret = jQuery("#role").jqGrid('getRowData', roleid);
            //                    if (!roleid) roleid = "0";
            //                    Request.RoleID = roleid;
            //                    Request.Designation = $("#designation").val();
            //                    Request.Description = $("#description").val();
            //                    Request.IsActive = true;

            //                    var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_DESIGNATION%>', Request, true);
            //                    if (mode == "edit") {
            //                        if (confirm('Do you want to Update the Changes made?') == false)
            //                            return false;
            //                    }
            //                    alert(Response.Message);
            //                    if (Response.ResponseCommand == 'SUCCESS') {
            //                        mode = "SUCCESS";
            //                        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '', true);
            //                        jQuery("#list").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
            //                        jQuery("#list").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");
            //                        jQuery("#list").setGridParam({ 'selrow': '' });

            //                        //                        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '');
            //                        //                        jQuery("#leavedesignation").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
            //                        //                        jQuery("#leavedesignation").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");
            //                        //                        jQuery("#leavedesignation").setGridParam({ 'selrow': '' });
            //                        clearLabels();
            //                        onCancel();
            //                    }
            //                },
            submitHandler: function(id) {
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                var ID = "";
                if (mode == "edit") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    ID = ret.id;
                    if (confirm('Do you want to Update the Changes made?') == false) return false;
                }
                else {
                    ID = "0";
                }
                var roleid = jQuery("#role").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#role").jqGrid('getRowData', roleid);
                if (!roleid) roleid = "0";
                Request.RoleID = roleid;
                Request.Designation = $("#designation").val();
                Request.Description = $("#description").val();
                Request.IsActive = true;

                if ($("#isactive").is(':checked')) {
                    Request.IsActive = true;
                }
                else {
                    Request.IsActive = false;
                    $("#reptdesignation").val("");
                    //                    mode = "deactivatelist";
                    document.getElementById("divInactiveDesignation").style.display = "";
                    $('#divInactiveDesignation').dialog({
                        height: 430,
                        width: 280,
                        modal: true
                    })
                }
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_DESIGNATION%>', Request, true);
                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = "SUCCESS";
                    BindGrid(currPage);
                    clearLabels();
                    onCancel();
                }
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });

    });

        function onCancel() {
            if (mode != "SUCCESS") {
                if (confirm('Do you want to cancel?') == false) return;
            }
            $("#divDesignation").dialog('close');
        }
        function onCancelActivateDialog() {
            if (mode != "SUCCESS") {
                if (confirm('Do you want to cancel?') == false) return;
            }
            $("#divInactiveDesignation").dialog('close');
        }

        function onActivate() {
            var id = jQuery("#InactiveGrid").jqGrid('getGridParam', 'selrow');
            var Request = new Object();
            var ID = "";
            mode = "activate";
            if (id) {
                if ($("#reptdesignation").val() == "") {
                    alert("Select Reporting Designation");
                    return;
                }
                var ret = jQuery("#InactiveGrid").jqGrid('getRowData', id);
                if (confirm('Do you want to activate?') == false) return;
                ID = ret.id;
                Request.ID = ID;
                Request.ChangedBy = $("#hdnEmployeeID").val();
                Request.RepoMgr = $("#reptdesignation").val();
                var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_DESIGNATION%>", Request, true);
                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '');
                    jQuery("#list").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
                    jQuery("#list").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");
                    jQuery("#list").jqGrid('resetSelection');

                    var Responsee = SendApplicationRequest('<%=HRAppCommands.INACTIVE_DESIGNATION%>', '', true);
                    if (Responsee.ResponseObject.datastr == null)
                        jQuery("#InactiveGrid").jqGrid('clearGridData');
                    else {
                        jQuery("#InactiveGrid").jqGrid('setGridParam', Responsee.ResponseObject);
                        jQuery("#InactiveGrid").jqGrid('setCaption', "DesignationDetails").trigger('reloadGrid');
                        jQuery("#InactiveGrid").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
                        mode = "SUCCESS";
                        onCancelActivateDialog();
                    }
                }
            }
            else alert("Select designation to activate");
        }
        
        function fillData() {

            var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#list").jqGrid('getRowData', id);
            $("#designation").val(ret.desc);
            var Request = new Object();
            var ID = ret.id;
            Request.DesignationID = ID;
            var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_INFO%>', Request, true);
            if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                var arr = Response.ResponseObject;
                $("#description").val(arr['Description']);
                //                var appliedto = arr['LeaveAppliedTo'];
                //                jQuery('#leavedesignation').jqGrid('setSelection', appliedto);
                //                var adminReporting=arr['ParentDesignationID'];
                //                jQuery('#AdminRepoDesign').jqGrid('setSelection', adminReporting);
                var roleid = arr['RoleID'];
                jQuery('#role').jqGrid('setSelection', roleid);
                if (arr['IsActive'] == 'False') { $("#isactive").attr('checked', false); }
                else { $("#isactive").attr('checked', true); }
            }
        }
        function BindGrid(pageNumber) {            
            var Request = new Object();
            if ($("#activedata").is(':checked')) {
                var Response = SendApplicationRequest("<%=HRAppCommands.DESIGNATION_DETAILS%>", '', true);
                activeStatus = true;
            }
            else {
                var Response = SendApplicationRequest("<%=HRAppCommands.INACTIVE_DESIGNATION%>", '', true);
                activeStatus = false;
            }
            if (Response.ResponseObject.datastr == null)
                jQuery("#list").jqGrid('clearGridData');
            else {
                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                //jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
            }
            GridActiveButton();
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
              
        function clearLabels() {
            $("#designation").val("");
            $("#description").val("");
            //  $("#leavedesignation").val("");
            $("#role").val("");
            $("#isactive").attr('checked', false);
            // jQuery('#leavedesignation').jqGrid('resetSelection');
            jQuery('#role').jqGrid('resetSelection');
        }

        function LoadPermits() {
            var Response = LoadPermissions($('#hdnmodule').val(), $('#hdnEmployeeID').val());
            if (Response != null) {
                $('#hdnApplyPermit').val(Response['Apply']);
                $('#hdnApprovlPermit').val(Response['Approvals']);
                $('#hdnViewPermit').val(Response['ViewMode']);
            }
        }
//        function onGetPermissionDisplay() {
//            document.getElementById("add").style.display = "none";
//            document.getElementById("edit").style.display = "none";
//            if (document.getElementById("hdnApplyPermit").value == "true") {
//                document.getElementById("add").style.display = "";
//                document.getElementById("edit").style.display = "";
//            }
        //        }
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
     

        function LoadRoles() {
            var myGrid = $('#role');
            var Response = SendApplicationRequest('<%=HRAppCommands.ROLE_MASTER_DETAILS%>', '');
            Response.ResponseObject.colModel = [
   		            { name: 'roleid', index: 'roleid', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'role', index: 'role', width: 100, editable: true },
   		            { name: 'description', index: 'description', width: 100, hidden: true, editable: true },
   		            { name: 'isactive', index: 'isactive', width: 100, hidden: true, editable: true }
   	            ]

            Response.ResponseObject.rolepager = "";
            Response.ResponseObject.height = "200";
            Response.ResponseObject.width = "300";
            Response.ResponseObject.rowNum = "1000";
            myGrid.jqGrid(Response.ResponseObject);
            jQuery("#role").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        }

        function LoadLeaveDesignation() {

            var myGrid = $('#leavedesignation');
            var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#list").jqGrid('getRowData', id);
            var Request = new Object();
            var ID = ret.id;
            Request.DesignationID = ID;

            var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_HIRE_INFO%>', Request, true);
            $("#leavedesignation").jqGrid({
                datatype: 'jsonstring',
                datastr: Response.ResponseObject.datastr,
                colNames: ["ID", " "],
                colModel: [{
                    name: 'id',
                    index: 'id',
                    width: 1,
                    hidden: true,
                    key: true
                },
                    {
                        name: 'desc',
                        index: 'desc',
                        hidden: false,
                        sortable: true
                    }
                ],
                treeGridModel: 'adjacency',
                height: '200',
                width: '300',
                treeGrid: true,
                ExpandColumn: 'desc',
                ExpandColClick: true,
                caption: "Functional Reporting Designations",
                onSelectRow: function(rowid) {
                    var ret = jQuery("#leavedesignation").jqGrid('getRowData', rowid);
                    if (ret.id == '0') {
                        if (mode != "edit")
                            alert("Designation root node cannot be selected,Please select designation node. ");
                        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '');
                        jQuery("#leavedesignation").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
                        jQuery("#leavedesignation").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");
                    }
                }
            });

        }

        function LoadAdminRepoDesign() {
            var myGrid = $('#AdminRepoDesign');
            var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#list").jqGrid('getRowData', id);
            var Request = new Object();
            var ID = ret.id;
            Request.DesignationID = ID;

            var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_HIRE_INFO%>', Request, true);
            $("#AdminRepoDesign").jqGrid({
                datatype: 'jsonstring',
                datastr: Response.ResponseObject.datastr,
                colNames: ["ID", " "],
                colModel: [{
                    name: 'id',
                    index: 'id',
                    width: 1,
                    hidden: true,
                    key: true
                },
                    {
                        name: 'desc',
                        index: 'desc',
                        hidden: false,
                        sortable: true
                    }
                ],
                treeGridModel: 'adjacency',
                height: '200',
                width: '300',
                treeGrid: true,
                ExpandColumn: 'desc',
                ExpandColClick: true,
                caption: "Administrative Reporting Designations",
                onSelectRow: function(rowid) {
                    var ret = jQuery("#leavedesignation").jqGrid('getRowData', rowid);
                    if (ret.id == '0') {
                        if (mode != "edit")
                            alert("Designation root node cannot be selected,Please select designation node. ");
                        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '');
                        jQuery("#AdminRepoDesign").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
                        jQuery("#AdminRepoDesign").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");
                    }
                }
            });

        }
        function LoadDesignation() {
            var Response = SendApplicationRequest("<%=HRAppCommands.DESIGNATIONCOMBO_DETAILS%>", "");
            var optn = document.createElement("OPTION");
            optn.text = "Choose Reporting Designation";
            optn.value = "";
            document.getElementById('reptdesignation').options.add(optn);
            if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                var arr = Response.ResponseObject;

                for (var i = 0; i < arr.length; ++i) {
                    var optn = document.createElement("OPTION");
                    optn.text = arr[i]['DesignationName'];
                    optn.value = arr[i]['ID'];
                    document.getElementById('reptdesignation').options.add(optn);
                }
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