<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateInterviewForm.aspx.cs" Inherits="AltioStarHR.Recruitment.CandidateInterviewForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>Candidate Evaluation Form</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" /> 
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    
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
        <img alt="" src="Resources/Images/NewImages/1.png"style="width:97%;margin-left:1%;height:53px;margin-top:0%"/>
            <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
                <strong class="family1 imageheadercolor">Candidate Evaluation Form</strong>
            </div>
    </div>
    
    <div id="divInterviewForm" style="width:100%;">
        <form id="frmInterviewUpdate" method="get" action="">
        <fieldset style="width: 97%;margin-left:1%;margin-top:0%">
            <table style="width:100%;background-color:#a4cd0f">
                <tr>
                    <td>
                        <label id="lcandidatename" class="family">Candidate Name</label>
                    </td>
                    <td>
                        <input type="text" id="candidatename" name="candidatename" disabled style=" width:225px; border:1px solid silver" class="family"/>
                    </td>
                    <td id="scandidatename" class="family">
                    </td>
                    
                    <td>
                        <label id="ljobtitle" class="family">Job Title</label>
                    </td>
                    <td>
                        <input type="text" id="jobtitle" name="jobtitle" style=" width:225px; border:1px solid silver" class="family"/>
                    </td>
                    <td id="sjobtitle" class="family">
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lcmbinterviewer" class="family">Interviewers Name</label>
                    </td>
                    <td>
                        <select id="cmbinterviewer" name="cmbinterviewer" style=" width:225px; border:1px solid silver" class="family"></select>
                    </td>
                    <td  id="scmbinterviewer" class="family">
                    </td>
                    
                    <td> 
                        <label id="linterviewdate" class="family">Interview Date</label>
                    </td>
                    <td>
                        <input type="text" id="interviewdate" name="interviewdate" readonly style=" width:225px; border:1px solid silver" class="family"/>
                    </td>
                    <td id="stime1" class="family">
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <label id="lratingdescp" class="family"></label>
                    </td>
                </tr>
                <tr>
                    <td class="dvGrid" colspan="6" style="margin-left:2%;" id="box">
                        <table id="list"></table>
                        <div id="pager"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <label id="lsandw" class="family">Strengths, Weaknesses and Other Considerations</label>
                    </td>
                    <td colspan="3">
                        <textarea id="sandw" rows="3" cols="30"style="border:1px solid silver;width:300px" class="family"></textarea>
                    </td>
                    <td id="ssandw" class="family">
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lrecommendation" class="family">Recommendation</label>
                    </td>
                    <td>
                    <label>
                        <input type="radio" name="rdbRecommendation" checked="checked" id="rdbhire" class="radioClear family" />
                        <b class="family">Hire</b></label>
                    </td>
                    <td colspan="2">
                        <label>
                            <input type="radio" name="rdbRecommendation" id="rdbnothire" class="radioClear" class="family"/>
                            <b class="family">Do not Hire</b>
                        </label>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <br />
            <table>
                <tr align="center">
                    <td>
                        <input id="brnsave" name="save" type="submit" value="Save" class="family" />
                    </td>
                    <td>
                        <input id="btncancel" name="cancel" type="button" value="Cancel" onclick="RedirectToInterviewSchedule()" class="family"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        </form>
    </div>
   
    <form id="frm1" runat="server">
        <input type="hidden" id="hdnLoggedUserID" runat="server" />
        <input type="hidden" id="hdnLoggedEmpID" runat="server" />
        <input type="hidden" id="hdnCandidateID" runat="server" />        
        <input type="hidden" id="hdnRoleName" runat="server"  />
        <input type="hidden" id="hdnMode" runat="server"  />
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
    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)'); 
    var mode = "";
    var activeStatus = true;
    jQuery(document).ready(function() {
        LoadInterviewer();
        document.getElementById('lratingdescp').innerHTML = " Based on your interview, evaluate the candidate for overall fit and qualifications for the job position using the following metrics:  "
            + "<br/>"
            + "<br/>"
            + "<b><u>Rating:</u></b>"
            + "<br/>"
            + "     5- Candidate is extremely well qualified or possess mastery in all areas interviewed and should consistently exceed expectations"
            + "<br/>"
            + "     4- Candidate is very well qualified in the areas interviewed and should meet or exceed expectations"
            + "<br/>"
            + "     3- Candidate fits all of the requirements in the areas interviewed"
            + "<br/>"
            + "     2- Candidate fits some of the requirements in the areas interviewed"
            + "<br/>"
            + "     1- Candidate does not fit the requirements in the areas interviewed";


        $("#interviewdate").datepicker({
            showOn: "button",
            buttonImage: "Resources/Images/calendar.gif",
            buttonImageOnly: true,
            changeMonth: true,
            changeYear: true,
            showTimePicker: false,
            yearRange: '1930:2050'
        });
        $("#interviewdate").datepicker("option", "dateFormat", 'dd/mm/yy');

        var myGrid = $('#list');

        var Request = new Object();
        Request.ID = $('#hdnLoggedEmpID').val();
        Request.ChangedBy = $('#hdnCandidateID').val();

        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.GET_INTERVIEW_RESULT_GRID%>', Request, true); 
        TempResponse = Response;
        
        Response.ResponseObject.colNames = ["ID", "MCCID", "CandidateID", "CandidateName", "JobTitle", "InterviewerID",
             "InterviewDate", "Competency", "5", "4", "3", "2", "1", "N/A", "StrengthandWeakness", "Recommendation"];
             
        
        Response.ResponseObject.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'mccompetencyid', index: 'mccompetencyid', width: 100, editable: true, hidden: true, sortable: false },
            { name: 'candidateid', index: 'candidateid', width: 100, editable: true, hidden: true, sortable: false },
            { name: 'candidatename', index: 'candidatename', width: 100, editable: true, hidden: true, sortable: false },
            { name: 'jobtitle', index: 'jobtitle', width: 100, editable: true, hidden: true, sortable: false },
            { name: 'interviewerid', index: 'interviewerid', width: 90, editable: true, hidden: true, sortable: false },
            { name: 'interviewdate', index: 'interviewdate', width: 100, editable: true, hidden: true, sortable: false },
            { name: 'competency', index: 'competency', width: 300, editable: true, sortable: false },
            { name: 'value1', index: 'value1', width: 40, editable: true, sortable: false, formatter: radio, edittype: 'custom', align: 'center' },
            { name: 'value2', index: 'value2', width: 40, editable: true, sortable: false, formatter: radio, edittype: 'custom', align: 'center' },
            { name: 'value3', index: 'value3', width: 40, editable: true, sortable: false, formatter: radio, edittype: 'custom', align: 'center' },
            { name: 'value4', index: 'value4', width: 40, editable: true, sortable: false, formatter: radio, edittype: 'custom', align: 'center' },
            { name: 'value5', index: 'value5', width: 40, editable: true, sortable: false, formatter: radio, edittype: 'custom', align: 'center' },
            { name: 'value6', index: 'value6', width: 40, editable: true, sortable: false, formatter: radio, edittype: 'custom', align: 'center' },
            { name: 'sandw', index: 'sandw', width: 30, editable: true, hidden: true },
            { name: 'recommendation', index: 'recommendation', width: 30, editable: true, hidden: true },
        ];

        Response.ResponseObject.beforeSelectRow = function(rowid, e) { 

            if ($(e.target).is('input[type="radio"]')) {

                var Check = rowCheck(rowid);
                var ret = jQuery("#list").jqGrid('getRowData', rowid);
                var iCol = $.jgrid.getCellIndex($(e.target).closest("td")[0]);
                var cm = $(this).jqGrid("getGridParam", "colModel");
                var ids = 'rdb_' + rowid + '_' + cm[iCol].name;

                for (d = 8; d <= 13; d++) {
                    TempResponse.ResponseObject.datastr.rows[Check].cell[d] = "False";
                }
                if ($('#' + ids).is(':checked')) {
                    TempResponse.ResponseObject.datastr.rows[Check].cell[iCol - 1] = "True"
                }
            }
        }

        Response.ResponseObject.autowidth = true;
        Response.ResponseObject.caption = "Interview Result";
        Response.ResponseObject.rowNum = 40;
        Response.ResponseObject.pager = "";
        Response.ResponseObject.scroll = true;
        var he = $(window).height();
        var reduce = he * 0.60;
        Response.ResponseObject.height = reduce;
        myGrid.jqGrid(Response.ResponseObject);

        if (Response.ResponseObject.datastr.rows[0].cell[3] == "") {
            var CandRequest = new Object();
            CandRequest.ID = $('#hdnCandidateID').val();

            var CandResponse = SendApplicationRequest('<%=RecruitmentAppCommands.GET_CANDIDATE_DETAILS_BY_ID%>', CandRequest, true);
            if (CandResponse.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                var CandName = CandResponse.ResponseObject.FirstName
                        + ' ' + CandResponse.ResponseObject.MiddleName
                        + ' ' + CandResponse.ResponseObject.LastName;
                $('#candidatename').val(CandName);
            }
        }
        else {
            $('#candidatename').val(Response.ResponseObject.datastr.rows[0].cell[3]);
        }

        $('#jobtitle').val(Response.ResponseObject.datastr.rows[0].cell[4]);
        $('#cmbinterviewer').val($('#hdnLoggedEmpID').val());

        $('#interviewdate').val(Response.ResponseObject.datastr.rows[0].cell[6]);
        $('#sandw').val(Response.ResponseObject.datastr.rows[0].cell[14]);

        if (Response.ResponseObject.datastr.rows[0].cell[15] == "HR")
            $('#rdbhire').attr('checked', true);
        else if (Response.ResponseObject.datastr.rows[0].cell[15] == "NH")
            $("#rdbnothire").attr('checked', true);

        $("#t_list").closest(".ui-userdata").hide();

        var validator = $("#frmInterviewUpdate").validate({
            rules: {
                candidatename: {
                    required: true
                },
                jobtitle: {
                    required: true
                },
                cmbinterviewer: {
                    required: true
                },
                interviewdate: {
                    required: true
                }
            },
            messages: {
                candidatename: {
                    required: "Enter CandidateName"
                },
                jobtitle: {
                    required: "Enter Job Title"
                },
                cmbinterviewer: {
                    required: "Select Interviewer"
                },
                interviewdate: {
                    required: "Select Interview Date"
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {

                var DateRequest = new Object();
                DateRequest.InterviewDateFromPage = $('#interviewdate').val();
                DateRequest.CanidateID = $('#hdnCandidateID').val();

                var DateResponse = SendApplicationRequest('<%=RecruitmentAppCommands.INTERVIEW_DATE_VALIDATE%>', DateRequest, true);

                if (DateResponse.ResponseCommand == 'SUCCESS') {
                    var allRowsInGrid = TempResponse.ResponseObject.datastr.rows;
                    var CIRIds = allRowsInGrid[0].cell[0];
                    var CompetencyIds = allRowsInGrid[0].cell[1];
                    var Value1s = allRowsInGrid[0].cell[8];
                    var Value2s = allRowsInGrid[0].cell[9];
                    var Value3s = allRowsInGrid[0].cell[10];
                    var Value4s = allRowsInGrid[0].cell[11];
                    var Value5s = allRowsInGrid[0].cell[12];
                    var Value6s = allRowsInGrid[0].cell[13];

                    for (r = 1; r < allRowsInGrid.length; r++) {
                        CompetencyIds = CompetencyIds + "," + allRowsInGrid[r].cell[1];
                        CIRIds = CIRIds + "," + allRowsInGrid[r].cell[0];
                        Value1s = Value1s + "," + allRowsInGrid[r].cell[8];
                        Value2s = Value2s + "," + allRowsInGrid[r].cell[9];
                        Value3s = Value3s + "," + allRowsInGrid[r].cell[10];
                        Value4s = Value4s + "," + allRowsInGrid[r].cell[11];
                        Value5s = Value5s + "," + allRowsInGrid[r].cell[12];
                        Value6s = Value6s + "," + allRowsInGrid[r].cell[13];
                    }

                    var Request = new Object();
                    Request.CIRID = CIRIds;
                    Request.CandidateID = $('#hdnCandidateID').val();
                    Request.JobTitle = $('#jobtitle').val();
                    Request.InterviewerID = $('#cmbinterviewer').val();
                    Request.InterviewDate = $('#interviewdate').val();
                    Request.StrengthandWeakness = $('#sandw').val();
                    Request.UpdatedBy = $('#hdnLoggedUserID').val();
                    Request.CompetencyID = CompetencyIds;
                    Request.Value1 = Value1s;
                    Request.Value2 = Value2s;
                    Request.Value3 = Value3s;
                    Request.Value4 = Value4s;
                    Request.Value5 = Value5s;
                    Request.Value6 = Value6s;

                    if ($("#rdbhire").is(':checked'))
                        Request.Recommendation = "HR";
                    else if ($("#rdbnothire").is(':checked'))
                        Request.Recommendation = "NH";

                    var Response = SendApplicationRequest('<%=RecruitmentAppCommands.UPDATE_INTERVIEW_RESULT%>', Request, true);
                    if (Response.ResponseCommand == 'SUCCESS') {

                        var Request1 = new Object();
                        Request1.CandidateID = $('#hdnCandidateID').val();
                        Request1.Role = $('#hdnRoleName').val();

                        var Response1 = SendApplicationRequest('<%=RecruitmentAppCommands.NOTIFY_INTERVIEW_RESULT%>', Request1, true);

                        alert(Response.Message);
                        RedirectToInterviewSchedule();
                    }
                }
                else
                    alert(DateResponse.Message);
            }
        });
        if ($('#hdnMode').val() == "view") {
            DisableAllFields();
        }
        else {
            EnableAllFields();
        }
    });

    function rowCheck(ROWID) {
        var rowlenght = TempResponse.ResponseObject.datastr.rows.length;

        for (i = 0; i < rowlenght; i++) {
            if (TempResponse.ResponseObject.datastr.rows[i].cell[1] == ROWID) {
                return i;
            }
        }
    }

    function radio(value, options, rowObject) { 
        var chkd = '';
        if (value == "True") chkd = 'checked';
        var radioHtml = '<input type="radio" ' + chkd + '  name="radioid' + rowObject[1] + '" id="rdb_' + rowObject[1] + '_' + options.colModel.name + '"/>';
        return radioHtml;
    }

    function LoadInterviewer() {
        var Request = new Object();
        Request.ID = $('#hdnCandidateID').val();

        var Response = SendApplicationRequest("<%=RecruitmentAppCommands.GET_INTERVIEW_COMBO_FOR_CANDIDATE%>", Request); 
        var optn = document.createElement("OPTION");
        optn.text = "Choose Interviewer";
        optn.value = "";
        document.getElementById('cmbinterviewer').options.add(optn); 
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                if (arr[i]['ID'] != 0) {
                    optn.text = arr[i]['Value'];
                    optn.value = arr[i]['ID'];
                    document.getElementById('cmbinterviewer').options.add(optn);
                }
            }
        }

        if ($('#hdnRoleName').val() == "HR") {
            var Response1 = SendApplicationRequest("<%=RecruitmentAppCommands.GET_HR_COMBO%>", Request); 
            if (Response1.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                var arr = Response1.ResponseObject;
                for (var i = 0; i < arr.length; ++i) {
                    var optn1 = document.createElement("OPTION"); 
                    if (arr[i]['ID'] != 0) {
                        optn1.text = arr[i]['Value'];
                        optn1.value = arr[i]['ID'];
                        document.getElementById('cmbinterviewer').options.add(optn1);
                    }
                }
            }
        }
    }

    function RedirectToInterviewSchedule() {
        window.parent.ChildWB.frameElement.src = "default.aspx?serve=InterviewSchedule";
    }

    function DisableAllFields() {
        $('#jobtitle').attr("disabled", true);
        $('#cmbinterviewer').attr("disabled", true);
        $('#interviewdate').attr("disabled", true);
        $('#sandw').attr("disabled", true);
        $('#rdbRecommendation').attr("disabled", true);
        $('#brnsave').attr("disabled", true);
        $('#list').attr("disabled", true);
    }

    function EnableAllFields() {
        $('#jobtitle').attr("disabled", false);
        $('#cmbinterviewer').attr("disabled", false);
        $('#interviewdate').attr("disabled", false);
        $('#sandw').attr("disabled", false);
        $('#rdbRecommendation').attr("disabled", false);
        $('#brnsave').attr("disabled", false);
        $('#list').attr("disabled", false);
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

