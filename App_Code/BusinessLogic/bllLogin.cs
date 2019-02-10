using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
namespace Taxation.BusinessLogic
{


    /// <summary>
    /// Summary description for bllLogin
    /// </summary>
    public class bllLogin
    {
        #region Constructor
        public bllLogin()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        #endregion

        #region Functions
        public denLogin CheckUserStatus(string UserID)
        {
            try
            {
                dalLogin objLoginDAL = new dalLogin();
                return objLoginDAL.CheckUserStatus(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CheckUserNamePassword(denLogin objLoginDEN)
        {
            try
            {
                dalLogin objLoginDAL;
                objLoginDAL = new dalLogin();
                return objLoginDAL.CheckUserNamePassword(objLoginDEN);

            }
            catch (Exception ex)
            {
                    throw ex;
            }
        }

        public int CheckUserName(denLogin objLoginDEN)
        {
            try
            {
                dalLogin objLoginDAL;
                objLoginDAL = new dalLogin();
                return objLoginDAL.CheckUserName(objLoginDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denLogin Select(string username)
        {
            try
            {
                dalLogin objLoginDAL;
                objLoginDAL = new dalLogin();
                return objLoginDAL.Select(username);
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
                dalLogin objLoginDAL;
                objLoginDAL = new dalLogin();
                return objLoginDAL.CreateNewUser(objLoginDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denLogin GetSecretQuestion(string UserName)
        {
            denLogin objLoginDEN;
            dalLogin objLoginDAL;
            objLoginDEN = new denLogin();
            objLoginDAL = new dalLogin();
            objLoginDEN=objLoginDAL.GetSecretQuestion(UserName);
            return objLoginDEN;
        }
        public denLogin GetPassword(string UserName, string Answer)
        {
            denLogin objLoginDEN;
            dalLogin objLoginDAL;
            objLoginDEN = new denLogin();
            objLoginDAL = new dalLogin();
            objLoginDEN = objLoginDAL.GetPassword(UserName,Answer);
            return objLoginDEN;

        }

        public int InsertLoginDetails(denLogin objLoginDEN)
        {
            try
            {
                
                dalLogin objLoginDAL = new dalLogin();
                return objLoginDAL.InsertLoginDetails(objLoginDEN);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================================================
        //COde to update logindetails at the time of logout
        //================================================
        public int UpdateUserDetails(denLogin objLoginDEN)
        {
            try
            {
                dalLogin objLoginDAL = new dalLogin();
                return objLoginDAL.UpdateUserDetails(objLoginDEN);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=====================================================
        //Code o update Logindetails when he logs in
        //=====================================================
        public int UpdateLoginInfo(denLogin objLoginDEN)
        {
            try
            {
                dalLogin objLoginDAL = new dalLogin();
                return objLoginDAL.UpdateLoginInfo(objLoginDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int CountUser(string UserID)
        {
            try
            {
                dalLogin objLoginDAL = new dalLogin();
                return objLoginDAL.CountUser(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAssesseeCount(string userEmail)
        {
            dalLogin objLoginDAL = new dalLogin();
            return objLoginDAL.getAssesseeCount(userEmail);
        }




        #region TDS
        public void InSertTANWithUser(int UserID, string TAN)
        {
            try
            {
                dalLogin objLoginDAL = new dalLogin();
                objLoginDAL.InSertTANWithUser(UserID, TAN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion
    }
}