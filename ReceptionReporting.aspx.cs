using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Taxation.BusinessLogic;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.IO;

public partial class Presentation_ReceptionReporting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grdReception";
		//#Paramters/
        //VGrid1.Parameters = Session["NameID"].ToString();	Dummy Parameter for testing
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
		dny_BOBtn.btn_buttonClick += new EventHandler(dny_BOBtn_btn_buttonClick);
    }

	 protected void Page_PreRender(object sender, EventArgs e)
    {
        if (dny_BOBtn.Client_NoAction == "N")
        {
            dny_BOBtn.Client_NoAction = "N";
            Response.Redirect(Request.RawUrl);
        }
    }

     void dny_BOBtn_btn_buttonClick(object sender, EventArgs e)
     {
         DataTable dt2 = new DataTable();
         dt2 = VGrid1.GridCheckedRows();
         dny_BOBtn.Client_NoAction = "N";
         DataSet ds = new DataSet();
         ds.Tables.Add(dt2);

         if (((Button)sender).Text == "Save")
         {
             DataTable dtt = dt2.Copy();
             string sa = VGrid1.SelectedDataKey;
             DataTable dtSession = (DataTable)Session["GridData"];
             dtt.Columns.RemoveAt(dtt.Columns.Count - 1);
             dtt.Columns.RemoveAt(dtt.Columns.Count - 1);
             dtt.Columns.RemoveAt(dtt.Columns.Count - 1);
             dtt.Columns.RemoveAt(dtt.Columns.Count - 1);
             dtt.Columns.RemoveAt(dtt.Columns.Count - 1);
             dtt.Columns.RemoveAt(dtt.Columns.Count - 1);
             dtt.Columns.RemoveAt(dtt.Columns.Count - 1);
             dtt.Columns.RemoveAt(dtt.Columns.Count - 1);
             Session["CustomSession"] = dtt;
         }
         else if (((Button)sender).Text == "Export To Excel")
         {
             Session["CustomSession"] = ds;
         }
         else if (((Button)sender).Text == "Export To PDF")
         {
             Session["CustomSession"] = ds;
         }
         else if (((Button)sender).Text == "Export To Doc")
         {
             Session["CustomSession"] = ds;
         }
         else if (((Button)sender).Text == "Send Email")
         {
             DataTable dtData = new DataTable();
             DataColumn col1 = new DataColumn("To", Type.GetType("System.String"));
             DataColumn col2 = new DataColumn("From", Type.GetType("System.String"));
             DataColumn col3 = new DataColumn("Subject", Type.GetType("System.String"));
             DataColumn col4 = new DataColumn("attachment1", Type.GetType("System.String"));
             DataColumn col5 = new DataColumn("attachment2", Type.GetType("System.String"));
             DataColumn col6 = new DataColumn("EmailBody", Type.GetType("System.String"));

             dtData.Columns.Add(col1);
             dtData.Columns.Add(col2);
             dtData.Columns.Add(col3);
             dtData.Columns.Add(col4);
             dtData.Columns.Add(col5);
             dtData.Columns.Add(col6);

             DataRow row1 = dtData.NewRow();
             row1[0] = "ankush.passion@gmail.com";
             row1[1] = "contact@vatasinfotech.com";
             row1[2] = "This is Testing";
             row1[3] = Server.MapPath("./abc.xlsx");
             row1[4] = "";
             row1[5] = "Please find attached";
             dtData.Rows.Add(row1);
             Session["CustomSession"] = dtData;
         }

     }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)VGrid1.SelectedRow;        
        bllSalary objbllSalary = new bllSalary();
        objbllSalary.FetchTransData("101", Session["NameID"].ToString(), Session["ay"].ToString(), Convert.ToInt32(VGrid1.SelectedDataKey));
        Session["IncomeTax_VType"] = "101";
        Response.Redirect("IncomeTax");
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

}