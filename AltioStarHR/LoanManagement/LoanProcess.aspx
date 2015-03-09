<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoanProcess.aspx.cs" Inherits="AltioStarHR.LoanManagement.LoanProcess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Loan Processing</title>
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
            Loan Processing</div>--%>
        <div class="dvGrid">
            <table id="list" class="scroll">
            </table>
            <div id="pager">
            </div>
        </div>
    </div>
    <div id="divLoanActivity" class="dialog" title="Loan Request" style="display: none">
        <form id="signupLoanActivityForm" method="get" action="">
        <fieldset>
            <table class="teble_bg" >
                <tbody>
                    <tr>
                        <td class="label" style="width: 140px">
                            <label id="llblEmpName" for="lblEmpName" >
                                <b>Employee Name</b>
                            </label>
                        </td>
                        <td class="field">
                            <label id="lblEmpName">
                            </label>
                        </td>
                        <td class="status" id="slblEmpName">
                        </td>
                    </tr>
                    <tr style="width: auto">
                        <td class="label">
                            <label id="llblEmpCode" for="lblEmpCode">
                                <b>Employee Code</b>
                            </label>
                        </td>
                        <td class="field">
                            <label id="lblEmpCode">
                            </label>
                        </td>
                        <td class="status" id="slblEmpCode">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="llblLoanName" for="lblLoanName">
                                <b>Loan Name</b>
                            </label>
                        </td>
                        <td class="field">
                            <label id="lblLoanName">
                            </label>
                        </td>
                        <td class="status" id="slblLoanName">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="llblrequestedAmount" for="lblrequestedAmount">
                                <b>Request Amount</b></label>
                        </td>
                        <td class="field">
                            <label id="lblrequestedAmount">
                            </label>
                        </td>
                        <td class="status" id="lblrequestedAmount">
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td class="label">
                            <label id="llblInterest" for="lblInterest">
                                <b>Interest</b></label>
                        </td>
                        <td class="field">
                            <label id="lblInterest">
                            </label>
                        </td>
                        <td class="status" id="slblInterest">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="llblRepaymentMonth" for="lblRepaymentMonth">
                                <b>Repayment Month</b></label>
                        </td>
                        <td class="field">
                            <label id="lblRepaymentMonth">
                            </label>
                        </td>
                        <td class="status" id="lblRepaymentMonth">
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td class="label">
                            <label id="llblCurrentStatus" for="lblCurrentStatus">
                                <b>Current Status</b></label>
                        </td>
                        <td class="field">
                            <label id="lblCurrentStatus">
                            </label>
                        </td>
                        <td class="status" id="slblCurrentStatus">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="llblReason" for="lblReason">
                                <b>Reason</b></label>
                        </td>
                        <td class="field">
                            <label id="lblReason">
                            </label>
                        </td>
                        <td class="status" id="slblReason">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lpreComment" for="preComment">
                                <b>Previous Comments</b></label>
                        </td>
                        <td class="field">
                            <div id="preComment"></div>
                        </td>
                        <td class="status" id="spreComment">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lremark" for="remark">
                                <b>Remarks</b><span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field">
                            <textarea name="remarks" rows="4" id="remarks"></textarea>
                        </td>
                        <td class="status" id="sremarks">
                        </td>
                    </tr>
                    <tr id="trloanstart" style="display:none">
                        <td class="label">
                            <label id="lloanstartdate" for="loanstartdate">
                                <b>Loan Start From </b><span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field">
                                <input id="loanstartdate" name="loanstartdate" style="width: 80px" readonly="readonly" type="text"
                                                        tabindex="32" />
                        </td>
                        <td class="status" id="sloanstartdate">
                        </td>
                    </tr>
                    <tr>
                        <td class="field">
                            <input id="signupsubmit" name="Submit" type="submit" value="Save" />
                        </td>
                        <td>
                            <input id="Cancel" name="Cancel" type="button" value="CANCEL" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
        </form>
    </div>
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
    jQuery(document).ready(function() {    
        LoadPermits();        
        $("#loanstartdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
            }).change(function() {
            });
            $("#loanstartdate").datepicker("option", "dateFormat", 'dd/mm/yy');
        
        $('#Cancel').click(function() {
            onCancel();
        });
        
        $('#reject').click(function() {
            RejectLoanRequest();
        });
        
        var myGrid = $('#list');
        var Request = new Object();
        Request.EmpID = $('#hdnEmployeeID').val();
        var Response = '';
        Response = SendApplicationRequest('<%=LoanAppCommands.REQUESTED_LOAN%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
        debugger
        Response.ResponseObject.colModel = [
                    { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'loanrequestid', index: 'loanrequestid', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'empname', index: 'empname', width: 100, editable: true },
   		            { name: 'empcode', index: 'empcode', width: 100, editable: true },
   		            { name: 'teamname', index: 'teamname', width: 100, editable: true, hidden: true },
   		            { name: 'loanname', index: 'loanname', width: 100, editable: true },
   		            { name: 'loanamount', index: 'loanamount', width: 100, editable: true },
   		            { name: 'requeston', index: 'requeston', width: 100, editable: true , formatter:'date', "formatoptions":{srcformat: 'Y-m-d',newformat: 'd/m/Y'}  },
   		            { name: 'repaymentmonths', index: 'repaymentmonths', width: 100, editable: true, hidden: true  },
   		            { name: 'status', index: 'status', width: 100, editable: true, hidden: true },
   		            { name: 'maxamount', index: 'maxamount', width: 100, editable: true, hidden: true },
   		            { name: 'actualrepaymentmonth', index: 'actualrepaymentmonth', width: 100, editable: true, hidden: true  },
   		            { name: 'reason', index: 'reason', width: 100, editable: true, hidden: true },
   		            { name: 'interest', index: 'interest', width: 100, editable: true, hidden: true },
   		            { name: 'preComment', index: 'preComment', width: 100, editable: true, hidden: true },
   		            { name: 'statusdesc', index: 'statusdesc', width: 100, editable: true }
   	            ]
   	    
   	    Response.ResponseObject.onSelectRow = function(id) {
   	    debugger
   	    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
            debugger
             if(ret.status == "NEW"){
                $("#movetohr").show();
                $("#checkreport").hide();
                $("#movetofinance").hide();
                $("#approvenclose").hide();  
                //$("#mdapproval").hide();   
                $("#reject").show();              
                }
              else if (ret.status == "CHK" || ret.status == "COO"){
                $("#movetohr").hide();
                $("#checkreport").show();
                $("#movetofinance").hide();
                $("#approvenclose").hide();
                //$("#mdapproval").hide();  
                if(ret.status == "COO")
                $("#reject").show();
                else
                $("#reject").hide();
               } 
             else if (ret.status == "RRE"){
                $("#movetohr").hide();
                $("#checkreport").hide();
                $("#movetofinance").show();
                $("#approvenclose").hide();   
                //$("#mdapproval").hide();
                $("#reject").show();
               } 
//             else if (ret.status == "COO"){
//                $("#movetohr").hide();
//                $("#checkreport").hide();
//                $("#movetofinance").hide();
//                $("#approvenclose").hide();   
//                $("#mdapproval").show();
//                $("#reject").show();
//               } 
             else if(ret.status == "APP"){
                $("#movetohr").hide();
                $("#checkreport").hide();
                $("#movetofinance").hide();
                $("#approvenclose").show();  
                //$("#mdapproval").hide(); 
                $("#reject").hide();             
                }
        }
        
        Response.ResponseObject.height = 230;
        myGrid.jqGrid(Response.ResponseObject);

        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");

        $("#t_list").append("<input type='button' id='movetohr' value='View and Approve Loan request'  style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<input type='button' id='checkreport' value='View and Approve Loan request'  style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<input type='button' id='movetofinance' value='View and Approve Loan request'  style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<input type='button' id='approvenclose' value='View and Approve Loan request'  style='height:24px;font-size:-3'/> ");
        //$("#t_list").append("<input type='button' id='mdapproval' value='VIEW AND APPROVED LOAN REQUEST'  style='height:24px;font-size:-3'/> ");        
        $("#t_list").append("<input type='button' id='reject' value='View and Reject Loan request'  style='height:24px;font-size:-3'/> ");        
        $("#t_list").append("New Request <input type='checkbox' id='newdata' value='newdata' checked /> ");        
        
        
        $("#movetohr").show();
        $("#movetofinance").hide();
        $("#approvenclose").hide(); 
        $("#checkreport").hide(); 
        //$("#mdapproval").hide();
        $("#reject").hide();
        
        $("input", "#t_list").click(function(id) {
        debugger
            if (id.currentTarget.id == "movetohr") {
                
                mode = "movetohr";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if(id)
                {
//                if(ret.statusdesc!="New"){
//                    alert("Selected Loan Request already processed");
//                    return;
//                }
                clearLoanActivityLabels();
                fillLoanActivityData();
                document.getElementById("divLoanActivity").style.display = "";
                $("#signupsubmit").val("Forward To HR Dept");
                $('#divLoanActivity').dialog({
                    height: 380,
                    width: 580,
                    modal: true
                })
                }
                else alert("Select a Loan Request for View/Approve");                
            }
            else if (id.currentTarget.id == "newdata") {
                mode = "newdata";
                
                BindGrid(1);
            }
            else if (id.currentTarget.id == "checkreport") {    
                 mode = "checkreport";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if(id)
                {
//                if(ret.statusdesc!="New"){
//                    alert("Selected Loan Request already processed");
//                    return;
//                }
                clearLoanActivityLabels();
                fillLoanActivityData();
                document.getElementById("divLoanActivity").style.display = "";
                if(parseFloat(ret.maxamount)<parseFloat(ret.loanamount) && ret.status=='CHK')
                $("#signupsubmit").val("Forward To COO/MD");
                else if(parseFloat(ret.maxamount)<parseFloat(ret.loanamount) && ret.status!='CHK')
                $("#signupsubmit").val("Approve");
                else 
                $("#signupsubmit").val("Forward To HOD");
                $('#divLoanActivity').dialog({
                    height: 380,
                    width: 580,
                    modal: true
                })
                }
                else alert("Select a Loan Request for View/Approve");                
            }
            else if (id.currentTarget.id == "movetofinance") {    
                 mode = "movetofinance";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if(id)
                {
//                if(ret.statusdesc!="New"){
//                    alert("Selected Loan Request already processed");
//                    return;
//                }
                clearLoanActivityLabels();
                fillLoanActivityData();
                document.getElementById("divLoanActivity").style.display = "";
                $("#signupsubmit").val("Forward To Finance Dept");
                $('#divLoanActivity').dialog({
                    height: 380,
                    width: 580,
                    modal: true
                })
                }
                else alert("Select a Loan Request for View/Approve");                
            }
//            else if (id.currentTarget.id == "mdapproval") {    
//                 mode = "mdapproval";
//                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
//                var ret = jQuery("#list").jqGrid('getRowData', id);
//                if(id)
//                {
//                clearLoanActivityLabels();
//                fillLoanActivityData();
//                document.getElementById("divLoanActivity").style.display = "";
//                $("#signupsubmit").val("Forward To HOD");
//                $('#divLoanActivity').dialog({
//                    height: 380,
//                    width: 580,
//                    modal: true
//                })
//                }
//                else alert("Select a Loan Request for View/Approve");                
//            }
            else if (id.currentTarget.id == "approvenclose") {
                 mode = "approvenclose";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if(id)
                {
//                if(ret.statusdesc!="New"){
//                    alert("Selected Loan Request already processed");
//                    return;
//                }
                clearLoanActivityLabels();
                fillLoanActivityData();
                document.getElementById("divLoanActivity").style.display = "";
                
                document.getElementById("trloanstart").style.display = "";
                $("#signupsubmit").val("Approve and Close");
                $('#divLoanActivity').dialog({
                    height: 380,
                    width: 580,
                    modal: true
                })
                }
                else alert("Select a Loan Request for View/Approve");                
            }
            else if (id.currentTarget.id == "reject") {
                 mode = "reject";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if(id)
                {
//                if(ret.statusdesc!="New"){
//                    alert("Selected Loan Request already processed");
//                    return;
//                }
                clearLoanActivityLabels();
                fillLoanActivityData();
                document.getElementById("divLoanActivity").style.display = "";
                $("#signupsubmit").val("Reject");
                $('#divLoanActivity').dialog({
                    height: 380,
                    width: 580,
                    modal: true
                })
                }
                else alert("Select a Loan Request for Rejection");                
            }            
        });
        
        var validatorLoanRequest = $("#signupLoanActivityForm").validate({
            rules: {
                remarks:"required"
            },
            messages: {
                remarks:"Enter Remarks"
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            
            submitHandler: function() {           
            debugger 
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                if (mode == "movetohr") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    Request.LoanRequestID = ret.loanrequestid;
                    Request.ChangeBy=$("#hdnEmployeeID").val();
                    Request.Remarks=$("#remarks").val();
                    var Response = SendApplicationRequest('<%=LoanAppCommands.APPROVE_AND_FORWARD_TO_HR%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
                    alert(Response.Message);
                    if (Response.ResponseCommand == 'SUCCESS') { 
                    debugger
                        mode = "SUCCESS";
                        BindGrid(currPage);
//                        var Request1 = new Object();
//                        Request1.EmpID = $('#hdnEmployeeID').val();
//                        Response = SendApplicationRequest('<%=LoanAppCommands.REQUESTED_LOAN%>', Request1, true, '<%=RequestCommands.LOAN_REQUEST%>');
//                        if (Response.ResponseObject.datastr == null)
//                            jQuery("#list").jqGrid('clearGridData');
//                        else {
//                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
//                        jQuery("#list").jqGrid('setCaption', "LoanProcess").trigger('reloadGrid');
//                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
//                        }
                    }   
                }
                if (mode == "checkreport") {                
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    Request.LoanRequestID = ret.loanrequestid;
                    Request.ChangeBy=$("#hdnEmployeeID").val();
                    Request.Remarks=$("#remarks").val();
                    var Response="";
                    if(parseFloat(ret.maxamount)<parseFloat(ret.loanamount) && ret.status=='CHK')
                        Response = SendApplicationRequest('<%=LoanAppCommands.CHECK_REPORT_COO%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
                    else
                        Response = SendApplicationRequest('<%=LoanAppCommands.CHECK_REPORT_HOD%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
                    alert(Response.Message);
                    if (Response.ResponseCommand == 'SUCCESS') { 
                        mode = "SUCCESS";
                        var Request1 = new Object();
                        Request1.EmpID = $('#hdnEmployeeID').val();
                        Response = SendApplicationRequest('<%=LoanAppCommands.REQUESTED_LOAN%>', Request1, true, '<%=RequestCommands.LOAN_REQUEST%>');
                        if (Response.ResponseObject.datastr == null)
                            jQuery("#list").jqGrid('clearGridData');
                        else {
                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                        jQuery("#list").jqGrid('setCaption', "LoanProcess").trigger('reloadGrid');
                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                        }
                    }                
                }
                if (mode == "movetofinance") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    Request.LoanRequestID = ret.loanrequestid;
                    Request.ChangeBy=$("#hdnEmployeeID").val();
                    Request.Remarks=$("#remarks").val();
                    var Response = SendApplicationRequest('<%=LoanAppCommands.APPROVE_AND_FORWARD_TO_FINANCE%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
                    alert(Response.Message);
                    if (Response.ResponseCommand == 'SUCCESS') { 
                        mode = "SUCCESS";
                        var Request1 = new Object();
                        Request1.EmpID = $('#hdnEmployeeID').val();
                        Response = SendApplicationRequest('<%=LoanAppCommands.REQUESTED_LOAN%>', Request1, true, '<%=RequestCommands.LOAN_REQUEST%>');
                        if (Response.ResponseObject.datastr == null)
                            jQuery("#list").jqGrid('clearGridData');
                        else {
                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                        jQuery("#list").jqGrid('setCaption', "LoanProcess").trigger('reloadGrid');
                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                        }
                    }                
                }
                
                if (mode == "approvenclose") {
                
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    Request.LoanRequestID = ret.loanrequestid;
                    Request.ChangeBy=$("#hdnEmployeeID").val();
                    Request.Remarks=$("#remarks").val();
                    //Start loan date validation 
                    if($("#loanstartdate").val()=="") { alert("Enter loan start date"); return;}
                    var Req=new Object();
                    Req.LoanStartDate=$("#loanstartdate").val();
                    Req.LoanRequestID=ret.loanrequestid;
                    var Resp = SendApplicationRequest('<%=LoanAppCommands.CHECK_LOAN_START_DATE%>', Req, true, '<%=RequestCommands.LOAN_REQUEST%>');
                    if (Resp.ResponseCommand != 'SUCCESS') { 
                        alert(Resp.Message); return;
                    }
                    // End of Validati9on
                    Request.LoanStartOn = $("#loanstartdate").val();
                    var Response = SendApplicationRequest('<%=LoanAppCommands.PASS_LOAN_REQUEST%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
                    alert(Response.Message);
                    if (Response.ResponseCommand == 'SUCCESS') { 
                        mode = "SUCCESS";
                        var Request1 = new Object();
                        Request1.EmpID = $('#hdnEmployeeID').val();
                        Response = SendApplicationRequest('<%=LoanAppCommands.REQUESTED_LOAN%>', Request1, true, '<%=RequestCommands.LOAN_REQUEST%>');
                        if (Response.ResponseObject.datastr == null)
                            jQuery("#list").jqGrid('clearGridData');
                        else {
                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                        jQuery("#list").jqGrid('setCaption', "LoanProcess").trigger('reloadGrid');
                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                        }                        
                    }             
                }
                
                if (mode == "reject") {
                
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    Request.LoanRequestID = ret.loanrequestid;
                    Request.ChangeBy=$("#hdnEmployeeID").val();
                    Request.Remarks=$("#remarks").val();
                    var Response = SendApplicationRequest('<%=LoanAppCommands.REJECT_LOAN_REQUEST%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
                    alert(Response.Message);
                    if (Response.ResponseCommand == 'SUCCESS') { 
                        mode = "SUCCESS";
                        var Request1 = new Object();
                        Request1.EmpID = $('#hdnEmployeeID').val();
                        Response = SendApplicationRequest('<%=LoanAppCommands.REQUESTED_LOAN%>', Request1, true, '<%=RequestCommands.LOAN_REQUEST%>');
                        if (Response.ResponseObject.datastr == null)
                            jQuery("#list").jqGrid('clearGridData');
                        else {
                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                        jQuery("#list").jqGrid('setCaption', "LoanProcess").trigger('reloadGrid');
                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                        }
                    }                
                }
                onCancel();
                document.getElementById("trloanstart").style.display = "none";
           }
        });
    });
    function BindGrid(pageNumber) {
        var Request = new Object();
        Request.EmpID = $('#hdnEmployeeID').val();
        if ($("#newdata").is(':checked')) {
            $("#signupsubmit").show();
            var Response = SendApplicationRequest('<%=LoanAppCommands.REQUESTED_LOAN%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
            //activeStatus = true;
        }
        else {
            $("#signupsubmit").hide();
            var Response = SendApplicationRequest('<%=LoanAppCommands.PROCESSED_LOAN%>', Request, true, '<%=RequestCommands.LOAN_REQUEST%>');
            //activeStatus = false;
        }
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setCaption', "Loan Request Details").trigger('reloadGrid');
            jQuery("#list").jqGrid('setGridParam', { page: pageNumber }).trigger('reloadGrid');
        }
        //GridActiveButton();
    }
    function onCancel() {
        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        $("#divLoanActivity").dialog('close');
    }
    
    function fillLoanActivityData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#lblEmpName").text(ret.empname);
        $("#lblEmpCode").text(ret.empcode);
        $("#lblLoanName").text(ret.loanname);
        $("#lblrequestedAmount").text(ret.loanamount);
        $("#lblInterest").text(ret.interest);
        $("#lblRepaymentMonth").text(ret.repaymentmonths);
        $("#lblCurrentStatus").text(ret.status);
        $("#lblReason").text(ret.reason);
        $("#preComment").html(ret.preComment);
    }
    
    function clearLoanActivityLabels() {
        $("#lblEmpName").text("");
        $("#lblEmpCode").text("");
        $("#lblLoanName").text("");
        $("#lblrequestedAmount").text("");
        $("#lblInterest").text("");
        $("#lblRepaymentMonth").text("");
        $("#lblCurrentStatus").text("");
        $("#lblReason").text("");
        $("#preComment").html("");
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
</script>

<script type="text/javascript">
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('#t_list').css('background', 'none');
        $('#t_list').css('background-color', '#fff');
        $('#t_list').css('padding', '10px 0px');
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
