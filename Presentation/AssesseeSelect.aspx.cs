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
using Taxation.DataEntity;
using Taxation.BusinessLogic;
//using GetTDSReference;
using System.Globalization;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

public partial class Presentation_AssesseeSelect : System.Web.UI.Page
{
    static int StateID = 26;
    string errMsg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Added by Mudit on 30/06/2015 for deleting records if user comes back without generating XML
        
        //Request.Cookies["vtype"].Value = "106";
        bllAssessee objbllAssessee = new bllAssessee();
        if (Session["NameID"] != null)
        {

            string AY = (Session["AY"] != null) ? Session["AY"].ToString() : "";
            string NameID = Session["NameID"].ToString();
            //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'> alert('All Yor Data Will be Lost....!!');</script>");
            objbllAssessee.DeleteFromStoreTrans(NameID, AY);
        }
        if (Request.QueryString["U"] != null)
        {
            if (Request.QueryString["U"] == "PRY")
            {
                SiteMapPath1.SiteMapProvider = "eca_static_sitemap";
            }
        }
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
        if (!IsPostBack)
        {
            //print username nishu8/4/2015
            objbllAssessee.DeleteFromBankmast(Session["User_ID"].ToString());
            ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";

            //fill ITR Dropdown w.r.t. Project Name

            bllITR objbllITR = new bllITR();
            ddITR.DataSource = objbllITR.Select(Session["Project"].ToString());
            ddITR.DataTextField = "detail";
            ddITR.DataValueField = "title";
            ddITR.DataBind();

            ListItem LstF = new ListItem("Select", "-1");
            ddITR.Items.Insert(0, LstF);

            //For INCOME TAX
            //if (Session["Project"].ToString() == "vt")    
            //{
            //    divST.Visible = false;
            //    ListItem Lst1 = new ListItem("Individual", "0");
            //    ListItem Lst2 = new ListItem("Hindu Undivided Family (HUF)", "1");
            //    ListItem Lst3 = new ListItem("Partnership Firm", "2");
            //    ListItem Lst4 = new ListItem("Company", "3");
            //    ListItem Lst5 = new ListItem("Association of Person (AOP)", "4");
            //    ListItem Lst6 = new ListItem("Body of Individuals (BOI)", "5");
            //    ListItem Lst7 = new ListItem("Co-Operative Society", "6");
            //    ListItem Lst8 = new ListItem("Co-Operative Bank", "7");
            //    ListItem Lst9 = new ListItem("Local Authority", "8");

            //    ddlAssesseeList.Items.Add(Lst1);
            //    ddlAssesseeList.Items.Add(Lst2);
            //    //ddlAssesseeList.Items.Add(Lst3);
            //    //ddlAssesseeList.Items.Add(Lst4);
            //    //ddlAssesseeList.Items.Add(Lst5);
            //    //ddlAssesseeList.Items.Add(Lst6);
            //    //ddlAssesseeList.Items.Add(Lst7);
            //    //ddlAssesseeList.Items.Add(Lst8);
            //    //ddlAssesseeList.Items.Add(Lst9);
            //    if (Session["UploadForm16Details"] != null && Session["PAN"] != null)
            //    {
            //        txtPAN.Text = Session["PAN"].ToString();
            //        txtPAN.Enabled = false;
            //    }
            //    //divPAN.Visible = false;
            //}
            //else  
            //For SERVICE TAX
            //{
            //    divPAN.Visible = true;
            //    divST.Visible = true;
            //    ListItem Lst1 = new ListItem("Proprietorship/Individual", "0");
            //    ListItem Lst2 = new ListItem("Limited Liability Partnership", "1");
            //    ListItem Lst3 = new ListItem("Registered Public Limited Company", "2");
            //    ListItem Lst4 = new ListItem("Registered Private Limited Company", "3");
            //    ListItem Lst5 = new ListItem("Registered Trust", "4");
            //    ListItem Lst6 = new ListItem("Society/Co-operative Society", "5");
            //    ListItem Lst7 = new ListItem("A Firm", "6");
            //    ListItem Lst8 = new ListItem("Hindu Undivided Family", "7");
            //    ListItem Lst9 = new ListItem("Government", "8");
            //    ListItem Lst10 = new ListItem("An Association of Persons or Body of Individuals, whether incorporated or not", "9");
            //    ListItem Lst11 = new ListItem("A Local Authority", "10");
            //    ListItem Lst12 = new ListItem("Every Artificial Juridical Person, not falling within any of the preceding sub-clauses", "11");

            //    ddlAssesseeList.Items.Add(Lst1);
            //    ddlAssesseeList.Items.Add(Lst2);
            //    ddlAssesseeList.Items.Add(Lst3);
            //    ddlAssesseeList.Items.Add(Lst4);
            //    ddlAssesseeList.Items.Add(Lst5);
            //    ddlAssesseeList.Items.Add(Lst6);
            //    ddlAssesseeList.Items.Add(Lst7);
            //    ddlAssesseeList.Items.Add(Lst8);
            //    ddlAssesseeList.Items.Add(Lst9);

            //    ddlAssesseeList.Items.Add(Lst10);
            //    ddlAssesseeList.Items.Add(Lst11);
            //    ddlAssesseeList.Items.Add(Lst12);
            //}
        }
    }

    protected void ddITR_SelectedIndexChanged(object sender, EventArgs e)
    {
        bllStatus objbllStatus = new bllStatus();
        List<denStatus> LstStatus = objbllStatus.Select(ddITR.SelectedValue);
        ddlAssesseeList.DataSource = LstStatus;
        ddlAssesseeList.DataTextField = "Status";
        ddlAssesseeList.DataValueField = "id";
        ddlAssesseeList.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        restoreXML();
    }
    private void restoreXML()
    {
        try
        {
            if (fup1.FileName != "")
            {
                fup1.PostedFile.SaveAs(Server.MapPath("../xmlUpload/") + fup1.FileName);
            }
            string PAN = "";
            bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            //Session["AY"] = txtAY.Text;
            string ITR = "";
            string strXML = File.ReadAllText((Server.MapPath("../xmlUpload/") + fup1.FileName).ToString());
            string[] arrXML = System.Text.RegularExpressions.Regex.Split(strXML, @"\?>");
            string xml="";
            if (arrXML.Length > 1)
                xml = arrXML[1];// strXML;

            if (strXML.Contains("Form_ITR1"))
            {
                Session["ITR"] = "1";
                ITR = "1";
            }
            else if (strXML.Contains("Form_ITR4S"))
            {
                Session["ITR"] = "8";
                ITR = "8";
            }
            //else if (strXML.Contains("Form_ITR4"))
            //{
            //    Session["ITR"] = "4";
            //    ITR = "4";
            //}
            //else if (strXML.Contains("Form_ITR2"))
            //{
            //    Session["ITR"] = "2";
            //    ITR = "2";
            //}

            if (ITR == "1" || ITR == "8")
            {
                string[] arrAY = System.Text.RegularExpressions.Regex.Split(strXML, "</ITRForm:AssessmentYear>");
                strXML = arrAY[0].Substring(arrAY[0].Length - 4);
                Session["AY"] = strXML + "-" + (Convert.ToInt32(strXML) + 1).ToString();

                //objbllStoreTrans.resXML(xml, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + fup1.FileName).ToString(), ITR, (Session["NameID"] == null) ? "0" : Session["NameID"].ToString(), out PAN, 1);
                //objbllStoreTrans.resXML(xml, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + fup1.FileName).ToString(), ITR, "0", out PAN, 1);
                
                objbllStoreTrans.resXML_withMsg(xml, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + fup1.FileName).ToString(), ITR, "0", out PAN, 1, out errMsg);
                if (PAN != "")
                {
                    bllAssessee objbllAssessee = new bllAssessee();
                    denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                    objAssesseeIndividual = objbllAssessee.GetDataIndividual(PAN);
                    Session["NameID"] = objAssesseeIndividual.NameID;
                    Session["restore"] = "true";
                    Session["PAN"] = PAN;

                    common objcommon = new common();
                    balXML objbalXML = new balXML();
                    string ITRXML_ID = "";
                    ITRXML_ID = objbalXML.getXML_Last_ID(objAssesseeIndividual.NameID);
                    objcommon.SaveJob(Session["NameID"].ToString(), Session["userEmail"].ToString(), ITRXML_ID);

                    objcommon.AddUser(Session["NameID"].ToString());
                    denMain objMainDEN = new denMain();
                    bllMain objMainBLL = new bllMain();

                    objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), 0, 0, StateID);
                    string[] arrDate = System.Text.RegularExpressions.Regex.Split(objMainDEN.DueDate, "/");

                    DateTime dtime = new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]));
                    // DateTime dtime = Convert.ToDateTime("21/02/2009", new CultureInfo("en-US", true));
                    //dtime.Month+"/"+dtime.Day+"/"+dtime.Year
                    //Session["ITR"] = "1";
                    Session["ay"] = Session["AY"];
                    Session["duedate"] = objMainDEN.DueDate;
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    lblmsg.Text = "This Assessee is already added by you";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + lblmsg.Text + "');", true);
                }
            }
            else
            {
                lblmsg.Text = "You can only import ITR-1 and ITR-4S";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + lblmsg.Text + "');", true);
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "PAN already registered by another user";// ex.Message.ToString();
            if (errMsg != "")
                lblmsg.Text = errMsg;
              //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup(Assessee Already Registered with Aother User;)", true); endrequesr
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + lblmsg.Text + "');", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('"+ex.Message.ToString()+"');", true);
            
        }
    }

    
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        Session["Master_VType"] = "true";
        Session["AY"] = ddAY.SelectedValue;
        Session["ITR"] = ddITR.SelectedValue;
        string strtarget;
        bool IsValidPAN = false;
        //if (Page.IsValid)
        //{
        Session["PAN"] = txtPAN.Text.ToUpper();
        Session["AssesseeType"] = ddlAssesseeList.SelectedItem.Text;//.SelectedValue;        
        //Session["STCNo"] = txtSTCNo.Text;
        strtarget = ddlAssesseeList.SelectedValue;
        ltMsg.Visible = false;
        //Commented by Mudit on 16/06/2015 for the testing of Generic Procedures
        //if (strtarget == "0")
        //{
        //    if (txtPAN.Text.Substring(3, 1) == "P" || txtPAN.Text.Substring(3, 1) == "p")
        //        IsValidPAN = true;
        //}
        //else if (strtarget == "1")
        //{
        //    if (txtPAN.Text.Substring(3, 1) == "H" || txtPAN.Text.Substring(3, 1) == "h")
        //        IsValidPAN = true;
        //}
        //else if (strtarget == "2")
        //{
        //    if (txtPAN.Text.Substring(3, 1) == "F" || txtPAN.Text.Substring(3, 1) == "f")
        //        IsValidPAN = true;
        //}
        //else if (strtarget == "3")
        //{
        //    if (txtPAN.Text.Substring(3, 1) == "C" || txtPAN.Text.Substring(3, 1) == "c")
        //        IsValidPAN = true;
        //}
        //else if (strtarget == "4")
        //{
        //    if (txtPAN.Text.Substring(3, 1) == "A" || txtPAN.Text.Substring(3, 1) == "a")
        //        IsValidPAN = true;
        //}
        //else if (strtarget == "5")
        //{
        //    if (txtPAN.Text.Substring(3, 1) == "B" || txtPAN.Text.Substring(3, 1) == "b")
        //        IsValidPAN = true;
        //}
        //else if (strtarget == "6")
        //{
        //    if (txtPAN.Text.Substring(3, 1) == "B" || txtPAN.Text.Substring(3, 1) == "b" || txtPAN.Text.Substring(3, 1) == "A" || txtPAN.Text.Substring(3, 1) == "a")
        //        IsValidPAN = true;
        //}
        //else if (strtarget == "7")
        //{
        //    if (txtPAN.Text.Substring(3, 1) == "B" || txtPAN.Text.Substring(3, 1) == "b" || txtPAN.Text.Substring(3, 1) == "A" || txtPAN.Text.Substring(3, 1) == "a")
        //        IsValidPAN = true;
        //}
        //else if (strtarget == "8")
        //{
        //    if (txtPAN.Text.Substring(3, 1) == "L" || txtPAN.Text.Substring(3, 1) == "l")
        //        IsValidPAN = true;
        //}


        //Settion ObjectValues to send information to Doctrans Table
        //if (IsValidPAN)
        //{

        string msg_IIF = "";
            // following fields have been taken to the Assessee Select Page - Ankush on 21-11-2014:
            if (ltMsg.Visible == false)
            {
                Int32 IsExists;
                IsExists = 0;   // condition here..

                try
                {
                    bllDocTrans objDocTransBLL;
                    denDocTrans objdenDocTrans = new denDocTrans();
                    objDocTransBLL = new bllDocTrans();
                    IsExists = objDocTransBLL.IsExists(txtPAN.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //IsExists = InsertMiscInfo(objDocTransDEN);
                if (IsExists >= 1)
                {
                    ltMsg.Visible = true;
                    ltMsg.Text = "<center><span style='color:red;'> This PAN Number is already registered with us!!</span></center>";
                }
                else
                {
                    //Redirecting Pages
                    bllStatus objbllStatus = new bllStatus();
                    string Vtype = objbllStatus.SelectVType(ddlAssesseeList.SelectedValue, ddITR.SelectedValue);
                    
                    if (Session["Project"].ToString() == "stax")
                    {
                        Session["RP"] = "April-September";
                        Session["NameID"] = Session["User_ID"].ToString();
                        //Added By Mudit on 31/08/2015 for ServiceTax it will work when user will click on Button Enter106
                        Button btn = new Button();
                        btn = (Button)sender;
                        if (btn.ID == "btnEnterSal")
                            Response.Redirect("Salary.aspx?Vtype=" + 10005);
                        else
                        {
                            //Session["AType"] = "individual";
                            Response.Redirect("STaxMaster.aspx");
                        }
                       
                    }
                    else
                    {
                        Session["NameID"] = Session["User_ID"].ToString();
                        //Due Date:
                        if (ddAY.SelectedItem.Text == "2014-2015")
                            Session["duedate"] = "31/07/2014";
                        else if (ddAY.SelectedItem.Text == "2015-2016")
                            Session["duedate"] = "31/08/2015";
                        else if (ddAY.SelectedItem.Text == "2016-2017")
                            Session["duedate"] = "31/07/2016";


                        denStoreTrans objdenStoreTrans = new denStoreTrans();
                        bllStoreTrans objbllStoreTrans = new bllStoreTrans();

                        objdenStoreTrans.NameID = Session["NameID"].ToString();
                        objdenStoreTrans.Vtype = 106;
                        objdenStoreTrans.MainID = Convert.ToInt32(Session["NameID"]);
                        objdenStoreTrans.ConstID = 5;
                        objdenStoreTrans.SubConstID = 0;
                        objdenStoreTrans.ComboItemNo = 0;
                        objdenStoreTrans.GIndex = 105;
                        objdenStoreTrans.Col3 = txtPAN.Text;
                        objdenStoreTrans.AY = ddAY.SelectedValue;
                        objdenStoreTrans.GRowNo = 3;
                        objdenStoreTrans.IsEnterFDet = 0;
                        objdenStoreTrans.RecdAmount = 0;
                        objdenStoreTrans.DueDate = Session["duedate"].ToString();

                        int i = objbllStoreTrans.CheckMainGrid(objdenStoreTrans);
                        if (i <= 0)
                            objbllStoreTrans.InsertDataMainGrid(objdenStoreTrans, out msg_IIF);
                        else
                            objbllStoreTrans.UpdateMainGrid(objdenStoreTrans, out msg_IIF);

                        denStoreTrans objdenStoreTrans2 = new denStoreTrans();
                        objdenStoreTrans2.NameID = Session["NameID"].ToString();
                        objdenStoreTrans2.Vtype = 106;
                        objdenStoreTrans2.MainID = Convert.ToInt32(Session["NameID"]);
                        objdenStoreTrans2.ConstID = 26;
                        objdenStoreTrans2.SubConstID = 0;
                        objdenStoreTrans2.ComboItemNo = 0;
                        objdenStoreTrans2.GIndex = 105;
                        objdenStoreTrans2.Col3 = ddlAssesseeList.SelectedValue;
                        objdenStoreTrans2.AY = ddAY.SelectedValue;
                        objdenStoreTrans2.GRowNo = 8;
                        objdenStoreTrans2.IsEnterFDet = 0;
                        objdenStoreTrans2.RecdAmount = 0;
                        objdenStoreTrans2.DueDate = Session["duedate"].ToString();

                        i = objbllStoreTrans.CheckMainGrid(objdenStoreTrans2);
                        if (i <= 0)
                            objbllStoreTrans.InsertDataMainGrid(objdenStoreTrans2, out msg_IIF);
                        else
                            objbllStoreTrans.UpdateMainGrid(objdenStoreTrans2, out msg_IIF);


                        denStoreTrans objdenStoreTrans3 = new denStoreTrans();
                        objdenStoreTrans3.NameID = Session["NameID"].ToString();
                        objdenStoreTrans3.Vtype = 106;
                        objdenStoreTrans3.MainID = Convert.ToInt32(Session["NameID"]);
                        objdenStoreTrans3.ConstID = 7;
                        objdenStoreTrans3.SubConstID = 0;
                        objdenStoreTrans3.ComboItemNo = 0;
                        objdenStoreTrans3.GIndex = 105;
                        if (ddlAssesseeList.SelectedItem.Text == "Hindu Undivided Family")
                            objdenStoreTrans3.Col3 = "3";
                        else
                            objdenStoreTrans3.Col3 = "1";
                        objdenStoreTrans3.AY = ddAY.SelectedValue;
                        objdenStoreTrans3.GRowNo = 7;
                        objdenStoreTrans3.IsEnterFDet = 0;
                        objdenStoreTrans3.RecdAmount = 0;
                        objdenStoreTrans3.DueDate = Session["duedate"].ToString();

                        i = objbllStoreTrans.CheckMainGrid(objdenStoreTrans3);
                        if (i <= 0)
                            objbllStoreTrans.InsertDataMainGrid(objdenStoreTrans3, out msg_IIF);
                        else
                            objbllStoreTrans.UpdateMainGrid(objdenStoreTrans3, out msg_IIF);

                        //Saving Job conditionally for CA Assisted User (with Account Type = E)
                        if (Session["Account_Type"] != null)
                        {
                            if (Session["Account_Type"].ToString() == "E")
                            {
                                common objcommon = new common();
                                objcommon.SaveJob(Session["NameId"].ToString(), Session["userEmail"].ToString(), "0");
                            }
                        }

                        if (strtarget == "0")
                        {
                            //Added by Mudit For Generic Procedure on 16/06/2015

                            //string Vtype = Session["Vtype"].ToString();
                            
                            Button btn = new Button();
                            btn = (Button)sender;
                            if (btn.ID == "btnEnterSal")
                            {
                                //if (ddAY.SelectedValue == "2015-2016")
                                Session["Master_VType"] = "true";
                                Session["Listing_Page"] = "true";
                                Session["IncomeTax_VType"] = Vtype;
                                //if (Vtype == "106")
                                    Response.Redirect("Profile");
                                    //Response.Redirect("Salary.aspx?Vtype=" + Vtype);
                            }
                            else
                            {
                                Session["AType"] = "individual";
                                Response.Redirect("individual.aspx");
                            }
                        }
                        else if (strtarget == "1")
                        {
                            //Added by Mudit For Generic Procedure on 16/06/2015
                            //string Vtype = Session["Vtype"].ToString();
                           
                            //Added by Mudit On 31/08/2015 for HUF it will work when user will click on Button Enter106
                             Button btn = new Button();
                            btn = (Button)sender;
                            if (btn.ID == "btnEnterSal")
                            {
                             //   Response.Redirect("Salary.aspx?Vtype=" + Vtype);
                                Session["IncomeTax_VType"] = Vtype;
                                if (Vtype == "106")
                                    Response.Redirect("Profile");
                            }
                            else
                            {
                                //Response.Redirect("Salary.aspx?Vtype=" + Vtype);
                                Response.Redirect("HUF.aspx");
                                Session["AType"] = "HUF";
                            }
                        }
                        else if (strtarget == "2")
                        {
                            Response.Redirect("partnership.aspx");
                            Session["AType"] = "partnership";
                        }
                        else if (strtarget == "3")
                        {
                            Response.Redirect("company.aspx");
                            Session["AType"] = "company";
                        }
                        else if (strtarget == "4")
                        {
                            Response.Redirect("AOP.aspx");
                            Session["AType"] = "AOP";
                        }
                        else if (strtarget == "5")
                        {
                            Response.Redirect("cooperative.aspx");
                            Session["AType"] = "cooperative";
                        }
                    }
                }
            }
        //}
        //else
        //{
        //    ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'> alert('Invalid PAN for the selected Assessee Type!!');</script>");
        //}
        //}
        //else
        //    ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'> alert('Page not validated!!');</script>");
    }

    protected Int32 InsertMiscInfo(denDocTrans objDocTransDEN)
    {
        Int32 IsExists;
        try
        {
            bllDocTrans objDocTransBLL;
            objDocTransBLL = new bllDocTrans();
            objDocTransBLL.InsertMiscDetails(objDocTransDEN, out IsExists);
            return IsExists;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void fetchTDSData()
    {
        // try
        // {
            // //Providing Login Details
            // GetTDSReference.LoginInfoType obj_LoginInfoType = new LoginInfoType();
            // obj_LoginInfoType.userName = "ERIA100133";
            // obj_LoginInfoType.password = "gill123456@";


            // //Providing Client Details

            // //DateTime Date_of_Birth = DateTime.ParseExact(TxtDOB.Text.TrimEnd().TrimStart(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            // DateTime Date_of_Birth;
            // string[] formats = { "yyyy-MM-dd" };
            // //Session["ay"] = "2013-14";
            // DateTime.TryParseExact(Session["DateofBirth"].ToString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out Date_of_Birth);

            // GetTDSReference.ClientInfoType obj_ClientInfoType = new ClientInfoType();
            // obj_ClientInfoType.pan = Session["PAN"].ToString();
            // obj_ClientInfoType.dob = Date_of_Birth;
            // obj_ClientInfoType.assessmentYear = Session["ay"].ToString();


            // //Fetching TDS Details via LoginInfo and ClientInfo
            // GetTDSReference.getTDSDetails obj_getTDSDetails = new getTDSDetails();
            // obj_getTDSDetails.ClientInfo = obj_ClientInfoType;
            // obj_getTDSDetails.LoginInfo = obj_LoginInfoType;


            // //Creating a TDS Request with GetTDSDetails Class Object
            // GetTDSReference.GetTDSRequest obj_GetTDSRequest = new GetTDSRequest(obj_getTDSDetails);
            // obj_GetTDSRequest.getTDSDetails = obj_getTDSDetails;

            // //Getting TAN and TAN Name Details
            // GetTDSReference.EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDetl = new EmployerOrDeductorOrCollectDetl();

            // //Passing TDS Details as parameter in TDSPortClient
            // GetTDSReference.GetTDSPortClient obj_GetTDSPortClient = new GetTDSPortClient("GetTDSPortSoap11", "https://incometaxindiaefiling.gov.in/e-FilingWS/ditws");
            // obj_GetTDSPortClient.Open();

            // GetTDSReference.GetTDSResponseType obj_GetTDSResponseType = new GetTDSResponseType();
            // obj_GetTDSResponseType = obj_GetTDSPortClient.getTDSDetails(obj_getTDSDetails);

            // //Getting The TDS Response
            // GetTDSReference.GetTDSResponse obj_GetTDSResponse = new GetTDSResponse();
            // obj_GetTDSResponse.GetTDSResponse1 = obj_GetTDSResponseType;

            // bllFloating objFloatingBLO = new bllFloating();

            // //-----------------------------------------------------------------------------
            // //Getting TDS on Salary Data.....
            // //-----------------------------------------------------------------------------
            // if (obj_GetTDSResponse.GetTDSResponse1.TDSonSalaries != null)
            // {

                // int Length_TDSOnSal_Array = obj_GetTDSResponseType.TDSonSalaries.Length;
                // GetTDSReference.TDSonSalary[] obj_TDSonSalary = obj_GetTDSResponseType.TDSonSalaries;



                // DataTable dt_arr = new DataTable();
                // dt_arr.Columns.Add("TAN", typeof(String));
                // dt_arr.Columns.Add("TAN Name", typeof(String));
                // dt_arr.Columns.Add("Income Chargeable on Salary", typeof(String));
                // dt_arr.Columns.Add("Total TDS Salary", typeof(String));







                // for (int i = 0; i < obj_GetTDSResponseType.TDSonSalaries.Length; i++)
                // {
                    // var x = obj_TDSonSalary[i].IncChrgSal.ToString();
                    // var y = obj_TDSonSalary[i].TotalTDSSal.ToString();
                    // obj_EmployerOrDeductorOrCollectDetl = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl;

                    // DataRow Dr = dt_arr.NewRow();
                    // Dr["TAN"] = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // Dr["TAN Name"] = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // Dr["Income Chargeable on Salary"] = x;
                    // Dr["Total TDS Salary"] = y;
                    // dt_arr.Rows.Add(Dr);


                    // denFloating objFloatingDEO = new denFloating();
                    // objFloatingDEO.NameID = Convert.ToString(Session["NameID"]);
                    // objFloatingDEO.HeaderID = "102";
                    // objFloatingDEO.Vtype = "49";
                    // objFloatingDEO.ConstID = "802";
                    // objFloatingDEO.Gorder = Convert.ToString(ViewState["Gorder"]);
                    // objFloatingDEO.Number = 1;

                    // objFloatingDEO.Col4 = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // objFloatingDEO.Col7 = x;
                    // objFloatingDEO.Col9 = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // objFloatingDEO.Col13 = y;

                    // objFloatingBLO.InsertOrUpdate(objFloatingDEO);

                    // // To submit main data for the same:

                    // denStoreTrans objStoreTransDEN, objstoreTransDEN2;
                    // bllStoreTrans objStoreTransBLL;

                    // objStoreTransDEN = new denStoreTrans();
                    // objstoreTransDEN2 = new denStoreTrans();
                    // objStoreTransBLL = new bllStoreTrans();

                    // objStoreTransDEN.ConstID = 802;
                    // objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
                    // objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
                    // objStoreTransDEN.Vtype = 49;
                    // objStoreTransDEN.GIndex = 0;//Convert.ToInt32(ViewState["GridIndex"]);
                    // objStoreTransDEN.ComboItemNo = 0;// Convert.ToInt32(ViewState["ComboItem"]);
                    // objStoreTransDEN.MainID = 0;// Convert.ToInt32(ViewState["MainID"]);
                    // objStoreTransDEN.GRowNo = 0;// Convert.ToInt32(ViewState["GRowNo"]);
                    // objStoreTransDEN.IsEnterFDet = 1;

                    // //if (Session["float"].ToString() == "true")
                    // //{
                    // objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "0", 0);
                    // //}

                // }
                // //TDS on Salary Retrieved in Grid View


            // }

            // //------------------------------------------------------------------------------------
            // //Getting TDS On Other Than Salary Data......
            // //--------------------------------------------------------------------------------
            // if (obj_GetTDSResponse.GetTDSResponse1.TDSonOthThanSals != null)
            // {

                // int Length_TDSOnOthSal_Array = obj_GetTDSResponseType.TDSonOthThanSals.Length;
                // GetTDSReference.TDSonOthThanSal[] obj_TDSonOthThanSal = new TDSonOthThanSal[Length_TDSOnOthSal_Array];
                // obj_TDSonOthThanSal = obj_GetTDSResponseType.TDSonOthThanSals;

                // DataTable dt_arr = new DataTable();
                // dt_arr.Columns.Add("TAN", typeof(String));
                // dt_arr.Columns.Add("TAN Name", typeof(String));
                // dt_arr.Columns.Add("Total TDS On Amt Paid", typeof(String));
                // dt_arr.Columns.Add("Claim Out Of Tot. TDS On Amt Paid", typeof(String));
                // for (int i = 0; i < obj_GetTDSResponseType.TDSonOthThanSals.Length; i++)
                // {
                    // var x = obj_TDSonOthThanSal[i].TotTDSOnAmtPaid.ToString();
                    // var y = obj_TDSonOthThanSal[i].ClaimOutOfTotTDSOnAmtPaid.ToString();
                    // EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDet1_2 = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl;





                    // DataRow Dr = dt_arr.NewRow();
                    // Dr["TAN"] = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // Dr["TAN Name"] = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // Dr["Total TDS On Amt Paid"] = x;
                    // Dr["Claim Out Of Tot. TDS On Amt Paid"] = y;
                    // dt_arr.Rows.Add(Dr);


                    // denFloating objFloatingDEO = new denFloating();
                    // objFloatingDEO.NameID = Convert.ToString(Session["NameID"]);
                    // objFloatingDEO.HeaderID = "102";
                    // objFloatingDEO.Vtype = "49";
                    // objFloatingDEO.ConstID = "788";
                    // objFloatingDEO.Gorder = Convert.ToString(ViewState["Gorder"]);
                    // objFloatingDEO.Number = 1;

                    // objFloatingDEO.Col4 = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // objFloatingDEO.Col7 = x;
                    // objFloatingDEO.Col9 = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // objFloatingDEO.Col13 = y;

                    // objFloatingBLO.InsertOrUpdate(objFloatingDEO);


                    // // To submit main data for the same:

                    // denStoreTrans objStoreTransDEN, objstoreTransDEN2;
                    // bllStoreTrans objStoreTransBLL;

                    // objStoreTransDEN = new denStoreTrans();
                    // objstoreTransDEN2 = new denStoreTrans();
                    // objStoreTransBLL = new bllStoreTrans();

                    // objStoreTransDEN.ConstID = 788;
                    // objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
                    // objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
                    // objStoreTransDEN.Vtype = 49;
                    // objStoreTransDEN.GIndex = 0;//Convert.ToInt32(ViewState["GridIndex"]);
                    // objStoreTransDEN.ComboItemNo = 0;// Convert.ToInt32(ViewState["ComboItem"]);
                    // objStoreTransDEN.MainID = 0;// Convert.ToInt32(ViewState["MainID"]);
                    // objStoreTransDEN.GRowNo = 0;// Convert.ToInt32(ViewState["GRowNo"]);
                    // objStoreTransDEN.IsEnterFDet = 1;

                    // //if (Session["float"].ToString() == "true")
                    // //{
                    // objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "0", 0);
                // }
                // //TDS on Other Than Salary Retrieved in Grid View


            // }

            // //--------------------------------------------------------------------------------------
            // //Getting TCS Details Array
            // //---------------------------------------------------------------------------------------
            // if (obj_GetTDSResponse.GetTDSResponse1.ScheduleTCS != null)
            // {

                // int length_TCS_Array = obj_GetTDSResponse.GetTDSResponse1.ScheduleTCS.Length;
                // GetTDSReference.TCS[] obj_TCS = new TCS[length_TCS_Array];
                // obj_TCS = obj_GetTDSResponseType.ScheduleTCS;

                // DataTable dt = new DataTable();
                // dt.Columns.Add("TAN", typeof(String));
                // dt.Columns.Add("TAN Name", typeof(String));
                // dt.Columns.Add("Total TCS", typeof(String));
                // dt.Columns.Add("Amt TC Claimed This Year", typeof(String));

                // for (int i = 0; i < obj_GetTDSResponseType.ScheduleTCS.Length; i++)
                // {

                    // var x = obj_TCS[i].AmtTCSClaimedThisYear.ToString();
                    // var y = obj_TCS[i].TotalTCS.ToString();
                    // EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDet1_3 = obj_TCS[i].EmployerOrDeductorOrCollectDetl;

                    // DataRow dr = dt.NewRow();
                    // dr["TAN"] = obj_TCS[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // dr["TAN Name"] = obj_TCS[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // dr["Total TCS"] = x;
                    // dr["Amt TC Claimed This Yeard"] = y;
                // }

                // //TCS Data Retrieved in GridView

            // }
            // else
            // {
                // denStoreTrans objStoreTransDEN, objstoreTransDEN2;
                // bllStoreTrans objStoreTransBLL;

                // objStoreTransDEN = new denStoreTrans();
                // objstoreTransDEN2 = new denStoreTrans();
                // objStoreTransBLL = new bllStoreTrans();

                // objStoreTransDEN.ConstID = 801;
                // objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
                // objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
                // objStoreTransDEN.Vtype = 49;
                // objStoreTransDEN.GIndex = 0;//Convert.ToInt32(ViewState["GridIndex"]);
                // objStoreTransDEN.ComboItemNo = 0;// Convert.ToInt32(ViewState["ComboItem"]);
                // objStoreTransDEN.MainID = 0;// Convert.ToInt32(ViewState["MainID"]);
                // objStoreTransDEN.GRowNo = 0;// Convert.ToInt32(ViewState["GRowNo"]);
                // objStoreTransDEN.IsEnterFDet = 1;

                // objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "0", 0);
            // }

            // //------------------------------------------------------------------------------------------
            // //Getting Tax Payments Arrays.
            // //-------------------------------------------------------------------------------------------
            // if (obj_GetTDSResponse.GetTDSResponse1.TaxPayments != null)
            // {

                // int Length_Taxpayments_Array = obj_GetTDSResponseType.TaxPayments.Length;
                // GetTDSReference.TaxPayment[] obj_TaxPayment = new TaxPayment[Length_Taxpayments_Array];
                // obj_TaxPayment = obj_GetTDSResponseType.TaxPayments;


                // //Tax Payment Data Retrieved in Grid View
                // //GrdVw_TaxPayments.DataSource = ConvertArrayToDataTable(obj_TaxPayment);
                // //GrdVw_TaxPayments.DataBind();
                // //GrdVw_TaxPayments.HeaderRow.Cells[0].Text = "BSR Code";
                // //GrdVw_TaxPayments.HeaderRow.Cells[1].Text = "Dt. Deposited";
                // //GrdVw_TaxPayments.HeaderRow.Cells[2].Text = "Sr. No. of Challan";
                // //GrdVw_TaxPayments.HeaderRow.Cells[3].Text = "Amount";
            // }
        // }
        // catch (Exception ex)
        // {
            // //ltMsg.Visible = true;
            // //lblMessage.Text = ex.Message;
            // throw ex;
        // }
    }

    protected void ddlAssesseeList_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlAssesseeList.SelectedIndex == 1)
            Session["Vtype"] = 106;
        if (ddlAssesseeList.SelectedIndex == 2)
            Session["Vtype"] = 10004;
        Session["Status"] = ddlAssesseeList.SelectedIndex;
    }
    
}
