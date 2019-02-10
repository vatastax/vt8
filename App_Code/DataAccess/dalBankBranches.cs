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


/// <summary>
/// Summary description for dalBankBranches
/// </summary>
public class dalBankBranches : dalConnection
{
    public dalBankBranches()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Variables
    SqlCommand cmd;
    #endregion
    public List<denBankBranches> Select(string BSRCode)
    {
        DataTable dt = new DataTable();
        List<denBankBranches> objList = new List<denBankBranches>();
        try
        {
            this.pConnAdmin();
            cmd = new SqlCommand("select BankName from BankBranches where BankCode=@BankCode", this.SqlCon);
            cmd.Parameters.AddWithValue("@BankCode", BSRCode);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                denBankBranches objdenBankBranches = new denBankBranches();
                objdenBankBranches.BankName = reader.GetString(0);
                objList.Add(objdenBankBranches);
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

    public string SelectSingle(string BSRCode)
    {
        string val = "";
        try
        {
            this.pConnAdmin();
            cmd = new SqlCommand("select (BankName + ', ' + Branch) as BankName from BankBranches where BankCode=@BankCode", this.SqlCon);
            cmd.Parameters.AddWithValue("@BankCode", BSRCode);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                val = reader.GetString(0);
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
        return val;
    }

    public string SelectBankByIFSC(string IFSC)
    {
        string val = "";
        try
        {
            this.pConn();
            cmd = new SqlCommand("select BANK from IFSC_Code_BankName where IFSC = @IFSC", this.SqlCon);
            cmd.Parameters.AddWithValue("@IFSC", IFSC);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                val = reader.GetString(0);
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
        return val;
    }

}