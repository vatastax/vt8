using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using System.Data;

public partial class Presentation_header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Project"] == null)
            Response.Redirect("../Default.aspx");
        if (Session["user_name"] != null)
            lblUser.Text = Session["user_name"].ToString();  // Session["UserName"].ToString();
        else
            Response.Redirect("../Default.aspx");

        if (Session["Project"].ToString() == "tds")
        {
            hdnProject.Value = "tds";
        }
        else
            hdnProject.Value = Session["Project"].ToString();
        
    }
}