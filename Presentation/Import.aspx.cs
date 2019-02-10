using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_Import : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ISExistMaster"] != null)
        {
            if (Session["ISExistMaster"].ToString() != "true")
            {
                mm1.Visible = false;
            }
        }
    }
}