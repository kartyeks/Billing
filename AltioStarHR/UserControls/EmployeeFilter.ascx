<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false"  CodeBehind="EmployeeFilter.ascx.cs" Inherits="AltioStarHR.UserControls.EmployeeFilter" %>
<style type="text/css">
    .style1
    {
        width: 25px;f
    }
    .style6
    {
        width: 254px;
    }
    .style7
    {
        width: 16%;
    }
    .style8
    {
        width: 208px;
    }
</style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

  <link href="../resources/css/newcss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
 <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>
 <script src="Resources/js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
<div id="filterControl" style="width:100%;" runat="server" >
<div id='ucControl' runat="server" style="background-color:#a4cd0f">
  <%--<fieldset  >--%>
<%-- <legend id='lblFilters$D1'  class="label2" >Employee Filter </legend>--%>
  <div id="dvHideFilter" style="background-color:Transparent; " runat="server" >
                    <div id='dvFilter' runat="server" >
                    <table style="width:100%;background-color:#a4cd0f" >
                        <tr>
                            <td  style="width:100%" valign="top">
                                <table style="width:100%">
                                 <tr>
                                        <td height="40" colspan="2" class="family">
                                            First Name
                                        </td>
                                        <td height="40">
                                        <input id="txtFirstn"  type="text" style="width:225px;border:1px solid silver" maxlength="100" tabindex="5" runat="server" class="family" />

                                        </td>
                                     
                                        <td height="40" colspan="2" style="width:10%" class="family">
                                            Last Name
                                        </td>
                                        <td height="40" >
                                       <input id="txtLastn"  type="text" style="width: 225px;border:1px solid silver" maxlength="100" tabindex="5" runat="server"  class="family"/>

                                        </td>
                                     
                     </tr>
                     
                      <tr>
                    <td runat="server" colspan="2">
                       <span id='Span1' style="white-space:nowrap" class="family">Employee Code: </span>
                    </td>
                    <td class="family">
                     <input id="txtEmpCode"  type="text"  maxlength="4" tabindex="5" runat="server"  style="width: 225px;border:1px solid silver" class="family"/>
                    </td>
                    <td id='td2' colspan="2" runat="server" ><span  align="right" class="label family" id='Span'  >Designation: </span>
                    </td><td>
                   <select id="cmbDesignation"  tabindex="4" class="family" runat="server"   style="width: 235px;border:1px solid silver" > 
                    </select> 
                    </td>
                    
                    </tr>
                    <%-- </table>
                      <table style="width: 700px">--%>
                              
                    <tr>
                    <td id='tdCountry' runat="server" colspan="2">
                    <span style="white-space:nowrap" id='lblBranch' class="family">Country: </span>
                    </td>
                    <td class="style6">
                     <select id="cmbCountry"  style="width:235px;border:1px solid silver" tabindex="2" runat="server" class="family" onchange="return LoadLocation();"  > 
                    </select> 
                    </td>
                    
                    <td  id='tdLocation' colspan="2" runat="server" class="style7" >
                    <span  style="white-space:nowrap" id='lblLocation' class="family">&nbsp; Location:
                    </span>
                    </td><td>
                     <select id="cmbLocation"  style="width:235px;border:1px solid silver" tabindex="5"  runat="server"  class="family"> 
                    </select> 
                    </td>
                    
                    </tr>
                    <tr>
                    <td height="40" colspan="2" class="family">
                                           Team
                                        </td>
                                        <%--<td height="40" class="style8">--%>
                                        <td height="40" >
                               <select id="cmbTeam" name="cmbTeam"  style="width:235px;border:1px solid silver" tabindex="1" class="family" runat="server"  > 
                             </select> 
                                        </td>
                                        <td id="scmbTeam" height="40" class="family">
                                        </td>
                    </tr>
                   </table>
                   </td>
                   </tr>
                    </table>
                     </div>

</div>
 <%--</fieldset>--%>
 </div>
<script type="text/javascript">
    jQuery(document).ready(function() {

        document.getElementById("<%=ClientID%>_dvHideFilter").style.display = "";
        LoadCountry();
        LoadLocation();
        LoadDesignation();
        LoadTeam();

        document.getElementById('<%=ClientID%>_cmbDesignation').selectedIndex = 0;
        document.getElementById('<%=ClientID%>_cmbCountry').selectedIndex = 0;
        document.getElementById('<%=ClientID%>_cmbLocation').selectedIndex = 0;
        document.getElementById('<%=ClientID%>_cmbTeam').selectedIndex = 0;
    });

function LoadTeam() {
  var objName = document.getElementById('<%=ClientID%>_cmbTeam');
       objName.options.length = 0;
         var optn = document.createElement("OPTION");
         optn.text = "Choose Team";
         optn.value = "0";
         objName.options.add(optn);
    var Response = SendApplicationRequest("<%=HRAppCommands.TEAM_COMBO_DETAILS%>", "");
         if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                objName = document.getElementById('<%=this.ClientID%>_cmbTeam');
                optn = document.createElement("OPTION");
                optn.text = arr[i]['Value'];
                optn.value = arr[i]['ID'];
                objName.options.add(optn);
            }
        }
  }
  
 function LoadCountry() {
     var objName = document.getElementById('<%=this.ClientID%>_cmbCountry');
       objName.options.length = 0;
         var optn = document.createElement("OPTION");
         optn.text = "Choose Country";
         optn.value = "0";
         objName.options.add(optn);
     var Response = SendApplicationRequest("<%=HRAppCommands.COUNTRY_COMBO_DETAILS%>", "");
         if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                objName = document.getElementById('<%=this.ClientID%>_cmbCountry');
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['CountryName'];
                optn.value = arr[i]['ID'];
                objName.options.add(optn);
            }
        }
  }
  
   function LoadLocation() {
       $("#cmbLocation").empty();
       var objName = document.getElementById('<%=this.ClientID%>_cmbLocation');
       objName.options.length = 0;
         var optn = document.createElement("OPTION");
         optn.text = "Choose Location";
         optn.value = "0";
         objName.options.add(optn);
       if (document.getElementById('<%=this.ClientID%>_cmbCountry').value == "0") return;
        var Request = new Object();
        Request.CountryID = document.getElementById('<%=this.ClientID%>_cmbCountry').value;
        var Response = SendApplicationRequest("<%=HRAppCommands.GET_LOCATION_COMBO%>", Request, true);  
           if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
                var objName = document.getElementById('<%=this.ClientID%>_cmbLocation');
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['LocationName'];
                optn.value = arr[i]['ID'];
                objName.options.add(optn);
            }
        }
  }


 function LoadDesignation() {
   var objName = document.getElementById('<%=this.ClientID%>_cmbDesignation');
       objName.options.length = 0;
         var optn = document.createElement("OPTION");
         optn.text = "Choose Designation";
         optn.value = "0";
         objName.options.add(optn);
     var Response = SendApplicationRequest("<%=HRAppCommands.DESIGNATIONCOMBO_DETAILS%>", '', true);
         if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            var arr = Response.ResponseObject;
            for (var i = 0; i < arr.length; ++i) {
             var objName = document.getElementById('<%=this.ClientID%>_cmbDesignation');
                var optn = document.createElement("OPTION");
                optn.text = arr[i]['DesignationName'];
                optn.value = arr[i]['ID'];
                objName.options.add(optn);
            }
        }
  }
   
  function ClearItems(id) {

      jQuery('#<%=this.ClientID%>_txtFirstn').val("");
      jQuery('#<%=this.ClientID%>_txtLastn').val("");
      jQuery('#<%=this.ClientID%>_txtEmpCode').val("");

      document.getElementById('<%=this.ClientID%>_cmbDesignation').selectedIndex = 0;
      document.getElementById('<%=this.ClientID%>_cmbCountry').selectedIndex = 0;
      LoadLocation();
      document.getElementById('<%=this.ClientID%>_cmbLocation').selectedIndex = 0;
      document.getElementById('<%=this.ClientID%>_cmbTeam').selectedIndex = 0;
  }    


  
</script> 

 </div>