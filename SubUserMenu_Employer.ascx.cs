using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using Taxation.BusinessLogic;
using System.Data;

public partial class SubUserMenu_Employer : System.Web.UI.UserControl
{
    dalEmployerMaster objdalEmployerMaster = new dalEmployerMaster();
    denEmployerMaster objdenEmployerMaster = new denEmployerMaster();
    static DataTable dtMain = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int type = 0;
            if (Request.QueryString["vtype"].ToString() == "40")
            {
                type = 31;
                ltTitle.Text = "Employer";
                ltTitle2.Text = "Employer";
                aLnk.HRef = "Presentation/EmployerMaster.aspx";
            }
            else if (Request.QueryString["vtype"].ToString() == "41")
            {
                type = 32;
                ltTitle.Text = "Business";
                ltTitle2.Text = "Business";
                aLnk.HRef = "Presentation/BusinessMaster.aspx";
            }

            if (Request.UrlReferrer != null)
            {
                if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                {
                    Session["E_NameID"] = null;
                    dtMain.Rows.Clear();
                    dtMain.Clear();
                    dtMain = objdalEmployerMaster.SelectByAssessee(Convert.ToString(Session["NameID"]), type);
                    if (dtMain.Rows.Count > 0)
                    {
                        Session["E_NameID"] = dtMain.Rows[0]["EmpID"].ToString();
                        Session["E_Name"] = dtMain.Rows[0]["Name"].ToString();
                    }                    
                }
            }

            if (dtMain.Rows.Count < 1)
            {
                dtMain = objdalEmployerMaster.SelectByAssessee(Convert.ToString(Session["NameID"]), type);
                if (dtMain.Rows.Count > 0)
                {
                    Session["E_NameID"] = dtMain.Rows[0]["EmpID"].ToString();
                    Session["E_Name"] = dtMain.Rows[0]["Name"].ToString();
                }
            }
            gvEmp.DataSource = dtMain;
            gvEmp.DataBind();
            if (Request.QueryString["vtype"].ToString() == "41")
            {
                gvEmp.Columns[2].Visible = false;
                gvEmp.Columns[1].HeaderText = "Business";
            }
            else
            {
                gvEmp.Columns[2].Visible = true;
                gvEmp.Columns[1].HeaderText = "Employer";
                gvEmp.ShowHeader = true;
            }
            
        }
    }
    protected void gvEmp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == -1)
        {
            if (gvEmp.Rows.Count > 0)
                e.Row.Cells[1].Text = ltTitle.Text;

        }
        if (e.Row.RowIndex != -1)
        {
            Label lblSNO = new Label();
            Label lblEmpID = new Label();

            lblSNO = (Label)e.Row.FindControl("lblSNO");
            lblSNO.Text = (e.Row.RowIndex + 1).ToString();

            lblEmpID = (Label)e.Row.FindControl("lblEmpID");
            if (Session["E_NameID"] != null)
            {
                if (lblEmpID.Text == Session["E_NameID"].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }
    }

    protected void gvEmp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Session["E_NameID"] = e.CommandArgument.ToString();
        LinkButton lbtn = new LinkButton();
        lbtn = (LinkButton)e.CommandSource;
        Session["E_Name"] = lbtn.Text;
        //Response.Redirect("Salary.aspx?vtype=40");
        Response.Redirect(Request.Url.ToString());
    }

    void SelectDataIndividual(string PAN)
    {
        try
        {        
            DataTable dt = new DataTable();
            dt = objdalEmployerMaster.Select(Convert.ToInt64(Session["E_NameID"]));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}