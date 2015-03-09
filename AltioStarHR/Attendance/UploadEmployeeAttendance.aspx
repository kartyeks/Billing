<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadEmployeeAttendance.aspx.cs" Inherits="AltioStarHR.Attendance.UploadEmployeeAttendance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
<base target="_self" />
    <title>Employee Attendance</title>
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
<%--    <div style="background-color: #003366; color: #FFFFFF; font-size: x-large; width: 940px;
        text-align: center">
        Employee Attendance
    </div>--%>

    <div style="background-color:#02d9f5; color: #FFFFFF; font-size:15x;height:20px; width:100%;text-align: center">
        <strong class="family1 imageheadercolor">Employee Attendance</strong>
        
    </div>
    <div id="divUploadSection" style="width:100%;padding-left:0%;background-color:White">
        <form id="form1"  runat="server" >
        <fieldset style="width:100%;margin-top:1%;background-color:#a4cd0f">
            <table style="width:100%">
                <tbody>
                    <tr>
                        <td>
                            <label id="luploadexcelfile" class="family">Upload Excel</label>
                            <span id="spmandatory" style="color:Red;"> *</span>
                            <input type="file" id="uploadexcelfile" name="uploadexcelfile" runat="server" class="family"/>
                            <span id="spmsg" style="color:Red;"> [.xlsx only]</span>
                        </td>
                    </tr>
                    <tr>
                    <td>
                        <input type="button" id="btnview" value="Save" runat="server" onclick="SaveFile()" class="family"/>
                        <input type="button" id="btncancel" value="Cancel" onclick="RedirectToEmployeeAttendance()" class="family"/>
                    </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
            <input type="hidden" id='hdnSaveResult' runat="server" />
            <input type="hidden" id='hdnMonth' runat="server" />
            <input type="hidden" id='hdnYear' runat="server" />
        </form>
    </div>
</body>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-1.6.2.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery-ui-1.8.16.custom.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/grid.locale-en.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.jqGrid.min.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Webutility.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/toolbar.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.core.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.ui.widget.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/jquery.validate.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/Validation.js") %>"></script>

<script type="text/javascript" src="<%=ResolveUrl("~/Resources/js/progress.js") %>"></script>

<script type="text/javascript">

    jQuery(document).ready(function() {
        
        if ($('#hdnSaveResult').val() != "") {
            alert($('#hdnSaveResult').val());
            $.hideprogress();
            RedirectToEmployeeAttendance();
        }
    });
    function SaveFile() {
        if (Validate()) {
            $.showprogress();
            form1.submit();
        }
    }

    function Validate() {
        if ($('#uploadexcelfile').val() == "") {
            alert('Browse a file to Upload');
            $('#uploadexcelfile').focus();
            return false;
        }
        var ext = $('#uploadexcelfile').val().split('.').pop().toLowerCase();
        if ($('#uploadexcelfile').val() != "" && $.inArray(ext, ['xlsx']) == -1) {
            alert('Invalid File! Only XLSX file type allowed.');
            return false;
        }
        
        var fl = $('#uploadexcelfile').val().split('.');
        var flname = fl[0];

        if (flname.match("Attendance")) 
            return true;
        else {
            alert('Incorrect file Uploaded');
            return false;
        }
        return true;
    }
    
    function RedirectToEmployeeAttendance() {
        window.close();
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
