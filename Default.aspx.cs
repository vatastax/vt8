using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Query.BusinessLogic;
using Query.DataEntity;
using Taxation.BusinessLogic;
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


public partial class _Default : System.Web.UI.Page
{
    string File;
    int i;
    //tbl_UserGroupRegistration objtbl_UserGroupRegistration;
    //Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration;
    Bltbl_UserInfo_Mangement objBltbl_UserInfo_Mangement;
    tbl_UserInfo_Mangement objtbl_UserInfo_Mangement;

    //for integration of all logins:
    DataTable dt;
    DBtbl_Module objdbmodule;
    //Create the Object of User Group Management
    Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration;
    tbl_UserGroupRegistration objtbl_UserGroupRegistration;
    //Create The Object of the Menus
    //Initialise the Object of the Menu
    Bltbl_Menu objBltbl_Menu;
    tbl_Menu objtbl_Menu;
    //Intialize the Object of the User
    Bltbl_User objBltbl_User;
    tbl_User objtbl_User;
    //Intialize the Object of Role Management Module

    Bltbl_RoleManagement objBltbl_RoleManagement;
    tbl_RoleManagement objtbl_RoleManagement;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["Project"] = "vt";
        //bindNews();
        
        //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('" + Request.UserAgent + "'); </script>");
        try
        {
            string[] arr = null;
            if (Request.UserAgent.Contains("rv:"))
            {
                arr = System.Text.RegularExpressions.Regex.Split(Request.UserAgent, "rv:");
                arr = System.Text.RegularExpressions.Regex.Split(arr[1], ".");
                if (Convert.ToDecimal(arr[1].Trim()) < 9)
                    ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'> alert('IE is older than Version 9!!');</script>");
            }
            else if (Request.UserAgent.Contains("MSIE"))
            {
                arr = System.Text.RegularExpressions.Regex.Split(Request.UserAgent, "MSIE");
                arr = System.Text.RegularExpressions.Regex.Split(arr[1], ";");
                arr[0] = arr[0].Trim();
                if (Convert.ToDecimal(arr[0]) < 9)
                    ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'> alert('IE is older than Version 9!!');</script>");
            }
            if (!IsPostBack)
                FillCapctha();
            //code for show/hide internet explorer upgrade message
            try
            {
                if (Request.UserAgent.Contains("MSIE 7.0") || Request.UserAgent.Contains("MSIE 7.0b") || Request.UserAgent.Contains("MSIE 8.0") || Request.UserAgent.Contains("MSIE 9.0") || Request.UserAgent.Contains("MSIE 10.0") || (Request.UserAgent.Contains("rv:11.0") && Request.UserAgent.Contains("Trident")))
                {
                    iemsg.Visible = true;
                }
                else
                {
                    iemsg.Visible = false;
                }
            }

            catch (Exception ex)
            {
            }


            if (Session["user_name"] != null)
            {
                li_Login.Visible = false;
                //li_login_mob.Visible = false;
                //li_logout_mob.Visible = true;
                li_Logout.Visible = true;
                li_Logout1.Visible = true;
                li_Login1.Visible = false;
                ltWelcome.Text = "Welcome <a href='Presentation/' style=' text-transform: capitalize'>" + Session["user_name"].ToString() + "</a>";
            }
            else
            {
                //li_logout_mob.Visible = false;
                li_Login.Visible = true;
                li_Login1.Visible = true;
                li_Logout1.Visible = false;
                li_Logout.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }

        if (Session["NameID"] != null)
        {
            bllAssessee objbllAssessee = new bllAssessee();
            string AY = Session["AY"].ToString();
            string NameID = Session["NameID"].ToString();
            //Added by Mudit on 30/06/2015 for deleting records if user comes back without generating XML
            //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'> alert('All Yor Data Will be Lost....!!');</script>");
            objbllAssessee.DeleteFromStoreTrans(NameID,AY);
        }

    }
    //protected void ImageButton2_Click(object sender, EventArgs e)
    //{
    //    if (FUpload1.HasFile)
    //    {
    //        string[] validFileTypes = { "pdf" };
    //        string ext = System.IO.Path.GetExtension(FUpload1.PostedFile.FileName);
    //        bool isValidFile = false;

    //        for (int i = 0; i < validFileTypes.Length; i++)
    //        {
    //            if (ext == "." + validFileTypes[i])
    //            {
    //                isValidFile = true;
    //                break;
    //            }
    //        }
    //        if (!isValidFile)
    //        {
    //            string message = "Please upload only PDF File.";
    //            System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //            sb.Append("<script type = 'text/javascript'>");
    //            sb.Append("window.onload=function(){");
    //            sb.Append("alert('");
    //            sb.Append(message);
    //            sb.Append("')};");
    //            sb.Append("</script>");
    //            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
    //        }
    //        else
    //        {
    //            File = "~/UserUploads/" + FUpload1.FileName;
    //            FUpload1.SaveAs(Server.MapPath(File));
    //        }


    //    }
    //    else
    //    {
    //        File = "No Attachment";
    //        //string message = "Please select file to be upload";
    //        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //        //sb.Append("<script type = 'text/javascript'>");
    //        //sb.Append("window.onload=function(){");
    //        //sb.Append("alert('");
    //        //sb.Append(message);
    //        //sb.Append("')};");
    //        //sb.Append("</script>");
    //        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
    //    }
    //    // Create object for BAL
    //    balquery objQuery = new balquery();

    //    //Create object of Data Entity Class
    //    denquery objdenquery = new denquery();
    //    //Assign value to variables of data entity class
    //    objdenquery.name = txtName.Text;
    //    objdenquery.email = txtEmail.Text;
    //    objdenquery.subject = txtSubject.Text;
    //    objdenquery.query = txtComment.Text;
    //    objdenquery.Attachment = File;
    //    //call function of BAL Class
    //    try
    //    {

    //        objQuery.Insertquery(objdenquery);
    //        txtName.Text = "";
    //        txtEmail.Text = "";
    //        txtSubject.Text = "";
    //        txtComment.Text = "";
    //        //string message = "Your query has been sent successfuly";
    //        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //        //sb.Append("<script type = 'text/javascript'>");
    //        //sb.Append("window.onload=function(){");
    //        //sb.Append("alert('");
    //        //sb.Append(message);
    //        //sb.Append("')};");
    //        //sb.Append("</script>");
    //        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
    //        string message = "Your query has been sent successfuly";
    //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
       
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
    public void bindNews()
    {
        balWhatsNew objNews = new balWhatsNew();
        DataSet dsNews = new DataSet();
        dsNews = objNews.GetNew();
        dlst.DataSource = dsNews;
        dlst.DataBind();
    }
    [WebMethod]
    public static void AbandonSession()
    {
        HttpContext.Current.Session.Abandon();
    }

    protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
    {
        FillCapctha();
    }

    protected void lbtnLogout_Click(object sender, System.EventArgs e)
    {
        Session.Abandon();
        Response.Redirect(Request.Url.ToString());
    }

    protected void btnLogin1_Click(object sender, EventArgs e)
    {
        //if (this.txtCaptcha.Text == Session["CaptchaImageText"].ToString())
        //{
        //    lblMsg.Text = "Excellent.......";
        //    getLogin();
        //}
        //else
        //{
        //    lblMsg.Text = "Security Code is not Valid.";
        //}
        Login();
        this.txtCaptcha.Text = "";
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

    private void Login()
    {
        //if (this.txtCaptcha.Text == Session["CaptchaImageText"].ToString())
        string strCaptcha = Session["captcha"].ToString();
        if (this.txtCaptcha.Text == Session["captcha"].ToString())
        {
            divErrorMsg.Visible = false;
            //Label6.Text = "Excellent.......";
            //Check Admin Exist or Not Exist in Table (Admin Login)
            //objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
            //objtbl_User = new tbl_User();
            //objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration();
            //Connection  String For the Admin Process
            string strConnName_Admin, strConnectionString_Admin;

            //Connection  String For the Admin Process
            strConnName_Admin = Application["DBEngine"].ToString();
            strConnectionString_Admin = ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString;

            string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
            DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

            strConnName_Admin = Application["DBEngine"].ToString();
            strConnectionString_Admin = ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString;

            Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
            DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

            //Initiliaze the Object of User Group Management
            objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
            objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();


            //Create The Object of the Menu
            objBltbl_Menu = new Bltbl_Menu(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
            objtbl_Menu = new tbl_Menu();

            //Create The Object of the User Module
            objBltbl_User = new Bltbl_User(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
            objtbl_User = new tbl_User();

            //Create The Object of the Role Management Module
            objBltbl_RoleManagement = new Bltbl_RoleManagement(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
            objtbl_RoleManagement = new tbl_RoleManagement();

            objtbl_UserGroupRegistration.EmailID = txtUser1.Text;
            objtbl_UserGroupRegistration.Password = txtPassword1.Text;
            objtbl_User.User_Name = txtUser1.Text;
            //objtbl_User.User_Name = "abc@abc.com";
            objtbl_User.Password = txtPassword1.Text;
            //objtbl_User.Password = "abc";

            bool Is_Exist = objBltbl_UserGroupRegistration.Check_Admin_Credentials(objtbl_UserGroupRegistration);
            if (Is_Exist)
            {
                dt = new DataTable();
                dt = objBltbl_UserGroupRegistration.Get_User_Data(objtbl_UserGroupRegistration);

                ////Now Create Session
                Session["Email_Id"] = objtbl_UserGroupRegistration.EmailID;
                string email = Session["Email_Id"].ToString();

                Session["Password"] = objtbl_UserGroupRegistration.Password;
                string password = Session["Password"].ToString();


                //Get Account Type
                string Account_Type = string.Empty;
                //Get the Username
                string Username = string.Empty;
                string LastName = string.Empty;
                string User_ID = string.Empty;
                if (dt.Rows.Count != 0)
                {
                    Account_Type = dt.Rows[0]["Account_Type"].ToString();
                    Username = dt.Rows[0]["Name"].ToString();
                    LastName = dt.Rows[0]["Last_Name"].ToString();
                    User_ID = dt.Rows[0]["Super_User_Id"].ToString();

                }
                //Assign to Session Variable
                Session["User_ID"] = User_ID;
                string userid = Session["User_ID"].ToString();
                DBtbl_Module.User_ID = Convert.ToInt32(Session["User_ID"]);


                Session["Name"] = Username;
                Session["LastName"] = LastName;
                objtbl_UserGroupRegistration.EmailID = email;
                objtbl_UserGroupRegistration.Password = password;
                string Is_LoggedIn = objBltbl_UserGroupRegistration.Get_Active_Login(objtbl_UserGroupRegistration);
                //if (Is_LoggedIn == "N")
                //{
                if (Account_Type == "SA")
                {
                    Response.Redirect("~/Super_Admin/MainSuperAdmin_Section.aspx");
                }
                else if (Account_Type == "A")
                {
                    //Response.Redirect("~/User_Admin/MainAdminSection.aspx");
                    Response.Redirect("http://192.168.1.125:83/User_Admin/MainAdminSection.aspx");
                }
                else if (Account_Type == "U" || Account_Type == "S")
                {
                    Session["OK"] = "MEMBER";
                    //Update Login Status
                    objtbl_UserGroupRegistration.EmailID = email;
                    objtbl_UserGroupRegistration.Password = password;
                    objtbl_UserGroupRegistration.Active_Login = "Y";
                    objBltbl_UserGroupRegistration.Set_Active_Login(objtbl_UserGroupRegistration);
                    //Now Check Wheter the Account is Locked or Not or whether it is deleted or Not
                    bool Is_Locked = objBltbl_User.Check_Account_IsLocked(objtbl_User);
                    if (!Is_Locked)
                    {
                        //Get The Menu Associated with the User
                        //Get Role Name By User
                        string Role_Name = objBltbl_User.Get_RoleName_ByUser(objtbl_User);
                        objtbl_RoleManagement.Role_Name = Role_Name;
                        //Get RoleID according to the User.
                        int RoleID = objBltbl_RoleManagement.Get_RoleID_By_UserRole(objtbl_RoleManagement);
                        //Get The Menu According to the Role Id
                        Session["MenuByRole"] = CreateMenu(RoleID);
                        Session["Role_ID"] = RoleID;
                        DataTable dt_page = new DataTable();
                        dt_page = objBltbl_Menu.Get_PageID_Byrole(RoleID);
                        //StaticVariabels.Session_Usr.Add(Session["Email_Id"].ToString());
                        objtbl_UserGroupRegistration.Active_Login = "Y";
                        objBltbl_UserGroupRegistration.Set_Active_Login(objtbl_UserGroupRegistration);
                        //Insert the Session Login Details
                        objtbl_UserGroupRegistration.Super_User_Id = Convert.ToInt32(Session["User_ID"]);
                        string Login_Time = DateTime.Now.ToString();
                        Session["Login_Time"] = Login_Time;
                        objtbl_UserGroupRegistration.Login_Time = Login_Time;
                        objtbl_UserGroupRegistration.Logout_Time = "NA";
                        objtbl_UserGroupRegistration.Logout_Nature = "NA";
                        objtbl_UserGroupRegistration.Session_ID = HttpContext.Current.Session.SessionID.ToString();
                        objBltbl_UserGroupRegistration.Insert_Login_Session(objtbl_UserGroupRegistration);
                        //Response.Redirect("~/Main.aspx");
                        getLogin();
                    }
                    else
                    {
                        lblMsg.Text = "Sorry your account is locked";
                        divErrorMsg.Visible = true;
                        //ClientScript.RegisterClientScriptBlock(GetType(), "alert message", "<script type='text/javascript'>alert('Sorry your account is locked you have exceeded maximum login attempts. Please Contact Your Adminstration!');</script>");
                        //ltrIsApproveCheck.Text = "Sorry your account is locked you have exceeded maximum login attempts. Please Contact Your Adminstration! ";
                    }
                }
            }
            else
            {
                lblMsg.Text = "Please Check Either Your UserName or Password is Not Correct!";
                divErrorMsg.Visible = true;
                //this.ClientScript.RegisterStartupScript(this.GetType(), "Some Title", "<script language=\"javaScript\">" + "alert('Please Check Either Your UserName or Password is Not Correct! ');" + "<" + "/script>");
            }
        }
        else
        {
            lblMsg.Text = "Entered Security Code is not Correct.";
            divErrorMsg.Visible = true;
        }
        this.txtCaptcha.Text = "";
        // Response.Redirect(Request.Url.ToString());
    }

    //protected void lbtnLogout_Click(object sender, System.EventArgs e)
    //{
    //    Session.Abandon();
    //    Response.Redirect(Request.Url.ToString());
    //}

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
            string str_Redirect = "";

            if (counter == 0)
            {
                objLoginBLL.InsertLoginDetails(objLoginDEN);
            }
            else if (counter != 0)
            {
                objLoginDEN.UserName = txtUser1.Text;// Convert.ToString(Session["UserName"]);
                //======================================================
                //code to update logindetails table at user login
                //Like new sessionID,new logintime etc
                //======================================================

                objLoginBLL.UpdateLoginInfo(objLoginDEN);
                denLogin objLogin2 = new denLogin();
                objLogin2 = objLoginBLL.Select(objLoginDEN.UserName);
                Session["user_name"] = objLogin2.PersonName;

                
                Session["userEmail"] = txtUser1.Text;
                //if (objLogin2.Account_Type == "S")
                if (Session["Project"].ToString() == "vt")
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
                    //str_Redirect = "itr1.aspx";
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
                    Session["UserName"] = txtUser1.Text;
                    //Response.Redirect("Presentation/" + str_Redirect);
                }
                else if (x == 0 && Y == 0)
                {
                    Session["UserName"] = txtUser1.Text;
                    //Response.Redirect("Presentation/" + str_Redirect);
                }
                else if (x == 2)
                {
                    //mltView.ActiveViewIndex = 4;
                    lblMsg.Text = "Username Incorrect";
                    Session["chk"] = 0;
                }
                else if (x == 3)
                {
                    //mltView.ActiveViewIndex = 4;
                    lblMsg.Text = "Password Incorrect";
                    Session["chk"] = 0;
                }
            }
            if (lblMsg.Text != "Username Incorrect" && lblMsg.Text != "Password Incorrect" && str_Redirect != "")
            {
                Response.Redirect(Request.Url.ToString());
            }
        }
    }

    public StringBuilder CreateMenu(int RoleID)
    {
        objtbl_Menu.Role_ID = RoleID;

        StringBuilder sb_Menu = new StringBuilder();
        sb_Menu = objBltbl_Menu.Create_Menu(objtbl_Menu);
        return sb_Menu;
    }


    //private void getLogin()
    //{
    //    int x, Y;
    //    if (Session["project"] == null)
    //        Session["project"] = "vt";


    //    Session["chk"] = -1;

    //    if (Page.IsValid)
    //    {
    //        denLogin objLoginDEN;
    //        bllLogin objLoginBLL;
    //        bllMain objMainBLL;

    //        objLoginDEN = new denLogin();
    //        objLoginBLL = new bllLogin();
    //        objMainBLL = new bllMain();
    //        objLoginDEN.UserName = txtUser1.Text;
    //        objLoginDEN.Password = txtPassword1.Text;
    //        objLoginDEN.SessionID = Session.SessionID;
    //        objLoginDEN.LoginTime = DateTime.Now.ToShortTimeString();
    //        objLoginDEN.LogoutStatus = 0;
    //        x = objLoginBLL.CheckUserNamePassword(objLoginDEN);
    //        Y = objMainBLL.CountNames(txtUser1.Text);
    //        denLogin objLoginDEN2;
    //        objLoginDEN2 = new denLogin();
    //        int counter;
    //        counter = objLoginBLL.CountUser(txtUser1.Text);
    //        if (counter == 0)
    //        {
    //            objLoginBLL.InsertLoginDetails(objLoginDEN);
    //        }
    //        else if (counter != 0)
    //        {
    //            //objLoginDEN2 = objLoginBLL.CheckUserStatus(Convert.ToString(Session["UserName"]));
    //            //if (objLoginDEN2.LogoutStatus == 0)
    //            //{
    //            //    mltView.ActiveViewIndex = 4;
    //            //    lblMessage.Text = "You were Logged out Improperly";
    //            //    btnGoBackM.Text = "Enter";
    //            //    Session["chk"] = 10;
    //            //}

    //            ////users = objUserMgmtBLL.CountUser(Convert.ToString(Session["UserName"]));


    //            //else
    //            //{
    //            objLoginDEN.UserName = txtUser1.Text;// Convert.ToString(Session["UserName"]);
    //            //======================================================
    //            //code to update logindetails table at user login
    //            //Like new sessionID,new logintime etc
    //            //======================================================

    //            objLoginBLL.UpdateLoginInfo(objLoginDEN);
    //            denLogin objLogin2 = new denLogin();
    //            objLogin2 = objLoginBLL.Select(objLoginDEN.UserName);
    //            Session["user_name"] = objLogin2.PersonName;
    //            DataTable dt = new DataTable();
    //            tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
    //            Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration();
    //            objtbl_UserGroupRegistration.EmailID = txtUser1.Text;
    //            objtbl_UserGroupRegistration.Password = txtPassword1.Text;
    //            //dt = objBltbl_UserGroupRegistration.Get_User_Data(objtbl_UserGroupRegistration);
    //            //Session["User_ID"] = dt.Rows[0]["Super_User_Id"].ToString();
    //            //Session["User_ID"] = objLogin2.
    //            string str_Redirect = "Main.aspx";
    //            Session["userEmail"] = txtUser1.Text;
    //            if (objLogin2.Account_Type == "S")
    //            {
    //                DataTable dtAssessee = new DataTable();
    //                dtAssessee = objLoginBLL.getAssesseeCount(txtUser1.Text);
    //                if (dtAssessee.Rows.Count > 0)
    //                {
    //                    Session["Exists"] = 1;
    //                    Session["Bool"] = "False";
    //                    Session["Mode"] = "New";
    //                    Session["PAN"] = Convert.ToString(dtAssessee.Rows[0]["PanNo"].ToString());
    //                    Session["Status"] = dtAssessee.Rows[0]["Status"].ToString();
    //                    Session["NameID"] = dtAssessee.Rows[0]["NameID"].ToString();
    //                    Session["E_NameID"] = null;
    //                    Session["restore"] = null;
    //                    Session["AssesseeType"] = "Individual";
    //                    Session["AType"] = "";
    //                    Session["DateofBirth"] = dtAssessee.Rows[0]["DateofBirth"].ToString();
    //                    Session["ITR"] = "1";
    //                    Session["ay"] = "2014-2015";
    //                    Session["duedate"] = "31-07-2014";

    //                    str_Redirect = "Presentation/DisplayForm.aspx";
    //                }
    //                else
    //                {
    //                    Session["Mode"] = "New";
    //                    str_Redirect = "Presentation/individual.aspx";
    //                }
    //            }
    //            //if (Session["Project"].ToString() == "stax")
    //            //    str_Redirect = "DisplayForm.aspx";
    //            str_Redirect = "Presentation/itr1.aspx";
    //            if (x == 0 && Y != 0)
    //            {
    //                //Response.Redirect("Main.aspx");
    //                Session["UserName"] = txtUser1.Text;
    //                Response.Redirect(Request.Url.ToString());
    //            }
    //            else if (x == 0 && Y == 0)
    //            {
    //                //Response.Redirect("FormMain.aspx");
    //                //Response.Redirect("Main.aspx");
    //                Session["UserName"] = txtUser1.Text;
    //                Response.Redirect(Request.Url.ToString());
    //                //Session["Mode"] = "New";
    //                //Session["Bool"] = "False";
    //                //Response.Redirect("Assesseeselect.aspx");
    //            }
    //            else if (x == 2)
    //            {
    //                //mltView.ActiveViewIndex = 4;
    //                lblMsg.Text = "Username Incorrect";
    //                Session["chk"] = 0;
    //            }
    //            else if (x == 3)
    //            {
    //                lblMsg.Text = "Password Incorrect";
    //                Session["chk"] = 0;
    //            }
    //            // }
    //            //else
    //            //{
    //            //    mltView.ActiveViewIndex = 4;
    //            //    lblMessage.Text = "You are Already logged in";
    //            //    Session["chk"] = 0;
    //            //}
    //            //}


    //        }
    //    }
    //}
    protected void lnkSignup_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/presentation/login.aspx?Value=" + "Signup");
    }
    protected void lnkPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/presentation/login.aspx?Value=" + "pwd");
    }
