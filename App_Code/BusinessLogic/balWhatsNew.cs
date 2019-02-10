using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for balWhatsNew
/// </summary>
public class balWhatsNew
{
    dalWhatsNew obj_dalWhatsNew = new dalWhatsNew();
	public balWhatsNew()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet GetNew()
    {
        try
        {

            DataSet ds1 = new DataSet();
            ds1 = obj_dalWhatsNew.Get_Whats_New();
            return ds1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}