<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAppraisal.aspx.cs" Inherits="AltioStarHR.Masters.ViewAppraisal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>View Grade/Goal</title>
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
        .ui-jqgrid tr.jqgroup td
        {
            font-size: 1.1em;
            font-weight: bold !important;
            background-color: Gray;
            color: White;
        }
        
    </style>
</head>
<body>
    <div>
        <%--<div class="header_title2">
            View Grade/Goal</div>--%>
            <div style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png" style="width: 97%; margin-left: 2%;height: 53px"/>
    <div style="position:absolute;left:4%;top:52%;">
  <strong class="family1 imageheadercolor">View Grade/Goal</strong>
    </div>
</div>
           <div id="divSearchFilter">
        <table style="margin-left:1.5%;margin-top:-2%;width:98%">
            <tr>
                <td >
                    <fieldset>
                        <table  class="teble_bg"  style="width:100%;background-color:#00daf5">
                             <tr>
                                 
                                <td colspan="10" align="center" >
                                    <table class="teble_bg" style="background-color:#00daf5">
                                    <tr>
                                    <td style="font-family:Arial;font-size:13px;"><b style="float:right">Select Intimation Year</b></td>
                                    <td> <select id="cmbDate" onchange="return BindGrid();" class="family" style="float:left"></select></td>
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
    
    function ViewAppraisal(id,doc,type)
    {
        window.location.href = "DownloadFileHandler.ashx?DocumentName=" + doc+ "&Type="+ type+"&ID="+id;
    }
    function LoadDate()
    {            
        var response = SendApplicationRequest("<%=HRAppCommands.INTIMATEDATE_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Select Intimation Year";
        optn.value = "";
        document.getElementById('cmbDate').options.add(optn);
        if (response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbDate').options.add(optn);
            }
        }
    }

    //    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });   
    
    function BindGrid() {
    if($("cmbDate").val() == "") {
        alert("Select Intimation Date");
        return ;
    }
        $(".dvGrid1").html("<table id='list'></table>");
        //var myGrid = $('#list');
         var request = new Object();
	        request.ID=$("#cmbDate").val();
	        var response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_TEAM_MEMBER_FOR_RATING_VIEW%>', request, true);
            response.ResponseObject.colModel = [
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
            response.ResponseObject.caption = "View Grade/Goal";
            var he = $(window).height();
            var reduce = he * 0.54;
            response.ResponseObject.height = reduce;
            response.ResponseObject.autowidth= true;
            response.ResponseObject.rowNum=-1;
            response.ResponseObject.grouping=true;  
            response.ResponseObject.resizable =false;    
   	        response.ResponseObject.groupingView = {
   		        groupField : ['team'],
   		        groupColumnShow : [false],
   		        groupCollapse : true
   	        };
        response.ResponseObject.gridComplete = function() {
            var lista = jQuery("#list").getDataIDs();
            for (var i = 0; i < lista.length; i++) {
                var rowData = jQuery('#list').getRowData(lista[i]);
                if ($.trim(rowData['grade']) != '') {
                    $('#list').jqGrid('setRowData', lista[i], false, { background: '#FF9999' });
                } else if ($.trim(rowData['goals']) != '') {
                    $('#list').jqGrid('setRowData', lista[i], false, { background: '#99FF99' });
                }
            }
        };
        jQuery("#list").jqGrid(response.ResponseObject);
        jQuery("#t_list").html("");
//        jQuery("#t_list").append("<input type='button' id='view' value='View' style='height:24px;font-size:-3'/> ");     
//        jQuery("#t_list").append("<label style='color:white;background-color:gray;height:24px;font-size:-3;padding:4px'>Team name</label><label style='padding:4px'/>");    
//        jQuery("#t_list").append("<label style='color:black;background-color:#FF9999;height:24px;font-size:-3;padding:4px'>Grade Submitted</label><label style='padding:4px'/>");    
//        jQuery("#t_list").append("<label style='color:black;background-color:#99FF99;height:24px;font-size:-3;padding:4px'>Goal Submitted</label><label style='padding:4px'/>");

//      jQuery("#t_list").append("<input type='button' id='view' value='View' style='font-size:12px;font-family:arial;margin:8px;'/> ");
        jQuery("#t_list").append("<button type='button' id='view' value='view' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view.jpg' height=18px;width=18px alt='' /><br/><div></div><span>View</span></button>");
        jQuery("#t_list").append("<label style='color:white;background-color:gray;height:24px;font-size:12px;padding:4px'>Team name</label><label style='padding:4px'/>");
        jQuery("#t_list").append("<label style='color:black;background-color:#FF9999;height:24px;font-size:12px;padding:4px'>Grade Submitted</label><label style='padding:4px'/>");
        jQuery("#t_list").append("<label style='color:black;background-color:#99FF99;height:24px;font-size:12px;padding:4px'>Goal Submitted</label><label style='padding:4px'/>");       
        
        $("input,button", "#t_list").click(function(id) {
            if (id.currentTarget.id == "view") {
               var gid = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (gid) {
                    var ret = jQuery("#list").jqGrid('getRowData', gid);
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
                    alert("Select row to view");
                }
            }
        }); 
        
        $('body').css('background', 'none');
        $('#t_list').css('background', 'none');
        $('#t_list').css('background-color', 'white');
        $('#t_list').css('padding', '10px 0');
//        $('#t_list input[type=button]').css('margin-left', '10px');
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
