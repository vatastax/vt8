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
    /// Summary description for denStates
    /// </summary>
    public class denStates:IStates
    {
        #region Constructor
        public denStates()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        string intStateCode;
        string strStateName;
        #endregion



        #region IStates Members

        public string StateCode
        {
            get
            {
                return intStateCode;
            }
            set
            {
                intStateCode=value;
            }
        }

        public string StateName
        {
            get
            {
                return strStateName;
            }
            set
            {
                strStateName=value;
            }
        }

        #endregion
    }
}