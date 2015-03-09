<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OldViewAppraisal.aspx.cs" Inherits="AltioStarHR.Masters.OldViewAppraisal" %>

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
    <div class="family">
        <div class="header_title2" >
            View Appraisal</div>
            <div>
            Select Intimation Date <select id="cmbDate" onchange="return BindGrid();" class="family"></select>
            </div>
        <div class="dvGrid">
            <table id='list'></table>
        </div>
        <div id="ViewAppraisal" style="display:none">
            
            <input type="button" onclick="return OnCancel();"class="family" />
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
        LoadDate(); 
    });
    
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
	        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_TEAM_MEMBER_FOR_VIEW%>', Request, true);
	        
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
            Response.ResponseObject.caption = "Team Member List";            
            Response.ResponseObject.width="900";
            Response.ResponseObject.height="100%";
            Response.ResponseObject.rowNum=-1;
            Response.ResponseObject.grouping=true;
   	        Response.ResponseObject.groupingView = {
   		        groupField : ['team'],
   		        groupColumnShow : [false],
   		        groupCollapse : true
   	        };
            jQuery("#list").jqGrid(Response.ResponseObject);	
            
        jQuery("#t_list").append("<input type='button' id='view' value='View' style='height:24px;font-size:-3'/> ");        
        
        $("input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "view") {
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
                    alert("Select row to add grade");
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
