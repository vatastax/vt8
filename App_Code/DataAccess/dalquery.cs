using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Query.DataEntity;

namespace Query.DataAccess
{
    /// <summary>
    /// Summary description for dalquery
    /// </summary>
    public class dalquery : dalConnection
    {
        public dalquery()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region variable
        SqlCommand cmd;
        #endregion
        #region functions
        public string insertquery(denquery objdenquery)
        {
        
            try
             {
                 this.pConnMain();
                cmd = new SqlCommand("Proc_StoreUserQuery", this.SqlCon);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name",objdenquery.name);
                cmd.Parameters.AddWithValue("@email",objdenquery.email);

                cmd.Parameters.AddWithValue("@subject",objdenquery.subject);
                cmd.Parameters.AddWithValue("@query",objdenquery.query);
                cmd.Parameters.AddWithValue("@attachment", objdenquery.Attachment);
                cmd.ExecuteNonQuery();
                return "Data Inserted Successfully";
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        
        
        

        
    
        #endregion
    }
}