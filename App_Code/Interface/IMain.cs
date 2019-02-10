namespace Taxation.Interface
{

    /// <summary>
    /// Summary description for IMain
    /// </summary>
    interface IMain
    {
        string UserName
        {
            get;
            set;
        }
        string PAN
        {
            get;
            set;
        }
        int Status
        {
            get;
            set;
        }
        string FirstName
        {
            get;
            set;
        }
        string DispStatus
        {
            get;
            set;
        }
        string AssYear
        {
            get;
            set;
        }
        string DueDate
        {
            get;
            set;
        }

        string AuditorName
        {
            get;
            set;
        }
        string LastName
        {
            get;
            set;
        }
        string MiddleName
        {
            get;
            set;
        }

        string CombinedName
        {
            get;
            set;
        }
    }
}