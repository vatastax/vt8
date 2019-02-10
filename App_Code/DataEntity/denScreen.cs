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
    /// Summary description for denScreen
    /// </summary>
 
    public class denScreen:IScreen
    {
        public denScreen()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Variables
        string strVoucher, strAssessYear, strComboItems, strIsComboAttach, strLabelText, strRadioVisible, strgridIndex;
        string strScreenTitle;
        int intID;
#endregion


        #region IScreen Members

        public string Voucher
        {
            get
            {
                return strVoucher;
            }
            set
            {
                strVoucher = value;

            }
        }

        public string AssessYear
        {
            get
            {
                return strAssessYear;
            }
            set
            {
                strAssessYear = value;
            }
        }

        public string ComboItems
        {
            get
            {
                return strComboItems;
            }
            set
            {
                strComboItems=value;
            }
        }

        public string IsComboAttach
        {
            get
            {
                return strIsComboAttach;
            }
            set
            {
                strIsComboAttach=value;
            }
        }

        public string LabelText
        {
            get
            {
                return strLabelText;
            }
            set
            {
                strLabelText=value;
            }
        }

        public string RadioVisible
        {
            get
            {
                return strRadioVisible;
            }
            set
            {
                strRadioVisible=value;
            }
        }

        public string GridIndex
        {
            get
            {
                return strgridIndex;
            }
            set
            {
                strgridIndex=value;
            }
        }

        public string ScreenTitle
        {
            get
            {
                return strScreenTitle;
            }
            set
            {
                strScreenTitle = value;
            }
        }

        public int ID
        {
            get
            {
                return intID;
            }
            set
            {
                intID = value;
            }
        }

        public string Theme
        { get; set; }

        //Added by Mudit For TDS
        public int ChallanID
        {
            get;
            set;
        }
        public char FillDatabase
        {
            get;
            set;
        }

        public string GridName
        { get; set; }

        public string Page_ID
        { get; set; }

        public string Page_SubModule_ID
        { get; set; }

        public string IsMaster
        { get; set; }

        public string GridHeader
        {
            get;
            set;
        }

        public int popupID
        {
            get;
            set;
        }

        public string ScreenListing
        {
            get;
            set;
        }

        public string dbtnID
        { get; set; }

        #endregion

    }
}