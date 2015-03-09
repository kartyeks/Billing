<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkDataUpload.aspx.cs" Inherits="AltioStarHR.Masters.BulkDataUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Employee details upload</title>
        <base target="_self" />
      <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
    <link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />
    <script src="Resources/js/Newjs/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Resources/js/Newjs/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
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
<body TargetPage="self">
     <form id="form1" runat="server" action="Masters\BulkDataUpload.aspx" method="post">
  <div id='dvTitle' runat="server"></div>
     <div>
        <fieldset>
            <table>
                <tr>
                    <td>
                        <label class="label">
                            Select File:
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="file" id="fileUpload" runat="server" />
                         <span id="spmsg" style="color:Red;"> [.xlsx only]</span>
                    </td>
                </tr>
            </table>
             <br />
        <table>
            <tr align="center" id="buttonForEmp">
                <td class="field">
                    <input id="Save" name="Save" type="button" value="Save" tabindex="1" onclick="return OnSave()"
                        runat="server" />
                   
                </td>
                <td class="field">
                    <input id="Cancel" name="Cancel" type="button" value="Cancel" tabindex="2" onclick="return OnCancel()"
                        runat="server" />
                   
                </td>
            </tr>
        </table>
        </fieldset>
    </div>
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
<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/progress.js") %>"></script>

<script type="text/javascript">
    jQuery(document).ready(function() {
    });
    function OnSave() {  
      
        var fld = document.getElementById("fileUpload");
        if (fld.value == "") {
            alert("Please select a file to upload the data.");
            return;
        }

        var valid = CheckExtension(fld);

        if (valid) {
            $.showprogress();
            document.getElementById('form1').submit();
           
        }
        else {
            alert("Please select an Excel file to upload the data.");
            return;
        }
    }
    
    
    var valid_extensions = /(.xlsx)$/i;
    function CheckExtension(fld) {
        if (fld.value) {
            if (valid_extensions.test(fld.value)) {
                return true;
            } else {
                return false;
            }
        } else {
            return true;
        }
    }

    function OnCancel() {
        window.close();   
    }
</script>
</html>
