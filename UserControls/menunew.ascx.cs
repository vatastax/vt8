using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using System.Data;

public partial class menunew : System.Web.UI.UserControl
{
    static int vtypeVal = 40;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Project"] == null)
            Response.Redirect("../Default.aspx");
        if (Session["IsMaster"] == null)
            Session["IsMaster"] = "0";
        
        //if ((Session["ay"] != null || Session["Project"].ToString() == "TDS" || Session["Project"].ToString() == "stax") && Session["IsMaster"].ToString() != "1" && !Request.Url.ToString().Contains("Profile"))
        bool IsVTypeFactor = false;
        if (Session["VType"] != null)
        {
            if (Session["VType"].ToString() == "106")
                IsVTypeFactor = true;
        }
        if ((Session["ay"] != null || Session["Project"].ToString() == "TDS" || Session["Project"].ToString() == "stax") && !IsVTypeFactor && !Request.Url.ToString().Contains("Profile"))
        {
            bllMain objbllMain = new bllMain();
            DataTable dt = new DataTable();
            if (Session["ITR"] == null)
                Session["ITR"] = "1";
            if (Session["Project"].ToString() != "stax")
                dt = objbllMain.getMenu(Session["ay"].ToString(), Session["ITR"].ToString(), Session["AssesseeType"].ToString(), Session["Project"].ToString(), Convert.ToInt64(Session["User_ID"]));     //  {0} = AY, {1} = ITR, {2} = Assessee
            else
                dt = objbllMain.getMenuGlobal(Session["Project"].ToString(), Session["ay"].ToString());     //  {0} = AY, {1} = ITR, {2} = Assessee

            string strMenu = @"<ul>";

            DataRow[] rows = dt.Select("Parent_Menu=0");
            DataTable dtMain = new DataTable();
            dtMain = dt.Clone();

            DataTable dtRest = new DataTable();
            dtRest = dt.Clone();

            foreach (DataRow row1 in rows)
            {
                DataRow row = dtMain.NewRow();
                row.ItemArray = row1.ItemArray;
                dtMain.Rows.Add(row);
            }

            rows = dt.Select("Parent_Menu<>0");
            foreach (DataRow row1 in rows)
            {
                DataRow row = dtRest.NewRow();
                row.ItemArray = row1.ItemArray;
                dtRest.Rows.Add(row);
            }

            int cnt = 0;
            string strVtypes = "";

            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                string[] arrURL = System.Text.RegularExpressions.Regex.Split(Request.Url.ToString(), "/");
                string strURL = arrURL[arrURL.Length - 1];
                string[] arrVType = System.Text.RegularExpressions.Regex.Split(dt.Rows[i]["Menu_Link"].ToString(), "vtype=");
                string vtype = (arrVType.Length > 1) ? arrVType[1] : arrVType[0];
                //string ss = (Session["vtype"] != null) ? Session["vtype"].ToString() : "";
                int MenuID = objbllMain.MenuID("vatastax", "2014-2015", strURL);
                if (MenuID == Convert.ToInt32(dtMain.Rows[i]["Menu_ID"]))
                {
                    //if (!Request.Url.ToString().Contains("Salary.aspx") || !dt.Rows[i]["Menu_Link"].ToString().Contains("Salary.aspx"))
                    if (!Request.Url.ToString().Contains("IncomeTax") || !dt.Rows[i]["Menu_Link"].ToString().Contains("Salary.aspx"))
                    {
                        strMenu += @"<li><a formnovalidate  style='color:#ef5845' href='" + dt.Rows[i]["Menu_Link"].ToString().Replace("Salary","manageLinking") + @"'><span>" + dt.Rows[i]["Menu_Name"].ToString() + @"</span></a>";
                    }
                    else
                    {
                        strVtypes += vtype.ToString() + "~";
                        strMenu += @"<li><a formnovalidate  style='color:#ef5845' onclick='movePage(" + vtype + ");'><span>" + dt.Rows[i]["Menu_Name"].ToString() + @"</span></a>";
                    }

                }
                else
                {
                    //if (!Request.Url.ToString().Contains("Salary.aspx") || !dt.Rows[i]["Menu_Link"].ToString().Contains("Salary.aspx"))
                    if (!Request.Url.ToString().Contains("IncomeTax") || !dt.Rows[i]["Menu_Link"].ToString().Contains("Salary.aspx"))
                    {
                        strMenu += @"<li class='has-sub'><a formnovalidate  href='" + dt.Rows[i]["Menu_Link"].ToString().Replace("Salary", "manageLinking") + @"'><span>" + dt.Rows[i]["Menu_Name"].ToString() + @"</span></a>";
                    }
                    else
                    {
                        strVtypes += vtype.ToString() + "~";
                        //string ssvt = Session["VType"].ToString();
                        //if (vtype == Session["VType"].ToString())
                        //    strMenu += @"<li class='has-sub active' ><a formnovalidate  onclick='movePage(" + vtype + ");' ><span>" + dt.Rows[i]["Menu_Name"].ToString() + @"</span></a>";
                        //else
                            strMenu += @"<li class='has-sub' ><a formnovalidate  onclick='movePage(" + vtype + ");' ><span>" + dt.Rows[i]["Menu_Name"].ToString() + @"</span></a>";
                    }
                }


                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["Parent_Menu"].ToString() == dtMain.Rows[i]["Menu_id"].ToString())
                    {
                        arrVType = System.Text.RegularExpressions.Regex.Split(dt.Rows[j]["Menu_Link"].ToString(), "vtype=");
                        vtype = (arrVType.Length > 1) ? arrVType[1] : arrVType[0];
                        if (cnt == 0)
                        {
                            if (!Request.Url.ToString().Contains("Salary.aspx") || !dt.Rows[j]["Menu_Link"].ToString().Contains("Salary.aspx"))
                            {
                                int R = Convert.ToInt32(dt.Rows[j]["Menu_id"]);
                                DataRow[] rowsub = dt.Select("Parent_Menu=" + Convert.ToInt32(dt.Rows[j]["Menu_id"]));
                                DataTable dtSub = new DataTable();
                                dtSub = dt.Clone();
                                foreach (DataRow row1 in rowsub)
                                {
                                    DataRow row = dtSub.NewRow();
                                    row.ItemArray = row1.ItemArray;
                                    dtSub.Rows.Add(row);
                                }
                                if (dtSub.Rows.Count > 0)
                                {
                                    strMenu += @"<ul ><li><a formnovalidate   href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'><span>" + dt.Rows[j]["Menu_Name"].ToString() + @"</span></a>";
                                    string Submenu = "";
                                    for (int k = 0; k < dtSub.Rows.Count; k++)
                                    {
                                        Submenu += @"<ul ><li><a formnovalidate   href='" + dtSub.Rows[k]["Menu_Link"].ToString() + @"'><span>" + dtSub.Rows[k]["Menu_Name"].ToString() + @"</span></a></li>";
                                    }
                                    strMenu += Submenu + @"</li>";
                                }
                                else
                                {
                                    strMenu += @"<ul ><li><a formnovalidate   href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'><span>" + dt.Rows[j]["Menu_Name"].ToString() + @"</span></a></li>";
                                }
                            }
                            else
                            {
                                strVtypes += vtype.ToString() + "~";
                                strMenu += @"<ul ><li><a formnovalidate  onclick='movePage(" + vtype + ");'><span>" + dt.Rows[j]["Menu_Name"].ToString() + @"</span></a></li>";
                            }
                            cnt += 1;
                        }
                        else
                        {
                            int R = Convert.ToInt32(dt.Rows[j]["Menu_id"]);
                            DataRow[] rowsub = dt.Select("Parent_Menu=" + Convert.ToInt32(dt.Rows[j]["Menu_id"]));
                            DataTable dtSub = new DataTable();
                            dtSub = dt.Clone();
                            foreach (DataRow row1 in rowsub)
                            {
                                DataRow row = dtSub.NewRow();
                                row.ItemArray = row1.ItemArray;
                                dtSub.Rows.Add(row);
                            }
                            string Submenu = "";

                            if (!Request.Url.ToString().Contains("Salary.aspx") || !dt.Rows[j]["Menu_Link"].ToString().Contains("Salary.aspx"))
                            {

                                if (dtSub.Rows.Count > 0)
                                {
                                    strMenu += @"<li><a formnovalidate  href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'><span>" + dt.Rows[j]["Menu_Name"].ToString() + @"</span></a><ul id='ss'>";
                                    for (int k = 0; k < dtSub.Rows.Count; k++)
                                    {
                                        Submenu += @"<li><a formnovalidate  href='" + dtSub.Rows[k]["Menu_Link"].ToString() + @"'><span>" + dtSub.Rows[k]["Menu_Name"].ToString() + @"</span></a></li>";
                                    }
                                    strMenu += Submenu + @"</li></ul>";
                                }
                                else
                                {
                                    strMenu += @"<li><a formnovalidate  href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'><span>" + dt.Rows[j]["Menu_Name"].ToString() + @"</span></a></li>";
                                }
                            }
                            else
                            {
                                strVtypes += vtype.ToString() + "~";
                                strMenu += @"<li><a formnovalidate onclick='movePage(" + vtype + ");'><span>" + dt.Rows[j]["Menu_Name"].ToString() + @"</span></a></li>";
                            }
                        }
                    }
                }
                if (cnt > 0)
                {
                    cnt = 0;
                    strMenu += "</ul>";
                }
                strMenu += "</li>";

            }
            if (strVtypes.Length > 1)
            {
                Session["vtypes"] = strVtypes.Remove(strVtypes.Length - 1);
            }
            ltMenu.Text = strMenu;
        }

    }
}