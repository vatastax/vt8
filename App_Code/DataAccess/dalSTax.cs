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
using Taxation.Interface;
using System.Collections.Generic;
using Taxation.DataEntity;

namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalSTax
    /// </summary>
    public class dalSTax:dalConnection
    {
        public dalSTax()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Variables
        SqlCommand cmd;        
        #endregion


        #region Master 

        //Creating a Generic list to get records from T4 table when we click on LinkButton

        public List<denSTax> getParticulars()
        {
            denSTax objdenSTax;
            try
            {
                List<denSTax> GenT4 = new List<denSTax>();
                this.pConn();
                //Now we are getting Details of ID 808 this is special case.
                //Another different case is 107.
                cmd = new SqlCommand("select * from stax_tbl_ServiceList", this.SqlCon);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenSTax = new denSTax();
                    objdenSTax.id = Convert.ToInt64(reader["id"]);
                    objdenSTax.title = Convert.ToString(reader["title"]);
                    objdenSTax.SubClauseNo = Convert.ToString(reader["SubClauseNo"]);
                    objdenSTax.ServiceCode = Convert.ToString(reader["ServiceCode"]);

                    GenT4.Add(objdenSTax);
                }
                reader.Close();
                //this.SqlCon.Close();
                return GenT4;
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

        public List<denAbatementNotifications> getAbatementNotifications()
        {
            denAbatementNotifications objdenAbatementNotifications;
            try
            {
                List<denAbatementNotifications> GenT4 = new List<denAbatementNotifications>();
                this.pConn();
                //Now we are getting Details of ID 808 this is special case.
                //Another different case is 107.
                cmd = new SqlCommand("select * from stax_tbl_Abatement_Notifications", this.SqlCon);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenAbatementNotifications = new denAbatementNotifications();
                    objdenAbatementNotifications.id = Convert.ToInt64(reader["id"]);
                    objdenAbatementNotifications.Notification_Number = Convert.ToString(reader["Notification_Number"]);
                    objdenAbatementNotifications.ServiceID = Convert.ToInt64(reader["ServiceID"]);

                    GenT4.Add(objdenAbatementNotifications);
                }
                reader.Close();
                //this.SqlCon.Close();
                return GenT4;
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

        public List<denAbatementNotifications> getAbatementNotifications(Int64 serviceID)
        {
            denAbatementNotifications objdenAbatementNotifications;
            try
            {
                List<denAbatementNotifications> GenT4 = new List<denAbatementNotifications>();
                this.pConn();
                //Now we are getting Details of ID 808 this is special case.
                //Another different case is 107.
                cmd = new SqlCommand("select * from stax_tbl_Abatement_Notifications where ServiceID=@ServiceID", this.SqlCon);
                cmd.Parameters.AddWithValue("@ServiceID", serviceID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenAbatementNotifications = new denAbatementNotifications();
                    objdenAbatementNotifications.id = Convert.ToInt64(reader["id"]);
                    objdenAbatementNotifications.Notification_Number = Convert.ToString(reader["Notification_Number"]);
                    objdenAbatementNotifications.ServiceID = Convert.ToInt64(reader["ServiceID"]);

                    GenT4.Add(objdenAbatementNotifications);
                }
                reader.Close();                
                return GenT4;
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

        public List<denExemptionSerials> getExemptionSerials(Int64 serviceID)
        {
            denExemptionSerials objdenExemptionSerials;
            try
            {
                List<denExemptionSerials> GenT4 = new List<denExemptionSerials>();
                this.pConn();
                //Now we are getting Details of ID 808 this is special case.
                //Another different case is 107.
                cmd = new SqlCommand("select * from stax_tbl_ExemptionSerials where ServiceID=@ServiceID", this.SqlCon);
                cmd.Parameters.AddWithValue("@ServiceID", serviceID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenExemptionSerials = new denExemptionSerials();
                    objdenExemptionSerials.id = Convert.ToInt64(reader["id"]);
                    objdenExemptionSerials.NotSerialNo = Convert.ToString(reader["NotSerialNo"]);
                    objdenExemptionSerials.ServiceID = Convert.ToInt64(reader["ServiceID"]);

                    GenT4.Add(objdenExemptionSerials);
                }
                reader.Close();
                return GenT4;
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


        #region Transactions

        //Adding Service into Services

        //Adding Service into Services
        //Changed by Mudit on 24-04-2015 as new fields are added in the table
        public Int64 AddService(Int64 ServiceID, string NameID, int ServiceProvider, int SP_PartialReverseCharge, string SP_STPayable, int ServiceReceiver, int SR_PartialReverseCharge, string SR_STPayable, int BenefitOfExemptions, int AbatementClaimed, int ProvisionallyAssessed)
        {
            Int64 lastID = 0;
            try
            {
                List<denSTax> GenT4 = new List<denSTax>();
                this.pConn();
                //Now we are getting Details of ID 808 this is special case.
                //Another different case is 107.
                cmd = new SqlCommand("Proc_ServiceTax_InsertSelectedServices", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", ServiceID);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@ServiceProvider", ServiceProvider);
                cmd.Parameters.AddWithValue("@SP_PartialReverseCharge", SP_PartialReverseCharge);
                cmd.Parameters.AddWithValue("@SP_STPayable", SP_STPayable);
                cmd.Parameters.AddWithValue("@ServiceReceiver", ServiceReceiver);
                cmd.Parameters.AddWithValue("@SR_PartialReverseCharge", SR_PartialReverseCharge);
                cmd.Parameters.AddWithValue("@SR_STPayable", SR_STPayable);
                cmd.Parameters.AddWithValue("@BenefitOfExemptions", BenefitOfExemptions);
                cmd.Parameters.AddWithValue("@AbatementClaimed", AbatementClaimed);
                cmd.Parameters.AddWithValue("@ProvisionallyAssessed", ProvisionallyAssessed);
                //cmd.Parameters.AddWithValue("@Date", NameID);
                lastID = Convert.ToInt64(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return lastID;
        }
        //Added by Mudit on 24-04-2015 for maintaining Abatement Records
        public void AddAbtService(Int64 ServID, string NotificationNo, Int64 SI_No)
        {
            try
            {
                List<denSTax> GenT4 = new List<denSTax>();
                this.pConn();
                cmd = new SqlCommand("Proc_ServiceTax_InsertSelectedAbatement", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SelServID", ServID);
                cmd.Parameters.AddWithValue("@NotificationNo", NotificationNo);
                cmd.Parameters.AddWithValue("@SI_No", SI_No);
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
        //Added by Mudit on 24-04-2015 for maintaining Exemption Records
        public void AddExmptService(Int64 ServID, string NotificationNo, Int64 SI_No)
        {
            try
            {
                List<denSTax> GenT4 = new List<denSTax>();
                this.pConn();
                cmd = new SqlCommand("Proc_ServiceTax_InsertSelectedExmpt", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SelServID", ServID);
                cmd.Parameters.AddWithValue("@NotificationNo", NotificationNo);
                cmd.Parameters.AddWithValue("@SI_No", SI_No);
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
        //Added by Mudit on 24-04-2015 for maintaining Provisional Records
        public void AddProService(Int64 ServID, string ProOrderNo, string Date)
        {
            try
            {
                List<denSTax> GenT4 = new List<denSTax>();
                this.pConn();
                cmd = new SqlCommand("Proc_ServiceTax_InsertProvisionalService", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SelServID", ServID);
                cmd.Parameters.AddWithValue("@ProOrderNo", ProOrderNo);
                cmd.Parameters.AddWithValue("@Date", Date);
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
        //Added by Mudit on 25-04-2015 for Fetching Records From SelectedService Table
        public DataTable getSelectedServices(string NameID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("Proc_ServiceTax_GetSelectedService", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                //cmd.Parameters.AddWithValue("@ServID", ServID);
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
        //Added by Mudit on 25-04-2015 for Fetching Records From Selected Abatement Service Table
        public DataTable getSelectedAbtServices(string SelServID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("Proc_ServiceTax_GetSelectedAbtService", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServID", SelServID);
                //cmd.Parameters.AddWithValue("@ServID", ServID);
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

        //Added by Mudit on 25-04-2015 for Fetching Records From Selected Exempted Service Table
        public DataTable getSelectedExmptServices(string SelServID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("Proc_ServiceTax_GetSelectedExmptService", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServID", SelServID);
                //cmd.Parameters.AddWithValue("@ServID", ServID);
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
        #endregion

    }
}