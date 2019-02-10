using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using VatasInfosysLib;
using System.Collections.Generic;
using BALVatasETDS.TANMaster;
using BALVatasETDS.FileHeader;
using BALVatasETDS.BatchHeader;
using BALVatasETDS.ChallanDetails;
using BALVatasETDS.DeducteeDetail;
using BALVatasETDS.SalaryDetails;
using DALVatasETDS;
using System.IO;
using BALVatasETDS;
using AjaxControlToolkit;
//using mbox;



public partial class UserControls_FormControl1 : System.Web.UI.UserControl
{
    
    Bltbl_TANMaster objBltbl_TANMaster;
    tbl_TANMaster objtbl_TANMaster;
    public static int CountDeductee = 0;
    public static int index = 0;
    public static int countChallan = 0;
    DataSet ds;
    public event ImageClickEventHandler ButtonCloseClick;
    string Reg_Corr = string.Empty;
    public event EventHandler ButtonSubmitClick;
    //Create Object of File_Header Class
    Bltbl_FileHeader objBltbl_FileHeader;
    tbl_FileHeader objtbl_FileHeader;
    //Create Object of Batch_Header Class
    Bltbl_BatchHeader objBltbl_BatchHeader;
    tbl_BatchHeader objtbl_BatchHeader;
    //Create Object of Challan_Detail Class
    Bltbl_ChallanDetails objBltbl_ChallanDetails;
    tbl_ChallanDetails objtbl_ChallanDetails;
    //Create Object of Deductee_Detail Class
    Bltbl_DeducteeDetail objBltbl_DeducteeDetail;
    tbl_DeducteeDetail objtbl_DeducteeDetail;

    //Create Object of Salary_Detail Class
    Bltbl_SalaryDetails objBltbl_SalaryDetails;
    tbl_SalaryDetails objtbl_SalaryDetails;
    
   //Create Object of DB_Module
    DBtbl_Module objDBtbl_Module;

   //Constructor
    //public UserControls_FormControl1()
    //{
    //    InitializeComponent();
    //    this.IsVisibleChanged += new DependencyPropertyChangedEventHandler(LoginControl_IsVisibleChanged); 
    //}

    //void LoginControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    //{
    //    if ((bool)e.NewValue == true)
    //    {
    //        Dispatcher.BeginInvoke(
    //        DispatcherPriority.ContextIdle,
    //        new Action(delegate()
    //        {
    //            txt_TANNumber.Focus();
    //        }));
    //    }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {

        string strConnectionString, strConnName, strConnectionString_Admin;
      
        strConnName = Application["DBEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[Application["DBEngine"].ToString()].ConnectionString;
      
        objBltbl_TANMaster = new Bltbl_TANMaster(strConnectionString,strConnName,strConnectionString_Admin);
        objtbl_TANMaster = new tbl_TANMaster();

        objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString,strConnName,strConnectionString_Admin);
        objtbl_FileHeader = new tbl_FileHeader();

        objBltbl_BatchHeader = new Bltbl_BatchHeader(strConnectionString,strConnName,strConnectionString_Admin);
        objtbl_BatchHeader = new tbl_BatchHeader();

        objBltbl_ChallanDetails = new Bltbl_ChallanDetails(strConnectionString,strConnName,strConnectionString_Admin);
        objtbl_ChallanDetails = new tbl_ChallanDetails();

        objBltbl_DeducteeDetail = new Bltbl_DeducteeDetail(strConnectionString,strConnName,strConnectionString_Admin);
        objtbl_DeducteeDetail = new tbl_DeducteeDetail();

        objBltbl_SalaryDetails = new Bltbl_SalaryDetails(strConnectionString,strConnName,strConnectionString_Admin);
        objtbl_SalaryDetails = new tbl_SalaryDetails();

        objDBtbl_Module = new DBtbl_Module(strConnectionString,strConnName,strConnectionString_Admin);
       
        if (!Page.IsPostBack)
        {
            FillCombo();
            CountDeductee = 0;
            index = 0;
            countChallan = 0;
            LoadDefaultControl();
            string menu = string.Empty;
            if (Session["menu"] != null)
            {
                menu = Session["menu"].ToString();
            }

            if (menu == "AIR")
            {

                drp_Quater.Visible = false;
                lbl_Quater.Visible = false;
                drp_FormType.Visible = false;
                lbl_FormType.Visible = false;


            }
            else
            {
                drp_Quater.Visible = true;
                lbl_Quater.Visible = true;
                drp_FormType.Visible = true;
                lbl_FormType.Visible = true;
            }
        }
        int Popup_ControlID = 1;
        auto_TANUC.ContextKey = getQuery(367, 4, "TAN", auto_TANUC) + "!" + Popup_ControlID + "!" + txt_TANNumber.ID;
        auto_Name.ContextKey = getQuery(367, 4, "AName", auto_Name) + "!" + Popup_ControlID + "!" + txt_Name.ID;
        //update_FormControl.Update();

        //get the Error
        //Context Key For TAN
          string contextkey_TAN = auto_TANUC.ContextKey.ToString();
        contextkey_TAN = contextkey_TAN.Replace("'", "");
        contextkey_TAN = contextkey_TAN.Replace("'", "");

        //Create the Context Key For AName
        string context_AName =auto_Name.ContextKey.ToString();
        context_AName = context_AName.Replace("'", "");
        context_AName = context_AName.Replace("'", "");
        //Set Attributes to Call Error Message
        
        txt_TANNumber.Attributes.Add("onkeyup", "ShowMessage(event,this,'" + contextkey_TAN + "')");
        txt_Name.Attributes.Add("onkeyup", "ShowMessage(event,this,'" + context_AName + "')");
        //if (!Page.IsPostBack)
        //{
        //    SetInputFocus();
        //    //Page.Form.DefaultFocus = Demo1.FindControl("txt_TANNumber").ClientID;
        //}

        //txt_TANNumber.Focus();
    }

    //Function to get generate the Query for filling the autocomplete list.
    public string getQuery(int QueryID, int TableID, string FieldName, AutoCompleteExtender autoComplete_Name)
    {

        objtbl_TANMaster.QueryID = QueryID;
        objtbl_TANMaster.TableID = TableID;
        objtbl_TANMaster.FieldName = FieldName;
        //objtbl_JobWork.FieldValue = FieldValue;
        objtbl_TANMaster.Count = Convert.ToInt32(autoComplete_Name.CompletionSetCount);
        string strQuery = objBltbl_TANMaster.CreateQuery(objtbl_TANMaster) + "!" + FieldName;
        return strQuery;
    }
   //Function to load Default Control
    public void LoadDefaultControl()
    {
        txt_TANNumber.Focus();
        txt_PANNumber.Enabled = false;
        txt_PANNumber.Attributes.Add("style", "background-color:#E3E3E3");
        drp_FormType.Enabled = false;
        drp_FormType.Attributes.Add("style", "background-color:#E3E3E3");
        drp_FinancialYear.Enabled = false;
        drp_FinancialYear.Attributes.Add("style", "background-color:#E3E3E3");
      txt_AssesmentYear.Enabled = false;
      txt_AssesmentYear.Attributes.Add("style", "background-color:#E3E3E3");
      drp_Quater.Enabled = false;
      drp_Quater.Attributes.Add("style", "background-color:#E3E3E3");
    }
    //Functioin to enable Default Control
    public void EnableDefaultControl()
    {
        txt_PANNumber.Enabled = true;
        txt_PANNumber.Attributes.Remove("style");
        drp_FormType.Enabled = true;
        drp_FormType.Attributes.Remove("style");
        drp_FinancialYear.Enabled = true;
        drp_FinancialYear.Attributes.Remove("style");
        txt_AssesmentYear.Enabled = true;
        txt_AssesmentYear.Attributes.Remove("style");
        drp_Quater.Enabled = true;
        drp_Quater.Attributes.Remove("style");
    }

    public void FillCombo()
    {

        //Fill Quater Combo

        drp_Quater.DataSource =objBltbl_TANMaster.FillQuarterCombo();
        drp_Quater.DataTextField = "QuaterName";
        drp_Quater.DataValueField = "QuarterCode";
        drp_Quater.DataBind();
        drp_Quater.Items.Insert(0, new ListItem("---Select---", "0"));

        //Fill FinancialYear Combo
        BindFinancialYearCombo();

        //Fill FormType Combo
        drp_FormType.DataSource = objBltbl_TANMaster.FillFormTypeCombo();
        drp_FormType.DataTextField = "FormName";
        drp_FormType.DataValueField = "FormCode";
        drp_FormType.DataBind();
        drp_FormType.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    public void BindFinancialYearCombo()
    {
        DateTime dt = DateTime.Now;
        int year = Convert.ToInt32(dt.Year);
        for (int i = 2004; i < year + 1; i++)
        {
            int j = i + 1;
            drp_FinancialYear.Items.Add(i + "-" + j);


        }
        drp_FinancialYear.Items.Insert(0, new ListItem("---Select---", "0"));
        List<string> listItems = drp_FinancialYear.Items.Cast<ListItem>().Select(item => item.Text).ToList();
        listItems.Sort((a , b) => string.Compare(b, a));
        drp_FinancialYear.DataSource = listItems;
        drp_FinancialYear.DataBind();
    }
    public void BindAssessmentYear()
    {
        string assessmentYear = drp_FinancialYear.SelectedItem.ToString();
        string FirstYear = assessmentYear.Substring(0, 4);
        string lastYear = assessmentYear.Substring(5, 4);
        int firstyear = Convert.ToInt32(FirstYear);
        firstyear = firstyear + 1;
        int lastyear = Convert.ToInt32(lastYear);
        lastyear = lastyear + 1;
        txt_AssesmentYear.Text = Convert.ToString(firstyear + "-" + lastyear);




    }
    public void FillFields(string FieldName, string FieldValue)
     {
        string SearchBy = FieldName;
        //create Paramteres to Pass to the Function
        objtbl_TANMaster.FieldName = FieldName;
        objtbl_TANMaster.FieldValue = FieldValue;
        objtbl_TANMaster.Regular_Correction ="Regular";
        ds = new DataSet();
        ds = objBltbl_TANMaster.FillRecords(objtbl_TANMaster);
        if (ds.Tables[0].Rows.Count != 0)
        {

            if (SearchBy == "TAN")
            {
                txt_PANNumber.Text = ds.Tables[0].Rows[0]["PAN"].ToString();
                txt_Name.Text = ds.Tables[0].Rows[0]["AName"].ToString();

            }
            else if (SearchBy == "AName")
            {
                txt_TANNumber.Text = ds.Tables[0].Rows[0]["TAN"].ToString();
                txt_PANNumber.Text = ds.Tables[0].Rows[0]["PAN"].ToString();
            }
        }
        else
        {
            //MessageBox.Show("No Records Found");
        }
    }
    protected void drp_FinancialYear_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        BindAssessmentYear();
        txt_AssesmentYear.Focus();
    }
    protected void drp_Quater_SelectedIndexChanged(object sender, EventArgs e)
    {
        btn_Submit.Focus();
    }
   
    protected void txt_TANNumber_TextChanged(object sender, EventArgs e)
    {
        FillByTAN();
        EnableDefaultControl();
        drp_FormType.Focus();

    }
    protected void txt_Name_TextChanged(object sender, EventArgs e)
    {
        FilByName();
        EnableDefaultControl();
        drp_FormType.Focus();
    }
    public void FillByTAN()
    {
        FillFields("TAN", txt_TANNumber.Text);
       
    }
    public void FilByName()
    {
        FillFields("AName", txt_Name.Text);
        
    }

   
   
    //protected void rdl_SelectReturn_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    rdlSelectedIndex(sender, e);
       
        
    //}
    protected void btn_Close_Click(object sender, ImageClickEventArgs e)
    {
        ButtonCloseClick(sender, e);
    }





    //public void SetInputFocus()
    //{
    //    //System.Web.UI.WebControls.TextBox tbox = this.Demo1.FindControl("txt_TANNumber") as System.Web.UI.WebControls.TextBox;
     
    //        ToolkitScriptManager.GetCurrent(this.Page).SetFocus(txt_TANNumber);
    //        //ScriptManager.GetCurrent(this.Page).SetFocus(tbox);
        
    //}


   



    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        ButtonSubmitClick(sender, e);
    }
    protected void drp_FormType_SelectedIndexChanged(object sender, EventArgs e)
    {
        drp_FinancialYear.Focus();
    }
}
