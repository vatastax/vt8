using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Taxation.BusinessLogic;

public partial class Presentation_Reception_LstTAN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["TAN"] != null)
            {
                BindGrid();
                tbl_AY objtbl_AY = new tbl_AY();
                DataTable dtAY = new DataTable();
                dtAY = objtbl_AY.Select();
                DropDownList1.DataSource = dtAY;
                DropDownList1.DataTextField = "FY";
                DropDownList1.DataValueField = "AY";
                DropDownList1.DataBind();
                ListItem LstF = new ListItem(" -- Select -- ", "-1");
                DropDownList1.Items.Insert(0, LstF);
            }

        }
    }
    public void BindGrid()
    {
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grd_DeducteeJobs";
        VGrid1.Parameters = Session["TAN"].ToString();
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string[] arrVal = System.Text.RegularExpressions.Regex.Split(DropDownList1.SelectedValue, "-");
        txtTDSAY.Text = DropDownList1.SelectedValue;// arrVal[1] + "-" + (Convert.ToInt32(arrVal[1]) + 1).ToString();
        //Button3.Visible = true;
        //hdnCG.Value = "";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        bllMain objbllMain = new bllMain();
        Session["ay"] = txtTDSAY.Text;//txtTDSAY.Text;// DropDownList2.SelectedItem.Text;
        Session["AY"] = txtTDSAY.Text;
        Session["FormType"] = ddFormType.SelectedItem.Text;//ddFormType.SelectedValue;
        Session["FY"] = DropDownList1.SelectedItem.Text;     //ddFY.SelectedValue;
        Session["qtr"] = DropDownList3.SelectedValue;
        Session["OC"] = ddRetType.SelectedValue;
        string Type = "";
        if (Session["Regular_Correction"] != null)
            Type = Session["Regular_Correction"].ToString();
        DataTable dt = new DataTable();
        dt = objbllMain.FormQuaeterMapping(ddFormType.SelectedItem.ToString(), DropDownList3.SelectedValue.ToString(), Type);
        if (dt.Rows.Count > 0)
        {
            Session["ITR"] = dt.Rows[0][0].ToString();//DropDownList3.SelectedValue.Substring(1, 1);
        }

        common objcommon = new common();
        bool IsJobExists = false;
        IsJobExists = objcommon.IsJobExists(Session["TAN"].ToString(), Session["FY"].ToString(), Session["FY"].ToString(), Session["FormType"].ToString(), Session["OC"].ToString());
        if (!IsJobExists)
            objcommon.SaveJob_TDS(Session["userEmail"].ToString());

        objbllMain.TDSMasterDetails(Session["TAN"].ToString(), Session["FY"].ToString(), "Regular", Session["qtr"].ToString(), Session["FormType"].ToString(), Session["AY"].ToString());
        Session["AssesseeType"] = "999999"; //Default Assessee Type for TDS as there is no Assessee Type in TDS
        //Response.Redirect("DisplayForm.aspx");
        Session["IncomeTax_VType"] = "3001";
        Response.Redirect(Request.Url.ToString());
    }
}