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
    /// Summary description for bllCompDetails
    /// </summary>
    public class bllCompDetails
    {
        #region Constructors
        public bllCompDetails()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        dalCompanyDetails objCompanyDetailsDAL;
        #endregion

        #region Functions
        public int InsertCompanyDetails(denCompanyDetails objCompanyDetailsDEN)
        {
            try
            {
                objCompanyDetailsDAL = new dalCompanyDetails();
                return objCompanyDetailsDAL.InsertCompanyDetails(objCompanyDetailsDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}