using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Project"] = "vt";
        bindWhatsNew();
    }
    //bind whats new
    public void bindWhatsNew()
    {
        balWhatsNew objWhatNew = new balWhatsNew();
        DataSet ds = new DataSet();
        ds = objWhatNew.GetNew();
       grdNews.DataSource = ds;
        grdNews.DataBind();

    }
}