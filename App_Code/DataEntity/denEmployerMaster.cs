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
    /// Summary description for denEmployerMaster
    /// </summary>
    public class denEmployerMaster:IEmployerMaster
    {
        #region Constructor
        public denEmployerMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        int intEmpID, intVtype, intTypeofEmpr;
        float fltPSR;
        string strName, strAddress, strPhoneNo, strPAN, strDesignation, strNameID, strTAN;

        #endregion

        #region Entities


        #endregion

        #region IEmployerMaster Members
        public string NameID
        {
            get
            {
                return strNameID;
            }
            set
            {
                strNameID = value;
            }
        }
        public int EmpID
        {
            get
            {
                return intEmpID;
            }
            set
            {
                intEmpID = value;
            }
        }

        public int Vtype
        {
            get
            {
                return intVtype;
            }
            set
            {
                intVtype = value;
            }
        }

        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }

        public string Address
        {
            get
            {
                return strAddress;
            }
            set
            {
                strAddress = value;
            }
        }

        public string PhoneNo
        {
            get
            {
                return strPhoneNo;
            }
            set
            {
                strPhoneNo=value;
            }
        }

        public int TypeofEmployer
        {
            get
            {
                return intTypeofEmpr;
            }
            set
            {
               intTypeofEmpr=value;
            }
        }

        public float PSR
        {
            get
            {
                return fltPSR;
            }
            set
            {
                fltPSR = value;
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
                strPAN=value;
            }
        }

        public string Designation
        {
            get
            {
                return strDesignation;
            }
            set
            {
                strDesignation=value;
            }
        }

        public string TAN
        {
            get
            {
                return strTAN;
            }
            set
            {
                strTAN = value;
            }
        }

        public string Flat
        { get; set; }

        public string Premises
        { get; set; }

        public string Road
        { get; set; }

        public string Area
        { get; set; }

        public string City
        { get; set; }

        public string PIN
        { get; set; }

        public string State
        { get; set; }

        #endregion
    }
}