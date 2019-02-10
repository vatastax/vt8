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
    /// Summary description for bllUserMgmt
    /// </summary>
    public class bllUserMgmt
    {
        #region Constructor
        public bllUserMgmt()
        {
            //
            // TODO: Add constructor logic here
            //
         
        }
        #endregion

        #region Variables

        #endregion

        #region Functions
        //=============================================
        //COde to insert username into usermgmt table
        //=============================================
        public int InsertUser(denUserMgmt objUserMgmtDEN)
        {
            try
            {
                dalUserMgmt objUserMgmtDAL = new dalUserMgmt();
                return objUserMgmtDAL.InsertUser(objUserMgmtDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============================================================
        //Code to update that table after userlogout and application end
        //==============================================================
        public int UpdateUser(denUserMgmt objUserMgmtDEN)
        {
            try
            {
                dalUserMgmt objUserMgmtDAL = new dalUserMgmt();
                return objUserMgmtDAL.UpdateUser(objUserMgmtDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========================================================
        //Code to count user,if he is loginned or not
        //===========================================================
        public int CountUser(string UserName)
        {
            try
            {
                dalUserMgmt objUserMgmtDAL = new dalUserMgmt();
                return objUserMgmtDAL.CountUser(UserName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ChangeUserPwd(string Email_id, string old_Pwd, string New_Pwd)
        {
            try
            {
                dalUserMgmt objUserMgmtDal = new dalUserMgmt();
                DataTable dtPwd = new DataTable();
            dtPwd=  objUserMgmtDal.ChangePassword(Email_id, old_Pwd, New_Pwd).Copy();
            return dtPwd;
             
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CheckUserPwd(string Emailid, string oldPwd)
        {
            try
            {
                dalUserMgmt objUserMgmtDal = new dalUserMgmt();
                DataTable dtCheckPwd = new DataTable();
               dtCheckPwd = objUserMgmtDal.CheckCorrectPassword(Emailid, oldPwd ).Copy();
                return dtCheckPwd;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}