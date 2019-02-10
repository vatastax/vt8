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
/// <summary>
/// Summary description for denSTax
/// </summary>
/// 
namespace Taxation.DataEntity
{
    public class denSTax
    {
        public denSTax()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region Service Members


        public Int64 id
        {
            get;
            set;
        }

        public string title
        {
            get;
            set;
        }

        public string SubClauseNo
        {
            get;
            set;
        }

        public string ServiceCode
        {
            get;
            set;
        }

        #endregion

        

    }

    public class denAbatementNotifications
    {
        public denAbatementNotifications()
        {

        }

        #region Abatement Notification Members


        public Int64 id
        {
            get;
            set;
        }

        public Int64 ServiceID
        {
            get;
            set;
        }

        public string Notification_Number
        {
            get;
            set;
        }


        #endregion
    }

    public class denExemptionSerials
    {
        public denExemptionSerials()
        {

        }

        #region Exemption Serials Members


        public Int64 id
        {
            get;
            set;
        }

        public Int64 ServiceID
        {
            get;
            set;
        }

        public string NotSerialNo
        {
            get;
            set;
        }


        #endregion

        //#region Service Selection Process Members


        //public Int64 id
        //{
        //    get;
        //    set;
        //}

        //public Int64 ServiceID
        //{
        //    get;
        //    set;
        //}

        //public string NotSerialNo
        //{
        //    get;
        //    set;
        //}


        //#endregion
    }
}
