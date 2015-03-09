<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Master_Employees.aspx.cs" Inherits="AltioStarHR.Masters.Master_Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
    
<head>

<title>Employee</title>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
         <!-- Library CSS files -->
         <style type="text/css">
        html, body, div, span, applet, object, iframe,h1, h2, h3, h4, h5, h6, p, blockquote, pre,a, abbr, acronym, address, big, cite, code,del, dfn, em, img, ins, kbd, q, s, samp,small, strike, strong, sub, sup, tt, var,b, u, i, center,dl, dt, dd, ol, ul, li,fieldset, form, label, legend,table, caption, tbody, tfoot, thead, tr, th, td,article, aside, canvas, details, embed, figure, figcaption, footer, header, hgroup, menu, nav, output, ruby, section, summary,time, mark, audio, video {	margin: 0;	padding: 0;	border: 0;	font-size: 100%;	font: inherit;	vertical-align: baseline;}/* HTML5 display-role reset for older browsers */article, aside, details, figcaption, figure, footer, header, hgroup, menu, nav, section {	display: block;}body {	line-height: 1;}ol, ul {	list-style: none;}blockquote, q {	quotes: none;}blockquote:before, blockquote:after,q:before, q:after {	content: '';	content: none;}table {	border-collapse: collapse;	border-spacing: 0;}
        
        
        .pimPane .head, .pimPane .inner {
                margin-left: 220px;
        }
        .box .inner {
                background: #f7f6f6;
                padding: 15px;
                border: 1px solid #dedede;
                border-top: none;
                -moz-border-radius-bottomright: 3px;
                -webkit-border-bottom-right-radius: 3px;
                border-bottom-right-radius: 3px;
                -moz-border-radius-bottomleft: 3px;
                -webkit-border-bottom-left-radius: 3px;
                border-bottom-left-radius: 3px;
                overflow: hidden;
                margin-bottom: 19px;
        }
        </style>
        <!-- Custom CSS files -->
<link href="../../../Resources/css/main.css" rel="stylesheet" type="text/css" />
<link href="../../../Resources/css/mycss/jquery-autocomplete.css" rel="stylesheet" type="text/css" />
<link href="../../../Resources/css/mycss/orangehrm.datepicker.css" rel="stylesheet" type="text/css" />
<link href="../../../Resources/css/mycss/jquery-ui-1.8.21.custom.css" rel="stylesheet"
type="text/css" />
        
<script src="../Resources/js/myjs/archive.js" type="text/javascript"></script>
<script src="../../../../Resources/js/myjs/Parsley.js-1.2.2/parsley.extend.js" type="text/javascript"></script>
<script src="../../../../Resources/js/myjs/Parsley.js-1.2.2/parsley.js" type="text/javascript"></script>
<script src="../../../Resources/js/myjs/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../../../Resources/js/myjs/javascript.js" type="text/javascript"></script>
<script src="../../../Resources/js/myjs/bootstrap-modal.js" type="text/javascript"></script>
<script type="text/javascript" src="../Resources/js/jquery-ui-1.8.16.custom.min.js"></script>
        
    
</head>
    <body>
      
        <div id="wrapper">
          <div class="box">
 <div class="head">
        <h1>Add Employee</h1>
    </div>   
<div id="content">

                  
<div class="box pimPane" id="employee-details">
    
    
    <div id="sidebar">

        <div id="profile-pic" >
            <h1>asdsdfg asdfgdf</h1>
                
                <div class="imageHolder" style="display:none">
                        <a href="" title="Change Photo" class="tiptip">
                        <img alt="Employee Photo" src="" border="0" id="empPic" width="200" height="150"/></a>
                </div>   
                 
        </div> <!-- profile-pic -->        
            
        <ul id="sidenav">
                <li><a href="Master_Employees.aspx">Employee Details</a></li>
                <li><a href="">Salary Details</a></li>
              <%--  <li><a href="">Contact Details</a></li>
                <li><a href="">Emergency Contacts</a></li>
                <li><a href="">Dependents</a></li>
                <li><a href="">Immigration</a></li>
                <li><a href="">Job</a></li>
                <li><a href="">Report-to</a></li>
                <li><a href="">Qualifications</a></li>
                <li><a href="">Memberships</a></li>--%>
        </ul>

    </div> <!-- sidebar -->
    
    <div class="personalDetails" id="pdMainContainer">
        
        <div class="head">
            <h1>Employee Details</h1>
        </div> <!-- head -->
    
        <div class="inner">

<div class="message success fadable">
Successfully Saved   
    <a href="#" class="messageCloseButton">Close</a>
</div>
         <form id="frmEmpPersonalDetails" method="post" action="" runat="server" parsley-validate>
                <fieldset>
                   <ol>
                        <li class="line nameContainer">
                            <label for="Full_Name" class="hasTopFieldHelp">Full Name</label>
                            <ol class="fieldsInLine">
                                <li>
                                    <div class=""><em>*</em> First Name</div>
                                    <input type="text" name="personal[txtEmpFirstName]" class="" maxlength="30" title="First Name" id="personal_txtEmpFirstName" runat="server" required  />
                                    </li>
                                <li>
                                    <div class=""><em>*</em>Last Name</div>
                                    <input value="" type="text" name="personal[txtEmpMiddleName]" class="" maxlength="30" title="Middle Name" id="personal_txtEmpMiddleName" runat="server" required />                                
                                    </li>
                                <li>
                                    <div class=""><em>*</em>Initial </div>
                                    <input type="text" name="personal[txtEmpLastName]" class="" maxlength="30" title="Last Name" id="personal_txtEmpLastName" runat="server" required />                                
                                    </li>
                            </ol>    
                        </li>
                    </ol>
                    <ol>
                        <li>
                            <label for="personal_txtEmployeeId">Employee ID</label>
                            <input type="text" name="personal[txtEmployeeId]" maxlength="10" class="" id="personal_txtEmployeeId" runat="server" required/> 
                            </li>
                        <li>
                            <label for="personal_txtOtherID">Employee Code</label>
                            <input type="text" name="personal[txtOtherID]" maxlength="30" class="" id="personal_txtOtherID" runat="server" required/>
                            </li>
                        <li>
                            <label for="personal_DOB">Date of Birth</label>
                            <input id="personal_DOB" type="text" name="personal[DOB]" class="" required/> 
                            <script type="text/javascript">
                            $(function() {        
                                    $("#personal_DOB").datepicker({
                                    showOn: "button",
                                    buttonImage: "../Resources/Images/mycalendar.png",
                                    buttonImageOnly: true,
                                    changeMonth: true,
                                    changeYear: true,
                                    showTimePicker: false,
                                    yearRange: '1930:2050'
                                    });
                                    $("#personal_DOB").datepicker("option", "dateFormat", 'dd/mm/yy');            
                                    });    
                            </script>
                        </li>
                   </ol>
    <ol>
        <li class="radio" >
            <label for="personal_optGender">Gender</label>
            <ul class="radio_list">
                 <li><input name="personal[optGender]" type="radio" value="1" id="personal_optGender_1" checked="checked" class="" />&nbsp;
                     <label for="personal_optGender_1">Male</label>
                 </li>
                 <li>
                     <input name="personal[optGender]" type="radio" value="2" id="personal_optGender_2" class="" />&nbsp;
                     <label for="personal_optGender_2" required>Female</label>
                 </li>
             </ul>                        
         </li>
         
         <li>
                <label for="personal_cmbMarital" >Marital Status</label>
                <select name="personal[cmbMarital]" class="" id="personal_cmbMarital" runat="server" required>
                <option value="" selected="selected">-- Select --</option>
                <option value="1">Single</option>
                <option value="2">Married</option>
                <option value="3">Other</option>
                </select>                        
        </li>
                        
        <li><label for="PAddress">Permenent Address</label>
                <textarea name="txtPAddress" id="txtPAddress" rows="3" cols="35"  runat="server" required></textarea>
        </li>
        <li><label for="CAddress">Current Address</label>
                <textarea name="txtCAddress" id="txtCAddress" rows="3" cols="35"  runat="server" required></textarea>
        </li>
        <li><label for="Mobile">Mobile Number</label>
                 <input class="" maxlength="10" type="text" name="Mobile"  id="Mobile" style="width:200px" onkeypress="return isNumberKey(event)"  runat="server" required/>
        </li>
        <li><label for="Emergency">Emergency Number</label>
                 <input class="" maxlength="10" type="text" name="Emergency"  id="Emergency" style="width:200px" onkeypress="return isNumberKey(event)"  runat="server" required/>
        </li>
        <li><label for="EmailID">Email ID</label>
                 <input class="" maxlength="100" type="text" name="EmailID"  placeholder="abc@gmail.com"  id="EmailID" style="width:200px" runat="server" required />
                        <asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Enter Valid Email ID" ControlToValidate="EmailID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </li>
        <li><label for="photofile">Photograph</label>
                <input class="" type="file" name="photofile" id="photofile" runat="server" required/>
                <label class="fieldHelpBottom"/>Accepts jpg, .png, .gif up to 1MB. Recommended dimensions: 200px X 200px
        </li>
       <li class="required new"> <em>*</em> Required field                        
        </li>
     </ol>    
                                            
             <p>
             <input type="submit" class="" id="btnSaveDetails" value="Save" runat="server"  />
           <%-- <input type="button" class="reset" id="resetBtn" value="Cancel" runat="server" onclick="canceldetails()"/>--%>
             </p>
                    
                </fieldset>
            <input type="hidden" id='hdnmsid' runat="server" />
            <input type="hidden" id='hdndob' runat="server" />
            <input type="hidden" id='hdngenderval' runat="server" />
            
        </form>

            
        </div> <!-- inner -->
        
    </div> <!-- pdMainContainer -->
    


<script type="text/javascript">

function isNumberKey(evt)
{
  var charCode = (evt.which) ? evt.which : event.keyCode;
  if (charCode != 46 && charCode > 31 
    && (charCode < 48 || charCode > 57))
     return false;

  return true;
}
var lang_processing = 'Processing';
$(document).ready(function() {
      $('#btnSaveDetails').click(function() {
      $("#btnSave").val(lang_processing);
      
          var val = document.getElementById('personal_cmbMarital').value;
          document.getElementById('hdnmsid').value = val;
          var val1=document.getElementById('personal_DOB').value;
          document.getElementById('hdndob').value = val1;
    });
     $("div.fadable").delay(2000)
    .fadeOut("slow", function () {
        $("div.fadable").remove();
    });
    clearLabels();
});

</script>    


</div> <!-- employee-details -->

            </div> <!-- content -->
        </div> <!-- wrapper -->
  </div>
 <!-- footer -->        
    
  </body>
  <script type="text/javascript">
    function clearLabels() {
    $("#personal_txtEmpFirstName").val("");
    $("#personal_txtEmpMiddleName").val("");
    $("#personal_txtEmpLastName").val("");
    $("#personal_txtEmployeeId").val("");
    $("#personal_txtOtherID").val("");
    $("#personal_DOB").val("");
    $("#txtPAddress").val("");
    $("#txtCAddress").val("");
    $("#Mobile").val("");
    $("#Emergency").val("");
    $("#EmailID").val("");
    $("#photofile").val("");
  } 
  </script>
</html>
