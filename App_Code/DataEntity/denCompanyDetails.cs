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
/// Summary description for denCOmpanyDetails
/// </summary>
/// 
namespace Taxation.DataEntity
{
    public class denCompanyDetails : ICompanyDetails
    {
        public denCompanyDetails()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Variables
        int intCompany_Nature, intState;
        string strCompName,
                    strAddress1,
                    strAddress2,
                    strAddress3,
                    strAddress4,
                    strCity,
                    strPIN,
                    strCompPan,
                    strAssesseeID,
                    strFormNO;

        #endregion

        #region ICompanyDetails Members

        public int Company_Nature
        {
            get
            {
                return intCompany_Nature;
            }
            set
            {
                intCompany_Nature = value;
            }
        }

        public string CompName
        {
            get
            {
                return strCompName;
            }
            set
            {
                strCompName = value;
            }
        }

        public string Address1
        {
            get
            {
                return strAddress1;
            }
            set
            {
                strAddress1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return strAddress2;
            }
            set
            {
                strAddress2 = value;
            }
        }

        public string Address3
        {
            get
            {
                return strAddress3;
            }
            set
            {
                strAddress3 = value;
            }
        }

        public string Address4
        {
            get
            {
                return strAddress4;
            }
            set
            {
                strAddress4 = value;
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
                strCity = value;
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
                intState = value;
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
                strPIN = value;
            }
        }

        public string CompPan
        {
            get
            {
                return strCompPan;
            }
            set
            {
                strCompPan = value;
            }
        }

        public string AssesseeID
        {
            get
            {
                return strAssesseeID;
            }
            set
            {
                strAssesseeID = value;
            }
        }
        public string FormNO
        {
            get
            {
                return strFormNO;
            }
            set
            {
                strFormNO = value;
            }
        }

        #endregion
    }
}