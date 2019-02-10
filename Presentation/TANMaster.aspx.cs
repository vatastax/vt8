using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using VatasInfosysLib;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using BALVatasETDS.TANMaster;
using BALVatasETDS.CompressAndDecompress_Page;
using BALVatasETDS.BatchHeader_Correction;
using System.IO;
using BALVatasETDS.FileHeader;
using BALVatasETDS;
using BALVatasETDS.AIRMaster;
using BALVatasETDS.Interface_By_Role;
using DALVatasETDS;
using AjaxControlToolkit;
using BALVatasETDS.File_Header_Correction;
using BALVatasETDS.Accounts;
using BALVatasETDS.System_Config;
using BALVatasETDS.Vouchers;
using controlgrid;
using BALVatasETDS.Path_Management;
using Taxation.BusinessLogic;


public partial class _Default : System.Web.UI.Page
{
    #region Declaration

    TANMaster objTANMaster;
    string strConnName;
    string strConnectionString;
    string strConnectionString_Admin, strConnName_Admin;
    string strConnectionString_VS, strConnName_VS;
    public string strTANNumber;
    public static string FlagForExistence = string.Empty;
    public static string FlagDelete = string.Empty;
    public static string FlagSave = string.Empty;
    public static string FlagRefresh = string.Empty;
    public static string FlagSuccess = string.Empty;
    public static string FlagC1 = string.Empty;
    string Regular_Correction = string.Empty;
    Bltbl_TANMaster objBltbl_TANMaster;
    tbl_TANMaster objtbl_TANMaster;
    //Create Object of the Batch Header Correction
    Bltbl_BatchHeader_Correction objBltbl_BatchHeader_Correction;
    tbl_BatchHeader_Correction objtbl_BatchHeader_Correction;

    //Create Object of the FileHeader Correction
    Bltbl_FileHeader objBltbl_FileHeader;
    tbl_FileHeader objtbl_FileHeader;

    //Create Object of the AIR Module
    Bltbl_AIRMaster objBltbl_AIRMaster;
    tbl_AIRMaster objtbl_AIRMaster;
    //Create Object of the Interface_By_Role Class
    Bltbl_Interface_By_Role objBltbl_Interface_By_Role;
    tbl_Interface_By_Role objtbl_Interface_By_Role;
    DBtbl_Module objDBtbl_Module;

    //Create Object of the File_Header_Correction Module
    Bltbl_FileHeader_Correction objBltbl_FileHeader_Correction;
    tbl_FileHeader_Correction objtbl_FileHeader_Correction;

    //Create Object of the Accounts Module
    BLtbl_Accounts11 objBLtbl_Accounts11;
    tbl_Accounts1 objtbl_Accounts1;

    //Create object of the System.Config
    Bltbl_System_Config objBltbl_System_Config;
    tbl_System_Config objtbl_System_Config;

    //Create object of the Voucher
    Bltbl_Vouchers objBltbl_Vouchers;
    tbl_Vouchers objtbl_Vouchers;

    Bltbl_PathManagement objBltbl_PathManagement;
    tbl_PathManagement objtbl_PathManagement;

    DataTable dt;
    #endregion

    #region PageLoad Event

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        // Connection String of TDS
        strConnName = Application["DBEngine7"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;

        //ConnectionString Of Admin
        strConnName_Admin = Application["DBEngine6"].ToString();
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[strConnName_Admin].ConnectionString;

        //ConnectionString of VS
        //strConnName_VS= Application["DBEngine5"].ToString(); 
        //  strConnectionString_VS=ConfigurationManager.ConnectionStrings[strConnName_VS].ConnectionString;

        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;
        DynamicControl.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;
        //Session["CurrentUrl"] = HttpContext.Current.Request.RawUrl;
        objBltbl_TANMaster = new Bltbl_TANMaster(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_TANMaster = new tbl_TANMaster();

        //Intialize Object For Batch_hHeader_Correction
        objBltbl_BatchHeader_Correction = new Bltbl_BatchHeader_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_BatchHeader_Correction = new tbl_BatchHeader_Correction();

        //Intialize Object For File Header
        objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_FileHeader = new tbl_FileHeader();

        //Intialize the Object For File Header Correction
        objBltbl_FileHeader_Correction = new Bltbl_FileHeader_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_FileHeader_Correction = new tbl_FileHeader_Correction();
        //Intialize the Object For AIR
        objBltbl_AIRMaster = new Bltbl_AIRMaster(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_AIRMaster = new tbl_AIRMaster();

        //Intialize the Object For InterFace_By_Role
        string Leftpath_Admin = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost_Admin = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "ADMIN," + ApplicationHost_Admin + "," + Leftpath_Admin;
        DynamicControl.Project_Name = "ADMIN," + ApplicationHost_Admin + "," + Leftpath_Admin;
        objBltbl_Interface_By_Role = new Bltbl_Interface_By_Role(strConnectionString_Admin, strConnName_Admin, strConnectionString_Admin);
        objtbl_Interface_By_Role = new tbl_Interface_By_Role();



        string Leftpath_VS = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost_VS = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "VS," + ApplicationHost_VS + "," + Leftpath_VS;
        DynamicControl.Project_Name = "VS," + ApplicationHost_VS + "," + Leftpath_VS;

        //Intialize the Object For Accounts
        objBLtbl_Accounts11 = new BLtbl_Accounts11(strConnectionString_VS, strConnName_VS, strConnectionString_Admin);
        objtbl_Accounts1 = new tbl_Accounts1();

        //Intialize the object of System.Config
        objBltbl_System_Config = new Bltbl_System_Config(strConnectionString_VS, strConnName_VS, strConnectionString_Admin);
        objtbl_System_Config = new tbl_System_Config();




        Multiview2.SetActiveView(vw_tab3);

        int Role_ID = 0;
        if (Request.QueryString["RoleID"] != null)
        {
            Role_ID = Convert.ToInt32(Request.QueryString["RoleID"]);
            Session["Role_ID"] = Role_ID;
        }
        int User_ID = 0;
        if (Request.QueryString["UserID"] != null)
        {
            User_ID = Convert.ToInt32(Request.QueryString["UserID"]);
        }
        string menu = string.Empty;
        if (Request.QueryString["menu"] != null)
        {
            menu = Request.QueryString["menu"].ToString();
        }
        if (menu == "TANMaster")
        {
            maindiv.Visible = true;
        }
        int Popup_ControlID = 1;
        auto_TAN.ContextKey = getQuery(367, 4, "TAN", auto_TAN) + "!" + Popup_ControlID + "!" + txt_TANNumber.ID;
        auto_AName.ContextKey = getQuery(367, 4, "AName", auto_AName) + "!" + Popup_ControlID + "!" + txt_AssesseName.ID;

        if (!Page.IsPostBack)
        {
            Load_Interface_By_Role(Role_ID);
            req_MinistryName.Visible = false;
            GetDefaultReturnType();
            FillCombo();
            FlagForExistence = "";
            FlagDelete = "";
            FlagSave = "";
            FlagRefresh = "";
            FlagSuccess = "";

            DBtbl_Module.User_ID = User_ID;

            if (Request.QueryString["type"] != null)
            {
                string type = Request.QueryString["type"].ToString();
                Regular_Correction = type;
                ViewState["Regular_Correction"] = Regular_Correction;

                //Get the Other Parameters Coming from QueryString

                if (type == "Correction")
                {
                    string TAN = Request.QueryString["TAN"].ToString();
                    string PAN = Request.QueryString["PAN"].ToString();
                    string Quarter = Request.QueryString["Quarter"].ToString();
                    string FormNo = Request.QueryString["FormNo"].ToString();
                    string Financial_Year = Request.QueryString["FY"].ToString();

                    //Create object Parameters
                    objtbl_TANMaster.TAN = TAN;
                    objtbl_TANMaster.Quarter = Quarter;
                    objtbl_TANMaster.Financial_Year = Financial_Year;
                    objtbl_TANMaster.FormNo = FormNo;
                    objtbl_TANMaster.Regular_Correction = type;
                    //Get the MasterId
                    int MasterID = objBltbl_TANMaster.Get_MasterID(objtbl_TANMaster);
                    ViewState["MasterID"] = MasterID;
                    btn_backtoChallan.Visible = true;
                    msg_TanCorrection1.Confirm("Do you Want to 'CHANGE TAN'");

                }
                if (type == "TAN")
                {

                    string TAN = Request.QueryString["TAN"].ToString();

                    txt_TANNumber.Text = TAN;

                }
            }
            else
            {
                if (Session["IsEditTAN"] != null)
                {
                    if (Session["IsEditTAN"].ToString() == "Edit")
                    {
                        hdnEditTAN.Value = Session["EditTAN"].ToString();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Javascript", "javascript:getHdn();", true);
                    }
                }
                btn_backtoChallan.Visible = false;
                ViewState["Regular_Correction"] = "Regular";

            }
            txt_TANNumber.Focus();
        }

        if (Session["TAN"] != null)
        {
            ViewState["Regular_Correction"] = "Regular";// Session["OC"].ToString();
            FillScreenBYSearch("TAN", Session["TAN"].ToString());
            txt_TANNumber.Text = Session["TAN"].ToString();
        }

        req_MinistryName.Visible = false;
        //Create the ContextKey For TAN
        string contextkey_TAN = auto_TAN.ContextKey.ToString();
        contextkey_TAN = contextkey_TAN.Replace("'", "");
        contextkey_TAN = contextkey_TAN.Replace("'", "");

        //Create the Context Key For AName
        string context_AName = auto_AName.ContextKey.ToString();
        context_AName = context_AName.Replace("'", "");
        context_AName = context_AName.Replace("'", "");


        txt_TANNumber.Attributes.Add("onkeyup", "ShowMessage(event,this,'" + contextkey_TAN + "')");
        txt_AssesseName.Attributes.Add("onkeyup", "ShowMessage(event,this,'" + context_AName + "')");

    }
    #endregion


    //upd_TAN.Update();

    //Function to get generate the Query for filling the autocomplete list.
    public string getQuery(int QueryID, int TableID, string FieldName, AutoCompleteExtender autoComplete_Name)
    {

        objtbl_TANMaster.QueryID = QueryID;
        objtbl_TANMaster.TableID = TableID;
        objtbl_TANMaster.FieldName = FieldName;
        //objtbl_JobWork.FieldValue = FieldValue;
        objtbl_TANMaster.Count = Convert.ToInt32(autoComplete_Name.CompletionSetCount);
        string strQuery = objBltbl_TANMaster.CreateQuery(objtbl_TANMaster) + "!" + FieldName;
        return strQuery;
    }
    //Function to Load Interface By Role
    public void Load_Interface_By_Role(int RoleID)
    {
        //Create Parameters
        objtbl_Interface_By_Role.Role_ID = RoleID;
        objtbl_Interface_By_Role.Page_Name = "Master";
        objtbl_Interface_By_Role.SubModule_Name = "TANMaster";
        dt = new DataTable();
        dt = objBltbl_Interface_By_Role.Get_Interface_By_Role(objtbl_Interface_By_Role);
        foreach (DataRow rows in dt.Rows)
        {
            int Control_ID = Convert.ToInt32(rows["Control_ID"]);
            objtbl_Interface_By_Role.Control_ID = Control_ID;
            string Visible = rows["Visible"].ToString();
            string Enable = rows["Enable"].ToString();
            string ControlID_In_Page = objBltbl_Interface_By_Role.Get_ControlID_In_Page(objtbl_Interface_By_Role);
            Control cb = maindiv;
            Find_Control_From_Page(cb, ControlID_In_Page, Visible, Enable);


        }

    }

    //Function To Iterate Through the List of Controls Available and Find the Control
    public void Find_Control_From_Page(Control ccb, string ControlID_In_Page, string Visible, string Enable)
    {
        foreach (Control ctrl in ccb.Controls)
        {
            if (ctrl.ID != null)
            {
                if (ctrl is UpdatePanel)
                {
                    foreach (Control control in ctrl.Controls[0].Controls)
                    {
                        if (control is UpdatePanel)
                        {
                            foreach (Control child_control in control.Controls[0].Controls)
                            {
                                if (child_control is Button)
                                {
                                    if (ControlID_In_Page == child_control.ID.ToString())
                                    {
                                        Button btn = (Button)child_control;
                                        if (Visible == "Y")
                                        {
                                            btn.Visible = true;
                                        }
                                        else
                                        {
                                            btn.Visible = false;
                                        }
                                        if (Enable == "Y")
                                        {
                                            btn.Enabled = true;
                                        }
                                        else
                                        {
                                            btn.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (control is Button)
                            {
                                if (ControlID_In_Page == control.ID.ToString())
                                {
                                    Button btn = (Button)control;
                                    if (Visible == "Y")
                                    {
                                        btn.Visible = true;
                                    }
                                    else
                                    {
                                        btn.Visible = false;
                                    }
                                    if (Enable == "Y")
                                    {
                                        btn.Enabled = true;
                                    }
                                    else
                                    {
                                        btn.Enabled = false;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (ctrl is Button)
                    {
                        if (ControlID_In_Page == ctrl.ID.ToString())
                        {
                            Button btn = (Button)ctrl;
                            if (Visible == "Y")
                            {
                                btn.Visible = true;
                            }
                            else
                            {
                                btn.Visible = false;
                            }
                            if (Enable == "Y")
                            {
                                btn.Enabled = true;
                            }
                            else
                            {
                                btn.Enabled = false;
                            }
                        }
                    }
                }



                Find_Control_From_Page(ctrl, ControlID_In_Page, Visible, Enable);
            }


        }

    }



    //Function For Showing the Default ReturnType on PageLoad
    public void GetDefaultReturnType()
    {
        drp_ReturnType.SelectedIndex = 1;
        if (drp_ReturnType.SelectedIndex == 1)
        {
            Bind_Deductor_Combo();
        }
        mv_TAN.SetActiveView(vw_TAN1);
        //update_TANMaster.Update();
    }
    //Bind Deductor Dropdownlist
    public void Bind_Deductor_Combo()
    {
        //Fill DeductorType Combo
        drp_DeductorType1.DataSource = objBltbl_TANMaster.GetDeductorType();
        drp_DeductorType1.DataValueField = "deductorCode";
        drp_DeductorType1.DataTextField = "deductorType";
        drp_DeductorType1.DataBind();
        drp_DeductorType1.Items.Insert(0, new ListItem("Select", ""));
    }
    //Bind Status Combo
    public void Bind_Status_Combo()
    {
        //Fill Status Combo
        drp_DeductorType1.DataSource = objBltbl_TANMaster.Get_AIR_DeductorType();
        drp_DeductorType1.DataValueField = "Status_Code";
        drp_DeductorType1.DataTextField = "Status_Name";
        drp_DeductorType1.DataBind();
        drp_DeductorType1.Items.Insert(0, new ListItem("Select", ""));

    }
    //Function For Selected ReturnType
    public void GetSelectedReturnType()
    {
        if (drp_ReturnType.SelectedIndex == 0)
        {
            mv_TAN.SetActiveView(vw_TAN1);

            Bind_Deductor_Combo();
            // update_TANMaster.Update();
        }
        else if (drp_ReturnType.SelectedIndex == 1)
        {
            mv_TAN.SetActiveView(vw_TAN1);
            Multiview2.SetActiveView(vw_tab3);
            Bind_Deductor_Combo();
            // update_TANMaster.Update();
        }
        else if (drp_ReturnType.SelectedIndex == 2)
        {
            mv_TAN.SetActiveView(vw_TAN2);
            Multiview2.SetActiveView(vw_tab4);
            Bind_Status_Combo();
            // update_TANMaster.Update();
        }

    }

    protected void drp_ReturnType_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetSelectedReturnType();
    }
    //Function for filling the combo
    public void FillCombo()
    {


        //Fill Ministry Combo
        drp_MinistryName.DataSource = objBltbl_TANMaster.GetMinistryCombo();
        drp_MinistryName.DataValueField = "ministryId";
        drp_MinistryName.DataTextField = "ministryName";
        drp_MinistryName.DataBind();
        drp_MinistryName.Items.Insert(0, new ListItem("Select", ""));

        //Fill StateCombo
        drp_StateName.DataSource = objBltbl_TANMaster.GetStateCombo();
        drp_StateName.DataValueField = "stateId";
        drp_StateName.DataTextField = "statename";
        drp_StateName.DataBind();
        drp_StateName.Items.Insert(0, new ListItem("Select", ""));
        //Fill StateCombo1
        drp_State.DataSource = objBltbl_TANMaster.GetStateCombo();
        drp_State.DataValueField = "stateId";
        drp_State.DataTextField = "statename";
        drp_State.DataBind();
        drp_State.Items.Insert(0, new ListItem("Select", ""));
        //FillCombo StateCombo2
        drp_State1.DataSource = objBltbl_TANMaster.GetStateCombo();
        drp_State1.DataValueField = "stateId";
        drp_State1.DataTextField = "statename";
        drp_State1.DataBind();
        drp_State1.Items.Insert(0, new ListItem("Select", ""));
        //FillCombo State   Combo3
        drp_State2.DataSource = objBltbl_TANMaster.GetStateCombo();
        drp_State2.DataValueField = "stateId";
        drp_State2.DataTextField = "statename";
        drp_State2.DataBind();
        drp_State2.Items.Insert(0, new ListItem("Select", ""));
        //Fill DistrictCombo
        drp_District.DataSource = objBltbl_TANMaster.GetDistrictCombo();
        drp_District.DataValueField = "DistrictCode";
        drp_District.DataTextField = "DistrictName";
        drp_District.DataBind();
        drp_District.Items.Insert(0, new ListItem("Select", ""));
        //Fill DesignationCombo
        //Commented by Mudit On 06/04/2015 AS Designation Will now be Entered by texbox
        //drp_Designation.DataSource= objBltbl_TANMaster.GetDesignation();
        //drp_Designation.DataValueField = "designation";
        //drp_Designation.DataTextField = "designation";
        //drp_Designation.DataBind();
        //drp_Designation.Items.Insert(0, new ListItem("Select", ""));

        //Fill CITCombo
        drp_JurisdictionalName.DataSource = objBltbl_TANMaster.GetCIT();
        drp_JurisdictionalName.DataValueField = "Code";
        drp_JurisdictionalName.DataTextField = "Location";
        drp_JurisdictionalName.DataBind();
        drp_JurisdictionalName.Items.Insert(0, new ListItem("Select", ""));
        //Fill MediumofReturn Combo
        drp_MediumofReturn.DataSource = objBltbl_TANMaster.GetMediumofReturns();
        drp_MediumofReturn.DataValueField = "MedCode";
        drp_MediumofReturn.DataTextField = "MediumName";
        drp_MediumofReturn.DataBind();
        drp_MediumofReturn.Items.Insert(0, new ListItem("Select", ""));





    }
    //Function for enabling and Disabling Fields according to Deductor Type
    public void FieldsByDeductorType()
    {
        if (drp_DeductorType1.SelectedIndex == 0)
        {
            drp_StateName.Enabled = true;
            drp_MinistryName.Enabled = true;
            if (drp_MinistryName.Enabled == true)
            {
                req_MinistryName.Visible = true;
            }
            txt_PAOCode.Enabled = true;
            txt_DDOCode.Enabled = true;
            txt_PAORegistrationNo.Enabled = true;
            txt_DDORegistrationNo.Enabled = true;
            if (drp_MinistryName.Enabled == true && drp_StateName.Enabled == true && txt_PAOCode.Enabled == true && txt_DDOCode.Enabled == true && txt_PAORegistrationNo.Enabled == true && txt_DDORegistrationNo.Enabled == true)
            {

                drp_StateName.Attributes.Remove("style");

                drp_MinistryName.Attributes.Remove("style");
                txt_PAOCode.Attributes.Remove("style");
                txt_DDOCode.Attributes.Remove("style");
                txt_PAORegistrationNo.Attributes.Remove("style");
                txt_DDORegistrationNo.Attributes.Remove("style");

            }
        }
        if (drp_DeductorType1.SelectedItem != null)
        {
            if (drp_DeductorType1.SelectedItem.ToString() == "Artificial Juridical Person" || drp_DeductorType1.SelectedItem.ToString() == "Association of Person (Trust)" || drp_DeductorType1.SelectedItem.ToString() == "Association of Person (AOP)" || drp_DeductorType1.SelectedItem.ToString() == "Body of Individuals" || drp_DeductorType1.SelectedItem.ToString() == "Branch / Division of Company" || drp_DeductorType1.SelectedItem.ToString() == "Company" || drp_DeductorType1.SelectedItem.ToString() == "Firm" || drp_DeductorType1.SelectedItem.ToString() == "Individual/HUF")
            {
                drp_StateName.Enabled = false;

                drp_MinistryName.Enabled = false;

                txt_PAOCode.Enabled = false;
                txt_DDOCode.Enabled = false;
                txt_PAORegistrationNo.Enabled = false;
                txt_DDORegistrationNo.Enabled = false;
                if (drp_MinistryName.Enabled == false && drp_StateName.Enabled == false && txt_PAOCode.Enabled == false && txt_DDOCode.Enabled == false && txt_PAORegistrationNo.Enabled == false && txt_DDORegistrationNo.Enabled == false)
                {
                    req_MinistryName.Visible = false;
                    drp_StateName.Attributes.Add("style", "background-color:#E3E3E3");

                    drp_MinistryName.Attributes.Add("style", "background-color:#E3E3E3");
                    txt_PAOCode.Attributes.Add("style", "background-color:#E3E3E3");
                    txt_DDOCode.Attributes.Add("style", "background-color:#E3E3E3");
                    txt_PAORegistrationNo.Attributes.Add("style", "background-color:#E3E3E3");
                    txt_DDORegistrationNo.Attributes.Add("style", "background-color:#E3E3E3");

                }

            }
            else if (drp_DeductorType1.SelectedItem.ToString() == "Autonomous body (Central Govt.)" || drp_DeductorType1.SelectedItem.ToString() == "Local Authority (Central Govt.)" || drp_DeductorType1.SelectedItem.ToString() == "Central Government" || drp_DeductorType1.SelectedItem.ToString() == "Statutory body (Central Govt.)")
            {
                drp_StateName.Enabled = false;
                drp_MinistryName.Enabled = true;
                if (drp_MinistryName.Enabled == true)
                {
                    req_MinistryName.Visible = true;

                }
                txt_PAOCode.Enabled = true;
                txt_DDOCode.Enabled = true;
                txt_PAORegistrationNo.Enabled = true;
                txt_DDORegistrationNo.Enabled = true;
                if (drp_StateName.Enabled == false)
                {
                    drp_StateName.Attributes.Add("style", "background-color:#E3E3E3");
                    drp_MinistryName.Attributes.Remove("style");
                    txt_PAOCode.Attributes.Remove("style");
                    txt_DDOCode.Attributes.Remove("style");
                    txt_PAORegistrationNo.Attributes.Remove("style");
                    txt_DDORegistrationNo.Attributes.Remove("style");
                }
                if (drp_DeductorType1.SelectedItem.ToString() == "Central Government")
                {
                    lbl_AINNumber.Attributes.Remove("style");
                    txt_AINNumber.Attributes.Remove("style");
                }
            }
            else if (drp_DeductorType1.SelectedItem.ToString() == "Autonomous body (State Govt.)" || drp_DeductorType1.SelectedItem.ToString() == "Local Authority (State Govt.)" || drp_DeductorType1.SelectedItem.ToString() == "Statutory body (State Govt.)")
            {
                drp_StateName.Enabled = true;
                drp_MinistryName.Enabled = true;
                if (drp_MinistryName.Enabled == true)
                {
                    req_MinistryName.Visible = true;

                }
                txt_PAOCode.Enabled = true;
                txt_DDOCode.Enabled = true;
                txt_PAORegistrationNo.Enabled = true;
                txt_DDORegistrationNo.Enabled = true;

                if (drp_MinistryName.Enabled == true && drp_StateName.Enabled == true && txt_PAOCode.Enabled == true && txt_DDOCode.Enabled == true && txt_PAORegistrationNo.Enabled == true && txt_DDORegistrationNo.Enabled == true)
                {
                    req_MinistryName.Visible = false;
                    drp_StateName.Attributes.Remove("style");

                    drp_MinistryName.Attributes.Remove("style");
                    txt_PAOCode.Attributes.Remove("style");
                    txt_DDOCode.Attributes.Remove("style");
                    txt_PAORegistrationNo.Attributes.Remove("style");
                    txt_DDORegistrationNo.Attributes.Remove("style");

                }
            }
            else if (drp_DeductorType1.SelectedItem.ToString() == "State Government")
            {
                drp_StateName.Enabled = true;
                drp_MinistryName.Enabled = false;
                if (drp_MinistryName.Enabled == false)
                {
                    req_MinistryName.Visible = false;
                    drp_MinistryName.Attributes.Add("style", "background-color:#E3E3E3");
                    drp_StateName.Attributes.Remove("style");
                    //txt_PAOCode.Attributes.Remove("style");
                    // txt_DDOCode.Attributes.Remove("style");
                    // txt_PAORegistrationNo.Attributes.Remove("style");
                    // txt_DDORegistrationNo.Attributes.Remove("style");
                }
                txt_PAOCode.Enabled = false;
                txt_PAOCode.Attributes.Add("style", "background-color:#E3E3E3");
                txt_DDOCode.Enabled = false;
                txt_DDOCode.Attributes.Add("style", "background-color:#E3E3E3");
                txt_PAORegistrationNo.Enabled = false;
                txt_PAORegistrationNo.Attributes.Add("style", "background-color:#E3E3E3");
                txt_DDORegistrationNo.Enabled = false;
                txt_DDORegistrationNo.Attributes.Add("style", "background-color:#E3E3E3");
                lbl_AINNumber.Attributes.Remove("style");
                txt_AINNumber.Attributes.Remove("style");
            }
        }
    }

    protected void drp_DeductorType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FieldsByDeductorType();

    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        //gdv_SearchTAN.DataSource = objTANMaster.FillTANSearchGrid(txt_customerName.Text);
        //gdv_SearchTAN.DataBind();
    }
    //protected void btn_Clear_Click(object sender, EventArgs e)
    //{
    //    drp_StateName.SelectedIndex = 0;
    //}

    #region Save and Update TAN Master
    //Evenet to Save and Update the TAN Master
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //Clear List
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.Previous_Table = "";
        DBtbl_Module.lst_update = new List<string[]>();


        //Pnl_NewTAN.Attributes.Add("style", "display:none");
        string PAN_Number = txt_PANNumber.Text;
        string TAN_Number = txt_TANNumber.Text;

        string A_Name = txt_AssesseName.Text;
        bool IS_TAN_Valid = ValidateTAN(TAN_Number, "");
        bool Is_PAN_Valid = ValiadtePAN(PAN_Number);
        if (Is_PAN_Valid && IS_TAN_Valid)
        {
            string Regular_Correction = ViewState["Regular_Correction"].ToString();
            if (Regular_Correction != "Correction")
            {
                objtbl_TANMaster.TAN = txt_TANNumber.Text.ToUpper();
                bool Is_Old_Record = objBltbl_TANMaster.CheckRecordExistence(objtbl_TANMaster);
                string Return_Type = drp_ReturnType.SelectedValue.ToString();
                if (!Is_Old_Record && FlagSave != "NS")
                {
                    btn_Save.CausesValidation = true;

                    if (Return_Type == "TDS")
                    {
                        SaveTANEntry();
                    }
                    else if (Return_Type == "AIR")
                    {
                        SaveAIRRecords();
                    }
                    FlagSave = "S";
                    //MessageBox.BoxType = "";
                    //MessageBox.Show("Record Saved SuccesFully", "a");
                    RefreshControls();
                    //change
                    txt_TANNumber.Text = "";
                    txt_PANNumber.Text = "";
                    txt_AssesseName.Text = "";
                    txt_PersonResponsible.Text = "";
                    txt_PANofResPer.Text = "";
                    drp_DeductorType1.SelectedIndex = 0;
                    //drp_Designation.SelectedIndex = 0;
                    drp_StateName.SelectedIndex = 0;
                    //Added by Mudit On 06/04/2015
                    txtDesignation.Text = "";


                }
                else if (Is_Old_Record && FlagSave != "NS")
                {

                    btn_Save.CausesValidation = false;
                    if (Return_Type == "TDS")
                    {
                        UpdateTANEntry();

                    }
                    else if (Return_Type == "AIR ")
                    {
                        UpdateAIRMaster();
                    }

                    FlagSave = "S";
                    //MessageBox.BoxType = "";
                    //MessageBox.Show("TAN Entry Updated Successfully", "a");
                    RefreshControls();

                    //change
                    txt_TANNumber.Text = "";
                    txt_PANNumber.Text = "";
                    txt_AssesseName.Text = "";
                    txt_PANofResPer.Text = "";
                    txt_PersonResponsible.Text = "";
                    drp_DeductorType1.SelectedIndex = 0;
                    //drp_Designation.SelectedIndex = 0;
                    drp_StateName.SelectedIndex = 0;
                    //Added by Mudit on 06/04/2015
                    txtDesignation.Text = "";


                }
                txt_TANNumber.Focus();
            }
            else if (Regular_Correction == "Correction")
            {
                if (FlagC1 == "Yes")
                {
                    SaveEntryBH_Correction_C1();
                    FlagC1 = "";
                    int MasterID = Convert.ToInt32(ViewState["MasterID"]);
                    bool Is_Compared = Compare_TAN_BH_Correction(TAN_Number, MasterID, Regular_Correction);
                    if (!Is_Compared)
                    {
                        //msg_ConfirmCorrection.Confirm("Do you want to Update TANMaster!");
                    }

                }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Record Saved!');", true);
            if (Session["UserRole"] != null)
            {
                if (Session["UserRole"].ToString() == "Reception")
                    Response.Redirect("Reception/Default.aspx");
            }
            Response.Redirect("Main.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Either PAN or TAN is Invalid,Please Check!');", true);
        }

    }
    //Function to Save the TAN Master Records.
    public void SaveTANEntry()
    {
        //Create Parameters Variables
        string TAN = txt_TANNumber.Text.ToUpper();
        string PAN = txt_PANNumber.Text.ToUpper();
        string Type = drp_DeductorType1.SelectedValue.ToString();
        string AName = txt_AssesseName.Text;
        string PName = txt_PersonResponsible.Text;
        string PANofPName = txt_PANofResPer.Text;
        //Added by Mudit on 06/04/2015
        string PDesig = txtDesignation.Text;//string PDesig=drp_Designation.SelectedItem.ToString();
        string AFlat = txt_Address1.Text;
        string APremises = txt_Address2.Text;
        string ARoad = txt_Address3.Text;
        string AArea = txt_Address4.Text;
        string ATown = txt_Address5.Text;
        string AState = drp_State.SelectedValue.ToString();
        string APINCode = txt_PINCode.Text;
        string PFlat = txt_Address01.Text;
        string PPremises = txt_Address02.Text;
        string PRoad = txt_Address03.Text;
        string PArea = txt_Address04.Text;
        string PTown = txt_Address05.Text;
        string PState = drp_State1.SelectedValue.ToString();
        string PPINCode = txt_PINCode1.Text;
        string Branch = txt_BranchorDivision.Text;
        string ASTDCode = txt_STDCode.Text;
        string APhone = txt_Telephone.Text;
        string AEmail = txt_Email.Text;
        string PSTDCode = txt_STDCode1.Text;
        string PPhone = txt_Telephone1.Text;
        string PEmail = txt_Email1.Text;
        string FatherName = txt_FatherName.Text;
        string Flat = txt_FlatNo.Text;
        string House = txt_HouseorPremisesNo.Text;
        string Floor = txt_FloorNo.Text;
        string Building = txt_BuildingName.Text;
        string Block = txt_BlockorSector.Text;
        string Road = txt_RoadorStreet.Text;
        string Locality = txt_LocalityorColony.Text;
        string City = txt_City.Text;
        string State = drp_State2.Text;
        string PINCode = txt_PINCode2.Text;
        string Status = "";
        string CIT = drp_JurisdictionalName.SelectedValue.ToString();
        string District = drp_District.SelectedValue.ToString();
        string Medium = drp_MediumofReturn.SelectedValue.ToString();
        string FileNum = "";
        string StateCode = drp_StateName.SelectedValue.ToString();
        string PAOCode = txt_PAOCode.Text;
        string DDOCode = txt_DDOCode.Text;
        string PAORegNO = txt_PAORegistrationNo.Text;
        string DDORegNo = txt_DDORegistrationNo.Text;
        string MinistryCode = drp_MinistryName.SelectedValue.ToString();
        string MinistryName = string.Empty;
        if (drp_MinistryName.SelectedItem.ToString() == "Select")
        {
            MinistryName = "";
        }
        else
        {
            MinistryName = drp_MinistryName.SelectedValue.ToString();
        }

        string MobileNumber = txt_MobileNo.Text;

        //Create Parameters
        objtbl_TANMaster.TAN = TAN;
        objtbl_Accounts1.TAN = TAN;

        objtbl_TANMaster.PAN = PAN;
        objtbl_Accounts1.PAN = PAN;

        objtbl_TANMaster.Type = Type;
        objtbl_Accounts1.Flag = "17";

        objtbl_TANMaster.AName = AName;
        objtbl_Accounts1.AccName = AName;

        objtbl_TANMaster.PName = PName;
        objtbl_Accounts1.Contact_Person = PName;

        objtbl_TANMaster.PDesig = PDesig;

        objtbl_TANMaster.AFlat = AFlat;
        objtbl_Accounts1.A_Address1 = AFlat;

        objtbl_TANMaster.APremises = APremises;
        objtbl_Accounts1.A_Address2 = APremises;

        objtbl_TANMaster.ARoad = ARoad;
        objtbl_Accounts1.A_Address3 = ARoad;

        objtbl_TANMaster.AArea = AArea;
        objtbl_Accounts1.A_Address4 = AArea;

        objtbl_TANMaster.ATown = ATown;
        objtbl_Accounts1.A_Address5 = ATown;

        objtbl_TANMaster.AState = AState;
        objtbl_Accounts1.A_State_ID = Convert.ToInt32(AState);
        objtbl_Accounts1.A_City_ID = 0;
        objtbl_Accounts1.A_Country_ID = 76;

        objtbl_TANMaster.APINCode = APINCode;

        objtbl_TANMaster.PFlat = PFlat;
        objtbl_Accounts1.P_Address1 = PFlat;

        objtbl_TANMaster.PPremises = PPremises;
        objtbl_Accounts1.P_Address2 = PPremises;

        objtbl_TANMaster.PRoad = PRoad;
        objtbl_Accounts1.P_Address3 = PRoad;

        objtbl_TANMaster.PArea = PArea;
        objtbl_Accounts1.P_Address4 = PArea;

        objtbl_TANMaster.PTown = PTown;
        objtbl_Accounts1.P_Address5 = PTown;

        objtbl_TANMaster.PState = PState;
        objtbl_Accounts1.P_StateID = Convert.ToInt32(PState);
        objtbl_Accounts1.P_CityID = 0;
        objtbl_Accounts1.P_CountryID = 76;
        objtbl_TANMaster.PPINCode = PPINCode;

        objtbl_TANMaster.Branch = Branch;

        objtbl_TANMaster.ASTDCode = ASTDCode;
        objtbl_TANMaster.APhone = APhone;
        string Acc_Telephone = ASTDCode + APhone;
        objtbl_Accounts1.A_Telephone1 = Acc_Telephone;
        objtbl_Accounts1.A_Telephone2 = "";
        objtbl_Accounts1.A_Telephone3 = "";

        objtbl_TANMaster.AEmail = AEmail;
        objtbl_Accounts1.A_Email_ID1 = AEmail;
        objtbl_Accounts1.A_Email_ID2 = "";

        objtbl_TANMaster.PSTDCode = PSTDCode;
        objtbl_TANMaster.PPhone = PPhone;
        string Acc_PTelephone = PSTDCode + PPhone;
        objtbl_Accounts1.P_Telephone1 = Acc_PTelephone;
        objtbl_Accounts1.P_Telephone2 = "";
        objtbl_Accounts1.P_Telephone3 = "";

        objtbl_TANMaster.PEmail = PEmail;
        objtbl_Accounts1.P_Email_ID1 = PEmail;
        objtbl_Accounts1.P_Email_ID2 = "";

        objtbl_TANMaster.FatherName = FatherName;
        objtbl_Accounts1.Father_Name = FatherName;

        objtbl_TANMaster.Flat = Flat;
        objtbl_TANMaster.House = House;
        objtbl_TANMaster.Floor = Floor;
        objtbl_TANMaster.Building = Building;
        objtbl_TANMaster.Block = Block;
        objtbl_TANMaster.Road = Road;
        objtbl_TANMaster.Locality = Locality;
        objtbl_TANMaster.City = City;
        objtbl_TANMaster.State = State;
        objtbl_TANMaster.PINCode = PINCode;
        objtbl_TANMaster.Status = Status;
        objtbl_TANMaster.CIT = CIT;
        objtbl_TANMaster.District = District;
        objtbl_TANMaster.Medium = Medium;
        objtbl_TANMaster.FileNum = FileNum;
        objtbl_TANMaster.StateCode = StateCode;
        objtbl_TANMaster.PAOCode = PAOCode;
        objtbl_TANMaster.DDOCode = DDOCode;
        objtbl_TANMaster.PAORegNo = PAORegNO;
        objtbl_TANMaster.DDORegNo = DDORegNo;
        objtbl_TANMaster.MinistryCode = MinistryCode;
        objtbl_TANMaster.MinistryName = MinistryName;
        objtbl_TANMaster.MobileNumber = MobileNumber;
        objtbl_TANMaster.AIN_Number = "";
        objtbl_TANMaster.AIN_Number = txt_AINNumber.Text;
        //Added by Mudit 
        objtbl_TANMaster.PANof_Responsible_Person = PANofPName;
        objtbl_TANMaster.username = Session["userEmail"].ToString();

        objtbl_Accounts1.A_Mobile1 = MobileNumber;
        objtbl_Accounts1.A_Mobile2 = "";
        objtbl_Accounts1.P_Mobile1 = MobileNumber;
        objtbl_Accounts1.P_Mobile2 = "";
        objtbl_Accounts1.Opening_Bal = 0.00;
        objtbl_Accounts1.Reffered_By_ID = 0;
        objtbl_Accounts1.Name_of_Firm = "ALL";
        objtbl_Accounts1.Category = "";
        objtbl_Accounts1.FY = "";
        objtbl_Accounts1.NonEditable = "N";
        objtbl_TANMaster.Page_ID = "1";
        objtbl_TANMaster.Page_SubModule_ID = "1";
        objtbl_Accounts1.Page_ID = "1";
        objtbl_Accounts1.Page_SubModule_ID = "14";
        //Call Insert Function and Pass Parameter to the Function
        int success = objBltbl_TANMaster.InsertTANEntry(objtbl_TANMaster);
        //if (success == 1)
        //{
        //    FlagSuccess = "Y";
        //    objtbl_TANMaster.TAN = "-999999999";
        //    objtbl_TANMaster.PAN = "";
        //    objtbl_TANMaster.Type = "";
        //    objtbl_TANMaster.AName = "";
        //    objtbl_TANMaster.PName = "";
        //    objtbl_TANMaster.PDesig = "";
        //    objtbl_TANMaster.AFlat = "";
        //    objtbl_TANMaster.APremises = "";
        //    objtbl_TANMaster.ARoad = "";
        //    objtbl_TANMaster.AArea = "";
        //    objtbl_TANMaster.ATown = "";
        //    objtbl_TANMaster.AState = "";
        //    objtbl_TANMaster.APINCode = "";
        //    objtbl_TANMaster.PFlat = "";
        //    objtbl_TANMaster.PPremises = "";
        //    objtbl_TANMaster.PRoad = "";
        //    objtbl_TANMaster.PArea = "";
        //    objtbl_TANMaster.PTown = "";
        //    objtbl_TANMaster.PState = "";
        //    objtbl_TANMaster.PPINCode = "";
        //    objtbl_TANMaster.Branch = "";
        //    objtbl_TANMaster.ASTDCode = "";
        //    objtbl_TANMaster.APhone = "";
        //    objtbl_TANMaster.AEmail = "";
        //    objtbl_TANMaster.PSTDCode = "";
        //    objtbl_TANMaster.PPhone = "";
        //    objtbl_TANMaster.PEmail = "";
        //    objtbl_TANMaster.FatherName = "";
        //    objtbl_TANMaster.Flat = "";
        //    objtbl_TANMaster.House = "";
        //    objtbl_TANMaster.Floor = "";
        //    objtbl_TANMaster.Building = "";
        //    objtbl_TANMaster.Block = "";
        //    objtbl_TANMaster.Road = "";
        //    objtbl_TANMaster.Locality = "";
        //    objtbl_TANMaster.City = "";
        //    objtbl_TANMaster.State = "";
        //    objtbl_TANMaster.PINCode = "";
        //    objtbl_TANMaster.Status = "";
        //    objtbl_TANMaster.CIT = "";
        //    objtbl_TANMaster.District = "";
        //    objtbl_TANMaster.Medium = "";
        //    objtbl_TANMaster.FileNum = "";
        //    objtbl_TANMaster.StateCode = "";
        //    objtbl_TANMaster.PAOCode = "";
        //    objtbl_TANMaster.DDOCode = "";
        //    objtbl_TANMaster.PAORegNo = "";
        //    objtbl_TANMaster.DDORegNo = "";
        //    objtbl_TANMaster.MinistryCode = "";
        //    objtbl_TANMaster.MinistryName = "";
        //    objtbl_TANMaster.MobileNumber = "";
        //    objtbl_TANMaster.AIN_Number = "";
        //    objtbl_TANMaster.PANof_Responsible_Person = "";
        //    objBltbl_TANMaster.InsertTANEntry(objtbl_TANMaster);

        //    Check the Existence of the Accounts 

        //    bool Is_Exist = objBLtbl_Accounts11.Check_Existence_Account_By_TAN(objtbl_Accounts1);
        //    if (!Is_Exist)
        //    {
        //        SaveAccountsEntry(objtbl_Accounts1);
        //    }
        //    else 
        //    {
        //        UpdateAccountsEntry(objtbl_Accounts1);
        //    }
        //    SaveTANwithUser(txt_TANNumber.Text);
        //}
    }

    //Function to Save Accounts Entry
    public void SaveAccountsEntry(tbl_Accounts1 objtbl_Accounts1)
    {
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.Previous_Table = "";
        DBtbl_Module.lst_update = new List<string[]>();
        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "VS," + ApplicationHost + "," + Leftpath;
        DynamicControl.Project_Name = "VS," + ApplicationHost + "," + Leftpath;
        int success = objBLtbl_Accounts11.Insert_Record_Accounts(objtbl_Accounts1);
        if (success == 1)
        {
            //Intialize the object of System.Config
            objBltbl_Vouchers = new Bltbl_Vouchers(strConnectionString_VS, strConnName_VS, strConnectionString_Admin);
            objtbl_Vouchers = new tbl_Vouchers();
            string AccName = objtbl_Accounts1.AccName;
            objtbl_Accounts1.AccName = "-999999999";
            objBLtbl_Accounts11.Insert_Record_Accounts(objtbl_Accounts1);
            DataTable dt_Voucher = new DataTable();
            DataTable dt_Voucher_Details_Accounts = new DataTable();
            //Create string Array Of Voucher Detail
            string[] arr_Voucher_field = new string[] { DateTime.Now.ToShortDateString(), "0", "" };
            objtbl_System_Config.Table_Name = "tbl_Vouchers";
            dt_Voucher = objBltbl_System_Config.Get_Column_Name_With_DataType(objtbl_System_Config);
            dt_Voucher.Columns.Remove(dt_Voucher.Columns[0]);
            dt_Voucher.TableName = "tbl_Vouchers";

            //Add New Datarow 
            DataRow dr_Voucher = dt_Voucher.NewRow();
            //Voucher Date Field
            dr_Voucher["Voucher_Date"] = arr_Voucher_field[0].ToString();
            //Voucher BillNo Field
            dr_Voucher["Bill_No"] = Convert.ToInt32(arr_Voucher_field[1]);
            //Voucher Receipt Field 
            dr_Voucher["Receipt_ID"] = 0;
            //Voucher Name_Of_Firm
            dr_Voucher["Name_Of_Firm"] = arr_Voucher_field[2].ToString();

            //Add the Row to the Voucher Table
            dt_Voucher.Rows.Add(dr_Voucher);
            dt_Voucher.AcceptChanges();


            //Create Voucher Details Table
            objtbl_Accounts1.AccName = AccName;
            int Acc_ID = objBLtbl_Accounts11.GetAccID(objtbl_Accounts1);
            string[] arr_Voucher_Detail_Fields = new string[8];
            objtbl_System_Config.Table_Name = "tbl_Voucher_Details";
            dt_Voucher_Details_Accounts = objBltbl_System_Config.Get_Column_Name_With_DataType(objtbl_System_Config);
            dt_Voucher_Details_Accounts.Columns.Remove(dt_Voucher_Details_Accounts.Columns[0]);
            dt_Voucher_Details_Accounts.Columns.Remove(dt_Voucher_Details_Accounts.Columns[0]);
            dt_Voucher_Details_Accounts.TableName = "tbl_Voucher_Details";
            //Fill the Value in the Array

            arr_Voucher_Detail_Fields[0] = Acc_ID.ToString();
            arr_Voucher_Detail_Fields[1] = "To Opening Balance";
            arr_Voucher_Detail_Fields[2] = "D";
            arr_Voucher_Detail_Fields[3] = objtbl_Accounts1.Opening_Bal.ToString();
            arr_Voucher_Detail_Fields[4] = "1";
            arr_Voucher_Detail_Fields[5] = "0";
            arr_Voucher_Detail_Fields[6] = objtbl_Accounts1.FY;




            //Fill Record in the Datattable
            DataRow dr_Voucher_Details = dt_Voucher_Details_Accounts.NewRow();

            //Add Acc_ID in the Row
            dr_Voucher_Details["Acc_ID"] = Convert.ToInt32(arr_Voucher_Detail_Fields[0]);
            //Add Narration in the Row 
            dr_Voucher_Details["Narration"] = arr_Voucher_Detail_Fields[1].ToString();
            //Add Debit Amount in the Row
            string Debit_Credit = arr_Voucher_Detail_Fields[2].ToString();
            dr_Voucher_Details["Debit_Credit"] = Debit_Credit;
            if (Debit_Credit == "D")
            {
                dr_Voucher_Details["Debit_Amount"] = arr_Voucher_Detail_Fields[3].ToString();
                dr_Voucher_Details["Amount"] = Convert.ToDouble(arr_Voucher_Detail_Fields[3]);

            }
            else if (Debit_Credit == "C")
            {
                dr_Voucher_Details["Credit_Amount"] = arr_Voucher_Detail_Fields[3].ToString();
                dr_Voucher_Details["Amount"] = Convert.ToDouble(arr_Voucher_Detail_Fields[3]) * -1;
            }

            // Add Voucher Detail id in the Row
            dr_Voucher_Details["Voucher_DetailID"] = Convert.ToInt32(arr_Voucher_Detail_Fields[4]);
            //Add Enabled Field  in the Row
            dr_Voucher_Details["Enabled"] = "false";

            dr_Voucher_Details["V_Type"] = arr_Voucher_Detail_Fields[5].ToString();
            dr_Voucher_Details["FY"] = arr_Voucher_Detail_Fields[6].ToString();

            dt_Voucher_Details_Accounts.Rows.Add(dr_Voucher_Details);
            dt_Voucher_Details_Accounts.AcceptChanges();

            //Add Table to DataSet
            objtbl_Vouchers.Page_ID = "1";
            objtbl_Vouchers.Page_SubModule_ID = "14";
            DataSet ds = new DataSet();
            ds.Tables.Add(dt_Voucher);
            ds.Tables.Add(dt_Voucher_Details_Accounts);
            //Insert the Record
            //objBltbl_Vouchers(ds,"VS");
            objBltbl_Vouchers.Insert_DataTable2(ds, "VS", objtbl_Vouchers);
        }
    }

    //Function to Update Accounts Entry
    public void UpdateAccountsEntry(tbl_Accounts1 objtbl_Accounts1)
    {
        objBLtbl_Accounts11.Update_Records_Account_By_TAN(objtbl_Accounts1);
    }
    //Function to Update the TAN Master Records. 
    public void UpdateTANEntry()
    {

        string TAN = txt_TANNumber.Text.ToUpper();
        string PAN = txt_PANNumber.Text.ToUpper();
        string Type = drp_DeductorType1.SelectedValue.ToString();
        string AName = txt_AssesseName.Text;
        string PName = txt_PersonResponsible.Text; 
        //Added by Mudit on 06/04/2015
        string PANofPName = txt_PANofResPer.Text;
        string PDesig = txtDesignation.Text;//string PDesig = drp_Designation.SelectedItem.ToString();
        string AFlat = txt_Address1.Text;
        string APremises = txt_Address2.Text;
        string ARoad = txt_Address3.Text;
        string AArea = txt_Address4.Text;
        string ATown = txt_Address5.Text;
        string AState = drp_State.SelectedValue.ToString();
        string APINCode = txt_PINCode.Text;
        string PFlat = txt_Address01.Text;
        string PPremises = txt_Address02.Text;
        string PRoad = txt_Address03.Text;
        string PArea = txt_Address04.Text;
        string PTown = txt_Address05.Text;
        string PState = drp_State1.SelectedValue.ToString();
        string PPINCode = txt_PINCode1.Text;
        string Branch = txt_BranchorDivision.Text;
        string ASTDCode = txt_STDCode.Text;
        string APhone = txt_Telephone.Text;
        string AEmail = txt_Email.Text;
        string PSTDCode = txt_STDCode1.Text;
        string PPhone = txt_Telephone1.Text;
        string PEmail = txt_Email1.Text;
        string FatherName = txt_FatherName.Text;
        string Flat = txt_FlatNo.Text;
        string House = txt_HouseorPremisesNo.Text;
        string Floor = txt_FloorNo.Text;
        string Building = txt_BuildingName.Text;
        string Block = txt_BlockorSector.Text;
        string Road = txt_RoadorStreet.Text;
        string Locality = txt_LocalityorColony.Text;
        string City = txt_City.Text;
        string State = drp_State2.Text;
        string PINCode = txt_PINCode2.Text;
        string Status = drp_DeductorType1.SelectedValue.ToString();
        string CIT = "";
        string District = drp_District.SelectedValue.ToString();
        string Medium = drp_MediumofReturn.SelectedValue;
        string FileNum = "";
        string StateCode = drp_StateName.SelectedValue.ToString();
        string PAOCode = txt_PAOCode.Text;
        string DDOCode = txt_DDOCode.Text;
        string PAORegNO = txt_PAORegistrationNo.Text;
        string DDORegNo = txt_DDORegistrationNo.Text;
        string MinistryCode = "";
        string MinistryName = string.Empty;
        if (drp_MinistryName.SelectedItem.ToString() == "---Select---")
        {
            MinistryName = "";
        }
        else
        {
            MinistryName = drp_MinistryName.SelectedValue.ToString();
        }

        string MobileNumber = txt_MobileNo.Text;
        string AIN_Number = txt_AINNumber.Text;

        //Create Parameters
        objtbl_TANMaster.TAN = TAN;
        objtbl_TANMaster.PAN = PAN;
        objtbl_TANMaster.Type = Type;
        objtbl_TANMaster.AName = AName;
        objtbl_TANMaster.PName = PName;
        objtbl_TANMaster.PDesig = PDesig;
        objtbl_TANMaster.AFlat = AFlat;
        objtbl_TANMaster.APremises = APremises;
        objtbl_TANMaster.ARoad = ARoad;
        objtbl_TANMaster.AArea = AArea;
        objtbl_TANMaster.ATown = ATown;
        objtbl_TANMaster.AState = AState;
        objtbl_TANMaster.APINCode = APINCode;
        objtbl_TANMaster.PFlat = PFlat;
        objtbl_TANMaster.PPremises = PPremises;
        objtbl_TANMaster.PRoad = PRoad;
        objtbl_TANMaster.PArea = PArea;
        objtbl_TANMaster.PTown = PTown;
        objtbl_TANMaster.PState = PState;
        objtbl_TANMaster.PPINCode = PPINCode;
        objtbl_TANMaster.Branch = Branch;
        objtbl_TANMaster.ASTDCode = ASTDCode;
        objtbl_TANMaster.APhone = APhone;
        objtbl_TANMaster.AEmail = AEmail;
        objtbl_TANMaster.PSTDCode = PSTDCode;
        objtbl_TANMaster.PPhone = PPhone;
        objtbl_TANMaster.PEmail = PEmail;
        objtbl_TANMaster.FatherName = FatherName;
        objtbl_TANMaster.Flat = Flat;
        objtbl_TANMaster.House = House;
        objtbl_TANMaster.Floor = Floor;
        objtbl_TANMaster.Building = Building;
        objtbl_TANMaster.Block = Block;
        objtbl_TANMaster.Road = Road;
        objtbl_TANMaster.Locality = Locality;
        objtbl_TANMaster.City = City;
        objtbl_TANMaster.State = State;
        objtbl_TANMaster.PINCode = PINCode;
        objtbl_TANMaster.Status = Status;
        objtbl_TANMaster.CIT = CIT;
        objtbl_TANMaster.District = District;
        objtbl_TANMaster.Medium = Medium;
        objtbl_TANMaster.FileNum = FileNum;
        objtbl_TANMaster.StateCode = StateCode;
        objtbl_TANMaster.PAOCode = PAOCode;
        objtbl_TANMaster.DDOCode = DDOCode;
        objtbl_TANMaster.PAORegNo = PAORegNO;
        objtbl_TANMaster.DDORegNo = DDORegNo;
        objtbl_TANMaster.MinistryCode = MinistryCode;
        objtbl_TANMaster.MinistryName = MinistryName;
        objtbl_TANMaster.MobileNumber = MobileNumber;
        objtbl_TANMaster.AIN_Number = AIN_Number; //txt_AINNumber.Text;
        objtbl_TANMaster.Page_ID = "1";
        objtbl_TANMaster.Page_SubModule_ID = "1";
        //Added by Mudit
        objtbl_TANMaster.PANof_Responsible_Person = PANofPName;
        //Call Insert Function and Pass Parameter to the Function
        int success = objBltbl_TANMaster.UpdateTANEntry(objtbl_TANMaster);
        if (success == 1)
        {
            objtbl_TANMaster.TAN = "-999999999";
            objBltbl_TANMaster.UpdateTANEntry(objtbl_TANMaster);
        }

    }
    public void UpdateTANEntry_Corr()
    {

        string TAN = txt_TANNumber.Text.ToUpper();
        string PAN = txt_PANNumber.Text.ToUpper();
        string Type = drp_DeductorType1.SelectedValue.ToString();
        string AName = ViewState["AName_Corr"].ToString();
        string PName = txt_PersonResponsible.Text; ;
        //Added by Mudit on 06/04/2015
        string PANofPName = txt_PANofResPer.Text;
        string PDesig = txtDesignation.Text;//string PDesig = drp_Designation.SelectedItem.ToString();
        string AFlat = ViewState["A_Address1_Corr"].ToString();
        string APremises = ViewState["A_Address2_Corr"].ToString();
        string ARoad = ViewState["A_Address3_Corr"].ToString();
        string AArea = ViewState["A_Address4_Corr"].ToString();
        string ATown = ViewState["A_Address5_Corr"].ToString();
        string AState = ViewState["A_State_Corr"].ToString();
        string APINCode = ViewState["A_PINCode_Corr"].ToString();
        string PFlat = ViewState["P_Address1"].ToString();
        string PPremises = ViewState["P_Address2"].ToString();
        string PRoad = ViewState["P_Address3"].ToString();
        string PArea = ViewState["P_Address4"].ToString();
        string PTown = ViewState["P_Address5"].ToString();
        string PState = ViewState["P_State"].ToString();
        string PPINCode = ViewState["P_PIN"].ToString();
        string Branch = ViewState["BranchDivision_Corr"].ToString();
        string ASTDCode = ViewState["A_STDCode_Corr"].ToString();
        string APhone = ViewState["A_Telephone_Corr"].ToString();
        string AEmail = ViewState["A_Email_Corr"].ToString();
        string PSTDCode = ViewState["P_STD_Code"].ToString();
        string PPhone = ViewState["P_Telephone"].ToString();
        string PEmail = ViewState["P_Email"].ToString();

        string FatherName = txt_FatherName.Text;
        string Flat = txt_FlatNo.Text;
        string House = txt_HouseorPremisesNo.Text;
        string Floor = txt_FloorNo.Text;
        string Building = txt_BuildingName.Text;
        string Block = txt_BlockorSector.Text;
        string Road = txt_RoadorStreet.Text;
        string Locality = txt_LocalityorColony.Text;
        string City = txt_City.Text;
        string State = drp_State2.SelectedValue.ToString();
        string PINCode = txt_PINCode2.Text;
        string Status = ViewState["Deductor_Type"].ToString();
        string CIT = "";
        string District = drp_District.SelectedValue.ToString();
        string Medium = drp_MediumofReturn.SelectedValue;
        string FileNum = "";
        string StateCode = drp_StateName.SelectedValue.ToString();
        string PAOCode = ViewState["PAO_Code"].ToString();
        string DDOCode = ViewState["DDO_Code"].ToString();
        string PAORegNO = ViewState["PAO_RegNo"].ToString();
        string DDORegNo = ViewState["DDO_RegistrationNo"].ToString();
        string MinistryCode = "";
        string MinistryName = string.Empty;
        if (drp_MinistryName.SelectedItem.ToString() == "---Select---")
        {
            MinistryName = "";
        }
        else
        {
            MinistryName = ViewState["Ministry_Name"].ToString();
        }

        string MobileNumber = ViewState["Mobile_Number"].ToString();

        //Create Parameters
        objtbl_TANMaster.TAN = TAN;
        objtbl_TANMaster.PAN = PAN;
        objtbl_TANMaster.Type = Type;
        objtbl_TANMaster.AName = AName;
        objtbl_TANMaster.PName = PName;
        objtbl_TANMaster.PDesig = PDesig;
        objtbl_TANMaster.AFlat = AFlat;
        objtbl_TANMaster.APremises = APremises;
        objtbl_TANMaster.ARoad = ARoad;
        objtbl_TANMaster.AArea = AArea;
        objtbl_TANMaster.ATown = ATown;
        objtbl_TANMaster.AState = AState;
        objtbl_TANMaster.APINCode = APINCode;
        objtbl_TANMaster.PFlat = PFlat;
        objtbl_TANMaster.PPremises = PPremises;
        objtbl_TANMaster.PRoad = PRoad;
        objtbl_TANMaster.PArea = PArea;
        objtbl_TANMaster.PTown = PTown;
        objtbl_TANMaster.PState = PState;
        objtbl_TANMaster.PPINCode = PPINCode;
        objtbl_TANMaster.Branch = Branch;
        objtbl_TANMaster.ASTDCode = ASTDCode;
        objtbl_TANMaster.APhone = APhone;
        objtbl_TANMaster.AEmail = AEmail;
        objtbl_TANMaster.PSTDCode = PSTDCode;
        objtbl_TANMaster.PPhone = PPhone;
        objtbl_TANMaster.PEmail = PEmail;
        objtbl_TANMaster.FatherName = FatherName;
        objtbl_TANMaster.Flat = Flat;
        objtbl_TANMaster.House = House;
        objtbl_TANMaster.Floor = Floor;
        objtbl_TANMaster.Building = Building;
        objtbl_TANMaster.Block = Block;
        objtbl_TANMaster.Road = Road;
        objtbl_TANMaster.Locality = Locality;
        objtbl_TANMaster.City = City;
        objtbl_TANMaster.State = State;
        objtbl_TANMaster.PINCode = PINCode;
        objtbl_TANMaster.Status = Status;
        objtbl_TANMaster.CIT = CIT;
        objtbl_TANMaster.District = District;
        objtbl_TANMaster.Medium = Medium;
        objtbl_TANMaster.FileNum = FileNum;
        objtbl_TANMaster.StateCode = StateCode;
        objtbl_TANMaster.PAOCode = PAOCode;
        objtbl_TANMaster.DDOCode = DDOCode;
        objtbl_TANMaster.PAORegNo = PAORegNO;
        objtbl_TANMaster.DDORegNo = DDORegNo;
        objtbl_TANMaster.MinistryCode = MinistryCode;
        objtbl_TANMaster.MinistryName = MinistryName;
        objtbl_TANMaster.MobileNumber = MobileNumber;
        objtbl_TANMaster.Page_ID = "1";
        objtbl_TANMaster.Page_SubModule_ID = "1";
        //Added by Mudit 
        objtbl_TANMaster.PANof_Responsible_Person = PANofPName;
        //Call Insert Function and Pass Parameter to the Function
        int success = objBltbl_TANMaster.UpdateTANEntry(objtbl_TANMaster);
        if (success == 1)
        {
            objtbl_TANMaster.TAN = "-999999999";
            objBltbl_TANMaster.UpdateTANEntry(objtbl_TANMaster);
        }

    }
    #endregion


    public void FillScreenBYSearch(string SearchBy, string FieldValue)
    {
        string FieldName = SearchBy;
        string Regular_Correction = ViewState["Regular_Correction"].ToString();
        if (Regular_Correction == "Correction")
        {
            int MasterID = Convert.ToInt32(ViewState["MasterID"]);
            objtbl_TANMaster.ID = MasterID;


        }
        else
        {
            objtbl_TANMaster.FieldName = FieldName;
            objtbl_TANMaster.FieldValue = FieldValue;

        }

        DataSet ds = new DataSet();
        //da.Fill(ds);
        objtbl_TANMaster.FieldName = FieldName;
        objtbl_TANMaster.FieldValue = FieldValue;
        objtbl_TANMaster.Regular_Correction = Regular_Correction;

        ds = objBltbl_TANMaster.FillRecords(objtbl_TANMaster);
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("");
        }
        else
        {

            if (SearchBy == "TAN")
            {
                txt_PANNumber.Text = ds.Tables[0].Rows[0]["PAN"].ToString();
                txt_AssesseName.Text = ds.Tables[0].Rows[0]["AName"].ToString();

            }
            else if (SearchBy == "PAN")
            {
                txt_TANNumber.Text = ds.Tables[0].Rows[0]["TAN"].ToString();
                txt_AssesseName.Text = ds.Tables[0].Rows[0]["AName"].ToString();
            }
            else if (SearchBy == "AName")
            {
                txt_TANNumber.Text = ds.Tables[0].Rows[0]["TAN"].ToString();
                txt_PANNumber.Text = ds.Tables[0].Rows[0]["PAN"].ToString();
            }
            string Deductor_Type = ds.Tables[0].Rows[0]["Type"].ToString();
            if (Deductor_Type != "C")
            {
                drp_DeductorType1.SelectedValue = Deductor_Type;
            }
            else
            {
                drp_DeductorType1.SelectedIndex = 0;
            }
            FieldsByDeductorType();
            txt_PersonResponsible.Text = ds.Tables[0].Rows[0]["PName"].ToString();
            txt_PANofResPer.Text = ds.Tables[0].Rows[0]["PANof_Responsible_Person"].ToString();
            if (drp_MinistryName.Enabled == false)
            {
                drp_MinistryName.SelectedIndex = 0;
            }
            else
            {
                drp_MinistryName.SelectedValue = ds.Tables[0].Rows[0]["MinistryName"].ToString();
            }

            //Added by Mudit on 06/04/2015
            txtDesignation.Text = ds.Tables[0].Rows[0]["PDesig"].ToString();//drp_Designation.SelectedItem.Text = ds.Tables[0].Rows[0]["PDesig"].ToString();
            string StateCode = ds.Tables[0].Rows[0]["StateCode"].ToString();
            if (StateCode == "")
            {
                drp_StateName.SelectedValue = StateCode;
            }
            txt_PAOCode.Text = ds.Tables[0].Rows[0]["PAOCode"].ToString();
            txt_DDOCode.Text = ds.Tables[0].Rows[0]["DDOCode"].ToString();
            txt_PAORegistrationNo.Text = ds.Tables[0].Rows[0]["PAORegNo"].ToString();
            txt_DDORegistrationNo.Text = ds.Tables[0].Rows[0]["DDORegNo"].ToString();

            //Fill the Fields of TDS/TCS Returns
            txt_Address1.Text = ds.Tables[0].Rows[0]["AFlat"].ToString();
            txt_Address2.Text = ds.Tables[0].Rows[0]["APremises"].ToString();
            txt_Address3.Text = ds.Tables[0].Rows[0]["ARoad"].ToString();
            txt_Address4.Text = ds.Tables[0].Rows[0]["AArea"].ToString();
            txt_Address5.Text = ds.Tables[0].Rows[0]["ATown"].ToString();
            drp_State.SelectedValue = ds.Tables[0].Rows[0]["AState"].ToString();
            txt_PINCode.Text = ds.Tables[0].Rows[0]["APINCode"].ToString();
            txt_Address01.Text = ds.Tables[0].Rows[0]["PFlat"].ToString();
            txt_Address02.Text = ds.Tables[0].Rows[0]["PPremises"].ToString();
            txt_Address03.Text = ds.Tables[0].Rows[0]["PRoad"].ToString();
            txt_Address04.Text = ds.Tables[0].Rows[0]["PArea"].ToString();
            txt_Address05.Text = ds.Tables[0].Rows[0]["PTown"].ToString();
            drp_State1.SelectedValue = ds.Tables[0].Rows[0]["PState"].ToString();
            txt_PINCode1.Text = ds.Tables[0].Rows[0]["PPINCode"].ToString();
            txt_BranchorDivision.Text = ds.Tables[0].Rows[0]["Branch"].ToString();
            txt_STDCode.Text = ds.Tables[0].Rows[0]["ASTDCode"].ToString();
            txt_Telephone.Text = ds.Tables[0].Rows[0]["APhone"].ToString();
            txt_Email.Text = ds.Tables[0].Rows[0]["AEmail"].ToString();
            txt_STDCode1.Text = ds.Tables[0].Rows[0]["PSTDCode"].ToString();
            txt_Telephone1.Text = ds.Tables[0].Rows[0]["PPhone"].ToString();
            txt_Email1.Text = ds.Tables[0].Rows[0]["PEmail"].ToString();
            txt_MobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();

            //Fill AIR Return Fields
            //txt_FatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
            //txt_FlatNo.Text = ds.Tables[0].Rows[0]["Flat"].ToString();
            //txt_HouseorPremisesNo.Text = ds.Tables[0].Rows[0]["House"].ToString();
            //txt_FloorNo.Text = ds.Tables[0].Rows[0]["Floor"].ToString();
            //txt_BuildingName.Text = ds.Tables[0].Rows[0]["Building"].ToString();
            //txt_BlockorSector.Text = ds.Tables[0].Rows[0]["Block"].ToString();
            //txt_RoadorStreet.Text = ds.Tables[0].Rows[0]["Road"].ToString();

            //txt_LocalityorColony.Text = ds.Tables[0].Rows[0]["Locality"].ToString();
            //txt_City.Text = ds.Tables[0].Rows[0]["City"].ToString();
            //drp_State2.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
            //txt_PINCode2.Text = ds.Tables[0].Rows[0]["PINCode"].ToString();
            //drp_District.SelectedValue = ds.Tables[0].Rows[0]["District"].ToString();
            //drp_MediumofReturn.SelectedValue = ds.Tables[0].Rows[0]["Medium"].ToString();
            //drp_JurisdictionalName.SelectedValue = ds.Tables[0].Rows[0]["CIT"].ToString();


        }

    }
    //public void CheckExistence()
    //{

    //        lbl_Message.Text = "Records does not exit.Do you want to add new record";
    //        ModalPopupExtender1.Show();
    //        txt_PANNumber.Focus();

    //        FlagForExistence = "F";




    //}

    public void Fill_Screen_By_Search_Correction(int MasterID)
    {

    }



    protected void txt_PANNumber_TextChanged1(object sender, EventArgs e)
    {
        //FillScreenBYSearch("PAN", txt_PANNumber.Text);
    }



    //protected void txt_AssesseName_TextChanged(object sender, EventArgs e)
    //{
    //    FillScreenBYSearch("AName", txt_AssesseName.Text);

    //}
    protected void btn_Copy_Click(object sender, EventArgs e)
    {
        CopyFields();
    }
    public void CopyFields()
    {
        txt_Address01.Text = txt_Address1.Text;
        txt_Address02.Text = txt_Address2.Text;
        txt_Address03.Text = txt_Address3.Text;
        txt_Address04.Text = txt_Address4.Text;
        txt_Address05.Text = txt_Address5.Text;
        drp_State1.SelectedValue = drp_State.SelectedValue;
        txt_PINCode1.Text = txt_PINCode.Text;
        txt_STDCode1.Text = txt_STDCode.Text;
        txt_Telephone1.Text = txt_Telephone.Text;
        txt_Email1.Text = txt_Email.Text;
    }

    public void RefreshControls()
    {
        foreach (Control controls in Form.Controls)
        {
            if (controls is TextBox)
            {
                TextBox txt = (TextBox)controls;
                txt.Text = "";
            }
            if (controls is DropDownList)
            {
                DropDownList drp = (DropDownList)controls;
                drp.SelectedIndex = 0;
            }
            drp_ReturnType.SelectedIndex = 1;

        }
        foreach (Control controls in vw_TAN1.Controls)
        {
            if (controls is TextBox)
            {
                TextBox txt = (TextBox)controls;
                txt.Text = "";
            }
            if (controls is DropDownList)
            {
                if (controls.ID != "drp_Designation")
                {
                    DropDownList drp = (DropDownList)controls;
                    drp.SelectedIndex = 0;
                }
            }

        }
        foreach (Control controls in vw_TAN2.Controls)
        {
            if (controls is TextBox)
            {
                TextBox txt = (TextBox)controls;
                txt.Text = "";
            }
            if (controls is DropDownList)
            {
                DropDownList drp = (DropDownList)controls;
                drp.SelectedIndex = 0;
            }

        }
    }
    protected void btn_New_Click(object sender, EventArgs e)
    {
        RefreshControls();
        if (drp_DeductorType1.SelectedItem.ToString() == "Select")
        {
            drp_StateName.Enabled = true;
            drp_MinistryName.Enabled = true;

            txt_PAOCode.Enabled = true;
            txt_DDOCode.Enabled = true;
            txt_PAORegistrationNo.Enabled = true;
            txt_DDORegistrationNo.Enabled = true;
            drp_StateName.Attributes.Remove("style");

            drp_MinistryName.Attributes.Remove("style");
            txt_PAOCode.Attributes.Remove("style");
            txt_DDOCode.Attributes.Remove("style");
            txt_PAORegistrationNo.Attributes.Remove("style");
            txt_DDORegistrationNo.Attributes.Remove("style");

        }
        txt_Designation.Visible = false;
        btn_AddDesignation.Visible = false;
        //drp_Designation.Visible = true;


        //change
        txt_TANNumber.Text = "";
        txt_PANNumber.Text = "";
        txt_AssesseName.Text = "";
        txt_PersonResponsible.Text = "";
        txt_PANofResPer.Text = "";
        drp_DeductorType1.SelectedIndex = 0;
        //drp_Designation.SelectedIndex = 0;
        drp_StateName.SelectedIndex = 0;
        txt_TANNumber.Focus();
        //Added by Mudit on 06/04/2015
        txtDesignation.Text = "";
    }
    protected void btn_ok_Click(object sender, EventArgs e)
    {

        if (FlagSave == "S" || FlagRefresh == "R")
        {

            foreach (Control controls in Form.Controls)
            {
                if (controls is TextBox)
                {
                    TextBox txt = (TextBox)controls;
                    txt.Text = "";
                }
                if (controls is DropDownList)
                {
                    DropDownList drp = (DropDownList)controls;
                    drp.SelectedIndex = 0;
                }

            }
            foreach (Control controls in vw_TAN1.Controls)
            {
                if (controls is TextBox)
                {
                    TextBox txt = (TextBox)controls;
                    txt.Text = "";
                }
                if (controls is DropDownList)
                {
                    DropDownList drp = (DropDownList)controls;
                    drp.SelectedIndex = 0;
                }

            }
            foreach (Control controls in vw_TAN2.Controls)
            {
                if (controls is TextBox)
                {
                    TextBox txt = (TextBox)controls;
                    txt.Text = "";
                }
                if (controls is DropDownList)
                {
                    DropDownList drp = (DropDownList)controls;
                    drp.SelectedIndex = 0;
                }

            }
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        FlagDelete = "F";
    }
    protected void btn_Delete_Click(object sender, EventArgs e)
    {

        //msg_Delete.Confirm("Are you sure you want to delete the record. The deleted data cannot be recovered.");




    }





    protected void msg_Delete_GetMessageBoxResponse(object sender, Utilities.MessageBox.MessageBoxEventHandler e)
    {
        if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Ok)
        {
            objtbl_TANMaster.TAN = txt_TANNumber.Text;
            objtbl_TANMaster.Page_ID = "1";
            objtbl_TANMaster.Page_SubModule_ID = "1";

            int success = objBltbl_TANMaster.DeleteTANEntry(objtbl_TANMaster);
            if (success == 1)
            {

                objtbl_TANMaster.TAN = "-999999999";
                objBltbl_TANMaster.DeleteTANEntry(objtbl_TANMaster);
                RefreshControls();
                //MessageBox.Show("TAN Deleted Successfully");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('TAN Deleted Successfully!');", true);

            }
            txt_TANNumber.Focus();
        }
        else if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Cancel)
        {
            txt_TANNumber.Focus();
        }
    }
    protected void btn_AddDesignation_Click(object sender, EventArgs e)
    {
        //Clear List
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";



        //drp_Designation.Visible = false;
        txt_Designation.Visible = true;
        btn_AddDesignation.Text = "Save";
        int success = 0;
        if (txt_Designation.Text != "")
        {
            //Create Parameters to Pass.
            objtbl_TANMaster.PDesig = txt_Designation.Text;
            objtbl_TANMaster.Page_ID = "1";
            objtbl_TANMaster.Page_SubModule_ID = "1";
            //Call the Function to Insert New Designation and pass the parameter to it.
            success = objBltbl_TANMaster.InsertDesignation(objtbl_TANMaster);
        }
        if (success == 1)
        {
            objtbl_TANMaster.PDesig = "-999999999";
            objBltbl_TANMaster.InsertDesignation(objtbl_TANMaster);
            //drp_Designation.Visible = true;
            txt_Designation.Visible = false;
            btn_AddDesignation.Text = "Add Designation";
            //Fill DesignationCombo
            //drp_Designation.DataSource = objBltbl_TANMaster.GetDesignation();
            //drp_Designation.DataValueField = "designation";
            //drp_Designation.DataTextField = "designation";
            //drp_Designation.DataBind();
            //drp_Designation.Items.Insert(0, new ListItem("Select", ""));

        }

    }
    protected void btn_CancelDesig_Click(object sender, EventArgs e)
    {
        txt_Designation.Visible = false;

        //drp_Designation.Visible = true;
        btn_AddDesignation.Text = "Add Designation";
    }


    #region TAN MasterPageMethods

    [System.Web.Services.WebMethod()]
    public static string GetMaxLenghtTelephone(string STDCodeLenght)
    {
        int lenght = Convert.ToInt32(STDCodeLenght);
        string MaxLenght = string.Empty;
        if (lenght == 0)
        {
            MaxLenght = "10";

        }
        else if (lenght == 3)
        {
            MaxLenght = "8";
        }
        else if (lenght == 4 || lenght == 5)
        {
            MaxLenght = "7";
        }
        return MaxLenght;

    }


    [System.Web.Services.WebMethod()]
    public static string GetMaxLenghtTelephone1(string STDCodeLenght1)
    {
        int lenght = Convert.ToInt32(STDCodeLenght1);
        string MaxLenght = string.Empty;
        if (lenght == 0)
        {
            MaxLenght = "10";

        }
        else if (lenght == 3)
        {
            MaxLenght = "8";
        }
        else if (lenght == 4 || lenght == 5)
        {
            MaxLenght = "7";
        }
        return MaxLenght;

    }


    [System.Web.Services.WebMethod()]
    public static bool ValidateTAN(string TANNumber, string AName)
    {
        string FlagValid = string.Empty;
        bool ISTanValid = false;
        bool firstfour = false;
        bool nextFive = false;
        bool lastchar = false;

        if (TANNumber != "" && TANNumber.Length == 10)
        {
            string FirstFour = TANNumber.Substring(0, 4).ToString();
            Regex r = new Regex(@"^[a-zA-Z]*$");
            if (r.IsMatch(FirstFour))
            {
                firstfour = true;
            }
            string NextFive = TANNumber.Substring(4, 5).ToString();
            Regex n = new Regex(@"^[0-9]*$");
            if (n.IsMatch(NextFive))
            {
                nextFive = true;

            }
            string LastChar = TANNumber.Substring(9, 1).ToString();
            if (r.IsMatch(LastChar))
            {
                lastchar = true;
            }
            if (firstfour && nextFive && lastchar)
            {
                ISTanValid = true;
            }
            else
            {
                ISTanValid = false;
            }
        }
        else
        {
            ISTanValid = false;
        }

        return ISTanValid;

    }
    [System.Web.Services.WebMethod()]
    public static String[] FillByTAN(string FieldName, string FieldValue)
    {

        string strConnName, strConnectionString, strConnectionString_Admin;
        strConnName = ConfigurationManager.AppSettings["DatabaseEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DatabaseEngine2"].ToString()].ConnectionString;

        DataSet ds = new DataSet();
        Bltbl_TANMaster objBltbl_TANMaster = new Bltbl_TANMaster(strConnectionString, strConnName, strConnectionString_Admin);
        tbl_TANMaster objtbl_TANMaster = new tbl_TANMaster();


        //Create Parameters....
        objtbl_TANMaster.FieldName = FieldName.ToString();
        objtbl_TANMaster.FieldValue = FieldValue.ToString();
        objtbl_TANMaster.Regular_Correction = "Regular";
        objtbl_TANMaster.Count = 5;
        //ds = objBltbl_TANMaster.GetTANListFromTANMaster(objtbl_TANMaster);
        ds = objBltbl_TANMaster.FillRecords(objtbl_TANMaster);
        int count = Convert.ToInt32(ds.Tables[0].Columns.Count);
        String[] arrTAN = new String[count];
        if (ds.Tables[0].Rows.Count != 0)
        {

            int i = 0;
            foreach (var items in ds.Tables[0].Rows[0].ItemArray)
            {

                arrTAN[i] = items.ToString();
                i++;
            }
        }
        else
        {
            arrTAN[0] = "NoRecords";
        }

        return arrTAN;
    }
    [System.Web.Services.WebMethod()]
    public static bool ValiadtePAN(string PANNumber)
    {
        PANNumber = PANNumber.ToUpper();
        bool ISValidPAN = false;
        bool firstfive = false;
        bool nextFour = false;
        bool lastchar = false;
        string Firstfive = string.Empty;
        string NextFour = string.Empty;
        string LastChar = string.Empty;
        if (PANNumber.Length == 10)
        {
            Firstfive = PANNumber.Substring(0, 5).ToString();
            Regex r = new Regex(@"^[a-zA-Z]*$");
            if (r.IsMatch(Firstfive))
            {
                firstfive = true;
            }
            NextFour = PANNumber.Substring(5, 4).ToString();
            Regex n = new Regex(@"^[0-9]*$");
            if (n.IsMatch(NextFour))
            {
                nextFour = true;

            }
            LastChar = PANNumber.Substring(9, 1).ToString();
            if (r.IsMatch(LastChar))
            {
                lastchar = true;
            }
            if (firstfive && nextFour && lastchar || PANNumber == "PANNOTREQD")
            {
                ISValidPAN = true;
            }
            else
            {

                ISValidPAN = false;
            }
        }
        else
        {
            ISValidPAN = false;
        }
        return ISValidPAN;
    }


    [System.Web.Services.WebMethod()]
    public static String[] FillByAssess(string FieldName, string FieldValue)
    {
        string strConnName, strConnectionString, strConnectionString_Admin;
        strConnName = ConfigurationManager.AppSettings["DatabaseEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DatabaseEngine"].ToString()].ConnectionString;

        DataSet ds = new DataSet();
        Bltbl_TANMaster objBltbl_TANMaster = new Bltbl_TANMaster(strConnectionString, strConnName, strConnectionString_Admin);
        tbl_TANMaster objtbl_TANMaster = new tbl_TANMaster();


        //Create Parameters....
        objtbl_TANMaster.FieldName = FieldName.ToString();
        objtbl_TANMaster.FieldValue = FieldValue.ToString();
        objtbl_TANMaster.Regular_Correction = "Regular";
        objtbl_TANMaster.Count = 5;
        //ds = objBltbl_TANMaster.GetTANListFromTANMaster(objtbl_TANMaster);
        ds.Clear();
        ds = objBltbl_TANMaster.FillRecords(objtbl_TANMaster);
        int count = Convert.ToInt32(ds.Tables[0].Columns.Count);
        String[] arrAName = new String[count];
        int i = 0;
        if (ds.Tables[0].Rows.Count != 0)
        {
            foreach (var items in ds.Tables[0].Rows[0].ItemArray)
            {

                arrAName[i] = items.ToString();
                i++;
            }
        }
        else
        {
            arrAName[0] = "NoRecords";
        }

        return arrAName;
    }

    [System.Web.Services.WebMethod()]
    public static bool CheckTANExist(string TAN)
    {
        string strConnName, strConnectionString, strConnectionString_Admin;

        strConnName = ConfigurationManager.AppSettings["DatabaseEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DatabaseEngine2"].ToString()].ConnectionString;

        Bltbl_TANMaster objBltbl_TANMaster = new Bltbl_TANMaster(strConnectionString, strConnName, strConnectionString_Admin);
        tbl_TANMaster objtbl_TANMaster = new tbl_TANMaster();
        DataTable dt = new DataTable();
        objtbl_TANMaster.TAN = TAN;
        bool ISExist = false;
        dt = objBltbl_TANMaster.GetTANByTANNumber(objtbl_TANMaster);
        if (dt.Rows.Count != 0)
        {
            ISExist = true;

        }
        else
        {
            ISExist = false;

        }
        return ISExist;
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {


        string strConnName, strConnectionString;
        strConnName = ConfigurationManager.AppSettings["DatabaseEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        TANMaster objTANMaster = new TANMaster(strConnectionString, strConnName);
        DataSet ds = new DataSet();
        string FieldName = "TAN";
        ds = objTANMaster.GetTANList(FieldName, prefixText, count);

        int countdata = ds.Tables[0].Rows.Count;
        List<string> Completionset = new List<string>();
        if (ds.Tables[0].Rows.Count == 0)
        {


        }
        else
        {
            for (int i = 0; i < countdata; i++)
            {
                Completionset.Add(ds.Tables[0].Rows[i]["TAN"].ToString());

            }
        }
        return Completionset.ToArray();
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList3(string prefixText, int count, string contextKey)
    {
        string strConnName, strConnectionString;
        strConnName = ConfigurationManager.AppSettings["DatabaseEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        TANMaster objTANMaster = new TANMaster(strConnectionString, strConnName);
        DataSet ds = new DataSet();
        string FieldName = "AName";
        ds = objTANMaster.GetTANList(FieldName, prefixText, count);
        List<string> Completionset1 = new List<string>();


        int countdata = ds.Tables[0].Rows.Count;


        for (int i = 0; i < countdata; i++)
        {
            Completionset1.Add(ds.Tables[0].Rows[i]["AName"].ToString());

        }



        return Completionset1.ToArray();
    }


    #endregion





    protected void btn_Exit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");//maindiv.Attributes.Add("style", "display:none");
    }
    protected void txt_TANNumber_TextChanged(object sender, EventArgs e)
    {
        FieldsByDeductorType();
        txt_PANNumber.Focus();
    }

    protected void btn_backtoChallan_Click(object sender, EventArgs e)
    {
        string TAN = Request.QueryString["TAN"].ToString();
        ViewState["TAN"] = TAN.ToString();
        string FY = Request.QueryString["FY"].ToString();
        ViewState["FY"] = FY.ToString();
        string Quarter = Request.QueryString["Quarter"].ToString();
        ViewState["Quarter"] = Quarter.ToString();
        string FormNo = Request.QueryString["FormNo"].ToString();
        ViewState["FormNo"] = FormNo;
        string AY = Request.QueryString["AY"].ToString();

        string AName = Request.QueryString["AName"].ToString();
        string PAN = Request.QueryString["PAN"].ToString();

        string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string Host = HttpContext.Current.Request.Url.DnsSafeHost.ToString();

        string Project_Name = "Admin";

        objtbl_PathManagement.Host = Host;
        objtbl_PathManagement.Path_Name = Project_Name;
        string LivePath = string.Empty;
        DataTable dt_Path = objBltbl_PathManagement.Get_Path(objtbl_PathManagement);
        if (dt_Path.Rows.Count != 0)
        {
            LivePath = dt_Path.Rows[0]["Path"].ToString();
        }
        //string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        Response.Redirect(@"" + LivePath + "/Main.aspx?menu=Correction&type=Challan&TAN=" + TAN + "&FY=" + FY + "&Quarter=" + Quarter + "&FormNo=" + FormNo + "&AY=" + AY + "&AName=" + AName + "&PAN=" + PAN + "&ProjectName=TDS");

        //if (path == "http://192.168.1.129:85")
        //{
        //    Response.Redirect(@"http://192.168.1.129:83/Main.aspx?menu=Correction&type=Challan&TAN=" + TAN + "&FY=" + FY + "&Quarter=" + Quarter + "&FormNo=" + FormNo + "&AY=" + AY + "&AName=" + AName + "&PAN=" + PAN + "&ProjectName=TDS");
        //}
        //else if (path == "http://59.90.184.247:85")
        //{
        //    Response.Redirect(@"http://59.90.184.247:83/Main.aspx?menu=Correction&type=Challan&TAN=" + TAN + "&FY=" + FY + "&Quarter=" + Quarter + "&FormNo=" + FormNo + "&AY=" + AY + "&AName=" + AName + "&PAN=" + PAN + "&ProjectName=TDS");
        //}


    }
    protected void msg_TanCorrection1_GetMessageBoxResponse(object sender, Utilities.MessageBox.MessageBoxEventHandler e)
    {
        //Code if Yes is Clicked following Code Will Fire
        if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Ok)
        {

            //Pop_NewTANNo.Show();
            btn_Delete.Enabled = true;
            btn_New.Enabled = true;

        }
        else if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Cancel)
        {
            txt_TANNumber.Enabled = false;
            txt_TANNumber.Text = Request.QueryString["TAN"].ToString();

            FillScreenBYSearch("TAN", txt_TANNumber.Text);
            txt_TANNumber.Attributes.Add("style", "background-color:#E3E3E3");
            FlagC1 = "Yes";
            btn_Delete.Enabled = false;
            btn_New.Enabled = false;

        }
    }
    //Event to Submit New TAN in Correction Case
    protected void btn_SubmitNewTAN_Click(object sender, EventArgs e)
    {
        //Create Parameter
        objtbl_BatchHeader_Correction.Tan_of_Employer = txt_NewTanNo.Text;
        ViewState["NewTAN"] = txt_NewTanNo.Text;
        //Call the Function to Check the Existence
        bool isExist = objBltbl_BatchHeader_Correction.CheckTanMasterExistence(objtbl_BatchHeader_Correction);
        if (isExist)
        {
            //msg_TanCorrection4.Confirm("On saving new data all the previous data from Quarter will be lost");
        }
        else
        {
            //msg_TanCorrection2.Confirm("Do you want to add TAN to database");
        }

    }
    protected void msg_TanCorrection2_GetMessageBoxResponse(object sender, Utilities.MessageBox.MessageBoxEventHandler e)
    {
        if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Ok)
        {
            //Show the New TAN Submitted
            txt_TANNumber.Text = ViewState["NewTAN"].ToString();
            string Old_TAN = Request.QueryString["TAN"].ToString();
            //Show the Rest of the Data of the Previous TAN
            FillScreenBYSearch("TAN", Old_TAN);

            //Update Y in the Batch Header and Create the Y File;
            if (FlagSuccess == "Y")
            {
                //msg_TanCorrection3.Confirm("Do you want data of previous return to be saved on New TAN");
            }
        }
        else if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Cancel)
        {

            //Get the ID From Master_Table
            objtbl_BatchHeader_Correction.Tan_of_Employer = ViewState["TAN"].ToString();
            objtbl_BatchHeader_Correction.Quarter = ViewState["Quarter"].ToString();
            objtbl_BatchHeader_Correction.Financial_Year = Convert.ToInt32(ViewState["FY"]);
            objtbl_BatchHeader_Correction.FormNo = ViewState["FormNo"].ToString();
            objtbl_BatchHeader_Correction.Regular_Correction = "Correction";
            int ID = objBltbl_BatchHeader_Correction.GetIDFromMaster(objtbl_BatchHeader_Correction);
            //Create Parameter For FH
            objtbl_FileHeader.ID = ID;
            //Mark Y in FH
            int successFH = objBltbl_FileHeader.UpdateRecords_Correction(objtbl_FileHeader);
            //Create Parameter For BH
            objtbl_BatchHeader_Correction.ID = ID;
            //Mark Y in BH
            int successBH = objBltbl_BatchHeader_Correction.MarkCorrection(objtbl_BatchHeader_Correction);




        }
    }
    public int SaveEntryBH_Correction_C1()
    {
        //Get the ID From Master_Table
        objtbl_BatchHeader_Correction.Tan_of_Employer = Request.QueryString["TAN"].ToString();
        ViewState["TAN_Corr"] = objtbl_BatchHeader_Correction.Tan_of_Employer.ToString();
        objtbl_BatchHeader_Correction.Quarter = Request.QueryString["Quarter"].ToString();
        ViewState["Quarter_Corr"] = objtbl_BatchHeader_Correction.Quarter.ToString();
        objtbl_BatchHeader_Correction.Financial_Year = Convert.ToInt32(Request.QueryString["FY"].ToString());
        ViewState["FY_Corr"] = objtbl_BatchHeader_Correction.Financial_Year.ToString();
        objtbl_BatchHeader_Correction.Form_Number = Request.QueryString["FormNo"].ToString();
        ViewState["FormNumber_Corr"] = objtbl_BatchHeader_Correction.Form_Number.ToString();
        objtbl_BatchHeader_Correction.Regular_Correction = "Correction";

        int ID = objBltbl_BatchHeader_Correction.GetIDFromMaster(objtbl_BatchHeader_Correction);
        ViewState["MasterID"] = ID;

        //Create Parameter For Batch_HeaderCorrection
        objtbl_BatchHeader_Correction.ID = ID;
        objtbl_BatchHeader_Correction.Count_of_Challan_Transfer_Voucher_Records = 0;
        objtbl_BatchHeader_Correction.Transaction_type = "";

        objtbl_BatchHeader_Correction.PAN_Of_deductor_Employer = txt_PANNumber.Text;
        ViewState["PAN_Corr"] = txt_PANNumber.Text;

        objtbl_BatchHeader_Correction.Name_Of_Employer = txt_AssesseName.Text;
        ViewState["AName_Corr"] = txt_AssesseName.Text;

        objtbl_BatchHeader_Correction.Employer_Branch_Division = txt_BranchorDivision.Text;
        ViewState["BranchDivision_Corr"] = txt_BranchorDivision.Text;

        objtbl_BatchHeader_Correction.Employer_Address1 = txt_Address1.Text;
        ViewState["A_Address1_Corr"] = txt_Address1.Text;

        objtbl_BatchHeader_Correction.Employer_Address2 = txt_Address2.Text;
        ViewState["A_Address2_Corr"] = txt_Address2.Text;

        objtbl_BatchHeader_Correction.Employer_Address3 = txt_Address3.Text;
        ViewState["A_Address3_Corr"] = txt_Address3.Text;

        objtbl_BatchHeader_Correction.Employer_Address4 = txt_Address4.Text;
        ViewState["A_Address4_Corr"] = txt_Address4.Text;

        objtbl_BatchHeader_Correction.Employer_Address5 = txt_Address5.Text;
        ViewState["A_Address5_Corr"] = txt_Address5.Text;

        objtbl_BatchHeader_Correction.Employer_State = Convert.ToInt32(drp_State.SelectedValue);
        ViewState["A_State_Corr"] = Convert.ToInt32(drp_State.SelectedValue);

        objtbl_BatchHeader_Correction.Employer_PIN = Convert.ToInt32(txt_PINCode.Text);
        ViewState["A_PINCode_Corr"] = Convert.ToInt32(txt_PINCode.Text);


        objtbl_BatchHeader_Correction.Employer_Deductor_EmailID = txt_Email.Text;
        ViewState["A_Email_Corr"] = txt_Email.Text;

        objtbl_BatchHeader_Correction.Employer_Deductors_STD_Code = Convert.ToInt32(txt_STDCode.Text);
        ViewState["A_STDCode_Corr"] = Convert.ToInt32(txt_STDCode.Text);

        objtbl_BatchHeader_Correction.Employer_Deductors_TelephoneNo = Convert.ToInt32(txt_Telephone.Text);
        ViewState["A_Telephone_Corr"] = Convert.ToInt32(txt_Telephone.Text);

        objtbl_BatchHeader_Correction.Deductor_Type = drp_DeductorType1.SelectedValue.ToString();
        ViewState["Deductor_Type"] = drp_DeductorType1.SelectedValue.ToString();

        objtbl_BatchHeader_Correction.Name_of_Person = txt_PersonResponsible.Text;

        ViewState["P_Name"] = txt_PersonResponsible.Text;

        objtbl_BatchHeader_Correction.Designation_of_Person = txtDesignation.Text;//drp_Designation.SelectedValue.ToString();
        ViewState["P_Desig"] = txtDesignation.Text;//drp_Designation.SelectedValue.ToString();

        objtbl_BatchHeader_Correction.Responsible_Persons_Address1 = txt_Address01.Text;
        ViewState["P_Address1"] = txt_Address01.Text;

        objtbl_BatchHeader_Correction.Responsible_Persons_Address2 = txt_Address02.Text;
        ViewState["P_Address2"] = txt_Address02.Text;

        objtbl_BatchHeader_Correction.Responsible_Persons_Address3 = txt_Address03.Text;
        ViewState["P_Address3"] = txt_Address03.Text;

        objtbl_BatchHeader_Correction.Responsible_Persons_Address4 = txt_Address04.Text;
        ViewState["P_Address4"] = txt_Address04.Text;

        objtbl_BatchHeader_Correction.Responsible_Persons_Address5 = txt_Address05.Text;
        ViewState["P_Address5"] = txt_Address05.Text;

        objtbl_BatchHeader_Correction.Responsible_Persons_State = Convert.ToInt32(drp_State1.SelectedValue);
        ViewState["P_State"] = Convert.ToInt32(drp_State1.SelectedValue);

        objtbl_BatchHeader_Correction.Responsible_Persons_PIN = Convert.ToInt32(txt_PINCode1.Text);
        ViewState["P_PIN"] = Convert.ToInt32(txt_PINCode1.Text);

        objtbl_BatchHeader_Correction.Responsible_Persons_EmailID_1 = txt_Email1.Text;
        ViewState["P_Email"] = txt_Email1.Text;

        objtbl_BatchHeader_Correction.Mobile_Number = txt_MobileNo.Text;
        ViewState["Mobile_Number"] = txt_MobileNo.Text;

        objtbl_BatchHeader_Correction.Responsible_Persons_STDCode = Convert.ToInt32(txt_STDCode1.Text);
        ViewState["P_STD_Code"] = Convert.ToInt32(txt_STDCode1.Text);

        objtbl_BatchHeader_Correction.Responsible_Persons_TelPhoneNo = Convert.ToInt32(txt_Telephone1.Text);
        ViewState["P_Telephone"] = Convert.ToInt32(txt_Telephone1.Text);

        objtbl_BatchHeader_Correction.Batch_Total_DepositeAMT = 0;

        objtbl_BatchHeader_Correction.PAO_Code = txt_PAOCode.Text;
        ViewState["PAO_Code"] = txt_PAOCode.Text;

        objtbl_BatchHeader_Correction.DDO_Code = txt_DDOCode.Text;
        ViewState["DDO_Code"] = txt_DDOCode.Text;

        objtbl_BatchHeader_Correction.Ministry_Name = drp_MinistryName.SelectedValue.ToString();
        ViewState["Ministry_Name"] = drp_MinistryName.SelectedValue.ToString();

        if (txt_PAORegistrationNo.Text == "")
        {
            objtbl_BatchHeader_Correction.PAO_Register_No = 0;

        }
        else
        {
            objtbl_BatchHeader_Correction.PAO_Register_No = Convert.ToInt32(txt_PAORegistrationNo.Text);
        }
        ViewState["PAO_RegNo"] = objtbl_BatchHeader_Correction.PAO_Register_No;
        objtbl_BatchHeader_Correction.DDO_RegistrationNo = txt_DDORegistrationNo.Text;
        ViewState["DDO_RegistrationNo"] = txt_DDORegistrationNo.Text;
        objtbl_BatchHeader_Correction.C1 = "Y";
        objtbl_BatchHeader_Correction.C2 = "";
        objtbl_BatchHeader_Correction.C3 = "";
        objtbl_BatchHeader_Correction.C4 = "";
        objtbl_BatchHeader_Correction.C5 = "";
        objtbl_BatchHeader_Correction.C9 = "";
        objtbl_BatchHeader_Correction.Y = "";
        objtbl_BatchHeader_Correction.Decision = "U";
        objtbl_BatchHeader_Correction.Page_ID = "1";
        objtbl_BatchHeader_Correction.Page_SubModule_ID = "1";
        int sucess = objBltbl_BatchHeader_Correction.UpdateRecords_Correction(objtbl_BatchHeader_Correction);
        if (sucess == 1)
        {
            objtbl_BatchHeader_Correction.Count_of_Challan_Transfer_Voucher_Records = -999999999;
            objBltbl_BatchHeader_Correction.UpdateRecords_Correction(objtbl_BatchHeader_Correction);
            // Mark the Correction the File Header
            objtbl_FileHeader_Correction.C1 = "Y";
            objtbl_FileHeader_Correction.C2 = "";
            objtbl_FileHeader_Correction.C3 = "";
            objtbl_FileHeader_Correction.C4 = "";
            objtbl_FileHeader_Correction.C5 = "";
            objtbl_FileHeader_Correction.C9 = "";
            objtbl_FileHeader_Correction.ID = ID;
            objBltbl_FileHeader_Correction.Mark_Correction_Type(objtbl_FileHeader_Correction);
        }



        return sucess;
    }
    protected void msg_TanCorrection3_GetMessageBoxResponse(object sender, Utilities.MessageBox.MessageBoxEventHandler e)
    {
        if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Ok)
        {
            //Create Master Table With New TAN No


        }
        else if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Cancel)
        {
        }
    }

    //Function to Save the AIRMaster Entry
    public void SaveAIRRecords()
    {
        //Create Parameters
        objtbl_AIRMaster.TAN = txt_TANNumber.Text.ToUpper();
        objtbl_AIRMaster.PAN = txt_PANNumber.Text.ToUpper();
        objtbl_AIRMaster.Status = drp_DeductorType1.SelectedValue.ToString();
        objtbl_AIRMaster.AName = txt_AssesseName.Text;
        objtbl_AIRMaster.PName = txt_PersonResponsible.Text;
        objtbl_AIRMaster.PDesig = txtDesignation.Text;//drp_Designation.SelectedValue.ToString() ;
        objtbl_AIRMaster.FatherName = txt_FatherName.Text;
        objtbl_AIRMaster.Flat = txt_FlatNo.Text;
        objtbl_AIRMaster.House = txt_HouseorPremisesNo.Text;
        objtbl_AIRMaster.Floor = txt_FloorNo.Text;
        objtbl_AIRMaster.Building = txt_BuildingName.Text;
        objtbl_AIRMaster.Block = txt_BlockorSector.Text;
        objtbl_AIRMaster.Road = txt_RoadorStreet.Text;
        objtbl_AIRMaster.Locality = txt_LocalityorColony.Text;
        objtbl_AIRMaster.City = txt_City.Text;
        objtbl_AIRMaster.State = Convert.ToInt32(drp_State2.SelectedValue);
        objtbl_AIRMaster.PINCode = Convert.ToInt32(txt_PINCode2.Text);
        objtbl_AIRMaster.CIT = drp_JurisdictionalName.SelectedValue.ToString();
        objtbl_AIRMaster.District = Convert.ToInt32(drp_District.SelectedValue);
        objtbl_AIRMaster.Medium = drp_MediumofReturn.SelectedValue.ToString();
        //objtbl_AIRMaster.FileNum="";
        objtbl_AIRMaster.StateCode = drp_StateName.SelectedValue.ToString();
        objtbl_AIRMaster.PAOCode = txt_PAOCode.Text;
        objtbl_AIRMaster.DDOCode = txt_DDOCode.Text;
        objtbl_AIRMaster.PAORegNo = txt_PAORegistrationNo.Text;
        objtbl_AIRMaster.DDORegNo = txt_DDORegistrationNo.Text;
        objtbl_AIRMaster.MinistryCode = "";
        objtbl_AIRMaster.MinistryName = drp_MinistryName.SelectedValue.ToString();
        objtbl_AIRMaster.Page_ID = "1";
        objtbl_AIRMaster.Page_SubModule_ID = "1";
        //Call the Insert Function and Save The Record
        int sucess = objBltbl_AIRMaster.InsertRecords(objtbl_AIRMaster);
        objtbl_AIRMaster.TAN = "-999999999";
        objBltbl_AIRMaster.InsertRecords(objtbl_AIRMaster);
    }

    //Function to Update The AIR Master Entry
    public void UpdateAIRMaster()
    {

        //Create Parameters
        objtbl_AIRMaster.TAN = txt_TANNumber.Text.ToUpper();
        objtbl_AIRMaster.PAN = txt_PANNumber.Text.ToUpper();
        objtbl_AIRMaster.Status = drp_DeductorType1.SelectedValue.ToString();
        objtbl_AIRMaster.AName = txt_AssesseName.Text;
        objtbl_AIRMaster.PName = txt_PersonResponsible.Text;
        objtbl_AIRMaster.PDesig = txtDesignation.Text;//drp_Designation.SelectedValue.ToString();
        objtbl_AIRMaster.FatherName = txt_FatherName.Text;
        objtbl_AIRMaster.Flat = txt_FlatNo.Text;
        objtbl_AIRMaster.House = txt_HouseorPremisesNo.Text;
        objtbl_AIRMaster.Floor = txt_FloorNo.Text;
        objtbl_AIRMaster.Building = txt_BuildingName.Text;
        objtbl_AIRMaster.Block = txt_BlockorSector.Text;
        objtbl_AIRMaster.Road = txt_RoadorStreet.Text;
        objtbl_AIRMaster.Locality = txt_LocalityorColony.Text;
        objtbl_AIRMaster.City = txt_City.Text;
        objtbl_AIRMaster.State = Convert.ToInt32(drp_State2.SelectedValue);
        objtbl_AIRMaster.PINCode = Convert.ToInt32(txt_PINCode2.Text);
        objtbl_AIRMaster.CIT = drp_JurisdictionalName.SelectedValue.ToString();
        objtbl_AIRMaster.District = Convert.ToInt32(drp_District.SelectedValue);
        objtbl_AIRMaster.Medium = drp_MediumofReturn.SelectedValue.ToString();
        //objtbl_AIRMaster.FileNum = "";
        objtbl_AIRMaster.StateCode = drp_StateName.SelectedValue.ToString();
        objtbl_AIRMaster.PAOCode = txt_PAOCode.Text;
        objtbl_AIRMaster.DDOCode = txt_DDOCode.Text;
        objtbl_AIRMaster.PAORegNo = txt_PAORegistrationNo.Text;
        objtbl_AIRMaster.DDORegNo = txt_DDORegistrationNo.Text;
        objtbl_AIRMaster.MinistryCode = "";
        objtbl_AIRMaster.MinistryName = drp_MinistryName.SelectedValue.ToString();
        objtbl_AIRMaster.Page_ID = "1";
        objtbl_AIRMaster.Page_SubModule_ID = "1";
        //Call the Function to Update the AIR master Records
        int success = objBltbl_AIRMaster.UpdateRecords(objtbl_AIRMaster);
        objtbl_AIRMaster.TAN = "-999999999";
        objBltbl_AIRMaster.UpdateRecords(objtbl_AIRMaster);
    }

    //Event to select the District By State
    protected void drp_State2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int state = Convert.ToInt32(drp_State2.SelectedValue);
        //Create Parameters
        objtbl_AIRMaster.State = Convert.ToInt32(state);
        //Pass the Parameter to the Query
        dt = new DataTable();
        dt = objBltbl_AIRMaster.GetDistrictByState(objtbl_AIRMaster);
        //Bind District 

        drp_District.DataSource = dt;
        drp_District.DataValueField = "DistrictCode";
        drp_District.DataTextField = "DistrictName";
        drp_District.DataBind();
        drp_District.Items.Insert(0, new ListItem("Select", ""));

    }

    //Function To Fire AutoComplete
    public void Fire_AutoComplete(AutoCompleteExtender autocomplete, string Target_Control_ID, string Service_Path, string Service_Method)
    {
        autocomplete.TargetControlID = Target_Control_ID;
        autocomplete.ServicePath = Service_Path;
        autocomplete.ServiceMethod = Service_Method;
    }
    //Function To Get Error_Message
    [System.Web.Services.WebMethod()]
    public static string Fire_Error_Message(string PrefixText, string ContextKey)
    {
        //Create the Object of the Search List Service Method
        string result = string.Empty;
        //SearchList objlst = new SearchList();
        // string[] Message = objlst.Get_Error_List(ContextKey,PrefixText);
        //result = Message[0].ToString() + Message[1].ToString() + Message[2].ToString() + Message[3].ToString() + Message[4].ToString() + Message[5].ToString() + Message[6].ToString();
        return result;
    }

    //Function to get the Data From Batch Header and TAN Master and Compare them In Case OF Correction
    public bool Compare_TAN_BH_Correction(string TAN, int MasterID, string Regular_Correction)
    {
        //Get the Parameters
        bool Is_Compared = objBltbl_TANMaster.CompareTANData_Correction(TAN, MasterID, Regular_Correction);
        return Is_Compared;
    }



    //Event of Message Box Confirm Correction
    protected void msg_ConfirmCorrection_GetMessageBoxResponse(object sender, Utilities.MessageBox.MessageBoxEventHandler e)
    {
        if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Ok)
        {
            UpdateTANEntry_Corr();
        }
        else if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Cancel)
        {
        }

    }
    //Code Written By Mudit To Save Data of TAN MASTER according To Users
    public void SaveTANwithUser(string TAN)
    {
        try
        {
            int UserID = Convert.ToInt32(Session["User_ID"]);
            //string TAN = Session["TAN"].ToString();
            bllLogin objbllLogin = new bllLogin();
            objbllLogin.InSertTANWithUser(UserID, TAN);
        }
        catch (Exception ex)
        {

        }
    }
    protected void btndefault_Click(object sender, EventArgs e)
    {
       
    }
}
