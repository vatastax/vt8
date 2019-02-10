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

public partial class Presentation_CompanyAdditional : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ddlCompany.SelectedIndex == 2)
        {
            lblCompName.Visible = false;
            txtCompName.Visible = false;
            lblCompAddress.Visible = false;
            txtCompAddress.Visible = false;
            lblCompPAN.Visible = false;
            txtCompPAN.Visible = false;
        }


    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompany.SelectedIndex != 2)
        {
            lblCompName.Visible = true;
            txtCompName.Visible = true;
            lblCompAddress.Visible = true;
            txtCompAddress.Visible = true;
            lblCompPAN.Visible = true;
            txtCompPAN.Visible = true;
        }



    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["strName"] = txtCompName.Text;
        e.InputParameters["strPAN"] = txtCompPAN.Text;
        e.InputParameters["strAddress"] = txtCompAddress.Text;
    }
    protected void btnCreateRow_Click(object sender, EventArgs e)
    {
        bllCompAdditional objCompAdditional = new bllCompAdditional();
        //objCompAdditional.ShowTempGrid(txtCompName.Text, txtCompAddress.Text, txtCompPAN.Text);

        GridView1.DataSourceID = "";
        GridView1.DataSourceID = "ObjectDataSource3";
    }
}
