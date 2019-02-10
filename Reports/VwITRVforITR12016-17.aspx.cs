using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Xml;
using System.Data.SqlClient;
using Taxation.DataEntity;
using Taxation.BusinessLogic;

public partial class VwITRVforITR12016_17 : System.Web.UI.Page
{
    string filePath, filepathdemo;
    DataSet ds = new DataSet();
    DataSet dsdemo = new DataSet();
    bllStoreTrans objbllStoreTrans;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // filePath = Server.MapPath("~/xml/DFGPR1234R_ITR-1_2016_N_1234.xml");
            filePath = Server.MapPath(Request.QueryString["nid"].ToString() + ".xml");
            filepathdemo = Server.MapPath("~/DemoXMLs/ITR1_16-17.xml");
            ds.ReadXml(filePath);
            dsdemo.ReadXml(filepathdemo);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("ITRVforITR12016-2017.rdlc");
            //get personal info data
            ReportDataSource datasourcePersonalInfo = new ReportDataSource("PersonalInfo", ds.Tables["PersonalInfo"]);
            if (ds.Tables["PersonalInfo"].Rows[0]["Gender"].ToString() == "F")
            {
                ds.Tables["PersonalInfo"].Rows[0]["Gender"] = "Female";
            }
            else if (ds.Tables["PersonalInfo"].Rows[0]["Gender"].ToString() == "M")
            {
                ds.Tables["PersonalInfo"].Rows[0]["Gender"] = "Male";
            }
            if (ds.Tables["PersonalInfo"].Rows[0]["Status"].ToString() == "I")
            {
                ds.Tables["PersonalInfo"].Rows[0]["Status"] = "Individual";
            }
            else if (ds.Tables["PersonalInfo"].Rows[0]["Status"].ToString() == "H")
            {
                ds.Tables["PersonalInfo"].Rows[0]["Status"] = "HUF";
            }
            DataColumnCollection columns = ds.Tables["PersonalInfo"].Columns;
            if (columns.Contains("AadhaarCardFlg"))
            {
                if (ds.Tables["PersonalInfo"].Rows[0]["AadhaarCardFlg"].ToString() == "N")
                {
                    ds.Tables["PersonalInfo"].Rows[0]["AadhaarCardFlg"] = "No";
                }
                else if (ds.Tables["PersonalInfo"].Rows[0]["AadhaarCardFlg"].ToString() == "Y")
                {
                    ds.Tables["PersonalInfo"].Rows[0]["AadhaarCardFlg"] = "Yes";
                }
            }
            //get assessee name data
            ReportDataSource datasourceAssesseeName = new ReportDataSource("AssesseeName", ds.Tables["AssesseeName"]);
            ReportDataSource datasourceA = new ReportDataSource("Address", ds.Tables["Address"]);
            bllStates objbllStates = new bllStates();
            balCountry objbalCountry = new balCountry();
            ds.Tables["Address"].Rows[0]["StateCode"] = objbllStates.SelectStateName(Convert.ToInt32(ds.Tables["Address"].Rows[0]["StateCode"])).ToString();
            ds.Tables["Address"].Rows[0]["CountryCode"] = objbalCountry.SelectCountryName(Convert.ToInt32(ds.Tables["Address"].Rows[0]["CountryCode"])).ToString();
            //get filing status
            ReportDataSource datasourceFS;
            if (ds.Tables.Contains("FilingStatus"))
            {
                datasourceFS = new ReportDataSource("FilingStatus", ds.Tables["FilingStatus"]);
                if (ds.Tables["FilingStatus"].Rows[0]["TaxStatus"].ToString() == "TR")
                {
                    ds.Tables["FilingStatus"].Rows[0]["TaxStatus"] = "Tax Refundable";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["TaxStatus"].ToString() == "TP")
                {
                    ds.Tables["FilingStatus"].Rows[0]["TaxStatus"] = "Tax Payable";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["TaxStatus"].ToString() == "NT")
                {
                    ds.Tables["FilingStatus"].Rows[0]["TaxStatus"] = "Nil Tax";
                }
                if (ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"].ToString() == "11")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"] = "On or Before Due Date 139(1)";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"].ToString() == "12")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"] = "After Due Date 139(4)";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ReturnFileSece"].ToString() == "13")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"] = "u/s 142(1)";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ReturnFileSece"].ToString() == "14")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"] = "u/s 148";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ReturnFileSece"].ToString() == "15")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"] = "u/s 153 A";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ReturnFileSece"].ToString() == "16")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"] = "u/s 153C r/w 153A";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ReturnFileSece"].ToString() == "17")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"] = "Revised Return -139(5)";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ReturnFileSece"].ToString() == "18")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"] = "u/s 139(9)";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ReturnFileSece"].ToString() == "20")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnFileSec"] = "u/s 119(2)(b)";
                }
                if (ds.Tables["FilingStatus"].Rows[0]["ResidentialStatus"].ToString() == "RES")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ResidentialStatus"] = "Resident";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ResidentialStatus"].ToString() == "NRI")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ResidentialStatus"] = "No Resident";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ResidentialStatus"].ToString() == "NOR")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ResidentialStatus"] = "Resident but not only Resident";
                }
                if (ds.Tables["FilingStatus"].Rows[0]["PortugeseCC5A"].ToString() == "N")
                {
                    ds.Tables["FilingStatus"].Rows[0]["PortugeseCC5A"] = "No";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["PortugeseCC5A"].ToString() == "Y")
                {
                    ds.Tables["FilingStatus"].Rows[0]["PortugeseCC5A"] = "Yes";
                }
                if (ds.Tables["FilingStatus"].Rows[0]["ReturnType"].ToString() == "O")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnType"] = "Original";
                }
                else if (ds.Tables["FilingStatus"].Rows[0]["ReturnType"].ToString() == "R")
                {
                    ds.Tables["FilingStatus"].Rows[0]["ReturnType"] = "Revised";
                }
            }
            else
            {
                datasourceFS = new ReportDataSource("FilingStatus", dsdemo.Tables["FilingStatus"]);
            }
            //interest Pay
            ReportDataSource datasourceIntrstPay;
            if (ds.Tables.Contains("IntrstPay"))
            {
                datasourceIntrstPay = new ReportDataSource("IntrstPay", ds.Tables["IntrstPay"]);
            }
            else
            {
                datasourceIntrstPay = new ReportDataSource("IntrstPay", dsdemo.Tables["IntrstPay"]);
            }
            //TaxesPaid
            ReportDataSource datasourceTaxesPaid;
            if (ds.Tables.Contains("TaxesPaid"))
            {
                datasourceTaxesPaid = new ReportDataSource("TaxesPaid", ds.Tables["TaxesPaid"]);
            }
            else
            {
                datasourceTaxesPaid = new ReportDataSource("TaxesPaid", dsdemo.Tables["TaxesPaid"]);
            }
            //TaxesPaid
            ReportDataSource datasourceTaxPaid;
            if (ds.Tables.Contains("TaxPaid"))
            {
                datasourceTaxPaid = new ReportDataSource("TaxPaid", ds.Tables["TaxPaid"]);
            }
            else
            {
                datasourceTaxPaid = new ReportDataSource("TaxPaid", dsdemo.Tables["TaxPaid"]);
            }
            //BankAccountDtls
            ReportDataSource datasourceBankAccountDtls;
            if (ds.Tables.Contains("BankAccountDtls"))
            {
                datasourceBankAccountDtls = new ReportDataSource("BankAccountDtls", ds.Tables["BankAccountDtls"]);
            }
            else
            {
                datasourceBankAccountDtls = new ReportDataSource("BankAccountDtls", dsdemo.Tables["BankAccountDtls"]);
            }
            //PriBankDetails
            ReportDataSource datasourcePriBankDetails;
            if (ds.Tables.Contains("PriBankDetails"))
            {
                datasourcePriBankDetails = new ReportDataSource("PriBankDetails", ds.Tables["PriBankDetails"]);
                if (ds.Tables["PriBankDetails"].Rows[0]["BankAccountType"].ToString() == "SAV")
                {
                    ds.Tables["PriBankDetails"].Rows[0]["BankAccountType"] = "Saving";
                }
                else if (ds.Tables["PriBankDetails"].Rows[0]["BankAccountType"].ToString() == "CUR")
                {
                    ds.Tables["PriBankDetails"].Rows[0]["BankAccountType"] = "Current";
                }
            }
            else
            {
                datasourcePriBankDetails = new ReportDataSource("PriBankDetails", dsdemo.Tables["PriBankDetails"]);
            }
            //  AddtnlBankDetails
            ReportDataSource datasourceAddtnlBankDetails;
            if (ds.Tables.Contains("AddtnlBankDetails"))
            {
                datasourceAddtnlBankDetails = new ReportDataSource("AddtnlBankDetails", ds.Tables["AddtnlBankDetails"]);
                if (ds.Tables["AddtnlBankDetails"].Rows[0]["BankAccountType"].ToString() == "SAV")
                {
                    ds.Tables["AddtnlBankDetails"].Rows[0]["BankAccountType"] = "Saving";
                }
                else if (ds.Tables["AddtnlBankDetails"].Rows[0]["BankAccountType"].ToString() == "CUR")
                {
                    ds.Tables["AddtnlBankDetails"].Rows[0]["BankAccountType"] = "Current";
                }
            }
            else
            {
                datasourceAddtnlBankDetails = new ReportDataSource("AddtnlBankDetails", dsdemo.Tables["AddtnlBankDetails"]);
            }
            //BankAccountsDtls
            ReportDataSource datasourceBankAccountsDtls;
            if (ds.Tables.Contains("BankAccountsDtls"))
            {
                datasourceBankAccountsDtls = new ReportDataSource("BankAccountsDtls", ds.Tables["BankAccountsDtls"]);
            }
            else
            {
                datasourceBankAccountsDtls = new ReportDataSource("BankAccountsDtls", dsdemo.Tables["BankAccountsDtls"]);
            }
            //Declaration
            ReportDataSource datasourceDeclaration = new ReportDataSource("Declaration", ds.Tables["Declaration"]);
            //Verification
            ReportDataSource datasourceVerification = new ReportDataSource("Verification", ds.Tables["Verification"]);
            //TaxPayment
            ReportDataSource datasourceTaxPayment;
            if (ds.Tables.Contains("TaxPayment"))
            {
                datasourceTaxPayment = new ReportDataSource("TaxPayment", ds.Tables["TaxPayment"]);
            }
            else
            {

                datasourceTaxPayment = new ReportDataSource("TaxPayment", dsdemo.Tables["TaxPayment"]);
            }
            //EmployerorDeductor
            //ReportDataSource datasourceEmployerorDeductor, datasourceEmployerorDeductorfortds1, datasourceEmployerorDeductorfortds2;
            //if (ds.Tables.Contains("EmployerOrDeductorOrCollectDetl"))
            //{
            //    DataColumnCollection columns1 = ds.Tables["EmployerOrDeductorOrCollectDetl"].Columns;
            //    if (columns1.Contains("TDSonSalary_Id") == true)
            //    {
            //        // datasourceEmployerorDeductorfortds1 = new ReportDataSource("EmployerOrDeductorforTDS1", ds.Tables["EmployerOrDeductorOrCollectDetl"].Select("TDSonSalary_Id>="+0));
            //        DataRow[] drtds1 = ds.Tables["EmployerOrDeductorOrCollectDetl"].Select("TDSonSalary_Id>=0");
            //        DataTable dtTDSonSalary = new DataTable();
            //        dtTDSonSalary.Columns.Add("TAN", typeof(string));
            //        dtTDSonSalary.Columns.Add("EmployerOrDeductorOrCollecterName", typeof(string));
            //        dtTDSonSalary.Columns.Add("TDSonSalary_Id", typeof(string));
            //        for (int i = 0; i < drtds1.Length; i++)
            //        {
            //            dtTDSonSalary.ImportRow(drtds1[i]);
            //        }
            //        datasourceEmployerorDeductor = new ReportDataSource("EmployerorDeductor", dtTDSonSalary);

            //    }
            //    else
            //    {
            //        datasourceEmployerorDeductorfortds1 = new ReportDataSource("EmployerOrDeductorforTDS1", dsdemo.Tables["EmployerOrDeductorOrCollectDetl"]);
            //    }
            //    if (columns1.Contains("TDSonOthThanSal_Id") == true)
            //    {
            //        //datasourceEmployerorDeductorfortds2 = new ReportDataSource("EmployerOrDeductorforTDS2", ds.Tables["EmployerOrDeductorOrCollectDetl"].Select("TDSonOthThanSal_Id>=0"));
            //        DataRow[] drtds1 = ds.Tables["EmployerOrDeductorOrCollectDetl"].Select("TDSonSalary_Id>=0");
            //        DataTable dtTDSonOthThanSalary = new DataTable();
            //        dtTDSonOthThanSalary.Columns.Add("TAN", typeof(string));
            //        dtTDSonOthThanSalary.Columns.Add("EmployerOrDeductorOrCollecterName", typeof(string));
            //        dtTDSonOthThanSalary.Columns.Add("TDSonSalary_Id", typeof(string));
            //        for (int i = 0; i < drtds1.Length; i++)
            //        {
            //            dtTDSonOthThanSalary.ImportRow(drtds1[i]);
            //        }
            //        datasourceEmployerorDeductor = new ReportDataSource("EmployerorDeductor", dtTDSonOthThanSalary);
            //    }
            //    else
            //    {
            //        datasourceEmployerorDeductorfortds2 = new ReportDataSource("EmployerOrDeductorforTDS2", dsdemo.Tables["EmployerOrDeductorOrCollectDetl"]);
            //    }
            //    if (columns1.Contains("TCS_Id") == true)
            //    {
            //        DataRow[] drtds1 = ds.Tables["EmployerOrDeductorOrCollectDetl"].Select("TCS_Id>=0");
            //        DataTable dttds1 = new DataTable();
            //        dttds1.Columns.Add("TAN", typeof(string));
            //        dttds1.Columns.Add("EmployerOrDeductorOrCollecterName", typeof(string));
            //        dttds1.Columns.Add("TCS_Id", typeof(string));
            //        for (int i = 0; i < drtds1.Length; i++)
            //        {
            //            dttds1.ImportRow(drtds1[i]);
            //        }
            //        datasourceEmployerorDeductor = new ReportDataSource("EmployerorDeductor", dttds1);

            //    }
            //    else
            //    {
            //        datasourceEmployerorDeductor = new ReportDataSource("EmployerorDeductor", dsdemo.Tables["EmployerOrDeductorOrCollectDetl"]);
            //    }
            //}
            //else
            //{
            //    datasourceEmployerorDeductor = new ReportDataSource("EmployerorDeductor", dsdemo.Tables["EmployerOrDeductorOrCollectDetl"]);
            //    datasourceEmployerorDeductorfortds2 = new ReportDataSource("EmployerOrDeductorforTDS2", dsdemo.Tables["EmployerOrDeductorOrCollectDetl"]);
            //    datasourceEmployerorDeductorfortds1 = new ReportDataSource("EmployerOrDeductorforTDS1", dsdemo.Tables["EmployerOrDeductorOrCollectDetl"]);
            //}

            // TDSonSalary
            ReportDataSource datasourceTDSonSalary;
            if (ds.Tables.Contains("TDSonSalary"))
            {
                datasourceTDSonSalary = new ReportDataSource("TDSonSalary", ds.Tables["TDSonSalary"]);
            }
            else
            {
                datasourceTDSonSalary = new ReportDataSource("TDSonSalary", dsdemo.Tables["TDSonSalary"]);
            }
            //Refund
            ReportDataSource datasourceRefund;
            if (ds.Tables.Contains("Refund"))
            {
                datasourceRefund = new ReportDataSource("Refund", ds.Tables["Refund"]);

            }
            else
            {
                datasourceRefund = new ReportDataSource("Refund", dsdemo.Tables["Refund"]);
            }
            //TDSonOthThanSal
            ReportDataSource datasourceTDSonOthThanSal;
            if (ds.Tables.Contains("TDSonOthThanSal"))
            {
                datasourceTDSonOthThanSal = new ReportDataSource("TDSonOthThanSal", ds.Tables["TDSonOthThanSal"]);
            }
            else
            {
                datasourceTDSonOthThanSal = new ReportDataSource("TDSonOthThanSal", dsdemo.Tables["TDSonOthThanSal"]);
            }
            ReportDataSource datasourceIncomeDeduction;
            if (ds.Tables.Contains("ITR1_IncomeDeductions"))
            {
                datasourceIncomeDeduction = new ReportDataSource("IncomeDeductions", ds.Tables["ITR1_IncomeDeductions"]);
            }
            else
            {
                datasourceIncomeDeduction = new ReportDataSource("IncomeDeductions", dsdemo.Tables["ITR1_IncomeDeductions"]);
            }
            ReportDataSource datasourceITR1_TaxComputation;
            if (ds.Tables.Contains("ITR1_TaxComputation"))
            {
                datasourceITR1_TaxComputation = new ReportDataSource("TaxComputation", ds.Tables["ITR1_TaxComputation"]);
            }
            else
            {
                datasourceITR1_TaxComputation = new ReportDataSource("TaxComputation", dsdemo.Tables["ITR1_TaxComputation"]);
            }
            ReportDataSource datasourceUsrDeductUndChapVIA;
            if (ds.Tables.Contains("DeductUndChapVIA"))
            {
                datasourceUsrDeductUndChapVIA = new ReportDataSource("DeductUndChapVIA", ds.Tables["DeductUndChapVIA"]);
            }
            else
            {
                datasourceUsrDeductUndChapVIA = new ReportDataSource("DeductUndChapVIA", dsdemo.Tables["DeductUndChapVIA"]);
            }
            ReportDataSource datasourceITR1;
            if (ds.Tables.Contains("ITR1"))
            {
                datasourceITR1 = new ReportDataSource("ITR1", ds.Tables["ITR1"]);
            }
            else
            {
                datasourceITR1 = new ReportDataSource("ITR1", dsdemo.Tables["ITR1"]);
            }
            ReportDataSource datasourceScheduleAL;
            if (ds.Tables.Contains("ScheduleAL"))
            {
                datasourceScheduleAL = new ReportDataSource("ScheduleAL", ds.Tables["ScheduleAL"]);
            }
            else
            {
                datasourceScheduleAL = new ReportDataSource("ScheduleAL", dsdemo.Tables["ScheduleAL"]);
            }
            ReportDataSource datasourceMovableAsset;
            if (ds.Tables.Contains("MovableAsset"))
            {
                datasourceMovableAsset = new ReportDataSource("MovableAsset", ds.Tables["MovableAsset"]);
            }
            else
            {
                datasourceMovableAsset = new ReportDataSource("MovableAsset", dsdemo.Tables["MovableAsset"]);
            }
            ReportDataSource datasourceTCS;
            if (ds.Tables.Contains("TCS"))
            {
                datasourceTCS = new ReportDataSource("TCS", ds.Tables["TCS"]);
            }
            else
            {
                datasourceTCS = new ReportDataSource("TCS", dsdemo.Tables["TCS"]);
            }
            ReportDataSource datasourceTaxReturnPreparer;
            // TaxReturnPreparer
            if (ds.Tables.Contains("TaxReturnPreparer"))
            {
                datasourceTaxReturnPreparer = new ReportDataSource("TaxReturnPreparer", ds.Tables["TaxReturnPreparer"]);
            }
            else
            {
                datasourceTaxReturnPreparer = new ReportDataSource("TaxReturnPreparer", dsdemo.Tables["TaxReturnPreparer"]);
            }
            ReportDataSource datasourceForm_ITR1;
            if (ds.Tables.Contains("Form_ITR1"))
            {
                datasourceForm_ITR1 = new ReportDataSource("Form_ITR1", ds.Tables["Form_ITR1"]);
            }
            else
            {
                datasourceForm_ITR1 = new ReportDataSource("Form_ITR1", dsdemo.Tables["Form_ITR1"]);
            }
            string[] arrDOB = ds.Tables["Verification"].Rows[0]["Date"].ToString().Split('-');
            string DOB = arrDOB[2] + "-" + arrDOB[1] + "-" + arrDOB[0];
            ds.Tables["Verification"].Rows[0]["Date"] = DOB;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxReturnPreparer);
            ReportViewer1.LocalReport.DataSources.Add(datasourceForm_ITR1);
            ReportViewer1.LocalReport.DataSources.Add(datasourceITR1);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePersonalInfo);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAssesseeName);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTCS);
            ReportViewer1.LocalReport.DataSources.Add(datasourceA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceFS);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncomeDeduction);
            ReportViewer1.LocalReport.DataSources.Add(datasourceUsrDeductUndChapVIA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIntrstPay);
            ReportViewer1.LocalReport.DataSources.Add(datasourceITR1_TaxComputation);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxesPaid);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxPaid);
            ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleAL);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBankAccountDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePriBankDetails);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAddtnlBankDetails);
            ReportViewer1.LocalReport.DataSources.Add(datasourceMovableAsset);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeclaration);
            ReportViewer1.LocalReport.DataSources.Add(datasourceVerification);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxPayment);
           // ReportViewer1.LocalReport.DataSources.Add(datasourceEmployerorDeductor);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTDSonSalary);
            ReportViewer1.LocalReport.DataSources.Add(datasourceRefund);
        

            ReportViewer1.LocalReport.DataSources.Add(datasourceTDSonOthThanSal);
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.    
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= " + "ITRV" + "_" + Session["ITR"].ToString() + "_" + Session["AY"].ToString() + ".pdf");
            Response.BinaryWrite(bytes); // create the file    
            Response.Flush();
        }
    }
}