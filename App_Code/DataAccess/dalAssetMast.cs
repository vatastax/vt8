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
    /// Summary description for dalAssetMast
    /// </summary>
    /// 
    public class dalAssetMast:dalConnection
    {
        #region Constructor
        public dalAssetMast()
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

        public List<denAssetMast>GetComboData()
        {
            denAssetMast objAssetMastDEN;
            try
            {
                List<denAssetMast> genComboData = new List<denAssetMast>();
                this.pConn();
                cmd = new SqlCommand("fillComboAssetMaster", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objAssetMastDEN = new denAssetMast();
                    objAssetMastDEN.AssetNAme = Convert.ToString(reader["AssetNAme"]);
                    objAssetMastDEN.AssetType = Convert.ToInt16(reader["AssetType"]);
                    genComboData.Add(objAssetMastDEN);

                }
                reader.Close();
                return genComboData;
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

        public List<denAssetMast> getParticularsByIndex(int intIndex)
        {
            denAssetMast objAssetMastDEN;
            try
            {
                List<denAssetMast> genAssetMast = new List<denAssetMast>();
                this.pConn();
                cmd = new SqlCommand("procGetGridDataAssetMast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@C4", intIndex);
                
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objAssetMastDEN = new denAssetMast();
                    objAssetMastDEN.Particulars = Convert.ToString(reader["C3"]);
                    objAssetMastDEN.C8 = Convert.ToInt16(reader["C8"]);
                    objAssetMastDEN.C7 = Convert.ToInt16(reader["C7"]);
                    objAssetMastDEN.C1 = Convert.ToInt32(reader["C1"]);

                    genAssetMast.Add(objAssetMastDEN);


                }
                reader.Close();
                //this.SqlCon.Close();
                return genAssetMast;
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

        public int InsertAssetTrans(denAssetMast objAssetMastDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procinsertassettrans", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objAssetMastDEN.NameID);
                cmd.Parameters.AddWithValue("@AssetType", objAssetMastDEN.AssetType);
                cmd.Parameters.AddWithValue("@IsExempted", objAssetMastDEN.IsExempted);
                cmd.Parameters.AddWithValue("@CompanyName", objAssetMastDEN.CompanyName);
                cmd.Parameters.AddWithValue("@Rate", objAssetMastDEN.Rate);
                cmd.Parameters.AddWithValue("@NoOfShares", objAssetMastDEN.NoOfShares);
                cmd.Parameters.AddWithValue("@PurchaseDate", objAssetMastDEN.PurchaseDate);
                cmd.Parameters.AddWithValue("@PurchaseCost", objAssetMastDEN.PurchaseCost);
                cmd.Parameters.AddWithValue("@FMV", objAssetMastDEN.FMV);
                cmd.Parameters.AddWithValue("@PurchaseExp", objAssetMastDEN.PurchaseExp);
                cmd.Parameters.AddWithValue("@ImproveDate", objAssetMastDEN.ImproveDate);
                cmd.Parameters.AddWithValue("@ImproveCost", objAssetMastDEN.ImproveCost);
                cmd.Parameters.AddWithValue("@SaleAmount", objAssetMastDEN.SaleAmount);
                cmd.Parameters.AddWithValue("@Address", objAssetMastDEN.Address);
                cmd.Parameters.AddWithValue("@TOP", objAssetMastDEN.TOP);
                cmd.Parameters.AddWithValue("@LTCG", objAssetMastDEN.LTCG);
                cmd.Parameters.AddWithValue("@TownCity", objAssetMastDEN.Town_City);
                cmd.Parameters.AddWithValue("@State", objAssetMastDEN.State);
                cmd.Parameters.AddWithValue("@PinCode", objAssetMastDEN.PinCode);
                cmd.Parameters.AddWithValue("@TenantName", objAssetMastDEN.TenantName);
                cmd.Parameters.AddWithValue("@TenantPAN", objAssetMastDEN.TenantPAN);
                cmd.Parameters.AddWithValue("@VType", objAssetMastDEN.VType);

                cmd.ExecuteNonQuery();
                return 0;
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

        public int UpdateDataAssetTrans(denAssetMast objAssetMastDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdateassettrans", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssetID", objAssetMastDEN.AssetID);
                cmd.Parameters.AddWithValue("@NameID", objAssetMastDEN.NameID);
                cmd.Parameters.AddWithValue("@AssetType", objAssetMastDEN.AssetType);
                cmd.Parameters.AddWithValue("@IsExempted", objAssetMastDEN.IsExempted);
                cmd.Parameters.AddWithValue("@CompanyName", objAssetMastDEN.CompanyName);
                cmd.Parameters.AddWithValue("@Rate", objAssetMastDEN.Rate);
                cmd.Parameters.AddWithValue("@NoOfShares", objAssetMastDEN.NoOfShares);
                cmd.Parameters.AddWithValue("@PurchaseDate", objAssetMastDEN.PurchaseDate);
                cmd.Parameters.AddWithValue("@PurchaseCost", objAssetMastDEN.PurchaseCost);
                cmd.Parameters.AddWithValue("@FMV", objAssetMastDEN.FMV);
                cmd.Parameters.AddWithValue("@PurchaseExp", objAssetMastDEN.PurchaseExp);
                cmd.Parameters.AddWithValue("@ImproveDate", objAssetMastDEN.ImproveDate);
                cmd.Parameters.AddWithValue("@ImproveCost", objAssetMastDEN.ImproveCost);
                cmd.Parameters.AddWithValue("@SaleAmount", objAssetMastDEN.SaleAmount);
                cmd.Parameters.AddWithValue("@Address", objAssetMastDEN.Address);
                cmd.Parameters.AddWithValue("@TOP", objAssetMastDEN.TOP);
                cmd.Parameters.AddWithValue("@LTCG", objAssetMastDEN.LTCG);
                cmd.Parameters.AddWithValue("@TownCity", objAssetMastDEN.Town_City);
                cmd.Parameters.AddWithValue("@State", objAssetMastDEN.State);
                cmd.Parameters.AddWithValue("@PinCode", objAssetMastDEN.PinCode);
                cmd.Parameters.AddWithValue("@TenantName", objAssetMastDEN.TenantName);
                cmd.Parameters.AddWithValue("@TenantPAN", objAssetMastDEN.TenantPAN);

                cmd.ExecuteNonQuery();
                return 0;
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

        public DataTable SelectCompleteAssetDetail(string NameID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("procselectdataassettransMain", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }

        public DataTable SelectCompleteAssetDetail(string NameID, string AssetName)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("procselectdataassettransMainByAssetType", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AssetName", AssetName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
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