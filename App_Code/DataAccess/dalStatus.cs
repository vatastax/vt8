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
    /// Summary description for dalStatus
    /// </summary>
    public class dalStatus:dalConnection
    {
        #region Constructor
        public dalStatus()
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
        public List<denStatus> Select(string ReturnType)
        {
            try
            {
                List<denStatus> genStatus = new List<denStatus>();
                this.pConnMain();
                cmd = new SqlCommand("SELECT * FROM tbl_Status where charindex(@ReturnType,ReturnType)>0", this.SqlCon);
                cmd.Parameters.AddWithValue("@ReturnType", ReturnType);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    denStatus objStatusDEN = new denStatus();
                    objStatusDEN.id = Convert.ToInt32(reader["id"]);
                    objStatusDEN.ReturnType = Convert.ToString(reader["ReturnType"]);
                    objStatusDEN.Status = Convert.ToString(reader["Status"]);
                    objStatusDEN.TagVal = Convert.ToString(reader["TagVal"]);
                    objStatusDEN.VType_URL = Convert.ToString(reader["VType_URL"]);
                    genStatus.Add(objStatusDEN);
                }
                reader.Close();
                return genStatus;
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

        public string SelectVType(string id)
        {
            string VType = "";
            try
            {
                List<denStatus> genStatus = new List<denStatus>();
                this.pConnMain();
                cmd = new SqlCommand("SELECT distinct(VType_URL) FROM tbl_Status where id=@id", this.SqlCon);
                cmd.Parameters.AddWithValue("@id", id);
                VType = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return VType;
        }

        public string SelectVType(string id, string ITR)
        {
            string VType = "";
            try
            {
                List<denStatus> genStatus = new List<denStatus>();
                this.pConnMain();
                cmd = new SqlCommand("SELECT distinct(VType_URL) FROM tbl_Status where id=@id and CHARINDEX(@ITR,ReturnType)>0", this.SqlCon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@ITR", ITR);
                VType = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return VType;
        }

        #endregion
    }
      
}
