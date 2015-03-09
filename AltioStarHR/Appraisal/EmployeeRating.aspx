<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRating.aspx.cs" Inherits="AltioStarHR.Appraisal.EmployeeRating" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>View Appraisals</title>
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
</head>
<body>
    <div>
        <%--<div class="header_title2">
            View Appraisals</div>--%>
                     <div style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png" style="width: 97%; margin-left: 2%;height: 53px"/>
    <div style="position:absolute;left:4%;top:52%;">
  <strong class="family1 imageheadercolor">View Appraisals</strong>
    </div>
</div>
            <div id="divSearchFilter">
        <table style="margin-left:1.5%;margin-top:-2%;width:98%">
            <tr>
                <td >
                    <fieldset>
                        <table  class="teble_bg" style="width:100%;background-color:#00daf5">
                             <tr>
                                 
                                <td colspan="10" align="center" >
                                   
                                    <table class="teble_bg" style="background-color:#00daf5">
                                    <tr>
                                    <td style="font-family:Arial;font-size:13px;"><b style="float:right">Select Intimation Year</b></td>
                                    <td > <select id="cmbDate" onchange="return BindGrid();" class="family"></select></td>
                                    </tr>
                                    </table>
                                
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>
        
        <div class="dvGrid1" style="margin-left:2%;width:97%" id="box">
            </div>
        
        <div id="ViewAppraisal" style="display:none">
            
            <input type="button" onclick="return OnCancel();" />
        </div>
        <div id='divPromotion' style="display:none" title="Promote Employee">
            <table class="teble_bg" style="background-color:#a4cd0f">
            <tr>
            <td class="family">Employee Name</td>
            <td><label id="lblEmpName"></label></td>
            </tr>
            <tr>
            <td class="family">Current Designation</td>
            <td><label id="lblDesignation"></label></td>
            </tr>
            <tr>
            <td class="family">Promoted Designation</td>
            <td><select id="cmbDesignation"></select></td>
            </tr>
            <tr>
            <td class="family"><input id="btnPromote" type="button" value="Promote" onclick="return Promote();" style="background-color:#00DBF1;"/></td>
            <td class="family"><input id="btnPCancle" type="button" value="Cancel" style="background-color:#00DBF1;"/></td>
            </tr>
            </table>
        </div>
        
        <div id='divHike' style="display:none;" title="Hike Employee">
            <table class="teble_bg" style="background-color:#a4cd0f">
            <tr>
            <td class="family">Employee Name</td>
            <td><label id="lblEmpNameHike" style="width: 220px;border:1px solid silver"></label></td>
            </tr>
            <tr>
            <td class="family">Current Salary</td>
            <td><label id="lblSalary" style="width: 220px;border:1px solid silver"></label></td>
            </tr>
            <tr>
            <td class="family">Salary after hike</td>
            <td><input type="text" id="txtSalary" onkeyup="return CalculatePercentage();" style="width: 220px;border:1px solid silver"/></td>
            </tr>
            <tr>
            <td class="family">Hike Percentage(in %)</td>
            <td><label id="HikePer" style="width: 220px;border:1px solid silver"></label></td>
            </tr>
            <tr>
            <td class="family"><input id="btnHike" type="button" value="Hike" onclick="return Hike();" style="border:1px solid silver;background-color:#00DBF1;"/></td>
            <td class="family"><input id="btnHCancel" type="button" value="Cancel" style="border:1px solid silver;background-color:#00DBF1;"/></td>
            </tr>
            </table>
        </div>
    </div>
    
    <input id="hdnEmployeeID" type="hidden" runat="server"/>
</body>

<script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

<script src="Resources/js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

<script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="Resources/js/Webutility.js"></script>

<script type="text/javascript" src="Resources/js/toolbar.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

<script type="text/javascript" src="Resources/js/jquery.validate.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.button.js"></script>

<script type="text/javascript">
    $(document).keydown(function(e) {

        var nodeName = e.target.nodeName.toLowerCase();
        if (e.which == 8) {
            if ((nodeName == 'input' && e.target.type == 'text') || nodeName == 'textarea') {
            }
            else { e.preventDefault(); }
        }
    });
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });   
    jQuery(document).ready(function() {

    $("#txtSalary").keydown(function(event) {
        // Allow only backspace and delete
        if( !(event.keyCode == 8                                // backspace
        || event.keyCode == 46                              // delete
        || (event.keyCode >= 35 && event.keyCode <= 40)     // arrow keys/home/end
        || (event.keyCode >= 48 && event.keyCode <= 57)     // numbers on keyboard
        || (event.keyCode >= 96 && event.keyCode <= 105)
        ) || (event.shiftKey))  // number on keypad
        {
            return false;
        }
    });
    
        LoadDate(); 
        LoadDesignation();        
        $('#btnPCancle').click(function() {
            onPCancel();
        });
        $('#btnHCancel').click(function() {
            onHCancel();
        });

    });
    function Hike()
    {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        if (id) {
            var ret = jQuery("#list").jqGrid('getRowData', id);
            if ($("#txtSalary").val() == "") {
                alert("Enter new salary");
                return;
            }
            var Request = new  Object();
            Request.ID = ret.id;
            Request.EmployeeID = ret.employeeid;
            Request.OldSalary = ret.Salary;
            Request.HikePer = $("#HikePer").text();
            Request.Salary = $("#txtSalary").val();
            Request.Basic = eval($("#txtSalary").val())*(0.40);
            var Response = SendApplicationRequest('<%=HRAppCommands.EMPLOYEE_HIKE%>', Request,true);
            alert("Employee salary hiked successfully");
            onHCancel();
            BindGrid();
        }
        else{
            alert("Select employee");
        }
    }
    function onPCancel(){
        $("#lblEmpName").text("");
        $("#lblDesignation").text("");
        $("#cmbDesignation").val("");
        $('#divPromotion').dialog('close');
    }
    function onHCancel(){
        $("#lblEmpNameHike").text("");
        $("#lblSalary").text("");
        $("#txtSalary").val("");
        $("#HikePer").text("");
        $('#divHike').dialog('close');
    }
    function Promote()
    {
     var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        if (id) {
            if ($("#cmbDesignation").val() == "") {
                alert("Select new designation");
                return;
            }
            var ret = jQuery("#list").jqGrid('getRowData', id);        
            var Request = new  Object();
            Request.ID = ret.id;
            Request.EmployeeID = ret.employeeid;
            Request.OldDesignation = ret.Designation;
            Request.DesignationID = $("#cmbDesignation").val();
            var Response = SendApplicationRequest('<%=HRAppCommands.EMPLOYEE_PROMOTE%>', Request,true);
            if (Response.ResponseCommand == "SUCCESS") {
                alert("Employee promoted successfully");
                onPCancel();
                BindGrid();
            }
            else {
                alert(Response.Message);
            }
        }
        else{
            alert("Select employee");
        }
    }
    function CalculatePercentage()
    {
    
        if(parseFloat($("#txtSalary").val()) >0 && parseFloat($("#lblSalary").text()) !=0 )
        {
            var per = (parseFloat($("#txtSalary").val())-parseFloat($("#lblSalary").text()))/parseFloat($("#lblSalary").text())*100;
            $("#HikePer").text(parseFloat(per).toFixed(2));
        }
        else{
            $("#HikePer").text("");
        }
    }
    function ViewAppraisal(ID,Doc,type)
    {
        window.location.href = "DownloadFileHandler.ashx?DocumentName=" + Doc+ "&Type="+ type+"&ID="+ID;
    }
    function LoadDate()
    {            
        var Response = SendApplicationRequest("<%=HRAppCommands.INTIMATEDATE_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Select Intimation Year";
        optn.value = "";
        document.getElementById('cmbDate').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbDate').options.add(optn);
            }
        }
    }
    function LoadDesignation() {

            var Response = SendApplicationRequest("<%=HRAppCommands.DESIGNATION_COMBO_DETAILS%>", "");
            var optn = document.createElement("OPTION");
            optn.text = "Choose Designation";
            optn.value = "";
            document.getElementById('cmbDesignation').options.add(optn);
            if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                var arr = Response.ResponseObject;
                for (var i = 0; i < arr.length; ++i) {
                    var optn = document.createElement("OPTION");
                    optn.text = arr[i]['Value'];
                    optn.value = arr[i]['ID'];
                    document.getElementById('cmbDesignation').options.add(optn);
                }
            }
        }
    function BindGrid() {
    if($("cmbDate").val() == "") {
        alert("Select Intimation Date");
        return ;
    }
        $(".dvGrid1").html("<table id='list'></table>");
        var myGrid = $('#list');
         var Request = new Object();
	        Request.ID=$("#cmbDate").val();
	        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_TEAM_MEMBER_FOR_RATING%>', Request, true);
	        
	        Response.ResponseObject.colModel = [
	            { name: 'Sno', index: 'Sno', width: 20,hidden:true,sortable:false},
                { name: 'id', index: 'id', width: 20,hidden:true,sortable:false},
                { name: 'intimationid', index: 'intimationid', width: 20,hidden:true,sortable:false},
                { name: 'employeeid', index: 'employeeid', width: 20,hidden:true,sortable:false},
                { name: 'employee', index: 'employee', width: 100, editable: true,sortable:false,resizable:false },
                { name: 'goals', index: 'goals', width: 20, editable: true,sortable:false ,hidden:true},
                { name: 'grade', index: 'grade', width: 30, editable: true,sortable:false ,hidden:true},
                { name: 'addgoals', index: 'addgoals', width: 70, editable: true,sortable:false,align:'center',resizable:false },
                { name: 'addgrade', index: 'addgrade', width: 70, editable: true,sortable:false,align:'center',resizable:false }  ,
                { name: 'view', index: 'view', width: 50, editable: true,sortable:false,align:'center',hidden:true },
                { name: 'Designation', index: 'Designation', width: 20,hidden:true,sortable:false},
                { name: 'PreDesignation', index: 'PreDesignation', width: 100,hidden:false,sortable:false,resizable:false},
                { name: 'NewDesignation', index: 'NewDesignation', width: 60,sortable:false,resizable:false} ,
                { name: 'Salary', index: 'Salary', width: 20,hidden:true,sortable:false},
                { name: 'PreSalary', index: 'PreSalary', width: 50,hidden:false,sortable:false,resizable:false},
                { name: 'CurrSalary', index: 'CurrSalary', width: 50,hidden:false,sortable:false,resizable:false},
                { name: 'HikePer', index: 'HikePer', width: 30,sortable:false,resizable:false},
                { name: 'teamid', index: 'teamid', width: 60,sortable:false,hidden:true},
                { name: 'team', index: 'team', width: 60,sortable:false,hidden:true}                 
                            
            ];
           Response.ResponseObject.caption = "View Appraisals";
           var he = $(window).height();
           var reduce = he * 0.63;
           Response.ResponseObject.height = reduce;
           Response.ResponseObject.autowidth= true;
            Response.ResponseObject.rowNum=-1;
            Response.ResponseObject.grouping=true;
            Response.ResponseObject.resizable =false; 
   	        Response.ResponseObject.groupingView = {
   		        groupField : ['team'],
   		        groupColumnShow : [false],
   		        groupCollapse : false,
   		        groupText : ['<b>{0}</b>']
   	        };
            jQuery("#list").jqGrid(Response.ResponseObject);
            jQuery("#t_list").html("");
            jQuery("#t_list").append("<button type='button' id='view' value='View' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view.jpg' height=18px;width=18px alt='' /><br/><div></div><span>View</span></button>");
            $("#t_list").append("<button type='button' id='promote' value='Promote Employee' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/promote_employee.png' height=18px;width=18px alt='' /><br/><div></div><span>Promote Employee</span></button>");
            $("#t_list").append("<button type='button' id='hike' value='Salary Hike' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/salary_hike.png' height=18px;width=18px alt='' /><br/><div></div><span>Salary Hike</span></button>");
            
//            jQuery("#t_list").append("<input type='button' id='view' value='View' style='font-size:12px;font-family:arial;margin:8px;'/> ");
//            $("#t_list").append("<input type='button' id='promote' value='Promote Employee' style='font-size:12px;font-family:arial;margin:8px;'/> ");
//            $("#t_list").append("<input type='button' id='hike' value='Salary Hike' style='font-size:12px;font-family:arial;margin:8px;'/> ");

        $("input,button", "#t_list").click(function(id) {
            if (id.currentTarget.id == "view") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    if (ret.id == 0) {
                        alert("Goal/Grade not submitted");
                        return;
                    }
                    else {
                        if (ret.grade != "") {
                            ViewAppraisal(ret.id, ret.grade, "empgrade");
                        } else if (ret.goals != "") {
                            ViewAppraisal(ret.id, ret.goals, "empgoal");
                        }
                        else {
                            alert("Not Submited");
                        }
                    }
                }
                else {
                    alert("Select a row  to view employee review form");
                }
            }
            else if (id.currentTarget.id == "promote") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    if ($.trim(ret.NewDesignation) != "") {
                        alert("Employee already Promoted");
                        return;
                    }
                    $("#cmbDesignation").val("");
                    document.getElementById("divPromotion").style.display = "";
                    $('#divPromotion').dialog({
                        height: 200,
                        width: 550,
                        modal: true
                    })
                    $("#lblEmpName").text(ret.employee);
                    $("#lblDesignation").text(ret.Designation);
                }
                else {
                    alert("Select Employee");
                }
            }
            else if (id.currentTarget.id == "hike") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    if ($.trim(ret.HikePer) != "0") {
                        alert("Salary hike already done");
                        return;
                    }
                    $("#txtSalary").val("");
                    $("#HikePer").text("");
                    document.getElementById("divHike").style.display = "";
                    $('#divHike').dialog({
                        height: 200,
                        width: 550,
                        modal: true
                    })
                    $("#lblEmpNameHike").text(ret.employee);
                    $("#lblSalary").text(ret.Salary);
                }
                else {
                    alert("Select Employee");
                }
            }
        }); 
        
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
        
    }
</script>
</html>
