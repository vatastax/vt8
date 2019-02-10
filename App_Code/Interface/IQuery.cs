namespace Query.Interface
{
    interface IQuery
    {
        string name
        {
            get;
            set;
        }
        string email
        {
            get;
            set;
        }
        string subject
        {
            get;
            set;
        }
        string query
        {
            get;
            set;
        }
    }
}