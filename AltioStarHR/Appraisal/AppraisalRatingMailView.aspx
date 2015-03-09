<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppraisalRatingMailView.aspx.cs" Inherits="AltioStarHR.Masters.AppraisalRatingMailView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Conduct Appraisal</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
        <div class="header_title2">
            Conduct Appraisal</div>
            <div>     
            <br />       
            <table class="teble_bg" width="100%">
            <tr>
            <td><b>Select Intimation Date</b></td>
            <td> <select id="cmbDate" onchange="return BindGrid();"></select></td>
            <td align="right"><input id="btnLogout" value="Logout" type="button" onclick="return LogOut();" /></td>
            </tr>
            </table>
            </div>
        <div class="dvGrid">
            <table id='list'></table>
        </div>
        <div id="ViewAppraisal" style="display:none">
            
            <input type="button" onclick="return OnCancel();" />
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
    var CleanExit = false;
    $(document).keydown(function(e) {

        var nodeName = e.target.nodeName.toLowerCase();
        if (e.which == 8) {
            if ((nodeName == 'input' && e.target.type == 'text') || nodeName == 'textarea') {
            }
            else { e.preventDefault(); }
        }
    });


    var mode = "";
    var activeStatus = true;
    var IntimationID=0;

    jQuery(document).ready(function() {
        LoadDate();  
    });
    function LogOut() {
        if (!confirm('Confirm LogOut')) {
            return false;
        }

        CleanExit = true;
        location.href = "module91.axd/logoutuser";
    }
    function AddGoal(EmployeeID, IID) {
        var url = "Appraisal/EmployeeGoalUpload.aspx?IntimationID=" + IID + "&EmployeeID=" + EmployeeID + "&ID=0";
        var retval = window.showModalDialog(url, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");

    BindGrid();
    }
    function AddGrade(ID)
    {
         var url = "Appraisal/EmployeeGradeUpload.aspx?ID="+ID;
         var retval = window.showModalDialog(url, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
         BindGrid();
    }
    function UpdateGoal(ID)
    {
        var url = "Appraisal/EmployeeGoalUpload.aspx?ID="+ID;
        var retval = window.showModalDialog(url, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");        
        BindGrid();
    }
    function DeleteGoal(ID)
    {
        var Request = new Object();
        Request.ID=ID;
        var Response = SendApplicationRequest('<%=HRAppCommands.DELETE_EMPLOYEE_GOALS%>', Request, true);
        
        alert("Goal deleted successfully");
        BindGrid();
    }
    function UpdateGrade(ID)
    {
        var url = "Appraisal/EmployeeGradeUpload.aspx?ID="+ID;
        var retval = window.showModalDialog(url, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");

        BindGrid();
    }
    function DeleteGrade(ID)
    {
        var Request = new Object();
        Request.ID=ID;
        var Response = SendApplicationRequest('<%=HRAppCommands.DELETE_EMPLOYEE_GRADE%>', Request, true);
        alert("Grade deleted successfully");
        BindGrid();
    }
    function viewDoc(ID)
    {       
        var ret = jQuery("#list").jqGrid('getRowData', ID);
        window.location.href = "DownloadFileHandler.ashx?Type=empappraisal"+ "&ID="+ID;
    }
    
    function ViewAppraisal(ID,Doc,type)
    {
        window.location.href = "DownloadFileHandler.ashx?DocumentName=" + Doc+ "&Type="+ type+"&ID="+ID;
    }
    function LoadDate()
    {            
        var Response = SendApplicationRequest("<%=HRAppCommands.INTIMATEDATE_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Choose Intimated Date";
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
    function BindGrid() {
    if($("cmbDate").val() == "") {
        alert("Select Intimation Date");
        return ;
    }
        $(".dvGrid").html("<table id='list'></table>");
        var myGrid = $('#list');
         var Request = new Object();
	        Request.ID=$("#cmbDate").val();
	        Request.ManagerID=$("#hdnEmployeeID").val();
	        var Response = SendApplicationRequest('<%=HRAppCommands.GET_TEAM_MEMBER_FOR_APPRAISAL%>', Request, true);
	        
	        Response.ResponseObject.colModel = [
	            { name: 'Sno', index: 'Sno', width: 20,hidden:true,sortable:false},
                { name: 'id', index: 'id', width: 20,hidden:true,sortable:false},
                { name: 'intimationid', index: 'intimationid', width: 20,hidden:true,sortable:false},
                { name: 'employeeid', index: 'employeeid', width: 20,hidden:true,sortable:false},
                { name: 'employee', index: 'employee', width: 100, editable: true,sortable:false },
                { name: 'goals', index: 'goals', width: 20, editable: true,sortable:false ,hidden:true},
                { name: 'grade', index: 'grade', width: 30, editable: true,sortable:false ,hidden:true},
                { name: 'addgoals', index: 'addgoals', width: 100, editable: true,sortable:false,align:'center' },
                { name: 'addgrade', index: 'addgrade', width: 100, editable: true,sortable:false,align:'center' }  ,
                { name: 'view', index: 'view', width: 50, editable: true,sortable:false,align:'center' ,hidden:true} ,
                { name: 'status', index: 'status', width: 50, editable: true,sortable:false,align:'center',hidden:true } , 
                { name: 'teamid', index: 'teamid', width: 50, editable: true,sortable:false,align:'center',hidden:true },
                { name: 'team', index: 'team', width: 50, editable: true,sortable:false,align:'center',hidden:true}            
                            
            ];
                Response.ResponseObject.caption = "Conduct Appraisal";            
            Response.ResponseObject.width="900";
            Response.ResponseObject.height="100%";
            Response.ResponseObject.rowNum=-1;
            Response.ResponseObject.grouping=true;
   	        Response.ResponseObject.groupingView = {
   		        groupField : ['team'],
   		        groupColumnShow : [false],
   		        groupCollapse : false
   	        };
            jQuery("#list").jqGrid(Response.ResponseObject);	
        jQuery("#t_list").append("<input type='button' id='addgoal' value='Upload Goal'  style='height:24px;font-size:-3;display:none'/> ");
        jQuery("#t_list").append("<input type='button' id='editgoal' value='Edit Goal'  style='height:24px;font-size:-3;display:none'/> ");
        jQuery("#t_list").append("<input type='button' id='deletegoal' value='Delete Goal'  style='height:24px;font-size:-3;display:none'/> ");
        jQuery("#t_list").append("<input type='button' id='addgrade' value='Upload Grade'  style='height:24px;font-size:-3;display:none'/> ");
        jQuery("#t_list").append("<input type='button' id='editgrade' value='Edit Grade'  style='height:24px;font-size:-3;display:none'/> ");
        jQuery("#t_list").append("<input type='button' id='deletegrade' value='Delete Grade'  style='height:24px;font-size:-3;display:none'/> ");
        jQuery("#t_list").append("<input type='button' id='notify' value='Notify'  style='height:24px;font-size:-3;display:none'/> ");    
//        jQuery("#t_list").append("<input type='button' id='view' value='View' style='height:24px;font-size:-3'/> ");        
//        jQuery("#t_list").append("<input type='button' id='download' value='Download Form' style='height:24px;font-size:-3'/> ");        

jQuery("#t_list").append("<button type='button' id='view' value='view' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view.jpg' height=18px;width=18px alt='' /><br/><div></div><span>View</span></button>");
jQuery("#t_list").append("<button type='button' id='download' value='Download Form' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/download-form.png' height=18px;width=18px alt='' /><br/><div></div><span>Download Form</span></button>");
        $("input,button", "#t_list").click(function(id) {
            if (id.currentTarget.id == "notify") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                     var ret = jQuery("#list").jqGrid('getRowData', id); 
                     var PreRequest = new Object();
                     PreRequest.IntimationID =$("#cmbDate").val();
                     PreRequest.TeamID =ret.teamid;
                     if ($.trim(ret.status) == "GOL"){
                     if($.trim(ret.addgrade) == "Not Initiated")
                     {
                        alert(ret.addgrade);
                        return;
                     }
                     PreRequest.Type ="Grade";
                     }
                     else if ($.trim(ret.status) == ""){
                     PreRequest.Type ="Goal";
                     }
                     var PreResponse = SendApplicationRequest('<%=HRAppCommands.CHECK_ALL_APPRAISAL_DOC_SUBMITTED%>', PreRequest,true);
                    if(PreResponse.Message == "PENDING")
                    {
                        alert("Upload Document for all the team member before notify");
                        return;
                    }
                    if ($.trim(ret.status) == "GOL"){
                        var Request = new Object();
                        Request.IntimationID =$("#cmbDate").val();
                        Request.EmployeeID =$("#hdnEmployeeID").val();
                        Request.TeamID =ret.teamid;
                        Request.Type ="Grade";
                        var Response = SendApplicationRequest('<%=HRAppCommands.APPRAISAL_SUMBITTED%>', Request,true);
                        alert("Notification to HR for grade submitted successfully");
                        BindGrid(); 
                    }else if ($.trim(ret.status) == ""){
                        var Request = new Object();
                        Request.IntimationID =$("#cmbDate").val();
                        Request.EmployeeID =$("#hdnEmployeeID").val();
                        Request.TeamID =ret.teamid;
                        Request.Type ="Goal";
                        var Response = SendApplicationRequest('<%=HRAppCommands.APPRAISAL_SUMBITTED%>', Request,true);
                        alert("Notification to HR for goal submitted successfully"); 
                        BindGrid();
                    } 
                }
                else{
                    alert("Select row to intimate");
                }               
            }
            else if (id.currentTarget.id == "addgoal") {       
                 
               var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    AddGoal(ret.employeeid,$("#cmbDate").val()); 
                    BindGrid();
                }
                else{
                    alert("Select row to add goal");
                }
            }
            else if (id.currentTarget.id == "addgrade") {
               var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    AddGrade(ret.id);        
                    BindGrid();           
                }
                else{
                    alert("Select a row");
                }
            }
            else if (id.currentTarget.id == "view") {
               var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    if(ret.id==0)
                    {
                        alert("Goal/Grade not submitted");
                        return;
                    }
                    else{
                        if (ret.grade != ""){
                            ViewAppraisal(ret.id,ret.grade,"empgrade");
                        }else if (ret.goals != ""){
                            ViewAppraisal(ret.id,ret.goals,"empgoal");
                        }      
                        else{
                            alert("Not Submited");
                        }   
                    }         
                }
                else{
                   alert("Select a row");
                }
            }
            else if (id.currentTarget.id == "editgoal") {
               var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    UpdateGoal(ret.id);  
                    BindGrid();       
                }
                else{
                    alert("Select row to edit goal");
                }
            }
            else if (id.currentTarget.id == "deletegoal") {
               var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                 if (confirm('Do you want to delete?') == false) return;
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    DeleteGoal(ret.id);  
                    BindGrid();      
                }
                else{
                    alert("Select a row");
                }
            }
            else if (id.currentTarget.id == "editgrade") {
               var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    UpdateGrade(ret.id);  
                    BindGrid();       
                }
                else{
                    alert("Select a row");
                }
            }
            else if (id.currentTarget.id == "deletegrade") {
               var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    if (confirm('Do you want to delete?') == false) return;
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    DeleteGrade(ret.id); 
                    BindGrid();        
                }
                else{
                    alert("Select a row");
                }
            }
            else if (id.currentTarget.id == "download") {
               viewDoc($("#cmbDate").val());  
            }
        });   
        jQuery("#list").jqGrid('setGridParam', {
            onSelectRow:function(rowid,iRow,iCol,e){
                var ret = jQuery("#list").jqGrid('getRowData', rowid);
                
                
                if(ret.addgoals != "Not Yet submitted")
                {
                    document.getElementById("addgoal").style.display="none";  
                }
                else
                {
                    document.getElementById("addgoal").style.display="";
                }
                if(ret.addgrade != "Not Yet submitted")
                {
                    document.getElementById("addgrade").style.display="none";  
                }
                else
                {
                    document.getElementById("addgrade").style.display="";
                }                
                if($.trim(ret.status)=="" && ret.goals != "")
                {
                    document.getElementById("editgoal").style.display="";
                    document.getElementById("deletegoal").style.display="";
                }
                else if($.trim(ret.status)=="GOL" && ret.grade != "")
                {   
                    document.getElementById("editgrade").style.display="";
                    document.getElementById("deletegrade").style.display="";
                    document.getElementById("editgoal").style.display="none";
                    document.getElementById("deletegoal").style.display="none";
                }
                else{
                    document.getElementById("editgrade").style.display="none";
                    document.getElementById("deletegrade").style.display="none";
                    document.getElementById("editgoal").style.display="none";
                    document.getElementById("deletegoal").style.display="none";
                }
                if($.trim(ret.status)==''){
                     document.getElementById("notify").style.display=""; 
                     $("#notify").val("Notify Goal");
                }
                else if($.trim(ret.status)=="GOL")
                {
                    document.getElementById("notify").style.display="";
                    $("#notify").val("Notify Grade");
                }
                else{
                     document.getElementById("notify").style.display="none"; 
                }
                
            }
        });
        
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
        
    }
</script>



</html>
