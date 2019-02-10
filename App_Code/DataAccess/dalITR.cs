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
    /// Summary description for dalITR
    /// </summary>
    public class dalITR:dalConnection
    {
        #region Constructor
        public dalITR()
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
        public denITR fetchData(Int64 ID)
        {
            denITR objdenITR = new denITR();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from tbl_ITRXML where ID=@ID",this.SqlCon);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenITR.AY = Convert.ToString(reader["AY"]);
                    objdenITR.ITRType = Convert.ToString(reader["ITRType"]);
                }
                reader.Close();
                return objdenITR;
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

        public denITR getITRData(Int64 NameID, string AY, string ITRType)
        {
            denITR objdenITR = new denITR();
            try
            {
                this.pConn();
                //cmd = new SqlCommand("select * from tbl_ITRXML where NameID=@NameID and AY=@AY and ITRType=@ITRType", this.SqlCon);
                cmd = new SqlCommand("select * from tbl_ITRXML where NameID=@NameID and XML_Data is not null", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                //cmd.Parameters.AddWithValue("@AY", AY);
                //cmd.Parameters.AddWithValue("@ITRType", ITRType);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                objdenITR.NameID = 0;
                while (reader.Read())
                {
                    objdenITR.AY = Convert.ToString(reader["AY"]);
                    objdenITR.ITRType = Convert.ToString(reader["ITRType"]);
                    objdenITR.AddedOn = Convert.ToDateTime(reader["AddedOn"]);
                    objdenITR.NameID = NameID;
                    objdenITR.XMLFile = reader["XMLFile"].ToString();
                    objdenITR.XML_Data = reader["XML_Data"].ToString();
                    objdenITR.ID = Convert.ToInt64(reader["ID"]);
                }
                reader.Close();
                return objdenITR;
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

        public denITR getITRData2(Int64 NameID, string AY, string ITRType)
        {
            denITR objdenITR = new denITR();
            try
            {
                this.pConn();
                //cmd = new SqlCommand("select * from tbl_ITRXML where NameID=@NameID and AY=@AY and ITRType=@ITRType", this.SqlCon);
                cmd = new SqlCommand("select * from tbl_ITRXML where NameID=@NameID and XML_Data is not null and AY=@AY", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@ITRType", ITRType);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                objdenITR.NameID = 0;
                while (reader.Read())
                {
                    objdenITR.AY = Convert.ToString(reader["AY"]);
                    objdenITR.ITRType = Convert.ToString(reader["ITRType"]);
                    objdenITR.AddedOn = Convert.ToDateTime(reader["AddedOn"]);
                    objdenITR.NameID = NameID;
                    objdenITR.XMLFile = reader["XMLFile"].ToString();
                    objdenITR.XML_Data = reader["XML_Data"].ToString();
                    objdenITR.ID = Convert.ToInt64(reader["ID"]);
                }
                reader.Close();
                return objdenITR;
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

        public int getITRData_Main(Int64 NameID, string AY)
        {
            int IsExists = 0;
            try
            {
                this.pConn();
                cmd = new SqlCommand("proc_SelectAssesseeData_Main", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.Add("@IsExists", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                IsExists = Convert.ToInt32(cmd.Parameters["@IsExists"].Value);
                return IsExists;
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

        public denITR getITRData(Int64 NameID, string AY)
        {
            denITR objdenITR = new denITR();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select top(1)* from tbl_ITRXML where NameID=@NameID and AY=@AY", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                objdenITR.NameID = 0;
                while (reader.Read())
                {
                    objdenITR.AY = Convert.ToString(reader["AY"]);
                    objdenITR.ITRType = Convert.ToString(reader["ITRType"]);
                    objdenITR.AddedOn = Convert.ToDateTime(reader["AddedOn"]);
                    objdenITR.NameID = NameID;
                    objdenITR.XMLFile = reader["XMLFile"].ToString();
                    objdenITR.XML_Data = reader["XML_Data"].ToString();
                    objdenITR.ID = Convert.ToInt64(reader["ID"]);
                }
                reader.Close();
                return objdenITR;
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

        #endregion

        #region tbl_ITRTypes-Functions
        //To Select ITR Types on the basis of Project Name
        public List<denITR> Select(string Project)
        {
            List<denITR> LstITR = new List<denITR>();
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("select title,((case when title='1' then 'Salary/Other Income' when title = '8' then 'Business Income 44 AD' else detail end)) as detail from tbl_ITRTypes where Project=@Project", this.SqlCon);// and detail in('ITR-1','ITR-4S','ITR-2A')
                cmd.Parameters.AddWithValue("@Project", Project);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    denITR objdenITR = new denITR();
                    objdenITR.title = Convert.ToString(reader["title"]);
                    objdenITR.detail = Convert.ToString(reader["detail"]);
                    LstITR.Add(objdenITR);
                }
                reader.Close();
                return LstITR;
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

        //To Select ITR Types on the basis of Project Name
        public DataTable SelectITR(string Project)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                if (Project == "TDS" || Project == "tds")
                    cmd = new SqlCommand("select distinct detail, detail from tbl_ITRTypes where Project = @Project and status ='true'", this.SqlCon);
                else
                    cmd = new SqlCommand("select title, detail from tbl_ITRTypes where Project = @Project and status ='true'", this.SqlCon);

                cmd.Parameters.AddWithValue("@Project", Project);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
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

        public int getReturnType(string detail, string Project)
        {
            int RetType = 0;
            List<denITR> LstITR = new List<denITR>();
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("select id from dbMain.dbo.tbl_ITRTypes where detail = @detail and Project = @Project", this.SqlCon);
                cmd.Parameters.AddWithValue("@detail", detail);
                cmd.Parameters.AddWithValue("@Project", Project);
                RetType = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return RetType;
        }

        #endregion
    }
}
