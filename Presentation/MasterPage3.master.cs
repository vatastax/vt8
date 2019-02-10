using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtnEditProf_Click(object sender, EventArgs e)
    {
        //Session["Mode"] = "Edit";
        //Session["InternalSal"] = "true";
        //Response.Redirect("Salary.aspx?vtype=106");

        Session["Mode"] = "Edit";
        Session["InternalSal"] = "true";
        Session["IncomeTax_VType"] = "106";
        Response.Redirect("Profile");
    }
}
