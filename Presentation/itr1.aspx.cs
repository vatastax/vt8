using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
public partial class itr1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Added by Mudit on 30/06/2015 for deleting records if user comes back without generating XML
        if (Session["NameID"] != null)
        {
            bllAssessee objbllAssessee = new bllAssessee();
            string AY = Session["AY"].ToString();
            string NameID = Session["NameID"].ToString();
            objbllAssessee.DeleteFromStoreTrans(NameID, AY);
        }

        //Auto Redirect on Session Out
        int reason = 0;
            ////if (!common.IsLoggedIn(out reason))
            ////{
            ////    if (reason == 1)
            ////    {
            ////        Session["reason_logout"] = "suspecious_attempt";
            ////    }
            ////    Response.Redirect("Logout.aspx");
            ////}
        //Response.Write(Application["User_Sessions"].ToString());

        Session["AssesseeUser"] = null;
        Session["Project"] = "vt";
        //if (Session["user_name"] != null)
        //    ltWelcome.Text = "Welcome <a href='../Presentation/' style=' text-transform: capitalize'>" + Session["user_name"].ToString() + "</a>";
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logout.aspx");
        //Session.Abandon();
        //Response.Redirect("Default.aspx");
    }
    protected void lbtnLogout1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logout.aspx");
        //Session.Abandon();
        //Response.Redirect("Default.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
}