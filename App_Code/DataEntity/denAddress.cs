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
    /// Summary description for denAddress
    /// </summary>
    public class denAddress:IAddress
    {
        public denAddress()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Variables
        string strNameID, strFlat, strPremises, strRoad, strArea, strCity, strState, strPIN,strAddress,
            strSTDCODE,strPhone;
        int intVtype;
        #endregion


        #region IAddress Members
        public int Vtype
        {
            get
            {
                return intVtype; 
            }
            set
            {
                intVtype = value;
            }
        }
        public string STDCODE
        {
            get
            {
                return strSTDCODE;
            }
            set
            {
                strSTDCODE = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return strPhone;
            }
            set
            {
                strPhone = value;
            }
        }
        public string NameID
        {
            get
            {
                return strNameID;
            }
            set
            {
                strNameID = value;
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
                strFlat = value;
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
                strPremises = value;
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
        public string mobile1
        {
            get;
            set;
        }

        public string mobile2
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        #endregion
    }
}