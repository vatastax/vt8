using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using System.Data;

public partial class E_FileCA : System.Web.UI.Page
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

        Session["AssesseeUser"] = "2";  //to state that this user is for "E-File with CA"
        if (Session["user_id"] != null && Session["userEmail"] != null)
        {
            Session["Account_Type"] = "E";
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
            Session["AssesseeUser"] = "2";
            Session["Account_Type"] = "E";
            Response.Redirect("Login.aspx");
        }

        if (Session["user_name"] != null)
            ltWelcome.Text = "Welcome <a href='../Presentation/'>" + Session["user_name"].ToString() + "</a>";
    }

    protected void lbtnLogout1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    protected void lbtnLogout11_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}