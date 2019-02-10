using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_DeleteReturn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //OnConfirm();
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Confirm1", "Confirm1();", true);
            
        }
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        //Response.Redirect("DeleteReturn.aspx");
    }
    public void OnConfirm()
    {
        string str = hdnConfirm.Value;
    }
}