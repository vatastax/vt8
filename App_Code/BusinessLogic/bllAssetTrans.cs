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
    /// Summary description for bllAssetTrans
    /// </summary>
    public class bllAssetTrans
    {
        #region Constructor
        public bllAssetTrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        dalAssetTrans objAssetTransDAL;
        
        #endregion

        #region Functions

        public List<denAssetTrans> Select(Int32 AssetID)
        {
            dalAssetTrans objAssetTransDAL;
            try
            {
                objAssetTransDAL = new dalAssetTrans();
                return objAssetTransDAL.Select(AssetID);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public void Delete(Int64 AssetID)
        {
            dalAssetTrans objAssetTransDAL;
            try
            {
                objAssetTransDAL = new dalAssetTrans();
                objAssetTransDAL.Delete(AssetID);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        #endregion
    }
}