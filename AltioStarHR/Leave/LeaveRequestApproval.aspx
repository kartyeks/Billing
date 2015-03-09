<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveRequestApproval.aspx.cs"
    Inherits="AltioStarHR.Leave.LeaveRequestApproval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Leave Request Approval</title>
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
      
    </style>
</head>
<body>
<%--    <div style="background-color:#02d9f5; color:white; font-size: x-large; width:97%;margin-left:1%;padding-left:2%">
        Leave Approval
    </div>--%>
     <div style="position:relative;width: 100%" >
    <img alt="" src="Resources/Images/NewImages/1.png" style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
    <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
    <strong class="family1 imageheadercolor">Leave Approval</strong>
    </div>
</div>
    <div id="divStatus" class="dialog" title="Leave Comment" style="display: none;background-color:White;width:100%">
        <form id="signupForm" method="get" action="">
        <table class="teble_bg" style="width: 97%; background-color:#a4cd0f;">
            <tr>
                <td style="width: 50px;" id="ltxtComment" class="family">
                    <label>
                        Comments</label>
                </td>
                <td id="tdtxtComment">
                    <textarea style="width: 370px;border:1px solid silver" id='txtComment' runat="server" cols="2" rows="3" class="family"></textarea>
                </td>
                <td id="stxtComment" style="width: 200px;" class="family">
                </td>
            </tr>
        </table>
        <table style="width: 475px; background-color:#a4cd0f;">
            <tr align="left">
                <td>
                    <input id="signupsubmit" name="Submit" type="submit" value="Submit" style="border:1px solid silver;background-color:#00DBF1;" class="family"/>
                    <input id="Cancel" name="Cancel" type="button" value="Cancel" style="border:1px solid silver;background-color:#00DBF1;" class="family"/>
                </td>
            </tr>
        </table>
        </form>
    </div>
    
        <div id="LeaveAppGrid" style="margin-left:2%">
        </div>
    
    <input type="hidden" runat="server" id="hdnEmployeeID" />
</body>

<script type="text/javascript" src="Resources/js/jquery-1.6.2.min.js"></script>

<script type="text/javascript" src="Resources/js/jquery-ui-1.8.16.custom.min.js"></script>

<script type="text/javascript" src="Resources/js/grid.locale-en.js"></script>

<script type="text/javascript" src="Resources/js/jquery.jqGrid.min.js"></script>

<script type="text/javascript" src="Resources/js/Webutility.js"></script>

<script type="text/javascript" src="Resources/js/toolbar.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.core.js"></script>

<script type="text/javascript" src="Resources/js/jquery.ui.widget.js"></script>

<script src="Resources/js/jquery.ui.button.js" type="text/javascript"></script>
 
<script type="text/javascript" src="Resources/js/jquery.validate.js"></script>

<script type="text/javascript">
    //    $('#LeaveAppGrid').css('background-image', 'url(Resources/Images/NewImages/dashboard_bg1.gif)');
    $("#LeaveAppGrid").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });   
        var validator;
        jQuery(document).ready(function() { 
            $.validator.addMethod("alphaNumerix", function(value, element) {
                return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9,\s ]*$/i.test(value);
            }, "Username must contain only letters, numbers, or dashes.");
            
            $('#Cancel').click(function() {
                onCancel();
            });
            LoadLeaveReqApp();                  
       
         validator = $("#signupForm").validate({
            rules: {              
            },            
            messages: {                      
            },            
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            
            submitHandler: function(id) {               
                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                var LeaveRequestID = "";
                var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                var ret = jQuery("#list").jqGrid('getRowData', id);                
                if(mode=="reject" && $("#txtComment").val()=="")
                {
                    alert("Enter Comment");
                    return false;
                }
                if (mode == "approve") {                    
                    Request.LeaveRequestID = ret.id;
                    Request.Status = "APP" 
                }
                else {
                    Request.LeaveRequestID = ret.id;
                    Request.Status = "REJ" 
                }                         
                Request.ID = "0";  
                Request.ProcessedBy =  $("#hdnEmployeeID").val();            
                Request.Comment = $("#txtComment").val();   
                if (confirm('Do you want to Submit?') == false) return false;             
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_LEAVE_APPROVAL%>', Request, true);                
                alert(Response.Message);                                         
                if (Response.ResponseCommand == 'SUCCESS') {
                    mode = "SUCCESS";
                    LoadLeaveReqApp();                             
                    clearLabels();
                    onCancel();
                }
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });
        }); 
         function LoadLeaveReqApp(){
            $("#LeaveAppGrid").html("");                
            $("#LeaveAppGrid").html("<div><table id='list'></table><div id='pager'></div></div>");     
            var Request = new Object();
            Request.EmployeeID = $("#hdnEmployeeID").val();      
            var myGrid = $('#list');    
            var Response = SendApplicationRequest('<%=HRAppCommands.LEAVE_REQUEST_APPROVAL_DETAILS%>', Request,true);
            Response.ResponseObject.colModel = [
   		                { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
   		                { name: 'employeeid', index: 'employeeid', width: 20,hidden: true, editable: true },  		            		            
   		                { name: 'leaveid', index: 'leaveid', width: 20,hidden: true,editable: true },
   		                { name: 'managerid', index: 'managerid', width: 20,hidden: true, editable: true },
   		                { name: 'managername', index: 'managername', width: 70, editable: true,hidden: true  },
   		                { name: 'employeename', index: 'employeename', width: 70, editable: true},
   		                { name: 'leavetype', index: 'leavetype', width: 70, editable: true },   		                
   		                { name: 'fromdate', index: 'fromdate', width: 50, editable: true },
   		                { name: 'todate', index: 'todate', width: 50, editable: true},
   		                { name: 'dayscount', index: 'dayscount', width: 50, editable: true},  
   		                { name: 'applieddatetime', index: 'applieddatetime', width: 50, editable: true, hidden: true },   		               
   		                { name: 'comment', index: 'comment', width: 150, editable: true,hidden: true},
   		                { name: 'status', index: 'status', width: 50, editable: true}, 
   		                { name: 'isactive', index: 'isactive', width: 10, editable: true, hidden: true },
   		                { name: 'title', index: 'title', width: 10, editable: true, hidden: true },
   		                { name: 'managercomments', index: 'managercomments', width: 10, editable: true, hidden: true },
   		                { name: 'FromDateHalfDay', index: 'FromDateHalfDay', width: 10, editable: true, hidden: true },
   		                { name: 'ToDateHalfDay', index: 'ToDateHalfDay', width: 10, editable: true, hidden: true }    		             
   	                ]
            Response.ResponseObject.caption = "";
            Response.ResponseObject.subGrid = true;
            Response.ResponseObject.autowidth= true;
            myGrid.jqGrid(Response.ResponseObject);
            jQuery("#list").jqGrid('setGridParam', { subGridRowExpanded: function(subgrid_id, row_id) {
                var ret = jQuery("#list").jqGrid('getRowData', row_id);                
                if($.trim(ret.comment) !=''){
                    $("#" + subgrid_id).html("<b><label>Employee Comments</label></b><br/>"
                    +"<textarea id='ta_"+row_id+"' rows='3' cols='100' readonly='readonly'></textarea><br/>");         
                    $("#ta_"+row_id).val(ret.comment.replace(/<br>/g,"\n"));

                    $("#" + subgrid_id).append("<b><label>Manager Comments</label></b><br/>"
                    +"<textarea id='tb_"+row_id+"' rows='3' cols='100' readonly='readonly'></textarea><br/>");         
                    $("#tb_"+row_id).val(ret.managercomments.replace(/<br>/g,"\n"));   
                }                           
            }}); 
            jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
            jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
            jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
                onClickButton: function() {
                    myGrid[0].toggleToolbar()
                }
            });
//            $("#list").closest(".ui-jqgrid-bdiv").height("auto");
            jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
            
            $("#t_list").append("<button type='button' id='approve' value='Approve' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/approve.png' height=18px;width=18px alt='' /><br/><div></div><span>Approve</span></button>");
            $("#t_list").append("<button type='button' id='reject' value='Reject' style='background:none;border:0px;outline:none;'><img src='Resources/Images/NewImages/delete.jpg' height=18px;width=18px alt='' /><br/><div></div><span>Reject</span></button>");
//            $("#t_list").append("<input type='button' id='approve' value='Approve'  style='font-size:12px;font-family:arial;margin:8px;'/> ");
//            $("#t_list").append("<input type='button' id='reject' value=' Reject' style='font-size:12px;font-family:arial;margin:8px;'/> ");  
            
            $("input,button", "#t_list").click(function(id) {
            
                if (id.currentTarget.id == "approve") {                
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    mode = "approve";
                    if(id){
                        if(ret.status == "Approved")
                        {
                            alert("Already Approved");
                            return false;
                        } 
                        if(ret.status == "Rejected")
                        {
                            alert("Already Rejected");
                            return false;
                        }                   
                        validator.resetForm();                    
                        clearLabels();                
                        document.getElementById("divStatus").style.display = "";
                        $('#divStatus').dialog({
                            height: 150,
                            width: 500,
                            modal: true
                        })
                    }
                    else {alert("Please select a row");}
                } 
                else if (id.currentTarget.id == "reject") {
                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                    var ret = jQuery("#list").jqGrid('getRowData', id);
                    mode = "reject";
                    if (id) {
                        if(ret.status == "Approved")
                        {
                            alert("Already Approved");
                            return false;
                        }
                        if(ret.status == "Rejected")
                        {
                            alert("Already Rejected");
                            return false;
                        }
                        validator.resetForm();                   
                        clearLabels();                
                        document.getElementById("divStatus").style.display = "";
                        $('#divStatus').dialog({
                            height: 150,
                            width: 500,
                            modal: true
                        })
                    }
                    else {alert("Please select a row");}
                }     
            });
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
         }   
        function clearLabels()
        {
            $("#txtComment").val("");            
        } 
        function onCancel() {
            if (mode != "SUCCESS") {
                if (confirm('Do you want to cancel?') == false) return;
            }
            $("#divStatus").dialog('close');
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
