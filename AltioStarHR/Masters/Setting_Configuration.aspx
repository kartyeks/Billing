<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setting_Configuration.aspx.cs" Inherits="AltioStarHR.Masters.Setting_Configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Benefits Configuration</title>
    <link rel="stylesheet" href="../Resources/css/dialog/smoothness/jquery-ui-1.8.16.custom.css" />
    <link rel="stylesheet" href="../Resources/css/dialog/demos.css" />
    <link type="text/css" href="../Resources/css/ui.jqgrid.css" rel="stylesheet" />
    <link type="text/css" href="../Resources/css/InsidePage.css" rel="stylesheet" />
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
        #Clientmaster
        {
            width: 217px;
        }
       
    </style>
</head>
<body>

  <div style="position:relative;width:100%">
    <img alt="" src="Resources/Images/NewImages/1.png" style="width:97%;margin-left:2%;height:53px;margin-top:0%"/>
    <div style="position:absolute;left:4%;top:30%;margin-top:1%;">
     <strong class="family1 imageheadercolor">Benefits Configuration Details</strong>
    </div>
</div>
    <div style="margin-left:2%;" id="box">
      <table id="list">
        </table>
        <div id="pager">
        </div>
    </div>
    <input type="hidden" id='hdnEmployeeID' runat="server" />
    <input type="hidden" id='hdnmodule' runat="server" />
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
    // Code to Prevent the BackSpace key from Working as "Go To Back Page."



    jQuery(document).ready(function() {

//        $(window).bind('resize', function() {
//            $("#list").setGridWidth($('#box').width() - 10, true);
//        }).trigger('resize');
        jQuery("#box").css({ width: "97%" });
        $("#box").css({ "background-image": "url(Resources/Images/NewImages/dashboard_bg.gif)", "width": "97%" });

        var lastsel2;
        var saveitid = 0;
        var currPage = 1;
        var myGrid = $('#list');

        var Response = SendApplicationRequest('<%=HRAppCommands.SETTING_CONFIGURATION_DETAILS%>', '');
        Response.ResponseObject.colModel = [
            { name: 'id', index: 'id', width: 20, hidden: true, sorttype: "int" },
            { name: 'name', index: 'name', width: 400, editable: false },
            {name: 'value', index: 'value', width: 100, editable: false }
        ];

        var he = $(window).height();
        var reduce = he * 0.63;
        Response.ResponseObject.height = reduce;
        Response.ResponseObject.autowidth= true;
        
        myGrid.jqGrid(Response.ResponseObject);
        jQuery("#list").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });
        jQuery("#list").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: "cn" });
        jQuery("#list").jqGrid('navButtonAdd', "#pager", { caption: "Toggle", title: "Toggle Search Toolbar", buttonicon: 'ui-icon-pin-s',
            onClickButton: function() {
                myGrid[0].toggleToolbar();
            }
        });
//         $("#list").closest(".ui-jqgrid-bdiv").height("auto");
        $("#t_list").closest(".ui-userdata").hide();
        jQuery("#list").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
        jQuery("#list").jqGrid('setGridWidth', "100%");

//        var mygrid = jQuery('#list'),
//        cDiv = mygrid[0].grid.cDiv;
//        mygrid.setCaption("");
//        $("a.ui-jqgrid-titlebar-close", cDiv).unbind();
//        $(cDiv).hide();
        //$("#list").closest(".ui-jqgrid-bdiv").height("auto");
        
        $('.textClass').keyup(function(e) {
            if (e.keyCode == 8) {
                $("#" + this.id).css("background-color", "lightpink");
            }
        });
        $(".textClass").bind("keypress", function(e) {

            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 13) {
                var id = this.id;
                var Request = new Object();
                Request.ID = id.split('_')[1];
                Request.ConfigValue = $("#" + this.id).val();
                Request.UpdateBy = $("#hdnEmployeeID").val();
                if (isNaN($("#" + this.id).val())) {
                    alert("Invalid Number");
                    return;
                }
                var Response = SendApplicationRequest('<%=HRAppCommands.UPDATE_SETTING_CONFIGURATION%>', Request, true);
                alert(Response.Message);
                $("#" + this.id).css("background-color", "lightgreen");

            }
            else {
                $("#" + this.id).css("background-color", "lightpink");
            }
        });
    });
    
    


</script>

<script type="text/javascript">
    $(document).ready(function() {
        $('body').css('background', 'none');
        $('#pager input[type=text]').css('width', '40px');
        $('#pager select').css('width', '50px');
        $('#pager select').css('margin-left', '15px');
    });
</script>
</html>
