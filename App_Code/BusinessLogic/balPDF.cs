using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Taxation.DataAccess;

/// <summary>
/// Summary description for balPDF
/// </summary>
public class balPDF
{
    dalPDF objPDF = new dalPDF();
	public balPDF()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //fetch data from pdf

    public DataTable getPDF_Data(string FormType)
    {
        try
        {
            DataTable dtSearch_PDfdata = new DataTable();
            dtSearch_PDfdata = objPDF.GetPdfData(FormType).Copy();
            return dtSearch_PDfdata;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}