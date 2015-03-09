var _FWStndCode = '<object id="{0}" width="{1}" height="{2}" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0">' +
    '<param name="movie" value="{3}">' +
    '<param name="salign" value="{4}">' +
    '<param name="quality" value="High">' +
    '<param name="play" value="True">' +
    '<param name="wmode" value="transparent">' +
    '<param name="loop" value="True">' +
    '<param name="menu" value="False">' +
    '<param name="scale" value="{5}">' +
    '<embed name="FlashControl1" wmode="transparent" src="{3}" quality="High" play="True" menu="False" scale="{5}" loop="False" type="application/x-shockwave-flash" salign="t" width="{1}" height="{2}" pluginspage="http://www.macromedia.com/go/getflashplayer">' +
    '</embed></object>';

var _FWStndCode1 = '<OBJECT CLASSID="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" ' +
    'CODEBASE="http://active.macromedia.com/flash5/cabs/swflash.cab#version=5,0,0,0"' +
    'ID={0} WIDTH={1} HEIGHT={2}>' +
    '<PARAM NAME="movie" VALUE="{3}"> ' +
    '<PARAM NAME="play" VALUE="true"> ' +
    '<PARAM NAME="quality" VALUE="high"> ' +
    '<param name="scale" value="Showall">' +
    '<param name="wmode" value="transparent">' +
    '<EMBED NAME=FWBanner wmode="transparent" SRC={3} WIDTH={1} HEIGHT={2} PLAY=true scale=Showall ' +
    'SWLIVECONNECT=true QUALITY=high>' +
    '</OBJECT>'

String.format = function() {
    if (arguments.length == 0) return null; var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm'); str = str.replace(re, arguments[i]);
    }; return str;
};
function ActivateFlash(divid, flashid, width, height, src, salign, scale) {
    if (navigator.appName == "Netscape") {
        document.getElementById(divid).innerHTML = String.format(_FWStndCode1, flashid, width, height, src, salign, scale);
    } else if (navigator.appName == "Microsoft Internet Explorer") {
        document.getElementById(divid).innerHTML = String.format(_FWStndCode, flashid, width, height, src, salign, scale);
    } else {
        document.getElementById(divid).innerHTML = String.format(_FWStndCode1, flashid, width, height, src, salign, scale);
    }
}

function ActivateMusic() {
    //removed the code base code in first line.
    //    document.write('<object id="MediaPlayer1" width="1" height="1" classid="CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95" codebase="http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,0,02,902" standby="Loading Microsoft Windows Media Player..." type="application/x-oleobject">');
    document.write('<object id="MediaPlayer1" width="1" height="1" classid="CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95" standby="Loading Microsoft Windows Media Player..." type="application/x-oleobject">');
    document.write('<param name="FileName" value="../MediaFiles/Trial.mp3">');
    document.write('<param name="animationatStart" value="false">');
    document.write('<param name="transparentatStart" value="true">');
    document.write('<param name="autoStart" value="true">');
    document.write('<param name="showControls" value="false">');
    document.write('<param name="Volume" value="-100">');
    document.write('<embed type="application/x-mplayer2" pluginspage="http://www.microsoft.com/Windows/MediaPlayer/" Name="MediaPlayer" src="Trial.mp3" AutoStart="true" ShowStatusBar="1" volume="-1" HEIGHT="1" WIDTH="1"></embed></object>');
}


function getFileContent(FileName) {
    try {
        var NewExeObjx = getRequestObject1();
        NewExeObjx.open("GET", '../htmlHandler.ashx/' + FileName, false);
        NewExeObjx.setRequestHeader("&param", 'IS91');
        NewExeObjx.send('');
        if (!NewExeObjx.status == 200) { return ''; }
        return NewExeObjx.responseText;
        
    } catch (e) { return ''; };
}

var objXML = null;
function getIGHRequestObject() {
    if (window.XMLHttpRequest) {//for IE7 version
        objXML = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {//for IE6 and IE5 version
        try {
            objXML = new ActiveXObject("Microsoft.XMLHTTP");
        } catch (err) {
            objXML = new ActiveXObject("Microsoft.XMLHTTP");
        }
    }
}

function getRequestObject1() {
    if (window.XMLHttpRequest) {
        return new window.XMLHttpRequest();
    } else {
        try {
            return new ActiveXObject("MSXML2.XMLHTTP");
        } catch (err) {
            return new ActiveXObject("Microsoft.XMLHTTP");
        }
    }
};

function getEmailIds(strEmail, langID) {
    var strEmailID = strEmail;
    if (strEmailID == "") { alert(getValue('msg$5', langID)); return false; }
    if (strEmailID != "" || strEmailID != null) {
        var tmp = new Array();
        tmp = strEmailID.split(', ');
        var count = tmp.length;
        for (var i = 0; i < count; i++) {
            if (!validateEmail(tmp[i], langID)) {
                return false;
            }
        }
        return true;
    }
    return false;
}

function validateEmail(EmailID, langID) {
    if (EmailID == "") {
        alert(getValue('msg$5', langID)); //alert("Email ID cannot be empty!!");
        return false;
    } else {
        var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        if (!emailPattern.test(EmailID)) {//alert("enter valid email id");return false}
            alert(getValue('msg$4', langID)); return false;
        }
        return true;
    }
}

var xmlDoc = null;
function getValue(msgID, langID, fileName) {
    try {
        if (window.ActiveXObject) { xmlDoc = new ActiveXObject("MSXML2.DOMDocument"); }
        else { xmlDoc = document.implementation.createDocument; }
    }
    catch (e) { alert("Failed to Load XML Document"); }

    xmlDoc.async = false;
    if (fileName == null || fileName == '') {
        xmlDoc.load("../ML_XML/Common/Message_Lang_Map.xml");
    } else if (fileName == "ToolBarContent") {
        xmlDoc.load("../ML_XML/Common/ToolBarContent_Lang_Map.xml");
    } else {
        xmlDoc.load("../ML_XML/Common/" + fileName + "_Lang_Map.xml");
    }

    if (langID == "" || langID == null) { langID = "en-gb"; }
    var mNode = xmlDoc.selectSingleNode("//Messages/Message[@id=\"" + msgID + "\"]");
    var messageContent = "";
    if (langID == '' || langID == undefined) return 0;
    if (mNode != null) {
        messageContent = mNode.selectSingleNode("//Messages/Message[@id=\"" + msgID + "\"]//Language[@id='" + langID + "']").text;
    }
    if (messageContent == null || messageContent == "undefined") {
        return 0;
    }
    else {
        return messageContent;
    }
}

function getUniqueID() {
    var currDate = new Date();
    var tmpStr = currDate.getDate();
    var tmpStr1 = currDate.getTime();
    var tmpStr2 = currDate.getMinutes();
    var tmpStr3 = currDate.getSeconds();
    var tmpStr4 = currDate.getMilliseconds();
    var tmpStr5 = currDate.getHours();
    var tmpStr6 = currDate.getFullYear();
    return tmpStr + tmpStr1 + tmpStr2 + tmpStr3 + tmpStr4 + tmpStr5 + tmpStr6;
}

var brwsName = '';
var xmlDoc = null;
function loadClientXML() {
    try {
        if (window.ActiveXObject) { xmlDoc = new ActiveXObject("MSXML2.DOMDocument"); }
        else { xmlDoc = document.implementation.createDocument; }
    } catch (e) { alert("Failed to Load XML Document"); }
}


function OnlyNumbers(e) {
    window.brwsName = window.navigator.appName;
    if (navigator.appName != 'Microsoft Internet Explorer') {
        if (window.brwsName.toLowerCase() != "netscape") {
            if (event.keyCode < 48 || event.keyCode > 57) {
                //window.event.keyCode = 0;
                return false;
            }
        } else {
            evt = e || event;
            if (evt.charCode != 0 && evt.charCode < 48 || evt.charCode > 57) {
                evt.preventDefault();
            }
        }
    } else {
        if (window.brwsName.toLowerCase() != "netscape") {
            if (window.event.keyCode < 48 || window.event.keyCode > 57) {
                //window.event.keyCode = 0;
                return false;
            }
        } else {
            evt = e || window.event;
            if (evt.charCode != 0 && evt.charCode < 48 || evt.charCode > 57) {
                evt.preventDefault();
            }
        }
    }

}

function OnlyNumbersWithPlus(e, val) {
    if (navigator.appName != 'Microsoft Internet Explorer') {
        if (event.keyCode == 43 && val.indexOf("+") < 0) return;
        if (event.keyCode < 48 || event.keyCode > 57) {
            event.keyCode = 0;
        } else {
            if (val == '')
                document.getElementById(event.srcElement.id).value = "+" + document.getElementById(event.srcElement.id).value;
        }
    } else {
        if (window.event.keyCode == 43 && val.indexOf("+") < 0) return;
        if (window.event.keyCode < 48 || window.event.keyCode > 57) {
            window.event.keyCode = 0;
        } else {
            if (val == '')
                document.getElementById(window.event.srcElement.id).value = "+" + document.getElementById(window.event.srcElement.id).value;
        }
    }

}

function ConvertUpperChar(val, id) {
    document.getElementById(id).value = val.toUpperCase();
}

function OnlyCharacters(e) {
    window.brwsName = window.navigator.appName;
    if (navigator.appName != 'Microsoft Internet Explorer') {
        if (window.brwsName.toLowerCase() != "netscape") {
            if (event.keyCode < 65 || event.keyCode > 122) {
                //window.event.keyCode = 0;
                return false;
            }
        } else {
            evt = e || event;
            if (evt.charCode != 0 && evt.charCode < 65 || evt.charCode > 122) {
                evt.preventDefault();
            }
        }
    } else {
        if (window.brwsName.toLowerCase() != "netscape") {
            if (window.event.keyCode < 65 || window.event.keyCode > 122) {
                //window.event.keyCode = 0;
                return false;
            }
        } else {
            evt = e || window.event;
            if (evt.charCode != 0 && evt.charCode < 65 || evt.charCode > 122) {
                evt.preventDefault();
            }
        }
    }

}

function checkEmail(e) {
    re = /(@.*@)|(\.\.)|(^\.)|(^@)|(@$)|(\.$)|(@\.)/;
    re_two = /^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,3}|[0-9]{1,3})(\]?)$/;
    if (!e.match(re) && e.match(re_two)) return true;
    else return false;
}

function PrintPage() {
    window.print();
}

function AddToFavorite() {
    if (document.all)
        window.external.AddFavorite(window.ChildWB.document.location, window.document.title);
}

function Emaillink() {
    var oFrame = document.getElementById('ChildWB');
    var oFrameContent = oFrame.contentWindow.frameElement.document.documentElement.outerHTML;
    var emailID = prompt("Enter the EmailId", '');
    if (!getEmailIds(emailID)) return false;
    oFrame.document.forms[0].method = "Post";
    oFrame.document.forms[0].action = "mailto:" + emailID + "?body=" + oFrameContent;
    oFrame.document.forms[0].encoding = "application/x-www-form-urlencoded";
    return;
}

function setDivContentBI() {
    if (document.getElementById('divContent') != null)
        document.getElementById('divContent').style.backgroundImage = "url('../APPWEBSITERES.ashx/golfer.png')";
}

function GetCorrectAccountNumber(accNum) {
    accNum = accNum.replace('-', '');
    accNum = accNum.replace(' ', '');
    return accNum;
}