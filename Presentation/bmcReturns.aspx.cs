using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.BusinessLogic;
using System.Web.Services;
using BALVatasETDS.UserGroupManagement;
using System.Data;


using Ionic.Zip;
using System.Collections.Generic;

public partial class Presentation_bmcReturns : System.Web.UI.Page
{
    public int IsLogout = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Auto Redirect on Session Out
        int reason = 0;
        Session["Main"] = "set";
        if (!common.IsLoggedIn(out reason))
        {
            if (reason == 1)
            {
                Session["reason_logout"] = "suspecious_attempt";
            }
            Response.Redirect("Logout.aspx");
        }
        IsLogout = 0;
        //for managing window close from top:
        if (Request.UrlReferrer != null)
        {
            if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                Session["DisplayForm"] = null;
            else
                Session["DisplayForm"] = "set";
        }
        else
            Session["DisplayForm"] = "set";


        ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";

        if (!IsPostBack)
        {
            bindGrid();
        }
    }

    private void bindGrid()
    {
        blltbl_ProcessesHistoryofjob obj = new blltbl_ProcessesHistoryofjob();
        DataTable dt = new DataTable();
        dt = obj.Select(false);
        gvReturns.DataSource = dt;
        gvReturns.DataBind();
    }

    protected void btnAllocate_Click(object sender, EventArgs e)
    {

        using (ZipFile zip = new ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            zip.AddDirectoryByName("Files");
            foreach (GridViewRow row in gvReturns.Rows)
            {

                if ((row.FindControl("chkAss") as CheckBox).Checked)
                {
                    string filePath = Server.MapPath("../xml/") + (row.FindControl("lblAY") as Label).Text + "/" + (row.FindControl("lblNameID") as Label).Text + "_1.xml";
                    zip.AddFile(filePath, "Files");
                }
            }
            Response.Clear();
            Response.BufferOutput = false;
            string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
            zip.Save(Response.OutputStream);
            Response.End();
        }

        //string IDs = "";
        //string NameIDs = "";
        //bllAssesseeMaster objbllAssesseeMaster = new bllAssesseeMaster();
        //bllAssessee objbllAssessee = new bllAssessee();
        //foreach (GridViewRow row1 in gvReturns.Rows)
        //{
        //    CheckBox chk = new CheckBox();
        //    chk = (CheckBox)row1.FindControl("chkAss");
        //    if (chk.Checked)
        //    {
        //        string filePath = (row.FindControl("lblFilePath") as Label).Text;
        //        zip.AddFile(filePath, "Files");
        //    }
        //}

        //Response.Clear();
        //Response.BufferOutput = false;
        //string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
        //Response.ContentType = "application/zip";
        //Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
        //zip.Save(Response.OutputStream);
        //Response.End();
    }

    protected void btnTesting_Click(object sender, EventArgs e)
    {

    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        //Session["DisplayForm_Close"] = "0";
        //IsLogout = 0;
        //Session["DisplayForm"] = "set";
    }
}