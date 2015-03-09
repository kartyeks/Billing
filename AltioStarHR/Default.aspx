<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <base target="_self" />
    <meta http-equiv="X-UA-Compatible" content="IE=EDGE" />
    <link href="Resources/css/hrStyle.css" rel="stylesheet" type="text/css" />
    <%--
    <link href="Resources/css/ddsmoothmenu.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" href="Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link href="Resources/css/menu_style.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
        label, input
        {
            display: block;
        }
        input.text
        {
            margin-bottom: 5px;
            width: 95%;
            padding: .4em; 
        }
        select.text
        {
            margin-bottom: 5px;
            width: 95%;
            padding: .4em;
        }
        fieldset
        {
            padding: 0;
            border: 0;
            margin-top: 25px;
        }
        div#users-contain
        {
            width: 350px;
            margin: 20px 0;
        }
        div#users-contain table
        {
            margin: 1em 0;
            border-collapse: collapse;
            width: 100%;
        }
        div#users-contain table td, div#users-contain table th
        {
            border: 1px solid #eee;
            padding: .6em 10px;
            text-align: left;
        }
        .ui-dialog .ui-state-error
        {
            padding: .3em;
        }
        .validateTips
        {
            border: 1px solid transparent;
            padding: 0.3em;
        }
        body a
        {
            color: #000;
        }
        body a:hover
        {
            color: red;
            text-decoration: none;
        }
        #form1
        {
        	height:100%;
        }
    </style>
    <title>HR Cubes</title>

</head>
<body onload="return window_onload()" onbeforeunload="return window_onbeforeunload()" 
    onunload="return window_onunload()">
    <%--<form id="form2" runat="server" style="background-color:Black">--%>
    <div class="dvMain">
        <%--<div id="dvBanner" class="dvBanner" style="width: 960px" >
        </div>--%>
        <div id="dvBanner" class="dvBanner" style="width: 0px;display:none" >
        </div>
        <div id="head">
            <div id="banners"  style="position:relative; padding:0%;">
                <img alt="" src="Resources/Images/NewImages/inside_pg_header.jpg" style="width:100%;height:10%;"/>  
            </div>
            <div class="dvMenu">
            <table id="tblrowMenu" runat="server"  style="width:100%;height:100%">
                <tr>
                    <td id="rowMenu" style="visibility: hidden; text-align: left;">
                        <div id="topnavigation">
                            <div id="navigation">
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <div id="menu_zone" class="logname" style="background-color:#a4cd0f">
                <table style="width:100%">
                    <tr>
                        <td style="text-align: left;width:25%">
                            <span style="color:#29295B">
                                <% =( IS91.Services.Common.GetProductName() + " v" + IS91.Services.Common.GetAppVersion() )%>
                            </span>
                        </td>
                        <td id='tdlblLoginInfo' style="text-align: center;width:50%">
                            <b><span id='lblLoginInfo' runat="server"></span></b>
                        </td>
                        <%--<td id='tdchangepwd' style="padding-right: 10px;display:none;width=25%" >
                            <a href="#" onclick="return onChangePwd()" id="spChngPwd" style="display: none;" runat="server">Change
                                Password</a>
                        </td>--%>
                        <%--<td style="padding-right: 10px;" width="25%;">
                            <span>
                                <% =(DateTime.Now.ToString("dddd, MMMM dd, yyyy"))%>
                            </span>
                        </td>--%>
                        <td style="text-align: right;width:25%">
                            <span style="color:#29295B">
                                <% =(DateTime.Now.ToString("dddd, MMMM dd, yyyy"))%>
                            </span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        </div>
        <div id="dvContent" class="dvContent">
            <div id="ChildWBDiv" class="dvIFrame">
                <iframe id="ChildWB" src="default.aspx?serve=LoginHR" 
                    style="background-color: Transparent;width:99%"; frameborder="no" allowtransparency="true"
                    hidefocus="hidefocus"></iframe>
            </div>
        </div>
    </div>
    <input id="hdnUserid" type="hidden" runat="server" />
    <input id="hdnRole" type="hidden" runat="server" />
    <input id="hdnRoleName" type="hidden" runat="server" />
    <input id="hdnMenuItem" type="hidden" runat="server" />
    <input id="hdnEmployeeID" type="hidden" runat="server" />
    <input id="hdnPage" type="hidden" runat="server" />
    <input id="hdnStatus" type="hidden" runat="server" />
      <input id="Hidden1" type="hidden" runat="server" />
        <input id="hdnLoginName" type="hidden" runat="server" />
        <input id='hdnLoginType' runat="server" type="hidden" />
    <%--</form>--%>
</body>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-1.6.2.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.core.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.custom.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/grid.locale-en.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.jqGrid.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Webutility.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/toolbar.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.widget.js") %>"></script>

<script type="text/javascript"  src="<%=ResolveUrl("~/Resources/js/jquery.validate.js") %>"></script>

<script type="text/javascript" src=" <%=ResolveUrl("~/Resources/js/ddsmoothmenu.js") %>"></script>

<%--ddsmoothmenu.init

<script type="text/javascript">

    ddsmoothmenu.init({
        mainmenuid: "dropDownMenu",
        orientation: 'h',
        classname: 'ddsmoothmenu',

        contentsource: "markup"
    });
        

</script>--%>
<%--
    <script type="text/javascript" src="APPRES.ashx/<% = IS91.Services.Web._PageMaster.MyAppResid %>/js2rw1.js"></script>

--%>
 
<%--    
<script type="text/javascript" src="Resources/js/ircaobjs2.js"></script>

<script type="text/javascript" src="Resources/js/js2rw2.js"></script>--%>
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


    function menuLoad() {

        try {
            var Request = new Object();
            Request.RoleID = $('#hdnRole').val();
            Request.Role = $('#hdnRoleName').val();
            
            var Response = SendApplicationRequest("<%=HRAppCommands.GET_MENUSTRING%>", Request, true);
            if (Response.ResponseCommand == 'SUCCESS') {
                $('#navigation').html('');
                $('#navigation').html(Response.ResponseObject);
            }
            if ($('#hdnLoginType').val() == "CNT") {
                document.getElementById("tdchangepwd").style.display = "";   
            }
        }
        catch (e) {
        }


    }
    $(function() {

        //menuLoad();
    });
</script>

<%--


<script type="text/javascript" src="Resources/js/auxilary.js"></script>--%>
<%--iframe_onload--%>

<script type="text/javascript">
    var CleanExit = false;
    $('#ChildWB').load(function() { 
        var allheight = document.documentElement.clientHeight;
        var imgmenuheight = document.getElementById('head').clientHeight;
        var reduce = allheight - imgmenuheight - 55;
        //        this.style.height = he + 'px';

        try {
            if (document.getElementById('ChildWB').PMenuDiv) {

                $("#head").show();
                //                $("#ChildWB").attr("height", "320px");
                if (mainMenu.innerHTML == '') {
                    mainMenu.innerHTML = document.getElementById('ChildWB').PMenuDiv.innerHTML;
                    if (tblMenu.style.display == 'none') {
                        tblMenu.style.display = '';
                    }
                }
                loginId = ChildWB.document.all.hdnPermission.value;
                IsSysAdmin = ChildWB.document.all.hdnIsSysAdmin.value;

            } //else{ iframe_onunload(); };
            else {
                //                $(window).height() + "px"
                $("#head").hide();
                $("#ChildWB").attr("height", reduce);
            }
        } catch (e) { ; }

        if (!isStartUpPage()) {
            document.getElementById("rowMenu").style.visibility = "visible";
            // document.getElementById("lblLoginInfo").style.visibility = "visible";
            menuLoad();
            $('#spChngPwd').css('display', '');
            $('#spChngPwd').css('color', '#FF0000');
            //spChngPwd.style.color = "#FF0000";  //"#361470";   //"#4e7114";
            if (document.getElementById("hdnStatus") && document.getElementById("hdnStatus").value == "") {
                //$('#ChildWB').contents().find('body').attr('ThisPage')
                if ($('#ChildWB').contents().find('#hdnLoginInfo').length > 0 &&
                    $('#ChildWB').contents().find('#hdnLoginInfo').val() != "") {

                    var str = "Welcome ";
                    var result = str.bold();

                    $('#lblLoginInfo').html(result + $('#ChildWB').contents().find('#hdnLoginInfo').val());
                    document.getElementById("hdnStatus").value = "true";

                }
                if ($('#ChildWB').contents().find('#hdnAppMenuItems').length > 0 &&
                    $('#ChildWB').contents().find('#hdnAppMenuItems').val() != "") {

                    onLoadMenu();
                }
            }
            $("#head").show();
            $("#ChildWB").attr("height", reduce);
        }
        else {
            $("#head").hide();
            $("#ChildWB").attr("height", reduce);
        }

        //setMainDocSize();
    });
    
</script>

<%--onLoadMenu--%>

<script type="text/javascript">
    function onLoadMenu() {

        //$('#ChildWB').load(function() {
        var MenuItemsval = $('#ChildWB').contents().find('hdnAppMenuItems');

        if (MenuItemsval.length > 0)
            document.getElementById("hdnMenuItem").value = $(MenuItemsval).val();

        if (document.getElementById("hdnMenuItem").value != "") {
            var mainids = document.getElementById("hdnMenuItem").value.split(",");
            if (mainids.length > 0) {
                for (k = 0; k < mainids.length; k++) {
                    document.getElementById(mainids[k]).style.display = "none";
                }
            }

        }
        //
        //menuLoad();
        //});
    }

</script>

<%--window_onload--%>

<script type="text/javascript">

    function window_onload() {
        //$('#ChildWB').load(function() {
        try {
            var allheight = document.documentElement.clientHeight;
            var imgmenuheight = document.getElementById('head').clientHeight;
            var reduce = allheight - imgmenuheight - 55;
            moveTo(0, 0);
            //resizeTo(screen.availWidth, screen.availHeight);


            //MainDiv.style.paddingLeft = padVal;
            //MainDiv.style.paddingRight = padVal;

            //setMainDocSize();
            //var scrWidth = screen.width;
            //var padVal = (scrWidth - 1000) / 2;

            //alert(MainDiv.style.paddingLeft);
            //});
        }
        catch (e) { }

    }
    
  
</script>

<%--setMainDocSize--%>

<script type="text/javascript">
    function setMainDocSize() {
        //$('#ChildWB').load(function() {
        try {
            var maxHeight = Math.max(document.documentElement.clientHeight, document.documentElement.offsetHeight, document.documentElement.style.pixelHeight);
            f = maxHeight;
            MainDiv.style.height = f;
            var mh = MainDiv.clientHeight;
            MainDiv1.style.height = mh - BannerDiv.offsetHeight - mainMenu.offsetHeight;
            ChildWBDiv.style.height = MainDiv1.style.pixelHeight - mainMenu.offsetHeight - 10;
            var frame = document.getElementById("ChildWB");
            frame.style.height = MainDiv1.style.pixelHeight - mainMenu.offsetHeight - 10;
        }
        catch (e) { ; }
        //});
    }
</script>

<%--LogOut

<script type="text/javascript">
    function LogOut() {
        if (!confirm('Confirm LogOut')) return false;
        CleanExit = true;
        location.href = "module91.axd/logoutuser";
    }
</script>--%>

<%--window_onbeforeunload--%>

<script type="text/javascript">
    var recurnt = false;

    function window_onbeforeunload() { 
    
        if (CleanExit || recurnt
            || (document.getElementById('ChildWB').document && document.getElementById('ChildWB').document.body &&
             (document.getElementById('ChildWB').document.body.ThisPage + '') == 'LoginHR.aspx')
        ) 
        {
            return;
        }

        return 'This action will log you out from the server. Do you want to continue?';
    }
</script>

<%--window_onunload--%>

<script type="text/javascript">
    function window_onunload() {
       
        var allheight = document.documentElement.clientHeight;
        var imgmenuheight = document.getElementById('head').clientHeight;
        var reduce = allheight - imgmenuheight - 55;
        recurnt = true;
        if (!CleanExit) {
            if (isStartUpPage()) {
                CleanExit = true;
            }
        }

        if (!CleanExit) {
            location.href = "module91.axd/logoutuser";
            return;
        }
    }
</script>

<%--isStartUpPage--%>

<script type="text/javascript">
    function isStartUpPage() {
        //$('#ChildWB').load(function() {
        if ($('#ChildWB').contents().find('body').length > 0 &&
            ($('#ChildWB').contents().find('body').attr('ThisPage') == 'LoginHR.aspx')) {
            return true;
        }
        return false;
        //});
    }
</script>

<%--Menu_onClick--%>

<script type="text/javascript">
    function Menu_onClick(menuItemId, menuItem) {
    
        // var empid = document.getElementById("hdnEmployeeID").value;

        //  menuLoad();

        var place = (document.getElementById('ChildWB').frameElement) ?
            document.getElementById('ChildWB').frameElement :
            document.getElementById('ChildWB').contentWindow.frameElement;

        if (menuItemId != "li_Dashboard") {
            //$('#dvBanner').css('display', 'none');
           
            
                
//            $('#ChildWB').css('height', '600px');
        }
        else {
            //$('#dvBanner').css('display', '');


//            $('#ChildWB').css('height', '600px');

        }
        switch (menuItemId) {
            case "li_Dashboard":
                {
                    //                    place.src = "default.aspx?serve=DashboardReportViewer";
                    place.src = "default.aspx?serve=DashBoard";
                    break;
                }
            case "li_Employee_View_SelfInformation":
                {
                    place.src = "default.aspx?serve=Master_Employee&Type=self";
                    break;
                }  
            case "li_Employee_View_View Employees":
                {
                    place.src = "default.aspx?serve=Master_EmployeeSummary";//Master_Employee";
                    break;
                }
            case "li_Setup_Organisation Hierarchy_Designation":
                {
                    place.src = "default.aspx?serve=Designation";
                    break;
                }
            case "li_Setup_Grade":
                {
                    place.src = "default.aspx?serve=Grade";
                    break;
                }
            case "li_Setup_Zone":
                {
                    place.src = "default.aspx?serve=Zone";
                    break;
                }
            case "li_Setup_CompanyInfo_InvestmentGroup":
              {
                    place.src = "default.aspx?serve=InvestmentGroup";
                    break;
                }
                
             case "li_Setup_CompanyInfo_CompanyMaster":
              {
                    place.src = "default.aspx?serve=CompanyMaster";
                    break;
              }
              
              case "li_Setup_ProjectInfo_ProjectDetails":
              {
                    place.src = "default.aspx?serve=ProjectInfo";
                    break;
              }
//            case "li_Setup_Department":
//                {
//                    place.src = "default.aspx?serve=Department";
//                    break;
//                }
            case "li_Setup_Role Permissions":
                {
                    place.src = "default.aspx?serve=RoleMaster";
                    break;
                }
            case "li_Setup_Social Status_Relation":
                {
                    place.src = "default.aspx?serve=Relation";
                    break;
                }

            case "li_Setup_Organisation Hierarchy_Team":
                {
                    place.src = "default.aspx?serve=Team";
                    break;
                }
                
            case "li_Recruitment_InterviewType":
                {
                    place.src = "default.aspx?serve=InterviewType";
                    break;
                }
            case "li_Recruitment_InterviewRounds":
                {
                    place.src = "default.aspx?serve=InterviewRounds";
                    break;
                }
            case "li_Recruitment_JobProfile":
                {
                    place.src = "default.aspx?serve=JobProfile";
                    break;
                }
            case "li_Setup_Recruitment_Jobprofile_Approval":
                {
                    place.src = "default.aspx?serve=JobProfile";
                    break;
                }
            case "li_Employees_Grievance_GrievanceType":
                {
                    place.src = "default.aspx?serve=GriveanceType";
                    break;
                }
            case "li_Employee_Loan_Loan":
               {
                    place.src = "default.aspx?serve=Loan";
                    break;
                }
            case "li_Employee_Loan_LoanAdvanceType":
                {
                    place.src = "default.aspx?serve=AdvanceType";
                    break;
                }
            case "li_Employee_Loan_LoanManagement":
                {
                    place.src = "default.aspx?serve=LoanManagement";
                    break;
                }
                case "li_Employee_Loan_LoanProcess":
                {
                    place.src = "default.aspx?serve=LoanProcess";
                    break;
                }
            case "li_Setup_NonDiscpAct":
                {
                    place.src = "default.aspx?serve=NonDisciplinaryActivity";
                    break;
                }
            case "li_Setup_Incidents_IncidentType":
                {
                    place.src = "default.aspx?serve=IncidentTypes";
                    break;
                }
            case "li_Setup_Incidents_IncidentCompeType":
                {
                    place.src = "default.aspx?serve=IncidentCompensationTypes";
                    break;
                }
            case "li_Setup_Incidents_IncidentMitgType":
                {
                    place.src = "default.aspx?serve=IncidentMitigationTypes";
                    break;
                }
            case "li_Setup_EmployeeNotification":
                {
                    place.src = "default.aspx?serve=EmployeeNotification";
                    break;
                }
            case "li_Employees_Grievance_Grievance":
                {
                    place.src = "default.aspx?serve=Griveance";
                    break;
                }
            case "li_Employees_Grievance_GrievanceList":
                {
                    place.src = "default.aspx?serve=GriveanceList";
                    break;
                }
            case "li_Recruitment_CandidateNew":
                {
                    place.src = "default.aspx?serve=CandidateApplicationInfo";
                    break;
                }
            case "li_Recruitment_CandidateSummary":
                {
                    place.src = "default.aspx?serve=CandidateSummary";
                    break;
                }
            case "li_Recruitment_CandidateMDSummary":
                {
                    place.src = "default.aspx?serve=CandidateSummary&Emp=MD";
                    break;
                }
            case "li_Recruitment_CandidateCOOSummary":
                {
                    place.src = "default.aspx?serve=CandidateSummary&Emp=COO";
                    break;
                }
            case "li_Recruitment_InterviewSchedule_RefCheck":
                {
                    place.src = "default.aspx?serve=InterviewSchedule";
                    break;
                }
            case "li_Setup_Locations_LocationType":
                {
                    place.src = "default.aspx?serve=LocationType";
                    break;
                }
            case "li_Setup_Geographic Location_Locations":
                {
                    place.src = "default.aspx?serve=LocationMaster";
                    break;
                }
            case "li_Employees_Employees":
                {
                    // if(empid=="1")
                    place.src = "default.aspx?serve=Employees";
                    //                       else
                    //                           place.src = "default.aspx?serve=EmployeeInformation&type=self&employeeid=" + empid;

                    break;
                }
            case "li_Employees_SelfInformation":
                {
                    place.src = "default.aspx?serve=EmployeeInformation&Type=self";
                    break;
                }
            case "li_Employees_EmployeeBirthday":
                {
                    place.src = "default.aspx?serve=EmployeeBirthday";
                    break;
                }
            case "li_Setup_Shifts":
                {
                    place.src = "default.aspx?serve=ShiftCharges";
                    break;
                }
            case "li_Employees_Loan_Loan":
                {
                    place.src = "default.aspx?serve=Loan";
                    break;
                }
            case "li_Setup_Locations_Branchs":
                {
                    place.src = "default.aspx?serve=Branches";
                    break;
                }
            case "li_Setup_Insurance":
                {
                    place.src = "default.aspx?serve=Insurance";
                    break;
                }
            case "li_Policies_PolicyType":
                {
                    place.src = "default.aspx?serve=PolicyType";
                    break;
                }
            case "li_Employees_Reimbursment_ReimbursementType":
                {
                    place.src = "default.aspx?serve=ReimbursementType";
                    break;
                }
            case "li_Employees_Reimbursment_ReimbursementTypeGrade":
                {
                    place.src = "default.aspx?serve=ReimbursementTypeGrade";
                    break;
                }
            case "li_Employees_Reimbursment_ReimbursementManagement":
                {
                    place.src = "default.aspx?serve=ReimbursementManagement";
                    break;
                }
            case "li_Employees_Reimbursment_Reimbursement":
                {
                    place.src = "default.aspx?serve=Reimbursement";
                    break;
                }
            case "li_Employees_Reimbursment_ReimbursementView":
                {
                    place.src = "default.aspx?serve=ReimbursementView";
                    break;
                }
            case "li_Policies_Policy":
                {
                    place.src = "default.aspx?serve=Policy";
                    break;
                }
            case "li_Policies_Policyview":
                {
                    place.src = "default.aspx?serve=DownLoadPolicies"; //Policy";
                    break;
                }
            case "li_Recruitment_JobAgency":
                {
                    place.src = "default.aspx?serve=JobAgency";
                    break;
                }
            case "li_Setup_Asset":
                {
                    place.src = "default.aspx?serve=Asset";
                    break;
                }
            case "li_Recruitment_InterviewerScheduler":
                {
                    place.src = "default.aspx?serve=InterviewerScheduler";
                    break;
                }
            case "li_Employees_Loan_LoanGrade":
                {
                    place.src = "default.aspx?serve=Loan_Grade";
                    break;
                }
            case "li_Employees_Loan_LoanAdvanceType":
                {
                    place.src = "default.aspx?serve=AdvanceType";
                    break;
                }
            case "li_Employees_Loan_LoanManagement":
                {
                    place.src = "default.aspx?serve=LoanManagement";
                    break;
                }
            case "li_Employees_Leave_LeaveRequest":
                {
                    place.src = "default.aspx?serve=LeaveRequestPage";
                    break;
                }
            case "li_Employees_Leave_LeaveManagement":
                {
                    place.src = "default.aspx?serve=LeaveManagement";
                    break;
                }
            case "li_Employees_Leave_EmpLeaveManagement":
                {
                    place.src = "default.aspx?serve=EmpLeaveManagement";
                    break;
                }
            case "li_Employees_Leave_HolidayCalender":
                {
                    place.src = "default.aspx?serve=HolidayCalendar";
                    break;
                }
            case "li_Setup_Leaves_LeaveType":
                {
                    place.src = "default.aspx?serve=Leaves";
                    break;
                }
            case "li_Training_Course":
                {
                    place.src = "default.aspx?serve=Course";
                    break;
                }
            case "li_Training_Trainer":
                {
                    place.src = "default.aspx?serve=Trainers";
                    break;
                }
            case "li_Training_TrainingCalendar":
                {
                    place.src = "default.aspx?serve=Training_Calendar";
                    break;
                }
            case "li_Training_TrainingApprovals":
                {
                    place.src = "default.aspx?serve=TrainingApprovals";
                    break;
                }
            case "li_Training_EmpTrainingCalendar":
                {
                    place.src = "default.aspx?serve=EmployeeTrainingManagement";
                    break;
                }
            case "li_Employees_Leave_AssignLeave":
                {
                    place.src = "default.aspx?serve=Assign_Leave";
                    break;
                }
            case "li_Employees_Leave_Settings_Leave_Employee_Type":
                {
                    place.src = "default.aspx?serve=Settings_Leave_Employee_Type";
                    break;
                }
            case "li_Setup_Bank_Bank":
                {
                    place.src = "default.aspx?serve=Bank";
                    break;
                }
            case "li_Setup_Bank_BankBranch":
                {
                    place.src = "default.aspx?serve=BankBranch";
                    break;
                }
            case "li_Employee_EmployeeAttendance":
                {
                    place.src = "default.aspx?serve=EmployeeAttendance";
                    break;
                }

            case "li_Employees_Leave_Holidays":
                {
                    place.src = "default.aspx?serve=Holidays";
                    break;
                }
            case "li_Employees_Leave_Weekends":
                {
                    place.src = "default.aspx?serve=Weekend";
                    break;
                }
            case "li_Employees_Leave_Manual":
                {
                    place.src = "default.aspx?serve=ManualLeave";
                    break;
                }
            case "li_Employees_Leave_Bulk":
                {
                    place.src = "default.aspx?serve=BulkLeaveUpload";
                    break;
                }
            case "li_Employees_Payroll_monthlypayroll":
                {
                    place.src = "default.aspx?serve=Payroll";
                    break;
                }

            case "li_Employee_Overtime":
                {
                    place.src = "default.aspx?serve=EmployeeOvertime";
                    break;
                }
            case "li_Employees_Payroll_PayrollConfiguration":
                {
                    place.src = "default.aspx?serve=PayrollConfiguration";
                    break;
                }
            case "li_Employees_Payroll_AnnualAdditions":
                {
                    place.src = "default.aspx?serve=AnnualAdditions";
                    break;
                }
            case "li_Employee_Payroll_SalryAllowances":
                {
                    place.src = "default.aspx?serve=SalaryAllowances";
                    break;
                }
            case "li_Employees_Payroll_UploadSalryAllowances":
                {
                    place.src = "default.aspx?serve=DataUpload";
                    break;
                }
            case "li_Employees_Payroll_GradeSalry":
                {
                    place.src = "default.aspx?serve=GradeSalary";
                    break;
                }
            case "li_Employee_Payroll_SalryDeductions":
                {
                    place.src = "default.aspx?serve=SalaryDeductions";
                    break;
                }
            case "li_Employees_Payroll_GradeAllowances":
                {
                    place.src = "default.aspx?serve=GradeAllowances";
                    break;
                }
            case "li_Employees_Payroll_TaxExcemtionGroup":
                {
                    place.src = "default.aspx?serve=TaxExcemptionGroup";
                    break;
                }
            case "li_Employees_Payroll_TaxExemption":
                {
                    place.src = "default.aspx?serve=TaxExemption";
                    break;
                }
            case "li_Employees_Payroll_mTax":
                {
                    place.src = "default.aspx?serve=mTax";
                    break;
                }
            case "li_Employees_Payroll_EmpTaxDeclaration":
                {
                    place.src = "default.aspx?serve=EmployeeTaxDeclaration";
                    break;
                }
            case "li_Reports_Reimbursment_ReimbursmentStausReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Reimbursment Status Report&perm=aedv&rtype=rdlcReimbursmentStatusReport";
                    break;
                }
            case "li_Reports_Reimbursment_ReimbursmentDetailsReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Reimbursment Details Report&perm=aedv&rtype=rdlcReimbursmentReport";
                    break;
                }

            case "li_Reports_Interview_CandidateInterviewScheduleByDate":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Interview Schedule &perm=aedv&rtype=rdlcScheduleCandidateByDate";
                    break;
                }
            case "li_Reports_Interview_CandidateInterviewScheduleByDateNInterviewType":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Interview Schedule &perm=aedv&rtype=rdlcScheduleCandidateByDateNInterviewType";
                    break;
                }
            case "li_Reports_Interview_CandidateInterviewResultScheduleByDateNInterviewType":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Interview Schedule With Result&perm=aedv&rtype=rdlcResultScheduleCandidateByDateNInterviewType";
                    break;
                }
            case "li_Reports_Interview_CandidateInterviewDetails":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Candidate Interview Details&perm=aedv&rtype=rdlcCandidateInterviewDetails";
                    break;
                }
            case "li_Reports_Interview_CandidateInterviewResult":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Candidate Interview Result Details&perm=aedv&rtype=rdlcCandidateInterviewResult";
                    break;
                }
            case "li_Reports_Interview_ScheduleTracker":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Candidate Interview Tracker&perm=aedv&rtype=rdlcScheduleInterviewTracker";
                    break;
                }
            case "li_Reports_Interview_ActivityReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Candidate Activity Report&perm=aedv&rtype=rdlcCandidateActivityRecord";
                    break;
                }
            case "li_Reports_Interview_CandidateDOJ":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Candidate Joining Date&perm=aedv&rtype=rdlcCandidateDOJ";
                    break;
                }
            case "li_Reports_Interview_ShortlistCandidateApplication":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Shortlisted Candidate Application Details&perm=aedv&rtype=rdlcShortlistCandidateApplicationReport";
                    break;
                }
            case "li_Reports_Interview_OfferLetterReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Candidate Offer Letter&perm=aedv&rtype=rdlcCandidateOfferLetterReport";
                    break;
                }
            case "li_Reports_Interview_AgencyReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Agency Report&perm=aedv&rtype=rdlcJobAgencyReport";
                    break;
                }
            case "li_Reports_Interview_VacancyReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Vacancy Report&perm=aedv&rtype=rdlcVacancyReport";
                    break;
                }
            case "li_Reports_Interview_CandidateApplication":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Candidate Application Details&perm=aedv&rtype=rdlcCandidateApplicationReport";
                    break;
                }
//            case "li_Reports_Employees_EmployeeDetailReport":
//                {
//                    place.src = "default.aspx?serve=KurlonReports&cap=Employee Detail Report&perm=aedv&rtype=rdlcEmployeeDetailsReport";
//                    break;
//                }
//            case "li_Reports_AllEmployees_EmployeeDetailReport":
//                {
//                    place.src = "default.aspx?serve=KurlonReports&cap=Employee Detail Report&perm=aedv&rtype=rdlcAllEmployeeDetailsReport";
//                    break;
//                }
            case "li_Reports_Employees_EmployeeInfoReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Employee Joining Report&perm=aedv&rtype=rdlcEmployeeJoining";
                    break;
                }
            case "li_Reports_Employee_ProgressionReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Employee Progression Report&perm=aedv&rtype=rdlcProgressionReport";
                    break;
                }

            case "li_Reports_Employees_EmployeeActivityReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Employee Joining Activity Report&perm=aedv&rtype=rdlcEmployeeActivity";
                    break;
                }
            case "li_Reports_Employees_EmployeeStatusReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap= Department Wise Employee Status Report&perm=aedv&mode=status&rtype=rdlcEmployeeDepartmentWise";
                    break;
                }
            case "li_Reports_Employees_EmployeeDesigReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap= Department Wise Employee Designation Report&perm=aedv&mode=designation&rtype=rdlcEmployeeDepartmentWise";
                    break;
                }
            case "li_Reports_Employees_EmployeeTypeReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap= Department Wise Employee Type Report&perm=aedv&mode=type&rtype=rdlcEmployeeDepartmentWise";
                    break;
                }
            case "li_Reports_Employees_EmployeeGradeReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap= Department Wise Employee Grade Report&perm=aedv&mode=grade&rtype=rdlcEmployeeDepartmentWise";
                    break;
                }
            case "li_Reports_Employees_ContractEmployeeReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap= Contract Employee Report&perm=aedv&mode=grade&rtype=rdlcContractEmployee";
                    break;
                }
            case "li_Reports_Employees_SalaryBandReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap= Department Wise Salary Band Report&perm=aedv&rtype=rdlcDepartmentWiseSalaryBandReport";
                    break;
                }
            case "li_Reports_Appraisal_AppraisalStatusReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Appraisal Status Report&perm=aedv&rtype=rdlcAppraisalStatusReport";
                    break;
                }
            case "li_Reports_Appraisal_DepartmentWiseAppraisalStatusReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Department Wise Appraisal Status Report&perm=aedv&rtype=rdlcDepartmentWiseAppraisalStatusReport";
                    break;
                }
            case "li_Reports_Appraisal_DepartmentWiseAppraisalStatusReportDetails":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Department Wise Appraisal Status Report Details&perm=aedv&rtype=rdlcDepartmentWiseAppraisalStatusReportDetails";
                    break;
                }
            case "li_Reports_Loan_LoanReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Loan Report&perm=aedv&rtype=rdlcLoanReportByDateNDepartmentWise";
                    break;
                }
            case "li_Reports_Loan_LoanRecovery":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Loan Recovery Report&perm=aedv&rtype=rdlcLoanRecoveryReport";
                    break;
                }
            case "li_Reports_Loan_LoanRequest":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Loan Request Report&perm=aedv&rtype=rdlcFullLoanRequestReport";
                    break;
                }
            case "li_Reports_Loan_FullLoanReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Full Loan Report&perm=aedv&rtype=rdlcLoanFullReportByDateNDepartmentWise";
                    break;
                }
            case "li_Reports_Policy_PolicyDetails":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Policy Details&perm=aedv&rtype=rdlcPolicyCreationReport";
                    break;
                }
            case "li_Reports_Leaves_LeaveRequestActivityReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Leave Request Activity Summary Report&perm=aedv&rtype=rdlcLeaveRequestActivityReport";
                    break;
                }
            case "li_Reports_Leaves_EmployeeLeaveActivityReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Employee Leave Activity Report&perm=aedv&rtype=rdlcEmployeeLeaveActivityReport";
                    break;
                }
            case "li_Reports_Leaves_EmployeeLeaveBalanceReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Leave Balance Report&perm=aedv&rtype=rdlcLeaveBalanceReport";
                    break;
                }
            case "li_Reports_Policy_PolicyMgmtStatus":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Policy Mgmt Status &perm=aedv&rtype=rdlcPolicyMgmtStatusReport";
                    break;
                }
            case "li_Reports_Policy_PolicyActivityReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Policy Activity &perm=aedv&rtype=rdlcPolicyActivityReport";
                    break;
                }
            case "li_Reports_Attendance_AttendanceReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Attendance Report &perm=aedv&rtype=rdlcAttendanceReport";
                    break;
                }
            case "li_Reports_Attendance_DetailedAttendanceReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Detailed Attendance Report &perm=aedv&rtype=rdlcDetailedAttendanceReport";
                    break;
                }
            case "li_Reports_Attendance_AttendanceLeaveReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Attendance Leave Report &perm=aedv&rtype=rdlcMonthlyAttendanceLeaveReport";
                    break;
                }
            case "li_Reports_Attendance_EntryExitReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Entry Exit Report &perm=aedv&rtype=rdlcEntryExitReport";
                    break;
                }
            case "li_Reports_Training_TrainingSchedule":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Training Schedule Report &perm=aedv&rtype=rdlcTrainingSchedule";
                    break;
                }
            case "li_Reports_Training_TrainingParticipation":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Training Participation Report &perm=aedv&rtype=rdlcTrainingParticipation";
                    break;
                }
            case "li_Reports_Training_TrainingFeedbackReport":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Training Feedback Report &perm=aedv&rtype=rdlcTrainingFeedbackReport";
                    break;
                }
            case "li_Reports_Training_TrainingEmployee":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Employee Training Report &perm=aedv&rtype=rdlcTrainingEmployee";
                    break;
                }
            case "li_Reports_Training_TrainingActivityDates":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Training Activity Dates Report &perm=aedv&rtype=rdlcTrainingActivityDates";
                    break;
                }
            case "li_Reports_Training_TrainingSummary":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Training Summary Report &perm=aedv&rtype=rdlcTrainingSummary";
                    break;
                }
            case "li_Reports_Grievance_GrievanceType":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Grievance Type Report &perm=aedv&rtype=rdlcGrievanceType";
                    break;
                }
            case "li_Reports_Payroll_Form16":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Form16 Report &perm=aedv&rtype=rdlcForm16";
                    break;
                }
            case "li_Reports_Payroll_Form16A":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Form16A Report &perm=aedv&rtype=rdlcForm16A";
                    break;
                }
            case "li_Reports_Payroll_OverTime":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Employee OverTime Report &perm=aedv&rtype=rdlcOverTime";
                    break;
                }
            case "li_Reports_Payroll_Gratuity":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Gratuity Calculation Report &perm=aedv&rtype=rdlcGratuity";
                    break;
                }
            case "li_Reports_Payroll_Annuation":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=SuperAnnuation Calculation Report &perm=aedv&rtype=rdlcSuperAnnuation";
                    break;
                }
            case "li_Reports_Payroll_HolidayList":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Holiday List Report &perm=aedv&rtype=rdlcHolidayListReport";
                    break;
                }
            case "li_Reports_Payroll_SalaryCertificate":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Salary Certificate&perm=aedv&rtype=rdlcSalaryCertificateReport";
                    break;
                }
            case "li_Reports_Payroll_PaySlip":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Pay Slip&perm=aedv&rtype=rdlcPaySlip";
                    break;
                }
            case "li_Reports_Payroll_EmployeeSalary":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Employee Salary&perm=aedv&rtype=rdlcEmployeeSalary";
                    break;
                }
            case "li_Reports_Payroll_ConsolidateSalary":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Consolidate Salary&perm=aedv&rtype=rdlcConsolidateSalary";
                    break;
                }
            case "li_Reports_Payroll_ESIStatement":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=ESI Statement&perm=aedv&rtype=rdlcESIStatement";
                    break;
                }
            case "li_Reports_Payroll_BankDeposit":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=Bank Deposit&perm=aedv&rtype=rdlcBankDeposit";
                    break;
                }
            case "li_Reports_Payroll_ESIMonthlyRemittance":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=ESI Monthly Remittance&perm=aedv&rtype=rdlcForm6";
                    break;
                }
            case "li_Reports_Payroll_Form3APFYearly":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=FORM 3 A (PF) Yearly&perm=aedv&rtype=rdlcForm3A";
                    break;
                }
            case "li_Reports_Payroll_FORM6HalfYearlyReturnsConsolidated":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=FORM-6(Half Yearly Returns) Consolidated&perm=aedv&rtype=rdlcESIHalfYearly";
                    break;
                }
            case "li_Reports_Payroll_FORM6APFYearly":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=FORM 6 A (PF) Yearly&perm=aedv&rtype=rdlcForm6A";
                    break;
                }
            case "li_Reports_Payroll_FORM6APFLastSheetYearly":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=FORM 6 A (PF) Last Sheet Yearly&perm=aedv&rtype=rdlcForm6ALASTSHEET";
                    break;
                }
            case "li_Reports_Payroll_FORM3AResignationTime":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=FORM 3 A Resignation Time&perm=aedv&rtype=rdlcForm3Aresignation";
                    break;
                }
            case "li_Reports_Payroll_FORM7":
                {
                    place.src = "default.aspx?serve=KurlonReports&cap=FORM 7&perm=aedv&rtype=rdlcForm7";
                    break;
                }

            case "li_Employees_Loan_SalaryAdvance":
                {
                    place.src = "default.aspx?serve=SalaryAdvance";
                    break;
                }

            case "li_Setup_SkillSet":
                {
                    place.src = "default.aspx?serve=SkillSet";
                    break;
                }
            case "li_Setup_Assign_Company_Bank":
            {
                place.src = "default.aspx?serve=Assign_Company_Bank";
                break;
            }
            case "li_Setup_EmployeeType":
            {
                place.src = "default.aspx?serve=EmployeeType";
                break;
            }
            case "li_Setup_Benifits Configuration":
            {
                place.src = "default.aspx?serve=Setting_Configuration";
                break;
            }
            case "li_Setup_Bonus":
            {
                place.src = "default.aspx?serve=Bonus";
                break;
            }
            case "li_Employees_Loan_LoanProcess":
            {
                place.src = "default.aspx?serve=LoanProcess";
                break;
            }

            case "li_Employees_Seperation_ResignationRequest":
            {
                place.src = "default.aspx?serve=EmployeeResignRequest";
                break;
            }
            case "li_Employees_Seperation_ResignationApproval":
            {
                place.src = "default.aspx?serve=ResignationApproval";
                break;
            }
            case "li_Employees_Seperation_SeperationManagement":
            {
                place.src = "default.aspx?serve=SeperationManagement";
                break;
            }
            case "li_Employees_Seperation_EmployeeTerminationRequest":
            {
                place.src = "default.aspx?serve=EmployeeTerminationRequest";
                break;
            }
            case "li_Employees_Seperation_TerminationManagement":
            {
                place.src = "default.aspx?serve=TerminationManagement";
                break;
            }

            case "li_Employees_Appraisals_AppraisalIntimation":
            {
                place.src = "default.aspx?serve=AppraisalIntimation";
                break;
            }
            case "li_Employees_Appraisals_SubmitAppraisal":
            {
                place.src = "default.aspx?serve=SubmitAppraisal";
                break;
            }
            case "li_Employees_Appraisals_KPI":
            {
                place.src = "default.aspx?serve=KPI";
                break;
            }
            case "li_Employees_Appraisals_AppraiseAppraisee":
            {
                place.src = "default.aspx?serve=AppraiseAppraisee";
                break;
            }
            case "li_Setup_ExternalUploadResume":
            {
                place.src = "default.aspx?serve=ExternalUploadResume";
                break;
            }
            case "li_Setup_ExternalUploadResumeView":
            {
                place.src = "default.aspx?serve=ExternalUploadResumeView";
                break;
            }
            case "li_Setup_ExternalUploadResumeOne":
            {
                place.src = "default.aspx?serve=ExternalUploadResumeOne";
                break;
            }

            case "li_Employees_Appraisals_AppraisalSelfComment":
            {
                place.src = "default.aspx?serve=AppraisalSelfComment";
                break;
            }
            case "li_Employees_Appraisals_AppraiseAppraiseeComment":
            {
                place.src = "default.aspx?serve=AppraiseAppraiseeComment";
                break;
            }
            case "li_Employees_Appraisals_FinalAppraisalView":
            {
                place.src = "default.aspx?serve=FinalAppraisalView";
                break;
            }
            case "li_Employees_Appraisals_EmployeeFinalAppraisalView":
            {
                place.src = "default.aspx?serve=EmployeeFinalAppraisalView";
                break;
            }
            case "li_Recruitment_ResourceRequest":
            {
                place.src = "default.aspx?serve=ResourceRequest";
                break;
            }
            case "li_Employees_Payroll_gratuity":
            {
                place.src = "default.aspx?serve=GratuityCalculation";
                break;
            }
            case "li_Employees_Grievance_GrievanceRequest":
            {
                place.src = "default.aspx?serve=GrievanceRequest";
                break;
            }
            case "li_Employees_Grievance_GrievanceProcess":
            {
                place.src = "default.aspx?serve=GrievanceProcess";
                break;
            }
            case "li_Recruitment_SalaryApprove":
            {
                place.src = "default.aspx?serve=InterviewSchedule?Type=SalaryApprove";
                break;
            }
        case "li_Setup_Geographic Location_Country":
            {
                place.src = "default.aspx?serve=Master_Country";
                break;
            }
            case "li_Setup_Holiday":
            {
                place.src = "default.aspx?serve=Master_Holidays";
                break;
            }
            case "li_Setup_Recruitment_Consultant":
            {
                place.src = "default.aspx?serve=ConsultantMaster";
                break;
            }
             case "li_Setup_Social Status_MaritalStatus":
            {
                place.src = "default.aspx?serve=Master_Maritial_Status";
                break;
            }
            case "li_Employee_Leave_EmployeeLeaveRequest":
            {
                place.src = "default.aspx?serve=LeaveRequest";
                break;
            }
            case "li_Employee_Leave_LeaveApproval":
            {
                place.src = "default.aspx?serve=LeaveRequestApproval";
                break;
            }
              
              
                case "li_Employees_Loan_Loan":
                {
                    place.src = "default.aspx?serve=Loan";
                    break;
                }
              
              
              
            case "li_Recruitment_CandidateDashboard":
            {
                place.src = "default.aspx?serve=CandidateDashboard";
               // place.src = "~/Recruitment/CandidateDashboard.aspx";
                break;
            }
            case "li_Setup_Recruitment_InterviewType":
            {
                place.src = "default.aspx?serve=InterviewType";
                break;
            }
            case "li_Recruitment_InterviewSchedule":
            {
                place.src = "default.aspx?serve=InterviewSchedule";
                break;
            }
            case "li_Setup_Recruitment_CandidateCompetency":
            {
                place.src = "default.aspx?serve=Candidate_Competency";
                break;
            }
            case "li_Recruitment_Issue Offer":
            {
                place.src = "default.aspx?serve=IssueOfferLetter";
                break;
            }

        case "li_Setup_Inventory_AssetCategory":
            {
                place.src = "default.aspx?serve=AssetCategory";
                break;
            }
        case "li_Setup_Inventory_AssetSubCategory":
            {
                place.src = "default.aspx?serve=AssetSubCategory";
                break;
            }
        case "li_Setup_Inventory_Manufacturer":
            {
                place.src = "default.aspx?serve=Manufacturer";
                break;
            }
        case "li_Employee_Appraisal_Intimation":
            {
                place.src = "default.aspx?serve=Intimation";
                break;
            }
        case "li_Employee_Appraisal_AppraisalRating":
            {
                place.src = "default.aspx?serve=AppraisalRating";
                break;
            }
        case "li_Employee_Appraisal_EmployeeRating":
            {
                place.src = "default.aspx?serve=EmployeeRating";
                break;
            }
        case "li_Employee_Appraisal_ViewAppraisal":
            {
                place.src = "default.aspx?serve=ViewAppraisal";
                break;
            }
        case "li_Employee_Exit Management_Exit Management":
            {
                place.src = "default.aspx?serve=ExitManagement";
                break;
            }
        case "li_Employee_Exit Management_EmployeeExitManagement":
            {
                place.src = "default.aspx?serve=EmployeeExitManagement";
                break;
            }
            case "li_Inventory_ManageAssets":
            {
                place.src = "default.aspx?serve=ManageAssetSummary";
                break;
            }
            case "li_Inventory_AssignAssets":
            {
                place.src = "default.aspx?serve=AssignAssetSummary";
                break;
            }
            case "li_Inventory_OutgoingAssets":
            {
                place.src = "default.aspx?serve=AssetOutgoingSummary";
                break;
            }
            case "li_Employee_Payroll_monthlypayroll":
            {
                place.src = "default.aspx?serve=Payroll";
                break;
            }
            case "li_Attendance_EmployeeAttendance":
            {
                place.src = "default.aspx?serve=EmployeeAttendance";
                break;
            }
           case "li_Reports_Inventory_AssetAssignTeamWise":
            {
                place.src = "default.aspx?serve=Reports&cap=Asset Assign Team Wise Report&perm=aedv&rtype=rdlcAssetAssignTeamWise";
                break;
            }
         case "li_Reports_Inventory_AssetAssignUserWise":
            {
                place.src = "default.aspx?serve=Reports&cap=Asset Assign User Wise Report&perm=aedv&rtype=rdlcAssetAssignUserWise";
                break;
            }
        case "li_Reports_Inventory_OutgoingAssets":
            {
                place.src = "default.aspx?serve=Reports&cap=Outgoing Devices Report&perm=aedv&rtype=rdlcOutgoingAssets";
                break;
            }
        case "li_Reports_Employee_ExitEmployee":
            {
                place.src = "default.aspx?serve=Reports&cap=Exit Employee Report&perm=aedv&rtype=rdlcExitEmployment";
                break;
            }
         case "li_Reports_Employee_JoiningDate":
            {
                place.src = "default.aspx?serve=Reports&cap=Employee Joining Date Report&perm=aedv&rtype=rdlcJoiningType";
            break;
        }
    case "li_Reports_Employee_All Employee Details":
        {
            place.src = "default.aspx?serve=Reports&cap=All Employee Details Report&perm=aedv&rtype=rdlcAllEmployeeDetails";
            break;
        }  

 case "li_Reports_Employee_Employee Details":
        {
            place.src = "default.aspx?serve=Reports&cap=Employee Details Report&perm=aedv&rtype=rdlcEmployeeDetails";
            break;
        }
    case "li_Reports_Employee_Type":
        {
            place.src = "default.aspx?serve=Reports&cap=Employee Type Report&perm=aedv&rtype=rdlcEmployeeType";
            break;
        }         
                
        case "li_Reports_Inventory_AssetCategory":
        {
            place.src = "default.aspx?serve=Reports&cap=Asset Category Report&perm=aedv&rtype=rdlcAssetCategory&mode=assetcategory";
            break;
        }
        case "li_Reports_Inventory_AssetSubCategory":
        {
            place.src = "default.aspx?serve=Reports&cap=Asset Sub Category Report&perm=aedv&rtype=rdlcAssetCategory&mode=assetsubcategory";
            break;
        }
        case "li_Reports_Inventory_AllAssets":
        {
            place.src = "default.aspx?serve=Reports&cap=All Assets Report&perm=aedv&rtype=rdlcAssetCategory&mode=allassets";
            break;
        }
      
        
             
       case "li_Reports_Employee_TeamwiseEmployee":
            {
                place.src = "default.aspx?serve=Reports&cap=Team Wise Employee Report&perm=aedv&rtype=rdlcTeamwiseEmployee";
                break;
            }
            
        case "li_Reports_Leave_Balance":
        {
            place.src = "default.aspx?serve=Reports&cap=Leave Balance Report&perm=aedv&rtype=rdlcLeaveBalance";
            break;
        }
        case "li_Reports_Leave_Request":
        {
            place.src = "default.aspx?serve=Reports&cap=Leave Request Report&perm=aedv&rtype=rdlcLeaveRequest";
            break;
        }
        case "li_Reports_Leave_WorkFromHome":
        {
            place.src = "default.aspx?serve=Reports&cap=Work From Home Report&perm=aedv&rtype=rdlcWorkFromHome";
            break;
        }
        case "li_Reports_Leave_Employee Leave Activity Report":
        {
            place.src = "default.aspx?serve=Reports&cap=Employee Leave Activity Report&perm=aedv&rtype=rdlcEmpActivityLeave";
            break;
        }
        case "li_Reports_Appraisal_Promotion Report":
        {
            place.src = "default.aspx?serve=Reports&cap=Promotion Report&perm=aedv&rtype=rdlcPromotionReport";
            break;
        }
        case "li_Reports_Appraisal_Salary Hike Report":
        {
            place.src = "default.aspx?serve=Reports&cap=Salary Hike Report&perm=aedv&rtype=rdlcSalaryHikeReport";
            break;
        }
        case "li_Reports_Exit Management_Exit Employee by Resignation":
        {
            place.src = "default.aspx?serve=Reports&cap=Exit Employee by Resignation&perm=aedv&rtype=rdlcResignationExitManagementReport";
            break;
        }
        case "li_Reports_Exit Management_Exit employee by Termination":
        {
            place.src = "default.aspx?serve=Reports&cap=Exit employee by Termination&perm=aedv&rtype=rdlcTerminationExitManagementReport";
            break;
        }
        case "li_Reports_Exit Management_Exit employee by Team":
        {
            place.src = "default.aspx?serve=Reports&cap=Exit employee by Team&perm=aedv&rtype=rdlcTeamWiseExitManagementReport";
            break;
        }

        case "li_Reports_Recruitment_Candidate interview details report":
        {
            place.src = "default.aspx?serve=Reports&cap=Candidate interview details report&perm=aedv&rtype=rdlcCandidateInterviewDetailsReport";
            break;
        }
        case "li_Reports_Recruitment_Candidate details by consultant":
        {
            place.src = "default.aspx?serve=Reports&cap=Candidate details by consultant&perm=aedv&rtype=rdlcCandidateDetailsbyConsultant";
            break;
        }
        case "li_Reports_Recruitment_Candidate details by referral":
        {
            place.src = "default.aspx?serve=Reports&cap=Candidate details by referral&perm=aedv&rtype=rdlcCandidateDetailsbyReferral";
            break;
        }
//        case "li_Reports_Recruitment_Shortlisted candidate application details":
//        {
//            place.src = "default.aspx?serve=Reports&cap=Shortlisted candidate application details&perm=aedv&rtype=rdlcShortlistedCandidateApplicationDetails";
//            break;
//        }
        case "li_Reports_Recruitment_Offer letter issued report":
        {
            place.src = "default.aspx?serve=Reports&cap=Offer letter issued report&perm=aedv&rtype=rdlcOfferLetterIssuedReport";
            break;
        }
        case "li_Manual":
        {
            place.src = "default.aspx?serve=Help";
            break;

        }
    case "li_Employee_Payroll_Payroll":
        {
            place.src = "default.aspx?serve=Payroll";
            break;
        }
    case "li_Employee_Payroll_PayrollAllowance":
        {
            place.src = "default.aspx?serve=SalaryAllowances";
            break;
        }
    case "li_Employee_Payroll_PayrollDeductions":
        {
            place.src = "default.aspx?serve=SalaryDeductions";
            break;
        }
        case "li_Reports":
        {
            place.src = "default.aspx?serve=Reports";
            break;
        } 
            
            case "li_LogOut":
                LogOut();
                break;


            default:
                {
                    if (menuItem && menuItem.href) {
                        place.src = menuItem.href;
                        break;
                    };

                    place.src = "default.aspx?serve=temp";

                    break;
                }
        }
    }
</script>

<%--NavigateToPage--%>

<script type="text/javascript">
    function NavigateToPage(pgname) {
        place.src = "default.aspx?serve=" + pgname;
    }
</script>

<%--selfshow--%>

<script type="text/javascript">
    function selfshow(tmptPageHtml) {
        CWBpgstrA = tmptPageHtml;

        var thissrc = "var newdoc=document.open('text/html', 'replace');"
              + "newdoc.write(CWBpgstrA);"
              + "newdoc.close();";

        if (execScript)
            execScript(thissrc);
    }
</script>

<%--LogOut--%>

<script type="text/javascript">
    function LogOut() {
        if (!confirm('Confirm Logout')) {
            return false;
        }

        CleanExit = true;
        location.href = "module91.axd/logoutuser";
    }

    function AfterLogin() {
        document.getElementById("ChildWB").frameElement.src = "default.aspx?serve=DashBoard";
    }
</script>

<%--onUsers--%>

<script type="text/javascript">
    function onUsers() {
        place.src = "default.aspx?serve=Users";
    }
</script>

<%--onChangePwd--%>

<script type="text/javascript">
    function onChangePwd() {
        showModalDialog("default.aspx?serve=ChangePassword", self, "dialogHeight:190px; dialogWidth:500px; resizable:yes; status:no;");
    }
</script>

</html>
