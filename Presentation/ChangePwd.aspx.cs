using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataAccess;
using System.Collections.Generic;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
using System.Data;

public partial class Presentation_ChangePwd : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            Session["Url"] = Request.UrlReferrer;
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        bllUserMgmt objUserMgmt = new bllUserMgmt();
        DataTable dt_Pwd = new DataTable();
        DataTable dtpwd = new DataTable();
        dtpwd = objUserMgmt.CheckUserPwd(Session["Email_id"].ToString(), txtOldPwd.Text);
        if(dtpwd.Rows.Count>0)
        {
      dt_Pwd= objUserMgmt.ChangeUserPwd(Session["Email_Id"].ToString(), txtOldPwd.Text, txtComPwd.Text).Copy(); ;
       
     txtOldPwd.Text = "";
     txtNewPwd.Text = "";
     txtComPwd.Text = "";
  
     //string message = "Your Password have been changed";
     //System.Text.StringBuilder sb = new System.Text.StringBuilder();
     //sb.Append("<script type = 'text/javascript'>");
     //sb.Append("window.onload=function(){");
     //sb.Append("alert('");
     //sb.Append(message);
     //sb.Append("')};");
     //sb.Append("</script>");
     //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
     //Response.Redirect(Session["Url"].ToString());
     lblMsg.Text = "Your Password has been changed successfully.";
     lblMsg.Visible = true;
 }
 else
 {
     //string message = "Enter correct data";
     //System.Text.StringBuilder sb = new System.Text.StringBuilder();
     //sb.Append("<script type = 'text/javascript'>");
     //sb.Append("window.onload=function(){");
     //sb.Append("alert('");
     //sb.Append(message);
     //sb.Append("')};");
     //sb.Append("</script>");
     //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
               //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Data you entered is not correct');", true);
     lblMsg.Text = "Enter correct data";
     lblMsg.Visible = true;
 }
    }


    
}