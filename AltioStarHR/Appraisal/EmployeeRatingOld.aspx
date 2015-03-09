<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRatingOld.aspx.cs" Inherits="AltioStarHR.Appraisal.EmployeeRatingOld" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee Rating</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
     
    </style>
</head>
<body>
    <div>
        <div class="header_title2">
            Employee Rating</div>
        <div class="dvGrid">
            <table id='list'></table>
        </div>        
        <div id='divPromotion' style="display:none" title="Promote Employee">
            <table class="teble_bg">
            <tr class="family">
            <td>Employee Name</td>
            <td><label id="lblEmpName"></label></td>
            </tr>
            <tr class="family">
            <td>Current Designation</td>
            <td><label id="lblDesignation"></label></td>
            </tr>
            <tr class="family">
            <td>Promated Designation</td>
            <td><select id="cmbDesignation"></select></td>
            </tr>
            <tr>
            <td><input id="btnPromote" type="button" value="Promote" onclick="return Promote();" class="family"/></td>
            <td><input id="btnPCancle" type="button" value="Cancle" class="family"/></td>
            </tr>
            </table>
        </div>
        <div id='divHike' style="display:none" title="Hike Employee">
            <table class="teble_bg">
            <tr>
            <td class="family">Employee Name</td>
            <td><label id="lblEmpNameHike"></label></td>
            </tr>
            <tr>
            <td class="family">Current Salary</td>
            <td><label id="lblSalary"></label></td>
            </tr>
            <tr>
            <td class="family">Salary after hike</td>
            <td><input type="text" id="txtSalary" onkeyup="return CalculatePercentage();"/></td>
            </tr>
            <tr>
            <td class="family">Hike Percentage(in %)</td>
            <td><label id="HikePer"></label></td>
            </tr>
            <tr>
            <td class="family"><input id="btnHike" type="button" value="Hike" onclick="return Hike();"/></td>
            <td class="family"><input id="btnHCancel" type="button" value="Cancle"/></td>
            </tr>
            </table>
        </div>
    </div>
    <input id="hdnEmployeeID" type="hidden" runat="server"/>
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

<script type="text/javascript" src="Resources/js/jquery.ui.button.js"></script>

<script type="text/javascript">
    $(document).keydown(function(e) {

        var nodeName = e.target.nodeName.toLowerCase();
        if (e.which == 8) {
            if ((nodeName == 'input' && e.target.type == 'text') || nodeName == 'textarea') {
            }
            else { e.preventDefault(); }
        }
    });


    var mode = "";
    var activeStatus = true; 
    var SelectedEmployee=0;
    var EmpName="";
    var ID=0;

    jQuery(document).ready(function() {
        
        LoadDesignation();
        
        $('#btnPCancle').click(function() {
            onPCancel();
        });
        $('#btnHCancel').click(function() {
            onHCancel();
        });

        $.validator.addMethod("alphaNumerix", function(value, element) {
            return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

        ConstructGrid(); 

    });
    function Hike()
    {
        if(SelectedEmployee!= 0)
        {
            var Request = new  Object();
            Request.ID = ID;
            Request.EmployeeID = SelectedEmployee;
            Request.HikePer = $("#HikePer").text();
            Request.Salary = $("#txtSalary").val();
            var Response = SendApplicationRequest('<%=HRAppCommands.EMPLOYEE_HIKE%>', Request,true);
            alert("Employee Salary hike successfully");
            onHCancel();
            ConstructGrid();
        }
        else{
            alert("Select employee");
        }
    }
    function Promote()
    {
        if(SelectedEmployee!= 0)
        {
            var Request = new  Object();
            Request.ID = ID;
            Request.EmployeeID = SelectedEmployee;
            Request.DesignationID = $("#cmbDesignation").val();
            var Response = SendApplicationRequest('<%=HRAppCommands.EMPLOYEE_PROMOTE%>', Request,true);
            alert("Employee promoted successfully");
            onPCancel();
            ConstructGrid();
        }
        else{
            alert("Select employee");
        }
    }
    function CalculatePercentage()
    {
    
        if(parseFloat($("#txtSalary").val()) >0 && parseFloat($("#lblSalary").text()) !=0 )
        {
            var per = (parseFloat($("#txtSalary").val())-parseFloat($("#lblSalary").text()))/parseFloat($("#lblSalary").text())*100;
            $("#HikePer").text(per);
        }
        else{
            $("#HikePer").text("");
        }
    }
    function ConstructGrid()
    {
        $(".dvGrid").html("<table id='list'></table>");
        var myGrid = $('#list');
        var Response = SendApplicationRequest('<%=HRAppCommands.INTIMATION%>', '');
        Response.ResponseObject.colModel = [
   		            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		            { name: 'goal', index: 'goal', width: 100},
   		            { name: 'appraisal', index: 'appraisal', width: 100 },
   		            { name: 'intimateby', index: 'intimateby', width: 100, editable: false},
   		            { name: 'view', index: 'view', width: 50, editable: false,align:'center'},
   		            { name: 'documentname', index: 'documentname', width: 10, editable: false,hidden:true}
   	            ]
        Response.ResponseObject.subGrid = true;
        myGrid.jqGrid(Response.ResponseObject);

        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar()
            }
        });

        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        
        jQuery("#list").jqGrid('setGridParam', { subGridRowExpanded: function(subgrid_id, row_id) {
            
            var ret = jQuery("#list").jqGrid('getRowData', row_id);
            var subgrid_table_id = subgrid_id+"_t";
	        $("#"+subgrid_id).html("<table id='"+subgrid_table_id+"' class='scroll'></table>");
	        var Request = new Object();
	        Request.ID=ret.id;
	        IntimationID=ret.id;	        
	        var Response = SendApplicationRequest('<%=HRAppCommands.GET_ALL_TEAM_MEMBER_FOR_RATING%>', Request, true);
	        Response.ResponseObject.colModel = [
	            { name: 'Sno', index: 'Sno', width: 20,hidden:true,sortable:false},
                { name: 'id', index: 'id', width: 20,hidden:true,sortable:false},
                { name: 'intimationid', index: 'intimationid', width: 20,hidden:true,sortable:false},
                { name: 'employeeid', index: 'employeeid', width: 20,hidden:true,sortable:false},
                { name: 'employee', index: 'employee', width: 100, editable: true,sortable:false },
                { name: 'goals', index: 'goals', width: 20, editable: true,sortable:false ,hidden:true},
                { name: 'grade', index: 'grade', width: 30, editable: true,sortable:false ,hidden:true},
                { name: 'addgoals', index: 'addgoals', width: 100, editable: true,sortable:false,align:'center' },
                { name: 'addgrade', index: 'addgrade', width: 100, editable: true,sortable:false,align:'center' }  ,
                { name: 'view', index: 'view', width: 50, editable: true,sortable:false,align:'center' },
                { name: 'Designation', index: 'Designation', width: 20,hidden:true,sortable:false},
                { name: 'Salary', index: 'Salary', width: 20,hidden:true,sortable:false},
                { name: 'HikePer', index: 'HikePer', width: 20,sortable:false},
                { name: 'NewDesignation', index: 'NewDesignation', width: 60,sortable:false}
                           
            ];
            Response.ResponseObject.caption = "Team Member List";            
            Response.ResponseObject.width="800";
            Response.ResponseObject.height="100%";
            Response.ResponseObject.rowNum=-1;
            jQuery("#"+subgrid_table_id).jqGrid(Response.ResponseObject);		
            
            $("#t_"+subgrid_table_id).append("<input type='button' id='promote_"+subgrid_table_id+"' value='Promote Employee' style='height:24px;font-size:-3'/> ");
            $("#t_"+subgrid_table_id).append("<input type='button' id='hike_"+subgrid_table_id+"' value='Salary Hike' style='height:24px;font-size:-3'/> ");
            $("input", "#t_"+subgrid_table_id).click(function(id) {
                var idi = jQuery("#"+subgrid_table_id).jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#"+subgrid_table_id).jqGrid('getRowData', idi);
                ID = ret.id;
                SelectedEmployee = ret.employeeid;
                EmpName= ret.employee;
                if (id.currentTarget.id == "promote_"+subgrid_table_id) {                
                    if(idi){
                        document.getElementById("divPromotion").style.display = "";
                        $('#divPromotion').dialog({
                            height: 200,
                            width: 550,
                            modal: true
                        })
                        $("#lblEmpName").text(EmpName);
                        $("#lblDesignation").text(ret.Designation);
                    }
                    else{
                        alert("Select Employee");
                    }
                }
                else if (id.currentTarget.id == "hike_"+subgrid_table_id) {
                    if(idi){
                        document.getElementById("divHike").style.display = "";
                        $('#divHike').dialog({
                            height: 200,
                            width: 550,
                            modal: true
                        })
                        $("#lblEmpNameHike").text(EmpName);
                        $("#lblSalary").text(ret.Salary);
                     }
                    else{
                        alert("Select Employee");
                    }
                }
            });   
            jQuery("#"+subgrid_table_id).jqGrid('setGridParam', {
            onSelectRow:function(rowid,iRow,iCol,e){
                var ret = jQuery("#"+subgrid_table_id).jqGrid('getRowData', rowid);
                if(ret.status=='GOL')
                {
                    document.getElementById("goal_"+subgrid_table_id).style.display="none";         
                    document.getElementById("grade_"+subgrid_table_id).style.display="";    
                }
                else if(ret.status=='GRA')
                {   
                    document.getElementById("goal_"+subgrid_table_id).style.display="none";         
                    document.getElementById("grade_"+subgrid_table_id).style.display="none";   
                }
                else{
                    document.getElementById("goal_"+subgrid_table_id).style.display="";         
                    document.getElementById("grade_"+subgrid_table_id).style.display="";   
                }
            }
        }); 
        }});     
    }
    function onPCancel(){
        $("#lblEmpName").text("");
        $("#lblDesignation").text("");
        $("#cmbDesignation").val("");
        $('#divPromotion').dialog('close');
    }
    function onHCancel(){
        $("#lblEmpNameHike").text("");
        $("#lblSalary").text("");
        $("#txtSalary").val("");
        $("#HikePer").text("");
        $('#divHike').dialog('close');
    }
    function LoadDesignation() {

            var Response = SendApplicationRequest("<%=HRAppCommands.DESIGNATION_COMBO_DETAILS%>", "");
            var optn = document.createElement("OPTION");
            optn.text = "Choose Designation";
            optn.value = "";
            document.getElementById('cmbDesignation').options.add(optn);
            if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
                var arr = Response.ResponseObject;
                for (var i = 0; i < arr.length; ++i) {
                    var optn = document.createElement("OPTION");
                    optn.text = arr[i]['Value'];
                    optn.value = arr[i]['ID'];
                    document.getElementById('cmbDesignation').options.add(optn);
                }
            }
        }
    function viewDoc(ID)
    {       
        var ret = jQuery("#list").jqGrid('getRowData', ID);
        window.location.href = "DownloadFileHandler.ashx?DocumentName=" + ret.documentname+ "&Type=appraisal"+ "&ID="+ID;
    }
    function BindGrid() {

       var Response = SendApplicationRequest('<%=HRAppCommands.INTIMATION%>', '');
      if (Response.ResponseCommand == 'SUCCESS') {
          if (Response.ResponseObject.datastr == null)
          
              jQuery("#list").jqGrid('clearGridData');
          else {
              jQuery("#list").jqGrid('setGridParam', Response.ResponseObject);
              jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger('reloadGrid');
          }
      }
  }
  function ViewAppraisal(ID,Doc,type)
{
    window.location.href = "DownloadFileHandler.ashx?DocumentName=" + Doc+ "&Type="+type+"&ID="+ID;
}
</script>

<script type="text/javascript">
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('#t_list').css('background', 'none');
        $('#t_list').css('background-color', '#fff');
        //$('#t_list').css('padding', '10px 0px');
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
