<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loan.aspx.cs" Inherits="AltioStarHR.LoanManagement.Loan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Loan</title>
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
        #addInstallment
        {
            height: 13px;
            width: 13px;
        }
        #loanname
        {
            height: 22px;
        }
        .style1
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <div>
       <%-- <div class="header_title2">
            Loan</div>--%>
        <div class="dvGrid">
            <table id="list" class="scroll">
            </table>
            <div id="pager">
            </div>
        </div>
    </div>
    <div id="divLoan" class="dialog" title="Loan" style="display: none">
        <form id="signupForm" method="get" action="">
        <fieldset>
            <table class="teble_bg">
                <tbody>
                    <tr>
                        <td class="label">
                            <label id="lloanName" for="loan">
                                LoanName<span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field">
                            <input id="loanname" name="loanname" type="text" value="" maxlength="100" style="width: 300px;" />
                        </td>
                        <td class="status" id="sloanname" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="llimit" for="limit">
                                Limit<span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field">
                            <input id="basicpercentage" name="basicpercentage" type="text" value="" style="width: 50px" /><b>%
                                OF BASIC OR</b>
                            <input id="maxamount" name="maxamount" type="text" value="" maxlength="100" style="width: 100px;" /><b>MAXIMUM</b>
                        </td>
                        <td class="status" id="smaxamount">
                        </td>
                        <td class="status" id="sbasicpercentage">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="linterest" for="interest">
                                Interest</label>
                        </td>
                        <td class="field">
                            <input id="interest" name="interest" type="text" value="" maxlength="100" style="width: 30px;" />%
                        </td>
                        <td class="status" id="sinterest" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="label">
                            <label>
                                <span style="font-size: small; color: Red"><b>#</b> Interest applicable only when employee
                                    is Terminated/Fired before the completion of the loan tenure.</span></label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="label">
                            <label id="linstallment" for="installment">
                                Installment<span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field">
                            <table>
                                <tr>
                                    <td style="width: 165px;">
                                        <table border="1" style="width: 165px;">
                                            <tr>
                                                <td class="style1">
                                                    Service Period
                                                </td>
                                                <td class="style1">
                                                    Installment
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td>
                                                    <input id="serviceperiod" name="serviceperiod" type="text" style="width: 30px" />
                                                </td>
                                                <td>
                                                    <input id="installment" name="installment" type="text" style="width: 30px" />
                                                </td>
                                            </tr>
                                        </table>
                                        <a href="#" id="clearinstallment" style="color: Green">Clear Data</a>
                                    </td>
                                    <td style="width: 20px;">
                                        <img src="Resources/images/addIcon.png" alt="Add Installment"
                                            id="addInstallment" align="right" />
                                    </td>
                                    <td style="width: auto">
                                        <div id="displayInstallment">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="status" id="slevel" colspan="2">
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td colspan="4">
                            <label id="intallmentForDB">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lMinServicePeriod" for="MinServicePeriod">
                                Min Service Period<span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field">
                            <input id="MinServicePeriod" name="MinServicePeriod" type="text" value="" style="width: 50px" />
                        </td>
                        <td class="status" id="sMinServicePeriod" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lMinLeaveBalance" for="MinLeaveBalance">
                                Min Leave Balance<span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field">
                            <input id="MinLeaveBalance" name="MinLeaveBalance" type="text" value="" style="width: 50px" />
                        </td>
                        <td class="status" id="sMinLeaveBalance" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lRemainingService" for="RemainingService">
                                Remaining Service<span style="font-size: medium; color: Red">*</span></label>
                        </td>
                        <td class="field">
                            <input id="RemainingService" name="RemainingService" type="text" value="" style="width: 50px" />
                        </td>
                        <td class="status" id="sRemainingService" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            <label id="lisactive" >
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
    var instDisp=0;
    var collectInstallData="";
    var instPreDataedit="";
    jQuery(document).ready(function() {
    debugger
        LoadPermits();
        
         $("#serviceperiod").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
            if($("#serviceperiod").val().length > 1)
            {
                return false;
            }
        });
        
        $("#installment").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
            if($("#installment").val().length > 2)
            {
                return false;
            }
        }); 
         
        $('#clearinstallment').attr("disabled",true);
        $('#clearinstallment').click(function() {
            $('#displayInstallment').html("");
            $('#clearinstallment').attr("disabled",false);
            instDisp=0;
            $("#intallmentForDB").text("");  
        });
        
        $('#addInstallment').click(function() {
        var spdata=$('#serviceperiod').val();
        var intdata=$('#installment').val();
        
        if(spdata=="" || intdata=="" || spdata=="0" || intdata=="0")
        {
            alert("Enter Installment details");
            return;
        }
        if(instDisp==0)
        {
            $('#displayInstallment').html("<table border='1' style='width: 190px;'><tr><td class='style1'>Service Period</td><td class='style1'>Installment</td></tr><tbody id='intallData'></tbody></table>");
            instDisp=1;
        }
        
        if(isUniqueInstallment(spdata,intdata,instDisp))
        {
            instPreData=$('#intallData').html();
            $('#intallData').html(instPreData+"<tr id='trinstData"+instDisp+"' ><td><label id='spdata"+instDisp+"' >"+spdata+"</label></td><td><label id='intdata"+instDisp+"' >"+intdata+"</label></td></tr>");
            $('#serviceperiod').val("");
            $('#installment').val("");            
         collectInstallData="";
         for(var j=1;j<=instDisp;j++)
         {
              if($("#spdata"+instDisp).text()!=null ||$("#spdata"+instDisp).text()!="")
              {
                    
                        collectInstallData=collectInstallData+$("#spdata"+j).text()+","+$("#intdata"+j).text()+"|";
              }
              $('#clearinstallment').attr("disabled",false);
         }
          collectInstallData = collectInstallData.slice(0, -1);
         $("#intallmentForDB").text(collectInstallData);   
         instDisp++;
        }
        else
            alert("Already Added");
        });

        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        $.validator.addMethod("CheckDecimalUpto2Digit", function(value, element) {
            return this.optional(element) || /^[0-9]+(\.[0-9]{1,2})?$/i.test(value);
        }, "More Than Two Decimal Digit not allowed.");

        $('#Cancel').click(function() {
            onCancel();
        });
        
        $("#basicpercentage").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
            if($("#basicpercentage").val().length > 1)
            {
                return false;
            }
        });
        $("#maxamount").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
            if($("#maxamount").val().length > 9)
            {
                return false;
            }
        });
        $("#interest").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && e.which != 46 && (e.which < 48 || e.which > 57)) {
                return false;
            }
            if($("#interest").val().length > 1)
            {
                return false;
            }
        });
        $("#repaymentmonth").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        
        $("#MinServicePeriod").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }            
            if(Math.floor( $("#MinServicePeriod").val())>30)                        
                return false;            
        });
        
        $("#RemainingService").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            } 
            if($("#RemainingService").val().length > 1)
            {
                return false;
            }           
//            if(Math.floor( $("#RemainingService").val())>30)                        
//                return false;            
        });
        
        $("#MinLeaveBalance").keypress(function(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }            
            if(Math.floor( $("#MinLeaveBalance").val())>30)                        
                return false;            
        });

        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=HRAppCommands.LOAN_DETAILS%>', '');        
        Response.ResponseObject.colModel = [
   		            { name: 'loanid', index: 'loanid', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'loanname', index: 'loanname', width: 100, editable: true },
   		            { name: 'maxamount', index: 'maxamount', width: 100, editable: true },
   		            { name: 'interest', index: 'interest', width: 100, editable: true },
   		            { name: 'isactive', index: 'isactive', width: 100, editable: true, hidden: true },   		            
   		            { name: 'maxbasicpercentage', index: 'maxbasicpercentage', width: 100, editable: true },
   		            { name: 'minserviceperiod', index: 'minserviceperiod', width: 100, editable: true },
   		            { name: 'minleavebalance', index: 'minleavebalance', width: 100, editable: true },
   		            { name: 'remainingservice', index: 'remainingservice', width: 100, editable: true },
   		            { name: 'installment', index: 'installment', width: 100, editable: true, hidden: true}
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
         //   onGetPermissionDisplay();
        }
        
        $("input", "#t_list").click(function(id) {
            if (id.currentTarget.id == "add") {
                validator.resetForm();
                mode = "add";
                clearLabels();
                $("#isactive").attr('checked', true);
                document.getElementById("divLoan").style.display = "";
                $('#divLoan').dialog({
                    height: 400,
                    width: 575,
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
                    document.getElementById("divLoan").style.display = "";
                    $('#divLoan').dialog({
                        height: 400,
                        width: 575,
                        modal: true
                    })
                    fillData();
                    $("input[type='text']:first", document.forms[0]).focus();
                }
                else  alert("Please select Loan"); 
            }
            else if (id.currentTarget.id == "activedata") {
                mode = "activedata";
                BindGrid(1);
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
                        ID = ret.loanid;
                        Request.ID = ID;
                        Request.ChangedBy = $("#hdnEmployeeID").val();
                        var Response = SendApplicationRequest("<%=HRAppCommands.DEACTIVATE_LOAN%>", Request, true);
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=HRAppCommands.LOAN_DETAILS%>', '', true);
                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setCaption', "LoanDetails").trigger('reloadGrid');
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else alert("Selected Loan is already deactivated!");                   
                }
                else alert("Please Select Loan to deactivate!");
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
                        ID = ret.loanid;
                        Request.ID = ID;
                        Request.ChangedBy = $("#hdnEmployeeID").val();
                        var Response = SendApplicationRequest("<%=HRAppCommands.ACTIVATE_LOAN%>", Request, true);
                        alert(Response.Message);
                        if (Response.ResponseCommand == 'SUCCESS') {
                            mode = "";
                            var Response = SendApplicationRequest('<%=HRAppCommands.INACTIVE_LOAN%>', '', true);
                            if (Response.ResponseObject.datastr == null)
                                jQuery("#list").jqGrid('clearGridData');
                            else {
                                jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
                                jQuery("#list").jqGrid('setCaption', "LoanDetails").trigger('reloadGrid');
                                jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
                            }
                        }
                    }
                    else alert("Selected Loan is already activated!");                    
                }
                else alert("Please Select Loan to activate!");                
            }
        });
        
        GridActiveButton();
        var validator = $("#signupForm").validate({
            rules: {
                loanname: {
                    required: true,
                    alphaNumerix: true
                },
                maxamount:
                {
                    required: true,
                    number: true
                },
                interest: "CheckDecimalUpto2Digit",
                basicpercentage:{
                    required: true,
                    CheckDecimalUpto2Digit: true 
                },              
                MinServicePeriod:"required",                   
                MinLeaveBalance:"required",
                RemainingService:"required"       
            },
            messages: {
                loanname: {
                    required: "Enter Loan Name",
                    alphaNumerix: "Invalid Loan"
                },
                maxamount:
               {
                   required: "Enter Max Amount",
                   number: "Invalid Max Amount"
               },
                interest: "Invalid Interest",
                basicpercentage:{
                    required: "Enter Basic Percentage",
                    CheckDecimalUpto2Digit: "Invalid Basic Percentage"
                },
                MinServicePeriod:"Enter Min Service Period",                   
                MinLeaveBalance:"Enter Min Leave Balance",
                RemainingService:"Enter Remaining Service"                            
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            
            submitHandler: function() {
               debugger
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                var ID = "";
                if (mode == "edit") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    ID = ret.loanid;
                }
                else {
                    ID = "0";
                }

                Request.ID = ID;
                Request.LoanName = $("#loanname").val();
                Request.MaxAmount = $("#maxamount").val();
                
                var xInterest = 0;
                var xbasicpercentage=0;
                var xMinServicePeriod=0;
                var xRemainingService=0;
                if ($.trim($("#interest").val()) != "" && $("#interest").val() != ".") xInterest = $("#interest").val();
                Request.Interest = xInterest; 
                if ($.trim($("#basicpercentage").val()) != "" && $("#basicpercentage").val() != ".") xbasicpercentage = $("#basicpercentage").val();
                Request.MaxBasicPercentage = xbasicpercentage;               
                Request.Installment= $("#intallmentForDB").text(); 
                Request.MinLeaveBalance= $("#MinLeaveBalance").val();              
                //Request.MaxBasicPercentage= $("#basicpercentage").val();               
                Request.MinServicePeriod= $("#MinServicePeriod").val();                
                Request.RemainingService= $("#RemainingService").val();
                if ($("#intallmentForDB").text()=="")
                {
                    alert("Enter Installment Details");
                    return;
                }

                if ($("#isactive").is(':checked')) { Request.IsActive = true; }
                else { Request.IsActive = false; }
                
                Request.UpdateBy = $("#hdnEmployeeID").val();
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_LOAN%>', Request, true);                
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
    
    function isUniqueInstallment(spdata,spinstall,count)
    { 
    var checkFlag=true;
        for(var i=1;i<=count;i++)
        {
        if( $("#spdata"+i).text()==spdata && $("#intdata"+i).text()==spinstall) {checkFlag=false; break}
        }
    return checkFlag;
    }
    
    function BindGrid(pageNumber) {
        var Request = new Object();
        if ($("#activedata").is(':checked')) {
            var Response = SendApplicationRequest("<%=HRAppCommands.LOAN_DETAILS%>", '', true);
            activeStatus = true;
        }
        else {
            var Response = SendApplicationRequest("<%=HRAppCommands.INACTIVE_LOAN%>", '', true);
            activeStatus = false;
        }
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").jqGrid('setCaption', "LoanDetails").trigger('reloadGrid');
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
        $("#divLoan").dialog('close');
    }

    function fillData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        $("#loanname").val(ret.loanname);
        $("#maxamount").val(ret.maxamount);
        $("#interest").val(ret.interest);
        $("#repaymentmonth").val(ret.repaymentmonth);
        if (ret.isactive == 'False') { $("#isactive").attr('checked', false); }
        else { $("#isactive").attr('checked', true); }
        
        $("#basicpercentage").val(ret.maxbasicpercentage);
        $("#MinServicePeriod").val(ret.minserviceperiod);
        $("#MinLeaveBalance").val(ret.minleavebalance);
        $("#RemainingService").val(ret.remainingservice);
        fillInstallmentTable(ret.installment);
    }
    
    function fillInstallmentTable(installment)
    {    
        $('#clearinstallment').attr("disabled",false);
        var insPair=installment.split("|");
        var insSerPe="";
        var insVal="";
        var insArr;        
        for(var i=1;i<=insPair.length;i++)
        {
            insArr=insPair[i-1].split(",");
                insSerPe=insArr[0];
                insVal=insArr[1];            
                if(i==1)
                 {
                    $('#displayInstallment').html("<table border='1' style='width: 190px;'><tr><td class='style1'>Service Period</td><td class='style1'>Installment</td></tr><tbody id='intallData'></tbody></table>");                   
                 }
                instPreDataedit=$('#intallData').html();
                $('#intallData').html(instPreDataedit+"<tr id='trinstData"+i+"' ><td><label id='spdata"+i+"' >"+insSerPe+"</label></td><td><label id='intdata"+i+"' >"+insVal+"</label></td></tr>");               
        }  
        instDisp=insPair.length+1;
        $("#intallmentForDB").text(installment);
    }
    
    function clearLabels() {
        $("#loanname").val("");
        $("#maxamount").val("");
        $("#interest").val("");        
        $("#basicpercentage").val("");
        $("#intallmentForDB").text("");
        $("#MinServicePeriod").val("");
        $("#MinLeaveBalance").val("");
        $("#RemainingService").val("");
        $("#isactive").attr('checked', false);
        $('#displayInstallment').html("");
        instDisp=0;
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
