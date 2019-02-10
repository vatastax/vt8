using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using Taxation.BusinessLogic;

public partial class Presentation_MediumSubUserMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["PAN"] != null)
            SelectDataIndividual(Session["PAN"].ToString());

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
            ltSelect.Text = "Change Deductors";
        }
        else
        {
            ltTitle.Text = "PAN";
            ltMain.Text = "ASSESSEE DETAILS";
            ltSelect.Text = "Change Assessees";
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