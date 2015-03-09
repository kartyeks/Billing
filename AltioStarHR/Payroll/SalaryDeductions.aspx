<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalaryDeductions.aspx.cs"
    Inherits="AltioStarHR.Payroll.SalaryDeductions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Salary Deductions</title>
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
<%--        <div style="background-color:#00daf5;width:885px;margin-left:2%;height:25px;padding-left:2%;font-family:Calibri;font-weight:bold;color:White;padding-top:1%">
            Salary Deductions</div>--%>
                        <div style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png"style="width:96%;margin-left:2%;height:53px;margin-top:0%"/>
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
  <strong class="family1 imageheadercolor">Salary Deductions</strong>
    </div>
</div>
        <div style="margin-left:2%;" id="box">
            <table id="list" class="scroll">
            </table>
            <div id="pager">
            </div>
        </div>
    </div>
    <div id="divSalaryDeduct" class="dialog" title="GradeDeductions" style="display: none;">
        <form id="signupForm" method="get" action="">
        <fieldset>
            <table class="teble_bg" style="width: 600px">
                <tbody>
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lname" for="name" class="family">
                                Name <span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="name" name="name" style="width: 200px" type="text" value="" tabindex="1" class="family"/>
                        </td>
                        <td id="sname" width="200" height="40" class="family">
                        </td>
                    </tr>
                    <tr>
                        <td class="label" width="200" height="40">
                            <label id="Label1" for="code" class="family">
                                Code <span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="code" name="code" style="width: 200px" type="text" value="" tabindex="1" class="family"/>
                        </td>
                        <td id="Td1" width="200" height="40" class="family">
                        </td>
                    </tr>
                    <tr>
                        <td class="family">
                            Deduction Period <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="family">
                            <label>
                                <input type="radio" name="myperiod" value="radio" id="rdoYear" tabindex="2" />
                                yearly</label>
                            <label>
                                <input type="radio" name="myperiod" checked value="radio" id="rdoMonth" tabindex="3" />
                                Monthly</label>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lblchkisemployee" for="chkchkisemployee" class="family">
                                IsEmployee Level</label>
                        </td>
                        <td class="field">
                            <input id="chkisemployee" type="checkbox" tabindex="4" onclick="return onEmployeeClick();" class="family"/>
                        </td>
                        <td class="status" id="schkisemployee">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lblispercentage" for="chkispercentage" class="family">
                                IsPercentage</label>
                        </td>
                        <td class="field">
                            <input id="chkispercentage" type="checkbox" tabindex="5" class="family"/>
                        </td>
                        <td class="status" id="schkispercentage">
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
                        <td class="label" width="200" height="40">
                            <label id="lbllimit" for="limit" class="family">
                                Limit <span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="limit" name="limit" type="text" style="width: 200px" value="" tabindex="6" class="family"/>
                        </td>
                        <td id="slimit" width="200" height="40" class="family">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lisactive" for="isactive" class="family">
                                Active</label>
                        </td>
                        <td class="field">
                            <input id="isactive" type="checkbox" tabindex="7" class="family"/>
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
                        <input id="signupsubmit" name="Submit" type="submit" value="Save" tabindex="8" class="family"/>
                    </td>
                    <td class="field">
                        <input id="Cancel" name="Cancel" type="button" value="Cancel" tabindex="9" class="family"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        </form>
        <input type="hidden" id='hdnEmployeeID' runat="server" />
        <input type="hidden" id='hdnmodule' runat="server" />
        <input type="hidden" id='hdnApprovlPermit' runat="server" />
        <input type="hidden" id="hdnApplyPermit" runat="server" />
        <input type="hidden" id="hdnViewPermit" runat="server" />
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
        var Response = SendApplicationRequest('<%=PayrollAppCommands.SALRYDEDUCTION_DETAILS%>', '', true);
        Response.ResponseObject.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'name', index: 'name', width: 100, editable: true },
            { name: 'code', index: 'code', width: 100, editable: true },
            { name: 'deductionperiod', index: 'deductionperiod', width: 100, hidden: true, editable: true },
            { name: 'limit', index: 'limit', width: 100, editable: true },
            { name: 'isemployeelevel', index: 'employeelevel', width: 100, editable: true },
            { name: 'ispercentage', index: 'ispercentage', width: 100, editable: true },
            { name: 'istaxexempted', index: 'istaxexempted', width: 100, hidden: true, editable: true },
            { name: 'isactive', index: 'isactive', width: 100, editable: true, hidden: true }
        ];
        Response.ResponseObject.caption="Salary Deductions"
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

//        if ($('#hdnEmployeeID').val() != "1") {
//            onGetPermissionDisplay();
//        }

//        $("input", "#t_list").click(function(id) {
//            if (id.currentTarget.id == "add") {
//                validator.resetForm();
//                mode = "add";
//                clearLabels();

//                document.getElementById("divSalaryDeduct").style.display = "";
//                $('#divSalaryDeduct').dialog({
//                    height: 350,
//                    width: 620,
//                    modal: true
//                })
//                $("input[type='text']:first", document.forms[0]).focus();
//            }
//            else if (id.currentTarget.id == "edit") {

//                validator.resetForm();
//                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
//                if (id) {
//                    var ret = jQuery("#list").jqGrid('getRowData', id);
//                    //if (ret.code != "") return;
//                    mode = "edit";
//                    clearLabels();
//                    document.getElementById("divSalaryDeduct").style.display = "";
//                    $('#divSalaryDeduct').dialog({
//                        height: 350,
//                        width: 620,
//                        modal: true
//                    })
//                    fillData();

//                    $("input[type='text']:first", document.forms[0]).focus();
//                }
//                else { alert("Please select a row"); }
//            }
//            else if (id.currentTarget.id == "activedata") {
//                mode = "activedata";
//                BindGrid(1);
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
//                        var Response = SendApplicationRequest("<%=PayrollAppCommands.DEACTIVATE_SALRYDEDUCTION%>", Request, true);
//                        alert(Response.Message);
//                        if (Response.ResponseCommand == 'SUCCESS') {
//                            mode = "";
//                            var Response = SendApplicationRequest('<%=PayrollAppCommands.SALRYDEDUCTION_DETAILS%>', '', true);
//                            if (Response.ResponseObject.datastr == null)
//                                jQuery("#list").jqGrid('clearGridData');
//                            else {
//                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
//                                jQuery("#list").jqGrid('setCaption', "Grade Salary Details: ").trigger('reloadGrid');
//                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
//                            }
//                        }
//                    }
//                    else alert("Selected Row is already deactivated!");                    
//                }
//                else alert("Please Select a Row to deactivate!");               
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
//                        var Response = SendApplicationRequest("<%=PayrollAppCommands.ACTIVATE_SALRYDEDUCTION%>", Request, true);
//                        alert(Response.Message);
//                        if (Response.ResponseCommand == 'SUCCESS') {
//                            mode = "";
//                            var Response = SendApplicationRequest('<%=PayrollAppCommands.INACTIVE_SALRYDEDUCTION%>', '', true);
//                            if (Response.ResponseObject.datastr == null)
//                                jQuery("#list").jqGrid('clearGridData');
//                            else {
//                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
//                                jQuery("#list").jqGrid('setCaption', "Grade Salary Details: ").trigger('reloadGrid');
//                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
//                            }
//                        }
//                    }
//                    else alert("Selected Row is already activated!");                    
//                }
//                else alert("Please Select a Row to activate!");                
//            }
//        });
//        
//        GridActiveButton();
//        var validator = $("#signupForm").validate({
//            rules: {
//                name: {
//                    required: true,
//                    alphaNumerix: true
//                },
//                code: {
//                    required: true,
//                    alphaNumerix: true
//                },
//                limit: {
//                    number: true
//                }
//            },
//            messages: {
//                name: {
//                    required: "Enter Name",
//                    alphaNumerix: "Invalid  Name"
//                },
//                code: {
//                    required: "Enter Code",
//                    alphaNumerix: "Invalid  Code"
//                },
//                limit:
//                       {
//                           number: "Invalid limit"
//                       }
//            },
//            errorPlacement: function(error, element) {
//                error.appendTo(element.parent().next());
//            },
//            
//            submitHandler: function(id) {
//                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
//                var Request = new Object();
//                var ID = "";
//                var reportids = "";
//                if (mode == "edit") {
//                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
//                    var ret = jQuery("#list").jqGrid('getRowData', id);
//                    ID = ret.id;
//                    Request.DeductionCode=ret.code;
//                }
//                else {
//                    ID = "0";
//                }

//                Request.UpdateBy = $("#hdnEmployeeID").val();
//                Request.ID = ID;
//                Request.Name = $("#name").val();
//                Request.Code = $("#code").val();
//                if ($("#limit").val() == "")
//                    Request.Limit = "0";
//                else
//                    Request.Limit = $("#limit").val();

//                if ($("#chkisemployee").is(':checked')) { Request.IsEmployee = true; }
//                else { Request.IsEmployee = false; }
//                if ($("#chkispercentage").is(':checked')) { Request.IsPercentage = true; }
//                else { Request.IsPercentage = false; }
//                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
//                else { Request.IsActive = false; }
//                
//                Request.IsTaxExempted= $("#istaxexempted").is(':checked');
//                if ($("#rdoMonth").is(':checked')) { Request.Period = "<%=PayrollAppCommands.ALLOWANCE_MONTHLY %>"; }
//                else { Request.Period = "<%=PayrollAppCommands.DEDUCTION_YEARLY%>"; }

//                var Response = SendApplicationRequest('<%=PayrollAppCommands.UPDATE_SALRYDEDUCTION%>', Request, true);                
//                if(mode == "edit")
//                {
//                  if(confirm('Do you want to Update the Changes made?') == false)
//                    return false;
//                }
//                
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
           var Response = SendApplicationRequest('<%=PayrollAppCommands.SALRYDEDUCTION_DETAILS%>', '', true);
            activeStatus = true;
        }
        else {
            var Response = SendApplicationRequest('<%=PayrollAppCommands.INACTIVE_SALRYDEDUCTION%>', '', true);
            activeStatus = false;
        }
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setCaption', "Salary Deductions").trigger('reloadGrid');
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
    
    function fillData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        
        $("#name").val(ret.name);
        $("#code").val(ret.code);
        $("#limit").val(ret.limit);
        if (ret.deductionperiod == "<%=PayrollAppCommands.ALLOWANCE_MONTHLY %>") { $("#rdoMonth").attr('checked', true); }
        else { $("#rdoYear").attr('checked', true); }
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }
        if (ret.ispercentage == 'False') { $("#chkispercentage").attr('checked', false); }
        else { $("#chkispercentage").attr('checked', true); }
        if (ret.isemployeelevel == 'False') { $("#chkisemployee").attr('checked', false); }
        else {
            $("#chkisemployee").attr('checked', true);
            $('#limit').attr('disabled', true);
            $('#chkispercentage').attr('disabled', true);
            $("#limit").val('');
        }
         $("#istaxexempted").attr('checked', (ret.istaxexempted == 'True'));
    }

    function clearLabels() {
        $("#name").val("");
        $("#code").val("");
        $("#limit").val("");
        $("#rdoMonth").attr('checked', true);
        $("#rdoYear").attr('checked', true);
        $("#chkispercentage").attr('checked', false);
        $("#isactive").attr('checked', true);
        $("#chkisemployee").attr('checked', false);
        $('#limit').attr('disabled', false);
        $('#chkispercentage').attr('disabled', false);
        $("#istaxexempted").attr('checked', false);
    }

    function onCancel() {
        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        $("#divSalaryDeduct").dialog('close');
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

    function onEmployeeClick() {
        if ($("#chkisemployee").is(':checked')) {
           // $('#limit').attr('disabled', true);
            $('#chkispercentage').attr('disabled', true);
           // $('#limit').val('');
            $('#chkispercentage').attr('checked', false);
        }
        else {
          //  $('#limit').attr('disabled', false);
            $('#chkispercentage').attr('disabled', false);
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
