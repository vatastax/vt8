using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pageRedirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["prj"] != null)
        {
            Session["Project"] = Request.QueryString["prj"];
            string strRedirect = "Presentation/Login.aspx";
            if (Session["user_id"] != null)
            {
                if (Session["Project"] != null)
                {
                    //if (Request.QueryString["prj"].ToString() != Session["Project"].ToString())
                    //{
                    //    //Session.Clear();
                    //    strRedirect = "Presentation/Login.aspx";
                    //}
                    //else
                    //{
                        if (Session["Project"].ToString() == "vt")
                            strRedirect = "Presentation/itr1.aspx";
                        else if (Session["Project"].ToString() == "tds")
                            strRedirect = "Presentation/tds.aspx";
                        else if (Session["Project"].ToString() == "tds2")
                        {
                            Session["project"] = "tds2";
                            strRedirect = "Presentation/Login.aspx";
                        }
                        else if (Session["Project"].ToString() == "stax")
                            strRedirect = "Presentation/servicetax.aspx";
                        else
                            strRedirect = "Presentation/Login.aspx";
                    //}
                }
            }
            Session["Project"] = Request.QueryString["prj"];
            Response.Redirect(strRedirect);
        }
        else
        {
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());
            else
                Response.Redirect("Default.aspx");
        }
    }
}