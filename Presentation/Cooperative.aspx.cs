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
using Taxation.BusinessLogic;

public partial class Presentation_Cooperative : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblAssesseeType.Text = Convert.ToString(Session["AssesseeType"]);
        lblPan.Text = Convert.ToString(Session["PAN"]);
        if (!IsPostBack)
        {
            ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";
            bllAssessee objAssesseeBLL = new bllAssessee();
            DataTable dtBC = new DataTable();
            dtBC = objAssesseeBLL.SelectBusinessCategories();

            ddBusiness.DataSource = dtBC;
            ddBusiness.DataTextField = "title";
            ddBusiness.DataValueField = "id";
            ddBusiness.DataBind();
            ListItem lstFirst = new ListItem(" -- Select -- ", "0");
            ddBusiness.Items.Insert(0, lstFirst);

            ddBusiness2.DataSource = dtBC;
            ddBusiness2.DataTextField = "title";
            ddBusiness2.DataValueField = "id";
            ddBusiness2.DataBind();
            ddBusiness2.Items.Insert(0, lstFirst);

            ddBusiness3.DataSource = dtBC;
            ddBusiness3.DataTextField = "title";
            ddBusiness3.DataValueField = "id";
            ddBusiness3.DataBind();
            ddBusiness3.Items.Insert(0, lstFirst);
            selectDataCOOP(Convert.ToString(Session["PAN"]));
            GetAddress(Convert.ToString(Session["PAN"]));
            GetBankDetails(Convert.ToString(Session["PAN"]));
            GetRepresentativeDetails(Convert.ToString(Session["PAN"]));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Convert.ToString(Session["Mode"]) == "New")
            {
                InsertDataCOOP();
                InsertAddress();
            }
            else if (Convert.ToString(Session["Mode"]) == "Edit")
            {
                UpdateDataCOOP();
                UpdateAddress();
            }
            UpdateBankDetails();
            if (rdoRepresentative.Checked == true)
            {
                UpdateRepresentativeDetails();
            }
            if (rdoSelf.Checked == true)
            {
                UpdateAuthorisedSignatory();
            }
        }
    }
    void UpdateDataCOOP()
    {
        denAssesseeMain objAssesseeMainDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeMainDEN = new denAssesseeMain();
        objAssesseeBLL = new bllAssessee();
        objAssesseeMainDEN.Status = Convert.ToInt32(Session["Status"]);
        objAssesseeMainDEN.PANNO = Convert.ToString(Session["PAN"]);
        objAssesseeMainDEN.LastName = txtNameCOOP.Text;
        objAssesseeMainDEN.TANNO = txtTANCOOP.Text;
        objAssesseeMainDEN.DateofBirth = txtDateCOOP.Text;
        objAssesseeMainDEN.WardCircle = txtWardCOOP.Text;
        objAssesseeMainDEN.ResStatus = ddlResCOOP.SelectedIndex;
        objAssesseeMainDEN.BussNature = ddlBussNatureCOOP.SelectedValue;
        objAssesseeMainDEN.PEOutIndia = 0;
        objAssesseeMainDEN.PEInIndia = 0;
        objAssesseeMainDEN.EMail = txtEmail.Text;
        objAssesseeBLL.UpdateDataGeneral(objAssesseeMainDEN);
        
    }
    void GetBankDetails(string NameID)
    {
        try
        {
            denDocTrans objDocTransDEN = new denDocTrans();
            bllDocTrans objDocTransBLL = new bllDocTrans();
            objDocTransDEN = objDocTransBLL.GetBankDetails(NameID);
            txtBankName.Text = objDocTransDEN.BankNAme;
            txtBranchAddress.Text = objDocTransDEN.AddressofBranch;
            txtAccountNumber.Text = objDocTransDEN.AccountNumber;
            txtMICR.Text = objDocTransDEN.MICRCode;
            ddlAccountType.SelectedValue = objDocTransDEN.AccountType;
            ddlESC.SelectedValue = objDocTransDEN.ECS;
            ddlRefund.SelectedValue = objDocTransDEN.RefundMethod;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void UpdateBankDetails()
    {
        try
        {
            denDocTrans objDocTransDEN = new denDocTrans();
            bllDocTrans objDocTransBLL = new bllDocTrans();
            objDocTransDEN.NameID = Convert.ToString(Session["PAN"]);
            objDocTransDEN.AccountType = ddlAccountType.SelectedValue;
            objDocTransDEN.MICRCode = txtMICR.Text;
            objDocTransDEN.AccountNumber = txtAccountNumber.Text;
            objDocTransDEN.AddressofBranch = txtBranchAddress.Text;
            objDocTransDEN.ECS = ddlESC.SelectedValue;
            objDocTransDEN.RefundMethod = ddlRefund.SelectedValue;
            objDocTransBLL.UpdateBankDetails(objDocTransDEN);



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void InsertDataCOOP()
    {
        denAssesseeMain objAssesseeMainDEN;
        bllAssessee objAssesseeBLL;
        objAssesseeMainDEN = new denAssesseeMain();
        objAssesseeBLL = new bllAssessee();
        objAssesseeMainDEN.UserName = Convert.ToString(Session["UserName"]);
        objAssesseeMainDEN.Status = Convert.ToInt32(Session["Status"]);
        objAssesseeMainDEN.PANNO = Convert.ToString(Session["PAN"]);
        objAssesseeMainDEN.LastName = txtNameCOOP.Text;
        objAssesseeMainDEN.TANNO = txtTANCOOP.Text;
        objAssesseeMainDEN.DateofBirth = txtDateCOOP.Text;
        objAssesseeMainDEN.WardCircle = txtWardCOOP.Text;
        objAssesseeMainDEN.ResStatus = ddlResCOOP.SelectedIndex;
        objAssesseeMainDEN.BussNature = ddlBussNatureCOOP.SelectedValue;
        objAssesseeMainDEN.PEOutIndia = 0;
        objAssesseeMainDEN.PEInIndia = 0;
        objAssesseeMainDEN.EMail = txtEmail.Text;
        objAssesseeBLL.InsertDataGeneral(objAssesseeMainDEN);

        //ddlStatus.SelectedIndex = 0;
        //txtPAN.Text = "";
        txtNameCOOP.Text = "";
        txtTANCOOP.Text = "";
        txtDateCOOP.Text = "";
        txtWardCOOP.Text = "";
        ddlResCOOP.SelectedIndex = 0;
        ddlBussNatureCOOP.SelectedIndex = 0;
        txtEmail.Text = "";
        
        
    }

    void InsertAddress()
    {
        try
        {
           
                denAddress objAddressDEN;
                bllAddress objAddressBLL;
                objAddressDEN = new denAddress();
                objAddressBLL = new bllAddress();
                objAddressDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
                objAddressDEN.NameID = Convert.ToString(Session["PAN"]);
                objAddressDEN.Flat = txtFlat.Text;
                objAddressDEN.Road = txtRoad.Text;
                objAddressDEN.City = txtCity.Text;
                objAddressDEN.PIN = txtPIN.Text;
                objAddressDEN.Premises = txtPremises.Text;
                objAddressDEN.Area = txtArea.Text;
                objAddressDEN.State = ddlState.SelectedValue;
                string stateName = ddlState.Items[ddlState.SelectedIndex].Text;
                objAddressDEN.Address = objAddressDEN.Flat + "," + objAddressDEN.Premises + "," + objAddressDEN.Road + "," + objAddressDEN.Area + "," + objAddressDEN.City + "," + stateName + "," + objAddressDEN.PIN;
                objAddressDEN.STDCODE = txtSTD.Text;
                objAddressDEN.PhoneNo = txtPhone.Text;
                
                
                objAddressBLL.InsertAddress(objAddressDEN);
                txtFlat.Text = "";
                txtRoad.Text = "";
                txtCity.Text = "";
                txtPIN.Text = "";
                txtPremises.Text = "";
                txtArea.Text = "";
                txtSTD.Text = "";
                txtPhone.Text = "";
                       
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void UpdateAddress()
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
        objAddressDEN1.STDCODE = txtSTD.Text;
        objAddressDEN1.PhoneNo = txtPhone.Text;
        string stateName = ddlState.Items[ddlState.SelectedIndex].Text;
        objAddressDEN1.Address = objAddressDEN1.Flat + "," + objAddressDEN1.Premises + "," + objAddressDEN1.Road + "," + objAddressDEN1.Area + "," + objAddressDEN1.City + "," + stateName + "," + objAddressDEN1.PIN;
        bllAddress objAddressBLL = new bllAddress();
        objAddressBLL.UpdateAddress(objAddressDEN1);

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
            //if (Convert.ToString(Session["CopyPAN"]) == "")
            //    btnOK.Enabled = true;
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
            bllAssessee objAssesseeBLL = new bllAssessee();
            denAssesseeMain objAssesseeMainDEN = new denAssesseeMain();
            objAssesseeMainDEN = objAssesseeBLL.GetDataGeneral(PAN);
            txtNameCOOP.Text = objAssesseeMainDEN.LastName;
            txtDateCOOP.Text = objAssesseeMainDEN.DateofBirth;
            txtWardCOOP.Text = objAssesseeMainDEN.WardCircle;
            txtTANCOOP.Text = objAssesseeMainDEN.TANNO;
            ddlResCOOP.SelectedIndex = objAssesseeMainDEN.ResStatus;
            txtEmail.Text = objAssesseeMainDEN.EMail;
            ddlBussNatureCOOP.SelectedValue = objAssesseeMainDEN.BussNature;
            txtSTD.Text = objAssesseeMainDEN.STDCODE;
            txtPhone.Text = objAssesseeMainDEN.PhoneNo;

            DateTime dtime = new DateTime();
            dtime = Convert.ToDateTime(objAssesseeMainDEN.DateofBirth);
            txtDateCOOP.Text = dtime.Year.ToString() + "-" + ((dtime.Month.ToString().Length == 1) ? ("0" + dtime.Month.ToString()) : dtime.Month.ToString()) + "-" + ((dtime.Day.ToString().Length == 1) ? ("0" + dtime.Day.ToString()) : dtime.Day.ToString());


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void GetRepresentativeDetails(string NameID)
    {
        try
        {
            denDocTrans objDocTransDEN = new denDocTrans();
            bllDocTrans objDocTransBLL = new bllDocTrans();
            objDocTransDEN = objDocTransBLL.GetRepresentativeDetails(NameID);
            txtNameRep.Text = objDocTransDEN.Name;
            txtDesignationRep.Text = objDocTransDEN.Designation;
            txtPANRep.Text = objDocTransDEN.PAN;
            txtPlaceRep.Text = objDocTransDEN.Place;
            txtFlatRep.Text = objDocTransDEN.Flat;
            txtPremisesRep.Text = objDocTransDEN.Premises;
            txtRoadRep.Text = objDocTransDEN.Road;
            txtAreaRep.Text = objDocTransDEN.Area;
            txtCityRep.Text = objDocTransDEN.City;
            ddlStatesRep.SelectedIndex = objDocTransDEN.State;
            txtPINRep.Text = objDocTransDEN.PIN;
            txtNameAu.Text = objDocTransDEN.Auth_Name;
            //txtFNameAu.Text = objDocTransDEN.Auth_Father_Name;
            txtDesignationAu.Text = objDocTransDEN.Auth_Desig;
            txtPlaceAu.Text = objDocTransDEN.Auth_Place;
            txtDateAu.Text = objDocTransDEN.FilingDate;
            txtWardAu.Text = objDocTransDEN.WardCircle;
            if (objDocTransDEN.RepAssessee == 0)
            {
                rdoSelf.Checked = true;
                pnlAuthorised.Visible = true;
            }
            else if (objDocTransDEN.RepAssessee == 1)
            {
                rdoRepresentative.Checked = true;
                pnlRepresentative.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void UpdateRepresentativeDetails()
    {
        try
        {
            bllDocTrans objDocTransBLL = new bllDocTrans();
            denDocTrans objDocTransDEN = new denDocTrans();
            objDocTransDEN.NameID = Convert.ToString(Session["PAN"]);
            objDocTransDEN.Name = txtNameRep.Text;
            objDocTransDEN.PAN = txtPANRep.Text;
            objDocTransDEN.Designation = txtDesignationRep.Text;
            objDocTransDEN.Place = txtPlaceRep.Text;
            objDocTransDEN.Flat = txtFlatRep.Text;
            objDocTransDEN.Premises = txtPremisesRep.Text;
            objDocTransDEN.Road = txtRoadRep.Text;
            objDocTransDEN.Area = txtAreaRep.Text;
            objDocTransDEN.City = txtCityRep.Text;
            objDocTransDEN.State = Convert.ToInt32(ddlStatesRep.SelectedValue);
            objDocTransDEN.PIN = txtPINRep.Text;

            objDocTransBLL.UpdateRepresentativeDetails(objDocTransDEN);


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void UpdateAuthorisedSignatory()
    {
        try
        {
            bllDocTrans objDocTransBLL = new bllDocTrans();
            denDocTrans objDocTransDEN = new denDocTrans();
            objDocTransDEN.NameID = Convert.ToString(Session["PAN"]);
            objDocTransDEN.Auth_Name = txtNameAu.Text;
            objDocTransDEN.Auth_Father_Name = txtFNameAu.Text;
            objDocTransDEN.Auth_Desig = txtDesignationAu.Text;
            objDocTransDEN.Auth_Place = txtPlaceAu.Text;
            objDocTransDEN.FilingDate = txtDateAu.Text;
            objDocTransDEN.WardCircle = txtWardAu.Text;

            objDocTransBLL.UpdateAuthorisedSignatory(objDocTransDEN);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdoRepresentative_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoRepresentative.Checked == true)
        {
            pnlRepresentative.Visible = true;
            pnlAuthorised.Visible = false;
        }

    }
    protected void rdoSelf_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoSelf.Checked == true)
        {
            pnlRepresentative.Visible = false;
            pnlAuthorised.Visible = true;
        }
    }
}
