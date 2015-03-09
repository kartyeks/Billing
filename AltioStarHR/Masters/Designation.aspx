<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="AltioStarHR.Masters.Designation1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Designation</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    
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
<body>
<div id="headertop" style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png"style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
        <strong class="family1 imageheadercolor">Designation Details</strong>
    </div>
</div>
    <div id="divDesignation" class="dialog" style="display:none;">
        <form id="signupForm" method="get" action="">
        <fieldset style="width: 97%;margin-left:2%;margin-top:0%">
            <table style="width:100%;background-color:#a4cd0f">
                <tbody>
                    <tr>
                        <td class="label" width="200" height="40">
                            <label id="ldesignation" for="designation" class="family" >
                                Designation Name</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" height="40">
                            <input id="designation" name="designation" type="text" style="width: 200px; border:1px solid silver" tabindex="1"
                                value=""  class="family"/>
                        </td>
                        <td id="sdesignation" >
                        </td>
                    </tr>
                    <tr>
                        <td class="label" width="200" height="40">
                            <label id="lrole" for="role" class="family">
                                Role</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <select id="role" tabindex="9" style="width: 210px;border:1px solid silver" name="role" runat="server" class="family">
                            </select>
                        </td>
                        <td id="srole" >
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lisactive" class="family">
                                Active</label>
                        </td>
                        <td class="field">
                            <input id="isactive" tabindex="3" type="checkbox" style="border:1px solid silver" />
                        </td>
                        <td class="status" id="sisactive">
                        </td>
                    </tr>
                    <tr>
                    <td></td>
                    <td>
                        <input id="signupsubmit" name="Submit" tabindex="4" type="submit" class="family" value="Save" />
                        <input id="Cancel" name="Cancel" tabindex="5" type="button" class="family" value="Cancel" />
                    </td>
                    </tr>
                </tbody>
            </table>
            <%--<table>
                <tr align="center">
                    <td class="field">
                        <input id="signupsubmit" name="Submit" tabindex="4" type="submit" value="Save" />
                    </td>
                    <td class="field">
                        <input id="Cancel" name="Cancel" tabindex="5" type="button" value="Cancel" />
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
    <input type="hidden" id='hdnEmployeeID' runat="server" />
    <input type="hidden" id='hdnmodule' runat="server" />
    <input type="hidden" id='hdnApprovlPermit' runat="server" />
    <input type="hidden" id="hdnApplyPermit" runat="server" />
    <input type="hidden" id="hdnViewPermit" runat="server" />
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
    $("#box").css({"background-image":"url(Resources/Images/NewImages/dashboard_bg.gif)","width":"97%"});
    var mode = "";
    var activeStatus = true;
//    $(window).bind('resize', function() {
//        $("#list").setGridWidth($('#box').width() - 30, true);
//    }).trigger('resize');

    jQuery(document).ready(function() {
        //LoadPermits();
        LoadRole();
        //        $.validator.addMethod("alphaNumerix", function(value, element) {
        //            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\@\_\-\ \&\:\s ]*$/i.test(value);
        //        }, "Username must contain only letters, numbers, or dashes.");

        $('#Cancel').click(function() {
            onCancel();
        });

        var myGrid = $('#list');

        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', '');
        Response.ResponseObject.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'roleid', index: 'roleid', width: 100, editable: true, hidden: true },
            { name: 'designation', index: 'designation', width: 100, editable: true },
            { name: 'isactive', index: 'isactive', width: 100, editable: true, hidden: true },
            { name: 'isupdateby', index: 'isupdateby', width: 100, editable: true, hidden: true },
            { name: 'role', index: 'role', width: 100, editable: true },
            { name: 'activestatus', index: 'activestatus', width: 40, align: 'center', editable: true, formatter: cboxFormatter,
                stype: 'select', searchoptions: { value: ":All;True:Active;False:Inactive", defaultValue: "All" },
                search: true, edittype: 'checkbox', editoptions: { value: 'True:False' }, formatoptions: { disabled: true }
            },
        ];

        Response.ResponseObject.onSelectRow = function(ID) {
            fillData();
        }
        
        
        Response.ResponseObject.autowidth= true;
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
                document.getElementById("divDesignation").style.display = "";

            }
            else if (id.currentTarget.id == "edit") {
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divDesignation").style.display = "";

                    fillData();
                }
                else { alert("Please select a row"); }
            }


        });

        //        var mygrid = jQuery('#list'),
        //        cDiv = mygrid[0].grid.cDiv;
        //        mygrid.setCaption("");
        //        $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
        //        $(cDiv).hide();
        //   $("#list").closest(".ui-jqgrid-bdiv").height("auto");

        //GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {
                designation: {
                    required: true
                    //  alphaNumerix: true
                },
                role: {
                    required: true
                }
            },
            messages: {
                designation: {
                    required: "Please enter Designation Name"
                    //  alphaNumerix: "Invalid Designation"
                },
                role: "Please select a Role"
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },

            submitHandler: function(id) {

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
                Request.DesignationID = ID;
                Request.Designation = $("#designation").val();
                Request.RoleID = $("#role").val();
                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_DESIGNATION%>', Request, true);

                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = "SUCCESS";
                    var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', Request, true);
                    if (Response.ResponseObject.datastr == null)
                        jQuery("#list").jqGrid('clearGridData');
                    else {
                        jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                        jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                    }

                    $('#gs_Status').val("");
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

        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_DESIGNATION%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', Request, true);
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

        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_DESIGNATION%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.DESIGNATION_DETAILS%>', Request, true);
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
        //$("#divDesignation").dialog('close');
        document.getElementById("divDesignation").style.display = "none";
    }

    function fillData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        
        $("#designation").val(ret.designation);       
        $("#role").val(ret.roleid);        
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }      
        
    }

    function clearLabels() {
        $("#designation").val("");        
        $("#role").val("");       
        $("#isactive").attr('checked', false);         
    }    
    function LoadRole() {
        var Response = SendApplicationRequest("<%=HRAppCommands.ROLE_COMBO%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Choose Role";
        optn.value = "";
        document.getElementById('role').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                document.getElementById('role').options.add(optn);
            }
        }
    }    

    function LoadPermits() {
        var Response = LoadPermissions($('#hdnmodule').val(), $('#hdnEmployeeID').val());
        if (Response != null) {
            $('#hdnApplyPermit').val(Response['Apply']);
            $('#hdnApprovlPermit').val(Response['Approvals']);
            $('#hdnViewPermit').val(Response['ViewMode']);
        }
    }
   
//    function onGetPermissionDisplay() {
//        document.getElementById("add").style.display = "none";
//        document.getElementById("edit").style.display = "none";
//        document.getElementById("activate").style.display = "none";
//        document.getElementById("deactivate").style.display = "none";

//        if (document.getElementById("hdnApplyPermit").value == "true") {
//            document.getElementById("add").style.display = "";            
//        }
//        if (document.getElementById("hdnApprovlPermit").value == "true") {
//            document.getElementById("activate").style.display = "";
//            document.getElementById("deactivate").style.display = "";
//            document.getElementById("edit").style.display = "";
//        }
//    } 
    

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
