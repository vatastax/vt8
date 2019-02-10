using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.Interface;
namespace Taxation.DataEntity
{

    /// <summary>
    /// Summary description for denAssetTrans
    /// </summary>
    public class denAssetTrans : IAssetTrans
    {
        #region Constructor
        public denAssetTrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

      

        #region Entities

        public int AssetID { get; set; }
        public string NameID { get; set; }
        public int AssetType { get; set; }
        public int IsExempted { get; set; }
        public string CompanyName { get; set; }
        public int Rate { get; set; }
        public int NoOfShares { get; set; }
        public string PurchaseDate { get; set; }
        public int PurchaseCost { get; set; }
        public int FMV { get; set; }
        public int PurchaseExp { get; set; }
        public string ImproveDate { get; set; }
        public int ImproveCost { get; set; }
        public int SaleAmount { get; set; }
        public string Address { get; set; }
        public Int16 TOP { get; set; }
        public int LTCG { get; set; }
        public string Town_City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string TenantName { get; set; }
        public string TenantPAN { get; set; }
        public Int32 VType { get; set; }


        #endregion

    
    }
}