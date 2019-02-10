using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
using DALVatasETDS;
using BALVatasETDS;
using BALVatasETDS.User_Admin;
using BALVatasETDS.RoleManagement;
using BALVatasETDS.Assign_Role_To_User;
using System.Data.SqlClient;
using System.Configuration;
using System;
using controlgrid;
using BALVatasETDS.UserGroupManagement;
using System.Data;
using System.Text;
using BALVatasETDS.Menu;
using BALVatasETDS.User;
using System.Web.Services;
public partial class VatasMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            li_Login.Visible = false;
            li_Logout1.Visible = true;
            li_Login1.Visible = false;
            li_Logout.Visible = true;
            li_Login11.Visible = false;
            li_Logout11.Visible = true;
            ltWelcome.Text = "Welcome <a href='Presentation/'>" + Session["user_name"].ToString() + "</a>";
        }
        else
        {
            li_Login.Visible = true;
            li_Logout1.Visible = false;
            li_Login1.Visible = true;
            li_Logout.Visible = false;
            li_Login11.Visible = true;
            li_Logout11.Visible = false;
        }
        if (!IsPostBack)
        {
            FillCapctha();
            string[] arrURL = System.Text.RegularExpressions.Regex.Split(Request.Url.ToString(), "/");
            string strURL = arrURL[arrURL.Length - 1];
            if (strURL == "AboutUs.aspx")
            {
                aAbout.Attributes.Add("class", "selectedA");
                aaAbout.Attributes.Add("class", "selectedAA");
                aaaAbout.Attributes.Add("class", "selectedA");
            }
            else if (strURL == "ContactUsNew.aspx")
            {
                aContact.Attributes.Add("class", "selectedA");
                aaContact.Attributes.Add("class", "selectedAA");
                aaaContact.Attributes.Add("class", "selectedA");
            }
            else if (strURL == "News.aspx")
            {
                aLatest.Attributes.Add("class", "selectedA");
                aaLatest.Attributes.Add("class", "selectedAA");
                aaaLatest.Attributes.Add("class", "selectedA");
            }
            else if (strURL == "SiteMap.aspx")
            {
                aSite.Attributes.Add("class", "selectedA");
                aaSite.Attributes.Add("class", "selectedAA");
                aaaSite.Attributes.Add("class", "selectedA");
            }
            else if (strURL == "Terms_Conditions.aspx")
            {
                aTnC.Attributes.Add("class", "selectedA");
                aaTnC.Attributes.Add("class", "selectedAA");
                aaaTnC.Attributes.Add("class", "selectedA");
            }
            else if (strURL == "PrivacyPolicy.aspx")
            {
                aPolicy.Attributes.Add("class", "selectedA");
                aaPolicy.Attributes.Add("class", "selectedAA");
                aaaPolicy.Attributes.Add("class", "selectedA");
            }

        }
    }
    protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
    {
        FillCapctha();
    }
    protected void btnLogin1_Click(object sender, EventArgs e)
    {
        //if (this.txtCaptcha.Text == Session["CaptchaImageText"].ToString())
        //{
        //    lblMsg.Text = "Excellent.......";
            getLogin();
        //}
        //else
        //{
        //    lblMsg.Text = "Security Code is not Valid.";
        //}
        this.txtCaptcha.Text = "";
    }
    protected void lbtnLogout_Click(object sender, System.EventArgs e)
    {
        Session.Abandon();
        Response.Redirect(Request.Url.ToString());
    }
    private void getLogin()
    {
        int x, Y;
        if (Session["project"] == null)
            Session["project"] = "vt";


        Session["chk"] = -1;

        if (Page.IsValid)
        {
            denLogin objLoginDEN;
            bllLogin objLoginBLL;
            bllMain objMainBLL;

            objLoginDEN = new denLogin();
            objLoginBLL = new bllLogin();
            objMainBLL = new bllMain();
            objLoginDEN.UserName = txtUser1.Text;
            objLoginDEN.Password = txtPassword1.Text;
            objLoginDEN.SessionID = Session.SessionID;
            objLoginDEN.LoginTime = DateTime.Now.ToShortTimeString();
            objLoginDEN.LogoutStatus = 0;
            x = objLoginBLL.CheckUserNamePassword(objLoginDEN);
            Y = objMainBLL.CountNames(txtUser1.Text);
            denLogin objLoginDEN2;
            objLoginDEN2 = new denLogin();
            int counter;
            counter = objLoginBLL.CountUser(txtUser1.Text);
            if (counter == 0)
            {
                objLoginBLL.InsertLoginDetails(objLoginDEN);
            }
            else if (counter != 0)
            {
                //objLoginDEN2 = objLoginBLL.CheckUserStatus(Convert.ToString(Session["UserName"]));
                //if (objLoginDEN2.LogoutStatus == 0)
                //{
                //    mltView.ActiveViewIndex = 4;
                //    lblMessage.Text = "You were Logged out Improperly";
                //    btnGoBackM.Text = "Enter";
                //    Session["chk"] = 10;
                //}

                ////users = objUserMgmtBLL.CountUser(Convert.ToString(Session["UserName"]));


                //else
                //{
                objLoginDEN.UserName = txtUser1.Text;// Convert.ToString(Session["UserName"]);
                //======================================================
                //code to update logindetails table at user login
                //Like new sessionID,new logintime etc
                //======================================================

                objLoginBLL.UpdateLoginInfo(objLoginDEN);
                denLogin objLogin2 = new denLogin();
                objLogin2 = objLoginBLL.Select(objLoginDEN.UserName);
                Session["user_name"] = objLogin2.PersonName;
                DataTable dt = new DataTable();
                tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
                Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration();
                objtbl_UserGroupRegistration.EmailID = txtUser1.Text;
                objtbl_UserGroupRegistration.Password = txtPassword1.Text;
                //dt = objBltbl_UserGroupRegistration.Get_User_Data(objtbl_UserGroupRegistration);
                //Session["User_ID"] = dt.Rows[0]["Super_User_Id"].ToString();
                //Session["User_ID"] = objLogin2.
                string str_Redirect = "Main.aspx";
                Session["userEmail"] = txtUser1.Text;
                if (objLogin2.Account_Type == "S")
                {
                    DataTable dtAssessee = new DataTable();
                    dtAssessee = objLoginBLL.getAssesseeCount(txtUser1.Text);
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

                        str_Redirect = "Presentation/DisplayForm.aspx";
                    }
                    else
                    {
                        Session["Mode"] = "New";
                        str_Redirect = "Presentation/individual.aspx";
                    }
                }
                //if (Session["Project"].ToString() == "stax")
                //    str_Redirect = "DisplayForm.aspx";
                str_Redirect = "Presentation/itr1.aspx";
                if (x == 0 && Y != 0)
                {
                    //Response.Redirect("Main.aspx");
                    Session["UserName"] = txtUser1.Text;
                    Response.Redirect(Request.Url.ToString());
                }
                else if (x == 0 && Y == 0)
                {
                    //Response.Redirect("FormMain.aspx");
                    //Response.Redirect("Main.aspx");
                    Session["UserName"] = txtUser1.Text;
                    Response.Redirect(Request.Url.ToString());
                    //Session["Mode"] = "New";
                    //Session["Bool"] = "False";
                    //Response.Redirect("Assesseeselect.aspx");
                }
                else if (x == 2)
                {
                    //mltView.ActiveViewIndex = 4;
                    lblMsg.Text = "Username Incorrect";
                    Session["chk"] = 0;
                }
                else if (x == 3)
                {
                    lblMsg.Text = "Password Incorrect";
                    Session["chk"] = 0;
                }
                // }
                //else
                //{
                //    mltView.ActiveViewIndex = 4;
                //    lblMessage.Text = "You are Already logged in";
                //    Session["chk"] = 0;
                //}
                //}


            }
        }
    }
    protected void lnkSignup_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/presentation/login.aspx?Value=" + "Signup");
    }
    protected void lnkPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/presentation/login.aspx?Value=" + "pwd");
    }
    public void FillCapctha()
    {
        try
        {
            Random random = new Random();
            //string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";   // Including Upper Case
            string combination = "0123456789abcdefghijklmnopqrstuvwxyz";    // Excluding Upper Case
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();
            imgCaptcha.ImageUrl = "Presentation/GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {

            throw;
        }
    }
}
