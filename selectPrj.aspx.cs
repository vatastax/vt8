using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_selectPrj : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        Session["Main"] = "set";

        if (Session["project"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if (Session["project"].ToString() == "vt")
        {
            Response.Redirect("~/Presentation/itr1.aspx");
        }
        else if (Session["project"].ToString() == "stax")
        {
            Response.Redirect("~/Presentation/servicetax.aspx");
        }
        else if (Session["project"].ToString() == "tds")
        {
            Response.Redirect("~/Presentation/tds.aspx");
        }

    }
}