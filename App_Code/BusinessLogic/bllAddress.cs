using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataAccess;
using Taxation.DataEntity;
namespace Taxation.BusinessLogic
{
    /// <summary>
    /// Summary description for bllAddress
    /// </summary>
    public class bllAddress
    {
        #region Constructors
        public bllAddress()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        dalAddress objAddressDAL;
        #endregion

        #region Functions
        public int InsertAddress(denAddress objAddressDEN)
        {
            try
            {
                objAddressDAL = new dalAddress();
                objAddressDAL.InsertAddress(objAddressDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public denAddress GetAddress(string PAN)
        {
            try
            {
                denAddress objAddressDEN;
                objAddressDAL = new dalAddress();
                objAddressDEN = objAddressDAL.GetAddress(PAN);
                return objAddressDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateAddress(denAddress objAddressDEN)
        {
            try
            {
                objAddressDAL = new dalAddress();
                objAddressDAL.UpdateAddress(objAddressDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}