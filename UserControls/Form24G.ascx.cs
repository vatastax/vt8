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
using BALVatasETDS;
using BALVatasETDS.BatchHeader_24G;
using BALVatasETDS.AIN_Master;
using BALVatasETDS.DDO_TransactionDetailRecord_24G;
using BALVatasETDS.TANMaster;
using System.Collections.Generic;
using AjaxControlToolkit;

public partial class UserControls_Form24G : System.Web.UI.UserControl
{
    //Create the Object of BatchHeader_24G
    Bltbl_BatchHeader_24G objBltbl_BatchHeader_24G;
    tbl_BatchHeader_24G objtbl_BatchHeader_24G;
    //Create the Object of DDO_TransactionDetailRecord_24G
    Bltbl_DDO_TransactionDetailRecord_24G objBltbl_DDO_TransactionDetailRecord_24G;
    tbl_DDO_TransactionDetailRecord objtbl_DDO_TransactionDetailRecord;
    //Craete the Object of AIN_Master
    Bltbl_AIN_Master objBltbl_AIN_Master;
    tbl_AIN_Master objtbl_AIN_Master;

    //Create Object of the TanMaster
    Bltbl_TANMaster objBltbl_TANMaster;
    tbl_TANMaster objtbl_TANMaster;

    //Create DataTable
    DataTable dt;
    //Create the Button Events
    public event ImageClickEventHandler ButtonCloseClick;
    public event EventHandler ButtonSubmitClick;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Create Connection Strings and Connection Name
        string strConnectionString, strConnName, strConnectionString_Admin;

        strConnName = Application["DBEngine"].ToString();

        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[Application["DBEngine6"].ToString()].ConnectionString;
       
        //Intialize the object of BatchHeader_24G
        objBltbl_BatchHeader_24G = new Bltbl_BatchHeader_24G(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_BatchHeader_24G = new tbl_BatchHeader_24G();

        //Intialize the object of DDO_TransactionDetailRecord_24G
        objBltbl_DDO_TransactionDetailRecord_24G = new Bltbl_DDO_TransactionDetailRecord_24G(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_DDO_TransactionDetailRecord = new tbl_DDO_TransactionDetailRecord();
        //Intialize the object of AIN_master
        objBltbl_AIN_Master = new Bltbl_AIN_Master(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_AIN_Master = new tbl_AIN_Master();


        //Initialize the Object For TANMaster
        objBltbl_TANMaster = new Bltbl_TANMaster(strConnectionString, strConnName, strConnectionString_Admin);
        objtbl_TANMaster = new tbl_TANMaster();

        int Popup_ControlID=5;
        //Get The AIN List
        //autoComplete_AIN.ContextKey = getQuery(254, 69, "AccOfficeIdentificationNo_AIN");
       //Get the Name List
        //auto_Name.ContextKey = getQuery(256, 69, "AO_Name");

        //Functions to Run when the Page Loads for the First Time
        if (!Page.IsPostBack)
        {
            LoadDefaultControl();
            FillCombos();

        }

        
        autoComplete_AIN.ContextKey = getQuery(335, 90, "AccOfficeIdentificationNo_AIN",autoComplete_AIN) + "!" + Popup_ControlID + "!" + txt_AINNumber.ID;
        //Create The Context Key and Set the Atrribute to call the Error Message Function
        //Create the Context Key For AName
        string context_AIN = autoComplete_AIN.ContextKey.ToString();
        context_AIN = context_AIN.Replace("'", "");
        context_AIN = context_AIN.Replace("'", "");


        txt_AINNumber.Attributes.Add("onkeyup", "ShowMessage(event,this,'" + context_AIN + "')");



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
    //Function to Fill Combos
    public void FillCombos()
    {
        //Bind Financial Year Combo

        DateTime date = DateTime.Now;
        int year = Convert.ToInt32(date.Year);
        for (int i = 2004; i < year + 1; i++)
        {
            int j = i + 1;

            drp_FinancialYear.Items.Add(i + "-" + j);


        }
        drp_FinancialYear.Items.Insert(0, new ListItem("---Select---", "0"));
        List<string> listItems = drp_FinancialYear.Items.Cast<ListItem>().Select(item => item.Text).ToList();
        listItems.Sort((a, b) => string.Compare(b, a));
        drp_FinancialYear.DataSource = listItems;
        drp_FinancialYear.DataBind();

        //Bind  Month Combo
        dt = new DataTable();
        dt = objBltbl_BatchHeader_24G.BindMonthCombo();
        if (dt.Rows.Count != 0)
        {
            //Assign the DataSource to Month Combo
            drp_Month.DataSource = dt;
            drp_Month.DataTextField = "Month";
            drp_Month.DataValueField = "MonthCode";
            drp_Month.DataBind();
            drp_Month.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }

    //Click Event of Submit Button
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        ButtonSubmitClick(sender, e);
    }
    protected void btn_Close_Click(object sender, ImageClickEventArgs e)
    {
        ButtonCloseClick(sender, e);
    }

    //Function to Load  Default Control
    public void LoadDefaultControl()
    {
        //Disable Financial Year Combo
        drp_FinancialYear.Enabled = false;
        drp_FinancialYear.Attributes.Add("style", "background-color:#E3E3E3");
        
        //Disable Month Combo Year
        drp_Month.Enabled = false;
        drp_Month.Attributes.Add("style","background-color:#E3E3E3");
    }

    //Function to Fill By AIN
    public void FillBYAIN(string FieldName,string FieldValue)
    {
       
        //Create Parameters
        objtbl_AIN_Master.FieldName = FieldName;
        objtbl_AIN_Master.FieldValue = FieldValue;
        //Create DataTable and Fill it
        dt = new DataTable();
        dt = objBltbl_AIN_Master.FillBy(objtbl_AIN_Master);
        if (dt.Rows.Count != 0)
        {
            txt_AOName.Text = dt.Rows[0]["AO_Name"].ToString();

        }
        //Enable Financial Year Combo.
        drp_FinancialYear.Enabled = true;
        drp_FinancialYear.Attributes.Remove("style");
        //Enable Month Combo
        drp_Month.Enabled = true;
        drp_Month.Attributes.Remove("style");
    }

    //Function to Fill By AO_Name
    public void FillBYAOName(string FieldName, string FieldValue)
    {
        //Create Parameters
        objtbl_AIN_Master.FieldName = FieldName;
        objtbl_AIN_Master.FieldValue = FieldValue;
        //Create DataTable and Fill it
        dt = new DataTable();
        dt =objBltbl_AIN_Master.FillBy(objtbl_AIN_Master);
        if (dt.Rows.Count != 0)
        {
            txt_AINNumber.Text = dt.Rows[0]["AccOfficeIdentificationNo_AIN"].ToString();

        }
        //Enable Financial Year Combo.
        drp_FinancialYear.Enabled = true;
        drp_FinancialYear.Attributes.Remove("style");
        //Enable Month Combo
        drp_Month.Enabled = true;
        drp_Month.Attributes.Remove("style");
    }
    //Text Change Event of AIN
    protected void txt_AINNumber_TextChanged(object sender, EventArgs e)
    {
        FillBYAIN("AccOfficeIdentificationNo_AIN",txt_AINNumber.Text);
    }
    //Text Change Event of AO_Name
    protected void txt_AOName_TextChanged(object sender, EventArgs e)
    {
        FillBYAOName("AO_Name", txt_AOName.Text);
    }

   
    

    
}
