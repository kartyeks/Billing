<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAttendance.aspx.cs" Inherits="AltioStarHR.Attendance.EmployeeAttendance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Employee Attendance</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
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
    <%--<div style="background-color: #003366; color: #FFFFFF; font-size: x-large; width: 940px;text-align: center">--%>
   <%-- <div style="background-color:#00daf5;width:885px;margin-left:1%;height:25px;padding-left:2%;font-family:Calibri;font-weight:bold">
        Employee Attendance
    </div>--%>
    <div style="position:relative;width:100%">
<img alt="" src="Resources/Images/NewImages/1.png" style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
<div style="position:absolute;left:4%;top:30%;margin-top:1%;">
<strong class="family1 imageheadercolor"> Employee Attendance Details</strong>
</div>
</div>
<div id="divLocation" class="dialog" >
     <%-- <div id="divLocation" style="width:903px;padding-left:3%;background-color:White">--%>
        <form id="signupForm" method="get" action="">
         <fieldset >
            <table style="margin-top:-25px;background-color:#a4cd0f;margin-left:2%;width:97%">
                <tbody>
                    <tr>
                        <td style="width:2%">
                            <select id="cmbyear" name="cmbyear" style="border:1px solid silver" onchange="LoadMonth()" class="family"></select>
                            
                        </td>
                        <td style="width:2%"></td>
                        <td style="width:2%">
                            <select id="cmbmonth" name="cmbmonth" style="border:1px solid silver" class="family"></select>
                        </td>
                          <td style="white-space:nowrap;width:10%"></td>
                    </tr>
                      <tr>
                    <td style="width:2%">                    
                        
                                     <input type="submit" id="btnview" name="btnViewandUpload" value="View Monthly Attendance" style="border:1px solid silver" 
                                    class="family"/>                  
                  <%--  <button type="button" id="btnview" name="btnViewandUpload" class="family"  value="View Monthly Attendance" style="outline:none;border:none"><img src="Resources/Images/NewImages/view_attendence.png"   style="height:20px;width:22px" alt='' /><br/><span style="white-space:nowrap">View Monthly Attendance</span></button>--%>
                            
                    </td>
                    <td style="width:2%">
                        <%--<input type="button" id="btnuploadexcel" name="btnViewandUpload" value="Upload File" onclick="RedirectToUpload()" 
                            style="border:1px solid silver" class="family"/>--%>
                        <button type="button" id="btnuploadexcel" name="btnViewandUpload" class="family" onclick="RedirectToUpload()" value="Upload File" style="outline:none;border:none"><img src="Resources/Images/NewImages/Upload-file.png"   style="height:20px;width:22px" alt='' /><br/><span style="white-space:nowrap">Upload File</span></button>
                    </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
        </form>
    </div>
  
    <div style="margin-left:2%;margin-top:0%;width:97%" id="box">
        <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>
    <input type="hidden" id='hdnEmployeeID' runat="server" />
    <input type="hidden" id='hdnmodule' runat="server" />
    <input type="hidden" id='hdnApprovlPermit' runat="server" />
    <input type="hidden" id="hdnApplyPermit" runat="server" />
    <input type="hidden" id="hdnViewPermit" runat="server" />
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
    $(window).bind('resize', function() {
        $("#list").setGridWidth($('#box').width() - 10, true);
    }).trigger('resize');
    jQuery("#box").css({ width: "97%" });
//    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });
    jQuery(document).ready(function() {

        LoadYear();
        LoadMonth();
        
        var myGrid = $('#list');

        var Request = new Object();

        if (isNaN($('#cmbyear option:selected').text()))
            Request.ChangedBy = 0;
        else
            Request.ChangedBy = $('#cmbyear option:selected').text();

        if ($('#cmbmonth').val() == "")
            Request.ID = 0;
        else
            Request.ID = $('#cmbmonth').val();

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_EMP_UPLOADED_ATTENDANCE_GRID%>', Request);
        Response.ResponseObject.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'empid', index: 'empid', width: 100, editable: true, hidden: true },
            { name: 'empcode', index: 'empcode', width: 100, editable: true },
            { name: 'empname', index: 'empname', width: 100, editable: true },
            { name: 'teamname', index: 'teamname', width: 100, editable: true },
            { name: 'month', index: 'month', width: 70, editable: true },
            { name: 'year', index: 'year', width: 30, editable: true },
            { name: 'leavedate', index: 'leavedate', width: 100, editable: true, hidden: true },
            { name: 'leavetype', index: 'leavetype', width: 100, editable: true, hidden: true },
            { name: 'daysinmonth', index: 'daysinmonth', width: 100, editable: true },
            { name: 'leavecount', index: 'leavecount', width: 100, editable: true },
            { name: 'daysworked', index: 'daysworked', width: 100, editable: true }
        ]

        Response.ResponseObject.autowidth= true;
        
        myGrid.jqGrid(Response.ResponseObject);
        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

        
        $("#t_list").closest(".ui-userdata").hide();
        var validator = $("#signupForm").validate({
            rules: {
                cmbyear: {
                    required: true
                },
                cmbmonth: {
                    required: true
                }
            },
            messages: {
                cmbyear: {
                    required: "Select Year"
                },
                cmbmonth: {
                    required: "Select Month"
                }
            },

            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {

                var Year = $('#cmbyear option:selected').text();
                var Month = $('#cmbmonth').val();

                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                Request.ID = Month;
                Request.ChangedBy = Year;

                var Response = SendApplicationRequest('<%=HRAppCommands.GET_EMP_UPLOADED_ATTENDANCE_GRID%>', Request);
                if (Response.ResponseObject.datastr == null) {
                    jQuery("#list").jqGrid('clearGridData');
                    alert('No Data for selected month and year');
                    return;
                }
                else {
                    jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                    jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                }
            }
        });
    });

    function RedirectToUpload() {
        if (validate()) {
            var Month = $('#cmbmonth').val();
            var Year = $('#cmbyear option:selected').text();

            var url = "default.aspx?serve=UploadEmployeeAttendance&comboMonth=" + Month + "&comboYear=" + Year;
            var retval = window.showModalDialog(url, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
        }
    }

    function validate() {
        
        if ($('#cmbyear').val() == "") {
            alert('Select Year');
            $('#cmbyear').focus();
            return false;
        }
        else if ($('#cmbmonth').val() == "") {
            alert('Select Month');
            $('#cmbmonth').focus();
            return false;
        }
        return true;
    }
    
    function LoadYear() {
        var optn = document.createElement("OPTION");
        optn.text = "Choose Year";
        optn.value = "";
        document.getElementById('cmbyear').options.add(optn);
        
        for (var i = 1; i <= 3; ++i) {
            var optn = document.createElement("OPTION");
            optn.text = (new Date().getFullYear())-(i-1);
            optn.value = i;
            document.getElementById('cmbyear').options.add(optn);
        }
    }

    function LoadMonth() {
        $('#cmbmonth').empty();
        var Montharr = new Array();
        Montharr[0] = "January";
        Montharr[1] = "February";
        Montharr[2] = "March";
        Montharr[3] = "April";
        Montharr[4] = "May";
        Montharr[5] = "June";
        Montharr[6] = "July";
        Montharr[7] = "August";
        Montharr[8] = "September";
        Montharr[9] = "October";
        Montharr[10] = "November";
        Montharr[11] = "December";
        
        var optn = document.createElement("OPTION");
        optn.text = "Choose Month";
        optn.value = "";
        document.getElementById('cmbmonth').options.add(optn);
        
        var CurYear = new Date().getFullYear();
        var CurMonth = new Date().getMonth();
        
        // Check selected year is current year, then display Month Combo till current month //  
        if ($('#cmbyear option:selected').text() == CurYear) {
            if (CurMonth == 0) {
                var optn = document.createElement("OPTION");
                optn.text = Montharr[CurMonth];
                optn.value = 1;
                document.getElementById('cmbmonth').options.add(optn);
            }
            else {
                for (var i = 1; i <= CurMonth + 1; ++i) {
                    var optn = document.createElement("OPTION");
                    optn.text = Montharr[i - 1];
                    optn.value = i;
                    document.getElementById('cmbmonth').options.add(optn);
                }
            }
        }
        // If selected year not current year, then display all months in Month Combo //
        else {
            for (var i = 1; i <= 12; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = Montharr[i - 1];
                optn.value = i;
                document.getElementById('cmbmonth').options.add(optn);
            }
        }
    }

</script>
<script type="text/javascript">
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('#t_list').css('background', 'none');
        $('#t_list').css('background-color', '#fff');
       // $('#t_list').css('padding', '10px 0px');
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
