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
    /// Summary description for denMain
    /// </summary>
    public class denMain : IMain
    {
        #region Constructor
        public denMain()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion
        #region Variables
        string strUserName, strPAN, strFirstName, strDispStatus, strAssYear, strDueDate, strAuditorName;
        int intStatus;
        string strLastName, strMiddleName, strCombinedName;
        #endregion

        #region Entities
        #endregion

        #region IMain Members

        public string UserName
        {
            get
            {
                return strUserName;
            }
            set
            {
                strUserName = value;
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

        public int Status
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
            }
        }

        public string FirstName
        {
            get
            {
                return strFirstName;
            }
            set
            {
                strFirstName = value;
            }
        }

        public string DispStatus
        {
            get
            {
                return strDispStatus;
            }
            set
            {
                strDispStatus = value;
            }
        }
        public string AssYear
        {
            get
            {
                return strAssYear;
            }
            set
            {
                strAssYear = value;
            }
        }
        public string DueDate
        {
            get
            {
                return strDispStatus;
            }
            set
            {
                strDispStatus = value;
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
        public string LastName
        {
            get
            {
                return strLastName;

            }
            set
            {
                strLastName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return strMiddleName;
            }
            set
            {
                strMiddleName = value;
            }
        }
        public string CombinedName
        {
            get
            {
                return strCombinedName;
            }
            set
            {
                strCombinedName = value;
            }
        }

        public string NameID
        {
            get;
            set;
        }

        public string DateofBirth
        {
            get;
            set;
        }

        #endregion

        #region Menu

        public int Menu_id
        {
            get;
            set;
        }
        public int Parent_Menu
        { get; set; }

        public int Menu_Level
        {
            get;
            set;
        }

        public string Menu_Name
        {
            get;
            set;
        }
        public string Menu_Link
        {
            get;
            set;
        }
        public int Menu_Order
        { get; set; }

        public int Menu_Status
        { get; set; }

        public char Is_Deleted
        { get; set; }

        public string Project_Name
        { get; set; }
        public int Page_ID
        { get; set; }
        public int Sub_ModuleID
        { get; set; }
        public int ID_Admin
        { get; set; }

        public string ITRCheck
        { get; set; }

        public string AssesseeCheck
        { get; set; }



        #endregion

    }
}