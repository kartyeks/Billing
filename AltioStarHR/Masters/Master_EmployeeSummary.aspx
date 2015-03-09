<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Master_EmployeeSummary.aspx.cs" Inherits="AltioStarHR.Masters.Master_EmployeeSummary" %>
<%@ Register Src="~/UserControls/EmployeeFilter.ascx" TagName="EmployeeFilter"
    TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employees</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    </style>
    <link type="text/css" href="../Resources/css/datePicker.css" rel="stylesheet" />
    <style type="text/css">
        .ui-timepicker-div .ui-widget-header
        {
            margin-bottom: 8px;
        }
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 15px;
        }
        .ui-timepicker-div dl dd
        {
            margin: -25px 0 10px 65px;
        }
        .ui-timepicker-div td
        {
            font-size: 50%;
        }
       
    </style>

</head>
<body>
    <div>
<%--        <div class="header_title2">
            Employees</div>--%>
           <div style="position:relative;width:100%">
                <img alt="" src="Resources/Images/NewImages/1.png"style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
<div style="position:absolute;left:4%;top:30%;margin-top:1%;">
<strong class="family1 imageheadercolor">Employee Details</strong>
</div>
</div>
        <div class="dvGrid" style="width:100%;margin-top:-1%">
            <div id="divEmployees" >
                <form id="signupForm" method="get" action="">
                <table style="background-color:#a4cd0f;margin-left:2%;width:97% ">
                 <tr>
                        <td>
                            <fieldset style="margin-top:0%;margin-left:2%;width:97%">
                                <uc:EmployeeFilter ID='ucFilter' runat="server" />
                            </fieldset>
                        </td>
                    </tr>
                </table>
                 <table >
                <tr>
                    <td align="right"><input id="btnSearch" value="Search" onclick="onSearch()" type="button" class="family"/></td>
                 <td ><input id="btnClear" type="button" value="Reset" onclick="clearGrid()" class="family"/></td>
                </tr>
                </table>
                </form>
            </div>
<%--       <div style="background-color:#00daf5;width:888px;margin-left:0%;height:25px;padding-left:2%;font-family:Calibri;font-weight:bold;color:White;padding-top:2%">
            Employee Details</div>--%>
        </div>
        <div style="margin-left:2%" id="box">
            <table id="list" >
            </table>
            <div id="pager">
            </div>
        </div>
    </div>
</body>


    <script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

    <script src="Resources/js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>

    <script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>

    <script type="text/javascript" src="Resources/js/Webutility.js"></script>

    <script type="text/javascript" src="Resources/js/toolbar.js"></script>

    <script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>

    <script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

    <script src="Resources/js/jquery.ui.button.js" type="text/javascript"></script>

<script type="text/javascript">
    // Code to Prevent the BackSpace key from Working as "Go To Back Page."

//    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg.gif)');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "95%" });
    $(document).keydown(function(e) {

        var nodeName = e.target.nodeName.toLowerCase();
        if (e.which == 8) {
            if ((nodeName == 'input' && e.target.type == 'text') || nodeName == 'textarea') {
                /* do nothing */
            }
            else { e.preventDefault(); }
        }
    });
    var dummyResponse;

    function onSearch() {

      //  $.showprogress();
        var DesigID = 0;
        var CountryID = 0;
        var LoacID = 0;
        var TeamID = 0;
        var sDesigID = $("#ucFilter_cmbDesignation").val();
        if (sDesigID != "")
            DesigID = sDesigID;
        var sCountry = $("#ucFilter_cmbCountry").val();
        if (sCountry != "")
            CountryID = sCountry;
        var sLocationID = $("#ucFilter_cmbLocation").val();
        if (sLocationID != "")
            LoacID = sLocationID;
        var sTeamID = $("#ucFilter_cmbTeam").val();
        if (sTeamID != "")
            TeamID = sTeamID;
        var Request = new Object();
        Request.FirstName = $("#ucFilter_txtFirstn").val();
        Request.LastName = $("#ucFilter_txtLastn").val();
        Request.Empcode = $("#ucFilter_txtEmpCode").val();
        Request.DesignationID = DesigID; 
        Request.CountryID = CountryID;
        Request.LocationID = LoacID;
        Request.TeamID = TeamID;
        if (Request.FirstName == '' && Request.LastName == '' && Request.Empcode == '' && Request.DesignationID == 0 && Request.CountryID == 0 && Request.LocationID == 0 && Request.TeamID == 0) {
            alert('Please provide the input to search');return false;
        }
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE_GRIDDETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            //        jQuery("#list").jqGrid('setCaption', "EmployeeDetails").trigger('reloadGrid');
            jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
        }
        var lista = jQuery("#list").jqGrid('getRowData');
        if (lista.length == 0) {
            alert('No record found');
        }

    }
    function clearGrid() {
        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        jQuery("#list").jqGrid('clearGridData');
        window.ClearItems('ucFilter');
        
        // On Reset, the page was going blank. To avoid this below code is written
        var Request1 = new Object();
        Request1.FirstName = '';
        Request1.LastName = '';
        Request1.Empcode = '';
        Request1.DesignationID = 0;
        Request1.CountryID = 0;
        Request1.LocationID = 0;
        Request1.TeamID = 0;
        var myGrid = $('#list');
        var Response1 = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE_GRIDDETAILS%>', Request1, true);
        if (Response1.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response1.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
    }
    
    var mode = "";
    var searchEmployeeType = '';
    jQuery(document).ready(function() {

        var Request = new Object();
        Request.FirstName = '';
        Request.LastName = '';
        Request.Empcode = '';
        Request.DesignationID = 0;
        Request.CountryID = 0;
        Request.LocationID = 0;
        Request.TeamID = 0;
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE_GRIDDETAILS%>', Request, true);
        Response.ResponseObject.colModel = [
            { name: 'EmpID', index: 'EmpID', hidden: true, sorttype: "int" },
            { name: 'EmpTypeID', index: 'EmpTypeID', hidden: true, sorttype: "int" },
            { name: 'EmpCode', index: 'EmpCode', editable: true },
            { name: 'EmployeeType', index: 'EmployeeType', editable: true },
            { name: 'FirstName', index: 'FirstName', editable: true },
            { name: 'MiddleName', index: 'MiddleName', editable: true },
            { name: 'LastName', index: 'LastName', editable: true },
            { name: 'Country', index: 'Country', editable: true },
            { name: 'Location', index: 'Location', editable: true },
            { name: 'Designation', index: 'Designation', editable: true },
            { name: 'Team', index: 'Team', editable: true },
            { name: 'ManagerName', index: 'ManagerName', editable: true },
            { name: 'Gender', index: 'Gender', hidden: true, editable: true },
            { name: 'EmailID', index: 'EmailID', hidden: true, editable: true }
        ]

        Response.ResponseObject.autowidth= true;
        
        myGrid.jqGrid(Response.ResponseObject);
        dummyResponse = Response;

        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });
//        $("#list").closest(".ui-jqgrid-bdiv").height("auto");
        //        jQuery("#list").jqGrid('setCaption', "Employee Details").trigger('reloadGrid');
        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");

        $("#t_list").append("<button type='button' id='Add' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><div></div><span>Add</span></button>");
        $("#t_list").append("<button type='button' id='View' value='View' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view_btn.png'height=18px;width=18px alt='' /><br/><div></div><span>View</span></button>");
        $("#t_list").append("<button type='button' id='Delete' value='Delete' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/Delete_Icon.png'height=20px;width=22px alt='' /><br/><div></div><span >Delete</span></button>");
       $("#t_list").append("<button type='button' id='User' value='Create Users' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/create_users.png'height=20px;width=22px alt='' /><br/><span >Create Users</span></button>");
        $("#t_list").append("<button type='button' id='Refresh' value='Refresh' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/refresh_icon.png'height=20px;width=22px alt='' /><br/><div></div><span >Refresh</span></button>");
        $("#t_list").append("<button type='button' id='LeaveUpdate' value='Leave Modify' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/leave_modify.png'height=20px;width=22px alt='' /><br/><div></div><span >Leave Modify</span></button>");
        $("#t_list").append("<button type='button' id='Upload' value='Upload Employee Data' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/upload_employee_data.png'height=20px;width=22px alt='' /><br/><div></div><span>Upload Employee Data</span></button>");


        //        $("#t_list").append("<input type='button' id='Add' value='Add'  style='height:24px;font-size:-2'/>");
        //        $("#t_list").append("<input type='button' id='View' value='View'  style='height:24px;font-size:-2'/>");
        //        $("#t_list").append("<input type='button' id='Delete' value='Delete'  style='height:24px;font-size:-2'/>");
        //        $("#t_list").append("<input type='button' id='User' value='Create Users'  style='height:24px;font-size:-2'/>");
        //        $("#t_list").append("<input type='button' id='Refresh' value='Refresh'  style='height:24px;font-size:-2'/>");
        //        $("#t_list").append("<input type='button' id='LeaveUpdate' value='Leave Modify'  style='height:24px;font-size:-2'/>");
        //        $("#t_list").append("<input type='button' id='Upload' value='Upload Employee Data'  style='height:24px;font-size:-2'/>");
        $("button,input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "Add") {

                var InviewModeValue = id.currentTarget.id;
                $('#ChildWB', parent.document).attr("src", "default.aspx?serve=Master_Employee&employeeid=0&InviewMode=add");

            }
            else if (id.currentTarget.id == "View") {

                var InviewModeValue = id.currentTarget.id;
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {

                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    $('#ChildWB', parent.document).attr("src", "default.aspx?serve=Master_Employee&employeeid=" + ret.EmpID + "&InviewMode=view");
                }
                else alert("Please select employee to view");
            }
            else if (id.currentTarget.id == "User") {

                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    //                $('#ChildWB', parent.document).attr("src", "default.aspx?serve=Users");
                    window.showModalDialog('default.aspx?serve=Users&empName=' + ret.FirstName + ' ' + ret.LastName + '&empID=' + ret.EmpID + '&mod=EMP', window.self, "dialogHeight:260px; dialogWidth:450px; resizable:yes; status:no; scroll:no;");
                    //                window.location.href = "default.aspx?serve=Users&empName=" + ret.FirstName + " " + ret.LastName + "&empID=" + ret.EmpID;

                }
                else { alert("Please select a row"); }
            }
            else if (id.currentTarget.id == "Delete") {

                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    if (confirm('Do you want to delete?') == false) return;
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    var Request = new Object();
                    Request.ID = ret.EmpID;
                    var Response = SendApplicationRequest('<%=EmployeeAppCommands.DELETE_EMPLOYEE%>', Request);

                    var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                    var Response = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE_GRIDDETAILS%>', '', true);
                    jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                    //                     jQuery("#list").jqGrid('setCaption', "Employee Details").trigger('reloadGrid');
                    jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                }
                else alert("Please select employee to delete");
            }
            else if (id.currentTarget.id == "Upload") {
                var ret = window.showModalDialog('default.aspx?serve=BulkDataUpload', window.self, "dialogHeight:360px; dialogWidth:450px; resizable:yes; status:no; scroll:no;");
                //if (ret) {
                    var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                    var Response = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE_GRIDDETAILS%>', '', true);
                    jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                    //                     jQuery("#list").jqGrid('setCaption', "Employee Details").trigger('reloadGrid');
                    jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                //}
            }
            else if (id.currentTarget.id == "Refresh") {
               window.ClearItems('ucFilter');

                //                onCTC();
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                //  window.ClearItems('ucFilter');
                var Response = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE_GRIDDETAILS%>', '', true);
                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                //                jQuery("#list").jqGrid('setCaption', "Employee Details").trigger('reloadGrid');
                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
            }
            else if (id.currentTarget.id == "LeaveUpdate") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    var qrystr = "default.aspx?serve=LeaveManagement&EID=" + ret.EmpID;
                    retval = showModalDialog(qrystr, window.self, "dialogHeight:480px; dialogWidth:950px; resizable:yes; status:no; titlebar: no; toolbar: no; statusbar:no");
                }
                else { alert("Please select a row"); }
            }

        });
        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
    });

    
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
