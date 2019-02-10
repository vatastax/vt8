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
using System.Collections;

public partial class Presentation_STaxMaster : System.Web.UI.Page
{
    bllAssessee objAssesseeBLL;
    bllSTax objbllStax;
    static string[] Formats = null;
    static List<denSTax> LstSTax = null;
    static Int64 gridCnt = 0;
    static Int64 gridCnt2 = 0;
    static Int64 gridCnt3 = 0;
    static Int64 selectedMainGrid = 0;

    static List<denAbatementNotifications> LstAb = null;
    static List<denExemptionSerials> LstExempt = null;
    static ArrayList arrSelected = null;
    static ArrayList arrSelected2 = null;
    static ArrayList arrSelected3 = null;
    static DataTable dtMainService =null;
    static DataTable dtAbtService = null;
    static DataTable dtExmptService = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["vtype"] = 30;
        //lblAssesseeType.Text = Convert.ToString(Session["AssesseeType"]);
        //lblPan.Text = Convert.ToString(Session["PAN"]);
        objbllStax = new bllSTax();
        if (Session["AssesseeType"] == null)
            Session["AssesseeType"] = "0";
        if (!IsPostBack)
        {
            if (Session["AssesseeType"] == null)
                Session["AssesseeType"] = "0";

            if (arrSelected != null)
                arrSelected.Clear();
            else
                arrSelected = new ArrayList();

            if (arrSelected2 != null)
                arrSelected2.Clear();
            else
                arrSelected2 = new ArrayList();

            if (arrSelected3 != null)
                arrSelected3.Clear();
            else
                arrSelected3 = new ArrayList();


            gridCnt = 0;
            gridCnt2 = 0;
            gridCnt3 = 0;

            DataTable dtCountr = new DataTable();
            balCountry objbalCountry = new balCountry();
            dtCountr = objbalCountry.Select();
            ddlCountry.DataSource = dtCountr;
            ddlCountry.DataBind();

            ddlCountry.SelectedValue = "112";
            objAssesseeBLL = new bllAssessee();
            DataTable dtBC = new DataTable();
            dtBC = objAssesseeBLL.SelectBusinessCategories();

            SelectDataIndividual(Convert.ToString(Session["PAN"]));
            GetAddress(Convert.ToString(Session["PAN"]));
            GetBankDetails(Convert.ToString(Session["PAN"]));
            GetRepresentativeDetails(Convert.ToString(Session["PAN"]));
            txtPANRep.Text = Session["PAN"].ToString();
            bllSTax objbllSTax = new bllSTax();
            LstSTax = objbllSTax.GetParticulars();
            if (Session["NameID"] != null)
            {
                dtMainService = objbllStax.getSelectedServices(Session["NameID"].ToString());

            }
            bindServices();
        }
    }

    protected void ddService_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dd = new DropDownList();
        dd = (DropDownList)sender;        
        bllSTax objbllSTax = new bllSTax();        
        LstAb = objbllSTax.getAbatementNotifications(Convert.ToInt64(dd.SelectedValue));
        LstExempt = objbllSTax.getExemptionSerials(Convert.ToInt64(dd.SelectedValue));

        string[] arrExemptions = new string[1];
        gvExempNotifications.DataSource = arrExemptions;
        gvExempNotifications.DataBind();
        gvAbtclaimed.DataSource = arrExemptions;
        gvAbtclaimed.DataBind();

        gvProvisional.DataSource = arrExemptions;
        gvProvisional.DataBind();

        ddSP.SelectedIndex = 1;
    }

    protected void gvProvisional_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            //DropDownList ddService_NN = new DropDownList();
            //DropDownList dd_SIN = new DropDownList();

            //ddService_NN = (DropDownList)e.Row.FindControl("ddService_NN");
            //ddService_NN.DataSource = LstAb;
            //ddService_NN.DataTextField = "Notification_Number";
            //ddService_NN.DataValueField = "id";
            //ddService_NN.DataBind();

            //dd_SIN = (DropDownList)e.Row.FindControl("dd_SIN");
            //dd_SIN.DataSource = LstExempt;
            //dd_SIN.DataTextField = "NotSerialNo";
            //dd_SIN.DataValueField = "id";
            //dd_SIN.DataBind();
        }
    }

    protected void gvServices_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            DropDownList ddLst = new DropDownList();
            ddLst = (DropDownList)e.Row.FindControl("ddService");

            ListItem lstFirst = new ListItem(" -- Select -- ", "0");
            ddLst.DataSource = LstSTax;
            ddLst.DataTextField = "title";
            ddLst.DataValueField = "id";
            ddLst.DataBind();

            ddLst.Items.Insert(0, lstFirst);
            if (arrSelected != null)
            {
                if (arrSelected.Count > e.Row.RowIndex)
                {
                    ddLst.SelectedIndex = Convert.ToInt32(arrSelected[e.Row.RowIndex]);
                    ddLst.Enabled = false;
                }
            }
            if (Session["NameID"] != null)
            {
                if (dtMainService.Rows.Count > 0)
                {
                    if (dtMainService.Rows.Count > e.Row.RowIndex)
                    {
                        ddLst.SelectedValue = dtMainService.Rows[e.Row.RowIndex][1].ToString();
                        ddLst.Enabled = false;
                    }
                }
            }

        }
    }

    protected void gvExempNotifications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            DropDownList dd=new DropDownList();
            DropDownList ddService_NN = new DropDownList();
            DropDownList dd_SIN = new DropDownList();
            bllSTax objbllSTax=new bllSTax();
            ddService_NN = (DropDownList)e.Row.FindControl("ddService_NN");
            ddService_NN.DataSource = LstAb;
            ddService_NN.DataTextField = "Notification_Number";
            ddService_NN.DataValueField = "id";
            ddService_NN.DataBind();

            dd_SIN = (DropDownList)e.Row.FindControl("dd_SIN");
            dd_SIN.DataSource = LstExempt;
            dd_SIN.DataTextField = "NotSerialNo";
            dd_SIN.DataValueField = "id";
            dd_SIN.DataBind();

            if (arrSelected2 != null)
            {
                if (arrSelected2.Count > e.Row.RowIndex)
                {
                    ddService_NN.SelectedIndex = Convert.ToInt32(arrSelected2[e.Row.RowIndex]);
                    //ddService_NN.Enabled = false;
                }
            }
            if (Session["NameID"] != null)
            {
                if (dtExmptService != null)
                {
                    if (dtExmptService.Rows.Count > 0)
                    {
                        if (dtExmptService.Rows.Count > e.Row.RowIndex)
                        {
                            ddService_NN.SelectedItem.Text = dtExmptService.Rows[e.Row.RowIndex][2].ToString();
                            dd_SIN.SelectedValue = dtExmptService.Rows[e.Row.RowIndex][3].ToString();
                            ddService_NN.Enabled = false;
                            dd_SIN.Enabled = false;

        }
    }
                }
            }
        }
    }

    protected void gvAbtclaimed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            DropDownList ddService_NN = new DropDownList();
            DropDownList dd_SIN = new DropDownList();

            ddService_NN = (DropDownList)e.Row.FindControl("ddService_NN");
            ddService_NN.DataSource = LstAb;
            ddService_NN.DataTextField = "Notification_Number";
            ddService_NN.DataValueField = "id";
            ddService_NN.DataBind();

            dd_SIN = (DropDownList)e.Row.FindControl("dd_SIN");
            dd_SIN.DataSource = LstExempt;
            dd_SIN.DataTextField = "NotSerialNo";
            dd_SIN.DataValueField = "id";
            dd_SIN.DataBind();

            if (arrSelected2 != null)
            {
                if (arrSelected2.Count > e.Row.RowIndex)
                {
                    ddService_NN.SelectedIndex = Convert.ToInt32(arrSelected2[e.Row.RowIndex]);
                    //ddService_NN.Enabled = false;
                }
            }
            if (Session["NameID"] != null)
            {
                if (dtAbtService != null)
                {
                    if (dtAbtService.Rows.Count > 0)
                    {
                        if (dtAbtService.Rows.Count > e.Row.RowIndex)
                        {
                            ddService_NN.SelectedItem.Text = dtAbtService.Rows[e.Row.RowIndex][2].ToString();
                            dd_SIN.SelectedValue = dtAbtService.Rows[e.Row.RowIndex][3].ToString();
                            ddService_NN.Enabled = false;
                            dd_SIN.Enabled = false;

        }
    }
                }
            }
        }
    }

    private void bindServices()
    {
        if (Session["NameID"] != null)
        {
            if (dtMainService.Rows.Count > gridCnt)
            {
                gridCnt = dtMainService.Rows.Count;
                //gridCnt += 1;
            }
            else
                gridCnt += 1;
        }
        else
        {
            gridCnt += 1;
        }
        string[] arrData = new string[gridCnt];
        gvServices.DataSource = arrData;
        gvServices.DataBind();
        //GetDataSelectedService(Session["NameID"].ToString());
    }

    protected void btnAddGRow_Click(object sender, EventArgs e)
    {
        DropDownList dd = new DropDownList();
        foreach (GridViewRow row1 in gvServices.Rows)
        {
            
            dd = (DropDownList)row1.FindControl("ddService");
            arrSelected.Add(dd.SelectedIndex);
            dd.Enabled = false;
        }
        arrSelected.Add(dd.SelectedIndex);
        gridCnt += 1;
        bindServices();
    }

    protected void btnAddGRow2_Click(object sender, EventArgs e)
    {
        DropDownList dd = new DropDownList();
        foreach (GridViewRow row1 in gvExempNotifications.Rows)
        {            
            
            dd = (DropDownList)row1.FindControl("ddService_NN");
            arrSelected2.Add(dd.SelectedIndex);
            dd.Enabled = false;
        }
        arrSelected2.Add(dd.SelectedIndex);
        gridCnt2 += 1;

        bindExemptions();
    }

    private void bindExemptions()
    {
        if (Session["NameID"] != null)
        {
            //ViewState["lastID"] = selectedMainGrid.ToString();
            dtExmptService = objbllStax.getSelectedExmptServices(ViewState["lastID"].ToString());
            if (dtExmptService.Rows.Count > gridCnt2)
            {
                gridCnt2 = dtExmptService.Rows.Count;
            }
            else
            {
                gridCnt2 += 1;
            }
        }
        else
        {
            gridCnt2 += 1;
        }
        string[] arrData = new string[gridCnt2];
        gvExempNotifications.DataSource = arrData;
        gvExempNotifications.DataBind();
    }

    protected void btnAddGRow3_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row1 in gvAbtclaimed.Rows)
        {            
            DropDownList dd = new DropDownList();
            dd = (DropDownList)row1.FindControl("ddService_NN");
            arrSelected3.Add(dd.SelectedIndex);
            dd.Enabled = false;
        }
        gridCnt3 += 1;

        bindAbatements();
    }

    private void bindAbatements()
    {
        if (Session["NameID"] != null)
        {
            dtAbtService = objbllStax.getSelectedAbtServices(ViewState["lastID"].ToString());
            if (dtAbtService.Rows.Count > gridCnt3)
            {
                gridCnt3 = dtAbtService.Rows.Count;
            }
            else
            {
                gridCnt3 += 1;
            }
        }
        else
        {
            gridCnt3 += 1;
        }
        string[] arrData = new string[gridCnt3];
        gvAbtclaimed.DataSource = arrData;
        gvAbtclaimed.DataBind();
    }

    protected void btnRemGRow_Click(object sender, EventArgs e)
    {
        gridCnt -= 1;
        bindServices();
    }

    protected void btnRemGRow2_Click(object sender, EventArgs e)
    {
        gridCnt2 -= 1;
        bindExemptions();
    }
    protected void btnRemGRow3_Click(object sender, EventArgs e)
    {
        gridCnt3 -= 1;
        bindAbatements();
    }

    protected void btnViewGRow_Click(object sender, EventArgs e)
    {
        //GetDataSelectedService(Session["NameID"].ToString);
        DropDownList dd = new DropDownList();
        foreach (GridViewRow row in gvServices.Rows)
        {
            dd = (DropDownList)row.FindControl("ddService");
    }

        //bllSTax objbllSTax = new bllSTax();
        //LstAb = objbllSTax.getAbatementNotifications(Convert.ToInt64(dd.SelectedValue));
        //LstExempt = objbllSTax.getExemptionSerials(Convert.ToInt64(dd.SelectedValue));
    
        //string[] arrExemptions = new string[1];
        //gvExempNotifications.DataSource = arrExemptions;
        //gvExempNotifications.DataBind();
        //gvAbtclaimed.DataSource = arrExemptions;
        //gvAbtclaimed.DataBind();
    
        //gvProvisional.DataSource = arrExemptions;
        //gvProvisional.DataBind();

        //ddSP.SelectedIndex = 0;
        ////assdet1.Style.Add("dispaly", "block");
        ////ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>showForm(); </script>");
    }

    
    


    void InsertDataIndividual()
    {
        denAssesseeIndividual objAssesseeDEN;

        objAssesseeDEN = new denAssesseeIndividual();
        objAssesseeBLL = new bllAssessee();
        objAssesseeDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
        objAssesseeDEN.UserName = Convert.ToString(Session["UserName"]);
        objAssesseeDEN.Status = Convert.ToInt32(Session["Status"]);
        objAssesseeDEN.PANNO = Convert.ToString(Session["PAN"]);
        objAssesseeDEN.Salute = 0;// ddlSalute.SelectedIndex;
        objAssesseeDEN.LastName = txtLastName.Text;
        objAssesseeDEN.MiddleName = "";
        objAssesseeDEN.FirstName = "";
        objAssesseeDEN.FatherName = "";
        objAssesseeDEN.ServiceTaxRegNo = txtSTGN.Text;
        objAssesseeDEN.TANNO = "";// txtTAN.Text;
        DateTime dTime = new DateTime();

        DateTime dd = new DateTime();

        string ShortFormat = "yyyy-MM-dd";
        string LongFormat = "yyyy-dd-MM";
        Formats = new string[8] { ShortFormat, LongFormat, "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd", "yyyy/dd/MM", "dd-MM-yyyy", "MM-dd-yyyy" };




        objAssesseeDEN.DateofBirth = "31/03/1980";// dTime.Day.ToString() + "/" + dTime.Month.ToString() + "/" + dTime.Year.ToString();  //txtDOB.Text;
        objAssesseeDEN.ResStatus = 0;// ddlResStatus.SelectedIndex;
        objAssesseeDEN.TypeofAss = 1;// typeofass = 1 for service tax assessee     (Session["AssesseeType"] != null) ? Convert.ToInt32(Session["AssesseeType"]) : 0;
        objAssesseeDEN.EMail = txtEmail.Text;
        objAssesseeDEN.WardCircle = "";// txtWard.Text;
        objAssesseeDEN.BussNature = "";// ddlBussNature.SelectedValue;
        objAssesseeDEN.PEOutIndia = 0;
        objAssesseeDEN.PEInIndia = 0;
        objAssesseeDEN.no_of_dependents = 0;
        objAssesseeBLL.InsertNameMastIndividual(objAssesseeDEN);
        dalAssessee objAssesseeDAL = new dalAssessee();
        denAssesseeIndividual objAssesseeIndividualDEN = new denAssesseeIndividual();
        objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(objAssesseeDEN.PANNO, Convert.ToString(Session["UserName"]));
        Session["NameID"] = objAssesseeIndividualDEN.NameID;
        //ddlStatus.SelectedIndex = 0;

        
        txtLastName.Text = "";
      
        txtEmail.Text = "";
      
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
            txtLastName.Text = objAssesseeIndividualDEN.LastName;
            //txtMiddleName.Text = objAssesseeIndividualDEN.MiddleName;
            //txtFirstName.Text = objAssesseeIndividualDEN.FirstName;
            //ddlStatus.SelectedIndex = objAssesseeIndividualDEN.Status;
            //ddlSalute.SelectedIndex = objAssesseeIndividualDEN.Salute;
            //txtFatherName.Text = objAssesseeIndividualDEN.FatherName;
            //DateTime dtime = new DateTime();
            //dtime = Convert.ToDateTime(objAssesseeIndividualDEN.DateofBirth);
            //txtDOB.Text = objAssesseeIndividualDEN.DateofBirth;// dtime.Year.ToString() + "-" + ((dtime.Month.ToString().Length == 1) ? ("0" + dtime.Month.ToString()) : dtime.Month.ToString()) + "-" + ((dtime.Day.ToString().Length == 1) ? ("0" + dtime.Day.ToString()) : dtime.Day.ToString());
            txtSTGN.Text = objAssesseeIndividualDEN.ServiceTaxRegNo;
            txtEmail.Text = objAssesseeIndividualDEN.EMail;
          
            txtSTD.Text = objAssesseeIndividualDEN.STDCODE;
            txtPhone.Text = objAssesseeIndividualDEN.PhoneNo;
            txtSTGN.Text = objAssesseeIndividualDEN.ServiceTaxRegNo;
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

        objAssesseeDEN.PANNO = Convert.ToString(Session["PAN"]);
        objAssesseeDEN.Salute = 0;
        objAssesseeDEN.LastName = txtLastName.Text;
        objAssesseeDEN.MiddleName = "";
        objAssesseeDEN.FirstName = "";
        objAssesseeDEN.FatherName = txtFNameAu.Text;
        objAssesseeDEN.TANNO = "";
        objAssesseeDEN.DateofBirth = "20/02/1980";
        objAssesseeDEN.ResStatus = 0;
        objAssesseeDEN.TypeofAss = 1;
        objAssesseeDEN.EMail = txtEmail.Text;
        objAssesseeDEN.WardCircle = "";
        objAssesseeDEN.BussNature = "";
        objAssesseeDEN.PEOutIndia = 0;
        objAssesseeDEN.PEInIndia = 0;
        objAssesseeDEN.ServiceTaxRegNo = txtSTGN.Text;
        // objAssesseeDEN.no_of_dependents = (txtNoOfDependents.Text == "") ? 0 : Convert.ToInt32(txtNoOfDependents.Text);

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

    //protected void txtDOB_TextChanged(object sender, EventArgs e)
    //{
    //    string date = txtDOB.Text;
    //    DateTime str = Convert.ToDateTime(date);
    //    string strc = str.ToShortDateString();
    //    txtDOB.Text = strc;
    //}

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

    //Save Button Click
    protected void Button1_Click1(object sender, EventArgs e)
     {
        Int64 lastID = 0;
        string ss = Session["NameID"].ToString();
        if (Page.IsValid)
        {
            if (Convert.ToString(Session["Mode"]) == "New")
            {
                
                InsertDataIndividual();
                InsertAddress();
                denSTax objdenSTax = new denSTax();
                bllSTax objbllSTax = new bllSTax();

                foreach (GridViewRow row1 in gvServices.Rows)
                {
                    DropDownList ddService = new DropDownList();
                    ddService = (DropDownList)row1.FindControl("ddService");
                    lastID = objbllSTax.AddService(Convert.ToInt64(ddService.SelectedValue), Session["NameID"].ToString(), Convert.ToInt16(ddSP.SelectedValue), Convert.ToInt16(DropDownList2.SelectedValue), (txtSTaxPayable.Text), Convert.ToInt16(DropDownList1.SelectedValue), Convert.ToInt16(DropDownList3.SelectedValue), (TextBox1.Text), Convert.ToInt16(DropDownList4.SelectedValue), Convert.ToInt16(DropDownList5.SelectedValue), Convert.ToInt16(DropDownList6.SelectedValue));
                }
                foreach (GridViewRow row1 in gvAbtclaimed.Rows)
                {
                    DropDownList dd = new DropDownList();
                    DropDownList dd_SIN = new DropDownList();
                    dd = (DropDownList)row1.FindControl("ddService_NN");
                    dd_SIN = (DropDownList)row1.FindControl("dd_SIN");
                    objbllSTax.AddAbtService(lastID, Convert.ToString(dd.SelectedValue), Convert.ToInt64(dd_SIN.SelectedValue));
                }
                foreach (GridViewRow row1 in gvExempNotifications.Rows)
                {
                    DropDownList dd = new DropDownList();
                    DropDownList dd_SIN = new DropDownList();
                    dd = (DropDownList)row1.FindControl("ddService_NN");
                    dd_SIN = (DropDownList)row1.FindControl("dd_SIN");
                    objbllSTax.AddExmptService(lastID, Convert.ToString(dd.SelectedValue), Convert.ToInt64(dd_SIN.SelectedValue));
                }

                foreach (GridViewRow row1 in gvProvisional.Rows)
                {
                    TextBox txtProOrderNo = new TextBox();
                    TextBox txtDate = new TextBox();
                    txtProOrderNo = (TextBox)row1.FindControl("txtNotificationNo");
                    txtDate = (TextBox)row1.FindControl("txt");
                    objbllSTax.AddProService(lastID, txtProOrderNo.Text, txtDate.Text);
                }
                
            }
            else if (Convert.ToString(Session["Mode"]) == "Edit")
            {
                UpdateDataIndividual();
                UpdateAddress();
                UpdateAuthorisedSignatory();
                denSTax objdenSTax = new denSTax();
                bllSTax objbllSTax = new bllSTax();

                foreach (GridViewRow row1 in gvServices.Rows)
                {
                    DropDownList ddService = new DropDownList();
                    ddService = (DropDownList)row1.FindControl("ddService");

                    lastID = objbllSTax.AddService(Convert.ToInt64(ddService.SelectedValue), Session["NameID"].ToString(), Convert.ToInt16(ddSP.SelectedValue), Convert.ToInt16(DropDownList2.SelectedValue), (txtSTaxPayable.Text), Convert.ToInt16(DropDownList1.SelectedValue), Convert.ToInt16(DropDownList3.SelectedValue), (TextBox1.Text), Convert.ToInt16(DropDownList4.SelectedValue), Convert.ToInt16(DropDownList5.SelectedValue), Convert.ToInt16(DropDownList6.SelectedValue));
                }
                foreach (GridViewRow row1 in gvAbtclaimed.Rows)
                {
                    DropDownList dd = new DropDownList();
                    DropDownList dd_SIN = new DropDownList();
                    dd = (DropDownList)row1.FindControl("ddService_NN");
                    dd_SIN = (DropDownList)row1.FindControl("dd_SIN");
                    objbllSTax.AddAbtService(lastID,Convert.ToString(dd.SelectedItem),Convert.ToInt64(dd_SIN.SelectedValue));
                }
                foreach (GridViewRow row1 in gvExempNotifications.Rows)
                {
                    DropDownList dd = new DropDownList();
                    DropDownList dd_SIN = new DropDownList();
                    dd = (DropDownList)row1.FindControl("ddService_NN");
                    dd_SIN = (DropDownList)row1.FindControl("dd_SIN");
                    objbllSTax.AddExmptService(lastID, Convert.ToString(dd.SelectedItem), Convert.ToInt64(dd_SIN.SelectedValue));
                }
                foreach (GridViewRow row1 in gvProvisional.Rows)
                {
                    TextBox txtProOrderNo = new TextBox();
                    TextBox txtDate = new TextBox();
                    txtProOrderNo = (TextBox)row1.FindControl("txtNotificationNo");
                    txtDate = (TextBox)row1.FindControl("txt");
                    objbllSTax.AddProService(lastID, txtProOrderNo.Text, txtDate.Text);
                }
            }
            
            UpdateBankDetails();
            //if (rdoRepresentative.Checked == true)
            //{
            //    UpdateRepresentativeDetails();
            //}
            //if (rdoSelf.Checked == true)
            //{
            //    UpdateAuthorisedSignatory();
            //}
            lblMessage.Visible = true;
            lblMessage.Text = "Information Addeed/Updated Successfully";
        }
        else
        {

            lblMessage.Visible = true;
            lblMessage.Text = "Please Enter All the Values";

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
            objDocTransDEN.MICRCode = txtMICR.Text;
            objDocTransDEN.AccountNumber = txtAccountNumber.Text;
            objDocTransDEN.AddressofBranch = txtBranchAddress.Text;
            objDocTransDEN.ECS = ddlESC.SelectedValue;
            objDocTransDEN.RefundMethod = ddlRefund.SelectedValue;

            objDocTransDEN.Business_Nature1 = 0;
            objDocTransDEN.Business_Nature2 = 0;
            objDocTransDEN.Business_Nature3 = 0;

            objDocTransDEN.Business1_Trade1 = "";
            objDocTransDEN.Business1_Trade2 = "";
            objDocTransDEN.Business1_Trade3 = "";

            objDocTransDEN.Business2_Trade1 = "";
            objDocTransDEN.Business2_Trade2 = "";
            objDocTransDEN.Business2_Trade3 = "";

            objDocTransDEN.Business3_Trade1 = "";
            objDocTransDEN.Business3_Trade2 = "";
            objDocTransDEN.Business3_Trade3 = "";

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
            txtNameRep.Text = objDocTransDEN.Auth_Name;
            txtDesignationRep.Text = objDocTransDEN.Auth_Desig;
            txtFNameAu.Text = objDocTransDEN.Auth_Father_Name;

            txtPANRep.Text = objDocTransDEN.PAN;
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
            //objDocTransDEN.Place = txtPlaceRep.Text;
            //objDocTransDEN.Flat = txtFlatRep.Text;
            //objDocTransDEN.Premises = txtPremisesRep.Text;
            //objDocTransDEN.Road = txtRoadRep.Text;
            //objDocTransDEN.Area = txtAreaRep.Text;
            //objDocTransDEN.City = txtCityRep.Text;
            //objDocTransDEN.State = Convert.ToInt32(ddlStatesRep.SelectedValue);
            //objDocTransDEN.PIN = txtPINRep.Text;

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
            objDocTransDEN.Auth_Name = txtNameRep.Text;
            objDocTransDEN.Auth_Father_Name = txtFNameAu.Text;
            objDocTransDEN.Auth_Desig = txtDesignationRep.Text;
            objDocTransDEN.Auth_Place = "";
            objDocTransDEN.FilingDate = "";// txtDateAu.Text;
            objDocTransDEN.WardCircle = "";

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
        //{
        //    txtNameRep.Enabled = true;
        //    txtFNameAu.Enabled = true;
        //    txtPANRep.Enabled = true;
        //    txtDesignationRep.Enabled = true;
        //    RequiredFieldValidator11.Visible = true;
        //}
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

    //Added By Mudit On 25-04-2015 For Fetching Selected Service
    public void GetDataSelectedService(string NameID)
    {
        

    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList4.SelectedIndex == 1)
        {
            gvExempNotifications.Visible = true;
        }
        else
        {
            gvExempNotifications.Visible = false;
        }
    }

    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList5.SelectedIndex == 1)
        {
            gvAbtclaimed.Visible = true;
        }
        else
        {
            gvAbtclaimed.Visible = false;
        }
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList6.SelectedIndex == 1)
        {
            gvProvisional.Visible = true;
        }
        else
        {
            gvProvisional.Visible = false;
        }
    }
    protected void gvServices_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "viw")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            selectedMainGrid = index;
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            DropDownList dd = new DropDownList();
            dd = (DropDownList)row.FindControl("ddService");
            bllSTax objbllSTax = new bllSTax();
            LstAb = objbllSTax.getAbatementNotifications(Convert.ToInt64(dd.SelectedValue));
            LstExempt = objbllSTax.getExemptionSerials(Convert.ToInt64(dd.SelectedValue));
            if (Session["NameID"] != null)
            {
                if (dtMainService.Rows.Count >= gridCnt)
                {
                    DataRow[] row1 = dtMainService.Select("serviceID=" + dd.SelectedValue);

                    if (row1 != null)
                    {
                        ViewState["lastID"] = Convert.ToInt64(row1[0][0].ToString());
                        ddSP.SelectedIndex = Convert.ToInt16(row1[0][3]);
                        DropDownList2.SelectedIndex = Convert.ToInt16(row1[0][4]);
                        txtSTaxPayable.Text = row1[0][5].ToString();
                        DropDownList1.SelectedIndex = Convert.ToInt16(row1[0][6]);
                        DropDownList3.SelectedIndex = Convert.ToInt16(row1[0][7]);
                        TextBox1.Text = row1[0][8].ToString();
                        DropDownList4.SelectedIndex = Convert.ToInt16(row1[0][9]);
                        DropDownList5.SelectedIndex = Convert.ToInt16(row1[0][10]);
                        DropDownList6.SelectedIndex = Convert.ToInt16(row1[0][11]);
                        bindExemptions();
                        bindAbatements();

                        //gvProvisional.DataSource = arrExemptions;
                        //gvProvisional.DataBind();

                        //ddSP.SelectedIndex = 0;
                        if (DropDownList4.SelectedIndex == 1)
                            gvExempNotifications.Visible = true;
                        if (DropDownList5.SelectedIndex == 1)
                            gvAbtclaimed.Visible = true;
                        if (DropDownList6.SelectedIndex == 1)
                            gvProvisional.Visible = true;
                    }
                }
                else
                {
                    ViewState["lastID"] = dd.SelectedValue;

                    bindAbatements();
                    bindExemptions();
                    ddSP.SelectedIndex = 0;
                    DropDownList2.SelectedIndex = 0;
                    txtSTaxPayable.Text = "";
                    DropDownList1.SelectedIndex =0;
                    DropDownList3.SelectedIndex = 0;
                    TextBox1.Text = "";
                    DropDownList4.SelectedIndex = 0;
                    DropDownList5.SelectedIndex = 0;
                    DropDownList6.SelectedIndex = 0;
                    if (DropDownList4.SelectedIndex == 0)
                        gvExempNotifications.Visible = false;
                    if (DropDownList5.SelectedIndex == 0)
                        gvAbtclaimed.Visible = false;
                    if (DropDownList6.SelectedIndex == 0)
                        gvProvisional.Visible = false;
                    //ddSP.SelectedIndex = 0;
                }
            }
            else
            {
                string[] arrExemptions = new string[1];
                gvExempNotifications.DataSource = arrExemptions;
                gvExempNotifications.DataBind();
                gvAbtclaimed.DataSource = arrExemptions;
                gvAbtclaimed.DataBind();

                gvProvisional.DataSource = arrExemptions;
                gvProvisional.DataBind();

                ddSP.SelectedIndex = 1;
            }
        }
    }
}