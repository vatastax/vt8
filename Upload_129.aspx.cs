using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Taxation.BusinessLogic;

public partial class Presentation_Upload_129 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grd_Report_Upload_129";
		//#Paramters/
        //VGrid1.Parameters = Session["NameID"].ToString();	Dummy Parameter for testing
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        VGrid1.VGrid_PageIndexChanging += new EventHandler(VGrid1_VGrid_PageIndexChanging);
		dny_BOBtn.btn_buttonClick += new EventHandler(dny_BOBtn_btn_buttonClick);
    }

    void VGrid1_VGrid_PageIndexChanging(object sender, EventArgs e)
    {
        
    }

	 protected void Page_PreRender(object sender, EventArgs e)
    {
        if (dny_BOBtn.Client_NoAction == "N" && Session["MethodReturn"] != null)
        {
            if (Session["MethodReturn"] != "")
            {
                Response.Redirect("manageLinking.aspx?vtype=101");
            }
        }
    }

	void dny_BOBtn_btn_buttonClick(object sender, EventArgs e)
    {
		//Following 2 lines are to see the datatable that filled the current page Grid
        //DataTable dt = new DataTable();
        //dt = (DataTable)Session["GridData"];
		dny_BOBtn.Client_NoAction = "N";
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