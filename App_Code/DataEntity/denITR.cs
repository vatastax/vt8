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
    /// Summary description for denITR
    /// </summary>
    public class denITR
    {
        #region Constructor
        public denITR()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region denITR Members

        public Int64 ID
        { get; set; }

        public Int64 NameID
        { get; set; }

        public string AY
        {
            get;
            set;
        }

        public string ITRType
        { get; set; }

        public string XML_Data
        { get; set; }

        public DateTime AddedOn
        { get; set; }

        public string XMLFile
        { get; set; }


        #endregion

        #region tbl_ITRTypes Members

        public Int64 id
        { get; set; }

        public string title
        { get; set; }

        public string detail
        {
            get;
            set;
        }

        public string Project
        { get; set; }

        public string itrtype_xml
        { get; set; }

       
        #endregion
    }
}