//"ALL RIGHTS RESERVED (R) 2005 Onwards. CopyRight IRCA (INDIA) Pvt. Ltd."//
//Implements:Help;
var isIEX = (window.navigator.appName == "Microsoft Internet Explorer"); var string = '';
window.onerror=HandlePageError;__Alert=alert;window.onhelp=ShowHelp;
function isNull(checkObject){ return ((checkObject==null)||((checkObject)==window.undefined)); };
String.prototype.isEmpty = function(stringCheck) { if((typeof(stringCheck)==null)||(stringCheck==null)){ return true; } ; switch (typeof(stringCheck)){ case 'string': case 'number': break;  default: return true;break; };return (stringCheck+'').trim()==''; };
String.prototype.startsWith = function(strStart){ return this.toLowerCase().indexOf(strStart.toLowerCase())==0; };
String.prototype.endsWith = function(strEnd){ return this.toLowerCase().substr(this.length-strEnd.length,strEnd.length)==strEnd.toLowerCase(); };
String.prototype.Equals = function(toString) { var comp1str=this.trim();var comp2str=toString.trim(); return comp1str==comp2str; };
String.prototype.__replace=String.prototype.replace;
String.prototype.__replaceAll=function(strFnd,strRpl){ var returnThisString=this; try{ var regTmp=''; if(strFnd.__replace){ var strTmp=strFnd.__replace(/\*/g,"\\*"); strTmp=strFnd.__replace(/([.*+?$|(){}[\]\\])/g,'\\$1'); var regTmp= new RegExp(strTmp,"g");  }else{ regTmp=strFnd;}; returnThisString=this.__replace(regTmp,strRpl); }catch(e){ returnThisString=this; }finally{ return returnThisString; } };
function replace(strExp,strFnd,strRpl){ return strExp.__replaceAll(strFnd,strRpl); }
String.prototype.replacex=function(x1,x2){ return this.__replaceAll(x1,x2) };
String.prototype.replace=function(x1,x2){ return this.__replaceAll(x1,x2) };
String.prototype.repeat=function(n){ var s = "", t = this.toString(); while (--n >= 0) s += t ;return s;};
String.prototype.contains = function(txtSearch,checkCase) { if(checkCase){return this.indexOf(txtSearch)!=-1;}else{return this.toLowerCase().indexOf(txtSearch.toLowerCase())!=-1;} };
String.prototype.trim = function() { if (this=='')return ''; var x=this;	x=x.replace(/^\s*(.*)/, "$1"); x=x.replace(/(.*?)\s*$/, "$1");	return x; };
function indexOfarray(varray,strId){ var i; for(i=0;i<varray.length;i++){ if (varray[i]==strId){return i;};} }
function HashTable(){
    var items = new Array();var itemsN = new Array();this.items = items; _add.apply(this,arguments);
	function add(indxOrName,value){ try{ items[indxOrName+'']=value; itemsN.push(indxOrName); }catch(e){;}; }
    function remove(indxOrName){ try{ delete items[indxOrName+'']; delete itemsN[indexOfarray(itemsN,indxOrName)] }catch(e){;}; }
    this.getLength = function(){return itemsN.length};
   function _add(){
	    if(arguments.length==2 && arguments[1]==','){ var itms=arguments[0].split(','); for(var i in itms) add(itms[i],'');	    
	    }else{ for (var i = 0; i < arguments.length; i += 2) { if (typeof(arguments[i + 1]) != 'undefined') { add(arguments[i]+'',arguments[i + 1]); }; }; }
	};
    this.remove=function(indxOrName){
	    for (var i = 0; i < arguments.length; i++) { if (typeof(arguments[i]) != 'undefined') { remove(arguments[i]+''); }; }
    }
    this.get=function(indxOrName){ try{ return items[indxOrName+'']; }catch(e){;};}
    this.add=_add; this.set=_add;
    this.clear=function(){items= new Array(); itemsN = new Array();};
    this.contains=function(in_key){return typeof(items[in_key+'']) != 'undefined';};
    this.toString=function(){return itemstoString();
    function itemstoString(){ var retStr=[];for(var item in items){retStr.push(item + '=' + items[item]);};return retStr.toString(); }
   }
}
function trim(ToTrim) 
{
	Trimmed = ToTrim; if (Trimmed == null) return ("");
	while (Trimmed.substring(0,1) == ' ') Trimmed = Trimmed.substring(1, Trimmed.length);
	while (Trimmed.substring(Trimmed.length - 1, Trimmed.length) == ' ') Trimmed = Trimmed.substring(0, Trimmed.length - 1);
	return (Trimmed);
};
function _window_onload(){
    window.document.detachEvent('onreadystatechange',_window_onload);
    if(document.readyState=="complete"){
        if(window.docready){window.docready();}
    } else {
    if (isIEX) {
            window.document.attachEvent('onreadystatechange',_window_onload);
        } else {
            window.addEventListener('onreadystatechange', _window_onload, false);
        }
     }; 
}	
if(window.IRCAMAINOBJ){
    if(!window.IRCAMAIN || !window.IRCAMAIN.IRCAWind){
        window.IRCAMAIN=new IRCAMAINOBJ(); window.IRCAMAIN.IRCAWind=window.name;
        window.IRCA = new IRCAOBJ(null,null,true);//tell IRCAOBJ that this is main
        window.ircaObject=window.IRCA
    }
}else{
    if(!window.ircaObject ||!window.ircaObject.ThisPage){
        var IRCAMAINObject;
        if(!assignIrcaObject(window.parent)){
            if(!assignIrcaObject(window.opener)){
                if(!assignIrcaObject(window.dialogArguments)){
                    if(window.dialogArguments && !assignIrcaObject(window.dialogArguments[0])){
                       if(!assignIrcaObject(window.parent.parent)){
                            //failed tho tried hard
                       } 
                    }
                }
            }
        }
    }
};
function assignIrcaObject(windowObject){
    if(!windowObject){return}; var IRCAMAINObject;
    if(windowObject.IRCAMAIN)IRCAMAINObject=windowObject.IRCAMAIN;
    else if(windowObject.ircaObject) IRCAMAINObject=windowObject.ircaObject.ircaMain();
    if(!IRCAMAINObject){return}; window.ircaObject=IRCAMAINObject.getNewInstance(window);
    return true;
};
if (isIEX) {
    window.attachEvent('onload', _window_onload);
} else {
    window.addEventListener('onload', _window_onload, false);
}
var jsCRLF=String.fromCharCode(13,10);
function OpenWindow(argPath,argName,argStyle){
	if(!argStyle){ argStyle='fullscreen=no,directories=no,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,titlebar=no,toolbar=no';}
	return thisOpenWin(argPath,argName,argStyle);
}
var thisOpenWin = window.open;
window.open=OpenWindow;

function HandlePageError(errmsg,errpage,errlinenumber){
	var dtnow = new Date();
	var errstring = "Error Msg = " + errmsg + "\n Page Location = " + errpage + "\n" +
					"Document Ref = " + ThisPage() + "\n Error Date/Time = " + dtnow.toString()  + "\n" +
					"Error Line Number = " + errlinenumber + "\n Error Stack Trace = " + GetStackTrace(arguments.caller) + "\n\n\n" +
					"Please Contact Your System Administrator for Help"
	alert( errstring);
	return true;
}
function GetStackTrace(funcCaller){
	if (null == funcCaller)return "UnknownFunction";
	var strStackTrace = "";
	while(funcCaller != null && funcCaller.callee != null && funcCaller.caller != funcCaller){
		var strFunctionHeader = funcCaller.callee.toString();
		strFunctionHeader = strFunctionHeader.substring(9, strFunctionHeader.indexOf(")")+1);strStackTrace += strFunctionHeader + "; ";
		funcCaller = funcCaller.caller;	};
	return strStackTrace;
}
function ThisPage(thisdoc){
    if (!thisdoc){thisdoc=document}; var strpg;
    if (thisdoc.body){ strpg=thisdoc.body.ThisPage + ""; }
    if (strpg==""){
	    var strpg=thisdoc.URLUnencoded+""; var splstr=strpg.split("/");
	    if (splstr.length>0 ){strpg= splstr[splstr.length-1];}
    };return strpg;
};
function ShowHelp() {
   if(window.event){ event.keyCode = 0; event.cancelBubble = true; event.returnValue = false;}
   var curHelpTopicID = ''; try { curHelpTopicID = window.document.body.HelpTopicID;} catch (e) { ; };
   if (string.isEmpty(curHelpTopicID)) { curHelpTopicID = '' } else { curHelpTopicID = 'IRCAHLPTID' + curHelpTopicID };
   try {
       window.open("IS91HelpProvider.axd/" + curHelpTopicID, 'IRCAWebHelp', "fullscreen=0,height=400,width=700,left=150,top=150,directories=0,location=0,menubar=0,resizable=1,scrollbars=1,status=0,titlebar=0,toolbar=0");
   } catch (e) {
       window.showModelessDialog("IS91HelpProvider.axd/" + curHelpTopicID, window, 'status:0;help:0;resizable:1;');
   };
   return false;
}
function CreateslideMenu (id){
    var slMainDiv = document.getElementById(id);
    this.obj=function(){}; var sobj=this.obj;
    function itemOnclickHandler(){ 
        if(sobj.itemClickEvent){
            try{ sobj.itemClickEvent(this.id,this) }catch(e){;};
        };
        return false;
    };
    function grpOnclickHandler(){ 
        sobj.expandcollapse(this.parentElement.id,!isExpanded(this.parentElement));
        return false;
    };
    sobj.itemClickEvent=function(id, item){ return false; };
    sobj.expandcollapse=function(Grpid,boolexpand){
        var divHldrs= getAllDivsBySlAttr('hldr');
        for(var i=0;i<divHldrs.length;i++){
             var child=divHldrs[i];
             if(child.parentElement.id==Grpid){ child.style.display= (boolexpand==true?'':'none');
             }else{ child.style.display= 'none'; };
        }
    };
    function getAllDivsBySlAttr(SlAttr,forDiv){
        var rslt = new Array(); if(forDiv==null)forDiv=slMainDiv;
        var nodes=forDiv.getElementsByTagName('DIV');
        for(var i=0;i<nodes.length;i++){
             var child=nodes[i]; if(SlAttr=='' || child.slidemenuattr==SlAttr){ rslt.push(child); };
        }; return rslt;
    };
    function isExpanded(forGrpDiv){
        var d=getAllDivsBySlAttr('hldr',forGrpDiv);
        return (d[0]==null?false:(d[0].style.display==''));
    };
    function prepareslidemenu(){
        sobj.expandcollapse('0',false); var nodes=getAllDivsBySlAttr('');
        for(var i=0;i<nodes.length;i++){
            var child=nodes[i];
            switch(child.slidemenuattr){
                case "grplbl":
                    child.onclick=grpOnclickHandler;
                break;
                case "item":
                    child.onclick=itemOnclickHandler;
                break;
            };
        };
         document.detachEvent('onreadystatechange',init_slidemenu);
    };
    function init_slidemenu (){if(document.readyState=="complete")prepareslidemenu();};
    if (document.readyState == "complete") {
        prepareslidemenu()
    } else {
    if (isIEX) {
        document.attachEvent('onreadystatechange', init_slidemenu)
    }else
        window.addEventListener('onreadystatechange', init_slidemenu, false);
    }
    return this.obj;
};	
function removeRow(grdId,rwNo) {
    if (grdId){ var oGrid = igtbl_getGridById(grdId);
	    if (oGrid){ if (rwNo<0)return;
		    oGrid.Rows.remove(rwNo);
		    if (oGrid.Rows.length>0) oGrid.setActiveRow(oGrid.Rows.getRow(0).Id);
	    }
	    if(window.ircaObject){ircaObject.setObjectSrc('img_uwgDoc','APPRES.ashx/1664805296/nothumb.gif')};
	}
}
function removeAllRows(gridId){
    if (gridId){
	    var oGrid = igtbl_getGridById(gridId);
	    if (oGrid){
		    var ln=oGrid.Rows.length;
		    if (ln>0){
			    for(var i=ln;i>-1;i--){
				    oGrid.Rows.remove(i);
			    }
		    }
	    }
    }
}
function editRow(gridId,rowkey,isSeqEvnts){
    if (rowkey){
	    // deprecated by guru for Sequence of Events, since giving wrong numbers
	    if (isSeqEvnts){
		    var rwNo=parseInt(rowkey[1],10); // convert to int
	    }else{
		    var rwNo=getRowNo(gridId,rowkey[1],1);	
	    }
	    if (rwNo>-1){
		     var oGrid = igtbl_getGridById(gridId);
		    if (oGrid){
			    var rw
			    if(isSeqEvnts){
				    rw=oGrid.Rows.getRow(rwNo-1);
			    }else{
				    rw=oGrid.Rows.getRow(rwNo);
			    }
			    if (rw){
				    if(isSeqEvnts){rowkey[2]=rwNo+'';}
 				    for (var k=1;k<rowkey.length;k++)
 				    {
 					    rw.getCell(k).setValue(rowkey[k]);
 				    }
 			    }
		    }
	    }
    }
}
function addRow(gridId,rwArr,imgCell){ 
	if (rwArr){
		if (rwArr.length==0)return;
 		if (gridId){
			var NewRow=igtbl_addNew(gridId,0);
			//var NewRow=GridObj.Rows.addNew();
			if (NewRow){
				for (var xx=0;xx<rwArr.length;xx++){
						if(imgCell==xx){
							NewRow.cells[xx].getElement().innerHTML="<NOBR><IMG src=\"APPRES.ashx/1664805296/remove.gif\"></NOBR>"
							}
							else{
						        var isHtml=isTextHTML(rwArr[xx]);
						         NewRow.cells[xx].setValue(rwArr[xx],null,isHtml);
						         }
					} 
				NewRow.setSelected();	
		        igtbl_selectRow(gridId, NewRow.Element.id, true);
                igtbl_setActiveRow(gridId,NewRow.Element);
			}	
		}
	}  
} 
function setCheckRows(gridId,rowids,boolval){
	var oGrid=igtbl_getGridById(gridId);
	if (oGrid){
	    if (rowids==null){return;}
		if (rowids.length<1)return;
		for (var j=0;j<rowids.length;j++){
			for (var k=0;k<oGrid.Rows.length;k++){
				var rw=oGrid.Rows.getRow(k);
				if (rw){
					if (rw.getCell(1).getValue()==rowids[j]){	
						rw.getCell(0).setValue(boolval);
					}
				}
			}
		}
	}
}

function selectgridrow(gridId,rowid,colId){
    var oGrid=igtbl_getGridById(gridId);
	if (oGrid){
	        if (rowid==null){return;}
		    if (rowid.length<1)return;
		    if (colId==undefined){colId=1;}
		    if (colId==null){colId=1;}
 			for (var k=0;k<oGrid.Rows.length;k++){
				var rw=oGrid.Rows.getRow(k);
				if (rw){
					if (rw.getCell(colId).getValue()==rowid){	
						rw.setSelected();
						oGrid.setActiveRow(rw);
					}
				}
			}
	}
}
function getRowNo(gridName,idKey,colNo)
{
	if (idKey)
	{
		var oGrid=igtbl_getGridById(gridName);
		if (oGrid)
		{
			if (colNo==null)colNo=0;
 			for (var i=0;i<oGrid.Rows.length;i++)
			{
				var nDKey = oGrid.Rows.getRow(i).getCell(colNo).getValue();
				if(nDKey == idKey)
					return i;
					//oGrid.Rows.getRow(i).Id;
			}
		}
	}
	return "";
}
function getsText(strHTML){
   var onerrorfuncRef=window.onerror;
   window.onerror=function(){return true};
   try{
    var tmpDivObj = document.createElement('DIV');
    tmpDivObj.innerHTML = strHTML.replace('&sect', '& sect');
    if (tmpDivObj.innerHTML != '' && tmpDivObj.innerText == '') return tmpDivObj.innerHTML;
    return tmpDivObj.innerText.replace('& sect','&sect');
   }catch(r){
    return '';
   }finally{
    window.onerror=onerrorfuncRef;
   }
} 
function isTextHTML(strText){
    if(!strText){return false};
    try {
        var getsTextResultLength=getsText(strText).length;
        if (strText.length > 0 && getsTextResultLength == 0) return false;
    return (strText.length!=getsTextResultLength);
    }catch(r){return false};
}
function toHtml(myString) {
    var htmlString = myString.split("&lt;").join("<");
    htmlString = htmlString.split("&gt;").join(">");
    htmlString = htmlString.split("&quot;").join("\"");
    htmlString = htmlString.split("&apos;").join("\'");
    htmlString = htmlString.split("&amp;").join("&");
    return htmlString;
}
function FromHtml(myString) {
    var htmlString =myString.split("&").join("&amp;");
    htmlString = htmlString.split(">").join("&gt;");
    htmlString = htmlString.split("\"").join("&quot;");
    htmlString = htmlString.split("\'").join("&apos;");
    htmlString = htmlString.split("<").join("&lt;");
    return htmlString;
}
function calcRealHeight(obj){
    if(typeof obj != 'object'){return 0};
    var clH=obj.clientHeight;
    if(obj.scrollHeight>clH){
        clH= obj.scrollHeight;
    }
    return clH;
}
function calcRealWidth(obj){
    if(typeof obj != 'object'){return 0};
    var clW=obj.clientWidth;
    if(obj.scrollWidth>clW){
        clW= obj.scrollWidth;
    }
    return clW;
}
function dialogAutoResize(){
    if(window.resizeDialog && document.Form1){
        resizeDialog(document.Form1.offsetWidth,document.Form1.offsetHeight+50);
	}
}

function PartialLoadDiv(eventTarget,eventArgument,DivObj,useDirectResponse){
               // eventTarget, eventArgument,containerObj,useDirectResponse
    ircaObject.partialLoad(eventTarget,eventArgument,DivObj,useDirectResponse);
}

function addiwtNode(cntrlname,itmvalu,itmKey,itmXtraInfo,itmparentid,style,showToolTip,childIsExpanded,isCheckBox,strArgumentList)
{
	var tree = eval('o' + cntrlname);
	var node = tree.getNodeById(itmparentid);
	if(node) {
        //childNodeId,childNodeText,childNodeXtraInfo,childIsExpanded
		    node.add(itmKey,itmvalu,itmXtraInfo,childIsExpanded,style,showToolTip,isCheckBox);
		  var nd=tree.getNodeById(itmKey);
		  if (nd){
            if(!strArgumentList){return true};
		    var oArgsList= strArgumentList.split(ircaObject.splitStrB);
		    for (var i=0;i<oArgsList.length;i++){
		        var itemList=oArgsList[i].split(ircaObject.splitStrA);
		        nd._realNode.setAttribute(itemList[0]+'',itemList[1]+'');
		    }
		   } 
	}
}
function editiwtNode(cntrlname,nodeId,nodeText,nodeXtraiInfo,style,showToolTip,newNodeID)
{
	var tree = eval('o' + cntrlname);
	var node = tree.getNodeById(nodeId);
	if(node) {
        //childNodeId,childNodeText,childNodeXtraInfo,childIsExpanded
		    node.edit(nodeText,nodeXtraiInfo,style,showToolTip,newNodeID);
	}
}
function deliwtNode(cntrlname,itmid,reccursive){
	var tree = eval('o' + cntrlname);
	var node = tree.getNodeById(itmid);
    if(node) {
	    //if (node.getParent()){
		//   node.getParent().setSelected(true);
		    node.remove(reccursive);
      //  }
    }
}
function concatRowCols(gridName,colSep,rowSep){
        var strcolval="";
        var strRwVal="";
        var oGrid=igtbl_getGridById(gridName);
		if (oGrid){
		    for (var i=0;i<oGrid.Rows.length;i++){
		        for (var k=1;k<oGrid.Rows.getRow(i).cells.length;k++){
		            strcolval += oGrid.Rows.getRow(i).getCell(k).getValue()+colSep;
		        }
		        if(strcolval.length>0){
		            strcolval=strcolval.substring(0,strcolval.length-3);
		        }
		        strRwVal=strRwVal+strcolval+rowSep;
		        strcolval="";
		    }
			if(strRwVal.length>0){
			    strRwVal=strRwVal.substring(0,strRwVal.length-3);
			}
			return strRwVal;
		}

}

//Grid Server Sorting and Paging handler
function uwGrid_BeforeSortColumnHandler(gridName, columnId,pageNumber,sortordr){
	//Add code to handle your event here. // ASC or DESC //igtbl_getGridById(gridName).CurrentPageIndex
	try{
	    if(document.all[gridName+"_main"].disabled==true){
	        return false;
	    }
	}catch(ex){
	    return false;
	};
    mdisable(gridName+"_main");
	if(!window.sortConfig){ window.sortConfig=[]};
	var sortConfigGrid=window.sortConfig[gridName];
	if(!sortConfigGrid){
	    window.sortConfig[gridName]=[];sortConfigGrid=window.sortConfig[gridName];
	    sortConfigGrid['order']='ASC';sortConfigGrid['columnID']=columnId;
	    sortConfigGrid['imageASC']="&nbsp;<img src='APPRES.ashx/1664805296/ig_tblSortAsc.gif' border='0' imgType='sort'>";
	    sortConfigGrid['imageDESC']="&nbsp;<img src='APPRES.ashx/1664805296/ig_tblSortDesc.gif' border='0' imgType='sort'>";
	    sortConfigGrid['page']=eval('o'+gridName + '.CurrentPageIndex')||1;
	}else{
	    if(sortConfigGrid['order']=='ASC'){ 
	        sortConfigGrid['order']='DESC';
	    }else{
           sortConfigGrid['order']='ASC'; 
	    }
	}
	if(sortordr && (sortordr=='ASC'||sortordr=='DESC')){sortConfigGrid['order']=sortordr};
	if(pageNumber && parseInt(pageNumber)!=NaN){sortConfigGrid['page']=pageNumber};
    sortConfigGrid['columnNo']=igtbl_colNoFromColId(columnId);
//event
	try{
	    if(this.beforeColumnSort){this.beforeColumnSort(sortConfigGrid['columnNo'],sortConfigGrid['order'],sortConfigGrid['page'])};	
	}catch(e){};
	var submValue = '__GridSortColumnNo='+sortConfigGrid['columnNo'] +
	                '&__GridSortOrder=' + sortConfigGrid['order'] + '&' ;
    __doPostBack(gridName,'Page:'+sortConfigGrid['page'],submValue);
    eval("o"+gridName+".Bands[0].Columns["+sortConfigGrid['columnNo']+"].Element.innerHTML+=sortConfigGrid['image"+sortConfigGrid['order']+"']");
    eval('o'+gridName + '.CurrentPageIndex=' + sortConfigGrid['page']);
              
	return true;
}

function getXmlFileContent(xmlFile,async,reqErrStatusObj)
{
   try{
	var NewExeObjx=getRequestObject();
    NewExeObjx.open("GET",getUniqueUrl(xmlFile), async||false);
	NewExeObjx.setRequestHeader("IRCAAuth",window.vauth||'.');
	NewExeObjx.setRequestHeader("&param",'IRCA');
	NewExeObjx.send('');
	if (!reqErrStatusObj) reqErrStatusObj = new Object(); reqErrStatusObj.reqErrStatus = NewExeObjx.getResponseHeader("REQERRSTATUS") || '';
	if (NewExeObjx.status != 200) { return ''; }
    return NewExeObjx.responseText;
    }catch(e){return '';};
}

function getRequestObject(){
    
    if (window.XMLHttpRequest){
		return new window.XMLHttpRequest();
	}else{
        try{
            return new ActiveXObject("MSXML2.XMLHTTP");
        }catch(err){
            return new ActiveXObject("Microsoft.XMLHTTP");
        }
    }
};
function getUniqueUrl(strUrl){
   var dtsend= encodeURI(new Date().toString());
		if (strUrl.indexOf("?")>0)
			return strUrl+"&"+dtsend;
		else
			return strUrl+"?"+dtsend;
};

 function ReadDataFromXmlFile()
        {
            
            var xmlDoc=new ActiveXObject("MSXML2.DomDocument");
            xmlDoc.async=false;
            var boolLoaded=xmlDoc.load("/QbankEngine/dqmQuestion.xml");
            parseXML(xmlDoc.selectNodes("//parts/part"))
        }
        
        
        function parseXML(node)
        {
            
            for (var i=0;i<node.length;i++)
            {

             alert(node[i].childNodes[0].nodeTypedValue );
                
              for(var n=0;n<node[i].childNodes[1].childNodes.length;n++)
              {
              
                var str= node[i].childNodes[1].childNodes[n].attributes[0].nodeTypedValue ;
                str=str+ "  "+node[i].childNodes[1].childNodes[n].attributes[1].nodeTypedValue ;
                str =str+ "  "+node[i].childNodes[1].childNodes[n].attributes[2].nodeTypedValue ;
                str =str+ "  "+node[i].childNodes[1].childNodes[n].attributes[3].nodeTypedValue ;
                
                alert(str);
              }
           }
        }
        
        function CreateXmlFile(mainQuest,gridName)
        {
            
            var xmlDoc=new ActiveXObject("MSXML2.DomDocument");
            xmlDoc.async=false;
            //Load the Template XML
            var boolLoaded=xmlDoc.load("../QbankEngine/dqmQuestion.xml");
            
            if (boolLoaded)
            {
            
                var oGrid=igtbl_getGridById(gridName);
    		    
		        if (oGrid)
		        {
		                //Create a DOM object
                        var newXmlDoc=new ActiveXObject("MSXML2.DomDocument");
                        newXmlDoc.async=false;
                        newXmlDoc= xmlDoc;
            			
        			    //This is for checking Sub Question is Changed.
        			    var checkPartChange=oGrid.Rows.getRow(0).getCell(2).getValue();
            			
        			    var NodeClone=newXmlDoc.selectNodes("//parts/part").item(0);
        			    var SubNodeClone=newXmlDoc.selectNodes("//answerOptions").item(0);
            		
        			    var flag=true;
            			        
        			            //Text
				                NodeClone.firstChild.text=mainQuest;
            				    
				                //dqmq_pid
				                NodeClone.attributes[0].text="A";
            				    
				                //subQuestion
				                NodeClone.attributes[1].text="0"
				                //isRequired
				                NodeClone.attributes[2].text="True";
    				           
				               var counter=0;
				               var counterControl=0;
    				     
				         //flag is used becouse. For first time after clone no need for creating <control> tag to clone.
				         //So first time <control> is not cloned and after that next loop control is get cloned.     
    				       
        			    for (var i=0;i<oGrid.Rows.length;i++)
                        {
                            
                            if (checkPartChange != oGrid.Rows.getRow(i).getCell(2).getValue())
                            {
                                checkPartChange=oGrid.Rows.getRow(i).getCell(2).getValue();
                                newXmlDoc.childNodes[1].childNodes[0].childNodes[0].appendChild(NodeClone);
                                flag=true;
                            }
                            
                                if (flag==true)
                                {
                                    counter=counter+1;
                                    
        			                //Clone of the Part for Adding new Part.
				                    NodeClone=xmlDoc.selectNodes("//parts/part").item(0).cloneNode(true);
                                    //Text
				                    NodeClone.firstChild.text=oGrid.Rows.getRow(i).getCell(2).getValue();
                				    
				                    //dqmq_pid
				                    //String.fromCharCode(counter+65)= This will convert Ascii number to Charector
				                    NodeClone.attributes[0].text= String.fromCharCode(counter+65); 
                				    
				                    //subQuestion
				                    NodeClone.attributes[1].text=counter;
				                    //isRequired
				                    NodeClone.attributes[2].text=oGrid.Rows.getRow(i).getCell(5).getValue();
    				                
				                    SubNodeClone=NodeClone.selectNodes("//control").item(0);
				                    
				                    //Set Counter to zero for Control tags.
				                    counterControl=0;
                                }
                                
                              
                                if (flag==false)
                                {
                                 //Read Control From the Clone Node for Assigning Data
                                    SubNodeClone=NodeClone.selectNodes("//control").item(0).cloneNode(true);
                                }   
                                   flag=false;
                                    //class
                                    SubNodeClone.attributes[0].text=""
                                    //dqmq_cid, co
                                    //String.fromCharCode(counter+65)= This will convert Ascii number to Charector
				                    SubNodeClone.attributes[1].text="cntrl"+ String.fromCharCode(counter+65)+counterControl;
				                    counterControl++;
				                    //type
				                    SubNodeClone.attributes[2].text=oGrid.Rows.getRow(i).getCell(3).getValue();
				                    //labelText
				                    SubNodeClone.attributes[3].text=oGrid.Rows.getRow(i).getCell(4).getValue();
        				            //Append to the Existing one
				                    NodeClone.childNodes[1].appendChild(SubNodeClone);
                                
//                              }
//        				      else
//				              {
				                     
				                    
    				                
				               //} //End of Sub Question Check
        				    
				        } //End of Main For loop
				        
				            newXmlDoc.childNodes[1].childNodes[0].childNodes[0].appendChild(NodeClone);
    				          
    				        //Remove tag <control> from the First Node.
			                var NodeClone=newXmlDoc.selectNodes("//parts/part/answerOptions").item(0);
    			            var SubNodeClone=newXmlDoc.selectNodes("//control").item(0);
    			            NodeClone.removeChild(SubNodeClone);
    			            
			                //alert(newXmlDoc.xml);
			                
			                return newXmlDoc.xml 
		          }
		    }
        } //End of createXmlFile


function closeParent(){ 
	try{ 
		var op = window.opener;
	    if(op.ClsWinMe){
            op.ClsWinMe();return;	    
	    };
		op.opener = op.self; 
		op.close(); 
	}catch(er){} 
} 
function ClsWinMe(){
//    try{ 
	    var op = window.parent; 
	    op.opener = self; 
	    self.close(); 
//    }catch(er){} 
}
        
        //DATE CONTROL
        
        
var DTPoldval="";var attachedctl="";
calendar=null;
function DTPICKERshow(){
  attachedctl = window.event.srcElement.id;
  var el = document.getElementById(attachedctl+"D");
  if(el.disabled==true){return};
  if (calendar != null) {
    // we already have some calendar created
    calendar.hide();                 // so we hide it first.
  } else {
    // first-time call, create the calendar.
    initCalendar();
  }
  calendar.parseDate(el.value);      // try to parse the text in field
  calendar.sel = el;                 // inform it what input field we use
  calendar.showAtElement(el);        // show the calendar below it

  // catch "mousedown" on document
  Calendar.addEvent(document, "mousedown", checkCalendar);
  return false;
}
function initCalendar(mondayFirst,weekEnd1, weekEnd2) {
    // first-time call, create the calendar.
    var cal = new Calendar((mondayFirst==true), null, selected, closeHandler);
    calendar = cal;                  // remember it in the global var
    //cal.setRange(2000, 2070);        // min/max year allowed.
    if(weekEnd1!=null) cal.weekEnd1=weekEnd1;
    if(weekEnd2!=null) cal.weekEnd2=weekEnd2;
    //cal.setDateFormat(document.namespaces('IRCADTF').urn);    // set the specified date format
    cal.create();
}
// This function gets called when the end-user clicks on some date.
function selected(cal, date) {
  cal.sel.value = date; // just update the date in the input field.
  //if (cal.sel.id == "sel1" || cal.sel.id == "sel3")
    // if we add this call we close the calendar on single-click.
    // just to exemplify both cases, we are using this only for the 1st
    // and the 3rd field, while 2nd and 4th will still require double-click.
    cal.callCloseHandler();
}

// And this gets called when the end-user clicks on the _selected_ date,
// or clicks on the "Close" button.  It just hides the calendar without
// destroying it.
function closeHandler(cal) {
  cal.hide();                        // hide the calendar

  // don't check mousedown on document anymore (used to be able to hide the
  // calendar when someone clicks outside it, see the showCalendar function).
  Calendar.removeEvent(document, "mousedown", checkCalendar);
  if (calendar.onClose){ try{ calendar.onClose(); }catch(e){;} };
}

// This gets called when the user presses a mouse button anywhere in the
// document, if the calendar is shown.  If the click was outside the open
// calendar this function closes it.
function checkCalendar(ev) {
  var el = Calendar.is_ie ? Calendar.getElement(ev) : Calendar.getTargetElement(ev);
  for (; el != null; el = el.parentNode)
    // FIXME: allow end-user to click some link without closing the
    // calendar.  Good to see real-time stylesheet change :)
    if (el == calendar.element || el.tagName == "A") break;
  if (el == null) {
    // calls closeHandler which should hide the calendar.
    calendar.callCloseHandler();
    Calendar.stopEvent(ev);
  }
}
var MINUTE = 60 * 1000;
var HOUR = 60 * MINUTE;
var DAY = 24 * HOUR;
var WEEK = 7 * DAY;

function isDisabled(date) {
  var today = new Date();
  return (Math.abs(date.getTime() - today.getTime()) / DAY) > 10;
}
function isDate(DateToCheck){
	try{
	var arrDate = DateToCheck.split("/");var myDAY = arrDate[0];var myMONTH = arrDate[1];var myYEAR = arrDate[2];var strDate;
	strDate = myMONTH + "/" + myDAY + "/" + myYEAR;var testDate=new Date(strDate);
	if(testDate.getMonth()+1==myMONTH){return true;}else{return false;}
	}catch(e){return false};
}


function OnlyNumbers() {
if (window.event.keyCode < 48 || window.event.keyCode >57){
		window.event.keyCode =0;
}
}

function OnlyNumbersWithDec(val) {
	if (window.event.keyCode==46 && val.indexOf(".")<0)return;
	if (window.event.keyCode < 48 || window.event.keyCode >57){
			window.event.keyCode =0;
	 }
	}
var LWhandleM=null;var LWhandleK=null;var LCWhandleM=null; var LCWhandleK=null;var treecuritemid="";
function UnlockWin(PDOC,reqWind,tmptPagetype){
    if(!PDOC){PDOC=document}
    LockMode=false;Busy=false;
    if(tmptPagetype!='popup'){IRCAMAIN.AppLock(true)};
    window.onmousedown=LWhandleM;window.onmousedown=LWhandleK;
}
function mdisable(obj) {
	try{
		var thisdivtree=null;
		if (typeof(obj)=="object"){
		thisobj=obj;
		}else{
		thisobj=document.getElementById(obj);
		}
		if (!thisobj){return}
		try{thisobj.disabled=true;}catch(e){}
		if(thisobj.childNodes.length>0){
			endisChildObj(thisobj,true);
		}
	}catch(e){}
}

function menable(obj) {
	try{
		var thisobj=null;
		if (typeof(obj)=="object"){
			thisobj=obj;
		}else{
			thisobj=document.getElementById(obj);
		}
		if (!thisobj){return}
		try{thisobj.disabled=false;}catch(e){}
	if(thisobj.childNodes.length>0){
		endisChildObj(thisobj,false);
	}
	}catch(e){}	
}	

function endisChildObj(childobj,boolv){
	var iln=childobj.childNodes.length;
	if (iln!=0){
		var i = 0;
		while (i < iln){
			try{
				childobj.childNodes[i].disabled=boolv;
				endisChildObj(childobj.childNodes[i],boolv);
			}catch(ex){}
				
			i++;
		}
	}					
}	
//For Tab Control

var panes = new Array();

function setupPanes(containerId, defaultTabId,PaneNumber) {
  // go through the DOM, find each tab-container
  // set up the panes array with named panes
  // find the max height, set tab-panes to that height
  panes[containerId] = new Array();
  var maxHeight = 0; var maxWidth = 0;
  var container = document.getElementById(containerId);
//  var paneContainer = container.getElementsByTagName("div")[0];
// var paneList = paneContainer.childNodes;
  for (var i=1; i < parseInt(PaneNumber)+1; i++ ) {
    var pane = document.getElementById('panel' + i);
    //if (pane.nodeType != 1) continue;
//    if (pane.offsetHeight > maxHeight) maxHeight = pane.offsetHeight;
//    if (pane.offsetWidth  > maxWidth ) maxWidth  = pane.offsetWidth;
    panes[containerId][pane.id] = pane;
    pane.style.display = "none";
  }
//    paneContainer.style.height = maxHeight + "px";
//    paneContainer.style.width  = maxWidth + "px";
    document.getElementById(defaultTabId).onclick();
}

function showPane(paneId, activeTab) {
  // make tab active class
  // hide other panes (siblings)
  // make pane visible
  
    for (var con in panes) {
    activeTab.blur();
    activeTab.className = "tab-active";
    if (panes[con][paneId] != null) { // tab and pane are members of this container
      var pane = document.getElementById(paneId);
      pane.style.display = "block";
      var container = document.getElementById(con);
      var tabs = container.getElementsByTagName("ul")[0];
      var tabList = tabs.getElementsByTagName("a")
      for (var i=0; i<tabList.length; i++ ) {
        var tab = tabList[i];
        if (tab != activeTab) tab.className = "tab-disabled";
      }
      for (var i in panes[con]) {
        var pane = panes[con][i];
        if (pane == undefined) continue;
        if (pane.id == paneId) continue;
        pane.style.display = "none"
      }
    }
  }
  return false;    
}

//Popup Master Pages For Selection

function ShowMasterPopup(pgname,qry){
    try{
	    ircaObject.ircaMain().formNavigation(pgname +".aspx?"+qry,"",true,"popup",null,window);
    }catch(e){}
}
//to Check parent Node
function setCheckParent(nod,bvalu)
{
if (nod)
	{
		var bln=true;
		var nd=null;
		var nods=nod.getChildNodes();
		if (nods==null)return;
		if (nods.length==0)return;
		for (var i=0;i<nods.length;i++)
		{
			 	nd=nods[i];
			 	if(nd){
			 	    if (nd.getChecked()!=bvalu)
				    {
					    bln=false;		 
					    break;
				    }
				    //setCheckParent(nd,bvalu);
				}
		}
		if (bln)
			nod.setChecked(bvalu);
 		
 		
	}
 }
function ContainsAmp(val)
{
    if (val.indexOf('&') >= 0)
    {
      val = replace(val,'&','&amp;'); 
    } 
    return val;
}
 
function setSuggestValue(rw)
	{   
	    if(!rw){return};
	    var Selectedstr="";
	    for(i=0;i<=rw.cells.length-1;i++)
	    {
   		    Selectedstr =Selectedstr+ rw.getCell(i).getValue() +"|~|" ;
   		}
   		if(Selectedstr.length>3){Selectedstr=Selectedstr.substring(0,Selectedstr.length-3);}
   		
		//ircaObject.setObjectValue(window.controlName+"___userinput",ContainsAmp(rw.getCell(1).getValue()));
        //ircaObject.setObjectProp(window.controlName+"___userinput","title",null,ContainsAmp(Selectedstr));
        ircaObject.setObjectValue(window.controlName+"___userinput",rw.getCell(1).getValue());
        ircaObject.setObjectProp(window.controlName+"___userinput","title",null,Selectedstr);
        ircaObject.setObjectValue(window.controlName+"___Value",rw.getCell(0).getValue());
        if(window.onSelectPopupValue){onSelectPopupValue();}
    }
    
    function setSuggestMultiValue(arrRows)
	{   
	    if(!arrRows){return};
	    var Selectedstr="";
	    var vids="";
	    var rw;
	     for(k=0;k<arrRows.length;k++){
	        if(arrRows[k]){
	              rw=arrRows[k];
	              for(i=1;i<=rw.cells.length-1;i++){
   		            Selectedstr =Selectedstr+ rw.getCell(i).getValue() +"|~|" ;
   		          }
       		      if(Selectedstr.length>3){Selectedstr=Selectedstr.substring(0,Selectedstr.length-3);}
                  Selectedstr=Selectedstr+"|^|";
                   vids = vids + "," + rw.getCell(1).getValue();
             }  
         }
        if(Selectedstr.length>3){Selectedstr=Selectedstr.substring(0,Selectedstr.length-3);}
        if (vids.length > 0){vids = vids.substring(1);}
        //ircaObject.getObject(window.controlName+'___selectionDiv').innerHTML="";
        clearSuggestGrid(window.controlName);
        resetArray(vids);
	    AssDefaultValue(window.controlName+"___suggestholder",ContainsAmp(Selectedstr),2);
        ircaObject.setObjectValue(window.controlName+"___Value",vids);
    }
    
function XPAlert(obj,title,Msg,delay,iconX){
    if(getsText(Msg).length>200){alert(getsText(Msg),0,title);return};
    if(!iconX){iconX='Exclaim'};
    if(!window.JSBObj){window.JSBObj=new JSBalloon();};
    if(delay==-1||delay==0){
        JSBObj.autoAway=false;JSBObj.autoHide=false;
     //   ircaObject.ircaMain().windLock(document);
    }else{
        delay=(parseInt(delay,10) *1000);
        JSBObj.autoAway=true;JSBObj.autoHide=true;
        JSBObj.autoHideInterval=delay;
    };
	JSBObj.Show({title:String(title),message:String(Msg),
					    anchor:obj, icon:iconX});
}    


function Add2Lstbx(cntrl,sText,SValue,PDOC,StrOptionArgumentList){	
	if ((typeof(cntrl)!="object")&&(typeof(cntrl)!="string")||(sText==null)||(sText=="")){return false}
	if ((SValue==null)||(SValue=="")){SValue=sText}
	try{
		var oOption = PDOC.createElement("OPTION");
		if (typeof(cntrl)=="object"){
			cntrl.options.add(oOption);
		}else{
			PDOC.getElementById(cntrl).options.add(oOption);
		}
		var tmpArr=new Array();
		tmpArr=SValue.split(ircaObject.splitStrB);
		oOption.id= "id" + tmpArr[0];
		oOption.innerText = sText+"";
		oOption.value = SValue+"";
		if(!window.myRcat || !StrOptionArgumentList){return true};
		var oOptArgsList= StrOptionArgumentList.split(ircaObject.splitStrB);
		for (var item in oOptArgsList){
		    var itemList=item.split(myRcat.splitStrA);
		    oOption.setAttribute(itemList[0]+'',itemList[1]+'',0);
		}
		return true;
	}catch(ex){
		return false;
	}
}
function Edit2Lstbx(cntrl,sText,SValue,PDOC,StrOptionArgumentList){	
	if ((typeof(cntrl)!="object")&&(typeof(cntrl)!="string")||(sText==null)||(sText=="")){return false}

	var sIndex="",i;
	var tmpArr=new Array();

	try{
	
		tmpArr=SValue.split(ircaObject.splitStrB);
		sIndex="id"+tmpArr[0];

		PDOC.getElementById(cntrl).options(sIndex).innerText=sText;
		PDOC.getElementById(cntrl).options(sIndex).value=SValue;

		if(!window.myRcat || !StrOptionArgumentList){return true};
		var oOptArgsList= StrOptionArgumentList.split(ircaObject.splitStrB);
		for (var item in oOptArgsList){
		    var itemList=item.split(myRcat.splitStrA);
		    oOption.setAttribute(itemList[0]+'',itemList[1]+'',0);
		}
			
	}catch(ex){
		return false;
	}
	
	return true;
}
function Remove2Lstbx(cntrl,sVar,PDOC){	
	if ((typeof(cntrl)!="object")&&(typeof(cntrl)!="string")||(sVar==null)){return false}
	if (typeof(sVar)!="string"){return}
	
	var tmpcntrl=null;
	var tmpArr=new Array();
	var sIndex="";
	
	if (typeof(cntrl)=="object"){
		tmpcntrl=cntrl;
	}else{
		tmpcntrl=PDOC.getElementById(cntrl);
	}


	try{
		tmpArr=sVar.split(ircaObject.splitStrB);
		sIndex="id"+tmpArr[0];
		var delopt=tmpcntrl.options(sIndex);
		tmpcntrl.options.removeChild(delopt);
		return true;
	}catch(ex){
		return false;
	}
}
//TIME CONTROL
/*Get Current Time*/
function getCaretPosition(objTextBox){ 
    var i = objTextBox.value.length+1; 
    if (objTextBox.createTextRange){ 
            objCaret = document.selection.createRange().duplicate(); 
            while (objCaret.parentElement()==objTextBox && objCaret.move("character",1)==1){
                i--;
            }
    } 
    return i; 
} 

function hr_onkeypress(hrcntrl) {
if(hrcntrl.readOnly==true)return;
	OnlyNumbers();
	var cp=getCaretPosition(hrcntrl);
		
	if (cp==2 && parseInt(hrcntrl.value,10)>1 && window.event.keyCode >51)window.event.keyCode =0;
	if (cp==2 && parseInt(hrcntrl.value,10)>2 )window.event.keyCode =0;
	if (cp==1 && parseInt(hrcntrl.value,10)<4 && window.event.keyCode <51)return;
	if (cp==1 && parseInt(hrcntrl.value,10)>1 && window.event.keyCode >49)window.event.keyCode =0;
}

function mi_onkeypress(mncntrl) {
if(mncntrl.readOnly==true)return;
	OnlyNumbers();
	var cp=getCaretPosition(mncntrl);
		
	if (cp==2 && parseInt(mncntrl.value,10)>4 && window.event.keyCode >57)window.event.keyCode =0;
	if (cp==2 && parseInt(mncntrl.value,10)>5 )window.event.keyCode =0;
	if (cp==1 &&  window.event.keyCode <54)return;  
	if (cp==1 && parseInt(mncntrl.value,10)>5 && window.event.keyCode >53)window.event.keyCode =0;
	
}

function hr_onkeydown(hrcntrl) {
if(hrcntrl.readOnly==true)return;
	if (window.event.keyCode==40)
	{	var intsc=parseInt(hrcntrl.value,10);
		if (intsc>0){
			intsc-=1;hrcntrl.value=hrcntrl.value.length>1?hrcntrl.value.substring(0,1)=="0"?"0"+intsc:intsc:intsc;
		}else{
			hrcntrl.value=23;
		}
	}
	if (window.event.keyCode==38)
	{	var intsc=parseInt(hrcntrl.value,10) ;
		if (intsc<23){
			intsc++;hrcntrl.value=hrcntrl.value.length>1?hrcntrl.value.substring(0,1)=="0"?"0"+intsc:intsc:intsc;
		}else{
			intsc=0;hrcntrl.value=hrcntrl.value.length>1?hrcntrl.value.substring(0,1)=="0"?"0"+intsc:intsc:intsc;
		}
	}
	if(hrcntrl.value.length>2 && hrcntrl.value.substring(0,1)=="0"){hrcntrl.value=hrcntrl.value.substring(1,hrcntrl.value.length)}
}
function mi_onkeydown(mncntrl) {
if(mncntrl.readOnly==true)return;
	if (window.event.keyCode==40)
	{	var intsc=parseInt(mncntrl.value,10);
		if (intsc>0){
			intsc-=1;mncntrl.value=mncntrl.value.length>1?mncntrl.value.substring(0,1)=="0"?"0"+intsc:intsc:intsc;
		}else{
			mncntrl.value=59;
		}
	}
	if (window.event.keyCode==38)
	{	var intsc=parseInt(mncntrl.value,10) ;
		if (intsc<59){
			intsc++;mncntrl.value=mncntrl.value.length>1?mncntrl.value.substring(0,1)=="0"?"0"+intsc:intsc:intsc;
		}else{
			intsc=0;mncntrl.value=mncntrl.value.length>1?mncntrl.value.substring(0,1)=="0"?"0"+intsc:intsc:intsc;
		}
	}
	if(mncntrl.value.length>2 && mncntrl.value.substring(0,1)=="0"){mncntrl.value=mncntrl.value.substring(1,mncntrl.value.length)}
}

function hr_onfocus(hrcntrl) {
	hrcntrl.select();
}
function mi_onfocus(mncntrl) {
	mncntrl.select();
}
function TimeControl(divn){
    if((document.getElementById(divn+"_hr"))&&(document.getElementById(divn+"_mi"))){return}
	var dvnm=" <INPUT readonly language='javascript' onpaste='return false;' onbeforepaste='return false;' onkeypress='return hr_onkeypress(this);' IRCAType id='" + divn + "_hr' onkeydown='return hr_onkeydown(this);'" +
				" style='WIDTH: 16px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 16px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: right; BORDER-BOTTOM-STYLE: none'" +
				" onfocus='return hr_onfocus(this);' type='text' maxLength='2' size='1' name='hr' value='00'>:<INPUT readonly language='javascript' onkeypress='return mi_onkeypress(this);' IRCAType id='" + divn + "_mi' onkeydown='return mi_onkeydown(this);'" +
				" style='WIDTH: 16px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 16px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: right; BORDER-BOTTOM-STYLE: none;'" +
				" type='text' maxLength='2' size='1' name='" + divn + "_mi' value='00' onfocus='return mi_onfocus(this);'>";
		document.getElementById(divn).innerHTML=dvnm;
}
function EnableTimeControl(divn){try{if(document.getElementById(divn+"_hr"))document.getElementById(divn+"_hr").readOnly=false;if(document.getElementById(divn+"_mi"))document.getElementById(divn+"_mi").readOnly=false;}catch(e){}}
function setTime(divn,tm){
TimeControl(divn);
	if (divn!=null)
	{
		if (tm!=null)
		{
			var hArr=tm.split(":");
			if (hArr!=null)
			{
				document.getElementById(divn + "_hr").value=hArr[0];
				
				document.getElementById(divn + "_mi").value=hArr[1];
			}
		}
	}
}
function getTime(divn){
TimeControl(divn);
	if (divn!=null){
		var hrv=document.getElementById(divn + "_hr").value;
		var miv = document.getElementById(divn + "_mi").value;
		return hrv+":" +miv;
			
	}
}
window.isPopup=false;
