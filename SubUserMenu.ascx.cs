using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using Taxation.BusinessLogic;

public partial class SubUserMenu : System.Web.UI.UserControl
{
    //static int 
    public void Page_Load(object sender, EventArgs e)
    {
        string sa1 = "";
        if (Session["IsMaster"] != null)
            sa1 = Session["IsMaster"].ToString();

        if (Session["IsMaster"] != null && Session["Account_Type"] != null)
        {
            string ss1 = Session["IsMaster"].ToString();
            ss1 = Session["Account_Type"].ToString();
        }
        //if (Session["UserName"] != null)
        //    lblUser.Text = Session["UserName"].ToString();
        if (Session["PAN"] != null)
            SelectDataIndividual(Session["PAN"].ToString());
        string ss = "";
        if (Session["Account_Type"] != null)
            ss = Session["Account_Type"].ToString();
    }

    protected void lbtnEditProf_Click(object sender, EventArgs e)
    {
        Session["Mode"] = "Edit";
        Session["InternalSal"] = "true";
        Response.Redirect("Salary.aspx?vtype=106");
    }

    public void SelectDataIndividual(string PAN)
    {
        if (Session["project"].ToString() == "tds")
        {
            lblUser.Text = Session["Name"].ToString();
            lblAY.Text = (Session["ay"] != null) ? Session["ay"].ToString() : "";
            lblPAN.Text = (Session["TAN"] != null) ? Session["TAN"].ToString() : "";
            ltTitle.Text = "TAN";
            ltMain.Text = "DEDUCTOR DETAILS";
            ltSelect.Text = "Select Deductors";
            ltSelectTDS.Text = "Change Deductee";
        }
        else
        {
            ltTitle.Text = "PAN";
            ltMain.Text = "ASSESSEE DETAILS";
            ltSelect.Text = "Assessee";
            try
            {
                dalAssessee objAssesseeDAL = new dalAssessee();
                denAssesseeIndividual objAssesseeIndividualDEN = new denAssesseeIndividual();
                objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(PAN);
                lblUser.Text = objAssesseeIndividualDEN.FirstName + " " + objAssesseeIndividualDEN.MiddleName + " " + objAssesseeIndividualDEN.LastName;
                lblAY.Text = (Session["ay"] != null) ? Session["ay"].ToString() : "";
                lblPAN.Text = objAssesseeIndividualDEN.PANNO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}