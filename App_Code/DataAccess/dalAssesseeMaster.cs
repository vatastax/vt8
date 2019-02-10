using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using Taxation.DataEntity;
namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalAssesseeMaster
    /// </summary>
    public class dalAssesseeMaster:dalConnection
    {
        #region Constructor
        public dalAssesseeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;
        denAssesseeMaster objAssesseeMasterDEN;
        #endregion

        #region Functions
        public void InsertDataMainGrid(denAssesseeMaster objdenAssesseeMaster)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("insert into AssesseeMaster(NameID,UserID,addedOn,status) values(@NameID,@UserID,@addedOn,@status)", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", objdenAssesseeMaster.NameID);
                cmd.Parameters.AddWithValue("@UserID", objdenAssesseeMaster.UserID);
                cmd.Parameters.AddWithValue("@addedOn", objdenAssesseeMaster.addedOn);
                cmd.Parameters.AddWithValue("@status", objdenAssesseeMaster.status);
                cmd.ExecuteNonQuery();
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

        public Int64 update(denAssesseeMaster objdenAssesseeMaster)
        {
            Int64 id = 0;
            try
            {
                this.pConn();
                cmd = new SqlCommand("update AssesseeMaster set AY=@AY,ReturnType=@ReturnType,Amount=@Amount where NameID=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@AY", objdenAssesseeMaster.AY);
                cmd.Parameters.AddWithValue("@ReturnType", objdenAssesseeMaster.ReturnType);
                cmd.Parameters.AddWithValue("@Amount", objdenAssesseeMaster.Amount);
                cmd.Parameters.AddWithValue("@NameID", objdenAssesseeMaster.NameID);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("select id from AssesseeMaster where NameID=@NameID", this.SqlCon);
                cmd2.Parameters.AddWithValue("@NameID", objdenAssesseeMaster.NameID);
                id = Convert.ToInt64(cmd2.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return id;
        }

        public void updateStatus(string ids)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("update AssesseeMaster set status = 0 where id in (@ids)", this.SqlCon);
                cmd.Parameters.AddWithValue("@ids", ids);
                cmd.ExecuteNonQuery();
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

        #endregion
    }
}
