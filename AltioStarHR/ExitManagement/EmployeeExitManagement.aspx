<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeExitManagement.aspx.cs"
    EnableViewState="false" Buffer="true" Inherits="AltioStarHR.ExitManagement.EmployeeExitManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee Exit Management</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <%--<link href="../Resources/css/New%20Css/Stylesheet1.css" rel="stylesheet" type="text/css" />--%>
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
    <div style="position: relative; width: 100%">
        <img alt="" src="Resources/Images/NewImages/1.png" style="width: 97%; margin-left: 2%;
            height: 53px; margin-top: 0%" />
        <div style="position: absolute; left: 4%; top: 30%; margin-top: 1%;">
            <strong class="family1 imageheadercolor">
                Upload Clearance form</strong>
        </div>
    </div>
    <form id="signupForm" method="get" action="">
    </form>
    
        <div id="box" style='margin-left:2%;width: 97%'>
            <table id='list'>
            </table>
        </div>
        <div id="pager">
        
    </div>
    <input type="hidden" id='hdnEmployeeID' runat="server" />
</body>


<script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

<script type="text/javascript" src="Resources/js/jquery-ui-1.8.16.custom.min.js"></script>

<script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="Resources/js/Webutility.js"></script>

<script type="text/javascript" src="Resources/js/toolbar.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

<script src="Resources/js/jquery.ui.button.js" type="text/javascript"></script>

<script type="text/javascript" src="Resources/js/jquery.validate.js"></script>

<%-- ReSharper disable once InconsistentNaming --%>
<%-- ReSharper disable UnusedLocals --%>

<script type="text/javascript">
 jQuery(document).ready(function() {
     BindGrid();

 });

 function BindGrid() {
 
  $(".dvGrid").html("<table id='list'></table>");
     
     var myGrid = $('#list');    
        var request = new Object();        
        request.EmployeeID = $('#hdnEmployeeID').val();        
        var response = SendApplicationRequest('<%=HRAppCommands.GET_EMPLOYEE_EXIT_MANAGEMENT_DETAILS%>', request, true);        
        response.ResponseObject.colModel = [
   		                { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		                { name: 'employeeid', index: 'employeeid', width: 100, editable: true,hidden: true }, 
   		                { name: 'exittypeid', index: 'exittypeid', width: 100, editable: true,hidden: true }, 
   		                { name: 'employeecode', index: 'employeecode', width: 50,editable: true },		            		            
   		                { name: 'employeename', index: 'employeename', width: 100,editable: true },   		                
   		                { name: 'exittype', index: 'exittype', width: 50,editable: true },
   		                { name: 'exitdate', index: 'exitdate', width: 50,editable: true },   		              
   		                { name: 'documentname', index: 'documentname', width: 10, editable: false,hidden:true}     		               		       	             
   	            ];
        response.ResponseObject.caption = "";
        
        response.ResponseObject.autowidth= true;
        
        myGrid.jqGrid(response.ResponseObject);
        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() { 
                myGrid[0].toggleToolbar();
            }
        });
        //        $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
        $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });   
//        $("#list").closest(".ui-jqgrid-bdiv").height("auto");
        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        $("#t_list").append("<button type='button' id='upload' value='Upload clearance form' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/upload_clearance_form.png' height=18px;width=18px alt='' /><br/><div></div><span>Upload clearance form</span></button>");
        $("#t_list").append("<button type='button' id='view' value='View' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view.jpg' height=18px;width=18px alt='' /><br/><div></div><span>View</span></button>");
        
//        $("#t_list").append("<input type='button' id='upload' value='Upload clearance form'  style='font-size:12px;font-family:arial;margin:8px;'/> ");
//        $("#t_list").append("<input type='button' id='view' value=' View'  style='font-size:12px;font-family:arial;margin:8px;'/> ");
        
        $("input,button", "#t_list").click(function(id) {
            var ret;
            if (id.currentTarget.id == "upload") {                    

                id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    ret = jQuery("#list").jqGrid('getRowData', id);
                    UpdateGrade(ret.id);
                }
                else{ 
                    alert("Please select an employee");
                }            
            }
            else if (id.currentTarget.id == "view") {
                id = jQuery("#list").jqGrid('getGridParam', 'selrow'); 
                if (id) {                 
                    ret = jQuery("#list").jqGrid('getRowData', id);
                    if (ret.documentname != "") {
                        window.location.href = "DownloadFileHandler.ashx?DocumentName=" + ret.documentname + "&Type=exitmanagement" + "&EmployeeID=" + ret.employeeid;
                    }
                    else 
                       {
                      alert("Your clearance form is not yet uploaded");   
                    }

                }
                else { alert("Please select an employee"); }                
            }
        }); 
        
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

 }

 function UpdateGrade(id)
    {
        var url = "ExitManagement/UploadNDForm.aspx?ID="+id;
        var retval = window.showModalDialog(url, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");

        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        var request = new Object();
        request.EmployeeID = $('#hdnEmployeeID').val();
        var Response = SendApplicationRequest('<%=HRAppCommands.GET_EMPLOYEE_EXIT_MANAGEMENT_DETAILS%>', request, true);     
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
    }
   

</script>

</html>
