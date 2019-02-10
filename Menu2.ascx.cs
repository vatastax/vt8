﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] != null)
            lblUser.Text = Session["user_name"].ToString();// Session["UserName"].ToString();
        else
            Response.Redirect("login.aspx");
    }
}