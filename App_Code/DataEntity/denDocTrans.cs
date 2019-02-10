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
    /// Summary description for denDocTrans
    /// </summary>
    public class denDocTrans:IDoctrans
    {
        public denDocTrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region IDoctrans Members
        #region Variables
        string strNameID,
                strIncomeFileSection,
                strReturnType,
                strRecieptNo,
                
                strBankName,
                strAccountType,
                strMICRCode,
                strAccountNumber,
                strAddressofBranch,
                strECS,
                strRefundMethod,
                strName,
                strPAN,
                strPlace,
                strDesignation,
                strDate,
                strFlat,
                strPremises,
                strRoad,
                strArea,
                strCity,
                strPIN,
                strAuth_Name,
                strAuth_Father_Name,
                strAuth_Desig,
                strAuth_Place,
                strWardCircle,
                strFilingDate;
        int intFBTFileSection,
                intReturnFiledUS,
                intFirstReturn,
                intState,
                intrepAssessee;
                
                
        #endregion

        public string NameID
        {
            get
            {
                return strNameID;
            }
            set
            {
                strNameID = value ;
            }
        }

        public string IncomeFileSection
        {
            get
            {
                return strIncomeFileSection;
            }
            set
            {
                strIncomeFileSection=value;
            }
        }

        public int FBTFileSection
        {
            get
            {
                return intFBTFileSection;
            }
            set
            {
                intFBTFileSection=value;
            }
        }

        public string ReturnType
        {
            get
            {
                return strReturnType;
            }
            set
            {
                strReturnType=value;
            }
        }

        public string RecieptNo
        {
            get
            {
                return strRecieptNo;
            }
            set
            {
               strRecieptNo=value;
            }
        }

        public string FilingDate
        {
            get
            {
                return strFilingDate;
            }
            set
            {
                strFilingDate=value;
            }
        }

        public int ReturnFiledUS
        {
            get
            {
                return intReturnFiledUS;
            }
            set
            {
                intReturnFiledUS=value;
            }
        }

        public int FirstReturn
        {
            get
            {
                return intFirstReturn;
            }
            set
            {
                intFirstReturn=value;
            }
        }

        public bool IsGovernedByPortugeseCivilCodeunder5A
        {
            get;
            set;
        }

        #endregion

        #region IDoctrans Members


        public string BankNAme
        {
            get
            {
                return strBankName ;
            }
            set
            {
                strBankName = value ;
            }
        }

        public string AccountType
        {
            get
            {
                return strAccountType;
            }
            set
            {
                strAccountType=value;
            }
        }

        public string MICRCode
        {
            get
            {
                return strMICRCode;
            }
            set
            {
                strMICRCode=value;
            }
        }

        public string AccountNumber
        {
            get
            {
                return strAccountNumber;
            }
            set
            {
                strAccountNumber = value ;
            }
        }

        public string AddressofBranch
        {
            get
            {
                return strAddressofBranch;
            }
            set
            {
               strAddressofBranch=value;
            }
        }

        public string ECS
        {
            get
            {
                return strECS;
            }
            set
            {
                strECS=value;
            }
        }

        public string RefundMethod
        {
            get
            {
                return strRefundMethod;
            }
            set
            {
               strRefundMethod=value;
            }
        }

        #endregion

        #region IDoctrans Members


        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName=value;
            }
        }

        public string PAN
        {
            get
            {
                return strPAN;
            }
            set
            {
                strPAN = value;
            }
        }

        public string Place
        {
            get
            {
                return strPlace;
            }
            set
            {
                strPlace=value;
            }
        }

        public string Designation
        {
            get
            {
                return strDesignation;
            }
            set
            {
               strDesignation=value;
            }
        }

        public string Date
        {
            get
            {
                return strDate;
            }
            set
            {
                strDate=value;
            }
        }

        public string Flat
        {
            get
            {
                return strFlat;
            }
            set
            {
                strFlat=value;
            }
        }

        public string Premises
        {
            get
            {
                return strPremises;
            }
            set
            {
                strPremises=value;
            }
        }

        public string Road
        {
            get
            {
                return strRoad;
            }
            set
            {
               strRoad=value;
            }
        }

        public string Area
        {
            get
            {
                return strArea;
            }
            set
            {
                strArea=value;
            }
        }

        public int State
        {
            get
            {
                return intState;
            }
            set
            {
                intState=value;
            }
        }

        public string City
        {
            get
            {
                return strCity;
            }
            set
            {
                strCity=value;
            }
        }

        public string PIN
        {
            get
            {
                return strPIN;
            }
            set
            {
                strPIN=value;
            }
        }

        public int RepAssessee
        {
            get
            {
                return intrepAssessee;
            }
            set
            {
                intrepAssessee=value;
            }
        }

        public string Auth_Name
        {
            get
            {
                return strAuth_Name;
            }
            set
            {
                strAuth_Name=value;
            }
        }

        public string Auth_Father_Name
        {
            get
            {
                return strAuth_Father_Name;
            }
            set
            {
                strAuth_Father_Name = value ;
            }
        }

        public string Auth_Desig
        {
            get
            {
                return strAuth_Desig;
            }
            set
            {
               strAuth_Desig=value;
            }
        }

        public string Auth_Place
        {
            get
            {
                return strAuth_Place;
            }
            set
            {
               strAuth_Place=value;
            }
        }

        public string WardCircle
        {
            get
            {
                return strWardCircle;
            }
            set
            {
                strWardCircle=value;
            }
        }

        // for Username:

        public string username
        {
            get;
            set;
        }

        public Int64 Business_Nature1
        { get; set; }

        public Int64 Business_Nature2
        { get; set; }

        public Int64 Business_Nature3
        { get; set; }

        public string Business1_Trade1
        { get; set; }

        public string Business1_Trade2
        { get; set; }

        public string Business1_Trade3
        { get; set; }

        public string Business2_Trade1
        { get; set; }

        public string Business2_Trade2
        { get; set; }

        public string Business2_Trade3
        { get; set; }

        public string Business3_Trade1
        { get; set; }

        public string Business3_Trade2
        { get; set; }

        public string Business3_Trade3
        { get; set; }

        public string SpouseName
        { get; set; }

        public string SpousePAN
        { get; set; }

        public bool IsReturnByTRP
        { get; set; }

        public string TRP_PIN
        { get; set; }

        public string TRP_Name
        { get; set; }

        public double TRP_AmtToBePaid
        {
            get;
            set;
        }
        public string STC_CodeNumber
        {
            get;
            set;
        }
        #endregion
    }
}