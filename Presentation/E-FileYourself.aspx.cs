using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Taxation.BusinessLogic;

public partial class E_FileYourself : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Auto Redirect on Session Out
        int reason = 0;
        //if (!common.IsLoggedIn(out reason))
        //{
        //    if (reason == 1)
        //    {
        //        Session["reason_logout"] = "suspecious_attempt";
        //    }
        //    Response.Redirect("Logout.aspx");
        //}
        Session["AssesseeUser"] = "1";  //to state that this user is for "Prepare Return Yourself"

        if (Session["user_id"] != null && Session["userEmail"] != null)
        {
            Session["Account_Type"] = "S";
            bllLogin objbllLogin = new bllLogin();
            DataTable dtAssessee = new DataTable();
            dtAssessee = objbllLogin.getAssesseeCount(Session["userEmail"].ToString());
            if (dtAssessee.Rows.Count > 0)
                Response.Redirect("Main.aspx");
            else
                Response.Redirect("AssesseeSelect.aspx");
        }//ltWelcome.Text = "Welcome <a href='../Presentation/'>" + Session["user_name"].ToString() + "</a>";
        else
        {
            //Session.Abandon();
            Session["Project"] = "vt";
            Response.Redirect("Login.aspx");
        }

        if (Session["Exists"] != null && Session["Bool"] != null && Session["Mode"] != null && Session["PAN"] != null)
        {
            aPRY.HRef = "Main.aspx?rid=1";
        }
        else
        {
            aPRY.HRef = "Assesseeselect.aspx?u=PRY";
        }
    }
    protected void lbtnLogout1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logout.aspx");
        //Session.Abandon();
        //Response.Redirect("Default.aspx");
    }
    protected void lbtnLogout11_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logout.aspx");
        //Session.Abandon();
        //Response.Redirect("Default.aspx");
    }
}