using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_aa22 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grd_Clients_TDS";        
        VGrid1.Parameters = Session["NameID"].ToString();
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["IncomeTax_VType"] = "12121";
        Response.Redirect("IncomeTax");
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}