using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Taxation.DataEntity;
using Taxation.DataAccess;
namespace Taxation.BusinessLogic
{


    /// <summary>
    /// Summary description for bllStatus
    /// </summary>
    public class bllStatus
    {
        #region Constructors
        public bllStatus()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        dalStatus objStatusDAL;
        
        #endregion

        #region Functions
        public List<denStatus> Select(string ReturnType)
        {
            try
            {
                objStatusDAL = new dalStatus();
                return objStatusDAL.Select(ReturnType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SelectVType(string id)
        {
            try
            {
                objStatusDAL = new dalStatus();
                return objStatusDAL.SelectVType(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SelectVType(string id, string ITR)
        {
            try
            {
                objStatusDAL = new dalStatus();
                return objStatusDAL.SelectVType(id, ITR);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}