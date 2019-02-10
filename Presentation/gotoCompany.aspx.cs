using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_gotoCompany : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Status"] != null)
        {
            if (Session["Status"].ToString() == "0" || Session["Status"].ToString() == "1")
                Response.Redirect("individual.aspx");
            else if (Session["Status"].ToString() == "2")
                Response.Redirect("HUF.aspx");
            else if (Session["Status"].ToString() == "3")
                Response.Redirect("Partnership.aspx");
            else if (Session["Status"].ToString() == "4")
                Response.Redirect("Company.aspx");
            else if (Session["Status"].ToString() == "5")
                Response.Redirect("AOP.aspx");
            else if (Session["Status"].ToString() == "6")
                Response.Redirect("Cooperative.aspx");
        }
        else
        {
            Response.Redirect("main.aspx");
        }
    }
}