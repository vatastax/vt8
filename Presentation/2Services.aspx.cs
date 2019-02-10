using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Project"] != null)
        {
            string strRedirect = Session["Project"].ToString();
            if (Session["Project"].ToString() == "tds")
                strRedirect = "../pageRedirect.aspx?prj=tds";
            else if (Session["Project"].ToString() == "vt")
                strRedirect = "../pageRedirect.aspx?prj=vt";
            else if (Session["Project"].ToString() == "stax")
                strRedirect = "../pageRedirect.aspx?prj=stax";
            if (strRedirect != "")
                Response.Redirect(strRedirect);
        }
    }
}