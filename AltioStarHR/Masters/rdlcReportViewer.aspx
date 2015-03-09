<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rdlcReportViewer.aspx.cs" Inherits="AltioStarHR.Masters.rdlcReportViewer" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <base target="_self" />
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="../Resources/js/jquery-1.6.2.min.js"></script>
    
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
<%--    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
--%>    
     <script language="javascript" type="text/javascript">
         function window_onload() {
             if(document.getElementById("hdnClose").value=="true") {
                 window.returnValue="nodata";
                 window.close();
             }
         } 

     </script>
</head>
<body noxmldata onload="return window_onload()">
    <form id="form1" runat="server" action="Masters/rdlcReportViewer.aspx" >
    <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>
    <%--<iframe id="ifrmCntrl" visible="false" src='' height="0" width="0"></iframe>--%>
    <div style="width:100%;">
    
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="95%" ShowDocumentMapButton="false"  ShowRefreshButton="False"
        ShowPrintButton="false" ShowPageNavigationControls="true" AsyncRendering="False" SizeToReportContent="true" ShowFindControls=true
        ExportContentDisposition="AlwaysAttachment" Width="931px" >
    </rsweb:ReportViewer>
    </div>
    <input type=hidden id="hdnClose" value="false" runat="server" />
    </form>
</body>
</html>
