using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Taxation.BusinessLogic;

public partial class Presentation_Employee_HouseProperty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grdProperty";
		VGrid1.Parameters = Session["NameID"].ToString()+","+Session["NameID"].ToString()+","+Session["NameID"].ToString()+","+Session["NameID"].ToString()+","+Session["NameID"].ToString()+","+Session["NameID"].ToString()+","+Session["NameID"].ToString();
        //VGrid1.Parameters = Session["NameID"].ToString();	Dummy Parameter for testing
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
		dny_BOBtn.btn_buttonClick += new EventHandler(dny_BOBtn_btn_buttonClick);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (dny_BOBtn.Client_NoAction == "N")
            Response.Redirect("manageLinking.aspx?vtype=13012");

    }

	void dny_BOBtn_btn_buttonClick(object sender, EventArgs e)
    {
		//Following 2 lines are to see the datatable that filled the current page Grid
        //DataTable dt = new DataTable();
        //dt = (DataTable)Session["GridData"];
        dny_BOBtn.Client_NoAction = "N";
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        string MainID = objbllStoreTrans.getMainID(Session["NameId"].ToString(), "13012");
        Session["MainID"] = MainID;    //(Session["MainID"] != null) ? (Convert.ToInt32(Session["MainID"]) + 1).ToString() : "1";
        Session["E_NameID"] = Session["MainID"].ToString();
        ViewState["MainID"] = Session["MainID"].ToString();
        dny_BOBtn.Client_NoAction = "N";
		//Session["IncomeTax_VType"] = 13012;
        //Response.Redirect("IncomeTax");
        //Response.Redirect("manageLinking.aspx?vtype=13012");
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.SelectedRow;
        int row_indx = Convert.ToInt32(dtGrid.Rows[0][0]);

        Session["MainID"] = (Convert.ToInt32(VGrid1.SelectedIndex) + 1).ToString();
        ViewState["MainID"] = (Convert.ToInt32(VGrid1.SelectedIndex) + 1).ToString();
        Session["E_Name"] = dtGrid.Rows[0][1].ToString();
        Response.Redirect("manageLinking.aspx?vtype=13012");
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }
}