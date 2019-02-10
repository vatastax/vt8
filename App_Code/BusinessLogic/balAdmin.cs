using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxation.DataAccess;
using System.Data;
using Taxation.DataEntity;
using System.Data.SqlClient;


/// <summary>
/// Summary description for balAdmin
/// </summary>
/// 
namespace Taxation.BusinessLogic
{
      
    public class balAdmin
    {
        #region Variable
        SqlCommand cmd;
        #endregion

        #region constructor
        public balAdmin()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion
        #region variables
        dalAdmin objdalAdmin;
        dalPath objdalPath;
        
        
        #endregion

        #region function
               
        public denPath Select(string project)
        {
            try
            {
                objdalPath = new dalPath();
                return objdalPath.Select(project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void activateUser(Int64 superUserID, string AcType)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                objdalAdmin.activateUser(superUserID, AcType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deActiveUser(Int32 superUserID)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                objdalAdmin.deActiveUser(superUserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Deactive the user for the provided EmailID
        public void deActiveUser(string EmailID)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                objdalAdmin.deActiveUser(EmailID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getLoginSession(int superUserID)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                return objdalAdmin.getLoginSession(superUserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 getLastLoginID(int superUserID)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                return objdalAdmin.getLastLoginID(superUserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int unlockUser(Int32 superUserID)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                return objdalAdmin.unlockUser(superUserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbl_UserRegistration SelectData(int SuperID)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                return objdalAdmin.SelectData(SuperID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To update AccID of a User w.r.t. Super_User_Id
        public void Update_User_AccID(Int64 Super_User_Id, string EmailID)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                objdalAdmin.Update_User_AccID(Super_User_Id, EmailID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To update AccID with 2408 for Free Account
        public void Update_User_AccID(Int64 Super_User_Id)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                objdalAdmin.Update_User_AccID(Super_User_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectData(string Account_Type, string Role)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                return objdalAdmin.SelectData(Account_Type, Role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To insert initial record in the table "tbl_OnlinePaymentRecd"
        public void Add_OnlinePayment(tbl_OnlinePaymentRecd objtbl_OnlinePaymentRecd)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                objdalAdmin.Add_OnlinePayment(objtbl_OnlinePaymentRecd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void logoutUser()
        //{
        //    try
        //    {
        //        objdalAdmin = new dalAdmin();
        //        objdalAdmin.logoutUser();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //this function execute at the same place instead of going to the data layer as there was a problem while it was going to Data Later, an Error "Object Moved to Here" used to come so this was the final solution that i could execute here only.
        public void logoutUser()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
            tbl_UserRegistration objtbl_User = new tbl_UserRegistration();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd2 = new SqlCommand("select count(*) from tbl_User_Session_Details where Session_ID=@Session_ID", con);
                cmd2.Parameters.AddWithValue("@Session_ID", HttpContext.Current.Session.SessionID.ToString());
                int cnt = Convert.ToInt32(cmd2.ExecuteScalar());
                if (cnt != 0)
                {
                    cmd = new SqlCommand(@"update tbl_User_Session_Details set Logout_Nature='LogOff' where ID=(select top(1) ID from tbl_User_Session_Details where Session_ID=@Session_ID order by ID desc)", con);
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
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void logoutUser(Int64 SuperID)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                objdalAdmin.logoutUser(SuperID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getCGCount(string Grid_Name, string param)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                return objdalAdmin.getCGCount(Grid_Name,param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Function to check whether this User is associated with any AccID or not
        public int IsAccIDExists(Int64 Super_User_Id)
        {
            try
            {
                objdalAdmin = new dalAdmin();
                return objdalAdmin.IsAccIDExists(Super_User_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }

}