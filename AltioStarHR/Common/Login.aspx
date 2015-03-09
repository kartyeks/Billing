<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AltioStarHR.Common.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>AltioStar HR</title>
    <base target="_self" />
    <link rel="stylesheet" href="Resources/css/login_style.css" />   
    
      
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
		fieldset { border:0;  margin-bottom: 40px;}
		select { width: 212px;}
		
	    .style1
        {
            height: 301px;
        }
		
	    .style2
        {
            width: 142px;
        }
		
	</style>
</head>
<body ThisPage="Login.aspx" noxmldata style="background-image:url(Resources/Images/login_pg_bg.jpg)">
    <form id="form1" runat="server">
        <table id="logintable" 
            style="margin-left:410px;margin-top:230px;background-image:url(Resources/Images/login_dialog.jpg)" width="520">
            <tr>
                <td class="style1">
                <table style="margin-left:10px;margin-top:150px;height: 150px;width: 500px;">
               <%-- <tr>
                    <td class="style2"><label style='font-family: TimesNewRoman, "Times New Roman", Times, Baskerville, Georgia, serif;'>Username</label></td><td><input type="text" /></td>
                </tr>
                <tr>
                    <td class="style2"><label style='font-family: TimesNewRoman, "Times New Roman", Times, Baskerville, Georgia, serif;'>Password</label></td><td><input type="text" /></td>
                </tr>--%>
                <tr>
                    <td colspan="2" align="center"><input class="submit" type="button" value="Login" onclick="OnLogin()"  /></td>
                </tr>
                </table>
                </td>
            </tr>    
        </table>
    </form>
</body>
<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/ircaobjs2.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/js2rw2.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-1.6.2.min.js") %>"></script>

<script src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.16.custom.min.js") %>" type="text/javascript"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/grid.locale-en.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.jqGrid.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Webutility.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/toolbar.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.core.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.widget.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.validate.js") %>"></script>

<script  src="<%=ResolveUrl("~/Resources/js/jquery.ui.button.js") %>" type="text/javascript"></script>

<script src="<%=ResolveUrl("~/Resources/js/ui.selectmenu.js") %>"  type="text/javascript"></script>

<script type="text/javascript">
   
    function OnLogin() {
       
        
        var SelectedRole = '0';
        var Request = new Object();
        Request.Username='admin';
        Request.Password ='';
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

        IRCAMAIN.smartNavigate(window, fx);

    }

//    function Authenticate() {
//        if ($('#txtusername').val() == "") {
//            alert('Please Enter Username');
//            $('#txtusername').focus();
//            return false;
//        }
//        
//        form1.submit();
//    }
    
    function OnForgot() {
       // showModalDialog('default.aspx?serve=ForgotPassword', self, "dialogHeight:300px; dialogWidth:450px; resizable:yes; status:no; scroll:no;");

    }
</script>
</html>
