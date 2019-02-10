using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Taxation.DataEntity;
using Taxation.BusinessLogic;

/// <summary>
/// Summary description for dalDataRules
/// </summary>
namespace Taxation.DataAccess
{

    public class dalDataRules:dalConnection
    {
        public dalDataRules()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Variables
        SqlCommand cmd;
        #endregion


        #region Functions

        //Function To select All Records
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            try
            {
                denAddress objAddressDEN = new denAddress();
                this.pConnMain();
                cmd = new SqlCommand("select * from tbl_DataRules order", this.SqlCon);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }
        //Fun To select records based on SourceID
        public DataSet SelectRules(denDataRules objdenDataRules,string ITR)
        {
            DataSet ds = new DataSet();
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("Proc_DataRules", this.SqlCon);
                cmd.Parameters.AddWithValue("@Vtype", objdenDataRules.Vtype);
                cmd.Parameters.AddWithValue("@AY", objdenDataRules.AY);
                cmd.Parameters.AddWithValue("@nameID", objdenDataRules.NameID);
                cmd.Parameters.AddWithValue("@ITR", ITR);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return ds;
        }
        #endregion

    }
}