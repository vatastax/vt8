using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

using BALVatasETDS.System_Config;
using System.Collections.Generic;

/// <summary>
/// Summary description for TextToDataSet
/// </summary>
public class TextToDataSet
{

    //Initialize the Object Of System.Config Class
    Bltbl_System_Config objBltbl_System_Config;
    tbl_System_Config objtbl_System_Config;
    public TextToDataSet(string strConnectionString, string strEngine, string strConnectionString_Admin)
    {
        objBltbl_System_Config = new Bltbl_System_Config(strConnectionString, strEngine, strConnectionString_Admin);
        objtbl_System_Config = new tbl_System_Config();

    }
    /// <summary>
    /// Converts a given delimited file into a dataset. 
    /// Assumes that the first line    
    /// of the text file contains the column names.
    /// </summary>
    /// <param name="File">The name of the file to open</param>    
    /// <param name="TableName">The name of the 
    /// Table to be made within the DataSet returned</param>
    /// <param name="delimiter">The string to delimit by</param>
    /// <returns></returns>  

    public DataTable Convert(List<string> lst_Record, string TableName, string delimiter, string Type)
    {
        //The DataSet to Return
        DataTable result = new DataTable();
        DataTable dt = new DataTable();

        //Get The Column Name
        objtbl_System_Config.Table_Name = TableName;
        dt = objBltbl_System_Config.Get_Column_Name(objtbl_System_Config);
        //Split the  columns from DatatTable into Array      
        string[] columns = new string[dt.Rows.Count];
        string[] column_dataType = new string[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            columns[i] = dt.Rows[i]["Column Name"].ToString();
            column_dataType[i] = dt.Rows[i]["Data Type"].ToString();
        }

        //Add the new DataTable to the RecordSet
        //result.Tables.Add(TableName);

        //Cycle the colums, adding those that don't exist yet 
        //and sequencing the one that do.
        for (int k = 0; k < columns.Length; k++)
        {
            //    Type type=typeof(string);
            //     if(column_dataType[k]=="nvarchar")
            //     {
            //          type=typeof(string);
            //     }
            //    else if(column_dataType[k]=="int")
            //     {
            //        type=typeof(int);

            //    }
            //    else if(column_dataType[k]=="decimal")
            //     {
            //        type=typeof(double);
            //    }

            result.Columns.Add(columns[k]);

        }
        if (TableName == "tbl_SalaryDetailsRecords" || TableName == "tbl_SalaryDetailsRecords_Correction")
        {
            result.Columns.Remove(columns[1]);

        }
        else if (TableName == "tbl_SectionVIA" || TableName == "tbl_16A")
        {
        }
        else if (TableName != "tbl_SectionVIA" && TableName != "tbl_SectionVIA_Correction" && TableName != "tbl_16A" && TableName != "tbl_16A_Correction" && TableName != "tbl_Batch_Header_Record_Correction" && TableName != "tbl_SalaryDetailsRecords" && TableName != "tbl_SalaryDetailsRecords_Correction" && TableName != "tbl_DeducteeDetail_Record_Correction")
        {
            result.Columns.Remove(columns[0]);
        }

        if (TableName == "tbl_DeducteeDetail_Record_Correction" || TableName == "tbl_Batch_Header_Record_Correction")
        {
            result.Columns.Remove(columns[0]);
        }


        //Read the rest of the data in the file.        
        //Now add each row to the DataSet  


        //Split the row at the delimiter.
        string item = string.Empty;
        string[] items = new string[lst_Record.Count];

        DataTable dt_Cd = (DataTable)HttpContext.Current.Session["Data_CD"];


        for (int i = 0; i < lst_Record.Count; i++)
        {

            item = lst_Record[i].ToString();

            items = (string[])item.Split('^');
            int count = result.Columns.Count;
            result.Rows.Add(items);
            if (Type == "Correction" && TableName == "tbl_Batch_Header_Record_Correction" || TableName == "tbl_Batch_Header_Record")
            {
                //Get The DataRow 
                DataRow[] dr_BH_Correction = result.Select();
                string Mobile_Number = dr_BH_Correction[0]["Unmatched_Challan_No"].ToString();
                dr_BH_Correction[0]["Mobile_Number"] = Mobile_Number;
                dr_BH_Correction[0]["Unmatched_Challan_No"] = "";
                dr_BH_Correction[0]["Employer_Deductors_STD_Code_Alt"] = dr_BH_Correction[0]["Employer_Deductors_TelephoneNo_Alt"].ToString();
                dr_BH_Correction[0]["Employer_Deductors_TelephoneNo_Alt"] = dr_BH_Correction[0]["Employer_Deductor_EmailID_Alt"].ToString();
                dr_BH_Correction[0]["Employer_Deductor_EmailID_Alt"] = dr_BH_Correction[0]["Responsible_Persons_STDCode_Alt"].ToString();
                dr_BH_Correction[0]["Responsible_Persons_STDCode_Alt"] = dr_BH_Correction[0]["Responsible_Persons_TelPhoneNo_Alt"].ToString();
                dr_BH_Correction[0]["Responsible_Persons_TelPhoneNo_Alt"] = dr_BH_Correction[0]["Responsible_Persons_EmailID_2_Alt"].ToString();
                dr_BH_Correction[0]["Responsible_Persons_EmailID_2_Alt"] = dr_BH_Correction[0]["AIN"].ToString();
                dr_BH_Correction[0]["AIN"] = "";
                HttpContext.Current.Session["FormNo"] = dr_BH_Correction[0]["Form_Number"].ToString();


            }


            if (items[3].ToString() == "CD")
            {
                string By_BookEntry_CD = result.Rows[i]["By_BookEntry"].ToString();
                if (By_BookEntry_CD == "Y")
                {
                    result.Rows[i]["TransferVoucher_DDO_SerialNo"] = result.Rows[i]["Bank_Challan_No"].ToString();
                    result.Rows[i]["Last_Transfer_Voucher_No"] = result.Rows[i]["TransferVoucher_DDO_SerialNo"].ToString();
                    result.Rows[i]["Bank_Challan_No"] = "";

                }
                result.Rows[i]["Last_Total_DepositAmount"] = result.Rows[i]["TotalDepositeAmount"].ToString();
            }

            if (items[4].ToString() == "DD")
            {
                string Challan_Detail_Record_No = items[6].ToString();





                //System.Data.DataRow[] dr = new DataRow[i];
                //  dr=(DataRow[])dt_Cd.Select("Challan_Detail_Record_No=" + Challan_Detail_Record_No);
                var rowColl = dt_Cd.AsEnumerable();
                string ChallanID = (from r in rowColl
                                    where r.Field<string>("Challan_Detail_Record_No") == Challan_Detail_Record_No
                                    select r.Field<string>("ChallanID")).First<string>();

                //string ChallanID = string.Empty;

                // ChallanID = dr[0]["ChallanID"].ToString();
                result.Rows[i]["ID"] = ChallanID;

                string By_BookEntry = result.Rows[i]["BookEntry_CashIndicator"].ToString();
                if (By_BookEntry == "C")
                {
                    result.Rows[i]["BookEntry_CashIndicator"] = "";
                }



                string Formno = HttpContext.Current.Session["FormNo"].ToString();
                if (Formno == "27Q")
                {
                    result.Rows[i]["Country_to_which_remittance_is_made_27"] = result.Rows[i]["RecordHash"].ToString();
                    result.Rows[i]["RecordHash"] = "";
                }
                else
                {
                    result.Rows[i]["RecordHash"] = "";
                }


            }


        }


        //Add the item
        //result.Tables[TableName].Rows.Add(items);


        //Return the imported data.        
        return result;
    }

}


