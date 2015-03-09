<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Master_Country.aspx.cs" Inherits="AltioStarHR.Masters.Master_Country" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Country</title>
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
        #Clientmaster
        {
            width: 217px;
        }
        
    </style>
    
</head>
<body>
<div style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png"style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;" >
  <strong class="family1 imageheadercolor">Country</strong>
    </div>
</div>
    <div class="dvGrid" id="divCountry" style="display:none;width:100%;">
        <form id="signupForm" method="get" action="">
        <fieldset style="width: 97%;margin-left:2%;margin-top:0%">
            <table style="width:100%;background-color:#a4cd0f">
                <tr>
                <td style="width:20%;">
                        <label id="lcountryid" for="countryid" style="width: auto" class="family">
                            Country Code<span style="font-size: medium; color: Red"><b>*</b></span></label>
                    </td>
                    <td style="width:18%;">
                        <input id="countryid" name="countryid" type="text" maxlength="15" 
                            style="width: 220px;border:1px solid silver" class="family"/>
                    </td>
                    <td id="scountryid" >
                    </td>
                </tr>
                <tr>
                   <td style="width:20%;">
                    <label id="lcountry" for="country" style="width: auto" class="family">
                            Country Name<span style="font-size: medium; color: Red"><b>*</b></span></label>
                    </td>
                    <td style="width:18%;">
                        <input id="country" name="country" type="text" maxlength="250" 
                            style="width: 220px;border:1px solid silver" class="family"/>
                    </td>
                    <td id="scountry" >
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
                        <input id="signupsubmit" name="Submit" type="submit" class="family" value="Save" />
                        <input id="Cancel" name="Cancel" type="button" class="family"  value="Cancel" />
                    </td>
                </tr>
            </table>
            <%--<table>
                <tr align="center">
                    <td>
                        <input id="signupsubmit" name="Submit" type="submit" value="Save" />
                    </td>
                    <td>
                        <input id="Cancel" name="Cancel" type="button" value="Cancel" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>--%>
        </fieldset>
        </form>
    </div>
    <div style="margin-left:2%;" id="box" runat="server">
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
    <input type="hidden" id="hdnApply" runat="server" />
    <input type="hidden" id="hdnApprove" runat="server" />
    <input type="hidden" id="hdnView" runat="server" />
    <input type="hidden" id="hdnRoleid" runat="server" />
    <input type="hidden" id='hdnMode' runat="server" />
    <input type="hidden" id='hdnuserid' runat="server" />
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


//    $(window).bind('resize', function() {
//        $("#list").setGridWidth($('#box').width() - 10, true);
//    }).trigger('resize');
    jQuery("#box").css({ width: "97%" });
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });

    var mode = "";
    var activeStatus = true;
    jQuery(document).ready(function() {

        // LoadPermits();
        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-z0-9\-\.\_\/\,\&\;\:\"\'\(\)\|\+\#\@\!\~\`\^\*\$\?\>\<\%\s]+$/i.test(value);
        }, "contain only letters, numbers, or dashes.");

        var myGrid = $('#list');

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_COUNTRY_DETAILS%>', '', true);

        Response.ResponseObject.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'countryid', index: 'countryid', width: 100, editable: true },
            { name: 'countryname', index: 'countryname', width: 100, editable: true },
            { name: 'isactive', index: 'isactive', width: 20, editable: true, hidden: true },
            { name: 'createdby', index: 'createdby', width: 100, editable: true, hidden: true },
            { name: 'createddate', index: 'createddate', width: 100, editable: true, hidden: true },
            { name: 'modifiedby', index: 'modifiedby', width: 100, editable: true, hidden: true },
            { name: 'modifieddate', index: 'modifieddate', width: 100, editable: true, hidden: true },
            { name: 'activestatus', index: 'activestatus', width: 40, align: 'center', editable: true, formatter: cboxFormatter,
                stype: 'select', searchoptions: { value: ":All;True:Active;False:Inactive", defaultValue: "All" },
                search: true, edittype: 'checkbox', editoptions: { value: 'True:False' }, formatoptions: { disabled: true }
            },

        ];


        $('select#gs_StateId').val('0'); //Status New

        Response.ResponseObject.onSelectRow = function(ID) {
            fillData();
        }

        Response.ResponseObject.hidegrid = false;
        Response.ResponseObject.ignoreCase = true;
       
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
        //        $("#t_list").append("<img src='Resources/Images/NewImages/Activate.jpg' height=18px;width=18px alt='' /><input type='checkbox' id='activedata' value='activedata' checked /> ");

        $("button,input", "#t_list").click(function(id) {

            if (id.currentTarget.id == "add") {
                validator.resetForm();
                mode = "add";
                clearLabels();
                $("#isactive").attr('checked', true);
                document.getElementById("divCountry").style.display = "";
            }
            else if (id.currentTarget.id == "edit") {
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divCountry").style.display = "";
                    fillData();
                }
                else { alert("Please select a row"); }
            }

            //            else if (id.currentTarget.id == "activedata") {
            //                mode = "activedata";
            //                BindGrid(1);
            //            }
        });
        $('#Cancel').click(function() {
            onCancel();
        });

        //        var mygrid = jQuery('#list'),
        //        cDiv = mygrid[0].grid.cDiv;
        //        mygrid.setCaption("");
        //        $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
        //        $(cDiv).hide();

        //  $("#list").closest(".ui-jqgrid-bdiv").height("auto");


        var validator = $("#signupForm").validate({
            rules: {
                countryid: {
                    alphaNumerix: true,
                    required: true
                },
                country: {
                    alphaNumerix: true,
                    required: true
                }

            },

            messages: {
                countryid: {
                    alphaNumerix: "Invalid Country Code",
                    required: "Enter Country Code"
                },
                country: {
                    alphaNumerix: "Invalid Country Name",
                    required: "Enter Country Name"
                }
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
                var CrationDate = "";
                if (mode == "edit") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    ID = ret.id;
                    CrationDate = ret.createddate;
                }
                else {
                    ID = "0";
                    CrationDate = new Date();
                    Request.CreatedBy = 1;
                }
                Request.ModifiedBy = 1;
                Request.ID = ID;
                Request.CountryName = $.trim($("#country").val());
                Request.CountryID = $.trim($("#countryid").val());


                Request.CreatedDate = CrationDate;

                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }

                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_COUNTRY%>', Request, true);

                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = "SUCCESS";

                    var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_COUNTRY_DETAILS%>', Request, true);
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

//function toggleCurrency(currencySelect) {
//
//    var emptyOption = '<option value=""></option>';

//    return true;
//}

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

        var Response = SendApplicationRequest("<%=HRAppCommands.GET_ACTIVE_DEACTIVATE_COUNTRY%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_COUNTRY_DETAILS%>', Request, true);
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

        var Response = SendApplicationRequest("<%=HRAppCommands.GET_ACTIVE_DEACTIVATE_COUNTRY%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_COUNTRY_DETAILS%>', Request, true);
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
        document.getElementById("divCountry").style.display = "none";
    }
    
    function fillData() {

        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#country").val(ret.countryname);
        $("#countryid").val(ret.countryid);
        
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }
    }
    
    function clearLabels() {
        $("#countryid").val("");
        $("#country").val("");
        $("#isactive").attr('checked', false);
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
