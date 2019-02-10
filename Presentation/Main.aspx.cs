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
//using GetTDSReference;
using System.Globalization;
using System.Reflection;
using controlgrid;
using System.IO;
using System.Web.Services;
using BALVatasETDS.UserGroupManagement;

public partial class Presentation_Main : System.Web.UI.Page
{
    int audit;
    static string url_ref = "";
    Module objModule;
    static string ShortFormat = "";
    static string LongFormat = "";
    static string[] Formats = null;
    static bool IsLnkClicked = false;
    bllStoreTrans objbllStoreTrans = new bllStoreTrans();
    static int cntGrid = 0;
    static string hdnVal = "testing";
    static int StateID = 26;

    denMain objdenMain = new denMain();
    bllMain objbllMain = new bllMain();
    static bool IsEdit = false;
    static string ITRXML_ID = "";
    static int IsEditSelect = 0;
    static string IsOrigRevised = "1";
    string errMsg = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["ut"] != null && Session["ITRXML_ID"] != null && !IsPostBack)
        {
            ITRXML_ID = Session["ITRXML_ID"].ToString();
            Session["UpdateXML"] = "sel";
            Session["Mode"] = "Sel";
            row_AY.Style.Add("display", "none");
            row_DD.Style.Add("display", "none");
            row_ITR.Style.Add("display", "none");
            rowAmt.Style.Add("display", "none");
            //divEmployer.Style.Add("display", "none");
            divNotice.Style.Add("display", "none");
            divDON.Style.Add("display", "none");
            //divGovernedPortugese.Style.Add("display", "none");
            IsEditSelect = 2;
            DropDownList2.SelectedValue = Session["AY"].ToString();
            ddITR.SelectedValue = Session["ITR"].ToString();
            ddlReturnType.SelectedValue = (Session["ReturnType"].ToString() == "Original") ? "O" : "R";
            mltView.ActiveViewIndex = 1;
        }
        else
        {
            //Added by Mudit on 30/06/2015 for deleting records if user comes back without generating XML
            if (Session["NameID"] != null)
            {
                bllAssessee objbllAssessee = new bllAssessee();

                string AY = (Session["AY"] != null) ? Session["AY"].ToString() : "2014-2015";
                hdnAY.Value = AY;
                string NameID = Session["NameID"].ToString();
                //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'> alert('All Yor Data Will be Lost....!!');</script>");
                if (hdnButton.Value == "")
                    objbllAssessee.DeleteFromStoreTrans(NameID, AY);
                else
                    hdnButton.Value = "";

                if (Session["Status"] != null)
                {
                    if (Session["Status"].ToString() == "1")
                        divGovernedPortugese.Visible = false;
                    else
                        divGovernedPortugese.Visible = true;
                }
                else
                    divGovernedPortugese.Visible = true;
            }
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
            if (Request.QueryString["ai"] != null)
            {
                mltView.ActiveViewIndex = 1;
            }
            Session["InternalSal"] = null;
            Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
            Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
            Session["xmlRestore"] = "set";
            Session["inc"] = "set";

            //for managing window close from top:
            if (Request.UrlReferrer != null)
            {
                if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                    Session["Main"] = null;
                else
                    Session["Main"] = "set";
            }
            else
                Session["Main"] = "set";

            if (Session["project"].ToString() == "vt")
            {
                Page.Title = "The Interactive Platform for free e-filing Income Tax Returns in India";
            }
            else if (Session["project"].ToString() == "tds")
            {
               
                Page.Title = "The Interactive Platform for free e-filing TDS Returns in India";
            }
            // following code is for ControlGrid
            DynamicControl.k = 2;
            DynamicControl.h = 1;
            string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
            //DynamicControl.Project_Name = "VS," + ApplicationHost + "," + Leftpath;

            //following code is to fetch the Admin Connectionstring :

            balAdmin objbalAdmin = new balAdmin();
            denPath objdenPath = new denPath();
            objdenPath = objbalAdmin.Select(Session["project"].ToString());

            DynamicControl.Project_Name = "Data Source=" + objdenPath.Host + ";Initial Catalog=" + objdenPath.DBName + ";uid=" + objdenPath.username + ";pwd=" + objdenPath.password + ";";

            //objModule = new Module(ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString, Application["DatabaseEngine5"].ToString());
            //System.Collections.Generic.List<denMain> objMain = objbllMain.GetAssYear();

            if (Session["project"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            if (!IsPostBack)
            {
                IsOrigRevised = "1";
                StateID = 26;
                if (Session["user_name"] == null)
                    Response.Redirect("login.aspx");

                if (Session["project"].ToString() == "vt" || Session["project"].ToString() == "tds")
                {
                    //DropDownList2.DataSource = objbllMain.GetAssYear();
                    //DropDownList2.DataBind();
                    if (Session["UserRole"] != null)
                    {
                        if (Session["UserRole"].ToString() == "FO")
                        {
                            rowAmt.Visible = true;
                        }
                    }
                    setITR();
                    getData();
                }
                if (Session["project"].ToString() == "stax" || Session["project"].ToString() == "tds")
                {
                    ddFY.DataSource = objbllMain.GetFinYear();
                    ddFY.DataTextField = "AssYear";
                    ddFY.DataValueField = "AssYear";
                    ddFY.DataBind();
                    setDueDateForStax();
                }

                if (Session["Account_Type"] != null)
                {
                    if (Session["Account_Type"].ToString() == "S" || Session["Account_Type"].ToString() == "E" || Session["Account_Type"].ToString() == "US")
                        btnAddAssessee.Visible = false;
                }
                ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";
                if (Request.UrlReferrer != null)
                    url_ref = Request.UrlReferrer.ToString();

                //if (Session["Project"] != null)
                //{
                //    if (Session["Project"].ToString() == "vt" || Session["Project"].ToString() == "stax")
                //    {
                //        //gvTDS.DataSource = "";
                //        //GridView1.DataSource = ObjectDataSource1;
                //        //GridView1.DataBind();
                //        dny_Grd_ITRInfo.GridName = "grd_AssesseeList";
                //        dny_Grd_ITRInfo.Page_ID = "537";
                //        dny_Grd_ITRInfo.Page_SubModule_ID = "64";
                //        lblMainTitle.Text = "List of Assessees";
                //    }
                //    else
                //    {
                //        //gvTDS.DataSource = ObjectDataSource5;
                //        //gvTDS.DataBind();
                //        dny_Grd_ITRInfo.GridName = "grd_TANList";
                //        dny_Grd_ITRInfo.Page_ID = "536";
                //        dny_Grd_ITRInfo.Page_SubModule_ID = "63";
                //        btnAddAssessee.Text = "Add New Deductee";
                //        //GridView1.DataSource = "";
                //        //GridView1.DataBind();
                //        lblMainTitle.Text = "List of Deductors";
                //    }
                //}
                // following code is for ControlGrid
                DynamicControl.Flag_Update = "";
                DynamicControl.Flag_Search = "";
                DynamicControl.Flag_Delete = "";
                DynamicControl.Flag_Filter = "";
                DynamicControl.Flag_Paging = "";

                ITRXML_ID = "0";
            }
            if (Session["tab"] != null || Request.QueryString["rid"] != null)
            {
                mltView.ActiveViewIndex = (Session["tab"] != null) ? Convert.ToInt32(Session["tab"]) : Convert.ToInt32(Request.QueryString["rid"]);
                Session["tab"] = null;
            }

            lblMsg.Visible = false;

            // following code is for ControlGrid
            DynamicControl.count_Check = "F";

            //if (Session["NameID"] != null)
            //    DynamicControl.Parameters = Session["NameID"].ToString();

            //Event
            //dny_Grd_Returns2.grd_SelectedIndexChanged += new EventHandler(dny_Grd_Returns2_grd_SelectedIndexChanged);
            //dny_Grd_TANInfo.grd_SelectedIndexChanged += new EventHandler(dny_Grd_TANInfo_grd_SelectedIndexChanged);
            //dny_Grd_ITRInfo.grd_SelectedIndexChanged += new EventHandler(dny_Grd_ITRInfo_grd_SelectedIndexChanged);
            //dny_Grd_ITRInfo.grd_SelectedIndexChanging += new EventHandler(dny_Grd_ITRInfo_grd_SelectedIndexChanging);
            //dny_Grd_ITRInfo.grd_EditIndex += new EventHandler(dny_Grd_ITRInfo_grd_EditIndex);
            //dny_Grd_Returns2.Enabled = false;

            //if (IsLnkClicked)
            //{
            //DataTable dtGrdData = new DataTable();
            //dtGrdData = dny_Grd_Returns2.Get_Data("grd_OldReturns", "521", "59");
            //if (dtGrdData != null)
            //{
            //    if (dtGrdData.Rows.Count < 1)
            //    {
            //        olditr.Visible = false;
            //        detolditr.Visible = false;
            //    }
            //}
            //    IsLnkClicked = false;
            //}
            if (dny_Grd_ITRInfo.Controls.Count < 1)
            {
                //dny_Grd_ITRInfo.Visible = false;
                //lblMainTitle.Visible = false;
            }
            if (Session["Project"].ToString() == "tds")
            {
                if (Session["TAN"] != null)
                    BindNewGrid();
            }
            else if (Session["Project"].ToString() == "vt")
            {
                if (Session["PAN"] != null)
                    BindNewGrid();
            }
            //int ii = VGrid1.Controls.Count;
            //if (!IsEdit)
            ClientScript.RegisterClientScriptBlock(GetType(), "ads", "<script type='text/javascript'>showIt();</script>");
            //else
            //    IsEdit = false;

            //hdnActiveIndx.Value = "0";
            hdnAY.Value = DropDownList2.SelectedValue;
        }
        if (!IsPostBack)
        {
            if (Session["project"].ToString() == "tds")
            {
                tbl_AY objtbl_AY = new tbl_AY();
                DataTable dtAY = new DataTable();
                dtAY = objtbl_AY.Select();
                DropDownList1.DataSource = dtAY;
                DropDownList1.DataTextField = "FY";
                DropDownList1.DataValueField = "AY";
                DropDownList1.DataBind();
                ListItem LstF = new ListItem(" -- Select -- ", "-1");
                DropDownList1.Items.Insert(0, LstF);
            }
        }
    }

    public void BindNewGrid()
    {
        if (Session["NameID"] != null)
        {
            if (Session["Project"].ToString() == "vt")
            {
                VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
                VGrid1.GridName = "AssesseeRets";
                VGrid1.Parameters = Session["NameID"].ToString();
                VGrid1.DataBind();
                VGrid1.HeaderStyle = "abc";
                VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
                VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
            }
            else if (Session["Project"].ToString() == "tds")
            {
                VGrid2.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
                VGrid2.GridName = "grd_DeducteeJobs";
                VGrid2.Parameters = Session["TAN"].ToString();
                VGrid2.DataBind();
                VGrid2.VGrid_RowCommand += new EventHandler(VGrid2_VGrid_RowCommand);
                VGrid2.VGrid_SelectedIndexChanged += new EventHandler(VGrid2_VGrid_SelectedIndexChanged);
                VGrid2.VGrid_PageIndexChanging += new EventHandler(VGrid2_VGrid_PageIndexChanging);
            }
        }
        
    }

    void VGrid2_VGrid_PageIndexChanging(object sender, EventArgs e)
    {
        hdnCG.Value = "";
    }

    void VGrid2_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = VGrid2.SelectedRow;
        int indx = 0;
        for(int i=0;i<ddFormType.Items.Count;i++)
        {
            if (ddFormType.Items[i].Text == dt.Rows[0][2].ToString())
                indx = i;                
        }
        Session["Job_ID"] = dt.Rows[0][0].ToString();
        ddFormType.SelectedIndex = indx;
        string FY_Selection = dt.Rows[0]["FY"].ToString();
        string[] arrFY = System.Text.RegularExpressions.Regex.Split(FY_Selection, "-");
        DropDownList1.SelectedValue = ((Convert.ToInt32(arrFY[0]) + 1).ToString() + "-" + (Convert.ToInt32(arrFY[1]) + 1).ToString());
        DropDownList3.SelectedValue = dt.Rows[0]["Quarter"].ToString();
        //txtTDSAY.Text = ((Convert.ToInt32(arrFY[0]) + 1).ToString() + "-" + (Convert.ToInt32(arrFY[1]) + 1).ToString());
        ddRetType.SelectedIndex = (dt.Rows[0][7].ToString() == "Regular") ? 1 : 2;
        //throw new NotImplementedException();
        hdnCG.Value = "valye";
        ddFormType.Attributes.Add("disabled", "true");
        DropDownList1.Attributes.Add("disabled", "true");
        DropDownList3.Attributes.Add("disabled", "true");
        ddRetType.Attributes.Add("disabled", "true");

        //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('abc');</script>");
    }

    void VGrid2_VGrid_RowCommand(object sender, EventArgs e)
    {
         GridView gv1 = (GridView)sender;
        DataTable dt = new DataTable();
        GridViewCommandEventArgs ee = (GridViewCommandEventArgs)e;
        string form_name = "";
        int grdIndx = 0;
        if (ee.CommandArgument != "")
        {
            grdIndx = Convert.ToInt32(ee.CommandArgument);
            form_name = ((Label)gv1.Rows[grdIndx].FindControl("Form Name")).Text;
        }

        int indx = 0;
        for (int i = 0; i < ddFormType.Items.Count; i++)
        {
            if (ddFormType.Items[i].Text == form_name)
                indx = i;

        }
        ddFormType.SelectedIndex = indx;
        string FY_Selection = ((Label)gv1.Rows[grdIndx].FindControl("FY")).Text;
        string[] arrFY = System.Text.RegularExpressions.Regex.Split(FY_Selection, "-");
        DropDownList1.SelectedValue = ((Convert.ToInt32(arrFY[0]) + 1).ToString() + "-" + (Convert.ToInt32(arrFY[1]) + 1).ToString());
        DropDownList3.SelectedValue = ((Label)gv1.Rows[grdIndx].FindControl("Quarter")).Text;
        //txtTDSAY.Text = ((Convert.ToInt32(arrFY[0]) + 1).ToString() + "-" + (Convert.ToInt32(arrFY[1]) + 1).ToString());
        ddRetType.SelectedIndex = 2;
        hdnCG.Value = "valye";
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //GridControl.VGrid vg1 = (GridControl.VGrid)sender;
        GridView gv1 = (GridView)sender;
        DataTable dt = new DataTable();
        GridViewCommandEventArgs ee = (GridViewCommandEventArgs)e;
        if (ee.CommandArgument != "")
        {
            int grdIndx = Convert.ToInt32(ee.CommandArgument);
            string Assessee_PAN = ((Label)gv1.Rows[grdIndx].FindControl("PAN")).Text;
            ddITR.SelectedValue = (((Label)gv1.Rows[grdIndx].FindControl("ITRType")).Text == "ITR-1") ? "1" : "8";
            DropDownList2.SelectedValue = ((Label)gv1.Rows[grdIndx].FindControl("AY")).Text;
            ddlReturnType.SelectedValue = "R";
            hdnVal = "testing";
            IsOrigRevised = "2";
            
        }
        else
            IsOrigRevised = "1";
        //vg1.SelectedRow
        row_AY.Style.Add("display", "none");
        row_DD.Style.Add("display", "none");
        row_ITR.Style.Add("display", "none");
        rowAmt.Style.Add("display", "none");
        //divEmployer.Style.Add("display", "none");
        divNotice.Style.Add("display", "none");
        divDON.Style.Add("display", "none");
        //divGovernedPortugese.Style.Add("display", "none");
        IsEditSelect = 1;        
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.SelectedRow;
        string strITRType = "";
        if (dtGrid.Rows[0][1].ToString() == "ITR-4S")
            strITRType = "8";
        else if (dtGrid.Rows[0][1].ToString() == "ITR-2A")
            strITRType = "9";
        else if (dtGrid.Rows[0][1].ToString() == "FORM3CEB")
            strITRType = "55";
        else if (dtGrid.Rows[0][1].ToString() == "FORM3CB3CD")
            strITRType = "56";
        else
            strITRType = dtGrid.Rows[0][1].ToString().Substring(dtGrid.Rows[0][1].ToString().IndexOf("-") + 1);
            //strITRType = dtGrid.Rows[0][1].ToString().Substring(dtGrid.Rows[0][1].ToString().Length - 1);

        //ddITR.SelectedValue = ((dtGrid.Rows[0][1].ToString() == "ITR-4S") ? "8" : dtGrid.Rows[0][1].ToString().Substring(dtGrid.Rows[0][1].ToString().Length - 1));
        ddITR.SelectedValue = strITRType;

        DropDownList2.SelectedValue = dtGrid.Rows[0][4].ToString();
        ddlReturnType.SelectedValue = ((dtGrid.Rows[0][5].ToString() == "Original") ? "O" : "R");
        //common objcommon = new common();
        //objcommon.SaveJob(Session["NameID"].ToString(), Session["userEmail"].ToString(), dtGrid.Rows[0][0].ToString());
        //setDataTransfer();
        ITRXML_ID = dtGrid.Rows[0][0].ToString();
        Session["AY"] = dtGrid.Rows[0][4].ToString();
        Session["ITR"] = strITRType; //(dtGrid.Rows[0][1].ToString() == "ITR-1") ? "1" : "8"; //for Itr-1 and ITR- 4s
        Session["Job_ID"] = dtGrid.Rows[0]["Job_ID"].ToString();
        Session["UpdateXML"] = "sel";
        row_AY.Style.Add("display", "none");
        row_DD.Style.Add("display", "none");
        row_ITR.Style.Add("display", "none");
        rowAmt.Style.Add("display", "none");
        //divEmployer.Style.Add("display", "none");
        divNotice.Style.Add("display", "none");
        divDON.Style.Add("display", "none");
        //divGovernedPortugese.Style.Add("display", "none");
        bllITR objbllITR = new bllITR();
        denITR objdenITR = new denITR();

        objdenITR = objbllITR.getITRData(Convert.ToInt64(Session["NameID"]), Session["AY"].ToString(), Session["ITR"].ToString());
        if (objdenITR.NameID != 0 && objdenITR.ITRType != "")
        {
            if (Session["AY"] != null)
            {
                restoreXML(objdenITR.XML_Data, objdenITR.ID);
            }
        }
        if (IsEdit != true)
        {
            IsEditSelect = 2;
            

            DataTable dtMain = new DataTable();
            dtMain = objbllStoreTrans.SelectData_Vtype(Session["NameID"].ToString(), "15062");
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                if (dtMain.Rows[i]["ConstantID"].ToString() == "27")
                    ddEmployer.SelectedValue = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "28")
                    ddlWhichSection.SelectedValue = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "34")
                    ddCivilCode.SelectedValue = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "35")
                    txtPAN.Text = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "30")
                    ddlReturnType.SelectedValue = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "31")
                    txtRecieptNo.Text = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "114")
                    txtDateofReturn.Text = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "37")
                    txtNotice.Text = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "62")
                    txtTRP_PIN.Text = dtMain.Rows[i]["Col3"].ToString();

                if (dtMain.Rows[i]["ConstantID"].ToString() == "29")
                    txtDON.Text = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "63")
                    txtTRPName.Text = dtMain.Rows[i]["Col3"].ToString();
                if (dtMain.Rows[i]["ConstantID"].ToString() == "64")
                    txtTRPPaid.Text = dtMain.Rows[i]["Col3"].ToString();

                // txtTRPPaid.Text
            }
            //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>removeItems();</script>");
        }
        else
        {
            IsEdit = false;
            IsEditSelect = 0;
           

            setDataTransfer();

            ////Adding tbl_ITRXML if not already exists
            //balXML objbalXML = new balXML();
            //objbalXML.AddXMLData(Session["NameID"].ToString(), Session["ITR"].ToString(), Session["AY"].ToString(), ddReturnType.SelectedValue);

            //common objcommon = new common();
            //objcommon.SaveJob(Session["NameID"].ToString(), Session["userEmail"].ToString(), ITRXML_ID);
        }
    }

    private void setDataTransfer()
    {
        bllDocTrans objbllDocTrans = new bllDocTrans();
        bool IsAdmin = false;
        if (Session["UserRole"] != null)
        {
            if (Session["UserRole"].ToString() == "FO")
            {
                IsAdmin = true;
            }
        }
        if (IsAdmin == false)
        {
            setEditMode();
            try
            {
                if (ddITR.SelectedValue != "")
                    Session["ITR"] = ddITR.SelectedValue;
                Session["ay"] = DropDownList2.SelectedItem.Text;
                hdnAY.Value = DropDownList2.SelectedItem.Text;
                string strDueDate = "";
                if (DropDownList2.SelectedItem.Text == "2014-2015")
                    Session["duedate"] = "31/07/2014";
                else if (DropDownList2.SelectedItem.Text == "2015-2016")
                    Session["duedate"] = "31/08/2015";
                else if (DropDownList2.SelectedItem.Text == "2016-2017")
                    Session["duedate"] = "31/07/2016";

                Session["ReturnType"] = ddlReturnType.SelectedItem.Text;
                denDocTrans objDocTransDEN = new denDocTrans();
                objDocTransDEN.NameID = Convert.ToString(Session["PAN"]);

                objDocTransDEN.ReturnType = ddlReturnType.SelectedValue;
                objDocTransDEN.RecieptNo = txtRecieptNo.Text;
                objDocTransDEN.FilingDate = txtDateofReturn.Text;
                objDocTransDEN.FBTFileSection = 0;
                objDocTransDEN.ReturnFiledUS = Convert.ToInt32(ddlWhichSection.SelectedValue);
                objDocTransDEN.IncomeFileSection = "";  //Convert.ToString(ddlROI.SelectedIndex);
                objDocTransDEN.SpouseName = txtSpouse.Text;

                objDocTransDEN.SpousePAN = txtPAN.Text;
                objDocTransDEN.IsGovernedByPortugeseCivilCodeunder5A = (ddCivilCode.SelectedIndex == 0) ? false : true;
                if (chkFirstReturn.Checked == true)
                    objDocTransDEN.FirstReturn = 1;
                if (chkFirstReturn.Checked == false)
                    objDocTransDEN.FirstReturn = 0;

                //if (chkTRP.Checked)
                //{
                objDocTransDEN.IsReturnByTRP = Convert.ToBoolean(chkTRP.Checked);
                objDocTransDEN.TRP_AmtToBePaid = (txtTRPPaid.Text != "") ? Convert.ToDouble(txtTRPPaid.Text) : 0;
                objDocTransDEN.TRP_Name = txtTRPName.Text;
                objDocTransDEN.TRP_PIN = txtTRP_PIN.Text;
                //}

                //Response.Redirect("saveAssessee.aspx?wx=1");
                bllITR objbllITR = new bllITR();
                denITR objdenITR = new denITR();
                int if_Exists = 0;  // objbllITR.getITRData_Main(Convert.ToInt64(Session["NameID"]), Session["AY"].ToString());    //to check if the assessee data exists in the storetrans_main
                bllSalary objbllSalary = new bllSalary();
                int[] arrVType = new int[1] { 106 };
                DataTable dtVType = new DataTable();
                dtVType = objbllStoreTrans.getVtypeData(arrVType, Session["AY"].ToString(), Session["ITR"].ToString(), Session["NameID"].ToString());
                if (dtVType.Rows.Count < 1)
                {
                    objdenITR = objbllITR.getITRData(Convert.ToInt64(Session["NameID"]), Session["AY"].ToString(), Session["ITR"].ToString());
                    if (objdenITR.NameID != 0 && objdenITR.ITRType != "")
                    {
                        if (Session["AY"] != null)
                        {
                            restoreXML(objdenITR.XML_Data, objdenITR.ID);
                        }
                    }
                }

                //Following is XML Restore Code:
                //if (if_Exists < 1)
                //{
                //    objdenITR = objbllITR.getITRData(Convert.ToInt64(Session["NameID"]), Session["AY"].ToString(), Session["ITR"].ToString());
                //    if (objdenITR.NameID != 0 && objdenITR.ITRType != "")
                //    {
                //        if (Session["AY"] != null)
                //        {
                //            restoreXML(objdenITR.XML_Data, objdenITR.ID);
                //        }
                //    }
                //    //updateMiscInfo(objDocTransDEN);
                //}
                //DataTable dtMain = new DataTable();
                //dtMain = objbllStoreTrans.SelectData_Vtype(Session["NameID"].ToString(), "15062");
                //for (int i = 0; i < dtMain.Rows.Count; i++)
                //{
                //    if (dtMain.Rows[i]["ConstantID"].ToString() == "27")
                //        ddEmployer.SelectedValue = dtMain.Rows[i]["Col3"].ToString();
                //}

                bllAssessee objbllAssessee = new bllAssessee();
                objbllAssessee.Add_AssesseeITR();   //To add Assessee Return Details
                denAssesseeIndividual objdenAssesseeIndividual = new denAssesseeIndividual();
                objdenAssesseeIndividual.EmployerCategory = ddEmployer.SelectedItem.Text;
                objbllAssessee.addEmployerCategory(Convert.ToString(Session["NameID"]), ddEmployer.SelectedIndex);
                objDocTransDEN.Auth_Name = "";
                objDocTransDEN.PAN = "";
                objDocTransDEN.Place = "";
                objDocTransDEN.Date = "";
                //if (Session["UpdateXML"] == "edt")
                //Added by Mudit ON 01/09/2015 for Inserting Main Page Data in StoreTrans
                //objbllDocTrans.InsertMainDataInStoreTrans(objDocTransDEN,Session["AY"].ToString(),"ITR-"+Session["ITR"].ToString(),ddEmployer.SelectedValue,Session["duedate"].ToString(),0);
                objbllMain.SetMainPageData(Session["NameID"].ToString(), Session["AY"].ToString(), Session["NameID"].ToString(), (ddEmployer.SelectedValue == "NA" ? "" : ddEmployer.SelectedValue), "", ddlWhichSection.SelectedValue, ddCivilCode.SelectedValue, txtPAN.Text, ddlReturnType.SelectedValue, txtRecieptNo.Text, txtDateofReturn.Text, txtDateofReturn.Text, txtRecieptNo.Text, txtNotice.Text, txtDON.Text, txtTRP_PIN.Text, txtTRPName.Text, txtTRPPaid.Text);
                txtDateofReturn.Text = "";
                if (Session["Project"].ToString() == "tds")
                {
                    Session["FormType"] = "";
                    Session["FY"] = "";
                }
                //bllITR objbllITR = new bllITR();
                //denITR objdenITR = new denITR();
                //objdenITR = objbllITR.getITRData(Convert.ToInt64(Session["NameID"]), Session["AY"].ToString(), Session["ITR"].ToString());
                //if (objdenITR.NameID != 0)
                //{
                //    bllStoreTrans objbllStoreTrans = new bllStoreTrans();
                //    objbllStoreTrans.deleteUser(Session["NameID"].ToString());
                //    string xmlPath = (Server.MapPath("../xml") + "\\" + Session["AY"].ToString() + "\\" + Session["NameID"].ToString() + "_" + Session["ITR"].ToString() + ".xml");
                //    string PAN = "0";
                //    objbllStoreTrans.resXML(Session["username"].ToString(), Session["AY"].ToString(), xmlPath, out PAN, Session["ITR"].ToString());
                //}


            }
            catch (Exception ex)
            {
                //throw ex;
                //Response.Redirect("DisplayForm.aspx");
            }
            //fetchTDSData();
            //if (lblMsg.Visible == false)

            //Adding tbl_ITRXML if not already exists
            balXML objbalXML = new balXML();
            string ss11 = ddlReturnType.Text;
            Int64 xmlID = objbalXML.AddXMLData(Session["NameID"].ToString(), Session["ITR"].ToString(), Session["AY"].ToString(), ((IsOrigRevised == "1") ? "O" : "R"));
            if (xmlID > 0)
                ITRXML_ID = Convert.ToString(xmlID);

            if (ITRXML_ID != "0")
            {
                Session["ITRXML_ID"] = ITRXML_ID.ToString();
                common objcommon = new common();
                objcommon.SaveJob(Session["NameID"].ToString(), Session["userEmail"].ToString(), ITRXML_ID);
                if (Session["Common_JobID"] != null)
                    Session["Job_ID"] = Session["Common_JobID"].ToString();

                //To find the first URL to be opened after going to Salary Page from Menu Proc:
                //bllMain objbllMain = new bllMain();
                DataTable dtMenu = new DataTable();
                dtMenu = objbllMain.getMenu(Session["ay"].ToString(), Session["ITR"].ToString(), Session["AssesseeType"].ToString(), Session["Project"].ToString(), Convert.ToInt64(Session["User_ID"]));

                Session["IncomeTax_VType"] = "40";
                if (Session["UpdateXML"] == "edt" || Session["Mode"] == "Edit")
                {
                    bllSalary objbllSalary = new bllSalary();
                    //string Vtype = Session["Vtype"].ToString();
                    //objbllSalary.FetchTransData("106", Session["NameID"].ToString(), Session["ay"].ToString());
                    //Response.Redirect("Salary.aspx?vtype=106");
                    if (Session["Status"].ToString() == "0" || Session["Status"].ToString() == "1")
                    {
                        Session["IncomeTax_VType"] = "106";
                        Response.Redirect("Profile");    //Response.Redirect("Salary.aspx?vtype=106"); //Response.Redirect(dtMenu.Rows[0]["Menu_Link"].ToString());        //Response.Redirect("Individual.aspx");
                    }
                    else// if (Session["Status"].ToString() == "1")
                        Response.Redirect("HUF.aspx");
                }
                else if (Session["UpdateXML"] == "sel")
                {
                    //if (objbllStoreTrans.getDataCount(Session["NameID"].ToString()) > 0)
                    //{
                        if (dtMenu.Rows.Count > 0)
                        {
                            if (Session["project"].ToString() == "vt")
                                Session["IncomeTax_VType"] = (dtMenu.Rows[0]["Menu_Link"].ToString().Contains("40")) ? "40" : "42";
                            else
                                Session["IncomeTax_VType"] = (dtMenu.Rows[0]["Menu_Link"].ToString().Contains("3001")) ? "3001" : "3001";
                        }
                        else
                            Session["IncomeTax_VType"] = "40";

                        //Response.Redirect((dtMenu.Rows.Count > 0) ? dtMenu.Rows[0]["Menu_Link"].ToString() : "Salary.aspx?vtype=40");        //Response.Redirect("Salary.aspx?vtype=40");
                        Response.Redirect("IncomeTax");
                    //}
                    //else
                    //    Response.Redirect("IncomeTax");
                }
            }
            else
            {
                //lblErrMsg.Text = "<span style='font-weight:Bold;color:red;'>Can't have multiple Returns within same AY</span>";
                ClientScript.RegisterClientScriptBlock(GetType(), "Error", "<script type='text/javascript'>getPopup(); </script>");
            }
            //objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["ay"].ToString(), "", "1", Session["duedate"].ToString(), 0);
        }
        else
        {
            bllAssesseeMaster objbllAssesseeMaster = new bllAssesseeMaster();
            denAssesseeMaster objdenAssesseeMaster = new denAssesseeMaster();
            objdenAssesseeMaster.NameID = Convert.ToInt64(Session["NameID"]);
            objdenAssesseeMaster.AY = DropDownList2.SelectedItem.Text;
            hdnAY.Value = DropDownList2.SelectedItem.Text;
            objdenAssesseeMaster.ReturnType = ddlReturnType.SelectedValue;
            objdenAssesseeMaster.Amount = (txtAmtRec.Text != "") ? Convert.ToDouble(txtAmtRec.Text) : 0;
            Int64 ID = 0;
            ID = objbllAssesseeMaster.update(objdenAssesseeMaster);

            blltbl_ProcessesHistoryofjob objblltbl_ProcessesHistoryofjob = new blltbl_ProcessesHistoryofjob();
            dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob = new dentbl_ProcessesHistoryofjob();
            objdentbl_ProcessesHistoryofjob.Supervisor = "Deepak";
            objdentbl_ProcessesHistoryofjob.Reason_for_Delay = "";
            objdentbl_ProcessesHistoryofjob.Priority_of_Job = 1;
            objdentbl_ProcessesHistoryofjob.Previous_UserID = 1;
            objdentbl_ProcessesHistoryofjob.Next_UserID = 1;
            objdentbl_ProcessesHistoryofjob.MasterID = ID;
            objdentbl_ProcessesHistoryofjob.Job_Status = "ABC";
            objdentbl_ProcessesHistoryofjob.Is_Sent = "T";
            objdentbl_ProcessesHistoryofjob.Date_Time_Stamp = "";
            objblltbl_ProcessesHistoryofjob.InsertDataMainGrid(objdentbl_ProcessesHistoryofjob);
            Response.Redirect("Main.aspx");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["Dir_Path"] = "";
        setDataTransfer();
    }

    protected void dny_Grd_ITRInfo_grd_SelectedIndexChanging(object sender, EventArgs e)
    {
        btnAddRet.Visible = true;
        //hdnVal = "edt~1";
        ////btTest_Click(sender, e);
        ////ScriptManager1.RegisterDataItem(hdnActiveIndx, "1");
        ////hdnActiveIndx.Value = "1";//hdnActiveIndx.Value = "1";
        //hdnActiveIndx.Value = "edt~2";
        //Session["UpdateXml"] = "edt";
        //mltView.ActiveViewIndex = 1;
    }

    protected void dny_Grd_ITRInfo_grd_EditIndex(object sender, EventArgs e)
    {
        if (Session["Project"].ToString() == "vt" || Session["Project"].ToString() == "stax")
        {
            GridViewEditEventArgs ee = (GridViewEditEventArgs)e;
            GridView grd = (GridView)dny_Grd_ITRInfo.FindControl("Dynamic_Gridview");
            DataTable dt = (DataTable)grd.DataSource;
            int ii = (grd.PageIndex * 10) + ee.NewEditIndex;
            //for Master Page Redirect:

            Session["Exists"] = 1;
            Session["Bool"] = "False";
            Session["Mode"] = "Edit";
            Session["PAN"] = Convert.ToString(dt.Rows[ii]["PanNo"].ToString());
            Session["Status"] = dt.Rows[ii]["Status"].ToString();
            Session["NameID"] = dt.Rows[ii]["ID"].ToString();
            Session["E_NameID"] = null;
            Session["restore"] = null;
            Session["AssesseeType"] = dt.Rows[ii]["Status"].ToString(); //Session["AssesseeType"] = "Individual";
            Session["AType"] = "";
            Session["DateofBirth"] = dt.Rows[ii]["DateOfBirth"].ToString();
            Session["ITR"] = "1";
            Session["ay"] = "2014-2015";// Session["AY"].ToString();    default 14-15 for edi
            hdnAY.Value = "2014-2015";
            if (Session["duedate"] != null)
                Session["duedate"] = "31-07-2014";
            //Changed by Mudit on 16/06/2015 for Generic Procedures
            //Response.Redirect("Individual.aspx");
            bllSalary objbllSalary = new bllSalary();
            //string Vtype = Session["Vtype"].ToString();
            //objbllSalary.FetchTransData("106", Session["NameID"].ToString(), Session["ay"].ToString());
            //Response.Redirect("Salary.aspx?vtype=106");

            //Edit For 106:
            //mltView.ActiveViewIndex = 1;
            //LinkButton lnkName2 = new LinkButton();

            //if (Session["Project"].ToString() == "vt")
            //    Session["tab"] = "1";
            //else
            //    Session["tab"] = "5";
            //IsLnkClicked = true;

            //mltView.ActiveViewIndex = 1;
            //setITR();
            //setAssessmentDetails();
            //Edit for 106 complete
            //hdnActiveIndx.Value = "1";
            //btTest_Click(sender, e);
            hdnVal = "edt~" + ii.ToString();
            //ScriptManager1.RegisterDataItem(hdnActiveIndx, "1");
            //hdnActiveIndx.Value = "1";//hdnActiveIndx.Value = "1";

            Session["UpdateXml"] = "edt";
            mltView.ActiveViewIndex = 1;
            //Response.Redirect(Request.Url.ToString());
            //lblHdnLbl.Text = hdnActiveIndx.Value;
            //Response.Redirect("AssesseeSelect.aspx");

            //Response.Redirect("Individual.aspx");
            //hdn3.Value = "Value Changed in Edit";
            hdnVal = "Value Changed in Edit";
            try
            {
                ScriptManager1.RegisterDataItem(hdn3, hdnVal);
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            GridViewEditEventArgs ee = (GridViewEditEventArgs)e;
            GridView grd = (GridView)dny_Grd_ITRInfo.FindControl("Dynamic_Gridview");
            DataTable dt = (DataTable)grd.DataSource;
            int ii = (grd.PageIndex * 10) + ee.NewEditIndex;
            string editTAN = grd.Rows[ii].Cells[6].Text;
            Session["IsEditTAN"] = "Edit";
            Session["EditTAN"] = editTAN;

            Response.Redirect("TANMaster.aspx");
        }
        IsEditSelect = 1;
        IsEdit = true;
        btnAddRet.Visible = false;
        btnImportReturn.Visible = false;

        if (Session["Project"].ToString() == "vt")
            Session["tab"] = "1";
        else
            Session["tab"] = "5";
        Response.Redirect("Main.aspx");
    }

    private void setITR()
    {
        bllITR objbllITR = new bllITR();
        DataTable dt = new DataTable();
        dt = objbllITR.SelectITR(Session["Project"].ToString());

        if (Session["Project"].ToString() == "vt")
        {
            ddITR.DataSource = dt;
            ddITR.DataTextField = "detail";
            ddITR.DataValueField = "title";
            ddITR.DataBind();
        }
        else if (Session["Project"].ToString() == "tds")
        {
            ddFormType.DataSource = dt;
            ddFormType.DataTextField = "detail";
            ddFormType.DataValueField = "detail";
            ddFormType.DataBind();
        }

        //ListItem Lst1 = new ListItem("ITR-1", "1");
        //ListItem Lst2 = new ListItem("ITR-2", "2");
        //ListItem Lst3 = new ListItem("ITR-3", "3");
        //ListItem Lst4 = new ListItem("ITR-4", "4");
        //ListItem Lst5 = new ListItem("ITR-5", "5");
        //ListItem Lst6 = new ListItem("ITR-6", "6");
        //ListItem Lst7 = new ListItem("ITR-7", "7");
        //ListItem Lst8 = new ListItem("ITR-4S", "8");
        //ListItem Lst9 = new ListItem("ITR-2A", "9");
        //ListItem Lst10 = new ListItem("Form3CB", "43");
        //ListItem Lst11 = new ListItem("Form15G", "50");
        //ListItem Lst12 = new ListItem("Form15H", "51");
        //ListItem Lst13 = new ListItem("Form26G", "53");
        //if (Session["Status"] != null)
        //{
        //    ddITR.Items.Clear();
        //    if (Session["Status"].ToString() == "1" || Session["Status"].ToString() == "0")
        //    {
        //        ddITR.Items.Add(Lst1);
        //        //ddITR.Items.Add(Lst2);
        //        //ddITR.Items.Add(Lst3);
        //        //ddITR.Items.Add(Lst4);
        //        //ddITR.Items.Add(Lst5);
        //        //ddITR.Items.Add(Lst6);
        //        //ddITR.Items.Add(Lst7);
        //        ddITR.Items.Add(Lst8);
        //        ddITR.Items.Add(Lst11);
        //        //ddITR.Items.Add(Lst9);
        //        //ddITR.Items.Add(Lst10);
        //    }
        //    else if (Session["Status"].ToString() == "2")
        //    {
        //        //code by nishu for change itr dropdown entries  
        //        ddITR.Items.Add(Lst8);
        //        ddITR.Items.Add(Lst1);
        //        //ddITR.Items.Add(Lst2);
        //        //ddITR.Items.Add(Lst3);
        //        //ddITR.Items.Add(Lst4);
        //        //ddITR.Items.Add(Lst8);
        //        //ddITR.Items.Add(Lst7);

        //    }
        //    else if (Session["Status"].ToString() == "3")
        //    {
        //        ddITR.Items.Add(Lst5);
        //        ddITR.Items.Add(Lst7);

        //    }
        //    else if (Session["Status"].ToString() == "4")
        //    {
        //        ddITR.Items.Add(Lst6);
        //        ddITR.Items.Add(Lst7);

        //    }
        //    else if (Session["Status"].ToString() == "5" || Session["Status"].ToString() == "6" || Session["Status"].ToString() == "7")
        //    {
        //        ddITR.Items.Add(Lst5);
        //        ddITR.Items.Add(Lst7);
        //    }
        //    else if (Session["Status"].ToString() == "8")
        //    {
        //        ddITR.Items.Add(Lst5);
        //    }
        //    else if (Session["Status"].ToString() == "9")
        //    {
        //        ddITR.Items.Add(Lst5);
        //        ddITR.Items.Add(Lst7);
        //    }
        //}
        //else    //For Other cases (specific to the one where user came from E-File Yourself in this case) but can be used for other cases too
        //{
        //    if (Session["Project"].ToString() == "vt")
        //    {
        //        ddITR.Items.Clear();
        //        ddITR.Items.Add(Lst1);
        //        ddITR.Items.Add(Lst2);
        //        ddITR.Items.Add(Lst3);
        //        ddITR.Items.Add(Lst4);
        //        ddITR.Items.Add(Lst5);
        //        ddITR.Items.Add(Lst6);
        //        ddITR.Items.Add(Lst7);
        //        ddITR.Items.Add(Lst8);
        //        ddITR.Items.Add(Lst9);
        //        ddITR.Items.Add(Lst10);
        //    }
        //}
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["Project"] != null && Session["UserName"] != null)
        {
            if (Session["Project"].ToString() == "vt" || Session["Project"].ToString() == "stax")
            {
                //gvTDS.DataSource = "";
                //GridView1.DataSource = ObjectDataSource1;
                //GridView1.DataBind();

                DynamicControl.Parameters = Session["UserName"].ToString();
                if (Session["Account_Type"] != null)
                {
                    if (Session["Account_Type"].ToString() == "BMC")
                    {
                        dny_Grd_ITRInfo.GridName = "grd_AssesseeListBMC";
                        dny_Grd_ITRInfo.Page_ID = "539";
                        dny_Grd_ITRInfo.Page_SubModule_ID = "2067";

                    }
                    else
                    {
                        dny_Grd_ITRInfo.GridName = "grd_AssesseeList";
                        dny_Grd_ITRInfo.Page_ID = "537";
                        dny_Grd_ITRInfo.Page_SubModule_ID = "64";
                    }
                }
                else if (Session["Project"].ToString() == "stax")
                {
                    dny_Grd_ITRInfo.GridName = "grd_AssesseeListSTAX";
                    dny_Grd_ITRInfo.Page_ID = "538";
                    dny_Grd_ITRInfo.Page_SubModule_ID = "1067";
                }
                else
                {
                    dny_Grd_ITRInfo.GridName = "grd_AssesseeList";
                    dny_Grd_ITRInfo.Page_ID = "537";
                    dny_Grd_ITRInfo.Page_SubModule_ID = "64";
                }

                balAdmin objbalAdmin = new balAdmin();
                cntGrid = objbalAdmin.getCGCount(dny_Grd_ITRInfo.GridName, Session["UserName"].ToString());
                lblMainTitle.Text = "LIST OF ASSESSEES";

                //if (Session["NameID"] != null)
                //    DynamicControl.Parameters = Session["NameID"].ToString();

                //dny_Grd_Returns2.GridName = "grd_OldReturns";
                //dny_Grd_Returns2.Page_ID = "530";
                //dny_Grd_Returns2.Page_SubModule_ID = "59";
            }
            else
            {
                //gvTDS.DataSource = ObjectDataSource5;
                //gvTDS.DataBind();

                DynamicControl.Parameters = Session["UserEmail"].ToString();// Session["User_ID"].ToString();
                dny_Grd_ITRInfo.GridName = "grd_TANList";
                dny_Grd_ITRInfo.Page_ID = "536";
                dny_Grd_ITRInfo.Page_SubModule_ID = "63";
                btnAddAssessee.Text = "Add New Deductor";
                //GridView1.DataSource = "";
                //GridView1.DataBind();
                lblMainTitle.Text = "List of Deductors";
            }
        }
    }

    //void dny_Grd_Returns2_grd_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //Get the Datakey of the Selected Record from Gridview
    //    GridView grd = (GridView)dny_Grd_Returns2.FindControl("Dynamic_Gridview");
    //    //var Job_ID = Convert.ToInt32(grd.SelectedDataKey.Value).ToString();
    //    Int64 ID = Convert.ToInt64(grd.SelectedDataKey.Value);//.ToString();
    //    ////Get the DataSource

    //    DataTable dt = (DataTable)grd.DataSource;
    //    bllITR objbllITR = new bllITR();
    //    denITR objdenITR = new denITR();

    //    objdenITR = objbllITR.fetchData(ID);

    //    Session["ay"] = objdenITR.AY;
    //    Session["Status"] = "0";
    //    Session["ITR"] = objdenITR.ITRType;

    //    bllMain objMainBLL;
    //    denMain objMainDEN;
    //    objMainBLL = new bllMain();
    //    audit = 0;
    //    if (chkAccountAudited.Checked == true)
    //        audit = 1;
    //    else if (chkAccountAudited.Checked == false)
    //        audit = 0;

    //    objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), Convert.ToInt32(Session["Status"]), audit);
    //    Session["duedate"] = objMainDEN.DueDate;
    //    restoreXML();
    //    Response.Redirect("DisplayForm.aspx");
    //}

    protected void dny_Grd_ITRInfo_grd_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ii = 0;
        if (Session["Project"] != null)
        {
            if (Session["Project"].ToString() == "vt" || Session["Project"].ToString() == "stax")
            {

                //Get the Datakey of the Selected Record from Gridview
                GridView grd = (GridView)dny_Grd_ITRInfo.FindControl("Dynamic_Gridview");
                if (grd.SelectedDataKey != null)
                {
                    DataTable dt = (DataTable)grd.DataSource;
                    //var Job_ID = Convert.ToInt32(grd.SelectedDataKey.Value).ToString();
                    Int64 ID = Convert.ToInt64(grd.SelectedDataKey.Value);//.ToString();
                    ////Get the DataSource
                    ii = (grd.PageIndex * 10) + grd.SelectedIndex;
                    //this session variable is to check whether the assessee is going to Assesseeform through login or direct
                    //if he goes direct then this variable will <>1 and the form will be empty.
                    Session["Exists"] = 1;
                    Session["Bool"] = "False";
                    Session["Mode"] = "New";
                    Session["PAN"] = dt.Rows[ii]["PANNo"].ToString();
                    Session["Status"] = dt.Rows[ii]["Status"].ToString();
                    Session["NameID"] = dt.Rows[ii]["ID"].ToString();
                    Session["E_NameID"] = null;
                    Session["restore"] = null;
                    Session["AssesseeType"] = dt.Rows[ii]["Status"].ToString();
                    Session["AType"] = "";

                    //Session["DateofBirth"] = row.Cells[5].Text;

                    //dd = Convert.ToDateTime(Parse(row.Cells[6].Text));
                    Session["DateofBirth"] = dt.Rows[ii]["DateOfBirth"].ToString(); //(dd.Year + "-" + ((dd.Month.ToString().Length > 1) ? dd.Month.ToString() : ("0" + dd.Month.ToString())) + "-" + dd.Day).ToString();

                    mltView.ActiveViewIndex = 1;
                    LinkButton lnkName2 = new LinkButton();

                    if (Session["Project"].ToString() == "vt")
                        Session["tab"] = "1";
                    else
                        Session["tab"] = "5";
                    IsLnkClicked = true;

                    if (Session["Project"].ToString() == "vt")
                        mltView.ActiveViewIndex = 1;
                    else
                        mltView.ActiveViewIndex = 5;

                    //hdnActiveIndx.Value = mltView.ActiveViewIndex.ToString();
                    ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('" + mltView.ActiveViewIndex.ToString() + "'); </script>");



                    setITR();
                    setAssessmentDetails(); //for such an assessee for which XML File was already developed before

                    bllDocTrans objbllDocTrans = new bllDocTrans();
                    StateID = objbllDocTrans.getState(Session["NameID"].ToString());
                    Session["UpdateXml"] = "sel";
                    btTest_Click(sender, e);
                    hdnVal = "edt~" + ii.ToString();
                    IsEditSelect = 0;
                    
                    Response.Redirect("Main.aspx");
                    //Response.Redirect("Main.aspx?rid=1");
                }
            }
            else
            {
                //Get the Datakey of the Selected Record from Gridview
                GridView grd = (GridView)dny_Grd_ITRInfo.FindControl("Dynamic_Gridview");
                //var Job_ID = Convert.ToInt32(grd.SelectedDataKey.Value).ToString();
                Int64 ID = Convert.ToInt64(grd.SelectedDataKey.Value);//.ToString();
                ////Get the DataSource
                ii = (grd.PageIndex * 10) + grd.SelectedIndex;
                DataTable dt = (DataTable)grd.DataSource;
                bllITR objbllITR = new bllITR();
                denITR objdenITR = new denITR();
                Session["Exists"] = 1;
                Session["Bool"] = "False";
                Session["Mode"] = "New";
                Session["Name"] = dt.Rows[ii]["Name"].ToString();
                Session["TAN"] = dt.Rows[ii]["TAN"].ToString();
                Session["PAN"] = dt.Rows[ii]["PAN"].ToString();
                Session["Status"] = "0";
                Session["NameID"] = ID;
                Session["E_NameID"] = null;
                Session["restore"] = null;
                Session["AssesseeType"] = "";// Convert.ToString(row.Cells[2].Text);

                Session["ay"] = "2014-2015";
                Session["AY"] = "2014-2015";
                hdnAY.Value = "2014-2015";
                Session["ITR"] = "1";
                //mltView.ActiveViewIndex = 1;
                //Response.Redirect("DisplayForm.aspx");

                lblTAN.Text = Session["TAN"].ToString();
                lblTDSName.Text = Session["Name"].ToString();
                lblTDSPAN.Text = Session["PAN"].ToString();
                Button2.Visible = true;
                IsLnkClicked = true;
                mltView.ActiveViewIndex = 4;
                ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('" + mltView.ActiveViewIndex.ToString() + "'); </script>");

                bllDocTrans objbllDocTrans = new bllDocTrans();
                StateID = objbllDocTrans.getState(Session["NameID"].ToString());
                Session["UpdateXml"] = "sel";
                btTest_Click(sender, e);
                hdnVal = "edt~" + ii.ToString();

                Session["tab"] = "4";
                Session["IncomeTax_VType"] = "3001";
                Response.Redirect("Main.aspx");
            }
        }

        //BindNewGrid();

        string strhright = VGrid1.Height.Value.ToString();
        IsEditSelect = 2;
    }

    protected void butSubmit_Click(object sender, EventArgs e)
    {
        if (Session["Project"].ToString() == "vt")
            mltView.ActiveViewIndex = 1;
        else if (Session["Project"].ToString() == "tds")
        {
            if (Session["TAN"] != null)
            {
                mltView.ActiveViewIndex = 4;

                lblTAN.Text = Session["TAN"].ToString();
                lblTDSName.Text = Session["Name"].ToString();
                lblTDSPAN.Text = Session["PAN"].ToString();

                Button2.Visible = true;
            }
            else
                mltView.ActiveViewIndex = 0;
        }
        else
        {
            mltView.ActiveViewIndex = 5;
            ddFY.DataSource = objbllMain.GetFinYear();
            ddFY.DataTextField = "AssYear";
            ddFY.DataValueField = "AssYear";
            ddFY.DataBind();
            setDueDateForStax();
        }
    }

    protected void txtDateofReturn_TextChanged(object sender, EventArgs e)
    {
        string[] arrDate = System.Text.RegularExpressions.Regex.Split(txtDateofReturn.Text, "/");
        if (Convert.ToDateTime(txtDateofReturn.Text) > DateTime.Now)
        //if (Convert.ToDateTime(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]) > DateTime.Now)
        {
            //txtDateofReturn.Text = "";
            lblDateErr.Text = "Invalid Date";
            lblDateErr.ForeColor = System.Drawing.Color.Red;
            lblDateErr.Visible = true;
        }
        else
        {
            DateTime dt_StandardDate = new DateTime(Convert.ToInt32(Session["AY"].ToString().Substring(0, 4)), 4, 1);
            //if (Convert.ToDateTime(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]) < dt_StandardDate)
            if (Convert.ToDateTime(txtDateofReturn.Text) < dt_StandardDate)
            {
              //  txtDateofReturn.Text = "";
                lblDateErr.Text = "Invalid Date";
                lblDateErr.ForeColor = System.Drawing.Color.Red;
                lblDateErr.Visible = true;
            }
            else
                lblDateErr.Text = "";
        }
        setSection();
    }

    public void setAssessmentDetails()
    {
        //Code Written By Mudit For Managing Master Data Of DropDowns from database That Come After Selecting Assessee from Grid
        //The page life cycle is still to be check by Ankush Sir.....23/06/2015
        bllMain objbllMain = new bllMain();
        DataTable dt = new DataTable();
        if (Session["NameID"] != null)
        {
            string NameID = Session["NameID"].ToString();
            dt = objbllMain.GetDetails(Session["NameID"].ToString());
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["EmployerCategory"].ToString() != "")
                {
                    ddEmployer.SelectedIndex = (dt.Rows[0].IsNull(0) == false) ? Convert.ToInt16(dt.Rows[0]["EmployerCategory"]) : 0;
                    ddlWhichSection.SelectedValue = (dt.Rows[0]["ReturnFiledUnderSection"].ToString() != "0") ? dt.Rows[0]["ReturnFiledUnderSection"].ToString() : ddlWhichSection.SelectedValue;
                    if (dt.Rows[0]["ReturnType"].ToString() == "Original")
                        ddlReturnType.SelectedIndex = 0;
                    else
                    {
                        ddlReturnType.SelectedIndex = 1;
                        txtRecieptNo.Visible = true;
                        txtDateofReturn.Visible = true;
                        txtRecieptNo.Text = dt.Rows[0]["AckNoOriginalReturn"].ToString();
                        txtDateofReturn.Text = dt.Rows[0]["FilingDate"].ToString();
                    }
                    ddCivilCode.SelectedIndex = Convert.ToInt16(dt.Rows[0]["IsGovernedByPortugeseCivilCodeunder5A"]);
                    if (ddCivilCode.SelectedIndex > 0)
                    {
                        txtSpouse.Visible = true;
                        txtPAN.Visible = true;
                        txtSpouse.Text = dt.Rows[0]["SpouseName"].ToString();
                        txtPAN.Text = dt.Rows[0]["PANOfSpouse"].ToString();
                    }
                    if (dt.Rows[0]["IsReturnByTRP"].ToString() == "1")
                    {
                        chkTRP.Checked = true;
                        txtTRP_PIN.Visible = true;
                        txtTRPName.Visible = true;
                        txtTRPPaid.Visible = true;
                        txtTRP_PIN.Text = dt.Rows[0]["TRP_PIN"].ToString();
                        txtTRPName.Text = dt.Rows[0]["TRName"].ToString();
                        txtTRPPaid.Text = dt.Rows[0]["TRP_AmtToBePaid"].ToString();
                    }
                }
            }
        }
    }

    public void restoreXML(string strXML, Int64 ID)
    {
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        string ITR = "";
        string PAN = "";
        string ss = Session["AY"].ToString();
        ss = Session["NameID"].ToString();
        ss = Session["ITR"].ToString();
        
        //string filePath = Server.MapPath("../xml/") + Session["AY"].ToString() + "/" + Session["NameID"].ToString() + "_" + Session["ITR"].ToString() + ".xml";
        //string strXML = File.ReadAllText(filePath);

        if (Session["ITR"].ToString() == "8")
            ITR = "4s";
        else
            ITR = Session["ITR"].ToString();

        //if (strXML.Length > 1)
        //{
            //objbllStoreTrans.resXML(Session["UserName"].ToString(), Session["AY"].ToString(), filePath, out PAN, ITR);
            //objbllStoreTrans.resXML(strXML, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/")).ToString(), ITR, (Session["NameID"] == null) ? "0" : Session["NameID"].ToString(), out PAN, 0);

            //objbllStoreTrans.resXMLInv(Session["AY"].ToString(), Session["UserName"].ToString(), ITR.ToString(), ID, out PAN);
            objbllStoreTrans.resXMLInv(Session["NameID"].ToString(), Session["AY"].ToString(), out PAN, Convert.ToInt32(Session["ITR"]));
            bllAssessee objbllAssessee = new bllAssessee();
            denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
            //objAssesseeIndividual = objbllAssessee.GetDataIndividual(PAN);
            //Session["NameID"] = objAssesseeIndividual.NameID;
            Session["restore"] = "true";
            Session["PAN"] = PAN;


            denMain objMainDEN = new denMain();
            bllMain objMainBLL = new bllMain();

            objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), 0, 0, StateID);
            string[] arrDate = System.Text.RegularExpressions.Regex.Split(objMainDEN.DueDate, "/");

            DateTime dtime = new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]));

        //}
        // DateTime dtime = Convert.ToDateTime("21/02/2009", new CultureInfo("en-US", true));
        //dtime.Month+"/"+dtime.Day+"/"+dtime.Year
        //Session["ITR"] = "1";
        //Session["ay"] = Session["AY"];
        //Session["duedate"] = objMainDEN.DueDate;

        hdnAY.Value = Session["AY"].ToString();
        //Response.Redirect("DisplayForm.aspx");
    }


    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    GridView1.DataSource = ObjectDataSource1;
    //    GridView1.DataBind();
    //}

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            string[] arr = System.Text.RegularExpressions.Regex.Split(e.CommandArgument.ToString(), "~");
            Session["PAN"] = arr[0];
            Session["NameID"] = arr[2];
            Session["Mode"] = "Edit";
            if (Session["project"].ToString() == "vt")
            {
                if (arr[1] == "0" || arr[1] == "1")
                    Response.Redirect("individual.aspx");
                else if (arr[1] == "2")
                    Response.Redirect("HUF.aspx");
                else if (arr[1] == "3")
                    Response.Redirect("Partnership.aspx");
                else if (arr[1] == "4")
                    Response.Redirect("Company.aspx");
                else if (arr[1] == "5")
                    Response.Redirect("AOP.aspx");
                else if (arr[1] == "6")
                    Response.Redirect("Cooperative.aspx");
            }
            else if (Session["project"].ToString() == "stax")
            {
                Response.Redirect("STaxMaster.aspx");
            }
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //e.InputParameters["intVtype"] = Convert.ToInt16(ViewState["vtype"]);
        e.InputParameters["UserName"] = Convert.ToString(Session["UserName"]);
        e.InputParameters["TypeOfAss"] = (Session["project"].ToString() == "vt") ? "0" : "1";
    }

    protected void btnAddAssessee_Click(object sender, EventArgs e)
    {
        Session["TAN"] = null;
        Session["Mode"] = "New";
        Session["Bool"] = "False";
        string sss = Session["Project"].ToString();
        if (Session["Project"].ToString() == "vt" || Session["Project"].ToString() == "stax")
        {
            Response.Redirect("Assesseeselect.aspx");
        }
        else if (Session["Project"].ToString() == "tds")
        {
            Session["IsEditTAN"] = null;
            Response.Redirect("TANMaster.aspx");
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Request.QueryString["ut"] != null && Session["ITRXML_ID"] != null && !IsPostBack)
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>hideIt_Original();</script>");
        }
        else
        {
            //GridView grd = (GridView)dny_Grd_ITRInfo.FindControl("Dynamic_Gridview");
            //if (grd.Rows.Count < 1)
            //{
            //    //dny_Grd_ITRInfo.Visible = false;
            //    lblMainTitle.Visible = false;
            //    ControlGrid.Visible = false;
            //    pnlNoRecord.Visible = true;
            //    //btnBack2.Visible = true;
            //    if (cntGrid > 0)
            //        btnBackToRec.Visible = true;
            //    else
            //        btnBackToRec.Visible = false;
            //}
            //else
            //    btnBackToRec.Visible = false;
            //DataTable dt = new DataTable();
            //dt = dny_Grd_ITRInfo.Get_Data("grd_AssesseeList", "537", "64");
            
            if (IsEditSelect == 11)
                ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>hideIt();</script>");
            else if (IsEditSelect == 2)
                ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>hideIt_Original();</script>");

            IsEditSelect = 0;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            Label lblSNO = new Label();
            lblSNO = (Label)e.Row.FindControl("lblSNO");
            lblSNO.Text = (e.Row.RowIndex + 1).ToString();
        }
    }

    protected void lnkName_Click(object sender, EventArgs e)
    {
        Control btnLnk = (Control)sender;
        GridViewRow row = (GridViewRow)btnLnk.NamingContainer;
        //this session variable is to check whether the assessee is going to Assesseeform through login or direct
        //if he goes direct then this variable will <>1 and the form will be empty.
        Session["Exists"] = 1;
        Session["Bool"] = "False";
        Session["Mode"] = "Edit";
        Session["PAN"] = Convert.ToString(row.Cells[2].Text);
        Session["Status"] = Convert.ToInt32(row.Cells[4].Text);
        Session["NameID"] = row.Cells[5].Text;
        Session["E_NameID"] = null;
        Session["restore"] = null;
        Session["AssesseeType"] = Convert.ToString(row.Cells[3].Text);
        Session["AType"] = "";

        //Session["DateofBirth"] = row.Cells[5].Text;

        //dd = Convert.ToDateTime(Parse(row.Cells[6].Text));
        Session["DateofBirth"] = row.Cells[6].Text; //(dd.Year + "-" + ((dd.Month.ToString().Length > 1) ? dd.Month.ToString() : ("0" + dd.Month.ToString())) + "-" + dd.Day).ToString();

        mltView.ActiveViewIndex = 1;
        LinkButton lnkName2 = new LinkButton();

        if (Session["Project"].ToString() == "vt")
            Session["tab"] = "1";
        else
            Session["tab"] = "5";
        IsLnkClicked = true;

        Response.Redirect("Main.aspx?rid=1");
        // SubUserMenu uc = (SubUserMenu)this.Parent.FindControl("sub1");

        //WebUserControl2 uc = (WebUserControl2)this.Parent.FindControl("c2");
        //uc.Page_Load(uc, EventArgs.Empty);
    }

    protected void lnkName2_Click(object sender, EventArgs e)
    {
        Control btnLnk = (Control)sender;
        GridViewRow row = (GridViewRow)btnLnk.NamingContainer;
        //this session variable is to check whether the assessee is going to Assesseeform through login or direct
        //if he goes direct then this variable will <>1 and the form will be empty.
        Session["Exists"] = 1;
        Session["Bool"] = "False";
        Session["Mode"] = "Edit";
        Session["Name"] = ((LinkButton)btnLnk).Text;
        Session["TAN"] = Convert.ToString(row.Cells[2].Text);
        Session["PAN"] = Convert.ToString(row.Cells[3].Text);
        Session["Status"] = "0";
        Session["NameID"] = row.Cells[4].Text;
        Session["E_NameID"] = null;
        Session["restore"] = null;
        Session["AssesseeType"] = "";// Convert.ToString(row.Cells[2].Text);

        Session["ay"] = "2014-2015";
        Session["AY"] = "2014-2015";
        Session["ITR"] = "1";
        //mltView.ActiveViewIndex = 1;
        //Response.Redirect("DisplayForm.aspx");

        lblTAN.Text = Session["TAN"].ToString();
        lblTDSName.Text = Session["Name"].ToString();
        lblTDSPAN.Text = Session["PAN"].ToString();
        Button2.Visible = true;
        mltView.ActiveViewIndex = 4;

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

    protected void ddlWhichSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        setSection();
    }

    private void setSection()
    {
        if (ddlWhichSection.SelectedValue == "17")
        {
            ddlReturnType.SelectedIndex = 1;
        }
        else
        {
            ddlReturnType.SelectedIndex = 0;
        }
        ddlReturnType.Enabled = false;

        if (ddlReturnType.SelectedIndex == 1 || ddlWhichSection.SelectedValue == "18")
        {
            lblRecieptNO.Visible = true;
            txtRecieptNo.Visible = true;
            lblOrigionalReturn.Visible = true;
            txtDateofReturn.Visible = true;
            reqq1.Visible = true;
            reqq1.ControlToValidate = "txtRecieptNo";
            RequiredFieldValidator1.Visible = true;
            RequiredFieldValidator1.ControlToValidate = "txtDateofReturn";

            if (ddlWhichSection.SelectedValue == "18")
            {
                divNotice.Visible = true;
                RequiredFieldValidator2.Visible = true;
                RequiredFieldValidator2.ControlToValidate = "txtNotice";
            }
        }
        else if (ddlReturnType.SelectedIndex == 0)
        {
            lblRecieptNO.Visible = false;
            txtRecieptNo.Visible = false;
            lblOrigionalReturn.Visible = false;
            txtDateofReturn.Visible = false;
            reqq1.Visible = false;
            RequiredFieldValidator1.Visible = false;

            //RequiredFieldValidator1.ControlToValidate = "txtDateofReturn";
            //if (ddlWhichSection.SelectedValue == "18")
            //{
            divNotice.Visible = false;
            RequiredFieldValidator2.Visible = false;
            //}
            //RequiredFieldValidator2.ControlToValidate = "txtNotice";
        }
        else
        {
            divNotice.Visible = false;
            RequiredFieldValidator2.Visible = false;
        }
        if (ddlWhichSection.SelectedValue == "18" || ddlWhichSection.SelectedValue == "13" || ddlWhichSection.SelectedValue == "14" || ddlWhichSection.SelectedValue == "15" || ddlWhichSection.SelectedValue == "16")
        {
            //divDON.Visible = true;
            divDON.Style.Add("display", "block");
            RequiredFieldValidator3.Visible = true;
        }
        else
        {
            divDON.Style.Add("display", "none"); //divDON.Visible = false;
            RequiredFieldValidator3.Visible = false;
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["AY"] = DropDownList2.SelectedValue;
        getData();
        ScriptManager1.RegisterDataItem(hdn3, hdnVal);
    }

    private void getData()
    {
        bllMain objMainBLL;
        denMain objMainDEN;
        objMainBLL = new bllMain();
        audit = 0;
        if (chkAccountAudited.Checked == true)
            audit = 1;
        else if (chkAccountAudited.Checked == false)
            audit = 0;

        Session["AY"] = DropDownList2.SelectedValue;
        objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), Convert.ToInt32(Session["Status"]), audit, StateID);
        string[] arrDate = System.Text.RegularExpressions.Regex.Split(objMainDEN.DueDate, "/");

        DateTime dtime = new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]));
        txtDueDate.Text = objMainDEN.DueDate;
        if (DateTime.Now > dtime)
            ddlWhichSection.SelectedIndex = 1;
        else
            ddlWhichSection.SelectedIndex = 0;
        hdnVal = objMainDEN.DueDate + "~" + ddlWhichSection.SelectedIndex.ToString();
        Button2.Visible = true;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string[] arrVal = System.Text.RegularExpressions.Regex.Split(DropDownList1.SelectedValue, "-");
        //txtTDSAY.Text = DropDownList1.SelectedValue;// arrVal[1] + "-" + (Convert.ToInt32(arrVal[1]) + 1).ToString();
        Button3.Visible = true;
        hdnCG.Value = "";
    }
    protected void DropDownList2_PreRender(object sender, EventArgs e)
    {

    }

    protected void ddlReturnType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlWhichSection.SelectedValue == "17")
            ddlWhichSection.SelectedIndex = 1;
        if (ddlReturnType.SelectedIndex == 0)
        {
            lblRecieptNO.Visible = false;
            txtRecieptNo.Visible = false;
            lblOrigionalReturn.Visible = false;
            txtDateofReturn.Visible = false;
            reqq1.Visible = false;
        }
        else if (ddlReturnType.SelectedIndex == 1)
        {
            reqq1.Visible = true;
            lblRecieptNO.Visible = true;
            txtRecieptNo.Visible = true;
            lblOrigionalReturn.Visible = true;
            txtDateofReturn.Visible = true;
        }
    }
    protected void chkAccountAudited_CheckedChanged(object sender, EventArgs e)
    {
        bllMain objMainBLL;
        denMain objMainDEN;
        objMainBLL = new bllMain();

        if (chkAccountAudited.Checked == true)
        {
            audit = 1;

            lblSection.Visible = true;
            ddlSection.Visible = true;
            lblAuditor.Visible = true;
            ddlAuditor.Visible = true;
            Session["AY"] = DropDownList2.SelectedValue;
            objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), Convert.ToInt32(Session["Status"]), audit, StateID);
            txtDueDate.Text = objMainDEN.DueDate;
            Button2.Visible = true;
            //btnReadOnly.Visible = false;
        }
        else if (chkAccountAudited.Checked == false)
        {
            audit = 0;
            lblSection.Visible = false;
            ddlSection.Visible = false;
            lblAuditor.Visible = false;
            ddlAuditor.Visible = false;
            Session["AY"] = DropDownList2.SelectedValue;
            objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), Convert.ToInt32(Session["Status"]), audit, StateID);
            txtDueDate.Text = objMainDEN.DueDate;
            Button2.Visible = true;
            //btnReadOnly.Visible = false;
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        mltView.ActiveViewIndex = 0;
    }

    // This function will set the Edit Mode Values according to the selected Record For Edit. 
    //This is created other than the main event as to make sure that the first round of process 
    //is also managed through this function through the same Submit Button that was previously doing on Edit Index Changed.
    public void setEditMode()
    {
        GridView grd = (GridView)dny_Grd_ITRInfo.FindControl("Dynamic_Gridview");
        DataTable dt = (DataTable)grd.DataSource;
        if (hdnVal != "testing" && hdnVal != "")
        {
            string[] arr = System.Text.RegularExpressions.Regex.Split(hdnVal, "~");
            if (arr[0] == "edt" || arr[0] == "sel")    // to check whether its for Edit or Select
            {
                int ii = Convert.ToInt32(arr[1]);
                //for Master Page Redirect:

                Session["Exists"] = 1;
                Session["Bool"] = "False";
                Session["Mode"] = "Edit";
                Session["PAN"] = Convert.ToString(dt.Rows[ii]["PanNo"].ToString());
                Session["Status"] = dt.Rows[ii]["Status"].ToString();
                Session["NameID"] = dt.Rows[ii]["ID"].ToString();
                Session["E_NameID"] = null;
                Session["restore"] = null;
                Session["AssesseeType"] = dt.Rows[ii]["Status"].ToString(); //Session["AssesseeType"] = "Individual";
                Session["AType"] = "";
                Session["DateofBirth"] = dt.Rows[ii]["DateOfBirth"].ToString();
                Session["ITR"] = "1";
                Session["ay"] = "2014-2015";// Session["AY"].ToString();    default 14-15 for edi
                if (Session["duedate"] != null)
                    Session["duedate"] = "31-07-2014";
                Session["UpdateXml"] = "edt";
            }
        }
    }



    protected void chkTRP_CheckedChanged(object sender, EventArgs e)
    {

        if (chkTRP.Checked)
        {
            divTRP.Visible = true;
            divTRPName.Visible = true;
            divTRPPaid.Visible = true;

            reqTRP1.Visible = true;
            RequiredFieldValidator6.Visible = true;
            RequiredFieldValidator7.Visible = true;
        }
        else
        {
            divTRP.Visible = false;
            divTRPName.Visible = false;
            divTRPPaid.Visible = false;

            reqTRP1.Visible = false;
            RequiredFieldValidator6.Visible = false;
            RequiredFieldValidator7.Visible = false;
        }
    }

    protected void ddCivilCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddCivilCode.SelectedValue == "0")
        {
            divSpouse.Visible = false;
            divSpousePAN.Visible = false;
            req2.Visible = false;
            req3.Visible = false;
        }
        else
        {
            divSpouse.Visible = true;
            divSpousePAN.Visible = true;
            req2.Visible = true;
            req3.Visible = true;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        bllMain objbllMain = new bllMain();
        Session["ay"] = DropDownList1.SelectedValue;//txtTDSAY.Text;// DropDownList2.SelectedItem.Text;
        Session["AY"] = DropDownList1.SelectedValue;
        Session["FormType"] = ddFormType.SelectedItem.Text;//ddFormType.SelectedValue;
        Session["FY"] = DropDownList1.SelectedItem.Text;     //ddFY.SelectedValue;
        Session["qtr"] = DropDownList3.SelectedValue;
        Session["OC"] = ddRetType.SelectedValue;
        Session["Dir_Path"] = "TDS";

        string Type = "";
        if (Session["Regular_Correction"] != null)
            Type = Session["Regular_Correction"].ToString();
        DataTable dt = new DataTable();
        dt = objbllMain.FormQuaeterMapping(ddFormType.SelectedItem.ToString(), DropDownList3.SelectedValue.ToString(), Type);
        if (dt.Rows.Count > 0)
        {
            Session["ITR"] = dt.Rows[0][0].ToString();//DropDownList3.SelectedValue.Substring(1, 1);
        }
        bllAssessee objbllAssessee = new bllAssessee();
        objbllAssessee.Add_AssesseeITR();   //To add Assessee Return Details

        common objcommon = new common();
        bool IsJobExists = false;
        IsJobExists = objcommon.IsJobExists(Session["TAN"].ToString(), Session["FY"].ToString(), Session["FY"].ToString(), Session["FormType"].ToString(), Session["OC"].ToString(), DropDownList3.SelectedValue);
        if (!IsJobExists)
            objcommon.SaveJob("", Session["userEmail"].ToString(), "");
        //objcommon.SaveJob_TDS(Session["userEmail"].ToString());

        objbllMain.TDSMasterDetails(Session["TAN"].ToString(), Session["FY"].ToString(), "Regular", Session["qtr"].ToString(), Session["FormType"].ToString(), Session["AY"].ToString());

        denITR objdenITR = new denITR();
        bllITR objbllITR = new bllITR();

        bool IsProjectXML = objbllMain.IsProject_XML(Session["ITR"].ToString());

        
        //if (objdenITR.NameID != 0 && objdenITR.ITRType != "")
        if(IsProjectXML)
        {
            if (Session["AY"] != null)
            {
                objdenITR = objbllITR.getITRData(Convert.ToInt64(Session["NameID"]), Session["AY"].ToString(), Session["ITR"].ToString());
                restoreXML(objdenITR.XML_Data, objdenITR.ID);
            }
        }
        else
        {
            objcommon.ReverseGeneral(Convert.ToInt32(Session["NameID"]), Session["AY"].ToString(), Convert.ToInt32(Session["ITR"]), Convert.ToInt32(Session["Job_ID"]));
        }

        objcommon.SaveMainData(Convert.ToInt64(Session["NameID"]), Convert.ToInt32(Session["ITR"]), Session["AY"].ToString(), Session["TAN"].ToString(), Session["qtr"].ToString(), Session["FY"].ToString(), ddRetType.SelectedValue);
        Session["AssesseeType"] = "999999"; //Default Assessee Type for TDS as there is no Assessee Type in TDS
        //Response.Redirect("DisplayForm.aspx");

        //Redirection Logic:
        DataTable dtMenu = new DataTable();
        dtMenu = objbllMain.getMenu(Session["ay"].ToString(), Session["ITR"].ToString(), Session["AssesseeType"].ToString(), Session["Project"].ToString(), Convert.ToInt64(Session["User_ID"]));
        if (dtMenu.Rows.Count > 0)
        {
            if (dtMenu.Rows[0]["Menu_Link"].ToString().Contains("vtype"))
            {
                string[] arr = System.Text.RegularExpressions.Regex.Split(dtMenu.Rows[0]["Menu_Link"].ToString(), "vtype=");
                if (arr.Length == 2)
                    Session["IncomeTax_VType"] = arr[1];
                else
                    Session["IncomeTax_VType"] = "3001";

                Response.Redirect("IncomeTax");
            }
            else
                Response.Redirect(dtMenu.Rows[0]["Menu_Link"].ToString());
        }
        else
            Response.Redirect("IncomeTax");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        //Session["ITR"] = ddITR.SelectedValue;
        Session["FY"] = ddFY.SelectedValue;// DropDownList2.SelectedItem.Text;
        Session["ReturnType"] = ddReturnType.SelectedValue;
        Session["RP"] = ddReturnPeriod_1.SelectedValue;
        Session["DueDate"] = txtDueDate2.Text;
        if (Session["project"].ToString() == "stax")
        {
            Session["ay"] = ddFY.SelectedValue;
            Session["AY"] = ddFY.SelectedValue;
            if (Session["RP"] == "April-September")
                Session["ITR"] = "40";
            else
                Session["ITR"] = "41";
        }
        //Session["duedate"] = txtDueDate.Text;
        Response.Redirect("DisplayForm.aspx");
    }

    protected void ddReturnPeriod_1_SelectedIndexChanged(object sender, EventArgs e)
    {
        setDueDateForStax();
    }

    private void setDueDateForStax()
    {
        string[] arr = System.Text.RegularExpressions.Regex.Split(ddFY.SelectedValue, "-");
        if (ddReturnPeriod_1.SelectedValue == "April-September")
            txtDueDate2.Text = "25/10/" + arr[0];
        else
            txtDueDate2.Text = "25/04/" + arr[1];
    }

    //protected void gvTDS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvTDS.PageIndex = e.NewPageIndex;
    //    gvTDS.DataSource = ObjectDataSource5;
    //    gvTDS.DataBind();
    //}

    protected void updateMiscInfo(denDocTrans objDocTransDEN)
    {
        try
        {
            bllDocTrans objDocTransBLL;
            objDocTransBLL = new bllDocTrans();
            objDocTransBLL.updateMiscDetails(objDocTransDEN);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        bllUserMgmt objUserMgmtBLL = new bllUserMgmt();
        denUserMgmt objUserMgmtDEN = new denUserMgmt();
        objUserMgmtDEN.UserID = Convert.ToString(Session["UserName"]);

        bllLogin objLoginBLL = new bllLogin();
        denLogin objLoginDEN = new denLogin();
        objLoginDEN.LogoutTime = DateTime.Now.ToShortTimeString();
        objLoginDEN.UserName = Convert.ToString(Session["UserName"]);
        objLoginBLL.UpdateUserDetails(objLoginDEN);

        Response.Redirect("Login.aspx");
        Session["UserName"] = "";

    }

    public void fetchTDSData()
    {
        // try
        // {
            // //Providing Login Details
            // GetTDSReference.LoginInfoType obj_LoginInfoType = new LoginInfoType();
            // obj_LoginInfoType.userName = "ERIA100133";
            // obj_LoginInfoType.password = "gill123456@";

            // //Providing Client Details

            // //DateTime Date_of_Birth = DateTime.ParseExact(TxtDOB.Text.TrimEnd().TrimStart(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            // DateTime Date_of_Birth = new DateTime();

            // Date_of_Birth = Convert.ToDateTime(Session["DateofBirth"]);
            // string[] formats = { "yyyy-MM-dd" };
            // //Session["ay"] = "2013-14";
            // string ss = Session["DateofBirth"].ToString();
            // //DateTime.TryParseExact(Session["DateofBirth"].ToString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out Date_of_Birth);
            // //DateTime.TryParseExact(Date_of_Birth.ToShortDateString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out Date_of_Birth);

            // GetTDSReference.ClientInfoType obj_ClientInfoType = new ClientInfoType();
            // obj_ClientInfoType.pan = Session["PAN"].ToString();
            // obj_ClientInfoType.dob = Date_of_Birth;
            // obj_ClientInfoType.assessmentYear = "2013-14";// Session["ay"].ToString();


            // //Fetching TDS Details via LoginInfo and ClientInfo
            // GetTDSReference.getTDSDetails obj_getTDSDetails = new getTDSDetails();
            // obj_getTDSDetails.ClientInfo = obj_ClientInfoType;
            // obj_getTDSDetails.LoginInfo = obj_LoginInfoType;


            // //Creating a TDS Request with GetTDSDetails Class Object
            // GetTDSReference.GetTDSRequest obj_GetTDSRequest = new GetTDSRequest(obj_getTDSDetails);
            // obj_GetTDSRequest.getTDSDetails = obj_getTDSDetails;

            // //Getting TAN and TAN Name Details
            // GetTDSReference.EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDetl = new EmployerOrDeductorOrCollectDetl();

            // //Passing TDS Details as parameter in TDSPortClient
            // GetTDSReference.GetTDSPortClient obj_GetTDSPortClient = new GetTDSPortClient("GetTDSPortSoap11", "https://incometaxindiaefiling.gov.in/e-FilingWS/ditws");
            // obj_GetTDSPortClient.Open();

            // GetTDSReference.GetTDSResponseType obj_GetTDSResponseType = new GetTDSResponseType();
            // obj_GetTDSResponseType = obj_GetTDSPortClient.getTDSDetails(obj_getTDSDetails);

            // //Getting The TDS Response
            // GetTDSReference.GetTDSResponse obj_GetTDSResponse = new GetTDSResponse();
            // obj_GetTDSResponse.GetTDSResponse1 = obj_GetTDSResponseType;

            // bllFloating objFloatingBLO = new bllFloating();

            // //-----------------------------------------------------------------------------
            // //Getting TDS on Salary Data.....
            // //-----------------------------------------------------------------------------
            // if (obj_GetTDSResponse.GetTDSResponse1.TDSonSalaries != null)
            // {

                // int Length_TDSOnSal_Array = obj_GetTDSResponseType.TDSonSalaries.Length;
                // GetTDSReference.TDSonSalary[] obj_TDSonSalary = obj_GetTDSResponseType.TDSonSalaries;



                // DataTable dt_arr = new DataTable();
                // dt_arr.Columns.Add("TAN", typeof(String));
                // dt_arr.Columns.Add("TAN Name", typeof(String));
                // dt_arr.Columns.Add("Income Chargeable on Salary", typeof(String));
                // dt_arr.Columns.Add("Total TDS Salary", typeof(String));







                // for (int i = 0; i < obj_GetTDSResponseType.TDSonSalaries.Length; i++)
                // {
                    // var x = obj_TDSonSalary[i].IncChrgSal.ToString();
                    // var y = obj_TDSonSalary[i].TotalTDSSal.ToString();
                    // obj_EmployerOrDeductorOrCollectDetl = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl;

                    // DataRow Dr = dt_arr.NewRow();
                    // Dr["TAN"] = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // Dr["TAN Name"] = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // Dr["Income Chargeable on Salary"] = x;
                    // Dr["Total TDS Salary"] = y;
                    // dt_arr.Rows.Add(Dr);


                    // denFloating objFloatingDEO = new denFloating();
                    // objFloatingDEO.NameID = Convert.ToString(Session["NameID"]);
                    // objFloatingDEO.HeaderID = "102";
                    // objFloatingDEO.Vtype = "49";
                    // objFloatingDEO.ConstID = "802";
                    // objFloatingDEO.Gorder = Convert.ToString(ViewState["Gorder"]);
                    // objFloatingDEO.Number = 1;

                    // objFloatingDEO.Col4 = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // objFloatingDEO.Col7 = x;
                    // objFloatingDEO.Col9 = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // objFloatingDEO.Col13 = y;

                    // objFloatingBLO.InsertOrUpdate(objFloatingDEO);

                    // // To submit main data for the same:

                    // denStoreTrans objStoreTransDEN, objstoreTransDEN2;
                    // bllStoreTrans objStoreTransBLL;

                    // objStoreTransDEN = new denStoreTrans();
                    // objstoreTransDEN2 = new denStoreTrans();
                    // objStoreTransBLL = new bllStoreTrans();

                    // objStoreTransDEN.ConstID = 802;
                    // objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
                    // objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
                    // objStoreTransDEN.Vtype = 49;
                    // objStoreTransDEN.GIndex = 0;//Convert.ToInt32(ViewState["GridIndex"]);
                    // objStoreTransDEN.ComboItemNo = 0;// Convert.ToInt32(ViewState["ComboItem"]);
                    // objStoreTransDEN.MainID = 0;// Convert.ToInt32(ViewState["MainID"]);
                    // objStoreTransDEN.GRowNo = 0;// Convert.ToInt32(ViewState["GRowNo"]);
                    // objStoreTransDEN.IsEnterFDet = 1;

                    // //if (Session["float"].ToString() == "true")
                    // //{
                    // objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "0", 0);
                    // //}

                // }
                // //TDS on Salary Retrieved in Grid View


            // }

            // //------------------------------------------------------------------------------------
            // //Getting TDS On Other Than Salary Data......
            // //--------------------------------------------------------------------------------
            // if (obj_GetTDSResponse.GetTDSResponse1.TDSonOthThanSals != null)
            // {

                // int Length_TDSOnOthSal_Array = obj_GetTDSResponseType.TDSonOthThanSals.Length;
                // GetTDSReference.TDSonOthThanSal[] obj_TDSonOthThanSal = new TDSonOthThanSal[Length_TDSOnOthSal_Array];
                // obj_TDSonOthThanSal = obj_GetTDSResponseType.TDSonOthThanSals;

                // DataTable dt_arr = new DataTable();
                // dt_arr.Columns.Add("TAN", typeof(String));
                // dt_arr.Columns.Add("TAN Name", typeof(String));
                // dt_arr.Columns.Add("Total TDS On Amt Paid", typeof(String));
                // dt_arr.Columns.Add("Claim Out Of Tot. TDS On Amt Paid", typeof(String));
                // for (int i = 0; i < obj_GetTDSResponseType.TDSonOthThanSals.Length; i++)
                // {
                    // var x = obj_TDSonOthThanSal[i].TotTDSOnAmtPaid.ToString();
                    // var y = obj_TDSonOthThanSal[i].ClaimOutOfTotTDSOnAmtPaid.ToString();
                    // EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDet1_2 = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl;





                    // DataRow Dr = dt_arr.NewRow();
                    // Dr["TAN"] = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // Dr["TAN Name"] = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // Dr["Total TDS On Amt Paid"] = x;
                    // Dr["Claim Out Of Tot. TDS On Amt Paid"] = y;
                    // dt_arr.Rows.Add(Dr);


                    // denFloating objFloatingDEO = new denFloating();
                    // objFloatingDEO.NameID = Convert.ToString(Session["NameID"]);
                    // objFloatingDEO.HeaderID = "102";
                    // objFloatingDEO.Vtype = "49";
                    // objFloatingDEO.ConstID = "788";
                    // objFloatingDEO.Gorder = Convert.ToString(ViewState["Gorder"]);
                    // objFloatingDEO.Number = 1;

                    // objFloatingDEO.Col4 = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // objFloatingDEO.Col7 = x;
                    // objFloatingDEO.Col9 = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // objFloatingDEO.Col13 = y;

                    // objFloatingBLO.InsertOrUpdate(objFloatingDEO);


                    // // To submit main data for the same:

                    // denStoreTrans objStoreTransDEN, objstoreTransDEN2;
                    // bllStoreTrans objStoreTransBLL;

                    // objStoreTransDEN = new denStoreTrans();
                    // objstoreTransDEN2 = new denStoreTrans();
                    // objStoreTransBLL = new bllStoreTrans();

                    // objStoreTransDEN.ConstID = 788;
                    // objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
                    // objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
                    // objStoreTransDEN.Vtype = 49;
                    // objStoreTransDEN.GIndex = 0;//Convert.ToInt32(ViewState["GridIndex"]);
                    // objStoreTransDEN.ComboItemNo = 0;// Convert.ToInt32(ViewState["ComboItem"]);
                    // objStoreTransDEN.MainID = 0;// Convert.ToInt32(ViewState["MainID"]);
                    // objStoreTransDEN.GRowNo = 0;// Convert.ToInt32(ViewState["GRowNo"]);
                    // objStoreTransDEN.IsEnterFDet = 1;

                    // //if (Session["float"].ToString() == "true")
                    // //{
                    // objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "0", 0);
                // }
                // //TDS on Other Than Salary Retrieved in Grid View
            // }

            // //--------------------------------------------------------------------------------------
            // //Getting TCS Details Array
            // //---------------------------------------------------------------------------------------
            // if (obj_GetTDSResponse.GetTDSResponse1.ScheduleTCS != null)
            // {

                // int length_TCS_Array = obj_GetTDSResponse.GetTDSResponse1.ScheduleTCS.Length;
                // GetTDSReference.TCS[] obj_TCS = new TCS[length_TCS_Array];
                // obj_TCS = obj_GetTDSResponseType.ScheduleTCS;

                // DataTable dt = new DataTable();
                // dt.Columns.Add("TAN", typeof(String));
                // dt.Columns.Add("TAN Name", typeof(String));
                // dt.Columns.Add("Total TCS", typeof(String));
                // dt.Columns.Add("Amt TC Claimed This Year", typeof(String));

                // for (int i = 0; i < obj_GetTDSResponseType.ScheduleTCS.Length; i++)
                // {

                    // var x = obj_TCS[i].AmtTCSClaimedThisYear.ToString();
                    // var y = obj_TCS[i].TotalTCS.ToString();
                    // EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDet1_3 = obj_TCS[i].EmployerOrDeductorOrCollectDetl;

                    // DataRow dr = dt.NewRow();
                    // dr["TAN"] = obj_TCS[i].EmployerOrDeductorOrCollectDetl.TAN;
                    // dr["TAN Name"] = obj_TCS[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    // dr["Total TCS"] = x;
                    // dr["Amt TC Claimed This Yeard"] = y;
                // }
                // //TCS Data Retrieved in GridView
            // }
            // else
            // {
                // denStoreTrans objStoreTransDEN, objstoreTransDEN2;
                // bllStoreTrans objStoreTransBLL;

                // objStoreTransDEN = new denStoreTrans();
                // objstoreTransDEN2 = new denStoreTrans();
                // objStoreTransBLL = new bllStoreTrans();

                // objStoreTransDEN.ConstID = 801;
                // objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
                // objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
                // objStoreTransDEN.Vtype = 49;
                // objStoreTransDEN.GIndex = 0;//Convert.ToInt32(ViewState["GridIndex"]);
                // objStoreTransDEN.ComboItemNo = 0;// Convert.ToInt32(ViewState["ComboItem"]);
                // objStoreTransDEN.MainID = 0;// Convert.ToInt32(ViewState["MainID"]);
                // objStoreTransDEN.GRowNo = 0;// Convert.ToInt32(ViewState["GRowNo"]);
                // objStoreTransDEN.IsEnterFDet = 1;

                // objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "0", 0);
            // }

            // //------------------------------------------------------------------------------------------
            // //Getting Tax Payments Arrays.
            // //-------------------------------------------------------------------------------------------
            // if (obj_GetTDSResponse.GetTDSResponse1.TaxPayments != null)
            // {

                // int Length_Taxpayments_Array = obj_GetTDSResponseType.TaxPayments.Length;
                // GetTDSReference.TaxPayment[] obj_TaxPayment = new TaxPayment[Length_Taxpayments_Array];
                // obj_TaxPayment = obj_GetTDSResponseType.TaxPayments;


                // //Tax Payment Data Retrieved in Grid View
                // //GrdVw_TaxPayments.DataSource = ConvertArrayToDataTable(obj_TaxPayment);
                // //GrdVw_TaxPayments.DataBind();
                // //GrdVw_TaxPayments.HeaderRow.Cells[0].Text = "BSR Code";
                // //GrdVw_TaxPayments.HeaderRow.Cells[1].Text = "Dt. Deposited";
                // //GrdVw_TaxPayments.HeaderRow.Cells[2].Text = "Sr. No. of Challan";
                // //GrdVw_TaxPayments.HeaderRow.Cells[3].Text = "Amount";
            // }
        // }
        // catch (Exception ex)
        // {
            // lblMsg.Visible = true;
            // //lblMessage.Text = ex.Message;
            // //throw ex;
        // }
    }

    public DataTable ConvertArrayToDataTable(object[] inArray)
    {

        //create our datatable
        DataTable dt = new DataTable();


        if (inArray.Length == 0)
            return new DataTable();
        //initialize a new type of our inArray type
        Type type = inArray[0].GetType();


        //extract all our properties (public & static) from our type (generic)
        PropertyInfo[] proInfo = type.GetProperties();


        //create the columns for each property setting the name & type (generic)
        foreach (PropertyInfo i in proInfo)
            dt.Columns.Add(i.Name, i.PropertyType);


        //loop through each object in the array
        foreach (object o in inArray)
        {
            //create a new datarow
            DataRow r = dt.NewRow();
            //loop through each property in order and set our row columns to the value of the property
            for (int i = 0; i < proInfo.Length; i++)
                r[i] = o.GetType().InvokeMember(proInfo[i].Name, BindingFlags.GetProperty, null, o, null);


            //add the row to our table
            dt.Rows.Add(r);
        }

        return dt;
    }

    protected void btnBack2_Click(object sender, EventArgs e)
    {
        //if (url_ref != Request.Url.ToString())
        //{
        //    Response.Redirect(url_ref);
        //}
        //else
        //{
        //    Response.Redirect("Salary.aspx?vtype=40");
        //}
        Response.Redirect(Request.Url.ToString());
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        //Session["DisplayForm_Close"] = "0";
        //IsLogout = 0;
        //if (Request.UrlReferrer.ToString() != Request.Url.ToString())
        //    Session["Main"] = null;
        //else
        //    Session["Main"] = "set";
        hdnActiveIndx.Value = "edt~3";
    }

    [WebMethod]
    public static void AbandonSession()
    {
        Presentation_Main objPresentation_Main = new Presentation_Main();
        string ss = HttpContext.Current.Request.UrlReferrer.ToString();
        if (HttpContext.Current.Session["Main"] == null)
        {
            //HttpContext.Current.Response.Redirect("Logout.aspx");
            //HttpContext.Current.Session.Abandon();
            //Presentation_DisplayForm objPresentation_DisplayForm = new Presentation_DisplayForm();
            bllAssessee objbllAssessee = new bllAssessee();
            if (HttpContext.Current.Session["NameID"] != null && HttpContext.Current.Session["AY"] != null)
                objbllAssessee.DeleteFromStoreTrans(HttpContext.Current.Session["NameID"].ToString(), HttpContext.Current.Session["AY"].ToString());

            //HttpContext.Current.Response.Redirect("Logout.aspx");
            objPresentation_Main.Logout();
        }
        else
            HttpContext.Current.Session["Main"] = null;
    }

    public void Logout()
    {
        balAdmin objbalAdmin = new balAdmin();
        if (HttpContext.Current.Session.SessionID != null)
        {
            objbalAdmin.logoutUser();
        }
        string Project_Session = "";
        string reason_logout = "";

        if (Session["User_ID"] == null)
            Response.Redirect("../Default.aspx");
        if (Session["Project"] != null)
            Project_Session = Session["Project"].ToString();
        if (Session["reason_logout"] != null)
            reason_logout = Session["reason_logout"].ToString();

        //balAdmin objbalAdmin = new balAdmin();
        int lastID = objbalAdmin.getLastLoginID(Convert.ToInt32(Session["User_ID"]));   // this is the last ID for tbl_User_Session_Details table and this to set the Logout Status for the same record for the user
        Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
        tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        objtbl_UserGroupRegistration.Logout_Time = DateTime.Now.ToString();
        objtbl_UserGroupRegistration.Logout_Nature = "LogOff";
        objtbl_UserGroupRegistration.Super_User_Id = Convert.ToInt32(Session["User_ID"]);
        objtbl_UserGroupRegistration.Time_OutID = lastID;
        objBltbl_UserGroupRegistration.Update_Logout_Time(objtbl_UserGroupRegistration);

        Session.Clear();
        Session.Abandon();
        Session["Project"] = Project_Session;
        string strRedirect = "../Default.aspx";
        if (reason_logout != "")
        {
            Session["reason_logout"] = reason_logout.ToString();
            strRedirect = "Login.aspx?reason_logout=sa";
        }
        //Response.Redirect("login.aspx");
        //Response.Redirect("../Default.aspx");
        //Response.Redirect(strRedirect);
    }
    protected void btnBackMain_Click(object sender, EventArgs e)
    {
        if (Session["Project"].ToString() == "tds")
        {
            Response.Redirect("tds.aspx");
        }
        else if (Session["Project"].ToString() == "stax")
        {
            Response.Redirect("servicetax.aspx");
        }
        else if (Session["Project"].ToString() == "vt")
        {
            Response.Redirect("itr1.aspx");
        }
    }

    protected void btnBackToRec_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
    protected void btTest_Click(object sender, EventArgs e)
    {
        try
        {
            hdn1.Value = "hello";
            hdnActiveIndx.Value = hdnVal;

            ScriptManager1.RegisterDataItem(hdnActiveIndx, hdnVal);
            hdnVal = "testing";
        }
        catch (Exception ex)
        {

        }        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        restoreXML();
    }
    private void restoreXML()
    {
        try
        {
            if (fup1.FileName != "")
            {
                fup1.PostedFile.SaveAs(Server.MapPath("../xmlUpload/") + fup1.FileName);
            }
            string PAN = "";
            bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            //Session["AY"] = txtAY.Text;
            string ITR = "";
            string strXML = File.ReadAllText((Server.MapPath("../xmlUpload/") + fup1.FileName).ToString());
            string[] arrXML = System.Text.RegularExpressions.Regex.Split(strXML, @"\?>");
            string xml = "";
            if (arrXML.Length > 1)
                xml = arrXML[1];// strXML;

            if (strXML.Contains("Form_ITR1"))
            {
                Session["ITR"] = "1";
                ITR = "1";
            }
            else if (strXML.Contains("Form_ITR4S"))
            {
                Session["ITR"] = "8";
                ITR = "8";
            }
            //else if (strXML.Contains("Form_ITR4"))
            //{
            //    Session["ITR"] = "4";
            //    ITR = "4";
            //}
            //else if (strXML.Contains("Form_ITR2"))
            //{
            //    Session["ITR"] = "2";
            //    ITR = "2";
            //}

            if (ITR == "1" || ITR == "8")
            {
                string[] arrAY = System.Text.RegularExpressions.Regex.Split(strXML, "</ITRForm:AssessmentYear>");
                strXML = arrAY[0].Substring(arrAY[0].Length - 4);
                Session["AY"] = strXML + "-" + (Convert.ToInt32(strXML) + 1).ToString();

                //objbllStoreTrans.resXML(xml, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + fup1.FileName).ToString(), ITR, (Session["NameID"] == null) ? "0" : Session["NameID"].ToString(), out PAN, 1);
                //objbllStoreTrans.resXML(xml, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + fup1.FileName).ToString(), ITR, "0", out PAN, 1);
                
                objbllStoreTrans.resXML_withMsg(xml, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + fup1.FileName).ToString(), ITR, "0", out PAN, 1, out errMsg);
                
                if (Session["PAN"].ToString() == PAN)
                {
                    bllAssessee objbllAssessee = new bllAssessee();
                    denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                    objAssesseeIndividual = objbllAssessee.GetDataIndividual(PAN);
                    Session["NameID"] = objAssesseeIndividual.NameID;
                    Session["restore"] = "true";
                    Session["PAN"] = PAN;

                    common objcommon = new common();
                    balXML objbalXML = new balXML();
                    string ITRXML_ID = "";
                    ITRXML_ID = objbalXML.getXML_Last_ID(objAssesseeIndividual.NameID);
                    objcommon.SaveJob(Session["NameID"].ToString(), Session["userEmail"].ToString(), ITRXML_ID);

                    denMain objMainDEN = new denMain();
                    bllMain objMainBLL = new bllMain();

                    objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), 0, 0, StateID);
                    string[] arrDate = System.Text.RegularExpressions.Regex.Split(objMainDEN.DueDate, "/");

                    DateTime dtime = new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]));
                    // DateTime dtime = Convert.ToDateTime("21/02/2009", new CultureInfo("en-US", true));
                    //dtime.Month+"/"+dtime.Day+"/"+dtime.Year
                    //Session["ITR"] = "1";
                    Session["ay"] = Session["AY"];
                    Session["duedate"] = objMainDEN.DueDate;
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    if (PAN == "")
                    {
                        balXML objbalXML = new balXML();
                        PAN = objbalXML.getTag_Value("ITRForm:PAN", xml);
                    }
                    if (Session["PAN"].ToString() == PAN)
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert_custom('Invalid XML File',1,'Error','','','',['OK'],'200','100px');", true);
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert_custom('XML is not associated with this Assessee',1,'Error','','','',['OK'],'200','100px');", true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('XML is not associated with this Assessee');", true);
                    //if (PAN != "")
                    //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert_custom('XML is not associated with this Assessee',1,'Error','','','',['OK'],'200','100px');", true);
                    //else
                    //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert_custom('Invalid XML File',1,'Error','','','',['OK'],'200','100px');", true);
                   
                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert_custom('" + errMsg.Substring(0,errMsg.IndexOf(".")) + "',1,'Error','','','',['OK'],'200','100px');", true);                    
                }
                //}
                //else
                //{
                //    //lblmsg2.Text = "This Assessee is already added by you";
                //    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('This Assessee is already added by you');", true);
                //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert_custom('This Assessee is already added by you',1,'Error','','','',['OK'],'200','100px');", true);
                //}
            }
            else
            {
                //lblmsg.Text = "You can only import ITR-1 and ITR-4S";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert_custom('You can only import ITR-1 and ITR-4S',1,'Error','','','',['OK'],'200','100px');", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('You can only import ITR-1 and ITR-4S');", true);
            }
        }
        catch (Exception ex)
        {
            //lblmsg.Text = "PAN already registered by another user";// ex.Message.ToString();
            
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup(Assessee Already Registered with Aother User;)", true); endrequesr
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('PAN already registered by another user');", true);
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "alert_custom('PAN already registered by another user',1,'Error','','','',['OK'],'200','100px');", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('"+ex.Message.ToString()+"');", true);

        }
    }


}
