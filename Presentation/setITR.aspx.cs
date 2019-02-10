using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_setITR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Auto Redirect on Session Out
        int reason = 0;
        if (!common.IsLoggedIn(out reason))
        {
            if (reason == 1)
            {
                Session["reason_logout"] = "suspecious_attempt";
            }
            Response.Redirect("Logout.aspx");
        }
        if (Request.QueryString["itr"] != null)
        {
            Session["ITR"] = Request.QueryString["itr"].ToString();
        }
        Response.Redirect(Request.UrlReferrer.ToString());
    }
}