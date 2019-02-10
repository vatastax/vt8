using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using System.Data;
using Taxation.DataEntity;

public partial class Presentation_signatoryDetails : System.Web.UI.Page
{
    bllAssessee objAssesseeBLL;
    static string[] Formats = null;
    static DataTable table = new DataTable();
    static DataTable dtBank;
    static int ID;
    static int grdIndx = 0;
    static string Searchbank = "";
    static bool IsGen = true;
    bllDocTrans objDocTransBLL = new bllDocTrans();
    denDocTrans objDocTransDEN = new denDocTrans();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NameID"] == null)
            Response.Redirect("Main.aspx");

        //to check if its a simple assessee or HUF:
        if (Session["PAN"].ToString().Substring(3, 1) == "H")
        {
            ddRepSelf.SelectedValue = "2";
            txtSignatory.Enabled = true;
            txtPANSignatory.Enabled = true;
        }

        ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        if (!Page.IsPostBack)
        {
            IsGen = true;
            if (Request.QueryString["gen"] != null)
                IsGen = false;
            else
            {
                ltTitle.Text = "Verification";
                btnSubmitSignatory.Text = "Generate XML";
            }
            if (Session["Status"] != null)
            {
                if (Session["Status"].ToString() == "2")
                {
                    ddRepSelf.Items.Clear();
                    ddRepSelf.Items.Add(new ListItem("Karta", "1"));
                    ddRepSelf.Items.Add(new ListItem("Representative", "2"));

                }
            }
            getData();
        }
        
        //For Tax Status Popup:

        bllSalary objbllSalary = new bllSalary();
        objbllSalary.SetAllZero(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.calTaxNew(Session["NameID"].ToString(), Session["ay"].ToString(), 49, (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString()), Convert.ToInt32(((Session["Project"].ToString() != "vtax") ? 0 : 1)));

        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        hdnTaxStatus.Value = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "33");

        txtFatherSignatory.Text = objbllStoreTrans.SelectData_ConstID(Session["NameId"].ToString(), "8");
        txtPlace.Text = objbllStoreTrans.SelectData_ConstID(Session["NameId"].ToString(), "13");

        //if (Request.QueryString["sd"] != null)
        //    submitData();

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        bllAssessee objbllAssessee = new bllAssessee();
        objbllAssessee.AddAssesseeLog(Session["AssesseeID"].ToString());
    }

    protected void btnSubmitSignatory_Click(object sender, EventArgs e)
    {
        submitData();
        if (IsGen)
            Response.Redirect("XmlRestore.aspx");
        else
            Response.Redirect("XmlRestore.aspx?mod=sub");

       // string message = " ITR XML saved successfully.<br />To upload XML please click on below link";
     
        //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
    }
    private void getData()
    {
        if (Request.QueryString["sd"] == null)
        {
            //Fetching Signatory Data from VType 15015 Page
            bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            DataTable dtSignatory = new DataTable();
            dtSignatory = objbllStoreTrans.SelectData_Vtype(Session["NameID"].ToString(), "15015");
            if (dtSignatory.Rows.Count > 1)
            {
                for (int i = 0; i < dtSignatory.Rows.Count; i++)
                {
                    if (dtSignatory.Rows[i]["ConstantID"].ToString() == "58")
                        txtSignatory.Text = dtSignatory.Rows[i]["Col3"].ToString();
                    else if (dtSignatory.Rows[i]["ConstantID"].ToString() == "8")
                        //txtFatherSignatory.Text = dtSignatory.Rows[i]["Col3"].ToString();
                        txtFatherSignatory.Text = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "8");
                    else if (dtSignatory.Rows[i]["ConstantID"].ToString() == "59")
                        txtPANSignatory.Text = dtSignatory.Rows[i]["Col3"].ToString();
                    else if (dtSignatory.Rows[i]["ConstantID"].ToString() == "60")
                        txtPlace.Text = dtSignatory.Rows[i]["Col3"].ToString();
                    else if (dtSignatory.Rows[i]["ConstantID"].ToString() == "794")
                        txtDateofReturn.Text = dtSignatory.Rows[i]["Col3"].ToString();
                }
            }
            else
            {
                DateTime date = DateTime.Now;
                txtDateofReturn.Text = date.ToString("dd'/'MM'/'yyyy");
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
                        // txtPlace.Text = "Jalandhar";
                    }
                }
            }
            if (txtDateofReturn.Text == "")
            {
                string strDt = ((DateTime.Now.Day < 10) ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString());
                strDt += "/" + ((DateTime.Now.Month < 10) ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString());
                strDt += "/" + DateTime.Now.Year;
                txtDateofReturn.Text = strDt;
            }
        }
    }
    private void submitData()
    {

        if (ddRepSelf.SelectedValue == "1")
        {
            objDocTransBLL.GetBankDetails(txtPANSignatory.Text);
            objDocTransDEN.NameID = Convert.ToString(txtPANSignatory.Text);
            objDocTransDEN.Auth_Father_Name = txtFatherSignatory.Text;
            objDocTransDEN.FilingDate = txtDateofReturn.Text;
            objDocTransDEN.Name = txtSignatory.Text;
            objDocTransDEN.PAN = txtPANSignatory.Text;
            objDocTransDEN.Place = txtPlace.Text;
            objDocTransDEN.Auth_Desig = "";
            objDocTransDEN.Auth_Place = txtPlace.Text;
            objDocTransDEN.WardCircle = "";
            objDocTransDEN.Auth_Desig = "";
            objDocTransDEN.Auth_Place = txtPlace.Text;
            objDocTransDEN.WardCircle = "";
            objDocTransDEN.Flat = "";
            objDocTransDEN.Premises = "";
            objDocTransDEN.Road = "";
            objDocTransDEN.City = "";
            objDocTransDEN.State = 26;
            objDocTransDEN.Area = "";
            objDocTransDEN.Designation = "";
            objDocTransDEN.PIN = "";
            objDocTransBLL.UpdateRepresentativeDetails(objDocTransDEN);

            //objDocTransBLL.UpdateAuthorisedSignatory(objDocTransDEN);
        }
        else
        {
            // objDocTransDEN = objDocTransBLL.GetRepresentativeDetails(Session["PAN"].ToString());

            objDocTransDEN.NameID = Convert.ToString(Session["PAN"].ToString());
            objDocTransDEN.Auth_Father_Name = txtFatherSignatory.Text;
            objDocTransDEN.FilingDate = txtDateofReturn.Text;
            objDocTransDEN.Name = txtSignatory.Text;
            objDocTransDEN.PAN = txtPANSignatory.Text;
            objDocTransDEN.Place = txtPlace.Text;
            objDocTransDEN.Auth_Desig = "";
            objDocTransDEN.Auth_Place = txtPlace.Text;
            objDocTransDEN.WardCircle = "";
            objDocTransDEN.Flat = "";
            objDocTransDEN.Premises = "";
            objDocTransDEN.Road = "";
            objDocTransDEN.City = "";
            objDocTransDEN.State = 26;
            objDocTransDEN.Area = "";
            objDocTransDEN.Designation = "";
            objDocTransDEN.PIN = "";

            //objDocTransBLL.UpdateAuthorisedSignatory(objDocTransDEN);
            objDocTransBLL.UpdateRepresentativeDetails(objDocTransDEN);
        }
        //objDocTransBLL.InsertMainDataInStoreTrans(objDocTransDEN, Session["AY"].ToString(), Session["ITR"].ToString(), "", "", 1);

        bllMain objbllMain = new bllMain();
        objbllMain.SetSignPageData(Session["NameId"].ToString(), Session["AY"].ToString(), Session["NameID"].ToString(), txtSignatory.Text, txtPANSignatory.Text, txtFatherSignatory.Text, txtPlace.Text, txtDateofReturn.Text);

       // Response.Redirect("XMLRestore.aspx");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Salary.aspx?vtype=40");
    }
    protected void ddRepSelf_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (ddRepSelf.SelectedValue == "1")
        {
            txtSignatory.Enabled = false;
            txtPANSignatory.Enabled = false;
            txtFatherSignatory.Enabled = false;
            getData();
        }
        else
        {
            txtSignatory.Enabled = true;
            txtPANSignatory.Enabled = true;
            txtFatherSignatory.Enabled = true;
            txtFatherSignatory.Text = "";
            txtPANSignatory.Text = "";
            txtSignatory.Text = "";
        }
    }
    protected void lbtnEditProf_Click(object sender, EventArgs e)
    {
        //Session["Mode"] = "Edit";
        //Session["InternalSal"] = "true";
        //Response.Redirect("Salary.aspx?vtype=106");

        Session["Mode"] = "Edit";
        Session["InternalSal"] = "true";
        Session["IncomeTax_VType"] = "106";
        Response.Redirect("Profile");
    }
}