<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoanManagement.aspx.cs"
    Inherits="AltioStarHR.LoanManagement.LoanManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Loan Management</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
       <%-- <div class="header_title2">
            Loan Management</div>--%>
        <div class="dvGrid">
            <table id="tableLoanRequest" class="scroll">
            </table>
            <div id="pager2">
            </div>
        </div>
    </div>
    <div id="divLoanRequest" class="dialog" title="Loan Request" style="display: none;">
        <form id="signupLoanRequestForm" method="get" action="">
        <fieldset>
            <table class="teble_bg" style="width: 650px">
                <tbody>
                    <tr>
                        <td class="label" width="200" height="40">
                            <label id="lloan" for="loan">
                                Loan <span style="font-size: medium; color: Red"><b>*</b></span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <select id="loan" name="loan" style="width: 200px" onchange="LoadLoanAmountInterest()">
                            </select>
                        </td>
                        <td>
                        </td>
                        <td id="sloan" width="200" height="40">
                        </td>
                    </tr>
                    <tr id="trLoanDetail1" style="display: none;" width="90" height="40">
                        <td class="label">
                            <label id="lmaxloanamount" for="maxloanamount">
                                Max Loan Amount</label>
                        </td>
                        <td class="field">
                            <b>
                                <label id="maxloanamount">
                                </label>
                                <label id="maxloanamountforvalidation" style="display: none">
                                </label>
                            </b>
                        </td>
                        <td class="status" id="smaxloanamount">
                        </td>
                    </tr>
                    <tr id="trLoanDetail2" style="display: none;">
                        <td class="label">
                            <label id="linterest" for="interest">
                                Interest</label>
                        </td>
                        <td class="field">
                            <b>
                                <label id="interest">
                                </label>
                            </b>
                        </td>
                        <td class="status" id="sinterest">
                        </td>
                    </tr>
                    <tr id="trLoanDetail4" style="display: none;">
                        <td colspan="3" class="label">
                            <label>
                                <span style="font-size: small; color: Red"><b>#</b> Interest applicable only when employee
                                    is Terminated/Fired before the completion of the loan tenure.</span></label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="display: none;">
                            <label id="interestlabel">
                            </label>
                        </td>
                    </tr>
                    <tr id="trLoanDetail3" style="display: none;">
                        <td class="label">
                            <label id="lrepaymentmonths" for="repaymentmonths">
                                Repayment Months <span style="font-size: medium; color: Red"><b>*</b></span></label>
                        </td>
                        <td class="field">
                            <input id="repaymentmonths" name="repaymentmonths" style="width: 200px" type="text"
                                value="" maxlength="100"  />
                        </td>
                        <td class="status" id="srepaymentmonths">
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td colspan="3">
                            <label id="repaymentmonthslabel">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td class="label" width="200" height="40">
                            <label id="lloanamount" for="loanamount">
                                Loan Amount <span style="font-size: medium; color: Red"><b>*</b></span></label>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="loanamount" name="loanamount" style="width: 200px" type="text" value=""
                                maxlength="100" disabled="disabled" />
                        </td>
                        <td id="sloanamount" width="200" height="40">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lmonthlyamount" for="monthlyamount">
                                Monthly Amount</label>
                        </td>
                        <td class="field">
                            <b>
                                <label id="monthlyamount">
                                </label>
                                <label id="monthlyamountfordb" style="display: none;">
                                </label>
                            </b>
                        </td>
                        <td class="status" id="smonthlyamount">
                        </td>
                    </tr>
                    <tr>
                        <td class="label" width="90" height="40">
                            <label id="lreason" for="reason">
                                Reason <span style="font-size: medium; color: Red"><b>*</b></span></label>
                        </td>
                        <td class="field" width="90" height="40">
                            <select id="reason" name="reason" style="width: auto" onchange="LoadTextBoxForOther()">
                            </select>
                        </td>
                        <td id="sreason" width="90" height="40">
                        </td>
                    </tr>
                    <tr id="trOtherReason" style="display:none">
                    <td>Other Reason</td>
                    <td>
                        <textarea name="otherreason" cols="30" rows="4" style="width: 300px" id="otherreason"></textarea> 
                    </td>
                    <td id="sotherreason" width="90" height="40">
                    </td>
                    </tr>
                    <tr id="ForHR" style="display: none;">
                        <td class="label" width="90" height="40">
                            <label id="lhrremarks" for="hrremarks">
                                HR Remarks</label>
                        </td>
                        <td class="field" width="90" height="40">
                            <textarea name="hrremarks" cols="30" rows="4" style="width: 300px" id="hrremarks"></textarea>
                        </td>
                        <td id="shrremarks" width="90" height="40">
                        </td>
                    </tr>
                </tbody>
            </table>
            <table>
                <tr id="trButtonControlForEmp" style="display: none;">
                    <td colspan="3">
                        <table>
                            <tr align="center">
                                <td class="field">
                                    <input id="signupsubmit" name="Submit" type="submit" value="Save" />
                                </td>
                                <td class="field">
                                    <input id="CancelLoanRequest" name="Cancel" type="button" value="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trButtonControlForHR" style="display: none;">
                    <td colspan="3">
                        <table>
                            <tr align="center">
                                <td class="field">
                                    <input id="btnAccept" name="Accept" type="button" value="Accept" />
                                </td>
                                <td class="field">
                                    <input id="btnReject" name="Reject" type="button" value="Reject" />
                                </td>
                                <td class="field">
                                    <input id="CancelHR" name="Cancel" type="button" value="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trAfterAction" style="display: none;">
                    <td colspan="3">
                        <input id="CancelAfterAction" name="Cancel" type="button" value="Cancel" onclick="onCancelLoanRequest()" />
                    </td>
                </tr>
            </table>
        </fieldset>
        </form>
    </div>
    <input type="hidden" id='hdnLoanReason' runat="server" />
    <input type="hidden" id='hdnmodule' runat="server" />
    <input type="hidden" id='hdnApprovlPermit' runat="server" />
    <input type="hidden" id="hdnApplyPermit" runat="server" />
    <input type="hidden" id="hdnViewPermit" runat="server" />
    <input type="hidden" id='hdnEmployeeID' runat="server" />
</body>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-1.6.2.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.17.custom.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/grid.locale-en.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.jqGrid.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Webutility.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/toolbar.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.core.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.widget.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.validate.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Validation.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.button.js") %>"></script>


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
    var eGradeId = 0;
    var xAmountRequest = 0;
    var ReqByEmpID = 0;

    jQuery(document).ready(function() {
    debugger
        //LoadPermits();
        LoadLoan();
        getLoanReson();
        LoadLoanAmountInterest();

        $('#CancelLoanRequest').click(function() {
            onCancelLoanRequest();
        });

        $('#CancelHR').click(function() {
            onCancelLoanRequest();
        });

        $('#btnAccept').click(function() {
            AcceptLoanRequest();
        });

        $('#btnReject').click(function() {
            RejectLoanRequest();
        });

        $.validator.addMethod("CheckDecimalUpto2Digit", function(value, element) {
            return this.optional(element) || /^[0-9]+(\.[0-9]{1,2})?$/i.test(value);
        }, "More Than Two Decimal Digit not allowed.");

        $("#loanamount").keyup(function() {
            calculateInstallment();
        });

        $("#loanamount").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && e.which != 46 && (e.which < 48 || e.which > 57)) {
                return false;
            }
            if ($("#loanamount").val().length > 9) {
                return false;
            }
        });

        $('#divLoanRequest').bind('dialogclose', function(event) {
            HideTrLoanDetails();
            clearLoanRequestLabels();
        });

        var myGrid = $('#tableLoanRequest');
        var Request = new Object();
        Request.AppliedTo = $('#hdnEmployeeID').val();
        var Response = '';
        debugger
        if ($('#hdnEmployeeID').val() == "1") {
            Response = SendApplicationRequest('<%=LoanAppCommands.LOANREQUEST_DETAILS%>', '', true, '<%=RequestCommands.LOAN_REQUEST%>');
        }
        else {
            Response = SendApplicationRequest('<%=LoanAppCommands.LOANREQUEST_APPLIEDTO_DETAILS%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
        }

        Response.ResponseObject.colModel = [
   		            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'empid', index: 'empid', width: 100, editable: true, hidden: true },
   		            { name: 'empname', index: 'empname', width: 100, editable: true },
   		            { name: 'loanid', index: 'loanid', width: 100, editable: true, hidden: true },
   		            { name: 'loanname', index: 'loanname', width: 100, editable: true },
   		            { name: 'loanamount', index: 'loanamount', width: 100, editable: true },
   		            { name: 'repaymentmonths', index: 'repaymentmonths', width: 100, editable: true },
   		            { name: 'monthlyamount', index: 'monthlyamount', width: 100, editable: true },
   		            { name: 'reason', index: 'reason', width: 100, editable: true, hidden: true },
   		            { name: 'Applieddatetime', index: 'Applieddatetime', width: 100, editable: true, formatter: 'date', "formatoptions": { srcformat: 'Y-m-d', newformat: 'd/m/Y'} },
   		            { name: 'appliedto', index: 'appliedto', width: 100, editable: true, hidden: true },
   		            { name: 'hrremarks', index: 'hrremarks', width: 100, editable: true, hidden: true },
   		            { name: 'status', index: 'status', width: 100, editable: true, stype: 'select', editoptions: { value: ":ALL;NEW:NEW;APPROVED:APPROVED;REJECTED:REJECTED;DISBURSEMENT:DISBURSEMENT"} },
   		            { name: 'appliedToName', index: 'appliedToName', width: 100, editable: true, hidden: true }
   	            ]

        Response.ResponseObject.height = 240;
        Response.ResponseObject.pager = "#pager2";
        myGrid.jqGrid(Response.ResponseObject);

        jQuery("#tableLoanRequest").jqGrid('navGrid', '#pager2', { del: false, add: false, edit: false, search: false });
        jQuery("#tableLoanRequest").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#tableLoanRequest").jqGrid('navButtonAdd', "#pager2", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

        jQuery("#tableLoanRequest").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        $("#t_tableLoanRequest").append("<input type='button' id='request' value='Request'  style='height:24px;font-size:-3'/> ");
        $("#t_tableLoanRequest").append("<input type='button' id='editrequest' value='Edit Request' style='height:24px;font-size:-3'/> ");
        $("#t_tableLoanRequest").append("<input type='hidden' id='view' value='View' style='height:24px;font-size:-3' /> ");
        if ($('#hdnEmployeeID').val() != "1") {
            //onGetPermissionDisplay();
        }
        $("input", "#t_tableLoanRequest").click(function(id) {
        if (id.currentTarget.id == "request") {
            
                var rowid = jQuery("#tableLoanRequest").jqGrid('getGridParam', 'selrow');
                //if (rowid) {
                    //strQr="rtype=loanmgmt=" + "&employeeid=" + $("#hdnEmployeeID").val();
                    debugger
                    ReqByEmpID = $("#hdnEmployeeID").val();
                    var Request = new Object();
                    Request.ID = ReqByEmpID;
                    var Response = SendApplicationRequest('<%=LoanAppCommands.CHECK_EGIBLITY_LOAN_REQUEST%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
                    if (Response.ResponseCommand != 'SUCCESS') {
                        alert(Response.Message);
                        return;
                    }
                    //kartyek 10.2.2015 for HOD not available in this application
//                    var ResponseHOD = SendApplicationRequest('<%=LoanAppCommands.CHECK_LOAN_DEPTHOD%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
//                    if (ResponseHOD.ResponseCommand != 'SUCCESS') {
//                        alert(ResponseHOD.Message);
//                        return;
//                    }
                    validatorLoanRequest.resetForm();
                    clearLoanRequestLabels();
                    mode = "addRequest";
                    document.getElementById("divLoanRequest").style.display = "";
                    document.getElementById("trOtherReason").style.display = "none";
                    $('#divLoanRequest').dialog({
                        height: 355,
                        width: 700,
                        modal: true
                    })
                    $('#loan').attr('disabled', false);
                    $('#loanamount').attr('disabled', false);
                    $('#reason').attr('readonly', false);
                    document.getElementById("trButtonControlForEmp").style.display = "";
                    document.getElementById("trButtonControlForHR").style.display = "none";
                    document.getElementById("trAfterAction").style.display = "none";
                    document.getElementById("ForHR").style.display = "none";
//                }
//                else
//                    alert('Select a row for requesting');
            }
            else if (id.currentTarget.id == "editrequest") {
                ReqByEmpID = $("#hdnEmployeeID").val();
                validatorLoanRequest.resetForm();
                var id = jQuery("#tableLoanRequest").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#tableLoanRequest").jqGrid('getRowData', id);
                if (id) {
                    if (ret.status == "New") {
                        clearLoanRequestLabels();

                        fillLoanRequestData();
                        mode = "editRequest";
                        document.getElementById("divLoanRequest").style.display = "";
                        $('#divLoanRequest').dialog({
                            height: 355,
                            width: 700,
                            modal: true
                        })
                        $('#loan').attr('disabled', false);
                        $('#loanamount').attr('disabled', false);
                        $('#reason').attr('readonly', false);
                        document.getElementById("trButtonControlForEmp").style.display = "";
                        document.getElementById("trButtonControlForHR").style.display = "none";
                        document.getElementById("trAfterAction").style.display = "none";
                        document.getElementById("ForHR").style.display = "none";

                    }
                    else if (ret.status == "Rejected")
                        alert("Selected Loan request is rejected.Not Editable");
                    else
                        alert("Selected Loan request is under process.Not Editable");
                }
                else {
                    alert("Select loan Request");
                }
            }
            else if (id.currentTarget.id == "view") {
                validatorLoanRequest.resetForm();

                var id = jQuery("#tableLoanRequest").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#tableLoanRequest").jqGrid('getRowData', id);
                if (id) {
                    if (ret.status != "") {
                        ReqByEmpID = ret.empid;
                        mode = "view";
                        clearLoanRequestLabels();
                        document.getElementById("divLoanRequest").style.display = "";
                        document.getElementById("ForHR").style.display = "";
                        document.getElementById("trOtherReason").style.display = "none";
                        $('#divLoanRequest').dialog({
                            height: 400,
                            width: 700,
                            modal: true
                        })

                        fillLoanRequestData();

                        $('#loan').attr('disabled', true);
                        $('#loanamount').attr('disabled', true);
                        $('#reason').attr('readonly', 'readonly');
                        $('#HRappliedto').text(ret.appliedToName);
                        document.getElementById("trButtonControlForEmp").style.display = "none";
                        if (ret.status == 'NEW') {
                            if (parseInt(ret.loanamount) > parseInt($('#maxloanamountforvalidation').text()))
                                alert("Requested Loan amount is greater than Current Max loan amount");
                            $('#hrremarks').attr('readonly', false);
                            document.getElementById("trButtonControlForHR").style.display = "";
                            document.getElementById("trAfterAction").style.display = "none";
                        }
                        else {
                            $('#hrremarks').attr('readonly', 'readonly');
                            document.getElementById("trButtonControlForHR").style.display = "none";
                            document.getElementById("trAfterAction").style.display = "";
                        }
                    }
                    else {
                        alert("Selected Loan Request is not valid!");
                    }
                }
                else { alert("Please select Loan Request"); }
            }
        });
        var validatorLoanRequest = $("#signupLoanRequestForm").validate({
            rules: {
                loan: "required",
                loanamount: {
                    required: true,
                    CheckDecimalUpto2Digit: true
                },
                repaymentmonths: "required",
                reason: {
                    required: true,
                    maxlength: 250
                },
                hrremarks: {
                    maxlength: 250
                },
                otherreason: {
                    required: function(element) {
                        return $("#reason").val() == "Others";
                    },
                    maxlength: 250
                }
            },
            messages: {
                loan: "Select loan",
                loanamount: {
                    required: "Enter Loan Amount",
                    CheckDecimalUpto2Digit: "Invalid Loan Amount"
                },
                repaymentmonths: "Enter Repayment Months",
                reason: {
                    required: "Enter Reason",
                    maxlength: jQuery.format("Enter maximum {0} characters")
                },
                hrremarks: {
                    maxlength: jQuery.format("Enter maximum {0} characters")
                },
                otherreason: {
                    required: "Enter other reason",
                    maxlength: jQuery.format("Enter maximum {0} characters")
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function() {
debugger
                if ($("#repaymentmonths").val() == "") {
                    alert("You are not eligible to request loan");
                    return;
                }
                var currPage = jQuery('#tableLoanRequest').jqGrid('getGridParam', 'page');

                var curloanval = parseFloat($("#loanamount").val());
                var storeloanval = parseFloat($("#maxloanamountforvalidation").text());

                var Request = new Object();

                if (mode == "editRequest") {
                    var id = jQuery("#tableLoanRequest").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#tableLoanRequest").jqGrid('getRowData', id);
                    ID = ret.id;
                }
                else {
                    ID = "0";
                }
                debugger
                Request.ID = ID;
                Request.EmpID = $("#hdnEmployeeID").val();
                Request.LoanID = $("#loan").val();
                Request.LoanAmount = $("#loanamount").val();
                Request.RepaymentMonths = $("#repaymentmonths").val();
                Request.MonthlyAmount = $("#monthlyamountfordb").text();
                debugger
                var CurrReason = $("#reason").val();
                if ($("#reason").val() == 'Others')
                    CurrReason = $("#otherreason").val();
                Request.Reason = CurrReason;
                Request.UpdateBy = $("#hdnEmployeeID").val();
                Request.MaxAmount = $("#maxloanamountforvalidation").text();
                Request.Interest = $("#interestlabel").text();
                Request.ActualRepaymentMonth = $("#repaymentmonthslabel").text();

                var Response1 = SendApplicationRequest('<%=LoanAppCommands.PLACE_LOANREQUEST%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
                if (Response1.ResponseCommand == 'SUCCESS') {
                    if (mode == "editRequest") {
                        alert("Loan Request sent successfully");
                    }
                    else
                        alert("Loan Request sent successfully");
                    mode = "SUCCESS";
                    var RequestAfterAction = new Object();
                    RequestAfterAction.AppliedTo = $('#hdnEmployeeID').val();
                    var ResponseAfterAction = '';

                    if ($('#hdnEmployeeID').val() == "1") {
                        ResponseAfterAction = SendApplicationRequest('<%=LoanAppCommands.LOANREQUEST_DETAILS%>', '', true, '<%=RequestCommands.LOAN_REQUEST%>');
                    }
                    else {
                        ResponseAfterAction = SendApplicationRequest('<%=LoanAppCommands.LOANREQUEST_APPLIEDTO_DETAILS%>', RequestAfterAction, true, '<%=RequestCommands.LOAN_REQUEST%>');
                    }

                    jQuery("#tableLoanRequest").jqGrid('setGridParam', ResponseAfterAction.ResponseObject);
                    jQuery("#tableLoanRequest").jqGrid('setCaption', "EmployeeLoanInfo").trigger('reloadGrid');
                    clearLoanRequestLabels();
                    onCancelLoanRequest();
                    HideTrLoanDetails();
                    jQuery("#tableLoanRequest").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                    // Code for email loan 
                    //                        path = Response1.Message + "$loanemail" + "$Request";
                    //                        $.post("UploadFileHandler.ashx", { path: path }, function(data) {
                    //                            var d = data.split(':');
                    //                            $("#res").html("File Name : " + d[0] + "File Size : " + d[1] + "File Type : " + d[2]);

                    //                        });
                }
                else alert(Response1.Message);
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });
    });
    function LoadTextBoxForOther(){
    debugger
        if($("#reason").val()=='Others'){
            $("#otherreason").val("");
            document.getElementById("trOtherReason").style.display="";
        }
        else {
            document.getElementById("trOtherReason").style.display="none";
        }                
    }
    function FillGridLoanRequest() {
        var Response = SendApplicationRequest('<%=LoanAppCommands.LOANREQUEST_DETAILS%>', '', true, '<%=RequestCommands.LOAN_REQUEST%>');
        jQuery("#tableLoanRequest").jqGrid('setGridParam', Response.ResponseObject);
        jQuery("#tableLoanRequest").jqGrid('setCaption', "EmployeeLoanInfo").trigger('reloadGrid');
        jQuery("#tableLoanRequest").jqGrid('setGridParam', { page: currPagetableLoanRequest }).trigger('reloadGrid');
    }

    function onCancelLoanRequest() {
        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        $("#divLoanRequest").dialog('close');
    }
    
    function fillLoanRequestData() {
        var id = jQuery("#tableLoanRequest").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#tableLoanRequest").jqGrid('getRowData', id);
        $("#loan").val(ret.loanid);
        $("#loanamount").val(ret.loanamount);
        $("#monthlyamount").text(ret.monthlyamount);
        $("#reason").val(ret.reason);
        if($("#reason").val()=="")
        {
            $("#otherreason").val(ret.reason);
            $("#reason").val("Others");
            document.getElementById("trOtherReason").style.display="";
        }
        else document.getElementById("trOtherReason").style.display="none";
        $("#hrremarks").val(ret.hrremarks);
        
        LoadLoanAmountInterest();
        
        if (ret.status == "ACCEPTED" || ret.status == "REJECTED") {
            HideTrLoanDetails();
            document.getElementById("trLoanDetail3").style.display = "";
        }
    }
    
    function clearLoanRequestLabels() {
        $("select#loan")[0].selectedIndex = 0;
        $("#maxloanamount").text("");
        $("#interest").text("");
        $("#loanamount").val("");
        $("#repaymentmonths").val("");
        $("#monthlyamount").text("");
        $("#monthlyamountfordb").text("");
        $("#reason").val("");
        $("#hrremarks").val("");
        $("#otherreason").val("");
    }

    function calculateInstallment() {
    
        if ($("#loanamount").val() != "" && $("#repaymentmonths").val() != ""
               && $("#interest").text() != "" && $("#loan").text() != "") {
            var xLoanAmt = parseFloat($("#loanamount").val());
            var splitInterest = $("#interest").text().split('%');
            var xInterest = parseFloat(splitInterest[0]);
            var xMonth = parseInt($("#repaymentmonths").val());            
            var xInstallment = xLoanAmt / xMonth;
            $("#monthlyamount").text("Rs. " + xInstallment.toFixed(2) + " Per Month");
            $("#monthlyamountfordb").text(xInstallment.toFixed(2));
        }
        else {
            $("#monthlyamount").text("");
            $("#monthlyamountfordb").text("");
        }
    }

    function LoadLoan() {
    
        var objLocTypeName = document.getElementById('loan');
        objLocTypeName.options.length = 0;
        var optn = document.createElement("OPTION");
        optn.text = "Choose Loan";
        optn.value = "";
        objLocTypeName.options.add(optn);
        var Request= new Object;
        Request.ID=$("#hdnEmployeeID").val(); 
        var Response = SendApplicationRequest("<%=HRAppCommands.COMBOLOAN_DETAILS%>", Request, true);
        if (Response.ResponseCommand == "SUCCESS") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['LoanName'];
                optn.value = arr[i]['ID'];
                objLocTypeName.options.add(optn);
            }
        }
    }
    
    function ShowTrLoanDetails() {
        document.getElementById("trLoanDetail1").style.display = "";
        document.getElementById("trLoanDetail2").style.display = "";
        document.getElementById("trLoanDetail3").style.display = "";
        document.getElementById("trLoanDetail4").style.display = "";
    }
    
    function HideTrLoanDetails() {
        document.getElementById("trLoanDetail1").style.display = "none";
        document.getElementById("trLoanDetail2").style.display = "none";
        document.getElementById("trLoanDetail3").style.display = "none";
        document.getElementById("trLoanDetail4").style.display = "none";
    }

    function LoadLoanAmountInterest() {    
    debugger
    if ($("#loan").val() != "")
    {
        var Request = new Object();
        Request.LoanID = $("#loan").val();
        Request.EmpID = ReqByEmpID;
        var Response = SendApplicationRequest("<%=HRAppCommands.LOANAMOUNTBYLOAN%>", Request);
        if (Response.ResponseCommand == "SUCCESS") {            
            var array = Response.ResponseObject.split('%');
            var xmaxloanamount = array[0];
            var xinterest = array[1];
            var xrepayment = array[2];
            $("#maxloanamount").text("Rs. " + xmaxloanamount);
            $("#maxloanamountforvalidation").text(xmaxloanamount);
            $("#interest").text(xinterest + "%");
            $("#interestlabel").text(xinterest);
            $("#repaymentmonths").val(xrepayment);
            $("#repaymentmonthslabel").text(xrepayment);
            calculateInstallment();
            ShowTrLoanDetails();            
        }
        else {
                //alert("Selected Loan is Inactive");
                HideTrLoanDetails();                
                $("#maxloanamount").text("");
                $("#maxloanamountforvalidation").text("");
                $("#interest").text("");
                $("#repaymentmonths").val("");
                $("#monthlyamount").text("");
                $("#monthlyamountfordb").text("");
            }
     }
    else {
        $("#loanamount").val("");        
        $("#loanamount").attr('disabled', 'disabled');
        HideTrLoanDetails();
        $("#maxloanamount").text("");
        $("#maxloanamountforvalidation").text("");
        $("#interest").text("");
        $("#repaymentmonths").val("");
        $("#monthlyamount").text("");
        $("#monthlyamountfordb").text("");        
    }
    }
    
    function AcceptLoanRequest() {    
        var currPage = jQuery('#tableLoanRequest').jqGrid('getGridParam', 'page');
        var Request = new Object();
        var ID = "";
        var id = jQuery("#tableLoanRequest").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#tableLoanRequest").jqGrid('getRowData', id);

        if (confirm('Do you want to accept?') == false) return;
        Request.ID = ret.id;
        Request.EmpID = ret.empid;
        Request.LoanID = ret.loanid;
        Request.LoanAmount = ret.loanamount;
        Request.HRRemarks = $("#hrremarks").val();
        Request.ChangedBy = $("#hdnEmployeeID").val();

        var Response = SendApplicationRequest('<%=LoanAppCommands.ACCEPTLOANREQUEST_DETAILS%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
        alert(Response.Message);
        if (Response.ResponseCommand == 'SUCCESS') {
            mode = "SUCCESS";            
            var RequestAfterAction = new Object();
            RequestAfterAction.AppliedTo = $('#hdnEmployeeID').val();
            var ResponseAfterAction = '';

            if ($('#hdnEmployeeID').val() == "1") {
                ResponseAfterAction = SendApplicationRequest('<%=LoanAppCommands.LOANREQUEST_DETAILS%>', '', true, '<%=RequestCommands.LOAN_REQUEST%>');
            }
            else {
                ResponseAfterAction = SendApplicationRequest('<%=LoanAppCommands.LOANREQUEST_APPLIEDTO_DETAILS%>', RequestAfterAction, true, '<%=RequestCommands.LOAN_REQUEST%>');
            }
            jQuery("#tableLoanRequest").jqGrid('setGridParam', ResponseAfterAction.ResponseObject);
            jQuery("#tableLoanRequest").jqGrid('setCaption', "EmployeeLoanInfo").trigger('reloadGrid');
            clearLoanRequestLabels();
            onCancelLoanRequest();            
            jQuery("#tableLoanRequest").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
            
            //EMAIL!
            $.post("CollectEmailsFromApp.ashx", { path: "LoanAppRej", loanTypeId: ret.loanid ,  
                                            loanName: ret.loanname ,
                                            empId: ret.empid,                      
                                            action: "Approved",
                                            loanAmount: ret.loanamount,
                                            actionbyempid : $("#hdnEmployeeID").val() });  
        }

    }

    function RejectLoanRequest() {
        var currPage = jQuery('#tableLoanRequest').jqGrid('getGridParam', 'page');
        var Request = new Object();
        var ID = "";
        var id = jQuery("#tableLoanRequest").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#tableLoanRequest").jqGrid('getRowData', id);
        if (confirm('Do you want to reject?') == false) return;
        var currPage = jQuery('#tableLoanRequest').jqGrid('getGridParam', 'page');
        Request.ID = ret.id;
        Request.HRRemarks = $("#hrremarks").val();
        Request.ChangedBy = $("#hdnEmployeeID").val();

        var Response = SendApplicationRequest('<%=LoanAppCommands.REJECTLOANREQUEST_DETAILS%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
        alert(Response.Message);
        if (Response.ResponseCommand == 'SUCCESS') {
            mode = "SUCCESS";            
            var RequestAfterAction = new Object();
            RequestAfterAction.AppliedTo = $('#hdnEmployeeID').val();
            var ResponseAfterAction = '';

            if ($('#hdnEmployeeID').val() == "1") {
                ResponseAfterAction = SendApplicationRequest('<%=LoanAppCommands.LOANREQUEST_DETAILS%>', '', true, '<%=RequestCommands.LOAN_REQUEST%>');
            }
            else {
                ResponseAfterAction = SendApplicationRequest('<%=LoanAppCommands.LOANREQUEST_APPLIEDTO_DETAILS%>', RequestAfterAction, true, '<%=RequestCommands.LOAN_REQUEST%>');
            }
            jQuery("#tableLoanRequest").jqGrid('setGridParam', ResponseAfterAction.ResponseObject);
            jQuery("#tableLoanRequest").jqGrid('setCaption', "EmployeeLoanInfo").trigger('reloadGrid');
            clearLoanRequestLabels();
            onCancelLoanRequest();
            jQuery("#tableLoanRequest").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
             //EMAIL!
            $.post("CollectEmailsFromApp.ashx", { path: "LoanAppRej", loanTypeId: ret.loanid ,  
                                            loanName: ret.loanname ,
                                            empId: ret.empid,                      
                                            action: "Rejected",
                                            loanAmount: ret.loanamount,
                                            actionbyempid : $("#hdnEmployeeID").val() }); 
        }

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
        document.getElementById("request").style.display = "none";
        document.getElementById("view").style.display = "none";

        if (document.getElementById("hdnApplyPermit").value == "true") {
            document.getElementById("request").style.display = "";
        }
        if (document.getElementById("hdnApprovlPermit").value == "true") {
            document.getElementById("view").style.display = "";
        }
    }
    
    function getLoanReson()
    {    
    debugger
        var LoanReason= $("#hdnLoanReason").val();
        var substr = LoanReason.split(',');
        var objName = document.getElementById('reason'); 
        objName.options.length = 0;
        var optn = document.createElement("OPTION");
        optn.text = "Select Reason";
        optn.value = "";
        objName.options.add(optn);
        for (var i = 0; i < substr.length; ++i) {
                var optn = document.createElement("OPTION");
                var optnFun = document.createElement("OPTION");
                optn.text =substr[i];
                optn.value =substr[i];
                objName.options.add(optn);
        }
    }
    
</script>

<script type="text/javascript">
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('#t_tableLoanRequest').css('background', 'none');
        $('#t_tableLoanRequest').css('background-color', '#fff');
        $('#t_tableLoanRequest').css('padding', '10px 0px');
        $('#t_tableLoanRequest input[type=button]').css('margin-left', '10px');
        $('body input[type=button]').button();
        $('body input[type=submit]').button();
        $('body button').button();
        $('body input[type=text]').addClass('text ui-widget-content ui-corner-all');
        $('body textarea').addClass('text ui-widget-content ui-corner-all');
        $('body select').addClass('text ui-widget-content ui-corner-all');
        $('#pager2 input[type=text]').css('width', '40px');
        $('#pager2 select').css('width', '50px');
        $('#pager2 select').css('margin-left', '15px');
    });
</script>

</html>
