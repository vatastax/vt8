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
    /// Summary description for dalEmployerMaster
    /// </summary>
    public class dalEmployerMaster:dalConnection

    {
        #region Constructor
        public dalEmployerMaster()
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
        //inserting Data of EmployerMaster

        public int InsertDataEmployerMaster(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procinsertemprmast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vtype", objEmployerMasterDEN.Vtype);
                cmd.Parameters.AddWithValue("@Name", objEmployerMasterDEN.Name);
                cmd.Parameters.AddWithValue("@Address", objEmployerMasterDEN.Address);
                cmd.Parameters.AddWithValue("@Phone", objEmployerMasterDEN.PhoneNo);
                cmd.Parameters.AddWithValue("@TypeofEmployer", objEmployerMasterDEN.TypeofEmployer);
                cmd.Parameters.AddWithValue("@PSR", objEmployerMasterDEN.PSR);
                cmd.Parameters.AddWithValue("@PAN", objEmployerMasterDEN.PAN);
                cmd.Parameters.AddWithValue("@Designation", objEmployerMasterDEN.Designation);
                cmd.Parameters.AddWithValue("@NameID", objEmployerMasterDEN.NameID);
                cmd.Parameters.AddWithValue("@TAN", objEmployerMasterDEN.TAN);
                //cmd.ExecuteNonQuery();
                int a = Convert.ToInt32(cmd.ExecuteNonQuery());
                return a;
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

        public int UpdateDataEmployerMaster(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdateemprmast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Name", objEmployerMasterDEN.Name);
                cmd.Parameters.AddWithValue("@Address", objEmployerMasterDEN.Address);
                cmd.Parameters.AddWithValue("@Phone", objEmployerMasterDEN.PhoneNo);
                cmd.Parameters.AddWithValue("@TypeofEmployer", objEmployerMasterDEN.TypeofEmployer);                
                cmd.Parameters.AddWithValue("@PAN", objEmployerMasterDEN.PAN);
                cmd.Parameters.AddWithValue("@EmpID", objEmployerMasterDEN.EmpID);
                cmd.Parameters.AddWithValue("@TAN", objEmployerMasterDEN.TAN);
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //inserting data of BusinessMaster

        public int InsertDataBusinessMaster(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procinsertbusinessmast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vtype", objEmployerMasterDEN.Vtype);
                cmd.Parameters.AddWithValue("@Name", objEmployerMasterDEN.Name);
                cmd.Parameters.AddWithValue("@Address", objEmployerMasterDEN.Address);
                cmd.Parameters.AddWithValue("@Phone", objEmployerMasterDEN.PhoneNo);
                cmd.Parameters.AddWithValue("@PAN", objEmployerMasterDEN.PAN);
                cmd.Parameters.AddWithValue("@Designation", objEmployerMasterDEN.Designation);
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //updating data of businessMaster

        public int UpdateDataBusinessMaster(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdatebusinessmast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", objEmployerMasterDEN.Name);
                cmd.Parameters.AddWithValue("@Address", objEmployerMasterDEN.Address);
                cmd.Parameters.AddWithValue("@Phone", objEmployerMasterDEN.PhoneNo);
                cmd.Parameters.AddWithValue("@Designation", objEmployerMasterDEN.Designation);

                cmd.Parameters.AddWithValue("@PAN", objEmployerMasterDEN.PAN);

                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertDirectorDetails(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procInsertDirectorDetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Vtype", objEmployerMasterDEN.Vtype);
                cmd.Parameters.AddWithValue("@Name", objEmployerMasterDEN.Name);
                cmd.Parameters.AddWithValue("@Address", objEmployerMasterDEN.Address);                
                cmd.Parameters.AddWithValue("@PhoneNo", objEmployerMasterDEN.PhoneNo);
                cmd.Parameters.AddWithValue("@PAN", objEmployerMasterDEN.PAN);
                cmd.Parameters.AddWithValue("@Designation", objEmployerMasterDEN.Designation);
                cmd.Parameters.AddWithValue("@NameID", objEmployerMasterDEN.NameID);

                cmd.Parameters.AddWithValue("@Flat", objEmployerMasterDEN.Flat);
                cmd.Parameters.AddWithValue("@Premises", objEmployerMasterDEN.Premises);
                cmd.Parameters.AddWithValue("@Road", objEmployerMasterDEN.Road);
                cmd.Parameters.AddWithValue("@Area", objEmployerMasterDEN.Area);
                cmd.Parameters.AddWithValue("@City", objEmployerMasterDEN.City);
                cmd.Parameters.AddWithValue("@PIN", objEmployerMasterDEN.PIN);
                cmd.Parameters.AddWithValue("@State", objEmployerMasterDEN.State);
                cmd.ExecuteNonQuery();

                return 0;
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
        public int InsertBeneficiaryDetails(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procinsertBeneficiaryDetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vtype", objEmployerMasterDEN.Vtype);
                cmd.Parameters.AddWithValue("@PAN", objEmployerMasterDEN.PAN);
                cmd.Parameters.AddWithValue("@Name", objEmployerMasterDEN.Name);
                cmd.Parameters.AddWithValue("@Address", objEmployerMasterDEN.Address);
                cmd.Parameters.AddWithValue("@BenRatio", objEmployerMasterDEN.PSR);
                cmd.ExecuteNonQuery();
                return 0;

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
        public denEmployerMaster GetDirectorDetails(string PAN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procselectdirectordetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PAN", PAN);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                denEmployerMaster objEmployerMasterDEN = new denEmployerMaster();
                while (reader.Read())
                {
                    objEmployerMasterDEN.PAN = Convert.ToString(reader["pan"]);
                    objEmployerMasterDEN.Name = Convert.ToString(reader["name"]);
                    objEmployerMasterDEN.Designation = Convert.ToString(reader["designation"]);
                    objEmployerMasterDEN.PhoneNo = Convert.ToString(reader["phoneno"]);
                }
                return objEmployerMasterDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<denEmployerMaster> GetDirectorList(string NameID)
        {
            try
            {
                this.pConn();
                denEmployerMaster objEmployerMasterDEN;
                List<denEmployerMaster> lstEmployerMasterDEN = new List<denEmployerMaster>();
                cmd = new SqlCommand("procgetdirectorlist", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objEmployerMasterDEN = new denEmployerMaster();
                    objEmployerMasterDEN.Name = Convert.ToString(reader["name"]);
                    objEmployerMasterDEN.PAN = Convert.ToString(reader["pan"]);
                    objEmployerMasterDEN.Designation = Convert.ToString(reader["designation"]);
                    lstEmployerMasterDEN.Add(objEmployerMasterDEN);
                }
                return lstEmployerMasterDEN;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByAssessee(string aid, Int32 vtype)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from emprmast where NameID=@NameID and Vtype=@vtype", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", aid);
                cmd.Parameters.AddWithValue("@vtype", vtype);
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

        public void Delete(Int64 EmpID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("delete from emprmast where EmpID=@EmpID", this.SqlCon);
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                cmd.ExecuteNonQuery();
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

        public DataTable Select(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from emprmast where EmpID=@EmpID", this.SqlCon);
                cmd.Parameters.AddWithValue("@EmpID", id);
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

        public DataTable Select()
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from emprmast", this.SqlCon);
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

        #endregion
    }
}