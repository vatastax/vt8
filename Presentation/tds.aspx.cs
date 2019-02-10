using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tds : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["project"] = "tds";
        ltWelcome.Text = "Welcome <a href='../Presentation/' style=' text-transform: capitalize'>" + Session["user_name"].ToString() + "</a>";
    }
    protected void lbtnLogout1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logout.aspx");
        //Session.Abandon();
        //Response.Redirect("Default.aspx");
    
    }
    protected void lnkRegular_Click(object sender, EventArgs e)
    {
        Session["Regular_Correction"] = "Regular";
        if (Session["UserRole"] != null)
        {
            if (Session["UserRole"].ToString() == "Reception")
                Response.Redirect("Reception/Default.aspx");
            else if (Session["UserRole"].ToString() == "Supervisor")
                Response.Redirect("Supervisor.aspx");
            else if (Session["UserRole"].ToString() == "Operator")
                Response.Redirect("Operator.aspx");
        }
        Response.Redirect("Main.aspx");
    }
    protected void lnkRegularImport_Click(object sender, EventArgs e)
    {
        Session["Regular_Correction"] = "Regular_Import";//lnkCorrectionImport.Text;
        Response.Redirect("Import.aspx");
    }
    protected void lnkCorrectionImport_Click(object sender, EventArgs e)
    {
        Session["Regular_Correction"] = "Correction_Import";//lnkCorrectionImport.Text;
        Response.Redirect("Import.aspx");
    }
    protected void lnkCorrectionForm_Click(object sender, EventArgs e)
    {
        Session["Regular_Correction"] = "Correction";//lnkCorrectionForm.Text;
        Response.Redirect("Main.aspx");
    }
}