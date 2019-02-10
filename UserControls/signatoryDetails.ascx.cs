using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using Taxation.BusinessLogic;
using System.Globalization;
using System.Data;


public partial class UserControls_signatoryDetails : System.Web.UI.UserControl
{
    bllAssessee objAssesseeBLL;
    static string[] Formats = null;
    static DataTable table = new DataTable();
    static DataTable dtBank;
    static int ID;
    static int grdIndx = 0;
    static string Searchbank = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sd"] == null)
        {
            txtDateofReturn.Text = DateTime.Now.ToShortDateString();
            DataTable dt = new DataTable();
            if (Session["NameID"] != null)
            {
                objAssesseeBLL = new bllAssessee();
                dt = objAssesseeBLL.Select(Convert.ToInt64(Session["NameID"]));
                if (dt.Rows.Count > 0)
                {
                    txtSignatory.Text = dt.Rows[0]["name"].ToString();
                    txtPANSignatory.Text = dt.Rows[0]["PanNo"].ToString();
                    txtFatherSignatory.Text = dt.Rows[0]["fathersName"].ToString();
                    txtPlace.Text = "Jalandhar";
                }
            }
        }
        //else
        //{
        //    submitData();
        //}
        if (Request.QueryString["sd"] != null)
            submitData();
        //if (hdnSD_Data.Value != "")
        //{
        //    submitData();
        //    hdnSD_Data.Value = "";
        //}
    }

    protected void btnSubmitSignatory_Click(object sender, EventArgs e)
    {
        submitData();
    }
    
    private void submitData()
    {
        bllDocTrans objDocTransBLL = new bllDocTrans();
        denDocTrans objDocTransDEN = new denDocTrans();
        txtDateofReturn.Text = DateTime.Now.ToShortDateString();
        DataTable dt = new DataTable();
        if (Session["NameID"] != null)
        {
            objAssesseeBLL = new bllAssessee();
            dt = objAssesseeBLL.Select(Convert.ToInt64(Session["NameID"]));
            if (dt.Rows.Count > 0)
            {
                txtSignatory.Text = dt.Rows[0]["name"].ToString();
                txtPANSignatory.Text = dt.Rows[0]["PanNo"].ToString();
                txtFatherSignatory.Text = dt.Rows[0]["fathersName"].ToString();
                txtPlace.Text = "Jalandhar";
            }
        }

        if (ddRepSelf.SelectedValue == "1")
        {
            objDocTransBLL.GetBankDetails(Session["PAN"].ToString());
            objDocTransDEN.NameID = Convert.ToString(Session["PAN"]);
            objDocTransDEN.Auth_Father_Name = txtFatherSignatory.Text;
            objDocTransDEN.FilingDate = txtDateofReturn.Text;
            objDocTransDEN.Auth_Name = txtSignatory.Text;
            objDocTransDEN.PAN = txtPANSignatory.Text;
            objDocTransDEN.Place = txtPlace.Text;
            objDocTransDEN.Auth_Desig = "";
            objDocTransDEN.Auth_Place = txtPlace.Text;
            objDocTransDEN.WardCircle = "";

            objDocTransBLL.UpdateAuthorisedSignatory(objDocTransDEN);
        }
        else
        {
            objDocTransDEN = objDocTransBLL.GetRepresentativeDetails(Session["PAN"].ToString());

            objDocTransDEN.NameID = Convert.ToString(Session["PAN"]);
            objDocTransDEN.Auth_Father_Name = txtFatherSignatory.Text;
            objDocTransDEN.FilingDate = txtDateofReturn.Text;
            objDocTransDEN.Name = txtSignatory.Text;
            objDocTransDEN.PAN = txtPANSignatory.Text;
            objDocTransDEN.Place = txtPlace.Text;
            objDocTransDEN.Auth_Place = txtPlace.Text;

            //objDocTransDEN.Auth_Desig = "";
            //objDocTransDEN.Designation = "";
            //objDocTransDEN.Flat = "";
            //objDocTransDEN.Premises = "";
            //objDocTransDEN.Road = "";
            //objDocTransDEN.Area = "";
            //objDocTransDEN.City = "";
            //objDocTransDEN.State = 26;
            //objDocTransDEN.PIN = "";

            objDocTransBLL.UpdateRepresentativeDetails(objDocTransDEN);
        }
        Response.Redirect("XMLRestore.aspx");
    }
}