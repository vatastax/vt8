using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_mobilemenu2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
            lblUser.Text = Session["UserName"].ToString();// Session["UserName"].ToString();
        else
            Response.Redirect("login.aspx");
    }
}