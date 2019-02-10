using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Taxation.DataEntity;
using Taxation.BusinessLogic;

namespace Taxation.DataAccess
{


    /// <summary>
    /// Summary description for dalAddress
    /// </summary>
    public class dalCountry:dalConnection
    {
        #region Constructors
        public dalCountry()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;
        #endregion


        #region Functions
        
       
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            try
            {
                denAddress objAddressDEN = new denAddress();
                this.pConnMain();
                cmd = new SqlCommand("select * from tbl_Country order by Country_Name", this.SqlCon);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }
        //nishu 6/8/2015
        public string SelectCountryName(int CountryCode)
        {
            string Country_Name;
            try
            {
                denAddress objAddressDEN = new denAddress();
                this.pConnMain();
                cmd = new SqlCommand("select Country_Name from tbl_Country where Country_Code=@CCode", this.SqlCon);
                cmd.Parameters.AddWithValue("@CCode", CountryCode);
                Country_Name = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return Country_Name;
        }
        #endregion
    }
}