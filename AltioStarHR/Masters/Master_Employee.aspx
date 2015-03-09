<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Master_Employee.aspx.cs"
    Inherits="AltioStarHR.Masters.Master_Employee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <link href="../Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" media="screen" href="../Resources/css/datePicker.css" />
    <link type="text/css" rel="stylesheet" href="../Resources/css/ajaxfileupload.css" />
    
    <style type="text/css">
        #sidebar
        {
            width: 180px; 
            float: left;
            margin: 0 17px 0 0;
            min-height: 300px;
            height: 410px;
        }
        #sidebar #sidenav
        {
            margin: 8px 0 0 0;
            padding: 7px;
            background: #5F9EA0 url(../images/sidebar-nav-bg.png) repeat-y top right;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }
        #sidebar #sidenav a
        {
            color: #fff;
            display: block;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            padding: 7px 7px;
            width: 140px;
            margin-left:-8px;
            text-decoration: none;
            margin-bottom: 5px;
           /* border-bottom: 1px solid #2E2E2E;*/
        }
        #sidebar #sidenav a:hover
        {
            /*background-color: #2E2E2E;*/
            background-color:#ACFA58;
        }
        #sidebar #sidenav a.disabled
        {
            background-color: #CE6D1D;
        }
        #sidebar #sidenav .selected a
        {
            background-color: #555657;
            color: #fff;
            border-bottom: none;
        }
        ul
        {
            list-style: none;
        }
        #eduyear_1
        {
            width: 88px;
        }
        #edupercentage_1
        {
            width: 88px;
        }
        #eduname_1
        {
            width: 95px;
        }
        #edustream_1
        {
            width: 74px;
        }
        #educollege_1
        {
            width: 88px;
        }
        #content
        {
            padding-top: 35px;
            width:75%;
        }
        div
        {
            display: block;
        }
    </style>
    <base target='_self' />
</head>
<body targetpage="self" thispage='Master_Employee.aspx'>
    <div id="sidebar">
        <div id="photo" style="display: none;">
            <%--<table style="width: 100px; background-color: #00daf5" border="5">--%>
            <table style="width: 100px; background-color:Red;margin-left:0%;margin-top:10%" border="5">
                <tr>
                    <td>
                        <div id="dvImgPhoto" align="center" style="background-color: #00daf5">
                        
                            <img alt="" id="imgPhoto" width="100" height="100" runat="server" onclick="return onClickload();" /></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id='btnUpload' type="button" runat="server" onclick="Upload();" value="Upload Photo" />
                    </td>
                </tr>
            </table>
        </div>
        <ul id="sidenav" style="background-color: #00daf5;margin-left:0%">
            <li><a class="show " target="1" style="font-family:Arial;font-size:11px;color:Black;">Employee Personal Details</a><br />
                <a class="show " target="2" style="font-family:Arial;font-size:11px;color:Black;">Occupational Details</a><br />
                <a class="show" target="3" style="font-family:Arial;font-size:11px;color:Black;">Education Details</a><br />
                <a class="show " target="4" style="font-family:Arial;font-size:11px;color:Black;">Career Summary</a><br />
                <a class="show " target="5" style="font-family:Arial;font-size:11px;color:Black;">AltioStar CTC</a><br />
                <%--  <a  class="show" target="6">Exit Employee Report</a><br />--%>
                <a class="show " target="7" style="font-family:Arial;font-size:11px;color:Black;">Document Upload</a><br />
                <%--  <a  class="hide" >HIDEALL</a>--%>
                <a id='bck' class="show " target="8" style="font-family:Arial;font-size:11px;color:Black;">Back</a><br />
            </li>
        </ul>
    </div>
    <div id="content">
        <table style="width: 100%;">
            <tr style="width: 100%">
                <td colspan="2">
                    <input id="TXTEMPLOYEEID" disabled runat="server" style="display: none;" class="family" />
                </td>
            </tr>
            <tr style="width: 50%">
                <td style="width: 45%;">
                    <label id='txtid1' class="family" style="white-space: nowrap;">
                        <b  style="font-size:15px;color:#07DAF7;font-family:Arial">Employee Code :</b></label><label id='txtid' runat="server" 
                            style="white-space: nowrap;font-family:Arial;font-size:13px"></label>
                </td>
                <td style="width: 50%;">
                    <label id='txtName1' style="white-space: nowrap;">
                        <b style="font-size:15px;color:#07DAF7;font-family:Arial">Employee Name :</b></label><label id='txtName' runat="server" 
                            style="white-space: nowrap;font-family:Arial;font-size:13px"></label>
                </td>
            </tr>
        </table>
        <div id="div1" class="targetDiv">
            <%--<h1>Employee Details</h1>--%>
            <div style="position: relative; margin-left: 0%;">
                <img alt="" src="Resources/Images/NewImages/1.png" style="width: 100%; height: 53px" />
                <div style="position: absolute; left: 2%; top: 52%;">
                    <strong class="family1 imageheadercolor">Employee Personal Details</strong>
                </div>
            </div>
            <form id="frmpersonaldetails" action="">
            <table style="width: 100%; background-color: #a4cd0f">
                <%--<tr>
                    <td width="auto" valign="top">
                        <table style="width: 700px">--%>
                <tr>
                    <td width="100" height="40" class="family">
                        Employee Code
                    </td>
                    <td width="100" height="40">
                        <input id="txtEmpNo" style="width: 150px" name="txtEmpNo" disabled="disabled" type="text"
                            tabindex="1" />
                    </td>
                    <td width="100" height="40"></td>
                    <td width="100" height="40" class="family">
                        Type of Employee<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td width="100" height="40">
                        <select name="cmbemptype" id="cmbemptype" tabindex="2" style="width: 150px" class="family">
                        </select>
                    </td>
                <td  height="100%" id="scmbemptype"></td>
                </tr>
                <tr>
                    <td width="100" height="40" class="family">
                        First Name<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td width="100" height="40">
                        <input id="txtFirstname" style="width: 150px" name="txtFirstname" type="text" tabindex="3" />
                    </td>
                <td  id="stxtFirstname"></td>
                    <td width="100" height="40" class="family">
                        Middle Name
                    </td>
                    <td width="100" height="40">
                        <input id="txtMiddlename" name="txtMiddlename" style="width: 150px" type="text" tabindex="4" />
                    </td>
                <td  id="stxtMiddlename"></td>
                </tr>
               
                <tr>
                    <td width="100" height="40" class="family">
                        Last Name<span style="font-size: medium; color: Red">*</span>
                    </td>
                    
                    <td width="100" height="40">
                        <input id="txtLastName" name="txtLastName" style="width: 150px" type="text" tabindex="5" />
                    </td>
                   <td  id="stxtLastName"></td>
                    <td width="100" height="40" class="family">
                        Personal EmailID<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td width="100" height="40">
                        <input id="txtpersonalemail" style="width: 150px" name="txtpersonalemail" type="text"
                            tabindex="6" />
                    </td>
                <td  id="stxtpersonalemail"></td>
                </tr>
                
                <tr>
                    <td width="100" height="40" class="family">
                        Date of Birth<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td width="100" height="40">
                        <input type="text" id="DOBdatepicker" style="width: 135px" readonly name="DOBdatepicker"
                            tabindex="7" />
                    </td>
                <td id="sDOBdatepicker"></td>
                    <td width="100" height="40" class="family">
                        Gender<span style="font-size: medium; color: Red">*</span>
                    </td>
                    
                    <td>
                        <label>
                            <input type="radio" name="mygender" checked value="radio" id="rdoMale" tabindex="8" />
                            <b>Male</b></label>
                        <label style="width: 150px;">
                            <input type="radio" name="mygender" value="radio" id="rdoFemale" tabindex="9" />
                            <b>Female</b></label>
                    </td>
                <td  id="smygender"></td>
                </tr>
                
                <tr>
                    <td width="100" height="40" class="family">
                        Marital Status<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td width="100" height="40">
                        <select name="cmbmaritalstatus" id="cmbmaritalstatus" tabindex="10" style="width: 150px"
                            class="family">
                        </select>
                    </td>
                <td id="scmbmaritalstatus"></td>
                    <td width="100" height="40" class="family">
                        Permanent Address<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td>
                        <textarea name="txtPAddress" id="txtPAddress" rows="3" cols="25" tabindex="11" runat="server"
                            style="width: 150px"></textarea>
                    </td>
                <td  id="stxtPAddress"></td>
                </tr>
               
                <tr id="trCAddress">
                    <td width="100" height="40" class="family">
                        Current Address<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td width="100" height="40">
                        <textarea name="txtCAddress" id="txtCAddress" rows="3" cols="25" tabindex="12" runat="server"
                            style="width: 150px"></textarea>
                    </td>
                <td  id="stxtCAddress"></td>
                    <td width="100" height="40" class="family">
                        Mobile Number<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td width="100" height="40">
                        <input id="txtmobile" style="width: 150px" name="txtmobile" type="text" tabindex="13"
                            maxlength="11" />
                    </td>
                <td  id="stxtmobile"></td>
                </tr>
               
                <tr>
                    <td width="100" height="40" class="family">
                        Residence Number
                    </td>
                    <td width="100" height="40">
                        <input id="txtresidno" style="width: 150px" name="txtresidno" type="text" tabindex="14" />
                    </td>
                <td  id="stxtresidno"></td>
                    <td width="100" height="40" class="family">
                        Emergency Contact<br /> Number<span style="font-size: medium; color: Red">*</span>
                    </td>
                    <td width="100" height="40" style="white-space: nowrap">
                        <input id="txtemergno" name="txtemergno" style="width: 150px" type="text" tabindex="15"
                            maxlength="11" />
                    </td>
                <td id="stxtemergno"></td>
                </tr>
               
                <%--</table>
                    </td>
                </tr>--%>
            </table>
            <br />
            <table>
                <tr>
                    <td colspan="4" class="family">
                        <input id="btnSave1" name="Submit" type="submit" value="Save" tabindex="16" />
                    </td>
                </tr>
            </table>
            <input type="hidden" id='hdnPhoto' runat="server" />
            <input type="hidden" id='hdnEmpPersonalTab' runat="server" />
            <input id='hdnEmployeeID' runat="server" type="hidden" />
            <input id='hdnLoggedinID' runat="server" type="hidden" />
            <input id='hdnType' runat="server" type="hidden" />
            </form>
        </div>
        <div id="div2" class="targetDiv">
            <%--<h1>Occupational Details</h1>--%>
            <div style="position: relative; margin-left: 0%;">
                <img alt="" src="Resources/Images/NewImages/1.png" style="width: 100%; height: 53px" />
                <div style="position: absolute; left: 2%; top: 52%;">
                    <strong class="family1 imageheadercolor">Occupational Details</strong>
                </div>
            </div>
            <form id="OccupationForm" action="">
            <table  style="width: 100%; background-color: #a4cd0f">
                <tr>
                    <td width="auto" valign="top">
                        <table style="width: 730px">
                            <tr>
                                <td width="200" height="40" class="family">
                                    Country <span style="font-size: medium; color: Red">*</span>
                                </td>
                                <td width="200" height="40">
                                    <select name="cmbcountry" id="cmbcountry" tabindex="1" style="width: 200px" onchange="return LoadLocation();"
                                        class="family">
                                    </select>
                                </td>
                                <td id="scmbcountry" width="200" height="40">
                                </td>
                                <td width="200" height="40" class="family">
                                    Location <span style="font-size: medium; color: Red">*</span>
                                </td>
                                <td width="200" height="40">
                                    <select name="cmblocation" id="cmblocation" tabindex="2" style="width: 200px" class="family">
                                    </select>
                                </td>
                                <td id="scmblocation" width="200" height="40">
                                </td>
                            </tr>
                            <tr>
                                <td width="200" height="40" class="family">
                                    Joining Date<span style="font-size: medium; color: Red">*</span>
                                </td>
                                <td width="200" height="40">
                                    <input type="text" id="txtjoiningdate" tabindex="3" style="width: 180px" readonly
                                        onchange="return OnChangeLeaveCount();" name="txtjoiningdate" />
                                </td>
                                <td id="stxtjoiningdate" width="200" height="40">
                                </td>
                                <td width="200" height="40" class="family">
                                    Official Email Address
                                </td>
                                <td width="200" height="40">
                                    <input type="text" id="txtemailid" style="width: 200px" name="txtemailid" tabindex="6" />
                                </td>
                                <td id="stxtemailid" width="200" height="40">
                                </td>
                            </tr>
                            <tr>
                                <td width="200" height="40" class="family">
                                    Type of Exit
                                </td>
                                <td width="200" height="40" class="family">
                                    <select name="cmbtypeofexit" id="cmbtypeofexit" tabindex="5" style="width: 200px"
                                        onchange="return OnExitChange();" class="family">
                                        <option value="">Select Type Of Exit</option>
                                        <option value="1">Resigned</option>
                                        <option value="2">Terminated</option>
                                    </select>
                                </td>
                                <td id="scmbtypeofexit" width="200" height="40">
                                </td>
                                <td width="200" height="40" class="family">
                                    Exit Date
                                </td>
                                <td width="200" height="40">
                                    <input type="text" id="txtexitdate" tabindex="4" style="width: 180px" disabled name="txtexitdate" />
                                </td>
                                <td id="stxtexitdate" width="200" height="40">
                                </td>
                            </tr>
                            <tr>
                                <td width="200" height="40" class="family">
                                    Leaves
                                </td>
                                <td width="200" height="40">
                                    <input type="text" id="txtleaves" style="width: 200px" readonly name="txtleaves"
                                        tabindex="7" />
                                </td>
                                <td id="stxtleaves" class="status">
                                </td>
                            </tr>
                            <tr>
                                <td width="200" height="40" class="family">
                                    Team<span style="font-size: medium; color: Red">*</span>
                                </td>
                                <td width="200" height="40">
                                    <select name="cmbteam" id="cmbteam" tabindex="8" style="width: 200px" onchange="onTeamChange();"
                                        class="family" >
                                    </select>
                                </td>
                                <td id="scmbteam" width="200" height="40">
                                </td>
                                <td width="200" height="40" class="family">
                                    Manager Name
                                </td>
                                <td width="200" height="40">
                                    <input type="text" id="txtmanagername" style="width: 200px" readonly name="txtmanagername"
                                        tabindex="9" />
                                </td>
                                <td id="stxtmanagername" width="200" height="40">
                                </td>
                            </tr>
                            <tr>
                                <td width="200" height="40">
                                    Designation<span style="font-size: medium; color: Red">*</span>
                                </td>
                                <td width="200" height="40">
                                    <select name="cmbdesignation" id="cmbdesignation" tabindex="10" style="width: 200px"
                                        class="family">
                                    </select>
                                </td>
                                <td id="scmbdesignation" width="200" height="40">
                                </td>
                                <td width="200" height="40">
                                    Username<span style="font-size: medium; color: Red">*</span>
                                </td>
                                <td width="200" height="40">
                                    <input type="text" id="txtUsername" style="width: 200px" name="txtUsername" />
                                </td>
                                <td id="stxtUsername" width="200" height="40">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan="4">
                        <input id="btnSave2" name="Submit" type="submit" value="Save" tabindex="11" />
                    </td>
                </tr>
            </table>
            <input type="hidden" id='hdnEmpOccupationalTab' runat="server" />
            <input type="hidden" id='hdnOccupID' runat="server" />
            <input id='hdnLeaveCount' type="hidden" runat="server" />
            <input id='hdnFinancialMonth' type="hidden" runat="server" />
            <input id='hdnFinancialYear' type="hidden" runat="server" />
            </form>
        </div>
        <div id="div3" class="targetDiv">
            <%--<h1>Education Details</h1>--%>
            <div style="position: relative; margin-left: 0%;">
                <img alt="" src="Resources/Images/NewImages/1.png" style="width:100%; height: 53px" />
                <div style="position: absolute; left: 2%; top: 52%;">
                    <strong class="family1 imageheadercolor">Education Details</strong>
                </div>
            </div>
            <form id="frmeducation" action="" enctype="multipart/form-data">
            <div id='dialogAcademicDetails' style="display: none;">
                <table  style="width: 100%; background-color: #a4cd0f">
                    <tr>
                        <td width="20%" height="40" class="family">
                            Education<span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td width="20%" height="40">
                            <input id="txteducation" style="width: 150px" name="txteducation" type="text" tabindex="1" />
                        </td>
                        <td id="stxteducation" width="200" height="40">
                        </td>
                        <td width="20%" height="40" class="family">
                            Stream<span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td width="20%" height="40">
                            <input id="txtstream" style="width: 150px" name="txtstream" type="text" tabindex="2" />
                        </td>
                        <td id="stxtstream" width="20%" height="40">
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" height="40" class="family">
                            University/College<span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td width="20%" height="40">
                            <input id="txtuniversity" style="width: 150px" name="txtuniversity" type="text" tabindex="3" />
                        </td>
                        <td id="stxtuniversity" width="200" height="40">
                        </td>
                        <td width="20%" height="40" class="family">
                            Year<span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td width="20%" height="40">
                            <input id="txtyear" style="width: 150px" name="txtyear" maxlength="4" type="text"
                                tabindex="4" />
                        </td>
                        <td id="stxtyear" width="20%" height="40">
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" height="40" class="family">
                            Percentage<span style="font-size: medium; color: Red">*</span>
                        </td>
                        <td width="200" height="40">
                            <input id="txtpercentage" style="width: 150px" name="txtpercentage" type="text" tabindex="5" />
                        </td><td>%</td>
                        <td id="stxtpercentage" width="20%" height="40">
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td colspan="4">
                            <input id="btnAddAcademic" name="Save" type="submit" tabindex="6" value="Save" class="family" />
                            <input id="btnCancleAcademic" name="Cancel" type="button" tabindex="6" value="Cancel"
                                class="family" />
                        </td>
                    </tr>
                </table>
            </div>
            <%-- <h1 style="height:30px;font-family:Calibri;font-size:14px;font-weight:bold;background-color:#a4cd0f;width: 735px;"> Employee Education Details</h1>--%>
            <div style="margin-top: 0%;" id="box">
                
                <table id="grdAcademic">
                </table>
                <div class="grdPager" id="grdAcademicpager">
                </div>
            </div>
            <input type="hidden" id='hdnMasterAcademic' runat="server" />
            </form>
        </div>
        <div id="div4" class="targetDiv">
            <%--<h1>Career Summary</h1>--%>
            <div style="position: relative; margin-left: 0%;">
                <img alt="" src="Resources/Images/NewImages/1.png" style="width: 100%; height: 53px" />
                <div style="position: absolute; left: 2%; top: 52%;">
                    <strong class="family1 imageheadercolor">Career Summary</strong>
                </div>
            </div>
            <form id="frmcareer" action="" enctype="multipart/form-data">
            <div id='dvCareer' style="display: none;">
                <table style="width: 100%; background-color: #a4cd0f" >
                    <tr>
                        <td width="auto" valign="top">
                            <table style="width: 700px">
                                <tr>
                                    <td width="20%" height="40" class="family">
                                        Career Summary
                                    </td>
                                    <td>
                                        <label>
                                            <input type="radio" name="fresh" value="radio" id="fresh" tabindex="1" onclick="onCareerchange(this.id)" />
                                            <b>Fresher</b></label>
                                        <label>
                                            <input type="radio" name="experience" value="radio" id="experience" tabindex="2"
                                                onclick="onCareerchange(this.id)" />
                                            <b>Experienced</b></label>
                                    </td>
                                    <td class="status">
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td width="20%" height="40" class="family">
                                        Company Name<span style="font-size: medium; color: Red">*</span>
                                    </td>
                                    <td width="20%" height="40">
                                        <input id="txtcmpname" style="width: 150px" name="txtcmpname" disabled type="text"
                                            tabindex="3" />
                                    </td>
                                    <td colspan="2" ></td>
                                </tr>
                                <tr>
                                <td colspan="2" id="stxtcmpname"></td>
                                <td colspan="2" ></td>
                                </tr>
                                <tr>
                                    <td width="20%" height="40" class="family">
                                        Start Date<span style="font-size: medium; color: Red">*</span>
                                    </td>
                                    <td width="20%" height="40">
                                        <input id="txtstdate" name="txtstdate" disabled style="width: 100px" readonly type="text"
                                            tabindex="4" />
                                    </td>
                                   
                                    <td width="20%" height="40" class="family">
                                        End Date<span style="font-size: medium; color: Red">*</span>
                                    </td>
                                    <td width="20%" height="40">
                                        <input id="txtenddates" name="txtenddates" disabled style="width: 100px" readonly
                                            type="text" tabindex="5" />
                                    </td>
                                </tr>
                                <tr>
                                <td colspan="2" id="stxtstdate"></td>
                                <td colspan="2" id="stxtenddates"></td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td colspan="4">
                            <input id="btnCareer" name="Save" type="submit" tabindex="6" value="Save" class="family" />
                            <input id="btnCareerCancel" name="Cancel" type="button" tabindex="6" value="Cancel"
                                class="family" />
                        </td>
                    </tr>
                </table>
            </div>
            <%--  <h1 style="height:30px;font-family:Calibri;font-size:14px;font-weight:bold;background-color:#a4cd0f;width: 735px;"> Employee Career Details</h1>--%>
            <div style="margin-top: -2%;" id="box1">
                <br />
                <table id="grdCareer" >
                </table>
                <div class="grdPager" id="grdCareerpager">
                </div>
            </div>
            <input type="hidden" id='hdnCareerInfo' runat="server" />
            </form>
        </div>
        <div id="div5" class="targetDiv">
            <%--<h1>AltioStar CTC</h1>--%>
            <div style="position: relative; margin-left: 0%;">
                <img alt="" src="Resources/Images/NewImages/1.png" style="width: 100%; height: 53px" />
                <div style="position: absolute; left: 2%; top: 52%;">
                    <strong class="family1 imageheadercolor">AltioStar CTC</strong>
                </div>
            </div>
            <form id="frmctc" action="" enctype="multipart/form-data">
            <table  style="background-color: #a4cd0f;width: 100%">
                <tr>
                    <td>
                        <table  style=" background-color: #a4cd0f;display:none">
                            <tr>
                                <td colspan="10" align="center" class="family">
                                   
                                        <legend>Salary Slip</legend>
                                        <table>
                                            <tr>
                                                <td>
                                                    <b>
                                                        <label id="lblMonthl" class="family">
                                                            Month</label></b>
                                                </td>
                                                <td>
                                                    <select style="width: auto;" id="cmbMonthl" name="cmbMonthl" class="family">
                                                        <option value="">Select</option>
                                                        <option value="1">January</option>
                                                        <option value="2">Febuary</option>
                                                        <option value="3">March</option>
                                                        <option value="4">April</option>
                                                        <option value="5">May</option>
                                                        <option value="6">June</option>
                                                        <option value="7">July</option>
                                                        <option value="8">August</option>
                                                        <option value="9">September</option>
                                                        <option value="10">October</option>
                                                        <option value="11">November</option>
                                                        <option value="12">December</option>
                                                    </select>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <b>
                                                        <label id="lblYear" class="family">
                                                            Year</label></b>
                                                </td>
                                                <td>
                                                    <input id="txtYearl" name="txtYearl" style="width: 50px;" type="text" size="5" />
                                                </td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    <input id="btnSearch" value="Generate" name="Submit" type="button" onclick="return getSalarySlip()" />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <fieldset>
                            <table  style="width: 100%; background-color: #a4cd0f">
                                <tr>
                                    <td class="family">
                                        ESOP(Employee stock operation plan)
                                    </td>
                                    <td>
                                        <input id="txtesop" name="txtesop" type="text" tabindex="1" style="width: 200px" />
                                    </td>
                                    <td class="status" id="stxtesop">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="family">
                                        CTC(Yearly) <span style="font-size: medium; color: Red">*</span>
                                    </td>
                                    <td>
                                        <input type="text" name="txtctc" id="txtctc" tabindex="2" style="width: 200px" onkeyup="return CalculateCTCDetails();" />
                                    </td>
                                    <td class="status" id="stxtctc">
                                    </td>
                                    <td class="family">
                                        CTC(Monthly)
                                    </td>
                                    <td>
                                        <input type="text" name="txtmonthlyctc" tabindex="3" id="txtmonthlyctc" style="width: 200px"
                                            readonly />
                                    </td>
                                    <td class="stxtmonthlyctc" id="Td1">
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%; background-color: #a4cd0f;" >
                                <tr>
                                    <td width="auto" valign="top">
                                        <table style="width: 700px; background-color: #a4cd0f">
                                            <tr>
                                                <td width="200" height="40" class="family">
                                                    <b>ANNUAL</b>
                                                </td>
                                                <td width="200" height="40">
                                                </td>
                                                <td width="200" height="40">
                                                </td>
                                                <td width="200" height="40" class="family">
                                                    <b>MONTHLY</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="200" height="40" class="family">
                                                    Annual Basic
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtannualb" style="width: 150px" readonly name="txtannualb"
                                                        tabindex="4" />
                                                </td>
                                                <td id="sannualb" width="200" height="40">
                                                </td>
                                                <td width="200" height="40" class="family">
                                                    Monthly Basic
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtmonthlyb" style="width: 150px" readonly name="txtmonthlyb"
                                                        tabindex="5" />
                                                </td>
                                                <td id="smonthlyb" width="200" height="40">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="200" height="40" class="family">
                                                    Annual HRA
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtannualHRA" style="width: 150px" readonly name="txtannualHRA"
                                                        tabindex="6" />
                                                </td>
                                                <td id="sannualHRA" width="200" height="40">
                                                </td>
                                                <td width="200" height="40" class="family">
                                                    Monthly HRA
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtmonthlyHRA" style="width: 150px" readonly name="txtmonthlyHRA"
                                                        tabindex="7" />
                                                </td>
                                                <td id="smonthlyHRA" width="200" height="40">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="200" height="40" class="family">
                                                    Annual Special Allowance
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtannualASA" style="width: 150px" readonly name="txtannualASA"
                                                        tabindex="8" />
                                                </td>
                                                <td id="sannualASA" width="200" height="40">
                                                </td>
                                                <td width="200" height="40" class="family">
                                                    Monthly Special Allowance
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtmonthlyMSA" style="width: 150px" readonly name="txtmonthlyMSA"
                                                        tabindex="9" />
                                                </td>
                                                <td id="smonthlyMSA" width="200" height="40">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="200" height="40" class="family">
                                                    Annual Conveyance Allowance
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtannualACA" style="width: 150px" readonly name="txtannualACA"
                                                        tabindex="10" />
                                                </td>
                                                <td id="sannualACA" class="status">
                                                </td>
                                                <td width="200" height="40" class="family">
                                                    Monthly Conveyance Allowance
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtmonthlyMCA" style="width: 150px" readonly name="txtmonthlyMCA"
                                                        tabindex="11" />
                                                </td>
                                                <td id="smonthlyMCA" class="status">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="200" height="40" class="family">
                                                    Annual PF
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtannualPF" style="width: 150px" readonly name="txtannualPF"
                                                        tabindex="12" />
                                                </td>
                                                <td id="sannualPF" width="200" height="40">
                                                </td>
                                                <td width="200" height="40" class="family">
                                                    Monthly PF
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtmonthlyPF" style="width: 150px" readonly name="txtmonthlyPF"
                                                        tabindex="13" />
                                                </td>
                                                <td id="smonthlyPF" width="200" height="40">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="family">
                                                    Annual Benefits
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="200" height="40" class="family">
                                                    Leave Travel allowance
                                                </td>
                                                <td>
                                                    <input id='txttravel' type="text" name="txttravel" style="width: 150px" readonly />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="family">
                                                    Medical Reimbursement
                                                </td>
                                                <td width="200" height="40">
                                                    <input type="text" id="txtannualbenefits" style="width: 150px" readonly name="txtannualbenefits"
                                                        tabindex="14" />
                                                </td>
                                                <td id="sannualbenefits" width="200" height="40">
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td colspan="4" class="family">
                                                    <input id="btnSave5" name="Submit" type="submit" value="Save" tabindex="15" />
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
            <input type="hidden" id='hdnSalaryID' runat="server" />
            <input type="hidden" id='hdnMasterEmpSalary' runat="server" />
            <input type="hidden" id='hdnCA' runat="server" />
            <input type="hidden" id='hdnMedicalReimb' runat="server" />
            </form>
        </div>
        <div id="div6" class="targetDiv">
            <h1>
                Exit Employee Report</h1>
        </div>
        <div id="div7" class="targetDiv" >
            <%--<h1>Document upload</h1>--%>
            <div style="position: relative; margin-left: 0%;">
                <img alt="" src="Resources/Images/NewImages/1.png" style="width: 100%; height: 53px" />
                <div style="position: absolute; left: 2%; top: 52%;">
                    <strong class="family1 imageheadercolor">Document upload</strong>
                </div>
            </div>
            <div style="margin-left: 0%;margin-top:-2%; border: solid 1px Transparent;" class="header_main">
                <label style="color: White" class="family">
                    Document Upload</label></div>
            <fieldset>
                <table  style="background-color: #a4cd0f; width: 100%;">
                    <tr id="trEmployeeDocUpl">
                        <td>
                            <input type="button" id="btnDocumentUpload" value="Please select a Document to Upload"
                                onclick="onDocumentUpload()" tabindex="1" class="family" />
                        </td>
                        <td>
                            <input type="button" id="btnDocumentDelete" value="Delete Document" onclick="onDocumentDelete()"
                                tabindex="2" class="family" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="button" id="btnViewDocument" value="View Document" onclick="onDocumentView()"
                                tabindex="3" class="family" />
                        </td>
                    </tr>
                    <tr id="trAdminDocUpl">
                        <td colspan="2">
                            <%-- <div id="box2">
                                    <table id="grdDocUpl" class="scroll">
                                    </table>
                                    <div class="grdPager" id="pagerDocUpl">
                                    </div>
                                 </div>--%>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <div id="box2">
                <table id="grdDocUpl">
                </table>
                <div class="grdPager" id="pagerDocUpl">
                </div>
            </div>
            <input type="hidden" id='hdnMasterDocs' runat="server" />
        </div>
        <div id="div8" class="targetDiv">
        </div>
    </div>
    <%--  </form>--%>
</body>

<script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

<script src="Resources/js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

<script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="Resources/js/Webutility.js"></script>

<script type="text/javascript" src="Resources/js/toolbar.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

<script type="text/javascript" src="Resources/js/jquery.validate.js"></script>

<script src="Resources/js/jquery.ui.button.js" type="text/javascript"></script>

<script type="text/javascript" src="Resources/js/Validation.js"></script>

<script type="text/javascript" src="Resources/js/ajaxfileupload.js"></script>

<script type="text/javascript">
    $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "100%" });
    $("#box1").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "100%" });
    $("#box2").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "100%" }); 
//    $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg.gif)');
//    $('#box1').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg.gif)');
//    $('#box2').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg.gif)');
    var currentMonth = '';
    var currentDate = '';
    var currentYear = '';

    jQuery(document).ready(function() {

        var date = new Date();
        currentMonth = date.getMonth();
        currentDate = date.getDate();
        currentYear = date.getFullYear();
        $('.targetDiv').hide();
        $('#div1').show();
        if ($('#hdnType').val() == "self") {
            document.getElementById("bck").style.display = "none";
        }
        document.getElementById("photo").style.display = "";
        $('.show').click(function() {
            $('.targetDiv').hide();
            var selected = $('#div' + $(this).attr('target'));
            if (selected.selector == '#div1') {
                selected.show();
                document.getElementById("photo").style.display = "";
            }
            else if (selected.selector == '#div8') {
                if ($('#hdnType').val() != "self") {
                    $('#ChildWB', parent.document).attr("src", "default.aspx?serve=Master_EmployeeSummary");

                }
            }
            else {
                //  document.getElementById("photo").style.display = "none";
                if ($('#hdnEmployeeID').val() != "0") {
                    // if (confirm('Do you want to svae the changes?') == false) return;
                    selected.show();
                    onCancelAcademicDetails();
                    clearAcademicDetailsData();
                    onCancelCareerDetails();
                    clearCareerDetailsData();
                    // LoadEmpPersonalInfo();
                }
                else {
                    $('#div1').show();
                }
            }
        });

        LoadCountry();
        LoadMaritalStatus();
        LoadEmployeeType();
        LoadLocation();
        LoadDesignation();
        LoadTeam();

        if ($('#hdnType').val() == "self") {
           // $("#btnSave1").hide();
            $("#btnSave2").hide();
          //  $("#btnAddAcademic").hide();
          //  $("#btnCareer").hide();
            $("#btnSave5").hide();
//$("#btnUpload").hide();
        }
        $(function() {
            $("#DOBdatepicker").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050',
                maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
                $("#DOBdatepicker").valid();
            });
            $("#DOBdatepicker").datepicker("option", "dateFormat", 'dd/mm/yy');

        });

        var date = new Date(), y = date.getFullYear(), m = date.getMonth();
        var fSDate = new Date(y, m, 1);
        var fEDate = new Date(y, m + 1, 0);

        $(function() {
            $("#txtjoiningdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '-0:+0',
                maxDate: fEDate,
                yearRange: '1930:2050'
                // maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
                $("#txtjoiningdate").valid();
            });
            $("#txtjoiningdate").datepicker("option", "dateFormat", 'dd/mm/yy');

        });

        $(function() {
            $("#txtexitdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
                $("#txtexitdate").valid();
            });
            $("#txtexitdate").datepicker("option", "dateFormat", 'dd/mm/yy');

        });
        // $("#txtexitdate").datepicker("option", "disabled", true);
        //$('#txtexitdate').attr("disabled", true);
        $("#txtexitdate").datepicker('disable');
        $(function() { 
            $("#txtstdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050',
                maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
                
                $("#txtstdate").valid();
                $("#grdCareer").jqGrid('setGridWidth', $("#content").width());
            });
            $("#txtstdate").datepicker("option", "dateFormat", 'dd/mm/yy');

        });
        $(function() { 
            $("#txtenddates").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050',
                maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
                $("#txtenddates").valid();
            });
            $("#txtenddates").datepicker("option", "dateFormat", 'dd/mm/yy');

        });

        jQuery.validator.addMethod("greaterThan", function(value, element, param) {
            return this.optional(element) || parseFloat(value) < parseFloat($(param).val());
        }, "");
        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]+$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");
        //Start of Employee Info  DIV1
        var Data = new Date();
        var validator = $("#frmpersonaldetails").validate({
            ignore: ":disabled",
            rules: {
                cmbemptype: {
                    required: true
                },
                txtFirstname: {
                    required: true
                },
                txtLastName: {
                    required: true
                },
                DOBdatepicker: {
                    required: true
                },
                cmbmaritalstatus: {
                    required: true
                },
                txtPAddress: {
                    required: true
                },
                txtCAddress: {
                    required: true
                },
                txtpersonalemail: {
                    required: true,
                    email: true
                },
                txtmobile: {
                    required: true,
                    number: true,
                    minlength: 10
                },
                txtresidno: {
                    number: true
                },
                txtemergno: {
                    required: true,
                    number: true,
                    minlength: 10
                }

            },
            messages: {
                cmbemptype: {
                    required: "Select employee type"
                },
                txtFirstname: {
                    required: "First name cannot be empty"
                },
                txtLastName: {
                    required: "Last name cannot be empty"
                },
                DOBdatepicker: {
                    required: "Select Date of birth"
                },
                cmbmaritalstatus: {
                    required: "Select marital status"
                },
                txtPAddress: {
                    required: "Enter permanent address"
                },
                txtCAddress: {
                    required: "Enter current address"
                },
                txtmobile: {
                    required: "Enter mobile number",
                    number: "Enter mobile number",
                    minlength : "Enter alteast 10 digits"
                },
                txtresidno: {
                    number: "Enter residency number"
                },
                txtemergno: {
                    required: "Enter emergency number",
                    number: "Enter emergency number",
                    minlength: "Enter alteast 10 digits"
                },
                txtpersonalemail: {
                    required: "Enter the E-mail Address",
                    email: "Please enter a valid email address"
                }
            },
            errorPlacement: function(error, element) {            
                $("#s" + element[0].id).html(error);  
            },
            submitHandler: function(id) {
                UpdateEmpPersonalInfo();
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });

        //End Of Updtae Personal Employee Info
        //Start Update of Occupation EMployee Info  DIV2

        var validator = $("#OccupationForm").validate({
            ignore: ":disabled",
            rules: {
                cmbcountry: {
                    required: true
                },
                cmblocation: {
                    required: true
                },
                txtjoiningdate: {
                    required: true
                },
                txtemailid: {
                    email: true
                },
                txtleaves: {
                    required: true
                },
                cmbteam: {
                    required: true
                },
//                txtmanagername: {
//                    required: true
//                },
                cmbdesignation: {
                    required: true
                },
                txtUsername: {
                    required: true
                }

            },
            messages: {
                cmbcountry: {
                    required: "Select country"
                },
                cmblocation: {
                    required: "Select location"
                },
                txtjoiningdate: {
                    required: "Enter joining date"
                },
                txtemailid: {
                    required: "Enter the E-mail Address"
                },
                txtleaves: {
                    required: "Enter leaves count"
                },
                cmbteam: {
                    required: "Select team"
                },
                cmbdesignation: {
                    required: "Select designation"
                },
                txtUsername: {
                    required: "Enter Username"
                }

            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {

                if ($('#cmbtypeofexit').val() != "") {
                    if ($('#txtexitdate').val() == "") {
                        alert("Enter exit date");
                    }
                    else {
                        UpdateOccupationalInfo();
                    }
                }
                else {
                    UpdateOccupationalInfo();
                }
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });
        // END of occupation employee Info


        ///EMPLOYEE ACADEMIC DETAILS  DIV3
        var validatorDialogAcademic = $("#frmeducation").validate({
            rules: {
                txteducation: {
                    required: true
                },
                txtstream: {
                    required: true
                },
                txtuniversity: {
                    required: true
                },
                txtyear: {
                    required: true,
                    number: true,
                    minlength: 4,
                    maxlength: 4
                },
                txtpercentage: {
                    required: true,
                    number: true
                }
            },
            messages: {
                txteducation: {
                    required: "Enter education"
                },
                txtstream: {
                    required: "Enter stream"
                },
                txtuniversity: {
                    required: "Enter University"
                },
                txtyear: {
                    required: "Enter year",
                    number: "Enter year",
                    minlength: "Enter atleast 4 numbers",
                    maxlength: "Maximum 4 numbers allowed"
                },
                txtpercentage: {
                    required: "Enter percentage",
                    number: "Enter percentage"
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {
                UpdateEmpAcademicDetails();
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });

        $('#btnCancleAcademic').click(function() {
            onCancelAcademicDetails();
            clearAcademicDetailsData();
        });

        //** END OF EMPLOYEE ACADEMIC DETAILS

        //Start Emp career  DIV4
        var validator = $("#frmcareer").validate({
            ignore: ":disabled",
            rules: {
                txtcmpname: {
                    required: true
                },
                txtstdate: {
                    required: true
                },
                txtenddates: {
                    required: true
                }
            },
            messages: {
                txtcmpname: {
                    required: "Enter company name"
                },
                txtstdate: {
                    required: "Select start date"
                },
                txtenddates: {
                    required: "Select end date"
                }
            },
            errorPlacement: function(error, element) {
                $("#s" + element[0].id).html(error);  
                //error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {
                UpdateEmpCareerInfo();
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });

        $('#btnCareerCancel').click(function() {
            onCancelCareerDetails();
            clearCareerDetailsData();
        });
        //End Of Employee Career Info

        //START Slary Info
        var validator = $("#frmctc").validate({
            ignore: ":disabled",
            rules: {
                txtesop: {
                    number: true
                },
                txtctc: {
                    required: true,
                    number: true
                }
            },
            messages: {
                txtesop: {
                    required: "Enter ESOP Number"
                },
                txtctc: {
                    required: "Enter CTC"
                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function(id) {
                UpdateSalaryInfo();
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });

        LoadEmpPersonalInfo();

        if ($("#hdnOccupID").val() == "" || $("#hdnOccupID").val() == "0") {
            $("#txtUsername").val(""); 
            $("#txtUsername").prop("readonly", false);
        }
        else {
            $("#txtUsername").prop("readonly", true);
        }

    });
    function getSalarySlip() {
        var dtDate = new Date($("#txtYearl").val(), $("#cmbMonthl").val() - 1, '01');
        if (dtDate > new Date()) {
            alert("Invalid Month and Year");
            return;
        }
        var Request = new Object();
        Request.Month = $("#cmbMonthl").val();
        Request.Year = $("#txtYearl").val();
        Request.EmpID = $("#hdnEmployeeID").val();
        var Response = SendApplicationRequest('<%=PayrollAppCommands.CHECK_PAYROLL_GENERATED%>', Request);
        if (Response.ResponseCommand != 'SUCCESS') {
            alert("Payroll not generated for this month");
            return;
        }
        strQr = "rtype=rdlcSalaryDetails&Month=" + $("#cmbMonthl").val() + "&employeeid=" + $("#hdnEmployeeID").val() + "&Year=" + document.getElementById("txtYearl").value;
        window.showModalDialog("default.aspx?serve=rdlcReportViewer&" + strQr, window.self, "dialogHeight:750px; dialogWidth:1000px; resizable:yes; status:no;");
    }
    function OnChangeLeaveCount() {

        if ($("#txtjoiningdate").val() != "") {
            var arr = $("#txtjoiningdate").val();
            arr = arr.split("/");

            var date = new Date($("#txtjoiningdate").val());
            var mnthleaves = $("#hdnLeaveCount").val() / 12;
            var leavescnt = ''; var cnt = 0;
            //if(currentMonth<3)
            $("#hdnFinancialMonth").val("4");
            if ((arr[1] == 1 || arr[1] == 01) && arr[2] <= currentYear) {
                arr[1] = "13";
                $("#hdnFinancialYear").val(eval(currentYear) - 1);
            }
            else if ((arr[1] == 2 || arr[1] == 02) && arr[2] <= currentYear) {
                arr[1] = "14";
                $("#hdnFinancialYear").val(eval(currentYear) - 1);
            }
            else if ((arr[1] == 3 || arr[1] == 03) && arr[2] <= currentYear) {
                arr[1] = "15";
                $("#hdnFinancialYear").val(eval(currentYear) - 1);
            }
            else if (arr[2] <= currentYear) {
                $("#hdnFinancialYear").val(eval(currentYear) - 1);
            }
            else {
                $("#hdnFinancialYear").val(eval(currentYear));
            }
            for (j = arr[1]; j <= 15; j++) {
                cnt = cnt + 1;
            }
            leavescnt = eval(mnthleaves) * eval(cnt);
            $("#txtleaves").val(leavescnt);
        }
    }

    function UpdateEmpPersonalInfo() {

        if (!ValidateSingleDate($("#DOBdatepicker").val(), 'Birth')) { return; }
        var Request = new Object();
        var ID = "";
        if ($("#hdnEmployeeID").val() == "") ID = "0";
        else ID = $("#hdnEmployeeID").val();
        Request.ID = ID;
        Request.EmpCode = $("#txtEmpNo").val();
        Request.EmployeeTypeID = $("#cmbemptype").val();
        Request.FirstName = $("#txtFirstname").val();
        Request.LastName = $("#txtLastName").val();
        Request.MiddleName = $("#txtMiddlename").val();
        Request.DOB = $("#DOBdatepicker").val();
        Request.MaritalStatusID = $("#cmbmaritalstatus").val();
        Request.PermanentAddress = $("#txtPAddress").val();
        Request.CurrentAddress = $("#txtCAddress").val();
        Request.MobileNumber = $("#txtmobile").val();
        Request.ResidenceNumber = $("#txtresidno").val();
        Request.EmergencyContactNumber = $("#txtemergno").val();
        Request.PersonalEmailID = $("#txtpersonalemail").val();
        Request.IsActive = true;
        Request.IsDeleted = false;
        Request.UpdatedBy = $("#hdnLoggedinID").val();
        if ($("#rdoMale").is(':checked')) { Request.Gender = 'M'; }
        else { Request.Gender = 'F'; }

        Request.EmployeeInfoType = document.getElementById("hdnEmpPersonalTab").value;
        var Response = SendApplicationRequest('<%=EmployeeAppCommands.UPDATE_EMPLOYEE_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
            alert('Employee saved successfully');
            var str = Response.Message.split('_');
            $('#hdnEmployeeID').val(str[0]);
            $('#txtEmpNo').val(str[1]);

            if (document.getElementById("hdnPhoto").value == "") document.getElementById("hdnPhoto").value = "false"
            if (document.getElementById("hdnPhoto").value == "false") {
                // if (confirm('Do you want to upload photo?')) {
                Upload();
                //}
            }
            if (ID == "0")
                LoadEmpPersonalInfo();
        }
        else {
            alert(Response.Message); return false;
        }
    }

    function UpdateOccupationalInfo() {

        var Request = new Object();
        var ID = "";
        if ($("#hdnOccupID").val() == "" || $("#hdnOccupID").val() == "0")
            ID = "0";
        else
            ID = $("#hdnOccupID").val();
        Request.ID = ID;
        Request.EmployeeID = $("#hdnEmployeeID").val(); // $("#hdnEmployeeID").val();
        Request.CountryID = $("#cmbcountry").val();
        Request.LocationID = $("#cmblocation").val();
        Request.DesignationID = $("#cmbdesignation").val();
        Request.TeamID = $("#cmbteam").val();
        Request.JoiningDate = $("#txtjoiningdate").datepicker("getDate");
        Request.ExitDate = $("#txtexitdate").val();
        Request.Username = $("#txtUsername").val();
        if ($("#cmbtypeofexit").val() == "") {
            Request.TypeOfExitID = "0";
        }
        else {
            Request.TypeOfExitID = $("#cmbtypeofexit").val();
        }
        if (!CompareDateForForm(jQuery('#DOBdatepicker').val(), jQuery('#txtjoiningdate').val())) {
            alert('Joining date should be greater than date of birth');
            return false;
        }
        if ($('#cmbtypeofexit').val() != "") {
            if ($("#txtexitdate").datepicker("getDate") == "" || $("#txtexitdate").datepicker("getDate") == null) {
                alert('Exit Date Cannot be empty');
                return;
            }
            else {
                // if (!ValidateDate($("#txtjoiningdate").val(), $("#txtexitdate").val())) { return; }
                if (!CompareDateForForm(jQuery('#txtjoiningdate').val(), jQuery('#txtexitdate').val())) {
                    alert('Exit date should be greater than joining date');
                    return false;
                }
                Request.ExitDate = $("#txtexitdate").datepicker("getDate");
            }
        }


        Request.LeavesCount = $("#txtleaves").val();
        Request.EmailID = $("#txtemailid").val();
        Request.ActivatedBy = $("#hdnLoggedinID").val();
        Request.IsActive = true;
        Request.FinancialMonth = $("#hdnFinancialMonth").val();
        Request.FinancialYear = $("#hdnFinancialYear").val();
        Request.EmployeeInfoType = document.getElementById("hdnEmpOccupationalTab").value;
        var Response = SendApplicationRequest('<%=EmployeeAppCommands.UPDATE_EMPLOYEE_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
            alert('saved successfully');
            //$("#btnSave2").attr("disabled", true);
            $("#hdnOccupID").val(Response.Message);
        }
        else {
            alert(Response.Message); return false;
        }
    }


    function LoadEmpPersonalInfo() {

        //   $("#hdnEmployeeID").val("3");
        var Request = new Object();
        Request.ID = $("#hdnEmployeeID").val();
        Request.EmployeeInfoType = document.getElementById("hdnEmpPersonalTab").value;
        var Response = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE%>', Request, true);
        if (Response.ResponseCommand == 'SUCCESS') {
            if (Response.ResponseObject.PersonalInfo.iD != 0) {
                $("#txtEmpNo ").val(Response.ResponseObject.PersonalInfo.empCode);
                $("#cmbemptype").val(Response.ResponseObject.PersonalInfo.employeeTypeID);
                $("#txtFirstname").val(Response.ResponseObject.PersonalInfo.firstName);
                $("#txtMiddlename").val(Response.ResponseObject.PersonalInfo.middleName);
                $("#txtLastName").val(Response.ResponseObject.PersonalInfo.lastName);
                $("#txtName").text($("#txtFirstname").val() + ' ' + $("#txtMiddlename").val() + ' ' + $("#txtLastName").val());
                $("#txtid").text($("#txtEmpNo").val());
                var IndDOB = null;
                IndDOB = Response.ResponseObject.PersonalInfo.dOB.substring(8, 10) + "/" + Response.ResponseObject.PersonalInfo.dOB.substring(5, 7) + "/" + Response.ResponseObject.PersonalInfo.dOB.substring(0, 4);
                $("#DOBdatepicker").datepicker({
                    showOn: "button",
                    buttonImage: "Resources/Images/calendar.gif",
                    buttonImageOnly: true,
                    changeMonth: true,
                    changeYear: true,
                    yearRange: '1930:2050',
                    maxDate: new Date()
                }).change(function() {
                    $("#DOBdatepicker").valid();
                });
                $("#DOBdatepicker").datepicker("option", "dateFormat", 'dd/mm/yy');
                $("#DOBdatepicker").val(IndDOB);
                if (Response.ResponseObject.PersonalInfo.gender == 'M') { $("#rdoMale").attr('checked', true); }
                else { $("#rdoFemale").attr('checked', true); }
                $("#cmbmaritalstatus").val(Response.ResponseObject.PersonalInfo.maritalStatusID);
                $("#txtPAddress").val(Response.ResponseObject.PersonalInfo.permanentAddress);
                $("#txtCAddress").val(Response.ResponseObject.PersonalInfo.currentAddress);
                $("#txtmobile").val(Response.ResponseObject.PersonalInfo.mobileNumber);
                $("#txtresidno").val(Response.ResponseObject.PersonalInfo.residenceNumber);
                $("#txtemergno").val(Response.ResponseObject.PersonalInfo.emergencyContactNumber);
                $("#txtpersonalemail").val(Response.ResponseObject.PersonalInfo.personalEmailID);

                // document.getElementById("imgPhoto").src = "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val();
                // setImageDiv('dvImgPhoto', 'imgPhoto', '', "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val() + '&test=te' + inc++, 100, 100);
                if (document.getElementById("hdnPhoto").value == "true") {

                    if ($("#hdnType").val() != "self") {
                        // setImageDiv('dvImgPhoto', 'imgPhoto', '', "../UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val() + '&test=te' + inc++, 100, 100);
                        document.getElementById("imgPhoto").src = "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val();

                    }
                    else {
                        //setImageDiv('dvImgPhoto', 'imgPhoto', '', "../UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val() + '&test=te' + inc++, 100, 100);
                        document.getElementById("imgPhoto").src = "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val();

                    }
                }
                LoadOccupational(Response);
                LoadEmpDocs(Response);
                LoadEmpAcademicDetails(Response);
                LoadSalaryDetails(Response);
                LoadCareerDetails(Response);
            }
        }
    }


    function OnExitChange() {
        if ($('#cmbtypeofexit').val() != "") {
            $("#txtexitdate").datepicker('enable');
        }
        else {
            $("#txtexitdate").datepicker('disable');
            $('#txtexitdate').val("");
        }
    }

    function LoadOccupational(Response) {
        if (Response.ResponseObject.OccupationInfo.ID != 0) {
            $("#hdnOccupID").val(Response.ResponseObject.OccupationInfo.iD);
            $("#hdnFinancialMonth").val(Response.ResponseObject.OccupationInfo.financialMonth);
            $("#hdnFinancialYear").val(Response.ResponseObject.OccupationInfo.financialYear);
            $("#cmbcountry").val(Response.ResponseObject.OccupationInfo.countryID);
            LoadLocation();
            $("#cmblocation").val(Response.ResponseObject.OccupationInfo.locationID);
            var fromdt = null;
            fromdt = Response.ResponseObject.OccupationInfo.joiningDate.substring(8, 10) + "/" + Response.ResponseObject.OccupationInfo.joiningDate.substring(5, 7) + "/" + Response.ResponseObject.OccupationInfo.joiningDate.substring(0, 4);
            var date = new Date(), y = date.getFullYear(), m = date.getMonth();
            var fSDate = new Date(y, m, 1);
            var fEDate = new Date(y, m + 1, 0);
            $("#txtjoiningdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '-0:+0',
                maxDate: fEDate,
                yearRange: '1930:2050'
                // maxDate: new Date(currentYear, currentMonth, currentDate)
            }).change(function() {
                $("#txtjoiningdate").valid();
            });
            $("#txtjoiningdate").datepicker("option", "dateFormat", 'dd/mm/yy');
            if (fromdt == "01/01/0001" || fromdt == "01/01/1900") {
                $("#txtjoiningdate").val("");
            }
            else {
                $("#txtjoiningdate").val(fromdt);
            }
            var exitdt = null;
            exitdt = Response.ResponseObject.OccupationInfo.exitDate.substring(8, 10) + "/" + Response.ResponseObject.OccupationInfo.exitDate.substring(5, 7) + "/" + Response.ResponseObject.OccupationInfo.exitDate.substring(0, 4);
            $("#txtexitdate").datepicker({
                showOn: "button",
                buttonImage: "Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
                // maxDate: new Date()
            }).change(function() {
                $("#txtexitdate").valid();
            });
            $("#txtexitdate").datepicker("option", "dateFormat", 'dd/mm/yy');
            if (exitdt == "01/01/0001" || exitdt == "01/01/1900") {
                $("#txtexitdate").val("");
            }
            else {
                $("#txtexitdate").val(exitdt);
            }
            $("#cmbtypeofexit").val(Response.ResponseObject.OccupationInfo.typeOfExitID);
            if (Response.ResponseObject.OccupationInfo.typeOfExitID == 0) $("#txtexitdate").datepicker('disable');
            $("#txtemailid").val(Response.ResponseObject.OccupationInfo.emailID);

            $("#txtleaves").val(Response.ResponseObject.OccupationInfo.leavesCount);

            $("#cmbteam").val(Response.ResponseObject.OccupationInfo.teamID);
            $("#cmbdesignation").val(Response.ResponseObject.OccupationInfo.designationID);
            onTeamChange();

            $("#txtUsername").val(Response.ResponseObject.OccupationInfo.username);
            if ($("#txtUsername").val() != "") {
                $("#txtUsername").attr("readonly", true);
            }
            else {
                $("#txtUsername").prop("readonly", false);
            }
        }
        else {
            $("#txtUsername").val("");
            $("#txtUsername").prop("readonly", false);
        }
    }

    function onTeamChange() {
        var Request = new Object();
            Request.ID = $("#cmbteam").val();
        var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_DETAILS_BYID%>", Request, true);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            $("#txtmanagername").val(arr[0]["ManagerName"]);
        } else {
            $("#txtmanagername").val("");
        }
    }


    //// ACADEMIC EMPLOYEE  DETAILS /////

    function LoadEmpAcademicDetails(Response) {

        var myGrid = $('#grdAcademic');
        Response.ResponseObject.EducationInfo.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'EmployeeID', index: 'EmployeeID', width: 20, hidden: true, sorttype: "int" },
            { name: 'Education', index: 'Education', width: 100, editable: true },
            { name: 'Stream', index: 'Stream', width: 100, editable: true },
            { name: 'University', index: 'University', width: 100, editable: true },
            { name: 'Year', index: 'Year', width: 85, editable: true },
            { name: 'Percentage', index: 'Percentage', width: 85, editable: true },
            { name: 'UpdatedBy', index: 'UpdatedBy', width: 85, editable: true, hidden: true }
        ]
        Response.ResponseObject.EducationInfo.pager = "grdAcademicpager";
        Response.ResponseObject.CareerInfo.height = "225";
        Response.ResponseObject.EducationInfo.width = $("#content").width();
        myGrid.jqGrid(Response.ResponseObject.EducationInfo);

      //  jQuery("#grdAcademic").jqGrid('setGridHeight', "100%");
//        jQuery("#grdAcademic").jqGrid('setGridWidth', "735");

        //       jQuery("#grdAcademic").jqGrid('setCaption', "Employee Education Details").trigger('reloadGrid');
        jQuery("#grdAcademic").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        jQuery("#grdAcademic").jqGrid('navGrid', '#grdAcademicpager', { del: false, add: false, edit: false, search: false });
        $("#t_grdAcademic").append("<button type='button' id='add' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><div></div><span>Add</span></button>");
        $("#t_grdAcademic").append("<button type='button' id='edit' value='Edit' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/edit_icon.png'height=18px;width=18px alt='' /><br/><div></div><span>Edit</span></button>");
        $("#t_grdAcademic").append("<button type='button' id='delete' value='Delete' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/Deactive.jpg'height=20px;width=22px alt='' /><br/><div></div><span>Delete</span></button>");
        if ($('#hdnType').val() == "self") {
            document.getElementById("delete").style.display = "none";
            document.getElementById("edit").style.display = "none";
        }
        $("input,button", "#t_grdAcademic").click(function(id) {
            if (id.currentTarget.id == "add") {
                mode = "add";
                document.getElementById("dialogAcademicDetails").style.display = "";
                clearAcademicDetailsData();
            }
            else if (id.currentTarget.id == "edit") {
                var id = jQuery("#grdAcademic").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    document.getElementById("dialogAcademicDetails").style.display = "";
                    fillAcademicDetailsData();
                }
                else { alert("Please select row"); }
            }
            else if (id.currentTarget.id == "delete") {
                var gr = jQuery("#grdAcademic").getGridParam('selrow');
                if (gr) {
                    var currPage = jQuery('#grdAcademic').jqGrid('getGridParam', 'page');
                    if (confirm('Do you want to delete?') == false) return;
                    var id = jQuery("#grdAcademic").jqGrid('getGridParam', 'selrow');
                    if (id) {
                        RemoveAcademicEmpdetails(id);
                    }
                    jQuery("#grdAcademic").delRowData(gr);
                    jQuery("#grdAcademic").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');

                }
                else alert("Please Select Row to delete!");

            }
        });
    }

    function onCancelAcademicDetails() {
        clearAcademicDetailsData();
        document.getElementById("dialogAcademicDetails").style.display = "none";
    }
    function UpdateEmpAcademicDetails() {

        var currPage = jQuery('#grdAcademic').jqGrid('getGridParam', 'page');
        var Request = new Object();
        var ID = "";
        if (mode == "edit") {
            var id = jQuery("#grdAcademic").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#grdAcademic").jqGrid('getRowData', id);
            ID = ret.id;
        }
        else {
            ID = "0";
        }
        Request.ID = ID;
        Request.EmployeeID = $("#hdnEmployeeID").val();
        Request.Education = $("#txteducation").val();
        Request.Stream = $("#txtstream").val();
        Request.University = $("#txtuniversity").val();
        Request.Percentage = $("#txtpercentage").val();
        if ($("#txtyear").val() <= (new Date().getFullYear())) {
            Request.Year = $("#txtyear").val();
        } else {
            alert("Invalid Year."); return;
        }

        Request.UpdateBy = $("#hdnLoggedinID").val();
        Request.EmployeeInfoType = document.getElementById("hdnMasterAcademic").value;
        var per = $("#txtpercentage").val();
        if (eval(per) > 100 || eval(per) < 45) {
            alert("Invalid percentage"); return;
        }

        var Response = SendApplicationRequest('<%=EmployeeAppCommands.UPDATE_EMPLOYEE_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
            alert('Saved successfully');
            var Request = new Object();
            Request.ID = $("#hdnEmployeeID").val();
            Request.EmployeeInfoType = document.getElementById("hdnMasterAcademic").value;
            var Response = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE%>', Request);
            Response.ResponseObject.EducationInfo.width = $("#content").width();
            jQuery("#grdAcademic").jqGrid('setGridParam', Response.ResponseObject.EducationInfo);
            //          jQuery("#grdAcademic").jqGrid('setCaption', "Employee Academic  Detail: ").trigger('reloadGrid');
            onCancelAcademicDetails();
            clearAcademicDetailsData();
        }
        else {
            alert(Response.Message);
        }
        //       jQuery("#grdAcademic").jqGrid('setCaption', "Employee Education Details").trigger('reloadGrid');
        jQuery("#grdAcademic").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
    }
    function clearAcademicDetailsData() {
        stxteducation.innerHTML = "";
        stxtstream.innerHTML = "";
        stxtuniversity.innerHTML = "";
        stxtyear.innerHTML = "";
        stxtpercentage.innerHTML = "";
        $("#txteducation").val("");
        $("#txtstream").val("");
        $("#txtuniversity").val("");
        $("#txtyear").val("");
        $("#txtpercentage").val("");
    }
    function fillAcademicDetailsData() {
        var id = jQuery("#grdAcademic").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#grdAcademic").jqGrid('getRowData', id);
        $("#txteducation").val(ret.Education);
        $("#txtstream").val(ret.Stream);
        $("#txtuniversity").val(ret.University);
        $("#txtyear").val(ret.Year);
        $("#txtpercentage").val(ret.Percentage);
    }

    function RemoveAcademicEmpdetails(id) {

        var Request = new Object();
        Request.ID = id;
        Request.EmployeeInfoType = document.getElementById("hdnMasterAcademic").value;
        var Response = SendApplicationRequest('<%=EmployeeAppCommands.REMOVE_EMPLOYEE_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
            mode = "SUCCESS";
            alert('Deleted successfully');
        }
        else
            alert(Response.Message);
    }
    //END EDUCATION DETAILS


    //START CAREER DETAILS


    function LoadCareerDetails(Response) { 

        var myGrid = $('#grdCareer');
        Response.ResponseObject.CareerInfo.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'EmployeeID', index: 'EmployeeID', width: 20, hidden: true, sorttype: "int" },
//   		            { name: 'IsFresher', index: 'IsFresher', width: 100, editable: true },
            {name: 'IsFresher', index: 'IsFresher', width: 40, align: 'center', editable: false, formatter: 'checkbox',
            edittype: 'checkbox', editoptions: { value: 'Yes:No' }, formatoptions: { disabled: true }
            },
            { name: 'CompanyName', index: 'CompanyName', width: 100, editable: true },
            { name: 'dtStartDate', index: 'dtStartDate', width: 100, editable: true, hidden: true,
                formatter: 'date', "formatoptions": { srcformat: 'Y-m-d', newformat: 'd/m/Y' }
            },
            { name: 'dtEndDate', index: 'dtEndDate', width: 100, editable: true, hidden: true,
                 formatter: 'date', "formatoptions": { srcformat: 'Y-m-d', newformat: 'd/m/Y' }
            },
            { name: 'StartDate', index: 'StartDate', width: 100, editable: true },
            { name: 'EndDate', index: 'EndDate', width: 100, editable: true },
            { name: 'UpdatedBy', index: 'UpdatedBy', width: 85, editable: true, hidden: true }
        ]

        Response.ResponseObject.CareerInfo.pager = "grdCareerpager";
        Response.ResponseObject.CareerInfo.height = "225";
        Response.ResponseObject.CareerInfo.width = $("#content").width();
        myGrid.jqGrid(Response.ResponseObject.CareerInfo);

      
        //jQuery("#grdCareer").jqGrid('setGridWidth', "900px");
        //      jQuery("#grdCareer").jqGrid('setCaption', "Employee Career Details").trigger('reloadGrid');
        jQuery("#grdCareer").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        jQuery("#grdCareer").jqGrid('navGrid', '#grdCareerpager', { del: false, add: false, edit: false, search: false });
        //      jQuery("#grdCareer").jqGrid('navButtonAdd', "#grdCareerpager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
        //          onClickButton: function() {
        //              myGrid[0].toggleToolbar()
        //          }
        //      });
        //      $("#t_grdCareer").append("<input type='button' id='add' value='Add'  style='height:24px;font-size:-3'/>");
        //      $("#t_grdCareer").append("<input type='button' id='edit' value='Edit' style='height:24px;font-size:-3'/> ");
        //      $("#t_grdCareer").append("<input type='button' id='deletecareer' value='Delete' style='height:24px;font-size:-3'/> ");
        $("#t_grdCareer").append("<button type='button' id='add' value='Add' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/add_icon.png' height=18px;width=18px alt='' /><br/><div></div><span >Add</span></button>");
        $("#t_grdCareer").append("<button type='button' id='careeredit' value='Edit' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/edit_icon.png'height=18px;width=18px alt='' /><br/><div></div><span >Edit</span></button>");
        $("#t_grdCareer").append("<button type='button' id='deletecareer' value='Delete' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/Deactive.jpg'height=20px;width=22px alt='' /><br/><div></div><span >Delete</span></button>");
        if ($('#hdnType').val() == "self") {
            document.getElementById("deletecareer").style.display = "none";
            document.getElementById("careeredit").style.display = "none";
        }
        $("input,button", "#t_grdCareer").click(function(id) {
            if (id.currentTarget.id == "add") {
                // validator.resetForm();
                mode = "add";
                var Request = new Object();
                Request.ID = $("#hdnEmployeeID").val();
                var Response = SendApplicationRequest('<%=EmployeeAppCommands.CHECK_EMP_ISFRESHER%>', Request);
                if (Response.ResponseCommand == "SUCCESS") {
                    alert("Employee is added as fresher, you can't add other career details"); return false;
                }
                document.getElementById("dvCareer").style.display = "";
                clearCareerDetailsData();

            }
            else if (id.currentTarget.id == "careeredit") {
                var id = jQuery("#grdCareer").jqGrid('getGridParam', 'selrow');
                if (id) {
                    mode = "edit";
                    var id = jQuery("#grdCareer").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#grdCareer").jqGrid('getRowData', id);
                    if (ret.IsFresher == "Yes") {
                        alert("Employee is added as fresher, you can't edit "); return false;
                    }
                    document.getElementById("dvCareer").style.display = "";
                    fillCareerDetailsData();
                }
                else { alert("Please select row"); }
            }
            else if (id.currentTarget.id == "deletecareer") {
                var gr = jQuery("#grdCareer").getGridParam('selrow');
                if (gr) {
                    var currPage = jQuery('#grdCareer').jqGrid('getGridParam', 'page');
                    if (confirm('Do you want to delete?') == false) return;
                    var id = jQuery("#grdCareer").jqGrid('getGridParam', 'selrow');
                    if (id) {
                        RemoveCareerEmpdetails(id);
                    }
                    jQuery("#grdCareer").delRowData(gr);
                    //                  jQuery("#grdCareer").jqGrid('setCaption', "Employee Career Details").trigger('reloadGrid');
                    jQuery("#grdCareer").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');

                }
                else alert("Please Select Row to delete!");

            }
        });
    }

    function onCancelCareerDetails() {
        clearCareerDetailsData();
        document.getElementById("dvCareer").style.display = "none";
    }
    function UpdateEmpCareerInfo() {

        if ($("#experience").is(':checked')) {
            if (!ValidateDate($("#txtstdate").val(), $("#txtenddates").val())) { return; }
        }
        var currPage = jQuery('#grdCareer').jqGrid('getGridParam', 'page');
        var Request = new Object();
        var ID = "";
        if (mode == "edit") {
            var id = jQuery("#grdCareer").jqGrid('getGridParam', 'selrow');
            var ret = jQuery("#grdCareer").jqGrid('getRowData', id);
            ID = ret.id;
        }
        else {
            ID = "0";
        }
        Request.ID = ID;
        Request.EmployeeID = $("#hdnEmployeeID").val();
        Request.CompanyName = $("#txtcmpname").val();
        Request.dtStartDate = $("#txtstdate").val();  //$("#txtstdate").val();
        Request.dtEndDate = $("#txtenddates").val();
        if ($("#fresh").is(':checked')) { Request.IsFresher = 'True'; }
        else { Request.IsFresher = 'False'; }
        Request.UpdateBy = $("#hdnLoggedinID").val();
        Request.EmployeeInfoType = document.getElementById("hdnCareerInfo").value;

        var Response = SendApplicationRequest('<%=EmployeeAppCommands.UPDATE_EMPLOYEE_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
            alert('Saved successfully');
            var Request = new Object();
            Request.ID = $("#hdnEmployeeID").val();
            Request.EmployeeInfoType = document.getElementById("hdnCareerInfo").value;
            var Response = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE%>', Request);
            Response.ResponseObject.CareerInfo.width = $("#content").width();
            jQuery("#grdCareer").jqGrid('setGridParam', Response.ResponseObject.CareerInfo);
            //          jQuery("#grdCareer").jqGrid('setCaption', "Employee Career Details ").trigger('reloadGrid');
            onCancelCareerDetails();
            clearCareerDetailsData();
        }
        else {
            alert(Response.Message);
        }
        jQuery("#grdCareer").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');
    }
    function clearCareerDetailsData() {
        stxtstdate.innerHTML = "";
        stxtenddates.innerHTML = "";
        stxtcmpname.innerHTML = "";
        $("#txtcmpname").val("");
        $("#txtstdate").val("");
        $("#txtenddates").val("");
        $("#fresh").attr("checked", true);
        $("#experience").attr("checked", false);
        $("#txtcmpname").attr("disabled", true);
        $("#txtstdate").attr("disabled", true);
        $("#txtenddates").attr("disabled", true);
        $("#fresh").attr("disabled", false);
        $("#experience").attr("disabled", false);
        $("#txtstdate").datepicker('disable');
        $("#txtenddates").datepicker('disable');

    }
    function onCareerchange(id) {

        if (id == "fresh") {
            if ($("#fresh").is(':checked')) {
                $("#txtcmpname").attr("disabled", true);
                $("#txtstdate").attr("disabled", true);
                $("#txtenddates").attr("disabled", true);
                $("#experience").attr("checked", false);
                $("#txtcmpname").val("");
                $("#txtstdate").val("");
                $("#txtenddates").val("");
                $("#txtstdate").datepicker('disable');
                $("#txtenddates").datepicker('disable');
            }
            else {
                $("#txtcmpname").attr("disabled", false);
                $("#txtstdate").attr("disabled", false);
                $("#txtenddates").attr("disabled", false);
                $("#fresh").attr("checked", false);
                $("#txtstdate").datepicker('enable');
                $("#txtenddates").datepicker('enable');
            }
        }
        else {
            if ($("#experience").is(':checked')) {
                $("#txtcmpname").attr("disabled", false);
                $("#txtstdate").attr("disabled", false);
                $("#txtenddates").attr("disabled", false);
                $("#fresh").attr("checked", false);
                $("#txtstdate").datepicker('enable');
                $("#txtenddates").datepicker('enable');
            }
            else {
                $("#txtcmpname").attr("disabled", true);
                $("#txtstdate").attr("disabled", true);
                $("#txtenddates").attr("disabled", true);
                $("#experience").attr("checked", false);
                $("#txtstdate").datepicker('disable');
                $("#txtenddates").datepicker('disable');
            }
        }
    }
    function fillCareerDetailsData() {

        var id = jQuery("#grdCareer").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#grdCareer").jqGrid('getRowData', id);
        $("#txtcmpname").val(ret.CompanyName);
        $("#txtstdate").val(ret.dtStartDate);
        $("#txtenddates").val(ret.dtEndDate);
        if (ret.IsFresher == "Yes") {
            $("#fresh").attr("checked", true);
            $("#txtcmpname").attr("disabled", true);
            $("#txtstdate").attr("disabled", true);
            $("#txtenddates").attr("disabled", true);
            $("#experience").attr("checked", false);
            $("#experience").attr("disabled", true);
            $("#txtstdate").datepicker('disable');
            $("#txtenddates").datepicker('disable');
        }
        else {
            $("#txtcmpname").attr("disabled", false);
            $("#txtstdate").attr("disabled", false);
            $("#txtenddates").attr("disabled", false);
            $("#experience").attr("checked", true);
            $("#fresh").attr("checked", false);
            $("#fresh").attr("disabled", true);
            $("#txtstdate").datepicker('enable');
            $("#txtenddates").datepicker('enable');
        }
    }

    function RemoveCareerEmpdetails(id) {
        var Request = new Object();
        Request.ID = id;
        Request.EmployeeInfoType = document.getElementById("hdnCareerInfo").value;
        var Response = SendApplicationRequest('<%=EmployeeAppCommands.REMOVE_EMPLOYEE_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
            mode = "SUCCESS";
            alert('Deleted successfully');
        }
        else
            alert(Response.Message);
    }
    //END CAREER DETAILS

    // START EMPLOYEE DOCUMENT UPLOAD

    function onDocumentUpload() {

        // $('#hdnEmployeeID').val("3");
        var id = $('#hdnEmployeeID').val();
        if (id != "0") {
            if (confirm('Do you want to upload document?') == false) return;

            var strQ = "ID=" + id;
            if ($('#hdnType').val() != "") {
                retval = window.showModalDialog("Masters/UploadDocument.aspx?" + strQ, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
            }
            else {
                retval = window.showModalDialog("Masters/UploadDocument.aspx?" + strQ, window.self, "dialogHeight:260px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
            }

            if (retval) {
                alert('Document uploaded successfully');
            }
        }
        BindGrid();
    }
    function onDocumentView() {

        var id = jQuery("#grdDocUpl").jqGrid('getGridParam', 'selrow');
        if (id) {
            var ret = jQuery("#grdDocUpl").jqGrid('getRowData', id);
            if ($('#hdnType').val() != "") {
                //                window.location.href = "DownloadFileHandler.ashx?EmployeeID=" + $("#hdnEmployeeID").val() + "&DocumentName=" + ret.documentname;
                window.location.href = "DownloadFileHandler.ashx?EmployeeID=" + $("#hdnEmployeeID").val() + "&DocumentName=" + ret.documentname;

            }
            else {
                //                window.location.href = "../../DownloadFileHandler.ashx?EmployeeID=" + $("#hdnEmployeeID").val() + "&DocumentName=" + ret.documentname;
                window.location.href = "DownloadFileHandler.ashx?EmployeeID=" + $("#hdnEmployeeID").val() + "&DocumentName=" + ret.documentname;

            }
        }
        else
            alert("Select a document to view");

    }

    function onDocumentDelete() {

        var id = jQuery("#grdDocUpl").jqGrid('getGridParam', 'selrow');
        if (id) {
            var ret = jQuery("#grdDocUpl").jqGrid('getRowData', id);
            if (confirm('Do you want to delete?') == false) return;
            var Request = new Object();
            Request.ID = id;
            Request.EmployeeInfoType = document.getElementById("hdnMasterDocs").value;
            ///DELETE EMPLOYEE DOCUMENT INFORMATION FROM DB
            var Response = SendApplicationRequest('<%=EmployeeAppCommands.REMOVE_EMPLOYEE_INFO%>', Request);
            if (Response.ResponseCommand == 'SUCCESS') {
                alert('Document deleted successfully');
            }
            else {
                alert(Response.Message); return;
            }
        }
        else
            alert("Select a document to delete");
        BindGrid();
    }
    function BindGrid() {

        var Request = new Object();
        Request.ID = $('#hdnEmployeeID').val();
        Request.EmployeeInfoType = document.getElementById("hdnMasterDocs").value;
        ///DELETE EMPLOYEE DOCUMENT INFORMATION FROM DB
        var Response = SendApplicationRequest('<%=EmployeeAppCommands.GET_EMPLOYEE%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {

            if (Response.ResponseObject.EmpDocs.datastr == null)
                jQuery("#grdDocUpl").jqGrid('clearGridData');
            else {
                Response.ResponseObject.EmpDocs.pager = "pagerDocUpl";
                Response.ResponseObject.EmpDocs.height = "225";
                Response.ResponseObject.CareerInfo.width = $("#content").width();
                jQuery("#grdDocUpl").jqGrid('setGridParam', Response.ResponseObject.EmpDocs);
              
                jQuery("#grdDocUpl").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
            }
        }
    }

    function LoadEmpDocs(Response) { 

        var myGrid = $('#grdDocUpl');
        Response.ResponseObject.EmpDocs.colModel = [
    		            { name: 'id', index: 'id', width: 60, hidden: true, sorttype: "int" },
    		            { name: 'employeeid', index: 'employeeid', width: 60, hidden: true, sorttype: "int" },
    		            { name: 'documenttitle', index: 'documenttitle', width: 60, editable: true },
    		            { name: 'documentname', index: 'documentname', width: 90, editable: true }
    	            ]

        Response.ResponseObject.EmpDocs.pager = "pagerDocUpl";
        // Response.ResponseObject.EmpDocs.rowNum = -1;
        Response.ResponseObject.EmpDocs.height = "225";
        Response.ResponseObject.EmpDocs.width = $("#content").width();
        myGrid.jqGrid(Response.ResponseObject.EmpDocs);
        //jQuery("#grdDocUpl").jqGrid('setGridHeight', "100%");
//        jQuery("#grdDocUpl").jqGrid('setGridWidth', "100%");
        jQuery("#grdDocUpl").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        jQuery("#grdDocUpl").jqGrid('navGrid', '#pagerDocUpl', { del: false, add: false, edit: false, search: false });
        //      jQuery("#grdDocUpl").jqGrid('navButtonAdd', "#pagerDocUpl", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
        //          onClickButton: function() {
        //          
        //              myGrid[0].toggleToolbar()
        //          }
        //      });
        $("#t_grdDocUpl").closest(".ui-userdata").hide();
    }

    ////////END OF EMPLOYEEMENT DOCUMENTS  //////////////


    ///START ALTIO STAR CTC DETAIS

    function CalculateCTCDetails() {

        var request = new Object();
        request.CTC = $("#txtctc").val();

        var Response = SendApplicationRequest('<%=EmployeeAppCommands.CALCULATE_CTC_DETAILS%>', request);

        var ctc = $("#txtctc").val();
        if (ctc == "") return;
        var monthlyctc = eval(ctc) / 12;
        monthlyctc = Math.round(monthlyctc, 2);
        var yrlbasic = eval(ctc) * 40 / 100;
        yrlbasic = Math.round(yrlbasic, 2);
        var mnthbasic = eval(yrlbasic) / 12;
        mnthbasic = Math.round(mnthbasic, 2);
        $("#txtmonthlyctc").val(monthlyctc);
        $("#txtannualb").val(yrlbasic);
        $("#txtmonthlyb").val(mnthbasic);
        $("#txtannualHRA").val(Math.round(Response.ResponseObject.HRA, 2));
        $("#txtmonthlyHRA").val(Math.round(eval(Response.ResponseObject.HRA) / 12, 2));
        $("#txtannualASA").val(Math.round(Response.ResponseObject.SPL, 2));
        $("#txtmonthlyMSA").val(Math.round(eval(Response.ResponseObject.SPL) / 12, 2));
        $("#txtannualACA").val(Math.round(Response.ResponseObject.CON, 2));
        $("#txtmonthlyMCA").val(Math.round(eval(Response.ResponseObject.CON) / 12, 2));
        $("#txtannualPF").val(Math.round(Response.ResponseObject.PF, 2));
        $("#txtmonthlyPF").val(Math.round(eval(Response.ResponseObject.PF) / 12, 2));
        $("#txtannualbenefits").val(Math.round(Response.ResponseObject.MED, 2));
        $("#txttravel").val(Math.round(Response.ResponseObject.LTA, 2));

//           var ctc = $("#txtctc").val();
//              if (ctc == "") return;
//              var monthlyctc = eval(ctc) / 12;
//              monthlyctc = Math.round(monthlyctc, 2);
//              var yrlbasic = eval(ctc) * 40 / 100;
//              yrlbasic = Math.round(yrlbasic, 2);
//              var mnthbasic = eval(yrlbasic) / 12;
//              mnthbasic = Math.round(mnthbasic, 2);
//        var yrlyhra = eval(yrlbasic) * 40 / 100;
//              yrlyhra = Math.round(yrlyhra, 2);
//              var mnthhra = eval(yrlyhra) / 12;
//             mnthhra = Math.round(mnthhra, 2);
//               var CA = $("#hdnCA").val();
//               var pf = eval(yrlbasic) * 12 / 100;
//               pf = Math.round(pf, 2);
//               var yrlallo = eval(ctc) - eval(yrlbasic) - eval(yrlyhra) - eval(CA) - eval(pf)- eval(mnthbasic) - eval($("#hdnMedicalReimb").val());
//               yrlallo = Math.round(yrlallo, 2);
//               var mntallow = yrlallo / 12;
//               mntallow = Math.round(mntallow, 2);
//               var mnthca = CA / 12;
//               mnthca = Math.round(mnthca, 2);
//               var mnthpf = pf / 12;
//               mnthpf = Math.round(mnthpf, 2);
//               
//               if(monthlyctc!=NaN)
//                   $("#txtmonthlyctc").val(monthlyctc);
//               if (yrlbasic != NaN)
//                   $("#txtannualb").val(yrlbasic);
//               if (mnthbasic != NaN)
//                   $("#txtmonthlyb").val(mnthbasic);
//               if (yrlyhra != NaN)
//                   $("#txtannualHRA").val(yrlyhra);
//               if (mnthhra != NaN)
//                   $("#txtmonthlyHRA").val(mnthhra);
//               if (yrlallo != NaN)
//                   $("#txtannualASA").val(yrlallo);
//               if (mntallow != NaN)
//                   $("#txtmonthlyMSA").val(mntallow);
//               if (CA != NaN)
//                   $("#txtannualACA").val(CA);
//               if (mnthca != NaN)
//                   $("#txtmonthlyMCA").val(mnthca);
//               if (pf != NaN)
//                   $("#txtannualPF").val(pf);
//               if (mnthpf != NaN)
//                   $("#txtmonthlyPF").val(mnthpf);
//              $("#txtannualbenefits").val($("#hdnMedicalReimb").val());
//               $("#txttravel").val(mnthbasic);
    }

    function LoadSalaryDetails(Response) {

        if (Response.ResponseObject.SalaryInfo.id != 0) {
            $("#hdnSalaryID").val(Response.ResponseObject.SalaryInfo.id);
            $("#txtctc").val(Response.ResponseObject.SalaryInfo.ctc);
            $("#txtesop").val(Response.ResponseObject.SalaryInfo.esop);
            CalculateCTCDetails();
        }
    }

    function UpdateSalaryInfo() {
        ;

        var Request = new Object();
        var ID = "";
        if ($("#hdnSalaryID").val() == "") ID = 0;
        else ID = $("#hdnSalaryID").val();

        Request.Id = ID;
        Request.EmployeeId = $("#hdnEmployeeID").val();
        Request.Ctc = $("#txtctc").val();
        Request.Esop = $("#txtesop").val();
        Request.Basic = $("#txtannualb").val();
        Request.EmployeeInfoType = document.getElementById("hdnMasterEmpSalary").value;

        var Response = SendApplicationRequest('<%=EmployeeAppCommands.UPDATE_EMPLOYEE_INFO%>', Request);
        if (Response.ResponseCommand == 'SUCCESS') {
            alert('Saved successfully');
            // $("#btnSave5").attr("disabled", true);
            $("#hdnSalaryID").val(Response.Message);
        }
    }


    ///END ALTIO STAR CTC
    var knt = 0;
    function Upload() {
        if ($('#hdnEmployeeID').val() == "") $('#hdnEmployeeID').val("0");
        var id = $('#hdnEmployeeID').val();
        if (id != "0") {
            if (confirm('Do you want to upload photo?') == false) return;

            var strQ = "ID=" + id;
            if ($("#hdnType").val() != "self") {
                retval = window.showModalDialog("Masters/UploadFile.aspx?" + strQ, window.self, "dialogHeight:230px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
            }
            else {
                retval = window.showModalDialog("Masters/UploadFile.aspx?" + strQ, window.self, "dialogHeight:230px; dialogWidth:540px; resizable:yes; status:no; scroll:no;");
            }

            if (retval) {
                alert('Photo uploaded successfully');
                document.getElementById("hdnPhoto").value = "true";
                if ($("#hdnType").val() != "self") {
                    // setImageDiv('dvImgPhoto', 'imgPhoto', '', "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val() + '&test=te' + inc++, 100, 100);
                    document.getElementById("imgPhoto").src = "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val() + "&a=" + knt;


                }
                else {
                    // setImageDiv('dvImgPhoto', 'imgPhoto', '', "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val() + '&test=te' + inc++, 100, 100);
                    //document.getElementById("imgPhoto").src = "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val();
                    document.getElementById("imgPhoto").src = "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val() + "&a=" + knt;

                }

                knt++;
            }
            document.getElementById("imgPhoto").src = "UploadFileHandler.ashx?mode=employeephoto&ID=" + $("#hdnEmployeeID").val() + "&a=" + knt;
        }
        else {
            alert('Please save the employee details');
            return false;
        }
    }

    function setImageDiv(id, imgID, onclik, path, width, height) {
        $('#' + id).html('');
        $('#' + id).css('width', width);
        if (height == "auto") {
            $('#' + id).css('height', '50px');
        }
        else {
            $('#' + id).css('height', height);
        }
        $('#' + id).addClass('loading');
        var img = new Image();

        $(img).load(function() {
            $(this).hide();
            $('#' + id).removeClass('loading').append(this);
            $(this).fadeIn();
            $(this).attr('id', imgID);
        }).error(function() {
            // notify the user that the image could not be loaded
        }).attr('src', path).css('width', width).css('height', height);
    }
    function onClickload() {
        return false;
    }
    function LoadTeam() {

        var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Choose Team";
        optn.value = "";
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

    function LoadCountry() {
        var Response = SendApplicationRequest("<%=HRAppCommands.COUNTRY_COMBO_DETAILS%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Select Country";
        optn.value = "";
        document.getElementById('cmbcountry').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['CountryName'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbcountry').options.add(optn);
            }
        }
    }

    function LoadMaritalStatus() {
        var Response = SendApplicationRequest("<%=HRAppCommands.GET_MARITALSTATUS_COMBO%>", "");
        var optn = document.createElement("OPTION");
        optn.text = "Select Marital Status";
        optn.value = "";
        document.getElementById('cmbmaritalstatus').options.add(optn);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['MaritalStatus'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbmaritalstatus').options.add(optn);
            }
        }
    }

    function LoadEmployeeType() {
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

    function LoadLocation() {
        $("#cmblocation").empty();

        var optn = document.createElement("OPTION");
        optn.text = "Select Location";
        optn.value = "";
        document.getElementById('cmblocation').options.add(optn);

        if ($("#cmbcountry").val() == "") return;
        var Request = new Object();
        Request.CountryID = $("#cmbcountry").val();
        var Response = SendApplicationRequest("<%=HRAppCommands.GET_LOCATION_COMBO%>", Request, true);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['LocationName'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmblocation').options.add(optn);
            }
        }
    }

    function LoadDesignation() {
        var optn = document.createElement("OPTION");
        optn.text = "Select Designation";
        optn.value = "";
        document.getElementById('cmbdesignation').options.add(optn);
        var Response = SendApplicationRequest("<%=HRAppCommands.DESIGNATIONCOMBO_DETAILS%>", '', true);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['DesignationName'];
                optn.value = arr[i]['ID'];
                document.getElementById('cmbdesignation').options.add(optn);
            }
        }
    }
</script>

<script type="text/javascript">
    $(document).ready(function() {
        $('#t_grdAcademic').css('padding', '10px 0px');
        $('#t_grdCareer').css('padding', '10px 0px');

        $('.grdPager input[type=text]').css('width', '40px');
        $('.grdPager select').css('width', '50px');
        $('.grdPager select').css('margin-left', '15px');
        $('#grdAcademicpager_center').css('width', '500px');
        $('#grdCareerpager_center').css('width', '500px');
        $('#pagerDocUpl_center').css('width', '500px');
    });
</script>
</html>
