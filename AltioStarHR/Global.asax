<%@ Application Language="C#" %>

<script runat="server">
    
    
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        try
        {

        // XModule.AppInitIS91Services();
        }
        catch (IS91.Services.ServiceException srex1)
        {
            IS91.Services.Logger.LogThis(srex1);
            //if (srex1.ErrNumber == 402 || srex1.ErrNumber == 102)
            //{
            IS91.Services.Web.WebModule.WriteHttpAppError(HttpContext.Current.Response, srex1.Message);
            //}
        }
        catch (Exception ex)
        {
            IS91.Services.Logger.LogThis(ex);
        }
    }
   // private static DateTime ResourceFileDT = GetResourceFileLMDt();
    //private static StringBuilder Digestchallenge = null;
    //private static StringBuilder NTLMchallenge = null;
    //private static Boolean isNTLM = false; 
    void Application_PostMapRequestHandler(object sender, EventArgs e)
    {
        var app = (HttpApplication)sender;
        var handler = (IHttpHandler)app.Context.Handler;
        Page page = handler as Page;

        if (page != null)
        {
            page.Load += Page_Load;
        }
    }
    private void Page_Load(object sender, EventArgs e)
    {
        var page = (Page)HttpContext.Current.Handler;
        var smg = ScriptManager.GetCurrent(page);
        if (smg != null && (page.IsPostBack == false || smg.IsInAsyncPostBack == false))
        {
            ScriptManager.RegisterOnSubmitStatement(page, page.GetType(), "IE10ImgFloatFix", "IE10ImgFloatFix();");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "IE10ImgFloatFix_func", "function IE10ImgFloatFix() {try {var o = Sys.WebForms.PageRequestManager._instance;var s = o._additionalInput;s = s.replace(/(.y=\\d+)([.]\\d+)?/g, '$1');s = s.replace(/(.x=\\d+)([.]\\d+)?/g, '$1');o._additionalInput = s;} catch (ex){}}", true);
        }
    }

    private void SessionState_Start(object sender, EventArgs e)
    {
         resetSessioncNounce();
            //checkASNETSTATEService()
            //For Session Timeout; if required the callback can be hooked
            if(IS91.Services.Web.WebModule.CacheManager.GetCacheItem("c" + HttpContext.Current.Session.SessionID)==null)
            {
                //IS91.Services.Web.WebModule.CacheManager.Add2Cache("c" + HttpContext.Current.Session.SessionID, HttpContext.Current.Session.SessionID, true, HttpContext.Current.Session.Timeout, IS91.Services.Web.WebModule.CSessionStateStoreProvider_SessionEndcallback, true);
            }
    }
    private void resetSessioncNounce()
    {
       HttpContext.Current.Session["cNounce"] = Math.Abs(DateTime.Now.Ticks.GetHashCode()).ToString();
    }
</script>
