<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="AltioStarHR.Masters.Department" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Department</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input[type=text] 
        {
            margin-bottom: 5px;
            width: 100%;
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
            Department</div>
        <div class="dvGrid">
            <table id="list" class="scroll">
            </table>
        </div>
    </div>
    <div id="divDepartment" class="dialog" title="Department" style="display: none;">
        <form id="signupForm" method="get" action="">
        <fieldset>
            <table class="teble_bg">
                <tbody>
                    <tr>
                        <td class="label" width="90" height="40">
                            <label id="ldepartment" for="department">
                                Department</label>
                        </td>
                        <td class="field" width="90" height="40">
                            <input id="department" name="department" type="text" value="" maxlength="100" />
                        </td>
                        <td id="sdepartment" width="90" height="40">
                        </td>
                    </tr>
                    <tr id="trSelectHOD" style="display: none">
                        <td class="label" width="90" height="40">
                            <label id="lHOD" for="HOD">
                                Head Of Department</label>
                        </td>
                        <td class="field" width="90" height="40">
                            <select id="HOD" name="HOD" runat="server">
                            </select>
                        </td>
                        <td id="sHOD" width="90" height="40">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lishr" >
                                Is HR
                            </label>
                        </td>
                        <td class="field">
                            <input id="ishr" tabindex="3" type="checkbox" />
                        </td>
                        <td id="sishr">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lisFinance" >
                                Is Finance
                            </label>
                        </td>
                        <td class="field">
                            <input id="isFinance" tabindex="3" type="checkbox" />
                        </td>
                        <td id="sisFinance">
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
        <input type="hidden" id="hdnApplyPermit" runat="server" />
        <input type="hidden" id="hdnViewPermit" runat="server" />
        </form>
    </div>
</body>

<script type="text/javascript" src="../Resources/js/jquery-1.6.2.min.js"></script>

<script src="../Resources/js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

<script type="text/javascript" src="../Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="../Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="../Resources/js/Webutility.js"></script>

<script type="text/javascript" src="../Resources/js/toolbar.js"></script>

<script type="text/javascript" src="../Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="../Resources/js/jquery.ui.widget.js"></script>

<script type="text/javascript" src="../Resources/js/jquery.validate.js"></script>

<script src="../Resources/js/jquery.ui.button.js" type="text/javascript"></script>

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
    jQuery(document).ready(function() {
        //LoadPermits();

        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        $('#Cancel').click(function() {
         onCancel();    
        });

        $('#ishr').click(function() {
            CheckHRFinanceValidation();
        });
        $('#isFinance').click(function() {
            CheckHRFinanceValidation();
        });

        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=HRAppCommands.DEPARTMENT_DETAILS%>', '');
        $("#list").jqGrid({
            datatype: 'jsonstring',
            datastr: Response.ResponseObject.datastr,
            colNames: ["ID", " "],
            colModel: [{
                name: 'id',
                index: 'id',
                width: 1,
                hidden: true,
                key: true
            }, {
                name: 'desc',
                index: 'desc',
                hidden: false,
                sortable: true
}],
                treeGridModel: 'adjacency',
                height: '375',
                width: '800',
                treeGrid: true,
                ExpandColumn: 'desc',
                toolbar: [true, "top"],
                caption: "DepartmentDetails",
                headertitles: true,
                title: true
            });

            jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
            $("#t_list").append("<input type='button' id='add' value='Add'  style='height:24px;font-size:-3'/> ");
            $("#t_list").append("<input type='button' id='edit' value='Edit' style='height:24px;font-size:-3'/> ");
            $("#t_list").append("<input type='button' id='reset' value='Refresh' style='height:24px;font-size:-3'/> ");

            if ($('#hdnEmployeeID').val() != "1") {
                onGetPermissionDisplay();
            }
            $("input", "#t_list").click(function(id) {
                if (id.currentTarget.id == "add") {
                    document.getElementById("trSelectHOD").style.display = "none";
                    validator.resetForm();
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    if (id) {
                        mode = "add";
                        //clearLabels();
                        document.getElementById("divDepartment").style.display = "";
                        $('#divDepartment').dialog({
                            height: 220,
                            width: 550,
                            modal: true
                        })
                        $("input[type='text']:first", document.forms[0]).focus();
                    }
                    else { alert("Please select Department"); }
                }
                else if (id.currentTarget.id == "edit") {
                    validator.resetForm();
                    document.getElementById("trSelectHOD").style.display = "";
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    if (id) {
                      //  LoadEmpForHOD(id);
                        var ret = jQuery("#list").jqGrid('getRowData', id);
                        var ID = ret.id;
                        var NodeName = ret.desc;
                        if (ID != 0) {
                            mode = "edit";
                            //clearLabels();
                            document.getElementById("divDepartment").style.display = "";
                            $('#divDepartment').dialog({
                                height: 270,
                                width: 550,
                                modal: true
                            })
                            fillData();
                           // $("input[type='text']:first", document.forms[0]).focus();
                        }
                        else { alert(NodeName + " cannot be edited"); }
                    }
                    else { alert("Select Department"); }
                }
                else if (id.currentTarget.id == "reset") {
                    var Response = SendApplicationRequest('<%=HRAppCommands.DEPARTMENT_DETAILS%>', '');
                    jQuery("#list").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
                    jQuery("#list").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");
                    jQuery("#list").jqGrid('resetSelection');
                }
            });

            var validator = $("#signupForm").validate({
                rules: {
                    department: {
                        required: true,
                        alphaNumerix: true
                    }
                },
                messages: {
                    department: {
                        required: "Enter Department",
                        alphaNumerix: "Invalid Department"
                    }
                },
                errorPlacement: function(error, element) {
                    error.appendTo(element.parent().next());
                },

                submitHandler: function() {
                    var Request = new Object();
                    var ID = "";
                    var ParentID = "";
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    if (mode == "edit") {
                        ID = ret.id;
                        ParentID = parseInt(ret.id) - 1;
                    }
                    else {
                        ID = "0";
                        ParentID = parseInt(ret.id) - 1;
                    }
                    Request.UpdateBy = $("#hdnEmployeeID").val();
                    Request.DepartmentID = ID;
                    Request.Department = $("#department").val();
                    Request.ParentID = ParentID;
                    if ($("#ishr").is(':checked')) { Request.IsHR = true; }
                    else { Request.IsHR = false; }
                    if ($("#isFinance").is(':checked')) { Request.IsFinance = true; }
                    else { Request.IsFinance = false; }

                    var HOD = 0;
                    if ($("#HOD").val() != "")
                        HOD = $("#HOD").val();
                    Request.HOD = HOD;
                    var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_DEPARTMENT%>', Request, true);
                    if (mode == "edit") {
                        if (confirm('Do you want to Update the Changes made?') == false)
                            return false;
                    }
                    alert(Response.Message);
                    if (Response.ResponseCommand == 'SUCCESS') {
                        mode = "SUCCESS";
                        var Response = SendApplicationRequest('<%=HRAppCommands.DEPARTMENT_DETAILS%>', '');
                        jQuery("#list").setGridParam({ 'datastr': '' }).trigger("reloadGrid");
                        jQuery("#list").setGridParam({ 'datastr': Response.ResponseObject.datastr }).trigger("reloadGrid");
                        jQuery("#list").setGridParam({ 'selrow': '' });
                        //onCancel();
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
            $("#divDepartment").dialog('close');
        }
        
        function CheckHRFinanceValidation()
        {
        if( $("#isFinance").is(':checked') && $("#ishr").is(':checked'))
           {
           alert("Finance and Hr department should be different");
            $("#isFinance").attr('checked',false);
            $("#ishr").attr('checked',false);
           }
        }

        function LoadEmpForHOD(DeptId) {
            var optn = document.getElementById('HOD');
            optn.options.length = 0;
            var optn = document.createElement("OPTION");
            optn.text = "Choose Head OF Department";
            optn.value = "";
            document.getElementById('HOD').options.add(optn);
            if (DeptId == 0)
                return;
            var Request = new Object();
            Request.ID = DeptId - 1;

            alert(Response.Message);
            if (Response.ResponseCommand == 'SUCCESS') {
                mode = "SUCCESS";
                var Response = SendApplicationRequest('<%=HRAppCommands.DEPARTMENT_DETAILS%>', '');
                var Response = SendApplicationRequest('<%=EmployeeAppCommands.EMPDEPTWISE_DETAILS%>', '');

                if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                    var arr = Response.ResponseObject;
                    for (var i = 0; i < arr.length; ++i) {
                        var optn = document.createElement("OPTION");
                        optn.text = arr[i]['CandidateName'];
                        optn.value = arr[i]['ID'];
                        document.getElementById('HOD').options.add(optn);
                    }
                }
            }

            function LoadPermissions() {
                var Request = new Object();
                Request.FunctionName = $('#hdnmodule').val();
                Request.EmployeeID = $('#hdnEmployeeID').val();
                var Response = SendApplicationRequest("<%=HRAppCommands.GET_PERMISSION_ASSIGNED%>", Request, true);
                if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                    var arr = Response.ResponseObject;
                    if (arr != null) {
                        $('#hdnApplyPermit').val(arr['Apply']);
                        $('#hdnViewPermit').val(arr['ViewMode']);
                    }
                }
            }

//            function onCancel() {
//                if (mode != "SUCCESS") {
//                    if (confirm('Do you want to cancel?') == false) return ;
//                }
//                $("#divDepartment").dialog('close');
//            }

            function fillData() {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                $("#department").val(ret.desc);
                var Request = new Object();
                Request.ID = id - 1;

                var Response = SendApplicationRequest('<%=HRAppCommands.DEPARTMENT_HOD_DETAILS%>', Request, true);
                if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                    $("#HOD").val(Response.ResponseObject.HOD);
                    if (Response.ResponseObject.IsHR) { $("#ishr").attr('checked', true); }
                    else { $("#ishr").attr('checked', false); }
                    if (Response.ResponseObject.IsFinance) { $("#isFinance").attr('checked', true); }
                    else { $("#isFinance").attr('checked', false); }
                }
            }

            function clearLabels() {
                $("#department").val("");
                $("#HOD").val("");
                $("#ishr").attr('checked', false);
                $("#isFinance").attr('checked', false);
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

                if (document.getElementById("hdnApplyPermit").value == "true") {
                    document.getElementById("add").style.display = "";
                    document.getElementById("edit").style.display = "";
                }
            }
        }
        
</script>

<script type="text/javascript">
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('#t_list').css('background', 'none');
        $('#t_list').css('background-color', '#fff');
//       $('#t_list').css('padding', '10px 0px');
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
