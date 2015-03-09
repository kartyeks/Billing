<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    Inherits="AltioStarHR.Common.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
 <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    <link href="Resources/css/NewCss/Stylesheet2.css" rel="stylesheet" type="text/css" />    

    <script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Newjs/jquery-1.9.1.js") %>"></script>

    <script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Newjs/jquery-ui-1.10.3.custom.js") %>"></script>

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
        var path = null;
        jQuery(document).ready(function() {

        $.validator.addMethod("alphaNumerixwithouspace", function(value, element) {
            return this.optional(element) || /^[a-zA-Z0-9][a-zA-Z0-9,\s]*$/i.test(value);
        }, "Username must contain only letters, numbers, or dashes.");

            $('#Cancel').click(function() {
                onCancel();
            });

            $("#loginname").val($("#hdnLoginName").val());


            var validator = $("#signupForm").validate({
                rules: {
                    loginname: {
                        required: true
                    },
                    password: {
                        required: true,
                        minlength: 4,
                        alphaNumerixwithouspace: true
                    },
                    password_confirm: {
                        required: true,
                        minlength: 4,
                        equalTo: "#password"
                    }
                },
                messages: {
                    loginname: {
                        required: "Enter login name"
                    },
                    password: {
                        required: "Provide a password",
                        rangelength: jQuery.format("Enter at least {0} characters"),
                        alphaNumerixwithouspace: "Invalid password space not allowed"
                    },
                    password_confirm: {
                        required: "Repeat password",
                        minlength: jQuery.format("Enter at least {0} characters"),
                        equalTo: "Enter the same password as above"
                    }
                },
                errorPlacement: function(error, element) {
                    error.appendTo(element.parent().next());
                },
                submitHandler: function() {

                    var Request = new Object();
                    Request.UserID = $("#hdnUserid").val();
//                    Request.EmployeeID = $("#hdnEmployeeID").val();
//                    Request.LoginName = $("#loginname").val();
                    Request.NewPassword = $("#password").val();
                    var Response = SendApplicationRequest('CHANGE_PASSWORD', Request, true);
                    alert(Response.Message);
                    if (Response.ResponseCommand == 'SUCCESS') {
                        var ID = $("#hdnEmployeeID").val();
                        path = ID + "$logininfo";
                        $.post("UploadFileHandler.ashx", { path: path }, function(data) {
                            var d = data.split(':');
                            $("#res").html("File Name : " + d[0] + "File Size : " + d[1] + "File Type : " + d[2]);
                        });
                        onCancel();
                    }
                },
                success: function(label) {
                    label.html("&nbsp;").addClass("checked");
                }
            });
        });

        function onCancel() {
    
            window.close();
        }
    
    
    </script>

</head>
<body>
    <div id="chgpwd" runat="server">
        <form id="signupForm" method="get" action="">
        
        <table  align="center" >
            
            <tr>
                <td class="label">
                    <label id="lloginname" for="loginname" class="family1">
                        Login Name</label>
                </td>
                <td class="field">
                    <input id="loginname" name="loginname" style="width:auto;" disabled tabindex="1" type="text" value=""
                        maxlength="100" />
                </td>
                <td class="status" id="sloginname">
                </td>
            </tr>
            <tr id="rowPassword">
                <td class="label">
                    <label id="lpassword" for="password" class="family1">
                        Password</label>
                </td>
                <td class="field">
                    <input id="password" name="password" tabindex="2" type="password" value="" maxlength="100" />
                </td>
                <td class="status" id="spassword">
                </td>
            </tr>
            <tr id="rowCPassword">
                <td class="label">
                    <label id="lpassword_confirm" for="password_confirm" class="family1">
                        Confirm Password</label>
                </td>
                <td class="field">
                    <input id="password_confirm" name="password_confirm" tabindex="3" type="password"
                        value="" maxlength="100" />
                </td>
                <td class="status" id="spassword_confirm">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="field" colspan="2">
                    <input id="signupsubmit" name="Save" class="family1" type="submit" tabindex="4" value="Save" />
                    <input id="Cancel" name="Cancel" class="family1" tabindex="5" type="button" value="Cancel" />
                </td>
            </tr>
        </table>
        <input id="hdnUpdate" type="hidden" runat="server" />
        <input id="hdnUserid" type="hidden" runat="server" />
        <input id="hdnEmployeeID" type="hidden" runat="server" />
        <input id="hdnLoginName" type="hidden" runat="server" />
        <input id='hdnLoginType' runat="server" type="hidden" />
        </form>
    </div>
</body>
</html>
