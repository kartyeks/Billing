<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payroll.aspx.cs"
    Inherits="AltioStarHR.Payroll.Payroll" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payroll</title>
    <base target="_self" />    
    <link type="text/css" href="../Resources/css/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/style.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="Resources/js/jquery-ui-1.8.15.custom.js"></script>
    <script type="text/javascript" src="Resources/js/jquery-ui-1.8.custom.min.js"></script>
    <script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>
    <script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>
    <script type="text/javascript" src="Resources/js/Webutility.js"></script>
    <script type="text/javascript" src="Resources/js/toolbar.js"></script>
    <script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="Resources/js/jquery.validate.js"></script>
    <script src="Resources/js/jquery.ui.button.js" type="text/javascript"></script>
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    
    </style>
    <%-- ReSharper disable once Html.IdNotResolved --%>
    <%-- ReSharper disable once Html.IdNotResolved --%>
    <%-- ReSharper disable once Html.IdNotResolved --%>
    <%-- ReSharper disable Html.IdNotResolved --%>
    <script type="text/javascript">
    
      var mode = "";
        var varYear="";
        var varMonth = "";
        var fullDate;
        var currMonth;
        var currYear;
        var exportExcel = false;
      var strQr;
      jQuery(document).ready(function() {
        ////  LoadPermits();

          $('#btnCancel').click(function() {
              onCancel();
          });

          fullDate = new Date();
          currMonth = parseInt(fullDate.getMonth()) + 1;
          currYear = fullDate.getFullYear();
          $("#cmbMonth").val(currMonth);
          $("#txtYear").val(currYear);
          var request = new Object();
          request.Month = $("#cmbMonth").val();
          request.Year = $("#txtYear").val();
          request.UpdatedBy = $("#hdnEmployeeID").val();

          request.SessionID = $("#hdnSessionID").val();
          request.UniqueID = ($("#cmbMonth").val() + $("#txtYear").val());
          var myGrid = $('#list');
          var response = SendApplicationRequest('<%=PayrollAppCommands.GETPAYROLL_DETAILS%>', request, true);
          response.ResponseObject.colModel = [
              { name: 'ID', index: 'ID', width: 20, hidden: true, sorttype: "int" },
              { name: 'EmployeeID', index: 'EmployeeID', width: 100, hidden: true, editable: true },
              { name: 'EmployeeName', index: 'EmployeeName', width: 300, editable: true },
              { name: 'EmployeeCode', index: 'EmployeeCode', width: 100, editable: true },
              { name: 'Team', index: 'Team', width: 200, editable: true },
              { name: 'PresentDays', index: 'PresentDays', width: 100, editable: true },
              { name: 'GrossSalary', index: 'GrossSalary', width: 200, editable: true },
              { name: 'Deductions', index: 'Deductions', width: 200, editable: true },
              { name: 'NetSalary', index: 'NetSalary', width: 200, editable: true },
              { name: 'isPosted', index: 'isPosted', width: 200, editable: true },
              { name: 'isAnnual', index: 'isAnnual', width: 200, editable: true, hidden: true },
              { name: 'isAnnualSingle', index: 'isAnnualSingle', width: 200, editable: true, hidden: true }
          ];
          response.ResponseObject.caption = 'Payroll';
          myGrid.jqGrid(response.ResponseObject);
          jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
          jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
          jQuery("#list").jqGrid('navButtonAdd', "#pager", {
              caption: "Toggle",
              title: "Toggle Search Toolbar",
              buttonicon: 'ui-icon-pin-s',
              onClickButton: function() {
                  myGrid[0].toggleToolbar();
              }
          });

          //          $('#box').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
          $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "902px" });


//          $("#list").closest(".ui-jqgrid-bdiv").height("auto");

          jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
          $("#t_list").append("<button type='button' id='post' value='Post' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/post.png' height=18px;width=18px alt='' /><br/><div></div><span>Post</span></button>");
          $("#t_list").append("<button type='button' id='viewsalary' value='View Salary Details' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view_salary_details.png' height=18px;width=18px alt='' /><br/><div></div><span>View Salary Details</span></button>");

          $("#t_list").append("<button type='button' id='viewsalaryreg' value='View Salary Register' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/view_salary_register.png' height=18px;width=18px alt='' /><br/><div></div><span>View Salary Register</span></button>");
          $("#t_list").append("<button type='button' id='refresh' value='Refresh' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/refresh_icon.png' height=18px;width=18px alt='' /><br/><div></div><span>Refresh</span></button>");
          
//          $("#t_list").append("<input type='button' id='post' value='Post'  style='font-size:12px;font-family:arial;margin:8px;'/> ");
//          $("#t_list").append("<input type='button' id='viewsalary' value='View Salary Details'  style='font-size:12px;font-family:arial;margin:8px;'/> ");
//          $("#t_list").append("<input type='button' id='viewsalaryreg' value='View Salary Register'  style='font-size:12px;font-family:arial;margin:8px;'/> ");
//          $("#t_list").append("<input type='button' id='refresh' value='Refresh'  style='font-size:12px;font-family:arial;margin:8px;'/> ");

          fillAnnual();

////          if ($('#hdnEmployeeID').val() != "1") {
////              onGetPermissionDisplay();
////          }

          $("input,button", "#t_list").click(function(id) {
              if (id.currentTarget.id == "view") {
                  var gid = jQuery("#list").jqGrid('getGridParam', 'selrow');
                  if (gid) {
                      document.getElementById("dvannualbenifit").style.display = "";
                      $('#dvannualbenifit').dialog({
                          height: 400,
                          width: 800,
                          modal: true
                      });
                      LoadannualBenifits();
                  }
                  else {
                      alert('Select Employee');
                      return;
                  }
              }
              else if (id.currentTarget.id == "refresh") {
                  OnRefresh();
              }
              else if (id.currentTarget.id == "viewsalary") {
                  gid = jQuery("#list").jqGrid('getGridParam', 'selrow');
                  if (gid) {
                      ret = jQuery("#list").jqGrid('getRowData', gid);
                      month = '0';
                      var monthrep = '';
                      cmb = document.getElementById("cmbMonth");
                      if (cmb.selectedIndex > -1) {
                          month = cmb.options[cmb.selectedIndex].value;
                          monthrep = $("#cmbMonth option:selected").text();
                      }
                      strQr = "rtype=rdlcSalaryDetails&Month=" + month + "&employeeid=" + ret.EmployeeID + "&Year=" + document.getElementById("txtYear").value + "&MonthRep=" + monthrep + "&sessionid=" + $("#hdnSessionID").val() + "&unqid=" + ($("#cmbMonth").val() + $("#txtYear").val());
                      window.showModalDialog("default.aspx?serve=rdlcReportViewer&" + strQr, window.self, "dialogHeight:750px; dialogWidth:1000px; resizable:yes; status:no;");
                  }
                  else {
                      alert('Select Employee');
                      return;
                  }
              }
              else if (id.currentTarget.id == "viewsalaryreg") {
                  var ret = jQuery("#list").jqGrid('getRowData', id);
                  var month = '0';
                  var cmb = document.getElementById("cmbMonth");
                  if (cmb.selectedIndex > -1) {
                      month = cmb.options[cmb.selectedIndex].value;
                  }
                  strQr = "rtype=rdlcSalaryRegister&Month=" + month + "&Year=" + document.getElementById("txtYear").value + "&sessionid=" + $("#hdnSessionID").val() + "&unqid=" + ($("#cmbMonth").val() + $("#txtYear").val());
                  window.showModalDialog("default.aspx?serve=rdlcReportViewer&" + strQr, window.self, "dialogHeight:750px; dialogWidth:1000px; resizable:yes; status:no;");
              }
              else if (id.currentTarget.id == "post") {
                  var lista = jQuery("#list").jqGrid('getRowData');

                  if (lista.length > 0) {
                      request = new Object();
                      //if (confirm('Do you want to post?') == false) return;
                      var reta = jQuery("#list").jqGrid('getRowData', lista[0].ID);
                      if (reta.isPosted == "True") {
                          if (confirm('Salary for the month has been posted. Do you wish to post again?') == false) {
                              $("#post").attr('disabled', '');
                              return;
                          }
                      }
                      else {
                          if (confirm('Do you want to post?') == false) return;
                      }
                      request.SessionID = $("#hdnSessionID").val();
                      request.UniqueID = ($("#cmbMonth").val() + $("#txtYear").val());
                      request.Month = $("#cmbMonth").val();
                      request.Year = $("#txtYear").val();
                      request.IsAnualbenifitsincluded = $("#chkisannual").is(':checked');
                      response = SendApplicationRequest('<%=PayrollAppCommands.UPDATEPAYROLL_DETAILS%>', request, true);
                      alert(response.Message);
                      if (response.ResponseCommand == 'SUCCESS') {
                          //$("#post").attr('disabled', '');
                          $("#cmbMonth").attr("disabled", true);
                          $("#txtYear").attr("disabled", true);
                          OnRefresh();
                          
                      }

                  }
              }
          });
          $("#searchForm").validate({
              rules: {
                  cmbMonth: {
                      required: true
                  },
                  txtYear: {
                      required: true,
                      number: true
                  }
              },
              messages: {
                  cmbMonth: {
                      required: "Select Month"
                  },
                  txtYear: {
                      required: "Enter Year",
                      number: "Invalid Year"
                  }
              },
              errorPlacement: function(error, element) {
                  error.appendTo(element.parent().next());
              },

              submitHandler: function() {
                  request = new Object();
                  request.Month = $("#cmbMonth").val();
                  request.Year = $("#txtYear").val();
                  request.IsPreviousLOP = (document.getElementById("hdnIsPreviousLOP").value == "true" ? true : false);
                  request.UpdatedBy = $("#hdnEmployeeID").val();
                  request.SessionID = $("#hdnSessionID").val();
                  request.UniqueID = ($("#cmbMonth").val() + $("#txtYear").val());

                  //request.IsAnualbenifitsincluded = $("#chkisannual").is(':checked');
                  if (!OnValidate()) return;
                  response = SendApplicationRequest('<%=PayrollAppCommands.GETPAYROLL_DETAILS%>', request, true);
                  if (response.ResponseObject.datastr == null)
                      jQuery("#list").jqGrid('clearGridData');
                  else {
                      response.ResponseObject.caption = 'Payroll';
                      jQuery("#list").jqGrid('setGridParam', response.ResponseObject);
                      //                      jQuery("#list").jqGrid('setCaption', "Payroll").trigger('reloadGrid');
                      jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
                      $("#btnSearch").attr("disabled", true);
                      $("#cmbMonth").attr("disabled", true);
                      $("#txtYear").attr("disabled", true);
                      fillAnnual();
                  }
              }
          });
      });
      function fillAnnual() {
          var lista = jQuery("#list").jqGrid('getRowData');
          if (lista.length > 0) {
              if (lista[0].isAnnual.toLowerCase() == 'true') {
                  $("#chkisannual").attr("disabled", true);
              }
              else {
                  $("#chkisannual").attr("disabled", false);
              }
              if (lista[0].isAnnualSingle.toLowerCase() == 'true') {
                  $("#chkisannual").attr("checked", true);
              }
              else {
                  $("#chkisannual").attr("checked", false);

              }
              if (lista[0].isPosted.toLowerCase() == 'true') {
                  $("#chkisannual").attr("disabled", true);
              }
              else {
                  $("#chkisannual").attr("disabled", false);
              }
          }
      } 
   function OnRefresh(){
    var lista = jQuery("#list").jqGrid('getRowData');
   if(lista.length>0){
        var request=new Object();
                      request.Month=$("#cmbMonth").val();
                      request.Year=$("#txtYear").val();
                      request.IsPreviousLOP=(document.getElementById("hdnIsPreviousLOP").value=="true"?true:false);
                      request.UpdatedBy = $("#hdnEmployeeID").val();
                      request.SessionID=$("#hdnSessionID").val();
                      request.UniqueID = ($("#cmbMonth").val() + $("#txtYear").val());
                      request.IsAnualbenifitsincluded = $("#chkisannual").is(':checked');
                      if(!OnValidate()) return;
                      var response = SendApplicationRequest('<%=PayrollAppCommands.GETPAYROLL_DETAILS%>', request, true);
                      if(response.ResponseObject.datastr==null)
		                        jQuery("#list").jqGrid('clearGridData');
		                else{
		                    response.ResponseObject.caption = 'Payroll';
                        jQuery("#list").jqGrid('setGridParam',response.ResponseObject);
//                        jQuery("#list").jqGrid('setCaption', "Payroll").trigger('reloadGrid');
                        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
                        $("#btnSearch").attr("disabled", true);
                        $("#cmbMonth").attr("disabled", true);
                        $("#txtYear").attr("disabled", true);
                        fillAnnual();
                        }
      }   
  }
           
        function clearGrid(){
            jQuery("#list").jqGrid('clearGridData');
            fullDate = new Date();
            currMonth = parseInt(fullDate.getMonth()) + 1;
            currYear = fullDate.getFullYear();
            $("#cmbMonth").val(currMonth);
            $("#txtYear").val(currYear);
           $("#cmbMonth").attr("disabled", false);
            $("#txtYear").attr("disabled", false);
         //$("#post").attr("disabled", false);
         $("#btnSearch").attr("disabled", false);
         $("#cmbMonth").attr("disabled", false);
         $("#txtYear").attr("disabled", false);
        }
        function getGridDisplay(){
                jQuery("#list").jqGrid('clearGridData');
        }
        
        function OnValidate(){
            if (document.getElementById("txtYear").value == '') {
            alert("Enter Year");document.getElementById("txtYear").focus();
            return false;
            }
            if (document.getElementById("txtYear").value.length < 4) {
                alert("Invalid Year");document.getElementById("txtYear").focus();
                return false;
            }
            if (eval(document.getElementById("txtYear").value) > parseInt(currYear)) {
                alert("Invalid Year");document.getElementById("txtYear").focus();
                return false;
            }
            var cmb = document.getElementById("cmbMonth");
            if (cmb.selectedIndex > -1) {
               var smonth = eval(cmb.options[cmb.selectedIndex].value);
                if (eval(document.getElementById("txtYear").value) == parseInt(currYear) && smonth > parseInt(currMonth)) {
                    alert("Invalid Year / Invalid Month");
                    return false;
            }
            }
                return true;
       }

        function LoadPermits() {
            var response = LoadPermissions($('#hdnmodule').val(), $('#hdnEmployeeID').val());
            if (response != null) {
                $('#hdnApplyPermit').val(response['Apply']);
                $('#hdnApprovlPermit').val(response['Approvals']);
                $('#hdnViewPermit').val(response['ViewMode']);
            }
        }
        function onGetPermissionDisplay() {
            document.getElementById("post").style.display = "none";
       if (document.getElementById("hdnApplyPermit").value == "true") {
            document.getElementById("post").style.display = "";
       }
       if (document.getElementById("hdnApprovlPermit").value == "true") {
            document.getElementById("post").style.display = "";
        }
    }   
    
    function LoadannualBenifits(){    
        var myGrid1 = $('#annualbenifit');
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        var ret = jQuery("#list").jqGrid('getRowData', id);
        var empid=ret.EmployeeID;
        var request = new Object();
        request.Month =$("#cmbMonth").val();
        request.Year = $("#txtYear").val();;
        request.EmployeeID = empid;
        var response = SendApplicationRequest('<%=PayrollAppCommands.GETANNUL_BENIFITS%>', request, true);
        if (response.ResponseObject != null) {
            response.ResponseObject.colModel = [
                { name: 'id', index: 'id', hidden: true, sorttype: "int" },
                { name: 'name', index: 'name' },
                { name: 'amount', index: 'amount' }
            ];

            response.ResponseObject.height = 150;
            response.ResponseObject.width = 700;
            myGrid1.jqGrid(response.ResponseObject);
            jQuery("#annualbenifit").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
        }
        else {
            jQuery("#annualbenifit").jqGrid('clearGridData');
        }
    }
    function onCancel() {
        $("#dvannualbenifit").dialog('close');
    }
    
    </script>
    <%-- ReSharper restore Html.IdNotResolved --%>

</head>
<body>
    <form id="searchForm" method="get" action="">
    <%--<div class="header_title2">--%>
<%--    <div style="background-color:#00daf5;width:885px;margin-left:1%;height:25px;padding-left:2%;font-family:Calibri;font-weight:bold;color:White;padding-top:1%;font-size:14px">
            Payroll</div>--%>
            <div style="position:relative;width:945px">
   <img alt="" src="Resources/Images/NewImages/1.png"style="width:903px;margin-left:1%;height:53px;margin-top:0%"/>
     <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
  <strong class="family1 imageheadercolor">Payroll</strong>
    </div>
</div>
    <div id="divSearchFilter" >
        <table style="width:100%;margin-left:-4px" >
            <tr>
                <td >
                    <fieldset style="border:none">
                        <table  class="teble_bg" style="width:100%;background-color:#a4cd0f;">
                             <tr>
                                 <%-- ReSharper disable Html.Obsolete --%>
                                <td colspan="10" align="center" >
                                    <%-- ReSharper restore Html.Obsolete --%>
                                <table><tr>
                                <td><b><label id="lblMonth" style="font-weight:bold">Month</label></b></td>
                                <td><select style="width:auto;border:1px solid silver" id="cmbMonth" name="cmbMonth" onchange="getGridDisplay()" class="family">
                                        <option value="">Select</option>
                                        <option value="1">January</option>
                                        <option value="2">February</option>
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
                                <td></td>
                                <td><b><label id="lblYear" style="font-weight:bold">Year</label></b></td>
                                <td><input id="txtYear" name="txtYear" style="width:50px;border:1px solid silver" type="text" size="5" class="family"/></td>
                              
                               <td></td>
                                           <%-- ReSharper disable once Html.Obsolete --%>
                               <td align="right"><input id="btnSearch" value="Generate" name="Submit" type="submit" class="family"/></td>
                                <td ><input id="btnClear" type="button" value="Reset" onclick="clearGrid()" style="border:1px solid silver" class="family"/></td>
                                           <td><input  type="checkbox" id="chkisannual" class="family"/>Include Annual Allowance</td>
                                </tr></table>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>
    </form>
 <%--   <div style="position:relative;margin-left:1%;">
    <img alt="" src="Resources/Images/NewImages/1.png" style="width:96%;height:53px"/>
    <div style="position:absolute;left:2%;top:52%;">
    <strong style="font-size:16px;color:White">Payroll</strong>
    </div>
    </div>--%>
    <form id="signupForm" method="get" action="">
    <div style="margin-left:1%;" id="box">
        <table id="list"></table>
        <div id="pager"></div>
    </div>
    </form>
    <div id="dvannualbenifit" class="dvGrid" style="display: none;">
        <table id="annualbenifit"></table>
        <div class="field">
            <input id="btnCancel" name="btnCancel" type="button" value="Cancel" /></div>
        </div>
    <input type="hidden" id='hdnEmployeeID' runat="server" />
    <input type="hidden" id='hdnmodule' runat="server" />
    <input type="hidden" id='hdnApprovlPermit' runat="server" />
    <input type="hidden" id="hdnApplyPermit" runat="server" />
    <input type="hidden" id="hdnViewPermit" runat="server" />
    <input type="hidden" id="hdnUniqueID" runat="server" />
    <input type="hidden" id="hdnSessionID" runat="server" />
    <input type="hidden" id="hdnIsPreviousLOP" runat="server" />
</body>
<script type="text/javascript">
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('#t_list').css('background', 'none');
        $('#t_list').css('background-color', '#fff');
        $('#t_list').css('padding', '10px 0');
//        $('#t_list input[type=button]').css('margin-left', '10px');
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
