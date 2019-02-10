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
namespace Taxation.Interface
{

    /// <summary>
    /// Summary description for IAssetMast
    /// </summary>
    interface IAssetTrans
    {
        int AssetID { get; set; }
        string NameID { get; set; }
        int AssetType { get; set; }
        int IsExempted { get; set; }
        string CompanyName { get; set; }
        int Rate { get; set; }
        int NoOfShares { get; set; }
        string PurchaseDate { get; set; }
        int PurchaseCost { get; set; }
        int FMV { get; set; }
        int PurchaseExp { get; set; }
        string ImproveDate { get; set; }
        int ImproveCost { get; set; }
        int SaleAmount { get; set; }
        string Address { get; set; }
        Int16 TOP { get; set; }
        int LTCG { get; set; }
        string Town_City { get; set; }
        string State { get; set; }
        string PinCode { get; set; }
        string TenantName { get; set; }
        string TenantPAN { get; set; }
        Int32 VType { get; set; }
    }
}