<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvanceType.aspx.cs" Inherits="AltioStarHR.LoanManagement.AdvanceType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>AdvanceType</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
       <%-- <div class="header_title2">
            AdvanceType</div>--%>
        <div class="dvGrid">
            <table id="list" class="scroll">
            </table>
            <div id="pager">
            </div>
        </div>
    </div>
    <div id="divAdvanceType" class="dialog" title="AdvanceType" style="display: none;">
        <form id="signupForm" method="get" action="">
        <fieldset>
            <table class="teble_bg">
                <tbody>
                    <tr>
                        <td class="label" width="90" height="40">
                            <label id="ladvancetype" for="advancetype">
                                AdvanceType</label>
                        </td>
                        <td class="field" width="90" height="40">
                            <input id="advancetype" name="advancetype" style="width:200px" type="text"  />
                        </td>
                        <td></td>
                        <td id="sadvancetype" width="90" height="40">
                        </td>
                     
                    </tr>
                    
                    <tr>
                        <td class="label">
                            <label id="lisactive" for="">
                                Active</label>
                        </td>
                        <td class="field">
                            <input id="isactive" type="checkbox" />
                        </td>
                        <td class="status" id="sisactive">
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table>
                <tr align="center">
                    <td class="field">
                        <input id="signupsubmit" name="Submit" type="submit" value="Save" />
                    </td>
                    <td class="field">
                        <input id="Cancel" name="Cancel" type="button" value="Cancel" />
                    </td>
                </tr>
            </table>
        </fieldset>
        </form>
    </div>
    <input type="hidden" id='hdnmodule' runat="server" />
    <input type="hidden" id='hdnApprovlPermit' runat="server" />
    <input type="hidden" id="hdnApplyPermit" runat="server" />
    <input type="hidden" id="hdnViewPermit" runat="server" />
    <input type="hidden" id='hdnEmployeeID' runat="server" />
</body>

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
    var activeStatus = true;

    jQuery(document).ready(function() {     
    debugger
           LoadPermits();
           
        $('#Cancel').click(function() {
            onCancel();
        }); 
        
//        $("#advancetype").keypress(function(e) {
//            if (e.which != 8 && e.which != 0 && e.which != 46 && (e.which < 48 || e.which > 57)) {
//                return false;
//            }
//            if($("#advancetype").val().length > 9)
//            {
//                return false;
//            }
//        });       
   
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=LoanAppCommands.ADVANCE_TYPE_DETAILS%>', '');
        
        Response.ResponseObject.colModel = [
   		            { name: 'advancetypeid', index: 'advancetypeid', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'advancetype', index: 'advancetype', width: 100, editable: true },   		            
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
        $("#t_list").append("<input type='button' id='add' value='Add'  style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<input type='button' id='edit' value='Edit' style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<input type='button' id='activate' value='Activate' style='height:24px;font-size:-3'/> ");
        $("#t_list").append("<input type='button' id='deactivate' value='Deactivate' style='height:24px;font-size:-3'/> ");
        $("#t_list").append("Active <input type='checkbox' id='activedata' value='activedata' checked /> ");
        
        if ($('#hdnEmployeeID').val() != "1") {
            //onGetPermissionDisplay();
        }
        
        $("input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "add") {            
                validator.resetForm();
                mode = "add";
                clearLabels();
                $("#isactive").attr('checked', true);
                document.getElementById("divAdvanceType").style.display = "";
                $('#divAdvanceType').dialog({
                    height: 200,
                    width: 550,
                    modal: true
                })
                $("input[type='text']:first", document.forms[0]).focus();
            }
            else if (id.currentTarget.id == "edit") {          
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divAdvanceType").style.display = "";
                    $('#divAdvanceType').dialog({
                        height: 200,
                        width: 550,
                        modal: true
                    })
                    fillData();
                    $("input[type='text']:first", document.forms[0]).focus();
                }
                else  alert("Please select AdvanceType"); 
            }
            else if (id.currentTarget.id == "activedata") {
                mode = "activedata";
                BindGrid(1);
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
                        ID = ret.advancetypeid;
                        Request.ID = ID;
                        Request.ChangedBy = $("#hdnEmployeeID").val();
                        var Response = SendApplicationRequest('<%=LoanAppCommands.DEACTIVATE_ADVANCE_TYPE%>', Request, true, '');
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=LoanAppCommands.ADVANCE_TYPE_DETAILS%>', '', true, '');
                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setCaption', "AdvanceTypeDetails").trigger('reloadGrid');
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else alert("Selected AdvanceType is already deactivated!");                    
                }
                else alert("Please Select AdvanceType to deactivate!");
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
                        ID = ret.advancetypeid;
                        Request.ID = ID;
                        Request.ChangedBy = $("#hdnEmployeeID").val();
                        var Response = SendApplicationRequest('<%=LoanAppCommands.ACTIVATE_ADVANCE_TYPE%>', Request, true, '');
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=LoanAppCommands.INACTIVE_ADVANCE_TYPE%>', '', true, '');
                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setCaption', "AdvanceTypeDetails").trigger('reloadGrid');
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else alert("Selected AdvanceType is already activated!");                    
                }
                else alert("Please Select AdvanceType to activate!");                
            }
        });
        
        GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {
                advancetype: {
                    required: true,
                    maxlength: 250
                }
            },
            messages: {
                advancetype: {
                    required: "Enter Advance Type",
                    maxlength: "Maximum of only, {0} characters allowed"
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
                    ID = ret.advancetypeid;
                }
                else {
                    ID = "0";
                }

                Request.ID = ID;
                Request.AdvanceType = $("#advancetype").val();

                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }
                
                Request.UpdateBy = $("#hdnEmployeeID").val();
                var Response = SendApplicationRequest('<%=LoanAppCommands.UPDATE_ADVANCE_TYPE%>', Request, true, '');                
                if(mode == "edit")
                {
                   if(confirm('Do you want to Update the Changes made?') == false)
                   return;
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
            var Response = SendApplicationRequest('<%=LoanAppCommands.ADVANCE_TYPE_DETAILS%>', '', true, '');
            activeStatus = true;
        }
        else {
        var Response = SendApplicationRequest('<%=LoanAppCommands.INACTIVE_ADVANCE_TYPE%>', '', true, '');
            activeStatus = false;
        }
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setCaption', "AdvanceTypeDetails").trigger('reloadGrid');
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
        $("#divAdvanceType").dialog('close');
    }

    function fillData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#advancetype").val(ret.advancetype);
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }
    }

    function clearLabels() {
        $("#advancetype").val("");
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
        $('#t_list').css('padding', '10px 0px');
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
