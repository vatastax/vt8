using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using System.Data;

public partial class Menu : System.Web.UI.UserControl
{
    static int vtypeVal = 40;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Project"] == null)
            Response.Redirect("../Default.aspx");
        if (Session["ay"] != null || Session["Project"].ToString() == "TDS" || Session["Project"].ToString() == "stax")
        {
            bllMain objbllMain = new bllMain();
            DataTable dt = new DataTable();
            if (Session["ITR"] == null)
                Session["ITR"] = "1";
            if (Session["Project"].ToString() != "stax")
                dt = objbllMain.getMenu(Session["ay"].ToString(), Session["ITR"].ToString(), "0", Session["Project"].ToString(), Convert.ToInt64(Session["User_ID"]));     //  {0} = AY, {1} = ITR, {2} = Assessee
            else
                dt = objbllMain.getMenuGlobal(Session["Project"].ToString(), Session["ay"].ToString());     //  {0} = AY, {1} = ITR, {2} = Assessee

            string strMenu = @"<ul class='cbdb-menu  '>";

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
                    if (!Request.Url.ToString().Contains("Salary.aspx") || !dt.Rows[i]["Menu_Link"].ToString().Contains("Salary.aspx"))
                    {
                        strMenu += @"<li class='mainmenu '><div style='height:50px'><a formnovalidate class='blue' style='color:#ef5845' href='" + dt.Rows[i]["Menu_Link"].ToString() + @"'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
                    }
                    else
                    {
                        //if (Session["Project"].ToString() == "tds")
                        //    strMenu += @"<li class='mainmenu'><div style='height:50px'><a formnovalidate class='blue' style='color:#ef5845' href='" + dt.Rows[i]["Menu_Link"].ToString() + @"'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
                        //else
                        strVtypes += vtype.ToString() + "~";
                        strMenu += @"<li class='mainmenu '><div style='height:50px'><a formnovalidate class='blue' style='color:#ef5845' onclick='movePage(" + vtype + ");'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
                    }
                    //strMenu += @"<li class='mainmenu'><div style='height:50px'><a formnovalidate class='blue' style='color:#ef5845' href='" + dt.Rows[i]["Menu_Link"].ToString() + @"'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
                    //strMenu += @"<li class='mainmenu'><div style='height:50px'><a formnovalidate class='blue' style='color:#ef5845' onclick='movePage(" + vtype + ");'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
                }
                else
                {
                    if (!Request.Url.ToString().Contains("Salary.aspx") || !dt.Rows[i]["Menu_Link"].ToString().Contains("Salary.aspx"))
                    {
                        strMenu += @"<li class='mainmenu '><div style='height:50px'><a formnovalidate class='blue' href='" + dt.Rows[i]["Menu_Link"].ToString() + @"'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
                    }
                    else
                    {
                        //if (Session["Project"].ToString() == "tds")
                        //    strMenu += @"<li class='mainmenu'><div style='height:50px'><a formnovalidate class='blue' style='color:#ef5845' href='" + dt.Rows[i]["Menu_Link"].ToString() + @"'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
                        //else
                        strVtypes += vtype.ToString() + "~";
                        strMenu += @"<li class='mainmenu '><div style='height:50px'><a formnovalidate class='blue' onclick='movePage(" + vtype + ");' >" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
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
                strMenu += @"<ul class='submenu'><li><a formnovalidate class='blue '  href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'>" + dt.Rows[j]["Menu_Name"].ToString() + @"</a>";
                string Submenu = "";
                for (int k = 0; k < dtSub.Rows.Count; k++)
                {
                    Submenu += @"<ul class='submenu '><li><a formnovalidate class='blue '  href='" + dtSub.Rows[k]["Menu_Link"].ToString() + @"'>" + dtSub.Rows[k]["Menu_Name"].ToString() + @"</a></li>";
                }
                strMenu +=Submenu+ @"</li>"; 
            }
            else
            {
                strMenu += @"<ul class='submenu'><li><a formnovalidate class='blue '  href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'>" + dt.Rows[j]["Menu_Name"].ToString() + @"</a></li>";
            }
                            }
                            else
                            {
                                //if (Session["Project"].ToString() == "tds")
                                //    strMenu += @"<li class='mainmenu'><div style='height:50px'><a formnovalidate class='blue' style='color:#ef5845' href='" + dt.Rows[i]["Menu_Link"].ToString() + @"'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
                                //else
                                strVtypes += vtype.ToString() + "~";
                                strMenu += @"<ul class='submenu'><li><a formnovalidate class='blue ' onclick='movePage(" + vtype + ");'>" + dt.Rows[j]["Menu_Name"].ToString() + @"</a></li>";
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
                                    strMenu += @"<li><div style='height:50px'><a formnovalidate class='blue ' href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'>" + dt.Rows[j]["Menu_Name"].ToString() + @"</a></div><ul style='z-index:1;position:fixed;'>";
                                    for (int k = 0; k < dtSub.Rows.Count; k++)
                                    {
                                        Submenu += @"<li><a formnovalidate class='blue ' href='" + dtSub.Rows[k]["Menu_Link"].ToString() + @"'>" + dtSub.Rows[k]["Menu_Name"].ToString() + @"</a></li>";
                                    }
                                    strMenu += Submenu + @"</li></ul>";
                                }
                                else
                                {
                                    strMenu += @"<li><div style='height:50px'><a formnovalidate class='blue ' href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'>" + dt.Rows[j]["Menu_Name"].ToString() + @"</a></div></li>";
                                }
                            }
                            else
                            {
                                //if (Session["Project"].ToString() == "tds")
                                //    strMenu += @"<li class='mainmenu'><div style='height:50px'><a formnovalidate class='blue' style='color:#ef5845' href='" + dt.Rows[i]["Menu_Link"].ToString() + @"'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a></div>";
                                //else
                                strVtypes += vtype.ToString() + "~";
                                strMenu += @"<li><div style='height:50px'><a formnovalidate class='blue ' onclick='movePage(" + vtype + ");'>" + dt.Rows[j]["Menu_Name"].ToString() + @"</a></div></li>";
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
        //string ss = Session["UserName"].ToString();
        //commented by nishu 11/4/2014 for sperate header and menu
        //if (Session["user_name"] != null)
        //    lblUser.Text = Session["user_name"].ToString();  // Session["UserName"].ToString();
        //else
        //    Response.Redirect("login.aspx");
    }
}