using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using System.Data;

public partial class Presentation_report2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Auto Redirect on Session Out
        int reason = 0;
        if (!common.IsLoggedIn(out reason))
        {
            if (reason == 1)
            {
                Session["reason_logout"] = "suspecious_attempt";
            }
            Response.Redirect("Logout.aspx");
        }

        bllSalary objbllSalary = new bllSalary();
        DataSet ds = new DataSet();
        ds = objbllSalary.getComputationSheet(Session["NameID"].ToString(), "46", "2015-2016", "1", "1");
        //gv1.DataSource = ds;
        //gv1.DataBind();

        string str = "";
        foreach (DataTable dt in ds.Tables)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    //if (i % 2 == 0)
                    if (dt.Columns.Count == 1)
                        str += "<b>" + dt.Rows[i][j].ToString() + "&nbsp;&nbsp;" + "</b>";
                    else
                        str += dt.Rows[i][j].ToString() + "&nbsp;&nbsp;";
                }
                str += "<br/><br/>";
            }
        }
        ltReport.Text = str;
    }
}