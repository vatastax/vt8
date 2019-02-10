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
using Taxation.BusinessLogic;
using Taxation.DataEntity;
using System.Collections.Generic;


public partial class Presentation_Bank_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NameID"] == null)
            Response.Redirect("Main.aspx");
        if (!IsPostBack)
            bindGrid();
    }

    private void bindGrid()
    {
        //bllBankMast objbllBankMast = new bllBankMast();
        //gvBank.DataSource = objbllBankMast.SelectByAssesse(Convert.ToInt64(Session["NameID"]));
        //gvBank.DataBind();
    }
    protected void Button7_Click(object sender, EventArgs e)
    {

    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        denBankMast objBankMastDEN;
        bllBankMast objBankMastBLL;
        objBankMastDEN = new denBankMast();
        objBankMastBLL = new bllBankMast();
        objBankMastDEN.AssesseeID = Convert.ToInt32(Session["NameID"]);        
        objBankMastDEN.BankName = txtBankName.Text;
        objBankMastDEN.MICRCode = txtMICR.Text;
        objBankMastDEN.Address = txtAddress.Text;
        objBankMastDEN.AccountType = Convert.ToInt16(ddAccountType.SelectedValue);
        objBankMastDEN.AccountNo = txtAccountNo.Text;
        objBankMastDEN.ECS = ddECS.SelectedValue;

        objBankMastBLL.InsertDataBankMast(objBankMastDEN);

        bindGrid();

    }
    protected void Save_Click(object sender, EventArgs e)
    {
        denBankMast objBankMastDEN;
        bllBankMast objBankMastBLL;
        objBankMastDEN = new denBankMast();
        objBankMastBLL = new bllBankMast();
        objBankMastDEN.AssesseeID = Convert.ToInt64(Session["NameID"]);
        objBankMastDEN.BankID = Convert.ToInt32(ViewState["BankID"]);
        objBankMastDEN.BankName = txtBankName.Text;
        objBankMastDEN.MICRCode = txtMICR.Text;
        objBankMastDEN.Address = txtAddress.Text;
        objBankMastDEN.AccountType = Convert.ToInt16(ddAccountType.SelectedValue);
        objBankMastDEN.AccountNo = txtAccountNo.Text;
        objBankMastDEN.ECS = ddECS.SelectedValue;

        objBankMastBLL.UpdateDataBankMast(objBankMastDEN);
        bindGrid();
    }

    protected void gvBank_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            bllBankMast objbllBankMast = new bllBankMast();
            List<denBankMast> objList = new List<denBankMast>();
            objList = objbllBankMast.Select(Convert.ToInt32(e.CommandArgument));
            txtAccountNo.Text = objList[0].AccountNo;
            txtAddress.Text = objList[0].Address;
            txtBankName.Text = objList[0].BankName;
            txtMICR.Text = objList[0].MICRCode;
            ddAccountType.SelectedValue = objList[0].AccountType.ToString();
            ddECS.SelectedValue = objList[0].ECS.ToString();
            ViewState["BankID"] = objList[0].BankID.ToString();
        }
        else
        {
            bllBankMast objbllBankMast = new bllBankMast();
            objbllBankMast.Delete(Convert.ToInt32(e.CommandArgument));
            bindGrid();
        }
    }

    protected void gvBank_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            Label lblSNO = new Label();
            lblSNO = (Label)e.Row.FindControl("lblSNO");
            lblSNO.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
}
