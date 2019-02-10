using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Odbc;

/// <summary>
/// Summary description for Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService {

    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] GetSearchList(string contextKey, string prefixText)
    {

        string[] arrfield = new string[2];
        arrfield = (string[])contextKey.Split('&');
        string strQuery = arrfield[0].ToString();
        strQuery = strQuery.Replace("#", prefixText);
        string fieldName = arrfield[1].ToString();
        string strConnName, strConnectionString;
        strConnName = ConfigurationManager.AppSettings["DatabaseEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        OdbcConnection con = new OdbcConnection(strConnectionString);
        OdbcDataAdapter da = new OdbcDataAdapter(strQuery, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        List<string> Completionset1 = new List<string>();
        int countdata = dt.Rows.Count;

        for (int i = 0; i < countdata; i++)
        {
            Completionset1.Add(dt.Rows[i][fieldName].ToString());
        }
        return Completionset1.ToArray();
    }

    
    
}

