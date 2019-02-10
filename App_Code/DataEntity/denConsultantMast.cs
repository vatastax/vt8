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

/// <summary>
/// Summary description for denConsultantMast
/// </summary>
{
    public class denConsultantMast : IConsultantMast
    {
        #region Constructor
        public denConsultantMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        int intConsultID, intVtype;
        string strAuditorName, strAddress, strPhone, strMembershipNo, strPAN, strFirmName;
        #endregion

        #region Entities
        #endregion

        #region IConsultantMast Members

        public int ConsultID
        {
            get
            {
                return intConsultID;
            }
            set
            {
                intConsultID = value;
            }
        }

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

        public string AuditorName
        {
            get
            {
                return strAuditorName;
            }
            set
            {
                strAuditorName = value;
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

        public string Phone
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

        public string MembershipNo
        {
            get
            {
                return strMembershipNo;
            }
            set
            {
                strMembershipNo = value;
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

        public string FirmName
        {
            get
            {
                return strFirmName;
            }
            set
            {
                strFirmName = value;
            }
        }

        public Int64 NameID
        {
            get;
            set;
        }

        #endregion
    }
}