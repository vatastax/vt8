using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Taxation.BusinessLogic;
using Taxation.DataAccess;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for Service_Banks
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class Service_Banks : System.Web.Services.WebService {

    public Service_Banks () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string fetchData(string BSR) {
        bllBankBranches objbllBankBranches = new bllBankBranches();
        //string BSR = "0003693";
        return objbllBankBranches.SelectSingle(BSR.ToString());
        //return BSR;
    }

    [WebMethod]
    public string Send_Mail(string To, string From, string msg, string subject)
    {
        MailMessage mail = new MailMessage(From, To, subject, msg);
        mail.IsBodyHtml = true;
        SmtpClient smtpc = new SmtpClient("smtp.vatasinfotech.com");
        smtpc.Credentials = new System.Net.NetworkCredential("register@vatasinfotech.com", "Save1234");
        smtpc.Send(mail);
        return "done";
    }

    [WebMethod]
    public string Send_Mail(string To, string From, string msg, string subject, string ID, string amt)
    {
        //Session["tur_ID"]

        common objcommon = new common();
        objcommon.updateTDSClient_Returns_Status(Convert.ToInt64(ID), subject, msg,amt);
        MailMessage mail = new MailMessage(From, To, subject, msg);
        mail.IsBodyHtml = true;
        SmtpClient smtpc = new SmtpClient("smtp.vatasinfotech.com");
        smtpc.Credentials = new System.Net.NetworkCredential("register@vatasinfotech.com", "Save1234");
        smtpc.Send(mail);
        return "done";
    }

    [WebMethod]
    public string fetchDataByIFSC(string IFSC)
    {
        bllBankBranches objbllBankBranches = new bllBankBranches();
        return objbllBankBranches.SelectBankByIFSC(IFSC);
    }

    [WebMethod]
    public double fetchConstIDVal(string NameID,string ConstID)
    {
        bllSalary objbllSalary = new bllSalary();
        return objbllSalary.getDataForConstID(ConstID, NameID);
    }
    [WebMethod (EnableSession=true)]    
    public int CheckT4Data(string ConstantId)
    {
        string[] Param = System.Text.RegularExpressions.Regex.Split(ConstantId, "~");
        int flag = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con_Main"].ConnectionString);
        SqlDataAdapter da2 = new SqlDataAdapter("select c1 from t4 where c2=@c2 and c40=@c40", con);
        da2.SelectCommand.Parameters.AddWithValue("@c2", Convert.ToInt32(Param[0]));
        da2.SelectCommand.Parameters.AddWithValue("@c40", HttpContext.Current.Session["AY"].ToString());
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        SqlConnection cn = new SqlConnection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        String strCn = ConfigurationManager.ConnectionStrings["Con_NonPoolable"].ToString();
        cn.ConnectionString = strCn;
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select COL3 from storetrans where constantid=@CID and subconstid=@SubConstId and col3!=0 and nameid=@nameid";
        cmd.Parameters.AddWithValue("@CID", Convert.ToInt32(Param[0]));
        cmd.Parameters.AddWithValue("@NameId", HttpContext.Current.Session["NameID"].ToString());
        cmd.Parameters.AddWithValue("@SubConstId",Convert.ToInt32(ds2.Tables[0].Rows[1][0]) );
        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        catch
        {
        }
        finally
        {
            cn.Close();
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            SqlCommand cmd1 = new SqlCommand("if exists(select * from storetrans where constantid=@CID and subconstid=@SubConst and nameid=@NameId) update storetrans set col3=@col3 where constantid=@CID and subconstid=@SubConst and nameid=@NameId else ", cn);
            string a = "123";
            cmd1.Parameters.AddWithValue("@CID", Convert.ToInt32(Param[0]));
            cmd1.Parameters.AddWithValue("@SubConst", Convert.ToInt32(ds2.Tables[0].Rows[0][0]));
            cmd1.Parameters.AddWithValue("@NameId", HttpContext.Current.Session["NameID"].ToString());

            cmd1.Parameters.AddWithValue("@col3", Param[1].ToString());
            cn.Open();
            cmd1.ExecuteNonQuery();
            cn.Close();
            flag = 1;
        }
        return flag;
       
    }

    [WebMethod]
    public string getIndexedCost(string DateOfImprovement)
    {
        string amtOfImprovement = "";
        string FY_Improvement = "";
            string NameID = "";
        string AY = "";
        string constID = "";
        
        string[] arr = System.Text.RegularExpressions.Regex.Split(DateOfImprovement, "~");
        DateOfImprovement = arr[1];
        amtOfImprovement = arr[0];
        NameID = arr[2];
        AY = arr[3];
        constID = arr[4];

        string[] arrDate = System.Text.RegularExpressions.Regex.Split(DateOfImprovement, "/");
        if (Convert.ToInt32(arrDate[1]) > 3)
        {
            FY_Improvement = arrDate[2] + "-" + (Convert.ToInt32(arrDate[2]) + 1).ToString();
        }
        else
        {
            FY_Improvement = (Convert.ToInt32(arrDate[2]) - 1).ToString() + "-" + arrDate[2];
        }

        Taxation.DataAccess.dalStoreTrans objdalStoreTrans = new Taxation.DataAccess.dalStoreTrans();
        return objdalStoreTrans.getIndexedCost_Improvement(FY_Improvement, amtOfImprovement, NameID, AY, constID);
    }

    [WebMethod(EnableSession = true)]
    public string setVType(string vtype)
    {
        HttpContext.Current.Session["Session_VType"] = vtype;
        return "vtype";
    }

    //[WebMethod (EnableSession = true)]
    //public void CopyDateStoreFTrans(string Val)
    //{
    //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con_Poolable"].ConnectionString);
    //    try
    //    {
    //        if(con.State==ConnectionState.Closed)
    //            con.Open();
    //        int Vtype = 11008;//Convert.ToInt32(Session["Vtype"]);
    //        string NameID = Session["NameID"].ToString();
    //        string ITR = Session["ITR"].ToString();
    //        string AY = Session["AY"].ToString();
            
    //        SqlCommand cmd = new SqlCommand("Proc_CopyDateStoreFTrans_11008", con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@Vtype", Vtype);
    //        cmd.Parameters.Add("@NameID", NameID);
    //        cmd.Parameters.Add("@AY", AY);
    //        cmd.Parameters.Add("@ITR", ITR);
    //        cmd.Parameters.Add("@Val", Val);
    //        cmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        if (con.State == ConnectionState.Open)
    //            con.Close();
    //    }
    //}
    
}
