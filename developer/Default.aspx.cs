using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class developer_Default : System.Web.UI.Page
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

            VGrid1.GridName = "grdErrorLog";
            VGrid1.DataBind();

            //VGrid1.VGrid_Delete += new EventHandler(VGrid1_VGrid_Delete);
            VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        
            //VGrid1.VGrid_Update += new EventHandler(VGrid1_VGrid_Update);
            VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        //}
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.SelectedRow;
        string ss = dtGrid.Rows[0][2].ToString();
        ss = dtGrid.Rows[0][0].ToString();
        DropDownList dd = new DropDownList();
        
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        GridView gv1 = (GridView)sender;
        DataTable dt = new DataTable();
        GridViewCommandEventArgs ee = (GridViewCommandEventArgs)e;
        if (ee.CommandArgument != "")
        {
            int grdIndx = Convert.ToInt32(ee.CommandArgument);
            string ID = ((Label)gv1.Rows[grdIndx].FindControl("id")).Text;
            string SolvedBy = ((DropDownList)gv1.Rows[grdIndx].FindControl("Drp1")).SelectedItem.Text;
            //string SolvedBy = ((Label)gv1.Rows[grdIndx].FindControl("Lbl1")).Text;
            
            tbl_ErrorLog objtbl_ErrorLog = new tbl_ErrorLog();
            objtbl_ErrorLog.id = Convert.ToInt64(ID);
            objtbl_ErrorLog.methodName = SolvedBy;            
            common objcommon = new common();
            objcommon.updateError(objtbl_ErrorLog);
        }

    }
}