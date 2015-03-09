<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LocationMaster.aspx.cs"
    Inherits="AltioStarHR.Masters.LocationMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Location Master</title>
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
<body id="ibody">
<div style="position:relative;width:100%">
   <img alt="" src="Resources/Images/NewImages/1.png"style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;" >
  <strong class="family1 imageheadercolor">Location Details</strong>
    </div>
</div>
<%--<div class="right-triangle"></div>--%>
    <div id="divLocation" class="dialog" style="display:none;width:100%;">
        <form id="signupForm" method="get" action="">
        <fieldset style="width: 97%;margin-left:2%;margin-top:0%">
            <table  style="width:100%;background-color:#a4cd0f">
                <tbody>
                    <tr>
                        <td style="width:20%">
                            <label id="llocation" for="location" class="family">
                                Location Name</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="location" name="location" type="text" style="width: 210px;border:1px solid silver" tabindex="1"
                                value="" maxlength="50" />
                        </td>
                        <td id="slocation" >
                        </td>
                    </tr>
                    <tr>
                        <td class="label" width="100" height="40" >
                            <label id="lcountry" for="country" class="family">
                                Country</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <select id="country" tabindex="9" style="width: 220px;border:1px solid silver;" name="country"
                                runat="server" class="family">
                            </select>
                        </td>
                        <td id="scountry" >
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lisactive" class="family">
                                Active</label>
                        </td>
                        <td class="field">
                            <input id="isactive" tabindex="3" type="checkbox" style="border:1px solid silver;" />
                        </td>
                        <td class="status" id="sisactive">
                        </td>
                    </tr>
                    <tr>
                    <td></td>
                    <td>
                      <input id="signupsubmit" name="Submit" tabindex="4" type="submit" value="Save" class="family"/>
                        <input id="Cancel" name="Cancel" tabindex="5" type="button" value="Cancel" class="family"/>
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

<script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

<script src="Resources/js/jquery.ui.button.js" type="text/javascript"></script>

<script type="text/javascript" src="Resources/js/jquery.validate.js"></script>


    
    

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
//    $(window).bind('resize', function() {
//        $("#list").setGridWidth($('#box').width() - 10, true);
//    }).trigger('resize'); 
    
    jQuery(document).ready(function() {
        LoadPermits();
    
        LoadCountry();        
        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        $('#Cancel').click(function() {
            onCancel();
        });

        var myGrid = $('#list');
//        $('#box').css('background-image', 'url(../Resources/css/images/dashboard_bg.gif)');
        //   $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg.gif)');
        $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });

        var Response = SendApplicationRequest('<%=HRAppCommands.LOCATION_DETAILS%>', '');        
        Response.ResponseObject.colModel = [
   		            { name: 'locationid', index: 'locationid', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'locationname', index: 'locationname', width: 100, editable: true },  		            		            
   		            { name: 'countryid', index: 'countryid', width: 100, hidden: true, editable: true },
   		            { name: 'countryname', index: 'countryname', width: 100, editable: true },
   		            { name: 'isactive', index: 'isactive', width: 100, editable: true, hidden: true },
//   		            { name: 'Status', index: 'Status', width: 40, editable: true, stype: 'select', formatter: 'checkbox', edittype: 'checkbox',
//   		                editoptions: { value: ":All;True:Active;False:Inactive" }
//   		            }
                    {name: 'Status', index: 'Status', width: 40, align: 'center', editable: true, formatter: cboxFormatter,
                    stype: 'select', searchoptions: { value: ":All;True:Active;False:Inactive", defaultValue: "All" },
                    search: true, edittype: 'checkbox', editoptions: { value: 'True:False' }, formatoptions: { disabled: true }
                    },

  		          	             
   	            ];
        Response.ResponseObject.onSelectRow = function(ID) {
            fillData();
        }

        Response.ResponseObject.caption = "";
        
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
       
//        
            $("button ,input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "add") {
                validator.resetForm();
                mode = "add";
                clearLabels();
                $("#isactive").attr('checked', true);
                document.getElementById("divLocation").style.display = "";
               
            }
            else if (id.currentTarget.id == "edit") {        
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divLocation").style.display = "";
                   
                    fillData();
                }
                else { alert("Please select a row"); }
            }
               
           
        });
        /*
        var mygrid = jQuery('#list'),
        cDiv = mygrid[0].grid.cDiv;
        mygrid.setCaption("");
        $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
        $(cDiv).hide();
        $("#list").closest(".ui-jqgrid-bdiv").height("auto");
        */
//        $("#list").closest(".ui-jqgrid-bdiv").height("auto");
       // GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {
                location: {
                    required: true,
                    alphaNumerix: true
                },               
                country:{
                    required: true
                 }               
            },
            
            messages: {
                location: {
                    required: "Enter Location Name",
                    alphaNumerix: "Invalid Location"
                },               
                country:{
                required: "Select Country"
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
                if (mode == "edit") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    ID = ret.locationid;
//                    if (confirm('Do you want to Update the Changes made?') == false)
//                        return false;
                }
                else {
                    ID = "0";
                }
                
                Request.UpdateBy = $("#hdnEmployeeID").val();
                Request.ID = ID;
                Request.LocationName = $("#location").val();
                Request.CountryID = $("#country").val(); 
                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }        
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_LOCATION%>', Request, true);                            
                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = "SUCCESS";
                    var Response = SendApplicationRequest('<%=HRAppCommands.LOCATION_DETAILS%>', Request, true);
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
        ID = ret.locationid;
        Request.ID = ID;
        Request.IsActive = true;

        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_LOCATION%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.LOCATION_DETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }

        $('#gs_Status').val("");
    }

    function DeActivateRow(ROWID) {
        var ret = jQuery("#list").jqGrid('getRowData', ROWID);
        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');

        if (confirm('Do you want to deactivate?') == false) {
            $("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
            return;
        };

        var Request = new Object();
        ID = ret.locationid;
        Request.ID = ID;
        Request.IsActive = false;

        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_LOCATION%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.LOCATION_DETAILS%>', Request, true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
        $('#gs_Status').val("");
    }
    function onCancel() {
        if (mode != "SUCCESS") {
            if (confirm('Do you want to cancel?') == false) return;
        }
        document.getElementById("divLocation").style.display = "none";
        //$("#divLocation").dialog('close');
    }

    function fillData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);        
        $("#location").val(ret.locationname);       
        $("#country").val(ret.countryid);        
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }      
        
    }

    function clearLabels() {
        $("#location").val("");        
        $("#country").val("");       
        $("#isactive").attr('checked', false);         
    }    
    function LoadCountry() {    
        var Response = SendApplicationRequest('<%=HRAppCommands.COUNTRY_DETAILS%>', '');      
        var optn = document.createElement("OPTION");
        optn.text = "Choose Country";
        optn.value = "";
        document.getElementById('country').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['CountryName'];
                optn.value = arr[i]['ID'];
                document.getElementById('country').options.add(optn);
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
