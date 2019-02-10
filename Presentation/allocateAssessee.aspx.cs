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

public partial class Presentation_allocateAssessee : System.Web.UI.Page
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
        if (Request.UrlReferrer != null)
        {
            if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                Session["DisplayForm"] = null;
            else
                Session["DisplayForm"] = "set";
        }
        else
            Session["DisplayForm"] = "set";

        
        ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";
               
        if (!IsPostBack)
        {
            bindGrid();

            balAdmin objbalAdmin = new balAdmin();
            ddUsers.DataSource = objbalAdmin.SelectData("BMC", "BO");
            ddUsers.DataTextField = "Name";
            ddUsers.DataValueField = "Super_User_Id";
            ddUsers.DataBind();
        }
    }

    private void bindGrid()
    {
        blltbl_ProcessesHistoryofjob obj = new blltbl_ProcessesHistoryofjob();
        DataTable dt = new DataTable();
        dt = obj.Select(true);
        gvAssessee.DataSource = dt;
        gvAssessee.DataBind();
    }

    protected void btnAllocate_Click(object sender, EventArgs e)
    {
        string IDs = "";
        string NameIDs = "";
        bllAssesseeMaster objbllAssesseeMaster = new bllAssesseeMaster();
        bllAssessee objbllAssessee = new bllAssessee();
        foreach (GridViewRow row1 in gvAssessee.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)row1.FindControl("chkAss");
            if (chk.Checked)
            {
                Label lblID = new Label();
                Label lblNameID = new Label();

                lblID = (Label)row1.FindControl("lblID");
                lblNameID = (Label)row1.FindControl("lblNameID");
                objbllAssesseeMaster.updateStatus(lblID.Text);
                objbllAssessee.UpdateUser(ddUsers.SelectedValue, lblNameID.Text);
                IDs += lblID.Text + ",";
                NameIDs += lblNameID.Text + ",";
            }
        }
        if (IDs.Length > 0)
        {
            IDs = IDs.Remove(IDs.Length - 1);
            NameIDs = NameIDs.Remove(NameIDs.Length - 1);

            
            
            bindGrid();
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

    //[WebMethod]
    //public static void AbandonSession()
    //{
    //    Presentation_DisplayForm frm = new Presentation_DisplayForm();
    //    string ss = HttpContext.Current.Request.UrlReferrer.ToString();
    //    if (HttpContext.Current.Session["DisplayForm"] == null && HttpContext.Current.Request.Url.ToString().Contains("DisplayForm.aspx"))
    //    {
    //        HttpContext.Current.Response.Redirect("Logout.aspx");
    //        HttpContext.Current.Session.Abandon();
    //        bllAssessee objbllAssessee = new bllAssessee();
    //        if (HttpContext.Current.Session["NameID"] != null && HttpContext.Current.Session["AY"] != null)
    //            objbllAssessee.DeleteFromStoreTrans(HttpContext.Current.Session["NameID"].ToString(), HttpContext.Current.Session["AY"].ToString());

    //        Presentation_DisplayForm objPresentation_DisplayForm = new Presentation_DisplayForm();
    //        objPresentation_DisplayForm.Logout();
    //    }
    //    else
    //        HttpContext.Current.Session["DisplayForm"] = null;
    //}

    //public void Logout()
    //{
    //    balAdmin objbalAdmin = new balAdmin();
    //    if (HttpContext.Current.Session.SessionID != null)
    //    {
    //        objbalAdmin.logoutUser();
    //    }
    //    string Project_Session = "";
    //    string reason_logout = "";

    //    if (Session["User_ID"] == null)
    //        Response.Redirect("Login.aspx");
    //    if (Session["Project"] != null)
    //        Project_Session = Session["Project"].ToString();
    //    if (Session["reason_logout"] != null)
    //        reason_logout = Session["reason_logout"].ToString();

    //    balAdmin objbalAdmin = new balAdmin();
    //    int lastID = objbalAdmin.getLastLoginID(Convert.ToInt32(Session["User_ID"]));   // this is the last ID for tbl_User_Session_Details table and this to set the Logout Status for the same record for the user
    //    Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
    //    tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
    //    objtbl_UserGroupRegistration.Logout_Time = DateTime.Now.ToString();
    //    objtbl_UserGroupRegistration.Logout_Nature = "LogOff";
    //    objtbl_UserGroupRegistration.Super_User_Id = Convert.ToInt32(Session["User_ID"]);
    //    objtbl_UserGroupRegistration.Time_OutID = lastID;
    //    objBltbl_UserGroupRegistration.Update_Logout_Time(objtbl_UserGroupRegistration);

    //    Session.Clear();
    //    Session.Abandon();
    //    Session["Project"] = Project_Session;
    //    string strRedirect = "Login.aspx";
    //    if (reason_logout != "")
    //    {
    //        Session["reason_logout"] = reason_logout.ToString();
    //        strRedirect = "Login.aspx?reason_logout=sa";
    //    }
    //    Response.Redirect("login.aspx");
    //    Response.Redirect("../Default.aspx");
    //    Response.Redirect(strRedirect);
    //}

}
