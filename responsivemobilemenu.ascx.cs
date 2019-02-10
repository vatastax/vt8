using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using System.Data;

public partial class responsivemobilemenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ay"] != null)
        {
            bllMain objbllMain = new bllMain();
            DataTable dt = new DataTable();
            if (Session["ITR"] == null)
                Session["ITR"] = "1";

            dt = objbllMain.getMenu(Session["ay"].ToString(), Session["ITR"].ToString(), "0", Session["project"].ToString(), Convert.ToInt64(Session["User_ID"]));     //  {0} = AY, {1} = ITR, {2} = Assessee
//            ltMenu.Text = @"<ul data-breakpoint='800' class='flexnav'>
//            <li><a href=''>Item 1111</a>
//              <ul>
//                <li><a href='/'>Sub 1 Item 1</a></li>
//                <li><a href='/'>Sub 1 Item 2</a></li>
//                <li><a href='/'>Sub 1 Item 3</a></li>
//                <li><a href='/'>Sub 1 Item 4</a></li>
//              </ul>
//            </li>           
//          </ul>";

            string strMenu = @"<ul data-breakpoint='800' class='flexnav'>";

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
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                strMenu += @"<li><a href='" + dt.Rows[i]["Menu_Link"].ToString() + @"'>" + dt.Rows[i]["Menu_Name"].ToString() + @"</a>";

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["Parent_Menu"].ToString() == dtMain.Rows[i]["Menu_id"].ToString())
                    {
                        if (cnt == 0)
                        {
                            strMenu += @"<ul><li><a href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'>" + dt.Rows[j]["Menu_Name"].ToString() + @"</a></li>";
                            cnt += 1;
                        }
                        else
                        {
                            strMenu += @"<li><a href='" + dt.Rows[j]["Menu_Link"].ToString() + @"'>" + dt.Rows[j]["Menu_Name"].ToString() + @"</a></li>";
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
            strMenu += "</ul>";
            ltMenu.Text = strMenu;


           
        }
    }
}