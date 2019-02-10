using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;

namespace Taxation.DataAccess
{
    public class popup:dalConnection
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con_Poolable"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;

        public popup()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable Select(string VType, ArrayList info, out string addLnk, out string updLnk)
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                this.pConnMain();
                string strSQL = "";// "select * from popup_screen where VType=@VType";
                if (VType == "")
                    VType = "0";
                strSQL = @"select * from popup_screen where id = (select popupID from dbMain.dbo.screensettings where VType=@VType)";
                cmd = new SqlCommand(strSQL, this.SqlCon);
                cmd.Parameters.AddWithValue("@VType", VType);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                addLnk = "";
                updLnk = "";
                if (dt.Rows.Count > 0)
                {
                    addLnk = dt.Rows[0]["AddBtnURL"].ToString();
                    updLnk = dt.Rows[0]["ManageBtnURL"].ToString();
                    strSQL = dt.Rows[0]["SQLQry"].ToString();
                    string[] arr = System.Text.RegularExpressions.Regex.Split(strSQL, "#");

                    if (arr.Length > 2 && info.Count > 1)
                        strSQL = arr[0] + info[0].ToString() + arr[1] + info[1].ToString();
                    else if (arr.Length > 1)
                        strSQL = arr[0] + info[0].ToString() + arr[1];

                    // +arr[1] + VType;

                    adp = new SqlDataAdapter(strSQL, con);

                    adp.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        DataColumn col1 = new DataColumn("screenTitle", Type.GetType("System.String"));
                        DataColumn col2 = new DataColumn("IsAddButton", Type.GetType("System.String"));
                        DataColumn col3 = new DataColumn("IsManageButton", Type.GetType("System.String"));
                        DataColumn col4 = new DataColumn("AddBtnURL", Type.GetType("System.String"));
                        DataColumn col5 = new DataColumn("ManageBtnURL", Type.GetType("System.String"));
                        dt2.Columns.Add(col1);
                        dt2.Columns.Add(col2);
                        dt2.Columns.Add(col3);
                        dt2.Columns.Add(col4);
                        dt2.Columns.Add(col5);


                        dt2.Rows[0][3] = dt.Rows[0][3];
                        dt2.Rows[0][4] = dt.Rows[0][4];
                        dt2.Rows[0][5] = dt.Rows[0][5];
                        dt2.Rows[0][6] = dt.Rows[0][6];
                        dt2.Rows[0][7] = dt.Rows[0][7];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt2;

        }
    }
}