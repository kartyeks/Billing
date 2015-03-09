<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="ARATT.Masters.CompanyMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Company</title>
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
    <div id="divCompany" class="dialog" style="display: none;background-color:White;width:100%">
        <form id="signupForm" method="get" action="">
        <fieldset style="width: 97%;margin-left:2%;margin-top:0%">
        <table style="width:100%;background-color:#a4cd0f">
        <tr>
        <td>
            <table style="width:100%;background-color:#a4cd0f">
                
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lCompanyName" for="CompanyName" class="family">
                                Company Name</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="CompanyName" name="CompanyName" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sCompanyName" >
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lCompanycode" for="Companycode" class="family">
                                Company Code</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="Companycode" name="Companycode" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sCompanyCode" >
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lCompanyShortName" for="CompanyShortName" class="family">
                                Company Short Name</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="CompanyShortName" name="CompanyShortName" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sCompanyShortName" >
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
                        <td></td>
                         <td class="field" width="200" height="40">
                            <input id="Address1" name="Address1" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                         </tr>
                       <tr>
                       <td></td>
                        <td class="field" width="200" height="40">
                            <input id="Address2" name="Address2" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                       </tr>
                       <tr>
                        <td id="sAddress" >
                        </td>
                  </tr>
                    
                </table>
            </td>
            <td>
                <table style="width:100%;background-color:#a4cd0f">
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lfinancialyearstart" for="financialyearstart" class="family">
                                Financial year start date</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <%--<input id="financialyearstart" name="financialyearstart" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>--%>
                                
                                 <input type="text" id="financialyearstart" tabindex="9" style="width: 205px;border:1px solid silver;" readonly="readonly"
                                name="financialyearstart" class="family"/>
                        </td>
                        <td id="sfinancialyearstart" >
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lfinancialyearend" for="financialyearend" class="family">
                                Financial year end Date</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="financialyearend" style="width: 205px;border:1px solid silver;" readonly="readonly"
                                name="financialyearend"  class="family"/>
                        </td>
                        <td id="sfinancialyearend" >
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lfinancialyearname" for="financialyearname" class="family">
                                Financial year Name</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="financialyearname" name="financialyearname" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sfinancialyearname" >
                        </td>
                    </tr>
                    
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lvoucherstartdate" for="voucherstartdate" class="family">
                                Voucher Entry period start date</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="voucherstartdate" style="width: 205px;border:1px solid silver;" readonly="readonly"
                                  name="voucherstartdate"  class="family"/>
                        </td>
                        <td id="svoucherstartdate" >
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lvoucherenddate" for="voucherenddate" class="family">
                                Voucher Entry period End Date</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                                   <input id="voucherenddate" style="width: 205px;border:1px solid silver;" readonly="readonly"
                                  name="voucherenddate"  class="family"/>
                        </td>
                        <td id="svoucherenddate" >
                        </td>
                    </tr>
                    
                    
                    </table>
                   
                 </td></tr>
                 <tr>
                 <td>
                    <table style="width:100%;background-color:#a4cd0f">
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lPan" for="Pan" class="family">
                                PAN</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="Pan" name="Pan" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sPan" >
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lTin" for="Tin" class="family">
                                TIN</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="Tin" name="Tin" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sTin" >
                        </td>
                    </tr>
                    
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lregistrationno" for="registrationno" class="family">
                                Registration Number
                                </label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="registrationno" name="registrationno" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sregistrationno" >
                        </td>
                    </tr>
                    
                    
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lpfno" for="pfno" class="family">
                                PF Number</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="pfno" name="pfno" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="spfno" >
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lphone" for="phone" class="family">
                                Phone</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="phone" name="phone" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sphone" >
                        </td>
                    </tr>
                    </table>
                </td>
                <td>
                    <table style="width:100%;background-color:#a4cd0f">
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="linvestmentgroup" for="investmentgroup" class="family">
                                Investment Group</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                        <%--    <input id="investmentgroup" name="investmentgroup" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>--%>
                                 <select id="investmentgroup" tabindex="9" style="width: 230px; border:1px solid silver;"name="investmentgroup" class="family">
                            </select>
                        </td>
                        <td id="sinvestmentgroup" >
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="ltan" for="tan" class="family">
                                TAN</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="tan" name="tan" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="stan" >
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lservicetaxregno" for="servicetaxregno" class="family">
                                Service Tax Registration No.</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="servicetaxregno" name="servicetaxregno" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sservicetaxregno" >
                        </td>
                    </tr>
                    
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lwebsite" for="website" class="family">
                                Website</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="website" name="website" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="swebsite" >
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lemail" for="email" class="family">
                                Email</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="email" name="email" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="semail" >
                        </td>
                    </tr>
                    
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lshopsno" for="shopsno" class="family">
                                Shops & Establishment Number</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="shopsno" name="shopsno" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sshopsno" >
                        </td>
                    </tr>
                    
                    
                    
                    
                    
                    <tr>
                        <td class="label" width="200" height="40" >
                            <label id="lesino" for="esino" class="family">
                                ESI Number</label>
                                <span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td class="field" width="200" height="40">
                            <input id="esino" name="esino" style="width: 220px;border:1px solid silver" type="text" value=""
                                maxlength="100" class="family"/>
                        </td>
                        <td id="sesino" >
                        </td>
                    </tr>
                    
                    </table>
                    
                </td>
                </tr>
                <tr>
                <td>
                    <table>
                    
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
                        <input id="signupsubmit" name="Submit" tabindex="4"   type="submit" value="Save"  />
                        <input id="Cancel" name="Cancel" tabindex="5" type="button" value="Cancel"  runat="server" />
                    </td>
                    </tr>
                    </table>
                </td>
                </tr>
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

        LoadInvestmentGroup();
        $(function() {        
            $("#financialyearstart").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                showTimePicker: false,
                yearRange: '1930:2050'
            });
            $("#financialyearstart").datepicker("option", "dateFormat", 'dd/mm/yy');            
        });    
        $(function() {        
            $("#financialyearend").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                showTimePicker: false,
                yearRange: '1930:2050'
            });
            $("#financialyearend").datepicker("option", "dateFormat", 'dd/mm/yy');            
        });   
        $(function() {        
            $("#voucherstartdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                showTimePicker: false,
                yearRange: '1930:2050'
            });
            $("#voucherstartdate").datepicker("option", "dateFormat", 'dd/mm/yy');            
        });    
        $(function() {        
            $("#voucherenddate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                showTimePicker: false,
                yearRange: '1930:2050'
            });
            $("#voucherenddate").datepicker("option", "dateFormat", 'dd/mm/yy');            
        });     


        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        $('#Cancel').click(function() {
            onCancel();
        });

        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_COMPANY_DETAILS%>', '');
        debugger
        Response.ResponseObject.colModel = [
            { name: 'ID', index: 'ID', width: 20, hidden: true, sorttype: "int" },
            { name: 'CompanyCode', index: 'CompanyCode', width: 100, editable: true,sortable:false },
            { name: 'CompanyName', index: 'CompanyName', width: 100, editable: true,sortable:false },
            { name: 'FinancialYearName', index: 'FinancialYearName', width: 100, editable: true,sortable:false },
            { name: 'PanNumber', index: 'PanNumber', width: 100, editable: true,sortable:false },
            { name: 'email', index: 'email', width: 100, editable: true,sortable:false },
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
                document.getElementById("divCompany").style.display = "";
               
                $("input[type='text']:first", document.forms[0]).focus();
            }
            else if (id.currentTarget.id == "edit") {
                validator.resetForm();
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    clearLabels();
                    document.getElementById("divCompany").style.display = "";  
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
                Request.CompanyName = jQuery.trim($("#CompanyName").val());
                Request.Companycode = jQuery.trim($("#Companycode").val());
                Request.CompanyShortName = jQuery.trim($("#CompanyShortName").val());
                Request.Address = jQuery.trim($("#Address").val());
                Request.Address1 = jQuery.trim($("#Address1").val());
                Request.Address2 = jQuery.trim($("#Address2").val());
                Request.financialyearstart = jQuery.trim($("#financialyearstart").val());
                Request.financialyearend = jQuery.trim($("#financialyearend").val());
                Request.financialyearname = jQuery.trim($("#financialyearname").val());
                Request.voucherstartdate = jQuery.trim($("#voucherstartdate").val());
                Request.voucherenddate = jQuery.trim($("#voucherenddate").val());
                Request.Pan = jQuery.trim($("#Pan").val());
                Request.Tin = jQuery.trim($("#Tin").val());
                Request.registrationno = jQuery.trim($("#registrationno").val());
                Request.pfno = jQuery.trim($("#pfno").val());
                Request.phone = jQuery.trim($("#phone").val());
                Request.investmentgroup = jQuery.trim($("#investmentgroup").val());
                Request.tan = jQuery.trim($("#tan").val());
                Request.servicetaxregno = jQuery.trim($("#servicetaxregno").val());
                Request.website = jQuery.trim($("#website").val());
                Request.email = jQuery.trim($("#email").val());
                Request.shopsno = jQuery.trim($("#shopsno").val());
                Request.esino = jQuery.trim($("#esino").val());
                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }

                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_COMPANY%>', Request, true);
               
                alert(Response.Message);
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = 'SUCCESS';
                      var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_COMPANY_DETAILS%>', Request, true);
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

        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_COMPANY%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_COMPANY_DETAILS%>', Request, true);
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

        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_COMPANY%>", Request, true);
        alert(Response.Message);

        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_COMPANY_DETAILS%>', Request, true);
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
        //$("#divCompany").dialog('close');
        document.getElementById("divCompany").style.display = "none";
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
    
       function LoadInvestmentGroup() {
    
    var Response = SendApplicationRequest("<%=HRAppCommands.COMPANY_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Choose Investment";
        optn.value = "";
        document.getElementById('investmentgroup').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
        debugger
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['InvestmentGroupName'];
                optn.value = arr[i]['ID'];
                document.getElementById('investmentgroup').options.add(optn);
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

