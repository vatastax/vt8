using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class BrowserClose : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static void AbandonSession()
    {
        HttpContext.Current.Session.Abandon();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["ID"] = "1";
        Label1.Text = Session["ID"].ToString();
    }
}