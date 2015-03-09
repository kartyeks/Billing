<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="AltioStarHR.Help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="Resources/Images/icon_userguide.gif" onclick="ViewManual();" alt=""/>
    </div>
    <input id='hdnEmployeeID' runat="server" type="hidden" />
            <input id='hdnLoggedinID' runat="server" type="hidden" />
            <input id='hdnType' runat="server" type="hidden" />
            <input type="hidden" id="hdnLoginType" runat="server" />
    </form>
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
        jQuery(document).ready(function() {
            
        });
        function ViewManual() {
            if ($("#hdnLoginType").val() == "Administrator" || $("#hdnLoginType").val() == "HR") {
                window.location.href = "DownloadFileHandler.ashx?Type=Help&DocumentName=Admin";
            }
            else if ($("#hdnLoginType").val() == "Team Manager") {
                window.location.href = "DownloadFileHandler.ashx?Type=Help&DocumentName=Manager";
            }
            else if ($("#hdnLoginType").val() == "Employee") {
                window.location.href = "DownloadFileHandler.ashx?Type=Help&DocumentName=Employee";
            }
        }
        
    </script>
</body>

</html>
