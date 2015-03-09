<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveManagement.aspx.cs"
    Inherits="AltioStarHR.Leave.LeaveManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Leave Request</title>
    <style type='text/css'>
        #calendar
        {
            width: 400px;
            margin: 10;
        }
        .statusOnlyStar
        {
            font-size: 20px;
            color: red;
        }
    </style>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <link href="../Resources/css/ajaxfileupload.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/css/datePicker.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/cupertino/fullcalendar.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/cupertino/fullcalendar.print.css" rel="stylesheet" type="text/css"
        media='print' />
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
        
    </style>
</head>
<body>
    <div id="tabs" class="demo">
        <div id="tabs-2">
            <div style="background-color: #a4cd0f; color:Black; text-align: center;margin-left:1%;
                width: 97%; height: 25px" class="family1">
                Leave Modify 
            </div>
            <div id="LeaveRequestGrid">
            </div>
        </div>
    </div>
    <div id="divLeaveRequest" title="Leave Request Details" style="display: none; width: 100%;"
        class="family">
        <form id="signupFormLeaveReq" method="get" action="">
        <table style="background-color:#a4cd0f">
            <tr>
                <td>
                    <table class="teble_bg" style="width: 360px">
                        <tbody>
                            <tr>
                                <td class="label" style="width: 100px">
                                    <label id="lblltype" for="ltype" style="" class="family">
                                        Leave Type<span style="font-size: medium; color: Red"><b>*</b></span></label>
                                </td>
                                <td class="field">
                                    <select id="ltype" name="ltype" style="width: 160px;border:1px solid silver" class="family" onchange="LoadLeaveOverview();">
                                     <option value="0" selected>Select Leave Type</option>
                                      <option value="1">Annual leave</option>
                                      <option value="2"> Work from home</option>               
                                    </select>
                                </td>
                                <td class="statusOnlyStar" id="sltype" style="width: 150px;white-space:nowrap; font-size: x-small;">
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <label id="lfromdate" for="fromdate" style="" class="family">
                                        From Date<span style="font-size: medium; color: Red"><b>*</b></span></label>
                                </td>
                                <td class="field">
                                    <input type="text" id="fromdate" name="fromdate" style="width: 80px;border:1px solid silver" readonly="readonly" />
                                    <input type="checkbox" id="fromdatehalfday" name="halfday" value="true" onchange="FillLeaveFromDateHalfDaysCount();">Halfday<br>
                                </td>
                                <td class="statusOnlyStar" id="sfromdate" style="width: 150px;" class="family">
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <label id="ltodate" for="todate" style="" class="family">
                                        To Date<span style="font-size: medium; color: Red"><b>*</b></span></label>
                                </td>
                                <td class="field">
                                    <input type="text" id="todate" name="todate" style="width: 80px;border:1px solid silver" readonly="readonly"
                                        onblur="FillLeaveDaysCount();" class="family"/>
                                        <input type="checkbox" id="todatehalfday"name="halfday" value="true" onchange="FillLeaveToDateHalfDaysCount();">Halfday<br>
                                </td>
                                <td class="statusOnlyStar" id="stodate" style="width: 150px;">
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <label id="Label1" for="daycount" style="" class="family">
                                        Leave Count</label>
                                </td>
                                <td class="field">
                                    <input type="text" id="daycount" readonly="readonly" name="daycount" style="width: 150px;border:1px solid silver" class="family"/>
                                </td>
                                <td class="statusOnlyStar" id="Td1">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label id="Label2" for="todate" style="" class="family">
                                        Reason<span style="font-size: medium; color: Red"><b>*</b></span></label>
                                </td>
                                <td>
                                    <textarea name="reason" rows="3" cols="10" id="reason" style="width: 150px;border:1px solid silver" class="family"></textarea>
                                </td>
                                <td class="statusOnlyStar" id="sreason" style="width: 150px;" class="family">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <input id="signupsubmit" name="Submit" tabindex="4" type="submit" value="Submit"
                                        style="border:1px solid silver" class="family" />
                                    <input id="Cancel" name="Cancel" tabindex="5" type="button" value="Cancel" style="border:1px solid silver" class="family" />
                                    <input id="resetDates" name="resetDates" type="button" value="Reset Date Selection"
                                        style="border:1px solid silver" class="family" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td>
                    <div id='container'>
                        <div id='calendar' class="dvInsideIFrame">
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div id="divStatus" class="dialog" title="Leave Comment" style="display: none;">
        <form id="signupForm" method="get" action="">
        <table class="teble_bg" style="width: 475px; background-color:#a4cd0f">
            <tr>
                <td style="width: 50px;" id="ltxtComment" class="family">
                    <label>
                        Comments</label>
                </td>
                <td id="tdtxtComment">
                    <textarea style="width: 370px;border:1px solid silver" id='txtComment' runat="server" cols="2" rows="3" class="family"></textarea>
                </td>
                <td id="stxtComment" style="width: 200px;" class="family">
                </td>
            </tr>
        </table>
        <table style="width: 475px;background-color:#a4cd0f" >
            <tr align="left">
                <td>
                    <input id="Submit1" name="Submit" type="submit" value="Submit" style="" class="family" />
                    <input id="adminCancel" name="Cancel" type="button" value="Cancel" style="" class="family" />
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div id="LeaveOverviewGrid" style="display:none">
    </div>
    <input type="hidden" runat="server" id="hdnEmployeeTypeID" />
    <input type="hidden" runat="server" id="hdnempid" />
    <input type="hidden" runat="server" id="hdnappliedto" />
    <input type="hidden" runat="server" id="hdnlocofemp" />
    <input type="hidden" runat="server" id="hdnmodule" />
    <input type="hidden" runat="server" id="hdnApprovlPermit" />
    <input type="hidden" runat="server" id="hdnApplyPermit" />
    <input type="hidden" runat="server" id="hdnViewPermit" />
    <input type="hidden" runat="server" id="hdnTotalAnnualLeave" />
    <input type="hidden" runat="server" id="hdnBalanceLeave" />
    <input type="hidden" runat="server" id="hdnRequestedLeave" />
    <input type="hidden" runat="server" id="hdnEmployeeID" />
</body>

<script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

<script type="text/javascript" src="Resources/js/jquery-ui-1.8.16.custom.min.js"></script>

<script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="Resources/js/Webutility.js"></script>

<script type="text/javascript" src="Resources/js/toolbar.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

<script src="../Resources/js/jquery.ui.button.js" type="text/javascript"></script>

<script type="text/javascript" src="Resources/js/jquery.validate.js"></script>

<script type="text/javascript" src="Resources/js/fullcalendar.min.js"></script>

<script type="text/javascript">
    $('#LeaveOverviewGrid').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
            var arrholiday = new Array(7);
            var arrweekend = new Array(35);
            var selectedRowIdForLeaveForm = 0;
            var selectedRowIdForEncashForm = 0;
            var CalResponse = new Object();
            var ReqStartDate="";
            var ReqEndDate="";
            var isLeavesAvail=false;
            var isEncashAvail=false;  
            var validatorLeave;
         jQuery(document).ready(function() { 
         $(function() {
            $('#tabs').tabs({
                select: function(event, ui) {
                                
                }
            });
        });
           
         LoadLeaveOverview() 
         LoadLeaveTypes();   
         LoadWeekendAndHolidays();         
         $('#ViewCancel').click(function() {
            onViewCancel();
        });
        $('#Cancel').click(function() {
            onCancel();
        });
        LoadCalender();
            
            
            validatorLeave = $("#signupFormLeaveReq").validate({
                rules: {
                    ltype: "required",
                    fromdate: {
                        required: true
                    },
                    todate: {
                        required: true
                    },
                    ccmailid: {
                        required: true
                    },
                    reason: "required"
                },
                messages: {
                ltype: {
                    required: "Select Leave Type"
                },            
                fromdate: {
                    required: "Enter From Date"
                },
                todate: {
                    required: "Enter To Date"
                },                
                reason: {
                    required: "Enter Reason"
                } 
            },
                errorPlacement: function(error, element) {
                        error.appendTo(element.parent().next());
                },

                submitHandler: function(id) {                
                    var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                    var Request = new Object();
                    var ID = ""; var EmpID = "";
                    if (mode == "edit") {
                        var id = selectedRowIdForLeaveForm      
                        var ret = jQuery("#list").jqGrid('getRowData', id);
                        ID = ret.id;
                        EmpID = ret.employeeid;
                        Request.AppliedDateTime = ret.applieddatetime;
                        Status = ret.status;                        
                    }
                    else {
                        ID = "0";
                        EmpID = $("#hdnempid").val();
                    }
                    Request.ID = ID;
                    Request.EmpID = EmpID;
                    Request.LeaveID = $("#ltype").val();                    
                    var d = new Date();               
                    var curr_date = d.getDate();
                    var curr_month = parseInt(d.getMonth())+1;
                    var curr_year = d.getFullYear();                 
                    var dateInd = curr_date + "/" + curr_month + "/" + curr_year;
                   // var compareDateFromToday=(!dateInd.test($("#fromdate").val()))
                    //var compareDateFromToday=dateComparison(dateInd,$("#fromdate").val());
                    
                    var strDate = $("#fromdate").val();                    
                    Request.FromDate =strDate;                    
                    strDate = $("#todate").val();                    
                    Request.ToDate = strDate;                    
                    Request.Reason = $("#reason").val();                 
                    Request.DaysCount = $("#daycount").val();
                    if(Status == "Approved")
                    {
                         Request.Status = "APP";
                    }
                    else if(Status == "Rejected")
                    {
                         Request.Status = "REJ";
                    }
                    else if(Status == "Requested")
                    {
                         Request.Status = "REQ";    
                    }
                    //Request.Status = Status;
                    Request.UpdateBy =  $("#hdnempid").val();     
                    if ($("#fromdatehalfday").is(':checked')) { Request.FromDateHalfDay = true; }
                    else { Request.FromDateHalfDay = false; }
                    if ($("#todatehalfday").is(':checked')) { Request.ToDateHalfDay = true; }
                    else { Request.ToDateHalfDay = false; }              
                    if (confirm('Do you want to Submit?') == false) return false;
                    var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_LEAVE_REQUEST%>', Request, true);                    
                    alert(Response.Message);                      
                    ;                                            
                    if (Response.ResponseCommand == 'SUCCESS') {
                        var strQ = "ID=" + Response.MessageDetail;
                        mode = "SUCCESS";                        
                        Req = new Object();
                        Req.EmployeeID = $("#hdnempid").val();
                        var Response = SendApplicationRequest('<%=HRAppCommands.LEAVE_REQUEST_DETAILS%>', Req, true);
                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);                
                        clearLabels();
                        onCancel();
                        //reload calender
                        var Request = new Object();
                        Request.EmployeeID = $("#hdnempid").val();                        
                        CalResponse = SendApplicationRequest('<%=HRAppCommands.CALENDER%>', Request, true);
                        $('#calendar').fullCalendar('removeEvents',-1);
                        $('#calendar').fullCalendar('renderEvent', CalResponse.ResponseObject);
                        $('#calendar').fullCalendar('today');
                        LoadLeaveRequest();
                    }                    
                   
                    jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                    jQuery("#list2").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                },
                success: function(label) {
                    label.html("&nbsp;").addClass("checked");
                }
            }); 
            LoadLeaveRequest();
        });
        function LoadLeaveRequest()
        {        
            var Request = new Object();
            Request.EmployeeID = $("#hdnempid").val();  
            $("#LeaveRequestGrid").html("");                
            $("#LeaveRequestGrid").html("<div class='dvGrid'><table id='list'></table><div id='pager'></div></div></div>");     
            var myGrid = $('#list');    
            var Response = SendApplicationRequest('<%=HRAppCommands.LEAVE_REQUEST_DETAILS%>', Request,true);
            Response.ResponseObject.colModel = [
   		                { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		                { name: 'employeeid', index: 'employeeid', width: 20,hidden: true, editable: true },  		            		            
   		                { name: 'leaveid', index: 'leaveid', width: 20,hidden: true,editable: true },
   		                { name: 'managerid', index: 'managerid', width: 20,hidden: true, editable: true },
   		                { name: 'managername', index: 'managername', width: 70, editable: true},
   		                { name: 'employeename', index: 'employeename', width: 70, editable: true,hidden: true},
   		                { name: 'leavetype', index: 'leavetype', width: 70, editable: true },   		                
   		                { name: 'fromdate', index: 'fromdate', width: 50, editable: true },
   		                { name: 'todate', index: 'todate', width: 50, editable: true},
   		                { name: 'dayscount', index: 'dayscount', width: 50, editable: true},  
   		                { name: 'applieddatetime', index: 'applieddatetime', width: 50, editable: true, hidden: true },   		               
   		                { name: 'reason', index: 'reason', width: 150, editable: true,hidden: true},
   		                { name: 'status', index: 'status', width: 50, editable: true}, 
   		                { name: 'isactive', index: 'isactive', width: 10, editable: true, hidden: true },
   		                { name: 'title', index: 'title', width: 10, editable: true, hidden: true },
   		                { name: 'managercomments', index: 'managercomments', width: 10, editable: true, hidden: true },
   		                { name: 'FromDateHalfDay', index: 'FromDateHalfDay', width: 10, editable: true, hidden: true },
   		                { name: 'ToDateHalfDay', index: 'ToDateHalfDay', width: 10, editable: true, hidden: true }  		             
   	                ]
            Response.ResponseObject.caption = "";            
            Response.ResponseObject.subGrid = true;
            myGrid.jqGrid(Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { subGridRowExpanded: function(subgrid_id, row_id) {
                var ret = jQuery("#list").jqGrid('getRowData', row_id);
                if($.trim(ret.reason) !=''){
                    $("#" + subgrid_id).html("<b><label>Employee Comments</label></b><br/>"
                    +"<textarea id='ta_"+row_id+"' rows='3' cols='100' readonly='readonly'></textarea><br/>");         
                    $("#ta_"+row_id).val(ret.reason.replace(/<br>/g,"\n"));

                    $("#" + subgrid_id).append("<b><label>Manager Comments</label></b><br/>"
                    +"<textarea id='tb_"+row_id+"' rows='3' cols='100' readonly='readonly'></textarea><br/>");         
                    $("#tb_"+row_id).val(ret.managercomments.replace(/<br>/g,"\n"));   
                }                         
            }});
            
            jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
            jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
            jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
                onClickButton: function() {
                    myGrid[0].toggleToolbar()
                }
            });
            $("#list").closest(".ui-jqgrid-bdiv").height("auto");
            jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
            $("#t_list").append("<input type='button' id='editrequest' value=' Modify' style='font-size:12px;font-family:arial;margin:8px;'/> ");
            $("#t_list").append("<input type='button' id='approve' value='Approve' style='font-size:12px;font-family:arial;margin:8px;'/> ");
            $("#t_list").append("<input type='button' id='reject' value=' Reject' style='font-size:12px;font-family:arial;margin:8px;'/> ");

            $("input", "#t_list").click(function(id) {
                if (id.currentTarget.id == "editrequest") {
                    validatorLeave.resetForm();
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    if (id) {
                        LoadCalender();
                        //ResetSelectedDates();
                        clearLabels();
                        var ret = jQuery("#list").jqGrid('getRowData', id);
                        if (ret.status == "Requested") {
                            mode = "edit";
                            clearLabels();
                            document.getElementById("divLeaveRequest").style.display = "";
                            $('#divLeaveRequest').dialog({
                                height: 400,
                                width: 820,
                                modal: true
                            })
                            fillData();
                            selectedRowIdForLeaveForm = id;
                            $('#tabs').tabs('select', 2);
                            $('#calendar').fullCalendar('render');
                            var Request = new Object();
                            Request.EmployeeID = $("#hdnempid").val();                        
                            CalResponse = SendApplicationRequest('<%=HRAppCommands.CALENDER%>', Request, true);
                            $('#calendar').fullCalendar('removeEvents',-1);
                            $('#calendar').fullCalendar('renderEvent', CalResponse.ResponseObject);
                            $('#calendar').fullCalendar('today');
                            var sdate = $("#fromdate").val().split('/');
                            $('#calendar').fullCalendar('gotoDate', sdate[2], sdate[1] - 1);
                        }
                        else {
                            mode = "edit";
                            clearLabels();
                            document.getElementById("divLeaveRequest").style.display = "";
                            $('#divLeaveRequest').dialog({
                                height: 400,
                                width: 820,
                                modal: true
                            })
                            fillData();
                            selectedRowIdForLeaveForm = id;
                            $('#tabs').tabs('select', 2);
                            $('#calendar').fullCalendar('render');
                            var Request = new Object();
                            Request.EmployeeID = $("#hdnempid").val();
                            CalResponse = SendApplicationRequest('<%=HRAppCommands.CALENDER%>', Request, true);
                            $('#calendar').fullCalendar('removeEvents', -1);
                            $('#calendar').fullCalendar('renderEvent', CalResponse.ResponseObject);
                            $('#calendar').fullCalendar('today');
                            ////
                            var sdate = $("#fromdate").val().split('/');
                            //$('#calendar').fullCalendar('gotoDate', "2014-02-05");
                            $('#calendar').fullCalendar('gotoDate', sdate[2], sdate[1]-1);
                            //approved, rejected leaves cannot be editd
                            //alert("Approved and Rejected Leaves cannot be edited.");
                        }
                    }
                    else { alert("Please select a Request"); }
                }
                else if (id.currentTarget.id == "approve") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    mode = "approve";
                    if (id) {
                        validator.resetForm();
                        AdminclearLabels();
                        document.getElementById("divStatus").style.display = "";
                        $('#divStatus').dialog({
                            height: 150,
                            width: 500,
                            modal: true
                        })
                    }
                    else { alert("Please select a row"); }
                }
                else if (id.currentTarget.id == "reject") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    mode = "reject";
                    if (id) {
                        validator.resetForm();
                        AdminclearLabels();
                        document.getElementById("divStatus").style.display = "";
                        $('#divStatus').dialog({
                            height: 150,
                            width: 500,
                            modal: true
                        })
                    }
                    else { alert("Please select a row"); }
                }

            });
            $(document).ready(function() {       
                $('#t_list').css('background', 'none');
                $('#t_list').css('background-color', '#fff');
                //$('#t_list').css('padding', '10px 0px');
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
        }
         function LoadCalender()
         {
            var Request = new Object();
            Request.EmployeeID = $("#hdnempid").val();  
                       
            CalResponse = SendApplicationRequest('<%=HRAppCommands.CALENDER%>', Request,true);   
            $('#calendar').html('<span id="note" style="color:Red">Note:Please Drag the Mouse to Select From and To Dates'+
            '<br/>Note :After reset, please select From and To date before submission'
            +'</span>');
            $('#calendar').fullCalendar({
                disableDragging:true,
                editable: true,
                selectable: true,
			    selectHelper: true,	
			    contentHeight: 80,		
			    select: function(start, end, allDay) {
                    $('#calendar').fullCalendar('removeEvents',-1);					
                         var leaveExistsAlready = false;                     
                         if (CalResponse != null) {
                         var arrleaveEvents = $('#calendar').fullCalendar('clientEvents');
                         var dupli=0;
                         for (var i = 0; i < arrleaveEvents.length; i++) {
                            var testEventStartDate = new Date(arrleaveEvents[i].start);
                            var testEventEndDate = new Date(arrleaveEvents[i].end);
                            var testNewFromDate = new Date(start);
                            var testNewToDate = new Date(end);
                            var todayDate = new Date();
                            testEventStartDate.setHours(0, 0, 0, 0);
                            testEventEndDate.setHours(0, 0, 0, 0);
                            testNewFromDate.setHours(0, 0, 0, 0);
                            testNewToDate.setHours(0, 0, 0, 0);
                            todayDate.setHours(0, 0, 0, 0);
                                                     
                             var dupli=0;                         

                            if(testEventEndDate==null && testNewToDate==null)
                            {
                                if ((testEventEndDate - testNewToDate) == 0) {
                                    leaveExistsAlready = true;
                                     break;
                                }    
                            }
                            if(testEventEndDate!=null && testNewToDate==null)
                            {
                                if (testEventStartDate <= testNewFromDate && testEventEndDate >= testNewFromDate) {
                                    leaveExistsAlready = true;
                                     break;
                                }    
                            }
                            if(testEventEndDate==null && testNewToDate!=null)
                            {
                                if (testNewFromDate <= testEventStartDate && testNewToDate >= testEventStartDate) {
                                    leaveExistsAlready = true;
                                    break;
                                }    
                            }
                            if(testEventEndDate!=null && testNewToDate!=null)
                            {   
                                if(testNewFromDate<=testEventEndDate && testNewFromDate>=testEventStartDate){
                                    leaveExistsAlready = true;
                                    break;
                                }
                                else if(testNewToDate<=testEventEndDate && testNewToDate>=testEventStartDate){
                                    leaveExistsAlready = true;
                                    break;
                                }
                                else if(testNewFromDate<=testEventEndDate && testNewToDate>=testEventEndDate && testNewFromDate<=testEventStartDate && testNewToDate>=testEventStartDate){
                                    leaveExistsAlready = true;
                                    break;
                                }
                                
                            }
                        }
                        if (!leaveExistsAlready) {                        
                            $('#calendar').fullCalendar('renderEvent',
						    {
						        id:-1,
							    title: 'New Request',
							    start: start,
							    end: end,
							    allDay: allDay,
							    color: 'yellow',   
                                textColor: 'black'
						    },
						    true 						
					        );
                            FillDatesRange($.fullCalendar.formatDate(start, "dd/MM/yyyy"),$.fullCalendar.formatDate(end, "dd/MM/yyyy"),start);
                            
                            FillLeaveDaysCount(); 
                        }
                        else{
                        if(mode!='edit'){
                              if (leaveExistsAlready) {
                                    $('#calendar').fullCalendar('removeEvents',-1);
                                    alert("Leave already applied on this date");                                
                                }
                           }else
                           {
                           $('#calendar').fullCalendar('renderEvent',
						    {
						        id:-1,
							    title: 'New Request',
							    start: start,
							    end: end,
							    allDay: allDay,
							    color: 'yellow',   
                                textColor: 'black'
						    },
						    true 						
					        );
                            FillDatesRange($.fullCalendar.formatDate(start, "dd/MM/yyyy"),$.fullCalendar.formatDate(end, "dd/MM/yyyy"),start);
                            
                            FillLeaveDaysCount();                        

                           }
                        }
                            
                    }     
                        
			    },                
                events: CalResponse.ResponseObject,
                eventClick: function(calEvent, jsEvent, view) {                
                    var Request = new Object();
                     Request.ID = calEvent.id;                     
                     var LeaveDetails = SendApplicationRequest('<%=HRAppCommands.CALENDER_LEAVE_DETAIL%>', Request,true);              
                    //clearViewLeave();
                    if(LeaveDetails.ResponseObject.DaysCount==0){
                        return false;                         
                    }
                    else
                    {
                       alert("Already Leave Requested"); return false; 
                    }
                    fillViewLeave(LeaveDetails.ResponseObject.LeaveType,LeaveDetails.ResponseObject.Status,LeaveDetails.ResponseObject.DaysCount,LeaveDetails.ResponseObject.Reason);
                    document.getElementById("divLeaveInformation").style.display = "";
                    $('#divLeaveInformation').dialog({
                        height: 240,
                        width: 540, 
                        modal: true
                    })
                }
        });
         }
         function LoadLeaveTypes() {              
            var Response = SendApplicationRequest("<%=HRAppCommands.LEAVE_TYPE_COMBO%>", '');
            var optn = document.createElement("OPTION");
            optn.text = "Select Leave Type";
            optn.value = "";
            document.getElementById('ltype').options.add(optn);
            if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                var arr = Response.ResponseObject;
                for (var i = 0; i < arr.length; ++i) {
                    var optn = document.createElement("OPTION");
                    optn.text = arr[i]['LeaveType'];
                    optn.value = arr[i]['ID'];
                    document.getElementById('ltype').options.add(optn);
                }
            }
        } 
        
        function fillData() {
            var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#list").jqGrid('getRowData', id);
            var strDate = ret.fromdate;    
            $("#fromdate").val(strDate);
            var strDateTo = ret.todate;
            $("#todate").val(strDateTo);
            $("#reason").val(ret.reason);           
            $("#mremarks").val(ret.managerremarks);
            $("#daycount").val(ret.dayscount);   
            if (ret.FromDateHalfDay == 'False') { $("#fromdatehalfday").attr('checked', false); }
            else { $("#fromdatehalfday").attr('checked', true); }
            if (ret.ToDateHalfDay == 'False') { $("#todatehalfday").attr('checked', false); }
            else { $("#todatehalfday").attr('checked', true); }      
            $("#ltype").val($("#ltype option:contains(" + ret.leavetype + ")").val());
            LoadCalender();
        }   
        function clearLabels() {
            $("#fromdate").val("");
            $("#todate").val("");
            $("#reason").val("");
            $("#daycount").val("");           
            $("#mremarks").val("");           
            $("select#ltype")[0].selectedIndex = 0;
        } 
        
        function FillDatesRange(ReqStartDate,ReqEndDate,dateFormat) {
        
        if(ReqStartDate==ReqEndDate){
                if (IsHoliday(dateFormat) == false && IsWeekendFullDay(dateFormat) == false) {
                    $("#fromdate").val(ReqStartDate);
                    $("#todate").val(ReqStartDate);
                }
                else {
                    alert("Cannot apply leave on Holidays and weekly off days");
                }
        }
        else{
                $("#fromdate").val(ReqStartDate);
                $("#todate").val(ReqEndDate);
            }
        }
        
        function FillLeaveDaysCount() { 
            $('#fromdatehalfday').attr('checked', false);  
            $('#todatehalfday').attr('checked', false);    
            var count = 0;            
            var strFrom = $("#fromdate").val();
            var strTo = $("#todate").val();                        
            
            if(strFrom != ""){
                var dateParts = strFrom.split("/");
                strFrom = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];        
            }
            if(strTo != ""){
                var dateParts = strTo.split("/");
                strTo = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];        
            }
          
            var fromdate = new Date(strFrom);
            var todate = new Date(strTo);
            fromdate.setHours(0, 0, 0, 0);
            todate.setHours(0, 0, 0, 0);
            var tempdate = fromdate;            
            while (tempdate <= todate) {
                if (IsHoliday(tempdate) == true || IsWeekendFullDay(tempdate) == true) {
                }
                else {
                    if (GetWeekendSetting(tempdate) == 0.5) {
                        count = count + 0.5;
                    }       
                    else {
                        count++;
                    }
                }
                tempdate = getTomorrow(tempdate);
            }            
            var WeekEndsCount =CalculateWeekendDays(fromdate,todate);
            var CountLeave = count-WeekEndsCount;
            if (CountLeave >=0) {
                validatorLeave.resetForm();
            }
            if($("#hdnRequestedLeave").val()< CountLeave && $("#hdnBalanceLeave").val()< CountLeave)
            {
                clearLabels();
                alert("You don't have enough  balance leave");return false;
            }
            else
            {
                $("#daycount").val(CountLeave);
            }
        }
        function FillHalfDaysCount() {                        
            var count = 0;
            var strFrom = $("#fromdate").val();
            var strTo = $("#todate").val();

            if (strFrom != "") {
                var dateParts = strFrom.split("/");
                strFrom = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
            }
            if (strTo != "") {
                var dateParts = strTo.split("/");
                strTo = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
            }

            var fromdate = new Date(strFrom);
            var todate = new Date(strTo);
            fromdate.setHours(0, 0, 0, 0);
            todate.setHours(0, 0, 0, 0);
            var tempdate = fromdate;
            while (tempdate <= todate) {
                if (IsHoliday(tempdate) == true || IsWeekendFullDay(tempdate) == true) {
                }
                else {
                    if (GetWeekendSetting(tempdate) == 0.5) {
                        count = count + 0.5;
                    }
                    else {
                        count++;
                    }
                }
                tempdate = getTomorrow(tempdate);
            }
            var WeekEndsCount = CalculateWeekendDays(fromdate, todate);
            var CountLeave = count - WeekEndsCount;
            if (CountLeave >=0) {
                validatorLeave.resetForm();
            }
            $("#daycount").val(CountLeave); 
            if(CountLeave==1)
            {
                $("#todatehalfday").attr('disabled','disabled');
            } 
            else
            {
                $("#todatehalfday").attr('disabled',false);
            } 
    }
    var daysCount; 
    var finaldaysCount;
    var totalleavecount;
    
    function FillLeaveFromDateHalfDaysCount(){    
        if($("#fromdate").val()=="" && $("#todate").val()=="")
        {
            $('#fromdatehalfday').attr('checked', false);            
            alert("Select date");
            return false;   
        }
        else
        {
            if($("#fromdatehalfday").is(":checked") == true){            
                daysCount= $("#daycount").val();                
                finaldaysCount = daysCount-0.5;
                $("#daycount").val(finaldaysCount)
                $("#hdnFromLeaveCount").val(finaldaysCount)                
            }
            else
            {
                FillHalfDaysCount();
                totalleavecount = $("#hdnFromLeaveCount").val();
                if($("#todatehalfday").is(":checked") == true)
                { 
                    daysCount= $("#daycount").val();                   
                    finaldaysCount = daysCount-0.5;
                    $("#daycount").val(finaldaysCount);
                    $("#hdnToLeaveCount").val(finaldaysCount)  
                }  
                else
                {
                 $("#daycount").val();
                }      
            }          
        }
          
    }
    function FillLeaveToDateHalfDaysCount(){
        var daysCount; 
        if($("#fromdate").val()=="" && $("#todate").val()=="")
        {           
            $('#todatehalfday').attr('checked', false);  
            alert("Select date");
            return false;   
        }  
        else{  
            daysCount= $("#daycount").val();            
            if(daysCount>1)
            {
                if($("#todatehalfday").is(":checked") == true){ 
                    daysCount= $("#daycount").val();                   
                    finaldaysCount = daysCount-0.5;
                    $("#daycount").val(finaldaysCount);
                    $("#hdnToLeaveCount").val(finaldaysCount)          
                }
                else
                {
                    FillHalfDaysCount();
                    totalleavecount = $("#hdnToLeaveCount").val();
                     if($("#fromdatehalfday").is(":checked") == true)
                     {   
                        daysCount= $("#daycount").val();
                        finaldaysCount = daysCount-0.5;
                        $("#daycount").val(finaldaysCount)
                        $("#hdnFromLeaveCount").val(finaldaysCount)                
                    }
                    else
                    {
                        $("#daycount").val();
                    }               
                }
             }
            
        }
          
    }

        function CalculateWeekendDays(fromDate, toDate){
            var weekendDayCount = 0;
            var temDate = new Date(fromDate);
            while(temDate <= toDate){            
                if(temDate.getDay() === 0 || temDate.getDay() == 6){
                    ++weekendDayCount ;
                }
                temDate.setDate(temDate.getDate() + 1);
            }
            return weekendDayCount ;
        }
        
        function onViewCancel() {
            $("#divLeaveInformation").dialog('close');
        } 
        
      function FillDates(clickedDate) {
      
        var resetdates = false;
        var strDate = $("#fromdate").val();
        if(strDate != ""){
            var dateParts = strDate.split("/");
            strDate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];  
        }      
        var dfrom = strDate;
        var strDateTo =  $("#todate").val();
         if(strDateTo != ""){
            var datePartsTo = strDateTo.split("/");
            strDateTo = datePartsTo[1] + "/" + datePartsTo[0] + "/" + datePartsTo[2];
        }
        var dto = strDateTo;        
        if (clickedDate >= dfrom && clickedDate <= dto) {
            return;
        }
        if (dfrom == "" && dto == "") {
            var tempdate = new Date(clickedDate);
            tempdate.setHours(0, 0, 0, 0);
            if (IsHoliday(tempdate) == false && IsWeekendFullDay(tempdate) == false) {
                $("#fromdate").val(clickedDate);
                $("#todate").val(clickedDate);
            }
            else {
                alert("Cannot apply leave on Holidays and weekly off days");
            }
        }
        else {
            var dfromForYear = new Date(dfrom);
            var dclickedForYear = new Date(clickedDate);
            if (dclickedForYear.getFullYear() != dfromForYear.getFullYear()) {
                alert("Please choose dates within same year. Apply seperate leave request for dates in different years");
                return;
            }
            if (clickedDate < dfrom) {
                $("#fromdate").val(clickedDate);
                $("#todate").val(dto);
            }
            else if (clickedDate > dto) {
                $("#todate").val(clickedDate);
                 $("#fromdate").val(dfrom);
            }
        }        
        var strDate = $("#fromdate").val();
        if(strDate != ""){
            var dateParts = strDate.split("/");
            strDate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];        
        }
        $("#fromdate").val(strDate);
        var strDateTo =  $("#todate").val();
        if(strDateTo != ""){
            var datePartsTo = strDateTo.split("/");
            strDateTo = datePartsTo[1] + "/" + datePartsTo[0] + "/" + datePartsTo[2];
        }
        $("#todate").val(strDateTo);         

    } 
    function IsWeekendFullDay(date) {
    
        var dayofweek = date.getDay();
        if (arrweekend[dayofweek] == "1") {
            return true;
        }
        else {
            return false;
        }
    }
    function GetWeekendSetting(date) {
        var dayofweek = date.getDay();
        if (arrweekend[dayofweek] == "1") {
            return 1;
        }
        else if (arrweekend[dayofweek] == "0.5") {
            return 0.5;
        }
        else {
            return 0;
        }
    }
    function IsHoliday(date) {
        retVal = false;
        for (var i = 0; i < arrholiday.length; i++) {
            if (arrholiday[i] != null) {
                var temp1 = "";
                var str1 = arrholiday[i];
                var dt1 = str1.substring(8, 10);
                var mon1 = str1.substring(5, 7);
                var yr1 = str1.substring(0, 4);
                temp1 = mon1 + "/" + dt1 + "/" + yr1;
                var cfd = Date.parse(temp1);
                var holidayDate = new Date(cfd);
                if(holidayDate.getDay() === 0 || holidayDate.getDay() == 6)
                {
                     retVal = false;
                }
                else{
                    if (!(date - holidayDate)) {    
                        retVal = true;
                        break;
                    }   
                }    
            }
        }
        return retVal;
    }
    
    function LoadWeekendAndHolidays() {    
        var Request = new Object;
        Request.EmployeeID = $("#hdnempid").val();        
        var Response = SendApplicationRequest("<%=HRAppCommands.HOLIDAYS_BY_EMPID_DETAILS%>", Request, true);
        if (Response.ResponseCommand == "SUCCESS") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                 arrholiday[i] = arr[i]["HolidayDate"];
            }
        }
    }
    function getTomorrow(d) {
        var e = new Date(d.getTime() + 86400000);
        return e;
    }
    function onCancel() {
        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        selectedRowIdForLeaveForm = 0;
        clearLabels();            
        $("#divLeaveRequest").dialog('close');
        $('#tabs').tabs('select', 2);

    }
    $('#resetDates').click(function() {
        ResetSelectedDates();
        $('#calendar').fullCalendar('unselect');
       
    });
    
    function ResetSelectedDates() {
        $("#todate").val("");
        $("#fromdate").val("");
        $("#daycount").val("");
        $('#calendar').fullCalendar('removeEvents',-1);
        if (confirm('On resetting, the From date and To date will be cleared.Do you wish to reset?') == false) return false;   
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        Request = new Object();
        Request.ID=ret.id;                  
        Request.EmployeeID=$('#hdnempid').val();        
        var Response = SendApplicationRequest('<%=HRAppCommands.RESETDATE_LEAVE_REQUEST%>', Request, true);  
        $('#calendar').fullCalendar('removeEvents', 1);
        LoadLeaveRequest();
        LoadLeaveOverview();
        LoadCalender();
    }
    
    var validator;
        jQuery(document).ready(function() { 
            $.validator.addMethod("alphaNumerix", function(value, element) {
                return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
            }, "Username must contain only letters, numbers, or dashes.");
            
            $('#adminCancel').click(function() {
                onAdminCancel();
            });
            LoadLeaveRequest();                  
       
         validator = $("#signupForm").validate({
            rules: {              
            },            
            messages: {                      
            },            
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            
            submitHandler: function(id) {               
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                var LeaveRequestID = "";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);                
                if(mode=="reject" && $("#txtComment").val()=="")
                {
                    alert("Enter Comment");
                    return false;
                }
                if (mode == "approve") {                    
                    Request.LeaveRequestID = ret.id;
                    Request.Status = "APP" 
                }
                else {
                    Request.LeaveRequestID = ret.id;
                    Request.Status = "REJ" 
                }                         
                Request.ID = "0";  
                Request.ProcessedBy =  $("#hdnEmployeeID").val();            
                Request.Comment = $("#txtComment").val();                 
                if (confirm('Do you want to Submit?') == false) return false;             
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_LEAVE_APPROVAL%>', Request, true);                
                alert(Response.Message);                                         
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = "SUCCESS";
                    LoadLeaveRequest();  
                    LoadLeaveOverview();                             
                    AdminclearLabels();
                    onAdminCancel();
                }
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        }); 
        }); 
        function onAdminCancel() {
            if (mode != "SUCCESS") {
                if (confirm('Do you want to cancel?') == false) return;
            }
            $("#divStatus").dialog('close');
        }
        function AdminclearLabels()
        {
            $("#txtComment").val("");            
        } 
        
        function LoadLeaveOverview() {        
                Request = new Object();
                Request.EmployeeID = $("#hdnempid").val();      
                $("#LeaveOverviewGrid").html("");                
                $("#LeaveOverviewGrid").html("<div><table id='list2'></table></div></div>"); 
                var myGrid = $('#list2');              
                var Response = SendApplicationRequest('<%=HRAppCommands.LEAVE_OVERVIEW_DETAILS%>', Request,true);   
                if(Response.ResponseObject.datastr!=null)
                {
                     var LeaveReq = Response.ResponseObject.datastr.rows[0].cell[5];        
                     var BalL = Response.ResponseObject.datastr.rows[0].cell[7];                           
                } 
                else 
                {
                    var BalL=1;
                }   
                if(Response.ResponseObject.datastr.rows[0].cell[8]!=2)
                {
                    $("#hdnRequestedLeave").val(LeaveReq);            
                    $("#hdnBalanceLeave").val(BalL);  
                } 
                else
                {
                     $("#hdnRequestedLeave").val(2000);            
                     $("#hdnBalanceLeave").val(2000);  
                }                                  
                Response.ResponseObject.colModel = [
   		                    { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		                    { name: 'empid', index: 'empid', width: 100,hidden: true, editable: true }, 
   		                    { name: 'empname', index: 'empname', width: 100, editable: true,hidden: true },  		            		            
   		                    { name: 'leavetype', index: 'leavetype', width: 100,editable: true },
   		                    { name: 'totalleave', index: 'totalleave', width: 100, editable: true },
   		                    { name: 'leaverequested', index: 'leaverequested', width: 100, editable: true,hidden: true },
   		                    { name: 'usedleave', index: 'usedleave', width: 100, editable: true },
   		                    { name: 'balanceleave', index: 'balanceleave', width: 100, editable: true },
   		                    { name: 'leaveid', index: 'leaveid', width: 100, hidden: true,editable: true }    		                  		             
   	                    ]
                Response.ResponseObject.caption = "";
                myGrid.jqGrid(Response.ResponseObject);
                jQuery("#list2").jqGrid('navGrid', '#pager1', { del: false, add: false, edit: false, search: false });
                jQuery("#list2").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
            }
        
        
          
</script>

<script type="text/javascript">
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('#t_list').css('background', 'none');
        $('#t_list').css('background-color', '#fff');
        //$('#t_list').css('padding', '10px 0px');
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
