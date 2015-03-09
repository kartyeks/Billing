<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignAssetSummary.aspx.cs" Inherits="AltioStarHR.Inventory.AssignAssetSummary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Assign Asset Summary</title>
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

    <script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

</head>
<body>
    <div>
        <%--<div class="header_title2" style="background-color:#00daf5">--%>
<%--        <div style="background-color:#00daf5;width:885px;margin-left:2%;height:25px;padding-left:2%;font-family:Calibri;font-weight:bold">
            Assign Asset</div>--%>
           
    <div style="position:relative;width:100%">
        <img alt="" src="Resources/Images/NewImages/1.png" style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
        <div style="position:absolute;left:4%;top:52%;">
            <strong class="family1 imageheadercolor">Assign Asset Details</strong>
        </div>
    </div>
    <div style="margin-left:2%;margin-top:-1%" id="box">
        <div id="divEmployees" title="Employees">
            <form id="signupForm" method="get" action="">
                
            </form>
        </div>
        <br />
        <table id="list" class="scroll">
        </table>
        <div id="pager">
        </div>
    </div>
</body>

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
    $(document).keydown(function(e) {

        var nodeName = e.target.nodeName.toLowerCase();
        if (e.which == 8) {
            if ((nodeName == 'input' && e.target.type == 'text') || nodeName == 'textarea') {
                /* do nothing */
            }
            else { e.preventDefault(); }
        }
    });
    
    var mode = "";
    var searchEmployeeType = '';
    jQuery(document).ready(function() {
    //    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });
    jQuery("#box").css({ width: "97%" });
      
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=InventoryAppCommands.ASSIGNASSET_GRID%>', '', true);
        Response.ResponseObject.colModel = [
            { name: 'ID', index: 'ID', hidden: true, sorttype: "int" },
            { name: 'AssetID', index: 'AssetID', hidden: true, editable: true },
            { name: 'IsTeamAssigned', index: 'IsTeamAssigned', hidden: true, editable: true },
            { name: 'TeamID', index: 'TeamID', hidden: true, sorttype: "int" },
            { name: 'EmployeeID', index: 'EmployeeID', hidden: true, sorttype: "int" },
            { name: 'AssetName', index: 'AssetName', editable: true },
            { name: 'AssetNumber', index: 'AssetNumber', editable: true },
            { name: 'TeamName', index: 'TeamName',  editable: true },
            { name: 'ManagerName', index: 'ManagerName',  editable: true },
            { name: 'UserName', index: 'UserName', editable: true },
            { name: 'dtIssuedDate', index: 'dtIssuedDate', hidden: true, editable: true },
            { name: 'IssuedDate', index: 'IssuedDate', editable: true, width: 80 },
            { name: 'Reason', index: 'Reason', hidden: true, editable: true },
            { name: 'IsReturned', index: 'IsReturned', width: 100, align: 'center', editable: false, formatter: 'checkbox',
               edittype: 'checkbox', editoptions: { value: 'Yes:No' }, formatoptions: { disabled: true }
             },
            { name: 'ReturnedDate', index: 'ReturnedDate', hidden: true, editable: true },
            { name: 'LocationOfAsset', index: 'LocationOfAsset', hidden: true, editable: true },
            { name: 'Comments', index: 'Comments', hidden: true, editable: true },
            { name: 'UpdatedBy', index: 'UpdatedBy', hidden: true, editable: true }
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
//        $("#list").closest(".ui-jqgrid-bdiv").height("auto");
//        jQuery("#list").jqGrid('setCaption', "Assign Asset Details").trigger('reloadGrid');
        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
//        $("#t_list").append("<input type='button' id='Add' value='Add'  style='height:24px;font-size:-2'/>");
//        $("#t_list").append("<input type='button' id='View' value='View'  style='height:24px;font-size:-2'/>");
        //        $("#t_list").append("<input type='button' id='Refresh' value='Refresh'  style='height:24px;font-size:-2'/>");
        $("#t_list").append("<button type='button' id='Add' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><div></div><span >Add</span></button>");
        $("#t_list").append("<button type='button' id='View' value='Edit' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view_btn.png'height=18px;width=18px alt='' /><br/><div></div><span>View</span></button>");
        $("#t_list").append("<button type='button' id='Refresh' value='Refresh' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/refresh_icon.png'height=20px;width=22px alt='' /><br/><div></div><span>Refresh</span></button>");
        $("input,button", "#t_list").click(function(id) {
            if (id.currentTarget.id == "Add") {

                var InviewModeValue = id.currentTarget.id;
                $('#ChildWB', parent.document).attr("src", "default.aspx?serve=AssignAssetDetails&assignid=0");

            }
            else if (id.currentTarget.id == "View") {

                var InviewModeValue = id.currentTarget.id;
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {

                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    $('#ChildWB', parent.document).attr("src", "default.aspx?serve=AssignAssetDetails&assignid=" + ret.ID);
                }
                else alert("Please select asset to view");
            }
            else if (id.currentTarget.id == "Refresh") {
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Response = SendApplicationRequest('<%=InventoryAppCommands.ASSIGNASSET_GRID%>', '', true);
                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
//                jQuery("#list").jqGrid('setCaption', "Assign Asset Details").trigger('reloadGrid');
                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
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
