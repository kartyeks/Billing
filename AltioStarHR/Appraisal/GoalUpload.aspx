﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoalUpload.aspx.cs" Inherits="AltioStarHR.Appraisal.GoalUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <base target="_self" />
    <title>Goal Upload</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link href="../Resources/css/hrStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/css/InsidePage.css" rel="stylesheet" type="text/css" />
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
        .ui-datepicker {
            background: #00daf5;
            
         }
         .ui-datepicker-header {
          background: #00daf5;
        }
        .ui-datepicker-calendar
        {
          background : #00daf5;	
        }
        
        
        
      

        
    </style>
</head>
<body TargetPage="self" >
    <form id="form1" runat="server" action="GoalUpload.aspx" method="post">
     <div style="background-color:#02d9f5; color: #FFFFFF; font-size:15x;height:20px; width:100%;text-align: center">
        <strong class="family1 imageheadercolor">Altiostar Employee Performance Review Form</strong>
        
    </div>
    <div class="family">
        <table style="width:100%;background-color:#a4cd0f">
            <tr>
                <td class="family">Intimation Date</td>
                <td ><input type="text" id="datepick" style="width: 80px;overflow: hidden;background-repeat: no-repeat;" readonly 
                    name="datepick" runat="server" /></td>
            </tr>            
            <tr>
                <td class="label">
                    <span id="lblUpload" runat="server" class="family">Upload form</span>
                </td>
                <td>
                    <input type="file" tabindex="1" style="width: 359px; 
                        height: 25px;" id="uploadDocument" runat="server" class="family"
                        accept="application/pdf,application/msword,application/vnd.openxmlformats-officedocument.wordprocessingml.document" />
                    
                </td>
            </tr>                       
            <tr id="buttonForEmp">
                <td class="field">
                    <input id="Save" name="Save" type="button" value="Save" tabindex="2" onclick="return OnSave()"
                        runat="server" class="family" style="background-color:#00DBF1;"/>
                   
                    <input id="Cancel1" name="Cancel" type="button" tabindex="3" value="Cancel" onclick="return onCancel();" 
                        class="family" style="background-color:#00DBF1;"/>
                </td>
            </tr>
        </table>        
    </div>
    <input type="hidden" id="hdnEmployeeID" runat="server"/>
    </form>
    
</body>
<link href="Resources/css/NewCss/jquery-ui-1.10.3.custom2.css" rel="stylesheet"type="text/css" />

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
        $('input[type=submit]').button();
        $('button').button();
        $('textarea').addClass('text ui-widget-content ui-corner-all');
        $(function() {
            $("#datepick").datepicker({
                showOn: "button",
                buttonImage: "../Resources/Images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1930:2050'
            });
            $("#datepick").datepicker("option", "dateFormat", 'dd/mm/yy');
        });

    });
</script>

<script type="text/javascript">
    jQuery(document).ready(function() {
    });
    
    function OnSave() {
    
    Loaddoccombo();
    }
    
    function onCancel() {
        window.close();
    }

 function Loaddoccombo() {
      if (document.getElementById("uploadDocument").value == "") {
            alert("Please browse a document to upload");
            return false;
        }
        if(document.getElementById("uploadDocument").value.split('.').pop().toLowerCase()!='docx' && document.getElementById("uploadDocument").value.split('.').pop().toLowerCase()!='pdf')
        {
            alert("Please select 'docx' or 'pdf' type file only");
            return false;
        }
        if ($("#datepick").val() == "") {
            alert("Select intimation date");
            return false;
        }
        document.getElementById('form1').submit();
    }
      
</script>
</html>
