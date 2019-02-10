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
    /// Summary description for bllAssesseeMaster
    /// </summary>
    public class bllAssesseeMaster
    {
        #region Constructors
        public bllAssesseeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        dalAssesseeMaster objAssesseeMasterDAL;
        
        #endregion

        #region Functions
        public void InsertDataMainGrid(denAssesseeMaster objdenAssesseeMaster)
        {
            try
            {
                objAssesseeMasterDAL = new dalAssesseeMaster();
                objAssesseeMasterDAL.InsertDataMainGrid(objdenAssesseeMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 update(denAssesseeMaster objdenAssesseeMaster)
        {
            try
            {
                objAssesseeMasterDAL = new dalAssesseeMaster();
                return objAssesseeMasterDAL.update(objdenAssesseeMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateStatus(string ids)
        {
            try
            {
                objAssesseeMasterDAL = new dalAssesseeMaster();
                objAssesseeMasterDAL.updateStatus(ids);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}