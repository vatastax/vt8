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

/// <summary>
/// Summary description for dalAdmin
/// </summary>
/// 
namespace Taxation.DataAccess
{
    public class dalAdmin : dalConnection
    {
        #region Variable
        SqlCommand cmd;
        #endregion

        public dalAdmin()
        {
            
        }

        public void activateUser(Int64 superUserID, string AcType)
        {
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                SqlCommand cmd2 = new SqlCommand("select count(*) as cnt from tbl_UserGroup_Registration where Super_User_ID=@Super_User_ID", this.SqlCon);
                cmd2.Parameters.AddWithValue("@Super_User_ID", superUserID);
                cmd2.Parameters.AddWithValue("@Account_Type", AcType);
                int cnt = Convert.ToInt32(cmd2.ExecuteScalar());
                if (cnt > 0)
                {
                    cmd = new SqlCommand("update tbl_UserGroup_Registration set Is_Login_Active = 'Y' where Super_User_ID=@Super_User_ID", this.SqlCon);
                    cmd.Parameters.AddWithValue("@Super_User_ID", superUserID);
                    cmd.Parameters.AddWithValue("@Account_Type", AcType);
                    cmd.ExecuteNonQuery();
                }
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

        //To Deactive the user for the provided Super ID
        public void deActiveUser(Int32 superUserID)
        {
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("update tbl_User_Info set Is_Locked='Yes' where User_Info_ID=@User_Info_ID", this.SqlCon);
                cmd.Parameters.AddWithValue("@User_Info_ID", superUserID);
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

        //To Deactive the user for the provided EmailID
        public void deActiveUser(string EmailID)
        {
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("update tbl_UserGroup_Registration set Is_Login_Active='N' where EmailID=@EmailID", this.SqlCon);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
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

        public void logoutUser()
        {
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                SqlCommand cmd2 = new SqlCommand("select count(*) from tbl_User_Session_Details where Session_ID=@Session_ID", this.SqlCon);
                cmd2.Parameters.AddWithValue("@Session_ID", HttpContext.Current.Session.SessionID.ToString());
                int cnt = Convert.ToInt32(cmd2.ExecuteScalar());
                if (cnt != 0)
                {
                    cmd = new SqlCommand(@"update tbl_User_Session_Details set Logout_Nature='LogOff' where ID=(select top(1) ID from tbl_User_Session_Details where Session_ID=@Session_ID order by ID desc)", this.SqlCon);
                    cmd.Parameters.AddWithValue("@Session_ID", HttpContext.Current.Session.SessionID.ToString());
                    cmd.ExecuteNonQuery();
                }
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

        public void logoutUser(Int64 SuperID)
        {
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand(@"update tbl_User_Session_Details set Logout_Nature='LogOff' where ID=(select top(1) ID from tbl_User_Session_Details where User_ID=@SuperID order by ID desc)", this.SqlCon);
                cmd.Parameters.AddWithValue("@SuperID", SuperID);
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

        //Unlock the account if already 20+ minutes are passed since it get locked

        public int unlockUser(Int32 superUserID)
        {
            int IsTimePassed = 0;
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                SqlCommand cmd2 = new SqlCommand("select top(1) Logout_Time from tbl_User_Session_Details where User_ID=@superUserID order by id desc", this.SqlCon);
                cmd2.Parameters.AddWithValue("@superUserID", superUserID);
                DateTime dTime = new DateTime();
                dTime = Convert.ToDateTime(cmd2.ExecuteScalar());
                DateTime dTimeCurrent = DateTime.Now;
                if (dTimeCurrent > dTime.AddMinutes(20))
                {
                    cmd = new SqlCommand("update tbl_User_Info set Is_Locked='No' where User_Info_ID=@User_Info_ID", this.SqlCon);
                    cmd.Parameters.AddWithValue("@User_Info_ID", superUserID);
                    cmd.ExecuteNonQuery();
                    IsTimePassed = 1;
                }                
            }
            catch (Exception ex)
            {
                //throw ex;
                cmd = new SqlCommand("update tbl_User_Info set Is_Locked='No' where User_Info_ID=@User_Info_ID", this.SqlCon);
                cmd.Parameters.AddWithValue("@User_Info_ID", superUserID);
                cmd.ExecuteNonQuery();
                IsTimePassed = 1;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return IsTimePassed;
        }

        public string getLoginSession(int superUserID)
        {
            string session_status = "NA";
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("select top(1) Logout_Nature from tbl_User_Session_Details where User_ID=@User_ID order by id desc", this.SqlCon);
                cmd.Parameters.AddWithValue("@User_ID", superUserID);
                session_status = (cmd.ExecuteScalar() != null) ? cmd.ExecuteScalar().ToString() : "FT"; // FT: First Time (for first time login users)
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return session_status;
        }

        public Int32 getLastLoginID(int superUserID)
        {
            Int32 ID = 0;
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("select top(1) ID from tbl_User_Session_Details where User_ID=@User_ID order by ID desc", this.SqlCon);
                cmd.Parameters.AddWithValue("@User_ID", superUserID);
                ID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return ID;
        }

        public tbl_UserRegistration SelectData(int SuperID)
        {
            tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                cmd = new SqlCommand("select * from tbl_UserGroup_Registration where Super_User_Id=@Super_User_Id", this.SqlCon);
                cmd.Parameters.AddWithValue("@Super_User_Id", SuperID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //objtbl_UserRegistration.Can_Change_Password = Convert.ToString(reader["Can_Change_Password"]);                    
                    objtbl_UserRegistration.Password = Convert.ToString(reader["Password"]);
                    objtbl_UserRegistration.User_Name = Convert.ToString(reader["EmailID"]);
                    objtbl_UserRegistration.Last_Name = Convert.ToString(reader["Last_Name"]);
                    objtbl_UserRegistration.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                    objtbl_UserRegistration.Name = Convert.ToString(reader["Name"]);
                    objtbl_UserRegistration.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                    objtbl_UserRegistration.PinCode = Convert.ToInt32(reader["PinCode"]);
                    objtbl_UserRegistration.Telephone = Convert.ToString(reader["Telephone"]);
                    objtbl_UserRegistration.Address1 = Convert.ToString(reader["Address1"]);
                    objtbl_UserRegistration.State = Convert.ToInt32(reader["State"]);
                    objtbl_UserRegistration.EmailID = Convert.ToString(reader["EmailID"]);
                    objtbl_UserRegistration.AccID = (reader.IsDBNull(25) ? 0 : Convert.ToInt64(reader["AccID"]));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return objtbl_UserRegistration;
        }

        public DataTable SelectData(string Account_Type,string Role)
        {
            DataTable dt = new DataTable();
            tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                cmd = new SqlCommand(@"select * from tbl_UserGroup_Registration where Account_Type=@Account_Type and Super_User_Id in (select User_Info_ID from tbl_User_Info where Role=@Role)", this.SqlCon);
                cmd.Parameters.AddWithValue("@Account_Type", Account_Type);
                cmd.Parameters.AddWithValue("@Role", Role);
                SqlDataAdapter adp = new SqlDataAdapter();
                adp = new SqlDataAdapter(cmd);
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

        public int getCGCount(string Grid_Name,string param)
        {
            int cnt = 0;
            tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                cmd = new SqlCommand(@"select DataBinding_Query from tbl_PopulateGrid where Grid_Name=@Grid_Name", this.SqlCon);
                cmd.Parameters.AddWithValue("@Grid_Name", Grid_Name);
                string binding_Qry = Convert.ToString(cmd.ExecuteScalar());
                string[] arr = System.Text.RegularExpressions.Regex.Split(binding_Qry, ",");
                SqlCommand cmd2 = new SqlCommand(@"select Query from sqlQueries where QueryID=@QueryID and QueryTable=@QueryTable", this.SqlCon);
                cmd2.Parameters.AddWithValue("@QueryID", Convert.ToInt32(arr[1]));
                cmd2.Parameters.AddWithValue("@QueryTable", Convert.ToInt32(arr[0]));
                binding_Qry = Convert.ToString(cmd2.ExecuteScalar());
                binding_Qry = binding_Qry.Replace("#", param);
                SqlCommand cmd3 = new SqlCommand(binding_Qry, this.SqlCon);
                SqlDataAdapter adp = new SqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cnt = dt.Rows.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return cnt;
        }

        //Function to check whether this User is associated with any AccID or not
        public int IsAccIDExists(Int64 Super_User_Id)
        {
            int IsExists = 0;
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select ISNULL(AccID,0) from db_Admin.dbo.tbl_UserGroup_Registration where Super_User_Id = @Super_User_Id", this.SqlCon);
                cmd.Parameters.AddWithValue("@Super_User_Id", Super_User_Id);
                IsExists = Convert.ToInt32(cmd.ExecuteScalar());
                return IsExists;
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

        //To update AccID of a User w.r.t. Super_User_Id
        public void Update_User_AccID(Int64 Super_User_Id, string EmailID)
        {
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("update tbl_UserGroup_Registration set AccID = (select top(1) AccID from VatasSolution.dbo.Accounts where A_Email_ID1 = @EmailID order by AccID desc) where Super_User_Id=@Super_User_Id", this.SqlCon);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Super_User_Id", Super_User_Id);
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

        //To update AccID with 2408 for Free Account
        public void Update_User_AccID(Int64 Super_User_Id)
        {
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("update tbl_UserGroup_Registration set AccID = 2408 where Super_User_Id=@Super_User_Id", this.SqlCon);                
                cmd.Parameters.AddWithValue("@Super_User_Id", Super_User_Id);
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

        //To insert initial record in the table "tbl_OnlinePaymentRecd"
        public void Add_OnlinePayment(tbl_OnlinePaymentRecd objtbl_OnlinePaymentRecd)
        {
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("insert into tbl_OnlinePaymentRecd(Merchant_Transaction_Id,Amount,Date_of_Transaction,Customer_Name,Customer_Email) values(@Merchant_Transaction_Id,@Amount,@Date_of_Transaction,@Customer_Name,@Customer_Email)", this.SqlCon);
                cmd.Parameters.AddWithValue("@Merchant_Transaction_Id", objtbl_OnlinePaymentRecd.Merchant_Transaction_Id);
                cmd.Parameters.AddWithValue("@Amount", objtbl_OnlinePaymentRecd.Amount);
                cmd.Parameters.AddWithValue("@Date_of_Transaction", objtbl_OnlinePaymentRecd.Date_of_Transaction);
                cmd.Parameters.AddWithValue("@Customer_Name", objtbl_OnlinePaymentRecd.Customer_Name);
                cmd.Parameters.AddWithValue("@Customer_Email", objtbl_OnlinePaymentRecd.Customer_Email);
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

    }

    public class dalPath : dalConnection
    {
        #region Variable
        SqlCommand cmd;
        #endregion
        public dalPath()
        {

        }

        public denPath Select(string project)
        {
            denPath objdenPath = new denPath();
            try
            {
                this.pConnAdmin();
                denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                cmd = new SqlCommand("select * from tbl_Path where Path_Name=@Path_Name", this.SqlCon);
                cmd.Parameters.AddWithValue("@Path_Name", project);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    objdenPath.Host = Convert.ToString(reader["Host"]);
                    objdenPath.ID_Admin = 0;// Convert.ToInt32(reader["ID_Admin"]);
                    objdenPath.Path = Convert.ToString(reader["Path"]);
                    objdenPath.Path_ID = Convert.ToInt32(reader["Path_ID"]);
                    objdenPath.Path_Name = Convert.ToString(reader["Path_Name"]);
                    objdenPath.Path_Project = Convert.ToString(reader["Path_Project"]);

                    objdenPath.DBName = Convert.ToString(reader["DBName"]);
                    objdenPath.username = Convert.ToString(reader["username"]);
                    objdenPath.password = Convert.ToString(reader["password"]);
                }
                return objdenPath;
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