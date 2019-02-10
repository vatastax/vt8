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
    /// Summary description for denCompAdditional
    /// </summary>
    public class denCompAdditional:ICompAdditional
    {
        #region Constructor
        public denCompAdditional()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        string strCompNature;
        string strAmalgamatingComp;
        string strAmalgametedComp;
        string strDemergedComp;
        string strResultingComp;
        string strDescription;
        int intCode;
        string strCompName;
        string strCompAddress;
        string strCompPAN;
        string strCity;
        #endregion

        #region Properties

        #endregion

        #region ICompAdditional Members
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
        public string CompPAN
        {
            get
            {
                return strCompPAN;
            }
            set
            {
                strCompPAN = value;
            }
        }
        public string CompNature
        {
            get
            {
                return strCompNature;
            }
            set
            {
                strCompNature = value;
            }
        }

        public string AmalgamatingComp
        {
            get
            {
                return strAmalgamatingComp;
            }
            set
            {
                strAmalgamatingComp = value;
            }
        }

        public string AmalgametedComp
        {
            get
            {
                return strAmalgametedComp;
            }
            set
            {
                strAmalgametedComp = value;
            }
        }

        public string DemergedComp
        {
            get
            {
                return strDemergedComp;
            }
            set
            {
                strDemergedComp = value;
            }
        }

        public string ResultingComp
        {
            get
            {
                return strResultingComp;
            }
            set
            {
                strResultingComp = value;
            }
        }

        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
            }
        }

        public int Code
        {
            get
            {
                return intCode;
            }
            set
            {
                intCode = value;

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
                strCompName = value; ;
            }
        }

        public string CompAddress
        {
            get
            {
                return strCompAddress;
            }
            set
            {
                strCompAddress = value;
            }
        }

        #endregion
    }
}
