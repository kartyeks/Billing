<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateDashboard.aspx.cs" Inherits="AltioStarHR.Recruitment.CandidateDashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>Candidate Dashboard</title>
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
        #Clientmaster
        {
            width: 217px;
        }
      
    </style>
</head>
<body>
 <div style="position:relative;width: 100%" >
    <img alt="" src="Resources/Images/NewImages/1.png" style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
    <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
    <strong class="family1 imageheadercolor">Candidate Dashboard Details</strong>
    </div>
</div>
 <%--   <div style="margin-left:2%;" id="box1">
        <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>--%>
    <div id="divmanagerAppRejResume" style="display: none;width: 100%;background-color:#a4cd0f;">
        <table id="tblmanagerAppRejResume" style="width:100%" >
            <tr>
                <td>
                    <label><b class="family">View Resume</b></label>
                </td>
                <td>
                    <img id="imgViewResume" src="Resources/Images/big_resume_icon.png" alt="" onclick="onImageClick()"  style='cursor: pointer;'/>
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        <input type="radio" name="rdbManagerRemark" checked="checked" value="radio" id="rdbApp"  class="family"
                            onload="return ShowGridOrRemarks(); " onclick="ShowGridOrRemarks(); " class="radioClear" />
                        <b class="family">Approve</b></label>
                </td>
                <td>
                    <label>
                        <input type="radio" name="rdbManagerRemark" value="radio" id="rdbRej" class="family"
                            onload="return ShowGridOrRemarks(); " onclick="ShowGridOrRemarks(); " class="radioClear" />
                        <b class="family">Reject</b>
                    </label>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr id="trRejRemark" style="display:none">
                <td>
                    <label id="lrejectionremark" class="family">Rejection Remarks</label>
                </td>
                <td>
                    <textarea id="rejectionremark" rows="3" cols="10" style="border:1px solid silver" class="family"></textarea>
                </td>
            </tr>
            <tr id="trRoundShow" style="display:none;background-color:#00daf5; ">
                <td colspan="2">
                    <fieldset>
                        <legend style="font-weight:bold" class="family">Latest Interview Details</legend>
                        <table id="tblRoundShow" style="width:530px">
                            <tr>
                                <td>
                                    <b class="family">InterviewType:</b>
                                    <label id="linterviewtype" style="width:100px" class="family"></label>
                                </td>
                                <td>
                                    <b class="family">Interviewer(s):</b>
                                    <label id="linteviewers" style="width:200px" class="family"></label>
                                </td>
                            </tr>
                            <tr id="trsecondrounddetails" style="display:none">
                                <td>
                                    <b class="family">InterviewType:</b>
                                    <label id="lsecondroundinteviewtype" style="width:100px" class="family"></label>
                                </td>
                                <td>
                                    <b class="family">Interviewer(s):</b>
                                    <label id="lsecondroundinterviewer" style="width:200px" class="family"></label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr id="trEmpGrid">
                <td colspan="2" >
                    <table id="tblEmpGrid"></table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input type="button" id="btnSave" value="Submit" onclick="SaveManagerDetails()" style="background-color:#00DBF1;" class="family"/>
                </td>
                <td>
                    <input type="button" id="btnCancel" value="Cancel" onclick="CloseApporRejDialog()" style="background-color:#00DBF1;" class="family"/>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-left:2%;" id="box">
      <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>
    <form id="frm1" runat="server">
        <input type="hidden" id="hdnLoggedUserID" runat="server" />
        <input type="hidden" id="hdnLoggedEmpID" runat="server" />
        <input type="hidden" id="hdnlocalvar" />
        <input type="hidden" id="hdnLoginType" runat="server" />
    </form>
</body>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-1.6.2.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.16.custom.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/grid.locale-en.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.jqGrid.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Webutility.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/toolbar.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.core.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.widget.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.validate.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Validation.js") %>"></script>


<script type="text/javascript">
    var mode = "";
    var activeStatus = true;
//    $(window).bind('resize', function() {
//        $("#list").setGridWidth($('#box').width() - 10, true);
//    }).trigger('resize');
    jQuery("#box").css({ width: "97%" });
//    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg.gif)');
//    $('#tblEmpGrid').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg.gif)');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });
    $("#tblEmpGrid").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });   

    jQuery(document).ready(function() {
        EnableAllFields();
        var myGrid = $('#list');

        var Request = new Object();
        Request.LoggedEmpID = $('#hdnLoggedEmpID').val();
        Request.LoggedUserID = $('#hdnLoggedUserID').val();
        Request.RecruitmentLoggerType = $("#hdnLoginType").val();

        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.GET_CANDIDATE_DETAILS%>', Request, true);

        Response.ResponseObject.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'teamid', index: 'teamid', width: 100, editable: true, hidden: true },
            { name: 'candidatetype', index: 'candidatetype', width: 20, editable: true, hidden: true },
            { name: 'firstname', index: 'firstname', width: 80, editable: true },
            { name: 'middlename', index: 'middlename', width: 80, editable: true },
            { name: 'lastname', index: 'lastname', width: 80, editable: true },
            { name: 'teamname', index: 'teamname', width: 80, editable: true },
            { name: 'manager', index: 'manager', width: 80, editable: true },
            { name: 'currentemployer', index: 'currentemployer', width: 100, editable: true, hidden: true },
            { name: 'careerstartdate', index: 'careerstartdate', width: 20, hidden: true, sorttype: "int" },
            { name: 'experience', index: 'experience', width: 70, hidden: true },
            { name: 'technologyexpertise', index: 'technologyexpertise', width: 100, editable: true, hidden: true },
            { name: 'contactnumber', index: 'contactnumber', width: 70, editable: true, hidden: true },
            { name: 'emailid', index: 'emailid', width: 100, editable: true },
            { name: 'noticeperiod', index: 'noticeperiod', width: 100, editable: true, hidden: true },
            { name: 'currentlocation', index: 'currentlocation', width: 100, editable: true, hidden: true },
            { name: 'reasonforchange', index: 'reasonforchange', width: 100, editable: true, hidden: true },
            { name: 'offersinhand', index: 'offersinhand', width: 100, editable: true, hidden: true },
            { name: 'resumefilename', index: 'resumefilename', width: 80, editable: true, hidden: true },
            { name: 'recruitmenttype', index: 'recruitmenttype', width: 100, editable: true, hidden: true },
            { name: 'createdby', index: 'createdby', width: 100, editable: true, hidden: true },
            { name: 'createddate', index: 'createddate', width: 100, editable: true, hidden: true },
            { name: 'interviewstatusid', index: 'interviewstatusid', width: 100, editable: true, hidden: true },
            { name: 'interviewstatus', index: 'interviewtatus', width: 130, editable: true },
            { name: 'isdeleted', index: 'isdeleted', width: 130, editable: true, hidden: true },
        ];

        Response.ResponseObject.onSelectRow = function(ID) {
            var candidateid = jQuery("#list").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#list").jqGrid('getRowData', candidateid);

            var CheckRequest = new Object();
            CheckRequest.ID = $('#hdnLoggedUserID').val();
            CheckRequest.ChangedBy = candidateid;
            var CheckResponse = SendApplicationRequest('<%=RecruitmentAppCommands.CHECK_LOGGED_EMP_ISCANDIDATE_MANAGER%>', CheckRequest, true);

            if (CheckResponse.ResponseObject == true) {
                document.getElementById('btnshortlistcandidate').style.display = "";
                document.getElementById('btndeletecandidate').style.display = "none";
            }
            else {
                document.getElementById('btnshortlistcandidate').style.display = "none";
                document.getElementById('btndeletecandidate').style.display = "";
            }

            if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApproveFULL%>"
            || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove2FULL%>"
            || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduledFULL%>"
            || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled2FULL%>") {
                document.getElementById('btnviewTech').style.display = "";
            }
            else
                document.getElementById('btnviewTech').style.display = "none";

            $("#hdnlocalvar").val(CheckResponse.ResponseObject);
        }

        Response.ResponseObject.caption = "Candidate Dashboard";
        Response.ResponseObject.ignoreCase = true;
       
        Response.ResponseObject.autowidth= true;
        myGrid.jqGrid(Response.ResponseObject);

        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");

        $("#t_list").append("<button type='button' id='btnaddcandidate' value='Refer Candidate' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><div></div><span >Refer Candidate</span></button>");
        $("#t_list").append("<button type='button' id='edit' value='View Candidate' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view_btn.png'height=18px;width=18px alt='' /><br/><div></div><span >View Candidate</span></button>");
        $("#t_list").append("<button type='button' id='btnshortlistcandidate' value='Shortlist' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/shortlist.jpg'height=18px;width=18px alt='' /><br/><div></div><span >Shortlist</span></button>");
        $("#t_list").append("<button type='button' id='btnviewTech' value='View Technical Panel' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view.jpg'height=18px;width=18px alt='' /><br/><div></div><span>View Technical Panel</span></button>");
        $("#t_list").append("<button type='button' id='btndeletecandidate' value='Delete' style='background:none;border:0px;outline:none;'><img src='Resources/Images/delete.png'height=18px;width=18px alt='' /><br/><div></div><span >Delete</span></button> ");

        $("button ,input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "btnaddcandidate") {
                window.location.href = "default.aspx?serve=CandidateApplication&CandID=0";
            }
            else if (id.currentTarget.id == "edit") {
                var candidateid = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', candidateid);
                if (candidateid) {
                    if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerRejectFULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.RejectFirstFULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerReject2FULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.RejectSecondFULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.RejectHRFULL%>") {
                        alert('Candidate rejected, cannot View/Edit ');
                    }
                    else {
                        var ilep = $("#hdnlocalvar").val();
                        window.location.href = "default.aspx?serve=CandidateApplication&CandID=" + candidateid + "&ILEP=" + ilep;
                    }
                }
                else alert("Select candidate to view");
            }
            else if (id.currentTarget.id == "btnshortlistcandidate") {
                var candidateid = jQuery("#list").jqGrid('getGridParam', 'selrow');
                EnableAllFields();
                ShowGridOrRemarks();
                if (candidateid) {
                    var ret = jQuery("#list").jqGrid('getRowData', candidateid);

                    if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedSecondFULL%>") {
                        alert('Candidate already selected for HR Round ');
                    }
                    else if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.NewCandidate%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedFirstFULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApproveFULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerRejectFULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove2FULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerReject2FULL%>") {
                        document.getElementById('divmanagerAppRejResume').style.display = "";
                        $('#divmanagerAppRejResume').dialog({
                            height: 500,
                            width: 670,
                            modal: true,
                            title: "Candidate Approval"
                        });
                        FillTechnicalPanel("AddTech");
                    }
                    else if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerRejectFULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.RejectFirstFULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerReject2FULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.RejectSecondFULL%>"
                        || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.RejectHRFULL%>") {
                        alert('Candidate rejected, cannot shortlist ');
                    }
                    else if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.SalaryFixedFULL%>") {
                        alert('Candidate is already hired ');
                        return;
                    }
                    else {
                        alert('Candidate already scheduled for inteview');
                    }
                }
                else alert("Select candidate to shortlist");
            }
            else if (id.currentTarget.id == "btnviewTech") {
                ShowGridOrRemarks();
                var candidateid = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (candidateid) {
                    document.getElementById('divmanagerAppRejResume').style.display = "";
                    $('#divmanagerAppRejResume').dialog({
                        height: 500,
                        width: 670,
                        modal: true,
                        title: "Resume Approval"
                    });
                    FillTechnicalPanel("ViewTech");
                    DisableAllFields();
                }
                else
                    alert('Select candidate to View Technical Panel');
            }
            else if (id.currentTarget.id == "btndeletecandidate") {
                var candidateid = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                if (candidateid) {
                    if (confirm('Do you want to Delete?') == false) return;
                    var ret = jQuery("#list").jqGrid('getRowData', candidateid);
                    if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.NewCandidate%>") {
                        var Request = new Object();
                        Request.ID = ret.id;
                        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.DELETE_CANDIDATE%>', Request);
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            var RRequest = new Object();
                            RRequest.LoggedEmpID = $('#hdnLoggedEmpID').val();
                            RRequest.LoggedUserID = $('#hdnLoggedUserID').val();
                            RRequest.RecruitmentLoggerType = $("#hdnLoginType").val();

                            var RResponse = SendApplicationRequest('<%=RecruitmentAppCommands.GET_CANDIDATE_DETAILS%>', RRequest, true);
                            if (RResponse.ResponseObject.datastr == null)
                                $("#list").jqGrid('clearGridData');
                            else {
                                $("#list").jqGrid('setGridParam', RResponse.ResponseObject);
                                $("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else
                        alert('Cannot delete Candidate involved in recruitment process');
                }
                else
                    alert('Select candidate to delete');
            }
        });
//        var mygrid = jQuery('#list'),
//        cDiv = mygrid[0].grid.cDiv;
//        mygrid.setCaption("");
//        $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
//        $(cDiv).hide();
//        $("#list").closest(".ui-jqgrid-bdiv").height("auto");


        var myEmpGrid = $('#tblEmpGrid');

        var EmpRequest = new Object();
        EmpRequest.FirstName = '';
        EmpRequest.LastName = '';
        EmpRequest.Empcode = '';
        EmpRequest.DesignationID = 0;
        EmpRequest.CountryID = 0;
        EmpRequest.LocationID = 0;
        EmpRequest.TeamID = 0;
        var EmpResponse = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE_GRIDDETAILS%>', EmpRequest, true);

        EmpResponse.ResponseObject.colModel = [
            { name: 'EmpID', index: 'EmpID', hidden: true, sorttype: "int" },
            { name: 'EmpTypeID', index: 'EmpTypeID', hidden: true, sorttype: "int", hidden: true },
            { name: 'EmpCode', index: 'EmpCode', editable: true, width: 70 },
            { name: 'EmployeeType', index: 'EmployeeType', editable: true, hidden: true },
            { name: 'FirstName', index: 'FirstName', editable: true, width: 100 },
            { name: 'MiddleName', index: 'MiddleName', editable: true, width: 100, hidden: true },
            { name: 'LastName', index: 'LastName', width: 50, editable: true, width: 100 },
            { name: 'Country', index: 'Country', editable: true, hidden: true },
            { name: 'Location', index: 'Location', editable: true, hidden: true },
            { name: 'Designation', index: 'Designation', width: 50, editable: true, width: 100 },
            { name: 'Team', index: 'Team', editable: true, hidden: true },
            { name: 'ManagerName', index: 'ManagerName', editable: true, hidden: true },
            { name: 'Gender', index: 'Gender', editable: true, hidden: true },
            { name: 'EmailID', index: 'EmailID', editable: true, width: 150 }
        ];

        EmpResponse.ResponseObject.caption = "Assign Technical Panel";
        EmpResponse.ResponseObject.multiselect = true;
        EmpResponse.ResponseObject.pager = '';
        EmpResponse.ResponseObject.height = '200px';
        EmpResponse.ResponseObject.width = '610';
        EmpResponse.ResponseObject.scroll = true;
        myEmpGrid.jqGrid(EmpResponse.ResponseObject);

        $("#tblEmpGrid").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
    });

    function CloseApporRejDialog() {
        $('#divmanagerAppRejResume').dialog('close');
    }

    function ShowGridOrRemarks() {
        
        if ($("#rdbApp").is(':checked')) {
            document.getElementById('trEmpGrid').style.display = "";
            document.getElementById('tblEmpGrid').style.display = "";
            document.getElementById('trRejRemark').style.display = "none";
        }
        else if ($("#rdbRej").is(':checked')){
            document.getElementById('trRejRemark').style.display = "";
            document.getElementById('trEmpGrid').style.display = "none";
        }
    }

    function onImageClick() { 
        var candidateid = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', candidateid);

        if (ret.resumefilename != "" && ret.id != 0) {
            window.location.href = "DownloadFileHandler.ashx?Type=candidateresume&DocumentName=CandidateID_" + ret.id + "_" + ret.resumefilename;
        }
        else {
            alert("Resume not uploaded.");
            return;
        }
    }

    function FillTechnicalPanel(MODE) {
        
        var candid = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', candid);

        if ((ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled2FULL%>"
            || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduledFULL%>") 
            && MODE == "ViewTech") {
            var Request = new Object();
            Request.ID = ret.interviewstatusid;
            var Response = SendApplicationRequest('<%=RecruitmentAppCommands.INTERVIEW_STATUS_DET_WITH_TECHNICAL_PANEL%>', Request, true);
            
            if (Response.ResponseCommand == 'SUCCESS') {
                var arr = Response.ResponseObject;
                $('#tblEmpGrid').jqGrid('resetSelection');
                var TechPName1 = ""; var TechPName2 = "";
                
                if (arr[0].CandidateStatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove%>")
                    $("#rdbApp").attr('checked', true);
                else if (arr[0].CandidateStatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerReject%>")
                    $("#rdbRej").attr('checked', true);

                var InType = new Array();
                InType[0] = arr[0].InterviewType;

                $('#rejectionremark').val(arr[0].RejectionRemarks);
                ShowGridOrRemarks();
                
                for (k = 0; k < arr.length; k++) {
                    if (arr[k].InterviewType == InType[0]) {
                        document.getElementById('linterviewtype').innerHTML = arr[k].InterviewType;
                        if (TechPName1 == "")
                            TechPName1 = arr[0].TechPanelName;
                        else
                            TechPName1 = TechPName1 + "," + arr[k].TechPanelName
                    }
                    else {
                        document.getElementById('lsecondroundinteviewtype').innerHTML = arr[k].InterviewType;
                        if (TechPName2 == "")
                            TechPName2 = arr[k].TechPanelName;
                        else
                            TechPName2 = TechPName2 + "," + arr[k].TechPanelName
                    }
                }
                
                document.getElementById('linteviewers').innerHTML = TechPName1;
                document.getElementById('lsecondroundinterviewer').innerHTML = TechPName2;

                if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduledFULL%>") {
                    document.getElementById('trRoundShow').style.display = "";
                    document.getElementById('trEmpGrid').style.display = "none";
                }
                else if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled2FULL%>") {
                    document.getElementById('trsecondrounddetails').style.display = "";
                    document.getElementById('trRoundShow').style.display = "";
                    document.getElementById('trEmpGrid').style.display = "none";
                }
                else {
                    document.getElementById('trRoundShow').style.display = "none";
                    document.getElementById('trsecondrounddetails').style.display = "none";
                    document.getElementById('trEmpGrid').style.display = "";
                }
            }
        }
        else {
            var Request = new Object();
            Request.ID = ret.interviewstatusid;
            var Response = SendApplicationRequest('<%=RecruitmentAppCommands.INTERVIEW_STATUS_DET_WITH_TECHNICAL_PANEL%>', Request, true);

            if (Response.ResponseCommand == 'SUCCESS') {
                var arr = Response.ResponseObject;
                $('#tblEmpGrid').jqGrid('resetSelection');
                var TechPName = "";
                for (i = 0; i < arr.length; i++) {
                    if (arr[i].CandidateStatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove%>")
                        $("#rdbApp").attr('checked', true);
                    else if (arr[0].CandidateStatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerReject%>")
                        $("#rdbRej").attr('checked', true);

                    if (arr[i].TechnicalPanel != 0 && arr[i].InterviewTypeID == 0) {
                        $("#tblEmpGrid").jqGrid('setSelection', arr[i].TechnicalPanel);
                    }
                    $('#rejectionremark').val(arr[i].RejectionRemarks);
                    ShowGridOrRemarks();

                    if (arr[i].InterviewTypeID != 0) {
                        document.getElementById('linterviewtype').innerHTML = arr[i].InterviewType;
                        if (TechPName == "")
                            TechPName = arr[0].TechPanelName;
                        else
                            TechPName = TechPName + "," + arr[i].TechPanelName
                    }
                }
                document.getElementById('linteviewers').innerHTML = TechPName
            }
            if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedFirstFULL%>"
                || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove2FULL%>"
                || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerReject2FULL%>") {
                document.getElementById('trRoundShow').style.display = "";
            }
            else
                document.getElementById('trRoundShow').style.display = "none";
        }
    }
    
    function SaveManagerDetails() {
        
        var selection;
        if ($("#rdbApp").is(':checked')) {
            selection = "Approve";
        }
        
        var empGridlength = $("#tblEmpGrid").jqGrid('getGridParam', 'selarrrow').length;
        if ($("#rdbApp").is(':checked') && empGridlength == 0) {
            alert('Select atleast one employee for Technical Panel');
            
        }
        else if ($("#rdbRej").is(':checked') && $('#rejectionremark').val() == "") {
            alert('Enter Rejection Remarks');
            $('#rejectionremark').focus();
        }
        else {
            
            var Request = new Object();
            if ($("#rdbRej").is(':checked'))
            {
                if (confirm('Are you sure to reject candidate!') == false) return false;
                Request.RejectionRemarks = $('#rejectionremark').val();
            }
            var candid = jQuery("#list").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#list").jqGrid('getRowData', candid);

            var seletedRow = $('#tblEmpGrid').getGridParam('selarrrow');
            var strvalues = seletedRow[0];
            for (i = 1; i < seletedRow.length; i++) {
                strvalues = strvalues + "," + seletedRow[i];
            }

            Request.ID = ret.interviewstatusid;
            Request.CandidateID = ret.id;
            Request.TeamID = ret.teamid;

            if (ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedFirstFULL%>"
                || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove2FULL%>"
                || ret.interviewstatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerReject2FULL%>") {
                if ($("#rdbApp").is(':checked')) {
                    Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove2%>";
                }
                else if ($("#rdbRej").is(':checked')) {
                    Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerReject2%>";
                }
            }
            else {
                if ($("#rdbApp").is(':checked')) {
                    Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove%>";
                }
                else if ($("#rdbRej").is(':checked')) {
                    Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerReject%>";
                }
            }

            Request.TechnicalPanelIDs = strvalues;
            Request.InterviewTypeID = 0;
            Request.UpdatedBy = $('#hdnLoggedUserID').val();

            var Response = SendApplicationRequest('<%=RecruitmentAppCommands.UPDATE_INTERVIEW_STATUS%>', Request, true);
            if (Response.ResponseCommand == "SUCCESS")
            {
                var candid = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', candid);
                var NRequest = new Object();
                NRequest.CandidateID = candid;
                NRequest.SelectionType = selection;
                NRequest.ResumePath = "Resources/ResumeDownloads/CandidateID_" + candid + "_" + ret.resumefilename;

                var NResponse = SendApplicationRequest('<%=RecruitmentAppCommands.NOTIFY_MANAGER_APP_REJ%>', NRequest, true);
                if (NResponse.ResponseCommand == "SUCCESS") {
                    alert(Response.Message + NResponse.Message);
                }
                CloseApporRejDialog();
            }
            ReloadCandidateGrid();
        }
        
    }
    
    
    function ReloadCandidateGrid() {
        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        var Request = new Object();
        Request.LoggedEmpID = $('#hdnLoggedEmpID').val();
        Request.LoggedUserID = $('#hdnLoggedUserID').val();
        Request.RecruitmentLoggerType = $("#hdnLoginType").val();
        
        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.GET_CANDIDATE_DETAILS%>', Request, true);

        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").trigger('reloadGrid');
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
    }

    function ClearFields() {
        $('#tblEmpGrid').jqGrid('resetSelection');
        $('#rejectionremark').val("");
    }

    function DisableAllFields() { 
        $('#rdbApp').attr("disabled", true);
        $('#rdbRej').attr("disabled", true);
        $('#rejectionremark').attr("disabled", true);
        $('#tblEmpGrid').attr("disabled", true);
        $('#btnSave').hide();
    }

    function EnableAllFields() {
        $('#rdbApp').attr("disabled", false);
        $('#rdbRej').attr("disabled", false);
        $('#rejectionremark').attr("disabled", false);
        $('#tblEmpGrid').attr("disabled", false);
        $('#btnSave').show();
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
