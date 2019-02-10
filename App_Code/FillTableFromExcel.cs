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
using BALVatasETDS.System_Config;

/// <summary>
/// Summary description for FillTableFromExcel
/// </summary>
public class FillTableFromExcel
{
    #region Declaration


    //Initialize the Object Of System.Config Class
    Bltbl_System_Config objBltbl_System_Config;
    tbl_System_Config objtbl_System_Config;
    #endregion

    #region Constructor

    public FillTableFromExcel(string strConnectionString, string str_Engine, string strConnectionString_Admin)
    {
        objBltbl_System_Config = new Bltbl_System_Config(strConnectionString, str_Engine, strConnectionString_Admin);
        objtbl_System_Config = new tbl_System_Config();
    }

    #endregion

    #region Fill DataTable From Excel
    public DataTable Convert_DataTable( string TableName, string delimiter)
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
        if (TableName == "tbl_SalaryDetailsRecords")
        {
            result.Columns.Remove(columns[1]);

        }
        else if (TableName == "tbl_SectionVIA" || TableName == "tbl_16A")
        {
        }
        else if (TableName != "tbl_SectionVIA" || TableName != "tbl_16A" || TableName != "tbl_SalaryDetailsRecords")
        {
            result.Columns.Remove(columns[0]);
        }

        //Read the rest of the data in the file.        
        //Now add each row to the DataSet  


        //Split the row at the delimiter
 



        //Add the item
        //result.Tables[TableName].Rows.Add(items);


        //Return the imported data.        
        return result;
    }
    #endregion

    #region Fill DataTable From Excel Deductee
    public DataTable Convert_DataTable_Imp(string TableName, string delimiter)
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

        if (TableName == "tbl_DeducteeDetail_Record")
        {
            result.Columns.Remove(columns[0]);
        }
       
        return result;
    }
    #endregion

}
