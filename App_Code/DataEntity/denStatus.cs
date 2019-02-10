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
    /// Summary description for denStatus
    /// </summary>
    public class denStatus
    {
        #region Constructor
        public denStatus()
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



        #region IStatus Members

        public Int32 id
        { get; set; }

        public string Status
        { get; set; }

        public string TagVal
        { get; set; }

        public string ReturnType
        {
            get;
            set;
        }
        public string VType_URL
        {
            get;
            set;
        }
     

        #endregion
    }
}