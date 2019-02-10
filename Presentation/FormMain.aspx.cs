using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using Taxation.BusinessLogic;

public partial class Presentation_FormMain : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

        ViewState["vtype"] = Request.QueryString;
        if (Convert.ToInt32(Session["Checker"]) != 1)
        {
            Session["CopyPan"] = Session["PAN"];
            Session["CopyStatus"] = Session["Status"];
        }

        //if (Page.IsPostBack)
        //{
        
        
        if (Convert.ToString(Session["Mode"]) == "AssesseeSelected" && Convert.ToString(Session["Bool"])=="False")
        {
            if (Convert.ToInt32(Session["CopyStatus"]) == 0)
            {
                SelectDataIndividual(Convert.ToString(Session["CopyPan"]));
                ddlStatus.SelectedIndex = 0;
                PanelIndividual.Visible = true;
                PanelHUF.Visible = false;
                PanelCompany.Visible = false;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
            else if (Convert.ToInt32(Session["CopyStatus"]) == 1)
            {
                selectDataHUF(Convert.ToString(Session["CopyPan"]));
                PanelIndividual.Visible = false;
                PanelHUF.Visible = true;
                PanelCompany.Visible = false;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
            else if (Convert.ToInt32(Session["CopyStatus"]) == 2)
            {
                SelectDataPartner(Convert.ToString(Session["CopyPan"]));
                PanelIndividual.Visible = false;
                PanelHUF.Visible = false;
                PanelCompany.Visible = true;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
            else if (Convert.ToInt32(Session["CopyStatus"]) == 3)
            {
                SelectDataCompany(Convert.ToString(Session["CopyPan"]));
                PanelIndividual.Visible = false;
                PanelHUF.Visible = false;
                PanelCompany.Visible = true;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
            else if (Convert.ToInt32(Session["CopyStatus"]) == 4)
            {
                selectDataAOP(Convert.ToString(Session["CopyPan"]));
                PanelIndividual.Visible = false;
                PanelHUF.Visible = false;
                PanelCompany.Visible = false;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = true;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
            else if (Convert.ToInt32(Session["CopyStatus"]) == 5)
            {
                selectDataCOOP(Convert.ToString(Session["CopyPan"]));
                PanelIndividual.Visible = false;
                PanelHUF.Visible = false;
                PanelCompany.Visible = false;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = true;
                PanelButtons.Visible = true;
            }

        }
     //}
        else if(Convert.ToString(Session["Mode"])=="NewAssessee" && Convert.ToString(Session["Bool"])=="False")
        {
            PanelIndividual.Visible = true;
            PanelHUF.Visible = false;
            PanelCompany.Visible = false;
            PanelAOP.Visible = false;
            PanelCOOP.Visible = false;
            PanelPartnership.Visible = false;
            PanelButtons.Visible = true;
        }
    }

    protected void ShowHide(int SelectedIndex)
    {
        try
        {
            int i;
            i = Convert.ToInt32(Session["SelectedIndex"]);
            if (i == 0)
            {
                PanelIndividual.Visible = true;
                PanelHUF.Visible = false;
                PanelCompany.Visible = false;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
            else if (i == 1)
            {
                PanelIndividual.Visible = false;
                PanelHUF.Visible = true;
                PanelCompany.Visible = false;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
            else if (i == 2)
            {
                PanelIndividual.Visible = false;
                PanelHUF.Visible = false;
                PanelCompany.Visible = false;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = true;
                PanelButtons.Visible = true;
            }
            else if (i == 3)
            {
                PanelIndividual.Visible = false;
                PanelHUF.Visible = false;
                PanelCompany.Visible = true;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
            else if (i == 4)
            {
                PanelIndividual.Visible = false;
                PanelHUF.Visible = false;
                PanelCompany.Visible = false;
                PanelAOP.Visible = true;
                PanelCOOP.Visible = false;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
            else if (i == 5)
            {
                PanelIndividual.Visible = false;
                PanelHUF.Visible = false;
                PanelCompany.Visible = false;
                PanelAOP.Visible = false;
                PanelCOOP.Visible = true;
                PanelPartnership.Visible = false;
                PanelButtons.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Bool"] = "True";
        Session["SelectedIndex"] = ddlStatus.SelectedIndex;
        if (ddlStatus.SelectedIndex == 0)
        {
            PanelIndividual.Visible = true;
            PanelHUF.Visible = false;
            PanelPartnership.Visible = false;
            PanelCompany.Visible = false;
            PanelAOP.Visible = false;
            PanelCOOP.Visible = false;
            

        }
        else if (ddlStatus.SelectedIndex == 1)
        {
            PanelIndividual.Visible = false;
            PanelHUF.Visible = true;
            PanelPartnership.Visible = false;
            PanelCompany.Visible = false;
            PanelAOP.Visible = false;
            PanelCOOP.Visible = false;
            

        }
        else if (ddlStatus.SelectedIndex == 2)
        {
            PanelIndividual.Visible = false;
            PanelHUF.Visible = false;
            PanelPartnership.Visible = true;
            PanelCompany.Visible = false;
            PanelAOP.Visible = false;
            PanelCOOP.Visible = false;


        }
        else if (ddlStatus.SelectedIndex == 3)
        {
            PanelIndividual.Visible = false;
            PanelHUF.Visible = false;
            PanelPartnership.Visible = false;
            PanelCompany.Visible = true;
            PanelAOP.Visible = false;
            PanelCOOP.Visible = false;


        }
        else if (ddlStatus.SelectedIndex == 4)
        {
            PanelIndividual.Visible = false;
            PanelHUF.Visible = false;
            PanelPartnership.Visible = false;
            PanelCompany.Visible = false;
            PanelAOP.Visible = true;
            PanelCOOP.Visible = false;


        }
        else if (ddlStatus.SelectedIndex == 5)
        {
            PanelIndividual.Visible = false;
            PanelHUF.Visible = false;
            PanelPartnership.Visible = false;
            PanelCompany.Visible = false;
            PanelAOP.Visible = false;
            PanelCOOP.Visible = true;


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedIndex == 0)
        {
            InsertDataIndividual();
        }
        else if (ddlStatus.SelectedIndex == 1)
        {
            InsertDataHUF();
        }
        else if (ddlStatus.SelectedIndex == 2)
        {
            InsertDataPartner();
        }
        else if (ddlStatus.SelectedIndex == 3)
        {
            InsertDataCompany();

        }
        else if (ddlStatus.SelectedIndex == 4)
        {
            InsertDataAOP();
        }
        else if (ddlStatus.SelectedIndex == 5)
        {
            InsertDataCOOP();
        }
    }
    void InsertDataIndividual()
    {
        denAssesseeIndividual objAssesseeDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeDEN = new denAssesseeIndividual();
        objAssesseeBLL = new bllAssessee();
        objAssesseeDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
        objAssesseeDEN.UserName = Convert.ToString(Session["UserName"]);
        objAssesseeDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeDEN.PANNO = txtPAN.Text;
        objAssesseeDEN.Salute = ddlSalute.SelectedIndex;
        objAssesseeDEN.LastName = txtLastName.Text;
        objAssesseeDEN.MiddleName = txtMiddleName.Text;
        objAssesseeDEN.FirstName = txtFirstName.Text;
        objAssesseeDEN.FatherName = txtFatherName.Text;
        objAssesseeDEN.TANNO = txtTAN.Text;
        objAssesseeDEN.DateofBirth = txtDOB.Text;
        objAssesseeDEN.ResStatus = ddlResStatus.SelectedIndex;
        objAssesseeDEN.TypeofAss = ddlAssesseeType.SelectedIndex;
        objAssesseeDEN.EMail = txtEmail.Text;
        objAssesseeDEN.WardCircle = txtWard.Text;
        objAssesseeDEN.BussNature = ddlBussNature.SelectedValue;
        objAssesseeDEN.PEOutIndia = 0;
        objAssesseeDEN.PEInIndia = 0;
        objAssesseeBLL.InsertNameMastIndividual(objAssesseeDEN);
        ddlStatus.SelectedIndex = 0;
        txtPAN.Text = "";
        ddlSalute.SelectedIndex = 0;
        txtLastName.Text = "";
        txtMiddleName.Text = "";
        txtFirstName.Text = "";
        txtFatherName.Text = "";
        txtTAN.Text = "";
        txtDOB.Text = "";
        ddlResStatus.SelectedIndex = 0;
        ddlAssesseeType.SelectedIndex = 0;
        txtEmail.Text = "";
        txtWard.Text = "";
        ddlBussNature.SelectedIndex = 0;
        txtSTD.Text = "";
        txtPhone.Text = "";

        PanelIndividual.Visible = true;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = false;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = false;

    }
    void SelectDataIndividual(string PAN)
    {
        try
        {
            dalAssessee objAssesseeDAL = new dalAssessee();
            denAssesseeIndividual objAssesseeIndividualDEN = new denAssesseeIndividual();
            objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(PAN);
            txtPAN.Text = objAssesseeIndividualDEN.PANNO;
            txtLastName.Text = objAssesseeIndividualDEN.LastName;
            txtMiddleName.Text = objAssesseeIndividualDEN.MiddleName;
            txtFirstName.Text = objAssesseeIndividualDEN.FirstName;
            ddlStatus.SelectedIndex = objAssesseeIndividualDEN.Status;
            ddlSalute.SelectedIndex = objAssesseeIndividualDEN.Salute;
            txtFatherName.Text = objAssesseeIndividualDEN.FatherName;
            txtDOB.Text = objAssesseeIndividualDEN.DateofBirth;
            txtWard.Text = objAssesseeIndividualDEN.WardCircle;
            txtTAN.Text = objAssesseeIndividualDEN.TANNO;
            ddlResStatus.SelectedIndex = objAssesseeIndividualDEN.ResStatus;
            txtEmail.Text = objAssesseeIndividualDEN.EMail;
            ddlBussNature.SelectedValue = objAssesseeIndividualDEN.BussNature;
            txtSTD.Text = objAssesseeIndividualDEN.STDCODE;
            txtPhone.Text = objAssesseeIndividualDEN.PhoneNo;
            txtAddress.Text = objAssesseeIndividualDEN.Address;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void SelectDataPartner(string PAN)
    {
        try
        {
            dalAssessee objAssesseeDAL = new dalAssessee();
            denAssesseePartner objAssesseePartnerDEN = new denAssesseePartner();
            objAssesseePartnerDEN = objAssesseeDAL.GetDataPartner(PAN);
            txtPAN.Text = objAssesseePartnerDEN.PANNO;
            txtNamePart.Text = objAssesseePartnerDEN.LastName;
            ddlStatus.SelectedIndex = objAssesseePartnerDEN.Status;
            txtDatePart.Text = objAssesseePartnerDEN.DateofBirth;
            txtWardPart.Text = objAssesseePartnerDEN.WardCircle;
            txtTANPart.Text = objAssesseePartnerDEN.TANNO;
            ddlResPart.SelectedIndex = objAssesseePartnerDEN.ResStatus;
            txtEmailPart.Text = objAssesseePartnerDEN.EMail;
            ddlBussNaturePart.SelectedValue = objAssesseePartnerDEN.BussNature;
            txtSTD2.Text = objAssesseePartnerDEN.STDCODE;
            txtPhone2.Text = objAssesseePartnerDEN.PhoneNo;
            txtAddressPart.Text = objAssesseePartnerDEN.Address;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void selectDataHUF(string PAN)
    {
        try
        {
            dalAssessee objAssesseeDAL = new dalAssessee();
            denAssesseeMain objAssesseeMainDEN = new denAssesseeMain();
            objAssesseeMainDEN = objAssesseeDAL.GetDataGeneral(PAN);
            txtPAN.Text = objAssesseeMainDEN.PANNO;
            txtNameHUF.Text = objAssesseeMainDEN.LastName;
            ddlStatus.SelectedIndex = objAssesseeMainDEN.Status;
            txtDateHUF.Text = objAssesseeMainDEN.DateofBirth;
            txtWardHUF.Text = objAssesseeMainDEN.WardCircle;
            txtTANHUF.Text = objAssesseeMainDEN.TANNO;
            ddlResHUF.SelectedIndex = objAssesseeMainDEN.ResStatus;
            txtEmailHUF.Text = objAssesseeMainDEN.EMail;
            ddlBNHUF.SelectedValue = objAssesseeMainDEN.BussNature;
            txtSTD1.Text = objAssesseeMainDEN.STDCODE;
            txtPhone1.Text = objAssesseeMainDEN.PhoneNo;
            txtAddressHUF.Text = objAssesseeMainDEN.Address;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void selectDataAOP(string PAN)
    {
        try
        {
            dalAssessee objAssesseeDAL = new dalAssessee();
            denAssesseeMain objAssesseeMainDEN = new denAssesseeMain();
            objAssesseeMainDEN = objAssesseeDAL.GetDataGeneral(PAN);
            txtPAN.Text = objAssesseeMainDEN.PANNO;
            txtNameAOP.Text = objAssesseeMainDEN.LastName;
            ddlStatus.SelectedIndex = objAssesseeMainDEN.Status;
            txtDateAOP.Text = objAssesseeMainDEN.DateofBirth;
            txtWardAOP.Text = objAssesseeMainDEN.WardCircle;
            txtTANAOP.Text = objAssesseeMainDEN.TANNO;
            ddlResAOP.SelectedIndex = objAssesseeMainDEN.ResStatus;
            txtEmailAOP.Text = objAssesseeMainDEN.EMail;
            ddlBussAOP.SelectedValue = objAssesseeMainDEN.BussNature;
            txtSTD4.Text = objAssesseeMainDEN.STDCODE;
            txtPhone4.Text = objAssesseeMainDEN.PhoneNo;
            txtAddrAOP.Text = objAssesseeMainDEN.Address;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void selectDataCOOP(string PAN)
    {
        try
        {
            dalAssessee objAssesseeDAL = new dalAssessee();
            denAssesseeMain objAssesseeMainDEN = new denAssesseeMain();
            objAssesseeMainDEN = objAssesseeDAL.GetDataGeneral(PAN);
            txtPAN.Text = objAssesseeMainDEN.PANNO;
            txtNameCOOP.Text = objAssesseeMainDEN.LastName;
            ddlStatus.SelectedIndex = objAssesseeMainDEN.Status;
            txtDateCOOP.Text = objAssesseeMainDEN.DateofBirth;
            txtWardCOOP.Text = objAssesseeMainDEN.WardCircle;
            txtTANCOOP.Text = objAssesseeMainDEN.TANNO;
            ddlResCOOP.SelectedIndex = objAssesseeMainDEN.ResStatus;
            txtEmailCOOP.Text = objAssesseeMainDEN.EMail;
            ddlBussNatureCOOP.SelectedValue = objAssesseeMainDEN.BussNature;
            txtSTD5.Text = objAssesseeMainDEN.STDCODE;
            txtPhone5.Text = objAssesseeMainDEN.PhoneNo;
            txtAddrCOOP.Text = objAssesseeMainDEN.Address;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void SelectDataCompany(string PAN)
    {
        try
        {
            dalAssessee objAssesseeDAL = new dalAssessee();
            denAssesseeCompany objAssesseeCompanyDEN = new denAssesseeCompany();
            objAssesseeCompanyDEN = objAssesseeDAL.GetDataCompany(PAN);
            txtPAN.Text = objAssesseeCompanyDEN.PANNO;
            txtNameComp.Text = objAssesseeCompanyDEN.LastName;
            ddlStatus.SelectedIndex = objAssesseeCompanyDEN.Status;
            txtDateComp.Text = objAssesseeCompanyDEN.DateofBirth;
            txtTANComp.Text = objAssesseeCompanyDEN.TANNO;
            txtWardComp.Text = objAssesseeCompanyDEN.WardCircle;
            ddlResComp.SelectedIndex = objAssesseeCompanyDEN.ResStatus;
            ddlBussNatureComp.SelectedValue = objAssesseeCompanyDEN.BussNature;
            ddlCompStatus.SelectedValue = objAssesseeCompanyDEN.CompStatus;
            txtSTD3.Text = objAssesseeCompanyDEN.STDCODE;
            txtPhone3.Text = objAssesseeCompanyDEN.PhoneNo;
            txtAddressComp.Text = objAssesseeCompanyDEN.Address;
            txtEmailComp.Text = objAssesseeCompanyDEN.EMail;
            ddlCompNature.SelectedValue = objAssesseeCompanyDEN.CompNature;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void InsertDataHUF()
    {
        denAssesseeMain objAssesseeMainDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeMainDEN = new denAssesseeMain();
        objAssesseeBLL = new bllAssessee();
        objAssesseeMainDEN.UserName = Convert.ToString(Session["UserName"]);
        objAssesseeMainDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeMainDEN.PANNO = txtPAN.Text;
        objAssesseeMainDEN.LastName = txtNameHUF.Text;
        objAssesseeMainDEN.TANNO = txtTANHUF.Text;
        objAssesseeMainDEN.DateofBirth = txtDateHUF.Text;
        objAssesseeMainDEN.WardCircle = txtWardHUF.Text;
        objAssesseeMainDEN.ResStatus = ddlResHUF.SelectedIndex;
        objAssesseeMainDEN.BussNature = ddlBNHUF.SelectedValue;
        objAssesseeMainDEN.PEOutIndia = 0;
        objAssesseeMainDEN.PEInIndia = 0;
        objAssesseeMainDEN.EMail = txtEmailHUF.Text;
        objAssesseeBLL.InsertDataGeneral(objAssesseeMainDEN);
        ddlStatus.SelectedIndex = 0;
        txtPAN.Text = "";
        txtNameHUF.Text = "";
        txtDateHUF.Text = "";
        txtWardHUF.Text = "";
        ddlResHUF.Text = "";
        ddlBNHUF.SelectedIndex = 0;
        ddlResHUF.SelectedIndex = 0;
        txtEmailHUF.Text = "";
        txtSTD1.Text = "";
        txtPhone1.Text = "";
        PanelIndividual.Visible = false;
        PanelHUF.Visible = true;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = false;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = false;
    }
    void InsertDataPartner()
    {
        denAssesseePartner objAssesseePartnerDEN;
        bllAssessee objAssesseeBLL;
        objAssesseePartnerDEN = new denAssesseePartner();
        objAssesseeBLL = new bllAssessee();
        objAssesseePartnerDEN.UserName = Convert.ToString(Session["UserName"]);
        objAssesseePartnerDEN.Status = ddlStatus.SelectedIndex;
        objAssesseePartnerDEN.PANNO = txtPAN.Text;
        objAssesseePartnerDEN.TANNO = txtTANPart.Text;
        objAssesseePartnerDEN.LastName = txtNamePart.Text;
        objAssesseePartnerDEN.DateofBirth = txtDatePart.Text;
        objAssesseePartnerDEN.WardCircle = txtWardPart.Text;
        objAssesseePartnerDEN.ResStatus = ddlResPart.SelectedIndex;
        objAssesseePartnerDEN.BussNature = ddlBussNaturePart.SelectedValue;
        objAssesseePartnerDEN.PEOutIndia = 0;
        objAssesseePartnerDEN.PEInIndia = 0;
        objAssesseePartnerDEN.EMail = txtEmailPart.Text;
        objAssesseePartnerDEN.TypeofFirm = ddlTypeofFirmPart.SelectedIndex;
        objAssesseeBLL.InsertDataPartner(objAssesseePartnerDEN);
        ddlStatus.SelectedIndex = 0;
        txtPAN.Text = "";
        txtTANPart.Text = "";
        txtNamePart.Text = "";
        txtDatePart.Text = "";
        txtWardPart.Text = "";
        ddlResPart.SelectedIndex = 0;
        ddlBussNaturePart.SelectedIndex = 0;
        txtEmailPart.Text = "";
        txtSTD2.Text = "";
        txtPhone2.Text = "";
        ddlTypeofFirmPart.SelectedIndex = 0;
        PanelIndividual.Visible = false;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = true;
        PanelCompany.Visible = false;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = false;


    }
    void InsertDataCompany()
    {
        denAssesseeCompany objAssesseeCompanyDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeCompanyDEN = new denAssesseeCompany();
        objAssesseeBLL = new bllAssessee();
        objAssesseeCompanyDEN.UserName = Convert.ToString(Session["UserName"]);
        objAssesseeCompanyDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeCompanyDEN.PANNO = txtPAN.Text;
        objAssesseeCompanyDEN.LastName = txtNameComp.Text;
        objAssesseeCompanyDEN.ResStatus = ddlResComp.SelectedIndex;
        objAssesseeCompanyDEN.BussNature = ddlBussNatureComp.SelectedValue;
        objAssesseeCompanyDEN.WardCircle = txtWardComp.Text;
        objAssesseeCompanyDEN.PEOutIndia = 0;
        objAssesseeCompanyDEN.PEInIndia = 0;
        objAssesseeCompanyDEN.DateofBirth = txtDateComp.Text;
        objAssesseeCompanyDEN.CompStatus = ddlCompStatus.SelectedValue;
        objAssesseeCompanyDEN.CompNature = ddlCompNature.SelectedValue;
        objAssesseeCompanyDEN.EMail = txtEmailComp.Text;

        objAssesseeBLL.InsertDataCompany(objAssesseeCompanyDEN);
        ddlStatus.SelectedIndex = 0;
        txtPAN.Text = "";
        txtNameComp.Text = "";
        ddlResComp.SelectedIndex = 0;
        ddlBussNatureComp.SelectedIndex = 0;
        txtWardComp.Text = "";
        txtDateComp.Text = "";
        ddlCompStatus.SelectedIndex = 0;
        ddlCompNature.Text = "";
        txtEmailComp.Text = "";
        txtSTD3.Text = "";
        txtPhone3.Text = "";
        PanelIndividual.Visible = false;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = true;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = false;
    }
    void InsertDataAOP()
    {
        denAssesseeMain objAssesseeMainDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeMainDEN = new denAssesseeMain();
        objAssesseeBLL = new bllAssessee();
        objAssesseeMainDEN.UserName = Convert.ToString(Session["UserName"]);
        objAssesseeMainDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeMainDEN.PANNO = txtPAN.Text;
        objAssesseeMainDEN.LastName = txtNameAOP.Text;
        objAssesseeMainDEN.TANNO = txtTANAOP.Text;
        objAssesseeMainDEN.DateofBirth = txtDateAOP.Text;
        objAssesseeMainDEN.WardCircle = txtWardAOP.Text;
        objAssesseeMainDEN.ResStatus = ddlResAOP.SelectedIndex;
        objAssesseeMainDEN.BussNature = ddlBussAOP.SelectedValue;
        objAssesseeMainDEN.PEOutIndia = 0;
        objAssesseeMainDEN.PEInIndia = 0;
        objAssesseeMainDEN.EMail = txtEmailAOP.Text;
        objAssesseeBLL.InsertDataGeneral(objAssesseeMainDEN);

        ddlStatus.SelectedIndex = 0;
        txtPAN.Text = "";
        txtNameAOP.Text = "";
        txtTANAOP.Text = "";
        txtDateAOP.Text = "";
        txtWardAOP.Text = "";
        ddlResAOP.SelectedIndex = 0;
        ddlBussAOP.SelectedIndex = 0;
        txtEmailAOP.Text = "";
        txtSTD4.Text = "";
        txtPhone4.Text = "";

        PanelIndividual.Visible = false;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = false;
        PanelAOP.Visible = true;
        PanelCOOP.Visible = false;

        }
    void InsertDataCOOP()
    {
        denAssesseeMain objAssesseeMainDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeMainDEN = new denAssesseeMain();
        objAssesseeBLL = new bllAssessee();
        objAssesseeMainDEN.UserName = Convert.ToString(Session["UserName"]);
        objAssesseeMainDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeMainDEN.PANNO = txtPAN.Text;
        objAssesseeMainDEN.LastName = txtNameCOOP.Text;
        objAssesseeMainDEN.TANNO = txtTANCOOP.Text;
        objAssesseeMainDEN.DateofBirth = txtDateCOOP.Text;
        objAssesseeMainDEN.WardCircle = txtWardCOOP.Text;
        objAssesseeMainDEN.ResStatus = ddlResCOOP.SelectedIndex;
        objAssesseeMainDEN.BussNature = ddlBussNatureCOOP.SelectedValue;
        objAssesseeMainDEN.PEOutIndia = 0;
        objAssesseeMainDEN.PEInIndia = 0;
        objAssesseeMainDEN.EMail = txtEmailCOOP.Text;
        objAssesseeBLL.InsertDataGeneral(objAssesseeMainDEN);

        ddlStatus.SelectedIndex = 0;
        txtPAN.Text = "";
        txtNameCOOP.Text = "";
        txtTANCOOP.Text = "";
        txtDateCOOP.Text = "";
        txtWardCOOP.Text = "";
        ddlResCOOP.SelectedIndex = 0;
        ddlBussNatureCOOP.SelectedIndex = 0;
        txtEmailCOOP.Text = "";
        txtSTD5.Text = "";
        txtPhone5.Text = "";
        PanelIndividual.Visible = false;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = false;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = true;
    }

    void UpdateDataIndividual()
    {
        denAssesseeIndividual objAssesseeDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeDEN = new denAssesseeIndividual();
        objAssesseeBLL = new bllAssessee();
       
        objAssesseeDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeDEN.PANNO = txtPAN.Text;
        objAssesseeDEN.Salute = ddlSalute.SelectedIndex;
        objAssesseeDEN.LastName = txtLastName.Text;
        objAssesseeDEN.MiddleName = txtMiddleName.Text;
        objAssesseeDEN.FirstName = txtFirstName.Text;
        objAssesseeDEN.FatherName = txtFatherName.Text;
        objAssesseeDEN.TANNO = txtTAN.Text;
        objAssesseeDEN.DateofBirth = txtDOB.Text;
        objAssesseeDEN.ResStatus = ddlResStatus.SelectedIndex;
        objAssesseeDEN.TypeofAss = ddlAssesseeType.SelectedIndex;
        objAssesseeDEN.EMail = txtEmail.Text;
        objAssesseeDEN.WardCircle = txtWard.Text;
        objAssesseeDEN.BussNature = ddlBussNature.SelectedValue;
        objAssesseeDEN.PEOutIndia = 0;
        objAssesseeDEN.PEInIndia = 0;

        objAssesseeBLL.UpdateDataIndividual(objAssesseeDEN);
        PanelIndividual.Visible = true;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = false;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = false;




    }
    void UpdatedataHUF()
    {
        denAssesseeMain objAssesseeMainDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeMainDEN = new denAssesseeMain();
        objAssesseeBLL = new bllAssessee();
       
        objAssesseeMainDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeMainDEN.PANNO = txtPAN.Text;
        objAssesseeMainDEN.LastName = txtNameHUF.Text;
        objAssesseeMainDEN.TANNO = txtTANHUF.Text;
        objAssesseeMainDEN.DateofBirth = txtDateHUF.Text;
        objAssesseeMainDEN.WardCircle = txtWardHUF.Text;
        objAssesseeMainDEN.ResStatus = ddlResHUF.SelectedIndex;
        objAssesseeMainDEN.BussNature = ddlBNHUF.SelectedValue;
        objAssesseeMainDEN.PEOutIndia = 0;
        objAssesseeMainDEN.PEInIndia = 0;
        objAssesseeMainDEN.EMail = txtEmailHUF.Text;
        objAssesseeBLL.UpdateDataGeneral(objAssesseeMainDEN);
        PanelIndividual.Visible = false;
        PanelHUF.Visible = true;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = false;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = false;
    }

    void UpdatedataCompany()
    {
        denAssesseeCompany objAssesseeCompanyDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeCompanyDEN = new denAssesseeCompany();
        objAssesseeBLL = new bllAssessee();
        objAssesseeCompanyDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeCompanyDEN.PANNO = txtPAN.Text;
        objAssesseeCompanyDEN.LastName = txtNameComp.Text;
        objAssesseeCompanyDEN.ResStatus = ddlResComp.SelectedIndex;
        objAssesseeCompanyDEN.BussNature = ddlBussNatureComp.SelectedValue;
        objAssesseeCompanyDEN.WardCircle = txtWardComp.Text;
        objAssesseeCompanyDEN.PEOutIndia = 0;
        objAssesseeCompanyDEN.PEInIndia = 0;
        objAssesseeCompanyDEN.DateofBirth = txtDateComp.Text;
        objAssesseeCompanyDEN.CompStatus = ddlCompStatus.SelectedValue;
        objAssesseeCompanyDEN.CompNature = ddlCompNature.SelectedValue;
        objAssesseeCompanyDEN.EMail = txtEmailComp.Text;

        objAssesseeBLL.UpdateDataCompany(objAssesseeCompanyDEN);
        PanelIndividual.Visible = false;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = true;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = false;
    }

    void UpdateDataPartner()
    {
        denAssesseePartner objAssesseePartnerDEN;
        bllAssessee objAssesseeBLL;
        objAssesseePartnerDEN = new denAssesseePartner();
        objAssesseeBLL = new bllAssessee();
        objAssesseePartnerDEN.Status = ddlStatus.SelectedIndex;
        objAssesseePartnerDEN.PANNO = txtPAN.Text;
        objAssesseePartnerDEN.TANNO = txtTANPart.Text;
        objAssesseePartnerDEN.LastName = txtNamePart.Text;
        objAssesseePartnerDEN.DateofBirth = txtDatePart.Text;
        objAssesseePartnerDEN.WardCircle = txtWardPart.Text;
        objAssesseePartnerDEN.ResStatus = ddlResPart.SelectedIndex;
        objAssesseePartnerDEN.BussNature = ddlBussNaturePart.SelectedValue;
        objAssesseePartnerDEN.PEOutIndia = 0;
        objAssesseePartnerDEN.PEInIndia = 0;
        objAssesseePartnerDEN.EMail = txtEmailPart.Text;
        objAssesseePartnerDEN.TypeofFirm = ddlTypeofFirmPart.SelectedIndex;
        objAssesseeBLL.UpdateDataPartner(objAssesseePartnerDEN);
        PanelIndividual.Visible = false;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = true;
        PanelCompany.Visible = false;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = false;

    }

    void UpdateDataAOP()
    {
        denAssesseeMain objAssesseeMainDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeMainDEN = new denAssesseeMain();
        objAssesseeBLL = new bllAssessee();
        objAssesseeMainDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeMainDEN.PANNO = txtPAN.Text;
        objAssesseeMainDEN.LastName = txtNameAOP.Text;
        objAssesseeMainDEN.TANNO = txtTANAOP.Text;
        objAssesseeMainDEN.DateofBirth = txtDateAOP.Text;
        objAssesseeMainDEN.WardCircle = txtWardAOP.Text;
        objAssesseeMainDEN.ResStatus = ddlResAOP.SelectedIndex;
        objAssesseeMainDEN.BussNature = ddlBussAOP.SelectedValue;
        objAssesseeMainDEN.PEOutIndia = 0;
        objAssesseeMainDEN.PEInIndia = 0;
        objAssesseeMainDEN.EMail = txtEmailAOP.Text;
        objAssesseeBLL.UpdateDataGeneral(objAssesseeMainDEN);

        PanelIndividual.Visible = false;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = false;
        PanelAOP.Visible = true;
        PanelCOOP.Visible = false;

    }

    void UpdateDataCOOP()
    {
        denAssesseeMain objAssesseeMainDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeMainDEN = new denAssesseeMain();
        objAssesseeBLL = new bllAssessee();
        objAssesseeMainDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeMainDEN.PANNO = txtPAN.Text;
        objAssesseeMainDEN.LastName = txtNameCOOP.Text;
        objAssesseeMainDEN.TANNO = txtTANCOOP.Text;
        objAssesseeMainDEN.DateofBirth = txtDateCOOP.Text;
        objAssesseeMainDEN.WardCircle = txtWardCOOP.Text;
        objAssesseeMainDEN.ResStatus = ddlResCOOP.SelectedIndex;
        objAssesseeMainDEN.BussNature = ddlBussNatureCOOP.SelectedValue;
        objAssesseeMainDEN.PEOutIndia = 0;
        objAssesseeMainDEN.PEInIndia = 0;
        objAssesseeMainDEN.EMail = txtEmailCOOP.Text;
        objAssesseeBLL.UpdateDataGeneral(objAssesseeMainDEN);
        PanelIndividual.Visible = false;
        PanelHUF.Visible = false;
        PanelPartnership.Visible = false;
        PanelCompany.Visible = false;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = true;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedIndex == 0)
            UpdateDataIndividual();
        else if (ddlStatus.SelectedIndex == 1)
            UpdatedataHUF();
        else if (ddlStatus.SelectedIndex == 2)
            UpdateDataPartner();
        else if (ddlStatus.SelectedIndex == 3)
            UpdatedataCompany();
        else if (ddlStatus.SelectedIndex == 4)
            UpdateDataAOP();
        else if (ddlStatus.SelectedIndex == 5)
            UpdateDataCOOP();
        Session["PAN"] = txtPAN.Text;
        Button2.Enabled = false;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        PanelIndividual.Visible = true;
        pnlAddress.Visible = true;
        
        ShowHide(Convert.ToInt32(Session["SelectedIndex"]));
        
        
        GetAddress(Convert.ToString(Session["CopyPan"]));
    }
    protected void lnkHUF_Click(object sender, EventArgs e)
    {
        PanelHUF.Visible = true;
        pnlAddress.Visible = true;

        ShowHide(Convert.ToInt32(Session["SelectedIndex"]));
        

        GetAddress(Convert.ToString(Session["CopyPan"]));
    }
    protected void lnkPartner_Click(object sender, EventArgs e)
    {
        PanelPartnership.Visible = true;
        pnlAddress.Visible = true;
        ShowHide(Convert.ToInt32(Session["SelectedIndex"]));
        

        GetAddress(Convert.ToString(Session["CopyPan"]));
    }
    protected void lnkCompany_Click(object sender, EventArgs e)
    {
        PanelCompany.Visible = true;
        pnlAddress.Visible = true;
        ShowHide(Convert.ToInt32(Session["SelectedIndex"]));
        

        GetAddress(Convert.ToString(Session["CopyPan"]));
    }
    protected void lnkAOP_Click(object sender, EventArgs e)
    {
        PanelAOP.Visible = true;
        pnlAddress.Visible = true;
        ShowHide(Convert.ToInt32(Session["SelectedIndex"]));
        

        GetAddress(Convert.ToString(Session["CopyPan"]));
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        PanelCOOP.Visible = true;
        pnlAddress.Visible = true;
        ShowHide(Convert.ToInt32(Session["SelectedIndex"]));
        

        GetAddress(Convert.ToString(Session["CopyPan"]));
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlAddress.Visible = false;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            denAddress objAddressDEN;
            bllAddress objAddressBLL;
            objAddressDEN = new denAddress();
            objAddressBLL = new bllAddress();
            objAddressDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
            objAddressDEN.NameID = Convert.ToString(txtPAN.Text);
            objAddressDEN.Flat = txtFlat.Text;
            objAddressDEN.Road = txtRoad.Text;
            objAddressDEN.City = txtCity.Text;
            objAddressDEN.PIN = txtPIN.Text;
            objAddressDEN.Premises = txtPremises.Text;
            objAddressDEN.Area = txtArea.Text;
            objAddressDEN.State = ddlState.SelectedValue;
            string stateName = ddlState.Items[ddlState.SelectedIndex].Text;
            objAddressDEN.Address = objAddressDEN.Flat + "," + objAddressDEN.Premises + "," + objAddressDEN.Road + "," + objAddressDEN.Area + "," + objAddressDEN.City + "," + stateName + "," + objAddressDEN.PIN;

            

            if (PanelIndividual.Visible == true)
            {
                txtAddress.Text = objAddressDEN.Address;
                objAddressDEN.STDCODE = txtSTD.Text;
                objAddressDEN.PhoneNo = txtPhone.Text;
            }
            else if (PanelHUF.Visible == true)
            {
                txtAddressHUF.Text = objAddressDEN.Address;
                objAddressDEN.STDCODE = txtSTD1.Text;
                objAddressDEN.PhoneNo = txtPhone1.Text;
            }
            else if (PanelPartnership.Visible == true)
            {
                txtAddressPart.Text = objAddressDEN.Address;
                objAddressDEN.STDCODE = txtSTD2.Text;
                objAddressDEN.PhoneNo = txtPhone2.Text;
            }
            else if (PanelCompany.Visible == true)
            {
                txtAddressComp.Text = objAddressDEN.Address;
                objAddressDEN.STDCODE = txtSTD3.Text;
                objAddressDEN.PhoneNo = txtPhone3.Text;
            }
            else if (PanelAOP.Visible == true)
            {
                txtAddrAOP.Text = objAddressDEN.Address;
                objAddressDEN.STDCODE = txtSTD4.Text;
                objAddressDEN.PhoneNo = txtPhone4.Text;
            }
            else if (PanelCOOP.Visible == true)
            {
                txtAddrCOOP.Text = objAddressDEN.Address;
                objAddressDEN.STDCODE = txtSTD5.Text;
                objAddressDEN.PhoneNo = txtPhone5.Text;
            }
            objAddressBLL.InsertAddress(objAddressDEN);
            pnlAddress.Visible = false;




        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    protected void txtDOB_TextChanged(object sender, EventArgs e)
    {
        string date = txtDOB.Text;
        DateTime str = Convert.ToDateTime(date);
        string strc = str.ToShortDateString();
        txtDOB.Text = strc;
    }
    protected void txtDateHUF_TextChanged(object sender, EventArgs e)
    {
        string date = txtDateHUF.Text;
        DateTime str = Convert.ToDateTime(date);
        string strc = str.ToShortDateString();
        txtDateHUF.Text = strc;
    }
    protected void txtDatePart_TextChanged(object sender, EventArgs e)
    {
        string date = txtDatePart.Text;
        DateTime str = Convert.ToDateTime(date);
        string strc = str.ToShortDateString();
        txtDatePart.Text = strc;
    }

    protected void txtDateComp_TextChanged(object sender, EventArgs e)
    {
        string date = txtDateComp.Text;
        DateTime str = Convert.ToDateTime(date);
        string strc = str.ToShortDateString();
        txtDateComp.Text = strc;
    }
    protected void txtDateAOP_TextChanged(object sender, EventArgs e)
    {
        string date = txtDateAOP.Text;
        DateTime str = Convert.ToDateTime(date);
        string strc = str.ToShortDateString();
        txtDateAOP.Text = strc;
    }
    protected void txtDateCOOP_TextChanged(object sender, EventArgs e)
    {
        string date = txtDateCOOP.Text;
        DateTime str = Convert.ToDateTime(date);
        string strc = str.ToShortDateString();
        txtDateCOOP.Text = strc;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Directormaster.aspx");
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        denLogin objLoginDEN = new denLogin();
        bllLogin objLoginBLL = new bllLogin();

        objLoginDEN.UserName = Convert.ToString(Session["UserName"]);
        objLoginDEN.LogoutTime = DateTime.Now.ToShortTimeString();
        objLoginBLL.UpdateUserDetails(objLoginDEN);
        Response.Redirect("Login.aspx");
        Session["UserName"] = "";
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Session["Checker"] = 1;
        Session["CopyPan"] = "";
        //string str = Convert.ToString(Session["PAN"]);
        Button2.Enabled = true;
        btnNew.Enabled = false;

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["CopyPan"] = "";
        Session["CopyStatus"] = "";
        btnInsert.Enabled = true;
        btnEdit.Enabled = false;
        PanelIndividual.Visible = true;
        PanelHUF.Visible = false;
        PanelCompany.Visible = false;
        PanelAOP.Visible = false;
        PanelCOOP.Visible = false;
        PanelPartnership.Visible = false;
        PanelButtons.Visible = true;
    }
    protected void GetAddress(string PAN)
    {
        try
        {
            denAddress objAddressDEN = new denAddress();
            bllAddress objAddressBLL = new bllAddress();
            objAddressDEN = objAddressBLL.GetAddress(PAN);
            txtFlat.Text = objAddressDEN.Flat;
            txtPremises.Text = objAddressDEN.Premises;
            txtRoad.Text = objAddressDEN.Road;
            txtArea.Text = objAddressDEN.Area;
            txtCity.Text = objAddressDEN.City;
            ddlState.SelectedValue = objAddressDEN.State;
            txtPIN.Text = objAddressDEN.PIN;
            if (Convert.ToString(Session["CopyPAN"]) == "")
                btnOK.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
    protected void btnUpdateAddress_Click(object sender, EventArgs e)
    {
        denAddress objAddressDEN1 = new denAddress();
        objAddressDEN1.NameID = Convert.ToString(Session["PAN"]);
        objAddressDEN1.Flat = txtFlat.Text;
        objAddressDEN1.Premises = txtPremises.Text;
        objAddressDEN1.Road = txtRoad.Text;
        objAddressDEN1.Area = txtArea.Text;
        objAddressDEN1.City = txtCity.Text;
        objAddressDEN1.PIN = txtPIN.Text;
        objAddressDEN1.State = ddlState.SelectedValue;
        string stateName =ddlState.Items[ddlState.SelectedIndex].Text;
        objAddressDEN1.Address = objAddressDEN1.Flat + "," + objAddressDEN1.Premises + "," + objAddressDEN1.Road + "," + objAddressDEN1.Area + "," + objAddressDEN1.City + "," + stateName + "," + objAddressDEN1.PIN;
        bllAddress objAddressBLL = new bllAddress();
        objAddressBLL.UpdateAddress(objAddressDEN1);


    }
    
    protected void Button1_Click2(object sender, EventArgs e)
    {
        btnUpdateAddress.Enabled = true;
    }
    //protected void btncancel_Click(object sender, EventArgs e)
    //{
    //    Session["CopyPan"] = Session["PAN"];
    //    Session["CopyStatus"] = Session["Status"];
    //    Session["Checker"] = 0;

    //    btnInsert.Enabled = false;
    //    btnEdit.Enabled = true;
    //}
    protected void Button6_Click(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
}
