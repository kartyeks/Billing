<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalaryAllowances.aspx.cs"
    Inherits="AltioStarHR.Payroll.SalaryAllowances" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Salary Allowances</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
        
    </style>
</head>
<body>
    <div>
        <%--<div class="header_title2">--%>
<%--        <div style="background-color:#00daf5;width:885px;margin-left:2%;height:25px;padding-left:2%;font-family:Calibri;font-weight:bold">
            Salary Allowances</div>--%>
            <div style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png"style="width:96%;margin-left:2%;height:53px;margin-top:0%"/>
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
  <strong class="family1 imageheadercolor">Salary Allowances</strong>
    </div>
</div>
    
        <div style="margin-left:2%;" id="box">
            <table id="list" class="scroll">
            </table>
            <div id="pager">
            </div>
        </div>
    </div>
    <div id="dvSAllow" class="dialog" title="Salary Heads " style="display: none;">
        <form id="signupForm" method="get" action="">
        <fieldset>
            <table class="teble_bg" style="width: 600px">
                <tbody>
                    <tr>
                        <td class="label" width="200" height="40">
                            <label id="lallowancename" for="allowancename" class="family">
                                Allowance Name</label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="allowancename" name="allowancename" style="width: 200px" type="text" value=""
                                maxlength="100" />
                        </td>
                        <td id="sallowancename" width="200" height="40">
                        </td>
                    </tr>
                    <tr>
                        <td class="label" width="200" height="40">
                            <label id="Label7" for="allowancecode" class="family">
                                Allowance Code</label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="allowancecode" name="allowancecode" style="width: 200px" type="text" value=""
                                maxlength="100" />
                        </td>
                        <td id="Td4" width="200" height="40">
                        </td>
                    </tr>
                    <tr>
                        <td class="label" width="200" height="40">
                            <label id="lallowanceperiod" for="allowanceperiod" class="family">
                                 Period</label>
                        </td>
                        <td class="field" width="200" height="40">
                            <select id="allowanceperiod" style="width: 200px" class="family">
                                <option value="<%=PayrollAppCommands.ALLOWANCE_MONTHLY %>">Monthly</option>
                                <option value="<%=PayrollAppCommands.ALLOWANCE_YEARLY %>">Yearly</option>
                            </select>
                        </td>
                        <td id="sallowanceperiod" width="200" height="40">
                        </td>
                    </tr>
                     <tr>
                        <td class="label" width="200" height="40">
                            <label id="ldisplayorder" for="displayorder" class="family">
                                Display Order</label>
                        </td>
                        <td class="field" width="200" height="40">
                            <select id="displayorder" runat="server" name="displayorder" style="width: 200px" class="family">
                            </select>
                        </td>
                        <td id="sdisplayorder" width="200" height="40" class="family">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="Label4" for="isallowance" class="family">
                                Is Allowance</label>
                        </td>
                        <td class="field">
                            <input id="isallowance" type="checkbox" class="family"/>
                            <span id="sisallowance" style="display: none;" class="family">No</span>
                        </td>
                        <td class="status" id="Td3">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="Label1" for="ispercentage" class="family">
                                Is Percentage</label>
                        </td>
                        <td class="field">
                            <input id="ispercentage" type="checkbox" />
                            <span id="spnperc" style="display: none;">No</span>
                        </td>
                        <td class="status" id="Td1">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="Label2" for="istaxexempted" class="family">
                                Is TaxExempted</label>
                        </td>
                        <td class="field">
                            <input id="istaxexempted" type="checkbox" />
                            <span id="spntax" style="display: none;" class="family">No</span>
                        </td>
                        <td class="status" id="Td2">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="Label3" for="isoptional" class="family">
                                Is Optional</label>
                        </td>
                        <td class="field">
                            <input id="isoptional" type="checkbox" />
                            <span id="sopn" style="display: none;" class="family">No</span>
                        </td>
                        <td class="status" id="sisoptional">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="Label5" for="isonemonthbasic" class="family">
                                Is One Month Basic</label>
                        </td>
                        <td class="field">
                            <input id="isonemonthbasic" type="checkbox" />
                            <span id="SOneMonth" style="display: none;">No</span>
                        </td>
                        <td class="status" id="sisonemonthbasic">
                        </td>
                    </tr>
                    <tr>
                        <td class="label" width="200" height="40">
                            <label id="Label6" for="value" class="family">
                                Value</label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="value" name="value" style="width: 200px" type="text" value=""
                                maxlength="100" />
                        </td>
                        <td id="svalue" width="200" height="40">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lisactive" for="isactive" class="family">
                                Active</label>
                        </td>
                        <td class="field">
                            <input id="isactive" type="checkbox" />
                            <span id="spnactive" style="display: none;" class="family">No</span>
                        </td>
                        <td class="status" id="sisactive">
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table>
                <tr align="center">
                    <td class="field">
                        <input id="signupsubmit" name="Submit" type="submit" value="Save" class="family"/>
                    </td>
                    <td class="field">
                        <input id="Cancel" name="Cancel" type="button" value="Cancel" class="family"/>
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

<script type="text/javascript" src="Resources/js/jquery.ui.button.js"></script>

<script type="text/javascript">
    //    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "902px" });
    var mode = "";
    var activeStatus = true;
    jQuery(document).ready(function() {
        LoadPermits();

        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z0-9][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        $('#Cancel').click(function() {
            onCancel();
        });
        
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=PayrollAppCommands.SALARY_ALLOWANCES%>', '', true);
        Response.ResponseObject.colModel = [
   		            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'allowancename', index: 'allowancename', width: 100, editable: true },
   		            { name: 'allowancecode', index: 'allowancecode', width: 100, editable: true },
   		            { name: 'allowanceperiod', index: 'allowanceperiod', width: 100, editable: true },
   		            { name: 'ispercentage', index: 'ispercentage', width: 100, editable: true },
   		            { name: 'isactive', index: 'isactive', width: 100, editable: true, hidden: true },
   		            { name: 'istaxexempted', index: 'istaxexempted', width: 100, hidden: true, editable: true },
   		            { name: 'isoptional', index: 'isoptional', width: 100, hidden: true, editable: true },
   		            { name: 'isallowance', index: 'isallowance', width: 100, editable: true },
   		            { name: 'displayorder', index: 'displayorder', width: 100, hidden: true, editable: true }
   	            ]
        Response.ResponseObject.caption = "Salary Allowances";
        myGrid.jqGrid(Response.ResponseObject);

        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });
        $("#list").closest(".ui-jqgrid-bdiv").height("auto");
        $("#t_list").closest(".ui-userdata").hide();
        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");

        //        $("#t_list").append("<input type='button' id='add' value='Add'  style='height:24px;font-size:-3'/> ");
        //        $("#t_list").append("<input type='button' id='edit' value='Edit' style='height:24px;font-size:-3'/> ");
        //        $("#t_list").append("<input type='button' id='activate' value='Activate' style='height:24px;font-size:-3'/> ");
        //        $("#t_list").append("<input type='button' id='deactivate' value='Deactivate' style='height:24px;font-size:-3'/> ");
        //        $("#t_list").append("Active <input type='checkbox' id='activedata' value='activedata' checked /> ");
        //        
        //        if ($('#hdnEmployeeID').val() != "1") {
        //            onGetPermissionDisplay();
        //        }
        //        
        //        $("input", "#t_list").click(function(id) {
        //            if (id.currentTarget.id == "add") {
        //                validator.resetForm();
        //                mode = "add";
        //                clearLabels();
        //                $("#isactive").attr('checked', true);
        //                document.getElementById("dvSAllow").style.display = "";
        //                $('#dvSAllow').dialog({
        //                    height: 300,
        //                    width: 630,
        //                    modal: true
        //                })
        //                $("input[type='text']:first", document.forms[0]).focus();
        //            }
        //            else if (id.currentTarget.id == "edit") {
        //                validator.resetForm();
        //                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        //                if (id) {
        //                    mode = "edit";
        //                    clearLabels();
        //                    document.getElementById("dvSAllow").style.display = "";
        //                    $('#dvSAllow').dialog({
        //                        height: 300,
        //                        width: 630,
        //                        modal: true
        //                    })
        //                    fillData();
        //                    $("input[type='text']:first", document.forms[0]).focus();
        //                }
        //                else { alert("Please select row"); }
        //            }
        //            else if (id.currentTarget.id == "activedata") {
        //                mode = "activedata";
        //                BindGrid(1);
        //            }
        //            else if (id.currentTarget.id == "delete") {
        //                mode = "delete";
        //                var gr = jQuery("#list").jqGrid('getGridParam', 'selrow');
        //                if (gr != null) jQuery("#list").jqGrid('delGridRow', gr, { reloadAfterSubmit: false });
        //                else alert("Please Select Salary Head to delete!");
        //            }
        //            else if (id.currentTarget.id == "deactivate") {
        //                mode = "deactivate";
        //                var Request = new Object();
        //                var ID = "";
        //                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        //                var ret = jQuery("#list").jqGrid('getRowData', id);
        //                if (id) {
        //                    if (ret.isactive == 'True') {
        //                        if (confirm('Do you want to deactivate?') == false) return;
        //                        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        //                        ID = ret.id;
        //                        Request.ID = ID;
        //                        Request.ChangedBy = $("#hdnEmployeeID").val();
        //                        var Response = SendApplicationRequest("<%=PayrollAppCommands.DEACTIVATE_SALARYALLOWANCE%>", Request, true);
        //                        alert(Response.Message);
        //                        if (Response.ResponseCommand == 'SUCCESS') {
        //                            mode = "";
        //                            var Response = SendApplicationRequest('<%=PayrollAppCommands.SALARY_ALLOWANCES%>', '', true);
        //                            if (Response.ResponseObject.datastr == null)
        //                                jQuery("#list").jqGrid('clearGridData');
        //                            else {
        //                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
        //                                jQuery("#list").jqGrid('setCaption', "Salary Heads").trigger('reloadGrid');
        //                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        //                            }
        //                        }
        //                    }
        //                    else alert("Selected Salary Head is already deactivated");                    
        //                }
        //                else alert("Please Select Salary Head to deactivate");                
        //            }
        //            else if (id.currentTarget.id == "activate") {
        //                mode = "activate";
        //                var Request = new Object();
        //                var ID = "";
        //                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        //                var ret = jQuery("#list").jqGrid('getRowData', id);
        //                if (id) {
        //                    if (ret.isactive == 'False') {
        //                        if (confirm('Do you want to activate?') == false) return;
        //                        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        //                        ID = ret.id;
        //                        Request.ID = ID;
        //                        Request.ChangedBy = $("#hdnEmployeeID").val();
        //                        var Response = SendApplicationRequest("<%=PayrollAppCommands.ACTIVATE_SALARYALLOWANCE%>", Request, true);
        //                        alert(Response.Message);
        //                        if (Response.ResponseCommand == 'SUCCESS') {
        //                            mode = "";
        //                            var Response = SendApplicationRequest('<%=PayrollAppCommands.INACTIVE_SALARYALLOWANCES%>', '', true);
        //                            if (Response.ResponseObject.datastr == null)
        //                                jQuery("#list").jqGrid('clearGridData');
        //                            else {
        //                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
        //                                jQuery("#list").jqGrid('setCaption', "Salary Head").trigger('reloadGrid');
        //                            }
        //                        }
        //                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        //                    }
        //                    else alert("Selected Salary Head is already activated");                    
        //                }
        //                else alert("Please Select Salary Head to activate");                
        //            }
        //        });
        //        
        //        GridActiveButton();
        //        var validator = $("#signupForm").validate({
        //            rules: {
        //                allowancename: {
        //                    required: true
        //                },
        //                allowancecode: {
        //                    required: true
        //                }
        //            },
        //            messages: {
        //                allowancename: {
        //                    required: "Enter Allowance Name"
        //                },
        //                allowancecode: {
        //                    required: "Enter Allowance Code"
        //                }
        //            },
        //            errorPlacement: function(error, element) {
        //                error.appendTo(element.parent().next());
        //            },
        //            
        //            submitHandler: function() {
        //                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        //                var Request = new Object();
        //                var ID = "";

        //                if (mode == "edit") {
        //                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        //                    var ret = jQuery("#list").jqGrid('getRowData', id);
        //                    ID = ret.id;
        //                    Request.AllowanceCode=ret.allowancecode;
        //                }
        //                else {
        //                    ID = "0";
        //                }
        //                Request.UpdateBy = $("#hdnEmployeeID").val();
        //                Request.ID = ID;
        //                Request.AllowanceName = $("#allowancename").val();
        //                Request.AllowanceCode = $("#allowancecode").val();
        //                Request.AllowancePeriod = $("#allowanceperiod").val();
        //                Request.IsPercentage = $("#ispercentage").is(':checked');
        //                Request.IsTaxExempted= $("#istaxexempted").is(':checked');
        //                Request.IsActive = $("#isactive").is(':checked');
        //                Request.IsOptional = $("#isoptional").is(':checked');
        //                Request.IsAllowance = $("#isallowance").is(':checked');
        //                Request.DisplayOrder = $("#displayorder").val();
        //                Request.IsOneMonthBasic = $("#isonemonthbasic").is(':checked');
        //                Request.Value = $("#value").val();


        //                var Response = SendApplicationRequest('<%=PayrollAppCommands.UPDATE_SALARYALLOWANCE%>', Request, true);                
        //                if(mode == "edit")
        //                {
        //                  if(confirm('Do you want to Update the Changes made?') == false)
        //                    return false;
        //                }                
        //                alert(Response.Message);
        //                if (Response.ResponseCommand == 'SUCCESS') {
        //                    mode = "SUCCESS";
        //                    BindGrid(currPage);
        //                    clearLabels();
        //                    onCancel();
        //                }
        //            },
        //            success: function(label) {
        //                label.html("&nbsp;").addClass("checked");
        //            }
        //        });
    });
    
    function BindGrid(pageNumber) {
        var Request = new Object();
        if ($("#activedata").is(':checked')) {
             var Response = SendApplicationRequest('<%=PayrollAppCommands.SALARY_ALLOWANCES%>', '', true);
            activeStatus = true;
        }
        else {
            var Response = SendApplicationRequest('<%=PayrollAppCommands.INACTIVE_SALARYALLOWANCES%>', '', true);
            activeStatus = false;
        }
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setCaption', "Salary Allowances").trigger('reloadGrid');
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
        $("#dvSAllow").dialog('close');
    }

    function fillData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#allowancename").val(ret.allowancename);
        $("#allowancecode").val(ret.allowancecode);
        $("#allowanceperiod").val(ret.allowanceperiod);
        $("#isallowance").attr('checked', (ret.isallowance == 'True'));
        $("#ispercentage").attr('checked', (ret.ispercentage == 'True'));
        $("#istaxexempted").attr('checked', (ret.istaxexempted == 'True'));
        $("#isactive").attr('checked', (ret.isactive == 'True'));
        $("#isoptional").attr('checked', (ret.isoptional == 'True'));
        $("#displayorder").val(ret.displayorder);
        
    }

    function clearLabels() {
        $("#allowancename").val("");
        $("#allowancecode").val("");
        $("#isallowance").attr('checked', false);
        $("#ispercentage").attr('checked', false);
        $("#istaxexempted").attr('checked', false);
        $("#isactive").attr('checked', false);
        $("#isoptional").attr('checked', false);
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
    
    function OnCheck(chk) {
        var lbl = 'No';
        if (chk.checked) lbl = 'Yes';
        if (chk.id == "ispercentage") {
            spnperc.innerHTML = lbl;
        } else if (chk.id == "isactive") {
            spnactive.innerHTML = lbl;
        }else if (chk.id == "istaxexempted") {
            spntax.innerHTML = lbl;
        }else if (chk.id == "isoptional") {
            sopn.innerHTML = lbl;
        } else if (chk.id == "isallowance") {
        sisallowance.innerHTML = lbl;
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
