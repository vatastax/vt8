using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;

public partial class Default3 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        bllSalary objbllSalary = new bllSalary();
        gv1.DataSource = objbllSalary.getComputationSheet("1982112805", "46", "2015-2016", "1", "1");
        gv1.DataBind();
    }
}