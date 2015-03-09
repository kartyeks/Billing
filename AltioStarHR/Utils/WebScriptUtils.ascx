<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="Utils_WebScriptUtils" Codebehind="WebScriptUtils.ascx.cs" %>
<style type="text/css">
    div.UtilityScriptControl
    {
        height: 0px;
        width: 0px;
        margin: 0;
        border: 0;
        overflow: hidden;
    }
</style>
<div id="WebScriptUtils_Main">
</div>

<script type="text/javascript" id="UtilityScriptControl_Init">

    function toDouble(Value) {
        if (Value == null || Value.length <= 0 || isNaN(Value)) {
            return 0;
        }
        else {
            return parseFloat(Value);
        }
    }

    function toInt(Value) {
        if (Value == null || Value.length <= 0 || isNaN(Value)) {
            return 0;
        }
        else {
            return parseInt(Value);
        }
    }

    function init() {
        jQuery.support.cors = true;
    }

    function htmlEncode(value) {
        if (typeof (value) == 'undefined') {
            return '';
        }

        return $('<div/>').text(value).html();
    }

    function FromJson(JsonString) {
        return JSON.parse(JsonString);
    }

    function ToJson(JsonObject) {
        return JSON.stringify(JsonObject);
    }

    function SendApplicationRequest(Command, Data, DisableAutoErrorHandling, RequestHandler, PagePath) { 
      debugger
        init();

        var RequestData = typeof Data == 'string' ? Data : ToJson(Data);

        var Response = new Object();
        Response.ResponseCommand = 'ERROR';
        Response.Message = 'Error in sending Web Request!';

        var RequestPage = null;

        if (!PagePath) {
            RequestPage = "~/AppCommandHandler.ashx";
        }
        else {
            RequestPage = PagePath;
        }

        $.ajax
        (
            {
                type: 'POST',
                url: RequestPage,
                data: 'RequestCommand=' + escape(Command) + '&RequestData=' + escape(RequestData) + '&RequestHandler=' + escape(RequestHandler),
                processData: false,
                async: false,
                success:
                    function(ResponseData) {
                        Response = ResponseData;
                    },
                error:
                    function(XMLHttpRequest, textStatus, errorThrown) {
                        Response.Message = 'Error in Web Request Response!';
                        Response.MessageDetail = textStatus + '-' + (errorThrown ? errorThrown : '');
                    }
            }
        );

        if (Response.ResponseCommand == 'ERROR' && PagePath != null) {

            var ret = window.showModalDialog('default.aspx?serve=DownloadFile&Message=' +
             'BROWSER_LOCAL_SERVICE_ERROR' +
              '&FileName=~/bin/LocalService.exe', window.self,
               "dialogHeight:100px; dialogWidth:300px; resizable:no; status:no; scroll:no;");

        }

        return Response;
    }

    function LoadPermissions(modulename, employeeid) {
    
        var arr = '';
        var Response = new Object();
        var Request = new Object();
        Request.FunctionName = $('#hdnmodule').val();
        Request.EmployeeID = $('#hdnEmployeeID').val();
        Response = SendApplicationRequest("<%=HRAppCommands.GET_PERMISSION_ASSIGNED%>", Request, true);
        if (Response.ResponseCommand == "<%=WebAppCommands.SUCCESS%>") {
            arr = Response.ResponseObject;
        }
        return arr;
    }
</script>

