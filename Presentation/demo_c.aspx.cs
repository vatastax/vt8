using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class demo_c : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.txtimgcode.Text == Session["CaptchaImageText"].ToString())
        {
            lblmsg.Text = "Excellent.......";
        }
        else
        {
            lblmsg.Text = "image code is not valid.";
        }
        this.txtimgcode.Text = "";
    }
}