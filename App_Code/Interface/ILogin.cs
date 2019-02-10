namespace Taxation.Interface
{
    /// <summary>
    /// Summary description for ILogin
    /// </summary>
    interface ILogin
    {
       int LogoutStatus
        {
            get;
            set;
        }

        string LogoutTime
        {
            get;
            set;
        }
        string LoginTime
        {
            get;
            set;
        }
        string SessionID
        {
            get;
            set;
        }
        string UserName
        {
            get;
            set;
        }
        string Password
        {
            get;
            set;
        }
        string PersonName
        {
            get;
            set;
        }
        string SecretQuestion
        {
            get;
            set;

        }
        string SecretAns
        {
            get;
            set;
        }
        string PAN
        {
            get;
            set;
        }
    }
}