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
using System.Collections.Generic;
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
using System.Text;
using System.Net.Mail;

using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Taxation.DataAccess;

public partial class Presentation_Login : System.Web.UI.Page
{
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
    static string strPwd = "";
    static string SignUp_strPwd = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //string sqs = (Session["Project"] != null) ? Session["Project"].ToString() : "NULL";
        //if (Session["Project"] == null)
        //    Session["Project"] = "vt";
        //show view odf sign up or forget password when user will come from login popup nishu
        //FillCapctha();
        //Session["act"] = "unauthorized";
        //if (Session["user_id"] != null)
        //    Response.Redirect("../Default.aspx");
        if (Session["act"] == "unauthorized")
        {
            mltView.ActiveViewIndex = 1;
        }
        if (Request.QueryString["Value"] != null)
        {
            if (Request.QueryString["Value"] == "Signup")
            {
                mltView.ActiveViewIndex = 1;
                divSignup.Visible = false;
                divLogin.Visible = true;
            }
            else if (Request.QueryString["Value"] == "pwd")
            {
                mltView.ActiveViewIndex = 2;
                divSignup.Visible = false;
                divLogin.Visible = true;
            }
        }

        if (Session["Project"] == null)
            Session["Project"] = "";

        if (Session["act"] == null)
        {
            Session["act"] = null;
            hdnActivation.Value = "dd";
            //Response.Write("<script type='text/javascript'>alert('Your Login has been validated and you can proceed by Login Process Now!!'); </script>");
            //ClientScript.RegisterClientScriptBlock(GetType(), "abc", "<script type='text/javascript'>alert('Your Login has been validated and you can proceed by Login Process Now!!'); </script>");
        }
        hdnActivation.Value = "dd";
        //Response.Write("<script type='text/javascript'>alert('Your Login has been validated and you can proceed by Login Process Now!!'); </script>");
        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DynamicControl.Project_Name = "VS," + ApplicationHost + "," + Leftpath;
        //Reset Parameters
        DynamicControl.k = 2;
        DynamicControl.h = 1;

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["reason_logout"] != null)
            {
                lblTopMsg.Visible = true;
                lblTopMsg2.Visible = true;
                ltMsgTop.Text = "<p style='font-size:13px'>(Your Account will be unlocked after 20 minutes now!!)</p>";
                Session["reason_logout"] = null;
            }
            FillCapctha();
            DynamicControl.count_Check = "F";
            DynamicControl.Flag_Paging = "";

            txtPwd.Attributes.Add("onKeyPress", "doClick('" + btnLogin.ClientID + "',event)");
            //if (Session["reason_logout"] != null)
            //    "";
        }
        //FillCapctha();
        ScriptManager1.SetFocus(txtLogin);

        //if (txtLogin.Text != "" && txtPwd.Text != "")
        //{
        //    Login();
        //}
        //FillCapctha();
    }

    protected void ibtnCap_Click(object sender, ImageClickEventArgs e)
    {
        FillCapctha();
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
            if (mltView.ActiveViewIndex == 0)
                imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
            else
                imgCaptcha2.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {

            throw;
        }
    }

    protected void Page_PreInit(object sender, System.EventArgs e)
    {
        hdnActivation.Value = "preinit";
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        mltView.ActiveViewIndex = 1;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        mltView.ActiveViewIndex = 2;
    }
    protected void btnCreateUser_Click(object sender, EventArgs e)
    {
        if (lblEmailComfirmation.Visible == false)
        {
            if (Session["captcha"] == null)
                Response.Redirect(Request.Url.ToString());

            if ((this.txtimgcode2.Text).ToLower() == (Session["captcha"].ToString()).ToLower())
            {

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
                //objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
                //objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();


                //Create The Object of the Menu
                //objBltbl_Menu = new Bltbl_Menu(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
                //objtbl_Menu = new tbl_Menu();

                ////Create The Object of the User Module
                //objBltbl_User = new Bltbl_User(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
                //objtbl_User = new tbl_User();

                //Create The Object of the Role Management Module
                //objBltbl_RoleManagement = new Bltbl_RoleManagement(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
                //objtbl_RoleManagement = new tbl_RoleManagement();

                objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
                objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
                //objtbl_User = new tbl_User();
                objtbl_UserGroupRegistration.EmailID = txtUserID.Text;
                Session["EmailID"] = txtLogin.Text;
                objtbl_UserGroupRegistration.Password = txtPassword.Text;
                //objtbl_User.User_Name = txtLogin.Text;
                ////objtbl_User.User_Name = "abc@abc.com";
                //objtbl_User.Password = txtPwd.Text;
                //objtbl_User.Password = "abc";

                //objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration();
                //bool Is_Exist = objBltbl_UserGroupRegistration.Check_Admin_Credentials(objtbl_UserGroupRegistration);
                bool Is_Exist = objBltbl_UserGroupRegistration.CheckExistence(objtbl_UserGroupRegistration);

                if (!Is_Exist)
                {
                    int Success = Save_User_Admin();
                    if (Success == 1)
                    {
                        string Email_ID = txtUserID.Text;
                        objtbl_UserGroupRegistration.EmailID = Email_ID;
                        dt = objBltbl_UserGroupRegistration.GetUserId_Email(objtbl_UserGroupRegistration);
                        Int64 ID = Convert.ToInt32(dt.Rows[0]["Super_User_Id"]);
                        Session["ID"] = ID;
                        //Following is commented to prevent entry in Accounts for the free user:
                        //common objcommon = new common();
                        //objcommon.SaveAccount(ID);
                        balAdmin objbalAdmin = new balAdmin();
                        objbalAdmin.Update_User_AccID(ID);
                        Send_Email();
                        mltView.ActiveViewIndex = 4;
                        pnlLogged.Visible = true;
                        divMsg.Visible = false;
                        //DataTable dt = new DataTable();
                        ////Fill DataTable With Records
                        //string Account_Type = "U";
                        //string Email_ID = txtUserID.Text;
                        //objtbl_UserGroupRegistration.EmailID = Email_ID;
                        //dt = objBltbl_UserGroupRegistration.GetUserId_Email(objtbl_UserGroupRegistration);
                        //int ID = Convert.ToInt32(dt.Rows[0]["Super_User_Id"]);

                        //string serviceType = (Session["Project"] != null) ? Session["Project"].ToString() : "U";
                        ////string Active_Link = @"Your Activation links:<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/chkValidationUser.aspx?ID=" + base.Server.UrlEncode(ID.ToString()) + "&ActiveCode=" + HttpContext.Current.Session.SessionID.ToString() + "&AccountType=" + Account_Type + "&ST=" + serviceType + ">Click here to activate your account</a>";
                        //string Active_Link = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/chkValidationUser.aspx?ID=" + base.Server.UrlEncode(ID.ToString()) + "&ActiveCode=" + HttpContext.Current.Session.SessionID.ToString() + "&AccountType=" + Account_Type + "&ST=" + serviceType;
                        //Response.Redirect(Active_Link);
                        lblMessage.Text = "A Validation Link has been sent to your Email. Please check and Validate Your Account to proceed further.";
                        //Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    pnlLogged.Visible = true;
                    mltView.ActiveViewIndex = 4;
                    lblMessage.Text = "User Already Exists!!";
                }
                //denLogin objLoginDEN;
                //bllLogin objLoginBLL;

                //objLoginDEN = new denLogin();
                //objLoginBLL = new bllLogin();
                //if (Page.IsValid)
                //{
                //    objLoginDEN.PersonName = txtName.Text;
                //    objLoginDEN.UserName = txtUserID.Text;
                //    objLoginDEN.PAN = txtPAN.Text;


                //    objLoginDEN.Password = txtPassword.Text;
                //    objLoginDEN.SecretQuestion = ddlQuestions.SelectedValue;
                //    objLoginDEN.SecretAns = txtSecAnswer.Text;
                //    i = objLoginBLL.CheckUserName(objLoginDEN);
                //    if (i == 0)
                //    {
                //        objLoginBLL.CreateNewUser(objLoginDEN);
                //        mltView.ActiveViewIndex = 4;
                //        lblMessage.Text = "User Created";
                //        Session["chk"] = 0;
                //    }
                //    else
                //    {
                //        mltView.ActiveViewIndex = 4;
                //        lblMessage.Text = "User Already Exists";
                //        Session["chk"] = 1;
                //    }
                txtName.Text = "";
                txtUserID.Text = "";
                //txtPAN.Text = "";
                txtPassword.Text = "";
                ddlQuestions.SelectedIndex = 0;
                txtSecAnswer.Text = "";
                //}
            }
        }
    }

    protected void txtUserID_TextChanged(object sender, System.EventArgs e)
    {
        Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
        tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        objtbl_UserGroupRegistration.EmailID = txtUserID.Text;
        objtbl_UserGroupRegistration.Password = "";
        bool Is_Exist = objBltbl_UserGroupRegistration.CheckExistence(objtbl_UserGroupRegistration);
        if (Is_Exist)
            lblEmailComfirmation.Visible = true;
        else
            lblEmailComfirmation.Visible = false;
    }

    public int Save_User_Admin()
    {
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.Previous_Table = "";
        string User_Name = txtName.Text;
        string Password = txtPassword.Text;
        string Confirm_Password = txtPasswordConfirm.Text;
        string Is_deleted = "N";
        string Change_Password = "No";
        string Select_Role = "user";// "Staff";
        string Attempt_Unlock = "No";
        int Consecutive_Attempts = Convert.ToInt32("0");

        objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
        objtbl_UserInfo_Mangement = new tbl_UserInfo_Mangement();
        objBltbl_UserInfo_Mangement = new Bltbl_UserInfo_Mangement(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);

        objtbl_UserGroupRegistration.Name = User_Name;
        objtbl_UserGroupRegistration.Last_Name = "";
        objtbl_UserGroupRegistration.EmailID = txtUserID.Text;
        objtbl_UserGroupRegistration.Password = Password;
        objtbl_UserGroupRegistration.Confirm_Password = Confirm_Password;
        objtbl_UserGroupRegistration.Address1 = "";
        objtbl_UserGroupRegistration.Country = 0;
        objtbl_UserGroupRegistration.State = "0";
        objtbl_UserGroupRegistration.City = "";
        objtbl_UserGroupRegistration.PinCode = 0;
        objtbl_UserGroupRegistration.MobileNumber = "";
        objtbl_UserGroupRegistration.STDCODE = 0;
        objtbl_UserGroupRegistration.Telephone = "";
        objtbl_UserGroupRegistration.OrganizationName = "5";
        objtbl_UserGroupRegistration.SecurityQuestion = ddlQuestions.SelectedItem.Text;
        objtbl_UserGroupRegistration.Answer = txtSecAnswer.Text;
        objtbl_UserGroupRegistration.SelectPackage = "FREE";
        objtbl_UserGroupRegistration.ActivationCode = "";
        objtbl_UserGroupRegistration.STATUS = "";
        objtbl_UserGroupRegistration.Join_Date = DateTime.Now;
        if (Session["AssesseeUser"] != null)
        {
            objtbl_UserGroupRegistration.Account_Type = (Session["AssesseeUser"].ToString() == "2") ? "E" : "S";
        }
        else
            objtbl_UserGroupRegistration.Account_Type = "U";

        objtbl_UserGroupRegistration.Page_ID = "504";
        objtbl_UserGroupRegistration.Page_SubModule_ID = "33";
        objtbl_UserGroupRegistration.Is_Login_Active = "N";

        //objtbl_UserInfo_Mangement.Is_Deleted = Is_Deleted;
        //Call Insert Function and Pass Parameter to the Function
        int Success = objBltbl_UserGroupRegistration.InsertRegistrationEntry(objtbl_UserGroupRegistration);
        int success1 = 0;
        if (Success == 1)
        {
            //Get the UserId
            int User_ID = objBltbl_UserGroupRegistration.Get_User_ID(objtbl_UserGroupRegistration);
            objtbl_UserInfo_Mangement.User_Id = User_ID;
            objtbl_UserInfo_Mangement.Can_Change_Password = Change_Password;
            objtbl_UserInfo_Mangement.Role = Select_Role.ToString();
            objtbl_UserInfo_Mangement.Is_Locked = Attempt_Unlock;
            objtbl_UserInfo_Mangement.Consecutive_Attempts = Consecutive_Attempts;
            objtbl_UserInfo_Mangement.Is_Deleted = Is_deleted;
            objtbl_UserInfo_Mangement.Page_ID = "504";
            objtbl_UserInfo_Mangement.Page_SubModule_ID = "33";
            //Call Insert Function and Pass Parameter to the Function
            success1 = objBltbl_UserInfo_Mangement.InsertUser_Info(objtbl_UserInfo_Mangement);

            //if (Session["Project"].ToString() == "tds2")
            //{
            //    bllAssessee objbllAssessee = new bllAssessee();
            //    denAssesseeIndividual objdenAssesseeIndividual = new denAssesseeIndividual();
            //    objdenAssesseeIndividual.EMail = txtUserID.Text;
            //    objdenAssesseeIndividual.FirstName = (txtName.Text.Contains(" ")) ? txtName.Text.Substring(0, (txtName.Text.LastIndexOf(" "))) : txtName.Text;
            //    objdenAssesseeIndividual.LastName = (txtName.Text.Contains(" ")) ? txtName.Text.Substring(txtName.Text.LastIndexOf(" ") + 1) : txtName.Text;
            //    objdenAssesseeIndividual.no_of_dependents = 0;
            //    objdenAssesseeIndividual.PANNO = "";
            //    objdenAssesseeIndividual.PEInIndia = 0;
            //    objdenAssesseeIndividual.PEOutIndia = 0;
            //    objdenAssesseeIndividual.ResStatus = 0;
            //    objdenAssesseeIndividual.Salute = 0;
            //    objdenAssesseeIndividual.Status = 0;
            //    objdenAssesseeIndividual.TypeofAss = 0;
            //    objdenAssesseeIndividual.UserName = txtUserID.Text;
            //    objdenAssesseeIndividual.Vtype = 0;
            //    objdenAssesseeIndividual.MiddleName = "";
            //    objdenAssesseeIndividual.FatherName = "";
            //    objdenAssesseeIndividual.DateofBirth = "";
            //    objdenAssesseeIndividual.Address = "";
            //    objdenAssesseeIndividual.AdhaarNo = "";
            //    objdenAssesseeIndividual.BussNature = "";
            //    objdenAssesseeIndividual.EmployerCategory = "";
            //    objdenAssesseeIndividual.PhoneNo = "";
            //    objdenAssesseeIndividual.ServiceTaxRegNo = "";
            //    objdenAssesseeIndividual.STDCODE = "";
            //    objdenAssesseeIndividual.TANNO = "";
            //    objdenAssesseeIndividual.WardCircle = "";
            //    objbllAssessee.InsertNameMastIndividual(objdenAssesseeIndividual);

            //    bllAddress objbllAddress = new bllAddress();
            //    denAddress objdenAddress = new denAddress();
            //    objdenAddress.Address = "";
            //    objdenAddress.Area = "";
            //    objdenAddress.City = "";
            //    objdenAddress.Country = "India";
            //    objdenAddress.Flat = "";
            //    objdenAddress.mobile1 = "";
            //    objdenAddress.mobile2 = "";
            //    objdenAddress.NameID = "PAN";
            //    objdenAddress.PhoneNo = "";
            //    objdenAddress.PIN = "";
            //    objdenAddress.Premises = "";
            //    objdenAddress.Road = "";
            //    objdenAddress.State = "";
            //    objdenAddress.STDCODE = "";
            //    objdenAddress.Vtype = 0;
            //    objbllAddress.InsertAddress(objdenAddress);
                
            //}

            //if (success1 == 1)
            //{
            //    objtbl_UserGroupRegistration.Name = "-999999999";
            //    objBltbl_UserGroupRegistration.InsertRegistrationEntry(objtbl_UserGroupRegistration);
            //    //Bind_User_Admin_Grid();
            //    //tbCont_Menu_Management.ActiveTabIndex = 1;
            //    //Clear_Rec();
            //}
        }
        return success1;
    }

    protected void lbtnLogged_Click(object sender, System.EventArgs e)
    {
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.Previous_Table = "";

        objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
        objtbl_UserInfo_Mangement = new tbl_UserInfo_Mangement();
        objBltbl_UserInfo_Mangement = new Bltbl_UserInfo_Mangement(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
        divMsg.Visible = false;
        //pnlLogged.Visible = false;
        Send_Email_Activate();
        mltView.ActiveViewIndex = 4;
        lblMessage.Text = "A Validation Link has sent to your Registered Email.<br> In Order to re-active your account for further usage,<br> please click that link<br><br>";
        
    }

    protected void lbtnSendMail_Click(object sender, System.EventArgs e)
    {
        DataTable dt = new DataTable();
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
        objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
        objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();

        //Fill DataTable With Records
        string Account_Type = "U";
        if (Session["Account_Type"] != null)
            Account_Type = Session["Account_Type"].ToString();

        string Email_ID = txtLogin.Text;


        objtbl_UserGroupRegistration.EmailID = Email_ID;
        dt = objBltbl_UserGroupRegistration.GetUserId_Email(objtbl_UserGroupRegistration);
        if (dt.Rows.Count > 0)
        {
            int ID = Convert.ToInt32(dt.Rows[0]["Super_User_Id"]);
            Session["ID"] = ID;
            string ActivationCode = dt.Rows[0]["ActivationCode"].ToString();
            Session["ActivationCode"] = ActivationCode;
            string User_Name = dt.Rows[0]["Name"].ToString();
            string Last_Name = dt.Rows[0]["Last_Name"].ToString();
            //Here Create Activation Link with Activation Code and USer Id

            //string Active_Link = @"Your Activation links:<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Admin/UserGroupManagement/UserGroupRegistration.aspx?ID=" + base.Server.UrlEncode(ID.ToString()) + "&ActiveCode=" + ActivationCode + "&AccountType=" + Account_Type + ">Click here to activate your account</a>";
            string serviceType = (Session["Project"] != null) ? Session["Project"].ToString() : "U";
            string Active_Link = @"Your Activation links:<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/chkValidationUser.aspx?ID=" + base.Server.UrlEncode(ID.ToString()) + "&ActiveCode=" + HttpContext.Current.Session.SessionID.ToString() + "&AccountType=" + Account_Type + "&ST=" + serviceType + ">Click here to activate your account</a>";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Active_Link + "');", true);
            MailMessage mail = new MailMessage();
            mail.To.Add(Email_ID);

            mail.From = new MailAddress("info@echarteredaccountants.com");
            mail.Subject = "Account Activation Email of " + User_Name + "" + Last_Name + " from eCharteredAccountants.com";

            string Body = @"Hello " + User_Name + "" + Last_Name + ",<br/>Welcome to eCharteredAccountants.com, thanks for Registering with us.<br/><br/>To use your account,please activate your account by clicking the below activation Link.<br/>" + Active_Link + ".<br/><b>This is a system generated mail. Please do not reply to this email ID.</b><br/><br/>Warm Regards,<br/>Administartor,<br/>eCharteredAccountants.com.";
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.vatasinfotech.com"; //Or Your SMTP Server Address
            //smtp.Host = "smtp.mail.yahoo.com";
            smtp.Host = "smtp.vatasinfotech.com";
            smtp.Credentials = new System.Net.NetworkCredential
                  ("register@vatasinfotech.com", "Save1234");
            //Or your Smtp Email ID and Password
            //smtp.EnableSsl = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.Send(mail);

            mltView.ActiveViewIndex = 4;
            pnlLogged.Visible = true;
            divMsg.Visible = false;
            lblMessage.Text = "A Validation Link has been sent to your Email. Please check and Validate Your Account to proceed further.";
        }
    }

    //Function to the Send the Email to the User Created. 
    public void Send_Email()
    {
        DataTable dt = new DataTable();
        //Fill DataTable With Records
        string Account_Type = "U";
        if (Session["Account_Type"] != null)
            Account_Type = Session["Account_Type"].ToString();

        string Email_ID = txtUserID.Text;
        objtbl_UserGroupRegistration.EmailID = Email_ID;
        dt = objBltbl_UserGroupRegistration.GetUserId_Email(objtbl_UserGroupRegistration);
        int ID = Convert.ToInt32(dt.Rows[0]["Super_User_Id"]);
        Session["ID"] = ID;
        string ActivationCode = dt.Rows[0]["ActivationCode"].ToString();
        Session["ActivationCode"] = ActivationCode;
        string User_Name = dt.Rows[0]["Name"].ToString();
        string Last_Name = dt.Rows[0]["Last_Name"].ToString();
        //Here Create Activation Link with Activation Code and USer Id

        //string Active_Link = @"Your Activation links:<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Admin/UserGroupManagement/UserGroupRegistration.aspx?ID=" + base.Server.UrlEncode(ID.ToString()) + "&ActiveCode=" + ActivationCode + "&AccountType=" + Account_Type + ">Click here to activate your account</a>";
        string serviceType = (Session["Project"] != null) ? Session["Project"].ToString() : "U";
        string Active_Link = @"Your Activation links:<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/chkValidationUser.aspx?ID=" + base.Server.UrlEncode(ID.ToString()) + "&ActiveCode=" + HttpContext.Current.Session.SessionID.ToString() + "&AccountType=" + Account_Type + "&ST=" + serviceType + ">Click here to activate your account</a>";
        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Active_Link + "');", true);
        MailMessage mail = new MailMessage();
        mail.To.Add(Email_ID);

        mail.From = new MailAddress("info@echarteredaccountants.com");
        mail.Subject = "Account Activation Email of " + User_Name + "" + Last_Name + " from eCharteredAccountants.com";

        string Body = @"Hello " + User_Name + "" + Last_Name + ",<br/>Welcome to eCharteredAccountants.com, thanks for Registering with us.<br/><br/>To use your account,please activate your account by clicking the below activation Link.<br/>" + Active_Link + ".<br/><b>This is a system generated mail. Please do not reply to this email ID.</b><br/><br/>Warm Regards,<br/>Administartor,<br/>eCharteredAccountants.com.";
        mail.Body = Body;

        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        //smtp.Host = "smtp.vatasinfotech.com"; //Or Your SMTP Server Address
        //smtp.Host = "smtp.mail.yahoo.com";
        smtp.Host = "smtp.vatasinfotech.com";
        smtp.Credentials = new System.Net.NetworkCredential
              ("register@vatasinfotech.com", "Save1234");
        //Or your Smtp Email ID and Password
        //smtp.EnableSsl = true;
        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
        smtp.Send(mail);
    }

    //Function to the Send the Email to the User Created. 
    public void Send_EmailPwd(string pwd)
    {
        DataTable dt = new DataTable();
        //Fill DataTable With Records
        //objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        //objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration();


        string Account_Type = "U";
        string Email_ID = txtUserName.Text;
        objtbl_UserGroupRegistration.EmailID = Email_ID;
        dt = objBltbl_UserGroupRegistration.GetUserId_Email(objtbl_UserGroupRegistration);
        int ID = Convert.ToInt32(dt.Rows[0]["Super_User_Id"]);
        Session["ID"] = ID;
        string ActivationCode = dt.Rows[0]["ActivationCode"].ToString();
        Session["ActivationCode"] = ActivationCode;
        string User_Name = dt.Rows[0]["Name"].ToString();
        string Last_Name = dt.Rows[0]["Last_Name"].ToString();

        //string Active_Link = @"Your Activation links:<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Admin/UserGroupManagement/UserGroupRegistration.aspx?ID=" + base.Server.UrlEncode(ID.ToString()) + "&ActiveCode=" + ActivationCode + "&AccountType=" + Account_Type + ">Click here to activate your account</a>";
        //string Active_Link = @"Please check Your Password Here: <b>" + pwd + "</b>";
        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Active_Link + "');", true);
        MailMessage mail = new MailMessage();
        mail.To.Add(Email_ID);

        mail.From = new MailAddress("info@echarteredaccountants.com");
        mail.Subject = "Password Recovery of " + User_Name + "" + Last_Name + " from eCharteredAccountants.com";

        string Body = @"Hello " + User_Name + "" + Last_Name + ",<br/>Welcome to eCharteredAccountants.com, Please check your password here:" + pwd + " <br></b><br/>Warm Regards,<br/>Administartor,<br/>eCharteredAccountants.com.";
        mail.Body = Body;

        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.vatasinfotech.com"; //Or Your SMTP Server Address
        smtp.Credentials = new System.Net.NetworkCredential
             ("register@vatasinfotech.com", "Save1234");
        //Or your Smtp Email ID and Password
        //smtp.EnableSsl = true;
        smtp.Send(mail);
    }

    //Function to the Send the Email when user already Logged In
    public void Send_Email_Activate()
    {
        DataTable dt = new DataTable();

        string Account_Type = "U";
        string Email_ID = txtLogin.Text;
        objtbl_UserGroupRegistration.EmailID = Email_ID;
        dt = objBltbl_UserGroupRegistration.GetUserId_Email(objtbl_UserGroupRegistration);
        int ID = Convert.ToInt32(dt.Rows[0]["Super_User_Id"]);
        Session["ID"] = ID;
        string ActivationCode = dt.Rows[0]["ActivationCode"].ToString();
        Session["ActivationCode"] = ActivationCode;
        string User_Name = dt.Rows[0]["Name"].ToString();
        string Last_Name = dt.Rows[0]["Last_Name"].ToString();


        //string Active_Link = @"Your Activation links:<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Admin/UserGroupManagement/UserGroupRegistration.aspx?ID=" + base.Server.UrlEncode(ID.ToString()) + "&ActiveCode=" + ActivationCode + "&AccountType=" + Account_Type + ">Click here to activate your account</a>";
        string serviceType = (Session["Project"] != null) ? Session["Project"].ToString() : "U";
        string Active_Link = @"<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/chkValidationUser.aspx?ID=" + base.Server.UrlEncode(ID.ToString()) + "&ActiveCode=" + HttpContext.Current.Session.SessionID.ToString() + "&AccountType=" + Account_Type + "&ST=" + serviceType + "&acv=ae>Click Here</a><br><br>";
        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Active_Link + "');", true);
        MailMessage mail = new MailMessage();
        mail.To.Add(Email_ID);

        mail.From = new MailAddress("register@vatasinfotech.com");
        mail.Subject = "User Identity Checking for User " + User_Name + "" + Last_Name + " By ECharteredAccountants.com";

        string Body = @"Hello " + User_Name + "" + Last_Name + ",<br/>On your special request we are validating your account.<br/><br/>To use your account further,please re-activate your account by clicking the below activation Link.<br/>" + Active_Link + ".<br/><b>This is a system generated mail. Please do not reply to this email ID.</b><br/><br/>Warm Regards,<br/>Administartor,<br/>eCharteredAccountants.com.";
        mail.Body = Body;

        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.vatasinfotech.com"; //Or Your SMTP Server Address
        smtp.Credentials = new System.Net.NetworkCredential
              ("register@vatasinfotech.com", "Save1234");
        //Or your Smtp Email ID and Password
        //smtp.EnableSsl = true;
        smtp.Send(mail);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        mltView.ActiveViewIndex = 0;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Session["userAttempts"] != null)
        {
            if (Session["userAttempts"].ToString() == "5")
            {
                //objBltbl_UserGroupRegistration.Set_Active_Login()
                balAdmin objbalAdmin = new balAdmin();
                objbalAdmin.deActiveUser(txtLogin.Text);
                this.ClientScript.RegisterStartupScript(this.GetType(), "Some Title", "<script type='text/javascript'>" + "$('#modal_dialog1').dialog({title: 'Error Message',width: 430,height: 250,modal: true,buttons: { Close: function () {$(this).dialog('close');}}});" + "</script>");
            }
            else
            {
                Login();                
            }
        }
        else
            Login();
    }

    private void Login()
    {
        //if (this.txtimgcode.Text == Session["CaptchaImageText"].ToString())
        if (Session["captcha"] == null)
            Response.Redirect(Request.Url.ToString());

        if ((this.txtimgcode.Text).ToLower() == (Session["captcha"].ToString()).ToLower())
        {
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

            objtbl_UserGroupRegistration.EmailID = txtLogin.Text;
            objtbl_UserGroupRegistration.Password = txtPwd.Text;
            objtbl_User.User_Name = txtLogin.Text;
            //objtbl_User.User_Name = "abc@abc.com";
            objtbl_User.Password = txtPwd.Text;
            //objtbl_User.Password = "abc";

            bool Is_Exist = objBltbl_UserGroupRegistration.Check_Admin_Credentials(objtbl_UserGroupRegistration);
			if(!Is_Exist)
				        throw new System.ArgumentException("Does not exists" + Is_Exist, "original");
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
                //else if (Account_Type == "A")
                //{
                //    //Response.Redirect("~/User_Admin/MainAdminSection.aspx");

                //    //Response.Redirect("http://192.168.1.125:83/User_Admin/MainAdminSection.aspx");
                //    //Response.Redirect(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ":83/User_Admin/MainAdminSection.aspx");

                //}
                else if (Account_Type == "U" || Account_Type == "S" || Account_Type == "BMC" || Account_Type == "A" || Account_Type == "E" || Account_Type == "US" || Account_Type == "D")  
                {
                    ViewState["Account_Type"] = Account_Type;
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

                        //objBltbl_UserGroupRegistration.Get_Login_Session_Information_ID(

                        Session["userAttempts"] = null;
                        //Response.Redirect("~/Main.aspx");
                        //CreateAndStoreSessionToken(txtLogin.Text);
                        getLogin();

                    }
                    else
                    {
                        //check if the account is locked before more than 20 minutes as if so then unlock it

                        balAdmin objbalAdmin = new balAdmin();
                        int IsUnlocked = 0;
                        IsUnlocked = objbalAdmin.unlockUser(Convert.ToInt32(Session["User_ID"]));
                        if (IsUnlocked == 0)
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Some Title", "<script type='text/javascript'>" + "$('#modal_dialog1').dialog({title: 'Error Message',width: 430,height: 250,modal: true,buttons: { Close: function () {$(this).dialog('close');}}});" + "</script>");
                        else
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Some Title", "<script type='text/javascript'>" + "$('#modal_dialog2').dialog({title: 'Error Message',width: 430,height: 250,modal: true,buttons: { Close: function () {$(this).dialog('close');}}});" + "</script>");

                        //ltrIsApproveCheck.Text = "Sorry your account is locked you have exceeded maximum login attempts. Please Contact Your Adminstration! ";
                    }
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "Some Title", "<script type='text/javascript'>" + "$('#modal_dialog').dialog({title: 'Error Message',width: 430,height: 250,modal: true,buttons: { Close: function () {$(this).dialog('close');}}});" + "</script>");
                //$(this).dialog('close');
                if (Session["userAttempts"] == null)
                    Session["userAttempts"] = "1";
                else
                {
                    int cnt = Convert.ToInt32(Session["userAttempts"]);
                    cnt += 1;
                    Session["userAttempts"] = cnt.ToString();
                }






                //hdnCheck.Value = "Invalid";
                //string message="Please Check Either Your UserName or Password is Not Correct!";
                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
            }
            FillCapctha();
        }
        else
        {
            Label6.Text = "Security Code is not Valid.";
        }
        this.txtimgcode.Text = "";
    }

    public void AddSession(string userID, string password)
    {
        //put your login logic here and put the logged in user object in the session.

        //getting the sessions objects from the Application
        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
        if (sessions == null)
        {
            sessions = new Hashtable();
        }
        
        //getting the pointer to the Session of the current logged in user

        System.Web.SessionState.HttpSessionState existingUserSession =
             (System.Web.SessionState.HttpSessionState)sessions[userID];
        if (existingUserSession != null)
        {
            //existingUserSession["WebKeys.USEROBJECT"] = null;
            // already login
            //logout current logged in user
        }
        else
        {
            //putting the user in the session
            Session["WebKeys.USEROBJECT"] = userID;
            sessions["user.UserName"] = Session;
            Application.Lock(); //lock to prevent duplicate objects
            Application["WEB_SESSIONS_OBJECT"] = sessions;
            Application.UnLock();
        }
    }

    //internal static void CreateAndStoreSessionToken(string userName)
    //{
    //    // Will be using the response object several times
    //    HttpResponse pageResponse = HttpContext.Current.Response;

    //    // 'session' token
    //    Guid sessionToken = System.Guid.NewGuid();

    //    // Get authentication cookie and ticket
    //    HttpCookie authenticationCookie =
    //        pageResponse.Cookies[FormsAuthentication.FormsCookieName];

    //    FormsAuthenticationTicket newAuthenticationTicket = null;
    //    MembershipUser currentUser = null;
    //    //if (authenticationCookie.Value != null)
    //    //{
    //    //    FormsAuthenticationTicket authenticationTicket =
    //    //        FormsAuthentication.Decrypt(authenticationCookie.Value);

    //    //    // Create a new ticket based on the existing one that includes the 'session' token in the userData
    //    //    newAuthenticationTicket =
    //    //        new FormsAuthenticationTicket(
    //    //        authenticationTicket.Version,
    //    //        authenticationTicket.Name,
    //    //        authenticationTicket.IssueDate,
    //    //        authenticationTicket.Expiration,
    //    //        authenticationTicket.IsPersistent,
    //    //        sessionToken.ToString(),
    //    //        authenticationTicket.CookiePath);

    //    //    currentUser = Membership.GetUser(userName);
    //    //}
    //    //else
    //    //{
    //    //    // Create a new ticket based on the existing one that includes the 'session' token in the userData
    //    //    //newAuthenticationTicket =
    //    //    //    new FormsAuthenticationTicket(
    //    //    //    1,
    //    //    //    userName,
    //    //    //    DateTime.Now,
    //    //    //    DateTime.Now.AddMinutes(2),
    //    //    //    true,
    //    //    //    sessionToken.ToString(),
    //    //    //    string.Empty);

    //    //    newAuthenticationTicket =
    //    //        new FormsAuthenticationTicket(
    //    //        userName,
    //    //        true,
    //    //        2);

    //    //    currentUser = Membership.GetUser(authenticationCookie.Name);
    //    //}
    //    // Store session token in Membership comment
    //    // You may want to store other information in the comment
    //    // field, if so, you may have to implement some dilimited
    //    // structure within it, perhaps xml
       
    //    currentUser.Comment = sessionToken.ToString();        
    //    Membership.UpdateUser(currentUser);

    //    // Replace the authentication cookie
    //    pageResponse.Cookies.Remove(FormsAuthentication.FormsCookieName);

    //    HttpCookie newAuthenticationCookie = new HttpCookie(
    //        FormsAuthentication.FormsCookieName,
    //        FormsAuthentication.Encrypt(newAuthenticationTicket));

    //    newAuthenticationCookie.HttpOnly = authenticationCookie.HttpOnly;
    //    newAuthenticationCookie.Path = authenticationCookie.Path;
    //    newAuthenticationCookie.Secure = authenticationCookie.Secure;
    //    newAuthenticationCookie.Domain = authenticationCookie.Domain;
    //    newAuthenticationCookie.Expires = authenticationCookie.Expires;

    //    pageResponse.Cookies.Add(newAuthenticationCookie);
    //}

    private void InsertLoginSession()
    {
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
    }

    private void getLogin()
    {
        int x, Y;
        if (Session["Project"] == null)
            Session["Project"] = "";

        Session["chk"] = -1;

        if (Page.IsValid)
        {
            denLogin objLoginDEN;
            bllLogin objLoginBLL;
            bllMain objMainBLL;

            objLoginDEN = new denLogin();
            objLoginBLL = new bllLogin();
            objMainBLL = new bllMain();
            objLoginDEN.UserName = txtLogin.Text;
            objLoginDEN.Password = txtPwd.Text;
            objLoginDEN.SessionID = Session.SessionID;
            objLoginDEN.LoginTime = DateTime.Now.ToShortTimeString();
            objLoginDEN.LogoutStatus = 0;
            x = objLoginBLL.CheckUserNamePassword(objLoginDEN);
            Y = objMainBLL.CountNames(txtLogin.Text);
            denLogin objLoginDEN2;
            objLoginDEN2 = new denLogin();
            int counter;
            counter = objLoginBLL.CountUser(txtLogin.Text);
            if (counter == 0)
            {
                objLoginBLL.InsertLoginDetails(objLoginDEN);
            }
            else if (counter != 0)
            {
                objLoginDEN.UserName = txtLogin.Text;// Convert.ToString(Session["UserName"]);
                //======================================================
                //code to update logindetails table at user login
                //Like new sessionID,new logintime etc
                //======================================================

                objLoginBLL.UpdateLoginInfo(objLoginDEN);
                denLogin objLogin2 = new denLogin();
                objLogin2 = objLoginBLL.Select(objLoginDEN.UserName);

                Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
                tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
                balAdmin objbalAdmin = new balAdmin();
                string session_status = objbalAdmin.getLoginSession(objLogin2.Super_User_Id);
                //if (session_status != "NA")
                //{
                objLogin2.LoginTime = DateTime.Now.ToString();
                Session["user_name"] = objLogin2.PersonName;

                string str_Redirect = "Main.aspx";
                Session["userEmail"] = txtLogin.Text;
                //if (objLogin2.Account_Type == "S")
                DataTable dtAssessee = new DataTable();
                dtAssessee = objLoginBLL.getAssesseeCount(txtLogin.Text);
                
                if (Session["Project"].ToString() == "vt")
                {
                    if (dtAssessee.Rows.Count > 0 && Session["AssesseeUser"] != null && ViewState["Account_Type"].ToString() != "BMC")
                    {
                        bllAssessee objbllAssessee = new bllAssessee();
                        for (int i = 0; i < dtAssessee.Rows.Count; i++)
                        {
                            objbllAssessee.DeleteStoreTrans(dtAssessee.Rows[i]["NameID"].ToString());
                        }
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
                        bllAssessee objbllAssessee = new bllAssessee();
                        for (int i = 0; i < dtAssessee.Rows.Count; i++)
                        {
                            objbllAssessee.DeleteStoreTrans(dtAssessee.Rows[i]["NameID"].ToString());
                        }
                        Session["Mode"] = "New";
                        str_Redirect = "individual.aspx";
                    }

                    Session["Account_Type"] = "U";
                    if (objLogin2.Account_Type == "S" || objLogin2.Account_Type == "E" || objLogin2.Account_Type == "US" || objLogin2.Account_Type == "D")
                    {
                        Session["Account_Type"] = objLogin2.Account_Type;
                        if (dtAssessee.Rows.Count > 0)
                        {
                            str_Redirect = "Main.aspx";
                        }
                        else
                        {
                            Session["Mode"] = "New";
                            str_Redirect = "AssesseeSelect.aspx";
                        }
                    }
                    else if (ViewState["Account_Type"].ToString() == "BMC")
                    {
                        BALVatasETDS.User_Admin.tbl_UserInfo_Mangement objtbl_UserInfo_Mangement = new tbl_UserInfo_Mangement();
                        objBltbl_UserInfo_Mangement = new Bltbl_UserInfo_Mangement(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
                        //BALVatasETDS.User_Admin.Bltbl_UserInfo_Mangement objBltbl_UserInfo_Mangement = new Bltbl_UserInfo_Mangement();
                        objtbl_UserInfo_Mangement.User_Id = Convert.ToInt32(Session["user_id"]);
                        DataTable dtInfo = new DataTable();
                        dtInfo = objBltbl_UserInfo_Mangement.GetUserInfoByID(objtbl_UserInfo_Mangement);
                        if (dtInfo.Rows.Count > 0)
                        {
                            if (dtInfo.Rows[0]["Role"].ToString() == "FO")
                                str_Redirect = "Main.aspx";
                            else if (dtInfo.Rows[0]["Role"].ToString() == "SU")
                                str_Redirect = "allocateAssessee.aspx";
                            else if (dtInfo.Rows[0]["Role"].ToString() == "BO")
                                str_Redirect = "itr1.aspx";
                            else if (dtInfo.Rows[0]["Role"].ToString() == "M")
                                str_Redirect = "bmcReturns.aspx";
                            else
                                str_Redirect = "itr1.aspx";
                        }
                        Session["UserRole"] = dtInfo.Rows[0]["Role"].ToString();
                        Session["Account_Type"] = ViewState["Account_Type"].ToString();
                    }
                    else
                    {
                        //str_Redirect = "itr1.aspx";
                        str_Redirect = "Main.aspx";
                    }
                    InsertLoginSession();
                    if (objtbl_RoleManagement.Role_Name == "Operator" || objtbl_RoleManagement.Role_Name == "Supervisor" || objtbl_RoleManagement.Role_Name == "Reception")
                    {
                        Session["UserRole"] = objtbl_RoleManagement.Role_Name;
                        if (objtbl_RoleManagement.Role_Name == "Reception")
                            str_Redirect = "Reception/Default.aspx";
                        else if (objtbl_RoleManagement.Role_Name == "Operator")
                            str_Redirect = "Operator.aspx";
                        else if (objtbl_RoleManagement.Role_Name == "Supervisor")
                            str_Redirect = "Supervisor.aspx";
                    }
                    //Application["User_Sessions"] = Application["User_Sessions"].ToString() + "~" + Session["User_ID"].ToString();
                }
                else if (Session["Project"].ToString() == "tds")
                {
                    InsertLoginSession();
                    if (objtbl_RoleManagement.Role_Name == "Operator" || objtbl_RoleManagement.Role_Name == "Supervisor" || objtbl_RoleManagement.Role_Name == "Reception")
                        Session["UserRole"] = objtbl_RoleManagement.Role_Name;
                    str_Redirect = "tds.aspx";
                }
                else if (Session["Project"].ToString() == "tds2")
                {
                    InsertLoginSession();

                    Session["Exists"] = 1;
                    Session["Bool"] = "False";
                    Session["Mode"] = "New";
                    //Session["PAN"] = Convert.ToString(dtAssessee.Rows[0]["PanNo"].ToString());
                    if (Session["Role_ID"].ToString() == "16")
                    {

                    }
                    else
                    {
                        if (dtAssessee.Rows.Count > 0)
                        {
                            Session["PAN"] = Convert.ToString(dtAssessee.Rows[0]["PanNo"].ToString());
                            Session["Status"] = dtAssessee.Rows[0]["Status"].ToString();
                            Session["NameID"] = dtAssessee.Rows[0]["NameID"].ToString();
                            Session["DateofBirth"] = dtAssessee.Rows[0]["DateofBirth"].ToString();
                            Session["E_NameID"] = null;
                            Session["restore"] = null;
                            Session["AssesseeType"] = "Individual";
                            Session["AType"] = "";
                            Session["ITR"] = "52";
                            Session["ay"] = "2016-2017";
                            Session["AY"] = "2016-2017";
                            Session["FY"] = "2015-2016";
                            Session["duedate"] = "31-07-2014";

                            bllSalary objbllSalary = new bllSalary();
                            objbllSalary.FetchTransData("15073", Session["NameID"].ToString(), "2016-2017", Convert.ToInt32(Session["NameID"]));
                            if (Session["Role_ID"].ToString() == "2032")
                                str_Redirect = "TDS_Staff.aspx";
                            else
                                str_Redirect = "TDSClientPay_Reporting.aspx";
                        }
                        else
                        {
                            str_Redirect = "AssesseeSelect.aspx";
                        }
                    }
                }
                else if (Session["Project"].ToString() == "stax")
                {
                    str_Redirect = "servicetax.aspx";
                }
                else
                {
                    InsertLoginSession();
                    if (objtbl_RoleManagement.Role_Name == "Operator" || objtbl_RoleManagement.Role_Name == "Supervisor" || objtbl_RoleManagement.Role_Name == "Reception")
                        Session["UserRole"] = objtbl_RoleManagement.Role_Name;
                    str_Redirect = "Services.aspx";
                }
                Session["UserName"] = txtLogin.Text;
                if (x == 0 && Y != 0)
                {
                    
                    Response.Redirect(str_Redirect);
                }
                else if (x == 0 && Y == 0)
                {
                    //Session["UserName"] = txtLogin.Text;
                    Response.Redirect(str_Redirect);
                }
                else if (x == 2)
                {
                    pnlLogged.Visible = false;
                    mltView.ActiveViewIndex = 4;
                    lblMessage.Text = "Username Incorrect";
                    Session["chk"] = 0;
                }
                else if (x == 3)
                {
                    pnlLogged.Visible = false;
                    mltView.ActiveViewIndex = 1;
                    lblMessage.Text = "Password Incorrect";
                    Session["chk"] = 0;
                }
                //    }
                //    else
                //    {
                //        // to forcefully logout the existing user
                //        //balAdmin objbalAdmin = new balAdmin();
                //        int lastID = objbalAdmin.getLastLoginID(Convert.ToInt32(Session["User_ID"]));   // this is the last ID for tbl_User_Session_Details table and this to set the Logout Status for the same record for the user
                //        //Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
                //        //tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
                //        objtbl_UserGroupRegistration.Logout_Time = DateTime.Now.ToString();
                //        objtbl_UserGroupRegistration.Logout_Nature = "LogOff";
                //        objtbl_UserGroupRegistration.Super_User_Id = Convert.ToInt32(Session["User_ID"]);
                //        objtbl_UserGroupRegistration.Time_OutID = lastID;
                //        objBltbl_UserGroupRegistration.Update_Logout_Time(objtbl_UserGroupRegistration);

                //        objbalAdmin.deActiveUser(Convert.ToInt32(Session["User_ID"]));

                //        pnlLogged.Visible = Visible;
                //        mltView.ActiveViewIndex = 4;
                //        lblMessage.Text = "User Already Login!!";
                //    }
            }
        }
    }

    //Function to automatically add assessee data into XML and tbl_ITRXML and to clear the storetrans accordingly

    public void ManageAssessees(string username)
    {
        string FilePath = "";   // MapPath("../xml/") + Session["NameID"].ToString() + ".xml";
        string NameID, AY, duedate;
        //bllAssessee objbllAssessee = new bllAssessee();
        //List<denAssesseeIndividual> LstAssessee = new List<denAssesseeIndividual>();
        //LstAssessee = objbllAssessee.Select(username);

        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        DataSet ds = new DataSet();
        ds = objbllStoreTrans.SelectUserData(username);
        for (int i = 0; i < ds.Tables.Count; i++)
        {
            for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
            {
                NameID = ds.Tables[i].Rows[j]["NameID"].ToString();
                AY = ds.Tables[i].Rows[j]["AY"].ToString();
                bllAssessee objbllAssessee = new bllAssessee();
                DataTable dtAll = new DataTable();
                dtAll = objbllAssessee.SelectAll(NameID);

                calcTax(NameID, AY, dtAll.Rows[0]["PANNo"].ToString());
            }
        }


        if (Session["ITR"].ToString() == "1")
        {
            //FilePath = (Server.MapPath("../xml/") + AY + "/" + NameID + "_1.xml");
            //System.IO.File.WriteAllText(FilePath, "");
            //objbllStoreTrans.genXML(NameID, AY, FilePath, "1", duedate);
        }
    }

    public void calcTax(string NameID, string AY, string PAN)
    {
        string duedate = "";
        string[] arr = System.Text.RegularExpressions.Regex.Split(AY, "-");
        duedate = "31/07/" + arr[0];

        denDocTrans objdenDocTrans = new denDocTrans();
        bllDocTrans objDocTransBLL = new bllDocTrans();
        objdenDocTrans = objDocTransBLL.GetBankDetails(Convert.ToString(Session["PAN"]));

        bllSalary objbllSalary = new bllSalary();
        decimal gIFS, gIFHP, gIFBUS, gIFSTCG, gIFLTCG, gIFOS, gDED, gDED1, gICE, gAI, gTDS, gTCS, gSelfAss, gATP, gCasuInc, gCLUB, gRelief, gTI, gGIT, gNIT, gSum_234, gSur, gEduCess, gRebate87A;
        gIFS = 0; gIFHP = 0; gIFBUS = 0; gIFSTCG = 0; gIFLTCG = 0; gIFOS = 0; gDED = 0; gDED1 = 0; gICE = 0; gAI = 0; gTDS = 0; gTCS = 0; gSelfAss = 0; gATP = 0; gCasuInc = 0; gCLUB = 0; gRelief = 0; gTI = 0; gGIT = 0; gNIT = 0; gSum_234 = 0;
        gSur = 0; gRebate87A = 0;
        gEduCess = 0;
        objbllSalary.SetAllZero(NameID, 49, AY, NameID, Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.calcSal("0", NameID, AY, (duedate == null) ? DateTime.Now.ToShortDateString() : (duedate), out gIFS, out  gIFHP, out  gIFBUS, out  gIFSTCG, out  gIFLTCG, out  gIFOS, out  gDED, out  gDED1, out  gICE, out  gAI, out  gTDS, out  gTCS, out  gSelfAss, out  gATP, out  gCasuInc, out  gCLUB, out  gRelief, out gTI, out gGIT, out gNIT, out gSum_234, out gEduCess, out gSur, out gRebate87A);

        //Response.Write("gIFS = " + gIFS + ", gIFHP = " + gIFHP + " , gIFBUS = " + gIFBUS + ", gIFSTCG= " + gIFSTCG + " , gIFLTCG =" + gIFLTCG + " , gIFOS = " + gIFOS + " , gDED= " + gDED + " , gDED1= " + gDED1 + " , gICE= " + gICE + ", gAI = " + gAI + " , gTDS = " + gTDS + " , gTCS = " + gTCS + " , gSelfAss = " + gSelfAss + " , gATP = " + gATP + ", gCasuInc = " + gCasuInc + " , gCLUB = " + gCLUB + ", gRelief = " + gRelief + ", gTI = " + gTI + ", gGIT = " + gGIT + ", gNIT = " + gNIT + ", gSum_234 = " + gSum_234 + ", gEduCess = " + gEduCess + ", gSur = " + gSur);

        Label lblNetTaxPayable = new Label();
        lblNetTaxPayable.Text = gNIT.ToString(); //(gNIT + gSum_234).ToString();

        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gIFS.ToString(), Convert.ToDecimal(9001), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, "L", Convert.ToDecimal(9002), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);   //for constantid=582 else s
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gIFHP.ToString(), Convert.ToDecimal(9003), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gIFOS.ToString(), Convert.ToDecimal(9004), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, (gIFBUS + gIFHP + gIFS + gIFOS + gIFLTCG + gIFSTCG).ToString(), Convert.ToDecimal(9005), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, (gIFBUS + gIFHP + gIFS + gIFOS + gIFLTCG + gIFSTCG - gDED - gDED1).ToString(), Convert.ToDecimal(9006), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);

        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, lblNetTaxPayable.Text, Convert.ToDecimal(9011), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, "0", Convert.ToDecimal(9012), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);   // Rebate 87A
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, "0", Convert.ToDecimal(9013), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);   //Tax Payable on Rebate

        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gSur.ToString(), Convert.ToDecimal(917), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 3, Convert.ToDecimal(0), 0);   //Surcharge
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gEduCess.ToString(), Convert.ToDecimal(1015), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 4, Convert.ToDecimal(0), 0);   //EducationCess

        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gRelief.ToString(), Convert.ToDecimal(881), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 6, Convert.ToDecimal(0), 0);   //Section89 - gRelief
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gSum_234.ToString(), Convert.ToDecimal(9019), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        if (!lblNetTaxPayable.Text.Contains("-"))
        {
            objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, lblNetTaxPayable.Text, Convert.ToDecimal(9025), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Balance Tax Payable
            objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, "0", Convert.ToDecimal(9034), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Refund Due
        }
        else
        {
            objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, "0", Convert.ToDecimal(9025), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Balance Tax Payable
            objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, lblNetTaxPayable.Text, Convert.ToDecimal(9034), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Refund Due
        }

        double tot_tax_paid = Convert.ToDouble(gATP + gTDS + gSelfAss);
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, tot_tax_paid.ToString(), Convert.ToDecimal(9030), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Tot Tax Paid

        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, objdenDocTrans.AccountNumber, Convert.ToDecimal(9035), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Assessee Account Number

        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, lblNetTaxPayable.Text, Convert.ToDecimal(9065), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //IncChrgSal
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gTDS.ToString(), Convert.ToDecimal(9066), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Total TDS Sal


        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, "0", Convert.ToDecimal(9016), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Gross Tax Liability   - no values known for now?
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, "0", Convert.ToDecimal(9018), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Net Tax Liability   - no values known for now?

        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gGIT.ToString(), Convert.ToDecimal(1117), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 1, Convert.ToDecimal(0), 0);    //Income Tax
        gRebate87A = gGIT - gRebate87A;
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, (gRebate87A).ToString(), Convert.ToDecimal(918), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 5, Convert.ToDecimal(0), 0);    //Total Tax
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, gGIT.ToString(), Convert.ToDecimal(1118), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 10, Convert.ToDecimal(0), 0);    //Total Tax Due

        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, "0", Convert.ToDecimal(1119), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 11, Convert.ToDecimal(0), 0);    //Tax Paid
        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, "0", Convert.ToDecimal(1120), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 12, Convert.ToDecimal(0), 0);    //Tax Payable/Refund

        objbllSalary.AddTaxDetails(NameID, 49, AY, NameID, (gDED + gDED1).ToString(), Convert.ToDecimal(9077), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 12, Convert.ToDecimal(0), 0);    //Total Deductions


    }

    //Function to create The Menu
    public StringBuilder CreateMenu(int RoleID)
    {
        objtbl_Menu.Role_ID = RoleID;

        StringBuilder sb_Menu = new StringBuilder();
        sb_Menu = objBltbl_Menu.Create_Menu(objtbl_Menu);
        return sb_Menu;
    }
    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        bllLogin objLoginBLL;
        objLoginBLL = new bllLogin();
        denLogin objLoginDEN;
        objLoginDEN = objLoginBLL.GetSecretQuestion(txtUserName.Text);
        txtSecQuestion.Text = objLoginDEN.SecretQuestion;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            bllLogin objLoginBLL;
            objLoginBLL = new bllLogin();
            denLogin objLoginDEN;
            objLoginDEN = objLoginBLL.GetPassword(txtUserName.Text, txtAnswer.Text);
            Session["chk"] = 0;
            pnlLogged.Visible = true;
            mltView.ActiveViewIndex = 4;
            if (objLoginDEN.Password != "" && objLoginDEN.Password != null)
            {
                //lblMessage.Text = "Your Password is :-" + objLoginDEN.Password;
                DBtbl_Module.ArrayIndex = 0;
                DBtbl_Module.Previous_RecordNo = 0;
                DBtbl_Module.lst_Query = new List<string>();
                DBtbl_Module.lst_Field = new Dictionary<string, int>();
                DBtbl_Module.Previous_Table = "";

                objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
                objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
                objtbl_UserInfo_Mangement = new tbl_UserInfo_Mangement();
                objBltbl_UserInfo_Mangement = new Bltbl_UserInfo_Mangement(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
                //lblPassword.Text = "Your Password:<span style='color:#EE5A3F'>" + objLoginDEN.Password + "</span>";

                //for sending mail:
                Send_EmailPwd(objLoginDEN.Password);
                lblMessage.Text = "An Email has been sent to your registered EmailID for the new Password.";
            }
            else
                lblMessage.Text = "Mismatch of secret answer";
        }
        else
        {
            pnlLogged.Visible = false;
            mltView.ActiveViewIndex = 4;
            lblMessage.Text = "Mismatch of secret answer";
            Session["chk"] = 2;
        }
    }
    protected void btnGoBackM_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["chk"]) == 0)
            mltView.ActiveViewIndex = 0;
        else if (Convert.ToInt32(Session["chk"]) == 1)
            mltView.ActiveViewIndex = 1;
        else if (Convert.ToInt32(Session["chk"]) == 2)
            mltView.ActiveViewIndex = 2;
        else if (Convert.ToInt32(Session["chk"]) == 10)
            Response.Redirect("main.aspx");
        else
            mltView.ActiveViewIndex = 0;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        mltView.ActiveViewIndex = 0;
    }
    //protected void Button3_Click(object sender, EventArgs e)
    //{



    //    bllUserMgmt objUserMgmtBLL = new bllUserMgmt();
    //    denUserMgmt objUserMgmtDEN = new denUserMgmt();
    //    objUserMgmtDEN.UserID = Convert.ToString(Session["UserName"]);

    //    objUserMgmtBLL.UpdateUser(objUserMgmtDEN);

    //}


    //for new design code:

    protected void Button3_Click(object sender, EventArgs e)
    {
        //bllUserMgmt objUserMgmtBLL = new bllUserMgmt();
        //denUserMgmt objUserMgmtDEN = new denUserMgmt();
        //objUserMgmtDEN.UserID = Convert.ToString(Session["UserName"]);

        //objUserMgmtBLL.UpdateUser(objUserMgmtDEN);



        mltView.ActiveViewIndex = 1;
        //show login button when sign portion show
        divSignup.Visible = false;
        divLogin.Visible = true;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        mltView.ActiveViewIndex = 1;
    }

    protected void btnlogin1_Click(object sender, EventArgs e)
    {
        mltView.ActiveViewIndex = 0;
    }
    protected void btnsignup_Click(object sender, EventArgs e)
    {
        mltView.ActiveViewIndex = 1;
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        mltView.ActiveViewIndex = 1;
        FillCapctha();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        //mltView.ActiveViewIndex = 0;
        Response.Redirect("Login.aspx");
    }

    protected void btnImgCaptcha_Click(object sender, EventArgs e)
    {
        this.txtimgcode.Text = "";
        if (this.txtimgcode.Text == Session["CaptchaImageText"].ToString())
        {
            Label6.Text = "";
        }
        else
        {
            Label6.Text = "";
        }
        this.txtimgcode.Text = "";
    }
    protected void Button4_Click1(object sender, System.EventArgs e)
    {
        //show signup button when login portion show
        mltView.ActiveViewIndex = 0;
        divSignup.Visible = true;
        divLogin.Visible = false;
    }


    protected void chkShowPassword_CheckedChanged(object sender, System.EventArgs e)
    {
        //if (Page.IsPostBack)
        //{
        if (chkShowPassword.Checked)
        {
            strPwd = txtPwd.Text;
            txtPwd.TextMode = TextBoxMode.SingleLine;
        }
        else
        {
            txtPwd.TextMode = TextBoxMode.Password;
            txtPwd.Attributes.Add("Value", txtPwd.Text);
        }
        //}
    }
    //protected void signupshowpw_CheckedChanged(object sender, System.EventArgs e)
    //{
    //    //if (Page.IsPostBack)
    //    //{
    //    if (signupshowpw.Checked)
    //    {
    //        SignUp_strPwd = txtPassword.Text;
    //        txtPassword.TextMode = TextBoxMode.SingleLine;
    //    }
    //    else
    //    {
    //        txtPassword.TextMode = TextBoxMode.Password;
    //        txtPassword.Attributes.Add("Value", txtPassword.Text);
    //    }
    //    //}
    //}
    protected void btnGoLogin_Click(object sender, EventArgs e)
    {
    }
}
