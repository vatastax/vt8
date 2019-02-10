using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using Taxation.DataEntity;

namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalAssetTrans
    /// </summary>
    /// 
    public class dalAssetTrans:dalConnection
    {
        #region Constructor
        public dalAssetTrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;
        #endregion

        #region Functions

        public List<denAssetTrans> Select(Int32 AssetID)
        {
            DataTable dt = new DataTable();
            List<denAssetTrans> objList = new List<denAssetTrans>();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from AssetTrans where AssetID=@AssetID", this.SqlCon);
                cmd.Parameters.AddWithValue("@AssetID", AssetID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    denAssetTrans objdenAssetTrans = new denAssetTrans();
                    objdenAssetTrans.Address = reader.GetString(14);
                    objdenAssetTrans.AssetID = reader.GetInt32(0);
                    objdenAssetTrans.AssetType = reader.GetInt32(2);
                    objdenAssetTrans.CompanyName = reader.GetString(4);
                    objdenAssetTrans.FMV = reader.GetInt32(9);
                    objdenAssetTrans.ImproveCost = reader.GetInt32(12);
                    objdenAssetTrans.ImproveDate = reader.GetString(11);
                    objdenAssetTrans.IsExempted = reader.GetInt32(3);
                    objdenAssetTrans.LTCG = reader.GetInt32(16);
                    objdenAssetTrans.NameID = reader.GetString(1);
                    objdenAssetTrans.NoOfShares = reader.GetInt32(6);
                    objdenAssetTrans.PinCode = reader.GetString(19);
                    objdenAssetTrans.PurchaseCost = reader.GetInt32(8);
                    objdenAssetTrans.PurchaseDate = reader.GetString(7);
                    objdenAssetTrans.PurchaseExp = reader.GetInt32(10);
                    objdenAssetTrans.Rate = reader.GetInt32(5);
                    objdenAssetTrans.SaleAmount = reader.GetInt32(13);
                    objdenAssetTrans.State = reader.GetString(18);
                    objdenAssetTrans.TenantName = reader.GetString(20);
                    objdenAssetTrans.TenantPAN = reader.GetString(21);
                    //objdenAssetTrans.TOP = reader.GetInt16(15);
                    objdenAssetTrans.Town_City = reader.GetString(17);
                    //objdenAssetTrans.VType = reader.GetInt32(22);
                    objList.Add(objdenAssetTrans);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return objList;
        }

        public void Delete(Int64 AssetID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("delete from assettrans where AssetID=@AssetID", this.SqlCon);
                cmd.Parameters.AddWithValue("@AssetID", AssetID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        #endregion

    }
}