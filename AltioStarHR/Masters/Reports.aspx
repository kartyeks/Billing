<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="AltioStarHR.Masters.Reports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-1.6.2.min.js") %>"></script>

    <script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.17.custom.min.js") %>"></script>

    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" media="screen" href="../Resources/css/datePicker.css" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
</head>
<body>
    <div style="position:relative;">
    <img alt="" src="Resources/Images/NewImages/1.png" style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
        <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
        <strong class="family1 imageheadercolor"><label id="lblHeader"></label></strong>
        </div>
    </div>
    <form id="signupForm" method="get" action="">
    
       
        <table style="width:97%;margin-left:2%;">
           <tr id='tbldates' style="display:none;">
           <td>
            <table style="background-color:#a4cd0f;width:100%" >
                <tr >
                    <td  class="family" style="width:0px">
                        <label id="lfromdate"  class="family" >
                             <b>From Date</b></label>
                        <span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td style="width:50px;padding-right:300px">
                        <input type="text" id="txtFromDate" style="width: 85px;" readonly="readonly" 
                            class="family" name="txtFromDate" />
                    </td>
                </tr>
                <tr >
                    <td class="family" >
                        <label id="Label12" class="family" >
                            <b>To Date</b> </label>
                        <span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td style="width:50px;padding-right:300px">
                        <input type="text" id="txtToDate" style="width: 85px" 
                            class="family" readonly="readonly" name="txtToDate" />
                    </td>
                </tr>
           </table>
           </td>
           </tr>
           
            <tr id='trAllLocations' >
                <td colspan="3">
                    <table style="width:100%;background-color:#a4cd0f">
                        <tr id='trTeam' style="display: none;">
                            <td style="width:100px;">
                            
                                <b style="margin-left:30px;">
                                    <label id="Label8" class="family">
                                        Select Team
                                    </label>
                                </b>
                            </td>
                            <td>
                                <select name="cmbteam" id="cmbteam" tabindex="1" style="width: 150px" class="family">
                                </select>
                            </td>
                            <td width="50px">
                            </td>
                        </tr>
                        <tr id='truser' style="display: none;">
                            <td style="width:100px;">
                                <b style="margin-left:30px;">
                                    <label id="Label1" class="family">
                                        Select User
                                    </label>
                                </b>
                            </td>
                            <td>
                                <select name="cmbuser" id="cmbuser" tabindex="2" style="width: 150px" class="family" >
                                </select>
                            </td>
                            <td width="50px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id='teamwiseemp' style="display: none;width:100%;background-color:#a4cd0f;">
                <td style="width:150px">
                    <b style="padding-left:33px">
                        <label id="Label2" class="family">
                            Team Name
                        </label>
                    </b>
                </td>
                <td>
                    <select name="cmbteam" id="cmbteams" tabindex="2" style="width: 150px" class="family">
                    </select>
                </td>
                <td width="50px">
                </td>
            </tr>
            
            <tr id='DOJ' style="display: none;" style="width:100%;background-color:#a4cd0f">
                <td style="width:80px">
                    <b>
                        <label id="Label7" style="width: auto" class="family">
                           Date Of Joining
                        </label>
                    </b>
                </td>
                 <td style="width:50px">
                    <input type="text" id="dojdate" style="width: 80px" readonly name="dojdate"  class="family"/>
                </td>
                <td id="sdojdate" width="100" height="40">
                </td>
            </tr>
            <tr id='assetcategory' style="display: none;width:100%;background-color:#a4cd0f;">
                <td style="width:150px">
                    <b style="margin-left:33px">
                        <label id="Label9" class="family" style="white-space:nowrap">
                           Asset Category
                        </label>
                    </b>
                </td>
                <td>
                    <select name="cmbasscategory" id="cmbasscategory" tabindex="2" style="width: 200px"
                         class="family">
                    </select>
                </td>
                <td width="50px">
                </td>
            </tr>
             <tr id='assetsubcategory' style="display: none;width:100%;background-color:#a4cd0f">
                <td style="width:150px">
                    <b style="padding-left:35px">
                        <label id="Label10" class="family" style="white-space:nowrap">
                           Asset Sub Category
                        </label>
                    </b>
                </td>
                <td>
                    <select name="cmbasssubcategory" id="cmbasssubcategory" tabindex="2" 
                        style="width: 200px" class="family">
                    </select>
                </td>
                <td width="50px">
                </td>
            </tr>
            
            <tr id='emptypes' style="display: none;width:100%;background-color:#a4cd0f" >
                <td style="width:150px">
                    <b style="padding-left:33px">
                        <label id="Label6" class="family" style="white-space:nowrap">
                            Employment Type
                        </label>
                    </b>
                </td>
                <td>
                    <select name="cmbemptype" id="cmbemptype" tabindex="2" style="width: 150px" class="family">
                    </select>
                </td>
                <td width="50px">
                </td>
            </tr>
            
             <tr id='empcode' style="display: none;width:100%;background-color:#a4cd0f" >
                <td style="width:150px">
                    <b style="padding-left:33px">
                        <label id="Label11" class="family" style="white-space:nowrap">
                            Employee Code
                        </label>
                    </b>
                </td>
                <td>
                    <input id="employeecode" name="employeecode" type="text" tabindex="1" 
                        style="width: 150px;border:1px solid silver" class="family"/>
                </td>
                <td width="50px">
                </td>
            </tr>
            
            
            <tr id="trleave" style="display: none;width:100%;background-color:#a4cd0f">
                <td id="tdteam" style="display: none;width:130px ">
                    <label id="Label3" style="width: auto;white-space:nowrap;padding-left:33px" class="family">
                        <b>Team Name</b>
                    </label>
                </td >
                 <td id="tdteaminput" style="display: none;width:120px">
                    <select name="cmbteam" id="cmbteamname" name="cmbteamname" style="width: 200px" 
                        class="family">
                    </select>
                </td>
                <td id="tdfromdate" style="display: none;width:120px">
                    <label id="Label4" style="width: auto;padding-left:33px" class="family">
                        <b>From Date</b>
                    </label>
                </td>
                <td id="tdfromdatetext" style="display: none;width:120px">
                    <input type="text" id="fromdate" style="width: 80px" readonly 
                        name="fromdate"  class="family"/>
                </td>
                <td id="tdtodate" style="display: none;width:80px">
                    <label id="Label5" style="width: auto" class="family">
                        <b>To Date</b>
                    </label>
                </td>
                <td id="tdtodatetext" style="display: none"> 
                    <input type="text" id="todate" style="width: 80px" readonly name="todate" 
                        class="family"/>
                </td>
            </tr>
        </table>
        
        <table style="margin-left:25px">
            <tr align="center">
                <td class="field">
                    <input id="btnGenerate" name="Generate" type="button" value="Generate" 
                        onclick="return onGenerate();" />
                </td>
            </tr>
        </table>
    
    <input id='hdnReportType' type="hidden" runat="server" />
    <input id='hdnHeader' type="hidden" runat="server" />
    <input id='hdnMode' type="hidden" runat="server" />
    </form>
</body>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.16.custom.min.js") %>"></script>

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
    jQuery(document).ready(function() {
        $("#lblHeader").text($("#hdnHeader").val());
        $(function() {
            $("#fromdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
            }).change(function() {
                $("#fromdate").valid();
            });
            $("#fromdate").datepicker("option", "dateFormat", 'dd/mm/yy');
        });

        $(function() {
            $("#todate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
            }).change(function() {
                $("#todate").valid();
            });
            $("#todate").datepicker("option", "dateFormat", 'dd/mm/yy');
        });

        $(function() {
            $("#dojdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
            }).change(function() {
                $("#dojdate").valid();
            });
            $("#dojdate").datepicker("option", "dateFormat", 'dd/mm/yy');
        });
        $(function() {
        $("#txtFromDate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
            }).change(function() {
            $("#txtFromDate").valid();
            });
            $("#txtFromDate").datepicker("option", "dateFormat", 'dd/mm/yy');
        });

        $(function() {
        $("#txtToDate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
            }).change(function() {
            $("#txtToDate").valid();
            });
            $("#txtToDate").datepicker("option", "dateFormat", 'dd/mm/yy');
        });

        LoadEmployees();
        LoadTeam();
        LoadTeamsforEmployee();

        if (document.getElementById("hdnReportType").value == "rdlcAssetAssignTeamWise") {
            document.getElementById("trTeam").style.display = "";
        }
        else if (document.getElementById("hdnReportType").value == "rdlcAssetAssignUserWise") {
            document.getElementById("truser").style.display = "";
        }
        else if (document.getElementById("hdnReportType").value == "rdlcTeamwiseEmployee") {
            document.getElementById("teamwiseemp").style.display = "";
        }
        else if (document.getElementById("hdnReportType").value == "rdlcEmployeeType") {

            document.getElementById("emptypes").style.display = "";
            LoadEmptype();
        }
         else if (document.getElementById("hdnReportType").value == "rdlcEmployeeDetails") {
             document.getElementById("empcode").style.display = "";
        }
        else if (document.getElementById("hdnReportType").value == "rdlcAllEmployeeDetails") {
             document.getElementById("empcode").style.display = "none";
        }
        else if (document.getElementById("hdnReportType").value == "rdlcJoiningType") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "none";
            document.getElementById("tdteaminput").style.display = "none";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";
            //LoadTeamFORLeave();
        }
        else if (document.getElementById("hdnReportType").value == "rdlcAssetCategory") {
     
            if (document.getElementById("hdnMode").value == "assetcategory") {
                document.getElementById("assetcategory").style.display = "";
                LoadAsset();
            }
            else if (document.getElementById("hdnMode").value == "assetsubcategory") {
            
                document.getElementById("assetsubcategory").style.display = "";
                LoadAssetSub();
            }
            else if (document.getElementById("hdnMode").value == "allassets") {
                document.getElementById("assetsubcategory").style.display = "none";
            }
        }
        else if (document.getElementById("hdnReportType").value == "rdlcLeaveBalance") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "";
            document.getElementById("tdteaminput").style.display = "";
            document.getElementById("tdfromdate").style.display = "none";
            document.getElementById("tdfromdatetext").style.display = "none";
            document.getElementById("tdtodate").style.display = "none";
            document.getElementById("tdtodatetext").style.display = "none";
            LoadTeamFORLeave();
        }
        else if (document.getElementById("hdnReportType").value == "rdlcLeaveRequest") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "";
            document.getElementById("tdteaminput").style.display = "";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";
            LoadTeamFORLeave();
        }
        else if (document.getElementById("hdnReportType").value == "rdlcWorkFromHome") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "";
            document.getElementById("tdteaminput").style.display = "";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";
            LoadTeamFORLeave();
        }
        else if (document.getElementById("hdnReportType").value == "rdlcEmpActivityLeave") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "";
            document.getElementById("tdteaminput").style.display = "";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";
            LoadTeamFORLeave();
        }
        else if (document.getElementById("hdnReportType").value == "rdlcResignationExitManagementReport") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "none";
            document.getElementById("tdteaminput").style.display = "none";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";
        }
        else if (document.getElementById("hdnReportType").value == "rdlcTerminationExitManagementReport") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "none";
            document.getElementById("tdteaminput").style.display = "none";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";

        }
        else if (document.getElementById("hdnReportType").value == "rdlcTeamWiseExitManagementReport") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "";
            document.getElementById("tdteaminput").style.display = "";
            document.getElementById("tdfromdate").style.display = "none";
            document.getElementById("tdfromdatetext").style.display = "none";
            document.getElementById("tdtodate").style.display = "none";
            document.getElementById("tdtodatetext").style.display = "none";
            LoadTeamFORLeave();
        }
        else if (document.getElementById("hdnReportType").value == "rdlcPromotionReport" ||
                 document.getElementById("hdnReportType").value == "rdlcSalaryHikeReport") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "";
            document.getElementById("tdteaminput").style.display = "";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";
            LoadTeamFORLeave();
        }
        else if (document.getElementById("hdnReportType").value == "rdlcOutgoingAssets") {
         document.getElementById("tbldates").style.display = "";
       }
       else if (document.getElementById("hdnReportType").value == "rdlcCandidateDetailsbyConsultant") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "none";
            document.getElementById("tdteaminput").style.display = "none";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";

        }
        else if (document.getElementById("hdnReportType").value == "rdlcCandidateDetailsbyReferral") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "none";
            document.getElementById("tdteaminput").style.display = "none";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";

        }
        else if (document.getElementById("hdnReportType").value == "rdlcCandidateInterviewDetailsReport") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "none";
            document.getElementById("tdteaminput").style.display = "none";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";

        }
        else if (document.getElementById("hdnReportType").value == "rdlcOfferLetterIssuedReport") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "none";
            document.getElementById("tdteaminput").style.display = "none";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";

        }
        else if (document.getElementById("hdnReportType").value == "rdlcShortlistedCandidateApplicationDetails") {
            document.getElementById("trleave").style.display = "";
            document.getElementById("tdteam").style.display = "none";
            document.getElementById("tdteaminput").style.display = "none";
            document.getElementById("tdfromdate").style.display = "";
            document.getElementById("tdfromdatetext").style.display = "";
            document.getElementById("tdtodate").style.display = "";
            document.getElementById("tdtodatetext").style.display = "";

        }

    });
     function onGenerate() {
     debugger
         var srtype = document.getElementById("hdnReportType").value;
         var strQr = '';
         var fromdate;
         var todate;
         var dojdate;
         var cmbteamname;
         switch (srtype) {

             case "rdlcAssetAssignTeamWise":
//                if($("#cmbteam").val() == "0")
//                {
//                    alert('Please Select Team');
//                    return;
//                }
                 strQr = "rtype=" + srtype + "&isteam=1&teamid=" + $("#cmbteam").val();
                 break;
             case "rdlcAssetAssignUserWise":
//              if($("#cmbuser").val() == "0")
//                {
//                    alert('Please Select User');
//                    return;
//                }
                 strQr = "rtype=" + srtype + "&isteam=0&teamid=" + $("#cmbuser").val();
                 break;
             case "rdlcOutgoingAssets":
                 if (!CompareDateForReport($("#txtFromDate").val(), $("#txtToDate").val())) { return; }
                 var fromdate = $("#txtFromDate").val();
                 var todate = $("#txtToDate").val();
                 strQr = "rtype=" + srtype + "&fromDate=" + fromdate + "&toDate=" + todate;
                 break;
             case "rdlcExitEmployment":
                 strQr = "rtype=" + srtype;
                 break;
             case "rdlcTeamwiseEmployee":
//             if($("#cmbteams").val() == "0")
//                {
//                
//                    alert('Please Select Team');
//                    return;
//                }
                 strQr = "rtype=" + srtype + "&teamid=" + $("#cmbteams").val();
                 break;
             case "rdlcJoiningType":
                 if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                 strQr = "rtype=" + srtype + "&fromdate=" + $("#fromdate").val() + "&todate=" + $("#todate").val();
                 break; 
             case "rdlcEmployeeType":
             if($("#cmbemptype").val() == "")
                {
                    alert('Please Select Employee Type');
                    return;
                }
                 strQr = "rtype=" + srtype +"&cmbemptype="+ $("#cmbemptype option:selected").text();
                 break; 
                  
             case "rdlcEmployeeDetails":
             if($("#employeecode").val() == "")
                {
                    alert('Please Enter Employee Code');
                    return;
                }
                 strQr = "rtype=" + srtype +"&employeecode="+ $("#employeecode").val();
                 break;        
                  
                  
             case "rdlcAllEmployeeDetails":
             
                 strQr = "rtype=" + srtype;
                 break;    
                 
                      
            case "rdlcAssetCategory":
                if(document.getElementById("hdnMode").value =="assetcategory")
                { 
                    if($("#cmbasscategory").val() == "")
                    {
                        alert('Please Select Asset Category');
                        return;
                    }
                    strQr = "rtype=" + srtype + "&assetcategory=" + $("#cmbasscategory").val() + "&rHeader=Asset Category Report";
                }
                else if (document.getElementById("hdnMode").value == "assetsubcategory") {    
                    
                    if($("#cmbasssubcategory").val() == "")
                    {
                        alert('Please Select Asset Subcategory');
                        return;
                    }
                    strQr = "rtype=" + srtype + "&assetsubcategory=" + $("#cmbasssubcategory").val() + "&rHeader=Asset Subcategory Report";
                }
                else if(document.getElementById("hdnMode").value =="allassets")
                {
                    strQr = "rtype=" + srtype + "&rHeader=All Assets Report";
                }
                
           break;  
             case "rdlcLeaveBalance":
                cmbteamname = $("#cmbteamname").val();
                strQr = "rtype=" + srtype + "&teamid=" + $("#cmbteamname").val();
                break; 
           case "rdlcLeaveRequest":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                //if ($("#cmbteamname").val() == "0") { alert("Select Team Name"); return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                cmbteamname = $("#cmbteamname").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate + "&teamid=" + $("#cmbteamname").val();
                break; 
            case "rdlcWorkFromHome":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                //if ($("#cmbteamname").val() == "0") { alert("Select Team Name"); return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                cmbteamname = $("#cmbteamname").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate + "&teamid=" + $("#cmbteamname").val();
                break; 
           case "rdlcEmpActivityLeave":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                cmbteamname = $("#cmbteamname").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate + "&teamid=" + $("#cmbteamname").val();
                break; 
                
           case "rdlcResignationExitManagementReport":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate;
                break; 
                
          case "rdlcTerminationExitManagementReport":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate;
                break;                 
         case "rdlcTeamWiseExitManagementReport":
                //if ($("#cmbteamname").val() == "0") { alert("Select Team Name"); return; }
                 
                cmbteamname = $("#cmbteamname").val();
                strQr = "rtype=" + srtype + "&teamid=" + $("#cmbteamname").val();
                break;
         case "rdlcPromotionReport":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                //if ($("#cmbteamname").val() == "0") { alert("Select Team Name"); return; }
                strQr = "rtype=" + srtype + "&teamid=" + $("#cmbteamname").val() + "&fromdate=" + $("#fromdate").val() + "&todate=" + $("#todate").val();
                break; 
         
         case "rdlcSalaryHikeReport":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                //if ($("#cmbteamname").val() == "0") { alert("Select Team Name"); return; }
                strQr = "rtype=" + srtype + "&teamid=" + $("#cmbteamname").val() + "&fromdate=" + $("#fromdate").val() + "&todate=" + $("#todate").val();
                break; 
                
        case "rdlcCandidateDetailsbyConsultant":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate;
                break; 
                
        case "rdlcCandidateDetailsbyReferral":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate;
                break; 
                
        case "rdlcCandidateInterviewDetailsReport":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate;
                break; 
                
        case "rdlcOfferLetterIssuedReport":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate;
                break; 
                
        case "rdlcShortlistedCandidateApplicationDetails":
                if (!CompareDateForReport($("#fromdate").val(), $("#todate").val())) { return; }
                fromdate = $("#fromdate").val();
                todate = $("#todate").val();
                strQr = "rtype=" + srtype + "&fromdate=" + fromdate + "&todate=" + todate;
                break; 
         
        }
         

         var qrystr = "default.aspx?serve=rdlcReportViewer&" + strQr;
         var ret = window.showModalDialog(qrystr, window.self, "dialogHeight:750px; dialogWidth:1000px; resizable:yes; status:no;");
         if (ret == 'nodata') {
             alert('No Data to generate Report');
         }
     }

     function LoadTeam() {

         var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_COMBO_DETAILS%>", "");
         var optn = document.createElement("OPTION");
         optn.text = "All Team";
         optn.value = "0";
         document.getElementById('cmbteam').options.add(optn);
         if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
             var arr = Response.ResponseObject;

             for (var i = 0; i < arr.length; ++i) {
                 var optn = document.createElement("OPTION");
                 optn.text = arr[i]['Value'];
                 optn.value = arr[i]['ID'];
                 document.getElementById('cmbteam').options.add(optn);
             }
         }
     }
     function LoadTeamsforEmployee() {

         var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_COMBO_DETAILS%>", "");
         var optn = document.createElement("OPTION");
         optn.text = "All Team";
         optn.value = "0";
         document.getElementById('cmbteams').options.add(optn);
         if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
             var arr = Response.ResponseObject;

             for (var i = 0; i < arr.length; ++i) {
                 var optn = document.createElement("OPTION");
                 optn.text = arr[i]['Value'];
                 optn.value = arr[i]['ID'];
                 document.getElementById('cmbteams').options.add(optn);
             }
         }
     }
      function LoadAsset() {
        var Response = SendApplicationRequest("<%=HRAppCommands.ASSET_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Select Asset Category";
        optn.value = "";
        document.getElementById('cmbasscategory').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['AssetCategories'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbasscategory').options.add(optn);
            }
        }
    }
      function LoadEmptype() {
      
        var Response = SendApplicationRequest("<%=HRAppCommands.COMBOEMPTYPE_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Select Employee Type";
        optn.value = "";
        document.getElementById('cmbemptype').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['Name'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbemptype').options.add(optn);
            }
        }
    }
    
    function LoadAssetSub() {
    
        var Response = SendApplicationRequest("<%=HRAppCommands.ASSETSUB_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Select Asset Sub Category";
        optn.value = "";
        document.getElementById('cmbasssubcategory').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['AssetSubCategories'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbasssubcategory').options.add(optn);
            }
        }
    }
     function LoadTeamFORLeave() {
         var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_COMBO_DETAILS%>", "");
         var optn = document.createElement("OPTION");
         optn.text = "All";
         optn.value = "0";
         document.getElementById('cmbteamname').options.add(optn);
         if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
             var arr = Response.ResponseObject;

             for (var i = 0; i < arr.length; ++i) {
                 var optn = document.createElement("OPTION");
                 optn.text = arr[i]['Value'];
                 optn.value = arr[i]['ID'];
                 document.getElementById('cmbteamname').options.add(optn);
             }
         }
     }

     function LoadEmployees() {
         var Response = SendApplicationRequest("<%=HRAppCommands.MANAGER_COMBO_DETAILS%>", "");
         var optn = document.createElement("OPTION");
         optn.text = "All User";
         optn.value = "0";
         document.getElementById('cmbuser').options.add(optn);
         if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
             var arr = Response.ResponseObject;
             for (var i = 0; i < arr.length; ++i) { 
                 var optn = document.createElement("OPTION");
                 optn.text = arr[i]['Value'];
                 optn.value = arr[i]['ID'];
                 document.getElementById('cmbuser').options.add(optn);
             }
         }
     }
   
</script>

</html>
