using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class GenerateXSD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
       DataSet ds = new DataSet();
       ds.ReadXml(Server.MapPath("~/itr4demo.xml"));
       ds.WriteXmlSchema(Server.MapPath("ITR4.xsd"));
    }
    
}