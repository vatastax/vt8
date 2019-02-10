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

public partial class Presentation_Business_Master : System.Web.UI.Page
{
    bllEmployerMaster objEmployerMasterBLL = new bllEmployerMaster();
    static Int64 id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblMessage.Visible = false;
        if (Session["NameID"] == null)
            Response.Redirect("main.aspx");
        ViewState["vtype"] = "32";// Request.QueryString["Vtype"];
        if (!IsPostBack)
            bindGrid();
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        objEmployerMasterBLL.Delete(id);
        bindGrid();
    }

    protected void gvEmpMtr_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ddel")
        {
            objEmployerMasterBLL.Delete(Convert.ToInt64(e.CommandArgument));
            bindGrid();
        }
        else if (e.CommandName == "edt")
        {
            DataTable dt = new DataTable();
            id = Convert.ToInt64(e.CommandArgument);
            dt = objEmployerMasterBLL.Select(id);
            if (dt.Rows.Count > 0)
            {
                txtAddr.Text = dt.Rows[0]["Address"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtPAN.Text = dt.Rows[0]["PAN"].ToString();
                txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                ViewState["EmpID"] = dt.Rows[0]["EmpID"].ToString();
            }
        }
        else
        {
            Session["E_NameID"] = e.CommandArgument.ToString();
            Response.Redirect("Salary.aspx?vtype=40");
        }
    }

    private void bindGrid()
    {
        //gvEmpMtr.DataSource = objEmployerMasterBLL.SelectByAssessee(Session["NameID"].ToString(), 32);
        //gvEmpMtr.DataBind();
    }

    protected void gvEmpMtr_RowDataBound(object sender, GridViewRowEventArgs e)
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
        try
        {
            denEmployerMaster objEmployerMasterDEN;
            bllEmployerMaster objEmployerMasterBLL;
            objEmployerMasterDEN = new denEmployerMaster();
            objEmployerMasterBLL = new bllEmployerMaster();

            objEmployerMasterDEN.PAN = txtPAN.Text;
            objEmployerMasterDEN.Name = txtName.Text;
            objEmployerMasterDEN.TAN = "";
            objEmployerMasterDEN.Address = txtAddr.Text;
            objEmployerMasterDEN.PhoneNo = txtPhone.Text;
            objEmployerMasterDEN.TypeofEmployer = 0;
            objEmployerMasterDEN.Designation = txtDesignation.Text;
            objEmployerMasterDEN.PSR = 0;
            objEmployerMasterDEN.Designation = "Director";
            objEmployerMasterDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
            objEmployerMasterDEN.NameID = Session["NameID"].ToString();
            objEmployerMasterBLL.InsertDataEmployerMaster(objEmployerMasterDEN);
            txtAddr.Text = "";
            txtCountryName.Text = "";
            txtName.Text = "";
            txtPAN.Text = "";
            txtPhone.Text = "";
            txtStateName.Text = "";
            lblMessage.Text = "Information Added Successfully!!";
            bindGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Salary.aspx?vtype=41");   
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            denEmployerMaster objEmployerMasterDEN;
            bllEmployerMaster objEmployerMasterBLL;
            objEmployerMasterDEN = new denEmployerMaster();
            objEmployerMasterBLL = new bllEmployerMaster();

            objEmployerMasterDEN.PAN = txtPAN.Text;
            objEmployerMasterDEN.Name = txtName.Text;
            objEmployerMasterDEN.Address = txtAddr.Text;
            objEmployerMasterDEN.PhoneNo = txtPhone.Text;
            objEmployerMasterDEN.Designation = txtDesignation.Text;
            objEmployerMasterDEN.TypeofEmployer = 0;
            objEmployerMasterDEN.EmpID = Convert.ToInt32(ViewState["EmpID"]);
            objEmployerMasterBLL.UpdateDataEmployerMaster(objEmployerMasterDEN);
            txtAddr.Text = "";
            txtCountryName.Text = "";
            txtName.Text = "";
            txtPAN.Text = "";
            txtPhone.Text = "";
            txtStateName.Text = "";
            lblMessage.Text = "Information Updated Successfully!!";
            bindGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string getEmpType(string type)
    {
        string strType = "";
        if (type == "0")
            strType = "Government";
        else if (type == "1")
            strType = "PSU";
        else
            strType = "Others";
        return strType;
    }
}
