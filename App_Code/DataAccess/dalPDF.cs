using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Taxation.DataEntity;

namespace Taxation.DataAccess
{
    /// <summary>
    /// Summary description for dalPDF
    /// </summary>
    public class dalPDF : dalConnection
    {
        SqlCommand cmd;
        public dalPDF()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetPdfData(string FormType)
        {
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("select * from tbl_PDF where Formtype=@FormType", this.SqlCon);
                cmd.Parameters.AddWithValue("@FormType",FormType);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dtPdf = new DataTable();
                if (dr.HasRows)
                {
                    dtPdf.Load(dr);
                }
                return dtPdf;

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
}