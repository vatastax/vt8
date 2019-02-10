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
/// Summary description for dalAssessee
/// </summary>
/// 
namespace Taxation.DataEntity
{
    public class denAssesseeMain : IAssesseeMain
    {
        #region Constructor
        public denAssesseeMain()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        int intVtype, intStatus, intResStatus, intPEOutIndia, intPEInIndia, intTypeofAss;
        string strUserName, strLastName, strDOB, strWardCircle, strPAN, strTAN, strEmail, strBussNature,
            strSTDCODE, strPhone, strAddress,strAdhaar,strMobile1;

        #endregion

        #region Entities
        public string Mobile1
        {
            get
            {
                return strMobile1;
            }
            set
            {
                strMobile1 = value;
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
        public string STDCODE
        {
            get
            {
                return strSTDCODE;
            }
            set
            {
                strSTDCODE = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return strPhone;
            }
            set
            {
                strPhone = value;
            }
        }

        public string UserName
        {
            get
            {
                return strUserName;
            }
            set
            {
                strUserName = value;
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

        public int Status
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
            }
        }
        public string LastName
        {
            get
            {
                return strLastName;
            }
            set
            {
                strLastName = value;
            }
        }
        public string DateofBirth
        {
            get
            {
                return strDOB;
            }
            set
            {
                strDOB = value;
            }
        }
        public string WardCircle
        {
            get
            {
                return strWardCircle;
            }
            set
            {
                strWardCircle = value;
            }
        }
        public string PANNO
        {
            get
            {
                return strPAN;
            }
            set
            {
                strPAN = value;
            }
        }
        public string TANNO
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
        public int ResStatus
        {
            get
            {
                return intResStatus;
            }
            set
            {
                intResStatus = value;
            }
        }
        public string EMail
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }
        public int PEOutIndia
        {
            get
            {
                return intPEOutIndia;
            }
            set
            {
                intPEOutIndia = value;
            }
        }

        public int PEInIndia
        {
            get
            {
                return intPEInIndia;
            }
            set
            {
                intPEInIndia = value;
            }
        }

        public string BussNature
        {
            get
            {
                return strBussNature;
            }
            set
            {
                strBussNature = value;
            }
        }

        public string AdhaarNo
        {
            get
            {
                return strAdhaar;
            }
            set
            {
                strAdhaar = value;
            }
        }
        public int TypeofAss
        {
            get
            {
                return intTypeofAss;
            }
            set
            {
                intTypeofAss = value;
            }
        }


        #endregion




    }
    public class denAssesseeIndividual : IAssessseeIndividual
    {
        #region Variables
        int intSalute, intTypeofAss;
        string strFirstName, strMiddleName, strFatherName, strUserName;
        int intVtype, intStatus, intResStatus, intPEOutIndia, intPEInIndia;
        string strLastName, strDOB, strWardCircle, strPAN, strTAN, strEmail, strBussNature;
        string strSTDCODE, strPhone, strAddress,strAdhaar;
        #endregion

        #region IAssessseeIndividual Members

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
        public string STDCODE
        {
            get
            {
                return strSTDCODE;
            }
            set
            {
                strSTDCODE = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return strPhone;
            }
            set
            {
                strPhone = value;
            }
        }

        public int Salute
        {
            get
            {
                return intSalute;
            }
            set
            {
                intSalute = value;
            }
        }

        public string FirstName
        {
            get
            {
                return strFirstName;
            }
            set
            {
                strFirstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return strMiddleName;
            }
            set
            {
                strMiddleName = value;
            }
        }

        public string FatherName
        {
            get
            {
                return strFatherName;
            }
            set
            {
                strFatherName = value;
            }
        }

        public int TypeofAss
        {
            get
            {
                return intTypeofAss;
            }
            set
            {
                intTypeofAss = value;
            }
        }

        public Int32 no_of_dependents
        {
            get;
            set;
        }

        public string NameID
        {
            get;
            set;
        }

        public string AdhaarNo
        {
            get
            {
                return strAdhaar;
            }
            set
            {
                strAdhaar = value;
            }

        }
        #endregion



        #region IAssesseeMain Members

        public string UserName
        {
            get
            {
                return strUserName;
            }
            set
            {
                strUserName = value;
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

        public int Status
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
            }
        }
        public string LastName
        {
            get
            {
                return strLastName;
            }
            set
            {
                strLastName = value;
            }
        }
        public string DateofBirth
        {
            get
            {
                return strDOB;
            }
            set
            {
                strDOB = value;
            }
        }
        public string WardCircle
        {
            get
            {
                return strWardCircle;
            }
            set
            {
                strWardCircle = value;
            }
        }
        public string PANNO
        {
            get
            {
                return strPAN;
            }
            set
            {
                strPAN = value;
            }
        }
        public string TANNO
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
        public int ResStatus
        {
            get
            {
                return intResStatus;
            }
            set
            {
                intResStatus = value;
            }
        }
        public string EMail
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }
        public int PEOutIndia
        {
            get
            {
                return intPEOutIndia;
            }
            set
            {
                intPEOutIndia = value;
            }
        }

        public int PEInIndia
        {
            get
            {
                return intPEInIndia;
            }
            set
            {
                intPEInIndia = value;
            }
        }

        public string BussNature
        {
            get
            {
                return strBussNature;
            }
            set
            {
                strBussNature = value;
            }
        }

        public string EmployerCategory
        {
            get;
            set;
        }


        #endregion

        #region Service Tax Members

        public string ServiceTaxRegNo
        {
            get;
            set;
        }

        #endregion


    }
    public class denAssesseePartner : IAssesseePartner
    {
        #region Variables
        int intTypeofFirm;
        int intVtype, intStatus, intResStatus, intPEOutIndia, intPEInIndia;
        string strUserName, strLastName, strDOB, strWardCircle, strPAN, strTAN, strEmail, strBussNature;
        string strSTDCODE, strPhone, strAddress;
        #endregion

        #region IAssesseePartner Members

        public int TypeofFirm
        {
            get
            {
                return intTypeofFirm;
            }
            set
            {
                intTypeofFirm = value;
            }
        }

        #endregion



        #region IAssesseeMain Members
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
        public string STDCODE
        {
            get
            {
                return strSTDCODE;
            }
            set
            {
                strSTDCODE = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return strPhone;
            }
            set
            {
                strPhone = value;
            }
        }
        public string UserName
        {
            get
            {
                return strUserName;
            }
            set
            {
                strUserName = value;
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

        public int Status
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
            }
        }
        public string LastName
        {
            get
            {
                return strLastName;
            }
            set
            {
                strLastName = value;
            }
        }
        public string DateofBirth
        {
            get
            {
                return strDOB;
            }
            set
            {
                strDOB = value;
            }
        }
        public string WardCircle
        {
            get
            {
                return strWardCircle;
            }
            set
            {
                strWardCircle = value;
            }
        }
        public string PANNO
        {
            get
            {
                return strPAN;
            }
            set
            {
                strPAN = value;
            }
        }
        public string TANNO
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
        public int ResStatus
        {
            get
            {
                return intResStatus;
            }
            set
            {
                intResStatus = value;
            }
        }
        public string EMail
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }
        public int PEOutIndia
        {
            get
            {
                return intPEOutIndia;
            }
            set
            {
                intPEOutIndia = value;
            }
        }

        public int PEInIndia
        {
            get
            {
                return intPEInIndia;
            }
            set
            {
                intPEInIndia = value;
            }
        }

        public string BussNature
        {
            get
            {
                return strBussNature;
            }
            set
            {
                strBussNature = value;
            }
        }

        #endregion
    }
    public class denAssesseeCompany : IAssesseeCompany
    {
        #region Variables
        string strCompStatus, strCompNature;
        int intVtype, intStatus, intResStatus, intPEOutIndia, intPEInIndia;
        string strUserName, strLastName, strDOB, strWardCircle, strPAN, strTAN, strEmail, strBussNature;
        string strAddress, strSTDCODE, strPhone;
        #endregion
        #region IAssesseeCompany Members

        public string CompStatus
        {
            get
            {
                return strCompStatus;
            }
            set
            {
                strCompStatus = value;
            }
        }

        public string CompNature
        {
            get
            {
                return strCompNature;
            }
            set
            {
                strCompNature = value;
            }
        }

        #endregion



        #region IAssesseeMain Members
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
        public string STDCODE
        {
            get
            {
                return strSTDCODE;
            }
            set
            {
                strSTDCODE = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return strPhone;
            }
            set
            {
                strPhone = value;
            }
        }

        public string UserName
        {
            get
            {
                return strUserName;
            }
            set
            {
                strUserName = value;
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

        public int Status
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
            }
        }
        public string LastName
        {
            get
            {
                return strLastName;
            }
            set
            {
                strLastName = value;
            }
        }
        public string DateofBirth
        {
            get
            {
                return strDOB;
            }
            set
            {
                strDOB = value;
            }
        }
        public string WardCircle
        {
            get
            {
                return strWardCircle;
            }
            set
            {
                strWardCircle = value;
            }
        }
        public string PANNO
        {
            get
            {
                return strPAN;
            }
            set
            {
                strPAN = value;
            }
        }
        public string TANNO
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
        public int ResStatus
        {
            get
            {
                return intResStatus;
            }
            set
            {
                intResStatus = value;
            }
        }
        public string EMail
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }
        public int PEOutIndia
        {
            get
            {
                return intPEOutIndia;
            }
            set
            {
                intPEOutIndia = value;
            }
        }

        public int PEInIndia
        {
            get
            {
                return intPEInIndia;
            }
            set
            {
                intPEInIndia = value;
            }
        }

        public string BussNature
        {
            get
            {
                return strBussNature;
            }
            set
            {
                strBussNature = value;
            }
        }
        #endregion
    }

    public class denAssesseeLog
    {
        public Int64 id
        { get; set; }

        public Int64 AssesseeID
        { get; set; }

        public DateTime OnDate
        { get; set; }

        public int Status_Challan_Deposit_Later
        { get; set; }
    }
}
