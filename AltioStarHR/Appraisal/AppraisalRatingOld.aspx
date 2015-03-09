<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppraisalRatingOld.aspx.cs" Inherits="AltioStarHR.Masters.AppraisalRatingOld" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Appraisal Rating</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
        <div class="header_title2">
         <span class="family">  Appraisal Rating</span></div>
        <div class="dvGrid">
            <table id='list'></table>
        </div>
        <div id="ViewAppraisal" style="display:none">
            
            <input type="button" onclick="return OnCancel();" class="family"/>
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


    var mode = "";
    var activeStatus = true;
    var IntimationID=0;

    jQuery(document).ready(function() {

        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        BindGrid();       
    });
    function viewDoc(ID)
    {       
        var ret = jQuery("#list").jqGrid('getRowData', ID);
        window.location.href = "DownloadFileHandler.ashx?DocumentName=" + ret.documentname+ "&Type=appraisal"+ "&ID="+ID;
    }
    function AddGoal(EmployeeID)
    {
        var url = "Appraisal/EmployeeGoalUpload.aspx?IntimationID="+IntimationID+"&EmployeeID="+EmployeeID+"&ID=0";
        var retval = window.showModalDialog(url, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
        //if (retval) {
          //alert('Employee goals submitted successfully');
          BindGrid();
      //}
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
        alert("Form deleted succssfully");
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
        alert("Form deleted succssfully");
        BindGrid();
    }
    function AddGrade(ID)
    {
         var url = "Appraisal/EmployeeGradeUpload.aspx?ID="+ID;
            var retval = window.showModalDialog(url, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
            //if (retval) {
              //alert('Employee grade submitted successfully');
              BindGrid();
          //}
    }
    function ViewAppraisal(ID,Doc,type)
    {
        window.location.href = "DownloadFileHandler.ashx?DocumentName=" + Doc+ "&Type="+ type+"&ID="+ID;
    }
    function BindGrid() {
        $(".dvGrid").html("<table id='list'></table>");
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=HRAppCommands.INTIMATION%>', '');
        Response.ResponseObject.colModel = [
   		            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'goal', index: 'goal', width: 100},
   		            { name: 'appraisal', index: 'appraisal', width: 100 },
   		            { name: 'intimateby', index: 'intimateby', width: 100, editable: false},
   		            { name: 'view', index: 'view', width: 50, editable: false,align:'center'},
   		            { name: 'documentname', index: 'documentname', width: 10, editable: false,hidden:true}
   	            ]
        Response.ResponseObject.subGrid = true;
        myGrid.jqGrid(Response.ResponseObject);
        
        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });
        
        
        
         jQuery("#list").jqGrid('setGridParam', { subGridRowExpanded: function(subgrid_id, row_id) {
            IntimationID=row_id;
            var ret = jQuery("#list").jqGrid('getRowData', row_id);
            var subgrid_table_id = subgrid_id+"_t";
	        $("#"+subgrid_id).html("<table id='"+subgrid_table_id+"' class='scroll'></table>");
	        var Request = new Object();
	        Request.ID=row_id;
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
                { name: 'view', index: 'view', width: 50, editable: true,sortable:false,align:'center' } ,
                { name: 'status', index: 'status', width: 50, editable: true,sortable:false,align:'center',hidden:true }              
                           
            ];
            Response.ResponseObject.caption = "Team Member List";            
            Response.ResponseObject.width="800";
            Response.ResponseObject.height="100%";
            Response.ResponseObject.rowNum=-1;
            jQuery("#"+subgrid_table_id).jqGrid(Response.ResponseObject);	
            
        jQuery("#t_"+subgrid_table_id).append("<input type='button' id='goal_"+subgrid_table_id+"' value='Goal Submitted'  style='height:24px;font-size:-3'/> ");
        jQuery("#t_"+subgrid_table_id).append("<input type='button' id='grade_"+subgrid_table_id+"' value='Grade Submitted' style='height:24px;font-size:-3'/> ");        

        $("input", "#t_"+subgrid_table_id).click(function(id) {

            if (id.currentTarget.id == "goal_"+subgrid_table_id) {
                var id = jQuery("#"+subgrid_table_id).jqGrid('getGridParam', 'selrow');
                if (id) {
                     var ret = jQuery("#list").jqGrid('getRowData', id);
                     var Request = new Object();
                     //Request.ID = ret.id;
                     Request.ID =$("#hdnEmployeeID").val();//Hardcode
                     Request.Type ="Goal";
                     var Response = SendApplicationRequest('<%=HRAppCommands.APPRAISAL_SUMBITTED%>', Request,true);
                     alert("Notification to HR for goal submitted successfully");   
                }
                else{
                    alert("Select row to intimate");
                }               
            }
            else if (id.currentTarget.id == "grade_"+subgrid_table_id) {
               var id = jQuery("#"+subgrid_table_id).jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                     var Request = new Object();
                     Request.ID =$("#hdnEmployeeID").val();//Hardcode
                     Request.Type ="Grade";
                     var Response = SendApplicationRequest('<%=HRAppCommands.APPRAISAL_SUMBITTED%>', Request,true);
                     alert("Notification to HR for grade submitted successfully");   
                   
                }
                else{
                    alert("Select row to intimate");
                }
            }
        });   
        jQuery("#"+subgrid_table_id).jqGrid('setGridParam', {
            onSelectRow:function(rowid,iRow,iCol,e){
                var ret = jQuery("#"+subgrid_table_id).jqGrid('getRowData', rowid);
                if(ret.status=='GOL')
                {
                    document.getElementById("goal_"+subgrid_table_id).style.display="none";         
                    document.getElementById("grade_"+subgrid_table_id).style.display="";    
                }
                else if(ret.status=='GRA')
                {   
                    document.getElementById("goal_"+subgrid_table_id).style.display="none";         
                    document.getElementById("grade_"+subgrid_table_id).style.display="none";   
                }
                else{
                    document.getElementById("goal_"+subgrid_table_id).style.display="";         
                    document.getElementById("grade_"+subgrid_table_id).style.display="";   
                }
            }
        });
            	    
        }});    
        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        
        
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
