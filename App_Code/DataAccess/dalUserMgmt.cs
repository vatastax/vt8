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
using Taxation.DataEntity;
namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalUserMgmt
    /// </summary>
    public class dalUserMgmt:dalConnection
    {
        #region Constructor
        public dalUserMgmt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;
        #endregion

        #region Functions
        public int InsertUser(denUserMgmt objUserMgmtDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procInsertuser", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", objUserMgmtDEN.UserID);
                cmd.ExecuteNonQuery();
                return 0;

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

        public int UpdateUser(denUserMgmt objUserMgmtDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdateuser", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", objUserMgmtDEN.UserID);
                cmd.ExecuteNonQuery();
                return 0;

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

        public int CountUser(string UserName)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proccountuser", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserName);
                return Convert.ToInt32(cmd.ExecuteScalar());
                

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
        //change user psssword
        public DataTable ChangePassword(string Emailid, string oldPwd,string NewPwd)
        {
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("update tbl_UserGroup_Registration set Password=@p,confirm_Password=@p where EmailId=@e and Password=@p1", this.SqlCon);
                cmd.Parameters.AddWithValue("@p", NewPwd);
                cmd.Parameters.AddWithValue("@p1", oldPwd);
                cmd.Parameters.AddWithValue("@e", Emailid);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select * from tbl_UserGroup_Registration where password=@pwd and EmailId=@eid", this.SqlCon);
                cmd.Parameters.AddWithValue("@pwd", oldPwd);
                cmd.Parameters.AddWithValue("@eid", Emailid);
                DataTable dtChgPwd = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dtChgPwd.Load(dr);
                }
                return dtChgPwd;
                

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
        //check user's pwd is coorect or not
        public DataTable CheckCorrectPassword(string EmailId, string Pwd)
        {
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("select * from tbl_UserGroup_Registration where EmailId=@e and Password=@p", this.SqlCon);
                cmd.Parameters.AddWithValue("@p", Pwd);
              
                cmd.Parameters.AddWithValue("@e", EmailId);
                cmd.ExecuteNonQuery();
              
                DataTable dtChkPwd = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dtChkPwd.Load(dr);
                }
                return dtChkPwd;


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