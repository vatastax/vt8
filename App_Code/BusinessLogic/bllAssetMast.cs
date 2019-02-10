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
    /// Summary description for bllAssetMast
    /// </summary>
    public class bllAssetMast
    {
        #region Constructor
        public bllAssetMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        dalAssetMast objAssetMastDAL;
        
        #endregion

        #region Functions

        public List<denAssetMast> GetComboData()
        {
            try
            {
                objAssetMastDAL = new dalAssetMast();

                return objAssetMastDAL.GetComboData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<denAssetMast> GetParticularsByIndex(int intIndex)
        {

            try
            {
                objAssetMastDAL = new dalAssetMast();

                return objAssetMastDAL.getParticularsByIndex(intIndex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertAssetTrans(denAssetMast objAssetMastDEN)
        {
            dalAssetMast objAssetMastDAL;
            try
            {
                objAssetMastDAL = new dalAssetMast();
                objAssetMastDAL.InsertAssetTrans(objAssetMastDEN);
                return 0;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public int UpdateAssetTrans(denAssetMast objAssetMastDEN)
        {
            dalAssetMast objAssetMastDAL;
            try
            {
                objAssetMastDAL = new dalAssetMast();
                objAssetMastDAL.UpdateDataAssetTrans(objAssetMastDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectCompleteAssetDetail(string NameID)
        {
            dalAssetMast objAssetMastDAL;
            try
            {
                objAssetMastDAL = new dalAssetMast();
                return objAssetMastDAL.SelectCompleteAssetDetail(NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public DataTable SelectCompleteAssetDetail(string NameID, string AssetName)
        {
            dalAssetMast objAssetMastDAL;
            try
            {
                objAssetMastDAL = new dalAssetMast();
                return objAssetMastDAL.SelectCompleteAssetDetail(NameID, AssetName);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        public void Delete(Int64 AssetID)
        {
            dalAssetMast objAssetMastDAL;
            try
            {
                objAssetMastDAL = new dalAssetMast();
                objAssetMastDAL.Delete(AssetID);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        #endregion
    }
}