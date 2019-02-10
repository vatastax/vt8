using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using System.Data;

public partial class menu_header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //nishu 8/3/2015 for logout conditionally
        if (Session["Project"].ToString() == "tds")
        {
            hdnProject.Value = "tds";
        }
        if (Session["Project"] == null)
            Response.Redirect("../Default.aspx");
        //if (Session["ay"] != null || Session["Project"].ToString() == "TDS" || Session["Project"].ToString() == "stax")
        //{
        //    bllMain objbllMain = new bllMain();
        //    DataTable dt = new DataTable();
        //    if (Session["ITR"] == null)
        //        Session["ITR"] = "1";
        //    if (Session["Project"].ToString() != "stax")
        //        dt = objbllMain.getMenu(Session["ay"].ToString(), Session["ITR"].ToString(), "0");     //  {0} = AY, {1} = ITR, {2} = Assessee
        //    else
        //        dt = objbllMain.getMenuGlobal(Session["ay"].ToString(), Session["ITR"].ToString(), "0", Session["Project"].ToString());     //  {0} = AY, {1} = ITR, {2} = Assessee

            

            

        //}
        //string ss = Session["UserName"].ToString();
        if (Session["user_name"] != null)
            lblUser.Text = Session["user_name"].ToString();  // Session["UserName"].ToString();
        else
            Response.Redirect("../Default.aspx");
    }
    
}