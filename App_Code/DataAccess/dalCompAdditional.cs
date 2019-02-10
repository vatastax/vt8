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
using System.Collections.Generic;
using Taxation.DataEntity;
namespace Taxation.DataAccess
{
    /// <summary>
    /// Summary description for dalCompAdditional
    /// </summary>
    public class dalCompAdditional:dalConnection
    {
        public dalCompAdditional()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Variables
        SqlCommand cmd;
        #endregion
        public List<denCompAdditional> FillGrid(string AssesseeID)
        {
            try
            {
                this.pConn();
                denCompAdditional objCompAdditionalDEN;
                List<denCompAdditional> lstCompAdditional = new List<denCompAdditional>();
                cmd = new SqlCommand("procgetcompanylist", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssesseeID", AssesseeID);
                cmd.Parameters.AddWithValue("@CompNature", 1);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objCompAdditionalDEN = new denCompAdditional();

                    objCompAdditionalDEN.CompName = Convert.ToString(reader["compname"]);
                    objCompAdditionalDEN.CompPAN = Convert.ToString(reader["comppan"]);
                    objCompAdditionalDEN.City = Convert.ToString(reader["city"]);

                    lstCompAdditional.Add(objCompAdditionalDEN);


                }
                return lstCompAdditional;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}