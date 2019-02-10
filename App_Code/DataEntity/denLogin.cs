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
    /// Summary description for denLogin
    /// </summary>
    public class denLogin:ILogin
    {
        #region Constructor
        public denLogin()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        string strUserName, strPassword, strStatus, strPersonName, strSecretQuestion, strSecretAns,
            strSessionID,strLoginTime,strLogOutTime;
        int intLogoutStatus;
        string strPAN;
        #endregion

        #region ILogin Members
        public int LogoutStatus
        {
            get
            {
                return intLogoutStatus;
            }
            set
            {
                intLogoutStatus = value;
            }
        }
        public string SessionID
        {
            get
            {
                return strSessionID;
            }
            set
            {
                strSessionID = value;
            }
        }
        public string LoginTime
        {
            get
            {
                return strLoginTime;
            }
            set
            {
                strLoginTime = value;

            }
        }
        public string LogoutTime
        {
            get
            {
                return strLogOutTime;
            }
            set
            {
                strLogOutTime = value;
            }
        }


        public string UserName
        {
            get
            {
                return strUserName;
            }
            set
            {
                strUserName=value;
            }
        }

        public string Password
        {
            get
            {
                return strPassword;
            }
            set
            {
                strPassword=value;
            }
        }

        public string PersonName
        {
            get
            {
                return strPersonName;
            }
            set
            {
                strPersonName=value;
            }
        }

        public string SecretQuestion
        {
            get
            {
               return strSecretQuestion;
            }
            set
            {
                strSecretQuestion=value;
            }
        }

        public string SecretAns
        {
            get
            {
                return strSecretAns;
            }
            set
            {
                strSecretAns=value;
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

        public string Account_Type
        {
            get;
            set;
        }

        public int Super_User_Id
        {
            get;
            set;
        }

        #endregion
    }
}