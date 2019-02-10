using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_manageLinking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        Session["IncomeTax_VType"] = "40";
        
        if (Request.QueryString["vtype"] != null)
        {
            if (Request.Cookies["vtype"] != null)
            {
                HttpCookie myCookie = Request.Cookies["vtype"];
                myCookie.Value = Request.QueryString["vtype"].ToString();
                Response.Cookies.Add(myCookie);
                //Response.Cookies.Set(myCookie) = Request.QueryString["vtype"].ToString();
            }
            Session["Master_VType"] = "true";
            Session["Listing_Page"] = "true";
            Session["IncomeTax_VType"] = Request.QueryString["vtype"].ToString();
            Session["Validation_Combo"] = (Request.QueryString["tab"] != null) ? Request.QueryString["tab"].ToString() : null;
        }
        Response.Redirect("IncomeTax");
    }
}