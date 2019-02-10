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
    /// Summary description for denUserMgmt
    /// </summary>
    public class denUserMgmt:IUserMgmt
    {
        #region Constructor
        public denUserMgmt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        string strUserID;
        #endregion
        #region Entities

        public string UserID
        {
            get
            {
                return strUserID;
            }
            set
            {
                strUserID = value;
            }
        }

        #endregion
    }
}