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
using VatasInfosysLib;
using System.Collections.Generic;
using BALVatasETDS.TANMaster;
using BALVatasETDS.FileHeader;
using BALVatasETDS.BatchHeader;
using BALVatasETDS.ChallanDetails;
using BALVatasETDS.DeducteeDetail;
using BALVatasETDS.SalaryDetails;
using BALVatasETDS._16A;
using BALVatasETDS.Section_VI_A;
using BALVatasETDS.Import_DataTable;
using BALVatasETDS.BatchHeader_Correction;
using BALVatasETDS.ChallanDetails_Correction;
using BALVatasETDS.DeducteeDetail_Correction;
using BALVatasETDS.SalaryDetails_Correction;
using BALVatasETDS.System_Config;
using BALVatasETDS.Path_Management;
using DALVatasETDS;
using System.IO;
using BALVatasETDS;
using System.Data.OleDb;
using System.Xml;
using Microsoft.XmlDiffPatch;
using System.Xml.Schema;
using ClosedXML.Excel;
using System.Text;
using System.Text.RegularExpressions;
using controlgrid;
using Taxation.BusinessLogic;
public partial class UserControls_Import : System.Web.UI.UserControl
{
    #region Declaration

    Bltbl_TANMaster objBltbl_TANMaster;
    tbl_TANMaster objtbl_TANMaster;
    public static int CountDeductee = 0;
    public static int index = 0;
    public static int countChallan = 0;
    public static int countAnnualSalary = 0;
    public static int Count_SectionVIA = 0;
    public static int Count_16A = 0;
    public string Update_Flag = string.Empty;
    public static int Count_index = 0;

    int ID_Admin = 0;
    string[] arr_Field_param;
    DataSet ds;

    //Create Object of File_Header Class
    Bltbl_FileHeader objBltbl_FileHeader;
    tbl_FileHeader objtbl_FileHeader;
    //Create Object of Batch_Header Class
    Bltbl_BatchHeader objBltbl_BatchHeader;
    tbl_BatchHeader objtbl_BatchHeader;
    //Create Object of Challan_Detail Class
    Bltbl_ChallanDetails objBltbl_ChallanDetails;
    tbl_ChallanDetails objtbl_ChallanDetails;
    //Create Object of Deductee_Detail Class
    Bltbl_DeducteeDetail objBltbl_DeducteeDetail;
    tbl_DeducteeDetail objtbl_DeducteeDetail;

    //Create Object of Salary_Detail Class
    Bltbl_SalaryDetails objBltbl_SalaryDetails;
    tbl_SalaryDetails objtbl_SalaryDetails;

    //Create Object Of the 16A Table
    Bltbl_16A objBltbl_16A;
    tbl_16A objtbl_16A;

    //Section VI A Object
    Bltbl_SectionVI_A objBltbl_SectionVI_A;
    tbl_SectionVI_A objtbl_SectionVI_A;

    //Create Object of DB_Module
    DBtbl_Module objDBtbl_Module;

    //Create Object For Correction Batch_Header.
    Bltbl_BatchHeader_Correction objBltbl_BatchHeader_Correction;
    tbl_BatchHeader_Correction objtbl_BatchHeader_Correction;

    //Create Object For Correction Challan_Detail
    Bltbl_ChallanDetails_Correction objBltbl_ChallanDetails_Correction;
    tbl_ChallanDetails_Correction objtbl_ChallanDetails_Correction;

    //Create Object For Correction Deductee Detail
    Bltbl_DeducteeDetails_Correction objBltbl_DeducteeDetails_Correction;
    tbl_DeducteeDetails_Correction objtbl_DeducteeDetails_Correction;

    //Create Object For Correction SalaryDetail
    Bltbl_SalaryDetails_Correction objBltbl_SalaryDetails_Correction;
    tbl_SalaryDetails_Correction objtbl_SalaryDetails_Correction;

    //Create Object For System_Config Class 
    Bltbl_System_Config objBltbl_System_Config;
    tbl_System_Config objtbl_System_Config;

    //Create Object For Import_Data
    Bltbl_Import_Data_Table objBltbl_Import_Data_Table;
    tbl_Import_Data_Table objtbl_Import_Data_Table;

    //Create the object of service to be consumed
    list.Service obj_Service;

    TextToDataSet objTextToDataSet;

    FillTableFromExcel objFillTableFromExcel;

    Bltbl_PathManagement objbltbl_PathManagement;
    tbl_PathManagement objtbl_PathManagement;

    public event EventHandler OkButtonClick;
    public event EventHandler CancelButtonClick;
    public event EventHandler CloseButtonClick;
    public event EventHandler AlertOkButtonClick;
    public static int countdeducteeRecord = 0;
    public static int countChallanRecord = 0;
    string ColumnNameTemplate, ColumnNameCompare;
    public static int Challan_Count = 0;
    public static int Deductee_Count = 0;
    public static int Table_index = 0;
    public static int Table_index_Excel = 0;
    public static int LineNumber = 0;
    public static int count_sal = 0;
    #endregion

    #region Page_Load and Import
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
        //Create the project name
        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;
        DynamicControl.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;
        string strConnectionString, strConnName;
        string strConnectionString_Admin, strConnName_Admin;
        strConnName = Application["DBEngine7"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;

        //Connection string For Admin
        strConnName_Admin = Application["DBEngine6"].ToString();
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[strConnName_Admin].ConnectionString;

        objBltbl_TANMaster = new Bltbl_TANMaster(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_TANMaster = new tbl_TANMaster();

        objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_FileHeader = new tbl_FileHeader();

        objBltbl_BatchHeader = new Bltbl_BatchHeader(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_BatchHeader = new tbl_BatchHeader();

        objBltbl_ChallanDetails = new Bltbl_ChallanDetails(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_ChallanDetails = new tbl_ChallanDetails();

        objBltbl_DeducteeDetail = new Bltbl_DeducteeDetail(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_DeducteeDetail = new tbl_DeducteeDetail();

        objBltbl_SalaryDetails = new Bltbl_SalaryDetails(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SalaryDetails = new tbl_SalaryDetails();

        objDBtbl_Module = new DBtbl_Module(strConnectionString, strConnName, strConnectionString_Admin);

        objBltbl_16A = new Bltbl_16A(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_16A = new tbl_16A();

        objBltbl_SectionVI_A = new Bltbl_SectionVI_A(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SectionVI_A = new tbl_SectionVI_A();

        objBltbl_BatchHeader_Correction = new Bltbl_BatchHeader_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_BatchHeader_Correction = new tbl_BatchHeader_Correction();

        objBltbl_ChallanDetails_Correction = new Bltbl_ChallanDetails_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_ChallanDetails_Correction = new tbl_ChallanDetails_Correction();

        objBltbl_DeducteeDetails_Correction = new Bltbl_DeducteeDetails_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_DeducteeDetails_Correction = new tbl_DeducteeDetails_Correction();

        objBltbl_SalaryDetails_Correction = new Bltbl_SalaryDetails_Correction(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SalaryDetails_Correction = new tbl_SalaryDetails_Correction();

        objBltbl_System_Config = new Bltbl_System_Config(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_System_Config = new tbl_System_Config();

        objBltbl_Import_Data_Table = new Bltbl_Import_Data_Table(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_Import_Data_Table = new tbl_Import_Data_Table();


        objTextToDataSet = new TextToDataSet(strConnectionString, strConnName,strConnectionString_Admin);


        objFillTableFromExcel = new FillTableFromExcel(strConnectionString, strConnName,strConnectionString_Admin);

        objtbl_PathManagement = new tbl_PathManagement();
        objbltbl_PathManagement = new Bltbl_PathManagement(strConnectionString_Admin, strConnName_Admin, strConnectionString_Admin);

        //Create the object of the Service to be consumed
        obj_Service = new list.Service();
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        if (!Page.IsPostBack)
        {
            countdeducteeRecord = 0;
            countChallanRecord = 0;
            countAnnualSalary = 0;
            Challan_Count = 0;
            Deductee_Count = 0;
            Table_index = 0;
            Table_index_Excel = 0;
            Count_index = 0;
            if (Session["Regular_Correction"] != null)
            {
                if (Session["Regular_Correction"].ToString() == "Correction_Import")
                {
                    lbl_ImportMsg.Text = "You Can Import .TDS  Files Only.";
                }
            }
        }

        //Create Event Handler For the Ok Button in Message box
        //msg_Pandiscre.btn_ok_click += new EventHandler(msg_Pandiscre_btn_ok_click);

        //msg_Pandiscre.btn_Cancel_click += new EventHandler(msg_Pandiscre_btn_Cancel_click);


    }

    public void msg_Pandiscre_btn_Cancel_click(object sender, EventArgs e)
    {

    }

    public void msg_Pandiscre_btn_ok_click(object sender, EventArgs e)
    {
        // mdl_PANGrid.Show();
    }
    //Click Event For the Upload Button
    protected void btn_SaveFile_Click(object sender, EventArgs e)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();

        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_Table = "";



        Count_16A = 0;
        Count_SectionVIA = 0;
        Challan_Count = 0;
        Deductee_Count = 0;
        int success = 0;

        CountDeductee = 0;
        index = 0;
        Table_index = 0;
        Table_index_Excel = 0;
        countChallan = 0;
        count_sal = 0;
        upload_File.Visible = true;
        //Get Name of the Uploaded File
        string FileName = upload_File.PostedFile.FileName.ToString();
        string Upload_filename = Path.GetFileName(upload_File.PostedFile.FileName.ToString());
        Session["Upload_FileName"] = Upload_filename;
        string Filepath = Server.MapPath("~/ImportedFile/" + FileName);
        Session["Filepath"] = Filepath;
        //Get Extension of the Uploaded File
        string FileExtension = Path.GetExtension(upload_File.FileName.ToString());
        Session["FileExtension"] = FileExtension;
        string Type = string.Empty;
        //Validate the Extension of the Uploaded File
        if (FileExtension == ".txt" || FileExtension == ".tds" || FileExtension == ".xlsx" || FileExtension == ".xls")
        {
            if (FileExtension == ".txt" || FileExtension == ".tds")
            {
                //Set the FilePath of the File to be Imported.
                //string Filepath = "D://"+FileName ;


                //Save the Uploaded File

                upload_File.PostedFile.SaveAs(Filepath);


                string[] arrBatchHeader = GetBatchHeaderData(Filepath);
                string TAN = arrBatchHeader[12].ToString();
                Session["TANImport"] = TAN.ToString();
                //Mudit
                Session["TAN"] = TAN.ToString();
                string FY = arrBatchHeader[16].ToString();
                Session["FYImport"] = FY.ToString();
                //Mudit
                Session["FY"] = FY.ToString();
                string Quarter = arrBatchHeader[17].ToString();
                Session["QuarterImport"] = Quarter.ToString();
                //Mudit
                Session["qtr"] = Quarter.ToString();
                string Form = arrBatchHeader[4].ToString();
                
                
                string FormNo = string.Empty;
                if (Form == "24Q")
                {
                    FormNo = "Form24Q";
                }
                else if (Form == "26Q")
                {
                    FormNo = "Form26Q";
                }
                else if (Form == "27Q")
                {
                    FormNo = "Form27Q";
                }
                else if (Form == "27EQ")
                {
                    FormNo = "Form27EQ";
                }
                Session["FormNoImport"] = FormNo.ToString();
                //Mudit
                Session["FormType"] = FormNo.ToString();

                string Regular_Correction = "Regular";

                string PAN = arrBatchHeader[14].ToString();
                Session["PANImport"] = PAN;
                //Mudit
                Session["PAN"] = PAN;

                string AName = arrBatchHeader[18].ToString();
                Session["ANameImport"] = AName.ToString();

                string AssessmentYear = arrBatchHeader[15].ToString();
                Session["AssessmentYearImport"] = AssessmentYear;
                //Mudit
                string AY=AssessmentYear.Insert(4,"-20");
                Session["AY"] = AY;


                string flagpopup = string.Empty;
                //Check Type Of Records
                if (FileExtension == ".txt")
                {
                    Type = "Regular";
                }
                else if (FileExtension == ".tds")
                {
                    Type = "Correction";
                    Session["NameID"] = Session["User_ID"].ToString();
                }
                Session["Regular_CorrectionImport"] = Type.ToString();
                

            }
            else if (FileExtension == ".xls" || FileExtension == ".xlsx")
            {
                countdeducteeRecord = 0;
                countChallanRecord = 0;
                countAnnualSalary = 0;
                Session["Regular_CorrectionImport"] = "Regular";

                //Get the Uploaded Excel File.
                string Uploaded_File = Server.MapPath("~/Upload/" + Upload_filename);

                upload_File.PostedFile.SaveAs(Uploaded_File);


            }
        }

        //Import Data 
        Import_Data(FileExtension, Filepath, Upload_filename);

    }
    //Function to Import Data 
    public void Import_Data(string FileExtension, string Filepath, string Upload_filename)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();

        DataTable dt_fh = new DataTable();
        DataTable dt_bh = new DataTable();
        DataTable dt_cd = new DataTable();
        DataTable dt_dd = new DataTable();
        DataTable dt_sd = new DataTable();
        DataTable dt_c6A = new DataTable();
        DataTable dt_16 = new DataTable();
        DataSet ds = new DataSet();
        string successFlag = "N";
        string DateValid = "N";
        string Panmatched = "N";
        string Valid_DeducteeAmount = "N";
        //Validate the Extension of the Uploaded File
        if (FileExtension == ".txt" || FileExtension == ".tds" || FileExtension == ".xlsx" || FileExtension == ".xls")
        {
            if (FileExtension == ".txt" || FileExtension == ".tds")
            {
                //Set the FilePath of the File to be Imported.
                //string Filepath = "D://"+FileName ;

                //Read the Data From Uploaded File
                StreamReader sr = new StreamReader(Filepath, false);
                string[] arrBatchHeader = GetBatchHeaderData(Filepath);

                int count = 0;
                int i = 0;


                //Create Parmeter For Checking the Existence of the Master Record
                objtbl_FileHeader.TAN = Session["TANImport"].ToString();
                objtbl_FileHeader.Quarter = Session["QuarterImport"].ToString();
                objtbl_FileHeader.FormType = Session["FormNoImport"].ToString();
                objtbl_FileHeader.FinancialYear = Session["FYImport"].ToString();
                int FinancialYear = Convert.ToInt32(Session["FYImport"]);
                objtbl_FileHeader.Regular_Correction = Session["Regular_CorrectionImport"].ToString();

                string Type = Session["Regular_CorrectionImport"].ToString();
                bool ISExist = objBltbl_FileHeader.CheckMasterTableExistence(objtbl_FileHeader);
                Session["ISExistMaster"]=ISExist.ToString();
                string ismaster = Session["ISExistMaster"].ToString();
                if (ISExist == true)
                {
                    string Message_OverWrite_SuccessFully = obj_Service.Get_Message("btn_SaveFile2", "2", "3");
                    msg_alert.Confirm(Message_OverWrite_SuccessFully);
                }
                else
                {
                    //Get the PANList Table
                    DataTable dt_PAN = new DataTable();
                    dt_PAN = objBltbl_DeducteeDetail.Get_PAN();
                    while (sr.Peek() >= 0)
                    {


                        string line = string.Empty;

                        string BH = sr.ReadLine();

                        string[] arrLine = (string[])BH.Split('^');

                        string TypeOfRecord = arrLine[1].ToString();


                        if (ISExist == false)
                        {

                            if (TypeOfRecord == "FH")
                            {
                                if (dt_fh.Rows.Count == 0)
                                {
                                    Update_Flag = "F";
                                    ViewState["Type"] = "FH";

                                    InsertMasterTable(Type);
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers();

                                    DBtbl_Module.ArrayIndex = 0;
                                    DBtbl_Module.Previous_RecordNo = 0;
                                    DBtbl_Module.lst_Query = new List<string>();
                                    DBtbl_Module.lst_Field = new Dictionary<string, int>();
                                    DBtbl_Module.lst_update = new List<string[]>();
                                    DBtbl_Module.Previous_Table = "";

                                    dt_fh = InsertFileHeaderTable(Filepath, Type);

                                    ds.Tables.Add(dt_fh);
                                    if (Type == "Regular")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_File_Header_Record";
                                    }
                                    else if (Type == "Correction")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_File_Header_Record_Correction";
                                    }
                                    Table_index = Table_index + 1;
                                }

                            }
                            else if (TypeOfRecord == "BH")
                            {
                                if (dt_bh.Rows.Count == 0)
                                {

                                    ViewState["Type"] = "BH";

                                    dt_bh = InsertBatchHeader(Filepath, Type);
                                    objtbl_TANMaster.TAN = ViewState["TAN"].ToString();
                                    bool IS_NotExist = objBltbl_TANMaster.CheckRecordExistence(objtbl_TANMaster);
                                    if (IS_NotExist)
                                    {
                                        InsertTANMaster(dt_bh);
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();

                                        DBtbl_Module.ArrayIndex = 0;
                                        DBtbl_Module.Previous_RecordNo = 0;
                                        DBtbl_Module.lst_Query = new List<string>();
                                        DBtbl_Module.lst_Field = new Dictionary<string, int>();
                                        DBtbl_Module.lst_update = new List<string[]>();
                                        DBtbl_Module.Previous_Table = "";

                                    }
                                    else
                                    {
                                        //Ask the User and Update the TANMaster if there is Difference
                                        string TAN = string.Empty;
                                        int ID = 0;
                                        TAN = dt_bh.Rows[0]["Tan_of_Employee"].ToString();
                                        ID = Convert.ToInt32(dt_bh.Rows[0]["ID"]);
                                        bool IS_Matched = objBltbl_TANMaster.CompareTANData_Correction(TAN, ID, Type);
                                        if (!IS_Matched)
                                        {
                                            Update_Flag = "F";
                                            //There is Difference Between TANMaster and BatchHeader Record.Do you want to Update TANMaster
                                        }

                                    }

                                    ds.Tables.Add(dt_bh);
                                    if (Type == "Regular")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_Batch_Header_Record";
                                    }
                                    else if (Type == "Correction")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_Batch_Header_Record_Correction";
                                    }
                                    Table_index = Table_index + 1;
                                    //Update_Master();
                                    //Update_File_Header();
                                }
                            }
                            else if (TypeOfRecord == "CD")
                            {

                                if (dt_cd.Rows.Count == 0)
                                {
                                    Update_Flag = "F";
                                    ViewState["Type"] = "CD";

                                    dt_cd = InsertChallanDetails(Filepath, Type);
                                    Session["Data_CD"] = dt_cd;
                                    ds.Tables.Add(dt_cd);
                                    if (Type == "Regular")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_ChallanTransferVoucherDetail";

                                    }
                                    else if (Type == "Correction")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_ChallanTransferVoucherDetail_Correction";
                                    }

                                    Table_index = Table_index + 1;
                                }
                            }
                            else if (TypeOfRecord == "DD")
                            {

                                if (dt_dd.Rows.Count == 0)
                                {
                                    Update_Flag = "F";
                                    ViewState["Type"] = "DD";

                                    dt_dd = InsertDeducteeDetails(Filepath, Type);

                                    ds.Tables.Add(dt_dd);
                                    if (Type == "Regular")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_DeducteeDetail_Record";
                                    }
                                    else if (Type == "Correction")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_DeducteeDetail_Record_Correction";
                                    }

                                    Table_index = Table_index + 1;
                                }
                            }
                            else if (TypeOfRecord == "SD")
                            {
                                if (dt_sd.Rows.Count == 0)
                                {
                                    Update_Flag = "F";
                                    ViewState["Type"] = "SD";
                                    dt_sd = InsertSalaryDetails(Filepath, Type);
                                    ds.Tables.Add(dt_sd);
                                    if (Type == "Regular")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_SalaryDetailsRecords";
                                    }
                                    else if (Type == "Correction")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_SalaryDetailsRecords_Correction";
                                    }


                                    Table_index = Table_index + 1;
                                }

                            }
                            else if (TypeOfRecord == "C6A")
                            {
                                if (dt_c6A.Rows.Count == 0)
                                {
                                    Update_Flag = "F";
                                    ViewState["Type"] = "C6A";
                                    dt_c6A = InsertSectionSixA(Filepath, Type);
                                    ds.Tables.Add(dt_c6A);
                                    if (Type == "Regular")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_SectionVIA";
                                    }
                                    else if (Type == "Correction")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_SectionVIA_Correction";
                                    }

                                    Table_index = Table_index + 1;
                                }

                            }
                            else if (TypeOfRecord == "S16")
                            {
                                if (dt_16.Rows.Count == 0)
                                {
                                    Update_Flag = "F";

                                    ViewState["Type"] = "S16";
                                    dt_16 = Insert16A(Filepath, Type);
                                    ds.Tables.Add(dt_16);
                                    if (Type == "Regular")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_16A";
                                    }
                                    else if (Type == "Correction")
                                    {
                                        ds.Tables[Table_index].TableName = "tbl_16A_Correction";
                                    }

                                    Table_index = Table_index + 1;
                                }
                            }

                            successFlag = "Y";

                        }
                        else
                        {

                            successFlag = "N";
                        }
                        if (Update_Flag == "T")
                        {

                            string Message_Update_TAN = obj_Service.Get_Message("btn_SaveFile", "2", "3");

                            msg_Imp.Confirm(Message_Update_TAN);


                        }

                    }//Loop of Making DataTable From TextFile Ends Here.
                    //Check if the Date On Which Amount Paid  is Falling within Quarter 
                    DataTable dt_InvalidDates = new DataTable();


                    if (ds.Tables.Count != 0)
                    {

                        bool Is_Date_Valid = false;
                        bool Is_Total_Tax_Deposited_Deductee_Valid = false;
                        string Date_On_Which_AmountPaid = string.Empty;

                        string FY = Convert.ToString(FinancialYear);
                        dt_InvalidDates = ds.Tables[3].Clone();
                        dt_InvalidDates.Clear();
                        string[] valid_Date = new string[ds.Tables[3].Rows.Count];
                        foreach (DataRow dr in ds.Tables[3].Rows)
                        {
                            //Validation on Date_On_Which_AmountPaid
                            Date_On_Which_AmountPaid = dr["DateOnWhich_AMTPaid"].ToString();
                            Date_On_Which_AmountPaid = Date_On_Which_AmountPaid.Replace("/", "");
                            Date_On_Which_AmountPaid = Date_On_Which_AmountPaid.Replace("-", "");
                            int count_deduc = ds.Tables[3].Rows.Count;


                            if (Date_On_Which_AmountPaid != "")
                            {
                                CheckDateByQuarter(Date_On_Which_AmountPaid, FY, dr, dt_InvalidDates, count_deduc);
                            }

                        }
                        string[] arr_ComparePAN = new string[ds.Tables[3].Rows.Count];
                        //string[,] arr_matchedpan = new string[ds.Tables["tbl_DeducteeDetail_Record"].Rows.Count, ds.Tables["tbl_DeducteeDetail_Record"].Rows.Count];
                        int count_pan = 0;
                        //int count_index2 = 0;
                        //DataTable dt_Pandiscrepancy = new DataTable();
                        ////dt_Pandiscrepancy=dt_PAN.Clone();
                        ////dt_Pandiscrepancy.Clear();
                        ////Add Name of the Deductee
                        //DataColumn dt_Nameofdeductee = new DataColumn("Name of Deductee", typeof(string));
                        //dt_Pandiscrepancy.Columns.Add(dt_Nameofdeductee);
                        ////Add Existing Pan Column
                        //DataColumn dt_ExistingPAN = new DataColumn("Existing PAN", typeof(string));
                        //dt_Pandiscrepancy.Columns.Add(dt_ExistingPAN);
                        ////Add Imported Pan Column
                        //DataColumn dt_ImportedPAN = new DataColumn("Imported PAN", typeof(string));
                        //dt_Pandiscrepancy.Columns.Add(dt_ImportedPAN);
                        //foreach (DataRow drCompare in ds.Tables[3].Rows)
                        //{

                        //    string Name = drCompare["NameofEmployee_Party"].ToString();
                        //    string PAN_Deductee = drCompare["EmployeePAN"].ToString();
                        //    DataRow[] dr_Pan = dt_PAN.Select("Name_of_Deductee='" + Name + "'");
                        //    if (dr_Pan.Count() != 0)
                        //    {
                        //        DataRow dr_finrow = dt_Pandiscrepancy.NewRow();
                        //        count_pan = count_pan + 1;
                        //        string PAN_TAble = dr_Pan[0]["PAN"].ToString();
                        //        //Compare the Pans From Two Tables
                        //        if (PAN_TAble != PAN_Deductee)
                        //        {
                        //            arr_ComparePAN[count_pan] = "Y";
                        //            dr_finrow["Existing PAN"] = PAN_TAble;
                        //            dr_finrow["Imported PAN"] = PAN_Deductee;
                        //            dr_finrow["Name of Deductee"] = Name;
                        //            dt_Pandiscrepancy.Rows.Add(dr_finrow);
                        //            //arr_matchedpan[count_pan, count_index2] = Name + "," + PAN_Deductee;

                        //            //count_index2 = count_index2 + 1;
                        //        }
                        //        else
                        //        {
                        //            arr_ComparePAN[count_pan] = "N";
                        //        }

                        //    }
                        //}
                        //if (arr_ComparePAN.Contains("Y"))
                        //{
                        //    Panmatched = "Y";
                        //    //grd_PanDiscrepancies.DataSource = dt_Pandiscrepancy;
                        //    //grd_PanDiscrepancies.DataBind();
                        //}
                        //else
                        //{
                        //    Panmatched = "N";
                        //}
                        int Count_challan = 0;
                        string[] arr_Valid = new string[ds.Tables[3].Rows.Count];
                        foreach (DataRow drCD in ds.Tables[2].Rows)
                        {
                            int ChallanID = Convert.ToInt32(drCD["ChallanID"]);
                            Count_challan = Count_challan + 1;


                            Double Total_Tax_Deposited_Challan = Convert.ToDouble(drCD["TotalDepositeAmount"]);
                            //Double Total_Tax_Deposited_Deductee = Convert.ToDouble(ds_Excel.Tables["tbl_DeducteeDetail_Record"].Compute("Sum(Total_TaxDeposited)","ID="+ChallanID+""));

                            var Total_Tax_Deposited_Deductee = ds.Tables[3].AsEnumerable().Where(row => (row.Field<string>("ID") == "" + ChallanID + "")).Sum(row => Convert.ToDecimal(row["Total_TaxDeposited"]));
                            Double Total_tax_Deposited_deduc = Convert.ToDouble(Total_Tax_Deposited_Deductee);
                            Count_challan = Count_challan - 1;
                            if (Total_tax_Deposited_deduc <= Total_Tax_Deposited_Challan)
                            {
                                arr_Valid[Count_challan] = "Y";
                            }
                            else
                            {
                                arr_Valid[Count_challan] = "N";
                            }
                            ViewState["array"] = arr_Valid;

                        }

                        string[] arr = (string[])ViewState["array"];
                        ViewState["InvalidDates"] = dt_InvalidDates;

                        if (dt_InvalidDates.Rows.Count == 0)
                        {
                            if (!arr.Contains("N"))
                            {
                                Valid_DeducteeAmount = "N";
                                //IMPORTING DATA TO DATASERVER
                                //Declare the main error list
                                DataTable dt_mainErrorList = new DataTable();

                                //Declare InValid Pan Error List
                                DataTable arr_INValidPANList = new DataTable();
                                DataTable dt_Deductee = ds.Tables[3];
                                arr_INValidPANList = Get_Error_List(dt_Deductee, "ValidatePAN", Session["FormNoImport"].ToString());
                                dt_mainErrorList = arr_INValidPANList.Clone();
                                dt_mainErrorList.Clear();
                                //Declare the InValid PAN Length Error List
                                DataTable arr_INValidPANLengthList = new DataTable();
                                arr_INValidPANLengthList = Get_Error_List(dt_Deductee, "ValidatePANLength", Session["FormNoImport"].ToString());
                                //Declare the Empty Name List
                                DataTable arr_EmptyNameList = new DataTable();
                                arr_EmptyNameList = Get_Error_List(dt_Deductee, "ValidateEmptyField", Session["FormNoImport"].ToString());

                                //Concatenate  the Lists to main error list if any of them contains error
                                if (arr_INValidPANList.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in arr_INValidPANList.Rows)
                                    {
                                        dt_mainErrorList.ImportRow(dr);
                                    }
                                }
                                if (arr_INValidPANLengthList.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in arr_INValidPANLengthList.Rows)
                                    {
                                        dt_mainErrorList.ImportRow(dr);
                                    }
                                }
                                if (arr_EmptyNameList.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in arr_EmptyNameList.Rows)
                                    {
                                        dt_mainErrorList.ImportRow(dr);
                                    }
                                }
                                if (dt_mainErrorList.Rows.Count != 0)
                                {
                                    Build(dt_mainErrorList);
                                }
                                else
                                {
                                    if (Type == "Regular")
                                    {
                                        objBltbl_Import_Data_Table.Import_Data(ds);
                                    }
                                    else if (Type == "Correction")
                                    {
                                        //Delete the Records From Regular Table According to the Credentials given.
                                        objtbl_FileHeader.TAN = Session["TANImport"].ToString();
                                        objtbl_FileHeader.Quarter = Session["QuarterImport"].ToString();
                                        objtbl_FileHeader.FormType = Session["FormNoImport"].ToString();
                                        objtbl_FileHeader.FinancialYear = Session["FYImport"].ToString();

                                        objtbl_FileHeader.Regular_Correction = "Regular";
                                        //Get MasterID For Regular_Module
                                        int Master_ID = objBltbl_FileHeader.GetIDFromMaster(objtbl_FileHeader);
                                        objtbl_ChallanDetails.ID = Master_ID;
                                        objtbl_DeducteeDetail.MasterID = Master_ID;
                                        objtbl_FileHeader.ID = Master_ID;
                                        objtbl_BatchHeader.ID = Master_ID;
                                        //If Master Id Exist Delete the Record From the Regular Table
                                        if (Master_ID != 0)
                                        {
                                            //Delete the Record From Challan By Master ID
                                            int success_FileHeader = objBltbl_FileHeader.Delete_File_Header(objtbl_FileHeader);
                                            int success_BatchHeader = objBltbl_BatchHeader.DeleteBH_By_MasterID(objtbl_BatchHeader);
                                            int success_challan = objBltbl_ChallanDetails.DeleteChallanByMasterID(objtbl_ChallanDetails);
                                            int success_deductee = objBltbl_DeducteeDetail.DeleteDeducteeByMasterID(objtbl_DeducteeDetail);
                                            //if (success_challan == 1 && success_deductee == 1 && success_FileHeader==1 && success_BatchHeader==1)
                                            //{
                                            DataSet ds_Regular = new DataSet();
                                            for (int n = 0; n < ds.Tables.Count; n++)
                                            {
                                                ds_Regular.Tables.Add(ds.Tables[n].Copy());
                                            }

                                            ds_Regular.Tables[0].TableName = "tbl_File_Header_Record";
                                            //Enter the File Sequence No In File Header if File_Seq is Empty.
                                            string File_Seq = ds_Regular.Tables[0].Rows[0]["File_Seq_No"].ToString();



                                            if (File_Seq == "")
                                            {
                                                ds_Regular.Tables[0].Rows[0]["File_Seq_No"] = 1;

                                            }
                                            ds_Regular.Tables[0].Rows[0]["ID"] = Master_ID;
                                            ds_Regular.Tables[1].TableName = "tbl_Batch_Header_Record";
                                            ds_Regular.Tables[1].Rows[0]["ID"] = Master_ID;
                                            ds_Regular.Tables[2].TableName = "tbl_ChallanTransferVoucherDetail";
                                            foreach (DataRow row in ds_Regular.Tables[2].Rows)
                                            {
                                                row["ID"] = Master_ID;
                                                row["Filler2"] = "";
                                                row["Filler3"] = "";

                                            }
                                            ds_Regular.Tables[3].TableName = "tbl_DeducteeDetail_Record";
                                            foreach (DataRow row in ds_Regular.Tables[3].Rows)
                                            {
                                                row["MasterID"] = Master_ID;

                                            }
                                            if (ds_Regular.Tables.Contains("tbl_SalaryDetailsRecords_Correction"))
                                            {
                                                ds_Regular.Tables[4].TableName = "tbl_SalaryDetailsRecords";
                                                if (ds_Regular.Tables.Contains("tbl_SectionVIA_Correction"))
                                                {
                                                    ds_Regular.Tables[5].TableName = "tbl_SectionVIA";
                                                }
                                                if (ds_Regular.Tables.Contains("tbl_16A_Correction"))
                                                {
                                                    ds_Regular.Tables[6].TableName = "tbl_16A";
                                                }
                                            }

                                            objBltbl_Import_Data_Table.Import_Data(ds_Regular);
                                            objBltbl_Import_Data_Table.Import_Data(ds);

                                        }
                                        else
                                        {
                                            //Insert an New Master ID For the Regular Record

                                            //Created New Master ID
                                            InsertMasterTable("Regular");

                                            //get the New master ID
                                            objtbl_FileHeader.TAN = Session["TANImport"].ToString();
                                            objtbl_FileHeader.Quarter = Session["QuarterImport"].ToString();
                                            objtbl_FileHeader.FormType = Session["FormNoImport"].ToString();
                                            objtbl_FileHeader.FinancialYear = Session["FYImport"].ToString();
                                            objtbl_FileHeader.Regular_Correction = "Regular";
                                            int NewMasterID = objBltbl_FileHeader.GetIDFromMaster(objtbl_FileHeader);

                                            DataSet ds_Regular = ds;
                                            ds_Regular.Tables[0].TableName = "tbl_File_Header_Record";
                                            //Enter the File Sequence No In File Header if File_Seq is Empty.
                                            string File_Seq = ds_Regular.Tables[0].Rows[0]["File_Seq_No"].ToString();


                                            ds_Regular.Tables[0].Rows[0]["ID"] = NewMasterID;
                                            if (File_Seq == "")
                                            {
                                                ds_Regular.Tables[0].Rows[0]["File_Seq_No"] = 1;

                                            }
                                            ds_Regular.Tables[1].TableName = "tbl_Batch_Header_Record";
                                            ds_Regular.Tables[1].Rows[0]["ID"] = NewMasterID;
                                            ds_Regular.Tables[2].TableName = "tbl_ChallanTransferVoucherDetail";

                                            //Remove Unwanted Field from Challan DataTable
                                            foreach (DataRow row in ds_Regular.Tables[2].Rows)
                                            {
                                                row["ID"] = NewMasterID;
                                                row["Filler2"] = "";
                                                row["Filler3"] = "";

                                            }
                                            ds_Regular.Tables[3].TableName = "tbl_DeducteeDetail_Record";
                                            foreach (DataRow row in ds_Regular.Tables[3].Rows)
                                            {
                                                row["MasterID"] = NewMasterID;

                                            }
                                            objBltbl_Import_Data_Table.Import_Data(ds_Regular);
                                            objBltbl_Import_Data_Table.Import_Data(ds);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Valid_DeducteeAmount = "Y";

                            }
                            DateValid = "N";
                        }
                        else
                        {
                            DateValid = "Y";

                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + Message_DateValid_SuccessFully + "');", true);
                        }
                    }


                    sr.Close();
                    sr.Dispose();

                    //if (Panmatched == "Y")
                    //{
                    //   // msg_placeholder.Attributes.Remove("style");
                    //}
                    //else
                    //{

                    if (DateValid == "N")
                    {
                        if (Valid_DeducteeAmount == "N")
                        {
                            if (successFlag == "Y")
                            {
                                string Message_Imported_SuccessFully = obj_Service.Get_Message("btn_SaveFile1", "2", "3");
                                msg_confirm.Confirm(Message_Imported_SuccessFully);
                            }
                            else if (successFlag == "N")
                            {
                                string Message_OverWrite_SuccessFully = obj_Service.Get_Message("btn_SaveFile2", "2", "3");
                                msg_alert.Confirm(Message_OverWrite_SuccessFully);
                            }
                        }
                        else if (Valid_DeducteeAmount == "Y")
                        {
                            string Message_TotalTaxDeposited_SuccessFully = obj_Service.Get_Message("btn_SaveFile6", "2", "3");

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + Message_TotalTaxDeposited_SuccessFully + "');", true);
                        }
                    }
                    else if (DateValid == "Y")
                    {
                        string Message_DateValid_SuccessFully = obj_Service.Get_Message("btn_SaveFile5", "2", "3");
                        msg_Valid_Date.Confirm(Message_DateValid_SuccessFully);
                    }
                    //}

                }
            }
            else if (FileExtension == ".xls" || FileExtension == ".xlsx")
            {
                successFlag = "";
                DataTable dt_ChallanDetails = new DataTable();
                DataTable dt_DeducteeDetails = new DataTable();
                DataTable dt_FileHeader = new DataTable();
                DataSet ds_Excel = new DataSet();
                string Uploaded_File = Server.MapPath(@"~/Upload/" + Upload_filename);

                //Create Connection for the Uploaded file
                string strConnectionString2 = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Uploaded_File + ";Extended Properties=Excel 12.0;";
                OleDbConnection con2 = new OleDbConnection(strConnectionString2);


                //Get the SheetName For the Uploaded File


                String[] ExcelSheetNames = GetExcelSheetName(con2, Upload_filename);
                string SheetName_UploadedFile = string.Empty;

                DataTable dtCompare = new DataTable();
                DataSet ds_UploadedFile = new DataSet();

                for (int i = 0; i < ExcelSheetNames.Length; i++)
                {
                    //Get the SheetName of the Uploaded File
                    SheetName_UploadedFile = ExcelSheetNames[i].ToString();

                    //DataTable of the uploaded and Template Excel.

                    dtCompare = GetDataTableofCompareExcel(SheetName_UploadedFile, Uploaded_File);
                    //Create DataSet for  the Template and Uploaded File


                    //Add the Excel Table to the Dataset
                    if (SheetName_UploadedFile == "'DEDUCTORS DETAIL$'")
                    {
                        ds_UploadedFile.Tables.Add(dtCompare);
                    }
                    else if (SheetName_UploadedFile == "'CHALLAN DETAIL$'")
                    {
                        ds_UploadedFile.Tables.Add(dtCompare);

                    }
                    else if (SheetName_UploadedFile == "DEDUCTEEDETAIL$")
                    {
                        ds_UploadedFile.Tables.Add(dtCompare);


                    }

                    else if (SheetName_UploadedFile == "'SALARY DETAIL$'")
                    {
                        ds_UploadedFile.Tables.Add(dtCompare);

                    }

                }

                DataTable dt_Deductor = new DataTable();
                dt_Deductor = ds_UploadedFile.Tables[2];
                //Create FormNo Parameter
                string FormNo = dt_Deductor.Rows[1][1].ToString();
                //string FormNo = "Form27Q";
                ViewState["FormType"] = FormNo;
                Session["FormNoImport"] = FormNo;
                //Create TAN Parameter
                string TAN = dt_Deductor.Rows[0][1].ToString();
                ViewState["TAN"] = TAN;
                Session["TANImport"] = TAN;
                //Create Quarter Parameter
                string Quarter = dt_Deductor.Rows[3][1].ToString();
                ViewState["Quarter"] = Quarter;
                Session["QuarterImport"] = Quarter;
                //Create AssessmentYear Parameter.
                string AssessmentYear = dt_Deductor.Rows[2][1].ToString();
                AssessmentYear = AssessmentYear.Replace("-", "");
                Session["AssessmentYearImport"] = AssessmentYear;

                //Create Financial Year Parameter
                int FinancialYear = Convert.ToInt32(AssessmentYear) - 101;
                Session["FYImport"] = FinancialYear;
                ViewState["FY"] = FinancialYear;

                //Create PAN Parameter
                string PAN = dt_Deductor.Rows[4][1].ToString();
                Session["PANImport"] = PAN;

                //Create AName Parameter
                string AName = dt_Deductor.Rows[5][1].ToString();
                Session["ANameImport"] = AName;
                string Regular_Correction = "Regular";
                string filename = string.Empty;
                string sheetName = string.Empty;
                //Create Parameters For Checking the Existence of Record in Database
                objtbl_FileHeader.TAN = TAN;
                objtbl_FileHeader.Quarter = Quarter;
                objtbl_FileHeader.FormType = FormNo;
                objtbl_FileHeader.FinancialYear = FinancialYear.ToString();
                objtbl_FileHeader.Regular_Correction = Regular_Correction;
                //Check the Existence of the Records in Database
                bool ISExist = objBltbl_FileHeader.CheckMasterTableExistence(objtbl_FileHeader);
                Session["ISExistMaster"] = ISExist.ToString();
                string path = string.Empty;
                string Uploaded_Path = string.Empty;
                if (!ISExist)
                {
                    if (FormNo == "Form24Q" && Quarter == "Q4")
                    {
                        //Get the SheetName Dynamically from ExcelSheet.
                        filename = Server.MapPath("~/ExcelSheetTemplate/Template24Q4.xsd");
                        path = Server.MapPath("~/Uploaded_Xml/Template24Q4.xml");
                    }
                    else if (FormNo == "Form24Q" && Quarter != "Q4")
                    {
                        filename = Server.MapPath("~/ExcelSheetTemplate/Template26.xsd");
                        path = Server.MapPath("~/Uploaded_Xml/Template24.xml");
                    }
                    else if (FormNo == "Form26Q")
                    {
                        filename = Server.MapPath("~/ExcelSheetTemplate/Template26.xsd");
                        path = Server.MapPath("~/Uploaded_Xml/Template26.xml");
                    }
                    else if (FormNo == "Form27Q")
                    {
                        filename = Server.MapPath("~/ExcelSheetTemplate/Template26.xsd");
                        path = Server.MapPath("~/Uploaded_Xml/Template27.xml");
                    }
                    else if (FormNo == "Form27EQ")
                    {
                        filename = Server.MapPath("~/ExcelSheetTemplate/Template27EQ.xsd");
                        path = Server.MapPath("~/Uploaded_Xml/Template27EQ.xml");
                    }
                    StreamReader sr = new StreamReader(filename);
                    XmlSchema xsd = XmlSchema.Read(sr, null);
                    sr.Close();

                    //output it into string
                    StringWriter sw = new StringWriter();
                    xsd.Write(sw);
                    string Template_Schema = sw.ToString();

                    //DiffGram

                    string diffFile = Server.MapPath("~/Uploaded_Xml/vxd.out");
                    XmlTextWriter tw = new XmlTextWriter(new StreamWriter(diffFile));
                    tw.Formatting = Formatting.Indented;

                    ds_UploadedFile.WriteXmlSchema(path);
                    string Template_File = string.Empty;
                    string Uploaded_Temp_File = string.Empty;
                    if (FormNo == "Form24Q" && Quarter == "Q4")
                    {
                        Template_File = Server.MapPath("~/ExcelSheetTemplate/Template24Q4.xml");
                        Uploaded_Temp_File = Server.MapPath("~/Uploaded_Xml/Template24Q4.xml");

                    }
                    else if (FormNo == "Form24Q" && Quarter != "Q4")
                    {
                        Template_File = Server.MapPath("~/ExcelSheetTemplate/Template24.xml");
                        Uploaded_Temp_File = Server.MapPath("~/Uploaded_Xml/Template24.xml");

                    }
                    else if (FormNo == "Form26Q")
                    {
                        Template_File = Server.MapPath("~/ExcelSheetTemplate/Template26.xml");
                        Uploaded_Temp_File = Server.MapPath("~/Uploaded_Xml/Template26.xml");
                    }
                    else if (FormNo == "Form27Q")
                    {
                        Template_File = Server.MapPath("~/ExcelSheetTemplate/Template27.xml");
                        Uploaded_Temp_File = Server.MapPath("~/Uploaded_Xml/Template27.xml");

                    }
                    else if (FormNo == "Form27EQ")
                    {
                        Template_File = Server.MapPath("~/ExcelSheetTemplate/Template27EQ.xml");
                        Uploaded_Temp_File = Server.MapPath("~/Uploaded_Xml/Template27EQ.xml");
                    }
                    //string Uploaded_File_Schema=


                    //bool Is_TemplateMatched = string.Equals(Template_Schema,Uploaded_File_Schema);
                    bool bIdentical = GenerateDiffGram(Template_File, Uploaded_Temp_File, tw);
                    //Read_Data_From_Xml(diffFile);
                    //Get the DataType of Mis Match Data


                    //if (bIdentical)
                    //{

                    //Create Master Table
                    objtbl_TANMaster.TAN = TAN;
                    bool IS_TANExist = objBltbl_TANMaster.CheckRecordExistence(objtbl_TANMaster);
                    // InsertBatchHeader_Excel(dtCompare);
                    if (IS_TANExist)
                    {
                        InsertTANMaster_Excel(ds_UploadedFile.Tables[2]);
                    }

                    //Create Challan Table
                    InsertMasterTable_Excel();
                    DataTable dt_CD = ds_UploadedFile.Tables[0];
                    for (int j = 0; j < dt_CD.Rows.Count; j++)
                    {
                        if (dt_CD.Rows[j][0].ToString() == "")
                        {
                            dt_CD.Rows.RemoveAt(j);
                        }
                    }
                    dt_ChallanDetails = InsertChallanDetails_Excel(ds_UploadedFile.Tables[0], FormNo);
                    ds_Excel.Tables.Add(dt_ChallanDetails);
                    ds_Excel.Tables[Table_index_Excel].TableName = "tbl_ChallanTransferVoucherDetail";
                    Table_index_Excel = Table_index_Excel + 1;

                    //Create Deductee Table
                    DataTable dtDD = new DataTable();
                    dtDD = ds_UploadedFile.Tables[1];
                    dt_DeducteeDetails = InsertDeducteeDetails_Excel(dtDD, FormNo);
                    ds_Excel.Tables.Add(dt_DeducteeDetails);
                    ds_Excel.Tables[Table_index_Excel].TableName = "tbl_DeducteeDetail_Record";
                    Table_index_Excel = Table_index_Excel + 1;
                    if (FormNo == "Form24Q" && Quarter == "Q4")
                    {
                        DataSet ds_Sal = new DataSet();
                        DataTable dt_Sal = new DataTable();
                        DataTable dt_Sec = new DataTable();
                        DataTable dt_16_Excel = new DataTable();

                        ds_Sal = InsertAnnualSalaryDetail_Excel(ds_UploadedFile.Tables[3]);
                        dt_Sal = ds_Sal.Tables[0];
                        dt_Sec = ds_Sal.Tables[1];
                        dt_16_Excel = ds_Sal.Tables[2];
                        ds_Sal.Tables.Remove(dt_Sal);
                        ds_Sal.Tables.Remove(dt_Sec);
                        ds_Sal.Tables.Remove(dt_16_Excel);
                        //Add Salary Detail Table To Import
                        ds_Excel.Tables.Add(dt_Sal);
                        ds_Excel.Tables[Table_index_Excel].TableName = "tbl_SalaryDetailsRecords";
                        Table_index_Excel = Table_index_Excel + 1;

                        //Add Section Table To Import
                        ds_Excel.Tables.Add(dt_Sec);
                        ds_Excel.Tables[Table_index_Excel].TableName = "tbl_SectionVIA";
                        Table_index_Excel = Table_index_Excel + 1;

                        //Add 16A Table To Import
                        ds_Excel.Tables.Add(dt_16_Excel);
                        ds_Excel.Tables[Table_index_Excel].TableName = "tbl_16A";
                        Table_index_Excel = Table_index_Excel + 1;
                    }

                    //Check if the Date On Which Amount Paid  is Falling within Quarter 
                    bool Is_Date_Valid = false;
                    bool Is_Total_Tax_Deposited_Deductee_Valid = false;
                    string Date_On_Which_AmountPaid = string.Empty;

                    string FY = Convert.ToString(FinancialYear);
                    DataTable dt_InvalidDates = ds_Excel.Tables["tbl_DeducteeDetail_Record"].Clone();
                    dt_InvalidDates.Clear();
                    string[] valid_Date = new string[ds_Excel.Tables["tbl_DeducteeDetail_Record"].Rows.Count];
                    foreach (DataRow dr in ds_Excel.Tables["tbl_DeducteeDetail_Record"].Rows)
                    {
                        //Validation on Date_On_Which_AmountPaid
                        Date_On_Which_AmountPaid = dr["DateOnWhich_AMTPaid"].ToString();
                        Date_On_Which_AmountPaid = Date_On_Which_AmountPaid.Replace("/", "");
                        Date_On_Which_AmountPaid = Date_On_Which_AmountPaid.Replace("-", "");
                        int count = ds_Excel.Tables["tbl_DeducteeDetail_Record"].Rows.Count;


                        if (Date_On_Which_AmountPaid != "")
                        {
                            CheckDateByQuarter(Date_On_Which_AmountPaid, FY, dr, dt_InvalidDates, count);
                        }

                    }

                    int Count_challan = 0;
                    string[] arr_Valid = new string[ds_Excel.Tables["tbl_DeducteeDetail_Record"].Rows.Count];
                    foreach (DataRow drCD in ds_Excel.Tables["tbl_ChallanTransferVoucherDetail"].Rows)
                    {
                        int ChallanID = Convert.ToInt32(drCD["ChallanID"]);
                        Count_challan = Count_challan + 1;


                        Double Total_Tax_Deposited_Challan = (drCD["TotalDepositeAmount"].ToString() == "") ? Convert.ToDouble(string.Format("0.00", drCD["TotalDepositeAmount"])) : Convert.ToDouble(drCD["TotalDepositeAmount"]);
                        //Double Total_Tax_Deposited_Deductee = Convert.ToDouble(ds_Excel.Tables["tbl_DeducteeDetail_Record"].Compute("Sum(Total_TaxDeposited)","ID="+ChallanID+""));

                        var Total_Tax_Deposited_Deductee = ds_Excel.Tables["tbl_DeducteeDetail_Record"].AsEnumerable().Where(row => (row.Field<string>("ID") == "" + ChallanID + "")).Sum(row => (drCD["TotalDepositeAmount"].ToString() == "") ? Convert.ToDouble(string.Format("0.00", row["Total_TaxDeposited"])) : Convert.ToDouble(row["Total_TaxDeposited"]));
                        Double Total_tax_Deposited_deduc = (Total_Tax_Deposited_Deductee.ToString() == "") ? Convert.ToDouble(string.Format("0.00", Total_Tax_Deposited_Deductee)) : Convert.ToDouble(Total_Tax_Deposited_Deductee); ;

                        if (Total_tax_Deposited_deduc <= Total_Tax_Deposited_Challan)
                        {
                            arr_Valid[Count_challan - 1] = "Y";
                        }
                        else
                        {
                            arr_Valid[Count_challan - 1] = "N";
                        }
                        ViewState["array"] = arr_Valid;

                    }
                    string[] arr = (string[])ViewState["array"];
                    ViewState["InvalidDates"] = dt_InvalidDates;
                    if (dt_InvalidDates.Rows.Count == 0)
                    {
                        if (!arr.Contains("N"))
                        {
                            //Declare the main error list
                            DataTable dt_mainErrorList = new DataTable();
                            //Declare  Challan Table
                            DataTable dtChallan = ds_Excel.Tables[0];

                            //Declare the Invalid BSRCode error List
                            DataTable arr_INValidBSRCodeList = new DataTable();
                            arr_INValidBSRCodeList = Get_Challan_Error_List(dtChallan, "ValidateBSRCode", Session["FormNoImport"].ToString());
                            //Declare the Empty Field Lis of the Challan Table
                            DataTable arr_INValidEmptyField = new DataTable();
                            arr_INValidEmptyField = Get_Challan_Error_List(dtChallan, "ValidateEmptyField", Session["FormNoImport"].ToString());
                            //Declare InValid Pan Error List
                            DataTable arr_INValidPANList = new DataTable();
                            DataTable dt_Deductee = ds_Excel.Tables[1];
                            arr_INValidPANList = Get_Error_List(dt_Deductee, "ValidatePAN", Session["FormNoImport"].ToString());
                            dt_mainErrorList = arr_INValidPANList.Clone();
                            dt_mainErrorList.Clear();
                            //Declare the InValid PAN Length Error List
                            DataTable arr_INValidPANLengthList = new DataTable();
                            arr_INValidPANLengthList = Get_Error_List(dt_Deductee, "ValidatePANLength", Session["FormNoImport"].ToString());
                            //Declare the Empty Name List
                            DataTable arr_EmptyNameList = new DataTable();
                            arr_EmptyNameList = Get_Error_List(dt_Deductee, "ValidateEmptyField", Session["FormNoImport"].ToString());
                            // Add the List of Challan Table Error to the Main Error List
                            if (arr_INValidBSRCodeList.Rows.Count > 0)
                            {
                                foreach (DataRow dr in arr_INValidBSRCodeList.Rows)
                                {
                                    dt_mainErrorList.ImportRow(dr);
                                }
                            }

                            if (arr_INValidEmptyField.Rows.Count > 0)
                            {
                                foreach (DataRow dr in arr_INValidEmptyField.Rows)
                                {
                                    dt_mainErrorList.ImportRow(dr);
                                }
                            }
                            //Concatenate  the Lists to main error list if any of them contains error
                            if (arr_INValidPANList.Rows.Count > 0)
                            {
                                foreach (DataRow dr in arr_INValidPANList.Rows)
                                {
                                    dt_mainErrorList.ImportRow(dr);
                                }
                            }
                            if (arr_INValidPANLengthList.Rows.Count > 0)
                            {
                                foreach (DataRow dr in arr_INValidPANLengthList.Rows)
                                {
                                    dt_mainErrorList.ImportRow(dr);
                                }
                            }
                            if (arr_EmptyNameList.Rows.Count > 0)
                            {
                                foreach (DataRow dr in arr_EmptyNameList.Rows)
                                {
                                    dt_mainErrorList.ImportRow(dr);
                                }
                            }
                            if (dt_mainErrorList.Rows.Count != 0)
                            {
                                Build(dt_mainErrorList);
                            }
                            else
                            {
                                objBltbl_Import_Data_Table.Import_Data(ds_Excel);
                                successFlag = "Y";
                            }
                        }
                        else
                        {
                            string Message_TotalTaxDeposited_SuccessFully = obj_Service.Get_Message("btn_SaveFile6", "2", "3");

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + Message_TotalTaxDeposited_SuccessFully + "');", true);
                        }
                    }
                    else
                    {
                        string Message_DateValid_SuccessFully = obj_Service.Get_Message("btn_SaveFile5", "2", "3");
                        msg_Valid_Date.Confirm(Message_DateValid_SuccessFully);
                        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + Message_DateValid_SuccessFully + "');", true);
                    }


                    //}
                    //else
                    //{
                    //    string Message_Template_SuccessFully = obj_Service.Get_Message("btn_SaveFile4", "2", "3");
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + Message_Template_SuccessFully + "');", true);
                    //}

                }
                else
                {
                    successFlag = "N";
                }



                if (successFlag == "Y")
                {
                    string Message_Imported_SuccessFully = obj_Service.Get_Message("btn_SaveFile1", "2", "3");
                    msg_confirm.Confirm(Message_Imported_SuccessFully);
                }
                else if (successFlag == "N")
                {
                    string Message_OverWrite_SuccessFully = obj_Service.Get_Message("btn_SaveFile2", "2", "3");
                    msg_alert.Confirm(Message_OverWrite_SuccessFully);
                }

            }

        }
        SaveTANwithUser(Session["TAN"].ToString());
        string s = Session["Regular_Correction"].ToString();
        string z = Session["ISExistMaster"].ToString();
        if (Session["Regular_Correction"].ToString() == "Correction_Import" && Session["ISExistMaster"].ToString() == "False")
        {
            //Response.Redirect("lstGrids.aspx?vtype=3001");
            string TAN = Session["TAN"].ToString();//Request.QueryString["TAN"].ToString();
            string FY = Session["FY"].ToString();//Request.QueryString["FY"].ToString();
            string Quarter = Session["qtr"].ToString();//Request.QueryString["Quarter"].ToString();
            string FormNo = Session["FormType"].ToString();//Request.QueryString["FormNo"].ToString();
            string AY = Session["AY"].ToString();//Request.QueryString["AY"].ToString();
            string AName = Session["ANameImport"].ToString();//Request.QueryString["AName"].ToString();
            string PAN = Session["PAN"].ToString();//Request.QueryString["PAN"].ToString();
            Session["Regular_Correction"] = "Correction";
            Response.Redirect("TANMaster.aspx?type=Correction&TAN=" + TAN + "&FY=" + FY + "&Quarter=" + Quarter + "&FormNo=" + FormNo + "&AY=" + AY + "&AName=" + AName + "&PAN=" + PAN + "");

            //Response.Redirect("lstGrids.aspx?vtype=3001");
            //Session["Regular_Correction"] = "Correction";
        }

    }





    //Function to Find  the Difference between two  xml files.
    public bool GenerateDiffGram(string originalFile, string finalFile,
                                       XmlWriter diffGramWriter)
    {
        XmlDiff xmldiff = new XmlDiff(XmlDiffOptions.IgnoreDtd);
        bool bIdentical = xmldiff.Compare(originalFile, finalFile, false, diffGramWriter);
        diffGramWriter.Close();
        return bIdentical;
    }

    #endregion

    #region  Import Text File
    //Function to Insert Data in FH Table
    public DataTable InsertFileHeaderTable(string file_path, string Type)
    {
        //Code of saving Challan

        //Create Parameter For Getting ID
        objtbl_FileHeader.TAN = ViewState["TAN"].ToString();
        objtbl_FileHeader.FinancialYear = ViewState["FY"].ToString();
        objtbl_FileHeader.Quarter = ViewState["Quarter"].ToString();
        objtbl_FileHeader.FormType = ViewState["FormNo"].ToString();


        objtbl_FileHeader.ID = objBltbl_FileHeader.GetIDFromMaster(objtbl_FileHeader);
        objtbl_Import_Data_Table.Master_ID = objtbl_FileHeader.ID;
        DataTable dt_FH = new DataTable();
        //Get ID_Admin
        ID_Admin = objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);
        if (Type == "Correction")
        {
            arr_Field_param = new string[] { objtbl_FileHeader.ID.ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^FH^", ID_Admin);
            dt_FH = objTextToDataSet.Convert(list, "tbl_File_Header_Record_Correction", "\t", Type);
        }
        else
        {
            arr_Field_param = new string[] { objtbl_FileHeader.ID.ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^FH^", ID_Admin);
            dt_FH = objTextToDataSet.Convert(list, "tbl_File_Header_Record", "\t", Type);

        }

        return dt_FH;

        // objtbl_FileHeader.Line_Number = Convert.ToInt32(arrLine[0]);
        // objtbl_FileHeader.Record_Type = arrLine[1].ToString();
        // objtbl_FileHeader.File_Type = arrLine[2].ToString();
        // objtbl_FileHeader.Upload_Type = arrLine[3].ToString();
        // objtbl_FileHeader.File_creation_date = arrLine[4].ToString();
        // string File_SeqNo = arrLine[5].ToString();
        // if (File_SeqNo != "")
        // {
        //     objtbl_FileHeader.File_Seq_No = Convert.ToInt32(File_SeqNo);
        // }

        // objtbl_FileHeader.Uploader_Type = arrLine[6].ToString();
        // objtbl_FileHeader.Tan_of_Employee = arrLine[7].ToString();
        // objtbl_FileHeader.Total_No_Batches = Convert.ToInt32(arrLine[8]);
        // objtbl_FileHeader.Name_of_Return_Prep_utility = arrLine[9].ToString();
        // objtbl_FileHeader.Record_Hash = arrLine[10].ToString();
        // objtbl_FileHeader.FVU_Version = arrLine[11].ToString();
        // objtbl_FileHeader.File_Hash = arrLine[12].ToString();
        // objtbl_FileHeader.Sam_Version = arrLine[13].ToString();
        // string SamHash = arrLine[14].ToString();
        // //if (SamHash == "")
        // //{
        // //    objtbl_FileHeader.Sam_Hash = 0;
        // //}
        // //else
        // //{
        //     objtbl_FileHeader.Sam_Hash = SamHash;
        // //}
        // objtbl_FileHeader.SCM_Version = arrLine[15].ToString();
        // objtbl_FileHeader.SCM_Hash = arrLine[16].ToString();
        // objtbl_FileHeader.Consolidated_File_Hash = arrLine[17].ToString();
        // objtbl_FileHeader.FinancialYear = ViewState["FY"].ToString();
        //int success= objBltbl_FileHeader.InsertFileHeaderFromFile(objtbl_FileHeader);



    }
    //Function to Insert Data In Master Table
    public int InsertMasterTable(string Type)
    {
        //Code of saving Challan

        string FinancialYear = Session["FYImport"].ToString();
        ViewState["FY"] = FinancialYear;
        string Quarter = Session["QuarterImport"].ToString();
        ViewState["Quarter"] = Quarter;
        string TAN = Session["TANImport"].ToString();
        ViewState["TAN"] = TAN;
        string FormNo = Session["FormNoImport"].ToString();
        ViewState["FormNo"] = FormNo;
        string Regular_Correction = string.Empty;
        if (Type == "Correction")
        {
            Regular_Correction = "Correction";
        }
        else
        {
            Regular_Correction = "Regular";
        }
        ViewState["Regular_Correction"] = Regular_Correction;

        //Call the Function to Insert Data into Master Table

        objtbl_FileHeader.FinancialYear = FinancialYear.ToString();
        objtbl_FileHeader.Quarter = Quarter;
        objtbl_FileHeader.TAN = TAN;
        objtbl_FileHeader.FormType = FormNo;
        objtbl_FileHeader.Regular_Correction = Regular_Correction;
        objtbl_FileHeader.Page_ID = "2";
        objtbl_FileHeader.Page_SubModule_ID = "3";
        int success = objBltbl_FileHeader.InsertDataInMaster(objtbl_FileHeader);
        if (success == 1)
        {
            objtbl_FileHeader.FinancialYear = "-999999999";
            objBltbl_FileHeader.InsertDataInMaster(objtbl_FileHeader);

        }
        return success;


    }


    //Function to Insert Batch Header File
    public DataTable InsertBatchHeader(string file_path, string Type)
    {
        //Get ID from Master
        objtbl_FileHeader.TAN = ViewState["TAN"].ToString();
        objtbl_FileHeader.FinancialYear = ViewState["FY"].ToString();
        objtbl_FileHeader.Quarter = ViewState["Quarter"].ToString();
        objtbl_FileHeader.FormType = ViewState["FormNo"].ToString();
        objtbl_BatchHeader.ID = objBltbl_FileHeader.GetIDFromMaster(objtbl_FileHeader);
        ViewState["ID"] = objtbl_BatchHeader.ID;
        objtbl_Import_Data_Table.Master_ID = objtbl_BatchHeader.ID;
        DataTable dt_BH = new DataTable();
        //Get ID_Admin
        ID_Admin = objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);

        if (Type == "Correction")
        {
            arr_Field_param = new string[] { ViewState["ID"].ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^BH^", ID_Admin);
            dt_BH = objTextToDataSet.Convert(list, "tbl_Batch_Header_Record_Correction", "\t", Type);
            ViewState["Batch_Header"] = dt_BH;
        }
        else
        {

            arr_Field_param = new string[] { ViewState["ID"].ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^BH^", ID_Admin);
            dt_BH = objTextToDataSet.Convert(list, "tbl_Batch_Header_Record", "\t", Type);
            ViewState["Batch_Header"] = dt_BH;
        }
        //DataRow[] dr_BH = dt_BH.Select();
        foreach (DataRow dr_BH in dt_BH.Rows)
        {
            dr_BH["ID_Admin"] = ID_Admin.ToString();
        }

        return dt_BH;


    }
    //Function to Insert TAN Master
    public int InsertTANMaster(DataTable dt_TAN)
    {
        //Code of saving Challan
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_Table = "";
        int success = 0;
        //Create Parameters
        objtbl_TANMaster.TAN = dt_TAN.Rows[0]["Tan_of_Employee"].ToString();

        objtbl_TANMaster.PAN = dt_TAN.Rows[0]["PAN_Of_deductor_Employer"].ToString();
        objtbl_TANMaster.Type = dt_TAN.Rows[0]["Deductor_Type"].ToString();
        objtbl_TANMaster.AName = dt_TAN.Rows[0]["Name_Of_Employer"].ToString();
        objtbl_TANMaster.PDesig = dt_TAN.Rows[0]["Designation_of_Person"].ToString();
        objtbl_TANMaster.AFlat = dt_TAN.Rows[0]["Employer_Address1"].ToString();
        objtbl_TANMaster.APremises = dt_TAN.Rows[0]["Employer_Address2"].ToString();
        objtbl_TANMaster.ARoad = dt_TAN.Rows[0]["Employer_Address3"].ToString();
        objtbl_TANMaster.AArea = dt_TAN.Rows[0]["Employer_Address4"].ToString();
        objtbl_TANMaster.ATown = dt_TAN.Rows[0]["Employer_Address5"].ToString();
        objtbl_TANMaster.AState = dt_TAN.Rows[0]["Employer_State"].ToString();
        objtbl_TANMaster.APINCode = dt_TAN.Rows[0]["Employer_PIN"].ToString();
        objtbl_TANMaster.PName = dt_TAN.Rows[0]["Name_of_Person"].ToString();
        objtbl_TANMaster.PFlat = dt_TAN.Rows[0]["Responsible_Persons_Address1"].ToString();
        objtbl_TANMaster.PPremises = dt_TAN.Rows[0]["Responsible_Persons_Address2"].ToString();
        objtbl_TANMaster.PRoad = dt_TAN.Rows[0]["Responsible_Persons_Address3"].ToString();
        objtbl_TANMaster.PArea = dt_TAN.Rows[0]["Responsible_Persons_Address4"].ToString();
        objtbl_TANMaster.PTown = dt_TAN.Rows[0]["Responsible_Persons_Address5"].ToString();
        objtbl_TANMaster.PState = dt_TAN.Rows[0]["Responsible_Persons_State"].ToString();
        objtbl_TANMaster.PPINCode = dt_TAN.Rows[0]["Responsible_Persons_PIN"].ToString();
        objtbl_TANMaster.Branch = dt_TAN.Rows[0]["Employer_Branch_Division"].ToString();
        objtbl_TANMaster.ASTDCode = dt_TAN.Rows[0]["Employer_Deductors_STD_Code"].ToString();
        objtbl_TANMaster.APhone = dt_TAN.Rows[0]["Employer_Deductors_TelephoneNo"].ToString();
        objtbl_TANMaster.AEmail = dt_TAN.Rows[0]["Employer_Deductor_EmailID"].ToString();
        objtbl_TANMaster.PSTDCode = dt_TAN.Rows[0]["Responsible_Persons_STDCode"].ToString();
        objtbl_TANMaster.PPhone = dt_TAN.Rows[0]["Responsible_Persons_TelPhoneNo"].ToString();
        objtbl_TANMaster.PEmail = dt_TAN.Rows[0]["Responsible_Persons_EmailID_1"].ToString();
        objtbl_TANMaster.FatherName = "";
        objtbl_TANMaster.Flat = "";
        objtbl_TANMaster.House = "";
        objtbl_TANMaster.Floor = "";
        objtbl_TANMaster.Building = "";
        objtbl_TANMaster.Block = "";
        objtbl_TANMaster.Road = "";
        objtbl_TANMaster.Locality = "";
        objtbl_TANMaster.City = "";
        objtbl_TANMaster.State = "";
        objtbl_TANMaster.PINCode = "";
        objtbl_TANMaster.Status = "";
        objtbl_TANMaster.CIT = "";
        objtbl_TANMaster.District = "";
        objtbl_TANMaster.Medium = "";
        objtbl_TANMaster.FileNum = "";
        objtbl_TANMaster.StateCode = dt_TAN.Rows[0]["State_Name"].ToString();
        objtbl_TANMaster.PAOCode = dt_TAN.Rows[0]["PAO_Code"].ToString();
        objtbl_TANMaster.DDOCode = dt_TAN.Rows[0]["DDO_Code"].ToString();
        objtbl_TANMaster.PAORegNo = dt_TAN.Rows[0]["PAO_Register_No"].ToString();
        objtbl_TANMaster.DDORegNo = dt_TAN.Rows[0]["DDO_RegistrationNo"].ToString();
        objtbl_TANMaster.MinistryCode = dt_TAN.Rows[0]["Ministry_NameOther"].ToString();
        objtbl_TANMaster.MinistryName = dt_TAN.Rows[0]["Ministry_Name"].ToString();
        objtbl_TANMaster.MobileNumber = dt_TAN.Rows[0]["Mobile_Number"].ToString();
        objtbl_TANMaster.AIN_Number = dt_TAN.Rows[0]["AIN"].ToString();
        objtbl_TANMaster.PANof_Responsible_Person = "";
        objtbl_TANMaster.Page_ID = "1";
        objtbl_TANMaster.Page_SubModule_ID = "1";
        //Call A Function to Insert the new Tan Entry
        bool isNewRecord = objBltbl_TANMaster.CheckRecordExistence(objtbl_TANMaster);
        if (isNewRecord)
        {
            success = objBltbl_TANMaster.InsertTANEntry(objtbl_TANMaster);
            objtbl_TANMaster.TAN = "-999999999";
            objBltbl_TANMaster.InsertTANEntry(objtbl_TANMaster);
        }
        return success;
    }

    //Function to Update TAN Master
    public int UpdateTANMaster(DataTable dt_TAN)
    {
        //Code of saving Challan
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_Table = "";
        int success = 0;
        //Create Parameters
        objtbl_TANMaster.TAN = dt_TAN.Rows[0]["Tan_of_Employee"].ToString();

        objtbl_TANMaster.PAN = dt_TAN.Rows[0]["PAN_Of_deductor_Employer"].ToString();
        objtbl_TANMaster.Type = dt_TAN.Rows[0]["Deductor_Type"].ToString();
        objtbl_TANMaster.AName = dt_TAN.Rows[0]["Name_Of_Employer"].ToString();
        objtbl_TANMaster.PDesig = dt_TAN.Rows[0]["Designation_of_Person"].ToString();
        objtbl_TANMaster.AFlat = dt_TAN.Rows[0]["Employer_Address1"].ToString();
        objtbl_TANMaster.APremises = dt_TAN.Rows[0]["Employer_Address2"].ToString();
        objtbl_TANMaster.ARoad = dt_TAN.Rows[0]["Employer_Address3"].ToString();
        objtbl_TANMaster.AArea = dt_TAN.Rows[0]["Employer_Address4"].ToString();
        objtbl_TANMaster.ATown = dt_TAN.Rows[0]["Employer_Address5"].ToString();
        objtbl_TANMaster.AState = dt_TAN.Rows[0]["Employer_State"].ToString();
        objtbl_TANMaster.APINCode = dt_TAN.Rows[0]["Employer_PIN"].ToString();
        objtbl_TANMaster.PName = dt_TAN.Rows[0]["Name_of_Person"].ToString();
        objtbl_TANMaster.PFlat = dt_TAN.Rows[0]["Responsible_Persons_Address1"].ToString();
        objtbl_TANMaster.PPremises = dt_TAN.Rows[0]["Responsible_Persons_Address2"].ToString();
        objtbl_TANMaster.PRoad = dt_TAN.Rows[0]["Responsible_Persons_Address3"].ToString();
        objtbl_TANMaster.PArea = dt_TAN.Rows[0]["Responsible_Persons_Address4"].ToString();
        objtbl_TANMaster.PTown = dt_TAN.Rows[0]["Responsible_Persons_Address5"].ToString();
        objtbl_TANMaster.PState = dt_TAN.Rows[0]["Responsible_Persons_State"].ToString();
        objtbl_TANMaster.PPINCode = dt_TAN.Rows[0]["Responsible_Persons_PIN"].ToString();
        objtbl_TANMaster.Branch = dt_TAN.Rows[0]["Employer_Branch_Division"].ToString();
        objtbl_TANMaster.ASTDCode = dt_TAN.Rows[0]["Employer_Deductors_STD_Code"].ToString();
        objtbl_TANMaster.APhone = dt_TAN.Rows[0]["Employer_Deductors_TelephoneNo"].ToString();
        objtbl_TANMaster.AEmail = dt_TAN.Rows[0]["Employer_Deductor_EmailID"].ToString();
        objtbl_TANMaster.PSTDCode = dt_TAN.Rows[0]["Responsible_Persons_STDCode"].ToString();
        objtbl_TANMaster.PPhone = dt_TAN.Rows[0]["Responsible_Persons_TelPhoneNo"].ToString();
        objtbl_TANMaster.PEmail = dt_TAN.Rows[0]["Responsible_Persons_EmailID_1"].ToString();
        objtbl_TANMaster.FatherName = "";
        objtbl_TANMaster.Flat = "";
        objtbl_TANMaster.House = "";
        objtbl_TANMaster.Floor = "";
        objtbl_TANMaster.Building = "";
        objtbl_TANMaster.Block = "";
        objtbl_TANMaster.Road = "";
        objtbl_TANMaster.Locality = "";
        objtbl_TANMaster.City = "";
        objtbl_TANMaster.State = "";
        objtbl_TANMaster.PINCode = "";
        objtbl_TANMaster.Status = "";
        objtbl_TANMaster.CIT = "";
        objtbl_TANMaster.District = "";
        objtbl_TANMaster.Medium = "";
        objtbl_TANMaster.FileNum = "";
        objtbl_TANMaster.StateCode = dt_TAN.Rows[0]["State_Name"].ToString();
        objtbl_TANMaster.PAOCode = dt_TAN.Rows[0]["PAO_Code"].ToString();
        objtbl_TANMaster.DDOCode = dt_TAN.Rows[0]["DDO_Code"].ToString();
        objtbl_TANMaster.PAORegNo = dt_TAN.Rows[0]["PAO_Register_No"].ToString();
        objtbl_TANMaster.DDORegNo = dt_TAN.Rows[0]["DDO_RegistrationNo"].ToString();
        objtbl_TANMaster.MinistryCode = dt_TAN.Rows[0]["Ministry_NameOther"].ToString();
        objtbl_TANMaster.MinistryName = dt_TAN.Rows[0]["Ministry_Name"].ToString();
        objtbl_TANMaster.MobileNumber = dt_TAN.Rows[0]["Mobile_Number"].ToString();
        objtbl_TANMaster.Page_ID = "1";
        objtbl_TANMaster.Page_SubModule_ID = "1";
        //Call A Function to Insert the new Tan Entry
        bool isNewRecord = objBltbl_TANMaster.CheckRecordExistence(objtbl_TANMaster);
        if (isNewRecord)
        {
            success = objBltbl_TANMaster.UpdateTANEntry(objtbl_TANMaster);
            objtbl_TANMaster.TAN = "-999999999";
            objBltbl_TANMaster.UpdateTANEntry(objtbl_TANMaster);
        }
        return success;
    }

    //Function to Insert Challan Details.
    public DataTable InsertChallanDetails(string file_path, string Type)
    {
        //Create DataTable 
        DataTable dt_CD = new DataTable();
        string FY = Session["FYImport"].ToString();
        int Financial_Year = Convert.ToInt32(FY);
        //int success = 0;
        if (Type == "Correction")
        {
            int MasterID = Convert.ToInt32(ViewState["ID"]);
            objtbl_ChallanDetails_Correction.ID = MasterID;
            objtbl_ChallanDetails.Regular_Correction = Type;

            int NewChallanID = objBltbl_ChallanDetails.GenerateChallanID(objtbl_ChallanDetails);
            objtbl_ChallanDetails.ChallanID = NewChallanID;


            arr_Field_param = new string[] { MasterID.ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^CD^", ID_Admin);
            dt_CD = objTextToDataSet.Convert(list, "tbl_ChallanTransferVoucherDetail_Correction", "\t", Type);


        }
        else if (Type == "Regular")
        {
            //Create Parameter For ChallanDetails From Consolidated File.

            //Code of saving Challan

            countChallan = countChallan + 1;

            if (countChallan == 1)
            {
                index = 0;

            }
            else if (countChallan > 1)
            {
                index = index + 1;
            }

            int MasterID = Convert.ToInt32(ViewState["ID"]);
            objtbl_ChallanDetails.ID = MasterID;
            objtbl_ChallanDetails.Regular_Correction = Type;

            int NewChallanID = objBltbl_ChallanDetails.GenerateChallanID(objtbl_ChallanDetails);
            objtbl_ChallanDetails.ChallanID = NewChallanID;


            arr_Field_param = new string[] { MasterID.ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^CD^", ID_Admin);
            dt_CD = objTextToDataSet.Convert(list, "tbl_ChallanTransferVoucherDetail", "\t", Type);
            //DataRow[] dr_CD = dt_CD.Select("ChallanID=" + NewChallanID + " and ID=" + MasterID + "");

            //Create Parameter

        }
        foreach (DataRow dr_CD in dt_CD.Rows)
        {
            dr_CD["ID_Admin"] = ID_Admin;
            if (Financial_Year >= 201213)
            {
                string Late_Fee = dr_CD["Fee"].ToString();
                if (Late_Fee == "")
                {
                    dr_CD["Fee"] = "0.00";
                }
                string Minor_Head = string.Empty;
                if (dr_CD["Record_Hash"].ToString() != null && dr_CD["Record_Hash"].ToString() != "")
                {
                    Minor_Head = dr_CD["Record_Hash"].ToString();
                    dr_CD["Minor_Head_of_Challan"] = Minor_Head;
                    dr_CD["Record_Hash"] = "";
                }

            }
            if (Type == "Correction")
            {

                dr_CD["Cheque_DD_No"] = 0;
            }

        }
        return dt_CD;

    }

    //Function to Insert Deductee Details.
    public DataTable InsertDeducteeDetails(string file_path, string Type)
    {
        //Code of saving Challan
        DataTable dt_DD = new DataTable();
        CountDeductee = CountDeductee + 1;

        //Create Parameters to Insert Records in the DeducteeDetails_Correction table
        objtbl_ChallanDetails.TAN = Session["TANImport"].ToString();
        objtbl_ChallanDetails.FinancialYear = Session["FYImport"].ToString();
        objtbl_ChallanDetails.Quarter = Session["QuarterImport"].ToString();
        string FormNo = Session["FormNoImport"].ToString();
        string Quarter = Session["QuarterImport"].ToString();
        string Update_FormNo = string.Empty;

        objtbl_ChallanDetails.FormType = Session["FormNoImport"].ToString();
        if (Type == "Correction")
        {
            objtbl_ChallanDetails.Regular_Correction = "Correction";
        }
        else
        {
            objtbl_ChallanDetails.Regular_Correction = "Regular";
        }

        objtbl_DeducteeDetail.ID = GetChallanID(objtbl_ChallanDetails, index);
        int ID = objtbl_DeducteeDetail.ID;

        int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
        ViewState["MasterID"] = MasterID;
        objtbl_DeducteeDetail.ID = ID;
        objtbl_DeducteeDetail.MasterID = MasterID;
        objtbl_Import_Data_Table.Master_ID = MasterID;
        //Get ID_Admin
        ID_Admin = objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);
        objtbl_DeducteeDetail.Regular_Correction = Type;
        objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(objBltbl_DeducteeDetail.GenerateDeducteeID(objtbl_DeducteeDetail));
        int Deductee_ID = objtbl_DeducteeDetail.DeducteeID;



        if (Type == "Correction")
        {

            arr_Field_param = new string[] { MasterID.ToString(), ID.ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^DD^", ID_Admin);
            dt_DD = objTextToDataSet.Convert(list, "tbl_DeducteeDetail_Record_Correction", "\t", Type);


        }
        else if (Type == "Regular")
        {
            arr_Field_param = new string[] { MasterID.ToString(), ID.ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^DD^", ID_Admin);
            dt_DD = objTextToDataSet.Convert(list, "tbl_DeducteeDetail_Record", "\t", Type);
            //DataRow[] dr_DD = dt_DD.Select("DeducteeID=" + Deductee_ID + "and ID=" + ID + "and MasterID=" + MasterID + "");


        }
        foreach (DataRow dr_DD in dt_DD.Rows)
        {
            dr_DD["ID_Admin"] = ID_Admin;
            string Rate_At_Which_Tax_Deducted = dr_DD["RateatWhich_TAXDeducted"].ToString();
            if (Rate_At_Which_Tax_Deducted == "")
            {
                dr_DD["RateatWhich_TAXDeducted"] = 0.0000;
            }
        }
        return dt_DD;




    }

    //Function to Insert Salary Details.
    public DataTable InsertSalaryDetails(string file_path, string Type)
    {
        objtbl_Import_Data_Table.Master_ID = Convert.ToInt32(ViewState["MasterID"]);
        int MasterID = Convert.ToInt32(ViewState["MasterID"]);
        //Get ID_Admin
        ID_Admin = objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);
        DataTable dt_SD = new DataTable();
        //Code of saving Challan

        ////create parameter for the salary detail table 
        //int success = 0;
        if (Type == "Correction")
        {

            arr_Field_param = new string[] { ViewState["MasterID"].ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^SD^", ID_Admin);
            dt_SD = objTextToDataSet.Convert(list, "tbl_SalaryDetailsRecords_Correction", "\t", Type);
            foreach (DataRow dr_SD in dt_SD.Rows)
            {
                dr_SD["ID_Admin"] = ID_Admin;
                dr_SD["ID"] = MasterID;
                ID_Admin = ID_Admin + 1;

            }

        }
        else
        {

            arr_Field_param = new string[] { ViewState["MasterID"].ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^SD^", ID_Admin);

            dt_SD = objTextToDataSet.Convert(list, "tbl_SalaryDetailsRecords", "\t", Type);
            foreach (DataRow dr_SD in dt_SD.Rows)
            {
                dr_SD["ID_Admin"] = ID_Admin;
                dr_SD["ID"] = MasterID;
                ID_Admin = ID_Admin + 1;

            }


        }

        return dt_SD;



    }

    //Function to Insert Section VI A Details
    public DataTable InsertSectionSixA(string file_path, string Type)
    {

        objtbl_Import_Data_Table.Master_ID = Convert.ToInt32(ViewState["MasterID"]);
        //Get ID_Admin
        ID_Admin = objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);
        DataTable dt_C6A = new DataTable();
        if (Type == "Correction")
        {
            arr_Field_param = new string[] { ViewState["MasterID"].ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^C6A^", ID_Admin);
            dt_C6A = objTextToDataSet.Convert(list, "tbl_SectionVIA_Correction", "\t", Type);
            foreach (DataRow dr_C6A in dt_C6A.Rows)
            {
                dr_C6A["ID_Admin"] = ID_Admin;
                ID_Admin = ID_Admin + 1;

            }
        }
        else
        {
            arr_Field_param = new string[] { ViewState["MasterID"].ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^C6A^", ID_Admin);
            dt_C6A = objTextToDataSet.Convert(list, "tbl_SectionVIA", "\t", Type);
            foreach (DataRow dr_C6A in dt_C6A.Rows)
            {
                dr_C6A["ID_Admin"] = ID_Admin;
                ID_Admin = ID_Admin + 1;

            }



        }

        return dt_C6A;
    }

    //Function to Insert 16 Details
    public DataTable Insert16A(string file_path, string Type)
    {

        objtbl_Import_Data_Table.Master_ID = Convert.ToInt32(ViewState["MasterID"]);
        //Get ID_Admin
        ID_Admin = objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);
        DataTable dt_C6A = new DataTable();
        if (Type == "Correction")
        {
            arr_Field_param = new string[] { ViewState["MasterID"].ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^S16^", ID_Admin);
            dt_C6A = objTextToDataSet.Convert(list, "tbl_16A_Correction", "\t", Type);
            foreach (DataRow dr_16 in dt_C6A.Rows)
            {
                dr_16["ID_Admin"] = ID_Admin;
                ID_Admin = ID_Admin + 1;
            }
        }
        else if (Type == "Regular")
        {
            arr_Field_param = new string[] { ViewState["MasterID"].ToString() };
            List<string> list = Get_Line(arr_Field_param, file_path, "^S16^", ID_Admin);
            dt_C6A = objTextToDataSet.Convert(list, "tbl_16A", "\t", Type);
            foreach (DataRow dr_16 in dt_C6A.Rows)
            {
                dr_16["ID_Admin"] = ID_Admin;
                ID_Admin = ID_Admin + 1;
            }
        }

        return dt_C6A;
    }

    //Function to Get ChallanID
    public int GetChallanID(tbl_ChallanDetails objtbl_ChallanDetails, int index)
    {
        int ChallanID = 0;
        DataTable dt = new DataTable();
        dt = objBltbl_ChallanDetails.GetChallanData(objtbl_ChallanDetails);
        if (dt.Rows.Count != 0)
        {
            ChallanID = Convert.ToInt32(dt.Rows[index]["ChallanID"]);
        }
        return ChallanID;
    }


    #endregion

    #region Import Excel File
    //Function to MatchTemplate
    public bool MatchTemplate(DataTable dtTemplate, DataTable dtCompare)
    {
        foreach (DataColumn column in dtTemplate.Columns)
        {
            ColumnNameTemplate = ColumnNameTemplate + column.ColumnName.ToString() + ",";



        }
        ColumnNameTemplate = ColumnNameTemplate.Remove(ColumnNameTemplate.Length - 1, 1);

        string[] arrColumnTemplate = (string[])ColumnNameTemplate.Split(',').ToArray();

        foreach (DataColumn columnCompare in dtCompare.Columns)
        {

            ColumnNameCompare = ColumnNameCompare + columnCompare.ColumnName.ToString() + ",";
        }

        ColumnNameCompare = ColumnNameCompare.Remove(ColumnNameCompare.Length - 1, 1);

        string[] arrColumnCompare = (string[])ColumnNameCompare.Split(',').ToArray();
        bool ISCompared = Compare(arrColumnTemplate, arrColumnCompare);
        return ISCompared;
    }
    public DataTable GetFormNo(string sheetName, string filename)
    {
        string strComand;
        strComand = @"select * from [" + sheetName + "]";
        //strComand = "select * from ['1$']";


        //string connectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\Excel 12.0 Xml;HDR=YES\;); path");
        //string strConnectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source="+filename+";Extended Properties=Excel 12.0;";
        string strConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
        //string strConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties=Excel 8.0;HDR=No;IMEX=1";
        OleDbConnection con = new OleDbConnection(strConnectionString);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        OleDbDataAdapter daAdapter = new OleDbDataAdapter(strComand, strConnectionString);
        DataTable dt = new DataTable(sheetName);
        //dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);


        //daAdapter.FillSchema(dt, SchemaType.Source);
        daAdapter.Fill(dt);
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        return dt;
    }
    public DataTable GetDataTableofTemplate(string sheetName, string filename)
    {
        try
        {
            string strComand;
            strComand = "select * from [" + sheetName + "]";

            string strConnectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + filename + ";Extended Properties=Excel 12.0;";
            //string strConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties=Excel 8.0;HDR=No;IMEX=1";
            OleDbConnection con = new OleDbConnection(strConnectionString);
            OleDbDataAdapter daAdapter = new OleDbDataAdapter(strComand, strConnectionString);
            DataTable dt = new DataTable(sheetName);
            daAdapter.FillSchema(dt, SchemaType.Source);
            daAdapter.Fill(dt);
            con.Close();
            return dt;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public DataTable GetDataTableofCompareExcel(string sheetName, string filename)
    {
        try
        {
            string strComand;
            strComand = "select * from [" + sheetName + "]";

            string strConnectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + filename + ";Extended Properties=Excel 12.0;";
            //string strConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties=Excel 8.0;HDR=No;IMEX=1";
            OleDbConnection con = new OleDbConnection(strConnectionString);
            OleDbDataAdapter daAdapter = new OleDbDataAdapter(strComand, strConnectionString);
            DataTable dt = new DataTable(sheetName);
            daAdapter.FillSchema(dt, SchemaType.Source);
            daAdapter.Fill(dt);
            con.Close();
            return dt;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    //Function to Compare the DataType of the DeductorSheet
    public List<string> Get_Line(string[] arr_field, string file_path, string searchText, int ID_Admin)
    {
        var mataches = new List<string>();
        using (var f = File.OpenRead(file_path))
        {
            var s = new StreamReader(f);
            while (!s.EndOfStream)
            {
                var line = s.ReadLine();
                for (int j = 0; j < arr_field.Length; j++)
                {

                    if (ViewState["Type"].ToString() == "CD" && line.Contains("^CD^"))
                    {
                        Challan_Count = Challan_Count + 1;
                        line = Challan_Count + "^" + arr_field[j].ToString() + "^" + line;

                    }
                    else if (ViewState["Type"].ToString() == "C6A" || ViewState["Type"].ToString() == "S16")
                    {
                        line = line;
                    }
                    else if (ViewState["Type"].ToString() == "FH" || ViewState["Type"].ToString() == "BH" || ViewState["Type"].ToString() == "DD" || ViewState["Type"].ToString() == "SD")
                    {
                        line = arr_field[j].ToString() + "^" + line;
                    }

                }
                for (int k = 0; k < 1; k++)
                {
                    if (ViewState["Type"].ToString() == "DD" && line.Contains("^DD^"))
                    {

                        Deductee_Count = Deductee_Count + 1;
                        line = Deductee_Count + "^" + line;
                    }

                }
                if (line != null && line.Contains(searchText))
                {
                    //if (ViewState["Type"].ToString() == "DD")
                    //{
                    //    line = line + "^^^^^^^^^^^" + ID_Admin;
                    //}
                    if (ViewState["Type"].ToString() == "SD" || ViewState["Type"].ToString() == "C6A" || ViewState["Type"].ToString() == "S16")
                    {
                        line = ID_Admin + "^" + line;
                    }
                    //else
                    //{
                    //    line = line + "^^^^^^^^^" + ID_Admin;
                    //}

                    mataches.Add(line);
                }
            }
            f.Close();

            Deductee_Count = 0;
        }
        return mataches;
    }

    public bool Compare(string[] arrTemplate, string[] arrCompareTemplate)
    {
        bool ISCompared = true;
        foreach (var str in arrTemplate)
        {
            if (ISCompared != false)
            {
                if (arrCompareTemplate.Contains(str))
                {
                    ISCompared = true;
                }
                else
                {
                    ISCompared = false;
                }
            }
        }
        return ISCompared;
    }
    public bool CompareDatatype(DataTable dt, string SheetName)
    {
        bool DataTypeIsCompared = false;
        if (SheetName == "'DEDUCTORS DETAIL$'")
        {

        }
        else if (SheetName == "'CHALLAN DETAIL$'")
        {
        }
        else if (SheetName == "'Deductee Detail$'")
        {

        }
        return DataTypeIsCompared;


    }
    //Get Excel Sheet Name of the Uploaded Excel File
    public String[] GetExcelSheetName(OleDbConnection con, string ExcelSheet)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (dt == null)
            {
                return null;
            }
            String[] excelSheets = new String[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {

                excelSheets[i] = row["TABLE_NAME"].ToString();


                i++;
            }
            return excelSheets;
        }
        catch (Exception e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            throw e;

        }


    }

    //Get Excel Sheet Name of the Template Excel File
    public String[] GetExcelSheetNameTemplate(OleDbConnection con, string ExcelSheet)
    {
        con.Open();
        DataTable dt = new DataTable();
        dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        if (dt == null)
        {
            return null;
        }
        String[] excelSheets = new String[dt.Rows.Count];
        int i = 0;
        foreach (DataRow row in dt.Rows)
        {
            excelSheets[i] = row["TABLE_NAME"].ToString();
            i++;
        }
        return excelSheets;

    }

    //Function to Insert Data in FH Table
    public DataTable InsertFileHeaderTable_Excel()
    {
        //Code of saving Challan
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";
        DataTable dt_FH = new DataTable();
        dt_FH = objFillTableFromExcel.Convert_DataTable("tbl_File_Header_Record", "\t");
        int success = 0;
        //Create Parameter For Getting ID
        DataRow dr_FH = dt_FH.NewRow();

        objtbl_FileHeader.TAN = ViewState["TAN"].ToString();
        objtbl_FileHeader.FinancialYear = ViewState["FY"].ToString();
        objtbl_FileHeader.Quarter = ViewState["Quarter"].ToString();
        objtbl_FileHeader.FormType = ViewState["FormType"].ToString();
        objtbl_FileHeader.Regular_Correction = "Regular";
        objtbl_FileHeader.ID = objBltbl_FileHeader.GetIDFromMaster(objtbl_FileHeader);
        ViewState["Master_ID"] = objtbl_FileHeader.ID;
        objtbl_FileHeader.Page_ID = "2";
        objtbl_FileHeader.Page_SubModule_ID = "3";
        string FY = objtbl_FileHeader.FinancialYear.ToString();
        //ID Field in FileHeader Line.
        int ID = Convert.ToInt32(objtbl_FileHeader.ID);
        objtbl_Import_Data_Table.Master_ID = ID;
        //Get ID_Admin
        int IDAdmin = objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);
        ViewState["IDAdmin"] = IDAdmin;
        //LineNumber Field in FileHeader line
        int LineNumber = 0;
        //RecordType Field in FileHeader line
        string RecordType = "FH";
        //FileType Field in FileHeader line
        string FileType = string.Empty;
        string FormType = objtbl_FileHeader.FormType.ToString();
        if (FormType == "Form24Q")
        {
            FileType = "SL1";
        }
        else if (FormType == "Form26Q")
        {
            FileType = "NS1";
        }
        else if (FormType == "Form27Q")
        {
            FileType = "NS1";
        }
        else if (FormType == "Form27EQ")
        {
            FileType = "TC1";
        }
        //UploadType Field In FileHeader Line.
        string Type = objtbl_FileHeader.Regular_Correction.ToString();
        string UploadType = string.Empty;
        if (Type == "Regular")
        {
            UploadType = "R";
        }
        else if (Type == "Correction")
        {
            UploadType = "C";
        }
        //FileCreationDate Field In FileHeader Line.
        DateTime CreateFileDate = DateTime.Now;

        string FileCreationDate = String.Format("{0:dd/MM/yyyy}", CreateFileDate);
        FileCreationDate = FileCreationDate.Replace("-", "");
        FileCreationDate = FileCreationDate.Replace("/", "");





        //FileSequenceNo in Field In FileHeader Line.
        int FileSequenceNo = 1;

        //UploadType Field In FileHeader Line.
        string UploaderType = "D";

        //TAN Field In FileHeader Line
        string TAN = objtbl_FileHeader.TAN.ToString();

        //TotalNoOfBatches Field in FileHeader Line
        int TotalNoofBatches = 1;

        // NameofReturnPreparationUtility Field in FileHeader Line.
        string NameofReturnPreparationUtility = "Vatas eTDS";


        //RecordHash Field in FileHeader Line.
        string RecordHash = "";

        //FVUVersion Field in FileHeader Line.
        string FVUVersion = "";

        //FileHash Field in FileHeader Line.
        string FileHash = "";

        //SAM Version Field in FileHeader Line.
        string SamVersion = "";

        //SAM Hash Field In FileHeader Line.
        string SAMHash = "";

        //SCM Version Field In FileHeader Line.
        string SCMVersion = "";

        //SCM Hash Filed In FileHeader Line.
        string SCMHash = "";

        //Consolidated File Hash In FileHeader Line
        string ConsolidatedFileHash = "";

        //bool IsFileHeader_Exist = objBltbl_FileHeader.CheckFileHeaderRecordExistence(objtbl_FileHeader);
        //if (!IsFileHeader_Exist)
        //{

        //}
        dr_FH["ID"] = objtbl_FileHeader.ID;
        dr_FH["Line_Number"] = 0;
        dr_FH["Record_Type"] = "FH";
        dr_FH["File_Type"] = FileType;
        dr_FH["Upload_Type"] = UploadType;
        dr_FH["File_creation_date"] = FileCreationDate;
        dr_FH["File_Seq_No"] = FileSequenceNo;
        dr_FH["Uploader_Type"] = UploaderType;
        dr_FH["Tan_of_Employee"] = TAN;
        dr_FH["Total_No_Batches"] = TotalNoofBatches;
        dr_FH["Name_of_Return_Prep_utility"] = NameofReturnPreparationUtility;
        dr_FH["Record_Hash"] = RecordHash;
        dr_FH["FVU_Version"] = FVUVersion;
        dr_FH["File_Hash"] = FileHash;
        dr_FH["Sam_Version"] = SamVersion;
        dr_FH["Sam_Hash"] = SAMHash;
        dr_FH["SCM_Version"] = SCMVersion;
        dr_FH["SCM_Hash"] = SCMHash;
        dr_FH["Consolidated_File_Hash"] = ConsolidatedFileHash;
        dr_FH["FY"] = FY;
        dr_FH["C1"] = "";
        dr_FH["C2"] = "";
        dr_FH["C3"] = "";
        dr_FH["C4"] = "";
        dr_FH["C5"] = "";
        dr_FH["C9"] = "";
        dr_FH["Y"] = "";
        dr_FH["ID_Admin"] = IDAdmin;

        dt_FH.Rows.Add(dr_FH);
        return dt_FH;

    }
    //Function to Insert Data In Master Table
    public int InsertMasterTable_Excel()
    {
        //Code of saving Challan
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";
        int success = 0;
        string FinancialYear = ViewState["FY"].ToString();

        string Quarter = ViewState["Quarter"].ToString();

        string TAN = ViewState["TAN"].ToString();

        string FormNo = ViewState["FormType"].ToString();

        string Regular_Correction = "Regular";

        //int CorrectionNo=
        //Create Parameter to Insert into Master Table
        objtbl_FileHeader.FinancialYear = FinancialYear.ToString();
        objtbl_FileHeader.Quarter = Quarter;
        objtbl_FileHeader.TAN = TAN;
        objtbl_FileHeader.FormType = FormNo;
        objtbl_FileHeader.Regular_Correction = Regular_Correction;
        objtbl_FileHeader.Page_ID = "2";
        objtbl_FileHeader.Page_SubModule_ID = "3";
        //Call the Function to Insert Data into Master Table
        bool IsMaster_Exist = objBltbl_FileHeader.CheckMasterTableExistence(objtbl_FileHeader);
        if (!IsMaster_Exist)
        {
            success = objBltbl_FileHeader.InsertDataInMaster(objtbl_FileHeader);
            if (success == 1)
            {
                objtbl_FileHeader.FinancialYear = "-999999999";
                objBltbl_FileHeader.InsertDataInMaster(objtbl_FileHeader);
            }
        }
        return success;
        //Create Parameter To Insert Data From Excel File to Batchheader

    }
    //Function to Insert Batch Header File
    public int InsertBatchHeader_Excel(DataTable dt_Deductor)
    {
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";
        //Code of saving Challan

        // int count=Convert.ToInt32(dt_Deductor.Rows.Count);
        //Create Parameter For Inserting Record in BatchHeader From Excel 
        objtbl_BatchHeader.Tan_of_Employer = dt_Deductor.Rows[0]["Deductor Info"].ToString();
        //ViewState["TAN"] = objtbl_BatchHeader.Tan_of_Employer.ToString();
        string AssessmentYear = dt_Deductor.Rows[2]["Deductor Info"].ToString();
        AssessmentYear = AssessmentYear.Replace("-", "");

        objtbl_BatchHeader.Assessment_Year = Convert.ToInt32(AssessmentYear);

        objtbl_BatchHeader.Quarter = dt_Deductor.Rows[3]["Deductor Info"].ToString();
        //ViewState["Quarter"] = objtbl_BatchHeader.Quarter.ToString();
        objtbl_BatchHeader.PAN_Of_deductor_Employer = dt_Deductor.Rows[4]["Deductor Info"].ToString();
        objtbl_BatchHeader.Name_Of_Employer = dt_Deductor.Rows[5]["Deductor Info"].ToString();
        objtbl_BatchHeader.Employer_Branch_Division = dt_Deductor.Rows[6]["Deductor Info"].ToString();
        objtbl_BatchHeader.Employer_Address1 = dt_Deductor.Rows[7]["Deductor Info"].ToString();
        objtbl_BatchHeader.Employer_Address2 = dt_Deductor.Rows[8]["Deductor Info"].ToString();
        objtbl_BatchHeader.Employer_Address3 = dt_Deductor.Rows[9]["Deductor Info"].ToString();
        objtbl_BatchHeader.Employer_Address4 = dt_Deductor.Rows[10]["Deductor Info"].ToString();
        objtbl_BatchHeader.Employer_Address5 = dt_Deductor.Rows[11]["Deductor Info"].ToString();
        objtbl_BatchHeader.Employer_State = Convert.ToInt32(dt_Deductor.Rows[12]["Deductor Info"]);
        objtbl_BatchHeader.Employer_PIN = Convert.ToInt32(dt_Deductor.Rows[13]["Deductor Info"]);
        objtbl_BatchHeader.Employer_Deductor_EmailID = dt_Deductor.Rows[14]["Deductor Info"].ToString();
        objtbl_BatchHeader.Employer_Deductors_STD_Code = dt_Deductor.Rows[15]["Deductor Info"].ToString();
        objtbl_BatchHeader.Employer_Deductors_TelephoneNo = dt_Deductor.Rows[16]["Deductor Info"].ToString();
        objtbl_BatchHeader.Change_address_of_Deductor_since_last_Return = dt_Deductor.Rows[17]["Deductor Info"].ToString();
        objtbl_BatchHeader.Deductor_Type = dt_Deductor.Rows[18]["Deductor Info"].ToString();
        objtbl_BatchHeader.Name_of_Person = dt_Deductor.Rows[19]["Deductor Info"].ToString();
        objtbl_BatchHeader.Designation_of_Person = dt_Deductor.Rows[21]["Deductor Info"].ToString();
        objtbl_BatchHeader.Responsible_Persons_Address1 = dt_Deductor.Rows[22]["Deductor Info"].ToString();
        objtbl_BatchHeader.Responsible_Persons_Address2 = dt_Deductor.Rows[23]["Deductor Info"].ToString();
        objtbl_BatchHeader.Responsible_Persons_Address3 = dt_Deductor.Rows[24]["Deductor Info"].ToString();
        objtbl_BatchHeader.Responsible_Persons_Address4 = dt_Deductor.Rows[25]["Deductor Info"].ToString();
        objtbl_BatchHeader.Responsible_Persons_Address5 = dt_Deductor.Rows[26]["Deductor Info"].ToString();
        objtbl_BatchHeader.Responsible_Persons_State = Convert.ToInt32(dt_Deductor.Rows[27]["Deductor Info"]);
        objtbl_BatchHeader.Responsible_Persons_PIN = Convert.ToInt32(dt_Deductor.Rows[28]["Deductor Info"]);
        objtbl_BatchHeader.Responsible_Persons_EmailID_1 = dt_Deductor.Rows[29]["Deductor Info"].ToString();
        objtbl_BatchHeader.Responsible_Persons_STDCode = dt_Deductor.Rows[30]["Deductor Info"].ToString();
        objtbl_BatchHeader.Responsible_Persons_TelPhoneNo = dt_Deductor.Rows[31]["Deductor Info"].ToString();
        objtbl_BatchHeader.Mobile_Number = dt_Deductor.Rows[32]["Deductor Info"].ToString();
        objtbl_BatchHeader.Change_address_of_person_since_last_Return = dt_Deductor.Rows[33]["Deductor Info"].ToString();
        objtbl_BatchHeader.PAO_Code = dt_Deductor.Rows[34]["Deductor Info"].ToString();
        objtbl_BatchHeader.DDO_Code = dt_Deductor.Rows[35]["Deductor Info"].ToString();
        objtbl_BatchHeader.Ministry_Name = dt_Deductor.Rows[36]["Deductor Info"].ToString();
        objtbl_BatchHeader.Ministry_NameOther = dt_Deductor.Rows[37]["Deductor Info"].ToString();
        string PAO_RegistrationNo = dt_Deductor.Rows[38]["Deductor Info"].ToString();
        if (PAO_RegistrationNo == "" || PAO_RegistrationNo == null)
        {
            objtbl_BatchHeader.PAO_Register_No = 0;
        }
        else
        {
            objtbl_BatchHeader.PAO_Register_No = Convert.ToInt32(PAO_RegistrationNo);
        }

        objtbl_BatchHeader.DDO_RegistrationNo = dt_Deductor.Rows[39]["Deductor Info"].ToString();
        objtbl_BatchHeader.Page_ID = "2";
        objtbl_BatchHeader.Page_SubModule_ID = "3";
        //Create Other Parameters Required
        objtbl_BatchHeader.Form_Number = ViewState["FormType"].ToString();
        ViewState["FormNo"] = objtbl_BatchHeader.Form_Number.ToString();
        objtbl_BatchHeader.Financial_Year = Convert.ToInt32(ViewState["FY"]);
        objtbl_BatchHeader.Regular_Correction = "Regular";
        ViewState["Regular_Correction"] = objtbl_BatchHeader.Regular_Correction.ToString();
        objtbl_BatchHeader.CorrectionType = "";
        //Get ID from Master
        objtbl_FileHeader.TAN = ViewState["TAN"].ToString();
        objtbl_FileHeader.FinancialYear = ViewState["FY"].ToString();
        objtbl_FileHeader.Quarter = ViewState["Quarter"].ToString();
        objtbl_FileHeader.FormType = objtbl_BatchHeader.Form_Number.ToString();

        //Batch HeaderLine
        objtbl_BatchHeader.ID = objBltbl_FileHeader.GetIDFromMaster(objtbl_FileHeader);


        int success = objBltbl_BatchHeader.InsertBatchHeaderFileFromExcel(objtbl_BatchHeader);
        if (success == 1)
        {
            objtbl_BatchHeader.ID = -999999999;
            objBltbl_BatchHeader.InsertBatchHeaderFileFromExcel(objtbl_BatchHeader);
            InsertTANMaster_Excel(dt_Deductor);
        }
        return success;
    }
    //Function to Insert Challan Detail
    public DataTable InsertChallanDetails_Excel(DataTable dt_ChallanDetail, string FormNo)
    {
        DataTable dt_Challan = new DataTable();
        //Code of saving Challan
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";

        int IDAdmin = Convert.ToInt32(ViewState["IDAdmin"]);
        //Create Parameters For Inserting Challan Deatils
        objtbl_ChallanDetails.FormType = ViewState["FormType"].ToString();
        objtbl_ChallanDetails.TAN = ViewState["TAN"].ToString();
        objtbl_ChallanDetails.TANNo = ViewState["TAN"].ToString();
        objtbl_ChallanDetails.Quarter = ViewState["Quarter"].ToString();
        objtbl_ChallanDetails.FinancialYear = ViewState["FY"].ToString();
        objtbl_ChallanDetails.Regular_Correction = "Regular";
        objtbl_ChallanDetails.Correction_Type = "";
        objtbl_ChallanDetails.ID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
        ViewState["Master_ID"] = objtbl_ChallanDetails.ID;
        dt_Challan = objFillTableFromExcel.Convert_DataTable("tbl_ChallanTransferVoucherDetail", "\t");

        dt_Challan.Clear();
        int count = dt_ChallanDetail.Rows.Count;
        int success = 0;
        foreach (DataRow rows in dt_ChallanDetail.Rows)
        {
            if (rows.ItemArray[0].ToString() != "")
            {
                countChallanRecord = countChallanRecord + 1;
            }
        }

        for (int i = 0; i < dt_ChallanDetail.Rows.Count; i++)
        {
            int j = 0;


            if (FormNo == "Form24Q")
            {
                string Check_EmptyField = dt_ChallanDetail.Rows[i][0].ToString();
                if (Check_EmptyField != "")
                {
                    objtbl_ChallanDetails.ChallanID = Convert.ToInt32(dt_ChallanDetail.Rows[i][j]);
                    ViewState["ChallanID"] = objtbl_ChallanDetails.ChallanID;
                    int Challan_ID = Convert.ToInt32(ViewState["ChallanID"]);
                    objtbl_ChallanDetails.Section = dt_ChallanDetail.Rows[i][j + 1].ToString();
                    //Section Field
                    string Section = dt_ChallanDetail.Rows[i][j + 1].ToString();
                    objtbl_ChallanDetails.Section = Section;

                    //Format Income Tax Field
                    string Income_Tax = dt_ChallanDetail.Rows[i][j + 2].ToString();
                    // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
                    if (Income_Tax != "")
                    {
                        objtbl_ChallanDetails.Oltas_TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);
                        objtbl_ChallanDetails.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);
                    }

                    string Nill_Challan_Indicator = string.Empty;
                    if (Income_Tax == "0")
                    {
                        Nill_Challan_Indicator = "Y";
                    }
                    else
                    {
                        Nill_Challan_Indicator = "N";
                    }

                    //Format Surcharge Field
                    string Surcharge = dt_ChallanDetail.Rows[i][j + 3].ToString();
                    //Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);
                    objtbl_ChallanDetails.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

                    //Format Education Cess Field
                    string Education_Cess = dt_ChallanDetail.Rows[i][j + 4].ToString();
                    // Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_Cess = Convert.ToDouble(Education_Cess);
                    objtbl_ChallanDetails.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);


                    //Format Interest Field
                    string Interest = dt_ChallanDetail.Rows[i][j + 5].ToString();
                    // Interest = string.Format("{0:f2}", Int32.Parse(Interest));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_InterestAMT = Convert.ToDouble(Interest);
                    objtbl_ChallanDetails.TDS_TCS_InterestAMT = Convert.ToDouble(Interest);

                    //Format Others Field
                    string Others = dt_ChallanDetail.Rows[i][j + 6].ToString();
                    //Others = string.Format("{0:f2}", Int32.Parse(Others));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_Others = Convert.ToDouble(Others);
                    objtbl_ChallanDetails.TDS_TCS_Others = Convert.ToDouble(Others);

                    //Format Total Tax Deposit Amt Field
                    string Total_Tax_Deposited = dt_ChallanDetail.Rows[i][j + 7].ToString();
                    //Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
                    objtbl_ChallanDetails.Total_TAX_Deposite_Amount = (Total_Tax_Deposited.ToString() == "") ? Convert.ToDouble(string.Format("0.00", Total_Tax_Deposited)) : Convert.ToDouble(Total_Tax_Deposited);
                    objtbl_ChallanDetails.TotalDepositeAmount = (Total_Tax_Deposited.ToString() == "") ? Convert.ToDouble(string.Format("0.00", Total_Tax_Deposited)) : Convert.ToDouble(Total_Tax_Deposited);
                    objtbl_ChallanDetails.Total_IncomeTAX_Deducted = Convert.ToDouble(objtbl_ChallanDetails.Total_TAX_Deposite_Amount);
                    //Field ChequeDDNo
                    string ChequeNO = dt_ChallanDetail.Rows[i][j + 8].ToString();
                    string cheque = string.Empty;
                    if (ChequeNO == "")
                    {
                        cheque = "";

                    }
                    else
                    {
                        cheque = dt_ChallanDetail.Rows[i][j + 8].ToString();
                    }
                    objtbl_ChallanDetails.Cheque_DD_No = cheque;
                    //Field BSRCode
                    objtbl_ChallanDetails.Bank_Branch_Code = dt_ChallanDetail.Rows[i][j + 9].ToString();
                    //Field Date on which Tax Deposited

                    string BankChallanDate = dt_ChallanDetail.Rows[i][j + 10].ToString();
                    BankChallanDate = BankChallanDate.Replace("-", "");
                    objtbl_ChallanDetails.Date_Of_Bank_ChallanNo = BankChallanDate;
                    ViewState["BankChallanDate"] = BankChallanDate;
                    //Field BankChallanNo
                    string Bank_Challan_No = dt_ChallanDetail.Rows[i][j + 11].ToString();
                    if (Bank_Challan_No == "")
                    {
                        objtbl_ChallanDetails.Bank_Challan_No = 0;
                    }
                    else
                    {
                        objtbl_ChallanDetails.Bank_Challan_No = Convert.ToInt32(dt_ChallanDetail.Rows[i][j + 11]);
                    }
                    string Transfer_VoucherNo = dt_ChallanDetail.Rows[i][j + 12].ToString();
                    //Field ByBook Entry.
                    string ByBookEntry = dt_ChallanDetail.Rows[i][j + 13].ToString();
                    ViewState["By_Book_Entry"] = ByBookEntry;
                    objtbl_ChallanDetails.By_BookEntry = ByBookEntry;
                    //Fee Field
                    string Fee = dt_ChallanDetail.Rows[i][j + 14].ToString();
                    //Minor_Head Challan
                    string Minor_Head_Challan = dt_ChallanDetail.Rows[i][j + 15].ToString();



                    objtbl_ChallanDetails.Remarks = "";


                    objtbl_ChallanDetails.Page_ID = "2";
                    objtbl_ChallanDetails.Page_SubModule_ID = "3";

                    DataRow dr_Challan = dt_Challan.NewRow();
                    dr_Challan["ChallanID"] = Challan_ID;
                    dr_Challan["ID"] = ViewState["Master_ID"].ToString();
                    dr_Challan["Line_Number"] = 0;
                    dr_Challan["Record_Type"] = "CD";
                    dr_Challan["Batch_Number"] = "1";
                    dr_Challan["Challan_Detail_Record_No"] = Challan_ID;
                    dr_Challan["Count_Of_deductee_PartyRecords"] = 0;
                    dr_Challan["Nill_Challan_Indicator"] = Nill_Challan_Indicator;
                    dr_Challan["Challan_Updation_Indicator"] = "0";
                    dr_Challan["Filler2"] = "";
                    dr_Challan["Filler3"] = "";
                    dr_Challan["Filler4"] = "";

                    dr_Challan["Last_Bank_Challan_No"] = "";

                    dr_Challan["Last_Bank_Challan_No"] = "";
                    if (ByBookEntry == "N")
                    {
                        dr_Challan["Bank_Challan_No"] = Bank_Challan_No;
                    }
                    else
                    {
                        dr_Challan["Bank_Challan_No"] = "";
                    }

                    dr_Challan["Last_Transfer_Voucher_No"] = "";
                    if (ByBookEntry == "Y")
                    {
                        dr_Challan["TransferVoucher_DDO_SerialNo"] = Transfer_VoucherNo;
                    }
                    else
                    {
                        dr_Challan["TransferVoucher_DDO_SerialNo"] = "";
                    }



                    dr_Challan["Last_Bank_Branch_Code"] = "";
                    dr_Challan["Bank_Branch_Code"] = objtbl_ChallanDetails.Bank_Branch_Code.ToString();
                    dr_Challan["Last_date_Of_BankChallanNo"] = "";
                    dr_Challan["Date_Of_Bank_ChallanNo"] = BankChallanDate;
                    dr_Challan["Filler5"] = "";
                    dr_Challan["Filler6"] = "";
                    dr_Challan["Section"] = Section;
                    dr_Challan["Oltas_TDS_TCS_IncomeTAX"] = objtbl_ChallanDetails.Oltas_TDS_TCS_IncomeTAX;
                    dr_Challan["Oltas_TDS_TCS_Surcharge"] = objtbl_ChallanDetails.Oltas_TDS_TCS_Surcharge;
                    dr_Challan["Oltas_TDS_TCS_Cess"] = objtbl_ChallanDetails.Oltas_TDS_TCS_Cess;
                    dr_Challan["Oltas_TDS_TCS_InterestAMT"] = objtbl_ChallanDetails.Oltas_TDS_TCS_InterestAMT;
                    dr_Challan["Oltas_TDS_TCS_Others"] = objtbl_ChallanDetails.Oltas_TDS_TCS_Others;
                    dr_Challan["TotalDepositeAmount"] = Total_Tax_Deposited;
                    dr_Challan["Last_Total_DepositAmount"] = "";
                    dr_Challan["Total_TAX_Deposite_Amount"] = Total_Tax_Deposited;
                    dr_Challan["TDS_TCS_IncomeTAX"] = "0.00";
                    dr_Challan["TDS_TCS_Surcharge"] = "0.00";
                    dr_Challan["TDS_TCS_Cess"] = "0.00";
                    dr_Challan["Total_IncomeTAX_Deducted"] = 0.00;
                    dr_Challan["TDS_TCS_InterestAMT"] = objtbl_ChallanDetails.TDS_TCS_InterestAMT;
                    dr_Challan["TDS_TCS_Others"] = objtbl_ChallanDetails.TDS_TCS_Others;
                    dr_Challan["Cheque_DD_No"] = cheque;
                    dr_Challan["By_BookEntry"] = ByBookEntry;
                    dr_Challan["Remarks"] = "";
                    dr_Challan["Fee"] = Fee;
                    dr_Challan["Minor_Head_of_Challan"] = Minor_Head_Challan;
                    dr_Challan["Record_Hash"] = "";
                    dr_Challan["C1"] = "";
                    dr_Challan["C2"] = "";
                    dr_Challan["C3"] = "";
                    dr_Challan["C4"] = "";
                    dr_Challan["C5"] = "";
                    dr_Challan["C9"] = "";
                    dr_Challan["Y"] = "";
                    dr_Challan["Decision"] = "";
                    dr_Challan["ID_Admin"] = IDAdmin;
                    dt_Challan.Rows.Add(dr_Challan);
                    //success = objBltbl_ChallanDetails.InsertRecords(objtbl_ChallanDetails);
                }

            }
            else if (FormNo == "Form26Q" || FormNo == "Form27Q")
            {
                string Check_EmptyField = dt_ChallanDetail.Rows[i][0].ToString();
                if (Check_EmptyField != "")
                {
                    objtbl_ChallanDetails.ChallanID = Convert.ToInt32(dt_ChallanDetail.Rows[i][j]);
                    int Challan_ID = objtbl_ChallanDetails.ChallanID;
                    ViewState["ChallanID"] = objtbl_ChallanDetails.ChallanID;
                    objtbl_ChallanDetails.Section = dt_ChallanDetail.Rows[i][j + 1].ToString();
                    string Section = objtbl_ChallanDetails.Section.ToString();
                    //Format Income Tax Field
                    string Income_Tax = dt_ChallanDetail.Rows[i][j + 2].ToString();
                    //Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);
                    string Nill_Challan_Indicator = string.Empty;
                    if (Income_Tax == "0")
                    {
                        Nill_Challan_Indicator = "Y";
                    }
                    else
                    {
                        Nill_Challan_Indicator = "N";
                    }
                    objtbl_ChallanDetails.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);

                    //Format Surcharge Field
                    string Surcharge = dt_ChallanDetail.Rows[i][j + 3].ToString();
                    //Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);
                    objtbl_ChallanDetails.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

                    //Format Education Cess Field
                    string Education_Cess = dt_ChallanDetail.Rows[i][j + 4].ToString();
                    // Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_Cess = Convert.ToDouble(Education_Cess);
                    objtbl_ChallanDetails.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);


                    //Format Interest Field
                    string Interest = dt_ChallanDetail.Rows[i][j + 5].ToString();
                    //Interest = string.Format("{0:f2}", Int32.Parse(Interest));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_InterestAMT = Convert.ToDouble(Interest);
                    objtbl_ChallanDetails.TDS_TCS_InterestAMT = Convert.ToDouble(Interest);

                    //Format Others Field
                    string Others = dt_ChallanDetail.Rows[i][j + 6].ToString();
                    //Others = string.Format("{0:f2}", Int32.Parse(Others));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_Others = Convert.ToDouble(Others);
                    objtbl_ChallanDetails.TDS_TCS_Others = Convert.ToDouble(Others);

                    //Format Total Tax Deposit Amt Field
                    string Total_Tax_Deposited = dt_ChallanDetail.Rows[i][j + 7].ToString();
                    //Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
                    objtbl_ChallanDetails.Total_TAX_Deposite_Amount = Convert.ToDouble(Total_Tax_Deposited);
                    objtbl_ChallanDetails.TotalDepositeAmount = Convert.ToDouble(Total_Tax_Deposited);
                    objtbl_ChallanDetails.Total_IncomeTAX_Deducted = Convert.ToDouble(objtbl_ChallanDetails.Total_TAX_Deposite_Amount);
                    //Cheque DD No
                    //Field ChequeDDNo
                    string ChequeNO = dt_ChallanDetail.Rows[i][j + 8].ToString();
                    string cheque = string.Empty;
                    if (ChequeNO == "")
                    {
                        cheque = "";

                    }
                    else
                    {
                        cheque = dt_ChallanDetail.Rows[i][j + 8].ToString();
                    }
                    objtbl_ChallanDetails.Cheque_DD_No = cheque;

                    //Bank Branch Code
                    objtbl_ChallanDetails.Bank_Branch_Code = dt_ChallanDetail.Rows[i][j + 9].ToString();
                    //Date on Which Tax Deposited
                    // DateTime Date_Of_Bank_ChallanNo = Convert.ToDateTime(dt_ChallanDetail.Rows[i][j + 10]);
                    string BankChallanDate = dt_ChallanDetail.Rows[i][j + 10].ToString();
                    objtbl_ChallanDetails.Date_Of_Bank_ChallanNo = BankChallanDate;
                    ViewState["BankChallanDate"] = BankChallanDate;
                    //Bank Challan No
                    objtbl_ChallanDetails.Bank_Challan_No = Convert.ToInt32(dt_ChallanDetail.Rows[i][j + 11]);
                    string Bank_Challan_No = objtbl_ChallanDetails.Bank_Challan_No.ToString();
                    string Transfer_VoucherNo = dt_ChallanDetail.Rows[i][j + 12].ToString();
                    //By Book Entry

                    objtbl_ChallanDetails.By_BookEntry = dt_ChallanDetail.Rows[i][j + 13].ToString();
                    string ByBookEntry = objtbl_ChallanDetails.By_BookEntry.ToString();
                    ViewState["By_Book_Entry"] = ByBookEntry;
                    objtbl_ChallanDetails.Remarks = "";
                    //Fee Field
                    string Fee = dt_ChallanDetail.Rows[i][j + 14].ToString();
                    //Minor_Head Challan
                    string Minor_Head_Challan = dt_ChallanDetail.Rows[i][j + 15].ToString();



                    objtbl_ChallanDetails.Page_ID = "2";
                    objtbl_ChallanDetails.Page_SubModule_ID = "3";
                    DataRow dr_Challan = dt_Challan.NewRow();
                    dr_Challan["ChallanID"] = Challan_ID;
                    dr_Challan["ID"] = ViewState["Master_ID"].ToString();
                    dr_Challan["Line_Number"] = 0;
                    dr_Challan["Record_Type"] = "CD";
                    dr_Challan["Batch_Number"] = "1";
                    dr_Challan["Challan_Detail_Record_No"] = Challan_ID;
                    dr_Challan["Count_Of_deductee_PartyRecords"] = 0;
                    dr_Challan["Nill_Challan_Indicator"] = Nill_Challan_Indicator;
                    dr_Challan["Challan_Updation_Indicator"] = "0";
                    dr_Challan["Filler2"] = "";
                    dr_Challan["Filler3"] = "";
                    dr_Challan["Filler4"] = "";

                    dr_Challan["Last_Bank_Challan_No"] = "";
                    if (ByBookEntry == "N")
                    {
                        dr_Challan["Bank_Challan_No"] = Bank_Challan_No;
                    }
                    else
                    {
                        dr_Challan["Bank_Challan_No"] = "";
                    }

                    dr_Challan["Last_Transfer_Voucher_No"] = "";
                    if (ByBookEntry == "Y")
                    {
                        dr_Challan["TransferVoucher_DDO_SerialNo"] = Transfer_VoucherNo;
                    }
                    else
                    {
                        dr_Challan["TransferVoucher_DDO_SerialNo"] = "";
                    }


                    dr_Challan["Last_Bank_Branch_Code"] = "";
                    dr_Challan["Bank_Branch_Code"] = objtbl_ChallanDetails.Bank_Branch_Code.ToString();
                    dr_Challan["Last_date_Of_BankChallanNo"] = "";
                    dr_Challan["Date_Of_Bank_ChallanNo"] = BankChallanDate;
                    dr_Challan["Filler5"] = "";
                    dr_Challan["Filler6"] = "";
                    dr_Challan["Section"] = Section;
                    dr_Challan["Oltas_TDS_TCS_IncomeTAX"] = objtbl_ChallanDetails.Oltas_TDS_TCS_IncomeTAX;
                    dr_Challan["Oltas_TDS_TCS_Surcharge"] = objtbl_ChallanDetails.Oltas_TDS_TCS_Surcharge;
                    dr_Challan["Oltas_TDS_TCS_Cess"] = objtbl_ChallanDetails.Oltas_TDS_TCS_Cess;
                    dr_Challan["Oltas_TDS_TCS_InterestAMT"] = objtbl_ChallanDetails.Oltas_TDS_TCS_InterestAMT;
                    dr_Challan["Oltas_TDS_TCS_Others"] = objtbl_ChallanDetails.Oltas_TDS_TCS_Others;
                    dr_Challan["TotalDepositeAmount"] = Total_Tax_Deposited;
                    dr_Challan["Last_Total_DepositAmount"] = "";
                    dr_Challan["Total_TAX_Deposite_Amount"] = Total_Tax_Deposited;
                    dr_Challan["Total_TAX_Deposite_Amount"] = Total_Tax_Deposited;
                    dr_Challan["TDS_TCS_IncomeTAX"] = "0.00";
                    dr_Challan["TDS_TCS_Surcharge"] = "0.00";
                    dr_Challan["TDS_TCS_Cess"] = "0.00";
                    dr_Challan["Total_IncomeTAX_Deducted"] = 0.00;
                    dr_Challan["TDS_TCS_InterestAMT"] = objtbl_ChallanDetails.TDS_TCS_InterestAMT;
                    dr_Challan["TDS_TCS_Others"] = objtbl_ChallanDetails.TDS_TCS_Others;
                    dr_Challan["Cheque_DD_No"] = cheque;
                    dr_Challan["By_BookEntry"] = ByBookEntry;
                    dr_Challan["Fee"] = Fee;
                    dr_Challan["Minor_Head_of_Challan"] = Minor_Head_Challan;
                    dr_Challan["Remarks"] = "";
                    dr_Challan["Record_Hash"] = "";
                    dr_Challan["C1"] = "";
                    dr_Challan["C2"] = "";
                    dr_Challan["C3"] = "";
                    dr_Challan["C4"] = "";
                    dr_Challan["C5"] = "";
                    dr_Challan["C9"] = "";
                    dr_Challan["Y"] = "";
                    dr_Challan["Decision"] = "";
                    dr_Challan["ID_Admin"] = IDAdmin;
                    dt_Challan.Rows.Add(dr_Challan);
                }

            }
            else if (FormNo == "Form27EQ")
            {
                string Check_EmptyField = dt_ChallanDetail.Rows[i][0].ToString();
                if (Check_EmptyField != "")
                {
                    objtbl_ChallanDetails.ChallanID = Convert.ToInt32(dt_ChallanDetail.Rows[i][j]);
                    int Challan_ID = objtbl_ChallanDetails.ChallanID;
                    ViewState["ChallanID"] = objtbl_ChallanDetails.ChallanID;
                    objtbl_ChallanDetails.Section = dt_ChallanDetail.Rows[i][j + 1].ToString();
                    string Section = objtbl_ChallanDetails.Section.ToString();
                    //Format Income Tax Field
                    string Income_Tax = dt_ChallanDetail.Rows[i][j + 2].ToString();
                    // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);
                    objtbl_ChallanDetails.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);

                    string Nill_Challan_Indicator = string.Empty;
                    if (Income_Tax == "0")
                    {
                        Nill_Challan_Indicator = "Y";
                    }
                    else
                    {
                        Nill_Challan_Indicator = "N";
                    }

                    //Format Surcharge Field
                    string Surcharge = dt_ChallanDetail.Rows[i][j + 3].ToString();
                    // Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);
                    objtbl_ChallanDetails.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

                    //Format Education Cess Field
                    string Education_Cess = dt_ChallanDetail.Rows[i][j + 4].ToString();
                    //Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_Cess = Convert.ToDouble(Education_Cess);
                    objtbl_ChallanDetails.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);


                    //Format Interest Field
                    string Interest = dt_ChallanDetail.Rows[i][j + 5].ToString();
                    // Interest = string.Format("{0:f2}", Int32.Parse(Interest));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_InterestAMT = Convert.ToDouble(Interest);
                    objtbl_ChallanDetails.TDS_TCS_InterestAMT = Convert.ToDouble(Interest);

                    //Format Others Field
                    string Others = dt_ChallanDetail.Rows[i][j + 6].ToString();
                    //Others = string.Format("{0:f2}", Int32.Parse(Others));
                    objtbl_ChallanDetails.Oltas_TDS_TCS_Others = Convert.ToDouble(Others);
                    objtbl_ChallanDetails.TDS_TCS_Others = Convert.ToDouble(Others);

                    //Format Total Tax Deposit Amt Field
                    string Total_Tax_Deposited = dt_ChallanDetail.Rows[i][j + 7].ToString();
                    // Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
                    objtbl_ChallanDetails.Total_TAX_Deposite_Amount = Convert.ToDouble(Total_Tax_Deposited);
                    objtbl_ChallanDetails.TotalDepositeAmount = Convert.ToDouble(Total_Tax_Deposited);
                    objtbl_ChallanDetails.Total_IncomeTAX_Deducted = Convert.ToDouble(objtbl_ChallanDetails.Total_TAX_Deposite_Amount);
                    //Cheque DD No
                    //Field ChequeDDNo
                    string ChequeNO = dt_ChallanDetail.Rows[i][j + 8].ToString();
                    string cheque = string.Empty;
                    if (ChequeNO == "")
                    {
                        cheque = "";

                    }
                    else
                    {
                        cheque = dt_ChallanDetail.Rows[i][j + 8].ToString();
                    }
                    objtbl_ChallanDetails.Cheque_DD_No = cheque;
                    //Bank Branch Code
                    objtbl_ChallanDetails.Bank_Branch_Code = dt_ChallanDetail.Rows[i][j + 9].ToString();
                    //Date on Which Tax Deposited

                    string BankChallanDate = dt_ChallanDetail.Rows[i][j + 10].ToString();
                    objtbl_ChallanDetails.Date_Of_Bank_ChallanNo = BankChallanDate;
                    //Bank Challan No
                    objtbl_ChallanDetails.Bank_Challan_No = Convert.ToInt32(dt_ChallanDetail.Rows[i][j + 11]);
                    string Bank_Challan_No = objtbl_ChallanDetails.Bank_Challan_No.ToString();
                    string Transfer_VoucherNo = dt_ChallanDetail.Rows[i][j + 12].ToString();
                    //By Book Entry
                    objtbl_ChallanDetails.By_BookEntry = dt_ChallanDetail.Rows[i][j + 13].ToString();
                    string ByBookEntry = objtbl_ChallanDetails.By_BookEntry.ToString();
                    ViewState["By_Book_Entry"] = ByBookEntry;
                    objtbl_ChallanDetails.Remarks = "";


                    //Fee Field
                    string Fee = dt_ChallanDetail.Rows[i][j + 14].ToString();
                    //Minor_Head Challan
                    string Minor_Head_Challan = dt_ChallanDetail.Rows[i][j + 15].ToString();

                    objtbl_ChallanDetails.Page_ID = "2";
                    objtbl_ChallanDetails.Page_SubModule_ID = "3";
                    DataRow dr_Challan = dt_Challan.NewRow();
                    dr_Challan["ChallanID"] = Challan_ID;
                    dr_Challan["ID"] = ViewState["Master_ID"].ToString(); ;
                    dr_Challan["Line_Number"] = 0;
                    dr_Challan["Record_Type"] = "CD";
                    dr_Challan["Batch_Number"] = "1";
                    dr_Challan["Challan_Detail_Record_No"] = Challan_ID;
                    dr_Challan["Count_Of_deductee_PartyRecords"] = 0;
                    dr_Challan["Nill_Challan_Indicator"] = Nill_Challan_Indicator;
                    dr_Challan["Challan_Updation_Indicator"] = "0";
                    dr_Challan["Filler2"] = "";
                    dr_Challan["Filler3"] = "";
                    dr_Challan["Filler4"] = "";

                    dr_Challan["Last_Bank_Challan_No"] = "";

                    dr_Challan["Last_Bank_Challan_No"] = "";
                    if (ByBookEntry == "N")
                    {
                        dr_Challan["Bank_Challan_No"] = Bank_Challan_No;
                    }
                    else
                    {
                        dr_Challan["Bank_Challan_No"] = "";
                    }

                    dr_Challan["Last_Transfer_Voucher_No"] = "";
                    if (ByBookEntry == "Y")
                    {
                        dr_Challan["TransferVoucher_DDO_SerialNo"] = Transfer_VoucherNo;
                    }
                    else
                    {
                        dr_Challan["TransferVoucher_DDO_SerialNo"] = "";
                    }



                    dr_Challan["Last_Bank_Branch_Code"] = "";
                    dr_Challan["Bank_Branch_Code"] = objtbl_ChallanDetails.Bank_Branch_Code.ToString();
                    dr_Challan["Last_date_Of_BankChallanNo"] = "";
                    dr_Challan["Date_Of_Bank_ChallanNo"] = BankChallanDate;
                    dr_Challan["Filler5"] = "";
                    dr_Challan["Filler6"] = "";
                    dr_Challan["Section"] = Section;
                    dr_Challan["Oltas_TDS_TCS_IncomeTAX"] = objtbl_ChallanDetails.Oltas_TDS_TCS_IncomeTAX;
                    dr_Challan["Oltas_TDS_TCS_Surcharge"] = objtbl_ChallanDetails.Oltas_TDS_TCS_Surcharge;
                    dr_Challan["Oltas_TDS_TCS_Cess"] = objtbl_ChallanDetails.Oltas_TDS_TCS_Cess;
                    dr_Challan["Oltas_TDS_TCS_InterestAMT"] = objtbl_ChallanDetails.Oltas_TDS_TCS_InterestAMT;
                    dr_Challan["Oltas_TDS_TCS_Others"] = objtbl_ChallanDetails.Oltas_TDS_TCS_Others;
                    dr_Challan["TotalDepositeAmount"] = Total_Tax_Deposited;
                    dr_Challan["Last_Total_DepositAmount"] = "";
                    dr_Challan["Total_TAX_Deposite_Amount"] = Total_Tax_Deposited;
                    dr_Challan["Total_TAX_Deposite_Amount"] = Total_Tax_Deposited;
                    dr_Challan["TDS_TCS_IncomeTAX"] = "0.00";
                    dr_Challan["TDS_TCS_Surcharge"] = "0.00";
                    dr_Challan["TDS_TCS_Cess"] = "0.00";
                    dr_Challan["Total_IncomeTAX_Deducted"] = 0.00;
                    dr_Challan["TDS_TCS_InterestAMT"] = objtbl_ChallanDetails.TDS_TCS_InterestAMT;
                    dr_Challan["TDS_TCS_Others"] = objtbl_ChallanDetails.TDS_TCS_Others;
                    dr_Challan["Cheque_DD_No"] = cheque;
                    dr_Challan["By_BookEntry"] = ByBookEntry;
                    dr_Challan["Remarks"] = "";
                    dr_Challan["Fee"] = Fee;
                    dr_Challan["Minor_Head_of_Challan"] = Minor_Head_Challan;
                    dr_Challan["Record_Hash"] = "";
                    dr_Challan["C1"] = "";
                    dr_Challan["C2"] = "";
                    dr_Challan["C3"] = "";
                    dr_Challan["C4"] = "";
                    dr_Challan["C5"] = "";
                    dr_Challan["C9"] = "";
                    dr_Challan["Y"] = "";
                    dr_Challan["Decision"] = "";
                    dr_Challan["ID_Admin"] = IDAdmin;
                    dt_Challan.Rows.Add(dr_Challan);

                }

            }


        }

        //if (success == 1)
        //{
        //    objtbl_ChallanDetails.ChallanID = -999999999;
        //    objBltbl_ChallanDetails.InsertRecords(objtbl_ChallanDetails);
        //}

        ViewState["ChallanTable"] = dt_Challan;
        return dt_Challan;
    }

    //Function to Insert Deductee Detail
    //public DataTable InsertDeducteeDetails_Excel(DataTable dt_DeducteeDetail, string FormNo)
    //{

    //    //Code of saving Challan
    //    DBtbl_Module.ArrayIndex = 0;
    //    DBtbl_Module.count = 0;
    //    DBtbl_Module.lst_Field = new Dictionary<string, int>();
    //    DBtbl_Module.lst_Query = new List<string>();
    //    DBtbl_Module.lst_update = new List<string[]>();
    //    DBtbl_Module.Previous_RecordNo = 0;
    //    DBtbl_Module.Previous_Table = "";
    //    //Create Parameters For Inserting Challan Deatils
    //    objtbl_DeducteeDetail.FormType = ViewState["FormType"].ToString();
    //    objtbl_DeducteeDetail.TAN = ViewState["TAN"].ToString();
    //    objtbl_DeducteeDetail.Quarter = ViewState["Quarter"].ToString();
    //    objtbl_DeducteeDetail.FinancialYear = ViewState["FY"].ToString();
    //    objtbl_DeducteeDetail.Regular_Correction = "Regular";
    //    objtbl_DeducteeDetail.Correction_Type = "";
    //    //Create Parameters For Inserting Challan Deatils for getting MasterID
    //    objtbl_ChallanDetails.FormType = ViewState["FormType"].ToString();
    //    objtbl_ChallanDetails.TAN = ViewState["TAN"].ToString();
    //    objtbl_ChallanDetails.TANNo = ViewState["TAN"].ToString();
    //    objtbl_ChallanDetails.Quarter = ViewState["Quarter"].ToString();
    //    objtbl_ChallanDetails.FinancialYear = ViewState["FY"].ToString();
    //    objtbl_ChallanDetails.Regular_Correction = "Regular";
    //    objtbl_ChallanDetails.Correction_Type = "";
    //    //Get ChallanID
    //    DataTable dt_Deductee = new DataTable();
    //    DataTable dt_Challan = new DataTable();
    //   dt_Challan=(DataTable)ViewState["ChallanTable"];
    //   dt_Challan.CaseSensitive = false;

    //    dt_Deductee = objFillTableFromExcel.Convert_DataTable("tbl_DeducteeDetail_Record", "\t");
    //    dt_Deductee.Clear();
    //    string Cash_Entry = string.Empty;
    //     int Master_ID= objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
    //     int IDAdmin = Convert.ToInt32(ViewState["IDAdmin"]);
    //    objtbl_DeducteeDetail.MasterID = Master_ID;
    //    int deducteecount = dt_DeducteeDetail.Rows.Count;
    //    int success = 0;
    //    int Challan_ID=0;
    //    string Section_Code = string.Empty;
    //    string Certificate_Number = string.Empty;
    //    string WhetherTDSRateofTDSIsITAct27 = string.Empty;
    //    string Nature_of_Remittance_27 = string.Empty;
    //    string Unique_formno_15CA_27 = string.Empty;
    //    string Country_to_which_remittance_is_made_27 = string.Empty;

    //    foreach (DataRow rows in dt_DeducteeDetail.Rows)
    //    {
    //        if (rows.ItemArray[0].ToString() != "")
    //        {
    //            countdeducteeRecord = countdeducteeRecord + 1;
    //        }
    //    }

    //    for (int i = 0; i < countdeducteeRecord; i++)
    //    {
    //        int k = 0;
    //        Challan_ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
    //        if (FormNo == "Form24Q")
    //        {
    //            DataRow[] dr_Challan_Deductee = dt_Challan.Select("ChallanID=" + Challan_ID + "");

    //            objtbl_DeducteeDetail.ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
    //            objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k + 1]);
    //            objtbl_DeducteeDetail.Deductee_PartyCode = "";
    //            objtbl_DeducteeDetail.EmployeePAN = dt_DeducteeDetail.Rows[i][k + 2].ToString();
    //            objtbl_DeducteeDetail.NameofEmployee_Party = dt_DeducteeDetail.Rows[i][k + 3].ToString();
    //            objtbl_DeducteeDetail.DateOnWhich_AMTPaid = dt_DeducteeDetail.Rows[i][k + 4].ToString();
    //            objtbl_DeducteeDetail.Dateof_Deposit = dr_Challan_Deductee[0]["Date_Of_Bank_ChallanNo"].ToString();
    //            //Format Amount of Payment Field
    //            string Amount_of_payment = dt_DeducteeDetail.Rows[i][k + 5].ToString();
    //            // Amount_of_payment = string.Format("{0:f2}", Int32.Parse(Amount_of_payment));
    //            objtbl_DeducteeDetail.Amountof_Payment = Convert.ToDouble(Amount_of_payment);

    //            //Format Income Tax Field
    //            string Income_Tax = dt_DeducteeDetail.Rows[i][k + 6].ToString();
    //            // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
    //            objtbl_DeducteeDetail.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);

    //            //Format Surcharge Field
    //            string Surcharge = dt_DeducteeDetail.Rows[i][k + 7].ToString();
    //            //Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
    //            objtbl_DeducteeDetail.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

    //            //Format Education_Cess Field
    //            string Education_Cess = dt_DeducteeDetail.Rows[i][k + 8].ToString();
    //            //Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
    //            objtbl_DeducteeDetail.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);

    //            //Format Total Tax Deposited Field
    //            string Total_Tax_Deposited = dt_DeducteeDetail.Rows[i][k + 9].ToString();
    //            //Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
    //            objtbl_DeducteeDetail.Total_TaxDeposited = Convert.ToDouble(Total_Tax_Deposited);


    //            objtbl_DeducteeDetail.Total_IncomeTAX_Deducted = objtbl_DeducteeDetail.Total_TaxDeposited;

    //            objtbl_DeducteeDetail.DateonWhich_TaxDeducted = dt_DeducteeDetail.Rows[i][k + 10].ToString();
    //            string Book_Entry = dt_DeducteeDetail.Rows[i][k + 11].ToString();
    //            Cash_Entry = Income_Tax;
    //            objtbl_DeducteeDetail.BookEntry_CashIndicator = Book_Entry;


    //            objtbl_DeducteeDetail.Reason_For_NonDeduction = dt_DeducteeDetail.Rows[i][k + 12].ToString();
    //            Section_Code = dt_DeducteeDetail.Rows[i][k + 13].ToString();
    //            Certificate_Number = dt_DeducteeDetail.Rows[i][k + 14].ToString();
    //            WhetherTDSRateofTDSIsITAct27 = dt_DeducteeDetail.Rows[i][k + 15].ToString();
    //            Nature_of_Remittance_27 = dt_DeducteeDetail.Rows[i][k + 16].ToString();
    //            Unique_formno_15CA_27 = dt_DeducteeDetail.Rows[i][k + 17].ToString();
    //            Country_to_which_remittance_is_made_27 = dt_DeducteeDetail.Rows[i][k + 18].ToString();
    //            objtbl_DeducteeDetail.Deductee_PartyCode = "";
    //            //Format Rate at which Tax Deducted
    //            //string Rate = dt_DeducteeDetail.Rows[i][k + 9].ToString();
    //            //Rate = string.Format("{0:f4}", Int32.Parse(Rate));
    //            objtbl_DeducteeDetail.RateatWhich_TAXDeducted = "0.0000";
    //            objtbl_DeducteeDetail.Page_ID = "2";
    //            objtbl_DeducteeDetail.Page_SubModule_ID = "3";
    //            DataRow dr_Deductee = dt_Deductee.NewRow();
    //            dr_Deductee["DeducteeID"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["ID"] =Challan_ID;
    //            dr_Deductee["MasterID"] = Master_ID;
    //            dr_Deductee["Line_Number"] = 0;
    //            dr_Deductee["Record_Type"] = "DD";
    //            dr_Deductee["Batch_Number"] = "1";
    //            dr_Deductee["Challan_Detail_Rec_No"] =Challan_ID;
    //            dr_Deductee["DeducteeParty_Record_No"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["Mode"] ="O";
    //            dr_Deductee["Employee_SerialNo"] = Challan_ID;
    //            dr_Deductee["LastEmployee_PartyPAN"] = "";
    //            dr_Deductee["Deductee_PartyCode"] = objtbl_DeducteeDetail.Deductee_PartyCode;
    //            dr_Deductee["EmployeePAN"] = objtbl_DeducteeDetail.EmployeePAN;
    //            dr_Deductee["Last_EmployeePartyPAN"] = "";
    //            dr_Deductee["PAN_RefNO"] = "";
    //            dr_Deductee["NameofEmployee_Party"] = objtbl_DeducteeDetail.NameofEmployee_Party;
    //            dr_Deductee["TDS_TCS_IncomeTAX"] = Income_Tax;
    //            dr_Deductee["TDS_TCS_Surcharge"] = Surcharge;
    //            dr_Deductee["TDS_TCS_Cess"] = Education_Cess;
    //            dr_Deductee["Total_IncomeTAX_Deducted"] = objtbl_DeducteeDetail.Total_IncomeTAX_Deducted;
    //            dr_Deductee["Last_Income_TaxDeducted"] = "";
    //            dr_Deductee["Total_TaxDeposited"] = Total_Tax_Deposited;
    //            dr_Deductee["LastTotal_TaxDeposited"] = "";
    //            dr_Deductee["Total_ValuePurchase"] ="";
    //            dr_Deductee["Amountof_Payment"] =Amount_of_payment;
    //            dr_Deductee["DateOnWhich_AMTPaid"] = objtbl_DeducteeDetail.DateOnWhich_AMTPaid;
    //            dr_Deductee["DateonWhich_TaxDeducted"] = objtbl_DeducteeDetail.DateonWhich_TaxDeducted;
    //            dr_Deductee["Dateof_Deposit"] = objtbl_DeducteeDetail.Dateof_Deposit;
    //            dr_Deductee["RateatWhich_TAXDeducted"] = "";
    //            dr_Deductee["GrossingUP_Indicator"] ="";
    //            dr_Deductee["BookEntry_CashIndicator"] = Book_Entry;
    //            dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";
    //            dr_Deductee["Reason_For_NonDeduction"] = objtbl_DeducteeDetail.Reason_For_NonDeduction;
    //            dr_Deductee["Remarks1"] = "";
    //            dr_Deductee["Remarks2"] = "";
    //            dr_Deductee["Section_Code"] = Section_Code;
    //            dr_Deductee["Certificate_Number"] = Certificate_Number;
    //            dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = WhetherTDSRateofTDSIsITAct27;
    //            dr_Deductee["Nature_of_Remittance_27"] = Nature_of_Remittance_27;
    //            dr_Deductee["Unique_formno_15CA_27"] = Unique_formno_15CA_27;
    //            dr_Deductee["Country_to_which_remittance_is_made_27"] = Country_to_which_remittance_is_made_27;

    //            dr_Deductee["RecordHash"] = "";
    //            dr_Deductee["DeleteFlag"] = "";
    //            dr_Deductee["C1"] = "";
    //            dr_Deductee["C2"] = "";
    //            dr_Deductee["C3"] = "";
    //            dr_Deductee["C4"] = "";
    //            dr_Deductee["C5"] = "";
    //            dr_Deductee["C9"] = "";
    //            dr_Deductee["Y"] = "";
    //            dr_Deductee["Desicion"] = "";
    //            dr_Deductee["ID_Admin"] = IDAdmin;
    //            dt_Deductee.Rows.Add(dr_Deductee);




    //        }
    //        else if (FormNo == "Form26Q" || FormNo == "Form27Q")
    //        {
    //            objtbl_DeducteeDetail.ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
    //            objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k + 1]);
    //            objtbl_DeducteeDetail.Deductee_PartyCode = dt_DeducteeDetail.Rows[i][k + 2].ToString();
    //            objtbl_DeducteeDetail.EmployeePAN = dt_DeducteeDetail.Rows[i][k + 3].ToString();
    //            objtbl_DeducteeDetail.NameofEmployee_Party = dt_DeducteeDetail.Rows[i][k + 4].ToString();
    //            //Format Amount of Payment Field
    //            string Amount_of_payment = dt_DeducteeDetail.Rows[i][k + 5].ToString();
    //            // Amount_of_payment = string.Format("{0:f2}", Int32.Parse(Amount_of_payment));
    //            objtbl_DeducteeDetail.Amountof_Payment = Convert.ToDouble(Amount_of_payment);
    //            if (dt_DeducteeDetail.Rows[i][k + 6].ToString() != "")
    //            {
    //                string DataType = dt_DeducteeDetail.Columns[6].DataType.ToString();
    //                if (DataType != "System.String")
    //                {
    //                    DateTime dt_On_Which_Amount_Paid = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 6]);
    //                    string Date_On_Which_Amount_Paid = dt_On_Which_Amount_Paid.ToString("dd/MM/yyyy");


    //                    Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
    //                }
    //                else
    //                {
    //                    string Date_Paid = dt_DeducteeDetail.Rows[i][k + 6].ToString();
    //                    string Date_On_Which_Amount_Paid = Date_Paid;


    //                    Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
    //                }
    //            }
    //            else
    //            {
    //                objtbl_DeducteeDetail.DateOnWhich_AMTPaid = "";
    //            }

    //            if (dt_DeducteeDetail.Rows[i][k + 13].ToString() != "")
    //            {
    //                string DataType = dt_DeducteeDetail.Columns[13].DataType.ToString();
    //                if (DataType != "System.String")
    //                {
    //                    DateTime dt_On_Which_Tax_Deducted = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 13]);
    //                    string Date_On_Which_Tax_Deducted = dt_On_Which_Tax_Deducted.ToString("dd/MM/yyyy");

    //                    Date_On_Which_Tax_Deducted = Date_On_Which_Tax_Deducted.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Tax_Deducted;
    //                }
    //                else
    //                {
    //                    string Date_Deducted = dt_DeducteeDetail.Rows[i][k + 13].ToString();
    //                    string Date_On_Which_Amount_Deducted = Date_Deducted;


    //                    Date_On_Which_Amount_Deducted = Date_On_Which_Amount_Deducted.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Amount_Deducted;
    //                }
    //            }

    //            //Format Rate at which Tax Deducted Field
    //            string Rate_at_Which_Tax_Deducted = dt_DeducteeDetail.Rows[i][k + 7].ToString();
    //             Rate_at_Which_Tax_Deducted = string.Format("{0:f4}", Double.Parse(Rate_at_Which_Tax_Deducted));

    //             //objtbl_DeducteeDetail.RateatWhich_TAXDeducted = Rate_at_Which_Tax_Deducted.ToString()+".0000";
    //             objtbl_DeducteeDetail.RateatWhich_TAXDeducted = Rate_at_Which_Tax_Deducted.ToString() ;

    //            //Deposit Tax By Book Entry
    //            objtbl_DeducteeDetail.BookEntry_CashIndicator = dt_DeducteeDetail.Rows[i][k + 8].ToString();
    //            string Book_Entry = objtbl_DeducteeDetail.BookEntry_CashIndicator.ToString();

    //            //Format Income Tax Field
    //            string Income_Tax = dt_DeducteeDetail.Rows[i][k + 9].ToString();
    //            Cash_Entry = Income_Tax;
    //            // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
    //            objtbl_DeducteeDetail.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);

    //            //Format Surcharge Field
    //            string Surcharge = dt_DeducteeDetail.Rows[i][k + 10].ToString();
    //            // Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
    //            objtbl_DeducteeDetail.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

    //            //Format Education_Cess Field
    //            string Education_Cess = dt_DeducteeDetail.Rows[i][k + 11].ToString();
    //            //  Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
    //            objtbl_DeducteeDetail.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);

    //            //Format Total Tax Deposited Field
    //            string Total_Tax_Deposited = dt_DeducteeDetail.Rows[i][k + 12].ToString();
    //            // Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
    //            objtbl_DeducteeDetail.Total_TaxDeposited = Convert.ToDouble(Total_Tax_Deposited);


    //            objtbl_DeducteeDetail.Total_IncomeTAX_Deducted = objtbl_DeducteeDetail.Total_TaxDeposited;



    //            objtbl_DeducteeDetail.Reason_For_NonDeduction = dt_DeducteeDetail.Rows[i][k + 14].ToString();
    //            Section_Code = dt_DeducteeDetail.Rows[i][k + 15].ToString();
    //            Certificate_Number = dt_DeducteeDetail.Rows[i][k + 16].ToString();
    //            WhetherTDSRateofTDSIsITAct27 = dt_DeducteeDetail.Rows[i][k + 17].ToString();
    //            Nature_of_Remittance_27 = dt_DeducteeDetail.Rows[i][k + 18].ToString();
    //            Unique_formno_15CA_27 = dt_DeducteeDetail.Rows[i][k + 19].ToString();
    //            Country_to_which_remittance_is_made_27 = dt_DeducteeDetail.Rows[i][k + 20].ToString();
    //            objtbl_DeducteeDetail.Page_ID = "2";
    //            objtbl_DeducteeDetail.Page_SubModule_ID = "3";


    //            DataRow dr_Deductee = dt_Deductee.NewRow();
    //            dr_Deductee["DeducteeID"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["ID"] = Challan_ID;
    //            dr_Deductee["MasterID"] = Master_ID;
    //            dr_Deductee["Line_Number"] = 0;
    //            dr_Deductee["Record_Type"] = "DD";
    //            dr_Deductee["Batch_Number"] = "1";
    //            dr_Deductee["Challan_Detail_Rec_No"] = Challan_ID;
    //            dr_Deductee["DeducteeParty_Record_No"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["Mode"] = "O";
    //            dr_Deductee["Employee_SerialNo"] = "";
    //            dr_Deductee["LastEmployee_PartyPAN"] = "";
    //            dr_Deductee["Deductee_PartyCode"] = objtbl_DeducteeDetail.Deductee_PartyCode;
    //            dr_Deductee["EmployeePAN"] = objtbl_DeducteeDetail.EmployeePAN;
    //            dr_Deductee["Last_EmployeePartyPAN"] = "";
    //            dr_Deductee["PAN_RefNO"] = "";
    //            dr_Deductee["NameofEmployee_Party"] = objtbl_DeducteeDetail.NameofEmployee_Party;
    //            dr_Deductee["TDS_TCS_IncomeTAX"] = Income_Tax;
    //            dr_Deductee["TDS_TCS_Surcharge"] = Surcharge;
    //            dr_Deductee["TDS_TCS_Cess"] = Education_Cess;
    //            dr_Deductee["Total_IncomeTAX_Deducted"] = objtbl_DeducteeDetail.Total_IncomeTAX_Deducted;
    //            dr_Deductee["Last_Income_TaxDeducted"] = "";
    //            dr_Deductee["Total_TaxDeposited"] = Total_Tax_Deposited;
    //            dr_Deductee["LastTotal_TaxDeposited"] = "";
    //            dr_Deductee["Total_ValuePurchase"] = "";
    //            dr_Deductee["Amountof_Payment"] = Amount_of_payment;
    //            dr_Deductee["DateOnWhich_AMTPaid"] = objtbl_DeducteeDetail.DateOnWhich_AMTPaid;
    //            dr_Deductee["DateonWhich_TaxDeducted"] = objtbl_DeducteeDetail.DateonWhich_TaxDeducted;
    //            dr_Deductee["Dateof_Deposit"] ="";
    //            dr_Deductee["RateatWhich_TAXDeducted"] = objtbl_DeducteeDetail.RateatWhich_TAXDeducted;
    //            dr_Deductee["GrossingUP_Indicator"] = "";
    //            dr_Deductee["BookEntry_CashIndicator"] = Book_Entry;
    //            dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";
    //            dr_Deductee["Reason_For_NonDeduction"] = objtbl_DeducteeDetail.Reason_For_NonDeduction;
    //            dr_Deductee["Remarks1"] = "";
    //            dr_Deductee["Remarks2"] = "";
    //            dr_Deductee["Section_Code"] = Section_Code;
    //            dr_Deductee["Certificate_Number"] = Certificate_Number;
    //            dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = WhetherTDSRateofTDSIsITAct27;
    //            dr_Deductee["Nature_of_Remittance_27"] = Nature_of_Remittance_27;
    //            dr_Deductee["Unique_formno_15CA_27"] = Unique_formno_15CA_27;
    //            dr_Deductee["Country_to_which_remittance_is_made_27"] = Country_to_which_remittance_is_made_27;
    //            dr_Deductee["RecordHash"] = "";
    //            dr_Deductee["DeleteFlag"] = "";
    //            dr_Deductee["C1"] = "";
    //            dr_Deductee["C2"] = "";
    //            dr_Deductee["C3"] = "";
    //            dr_Deductee["C4"] = "";
    //            dr_Deductee["C5"] = "";
    //            dr_Deductee["C9"] = "";
    //            dr_Deductee["Y"] = "";
    //            dr_Deductee["Desicion"] = "";
    //            dr_Deductee["ID_Admin"] = IDAdmin;
    //            dt_Deductee.Rows.Add(dr_Deductee);

    //        }
    //        else if (FormNo == "Form27EQ")
    //        {
    //            objtbl_DeducteeDetail.ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
    //            objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k + 1]);
    //            objtbl_DeducteeDetail.Deductee_PartyCode = dt_DeducteeDetail.Rows[i][k + 2].ToString();
    //            objtbl_DeducteeDetail.EmployeePAN = dt_DeducteeDetail.Rows[i][k + 3].ToString();
    //            objtbl_DeducteeDetail.NameofEmployee_Party = dt_DeducteeDetail.Rows[i][k + 4].ToString();
    //            objtbl_DeducteeDetail.Total_ValuePurchase = dt_DeducteeDetail.Rows[i][k + 5].ToString();
    //            //Format Amount of Payment Field
    //            string Amount_of_payment = dt_DeducteeDetail.Rows[i][k + 6].ToString();
    //            //Amount_of_payment = string.Format("{0:f2}", Int32.Parse(Amount_of_payment));
    //            objtbl_DeducteeDetail.Amountof_Payment = Convert.ToDouble(Amount_of_payment);


    //            objtbl_DeducteeDetail.DateOnWhich_AMTPaid = dt_DeducteeDetail.Rows[i][k + 7].ToString();

    //            //Format Rate at which Tax Deducted Field
    //            string Rate_at_Which_Tax_Deducted = dt_DeducteeDetail.Rows[i][k + 8].ToString();
    //            Rate_at_Which_Tax_Deducted = string.Format("{0:f4}", Double.Parse(Rate_at_Which_Tax_Deducted));
    //            //Rate_at_Which_Tax_Deducted = string.Format("0:f4", Int32.Parse(Rate_at_Which_Tax_Deducted));
    //            objtbl_DeducteeDetail.RateatWhich_TAXDeducted = Rate_at_Which_Tax_Deducted.ToString();

    //            //Deposit Tax By Book Entry
    //            string Book_Entry = dt_DeducteeDetail.Rows[i][k + 9].ToString();

    //            if (Book_Entry == "Yes" || Book_Entry == "Y")
    //            {
    //                objtbl_DeducteeDetail.BookEntry_CashIndicator = "Y";
    //            }
    //            else if (Book_Entry == "No" || Book_Entry == "N")
    //            {
    //                objtbl_DeducteeDetail.BookEntry_CashIndicator = "N";
    //            }


    //            //Format Income Tax Field
    //            string Income_Tax = dt_DeducteeDetail.Rows[i][k + 10].ToString();
    //            // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
    //            objtbl_DeducteeDetail.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);
    //            Cash_Entry = Income_Tax;
    //            //Format Surcharge Field
    //            string Surcharge = dt_DeducteeDetail.Rows[i][k + 11].ToString();
    //            //Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
    //            objtbl_DeducteeDetail.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

    //            //Format Education_Cess Field
    //            string Education_Cess = dt_DeducteeDetail.Rows[i][k + 12].ToString();
    //            // Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
    //            objtbl_DeducteeDetail.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);

    //            //Format Total Tax Deposited Field
    //            string Total_Tax_Deposited = dt_DeducteeDetail.Rows[i][k + 13].ToString();
    //            //Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
    //            objtbl_DeducteeDetail.Total_TaxDeposited = Convert.ToDouble(Total_Tax_Deposited);


    //            objtbl_DeducteeDetail.Total_IncomeTAX_Deducted = objtbl_DeducteeDetail.Total_TaxDeposited;

    //            objtbl_DeducteeDetail.DateonWhich_TaxDeducted = dt_DeducteeDetail.Rows[i][k + 14].ToString();

    //            objtbl_DeducteeDetail.Reason_For_NonDeduction = dt_DeducteeDetail.Rows[i][k + 15].ToString();
    //            Section_Code = dt_DeducteeDetail.Rows[i][k + 16].ToString();
    //            Certificate_Number = dt_DeducteeDetail.Rows[i][k + 17].ToString();
    //            WhetherTDSRateofTDSIsITAct27 = dt_DeducteeDetail.Rows[i][k + 18].ToString();
    //            Nature_of_Remittance_27 = dt_DeducteeDetail.Rows[i][k + 19].ToString();
    //            Unique_formno_15CA_27 = dt_DeducteeDetail.Rows[i][k + 20].ToString();
    //            Country_to_which_remittance_is_made_27 = dt_DeducteeDetail.Rows[i][k + 21].ToString();
    //            objtbl_DeducteeDetail.Page_ID = "2";
    //            objtbl_DeducteeDetail.Page_SubModule_ID = "3";



    //            DataRow dr_Deductee = dt_Deductee.NewRow();
    //            dr_Deductee["DeducteeID"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["ID"] = Challan_ID;
    //            dr_Deductee["MasterID"] = Master_ID;
    //            dr_Deductee["Line_Number"] = 0;
    //            dr_Deductee["Record_Type"] = "DD";
    //            dr_Deductee["Batch_Number"] = "1";
    //            dr_Deductee["Challan_Detail_Rec_No"] = Challan_ID;
    //            dr_Deductee["DeducteeParty_Record_No"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["Mode"] = "O";
    //            dr_Deductee["Employee_SerialNo"] = "";
    //            dr_Deductee["LastEmployee_PartyPAN"] = "";
    //            dr_Deductee["Deductee_PartyCode"] = objtbl_DeducteeDetail.Deductee_PartyCode;
    //            dr_Deductee["EmployeePAN"] = objtbl_DeducteeDetail.EmployeePAN;
    //            dr_Deductee["Last_EmployeePartyPAN"] = "";
    //            dr_Deductee["PAN_RefNO"] = "";
    //            dr_Deductee["NameofEmployee_Party"] = objtbl_DeducteeDetail.NameofEmployee_Party;
    //            dr_Deductee["TDS_TCS_IncomeTAX"] = Income_Tax;
    //            dr_Deductee["TDS_TCS_Surcharge"] = Surcharge;
    //            dr_Deductee["TDS_TCS_Cess"] = Education_Cess;
    //            dr_Deductee["Total_IncomeTAX_Deducted"] = objtbl_DeducteeDetail.Total_IncomeTAX_Deducted;
    //            dr_Deductee["Last_Income_TaxDeducted"] = "";
    //            dr_Deductee["Total_TaxDeposited"] = Total_Tax_Deposited;
    //            dr_Deductee["LastTotal_TaxDeposited"] = "";
    //            dr_Deductee["Total_ValuePurchase"] = objtbl_DeducteeDetail.Total_ValuePurchase;
    //            dr_Deductee["Amountof_Payment"] = Amount_of_payment;
    //            dr_Deductee["DateOnWhich_AMTPaid"] = objtbl_DeducteeDetail.DateOnWhich_AMTPaid;
    //            dr_Deductee["DateonWhich_TaxDeducted"] = objtbl_DeducteeDetail.DateonWhich_TaxDeducted;
    //            dr_Deductee["Dateof_Deposit"] = "";
    //            dr_Deductee["RateatWhich_TAXDeducted"] = objtbl_DeducteeDetail.RateatWhich_TAXDeducted;
    //            dr_Deductee["GrossingUP_Indicator"] = "";
    //            dr_Deductee["BookEntry_CashIndicator"] = Book_Entry;
    //            dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";
    //            dr_Deductee["Reason_For_NonDeduction"] = objtbl_DeducteeDetail.Reason_For_NonDeduction;
    //            dr_Deductee["Remarks1"] = "";
    //            dr_Deductee["Remarks2"] = "";
    //            dr_Deductee["Section_Code"] = Section_Code;
    //            dr_Deductee["Certificate_Number"] = Certificate_Number;
    //            dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = WhetherTDSRateofTDSIsITAct27;
    //            dr_Deductee["Nature_of_Remittance_27"] = Nature_of_Remittance_27;
    //            dr_Deductee["Unique_formno_15CA_27"] = Unique_formno_15CA_27;
    //            dr_Deductee["Country_to_which_remittance_is_made_27"] = Country_to_which_remittance_is_made_27;
    //            dr_Deductee["RecordHash"] = "";
    //            dr_Deductee["DeleteFlag"] = "";
    //            dr_Deductee["C1"] = "";
    //            dr_Deductee["C2"] = "";
    //            dr_Deductee["C3"] = "";
    //            dr_Deductee["C4"] = "";
    //            dr_Deductee["C5"] = "";
    //            dr_Deductee["C9"] = "";
    //            dr_Deductee["Y"] = "";
    //            dr_Deductee["Desicion"] = "";
    //            dr_Deductee["ID_Admin"] = IDAdmin;
    //            dt_Deductee.Rows.Add(dr_Deductee);

    //        }
    //        objtbl_ChallanDetails.ID = Master_ID;
    //        objtbl_ChallanDetails.ChallanID = Challan_ID;

    //        int count_deductee = dt_Deductee.Select("ID = '" + Challan_ID.ToString().Trim() + "' ").Length;
    //        DataRow[] dr_Challan = dt_Challan.Select("ChallanID ='"+Challan_ID.ToString().Trim() +"'");
    //        dr_Challan[0]["Count_Of_deductee_PartyRecords"] = count_deductee.ToString();
    //        dt_Challan.AcceptChanges();
    //        int Total_TDS_TCS_IncomeTAX = 0;
    //        int Total_TDS_TCS_Surcharge = 0;
    //        int Total_TDS_TCS_Cess = 0;
    //        int Total_IncomeTAX_Deducted = 0;
    //        if (Cash_Entry !="0")
    //        {
    //            //Update the Total of Deductee Field in the Challan Records.
    //             Total_TDS_TCS_IncomeTAX = (from DataRow dr in dt_Deductee.AsEnumerable()
    //                                           where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
    //                                           select Convert.ToInt32(dr["TDS_TCS_IncomeTAX"])).Sum();


    //             Total_TDS_TCS_Surcharge = (from DataRow dr in dt_Deductee.AsEnumerable()
    //                                           where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
    //                                           select Convert.ToInt32(dr["TDS_TCS_Surcharge"])).Sum();

    //             Total_TDS_TCS_Cess = (from DataRow dr in dt_Deductee.AsEnumerable()
    //                                      where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
    //                                      select Convert.ToInt32(dr["TDS_TCS_Cess"])).Sum();

    //             Total_IncomeTAX_Deducted = (from DataRow dr in dt_Deductee.AsEnumerable()
    //                                            where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
    //                                            select Convert.ToInt32(dr["Total_IncomeTAX_Deducted"])).Sum();

    //            //Update Challan DataTable
    //            DataRow[] dr_Challan_Excel = dt_Challan.Select("ChallanID='" + Challan_ID + "'");
    //            dr_Challan_Excel[0]["Total_TAX_Deposite_Amount"] = Total_TDS_TCS_IncomeTAX.ToString();
    //            dr_Challan_Excel[0]["TDS_TCS_IncomeTAX"] = Total_TDS_TCS_IncomeTAX.ToString();
    //            dr_Challan_Excel[0]["TDS_TCS_Surcharge"] = Total_TDS_TCS_Surcharge;
    //            dr_Challan_Excel[0]["TDS_TCS_Cess"] = Total_TDS_TCS_Cess;
    //            dr_Challan_Excel[0]["Total_IncomeTAX_Deducted"] = Total_IncomeTAX_Deducted;
    //        }
    //        //else if (Cash_Entry == "0" && Total_IncomeTAX_Deducted==0)
    //        //{
    //        //    DataRow[] dr_Challan_Excel = dt_Challan.Select("ChallanID=" + Challan_ID + " and ID=" + Master_ID + "");
    //        //    dr_Challan_Excel[0]["Total_TAX_Deposite_Amount"] = "0.00";
    //        //    dr_Challan_Excel[0]["TDS_TCS_IncomeTAX"] = "0.00";
    //        //    dr_Challan_Excel[0]["TDS_TCS_Surcharge"] = "0.00";
    //        //    dr_Challan_Excel[0]["TDS_TCS_Cess"] = "0.00";
    //        //    dr_Challan_Excel[0]["Total_IncomeTAX_Deducted"] = "0.00";
    //        //}



    //        k = 0;
    //    }


    //    return dt_Deductee;
    //}
    public DataTable InsertDeducteeDetails_Excel(DataTable dt_DeducteeDetail, string FormNo)
    {

        //Code of saving Challan
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";
        //Create Parameters For Inserting Challan Deatils
        objtbl_DeducteeDetail.FormType = ViewState["FormType"].ToString();
        objtbl_DeducteeDetail.TAN = ViewState["TAN"].ToString();
        objtbl_DeducteeDetail.Quarter = ViewState["Quarter"].ToString();
        objtbl_DeducteeDetail.FinancialYear = ViewState["FY"].ToString();
        objtbl_DeducteeDetail.Regular_Correction = "Regular";
        objtbl_DeducteeDetail.Correction_Type = "";
        //Create Parameters For Inserting Challan Deatils for getting MasterID
        objtbl_ChallanDetails.FormType = ViewState["FormType"].ToString();
        objtbl_ChallanDetails.TAN = ViewState["TAN"].ToString();
        objtbl_ChallanDetails.TANNo = ViewState["TAN"].ToString();
        objtbl_ChallanDetails.Quarter = ViewState["Quarter"].ToString();
        objtbl_ChallanDetails.FinancialYear = ViewState["FY"].ToString();
        objtbl_ChallanDetails.Regular_Correction = "Regular";
        objtbl_ChallanDetails.Correction_Type = "";
        //Get ChallanID
        DataTable dt_Deductee = new DataTable();
        DataTable dt_Challan = new DataTable();
        dt_Challan = (DataTable)ViewState["ChallanTable"];
        dt_Challan.CaseSensitive = false;

        dt_Deductee = objFillTableFromExcel.Convert_DataTable("tbl_DeducteeDetail_Record", "\t");
        dt_Deductee.Clear();
        string Cash_Entry = string.Empty;
        int Master_ID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
        int IDAdmin = Convert.ToInt32(ViewState["IDAdmin"]);
        objtbl_DeducteeDetail.MasterID = Master_ID;
        int deducteecount = dt_DeducteeDetail.Rows.Count;
        int success = 0;
        int Challan_ID = 0;
        string Section_Code = string.Empty;
        string Certificate_Number = string.Empty;
        string WhetherTDSRateofTDSIsITAct27 = string.Empty;
        string Nature_of_Remittance_27 = string.Empty;
        string Unique_formno_15CA_27 = string.Empty;
        string Country_to_which_remittance_is_made_27 = string.Empty;

        foreach (DataRow rows in dt_DeducteeDetail.Rows)
        {
            if (rows.ItemArray[0].ToString() != "")
            {
                countdeducteeRecord = countdeducteeRecord + 1;
            }
        }

        for (int i = 0; i < countdeducteeRecord; i++)
        {
            int k = 0;
            Challan_ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
            if (FormNo == "Form24Q")
            {
                DataRow[] dr_Challan_Deductee = dt_Challan.Select("ChallanID='" + Challan_ID + "'");

                objtbl_DeducteeDetail.ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
                objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k + 1]);
                objtbl_DeducteeDetail.Deductee_PartyCode = "";
                objtbl_DeducteeDetail.EmployeePAN = dt_DeducteeDetail.Rows[i][k + 2].ToString();
                objtbl_DeducteeDetail.NameofEmployee_Party = dt_DeducteeDetail.Rows[i][k + 3].ToString();
                if (dt_DeducteeDetail.Rows[i][k + 4].ToString() != "")
                {
                    string DataType = dt_DeducteeDetail.Columns[4].DataType.ToString();
                    if (DataType != "System.String")
                    {
                        DateTime dt_On_Which_Amount_Paid = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 4]);
                        string Date_On_Which_Amount_Paid = dt_On_Which_Amount_Paid.ToString("dd/MM/yyyy");


                        Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
                        objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
                    }
                    else
                    {
                        string Date_Paid = dt_DeducteeDetail.Rows[i][k + 4].ToString();
                        string Date_On_Which_Amount_Paid = Date_Paid;


                        Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
                        objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
                    }
                }
                else
                {
                    objtbl_DeducteeDetail.DateOnWhich_AMTPaid = "";
                }

                if (dt_DeducteeDetail.Rows[i][k + 10].ToString() != "")
                {
                    string DataType = dt_DeducteeDetail.Columns[10].DataType.ToString();
                    if (DataType != "System.String")
                    {
                        DateTime dt_On_Which_Tax_Deducted = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 10]);
                        string Date_On_Which_Tax_Deducted = dt_On_Which_Tax_Deducted.ToString("dd/MM/yyyy");

                        Date_On_Which_Tax_Deducted = Date_On_Which_Tax_Deducted.Replace("/", "");
                        objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Tax_Deducted;
                    }
                    else
                    {
                        string Date_Deducted = dt_DeducteeDetail.Rows[i][k + 10].ToString();
                        string Date_On_Which_Amount_Deducted = Date_Deducted;


                        Date_On_Which_Amount_Deducted = Date_On_Which_Amount_Deducted.Replace("/", "");
                        objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Amount_Deducted;
                    }
                }

                objtbl_DeducteeDetail.Dateof_Deposit = dr_Challan_Deductee[0]["Date_Of_Bank_ChallanNo"].ToString();
                //Format Amount of Payment Field
                string Amount_of_payment = dt_DeducteeDetail.Rows[i][k + 5].ToString();
                // Amount_of_payment = string.Format("{0:f2}", Int32.Parse(Amount_of_payment));
                objtbl_DeducteeDetail.Amountof_Payment = Convert.ToDouble(Amount_of_payment);

                //Format Income Tax Field
                string Income_Tax = dt_DeducteeDetail.Rows[i][k + 6].ToString();
                // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
                objtbl_DeducteeDetail.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);

                //Format Surcharge Field
                string Surcharge = dt_DeducteeDetail.Rows[i][k + 7].ToString();
                //Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
                objtbl_DeducteeDetail.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

                //Format Education_Cess Field
                string Education_Cess = dt_DeducteeDetail.Rows[i][k + 8].ToString();
                //Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
                objtbl_DeducteeDetail.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);

                //Format Total Tax Deposited Field
                string Total_Tax_Deposited = dt_DeducteeDetail.Rows[i][k + 9].ToString();
                //Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
                objtbl_DeducteeDetail.Total_TaxDeposited = (Total_Tax_Deposited.ToString() == "") ? Convert.ToDouble(string.Format("0.00", Total_Tax_Deposited)) : Convert.ToDouble(Total_Tax_Deposited);


                objtbl_DeducteeDetail.Total_IncomeTAX_Deducted = objtbl_DeducteeDetail.Total_TaxDeposited;

                //objtbl_DeducteeDetail.DateonWhich_TaxDeducted = dt_DeducteeDetail.Rows[i][k + 10].ToString();
                string Book_Entry = dt_DeducteeDetail.Rows[i][k + 11].ToString();
                Cash_Entry = Income_Tax;
                objtbl_DeducteeDetail.BookEntry_CashIndicator = Book_Entry;


                objtbl_DeducteeDetail.Reason_For_NonDeduction = dt_DeducteeDetail.Rows[i][k + 12].ToString();
                Section_Code = dt_DeducteeDetail.Rows[i][k + 13].ToString();
                Certificate_Number = dt_DeducteeDetail.Rows[i][k + 14].ToString();
                WhetherTDSRateofTDSIsITAct27 = dt_DeducteeDetail.Rows[i][k + 15].ToString();
                Nature_of_Remittance_27 = dt_DeducteeDetail.Rows[i][k + 16].ToString();
                Unique_formno_15CA_27 = dt_DeducteeDetail.Rows[i][k + 17].ToString();
                Country_to_which_remittance_is_made_27 = dt_DeducteeDetail.Rows[i][k + 18].ToString();
                objtbl_DeducteeDetail.Deductee_PartyCode = "";
                //Format Rate at which Tax Deducted
                //string Rate = dt_DeducteeDetail.Rows[i][k + 9].ToString();
                //Rate = string.Format("{0:f4}", Int32.Parse(Rate));
                objtbl_DeducteeDetail.RateatWhich_TAXDeducted = "0.0000";
                objtbl_DeducteeDetail.Page_ID = "2";
                objtbl_DeducteeDetail.Page_SubModule_ID = "3";
                DataRow dr_Deductee = dt_Deductee.NewRow();
                dr_Deductee["DeducteeID"] = objtbl_DeducteeDetail.DeducteeID;
                dr_Deductee["ID"] = Challan_ID;
                dr_Deductee["MasterID"] = Master_ID;
                dr_Deductee["Line_Number"] = 0;
                dr_Deductee["Record_Type"] = "DD";
                dr_Deductee["Batch_Number"] = "1";
                dr_Deductee["Challan_Detail_Rec_No"] = Challan_ID;
                dr_Deductee["DeducteeParty_Record_No"] = objtbl_DeducteeDetail.DeducteeID;
                dr_Deductee["Mode"] = "O";
                dr_Deductee["Employee_SerialNo"] = Challan_ID;
                dr_Deductee["LastEmployee_PartyPAN"] = "";
                dr_Deductee["Deductee_PartyCode"] = objtbl_DeducteeDetail.Deductee_PartyCode;
                dr_Deductee["EmployeePAN"] = objtbl_DeducteeDetail.EmployeePAN;
                dr_Deductee["Last_EmployeePartyPAN"] = "";
                dr_Deductee["PAN_RefNO"] = "";
                dr_Deductee["NameofEmployee_Party"] = objtbl_DeducteeDetail.NameofEmployee_Party;
                dr_Deductee["TDS_TCS_IncomeTAX"] = Income_Tax;
                dr_Deductee["TDS_TCS_Surcharge"] = Surcharge;
                dr_Deductee["TDS_TCS_Cess"] = Education_Cess;
                dr_Deductee["Total_IncomeTAX_Deducted"] = objtbl_DeducteeDetail.Total_IncomeTAX_Deducted;
                dr_Deductee["Last_Income_TaxDeducted"] = "";
                dr_Deductee["Total_TaxDeposited"] = Total_Tax_Deposited;
                dr_Deductee["LastTotal_TaxDeposited"] = "";
                dr_Deductee["Total_ValuePurchase"] = "";
                dr_Deductee["Amountof_Payment"] = Amount_of_payment;
                dr_Deductee["DateOnWhich_AMTPaid"] = objtbl_DeducteeDetail.DateOnWhich_AMTPaid;
                dr_Deductee["DateonWhich_TaxDeducted"] = objtbl_DeducteeDetail.DateonWhich_TaxDeducted;
                dr_Deductee["Dateof_Deposit"] = objtbl_DeducteeDetail.Dateof_Deposit;
                dr_Deductee["RateatWhich_TAXDeducted"] = "";
                dr_Deductee["GrossingUP_Indicator"] = "";
                dr_Deductee["BookEntry_CashIndicator"] = Book_Entry;
                dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";
                dr_Deductee["Reason_For_NonDeduction"] = objtbl_DeducteeDetail.Reason_For_NonDeduction;
                dr_Deductee["Remarks1"] = "";
                dr_Deductee["Remarks2"] = "";
                dr_Deductee["Section_Code"] = Section_Code;
                dr_Deductee["Certificate_Number"] = Certificate_Number;
                dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = WhetherTDSRateofTDSIsITAct27;
                dr_Deductee["Nature_of_Remittance_27"] = Nature_of_Remittance_27;
                dr_Deductee["Unique_formno_15CA_27"] = Unique_formno_15CA_27;
                dr_Deductee["Country_to_which_remittance_is_made_27"] = Country_to_which_remittance_is_made_27;

                dr_Deductee["RecordHash"] = "";
                dr_Deductee["DeleteFlag"] = "";
                dr_Deductee["C1"] = "";
                dr_Deductee["C2"] = "";
                dr_Deductee["C3"] = "";
                dr_Deductee["C4"] = "";
                dr_Deductee["C5"] = "";
                dr_Deductee["C9"] = "";
                dr_Deductee["Y"] = "";
                dr_Deductee["Desicion"] = "";
                dr_Deductee["ID_Admin"] = IDAdmin;
                dt_Deductee.Rows.Add(dr_Deductee);




            }
            else if (FormNo == "Form26Q" || FormNo == "Form27Q")
            {
                objtbl_DeducteeDetail.ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
                objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k + 1]);
                objtbl_DeducteeDetail.Deductee_PartyCode = dt_DeducteeDetail.Rows[i][k + 2].ToString();
                objtbl_DeducteeDetail.EmployeePAN = dt_DeducteeDetail.Rows[i][k + 3].ToString();
                objtbl_DeducteeDetail.PAN_RefNO = dt_DeducteeDetail.Rows[i][k + 4].ToString();
                objtbl_DeducteeDetail.NameofEmployee_Party = dt_DeducteeDetail.Rows[i][k + 5].ToString();
                //Format Amount of Payment Field
                string Amount_of_payment = dt_DeducteeDetail.Rows[i][k + 6].ToString();
                // Amount_of_payment = string.Format("{0:f2}", Int32.Parse(Amount_of_payment));
                objtbl_DeducteeDetail.Amountof_Payment = Convert.ToDouble(Amount_of_payment);
                if (dt_DeducteeDetail.Rows[i][k + 7].ToString() != "")
                {
                    string DataType = dt_DeducteeDetail.Columns[7].DataType.ToString();
                    if (DataType != "System.String")
                    {
                        DateTime dt_On_Which_Amount_Paid = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 7]);
                        string Date_On_Which_Amount_Paid = dt_On_Which_Amount_Paid.ToString("dd/MM/yyyy");


                        Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
                        objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
                    }
                    else
                    {
                        string Date_Paid = dt_DeducteeDetail.Rows[i][k + 7].ToString();
                        string Date_On_Which_Amount_Paid = Date_Paid;


                        Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
                        objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
                    }
                }
                else
                {
                    objtbl_DeducteeDetail.DateOnWhich_AMTPaid = "";
                }

                if (dt_DeducteeDetail.Rows[i][k + 14].ToString() != "")
                {
                    string DataType = dt_DeducteeDetail.Columns[14].DataType.ToString();
                    if (DataType != "System.String")
                    {
                        DateTime dt_On_Which_Tax_Deducted = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 14]);
                        string Date_On_Which_Tax_Deducted = dt_On_Which_Tax_Deducted.ToString("dd/MM/yyyy");

                        Date_On_Which_Tax_Deducted = Date_On_Which_Tax_Deducted.Replace("/", "");
                        objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Tax_Deducted;
                    }
                    else
                    {
                        string Date_Deducted = dt_DeducteeDetail.Rows[i][k + 14].ToString();
                        string Date_On_Which_Amount_Deducted = Date_Deducted;


                        Date_On_Which_Amount_Deducted = Date_On_Which_Amount_Deducted.Replace("/", "");
                        objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Amount_Deducted;
                    }
                }

                //Format Rate at which Tax Deducted Field
                string Rate_at_Which_Tax_Deducted = dt_DeducteeDetail.Rows[i][k + 8].ToString();
                Rate_at_Which_Tax_Deducted = string.Format("{0:f4}", Double.Parse(Rate_at_Which_Tax_Deducted));

                //objtbl_DeducteeDetail.RateatWhich_TAXDeducted = Rate_at_Which_Tax_Deducted.ToString()+".0000";
                objtbl_DeducteeDetail.RateatWhich_TAXDeducted = Rate_at_Which_Tax_Deducted.ToString();

                //Deposit Tax By Book Entry
                objtbl_DeducteeDetail.BookEntry_CashIndicator = dt_DeducteeDetail.Rows[i][k + 9].ToString();
                string Book_Entry = objtbl_DeducteeDetail.BookEntry_CashIndicator.ToString();

                //Format Income Tax Field
                string Income_Tax = dt_DeducteeDetail.Rows[i][k + 10].ToString();
                Cash_Entry = Income_Tax;
                // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
                objtbl_DeducteeDetail.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);

                //Format Surcharge Field
                string Surcharge = dt_DeducteeDetail.Rows[i][k + 11].ToString();
                // Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
                objtbl_DeducteeDetail.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

                //Format Education_Cess Field
                string Education_Cess = dt_DeducteeDetail.Rows[i][k + 12].ToString();
                //  Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
                objtbl_DeducteeDetail.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);

                //Format Total Tax Deposited Field
                string Total_Tax_Deposited = dt_DeducteeDetail.Rows[i][k + 13].ToString();
                // Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
                objtbl_DeducteeDetail.Total_TaxDeposited = Convert.ToDouble(Total_Tax_Deposited);


                objtbl_DeducteeDetail.Total_IncomeTAX_Deducted = objtbl_DeducteeDetail.Total_TaxDeposited;



                objtbl_DeducteeDetail.Reason_For_NonDeduction = dt_DeducteeDetail.Rows[i][k + 15].ToString();
                Section_Code = dt_DeducteeDetail.Rows[i][k + 16].ToString();
                Certificate_Number = dt_DeducteeDetail.Rows[i][k + 17].ToString();
                WhetherTDSRateofTDSIsITAct27 = dt_DeducteeDetail.Rows[i][k + 18].ToString();
                Nature_of_Remittance_27 = dt_DeducteeDetail.Rows[i][k + 19].ToString();
                Unique_formno_15CA_27 = dt_DeducteeDetail.Rows[i][k + 20].ToString();
                Country_to_which_remittance_is_made_27 = dt_DeducteeDetail.Rows[i][k + 21].ToString();
                objtbl_DeducteeDetail.Page_ID = "2";
                objtbl_DeducteeDetail.Page_SubModule_ID = "3";


                DataRow dr_Deductee = dt_Deductee.NewRow();
                dr_Deductee["DeducteeID"] = objtbl_DeducteeDetail.DeducteeID;
                dr_Deductee["ID"] = Challan_ID;
                dr_Deductee["MasterID"] = Master_ID;
                dr_Deductee["Line_Number"] = 0;
                dr_Deductee["Record_Type"] = "DD";
                dr_Deductee["Batch_Number"] = "1";
                dr_Deductee["Challan_Detail_Rec_No"] = Challan_ID;
                dr_Deductee["DeducteeParty_Record_No"] = objtbl_DeducteeDetail.DeducteeID;
                dr_Deductee["Mode"] = "O";
                dr_Deductee["Employee_SerialNo"] = "";
                dr_Deductee["LastEmployee_PartyPAN"] = "";
                dr_Deductee["Deductee_PartyCode"] = objtbl_DeducteeDetail.Deductee_PartyCode;
                dr_Deductee["EmployeePAN"] = objtbl_DeducteeDetail.EmployeePAN;
                dr_Deductee["Last_EmployeePartyPAN"] = "";
                string PAN_REFNO = objtbl_DeducteeDetail.PAN_RefNO;
                if (PAN_REFNO != "")
                {
                    PAN_REFNO = String.Format("{0:0000000000}", Int32.Parse(PAN_REFNO));
                }
                dr_Deductee["PAN_RefNO"] = PAN_REFNO;
                dr_Deductee["NameofEmployee_Party"] = objtbl_DeducteeDetail.NameofEmployee_Party;
                dr_Deductee["TDS_TCS_IncomeTAX"] = Income_Tax;
                dr_Deductee["TDS_TCS_Surcharge"] = Surcharge;
                dr_Deductee["TDS_TCS_Cess"] = Education_Cess;
                dr_Deductee["Total_IncomeTAX_Deducted"] = objtbl_DeducteeDetail.Total_IncomeTAX_Deducted;
                dr_Deductee["Last_Income_TaxDeducted"] = "";
                dr_Deductee["Total_TaxDeposited"] = Total_Tax_Deposited;
                dr_Deductee["LastTotal_TaxDeposited"] = "";
                dr_Deductee["Total_ValuePurchase"] = "";
                dr_Deductee["Amountof_Payment"] = Amount_of_payment;
                dr_Deductee["DateOnWhich_AMTPaid"] = objtbl_DeducteeDetail.DateOnWhich_AMTPaid;
                dr_Deductee["DateonWhich_TaxDeducted"] = objtbl_DeducteeDetail.DateonWhich_TaxDeducted;
                dr_Deductee["Dateof_Deposit"] = "";
                dr_Deductee["RateatWhich_TAXDeducted"] = objtbl_DeducteeDetail.RateatWhich_TAXDeducted;
                dr_Deductee["GrossingUP_Indicator"] = "";
                dr_Deductee["BookEntry_CashIndicator"] = Book_Entry;
                dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";
                dr_Deductee["Reason_For_NonDeduction"] = objtbl_DeducteeDetail.Reason_For_NonDeduction;
                dr_Deductee["Remarks1"] = "";
                dr_Deductee["Remarks2"] = "";
                dr_Deductee["Section_Code"] = Section_Code;
                dr_Deductee["Certificate_Number"] = Certificate_Number;
                dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = WhetherTDSRateofTDSIsITAct27;
                dr_Deductee["Nature_of_Remittance_27"] = Nature_of_Remittance_27;
                dr_Deductee["Unique_formno_15CA_27"] = Unique_formno_15CA_27;
                dr_Deductee["Country_to_which_remittance_is_made_27"] = Country_to_which_remittance_is_made_27;
                dr_Deductee["RecordHash"] = "";
                dr_Deductee["DeleteFlag"] = "";
                dr_Deductee["C1"] = "";
                dr_Deductee["C2"] = "";
                dr_Deductee["C3"] = "";
                dr_Deductee["C4"] = "";
                dr_Deductee["C5"] = "";
                dr_Deductee["C9"] = "";
                dr_Deductee["Y"] = "";
                dr_Deductee["Desicion"] = "";
                dr_Deductee["ID_Admin"] = IDAdmin;
                dt_Deductee.Rows.Add(dr_Deductee);

            }
            else if (FormNo == "Form27EQ")
            {
                objtbl_DeducteeDetail.ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
                objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k + 1]);
                objtbl_DeducteeDetail.Deductee_PartyCode = dt_DeducteeDetail.Rows[i][k + 2].ToString();
                objtbl_DeducteeDetail.EmployeePAN = dt_DeducteeDetail.Rows[i][k + 3].ToString();
                objtbl_DeducteeDetail.PAN_RefNO = dt_DeducteeDetail.Rows[i][k + 4].ToString();
                objtbl_DeducteeDetail.NameofEmployee_Party = dt_DeducteeDetail.Rows[i][k + 5].ToString();
                objtbl_DeducteeDetail.Total_ValuePurchase = dt_DeducteeDetail.Rows[i][k + 6].ToString();
                //Format Amount of Payment Field
                string Amount_of_payment = dt_DeducteeDetail.Rows[i][k + 7].ToString();
                //Amount_of_payment = string.Format("{0:f2}", Int32.Parse(Amount_of_payment));
                objtbl_DeducteeDetail.Amountof_Payment = Convert.ToDouble(Amount_of_payment);


                objtbl_DeducteeDetail.DateOnWhich_AMTPaid = dt_DeducteeDetail.Rows[i][k + 8].ToString();

                //Format Rate at which Tax Deducted Field
                string Rate_at_Which_Tax_Deducted = dt_DeducteeDetail.Rows[i][k + 9].ToString();
                Rate_at_Which_Tax_Deducted = string.Format("{0:f4}", Double.Parse(Rate_at_Which_Tax_Deducted));
                //Rate_at_Which_Tax_Deducted = string.Format("0:f4", Int32.Parse(Rate_at_Which_Tax_Deducted));
                objtbl_DeducteeDetail.RateatWhich_TAXDeducted = Rate_at_Which_Tax_Deducted.ToString();

                //Deposit Tax By Book Entry
                string Book_Entry = dt_DeducteeDetail.Rows[i][k + 10].ToString();

                if (Book_Entry == "Yes" || Book_Entry == "Y")
                {
                    objtbl_DeducteeDetail.BookEntry_CashIndicator = "Y";
                }
                else if (Book_Entry == "No" || Book_Entry == "N")
                {
                    objtbl_DeducteeDetail.BookEntry_CashIndicator = "N";
                }


                //Format Income Tax Field
                string Income_Tax = dt_DeducteeDetail.Rows[i][k + 11].ToString();
                // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
                objtbl_DeducteeDetail.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);
                Cash_Entry = Income_Tax;
                //Format Surcharge Field
                string Surcharge = dt_DeducteeDetail.Rows[i][k + 12].ToString();
                //Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
                objtbl_DeducteeDetail.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

                //Format Education_Cess Field
                string Education_Cess = dt_DeducteeDetail.Rows[i][k + 13].ToString();
                // Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
                objtbl_DeducteeDetail.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);

                //Format Total Tax Deposited Field
                string Total_Tax_Deposited = dt_DeducteeDetail.Rows[i][k + 14].ToString();
                //Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
                objtbl_DeducteeDetail.Total_TaxDeposited = Convert.ToDouble(Total_Tax_Deposited);


                objtbl_DeducteeDetail.Total_IncomeTAX_Deducted = objtbl_DeducteeDetail.Total_TaxDeposited;

                objtbl_DeducteeDetail.DateonWhich_TaxDeducted = dt_DeducteeDetail.Rows[i][k + 15].ToString();

                objtbl_DeducteeDetail.Reason_For_NonDeduction = dt_DeducteeDetail.Rows[i][k + 16].ToString();
                Section_Code = dt_DeducteeDetail.Rows[i][k + 17].ToString();
                Certificate_Number = dt_DeducteeDetail.Rows[i][k + 18].ToString();
                WhetherTDSRateofTDSIsITAct27 = dt_DeducteeDetail.Rows[i][k + 19].ToString();
                Nature_of_Remittance_27 = dt_DeducteeDetail.Rows[i][k + 20].ToString();
                Unique_formno_15CA_27 = dt_DeducteeDetail.Rows[i][k + 21].ToString();
                Country_to_which_remittance_is_made_27 = dt_DeducteeDetail.Rows[i][k + 22].ToString();
                objtbl_DeducteeDetail.Page_ID = "2";
                objtbl_DeducteeDetail.Page_SubModule_ID = "3";



                DataRow dr_Deductee = dt_Deductee.NewRow();
                dr_Deductee["DeducteeID"] = objtbl_DeducteeDetail.DeducteeID;
                dr_Deductee["ID"] = Challan_ID;
                dr_Deductee["MasterID"] = Master_ID;
                dr_Deductee["Line_Number"] = 0;
                dr_Deductee["Record_Type"] = "DD";
                dr_Deductee["Batch_Number"] = "1";
                dr_Deductee["Challan_Detail_Rec_No"] = Challan_ID;
                dr_Deductee["DeducteeParty_Record_No"] = objtbl_DeducteeDetail.DeducteeID;
                dr_Deductee["Mode"] = "O";
                dr_Deductee["Employee_SerialNo"] = "";
                dr_Deductee["LastEmployee_PartyPAN"] = "";
                dr_Deductee["Deductee_PartyCode"] = objtbl_DeducteeDetail.Deductee_PartyCode;
                dr_Deductee["EmployeePAN"] = objtbl_DeducteeDetail.EmployeePAN;
                dr_Deductee["Last_EmployeePartyPAN"] = "";
                string PAN_REFNO = objtbl_DeducteeDetail.PAN_RefNO;
                if (PAN_REFNO != "")
                {
                    PAN_REFNO = String.Format("{0:0000000000}", Int32.Parse(PAN_REFNO));
                }
                dr_Deductee["PAN_RefNO"] = PAN_REFNO;
                dr_Deductee["NameofEmployee_Party"] = objtbl_DeducteeDetail.NameofEmployee_Party;
                dr_Deductee["TDS_TCS_IncomeTAX"] = Income_Tax;
                dr_Deductee["TDS_TCS_Surcharge"] = Surcharge;
                dr_Deductee["TDS_TCS_Cess"] = Education_Cess;
                dr_Deductee["Total_IncomeTAX_Deducted"] = objtbl_DeducteeDetail.Total_IncomeTAX_Deducted;
                dr_Deductee["Last_Income_TaxDeducted"] = "";
                dr_Deductee["Total_TaxDeposited"] = Total_Tax_Deposited;
                dr_Deductee["LastTotal_TaxDeposited"] = "";
                dr_Deductee["Total_ValuePurchase"] = objtbl_DeducteeDetail.Total_ValuePurchase;
                dr_Deductee["Amountof_Payment"] = Amount_of_payment;
                dr_Deductee["DateOnWhich_AMTPaid"] = objtbl_DeducteeDetail.DateOnWhich_AMTPaid;
                dr_Deductee["DateonWhich_TaxDeducted"] = objtbl_DeducteeDetail.DateonWhich_TaxDeducted;
                dr_Deductee["Dateof_Deposit"] = "";
                dr_Deductee["RateatWhich_TAXDeducted"] = objtbl_DeducteeDetail.RateatWhich_TAXDeducted;
                dr_Deductee["GrossingUP_Indicator"] = "";
                dr_Deductee["BookEntry_CashIndicator"] = Book_Entry;
                dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";
                dr_Deductee["Reason_For_NonDeduction"] = objtbl_DeducteeDetail.Reason_For_NonDeduction;
                dr_Deductee["Remarks1"] = "";
                dr_Deductee["Remarks2"] = "";
                dr_Deductee["Section_Code"] = Section_Code;
                dr_Deductee["Certificate_Number"] = Certificate_Number;
                dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = WhetherTDSRateofTDSIsITAct27;
                dr_Deductee["Nature_of_Remittance_27"] = Nature_of_Remittance_27;
                dr_Deductee["Unique_formno_15CA_27"] = Unique_formno_15CA_27;
                dr_Deductee["Country_to_which_remittance_is_made_27"] = Country_to_which_remittance_is_made_27;
                dr_Deductee["RecordHash"] = "";
                dr_Deductee["DeleteFlag"] = "";
                dr_Deductee["C1"] = "";
                dr_Deductee["C2"] = "";
                dr_Deductee["C3"] = "";
                dr_Deductee["C4"] = "";
                dr_Deductee["C5"] = "";
                dr_Deductee["C9"] = "";
                dr_Deductee["Y"] = "";
                dr_Deductee["Desicion"] = "";
                dr_Deductee["ID_Admin"] = IDAdmin;
                dt_Deductee.Rows.Add(dr_Deductee);

            }
            objtbl_ChallanDetails.ID = Master_ID;
            objtbl_ChallanDetails.ChallanID = Challan_ID;

            int count_deductee = dt_Deductee.Select("ID = '" + Challan_ID.ToString().Trim() + "' ").Length;
            DataRow[] dr_Challan = dt_Challan.Select("ChallanID ='" + Challan_ID.ToString().Trim() + "'");
            dr_Challan[0]["Count_Of_deductee_PartyRecords"] = count_deductee.ToString();
            dt_Challan.AcceptChanges();
            int Total_TDS_TCS_IncomeTAX = 0;
            int Total_TDS_TCS_Surcharge = 0;
            int Total_TDS_TCS_Cess = 0;
            int Total_IncomeTAX_Deducted = 0;
            if (Cash_Entry != "0")
            {
                //Update the Total of Deductee Field in the Challan Records.
                Total_TDS_TCS_IncomeTAX = (from DataRow dr in dt_Deductee.AsEnumerable()
                                           where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
                                           select Convert.ToInt32(dr["TDS_TCS_IncomeTAX"])).Sum();


                Total_TDS_TCS_Surcharge = (from DataRow dr in dt_Deductee.AsEnumerable()
                                           where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
                                           select Convert.ToInt32(dr["TDS_TCS_Surcharge"])).Sum();

                Total_TDS_TCS_Cess = (from DataRow dr in dt_Deductee.AsEnumerable()
                                      where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
                                      select Convert.ToInt32(dr["TDS_TCS_Cess"])).Sum();

                Total_IncomeTAX_Deducted = (from DataRow dr in dt_Deductee.AsEnumerable()
                                            where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
                                            select Convert.ToInt32(dr["Total_IncomeTAX_Deducted"])).Sum();

                //Update Challan DataTable
                DataRow[] dr_Challan_Excel = dt_Challan.Select("ChallanID='" + Challan_ID + "'");
                dr_Challan_Excel[0]["Total_TAX_Deposite_Amount"] = Total_TDS_TCS_IncomeTAX.ToString();
                dr_Challan_Excel[0]["TDS_TCS_IncomeTAX"] = Total_TDS_TCS_IncomeTAX.ToString();
                dr_Challan_Excel[0]["TDS_TCS_Surcharge"] = Total_TDS_TCS_Surcharge;
                dr_Challan_Excel[0]["TDS_TCS_Cess"] = Total_TDS_TCS_Cess;
                dr_Challan_Excel[0]["Total_IncomeTAX_Deducted"] = Total_IncomeTAX_Deducted;
            }
            //else if (Cash_Entry == "0" && Total_IncomeTAX_Deducted==0)
            //{
            //    DataRow[] dr_Challan_Excel = dt_Challan.Select("ChallanID=" + Challan_ID + " and ID=" + Master_ID + "");
            //    dr_Challan_Excel[0]["Total_TAX_Deposite_Amount"] = "0.00";
            //    dr_Challan_Excel[0]["TDS_TCS_IncomeTAX"] = "0.00";
            //    dr_Challan_Excel[0]["TDS_TCS_Surcharge"] = "0.00";
            //    dr_Challan_Excel[0]["TDS_TCS_Cess"] = "0.00";
            //    dr_Challan_Excel[0]["Total_IncomeTAX_Deducted"] = "0.00";
            //}



            k = 0;
        }


        return dt_Deductee;
    }
    //public DataTable InsertDeducteeDetails_Excel(DataTable dt_DeducteeDetail, string FormNo)
    //{

    //    //Code of saving Challan
    //    DBtbl_Module.ArrayIndex = 0;
    //    DBtbl_Module.count = 0;
    //    DBtbl_Module.lst_Field = new Dictionary<string, int>();
    //    DBtbl_Module.lst_Query = new List<string>();
    //    DBtbl_Module.lst_update = new List<string[]>();
    //    DBtbl_Module.Previous_RecordNo = 0;
    //    DBtbl_Module.Previous_Table = "";
    //    //Create Parameters For Inserting Challan Deatils
    //    objtbl_DeducteeDetail.FormType = ViewState["FormType"].ToString();
    //    objtbl_DeducteeDetail.TAN = ViewState["TAN"].ToString();
    //    objtbl_DeducteeDetail.Quarter = ViewState["Quarter"].ToString();
    //    objtbl_DeducteeDetail.FinancialYear = ViewState["FY"].ToString();
    //    objtbl_DeducteeDetail.Regular_Correction = "Regular";
    //    objtbl_DeducteeDetail.Correction_Type = "";
    //    //Create Parameters For Inserting Challan Deatils for getting MasterID
    //    objtbl_ChallanDetails.FormType = ViewState["FormType"].ToString();
    //    objtbl_ChallanDetails.TAN = ViewState["TAN"].ToString();
    //    objtbl_ChallanDetails.TANNo = ViewState["TAN"].ToString();
    //    objtbl_ChallanDetails.Quarter = ViewState["Quarter"].ToString();
    //    objtbl_ChallanDetails.FinancialYear = ViewState["FY"].ToString();
    //    objtbl_ChallanDetails.Regular_Correction = "Regular";
    //    objtbl_ChallanDetails.Correction_Type = "";
    //    //Get ChallanID
    //    DataTable dt_Deductee = new DataTable();
    //    DataTable dt_Challan = new DataTable();
    //    dt_Challan = (DataTable)ViewState["ChallanTable"];
    //    dt_Challan.CaseSensitive = false;

    //    dt_Deductee = objFillTableFromExcel.Convert_DataTable("tbl_DeducteeDetail_Record", "\t");
    //    dt_Deductee.Clear();
    //    string Cash_Entry = string.Empty;
    //    int Master_ID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
    //    int IDAdmin = Convert.ToInt32(ViewState["IDAdmin"]);
    //    objtbl_DeducteeDetail.MasterID = Master_ID;
    //    int deducteecount = dt_DeducteeDetail.Rows.Count;
    //    int success = 0;
    //    int Challan_ID = 0;
    //    string Section_Code = string.Empty;
    //    string Certificate_Number = string.Empty;
    //    string WhetherTDSRateofTDSIsITAct27 = string.Empty;
    //    string Nature_of_Remittance_27 = string.Empty;
    //    string Unique_formno_15CA_27 = string.Empty;
    //    string Country_to_which_remittance_is_made_27 = string.Empty;

    //    foreach (DataRow rows in dt_DeducteeDetail.Rows)
    //    {
    //        if (rows.ItemArray[0].ToString() != "")
    //        {
    //            countdeducteeRecord = countdeducteeRecord + 1;
    //        }
    //    }

    //    for (int i = 0; i < countdeducteeRecord; i++)
    //    {
    //        int k = 0;
    //        Challan_ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
    //        if (FormNo == "Form24Q")
    //        {
    //            DataRow[] dr_Challan_Deductee = dt_Challan.Select("ChallanID='"+Challan_ID+"'");

    //            objtbl_DeducteeDetail.ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
    //            objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k + 1]);
    //            objtbl_DeducteeDetail.Deductee_PartyCode = "";
    //            objtbl_DeducteeDetail.EmployeePAN = dt_DeducteeDetail.Rows[i][k + 2].ToString();
    //            objtbl_DeducteeDetail.NameofEmployee_Party = dt_DeducteeDetail.Rows[i][k + 3].ToString();
    //            if (dt_DeducteeDetail.Rows[i][k + 4].ToString() != "")
    //            {
    //                string DataType = dt_DeducteeDetail.Columns[4].DataType.ToString();
    //                if (DataType != "System.String")
    //                {
    //                    DateTime dt_On_Which_Amount_Paid = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 4]);
    //                    string Date_On_Which_Amount_Paid = dt_On_Which_Amount_Paid.ToString("dd/MM/yyyy");


    //                    Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
    //                }
    //                else
    //                {
    //                    string Date_Paid = dt_DeducteeDetail.Rows[i][k + 4].ToString();
    //                    string Date_On_Which_Amount_Paid = Date_Paid;


    //                    Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
    //                }
    //            }
    //            else
    //            {
    //                objtbl_DeducteeDetail.DateOnWhich_AMTPaid = "";
    //            }

    //            if (dt_DeducteeDetail.Rows[i][k + 10].ToString() != "")
    //            {
    //                string DataType = dt_DeducteeDetail.Columns[10].DataType.ToString();
    //                if (DataType != "System.String")
    //                {
    //                    DateTime dt_On_Which_Tax_Deducted = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 10]);
    //                    string Date_On_Which_Tax_Deducted = dt_On_Which_Tax_Deducted.ToString("dd/MM/yyyy");

    //                    Date_On_Which_Tax_Deducted = Date_On_Which_Tax_Deducted.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Tax_Deducted;
    //                }
    //                else
    //                {
    //                    string Date_Deducted = dt_DeducteeDetail.Rows[i][k + 10].ToString();
    //                    string Date_On_Which_Amount_Deducted = Date_Deducted;


    //                    Date_On_Which_Amount_Deducted = Date_On_Which_Amount_Deducted.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Amount_Deducted;
    //                }
    //            }

    //            objtbl_DeducteeDetail.Dateof_Deposit = dr_Challan_Deductee[0]["Date_Of_Bank_ChallanNo"].ToString();
    //            //Format Amount of Payment Field
    //            string Amount_of_payment = dt_DeducteeDetail.Rows[i][k + 5].ToString();
    //            // Amount_of_payment = string.Format("{0:f2}", Int32.Parse(Amount_of_payment));
    //            objtbl_DeducteeDetail.Amountof_Payment = Convert.ToDouble(Amount_of_payment);

    //            //Format Income Tax Field
    //            string Income_Tax = dt_DeducteeDetail.Rows[i][k + 6].ToString();
    //            // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
    //            objtbl_DeducteeDetail.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);

    //            //Format Surcharge Field
    //            string Surcharge = dt_DeducteeDetail.Rows[i][k + 7].ToString();
    //            //Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
    //            objtbl_DeducteeDetail.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

    //            //Format Education_Cess Field
    //            string Education_Cess = dt_DeducteeDetail.Rows[i][k + 8].ToString();
    //            //Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
    //            objtbl_DeducteeDetail.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);

    //            //Format Total Tax Deposited Field
    //            string Total_Tax_Deposited = dt_DeducteeDetail.Rows[i][k + 9].ToString();
    //            //Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
    //            objtbl_DeducteeDetail.Total_TaxDeposited = Convert.ToDouble(Total_Tax_Deposited);


    //            objtbl_DeducteeDetail.Total_IncomeTAX_Deducted = objtbl_DeducteeDetail.Total_TaxDeposited;

    //            //objtbl_DeducteeDetail.DateonWhich_TaxDeducted = dt_DeducteeDetail.Rows[i][k + 10].ToString();
    //            string Book_Entry = dt_DeducteeDetail.Rows[i][k + 11].ToString();
    //            Cash_Entry = Income_Tax;
    //            objtbl_DeducteeDetail.BookEntry_CashIndicator = Book_Entry;


    //            objtbl_DeducteeDetail.Reason_For_NonDeduction = dt_DeducteeDetail.Rows[i][k + 12].ToString();
    //            Section_Code = dt_DeducteeDetail.Rows[i][k + 13].ToString();
    //            Certificate_Number = dt_DeducteeDetail.Rows[i][k + 14].ToString();
    //            WhetherTDSRateofTDSIsITAct27 = dt_DeducteeDetail.Rows[i][k + 15].ToString();
    //            Nature_of_Remittance_27 = dt_DeducteeDetail.Rows[i][k + 16].ToString();
    //            Unique_formno_15CA_27 = dt_DeducteeDetail.Rows[i][k + 17].ToString();
    //            Country_to_which_remittance_is_made_27 = dt_DeducteeDetail.Rows[i][k + 18].ToString();
    //            objtbl_DeducteeDetail.Deductee_PartyCode = "";
    //            //Format Rate at which Tax Deducted
    //            //string Rate = dt_DeducteeDetail.Rows[i][k + 9].ToString();
    //            //Rate = string.Format("{0:f4}", Int32.Parse(Rate));
    //            objtbl_DeducteeDetail.RateatWhich_TAXDeducted = "0.0000";
    //            objtbl_DeducteeDetail.Page_ID = "2";
    //            objtbl_DeducteeDetail.Page_SubModule_ID = "3";
    //            DataRow dr_Deductee = dt_Deductee.NewRow();
    //            dr_Deductee["DeducteeID"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["ID"] = Challan_ID;
    //            dr_Deductee["MasterID"] = Master_ID;
    //            dr_Deductee["Line_Number"] = 0;
    //            dr_Deductee["Record_Type"] = "DD";
    //            dr_Deductee["Batch_Number"] = "1";
    //            dr_Deductee["Challan_Detail_Rec_No"] = Challan_ID;
    //            dr_Deductee["DeducteeParty_Record_No"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["Mode"] = "O";
    //            dr_Deductee["Employee_SerialNo"] = Challan_ID;
    //            dr_Deductee["LastEmployee_PartyPAN"] = "";
    //            dr_Deductee["Deductee_PartyCode"] = objtbl_DeducteeDetail.Deductee_PartyCode;
    //            dr_Deductee["EmployeePAN"] = objtbl_DeducteeDetail.EmployeePAN;
    //            dr_Deductee["Last_EmployeePartyPAN"] = "";
    //            dr_Deductee["PAN_RefNO"] = "";
    //            dr_Deductee["NameofEmployee_Party"] = objtbl_DeducteeDetail.NameofEmployee_Party;
    //            dr_Deductee["TDS_TCS_IncomeTAX"] = Income_Tax;
    //            dr_Deductee["TDS_TCS_Surcharge"] = Surcharge;
    //            dr_Deductee["TDS_TCS_Cess"] = Education_Cess;
    //            dr_Deductee["Total_IncomeTAX_Deducted"] = objtbl_DeducteeDetail.Total_IncomeTAX_Deducted;
    //            dr_Deductee["Last_Income_TaxDeducted"] = "";
    //            dr_Deductee["Total_TaxDeposited"] = Total_Tax_Deposited;
    //            dr_Deductee["LastTotal_TaxDeposited"] = "";
    //            dr_Deductee["Total_ValuePurchase"] = "";
    //            dr_Deductee["Amountof_Payment"] = Amount_of_payment;
    //            dr_Deductee["DateOnWhich_AMTPaid"] = objtbl_DeducteeDetail.DateOnWhich_AMTPaid;
    //            dr_Deductee["DateonWhich_TaxDeducted"] = objtbl_DeducteeDetail.DateonWhich_TaxDeducted;
    //            dr_Deductee["Dateof_Deposit"] = objtbl_DeducteeDetail.Dateof_Deposit;
    //            dr_Deductee["RateatWhich_TAXDeducted"] = "";
    //            dr_Deductee["GrossingUP_Indicator"] = "";
    //            dr_Deductee["BookEntry_CashIndicator"] = Book_Entry;
    //            dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";
    //            dr_Deductee["Reason_For_NonDeduction"] = objtbl_DeducteeDetail.Reason_For_NonDeduction;
    //            dr_Deductee["Remarks1"] = "";
    //            dr_Deductee["Remarks2"] = "";
    //            dr_Deductee["Section_Code"] = Section_Code;
    //            dr_Deductee["Certificate_Number"] = Certificate_Number;
    //            dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = WhetherTDSRateofTDSIsITAct27;
    //            dr_Deductee["Nature_of_Remittance_27"] = Nature_of_Remittance_27;
    //            dr_Deductee["Unique_formno_15CA_27"] = Unique_formno_15CA_27;
    //            dr_Deductee["Country_to_which_remittance_is_made_27"] = Country_to_which_remittance_is_made_27;

    //            dr_Deductee["RecordHash"] = "";
    //            dr_Deductee["DeleteFlag"] = "";
    //            dr_Deductee["C1"] = "";
    //            dr_Deductee["C2"] = "";
    //            dr_Deductee["C3"] = "";
    //            dr_Deductee["C4"] = "";
    //            dr_Deductee["C5"] = "";
    //            dr_Deductee["C9"] = "";
    //            dr_Deductee["Y"] = "";
    //            dr_Deductee["Desicion"] = "";
    //            dr_Deductee["ID_Admin"] = IDAdmin;
    //            dt_Deductee.Rows.Add(dr_Deductee);




    //        }
    //        else if (FormNo == "Form26Q" || FormNo == "Form27Q")
    //        {
    //            objtbl_DeducteeDetail.ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
    //            objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k + 1]);
    //            objtbl_DeducteeDetail.Deductee_PartyCode = dt_DeducteeDetail.Rows[i][k + 2].ToString();
    //            objtbl_DeducteeDetail.EmployeePAN = dt_DeducteeDetail.Rows[i][k + 3].ToString();
    //            objtbl_DeducteeDetail.NameofEmployee_Party = dt_DeducteeDetail.Rows[i][k + 4].ToString();
    //            //Format Amount of Payment Field
    //            string Amount_of_payment = dt_DeducteeDetail.Rows[i][k + 5].ToString();
    //            // Amount_of_payment = string.Format("{0:f2}", Int32.Parse(Amount_of_payment));
    //            objtbl_DeducteeDetail.Amountof_Payment = Convert.ToDouble(Amount_of_payment);
    //            if (dt_DeducteeDetail.Rows[i][k + 6].ToString() != "")
    //            {
    //                string DataType = dt_DeducteeDetail.Columns[6].DataType.ToString();
    //                if (DataType != "System.String")
    //                {
    //                    DateTime dt_On_Which_Amount_Paid = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 6]);
    //                    string Date_On_Which_Amount_Paid = dt_On_Which_Amount_Paid.ToString("dd/MM/yyyy");


    //                    Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
    //                }
    //                else
    //                {
    //                    string Date_Paid = dt_DeducteeDetail.Rows[i][k + 6].ToString();
    //                    string Date_On_Which_Amount_Paid = Date_Paid;


    //                    Date_On_Which_Amount_Paid = Date_On_Which_Amount_Paid.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateOnWhich_AMTPaid = Date_On_Which_Amount_Paid;
    //                }
    //            }
    //            else
    //            {
    //                objtbl_DeducteeDetail.DateOnWhich_AMTPaid = "";
    //            }

    //            if (dt_DeducteeDetail.Rows[i][k + 13].ToString() != "")
    //            {
    //                string DataType = dt_DeducteeDetail.Columns[13].DataType.ToString();
    //                if (DataType != "System.String")
    //                {
    //                    DateTime dt_On_Which_Tax_Deducted = Convert.ToDateTime(dt_DeducteeDetail.Rows[i][k + 13]);
    //                    string Date_On_Which_Tax_Deducted = dt_On_Which_Tax_Deducted.ToString("dd/MM/yyyy");

    //                    Date_On_Which_Tax_Deducted = Date_On_Which_Tax_Deducted.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Tax_Deducted;
    //                }
    //                else
    //                {
    //                    string Date_Deducted = dt_DeducteeDetail.Rows[i][k + 13].ToString();
    //                    string Date_On_Which_Amount_Deducted = Date_Deducted;


    //                    Date_On_Which_Amount_Deducted = Date_On_Which_Amount_Deducted.Replace("/", "");
    //                    objtbl_DeducteeDetail.DateonWhich_TaxDeducted = Date_On_Which_Amount_Deducted;
    //                }
    //            }

    //            //Format Rate at which Tax Deducted Field
    //            string Rate_at_Which_Tax_Deducted = dt_DeducteeDetail.Rows[i][k + 7].ToString();
    //            Rate_at_Which_Tax_Deducted = string.Format("{0:f4}", Double.Parse(Rate_at_Which_Tax_Deducted));

    //            //objtbl_DeducteeDetail.RateatWhich_TAXDeducted = Rate_at_Which_Tax_Deducted.ToString()+".0000";
    //            objtbl_DeducteeDetail.RateatWhich_TAXDeducted = Rate_at_Which_Tax_Deducted.ToString();

    //            //Deposit Tax By Book Entry
    //            objtbl_DeducteeDetail.BookEntry_CashIndicator = dt_DeducteeDetail.Rows[i][k + 8].ToString();
    //            string Book_Entry = objtbl_DeducteeDetail.BookEntry_CashIndicator.ToString();

    //            //Format Income Tax Field
    //            string Income_Tax = dt_DeducteeDetail.Rows[i][k + 9].ToString();
    //            Cash_Entry = Income_Tax;
    //            // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
    //            objtbl_DeducteeDetail.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);

    //            //Format Surcharge Field
    //            string Surcharge = dt_DeducteeDetail.Rows[i][k + 10].ToString();
    //            // Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
    //            objtbl_DeducteeDetail.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

    //            //Format Education_Cess Field
    //            string Education_Cess = dt_DeducteeDetail.Rows[i][k + 11].ToString();
    //            //  Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
    //            objtbl_DeducteeDetail.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);

    //            //Format Total Tax Deposited Field
    //            string Total_Tax_Deposited = dt_DeducteeDetail.Rows[i][k + 12].ToString();
    //            // Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
    //            objtbl_DeducteeDetail.Total_TaxDeposited = Convert.ToDouble(Total_Tax_Deposited);


    //            objtbl_DeducteeDetail.Total_IncomeTAX_Deducted = objtbl_DeducteeDetail.Total_TaxDeposited;



    //            objtbl_DeducteeDetail.Reason_For_NonDeduction = dt_DeducteeDetail.Rows[i][k + 14].ToString();
    //            Section_Code = dt_DeducteeDetail.Rows[i][k + 15].ToString();
    //            Certificate_Number = dt_DeducteeDetail.Rows[i][k + 16].ToString();
    //            WhetherTDSRateofTDSIsITAct27 = dt_DeducteeDetail.Rows[i][k + 17].ToString();
    //            Nature_of_Remittance_27 = dt_DeducteeDetail.Rows[i][k + 18].ToString();
    //            Unique_formno_15CA_27 = dt_DeducteeDetail.Rows[i][k + 19].ToString();
    //            Country_to_which_remittance_is_made_27 = dt_DeducteeDetail.Rows[i][k + 20].ToString();
    //            objtbl_DeducteeDetail.Page_ID = "2";
    //            objtbl_DeducteeDetail.Page_SubModule_ID = "3";


    //            DataRow dr_Deductee = dt_Deductee.NewRow();
    //            dr_Deductee["DeducteeID"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["ID"] = Challan_ID;
    //            dr_Deductee["MasterID"] = Master_ID;
    //            dr_Deductee["Line_Number"] = 0;
    //            dr_Deductee["Record_Type"] = "DD";
    //            dr_Deductee["Batch_Number"] = "1";
    //            dr_Deductee["Challan_Detail_Rec_No"] = Challan_ID;
    //            dr_Deductee["DeducteeParty_Record_No"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["Mode"] = "O";
    //            dr_Deductee["Employee_SerialNo"] = "";
    //            dr_Deductee["LastEmployee_PartyPAN"] = "";
    //            dr_Deductee["Deductee_PartyCode"] = objtbl_DeducteeDetail.Deductee_PartyCode;
    //            dr_Deductee["EmployeePAN"] = objtbl_DeducteeDetail.EmployeePAN;
    //            dr_Deductee["Last_EmployeePartyPAN"] = "";
    //            dr_Deductee["PAN_RefNO"] = "";
    //            dr_Deductee["NameofEmployee_Party"] = objtbl_DeducteeDetail.NameofEmployee_Party;
    //            dr_Deductee["TDS_TCS_IncomeTAX"] = Income_Tax;
    //            dr_Deductee["TDS_TCS_Surcharge"] = Surcharge;
    //            dr_Deductee["TDS_TCS_Cess"] = Education_Cess;
    //            dr_Deductee["Total_IncomeTAX_Deducted"] = objtbl_DeducteeDetail.Total_IncomeTAX_Deducted;
    //            dr_Deductee["Last_Income_TaxDeducted"] = "";
    //            dr_Deductee["Total_TaxDeposited"] = Total_Tax_Deposited;
    //            dr_Deductee["LastTotal_TaxDeposited"] = "";
    //            dr_Deductee["Total_ValuePurchase"] = "";
    //            dr_Deductee["Amountof_Payment"] = Amount_of_payment;
    //            dr_Deductee["DateOnWhich_AMTPaid"] = objtbl_DeducteeDetail.DateOnWhich_AMTPaid;
    //            dr_Deductee["DateonWhich_TaxDeducted"] = objtbl_DeducteeDetail.DateonWhich_TaxDeducted;
    //            dr_Deductee["Dateof_Deposit"] = "";
    //            dr_Deductee["RateatWhich_TAXDeducted"] = objtbl_DeducteeDetail.RateatWhich_TAXDeducted;
    //            dr_Deductee["GrossingUP_Indicator"] = "";
    //            dr_Deductee["BookEntry_CashIndicator"] = Book_Entry;
    //            dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";
    //            dr_Deductee["Reason_For_NonDeduction"] = objtbl_DeducteeDetail.Reason_For_NonDeduction;
    //            dr_Deductee["Remarks1"] = "";
    //            dr_Deductee["Remarks2"] = "";
    //            dr_Deductee["Section_Code"] = Section_Code;
    //            dr_Deductee["Certificate_Number"] = Certificate_Number;
    //            dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = WhetherTDSRateofTDSIsITAct27;
    //            dr_Deductee["Nature_of_Remittance_27"] = Nature_of_Remittance_27;
    //            dr_Deductee["Unique_formno_15CA_27"] = Unique_formno_15CA_27;
    //            dr_Deductee["Country_to_which_remittance_is_made_27"] = Country_to_which_remittance_is_made_27;
    //            dr_Deductee["RecordHash"] = "";
    //            dr_Deductee["DeleteFlag"] = "";
    //            dr_Deductee["C1"] = "";
    //            dr_Deductee["C2"] = "";
    //            dr_Deductee["C3"] = "";
    //            dr_Deductee["C4"] = "";
    //            dr_Deductee["C5"] = "";
    //            dr_Deductee["C9"] = "";
    //            dr_Deductee["Y"] = "";
    //            dr_Deductee["Desicion"] = "";
    //            dr_Deductee["ID_Admin"] = IDAdmin;
    //            dt_Deductee.Rows.Add(dr_Deductee);

    //        }
    //        else if (FormNo == "Form27EQ")
    //        {
    //            objtbl_DeducteeDetail.ID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k]);
    //            objtbl_DeducteeDetail.DeducteeID = Convert.ToInt32(dt_DeducteeDetail.Rows[i][k + 1]);
    //            objtbl_DeducteeDetail.Deductee_PartyCode = dt_DeducteeDetail.Rows[i][k + 2].ToString();
    //            objtbl_DeducteeDetail.EmployeePAN = dt_DeducteeDetail.Rows[i][k + 3].ToString();
    //            objtbl_DeducteeDetail.NameofEmployee_Party = dt_DeducteeDetail.Rows[i][k + 4].ToString();
    //            objtbl_DeducteeDetail.Total_ValuePurchase = dt_DeducteeDetail.Rows[i][k + 5].ToString();
    //            //Format Amount of Payment Field
    //            string Amount_of_payment = dt_DeducteeDetail.Rows[i][k + 6].ToString();
    //            //Amount_of_payment = string.Format("{0:f2}", Int32.Parse(Amount_of_payment));
    //            objtbl_DeducteeDetail.Amountof_Payment = Convert.ToDouble(Amount_of_payment);


    //            objtbl_DeducteeDetail.DateOnWhich_AMTPaid = dt_DeducteeDetail.Rows[i][k + 7].ToString();

    //            //Format Rate at which Tax Deducted Field
    //            string Rate_at_Which_Tax_Deducted = dt_DeducteeDetail.Rows[i][k + 8].ToString();
    //            Rate_at_Which_Tax_Deducted = string.Format("{0:f4}", Double.Parse(Rate_at_Which_Tax_Deducted));
    //            //Rate_at_Which_Tax_Deducted = string.Format("0:f4", Int32.Parse(Rate_at_Which_Tax_Deducted));
    //            objtbl_DeducteeDetail.RateatWhich_TAXDeducted = Rate_at_Which_Tax_Deducted.ToString();

    //            //Deposit Tax By Book Entry
    //            string Book_Entry = dt_DeducteeDetail.Rows[i][k + 9].ToString();

    //            if (Book_Entry == "Yes" || Book_Entry == "Y")
    //            {
    //                objtbl_DeducteeDetail.BookEntry_CashIndicator = "Y";
    //            }
    //            else if (Book_Entry == "No" || Book_Entry == "N")
    //            {
    //                objtbl_DeducteeDetail.BookEntry_CashIndicator = "N";
    //            }


    //            //Format Income Tax Field
    //            string Income_Tax = dt_DeducteeDetail.Rows[i][k + 10].ToString();
    //            // Income_Tax = string.Format("{0:f2}", Int32.Parse(Income_Tax));
    //            objtbl_DeducteeDetail.TDS_TCS_IncomeTAX = Convert.ToDouble(Income_Tax);
    //            Cash_Entry = Income_Tax;
    //            //Format Surcharge Field
    //            string Surcharge = dt_DeducteeDetail.Rows[i][k + 11].ToString();
    //            //Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
    //            objtbl_DeducteeDetail.TDS_TCS_Surcharge = Convert.ToDouble(Surcharge);

    //            //Format Education_Cess Field
    //            string Education_Cess = dt_DeducteeDetail.Rows[i][k + 12].ToString();
    //            // Education_Cess = string.Format("{0:f2}", Int32.Parse(Education_Cess));
    //            objtbl_DeducteeDetail.TDS_TCS_Cess = Convert.ToDouble(Education_Cess);

    //            //Format Total Tax Deposited Field
    //            string Total_Tax_Deposited = dt_DeducteeDetail.Rows[i][k + 13].ToString();
    //            //Total_Tax_Deposited = string.Format("{0:f2}", Int32.Parse(Total_Tax_Deposited));
    //            objtbl_DeducteeDetail.Total_TaxDeposited = Convert.ToDouble(Total_Tax_Deposited);


    //            objtbl_DeducteeDetail.Total_IncomeTAX_Deducted = objtbl_DeducteeDetail.Total_TaxDeposited;

    //            objtbl_DeducteeDetail.DateonWhich_TaxDeducted = dt_DeducteeDetail.Rows[i][k + 14].ToString();

    //            objtbl_DeducteeDetail.Reason_For_NonDeduction = dt_DeducteeDetail.Rows[i][k + 15].ToString();
    //            Section_Code = dt_DeducteeDetail.Rows[i][k + 16].ToString();
    //            Certificate_Number = dt_DeducteeDetail.Rows[i][k + 17].ToString();
    //            WhetherTDSRateofTDSIsITAct27 = dt_DeducteeDetail.Rows[i][k + 18].ToString();
    //            Nature_of_Remittance_27 = dt_DeducteeDetail.Rows[i][k + 19].ToString();
    //            Unique_formno_15CA_27 = dt_DeducteeDetail.Rows[i][k + 20].ToString();
    //            Country_to_which_remittance_is_made_27 = dt_DeducteeDetail.Rows[i][k + 21].ToString();
    //            objtbl_DeducteeDetail.Page_ID = "2";
    //            objtbl_DeducteeDetail.Page_SubModule_ID = "3";



    //            DataRow dr_Deductee = dt_Deductee.NewRow();
    //            dr_Deductee["DeducteeID"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["ID"] = Challan_ID;
    //            dr_Deductee["MasterID"] = Master_ID;
    //            dr_Deductee["Line_Number"] = 0;
    //            dr_Deductee["Record_Type"] = "DD";
    //            dr_Deductee["Batch_Number"] = "1";
    //            dr_Deductee["Challan_Detail_Rec_No"] = Challan_ID;
    //            dr_Deductee["DeducteeParty_Record_No"] = objtbl_DeducteeDetail.DeducteeID;
    //            dr_Deductee["Mode"] = "O";
    //            dr_Deductee["Employee_SerialNo"] = "";
    //            dr_Deductee["LastEmployee_PartyPAN"] = "";
    //            dr_Deductee["Deductee_PartyCode"] = objtbl_DeducteeDetail.Deductee_PartyCode;
    //            dr_Deductee["EmployeePAN"] = objtbl_DeducteeDetail.EmployeePAN;
    //            dr_Deductee["Last_EmployeePartyPAN"] = "";
    //            dr_Deductee["PAN_RefNO"] = "";
    //            dr_Deductee["NameofEmployee_Party"] = objtbl_DeducteeDetail.NameofEmployee_Party;
    //            dr_Deductee["TDS_TCS_IncomeTAX"] = Income_Tax;
    //            dr_Deductee["TDS_TCS_Surcharge"] = Surcharge;
    //            dr_Deductee["TDS_TCS_Cess"] = Education_Cess;
    //            dr_Deductee["Total_IncomeTAX_Deducted"] = objtbl_DeducteeDetail.Total_IncomeTAX_Deducted;
    //            dr_Deductee["Last_Income_TaxDeducted"] = "";
    //            dr_Deductee["Total_TaxDeposited"] = Total_Tax_Deposited;
    //            dr_Deductee["LastTotal_TaxDeposited"] = "";
    //            dr_Deductee["Total_ValuePurchase"] = objtbl_DeducteeDetail.Total_ValuePurchase;
    //            dr_Deductee["Amountof_Payment"] = Amount_of_payment;
    //            dr_Deductee["DateOnWhich_AMTPaid"] = objtbl_DeducteeDetail.DateOnWhich_AMTPaid;
    //            dr_Deductee["DateonWhich_TaxDeducted"] = objtbl_DeducteeDetail.DateonWhich_TaxDeducted;
    //            dr_Deductee["Dateof_Deposit"] = "";
    //            dr_Deductee["RateatWhich_TAXDeducted"] = objtbl_DeducteeDetail.RateatWhich_TAXDeducted;
    //            dr_Deductee["GrossingUP_Indicator"] = "";
    //            dr_Deductee["BookEntry_CashIndicator"] = Book_Entry;
    //            dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";
    //            dr_Deductee["Reason_For_NonDeduction"] = objtbl_DeducteeDetail.Reason_For_NonDeduction;
    //            dr_Deductee["Remarks1"] = "";
    //            dr_Deductee["Remarks2"] = "";
    //            dr_Deductee["Section_Code"] = Section_Code;
    //            dr_Deductee["Certificate_Number"] = Certificate_Number;
    //            dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = WhetherTDSRateofTDSIsITAct27;
    //            dr_Deductee["Nature_of_Remittance_27"] = Nature_of_Remittance_27;
    //            dr_Deductee["Unique_formno_15CA_27"] = Unique_formno_15CA_27;
    //            dr_Deductee["Country_to_which_remittance_is_made_27"] = Country_to_which_remittance_is_made_27;
    //            dr_Deductee["RecordHash"] = "";
    //            dr_Deductee["DeleteFlag"] = "";
    //            dr_Deductee["C1"] = "";
    //            dr_Deductee["C2"] = "";
    //            dr_Deductee["C3"] = "";
    //            dr_Deductee["C4"] = "";
    //            dr_Deductee["C5"] = "";
    //            dr_Deductee["C9"] = "";
    //            dr_Deductee["Y"] = "";
    //            dr_Deductee["Desicion"] = "";
    //            dr_Deductee["ID_Admin"] = IDAdmin;
    //            dt_Deductee.Rows.Add(dr_Deductee);

    //        }
    //        objtbl_ChallanDetails.ID = Master_ID;
    //        objtbl_ChallanDetails.ChallanID = Challan_ID;

    //        int count_deductee = dt_Deductee.Select("ID = '" + Challan_ID.ToString().Trim() + "' ").Length;
    //        DataRow[] dr_Challan = dt_Challan.Select("ChallanID ='" + Challan_ID.ToString().Trim() + "'");
    //        dr_Challan[0]["Count_Of_deductee_PartyRecords"] = count_deductee.ToString();
    //        dt_Challan.AcceptChanges();
    //        int Total_TDS_TCS_IncomeTAX = 0;
    //        int Total_TDS_TCS_Surcharge = 0;
    //        int Total_TDS_TCS_Cess = 0;
    //        int Total_IncomeTAX_Deducted = 0;
    //        if (Cash_Entry != "0")
    //        {
    //            //Update the Total of Deductee Field in the Challan Records.
    //            Total_TDS_TCS_IncomeTAX = (from DataRow dr in dt_Deductee.AsEnumerable()
    //                                       where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
    //                                       select Convert.ToInt32(dr["TDS_TCS_IncomeTAX"])).Sum();


    //            Total_TDS_TCS_Surcharge = (from DataRow dr in dt_Deductee.AsEnumerable()
    //                                       where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
    //                                       select Convert.ToInt32(dr["TDS_TCS_Surcharge"])).Sum();

    //            Total_TDS_TCS_Cess = (from DataRow dr in dt_Deductee.AsEnumerable()
    //                                  where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
    //                                  select Convert.ToInt32(dr["TDS_TCS_Cess"])).Sum();

    //            Total_IncomeTAX_Deducted = (from DataRow dr in dt_Deductee.AsEnumerable()
    //                                        where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == Challan_ID && Convert.ToInt32(dr["MasterID"]) == Master_ID
    //                                        select Convert.ToInt32(dr["Total_IncomeTAX_Deducted"])).Sum();

    //            //Update Challan DataTable
    //            DataRow[] dr_Challan_Excel = dt_Challan.Select("ChallanID='" + Challan_ID + "'");
    //            dr_Challan_Excel[0]["Total_TAX_Deposite_Amount"] = Total_TDS_TCS_IncomeTAX.ToString();
    //            dr_Challan_Excel[0]["TDS_TCS_IncomeTAX"] = Total_TDS_TCS_IncomeTAX.ToString();
    //            dr_Challan_Excel[0]["TDS_TCS_Surcharge"] = Total_TDS_TCS_Surcharge;
    //            dr_Challan_Excel[0]["TDS_TCS_Cess"] = Total_TDS_TCS_Cess;
    //            dr_Challan_Excel[0]["Total_IncomeTAX_Deducted"] = Total_IncomeTAX_Deducted;
    //        }
    //        //else if (Cash_Entry == "0" && Total_IncomeTAX_Deducted==0)
    //        //{
    //        //    DataRow[] dr_Challan_Excel = dt_Challan.Select("ChallanID=" + Challan_ID + " and ID=" + Master_ID + "");
    //        //    dr_Challan_Excel[0]["Total_TAX_Deposite_Amount"] = "0.00";
    //        //    dr_Challan_Excel[0]["TDS_TCS_IncomeTAX"] = "0.00";
    //        //    dr_Challan_Excel[0]["TDS_TCS_Surcharge"] = "0.00";
    //        //    dr_Challan_Excel[0]["TDS_TCS_Cess"] = "0.00";
    //        //    dr_Challan_Excel[0]["Total_IncomeTAX_Deducted"] = "0.00";
    //        //}



    //        k = 0;
    //    }


    //    return dt_Deductee;
    //}

    //Function to Insert Annual Salary Detail
    public DataSet InsertAnnualSalaryDetail_Excel(DataTable dt_AnnualSalaryDetail)
    {
        //Code of saving Challan
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";

        DataTable dt_Salary_Details = new DataTable();
        DataTable dt_Section_Details = new DataTable();
        DataTable dt_16_A = new DataTable();

        dt_Salary_Details = objFillTableFromExcel.Convert_DataTable("tbl_SalaryDetailsRecords", "\t");

        dt_Section_Details = objFillTableFromExcel.Convert_DataTable("tbl_SectionVIA", "\t");
        dt_16_A = objFillTableFromExcel.Convert_DataTable("tbl_16A", "\t");
        dt_Salary_Details.Clear();
        dt_Section_Details.Clear();
        dt_16_A.Clear();
        int IDAdmin = Convert.ToInt32(ViewState["IDAdmin"]);
        //Create Parameters For Inserting Challan Deatils
        objtbl_SalaryDetails.FormNo = ViewState["FormType"].ToString();
        string FormNo = objtbl_SalaryDetails.FormNo.ToString();
        objtbl_SalaryDetails.TAN = ViewState["TAN"].ToString();
        string TAN = objtbl_SalaryDetails.TAN.ToString();
        objtbl_SalaryDetails.Quarter = ViewState["Quarter"].ToString();
        string Quarter = objtbl_SalaryDetails.Quarter;
        objtbl_SalaryDetails.FY = ViewState["FY"].ToString();
        string FY = objtbl_SalaryDetails.FY.ToString();
        objtbl_SalaryDetails.Regular_Correction = "Regular";
        string Regular_Correction = objtbl_SalaryDetails.Regular_Correction.ToString();
        objtbl_SalaryDetails.CorrectionType = "";
        objtbl_SalaryDetails.Correction_Mode = "";
        //Get Master ID
        int Master_ID = objBltbl_SalaryDetails.GetMasterID(objtbl_SalaryDetails);
        int success = 0;


        if (dt_AnnualSalaryDetail.Rows.Count != 0)
        {
            foreach (DataRow rows in dt_AnnualSalaryDetail.Rows)
            {
                if (rows.ItemArray[0].ToString() != "")
                {
                    countAnnualSalary = countAnnualSalary + 1;
                }
            }

            for (int i = 0; i < countAnnualSalary; i++)
            {
                count_sal = count_sal + 1;
                Count_SectionVIA = 0;
                Count_16A = 0;
                Bltbl_16A.SectionDetailRecordNo = 0;
                Bltbl_SectionVI_A.ChapterVIA_DetailRecordsNo = 0;
                int k = 0;
                objtbl_SalaryDetails.ID = Master_ID;
                //int Salary_Detail_Record_No = objBltbl_SalaryDetails.CreateSalaryDetailRecordNumber(objtbl_SalaryDetails);

                objtbl_SalaryDetails.EmployeePAN = dt_AnnualSalaryDetail.Rows[i][k + 1].ToString();
                objtbl_SalaryDetails.NameofEmployee = dt_AnnualSalaryDetail.Rows[i][k + 2].ToString();
                objtbl_SalaryDetails.Category_of_Employee = dt_AnnualSalaryDetail.Rows[i][k + 3].ToString();
                int Salary_Detail_Record_No = count_sal;
                objtbl_SalaryDetails.Salary_Detail_RecordNo = Salary_Detail_Record_No;
                string From_date = dt_AnnualSalaryDetail.Rows[i][k + 4].ToString();

                objtbl_SalaryDetails.Period_of_Employment_FromDate = From_date.ToString();

                string To_date = dt_AnnualSalaryDetail.Rows[i][k + 5].ToString();

                objtbl_SalaryDetails.Period_of_Employment_ToDate = To_date;

                //Taxable Amount Deducted By Current Employer
                string Taxable_Amount_Deducted_By_Current_Employer = dt_AnnualSalaryDetail.Rows[i][k + 6].ToString();
                //Taxable Amount Deducted By Previous Employer
                string Taxable_Amount_Deducted_By_Previous_Employer = dt_AnnualSalaryDetail.Rows[i][k + 7].ToString();

                //Format Total_Amt_of_Sal Field
                string Total_Amt_Sal = dt_AnnualSalaryDetail.Rows[i][k + 8].ToString();
                // Total_Amt_Sal = string.Format("{0:f2}", Int32.Parse(Total_Amt_Sal));
                objtbl_SalaryDetails.TotalAmount_OfSalary = Convert.ToDouble(Total_Amt_Sal);

                //Format Deduction_Under16 Field
                string Deduction_Under16 = dt_AnnualSalaryDetail.Rows[i][k + 9].ToString();
                //Deduction_Under16 = string.Format("{0:f2}", Int32.Parse(Deduction_Under16));
                objtbl_SalaryDetails.GrossTotal_TotalDeduction = Convert.ToDouble(Deduction_Under16);

                //Format Income_Chargeable Field
                string Income_Chargeable = dt_AnnualSalaryDetail.Rows[i][k + 12].ToString();
                //Income_Chargeable = string.Format("{0:f2}", Int32.Parse(Income_Chargeable));
                objtbl_SalaryDetails.Income_Chargeable = Convert.ToDouble(Income_Chargeable);

                //Format Other_Income Field
                string Other_Income = dt_AnnualSalaryDetail.Rows[i][k + 13].ToString();
                //Other_Income = string.Format("{0:f2}", Int32.Parse(Other_Income));
                objtbl_SalaryDetails.Other_Income = Convert.ToDouble(Other_Income);

                //Format Gross_Total_Income Field
                string Gross_Total_Income = dt_AnnualSalaryDetail.Rows[i][k + 14].ToString();
                // Gross_Total_Income = string.Format("{0:f2}", Int32.Parse(Gross_Total_Income));
                objtbl_SalaryDetails.Gross_Total_Income = Convert.ToDouble(Gross_Total_Income);

                //Format Gross_Total Field
                string Gross_Total = dt_AnnualSalaryDetail.Rows[i][k + 18].ToString();
                // Gross_Total = string.Format("{0:f2}", Int32.Parse(Gross_Total));
                objtbl_SalaryDetails.Gross_Total = Convert.ToDouble(Gross_Total);

                //Format Total_TaxableIncome Field
                string Total_TaxableIncome = dt_AnnualSalaryDetail.Rows[i][k + 19].ToString();
                //Total_TaxableIncome = string.Format("{0:f2}", Int32.Parse(Total_TaxableIncome));
                objtbl_SalaryDetails.Total_TaxableIncome = Convert.ToDouble(Total_TaxableIncome);

                //Format IncomeTax_onTotalIncome Field
                string IncomeTax_onTotalIncome = dt_AnnualSalaryDetail.Rows[i][k + 20].ToString();
                //IncomeTax_onTotalIncome = string.Format("{0:f2}", Int32.Parse(IncomeTax_onTotalIncome));
                objtbl_SalaryDetails.IncomeTax_onTotalIncome = Convert.ToDouble(IncomeTax_onTotalIncome);

                //Format Surcharge Field
                string Surcharge = dt_AnnualSalaryDetail.Rows[i][k + 21].ToString();
                // Surcharge = string.Format("{0:f2}", Int32.Parse(Surcharge));
                objtbl_SalaryDetails.Surcharge = Convert.ToDouble(Surcharge);

                //Format EducationCess Field
                string EducationCess = dt_AnnualSalaryDetail.Rows[i][k + 22].ToString();
                // EducationCess = string.Format("{0:f2}", Int32.Parse(EducationCess));
                objtbl_SalaryDetails.EducationCess = Convert.ToDouble(EducationCess);

                //Format IncomeTaxRelief Field
                string IncomeTaxRelief = dt_AnnualSalaryDetail.Rows[i][k + 23].ToString();
                //   IncomeTaxRelief = string.Format("{0:f2}", Int32.Parse(IncomeTaxRelief));
                objtbl_SalaryDetails.IncomeTaxRelief = Convert.ToDouble(IncomeTaxRelief);

                //Format NetIncomeTaxPayable Field
                string NetIncomeTaxPayable = dt_AnnualSalaryDetail.Rows[i][k + 24].ToString();
                //  NetIncomeTaxPayable = string.Format("{0:f2}", Int32.Parse(NetIncomeTaxPayable));
                objtbl_SalaryDetails.NetIncomeTaxPayable = Convert.ToDouble(NetIncomeTaxPayable);
                //Tax Deducted At Source By Current Employer
                string Tax_Deducted_At_Source_By_Current_Employer = dt_AnnualSalaryDetail.Rows[i][k + 25].ToString();

                //Tax Deducted At Source By Previous Employer
                string Tax_Deducted_At_Source_By_Previous_Employer = dt_AnnualSalaryDetail.Rows[i][k + 26].ToString();
                //Format TotalAmountof_TaxDeducted Field
                string TotalAmountof_TaxDeducted = dt_AnnualSalaryDetail.Rows[i][k + 27].ToString();
                //  TotalAmountof_TaxDeducted = string.Format("{0:f2}", Int32.Parse(TotalAmountof_TaxDeducted));
                objtbl_SalaryDetails.TotalAmountof_TaxDeducted = Convert.ToDouble(TotalAmountof_TaxDeducted);

                //Format ShortFall_in_TaxDeducted Field
                string ShortFall_in_TaxDeducted = dt_AnnualSalaryDetail.Rows[i][k + 28].ToString();
                // ShortFall_in_TaxDeducted = string.Format("{0:f2}", Int32.Parse(ShortFall_in_TaxDeducted));
                objtbl_SalaryDetails.ShortFall_in_TaxDeducted = Convert.ToDouble(ShortFall_in_TaxDeducted);

                //Tax_deducted_at_Higher_rate
                string Tax_deducted_at_Higher_rate = dt_AnnualSalaryDetail.Rows[i][k + 29].ToString();
                objtbl_SalaryDetails.Remarks1 = "";

                objtbl_SalaryDetails.Page_ID = "2";
                objtbl_SalaryDetails.Page_SubModule_ID = "3";
                DataRow dr_Salary = dt_Salary_Details.NewRow();
                dr_Salary["ID_Admin"] = IDAdmin;
                dr_Salary["ID"] = Master_ID;
                dr_Salary["Line_Number"] = 0;
                dr_Salary["RecordType"] = "SD";
                dr_Salary["BatchNumber"] = 1;

                dr_Salary["SalaryDetails_RecordNo"] = Salary_Detail_Record_No;
                dr_Salary["Mode"] = "A";
                dr_Salary["Filler"] = "";
                dr_Salary["EmployeePAN"] = objtbl_SalaryDetails.EmployeePAN.ToString();
                dr_Salary["PANRefNo"] = "";
                dr_Salary["NameofEmployee"] = objtbl_SalaryDetails.NameofEmployee;
                dr_Salary["Category_of_Employee"] = objtbl_SalaryDetails.Category_of_Employee;
                dr_Salary["Period_of_Employment_FromDate"] = From_date;
                dr_Salary["Period_of_Employment_ToDate"] = To_date;
                dr_Salary["TotalAmount_OfSalary"] = Total_Amt_Sal;
                dr_Salary["Filler8"] = "";
                dr_Salary["Countof_SalaryDetails"] = 0;
                dr_Salary["GrossTotal_TotalDeduction"] = Deduction_Under16;
                dr_Salary["Income_Chargeable"] = Income_Chargeable;
                dr_Salary["Other_Income"] = Other_Income;
                dr_Salary["Gross_Total_Income"] = Gross_Total_Income;
                dr_Salary["Last_GrossTotal_Income"] = "";
                dr_Salary["CountOF_SalaryDetails_VI"] = 0;
                dr_Salary["Gross_Total"] = Gross_Total;
                dr_Salary["Total_TaxableIncome"] = Total_TaxableIncome;
                dr_Salary["IncomeTax_onTotalIncome"] = IncomeTax_onTotalIncome;
                dr_Salary["Surcharge"] = Surcharge;
                dr_Salary["EducationCess"] = EducationCess;
                dr_Salary["IncomeTaxRelief"] = IncomeTaxRelief;
                dr_Salary["NetIncomeTaxPayable"] = NetIncomeTaxPayable;
                dr_Salary["TotalAmountof_TaxDeducted"] = TotalAmountof_TaxDeducted;
                dr_Salary["ShortFall_in_TaxDeducted"] = ShortFall_in_TaxDeducted;
                dr_Salary["Remarks1"] = "";
                dr_Salary["Remarks2"] = "";
                dr_Salary["Remarks3"] = "";
                dr_Salary["Taxable_Amount_deducted_by_the_current_employer"] = Taxable_Amount_Deducted_By_Current_Employer;
                dr_Salary["Taxable_Amount_deducted_by_the_Previous_employer"] = Taxable_Amount_Deducted_By_Previous_Employer;
                dr_Salary["Total_Amount_deducted_at_source_by_the_current_employer"] = Tax_Deducted_At_Source_By_Current_Employer;
                dr_Salary["Total_Amount_deducted_at_source_by_the_previous_employer"] = Tax_Deducted_At_Source_By_Previous_Employer;
                dr_Salary["Tax_deducted_at_Higher_rate"] = Tax_deducted_at_Higher_rate;

                dr_Salary["RecordHash"] = "";
                dr_Salary["C1"] = "";
                dr_Salary["C2"] = "";
                dr_Salary["C3"] = "";
                dr_Salary["C4"] = "";
                dr_Salary["C5"] = "";
                dr_Salary["C9"] = "";
                dr_Salary["Y"] = "";
                dr_Salary["Decision"] = "";
                dt_Salary_Details.Rows.Add(dr_Salary);










                if (Deduction_Under16 != "" && Deduction_Under16 != null && Deduction_Under16 != "0" && Deduction_Under16 != "0.00")
                {
                    objtbl_16A.ID = objBltbl_SalaryDetails.GetSalaryID(objtbl_SalaryDetails);
                    objtbl_16A.TAN = TAN;
                    objtbl_16A.Quarter = Quarter;
                    objtbl_16A.FY = FY;
                    objtbl_16A.FormNo = FormNo;
                    objtbl_16A.Regular_Correction = Regular_Correction;
                    objtbl_16A.Total_Deduction_Under_Section16 = Convert.ToDouble(Deduction_Under16);
                    objtbl_16A.Salary_Detail_RecordNo = Salary_Detail_Record_No;
                    objtbl_16A.Page_ID = "2";
                    objtbl_16A.Page_SubModule_ID = "3";

                    DataRow dr_16A = dt_16_A.NewRow();
                    dr_16A["ID_Admin"] = IDAdmin;
                    dr_16A["Line_Number"] = 0;
                    dr_16A["Record_Type"] = "S16";
                    dr_16A["Batch_Number"] = 1;
                    int Salary_Detail_RecordNo = objtbl_16A.Salary_Detail_RecordNo;

                    dr_16A["SalaryDetail_RecordNo"] = Salary_Detail_RecordNo;
                    Count_16A = Count_16A + 1;
                    dr_16A["SalaryDetal_Section_RecordNo"] = Count_16A;
                    dr_16A["SectionID"] = "16(iii)";
                    dr_16A["TotalDeduction_UnderSection"] = objtbl_16A.Total_Deduction_Under_Section16;
                    dr_16A["RecordHash"] = "";
                    dt_16_A.Rows.Add(dr_16A);




                }
                string DeductionUS = dt_AnnualSalaryDetail.Rows[i][k + 13].ToString();
                //DeductionUS = string.Format("{0:f2}", Int32.Parse(DeductionUS));
                if (DeductionUS != "" && DeductionUS != null && DeductionUS != "0" && DeductionUS != "0.00")
                {

                    //objtbl_SectionVI_A.ID = objBltbl_SalaryDetails.GetSalaryID(objtbl_SalaryDetails);
                    objtbl_SectionVI_A.Salary_Detail_RecordNo = Convert.ToInt32(objBltbl_SalaryDetails.GetSalary_Detail_RecordNo(objtbl_SalaryDetails));

                    objtbl_SectionVI_A.ChapterVIA_SectionID = "80CCE";
                    objtbl_SectionVI_A.Total_amount_under_ChapterVIA = Convert.ToDouble(DeductionUS);
                    objtbl_SectionVI_A.Regular_Correction = Regular_Correction;
                    objtbl_SectionVI_A.Page_ID = "2";
                    objtbl_SectionVI_A.Page_SubModule_ID = "3";
                    DataRow dr_Section6A = dt_Section_Details.NewRow();

                    dr_Section6A["ID_Admin"] = IDAdmin;
                    dr_Section6A["Line_Number"] = 0;
                    dr_Section6A["Record_Type"] = "C6A";
                    dr_Section6A["Batch_Number"] = 1;
                    dr_Section6A["SalaryDetail_RecordNo"] = Salary_Detail_Record_No;
                    Count_SectionVIA = Count_SectionVIA + 1;
                    dr_Section6A["SalaryDetail_ChapterVI_RecordNO"] = Count_SectionVIA;
                    dr_Section6A["Chapter_VI_SectionID"] = objtbl_SectionVI_A.ChapterVIA_SectionID;
                    dr_Section6A["TotalAmount_UnderChapterVI"] = objtbl_SectionVI_A.Total_amount_under_ChapterVIA;
                    dr_Section6A["RecordHash"] = "";
                    dt_Section_Details.Rows.Add(dr_Section6A);
                }
                string DeductionUS80CCF = dt_AnnualSalaryDetail.Rows[i][k + 14].ToString();
                // DeductionUS80CCF = string.Format("{0:f2}", Int32.Parse(DeductionUS80CCF));
                if (DeductionUS80CCF != "" && DeductionUS80CCF != null && DeductionUS80CCF != "0" && DeductionUS80CCF != "0.00")
                {
                    Count_SectionVIA = Count_SectionVIA + 1;
                    //objtbl_SectionVI_A.ID = objBltbl_SalaryDetails.GetSalaryID(objtbl_SalaryDetails);
                    objtbl_SectionVI_A.Salary_Detail_RecordNo = Convert.ToInt32(objBltbl_SalaryDetails.GetSalary_Detail_RecordNo(objtbl_SalaryDetails));

                    objtbl_SectionVI_A.ChapterVIA_SectionID = "80CCF";
                    objtbl_SectionVI_A.Total_amount_under_ChapterVIA = Convert.ToDouble(DeductionUS80CCF);
                    objtbl_SectionVI_A.Page_ID = "2";
                    objtbl_SectionVI_A.Page_SubModule_ID = "3";
                    DataRow dr_Section6A = dt_Section_Details.NewRow();
                    dr_Section6A["ID_Admin"] = IDAdmin;
                    dr_Section6A["Line_Number"] = 0;
                    dr_Section6A["Record_Type"] = "C6A";
                    dr_Section6A["Batch_Number"] = 1;
                    dr_Section6A["SalaryDetail_RecordNo"] = Salary_Detail_Record_No;
                    dr_Section6A["SalaryDetail_ChapterVI_RecordNO"] = Count_SectionVIA;
                    dr_Section6A["Chapter_VI_SectionID"] = objtbl_SectionVI_A.ChapterVIA_SectionID;
                    dr_Section6A["TotalAmount_UnderChapterVI"] = objtbl_SectionVI_A.Total_amount_under_ChapterVIA;
                    dr_Section6A["RecordHash"] = "";
                    dt_Section_Details.Rows.Add(dr_Section6A);

                }
                string OtherDeduction = dt_AnnualSalaryDetail.Rows[i][k + 15].ToString();
                // OtherDeduction = string.Format("{0:f2}", Int32.Parse(OtherDeduction));
                if (OtherDeduction != "" && OtherDeduction != null && OtherDeduction != "0" && OtherDeduction != "0.00")
                {
                    Count_SectionVIA = Count_SectionVIA + 1;
                    //objtbl_SectionVI_A.ID = objBltbl_SalaryDetails.GetSalaryID(objtbl_SalaryDetails);
                    objtbl_SectionVI_A.Salary_Detail_RecordNo = Convert.ToInt32(objBltbl_SalaryDetails.GetSalary_Detail_RecordNo(objtbl_SalaryDetails));

                    objtbl_SectionVI_A.ChapterVIA_SectionID = "OTHERS";
                    objtbl_SectionVI_A.Total_amount_under_ChapterVIA = Convert.ToDouble(OtherDeduction);
                    objtbl_SectionVI_A.Page_ID = "2";
                    objtbl_SectionVI_A.Page_SubModule_ID = "3";
                    DataRow dr_Section6A = dt_Section_Details.NewRow();
                    dr_Section6A["ID_Admin"] = IDAdmin;
                    dr_Section6A["Line_Number"] = 0;
                    dr_Section6A["Record_Type"] = "C6A";
                    dr_Section6A["Batch_Number"] = 1;
                    dr_Section6A["SalaryDetail_RecordNo"] = Salary_Detail_Record_No;
                    dr_Section6A["SalaryDetail_ChapterVI_RecordNO"] = Count_SectionVIA;
                    dr_Section6A["Chapter_VI_SectionID"] = objtbl_SectionVI_A.ChapterVIA_SectionID;
                    dr_Section6A["TotalAmount_UnderChapterVI"] = objtbl_SectionVI_A.Total_amount_under_ChapterVIA;
                    dr_Section6A["RecordHash"] = "";
                    dt_Section_Details.Rows.Add(dr_Section6A);

                }
                //Update the Count of Section 6 A in Salary Detail Record 

                //int count_Sec_6A = dt_Section_Details.Select("ID_Admin=" + IDAdmin + " and SalaryDetail_RecordNo=" + Salary_Detail_Record_No + " ").Length;
                //DataRow[] dr_Sal = dt_Salary_Details.Select("ID_Admin=" + IDAdmin + "  and SalaryDetails_RecordNo=" + Salary_Detail_Record_No + "");
                // dr_Sal[0]["CountOF_SalaryDetails_VI"] = count_Sec_6A;



                //Initialize ID Object
                //objtbl_SalaryDetails.ID = Master_ID;
                ////Get ID_Admin
                //int ID_Admin = objBltbl_SalaryDetails.GetIDAdmin(objtbl_SalaryDetails);
                //Session["Sal_ID"] = ID_Admin;
                //objtbl_SalaryDetails.SalaryID = ID_Admin;
                //objtbl_SalaryDetails.ID_Admin = ID_Admin;

                ////Update the Salary Detail Record No in 16A and 16A Counts 
                //if (Deduction_Under16 != "0.00")
                //{
                //    int success_16A = 0;
                //    //Get The Count Of 16 A
                //    objtbl_16A.ID_Admin = ID_Admin;
                //    int Count_16A = objBltbl_16A.Count_16A(objtbl_16A);
                //    //Update the Count of 16A in the Salary Details
                //    objtbl_SalaryDetails.Count_16A = Count_16A;
                //    success_16A = objBltbl_SalaryDetails.Update_Count16A(objtbl_SalaryDetails);
                //    //Update the Salary Detail Record No in 16 A
                //    int SalaryDetailRecordNo = Salary_Detail_Record_No;
                //    objtbl_16A.Salary_Detail_RecordNo = SalaryDetailRecordNo;
                //    success_16A = objBltbl_16A.Update_Salary_Detail_RecordNo_16A(objtbl_16A);
                //    if (success_16A == 1)
                //    {
                //        objtbl_16A.Salary_Detail_RecordNo = -999999999;
                //        objBltbl_16A.Update_Salary_Detail_RecordNo_16A(objtbl_16A);
                //    }


                //}
                ////Update the Salary Detail Record No And Chapter6 A Counts

                //objtbl_SalaryDetails.CountOF_SalaryDetails_VI = objBltbl_SalaryDetails.GetCount_of_Salary_Detail_Record_VIA(objtbl_SalaryDetails);
                //objtbl_SalaryDetails.Countof_SalaryDetails = objBltbl_SalaryDetails.GetSalary_Detail_RecordNo(objtbl_SalaryDetails);
                //objtbl_SalaryDetails.Page_ID = "2";
                //objtbl_SalaryDetails.Page_SubModule_ID = "22";
                //objtbl_SalaryDetails.ID_Admin = ID_Admin;
                // success = objBltbl_SalaryDetails.Update_Count(objtbl_SalaryDetails);
                //objBltbl_SalaryDetails.Update_Count_SectionVIA(objtbl_SalaryDetails);
                //if (success == 1)
                //{
                //    objtbl_SalaryDetails.Countof_SalaryDetails = -999999999;
                //    objBltbl_SalaryDetails.Update_Count_SectionVIA(objtbl_SalaryDetails);
                //}
                k = 0;
                IDAdmin = IDAdmin + 1;
            }


        }
        DataSet ds = new DataSet();
        ds.Tables.Add(dt_Salary_Details);
        ds.Tables.Add(dt_Section_Details);
        ds.Tables.Add(dt_16_A);
        return ds;
    }
    public int InsertTANMaster_Excel(DataTable dt_Deductor)
    {
        //Code of saving Challan
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.count = 0;
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_update = new List<string[]>();
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.Previous_Table = "";

        int success = 0;
        //Create Parameters
        objtbl_TANMaster.TAN = dt_Deductor.Rows[0]["Deductor Info"].ToString();
        objtbl_TANMaster.PAN = dt_Deductor.Rows[4]["Deductor Info"].ToString();
        objtbl_TANMaster.Type = dt_Deductor.Rows[18]["Deductor Info"].ToString();
        objtbl_TANMaster.AName = dt_Deductor.Rows[5]["Deductor Info"].ToString();
        objtbl_TANMaster.PName = dt_Deductor.Rows[20]["Deductor Info"].ToString();
        objtbl_TANMaster.PDesig = dt_Deductor.Rows[21]["Deductor Info"].ToString();
        objtbl_TANMaster.AFlat = dt_Deductor.Rows[7]["Deductor Info"].ToString();
        objtbl_TANMaster.APremises = dt_Deductor.Rows[8]["Deductor Info"].ToString();
        objtbl_TANMaster.ARoad = dt_Deductor.Rows[9]["Deductor Info"].ToString();
        objtbl_TANMaster.AArea = dt_Deductor.Rows[10]["Deductor Info"].ToString();
        objtbl_TANMaster.ATown = dt_Deductor.Rows[11]["Deductor Info"].ToString();
        objtbl_TANMaster.AState = dt_Deductor.Rows[12]["Deductor Info"].ToString();
        objtbl_TANMaster.APINCode = dt_Deductor.Rows[13]["Deductor Info"].ToString();
        objtbl_TANMaster.PFlat = dt_Deductor.Rows[22]["Deductor Info"].ToString();
        objtbl_TANMaster.PPremises = dt_Deductor.Rows[23]["Deductor Info"].ToString();
        objtbl_TANMaster.PRoad = dt_Deductor.Rows[24]["Deductor Info"].ToString();
        objtbl_TANMaster.PArea = dt_Deductor.Rows[25]["Deductor Info"].ToString();
        objtbl_TANMaster.PTown = dt_Deductor.Rows[26]["Deductor Info"].ToString();
        objtbl_TANMaster.PState = dt_Deductor.Rows[27]["Deductor Info"].ToString();
        objtbl_TANMaster.PPINCode = dt_Deductor.Rows[28]["Deductor Info"].ToString();
        objtbl_TANMaster.Branch = dt_Deductor.Rows[6]["Deductor Info"].ToString();
        objtbl_TANMaster.ASTDCode = dt_Deductor.Rows[15]["Deductor Info"].ToString();
        objtbl_TANMaster.APhone = dt_Deductor.Rows[16]["Deductor Info"].ToString();
        objtbl_TANMaster.AEmail = dt_Deductor.Rows[14]["Deductor Info"].ToString();
        objtbl_TANMaster.PSTDCode = dt_Deductor.Rows[30]["Deductor Info"].ToString();
        objtbl_TANMaster.PPhone = dt_Deductor.Rows[31]["Deductor Info"].ToString();
        objtbl_TANMaster.PEmail = dt_Deductor.Rows[29]["Deductor Info"].ToString();
        objtbl_TANMaster.FatherName = dt_Deductor.Rows[20]["Deductor Info"].ToString();
        objtbl_TANMaster.Flat = "";
        objtbl_TANMaster.House = "";
        objtbl_TANMaster.Floor = "";
        objtbl_TANMaster.Building = "";
        objtbl_TANMaster.Block = "";
        objtbl_TANMaster.Road = "";
        objtbl_TANMaster.Locality = "";
        objtbl_TANMaster.City = "";
        objtbl_TANMaster.State = "";
        objtbl_TANMaster.PINCode = "";
        objtbl_TANMaster.Status = "";
        objtbl_TANMaster.CIT = "";
        objtbl_TANMaster.District = "";
        objtbl_TANMaster.Medium = "";
        objtbl_TANMaster.FileNum = "";
        objtbl_TANMaster.StateCode = dt_Deductor.Rows[12]["Deductor Info"].ToString();
        objtbl_TANMaster.PAOCode = dt_Deductor.Rows[34]["Deductor Info"].ToString();
        objtbl_TANMaster.DDOCode = dt_Deductor.Rows[35]["Deductor Info"].ToString();
        objtbl_TANMaster.PAORegNo = dt_Deductor.Rows[38]["Deductor Info"].ToString();
        objtbl_TANMaster.DDORegNo = dt_Deductor.Rows[39]["Deductor Info"].ToString();
        objtbl_TANMaster.MinistryCode = dt_Deductor.Rows[37]["Deductor Info"].ToString();
        objtbl_TANMaster.MinistryName = dt_Deductor.Rows[36]["Deductor Info"].ToString();
        objtbl_TANMaster.MobileNumber = dt_Deductor.Rows[32]["Deductor Info"].ToString();
        objtbl_TANMaster.AIN_Number = "";
        objtbl_TANMaster.Page_ID = "1";
        objtbl_TANMaster.Page_SubModule_ID = "1";
        objtbl_TANMaster.PANof_Responsible_Person = "";
        //Call A Function to Insert the new Tan Entry
        bool isNewRecord = objBltbl_TANMaster.CheckRecordExistence(objtbl_TANMaster);
        if (isNewRecord)
        {
            success = objBltbl_TANMaster.InsertTANEntry(objtbl_TANMaster);
            objtbl_TANMaster.TAN = "-999999999";
            objBltbl_TANMaster.InsertTANEntry(objtbl_TANMaster);
        }
        return success;
    }
    ////Function to Insert TAN Master
    //public int InsertTANMaster_Excel(DataTable dt_Deductor)
    //{
    //    //Code of saving Challan
    //    DBtbl_Module.ArrayIndex = 0;
    //    DBtbl_Module.count = 0;
    //    DBtbl_Module.lst_Field = new Dictionary<string, int>();
    //    DBtbl_Module.lst_Query = new List<string>();
    //    DBtbl_Module.lst_update = new List<string[]>();
    //    DBtbl_Module.Previous_RecordNo = 0;
    //    DBtbl_Module.Previous_Table = "";

    //    int success = 0;
    //    //Create Parameters
    //    objtbl_TANMaster.TAN = dt_Deductor.Rows[0]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PAN = dt_Deductor.Rows[4]["Deductor Info"].ToString();
    //    objtbl_TANMaster.Type = dt_Deductor.Rows[18]["Deductor Info"].ToString();
    //    objtbl_TANMaster.AName = dt_Deductor.Rows[5]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PName = dt_Deductor.Rows[20]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PDesig = dt_Deductor.Rows[21]["Deductor Info"].ToString();
    //    objtbl_TANMaster.AFlat = dt_Deductor.Rows[7]["Deductor Info"].ToString();
    //    objtbl_TANMaster.APremises = dt_Deductor.Rows[8]["Deductor Info"].ToString();
    //    objtbl_TANMaster.ARoad = dt_Deductor.Rows[9]["Deductor Info"].ToString();
    //    objtbl_TANMaster.AArea = dt_Deductor.Rows[10]["Deductor Info"].ToString();
    //    objtbl_TANMaster.ATown = dt_Deductor.Rows[11]["Deductor Info"].ToString();
    //    objtbl_TANMaster.AState = dt_Deductor.Rows[12]["Deductor Info"].ToString();
    //    objtbl_TANMaster.APINCode = dt_Deductor.Rows[13]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PFlat = dt_Deductor.Rows[22]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PPremises = dt_Deductor.Rows[23]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PRoad = dt_Deductor.Rows[24]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PArea = dt_Deductor.Rows[25]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PTown = dt_Deductor.Rows[26]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PState = dt_Deductor.Rows[27]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PPINCode = dt_Deductor.Rows[28]["Deductor Info"].ToString();
    //    objtbl_TANMaster.Branch = dt_Deductor.Rows[6]["Deductor Info"].ToString();
    //    objtbl_TANMaster.ASTDCode = dt_Deductor.Rows[15]["Deductor Info"].ToString();
    //    objtbl_TANMaster.APhone = dt_Deductor.Rows[16]["Deductor Info"].ToString();
    //    objtbl_TANMaster.AEmail = dt_Deductor.Rows[14]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PSTDCode = dt_Deductor.Rows[30]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PPhone = dt_Deductor.Rows[31]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PEmail = dt_Deductor.Rows[29]["Deductor Info"].ToString();
    //    objtbl_TANMaster.FatherName = dt_Deductor.Rows[20]["Deductor Info"].ToString();
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
    //    objtbl_TANMaster.StateCode = dt_Deductor.Rows[12]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PAOCode = dt_Deductor.Rows[34]["Deductor Info"].ToString();
    //    objtbl_TANMaster.DDOCode = dt_Deductor.Rows[35]["Deductor Info"].ToString();
    //    objtbl_TANMaster.PAORegNo = dt_Deductor.Rows[38]["Deductor Info"].ToString();
    //    objtbl_TANMaster.DDORegNo = dt_Deductor.Rows[39]["Deductor Info"].ToString();
    //    objtbl_TANMaster.MinistryCode = dt_Deductor.Rows[37]["Deductor Info"].ToString();
    //    objtbl_TANMaster.MinistryName = dt_Deductor.Rows[36]["Deductor Info"].ToString();
    //    objtbl_TANMaster.MobileNumber = dt_Deductor.Rows[32]["Deductor Info"].ToString();
    //    objtbl_TANMaster.Page_ID = "1";
    //    objtbl_TANMaster.Page_SubModule_ID = "1";
    //    //Call A Function to Insert the new Tan Entry
    //    bool isNewRecord = objBltbl_TANMaster.CheckRecordExistence(objtbl_TANMaster);
    //    if (isNewRecord)
    //    {
    //        success = objBltbl_TANMaster.InsertTANEntry(objtbl_TANMaster);
    //        objtbl_TANMaster.TAN = "-999999999";
    //        objBltbl_TANMaster.InsertTANEntry(objtbl_TANMaster);
    //    }
    //    return success;
    //}

    //Function Update Master table 
    public int Update_Master()
    {
        //Code of saving Challan

        int success = 0;
        string FormNo = ViewState["FormNumber"].ToString();
        string Quarter = ViewState["Period"].ToString();
        string Update_FormNo = string.Empty;
        if (FormNo == "24Q")
        {
            Update_FormNo = "Form24Q";
        }
        else if (FormNo == "24Q" && Quarter == "Q4")
        {
            Update_FormNo = "Form24Q-Q4";
        }
        else if (FormNo == "26Q")
        {
            Update_FormNo = "Form26Q";
        }
        else if (FormNo == "27Q")
        {
            Update_FormNo = "Form27Q";
        }
        else if (FormNo == "Form27EQ")
        {
            Update_FormNo = "Form27EQ";
        }
        string FY = ViewState["Financial_Year"].ToString();


        string[] arrparam = { ViewState["Tan_of_Employer"].ToString(), ViewState["Period"].ToString(), FY, Update_FormNo, ViewState["ID"].ToString() };
        success = objDBtbl_Module.DMLOperation(arrparam, 12, 120, ViewState["ID"].ToString(), "2", "3");

        return success;
    }
    public int Update_File_Header()
    {
        string[] arrparam = new string[] { ViewState["Financial_Year"].ToString(), ViewState["ID"].ToString() };
        int success = objDBtbl_Module.DMLOperation(arrparam, 11, 121, ViewState["ID"].ToString(), "2", "3");

        return success;
    }
    public string[] GetBatchHeaderData(string file)
    {
        StreamReader reader = new StreamReader(file, false);
        string[] lines = reader.ReadToEnd().Split(new char[] { '\n' });
        string BatchHeader = lines[1].ToString();
        string[] arrBatchHeader = (string[])BatchHeader.Split('^');
        reader.Close();
        reader.Dispose();
        return arrBatchHeader;
    }

    protected void btn_Close_Click(object sender, ImageClickEventArgs e)
    {
        CloseButtonClick(sender, e);
    }

    #endregion

    #region Alert Message
    protected void msg_confirm_GetMessageBoxResponse(object sender, Utilities.MessageBox.MessageBoxEventHandler e)
    {
        if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Ok)
        {

            Import_OkButtonClick(sender, e);
        }
        else if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Cancel)
        {
            CancelButtonClick(sender, e);
        }
    }
    void Import_OkButtonClick(object sender, EventArgs e)
    {
        if (Session["TANImport"] != null)
        {
            string TAN = Session["TANImport"].ToString();
            ViewState["TAN"] = TAN.ToString();
            string FY = Session["FYImport"].ToString();
            ViewState["FinancialYear"] = FY;
            string Quarter = Session["QuarterImport"].ToString();
            ViewState["Quarter"] = Quarter;
            string FormNo = Session["FormNoImport"].ToString();
            Session["FormType"] = FormNo;
            string PAN = Session["PANImport"].ToString();
            int Role_ID = Convert.ToInt32(Session["Role_ID"]);
            int UserID = Convert.ToInt32(Session["UserID"]);
            string Regular_Correction = string.Empty;
            string CheckReg_Corr = Session["Regular_CorrectionImport"].ToString();

            if (CheckReg_Corr == "Import_Reg" || CheckReg_Corr == "Regular")
            {
                Regular_Correction = "Regular";
            }
            else if (CheckReg_Corr == "Import_Corr" || CheckReg_Corr == "Correction")
            {
                Regular_Correction = "Correction";
            }

            string AName = Session["ANameImport"].ToString();

            string AssessmentYear = Session["AssessmentYearImport"].ToString();
            ViewState["AssessmentYear"] = AssessmentYear;
            ViewState["PAN"] = Session["PANImport"].ToString();
            ViewState["AName"] = AName;


            string path = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

            string Host = HttpContext.Current.Request.Url.DnsSafeHost.ToString();

            string Project_Name = "Admin";

            objtbl_PathManagement.Host = Host;
            objtbl_PathManagement.Path_Name = Project_Name;
            string LivePath = string.Empty;
            DataTable dt_Path = objbltbl_PathManagement.Get_Path(objtbl_PathManagement);
            if (dt_Path.Rows.Count != 0)
            {
                LivePath = dt_Path.Rows[0]["Path"].ToString();
            }
            //Comment by Mudit As Dont Know where Control is to be shown
            //Response.Redirect(@"" + LivePath + "Salary.aspx?vtype=");


        }
    }
    //Event of the msg_alert To Fire Yes and No Click
    protected void msg_alert_GetMessageBoxResponse(object sender, Utilities.MessageBox.MessageBoxEventHandler e)
    {
        if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Ok)
        {
            //AlertOkButtonClick(sender, e);
            //Delete the Previous Return
            objtbl_ChallanDetails.TAN = Session["TANImport"].ToString();
            objtbl_ChallanDetails.Quarter = Session["QuarterImport"].ToString();
            string Quarter = objtbl_ChallanDetails.Quarter.ToString();
            objtbl_ChallanDetails.FinancialYear = Session["FYImport"].ToString();
            objtbl_ChallanDetails.FormType = Session["FormNoImport"].ToString();
            string FormType = objtbl_ChallanDetails.FormType.ToString();
            string Regular_Correction = Session["Regular_CorrectionImport"].ToString();
            objtbl_ChallanDetails.Regular_Correction = Regular_Correction;

            int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
            objtbl_ChallanDetails.ID = MasterID;
            objtbl_DeducteeDetail.MasterID = MasterID;
            objtbl_SalaryDetails.ID = MasterID;

            //Delete the Record From Challan By Master ID
            int success_challan = objBltbl_ChallanDetails.DeleteChallanByMasterID(objtbl_ChallanDetails);

            int success_deductee = objBltbl_DeducteeDetail.DeleteDeducteeByMasterID(objtbl_DeducteeDetail);

            if (FormType == "Form24Q" && Quarter == "Q4")
            {
                int success_salary = objBltbl_SalaryDetails.DeleteSalaryByMasterID(objtbl_SalaryDetails);

            }
            objtbl_FileHeader.ID = MasterID;
            int success = objBltbl_FileHeader.Delete_Master_Record(objtbl_FileHeader);
            //Delete the Record From Regular File While Doing Correction
            if (Regular_Correction == "Correction")
            {
                objtbl_ChallanDetails.Regular_Correction = "Regular";

                int MasterIDReg = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
                objtbl_ChallanDetails.ID = MasterIDReg;
                objtbl_DeducteeDetail.MasterID = MasterIDReg;
                objtbl_SalaryDetails.ID = MasterIDReg;

                //Delete the Record From Challan By Master ID
                int success_challanReg = objBltbl_ChallanDetails.DeleteChallanByMasterID(objtbl_ChallanDetails);

                int success_deducteeReg = objBltbl_DeducteeDetail.DeleteDeducteeByMasterID(objtbl_DeducteeDetail);

                if (FormType == "Form24Q" && Quarter == "Q4")
                {
                    int success_salary = objBltbl_SalaryDetails.DeleteSalaryByMasterID(objtbl_SalaryDetails);

                }
                objtbl_FileHeader.ID = MasterID;
                int successReg = objBltbl_FileHeader.Delete_Master_Record(objtbl_FileHeader);
            }
            //Import the New Return
            string Filepath = Session["Filepath"].ToString();
            string FileExtension = Session["FileExtension"].ToString();
            string Upload_FileName = Session["Upload_FileName"].ToString();

            Import_Data(FileExtension, Filepath, Upload_FileName);

        }
        else if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Cancel)
        {

        }

    }
    //Event of the Confirm Box To Fire Yes and No Click
    protected void msg_Imp_GetMessageBoxResponse(object sender, Utilities.MessageBox.MessageBoxEventHandler e)
    {
        if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Ok)
        {
            DataTable dt_TAN = (DataTable)ViewState["Batch_Header"];
            UpdateTANMaster(dt_TAN);
        }
        else if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Cancel)
        {

        }
    }
    //Event of the Valid Date Box 
    protected void msg_Valid_Date_GetMessageBoxResponse(object sender, Utilities.MessageBox.MessageBoxEventHandler e)
    {

        if (e.ButtonPressed == Utilities.MessageBox.MessageBoxEventHandler.Button.Ok)
        {
            string Name = "Invalid Dates";
            DataTable dtInValidDates = (DataTable)ViewState["InvalidDates"];
            var wb = new XLWorkbook();
            wb.Worksheets.Add(dtInValidDates, "DEDUCTORS DETAIL");
            string Path_Excel = Server.MapPath(@"~\Upload\" + Name + ".xlsx");
            wb.SaveAs(Path_Excel);
            wb.Dispose();
            //ExcelHelper.ExcelHelper.ToExcel(ds_Excel, Name, Page.Response);


            //Save as Excel File
            string Extension = Path.GetExtension(Path_Excel);
            string type = string.Empty;
            if (Extension.ToLower() == ".xls")
            {
                type = "application/msexcel";
            }
            else if (Extension.ToLower() == ".xlsx")
            {
                type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }


            Response.ContentType = type;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Name + ".xlsx");
            Page.Response.WriteFile(Path_Excel);
            Response.End();

        }

    }
    #endregion

    #region Functions
    public void CheckDateByQuarter(string Date_On_Which_Amount_Paid, string Financial_Years, DataRow dr, DataTable dt_InvalidDates, int Deductee_Count)
    {

        bool IsvalidQuarter = false;
        //Create DataTable For Invalid Dates

        string[] arr_ValidDate = new string[Deductee_Count];
        DateTime CurrentDate;
        string FY = Financial_Years;
        FY = FY.Remove(4, 2);
        string CurrentMonth = string.Empty;
        string CurrentYear = string.Empty;
        if (ViewState["Quarter"].ToString() == "Q1")
        {
            CurrentDate = DateTime.ParseExact(Date_On_Which_Amount_Paid.Trim(), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture); ;
            CurrentMonth = CurrentDate.Month.ToString();
            CurrentYear = CurrentDate.Year.ToString();
            if (Convert.ToInt32(CurrentMonth) >= 4 && Convert.ToInt32(CurrentMonth) <= 6 && Convert.ToInt32(CurrentYear) == Convert.ToInt32(FY) && CurrentDate < DateTime.Now)
            {


                arr_ValidDate[Count_index] = "Y";
            }
            else
            {

                arr_ValidDate[Count_index] = "N";
                dt_InvalidDates.ImportRow(dr);
                dt_InvalidDates.AcceptChanges();
            }

        }
        else if (ViewState["Quarter"].ToString() == "Q2")
        {
            CurrentDate = DateTime.ParseExact(Date_On_Which_Amount_Paid.Trim(), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
            CurrentMonth = CurrentDate.Month.ToString();
            CurrentYear = CurrentDate.Year.ToString();
            if (Convert.ToInt32(CurrentMonth) >= 7 && Convert.ToInt32(CurrentMonth) <= 9 && Convert.ToInt32(CurrentYear) == Convert.ToInt32(FY) && CurrentDate < DateTime.Now)
            {

                arr_ValidDate[Count_index] = "Y";
            }
            else
            {

                arr_ValidDate[Count_index] = "N";
                dt_InvalidDates.ImportRow(dr);
                dt_InvalidDates.AcceptChanges();
            }
        }
        else if (ViewState["Quarter"].ToString() == "Q3")
        {

            CurrentDate = DateTime.ParseExact(Date_On_Which_Amount_Paid.Trim(), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);

            CurrentMonth = CurrentDate.Month.ToString();
            CurrentYear = CurrentDate.Year.ToString();
            if (Convert.ToInt32(CurrentMonth) >= 10 && Convert.ToInt32(CurrentMonth) <= 12 && Convert.ToInt32(CurrentYear) == Convert.ToInt32(FY) && CurrentDate < DateTime.Now)
            {

                arr_ValidDate[Count_index] = "Y";

            }
            else
            {
                arr_ValidDate[Count_index] = "N";
                dt_InvalidDates.ImportRow(dr);
                dt_InvalidDates.AcceptChanges();
            }
        }
        else if (ViewState["Quarter"].ToString() == "Q4")
        {
            CurrentDate = DateTime.ParseExact(Date_On_Which_Amount_Paid.Trim(), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture); ;
            CurrentMonth = CurrentDate.Month.ToString();
            CurrentYear = CurrentDate.Year.ToString();
            if (Convert.ToInt32(CurrentMonth) >= 1 && Convert.ToInt32(CurrentMonth) <= 3 && Convert.ToInt32(CurrentYear) > Convert.ToInt32(FY) && CurrentDate < DateTime.Now)
            {
                arr_ValidDate[Count_index] = "Y";

            }
            else
            {
                arr_ValidDate[Count_index] = "N";
                dt_InvalidDates.ImportRow(dr);
                dt_InvalidDates.AcceptChanges();
            }
        }

        Count_index = Count_index + 1;


    }
    //Function to Trace the Errors in the Deductee Data Coming From Excel
    public DataTable Get_Error_List(DataTable dt_Deductee, string Flag_Operation, string Form)
    {
        list.Service objService = new list.Service();
        //Declare Generic List of type string
        DataTable dtListError = new DataTable();
        //Add dataColumn to the DataTable
        //Row No
        DataColumn dt_ColRowNo = new DataColumn("Row No", typeof(string));
        dtListError.Columns.Add(dt_ColRowNo);

        //Field Column
        DataColumn dt_ColField = new DataColumn("Name of Column", typeof(string));
        dtListError.Columns.Add(dt_ColField);


        //Message
        DataColumn dt_Message = new DataColumn("Message", typeof(string));
        dtListError.Columns.Add(dt_Message);


        //Declare Rowindex of the row
        int rowindex = 2;
        if (Flag_Operation == "ValidatePAN")
        {

            foreach (DataRow dr in dt_Deductee.Rows)
            {
                DataRow dr_ValidatePan = dtListError.NewRow();
                string PAN = dr["EmployeePAN"].ToString();
                bool IsValid = objService.ValiadtePAN(PAN);


                if (!IsValid)
                {
                    //arrListError.Add("PAN:-"+PAN+"at Row No"+rowindex+"is not valid.");
                    dr_ValidatePan["Name of Column"] = "PAN";
                    dr_ValidatePan["Row No"] = rowindex;
                    dr_ValidatePan["Message"] = "PAN " + PAN + " is invalid. ";
                    dtListError.Rows.Add(dr_ValidatePan);
                }
                rowindex = rowindex + 1;
            }
        }
        else if (Flag_Operation == "ValidatePANLength")
        {
            rowindex = 2;
            foreach (DataRow dr in dt_Deductee.Rows)
            {
                DataRow dr_ValidatePan = dtListError.NewRow();
                string PAN = dr["EmployeePAN"].ToString();
                bool IsValid = objService.ValidatePANLenght(PAN);
                if (!IsValid)
                {
                    //arrListError.Add("PAN:-" + PAN + "at Row No:" + rowindex + "is not having valid length.");
                    dr_ValidatePan["Name of Column"] = "PAN";
                    dr_ValidatePan["Row No"] = rowindex;
                    dr_ValidatePan["Message"] = "PAN " + PAN + " is having invalid length,it should be of 10 digits. ";
                    dtListError.Rows.Add(dr_ValidatePan);
                }
                rowindex = rowindex + 1;
            }
        }
        else if (Flag_Operation == "ValidateEmptyField")
        {
            rowindex = 2;
            //Return the Empty PAN Row No

            foreach (DataRow dr in dt_Deductee.Rows)
            {
                DataRow dr_ValidatePan = dtListError.NewRow();
                string PAN = dr["EmployeePAN"].ToString();

                //Validate each field one by one and 
                bool IS_PANEmpty = obj_Service.ValidateEmptyString(PAN);
                if (IS_PANEmpty)
                {
                    //arr_EmptyPAN.Add("PAN Field at Row No:" + rowindex + "is empty.");
                    dr_ValidatePan["Name of Column"] = "PAN";
                    dr_ValidatePan["Row No"] = rowindex;
                    dr_ValidatePan["Message"] = "PAN  is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidatePan);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Name Row No
            rowindex = 2;


            foreach (DataRow dr in dt_Deductee.Rows)
            {
                DataRow dr_ValidatePan = dtListError.NewRow();
                string Name_Of_Ddeuctee = dr["NameofEmployee_Party"].ToString();

                //Validate each field one by one and 
                bool IS_NameEmpty = obj_Service.ValidateEmptyString(Name_Of_Ddeuctee);
                if (IS_NameEmpty)
                {
                    // arr_EmptyName.Add("Name Field at Row No:" + rowindex + "is empty.");
                    dr_ValidatePan["Name of Column"] = "Name_of_Deductee ";
                    dr_ValidatePan["Row No"] = rowindex;
                    dr_ValidatePan["Message"] = "Name_Of_Ddeuctee is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidatePan);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Amount Row No
            rowindex = 2;

            foreach (DataRow dr in dt_Deductee.Rows)
            {
                DataRow dr_ValidatePan = dtListError.NewRow();
                string Amount = dr["Amountof_Payment"].ToString();

                //Validate each field one by one and 
                bool IS_AmountEmpty = obj_Service.ValidateEmptyString(Amount);
                if (IS_AmountEmpty)
                {
                    //arr_EmptyAmount.Add("Amount Field at Row No:" + rowindex + "is empty.");
                    dr_ValidatePan["Name of Column"] = "Amount of Payment ";
                    dr_ValidatePan["Row No"] = rowindex;
                    dr_ValidatePan["Message"] = "Amount of Payment is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidatePan);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Amount Row No
            rowindex = 2;

            foreach (DataRow dr in dt_Deductee.Rows)
            {
                DataRow dr_ValidatePan = dtListError.NewRow();
                string TDS = dr["TDS_TCS_IncomeTAX"].ToString();

                //Validate each field one by one and 
                bool IS_AmountEmpty = obj_Service.ValidateEmptyString(TDS);
                if (IS_AmountEmpty)
                {
                    // arr_EmptyTDS.Add("TDS Field at Row No:" + rowindex + "is empty.");
                    dr_ValidatePan["Name of Column"] = "TDS ";
                    dr_ValidatePan["Row No"] = rowindex;
                    dr_ValidatePan["Message"] = "TDS is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidatePan);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Amount Row No
            if (Form != "Form24Q")
            {
                rowindex = 2;

                foreach (DataRow dr in dt_Deductee.Rows)
                {
                    DataRow dr_ValidatePan = dtListError.NewRow();
                    string Rate = dr["RateatWhich_TAXDeducted"].ToString();

                    //Validate each field one by one and 
                    bool IS_RateEmpty = obj_Service.ValidateEmptyString(Rate);
                    if (IS_RateEmpty)
                    {
                        //arr_EmptyRate.Add("Rate Field at Row No:" + rowindex + "is empty.");
                        dr_ValidatePan["Name of Column"] = "Rate";
                        dr_ValidatePan["Row No"] = rowindex;
                        dr_ValidatePan["Message"] = "Rate is empty,please fill. ";
                        dtListError.Rows.Add(dr_ValidatePan);
                    }
                    rowindex = rowindex + 1;

                }
            }

            rowindex = 2;

            foreach (DataRow dr in dt_Deductee.Rows)
            {
                DataRow dr_ValidatePan = dtListError.NewRow();
                string Date = dr["DateOnWhich_AMTPaid"].ToString();

                //Validate each field one by one and 

                bool IS_DateEmpty = obj_Service.ValidateEmptyString(Date);
                if (IS_DateEmpty)
                {
                    //arr_EmptyRate.Add("Date Field at Row No:" + rowindex + "is empty.");
                    dr_ValidatePan["Name of Column"] = "Date";
                    dr_ValidatePan["Row No"] = rowindex;
                    dr_ValidatePan["Message"] = "Date is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidatePan);
                }
                rowindex = rowindex + 1;

            }



        }
        else if (Flag_Operation == "ValidateDateFormat")
        {

        }
        return dtListError;
    }
    public static bool ValiadtePAN(string PANNumber, string DeducteeCode)
    {
        PANNumber = PANNumber.ToUpper();
        bool ISValidPAN = false;
        bool firstfive = false;
        bool nextFour = false;
        bool lastchar = false;
        string Firstfive = string.Empty;
        string NextFour = string.Empty;
        string LastChar = string.Empty;
        string Form_Type = HttpContext.Current.Session["FormType"].ToString();
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
            if (firstfive && nextFour && lastchar || PANNumber == "PANNOTREQD" || PANNumber == "PANNOTAVBL" || PANNumber == "PANAPPLIED")
            {
                if (Form_Type == "Form24Q")
                {
                    if (PANNumber == "PANNOTREQD" || PANNumber == "PANNOTAVBL" || PANNumber == "PANAPPLIED")
                    {
                        ISValidPAN = true;
                    }
                    else
                    {
                        string Char4 = PANNumber.Substring(3, 1);
                        Char4 = Char4.ToUpper();

                        if (Char4 != "P")
                        {
                            ISValidPAN = false;
                        }
                        else
                        {
                            ISValidPAN = true;
                        }
                    }
                }
                else
                {
                    if (PANNumber == "PANNOTREQD" || PANNumber == "PANNOTAVBL" || PANNumber == "PANAPPLIED")
                    {
                        ISValidPAN = true;
                    }
                    else
                    {
                        if (DeducteeCode == "01- Companies")
                        {

                            string Char4 = PANNumber.Substring(3, 1);
                            Char4 = Char4.ToUpper();

                            if (Char4 != "C")
                            {
                                ISValidPAN = false;
                            }
                            else
                            {
                                ISValidPAN = true;
                            }
                        }
                        else if (DeducteeCode == "02- Other than Companies")
                        {
                            string Char4 = PANNumber.Substring(3, 1);
                            Char4 = Char4.ToUpper();
                            Char4 = Char4.TrimStart();
                            Char4 = Char4.TrimEnd();

                            if (Char4 == "P" || Char4 == "H" || Char4 == "F" || Char4 == "A" || Char4 == "T" || Char4 == "B" || Char4 == "L" || Char4 == "J" || Char4 == "G")
                            {
                                ISValidPAN = true;
                            }
                            else
                            {
                                ISValidPAN = false;
                            }
                        }


                    }
                }
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
    //Function to Trace the Error of Challan Data Comuing From exce
    public DataTable Get_Challan_Error_List(DataTable dt_Challan, string Flag_Operation, string Form)
    {
        list.Service objService = new list.Service();
        //Declare Generic List of type string
        DataTable dtListError = new DataTable();
        //Add dataColumn to the DataTable
        //Row No
        DataColumn dt_ColRowNo = new DataColumn("Row No", typeof(string));
        dtListError.Columns.Add(dt_ColRowNo);

        //Field Column
        DataColumn dt_ColField = new DataColumn("Name of Column", typeof(string));
        dtListError.Columns.Add(dt_ColField);


        //Message
        DataColumn dt_Message = new DataColumn("Message", typeof(string));
        dtListError.Columns.Add(dt_Message);


        //Declare Rowindex of the row
        int rowindex = 2;

        if (Flag_Operation == "ValidateBSRCode")
        {
            rowindex = 2;
            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateBSRCode = dtListError.NewRow();
                string BSRCode = dr["Bank_Branch_Code"].ToString();
                bool IsValid = objService.ValidateBSRCodeLenght(BSRCode);
                if (!IsValid)
                {
                    //arrListError.Add("PAN:-" + PAN + "at Row No:" + rowindex + "is not having valid length.");
                    dr_ValidateBSRCode["Name of Column"] = "Bank_Branch_Code";
                    dr_ValidateBSRCode["Row No"] = rowindex;
                    dr_ValidateBSRCode["Message"] = "Bank_Branch_Code" + BSRCode + " is having invalid length,it should be of 7 digits. ";
                    dtListError.Rows.Add(dr_ValidateBSRCode);
                }
                rowindex = rowindex + 1;
            }
        }
        else if (Flag_Operation == "ValidateEmptyField")
        {
            rowindex = 2;
            //Return the Empty ChallanID Row No

            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateChallanID = dtListError.NewRow();
                string ChallanID = dr["ChallanID"].ToString();

                //Validate each field one by one and 
                bool IS_ChallanIDEmpty = obj_Service.ValidateEmptyString(ChallanID);
                if (IS_ChallanIDEmpty)
                {
                    //arr_EmptyPAN.Add("PAN Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateChallanID["Name of Column"] = "ChallanID";
                    dr_ValidateChallanID["Row No"] = rowindex;
                    dr_ValidateChallanID["Message"] = "ChallanID  is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateChallanID);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty TDS Row No
            rowindex = 2;


            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateTDS = dtListError.NewRow();
                string TDS = dr["Oltas_TDS_TCS_IncomeTAX"].ToString();

                //Validate each field one by one and 
                bool IS_TDSEmpty = obj_Service.ValidateEmptyString(TDS);
                if (IS_TDSEmpty)
                {
                    // arr_EmptyName.Add("Name Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateTDS["Name of Column"] = "Oltas_TDS_TCS_IncomeTAX";
                    dr_ValidateTDS["Row No"] = rowindex;
                    dr_ValidateTDS["Message"] = "Oltas_TDS_TCS_IncomeTAX is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateTDS);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Surcharge Row No
            rowindex = 2;

            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateSurcharge = dtListError.NewRow();
                string Surcharge = dr["Oltas_TDS_TCS_Surcharge"].ToString();

                //Validate each field one by one and 
                bool IS_AmountEmpty = obj_Service.ValidateEmptyString(Surcharge);
                if (IS_AmountEmpty)
                {
                    //arr_EmptyAmount.Add("Amount Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateSurcharge["Name of Column"] = "Oltas_TDS_TCS_Surcharge of Payment ";
                    dr_ValidateSurcharge["Row No"] = rowindex;
                    dr_ValidateSurcharge["Message"] = "Oltas_TDS_TCS_Surcharge is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateSurcharge);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Education Cess Row No
            rowindex = 2;

            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateCess = dtListError.NewRow();
                string Cess = dr["Oltas_TDS_TCS_Cess"].ToString();

                //Validate each field one by one and 
                bool IS_ValidateCess = obj_Service.ValidateEmptyString(Cess);
                if (IS_ValidateCess)
                {
                    // arr_EmptyTDS.Add("TDS Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateCess["Name of Column"] = "Oltas_TDS_TCS_Cess ";
                    dr_ValidateCess["Row No"] = rowindex;
                    dr_ValidateCess["Message"] = "Oltas_TDS_TCS_Cess is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateCess);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Oltas_TDS_TCS_InterestAMT Row No

            rowindex = 2;

            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateInterest = dtListError.NewRow();
                string InterestAmt = dr["Oltas_TDS_TCS_InterestAMT"].ToString();

                //Validate each field one by one and 
                bool IS_RateEmpty = obj_Service.ValidateEmptyString(InterestAmt);
                if (IS_RateEmpty)
                {
                    //arr_EmptyRate.Add("Rate Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateInterest["Name of Column"] = "Oltas_TDS_TCS_InterestAMT";
                    dr_ValidateInterest["Row No"] = rowindex;
                    dr_ValidateInterest["Message"] = "Oltas_TDS_TCS_InterestAMT is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateInterest);
                }
                rowindex = rowindex + 1;

            }


            rowindex = 2;

            //Return The Empty Oltas_TDS_TCS_Others Row No

            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateOthers = dtListError.NewRow();
                string Others = dr["Oltas_TDS_TCS_Others"].ToString();

                //Validate each field one by one and 

                bool IS_OthersEmpty = obj_Service.ValidateEmptyString(Others);
                if (IS_OthersEmpty)
                {
                    //arr_EmptyRate.Add("Date Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateOthers["Name of Column"] = "Oltas_TDS_TCS_Others";
                    dr_ValidateOthers["Row No"] = rowindex;
                    dr_ValidateOthers["Message"] = "Oltas_TDS_TCS_Others is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateOthers);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty TotalDepositeAmount Row No
            rowindex = 2;
            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateTotalDepositeAmount = dtListError.NewRow();
                string TotalDepositAmount = dr["TotalDepositeAmount"].ToString();

                //Validate each field one by one and 

                bool IS_OthersEmpty = obj_Service.ValidateEmptyString(TotalDepositAmount);
                if (IS_OthersEmpty)
                {
                    //arr_EmptyRate.Add("Date Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateTotalDepositeAmount["Name of Column"] = "TotalDepositeAmount";
                    dr_ValidateTotalDepositeAmount["Row No"] = rowindex;
                    dr_ValidateTotalDepositeAmount["Message"] = "TotalDepositeAmount is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateTotalDepositeAmount);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Bank_Branch_Code Row No
            rowindex = 2;
            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateBankBranchCode = dtListError.NewRow();
                string BankBranchCode = dr["Bank_Branch_Code"].ToString();

                //Validate each field one by one and 

                bool IS_ChequeDDNoEmpty = obj_Service.ValidateEmptyString(BankBranchCode);
                if (IS_ChequeDDNoEmpty)
                {
                    //arr_EmptyRate.Add("Date Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateBankBranchCode["Name of Column"] = "Bank_Branch_Code";
                    dr_ValidateBankBranchCode["Row No"] = rowindex;
                    dr_ValidateBankBranchCode["Message"] = "Bank_Branch_Code is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateBankBranchCode);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Date_Of_Bank_ChallanNo  Row No
            rowindex = 2;
            foreach (DataRow dr in dt_Challan.Rows)
            {
                DataRow dr_ValidateDate_Of_Bank_ChallanNo = dtListError.NewRow();
                string Date_Of_Bank_ChallanNo = dr["Date_Of_Bank_ChallanNo"].ToString();

                //Validate each field one by one and 

                bool IS_Date_Of_Bank_ChallanNoEmpty = obj_Service.ValidateEmptyString(Date_Of_Bank_ChallanNo);
                if (IS_Date_Of_Bank_ChallanNoEmpty)
                {
                    //arr_EmptyRate.Add("Date Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateDate_Of_Bank_ChallanNo["Name of Column"] = "Date_Of_Bank_ChallanNo";
                    dr_ValidateDate_Of_Bank_ChallanNo["Row No"] = rowindex;
                    dr_ValidateDate_Of_Bank_ChallanNo["Message"] = "Date_Of_Bank_ChallanNo is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateDate_Of_Bank_ChallanNo);
                }
                rowindex = rowindex + 1;

            }

            //Return The Empty Bank_Challan_No  Row No

            rowindex = 2;
            foreach (DataRow dr in dt_Challan.Rows)
            {
                string Book_Entry = dr["By_BookEntry"].ToString();
                if (Book_Entry == "N")
                {
                    DataRow dr_ValidateBank_ChallanNo = dtListError.NewRow();
                    string Bank_ChallanNo = dr["Bank_Challan_No"].ToString();

                    //Validate each field one by one and 

                    bool IS_Bank_ChallanNoEmpty = obj_Service.ValidateEmptyString(Bank_ChallanNo);
                    if (IS_Bank_ChallanNoEmpty)
                    {
                        //arr_EmptyRate.Add("Date Field at Row No:" + rowindex + "is empty.");
                        dr_ValidateBank_ChallanNo["Name of Column"] = "Bank_Challan_No";
                        dr_ValidateBank_ChallanNo["Row No"] = rowindex;
                        dr_ValidateBank_ChallanNo["Message"] = "Bank_Challan_No is empty,please fill. ";
                        dtListError.Rows.Add(dr_ValidateBank_ChallanNo);
                    }
                }
                else if (Book_Entry == "Y")
                {
                    DataRow dr_ValidateDate_Of_TransferVoucher_DDO_SerialNo = dtListError.NewRow();
                    string TransferVoucher_DDO_SerialNo = dr["TransferVoucher_DDO_SerialNo"].ToString();

                    //Validate each field one by one and 

                    bool IS_TransferVoucher_DDO_SerialNoEmpty = obj_Service.ValidateEmptyString(TransferVoucher_DDO_SerialNo);
                    if (IS_TransferVoucher_DDO_SerialNoEmpty)
                    {
                        //arr_EmptyRate.Add("Date Field at Row No:" + rowindex + "is empty.");
                        dr_ValidateDate_Of_TransferVoucher_DDO_SerialNo["Name of Column"] = "TransferVoucher_DDO_SerialNo";
                        dr_ValidateDate_Of_TransferVoucher_DDO_SerialNo["Row No"] = rowindex;
                        dr_ValidateDate_Of_TransferVoucher_DDO_SerialNo["Message"] = "TransferVoucher_DDO_SerialNo is empty,please fill. ";
                        dtListError.Rows.Add(dr_ValidateDate_Of_TransferVoucher_DDO_SerialNo);
                    }
                }
                rowindex = rowindex + 1;

            }
            //Return The Empty By_BookEntry  Row No
            rowindex = 2;
            foreach (DataRow dr in dt_Challan.Rows)
            {

                DataRow dr_ValidateBy_BookEntry = dtListError.NewRow();
                string By_BookEntry = dr["By_BookEntry"].ToString();

                //Validate each field one by one and 

                bool IS_By_BookEntryEmpty = obj_Service.ValidateEmptyString(By_BookEntry);
                if (IS_By_BookEntryEmpty)
                {
                    //arr_EmptyRate.Add("Date Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateBy_BookEntry["Name of Column"] = "Date_Of_Bank_ChallanNo";
                    dr_ValidateBy_BookEntry["Row No"] = rowindex;
                    dr_ValidateBy_BookEntry["Message"] = "Date_Of_Bank_ChallanNo is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateBy_BookEntry);
                }

                rowindex = rowindex + 1;

            }

            //Return The Empty Fee  Row No
            rowindex = 2;
            foreach (DataRow dr in dt_Challan.Rows)
            {

                DataRow dr_ValidateBy_BookEntry = dtListError.NewRow();
                string Fee = dr["Fee"].ToString();

                //Validate each field one by one and 

                bool IS_FeeEmpty = obj_Service.ValidateEmptyString(Fee);
                if (IS_FeeEmpty)
                {
                    //arr_EmptyRate.Add("Date Field at Row No:" + rowindex + "is empty.");
                    dr_ValidateBy_BookEntry["Name of Column"] = "Fee";
                    dr_ValidateBy_BookEntry["Row No"] = rowindex;
                    dr_ValidateBy_BookEntry["Message"] = "Fee is empty,please fill. ";
                    dtListError.Rows.Add(dr_ValidateBy_BookEntry);
                }

                rowindex = rowindex + 1;

            }





        }
        else if (Flag_Operation == "ValidateDateFormat")
        {

        }
        return dtListError;
    }

    public void Build(DataTable dt)
    {
        DataView dv = dt.DefaultView;
        dv.Sort = "[Row No] asc";
        DataTable sortedDT = dv.ToTable();
        StringWriter sw = new StringWriter();
        HtmlTextWriter w = new HtmlTextWriter(sw);

        //Create a table

        System.Web.UI.WebControls.Table tbl = new System.Web.UI.WebControls.Table();
        tbl.Attributes.Add("border", "1");
        tbl.CellPadding = 1;
        tbl.CellSpacing = 1;

        //Create column header row
        TableHeaderRow thr = new TableHeaderRow();
        foreach (DataColumn col in sortedDT.Columns)
        {
            TableHeaderCell th = new TableHeaderCell();
            th.Text = col.Caption;
            thr.Controls.Add(th);
        }
        tbl.Controls.Add(thr);

        //Create table rows
        foreach (DataRow row in sortedDT.Rows)
        {
            TableRow tr = new TableRow();
            foreach (var value in row.ItemArray)
            {
                TableCell td = new TableCell();
                td.HorizontalAlign = HorizontalAlign.Center;
                td.Text = value.ToString();
                tr.Controls.Add(td);
            }
            tbl.Controls.Add(tr);
        }

        tbl.RenderControl(w);
        string tab = "\t";

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.Append(tab + "<head>");
        sb.Append(tab + "<center><h3>ERROR LIST OF ERRORS COMING ON IMPORTING EXCEL FILE</h3></center>");
        sb.Append(tab + "</head>");
        sb.AppendLine(tab + "<body>");
        sb.AppendLine(tab + "<center>");
        sb.AppendLine(sw.ToString());
        sb.AppendLine(tab + "</center>");
        sb.AppendLine("</html>");
        sb.AppendLine(tab + "</body>");

        //Write all the Content to Text File

        string Path_Html = Server.MapPath("~/FileFormat/ErrorList.htm");
        System.IO.File.WriteAllText(Path_Html, sb.ToString());
        //Save as Excel File
        //System.Diagnostics.Process.Start(Path_Html);
        Response.ContentType = "text/plain";

        Response.AppendHeader("Content-Disposition", "attachment; filename=ErrorList.htm");
        Page.Response.WriteFile(Path_Html);
        Response.End();
        //Response.Write(sw.ToString());
    }
    public void Read_Data_From_Xml(string File_Name)
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(File_Name);
        string value = xmldoc.SelectSingleNode("//simpleType[key = 'restriction']/value").InnerText;
    }
    #endregion

    protected void btnback_Click(object sender, EventArgs e)
    {
        if (Session["Regular_Correction"].ToString() == "Correction_Import")
        {
            Response.Redirect("tds.aspx");
        }
        else
        {
            Response.Redirect("Salary.aspx?vtype=3001");
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

}
