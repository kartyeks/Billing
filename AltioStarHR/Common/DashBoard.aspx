<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="AltioStarHR.Common.DashBoard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=EDGE" />
    <link href="Resources/css/hrStyle.css" rel="stylesheet" type="text/css" />
    <%--
    <link href="Resources/css/ddsmoothmenu.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" href="Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link href="Resources/css/menu_style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .Monthholid
        {
        	    font-family: Arial;
             font-size: 10px;
        }
        
        table .table1
        {
            border-collapse: collapse;
            width: 400px;
            text-align: center;
             font-family: Arial;
             font-size: 12px;
        }
       .table1 td
        {
            width: 10%;
            border: solid 1px;
             font-family: Arial;
             font-size: 12px;
        }
        .table1 tr td
        {
              height: 15px;
           background-color:#a4cd0f;
             font-family: Arial;
             font-size: 12px;
        }
        .table1 th
        {
            border: black solid 1px;
            background-color: #03DBF4;
             font-family: Arial;
             font-size: 12px;
        }
        .bankerScroll
        {
            display: block;
            overflow: auto;
            /*overflow-y:scroll;*/
            
            height: 80px;
            width:5%;
            white-space: nowrap;
             font-family: Arial;
             font-size: 12px;
        }
        .bankerScrollCNT
        {
            display: block;
         overflow: auto;
          /*overflow-y:scroll;*/
            height: 100px;
            width:1000px;
            white-space: nowrap;
             font-family: Arial;
             font-size: 12px;
        }
        .table1 thead tr th
        {
        	width:100%;
        	padding:10px;

        }
        .table1 tbody
        {
            text-align: center;
            font-family: Arial;
             font-size: 12px;
            color: #666;
            /*background-color: #CEEBFB;*/            
           /* text-shadow: 1px 1px 1px #fff;*/
        }
        .dashlabel
        {
            font-family: Arial;
            font-size: 13px;
            padding: 5px;
            width:0.01%;
            color: white;
            font-weight: bold;
            text-shadow: 1px 1px 1px #FF7F0D;
            border: 1px solid #FF7F0D;
            /*border-bottom: 3px solid #FF7F0D;*/
            background-color: #FF7F0D;
        }

        .style1
        {
            width: 10%;
        }

    </style>
</head>
<body onload="return window_onload()" thispage="DashBoard.aspx">
    <form id="form1" runat="server">
 
    <div id="divDashboard" style="background-image: url('<%= ResolveUrl("~/Resources/Images/NewImages/dashboard_bg.jpg") %>');text-align: center; width: 100%;height:100%">
        <div id="EmployeeDashBoard" >
            <table style="width: 80%; margin-top: 2%" align="center">
                <tr>                   
                    <th class="table1 dashlabel">
                       Leave balance
                    </th>
                    <th class="style1">
                        <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                    </th>
                    <th  class="table1 dashlabel">
                      Leave request status
                    </th>
                </tr>
                <tr>
                    <td>
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr>
                                    <th class="style4">
                                        Leave type
                                    </th>
                                    <th class="style4">
                                        Total leave
                                    </th>
                                    <th class="style4">
                                        Used leave
                                    </th>
                                    <th class="style4">
                                        Balance leave
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="leaveoverview" >
                               
                            </tbody>
                        </table>
                    </td>
                    <td class="style1" >
                    </td>
                    <td id="Tdleavedetails" >
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr>
                                    <th class="style2">
                                        Requested to
                                    </th>
                                    <th class="style2">
                                        From date
                                    </th>
                                    <th class="style2">
                                        To date
                                    </th>
                                    <th class="style2">
                                        Leave count
                                    </th>
                                    <th class="style3">
                                        Status
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="leavedetails" >
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 50px">
                    </td>
                </tr>
                <tr>
                    <td class="dashlabel">
                        <label id="LblHolidayMonth"></label>
                    </td>
                    <td class="style1">
                    </td>
                    <td class="dashlabel">
                        <label >
                            Candidate referred status</label>
                    </td>
                </tr>
                <tr>
                    <td id="TdMonthholidayss">
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                              <thead>
                                <tr style="width:100%">
                                    <th style="width:500px">
                                        Day
                                    </th>
                                    <th style="width:500px">
                                        Festival day
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="Monthholidayss" class="Monthholid">
                                
                            </tbody>
                        </table>
                    </td>
                    <td class="style1">
                    </td>
                    <td id="TdCandidatereferredStatusDetails">
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr>
                                    <th class="style5">
                                        Candidate name
                                    </th>
                                    <th class="style5">
                                        Team name
                                    </th>
                                    <th class="style5">
                                        Manager name
                                    </th>
                                    <th class="style5">
                                        Status
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="CandidatereferredStatusDetails" class="CandidateReferredClass">
                             
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 50px">
                    </td>
                </tr>
                <tr>
                    <td class="dashlabel">
                        <label>
                            Attendance</label>
                    </td>
                    <td class="style1">
                    </td>
                    <td class="dashlabel">
                        <label>
                            Appraisal</label>
                    </td>
                </tr>
                <tr>
                    <td id="TdEmpAttendanceDetails">
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr>
                                    <th>
                                        Month
                                    </th>
                                    <th>
                                        Days in month
                                    </th>
                                    <th>
                                        Leave
                                    </th>
                                    <th>
                                        Days worked
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="EmpAttendanceDetails">
                             
                            </tbody>
                        </table>
                    </td>
                    <td class="style1">
                    </td>
                    <td id="TdEmployeeAppraisal">
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr>
                                    <th class="style5">
                                        Year
                                    </th>
                                    <th class="style5">
                                        Old designation
                                    </th>
                                    <th class="style5">
                                        New designation
                                    </th>
                                    <th class="style5">
                                        Old CTC
                                    </th>
                                    <th class="style5">
                                        New CTC
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="EmployeeAppraisal">
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <div id="HRManagerDashBoard" style="display:none;">
            <table style="width: 80%" align="center">
                <tr>
                    <td class="dashlabel">
                        <label>
                            Employee exit in last 3 months</label>
                    </td>
                    <td >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="dashlabel">
                        <label>
                            Current month leave status</label>
                    </td>
                </tr>
                <tr>
                    <td id="TdEmployeeExitinthreemonths">
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr>
                                    <th class="style4">
                                        Employee code
                                    </th>
                                    <th class="style4">
                                        Employee name
                                    </th>
                                    <th class="style4">
                                        Designation
                                    </th>
                                    <th class="style4">
                                        Team
                                    </th>
                                    <th class="style4">
                                        Type of exit
                                    </th>
                                    <th class="style4">
                                        Exit date
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="EmployeeExitinthreemonths">
                             
                            </tbody >
                        </table>
                    </td>
                    <td>
                    </td>
                    <td id="TdCurrentMonthLeaveStatus1">
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr>
                                    <th class="style2">
                                        Total leave requests
                                    </th>
                                    <th class="style2">
                                        No of leaves approved
                                    </th>
                                    <th class="style2">
                                        No of leaves rejected
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="CurrentMonthLeaveStatus1">
                                
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 50px">
                    </td>
                </tr>
                <tr>
                    <td class="dashlabel">
                        <label>
                            Candidate schedule for interview<br />
                            (Current month)</label>
                    </td>
                    <td>
                    </td>
                    <td class="dashlabel">
                        <label>
                            Number of candidates referred</label>
                    </td>
                </tr>
                <tr>
                    <td id="TdScheduledCandiateDetails">
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr>
                                    <th style="width:30px;" >
                                        Sl No
                                    </th>
                                    <th>
                                        Candidate name
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="ScheduledCandiateDetails">
                                
                            </tbody>
                        </table>
                    </td>
                    <td>
                    </td>
                    <td id="TdCandidatesReferred">
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr style="width:100%">
                                    <th style="width:334px">
                                        Consultant
                                    </th>
                                    <th style="width:333px">
                                        Referral
                                    </th>
                                    <th style="width:333px">
                                        HR
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="CandidatesReferred">
                               
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 50px">
                    </td>
                </tr>
                <tr>
                    <td class="dashlabel">
                        <label>
                            Offers issued in current month</label>
                    </td>
                    <td>
                    </td>
                    <td class="dashlabel">
                        <label id='lblholid'>
                            Holidays in january</label>
                    </td>
                </tr>
                <tr>
                    <td id="TdOfferLetterIssuedDetails">
                        <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr>
                                    <th class="style6">
                                        Candidate
                                    </th>
                                    <th class="style6">
                                        Joining date
                                    </th>
                                    <th class="style6">
                                        Designation
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="OfferLetterIssuedDetails">
                            </tbody>
                        </table>
                    </td>
                    <td>
                    </td>
                        <td id="TdMonthholidayss1">
                         <table class="table1 bankerScroll" style="width:100%;height:100px">
                            <thead>
                                <tr style="width:100%">
                                    <th style="width:500px">
                                        Day
                                    </th>
                                    <th style="width:500px">
                                        Festival day
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="Monthholidayss1">
                                
                            </tbody>
                        </table>
                   
                    </td>
                </tr>
            </table>
        </div>
        <div id="divConsultantDisplay" style="display:none;background-image: url('<%= ResolveUrl("~/Resources/Images/NewImages/dashboard_bg.gif") %>');height:285px;">
             <table style="width: 43%; margin-top: 2%" align="center">
                <tr>                   
                    <th class="dashlabel">
                        <label> Candidate referred status</label>
                    </th>
                </tr>
                <tr>
                    <td id="tblConsultantDisplay">
                        <table class="table1 bankerScrollCNT">
                            <thead>
                                <tr>
                                    <th class="style5">
                                        Candidate name
                                    </th>
                                    <th class="style5">
                                        Team name
                                    </th>
                                    <th class="style5">
                                        Manager name
                                    </th>
                                    <th class="style5">
                                        Status
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="ConsultatntReferredDisplay" class="CandidateReferredClass">
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div style="height: 100%; width: 100%; border: solid 1px black; display: none;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td valign="top">
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td id="fraRptTD" valign="top" width="99%" height="100%" style="border: solid 0px red;">
                                    <iframe id="fraRpt" src="APPRES.ashx/_blank.htm" onload="return fraRpt_onload();"
                                        style="background-color: Transparent; width: 100%; height: 100%;" frameborder="no"
                                        scrolling="yes" allowtransparency="true"></iframe>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <input type="hidden" id='hdnAppMenuItems' runat="server" />
    <input type="hidden" id='hdnAllMenuItems' runat="server" />
    <input type="hidden" id='hdnLoginInfo' runat="server" />
    <input type="hidden" id='hdnRoleID' runat="server" />
    <input type="hidden" id='hdnRole' runat="server" />
    <input type="hidden" id='hdnLoginType' runat="server" />
    <input type="hidden" id='hdnLoggedEmpID' runat="server" />
    <input type="hidden" id='hdnEmployeeID' runat="server" />
    <input type="hidden" id='hdnLoggedUserID' runat="server" />
    </form>
</body>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-1.6.2.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.core.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.custom.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/grid.locale-en.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.jqGrid.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Webutility.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/toolbar.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.widget.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.validate.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/ddsmoothmenu.js") %>"></script>

<%--<script type="text/javascript" src="Resources/js/ircaobjs2.js"></script>

<script type="text/javascript" src="Resources/js/js2rw2.js"></script>--%>

<script type="text/javascript">
    function InitializeComponents() {

        // fraRpt.frameElement.src = '../HR/DashboardReportViewer.aspx';


        try {
            setfraRptSize();
        } catch (e) { ; }
    }
    var CleanExit = false;
    function Open(page) {
        if (page == "Dashboard") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=DashBoard") %>';
        }
        else if (page == "Role") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=RoleMaster") %>';
        }
        else if (page == "Designation") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=Designation") %>';
        }
        else if (page == "Relation") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=Relation") %>';
        }
        else if (page == "Country") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=Master_Country") %>';
        }
        else if (page == "Consultant") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=ConsultantMaster") %>';
        }
        else if (page == "Locations") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=LocationMaster") %>';
        }
        else if (page == "Designation") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=Designation") %>';
        }
        else if (page == "Marital_Status") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=Master_Maritial_Status") %>';
        }
        else if (page == "Team") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=Team") %>';
        }
        else if (page == "Setting_Configuration") {
            location.href = '<%=ResolveUrl("~/default.aspx?serve=Setting_Configuration") %>';
        }
        else if (page = "Logout") {
            if (!confirm('Confirm Logout')) {
                return false;
            }
            CleanExit = true;
            top.location.href = "module91.axd/logoutuser";
        }
        else {
        }
    }
</script>

<%--fraRpt_onload--%>

<script type="text/javascript">
    function fraRpt_onload() {
        try {
            var fraRpt = document.getElementById("fraRpt");

            //            if (fraRpt.readyState == "complete" && fraRpt.src == "../HR/DashboardReportViewer.aspx") {
            //                // document.getElementById("trExCollapse").style.display = "";
            //            }
            setfraRptSize();
        } catch (e) { ; }
    }
</script>

<%--window_onload--%>

<script type="text/javascript">
    function window_onload() {
        try {

            setfraRptSize();

        } catch (e) { ; }
        $('#hdnRole', window.parent.document).val(($('#hdnRoleID').val() == '' ? '0' : $('#hdnRoleID').val()));
        $('#hdnRoleName', window.parent.document).val(($('#hdnRole').val() == '' ? 'Administrator' : $('#hdnRole').val()));
        $('#hdnLoginType', window.parent.document).val(($('#hdnLoginType').val() != 'CNT' ? 'EMP' : $('#hdnLoginType').val()));
        //  location.href = "HR/DashboardReportViewer.aspx";
    }
</script>

<%--init_setfraRptSize--%>

<script type="text/javascript">
    function init_setfraRptSize() { if (document.readyState == "complete") { try { setfraRptSize(); } catch (e) { ; } } };
   
</script>

<%--setfraRptSize--%>

<script type="text/javascript">
    function setfraRptSize() {
        try {
            //  if (window.event && window.event.type == 'load') {
            setTimeout('document.body.onresize=setfraRptSize', 10);
            // }
            var g = document.documentElement.clientWidth;
            fraRptTD.height = document.documentElement.clientHeight - 35;
            fraRptTD.width = ((g * 90) / 100);
        } catch (e) { ; }
    };
</script>

<script type="text/javascript">
    jQuery(document).ready(function() {

        if ($('#hdnLoginType').val() == 'EMP') {
            if ($('#hdnRole').val() == 'HR') {
                document.getElementById("EmployeeDashBoard").style.display = 'none';
                document.getElementById("HRManagerDashBoard").style.display = '';

            }
            else {
                document.getElementById("HRManagerDashBoard").style.display = 'none';
                document.getElementById("EmployeeDashBoard").style.display = '';

            }
            document.getElementById('divConsultantDisplay').style.display = "none";
        }
        else {
            document.getElementById("HRManagerDashBoard").style.display = 'none';
            document.getElementById('EmployeeDashBoard').style.display = "none";
            document.getElementById('divConsultantDisplay').style.display = "";

        }

        if ($('#hdnLoginType').val() == 'EMP') { 
            var request = new Object();
            request.ID = $("#hdnEmployeeID").val();

            var response = SendApplicationRequest('<%=DashboardAppCommands.GET_DASHBOARD_LEAVE_DETAILS%>', request, true);
            if (response.ResponseCommand == 'SUCCESS') {
                $("#leaveoverview").html(
                "<tr>" +
                "<td>" + response.ResponseObject[0]["LeaveType"] + "</td>" +
                "<td>" + response.ResponseObject[0]["TotalLeave"] + "</td>" +
                "<td>" + response.ResponseObject[0]["UsedLeave"] + "</td>" +
                "<td>" + response.ResponseObject[0]["BalanceLeave"] + "</td>" +
                "</tr>");

                var arr = response.ResponseObject;
                var HtmlText = "";
                for (var i = 0; i < arr.length; ++i) {
                    $("#leavedetails").html(
                    HtmlText = HtmlText + "<tr>" +
                    "<td>" + response.ResponseObject[i]["RequestedTo"] + "</td>" +
                    "<td>" + response.ResponseObject[i]["FromDate"] + "</td>" +
                    "<td>" + response.ResponseObject[i]["ToDate"] + "</td>" +
                    "<td>" + response.ResponseObject[i]["LeaveCount"] + "</td>" +
                    "<td>" + response.ResponseObject[i]["Status"] + "</td>" +
                    "</tr>");
                }
            }

            var request2 = new Object();
            request2.ID = $("#hdnLoggedEmpID").val();
            var ReceiveResponse2 = SendApplicationRequest('<%=DashboardAppCommands.LOGGED_EMP_ATTENDANCE%>', request2, true);
            var arr2 = ReceiveResponse2.ResponseObject;
            var HtmlText2 = "";
            if (ReceiveResponse2.ResponseCommand == 'SUCCESS') {
                for (var i = 0; i < arr2.length; ++i) {
                    $("#EmpAttendanceDetails").html(
                    HtmlText2 = HtmlText2 + "<tr>" +
                    "<td>" + arr2[i]["Month"] + "</td>" +
                    "<td>" + arr2[i]["MonthlyDays"] + "</td>" +
                    "<td>" + arr2[i]["LeaveCount"] + "</td>" +
                    "<td>" + arr2[i]["WorkedDays"] + "</td>" +
                    "</tr>");
                }
            }
            else
            {
                var prevmnth = new Date().getMonth();
                var Previousmonth = GetMonthName(prevmnth);
                var TotalDays = GetMonthDays(prevmnth);
                
                $("#EmpAttendanceDetails").html(
                    HtmlText2 = HtmlText2 + "<tr>" +
                    "<td>" + Previousmonth + "</td>" +
                    "<td>" + TotalDays + "</td>" +
                    "<td>" + 0 + "</td>" +
                    "<td>" + TotalDays + "</td>" +
                    "</tr>");
            }

            var ReceiveResponse3 = SendApplicationRequest('<%=DashboardAppCommands.MONTHLY_OFFER_ISSUED%>', '', true);
            var arr3 = ReceiveResponse3.ResponseObject;
            var HtmlText3 = "";
            if (ReceiveResponse3.ResponseCommand == 'SUCCESS') {
                for (var i = 0; i < arr3.length; ++i) {
                    $("#OfferLetterIssuedDetails").html(
                    HtmlText3 = HtmlText3 + "<tr>" +
                    "<td>" + arr3[i]["Candidate"] + "</td>" +
                    "<td>" + arr3[i]["JoiningDate"] + "</td>" +
                    "<td>" + arr3[i]["Designation"] + "</td>" +
                    "</tr>");
                }
            }

            var ReceiveResponse4 = SendApplicationRequest('<%=DashboardAppCommands.MONTHLY_SCHEDULED_CANDIDATES%>', '', true);
            var arr4 = ReceiveResponse4.ResponseObject;
            var HtmlText4 = "";
            if (ReceiveResponse4.ResponseCommand == 'SUCCESS') {
                for (var i = 0; i < arr4.length; ++i) {
                    $("#ScheduledCandiateDetails").html(
                    HtmlText4 = HtmlText4 + "<tr>" +
                    "<td >" + arr4[i]["SlNo"] + "</td>" +
                    "<td>" + arr4[i]["CandidateName"] + "</td>" +
                    "</tr>");
                }
            }

            var request3 = new Object();
            request3.ID = $("#hdnLoggedUserID").val();
            var ReceiveResponse3 = SendApplicationRequest('<%=DashboardAppCommands.EMPLOYEE_APPRAISAL%>', request3, true);
            var arr3 = ReceiveResponse3.ResponseObject;
            var HtmlText3 = "";
            if (ReceiveResponse3.ResponseCommand == 'SUCCESS') {
                for (var i = 0; i < arr3.length; ++i) {
                    $("#EmployeeAppraisal").html(
                    HtmlText2 = HtmlText3 + "<tr>" +
                    "<td>" + ReceiveResponse3.ResponseObject[i]["Year"] + "</td>" +
                    "<td>" + ReceiveResponse3.ResponseObject[i]["OldDesignation"] + "</td>" +
                    "<td>" + ReceiveResponse3.ResponseObject[i]["NewDesignation"] + "</td>" +
                    "<td>" + ReceiveResponse3.ResponseObject[i]["OldCTC"] + "</td>" +
                    "<td>" + ReceiveResponse3.ResponseObject[i]["NewCTC"] + "</td>" +
                    "</tr>");
                }
            }
        }
        var request1 = new Object();

        request1.ID = $("#hdnLoggedUserID").val();
        var ReceiveResponse1 = SendApplicationRequest('<%=DashboardAppCommands.CANDIDATE_REFERRED_STATUS%>', request1, true);
        var arr1 = ReceiveResponse1.ResponseObject;
        var HtmlText1 = "";
        if (ReceiveResponse1.ResponseCommand == 'SUCCESS') {
            for (var i = 0; i < arr1.length; ++i) {
                $(".CandidateReferredClass").html(
                    HtmlText1 = HtmlText1 + "<tr>" +
                    "<td>" + ReceiveResponse1.ResponseObject[i]["CandidateName"] + "</td>" +
                    "<td>" + ReceiveResponse1.ResponseObject[i]["TeamName"] + "</td>" +
                    "<td>" + ReceiveResponse1.ResponseObject[i]["ManagerName"] + "</td>" +
                    "<td>" + ReceiveResponse1.ResponseObject[i]["Status"] + "</td>" +
                    "</tr>");
            }
        }


        var ReceiveResponse2 = SendApplicationRequest('<%=DashboardAppCommands.MONTHLY_HOLIDAYS%>', '', true);
        var arr2 = ReceiveResponse2.ResponseObject;
        var HtmlText2 = "";
        var d = new Date();
//        options = {
//            month: "long"
//        },
//        month = today.toDateString("en-GB", options).toUpperCase();
var monthNames = [ "January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December" ];
document.getElementById('LblHolidayMonth').innerHTML = "Holidays In " + monthNames[d.getMonth()];
document.getElementById('lblholid').innerHTML = "Holidays In " + monthNames[d.getMonth()];

        for (var i = 0; i < arr2.length; ++i) {
            $("#Monthholidayss ,#Monthholidayss1").html(
                    HtmlText2 = HtmlText2 + "<tr>" +
                    "<td>" + ReceiveResponse2.ResponseObject[i]["HolidayName"] + "</td>" +
                    "<td>" + ReceiveResponse2.ResponseObject[i]["HolidayDate"] + "</td>" +
                    "</tr>");
        }

        var ReceiveResponse4 = SendApplicationRequest('<%=DashboardAppCommands.EMPLOYEE_EXIT_IN_THREE_MONTHS%>', '', true);
        var arr4 = ReceiveResponse4.ResponseObject;
        var HtmlText4 = "";
        if (ReceiveResponse4.ResponseCommand == 'SUCCESS') {
            for (var i = 0; i < arr4.length; ++i) {
                $("#EmployeeExitinthreemonths").html(
                    HtmlText4 = HtmlText4 + "<tr>" +
                    "<td>" + ReceiveResponse4.ResponseObject[i]["EmployeeCode"] + "</td>" +
                    "<td>" + ReceiveResponse4.ResponseObject[i]["EmployeeName"] + "</td>" +
                    "<td>" + ReceiveResponse4.ResponseObject[i]["Designation"] + "</td>" +
                    "<td>" + ReceiveResponse4.ResponseObject[i]["Team"] + "</td>" +
                    "<td>" + ReceiveResponse4.ResponseObject[i]["TypeOfExit"] + "</td>" +
                    "<td>" + ReceiveResponse4.ResponseObject[i]["ExitDate"] + "</td>" +
                    "</tr>");
            }
        }
        var request5 = new Object();

        request5.ID = $("#hdnLoggedUserID").val();
        var ReceiveResponse5 = SendApplicationRequest('<%=DashboardAppCommands.CURRENT_MONTH_LEAVE_STATUS%>', request5, true);
        var arr5 = ReceiveResponse5.ResponseObject;
        var HtmlText5 = "";
        if (ReceiveResponse5.ResponseCommand == 'SUCCESS') {
            for (var i = 0; i < arr5.length; ++i) {
                $("#CurrentMonthLeaveStatus1").html(
                    HtmlText5 = HtmlText5 + "<tr>" +
                    "<td>" + ReceiveResponse5.ResponseObject[i]["LeaveRequest"] + "</td>" +
                    "<td>" + ReceiveResponse5.ResponseObject[i]["LeaveApproved"] + "</td>" +
                    "<td>" + ReceiveResponse5.ResponseObject[i]["LeaveRejected"] + "</td>" +
                    "</tr>");
            }
        }

        var ReceiveResponse6 = SendApplicationRequest('<%=DashboardAppCommands.CANDIDATE_REFERRED_COUNT%>', '', true);
        var arr6 = ReceiveResponse6.ResponseObject;
        var HtmlText6 = "";
        if (ReceiveResponse6.ResponseCommand == 'SUCCESS') {
            for (var i = 0; i < arr6.length; ++i) {
                $("#CandidatesReferred").html(
                    HtmlText6 = HtmlText6 + "<tr>" +
                    "<td>" + ReceiveResponse6.ResponseObject[i]["ConsultantCount"] + "</td>" +
                    "<td>" + ReceiveResponse6.ResponseObject[i]["EmpCount"] + "</td>" +
                    "<td>" + ReceiveResponse6.ResponseObject[i]["HRCount"] + "</td>" +
                    "</tr>");
            }
        }
    });
    
</script>
<script type="text/javascript">
    function GetMonthName(MnthNo)
    {
        if(MnthNo == 1)
            return "January";
        else if(MnthNo == 2)
            return "February";
        else if(MnthNo == 3)
            return "March";
        else if(MnthNo == 4)
            return "April";
        else if(MnthNo == 5)
            return "May";
        else if(MnthNo == 6)
            return "June";
        else if(MnthNo == 7)
            return "July";
        else if(MnthNo == 8)
            return "August";
        else if(MnthNo == 9)
            return "September";
        else if(MnthNo == 10)
            return "October";
        else if(MnthNo == 11)
            return "November";
        else if(MnthNo == 12)
            return "December";
    }
    
    function GetMonthDays(MnthNo)
    {
        if(MnthNo == 1 || MnthNo == 3 || MnthNo == 5 || MnthNo == 7 || MnthNo == 8 || MnthNo == 10 || MnthNo == 12)
            return 31;
        else if(MnthNo == 4 || MnthNo == 6 || MnthNo == 9 || MnthNo == 11)
            return 30;
        else if(MnthNo == 2)
        {
            if((getYear())%4 == 0)
                return 29;
            else 
                return 28;
        }
    }
</script>
</html>
