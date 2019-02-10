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

/// <summary>
/// Summary description for dalCompanyDetails
/// </summary>
/// 
namespace Taxation.DataAccess
{
    public class dalCompanyDetails:dalConnection
    {
        public dalCompanyDetails()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Variables
        SqlCommand cmd;
        #endregion

        #region Functions
        public int InsertCompanyDetails(denCompanyDetails objCompanyDetailsDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procinsertcompanydetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_Nature", objCompanyDetailsDEN.Company_Nature);
                cmd.Parameters.AddWithValue("@CompName", objCompanyDetailsDEN.CompName);
                cmd.Parameters.AddWithValue("@Address1", objCompanyDetailsDEN.Address1);
                cmd.Parameters.AddWithValue("@Address2", objCompanyDetailsDEN.Address2);
                cmd.Parameters.AddWithValue("@Address3", objCompanyDetailsDEN.Address3);
                cmd.Parameters.AddWithValue("@Address4", objCompanyDetailsDEN.Address4);
                cmd.Parameters.AddWithValue("@City", objCompanyDetailsDEN.City);
                cmd.Parameters.AddWithValue("@State", objCompanyDetailsDEN.State);
                cmd.Parameters.AddWithValue("@PIN", objCompanyDetailsDEN.PIN);
                cmd.Parameters.AddWithValue("@CompPan", objCompanyDetailsDEN.CompPan);
                cmd.Parameters.AddWithValue("@FormNo", objCompanyDetailsDEN.FormNO);

                cmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}