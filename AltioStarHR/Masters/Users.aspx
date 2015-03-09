<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="AltioStarHR.Masters.Users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Users</title>
   <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
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
        #Clientmaster
        {
            width: 217px;
        }
    </style>
</head>
<body>
    <div>
        <table id="list" class="scroll">
        </table>
        <div id="pager">
        </div>
        <div id="divUser">
            <form id="signupForm" method="get" action="">
           <table style="width:100%;background-color:#a4cd0f">
                    <tr>
                            <td class="label">
                                <label id="lfirstname" for="firstname">
                                     Name</label>
                            </td>
                            <td class="field">
                                <input id="firstname" name="firstname" type="text" style="width:150px" value="" maxlength="100" readonly="readonly" />
                            </td>
                            <td class="status" id="sfirstname">
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="label">
                                <label id="lloginname" for="loginname">
                                    Login Name<span style="font-size: medium; color: Red">*</span></label>
                            </td>
                            <td class="field">
                                <input id="loginname" name="loginname" tabindex="1" style="width:150px" type="text" value="" maxlength="100" />
                            </td>
                            <td class="status" id="sloginname">
                            </td>
                        </tr>
                        <tr id="rowPassword">
                            <td class="label">
                                <label id="lpassword" for="password">
                                    Password<span style="font-size: medium; color: Red">*</span></label>
                            </td>
                            <td class="field">
                                <input id="password" name="password" tabindex="2"  style="width:153px" type="password" value="" maxlength="100" />
                            </td>
                            <td class="status" id="spassword">
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="label">
                                <label id="lsignupsubmit" for="signupsubmit">
                                    </label>
                            </td>
                            <td class="field" colspan="2">
                                <input id="signupsubmit" name="Save" type="submit"  tabindex="4" value="Save"  class="lookup-submit" />
                           
                                <%--<input id="Cancel" name="Cancel" tabindex="5" type="button" value="Cancel" />--%>
                            </td>
                        </tr>
                   
                </table>
            <input id='hdnLoginType' runat="server" type="hidden" />
            <input id='hdnEmployeeID' runat="server" type="hidden" />
            <input id='hdnConsultantID' runat="server" type="hidden" />
            <input type="hidden" id='hdnSessionID' runat="server" />
            <input type="hidden" id='hdnType' runat="server" />
            <input type="hidden" id='hdnEmpName' runat="server" />
            <input type="hidden" id='hdnCntName' runat="server" />

            </form>
        </div>
    </div>
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
    var LoginNameResponse;
    jQuery(document).ready(function() {
        $('.lookup-submit').button().click(function() {
            //        alert("User Details Updated successfully");
            //            window.close();
        });
        var mode = "";
        var Type = "";
        var SelectedEmpType;
        var Request = new Object();
        if ($('#hdnLoginType').val() == "EMP") {

            Request.ChangedBy = $("#hdnEmployeeID").val();
            Request.ID = $('#hdnLoginType').val();
        }
        else if ($('#hdnLoginType').val() == "CNT") {
            Request.ChangedBy = $("#hdnConsultantID").val();
            Request.ID = $('#hdnLoginType').val();
        }
        var Response = SendApplicationRequest('<%=CommonAppCommands.EMPBASEDUPDATE_USER%>', Request, true);
        LoginNameResponse = Response.ResponseObject;

        if ($('#hdnLoginType').val() == "EMP") {

            $('#firstname').val($('#hdnEmpName').val());
        }
        else if ($('#hdnLoginType').val() == "CNT") {
            $('#firstname').val($('#hdnCntName').val());

        }
        if (Response.ResponseObject != "") {

            if ($('#hdnLoginType').val() == "EMP") {

                $("#loginname").val(Response.ResponseObject);

            }
            else if ($('#hdnLoginType').val() == "CNT") {
                $("#loginname").val(Response.ResponseObject);
            }
            if ($("#loginname").val() != '') {
                $("#loginname").attr("disabled", true);
            }
            //$("#firstname").attr("disabled", true);
            //$("#loginname").attr("disabled", true);
        }
        // var Response = SendApplicationRequest('USER_DETAILS', '', true);
        $.validator.addMethod("alphaNumerixwithouspace", function(value, element) {
            return this.optional(element) || /^[-._$@&a-zA-Z0-9\s]+$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");




        $('#Cancel').click(function() {
            onCancel();
        });
        var validator = $("#signupForm").validate({
            rules: {
                employee: "required",
                loginname: {
                    required: true,
                    //                    minlength: 6,
                    alphaNumerixwithouspace: true
                },
                password: {
                    required: true,
                    minlength: 4,
                    alphaNumerixwithouspace: true
                }
            },
            messages: {
                employee: "Select Employee",
                loginname: {
                    required: "Enter login name",
                    //                  minlength: jQuery.format("Enter at least {0} characters"),
                    alphaNumerixwithouspace: "Invalid login name space not allowed"
                },
                password: {
                    required: "Provide a password",
                    rangelength: jQuery.format("Enter at least {0} characters"),
                    alphaNumerixwithouspace: "Invalid password space not allowed"

                }
            },
            errorPlacement: function(error, element) {
                error.appendTo(element.parent().next());
            },
            submitHandler: function() {


                var currPage = jQuery('#list').jqGrid('getGridParam', 'page');
                var Request = new Object();
                var ID = "";
                //var EmployeeID = 3;

                //                if (mode == "") {
                //                    var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
                //                    var ret = jQuery("#list").jqGrid('getRowData', id);
                //                    ID = 1;
                //                    //EmployeeID = ret.employeeid;
                //                }
                //                else {
                //                    ID = "0";
                //                    CrationDate = new Date();
                //                    Request.CreatedBy = 1;
                //                }

                if (LoginNameResponse == "")
                    Request.UserID = 0;

                else
                    Request.UserID = 1;

                if ($('#hdnLoginType').val() == "EMP") {
                    Request.EmployeeID = $("#hdnEmployeeID").val();
                }
                else if ($('#hdnLoginType').val() == "CNT") {
                    Request.EmployeeID = $("#hdnConsultantID").val();
                }
                Request.LoginName = $("#loginname").val();
                Request.Password = $("#password").val();


                Request.LoginType = $("#hdnLoginType").val();
                var Response = SendApplicationRequest('<%=CommonAppCommands.UPDATE_USER%>', Request, true);



                if (Response.ResponseCommand == 'SUCCESS') {
                    //alert('User detail created successfully');
                    alert(Response.Message);
                    mode = "SUCCESS";
                    $("#password").val("");
                    $("#loginname").attr("disabled", true);
                    //$("#firstname").attr("disabled", true);
                    window.close();
                    // clearLabels();
                    //onCancel();
                    // jQuery("#list").jqGrid('setGridParam', { page: currPage }).trigger('reloadGrid');


                }
                else {
                    alert(Response.Message);
                }
            },
            success: function(label) {
                label.html("&nbsp;").addClass("checked");
            }
        });
    });
//    function clearLabels()
//    {
//       // $("#loginname").val(""); 
//        $("#password").val("");    
//        //$("#firstname").val("");  
//        $("#loginname").attr("disabled", true);
//        $("#firstname").attr("disabled", true);
//    }
  function onCancel() {
  var mode = "";
    if (mode != "SUCCESS") {
        if (confirm('Do you want to cancel?') == false) return;
    }
    // clearLabels();
    //document.getElementById("divUser").style.display = "";
}

 </script>
</html>
