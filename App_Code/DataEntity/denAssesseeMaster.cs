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
    /// Summary description for denAssesseeMaster
    /// </summary>
    public class denAssesseeMaster//:IStates
    {
        #region Constructor
        public denAssesseeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region IStates Members

        public Int64 id
        {
            get;
            set;
        }

        public Int64 NameID
        {
            get;
            set;
        }

        public Int64 UserID
        {
            get;
            set;
        }

        public DateTime addedOn
        {
            get;
            set;
        }

        public bool status
        {
            get;
            set;
        }

        public string AY
        {
            get;
            set;
        }

        public string ReturnType
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }



        #endregion
    }
}