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
using ClosedXML.Excel;
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

public partial class UserControls_ExportToExcel : System.Web.UI.UserControl
{
    #region Declaration
    //public event EventHandler rdl_Receipt;
    //public event EventHandler btnSubmit;
    //public event EventHandler btnClose;

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

    public static int ChallanCounter = 2;
    public static int DeductorCounter = 2;
    public static int DeducteeCounter = 2;
    public static int SalaryCounter = 2;
    public static int Count_Search_Deductee = 0;
    public static int Excel_Index = 0;

    #endregion

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
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        strConnName = Application["DBEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[Application["DBEngine3"].ToString()].ConnectionString;

        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;
        DynamicControl.Project_Name = "TDS," + ApplicationHost + "," + Leftpath;


        objBSRcode = new BSRCodes(strConnectionString, strConnName);
        objCreateFile = new CreateFile(strConnectionString, strConnName);

        objBltbl_ChallanDetails = new Bltbl_ChallanDetails(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_ChallanDetails = new tbl_ChallanDetails();


        objBltbl_DeducteeDetails = new Bltbl_DeducteeDetail(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_DeducteeDetails = new tbl_DeducteeDetail();

        objBltbl_SalaryDetails = new Bltbl_SalaryDetails(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_SalaryDetails = new tbl_SalaryDetails();

        objBltbl_Form = new Bltbl_Form(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_Form = new tbl_Form();

        objBltbl_BatchHeader = new Bltbl_BatchHeader(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_BatchHeader = new tbl_BatchHeader();

        objBltbl_16A = new Bltbl_16A(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_16A = new tbl_16A();

        objBltbl_BSRCode = new Bltbl_BSRCode(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_BSRCode = new tbl_BSRCode();

        objBltbl_SectionVI_A = new Bltbl_SectionVI_A(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_SectionVI_A = new tbl_SectionVI_A();

        objBltbl_TANMaster = new Bltbl_TANMaster(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_TANMaster = new tbl_TANMaster();

        objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_FileHeader = new tbl_FileHeader();

        objBltbl_ChallanDetails_Correction = new Bltbl_ChallanDetails_Correction(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_ChallanDetails_Correction = new tbl_ChallanDetails_Correction();

        //Intialize the Object For InterFace_By_Role
        objBltbl_Interface_By_Role = new Bltbl_Interface_By_Role(strConnectionString_Admin, strConnName_Admin, strConnectionString_Admin);
        objtbl_Interface_By_Role = new tbl_Interface_By_Role();

        objBltbl_BatchHeader_Correction = new Bltbl_BatchHeader_Correction(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_BatchHeader_Correction = new tbl_BatchHeader_Correction();

        objBltbl_DeducteeDetails_Correction = new Bltbl_DeducteeDetails_Correction(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_DeducteeDetails_Correction = new tbl_DeducteeDetails_Correction();

        objBltbl_CreateFile = new Bltbl_CreateFile(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_CreateFile = new tbl_CreateFile();


        objBltbl_CreateFile_Correction = new Bltbl_CreateFile_Correction(strConnectionString, strConnName,strConnectionString_Admin);
        objtbl_CreateFile_Correction = new tbl_CreateFile_Correction();

        //Intialize the Object For File Header Correction
        objBltbl_FileHeader_Correction = new Bltbl_FileHeader_Correction(strConnectionString, strConnName,strConnectionString_Admin);
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
        objdbtbl_Module = new DBtbl_Module(strConnectionString, strConnName,strConnectionString_Admin);
        if (!Page.IsPostBack)
        {
            //ExportToExcel();
        }
        btnExportToExcel_Click(btnExportToExcel,null);
        Response.Redirect("DisplayForm.aspx");
    }
    public void ExportToExcel()
    {
        string FormType = Session["FormType"].ToString();
        string Template_Name = string.Empty;
        string FilePath = Server.MapPath("~/ExcelSheetTemplate/");
        DeducteeCounter = 2;
        DeductorCounter = 2;
        ChallanCounter = 2;
        SalaryCounter = 2;
        Excel_Index = 0;
        DataSet ds_Excel = new DataSet();
        //Create Parameters
        string TAN = Session["TAN"].ToString();
        string Quarter = Session["qtr"].ToString();
        string FinancialYear = Session["FY"].ToString().Replace("-20", "");
        string FormNo = Session["FormType"].ToString();
        string Regular_Correction = "Regular";

        string Name = Session["Name"].ToString();

        objtbl_ChallanDetails.TAN = TAN;
        objtbl_ChallanDetails.Quarter = Quarter;
        objtbl_ChallanDetails.FinancialYear = FinancialYear;
        objtbl_ChallanDetails.FormType = FormNo;
        objtbl_ChallanDetails.Regular_Correction = Regular_Correction;
        int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);

        //Get the FileName
        if (FormType == "Form24Q")
        {
            Template_Name = "Template24";
        }
        else if (FormType == "Form27Q" || FormType == "Form26Q")
        {
            Template_Name = "Template27and26New";
        }
        else if (FormType == "Form27EQ")
        {
            Template_Name = "Template27EQ";
        }
        //Get the CurrentDirectoryPath
        string Current_Directory_Path = Server.MapPath("~/ExcelSheetTemplate/");
        //Create the FinalNameof File
        string Final_FileName_With_Path = string.Format("{0}\\{1}.xlsx", Current_Directory_Path, Template_Name);

        //Create ConnectionString Name to Get the SheetName From Template
        //string strConnectionString = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Final_FileName_With_Path + ";"Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\";
        string strConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Final_FileName_With_Path + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";
        //string strConnectionString=@"Driver={Microsoft Excel Driver (*.xls)};DriverId=790;Dbq="+ Final_FileName_With_Path+";DefaultDir="+Current_Directory_Path+";";
        //string strConnectionString=@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Final_FileName_With_Path+";Extended Properties=Excel 8.0;HDR=Yes;IMEX=1;";
        OleDbConnection con = new OleDbConnection(strConnectionString);
        //Open the Connection Here.
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        //Declare the DataTables We are using.
        System.Data.DataTable dt_DeductorType = new System.Data.DataTable();
        System.Data.DataTable dt_ChallanDetails = new System.Data.DataTable();
        System.Data.DataTable dt_DeducteeDetails = new System.Data.DataTable();

        System.Data.DataTable dt_Refresh = new System.Data.DataTable();

        //Create a string array of the SheetNames.
        String[] ExcelSheetName = GetExcelSheetName(con);
        con.Close();
        string SheetName = string.Empty;
        //var ExistingFile = new FileInfo(Final_FileName_With_Path);
        //var ExistingFile = new FileStream(Final_FileName_With_Path,FileMode.Open);
        var wb = new XLWorkbook();
        int FY = Convert.ToInt32(FinancialYear);

        string currentSheet = string.Empty;

        for (int i = 0; i < ExcelSheetName.Length; i++)
        {

            SheetName = ExcelSheetName[i].ToString();
            if (SheetName == "'DEDUCTORS DETAIL$'")
            {

                currentSheet = @"DEDUCTORS DETAIL";
                //var package = new ExcelPackage(ExistingFile);


                ////Create Object of the Current Sheet in Excel
                //ExcelWorksheet worksheet = package.Workbook.Worksheets[currentSheet];
                string FieldName = "TAN";
                string FieldValue = Session["TAN"].ToString();
                dt_DeductorType = GetDeductorDetail_ForExcel(FieldName, FieldValue);
                dt_Refresh = dt_DeductorType;
                DataTable dt_Deductor = WriteSheet(dt_DeductorType, Final_FileName_With_Path, SheetName, FilePath, FormType, con);
                //var ws = wb.Worksheets.Add("'DEDUCTORS DETAIL$'");
                //ws.Cell("A1").InsertTable(dt_Deductor);

                wb.Worksheets.Add(dt_Deductor, "DEDUCTORS DETAIL");


                //worksheet.Cells.Clear();
                //worksheet.Cells.LoadFromDataTable(dt_Deductor,true,TableStyles.None);
                //package.Save();
                //package.Dispose();
                //ds_Excel.Tables.Add(dt_Deductor);
                //ds_Excel.Tables[Excel_Index].TableName = SheetName;
                //Excel_Index = Excel_Index + 1;


            }
            else if (SheetName == "'CHALLAN DETAIL$'")
            {
                currentSheet = @"CHALLAN DETAIL";
                //var package = new ExcelPackage(ExistingFile);
                //ExcelWorksheet worksheet = package.Workbook.Worksheets[currentSheet];

                // var counts = worksheet.Dimension.End.Row;
                //worksheet.DeleteRow(2, counts);


                // OdbcDataAdapter da = GetChallanDetail_ForExcel();
                dt_ChallanDetails = GetChallanDetail_ForExcel();
                //dt_ChallanDetails.TableName = "ChallanDetails";
                dt_Refresh = dt_ChallanDetails;
                DataTable dt_Challan = WriteSheet(dt_ChallanDetails, Final_FileName_With_Path, SheetName, FilePath, FormType, con);
                var ws = wb.Worksheets.Add(dt_Challan, "CHALLAN DETAIL");
                //Add the Sum Formula to the Total Deposit Amount
                var rngData = ws.Range(2, 8, 5000, 8);
                rngData.FormulaR1C1 = "=SUM(RC[-5]:RC[-1])";
                ws.Columns().AdjustToContents();
                wb.ReferenceStyle = XLReferenceStyle.R1C1;
                wb.CalculateMode = XLCalculateMode.Auto;
                //Implement the Protection on the Columns of Challan Sheet

                //Select all the Columns in the Challan Sheet.
                ws.Columns(1, 16).Style.Protection.SetLocked(false);

                //Columns which will Always Remain Protected
                ws.Column(8).Style.Protection.SetLocked(true);
                //Column which will Remain Locked Conditionally

                if (FY < 201314)
                {
                    //Lock Section Code Field
                    ws.Column(2).Style.Protection.SetLocked(false);
                    //Lock Minor Head Challan
                    ws.Column(16).Style.Protection.SetLocked(true);
                }
                else
                {
                    //Unlock Section Code Field
                    ws.Column(2).Style.Protection.SetLocked(true);
                    //Unlock Minor Head Challan
                    ws.Column(16).Style.Protection.SetLocked(false);

                }

                if (FY < 201213)
                {
                    //Lock Fee Field
                    ws.Column(15).Style.Protection.SetLocked(true);
                }
                else
                {
                    //Unlock Fee Field
                    ws.Column(15).Style.Protection.SetLocked(false);
                }

                ws.Protect().SetSelectLockedCells(true);
                ws.Column(1).Style.NumberFormat.Format = "0";
                ws.Column(3).Style.NumberFormat.Format = "0.00";
                ws.Column(4).Style.NumberFormat.Format = "0.00";
                ws.Column(5).Style.NumberFormat.Format = "0.00";
                ws.Column(6).Style.NumberFormat.Format = "0.00";
                ws.Column(7).Style.NumberFormat.Format = "0.00";
                ws.Column(8).Style.NumberFormat.Format = "0.00";
                ws.Column(9).Style.NumberFormat.Format = "@";
                ws.Column(15).Style.NumberFormat.Format = "0.00";
                ws.Column(16).Style.NumberFormat.Format = "0";
                ws.Column(10).Style.NumberFormat.Format = "@";
                ws.Column(11).Style.NumberFormat.Format = "@";
                ws.Column(12).Style.NumberFormat.Format = "@";
                ws.Column(9).Style.NumberFormat.Format = "@";
                ws.Column(15).Style.NumberFormat.Format = "@";
                ws.Column(16).Style.NumberFormat.Format = "@";






            }
            else if (SheetName == "DEDUCTEEDETAIL$")
            {
                currentSheet = @"DEDUCTEEDETAIL";
                //Create Object of the Current Sheet in Excel
                //var package = new ExcelPackage(ExistingFile);
                //ExcelWorksheet worksheet = package.Workbook.Worksheets[currentSheet];
                //var counts = worksheet.Dimension.End.Row;
                //worksheet.DeleteRow(2, counts);

                int ChallanID = 0;
                DataTable dt_ID = new DataTable();
                objtbl_ChallanDetails.ID = MasterID;
                objtbl_ChallanDetails.Regular_Correction = Regular_Correction;
                dt_ID = objBltbl_ChallanDetails.Get_ChallanID(objtbl_ChallanDetails);
                int count = Convert.ToInt32(dt_ID.Rows.Count);
                DataTable dt_Deductee = new DataTable();



                //ChallanID = Convert.ToInt32(dt_ID.Rows[j]["ChallanID"]);
                dt_DeducteeDetails = GetDeducteeDetail_ForExcel(MasterID);
                dt_Refresh = dt_DeducteeDetails;
                dt_Deductee = WriteSheet(dt_DeducteeDetails, Final_FileName_With_Path, SheetName, FilePath, FormType, con);



                var ws = wb.Worksheets.Add(dt_Deductee, "DEDUCTEEDETAIL");

                //ws.Column(14).DataType = XLCellValues.Text;

                //Code to Implement the Protections on the Columns
                if (FormType == "Form26Q" || FormType == "Form27Q")
                {

                    var rngData = ws.Range(2, 15, 5000, 15);
                    rngData.FormulaR1C1 = "=RC[-7]";

                    var rngData2 = ws.Range(2, 14, 5000, 14);
                    rngData2.FormulaR1C1 = "=SUM(RC[-3]:RC[-1])";
                    ws.Columns(1, 21).Style.Protection.SetLocked(false);

                    //Columns That will be Permanently Locked
                    ws.Column(13).Style.Protection.SetLocked(true);
                    ws.Column(14).Style.Protection.SetLocked(true);
                    //Columns That will be Locked Conditionally
                    if (FY < 201314)
                    {
                        ws.Column(16).Style.Protection.SetLocked(true);
                        ws.Column(17).Style.Protection.SetLocked(true);
                        ws.Column(18).Style.Protection.SetLocked(true);
                        ws.Column(19).Style.Protection.SetLocked(true);
                        ws.Column(20).Style.Protection.SetLocked(true);
                        ws.Column(21).Style.Protection.SetLocked(true);


                    }
                    else
                    {
                        ws.Column(16).Style.Protection.SetLocked(false);
                        ws.Column(17).Style.Protection.SetLocked(false);
                        ws.Column(18).Style.Protection.SetLocked(false);
                        ws.Column(19).Style.Protection.SetLocked(false);
                        ws.Column(20).Style.Protection.SetLocked(false);
                        ws.Column(21).Style.Protection.SetLocked(false);
                        if (FormType == "Form27EQ")
                        {
                            ws.Column(17).Style.Protection.SetLocked(false);
                            ws.Column(18).Style.Protection.SetLocked(false);
                            ws.Column(19).Style.Protection.SetLocked(false);
                            ws.Column(20).Style.Protection.SetLocked(false);
                            ws.Column(21).Style.Protection.SetLocked(false);
                        }

                    }
                    //Set the Number Format on the Number Columns
                    ws.Column(1).Style.NumberFormat.Format = "0";
                    ws.Column(2).Style.NumberFormat.Format = "0";
                    ws.Column(3).Style.NumberFormat.Format = "@";
                    ws.Column(5).Style.NumberFormat.Format = "0000000000";
                    ws.Column(7).Style.NumberFormat.Format = "0.00";
                    ws.Column(8).Style.NumberFormat.Format = "dd/MM/yyyy";
                    ws.Column(9).Style.NumberFormat.Format = "0.0000";

                    ws.Column(11).Style.NumberFormat.Format = "0.00";
                    ws.Column(12).Style.NumberFormat.Format = "0.00";
                    ws.Column(13).Style.NumberFormat.Format = "0.00";
                    ws.Column(14).Style.NumberFormat.Format = "0.00";
                    ws.Column(15).Style.NumberFormat.Format = "dd/MM/yyyy";




                }
                else if (FormType == "Form24Q")
                {
                    var rngData = ws.Range(2, 11, 5000, 11);
                    rngData.FormulaR1C1 = "=RC[-6]";

                    var rngData2 = ws.Range(2, 10, 5000, 10);
                    rngData2.FormulaR1C1 = "=SUM(RC[-3]:RC[-1])";
                    ws.Columns(1, 19).Style.Protection.SetLocked(false);

                    //Columns That will be Permanently Locked
                    ws.Column(10).Style.Protection.SetLocked(true);
                    ws.Column(11).Style.Protection.SetLocked(true);
                    //Columns That will be Locked Conditionally
                    if (FY < 201314)
                    {
                        ws.Column(14).Style.Protection.SetLocked(true);
                        ws.Column(15).Style.Protection.SetLocked(true);
                        ws.Column(16).Style.Protection.SetLocked(true);
                        ws.Column(17).Style.Protection.SetLocked(true);
                        ws.Column(18).Style.Protection.SetLocked(true);
                        ws.Column(19).Style.Protection.SetLocked(true);

                    }
                    else
                    {
                        ws.Column(14).Style.Protection.SetLocked(false);
                        if (FormType == "Form27EQ")
                        {
                            ws.Column(15).Style.Protection.SetLocked(false);
                            ws.Column(16).Style.Protection.SetLocked(false);
                            ws.Column(17).Style.Protection.SetLocked(false);
                            ws.Column(18).Style.Protection.SetLocked(false);
                            ws.Column(19).Style.Protection.SetLocked(false);
                        }
                        else
                        {
                            ws.Column(15).Style.Protection.SetLocked(true);
                            ws.Column(16).Style.Protection.SetLocked(true);
                            ws.Column(17).Style.Protection.SetLocked(true);
                            ws.Column(18).Style.Protection.SetLocked(true);
                            ws.Column(19).Style.Protection.SetLocked(true);
                        }
                    }
                    //Set the Number Format on the Number Columns
                    ws.Column(1).Style.NumberFormat.Format = "0";
                    ws.Column(2).Style.NumberFormat.Format = "0"; ;
                    ws.Column(5).Style.NumberFormat.Format = "@";
                    ws.Column(6).Style.NumberFormat.Format = "0.00";
                    ws.Column(7).Style.NumberFormat.Format = "0.00";
                    ws.Column(8).Style.NumberFormat.Format = "0.00";
                    ws.Column(9).Style.NumberFormat.Format = "0.00";
                    ws.Column(10).Style.NumberFormat.Format = "0.00";
                    ws.Column(11).Style.NumberFormat.Format = "@";







                }
                else if (FormType == "Form27EQ")
                {
                    var rngData = ws.Range(2, 16, 5000, 16);
                    rngData.FormulaR1C1 = "=RC[-7]";

                    var rngData2 = ws.Range(2, 15, 5000, 15);
                    rngData2.FormulaR1C1 = "=SUM(RC[-3]:RC[-1])";

                    ws.Columns(1, 22).Style.Protection.SetLocked(false);

                    //Columns That will be Permanently Locked
                    ws.Column(14).Style.Protection.SetLocked(true);
                    ws.Column(15).Style.Protection.SetLocked(true);
                    //Columns That will be Locked Conditionally
                    if (FY < 201314)
                    {
                        ws.Column(17).Style.Protection.SetLocked(true);
                        ws.Column(18).Style.Protection.SetLocked(true);
                        ws.Column(19).Style.Protection.SetLocked(true);
                        ws.Column(20).Style.Protection.SetLocked(true);
                        ws.Column(21).Style.Protection.SetLocked(true);
                        ws.Column(22).Style.Protection.SetLocked(true);

                    }
                    else
                    {
                        ws.Column(17).Style.Protection.SetLocked(false);
                        if (FormType == "Form27EQ")
                        {
                            ws.Column(18).Style.Protection.SetLocked(false);
                            ws.Column(19).Style.Protection.SetLocked(false);
                            ws.Column(20).Style.Protection.SetLocked(false);
                            ws.Column(21).Style.Protection.SetLocked(false);
                            ws.Column(22).Style.Protection.SetLocked(false);
                        }
                        else
                        {
                            ws.Column(18).Style.Protection.SetLocked(true);
                            ws.Column(19).Style.Protection.SetLocked(true);
                            ws.Column(20).Style.Protection.SetLocked(true);
                            ws.Column(21).Style.Protection.SetLocked(true);
                            ws.Column(22).Style.Protection.SetLocked(true);
                        }
                    }

                    //Set the Number Format on the Number Columns
                    ws.Column(1).Style.NumberFormat.Format = "0";
                    ws.Column(2).Style.NumberFormat.Format = "0";
                    ws.Column(3).Style.NumberFormat.Format = "@";
                    ws.Column(5).Style.NumberFormat.Format = "0000000000";
                    ws.Column(6).Style.NumberFormat.Format = "0.00";
                    ws.Column(7).Style.NumberFormat.Format = "0.00";
                    ws.Column(8).Style.NumberFormat.Format = "@";
                    ws.Column(9).Style.NumberFormat.Format = "0.0000";
                    ws.Column(11).Style.NumberFormat.Format = "0.00";
                    ws.Column(12).Style.NumberFormat.Format = "0.00";
                    ws.Column(13).Style.NumberFormat.Format = "0.00";
                    ws.Column(14).Style.NumberFormat.Format = "0.00";
                    ws.Column(15).Style.NumberFormat.Format = "@";




                }
                ws.Protect().SetSelectLockedCells(true);
                wb.ReferenceStyle = XLReferenceStyle.R1C1;
                wb.CalculateMode = XLCalculateMode.Auto;


            }
            else if (FormType == "Form24Q" && Quarter == "Q4" && SheetName == "'SALARY DETAIL$'")
            {
                currentSheet = @"SALARY DETAIL";
                ////Create Object of the Current Sheet in Excel

                int ChallanID = 0;
                DataTable dt_ID = new DataTable();
                objtbl_SalaryDetails.ID = MasterID;
                dt_ID = objBltbl_SalaryDetails.GetIDAdminTable(objtbl_SalaryDetails);


                System.Data.DataTable dt_SalaryDetails = new System.Data.DataTable();


                int IDAdmin = Convert.ToInt32(dt_ID.Rows[0]["ID_Admin"]);

                dt_SalaryDetails = GetSalaryDetail_ForExcel(IDAdmin);
                dt_Refresh = dt_SalaryDetails;
                WriteSheet(dt_SalaryDetails, Final_FileName_With_Path, SheetName, FilePath, FormType, con);




                wb.Worksheets.Add(dt_SalaryDetails, "SALARY DETAIL");

            }

        }
        string Path_Excel = Server.MapPath(@"~\Upload\" + Name + ".xlsx");
        Session["Path_Excel"] = Path_Excel;
        wb.SaveAs(Path_Excel);
        wb.Dispose();



        //Save as Excel File
        //string Extension = Path.GetExtension(Path_Excel);
        //string type = string.Empty;
        //if (Extension.ToLower() == ".xls")
        //{
        //    type = "application/msexcel";
        //}
        //else if (Extension.ToLower() == ".xlsx")
        //{
        //    type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //}
        Response.Redirect("XMLRestore.aspx");

        //Response.ContentType = type;
        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Name + ".xlsx");
        //Page.Response.WriteFile(Path_Excel);
        //Response.End();

        //drp_TaxDepositedBookEntry.Focus();



    }
    //Function to Get the Name of the Sheet in Excel File
    public String[] GetExcelSheetName(OleDbConnection con)
    {

        System.Data.DataTable dt = new System.Data.DataTable();
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
    public System.Data.DataTable GetDeductorDetail_ForExcel(string FieldName, string FieldValue)
    {
        dt = new DataTable();
        //Create Parameters 
        objtbl_TANMaster.FieldName = FieldName;
        objtbl_TANMaster.FieldValue = FieldValue;
        dt = objBltbl_TANMaster.FillRecordsTable(objtbl_TANMaster);
        return dt;
    }
    public DataTable WriteSheet(DataTable dt, string Template_Name, string SheetName, string FilePath, string FormNo, OleDbConnection con)
    {
        //Open Workbook and add data to cells

        var ExistingFile = new FileInfo(Template_Name);
        DataTable dt_Excel_Sheet = new DataTable();

        //Get the Count of Number of Records in DataTable

        if (SheetName == "'CHALLAN DETAIL$'")
        {
            //Add the Excel template to the DataTable
            dt_Excel_Sheet = GetExcelSheetTemplate(con, SheetName);
            if (FormNo == "Form27Q" || FormNo == "Form26Q" || FormNo == "Form27EQ")
            {
                dt_Excel_Sheet = dt.DefaultView.ToTable(false,
                    "ChallanID",
                    "Section",
                    "Oltas_TDS_TCS_IncomeTAX",
                    "Oltas_TDS_TCS_Surcharge",
                    "Oltas_TDS_TCS_Cess",
                    "Oltas_TDS_TCS_InterestAMT",
                    "Oltas_TDS_TCS_Others",
                    "TotalDepositeAmount",
                    "Cheque_DD_No",
                    "Bank_Branch_Code",
                    "Date_Of_Bank_ChallanNo",
                    "Bank_Challan_No",
                    "TransferVoucher_DDO_SerialNo",
                    "By_BookEntry",
                    "Fee",
                    "Minor_Head_of_Challan"
                    );
            }
            else
            {
                dt_Excel_Sheet = dt.DefaultView.ToTable(false,
                   "ChallanID",
                   "Section",
                   "Oltas_TDS_TCS_IncomeTAX",
                   "Oltas_TDS_TCS_Surcharge",
                   "Oltas_TDS_TCS_Cess",
                   "Oltas_TDS_TCS_InterestAMT",
                   "Oltas_TDS_TCS_Others",
                   "TotalDepositeAmount",
                   "Cheque_DD_No",
                   "Bank_Branch_Code",
                   "Date_Of_Bank_ChallanNo",
                   "Bank_Challan_No",
                   "TransferVoucher_DDO_SerialNo",
                   "By_BookEntry",
                     "Fee",
                    "Minor_Head_of_Challan"
                   );
            }




        }
        else if (SheetName == "DEDUCTEEDETAIL$")
        {
            dt_Excel_Sheet = GetExcelSheetTemplate(con, SheetName);

            if (FormNo == "Form27EQ")
            {
                dt_Excel_Sheet = dt.DefaultView.ToTable(false,
                                "ID",
                                "DeducteeID",
                                "Deductee_PartyCode",
                                "EmployeePAN",
                                "PAN_RefNO",
                                "NameofEmployee_Party",
                                "Total_ValuePurchase",
                                "Amountof_Payment",
                                "DateOnWhich_AMTPaid",
                                "RateatWhich_TAXDeducted",
                                "BookEntry_CashIndicator",
                                "TDS_TCS_IncomeTAX",
                                "TDS_TCS_Surcharge",
                                "TDS_TCS_Cess",
                                "Total_TaxDeposited",
                                "DateonWhich_TaxDeducted",
                                "Reason_For_NonDeduction",
                                "Section_Code",
                                "Certificate_Number",
                                "WhetherTDSRateofTDSIsITAct27",
                                "Nature_of_Remittance_27",
                                "Unique_formno_15CA_27",
                                "Country_to_which_remittance_is_made_27"

                                );
            }
            else if (FormNo == "Form26Q" || FormNo == "Form27Q")
            {
                dt_Excel_Sheet = dt.DefaultView.ToTable(false,
                "ID",
                "DeducteeID",
                "Deductee_PartyCode",
                "EmployeePAN",
                "PAN_RefNO",
                "NameofEmployee_Party",
                "Amountof_Payment",
                "DateOnWhich_AMTPaid",
                "RateatWhich_TAXDeducted",
                "BookEntry_CashIndicator",
                "TDS_TCS_IncomeTAX",
                "TDS_TCS_Surcharge",
                "TDS_TCS_Cess",
                "Total_TaxDeposited",
                "DateonWhich_TaxDeducted",
                "Reason_For_NonDeduction",
                "Section_Code",
                "Certificate_Number",
                "WhetherTDSRateofTDSIsITAct27",
                "Nature_of_Remittance_27",
                "Unique_formno_15CA_27",
                "Country_to_which_remittance_is_made_27"
                );
            }
            else if (FormNo == "Form24Q")
            {
                dt_Excel_Sheet = dt.DefaultView.ToTable(false,
                        "ID",
                        "DeducteeID",
                        "EmployeePAN",
                        "NameofEmployee_Party",
                        "DateOnWhich_AMTPaid",
                       "Amountof_Payment",
                        "TDS_TCS_IncomeTAX",
                        "TDS_TCS_Surcharge",
                        "TDS_TCS_Cess",
                        "Total_TaxDeposited",
                        "DateonWhich_TaxDeducted",
                        "BookEntry_CashIndicator",
                        "Reason_For_NonDeduction",
                        "Section_Code",
                        "Certificate_Number",
                        "WhetherTDSRateofTDSIsITAct27",
                        "Nature_of_Remittance_27",
                        "Unique_formno_15CA_27",
                        "Country_to_which_remittance_is_made_27"
                        );


            }



        }
        else if (SheetName == "'DEDUCTORS DETAIL$'")
        {
            DataTable dt_Deductor_Excel = GetExcelSheetTemplate(con, SheetName);

            dt_Deductor_Excel.Rows[0]["Deductor Info"] = dt.Rows[0]["TAN"].ToString();
            dt_Deductor_Excel.Rows[1]["Deductor Info"] = FormNo;

            dt_Deductor_Excel.Rows[2]["Deductor Info"] = Session["AY"].ToString();

            dt_Deductor_Excel.Rows[3]["Deductor Info"] = Session["qtr"].ToString();

            dt_Deductor_Excel.Rows[4]["Deductor Info"] = dt.Rows[0]["PAN"].ToString();

            dt_Deductor_Excel.Rows[5]["Deductor Info"] = dt.Rows[0]["AName"].ToString();

            dt_Deductor_Excel.Rows[6]["Deductor Info"] = dt.Rows[0]["Branch"].ToString();

            dt_Deductor_Excel.Rows[7]["Deductor Info"] = dt.Rows[0]["AFlat"].ToString();

            dt_Deductor_Excel.Rows[8]["Deductor Info"] = dt.Rows[0]["APremises"].ToString();

            dt_Deductor_Excel.Rows[9]["Deductor Info"] = dt.Rows[0]["ARoad"].ToString();

            dt_Deductor_Excel.Rows[10]["Deductor Info"] = dt.Rows[0]["AArea"].ToString();

            dt_Deductor_Excel.Rows[11]["Deductor Info"] = dt.Rows[0]["ATown"].ToString();

            dt_Deductor_Excel.Rows[12]["Deductor Info"] = dt.Rows[0]["AState"].ToString();

            dt_Deductor_Excel.Rows[13]["Deductor Info"] = dt.Rows[0]["APINCode"].ToString();

            dt_Deductor_Excel.Rows[14]["Deductor Info"] = dt.Rows[0]["AEmail"].ToString();

            dt_Deductor_Excel.Rows[15]["Deductor Info"] = dt.Rows[0]["ASTDCode"].ToString();

            dt_Deductor_Excel.Rows[16]["Deductor Info"] = dt.Rows[0]["APhone"].ToString();

            dt_Deductor_Excel.Rows[17]["Deductor Info"] = "N";

            dt_Deductor_Excel.Rows[19]["Deductor Info"] = dt.Rows[0]["Type"].ToString();

            dt_Deductor_Excel.Rows[19]["Deductor Info"] = dt.Rows[0]["PName"].ToString();

            dt_Deductor_Excel.Rows[20]["Deductor Info"] = "";

            dt_Deductor_Excel.Rows[21]["Deductor Info"] = dt.Rows[0]["PDesig"].ToString();

            dt_Deductor_Excel.Rows[22]["Deductor Info"] = dt.Rows[0]["PFlat"].ToString();

            dt_Deductor_Excel.Rows[23]["Deductor Info"] = dt.Rows[0]["PPremises"].ToString();

            dt_Deductor_Excel.Rows[24]["Deductor Info"] = dt.Rows[0]["PRoad"].ToString();

            dt_Deductor_Excel.Rows[25]["Deductor Info"] = dt.Rows[0]["PArea"].ToString();

            dt_Deductor_Excel.Rows[26]["Deductor Info"] = dt.Rows[0]["PTown"].ToString();

            dt_Deductor_Excel.Rows[27]["Deductor Info"] = dt.Rows[0]["PState"].ToString();

            dt_Deductor_Excel.Rows[28]["Deductor Info"] = dt.Rows[0]["PPINCode"].ToString();

            dt_Deductor_Excel.Rows[29]["Deductor Info"] = dt.Rows[0]["PEmail"].ToString();

            dt_Deductor_Excel.Rows[30]["Deductor Info"] = dt.Rows[0]["PSTDCode"].ToString();

            dt_Deductor_Excel.Rows[31]["Deductor Info"] = dt.Rows[0]["PPhone"].ToString();

            dt_Deductor_Excel.Rows[32]["Deductor Info"] = dt.Rows[0]["MobileNumber"].ToString();

            dt_Deductor_Excel.Rows[33]["Deductor Info"] = "N";

            dt_Deductor_Excel.Rows[34]["Deductor Info"] = dt.Rows[0]["PAOCode"].ToString();

            dt_Deductor_Excel.Rows[35]["Deductor Info"] = dt.Rows[0]["DDOCode"].ToString();

            dt_Deductor_Excel.Rows[36]["Deductor Info"] = dt.Rows[0]["MinistryName"].ToString();

            dt_Deductor_Excel.Rows[37]["Deductor Info"] = dt.Rows[0]["MinistryCode"].ToString();

            dt_Deductor_Excel.Rows[38]["Deductor Info"] = dt.Rows[0]["PAORegNo"].ToString();

            dt_Excel_Sheet = dt_Deductor_Excel;

        }


        return dt_Excel_Sheet;

    }
    public DataTable GetChallanDetail_ForExcel()
    {
        ////Create Parameters
        objtbl_ChallanDetails.TAN = Session["TAN"].ToString();
        objtbl_ChallanDetails.FinancialYear = Session["FY"].ToString().Replace("-20", "");
        objtbl_ChallanDetails.Quarter = Session["qtr"].ToString();
        objtbl_ChallanDetails.FormType = Session["FormType"].ToString();
        objtbl_ChallanDetails.Regular_Correction = "Regular";
        dt = objBltbl_ChallanDetails.GetChallanData(objtbl_ChallanDetails);
        return dt;
    }
    public System.Data.DataTable GetDeducteeDetail_ForExcel(int MasterID)
    {
        dt = new DataTable();

        objtbl_DeducteeDetails.MasterID = MasterID;
        objtbl_DeducteeDetails.Regular_Correction = "Regular";
        dt = objBltbl_DeducteeDetails.Get_Data_By_MasterID(objtbl_DeducteeDetails);
        return dt;
    }
    public System.Data.DataTable GetSalaryDetail_ForExcel(int ID_Admin)
    {
        //Create The DataTables
        DataTable dt_Salary_Detail = new DataTable();
        DataTable dt_Section6A = new DataTable();
        DataTable dt_16A = new DataTable();
        DataTable dt_Annual_Salary_Detail = new DataTable();
        DataTable dt_Sec6a_Excel = new DataTable();
        //Set The Property of the ID_Admin
        objtbl_SectionVI_A.ID = ID_Admin;
        objtbl_16A.ID = ID_Admin;
        objtbl_SalaryDetails.SalaryID = ID_Admin;
        //Get Salary Detail

        dt_Salary_Detail = objBltbl_SalaryDetails.FillSalary(objtbl_SalaryDetails);

        //Get 16A Detail
        //dt_16A = objBltbl_16A.Get_Record16A_BYSalary(ID_Admin,Salary_Detail_Record_No);
        dt_Annual_Salary_Detail = Get_Salary_Template();
        dt_Annual_Salary_Detail.Clear();

        foreach (DataRow row_SD in dt_Salary_Detail.Rows)
        {
            DataRow dr = dt_Annual_Salary_Detail.NewRow();
            dr[0] = row_SD["SalaryDetails_RecordNo"].ToString();
            int Salary_Detail_Record_No = Convert.ToInt32(dr[0]);
            dr[1] = row_SD["EmployeePAN"].ToString();
            dr[2] = row_SD["NameofEmployee"].ToString();
            dr[3] = row_SD["Category_of_Employee"].ToString();
            dr[4] = row_SD["Period_of_Employment_FromDate"].ToString();
            dr[5] = row_SD["Period_of_Employment_ToDate"].ToString();
            dr[6] = row_SD["Taxable_Amount_deducted_by_the_current_employer"].ToString();
            dr[7] = row_SD["Taxable_Amount_deducted_by_the_Previous_employer"].ToString();
            dr[8] = row_SD["TotalAmount_OfSalary"].ToString();
            dr[9] = row_SD["GrossTotal_TotalDeduction"].ToString();
            dr[10] = "";
            dr[11] = "";
            dr[12] = row_SD["Income_Chargeable"].ToString();
            dr[13] = row_SD["Other_Income"].ToString();
            dr[14] = row_SD["Gross_Total_Income"].ToString();
            //Get Section6A Details

            dt_Section6A = objBltbl_SectionVI_A.Get_Record6A_BYSalary(ID_Admin, Salary_Detail_Record_No);
            if (dt_Section6A.Rows.Count != 0)
            {
                foreach (DataRow row in dt_Section6A.Rows)
                {
                    string Section_ID = row["Chapter_VI_SectionID"].ToString();
                    if (Section_ID == "80CCE")
                    {
                        dr[15] = row["TotalAmount_UnderChapterVI"].ToString();

                    }


                    if (Section_ID == "80CCF")
                    {
                        dr[16] = row["TotalAmount_UnderChapterVI"].ToString();


                    }

                    if (Section_ID == "OTHERS")
                    {
                        dr[17] = row["TotalAmount_UnderChapterVI"].ToString();
                    }


                }
            }
            else
            {
                dr[15] = 0.00;
                dr[16] = 0.00;
                dr[17] = 0.00;
            }
            dr[18] = row_SD["Gross_Total"].ToString();
            dr[19] = row_SD["Total_TaxableIncome"].ToString();
            dr[20] = row_SD["IncomeTax_onTotalIncome"].ToString();
            dr[21] = row_SD["Surcharge"].ToString();
            dr[22] = row_SD["EducationCess"].ToString();
            dr[23] = row_SD["IncomeTaxRelief"].ToString();
            dr[24] = row_SD["NetIncomeTaxPayable"].ToString();
            dr[25] = row_SD["Total_Amount_deducted_at_source_by_the_current_employer"].ToString();
            dr[26] = row_SD["Total_Amount_deducted_at_source_by_the_previous_employer"].ToString();
            dr[27] = row_SD["TotalAmountof_TaxDeducted"].ToString();
            dr[28] = row_SD["ShortFall_in_TaxDeducted"].ToString();
            dr[29] = row_SD["Tax_deducted_at_Higher_rate"].ToString();
            dt_Annual_Salary_Detail.Rows.Add(dr);


        }


        return dt_Annual_Salary_Detail;


    }
    public DataTable GetExcelSheetTemplate(OleDbConnection con, string SheetName)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }


        string strComand;
        strComand = "select * from [" + SheetName + "]";
        OleDbDataAdapter daAdapter = new OleDbDataAdapter(strComand, con);
        DataTable dt_Sheet = new DataTable(SheetName);
        daAdapter.FillSchema(dt_Sheet, SchemaType.Source);
        daAdapter.Fill(dt_Sheet);
        con.Close();
        return dt_Sheet;
    }
    public DataTable Get_Salary_Template()
    {

        //Create the Datatable of Salary Template

        string strComand;
        strComand = "select * from ['SALARY DETAIL$']";
        //Get File Name
        string filename = Server.MapPath("~/ExcelSheetTemplate/Template24.xlsx");
        string strConnectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + filename + ";Extended Properties=Excel 12.0;";
        //string strConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties=Excel 8.0;HDR=No;IMEX=1";
        OleDbConnection con = new OleDbConnection(strConnectionString);

        OleDbDataAdapter daAdapter = new OleDbDataAdapter(strComand, strConnectionString);
        DataTable dt_Salary = new DataTable("SALARY DETAIL");
        daAdapter.FillSchema(dt_Salary, SchemaType.Source);
        daAdapter.Fill(dt_Salary);
        con.Close();
        return dt_Salary;



    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        ExportToExcel();
    }
}