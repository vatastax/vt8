using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for dalWhatsNew
/// </summary>

public class dalWhatsNew : dalConnection
{


    public dalWhatsNew()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet Get_Whats_New()
    {
        try
        {
            this.pConn();
            SqlDataAdapter da = new SqlDataAdapter("select * from WhatsNew", this.SqlCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();

        }

    }
}
