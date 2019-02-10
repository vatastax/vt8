namespace Taxation.Interface
{
    /// <summary>
    /// Summary description for Assessee
    /// </summary>
    interface IAssesseeMain
    {
        string Address
        {
            get;
            set;
        }
        string STDCODE
        {
            get;
            set;
        }
        string PhoneNo
        {
            get;
            set;
        }
        string UserName
        {
            get;
            set;
        }
        int Vtype
        {
            get;
            set;
        }
        int Status
        {
            get;
            set;
        }
        string LastName
        {
            get;
            set;
        }
        
        string DateofBirth
        {
            get;
            set;
        }
        string WardCircle
        {
            get;
            set;
        }
        string PANNO
        {
            get;
            set;
        }
        string TANNO
        {
            get;
            set;
        }
        int ResStatus
        {
            get;
            set;
        }
        string EMail
        {
            get;
            set;
        }
        int PEOutIndia
        {
            get;
            set;
        }
        int PEInIndia
        {
            get;
            set;
        }
        string BussNature
        {
            get;
            set;
        }
        
     }
    interface IAssessseeIndividual : IAssesseeMain
    {

        int Salute
        {
            get;
            set;
        }
        string FirstName
        {
            get;
            set;
        }
        string MiddleName
        {
            get;
            set;
        }
        string FatherName
        {
            get;
            set;
        }
        int TypeofAss
        {
            get;
            set;
        }
        string AdhaarNo
        {
            get;
            set;
        }
    }
    interface IAssesseePartner : IAssesseeMain
    {
        int TypeofFirm
        {
            get;
            set;
        }

    }
    interface IAssesseeCompany : IAssesseeMain
    {
        string CompStatus
        {
            get;
            set;
        }
        string CompNature
        {
            get;
            set;
        }
    }
}
