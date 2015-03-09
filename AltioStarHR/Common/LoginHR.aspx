<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginHR.aspx.cs" Inherits="AltioStarHR.Common.LoginHR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <base target="_self" />
    <%--    <link rel="stylesheet" href="../Resources/css/login_style.css" />   --%>
    <link href="../Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        body a
        {
            color: #000;
        }
        body a:hover
        {
            color: red;
            text-decoration: none;
        }
        table
        {
        }
    </style>
    <style type="text/css">
        fieldset
        {
            border: 0;
            margin-bottom: 40px;
        }
        select
        {
            width: 212px;
        }
        .style1
        {
            height: 301px;
        }
        .style2
        {
            width: 142px;
        }
    </style>
    <%--<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/ircaobjs2.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/js2rw2.js") %>"></script> --%>

    <script type="text/javascript" src="../Resources/js/jquery-1.6.2.min.js"></script>

    <script type="text/javascript" src="../Resources/js/jquery-ui-1.8.17.custom.min.js"></script>

    <script type="text/javascript" src="../Resources/js/grid.locale-en.js"></script>

    <script type="text/javascript" src="../Resources/js/jquery.jqGrid.min.js"></script>

    <script type="text/javascript" src="../Resources/js/Webutility.js"></script>

    <script type="text/javascript" src="../Resources/js/toolbar.js"></script>

    <script type="text/javascript" src="../Resources/js/jquery.ui.core.js"></script>

    <script type="text/javascript" src="../Resources/js/jquery.ui.widget.js"></script>

    <script type="text/javascript" src="../Resources/js/jquery.validate.js"></script>

<script type="text/javascript">
    jQuery(document).ready(function() {

        // Blank Calculation for setting the image height and allinging it center //
//        var he = $(document).height();
//        var reduce = he * 1.7;
//        $("#tdloginImg").height(reduce); 
        
        if (document.getElementById("hdnSuccess").value == "true") {
            var place = (window.parent.document.getElementById('ChildWB').frameElement) ?
            window.parent.document.getElementById('ChildWB').frameElement :
            window.parent.document.getElementById('ChildWB').contentWindow.frameElement;
            place.src = "default.aspx?serve=DashBoard";// "Common/DashBoard.aspx";
            return;
            // window.close();
        } 
        else if (document.getElementById("hdnSuccess").value == "false") {
            alert('Invalid User name or password'); 
//            var he = $(window).height();
//            var reduce = he * 1.7;
//            $("#tdloginImg").height(reduce); 
        }

        $('#btnLogin').click(function() {            
            OnLoginClick();
        });
    });
    
    function onValidate() {
        if ($("#UserName").val() == "") {
            alert('User name can not be empty'); return false;
        }
        if ($("#UserName").val() != "admin") {
            if ($("#Password").val() == "") {
                if ($("#rdoEmp").is(':checked')) {
                    alert('Password can not be empty'); return false;
                }
            }
        }
        return true;
    }
   
    function OnLoginClick() {
        
        if (onValidate()) {
            //        form1.action = "default.aspx?serve=LoginHR";
            //form1.action = "Common\LoginHR.aspx";
            document.getElementById('form1').submit();
        }
        else { 
//            var place = (window.parent.document.getElementById('ChildWB').frameElement) ?
//            window.parent.document.getElementById('ChildWB').frameElement :
//            window.parent.document.getElementById('ChildWB').contentWindow.frameElement;
//            place.src = "default.aspx?serve=LoginHR"; // "Common/DashBoard.aspx";
//            return;
        }
     /*   var Request = new Object();
        Request.Username = $("#UserName").val();
        Request.Password = $("#Password").val();
        SelectedRole = 0;
        var fx = getXmlFileContent("default.aspx?serve=DashBoard&rl=" + SelectedRole, false, '', Request);

        if (fx == '') {
            getXmlFileContent('module91.axd/http401update', true);
            alert('Could not Login. Please try again !');
            return;
        }
        else if (fx == 'ServiceException-507') {
            alert('You have already logged in from another location. Please logout and retry again.');
            return;
        };

        IRCAMAIN.smartNavigate(window, fx);*/
    }

    function window_onload() {
        if (document.getElementById("hdnSuccess").value == "true") {
            window.parent.ChildWB.src = "default.aspx?serve=DashBoard";
            window.close();
        }
        
    }

</script> <%--url(../../Resources/Images/NewImages/login.png);--%>
</head>
    <body TargetPage="self"  onload="return window_onload()">
    <form id="form1"  method="post" runat="server" ><%--action="Default.aspx?serve=LoginHR"  method="post"--%>
    <%--<table id="logintable" style="border: none; outline: none; margin-left: 430px; margin-top: 188px; width: 520px; position: absolute; overflow: hidden; background-color: #00DAF5">--%>
    <div id="divisionMain" style= "background-image: url(<%=ResolveUrl("~/Resources/Images/NewImages/new_login_img.jpg")%>);background-position:center;width:100%;height:100%;position:absolute">
     <table align="right" style="margin-right:15%;margin-top:3% ">
            <tr>
                <%--<td style="width:10%">
                </td>--%>
                
                            <td><label  class="family"> User Name:</label></td>
                            <td><input type="text" id='UserName' runat="server" tabindex="3" CssClass="field family" style="width: 200px" /></td>
                            <td>&nbsp;&nbsp;&nbsp;<input type="radio" id="rdoEmp" tabindex="1"  runat="server" name="rdoLog" checked /><label  class="family"> Employee </label></td>
                        </tr>
                        <tr>
                            <td><label  class="family"> Password:</label></td>
                            <td><input id="Password" name="Password" runat="server" tabindex="4" type="password" CssClass="field family" style="width: 200px" /></td>
                            <td>&nbsp;&nbsp;&nbsp;<input type="radio" id="rdoCon" tabindex="2" runat="server" name="rdoLog"  /><label  class="family"> Consultant </label></td>
                        </tr>
                        <tr>
                            <td></td>                    
                            <td class="family" style="float:right">
                                <input type="submit" id="Submit1" runat="server" value="Log In"  tabindex="5"  class="family" width="90px" />                                                    
                            </td>
                            <td></td>
                        </tr>
                   
                  
                
                <%--<td style="width:10%">
                </td>--%>
    
    
        </table>
          <input type="hidden" id="hdnSuccess" value='' runat="server" />
    </div>
    <%--<table id="logintable" style="border: none; outline: none; margin-left: 920px; margin-top: 300px; width: 25%; position: absolute; overflow: hidden; background-color: #00DAF5">
        <tr>
            <td>
                <div id="login">
                <table>
                 <tr>
                <td><label  class="family"> User Name:</label></td>
                <td><input type="text" id='UserName' runat="server" tabindex="3" CssClass="field family" style="width: 200px" /></td>
                <td>&nbsp;&nbsp;&nbsp;<input type="radio" id="rdoEmp" tabindex="1"  runat="server" name="rdoLog" checked /><label  class="family"> Employee </label></td>
                </tr>
                <tr>
                <td><label  class="family"> Password:</label></td>
                <td><input id="Password" name="Password" runat="server" tabindex="4" type="password" CssClass="field family" style="width: 200px" /></td>
                <td>&nbsp;&nbsp;&nbsp;<input type="radio" id="rdoCon" tabindex="2" runat="server" name="rdoLog"  /><label  class="family"> Consultant </label></td>
                </tr>
                <tr>
                <td></td>
                
                <td class="family" style="float:right">
                 <input type="submit" id="Submit1" runat="server" value="Log In"  tabindex="5"  class="family" width="90px" />                                                    
                </td>
                <td></td>
                </tr>
                
                
           <%--     <tr><td><input type="radio" id="rdoEmp" runat="server" name="rdoLog" checked /><label  CssClass="family"> Employee </label>
                </td>
                <td><input type="radio" id="rdoCon" runat="server" name="rdoLog"  /><label  CssClass="family"> Consultant </label>
                </td>
                </tr>
                
                <tr><td><label  CssClass="family"> User Name:</label>
                </td>
                <td><input type="text" id='UserName' runat="server" CssClass="field family" style="width: 200px" />   </td>
                </tr>
                <tr><td><label  CssClass="family"> Password:</label>
                </td>
                <td>
                 <input id="Password" name="Password" runat="server" type="password" CssClass="field family" style="width: 200px" />
                 </td>
                </tr>
                <tr>
                <td></td>
                <td>
                 <input type="submit" id="btnLogin" runat="server" value="Log In"   class="family" width="90px" />                                                    
                </td>
                </tr>--%>
                <%--<tr><td><label  CssClass="family"> Employee </label><input type="radio" id="rdoEmp" name="rdoLog" checked />
                </td>
                <td><label  CssClass="family"> Contract Employee </label><input type="radio" id="rdoCon" name="rdoLog"  />   </td>
                </tr>
                
                <tr><td><label  CssClass="family"> User Name:</label>
                </td>
                <td><input type="text" id='UserName' runat="server" CssClass="field family" Style="width: 200px" />   </td>
                </tr>
                <tr><td><label  CssClass="family"> Password:</label>
                </td>
                <td>
                 <input id="Password" name="Password" runat="server" type="password" CssClass="field family" Style="width: 200px" />
                </tr>
                <tr>
                <td>
                 <input type="submit" id="btnLogin" runat="server" value="Log In"   class="family" width="90px" />
                                                       
                
                </td>
                </tr>
                </table>--%>
                  <%--  <asp:Login ID="Login1" runat="server"    TextLayout="TextOnTop">
                        <LayoutTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="family">User Name:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="field family" Style="width: 200px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1"
                                                        Style="color: red; font-weight: bold">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="family">Password:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="field family"
                                                        Style="width: 200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td>
                                                   <%-- <asp:Button ID="LoginButton" runat="server" BackColor="Gray" CommandName="Login"
                                                        Font-Bold="True" Font-Names="Calisto MT" Font-Size="Small" ForeColor="White"
                                                        Height="30px" Text="Log In" ValidationGroup="Login1" CssClass="family" Width="90px" />--%>
                                                        
                                               <%--   </td>
                                               <td style="color: Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdLabel" runat="server" colspan="2" style="display: none;">
                                                    <p class="lblBrowser">
                                                        Your Browser version does not support this application. Please use one of the following
                                                        browser version or the later versions</p>
                                                    <br />
                                                    <p class="lblBrowser">
                                                        IE 7.0, Firefox 3.6, Safari 5.0.x, Opera 10.0, Google Chrome
                                                    </p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <TextBoxStyle Font-Size="0.8em" />
                    </asp:Login>--%>
                    <%--<input type=hidden id="hdnSuccess" value='' runat="server" />--%>
                <%--</div>
            </td>
        </tr>
    </table>--%>
    </form>
</body>
</html>
