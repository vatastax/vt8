using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testing : System.Web.UI.UserControl
{
    public string Name
    {
        get
        {
            string s = (string)ViewState["name"];
            return (s != null) ? s : string.Empty;
        }
        set
        {
            ViewState["name"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn1212_Click(object sender, EventArgs e)
    {
        lt1.Text = Name;
    }
}