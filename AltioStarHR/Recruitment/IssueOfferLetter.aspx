<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueOfferLetter.aspx.cs" Inherits="AltioStarHR.Recruitment.IssueOfferLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>Issue Offer Letter</title>
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
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
  <strong class="family1 imageheadercolor">Issue Offer Letter</strong>
    </div>
    </div>
    <div  style="margin-left:2%;" id="box">
        <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>
    <div id="divCTC" style="width:100%;padding-left:0%;background-color:White;display:none">
        <table style="width:100%;margin-left:1%;background-color:#a4cd0f">
            <tr>
                <td valign="top">
                    <fieldset>
                        <table  style="width:100%;margin-left:1%;background-color:#a4cd0f">
                            <tr>
                                <td class="family">Joining Date</td>
                                <td>
                                    <input id="txtjoining" name="txtjoining" type="text" tabindex="1" style="width: 183px;border:1px solid silver" disabled class="family"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="family">ESOP(Employee stock operation plan)</td>
                                <td>
                                    <input id="txtesop" name="txtesop" type="text" tabindex="1" style="width: 200px;border:1px solid silver" class="family"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="family">CTC(Yearly) <span style="font-size: medium; color: Red">*</span></td>
                                <td>
                                    <input type="text" name="txtctc" id="txtctc" tabindex="2" style="width: 200px;border:1px solid silver" class="family"
                                        onkeyup="return CalculateCTCDetails()" onkeypress=" return OnlyDecimalAllowed(event)"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="family">CTC(Monthly)</td>
                                <td>
                                    <input type="text" name="txtmonthlyctc" tabindex="3" id="txtmonthlyctc" style="width: 200px;border:1px solid silver" readonly   class="family"/>
                                </td>
                            </tr>                      
                    </table>
                    <table style="width:100%;margin-left:1%;background-color:#a4cd0f" >
                        <tr>
                            <td width="auto" valign="top">
                                <table style="width: 700px">
                                    <tr>
                                        <td width="200" height="40">
                                            <b class="family">ANNUAL</b> </td>
                                        <td width="200" height="40"></td>
                                        <td width="200" height="40"></td>
                                        <td width="200" height="40" class="family"> <b>MONTHLY</b></td> 
                                    </tr>            
                                    <tr>
                                        <td width="200" height="40" class="family">
                                            Annual Basic </td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtannualb" style="width: 150px;border:1px solid silver" readonly name="txtannualb" tabindex="4" class="family"/>
                                        </td>
                                        <td id="sannualb" width="200" height="40" class="family">
                                        </td>
                                        <td width="200" height="40" class="family">
                                            Monthly Basic </td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtmonthlyb" style="width: 150px;border:1px solid silver" readonly name="txtmonthlyb" tabindex="5" class="family"/>
                                        </td>
                                        <td id="smonthlyb" width="200" height="40" class="family">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="200" height="40" class="family">
                                            Annual HRA
                                        </td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtannualHRA" style="width: 150px;border:1px solid silver" readonly name="txtannualHRA" tabindex="6" class="family"/>
                                        </td>
                                        <td id="sannualHRA" width="200" height="40">
                                        </td>            
                                        <td width="200" height="40" class="family">
                                            Monthly HRA
                                        </td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtmonthlyHRA" style="width: 150px;border:1px solid silver" readonly name="txtmonthlyHRA" tabindex="7" class="family"/>
                                        </td>
                                        <td id="smonthlyHRA" width="200" height="40" class="family">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="200" height="40" class="family">
                                            Annual Special Allowance
                                        </td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtannualASA" style="width: 150px;border:1px solid silver" readonly name="txtannualASA" tabindex="8" class="family"/>
                                        </td>
                                        <td id="sannualASA" width="200" height="40" class="family">
                                        </td>                
                                        <td width="200" height="40" class="family">
                                            Monthly Special Allowance
                                        </td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtmonthlyMSA" style="width: 150px;border:1px solid silver" readonly name="txtmonthlyMSA" tabindex="9" class="family"/>
                                        </td>
                                        <td id="smonthlyMSA" width="200" height="40" class="family"></td>
                                    </tr>
                                    <tr>
                                        <td width="200" height="40" class="family">
                                            Annual Conveyance Allowance
                                        </td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtannualACA" style="width: 150px;border:1px solid silver" readonly name="txtannualACA" tabindex="10" class="family"/>
                                        </td>
                                        <td id="sannualACA" class="status" class="family">
                                        </td>
                                         <td width="200" height="40" class="family">
                                            Monthly Conveyance Allowance
                                        </td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtmonthlyMCA" style="width: 150px;border:1px solid silver" readonly name="txtmonthlyMCA" tabindex="11" class="family"/>
                                        </td>
                                        <td id="smonthlyMCA" class="status family">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="200" height="40" class="family">
                                            Annual PF
                                        </td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtannualPF" style="width: 150px;border:1px solid silver" readonly name="txtannualPF" tabindex="12" class="family"/>
                                        </td>
                                        <td id="sannualPF" width="200" height="40" class="family">
                                        </td>
                                        <td width="200" height="40" class="family">
                                            Monthly PF
                                        </td>
                                        <td width="200" height="40">
                                             <input type="text" id="txtmonthlyPF" style="width: 150px;border:1px solid silver" readonly name="txtmonthlyPF" tabindex="13" class="family"/>
                                        </td>
                                        <td id="smonthlyPF" width="200" height="40" class="family">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="family"> Annual Benefits</td>
                                    </tr>
                                    <tr>
                                        <td width="200" height="40" class="family">
                                            Leave Travel allowance= 
                                        </td>
                                        <td>
                                            <input id='txttravel' type="text" name="txttravel" style="width: 150px;border:1px solid silver" readonly class="family"/>
                                            <b class="family">(per month)</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="family"> Medical Reimbursement</td>
                                        <td width="200" height="40">
                                            <input type="text" id="txtannualbenefits" style="width: 150px;border:1px solid silver" readonly name="txtannualbenefits" tabindex="14" class="family"/>
                                        </td>
                                        <td id="sannualbenefits" width="200" height="40" class="family"></td>
                                    </tr>                                    
                                </table>
                                <table>
                                    <tr>
                                        <td colspan="4">
                                            <input id="btnSave5" name="Submit" type="button" value="Save" tabindex="15" 
                                                onclick="SaveCandidateSalaryDet()" class="family" style="background-color:#00DBF1;"/>
                                        </td>
                                         <td>
                                            <input id="btncancel" name="btncancel" type="button" value="Cancel" onclick="CloseFixSalaryDiv()" 
                                                class="family" style="background-color:#00DBF1;"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
            </fieldset>
            </td>
            </tr>
            <tr>
            </tr>
        </table>
    </div>
    <form id="frm1" runat="server">
        <input type="hidden" id="hdnLoggedUserID" runat="server" />
        <input type="hidden" id="hdnCA" runat="server" />
        <input type="hidden" id='hdnEmployeeID' runat="server" />
        <input type="hidden" id='hdnMedicalReimb' runat="server" />
    </form>
</body>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-1.6.2.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.16.custom.min.js") %>"> </script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/grid.locale-en.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.jqGrid.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Webutility.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/toolbar.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.core.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.widget.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.validate.js") %>"></script>

<script  type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.button.js") %>"></script>

<script type="text/javascript">


//    $(window).bind('resize', function() {
//        $("#list").setGridWidth($('#box').width() - 10, true);
//    }).trigger('resize');
    $(".ui-jqgrid-titlebar").hide();    
//   $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg.gif)');
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });   

    var mode = "";
    var activeStatus = true;
    jQuery(document).ready(function() { 

        $("#txtjoining").datepicker({
            showOn: "button",
            buttonImage: "Resources/Images/calendar.gif",
            buttonImageOnly: true,
            changeMonth: true,
            changeYear: true,
            minDate: 0
        });
        $("#txtjoining").datepicker("option", "dateFormat", 'dd/mm/yy');

        var myGrid = $('#list');

        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.GET_HIRED_CANDIDATE_GRID%>', '', true);

        Response.ResponseObject.colModel = [
            { name: 'firstname', index: 'firstname', width: 70, editable: true },
            { name: 'middlename', index: 'middlename', width: 70, editable: true },
            { name: 'lastname', index: 'modifiedby', width: 70, editable: true },
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'candidateid', index: 'candidateid', width: 100, editable: true, hidden: true },
            { name: 'joiningdate', index: 'joiningdate', width: 70, editable: true },
            { name: 'issueofferdate', index: 'issueofferdate', width: 70, editable: true },
            { name: 'ctc', index: 'ctc', width: 70, editable: true },
            { name: 'esop', index: 'esop', width: 70, editable: true },
            { name: 'candidatestatus', index: 'candidatestatus', width: 70, editable: true }
        ];

        Response.ResponseObject.caption = "Issue Offer Letter";
        Response.ResponseObject.ignoreCase = true;
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
        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        $("#t_list").append("<button type='button' id='fix' value='Fix Salary' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/fix_salary.png' height=18px;width=18px alt='' /><br/><div></div><span>Fix Salary</span></button>");
        $("#t_list").append("<button type='button' id='issue' value='Issue Offer Letter' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/issue_offer_letter.png' height=18px;width=18px alt='' /><br/><div></div><span>Issue Offer Letter</span></button>");
        
//        $("#t_list").append("<input type='button' id='fix' value='Fix Salary' style='font-size:12px;font-family:arial;margin:8px;'/> ");
//        $("#t_list").append("<input type='button' id='issue' value='Issue Offer Letter' style='font-size:12px;font-family:arial;margin:8px;'/> ");
        $("input,button", "#t_list").click(function(id) {
        
            if (id.currentTarget.id == "fix") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                if (id) {
                    document.getElementById('divCTC').style.display = "";
                    $('#divCTC').dialog({
                        height: 500,
                        width: 760,
                        modal: true,
                        title: "Fix Salary"
                    });
                    FillData();
                    CalculateCTCDetails();
                }
                else alert("Select candidate to Fix salary");
            }
            else if (id.currentTarget.id == "issue") {
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);
                if (id) {
                    if (ret.ctc == "0" && ret.joiningdate == "") {
                        alert('Cannot issue as salary is not fixed');
                        return;
                    }
                    window.location.href = "HTMLEditor/html-editor.htm?Candid=" + id + "&LetterType=OfferLetter" + "&file=";
                }
                else alert('Select candidate to issue offer letter');
            }
        });
    });

    function CalculateCTCDetails() {

        var ctc = $("#txtctc").val();
        var MedRei = $("#hdnMedicalReimb").val();
        
        if (ctc == "") return;
        var monthlyctc = eval(ctc) / 12;
        monthlyctc = Math.round(monthlyctc, 2);
        
        var yrlbasic = eval(ctc) * 40 / 100;
        yrlbasic = Math.round(yrlbasic, 2);
        
        var mnthbasic = eval(yrlbasic) / 12;
        mnthbasic = Math.round(mnthbasic, 2);
        
        var yrlyhra = eval(yrlbasic) * 40 / 100;
        yrlyhra = Math.round(yrlyhra, 2);
        
        var mnthhra = eval(yrlyhra) / 12;
        mnthhra = Math.round(mnthhra, 2);
        
        var CA = $("#hdnCA").val();
        var pf = eval(yrlbasic) * 12 / 100;
        pf = Math.round(pf, 2);
        
        var yrlallo = eval(ctc) - eval(yrlbasic) - eval(yrlyhra) - eval(CA) - eval(pf);
        yrlallo = Math.round(yrlallo, 2);

        var mnthca = CA / 12;
        mnthca = Math.round(mnthca, 2);
        
        var mnthpf = pf / 12;
        mnthpf = Math.round(mnthpf, 2);

        if (monthlyctc != NaN)
            $("#txtmonthlyctc").val(monthlyctc);
        if (yrlbasic != NaN)
            $("#txtannualb").val(yrlbasic);
        if (mnthbasic != NaN)
            $("#txtmonthlyb").val(mnthbasic);
        if (yrlyhra != NaN)
            $("#txtannualHRA").val(yrlyhra);
        if (mnthhra != NaN)
            $("#txtmonthlyHRA").val(mnthhra);
        if (yrlallo != NaN) {
            if (yrlallo < 0)
                $("#txtannualASA").val(0);
            else
                $("#txtannualASA").val(yrlallo - mnthbasic - MedRei);
        }
        
        var mntallow = $("#txtannualASA").val() / 12;
        mntallow = Math.round(mntallow, 2);
        
        if (mntallow != NaN) {
            if (mntallow < 0)
                $("#txtmonthlyMSA").val(0);
            else
                $("#txtmonthlyMSA").val(mntallow);
        }
        if (CA != NaN)
            $("#txtannualACA").val(CA);
        if (mnthca != NaN)
            $("#txtmonthlyMCA").val(mnthca);
        if (pf != NaN)
            $("#txtannualPF").val(pf);
        if (mnthpf != NaN)
            $("#txtmonthlyPF").val(mnthpf);

        $("#txtannualbenefits").val(MedRei);
        $("#txttravel").val(mnthbasic);
    }

    function FillData() {
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);

        $('#txtjoining').val(ret.joiningdate);
        $('#txtesop').val(ret.esop);
        $('#txtctc').val(ret.ctc);
    }

    function SaveCandidateSalaryDet() {
        if (validate()) {
            var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#list").jqGrid('getRowData', id);

            var Request = new Object();
            Request.ID = ret.id;
            Request.CandidateID = id;
            Request.JoiningDate = $("#txtjoining").val();
            Request.CTC = $('#txtctc').val();
            Request.ESOP = $('#txtesop').val();

            var Response = SendApplicationRequest('<%=RecruitmentAppCommands.UPDATE_CANDIDATE_SALARY%>', Request, true);
            alert(Response.Message);
            ReloadSalaryGrid();
            $('#divCTC').dialog('close');
        }
    }

    function OnlyDecimalAllowed(e) {
        try {
            var charact = (e.keyCode) ? e.keyCode : ((e.charCode) ? e.charCode : e.which);

            if (charact == 8 || charact == 46)

                return true;

            if (charact < 48 || charact > 57) {
                charact = 0;
                return false;
            }

            return true;
        }
        catch (e) {
            return false;
        }
    }

    function ReloadSalaryGrid() {
        var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
        
        var Response = SendApplicationRequest('<%=RecruitmentAppCommands.GET_HIRED_CANDIDATE_GRID%>', '', true);
        if (Response.ResponseObject.datastr == null)
            jQuery("#list").jqGrid('clearGridData');
        else {
            jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
            jQuery("#list").trigger('reloadGrid');
            jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
        }
    }

    function validate() {
        if ($("#txtjoining").val() == "") {
            alert('Please Enter Joining Date');
            return false;
            $("#txtjoining").focus();
        }
        else if ($("#txtctc").val() == "" || $("#txtctc").val() == 0){
            alert('Please Enter CTC');
            return false;
            $("#txtctc").focus();
        }
        return true
    }
    
    function CloseFixSalaryDiv()
    {
        $('#divCTC').dialog('close');
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
