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
using System.Collections.Generic;

namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalConsultanaMast
    /// </summary>
    public class dalConsultantMast:dalConnection
    {
        #region Constructor
        public dalConsultantMast()
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
        public int InsertConsultantMaster(denConsultantMast objConsultantMastDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("insertConsultantMast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@ConsultID", objConsultantMastDEN.ConsultID);
                cmd.Parameters.AddWithValue("@Vtype", objConsultantMastDEN.Vtype);
                cmd.Parameters.AddWithValue("@AuditorName", objConsultantMastDEN.AuditorName);
                cmd.Parameters.AddWithValue("@Address", objConsultantMastDEN.Address);
                cmd.Parameters.AddWithValue("@Phone", objConsultantMastDEN.Phone);
                cmd.Parameters.AddWithValue("@MembershipNo", objConsultantMastDEN.MembershipNo);
                cmd.Parameters.AddWithValue("@PAN", objConsultantMastDEN.PAN);
                cmd.Parameters.AddWithValue("@FirmName", objConsultantMastDEN.FirmName);
                cmd.Parameters.AddWithValue("@AuditDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@NameID", objConsultantMastDEN.NameID);
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
        public int UpdateConsultantMaster(denConsultantMast objConsultantMastDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("updateConsultantMast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@ConsultID", objConsultantMastDEN.ConsultID);
                //cmd.Parameters.AddWithValue("@Vtype", objConsultantMastDEN.Vtype);
                cmd.Parameters.AddWithValue("@AuditorName", objConsultantMastDEN.AuditorName);
                cmd.Parameters.AddWithValue("@Address", objConsultantMastDEN.Address);
                cmd.Parameters.AddWithValue("@Phone", objConsultantMastDEN.Phone);
                cmd.Parameters.AddWithValue("@MembershipNo", objConsultantMastDEN.MembershipNo);
                cmd.Parameters.AddWithValue("@PAN", objConsultantMastDEN.PAN);
                cmd.Parameters.AddWithValue("@FirmName", objConsultantMastDEN.FirmName);
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

        public denConsultantMast Select(denConsultantMast objConsultantMastDEN)
        {
            denConsultantMast objdenConsultantMast = new denConsultantMast();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from consultantmast where PAN=@PAN", this.SqlCon);
                cmd.Parameters.AddWithValue("@PAN", objConsultantMastDEN.PAN);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    objdenConsultantMast.Address = reader.GetString(3);
                    objdenConsultantMast.AuditorName = reader.GetString(2);
                    objdenConsultantMast.ConsultID = reader.GetInt32(0);
                    objdenConsultantMast.FirmName = reader.GetString(7);
                    objdenConsultantMast.MembershipNo = reader.GetString(5);
                    objdenConsultantMast.PAN = reader.GetString(6);
                    objdenConsultantMast.Phone = reader.GetString(4);
                    objdenConsultantMast.Vtype = reader.GetInt32(1);
                    //objList.Add(objdenConsultantMast);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return objdenConsultantMast;
        }

        public List<denConsultantMast> Select(Int64 NameID)
        {
            List<denConsultantMast> objList = new List<denConsultantMast>();            
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from consultantmast where NameID=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    denConsultantMast objdenConsultantMast = new denConsultantMast();
                    objdenConsultantMast.Address = reader.GetString(3);
                    objdenConsultantMast.AuditorName = reader.GetString(2);
                    objdenConsultantMast.ConsultID = reader.GetInt32(0);
                    objdenConsultantMast.FirmName = reader.GetString(7);
                    objdenConsultantMast.MembershipNo = reader.GetString(5);
                    objdenConsultantMast.PAN = reader.GetString(6);
                    objdenConsultantMast.Phone = reader.GetString(4);
                    objdenConsultantMast.Vtype = reader.GetInt32(1);
                    
                    objList.Add(objdenConsultantMast);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return objList;
        }

        public denConsultantMast SelectByConsultID(Int64 ConsultID)
        {
            denConsultantMast objList = new denConsultantMast();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from consultantmast where ConsultID=@ConsultID", this.SqlCon);
                cmd.Parameters.AddWithValue("@ConsultID", ConsultID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objList.Address = reader.GetString(3);
                    objList.AuditorName = reader.GetString(2);
                    objList.ConsultID = reader.GetInt32(0);
                    objList.FirmName = reader.GetString(7);
                    objList.MembershipNo = reader.GetString(5);
                    objList.PAN = reader.GetString(6);
                    objList.Phone = reader.GetString(4);
                    objList.Vtype = reader.GetInt32(1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return objList;
        }

        public void Delete(Int64 ConsultID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("delete from consultantmast where ConsultID=@ConsultID", this.SqlCon);
                cmd.Parameters.AddWithValue("@ConsultID", ConsultID);
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
        #endregion
    }
}