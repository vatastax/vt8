using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using Taxation.BusinessLogic;
using System.Data;

public partial class SubUserMenu_Asset : System.Web.UI.UserControl
{
    bllAssetMast objbllAssetMast = new bllAssetMast();
    string strTitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["vtype"].ToString() == "42")
                strTitle = "House Property";
            ltAssetType.Text = (strTitle == "") ? "Asset Master" : strTitle;
            lblTitle.Text = (strTitle == "") ? "Asset Master" : strTitle;

            DataTable dt = new DataTable();
            dt = objbllAssetMast.SelectCompleteAssetDetail(Session["NameID"].ToString(), strTitle);

            if (dt.Rows.Count > 0)
            {
                if (Request.UrlReferrer != null)
                {
                    if (Request.Url.ToString() != Request.UrlReferrer.ToString() || Session["AssetID"] == null)
                    {
                        Session["AssetID"] = dt.Rows[0]["AssetID"].ToString();
                        Session["Asset"] = dt.Rows[0]["CompanyName"].ToString();
                    }
                }
            }
            gvAsset.DataSource = dt;
            gvAsset.DataBind();

           
           
        }
    }

    protected void gvAsset_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Text = ltAssetType.Text;
        }
        else if (e.Row.RowIndex != -1)
        {
            Label lblSNO = new Label();
            Label lblAssetID = new Label();

            lblSNO = (Label)e.Row.FindControl("lblSNO");
            lblSNO.Text = (e.Row.RowIndex + 1).ToString();
            lblAssetID = (Label)e.Row.FindControl("lblAssetID");
            if (Session["AssetID"] != null)
            {
                if (lblAssetID.Text == Session["AssetID"].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }
    }

    protected void gvAsset_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Session["AssetID"] = e.CommandArgument.ToString();
        LinkButton ltbn = new LinkButton();
        ltbn = (LinkButton)e.CommandSource;
        Session["Asset"] = ltbn.Text;
        Response.Redirect(Request.Url.ToString());
    }

}