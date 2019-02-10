using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataEntity;
using System.Data;

public partial class Presentation_Reception_Default : System.Web.UI.Page
{
    string Org = "5";
    static string ITRXML_ID = "";
    static int StateID = 26;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Project"].ToString() == "tds")
            btnAddAssessee.Text = "Add New Deductee";
        balAdmin objbalAdmin = new balAdmin();
        tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
        objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(Session["user_ID"]));
        Org = objtbl_UserRegistration.OrganizationName;
        BindNewGrid();
    }
    public void BindNewGrid()
    {

        //if (Session["NameID"] != null)
        //{
        if (Session["Project"].ToString() == "vt")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grdMain";
            VGrid1.Parameters = Org;
            VGrid1.DataBind();
        }
        else if (Session["Project"].ToString() == "tds")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grdMain_Deductee";
            VGrid1.Parameters = Org;
            VGrid1.DataBind();
        }

        VGrid1.AlternatingRowStyle = "bgo";
        //VGrid1.VGrid_Delete += new EventHandler(VGrid1_VGrid_Delete);
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);

        //}
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //GridControl.VGrid vg1 = (GridControl.VGrid)sender;       
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {   
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.SelectedRow;
        if (Session["Project"].ToString() == "vt")
        {
            ITRXML_ID = dtGrid.Rows[0][0].ToString();

            //this session variable is to check whether the assessee is going to Assesseeform through login or direct
            //if he goes direct then this variable will <>1 and the form will be empty.
            Session["Exists"] = 1;
            Session["Bool"] = "False";
            Session["Mode"] = "New";
            Session["PAN"] = dtGrid.Rows[0][2].ToString();
            Session["Status"] = "0";
            Session["NameID"] = dtGrid.Rows[0][0].ToString();// dt.Rows[ii]["ID"].ToString();
            Session["E_NameID"] = null;
            Session["restore"] = null;
            Session["AssesseeType"] = "0";
            Session["AType"] = "";
            Session["DateofBirth"] = dtGrid.Rows[0][4].ToString(); //(dd.Year + "-" + ((dd.Month.ToString().Length > 1) ? dd.Month.ToString() : ("0" + dd.Month.ToString())) + "-" + dd.Day).ToString();

            LinkButton lnkName2 = new LinkButton();
            if (Session["Project"].ToString() == "vt")
                Session["tab"] = "1";
            else
                Session["tab"] = "5";

            bllDocTrans objbllDocTrans = new bllDocTrans();
            StateID = objbllDocTrans.getState(Session["NameID"].ToString());
            Session["UpdateXml"] = "sel";
            Response.Redirect("Reception.aspx");
        }
        else if (Session["Project"].ToString() == "tds")
        {
            Session["TAN"] = dtGrid.Rows[0][2].ToString();
            Response.Redirect("LstTAN.aspx");
        }

    }

    protected void btnAddAssessee_Click(object sender, EventArgs e)
    {
        if (Session["Project"].ToString() == "tds")
        {
            Response.Redirect("../TanMaster.aspx");
        }
        else if (Session["Project"].ToString() == "vt")
        {
            Session["Mode"] = "New";
            Session["Bool"] = "False";
            string sss = Session["Project"].ToString();
            if (Session["Project"].ToString() == "vt" || Session["Project"].ToString() == "stax")
            {
                Response.Redirect("../Assesseeselect.aspx");
            }
        }
    }
}