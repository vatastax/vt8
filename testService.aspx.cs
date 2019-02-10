using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.IO;
using System.Data;

public partial class testService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.PreviousPage != null)
        {
            TextBox txtt = (TextBox)Page.PreviousPage.FindControl("Textbox2");
            Response.Write(txtt.Text);
        }
        asd.Name = "This is a good idea";
        Taxation.BusinessLogic.bllSalary objSal = new Taxation.BusinessLogic.bllSalary();
        DataTable dt = new DataTable();
        dt = objSal.Select("select * from storetrans where col3!='0' and ay='2016-2017' and GRowNo>2");
        dt.DefaultView.RowFilter = "EntryID=3";
        DataTable dt2 = new DataTable();
        dt2 = dt.DefaultView.ToTable();
        gv1.DataSource = dt2;//.DefaultView;
        gv1.DataBind();

        HttpCookie cookie1 = new HttpCookie("name", "ankush");
        cookie1.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(cookie1);

        
    }

    protected void btn11_Click(object sender, EventArgs e)
    {
        HttpCookie cook = Request.Cookies["name"];
        ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('" + cook.Value + "'); </script>");
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        Execute();
    }

    public void Execute()
    {
        
        HttpWebRequest request = CreateWebRequest();
        XmlDocument soapEnvelopeXml = new XmlDocument();
        soapEnvelopeXml.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:v=""http://incometaxindiaefiling.gov.in/ditws/tds/v_1_0"">
<soapenv:Header />
<soapenv:Body>
<v:getTDSDetails>

<v:LoginInfo>
<v:userName>ERIA100133</v:userName>
<v:password>gill123456@</v:password>
</v:LoginInfo>

<v:ClientInfo>
<v:pan>ABCPC9667J</v:pan>
<v:dob>02/02/1955</v:dob>
<v:assessmentYear>2011-12</v:assessmentYear>
</v:ClientInfo>
</v:getTDSDetails>
</soapenv:Body>
</soapenv:Envelope>
");
        try
        {
            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Response.Write(soapResult);
                    //Console.WriteLine(soapResult);
                }
            }
        }
        catch (Exception ex) { throw ex; }
    }
    /// <summary>
    /// Create a soap webrequest to [Url]
    /// </summary>
    /// <returns></returns>
    public HttpWebRequest CreateWebRequest()
    {
        //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"dev.nl/Rvl.Demo.TestWcfServiceApplication/SoapWebService.asmx");
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://incometaxindiaefiling.gov.in/e-FilingWS/ditws/Get26asInfo.wsdl");
        //webRequest.UserAgent = ".NET Framework Test Client";
        webRequest.Headers.Add(@"SOAP:Action");
        webRequest.ContentType = "text/xml;charset=\"utf-16\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }

}