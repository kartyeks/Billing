<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterviewSchedule.aspx.cs" Inherits="AltioStarHR.Recruitment.InterviewSchedule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>Interview Schedule</title>
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
    <div style="position:relative;width:100%">
        <img alt="" src="Resources/Images/NewImages/1.png" style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
        <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
         <strong class="family1 imageheadercolor">Interview Schedule Details</strong>
        </div>
    </div>
   <%-- <div class="dvGrid" style="width: 900px">
        <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>--%>
    <div id="divInterview" title="Interview Schedule" style="display:none;background-color:White;width:100%;">
        <form id="frmInterviewSchedule" method="get" action="">
        <fieldset style="width:97%; margin-left:2%">
            <table style="width:100%; background-color:#a4cd0f">
                <tbody>
                    <tr>
                        <td>
                            <label id="linterviewtype" class="family">Interview Type</label>
                        </td>
                        <td >
                            <select id="cmbinterviewtype" style="width: 180px;border:1px solid silver;" name="cmbinterviewtype" class="family">
                            </select>
                        </td>
                        <td id="scmbinterviewtype">
                        </td>
                    </tr>
                    <tr>
                        <td class="family">
                            Interview Date1
                        </td>
                        <td>
                            <input type="text" id="date1" disabled="disabled" name="date1" style="width: 155px;border:1px solid silver;" class="family"/>
                        </td>
                        <td  id="sdate1" class="family">
                        </td>
                    </tr>
                    <tr>
                        <td class="family">
                            Interview Time1
                        </td>
                        <td>
                            <input type="text" id="intTime1" name="intTime1" style="width: 155px;border:1px solid silver;" readonly class="family"/>
                        </td>
                        <td id="stime1" class="family">
                        </td>
                    </tr>
                    <tr>
                        <td class="family">
                            Interview Date2
                        </td>
                        <td>
                            <input type="text" id="date2" disabled="disabled" name="date2" style="width: 155px;border:1px solid silver;" class="family"/>
                        </td>
                        <td  id="sdate2" class="family">
                        </td>
                    </tr>
                    <tr>
                        <td class="family">
                            Interview Time2
                        </td>
                        <td>
                            <input type="text" id="intTime2" name="intTime2" style="width: 155px;border:1px solid silver;" readonly class="family"/>
                        </td>
                        <td id="stime2" class="family">
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table>
                <tr align="center">
                    <td>
                        <input id="brnsave" name="save" type="submit" value="Save" class="family" style="background-color:#00DBF1;"/>
                    </td>
                    <td>
                        <input id="btncancel" name="cancel" type="button" value="Cancel" onclick="CloseInterviewScheduleDialog()" 
                            class="family" style="background-color:#00DBF1;"/>
                    </td>
                    <td>
                        <input id="btnresetdatetime" name="btnresetdatetime" type="button" value="Reset Date&Time" 
                            onclick="ResetDateTime()" class="family" style="background-color:#00DBF1;"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        </form>
    </div>
    <div id="divCandidateAvail" title="Candidate Availability" style="display: none;background-color:White">
        <%--<table class="teble_bg" style="width:auto">--%>
        <table style="background-color:#a4cd0f">
            <tr>
                <td>
                    <label class="family">Is Candidate Available?</label>
                </td>
                <td>
                    <input type="checkbox" name="chkiscandavail" id="chkiscandavail" class="family"/>
                </td>
            </tr>  
            <tr>
                <td>
                    <input id="bnSaveCandAvial" name="save" type="button" value="Save" onclick="SaveCandAvialDialog()" class="family"
                        style="background-color:#00DBF1;"/>
                </td>  
                <td>
                    <input id="btnCancelCandAvial" name="btnCancelCandAvial" type="button" value="Cancel" onclick="CloseCandAvialDialog()" 
                        class="family" style="background-color:#00DBF1;"/>
                </td>
            </tr> 
        </table>
    </div>
    <div style="margin-left:2%;background-image:url('<%= ResolveUrl("~/Resources/Images/NewImages/dashboard_bg.gif") %>');" id="box">
      <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>
    <form id="frm1" runat="server">
        <input type="hidden" id="hdnLoggedUserID" runat="server" />
        <input type="hidden" id="hdnLoggedEmpID" runat="server" />
        <input type="hidden" id="hdnRoleName" runat="server"  />
        <input type="hidden" id="hdnLoginType" runat="server"  />
    </form>
</body>
<link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
        
    
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

<script src="Resources/js/jquery-ui-timepicker-addon.js" type="text/javascript"></script>


<script type="text/javascript">
    var mode = "";
    var activeStatus = true;
//    $(window).bind('resize', function() {
//        $("#list").setGridWidth($('#box').width() - 30, true);
//    }).trigger('resize');
    jQuery("#box").css({ width: "97%" });
    //    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });

    jQuery(document).ready(function() {
        LoadInterviewType();
        $(function() {
            $("#date1").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                minDate: 0
            });
            $("#date1").datepicker("option", "dateFormat", 'dd/mm/yy');
        });

        $('#intTime1').timepicker({
            showOn: "button",
            buttonImage: "Resources/Images/clock.jpg",
            ampm: false,
            show24Hours: true,
            hourMin: 7,
            hourMax: 19
        });
        $('#intTime1').timepicker({});

        $(function() {
            $("#date2").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                minDate: 0
            });
            $("#date2").datepicker("option", "dateFormat", 'dd/mm/yy');
        });

        $('#intTime2').timepicker({
            showOn: "button",
            buttonImage: "Resources/Images/clock.jpg",
            ampm: false,
            show24Hours: true,
            hourMin: 7,
            hourMax: 19
        });
        $('#intTime2').timepicker({});

        var myGrid = $('#list');

        var Request = new Object();
        Request.LoggedEmpID = $('#hdnLoggedEmpID').val();
        Request.LoggedUserID = $('#hdnLoggedUserID').val();
        Request.RoleName = $('#hdnRoleName').val();

        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.GET_INTERVIEW_STATUS_GRID%>', Request, true);

        Response.ResponseObject.colModel = [
            { name: 'candidatename', index: 'candidatename', width: 70 },
            { name: 'teamname', index: 'teamname', width: 60, editable: true },
            { name: 'managername', index: 'managername', width: 70, editable: true },
            { name: 'interviewtype', index: 'interviewtype', width: 70, editable: true },
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'candidateid', index: 'candidateid', width: 100, editable: true, hidden: true },
            { name: 'teamid', index: 'teamid', width: 100, editable: true, hidden: true },
            { name: 'interviewtypeid', index: 'interviewtypeid', width: 100, editable: true, hidden: true },
            { name: 'date1time1', index: 'date1time1', width: 80, editable: true },
            { name: 'date2time2', index: 'date2time2', width: 80, editable: true },
            { name: 'updatedby', index: 'updatedby', width: 100, editable: true, hidden: true },
            { name: 'updateddate', index: 'updateddate', width: 20, hidden: true, hidden: true },
            { name: 'iscandidateavail', index: 'updateddate', width: 20, hidden: true, hidden: true },
            { name: 'candidatestatus', index: 'candidatestatus', width: 90, editable: true }
        ];

        Response.ResponseObject.onSelectRow = function(ID) {
            var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#list").jqGrid('getRowData', id);

            var CheckRequest = new Object();
            CheckRequest.ID = id;
            CheckRequest.LoggedEmpID = $('#hdnLoggedEmpID').val();
            CheckRequest.RoleName = $('#hdnRoleName').val();
            CheckRequest.RecruitmentLoggerType = $('#hdnLoginType').val();
            CheckRequest.LoggedUserID = $('#hdnLoggedUserID').val();

            var CheckResponse = SendApplicationRequest('<%=RecruitmentAppCommands.CHECK_LOGGED_EMP_IN_TECHNICAL_PANEL%>', CheckRequest, true);

            if (CheckResponse.ResponseObject == true) {
                document.getElementById('btnschedule').style.display = "";
                document.getElementById('btnupdate').style.display = "";
                DisableIsCanidateAvailable();
            }
            else {
                document.getElementById('btnschedule').style.display = "none";
                document.getElementById('btnupdate').style.display = "none";
                EnableIsCanidateAvailable();
            }

            if ($('#hdnRoleName').val() == "HR"
                    && CheckResponse.ResponseObject == false
                    && (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedSecondFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.HRScheduledFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail3FULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail3FULL%>")) {
                document.getElementById('btnschedule').style.display = "";
                document.getElementById('btnupdate').style.display = "";
            }

            if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedFirstFULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedSecondFULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedHRFULL%>") {
                document.getElementById('btnviewform').style.display = "";
            }
            else
                document.getElementById('btnviewform').style.display = "none";
           
                
            var IDRequest = new Object();
            IDRequest.ID = ret.candidateid;

            var IDResponse = SendApplicationRequest("<%=RecruitmentAppCommands.GET_CANDIDATE_DETAILS_BY_ID%>", IDRequest, '');
            if(IDResponse.ResponseObject.CreatedBy == $('#hdnLoggedUserID').val()){
                EnableIsCanidateAvailable();
            }
            

            $("#hdnlocalvar").val(CheckResponse.ResponseObject);
        }

        Response.ResponseObject.caption = "Interview Schedule";
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
        $("#t_list").append("<button type='button' id='btnschedule' value='Schedule Interview' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/schedule_interview.png' height=18px;width=18px alt='' /><br/><div></div><span>Schedule Interview</span></button>");
        $("#t_list").append("<button type='button' id='btncheckavail' value='Candidate Availability' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/candidate_awaiting.png' height=18px;width=18px alt='' /><br/><div></div><span>Candidate Availability</span></button>");
        $("#t_list").append("<button type='button' id='btnupdate' value='Update Result' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/update_results.png' height=18px;width=18px alt='' /><br/><div></div><span>Update Result</span></button>");
        $("#t_list").append("<button type='button' id='btnviewform' value='View Result' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view_result.png' height=18px;width=18px alt='' /><br/><div></div><span>View Result</span></button>");
        
//        $("#t_list").append("<input type='button' id='btnschedule' value='Schedule Interview' style='font-size:12px;font-family:arial;margin:10px;'/> ");
//        $("#t_list").append("<input type='button' id='btncheckavail' value='Candidate Availability' style='font-size:12px;font-family:arial'/> ");
//        $("#t_list").append("<input type='button' id='btnupdate' value='Update Result' style='font-size:12px;font-family:arial'/> ");
//        $("#t_list").append("<input type='button' id='btnviewform' value='View Result' style='font-size:12px;font-family:arial'/> ");

        $("button ,input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "btnschedule") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if (id) {
                    if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.SalaryFixedFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.OfferIssuedFULL%>") {
                        alert('Candidate is already hired ');
                        return;
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvailFULL%>"
                        || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail2FULL%>"
                        || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail3FULL%>") {
                        alert('Cannot Schedule as candidate already available for Interview');
                        return;
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedFirstFULL%>") {
                        alert('Cannot Schedule as candidate cleared First Round');
                        return;
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedSecondFULL%>"
                        && $('#hdnRoleName').val() != "HR") {
                        alert('Cannot Schedule as candidate cleared Second Round');
                        return;
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedHRFULL%>") {
                        alert('Cannot Schedule as candidate cleared HR Round');
                        return;
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApproveFULL%>"
                        || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduledFULL%>"
                        || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvailFULL%>"
                        || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove2FULL%>"
                        || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled2FULL%>"
                        || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail2FULL%>"
                        || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.HRScheduledFULL%>"
                        || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail3FULL%>"
                        || (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedSecondFULL%>"
                        && $('#hdnRoleName').val() == "HR")) {
                        document.getElementById('divInterview').style.display = "";
                        $('#divInterview').dialog({
                            height: 350,
                            width: 670,
                            modal: true,
                            title: "Interview Schedule"
                        });

                        if ($('#hdnRoleName').val() == "HR") { 
                            if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.HRScheduledFULL%>"
                            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail3FULL%>") {
                                fillInterviewData();
                            }
                            else {
                                ClearFields();
                                CmbInterviewTypeWithoutPrevRounds(ret.id);
                            }
                        }
                        else {
                            if (ret.interviewtypeid != 0)
                                fillInterviewData();
                            else {
                                ClearFields();
                                CmbInterviewTypeWithoutPrevRounds(ret.id);
                            }
                        }
                    }                    
                }
                else alert("Select candidate to Schedule");
            }
            else if (id.currentTarget.id == "btncheckavail") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.NewCandidate%>") {
                        alert('Candidate is not yet shortlisted for Interview');
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApproveFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove2FULL%>") {
                        alert('Candidate is not yet scheduled for Interview');
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduledFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled2FULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.HRScheduledFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvailFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvailFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail2FULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail2FULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail3FULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail3FULL%>") {
                        document.getElementById('divCandidateAvail').style.display = "";
                        $('#divCandidateAvail').dialog({
                            height: 150,
                            width: 300,
                            modal: true,
                            title: "Candidate Availability"
                        });
                        if (ret.iscandidateavail == 'False') { $("#chkiscandavail").attr('checked', false); }
                        else { $("#chkiscandavail").attr('checked', true); }
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedFirstFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedSecondFULL%>") {
                        alert('Candidate is already assigned to Interview');
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedHRFULL%>") {
                        alert('Candidate already cleared all rounds');
                        return;
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.SalaryFixedFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.OfferIssuedFULL%>") {
                        alert('Candidate is already hired ');
                    }                    
                }
                else
                    alert("Select candidate to Check Availability");
            }
            else if (id.currentTarget.id == "btnupdate") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.SalaryFixedFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.OfferIssuedFULL%>") {
                        alert('Candidate is already hired ');
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedFirstFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedSecondFULL%>") {
                        alert('Candidate processed for further round ');
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvailFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail2FULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail3FULL%>") {
                        window.location.href = "default.aspx?serve=CandidateInterviewForm&CandidateID=" + ret.candidateid;
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedHRFULL%>") {
                        alert('Candidate already cleared all rounds');
                    }
                    else
                        alert('Candidate not yet confirmed for interview');
                }
                else alert("Select candidate to Update Interview Result");
            }
            else if (id.currentTarget.id == "btnviewform") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    window.location.href = "default.aspx?serve=CandidateInterviewForm&CandidateID=" + ret.candidateid + "&mode=view";
                }
                else alert("Select candidate to View Interview Result");
            }

        });
//        var mygrid = jQuery('#list'),
//        cDiv = mygrid[0].grid.cDiv;
//        mygrid.setCaption("");
//        $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
//        $(cDiv).hide();
//        $("#list").closest(".ui-jqgrid-bdiv").height("auto");
        var validator = $("#frmInterviewSchedule").validate({
            rules: {
                cmbinterviewtype: {
                    required: true
                }
            },
            messages: {
                cmbinterviewtype: {
                    required: "Select InterviewType"
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {

                if (ValidateDateTime()) {

                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);

                    var Request = new Object();
                    Request.ID = ret.id;
                    Request.InterviewTypeID = $('#cmbinterviewtype').val();
                    Request.Date1Time1 = $('#date1').val();
                    Request.Time1 = $('#intTime1').val() + ":00";
                    Request.Date2Time2 = $('#date2').val();
                    Request.Time2 = $('#intTime2').val() + ":00";
                    Request.UpdatedBy = $('#hdnLoggedUserID').val();
                    Request.RoleName = $('#hdnRoleName').val();

                    if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApproveFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduledFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvailFULL%>") {
                        Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled%>";
                    }
                    else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ManagerApprove2FULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled2FULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail2FULL%>") {
                        Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled2%>";
                    }
                    else if ((ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.ClearedSecondFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.HRScheduledFULL%>"
                    || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail3FULL%>")
                        && $('#hdnRoleName').val() == "HR") {
                        Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.HRScheduled%>";
                    }

                    var Response = SendApplicationRequest('<%=RecruitmentAppCommands.UPDATE_INTERVIEW_SCHEDULED_STATUS%>', Request, true);
                    if (Response.ResponseCommand == 'SUCCESS') {

                        var Request1 = new Object();
                        Request1.InterviewStatusID = ret.id;
                        Request1.ManagerID = ret.teamid;
                        Request1.RoleName = $('#hdnRoleName').val();
                        Request1.InterviewTypeID = $('#cmbinterviewtype').val();
                        var Response1 = SendApplicationRequest('<%=RecruitmentAppCommands.NOTIFY_PREFFERED_DATETIME%>', Request1, true);

                        alert(Response.Message);
                        CloseInterviewScheduleDialog();
                        ReloadMainGrid();
                    }
                }
            }
        });
    });

    function LoadInterviewType() {
        $("#cmbinterviewtype").empty();
        
        var Response = SendApplicationRequest("<%=HRAppCommands.INTERVIEWTYPE_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Choose Interview Type";
        optn.value = "";
        document.getElementById('cmbinterviewtype').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbinterviewtype').options.add(optn);
            }
        }
    }

    function CmbInterviewTypeWithoutPrevRounds(interviewSTATUSid) {
        $("#cmbinterviewtype").empty();

        var Request = new Object();
        Request.ID = interviewSTATUSid;
        var Response = SendApplicationRequest("<%=RecruitmentAppCommands.INTERVIEWTYPE_COMBO_BY_STATUSID%>", Request);

        var optn = document.createElement("OPTION");
        optn.text = "Choose Interview Type";
        optn.value = "";
        document.getElementById('cmbinterviewtype').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbinterviewtype').options.add(optn);
            }
        }
    }

    function CloseInterviewScheduleDialog() {
        ClearFields();
        $('#divInterview').dialog('close');
    }

    function ResetDateTime() {
        $('#date1').val("");
        $('#intTime1').val("");
        $('#date2').val("");
        $('#intTime2').val("");
    }

    function CloseCandAvialDialog() {
        $('#divCandidateAvail').dialog('close');
    }

    function SaveCandAvialDialog() { 
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);

        var Request = new Object();
        Request.ID = ret.id;
        Request.InterviewTypeID = ret.interviewtypeid;
        
        var datetimesplit1 = (ret.date1time1).split(' ');
        
        Request.Date1Time1 = datetimesplit1[0];
        Request.Time1 = datetimesplit1[1];
        
        var datetimesplit2 = (ret.date2time2).split(' ');
        
        Request.Date2Time2 = datetimesplit2[0];
        Request.Time2 = datetimesplit2[1];
        Request.UpdatedBy = $('#hdnLoggedUserID').val();

        if ($("#chkiscandavail").is(':checked')) {
            Request.IsCandidateAvail = true;
            if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled2FULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail2FULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail2FULL%>") {
                Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail2%>";
            }
            else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduledFULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvailFULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvailFULL%>") {
                Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail%>";
            }
            else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.HRScheduledFULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail3FULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail3FULL%>") {
                Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail3%>";
            }
        }
        else {
            Request.IsCandidateAvail = false;
            if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduled2FULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail2FULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail2FULL%>") {
                Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail2%>";
            }
            else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.InterviewScheduledFULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvailFULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvailFULL%>") {
                Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail%>";
            }
            else if (ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.HRScheduledFULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateAvail3FULL%>"
            || ret.candidatestatus == "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail3FULL%>") {
                Request.CandidateStatus = "<%=HRManager.Entity.Recruitment.CandidateStatusDescription.CandidateUnAvail3%>";
            }
        }

        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.UPDATE_AVAILABILITY_STATUS%>', Request, true);
        if (Response.ResponseCommand == 'SUCCESS') {
            
            var Request1 = new Object();
            Request1.InterviewStatusID = ret.id;
            Request1.ManagerID = ret.teamid;
            if ($("#chkiscandavail").is(':checked')) {
                Request1.IsCandAvail = true;
            }
            else {
                Request1.IsCandAvail = false;
            }
            Request1.InterviewTypeID = ret.interviewtypeid;
            Request1.Role = $('#hdnRoleName').val();
            
            var Response1 = SendApplicationRequest('<%=RecruitmentAppCommands.NOTIFY_CANDIDATE_AVAILABILITY%>', Request1, true);
            alert(Response.Message);
            CloseCandAvialDialog();
            ReloadMainGrid();
        }
    }

    function fillInterviewData() { 
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);

            $('#cmbinterviewtype').val(ret.interviewtypeid);
            $('#cmbinterviewtype').attr("disabled", true);

            if (ret.date1time1 != "") {
                var datetimesplit1 = (ret.date1time1).split(' ');
                var checkchar = datetimesplit1[0].substring(2, 3);
                var datesplit1 = datetimesplit1[0].split(checkchar);
                var timesplit1 = datetimesplit1[1].split(':');
                $('#date1').val(datesplit1[0] + checkchar + datesplit1[1] + checkchar + datesplit1[2]);
                $('#intTime1').val(timesplit1[0] + ':' + timesplit1[1]);
            }
            if (ret.date2time2 != "") {
                var datetimesplit2 = (ret.date2time2).split(' ');
                var checkchar = datetimesplit2[0].substring(2, 3);
                var datesplit2 = datetimesplit2[0].split(checkchar);
                var timesplit2 = datetimesplit2[1].split(':');
                $('#date2').val(datesplit2[0] + checkchar + datesplit2[1] + checkchar + datesplit2[2]);
                $('#intTime2').val(timesplit2[0] + ':' + timesplit2[1]);
            }
    }

    function ClearFields() {
        $('#cmbinterviewtype').val("");
        $('#cmbinterviewtype').attr("disabled", false);
        $('#date1').val("");
        $('#intTime1').val("");
        $('#date2').val("");
        $('#intTime2').val("");
    }

    function ReloadMainGrid() {
        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        var Request = new Object();
        Request.LoggedEmpID = $('#hdnLoggedEmpID').val();
        Request.LoggedUserID = $('#hdnLoggedUserID').val();
        Request.RoleName = $('#hdnRoleName').val();

        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.GET_INTERVIEW_STATUS_GRID%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").trigger('reloadGrid');
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
    }

    function DisableIsCanidateAvailable() {
        $("#chkiscandavail").attr("disabled", "disabled");
        $("#bnSaveCandAvial").attr("disabled", "disabled");
    }

    function EnableIsCanidateAvailable() {
        $("#chkiscandavail").attr("disabled", false);
        $("#bnSaveCandAvial").attr("disabled", false);
    }

    function ValidateDateTime() {
        if ($('#date1').val() == "" && $('#intTime1').val() == "" && $('#date2').val() == "" && $('#intTime2').val() == "") {
            alert('Please Select atleast one DateTime');
            return false;
        }
        else if ($('#date1').val() == "" && $('#intTime1').val() != "") {
            alert('Please Select Date1 as Time1 is selected');
            return false;
        }
        else if ($('#date1').val() != "" && $('#intTime1').val() == "") {
            alert('Please Select Time1 as Date1 is selected');
            return false;
        }
        else if ($('#date2').val() == "" && $('#intTime2').val() != "") {
            alert('Please Select Date2 as Time2 is selected');
            return false;
        }
        else if ($('#date2').val() != "" && $('#intTime2').val() == "") {
            alert('Please Select Time2 as Date2 is selected');
            return false;
        }
        return true;
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
