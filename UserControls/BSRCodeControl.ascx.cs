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
using BALVatasETDS.BSRCode;
public partial class UserControls_BSRCodeControl : System.Web.UI.UserControl
{
    DataTable dt;
    BSRCodes objBSRcode;
    Bltbl_BSRCode objBltbl_BSRCode;
    tbl_BSRCode objtbl_BSRCode;
    public string strConnectionString, strConnName, strConnectionString_Admin;
    Form26 objForm26;
    TANMaster objTANMaster;
    public event ImageClickEventHandler ButtonCloseClick1;
    public event EventHandler SelectedIndex;
    public event EventHandler SelectedBankIndex;
    public event EventHandler SelectedStateIndex;
    public event EventHandler SelectedAreaIndex;
    public event EventHandler SelectedBranchIndex;

    protected void Page_Load(object sender, EventArgs e)
    {
        strConnName = Application["DBEngine"].ToString();
        strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings[Application["DBEngine3"].ToString()].ConnectionString;   // for admin connectionstring

        objForm26 = new Form26(strConnectionString, strConnName);
        objTANMaster = new TANMaster(strConnectionString, strConnName);
        objBSRcode = new BSRCodes(strConnectionString, strConnName);
        objtbl_BSRCode = new tbl_BSRCode();
        objBltbl_BSRCode = new Bltbl_BSRCode(strConnectionString, strConnName, strConnectionString_Admin);
        if (!Page.IsPostBack)
        {
            BindBSrCodeGrid();
            FillBankNameCombo();
            BindDefaultStateCombo();
        }
    }
    public void BindBSrCodeGrid()
    {
        dt = new DataTable();
        if (dt.Rows.Count == 0)
        {
            gdv_BSRCodes.DataSource = objBSRcode.SetEmptyGrid();
            gdv_BSRCodes.DataBind();
        }
    }
    
    public void FillBankNameCombo()
    {
        //Fill BankName Combo
      drp_Bank.DataSource = objBSRcode.GetBank();
        drp_Bank.DataTextField = "BankName";
        drp_Bank.DataValueField = "BankName";
        drp_Bank.DataBind();
        drp_Bank.Items.Insert(0, new ListItem("---Select---", ""));

    }
    protected void drp_Bank_SelectedIndexChanged(object sender, EventArgs e)
    {
        string BankName = drp_Bank.SelectedValue.ToString();
        ViewState["BankName"] = BankName;
        FillBankStateCombo(BankName);
        SelectedBankIndex(sender, e);
        drp_State.Focus();


    }
    public void FillBankStateCombo(string BankName)
    {
        drp_State.DataSource = objBSRcode.GetStateByBank(BankName);
        drp_State.DataValueField = "BankState";
        drp_State.DataTextField = "BankState";
        drp_State.DataBind();
        drp_State.Items.Insert(0, new ListItem("---Select---", ""));

    }
    public void BindDefaultStateCombo()
    {
        drp_State.Items.Insert(0, new ListItem("---No State To Select----", ""));
        drp_Area.Items.Insert(0, new ListItem("---No Area/City To Select", ""));
        drp_Branch.Items.Insert(0, new ListItem("--No Branch To Select", ""));
    }
    public void FillBankCityCombo(string BankName, String BankState)
    {
        drp_Area.DataSource = objBSRcode.GetAreaOrCityByStateAndBank(BankName, BankState);
        drp_Area.DataValueField = "BankCity";
        drp_Area.DataTextField = "BankCity";
        drp_Area.DataBind();
        drp_Area.Items.Insert(0, new ListItem("---Select---", ""));
    }
    protected void drp_State_SelectedIndexChanged(object sender, EventArgs e)
    {
        string BankState = drp_State.SelectedValue.ToString();
        ViewState["BankState"] = BankState;
        string BankName = ViewState["BankName"].ToString();
        FillBankCityCombo(BankName, BankState);
        SelectedStateIndex(sender,e);
        drp_Area.Focus();

    }
    public void FillBankBranch(string BankName, string BankState, string BankCity)
    {
        drp_Branch.DataSource = objBSRcode.GetBankBranches(BankName, BankState, BankCity);
        drp_Branch.DataTextField = "Branch";
        drp_Branch.DataValueField = "Branch";
        drp_Branch.DataBind();
        drp_Branch.Items.Insert(0, new ListItem("---Select---", ""));
    }
    protected void drp_Area_SelectedIndexChanged(object sender, EventArgs e)
    {
        string BankName = ViewState["BankName"].ToString();
        string BankState = ViewState["BankState"].ToString();
        string BankCity = drp_Area.SelectedValue.ToString();
        ViewState["BankCity"] = BankCity;
        FillBankBranch(BankName, BankState, BankCity);
        SelectedAreaIndex(sender,e);
        drp_Branch.Focus();


    }
    public void FillBSRCodeGrid(string BankName, string BankState, string BankCity, string BankBranch)
    {
        gdv_BSRCodes.DataSource = objBSRcode.GetGridData(BankName, BankState, BankCity, BankBranch);
        gdv_BSRCodes.DataBind();
    }
    protected void drp_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        string BankName = ViewState["BankName"].ToString();
        string BankState = ViewState["BankState"].ToString();
        string BankCity = ViewState["BankCity"].ToString();
        string BankBranch = drp_Branch.SelectedValue.ToString();
        FillBSRCodeGrid(BankName, BankState, BankCity, BankBranch);
        SelectedBranchIndex(sender,e);

    }
    protected void btn_Close_Click(object sender, ImageClickEventArgs e)
    {
        ButtonCloseClick1(sender,e);
    }
    protected void gdv_BSRCodes_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedIndex(sender, e);
       
    }
}
