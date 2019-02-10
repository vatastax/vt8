using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalBankMast
    /// </summary>
    public class dalBankMast:dalConnection
    {
        #region Constructor
        public dalBankMast()
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

        public int InsertDataBankMast(denBankMast objBankMastDEN)
        {
            try
            {

                this.pConn();
                cmd = new SqlCommand("procInsertBankMast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@BankID", objBankMastDEN.BankID);
                cmd.Parameters.AddWithValue("@AssessID", objBankMastDEN.AssesseeID);
                cmd.Parameters.AddWithValue("@BankName", objBankMastDEN.BankName);
                cmd.Parameters.AddWithValue("@MICRCode", objBankMastDEN.MICRCode);
                cmd.Parameters.AddWithValue("@Address", objBankMastDEN.Address);
                cmd.Parameters.AddWithValue("@AccountType", objBankMastDEN.AccountType);
                cmd.Parameters.AddWithValue("@AccountNo", objBankMastDEN.AccountNo);
                cmd.Parameters.AddWithValue("@ECS", objBankMastDEN.ECS);
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

        public int UpdateDataBankMast(denBankMast objBankMastDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdateBankMast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BankID", objBankMastDEN.BankID);
                cmd.Parameters.AddWithValue("@AssessID", objBankMastDEN.AssesseeID);
                cmd.Parameters.AddWithValue("@BankName", objBankMastDEN.BankName);
                cmd.Parameters.AddWithValue("@MICRCode", objBankMastDEN.MICRCode);
                cmd.Parameters.AddWithValue("@Address", objBankMastDEN.Address);
                cmd.Parameters.AddWithValue("@AccountType", objBankMastDEN.AccountType);
                cmd.Parameters.AddWithValue("@AccountNo", objBankMastDEN.AccountNo);
                cmd.Parameters.AddWithValue("@ECS", objBankMastDEN.ECS);
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

        public DataTable SelectByAssesse(Int64 AssesseeID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select AssesseeID,BankName,MICRCode,Address,(case AccountType when 0 then 'Savings' when 1 then 'Current' else 'CashCredit' end) as acType,
                                    AccountNo,ECS,BankID from bankmast where AssesseeID=@AssesseeID", this.SqlCon);
                cmd.Parameters.AddWithValue("@AssesseeID", AssesseeID);
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

        public List<denBankMast> Select(Int32 BankID)
        {
            List<denBankMast> objList = new List<denBankMast>();
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select BankID, AssesseeID, BankName, MICRCode, Address, AccountType, AccountNo, ECS from bankmast where BankID=@BankID", this.SqlCon);
                cmd.Parameters.AddWithValue("@BankID", BankID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    denBankMast objdenBankMast = new denBankMast();
                    objdenBankMast.AccountNo = reader.GetString(6);
                    objdenBankMast.AccountType = reader.GetInt32(5);
                    objdenBankMast.Address = reader.GetString(4);
                    objdenBankMast.AssesseeID = reader.GetInt64(1);
                    objdenBankMast.BankID = reader.GetInt32(0);
                    objdenBankMast.BankName = reader.GetString(2);
                    objdenBankMast.ECS = reader.GetString(7);
                    objdenBankMast.MICRCode = reader.GetString(3);
                    objList.Add(objdenBankMast);
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

        public void Delete(Int32 BankID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"delete from bankmast where BankID=@BankID", this.SqlCon);
                cmd.Parameters.AddWithValue("@BankID", BankID);
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