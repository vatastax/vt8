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
using System.Globalization;

public partial class Presentation_IndividualUser : System.Web.UI.Page
{
    bllAssessee objAssesseeBLL;
    static string[] Formats = null;
    static DataTable table = new DataTable();
    static DataTable dtBank;
   static int ID;
   static int grdIndx = 0;
   static string Searchbank = "";
   static int BankID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Auto Redirect on Session Out
        int reason = 0;
        if (!common.IsLoggedIn(out reason))
        {
            if (reason == 1)
            {
                Session["reason_logout"] = "suspecious_attempt";
            }
            Response.Redirect("Logout.aspx");
        }
        if (Session["project"].ToString() == "vt")
        {
            Page.Title = "Income Tax Return";
        }
        else if (Session["project"].ToString() == "tds")
        {
            Page.Title = "TDS";
        }
        ViewState["vtype"] = 30;
        hdnAY.Value = "2015-2016";// Session["AY"].ToString();
        //lblAssesseeType.Text = Convert.ToString(Session["AssesseeType"]);
        //lblPan.Text = Convert.ToString(Session["PAN"]);
        if (!IsPostBack)
        {
            hdnIsBank.Value = "none";
            if (Session["Mode"].ToString() == "Edit")
            {
                //objAssesseeBLL = new bllAssessee();
                ////DataTable dt=new DataTable
                //dtBank = new DataTable();
                //dtBank = objAssesseeBLL.GetBankDetail(Session["PAN"].ToString()).Copy();
                //grdBank.DataSource = dtBank;
                //grdBank.DataBind();
                hdnIsBank.Value = "Bank";
                bindgrdBank1();
            }
            //else
            //{
            //    dtBank = new DataTable();
            //}
            //dtBank.Rows.Clear();
            //dtBank.Columns.Clear();
            //if (Session["Mode"] == "New")
            //{
            //    table.Clear();
            //    table.Columns.Clear();
            //    table.Columns.Add("BankID", typeof(int));
            //    table.Columns.Add("BankName", typeof(string));
            //    table.Columns.Add("Address", typeof(string));
            //    table.Columns.Add("AccountNo", typeof(string));
            //    table.Columns.Add("AccountType", typeof(string));
            //    table.Columns.Add("IFSCCode", typeof(string));
            //}
           
            ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";
            DataTable dtCountr = new DataTable();
            balCountry objbalCountry = new balCountry();
            dtCountr = objbalCountry.Select();
            ddlCountry.DataSource = dtCountr;
            ddlCountry.DataBind();
            bllStates objbllStates = new bllStates();
            System.Collections.Generic.List<denStates> LstStates = new System.Collections.Generic.List<denStates>();
            LstStates = objbllStates.getStates();
            ddlState.DataSource = LstStates;
            ddlState.DataBind();

            Int32 indx = 0;
            for (int i = 0; i < LstStates.Count; i++)
            {
                if (LstStates[i].StateName.Trim() == "Punjab")
                    indx = i;
            }
            ddlState.SelectedIndex = indx;
            indx = 0;
            for (int i = 0; i < dtCountr.Rows.Count; i++)
            {
                if (dtCountr.Rows[i]["Country_Name"].ToString().Trim() == "India")
                    indx = i;
            }
            ddlCountry.SelectedIndex = indx;

            objAssesseeBLL = new bllAssessee();
            DataTable dtBC = new DataTable();
            dtBC = objAssesseeBLL.SelectBusinessCategories();

            //ddBusiness.DataSource = dtBC;
            //ddBusiness.DataTextField = "title";
            //ddBusiness.DataValueField = "id";
            //ddBusiness.DataBind();
            ListItem lstFirst = new ListItem(" -- Select -- ", "0");
            //ddBusiness.Items.Insert(0, lstFirst);

            //ddBusiness2.DataSource = dtBC;
            //ddBusiness2.DataTextField = "title";
            //ddBusiness2.DataValueField = "id";
            //ddBusiness2.DataBind();
            //ddBusiness2.Items.Insert(0, lstFirst);

            //ddBusiness3.DataSource = dtBC;
            //ddBusiness3.DataTextField = "title";
            //ddBusiness3.DataValueField = "id";
            //ddBusiness3.DataBind();
            //ddBusiness3.Items.Insert(0, lstFirst);
            if (Session["PAN"] != null)
            {
                SelectDataIndividual(Convert.ToString(Session["PAN"]));
                GetAddress(Convert.ToString(Session["PAN"]));
                GetBankDetails(Convert.ToString(Session["PAN"]));
                GetRepresentativeDetails(Convert.ToString(Session["PAN"]));
                txtPANRep.Text = Session["PAN"].ToString();
            }
        }
    }

    void InsertDataIndividual()
    {
        denAssesseeIndividual objAssesseeDEN;
        
        objAssesseeDEN = new denAssesseeIndividual();
        objAssesseeBLL = new bllAssessee();
        objAssesseeDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
        objAssesseeDEN.UserName = Convert.ToString(Session["UserName"]);
        objAssesseeDEN.Status = Convert.ToInt32(Session["Status"]) ;
        objAssesseeDEN.PANNO = (Session["PAN"] != null) ? Convert.ToString(Session["PAN"]) : txtPANRep.Text;
        objAssesseeDEN.Salute = ddlSalute.SelectedIndex;
        objAssesseeDEN.LastName = txtLastName.Text;
        objAssesseeDEN.MiddleName = txtMiddleName.Text;
        objAssesseeDEN.FirstName = txtFirstName.Text;
        objAssesseeDEN.FatherName = txtFatherName.Text;
        objAssesseeDEN.TANNO = "";// txtTAN.Text;
        DateTime dTime = new DateTime();

        DateTime dd = new DateTime();

        string ShortFormat = "yyyy-MM-dd";
        string LongFormat = "yyyy-dd-MM";
        Formats = new string[8] { ShortFormat, LongFormat, "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd", "yyyy/dd/MM", "dd-MM-yyyy", "MM-dd-yyyy" };

        dd = Convert.ToDateTime(Parse(txtDOB.Text));


        dTime = dd;// Convert.ToDateTime(txtDOB.Text);


        objAssesseeDEN.DateofBirth = txtDOB.Text;// dTime.Day.ToString() + "/" + dTime.Month.ToString() + "/" + dTime.Year.ToString();  //txtDOB.Text;
        objAssesseeDEN.ResStatus = ddlResStatus.SelectedIndex;
        objAssesseeDEN.TypeofAss = 0;// ddlAssesseeType.SelectedIndex;
        objAssesseeDEN.EMail = txtEmail.Text;
        objAssesseeDEN.WardCircle = txtWard.Text;
        objAssesseeDEN.BussNature = "";// ddlBussNature.SelectedValue;
        objAssesseeDEN.PEOutIndia = 0;
        objAssesseeDEN.PEInIndia = 0;
        objAssesseeDEN.no_of_dependents = 0;
        objAssesseeDEN.AdhaarNo = txtAadhar.Text;
        objAssesseeBLL.InsertNameMastIndividual(objAssesseeDEN);
        //ddlStatus.SelectedIndex = 0;
        
        ddlSalute.SelectedIndex = 0;
        txtLastName.Text = "";
        txtMiddleName.Text = "";
        txtFirstName.Text = "";
        txtFatherName.Text = "";
        //txtTAN.Text = "";
        txtDOB.Text = "";
        ddlResStatus.SelectedIndex = 0;
        //ddlAssesseeType.SelectedIndex = 0;
        txtEmail.Text = "";
        txtWard.Text = "";
        //ddlBussNature.SelectedIndex = 0;
        //txtSTD.Text = "";
        //txtPhone.Text = "";
    }

    static string Parse(string text)
    {
        string strDate = "";
        // Adjust styles as per requirements
        DateTime result = DateTime.ParseExact(text, Formats,
                                              CultureInfo.InvariantCulture,
                                              DateTimeStyles.AssumeUniversal);
        strDate = result.ToShortDateString();
        return strDate;
    }

    void SelectDataIndividual(string PAN)
    {
        try
        {
            dalAssessee objAssesseeDAL = new dalAssessee();
            denAssesseeIndividual objAssesseeIndividualDEN = new denAssesseeIndividual();
            objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(PAN, Convert.ToString(Session["UserName"]));
            //txtPAN.Text = objAssesseeIndividualDEN.PANNO;
            if (objAssesseeIndividualDEN.DateofBirth != null)
            {
                hdnNew.Value = "false";
                txtLastName.Text = objAssesseeIndividualDEN.LastName;
                txtMiddleName.Text = objAssesseeIndividualDEN.MiddleName;
                txtFirstName.Text = objAssesseeIndividualDEN.FirstName;
                //ddlStatus.SelectedIndex = objAssesseeIndividualDEN.Status;
                ddlSalute.SelectedIndex = objAssesseeIndividualDEN.Salute;
                txtFatherName.Text = objAssesseeIndividualDEN.FatherName;
                txtAadhar.Text = objAssesseeIndividualDEN.AdhaarNo;
                DateTime dtime = new DateTime();

                string ShortFormat = "yyyy-MM-dd";
                string LongFormat = "yyyy-dd-MM";
                Formats = new string[8] { ShortFormat, LongFormat, "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd", "yyyy/dd/MM", "dd-MM-yyyy", "MM-dd-yyyy" };

                dtime = Convert.ToDateTime(Parse(objAssesseeIndividualDEN.DateofBirth));

                //dtime = Convert.ToDateTime(objAssesseeIndividualDEN.DateofBirth);

               // txtdob_MaskedEditExtender.Enabled = false;
                txtDOB.Text = objAssesseeIndividualDEN.DateofBirth;// ((dtime.Day.ToString().Length == 1) ? ("0" + dtime.Day.ToString()) : dtime.Day.ToString()) + ((dtime.Month.ToString().Length == 1) ? ("0" + dtime.Month.ToString()) : dtime.Month.ToString()) + dtime.Year.ToString();
                //txtdob_MaskedEditExtender.Enabled = true;
                txtWard.Text = objAssesseeIndividualDEN.WardCircle;
                //txtTAN.Text = objAssesseeIndividualDEN.TANNO;
                ddlResStatus.SelectedIndex = objAssesseeIndividualDEN.ResStatus;
                txtEmail.Text = objAssesseeIndividualDEN.EMail;
                //ddlBussNature.SelectedValue = objAssesseeIndividualDEN.BussNature;
                txtSTD.Text = objAssesseeIndividualDEN.STDCODE;
                txtPhone.Text = objAssesseeIndividualDEN.PhoneNo;
            }
            //txtAddress.Text = objAssesseeIndividualDEN.Address;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void UpdateDataIndividual()
    {
        denAssesseeIndividual objAssesseeDEN;
        
        objAssesseeDEN = new denAssesseeIndividual();
        objAssesseeBLL = new bllAssessee();

        //objAssesseeDEN.Status = ddlStatus.SelectedIndex;
        objAssesseeDEN.PANNO = Convert.ToString(Session["PAN"]);
        objAssesseeDEN.Salute = ddlSalute.SelectedIndex;
        objAssesseeDEN.LastName = txtLastName.Text;
        objAssesseeDEN.MiddleName = txtMiddleName.Text;
        objAssesseeDEN.FirstName = txtFirstName.Text;
        objAssesseeDEN.FatherName = txtFatherName.Text;
        objAssesseeDEN.TANNO = "";// txtTAN.Text;
        objAssesseeDEN.DateofBirth = txtDOB.Text;
        objAssesseeDEN.ResStatus = ddlResStatus.SelectedIndex;
        objAssesseeDEN.TypeofAss = 0;// ddlAssesseeType.SelectedIndex;
        objAssesseeDEN.EMail = txtEmail.Text;
        objAssesseeDEN.WardCircle = txtWard.Text;
        objAssesseeDEN.BussNature = "";// ddlBussNature.SelectedValue;
        objAssesseeDEN.PEOutIndia = 0;
        objAssesseeDEN.PEInIndia = 0;
       // objAssesseeDEN.no_of_dependents = (txtNoOfDependents.Text == "") ? 0 : Convert.ToInt32(txtNoOfDependents.Text);
        objAssesseeDEN.AdhaarNo = txtAadhar.Text;
        objAssesseeBLL.UpdateDataIndividual(objAssesseeDEN);
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
            objAddressDEN.NameID = (Session["PAN"] != null) ? Convert.ToString(Session["PAN"]) : txtPANRep.Text;
            objAddressDEN.Flat = txtFlat.Text;
            objAddressDEN.Road = txtRoad.Text;
            objAddressDEN.City = txtCity.Text;
            objAddressDEN.PIN = txtPIN.Text;
            objAddressDEN.Premises = txtPremises.Text;
            objAddressDEN.Area = txtArea.Text;
            objAddressDEN.State = ddlState.SelectedValue;
            objAddressDEN.Country = ddlCountry.SelectedValue;
            
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

    protected void txtDOB_TextChanged(object sender, EventArgs e)
    {
        string date = txtDOB.Text;
        DateTime str = Convert.ToDateTime(date);
        string strc = str.ToShortDateString();
        txtDOB.Text = strc;
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
            txtMobile1.Text = objAddressDEN.mobile1;
            txtMobile2.Text = objAddressDEN.mobile2;
            //if (Convert.ToString(Session["CopyPAN"]) == "")
            //    btnOK.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }   
    //cancel button Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Presentation/Main.aspx");
    }
    //Save Button Click
    protected void Button1_Click1(object sender, EventArgs e)
    {
        DateTime dtime = new DateTime();

        DateTime dd = new DateTime();

        string ShortFormat = "yyyy-MM-dd";
        string LongFormat = "yyyy-dd-MM";
        Formats = new string[8] { ShortFormat, LongFormat, "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd", "yyyy/dd/MM", "dd-MM-yyyy", "MM-dd-yyyy" };

       // dd = Convert.ToDateTime(Parse(txtDOB.Text));


        dtime = Convert.ToDateTime(Parse(txtDOB.Text));
        DateTime dt2 = new DateTime(2015, 03, 31);
        if (dtime > dt2)
        {
            lblMessage.Text = "Please Enter a Valid Date of Birth";
            ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('Enter a Valid Date'); </script>");
        }
        else
        {
            if (Page.IsValid && grdBank.Rows.Count > 0)
            {
                if (Convert.ToString(Session["Mode"]) == "New")
                {
                    denDocTrans objDocTransDEN = new denDocTrans();
                    objDocTransDEN.NameID = Convert.ToString(Session["PAN"]);

                    objDocTransDEN.ReturnType = "Original";
                    objDocTransDEN.RecieptNo = "";
                    objDocTransDEN.FilingDate = "";
                    objDocTransDEN.FBTFileSection = 0;
                    objDocTransDEN.ReturnFiledUS = 0;
                    objDocTransDEN.IncomeFileSection = "";
                    objDocTransDEN.FirstReturn = 0;
                    objDocTransDEN.State = Convert.ToInt32(ddlState.SelectedValue);
                    objDocTransDEN.username = Convert.ToString(Session["UserName"]);
                    objDocTransDEN.STC_CodeNumber = (Session["STCNo"] != null) ? Session["STCNo"].ToString() : "";

                    InsertMiscInfo(objDocTransDEN);
                    InsertDataIndividual();
                    InsertAddress();
                    lblMessage.Text = "New Assessee has been successfully created!!";
                }
                else if (Convert.ToString(Session["Mode"]) == "Edit")
                {
                    hdnIsBank.Value = "";
                    UpdateDataIndividual();
                    UpdateAddress();
                    lblMessage.Text = "Assessee Information has been successfully updated";
                }
                UpdateBankDetails();
                //if (rdoRepresentative.Checked == true)
                //{
                UpdateRepresentativeDetails();
                //}
                //if (rdoSelf.Checked == true)
                //{
                //    UpdateAuthorisedSignatory();
                //}
                objAssesseeBLL = new bllAssessee();
                if (Session["PAN"] != null)
                {
                    string AccType = "";
                    //objAssesseeBLL.DeleteFromBankmast(Session["PAN"].ToString());
                    for (int i = 0; i < grdBank.Rows.Count; i++)
                    {
                        if (grdBank.Rows[i].Cells[4].Text.ToString() == "Savings")
                            AccType = "2";
                        else
                            AccType = "3";
                        //objAssesseeBLL.InsertBankMastData(Session["PAN"].ToString(), grdBank.Rows[i].Cells[1].Text.ToString(), grdBank.Rows[i].Cells[2].Text.ToString(), AccType, grdBank.Rows[i].Cells[3].Text.ToString(), grdBank.Rows[i].Cells[5].Text.ToString());
                        objAssesseeBLL.UpdateBankMast(Session["User_ID"].ToString(), Session["PAN"].ToString());
                    }
                }

                lblMessage.Visible = true;
                
                //nishu 10/4/2015

                if (Session["UploadForm16Details"] != null)
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + "Information Added/Updated Successfully" + "');window.location='UploadForm16.aspx';", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + lblMessage.Text + "');", true);
                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + "Information Added/Updated Successfully" + "');window.location='Main.aspx';", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + lblMessage.Text + "');", true);
                }
                ClearControls();
                //dtBank.Rows.Clear();
                grdBank.DataSource = "";
                grdBank.DataBind();
            }
            else
            {

                lblMessage.Visible = true;
                lblMessage.Text = "Please Enter All the Values";

            }

        }
    }

    private void ClearControls()
    {
        foreach (Control c in Page.Controls)
        {
            foreach (Control ctrl in c.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
            }
        }
    } 

    protected Int32 InsertMiscInfo(denDocTrans objDocTransDEN)
    {
        Int32 IsExists;
        try
        {
            bllDocTrans objDocTransBLL;
            objDocTransBLL = new bllDocTrans();
            objDocTransBLL.InsertMiscDetails(objDocTransDEN, out IsExists);
            return IsExists;
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
        objAddressDEN1.mobile1 = txtMobile1.Text;
        objAddressDEN1.mobile2 = txtMobile2.Text;
        objAddressDEN1.State = ddlState.SelectedValue;
        objAddressDEN1.STDCODE = txtSTD.Text;
        objAddressDEN1.PhoneNo = txtPhone.Text;
        string stateName = ddlState.Items[ddlState.SelectedIndex].Text;
        objAddressDEN1.Address = objAddressDEN1.Flat + "," + objAddressDEN1.Premises + "," + objAddressDEN1.Road + "," + objAddressDEN1.Area + "," + objAddressDEN1.City + "," + stateName + "," + objAddressDEN1.PIN;
        bllAddress objAddressBLL = new bllAddress();
        objAddressBLL.UpdateAddress(objAddressDEN1);

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
            //other info code
            //ddBusiness.SelectedValue = (objDocTransDEN.Business_Nature1 != 0) ? objDocTransDEN.Business_Nature1.ToString() : "0";
            //ddBusiness2.SelectedValue = (objDocTransDEN.Business_Nature2 != 0) ? objDocTransDEN.Business_Nature2.ToString() : "0";
            //ddBusiness3.SelectedValue = (objDocTransDEN.Business_Nature3 != 0) ? objDocTransDEN.Business_Nature3.ToString() : "0";

            //if (ddBusiness.SelectedValue != "0")
            //{
            //    txtTrade1.Attributes.Remove("disabled");
            //    txtTrade2.Attributes.Remove("disabled");
            //    txtTrade3.Attributes.Remove("disabled");

            //    txtTrade1.Text = objDocTransDEN.Business1_Trade1;
            //    txtTrade2.Text = objDocTransDEN.Business1_Trade2;
            //    txtTrade3.Text = objDocTransDEN.Business1_Trade3;
            //}
            //if (ddBusiness2.SelectedValue != "0")
            //{
            //    txtTrade11.Attributes.Remove("disabled");
            //    txtTrade22.Attributes.Remove("disabled");
            //    txtTrade33.Attributes.Remove("disabled");

            //    txtTrade11.Text = objDocTransDEN.Business2_Trade1;
            //    txtTrade22.Text = objDocTransDEN.Business2_Trade2;
            //    txtTrade33.Text = objDocTransDEN.Business2_Trade3;
            //}
            //if (ddBusiness3.SelectedValue != "0")
            //{
            //    txtTrade111.Attributes.Remove("disabled");
            //    txtTrade222.Attributes.Remove("disabled");
            //    txtTrade333.Attributes.Remove("disabled");

            //    txtTrade111.Text = objDocTransDEN.Business3_Trade1;
            //    txtTrade222.Text = objDocTransDEN.Business3_Trade2;
            //    txtTrade333.Text = objDocTransDEN.Business3_Trade3;
            //}

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
            objDocTransDEN.BankNAme = txtBankName.Text;
            objDocTransDEN.MICRCode = txtMICR.Text.ToUpper();
            objDocTransDEN.AccountNumber = txtAccountNumber.Text;
            objDocTransDEN.AddressofBranch = txtBranchAddress.Text;
            objDocTransDEN.ECS = ddlESC.SelectedValue;
            objDocTransDEN.RefundMethod = ddlRefund.SelectedValue;
            //other info code
            objDocTransDEN.Business_Nature1 = 0;// (ddBusiness.SelectedValue != "0") ? Convert.ToInt64(ddBusiness.SelectedValue) : 0;
            objDocTransDEN.Business_Nature2 = 0;// (ddBusiness2.SelectedValue != "0") ? Convert.ToInt64(ddBusiness2.SelectedValue) : 0;
            objDocTransDEN.Business_Nature3 = 0;// (ddBusiness3.SelectedValue != "0") ? Convert.ToInt64(ddBusiness3.SelectedValue) : 0;

            objDocTransDEN.Business1_Trade1 = "";// txtTrade1.Text;
            objDocTransDEN.Business1_Trade2 = "";// txtTrade2.Text;
            objDocTransDEN.Business1_Trade3 = "";// txtTrade3.Text;

            objDocTransDEN.Business2_Trade1 = "";// txtTrade11.Text;
            objDocTransDEN.Business2_Trade2 = "";// txtTrade22.Text;
            objDocTransDEN.Business2_Trade3 = "";// txtTrade33.Text;

            objDocTransDEN.Business3_Trade1 = "";// txtTrade111.Text;
            objDocTransDEN.Business3_Trade2 = "";// txtTrade222.Text;
            objDocTransDEN.Business3_Trade3 = "";// txtTrade333.Text;
            objDocTransBLL.UpdateBankDetails(objDocTransDEN);
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
            txtFNameAu.Text = objDocTransDEN.Auth_Father_Name;
            //txtPlaceRep.Text = objDocTransDEN.Place;
            //txtFlatRep.Text = objDocTransDEN.Flat;
            //txtPremisesRep.Text = objDocTransDEN.Premises;
            //txtRoadRep.Text = objDocTransDEN.Road;
            //txtAreaRep.Text = objDocTransDEN.Area;
            //txtCityRep.Text = objDocTransDEN.City;
            //ddlStatesRep.SelectedIndex = objDocTransDEN.State;
            //txtPINRep.Text = objDocTransDEN.PIN;
            //txtNameAu.Text = objDocTransDEN.Auth_Name;
            //txtFNameAu.Text = objDocTransDEN.Auth_Father_Name;
            //txtDesignationAu.Text = objDocTransDEN.Auth_Desig;
            //txtPlaceAu.Text = objDocTransDEN.Auth_Place;
            ////txtDateAu.Text = objDocTransDEN.FilingDate;
            //txtWardAu.Text = objDocTransDEN.WardCircle;
            //if (objDocTransDEN.RepAssessee == 0)
            //{
            //    rdoSelf.Checked = true;
            //    //pnlAuthorised.Visible = true;
            //}
            //else if (objDocTransDEN.RepAssessee == 1)
            //{
            //    rdoRepresentative.Checked = true;
            //    //pnlRepresentative.Visible = true;
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
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
            objDocTransDEN.Auth_Father_Name = txtFNameAu.Text;



            objDocTransDEN.Place = "";// txtPlaceRep.Text;
            objDocTransDEN.Flat = "";//txtFlatRep.Text;
            objDocTransDEN.Premises = "";//txtPremisesRep.Text;
            objDocTransDEN.Road = "";//txtRoadRep.Text;
            objDocTransDEN.Area = "";//txtAreaRep.Text;
            objDocTransDEN.City = "";//txtCityRep.Text;
            objDocTransDEN.State = Convert.ToInt32(ddlState.SelectedValue);// Convert.ToInt32(ddlStatesRep.SelectedValue);
            objDocTransDEN.PIN = "";//txtPINRep.Text;
            objDocTransDEN.FilingDate = DateTime.Now.ToShortDateString();
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
            //objDocTransDEN.Auth_Name = txtNameAu.Text;
            objDocTransDEN.Auth_Father_Name = txtFNameAu.Text;
            //objDocTransDEN.Auth_Desig = txtDesignationAu.Text;
            //objDocTransDEN.Auth_Place = txtPlaceAu.Text;
            objDocTransDEN.FilingDate = "";// txtDateAu.Text;
            //objDocTransDEN.WardCircle = txtWardAu.Text;

            objDocTransBLL.UpdateAuthorisedSignatory(objDocTransDEN);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rdoRepresentative_CheckedChanged(object sender, EventArgs e)
    {
        //if (rdoRepresentative.Checked == true)
        //{
        //    //pnlRepresentative.Visible = true;
        //    //pnlAuthorised.Visible = false;
        //}

    }

    protected void rdoSelf_CheckedChanged(object sender, EventArgs e)
    {
        //if (rdoSelf.Checked == true)
        //{
        //    //pnlRepresentative.Visible = false;
        //    //pnlAuthorised.Visible = true;
        //}
    }
    protected void rdoRepresentative_CheckedChanged1(object sender, EventArgs e)
    {
        //if (rdoRepresentative.Checked == true)
        //if(ddSignType.SelectedValue=="2")
        //{
        //    txtNameRep.Enabled = true;
        //    txtFNameAu.Enabled = true;
        //    txtPANRep.Enabled = true;
        //    txtDesignationRep.Enabled = true;
        //    RequiredFieldValidator11.Visible = true;
        //}
    }

    protected void ddSignType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddSignType.SelectedValue == "2")
        {
            txtNameRep.Enabled = true;
            txtFNameAu.Enabled = true;
            txtPANRep.Enabled = true;
            txtDesignationRep.Enabled = true;
            //RequiredFieldValidator11.Visible = true;
        }
        else
        {
            txtNameRep.Enabled = false;
            txtFNameAu.Enabled = false;
            txtPANRep.Enabled = false;
            txtDesignationRep.Enabled = false;
            //RequiredFieldValidator11.Visible = false;
        }
    }
    protected void rdoSelf_CheckedChanged1(object sender, EventArgs e)
    {
        //if (rdoSelf.Checked == true)
        //{
        //    txtNameRep.Enabled = false;
        //    txtFNameAu.Enabled = false;
        //    txtPANRep.Enabled = false;
        //    txtDesignationRep.Enabled = false;
        //    RequiredFieldValidator11.Visible = false;
        //}
    }
    //enter aadhar no from user by selection of yes/no from dropdown nishu 26/5/2015
    protected void ddlAadhar_SelectionChanged(object sender, EventArgs e)
    {
        divAadhar.Visible = true;

    }
    //bind details of bank to grid
    public void bindgrdBank()
    {
        objAssesseeBLL = new bllAssessee();
        DataTable dtBankDetail = new DataTable();
        dtBankDetail = objAssesseeBLL.GetBankDetail(Session["User_ID"].ToString()).Copy();
     grdBank.DataSource = dtBankDetail;
     grdBank.DataBind();

        //DataTable table = getTable();
        //grdBank.DataSource = table;
        //grdBank.DataBind();


    }
    //bind bankgrid in case of edit
    public void bindgrdBank1()
    {
        objAssesseeBLL = new bllAssessee();
        DataTable dtBankDetail = new DataTable();
        dtBankDetail = objAssesseeBLL.GetBankDetail(Session["PAN"].ToString()).Copy();
        grdBank.DataSource = dtBankDetail;
        grdBank.DataBind();
    }
    protected void txtMICR_TextChanged(object sender, EventArgs e)
    {
      
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //if (Session["Mode"] == "New")
        //{
        //    bindgrdBank();
        //}
        //else if (Session["Mode"] == "Edit")
        //{
        //    if (objAssesseeBLL == null)
        //        objAssesseeBLL = new bllAssessee();

        //    int Id = objAssesseeBLL.GetID();
        //    if (btnAdd.Text == "Add New")
        //    {
        //        objAssesseeBLL = new bllAssessee();
        //        //dtBank = new DataTable();
                
        //        if (dtBank.Rows.Count < 1)
        //            dtBank = objAssesseeBLL.GetBankDetail(Session["PAN"].ToString()).Copy();

        //        dtBank.Rows.Add(Id + 1, txtBankName.Text, txtBranchAddress.Text, txtAccountNumber.Text, ddlAccountType.SelectedItem.Text, txtMICR.Text.ToUpper());
        //    }
        //    else
        //    {
        //        for (int i = 0; i < dtBank.Rows.Count; i++)
        //        {
        //            if (dtBank.Rows[i]["BankName"].ToString() == Searchbank)
        //            {
        //                dtBank.Rows.RemoveAt(i);
        //            }
        //        }
        //        dtBank.Rows.Add(Id + 1, txtBankName.Text, txtBranchAddress.Text, txtAccountNumber.Text, ddlAccountType.SelectedItem.Text, txtMICR.Text.ToUpper());
        //    }
        //    grdBank.DataSource = dtBank;
        //    grdBank.DataBind();
        //}
        if (Session["Mode"].ToString() == "New")
        {
            if (btnAdd.Text == "Add Account")
            {
                objAssesseeBLL = new bllAssessee();
                objAssesseeBLL.InsertBankMastData(Session["User_ID"].ToString(), txtBankName.Text, txtBranchAddress.Text, ddlAccountType.SelectedValue, txtAccountNumber.Text, txtMICR.Text);
                bindgrdBank();
                hdnIsBank.Value = "Bank";
            }
            else
            {
                objAssesseeBLL = new bllAssessee();
                objAssesseeBLL.UpdateBankMastData(txtBankName.Text, txtBranchAddress.Text, ddlAccountType.SelectedValue, txtAccountNumber.Text, txtMICR.Text, BankID);
                //bindgrdBank1();
                bindgrdBank();
                hdnIsBank.Value = "Bank";
            }
        }
        else if (Session["Mode"].ToString() == "Edit")
        {
            if (btnAdd.Text == "Add Account")
            //    {
            //        objAssesseeBLL = new bllAssessee();
            //        //dtBank = new DataTable();

            //        if (dtBank.Rows.Count < 1)
            //            dtBank = objAssesseeBLL.GetBankDetail(Session["PAN"].ToString()).Copy();

            //        dtBank.Rows.Add(Id + 1, txtBankName.Text, txtBranchAddress.Text, txtAccountNumber.Text, ddlAccountType.SelectedItem.Text, txtMICR.Text.ToUpper());
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dtBank.Rows.Count; i++)
            //        {
            //            if (dtBank.Rows[i]["BankName"].ToString() == Searchbank)
            //            {
            //                dtBank.Rows.RemoveAt(i);
            //            }
            //        }
            //        dtBank.Rows.Add(Id + 1, txtBankName.Text, txtBranchAddress.Text, txtAccountNumber.Text, ddlAccountType.SelectedItem.Text, txtMICR.Text.ToUpper());
            //    }
            {
                objAssesseeBLL = new bllAssessee();
                objAssesseeBLL.InsertBankMastData(Session["PAN"].ToString(), txtBankName.Text, txtBranchAddress.Text, ddlAccountType.SelectedValue, txtAccountNumber.Text, txtMICR.Text);
                bindgrdBank1();
                hdnIsBank.Value = "Bank";
            }
            else
            {
                objAssesseeBLL = new bllAssessee();
                objAssesseeBLL.UpdateBankMastData(txtBankName.Text,txtBranchAddress.Text,ddlAccountType.SelectedValue,txtAccountNumber.Text,txtMICR.Text,BankID);
                //bindgrdBank1();
                bindgrdBank1();
                hdnIsBank.Value = "Bank";
            }

        }
        btnInsert.Enabled = true;
        btnAdd.Text = "Add Account";
        txtBankName.Text = "";
        txtBranchAddress.Text = "";
        txtMICR.Text = "";
        txtAccountNumber.Text = "";
    }
    protected void grdBank_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edit")
        {
            //int index = Convert.ToInt32(e.CommandArgument);
            //GridViewRow row = grdBank.Rows[index];
            GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Int32 rowind = gvRow.RowIndex;
            if (gvRow.Cells[1].Text == "&nbsp;")
            {
                txtBankName.Text = "";
            }
            else
            {
                txtBankName.Text = gvRow.Cells[1].Text;
            }
            if (gvRow.Cells[2].Text == "&nbsp;")
            {
                txtBranchAddress.Text = "";
            }
            else
            {
                txtBranchAddress.Text = gvRow.Cells[2].Text;
            }
            if (gvRow.Cells[3].Text == "&nbsp;")
            {
                txtAccountNumber.Text = "";
            }
            else
            {
                txtAccountNumber.Text = gvRow.Cells[3].Text;
            }
           
            ddlAccountType.Text = gvRow.Cells[4].Text;
            if (gvRow.Cells[5].Text == "&nbsp;")
            {
                txtMICR.Text = "";
            }
            else
            {
                txtMICR.Text = gvRow.Cells[5].Text;
            }
            BankID = Convert.ToInt32(gvRow.Cells[0].Text);
            btnAdd.Text = "Edit";
            //Label txtBank11 =
            // (Label)gvRow.FindControl("lblBank1");
            // Label txtBranch11 =
            //  (Label)gvRow.FindControl("lblBranch1");
            // Label txtAccount11 =
            //  (Label)gvRow.FindControl("lblAccount1");
            // Label txtAccountType11 =
            //  (Label)gvRow.FindControl("lblAccountType1");
            // Label txtIFSC11 =
            //  (Label)gvRow.FindControl("lblIFSC1");
            // txtBankName.Text = txtBank11.Text;
            // txtBranchAddress.Text = txtBranch11.Text;
            // txtAccountNumber.Text = txtAccount11.Text;
            // ddlAccountType.Text = txtAccountType11.Text;
            // txtMICR.Text = txtIFSC11.Text;
            // grdBank.DataSource = table;
            // grdBank.DataBind();
            //int index = Convert.ToInt32(e.CommandArgument);
            //GridViewRow row = grdBank.Rows[index];
            //Searchbank = e.CommandArgument.ToString();
            //btnAdd.Text = "Edit";


            //    if (Session["Mode"] == "Edit")
            //    {
            //        for (int i = 0; i < dtBank.Rows.Count; i++)
            //        {

            //            if (dtBank.Rows[i][1].ToString() == e.CommandArgument.ToString())
            //            {
            //                string BankName = dtBank.Rows[i][1].ToString();
            //                string BranchAddress = dtBank.Rows[i][2].ToString();
            //                string AccountNumber = dtBank.Rows[i][3].ToString();
            //                string AccountType = dtBank.Rows[i][4].ToString();
            //                string MICR = dtBank.Rows[i][5].ToString();
            //                txtBankName.Text = BankName;
            //                txtBranchAddress.Text = BranchAddress;
            //                txtAccountNumber.Text = AccountNumber;
            //                ddlAccountType.Text = AccountType;
            //                txtMICR.Text = MICR;
            //                BankID = Convert.ToInt32(dtBank.Rows[i][0]);
            //            }
            //        }
            //    }
            //    else if (Session["Mode"] == "New")
            //    {
            //        for (int i = 0; i < table.Rows.Count; i++)
            //        {

            //            if (table.Rows[i][1].ToString() == e.CommandArgument.ToString())
            //            {
            //                string BankName = table.Rows[i][1].ToString();
            //                string BranchAddress = table.Rows[i][2].ToString();
            //                string AccountNumber = table.Rows[i][3].ToString();
            //                string AccountType = table.Rows[i][4].ToString();
            //                string MICR = table.Rows[i][5].ToString();
            //                txtBankName.Text = BankName;
            //                txtBranchAddress.Text = BranchAddress;
            //                txtAccountNumber.Text = AccountNumber;
            //                ddlAccountType.Text = AccountType;
            //                txtMICR.Text = MICR;
            //            }
            //        }
            //    }
        }
        else
        {
            if (e.CommandName == "Del")
            {
                Int64 ID = Convert.ToInt64(e.CommandArgument);

                objAssesseeBLL = new bllAssessee();
                objAssesseeBLL.DeleteBankMast(ID);
                DataTable dtBankDetail = new DataTable();
                dtBankDetail = objAssesseeBLL.GetBankDetail(Session["PAN"].ToString()).Copy();
                //grdBank.DataSource = dtBankDetail;
                //grdBank.DataBind();
                bindgrdBank();
            }
        }
    }
    protected void grdBank_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //grdBank.EditIndex = e.NewEditIndex;
        //bindgrdBank();
        grdBank.EditIndex = -1;
    }

    protected void grdBank_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdBank.EditIndex = -1;
    }
    public DataTable getTable()
    {


        ID = ID + 1;
        Presentation_IndividualUser myMainForm;
        myMainForm = (Presentation_IndividualUser)System.Web.HttpContext.Current.Handler;
        TextBox txtBank_Name = myMainForm.txtBankName;
        TextBox txtBranch_Address = myMainForm.txtBranchAddress;
        TextBox txtAccount_Number = myMainForm.txtAccountNumber;
        TextBox ifsc = myMainForm.txtMICR;
        DropDownList ddlAccount_Type = myMainForm.ddlAccountType;
        table.Rows.Add(ID, txtBank_Name.Text, txtBranch_Address.Text, txtAccount_Number.Text, ddlAccount_Type.SelectedItem.Text, ifsc.Text);
     
        //ViewState["dt"] = table;
         return table;
    }
 //protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
 //   {
 //      // string DateValue = e.Value.ToString();
 //       string[] Date = e.Value.Split('/');
 //       string CurrentYear = DateTime.Now.Year.ToString();
 //       int Year = Convert.ToInt32(CurrentYear) - 1;
 //       if (Convert.ToInt32(Date[2]) == Year)
 //       {
 //           if (Convert.ToInt32(Date[1]) > 4)
 //           {
 //               e.IsValid = false;
 //           }
 //           else
 //           {
 //               e.IsValid = true;
 //           }
 //       }
 //       else
 //       {
 //           e.IsValid = true;
 //       }


 //   }
}
