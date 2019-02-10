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
using System.Collections.Generic;

namespace Taxation.BusinessLogic
{

    /// <summary>
    /// Summary description for bllAuditorMaster
    /// </summary>
    public class bllAuditorMaster
    {
        public bllAuditorMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int InsertDataAuditorMaster(denConsultantMast objConsultantMastDEN)
        {
            try
            {
                dalConsultantMast objConsultantMastDAL;
                objConsultantMastDAL = new dalConsultantMast();
                objConsultantMastDAL.InsertConsultantMaster(objConsultantMastDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateDataAuditorMaster(denConsultantMast objConsultantMastDEN)
        {
            try
            {
                dalConsultantMast objConsultantMastDAL;
                objConsultantMastDAL = new dalConsultantMast();
                objConsultantMastDAL.UpdateConsultantMaster(objConsultantMastDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denConsultantMast Select(denConsultantMast objConsultantMastDEN)
        {
            dalConsultantMast objConsultantMastDAL = new dalConsultantMast();
            return objConsultantMastDAL.Select(objConsultantMastDEN);
        }

    }
}