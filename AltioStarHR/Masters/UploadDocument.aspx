<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadDocument.aspx.cs" Inherits="AltioStarHR.Masters.UploadDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <base target="_self" />
    <title>Document Upload</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/hrStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
<body TargetPage="self">
    <form id="form1" runat="server" action="UploadDocument.aspx" method="post">
    <div>
        <div class="header_title" style="width: 360px; margin: 0">
            Upload Document
        </div>
        <br />
        <table class="teble_bg" style="background-color:#a4cd0f">
            <tr>
                <td>
                    Document Title
                </td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="documentTitle" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="label">
                    <span id="lblUpload" runat="server">Document</span>
                </td>
            </tr>            
            <tr>
                <td>
                    <input type="file" tabindex="1" style="width: 359px;
                        height: 25px;" id="uploadDocument" runat="server" />
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr align="center" id="buttonForEmp">
                <td class="field">
                    <input id="Save" name="Save" type="button" value="Save" tabindex="2" onclick="return OnSave()"
                        runat="server" />
                    &nbsp; &nbsp; &nbsp;
                    <input id="Cancel1" name="Cancel" type="button" tabindex="3" value="Cancel" onclick="return onCancel();" />
                </td>
            </tr>
        </table>
    </div>
    <input id="hdnEmpID" type="hidden" runat="server" />
    </form>
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
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('input[type=button]').button();
        $('input[type=submit]').button();
        $('button').button();
       // $('input[type=text]').addClass('text ui-widget-content ui-corner-all');
        $('textarea').addClass('text ui-widget-content ui-corner-all');
       // $('select').addClass('text ui-widget-content ui-corner-all');

    });
</script>

<script type="text/javascript">
    jQuery(document).ready(function() {
    });
    
    function OnSave() {
    
    Loaddoccombo();
    }
   
    function checkImage() {
        if (document.getElementById("uploadDocument").value == '') { alert("Select a Document to Upload");  return false };
        var ext = document.getElementById("uploadDocument").value;

        ext = ext.substring(ext.length - 3, ext.length);
        ext = ext.toLowerCase();        
    }
    function onCancel() {
        window.close();
    }

 function Loaddoccombo() {
       if (document.getElementById("documentTitle").value == "") {
            alert("Please provide a document title");
            return false;
        }     
        else if (document.getElementById("uploadDocument").value == "") {
            alert("Please browse a document to upload");
            return false;
        }
        document.getElementById('form1').submit();
    }
      
</script>
</html>
