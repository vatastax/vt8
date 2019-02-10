using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.BusinessLogic;
using System.Web.Services;
using BALVatasETDS.UserGroupManagement;
using Taxation.DataEntity;

public partial class Presentation_DisplayForm : System.Web.UI.Page
{
    public int IsLogout = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Auto Redirect on Session Out
        int reason = 0;
        if (!common.IsLoggedIn(out reason))
        {
            if (reason == 1)
            {
                Session["reason_logout"] = "suspecious_attempt";
            }
            Response.Redirect("Logout.aspx");
        }
        IsLogout = 0;
        //for managing window close from top:
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["inc"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        Session["Main"] = "set";
        Session["Def"] = "set";

        if (Request.UrlReferrer != null)
        {
            if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                Session["DisplayForm"] = null;
            else
                Session["DisplayForm"] = "set";
        }
        else
            Session["DisplayForm"] = "set";

        if (Session["project"].ToString() == "vt")
        {
            lblText.Text = "Continue with ITR Process";
            Page.Title = "Income Tax Return";
            btnContinue.PostBackUrl = "Salary.aspx?VType=40";
        }
        else if (Session["project"].ToString() == "tds")
        {
            lblText.Text = "Continue with TDS Process";
            Page.Title = "TDS";
            bllMain objbllMain = new bllMain();
            int IsExists = 0;
            string TAN=Session["TAN"].ToString();
            string FY=Session["FY"].ToString();
            string FormNo = (Session["FormType"] != null) ? Session["FormType"].ToString() : "";
            string Quarter = (Session["qtr"] != null) ? Session["qtr"].ToString() : "";
            string Type=Session["Regular_Correction"].ToString();
            //string Vtype=ViewState["vtype"].ToString();
            IsExists = objbllMain.IsDataExists(TAN, FY, FormNo, Quarter, Type, "3001");
            if (IsExists == 0)
                btnContinue.PostBackUrl = "Salary.aspx?VType=3001";
            else
                btnContinue.PostBackUrl = "lstGrids.aspx?VType=3001";
        }
        else if (Session["project"].ToString() == "stax")
        {
            lblText.Text = "Continue with Service Tax Process";
            Page.Title = "SERVICE TAX";
            btnContinue.PostBackUrl = "Salary.aspx?VType=5001";
        }
        ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";

        if (Session["AssesseeUser"] != null)
        {
            bllLogin objLoginBLL = new bllLogin();
            DataTable dtAssessee = new DataTable();
            dtAssessee = objLoginBLL.getAssesseeCount(Session["userEmail"].ToString());
            if (dtAssessee.Rows.Count > 0)
            {
                Session["Exists"] = 1;
                Session["Bool"] = "False";
                Session["Mode"] = "New";
                Session["PAN"] = Convert.ToString(dtAssessee.Rows[0]["PanNo"].ToString());
                Session["Status"] = dtAssessee.Rows[0]["Status"].ToString();
                Session["NameID"] = dtAssessee.Rows[0]["NameID"].ToString();
                Session["E_NameID"] = null;
                Session["restore"] = null;
                Session["AssesseeType"] = "Individual";
                Session["AType"] = "";
                Session["DateofBirth"] = dtAssessee.Rows[0]["DateofBirth"].ToString();

                Session["ITR"] = "1";
                Session["ay"] = "2014-2015";
                Session["duedate"] = "31-07-2014";
            }
            else
                Response.Redirect("individual.aspx");
        }
    }

    protected void btnTesting_Click(object sender, EventArgs e)
    {

    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        //Session["DisplayForm_Close"] = "0";
        //IsLogout = 0;
        //Session["DisplayForm"] = "set";
    }

    [WebMethod]
    public static void AbandonSession()
    {
        Presentation_DisplayForm objPresentation_Main = new Presentation_DisplayForm();
        string ss = HttpContext.Current.Request.UrlReferrer.ToString();
        if (HttpContext.Current.Session["DisplayForm"] == null)
        {
            //HttpContext.Current.Response.Redirect("Logout.aspx");
            //HttpContext.Current.Session.Abandon();
            //Presentation_DisplayForm objPresentation_DisplayForm = new Presentation_DisplayForm();
            bllAssessee objbllAssessee = new bllAssessee();
            if (HttpContext.Current.Session["NameID"] != null && HttpContext.Current.Session["AY"] != null)
                objbllAssessee.DeleteFromStoreTrans(HttpContext.Current.Session["NameID"].ToString(), HttpContext.Current.Session["AY"].ToString());

            //HttpContext.Current.Response.Redirect("Logout.aspx");
            objPresentation_Main.Logout();
        }
        else
            HttpContext.Current.Session["DisplayForm"] = null;
    }

    public void Logout()
    {
        balAdmin objbalAdmin = new balAdmin();
        if (HttpContext.Current.Session.SessionID != null)
        {
            objbalAdmin.logoutUser();
        }
        string Project_Session = "";
        string reason_logout = "";

        if (Session["User_ID"] == null)
            Response.Redirect("../Default.aspx");
        if (Session["Project"] != null)
            Project_Session = Session["Project"].ToString();
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
        string strRedirect = "Login.aspx";
        if (reason_logout != "")
        {
            Session["reason_logout"] = reason_logout.ToString();
            strRedirect = "Login.aspx?reason_logout=sa";
        }
        //Response.Redirect("login.aspx");
        //Response.Redirect("../Default.aspx");
        //Response.Redirect(strRedirect);
    }

}
