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

public partial class Presentation_Assessee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["AssesseeType"] = ddlAssesseeList.SelectedValue;
        string strtarget = Convert.ToString(Session["AssesseeType"]);
        if (strtarget == "Individual")
            Response.Redirect("individual.aspx");
        else if (strtarget == "Hindu Undivided Family")
            Response.Redirect("HUF.aspx");
        else if (strtarget == "Partnership")
            Response.Redirect("partnership.aspx");
        else if (strtarget == "Company")
            Response.Redirect("company.aspx");
        else if (strtarget == "Association of Persons")
            Response.Redirect("AOP.aspx");
        else if (strtarget == "Cooperative Society")
            Response.Redirect("cooperative.aspx");
        
    }
}
