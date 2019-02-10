using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataAccess;
using System.Collections.Generic;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
using controlgrid;
using System.Globalization;

public partial class UserControls_PopupControl : System.Web.UI.UserControl
{
    string strTitle = "";
    static DataTable dtMain = new DataTable();
    string addLnk = "";
    string updLnk = "";
    static Int32 type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = 0;
        DataTable dt = new DataTable();
        bllScreen objbllScreen = new bllScreen();
        System.Collections.ArrayList arrInfo = new System.Collections.ArrayList();
        arrInfo.Add(Convert.ToString(Session["NameID"]));
        //string vv = Session["VType"].ToString();
        //string sss = Session["VType"].ToString();
        Label ll = (Label)this.Parent.FindControl("lblHeading");

        if (Session["VType"] == null)
        {
            Session["VType"] = objbllScreen.getVTypeByScreenTitle(ll.Text);
        }

        //Page pp = new Page();
        //pp = (Page)Parent;
        string strCtl = "";
        //foreach (Control ctl in pp.Controls)
        //{
        //    strCtl += ctl.ID + " ~ ";
        //}
        //if (ll.Text == "Income From Salary")
        //    Session["VType"] = "40";
        //else if (ll.Text == "Service Tax Return")
        //    Session["VType"] = "5001";
        //else
        //    Session["VType"] = "42";

        
        if (Session["VType"] != null)
        {
            if (Session["popupID"] != null)
            {
                if (Convert.ToInt32(Session["popupID"]) > 0)
                {
                    //type = 13011;
                    //arrInfo.Add(type);
                    arrInfo.Add(Session["NameID"].ToString());
                    gvEmp.EmptyDataText = "<b> Default Employer </b>";
                }
            }

            //if (Session["VType"].ToString() == "40")
            //{
            //    type = 13011;
            //    //arrInfo.Add(type);
            //    arrInfo.Add(Session["NameID"].ToString());
            //    gvEmp.EmptyDataText = "<b> Default Employer </b>";
            //}
            //else if (Session["VType"].ToString() == "41")
            //{
            //    type = 32;
            //    arrInfo.Add(type);

            //    bllAssetMast objbllAssetMast = new bllAssetMast();
            //    dt = objbllAssetMast.SelectCompleteAssetDetail(Session["NameID"].ToString(), strTitle);
            //    if (dt.Rows.Count > 0)
            //    {
            //        if (Session["AssetID"] == null)
            //        {
            //            Session["AssetID"] = dt.Rows[0]["AssetID"].ToString();
            //            Session["Asset"] = dt.Rows[0]["CompanyName"].ToString();
            //        }
            //    }
            //}
            //else if (Session["VType"].ToString() == "42")
            //{
            //    type = 13012;
            //    //arrInfo.Add(type);
            //    arrInfo.Add(Session["NameID"].ToString());
            //}
            //else if (Session["VType"].ToString() == "5001")
            //{
            //    type = 14012;
            //    //arrInfo.Add(type);
            //    arrInfo.Add(Session["NameID"].ToString());
            //}
            //else if (Session["VType"].ToString() == "42")
            //{
            //    strTitle = "House Property";
            //    arrInfo.Add("13012");
            //    bllAssetMast objbllAssetMast = new bllAssetMast();
            //    dt = objbllAssetMast.SelectCompleteAssetDetail(Session["NameID"].ToString(), strTitle);
            //    if (dt.Rows.Count > 0)
            //    {
            //        if (Session["AssetID"] == null)
            //        {
            //            Session["AssetID"] = dt.Rows[0]["AssetID"].ToString();
            //            Session["Asset"] = dt.Rows[0]["CompanyName"].ToString();
            //        }
            //    }
            //}


            dalEmployerMaster objdalEmployerMaster = new dalEmployerMaster();
            denEmployerMaster objdenEmployerMaster = new denEmployerMaster();

            dtMain.Rows.Clear();
            dtMain.Clear();
            popup objpopup = new popup();
            bool IsMasterOnly = false;

            dtMain = objpopup.Select(Session["VType"].ToString(), arrInfo, out addLnk, out updLnk);

            if (Session["restore"] != null)
            {
                Session["E_Name"] = Session["NameID"];
                Context.Items["MainID"] = Session["NameID"].ToString();
            }
            else
            {
                if (dtMain.Rows.Count > 0)
                {
                    if (Session["E_NameID"] == null && Session["E_Name"] == null || Request.UrlReferrer == null && !IsPostBack)
                    {
                        Session["E_NameID"] = dtMain.Rows[0]["id"].ToString();
                        Session["E_Name"] = dtMain.Rows[0]["title"].ToString();
                    }
                    else if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                    {
                        Session["E_NameID"] = dtMain.Rows[0]["id"].ToString();
                        Session["E_Name"] = dtMain.Rows[0]["title"].ToString();
                    }

                    gvEmp.DataSource = dtMain;
                    gvEmp.DataBind();
                    if (Session["VType"].ToString() == "41")
                    {
                        gvEmp.Columns[2].Visible = false;
                        gvEmp.Columns[1].HeaderText = "Business";
                    }
                    else
                    {
                        gvEmp.Columns[2].Visible = true;
                        gvEmp.Columns[1].HeaderText = "Employer";
                        gvEmp.ShowHeader = true;
                    }
                    ltTitle.Text = dtMain.Rows[0]["screenTitle"].ToString();
                    aLnk.Visible = Convert.ToBoolean(dtMain.Rows[0]["IsAddButton"]);
                    addLnk = dtMain.Rows[0]["AddBtnURL"].ToString();
                    updLnk = dtMain.Rows[0]["ManageBtnURL"].ToString();
                    aLnk.PostBackUrl = dtMain.Rows[0]["AddBtnURL"].ToString();
                    aLnka.HRef = dtMain.Rows[0]["AddBtnURL"].ToString();
                    aLnkUpdate.Visible = Convert.ToBoolean(dtMain.Rows[0]["IsManageButton"]);
                    //aLnkUpdate.PostBackUrl = dtMain.Rows[0]["AddBtnURL"].ToString() + "?id=" + Session["E_NameID"].ToString();


                }
                else
                {
                    gvEmp.DataSource = dtMain;  //to bind empty grid
                    gvEmp.DataBind();
                    //if (Session["VType"].ToString() == "40" || Session["VType"].ToString() == "41" || Session["VType"].ToString() == "42" || Session["VType"].ToString() == "5001")
                    //{
                    //    //lblHeading_Title.Text = "Default";
                    //    //if (Session["ITR"].ToString() != "1" && Session["ITR"].ToString() != "8")
                    //    //    lbtnChange.Visible = true;
                    //    //lbtnChange.Text = "(Add)";
                    ////if (Session["VType"].ToString() == "40")
                    ////    aLnk.PostBackUrl = "../Presentation/Employermaster.aspx";
                    ////else if (Session["VType"].ToString() == "41")
                    ////    aLnk.PostBackUrl = "../Presentation/BusinessMaster.aspx";
                    ////else if (Session["VType"].ToString() == "42")
                    ////{
                    ////    aLnk.PostBackUrl = "../Presentation/AssetMaster.aspx?sc=hp";
                    ////    aLnka.HRef = "../Presentation/Salary.aspx?VType=13012";
                    ////}
                    //}
                }

                //if ((Session["VType"].ToString() == "40" || Session["VType"].ToString() == "41" || Session["VType"].ToString() == "5001") && Session["E_NameID"] != null)
                if (Session["popupID"] != null)
                {
                    if (Convert.ToInt32(Session["popupID"]) > 0)
                    {
                        if (Session["E_NameID"] != null)
                            Context.Items["MainID"] = Session["E_NameID"].ToString();   //Session["NameID"].ToString(); //1234567890;
                        else
                            Context.Items["MainID"] = Session["NameID"].ToString();   //Session["NameID"].ToString(); //1234567890;
                    }
                }
                //else if ((Session["VType"].ToString() == "42" || Session["VType"].ToString() == "43") && Session["AssetID"] != null)
                //{
                //    Context.Items["MainID"] = Session["AssetID"].ToString();
                //}
                else
                    Context.Items["MainID"] = Session["NameID"].ToString();// "100";
            }
        }
    }

    protected void gvEmp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == -1)
        {
            if (gvEmp.Rows.Count > 0)
                e.Row.Cells[1].Text = ltTitle.Text;

        }
        if (e.Row.RowIndex != -1)
        {
            Label lblSNO = new Label();
            Label lblID = new Label();
            LinkButton lbtnTitle = new LinkButton();

            lblSNO = (Label)e.Row.FindControl("lblSNO");
            lbtnTitle = (LinkButton)e.Row.FindControl("lbtnTitle");

            lblSNO.Text = (e.Row.RowIndex + 1).ToString();
            lbtnTitle.Text = dtMain.Rows[e.Row.RowIndex]["title"].ToString();
            lblID = (Label)e.Row.FindControl("lblID");

            if (Session["E_NameID"] != null)
            {
                if (lblID.Text == Session["E_NameID"].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }

    }

    protected void gvEmp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (Session["VType"].ToString() == "42")
        //    Session["AssetID"] = e.CommandArgument.ToString();
        //else
        //{
            Session["E_NameID"] = e.CommandArgument.ToString();
            Session["AssetID"] = e.CommandArgument.ToString();
        //}
        LinkButton lbtn = new LinkButton();
        lbtn = (LinkButton)e.CommandSource;
        if (Session["restore"] == null)
            Session["E_Name"] = lbtn.Text;
        else
            Session["E_Name"] = Session["NameID"];
        if (Session["VType"] != null)
            Session["VType_Popup"] = Session["VType"].ToString();
        Response.Redirect(Request.Url.ToString());
    }

    protected void aLnkUpdate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row1 in gvEmp.Rows)
        {
            if (row1.BackColor == System.Drawing.Color.LightBlue)
            {
                Label lblID = new Label();
                lblID = (Label)row1.FindControl("lblID");
                Session["E_NameID"] = (row1.RowIndex + 2).ToString();
            }
        }
        //string[] arr = System.Text.RegularExpressions.Regex.Split(Request.Url.ToString(), "?");
        Response.Redirect(updLnk);
        //if (Session["VType"].ToString() == "40")
        //    Response.Redirect("~/Presentation/Salary.aspx?VType=13011");
        //else
        //    Response.Redirect("~/Presentation/Salary.aspx?VType=13012");
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        if (gvEmp.Rows.Count > 0)
        {
            //Session["E_NameID"] = Session["NameID"].ToString();
            Response.Redirect(addLnk);
        }
        else
        {
            Response.Redirect(addLnk);
            //Response.Redirect("~/Presentation/Salary.aspx?VType=" + type.ToString());
        }
    }
}