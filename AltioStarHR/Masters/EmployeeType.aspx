<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeType.aspx.cs" Inherits="AltioStarHR.Masters.EmployeeType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>EmployeeType</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
    <div>
        <div class="header_title2">
            Employee Type</div>
        <div class="dvGrid">
            <table id="list">
            </table>
            <div id="pager">
            </div>
        </div>
    </div>
    <div id="divEmployeeType" class="dialog" title="Employee Type" style="display: none;">
        <form id="signupForm" method="get" action="">
        <fieldset>
            <table class="teble_bg" style="width:500px">
                <tbody>
                     <tr>
                        <td class="label" width="200" height="40">
                            <label id="lname" for="name">
                                Employee Type</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="name" name="name" type="text" style="width:200px" value="" maxlength="100" />
                        </td>
                        <td id="sname" width="200" height="40">
                        </td>
                    </tr>
                    
                    <tr>
                       <%-- <td class="label" width="200" height="40">
                            <label id="lmindurationmonth" for="mindurationmonth">
                                Min Duration Month</label>
                        </td>--%>
                        <%--<td class="field" width="200" height="40">
                            <input id="mindurationmonth" name="mindurationmonth" style="width:200px" type="text" value="" maxlength="100" />
                        </td>
                        <td id="smindurationmonth" width="200" height="40">
                        </td>--%>
                    </tr>
                    <tr>
                        <%--<td class="label">
                            <label id="lIsService" for="IsService">
                                Is Service</label>
                        </td>
                        <td class="field">
                            <input id="IsService" type="checkbox" />
                        </td>
                        <td id="sIsService">
                        </td>--%>
                    </tr>
                    <tr>
                        <%--<td class="label">
                            <label id="lispermanent" for="ispermanent">
                                Is Permanent</label>
                        </td>
                        <td class="field">
                            <input id="ispermanent" type="checkbox" />
                        </td>
                        <td class="status" id="sispermanent">
                        </td>--%>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lisactive">
                                Active</label>
                        </td>
                        <td class="field">
                            <input id="isactive" type="checkbox" />
                        </td>
                        <td class="status" id="sisactive">
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
        <input type="hidden" id='hdnEmployeeID' runat="server" />
        <input type="hidden" id='hdnmodule' runat="server" />
        <input type="hidden" id='hdnApprovlPermit' runat="server" />
        <input type="hidden" id="hdnApplyPermit" runat="server" />
        <input type="hidden" id="hdnViewPermit" runat="server" />
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

<script type="text/javascript">
    // Code to Prevent the BackSpace key from Working as "Go To Back Page."
    $(document).keydown(function(e) {

        var nodeName = e.target.nodeName.toLowerCase();
        if (e.which == 8) {
            if ((nodeName == 'input' && e.target.type == 'text') || nodeName == 'textarea') {
                /* do nothing */
            }
            else { e.preventDefault(); }
        }
    });


    var mode = "";
    var activeStatus = true;

    jQuery(document).ready(function() {
        //        LoadPermits();

        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");


        $('#Cancel').click(function() {
            onCancel();
        });

        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=HRAppCommands.EMPLOYEETYPE_DETAILS%>', '');
        Response.ResponseObject.colModel = [
   		            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'name', index: 'name', width: 100, editable: true },
   		            { name: 'mindurationmonth', index: 'mindurationmonth', width: 100, hidden: true },
   		            { name: 'isservice', index: 'isservice', width: 100, hidden: true },
   		            { name: 'isactive', index: 'isactive', width: 100, editable: true, hidden: true },
   		            { name: 'ispermanent', index: 'ispermanent', width: 100, editable: true, hidden: true }
   	            ]

        myGrid.jqGrid(Response.ResponseObject);

        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");

        $("#t_list").append("<input type='button' id='add' value='Add'  style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<input type='button' id='edit' value='Edit' style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<input type='button' id='activate' value='Activate' style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<input type='button' id='deactivate' value='Deactivate' style='height:24px;font-size:-3'/> ");
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
                document.getElementById("divEmployeeType").style.display = "";
                $('#divEmployeeType').dialog({
                    height: 275,
                    width: 540,
                    modal: true
                })
                $("input[type='text']:first", document.forms[0]).focus();
            }
            else if (id.currentTarget.id == "edit") {
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divEmployeeType").style.display = "";
                    $('#divEmployeeType').dialog({
                        height: 275,
                        width: 540,
                        modal: true
                    })
                    fillData();
                    $("input[type='text']:first", document.forms[0]).focus();
                }
                else { alert("Please select EmployeeType"); }
            }
            else if (id.currentTarget.id == "activedata") {
                mode = "activedata";
                BindGrid(1);
            }
            else if (id.currentTarget.id == "delete") {
                mode = "delete";
                var gr = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (gr != null) jQuery("#list").jqGrid('delGridRow', gr, { reloadAfterSubmit: false });
                else alert("Please Select Row to delete!");
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
                        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_EMPLOYEETYPE%>", Request, true);
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=HRAppCommands.EMPLOYEETYPE_DETAILS%>', '', true);
                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setCaption', "EmployeeTypeDetails").trigger('reloadGrid');
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else {
                        alert("Selected EmployeeType is already deactivated!");
                    }
                }
                else {
                    alert("Please Select EmployeeType to deactivate!");
                }

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
                        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_EMPLOYEETYPE%>", Request, true);
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=HRAppCommands.INACTIVE_EMPLOYEETYPE%>', '', true);
                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setCaption', "EmployeeTypeDetails").trigger('reloadGrid');
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }

                    }
                    else {
                        alert("Selected EmployeeType is already activated!");
                    }
                }
                else {
                    alert("Please Select EmployeeType to activate!");
                }
            }

        });
        GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {

                name: {
                    required: true,
                    alphaNumerix: true
                },
                mindurationmonth: {
                    required: true,
                    number: true,
                    min: 0
                }

            },
            messages: {

                name: {
                    required: "Enter Name",
                    alphaNumerix: "Invalid Name"
                },

                mindurationmonth: {
                    required: "Enter Min Duration",
                    number: "Only Number Allowded",
                    min: jQuery.format("Enter at least {0} characters")
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function() {

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
                Request.Name = $("#name").val();
//              Request.MinDurationMonth = $("#mindurationmonth").val();
                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }
//                if ($("#IsService").is(':checked')) { Request.IsService = true; }
//                else { Request.IsService = false; }
//                if ($("#ispermanent").is(':checked')) { Request.IsPermanent = true; }
//                else { Request.IsPermanent = false; }
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_EMPLOYEETYPE%>', Request, true);
                if (mode == "edit") {
                    if (confirm('Do you want to Update the Changes made?') == false) return false;
                }
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
    function BindGrid(pageNumber) {
        var Request = new Object();
        if ($("#activedata").is(':checked')) {
            var Response = SendApplicationRequest("<%=HRAppCommands.EMPLOYEETYPE_DETAILS%>", '', true);
            activeStatus = true;
        }
        else {
            var Response = SendApplicationRequest("<%=HRAppCommands.INACTIVE_EMPLOYEETYPE%>", '', true);
            activeStatus = false;
        }
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setCaption', "EmployeeTypeDetails").trigger('reloadGrid');
            jQuery("#list").jqGrid('setGridParam', { page: pageNumber }).trigger('reloadGrid');
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

    function onCancel() {

        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        $("#divEmployeeType").dialog('close');
    }

    function fillData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#name").val(ret.name);
//        $("#mindurationmonth").val(ret.mindurationmonth);
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }
//        if (ret.isservice == 'False') { $("#IsService").attr('checked', false); }
//        else { $("#IsService").attr('checked', true); }
//        if (ret.ispermanent == 'False') { $("#ispermanent").attr('checked', false); }
//        else { $("#ispermanent").attr('checked', true); }
    }

    function clearLabels() {
        $("#name").val("");
        $("#mindurationmonth").val("");
        $("#isactive").attr('checked', false);
        $("#IsService").attr('checked', false);
        $("#ispermanent").attr('checked', false);
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
            document.getElementById("edit").style.display = "";
        }
        if (document.getElementById("hdnApprovlPermit").value == "true") {
            document.getElementById("activate").style.display = "";
            document.getElementById("deactivate").style.display = "";
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
