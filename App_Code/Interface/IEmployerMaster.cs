namespace Taxation.Interface
{

    /// <summary>
    /// Summary description for IEmployerMaster
    /// </summary>
    interface IEmployerMaster
    {
        int EmpID
        {
            get;
            set;
        }
        int Vtype
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }
        string Address
        {
            get;
            set;
        }
        string PhoneNo
        {
            get;
            set;
        }
        int TypeofEmployer
        {
            get;
            set;
        }
        float PSR
        {
            get;
            set;
        }
        string PAN
        {
            get;
            set;
        }
        string Designation
        {
            get;
            set;
        }
        string NameID
        {
            get;
            set;
        }
        string TAN
        {
            get;
            set;
        }

    }
}