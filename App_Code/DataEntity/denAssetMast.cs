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
    /// Summary description for denAssetMast
    /// </summary>
    public class denAssetMast:IAssetMast
    {
        #region Constructor
        public denAssetMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        string strAssetName,strParticulars,strNameID,strCompanyName,strPurchaseDate,strImproveDate,strAddress,strTownCity,strState,strPinCode,strTenantName,strTenantPAN;

        int intAssetType,intC8,intC7,intIsExempted,intRate,intNoOfShares,intPurchaseCost,intFMV,intPurchaseExp,intImproveCost,intSaleAmount,intTOP,intLTCG;
        int intAssetID,intC1;
        #endregion

        #region Entities
        
        public string AssetNAme
        {
            get
            {
                return strAssetName;
            }
            set
            {
                strAssetName=value;
            }
        }

        public int AssetType
        {
            get
            {
                return intAssetType;
            }
            set
            {
               intAssetType=value;
            }
        }

        #endregion

        #region IAssetMast Members


        public string Particulars
        {
            get
            {
                return strParticulars;
            }
            set
            {
                strParticulars=value;
            }
        }
        public int C1
        {
            get
            {
                return intC1;

            }

            set
            {
                intC1 = value;
            }
        }

        public int C8
        {
            get
            {
                return intC8;
            }
            set
            {
                intC8=value;
            }
        }
        public int C7
        {
            get
            {
                return intC7;
            }
            set
            {
                intC7 = value;
            }
        }

        #endregion

        #region IAssetMast Members


        public string NameID
        {
            get
            {
                return strNameID;
            }
            set
            {
                strNameID=value;
            }
        }

        public int IsExempted
        {
            get
            {
                return intIsExempted;
            }
            set
            {
                intIsExempted=value;
            }
        }

        public string CompanyName
        {
            get
            {
                return strCompanyName;
            }
            set
            {
                strCompanyName=value;
            }
        }

        public int Rate
        {
            get
            {
                return intRate;
            }
            set
            {
               intRate=value;
            }
        }

        public int NoOfShares
        {
            get
            {
                return intNoOfShares;
            }
            set
            {
                intNoOfShares=value;
            }
        }

        public string PurchaseDate
        {
            get
            {
                return strPurchaseDate;
            }
            set
            {
                strPurchaseDate=value;
            }
        }

        public int PurchaseCost
        {
            get
            {
                return intPurchaseCost;
            }
            set
            {
                intPurchaseCost=value;
            }
        }

        public int FMV
        {
            get
            {
                return intFMV;
            }
            set
            {
                intFMV=value;
            }
        }

        public int PurchaseExp
        {
            get
            {
                return intPurchaseExp;
            }
            set
            {
                intPurchaseExp=value;
            }
        }

        public string ImproveDate
        {
            get
            {
                return strImproveDate;
            }
            set
            {
                strImproveDate=value;
            }
        }

        public int ImproveCost
        {
            get
            {
                return intImproveCost;
            }
            set
            {
                intImproveCost=value;
            }
        }

        public int SaleAmount
        {
            get
            {
                return intSaleAmount;
            }
            set
            {
                intSaleAmount=value;
            }
        }

        public string Address
        {
            get
            {
               return strAddress;
            }
            set
            {
                strAddress=value;
            }
        }

        public int TOP
        {
            get
            {
                return intTOP;
            }
            set
            {
                intTOP=value;
            }
        }

        public int LTCG
        {
            get
            {
                return intLTCG;
            }
            set
            {
                intLTCG=value;
            }
        }

        public string Town_City
        {
            get
            {
                return strTownCity;
            }
            set
            {
                strTownCity=value;
            }
        }

        public string State
        {
            get
            {
                return strState;
            }
            set
            {
                strState=value;
            }
        }

        public string PinCode
        {
            get
            {
                return strPinCode;
            }
            set
            {
                strPinCode=value;
            }
        }

        public string TenantName
        {
            get
            {
                return strTenantName;
            }
            set
            {
                strTenantName=value;
            }
        }

        public string TenantPAN
        {
            get
            {
                return strTenantPAN;
            }
            set
            {
                strTenantPAN=value;
            }
        }
        public int AssetID
        {
            get
            {
                return intAssetID;
            }
            set
            {
                intAssetID = value;
            }
        }
        public Int32 VType
        { get; set; }

        #endregion
    }
}