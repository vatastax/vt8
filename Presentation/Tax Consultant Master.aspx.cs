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

public partial class Presentation_Tax_Consultant_Master : System.Web.UI.Page
{
    bllConsultantMast objbllConsultantMast = new bllConsultantMast();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NameID"] == null)
            Response.Redirect("main.aspx");

        //bindGrid();
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
                txtFName.Text = objdenConsultantMast.FirmName;
                txtMembershipNo.Text = objdenConsultantMast.MembershipNo;
                txtName.Text = objdenConsultantMast.AuditorName;
                txtPAN.Text = objdenConsultantMast.PAN;
                txtPhoneNo.Text = objdenConsultantMast.Phone;
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        denConsultantMast objdenConsultantMast = new denConsultantMast();
        objdenConsultantMast.Address = txtAddress.Text;
        objdenConsultantMast.AuditorName = txtName.Text;
        objdenConsultantMast.ConsultID = 0;
        objdenConsultantMast.FirmName = txtFName.Text;
        objdenConsultantMast.MembershipNo = txtMembershipNo.Text;
        objdenConsultantMast.PAN = txtPAN.Text;
        objdenConsultantMast.Phone = txtPhoneNo.Text;
        objdenConsultantMast.Vtype = 0;
        objdenConsultantMast.NameID = Convert.ToInt64(Session["NameID"]);
        bllConsultantMast objbllConsultantMast = new bllConsultantMast();
        objbllConsultantMast.InsertConsultantMast(objdenConsultantMast);
        lblMsg.Text = "Record Added Successfully";
        bindGrid();
    }

}
