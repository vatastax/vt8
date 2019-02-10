namespace Taxation.Interface
{

    /// <summary>
    /// Summary description for IConsultantMast
    /// </summary>
    interface IConsultantMast
    {
        int ConsultID
        {
            get;
            set;
        }
        int Vtype
        {
            get;
            set;
        }
        string AuditorName
        {
            get;
            set;
        }
        string Address
        {
            get;
            set;
        }
        string Phone
        {
            get;
            set;
        }
        string MembershipNo
        {
            get;
            set;
        }
        string PAN
        {
            get;
            set;
        }
        string FirmName
        {
            get;
            set;
        }
    }
}