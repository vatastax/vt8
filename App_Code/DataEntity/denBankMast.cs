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

/// <summary>
/// Summary description for denBankMast
/// </summary>
/// 
namespace Taxation.DataEntity
{

    public class denBankMast:IBankMast
    {
        #region Constructor
        public denBankMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables

        int intBankID, intAccountType;
        Int64 intAssesseeID;
        string strBankName, strMICRCode, strAddress, strAccountNo, strECS;
        #endregion

        #region Entities
        #endregion

        #region IBankMast Members

        public int BankID
        {
            get
            {
                return intBankID;
            }
            set
            {
                intBankID = value;
            }
        }

        public Int64 AssesseeID
        {
            get
            {
                return intAssesseeID;
            }
            set
            {
                intAssesseeID = value;
            }
        }

        public string BankName
        {
            get
            {
                return strBankName;
            }
            set
            {
                strBankName = value;
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
                strMICRCode = value;
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
                strAddress = value;
            }
        }

        public Int32 AccountType
        {
            get
            {
                return intAccountType;
            }
            set
            {
                intAccountType = value;
            }
        }

        public string AccountNo
        {
            get
            {
                return strAccountNo;
            }
            set
            {
                strAccountNo = value;
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
                strECS = value;
            }
        }

        #endregion
    }
}
