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

public partial class Presentation_AOP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";
        //lblAssesseeType.Text = "AOP";// Convert.ToString(Session["AssesseeType"]);
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
          selectDataAOP(Convert.ToString(Session["PAN"]));
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
                InsertDataAOP();
                InsertAddress();
            }
            else if (Convert.ToString(Session["Mode"]) == "Edit")
            {
                UpdateDataAOP();
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
    void InsertDataAOP()
    {
        try
        {
            denAssesseeMain objAssesseeMainDEN;
            bllAssessee objAssesseeBLL;
            objAssesseeMainDEN = new denAssesseeMain();
            objAssesseeBLL = new bllAssessee();
            objAssesseeMainDEN.UserName = Convert.ToString(Session["UserName"]);
            objAssesseeMainDEN.Status = Convert.ToInt32(Session["Status"]);
            objAssesseeMainDEN.PANNO = Convert.ToString(Session["PAN"]);
            objAssesseeMainDEN.LastName = txtNameAOP.Text;
            objAssesseeMainDEN.TANNO = txtTANAOP.Text;
            objAssesseeMainDEN.DateofBirth = txtDateAOP.Text;
            objAssesseeMainDEN.WardCircle = txtWardAOP.Text;
            objAssesseeMainDEN.ResStatus = ddlResAOP.SelectedIndex;
            objAssesseeMainDEN.BussNature = ddlBussAOP.SelectedValue;
            objAssesseeMainDEN.PEOutIndia = 0;
            objAssesseeMainDEN.PEInIndia = 0;
            objAssesseeMainDEN.EMail = txtEmail.Text;
            objAssesseeBLL.InsertDataGeneral(objAssesseeMainDEN);

            //ddlStatus.SelectedIndex = 0;
            //txtPAN.Text = "";
            txtNameAOP.Text = "";
            txtTANAOP.Text = "";
            txtDateAOP.Text = "";
            txtWardAOP.Text = "";
            ddlResAOP.SelectedIndex = 0;
            ddlBussAOP.SelectedIndex = 0;
            txtEmail.Text = "";
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
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

            ddBusiness.SelectedValue = (objDocTransDEN.Business_Nature1 != 0) ? objDocTransDEN.Business_Nature1.ToString() : "0";
            ddBusiness2.SelectedValue = (objDocTransDEN.Business_Nature2 != 0) ? objDocTransDEN.Business_Nature2.ToString() : "0";
            ddBusiness3.SelectedValue = (objDocTransDEN.Business_Nature3 != 0) ? objDocTransDEN.Business_Nature3.ToString() : "0";

            if (ddBusiness.SelectedValue != "0")
            {
                txtTrade1.Attributes.Remove("disabled");
                txtTrade2.Attributes.Remove("disabled");
                txtTrade3.Attributes.Remove("disabled");

                txtTrade1.Text = objDocTransDEN.Business1_Trade1;
                txtTrade2.Text = objDocTransDEN.Business1_Trade2;
                txtTrade3.Text = objDocTransDEN.Business1_Trade3;
            }
            if (ddBusiness2.SelectedValue != "0")
            {
                txtTrade11.Attributes.Remove("disabled");
                txtTrade22.Attributes.Remove("disabled");
                txtTrade33.Attributes.Remove("disabled");

                txtTrade11.Text = objDocTransDEN.Business2_Trade1;
                txtTrade22.Text = objDocTransDEN.Business2_Trade2;
                txtTrade33.Text = objDocTransDEN.Business2_Trade3;
            }
            if (ddBusiness3.SelectedValue != "0")
            {
                txtTrade111.Attributes.Remove("disabled");
                txtTrade222.Attributes.Remove("disabled");
                txtTrade333.Attributes.Remove("disabled");

                txtTrade111.Text = objDocTransDEN.Business3_Trade1;
                txtTrade222.Text = objDocTransDEN.Business3_Trade2;
                txtTrade333.Text = objDocTransDEN.Business3_Trade3;
            }
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
            objDocTransDEN.BankNAme = txtBankName.Text;

            objDocTransDEN.Business_Nature1 = (ddBusiness.SelectedValue != "0") ? Convert.ToInt64(ddBusiness.SelectedValue) : 0;
            objDocTransDEN.Business_Nature2 = (ddBusiness2.SelectedValue != "0") ? Convert.ToInt64(ddBusiness2.SelectedValue) : 0;
            objDocTransDEN.Business_Nature3 = (ddBusiness3.SelectedValue != "0") ? Convert.ToInt64(ddBusiness3.SelectedValue) : 0;

            objDocTransDEN.Business1_Trade1 = txtTrade1.Text;
            objDocTransDEN.Business1_Trade2 = txtTrade2.Text;
            objDocTransDEN.Business1_Trade3 = txtTrade3.Text;

            objDocTransDEN.Business2_Trade1 = txtTrade11.Text;
            objDocTransDEN.Business2_Trade2 = txtTrade22.Text;
            objDocTransDEN.Business2_Trade3 = txtTrade33.Text;

            objDocTransDEN.Business3_Trade1 = txtTrade111.Text;
            objDocTransDEN.Business3_Trade2 = txtTrade222.Text;
            objDocTransDEN.Business3_Trade3 = txtTrade333.Text;

            objDocTransBLL.UpdateBankDetails(objDocTransDEN);



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void UpdateDataAOP()
    {
        try
        {
            denAssesseeMain objAssesseeMainDEN;
            bllAssessee objAssesseeBLL;
            objAssesseeMainDEN = new denAssesseeMain();
            objAssesseeBLL = new bllAssessee();
            //objAssesseeMainDEN.Status = ddlStatus.SelectedIndex;
            objAssesseeMainDEN.PANNO = Convert.ToString(Session["PAN"]);
            objAssesseeMainDEN.LastName = txtNameAOP.Text;
            objAssesseeMainDEN.TANNO = txtTANAOP.Text;
            objAssesseeMainDEN.DateofBirth = txtDateAOP.Text;
            objAssesseeMainDEN.WardCircle = txtWardAOP.Text;
            objAssesseeMainDEN.Status = 5;
            objAssesseeMainDEN.ResStatus = ddlResAOP.SelectedIndex;
            objAssesseeMainDEN.BussNature = ddlBussAOP.SelectedValue;
            objAssesseeMainDEN.PEOutIndia = 0;
            objAssesseeMainDEN.PEInIndia = 0;
            objAssesseeMainDEN.EMail = txtEmail.Text;
            objAssesseeBLL.UpdateDataGeneral(objAssesseeMainDEN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }
    protected void InsertAddress()
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
            objAddressDEN.mobile1 = txtMobile1.Text;
            objAddressDEN.mobile2 = txtMobile2.Text;
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
        objAddressDEN1.mobile1 = txtPhone.Text;
        objAddressDEN1.mobile2 = "";
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
    void selectDataAOP(string PAN)
    {
        try
        {
            bllAssessee objAssesseeDAL = new bllAssessee();
            denAssesseeMain objAssesseeMainDEN = new denAssesseeMain();
            objAssesseeMainDEN = objAssesseeDAL.GetDataGeneral(PAN);
            
            txtNameAOP.Text = objAssesseeMainDEN.LastName;
            DateTime dtime = new DateTime();
            dtime = Convert.ToDateTime(objAssesseeMainDEN.DateofBirth);
            txtDateAOP.Text = dtime.Year.ToString() + "-" + ((dtime.Month.ToString().Length == 1) ? ("0" + dtime.Month.ToString()) : dtime.Month.ToString()) + "-" + ((dtime.Day.ToString().Length == 1) ? ("0" + dtime.Day.ToString()) : dtime.Day.ToString());

            //txtDateAOP.Text = objAssesseeMainDEN.DateofBirth;
            txtWardAOP.Text = objAssesseeMainDEN.WardCircle;
            txtTANAOP.Text = objAssesseeMainDEN.TANNO;
            ddlResAOP.SelectedIndex = objAssesseeMainDEN.ResStatus;
            txtEmail.Text = objAssesseeMainDEN.EMail;
            ddlBussAOP.SelectedValue = objAssesseeMainDEN.BussNature;
            txtSTD.Text = objAssesseeMainDEN.STDCODE;
            txtPhone.Text = objAssesseeMainDEN.PhoneNo;
            

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
