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
using Taxation.BusinessLogic;

public partial class UserControls_TDS_Delete : System.Web.UI.UserControl
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
    protected void Page_Load(object sender, EventArgs e)
    {
        strConnName = Application["DBEngine"].ToString();
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString;
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;

        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;
        DynamicControl.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;


        objBSRcode = new BSRCodes(strConnectionString, strConnName);
        objCreateFile = new CreateFile(strConnectionString, strConnName);

        objBltbl_ChallanDetails = new Bltbl_ChallanDetails(strConnectionString, strConnName, strConnectionString_Admin);
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
        objBltbl_SalaryDetails_Correction = new Bltbl_SalaryDetails_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SalaryDetails_Correction = new tbl_SalaryDetails_Correction();

        //Intialize the Object For SectionVIA Correction
        objBltbl_SectionVI_A_Correction = new Bltbl_SectionVI_A_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SectionVI_A_Correction = new tbl_SectionVI_A_Correction();

        //Intialize the Object For 16A Correction
        objBltbl_16A_Correction = new Bltbl_16A_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_16A_Correction = new tbl_16A_Correction();

        //Intialize the Object For Challan Correction
        objBltbl_ChallanDetails_Correction = new Bltbl_ChallanDetails_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_ChallanDetails_Correction = new tbl_ChallanDetails_Correction();
        //

        //Initialize the object of dbtbl_Module
        objdbtbl_Module = new DBtbl_Module(strConnectionString, strConnName, strConnectionString_Admin);

        //Block The Receipt No By Default
        if (!Page.IsPostBack)
        {
            //DeleteChallan();
            //DeleteAllChallan();
            //bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            //objbllStoreTrans.deleteUser(Session["NameID"].ToString());
            //Response.Redirect(Request.Url.ToString());
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Confirm", "Confirm1();", true);
            
        }
        if (Session["Mudit"] != null)
        {
            if (Session["Mudit"].ToString() == "Yes")
            {
                btnDelAllTSDData_Click(btnDelAllTSDData, null);
                Session.Remove("Mudit");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Return Deleted Successfully');RemoveSession();window.location='Main.aspx';", true);
            }
            else if (Session["Mudit"].ToString() == "null")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Data Does Not Exists');window.location='salary.aspx?vtype=3001';", true);
            }
        }
        

        //Response.Redirect("Main.aspx");
    }
    public void DeleteSingleChallan()
    {
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";
        //Pnl_Receipt.Attributes.Add("style", "display:none");
        
        //mdl_prn.Hide();
        //mdl_Receipt.Hide();

        //Create Variables Required
        string TAN = Session["TAN"].ToString();//ViewState["TAN"].ToString();
        string quarter = Session["qtr"].ToString();//+Session["ITR"].ToString();//ViewState["Quarter"].ToString();
        string financialYear = Session["FY"].ToString().Replace("-20", "");
        string PAN = Session["PAN"].ToString();//Session["PAN"].ToString();
        //string AName = "A.B.SUGARS LIMITED	QUARTER";//ViewState["AName"].ToString();
        //Session["AName"] = AName;
        //string FileName=@"D:/File126.txt";
        string AssessmentYear = Session["AY"].ToString().Replace("-20", "");
        string FormType = Session["FormType"].ToString();//Session["FormType"].ToString();
        string Regular_Correction = "Regular";//Session["Regular_Correction"].ToString();
        //ViewState["ID_Admin"] = "216260";
        int ChallanDelete = 0;
        int AllChallanDelete = 0;
        int deleteSucess = 0;

        //System.Web.UI.WebControls.CheckBox chkSelectAll = (System.Web.UI.WebControls.CheckBox)gdv_Form.HeaderRow.FindControl("chkAll");

        //Create Parameters.
        objtbl_ChallanDetails.TANNo = TAN;
        objtbl_ChallanDetails.TAN = TAN;
        objtbl_ChallanDetails.Quarter = quarter;
        objtbl_ChallanDetails.FinancialYear = financialYear;
        objtbl_ChallanDetails.FormType = FormType;
        objtbl_ChallanDetails.Regular_Correction = Regular_Correction;
        objtbl_ChallanDetails.Page_ID = "2";
        objtbl_ChallanDetails.Page_SubModule_ID = "23";
        int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
        //Session["MasterID"] = MasterID;
        //if (chkSelectAll.Checked && chkSelectAll != null)
        //{


        //    //Call the Function Delete  the All Challan Entry.
        //    //Create parameter to Delete all DeducteeDetail Entry
        //    objtbl_DeducteeDetails.MasterID = MasterID;
        //    int DelSucess = objBltbl_DeducteeDetails.DeleteAllEntriesByChallan(objtbl_DeducteeDetails);


        //    if (DelSucess == 1)
        //    {
        //        AllChallanDelete = objBltbl_ChallanDetails.DeleteAllChallanEntry(objtbl_ChallanDetails);
        //        if (AllChallanDelete == 1)
        //        {
        //            objtbl_DeducteeDetails.MasterID = -999999999;
        //            objBltbl_DeducteeDetails.DeleteAllEntriesByChallan(objtbl_DeducteeDetails);
        //            //gdv_Form.DataSource = objBltbl_ChallanDetails.GetNewChallanEntered(objtbl_ChallanDetails);
        //            //gdv_Form.DataBind();


        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('All Challans Deleted Successfully!');", true);
        //        }

        //    }
        //}
        //else
        //{

        //System.Web.UI.WebControls.CheckBox chkSelect = (System.Web.UI.WebControls.CheckBox)rows.FindControl("chkSelect");

        int ChallanID = Convert.ToInt32(Session["ChallanID"]);


        //Get the Deductee ID
        int Deductee_ID = 0;
        objtbl_DeducteeDetails.ID = ChallanID;
        objtbl_DeducteeDetails.MasterID = MasterID;
        objtbl_DeducteeDetails.Regular_Correction = Regular_Correction;
        DataTable dt_ID = new DataTable();
        dt_ID = objBltbl_DeducteeDetails.BindDeducteeDetails(objtbl_DeducteeDetails);
        foreach (DataRow dr in dt_ID.Rows)
        {
            Deductee_ID = Convert.ToInt32(dr["DeducteeID"]);
            ////Create Parameter for Deleting the Corresponding Deductee Entries
            objtbl_DeducteeDetails.ID = ChallanID;
            objtbl_DeducteeDetails.MasterID = MasterID;
            objtbl_DeducteeDetails.ID_Admin = Convert.ToInt32(ViewState["IDAdmin"]);
            objtbl_DeducteeDetails.DeducteeID = Deductee_ID;
            objtbl_DeducteeDetails.Page_ID = "2";
            objtbl_DeducteeDetails.Page_SubModule_ID = "23";
            deleteSucess = objBltbl_DeducteeDetails.DeleteSelectedEnteries(objtbl_DeducteeDetails);

            // Create Parameter for Deleting BatchHeader Entries 
            objtbl_BatchHeader.Tan_of_Employer = TAN;
            objtbl_BatchHeader.Quarter = quarter;
            objtbl_BatchHeader.Financial_Year = Convert.ToInt32(financialYear);
            objtbl_BatchHeader.FormNo = FormType;
            objtbl_BatchHeader.Regular_Correction = Regular_Correction;
            //Check Existence of MasterID in BatchHeader Table
            objtbl_BatchHeader.ID = MasterID;
            bool IsMasterIDExist = objBltbl_BatchHeader.CheckMasterID(objtbl_BatchHeader);
            if (IsMasterIDExist)
            {
                int deleteSuccess = objBltbl_BatchHeader.DeleteBH(objtbl_BatchHeader);

            }
            objtbl_DeducteeDetails.DeducteeID = -999999999;
            objBltbl_DeducteeDetails.DeleteSelectedEnteries(objtbl_DeducteeDetails);
        }


        //ChallanDelete= objForm26.DeleteSelectedChallan(TAN,quarter,financialYear,PrNumber);
        objtbl_ChallanDetails.ChallanID = ChallanID;
        objtbl_ChallanDetails.ID = MasterID;

        ChallanDelete = objBltbl_ChallanDetails.DeleteSelectedChallanEntry(objtbl_ChallanDetails);

        if (ChallanDelete == 1)
        {
            objtbl_ChallanDetails.ChallanID = -999999999;
            objBltbl_ChallanDetails.DeleteSelectedChallanEntry(objtbl_ChallanDetails);

        }
        //gdv_Form.DataSource = objBltbl_ChallanDetails.GetNewChallanEntered(objtbl_ChallanDetails);
        //gdv_Form.DataBind();
        //RefreshTDSTabControlS();
        //FillDefaultRecordsForTDS();
        //// objBltbl_ChallanDetails.RegenrateChallanID(objtbl_ChallanDetails, ChallanID);
        // objtbl_ChallanDetails.Line_Number = 0;
        // objtbl_ChallanDetails.ID = MasterID;
        // objBltbl_ChallanDetails.Update_Challan_Detail_Line_Number_ByID(objtbl_ChallanDetails);
        // objtbl_DeducteeDetails.MasterID =MasterID;
        // objtbl_DeducteeDetails.Line_Number = 0;
        // objBltbl_DeducteeDetails.Update_Deductee_Detail_Line_Number_ByID(objtbl_DeducteeDetails);


        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Challan Deleted Successfully!');", true);





    }


    public void DeleteDeductee()
    {
        //Clear List
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";

        string TAN = Session["TAN"].ToString();//ViewState["TAN"].ToString();
        string quarter = Session["qtr"].ToString();//+Session["ITR"].ToString();//ViewState["Quarter"].ToString();
        string financialYear = Session["FY"].ToString().Replace("-20", "");
        string PAN = Session["PAN"].ToString();//Session["PAN"].ToString();
        //string AName = "A.B.SUGARS LIMITED	QUARTER";//ViewState["AName"].ToString();
        //Session["AName"] = AName;
        //string FileName=@"D:/File126.txt";
        string AssessmentYear = Session["AY"].ToString().Replace("-20", "");
        string FormType = Session["FormType"].ToString();//Session["FormType"].ToString();
        string Regular_Correction = "Regular";//Session["Regular_Correction"].ToString();
        //ViewState["ID_Admin"] = "216260";
        //int ChallanDelete = 0;
        //int AllChallanDelete = 0;
        //int deleteSucess = 0;

        //System.Web.UI.WebControls.CheckBox chkSelectAll = (System.Web.UI.WebControls.CheckBox)gdv_Form.HeaderRow.FindControl("chkAll");

        //Create Parameters.
        objtbl_ChallanDetails.TANNo = TAN;
        objtbl_ChallanDetails.TAN = TAN;
        objtbl_ChallanDetails.Quarter = quarter;
        objtbl_ChallanDetails.FinancialYear = financialYear;
        objtbl_ChallanDetails.FormType = FormType;
        objtbl_ChallanDetails.Regular_Correction = Regular_Correction;
        objtbl_ChallanDetails.Page_ID = "2";
        objtbl_ChallanDetails.Page_SubModule_ID = "23";
        int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
        int ID = Convert.ToInt32(Session["ddlChallanID"]);//Convert.ToInt32(ViewState["ChallanID"]);
        //int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);//Convert.ToInt32(Session["MasterID"]);
        string Page_ID = string.Empty;
        string Page_Sub_ModuleID = string.Empty;
        //string FormType = Session["FormType"].ToString();
        //string Regular_Correction = "Regular";//Session["Regular_Correction"].ToString();
        int DeducteeID = Convert.ToInt32(Session["ChallanID"]);//Convert.ToInt32(ViewState["DeducID"]);
        if (Regular_Correction == "Regular")
        {

            objtbl_DeducteeDetails.DeducteeID = DeducteeID;
            objtbl_DeducteeDetails.ID = ID;
            objtbl_DeducteeDetails.MasterID = MasterID;

            if (FormType == "Form24Q")
            {
                objtbl_DeducteeDetails.Page_ID = "2";
                objtbl_DeducteeDetails.Page_SubModule_ID = "22";

            }
            else if (FormType == "Form26Q")
            {
                objtbl_DeducteeDetails.Page_ID = "2";
                objtbl_DeducteeDetails.Page_SubModule_ID = "23";
            }
            else if (FormType == "Form27Q")
            {
                objtbl_DeducteeDetails.Page_ID = "2";
                objtbl_DeducteeDetails.Page_SubModule_ID = "24";
            }
            else if (FormType == "Form27EQ")
            {
                objtbl_DeducteeDetails.Page_ID = "2";
                objtbl_DeducteeDetails.Page_SubModule_ID = "25";
            }
            Page_ID = objtbl_DeducteeDetails.Page_ID;
            Page_Sub_ModuleID = objtbl_DeducteeDetails.Page_SubModule_ID;
            int success = objBltbl_DeducteeDetails.DeleteSelectedEnteries(objtbl_DeducteeDetails);
            //Fire the Query to Delete the Deductee Record
            //if (success == 1)
            //{
            //    objtbl_DeducteeDetails.DeducteeID = -999999999;
            //    objBltbl_DeducteeDetails.DeleteSelectedEnteries(objtbl_DeducteeDetails);
            //}
            objtbl_DeducteeDetails.DeducteeID = DeducteeID;
            Update_ChallanFieldsByDeductee(ID, MasterID, Page_ID, Page_Sub_ModuleID);
            objBltbl_DeducteeDetails.RegenrateDeducteeID(objtbl_DeducteeDetails, DeducteeID);
            //objBltbl_DeducteeDetails.RegenrateDeducteeRecordNo(objtbl_DeducteeDetails);
            objtbl_DeducteeDetails.MasterID = MasterID;
            objtbl_DeducteeDetails.Line_Number = 0;
            objBltbl_DeducteeDetails.Update_Deductee_Detail_Line_Number_ByID(objtbl_DeducteeDetails);
            objtbl_ChallanDetails.Line_Number = 0;
            objtbl_ChallanDetails.ID = MasterID;
            objBltbl_ChallanDetails.Update_Challan_Detail_Line_Number_ByID(objtbl_ChallanDetails);
        }
        else if (Regular_Correction == "Correction")
        {
            //Create Parameters
            objtbl_DeducteeDetails_Correction.DeducteeID = DeducteeID;
            objtbl_DeducteeDetails_Correction.ID = ID;
            objtbl_DeducteeDetails_Correction.MasterID = MasterID;
            objtbl_DeducteeDetails_Correction.Mode = "D";
            objtbl_DeducteeDetails_Correction.C3 = "Y";
            objtbl_DeducteeDetails_Correction.Decision = "D";
            //get the Decision of Record To be Deleted
            DataTable dt = new DataTable();
            dt = objBltbl_DeducteeDetails_Correction.Get_deductee_Correction(objtbl_DeducteeDetails_Correction);
            string Decision = dt.Rows[0]["Desicion"].ToString();
            if (FormType == "Form24Q")
            {
                objtbl_DeducteeDetails_Correction.Page_ID = "2";
                objtbl_DeducteeDetails_Correction.Page_SubModule_ID = "22";

            }
            else if (FormType == "Form26Q")
            {
                objtbl_DeducteeDetails_Correction.Page_ID = "2";
                objtbl_DeducteeDetails_Correction.Page_SubModule_ID = "23";
            }
            else if (FormType == "Form27Q")
            {
                objtbl_DeducteeDetails_Correction.Page_ID = "2";
                objtbl_DeducteeDetails_Correction.Page_SubModule_ID = "24";
            }
            else if (FormType == "Form27EQ")
            {
                objtbl_DeducteeDetails_Correction.Page_ID = "2";
                objtbl_DeducteeDetails_Correction.Page_SubModule_ID = "25";
            }
            if (Decision != "A")
            {

                int success = objBltbl_DeducteeDetails_Correction.Delete_Deductee_Correction(objtbl_DeducteeDetails_Correction);

                // Mark the Correction the File Header
                objtbl_FileHeader_Correction.C1 = "";
                objtbl_FileHeader_Correction.C2 = "";
                objtbl_FileHeader_Correction.C3 = "Y";
                objtbl_FileHeader_Correction.C4 = "";
                objtbl_FileHeader_Correction.C5 = "";
                objtbl_FileHeader_Correction.C9 = "";

                objtbl_ChallanDetails.ChallanID = ID;
                objtbl_ChallanDetails.ID = MasterID;
                objtbl_ChallanDetails.Regular_Correction = "Correction";
                DataTable dt_Previous_Correction_Mark_CD = objBltbl_ChallanDetails.GetChallanDetailByID(objtbl_ChallanDetails);
                string Previous_C5_CD = string.Empty;
                string Previous_C2_CD = string.Empty;
                if (dt_Previous_Correction_Mark_CD.Rows.Count != 0)
                {
                    Previous_C2_CD = dt_Previous_Correction_Mark_CD.Rows[0]["C2"].ToString();
                    Previous_C5_CD = dt_Previous_Correction_Mark_CD.Rows[0]["C5"].ToString();
                }
                //Mark the Correction in the Challan Correction
                if (Previous_C2_CD == "" && Previous_C5_CD == "")
                {
                    objtbl_ChallanDetails_Correction.ChallanID = ID;
                    objtbl_ChallanDetails_Correction.ID = MasterID;
                    objtbl_ChallanDetails_Correction.C1 = "";
                    objtbl_ChallanDetails_Correction.C2 = "";
                    objtbl_ChallanDetails_Correction.C3 = "Y";
                    objtbl_ChallanDetails_Correction.C4 = "";
                    objtbl_ChallanDetails_Correction.C5 = "";
                    objtbl_ChallanDetails_Correction.C9 = "";
                    objtbl_ChallanDetails_Correction.Decision = "D";
                }
                else if (Previous_C2_CD == "Y" && Previous_C5_CD == "")
                {
                    objtbl_ChallanDetails_Correction.ChallanID = ID;
                    objtbl_ChallanDetails_Correction.ID = MasterID;
                    objtbl_ChallanDetails_Correction.C1 = "";
                    objtbl_ChallanDetails_Correction.C2 = "Y";
                    objtbl_ChallanDetails_Correction.C3 = "Y";
                    objtbl_ChallanDetails_Correction.C4 = "";
                    objtbl_ChallanDetails_Correction.C5 = "";
                    objtbl_ChallanDetails_Correction.C9 = "";
                    objtbl_ChallanDetails_Correction.Decision = "D";
                }
                else if (Previous_C2_CD == "" && Previous_C5_CD == "Y")
                {
                    objtbl_ChallanDetails_Correction.ChallanID = ID;
                    objtbl_ChallanDetails_Correction.ID = MasterID;
                    objtbl_ChallanDetails_Correction.C1 = "";
                    objtbl_ChallanDetails_Correction.C2 = "";
                    objtbl_ChallanDetails_Correction.C3 = "Y";
                    objtbl_ChallanDetails_Correction.C4 = "";
                    objtbl_ChallanDetails_Correction.C5 = "Y";
                    objtbl_ChallanDetails_Correction.C9 = "";
                    objtbl_ChallanDetails_Correction.Decision = "D";
                }
                else if (Previous_C2_CD == "Y" && Previous_C5_CD == "Y")
                {
                    objtbl_ChallanDetails_Correction.ChallanID = ID;
                    objtbl_ChallanDetails_Correction.ID = MasterID;
                    objtbl_ChallanDetails_Correction.C1 = "";
                    objtbl_ChallanDetails_Correction.C2 = "Y";
                    objtbl_ChallanDetails_Correction.C3 = "Y";
                    objtbl_ChallanDetails_Correction.C4 = "";
                    objtbl_ChallanDetails_Correction.C5 = "Y";
                    objtbl_ChallanDetails_Correction.C9 = "";
                    objtbl_ChallanDetails_Correction.Decision = "D";
                }



                if (success == 1)
                {
                    objtbl_DeducteeDetails_Correction.Mode = "-999999999";
                    objBltbl_DeducteeDetails_Correction.Delete_Deductee_Correction(objtbl_DeducteeDetails_Correction);

                    objtbl_FileHeader_Correction.ID = MasterID;
                    objBltbl_FileHeader_Correction.Mark_Correction_Type(objtbl_FileHeader_Correction);
                    objBltbl_ChallanDetails_Correction.Mark_Correction(objtbl_ChallanDetails_Correction);
                }
            }
            else if (Decision == "A")
            {
                int success2 = objBltbl_DeducteeDetails_Correction.Delete_Deductee_Correction_DataBase(objtbl_DeducteeDetails_Correction);
                if (success2 == 1)
                {
                    objtbl_DeducteeDetails_Correction.DeducteeID = -999999999;
                    objBltbl_DeducteeDetails_Correction.Delete_Deductee_Correction_DataBase(objtbl_DeducteeDetails_Correction);
                }

            }



        }
    }
    public void Update_ChallanFieldsByDeductee(int ChallanID, int MasterID, string Page_ID, string Page_SubModule_ID)
    {

        objtbl_DeducteeDetails.ID = ChallanID;
        objtbl_ChallanDetails.ChallanID = ChallanID;
        objtbl_ChallanDetails.ID = MasterID;
        objtbl_DeducteeDetails.MasterID = MasterID;
        dt = new DataTable();
        dt = objBltbl_DeducteeDetails.GetSum(objtbl_DeducteeDetails);
        Double Total_TDS = 0.00;
        Double Total_Surcharge = 0.00;
        Double Total_EducationCess = 0.00;
        Double Total_Tax_Deposited_Sec = 0.00;
        Double Total_IncomeTax_Deduc = 0.00;
        if (dt.Rows.Count != 0)
        {
            if (dt.Rows[0]["TotalTDS"].ToString() != "" && dt.Rows[0]["TotalTDS"].ToString() != null)
            {
                Total_TDS = Convert.ToDouble(dt.Rows[0]["TotalTDS"]);

            }
            else
            {
                Total_TDS = 0.00;
            }
            if (dt.Rows[0]["TotalSurcharge"].ToString() != "" && dt.Rows[0]["TotalSurcharge"].ToString() != null)
            {
                Total_Surcharge = Convert.ToDouble(dt.Rows[0]["TotalSurcharge"]);

            }
            else
            {
                Total_Surcharge = 0.00;
            }
            if (dt.Rows[0]["TotalEducationCess"].ToString() != "" && dt.Rows[0]["TotalEducationCess"].ToString() != null)
            {
                Total_EducationCess = Convert.ToDouble(dt.Rows[0]["TotalEducationCess"]);

            }
            else
            {
                Total_EducationCess = 0.00;
            }


            int count_deductee = objBltbl_ChallanDetails.GetDeducteeCount(objtbl_ChallanDetails);
            if (dt.Rows[0]["Total_TaxDeposited_Sec"].ToString() != "" && dt.Rows[0]["Total_TaxDeposited_Sec"].ToString() != null)
            {
                Total_Tax_Deposited_Sec = Convert.ToDouble(dt.Rows[0]["Total_TaxDeposited_Sec"]);

            }
            else
            {
                Total_Tax_Deposited_Sec = 0.00;
            }

            if (dt.Rows[0]["Total_IncomeTAX_Deducted_Sec"].ToString() != "" && dt.Rows[0]["Total_IncomeTAX_Deducted_Sec"].ToString() != null)
            {
                Total_IncomeTax_Deduc = Convert.ToDouble(dt.Rows[0]["Total_IncomeTAX_Deducted_Sec"]);
            }
            else
            {
                Total_IncomeTax_Deduc = 0.00;
            }
            //Create parameter
            objtbl_ChallanDetails.ChallanID = ChallanID;
            objtbl_ChallanDetails.ID = MasterID;
            objtbl_ChallanDetails.Total_TAX_Deposite_Amount = Total_Tax_Deposited_Sec;
            objtbl_ChallanDetails.TDS_TCS_IncomeTAX = Total_TDS;
            objtbl_ChallanDetails.TDS_TCS_Surcharge = Total_Surcharge;
            objtbl_ChallanDetails.TDS_TCS_Cess = Total_EducationCess;
            objtbl_ChallanDetails.Total_IncomeTAX_Deducted = Total_IncomeTax_Deduc;
            objtbl_ChallanDetails.Count_Of_deductee_PartyRecords = count_deductee;
            objtbl_ChallanDetails.Page_ID = Page_ID;
            objtbl_ChallanDetails.Page_SubModule_ID = Page_SubModule_ID;
            objtbl_ChallanDetails.C9 = "";
            objtbl_ChallanDetails.C3 = "";
            objtbl_ChallanDetails.Decision = "";
            int success = objBltbl_ChallanDetails.Update_Challan_ByDeductee(objtbl_ChallanDetails);
            //objtbl_ChallanDetails.Total_TAX_Deposite_Amount = -999999999;
            // objBltbl_ChallanDetails.Update_Challan_ByDeductee(objtbl_ChallanDetails);




        }
        //else
        //{
        //    txt_TDS.Text = "0.00";
        //    txt_TDS.Attributes.Add("style", "text-align:right");
        //    txt_Surcharge.Text = "0.00";
        //    txt_Surcharge.Attributes.Add("style", "text-align:right");

        //    txt_EducationCess.Text = "0.00";
        //    txt_EducationCess.Attributes.Add("style", "text-align:right");
        //    CalcTotalTaxDeposited();
        //}
        //Pnl_Bsr.Visible = false;
        // RefreshSectionTabControls();
        //gdv_Section.DataSource = null;
        //gdv_Section.DataBind();

        //UpdateTDS = "Yes";
        //Mv_Form.SetActiveView(Vw_TDS);
        //tab_Sections.Visible = true;
        //tab_TDS.Enabled = true;
        //TabContainer1.ActiveTabIndex = 0;
    }
    public void DeleteAllChallan()
    {
        //Pnl_Receipt.Attributes.Add("style", "display:none");

        //mdl_Receipt.Hide();
        string TAN = Session["TAN"].ToString();//ViewState["TAN"].ToString();
        string quarter =Session["qtr"].ToString();//+Session["ITR"].ToString();//ViewState["Quarter"].ToString();
        string financialYear = Session["FY"].ToString().Replace("-20", "");
        string PAN = Session["PAN"].ToString();//Session["PAN"].ToString();
        //string AName = "A.B.SUGARS LIMITED	QUARTER";//ViewState["AName"].ToString();
        //Session["AName"] = AName;
        //string FileName=@"D:/File126.txt";
        string AssessmentYear = Session["AY"].ToString().Replace("-20", "");
        string FormType = Session["FormType"].ToString();//Session["FormType"].ToString();
        string Regular_Correction = "Regular";//Session["Regular_Correction"].ToString();

        int ChallanDelete = 0;
        int AllChallanDelete = 0;
        int deleteSucess = 0;

        //System.Web.UI.WebControls.CheckBox chkSelectAll = (System.Web.UI.WebControls.CheckBox)gdv_Form.HeaderRow.FindControl("chkAll");

        //Create Parameters.
        objtbl_ChallanDetails.TANNo = TAN;
        objtbl_ChallanDetails.TAN = TAN;
        objtbl_ChallanDetails.Quarter = quarter;
        objtbl_ChallanDetails.FinancialYear = financialYear;
        objtbl_ChallanDetails.FormType = FormType;
        objtbl_ChallanDetails.Regular_Correction = Regular_Correction;
        objtbl_ChallanDetails.Page_ID = "2";
        objtbl_ChallanDetails.Page_SubModule_ID = "23";
        int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
        objtbl_ChallanDetails.ID = MasterID;
        //Delete the Record From Challan By Master ID
        int success_challan = objBltbl_ChallanDetails.DeleteChallanByMasterID(objtbl_ChallanDetails);

        int success_deductee = objBltbl_DeducteeDetails.DeleteDeducteeByMasterID(objtbl_DeducteeDetails);

        if (FormType == "Form24Q" && quarter == "Q4")
        {
            int success_salary = objBltbl_SalaryDetails.DeleteSalaryByMasterID(objtbl_SalaryDetails);

        }
        objtbl_FileHeader.ID = MasterID;
        int success = objBltbl_FileHeader.Delete_Master_Record(objtbl_FileHeader);
        //RefreshChallanGrid(MasterID);
        //drp_TaxDepositedBookEntry.Focus();
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Return Deleted Successfully');window.location='Main.aspx';", true);


    }
    //public void DeleteSalary()
    //{
    //    //Clear List
    //    DBtbl_Module.ArrayIndex = 0;
    //    DBtbl_Module.count = 0;
    //    DBtbl_Module.lst_Field = new Dictionary<string, int>();
    //    DBtbl_Module.lst_Query = new List<string>();
    //    DBtbl_Module.lst_update = new List<string[]>();
    //    DBtbl_Module.Previous_RecordNo = 0;
    //    DBtbl_Module.Previous_Table = "";
    //    denStoreTrans objdenStoreTrans = new denStoreTrans();
    //    dalStoreTrans objdalStoreTrans = new dalStoreTrans();
    //    //Get ID_Admin
    //    int ID_Admin = Convert.ToInt32(ViewState["ID_Admin"]);
    //    int Salary_Detail_RecordNo = Convert.ToInt32(Session["ChallanID"]);//Convert.ToInt32(ViewState["SalaryID"]);
    //    int ID = Convert.ToInt32(Session["MasterID"]);//Convert.ToInt32(ViewState["ID"]);
    //    string Regular_Correction = "Regular";
    //    int Success = 0;
    //    //Create The Parameters
    //    objtbl_SalaryDetails.ID_Admin = ID_Admin;
    //    objtbl_SalaryDetails.Salary_Detail_RecordNo = Salary_Detail_RecordNo;
    //    objtbl_SalaryDetails.ID = ID;
    //    objtbl_SalaryDetails.Page_ID = "2";
    //    objtbl_SalaryDetails.Page_SubModule_ID = "22";
    //    if (Regular_Correction == "Regular")
    //    {


    //        //Delete the Salary Detail
    //        Success = objBltbl_SalaryDetails.DeleteRecords(objtbl_SalaryDetails);
    //        objdenStoreTrans = objdalStoreTrans.GetMainGridData(Convert.ToString(Session["NameID"]), 49, Convert.ToInt32(ViewState["ConstID"]), ViewState["MainID"].ToString(), Session["AY"].ToString());
    //        //Check the Existence of Section VIA Records
    //        if (Session["ConstID"] == "3024")
    //        {
    //            if (objdenStoreTrans.Col3 != "" &&  objdenStoreTrans.Col3 != "0")
    //            {
    //                objtbl_16A.ID_Admin = ID_Admin;
    //                objtbl_16A.Salary_Detail_RecordNo = Salary_Detail_RecordNo;
    //                objtbl_16A.Page_ID = "2";
    //                objtbl_16A.Page_SubModule_ID = "22";
    //                //Delete 16A Records
    //                Success = objBltbl_16A.Delete_16A(objtbl_16A);
    //            }
    //        }
    //        if (Session["ConstID"] == "3019")
    //        {
    //            if (objdenStoreTrans.Col3 != "" && objdenStoreTrans.Col3 != "0")
    //            {
    //                objtbl_SectionVI_A.ID_Admin = ID_Admin;
    //                objtbl_SectionVI_A.Salary_Detail_RecordNo = Salary_Detail_RecordNo;
    //                objtbl_SectionVI_A.Page_ID = "2";
    //                objtbl_SectionVI_A.Page_SubModule_ID = "22";
    //                Success = objBltbl_SectionVI_A.Delete_SectionVIA(objtbl_SectionVI_A);
    //            }
    //        }
    //        if (Success == 1)
    //        {
    //            objtbl_SalaryDetails.ID_Admin = -999999999;
    //            objBltbl_SalaryDetails.DeleteRecords(objtbl_SalaryDetails);

    //            objtbl_SalaryDetails.Line_Number = 0;
    //            objtbl_SalaryDetails.ID_Admin = ID_Admin;
    //            objBltbl_SalaryDetails.Update_Salary_Detail_Line_Number_ByID(objtbl_SalaryDetails);

    //            objtbl_SectionVI_A.Line_Number = 0;
    //            objtbl_SectionVI_A.ID_Admin = ID_Admin;
    //            objBltbl_SectionVI_A.Update_Sec6A_Line_Number_ByID(objtbl_SectionVI_A);

    //            objtbl_16A.ID_Admin = ID_Admin;
    //            objtbl_16A.Line_Number = 0;
    //            objBltbl_16A.Update_16A_Line_Number_ByID(objtbl_16A);
    //            //BindSalaryGrid(ID);



    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Salary Detail Record Deleted!');", true);

    //        }

    //    }
    //    else if (Regular_Correction == "Correction")
    //    {

    //        objtbl_SalaryDetails_Correction.ID_Admin = ID_Admin;
    //        objtbl_SalaryDetails_Correction.Salary_Detail_RecordNo = Salary_Detail_RecordNo;
    //        objtbl_SalaryDetails_Correction.ID = ID;
    //        objtbl_SalaryDetails_Correction.Page_ID = "2";
    //        objtbl_SalaryDetails_Correction.Page_SubModule_ID = "22";
    //        objtbl_SalaryDetails_Correction.Mode = "D";
    //        objtbl_SalaryDetails_Correction.C4 = "Y";
    //        objtbl_SalaryDetails_Correction.Decision = "D";

    //        //Delete the Salary Detail
    //        Success = objBltbl_SalaryDetails_Correction.DeleteRecords_Correction(objtbl_SalaryDetails_Correction);
    //        //Marking the Type of Correction in the File Header Correction Table
    //        objtbl_FileHeader_Correction.ID = ID;
    //        objtbl_FileHeader_Correction.C1 = "";
    //        objtbl_FileHeader_Correction.C2 = "";
    //        objtbl_FileHeader_Correction.C3 = "";
    //        objtbl_FileHeader_Correction.C4 = "Y";
    //        objtbl_FileHeader_Correction.C5 = "";
    //        objtbl_FileHeader_Correction.C9 = "";
    //        objtbl_FileHeader_Correction.Y = "";


    //        int success_FH = objBltbl_FileHeader_Correction.Mark_Correction_Type(objtbl_FileHeader_Correction);

    //        objtbl_SalaryDetails_Correction.Mode = "-999999999";
    //        objBltbl_SalaryDetails_Correction.DeleteRecords_Correction(objtbl_SalaryDetails_Correction);

    //        //BindSalaryGrid(ID);

    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Salary Detail Record Deleted!');", true);





    //    }
    //}
    protected void btnDelTDSSingleData_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["vtype"].ToString() == "3001")
        {
            DeleteSingleChallan();
        }
        else if (Request.QueryString["vtype"].ToString() == "3002")
        {
            DeleteDeductee();
        }
        else if (Request.QueryString["vtype"].ToString() == "3003")
        {
            //DeleteSalary();
        }
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        objbllStoreTrans.deleteUser(Session["NameID"].ToString());
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnDelAllTSDData_Click(object sender, EventArgs e)
    {
        DeleteAllChallan();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        objbllStoreTrans.deleteUser(Session["NameID"].ToString());
        //Response.Redirect(Request.Url.ToString());
    }
}
//}