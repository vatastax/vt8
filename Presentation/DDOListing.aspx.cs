using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Taxation.BusinessLogic;
public partial class Presentation_DDOListing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grdDDO";
		VGrid1.Parameters = Session["Job_ID"].ToString();
        //VGrid1.Parameters = Session["NameID"].ToString();	Dummy Parameter for testing
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
		dny_BOBtn.btn_buttonClick += new EventHandler(dny_BOBtn_btn_buttonClick);
    }

	void dny_BOBtn_btn_buttonClick(object sender, EventArgs e)
    {
		//Following 2 lines are to see the datatable that filled the current page Grid
        //DataTable dt = new DataTable();
        //dt = (DataTable)Session["GridData"];
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        bllSalary objbllSalary = new bllSalary();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        objbllStoreTrans.deleteUser_VType(Session["NameID"].ToString(), "15078");
        objbllSalary.FetchTransData("15078", Session["NameID"].ToString(), Session["ay"].ToString(), Convert.ToInt32(VGrid1.SelectedDataKey));
        //Session["IncomeTax_VType"] = "15078";
        //Response.Redirect("Profile");
        Response.Redirect("manageLinking.aspx?vtype=15078");
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }
}