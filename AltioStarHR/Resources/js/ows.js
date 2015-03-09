function _browseris(){
    this.ie4up=true;
    this.win32=true;
    this.ie5up=true;
    this.ie55up=true;
}
browseris = new _browseris();
function OWSForm(stName, fUseDHTMLOverride, stPagePath){
	this.stName = stName;
	this.stFieldPrefix = "urn:schemas-microsoft-com:office:office#";
	this.dopt = new DateOptions;
	this.nopt = new NumberOptions;
	this.fUseDHTML = browseris.ie4up && browseris.win32;
	if (!fUseDHTMLOverride)
			this.fUseDHTML = false;
	this.ifldMax = 0;
	this.rgfld = new Array;
	this.stError = "";
	this.stImagesPath = "";
	this.stPagePath = stPagePath;// + L_Language_Text+"/";
	//this.dp = new DatePicker(this);
	this.stInputStyle = ((browseris.ie4up && browseris.win32) || browseris.nav6up) ? "CLASS=ms-input" : "";
	this.stLongStyle = ((browseris.ie4up && browseris.win32) || browseris.nav6up) ? "CLASS=ms-long" : "";
	this.fPreviewMode = false;
	if (document[this.stName])
		document[this.stName].onsubmit = FrmOnSubmitRetFalse; 
	this.form = null;
	//this.themeCSSurl = retrieveCurrentThemeLink();
	frmCurrent = this;
}
OWSForm.prototype.AddField = FrmAddField;
function FrmAddField(fld, stName, stDisplay, stValue){
	this.rgfld[this.ifldMax++] = fld;
	fld.frm = this;
	fld.stName = stName;
	fld.stDisplay = stDisplay;
	fld.stValue = stValue;
	fld.fRequired = false;
	fld.stError = "";
	fld.stAttributes = "";
	fld.fCalcCheck = false;
}
OWSForm.prototype.DataBind = function(){};
OWSForm.prototype.FindField = FrmFindField;
function FrmFindField(stField){
	var fld;
	for (ifld = 0; ifld < this.ifldMax; ifld++)
		{
		fld = this.rgfld[ifld];
		if (fld.stName == stField)
			return fld;
		}
	return null;
}
OWSForm.prototype.ValidateAndSubmit = function(){};
OWSForm.prototype.FValidate = function(){};
OWSForm.prototype.FPostProcess = function(){};
OWSForm.prototype.SetFirstFocus = function(){};
OWSForm.prototype.InitFormFields = function(){};
OWSForm.prototype.BuildFieldUI = FrmBuildFieldUI;
function FrmBuildFieldUI(fld, st){
	document.write(st);
}
OWSForm.prototype.StFieldPost = function(){};
OWSForm.prototype.FieldPost = FrmFieldPost;
function FrmFieldPost(fld){
    if (this.form == null)
		this.form = document[this.stName];
	return this.form[this.stFieldPrefix + fld.stName];
}
OWSForm.prototype.FilenameFieldPost = function(){};
OWSForm.prototype.StFieldSubPart = function(){};
OWSForm.prototype.FieldSubPart = FrmFieldSubPart;
function FrmFieldSubPart(fld, stPart){
    if (this.form == null)
		this.form = document[this.stName];
	return this.form[this.StFieldName(fld, stPart)];
}
OWSForm.prototype.StFieldName = FrmStFieldName;
function FrmStFieldName(fld, stPart){
	return this.StFieldNameFactory(fld.stName, stPart);
}
OWSForm.prototype.StFieldNameFactory = FrmStFieldNameFactory;
function FrmStFieldNameFactory(name, stPart){
	return "OWS:" + name + ":" + stPart;
}
OWSForm.prototype.GetSelValue = function(){};
OWSForm.prototype.TestURL = function(){};
OWSForm.prototype.SetRadioValue = function(){};
OWSForm.prototype.RevertSelect = function(){};
OWSForm.prototype.SetFillInButton = FormSetFillInButton;
function FormSetFillInButton(stName){
    if (event != null)
    {
        var charCode;
        if (browseris.ie)
            charCode = event.keyCode;
        else
            charCode = event.which;
        if (charCode == 9 || charCode == 16)
            return;
    }
	var fld = this.FindField(stName);
    fld.SetFillInButton();
}
OWSForm.prototype.UnsetFillInButton = FormUnsetFillInButton;
function FormUnsetFillInButton(stName){
	var fld = this.FindField(stName);
	fld.UnsetFillInButton();
}
function DateOptions(){}
function NumberOptions(){}
function RichTextField(frm, stName, stDisplay, stValue){
	frm.AddField(this, stName, stDisplay, stValue);
	this.stDirection = ""; this.WebLocale = "1033";
	this.stNumLines = "10";this.IMEMode="";
	this.fAllowHyperlink = false;
}
RichTextField.prototype.FieldFocus = RichTextFieldFieldFocus;
function RichTextFieldFieldFocus(){
   if (browseris.ie5up){
      RTE_GiveEditorFirstFocus(this.frm.stFieldPrefix + this.stName);
      return true;
   }else{
      return NoteFieldFieldFocusCore(this);
   }
}
RichTextField.prototype.BuildUI = RichTextFieldBuildUI;
function RichTextFieldBuildUI(docwrite,elem){
   var st = "";if(typeof elem !='object')return;
   var L_strRichTextSupport_Text = "You may add HTML formatting. Click <a href= 'javascript:HelpWindowKey(\"nsrichtext\")'>here</a> for more information.";
   st += NoteFieldBuildUICore(this,docwrite);
   if(docwrite==false)elem.innerHTML = st;
   if (browseris.ie5up && browseris.win32){
   	RTE_ConvertTextAreaToRichEdit(
   	      this.frm.stFieldPrefix + this.stName,
   	      true,
   	      false,
   	      this.stDirection,
   	      L_Language_Text);
   }else{ 
      st += "&nbsp;<br><SPAN class=ms-formdescription>" + L_strRichTextSupport_Text + "</SPAN>&nbsp;<br>";
      if(docwrite==false)
        return st;
      else
        document.write(st);
   }
}
RichTextField.prototype.DataBind = function(){};
RichTextField.prototype.FValidate = function(){};
function NoteFieldBuildUICore(fld,docwrite){
	var st = "";
    st += "<TEXTAREA class='ms-'" + FormTabIndex() + " COLS=\"30\""
        + " ROWS="+StAttrQuote(fld.stNumLines)
        + " TITLE="+StAttrQuote(fld.stDisplay)
        + " Name="+StAttrQuote(fld.frm.stFieldPrefix+fld.stName)
        + " "+fld.frm.stLongStyle;
    st += fld.IMEMode ? " style=\"ime-mode:" + fld.IMEMode + "\" " : ""
    st += " >";
    st += STSHtmlEncode(fld.stValue);
    st += "</TEXTAREA>";
    if(docwrite==false)
        return st;
    else
	    fld.frm.BuildFieldUI(fld, st);
}
var L_Language_Text="";var L_CutToolTip_TEXT = "Cut";var L_CopyToolTip_TEXT = "Copy";var L_PasteToolTip_TEXT = "Paste";var L_BoldToolTip_TEXT = "Bold";var L_ItalicToolTip_TEXT = "Italic";var L_UnderlineToolTip_TEXT = "Underline";var L_JustifyLeftToolTip_TEXT = "Align Left";var L_JustifyCenterToolTip_TEXT = "Center";var L_JustifyRightToolTip_TEXT = "Align Right";var L_OrderedListToolTip_TEXT = "Numbered List";var L_UnorderedListToolTip_TEXT = "Bulletted List";var L_OutdentToolTip_TEXT = "Decrease Indent";var L_IndentToolTip_TEXT = "Increase Indent";var L_ForeColorToolTip_TEXT = "Text Color";var L_BackColorToolTip_TEXT = "Background Color";var L_LTRToolTip_TEXT = "Left-to-Right";var L_RTLToolTip_TEXT = "Right-to-Left";var L_CreateLinkToolTip_TEXT = "Insert Hyperlink";var L_InsertImageToolTip_TEXT = "Insert Image";var L_FontNameLabel_TEXT = "Font";var L_FontNameToolTip_TEXT = "Font";var L_FontSizeLabel_TEXT	 = "Size";var L_FontSizeToolTip_TEXT = "Font Size";var L_ExampleText_TEXT = "Example Text";var L_EditorIFrameTitle_TEXT = "Rich Text Editor";var L_Black_TEXT = "Black";var L_Brown_TEXT = "Brown";var L_OliveGreen_TEXT = "Olive Green";var L_DarkGreen_TEXT = "Dark Green";var L_DarkTeal_TEXT = "Dark Teal";var L_DarkBlue_TEXT = "Dark Blue";var L_Indigo_TEXT = "Indigo";
var L_Gray80_TEXT = "Gray 80%";var L_DarkRed_TEXT = "Dark Red";var L_Orange_TEXT = "Orange";var L_DarkYellow_TEXT = "Dark Yellow";var L_Green_TEXT = "Green";var L_Teal_TEXT = "Teal";var L_Blue_TEXT = "Blue";var L_BlueGray_TEXT = "Blue Gray";var L_Gray50_TEXT = "Gray 50%";var L_Red_TEXT = "Red";var L_LightOrange_TEXT = "Light Orange";var L_Lime_TEXT = "Lime";var L_SeaGreen_TEXT = "Sea Green";var L_Aqua_TEXT = "Aqua";var L_LightBlue_TEXT = "Light Blue";var L_Violet_TEXT = "Violet";var L_Gray40_TEXT = "Gray 40%";var L_Pink_TEXT = "Pink";var L_Gold_TEXT = "Gold";var L_Yellow_TEXT = "Yellow";var L_BrightGreen_TEXT = "Bright Green";var L_Turquoise_TEXT = "Turquoise";var L_SkyBlue_TEXT = "Sky Blue";var L_Plum_TEXT = "Plum";var L_Gray25_TEXT = "Gray 25%";var L_Rose_TEXT = "Rose";var L_Tan_TEXT = "Tan";var L_LightYellow_TEXT = "Light Yellow";var L_LightGreen_TEXT = "Light Green";var L_LightTurquoise_TEXT = "Light Turquoise";var L_PaleBlue_TEXT = "Pale Blue";var L_Lavender_TEXT = "Lavender";var L_White_TEXT = "White";var L_Font1_TEXT = "Arial";var L_Font2_TEXT = "Arial";var L_Font3_TEXT = "Arial";var L_Font4_TEXT = "Arial";var L_Font5_TEXT = "Arial";var L_Font6_TEXT = "";var L_Font7_TEXT = "";var L_Font8_TEXT = "";var L_BoldKey_TEXT = "B"; var L_BoldShiftKey_TEXT = "false"; 
var L_BoldAltKey_TEXT = "false"; var L_ItalicKey_TEXT = "I"; var L_ItalicShiftKey_TEXT = "false"; var L_ItalicAltKey_TEXT = "false"; var L_UnderlineKey_TEXT = "U"; var L_UnderlineShiftKey_TEXT = "false"; var L_UnderlineAltKey_TEXT = "false"; var L_JustifyLeftKey_TEXT = "L"; var L_JustifyLeftShiftKey_TEXT = "false"; var L_JustifyLeftAltKey_TEXT = "false"; var L_JustifyCenterKey_TEXT = "E"; var L_JustifyCenterShiftKey_TEXT = "false"; var L_JustifyCenterAltKey_TEXT = "false"; var L_JustifyRightKey_TEXT = "R"; var L_JustifyRightShiftKey_TEXT = "false"; var L_JustifyRightAltKey_TEXT = "false"; var L_SelectFontNameKey_TEXT = "F"; var L_SelectFontNameShiftKey_TEXT = "true"; var L_SelectFontNameAltKey_TEXT = "false"; var L_SelectFontSizeKey_TEXT = "P"; var L_SelectFontSizeShiftKey_TEXT = "true"; var L_SelectFontSizeAltKey_TEXT = "false"; var L_OutdentKey_TEXT = "M"; var L_OutdentShiftKey_TEXT = "true"; var L_OutdentAltKey_TEXT = "false"; var L_IndentKey_TEXT = "M"; var L_IndentShiftKey_TEXT = "false"; var L_IndentAltKey_TEXT = "false"; var L_UnorderedListKey_TEXT = "L"; var L_UnorderedListShiftKey_TEXT = "true"; var L_UnorderedListAltKey_TEXT = "false"; var L_OrderedListKey_TEXT = "E"; var L_OrderedListShiftKey_TEXT = "true"; var L_OrderedListAltKey_TEXT = "false"; 
var L_CreateLinkKey_TEXT = "K"; var L_CreateLinkShiftKey_TEXT = "false"; var L_CreateLinkAltKey_TEXT = "false"; var L_SelectForeColorKey_TEXT = "C"; var L_SelectForeColorShiftKey_TEXT = "true"; var L_SelectForeColorAltKey_TEXT = "false"; var L_SelectBackColorKey_TEXT = "W"; var L_SelectBackColorShiftKey_TEXT = "true"; var L_SelectBackColorAltKey_TEXT = "false"; var L_InsertImageKey_TEXT = "G"; var L_InsertImageShiftKey_TEXT = "true"; var L_InsertImageAltKey_TEXT = "false"; var L_LTRKey_VALUE = 190; var L_RTLKey_VALUE = 188; var g_strRTEUnselectedClassName = "ms-rtetoolbarunsel";var g_strRTESelectedClassName = "ms-rtetoolbarsel";var g_strRTEDisabledClassName = "ms-rtetoolbardis";var g_strRTEHoverClassName = "ms-rtetoolbarhov";var g_strRTETextEditorPullDownMenuID = "RTETextEditorPullDownMenu";var g_strRTEDialogHelperID = "RTEDialogHelper";var g_strRTECutMnemonic = "Cut";var g_strRTECopyMnemonic = "Copy";var g_strRTEPasteMnemonic = "Paste";var g_strRTEFontNameMnemonic = "FontName";var g_strRTEFontSizeMnemonic = "FontSize";var g_strRTEBoldMnemonic = "Bold";var g_strRTEItalicMnemonic = "Italic";var g_strRTEUnderlineMnemonic = "Underline";var g_strRTEJustifyLeftMnemonic = "JustifyLeft";var g_strRTEJustifyCenterMnemonic = "JustifyCenter";var g_strRTEJustifyRightMnemonic = "JustifyRight";
var g_strRTEOrderedListMnemonic = "InsertOrderedList";var g_strRTEUnorderedListMnemonic = "InsertUnorderedList";var g_strRTEOutdentMnemonic = "Outdent";var g_strRTEIndentMnemonic = "Indent";var g_strRTEForeColorMnemonic = "ForeColor";var g_strRTEBackColorMnemonic = "BackColor";var g_strRTELTRMnemonic = "LTR";var g_strRTERTLMnemonic = "RTL";var g_strRTECreateLinkMnemonic = "CreateLink";var g_strRTEInsertImageMnemonic = "InsertImage";var g_strRTERestrictedModeAttributeName = "RestrictedMode";var g_strRTEAllowHyperlinkAttributeName = "AllowHyperlink";var g_strRTEBaseElementIDAttributeName = "BaseElementID";var g_strRTEWebLocaleAttributeName = "WebLocale";var g_strRTEButtonMnemonicAttributeName = "ButtonMnemonic";var g_strRTECommandToExecuteAttributeName = "CommandToExecute";var g_strRTECommandValueAttributeName = "CommandValue";var g_strRTEMenuItemBaseName = "MenuItem";var g_strRTEMenuItemAttributeName = "MenuItem";var g_strRTEMenuOpeningAttributeName = "MenuOpening";var g_strRTEMenuTableElementName = "MenuTable";var g_strRTEBegBoldItalicToken = "%BEGBI%";var g_strRTEEndBoldItalicToken = "%ENDBI%";var g_strRTEFontNameToken = "%FONTNAME%";var g_strRTEFontSizeToken = "%FONTSIZE%";var g_ntRTEElement = 1;var g_ntRTEText = 3;var g_iLineHeight = 14;
var g_rgstRTETextEditorSelectionType = new Array();
var g_rgrngRTETextEditorSelection = new Array();
function RTE_SaveSelection(strBaseElementID){
	var docEditor = RTE_GetEditorDocument(strBaseElementID);
	g_rgrngRTETextEditorSelection[strBaseElementID] = docEditor.selection.createRange();
	g_rgstRTETextEditorSelectionType[strBaseElementID] = docEditor.selection.type;
}
function RTE_RestoreSelection(strBaseElementID){
	var sel = g_rgrngRTETextEditorSelection[strBaseElementID];
	if (null != sel){
		sel.select();
	}
}
function RTE_GetSelection(strBaseElementID){
	return g_rgrngRTETextEditorSelection[strBaseElementID];
}
var g_elemRTELastTextAreaConverted = null;var g_strRTETextEditorWithTheFocus = null;
var g_strRTEPrevTextEditor = null;var g_strRTEEditorFirstFocus = null;
var g_rgstrRTEAllEditorsInThePage = new Array();var g_fRTEDialogIsOpen = false;
function RTE_GetEditorIFrameID(strBaseElementID){
	return strBaseElementID + "_iframe";
}
function RTE_GetEditorTextArea(strBaseElementID){
	var elemTextArea = document.getElementById(strBaseElementID);
	return elemTextArea;
}
function RTE_GetEditorIFrame(strBaseElementID){
	var ifmEditor = null;
	if ((null != document.frames) && (document.frames.length > 0)){
		var ifmContainer = document.getElementById(RTE_GetEditorIFrameID(strBaseElementID));
		if (ifmContainer != null){
		   	ifmEditor = document.frames(RTE_GetEditorIFrameID(strBaseElementID));
		}
	}
	return ifmEditor;
}
function RTE_GetEditorElement(strBaseElementID){
	var elemEditorIFrame = document.getElementById(RTE_GetEditorIFrameID(strBaseElementID));
	return elemEditorIFrame;
}
function RTE_GetEditorDocument(strBaseElementID){
	var ifmEditor = RTE_GetEditorIFrame(strBaseElementID);
	if (null == ifmEditor){
		return null;
	}
	var docEditor = ifmEditor.document;
	return docEditor;
}
function RTE_GetWebLocale(strBaseElementID){
	return RTE_GetEditorDocument(strBaseElementID).body.getAttribute(g_strRTEWebLocaleAttributeName);
}
function RTE_IsInRestrictedMode(strBaseElementID){
	var docEditor = RTE_GetEditorDocument(strBaseElementID);
	if (null != docEditor.body.getAttribute(g_strRTERestrictedModeAttributeName)){
		return true;
	}
	return false;
}
function RTE_IsHyperlinkAllowed(strBaseElementID){
	var docEditor = RTE_GetEditorDocument(strBaseElementID);
	if (null != docEditor.body.getAttribute(g_strRTEAllowHyperlinkAttributeName)){
		return true;
	}
	return false;
}
function RTE_ShouldShowDirection(){
	return true;
}
function RTE_EditorWithTheFocus(){
	return g_strRTETextEditorWithTheFocus;
}
function RTE_PrevEditor(){
	return g_strRTEPrevTextEditor;
}
function RTE_GetRichEditTextOnly(strBaseElementID){
	return RTE_GetEditorDocument(strBaseElementID).body.innerText;
}
function RTE_GiveEditorFocus(strBaseElementID){
	RTE_GetEditorIFrame(strBaseElementID).focus();
}
function RTE_GiveEditorFirstFocus(strBaseElementID){
	RTE_GetEditorIFrame(strBaseElementID).focus();
	g_strRTEEditorFirstFocus = strBaseElementID;
}
function RTE_ConvertTextAreaToRichEdit(
            strBaseElementID,
            fRestrictedMode,
            fAllowHyperlink,
            strDirection,
            strWebLocale){
	;
	if (!(browseris.ie5up && browseris.win32)){
		return;
	}
	var elemTextArea = RTE_GetEditorTextArea(strBaseElementID);
	var strHtmlToEdit = elemTextArea.innerText;
	if ((null == strHtmlToEdit) || (0 == strHtmlToEdit.length)){
		strHtmlToEdit = "<div style=\"width:100%;height:100%\" ></div>";
	}
	g_elemRTELastTextAreaConverted = elemTextArea;
	window.attachEvent("onload", new Function("RTE_TextAreaWindow_OnLoad('" + strBaseElementID + "');"));
	var strHtmlToAppend = "";
	strHtmlToAppend += RTE_GenerateToolBarHtml(strBaseElementID, strWebLocale, elemTextArea, fRestrictedMode, fAllowHyperlink);
	strHtmlToAppend += RTE_GenerateIFrameEditorHtml(strBaseElementID, elemTextArea, fRestrictedMode, fAllowHyperlink);
	elemTextArea.insertAdjacentHTML("afterEnd", strHtmlToAppend);
	elemTextArea.onfocus = new Function("RTE_TextArea_OnFocus('" + strBaseElementID + "')");
	elemTextArea.style.display = "none";
	window.attachEvent("onbeforeunload", new Function("RTE_TransferIFrameContentsToTextArea('" + strBaseElementID + "');"));
	var strEditorHtml = "<html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"";
	strEditorHtml += RTE_GetServerRelativeStylesheetUrl("ows.css", strWebLocale);
	strEditorHtml += "\"></head><body class=\"ms-formbody\" style=\"border: 1px solid black; margin: 1px;\">";
    strEditorHtml += strHtmlToEdit;
	strEditorHtml += "</body></html>";
	var docEditor = RTE_GetEditorDocument(strBaseElementID);
	docEditor.designMode = "on";
	docEditor = RTE_GetEditorDocument(strBaseElementID);
	docEditor.open("text/html", "replace");
	docEditor.write(strEditorHtml);
	docEditor.close();
	docEditor = RTE_GetEditorDocument(strBaseElementID);
	docEditor.body.scroll = "yes";
	docEditor.body.wordWrap = false;
	docEditor.body.onkeydown = new Function("RTE_OnKeyDown('" + strBaseElementID + "', this)");
	docEditor.body.onkeyup = new Function("RTE_OnKeyUp('" + strBaseElementID + "', this)");
	docEditor.body.onmouseup = new Function("RTE_OnMouseUp('" + strBaseElementID + "')");
	docEditor.body.oncontextmenu = new Function("return false");
	docEditor.body.onblur = new Function("RTE_OnBlur('" + strBaseElementID + "');");
	if (fRestrictedMode){
		docEditor.body.ondragenter = new Function("RTE_OnDragEnter(this);");
		docEditor.body.ondragover = new Function("RTE_OnDragOver(this);");
		docEditor.body.ondragdrop = new Function("RTE_OnDrop(this);");
	}
	RTE_GetEditorElement(strBaseElementID).onfocus = new Function("RTE_OnFocus('" + strBaseElementID + "');");
	if(strDirection != ""){
	    docEditor.dir = strDirection;
	}
	else
	{
	    docEditor.dir = document.dir;
	}
	if (fRestrictedMode){
		docEditor.body.setAttribute(g_strRTERestrictedModeAttributeName, "true");
		docEditor.body.onpaste = new Function("RTE_OnPaste_Restricted('" + strBaseElementID + "', this);");
	}
	if (fAllowHyperlink){
	    docEditor.body.setAttribute(g_strRTEAllowHyperlinkAttributeName, "true");
	}
	docEditor.body.setAttribute(g_strRTEBaseElementIDAttributeName, strBaseElementID);
	docEditor.body.setAttribute(g_strRTEWebLocaleAttributeName, strWebLocale);
	g_rgstrRTEAllEditorsInThePage[g_rgstrRTEAllEditorsInThePage.length] = strBaseElementID;
	RTE_GiveEditorFocus(strBaseElementID);
	RTE_ResetAllToolBarStates(strBaseElementID);
}
function RTE_DisableToolBar(strBaseElementID){
        if(document.activeElement && document.activeElement.className.indexOf('ms-')==0)return false;
		var fRestrictedMode = RTE_IsInRestrictedMode(strBaseElementID);
		var fAllowHyperlink = RTE_IsHyperlinkAllowed(strBaseElementID);
		if (!fRestrictedMode)
		{
			RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTECutMnemonic));
			RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTECopyMnemonic));
			RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEPasteMnemonic));
		}
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEFontNameMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEFontSizeMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEBoldMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEItalicMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEUnderlineMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEJustifyLeftMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEJustifyCenterMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEJustifyRightMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEOrderedListMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEUnorderedListMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEOutdentMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEIndentMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEForeColorMnemonic));
		RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEBackColorMnemonic));
		if (RTE_ShouldShowDirection())
		{
			RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTELTRMnemonic));
			RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTERTLMnemonic));
		}
		if (!fRestrictedMode || fAllowHyperlink)
		{
			RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTECreateLinkMnemonic));
		}
		if (!fRestrictedMode)
		{
			RTE_TB_SetButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEInsertImageMnemonic));
		}
}
function RTE_ResetAllToolBarStates(strBaseElementID){
	if ((browseris.ie55up) && (RTE_EditorWithTheFocus() != strBaseElementID) && (RTE_ToolBarButtonWithTheFocus() == null) && (!RTE_DD_MenuIsOpen()) 
	     && (!g_fRTEDialogIsOpen)){
		RTE_DisableToolBar(strBaseElementID);
		return;
	}
	var docEditor = RTE_GetEditorDocument(strBaseElementID);
	var fRestrictedMode = RTE_IsInRestrictedMode(strBaseElementID);
	var fAllowHyperlink = RTE_IsHyperlinkAllowed(strBaseElementID);
	if (!fRestrictedMode){
		RTE_TB_SetEnabledFromCommandEnabled(strBaseElementID, docEditor, g_strRTECutMnemonic, true);
		RTE_TB_SetEnabledFromCommandEnabled(strBaseElementID, docEditor, g_strRTECopyMnemonic, true);
		RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEPasteMnemonic));
	}
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEFontNameMnemonic));
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEFontSizeMnemonic));
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEBoldMnemonic));
 	RTE_TB_SetCheckFromCommandValue(strBaseElementID, docEditor, g_strRTEBoldMnemonic);
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEItalicMnemonic));
	RTE_TB_SetCheckFromCommandValue(strBaseElementID, docEditor, g_strRTEItalicMnemonic);
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEUnderlineMnemonic));
	RTE_TB_SetCheckFromCommandValue(strBaseElementID, docEditor, g_strRTEUnderlineMnemonic);
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEJustifyLeftMnemonic));
	RTE_TB_SetCheckFromCommandValue(strBaseElementID, docEditor, g_strRTEJustifyLeftMnemonic);
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEJustifyCenterMnemonic));
	RTE_TB_SetCheckFromCommandValue(strBaseElementID, docEditor, g_strRTEJustifyCenterMnemonic);
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEJustifyRightMnemonic));
	RTE_TB_SetCheckFromCommandValue(strBaseElementID, docEditor, g_strRTEJustifyRightMnemonic);
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEOrderedListMnemonic));
	RTE_TB_SetCheckFromCommandValue(strBaseElementID, docEditor, g_strRTEOrderedListMnemonic);
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEUnorderedListMnemonic));
	RTE_TB_SetCheckFromCommandValue(strBaseElementID, docEditor, g_strRTEUnorderedListMnemonic);
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEOutdentMnemonic));
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEIndentMnemonic));
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEForeColorMnemonic));
	RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEBackColorMnemonic));
	if (RTE_ShouldShowDirection()){
		RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTELTRMnemonic));
		RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTERTLMnemonic));
	}
	if (!fRestrictedMode || fAllowHyperlink){
		RTE_TB_SetEnabledFromCommandEnabled(strBaseElementID, docEditor, g_strRTECreateLinkMnemonic, true);
	}
	if (!fRestrictedMode){
		RTE_TB_ClearButtonDisabled(RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEInsertImageMnemonic));
	}
}
function RTE_TransferTextAreaContentsToIFrame(strBaseElementID){
	var elemTextArea = RTE_GetEditorTextArea(strBaseElementID);
	var strHtmlToEdit = elemTextArea.innerText;
	var docEditor = RTE_GetEditorDocument(strBaseElementID);
	if (null == docEditor)
		return;
	if ((null == strHtmlToEdit) || (0 == strHtmlToEdit.length)){
		strHtmlToEdit = "<div></div>";
	}
	docEditor.body.innerHTML = strHtmlToEdit;
	if (strBaseElementID == g_strRTEEditorFirstFocus){
	   var tr = docEditor.body.createTextRange();
	   tr.collapse(true);
	   tr.select();
	   g_strRTEEditorFirstFocus = null;
	}
}
function RTE_TransferIFrameContentsToTextArea(strBaseElementID){
	var strHtml, strText;
	var elemTextArea = RTE_GetEditorTextArea(strBaseElementID);
	var docEditor = RTE_GetEditorDocument(strBaseElementID);
	if (null == docEditor)
		return; 
	strHtml = docEditor.body.innerHTML;
	strText =  docEditor.body.innerText;
	if (0 >= strText.length){
		strHtml = "";
	}
	elemTextArea.innerText = strHtml;
	return elemTextArea.innerText;
}
function RTE_TextAreaWindow_OnLoad(strBaseElementID){
	;
	RTE_TransferTextAreaContentsToIFrame(strBaseElementID);
}
function RTE_TextArea_OnFocus(strBaseElementID){
	;
	RTE_GiveEditorFocus(strBaseElementID);
}
function RTE_OnFocus(strBaseElementID){
	;
	g_strRTETextEditorWithTheFocus = strBaseElementID;
	if ((g_strRTEPrevTextEditor != null) && (g_strRTEPrevTextEditor.length > 0) && (g_strRTEPrevTextEditor != strBaseElementID)){
		RTE_DisableToolBar(g_strRTEPrevTextEditor);
	}
	RTE_StartResetToolBarTimer(strBaseElementID);
}
function RTE_OnBlur(strBaseElementID){
	;
	RTE_SaveSelection(strBaseElementID);
	g_strRTEPrevTextEditor = g_strRTETextEditorWithTheFocus;
	g_strRTETextEditorWithTheFocus = null;
	RTE_StartResetToolBarTimer(strBaseElementID);
}
function RTE_OnDragEnter(elemThis){
	;
	var evtThis = elemThis.document.parentWindow.event;
	if (null != evtThis){
		evtThis.dataTransfer.dropEffect = "none";
		evtThis.returnValue = false;
	}
}
function RTE_OnDragOver(elemThis){
	;
	var evtThis = elemThis.document.parentWindow.event;
	if (null != evtThis){
		evtThis.dataTransfer.dropEffect = "none";
		evtThis.returnValue = false;
	}
}
function RTE_OnDrop(elemThis){
	;
	var evtThis = elemThis.document.parentWindow.event;
	if (null != evtThis){
		evtThis.dataTransfer.dropEffect = "none";
		evtThis.returnValue = false;
	}
}
function RTE_FInterpretTextAsBoolean(strBoolVal){
   if (strBoolVal.toLowerCase() == "true")
      return true;
   else
      return false;
}
function RTE_OnKeyDown(strBaseElementID, elem){
	RTE_SaveSelection(strBaseElementID);
	var fRestrictedMode = RTE_IsInRestrictedMode(strBaseElementID);
	var fAllowHyperlink = RTE_IsHyperlinkAllowed(strBaseElementID);
	var evtSource = elem.document.parentWindow.event;
	var nKeyCode = evtSource.keyCode;
	var fAltKey = evtSource.altKey;
	var fCtrlKey = evtSource.ctrlKey;
	var fShiftKey = evtSource.shiftKey;
   if (browseris.ie5up && !browseris.ie55up && (!fCtrlKey && !fAltKey && !fShiftKey))
   {
      switch (nKeyCode)
      {
         case 9: 
            var tr = RTE_GetEditorDocument(strBaseElementID).body.createTextRange();
            tr.collapse(true);
            tr.select();
            break;
      }
   }
	if (!fCtrlKey && !fAltKey && fShiftKey){
		switch (nKeyCode)
		{
			case 9: 
				evtSource.returnValue = false;
				document.body.focus();
				RTE_MoveFocusBackwards(RTE_GetEditorTextArea(strBaseElementID), strBaseElementID);
				break;
		}
	}
	else if (fCtrlKey){
		if ((L_BoldKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_BoldShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_BoldAltKey_TEXT ) == fAltKey)) 
	   {
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEBoldMnemonic).children(0).click();
	   }
		else if (( L_ItalicKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_ItalicShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_ItalicAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEItalicMnemonic).children(0).click();
		}
		else if (( L_UnderlineKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_UnderlineShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_UnderlineAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEUnderlineMnemonic).children(0).click();
		}
		else if (( L_JustifyLeftKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_JustifyLeftShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_JustifyLeftAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEJustifyLeftMnemonic).children(0).click();
		}
		else if (( L_JustifyCenterKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_JustifyCenterShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_JustifyCenterAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEJustifyCenterMnemonic).children(0).click();
		}
		else if (( L_JustifyRightKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_JustifyRightShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_JustifyRightAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEJustifyRightMnemonic).children(0).click();
		}
		else if (( L_IndentKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_IndentShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_IndentAltKey_TEXT) == fAltKey))  
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEIndentMnemonic).children(0).click();
		}
		else if (( L_CreateLinkKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_CreateLinkShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_CreateLinkAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
		   if (!fRestrictedMode || fAllowHyperlink)
		   {
				RTE_TB_GetToolBarButton(strBaseElementID, g_strRTECreateLinkMnemonic).children(0).click();
			}
		}
		else if (( L_SelectFontNameKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_SelectFontNameShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_SelectFontNameAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEFontNameMnemonic).children(0).click();
		}
		else if (( L_SelectFontSizeKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_SelectFontSizeShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_SelectFontSizeAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEFontSizeMnemonic).children(0).click();
		}
      else if (( L_SelectForeColorKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_SelectForeColorShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_SelectForeColorAltKey_TEXT) == fAltKey)) 
      {
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEForeColorMnemonic).children(0).click();
      }
	   else if (( L_SelectBackColorKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_SelectBackColorShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_SelectBackColorAltKey_TEXT) == fAltKey)) 
	   {
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEBackColorMnemonic).children(0).click();
	   }
		else if (( L_UnorderedListKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_UnorderedListShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_UnorderedListAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEUnorderedListMnemonic).children(0).click();
		}
      else if (( L_OrderedListKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_OrderedListShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_OrderedListAltKey_TEXT) == fAltKey)) 
      {
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEOrderedListMnemonic).children(0).click();
      }
		else if (( L_OutdentKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_OutdentShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_OutdentAltKey_TEXT) == fAltKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEOutdentMnemonic).children(0).click();
		}
      else if (( L_InsertImageKey_TEXT.charCodeAt(0) == nKeyCode)
		   && (RTE_FInterpretTextAsBoolean(L_InsertImageShiftKey_TEXT) == fShiftKey)
		   && (RTE_FInterpretTextAsBoolean(L_InsertImageAltKey_TEXT) == fAltKey))
      {
			evtSource.returnValue = false;
			if (!fRestrictedMode)
			{
				RTE_TB_GetToolBarButton(strBaseElementID, g_strRTEInsertImageMnemonic).children(0).click();
			}
      }
		else if (( L_LTRKey_VALUE  == nKeyCode)
		   && (fShiftKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTELTRMnemonic).children(0).click();
		}
		else if (( L_RTLKey_VALUE == nKeyCode)
		   && (fShiftKey)) 
		{
			evtSource.returnValue = false;
			RTE_TB_GetToolBarButton(strBaseElementID, g_strRTERTLMnemonic).children(0).click();
		}
	}
}
function RTE_OnKeyUp(strBaseElementID, elem){
	;
	RTE_StartResetToolBarTimer(strBaseElementID);
}
function RTE_OnMouseUp(strBaseElementID){
	;
	RTE_DD_CloseMenu();
	RTE_ResetAllToolBarStates(strBaseElementID);
}
function RTE_OnPaste_Restricted(strBaseElementID, elem){
	;
	elem.document.parentWindow.event.returnValue = false;
	RTE_RestoreSelection(strBaseElementID);
	var rngSelection = RTE_GetSelection(strBaseElementID);
	var strFromClipboard = window.clipboardData.getData("Text");
	if ((null != rngSelection) && (null != strFromClipboard)){
		rngSelection.text = strFromClipboard;
	}
}
var g_cRTEResetToolBarTimerQueue = 0;
function RTE_StartResetToolBarTimer(strBaseElementID){
	++g_cRTEResetToolBarTimerQueue;
	window.setTimeout("RTE_OnResetToolBarTimer(\"" + strBaseElementID + "\")", 400);
}
function RTE_OnResetToolBarTimer(strBaseElementID){
	;
	--g_cRTEResetToolBarTimerQueue;
	if (0 == g_cRTEResetToolBarTimerQueue){
		RTE_ResetAllToolBarStates(strBaseElementID);
	}
}
var g_fRTEFirstTimeGenerateCalled = true;
function RTE_GenerateIFrameEditorHtml(strBaseElementID, elemTextArea, fRestrictedMode, fAllowHyperlink){
	var strHtmlRet = "";
	if (g_fRTEFirstTimeGenerateCalled){
		g_fRTEFirstTimeGenerateCalled = false;
		strHtmlRet += "<iframe id=\"" + g_strRTETextEditorPullDownMenuID + "\"  src=\"" + RTE_GetServerRelativeUnlocalizedImageUrl("blank.gif") +
			"\" class=\"ms-rtetoolbarmenu\" TABINDEX=-1 style=\"display:none; position:absolute;\" " +g_strRTEBaseElementIDAttributeName + "=\"x\" " + g_strRTEWebLocaleAttributeName + "=\"x\" " +
			g_strRTEButtonMnemonicAttributeName + "=\"x\"></iframe>";
		document.body.insertAdjacentHTML("afterBegin", "<object id=\"RTEDialogHelper\" name=\"RTEDialogHelper\" classid=\"clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b\" style=\"width:0px; height:0px;\" TABINDEX=-1></OBJECT>");
	}
	var strWidthNameAndAttribute = ""
	var strHeightNameAndAttribute = ""
	var strClassNameAndAttribute = "";
	var cRows = elemTextArea.getAttribute("rows");
	if ((fRestrictedMode) && (null != cRows) && (cRows > 0)){
		strWidthNameAndAttribute = " width=\"100%\"";
		strHeightNameAndAttribute = " height=\"" + cRows * g_iLineHeight + "\"";
		if (fAllowHyperlink)
		{
			strClassNameAndAttribute = " class=\"ms-longer\"";
		}
		else
		{
			strClassNameAndAttribute = " class=\"ms-long\"";
		}
	}
	else
	{
		strWidthNameAndAttribute = " width=\"" + elemTextArea.offsetWidth + "\"";
		strHeightNameAndAttribute = " height=\"" + elemTextArea.offsetHeight + "\"";
		strClassNameAndAttribute = "";
	}
	strHtmlRet += "<div style=\"width:100%;height:100%\" >";
	strHtmlRet += "<iframe  style=\"width:100%\" " + strWidthNameAndAttribute + strHeightNameAndAttribute + strClassNameAndAttribute +
			" id=\"" + RTE_GetEditorIFrameID(strBaseElementID) + "\" title=\"" + L_EditorIFrameTitle_TEXT +
			"\" src=\"" + RTE_GetServerRelativeUnlocalizedImageUrl("blank.gif") + "\" TABINDEX=1></iframe>";
	strHtmlRet += "</div>";
	return strHtmlRet;
}
function RTE_GenerateToolBarHtml(strBaseElementID, strWebLanguage, elemTextArea, fRestrictedMode, fAllowHyperlink){
	var strHtmlRet = "";
	var strClassAttribute = " class=\"ms-toolbar rtetoolbar\" ";
	var strWidthAttribute = " width=\"100%\" ";//elemTextArea.currentStyle.width
	if (fRestrictedMode){
		if (fAllowHyperlink)
		{
			strClassAttribute = " class=\"ms-toolbar rtetoolbar ms-longer\" ";
		}
		else
		{
			strClassAttribute = " class=\"ms-toolbar rtetoolbar ms-long\" ";
		}
		//strWidthAttribute = "";
	}
	strHtmlRet += "<table style=\"width:100%\" cellpadding=0 cellspacing=0 " + strClassAttribute + strWidthAttribute + ">";
	strHtmlRet += "<tr><td><table cellspacing=0 cellpadding=0 border=0 >";
	strHtmlRet += "<tr>";
	if (!fRestrictedMode){
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTECutMnemonic, false, RTE_GetServerRelativeImageUrl("rtecut.gif"), "", L_CutToolTip_TEXT, true);
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTECopyMnemonic, false, RTE_GetServerRelativeImageUrl("rtecopy.gif"), "", L_CopyToolTip_TEXT, true);
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEPasteMnemonic, false, RTE_GetServerRelativeImageUrl("rtepaste.gif"), "", L_PasteToolTip_TEXT, false);
		strHtmlRet += RTE_TB_GenerateToolBarSeparatorHtml();
	}
	strHtmlRet += RTE_GenerateFontNameToolBarButtonHtml(strBaseElementID, strWebLanguage, fRestrictedMode);
	strHtmlRet += RTE_GenerateFontSizeToolBarButtonHtml(strBaseElementID, strWebLanguage, fRestrictedMode);
	strHtmlRet += RTE_TB_GenerateToolBarSeparatorHtml();
	strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEBoldMnemonic, false, RTE_GetServerRelativeImageUrl("rtebold.gif"), "", L_BoldToolTip_TEXT, false);
	strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEItalicMnemonic, false, RTE_GetServerRelativeImageUrl("rteital.gif"), "", L_ItalicToolTip_TEXT, false);
	strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEUnderlineMnemonic, false, RTE_GetServerRelativeImageUrl("rteundl.gif"), "", L_UnderlineToolTip_TEXT, false);
	strHtmlRet += RTE_TB_GenerateToolBarSeparatorHtml();
	if (strWebLanguage == "1025" || strWebLanguage == "1037"){
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEJustifyRightMnemonic, false, RTE_GetServerRelativeImageUrl("rtertal.gif"), "", L_JustifyRightToolTip_TEXT, false);
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEJustifyCenterMnemonic, false, RTE_GetServerRelativeImageUrl("rtectral.gif"), "", L_JustifyCenterToolTip_TEXT, false);
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEJustifyLeftMnemonic, false, RTE_GetServerRelativeImageUrl("rteltal.gif"), "", L_JustifyLeftToolTip_TEXT, false);
	}
	else
	{
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEJustifyLeftMnemonic, false, RTE_GetServerRelativeImageUrl("rteltal.gif"), "", L_JustifyLeftToolTip_TEXT, false);
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEJustifyCenterMnemonic, false, RTE_GetServerRelativeImageUrl("rtectral.gif"), "", L_JustifyCenterToolTip_TEXT, false);
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEJustifyRightMnemonic, false, RTE_GetServerRelativeImageUrl("rtertal.gif"), "", L_JustifyRightToolTip_TEXT, false);
	}
	strHtmlRet += RTE_TB_GenerateToolBarSeparatorHtml();
	strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEOrderedListMnemonic, false, RTE_GetServerRelativeImageUrl("rtenlst.gif"), "", L_OrderedListToolTip_TEXT, false);
	strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEUnorderedListMnemonic, false, RTE_GetServerRelativeImageUrl("rteblst.gif"), "", L_UnorderedListToolTip_TEXT, false);
	if (!fRestrictedMode){
		strHtmlRet += RTE_TB_GenerateToolBarSeparatorHtml();
	}
	if (strWebLanguage == "1025" || strWebLanguage == "1037"){
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEIndentMnemonic, false, RTE_GetServerRelativeImageUrl("rteidt.gif"), "", L_IndentToolTip_TEXT, false);
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEOutdentMnemonic, false, RTE_GetServerRelativeImageUrl("rteuidt.gif"), "", L_OutdentToolTip_TEXT, false);
	}
	else
	{
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEOutdentMnemonic, false, RTE_GetServerRelativeImageUrl("rteuidt.gif"), "", L_OutdentToolTip_TEXT, false);
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEIndentMnemonic, false, RTE_GetServerRelativeImageUrl("rteidt.gif"), "", L_IndentToolTip_TEXT, false);
	}
	if (!fRestrictedMode){
		strHtmlRet += RTE_TB_GenerateToolBarSeparatorHtml();
	}
	if (!fRestrictedMode || fAllowHyperlink){
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTECreateLinkMnemonic, true, RTE_GetServerRelativeImageUrl("rtelnk.gif"), "", L_CreateLinkToolTip_TEXT, true);
	}
	if (!fRestrictedMode){
		strHtmlRet += RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, g_strRTEInsertImageMnemonic, true, RTE_GetServerRelativeImageUrl("rteimg.gif"), "", L_InsertImageToolTip_TEXT, false);
	}
	strHtmlRet += RTE_TB_GenerateToolBarSeparatorHtml();
	strHtmlRet += RTE_GenerateForeColorToolBarButtonHtml(strBaseElementID, strWebLanguage);
	strHtmlRet += RTE_GenerateBackColorToolBarButtonHtml(strBaseElementID, strWebLanguage);
	if (RTE_ShouldShowDirection()){
		if (!fRestrictedMode)
		{
			strHtmlRet += RTE_TB_GenerateToolBarSeparatorHtml();
		}
		if (strWebLanguage == "1025" || strWebLanguage == "1037")
		{
			strHtmlRet += RTE_TB_GenerateToolBarButtonHtml(strBaseElementID, "rtl", "RTE_SetDirectionOfSelection('" + strBaseElementID + "', 'rtl');", RTE_GetServerRelativeImageUrl("rtertl.gif"), "", L_RTLToolTip_TEXT);
			strHtmlRet += RTE_TB_GenerateToolBarButtonHtml(strBaseElementID, "ltr", "RTE_SetDirectionOfSelection('" + strBaseElementID + "', 'ltr');", RTE_GetServerRelativeImageUrl("rteltr.gif"), "", L_LTRToolTip_TEXT);
		}
		else
		{
			strHtmlRet += RTE_TB_GenerateToolBarButtonHtml(strBaseElementID, "ltr", "RTE_SetDirectionOfSelection('" + strBaseElementID + "', 'ltr');", RTE_GetServerRelativeImageUrl("rteltr.gif"), "", L_LTRToolTip_TEXT);
			strHtmlRet += RTE_TB_GenerateToolBarButtonHtml(strBaseElementID, "rtl", "RTE_SetDirectionOfSelection('" + strBaseElementID + "', 'rtl');", RTE_GetServerRelativeImageUrl("rtertl.gif"), "", L_RTLToolTip_TEXT);
		}			
	}
	strHtmlRet += "</tr>";
	strHtmlRet += "</table></td></tr>";
	strHtmlRet += "</table>";
	return strHtmlRet;
}
function RTE_GenerateFontNameToolBarButtonHtml(strBaseElementID, strWebLanguage, fRestrictedMode){
	var strHtmlRet = "";
	strHtmlRet += RTE_TB_GenerateOpenCellButtonHtml(strBaseElementID, g_strRTEFontNameMnemonic);
	strHtmlRet += "<a TABINDEX=-1 href=\"#\" onfocus=\"RTE_TB_OnFocus('" + strBaseElementID + "', this); return false;\" onblur=\"RTE_TB_OnBlur('" + strBaseElementID + "', this); return false;\" onclick=\"RTE_DD_OpenFontNameOrSizeSelector('" + strBaseElementID + "' ,'" + strWebLanguage + "', true); return false;\" title=\"" +
			L_FontNameToolTip_TEXT + "\"";
	if (fRestrictedMode){
		strHtmlRet += "><img src=\"" + RTE_GetServerRelativeImageUrl("rtefnt.gif") + "\" alt=\"" + L_FontNameToolTip_TEXT + "\" border=0>";
	}
	else
	{
		strHtmlRet += " style=\"margin-left: 2px; margin-right: 2px;\">" + L_FontNameLabel_TEXT + "&nbsp;<img alt=\"" +
				L_FontNameToolTip_TEXT + "\" src=\"" + RTE_GetServerRelativeImageUrl("rtednar.gif") + "\" border=0>";
	}
	strHtmlRet += "</a>";
	strHtmlRet += RTE_TB_GenerateCloseCellButtonHtml();
	return strHtmlRet;
}
function RTE_GenerateFontSizeToolBarButtonHtml(strBaseElementID, strWebLanguage, fRestrictedMode){
	var strHtmlRet = "";
	strHtmlRet += RTE_TB_GenerateOpenCellButtonHtml(strBaseElementID, g_strRTEFontSizeMnemonic);
	strHtmlRet += "<a TABINDEX=-1 href=\"#\" onfocus=\"RTE_TB_OnFocus('" + strBaseElementID + "', this); return false;\" onblur=\"RTE_TB_OnBlur('" + strBaseElementID + "', this); return false;\" onclick=\"RTE_DD_OpenFontNameOrSizeSelector('" + strBaseElementID + "', '" + strWebLanguage + "', false); return false;\" title=\"" +
			L_FontSizeToolTip_TEXT + "\"";
	if (fRestrictedMode){
		strHtmlRet += "><img src=\"" + RTE_GetServerRelativeImageUrl("rtefntsz.gif") + "\" alt=\"" + L_FontSizeToolTip_TEXT + "\" border=0>";
	}
	else
	{
		strHtmlRet += " style=\"margin-left: 2px; margin-right: 2px;\">" + L_FontSizeLabel_TEXT + "&nbsp;<img alt=\"" +
				L_FontSizeToolTip_TEXT + "\" src=\"" + RTE_GetServerRelativeImageUrl("rtednar.gif") + "\" border=0>";
	}
	strHtmlRet += "</a>";
	strHtmlRet += RTE_TB_GenerateCloseCellButtonHtml();
	return strHtmlRet;
}
function RTE_GenerateForeColorToolBarButtonHtml(strBaseElementID, strWebLanguage){
	var strHtmlRet = "";
	strHtmlRet += RTE_TB_GenerateOpenCellButtonHtml(strBaseElementID, g_strRTEForeColorMnemonic);
	strHtmlRet += "<a TABINDEX=-1 href=\"#\" onfocus=\"RTE_TB_OnFocus('" + strBaseElementID + "', this); return false;\" onblur=\"RTE_TB_OnBlur('" + strBaseElementID + "', this); return false;\" onclick=\"RTE_DD_OpenForeColorSelector('" + strBaseElementID + "', '" + strWebLanguage + "'); return false;\"><img src=\"" + RTE_GetServerRelativeImageUrl("rtetxclr.gif") + "\" alt=\"" +
			L_ForeColorToolTip_TEXT + "\" border=0></a>";
	strHtmlRet += RTE_TB_GenerateCloseCellButtonHtml();
	return strHtmlRet;
}
function RTE_GenerateBackColorToolBarButtonHtml(strBaseElementID, strWebLanguage){
	var strHtmlRet = "";
	strHtmlRet += RTE_TB_GenerateOpenCellButtonHtml(strBaseElementID, g_strRTEBackColorMnemonic);
	strHtmlRet += "<a TABINDEX=-1 href=\"#\" onfocus=\"RTE_TB_OnFocus('" + strBaseElementID + "', this); return false;\" onblur=\"RTE_TB_OnBlur('" + strBaseElementID + "', this); return false;\" onclick=\"RTE_DD_OpenBackColorSelector('" + strBaseElementID + "', '" + strWebLanguage +"'); return false;\"><img src=\"" + RTE_GetServerRelativeImageUrl("rtebkclr.gif") + "\" alt=\"" +
			L_BackColorToolTip_TEXT + "\" border=0></a>";
	strHtmlRet += RTE_TB_GenerateCloseCellButtonHtml();
	return strHtmlRet;
}
function RTE_ShouldIgnoreElement(elem){
	return false;
}
function RTE_FindChildElementOfType(elemRoot, strTagNames, strBaseElementIDToSkip, fIgnoreRoot, fForwards){
	if ((elemRoot.nodeType != g_ntRTEElement) || (elemRoot.className.indexOf("rtetoolbar") >= 0) || (elemRoot.id == g_strRTETextEditorPullDownMenuID) || (elemRoot.id == RTE_GetEditorIFrameID(strBaseElementIDToSkip))){
		return null;
	}
	if ((fForwards) && (!fIgnoreRoot) && (strTagNames.indexOf("|"+elemRoot.tagName+"|") >= 0)){
		return elemRoot;
	}
	if ((elemRoot.children != null) && (elemRoot.children.length > 0)){
		var ielemChild = 0;
		var ielemLast = elemRoot.children.length - 1;
		var ielemIncrement = 1;
		if (!fForwards)
		{
			ielemChild = ielemLast;
			ielemLast = 0;
			ielemIncrement = -1;
		}
		do
		{
			var elemChild = elemRoot.children(ielemChild);
			if (elemChild != null)
			{
				var elemFound = RTE_FindChildElementOfType(elemChild, strTagNames, strBaseElementIDToSkip, false, fForwards); 
				if (elemFound != null)
				{
					return elemFound;
				}
			}
			ielemChild += ielemIncrement;
		} while (((fForwards) && (ielemChild <= ielemLast)) || ((!fForwards) && (ielemChild >= ielemLast)));
	}
	if ((!fForwards) && (!fIgnoreRoot) && (strTagNames.indexOf("|"+elemRoot.tagName+"|") >= 0)){
		return elemRoot;
	}
	return null;
}
function RTE_FindNextElementOfType(elemStart, strTagNames, strBaseElementIDToSkip, fForwards){
	if (fForwards){
		var elemChild = RTE_FindChildElementOfType(elemStart, strTagNames, strBaseElementIDToSkip, true, fForwards); 
		if (elemChild != null)
		{
			return elemFound;
		}
	}
	var elemCurrent = elemStart;
	do
	{
		if (fForwards)
		{
			if (elemCurrent.nextSibling != null)
			{
				elemCurrent = elemCurrent.nextSibling;
			}
			else
			{
				while (true)
				{
					if (elemCurrent.parentNode == null)
					{
						elemCurrent = elemCurrent.firstChild;
						break;
					}
					if (elemCurrent.parentNode.nextSibling != null)
					{
						elemCurrent = elemCurrent.parentNode.nextSibling;
						break;
					}
					elemCurrent = elemCurrent.parentNode;
				}
			}
		}
		else
		{
			if (elemCurrent.previousSibling != null)
			{
				elemCurrent = elemCurrent.previousSibling;
			}
			else
			{
				while (true)
				{
					if (elemCurrent.parentNode == null)
					{
						elemCurrent = elemCurrent.lastChild;
						break;
					}
					if (elemCurrent.parentNode.previousSibling != null)
					{
						elemCurrent = elemCurrent.parentNode.previousSibling;
						break;
					}
					elemCurrent = elemCurrent.parentNode;
				}
			}
		}
		if (elemCurrent != null)
		{
			var elemChild = RTE_FindChildElementOfType(elemCurrent, strTagNames, strBaseElementIDToSkip, false, fForwards); 
			if (elemChild != null)
			{
				return elemChild;
			}
		}
	} while (elemCurrent != null);
	return null;
}
var g_strRTEFocusElementTagNames = "|INPUT|TEXTAREA|IFRAME|A|";
function RTE_MoveFocus(elemStart, strBaseElementIDToSkip, fForwards){
	var elemNext = RTE_FindNextElementOfType(elemStart, g_strRTEFocusElementTagNames, strBaseElementIDToSkip, fForwards);
	while ((elemNext != null) && ((elemNext.disabled == true) || (elemNext.hidden == true)))
		   elemNext = RTE_FindNextElementOfType(elemNext, g_strRTEFocusElementTagNames, strBaseElementIDToSkip, fForwards);
	if (elemNext != null){
		if (elemNext.tagName == "IFRAME")
		{
			var ifmEditor = null;
	      if ((null != document.frames) && (document.frames.length > 0))
	      {
      		var ifmContainer = document.getElementById(elemNext.id);
   		   if (ifmContainer != null)
   		   {
   		   	ifmEditor = document.frames(elemNext.id);
   		   	if (ifmEditor != null)
   		   	{
   		   	   ifmEditor.focus();
   		   	}
   		   }
	      }
		}
		else if (elemNext.tagName == "INPUT")
		{
         elemNext.focus();
         elemNext.select();
		}
		else if (elemNext.tagName == "TEXTAREA")
		{
		   elemNext.focus();
		   var tr = elemNext.createTextRange();
		   tr.collapse(false);
		   tr.select();
		}
		else
		   elemNext.focus();
	}
}
function RTE_MoveFocusBackwards(elemStart, strBaseElementIDToSkip){
	RTE_MoveFocus(elemStart, strBaseElementIDToSkip, false);
}
function RTE_MoveFocusForwards(elemStart, strBaseElementIDToSkip){
	RTE_MoveFocus(elemStart, strBaseElementIDToSkip, true);
}
function RTE_ExecuteCommandOnSelection(strBaseElementID, strCommand, fUserInterface, strValue){
	var docEditor = RTE_GetEditorDocument(strBaseElementID);
	RTE_RestoreSelection(strBaseElementID);
	if ((strCommand == g_strRTECreateLinkMnemonic) || (strCommand == g_strRTEInsertImageMnemonic)){
		g_fRTEDialogIsOpen = true;
	}
	docEditor.execCommand(strCommand, fUserInterface, strValue);
	if (g_fRTEDialogIsOpen){
		g_fRTEDialogIsOpen = false;
		 RTE_OnFocus(strBaseElementID);
	}
	RTE_StartResetToolBarTimer(strBaseElementID);
}
function RTE_SetDirectionOfSelection(strBaseElementID, strDirection){
	var rngSelection = RTE_GetSelection(strBaseElementID);
	RTE_RestoreSelection(strBaseElementID);
	var strTagNames;
	if ("ltr" == strDirection){
		strTagNames = "|H1|H2|H3|H4|H5|H6|P|PRE|LI|TD|DIV|BLOCKQUOTE|DT|DD|TABLE|HR|IMG|TR|UL|OL|";
	}
	else
	{
		strTagNames = "|H1|H2|H3|H4|H5|H6|P|PRE|LI|TD|DIV|BLOCKQUOTE|DT|DD|TABLE|HR|IMG|";
	}
	var elemSelectionParent = rngSelection.parentElement();
	while ((elemSelectionParent != null) && (strTagNames.indexOf("|"+elemSelectionParent.tagName+"|") == -1)){
		elemSelectionParent = elemSelectionParent.parentElement;
	}
	if (elemSelectionParent){
		if ("ltr" == strDirection)
		{
			elemSelectionParent.dir = "ltr"	;
			elemSelectionParent.align = "left";
		}
		else
		{
			elemSelectionParent.dir = "rtl";
			elemSelectionParent.align = "right";
		}
	}
}
var g_strRTEToolBarButtonWithTheFocus = null;
function RTE_ToolBarButtonWithTheFocus(){
	return g_strRTEToolBarButtonWithTheFocus;
}
function RTE_TB_GetToolBarButton(strBaseElementID, strButtonMnemonic){
	var elemToolBarButton = document.all(strBaseElementID + "_" + strButtonMnemonic);
	return elemToolBarButton;
}
function RTE_TB_GenerateOpenCellButtonHtml(strBaseElementID, strButtonMnemonic){
	var strHtmlRet = "";
	strHtmlRet += "<td class=ms-toolbar>";
	strHtmlRet += "<table cellpadding=1 cellspacing=0 border=0>";
	strHtmlRet += "<tr>";
	strHtmlRet += "<td class=\"ms-toolbar " + g_strRTEUnselectedClassName + "\" nowrap id=\"" + strBaseElementID + "_" + strButtonMnemonic + "\" onmouseover=\"RTE_TB_OnMouseOver(this);\" onmouseout=\"RTE_TB_OnMouseOut(this);\">";
	return strHtmlRet;
}
function RTE_TB_GenerateCloseCellButtonHtml(){
	var strHtmlRet = "";
	strHtmlRet += "</td>";
	strHtmlRet += "</tr>";
	strHtmlRet += "</table>";
	strHtmlRet += "</td>";
	return strHtmlRet;
}
function RTE_TB_GenerateToolBarSeparatorHtml(){
	return "<td class=ms-separator>|</td>";
}
function RTE_TB_GenerateToolBarButtonHtml(strBaseElementID, strButtonMnemonic, strOnClickJScript, strImageUrl, strText, strToolTip){
	var strHtmlRet = "";
	strHtmlRet += RTE_TB_GenerateOpenCellButtonHtml(strBaseElementID, strButtonMnemonic);	
	strHtmlRet += "<a TABINDEX=-1 href=\"#\" onfocus=\"RTE_TB_OnFocus('" + strBaseElementID + "', this); return false;\" onblur=\"RTE_TB_OnBlur('" + strBaseElementID + "', this); return false;\" onclick=\"" + strOnClickJScript + "; return false;\">";
	if (0 < strImageUrl.length){
		strHtmlRet += "<img border=0 src=\"" + strImageUrl + "\" alt=\"" + strToolTip + "\">";
	}
	if (0 < strText.length){
		strHtmlRet += " " + strText;
	}
	strHtmlRet += "</a>";
	strHtmlRet += RTE_TB_GenerateCloseCellButtonHtml();
	return strHtmlRet;
}
function RTE_TB_GenerateExecCommandToolBarButtonHtml(strBaseElementID, strCommand, fUserInterface, strImageUrl, strText, strToolTip, fOnlyIfSelectionActive){
	var strOnClickJScript = "";
	if (fOnlyIfSelectionActive){
		strOnClickJScript += "var sel = RTE_GetEditorDocument('" + strBaseElementID + "').selection; if ((null != sel) && ('None' != sel.type)) { ";
	}
   if (browseris.ie5up && !browseris.ie55up && !browseris.ie6up)
   {
      strOnClickJScript += "RTE_SaveSelection('" + strBaseElementID + "');";
   }
	strOnClickJScript += "RTE_ExecuteCommandOnSelection('" + strBaseElementID + "', '" + strCommand + "', " + fUserInterface + ", null );";
	if (fOnlyIfSelectionActive){
		strOnClickJScript += "}";
	}
	return RTE_TB_GenerateToolBarButtonHtml(strBaseElementID, strCommand, strOnClickJScript, strImageUrl, strText, strToolTip);
}
function RTE_TB_SetButtonCheck(elemButton){
	elemButton.className = RTE_RemoveClassFromClassList(elemButton.className, g_strRTEUnselectedClassName);
	elemButton.className = RTE_AddClassToClassList(elemButton.className, g_strRTESelectedClassName);
}
function RTE_TB_ClearButtonCheck(elemButton){
	elemButton.className = RTE_RemoveClassFromClassList(elemButton.className, g_strRTESelectedClassName);
	elemButton.className = RTE_AddClassToClassList(elemButton.className, g_strRTEUnselectedClassName);
}
function RTE_TB_SetButtonDisabled(elemButton){
	elemButton.className = RTE_AddClassToClassList(elemButton.className, g_strRTEDisabledClassName);
	elemButton.disabled = true;
	var elemChildLink = elemButton.children(0);
	if ((elemChildLink != null) && (elemChildLink.tagName == "A")){
		elemChildLink.disabled = true;
	}
}
function RTE_TB_ClearButtonDisabled(elemButton){
	elemButton.disabled = false;
	var elemChildLink = elemButton.children(0);
	if ((elemChildLink != null) && (elemChildLink.tagName == "A")){
		elemChildLink.disabled = false;
	}
	elemButton.className = RTE_RemoveClassFromClassList(elemButton.className, g_strRTEDisabledClassName);
}
function RTE_TB_SetButtonHover(elemButton){
	elemButton.className = RTE_AddClassToClassList(elemButton.className, g_strRTEHoverClassName);
}
function RTE_TB_ClearButtonHover(elemButton){
	elemButton.className = RTE_RemoveClassFromClassList(elemButton.className, g_strRTEHoverClassName);
}
function RTE_TB_SetCheckFromCommandValue(strBaseElementID, docEditor, strCommand){
	var btn = RTE_TB_GetToolBarButton(strBaseElementID, strCommand);
	if (docEditor.queryCommandSupported(strCommand) && docEditor.queryCommandValue(strCommand)){
		RTE_TB_SetButtonCheck(btn);
	}
	else
	{
		RTE_TB_ClearButtonCheck(btn);
	}
}
function RTE_TB_SetEnabledFromCommandEnabled(strBaseElementID, docEditor, strCommand, fOnlyIfSelectionActive){
	var fSelectionTestResults = true;
	if (fOnlyIfSelectionActive){
		var sel = docEditor.selection;
		if ((null == sel) || ('none' == sel.type))
		{
			fSelectionTestResults = false;
		}
		else
		{
			var rngSel = docEditor.selection.createRange();
			if ((rngSel != null) && (rngSel.text != null) && (0 >= rngSel.text.length))
			{
				fSelectionTestResults = false;
			}
		}
	}
	var btn = RTE_TB_GetToolBarButton(strBaseElementID, strCommand);
	if ((fSelectionTestResults) && (docEditor.queryCommandEnabled(strCommand))){
		RTE_TB_ClearButtonDisabled(btn);
	}
	else
	{
		RTE_TB_SetButtonDisabled(btn);
	}
}
function RTE_TB_OnMouseOver(elemButton){
	if (0 > elemButton.className.indexOf(g_strRTEDisabledClassName)){
		RTE_TB_SetButtonHover(elemButton);
	}
}
function RTE_TB_OnMouseOut(elemButton){
	RTE_TB_ClearButtonHover(elemButton);
}
function RTE_TB_OnFocus(strBaseElementID, elemButton){
	g_strRTEToolBarButtonWithTheFocus = elemButton.parentElement.id;
}
function RTE_TB_OnBlur(strBaseElementID, elemButton){
	g_strRTEToolBarButtonWithTheFocus = null;
}
var g_strRTEDDBaseElementID = null;
var g_strRTEDDButtonMnemonic = null;
var g_fRTEFirstCallToGetMenu = true;
var g_elemRTEHighlightedMenuItem = null;
var g_iRTEHighlightedMenuItem = -1;
var g_iRTEMenuItemMax = -1;
function RTE_DD_GetMenuElement(){
	var elemMenu = document.getElementById(g_strRTETextEditorPullDownMenuID);
	if ((null == elemMenu) && (document.parentWindow != null) && (document.parentWindow.document != null)){
		elemMenu = document.parentWindow.parent.document.getElementById(g_strRTETextEditorPullDownMenuID);
	}
	return elemMenu;
}
function RTE_DD_GetMenuFrame(){
	var ifmMenu = null;
	var elemMenu = RTE_DD_GetMenuElement();
	if (null != elemMenu){
		if (document.frames.length > 0)
		{
			ifmMenu = document.frames(g_strRTETextEditorPullDownMenuID);
		}
		else
		{
			if ((document.parentWindow != null) && (document.parentWindow.frames != null))
			{
				ifmMenu = document.parentWindow.parent.document.frames(g_strRTETextEditorPullDownMenuID);
			}
		}
	}
	if (null == ifmMenu){
		if (g_fRTEFirstCallToGetMenu)
		{
			g_fRTEFirstCallToGetMenu = false;
			return null;
		}
	}
	return ifmMenu;
}
function RTE_DD_GetMenuBaseElementID(){
	return RTE_DD_GetMenuElement().getAttribute(g_strRTEBaseElementIDAttributeName);
}
function RTE_DD_GetMenuButtonMnemonic(){
	return RTE_DD_GetMenuElement().getAttribute(g_strRTEButtonMnemonicAttributeName);
}
function RTE_DD_MenuIsOpen(){
	if ("" == RTE_DD_GetMenuElement().style.display){
		return true;
	}
	return false;
}
var g_fRTEMenuMoved = false;
function RTE_DD_OpenMenu(strBaseElementID, strButtonMnemonic, strMenuHtml, cMenuItems){
	var elemMenu = RTE_DD_GetMenuElement();
	var ifmMenu = RTE_DD_GetMenuFrame();
	if (!g_fRTEMenuMoved){
		g_elemRTELastTextAreaConverted.insertAdjacentElement("afterEnd", elemMenu);
		elemMenu = RTE_DD_GetMenuElement();
		ifmMenu = RTE_DD_GetMenuFrame();
	}
	if ((g_strRTEDDBaseElementID == strBaseElementID) && (g_strRTEDDButtonMnemonic == strButtonMnemonic)){
		RTE_DD_CloseMenu();
		RTE_RestoreSelection(strBaseElementID);
		return;
	}
	if ((null != g_strRTEDDBaseElementID) && (null != g_strRTEDDButtonMnemonic)){
		RTE_DD_CloseMenu();
	}
	g_strRTEDDBaseElementID = strBaseElementID;
	g_strRTEDDButtonMnemonic = strButtonMnemonic;
	g_iRTEMenuItemMax = cMenuItems - 1;
   if (browseris.ie5up && !browseris.ie55up && !browseris.ie6up)
   {
   	RTE_SaveSelection(strBaseElementID);
   }
	var elemToolBarButton = RTE_TB_GetToolBarButton(strBaseElementID, strButtonMnemonic);
	elemMenu.setAttribute(g_strRTEBaseElementIDAttributeName, strBaseElementID);
	elemMenu.setAttribute(g_strRTEButtonMnemonicAttributeName, strButtonMnemonic);
	elemMenu.setAttribute(g_strRTEMenuOpeningAttributeName, "1");
	elemMenu.style.top = "";
	elemMenu.style.left = "";
	elemMenu.style.height = "";
	elemMenu.style.width = "";
	var strWebLocale = RTE_GetWebLocale(strBaseElementID);
	ifmMenu.document.open("text/html", "replace");
	ifmMenu.document.write("<html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"" + RTE_GetServerRelativeStylesheetUrl("ows.css", strWebLocale) + 
			"\"><script language=\"javascript\" src=\"" + RTE_GetServerRelativeScriptUrl("ows.js", strWebLocale) + "\"></script></head>" +
			"<body class=\"ms-rtetoolbarmenu\" " + g_strRTECommandToExecuteAttributeName + "=\"x\" " + g_strRTECommandValueAttributeName + "=\"x\"><div class=\"ms-rtetoolbarmenu\" id=\"divAroundMenu\">" +
			strMenuHtml + "</div></body></html>");
	ifmMenu.document.close();
	elemMenu = RTE_DD_GetMenuElement();
	ifmMenu = RTE_DD_GetMenuFrame();
	ifmMenu.document.body.onfocus = new Function("RTE_DD_OnFocus('" + strBaseElementID + "');");
	ifmMenu.document.body.onblur = new Function("RTE_DD_OnBlur('" + strBaseElementID + "');");
	ifmMenu.document.body.onkeydown = new Function("RTE_DD_OnKeyDown(this);");
	elemMenu.style.border = "0px";
	ifmMenu.document.body.style.border = "1px solid black";
	elemMenu.style.display = "";
	var elemMenuDivInFrame = ifmMenu.document.all("divAroundMenu");
	var elemMenuTable = ifmMenu.document.all(g_strRTEMenuTableElementName);
	var cyDropDownMax = 300;
	var rgnToolBarButtonCoordinates = RTE_GetElementWindowCoordinates(elemToolBarButton);
	var xToolBarButton = rgnToolBarButtonCoordinates[g_iRTELeft];
	var yToolBarButton = rgnToolBarButtonCoordinates[g_iRTETop];
	var cxToolBarButton = elemToolBarButton.offsetWidth;
	var cyToolBarButton = elemToolBarButton.offsetHeight;
	var cxDropDown = elemMenuTable.scrollWidth + 4; 
	var cyDropDown = elemMenuTable.scrollHeight + 4;
	var cxBody = elemMenu.document.documentElement.offsetWidth;
	var cyBody = elemMenu.document.documentElement.offsetHeight;
	var yDropDown = rgnToolBarButtonCoordinates[g_iRTETop] + elemToolBarButton.offsetHeight;
	var xDropDown = rgnToolBarButtonCoordinates[g_iRTELeft];
	var fNeedVerticalScrollBar = false;
	if (cyDropDown > cyDropDownMax){
		fNeedVerticalScrollBar = true;
		cyDropDown = cyDropDownMax;
	}
	if (cyDropDown > cyBody){
		fNeedVerticalScrollBar = true;
		cyDropDown = cyBody - 30;
	}
	if (yDropDown + cyDropDown > cyBody){
		yDropDown =  rgnToolBarButtonCoordinates[g_iRTETop] - cyDropDown - 10;
		if (0 > yDropDown)
		{
			yDropDown = 0;
		}
	}
	if (xDropDown + cxDropDown > cxBody){
		xDropDown = cxBody - cxDropDown - 30;
		if (0 > xDropDown)
		{
			xDropDown = 0;
		}
	}
	if (fNeedVerticalScrollBar){
		ifmMenu.document.body.scroll = "yes";
		cxDropDown += 22; 
	}
	else
	{
		ifmMenu.document.body.scroll = "";
	}
	elemMenu.style.left = xDropDown;
	elemMenu.style.top = yDropDown;
	elemMenu.style.width = cxDropDown;
	elemMenu.style.height = cyDropDown;
	RTE_DD_SetHighlightOnMenuItem(RTE_DD_GetMenuItem(0));
}
function RTE_DD_CloseMenu(){
	var elemMenu = RTE_DD_GetMenuElement();
	if (null == elemMenu){
		return;
	}
	elemMenu.style.display = "none";
	if ((g_strRTEDDBaseElementID != null) && (g_strRTEDDButtonMnemonic != null)){
		RTE_TB_ClearButtonHover(RTE_TB_GetToolBarButton(g_strRTEDDBaseElementID, g_strRTEDDButtonMnemonic));
	}
	g_strRTEDDBaseElementID = null;
	g_strRTEDDButtonMnemonic = null;
	g_elemRTEHighlightedMenuItem = null;
	g_iRTEHighlightedMenuItem = -1;
	g_iRTEMenuItemMax = -1;
}
function RTE_DD_GenerateMenuOpenHtml(strWebLanguage){
	if (strWebLanguage == "1037" || strWebLanguage == "1025")
		return "<table dir=\"rtl\" id=\"" + g_strRTEMenuTableElementName + "\"cellspacing=0 cellpading=0 border=0><tr>";
	else
		return "<table id=\"" + g_strRTEMenuTableElementName + "\"cellspacing=0 cellpading=0 border=0><tr>";
}
function RTE_DD_GenerateMenuCloseHtml(){
	return "</tr></table>";
}
function RTE_DD_GenerateMenuItemHtml(cColumns, iMenuItem, strCommandToPerform, strCommandValue, strMenuItemHtml, strMenuItemToolTip){
	var strHtmlRet = "";
	if (((1 >= cColumns) || ((1 < cColumns) && (0 == (iMenuItem % cColumns)))) && (0 != iMenuItem)){
		strHtmlRet = "</tr><tr>";
	}
	strHtmlRet += "<td class=\"ms-toolbar " + g_strRTEUnselectedClassName + "\" nowrap id=\"" + g_strRTEMenuItemBaseName + iMenuItem + "\" " +
			g_strRTEMenuItemAttributeName + "=\"" + iMenuItem +"\" onfocus=\"RTE_DD_Item_OnFocus(this) ;return false;\" onclick=\"return RTE_DD_StartCmdExec('"+ strCommandToPerform + "', '" + strCommandValue +
			"'); return false;\" onmouseover=\"RTE_DDItem_OnMouseOver(this);\" onmouseout=\"RTE_DDItem_OnMouseOut(this);\"><a TABINDEX=-1 href=\"#\" class=\"" + g_strRTEUnselectedClassName + 
			"\" style=\"text-decoration: none; color: black; cursor: hand;\" title=\"" + strMenuItemToolTip + "\" onblur=\"RTE_DD_Item_OnBlur(); return false;\" onfocus=\"RTE_DD_Item_OnFocus(this.parentElement); return false;\" >" +
			strMenuItemHtml + "</a></td>";
	return strHtmlRet;
}
function RTE_DD_GetMenuItem(iMenuItem){
	var elemMenuItem = RTE_DD_GetMenuFrame().document.all(g_strRTEMenuItemBaseName + iMenuItem);
	return elemMenuItem;
}
function RTE_DD_GetHighlightedMenuItem(){
	return g_elemRTEHighlightedMenuItem;
}
function RTE_DD_ClearHighlightOnMenuItem(elemMenuItem){
	RTE_TB_OnMouseOut(elemMenuItem);
}
function RTE_DD_ClearHighlightedMenuItem(){
	RTE_DD_ClearHighlightOnMenuItem(RTE_DD_GetHighlightedMenuItem());
}
function RTE_DD_SetHighlightOnMenuItem(elemMenuItem){
	if (!RTE_DD_MenuIsOpen()){
		return;
	}
	var strMenuItemAttributeValue = elemMenuItem.getAttribute(g_strRTEMenuItemAttributeName);
	if (null != g_elemRTEHighlightedMenuItem){
		RTE_DD_ClearHighlightOnMenuItem(g_elemRTEHighlightedMenuItem)
		g_elemRTEHighlightedMenuItem = null;
		g_iRTEHighlightedMenuItem = -1;
	}
	RTE_TB_OnMouseOver(elemMenuItem);
	elemMenuItem.children(0).focus();
	g_elemRTEHighlightedMenuItem = elemMenuItem;
	g_iRTEHighlightedMenuItem = parseInt(strMenuItemAttributeValue);
}
function RTE_DD_SetHighlightOnPrevMenuItem(cItemsToMove){
	var elemHighlighted = RTE_DD_GetHighlightedMenuItem();
	var strMenuItemAttributeValue = elemHighlighted.getAttribute(g_strRTEMenuItemAttributeName);
	var iMenuItem = parseInt(strMenuItemAttributeValue);
	if (iMenuItem > 0){
		var iNewMenuItem = Math.max(iMenuItem - cItemsToMove, 0);
		var elemPrev = RTE_DD_GetMenuItem(iNewMenuItem);
		RTE_DD_SetHighlightOnMenuItem(elemPrev);
	}
}
function RTE_DD_SetHighlightOnNextMenuItem(cItemsToMove){
	var elemHighlighted = RTE_DD_GetHighlightedMenuItem();
	var strMenuItemAttributeValue = elemHighlighted.getAttribute(g_strRTEMenuItemAttributeName);
	var iMenuItem = parseInt(strMenuItemAttributeValue);
	if (iMenuItem < g_iRTEMenuItemMax){
		var iNewMenuItem = Math.min(iMenuItem + cItemsToMove, g_iRTEMenuItemMax);
		var elemNext = RTE_DD_GetMenuItem(iNewMenuItem);
		RTE_DD_SetHighlightOnMenuItem(elemNext);
	}
}
function RTE_DD_StartCmdExec(strCommandToPerform, strCommandValue){
	document.body.setAttribute(g_strRTECommandToExecuteAttributeName, strCommandToPerform);
	document.body.setAttribute(g_strRTECommandValueAttributeName, strCommandValue);
	document.body.focus();
	RTE_DD_SetHighlightOnMenuItem(RTE_DD_GetMenuItem(0));
	return false;
}
function RTE_DD_OnFocus(){
}
function RTE_DD_OnBlur(){
	var elemMenu = RTE_DD_GetMenuElement();
	if (elemMenu.getAttribute(g_strRTEMenuOpeningAttributeName) == "1"){
		return;
	}
	var strBaseElementID = RTE_DD_GetMenuBaseElementID();
	var ifmMenu = RTE_DD_GetMenuFrame();
	var strCommandToPerform = ifmMenu.document.body.getAttribute(g_strRTECommandToExecuteAttributeName);
	var strCommandValue = ifmMenu.document.body.getAttribute(g_strRTECommandValueAttributeName);
	RTE_DD_CloseMenu();
	RTE_GiveEditorFocus(strBaseElementID);
	RTE_RestoreSelection(strBaseElementID);
	if ("x" != strCommandToPerform){
		RTE_ExecuteCommandOnSelection(RTE_DD_GetMenuBaseElementID(), strCommandToPerform, false, strCommandValue);
	}
}
function RTE_DD_Item_OnFocus(elemMenuItemCell){
	var elemMenu = RTE_DD_GetMenuElement();
	elemMenu.setAttribute(g_strRTEMenuOpeningAttributeName, "0");
	RTE_DD_SetHighlightOnMenuItem(elemMenuItemCell);
}
function RTE_DD_Item_OnBlur(){
	g_elemRTEHighlightedMenuItem = null;
	g_iRTEHighlightedMenuItem = -1;
	window.setTimeout("RTE_OnItemBlurTestCloseMenu()", 30);
}
function RTE_OnItemBlurTestCloseMenu(){
	if (null == g_elemRTEHighlightedMenuItem){
		RTE_DD_CloseMenu();
	}
}
function RTE_DD_OnKeyDown(elem){
	var evtSource = elem.document.parentWindow.event;
	var nKeyCode = evtSource.keyCode;
	var fAltKey = evtSource.altKey;
	var fCtrlKey = evtSource.ctrlKey;
	var fShiftKey = evtSource.shiftKey;
	if (!fCtrlKey && !fAltKey && !fShiftKey){
		switch (nKeyCode)
		{
			case 27: 
				var strBaseElementID = g_strRTEDDBaseElementID;	
				RTE_DD_CloseMenu();
				RTE_GiveEditorFocus(strBaseElementID);
				RTE_ResetAllToolBarStates(strBaseElementID);
				break;
			case 38: 
				evtSource.returnValue = false;
				RTE_DD_SetHighlightOnPrevMenuItem(1);
				break;
			case 9: 
			   evtSource.returnValue = false;
			   break;
			case 40: 
				evtSource.returnValue = false;
				RTE_DD_SetHighlightOnNextMenuItem(1);
				break;
			case 33: 
				evtSource.returnValue = false;
				RTE_DD_SetHighlightOnPrevMenuItem(12);
				break;
			case 34: 
				evtSource.returnValue = false;
				RTE_DD_SetHighlightOnNextMenuItem(12);
				break;
			case 36: 
				evtSource.returnValue = false;
				break;
			case 35: 
				evtSource.returnValue = false;
				break;
		}
	} 
	if (!fCtrlKey && !fAltKey && fShiftKey){
		switch (nKeyCode)
		{
			case 9: 
				evtSource.returnValue = false;
				break;
		}
	} 
}
function RTE_DDItem_OnMouseOver(elemTD){
	if (null != elemTD){
		RTE_DD_SetHighlightOnMenuItem(elemTD);
	}
}
function RTE_DDItem_OnMouseOut(elemTD){
	if (null != elemTD){
		RTE_DD_ClearHighlightOnMenuItem(elemTD);
	}
}
var g_rgstrRTEMenuHtml = new Array();
var g_strRTEColorMatrixMenuItemPrefixHtml = "<div unselectable=\"on\" style=\"width: 10px; height: 10px; background-color: ";
var g_strRTEColorMatrixMenuItemSufffixHtml = ";\"><img unselectable=\"on\" width=10 height=10 src=\"" + RTE_GetServerRelativeUnlocalizedImageUrl("blank.gif") + "\" alt=\"%TOOLTIP%\"></div>";
function RTE_DD_OpenFontNameOrSizeSelector(strBaseElementID, strWebLanguage, fGeneratingFontNameSelector){
	var rngSelection = RTE_GetSelection(strBaseElementID);
	var strSelectionFontName = rngSelection.queryCommandValue(g_strRTEFontNameMnemonic);
	var strSelectionFontSize = rngSelection.queryCommandValue(g_strRTEFontSizeMnemonic);
	var fSelectionBold = rngSelection.queryCommandValue(g_strRTEBoldMnemonic);
	var fSelectionItalic = rngSelection.queryCommandValue(g_strRTEItalicMnemonic);
	var strMenuHtml = "";
	var cMenuItems = -1;
	var strButtonMnemonic = "";
	if(!window.rgoMenuInfo_mgr)rgoMenuInfo_mgr=[];
	if(!window.rgoMenuInfo_mgr[fGeneratingFontNameSelector])
	rgoMenuInfo_mgr[fGeneratingFontNameSelector] = RTE_DD_GetFontNameOrSizeSelectorUnformattedHtml(fGeneratingFontNameSelector, strWebLanguage);
	var rgoMenuInfo=rgoMenuInfo_mgr[fGeneratingFontNameSelector];
	strMenuHtml = rgoMenuInfo[0];
	cMenuItems = rgoMenuInfo[1];
	if (fGeneratingFontNameSelector){
		strMenuHtml = strMenuHtml.replace(new RegExp(g_strRTEFontSizeToken, "g"), Math.min(Math.max(strSelectionFontSize, 2), 5));
		strButtonMnemonic = g_strRTEFontNameMnemonic;
	}
	else
	{
		strMenuHtml = strMenuHtml.replace(new RegExp(g_strRTEFontNameToken, "g"), strSelectionFontName);
		strButtonMnemonic = g_strRTEFontSizeMnemonic;
	}
	var strBegBoldItalicInsert = "";
	var strEndBoldItalicInsert = "";
	if (fSelectionBold){
		strBegBoldItalicInsert = "<b>";
		strEndBoldItalicInsert = "</b>";
	}
	if (fSelectionItalic){
		strBegBoldItalicInsert += "<i>";
		strEndBoldItalicInsert += "</i>";
	}
	strMenuHtml = strMenuHtml.replace(new RegExp(g_strRTEBegBoldItalicToken, "g"), strBegBoldItalicInsert);
	strMenuHtml = strMenuHtml.replace(new RegExp(g_strRTEEndBoldItalicToken, "g"), strEndBoldItalicInsert);
	RTE_DD_OpenMenu(strBaseElementID, strButtonMnemonic, strMenuHtml, cMenuItems);
}
function RTE_DD_GetFontNameOrSizeSelectorUnformattedHtml(fGeneratingFontNameSelector, strWebLanguage){
	var strCommandToPerform;
	if (fGeneratingFontNameSelector){
		strCommandToPerform = g_strRTEFontNameMnemonic;
	}
	else
	{
		strCommandToPerform = g_strRTEFontSizeMnemonic;
	}
	var strMenuHtml = g_rgstrRTEMenuHtml[strCommandToPerform];
	if (null != strMenuHtml){
		return strMenuHtml;
	}
	strMenuHtml = RTE_DD_GenerateMenuOpenHtml(strWebLanguage);
	var cMenuItems = -1;
	if (fGeneratingFontNameSelector){
		var rgstrClientFonts = RTE_GetSortedFontNames();
		cMenuItems = rgstrClientFonts.length;
		var iFont;
		for (iFont = 0; iFont < cMenuItems; iFont++)
		{
			strMenuHtml += RTE_DD_GenerateMenuItemHtml(1, iFont, strCommandToPerform, rgstrClientFonts[iFont],
					g_strRTEBegBoldItalicToken + "<font size=\"" + g_strRTEFontSizeToken + "\" face=\"" + rgstrClientFonts[iFont] + "\">" +
					rgstrClientFonts[iFont] + "</font>" + g_strRTEEndBoldItalicToken, "");
		}
	}
	else
	{
		cMenuItems = 7;
		var nFontSize;
		for (nFontSize = 1; nFontSize <= cMenuItems; nFontSize++)
		{
			strMenuHtml += RTE_DD_GenerateMenuItemHtml(1, nFontSize - 1, strCommandToPerform, nFontSize,
					g_strRTEBegBoldItalicToken + "<font size=\"" + nFontSize + "\" face=\"" + g_strRTEFontNameToken + "\">" +
					nFontSize + " - " + L_ExampleText_TEXT + "</font>" + g_strRTEEndBoldItalicToken, "");
		}
	}
	strMenuHtml += RTE_DD_GenerateMenuCloseHtml();
	g_rgstrRTEMenuHtml[strCommandToPerform] = new Array(strMenuHtml, cMenuItems);
	return g_rgstrRTEMenuHtml[strCommandToPerform];
}
function RTE_DD_OpenForeColorSelector(strBaseElementID, strWebLanguage){
	RTE_DD_OpenMenu(strBaseElementID, g_strRTEForeColorMnemonic, RTE_DD_GetColorSelectorHtml(g_strRTEForeColorMnemonic, strWebLanguage), g_rgrgstrRTEColorMatrix.length);
}
function RTE_DD_OpenBackColorSelector(strBaseElementID, strWebLanguage){
	RTE_DD_OpenMenu(strBaseElementID, g_strRTEBackColorMnemonic, RTE_DD_GetColorSelectorHtml(g_strRTEBackColorMnemonic, strWebLanguage), g_rgrgstrRTEColorMatrix.length);
}
function RTE_DD_GetColorSelectorHtml(strCommandToPerform, strWebLanguage){
	var strMenuHtml = g_rgstrRTEMenuHtml[strCommandToPerform];
	if (null == strMenuHtml){
		strMenuHtml = RTE_DD_GenerateMenuOpenHtml(strWebLanguage);
		var iColor;
		for (iColor = 0; iColor < g_rgrgstrRTEColorMatrix.length; iColor++)
		{
			strMenuHtml += RTE_DD_GenerateMenuItemHtml(g_cRTEColorMatrixColumns, iColor, strCommandToPerform,
					g_rgrgstrRTEColorMatrix[iColor][1], g_strRTEColorMatrixMenuItemPrefixHtml + g_rgrgstrRTEColorMatrix[iColor][1] +
					g_strRTEColorMatrixMenuItemSufffixHtml.replace("%TOOLTIP%", g_rgrgstrRTEColorMatrix[iColor][0]), "");
		}
		strMenuHtml += RTE_DD_GenerateMenuCloseHtml();
		g_rgstrRTEMenuHtml[strCommandToPerform] = strMenuHtml;
	}
	return strMenuHtml;
}
var g_cRTEColorMatrixColumns = 8;
var g_rgrgstrRTEColorMatrix = new Array(
	new Array(L_Black_TEXT, "#000000"), new Array(L_Brown_TEXT, "#993300"), new Array(L_OliveGreen_TEXT, "#333300"), new Array(L_DarkGreen_TEXT, "#003300"),
	new Array(L_DarkTeal_TEXT, "#003366"), new Array(L_DarkBlue_TEXT, "#000080"), new Array(L_Indigo_TEXT, "#333399"), new Array(L_Gray80_TEXT, "#333333"),
	new Array(L_DarkRed_TEXT, "#800000"), new Array(L_Orange_TEXT, "#ff6600"), new Array(L_DarkYellow_TEXT, "#808000"), new Array(L_Green_TEXT, "#008000"),
	new Array(L_Teal_TEXT, "#008080"), new Array(L_Blue_TEXT, "#0000FF"), new Array(L_BlueGray_TEXT, "#666699"), new Array(L_Gray50_TEXT, "#808080"),
	new Array(L_Red_TEXT, "#FF0000"), new Array(L_LightOrange_TEXT, "#ff9900"), new Array(L_Lime_TEXT, "#99cc00"), new Array(L_SeaGreen_TEXT, "#339966"),
	new Array(L_Aqua_TEXT, "#33cccc"), new Array(L_LightBlue_TEXT, "#3366ff"), new Array(L_Violet_TEXT, "#800080"), new Array(L_Gray40_TEXT, "#969696"),
	new Array(L_Pink_TEXT, "#FF00FF"), new Array(L_Gold_TEXT, "#ffcc00"), new Array(L_Yellow_TEXT, "#FFFF00"), new Array(L_BrightGreen_TEXT, "#00FF00"),
	new Array(L_Turquoise_TEXT, "#00FFFF"), new Array(L_SkyBlue_TEXT, "#00ccff"), new Array(L_Plum_TEXT, "#993366"), new Array(L_Gray25_TEXT, "#C0C0C0"),
	new Array(L_Rose_TEXT, "#ff99cc"), new Array(L_Tan_TEXT, "#ffcc99"), new Array(L_LightYellow_TEXT, "#ffff99"), new Array(L_LightGreen_TEXT, "#ccffcc"),
	new Array(L_LightTurquoise_TEXT, "#ccffff"), new Array(L_PaleBlue_TEXT, "#99ccff"), new Array(L_Lavender_TEXT, "#cc99ff"), new Array(L_White_TEXT, "#FFFFFF") );
function RTE_GetDialogHelper(){
	return document.all(g_strRTEDialogHelperID);
}
function RTE_GetSortedFontNames(){
	var rgstrFontNamesRet = new Array();
	var dh = RTE_GetDialogHelper();
	if ((null != dh) && (null != dh.fonts) && (0 < dh.fonts.count)){
		var iFont;
		for (iFont = 1; iFont < dh.fonts.count; iFont++)
		{
			RTE_InsertIntoSortedArrayIfValid(dh.fonts(iFont), rgstrFontNamesRet);
		}
	}
	else
	{
		RTE_InsertIntoSortedArrayIfValid(L_Font1_TEXT, rgstrFontNamesRet);
		RTE_InsertIntoSortedArrayIfValid(L_Font2_TEXT, rgstrFontNamesRet);
		RTE_InsertIntoSortedArrayIfValid(L_Font3_TEXT, rgstrFontNamesRet);
		RTE_InsertIntoSortedArrayIfValid(L_Font4_TEXT, rgstrFontNamesRet);
		RTE_InsertIntoSortedArrayIfValid(L_Font5_TEXT, rgstrFontNamesRet);
		RTE_InsertIntoSortedArrayIfValid(L_Font6_TEXT, rgstrFontNamesRet);
		RTE_InsertIntoSortedArrayIfValid(L_Font7_TEXT, rgstrFontNamesRet);
		RTE_InsertIntoSortedArrayIfValid(L_Font8_TEXT, rgstrFontNamesRet);
	}
	return rgstrFontNamesRet;
}
function RTE_IsChildOfElement(elemSearchingFor, elemToSearch){
	var rgelemChildren = elemToSearch.children;
	if ((null == rgelemChildren) || (0 >= rgelemChildren.length)){
		return false;
	}
	var iChild = 0;
	for (iChild = 0; iChild < rgelemChildren.length; iChild++){
		var elemChild = rgelemChildren[iChild];
		if (elemChild == elemSearchingFor)
		{
			return true;
		}
		if (RTE_IsChildOfElement(elemSearchingFor, elemChild))
		{
			return true;
		}
	}
	return false;
}
function RTE_FindParentElementWithTag(elem, strTagName){
	if (null == elem.parentElement){
		return null;
	}
	return RTE_FindParentElementOrSelfWithTag(elem.parentElement, strTagName);
}
function RTE_FindParentElementOrSelfWithTag(elem, strTagName){
	if (elem.tagName == strTagName){
		return elem;
	}
	else
	{
		if (null == elem.parentElement)
		{
			return null;
		}
		return RTE_FindParentElementOrSelfWithTag(elem.parentElement, strTagName);
	}
}
var g_iRTELeft = 0;
var g_iRTETop = 1;
var g_iRTEWidth = 2;
var g_iRTEHeight = 3;
var g_iRTERight = 4;
var g_iRTEBottom = 5;
function RTE_GetElementWindowCoordinates(elem){
	var xLeft = 0;
	var yTop = 0;
	var cxWidth = elem.offsetWidth;
	var cyHeight = elem.offsetHeight;
	do
	{
		xLeft += elem.offsetLeft;
		yTop += elem.offsetTop;
		if (null == elem.offsetParent)
		{
			xLeft += parseInt(elem.currentStyle.marginLeft);
			yTop += parseInt(elem.currentStyle.marginTop);
		}
		elem = elem.offsetParent;
	}
	while (elem != null);
	var rgnRet = new Array();
	rgnRet[g_iRTELeft] = xLeft;
	rgnRet[g_iRTETop] = yTop;
	rgnRet[g_iRTEWidth] = cxWidth;
	rgnRet[g_iRTEHeight] = cyHeight;
	rgnRet[g_iRTERight] = xLeft + cxWidth - 1;
	rgnRet[g_iRTEBottom] = yTop + cyHeight - 1;
	return rgnRet;
}
function RTE_GetServerRelativeUnlocalizedImageUrl(strImageFileName){
   return "APPRES.ashx/1664805296/" + strImageFileName;
}
function RTE_GetServerRelativeImageUrl(strImageFileName){
	return "APPRES.ashx/1664805296/" + strImageFileName;
}
function RTE_GetServerRelativeStylesheetUrl(strStylesheetFileName, strWebLocale){
   return "APPRES.ashx/1664805296/" + strStylesheetFileName;
}
function RTE_GetServerRelativeScriptUrl(strScriptFileName, strWebLocale){
   return "APPRES.ashx/1664805296/" + strScriptFileName;
}
function RTE_StripDoubleSpaces(str){
	while (str.indexOf("  ") != -1){
		str = str.replace(/  /g, " ");
	}
	return str;
}
function RTE_AddClassToClassList(strClassList, strNewClass){
	if (0 <= strClassList.indexOf(strNewClass)){
		return strClassList;
	}
	return RTE_StripDoubleSpaces(strClassList + " " + strNewClass);
}
function RTE_ReplaceClassInClassList(strClassList, strOldClass, strNewClass){
	var iSel = strClassList.indexOf(strOldClass);
	var strAheadOfOldClass = "";
	if (0 < iSel){
		return RTE_StripDoubleSpaces(strClassList.substr(0, iSel) + " " + strNewClass + " " + strClassList.substr(iSel + strOldClass.length));
	}
	return RTE_AddClassToClassList(strClassList, strNewClass);
}
function RTE_RemoveClassFromClassList(strClassList, strClass){
	return RTE_ReplaceClassInClassList(strClassList, strClass, "");
}
function RTE_AddOrRemoveClassFromClassList(fAdd, strClassList, strClass){
	if (fAdd){
		return RTE_AddClassToClassList(strClassList, strClass);
	}
	return RTE_RemoveClassFromClassList(strClassList, strClass);
}
function RTE_InsertIntoSortedArrayIfValid(strInsert, rgstrDest){
	if ((null == strInsert) || (0 == strInsert.length)){
		return;
	}
	var i = 0;
	for (i = rgstrDest.length; i >= 0; i--){
		if ((0 == i) || (rgstrDest[i - 1] < strInsert))
		{
			rgstrDest[i] = strInsert;
			return;
		}
		else
		{
			rgstrDest[i] = rgstrDest[i - 1];
		}
	}
}
function FormTabIndex(){
    if (window.formTabIndex) {
        if (formTabIndex == -1)
            return "";
        return "tabindex=" + formTabIndex;
    }
    return "tabindex=1";
}
function StAttrQuote(st){
	st = st.toString();
	st = st.replace(/&/g, '&amp;');
	st = st.replace(/\"/g, '&quot;'); 
	st = st.replace(/\r/g, '&#13;');
	return '"' + st + '"';
}
function STSHtmlEncode(str){
    var strOut = "";
    var ix = 0;
    for (ix = 0; ix < str.length; ix++)
    {
	    var ch = str.charAt(ix);
        switch (ch)
        {
            case '<':
                strOut += "&lt;";
                break;
            case '>':
                strOut += "&gt;";
                break;
            case '&':
                strOut += "&amp;";
                break;
            case '\"':
                strOut += "&quot;";
                break;
            case '\'':
                strOut += "&#39;";
                break;
            default:
                strOut += ch;
                break;
        }
   }
   return strOut;
}
if(window.RTE_onload){RTE_onload();};
