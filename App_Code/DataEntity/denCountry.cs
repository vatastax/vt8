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
    public class denCountry
    {
        public denCountry()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        


        #region IAddress Members

        public int CountryId
        {
            get;
            set;
        }

        public string Country_Name
        { get; set; }

        public string Country_Code
        {
            get;
            set;
        }

        #endregion
    }
}