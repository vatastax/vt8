using System;

namespace Taxation.Interface
{

    /// <summary>
    /// Summary description for IBankMast
    /// </summary>
    interface IBankMast
    {
        int BankID
        {
            get;
            set;
        }
        Int64 AssesseeID
        {
            get;
            set;
        }
        string BankName
        {
            get;
            set;
        }
        string MICRCode
        {
            get;
            set;
        }
        string Address
        {
            get;
            set;
        }
        int AccountType
        {
            get;
            set;
        }
        string AccountNo
        {
            get;
            set;
        }
        string ECS
        {
            get;
            set;
        }
    }

}