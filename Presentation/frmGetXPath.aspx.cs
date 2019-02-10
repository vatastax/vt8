using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Presentation_frmGetXPath : System.Web.UI.Page
{
    balXML objbalXML = new balXML();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (flUploadXml.HasFile)
        {
            string fileName = Path.Combine(Server.MapPath("../xmlUpload/"),flUploadXml.FileName);
            flUploadXml.SaveAs(fileName);
            string xml = File.ReadAllText(fileName);
            //xml = xml.Replace(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>", "");
            DataTable dt = new DataTable();
            dt = objbalXML.GetXPath(xml);
            ddlXpath.DataTextField = "FullPath";
            ddlXpath.DataValueField = "ID";
            ddlXpath.DataSource = dt;
            ddlXpath.DataBind();
        }
    }
}