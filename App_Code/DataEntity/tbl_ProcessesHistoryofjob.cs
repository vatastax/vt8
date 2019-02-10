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
    /// Summary description for dentbl_ProcessesHistoryofjob
    /// </summary>
    public class dentbl_ProcessesHistoryofjob
    {
        #region Constructor
        public dentbl_ProcessesHistoryofjob()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion


        #region Itbl_ProcessesHistoryofjob Members

        public int ID
        { get; set; }

        public Int64 MasterID
        { get; set; }

        public Int64 Next_UserID
        { get; set; }

        public Int64 Previous_UserID
        { get; set; }

        public string Date_Time_Stamp
        {
            get;
            set;
        }

        public Int64 Priority_of_Job
        {
            get;
            set;
        }

        public string Job_Status
        {
            get;
            set;
        }

        public string Reason_for_Delay
        { get; set; }

        public string Supervisor
        { get; set; }

        public string Is_Sent
        { get; set; }


        #endregion
    }
}