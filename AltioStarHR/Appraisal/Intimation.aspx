<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Intimation.aspx.cs" Inherits="AltioStarHR.Appraisal.Intimation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Appraisal Intimation</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
    <div>
    <div style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png" style="width: 97%; margin-left: 2%;height: 53px"/>
    <div style="position:absolute;left:4%;top:52%;">
  <strong class="family1 imageheadercolor">Appraisal Intimation</strong>
    </div>
    </div>

        <div class="dvGrid1" style="margin-left:2%;width:97%" id="box" >
            <%--<table id='list'></table>--%>
            </div>

    </div>
    <input id="hdnEmployeeID" type="hidden" runat="server"/>
</body>

<script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

<script type="text/javascript" src="Resources/js/jquery-ui-1.8.16.custom.min.js"></script>

<script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="Resources/js/Webutility.js"></script>

<script type="text/javascript" src="Resources/js/toolbar.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

<script type="text/javascript" src="Resources/js/jquery.validate.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.button.js"></script>

<script type="text/javascript">

    var mode = "";
    var activeStatus = true;
    var diaopen = false;
    jQuery(document).ready(function() {
        ConstructGrid();
    });
    function ConstructGrid()
    {
        $(".dvGrid1").html("<table id='list'></table>");
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=HRAppCommands.INTIMATION%>', '');
        Response.ResponseObject.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'goal', index: 'goal', width: 100 },
            { name: 'appraisal', index: 'appraisal', width: 100 },
            { name: 'intimateby', index: 'intimateby', width: 100, editable: false },
            { name: 'view', index: 'view', width: 50, editable: false, align: 'center', hidden: true },
            { name: 'documentname', index: 'documentname', width: 10, editable: false, hidden: true }
        ];
        
        Response.ResponseObject.rowNum = -1;
        var he = $(window).height();
        var reduce = he * 0.63;
        Response.ResponseObject.height = reduce;
        Response.ResponseObject.autowidth= true;
        
        myGrid.jqGrid(Response.ResponseObject);

        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar();
            }
        });

        //        $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
        $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });
        
        jQuery("#t_list").html("");
        
        
        $("#t_list").append("<button type='button' id='goal' value='Goal Intimation' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/goals_intimation.png' height=18px;width=18px alt='' /><br/><div></div><span>Goal Intimation</span></button>");
        $("#t_list").append("<button type='button' id='update' value='Update Intimation' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/update_intimation.png' height=18px;width=18px alt='' /><br/><div></div><span>Update Intimation</span></button>");
        $("#t_list").append("<button type='button' id='appraisal' value='Appraisal Intimation' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/appraisal_intimation.png' height=18px;width=18px alt='' /><br/><div></div><span>Appraisal Intimation</span></button>");
        $("#t_list").append("<button type='button' id='delete' value='Delete Intimation' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/delete_intimation.png' height=18px;width=18px alt='' /><br/><div></div><span>Delete Intimation</span></button>");
        $("#t_list").append("<button type='button' id='view' value='View Form' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view.jpg' height=18px;width=18px alt='' /><br/><div></div><span>View Form</span></button>");

        
//        $("#t_list").append("<input type='button' id='goal' value='Goal Intimation'  style='font-size:12px;font-family:arial;margin:8px;'/> ");
//        $("#t_list").append("<input type='button' id='update' value='Update Intimation'  style='font-size:12px;font-family:arial;margin:8px;'/> ");
//        $("#t_list").append("<input type='button' id='appraisal' value='Appraisal Intimation' style='font-size:12px;font-family:arial;margin:8px;'/> ");
//        $("#t_list").append("<input type='button' id='delete' value='Delete Intimation' style='font-size:12px;font-family:arial;margin:8px;'/> ");
//        $("#t_list").append("<input type='button' id='view' value='View Form' style='font-size:12px;font-family:arial;margin:8px;'/> ");


        $("input,button", "#t_list").click(function(id) {

            if (id.currentTarget.id == "goal") {
                var retval = window.showModalDialog("Appraisal/GoalUpload.aspx", window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
                ConstructGrid();                
            }
            else if (id.currentTarget.id == "update") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    var Request = new Object();
                    Request.ID = ret.id;
                    var Response = SendApplicationRequest('<%=HRAppCommands.IS_GOAL_SUBMISSION_STARTED%>', Request, true);
                    if (Response.ResponseCommand == "SUCCESS") {
                        var retval = window.showModalDialog("Appraisal/UpdateGoalUpload.aspx?ID=" + ret.id + "&date=" + ret.goal, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
                        ConstructGrid();
                    }
                    else {
                        alert("Intimation can be updated only before goal submission");
                    }
                }
                else {
                    alert("Select a row to update intimation");
                }
            }
            else if (id.currentTarget.id == "delete") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    if (confirm('Do you want to delete?') == false) return;
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    var Request = new Object();
                    Request.ID = ret.id;
                    var Response = SendApplicationRequest('<%=HRAppCommands.DELETE_INTIMATION%>', Request, true);
                    if (Response.ResponseCommand == "SUCCESS") {
                        alert('Intimation deleted successfully');
                        ConstructGrid();
                    }
                    else {
                        alert(Response.Message);
                    }

                }
                else {
                    alert("Select a row to delete a intimation");
                }
            }
            else if (id.currentTarget.id == "view") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    viewDoc(ret.id);
                }
                else {
                    alert("Select a row to view review form");
                }
            }
            else if (id.currentTarget.id == "appraisal") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    if ($.trim(ret.appraisal) != "") {
                        alert("Already intimated");
                        return;
                    }

                    else {
                        var Request = new Object();
                        Request.ID = ret.id;
                        var Response = SendApplicationRequest('<%=HRAppCommands.INTIMATE_FOR_APPRAISAL%>', Request, true);
                        alert('Appraisal intimated successfully');
                        ConstructGrid();
                    }
                }
                else {
                    alert("Select row to intimate");
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
    function viewDoc(ID)
    {       
        var ret = jQuery("#list").jqGrid('getRowData', ID);
        window.location.href = "DownloadFileHandler.ashx?DocumentName=" + ret.documentname+ "&Type=appraisal"+ "&ID="+ID;
    }
    function BindGrid() {

       var Response = SendApplicationRequest('<%=HRAppCommands.INTIMATION%>', '');
      if (Response.ResponseCommand == 'SUCCESS') {
          if (Response.ResponseObject.datastr == null)          
              jQuery("#list").jqGrid('clearGridData');
          else {
              jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
              jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
          }
      }
  }
  function ViewAppraisal(ID,Doc,type)
    {
        window.location.href = "DownloadFileHandler.ashx?DocumentName=" + Doc+ "&Type="+ type+"&ID="+ID;
    }
</script>
</html>