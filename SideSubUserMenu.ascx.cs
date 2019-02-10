using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using Taxation.BusinessLogic;

public partial class SideSubUserMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserName"] != null)
        //    lblUser.Text = Session["UserName"].ToString();
        if (Session["PAN"] != null)
            SelectDataIndividual(Session["PAN"].ToString());

    }
    public void SelectDataIndividual(string PAN)
    {
        ltTitleMain.Text = "Profile";
        if (Session["project"].ToString() == "tds")
        {
            lblQuarter.Visible = true;
            ltQuarter.Visible = true;
            lblUser.Text = Session["Name"].ToString();
            ltAY.Text = "FY";
            lblAY.Text = (Session["FY"] != null) ? Session["FY"].ToString() : "";
            lblPAN.Text = Session["TAN"].ToString();
            ltTitle.Text = "TAN";
            lblQuarter.Text = (Session["qtr"] != null) ? Session["qtr"].ToString() : "";
            ltMain.Text = "DEDUCTOR DETAILS";
            ltSelect.Text = "Switch to other Deductor";
        }
        else
        {
            ltQuarter.Visible = false;
            ltAY.Text = "AY";
            ltTitle.Text = "PAN";
            lblQuarter.Visible = false;
            ltMain.Text = "ASSESSEE DETAILS";
            if (Session["AssesseeUser"] != null && Session["Project"].ToString() == "vt")
            {
                ltSelect.Text = "Update Profile";
                aProfile.HRef = "Presentation/individual.aspx";
                ltMain.Text = "PERSONAL DETAILS";
            }
            else
            {
                ltSelect.Text = "Switch to other Assessee";
                ltTitleMain.Text = "Assesee<br>Details";
            }
            try
            {
                dalAssessee objAssesseeDAL = new dalAssessee();
                denAssesseeIndividual objAssesseeIndividualDEN = new denAssesseeIndividual();
                //objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(PAN);
                objAssesseeIndividualDEN = objAssesseeDAL.getAssesseeMinDetail(PAN);
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