 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leaves.aspx.cs" Inherits="AltioStarHR.Leave.Leaves" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LeaveType</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    <%--<script src="Resources/js/Newjs/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Resources/js/Newjs/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>--%>
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
        #Clientmaster
        {
            width: 217px;
        }
      
    </style>
</head>
<body>
   
<div style="position:relative;">
    <img alt="" src="Resources/Images/NewImages/1.png" style="width:96%;margin-left:3%;height:53px;margin-top:0%"/>
    <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
    <strong style="color:White" class="family1">LeaveType Details</strong>
    </div>
</div>
<div id="divLeave" class="dialog" title="Leave" style="display:none;width:96%;padding-left:3%;background-color:White">
        <form id="signupForm" method="get" action="">
        <fieldset style="width:100%; padding-left:-15%;">
            <table style="width: 500px;background-color:#a4cd0f">
                <tbody>
                    <tr>
                        <td style="width:20%">
                            <label id="lleavetype" for="leavetype" class="family">
                                Leave Type</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="leavetype" name="leavetype" type="text"  style="width: 210px;padding-left:-80%;border:1px solid silver" tabindex="1"
                                value="" maxlength="100" class="family"/>
                        </td>
                        <td class="status" id="sleavetype" >
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lisactive" for="isactive" class="family">
                                Active</label>
                        </td>
                        <td class="field">
                            <input id="isactive" type="checkbox" class="family"/>
                        </td>
                        <td class="status" id="sisactive">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                        <td>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table>
                <tr align="center">
                    <td class="field">
                        <input id="signupsubmit" name="Submit" type="submit" value="Save" class="family"/>
                    </td>
                    <td class="field">
                        <input id="Cancel" name="Cancel" type="button" value="Cancel" class="family"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        </form>
    </div>
<div style="margin-left:3%;background-image:url('<%= ResolveUrl("~/Resources/Images/NewImages/dashboard_bg.gif") %>');" id="box">
      <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>   
   
    <input type="hidden" id='hdnmodule' runat="server" />
    <input type="hidden" id='hdnApprovlPermit' runat="server" />
    <input type="hidden" id="hdnApplyPermit" runat="server" />
    <input type="hidden" id="hdnViewPermit" runat="server" />
    <input type="hidden" id='hdnEmployeeID' runat="server" />
</body>
<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Newjs/jquery-1.9.1.js") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Newjs/jquery-ui-1.10.3.custom.js") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-1.6.2.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.17.custom.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/grid.locale-en.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.jqGrid.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Webutility.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/toolbar.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.core.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.widget.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.validate.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Validation.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.button.js") %>"></script>



<script type="text/javascript">

    // Code to Prevent the BackSpace key from Working as "Go To Back Page."
//    $(document).keydown(function(e) {

//        var nodeName = e.target.nodeName.toLowerCase();
//        if (e.which == 8) {
//            if ((nodeName == 'input' && e.target.type == 'text') || nodeName == 'textarea') {
//                /* do nothing */
//            }
//            else { e.preventDefault(); }
//        }
//    });
    
    var mode = "";
    var activeStatus = true;
    $(window).bind('resize', function() {
        $("#list").setGridWidth($('#box').width() - 30, true);
    }).trigger('resize');
    jQuery("#box").css({ width: "97%" });
 
    
    jQuery(document).ready(function() {

        //LoadPermits();
        
        $('#Cancel').click(function() {
            onCancel();
        });
        
        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");
        
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=LeaveAppCommands.LEAVE_DETAILS%>', '', true);
        Response.ResponseObject.colModel = [
   		            { name: 'leaveid', index: 'leaveid', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'leavetype', index: 'leavetype', width: 100, editable: true },
   		            { name: 'isactive', index: 'isactive', width: 100, editable: true, hidden: true }
   	            ]

        myGrid.jqGrid(Response.ResponseObject);        
        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        $("#t_list").append("<button type='button' id='add' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><span>Add</span></button>");
        $("#t_list").append("<button type='button' id='edit' value='Edit' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/edit_icon.png'height=18px;width=18px alt='' /><br/><span>Edit</span></button>");
        $("#t_list").append("<button type='button' id='activate' value='Activate' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/Active.jpg'height=20px;width=22px alt='' /><br/><span>Activate</span></button>");
        $("#t_list").append("<button type='button' id='deactivate' value='Deactivate' style='background:none;border:0px;outline:none'><img src='Resources/Images/NewImages/deactivatescr_icon_sml.png' height=18px;width=18px alt='' /><br/><span>Deactivate</span></button>");
        $("#t_list").append("<img src='Resources/Images/NewImages/Activate.jpg' height=18px;width=18px alt='' /><input type='checkbox' id='activedata' value='activedata' checked /> ");
        
        if ($('#hdnEmployeeID').val() != "1") {
            onGetPermissionDisplay();
        }
        $("button ,input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "add") {
                validator.resetForm();
                mode = "add";
                clearLabels();
                $("#isactive").attr('checked', true);
                document.getElementById("divLeave").style.display = "";
                $("input[type='text']:first", document.forms[0]).focus();
            }          
            else if (id.currentTarget.id == "activedata") {
                mode = "activedata";
                BindGrid(1);
            }    
            else if (id.currentTarget.id == "edit") {
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                  document.getElementById("divLeave").style.display = "";
                    fillData();
                    $("input[type='text']:first", document.forms[0]).focus();
                }
                else { alert("Please select Leave"); }
            }  
            else if (id.currentTarget.id == "delete") {
                mode = "delete";
                var gr = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (gr != null) jQuery("#list").jqGrid('delGridRow', gr, { reloadAfterSubmit: false });
                else alert("Please Select Row to delete!");
            }     
            else if (id.currentTarget.id == "deactivate") {
                mode = "deactivate";
                var Request = new Object();
                var ID = "";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if (id) {
                    if (ret.isactive == 'True') {
                        if (confirm('Do you want to deactivate?') == false) return;
                        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                        ID = ret.leaveid;
                        Request.ID = ID;
                        Request.ChangedBy = $("#hdnEmployeeID").val();
                        var Response = SendApplicationRequest('<%=LeaveAppCommands.DEACTIVATE_LEAVE%>', Request, true);
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=LeaveAppCommands.LEAVE_DETAILS%>', '', true);
                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setCaption', "LeaveDetails").trigger('reloadGrid');
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else alert("Selected Leave is already deactivated");                    
                }
                else alert("Please Select Leave to deactivate!");                
            }
            else if (id.currentTarget.id == "activate") {
                mode = "activate";
                var Request = new Object();
                var ID = "";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if (id) {
                    if (ret.isactive == 'False') {
                        if (confirm('Do you want to activate?') == false) return;
                        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                        ID = ret.leaveid;
                        Request.ID = ID;
                        Request.ChangedBy = $("#hdnEmployeeID").val();
                        var Response = SendApplicationRequest("<%=LeaveAppCommands.ACTIVATE_LEAVE%>", Request, true);
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=LeaveAppCommands.INACTIVE_LEAVE%>', '', true);
                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setCaption', "LeaveDetails").trigger('reloadGrid');
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else alert("Selected Leave is already activated");                    
                }
                else alert("Please Select Leave to activate!");                
            }
        });

        var mygrid = jQuery('#list'),
        cDiv = mygrid[0].grid.cDiv;
        mygrid.setCaption("");
        $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
        $(cDiv).hide();
        $("#list").closest(".ui-jqgrid-bdiv").height("auto");
        
        GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {
                leavetype: {
                    required: true,
                    alphaNumerix: true
                }
            },
            messages: {
                leavetype: {
                    required: "Enter Leave Type",
                    alphaNumerix: "Invalid Leave Type"
                }
            },
            
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            
            submitHandler: function() {
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                var ID = "";
                if (mode == "edit") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    ID = ret.leaveid;
                }
                else {
                    ID = "0";
                }

                Request.ID = ID;
                Request.LeaveType = $("#leavetype").val();
                Request.UpdateBy = $("#hdnEmployeeID").val();
                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }

                var Response = SendApplicationRequest('<%=LeaveAppCommands.UPDATE_LEAVE%>', Request, true);                
                if(mode == "edit")
                {
                   if(confirm('Do you want to Update the Changes made?') == false) return false;
                }                
                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = "SUCCESS";
                    BindGrid(currPage);
                    clearLabels();
                    onCancel();
                }
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });
    });
    
    function BindGrid(pageNumber) {
        var Request = new Object();
        if ($("#activedata").is(':checked')) {
            var Response = SendApplicationRequest('<%=LeaveAppCommands.LEAVE_DETAILS%>', '', true);
            activeStatus = true;
        }
        else {
            var Response = SendApplicationRequest('<%=LeaveAppCommands.INACTIVE_LEAVE%>', '', true);
            activeStatus = false;
        }
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: pageNumber }).trigger('reloadGrid');
        }
        GridActiveButton();
    }
    
    function GridActiveButton() {
     if (document.getElementById("hdnApprovlPermit").value == "true") {
        document.getElementById("activate").style.display = "none";
        document.getElementById("deactivate").style.display = "none";
        if (activeStatus == false)
            document.getElementById("activate").style.display = "";
        else
            document.getElementById("deactivate").style.display = "";
            }
    }
    
    function onCancel() {
        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        // $("#divLeave").dialog('close');
        document.getElementById("divLeave").style.display = "none";
    }

    function fillData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#leavetype").val(ret.leavetype);
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }
    }

    function clearLabels() {
        $("#leavetype").val("");
        $("#isactive").attr('checked', false);
    }

    function LoadPermits() {
        var Response = LoadPermissions($('#hdnmodule').val(), $('#hdnEmployeeID').val());
        if (Response != null) {
            $('#hdnApplyPermit').val(Response['Apply']);
            $('#hdnApprovlPermit').val(Response['Approvals']);
            $('#hdnViewPermit').val(Response['ViewMode']);
        }
    }
    
    function onGetPermissionDisplay() {
        document.getElementById("add").style.display = "none";
        document.getElementById("edit").style.display = "none";
        document.getElementById("activate").style.display = "none";
        document.getElementById("deactivate").style.display = "none";

        if (document.getElementById("hdnApplyPermit").value == "true") {
            document.getElementById("add").style.display = "";
            document.getElementById("edit").style.display = "";
        }
        if (document.getElementById("hdnApprovlPermit").value == "true") {
            document.getElementById("activate").style.display = "";
            document.getElementById("deactivate").style.display = "";
        }
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
