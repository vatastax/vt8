using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controlgrid;

public partial class PANLIST : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Reset Parameters
        DynamicControl.k = 2;
        DynamicControl.h = 1;
        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DynamicControl.Project_Name = "VS," + ApplicationHost + "," + Leftpath;
        //DynamicControl.Project_Name = "ProcessFlow," + ApplicationHost + "," + Leftpath;

        if (!Page.IsPostBack)
        {
            DynamicControl.Flag_Update = "";
            DynamicControl.Flag_Search = "";
            DynamicControl.Flag_Delete = "";
            DynamicControl.Flag_Filter = "";
            DynamicControl.Flag_Paging = "";
            //Flag_IsVisit = "F";
        }
        DynamicControl.count_Check = "F";
        DynamicControl.Parameters = "psubhee@yahoo.com";
        dny_Grd_PAN.grd_SelectedIndexChanged += new EventHandler(dny_Grd_PAN_grd_SelectedIndexChanged);
    }

    void dny_Grd_PAN_grd_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}