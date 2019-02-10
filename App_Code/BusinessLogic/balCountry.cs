using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxation.DataAccess;
using System.Data;

namespace Taxation.BusinessLogic
{
    /// <summary>
    /// Summary description for balCountry
    /// </summary>
    public class balCountry
    {
        #region constructor
        public balCountry()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion
        #region variables
        dalCountry objdalCountry;
        #endregion

        #region function

       
        public DataTable Select()
        {
            try
            {
                objdalCountry = new dalCountry();
                return objdalCountry.Select();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //nishu 6/8/2015
        public string SelectCountryName(int CountryCode)
        {
            try
            {
                objdalCountry = new dalCountry();
                return objdalCountry.SelectCountryName(CountryCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}