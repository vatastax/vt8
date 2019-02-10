using System;
using System.Collections;
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
using BALVatasETDS.ChallanDetails;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using VatasInfosysLib;
using System.Collections.Generic;
using BALVatasETDS.DeducteeDetail;
using BALVatasETDS.SalaryDetails;
using BALVatasETDS.SalaryDetails_Correction;
using BALVatasETDS.Section_VI_A_Correction;
using BALVatasETDS._16A_Correction;
using BALVatasETDS.BatchHeader;
using BALVatasETDS.Form;
using BALVatasETDS._16A;
using BALVatasETDS.CompressAndDecompress_Page;
using BALVatasETDS.BSRCode;
using BALVatasETDS.TANMaster;
using BALVatasETDS.FileHeader;
using BALVatasETDS.Create_File_Correction;
using System.Threading;
////using CrystalDecisions.Shared;
////using CrystalDecisions.Shared;
//using CrystalDecisions.Shared;
using AjaxControlToolkit;
using BALVatasETDS.Section_VI_A;
using System.Data.OleDb;
using BALVatasETDS.File_Header_Correction;
using BALVatasETDS.ChallanDetails_Correction;



using controlgrid;
using System.Data.Odbc;
using BALVatasETDS.ChallanDetails_Correction;
using BALVatasETDS.BatchHeader_Correction;
using BALVatasETDS.DeducteeDetail_Correction;
using BALVatasETDS;
using BALVatasETDS.Create_File;
//using OfficeOpenXml;
//using OfficeOpenXml.Table;
using System.Text.RegularExpressions;
using BALVatasETDS.Interface_By_Role;
using DALVatasETDS;
using System.Data.Common;
using System.Data.SqlClient;

public partial class UserControls_ReceiptNo : System.Web.UI.UserControl
{
    #region Declaration
    public event EventHandler rdl_Receipt;
    public event EventHandler btnSubmit;
    public event EventHandler btnClose;

    // Challan Details Object.
    Bltbl_ChallanDetails objBltbl_ChallanDetails;
    tbl_ChallanDetails objtbl_ChallanDetails;

    //Deductee Details Object.
    Bltbl_DeducteeDetail objBltbl_DeducteeDetails;
    tbl_DeducteeDetail objtbl_DeducteeDetails;

    //Salary Details Object
    Bltbl_SalaryDetails objBltbl_SalaryDetails;
    tbl_SalaryDetails objtbl_SalaryDetails;

    //Form Object
    Bltbl_Form objBltbl_Form;
    tbl_Form objtbl_Form;

    //Batch_Header Object
    Bltbl_BatchHeader objBltbl_BatchHeader;
    tbl_BatchHeader objtbl_BatchHeader;

    //BSRCode Object
    Bltbl_BSRCode objBltbl_BSRCode;
    tbl_BSRCode objtbl_BSRCode;

    //Section VI A Object
    Bltbl_SectionVI_A objBltbl_SectionVI_A;
    tbl_SectionVI_A objtbl_SectionVI_A;

    //TanMaster Object
    Bltbl_TANMaster objBltbl_TANMaster;
    tbl_TANMaster objtbl_TANMaster;

    //File Header Object
    Bltbl_FileHeader objBltbl_FileHeader;
    tbl_FileHeader objtbl_FileHeader;

    ////Challan_Detail_Correction Object
    //Bltbl_ChallanDetails_Correction objBltbl_ChallanDetails_Correction;
    //tbl_ChallanDetails_Correction objtbl_ChallanDetails_Correction;

    //Create Object of the Interface_By_Role Class
    Bltbl_Interface_By_Role objBltbl_Interface_By_Role;
    tbl_Interface_By_Role objtbl_Interface_By_Role;


    //Create Object of the Batch Header Correction
    Bltbl_BatchHeader_Correction objBltbl_BatchHeader_Correction;
    tbl_BatchHeader_Correction objtbl_BatchHeader_Correction;

    //Create Object of the Deductee Detail Correction
    Bltbl_DeducteeDetails_Correction objBltbl_DeducteeDetails_Correction;
    tbl_DeducteeDetails_Correction objtbl_DeducteeDetails_Correction;

    //Create Object of the Create File
    Bltbl_CreateFile objBltbl_CreateFile;
    tbl_CreateFile objtbl_CreateFile;

    //Create Object of the Create File Correction
    Bltbl_CreateFile_Correction objBltbl_CreateFile_Correction;
    tbl_CreateFile_Correction objtbl_CreateFile_Correction;


    //Create Object of the File_Header_Correction Module
    Bltbl_FileHeader_Correction objBltbl_FileHeader_Correction;
    tbl_FileHeader_Correction objtbl_FileHeader_Correction;


    //Create Object of the Salary_Detail_Correction Module
    Bltbl_SalaryDetails_Correction objBltbl_SalaryDetails_Correction;
    tbl_SalaryDetails_Correction objtbl_SalaryDetails_Correction;

    //Create Object of the SectionVI_A_Correction Module
    Bltbl_SectionVI_A_Correction objBltbl_SectionVI_A_Correction;
    tbl_SectionVI_A_Correction objtbl_SectionVI_A_Correction;

    //Create Object of the _16_A_Correction Module
    Bltbl_16A_Correction objBltbl_16A_Correction;
    tbl_16A_Correction objtbl_16A_Correction;

    //Create Object of the _16_A
    Bltbl_16A objBltbl_16A;
    tbl_16A objtbl_16A;

    //Create Object of the Challan Details Correction
    Bltbl_ChallanDetails_Correction objBltbl_ChallanDetails_Correction;
    tbl_ChallanDetails_Correction objtbl_ChallanDetails_Correction;

    //Create Object of the BSRCode
    BSRCodes objBSRcode;

    //Create Object of the CreateFile
    CreateFile objCreateFile;

    //Create Datatable
    DataTable dt;
    string strConnName, strConnectionString;
    string strConnectionString_Admin, strConnName_Admin;
    //Create object of dbtbl_Module
    DBtbl_Module objdbtbl_Module;


    #endregion
    #region Page Load
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
        //strConnName = ConfigurationManager.AppSettings["DatabaseEngine"].ToString();
        strConnName = Application["DBEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString;

        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;
        DynamicControl.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;

        objBSRcode = new BSRCodes(strConnectionString, strConnName);
        objCreateFile = new CreateFile(strConnectionString, strConnName);

        objBltbl_ChallanDetails = new Bltbl_ChallanDetails(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_ChallanDetails = new tbl_ChallanDetails();

        objBltbl_DeducteeDetails = new Bltbl_DeducteeDetail(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_DeducteeDetails = new tbl_DeducteeDetail();

        objBltbl_SalaryDetails = new Bltbl_SalaryDetails(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SalaryDetails = new tbl_SalaryDetails();

        objBltbl_Form = new Bltbl_Form(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_Form = new tbl_Form();

        objBltbl_BatchHeader = new Bltbl_BatchHeader(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_BatchHeader = new tbl_BatchHeader();

        objBltbl_16A = new Bltbl_16A(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_16A = new tbl_16A();

        objBltbl_BSRCode = new Bltbl_BSRCode(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_BSRCode = new tbl_BSRCode();

        objBltbl_SectionVI_A = new Bltbl_SectionVI_A(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SectionVI_A = new tbl_SectionVI_A();

        objBltbl_TANMaster = new Bltbl_TANMaster(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_TANMaster = new tbl_TANMaster();

        objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_FileHeader = new tbl_FileHeader();

        objBltbl_ChallanDetails_Correction = new Bltbl_ChallanDetails_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_ChallanDetails_Correction = new tbl_ChallanDetails_Correction();

        //Intialize the Object For InterFace_By_Role
        objBltbl_Interface_By_Role = new Bltbl_Interface_By_Role(strConnectionString_Admin, strConnName_Admin, strConnectionString_Admin);
        objtbl_Interface_By_Role = new tbl_Interface_By_Role();

        objBltbl_BatchHeader_Correction = new Bltbl_BatchHeader_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_BatchHeader_Correction = new tbl_BatchHeader_Correction();

        objBltbl_DeducteeDetails_Correction = new Bltbl_DeducteeDetails_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_DeducteeDetails_Correction = new tbl_DeducteeDetails_Correction();

        objBltbl_CreateFile = new Bltbl_CreateFile(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_CreateFile = new tbl_CreateFile();


        objBltbl_CreateFile_Correction = new Bltbl_CreateFile_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_CreateFile_Correction = new tbl_CreateFile_Correction();

        //Intialize the Object For File Header Correction
        objBltbl_FileHeader_Correction = new Bltbl_FileHeader_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_FileHeader_Correction = new tbl_FileHeader_Correction();

        //Intialize the Object For SalaryDetails Correction
        objBltbl_SalaryDetails_Correction = new Bltbl_SalaryDetails_Correction(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_SalaryDetails_Correction = new tbl_SalaryDetails_Correction();

        //Intialize the Object For SectionVIA Correction
        objBltbl_SectionVI_A_Correction = new Bltbl_SectionVI_A_Correction(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_SectionVI_A_Correction = new tbl_SectionVI_A_Correction();

        //Intialize the Object For 16A Correction
        objBltbl_16A_Correction = new Bltbl_16A_Correction(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_16A_Correction = new tbl_16A_Correction();

        //Intialize the Object For Challan Correction
        objBltbl_ChallanDetails_Correction = new Bltbl_ChallanDetails_Correction(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_ChallanDetails_Correction = new tbl_ChallanDetails_Correction();
        //

        //Initialize the object of dbtbl_Module
        objdbtbl_Module = new DBtbl_Module(strConnectionString, strConnName, strConnectionString_Admin);

        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        //Block The Receipt No By Default
        if (!Page.IsPostBack)
        {
            //txt_PreviousReceiptNo.Enabled = false;
            //txt_PreviousReceiptNo.Attributes.Add("style", "background-color:#E0E0E0");
        }
    }
    #endregion

    #region Functions
    //Event to Select Fire the Action according to the Selected Index
    protected void rdl_PreviousReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdl_PreviousReceiptNo.SelectedValue == "N")
        {
            txt_PreviousReceiptNo.Enabled = false;
        }
        else
        {
            txt_PreviousReceiptNo.Enabled = true;
        }
    }
    #endregion

    protected void btn_Close_Click(object sender, ImageClickEventArgs e)
    {
        //btnClose(sender, e);
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        Bltbl_Form.CurrentLine = 0;
        Bltbl_CreateFile_Correction.CurrentLineNo = 0;
        Bltbl_CreateFile_Correction.Count_BH = 0;
        Bltbl_Form.Count_Challan = 0;
        Bltbl_Form.Count_Deductee = 0;
        Bltbl_Form.Count_Salary = 0;

        String FileName = "FileFormat.txt";
        String FilePath = Server.MapPath("~/FileFormat/" + FileName); //Replace this

        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.Previous_Table = "";
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_update = new List<string[]>();
        Bltbl_CreateFile.CurrentLineNo = 0;

        DynamicControl.Check_EmptyGrid = "";

        GC.Collect();
        GC.WaitForPendingFinalizers();
        string Type = Session["Regular_Correction"].ToString();


        string TAN = Session["TAN"].ToString();//ViewState["TAN"].ToString();
        string quarter = Session["qtr"].ToString();//+Session["ITR"].ToString();//ViewState["Quarter"].ToString();
        string financialYear = Session["FY"].ToString().Replace("-20", "");
        string PAN = Session["PAN"].ToString();//Session["PAN"].ToString();
        string AName = Session["Name"].ToString();//ViewState["AName"].ToString();
        //Session["AName"] = AName;
        //string FileName=@"D:/File126.txt";
        string[] year = Session["FY"].ToString().Split('-');
        int sYear = 0;
        string AssYear = "";
        foreach (string str in year)
        {
            sYear = Convert.ToInt32(str) + 1;
            AssYear += sYear.ToString()+"-";
        }
        AssYear = AssYear.Remove(AssYear.Length-1);
        string AssessmentYear = AssYear.Replace("-20","");//Session["AY"].ToString().Replace("-20", "");
        string FormType = Session["FormType"].ToString();//Session["FormType"].ToString();
        string Regular_Correction = Session["Regular_Correction"].ToString();
        //Create Parameter for Challan Table To Get MasterID.
        objtbl_ChallanDetails.TAN = TAN.ToString();
        objtbl_ChallanDetails.Quarter = quarter.ToString();
        objtbl_ChallanDetails.FinancialYear = financialYear.ToString();
        objtbl_ChallanDetails.FormType = FormType;
        objtbl_ChallanDetails.Regular_Correction = Regular_Correction;
        int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
        int JobID = objBltbl_ChallanDetails.Get_JobId(objtbl_ChallanDetails);
        if (txt_PreviousReceiptNo.Text.Length != 15 &&  rdl_PreviousReceiptNo.SelectedIndex== 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Previous Receipt Number Should be of 15 digit!');", true);
        }
        else
        {
            Session["Previous_RecieptNo="] = txt_PreviousReceiptNo.Text;
            Session["AO_Approval_Number"] = rdl_PreviousReceiptNo.SelectedValue.ToString();
            Session["OK"] = "OK";
            //mdl_Receipt.Hide();
            //Pnl_Receipt.Visible = false;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please Click Create File Button To Create the File!');", true);
        }
        //Path to Create directories
        string Directory_Name = "Download_Files\\" + JobID.ToString() + "_" + DateTime.Now.ToString() + "";
        common objcommon = new common();
        Directory_Name = objcommon.getDirectoryPath_ByJobID(); //@"D:\VatasSolution_Directories\2016-2017\VatasInfosys-JALANDHAR\E-TDS\285";
        //Session["OK"] = "Y";
        if (Type == "Regular")
        {
            if (Session["OK"] == null)
            {
                //Bind the Control With the Previous Values if Exist
                //RadioButtonList rdl_Receipt = (RadioButtonList)usr_receipt.FindControl("rdl_PreviousReceiptNo");
                //System.Web.UI.WebControls.TextBox txt_PreviousReceipt = (System.Web.UI.WebControls.TextBox)usr_receipt.FindControl("txt_PreviousReceiptNo");
                //Get the Data
                dt = new DataTable();
                objtbl_BatchHeader.ID = MasterID;
                dt = objBltbl_BatchHeader.Get_Previous_Receipt_Number(objtbl_BatchHeader);
                if (dt.Rows.Count != 0)
                {
                    if (dt.Rows[0]["Original_Token_Number"].ToString() != "")
                    {
                        string AO_Approval_No = dt.Rows[0]["AO_Approval_Number"].ToString();
                        string Previous_Receipt_No = dt.Rows[0]["Previous_Statement_Token"].ToString();
                        rdl_PreviousReceiptNo.SelectedValue = AO_Approval_No;
                        txt_PreviousReceiptNo.Text = Previous_Receipt_No;
                    }
                    else
                    {
                        //Pnl_Receipt.Attributes.Remove("style");
                        //mdl_Receipt.Show();
                    }
                }
                else
                {
                    //Pnl_Receipt.Attributes.Remove("style");
                    //mdl_Receipt.Show();
                }
            }
            else
            {
                //Create File

                //Pnl_Receipt.Attributes.Remove("style");
                //mdl_Receipt.Show();

                if (File.Exists(FilePath))
                {

                    //Create Parameter For Creating File

                    objtbl_Form.TAN = TAN;
                    objtbl_CreateFile.TAN = TAN;
                    objtbl_Form.Quarter = quarter;
                    objtbl_CreateFile.Quarter = quarter;
                    objtbl_Form.FinancialYear = financialYear;
                    objtbl_CreateFile.FinancialYear = financialYear;
                    objtbl_Form.FormNo = FormType;
                    objtbl_CreateFile.FormNo = FormType;
                    objtbl_Form.Regular_Correction = Regular_Correction;
                    objtbl_CreateFile.Regular_Correction = Regular_Correction;
                    objtbl_Form.CorrectionType = "";
                    objtbl_CreateFile.CorrectionType = "";
                    objtbl_Form.PAN = PAN;
                    objtbl_CreateFile.PAN = PAN;
                    objtbl_Form.Assesment_Year = AssessmentYear;
                    objtbl_CreateFile.Assesment_Year = AssessmentYear;
                    objtbl_Form.FilePath = FilePath;
                    objtbl_CreateFile.FilePath = FilePath;
                    objtbl_CreateFile.Previous_Statement_Token = Session["Previous_RecieptNo="].ToString();
                    objtbl_CreateFile.AO_Approval_Number = Session["AO_Approval_Number"].ToString();
                    //objtbl_CreateFile.Previous_Statement_Token = "";
                    //objtbl_CreateFile.AO_Approval_Number = "Y";
                    objtbl_BatchHeader.ID = MasterID;
                    //---------------------------------------------------------------------------------------------
                    //if (chk_employerAddress.Checked == true)
                    //{
                    //   objtbl_Form.Change_address_of_Deductor_since_last_Return = "Y";
                    //  objtbl_CreateFile.Change_address_of_Deductor_since_last_Return = "Y";  //--There was a checkbox for this but the value was going "False" of that checkbox thats why checkbox was removed 
                    //  objtbl_BatchHeader.Change_address_of_Deductor_since_last_Return = "Y";
                    //}
                    //else
                    //{
                    //---------------------------------------------------------------------------------------------
                    objtbl_Form.Change_address_of_Deductor_since_last_Return = "N";
                    objtbl_CreateFile.Change_address_of_Deductor_since_last_Return = "N";
                    objtbl_BatchHeader.Change_address_of_Deductor_since_last_Return = "Y";
                    //}
                    //---------------------------------------------------------------------------------------------
                    //if (chk_personAddress.Checked == true)
                    //{
                    //   objtbl_Form.Change_address_of_person_since_last_Return = "Y";
                    //   objtbl_CreateFile.Change_address_of_person_since_last_Return = "Y";  //--There was a checkbox for this but the value was going "False" of that checkbox thats why checkbox was removed 
                    //   objtbl_BatchHeader.Change_address_of_person_since_last_Return = "Y";
                    //}
                    //else
                    //{
                    //---------------------------------------------------------------------------------------------
                    objtbl_Form.Change_address_of_person_since_last_Return = "N";
                    objtbl_CreateFile.Change_address_of_person_since_last_Return = "N";
                    objtbl_BatchHeader.Change_address_of_person_since_last_Return = "N";
                    //}
                   //objtbl_Form.Batch_Total_Gross_Total_Income = 10000.00.ToString();
                    if (FormType == "Form24Q")
                    {
                        objtbl_Form.Page_ID = "2";
                        objtbl_Form.Page_SubModule_ID = "22";

                        objtbl_CreateFile.Page_ID = "2";
                        objtbl_CreateFile.Page_SubModule_ID = "22";

                        objtbl_BatchHeader.Page_ID = "2";
                        objtbl_BatchHeader.Page_SubModule_ID = "22";


                    }
                    else if (FormType == "Form26Q")
                    {
                        objtbl_Form.Page_ID = "2";
                        objtbl_Form.Page_SubModule_ID = "23";

                        objtbl_CreateFile.Page_ID = "2";
                        objtbl_CreateFile.Page_SubModule_ID = "23";


                        objtbl_BatchHeader.Page_ID = "2";
                        objtbl_BatchHeader.Page_SubModule_ID = "23";
                    }
                    else if (FormType == "Form27Q")
                    {
                        objtbl_Form.Page_ID = "2";
                        objtbl_Form.Page_SubModule_ID = "24";

                        objtbl_CreateFile.Page_ID = "2";
                        objtbl_CreateFile.Page_SubModule_ID = "23";


                        objtbl_BatchHeader.Page_ID = "2";
                        objtbl_BatchHeader.Page_SubModule_ID = "24";
                    }
                    else if (FormType == "Form27EQ")
                    {
                        objtbl_Form.Page_ID = "2";
                        objtbl_Form.Page_SubModule_ID = "25";

                        objtbl_CreateFile.Page_ID = "2";
                        objtbl_CreateFile.Page_SubModule_ID = "25";

                        objtbl_BatchHeader.Page_ID = "2";
                        objtbl_BatchHeader.Page_SubModule_ID = "25";
                    }


                    objtbl_CreateFile.MasterID = MasterID;

                    objtbl_Form.MasterID = MasterID;
                    objtbl_FileHeader.ID = MasterID;
                    objBltbl_FileHeader.Delete_File_Header(objtbl_FileHeader);
                    objtbl_BatchHeader.Tan_of_Employer = TAN.ToString();
                    objtbl_BatchHeader.Quarter = quarter.ToString();
                    objtbl_BatchHeader.Financial_Year = Convert.ToInt32(financialYear);
                    objtbl_BatchHeader.FormNo = FormType;
                    objtbl_BatchHeader.Regular_Correction = Regular_Correction;

                    int deleteSuccess = objBltbl_BatchHeader.DeleteBH(objtbl_BatchHeader);
                    objtbl_BatchHeader.Tan_of_Employer = "-999999999";

                    objBltbl_BatchHeader.DeleteBH(objtbl_BatchHeader);
                    //get the Challan Details
                    DataTable dt_CD = new DataTable();
                    dt_CD = objBltbl_ChallanDetails.GetChallanData(objtbl_ChallanDetails);
                    DataRow[] drCD = dt_CD.Select("Nill_Challan_Indicator='Y'");
                    int count = drCD.Count();

                    if (count > 0)
                    {

                        int ChallanID = Convert.ToInt32(drCD[0]["ChallanID"]);
                        dt = new DataTable();

                        dt = objBltbl_DeducteeDetails.GetDeducteeDetail(ChallanID, MasterID);
                        if (dt.Rows.Count != 0)
                        {
                            objBltbl_CreateFile.CreateFile(objtbl_CreateFile);
                            //Create Directroy
                            Create_directories(Directory_Name);
                            Session["OK"] = null;
                            Response.ContentType = "text/txt";
                            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + AName + "\".txt");
                            //File.Copy(FilePath, Directory_Name + @"\" + AName + ".txt", true);
                            Page.Response.WriteFile(FilePath);
                            File.Copy(FilePath, Directory_Name + @"\" + Session["TAN"].ToString().Substring(0, 4) + ".txt", true);
                            //Page.Response.WriteFile(Directory_Name + @"\File.txt");
                            //Response.End();

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please Add Deductee Entry of Nill Challan!');", true);
                        }

                    }
                    else
                    {
                        objBltbl_CreateFile.CreateFile(objtbl_CreateFile);
                        Create_directories(Directory_Name);
                        Session["OK"] = null;
                        Session["CreateFile"] = FilePath;
                        //File.Move(
                        string jobd = Session["Job_ID"].ToString();
                        File.Copy(FilePath, Directory_Name + @"\" + Session["TAN"].ToString().Substring(0, 4) + ".txt", true);
                        //Response.Redirect("XMLRestore.aspx");
                        //Response.ContentType = "text/txt";
                        //Response.AddHeader("Content-Disposition", "attachment; filename=\"" + AName + "\".txt");
                        //Page.Response.WriteFile(FilePath);
                        //Response.End();
                    }
                }
                else
                {
                    FileStream fs = File.Create(FilePath);
                    fs.Close();
                    //string TAN = ViewState["TAN"].ToString();
                    //string quarter = ViewState["Quarter"].ToString();
                    //string financialYear = ViewState["FinancialYear"].ToString();
                    //string PAN = ViewState["PAN"].ToString();
                    //string AName = ViewState["AName"].ToString();
                    ////string FileName=@"D:/File126.txt";
                    //string AssessmentYear = ViewState["AssessmentYear"].ToString();
                    //string FormType = Session["FormType"].ToString();
                    //string Regular_Correction = Session["Regular_Correction"].ToString();
                    //Create Parameter For Creating File
                    objtbl_Form.TAN = TAN;
                    objtbl_Form.Quarter = quarter;
                    objtbl_Form.FinancialYear = financialYear;
                    objtbl_Form.FormNo = FormType;
                    objtbl_Form.Regular_Correction = Regular_Correction;
                    objtbl_Form.CorrectionType = "";
                    objtbl_Form.PAN = PAN;
                    objtbl_Form.Assesment_Year = AssessmentYear;
                    objtbl_Form.FilePath = FilePath;

                    //---------------------------------------------------------------------------
                    //if (chk_employerAddress.Checked == true)
                    //{
                    //   objtbl_Form.Change_address_of_Deductor_since_last_Return = "Y";
                    //   objtbl_BatchHeader.Change_address_of_Deductor_since_last_Return = "Y";//--There was a checkbox for this but the value was going "False" of that checkbox thats why checkbox was removed 
                    //}
                    //else
                    //{
                    //---------------------------------------------------------------------------
                    objtbl_Form.Change_address_of_Deductor_since_last_Return = "N";
                    objtbl_BatchHeader.Change_address_of_Deductor_since_last_Return = "Y";
                    //}
                    //---------------------------------------------------------------------------
                    //if (chk_personAddress.Checked == true)
                    //{
                    //    objtbl_Form.Change_address_of_person_since_last_Return = "Y";
                    //    objtbl_BatchHeader.Change_address_of_person_since_last_Return = "Y";//--There was a checkbox for this but the value was going "False" of that checkbox thats why checkbox was removed 
                    //}
                    //else
                    //{
                    //----------------------------------------------------------------------------
                    objtbl_Form.Change_address_of_person_since_last_Return = "N";
                    objtbl_BatchHeader.Change_address_of_person_since_last_Return = "N";
                    //}
                    //objtbl_Form.Batch_Total_Gross_Total_Income = 10000.00.ToString();
                    if (FormType == "Form24Q")
                    {
                        objtbl_Form.Page_ID = "2";
                        objtbl_Form.Page_SubModule_ID = "22";
                    }
                    else if (FormType == "Form26Q")
                    {
                        objtbl_Form.Page_ID = "2";
                        objtbl_Form.Page_SubModule_ID = "23";
                    }
                    else if (FormType == "Form27Q")
                    {
                        objtbl_Form.Page_ID = "2";
                        objtbl_Form.Page_SubModule_ID = "24";
                    }
                    else if (FormType == "Form27EQ")
                    {
                        objtbl_Form.Page_ID = "2";
                        objtbl_Form.Page_SubModule_ID = "25";
                    }
                    //Create Parameter for Challan Table To Get MasterID.
                    objtbl_ChallanDetails.TAN = TAN.ToString();
                    objtbl_ChallanDetails.Quarter = quarter.ToString();
                    objtbl_ChallanDetails.FinancialYear = financialYear.ToString();
                    objtbl_ChallanDetails.FormType = FormType;
                    objtbl_ChallanDetails.Regular_Correction = Regular_Correction;
                    objtbl_CreateFile.Previous_Statement_Token = Session["Previous_RecieptNo="].ToString();
                    objtbl_CreateFile.AO_Approval_Number = Session["AO_Approval_Number"].ToString();
                    //int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
                    objtbl_Form.MasterID = MasterID;
                    objtbl_BatchHeader.Tan_of_Employer = TAN.ToString();
                    objtbl_BatchHeader.Quarter = quarter.ToString();
                    objtbl_BatchHeader.Financial_Year = Convert.ToInt32(financialYear);
                    objtbl_BatchHeader.FormNo = FormType;
                    objtbl_BatchHeader.Regular_Correction = Regular_Correction;
                    int deleteSuccess = objBltbl_BatchHeader.DeleteBH(objtbl_BatchHeader);
                    objtbl_BatchHeader.Tan_of_Employer = "-999999999";
                    objBltbl_BatchHeader.DeleteBH(objtbl_BatchHeader);


                    //get the Challan Details
                    DataTable dt_CD = new DataTable();
                    dt_CD = objBltbl_ChallanDetails.GetChallanData(objtbl_ChallanDetails);
                    DataRow[] drCD = dt_CD.Select("Nill_Challan_Indicator='Y'");
                    int count = drCD.Count();

                    if (count > 0)
                    {

                        int ChallanID = Convert.ToInt32(drCD[0]["ChallanID"]);
                        dt = new DataTable();

                        dt = objBltbl_DeducteeDetails.GetDeducteeDetail(ChallanID, MasterID);
                        if (dt.Rows.Count != 0)
                        {
                            objBltbl_CreateFile.CreateFile(objtbl_CreateFile);
                            Create_directories(Directory_Name);
                            Session["OK"] = null;
                            Session["CreateFile"] = FilePath.ToString();
                            //Response.Redirect("XMLRestore.aspx");
                            //Response.ContentType = "text/txt";
                            //Response.AddHeader("Content-Disposition", "attachment; filename=\"" + AName + "\".txt");
                            //Page.Response.WriteFile(FilePath);
                            //Response.End();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please Add Deductee Entry of Nil Challan!');", true);
                        }
                    }
                    else
                    {
                        objBltbl_CreateFile.CreateFile(objtbl_CreateFile);
                        Create_directories(Directory_Name);
                        Session["OK"] = null;
                        Session["CreateFile"] = FilePath.ToString();
                        //Response.Redirect("XMLRestore.aspx");
                        //Response.ContentType = "text/txt";
                        //Response.AddHeader("Content-Disposition", "attachment; filename=\"" + AName + "\".txt");
                        //Page.Response.WriteFile(FilePath);
                        //Response.End();
                    }
                    
                    //Get_PAN_List(MasterID);
                    //if (Bltbl_Form.CallPrompt == "Yes")
                    //{
                    //    // PlaceHolder2.Visible = false;

                    //    msg_tan.Confirm("Do you wan to Modify TANMaster!");

                    //}
                    //else if (Bltbl_Form.CallPrompt == "No")
                    //{
                    //Session["OK"] = null;
                    //Response.ContentType = "text/txt";
                    //Response.AppendHeader("Content-Disposition", "attachment; filename=" + AName + ".txt");
                    //Page.Response.WriteFile(FilePath);
                    //Response.End();

                    //Session["ReceiptOk"] = "";

                }
            }
        }
        else if (Type == "Correction")
        {

            objtbl_CreateFile_Correction.TAN = TAN;
            objtbl_CreateFile_Correction.Quarter = quarter;
            objtbl_CreateFile_Correction.FinancialYear = financialYear;
            objtbl_CreateFile_Correction.FormNo = FormType;
            objtbl_CreateFile_Correction.Regular_Correction = Regular_Correction;
            objtbl_CreateFile_Correction.CorrectionType = "";
            objtbl_CreateFile_Correction.PAN = PAN;
            objtbl_CreateFile_Correction.Assesment_Year = AssessmentYear;
            objtbl_CreateFile_Correction.FilePath = FilePath;
            //------------------------------------------------------------------------------------
            //if (chk_employerAddress.Checked == true)
            // {
            //    objtbl_CreateFile_Correction.Change_address_of_Deductor_since_last_Return = "Y";//--There was a checkbox for this but the value was going "False" of that checkbox thats why checkbox was removed 
            // }
            // else
            // {
            //------------------------------------------------------------------------------------
            objtbl_CreateFile_Correction.Change_address_of_Deductor_since_last_Return = "N";

            // }
            //-----------------------------------------------------------------------------------
            //if (chk_personAddress.Checked == true)
            //{

            // objtbl_CreateFile_Correction.Change_address_of_person_since_last_Return = "Y";//--There was a checkbox for this but the value was going "False" of that checkbox thats why checkbox was removed 

            //}
            //else
            //{
            //------------------------------------------------------------------------------------
            objtbl_CreateFile_Correction.Change_address_of_person_since_last_Return = "N";

            //}
            //objtbl_CreateFile_Correction.Batch_Total_Gross_Total_Income = 10000.00.ToString();
            if (FormType == "Form24Q")
            {
                objtbl_CreateFile_Correction.Page_ID = "2";
                objtbl_CreateFile_Correction.Page_SubModule_ID = "22";

            }
            else if (FormType == "Form26Q")
            {
                objtbl_CreateFile_Correction.Page_ID = "2";
                objtbl_CreateFile_Correction.Page_SubModule_ID = "23";
            }
            else if (FormType == "Form27Q")
            {

                objtbl_CreateFile_Correction.Page_ID = "2";
                objtbl_CreateFile_Correction.Page_SubModule_ID = "23";

            }
            else if (FormType == "Form27EQ")
            {
                objtbl_CreateFile_Correction.Page_ID = "2";
                objtbl_CreateFile_Correction.Page_SubModule_ID = "25";
            }

            //Create Parameter for Challan Table To Get MasterID.
            objtbl_ChallanDetails.TAN = TAN.ToString();
            objtbl_ChallanDetails.Quarter = quarter.ToString();
            objtbl_ChallanDetails.FinancialYear = financialYear.ToString();
            objtbl_ChallanDetails.FormType = FormType;
            objtbl_ChallanDetails.Regular_Correction = Regular_Correction;
            //int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
            objtbl_CreateFile_Correction.MasterID = MasterID;
            //get the Detail From BatchHeader Correction
            objtbl_BatchHeader_Correction.ID = MasterID;
            DataTable dt_BH = new DataTable();
            dt_BH = objBltbl_BatchHeader_Correction.Get_BH_Correction_Data(objtbl_BatchHeader_Correction);
            string Deductor_Type = dt_BH.Rows[0]["Deductor_Type"].ToString();
            if (Deductor_Type.Length > 1)
                Deductor_Type = Deductor_Type.Remove(1);
            if (Deductor_Type == "C")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select the Category Of Deductor Type in Tan Master!');", true);
            }
            else
            {
                objBltbl_CreateFile_Correction.Create_Correction_File(objtbl_CreateFile_Correction);
                Create_directories(Directory_Name);
                Session["OK"] = null;
                Session["CreateFile"] = FilePath.ToString();
                //Response.Redirect("XMLRestore.aspx");
                //objBltbl_CreateFile_Correction.Create_Correction_File(objtbl_CreateFile_Correction);
                //Create_directories(Directory_Name);
                //Session["OK"] = null;
                //Response.ContentType = "text/txt";
                //Response.AddHeader("Content-Disposition", "attachment; filename=\"" + AName + "\".txt");

                //Page.Response.WriteFile(FilePath);
                //Response.End();
            }





        }
        //mdl_View_Data_Challan.Hide();
        Session["REC"] = "done";
    }

    //Function to Create the Directories
    public void Create_directories(string Directory_Name)
    {
        string Current_Path = "C:\\VatasSolution_Directories";
        string File_Path = Current_Path + "\\" + Directory_Name;
        if (!Directory.Exists(Current_Path))
        {
            Directory.CreateDirectory(Current_Path);

        }

    }
    protected void btnback_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Salary.aspx?vtype=3001");
    }

}
