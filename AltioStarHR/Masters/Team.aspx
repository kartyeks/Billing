<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Team.aspx.cs" Inherits="AltioStarHR.Masters.Team" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Team</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
    <%--<link href="../Resources/css/New%20Css/Stylesheet1.css" rel="stylesheet" type="text/css" />--%>
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />    
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input[type=text]
        {
            margin-bottom: 5px;
            width: 100%;
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
        #Clientmaster
        {
            width: 217px;
        }
      
    </style>
</head>
<body >
<div id="dvHd" style="position:relative;width:100%;">
   <img alt="" src="Resources/Images/NewImages/1.png"style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
  <strong class="family1 imageheadercolor">Team Details</strong>
    </div>
</div>
    <div id="divTeam" class="dialog" style="display: none;background-color:White">
        <form id="signupForm" method="get" action="">
        <fieldset style="width: 97%;margin-left:2%;margin-top:0%">
            <table style="width:100%;background-color:#a4cd0f">
                <tbody >
                    <tr>
                        <td class="label" width="90" height="40">
                            <label id="lteam" for="team" class="family">
                                Team Name</label>
                        </td>
                        <td class="field" width="90" height="40">
                            <input id="team" name="team" type="text" value="" maxlength="100" style="width:230px;border:1px solid silver" class="family"/>
                        </td>
                        <td id="steam" style="white-space:nowrap">
                        </td>
                    </tr>
                    <tr id="trSelectManager">
                        <td class="label" width="90" height="40">
                            <label id="lManager" for="Manager" class="family">
                                Manager</label>
                        </td>
                        <td class="field" width="90" height="40">
                            <select id="Manager" name="Manager" runat="server" style="width:240px;border:1px solid silver" class="family">
                            </select>
                        </td>
                        <td id="sManager" style="white-space:nowrap">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="lisactive" class="family">
                                Active</label>
                        </td>
                        <td>
                            <input id="isactive" type="checkbox" />
                        </td>
                        <td class="status" id="sisactive">
                        </td>
                    </tr>
                    <tr>
                    <td></td>
                    <td>
                     <input id="signupsubmit" name="Submit" type="submit" value="Save" class="family" />
                     <input id="Cancel" name="Cancel" type="button" value="Cancel" class="family"/>
                    </td>
                    </tr>
                </tbody>
            </table>
           <%-- <table>
                <tr align="center">
                    <td class="field">
                        <input id="signupsubmit" name="Submit" type="submit" value="Save" />
                    </td>
                    <td class="field">
                        <input id="Cancel" name="Cancel" type="button" value="Cancel" />
                    </td>
                </tr>
            </table>--%>
        </fieldset>
        </form>
    </div>
    <div style="margin-left:2%;" id="box">
      <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>

    <input type="hidden" id="hdnEmployeeID" runat="server" />
    <input type="hidden" id='hdnmodule' runat="server" />
    <input type="hidden" id="hdnApplyPermit" runat="server" />
    <input type="hidden" id="hdnViewPermit" runat="server" />
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

<script src="Resources/js/jquery.ui.button.js" type="text/javascript"></script>

<script type="text/javascript">
var mode = "";
var activeStatus = true;
//$(window).bind('resize', function() {
//    $("#list").setGridWidth($('#box').width() - 10, true);
//}).trigger('resize');
jQuery("#box").css({ width: "97%" });
$("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });

jQuery(document).ready(function() {
    //LoadPermits();
    LoadManager();
    $.validator.addMethod("alphaNumerix", function(value, element) {
        return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\@\_\-\ \&\s ]*$/i.test(value);
    }, "Username must contain only letters, numbers, or dashes.");

    $('#Cancel').click(function() {
        onCancel();
    });

    var myGrid = $('#list');
    var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_TEAM_DETAILS%>', '');
    Response.ResponseObject.colModel = [

            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'teamname', index: 'teamname', width: 100, editable: true },
            { name: 'managerid', index: 'managerid', width: 100, editable: true, hidden: true },
            { name: 'managername', index: 'managername', width: 100, editable: true },
            { name: 'isactive', index: 'isactive', width: 20, editable: true, hidden: true },
            { name: 'createdby', index: 'createdby', width: 100, editable: true, hidden: true },
            { name: 'createddate', index: 'createddate', width: 100, editable: true, hidden: true },
            { name: 'modifiedby', index: 'modifiedby', width: 100, editable: true, hidden: true },
            { name: 'modifieddate', index: 'modifieddate', width: 100, editable: true, hidden: true },
            { name: 'updateby', index: 'updateby', width: 100, editable: true, hidden: true },
            { name: 'activestatus', index: 'activestatus', width: 40, align: 'center', editable: true, formatter: cboxFormatter,
                stype: 'select', searchoptions: { value: ":All;True:Active;False:Inactive", defaultValue: "All" },
                search: true, edittype: 'checkbox', editoptions: { value: 'True:False' }, formatoptions: { disabled: true }
            },

    ];

//    var he = $(window).height();
//    alert($(window).height());
//    alert(document.documentElement.clientHeight);
//    var reduce = he - 160 - 5; //* 0.58;
//    Response.ResponseObject.height = reduce;
    Response.ResponseObject.autowidth = true;

    myGrid.jqGrid(Response.ResponseObject);
    jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
    jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
    jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
        onClickButton: function() {
            myGrid[0].toggleToolbar()
        }
    });
    jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
    $("#t_list").append("<button type='button' id='add' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><div></div><span>Add</span></button>");
    $("#t_list").append("<button type='button' id='edit' value='Edit' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/edit_icon.png'height=18px;width=18px alt='' /><br/><div></div><span>Edit</span></button>");


    $("button ,input", "#t_list").click(function(id) {
        if (id.currentTarget.id == "add") {
            validator.resetForm();
            mode = "add";
            clearLabels();
            $("#isactive").attr('checked', true);
            document.getElementById("divTeam").style.display = "";

        }
        else if (id.currentTarget.id == "edit") {
            validator.resetForm();
            var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
            if (id) {
                mode = "edit";
                clearLabels();
                document.getElementById("divTeam").style.display = "";

                fillData();
            }
            else { alert("Please select a row"); }
        }


    });

    //    var mygrid = jQuery('#list'),
    //            cDiv = mygrid[0].grid.cDiv;
    //    mygrid.setCaption("");
    //    $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
    //    $(cDiv).hide();
    //$("#list").closest(".ui-jqgrid-bdiv").height("auto");

    var validator = $("#signupForm").validate({
        rules: {
            team: {
                required: true,
                alphaNumerix: true
            },
            Manager: {
                required: true

            }
        },
        messages: {
            team: {
                required: "Enter Team Name",
                alphaNumerix: "Invalid Team Name"
            },
            Manager: {
                required: "Select Manager name"
            }
        },
        errorPlacement: function(error, element) {
            error.appendTo(element.parent().next());
        },

        submitHandler: function() {

            if (mode == "edit") {
                if (confirm('Do you want to Update the Changes made?') == false) return false;
            }
            var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
            var Request = new Object();
            var ID = "";
            if (mode == "edit") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                ID = ret.id;
            }
            else {
                ID = "0";
            }
            Request.UpdateBy = $("#hdnEmployeeID").val();
            Request.ID = ID;
            Request.TeamName = $("#team").val();
            Request.ManagerID = $("#Manager").val();
            if ($("#isactive").is(':checked')) { Request.IsActive = true; }
            else { Request.IsActive = false; }
            var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_TEAM%>', Request, true);
            alert(Response.Message);
            if (Response.ResponseCommand == 'SUCCESS') {
                mode = "SUCCESS";
                var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_TEAM_DETAILS%>', Request, true);
                if (Response.ResponseObject.datastr == null)
                    jQuery("#list").jqGrid('clearGridData');
                else {
                    jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                    jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                }

                $('#gs_activestatus').val("");

                clearLabels();
                onCancel();
            }
        },
        success: function(label) {
            label.html("&nbsp;").addClass("checked");
        }
    });
    $(document).delegate('#list .jqgrow td input', 'click', function(obj) {

        var splitid = (obj.srcElement.id).split('_');
        var ROWID = splitid[1];
        var IsChecked = obj.srcElement.checked;
        if (IsChecked) {
            ActivateRow(ROWID);
        }
        else
            DeActivateRow(ROWID);
    });

    function cboxFormatter(cellvalue, options, rowObject) {

        var chkd = '';
        if (cellvalue == "True") chkd = 'checked';
        var ele = '<input type="checkbox" ' + chkd + ' id="chkRowId_' + options.rowId + '"/>';
        return ele;
    }
});
 function ActivateRow(ROWID) { 
        var ret = jQuery("#list").jqGrid('getRowData', ROWID);
        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        
        if (confirm('Do you want to activate?') == false) {
            $("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
            return;
        };
        
        var Request = new Object();
        ID = ret.id;
        Request.ID = ID;
        Request.IsActive = true;

        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_TEAM%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_TEAM_DETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
        
        $('#gs_activestatus').val("");
    }

    function DeActivateRow(ROWID) {
        var ret = jQuery("#list").jqGrid('getRowData', ROWID);
        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        
        if (confirm('Do you want to deactivate?') == false) {
            $("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
            return;
        };
        
        var Request = new Object();
        ID = ret.id;
        Request.ID = ID;
        Request.IsActive = false;

        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_TEAM%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_TEAM_DETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
        $('#gs_activestatus').val("");
    }
        function onCancel() {
            if (mode != "SUCCESS") {
                if (confirm('Do you want to cancel?') == false) return;
            }
            //$("#divTeam").dialog('close');
            document.getElementById("divTeam").style.display = "none";
        }

        function LoadManager() {
            var Response = SendApplicationRequest("<%=HRAppCommands.MANAGER_COMBO_DETAILS%>", "");
            var optn = document.createElement("OPTION");
            optn.text = "Choose Manager";
            optn.value = "";
            document.getElementById('Manager').options.add(optn);
            if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                var arr = Response.ResponseObject;
                for (var i = 0; i < arr.length; ++i) {
                    var optn = document.createElement("OPTION");
                    optn.text = arr[i]['Value'];
                    optn.value = arr[i]['ID'];
                    document.getElementById('Manager').options.add(optn);
                }
            }
        }

        function fillData() {
            var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#list").jqGrid('getRowData', id);
            $("#team").val(ret.teamname);
            $("#Manager").val(ret.managerid);
            if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
            else { $("#isactive").attr('checked', true); }  
        }    

        function LoadPermits() {
            var Response = LoadPermissions($('#hdnmodule').val(), $('#hdnEmployeeID').val());
            if (Response != null) {
                $('#hdnApplyPermit').val(Response['Apply']);
                $('#hdnApprovlPermit').val(Response['Approvals']);
                $('#hdnViewPermit').val(Response['ViewMode']);
            }
        }

        function clearLabels() {
            $("#team").val("");
            $("#Manager").val("0");
        }
        
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
