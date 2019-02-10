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
namespace Taxation.DataAccess
{


    /// <summary>
    /// Summary description for dalAddress
    /// </summary>
    public class dalAddress:dalConnection
    {
        #region Constructors
        public dalAddress()
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
        public int InsertAddress(denAddress objAddressDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procinsertaddress", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objAddressDEN.NameID);
                cmd.Parameters.AddWithValue("@Address", objAddressDEN.Address);
                cmd.Parameters.AddWithValue("@FlatNo", objAddressDEN.Flat);
                cmd.Parameters.AddWithValue("@NOPremises", objAddressDEN.Premises);
                cmd.Parameters.AddWithValue("@RoadStreet", objAddressDEN.Road);
                cmd.Parameters.AddWithValue("@Area", objAddressDEN.Area);
                cmd.Parameters.AddWithValue("@City", objAddressDEN.City);
                cmd.Parameters.AddWithValue("@State", objAddressDEN.State);
                cmd.Parameters.AddWithValue("@PinCode", objAddressDEN.PIN);
                cmd.Parameters.AddWithValue("@StdCode", objAddressDEN.STDCODE);
                cmd.Parameters.AddWithValue("@Phone", objAddressDEN.PhoneNo);
                cmd.Parameters.AddWithValue("@Vtype", objAddressDEN.Vtype);
                cmd.Parameters.AddWithValue("@mobile1", objAddressDEN.mobile1);
                cmd.Parameters.AddWithValue("@mobile2", objAddressDEN.mobile2);
                cmd.Parameters.AddWithValue("@Country", objAddressDEN.Country);

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
        public denAddress GetAddress(string PAN)
        {
            try
            {
                denAddress objAddressDEN = new denAddress();
                this.pConn();
                cmd = new SqlCommand("procselectaddress", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PAN", PAN);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    objAddressDEN.Flat = Convert.ToString(reader["flatno"]);
                    objAddressDEN.Premises = Convert.ToString(reader["nopremises"]);
                    objAddressDEN.Road = Convert.ToString(reader["roadstreet"]);
                    objAddressDEN.Area = Convert.ToString(reader["area"]);
                    objAddressDEN.City = Convert.ToString(reader["city"]);
                    objAddressDEN.State = Convert.ToString(reader["state"]);
                    objAddressDEN.PIN = Convert.ToString(reader["pincode"]);
                    
                    objAddressDEN.mobile1 = Convert.ToString(reader["mobile1"]);
                    objAddressDEN.mobile2 = Convert.ToString(reader["mobile2"]);

                }
                return objAddressDEN;
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

        public int UpdateAddress(denAddress objAddressDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdateaddress", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objAddressDEN.NameID);
                cmd.Parameters.AddWithValue("@FlatNo", objAddressDEN.Flat);
                cmd.Parameters.AddWithValue("@NOPremises", objAddressDEN.Premises);
                cmd.Parameters.AddWithValue("@RoadStreet", objAddressDEN.Road);
                cmd.Parameters.AddWithValue("@Area", objAddressDEN.Area);
                cmd.Parameters.AddWithValue("@City", objAddressDEN.City);
                cmd.Parameters.AddWithValue("@State", objAddressDEN.State);
                cmd.Parameters.AddWithValue("@PinCode", objAddressDEN.PIN);
                cmd.Parameters.AddWithValue("@Address", objAddressDEN.Address);
                cmd.Parameters.AddWithValue("@StdCode", objAddressDEN.STDCODE);
                cmd.Parameters.AddWithValue("@PhoneNo", objAddressDEN.PhoneNo);
                cmd.Parameters.AddWithValue("@mobile1", objAddressDEN.mobile1);
                cmd.Parameters.AddWithValue("@mobile2", objAddressDEN.mobile2);
                //Added by Mudit on 04/08/2015 because Country wast not getting update in AdrsMast
                cmd.Parameters.AddWithValue("@country", objAddressDEN.Country);
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
        #endregion
    }
}