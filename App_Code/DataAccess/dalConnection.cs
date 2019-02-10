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

/// <summary>
/// Summary description for dalConnection
/// </summary>
public class dalConnection
{
    protected SqlConnection SqlCon;
    protected string strConnStr;
    protected string strConnStr1;
    protected string strConnAdmin;
    protected string strConnTDS2;
    static string conStr = "";
    public dalConnection()
    {
        if (strConnStr == null && System.Web.HttpContext.Current.Session != null)
        {
            if (System.Web.HttpContext.Current.Session["Project"] != null)
            {
                if (System.Web.HttpContext.Current.Session["Project"].ToString() == "vt" || System.Web.HttpContext.Current.Session["Project"].ToString() == "stax")
                {
                    strConnStr = ConfigurationManager.ConnectionStrings["Con_Poolable"].ConnectionString;
                    strConnStr1 = ConfigurationManager.ConnectionStrings["Con_Main"].ConnectionString;
                    strConnAdmin = ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString;
                }
                else if (System.Web.HttpContext.Current.Session["Project"].ToString() == "tds")
                {
                    strConnStr = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                    //strConnStr1 = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                    strConnStr1 = ConfigurationManager.ConnectionStrings["Con_Main"].ConnectionString;
                    strConnAdmin = ConfigurationManager.ConnectionStrings["SQLServer4"].ConnectionString;
                }
                else if (System.Web.HttpContext.Current.Session["Project"].ToString() == "tds2")
                {
                    strConnStr = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                    strConnTDS2 = ConfigurationManager.ConnectionStrings["SQLServer9"].ConnectionString;
                    strConnStr1 = ConfigurationManager.ConnectionStrings["Con_Main"].ConnectionString;
                    strConnAdmin = ConfigurationManager.ConnectionStrings["SQLServer4"].ConnectionString;
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("");
            }
        }
        else
        {
            strConnStr = ConfigurationManager.ConnectionStrings["Con_Poolable"].ConnectionString;
        }
    }
    public void pConn()
    {
        try
        {
            SqlCon = new SqlConnection(strConnStr);
            
            SqlCon.Open();
        }
        catch (Exception ex)
        {
            if (HttpContext.Current.Session["project"].ToString() == "vt")
                SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Con_Poolable"].ConnectionString);
            else
                SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            SqlCon.Open();
        }
    }
    public void pConnMain()
    {
        try
        {
            SqlCon = new SqlConnection(strConnStr1);
            SqlCon.Open();
        }
        catch (Exception ex)
        {
            //if (HttpContext.Current.Session["project"].ToString() == "vt")
                SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Con_Main"].ConnectionString);
            //else
            //    SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            SqlCon.Open();
        }
    }
    public void pConnTDS()
    {
        try
        {
            SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            SqlCon.Open();
        }
        catch (Exception ex)
        {
            //if (HttpContext.Current.Session["project"].ToString() == "vt")
            SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            //else
            //    SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            SqlCon.Open();
        }
    }

    public void pConnAdmin()
    {
        try
        {
            SqlCon = new SqlConnection(strConnAdmin);
            SqlCon.Open();
        }
        catch (Exception ex)
        {
            SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
            SqlCon.Open();
        }
    }
    public void pConnTDS2()
    {
        try
        {
            SqlCon = new SqlConnection(strConnTDS2);
            SqlCon.Open();
        }
        catch (Exception ex)
        {
            SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
            SqlCon.Open();
        }
    }
}
