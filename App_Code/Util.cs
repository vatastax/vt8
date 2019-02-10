using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util : System.Web.UI.Page
{

	public Util()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //Function to Remove White Spaces From DataTable 
    public virtual DataTable RemoveWhiteSpace(DataTable dt)
    {
        dt.AsEnumerable().ToList()
         .ForEach(row =>
         {
             var cellList = row.ItemArray.ToList();
             row.ItemArray = cellList.Select(x => x.ToString().TrimStart().TrimEnd()).ToArray();
         });
        return dt;
    }
    //Function to Remove Empty Row from DataTable
    public virtual DataTable RemoveEmptyRow(DataTable dt)
    {
     DataTable filteredRows = dt.Rows.Cast<DataRow>()
    .Where(row => !row.ItemArray.All(field => field is System.DBNull))
    .CopyToDataTable();
     return filteredRows;
    }

    //Function to Remove WhiteSpace From PAN
    public virtual DataTable RemoveWhiteSpaceDeducteePAN(DataTable dt)
    {
        DataTable dt_Final = new DataTable();
        dt_Final = dt.Clone();
        dt_Final.Clear();
        foreach (DataRow row in dt.Rows)
        {

            string PAN = row["EmployeePAN"].ToString();
            PAN = PAN.Replace(" ", "");
            PAN = PAN.Replace("-", "");
            PAN = PAN.Replace("/", "");
            PAN = PAN.Replace("&", "");
            PAN = PAN.Replace("*", "");
            PAN = PAN.Replace("@", "");
            PAN = PAN.Replace("!", "");
            PAN = PAN.Replace("#", "");
            PAN = PAN.Replace("$", "");
            PAN = PAN.Replace("%", "");
            PAN = PAN.Replace("^", "");
            PAN = PAN.Replace("(", "");
            PAN = PAN.Replace(")", "");
            PAN = PAN.Replace("_","");
            PAN = PAN.Replace(@"\", "");
            PAN = PAN.Replace("|", "");
            PAN = PAN.Replace("<", "");
            PAN = PAN.Replace(">", "");
            PAN = PAN.Replace(",", "");
            PAN = PAN.Replace(".", "");
            PAN = PAN.Replace("?", "");
            PAN = PAN.Replace(":", "");
            PAN = PAN.Replace("'", "");
            PAN = PAN.Replace(";", "");
            PAN = PAN.Replace("+", "");
            PAN = PAN.Replace("=", "");
            row["EmployeePAN"] =PAN.ToString();
            dt_Final.ImportRow(row);
        }

        return dt_Final;
    }

  }