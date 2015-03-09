<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectInfo.aspx.cs" Inherits="ARATT.Masters.ProjectInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Company</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
<%--    <link href="../Resources/css/bootsrapcss/bootstrap-responsive.css" rel="stylesheet"
        type="text/css" />
    <link href="../Resources/css/bootsrapcss/bootstrap-responsive.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Resources/css/bootsrapcss/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/css/bootsrapcss/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="../Resources/js/Bootstrapjs/bootstrap.js" type="text/javascript"></script>

    <script src="../Resources/js/Bootstrapjs/bootstrap.min.js" type="text/javascript"></script>--%>
    
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

    </style></head>
<body>
    <%--<div>
        <div class="header_title2">
            Relation</div>
        <div class="dvGrid">
            <table id="list" class="scroll">
            </table>
            <div id="pager">
            </div>
        </div>
    </div>--%>
<div style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png"style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
         <strong class="family1 imageheadercolor">Company Details</strong>
    </div>
</div>
    <div id="divProjectInfo" class="dialog" style="display:none;background-color:White;width:100%">
        <form id="signupForm" method="get" action=""  class="form-horizontal">
        <%--<fieldset style="width: 97%;margin-left:2%;margin-top:0%">--%>
        
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
        <%--</fieldset>--%>
        <fieldset>
        <legend>Project Info</legend>

<!-- Text input-->
 <table style="width:100%;background-color:#a4cd0f">
                
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lCompanyid" for="Companyid" class="family">
                                Company Name</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                         
                                  <select id="Companyid" tabindex="9" style="width: 230px; border:1px solid silver;"name="Companyid" class="family">
                            </select>
                        </td>
                        <td id="sCompanyid" >
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lProjectGroup" for="ProjectGroup" class="family">
                                Project Group</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="ProjectGroup" name="ProjectGroup" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sProjectGroup" >
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lProjectcode" for="Projectcode" class="family">
                                Project Code</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="Projectcode" name="Projectcode" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sProjectcode" >
                        </td>
                    </tr>
                      <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lProjecttype" for="Projecttype" class="family">
                                Project Type</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="Projecttype" name="Projecttype" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sProjecttype" >
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lAddress" for="Address" class="family">
                                Address</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                       
                        
                        <td class="field" width="200" height="40">
                            <input id="Address" name="Address" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                      </tr>
                       
                      
                       <tr>
                        <td id="sAddress" >
                        </td>
                  </tr>
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lProjectName" for="ProjectName" class="family">
                                Project Name</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="ProjectName" name="ProjectName" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sProjectName" >
                        </td>
                    </tr>
                    <tr>
                     <%--<td width="100" height="40" class="family">
                        Gender<span style="font-size: medium; color: Red">*</span>
                    </td>--%>
                    
                    <td>
                        <label>
                            <input type="radio" name="mygender" checked value="radio" id="rdocontract" tabindex="8" />
                            <b>Contract</b></label>
                        <label style="width: 150px;">
                            <input type="radio" name="mygender" value="radio" id="rdoown" tabindex="9" />
                            <b>Own</b></label>
                    </td>
                <td  id="smygender"></td>
                    </tr>
                </table>

<table><tr> <td>
                        <input id="signupsubmit" name="Submit" tabindex="4"   type="submit" value="Save"  />
                        <input id="Cancel" name="Cancel" tabindex="5" type="button" value="Cancel"  runat="server" />
                    </td></tr></table>
</fieldset>
        </form>
    </div>
    <%--<div class="dvGrid">
        <table id="list" class="scroll">
        </table>
        <div id="pager">
        </div>
    </div>--%>
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

<script type="text/javascript" src="../Resources/js/jquery-1.6.2.min.js"></script>

<script src="../Resources/js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

<script type="text/javascript" src="../Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="../Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="../Resources/js/Webutility.js"></script>

<script type="text/javascript" src="../Resources/js/toolbar.js"></script>

<script type="text/javascript" src="../Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="../Resources/js/jquery.ui.widget.js"></script>

<script type="text/javascript" src="../Resources/js/jquery.validate.js"></script>

<script src="../Resources/js/jquery.ui.button.js" type="text/javascript"></script>

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
    /* The variable "mode" is used to find the submit type. Like click event for Add, Edit, Activate, Deactivate*/

    var mode = "";
    var activeStatus = true;
    /* 
    The function jQuery(document).ready(function()) is used at beginning only. Because if document is not ready 
    then some controls might not be loaded. Then Jquery function may try to access the control and might error occur.
    */
////    $(window).bind('resize', function() {
////        $("#list").setGridWidth($('#box').width() - 10, true);
////    }).trigger('resize');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });
    jQuery(document).ready(function() {
        // LoadPermits();

      LoadCompany();

        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        $('#Cancel').click(function() {
            onCancel();
        });

        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_PROJECT_DETAILS%>', '');
        debugger
        Response.ResponseObject.colModel = [
            { name: 'ID', index: 'ID', width: 20, hidden: true, sorttype: "int" },
            { name: 'CompanyName', index: 'CompanyName', width: 100, editable: true,sortable:false },
            { name: 'ProjectGroup', index: 'ProjectGroup', width: 100, editable: true,sortable:false },
            { name: 'projectcode', index: 'projectcode', width: 100, editable: true,sortable:false },
            { name: 'Projecttype', index: 'Projecttype', width: 100, editable: true,sortable:false },
            { name: 'Address', index: 'Address', width: 100, editable: true,sortable:false },
            { name: 'ProjectName', index: 'ProjectName', width: 100, editable: true,sortable:false },
            { name: 'checkcontractown', index: 'checkcontractown', width: 100, editable: true,sortable:false },
            { name: 'isactive', index: 'isactive', width: 40, editable: true, hidden: true },
            { name: 'activestatus', index: 'activestatus', width: 40, align: 'center', editable: true, formatter: cboxFormatter,
                stype:'select', searchoptions:{value: ":All;True:Active;False:Inactive",defaultValue: "All"},
                search:true,edittype: 'checkbox', editoptions: { value: 'True:False' }, formatoptions: { disabled: true }
             },
        ]

        var he = $(window).height();
        var reduce = he * 0.60;
        Response.ResponseObject.height = reduce;
        Response.ResponseObject.autowidth= true;
        
        myGrid.jqGrid(Response.ResponseObject);
        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

//        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        $("#t_list").append("<button type='button' id='add' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><div></div><span>Add</span></button>");
        $("#t_list").append("<button type='button' id='edit' value='Edit' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/edit_icon.png'height=18px;width=18px alt='' /><br/><div></div><span>Edit</span></button>");
       

        $("button ,input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "add") {
                validator.resetForm();
                mode = "add";
                clearLabels();
                $("#isactive").attr('checked', true);
                document.getElementById("divProjectInfo").style.display = "";
               
                $("input[type='text']:first", document.forms[0]).focus();
            }
            else if (id.currentTarget.id == "edit") {
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divProjectInfo").style.display = "";  
                    fillData();
                    $("input[type='text']:first", document.forms[0]).focus();
                }
                else { alert("Please select a row"); }
            }
          
            else if (id.currentTarget.id == "delete") {
                mode = "delete";
                var gr = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (gr != null) jQuery("#list").jqGrid('delGridRow', gr, { reloadAfterSubmit: false });
                else alert("Please Select a Row to delete!");
            }
            
        });

//        var mygrid = jQuery('#list'),
//        cDiv = mygrid[0].grid.cDiv;
//        mygrid.setCaption("");
//        $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
//        $(cDiv).hide();
       // $("#list").closest(".ui-jqgrid-bdiv").height("auto");

        //GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {
                CompanyName: {
                    required: true
                    //alphaNumerix: true,
                    //number: false
                },
                 Companycode: {
                     required: true
                },
                 CompanyShortName: {
                     required: true
                },
                 Address: {
                     required: true
                },
                 financialyearstart: {
                     required: true
                },
                 financialyearend: {
                     required: true
                },
                 financialyearname: {
                     required: true
                },
                 voucherstartdate: {
                     required: true
                },
                 voucherenddate: {
                     required: true
                },
                 Pan: {
                     required: true
                },
                 Tin: {
                     required: true
                },
                 registrationno: {
                     required: true
                },
                pfno: {
                     required: true
                },
                phone: {
                     required: true
                },
                investmentgroup: {
                     required: true
                },
                tan: {
                     required: true
                },
                servicetaxregno: {
                     required: true
                },
                website: {
                     required: true
                },
                email: {
                     required: true
                },
                shopsno: {
                     required: true
                },
                esino: {
                     required: true
                }
            },
            messages: {
                CompanyName: {
                    required: "Enter Company Name"
                    //alphaNumerix: "Invalid Company Name"
                },
                  Companycode: {
                    required: "Enter Company Code"
                },
                  CompanyShortName: {
                    required: "Enter Company ShortName"
                },
                  Address: {
                    required: "Enter Address"
                },
                  financialyearstart: {
                    required: "Please Select StartDate"
                },
                  financialyearend: {
                    required: "Please Select EndDate"
                },
                  financialyearname: {
                    required: "Enter Financial year name"
                },
                  voucherstartdate: {
                    required: "Please Select StartDate"
                },
                  voucherenddate: {
                    required: "Please Select EndDate"
                },
                  Pan: {
                    required: "Enter Pan number"
                },
                  Tin: {
                    required: "Enter Tin number"
                },
                  registrationno: {
                    required: "Enter Registration number"
                },
                  pfno: {
                    required: "Enter Pf number"
                },
                  phone: {
                    required: "Enter Phone number"
                },
                  investmentgroup: {
                    required: "Please Select InvestmentGroup"
                },
                  tan: {
                    required: "Enter tan number"
                },
                  servicetaxregno: {
                    required: "Enter Service tax number"
                },
                  website: {
                    required: "Enter Website"
                },
                  email: {
                    required: "Enter email"
                },
                  shopsno: {
                    required: "Enter shop number"
                },
                  esino: {
                    required: "Enter esi number"
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },

            submitHandler: function(id) {
debugger
                if (mode == "edit") {
                    if (confirm('Do you want to Update the Changes made?') == false) return false;
                }
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                var ID = "";
                if (mode == "edit") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    ID = ret.ID;
                }
                else {
                    ID = "0";
                }
                Request.UpdateBy = $("#hdnEmployeeID").val();
                Request.ID = ID;
                /* Note: jQuery.trim(); function used to remove left and right spaces in string*/
                Request.Companyid = jQuery.trim($("#Companyid").val());
                Request.ProjectGroup = jQuery.trim($("#ProjectGroup").val());
                Request.Projecttype = jQuery.trim($("#Projecttype").val());
                Request.projectcode = jQuery.trim($("#projectcode").val());
                Request.Address = jQuery.trim($("#Address").val());
                Request.ProjectName = jQuery.trim($("#ProjectName").val());
                
                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }

                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_PROJECT%>', Request, true);
               
                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = 'SUCCESS';
                      var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_PROJECT_DETAILS%>', Request, true);
                    if (Response.ResponseObject.datastr == null)
                        jQuery("#list").jqGrid('clearGridData');
                    else {
                        Response.ResponseObject.height = "225";
                        Response.ResponseObject.width = $(window).width() - 65;
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
        var rowid;
        rowid = ret.ID;
        Request.ID = rowid;
        Request.IsActive = true;

        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_PROJECT%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_PROJECT_DETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            Response.ResponseObject.height = "225";
            Response.ResponseObject.width = $(window).width() - 65;
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
        var rowid;
        rowid = ret.ID;
        Request.ID = rowid;
        Request.IsActive = false;

        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_PROJECT%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_PROJECT_DETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            Response.ResponseObject.height = "225";
            Response.ResponseObject.width = $(window).width() - 65;
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
        $('#gs_activestatus').val("");
    }

    function onCancel() {
        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        //$("#divProjectInfo").dialog('close');
        document.getElementById("divProjectInfo").style.display = "none";
    }

    function fillData() {    
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#RelationName").val(ret.RelationName);
        
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }
    }

    function clearLabels() {
        $("#CompanyName").val("");
        $("#Companycode").val("");
        $("#CompanyShortName").val("");
        $("#Address").val("");
        $("#financialyearstart").val("");
        $("#financialyearend").val("");
        $("#financialyearname").val("");
        $("#voucherstartdate").val("");
        $("#voucherenddate").val("");
        $("#Pan").val("");
        $("#Tin").val("");
        $("#registrationno").val("");
        $("#pfno").val("");
        $("#phone").val("");
        $("#investmentgroup").val("");
        $("#tan").val("");
        $("#servicetaxregno").val("");
        $("#website").val("");
        $("#email").val("");
        $("#shopsno").val("");
        $("#esino").val("");
        $("#isactive").attr('checked', false);
    }
    
       function LoadCompany() {
    
    var Response = SendApplicationRequest("<%=HRAppCommands.COMPANY_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Choose Company";
        optn.value = "";
        document.getElementById('Companyid').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
        debugger
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['CompanyName'];
                optn.value = arr[i]['ID'];
                document.getElementById('Companyid').options.add(optn);
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
