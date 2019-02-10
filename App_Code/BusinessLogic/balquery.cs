using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Query.DataAccess;
using Query.DataEntity;

namespace Query.BusinessLogic
{
    /// <summary>
    /// Summary description for balquery
    /// </summary>
    public class balquery
    {
        #region constructor
        public balquery()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion
        #region variables
        dalquery objdalquery;
        #endregion

        #region function

        public string Insertquery(denquery objdenquery)
        {
            try
            {
                objdalquery = new dalquery();
                objdalquery.insertquery(objdenquery);
                return "Data inserted successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}