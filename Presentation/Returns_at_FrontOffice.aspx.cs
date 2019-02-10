using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_Process_Returns_at_FrontOffice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindNewGrid();
    }

    public void BindNewGrid()
    {
        //if (Session["NameID"] != null)
        //{
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grd_Process_ReturnsAtFrontOffice";
            VGrid1.Parameters = "";
            VGrid1.DataBind();
            VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
            VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        //}
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        
    }
}