<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateApplication.aspx.cs" Inherits="AltioStarHR.Recruitment.CandidateApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>Candidate Application</title>
    <link href="../Resources/css/datePicker.css" rel="stylesheet" type="text/css" />
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
        #uploadresume
        {
            width: 328px;
        }
        .MedTextCalibri
        {
        	font-family:Calibri;font-size:medium
        }
            </style>
</head>
<body>
<%--     <div>
        <div class="header_title2">
            Candidate</div>
    </div>--%>
    <div style="position:relative;width: 100%" >
    <img alt="" src="Resources/Images/NewImages/1.png" style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
    <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
    <strong class="family1 imageheadercolor">Candidate Application Details</strong>
    </div>
    </div>
    
        <div id="divCandidate" style="width: 97%;margin-left:2%">
            <form id="signupForm" runat="server">
                <fieldset >
                    <legend class="family">Manager Details</legend>
                    <table id="tblteam" style="width:100%;border:1px solid silver;background-color:#a4cd0f">
                        <tr >
                            <td style="width:5%">
                                <label id="lcmbteam" class="family">Team</label>
                                <span id="vcmbteam" style="color:Red;"> *</span>
                            </td>
                            <td>
                                <select id="cmbteam" onchange="LoadTeamManager()" style="border:1px solid silver;" class="family"></select>
                            </td>
                        </tr>
                        <tr>   
                            <td >
                                <label id="lmanager" class="family">Manager-</label>
                            </td>
                            <td> 
                                <b><label id="manager" class="family" ></label></b>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend class="family">Candidate Form</legend>
                    <table style="width: 100%;border:1px solid silver;background-color:#a4cd0f">
                        <tr>
                            <td colspan="6">
                               <label id="lcmbcandidatetype" class="family">Candidate Type</label> 
                               <span id="vcmbcandidatetype" style="color:Red;"> *</span>
                               <select id="cmbcandidatetype" style="border:1px solid silver;" class="family">
                                    <option id="oselectcand" value="" >Select CandidateType</option>
                                    <option id="ofresher" value="F" >Fresher</option>
                                    <option id="oexperienced" value="E" >Experienced</option>                                
                                </select>     
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <table id="tblname" >
                                    <tr>
                                        <td style="white-space:nowrap;">
                                            <label id="lfirstname" class="family">First Name</label>
                                            <span id="vfirstname" style="color:Red;"> *</span>
                                        </td>
                                        <td>
                                            <input id="firstname" type="text" maxlength="150" runat="server" style="width:180px;border:1px solid silver;" class="family"/>
                                        </td>
                                        
                                        <td style="white-space:nowrap">
                                            <label id="lmiddlename" class="family">Middle Name</label>
                                        </td>
                                        <td>
                                            <input id="middlename" type="text" maxlength="150" runat="server" style="width:180px;border:1px solid silver;" class="family"/>
                                        </td>
                                        
                                        <td style="white-space:nowrap">
                                            <label id="llastname" class="family">Last Name</label>
                                            <span id="Span1" style="color:Red;"> *</span>
                                        </td>
                                        <td colspan="2">
                                            <input id="lastname" type="text" maxlength="150" runat="server" style="width:180px;border:1px solid silver;" class="family"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                            <div style="background-color:#00daf5;width:98%;margin-left:0%;height:25px;padding-left:2%;font-family:Arial;font-weight:bold;color:White">Education Details</div>
                            <div id="box">
                                <table id="list"></table>
                                <div id="pager"></div>
                            </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label id="lcurentemployer" class="family">Current Employer</label>
                            </td>
                            <td >
                                <textarea cols="20" rows="3" id="curentemployer" runat="server" style="border:1px solid silver;width:300px" class="family"></textarea>
                            </td>
                            <td colspan="2">
                                <label id="lstartdate" class="family">Career Start Date</label>
                            </td>
                            <td >
                                <input id="startdate" type="text" runat="server" style="width:205px;border:1px solid silver;"  disabled="disabled" class="family"/>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <label id="lexperience" class="family">Experience in Current Organisation</label>
                            </td>
                            <td >
                                <textarea cols="20" rows="3" id="experience" runat="server" style="border:1px solid silver;width:300px" class="family"></textarea>
                            </td>
                            <td colspan="2">
                                <label id="lexpertiseintech" class="family">Technology Expertise</label>
                            </td>
                            <td >
                                <textarea cols="20" rows="3" id="expertiseintech" runat="server" style="border:1px solid silver;width:300px" class="family"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <label id="lcontactno"  class="family">Contact Number</label>
                                <span id="Span3" style="color:Red;"> *</span>
                            </td>
                            <td>
                                <input id="contactno" type="text" runat="server" maxlength="15"  class="family"
                                    onkeypress="return OnlyNumbersAllowed(event)" style="width:250px;border:1px solid silver;"/>
                            </td>
                            <td colspan="2">
                                <label id="lemailid" class="family">Email ID</label>
                                <span id="Span4" style="color:Red;"> *</span>
                            </td>
                            <td>
                                <input id="emailid" type="text" runat="server" style="width:225px;border:1px solid silver;" maxlength="50" class="family"/>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <label id="lnoticeperiod" class="family">Notice Period in Days</label>
                            </td>
                            <td >
                                <input id="noticeperiod" type="text" runat="server" class="family"
                                    onkeypress="return OnlyDecimalAllowed(event)" style="width:250px;border:1px solid silver;"/>
                            </td>
                            <td colspan="2">
                                <label id="lcurrentlocation" class="family">Current Location</label>
                            </td>
                            <td>
                                <input id="currentlocation" type="text" style="width:225px;border:1px solid silver;" runat="server" maxlength="150" class="family"/>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <label id="lreason" class="family">Reason for Job Change</label>
                            </td>
                            <td >
                                <textarea cols="20" rows="3" id="reason" runat="server" style="width:300px;border:1px solid silver;" class="family"></textarea>
                            </td>
                            <td colspan="2">
                                <label id="loffers" class="family">Offers in Hand</label>
                                <span id="Span5" style="color:Red;"> *</span>
                            </td>
                            <td>
                                <input id="offers" type="text" runat="server" maxlength="200" class="family"
                                    onkeypress="return OnlyNumbersAllowed(event)" style="width:225px;border:1px solid silver;"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <fieldset>
                                    <table id="tblresumeupload">
                                        <tr>
                                            <td id="lupload" style="white-space:nowrap" class="family"><b>Upload Resume</b><span id="Span6" style="color:Red;"> *</span></td>
                                            <td>
                                                <input type="file" id="uploadresume" runat="server" style="border:1px solid silver;" />
                                            </td>
                                            <%--<td>
                                                <img id="imgUpdateResume" src="<%=ResolveUrl("~/Resources/Images/UpdateResume.jpg") %>"
                                                    height="50px" style="display:none" alt=""/>
                                            </td>--%>
                                            <td  id="trViewResume" style="display: none" onclick='return ViewUploadedResume();'>
                                                <%--<img id="img1" alt="View Proposal" height="30px" width="60px"
                                                    src="<%=ResolveUrl("~/Resources/Images/attachment.png") %>" style='cursor: pointer;' />--%>
                                                <label style='cursor: pointer;font-size:xx-small' class="family">
                                                    <b>View Resume</b></label>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr align="center">
                            <td >
                                <input id="signupsubmit" type="button" value="Save" onclick="SubmitCandidate()" class="family"/>
                            </td>
                            <td >
                                <input id="Cancel" name="Cancel" type="button" value="Cancel" onclick="RedirectToCandidateDashboard()" class="family"/>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <input type="hidden" id="hdnCandIDFromGrid" runat="server" />
                <input type="hidden" id="hdnCarierStartDate" runat="server" />
                <input type="hidden" id="hdnTeamID" runat="server" />
                <input type="hidden" id="hdnSaveResult" runat="server" />
                <input type="hidden" id="hdnCandidateType" runat="server" />
                <input type="hidden" id="hdnEducationDetails" runat="server" />
                <input type="hidden" id="hdnResumeFileName"/>
                <input type="hidden" id="hdnLoggedUserID" runat="server" />
                <input type="hidden" id="hdnIsLogEmpManager" runat="server" />
                <input type="hidden" id="hdnLoginType" runat="server" />
                <input type="hidden" id="hdnManagerID" runat="server" />
                <input type="hidden" id="hdnRoleName" runat="server" />
            </form>
            <div id="diveducation" style="display:none;background-color:White" >
                <form id="frmeducation" action="" >
                    <%--<table  class="teble_bg">--%>
                    <table  style="width: 100%;background-color:#a4cd0f">
                        <tr>
                            <td >
                                <label id="ldegree">Degree</label>
                                <span id="Span2" style="color:Red;"> *</span>
                            </td>
                            <td >
                                <input id="degree" name="degree" type="text" style="width:225px;border:1px solid silver"/>
                            </td>
                            <td></td>
                        </tr>   
                        <tr> 
                            <td >
                                <label id="lstream">Stream</label>
                                <span id="Span7" style="color:Red;"> *</span>
                            </td>
                            <td >
                                <input id="stream" name="stream" type="text" style="width:225px;border:1px solid silver"/>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td >
                                <label id="lcollege">University/College</label>
                                <span id="Span8" style="color:Red;"> *</span>
                            </td>
                            <td >
                                <input id="college" name="college" type="text" style="width:225px;border:1px solid silver"/>
                            </td>
                            <td></td>
                        </tr>
                        <tr>   
                            <td >
                                <label id="lyear">Year</label>
                                <span id="Span9" style="color:Red;"> *</span>
                            </td>
                            <td >
                                <input id="year" name="year" type="text" onkeypress="return OnlyDecimalAllowed(event)" style="width:225px;border:1px solid silver"/>
                            </td>
                            <td></td>
                        </tr>
                        <tr>    
                            <td >
                                <label id="lpercent">Percentage</label>
                                <span id="Span10" style="color:Red;"> *</span>
                            </td>
                            <td >
                                <input id="percent" name="percent" type="text" onkeypress="return OnlyDecimalAllowed(event)" style="width:225px;border:1px solid silver"/>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                    <table>
                        <tr align="center">
                            <td >
                                <input id="Button1" type="submit" value="Save" style="font-family:Arial;font-size:11px;background-color:#00DBF1;"/>
                            </td>
                            <td >
                                <input id="btncanceledu" name="btncanceledu" type="button" value="Cancel" onclick="CloseDialog()" style="font-family:Arial;font-size:11px;background-color:#00DBF1;"/>
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
        </div>
   
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

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/progress.js") %>"></script>

<script type="text/javascript">
    var Edumode = "";
    var Education = "";
    var CandidateIDFromGrid = "";
    var IsFieldsDisabled = false;
    jQuery(document).ready(function() {
        $("#signupsubmit").show();

//        debugger
//        var he = $(window).height();
//        var reduce = he * 0.70;
//        $("#divCandidate").attr("height", he);
        
        $.validator.addMethod("percentageCheck", function(value, element) {
            return this.optional(element) || /^'(100\.00|100\.0|100)|([0-9]{1,2}){0,1}(\.[0-9]{1,2}){0,1}$/i.test(value);
        }, "Only Percentage allowed");

        LoadTeam();
        
        SaveAlertMsg();
        ShowUploadedImageIcon();
        $(function() {
            $("#startdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                showTimePicker: false
            });
            $("#startdate").datepicker("option", "dateFormat", 'dd/mm/yy');
        });
        FillCandidateDetails();

        if ($("#hdnIsLogEmpManager").val() == "true") {
            IsFieldsDisabled = true;
            DisableFields();
        }

        var myGrid = $('#list');

        var Request = new Object();
        Request.ID = $('#hdnCandIDFromGrid').val();
        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.GET_CANDIDATE_EDUCATION%>', Request, true);

        Response.ResponseObject.colModel = [
            { name: 'localgridid', index: 'localgridid', width: 20, hidden: true, sorttype: "int" },
            { name: 'id', index: 'id', width: 20, hidden: true },
            { name: 'candidateid', index: 'candidateid', width: 100, editable: true, hidden: true },
            { name: 'educationname', index: 'educationname', width: 70, editable: true },
            { name: 'educationstream', index: 'educationstream', width: 50, editable: true },
            { name: 'university', index: 'university', width: 50, editable: true, hidden: true },
            { name: 'year', index: 'year', width: 50, editable: true },
            { name: 'percentage', index: 'percentage', width: 50, editable: true }
        ];

        //        Response.ResponseObject.caption = "Education Details";
        Response.ResponseObject.autowidth= true;
        myGrid.jqGrid(Response.ResponseObject);

        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

//        jQuery("#list").jqGrid('setGridWidth', "825");
        $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });
        $("#list").closest(".ui-jqgrid-bdiv").height("auto");
        //        $("#t_list").append("<input type='button' id='addedu' value='Add'  style='height:24px;font-size:-3'/> ");
        //        $("#t_list").append("<input type='button' id='editedu' value='Edit' style='height:24px;font-size:-3'/> ");
        //        $("#t_list").append("<input type='button' id='deleteedu' value='Delete' style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<button type='button' id='addedu' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><span style='font-size:12px;font-family:Calibri'>Add</span></button>");
        $("#t_list").append("<button type='button' id='editedu' value='Edit' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/edit_icon.png'height=18px;width=18px alt='' /><br/><span style='font-size:12px;font-family:Calibri'>Edit</span></button>");
        $("#t_list").append("<button type='button' id='deleteedu' value='Delete' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/delete.jpg'height=20px;width=22px alt='' /><br/><span style='font-size:12px;font-family:Calibri'>Delete</span></button>");
        $("input,button", "#t_list").click(function(id) {
            if (IsFieldsDisabled == false) {
                if (id.currentTarget.id == "addedu") {
                    validator.resetForm();
                    Edumode = "Eduadd";
                    clearEducationLabels();
                    document.getElementById("diveducation").style.display = "";
                    $('#diveducation').dialog({
                        height: 300,
                        width: 570,
                        modal: true,
                        title: "Education Details"
                    });
                }
                else if (id.currentTarget.id == "editedu") {
                    validator.resetForm();
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    if (id) {
                        Edumode = "Eduedit";
                        clearEducationLabels();
                        document.getElementById("diveducation").style.display = "";
                        $('#diveducation').dialog({
                            height: 300,
                            width: 570,
                            modal: true,
                            title: "Education Details"
                        });
                        fillEducationData();
                    }
                    else { alert("Please select a row"); }
                }
                else if (id.currentTarget.id == "deleteedu") {
                    validator.resetForm();
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                    if (id) {
                        Edumode = "Edudelete";
                        if (confirm('Do you want to delete seleted row!')) {

                            var ret = jQuery("#list").jqGrid('getRowData', id);

                            if (ret.id == 0) {
                                $('#list').jqGrid('delRowData', id);
                            }
                            else {
                                var delRequest = new Object();
                                delRequest.ID = ret.id;

                                var delResponse = SendApplicationRequest('<%=RecruitmentAppCommands.DELETE_CANDIDATE_EDUCATION%>', delRequest, true);
                                if (delResponse.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {

                                    delRequest.ID = ret.candidateid
                                    var Response = SendApplicationRequest('<%=RecruitmentAppCommands.GET_CANDIDATE_EDUCATION%>', delRequest, true);
                                    if (Response.ResponseObject.datastr == null)
                                        jQuery("#list").jqGrid('clearGridData');
                                    else {
                                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                        //                                        jQuery("#list").jqGrid('setCaption', "Education Details").trigger('reloadGrid');
                                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                                    }
                                }
                            }
                        }
                    }
                    else { alert("Please select a row"); }
                }
            }
        });

        var validator = $("#frmeducation").validate({
            rules: {
                degree: {
                    required: true
                },
                stream: {
                    required: true
                },
                college: {
                    required: true
                },
                year: {
                    required: true,
                    minlength: 4,
                    maxlength: 4
                },
                percent: {
                    required: true,
                    max: 100
                }
            },

            messages: {
                degree: {
                    required: "Enter Degree"
                },
                stream: {
                    required: "Enter Stream"
                },
                college: {
                    required: "Enter College"
                },
                year: {
                    required: "Enter Completion Year",
                    minlength: "Enter atleast 4 digits",
                    maxlength: "Maximum 4 numbers allowed"
                },
                percent: {
                    required: "Enter Overall Percentage",
                    max: "Value cannot exceed 100"
                }
            },

            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },

            submitHandler: function(id) {
                if (Edumode == "Eduadd") {
                    if (checkUnique("#list", "#degree", 0, "educationname", 'Entered Degree')) {
                        var DataCount = $("#list").getGridParam("reccount");
                        var myAddData = [{
                            localgridid: DataCount + 1,
                            id: 0,
                            candidateid: $('#hdnCandIDFromGrid').val(),
                            educationname: $('#degree').val(),
                            educationstream: $('#stream').val(),
                            university: $('#college').val(),
                            year: $('#year').val(),
                            percentage: $('#percent').val()
                        }]
                        jQuery("#list").jqGrid('addRowData', "localgridid", myAddData, "first");
                    }
                    alert('Education details added successfully');
                    CloseDialog();
                }
                else if (Edumode == "Eduedit") {
                    var localgridid = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    if (checkUnique("#list", "#degree", localgridid, "educationname", 'Entered Degree')) {
                        var myEditData = {
                            localgridid: localgridid,
                            candidateid: $('#hdnCandIDFromGrid').val(),
                            educationname: $('#degree').val(),
                            educationstream: $('#stream').val(),
                            university: $('#college').val(),
                            year: $('#year').val(),
                            percentage: $('#percent').val()
                        }
                        jQuery("#list").jqGrid('setRowData', localgridid, myEditData);
                    }
                    alert('Education details updated successfully');
                    CloseDialog();
                }
            }
        });
    });

    function LoadTeam() { 
        var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Choose Team";
        optn.value = "";
        document.getElementById('cmbteam').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;

            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbteam').options.add(optn);
            }
        }
    }

    function LoadTeamManager() {
        document.getElementById('manager').innerHTML = "";
        var Request = new Object();
        Request.ID = $("#cmbteam").val();

        var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_DETAILS_BYID%>", Request, '');
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            document.getElementById('manager').innerHTML = Response.ResponseObject[0].ManagerName;
            $('#hdnManagerID').val(Response.ResponseObject[0].ManagerID);
        }
    }

    function SaveAlertMsg() {
        $.hideprogress();
        if ($('#hdnSaveResult').val() != "") {
            if ($('#hdnSaveResult').val() == "ADDED success") {
                alert('Candidate Application added successfully');
            }
            else if ($('#hdnSaveResult').val() == "UPDATED success") {
                alert('Candidate Application updated successfully');
            }
            
            RedirectToCandidateDashboard();
        }
    }

    function ShowUploadedImageIcon() {
        if ($('#hdnCandIDFromGrid').val() == 0) {
//            document.getElementById('imgUpdateResume').style.display = "none";
            document.getElementById('trViewResume').style.display = "none"; 
        }
        else {
//            document.getElementById('imgUpdateResume').style.display = "";
            document.getElementById('trViewResume').style.display = ""; 
        }
    }

    function FillCandidateDetails() {  
        var Request = new Object();
        Request.ID = $('#hdnCandIDFromGrid').val();

        var Response = SendApplicationRequest("<%=RecruitmentAppCommands.GET_CANDIDATE_DETAILS_BY_ID%>", Request, '');
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            
            $('#cmbteam').val(Response.ResponseObject.TeamID);
            LoadTeamManager();
            $('#cmbcandidatetype').val(Response.ResponseObject.CandidateType);
            $('#firstname').val(Response.ResponseObject.FirstName);
            $('#middlename').val(Response.ResponseObject.MiddleName);
            $('#lastname').val(Response.ResponseObject.LastName);
            $('#curentemployer').val(Response.ResponseObject.CurrentEmployer);
            $('#startdate').val(Response.ResponseObject.CareerStartDate);
            $('#experience').val(Response.ResponseObject.Experience);
            $('#expertiseintech').val(Response.ResponseObject.TechnologyExpertise);
            $('#contactno').val(Response.ResponseObject.ContactNumber);
            $('#emailid').val(Response.ResponseObject.EmailId);
            $('#noticeperiod').val(Response.ResponseObject.NoticePeriod);
            $('#currentlocation').val(Response.ResponseObject.CurrentLocation);
            $('#reason').val(Response.ResponseObject.ReasonForChange);
            $('#offers').val(Response.ResponseObject.OffersInHand);
            $('#hdnResumeFileName').val(Response.ResponseObject.ResumeFilename);
        }
    }

    function DisableFields() {
        $("#cmbteam").attr("disabled", "disabled");
        $("#cmbcandidatetype").attr("disabled", "disabled");
        $("#firstname").attr("disabled", "disabled");
        $("#middlename").attr("disabled", "disabled");
        $("#lastname").attr("disabled", "disabled");
        $("#curentemployer").attr("disabled", "disabled");
        $("#startdate").attr("disabled", "disabled");
        $("#experience").attr("disabled", "disabled");
        $("#expertiseintech").attr("disabled", "disabled");
        $("#contactno").attr("disabled", "disabled");
        $("#emailid").attr("disabled", "disabled");
        $("#noticeperiod").attr("disabled", "disabled");
        $("#currentlocation").attr("disabled", "disabled");
        $("#reason").attr("disabled", "disabled");
        $("#offers").attr("disabled", "disabled");
        $("#uploadresume").attr("disabled", "disabled");
//        document.getElementById('imgUpdateResume').style.display = "none";
        $("#signupsubmit").attr("disabled", "disabled");
    }

    function SubmitCandidate() {
        if (ValidateFields()) {
            
            var ext = $('#uploadresume').val().split('.').pop().toLowerCase();
            if ($('#uploadresume').val() != "" && $.inArray(ext, ['doc', 'docx', 'pdf', 'jpg', 'png', 'xls', 'xlsx']) == -1) {
                alert('invalid extension! Only DOC,DOCX,JPG,PNG,XLS,XLSX or PDF file allowed.');
                return false;
            }
            
            $("#hdnCandidateType").val($('#cmbcandidatetype').val());
            $('#hdnCarierStartDate').val($('#startdate').val());
            $('#hdnTeamID').val($('#cmbteam').val());
            StoreEducationGridDatainfo("#list")

            $.showprogress();
            $("#signupsubmit").hide();
            
            signupForm.submit();
        }
    }

    function ViewUploadedResume() { 
        var filename = $('#hdnResumeFileName').val();
        var candid = $('#hdnCandIDFromGrid').val();
        if (filename != "" && candid != 0) { 
            
            window.location.href = "DownloadFileHandler.ashx?Type=candidateresume&DocumentName=CandidateID_"+candid+ "_"+filename;
        }
        else
            alert('Uploaded file incorrect, please upload the file again');
    }

    function OnlyDecimalAllowed(e) {
        try {
            var charact = (e.keyCode) ? e.keyCode : ((e.charCode) ? e.charCode : e.which);

            if (charact == 8 || charact == 46)

                return true;

            if (charact < 48 || charact > 57) {
                charact = 0;
                return false;
            }

            return true;
        }
        catch (e) {
            return false;
        }
    }

    function OnlyNumbersAllowed(e) {
        try {
            var charact = (e.keyCode) ? e.keyCode : ((e.charCode) ? e.charCode : e.which);

            if (charact == 8)

                return true;

            if (charact < 48 || charact > 57) {
                charact = 0;
                return false;
            }

            return true;
        }
        catch (e) {
            return false;
        }
    }
    
    function ValidateFields() {
        var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
        var listlength = jQuery("#list").getDataIDs().length;
        
        if ($("#cmbteam").val() == "") {
            alert('Please select Team');
            $("#cmbteam").focus();
            return false;
        }
        else if ($("#cmbcandidatetype").val() == "") {
            alert('Please select CandidateType');
            $("#cmbcandidatetype").focus();
            return false;
        }
        else if ($("#firstname").val() == "") {
            alert('Please Enter First Name');
            $("#firstname").focus();
            return false;
        }
        else if ($("#lastname").val() == "") {
            alert('Please Enter Last Name');
            $("#lastname").focus();
            return false;
        }
        else if (listlength == 0) {
            alert('Add atleast one Education details');
            return false;
        }
        else if ($("#contactno").val() == "") {
            alert('Please Enter Contact Number');
            $("#contactno").focus();
            return false;
        }
        else if ($("#emailid").val() == "") {
            alert('Please Enter Email address');
            $("#emailid").focus();
            return false;
        }
        else if (!reg.test($("#emailid").val())) {
            alert('Invalid Email address');
            $("#emailid").focus();
            return false;
        }
        else if ($("#offers").val() == "") {
            alert('Please Enter Offers in hand');
            $("#offers").focus();
            return false;
        }
        else if ($("#uploadresume").val() == "") {
            if ($('#hdnResumeFileName').val() == "") {
                alert('Please Upload resume');
                $("#uploadresume").focus();
                return false;
            }
        }
        return true;
    }

    function RedirectToCandidateDashboard() {
        var place = (window.parent.document.getElementById('ChildWB').frameElement) ?
            window.parent.document.getElementById('ChildWB').frameElement :
            window.parent.document.getElementById('ChildWB').contentWindow.frameElement;
            
            place.src = "default.aspx?serve=CandidateDashboard";
    }
    
    function checkUnique(gridId, control, ID, colName, message) {
        var ids = $(gridId).jqGrid('getDataIDs');
        for (var i = 1; i <= ids.length; i++) {
            var Ret = jQuery(gridId).getRowData(i);
            if (ID != Ret["localgridid"]) {
                if (Ret[colName].toLowerCase() == $(control).val().toLowerCase()) {
                    alert(message + ' already exists'); return false;
                }
            }
        }
        return true;
    }

    function StoreEducationGridDatainfo(gridId) { 
        var strvalues;
        var lista = jQuery(gridId).getDataIDs();
        for (i = 0; i < lista.length; i++) {
            strvalues = null;
            var Ret = jQuery(gridId).getRowData(lista[i]);
            strvalues = Ret["localgridid"] + "^" + Ret["id"] + "^" + Ret["candidateid"] + "^" + Ret["educationname"] + "^" + Ret["educationstream"] + "^" + Ret["university"] + "^" + Ret["year"] + "^" + Ret["percentage"] + "~";
            Education = Education + strvalues;
        }
        Education = Education.slice(0, -1);
        document.getElementById("hdnEducationDetails").value = Education;
    }

    function fillEducationData() {

        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        
        $('#degree').val(ret.educationname);
        $('#stream').val(ret.educationstream);
        $('#college').val(ret.university);
        $('#year').val(ret.year);
        $('#percent').val(ret.percentage);
    }
    
    function clearEducationLabels()
    {
        $('#degree').val("");
        $('#stream').val("");
        $('#college').val("");
        $('#year').val("");
        $('#percent').val("");
    }
    
    function CloseDialog()
    {
        clearEducationLabels();
        $('#diveducation').dialog('close');
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