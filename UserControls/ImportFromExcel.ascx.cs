using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BALVatasETDS;
using System.Data;
using BALVatasETDS.ChallanDetails;
using BALVatasETDS.DeducteeDetail;
using BALVatasETDS.SalaryDetails;
using BALVatasETDS.FileHeader;
using BALVatasETDS.Import_DataTable;
using Utilities;
using System.Data.OleDb;
using System.Configuration;
using System.IO;

public partial class ImportFromExcel : System.Web.UI.UserControl
{
    Bltbl_ChallanDetails objBltbl_ChallanDetails;
    tbl_ChallanDetails objtbl_ChallanDetails;
    Bltbl_DeducteeDetail objBltbl_DeducteeDetails;
    tbl_DeducteeDetail objtbl_DeducteeDetails;
    Bltbl_SalaryDetails objBltbl_SalaryDetails;
    tbl_SalaryDetails objtbl_SalaryDetails;
    Bltbl_FileHeader objBltbl_FileHeader;
    tbl_FileHeader objtbl_FileHeader;
    Bltbl_Import_Data_Table objBltbl_Import_Data_Table;
    tbl_Import_Data_Table objtbl_Import_Data_Table;
    FillTableFromExcel objFillTableFromExcel;
    string strConnName;
    string strConnectionString;
    string strConnName_Admin;
    string strConnectionString_Admin;
    int Count_Deductee;
    int Count_Challan;
    string FlagDeductee_Exist = "F";
    string FlagChallan_Exist = "F";
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
        // Connection String of TDS
        strConnName = Application["DBEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;

        //ConnectionString Of Admin
        strConnName_Admin = Application["DBEngine3"].ToString();
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[strConnName_Admin].ConnectionString;
        //Session["ChallanID"] = 1.ToString();
        string ChallanID = "";
        if (Session["ImportChallanID"] != null)
            ChallanID = Session["ImportChallanID"].ToString();
        //Session["DataImp"] = null;
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        if ((Session["ChallanID"] != "--select--") && (Request.QueryString["vtype"] == "3004"))
        {

            //ImportFrom_Excel();

        }
        Session["Regular_Correction"] = "Regular";
        if (ViewState["ImpType"] == null)
        {
            ViewState["ImpType"] = "Challan";
            ShowChallnScreen();
        }
        if (Session["Upload_FileName"] == null && asy_ImpExcel.HasFile)
        {
            //asy_ImpExcel.Visible = false;
            lbl_FileName.Visible = true;
            lbl_FileName.Text = "";
            lbl_FileName.Text = asy_ImpExcel.FileName.ToString();
        }
        else if (Session["Upload_FileName"] != null && (!asy_ImpExcel.HasFile))
        {
            //asy_ImpExcel.Visible = false;
            lbl_FileName.Visible = true;
            lbl_FileName.Text = Session["Upload_FileName"].ToString();
        }
        else if (asy_ImpExcel.HasFile)
        {
            lbl_FileName.Visible = true;
            lbl_FileName.Text = "";
            lbl_FileName.Text = asy_ImpExcel.FileName.ToString();
        }
        if (!Page.IsPostBack)
        {
            Bind_ImpDrop();
        }

    }

    public void ImportFrom_Excel()
    {


        objBltbl_ChallanDetails = new Bltbl_ChallanDetails(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_ChallanDetails = new tbl_ChallanDetails();

        //Deductee Details Object.
        objBltbl_DeducteeDetails = new Bltbl_DeducteeDetail(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_DeducteeDetails = new tbl_DeducteeDetail();

        //Salary Details Object
        objBltbl_SalaryDetails = new Bltbl_SalaryDetails(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SalaryDetails = new tbl_SalaryDetails();

        //File Header Object
        objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_FileHeader = new tbl_FileHeader();

        //Create Object For Import Datatable Module
        objBltbl_Import_Data_Table = new Bltbl_Import_Data_Table(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_Import_Data_Table = new tbl_Import_Data_Table();

        //Create The Object For the Fill From Excel Module
        objFillTableFromExcel = new FillTableFromExcel(strConnectionString, strConnName, strConnectionString_Admin);
        //Declarations
        Count_Deductee = 0;
        Count_Challan = 0;
        string Form_No = Session["FormType"].ToString();//"Form24Q";
        string Type = Session["Regular_Correction"].ToString();//"Regular";
        Double Total_TDS_TCS_IncomeTAX = 0.00;
        Double Total_TDS_TCS_Surcharge = 0.00;
        Double Total_TDS_TCS_Cess = 0.00;
        Double Total_IncomeTAX_Deducted = 0.00;

        Double Total_TDS_TCS_IncomeTAX1 = 0.00;
        Double Total_TDS_TCS_Surcharge1 = 0.00;
        Double Total_TDS_TCS_Cess1 = 0.00;
        Double Total_IncomeTAX_Deducted1 = 0.00;
        objtbl_ChallanDetails.TAN = Session["TAN"].ToString();
        objtbl_ChallanDetails.Quarter = Session["qtr"].ToString();
        objtbl_ChallanDetails.FinancialYear = Session["AY"].ToString().Replace("-20", "");
        objtbl_ChallanDetails.FormType = Session["FormType"].ToString();
        objtbl_ChallanDetails.Regular_Correction = Session["Regular_Correction"].ToString();//"Regular";
        int MasterID = objBltbl_ChallanDetails.GetIDFromMaster(objtbl_ChallanDetails);
        ViewState["ID_Master"] = MasterID;
        //Get ID_Admin By MasterID
        objtbl_Import_Data_Table.Master_ID = MasterID;
        //int ID_Admin = objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);

        //Get Challan ID
        int ChallanID = Convert.ToInt32(Session["ImportChallanID"]);
        // Get the Table From Sheet
        DataTable dtSheet = (DataTable)Session["SelectedDataTable"];
        //Make the Table to Be Imported
        DataTable dt_Structure = new DataTable();
        if (ViewState["ImpType"].ToString() == "Deductee")
            dt_Structure = objFillTableFromExcel.Convert_DataTable_Imp("tbl_DeducteeDetail_Record", ",");
        else
            dt_Structure = objFillTableFromExcel.Convert_DataTable_Imp("tbl_ChallanTransferVoucherDetail", ",");
        //Transfer Data From dt_Sheet to dt_Structure

        Session["FinalTable"] = dt_Structure;

        if (ViewState["ImpType"].ToString() == "Deductee")
        {
            DataTable dt_GetDeductee = objBltbl_DeducteeDetails.GetDeducteeDetail(ChallanID, MasterID, Type);
            if (dt_GetDeductee.Rows.Count != 0)
            {
                FlagDeductee_Exist = "T";

                //PlaceHolderImp.Attributes.Remove("style");

            }
            else
            {
                DataTable dt_Deductee = Insert_Deductee_Excel(dtSheet, dt_Structure, Type);

                //Add Table to the DataSet
                //dt_Deductee = RemoveEmptyRow(dt_Deductee);
                // dt_Deductee = RemoveWhiteSpace(dt_Deductee);
                //dt_Deductee = RemoveWhiteSpaceDeducteePAN(dt_Deductee);

                //Create Flag
                string Flag_C9 = dt_Deductee.Rows[0]["C9"].ToString();
                string Flag_C3 = dt_Deductee.Rows[0]["C3"].ToString();
                //FlagDeductee_Exist = "F";
                //Validate the Data in the Deductee Table and than Import the Data
                //Declare the main error list
                DataTable dt_mainErrorList = new DataTable();
                //Declare InValid Pan Error List
                DataTable arr_INValidPANList = new DataTable();
                //arr_INValidPANList = Get_Error_List(dt_Deductee, "ValidatePAN");
                dt_mainErrorList = arr_INValidPANList.Clone();
                dt_mainErrorList.Clear();
                //Declare the InValid PAN Length Error List
                DataTable arr_INValidPANLengthList = new DataTable();
                //arr_INValidPANLengthList = Get_Error_List(dt_Deductee, "ValidatePANLength");
                //Declare the Empty Name List
                DataTable arr_EmptyNameList = new DataTable();
                //arr_EmptyNameList = Get_Error_List(dt_Deductee, "ValidateEmptyField");

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
                    //Build(dt_mainErrorList);
                }
                else
                {




                    //Get the Sum of Fields to Update in Challan
                    //Update the Total of Deductee Field in the Challan Records.
                    int Count_Of_deductee = 0;
                    if (dt_GetDeductee.Rows.Count == 0)
                    {
                        Total_TDS_TCS_IncomeTAX = (from DataRow dr in dt_Deductee.AsEnumerable()
                                                   where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                                   select Convert.ToDouble(dr["TDS_TCS_IncomeTAX"])).Sum();


                        Total_TDS_TCS_Surcharge = (from DataRow dr in dt_Deductee.AsEnumerable()
                                                   where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                                   select Convert.ToDouble(dr["TDS_TCS_Surcharge"])).Sum();

                        Total_TDS_TCS_Cess = (from DataRow dr in dt_Deductee.AsEnumerable()
                                              where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                              select Convert.ToDouble(dr["TDS_TCS_Cess"])).Sum();

                        Total_IncomeTAX_Deducted = (from DataRow dr in dt_Deductee.AsEnumerable()
                                                    where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                                    select Convert.ToDouble(dr["Total_IncomeTAX_Deducted"])).Sum();
                        Count_Of_deductee = dt_Deductee.Rows.Count;
                    }
                    else
                    {
                        Total_TDS_TCS_IncomeTAX = (from DataRow dr in dt_Deductee.AsEnumerable()
                                                   where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                                   select Convert.ToDouble(dr["TDS_TCS_IncomeTAX"])).Sum();


                        Total_TDS_TCS_Surcharge = (from DataRow dr in dt_Deductee.AsEnumerable()
                                                   where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                                   select Convert.ToDouble(dr["TDS_TCS_Surcharge"])).Sum();

                        Total_TDS_TCS_Cess = (from DataRow dr in dt_Deductee.AsEnumerable()
                                              where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                              select Convert.ToDouble(dr["TDS_TCS_Cess"])).Sum();

                        Total_IncomeTAX_Deducted = (from DataRow dr in dt_Deductee.AsEnumerable()
                                                    where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                                    select Convert.ToDouble(dr["Total_IncomeTAX_Deducted"])).Sum();

                        Total_TDS_TCS_IncomeTAX1 = (from DataRow dr in dt_GetDeductee.AsEnumerable()
                                                    where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                                    select Convert.ToDouble(dr["TDS_TCS_IncomeTAX"])).Sum();


                        Total_TDS_TCS_Surcharge1 = (from DataRow dr in dt_GetDeductee.AsEnumerable()
                                                    where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                                    select Convert.ToDouble(dr["TDS_TCS_Surcharge"])).Sum();

                        Total_TDS_TCS_Cess1 = (from DataRow dr in dt_GetDeductee.AsEnumerable()
                                               where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                               select Convert.ToDouble(dr["TDS_TCS_Cess"])).Sum();

                        Total_IncomeTAX_Deducted1 = (from DataRow dr in dt_GetDeductee.AsEnumerable()
                                                     where dr.RowState != DataRowState.Deleted && Convert.ToInt32(dr["ID"]) == ChallanID && Convert.ToInt32(dr["MasterID"]) == MasterID
                                                     select Convert.ToDouble(dr["Total_IncomeTAX_Deducted"])).Sum();

                        Total_TDS_TCS_IncomeTAX = Total_TDS_TCS_IncomeTAX + Total_TDS_TCS_IncomeTAX1;
                        Total_TDS_TCS_Surcharge = Total_TDS_TCS_Surcharge + Total_TDS_TCS_Surcharge1;
                        Total_TDS_TCS_Cess = Total_TDS_TCS_Cess + Total_TDS_TCS_Cess1;
                        Total_IncomeTAX_Deducted = Total_IncomeTAX_Deducted + Total_IncomeTAX_Deducted1;
                        Count_Of_deductee = dt_Deductee.Rows.Count + dt_GetDeductee.Rows.Count;
                    }


                    //update the values to the Challan 

                    DataTable dt_Challan = new DataTable();
                    objtbl_ChallanDetails.ChallanID = ChallanID;
                    objtbl_ChallanDetails.ID = MasterID;
                    objtbl_ChallanDetails.Regular_Correction = Session["Regular_Correction"].ToString();

                    dt_Challan = objBltbl_ChallanDetails.GetChallanDetailByID(objtbl_ChallanDetails);
                    DataRow[] dr_Challan_Excel = dt_Challan.Select("ChallanID=" + ChallanID + " and ID=" + MasterID + "");

                    Double TotalDepositeAmount = Convert.ToDouble(dr_Challan_Excel[0]["TotalDepositeAmount"]);
                    Total_IncomeTAX_Deducted = Math.Round(Total_IncomeTAX_Deducted);
                    if (Total_IncomeTAX_Deducted <= TotalDepositeAmount)
                    {
                        //Update the Challan
                        objtbl_ChallanDetails.ChallanID = ChallanID;
                        objtbl_ChallanDetails.ID = MasterID;
                        objtbl_ChallanDetails.Total_TAX_Deposite_Amount = Total_IncomeTAX_Deducted;
                        objtbl_ChallanDetails.TDS_TCS_IncomeTAX = Total_TDS_TCS_IncomeTAX;
                        objtbl_ChallanDetails.TDS_TCS_Surcharge = Total_TDS_TCS_Surcharge;
                        objtbl_ChallanDetails.TDS_TCS_Cess = Total_TDS_TCS_Cess;
                        objtbl_ChallanDetails.Total_IncomeTAX_Deducted = Total_IncomeTAX_Deducted;
                        objtbl_ChallanDetails.Count_Of_deductee_PartyRecords = Count_Of_deductee;
                        if (Type == "Correction")
                        {
                            objtbl_ChallanDetails.C9 = Flag_C9;
                            objtbl_ChallanDetails.C3 = Flag_C3;
                            objtbl_ChallanDetails.Decision = "A";
                        }
                        else if (Type == "Regular")
                        {
                            objtbl_ChallanDetails.C9 = "";
                            objtbl_ChallanDetails.C3 = "";
                            objtbl_ChallanDetails.Decision = "";
                        }
                        if (Form_No == "Form24Q")
                        {
                            objtbl_ChallanDetails.Page_ID = "2";
                            objtbl_ChallanDetails.Page_SubModule_ID = "22";

                        }
                        else if (Form_No == "Form26Q")
                        {
                            objtbl_ChallanDetails.Page_ID = "2";
                            objtbl_ChallanDetails.Page_SubModule_ID = "23";
                        }
                        else if (Form_No == "Form27Q")
                        {
                            objtbl_ChallanDetails.Page_ID = "2";
                            objtbl_ChallanDetails.Page_SubModule_ID = "24";
                        }
                        else if (Form_No == "Form27EQ")
                        {
                            objtbl_ChallanDetails.Page_ID = "2";
                            objtbl_ChallanDetails.Page_SubModule_ID = "25";
                        }
                        //Call the Method and Update the Challan Table
                        int success = objBltbl_ChallanDetails.Update_Challan_ByDeductee(objtbl_ChallanDetails);
                        //if (Type == "Correction")
                        //{
                        //    objtbl_FileHeader_Correction.ID = MasterID;
                        //    objtbl_FileHeader_Correction.C1 = "";
                        //    objtbl_FileHeader_Correction.C2 = "";
                        //    objtbl_FileHeader_Correction.C4 = "";
                        //    objtbl_FileHeader_Correction.C5 = "";
                        //    objtbl_FileHeader_Correction.C9 = Flag_C9;
                        //    objtbl_FileHeader_Correction.C3 = Flag_C3;
                        //    objBltbl_FileHeader_Correction.Mark_Correction_Type(objtbl_FileHeader_Correction);
                        //}





                        //set Name of the Deductee Table
                        if (Type == "Regular")
                        {
                            dt_Deductee.TableName = "tbl_DeducteeDetail_Record";
                        }
                        else if (Type == "Correction")
                        {
                            dt_Deductee.TableName = "tbl_DeducteeDetail_Record_Correction";
                        }
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt_Deductee);

                        //Import Data To Database
                        objBltbl_Import_Data_Table.Import_Data(ds);
                        //mdl_ImpExcel.Hide();
                        //Pnl_Deductee.Attributes.Remove("style");
                        //Pnl_ImportExcel.Attributes.Add("style", "display:none");
                        //Chk_ImportExcel.Checked = false;
                        // BindDeducteeGrid(ChallanID, MasterID, Type);
                        Session["ImCD"] = 1;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Imported Suceessfully');window.location='salary.aspx?vtype=3002';", true);
                        //Response.Redirect("salary.aspx?vtype=3002");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Deductee Amount Cannot Exceed Challan Amount');", true);
                    }
                }
            }

        }
        else
        {
            objtbl_ChallanDetails.ID = Convert.ToInt32(ViewState["ID_Master"]);
            DataTable dt_GetChallan = objBltbl_ChallanDetails.GetChallanDeatilByMasterID(objtbl_ChallanDetails);
            //if (dt_GetChallan.Rows.Count != 0)
            //{
            //    FlagChallan_Exist = "T";
            //    //PlaceHolderImp.Attributes.Remove("style");
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Challan Already Exists Do U want to Add More Challans..');", true);
            //}
            //else
            //{
            DataTable dt_Challan = Insert_Challan_Excel(dtSheet, dt_Structure, Type);
            if (Type == "Regular")
            {
                dt_Challan.TableName = "tbl_ChallanTransferVoucherDetail";
            }
            else if (Type == "Correction")
            {
                dt_Challan.TableName = "tbl_ChallanTransferVoucherDetail_Correction";
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt_Challan);

            //Import Data To Database
            objBltbl_Import_Data_Table.Import_Data(ds);
            //mdl_ImpExcel.Hide();
            //Pnl_Deductee.Attributes.Remove("style");
            //Pnl_ImportExcel.Attributes.Add("style", "display:none");
            //Chk_ImportExcel.Checked = false;
            // BindDeducteeGrid(ChallanID, MasterID, Type);
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Imported Suceessfully');", true);
            //}
        }
    }
    public DataTable Insert_Deductee_Excel(DataTable dt_Sheet, DataTable dt_Deductee, string Type)
    {
        objBltbl_ChallanDetails = new Bltbl_ChallanDetails(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_ChallanDetails = new tbl_ChallanDetails();

        //Deductee Details Object.
        objBltbl_DeducteeDetails = new Bltbl_DeducteeDetail(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_DeducteeDetails = new tbl_DeducteeDetail();

        //Salary Details Object
        objBltbl_SalaryDetails = new Bltbl_SalaryDetails(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SalaryDetails = new tbl_SalaryDetails();

        //File Header Object
        objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_FileHeader = new tbl_FileHeader();

        //Create Object For Import Datatable Module
        objBltbl_Import_Data_Table = new Bltbl_Import_Data_Table(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_Import_Data_Table = new tbl_Import_Data_Table();

        //Create The Object For the Fill From Excel Module
        objFillTableFromExcel = new FillTableFromExcel(strConnectionString, strConnName, strConnectionString_Admin);
        string Flag_Replace = "F";
        string Form_No = Session["FormType"].ToString();
        //Make the Record From DataTable
        for (int i = 0; i < dt_Sheet.Rows.Count; i++)
        {
            //Add New Row to DataTable
            DataRow dr_Deductee = dt_Deductee.NewRow();
            //Create Parameters For Getting MasterID
            int MasterID = Convert.ToInt32(ViewState["ID_Master"]);
            dr_Deductee["MasterID"] = MasterID;

            //Get ID_Admin By MasterID
            objtbl_Import_Data_Table.Master_ID = MasterID;
            int ID_Admin = 0;// objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);
            dr_Deductee["ID_Admin"] = ID_Admin;
            //Get Challan ID
            int ChallanID = Convert.ToInt32(Session["ImportChallanID"]);
            dr_Deductee["ID"] = ChallanID;

            ////Get Section 
            //string Section_Code = string.Empty;
            //if (Convert.ToInt32(Session["ddlgrdState"]) != 0)
            //{
            //    Section_Code = Session["ddlgrdState"].ToString();
            //}
            //else
            //{
            //    Section_Code = "";
            //}

            //Changed by Mudit on 11/12/2015 because Sesction Code will Now be Added in ExcelSheet
            string Section_Code = string.Empty;
            if (dt_Sheet.Columns.Contains(drp_Section.SelectedItem.ToString()))
            {
                Section_Code = dt_Sheet.Rows[i][drp_Section.SelectedItem.ToString()].ToString().ToUpper();
                Section_Code = Section_Code.Trim();
            }
            else
            {
                Section_Code = "";
            }

            dr_Deductee["Section_Code"] = Section_Code;
            //Line_Number
            int LineNumber = 0;
            dr_Deductee["Line_Number"] = LineNumber;
            //Record Type
            string Record_Type = "DD";
            dr_Deductee["Record_Type"] = Record_Type;
            //Batch Number
            string Batch_Number = "1";
            dr_Deductee["Batch_Number"] = Batch_Number;
            //Challan Detail Record Number

            dr_Deductee["Challan_Detail_Rec_No"] = ChallanID;
            //Create Deductee SerialNo
            int Deductee_SerialNo = 0;
            //Deductee Party Record No
            int Deductee_party_recordNo = 0;
            DataTable dt_GetDeductee = objBltbl_DeducteeDetails.GetDeducteeDetail(ChallanID, MasterID);

            //Mode




            if (FlagDeductee_Exist == "T")
            {
                if (Flag_Replace == "" || Flag_Replace == null)
                {
                    //PlaceHolderImp.Attributes.Remove("style");
                }
                else
                {

                    if (Flag_Replace == "Y")
                    {
                        Count_Deductee = Count_Deductee + 1;
                        //Delete The Record From Deductee Table and Replace the current Record
                        objtbl_DeducteeDetails.ID = ChallanID;
                        objtbl_DeducteeDetails.MasterID = MasterID;

                        //Call the Query 
                        int success_Deductee = objBltbl_DeducteeDetails.Delete_All_Challan_Of_Deductee(objtbl_DeducteeDetails);

                        //Now Create New Deductee Serial No;
                        Deductee_SerialNo = Count_Deductee;
                        dr_Deductee["DeducteeID"] = Deductee_SerialNo;
                        Deductee_party_recordNo = Count_Deductee;
                        dr_Deductee["DeducteeParty_Record_No"] = Deductee_party_recordNo;
                        Flag_Replace = "Y";
                        FlagDeductee_Exist = "T";
                    }

                    else if (Flag_Replace == "F")
                    {
                        //Count Deductee  From Deductee Table
                        objtbl_DeducteeDetails.ID = ChallanID;
                        objtbl_DeducteeDetails.MasterID = MasterID;
                        if (dt_Deductee.Rows.Count == 0)
                        {
                            Deductee_SerialNo = objBltbl_DeducteeDetails.GetMaxIDofUNDelRec(objtbl_DeducteeDetails);

                        }
                        else
                        {
                            if (i != 0)
                            {
                                Deductee_SerialNo = Convert.ToInt32(dt_Deductee.Rows[i - 1]["DeducteeID"]);
                            }
                            else
                            {
                                Deductee_SerialNo = Convert.ToInt32(dt_Deductee.Rows[i]["DeducteeID"]);
                            }
                        }

                        Deductee_SerialNo = Deductee_SerialNo + 1;
                        dr_Deductee["DeducteeID"] = Deductee_SerialNo;
                        Deductee_party_recordNo = Deductee_SerialNo;
                        dr_Deductee["DeducteeParty_Record_No"] = Deductee_party_recordNo;
                        Flag_Replace = "F";
                        FlagDeductee_Exist = "T";
                    }
                }

            }
            else
            {
                Count_Deductee = Count_Deductee + 1;
                //set Deductee serial No
                Deductee_SerialNo = Count_Deductee;
                dr_Deductee["DeducteeID"] = Deductee_SerialNo;
                Deductee_party_recordNo = Count_Deductee;
                dr_Deductee["DeducteeParty_Record_No"] = Deductee_party_recordNo;
            }

            if (Deductee_SerialNo != 0)
            {
                //Employee_SerialNo
                string Employee_Serial_No = string.Empty;
                if (Form_No == "Form24Q")
                {
                    Employee_Serial_No = ChallanID.ToString();

                }
                else
                {
                    Employee_Serial_No = "";
                }
                dr_Deductee["Employee_SerialNo"] = Employee_Serial_No;

                //
                //Get Pan Number
                string PAN = dt_Sheet.Rows[i][drp_PANImp.SelectedItem.ToString()].ToString().ToUpper();
                PAN = PAN.TrimStart();
                PAN = PAN.TrimEnd();
                //Deductee Party_Code
                string Charc4 = string.Empty;
                if (PAN != "")
                {
                    Charc4 = PAN.Substring(3, 5);
                }
                if (Form_No != "Form24Q")
                {
                    if (Charc4 == "C")
                    {
                        dr_Deductee["Deductee_PartyCode"] = "1";
                    }
                    else
                    {
                        dr_Deductee["Deductee_PartyCode"] = "2";
                    }
                }
                else
                {
                    dr_Deductee["Deductee_PartyCode"] = "";
                }

                //LastEmployee_PartyPAN
                dr_Deductee["LastEmployee_PartyPAN"] = "";

                //Pan Number
                //Check If Pan Number is Valid
                if (PAN != "")
                {


                    dr_Deductee["EmployeePAN"] = PAN;
                }
                else
                {

                    dr_Deductee["EmployeePAN"] = "PANNOTAVBL";

                }
                //Last_EmployeePartyPAN
                dr_Deductee["Last_EmployeePartyPAN"] = "";

                //PAN_RefNO
                if (Form_No != "Form24Q")
                {
                    if (drp_PANRefNo.SelectedIndex != 0)
                    {
                        string PAN_RefNo = dt_Sheet.Rows[i][drp_PANRefNo.SelectedValue.ToString()].ToString();
                        if (PAN_RefNo != "")
                        {
                            PAN_RefNo = String.Format("{0:0000000000}", Int32.Parse(PAN_RefNo));
                        }
                        dr_Deductee["PAN_RefNO"] = PAN_RefNo;
                    }
                    else
                    {
                        dr_Deductee["PAN_RefNO"] = "";
                    }
                }
                else
                {
                    dr_Deductee["PAN_RefNO"] = "";
                }

                //Name of Employee Party
                string Name_Of_Employee_Party = dt_Sheet.Rows[i][drp_NameImp.SelectedValue.ToString()].ToString();
                Name_Of_Employee_Party = Name_Of_Employee_Party.TrimStart();
                Name_Of_Employee_Party = Name_Of_Employee_Party.TrimEnd();
                dr_Deductee["NameofEmployee_Party"] = Name_Of_Employee_Party;

                //  TDS_TCS Income TAX
                string TDSTCSIncomeTax = dt_Sheet.Rows[i][drp_TDSImp.SelectedItem.ToString()].ToString();
                Double TDS_TCS_INComeTax = 0.00;
                if (TDSTCSIncomeTax != "")
                {
                    TDS_TCS_INComeTax = Convert.ToDouble(dt_Sheet.Rows[i][drp_TDSImp.SelectedItem.ToString()]);
                    dr_Deductee["TDS_TCS_IncomeTAX"] = TDS_TCS_INComeTax;
                }
                else
                {
                    dr_Deductee["TDS_TCS_IncomeTAX"] = "";
                }

                //TDS_TCS_Surcharge
                dr_Deductee["TDS_TCS_Surcharge"] = 0.00;

                //TDS_TCS_Cess
                dr_Deductee["TDS_TCS_Cess"] = 0.00;

                //Total_IncomeTAX_Deducted
                dr_Deductee["Total_IncomeTAX_Deducted"] = TDS_TCS_INComeTax + Convert.ToDouble(dr_Deductee["TDS_TCS_Surcharge"]) + Convert.ToDouble(dr_Deductee["TDS_TCS_Cess"]);

                //Last_Income_TaxDeducted
                dr_Deductee["Last_Income_TaxDeducted"] = "";

                //Total_TaxDeposited
                dr_Deductee["Total_TaxDeposited"] = dr_Deductee["Total_IncomeTAX_Deducted"];

                //LastTotal_TaxDeposited
                dr_Deductee["LastTotal_TaxDeposited"] = "";

                //Total_ValuePurchase
                if (Form_No == "Form27EQ")
                {
                    dr_Deductee["Total_ValuePurchase"] = dt_Sheet.Rows[i][drp_AmountImp.SelectedValue.ToString()].ToString() + ".00";
                }
                else
                {
                    dr_Deductee["Total_ValuePurchase"] = "";

                }

                //Amountof_Payment
                string Amount_Of_Payment = dt_Sheet.Rows[i][drp_AmountImp.SelectedValue.ToString()].ToString();
                if (Amount_Of_Payment == "")
                {
                    dr_Deductee["Amountof_Payment"] = "";
                }
                else
                {
                    dr_Deductee["Amountof_Payment"] = Math.Round((Convert.ToDouble(Amount_Of_Payment)));
                }

                //DateOnWhich_AMTPaid

                string DateOnWhichAmountPaid = string.Empty;
                string DataType = dt_Sheet.Columns[drp_DateImp.SelectedItem.ToString()].DataType.ToString();
                if (DataType != "System.String")
                {
                    DateTime dt_On_Which_Amount_Paid = Convert.ToDateTime(dt_Sheet.Rows[i][drp_DateImp.SelectedItem.ToString()]);
                    DateOnWhichAmountPaid = dt_On_Which_Amount_Paid.ToString("dd/MM/yyyy");

                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.Replace("/", "");
                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.Replace("-", "");
                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.TrimStart();
                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.TrimEnd();
                }
                else
                {
                    DateOnWhichAmountPaid = dt_Sheet.Rows[i][drp_DateImp.SelectedItem.ToString()].ToString();
                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.Replace("/", "");
                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.Replace("-", "");
                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.TrimStart();
                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.TrimEnd();
                }


                dr_Deductee["DateOnWhich_AMTPaid"] = DateOnWhichAmountPaid;



                //Dateof_Deposit
                if (Form_No != "Form24Q")
                {
                    dr_Deductee["Dateof_Deposit"] = "";
                }
                else
                {
                    //Get Date Of Deposit
                    objtbl_ChallanDetails.ID = MasterID;
                    objtbl_ChallanDetails.ChallanID = ChallanID;
                    objtbl_ChallanDetails.Regular_Correction = Type;

                    DataTable dt = objBltbl_ChallanDetails.GetChallanDetailByID(objtbl_ChallanDetails);
                    //Get Bank Challan Date
                    string DateofDeposit = dt.Rows[0]["Date_Of_Bank_ChallanNo"].ToString();
                    DateofDeposit = DateofDeposit.TrimStart();
                    DateofDeposit = DateofDeposit.TrimEnd();
                    dr_Deductee["Dateof_Deposit"] = DateofDeposit;
                }
                //RateatWhich_TAXDeducted
                string Rate = string.Empty;
                if (Form_No == "Form24Q")
                {
                    Rate = "";
                }
                else
                {


                    Rate = dt_Sheet.Rows[i][drp_RateImp.SelectedValue.ToString()].ToString();
                    Rate = Rate.TrimStart();
                    Rate = Rate.TrimEnd();
                    Rate = String.Format("{0:0.0000}", Convert.ToDouble(Rate));

                }

                dr_Deductee["RateatWhich_TAXDeducted"] = Rate;

                //GrossingUP_Indicator
                dr_Deductee["GrossingUP_Indicator"] = "";

                //BookEntry_CashIndicator
                dr_Deductee["BookEntry_CashIndicator"] = "";

                //Dateof_TaxDeduction_Certificate
                dr_Deductee["Dateof_TaxDeduction_Certificate"] = "";

                //Reason_For_NonDeduction
                string Reason_Code = string.Empty;
                if (PAN == "PANNOTAVBL" || PAN == "")
                {
                    Reason_Code = "C";
                    dr_Deductee["Reason_For_NonDeduction"] = "C";
                }
                else
                {
                    if (dt_Sheet.Columns.Contains(drp_CCodeImp.SelectedItem.ToString()))
                    {
                        Reason_Code = dt_Sheet.Rows[i][drp_CCodeImp.SelectedItem.ToString()].ToString();
                        Reason_Code = Reason_Code.TrimStart();
                        Reason_Code = Reason_Code.TrimEnd();
                        dr_Deductee["Reason_For_NonDeduction"] = Reason_Code;
                    }
                    else
                    {
                        Reason_Code = "";
                        dr_Deductee["Reason_For_NonDeduction"] = "";
                    }
                }
                if (Reason_Code == "T")
                {
                    //DateonWhich_TaxDeducted
                    dr_Deductee["DateonWhich_TaxDeducted"] = "";
                }
                else
                {
                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.TrimStart();
                    DateOnWhichAmountPaid = DateOnWhichAmountPaid.TrimEnd();
                    dr_Deductee["DateonWhich_TaxDeducted"] = DateOnWhichAmountPaid;
                }


                //Remarks1
                dr_Deductee["Remarks1"] = "";

                //Remarks2
                dr_Deductee["Remarks2"] = "";

                if (Form_No == "Form27Q")
                {
                    //Certificate Number

                    //dr_Deductee["Certificate_Number"] = txt_CertificateNo.Text;

                    //WhetherTDSRateofTDSIsITAct27
                    string WhetherTDSRateofTDSIsITAct27 = string.Empty;
                    if (dt_Sheet.Columns.Contains(ddlTDS_DTAA.SelectedItem.ToString()))
                    {
                        dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = dt_Sheet.Rows[i][ddlTDS_DTAA.SelectedItem.ToString()].ToString().ToUpper();
                    }
                    else
                    {
                        dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = "";
                    }
                    //Nature_of_Remittance_27
                    if (dt_Sheet.Columns.Contains(ddlNatureOfRem.SelectedItem.ToString()))
                    {
                        dr_Deductee["Nature_of_Remittance_27"] = dt_Sheet.Rows[i][ddlNatureOfRem.SelectedItem.ToString()].ToString().ToUpper();
                    }
                    else
                    {
                        dr_Deductee["Nature_of_Remittance_27"] = "";
                    }
                    //Unique_formno_15CA_27
                    if (dt_Sheet.Columns.Contains(ddl_Acknowledgement_No_of_15CA.SelectedItem.ToString()))
                    {
                        dr_Deductee["Unique_formno_15CA_27"] = dt_Sheet.Rows[i][ddl_Acknowledgement_No_of_15CA.SelectedItem.ToString()].ToString().ToUpper();
                    }
                    else
                    {
                        dr_Deductee["Unique_formno_15CA_27"] = "";
                    }
                    //Country_to_which_remittance_is_made_27
                    if (dt_Sheet.Columns.Contains(ddlCountryTowhichRemi.SelectedItem.ToString()))
                    {
                        dr_Deductee["Country_to_which_remittance_is_made_27"] = dt_Sheet.Rows[i][ddlCountryTowhichRemi.SelectedItem.ToString()].ToString().ToUpper();
                    }
                    else
                    {
                        dr_Deductee["Country_to_which_remittance_is_made_27"] = "";
                    }
                }
                else
                {
                    //Certificate Number

                    dr_Deductee["Certificate_Number"] = "";

                    //WhetherTDSRateofTDSIsITAct27
                    dr_Deductee["WhetherTDSRateofTDSIsITAct27"] = "";
                    //Nature_of_Remittance_27
                    dr_Deductee["Nature_of_Remittance_27"] = "";
                    //Unique_formno_15CA_27
                    dr_Deductee["Unique_formno_15CA_27"] = "";
                    //Country_to_which_remittance_is_made_27
                    dr_Deductee["Country_to_which_remittance_is_made_27"] = "";
                }
                //RecordHash
                dr_Deductee["RecordHash"] = "";
                //DeleteFlag
                dr_Deductee["DeleteFlag"] = "";
                if (Type == "Regular")
                {
                    dr_Deductee["Mode"] = "O";
                    //C1
                    dr_Deductee["C1"] = "";
                    //C2
                    dr_Deductee["C2"] = "";
                    //C3
                    dr_Deductee["C3"] = "";
                    //C4
                    dr_Deductee["C4"] = "";
                    //C5
                    dr_Deductee["C5"] = "";
                    //C9
                    dr_Deductee["C9"] = "";
                    //Y
                    dr_Deductee["Y"] = "";
                    //Desicion

                    dr_Deductee["Desicion"] = "";
                }
                else if (Type == "Correction")
                {
                    objtbl_DeducteeDetails.ID = ChallanID;
                    objtbl_DeducteeDetails.MasterID = MasterID;
                    objtbl_DeducteeDetails.Regular_Correction = Type;

                    DataTable dt = objBltbl_DeducteeDetails.BindDeducteeDetails(objtbl_DeducteeDetails);

                    //Get Date Of Deposit
                    objtbl_ChallanDetails.ID = MasterID;
                    objtbl_ChallanDetails.ChallanID = ChallanID;
                    objtbl_ChallanDetails.Regular_Correction = Type;

                    DataTable dt_Challan = objBltbl_ChallanDetails.GetChallanDetailByID(objtbl_ChallanDetails);
                    if (dt.Rows.Count == 0 || dt_Challan.Rows[0]["C9"].ToString() == "Y")
                    {
                        dr_Deductee["Mode"] = "O";
                        //C1
                        dr_Deductee["C1"] = "";
                        //C2
                        dr_Deductee["C2"] = "";
                        //C3
                        dr_Deductee["C3"] = "";
                        //C4
                        dr_Deductee["C4"] = "";
                        //C5
                        dr_Deductee["C5"] = "";
                        //C9
                        dr_Deductee["C9"] = "Y";
                        //Y
                        dr_Deductee["Y"] = "";
                        //Desicion

                        dr_Deductee["Desicion"] = "A";
                    }
                    else
                    {
                        dr_Deductee["Mode"] = "A";
                        //C1
                        dr_Deductee["C1"] = "";
                        //C2
                        dr_Deductee["C2"] = "";
                        //C3
                        dr_Deductee["C3"] = "Y";
                        //C4
                        dr_Deductee["C4"] = "";
                        //C5
                        dr_Deductee["C5"] = "";
                        //C9
                        dr_Deductee["C9"] = "";
                        //Y
                        dr_Deductee["Y"] = "";
                        //Desicion

                        dr_Deductee["Desicion"] = "A";
                    }
                }

                dt_Deductee.Rows.Add(dr_Deductee);
            }
            //Check the Deductee Table Data Before Returing and Add the Errors to the List



        }
        return dt_Deductee;


    }
    public void Bind_ImpDrop()
    {
        if (Session["DataImp"] != null)
        {

            drp_NameofSheetImp.DataSource = (String[])Session["DataImp"];
            drp_NameofSheetImp.DataBind();
            drp_NameofSheetImp.Items.Insert(0, new ListItem("--Select SheetName--", "0"));
        }
        //asy_ImpExcel.UploadedComplete += new EventHandler<AjaxControlToolkit.AsyncFileUploadEventArgs>(asy_ImpExcel_UploadedComplete);
    }

    protected void btn_ExtractSheetName_Click(object sender, EventArgs e)
    {
        string FileName = asy_ImpExcel.PostedFile.FileName.ToString();

        string Upload_filename = Path.GetFileName(asy_ImpExcel.FileName.ToString());
        Session["Upload_FileName"] = Upload_filename;
        //Get the File Path of the Uploaded Excel
        string Filepath = Server.MapPath("~/ImportedFile/" + FileName);
        Session["Filepath"] = Filepath;
        //Get Extension of the Uploaded File
        string FileExtension = Path.GetExtension(asy_ImpExcel.FileName.ToString());
        Session["FileExtension"] = FileExtension;
        string Type = string.Empty;
        if (FileExtension == ".xls" || FileExtension == ".xlsx")
        {

            //Get the  Uploaded File
            string Uploaded_File = Server.MapPath(@"~/Upload/" + Upload_filename);
            Session["UploadedFile"] = Uploaded_File;
            asy_ImpExcel.PostedFile.SaveAs(Uploaded_File);
            //Create Connection String To connect with Excel Sheeet

            string strConnectionString2 = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Uploaded_File + ";Extended Properties=Excel 12.0;";
            OleDbConnection con2 = new OleDbConnection(strConnectionString2);
            //Get the Excel Sheet Name and Fill in the DropDownlist
            String[] arr_SheetName = GetExcelSheetName(con2, Upload_filename);
            //DataTable dt = GetExcelSheetName(con2, Upload_filename);
            Session["DataImp"] = arr_SheetName;
            btn_ExtractSheetName.Focus();
        }
        Bind_ImpDrop();

        //mdl_ImpExcel.Show();
        //upd_ImpExcel.Update();
        drp_NameofSheetImp.Focus();
    }
    public DataTable GetDataTableofCompareExcel(string sheetName, string filename)
    {
        try
        {
            string strComand;
            strComand = "select * from [" + sheetName + "]";

            string strConnectionString = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + filename + ";Extended Properties=Excel 12.0;";

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
    protected void drp_NameofSheetImp_SelectedIndexChanged(object sender, EventArgs e)
    {
        string File_Name = Session["UploadedFile"].ToString();
        string sheetName = drp_NameofSheetImp.SelectedItem.ToString();
        DataTable dt = GetDataTableofCompareExcel(sheetName, File_Name);
        Session["SelectedDataTable"] = dt;
        DataTable dtColName = new DataTable();
        DataColumn Col_Name = new DataColumn("ColumnName", typeof(string));
        dtColName.Columns.Add(Col_Name);

        foreach (DataColumn dt_Col in dt.Columns)
        {
            DataRow drCol = dtColName.NewRow();
            drCol["ColumnName"] = dt_Col.ColumnName.ToString();
            dtColName.Rows.Add(drCol);
        }
        //Bind the PAN DropDownList
        drp_PANImp.Enabled = true;
        drp_PANImp.DataSource = dtColName;
        drp_PANImp.DataValueField = "ColumnName";
        drp_PANImp.DataMember = "ColumnName";
        drp_PANImp.DataBind();
        drp_PANImp.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind Name DropDownList
        drp_NameImp.Enabled = true;
        drp_NameImp.DataSource = dtColName;
        drp_NameImp.DataValueField = "ColumnName";
        drp_NameImp.DataMember = "ColumnName";
        drp_NameImp.DataBind();
        drp_NameImp.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind Amount DropDownlist
        drp_AmountImp.Enabled = true;
        drp_AmountImp.DataSource = dtColName;
        drp_AmountImp.DataValueField = "ColumnName";
        drp_AmountImp.DataMember = "ColumnName";
        drp_AmountImp.DataBind();
        drp_AmountImp.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind TDS   DropDownlist
        drp_TDSImp.Enabled = true;
        drp_TDSImp.DataSource = dtColName;
        drp_TDSImp.DataValueField = "ColumnName";
        drp_TDSImp.DataMember = "ColumnName";
        drp_TDSImp.DataBind();
        drp_TDSImp.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind Date DropDownlist
        drp_DateImp.Enabled = true;
        drp_DateImp.DataSource = dtColName;
        drp_DateImp.DataValueField = "ColumnName";
        drp_DateImp.DataMember = "ColumnName";
        drp_DateImp.DataBind();
        drp_DateImp.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind CCode DropDownlIst
        drp_CCodeImp.Enabled = true;
        drp_CCodeImp.DataSource = dtColName;
        drp_CCodeImp.DataValueField = "ColumnName";
        drp_CCodeImp.DataMember = "ColumnName";
        drp_CCodeImp.DataBind();
        drp_CCodeImp.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind the Rate DropDownList

        drp_RateImp.Enabled = true;
        drp_RateImp.DataSource = dtColName;
        drp_RateImp.DataValueField = "ColumnName";
        drp_RateImp.DataMember = "ColumnName";
        drp_RateImp.DataBind();
        drp_RateImp.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind the Rate DropDownList

        drp_PANRefNo.Enabled = true;
        drp_PANRefNo.DataSource = dtColName;
        drp_PANRefNo.DataValueField = "ColumnName";
        drp_PANRefNo.DataMember = "ColumnName";
        drp_PANRefNo.DataBind();
        drp_PANRefNo.Items.Insert(0, new ListItem("--Select--", "0"));


        //Bind Section DropDownList
        drp_Section.Enabled = true;
        drp_Section.DataSource = dtColName;
        drp_Section.DataValueField = "ColumnName";
        drp_Section.DataMember = "ColumnName";
        drp_Section.DataBind();
        drp_Section.Items.Insert(0, new ListItem("--Select--", "0"));


        //Bind TDS_DTAA DropDownList
        ddlTDS_DTAA.Enabled = true;
        ddlTDS_DTAA.DataSource = dtColName;
        ddlTDS_DTAA.DataValueField = "ColumnName";
        ddlTDS_DTAA.DataMember = "ColumnName";
        ddlTDS_DTAA.DataBind();
        ddlTDS_DTAA.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind NatureOfRem DropDownList
        ddlNatureOfRem.Enabled = true;
        ddlNatureOfRem.DataSource = dtColName;
        ddlNatureOfRem.DataValueField = "ColumnName";
        ddlNatureOfRem.DataMember = "ColumnName";
        ddlNatureOfRem.DataBind();
        ddlNatureOfRem.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind CountryTowhichRemi DropDownList
        ddlCountryTowhichRemi.Enabled = true;
        ddlCountryTowhichRemi.DataSource = dtColName;
        ddlCountryTowhichRemi.DataValueField = "ColumnName";
        ddlCountryTowhichRemi.DataMember = "ColumnName";
        ddlCountryTowhichRemi.DataBind();
        ddlCountryTowhichRemi.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind Acknowledgement_No_of_15CA DropDownList
        ddl_Acknowledgement_No_of_15CA.Enabled = true;
        ddl_Acknowledgement_No_of_15CA.DataSource = dtColName;
        ddl_Acknowledgement_No_of_15CA.DataValueField = "ColumnName";
        ddl_Acknowledgement_No_of_15CA.DataMember = "ColumnName";
        ddl_Acknowledgement_No_of_15CA.DataBind();
        ddl_Acknowledgement_No_of_15CA.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind ChallanNo DropDownList
        drp_ChallanNo.Enabled = true;
        drp_ChallanNo.DataSource = dtColName;
        drp_ChallanNo.DataValueField = "ColumnName";
        drp_ChallanNo.DataMember = "ColumnName";
        drp_ChallanNo.DataBind();
        drp_ChallanNo.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind MinorCode DropDownList
        drp_MinorCode.Enabled = true;
        drp_MinorCode.DataSource = dtColName;
        drp_MinorCode.DataValueField = "ColumnName";
        drp_MinorCode.DataMember = "ColumnName";
        drp_MinorCode.DataBind();
        drp_MinorCode.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind MinorCode DropDownList
        drp_BSRCode.Enabled = true;
        drp_BSRCode.DataSource = dtColName;
        drp_BSRCode.DataValueField = "ColumnName";
        drp_BSRCode.DataMember = "ColumnName";
        drp_BSRCode.DataBind();
        drp_BSRCode.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind BookEntry DropDownList
        //drp_BookEntry.Enabled = true;
        //drp_BookEntry.DataSource = dtColName;
        //drp_BookEntry.DataValueField = "ColumnName";
        //drp_BookEntry.DataMember = "ColumnName";
        //drp_BookEntry.DataBind();
        //drp_BookEntry.Items.Insert(0, new ListItem("--Select--", "0"));
        //mdl_ImpExcel.Show();
        drp_BookEntry.Enabled = true;
        //upd_ImpExcel.Update();
        drp_PANImp.Focus();
    }

    //Function to Get Sheet Name From Excel
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
            String[] FilterExcel = new String[dt.Rows.Count];

            int i = 0;
            int j = 0;
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[i] = row["TABLE_NAME"].ToString();
                if (excelSheets[i].EndsWith("$"))
                {
                    FilterExcel[j] = excelSheets[i];

                    j++;
                }


                i++;
            }
            FilterExcel = FilterExcel.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return FilterExcel;
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
    protected void btn_ImpExcel_Click(object sender, EventArgs e)
    {
        ImportFrom_Excel();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        if (ViewState["ImpType"].ToString() == "Deductee")
        {
            Response.Redirect("Salary.aspx?vtype=3002");
        }
        else
        {
            Response.Redirect("Salary.aspx?vtype=3001");
        }
    }
    protected void btnChallan_Click(object sender, EventArgs e)
    {
        ViewState["ImpType"] = "Challan";
        ShowChallnScreen();
    }
    protected void btnDeductee_Click(object sender, EventArgs e)
    {
        ViewState["ImpType"] = "Deductee";
        ShowDeducteeScreen();
    }
    public void ShowChallnScreen()
    {
        drp_AmountImp.Visible = false;
        lbl_AmountImp.Visible = false;
        drp_BSRCode.Visible = true;
        lbl_BSR.Visible = true;
        drp_BookEntry.Visible = true;
        lbl_BookEntry.Visible = true;
        drp_CCodeImp.Visible = false;
        lbl_CCodeImp.Visible = false;
        drp_ChallanNo.Visible = true;
        lblChallanNo.Visible = true;
        drp_DateImp.Visible = true;
        lbl_DateImp.Visible = true;
        drp_MinorCode.Visible = true;
        lbl_MinorCode.Visible = true;
        drp_NameImp.Visible = false;
        lbl_NameImp.Visible = false;
        drp_PANImp.Visible = false;
        lbl_PANImp.Visible = false;
        drp_PANRefNo.Visible = false;
        lbl_PANREfNo.Visible = false;
        drp_RateImp.Visible = false;
        lbl_RateImp.Visible = false;
        drp_Section.Visible = false;
        lblSection.Visible = false;
        drp_TDSImp.Visible = true;
        lbl_TDSImp.Visible = true;
        ddl_Acknowledgement_No_of_15CA.Visible = false;
        lbl_Acknowledgement_No_of_15CA.Visible = false;
        ddlCountryTowhichRemi.Visible = false;
        lvlCountry_To_Which_Remittance_Made.Visible = false;
        ddlNatureOfRem.Visible = false;
        lblNature_Of_Remittance.Visible = false;
        ddlTDS_DTAA.Visible = false;
        lblTDS_DTAA.Visible = false;
    }
    public void ShowDeducteeScreen()
    {
        drp_AmountImp.Visible = true;
        lbl_AmountImp.Visible = true;
        drp_BSRCode.Visible = false;
        lbl_BSR.Visible = false;
        drp_BookEntry.Visible = false;
        lbl_BookEntry.Visible = false;
        drp_CCodeImp.Visible = true;
        lbl_CCodeImp.Visible = true;
        drp_ChallanNo.Visible = false;
        lblChallanNo.Visible = false;
        drp_DateImp.Visible = true;
        lbl_DateImp.Visible = true;
        drp_MinorCode.Visible = false;
        lbl_MinorCode.Visible = false;
        drp_NameImp.Visible = true;
        lbl_NameImp.Visible = true;
        drp_PANImp.Visible = true;
        lbl_PANImp.Visible = true;
        drp_PANRefNo.Visible = true;
        lbl_PANREfNo.Visible = true;
        drp_RateImp.Visible = true;
        lbl_RateImp.Visible = true;
        drp_Section.Visible = true;
        lblSection.Visible = true;
        drp_TDSImp.Visible = true;
        lbl_TDSImp.Visible = true;
        ddl_Acknowledgement_No_of_15CA.Visible = true;
        lbl_Acknowledgement_No_of_15CA.Visible = true;
        ddlCountryTowhichRemi.Visible = true;
        lvlCountry_To_Which_Remittance_Made.Visible = true;
        ddlNatureOfRem.Visible = true;
        lblNature_Of_Remittance.Visible = true;
        ddlTDS_DTAA.Visible = true;
        lblTDS_DTAA.Visible = true;
    }
    public DataTable Insert_Challan_Excel(DataTable dt_Sheet, DataTable dt_Challan, string Type)
    {
        objBltbl_ChallanDetails = new Bltbl_ChallanDetails(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_ChallanDetails = new tbl_ChallanDetails();

        //Deductee Details Object.
        objBltbl_DeducteeDetails = new Bltbl_DeducteeDetail(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_DeducteeDetails = new tbl_DeducteeDetail();

        //Salary Details Object
        objBltbl_SalaryDetails = new Bltbl_SalaryDetails(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_SalaryDetails = new tbl_SalaryDetails();

        //File Header Object
        objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_FileHeader = new tbl_FileHeader();

        //Create Object For Import Datatable Module
        objBltbl_Import_Data_Table = new Bltbl_Import_Data_Table(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_Import_Data_Table = new tbl_Import_Data_Table();

        //Create The Object For the Fill From Excel Module
        objFillTableFromExcel = new FillTableFromExcel(strConnectionString, strConnName, strConnectionString_Admin);
        string Flag_Replace = "F";
        string Form_No = Session["FormType"].ToString();
        //Make the Record From DataTable
        for (int i = 0; i < dt_Sheet.Rows.Count; i++)
        {
            //Add New Row to DataTable
            DataRow dr_Challan = dt_Challan.NewRow();
            //Create Parameters For Getting MasterID
            int MasterID = Convert.ToInt32(ViewState["ID_Master"]);
            dr_Challan["ID"] = MasterID;

            //Get ID_Admin By MasterID
            objtbl_Import_Data_Table.Master_ID = MasterID;
            int ID_Admin = objBltbl_Import_Data_Table.Get_IDAdmin(objtbl_Import_Data_Table);
            dr_Challan["ID_Admin"] = ID_Admin;

            //Line_Number
            int LineNumber = 0;
            dr_Challan["Line_Number"] = LineNumber;
            //Record Type
            string Record_Type = "CD";
            dr_Challan["Record_Type"] = Record_Type;
            //Batch Number
            string Batch_Number = "1";
            dr_Challan["Batch_Number"] = Batch_Number;
            //Create Deductee SerialNo
            int Challan_Detail_Record_No = 0;
            //Deductee Party Record No
            int Count_Of_deductee_PartyRecords = 0;
            //DataTable dt_GetDeductee = objBltbl_DeducteeDetails.GetDeducteeDetail(ChallanID, MasterID);

            ////Mode




            if (FlagChallan_Exist == "T")
            {
                if (Flag_Replace == "" || Flag_Replace == null)
                {
                    Flag_Replace = "Y";
                    //PlaceHolderImp.Attributes.Remove("style");
                }
                else
                {

                    if (Flag_Replace == "Y")
                    {
                        Count_Challan = Count_Challan + 1;
                        //Delete The Record From Deductee Table and Replace the current Record
                        objtbl_ChallanDetails.ChallanID = Count_Challan;
                        objtbl_ChallanDetails.ID = MasterID;

                        //Call the Query 
                        int success_Challan = objBltbl_ChallanDetails.DeleteChallanByMasterID(objtbl_ChallanDetails);

                        //Now Create New Deductee Serial No;
                        Challan_Detail_Record_No = Count_Challan;
                        dr_Challan["Challan_Detail_Record_No"] = Challan_Detail_Record_No;
                        Count_Of_deductee_PartyRecords = 0;
                        dr_Challan["Count_Of_deductee_PartyRecords"] = Count_Of_deductee_PartyRecords;
                        Flag_Replace = "Y";
                        FlagDeductee_Exist = "T";
                    }

                    else if (Flag_Replace == "F")
                    {
                        //Count Deductee  From Deductee Table
                        //objtbl_DeducteeDetails.ID = ChallanID;
                        objtbl_ChallanDetails.ID = MasterID;
                        if (dt_Challan.Rows.Count == 0)
                        {
                            Challan_Detail_Record_No = objBltbl_ChallanDetails.GetMaxIDofUNDelChallanRec(objtbl_ChallanDetails);

                        }
                        else
                        {
                            if (i != 0)
                            {
                                Challan_Detail_Record_No = Convert.ToInt32(dt_Challan.Rows[i - 1]["ChallanID"]);
                            }
                            else
                            {
                                Challan_Detail_Record_No = Convert.ToInt32(dt_Challan.Rows[i]["ChallanID"]);
                            }
                        }

                        Challan_Detail_Record_No = Challan_Detail_Record_No + 1;
                        dr_Challan["ChallanID"] = Challan_Detail_Record_No;
                        Count_Of_deductee_PartyRecords = 0;
                        dr_Challan["Challan_Detail_Record_No"] = Challan_Detail_Record_No;
                        Flag_Replace = "F";
                        FlagChallan_Exist = "T";
                    }
                }

            }
            else
            {
                if (Session["Challan_Detail_Record_No"] != null)
                {
                    Count_Challan = Convert.ToInt32(Session["Challan_Detail_Record_No"]) + 1;
                }
                else
                {
                    Count_Challan = Count_Challan + 1;
                }
                Challan_Detail_Record_No = Count_Challan;
                dr_Challan["ChallanID"] = Challan_Detail_Record_No;
                dr_Challan["Challan_Detail_Record_No"] = Challan_Detail_Record_No;
                Count_Of_deductee_PartyRecords = Count_Challan;
                dr_Challan["Count_Of_deductee_PartyRecords"] = 0;//Count_Of_deductee_PartyRecords;
                Session["Challan_Detail_Record_No"] = Challan_Detail_Record_No;
            }

            if (Challan_Detail_Record_No != 0)
            {
                //By_BookEntry
                string By_BookEntry = string.Empty;
                By_BookEntry = drp_BookEntry.SelectedValue;//dt_Sheet.Rows[i][drp_BookEntry.SelectedItem.ToString()].ToString();
                dr_Challan["By_BookEntry"] = By_BookEntry;

                //NIL Challan Indicator
                string Nill_Challan_Indicator = string.Empty;
                Nill_Challan_Indicator = "N";
                dr_Challan["Nill_Challan_Indicator"] = Nill_Challan_Indicator;

                //Challan_Updation_Indicator
                string Challan_Updation_Indicator = string.Empty;
                Challan_Updation_Indicator = "0";
                dr_Challan["Challan_Updation_Indicator"] = Challan_Updation_Indicator;

                //Filler2
                string Filler2 = string.Empty;
                dr_Challan["Filler2"] = Filler2;

                //Filler3
                string Filler3 = string.Empty;
                dr_Challan["Filler3"] = Filler3;

                //Filler4
                string Filler4 = string.Empty;
                dr_Challan["Filler4"] = Filler4;

                //Last_Bank_Challan_No
                string Last_Bank_Challan_No = string.Empty;
                dr_Challan["Last_Bank_Challan_No"] = Last_Bank_Challan_No;

                //Bank Challan No
                string Bank_Challan_No = string.Empty;
                if (By_BookEntry == "N")
                {
                    Bank_Challan_No = dt_Sheet.Rows[i][drp_ChallanNo.SelectedItem.ToString()].ToString();
                }
                else
                {
                    Bank_Challan_No = "0";
                }
                dr_Challan["Bank_Challan_No"] = Bank_Challan_No;
                //Last_Transfer_Voucher_No
                string Last_Transfer_Voucher_No = string.Empty;
                dr_Challan["Last_Transfer_Voucher_No"] = Last_Transfer_Voucher_No;

                //TransferVoucher_DDO_SerialNo
                string TransferVoucher_DDO_SerialNo = string.Empty;
                if (By_BookEntry == "Y")
                {
                    TransferVoucher_DDO_SerialNo = dt_Sheet.Rows[i][drp_ChallanNo.SelectedItem.ToString()].ToString();
                }
                else
                {
                    TransferVoucher_DDO_SerialNo = "";
                }
                dr_Challan["TransferVoucher_DDO_SerialNo"] = TransferVoucher_DDO_SerialNo;

                //Last_Bank_Branch_Code
                string Last_Bank_Branch_Code = string.Empty;
                Last_Bank_Branch_Code = "";
                dr_Challan["Last_Bank_Branch_Code"] = Last_Bank_Branch_Code;

                //Bank_Branch_Code
                string Bank_Branch_Code = string.Empty;
                Bank_Branch_Code = dt_Sheet.Rows[i][drp_BSRCode.SelectedItem.ToString()].ToString();
                dr_Challan["Bank_Branch_Code"] = Bank_Branch_Code;

                //Last_date_Of_BankChallanNo
                string Last_date_Of_BankChallanNo = string.Empty;
                dr_Challan["Last_date_Of_BankChallanNo"] = Last_date_Of_BankChallanNo;

                //Date_Of_Bank_ChallanNo
                string Date_Of_Bank_ChallanNo = string.Empty;
                Date_Of_Bank_ChallanNo = dt_Sheet.Rows[i][drp_DateImp.SelectedItem.ToString()].ToString();
                dr_Challan["Date_Of_Bank_ChallanNo"] = Date_Of_Bank_ChallanNo;

                //Filler5
                string Filler5 = string.Empty;
                dr_Challan["Filler5"] = Filler5;

                //Filler6
                string Filler6 = string.Empty;
                dr_Challan["Filler6"] = Filler6;

                //Section
                string Section = string.Empty;
                dr_Challan["Section"] = Section;


                //Oltas_TDS_TCS_IncomeTAX
                string OltasTDSTCSIncomeTAX = dt_Sheet.Rows[i][drp_TDSImp.SelectedItem.ToString()].ToString();
                Double Oltas_TDS_TCS_IncomeTAX = 0.00;
                if (OltasTDSTCSIncomeTAX != "")
                {
                    Oltas_TDS_TCS_IncomeTAX = Convert.ToDouble(dt_Sheet.Rows[i][drp_TDSImp.SelectedItem.ToString()]);
                    dr_Challan["Oltas_TDS_TCS_IncomeTAX"] = Oltas_TDS_TCS_IncomeTAX;
                }
                else
                {
                    dr_Challan["Oltas_TDS_TCS_IncomeTAX"] = "";
                }

                //Oltas_TDS_TCS_Surcharge
                dr_Challan["Oltas_TDS_TCS_Surcharge"] = 0.00;
                //Oltas_TDS_TCS_Cess
                dr_Challan["Oltas_TDS_TCS_Cess"] = 0.00;
                //Oltas_TDS_TCS_InterestAMT
                dr_Challan["Oltas_TDS_TCS_InterestAMT"] = 0.00;
                //Oltas_TDS_TCS_Others
                dr_Challan["Oltas_TDS_TCS_Others"] = 0.00;
                //Fee
                dr_Challan["Fee"] = "0.00";

                //TotalDepositeAmount
                dr_Challan["TotalDepositeAmount"] = Oltas_TDS_TCS_IncomeTAX + Convert.ToDouble(dr_Challan["Oltas_TDS_TCS_Surcharge"]) + Convert.ToDouble(dr_Challan["Oltas_TDS_TCS_Cess"]) + Convert.ToDouble(dr_Challan["Oltas_TDS_TCS_InterestAMT"]) + Convert.ToDouble(dr_Challan["Oltas_TDS_TCS_Others"]) + Convert.ToDouble(dr_Challan["Fee"]);

                //Last_Total_DepositAmount
                dr_Challan["Last_Total_DepositAmount"] = "";

                //Total_TAX_Deposite_Amount
                dr_Challan["Total_TAX_Deposite_Amount"] = 0.00;//dr_Deductee["Total_IncomeTAX_Deducted"];

                //TDS_TCS_IncomeTAX
                dr_Challan["TDS_TCS_IncomeTAX"] = 0.00;
                //TDS_TCS_Surcharge
                dr_Challan["TDS_TCS_Surcharge"] = 0.00;
                //TDS_TCS_Cess
                dr_Challan["TDS_TCS_Cess"] = 0.00;
                //Total_IncomeTAX_Deducted
                dr_Challan["Total_IncomeTAX_Deducted"] = 0.00;
                //TDS_TCS_InterestAMT
                dr_Challan["TDS_TCS_InterestAMT"] = 0.00;
                //TDS_TCS_Others
                dr_Challan["TDS_TCS_Others"] = 0.00;

                //Cheque_DD_No
                dr_Challan["Cheque_DD_No"] = "";
                //Remarks
                dr_Challan["Remarks"] = "";

                //Minor_Head_of_Challan
                string Minor_Head_of_Challan = string.Empty;
                if (By_BookEntry == "N")
                {
                    Minor_Head_of_Challan = dt_Sheet.Rows[i][drp_MinorCode.SelectedItem.ToString()].ToString();
                }
                else
                {
                    Minor_Head_of_Challan = "";
                }
                dr_Challan["Minor_Head_of_Challan"] = Minor_Head_of_Challan;

                //Record_Hash
                dr_Challan["Record_Hash"] = "";
                //C1
                dr_Challan["C1"] = "";
                //C2
                dr_Challan["C2"] = "";
                //C3
                dr_Challan["C3"] = "";
                //C4
                dr_Challan["C4"] = "";
                //C5
                dr_Challan["C5"] = "";
                //C9
                dr_Challan["C9"] = "";
                //Y
                dr_Challan["Y"] = "";
                //Decision
                dr_Challan["Decision"] = "";

                //else if (Type == "Correction")
                //{
                //    objtbl_DeducteeDetails.ID = ChallanID;
                //    objtbl_DeducteeDetails.MasterID = MasterID;
                //    objtbl_DeducteeDetails.Regular_Correction = Type;

                //    DataTable dt = objBltbl_DeducteeDetails.BindDeducteeDetails(objtbl_DeducteeDetails);

                //    //Get Date Of Deposit
                //    objtbl_ChallanDetails.ID = MasterID;
                //    objtbl_ChallanDetails.ChallanID = ChallanID;
                //    objtbl_ChallanDetails.Regular_Correction = Type;

                //    DataTable dt_Challan = objBltbl_ChallanDetails.GetChallanDetailByID(objtbl_ChallanDetails);
                //    if (dt.Rows.Count == 0 || dt_Challan.Rows[0]["C9"].ToString() == "Y")
                //    {
                //        dr_Deductee["Mode"] = "O";
                //        //C1
                //        dr_Deductee["C1"] = "";
                //        //C2
                //        dr_Deductee["C2"] = "";
                //        //C3
                //        dr_Deductee["C3"] = "";
                //        //C4
                //        dr_Deductee["C4"] = "";
                //        //C5
                //        dr_Deductee["C5"] = "";
                //        //C9
                //        dr_Deductee["C9"] = "Y";
                //        //Y
                //        dr_Deductee["Y"] = "";
                //        //Desicion

                //        dr_Deductee["Desicion"] = "A";
                //    }
                //    else
                //    {
                //        dr_Deductee["Mode"] = "A";
                //        //C1
                //        dr_Deductee["C1"] = "";
                //        //C2
                //        dr_Deductee["C2"] = "";
                //        //C3
                //        dr_Deductee["C3"] = "Y";
                //        //C4
                //        dr_Deductee["C4"] = "";
                //        //C5
                //        dr_Deductee["C5"] = "";
                //        //C9
                //        dr_Deductee["C9"] = "";
                //        //Y
                //        dr_Deductee["Y"] = "";
                //        //Desicion

                //        dr_Deductee["Desicion"] = "A";
                //    }
                //}

                dt_Challan.Rows.Add(dr_Challan);
            }
            //Check the Deductee Table Data Before Returing and Add the Errors to the List



        }
        return dt_Challan;


    }
    protected void drp_BookEntry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drp_BookEntry.SelectedValue == "Y")
        {
            lblChallanNo.Text = "Transfer Voucher Number :";
            lbl_BSR.Text = "Form 24G Receipt Number :";
            lbl_MinorCode.Visible = false;
            drp_MinorCode.Visible = false;
        }
        else if (drp_BookEntry.SelectedValue == "N")
        {
            lblChallanNo.Text = "Challan No. :";
            lbl_BSR.Text = "BSR Code :";
            lbl_MinorCode.Visible = true;
            drp_MinorCode.Visible = true;
        }
    }
}