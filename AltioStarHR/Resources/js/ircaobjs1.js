var IRCAMAINOBJ;
var IRCAMAIN;
var IRCA;
var ircaObject;

var id;
var readOnly;
var unLockPg;
var ReqXMLstr;
var ReqXMLstr;
var IRCAAuth;
var IRCAWind;
var Readonlytitle;
var keyValue;
var parentKeyValue;
var appConfigManager;
var tmpdocfocus;
var _md5HashAlg;


// declarations outside the Objects are to be pushed out from here
var WinReg = new Array();
var myDefaultUrl = "APPPAGEHANDLER.ashx";
var xPool = new Array();
// The IRCA Objects here are to the maximum extent stateless. It is attached to the window
//Class for IRCA Main page functions 

function IRCAMAINOBJ() { // constructor
    this.id = "IRCA MAIN";
    this.window = window;
    this.document = this.document;
    this.readOnly = false;
    this.unLockPg = "";
    this.ReqXMLstr = "";
    this.IRCAAuth = '';
    this.IRCAWind = '';
    this.Readonlytitle = '  [ READ ONLY ]';
    this.keyValue = '';
    this.parentKeyValue = ''
    this.appConfigManager = IRCAMAINOBJ.getNewdomXml('appConfigManager', true);
    this.tmpdocfocus = null; 
    this._md5HashAlg = new IRCAMAINOBJ.md5HashAlg();
    if (document.getElementById("AppCConfig")) {
        this.appConfigManager.root = 'appconfig/';
        this.appConfigManager.domObj.loadXML(document.getElementById("AppCConfig").innerHTML)
    };
};

IRCAMAIN = new IRCAMAINOBJ();
IRCAMAIN.IRCAWind = name;
IRCA = new IRCAOBJ(null, null, true); //tell IRCAOBJ that this is main
ircaObject = IRCA;

IRCAMAINOBJ.prototype.splitStrA = "|~|";
IRCAMAINOBJ.prototype.splitStrB = "|^|";
IRCAMAINOBJ.prototype.getConfigValue = function(configpath) { if (!this.appConfigManager) { return '' }; return this.appConfigManager.getXMlNodeValue(configpath); };
IRCAMAINOBJ.prototype.getWindow = function() { return this.window }
IRCAMAINOBJ.prototype.getNewInstance = function(windref) { return new this.IRCAOBJ(windref, this); }
IRCAMAINOBJ.prototype.formNavigation = function(thisnodeid, eventtype, reqstype, reqWind, popfuncref) { return FormNavigation(thisnodeid, eventtype, reqstype, reqWind, popfuncref); }
IRCAMAINOBJ.prototype.LockWin = function(PDOC, reqWind) { try { LockWin(PDOC, reqWind); } catch (e) { return false }; return true; };
IRCAMAINOBJ.prototype.UnlockWin = function(PDOC, reqWind) { try { UnlockWin(PDOC, reqWind); } catch (e) { return false }; return true; };
IRCAMAINOBJ.prototype.mtshow = function() { try { mtshow(); } catch (e) { return false }; return true; };
IRCAMAINOBJ.prototype.mthide = function() { try { mthide(); } catch (e) { return false }; return true; };
IRCAMAINOBJ.prototype.disableWind = function(wndref) { this.windLock(wndref.document); };
IRCAMAINOBJ.prototype.enableWind = function(wndref) { this.windUnLock(wndref.document); };
var MsgXmlDoc = null;
IRCAMAINOBJ.prototype.getValue = function(msgID, langID, fileName) {
    if (!MsgXmlDoc) {
        try {
            if (ActiveXObject) { MsgXmlDoc = new ActiveXObject("MSXML2.DOMDocument"); }
            else { MsgXmlDoc = document.implementation.createDocument; }
            MsgXmlDoc.async = false;
            if (fileName == null || fileName == '') {
                MsgXmlDoc.load("ML_XML/Message_Lang_Map.xml");
            } else {
                MsgXmlDoc.load("ML_XML/" + fileName + "_Lang_Map.xml");
            }
        } catch (e) { alert("Failed to Load Message XML Document"); }
    };
    if (langID == '' || langID == null) langID = "en-gb";
    var mNode = MsgXmlDoc.selectSingleNode("//Messages/Message[@id=\"" + msgID + "\"]");
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
};
IRCAMAINOBJ.prototype.showWindow = function(type, path, name, windarg, windfeatures, parentwind, withObj, xarg) {
    // follow the same window arguments style as of here.
    var pname = parentwind + "";
    windarg = this.getWindowByName(windarg); parentwind = this.getWindowByName(parentwind);
    if (!type) { type = "new" }; if (!name) { name = "unknown" + WinReg.length }; if (!parentwind) { parentwind = this.window };
    if (!windarg) { windarg = parentwind };
    var newwind;
    switch (type) {
        case "new":
            if (windfeatures) {
                newwind = parentwind.open(path, name, windfeatures);
            } else {
                newwind = parentwind.open(path, name);
            }
            //newwind.attachEvent('onbeforeunload',function(){newwind.ircaObject.ircaMain().unRegWindow(this.name)});
            this.regWindow(name, newwind, pname, true);
            return WinReg[name];
            break;

        case "modal": case "nonmodal":
            //guru lock
            this.drawDialog(path, true, false, 'RCAT Platinum - Selection', parentwind, windfeatures.dialogHeight, windfeatures.dialogWidth);
            break;
    }
};
IRCAMAINOBJ.prototype.regWindow = function(name, windowref, pname, isNewWind) {
    WinReg[name] = windowref;
    WinReg.push(name);
    //    if(!isNewWind){
    //	    windowref.execScript('name="'+name + '";pname="' + pname + '";opener=dialogArguments[0]');
    //    }
};
IRCAMAINOBJ.prototype.unRegWindow = function(name, pname, boolprefresh) {

    if (WinReg[name]) {
        var indx = this.getArrIndexbyName(name, WinReg);
        delete WinReg[WinReg[indx]];
        WinReg.splice(indx, 1);
        delete WinReg[name];
    }

};
IRCAMAINOBJ.prototype.unRegWindows = function() {
    for (var unr = WinReg.length; unr >= -1; unr--) {
        try {
            WinReg[WinReg[unr]].close();
        } catch (e) { };
        delete WinReg[WinReg[unr]];
        WinReg.splice(unr, 1);
    }
};
IRCAMAINOBJ.prototype.cleanup = function() {
    for (var unr = WinReg.length; unr > 0; unr--) {
        try {
            if (!WinReg[unr].closed && WinReg[unr].location) { } else { delete WinReg[unr]; }
        } catch (e) { };
        WinReg[unr] = null;
    }
};
IRCAMAINOBJ.prototype.WriteMeUp = function(pwind, mewind, pgstr) {
    pwind = this.getWindowByName(pwind);
    mewind = this.getWindowByName(mewind);
    if (!pwind.opener) { pwind.opener = mewind.self };
    if (pgstr) {
        var newdoc = mewind.document.open("text/html", "replace");
        mewind.execScript("ircaObject=dialogArguments[0].ircaObject.ircaMain().getNewInstance(window)");
        newdoc.write(pgstr);
        newdoc.namespaces.add("IRCAAuth", pwind.document.namespaces("IRCAAuth").urn);
        mewind.execScript('attachEvent("onunload",function(){ircaObject.ircaMain().unRegWindow(name,dialogArguments[0].name,boolprefresh||false)})');
        newdoc.close();
    };
};
IRCAMAINOBJ.prototype.smartNavigate = function(refTargetWindow, strPageHTML) {

    if (!refTargetWindow) { return };
    this.AppLock();
    if (!arguments[2]) {
        if (!isTextHTML(strPageHTML)) {
            getFile(strPageHTML, true, false, function(sCont) { this.IRCAMAIN.smartNavigate(refTargetWindow, sCont, true) });
            return;
        }
    }
    if (refTargetWindow.document && refTargetWindow.document.readyState != 'complete') { return };
    var thissrc = "if(typeof(targetWindow)=='undefined'){var targetWindow=window};var newdoc=targetWindow.document.open('text/html', 'replace');" +
    "if(typeof(_ParentIRCAMAIN)!='undefined'){targetWindow.ircaObject=_ParentIRCAMAIN.getNewInstance(targetWindow)};" +
    "newdoc.write(CWBpgstrA);" +
    "newdoc.close();"
    if (window == refTargetWindow) {
        __mFuncStub = new Function('No_ParentIRCAMAIN', 'targetWindow', 'CWBpgstrA', thissrc);
    } else {
        __mFuncStub = new Function('_ParentIRCAMAIN', 'targetWindow', 'CWBpgstrA', thissrc);
    }
    refTargetWindow.setTimeout(function() { __mFuncStub(this.IRCAMAIN, refTargetWindow, strPageHTML) }, 0);
    this.AppLock(true);
};
IRCAMAINOBJ.prototype.getWindowByName = function(strwindow) {
    if (!strwindow) { return "" };
    if (typeof (strwindow) != "string") { return strwindow };
    if (strwindow.toLowerCase() == "childwb") {
        return ChildWB;
    } else if (strwindow.toLowerCase() == "main") {
        return window;
    };
    if (WinReg[strwindow] == null) {
        return strwindow;
    } else {
        return WinReg[strwindow];
    };
};
IRCAMAINOBJ.prototype.windLock = function(id, zindx) {//(docObj)
    var docObj = this.document;
    if (!id) id = 'winlock'; if (!zindx) zindx = 2211;
    if (id == 'winlock' && winlock) {
        docObj.getElementById('winlock').style.display = '';
        return;
    };
    var docH = Math.max(docObj.body.offsetHeight, docObj.body.scrollHeight) + 10;
    var docW = docObj.body.clientWidth;
    if (id != 'winlock') this.windUnLock(id);
    var temptag = '<IFRAME id=' + id + ' style="display:block;visibility:visible;LEFT: -1px; POSITION: absolute; TOP: -1px; z-index: ' + zindx + '; width:' + docW + 'px;height:' + docH + 'px;  filter: progid:dximagetransform.microsoft.alpha(style=0,opacity=50);" src="APPRES.ashx/1664805296/_blank.htm" frameBorder="no" scrolling="no"></IFRAME>'
    //var temptag='<DIV id="winlock" onclick="event.cancelBubble=true;return false;" onkeydown="event.cancelBubble=true;return false;" style="cursor:wait;background: gainsboro url(APPRES.ashx/1664805296/white.gif);display:block;visibility:visible;LEFT: -1px; POSITION: absolute; TOP: -1px; z-index: 2211; width:'+docW+'px;height:'+docH+'px; filter: progid:dximagetransform.microsoft.alpha(style=0,opacity=50);" ></DIV>'
    docObj.body.insertAdjacentHTML('beforeEnd', temptag);
    //docObj.parentWindow.attachEvent('onresize',function(){this.IRCAMAIN.lockWindowOnResize(event,null,id);});
};
IRCAMAINOBJ.prototype.lockWindowOnResize = function(evt, forControl, id) {
    if (!id) id = 'winlock';
    if (!this.document) { return }; var lockObj; var thisPObj = this.document.body; lockObj = this.document.all[id];
    if (forControl != null) { thisPObj = forControl; lockObj = thisPObj.document.all[forControl.id + '_irca__cntrlLocker'] };
    if (!lockObj) { return };
    var docH = Math.max(thisPObj.offsetHeight, thisPObj.scrollHeight);
    var docW = thisPObj.clientWidth;
    lockObj.style.width = docW + 'px';
    lockObj.style.height = docH + 'px';
};
IRCAMAINOBJ.prototype.hideControls = function(controls, unhide) {
    if (!controls) { return }; if (!controls.length || controls.length < 1) { return };
    var control;
    for (var i = 0; i < controls.length; i++) {
        control = controls[i];
        if (unhide) {
            if (control.style.visibility == 'hidden' && control.getAttribute('__windlockitem')) {
                control.removeAttribute('__windlockitem'); control.style.visibility = 'visible';
            }
        } else {
            if ((control.style.visibility == 'visible' || control.style.visibility == '') && control.getAttribute('nolockhide') == null) {
                control.setAttribute('__windlockitem', true); control.style.visibility = 'hidden';
            }
        }
    };
};
IRCAMAINOBJ.prototype.makeBW = function(docObj) {
    if (!docObj) { docObj = document }; if (!docObj.body) { return };
    docObj.body.className += ' ApplyBW';
};
IRCAMAINOBJ.prototype.removeBW = function(docObj) {
    if (!docObj) { docObj = document }; if (!docObj.body) { return };
    docObj.body.className = docObj.body.className.replace(' ApplyBW', '');
};
IRCAMAINOBJ.prototype.windUnLock = function(id) {//(docObj)
    var docObj = this.document;
    if (!id) id = 'winlock';
    try {
        if (docObj.getElementById(id)) {
            //docObj.parentWindow.detachEvent('onresize',function(){this.IRCAMAIN.lockWindowOnResize(event,null,id);});
            if (id == 'winlock') docObj.getElementById(id).style.display = 'none';
            else docObj.getElementById(id).removeNode(true);
            //this.hideControls(docObj.getElementsByTagName('SELECT'),true);if(docObj.parentWindow.ChildWB && docObj.parentWindow.ChildWB.document)this.hideControls(docObj.parentWindow.ChildWB.document.getElementsByTagName('SELECT'),true);
        };
    } catch (e) { }
};
IRCAMAINOBJ.prototype.lockControl = function(controlObj) {
    this.unLockControl(controlObj);
    var docHpx = (calcRealHeight(controlObj) + 5);
    var docWpx = (calcRealWidth(controlObj) + 5);
    var lockerzIndex = Math.max(controlObj.style.zIndex + 1, 2211);
    var temptag = '<DIV id="' + controlObj.id + '_irca__cntrlLocker" z-index: ' + lockerzIndex + '; onclick="event.cancelBubble=true;return false;" onkeydown="event.cancelBubble=true;return false;" style="cursor:wait;background: gainsboro url(APPRES.ashx/1664805296/white.gif);display:block;visibility:visible;LEFT: -1px; POSITION: absolute; TOP: -1px; z-index: 2211; width:' + docWpx + 'px;height:' + docHpx + 'px; filter: progid:dximagetransform.microsoft.alpha(style=0,opacity=40);" ></DIV>'
    controlObj.insertAdjacentHTML('beforeEnd', temptag);
    controlObj.attachEvent('onresize', function() { this.IRCAMAIN.lockWindowOnResize(null, controlObj); });
};
IRCAMAINOBJ.prototype.unLockControl = function(controlObj) {
    var irLocker = controlObj.document.getElementById(controlObj.id + '_irca__cntrlLocker');
    if (irLocker) {
        controlObj.detachEvent('onresize', function() { this.IRCAMAIN.lockWindowOnResize(null, controlObj); });
        irLocker.removeNode();
    };
};
function getRequestObject() {

    if (XMLHttpRequest) {
        return new XMLHttpRequest();
    } else {
        try {
            return new ActiveXObject("MSXML2.XMLHTTP");
        } catch (err) {
            return new ActiveXObject("Microsoft.XMLHTTP");
        }
    }
};
function getUniqueUrl(strUrl) {
    var dtsend = this.IRCAMAIN.getUniqueID();
    if (strUrl.indexOf("?") > 0)
        return strUrl + "&" + dtsend;
    else
        return strUrl + "?" + dtsend;
};
function setBasicHeaders(xRequestObject, NoCompressHeadr) {
    try {
        xRequestObject.setRequestHeader("Content-Type", "text/xml");
        xRequestObject.setRequestHeader("IRCAAuth", document.namespaces("IRCAAuth").urn || ".");
        if (NoCompressHeadr) {
            xRequestObject.setRequestHeader("NoCompression", 'IRCA');
        }
    } catch (ex) {
    }
};
function getCFile(url, boolasync, returnContent, funcref) {
    return getFile(url, boolasync, returnContent, funcref, true);
};
function getFile(url, boolasync, returnContent, funcref, NoUniqueUrl) {
    try {
        if (checkOffLine()) { return }
        if (boolasync == null) { boolasync = true };
        NewExeObjx = getRequestObject();
        if (typeof (funcref) != 'undefined' && boolasync)
            NewExeObjx.onreadystatechange = function() {
                if (NewExeObjx.readyState == 4 && (NewExeObjx.status == 200)) {
                    if (typeof (funcref) != 'undefined') funcref(NewExeObjx.responseText); NewExeObjx = null;
                } else if (NewExeObjx.readyState == 4 && NewExeObjx.status == 403) { this.IRCAMAIN.absend(); return }
            }
        if (NoUniqueUrl) NewExeObjx.open("GET", url, boolasync);
        else NewExeObjx.open("GET", getUniqueUrl(url), boolasync);
        NewExeObjx.setRequestHeader('&param', 'IRCA');
        NewExeObjx.send(null);
        if (returnContent && !boolasync && typeof (funcref) == 'undefined') {
            if (NewExeObjx.status == 403) { this.absend(); return }
            if (NewExeObjx.status != 200) { return }
            var xx = NewExeObjx.responseText;
            NewExeObjx = null;
            return xx;
        };
    } catch (e) { };
};
IRCAMAINOBJ.prototype.getFile = getFile;
IRCAMAINOBJ.prototype.getCFile = getCFile;
function getsText(strHTML) {
    var onerrorfuncRef = onerror;
    onerror == function() { return true }; ;
    try {
        var tmpDivObj = document.createElement('DIV');
        tmpDivObj.innerHTML = strHTML.replace('&sect', '& sect');
        return tmpDivObj.innerText.replace('& sect', '&sect');
    } catch (r) {
        return '';
    } finally {
        onerror = onerrorfuncRef;
    }
}

function isTextHTML(strText) {
    if (!strText) { return false };
    try {
        return (strText.length != getsText(strText).length);
    } catch (r) { return false };
}

function isNativeFunction(funcRef) {
    return ((funcRef + '').indexOf('native') > 0);
}
function displayOfflineMessage() {
    var msgStr = 'Your browser seems to be in Offline Mode.' + jsCRLF +
        'Please change this [File-->Work OffLine] to continue working with the Application!';
    alert(msgStr);
};
function isClientOffLine() {
    try {
        return false; //return !navigator.onLine;       
    } catch (e) { return false };
};
function checkOffLine() {
    if (isClientOffLine()) { displayOfflineMessage(); return true };
    return false;
};
function getElementsByAttribute(docRNode, strAttributeName, strTagName, strAttributeValue) {
    if (!strTagName) { strTagName = null }; var arrElements = null;
    if (!docRNode) { docRNode = document };
    if (docRNode.all) {
        arrElements = (strTagName == null) ? docRNode.all : docRNode.getElementsByTagName(strTagName);
    } else {
        arrElements = docRNode.childNodes;
    }
    if (!strAttributeName && !strAttributeValue) { return arrElements };
    var arrReturnElements = new Array();
    var oAttributeValue = (typeof strAttributeValue != "undefined") ? new RegExp("(^|\\s)" + strAttributeValue + "(\\s|$)") : null;
    var oCurrent; var oAttribute; var i = 0;
    while (arrElements[i]) {
        oCurrent = arrElements[i];
        oAttribute = oCurrent.getAttribute(strAttributeName);
        if (typeof oAttribute == "string") {
            if (strAttributeValue == null) {
                arrReturnElements.push(oCurrent);
            } else {
                if (oAttributeValue && oAttributeValue.test(oAttribute)) {
                    arrReturnElements.push(oCurrent);
                }
            }
        }
        i++;
    }
    var zrr = []; zrr[0] = arrReturnElements;
    return zrr;
};
IRCAMAINOBJ.prototype.Logoutuser = function() { this.ExecuteFunc(myDefaultUrl, "IRCA", "LOGOUT", 'DATA', "POST", false, document, "", function() { }); };
IRCAMAINOBJ.prototype.ExecutePFunc = function(url, data, boolasync, returnContent) {
    if (checkOffLine()) { return }
    if (boolasync == null) { boolasync = true };
    var vauth = this.IRCAAuth;
    var NewExeObjx = getRequestObject();
    if (returnContent) {
        NewExeObjx.open("POST", url, boolasync);
    } else {
        url = getUniqueUrl(url);
        NewExeObjx.open("GET", url, boolasync);
    };
    NewExeObjx.setRequestHeader("IRCAAuth", vauth || '.');
    NewExeObjx.setRequestHeader("&param", 'XMLPOSTBACK');
    NewExeObjx.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

    NewExeObjx.send(data);
    if (returnContent) {
        if (NewExeObjx.status == 403) { this.absend(); return }
        if (NewExeObjx.status != 200) { return }
        return NewExeObjx.responseText;
    }
};
IRCAMAINOBJ.prototype.ExecuteFunc = function(url, Funcstr, params, data, type, boolasync, PDOC, isNav, callbackfunc, reqWind) {
    try {
        if (checkOffLine()) { return }
        var vauth = this.IRCAAuth;
        if (boolasync == null) { boolasync = true; } if (string.isEmpty(url)) url = myDefaultUrl;
        if (params == null) { params = "."; } if ((type == null) && (type != "GET") && (type != "HEAD") && (type != "POST")) { type = "GET"; }
        var xPoolr = getRequestObject();
        xPoolr.open(type, getUniqueUrl(url), boolasync);
        xPoolr.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
        xPoolr.setRequestHeader("IRCAAuth", vauth || '.');
        xPoolr.setRequestHeader("&FUNC", Funcstr);
        xPoolr.setRequestHeader("&param", params);
        var targetPage = '-'; try { targetPage = PDOC.body.TargetPage == 'self' ? (PDOC.body.ThisPage || '-') : '-'; } catch (e) { ; };
        xPoolr.setRequestHeader("&paramTargetPage", targetPage);
        xPoolr.onreadystatechange = new ExecuteFuncHandler(xPoolr, boolasync, PDOC, reqWind, callbackfunc);
        xPoolr.send(data);
    } catch (ex) { ; };
};
function ExecuteFuncHandler(xmlreqrslt, boolasync, PDOC, reqWind, callbackfunc) {
    this.x = function() {
        if (xmlreqrslt.readyState != 4) return;
        if (xmlreqrslt.status == 403) { this.absend(); return }
        try {
            if (typeof (callbackfunc) != "function") {
                var ircaObjectRef = PDOC.parentWindow.ircaObject;
                if (!ircaObjectRef) ircaObjectRef = reqWind.ircaObject;
                if (ircaObjectRef.WrapResponse) { ircaObjectRef.WrapResponse(xmlreqrslt, PDOC, reqWind, boolasync); }
            } else {
                if (callbackfunc) { callbackfunc(xmlreqrslt, PDOC, reqWind); }
            };
        } catch (e) { ; };
        xmlreqrslt = null; PDOC = null;
    };
    return this.x;
};
IRCAMAINOBJ.prototype.drawDialog = function(pageSrcA, isURL, isScrollable, title, dialogArgs, dialogHeight, dialogWidth, dialogTopP, dialogLeftP, resizable) {
    //do not change above params : see private_initDialog
    //if already ther is a dialog shown, hust alert and return
    if (WPDiv1_ifrm && WPDiv1_ifrm.document) {
        if (isURL) {
            __Alert(getsText(dialogArgs[1]) || '');
        } else {
            __Alert(getsText(pageSrcA));
        }
        return;
    }
    var pageSrc = '';
    this.windLock(document);
    if (isURL) { pageSrc = pageSrcA };
    if (resizable == null) { resizable = false };
    if (!dialogLeftP) { dialogLeftP = 200 }; if (!dialogTopP) { dialogTopP = 150 };
    dialogTopP += document.body.scrollTop;
    /**/RcatWind = createMiniWinLayer(['WPDiv1_ifrm', pageSrc, dialogWidth, dialogHeight, isScrollable],
    title, dialogLeftP, dialogTopP, 0, '#666699', '#ffffff', '', '', '', 'APPRES.ashx/1664805296/cross.gif', '', 'APPRES.ashx/1664805296/handle.gif',
    1, false, '', false, resizable, 2222);
    if (!isURL) { this.write2Dialog(pageSrcA); };
    this.private_initDialog(arguments);
    return WPDiv1_ifrm;
}
IRCAMAINOBJ.prototype.private_initDialog = function(argumentsA) {
    WPDiv1_ifrm.dialogArguments = argumentsA[4]//dialogArgs;
    WPDiv1_ifrm.opener = argumentsA[4];
    WPDiv1_ifrm.baseArguments = argumentsA;
    if (ChildWB) WPDiv1_ifrm.opener = ChildWB; //need to change in future
    WPDiv1_ifrm.selfID = RcatWind.id;
    WPDiv1_ifrm.close = function() { IRCAMAIN.closeDialog(WPDiv1_ifrm.selfID); };
    WPDiv1_ifrm.resizeDialog = resizeDialog;
    if (!argumentsA[3]) { RcatWind.ChangeTitle(WPDiv1_ifrm.document.title) };
    this.regWindow('WPDiv' + RcatWind.id, WPDiv1_ifrm); //register window
    WPDiv1_ifrm.focus();
}
IRCAMAINOBJ.prototype.write2Dialog = function(ContentX, isRewrite) {
    if (!WPDiv1_ifrm) { return };
    var oldArguments = null;
    if (isRewrite) { oldArguments = WPDiv1_ifrm.baseArguments };
    var newdoc = WPDiv1_ifrm.document.open('text/html', 'replace');
    WPDiv1_ifrm.execScript('ircaObject=parent.IRCAMAIN.getNewInstance(window)');
    newdoc.write(ContentX);
    //    newdoc.namespaces.add('IRCAAuth',document.namespaces('IRCAAuth').urn);
    //    newdoc.namespaces.add('IRCAWind',document.namespaces('IRCAWind').urn);
    //    newdoc.namespaces.add('IRCADTF',document.namespaces('IRCADTF').urn);
    newdoc.close();
    ContentX = '';
    if (oldArguments) { this.private_initDialog(oldArguments) };
}

function resizeDialog(ywidth, zheight) {
    var id = selfID || '1';
    resizeWin('MWJminiwinMAX' + id, 'MWJminiwinMIN' + id, ywidth, zheight, 'WPDiv1_ifrm');
    return false;
}
IRCAMAINOBJ.prototype.getArrIndexbyName = function(strname, arr) {
    for (var find = 0; find < arr.length; find++) {
        if (arr[find] == strname) { return find; }
    }
    return -1;
}
IRCAMAINOBJ.prototype.hasTagName = function(obj) { return (obj.tagName + "" != "undefined") ? true : false; }
IRCAMAINOBJ.prototype.setFormLock = function(xbool, parentObj) {
    if (!parentObj) { return };
    try {
        var collectCount = 0;
        var CollElements = this.getCollectableElements(parentObj);
        while (CollElements[collectCount]) {
            this.LoopThruNLock(CollElements[collectCount], xbool);
            collectCount++;
        };
    } catch (e) { return false };
    if (parentObj.parentWindow) {
        this.PgLockMode = xbool;
        this.readOnly = xbool;
        if (parentObj.parentWindow.afterLockChange) { parentObj.parentWindow.afterLockChange(xbool); }
    } else if (parentObj.document && parentObj.document.parentWindow.afterLockChange) {
        parentObj.document.parentWindow.afterLockChange(xbool);
    }
    return true;
};
IRCAMAINOBJ.prototype.LoopThruNLock = function(pobj, setbool) {
    var typtag = "";
    if (pobj.length == 0) { return };
    var i = 0;
    while (pobj[i]) {
        if (this.hasTagName(pobj[i])) {
            typtag = pobj[i].tagName
        } else {
            typtag = pobj[i].type
        }
        if ((pobj[i].id.indexOf("Suggest") >= 0) && (typtag == 'DIV')) // This is to disable the suggest control in edit mode
        {
            if (pobj[i].document.parentWindow.scDisable) { pobj[i].document.parentWindow.scDisable(pobj[i].id, setbool); };
            i++; typtag = "";
            continue;
        }
        switch (typtag) {
            case "INPUT": case "TEXTAREA":
                if (!pobj[i].id || pobj[i].type == "hidden" || pobj[i].getAttribute("NOFORMLOCK") == '') { break }
                if (pobj[i].type == "button" || pobj[i].type == "checkbox" || pobj[i].type == "radio") {
                    pobj[i].disabled = setbool;
                    break;
                } else {
                    if (pobj[i].id.indexOf("dt") == 0) {
                        pobj[i].disabled = setbool;
                    } else {
                        pobj[i].readOnly = setbool;
                    }
                }
                break;
            case "combo": case "select-one": case "SELECT":
                if (pobj[i].getAttribute("NOFORMLOCK") == '') { break }
                pobj[i].disabled = setbool;
                break;
        }
        i++; typtag = "";
    }
};
//Application Shutdown 
IRCAMAINOBJ.prototype.absend = function(forstr) {//abnormal session end
    __Alert("Sorry! Your Session was ended by the Server. \n\n Please Login again to continue."); this.AppDispose('open(".?ru");'); return;
};
IRCAMAINOBJ.prototype.AppDispose = function(strRunBeforeClose) {
    // first ensure the modal dialogs are closed
    //ensure non modals are closed
    //finally the main window shld be closed
    this.CleanExit = true;
    this.unRegWindows();
    try {
        if (strRunBeforeClose) { this.execScript(strRunBeforeClose); }
    } catch (e) { }
    this.close();
};
IRCAMAINOBJ.prototype.AppLock = function(boolUnLock, id, zindx) {
    if (boolUnLock) {
        //if(this.dhtmlwindow && this.dhtmlwindow.getLength()<2)
        this.windUnLock(id);
    } else {
        this.windLock(id, zindx);
    }
};
//var gu = new ActiveXObject("MSXML2.DomDocument");gu.lselectSingleNode().text
IRCAMAINOBJ.prototype.getNewdomXml = function(id, boolDom) {
    var IXMLDOMNew = new this.domXml(id);
    if (boolDom) {
        try {
            if (isIEX) {
                IXMLDOMNew.domObj = new ActiveXObject("MSXML2.DomDocument");
            }
        } catch (err) {
            IXMLDOMNew.domObj = document.implementation.createDocument("", "", null);
        }
    }
    return IXMLDOMNew;
};
IRCAMAINOBJ.prototype.domXml = IXMLDOM; // interface to XMLDOM
function IXMLDOM(id) {
    this.domObj = null;
    this.id = id + "";
    this.root = "";
};
IXMLDOM.prototype.getXMlNodeValue = function(path, multiple, prop, retobj) {
    try {
        if (!multiple) {

            if (!this.domObj && !this.domObj.selectSingleNode(this.root + path)) { if (!retobj) { return "" } else { return null }; };
            if (!retobj) {
                return this.domObj.selectSingleNode(this.root + path).text;
            } else {
                return this.domObj.selectSingleNode(this.root + path);
            };

        } else {

            if (!this.domObj && this.domObj.selectNodes(this.root + path).length < 1) { if (!retobj) { return "" } else { return null }; };
            if (!prop) {
                if (!retobj) {
                    //return eval("IRCAMAIN.domXml.domObj.selectNodes('"+this.root + path+"').text" );
                    return this.domObj.selectNodes(this.root + path).text;
                } else {
                    //return eval("IRCAMAIN.domXml.domObj.selectNodes('"+this.root + path+"')" );
                    return this.domObj.selectNodes(this.root + path);
                }
            } else {
                //return eval("IRCAMAIN.domXml.domObj.selectNodes('"+this.root + path+"')." + prop );
                return this.domObj.selectNodes(this.root + path).item(0).selectSingleNode(prop).text;

            };
        }
    } catch (e) { return "" }
};
IXMLDOM.prototype.dispose = function() { this.domObj = null; this.id = ""; this.root = "" };
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
IRCAMAINOBJ.prototype.tryLoadDomXml = function(xmlDomObj, path) {
    var Loaded = false;
    try {
        Loaded = xmlDomObj.loadXML(getFile(path, false, true));
        //   	    if (!Loaded){//Pag,boolasync,filetyp,retFunc,data2send,IsOPB,reqWind,NoCompressHeadr
        //		    Loaded=xmlDomObj.loadXML(ExecutePFunc(path,false,2,null,null,null,null,true));
        //	    }
    } catch (e) { };
    return Loaded;
};
//XML Serialization
IRCAMAINOBJ.prototype.WrapRequest = function(CntrolId, EvntType, PDOC, boolasync, pgtype, callbackfunc, paramx, reqWind) {
    var CanSend = true; var tmpnode;
    if (!PDOC) { PDOC = document }; if (!reqWind) { reqWind = window };
    this.AppLock(); this.ircaObject.setObjectProp('pb2', 'style', 'display', '');
    if (boolasync == null) { boolasync = true };
    var xmldom = new ActiveXObject("MSXML2.DomDocument");
    xmldom.async = false; var boolloaded = false;
    if (!this.ReqXMLstr) {
        boolloaded = this.tryLoadDomXml(xmldom, 'APPRES.ashx/1664805296/reqwraperx')
    } else {
        boolloaded = xmldom.loadXML(this.ReqXMLstr);
    }
    if (!boolloaded) { PDOC.parentWindow.alert('Failed to get XML from Server'); this.AppLock(true); IRCA.setObjectProp('pb2', 'style', 'display', 'none'); return; };
    if (!this.ReqXMLstr) { this.ReqXMLstr = xmldom.xml };
    if (!xmlreqtmpl) xmlreqtmpl = new ActiveXObject("MSXML2.DomDocument");
    if (xmlreqtmpl.xml == "") {
        xmlreqtmpl.async = false;
        xmlreqtmpl.loadXML(this.ReqXMLstr);
    }
    xmldom.selectSingleNode("//Page/@Name").text = this.ThisPage(PDOC);
    xmldom.selectSingleNode("//Page/@ToPage").text = this.constructToPage(CntrolId);
    xmldom.selectSingleNode("//Page/@ReqType").text = pgtype || "self";
    xmldom.selectSingleNode("//Page/@CurMode").text = this.CurMode || "";
    xmldom.selectSingleNode("//Page/@TargetMode").text = this.TargetMode || "";
    xmldom.selectSingleNode("//Page/@isPageCanceled").text = PDOC.parentWindow.ircaObject == null ? "false" : PDOC.parentWindow.ircaObject.isPageCanceled + '';
    xmldom.selectSingleNode("//Page/@ParentKeyValue").text = this.parentKeyValue;
    xmldom.selectSingleNode("//Page/@KeyValue").text = this.keyValue;
    xmldom.selectSingleNode("//Control/@Id").text = CntrolId;
    xmldom.selectSingleNode("//Control/@Type").text = PDOC.getElementById(CntrolId) != null ? PDOC.getElementById(CntrolId).getAttribute("type") + "" : "";
    xmldom.selectSingleNode("//Control/@Event").text = EvntType;

    if (pgtype == 'popup_self' || pgtype == 'self') { pgtype = null };
    var boolInciFlashRep = false;
    if (PDOC.parentWindow.ircaObject && PDOC.parentWindow.ircaObject.id.indexOf('flashreport.aspx') > 0) { boolInciFlashRep = true };
    if (this.ircaObject.getReadLock() && !boolInciFlashRep) { CanSend = false; };
    if (CanSend) { // if readonly no need to collect/send data from client to server,
        // datacontrol section PDOC.body
        xmldom.loadXML(this.CollectData(xmldom.xml, PDOC));
    }
    var DummyNodes = xmldom.selectNodes("//Data/DataControl[@Id='']");
    var DummyNodescnt = DummyNodes.length;
    if (DummyNodescnt > 0) {
        //var dncnt=0;
        for (var dncnt = 0; dncnt < DummyNodescnt; dncnt++) {
            xmldom.getElementsByTagName("Data").item(0).removeChild(DummyNodes.item(dncnt));
        }
    }
    this.ExecuteFunc(myDefaultUrl, "IRCA", paramx || "null", xmldom.xml, "POST", boolasync, PDOC, pgtype != null, callbackfunc, reqWind);
    xmldom = null;
    return true;
};
IRCAMAINOBJ.prototype.constructToPage = function(cntrlID) {
    cntrlID = cntrlID.trim();
    if (cntrlID && cntrlID.indexOf('*') < 0) { return cntrlID };
    if (this.keyValue && this.keyValue.indexOf(cntrlID) > -1) {
        return cntrlID + '~' + this.parentKeyValue;
    } else {
        return cntrlID + '~' + this.keyValue;
    }
};

///////////////////Data Collection
IRCAMAINOBJ.prototype.CollectData = function(xmldomDC, PDOC) {
    if (!XmlDC) XmlDC = new ActiveXObject("MSXML2.DomDocument");
    XmlDC.loadXML(xmldomDC);
    ncnt = 0; var collectCount = 0;
    var CollElements = this.getCollectableElements(PDOC);
    while (CollElements[collectCount]) {
        this.LoopThru(CollElements[collectCount]);
        collectCount++;
    };
    ncnt = 0;
    var retv = XmlDC.xml;
    XmlDC = null;
    return retv;
};
IRCAMAINOBJ.prototype.getCollectableElements = function(PDOC) {
    var CollectableElements = [];
    CollectableElements = CollectableElements.concat(getElementsByAttribute(PDOC, '', 'INPUT'));
    CollectableElements = CollectableElements.concat(getElementsByAttribute(PDOC, '', 'TEXTAREA'));
    CollectableElements = CollectableElements.concat(getElementsByAttribute(PDOC, '', 'DIV', 'suggest'));
    CollectableElements = CollectableElements.concat(getElementsByAttribute(PDOC, '', 'SELECT'));
    //CollectableElements=CollectableElements.concat(getElementsByAttribute(PDOC,'IRCAType','IMG'));
    return CollectableElements;
};
IRCAMAINOBJ.prototype.LoopThru = function(obj) {
    if (obj.length == 0) { return };
    var i = 0;
    while (obj[i]) {
        this.addxmldatacntrl(obj[i]);
        i++;
    }
};

IRCAMAINOBJ.prototype.hasTagName = function(obj) {
    return (obj.tagName + "" != "undefined") ? true : false;
};
IRCAMAINOBJ.prototype.addxmldatacntrl = function(objx) {
    var tmptyp = "";
    var cname = "value";
    if (!string.isEmpty(objx.getAttribute("IRCAType"))) {
        tmptyp = objx.getAttribute("IRCAType");
    } else {
        if (objx.type != "") {
            tmptyp = objx.type;
        } else {
            tmptyp = objx.tagName;
        }
    }
    if (objx.id == "") { return; }
    if (objx.id == "__VIEWSTATE" || objx.name == "__VIEWSTATE") return;
    if (objx.id == "ICOMP" || objx.name == "ICOMP") return;
    if (ncnt != 0) {
        //clone elements to fill data
        XmlDC.getElementsByTagName("Data").item(0).appendChild(xmlreqtmpl.getElementsByTagName("Data").item(0).selectSingleNode("DataControl").cloneNode(true));
    }
    XmlDC.getElementsByTagName("DataControl").item(ncnt).attributes.getNamedItem("Id").text = objx.id;
    XmlDC.getElementsByTagName("DataControl").item(ncnt).attributes.getNamedItem("Name").text = objx.name;
    XmlDC.getElementsByTagName("DataControl").item(ncnt).attributes.getNamedItem("Type").text = tmptyp;

    var valu = "";
    switch (tmptyp) {
        case "tree":
            break;

        case "grid":
            break;

        case "SELECT":
            if (objx.selectedIndex >= 0) {
                valu = objx.options(objx.selectedIndex).value;
            }
            break;

        case "checkbox": case "radio":
            valu = objx.checked ? "true" : "false";
            break;

        case "label":
            valu = objx.innerText;
            break;

        default:
            valu = objx.value;
            break;
    }

    XmlDC.getElementsByTagName("Value").item(ncnt).selectNodes("Item").item(0).attributes.getNamedItem("Name").text = cname;
    XmlDC.getElementsByTagName("Value").item(ncnt).selectNodes("Item").item(0).attributes.getNamedItem("Value").text = valu;
    ncnt++
};

//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^				
// XML DeSerialization
IRCAMAINOBJ.prototype.WrapResponse = function(xmlobj, PDOC, reqWind, async) {
    if (async)
        setTimeout(new WrapResponseX(this, xmlobj, PDOC, reqWind), 100);
    else
        return (new WrapResponseX(this, xmlobj, PDOC, reqWind)());
};
function WrapResponseX(thisObj, xmlobj, PDOC, reqWind) {
    this.x = function() {
        if (!PDOC) { PDOC = document }
        try {
            var xmlresdom = new ActiveXObject("MSXML2.DomDocument");
            if (!xmlresdom.loadXML(xmlobj.responseXML.text + "")) return;
            var pgStatus = ""; var hasError = false;
            try { pgStatus = xmlobj.getResponseHeader("REQSTATUS"); } catch (ex) { pgStatus = ""; }
            if (xmlobj.status != 200) {
                __Alert("Status is " + xmlobj.status);
                alert(xmlobj.responseText);
                return false;
            };
            switch (pgStatus) {
                case "0": case "OK":
                    var tmptargetPage = ""; var tmptPagetype = "";
                    tmptargetPage = xmlresdom.selectSingleNode("//Page/@Uri").text;
                    tmptPagetype = xmlresdom.selectSingleNode("//Page/@Type").text;
                    thisObj.parentKeyValue = xmlresdom.selectSingleNode("//Page/@ParentKeyValue").text;
                    thisObj.keyValue = xmlresdom.selectSingleNode("//Page/@KeyValue").text;
                    if (tmptPagetype == "next" || tmptPagetype == "popup") { thisObj.FNWrapResponse(xmlobj, PDOC, reqWind); return };
                    if (tmptPagetype == "reportresult") {
                        if (!PDOC.parentWindow.handleResultshtml) { return }; PDOC.parentWindow.handleResultshtml(xmlresdom.selectSingleNode("IRCA_WEB_RESPONSE/Page/PageHtml").text);
                    }
                    try {
                        if (tmptPagetype != "reportresult") procezres();
                    } catch (e) { };
                    //execute scripts if one
                    try {
                        if (xmlresdom.selectSingleNode("//ScriptExecute/Javascript").text != "") {
                            PDOC.parentWindow.execScript(xmlresdom.selectSingleNode("//ScriptExecute/Javascript").text, "javascript");
                        }
                    } catch (ex) { }
                    break;

                case "ERROR": case "1": case "":
                    hasError = true;
                    var srvmsg = xmlresdom.selectSingleNode("//Message").text;
                    thisObj.AppLock(true);
                    if (trim(srvmsg) != "") {
                        alert(srvmsg); //displayMessage(srvmsg);
                    } else {
                        alert("Unkown Error Occured"); //displayMessage("Unkown Error Occured");
                    }
                    break;
            };
        } finally {
            thisObj.ircaObject.setObjectProp('pb2', 'style', 'display', 'none');
            if (!hasError) { thisObj.AppLock(true); return true; } else { return false; };
        };

        function procezres() {
            var objxml = xmlresdom;
            if (objxml.selectSingleNode("//Page/@Uri").text) {
                var tmptargetPage = "", tmptPagetype = "";
                tmptargetPage = objxml.selectSingleNode("//Page/@Uri").text;
                tmptPagetype = objxml.selectSingleNode("//Page/@Type").text;
                switch (tmptPagetype) {
                    case "next":
                        handlepagenav(tmptargetPage);
                        return;
                        break;

                    case "":
                        break;
                }
            }

            var x = 0; var xcnt = 0;
            for (xcnt = 0; xcnt < objxml.selectSingleNode("//Page/Properties").selectNodes("Property").length; xcnt++) {
                //Set properties for the controls

            }
            ////////controllist
            var i = 0, j = 0, k = 0;
            for (i = 0; i < objxml.selectSingleNode("//ControlList").selectNodes("Control").length; i++) {
                var cntrlname = "", cntrlpgname = "", cntrltype = "";
                cntrlname = objxml.selectSingleNode("//ControlList").selectNodes("Control").item(i).attributes.getNamedItem("Name").text;
                cntrlpgname = objxml.selectSingleNode("//ControlList").selectNodes("Control").item(i).attributes.getNamedItem("PageName").text;
                cntrltype = objxml.selectSingleNode("//ControlList").selectNodes("Control").item(i).attributes.getNamedItem("Type").text;

                processItemres(cntrlname, cntrlpgname, objxml.selectSingleNode("//ControlList").selectNodes("Control").item(i).selectSingleNode("Items").xml);

                //properties
                for (k = 0; k < objxml.selectSingleNode("//ControlList").selectNodes("Control").item(i).selectSingleNode("Properties").selectNodes("Property").length; k++) {
                    var itmNode = "", itmprop = "", p1 = "", itmexec = "";
                    itmNode = objxml.getElementsByTagName("ControlList").item(0).selectNodes("Control").item(i).selectSingleNode("Properties").selectNodes("Property").item(k).attributes.getNamedItem("Node").text;
                    itmprop = objxml.getElementsByTagName("ControlList").item(0).selectNodes("Control").item(i).selectSingleNode("Properties").selectNodes("Property").item(k).attributes.getNamedItem("Name").text;
                    p1 = objxml.getElementsByTagName("ControlList").item(0).selectNodes("Control").item(i).selectSingleNode("Properties").selectNodes("Property").item(k).attributes.getNamedItem("Value").text;

                    if (cntrlname != "") {
                        switch (itmprop) {
                            case "disabled": case "title":
                                //				            itmexec="PDOC.getElementById('"+ cntrlname +"')."+itmprop +" = " + p1 + thisObj.ircaObject.SplitStrB
                                itmexec = p1 + thisObj.ircaObject.SplitStrB;
                                //				            PDOC.parentWindow.execScript(itmexec,"javascript");  
                                var g = PDOC.getElementById(cntrlname);
                                if (g) g.setAttribute(itmprop, itmexec);
                                break;

                            case "Select":
                                if (itmNode == "") { break; }
                                PDOC.parentWindow.getNodebyID(objCurTree[cntrlname], itmNode).focus();
                                break;

                            case "":
                                break;
                            default:
                                //				            itmexec="PDOC.getElementById('"+ cntrlname +"').style."+itmprop +" = " + p1 + thisObj.ircaObject.SplitStrB
                                itmexec = p1 + thisObj.ircaObject.SplitStrB;
                                //				            PDOC.parentWindow.execScript(itmexec,"javascript");  
                                var g = PDOC.getElementById(cntrlname);
                                if (g) g.style.setAttribute(itmprop, itmexec);
                                break;
                        }
                    }
                }
            }
            //
        };
        function processItemres(cntrlname, cntrlpgname, Itemxml) {
            var xmlItem = new ActiveXObject("MSXML2.DomDocument");
            xmlItem.loadXML(Itemxml);
            var cntrltype = ""; var itmexec = "", itmmode = "";
            if (cntrlname == "") { return }
            cntrlname = cntrlname.split('_')[0];
            //guru
            if (cntrlname.indexOf('iwt') == 0) {
                cntrltype = 'tree';
            } else if (cntrlname.indexOf('uwg') == 0) {
                cntrltype = 'grid';
            } else {
                var testCntrlObj = PDOC.getElementById(cntrlname);
                if (!testCntrlObj) { return };
                if (!string.isEmpty(testCntrlObj.getAttribute("IRCAType"))) {
                    cntrltype = testCntrlObj.getAttribute("IRCAType");
                } else {
                    if (!string.isEmpty(testCntrlObj.type)) {
                        cntrltype = testCntrlObj.type;
                    } else {
                        cntrltype = testCntrlObj.tagName;
                    }
                }
            }

            if (cntrlname == "") { return; }
            switch (cntrltype) {
                case "tree":
                    var itmparentid = ""; var itmid = ""; var itmname = ""; var itmXtraInfo = ""; var itmKey = ""; var itmType = "";
                    var nodeStyle = ''; var ShowToolTip = '';
                    try {
                        //itmKey=xmlItem.selectSingleNode('//Item[@Name="NodeKey"]/@Value').text;
                        itmid = xmlItem.selectSingleNode('//Item[@Name="NodeId"]/@Value').text;
                        itmname = xmlItem.selectSingleNode('//Item[@Name="NodName"]/@Value').text;
                        itmmode = xmlItem.selectSingleNode('//Item[@Name="NodName"]/@Mode').text;
                        itmparentid = xmlItem.selectSingleNode('//Item[@Name="ParentNodeId"]/@Value').text;
                        if (xmlItem.selectSingleNode('//Item[@Name="Nodetype"]/@Value')) {
                            itmType = xmlItem.selectSingleNode('//Item[@Name="Nodetype"]/@Value').text;
                        }
                        if (xmlItem.selectSingleNode('//Item[@Name="NodeTag"]/@Value')) {
                            itmXtraInfo = xmlItem.selectSingleNode('//Item[@Name="NodeTag"]/@Value').text;
                        }
                        nodeStyle = xmlItem.selectSingleNode('//Item[@Name="NodeStyle"]/@Value').text;
                        ShowToolTip = xmlItem.selectSingleNode('//Item[@Name="ShowToolTip"]/@Value').text;
                        //itmvalu=xmlItem.selectSingleNode('//Item[@Name="NodeTag"]/@Value').text;				
                    } catch (ex) { }

                    switch (itmmode) {
                        case "add":
                            PDOC.parentWindow.addMode = true;
                            PDOC.parentWindow.addiwtNode(cntrlname, itmname, itmid, itmXtraInfo, itmparentid, nodeStyle, ShowToolTip);
                            break;

                        case "edit":
                            var tree = ChildWB.eval('o' + cntrlname);
                            var node = tree.getNodeById(itmid);
                            if (node) {
                                node.edit(itmname, itmXtraInfo, nodeStyle, ShowToolTip);
                            }
                            break;

                        case "delete":
                            PDOC.parentWindow.deliwtNode(cntrlname, itmid, true)
                            break;

                    }
                    if (PDOC.parentWindow.onCancel) { PDOC.parentWindow.onCancel(); if (PDOC.parentWindow.addMode) { PDOC.parentWindow.addMode = false; } }
                    break;

                case "grid":
                    var gridID = "", i;
                    var gridValue = new String();
                    var newrow = new Array();
                    var str0 = "<img src='APPRES.ashx/1664805296/remove.gif'>"
                    for (i = 0; i < xmlItem.getElementsByTagName("Item").length; i++) {
                        itmmode = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Mode").text;
                        switch (itmmode) {
                            case "add":
                                gridID = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Name").text;
                                gridValue = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Value").text;
                                newrow = gridValue.split(thisObj.splitStrA);
                                newrow[0] = str0
                                cntrlname = cntrlname.replace('_div', '');
                                PDOC.parentWindow.addRow(cntrlname, newrow, 0);
                                break;

                            case "edit":
                                gridID = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Name").text;
                                gridValue = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Value").text;
                                newrow = gridValue.split(thisObj.splitStrA);
                                if (newrow[0] == "") {
                                    newrow[0] = str0;
                                }
                                cntrlname = cntrlname.replace('_div', '');
                                var boolSeqEvnts = PDOC.parentWindow.ircaObject.ThisPage().indexOf("seqevents") < 0 ? false : true;
                                PDOC.parentWindow.editRow(cntrlname, newrow, boolSeqEvnts);
                                break;

                            case "delete":
                                gridID = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Name").text;
                                gridValue = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Value").text;
                                newrow = gridValue.split(thisObj.splitStrA);
                                if (newrow[0] == "") {
                                    newrow[0] = str0;
                                }
                                cntrlname = cntrlname.replace('_div', '');
                                var rid = PDOC.parentWindow.getRowNo(cntrlname, gridID, 1);
                                PDOC.parentWindow.removeRow(cntrlname, rid);
                                break;
                        }

                    }
                    if (PDOC.parentWindow.onCancel) { PDOC.parentWindow.onCancel(); if (PDOC.parentWindow.addMode) { PDOC.parentWindow.addMode = false; } }
                    break;

                case "list": case "combo": case "select-one":
                    for (i = 0; i < xmlItem.getElementsByTagName("Item").length; i++) {
                        itmmode = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Mode").text;
                        var lstName = "", lstValu = "";
                        switch (itmmode) {

                            case "add":
                                lstName = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Name").text;
                                lstValu = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Value").text;
                                PDOC.parentWindow.Add2Lstbx(cntrlname, lstName, lstValu, PDOC);
                                break;

                            case "edit":
                                lstName = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Name").text;
                                lstValu = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Value").text;
                                PDOC.parentWindow.Edit2Lstbx(cntrlname, lstName, lstValu, PDOC);
                                break;

                            case "delete":
                                lstName = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Name").text;
                                lstValu = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Value").text;
                                PDOC.parentWindow.Remove2Lstbx(cntrlname, lstValu, PDOC);
                                break;

                            case "clearandadd":
                                //clear
                                PDOC.parentWindow.ClearLstbx(cntrlname, PDOC);
                                //add
                                //var i=0;
                                //while(xmlItem.getElementsByTagName("Item") && xmlItem.getElementsByTagName("Item").item(i)){
                                lstName = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Name").text;
                                lstValu = xmlItem.getElementsByTagName("Item").item(i).attributes.getNamedItem("Value").text;
                                if (!lstName || !lstValu) { continue };
                                PDOC.parentWindow.Add2Lstbx(cntrlname, lstName, lstValu, PDOC);
                                //  i++;
                                //}
                                break;
                        }
                    }
                    if (PDOC.parentWindow.onCancel) { PDOC.parentWindow.onCancel(); if (PDOC.parentWindow.addMode) { PDOC.parentWindow.addMode = false; } }
                    break;

                case "hidden": case "text": default:
                    try {
                        var xName = xmlItem.selectSingleNode('//Item/@Name').text;
                        var xValu = xmlItem.selectSingleNode('//Item/@Value').text;
                        PDOC.parentWindow.tempX5487Value = xValu;
                        PDOC.parentWindow.execScript('document.getElementById(\'' + cntrlname + '\').' + xName + '= tempX5487Value');
                        PDOC.parentWindow.tempX5487Value = null;
                    } catch (eee) { ; }
                    break;

                //break;                
            }
        };
        thisObj = null; xmlobj = null; PDOC = null; reqWind = null;
    };
    return this.x;
};

IRCAMAINOBJ.prototype.md5HashAlg = function() {
    var hexcase = 0; var b64pad = ""; var chrsz = 8;
    this.hex_md5 = function(s) { return binl2hex(core_md5(str2binl(s), s.length * chrsz)); }
    this.b64_md5 = function(s) { return binl2b64(core_md5(str2binl(s), s.length * chrsz)); }
    this.str_md5 = function(s) { return binl2str(core_md5(str2binl(s), s.length * chrsz)); }
    this.hex_hmac_md5 = function(key, data) { return binl2hex(core_hmac_md5(key, data)); }
    this.b64_hmac_md5 = function(key, data) { return binl2b64(core_hmac_md5(key, data)); }
    this.str_hmac_md5 = function(key, data) { return binl2str(core_hmac_md5(key, data)); }
    function md5_vm_test()
    { return hex_md5("abc") == "900150983cd24fb0d6963f7d28e17f72"; }
    function core_md5(x, len) {
        x[len >> 5] |= 0x80 << ((len) % 32); x[(((len + 64) >>> 9) << 4) + 14] = len; var a = 1732584193; var b = -271733879; var c = -1732584194; var d = 271733878; for (var i = 0; i < x.length; i += 16)
        { var olda = a; var oldb = b; var oldc = c; var oldd = d; a = md5_ff(a, b, c, d, x[i + 0], 7, -680876936); d = md5_ff(d, a, b, c, x[i + 1], 12, -389564586); c = md5_ff(c, d, a, b, x[i + 2], 17, 606105819); b = md5_ff(b, c, d, a, x[i + 3], 22, -1044525330); a = md5_ff(a, b, c, d, x[i + 4], 7, -176418897); d = md5_ff(d, a, b, c, x[i + 5], 12, 1200080426); c = md5_ff(c, d, a, b, x[i + 6], 17, -1473231341); b = md5_ff(b, c, d, a, x[i + 7], 22, -45705983); a = md5_ff(a, b, c, d, x[i + 8], 7, 1770035416); d = md5_ff(d, a, b, c, x[i + 9], 12, -1958414417); c = md5_ff(c, d, a, b, x[i + 10], 17, -42063); b = md5_ff(b, c, d, a, x[i + 11], 22, -1990404162); a = md5_ff(a, b, c, d, x[i + 12], 7, 1804603682); d = md5_ff(d, a, b, c, x[i + 13], 12, -40341101); c = md5_ff(c, d, a, b, x[i + 14], 17, -1502002290); b = md5_ff(b, c, d, a, x[i + 15], 22, 1236535329); a = md5_gg(a, b, c, d, x[i + 1], 5, -165796510); d = md5_gg(d, a, b, c, x[i + 6], 9, -1069501632); c = md5_gg(c, d, a, b, x[i + 11], 14, 643717713); b = md5_gg(b, c, d, a, x[i + 0], 20, -373897302); a = md5_gg(a, b, c, d, x[i + 5], 5, -701558691); d = md5_gg(d, a, b, c, x[i + 10], 9, 38016083); c = md5_gg(c, d, a, b, x[i + 15], 14, -660478335); b = md5_gg(b, c, d, a, x[i + 4], 20, -405537848); a = md5_gg(a, b, c, d, x[i + 9], 5, 568446438); d = md5_gg(d, a, b, c, x[i + 14], 9, -1019803690); c = md5_gg(c, d, a, b, x[i + 3], 14, -187363961); b = md5_gg(b, c, d, a, x[i + 8], 20, 1163531501); a = md5_gg(a, b, c, d, x[i + 13], 5, -1444681467); d = md5_gg(d, a, b, c, x[i + 2], 9, -51403784); c = md5_gg(c, d, a, b, x[i + 7], 14, 1735328473); b = md5_gg(b, c, d, a, x[i + 12], 20, -1926607734); a = md5_hh(a, b, c, d, x[i + 5], 4, -378558); d = md5_hh(d, a, b, c, x[i + 8], 11, -2022574463); c = md5_hh(c, d, a, b, x[i + 11], 16, 1839030562); b = md5_hh(b, c, d, a, x[i + 14], 23, -35309556); a = md5_hh(a, b, c, d, x[i + 1], 4, -1530992060); d = md5_hh(d, a, b, c, x[i + 4], 11, 1272893353); c = md5_hh(c, d, a, b, x[i + 7], 16, -155497632); b = md5_hh(b, c, d, a, x[i + 10], 23, -1094730640); a = md5_hh(a, b, c, d, x[i + 13], 4, 681279174); d = md5_hh(d, a, b, c, x[i + 0], 11, -358537222); c = md5_hh(c, d, a, b, x[i + 3], 16, -722521979); b = md5_hh(b, c, d, a, x[i + 6], 23, 76029189); a = md5_hh(a, b, c, d, x[i + 9], 4, -640364487); d = md5_hh(d, a, b, c, x[i + 12], 11, -421815835); c = md5_hh(c, d, a, b, x[i + 15], 16, 530742520); b = md5_hh(b, c, d, a, x[i + 2], 23, -995338651); a = md5_ii(a, b, c, d, x[i + 0], 6, -198630844); d = md5_ii(d, a, b, c, x[i + 7], 10, 1126891415); c = md5_ii(c, d, a, b, x[i + 14], 15, -1416354905); b = md5_ii(b, c, d, a, x[i + 5], 21, -57434055); a = md5_ii(a, b, c, d, x[i + 12], 6, 1700485571); d = md5_ii(d, a, b, c, x[i + 3], 10, -1894986606); c = md5_ii(c, d, a, b, x[i + 10], 15, -1051523); b = md5_ii(b, c, d, a, x[i + 1], 21, -2054922799); a = md5_ii(a, b, c, d, x[i + 8], 6, 1873313359); d = md5_ii(d, a, b, c, x[i + 15], 10, -30611744); c = md5_ii(c, d, a, b, x[i + 6], 15, -1560198380); b = md5_ii(b, c, d, a, x[i + 13], 21, 1309151649); a = md5_ii(a, b, c, d, x[i + 4], 6, -145523070); d = md5_ii(d, a, b, c, x[i + 11], 10, -1120210379); c = md5_ii(c, d, a, b, x[i + 2], 15, 718787259); b = md5_ii(b, c, d, a, x[i + 9], 21, -343485551); a = safe_add(a, olda); b = safe_add(b, oldb); c = safe_add(c, oldc); d = safe_add(d, oldd); }
        return Array(a, b, c, d);
    }
    function md5_cmn(q, a, b, x, s, t)
    { return safe_add(bit_rol(safe_add(safe_add(a, q), safe_add(x, t)), s), b); }
    function md5_ff(a, b, c, d, x, s, t)
    { return md5_cmn((b & c) | ((~b) & d), a, b, x, s, t); }
    function md5_gg(a, b, c, d, x, s, t)
    { return md5_cmn((b & d) | (c & (~d)), a, b, x, s, t); }
    function md5_hh(a, b, c, d, x, s, t)
    { return md5_cmn(b ^ c ^ d, a, b, x, s, t); }
    function md5_ii(a, b, c, d, x, s, t)
    { return md5_cmn(c ^ (b | (~d)), a, b, x, s, t); }
    function core_hmac_md5(key, data) {
        var bkey = str2binl(key); if (bkey.length > 16) bkey = core_md5(bkey, key.length * chrsz); var ipad = Array(16), opad = Array(16); for (var i = 0; i < 16; i++)
        { ipad[i] = bkey[i] ^ 0x36363636; opad[i] = bkey[i] ^ 0x5C5C5C5C; }
        var hash = core_md5(ipad.concat(str2binl(data)), 512 + data.length * chrsz); return core_md5(opad.concat(hash), 512 + 128);
    }
    function safe_add(x, y)
    { var lsw = (x & 0xFFFF) + (y & 0xFFFF); var msw = (x >> 16) + (y >> 16) + (lsw >> 16); return (msw << 16) | (lsw & 0xFFFF); }
    function bit_rol(num, cnt)
    { return (num << cnt) | (num >>> (32 - cnt)); }
    function str2binl(str) {
        var bin = Array(); var mask = (1 << chrsz) - 1; for (var i = 0; i < str.length * chrsz; i += chrsz)
            bin[i >> 5] |= (str.charCodeAt(i / chrsz) & mask) << (i % 32); return bin;
    }
    function binl2str(bin) {
        var str = ""; var mask = (1 << chrsz) - 1; for (var i = 0; i < bin.length * 32; i += chrsz)
            str += String.fromCharCode((bin[i >> 5] >>> (i % 32)) & mask); return str;
    }
    function binl2hex(binarray) {
        var hex_tab = hexcase ? "0123456789ABCDEF" : "0123456789abcdef"; var str = ""; for (var i = 0; i < binarray.length * 4; i++) {
            str += hex_tab.charAt((binarray[i >> 2] >> ((i % 4) * 8 + 4)) & 0xF) +
hex_tab.charAt((binarray[i >> 2] >> ((i % 4) * 8)) & 0xF);
        }
        return str;
    }
    function binl2b64(binarray) {
        var tab = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"; var str = ""; for (var i = 0; i < binarray.length * 4; i += 3) {
            var triplet = (((binarray[i >> 2] >> 8 * (i % 4)) & 0xFF) << 16) | (((binarray[i + 1 >> 2] >> 8 * ((i + 1) % 4)) & 0xFF) << 8) | ((binarray[i + 2 >> 2] >> 8 * ((i + 2) % 4)) & 0xFF); for (var j = 0; j < 4; j++)
            { if (i * 8 + j * 6 > binarray.length * 32) str += b64pad; else str += tab.charAt((triplet >> 6 * (3 - j)) & 0x3F); }
        }
        return str;
    }
};
IRCAMAINOBJ.prototype.getHash = function(forString) { return this._md5HashAlg.hex_md5(forString); };
IRCAMAINOBJ.prototype.getUniqueID = function() { return this._md5HashAlg.hex_md5(new Date().toString()); };
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
IRCAMAINOBJ.prototype.ThisPage = function(thisdoc) {
    if (!thisdoc) { thisdoc = this.document }
    var strpg = "";
    try { strpg = thisdoc.body.ThisPage || ""; strpg += ''; } catch (e) { };
    if (strpg == "") { var strpg = thisdoc.URLUnencoded + ""; var splstr = strpg.split("/"); if (splstr.length > 0) { strpg = splstr[splstr.length - 1]; } }
    return strpg;
};
//==============================================================================================================
// Class for General purpose functions
function IRCAOBJ(windref, IRCAMAINOBJref, IsMain) { // constructor
    this.window = windref || window; this.document = this.document; this.IRCAMAIN = IRCAMAINOBJref;
    this.page = ''; this.id = "IRCAGEN_" + this.page; this.name = this.name; try { this.pname = this.opener.name || this.pname } catch (e) { }; this.pname += '';
    this.query = this.qrystr || ''; this.isWindowRefresh = false; this.dtformat = ""; this.PageInitB = false; this.pageTitle = '';
    this.DelString = ''; this.isPageCanceled = false; this.enablePartialLoadCaching = true; this.plCache = [];
    this.Window_Init(IsMain); this.dhtmlwindow = this.dhtmlwindow;
};
IRCAOBJ.prototype.Window_Init = function(IsMain) {
    if (this.ircaMain()) { this.ircaMain().unLockPg = "" };
    if (!this.document.oncontextmenu) { this.document.oncontextmenu = this.DocContext }; this.document.onselectstart = this.DocContext; if (this.document.onkeydown == null) { this.document.onkeydown = this.DocKD };
    this.docready = function() { var Objirca = this.ircaObject; Objirca.Page_State(Objirca); }
    this.Page_InitSplForNetAdv(IsMain);
};
IRCAOBJ.prototype.Page_InitSplForNetAdv = function(IsMain) {
    if (!IsMain) {
        if (!this.igtbl_initGrid) {
            this.initGrid = []; this.igtbl_initGrid = function(gridId) { this.initGrid[this.initGrid.length] = gridId; this.ircaObject.includeGridScripts(); }
        }
        if (!this.igtree_initTree) {
            this.initTree = []; this.igtree_initTree = function(treeId) { this.initTree[this.initTree.length] = treeId; this.ircaObject.includeTreeScripts(); }
        }
        if (!this.ig_CreateWebScheduleInfo) {
            this.initWebScheduleFuncs = [];
            var oWebScheduleInfo1Obj = { window: this.window, updateControlState: function() { this.initWebScheduleFuncs[this.initWebScheduleFuncs.length] = ['oWebScheduleInfo1.updateControlState', arguments]; } };
            this.ig_CreateWebScheduleInfo = function() { this.initWebScheduleFuncs[this.initWebScheduleFuncs.length] = ['ig_CreateWebScheduleInfo', arguments]; return oWebScheduleInfo1Obj; }
            this.ig_CreateCalendar = function() { this.initWebScheduleFuncs[this.initWebScheduleFuncs.length] = ['ig_CreateCalendar', arguments]; }
            this.ig_CreateWebDialogActivator = function() { this.initWebScheduleFuncs[this.initWebScheduleFuncs.length] = ['ig_CreateWebDialogActivator', arguments]; }
            this.igcal_init = function() { this.initWebScheduleFuncs[this.initWebScheduleFuncs.length] = ['igcal_init', arguments]; }
            this.ig_CreateWebMonthView = function() { this.initWebScheduleFuncs[this.initWebScheduleFuncs.length] = ['ig_CreateWebMonthView', arguments]; }
        }
    }
    this.igtbl_tableMouseMove = this.dumpF; this.igtbl_headerMouseOut = this.dumpF; this.igtbl_headerMouseMove = this.dumpF; this.igtbl_headerMouseOver = this.dumpF; this.igtbl_cellMouseMove = this.dumpF; this.igtbl_cellMouseOver = this.dumpF;
    this.igtbl_cellMouseOut = this.dumpF; this.igtree_mouseover = this.dumpF; this.igtree_mouseout = this.dumpF; this.igtree_onscroll = this.dumpF; if (!this.igtbl_activate) this.igtbl_activate = this.dumpF;
};
IRCAOBJ.prototype.Page_Init = function() {
    this.PageInitB = true;
    this.page = this.ThisPage(); this.id = "IRCAGEN_" + this.page;
    //this.setFormTitle();
    //	if(this.name=='ChildWB'){
    //		if(!this.ircaMain().readOnly && this.ircaMain().unLockPg!=this.id){this.ircaMain().setFormLock(false)}
    //	}
    this.__doPostBack = this.__overridedoPostBack;
    if (!this.allowSumbit) {
        this.document.forms[0].attachEvent("onsubmit", function() { return this.allowSumbit == true });
    }
    //if(this.initGrid.length>=1){this.Grid_Init();}
    //if(this.initTree.length>=1){this.Tree_Init();}
    if (this.initWebScheduleFuncs && this.initWebScheduleFuncs.length > 0) { this.WebSchedule_Init(); }
    if (!this.dhtmlwindow) { this.dhtmlwindow = this.ircaMain().dhtmlwindow };
    //if(this.InitializeComponents){this.InitializeComponents(null,true)}
    if (!this.disableDataCall) this.setTimeout(new initDataCall(this, null, true, true), 1);
    return;
};
function initDataCall(thisObj, QueryString, blnasync, canCallInitFunc) {
    this.initData = function() {
        var isXmlDataSupported = (isNull(thisObj.document.body.NoXmlData));
        if (!isXmlDataSupported || checkOffLine()) return callInitializeComponents(thisObj, canCallInitFunc);
        var url = getUniqueUrl((thisObj.document.body.ThisPagePath || '') + thisObj.ThisPage() + '&' + QueryString);
        var NewExeObjx = getRequestObject();
        if (blnasync == null) { blnasync = true; }
        NewExeObjx.open("GET", url, blnasync);
        setBasicHeaders(NewExeObjx);
        NewExeObjx.setRequestHeader("&param", 'XMLDataRequest');
        NewExeObjx.onreadystatechange = new xmlDataCallBack(thisObj, NewExeObjx, canCallInitFunc, blnasync);
        NewExeObjx.send(null);
        thisObj = null;
    }
    return this.initData;
};
IRCAOBJ.prototype.startDataCall = function(QueryString, blnasync) {
    var thisObj = this.startDataCall ? this : this.ircaObject();
    new initDataCall(thisObj, QueryString, blnasync)();
};
function xmlDataCallBack(thisObj, NewExeObjx, canCallInitFunc, blnasync) {
    this.f = function() {
        if (NewExeObjx.readyState != 4) return;
        try {
            if (NewExeObjx.status == 403) { thisObj.ircaObject.ircaMain().absend(); return }
            if (NewExeObjx.status != 200) return;
            //call xmlDataFiller
            thisObj.ircaMain().WrapResponse(NewExeObjx, thisObj.document, thisObj.window, blnasync);
        } catch (e) { }
        finally { NewExeObjx = null; callInitializeComponents(thisObj, canCallInitFunc); thisObj = null; }
    };
    return this.f;
};
function callInitializeComponents(thisObj, canCallInitFunc) {
    if (canCallInitFunc != true) return;
    if (thisObj.InitializeComponents) { thisObj.InitializeComponents(null, true) };
}

IRCAOBJ.prototype.setFormTitle = function() {
};
IRCAOBJ.prototype.Page_State = function(Objirca) {
    if (Objirca.getWindow().document.readyState != "complete") return;
    if (!Objirca.PageInitB) { Objirca.Page_Init(); }
};
IRCAOBJ.prototype.Grid_Init = function(strGrid, reload) {
    if (!this.initGrid) { return; };
    for (var j = 0; j < this.initGrid.length; j++) {
        strGrid = this.initGrid[j];
        if (!strGrid) { break };
        this.execScript('this.o' + strGrid + '= this.igtbl_initGrid("' + strGrid + '")');
        var gridDiv = this.getObject(strGrid + '_div'); if (gridDiv) {
            gridDiv.setAttribute("IRCAType", "grid");
            this.eval('this.o' + strGrid + '.NeedPostBack = false;');
        }
    }
    this.initGrid = null;
};
IRCAOBJ.prototype.WebSchedule_Init = function() {
    if (!this.initWebScheduleFuncs) { return; };
    var Func2Call; var FuncArguments;
    for (var j = 0; j < this.initWebScheduleFuncs.length; j++) {
        Func2Call = this.initWebScheduleFuncs[j][0];
        FuncArguments = this.initWebScheduleFuncs[j][1];
        if (!Func2Call) { break };
        //diff
        //try{
        var Func = this.eval('' + Func2Call);
        if (!Func) { break };
        if (Func2Call == 'ig_CreateWebScheduleInfo') {
            this.oWebScheduleInfo1 = Func.apply(this, FuncArguments);
        } else if (Func2Call == 'oWebScheduleInfo1.updateControlState') {
            Func.apply(this.oWebScheduleInfo1, FuncArguments);
        } else {
            Func.apply(this, FuncArguments);
        }
        //}catch(e){;};
    }
    this.initWebScheduleFuncs = null;
};
IRCAOBJ.prototype.Tree_Init = function(strTree) {
    if (!this.initTree) { return; };
    for (var j = 0; j < this.initTree.length; j++) {
        strTree = this.initTree[j];
        if (!strTree) { break };
        this.eval('this.o' + strTree + '= this.igtree_initTree("' + strTree + '")');
        this.getObject('T_' + strTree).setAttribute("IRCAType", "tree");
    }
    this.initTree = null;
};
IRCAOBJ.prototype.includeGridScripts = function() {
    return;
};
IRCAOBJ.prototype.includeTreeScripts = function() {
    return;
};
IRCAOBJ.prototype.clearAllPartialCache = function() { this.plCache = null; this.plCache = []; };
IRCAOBJ.prototype.clearPartialCache = function(eventTarget, eventArgument) { var uniqueID = this.getHash(eventTarget + eventArgument); this.plCache[uniqueID] = null; };
IRCAOBJ.prototype.XPInfo = function(ObjId, infoText, title) {
    if (!this.XPAlert || !ObjId) { return }; if (!title) { title = this.pageTitle }; var Obj = this.getObject(ObjId);
    this.XPAlert(Obj, '<b>' + title + '</b>', infoText, 10, 'Info')
};
IRCAOBJ.prototype.ShowParentPopup = function(Url, title, type, isModal, windw) {
    if (typeof (Url) == 'undefined' || Url == null) return;
    if (!this.dhtmlwindow) return;
    if (typeof (type) == 'undefined' || type == null) type = 'iframe'; if (!windw) { windw = this.window; /*if(!windw.isPopup)windw=this.ircaMain().ChildWB*/ };
    if (!Url.toLowerCase().startsWith('forms/')) Url = 'forms/' + Url;
    var tempWind = this.dhtmlwindow.open(this.getUniqueID(), type, Url, title ? title : '', "resize=1,scrolling=1,center=1", windw, false, false, false, isModal);
    return tempWind;
};

IRCAOBJ.prototype.ShowModalPopup = function(Url, title, type, windw) {
    return this.ShowParentPopup(Url, title, type, true, windw);
};
IRCAOBJ.prototype.ShowPopup = function(Url, title, type, windw) {
    return this.ShowParentPopup(Url, title, type, false, windw);
};

IRCAOBJ.prototype.ShowFuploaddialog = function(varg, qry, windw) {
    if (!this.dhtmlwindow) return; if (!windw) windw = this.window;
    var tempWind = this.dhtmlwindow.openModal(this.getUniqueID(), "iframe", 'forms/sendFileIfr.aspx?' + qry, "DQM - Documents/Attachments", "center=1,resize=1,width=600px,height=300px", windw, true, true, false, true);
    tempWind.document.parentWindow.frames["_iframe-" + tempWind.id].name = varg + '';
    return tempWind;
};

IRCAOBJ.prototype.ShowPopupDiv = function(divID, title, prop, isModal, windw) {
    if (divID == '') return null; if (!isModal) isModal = true;
    //if(!this.document.getElementById(divID))return null;
    if (!this.dhtmlwindow) return null; if (!windw) windw = this.window;
    if (prop) { prop = prop + ",resize=1,scrolling=1,center=1"; } else { prop = "resize=1,scrolling=1,center=1" }
    var tempWind = this.dhtmlwindow.open(divID, "div", divID, title ? title : '', prop, windw, false, false, false, isModal);
    return tempWind;
};
IRCAOBJ.prototype.getHash = function(forString) { return this.ircaMain()._md5HashAlg.hex_md5(forString); };
IRCAOBJ.prototype.getUniqueID = function() { return this.ircaMain()._md5HashAlg.hex_md5(new Date().toString()); };
IRCAOBJ.prototype.ircaMain = function() { return this.IRCAMAIN || this.IRCAMAIN };
IRCAOBJ.prototype.splitStrA = "|~|";
IRCAOBJ.prototype.splitStrB = "|^|";
IRCAOBJ.prototype.escapeChars = function(strText) { strText += ''; var _strText = strText.replace("'", "\'"); _strText = _strText.replace('"', '\"'); _strText = _strText.replace('\n', '').replace('\r', ''); /*_strText=_strText.replace(jsCRLF,'\\r');*/return _strText };
IRCAOBJ.prototype.dumpF = function() { }
IRCAOBJ.prototype.getWindow = function() { return this.window }
IRCAOBJ.prototype.isNothing = function(objchk) { return this.document.getElementById(objchk) == null ? true : false; }
IRCAOBJ.prototype.isWindAlive = function(objchk) { if (!objchk) { return false }; var windw = null; if (typeof (objchk) == 'string') { windw = this.ircaMain().getWindowByName(objchk) } else { windw = objchk }; if (typeof (windw) == 'string') { return false }; if (!windw.closed && windw.location) { return true }; return false; }
IRCAOBJ.prototype.isEmpty = function(objchk, propchk) { if (!propchk) { propchk = 'value' }; return this.getObjectProp(objchk, propchk) == '' ? true : false; }
IRCAOBJ.prototype.getObject = function(objchk) { return this.document.getElementById(objchk); }
IRCAOBJ.prototype.getObjectValue = function(obj) { return this.document.getElementById(obj) == null ? "" : this.getObject(obj).value.trim(); }
IRCAOBJ.prototype.getObjectProp = function(obj, propstr) { if (!this.getObject(obj)) { return "" }; return this.eval("document.getElementById('" + obj + "')." + propstr); }
IRCAOBJ.prototype.setObjectValue = function(obj, xvalue, typ) { if (!typ) { typ = "0" }; var shtml = false; var typ = typ.split("/"); if (typ.length > 1 && typ[1].toLowerCase() == "h") { shtml = true }; if (!this.getObject(obj) || xvalue == null) { return }; xvalue = this.escapeChars(xvalue); var tmpobj = this.getObject(obj); switch (parseInt(typ[0], 10)) { case 0: tmpobj.value = xvalue; break; case 1: if (shtml) { tmpobj.innerHTML = xvalue } else { tmpobj.innerText = xvalue }; break; case 2: var sval = ""; var stext = ""; if (typeof (xvalue == "string")) { sval = xvalue; stext = sval } else { sval = xvalue[0][0]; stext = xvalue[0][1] } Add2Lstbx(tmpobj, stext, sval, this.document); break; case 3: tmpobj.checked = xvalue; break; } }
IRCAOBJ.prototype.getObjectSrc = function(obj) { try { return this.getObject(obj).src } catch (e) { return '' } }
IRCAOBJ.prototype.setObjectSrc = function(obj, xvalue) { try { this.getObject(obj).src = xvalue } catch (e) { } }
IRCAOBJ.prototype.setObjectProp = function(obj, propstr1, propstr2, pvalu, dquotepv) { if (!this.getObject(obj)) { return false }; if (!propstr1) { return false }; if (pvalu == null) { return false }; var propstr; if ((typeof (pvalu) == 'boolean') || (typeof (pvalu) == 'number')) { dquotepv = true }; if (!dquotepv && dquotepv != 0) { pvalu = "'" + pvalu.replace("'", "\\'") + "'" }; if (propstr2) { propstr = propstr1 + "." + propstr2 } else { propstr = propstr1 }; var scpt = "document.getElementById('" + obj + "')." + propstr + "="; if (typeof (pvalu) == 'boolean') { scpt += pvalu } else { scpt += pvalu == "" ? "''" : pvalu }; if (scpt == "") { return false }; try { this.execScript(this.escapeChars(scpt)); } catch (e) { }; return true }
IRCAOBJ.prototype.fireObjectMethod = function(obj, method, param) { if (!param) { param = '' }; try { this.eval("document.getElementById('" + obj + "')." + method + '(' + param + ');') } catch (e) { } }
IRCAOBJ.prototype.copyObjectValue = function(fromstr, tostr) { try { this.getObject(tostr).value = this.getObjectValue(fromstr) } catch (ex) { return false } return true };
IRCAOBJ.prototype.pause = function(timeout) { var dialogScript = 'setTimeout(' + ' function () { close(); }, ' + timeout + ');'; var disablwin = this.showModalDialog('javascript:this.document.writeln(' + '"<script>' + dialogScript + '<' + '/script>")'); }
IRCAOBJ.prototype.queryString = function(key) { var page = new PageQuery(this.location.search); return unescape(page.getValue(key)); }
IRCAOBJ.prototype.toolTipHelp = function(vartxt) { var oPopup = this.createPopup(); var oPopBody = oPopup.document.body; oPopBody.style.backgroundColor = "lightyellow"; oPopBody.style.border = "solid black 1px"; oPopBody.innerHTML = vartxt; oPopup.show(event.clientX, event.clientY, 180, 125, document.body); }
IRCAOBJ.prototype.repeatString = function(strInput, intCount) { var arrTmp = new Array(intCount + 1); return arrTmp.join(strInput); }
IRCAOBJ.prototype.checkEmail = function(e) { re = /(@.*@)|(\.\.)|(^\.)|(^@)|(@$)|(\.$)|(@\.)/; re_two = /^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,3}|[0-9]{1,3})(\]?)$/; if (!e.match(re) && e.match(re_two)) { return true; } else { return false }; }
IRCAOBJ.prototype.CWBNavigate = function(CWBpgstr, hndlcrossref) { CWBNavigate(CWBpgstr, hndlcrossref); }
IRCAOBJ.prototype.pageQuery = function(q) {
    if (q.length > 1) this.q = q.substring(1, q.length);
    else this.q = null; this.keyValuePairs = new Array();
    if (q) { for (var i = 0; i < this.q.split("&").length; i++) { this.keyValuePairs[i] = this.q.split("&")[i]; } }
    this.getKeyValuePairs = function() { return this.keyValuePairs; }
    this.getValue = function(s) {
        for (var j = 0; j < this.keyValuePairs.length; j++) { if (this.keyValuePairs[j].split("=")[0] == s) return this.keyValuePairs[j].split("=")[1]; }
        return false;
    }
    this.getParameters = function() {
        var a = new Array(this.getLength()); for (var j = 0; j < this.keyValuePairs.length; j++) { a[j] = this.keyValuePairs[j].split("=")[0]; }
        return a;
    }
    this.getLength = function() { return this.keyValuePairs.length; }
};
IRCAOBJ.prototype.validateObjectValues = function(arrobjstr) { var cont = 0; if (arrobjstr.length < 1) { return false }; for (var x = 0; x < arrobjstr.length; x++) { if (!this.getObjectValue(arrobjstr[x])) { cont++ } }; return cont == (arrobjstr.length) ? true : false }
// if was found:this in DocKD refers to Document instead of IRCAOBJ--so thisfunction is modified diff.
IRCAOBJ.prototype.DocKD = function() {
    var thishkey = this.parentWindow.event.keyCode;
    switch (thishkey) {
        case 114: case 18: case 116: case 115: case 122: case 114: case 117: case 112: case 118:
            this.parentWindow.event.keyCode = 0; this.parentWindow.event.cancelBubble = true; this.parentWindow.event.returnValue = false;
            if (this.parentWindow.parent.handleeventkb) { this.parentWindow.parent.handleeventkb(thishkey) }; break;
        case 66: case 69: case 70: case 73: case 72: case 76: case 79: case 78: case 80: case 82: case 87: case 119:
            if (!this.parentWindow.event.ctrlKey) { return }
            this.parentWindow.event.keyCode = 0; this.parentWindow.event.cancelBubble = true; this.parentWindow.event.returnValue = false;
            if (this.parentWindow.parent.handleeventkb) { this.parentWindow.parent.handleeventkb(thishkey) }; break;
        case 13:
            //this.parentWindow.event.keyCode = 0;this.parentWindow.event.cancelBubble = true;this.parentWindow.event.returnValue = false;
            if (this.parentWindow.handleeventkb) { this.parentWindow.handleeventkb(thishkey) }; /*break;*/
            if (!this.parentWindow.event.shiftKey && this.parentWindow.event.srcElement.type != "text" && this.parentWindow.event.srcElement.tagName != "INPUT") { return }
    }
};
IRCAOBJ.prototype.DocContext = function() {
    //return true;
    if (this.parentWindow.event.srcElement.disabled == true) { return false; }
    switch (this.parentWindow.event.srcElement.tagName) {
        case "INPUT": case "TEXTAREA":
            break;
        default:
            return false; break;
    }
};
IRCAOBJ.prototype.removeMediaPrint = function() {
    var forDoc; var returArryLinkEles = [];
    for (var i = 0; i < arguments.length; i++) {
        forDoc = arguments[i];
        if (!forDoc) { return };
        var links = forDoc.getElementsByTagName("LINK");
        for (var lnkmediaprint in links) {
            lnkmediaprint = links[lnkmediaprint];
            if (!lnkmediaprint.tagName) { continue };
            if (lnkmediaprint.getAttribute('media') == 'print') {
                returArryLinkEles[returArryLinkEles.length] = lnkmediaprint.removeNode();
            }
        }
    }; return returArryLinkEles;
};
IRCAOBJ.prototype.addMediaPrint = function() {
    if (!arguments[0]) { return }
    for (var eleM in arguments[0]) {
        eleM = arguments[0][eleM];
        if (!eleM || !eleM.document) { return };
        eleM.document.parentWindow.document.body.insertAdjacentElement('beforeBegin', eleM);
    }
};
IRCAOBJ.prototype.startPrintData = function(dataid, title) {
    if (typeof (dataid) != 'string') { return };
    var data;
    if (!isTextHTML(dataid)) {
        var dataObject = this.document.all[dataid];
        if (!dataObject) { return };
        data = dataObject.innerHTML;
    } else {
        data = dataid;
    }
    if (!data) { return };
    data = data.replace('<SCRIPT', '<DIV Style="display:none" ');
    data = data.replace('</SCRIPT>', '</DIV>');
    try {
        var lnkmediaprint = this.removeMediaPrint(this.document);
        var temptag = '<IFRAME id="winprintData"  style="width: 1px; height: 1px;" src="APPRES.ashx/1664805296/_blank.htm"></IFRAME>'
        this.document.body.insertAdjacentHTML('beforeEnd', temptag);
        var docC = this.winprintData.document.open('text/html', 'replace');
        docC.write(data); docC.title = title + ''; docC.close();
        this.winprintData.focus();
        this.winprintData.print();
        this.winprintData.frameElement.removeNode();
    } catch (e) {

    } finally {
        if (lnkmediaprint != null) {
            this.addMediaPrint(lnkmediaprint);
        }
    }
};
IRCAOBJ.prototype.endPrintData = function() {
    var elewinprintData = this.document.getElementById('winprintData');
    if (elewinprintData) {
        elewinprintData.removeNode();
    };
};
IRCAOBJ.prototype.ThisPage = function(thisdoc) { if (!thisdoc) { thisdoc = this.document }; return this.ircaMain().ThisPage(thisdoc); };
IRCAOBJ.prototype.WrapRequest = function(CntrolId, EvntType, PDOC, boolasync, pgtype, callbackfunc, paramx, reqWind) { if (!PDOC) { PDOC = this.document }; if (!reqWind) { reqWind = this.window }; return this.ircaMain().WrapRequest(CntrolId, EvntType, PDOC, boolasync, pgtype, callbackfunc, paramx, reqWind); };
IRCAOBJ.prototype.WrapResponse = function(xmlobj, PDOC, reqWind, async) { return this.ircaMain().WrapResponse(xmlobj, PDOC, reqWind, async); };
IRCAOBJ.prototype.confirmDeleteNode = function(curnode) {
    if (!curnode) { return false }
    if (curnode.hasChildren()) { this.XPInfo('cmdDelete', "Node(s) having children can't be deleted. <BR> Please delete the child Node(s) First."); return false; }
    var retv = this.confirm("Do you really want to Delete?");
    return retv;
};
IRCAOBJ.prototype.lockAllTabs = function(fortabbar) { if (!fortabbar) { return }; for (var itab in fortabbar.tabsId) { this.lockControl(tabbar.tabsId[itab]); } };
IRCAOBJ.prototype.lockTab = function(fortabbar, fortabId) { if (!fortabbar) { return }; this.lockControl(tabbar.tabsId[fortabId]); };
IRCAOBJ.prototype.unLockAllTabs = function(fortabbar) { if (!fortabbar) { return }; for (var itab in fortabbar.tabsId) { this.unLockControl(tabbar.tabsId[itab]); } };
IRCAOBJ.prototype.unLockTab = function(fortabbar, fortabId) { if (!fortabbar) { return }; this.unLockControl(tabbar.tabsId[fortabId]); };
IRCAOBJ.prototype.lockControl = function(cntrlObj) { this.ircaMain().lockControl(cntrlObj) };
IRCAOBJ.prototype.unLockControl = function(cntrlObj) { this.ircaMain().unLockControl(cntrlObj) };
IRCAOBJ.prototype.getReadLock = function() { try { return (this.ircaMain().readOnly && (this.ircaMain().CurMode != "search" && this.ircaMain().CurMode != "setup" && this.ircaMain().CurMode != "report")); } catch (e) { return false } }
IRCAOBJ.prototype.getEventPermit = function() { };
IRCAOBJ.prototype.getValue = function(msgID, langID, fileName) { return this.ircaMain().getValue(msgID, langID, fileName) };

IRCAOBJ.prototype.fixScriptinHTML = function(thisObjRef, tmpstr) {
    //for script execution
    var onerrorfuncRef = thisObjRef.onerror;
    thisObjRef.onerror = function() { return true };
    try {
        var siz = tmpstr.length; var curpos = 0;
        var s = 0, s1 = 0, e = 0;
        while ((curpos < siz) || s != -1 || e != -1) {
            s1 = tmpstr.indexOf('<script', e + 1);
            if (s1 == -1) break;
            s = tmpstr.indexOf('>', s1 + 2);
            e = tmpstr.indexOf('</script>', s + 2); e = e - 1;
            if (e == -1) break;
            var exc = tmpstr.substr(s + 1, e - s);
            exc = exc.replace('<!--', '');
            exc = exc.replace('// -->', '');
            exc = exc.replace('-->', '');
            try { thisObjRef.execScript(exc); } catch (r) { ; };
        }
    } catch (s) { ; };
    thisObjRef.onerror = onerrorfuncRef;
};
IRCAOBJ.prototype.partialLoad = function(eventTarget, eventArgument, containerObj, useDirectResponse) {
    if (!eventTarget) { return };
    if (!containerObj) { return };

    var tmpstr; var fromCache = false; var uniqueID = this.ircaObject.getHash(eventTarget + eventArgument);
    //if caching is enabled then check if its available
    if (this.ircaObject.enablePartialLoadCaching) {
        tmpstr = this.ircaObject.plCache[uniqueID]; fromCache = true;
    };
    if (!tmpstr) {
        fromCache = false;
        var thispageQry = (this.document.body.ThisPagePath || '') + this.ircaObject.ThisPage();
        var theFormvalues = ''; var theform = this.document.forms[0];
        //var thispageQry=theform.action +'';
        theFormvalues = '__EVENTTARGET=' + eventTarget + '&';
        theFormvalues += '__EVENTARGUMENT=' + eventArgument + '&';
        theFormvalues += 'IsCallBack=true&';
        theFormvalues += 'IsPartialLoad=true&';
        // if (!this.qrystr && this.document && this.document.forms[0]){
        this.qrystr = unescape(this.document.forms[0].action.split('?')[1]);
        // }
        if (this.qrystr) {
            if (thispageQry.indexOf("?") >= 0) {
                thispageQry += '&' + this.qrystr;
            } else {
                thispageQry += '?' + this.qrystr;
            }
        };
        this.ircaObject.ircaMain().AppLock();
        tmpstr = this.ircaObject.ircaMain().ExecutePFunc(thispageQry, theFormvalues, false, true);
        this.ircaObject.ircaMain().AppLock(true);
    }
    if (!tmpstr) { containerObj.innerHTML = ''; return }
    var hasigtblGrid = tmpstr.contains('igtbl_initGrid');
    //hold the ref to the NetAdv igtbl_initGrid function
    //these steps required since, when insertAdjacentHTML method executes the html content
    //having more than one NetAdv Grids, all except the first fails to init, (due to call timeout issue [igtbl_initGrid function takes more time])
    // the rest of the calls for Grid init are never called
    var tmpNetAdvGridInitFunc = this.igtbl_initGrid;
    //nullify the actual function, since Page_InitSplForNetAdv will not replace if it is already ther.
    if (hasigtblGrid) this.igtbl_initGrid = null;
    //call the replacement method 
    if (hasigtblGrid) this.ircaObject.Page_InitSplForNetAdv();
    containerObj.innerHTML = '';
    containerObj.insertAdjacentHTML('afterBegin', tmpstr);
    //for script execution
    this.ircaObject.fixScriptinHTML(this, tmpstr);
    //replace the method with original method
    if (hasigtblGrid) this.igtbl_initGrid = tmpNetAdvGridInitFunc;
    //now actually call the original method
    if (hasigtblGrid) this.ircaObject.Grid_Init('', true);
    if (!fromCache && this.ircaObject.enablePartialLoadCaching) {
        if (!this.ircaObject.plCache) {
            this.ircaObject.plCache = [];
        }
        this.ircaObject.plCache[uniqueID] = tmpstr;
    }
};
IRCAOBJ.prototype.__overridedoFormSubmit = function(eventTarget, eventArgument, xFormValues) {
    if (!this.allowSumbit) { return '' };
    if (this.beforePageChange) { this.beforePageChange() };
    // note how form.onsubmit is being called explicity 
    var thispageQry = (this.document.body.ThisPagePath || '') + this.ircaObject.page;
    var theFormvalues = ''; var theform = this.document.forms[0];
    theFormvalues = '__EVENTTARGET=' + escape(eventTarget.split("$").join(":")) + '&';
    theFormvalues += '__EVENTARGUMENT=' + escape(eventArgument) + '&';
    theFormvalues += 'IsCallBack=true&';
    if (xFormValues) {//sort code
        if (xFormValues.substr(xFormValues.length - 1, 1) != '&') { xFormValues += '&' };
        theFormvalues += xFormValues; this.xFormValues = xFormValues;
    } else if (this.xFormValues) {
        theFormvalues += this.xFormValues; //store for future
    };
    if (theform[eventTarget]) {
        theFormvalues += escape(theform.elements[eventTarget].name.split("$").join(":")) + '=' + escape(theform.elements[eventTarget].value);
    }
    if (!this.qrystr && this.document && this.document.forms[0]) {
        this.qrystr = unescape(this.document.forms[0].action.split('?')[1]);
    }
    if (this.qrystr) {
        if (thispageQry.indexOf("?") >= 0) {
            thispageQry += this.qrystr;
        } else {
            thispageQry += '?' + this.qrystr;
        }
    }
    //url,data,boolasync,returnContent
    this.ircaObject.ircaMain().AppLock();
    var tmpstr = this.ircaObject.ircaMain().ExecutePFunc(thispageQry, theFormvalues, false, true);
    this.ircaObject.ircaMain().AppLock(true);
    if (!tmpstr) { return '' }
    CollectGarbage(); this.__doPostBack = this.__overridedoPostBack;
    return tmpstr;
};
IRCAOBJ.prototype.__normaldoPostBack = function(eventTarget, eventArgument) {
    if (!this.allowSumbit) { return '' };
    var theForm = this.document.forms[0];
    if (!theForm) {
        theForm = document.Form1;
    }
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.__EVENTTARGET.value = eventTarget;
        theForm.__EVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
};
IRCAOBJ.prototype.__overridedoPostBack = function(eventTarget, eventArgument, xFormValues) {
    if (!eventArgument) { if (this.allowSumbit) { this.ircaObject.__normaldoPostBack(eventTarget, eventArgument) }; return };
    if (!eventArgument.contains('SORT') && !eventArgument.contains('Page')) { return }
    //Fire event if the function exists
    if (this.beforePageChange) { this.beforePageChange() };
    // note how form.onsubmit is being called explicity 
    var thispageQry = (this.document.body.ThisPagePath || '') + this.ircaObject.page;
    if (this.igtbl_formSubmit) { this.igtbl_formSubmit(this.eval('o' + eventTarget)) };
    var theFormvalues = ''; var theform = this.document.forms[0];
    theFormvalues = '__EVENTTARGET=' + escape(eventTarget.split("$").join(":")) + '&';
    theFormvalues += '__EVENTARGUMENT=' + escape(eventArgument) + '&';
    // can be maintained in session on server
    //theFormvalues += '__VIEWSTATE=' + escape(theform.__VIEWSTATE.value).replace(new RegExp('\\+', 'g'), '%2b') + '&';
    theFormvalues += 'IsCallBack=true&';
    if (xFormValues) {//sort code
        if (xFormValues.substr(xFormValues.length - 1, 1) != '&') { xFormValues += '&' };
        theFormvalues += xFormValues; this.xFormValues = xFormValues;
    } else if (this.xFormValues) {
        theFormvalues += this.xFormValues; //store for future
    };
    if (theform[eventTarget]) {
        theFormvalues += escape(theform.elements[eventTarget].name.split("$").join(":")) + '=' + escape(theform.elements[eventTarget].value);
    }
    // for GridPopup. As its a general page for all grids, it needs know which type of grid is being processed.
    if (!this.qrystr && this.document && this.document.forms[0]) {
        this.qrystr = unescape(this.document.forms[0].action.split('?')[1]);
    }
    if (this.qrystr) {
        if (thispageQry.indexOf("?") >= 0) {
            thispageQry += this.qrystr;
        } else {
            thispageQry += '?' + this.qrystr;
        }
    } else {
        if (theform['ptype']) {
            thispageQry += '?gridtype=' + escape(this.ircaObject.getObjectValue('ptype'));
        }
    }
    //bug fix for paging misplaced in page
    var GridParentElement = null;
    var tmpGridMainObj = this.ircaObject.getObject(eventTarget + '_main');
    if (tmpGridMainObj && tmpGridMainObj.parentNode.id != this.document.forms[0].id) {
        GridParentElement = tmpGridMainObj.parentNode;
    };
    this.ircaObject.ircaMain().AppLock();
    var tmpstr = this.ircaObject.ircaMain().ExecutePFunc(thispageQry, theFormvalues, false, true);
    this.ircaObject.ircaMain().AppLock(true);
    //this.ircaObject.ircaMain().UnlockWin(this.document);
    if (!tmpstr) { return }
    //this.igtbl_unloadGrid();
    if (eval("typeof(o" + eventTarget + ")=='object'")) {
        this.igtbl_unloadGrid(eventTarget);
    }
    this.ircaObject.setObjectProp(eventTarget, 'outerHTML', null, '');
    this.ircaObject.setObjectProp(eventTarget + '_main', 'outerHTML', null, '');
    CollectGarbage();
    if (GridParentElement) {
        GridParentElement.insertAdjacentHTML('afterBegin', tmpstr);
    } else {
        this.document.forms[0].insertAdjacentHTML('beforeEnd', tmpstr); //
    }
    //for script execution
    this.ircaObject.fixScriptinHTML(this, tmpstr);
    this.ircaObject.fireObjectMethod(eventTarget + '_div', 'setAttribute', '"IRCAType","grid"');
    //bug fix for infragistics - currentPageIndex not updated after page navigation
    this.ircaObject.eval('o' + eventTarget + '.CurrentPageIndex=' + parseInt(eventArgument.replace('Page:', '')) || 1);
    if (this.ircaObject.sortConfig && this.ircaObject.sortConfig[eventTarget]) {
        this.ircaObject.sortConfig[eventTarget]['page'] = parseInt(eventArgument.replace('Page:', '')) || 1;
    }
    if (this.afterPageChange) { this.afterPageChange() };
    this.__doPostBack = this.ircaObject.__overridedoPostBack;
};

// attach to the window
