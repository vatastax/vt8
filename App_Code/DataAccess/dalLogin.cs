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
using System.Collections.Generic;
namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalLogin
    /// </summary>
    public class dalLogin : dalConnection
    {
        #region Constructor
        public dalLogin()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;
        int i;
        #endregion

        #region Functions
        public int CountUser(string UserID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proccountuser", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
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
        
        public denLogin CheckUserStatus(string UserID)
        {
            try
            {
                this.pConn();
                denLogin objLoginDEN = new denLogin();
                cmd = new SqlCommand("proccheckuserstatus", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    objLoginDEN.LogoutStatus = Convert.ToInt32(reader["Logout"]); 
                }
                return objLoginDEN;
                
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

        public denLogin Select(string username)
        {
            try
            {
                this.pConn();
                denLogin objLoginDEN = new denLogin();
                //cmd = new SqlCommand("select * from db_Admin.dbo.tbl_UserGroup_Registration where EmailID=@username", this.SqlCon);
                cmd = new SqlCommand("select * from db_Admin.dbo.tbl_UserGroup_Registration where EmailID=@username", this.SqlCon);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    objLoginDEN.PAN = "";// Convert.ToString(reader["PAN"]);
                    objLoginDEN.Password = Convert.ToString(reader["Password"]);
                    objLoginDEN.PersonName = Convert.ToString(reader["Name"]) + " " + Convert.ToString(reader["Last_Name"]);
                    objLoginDEN.UserName = Convert.ToString(reader["EmailID"]);
                    objLoginDEN.Account_Type = Convert.ToString(reader["Account_Type"]);
                    objLoginDEN.Super_User_Id = Convert.ToInt32(reader["Super_User_Id"]);

                }
                return objLoginDEN;

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

        //Following method is to return the no of assessees w.r.t. User
        public DataTable getAssesseeCount(string userEmail)
        {
            DataTable dt;
            try
            {
                //if (HttpContext.Current.Session["Project"].ToString() == "tds2")
                //    this.pConnTDS2();
                //else
                    this.pConn();
                cmd = new SqlCommand(@"select * from NameMast where username=@username", this.SqlCon);
                cmd.Parameters.AddWithValue("@username", userEmail);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
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

        public int InsertLoginDetails(denLogin objLoginDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procinsertlogindetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", objLoginDEN.UserName);
                cmd.Parameters.AddWithValue("@SessionID", objLoginDEN.SessionID);
                cmd.Parameters.AddWithValue("@LoginTime", objLoginDEN.LoginTime);
                //cmd.Parameters.AddWithValue("@LogoutTime", objLoginDEN.LogoutStatus);
                cmd.Parameters.AddWithValue("@LogoutStatus", objLoginDEN.LogoutStatus);
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
        //To update logindetails table information when he logs in
        //like update sessionID,LoginTime,LogoutStatus to 0
        public int UpdateLoginInfo(denLogin objLoginDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdatelogininfo", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", objLoginDEN.UserName);
                cmd.Parameters.AddWithValue("@SessionID", objLoginDEN.SessionID);
                cmd.Parameters.AddWithValue("@LoginTime", objLoginDEN.LoginTime);
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
        //To update Logindetails table information when a user logout properly 
        public int UpdateUserDetails(denLogin objLoginDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdatelogindetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", objLoginDEN.UserName);
                cmd.Parameters.AddWithValue("@LogoutTime", objLoginDEN.LogoutTime);
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
            
        public int CheckUserNamePassword(denLogin objLoginDEN)
        {
            SqlParameter returnvalue, rv;
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("chk_Login", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", objLoginDEN.UserName);
                returnvalue = cmd.Parameters.Add("rv", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                if (Convert.ToInt32(cmd.Parameters["rv"].Value) == 1)
                    return 2;
                else
                  return  CheckPassword(objLoginDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CheckPassword(denLogin objLoginDEN)
        {
            SqlParameter returnvalue, rv;
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("chk_pwd", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", objLoginDEN.UserName);
                cmd.Parameters.AddWithValue("@pwd", objLoginDEN.Password);
                returnvalue = cmd.Parameters.Add("rv", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                if (Convert.ToInt32(cmd.Parameters["rv"].Value) == 1)
                    return 3;
                else return 0;
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
        public denLogin GetPassword(string UserName,string Answer)
            {
                try
                {
                    this.pConnAdmin();
                    denLogin objLoginDEN = new denLogin();
                    cmd = new SqlCommand("procgetpassword", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Answer", Answer);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objLoginDEN.Password = Convert.ToString(reader["password"]);
                    }
                    return objLoginDEN;

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


        public int CheckUserName(denLogin objLoginDEN)
        {
            SqlParameter returnvalue, rv;
            try
            {
                this.pConn();
                cmd = new SqlCommand("chk_Login", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", objLoginDEN.UserName);
                returnvalue = cmd.Parameters.Add("rv", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
             
                if (Convert.ToInt32(cmd.Parameters["rv"].Value) == 0)
                    return 2;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public int CreateNewUser(denLogin objLoginDEN)
        {
            try
            {
                this.pConn();

                cmd = new SqlCommand("procadduser", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", objLoginDEN.PersonName);
                cmd.Parameters.AddWithValue("@UserName", objLoginDEN.UserName);
                cmd.Parameters.AddWithValue("@PAN", objLoginDEN.PAN);
                cmd.Parameters.AddWithValue("@Password", objLoginDEN.Password);
                cmd.Parameters.AddWithValue("@SecretQuestion", objLoginDEN.SecretQuestion);
                cmd.Parameters.AddWithValue("@SecretAns", objLoginDEN.SecretAns);

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

        public denLogin GetSecretQuestion(string UserName)
        {
            try
            {
                this.pConnAdmin();
                denLogin objLoginDEN = new denLogin();
                cmd = new SqlCommand("procgetsecretquestion", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objLoginDEN.SecretQuestion = Convert.ToString(reader["SecurityQuestion"]);
                }
                return objLoginDEN;

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



        #region TDS
        public void InSertTANWithUser(int UserID, string TAN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("if not exists (select TAN from tbl_User_TANMapping where User_ID=@UserID and TAN=@TAN)insert into tbl_User_TANMapping(User_ID,TAN) values(@UserID,@TAN)", this.SqlCon);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@TAN",TAN);
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

        #endregion

    }
}