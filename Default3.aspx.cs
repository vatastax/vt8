﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["vid"] != null)
        {
            SubUserMenu ctrl = (SubUserMenu)LoadControl("~/SubUserMenu.ascx");
            pholder.Controls.Add(ctrl);
        }
    }
}