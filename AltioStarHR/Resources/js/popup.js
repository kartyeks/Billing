var dhtmlwindow = {
    imagefiles: ['APPRES.ashx/1664805296/min.gif', 'APPRES.ashx/1664805296/close.gif', 'APPRES.ashx/1664805296/restore.gif', 'APPRES.ashx/1664805296/resize.gif', 'APPRES.ashx/1664805296/refresh.gif'], //Path to 4 images used by script, in that order
    ajaxbustcache: true,

    minimizeorder: 0,
    tobjects: [],

    init: function(t, contenttype, noMin, noRefresh, pwindow) {
        var srcWindow = window;
        if ((contenttype == 'inline') || (contenttype == 'div')) srcWindow = pwindow;
        srcWindow.document.body.insertAdjacentHTML('beforeEnd', '<div id="' + t + '" class="dhtmlwindow" style="display:none;visibility:hidden;LEFT:0px;POSITION:absolute;TOP:0px;"</div>');
        var t = srcWindow.document.getElementById(t);
        t.className = "dhtmlwindow"
        var domwindowdata = ''
        domwindowdata = '<div class="drag-handle" ><span class="drag-title" ></span>'
        domwindowdata += '<div class="drag-controls" nowrap >';
        if (!noRefresh) domwindowdata += ' <img id="' + t.id + '_RefreshImg" src="' + this.imagefiles[4] + '" title="Refresh" />';
        if (!noMin) domwindowdata += ' <img id="' + t.id + '_MinimizeImg" src="' + this.imagefiles[0] + '" title="Minimize" />';
        domwindowdata += ' <img src="' + this.imagefiles[1] + '" title="Close" /></div>'
        domwindowdata += '</div>'
        domwindowdata += '<div id="' + t.id + '_contentarea" class="drag-contentarea"></div>'
        domwindowdata += '<div class="drag-statusarea"><div class="drag-resizearea" style="background: transparent url(' + this.imagefiles[3] + ') top right no-repeat;">&nbsp;</div></div>'
        domwindowdata += '</div>'
        t.innerHTML = domwindowdata
        this.zIndexvalue = ((this.zIndexvalue) ? this.zIndexvalue + 1 : 2333) + this.tobjects.length;
        var divs = t.getElementsByTagName("div")
        for (var i = 0; i < divs.length; i++) {
            if (/drag-/.test(divs[i].className))
                t[divs[i].className.replace(/drag-/, "")] = divs[i]
        }
        t.style.zIndex = this.zIndexvalue
        t.handle._parent = t
        t.resizearea._parent = t
        t.controls._parent = t
        t.onclose = function() { return true }
        t.onmousedown = function() { dhtmlwindow.zIndexvalue++; this.style.zIndex = dhtmlwindow.zIndexvalue }
        t.handle.onmousedown = dhtmlwindow.setupdrag
        t.resizearea.onmousedown = dhtmlwindow.setupdrag
        t.controls.onclick = dhtmlwindow.enablecontrols
        t.show = function() { dhtmlwindow.show(this) }
        t.hide = function() { dhtmlwindow.close(this, true) }
        t.setSize = function(w, h) { dhtmlwindow.setSize(this, w, h) }
        t.moveTo = function(x, y) { dhtmlwindow.moveTo(this, x, y) }
        t.isResize = function(bol) { dhtmlwindow.isResize(this, bol) }
        t.isScrolling = function(bol) { dhtmlwindow.isScrolling(this, bol) }
        t.load = function(contenttype, contentsource, title) { dhtmlwindow.load(this, contenttype, contentsource, title) }
        this.tobjects[t.id] = t;
        return t
    },
    openModal: function(t, contenttype, contentsource, title, attr, pwindow, noMin, noRefresh, recalonload) {
        return this.open(t, contenttype, contentsource, title, attr, pwindow, noMin, noRefresh, recalonload, true);
    },
    open: function(t, contenttype, contentsource, title, attr, pwindow, noMin, noRefresh, recalonload, isModal) {
        var d = dhtmlwindow; if (pwindow == null) { pwindow = window };
        var tOriginal = t; var returning = false;
        if (window.ircaObject) { t = ircaObject.getHash(t); }
        if (pwindow.document.getElementById(t) == null) {
            t = this.init(t, contenttype, noMin, noRefresh, pwindow)
            t.originalid = tOriginal;
        } else {
            t = pwindow.document.getElementById(t);
            t.style.display = "block";
            t.contentarea.style.display = "block";
            this.setTitle(t, title);
            setZIndex();
            returning = true;
        }
        t.pwindow = pwindow; t.attr = attr;
        t.noMin = noMin;
        t.noRefresh = noRefresh;
        t.setSize(this.getValue(t, ("width")), (this.getValue(t, "height")))
        if (typeof recalonload != "undefined" && recalonload == "recal" && this.scroll_top == 0) {
            var srcWindow = window; if ((contenttype == 'inline') || (contenttype == 'div')) srcWindow = pwindow;
            if (window.attachEvent && !window.opera)
                this.addEvent(srcWindow, function() { setTimeout(function() { t.moveTo(xpos, ypos) }, 400) }, "load")
            else
                this.addEvent(srcWindow, function() { t.moveTo(xpos, ypos) }, "load")
        }
        t.isResize(this.getValue(t, "resize"))
        t.isScrolling(this.getValue(t, "scrolling"))
        t.style.display = "block"
        t.contentarea.style.display = "block"
        if (!returning) t.load(contenttype, contentsource, title)
        if (t.state == "minimized" && t.controls.firstChild.title == "Restore") {
            t.controls.firstChild.setAttribute("src", dhtmlwindow.imagefiles[0])
            t.controls.firstChild.setAttribute("title", "Minimize")
            t.state = "fullview"
        };
        t.isModal = (typeof isModal != 'undefined');
        setModalAttr(); this.dialogAutoResize(t);
        return t

        function setZIndex() {
            d.zIndexvalue = ((d.zIndexvalue) ? d.zIndexvalue + 1 : 2333) + d.tobjects.length;
            t.style.zIndex = d.zIndexvalue;
        };
        function setModalAttr() {
            if (!t.isModal) return;
            if ((t.contentarea.datatype == 'inline') || (t.contentarea.datatype == 'div')) {
                dhtmlwindow.documentlocker(t);
            } else {
                if (t.pwindow.ircaObject) t.pwindow.ircaObject.ircaMain().AppLock(false, t.id + '_irca__dhtmlLocker', (dhtmlwindow.zIndexvalue - 1));
            }
        };
    },
    documentlocker: function(t, boolUnlock) {
        var srcWindow = window; if ((t.contentarea.datatype == 'inline') || (t.contentarea.datatype == 'div')) srcWindow = t.pwindow;
        if (boolUnlock == true) {
            srcWindow.ircaObject.ircaMain().unLockControl(t.document.body);
            srcWindow.document.body.scroll = srcWindow.docscrollable + '';
            srcWindow.ircaObject.ircaMain().hideControls(srcWindow.document.getElementsByTagName('SELECT'), true);
        } else {
            srcWindow.ircaObject.ircaMain().lockControl(t.document.body);
            srcWindow.docscrollable = t.document.body.scroll;
            srcWindow.document.body.scroll = 'no';
            srcWindow.ircaObject.ircaMain().hideControls(srcWindow.document.getElementsByTagName('SELECT'));
        }
    },
    setSize: function(t, w, h) {
        var wMax = Math.max(parseInt(w), 225); var hMax = Math.max(parseInt(h), 125);
        var dw = this.getValue(t, "width"); var dh = this.getValue(t, "height");
        if (t.pwindow && t.pwindow.frameElement) {
            if (!dw) wMax = Math.min(wMax, t.pwindow.frameElement.offsetWidth - 50);
            if (!dh) hMax = Math.min(hMax, t.pwindow.frameElement.offsetHeight - 75);
        }
        wMax = Math.min(wMax, screen.availWidth - 125); hMax = Math.min(hMax, screen.availHeight - 125);
        t.style.width = Math.abs(wMax) + "px"
        t.contentarea.style.height = Math.abs(hMax) + "px"
    },

    moveTo: function(t, x, y) {
        this.getviewpoint(t.pwindow)
        t.style.left = (x == "middle") ? this.scroll_left + Math.abs((this.docwidth - t.offsetWidth) / 2) + "px" : this.scroll_left + parseInt(x) + "px"
        t.style.top = (y == "middle") ? this.scroll_top + Math.abs((this.docheight - t.offsetHeight) / 2) + "px" : this.scroll_top + parseInt(y) + "px"
    },

    isResize: function(t, bol) {
        t.statusarea.style.display = (bol) ? "block" : "none"
    },

    isScrolling: function(t, bol) {
        t.contentarea.style.overflow = (bol) ? "auto" : "hidden"
    },
    setTitle: function(t, title) {
        if (typeof title != "undefined")
            t.handle.firstChild.innerText = title;
        else
            t.handle.firstChild.innerText = '';
    },
    load: function(t, contenttype, contentsource, title) {
        var contenttype = contenttype.toLowerCase();
        t.contentarea.datatype = contenttype;
        this.setTitle(t, title);
        if (contenttype == "inline") {
            t.contentarea.innerHTML = contentsource; this.dialogAutoResize(t);
        } else if (contenttype == "div") {
            var contentsourceouterHTML = t.pwindow.document.getElementById(contentsource).outerHTML;
            t.pwindow.document.getElementById(contentsource).removeNode(true);
            t.contentarea.innerHTML = contentsourceouterHTML;
            t.contentarea.firstChild.style.display = '';
            this.dialogAutoResize(t);
        }
        else if (contenttype == "iframe") {
            t.contentarea.style.overflow = "hidden"
            if (!t.contentarea.firstChild || t.contentarea.firstChild.tagName != "IFRAME")
                t.contentarea.innerHTML = '<iframe src="about:blank" style="margin:0; padding:0; width:100%; height: 100%" name="_iframe-' + t.id + '"></iframe>'

            var ifrmWindow = t.document.parentWindow.frames["_iframe-" + t.id];
            if (!isTextHTML(contentsource)) {
                this.ajax_connect(contentsource, t);
            } else {
                this.write2window(ifrmWindow, contentsource, t, contenttype);
            }
        }
        else if (contenttype == "ajax") {
            this.ajax_connect(contentsource, t)
        }
    },
    write2window: function(targetWindow, targetContent, t) {
        var newdoc = targetWindow.document.open('text/html', 'replace');
        targetWindow.execScript('window.ircaObject=window.parent.ircaObject.ircaMain().getNewInstance(window)');
        newdoc.write(targetContent);
        newdoc.close();
        targetWindow.close = function() { dhtmlwindow.close(t) }
        targetWindow.opener = t.pwindow || window;
        targetWindow.isPopup = true;
        if (targetWindow.document && t.handle.firstChild.innerText == '') {
            t.handle.firstChild.innerText = targetWindow.document.title;
        }
        this.dialogAutoResize(t);
    },
    dialogAutoResize: function(t) {
        switch (t.contentarea.datatype.toLowerCase()) {
            case 'inline': case 'div':
                var w = this.getValue(t, "width"); var h = this.getValue(t, "height");
                w = Math.max(w, t.contentarea.offsetWidth - 50); h = Math.max(h, t.contentarea.offsetHeight - 50);
                t.setSize(w, h);
                break;

            case 'iframe': case 'ajax':
                var ifrmWindow = t.document.parentWindow.frames["_iframe-" + t.id];
                if (ifrmWindow && ifrmWindow.document.forms[0]) t.setSize(ifrmWindow.document.forms[0].offsetWidth + 50, ifrmWindow.document.forms[0].offsetHeight + 75);
                break;
        }
        var xpos = this.getValue(t, "center") ? "middle" : this.getValue(t, "left")
        var ypos = this.getValue(t, "center") ? "middle" : this.getValue(t, "top")
        t.moveTo(xpos, ypos)
        t.style.visibility = "visible"
    },
    getValue: function getValue(t, Name) {
        var config = new RegExp(Name + "=([^,]+)", "i")
        return (config.test(t.attr)) ? parseInt(RegExp.$1) : 0
    },
    setupdrag: function(e) {
        var d = dhtmlwindow
        var t = this._parent
        d.etarget = this
        var srcWindow = window; if ((t.contentarea.datatype == 'inline') || (t.contentarea.datatype == 'div')) srcWindow = t.pwindow;
        var e = srcWindow.event || e
        if (e && (t.controls == e.srcElement.parentElement) && t.controls.onclick) { /*t.controls.onclick();*/return false };
        d.initmousex = e.clientX
        d.initmousey = e.clientY
        d.initx = parseInt(t.offsetLeft)
        d.inity = parseInt(t.offsetTop)
        d.width = parseInt(t.offsetWidth)
        d.contentheight = parseInt(t.contentarea.offsetHeight)
        if (t.contentarea.datatype == "iframe") {
            t.style.backgroundColor = "#F8F8F8"
            t.contentarea.style.visibility = "hidden"
        }
        var Ele = t.handle; if (e && e.srcElement && e.srcElement.className == 'drag-resizearea') Ele = e.srcElement;
        Ele.setCapture();
        Ele.document.attachEvent('onclick', function() { document.releaseCapture(); });
        if (Ele.className == 'drag-resizearea') {
            Ele.onlosecapture = EleOnloseCapture;
        } else {
            Ele.onmousemove = d.getdistance;
            Ele.onlosecapture = EleOnloseCapture;
        }

        function EleOnloseCapture() {
            d.getdistance(null, t);
            if (t.contentarea.datatype == "iframe") {
                t.contentarea.style.backgroundColor = "white"
                t.contentarea.style.visibility = "visible"
            }
            d.stop(d, Ele)
        }

        return false
    },

    getdistance: function(e, te) {
        try {
            var d = dhtmlwindow
            var etarget = d.etarget; var t = this._parent; if (te && te.contentarea) { t = te }
            var srcWindow = window; if ((t.contentarea.datatype == 'inline') || (t.contentarea.datatype == 'div')) srcWindow = t.pwindow;
            var e = srcWindow.event || e
            d.distancex = e.clientX - d.initmousex
            d.distancey = e.clientY - d.initmousey
            if (etarget.className == "drag-handle")
                d.move(etarget._parent, e)
            else if (etarget.className == "drag-resizearea")
                d.resize(etarget._parent, e)
            return false
        } catch (e) { return false; };
    },

    getviewpoint: function(wnd) {
        if (!wnd) { wnd = window; }
        this.standardbody = wnd.document.body
        this.scroll_top = this.standardbody.scrollTop
        this.scroll_left = this.standardbody.scrollLeft
        this.docwidth = this.standardbody.clientWidth
        this.docheight = this.standardbody.clientHeight
    },

    rememberattrs: function(t) {
        t.lastx = parseInt((t.style.left || t.offsetLeft))//-dhtmlwindow.scroll_left
        t.lasty = parseInt((t.style.top || t.offsetTop))//-dhtmlwindow.scroll_top
        t.lastwidth = t.style.width
    },

    move: function(t, e) {
        var tTop = Math.max(dhtmlwindow.distancey + dhtmlwindow.inity, 0);
        t.style.left = Math.max(dhtmlwindow.distancex + dhtmlwindow.initx, 0) + "px"
        t.style.top = tTop + "px"
    },

    resize: function(t, e) {
        t.style.width = Math.max(dhtmlwindow.width + dhtmlwindow.distancex, 225) + "px"
        t.contentarea.style.height = Math.max(dhtmlwindow.contentheight + dhtmlwindow.distancey, 125) + "px"
    },

    enablecontrols: function(e) {
        var d = dhtmlwindow; var t = this._parent;
        var srcWindow = window; if ((t.contentarea.datatype == 'inline') || (t.contentarea.datatype == 'div')) srcWindow = t.pwindow;
        var sourceobj = srcWindow.event ? srcWindow.event.srcElement : e.target
        if (/Minimize/i.test(sourceobj.getAttribute("title")))
            d.minimize(sourceobj, this._parent)
        else if (/Restore/i.test(sourceobj.getAttribute("title")))
            d.restore(sourceobj, this._parent)
        else if (/Close/i.test(sourceobj.getAttribute("title")))
            d.close(this._parent)
        else if (/Refresh/i.test(sourceobj.getAttribute("title")))
            if (this._parent.pwindow.dialog_onrefresh) { try { this._parent.pwindow.dialog_onrefresh(this._parent) } catch (e) { ; }; }
        return false
    },

    minimize: function(button, t) {
        dhtmlwindow.rememberattrs(t)
        button.setAttribute("src", dhtmlwindow.imagefiles[2])
        button.setAttribute("title", "Restore")
        t.state = "minimized"
        t.contentarea.style.display = "none"
        t.statusarea.style.display = "none"
        if (t.all[t.id + '_RefreshImg']) t.all[t.id + '_RefreshImg'].style.visibility = "hidden"
        if (typeof t.minimizeorder == "undefined") {
            dhtmlwindow.minimizeorder++
            t.minimizeorder = dhtmlwindow.minimizeorder
        }
        t.style.width = Math.max(t.handle.offsetWidth, 200) + 'px'
    },

    restore: function(button, t) {
        button.setAttribute("src", dhtmlwindow.imagefiles[0])
        button.setAttribute("title", "Minimize")
        t.state = "fullview"
        t.style.display = "block"
        if (t.all[t.id + '_RefreshImg']) t.all[t.id + '_RefreshImg'].style.visibility = ''
        t.contentarea.style.display = "block"
        t.statusarea.style.display = "block"
        t.style.width = parseInt(t.lastwidth) + "px"
    },


    close: function(t, noevent) {
        var closewinbol;
        try {
            if (!noevent) closewinbol = t.onclose(true);
        }
        catch (err) {
            closewinbol = true
        }
        finally {
            if (typeof closewinbol == "undefined") {
                closewinbol = true
            }
        }
        if (closewinbol) {
            if (t.state != "minimized") dhtmlwindow.rememberattrs(t)
            var typ = t.contentarea.datatype.toLowerCase();
            if ((typ == 'iframe') || (typ == 'ajax')) { var ifrmWindow = t.document.parentWindow.frames["_iframe-" + t.id]; ifrmWindow.frameElement.src = ''; }
            if (t.isModal) {
                if ((t.contentarea.datatype == 'inline') || (t.contentarea.datatype == 'div')) {
                    dhtmlwindow.documentlocker(t, true);
                } else {
                    window.ircaObject.ircaMain().AppLock(true, t.id + '_irca__dhtmlLocker');
                }
            }
            delete dhtmlwindow.tobjects[t.id];
            if (t.contentarea.datatype.toLowerCase() == 'div')
                t.style.display = 'none';
            else
                t.removeNode(true);
        }
        return closewinbol
    },

    show: function(t) {
        if (t.lastx)
            dhtmlwindow.restore(t.controls.firstChild, t)
        else
            t.style.display = "block"
        t.state = "fullview"
    },

    ajax_connect: function(url, t) {
        var page_request = false
        var bustcacheparameter = ""
        if (window.XMLHttpRequest)
            page_request = new window.XMLHttpRequest()
        else if (window.ActiveXObject) {
            try {
                page_request = new window.ActiveXObject("Msxml2.XMLHTTP")
            }
            catch (e) {
                try {
                    page_request = new window.ActiveXObject("Microsoft.XMLHTTP")
                }
                catch (e) { }
            }
        }
        else
            return false
        page_request.onreadystatechange = function() { dhtmlwindow.ajax_loadpage(page_request, t) }
        if (this.ajaxbustcache)
            bustcacheparameter = (url.indexOf("?") != -1) ? "&" + new Date().getTime() : "?" + new Date().getTime()
        page_request.open('GET', url + bustcacheparameter, true)
        page_request.setRequestHeader('&param', 'IRCA');
        page_request.send(null)
    },

    ajax_loadpage: function(page_request, t) {
        if (page_request.readyState == 4 && (page_request.status == 200 || window.location.href.indexOf("http") == -1)) {
            if (t.contentarea.datatype == 'iframe') {
                var ifrmWindow = t.document.parentWindow.frames["_iframe-" + t.id];
                this.write2window(ifrmWindow, page_request.responseText, t);
            } else {
                t.contentarea.innerHTML = page_request.responseText;
                this.dialogAutoResize(t);
            }
        } else if (page_request.readyState == 4 && page_request.status == 403 && t.document.parentWindow.ircaObject) {
            t.document.parentWindow.ircaObject.ircaMain().absend();
        }
    },


    stop: function(d, Ele) {
        dhtmlwindow.etarget = null
        Ele.document.detachEvent('onclick', function() { document.releaseCapture(); });
        Ele.onmousemove = null;
        Ele.onlosecapture = null;
    },

    addEvent: function(target, functionref, tasktype) {
        var tasktype = (window.addEventListener) ? tasktype : "on" + tasktype
        if (target.addEventListener)
            target.addEventListener(tasktype, functionref, false)
        else if (target.attachEvent)
            target.attachEvent(tasktype, functionref)
    },

    cleanup: function() {
        for (var dhtmlwindowObj in dhtmlwindow.tobjects) {
            delete dhtmlwindow.tobjects[dhtmlwindowObj];
        }
        window.onload = null
    },

    refreshAll: function() {
        for (var dhtmlwindowObj in dhtmlwindow.tobjects) {
            if (window.dialog_onrefresh) { try { window.dialog_onrefresh(dhtmlwindow.tobjects[dhtmlwindowObj]) } catch (e) { ; }; }
        }
    },
    getLength: function() {
        var intL = 0;
        for (var dhtmlwindowObj in dhtmlwindow.tobjects) intL++;
        return intL;
    }
} 
window.attachEvent('onunload',dhtmlwindow.cleanup);
