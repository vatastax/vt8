using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
using System.Collections.Generic;

public partial class Presentation_Auditor_Master : System.Web.UI.Page
{
    bllAuditorMaster objAuditorMasterBLL;
    bllConsultantMast objbllConsultantMast = new bllConsultantMast();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objAuditorMasterBLL = new bllAuditorMaster();
            denConsultantMast objConsultantMastDEN = new denConsultantMast();
            objConsultantMastDEN.PAN = (Session["PAN"] != null) ? Session["PAN"].ToString() : "";
            objConsultantMastDEN = objAuditorMasterBLL.Select(objConsultantMastDEN);
            txtAddress.Text = objConsultantMastDEN.Address;
            txtCountryName.Text = "";
            txtFirmName.Text = objConsultantMastDEN.FirmName;
            txtMember.Text = objConsultantMastDEN.AuditorName;
            txtName.Text = objConsultantMastDEN.AuditorName;
            txtPAN.Text = objConsultantMastDEN.PAN;
            txtPhone.Text = objConsultantMastDEN.Phone;
            txtStateName.Text = "";// objConsultantMastDEN.st;

            if (Session["NameID"] == null)
                Response.Redirect("main.aspx");

            bindGrid();
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        emptyTextboxes();
    }

    private void bindGrid()
    {
        //gvCM.DataSource = objbllConsultantMast.Select(Convert.ToInt64(Session["NameID"]));
        //gvCM.DataBind();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

    }

    protected void gvCM_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ddel")
        {
            objbllConsultantMast.Delete(Convert.ToInt64(e.CommandArgument));
            bindGrid();
        }
        else
        {
            DataTable dt = new DataTable();
            denConsultantMast objdenConsultantMast = new denConsultantMast();
            objdenConsultantMast = objbllConsultantMast.SelectByConsultID(Convert.ToInt64(e.CommandArgument));
            if (objdenConsultantMast.AuditorName != "")
            {
                txtAddress.Text = objdenConsultantMast.Address;
                txtFirmName.Text = objdenConsultantMast.FirmName;
                txtMember.Text = objdenConsultantMast.MembershipNo;
                txtName.Text = objdenConsultantMast.AuditorName;
                txtPAN.Text = objdenConsultantMast.PAN;
                txtPhone.Text = objdenConsultantMast.Phone;
            }
        }
    }

    protected void gvCM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            Label lblSNO = new Label();
            lblSNO = (Label)e.Row.FindControl("lblSNO");
            lblSNO.Text = (e.Row.RowIndex + 1).ToString();
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        denConsultantMast objConsultantMastDEN;
        

        objConsultantMastDEN = new denConsultantMast();
        objAuditorMasterBLL = new bllAuditorMaster();

        objConsultantMastDEN.ConsultID = 2;
        objConsultantMastDEN.Vtype = 83;
        objConsultantMastDEN.AuditorName = txtName.Text;
        objConsultantMastDEN.Address = txtAddress.Text;
        objConsultantMastDEN.Phone = txtPhone.Text;
        objConsultantMastDEN.MembershipNo = txtMember.Text;
        objConsultantMastDEN.PAN = txtPAN.Text;
        objConsultantMastDEN.FirmName = txtFirmName.Text;
        objConsultantMastDEN.NameID = Convert.ToInt64(Session["NameID"]);

        objAuditorMasterBLL.InsertDataAuditorMaster(objConsultantMastDEN);
        bindGrid();

        emptyTextboxes();
    }

    private void emptyTextboxes()
    {
        txtAddress.Text = "";
        txtCountryName.Text = "";
        txtFirmName.Text = "";
        txtMember.Text = "";
        txtName.Text = "";
        txtPAN.Text = "";
        txtPhone.Text = "";
        txtStateName.Text = "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        denConsultantMast objConsultantMastDEN;

        objConsultantMastDEN = new denConsultantMast();
        objAuditorMasterBLL = new bllAuditorMaster();

        //objConsultantMastDEN.ConsultID = 2;
        //objConsultantMastDEN.Vtype = 83;
        objConsultantMastDEN.AuditorName = txtName.Text;
        objConsultantMastDEN.Address = txtAddress.Text;
        objConsultantMastDEN.Phone = txtPhone.Text;
        objConsultantMastDEN.MembershipNo = txtMember.Text;
        objConsultantMastDEN.PAN = txtPAN.Text;
        objConsultantMastDEN.FirmName = txtFirmName.Text;

        objAuditorMasterBLL.UpdateDataAuditorMaster(objConsultantMastDEN);
        bindGrid();
    }
}
