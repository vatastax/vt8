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
    /// Summary description for dalStates
    /// </summary>
    public class dalStates:dalConnection
    {
        #region Constructor
        public dalStates()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;
        denStates objStatesDEN;
        #endregion

        #region Functions
        public List<denStates> GetStateList()
        {
            try
            {
                List<denStates> genStates = new List<denStates>();

                this.pConn();
                cmd = new SqlCommand("GetStates",this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objStatesDEN = new denStates();
                    objStatesDEN.StateCode = (reader["StateCode"]).ToString();
                    objStatesDEN.StateName = Convert.ToString(reader["StateName"]);
                    genStates.Add(objStatesDEN);
                }
                reader.Close();
                return genStates;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        //nishu 6/8/2015
        public string SelectStateName(int StateCode)
        {
            string Country_Name;
            try
            {
                denAddress objAddressDEN = new denAddress();
                this.pConnMain();
                cmd = new SqlCommand("select Statename from tblStates where StateCode=@SCode", this.SqlCon);
                cmd.Parameters.AddWithValue("@SCode", StateCode);
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
