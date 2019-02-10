<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="Taxation.DataEntity" %>
<script runat="server">

    public void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("IncomeTax", "Presentation/IncomeTax", "~/Presentation/Salary.aspx?vtype=40");
        routes.MapPageRoute("Profile", "Presentation/Profile", "~/Presentation/Salary.aspx?vtype=106");
        routes.MapPageRoute("Computation", "Presentation/Computation", "~/Presentation/Salary.aspx?vtype=106");
    }
    
    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
        Application["DBEngine"] = ConfigurationManager.AppSettings["DatabaseEngine"];
        Application["DBEngine2"] = ConfigurationManager.AppSettings["DatabaseEngine1"];
        Application["DBEngine3"] = ConfigurationManager.AppSettings["DatabaseEngine2"];
        Application["DBEngine4"] = ConfigurationManager.AppSettings["DatabaseEngine3"];
        Application["DBEngine5"] = ConfigurationManager.AppSettings["DatabaseEngine4"];
        Application["DBEngine6"] = ConfigurationManager.AppSettings["DatabaseEngine5"];
        Application["DBEngine7"] = ConfigurationManager.AppSettings["DatabaseEngine6"];
        Application["User_Sessions"] = "";
    }



    void Application_AcquireRequestState(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
       
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

        HttpException lastErrorWrapper = Server.GetLastError() as HttpException;
        tbl_ErrorLog objtbl_ErrorLog;
        Exception lastError = lastErrorWrapper;
        if (lastErrorWrapper.InnerException != null)
            lastError = lastErrorWrapper.InnerException;

        string lastErrorTypeName = lastError.GetType().ToString();
        string lastErrorMessage = lastError.Message;
        string lastErrorStackTrace = lastError.StackTrace;

        SqlCommand cmd;
        objtbl_ErrorLog = new tbl_ErrorLog();
        SqlConnection SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Con_Poolable"].ToString());
        SqlCon.Open();
        string strSQL = "";

        strSQL = @"insert into tbl_ErrorLog values(@ErrorMsg,@methodName,@className,@pageName,@ErrDateTime,@IsDone,@SolvedBy,@SolvedOn)";
        cmd = new SqlCommand(strSQL, SqlCon);
        cmd.Parameters.AddWithValue("@ErrorMsg", lastErrorMessage);
        cmd.Parameters.AddWithValue("@methodName", "");
        cmd.Parameters.AddWithValue("@className", "");
        cmd.Parameters.AddWithValue("@pageName", Request.Url.ToString());
        cmd.Parameters.AddWithValue("@ErrDateTime", System.DateTime.Now);
        cmd.Parameters.AddWithValue("@IsDone", "False");
        cmd.Parameters.AddWithValue("@SolvedBy", "0");
        cmd.Parameters.AddWithValue("@SolvedOn", DateTime.Now);
        cmd.ExecuteNonQuery();
        SqlCon.Close();
        //Server.ClearError();
       
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        
    }

    void Session_End(object sender, EventArgs e) 
    {
        //Response.Redirect("~/Presentation/Login.aspx");
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        
    }
    
    
       
</script>
