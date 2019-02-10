using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataEntity;
using System.Data;

public partial class Presentation_Supervisor : System.Web.UI.Page
{
    string Org = "5";
    static string ITRXML_ID = "";
    static int StateID = 26;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            balAdmin objbalAdmin = new balAdmin();
            tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
            objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(Session["user_ID"]));
            Org = objtbl_UserRegistration.OrganizationName;
            BindNewGrid();
        //}
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)VGrid1.SelectedRow;

    }

    public void BindNewGrid()
    {
        if (Session["Project"].ToString()=="vt")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grdAssesseeFirm_Super";
            VGrid1.Parameters = Org;
            VGrid1.DropDownParameters = Org;
            VGrid1.DataBind();
            VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
            VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        }
        else if (Session["Project"].ToString() == "tds")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grdDeducteeFirm_Super";
            VGrid1.Parameters = Org;
            VGrid1.DropDownParameters = Org;
            VGrid1.DataBind();
            VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
            VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        }
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.SelectedRow;
        string ss = dtGrid.Rows[0][2].ToString();
        ITRXML_ID = dtGrid.Rows[0][0].ToString();
        Session["UpdateXML"] = "sel";
        Session["ITR"] = dtGrid.Rows[0][2].ToString();
        Session["ay"] = dtGrid.Rows[0][10].ToString();
        Session["ReturnType"] = dtGrid.Rows[0][9].ToString();
        Session["NameID"] = dtGrid.Rows[0][3].ToString();
        Session["ITRXML_ID"] = ITRXML_ID.ToString();
        Session["AssesseeType"] = "0";
        //Response.Redirect("Main.aspx?ut=o");
        common objcommon = new common();
        if (Session["Project"].ToString() == "vt")
            objcommon.startProcessHistoryJob(Convert.ToInt64(dtGrid.Rows[0][1]), Convert.ToInt64(dtGrid.Rows[0][4]), "Supervisor", "N");
        else if (Session["Project"].ToString() == "tds")
            objcommon.startProcessHistoryJob(Convert.ToInt64(dtGrid.Rows[0][0]), Convert.ToInt64(dtGrid.Rows[0][3]), "Supervisor", "N");

        Response.Redirect(Request.Url.ToString());
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }
}