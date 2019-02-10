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
using System.Collections.Generic;

namespace Taxation.BusinessLogic
{
    /// <summary>
    /// Summary description for bllConsultantMast
    /// </summary>
    public class bllConsultantMast
    {
        #region Constructors
        public bllConsultantMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        dalConsultantMast objConsultantMastDAL;
        #endregion

        #region Functions
        public int InsertConsultantMast(denConsultantMast objConsultantMastDEN)
        {
            try
            {
                objConsultantMastDAL = new dalConsultantMast();
                objConsultantMastDAL.InsertConsultantMaster(objConsultantMastDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
        public int UpdateConsultantMast(denConsultantMast objConsultantMastDEN)
        {
            try
            {
                objConsultantMastDAL = new dalConsultantMast();
                objConsultantMastDAL.UpdateConsultantMaster(objConsultantMastDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<denConsultantMast> Select(Int64 NameID)
        {
            try
            {
                objConsultantMastDAL = new dalConsultantMast();
                return objConsultantMastDAL.Select(NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Int64 ConsultID)
        {
            try
            {
                objConsultantMastDAL = new dalConsultantMast();
                objConsultantMastDAL.Delete(ConsultID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denConsultantMast SelectByConsultID(Int64 ConsultID)
        {
            try
            {
                objConsultantMastDAL = new dalConsultantMast();
                return objConsultantMastDAL.SelectByConsultID(ConsultID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}