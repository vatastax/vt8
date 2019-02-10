using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataEntity;
using System.Data;

public partial class Presentation_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            denLogin objLogin2 = new denLogin();
            bllLogin objLoginBLL = new bllLogin();
            objLogin2 = objLoginBLL.Select(Session["UserName"].ToString());
            Session["user_name"] = objLogin2.PersonName;

            string str_Redirect = "Main.aspx";
            Session["userEmail"] = Session["UserName"].ToString();
            if (objLogin2.Account_Type == "S")
            {
                DataTable dtAssessee = new DataTable();
                dtAssessee = objLoginBLL.getAssesseeCount(Session["UserName"].ToString());
                if (dtAssessee.Rows.Count > 0)
                {
                    Session["Exists"] = 1;
                    Session["Bool"] = "False";
                    Session["Mode"] = "New";
                    Session["PAN"] = Convert.ToString(dtAssessee.Rows[0]["PanNo"].ToString());
                    Session["Status"] = dtAssessee.Rows[0]["Status"].ToString();
                    Session["NameID"] = dtAssessee.Rows[0]["NameID"].ToString();
                    Session["E_NameID"] = null;
                    Session["restore"] = null;
                    Session["AssesseeType"] = "Individual";
                    Session["AType"] = "";
                    Session["DateofBirth"] = dtAssessee.Rows[0]["DateofBirth"].ToString();
                    Session["ITR"] = "1";
                    Session["ay"] = "2014-2015";
                    Session["duedate"] = "31-07-2014";

                    str_Redirect = "DisplayForm.aspx";
                }
                else
                {
                    Session["Mode"] = "New";
                    str_Redirect = "individual.aspx";
                }
                Response.Redirect(str_Redirect);
            }

            //    if (Session["AssesseeUser"] != null)
            //    {
            //        bllLogin objLoginBLL = new bllLogin();
            //        DataTable dtAssessee = new DataTable();
            //        dtAssessee = objLoginBLL.getAssesseeCount(Session["userEmail"].ToString());
            //        if (dtAssessee.Rows.Count > 0)
            //        {
            //            Session["Exists"] = 1;
            //            Session["Bool"] = "False";
            //            Session["Mode"] = "New";
            //            Session["PAN"] = Convert.ToString(dtAssessee.Rows[0]["PanNo"].ToString());
            //            Session["Status"] = dtAssessee.Rows[0]["Status"].ToString();
            //            Session["NameID"] = dtAssessee.Rows[0]["NameID"].ToString();
            //            Session["E_NameID"] = null;
            //            Session["restore"] = null;
            //            Session["AssesseeType"] = "Individual";
            //            Session["AType"] = "";
            //            Session["DateofBirth"] = dtAssessee.Rows[0]["DateofBirth"].ToString();

            //            Session["ITR"] = "1";
            //            Session["ay"] = "2014-2015";
            //            Session["duedate"] = "31-07-2014";
            //        }
            //        else
            //            Response.Redirect("individual.aspx");
            //    }
                else
                    Response.Redirect("Main.aspx");
        }
        else
            Response.Redirect("login.aspx");
    }

    

}