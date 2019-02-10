using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
using DALVatasETDS;
using BALVatasETDS;
using BALVatasETDS.Menu;
using BALVatasETDS.User;
using BALVatasETDS.User_Admin;
using BALVatasETDS.RoleManagement;
using BALVatasETDS.Assign_Role_To_User;
using System.Data.SqlClient;
using System.Configuration;
using System;
using controlgrid;
using BALVatasETDS.UserGroupManagement;
using System.Data;

public partial class chkValidationUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null && Request.QueryString["ActiveCode"] != null && Request.QueryString["AccountType"] != null)
        {
            Session["project"] = "vt";
            balAdmin objbalAdmin = new balAdmin();
            objbalAdmin.activateUser(Convert.ToInt64(Request.QueryString["ID"]), Request.QueryString["AccountType"].ToString());
            objbalAdmin.logoutUser(Convert.ToInt64(Request.QueryString["ID"]));
            Session["act"] = "validated";
            if (Request.QueryString["ST"] != null)
            {
                if (Request.QueryString["ST"].ToString() == "vt" && Request.QueryString["ID"] != null)
                {
                    makeLogin(Request.QueryString["ID"].ToString());
                }
                else
                {
                    makeLogin(Request.QueryString["ID"].ToString());
                }
            }
        }
    }

    public void makeLogin(string User_ID)
    {
        Session["User_ID"] = User_ID;
        string userid = Session["User_ID"].ToString();
        //DBtbl_Module.User_ID = Convert.ToInt32(Session["User_ID"]);
        balAdmin objbalAdmin = new balAdmin();
        tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
        tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration();
        tbl_User objtbl_User = new tbl_User();
        string strConnName_Admin, strConnectionString_Admin;

        //Connection  String For the Admin Process
        strConnName_Admin = Application["DBEngine"].ToString();
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString;

        Bltbl_User objBltbl_User = new Bltbl_User(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);

        objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(User_ID));

        Session["Name"] = objtbl_UserRegistration.Name;
        Session["LastName"] = objtbl_UserRegistration.Last_Name;
        objtbl_UserGroupRegistration.EmailID = objtbl_UserRegistration.User_Name;
        objtbl_UserGroupRegistration.Password = objtbl_UserRegistration.Password;
        //string Is_LoggedIn = objBltbl_UserGroupRegistration.Get_Active_Login(objtbl_UserGroupRegistration);


        Session["OK"] = "MEMBER";
        //Update Login Status
        objtbl_UserGroupRegistration.EmailID = objtbl_UserRegistration.User_Name;
        objtbl_UserGroupRegistration.Password = objtbl_UserRegistration.Password;
        objtbl_UserGroupRegistration.Active_Login = "Y";
        //objBltbl_UserGroupRegistration.Set_Active_Login(objtbl_UserGroupRegistration);
        //Now Check Wheter the Account is Locked or Not or whether it is deleted or Not
        objtbl_User.User_Name = objtbl_UserRegistration.User_Name;
        objtbl_User.Password = objtbl_UserRegistration.Password;
        objtbl_UserRegistration.Password = "";
        bool Is_Locked = objBltbl_User.Check_Account_IsLocked(objtbl_User);
        if (!Is_Locked)
        {
            //Get The Menu Associated with the User
            //Get Role Name By User

            //objBltbl_UserGroupRegistration.Get_Login_Session_Information_ID(


            //Response.Redirect("~/Main.aspx");
            getLogin(objtbl_UserRegistration.User_Name, objtbl_UserRegistration.Password);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "alert message", "<script type='text/javascript'>alert('Sorry your account is locked you have exceeded maximum login attempts. Please Contact Your Adminstration!');</script>");
            //ltrIsApproveCheck.Text = "Sorry your account is locked you have exceeded maximum login attempts. Please Contact Your Adminstration! ";
        }
    }

    private void getLogin(string email, string pwd)
    {
        int x, Y;
        if (Session["project"] == null)
            Session["project"] = "vt";


        Session["chk"] = -1;

        //if (Page.IsValid)
        //{
        denLogin objLoginDEN;
        bllLogin objLoginBLL;
        bllMain objMainBLL;

        objLoginDEN = new denLogin();
        objLoginBLL = new bllLogin();
        objMainBLL = new bllMain();
        objLoginDEN.UserName = email;
        objLoginDEN.Password = pwd;
        objLoginDEN.SessionID = Session.SessionID;
        objLoginDEN.LoginTime = DateTime.Now.ToShortTimeString();
        objLoginDEN.LogoutStatus = 0;
        x = objLoginBLL.CheckUserNamePassword(objLoginDEN);
        Y = objMainBLL.CountNames(email);
        denLogin objLoginDEN2;
        objLoginDEN2 = new denLogin();
        int counter;
        counter = objLoginBLL.CountUser(email);
        if (counter == 0)
        {
            objLoginBLL.InsertLoginDetails(objLoginDEN);
        }
        //else if (counter != 0)
        //{
            objLoginDEN.UserName = email;// Convert.ToString(Session["UserName"]);
            //======================================================
            //code to update logindetails table at user login
            //Like new sessionID,new logintime etc
            //======================================================

            objLoginBLL.UpdateLoginInfo(objLoginDEN);
            denLogin objLogin2 = new denLogin();
            objLogin2 = objLoginBLL.Select(objLoginDEN.UserName);

            Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration();
            tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
            balAdmin objbalAdmin = new balAdmin();
            string session_status = objbalAdmin.getLoginSession(objLogin2.Super_User_Id);
            if (session_status != "NA")
            {


                objLogin2.LoginTime = DateTime.Now.ToString();

                Session["user_name"] = objLogin2.PersonName;
                Session["UserName"] = email;
                string str_Redirect = "Main.aspx";
                Session["Email_Id"] = email;
                Session["userEmail"] = email;
                //if (objLogin2.Account_Type == "S")
                if (Session["Project"].ToString() == "vt")
                {
                    DataTable dtAssessee = new DataTable();
                    dtAssessee = objLoginBLL.getAssesseeCount(email);
                    if (dtAssessee.Rows.Count > 0 && Session["AssesseeUser"] != null)
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
                        str_Redirect = "Main.aspx";
                    }
                    else
                    {
                        Session["Mode"] = "New";
                        str_Redirect = "individual.aspx";
                    }

                    Session["Account_Type"] = "U";
                    if (objLogin2.Account_Type == "S")
                    {
                        Session["Account_Type"] = "S";
                        if (dtAssessee.Rows.Count > 0)
                        {
                            str_Redirect = "DisplayForm.aspx";
                        }
                        else
                        {
                            Session["Mode"] = "New";
                            str_Redirect = "individual.aspx";
                        }
                    }
                    str_Redirect = "itr1.aspx";
                    InsertLoginSession();
                }
                else if (Session["Project"].ToString() == "tds")
                {
                    str_Redirect = "tds.aspx";
                }
                else if (Session["Project"].ToString() == "stax")
                {
                    str_Redirect = "servicetax.aspx";
                }

                if (x == 0 && Y != 0)
                {
                    Session["UserName"] = email;
                    Response.Redirect(str_Redirect);
                }
                else if (x == 0 && Y == 0)
                {
                    Session["UserName"] = email;
                    Response.Redirect(str_Redirect);
                }
                else if (x == 2)
                {
                    //mltView.ActiveViewIndex = 4;
                    //lblMessage.Text = "Username Incorrect";
                    Session["chk"] = 0;
                }
                else if (x == 3)
                {
                    //mltView.ActiveViewIndex = 4;
                    //lblMessage.Text = "Password Incorrect";
                    Session["chk"] = 0;
                }
                if (Request.QueryString["ST"] != null)
                {
                    if (Request.QueryString["ST"].ToString() == "vt")
                        str_Redirect = "Presentation/" + str_Redirect;
                    else
                        str_Redirect = "Default.aspx";
                }
                Response.Redirect(str_Redirect);
            }
            else
            {
                //mltView.ActiveViewIndex = 4;
                //lblMessage.Text = "User Already Login!!";
            }
        //}
        //}
    }

    private void InsertLoginSession()
    {
        //tbl_RoleManagement objtbl_RoleManagement = new tbl_RoleManagement();
        //string Role_Name = objBltbl_User.Get_RoleName_ByUser(objtbl_User);
        //objtbl_RoleManagement.Role_Name = Role_Name;
        ////Get RoleID according to the User.
        //int RoleID = objBltbl_RoleManagement.Get_RoleID_By_UserRole(objtbl_RoleManagement);
        ////Get The Menu According to the Role Id
        //Session["MenuByRole"] = CreateMenu(RoleID);
        //Session["Role_ID"] = RoleID;
        //DataTable dt_page = new DataTable();
        //dt_page = objBltbl_Menu.Get_PageID_Byrole(RoleID);
        ////StaticVariabels.Session_Usr.Add(Session["Email_Id"].ToString());
        //objtbl_UserGroupRegistration.Active_Login = "Y";
        //objBltbl_UserGroupRegistration.Set_Active_Login(objtbl_UserGroupRegistration);
        ////Insert the Session Login Details
        //objtbl_UserGroupRegistration.Super_User_Id = Convert.ToInt32(Session["User_ID"]);
        //string Login_Time = DateTime.Now.ToString();
        //Session["Login_Time"] = Login_Time;
        //objtbl_UserGroupRegistration.Login_Time = Login_Time;
        //objtbl_UserGroupRegistration.Logout_Time = "NA";
        //objtbl_UserGroupRegistration.Logout_Nature = "NA";
        //objtbl_UserGroupRegistration.Session_ID = HttpContext.Current.Session.SessionID.ToString();
        //objBltbl_UserGroupRegistration.Insert_Login_Session(objtbl_UserGroupRegistration);
    }

}