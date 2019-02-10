using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Query.Interface;

namespace Query.DataEntity
{
    /// <summary>
    /// Summary description for denquery
    /// </summary>
    public class denquery : IQuery
    {
        public denquery()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Variables
        string _name, _email, _subject, _query,_Attachment;

        #endregion
        #region IQuery Members
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }
        public string query
        {
            get
            {
                return _query;
            }
            set
            {
                _query = value;
            }
        }
        public string Attachment
        {
            get
            {
                return _Attachment;
            }
            set
            {
                _Attachment = value;
            }
        }
#endregion

    }
}