if (IRCAMAINOBJ) {
    if (!IRCAMAIN || !IRCAMAIN.IRCAWind) {
        IRCAMAIN = new IRCAMAINOBJ(); IRCAMAIN.IRCAWind = name;
        IRCA = new IRCAOBJ(null, null, true); //tell IRCAOBJ that this is main
        ircaObject = IRCA
    }
} else {
    if (!ircaObject || !ircaObject.ThisPage) {
        var IRCAMAINObject;
        if (!assignIrcaObject(parent)) {
            if (!assignIrcaObject(opener)) {
                if (!assignIrcaObject(dialogArguments)) {
                    if (dialogArguments && !assignIrcaObject(dialogArguments[0])) {
                        if (!assignIrcaObject(parent.parent)) {
                            //failed tho tried hard
                        }
                    }
                }
            }
        }
    }
};
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
function assignIrcaObject(windowObject) {
    if (!windowObject) { return }; var IRCAMAINObject;
    if (windowObject.IRCAMAIN) IRCAMAINObject = windowObject.IRCAMAIN;
    else if (windowObject.ircaObject) IRCAMAINObject = windowObject.ircaObject.ircaMain();
    if (!IRCAMAINObject) { return }; ircaObject = IRCAMAINObject.getNewInstance(window);
    return true;
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
}
function getUniqueUrl(strUrl) {
    var dtsend = encodeURI(new Date().toString());
    if (strUrl.indexOf("?") > 0)
        return strUrl + "&" + dtsend;
    else
        return strUrl + "?" + dtsend;
}
function getXmlFileContent(xmlFile, async, reqErrStatusObj) {
    try {
        var NewExeObjx = getRequestObject();
        NewExeObjx.open("GET", getUniqueUrl(xmlFile), async || false);
        NewExeObjx.setRequestHeader("IRCAAuth", vauth || '.');
        NewExeObjx.setRequestHeader("&param", 'IRCA');
        NewExeObjx.send('');
        if (!reqErrStatusObj) reqErrStatusObj = new Object(); reqErrStatusObj.reqErrStatus = NewExeObjx.getResponseHeader("REQERRSTATUS") || '';
        if (NewExeObjx.status != 200) { return ''; }
        return NewExeObjx.responseText;
    } catch (e) { return ''; };
}

var WinReg = new Array();
var myDefaultUrl = "APPPAGEHANDLER.ashx";
var xPool = new Array();

function IRCAMAINOBJ() { // constructor
    this.id = "IRCA MAIN"; this.window = window; this.document = this.document; this.readOnly = false; this.unLockPg = ""; this.ReqXMLstr = "";
    this.IRCAAuth = ''; this.IRCAWind = ''; this.Readonlytitle = '  [ READ ONLY ]'; this.keyValue = ''; this.parentKeyValue = ''
    this.appConfigManager = this.getNewdomXml('appConfigManager', true); this.tmpdocfocus = null; this._md5HashAlg = new this.md5HashAlg();
    if (document.getElementById("AppCConfig")) { this.appConfigManager.root = 'appconfig/'; this.appConfigManager.domObj.loadXML(document.getElementById("AppCConfig").innerHTML) };
}
function isTextHTML(strText) {
    if (!strText) { return false };
    try {
        return (strText.length != getsText(strText).length);
    } catch (r) { return false };
}
IRCAMAINOBJ.prototype.getNewInstance = function(windref) { return new this.IRCAOBJ(windref, this); }

IRCAMAINOBJ.prototype.domXml = IXMLDOM; // interface to XMLDOM
function IXMLDOM(id) {
    this.domObj = null;
    this.id = id + "";
    this.root = "";
};
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
IRCAMAINOBJ.prototype.unRegWindows = function() {
    for (var unr = WinReg.length; unr >= -1; unr--) {
        try {
            WinReg[WinReg[unr]].close();
        } catch (e) { };
        delete WinReg[WinReg[unr]];
        WinReg.splice(unr, 1);
    }
};
IRCAMAINOBJ.prototype.AppLock = function(boolUnLock, id, zindx) {
    if (boolUnLock) {
        //if(this.dhtmlwindow && this.dhtmlwindow.getLength()<2)
        this.windUnLock(id);
    } else {
        this.windLock(id, zindx);
    }
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
//----------------------------------------------------------

IRCAMAINOBJ.prototype.ThisPage = function(thisdoc) {
    if (!thisdoc) { thisdoc = this.document }
    var strpg = "";
    try { strpg = thisdoc.body.ThisPage || ""; strpg += ''; } catch (e) { };
    if (strpg == "") { var strpg = thisdoc.URLUnencoded + ""; var splstr = strpg.split("/"); if (splstr.length > 0) { strpg = splstr[splstr.length - 1]; } }
    return strpg;
};
function IRCAOBJ(windref, IRCAMAINOBJref, IsMain) { // constructor
    this.window = windref || window; this.document = this.document; this.IRCAMAIN = IRCAMAINOBJref;
    this.page = ''; this.id = "IRCAGEN_" + this.page; this.name = this.name; try { this.pname = this.opener.name || this.pname } catch (e) { }; this.pname += '';
    this.query = this.qrystr || ''; this.isWindowRefresh = false; this.dtformat = ""; this.PageInitB = false; this.pageTitle = '';
    this.DelString = ''; this.isPageCanceled = false; this.enablePartialLoadCaching = true; this.plCache = [];
    this.Window_Init(IsMain); this.dhtmlwindow = this.dhtmlwindow;
};
IRCAOBJ.prototype.ThisPage = function(thisdoc) {
    if (!thisdoc) { thisdoc = this.document }; return this.ircaMain().ThisPage(
thisdoc);
};
IRCAOBJ.prototype.getHash = function(forString) { return this.ircaMain()._md5HashAlg.hex_md5(forString); };
IRCAOBJ.prototype.getUniqueID = function() { return this.ircaMain()._md5HashAlg.hex_md5(new Date().toString()); };

IRCAOBJ.prototype.ircaMain = function() { return this.IRCAMAIN || this.IRCAMAIN };
IRCAOBJ.prototype.Window_Init = function(IsMain) {
    if (this.ircaMain()) { this.ircaMain().unLockPg = "" };
    if (!this.document.oncontextmenu) { this.document.oncontextmenu = this.DocContext };
    this.document.onselectstart = this.DocContext; 
    if (this.document.onkeydown == null) { this.document.onkeydown = this.DocKD };
    this.docready = function() { var Objirca = this.ircaObject; Objirca.Page_State(Objirca); }
    this.Page_InitSplForNetAdv(IsMain);
};
IRCAOBJ.prototype.Page_State = function(Objirca) {
    if (Objirca.getWindow().document.readyState != "complete") return;
    if (!Objirca.PageInitB) { Objirca.Page_Init(); }
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
