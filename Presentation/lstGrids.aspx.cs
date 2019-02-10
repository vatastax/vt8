using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
using controlgrid;
using System.Globalization;
using System.Data;

public partial class Presentation_lstGrids : System.Web.UI.Page
{
    bool bolTFCheck;
    string YN;
    string vs = "";
    string grd_Selection = "";
    string strTitle = "";
    static int couter = 0;
    static Int32 cnt_FloatingCols_Global = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        bindNewGrid();


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
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        //DynamicControl.k = 2;
        //DynamicControl.h = 1;
        //string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        //string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        //DynamicControl.Project_Name = "VS," + ApplicationHost + "," + Leftpath;

        //following code is to fetch the Admin Connectionstring :

        balAdmin objbalAdmin = new balAdmin();
        denPath objdenPath = new denPath();
        objdenPath = objbalAdmin.Select(Session["project"].ToString());

        //DynamicControl.Project_Name = "Data Source=" + objdenPath.Host + ";Initial Catalog=" + objdenPath.DBName + ";uid=" + objdenPath.username + ";pwd=" + objdenPath.password + ";";

        //DynamicControl.Project_Name = Session["project"].ToString();

        //if (!IsPostBack)
        //{
        //    DynamicControl.Flag_Update = "";
        //    DynamicControl.Flag_Search = "";
        //    DynamicControl.Flag_Delete = "";
        //    DynamicControl.Flag_Filter = "";
        //    DynamicControl.Flag_Paging = "";
        //}
        //DynamicControl.count_Check = "F";
        if (Session["Regular_Correction"] == "Correction_Import")
            Session["Regular_Correction"] = "Correction";

        if (Request.QueryString["VType"].ToString() == "3001")
            btnAdd.Text = "Add Challan";
        else if (Request.QueryString["VType"].ToString() == "3002")
            btnAdd.Text = "Add Deductee";
        else if (Request.QueryString["VType"].ToString() == "3003")
            btnAdd.Text = "Add Salary";
        else if (Request.QueryString["VType"].ToString() == "13011")
            btnAdd.Text = "Add Employer";
        else if (Request.QueryString["VType"].ToString() == "13012")
            btnAdd.Text = "Add Property";
        else if (Request.QueryString["VType"].ToString() == "15037")
            btnAdd.Text = "Add STCG";
        else if (Request.QueryString["VType"].ToString() == "15039")
            btnAdd.Text = "Add LTCG";
        else if (Request.QueryString["VType"].ToString() == "15065")
            btnAdd.Text = "Add 15G Detail";
        else if (Request.QueryString["VType"].ToString() == "15067")
            btnAdd.Text = "Add 15H Detail";
        else if (Request.QueryString["VType"].ToString() == "15074")
            btnAdd.Text = "Add Return";
        //Event
       // dny_Grd_Returns2.grd_SelectedIndexChanged += new EventHandler(dny_Grd_Returns2_grd_SelectedIndexChanged);
        //dny_Grd_Returns2.grd_EditIndex += new EventHandler(dny_Grd_Returns2_grd_EditIndex);
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        
    }

    public void bindGrid()
    {

        string ChallanID = "";
        string sFY = "";
        string[] arrTemp = System.Text.RegularExpressions.Regex.Split(Session["FY"].ToString(), "-");
        if (arrTemp.Length > 1)
            sFY = arrTemp[0] + arrTemp[1].Substring(2, 2);
        else
            sFY = arrTemp[0].ToString();
        if (Request.QueryString["ml"] != null)
        {
            ddTDSList.SelectedValue = Request.QueryString["ml"].ToString();
            ChallanID = Request.QueryString["ml"].ToString(); //(hdnDDListSelection.Value != "") ? hdnDDListSelection.Value : ddTDSList.SelectedValue;// ViewState["Challan"].ToString();
        }
        else
        {
            ChallanID = ddTDSList.SelectedValue;
        }

        if (Session["TAN"] != null)
            DynamicControl.Parameters = Session["TAN"].ToString() + "," + Session["FormType"].ToString() + "," + Session["qtr"].ToString() + "," + sFY + "," + Session["Regular_Correction"].ToString() + "," + ChallanID;
        if (Session["Regular_Correction"] == "Regular")
        {

            //dny_Grd_Returns2.GridName = "grd_Deductees";
            //dny_Grd_Returns2.Page_ID = "534";
            //dny_Grd_Returns2.Page_SubModule_ID = "61";
        }
        else if (Session["Regular_Correction"] == "Correction")
        {
            //dny_Grd_Returns2.GridName = "grd_Deductees_Correction";
            //dny_Grd_Returns2.Page_ID = "534";
            //dny_Grd_Returns2.Page_SubModule_ID = "61";
        }
    }

    private void bindNewGrid()
    {
        if (Session["Regular_Correction"] == "Correction_Import")
            Session["Regular_Correction"] = "Correction";

        denScreen objdenscreen = new denScreen();
        bllScreen objbllScreen = new bllScreen();
        
        objdenscreen = objbllScreen.getSettings(Convert.ToInt16(Request.QueryString["vtype"]));
        string ChallanID = "";
        string sFY = "";
        string[] arrTemp = null;

        if (Session["project"].ToString() == "tds")
        {
            bindListMenu();
            
            if (Session["FY"] != null)
                arrTemp = System.Text.RegularExpressions.Regex.Split(Session["FY"].ToString(), "-");
            if (arrTemp != null)
            {
                if (arrTemp.Length > 1)
                    sFY = arrTemp[0] + arrTemp[1].Substring(2, 2);
                else
                {
                    sFY = arrTemp[0];
                }
            }
            if (Request.QueryString["ml"] != null)
            {
                ddTDSList.SelectedValue = Request.QueryString["ml"].ToString();
                ChallanID = Request.QueryString["ml"].ToString(); //(hdnDDListSelection.Value != "") ? hdnDDListSelection.Value : ddTDSList.SelectedValue;// ViewState["Challan"].ToString();
            }
            else
            {
                if (ddTDSList.Items.Count > 0 && !IsPostBack)
                    ddTDSList.SelectedIndex = 0;
                ChallanID = ddTDSList.SelectedValue;
            }
        }
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        if (Request.QueryString["vtype"].ToString() == "3001")
        {
            //if (Session["TAN"] != null)
            //    DynamicControl.Parameters = Session["TAN"].ToString() + "," + Session["FormType"].ToString() + "," + Session["qtr"].ToString() + "," + sFY + "," + Session["Regular_Correction"].ToString();
            if (Session["Regular_Correction"] == "Regular")
            {
                VGrid1.GridName = "grd_Challans";
                VGrid1.Parameters = Session["TAN"].ToString() + "," + Session["FormType"].ToString() + "," + Session["qtr"].ToString() + "," + sFY + "," + Session["Regular_Correction"].ToString();


                //dny_Grd_Returns2.GridName = objdenscreen.GridName;// "grd_Challans";
                //dny_Grd_Returns2.Page_ID = objdenscreen.Page_ID; //"522";
                //dny_Grd_Returns2.Page_SubModule_ID = objdenscreen.Page_SubModule_ID; //"60";
            }
            else if (Session["Regular_Correction"] == "Correction")
            {
                //dny_Grd_Returns2.GridName = "grd_Challans_Correction";// "grd_Challans";
                //dny_Grd_Returns2.Page_ID = objdenscreen.Page_ID; //"522";
                //dny_Grd_Returns2.Page_SubModule_ID = objdenscreen.Page_SubModule_ID; //"60";
            }
        }
        else if (Request.QueryString["vtype"].ToString() == "3002")
        {
            //following code is to bind the main Dropdown:
            ddTDSList.Visible = true;
            

            if (Session["TAN"] != null)
                VGrid1.Parameters = Session["TAN"].ToString() + "," + Session["FormType"].ToString() + "," + Session["qtr"].ToString() + "," + sFY + "," + Session["Regular_Correction"].ToString() + "," + ChallanID;

            VGrid1.GridName = "grd_Deductee";
            //bindGrid();
        }
        else if (Request.QueryString["vtype"].ToString() == "3003")
        {
            if (Session["TAN"] != null)
                VGrid1.Parameters = Session["TAN"].ToString() + "," + Session["FormType"].ToString() + "," + Session["qtr"].ToString() + "," + sFY + "," + Session["Regular_Correction"].ToString() + "," + ChallanID;

            VGrid1.GridName = "grd_Salary";

            //if (Session["TAN"] != null)
            //    DynamicControl.Parameters = Session["TAN"].ToString() + "," + Session["FormType"].ToString() + "," + Session["qtr"].ToString() + "," + sFY + "," + Session["Regular_Correction"].ToString();
            //if (Session["Regular_Correction"] == "Regular")
            //{
            //    //dny_Grd_Returns2.GridName = "grd_Salary";
            //    //dny_Grd_Returns2.Page_ID = "535";
            //    //dny_Grd_Returns2.Page_SubModule_ID = "62";
            //}
            //else if (Session["Regular_Correction"] == "Correction")
            //{
            //    dny_Grd_Returns2.GridName = "grd_Salary_Correction";
            //    dny_Grd_Returns2.Page_ID = "535";
            //    dny_Grd_Returns2.Page_SubModule_ID = "62";
            //}
        }
        else if (Request.QueryString["vtype"].ToString() == "3004")
        {
            //mltView.ActiveViewIndex = 9;
            //Label6.Text = "Import From Excel";
        }
        else if (Request.QueryString["vtype"].ToString() == "13011")
        {
            VGrid1.GridName = "grdEmployer";
            if (Session["NameId"] != null)
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
        }
        else if (Request.QueryString["vtype"].ToString() == "13012")
        {
            VGrid1.GridName = "grdProperty";
            if (Session["NameId"] != null)
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
        }
        else if (Request.QueryString["vtype"].ToString() == "15037")
        {
            VGrid1.CustomConnection = "Data Source=DEV1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            if (Request.QueryString["tabindx"].ToString() == "0")
            {
                VGrid1.GridName = "STCG_Land";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "1")
            {
                VGrid1.GridName = "STCG_Slump";// "STCG_Equity";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "2")
            {
                VGrid1.GridName = "STCG_Equity";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "3")
            {
                VGrid1.GridName = "STCG_FII_Sale";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "4")
            {
                VGrid1.GridName = "STCG_Sale_of_Sec";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "5")
            {
                VGrid1.GridName = "STCG_Other_Assets";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "6")
            {
                VGrid1.GridName = "STCG_Slump";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            //else if (Request.QueryString["tabindx"].ToString() == "2")
            //{
            //    dny_Grd_Returns2.GridName = "grdCG115AD";
            //    dny_Grd_Returns2.Page_ID = "539";
            //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //}
            //else if (Request.QueryString["tabindx"].ToString() == "3")
            //{
            //    dny_Grd_Returns2.GridName = "grdCGFIISale";
            //    dny_Grd_Returns2.Page_ID = "539";
            //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //}
            //else if (Request.QueryString["tabindx"].ToString() == "4")
            //{
            //    dny_Grd_Returns2.GridName = "grdCGSaleSecurities";
            //    dny_Grd_Returns2.Page_ID = "539";
            //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //}
            //else if (Request.QueryString["tabindx"].ToString() == "5")
            //{
            //    dny_Grd_Returns2.GridName = "grdCGOtherAssets";
            //    dny_Grd_Returns2.Page_ID = "539";
            //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //}
            //else if (Request.QueryString["tabindx"].ToString() == "6")
            //{
            //    dny_Grd_Returns2.GridName = "grdSlump";
            //    dny_Grd_Returns2.Page_ID = "539";
            //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //}
        }

        else if (Request.QueryString["vtype"].ToString() == "15065")
        {
            VGrid1.CustomConnection = "Data Source=DEV1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grd15G";
            VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            btnAdd.Text = "Add Assessee";
        }
        else if (Request.QueryString["vtype"].ToString() == "15067")
        {
            VGrid1.CustomConnection = "Data Source=DEV1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grd15H";
            VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            btnAdd.Text = "Add Assessee";
        }
        else if (Request.QueryString["vtype"].ToString() == "15039")
        {
            VGrid1.CustomConnection = "Data Source=DEV1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            if (Request.QueryString["tabindx"].ToString() == "0")
            {
                VGrid1.GridName = "CGListing";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "1")
            {
                VGrid1.GridName = "LTCG_SlumpSale";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "2")
            {
                VGrid1.GridName = "LTCG_Bonds";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "3")
            {
                VGrid1.GridName = "LTCG_Listed_Security";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "4")
            {
                VGrid1.GridName = "LTCG_Foreign_Specified";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "5")
            {
                VGrid1.GridName = "LTCG_B1_B6";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "6")
            {
                VGrid1.GridName = "LTCG_Foreign_NonSpecified";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "8")
            {
                VGrid1.GridName = "LTCG_NonRes";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            else if (Request.QueryString["tabindx"].ToString() == "9")
            {
                VGrid1.GridName = "LTCG_NonRes_112";
                VGrid1.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
            }
            //    else if (Request.QueryString["tabindx"].ToString() == "2")
            //    {
            //        dny_Grd_Returns2.GridName = "grdCG115AD";
            //        dny_Grd_Returns2.Page_ID = "539";
            //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //    }
            //    else if (Request.QueryString["tabindx"].ToString() == "3")
            //    {
            //        dny_Grd_Returns2.GridName = "grdCGFIISale";
            //        dny_Grd_Returns2.Page_ID = "539";
            //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //    }
            //    else if (Request.QueryString["tabindx"].ToString() == "4")
            //    {
            //        dny_Grd_Returns2.GridName = "grdCGSaleSecurities";
            //        dny_Grd_Returns2.Page_ID = "539";
            //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //    }
            //    else if (Request.QueryString["tabindx"].ToString() == "5")
            //    {
            //        dny_Grd_Returns2.GridName = "grdCGOtherAssets";
            //        dny_Grd_Returns2.Page_ID = "539";
            //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //    }
            //    else if (Request.QueryString["tabindx"].ToString() == "6")
            //    {
            //        dny_Grd_Returns2.GridName = "grdSlump";
            //        dny_Grd_Returns2.Page_ID = "539";
            //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //    }
            //}
            //else if (Request.QueryString["vtype"].ToString() == "13011")
            //{
            //    if (Session["NameID"] != null)
            //        DynamicControl.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();

        //    dny_Grd_Returns2.GridName = "grdEmployer";
            //    dny_Grd_Returns2.Page_ID = "539";
            //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //}
            //else if (Request.QueryString["vtype"].ToString() == "13012")
            //{
            //    if (Session["NameID"] != null)
            //        DynamicControl.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();

        //    dny_Grd_Returns2.GridName = "grdProperty";
            //    dny_Grd_Returns2.Page_ID = "539";
            //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //}
            //else if (Request.QueryString["vtype"].ToString() == "15060")
            //{
            //    if (Session["NameID"] != null)
            //        DynamicControl.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();

        //    dny_Grd_Returns2.GridName = "grdFSI";
            //    dny_Grd_Returns2.Page_ID = "539";
            //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
            //}
            else
            {
                //make a case in DB for this condition
            }
        }
        else if (Request.QueryString["vtype"].ToString() == "15074")
        {
            VGrid1.GridName = "grd_Clients_TDS";
            VGrid1.Parameters = Session["NameID"].ToString();
        }
        VGrid1.DataBind();
        VGrid1.VGrid_Delete += new EventHandler(VGrid1_VGrid_Delete);
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_Update += new EventHandler(VGrid1_VGrid_Update);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["project"].ToString() != "tds")
        {
            DataTable dtGrid = new DataTable();
            dtGrid = VGrid1.SelectedRow;
            string ss = dtGrid.Rows[0][2].ToString();
            Response.Write(dtGrid.Rows[0][2].ToString());
            

            bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            denStoreTrans objdenStoreTrans = new denStoreTrans();

            int row_indx = Convert.ToInt32(dtGrid.Rows[0][0]);
            //string PAN = Job_ID.ToString();// gvRow.Cells[6].Text;
            //bllMain objbllMain = new bllMain();
            Session["MainID"] = (row_indx).ToString();
            ViewState["MainID"] = (row_indx).ToString();
            //Session["E_NameID"] = ViewState["MainID"];
            Session["E_Name"] = dtGrid.Rows[0][1].ToString();
            if (Request.QueryString["VType"] == "13011")
                Response.Redirect("Salary.aspx?VType=40");  //For Salary
            else if (Request.QueryString["VType"] == "13012")
                Response.Redirect("Salary.aspx?VType=42");  //For House Property
            else
                Response.Redirect("Salary.aspx?VType=" + Request.QueryString["VType"].ToString());  //For Rest
        }
        else
        {

            var Job_ID = VGrid1.SelectedDataKey;// Convert.ToInt32(grd.SelectedDataKey.Value);
            DataTable dtSelectedRow=new DataTable();
            dtSelectedRow = VGrid1.SelectedRow;

            bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            denStoreTrans objdenStoreTrans = new denStoreTrans();
           // GridViewRow gvRow = (GridViewRow)grd.SelectedRow;

            //grd.PageIndex
            //int ii = (grd.PageIndex * 10) + grd.SelectedIndex;
            //Session["ChallanID"] = dtSelectedRow.Rows[0]["ChallanID"].ToString(); //gvRow.Cells[4].Text;//Job_ID; Changed by Mudit Due to Change of JobNo which was earliar DeducteeID is no Record_No
            //string ss1 = gvRow.Cells[7].Text;
            //objdenStoreTrans.ChallanID = ddTDSList.SelectedValue;
            if (ddTDSList.SelectedValue != "")
                Session["SelChal"] = Convert.ToInt32(ddTDSList.SelectedValue);
            objdenStoreTrans.TAN = Session["TAN"].ToString();
            objdenStoreTrans.Quarter = Session["qtr"].ToString();
            objdenStoreTrans.AY = Session["AY"].ToString();
            objdenStoreTrans.RegularCorrection = Session["Regular_Correction"].ToString();//"Regular";
            objdenStoreTrans.FormNo = Session["FormType"].ToString();
            objdenStoreTrans.FY = Session["FY"].ToString();
            objdenStoreTrans.NameID = Session["NameID"].ToString();
            if (Request.QueryString["vtype"].ToString() == "3001")
            {
                Session["TDS_JobNo"] = dtSelectedRow.Rows[0][0].ToString();
                Session["TDS_ByBookEntry"] = dtSelectedRow.Rows[0]["By_BookEntry"].ToString();
                objdenStoreTrans.ChallanID = dtSelectedRow.Rows[0]["ChallanID"].ToString();   //gvRow.Cells[5].Text;//grd.SelectedDataKey.Value.ToString(); Changed by Mudit Due to Change of JobNo which was earliar DeducteeID is no Record_No
                Session["ChallanID"] = dtSelectedRow.Rows[0]["Job No"].ToString();
                objbllStoreTrans.ReverseChallanDetails(objdenStoreTrans);
            }
            else if (Request.QueryString["vtype"].ToString() == "3002")
            {
                bindListMenu();
                objdenStoreTrans.ChallanID = ddTDSList.SelectedValue;
                objdenStoreTrans.DeducteeID = Convert.ToInt32(dtSelectedRow.Rows[0]["DeducteeID"]);
                Session["ChallanID"] = dtSelectedRow.Rows[0]["Job No"];
                //objdenStoreTrans.DeducteeID = Convert.ToInt32(gvRow.Cells[5].Text);//Convert.ToInt32(grd.SelectedDataKey.Value); Changed by Mudit Due to Change of JobNo which was earliar DeducteeID is no Record_No
                objbllStoreTrans.ReverseDeducteeDetails(objdenStoreTrans);
            }
            else if (Request.QueryString["vtype"].ToString() == "3003")
            {
                Session["SalaryID"] = dtSelectedRow.Rows[0]["Job No"].ToString();   //SalaryID for mydatabase1.dbo.tbl_SalaryDetailsRecords
                objdenStoreTrans.DeducteeID = Convert.ToInt32(dtSelectedRow.Rows[0]["Job No"]);
                objbllStoreTrans.ReverseSalaryDetails(objdenStoreTrans);
            }
            else
            {
                Session["ChallanID"] = objdenStoreTrans.ChallanID;
            }
            //Session["ChkDateTDS"] = "1";
            
            Session["GrdVal"] = "edt";      //this session will work as a notification to the salary.aspx page that the form should show filled detail as per grid record selected (by ankush on 13-4-15)
            Response.Redirect("manageLinking.aspx?vtype=" + Request.QueryString["vtype"]);
        }
    }

    void VGrid1_VGrid_Update(object sender, EventArgs e)
    {

    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        GridViewCommandEventArgs ee = (GridViewCommandEventArgs)e;
        if (ee.CommandName == "Del1" || ee.CommandName == "Update" || ee.CommandName == "Delete")
        {
            GridView gv = new GridView();
            gv = (GridView)sender;
            int indx = (Convert.ToInt32(ee.CommandArgument) + (gv.PageIndex * gv.PageSize));
            DataTable dt = new DataTable();
            dt = ((DataTable)HttpContext.Current.Session["GridData"]);
            string datakey = dt.Rows[indx][gv.DataKeyNames[0]].ToString();

            if (ee.CommandName == "Del1" || ee.CommandName == "Delete")
            {
                //VGrid1.DeleteParameters = Session["NameID"].ToString() + ",!" + Session["MainID"].ToString() + "," + Session["VType"].ToString() + "," + Session["AY"].ToString() + "," + Session["ComboItemNo"].ToString(); // Request["Parameters"].ToString();
                if (Request.QueryString["vtype"].ToString() == "3001")
                    VGrid1.DeleteParameters = datakey;//Session["NameID"].ToString() + "," + datakey + "," + Session["VType"].ToString() + "," + Session["AY"].ToString() + "," + Request.QueryString["tabindx"].ToString();
                else if (Request.QueryString["vtype"].ToString() == "3002")
                    VGrid1.DeleteParameters = datakey;
                else if (Request.QueryString["vtype"].ToString() == "3003")
                    VGrid1.DeleteParameters = datakey;

                hdnDel.Value = "deleted";
            }
        }
        //else if (ee.CommandName == "Update")
        //{
        //    VGrid1.DeleteParameters = Session["NameID"].ToString() + "," + datakey + "," + Session["VType"].ToString() + "," + Session["AY"].ToString() + "," + Request.QueryString["tabindx"].ToString();
        //}
        //VGrid1.DataBind();
    }

    void VGrid1_VGrid_Delete(object sender, EventArgs e)
    {
        //GridViewDeleteEventArgs ee = (GridViewDeleteEventArgs)e;
        //GridView grd = (GridView)VGrid1.FindControl("CGListing");
        //DataTable dt = (DataTable)grd.DataSource;

        //throw new NotImplementedException();
    }

    //void dny_Grd_Returns2_grd_EditIndex(object sender, EventArgs e)
    //{
    //    if (Session["Project"].ToString() == "vt")
    //    {
    //        GridViewEditEventArgs ee = (GridViewEditEventArgs)e;
    //        GridView grd = (GridView)dny_Grd_Returns2.FindControl("Dynamic_Gridview");
    //        DataTable dt = (DataTable)grd.DataSource;
    //        int ii = (grd.PageIndex * 10) + ee.NewEditIndex;
    //        Session["MainID"] = (ii + 1).ToString();
    //        ViewState["MainID"] = (ii + 1).ToString();
    //        Session["E_NameID"] = ViewState["MainID"];
    //        Response.Redirect("Salary.aspx?VType=" + Request.QueryString["VType"].ToString());
    //        //for Master Page Redirect:

    //        //Session["Exists"] = 1;
    //        //Session["Bool"] = "False";
    //        //Session["Mode"] = "Edit";
    //        //Session["PAN"] = Convert.ToString(dt.Rows[ii]["PanNo"].ToString());
    //        //Session["Status"] = dt.Rows[ii]["Status"].ToString();
    //        //Session["NameID"] = dt.Rows[ii]["ID"].ToString();
    //        //Session["E_NameID"] = null;
    //        //Session["restore"] = null;
    //        //Session["AssesseeType"] = dt.Rows[ii]["Status"].ToString(); //Session["AssesseeType"] = "Individual";
    //        //Session["AType"] = "";
    //        //Session["DateofBirth"] = dt.Rows[ii]["DateOfBirth"].ToString();
    //        //Session["ITR"] = "1";
    //        //Session["ay"] = "2014-2015";// Session["AY"].ToString();    default 14-15 for edi
    //        //if (Session["duedate"] != null)
    //        //    Session["duedate"] = "31-07-2014";
    //        ////Changed by Mudit on 16/06/2015 for Generic Procedures
    //        ////Response.Redirect("Individual.aspx");
    //        //bllSalary objbllSalary = new bllSalary();

    //        //hdnVal = "edt~" + ii.ToString();
    //        ////ScriptManager1.RegisterDataItem(hdnActiveIndx, "1");
    //        ////hdnActiveIndx.Value = "1";//hdnActiveIndx.Value = "1";

    //        //Session["UpdateXml"] = "edt";
    //        //mltView.ActiveViewIndex = 1;
    //        ////lblHdnLbl.Text = hdnActiveIndx.Value;
    //        ////Response.Redirect("AssesseeSelect.aspx");

    //        ////Response.Redirect("Individual.aspx");
    //    }
    //}

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (hdnDel.Value == "deleted")
        {
            hdnDel.Value = "";
            Response.Redirect(Request.Url.ToString());
        }
        //if (Request.QueryString["vtype"].ToString() != "3002")
        //{
        //    GridView grd = (GridView)dny_Grd_Returns2.FindControl("Dynamic_Gridview");
        //    if (grd != null)
        //    {
        //        if (grd.Rows.Count < 1)
        //        {
        //            //dny_Grd_ITRInfo.Visible = false;
        //            //lblMainTitle.Visible = false;
        //            ControlGrid.Visible = false;
        //            pnlNoRecord.Visible = true;
        //            //btnBack2.Visible = true;
        //            //if (cntGrid > 0)
        //            // btnBackToRec.Visible = true;
        //            // else
        //            //  btnBackToRec.Visible = false;
        //        }
        //        else
        //        {
        //            // btnBackToRec.Visible = false;
        //            for (int i = 0; i < grd.Rows.Count; i++)
        //            {
        //                string Filler3 = grd.Rows[i].Cells[5].Text;
        //                hdnFiller.Value = Filler3;
        //                if (Filler3 == "M")
        //                {
        //                    grd.Rows[i].BackColor = System.Drawing.Color.White;
        //                    //grd.Rows[i].Attributes.Add("style", "background-color:Black");
        //                }
        //                else if (Filler3 == "U")
        //                {
        //                    grd.Rows[i].BackColor = System.Drawing.Color.Red;
        //                    //grd.Rows[i].Attributes.Add("style", "background-color:Red");
        //                }

        //                //pageIndex = pageIndex + 1;
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    if (ddTDSList.SelectedValue == "0")
        //    {
        //        ControlGrid.Visible = false;
        //        pnlNoRecord.Visible = true;
        //    }
        //}
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //if (Session["Regular_Correction"] == "Correction_Import")
        //    Session["Regular_Correction"] = "Correction";

        //denScreen objdenscreen = new denScreen();
        //bllScreen objbllScreen = new bllScreen();

        //objdenscreen = objbllScreen.getSettings(Convert.ToInt16(Request.QueryString["vtype"]));


        //string sFY = "";
        //string[] arrTemp=null;
        //if (Session["FY"] != null)
        //    arrTemp = System.Text.RegularExpressions.Regex.Split(Session["FY"].ToString(), "-");
        //if (arrTemp != null)
        //{
        //    if (arrTemp.Length > 1)
        //        sFY = arrTemp[0] + arrTemp[1].Substring(2, 2);
        //    else
        //    {
        //        sFY = arrTemp[0];
        //    }
        //}
        //if (Request.QueryString["vtype"].ToString() == "3001")
        //{
        //    if (Session["TAN"] != null)
        //        DynamicControl.Parameters = Session["TAN"].ToString() + "," + Session["FormType"].ToString() + "," + Session["qtr"].ToString() + "," + sFY + "," + Session["Regular_Correction"].ToString();
        //    if (Session["Regular_Correction"] == "Regular")
        //    {
        //        dny_Grd_Returns2.GridName = objdenscreen.GridName;// "grd_Challans";
        //        dny_Grd_Returns2.Page_ID = objdenscreen.Page_ID; //"522";
        //        dny_Grd_Returns2.Page_SubModule_ID = objdenscreen.Page_SubModule_ID; //"60";
        //    }
        //    else if (Session["Regular_Correction"] == "Correction")
        //    {
        //        dny_Grd_Returns2.GridName = "grd_Challans_Correction";// "grd_Challans";
        //        dny_Grd_Returns2.Page_ID = objdenscreen.Page_ID; //"522";
        //        dny_Grd_Returns2.Page_SubModule_ID = objdenscreen.Page_SubModule_ID; //"60";
        //    }            
        //}
        //else if (Request.QueryString["vtype"].ToString() == "3002")
        //{
        //    //following code is to bind the main Dropdown:
        //    ddTDSList.Visible = true;
        //    bindListMenu();
        //    bindGrid();
        //}
        //else if (Request.QueryString["vtype"].ToString() == "3003")
        //{
        //    if (Session["TAN"] != null)
        //        DynamicControl.Parameters = Session["TAN"].ToString() + "," + Session["FormType"].ToString() + "," + Session["qtr"].ToString() + "," + sFY + "," + Session["Regular_Correction"].ToString();
        //    if (Session["Regular_Correction"] == "Regular")
        //    {
        //        dny_Grd_Returns2.GridName = "grd_Salary";
        //        dny_Grd_Returns2.Page_ID = "535";
        //        dny_Grd_Returns2.Page_SubModule_ID = "62";
        //    }
        //    else if (Session["Regular_Correction"] == "Correction")
        //    {
        //        dny_Grd_Returns2.GridName = "grd_Salary_Correction";
        //        dny_Grd_Returns2.Page_ID = "535";
        //        dny_Grd_Returns2.Page_SubModule_ID = "62";
        //    }
        //}
        //else if (Request.QueryString["vtype"].ToString() == "3004")
        //{
        //    //mltView.ActiveViewIndex = 9;
        //    //Label6.Text = "Import From Excel";
        //}
        //else if (Request.QueryString["vtype"].ToString() == "15037")
        //{
        //    if (Session["NameID"] != null)
        //        DynamicControl.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
        //    if (Request.QueryString["tabindx"].ToString() == "0")
        //    {
        //        dny_Grd_Returns2.GridName = "grdCGLand";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "1")
        //    {
        //        dny_Grd_Returns2.GridName = "grdCGEquity";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "2")
        //    {
        //        dny_Grd_Returns2.GridName = "grdCG115AD";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "3")
        //    {
        //        dny_Grd_Returns2.GridName = "grdCGFIISale";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "4")
        //    {
        //        dny_Grd_Returns2.GridName = "grdCGSaleSecurities";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "5")
        //    {
        //        dny_Grd_Returns2.GridName = "grdCGOtherAssets";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "6")
        //    {
        //        dny_Grd_Returns2.GridName = "grdSlump";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //}
        //else if (Request.QueryString["vtype"].ToString() == "15039")
        //{
        //    if (Session["NameID"] != null)
        //        DynamicControl.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();
        //    if (Request.QueryString["tabindx"].ToString() == "0")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGLand";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "1")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGSaleBond";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "2")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGListedSecurities";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "3")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGGDR";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "4")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGShares";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "5")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGUnlistedSecurities";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "6")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGBondsGDR";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "7")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGSecuritiesFII";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "8")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGFEA";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "9")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGB1B6";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "10")
        //    {
        //        dny_Grd_Returns2.GridName = "grdSlump";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //    else if (Request.QueryString["tabindx"].ToString() == "11")
        //    {
        //        dny_Grd_Returns2.GridName = "grdLTCGFENEA";
        //        dny_Grd_Returns2.Page_ID = "539";
        //        dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //    }
        //}
        //else if (Request.QueryString["vtype"].ToString() == "13011")
        //{
        //    if (Session["NameID"] != null)
        //        DynamicControl.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();

        //    dny_Grd_Returns2.GridName = "grdEmployer";
        //    dny_Grd_Returns2.Page_ID = "539";
        //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //}
        //else if (Request.QueryString["vtype"].ToString() == "13012")
        //{
        //    if (Session["NameID"] != null)
        //        DynamicControl.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();

        //    dny_Grd_Returns2.GridName = "grdProperty";
        //    dny_Grd_Returns2.Page_ID = "539";
        //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //}
        //else if (Request.QueryString["vtype"].ToString() == "15060")
        //{
        //    if (Session["NameID"] != null)
        //        DynamicControl.Parameters = Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString() + "," + Session["NameID"].ToString();

        //    dny_Grd_Returns2.GridName = "grdFSI";
        //    dny_Grd_Returns2.Page_ID = "539";
        //    dny_Grd_Returns2.Page_SubModule_ID = "2067";
        //}
        //else
        //{
        //    //make a case in DB for this condition
        //}
    }

    //void dny_Grd_Returns2_grd_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //Get the Selected Data from GridView\
    //    GridView grd = (GridView)dny_Grd_Returns2.FindControl("Dynamic_Gridview");
    //    System.Xml.XmlDocument cc = new System.Xml.XmlDocument();

    //    if (Session["project"].ToString() != "TDS")
    //    {
    //        var Job_ID = grd.SelectedDataKey.Value;
    //        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
    //        denStoreTrans objdenStoreTrans = new denStoreTrans();
    //        GridViewRow gvRow = (GridViewRow)grd.SelectedRow;
    //        int row_indx = Convert.ToInt32(gvRow.Cells[4].Text);
    //        //string PAN = Job_ID.ToString();// gvRow.Cells[6].Text;
    //        //bllMain objbllMain = new bllMain();
    //        Session["MainID"] = (row_indx).ToString();
    //        ViewState["MainID"] = (row_indx).ToString();
    //        //Session["E_NameID"] = ViewState["MainID"];
    //        Session["E_Name"] = gvRow.Cells[5].Text;
    //        if (Request.QueryString["VType"] == "13011")
    //            Response.Redirect("Salary.aspx?VType=40");  //For Salary
    //        else if (Request.QueryString["VType"] == "13012")
    //            Response.Redirect("Salary.aspx?VType=42");  //For House Property
    //        else
    //            Response.Redirect("Salary.aspx?VType=" + Request.QueryString["VType"].ToString());  //For Rest
    //    }
    //    else
    //    {
    //        var Job_ID = Convert.ToInt32(grd.SelectedDataKey.Value);
    //        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
    //        denStoreTrans objdenStoreTrans = new denStoreTrans();
    //        GridViewRow gvRow = (GridViewRow)grd.SelectedRow;

    //        //grd.PageIndex
    //        int ii = (grd.PageIndex * 10) + grd.SelectedIndex;
    //        Session["ChallanID"] = gvRow.Cells[4].Text;//Job_ID; Changed by Mudit Due to Change of JobNo which was earliar DeducteeID is no Record_No
    //        string ss1 = gvRow.Cells[7].Text;
    //        //objdenStoreTrans.ChallanID = ddTDSList.SelectedValue;
    //        if (ddTDSList.SelectedValue != "")
    //            Session["ddlChallanID"] = Convert.ToInt32(ddTDSList.SelectedValue);
    //        objdenStoreTrans.TAN = Session["TAN"].ToString();
    //        objdenStoreTrans.Quarter = Session["qtr"].ToString();
    //        objdenStoreTrans.AY = Session["AY"].ToString();
    //        objdenStoreTrans.RegularCorrection = Session["Regular_Correction"].ToString();//"Regular";
    //        objdenStoreTrans.FormNo = Session["FormType"].ToString();
    //        objdenStoreTrans.FY = Session["FY"].ToString();
    //        objdenStoreTrans.NameID = Session["NameID"].ToString();
    //        if (Request.QueryString["vtype"].ToString() == "3001")
    //        {
    //            objdenStoreTrans.ChallanID = gvRow.Cells[5].Text;//grd.SelectedDataKey.Value.ToString(); Changed by Mudit Due to Change of JobNo which was earliar DeducteeID is no Record_No
    //            objbllStoreTrans.ReverseChallanDetails(objdenStoreTrans);
    //        }
    //        else if (Request.QueryString["vtype"].ToString() == "3002")
    //        {
    //            bindListMenu();
    //            objdenStoreTrans.ChallanID = ddTDSList.SelectedValue;
    //            objdenStoreTrans.DeducteeID = Convert.ToInt32(gvRow.Cells[5].Text);//Convert.ToInt32(grd.SelectedDataKey.Value); Changed by Mudit Due to Change of JobNo which was earliar DeducteeID is no Record_No
    //            objbllStoreTrans.ReverseDeducteeDetails(objdenStoreTrans);
    //        }
    //        else if (Request.QueryString["vtype"].ToString() == "3003")
    //        {
    //            objdenStoreTrans.DeducteeID = Convert.ToInt32(grd.SelectedDataKey.Value);
    //            objbllStoreTrans.ReverseSalaryDetails(objdenStoreTrans);
    //        }
    //        //Session["ChkDateTDS"] = "1";
    //        Session["GrdVal"] = "edt";      //this session will work as a notification to the salary.aspx page that the form should show filled detail as per grid record selected (by ankush on 13-4-15)
    //        Response.Redirect("Salary.aspx?vtype=" + Request.QueryString["vtype"]);
    //    }
    //    //mltView.ActiveViewIndex = 0;

    //    //grdState.DataSourceID = "";
    //    //grdState.DataBind();

    //    //grdState.DataSourceID = "ObjectDataSource1";
    //    //grdState.DataBind();
    //}

    private void bindListMenu()
    {
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        denStoreTrans objdenStoreTrans = new denStoreTrans();

        objdenStoreTrans.TAN = Session["TAN"].ToString();
        objdenStoreTrans.Quarter = Session["qtr"].ToString();
        objdenStoreTrans.FormNo = Session["FormType"].ToString();
        objdenStoreTrans.RegularCorrection = Session["Regular_Correction"].ToString();
        string[] arrTemp2 = System.Text.RegularExpressions.Regex.Split(Session["FY"].ToString(), "-");
        if (arrTemp2.Length > 1)
            objdenStoreTrans.FY = (Convert.ToInt32(arrTemp2[0]) - 1).ToString() + (Convert.ToInt32(arrTemp2[1].Substring(2, 2)) - 1).ToString();
        else
            objdenStoreTrans.FY = arrTemp2[0];
        objdenStoreTrans.Vtype = Convert.ToInt32(Request.QueryString["vtype"]);

        if (Request.QueryString["vtype"].ToString() == "3002")
        {
            Int32 v = Convert.ToInt32(Request.QueryString["VType"]);
            string ITR = Session["ITR"].ToString();
            string Quarter = Session["qtr"].ToString();
            string AY = Session["AY"].ToString();
            string TAN = Session["TAN"].ToString();
            string FormNo = Session["FormType"].ToString();
            string Regular_Correction = Session["Regular_Correction"].ToString();//"Regular";
            string FY = Session["FY"].ToString();

            //bllScreen objBllScreen = new bllScreen();
            bllScreen objbllScreen = new bllScreen();
            System.Collections.Generic.List<denScreen> lst = new List<denScreen>();
            lst = objbllScreen.getOtherComboData(v, ITR, AY, TAN, FormNo, Regular_Correction, FY, Quarter);

            ddTDSList.Visible = true;
            ddTDSList.DataSource = lst;
            ddTDSList.DataTextField = "ChallanID";
            ddTDSList.DataValueField = "ChallanID";
            ddTDSList.DataBind();
            if (lst.Count == 0)
                ddTDSList.Items.Add(new ListItem("No Challan Found", "0"));
        }
        //DataTable dt = new DataTable();
        //dt = objbllStoreTrans.getComboListData(objdenStoreTrans, "TDS");
        //ddTDSList.DataSource = dt;
        //ddTDSList.DataTextField = "title";
        //ddTDSList.DataValueField = "id";
        //ddTDSList.DataBind();
        //if (dt.Rows.Count == 0)
        //    ddTDSList.Items.Add(new ListItem("No Challan Found", "0"));

    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        if (ViewState["vtype"] != null)
            Response.Redirect("Salary.aspx?vtype=" + ViewState["vtype"].ToString());
        else
            Response.Redirect("Salary.aspx?vtype=" + Request.QueryString["vtype"]);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //To empty any MainID in the session:
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        string MainID = objbllStoreTrans.getMainID(Session["NameId"].ToString(), Request.QueryString["VType"].ToString());
        Session["MainID"] = MainID;    //(Session["MainID"] != null) ? (Convert.ToInt32(Session["MainID"]) + 1).ToString() : "1";
        Session["E_NameID"] = Session["MainID"].ToString();
        ViewState["MainID"] = Session["MainID"].ToString();
        string ss = Session["MainID"].ToString();
        
        if (ViewState["vtype"] != null)
        {
            Session["IncomeTax_VType"] = ViewState["vtype"].ToString();
            Response.Redirect("IncomeTax");
            //Response.Redirect("Salary.aspx?vtype=" + ViewState["vtype"].ToString());
        }
        else
        {
            objbllStoreTrans.saveUniqueIndentificationNo(Session["NameID"].ToString(), Session["AY"].ToString(), Session["ITR"].ToString());
            Session["IncomeTax_VType"] = Request.QueryString["vtype"];
            Response.Redirect("IncomeTax");
         //   Response.Redirect("Salary.aspx?vtype=" + Request.QueryString["vtype"]);
        }
    }
    protected void ddTDSList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["Challan"] = ddTDSList.SelectedValue;
        string chall = ViewState["Challan"].ToString();
        bindGrid();
    }
}