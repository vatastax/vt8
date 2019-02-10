using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Taxation.BusinessLogic;

public partial class Presentation_lstErrors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        common objcommon = new common();
        DataTable dtErr = new DataTable();

        dtErr = objcommon.Select_AssesseeErrors(Session["NameID"].ToString(), Session["AY"].ToString());
        if (dtErr.Rows.Count > 0)
        {
            gvError.DataSource = dtErr;
            gvError.DataBind();
        }
    }

    protected void gvError_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
}