using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataAccess;
using BALVatasETDS.UserGroupManagement;
using System.Configuration;

public partial class Presentation_logout : System.Web.UI.Page
{
    static string Project_Session = "";
    static string reason_logout = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Project"] != null)
            Project_Session = Session["Project"].ToString();

        balAdmin objbalAdmin = new balAdmin();
        if (HttpContext.Current.Session.SessionID != null)
        {
            objbalAdmin.logoutUser();
        }
        Session["Project"] = Project_Session;

        if (Session["User_ID"] == null)
            Response.Redirect("../Default.aspx");
        if (Session["reason_logout"] != null)
            reason_logout = Session["reason_logout"].ToString();

        //balAdmin objbalAdmin = new balAdmin();
        int lastID = objbalAdmin.getLastLoginID(Convert.ToInt32(Session["User_ID"]));   // this is the last ID for tbl_User_Session_Details table and this to set the Logout Status for the same record for the user
        Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
        tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        objtbl_UserGroupRegistration.Logout_Time = DateTime.Now.ToString();
        objtbl_UserGroupRegistration.Logout_Nature = "LogOff";
        objtbl_UserGroupRegistration.Super_User_Id = Convert.ToInt32(Session["User_ID"]);
        objtbl_UserGroupRegistration.Time_OutID = lastID;
        objBltbl_UserGroupRegistration.Update_Logout_Time(objtbl_UserGroupRegistration);

        Session.Clear();
        Session.Abandon();
        Session["Project"] = Project_Session;
        string strRedirect = "../Default.aspx";
        if (reason_logout != "")
        {
            Session["reason_logout"] = reason_logout.ToString();
            //strRedirect = "Login.aspx?reason_logout=sa";
            strRedirect = "../Default.aspx";
        }
        Session["Project"] = Project_Session;
        //Response.Redirect("login.aspx");
        //Response.Redirect("../Default.aspx");
        if (Project_Session == "tds")
            strRedirect = "../pageRedirect.aspx?prj=tds";
        else if (Project_Session == "vt")
            strRedirect = "../pageRedirect.aspx?prj=vt";
        else if (Project_Session == "stax")
            strRedirect = "../pageRedirect.aspx?prj=stax";
        else
            strRedirect = "../Default.aspx";    //In case don't know the Project Session

        Response.Redirect(strRedirect); //Response.Redirect(strRedirect);
    }
}