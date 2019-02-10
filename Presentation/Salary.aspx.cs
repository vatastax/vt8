using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataAccess;
using System.Collections.Generic;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
//using controlgrid;
using System.Globalization;
//using GetTDSReference;
using System.Web.Services;
using BALVatasETDS.UserGroupManagement;
//using Ionic.Zip;
using System.IO;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    dalEmployerMaster objdalEmployerMaster = new dalEmployerMaster();
    denEmployerMaster objdenEmployerMaster = new denEmployerMaster();
    denFloating objFloatingDEO = new denFloating();
    bllScreen objBllScreen = new bllScreen();
    int Flag = 0;

    static List<T1000_rules> Lst_T1000 = new List<T1000_rules>();
    static List<t00_Rules> Lst_T00 = new List<t00_Rules>();
    static List<t4_Rules> Lst_T4 = new List<t4_Rules>();
    static DataSet dsDataRules = new DataSet();
    static DataTable dtT000_Rules = new DataTable();
    static DataTable dtMain = new DataTable();
    static int grd_row_cnt = 0;
    static int grd_row_cnt_Paging = 0;  //for different page
    int detail_cnt = 0;
    static string[] Formats = null;

    bool bolTFCheck;
    string YN;
    string vs = "";
    string grd_Selection = "";
    string strTitle = "";
    static int couter = 0;
    static Int32 cnt_FloatingCols_Global = 0;
    string cb_Val = "";
    denScreen objDenScreen = new denScreen();
    static string[] arrVtypes = null;       //new string[7] { "40", "42", "44", "46", "50", "104", "49" };
    static int cntVtype = 0;
    static int grdState_RowIndx = 0;
    static bool IsMasterEvents = false;     //this is the variable to be used for the purpose of checking whether we are entering the data or coming on the screen first time after/during page_load, button click, dropdown change or tab click
    static bool IsTextChanged = false;      //To check Text Change Event on Prerender for Tabbing Issue by Ankush (03/07/15)
    //No. of columns in class for size of textboxes in grid- jaipal - 01/07/2015
    public string class_no;
    public string class_noo;
    public string class_tooltip;
    static Image imgSpinner;
    static bool IsPopup = false;   //To show (Add) button for the purpose of multiple entries corresponding to the selected list of items. This is for the listing with mainIDs
    static int grdstate_row_cnt = 0;
    static int dropdown_Indx = 0;   //main dropdown cum tab
    static short latest_TabIndx = 0;
    static Int32 FloatRowCnt = 0;
    static string msg_IIF = "";
    static string IsBackCont = "";
    UserControls_FileUploadDirectoryCtrk objFCtrl = null;

    //No. of columns in class for size of textboxes in grid- jaipal - 01/07/2015
    #region PageEvents

    protected void Page_Load(object sender, EventArgs e)
    {
        string hdnlVal = hdnDDListSelection.Value;
        //Auto Redirect on Session Out
        grdstate_row_cnt = 0;
        dropdown_Indx = 0;
        int reason = 0;
        //In case of Master Page and already have record in the form, ta
        if (!common.IsLoggedIn(out reason))
        {
            if (reason == 1)
            {
                Session["reason_logout"] = "suspecious_attempt";
            }
            Response.Redirect("Logout.aspx");
        }

        hdnProject.Value = Session["Project"].ToString();

        //for managing window close from top:
        if (Request.UrlReferrer != null)
        {
            if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                Session["Def"] = null;
            else
                Session["Def"] = "set";
        }
        else
            Session["Def"] = "set";

        Session["DisplayForm"] = "set"; //as it was causing problem and calling the function from DisplayForm
        Session["Main"] = "set";
        Session["inc"] = "set";


        if (Session["project"].ToString() == "vt")
        {
            Page.Title = "The Interactive Platform for free e-filing Income Tax Returns in India";
        }
        else if (Session["project"].ToString() == "tds")
        {
            Page.Title = "TDS";
        }

        ltUser.Text = (Session["user_name"] != null) ? Session["user_name"].ToString() : "";

        cb_Val = "";
        if (Request.QueryString["cb"] != null)
            cb_Val = Request.QueryString["cb"].ToString();
        string str1 = Session["UserName"].ToString();
        string str2 = Session["Project"].ToString();
        string str3 = Session["NameID"].ToString();
        if (Session["UserName"] == null || Session["Project"] == null || Session["NameID"] == null)
        {
            Response.Redirect("../Default.aspx");
        }
        if (Session["IncomeTax_VType"].ToString() == "40" || Session["IncomeTax_VType"].ToString() == "40#")
        {
            class_tooltip = "tooltipDemo";
        }

        if (objDenScreen.IsMaster != "")
            Session["IsMasterPage"] = objDenScreen.IsMaster;
        else
            Session["IsMasterPage"] = 0;


        //No. of columns in class for size of textboxes in grid- jaipal - 01/07/2015
        if (objDenScreen.IsMaster == "1")//(Request.QueryString["Vtype"].ToString() == "106" || Request.QueryString["Vtype"].ToString() == "106#")
        {

            class_no = "large-5 columns";
            class_noo = "large-7 columns";
            class_tooltip = "tooltipDemo1";
        }
        //No. of columns in class for size of textboxes in grid- jaipal - 01/07/2015

        dsDataRules.Clear();
        //DataRules();

        //for setting validations:

        if (objDenScreen.GridHeader != "" && objDenScreen.GridHeader != null)
        {
            string[] split = objDenScreen.GridHeader.Split(',');
            grdState.Columns[0].HeaderText = split[0].ToString();
            grdState.Columns[1].HeaderText = split[1].ToString();
            grdState.Columns[2].HeaderText = split[2].ToString();
        }
        //updpnl22.ContentTemplateContainer.Controls.Clear();
        //if (Session["Project"].ToString() == "vt")
        //    objFCtrl = LoadControl("../UserControls/FileUploadDirectoryCtrk.ascx") as UserControls_FileUploadDirectoryCtrk;
        //else if (Session["Project"].ToString() == "tds")
        //    objFCtrl = LoadControl("../UserControls/fileuploadDirCtrl_TDS.ascx") as UserControls_FileUploadDirectoryCtrk;

        //updpnl22.ContentTemplateContainer.Controls.Add(objFCtrl);
        if (!IsPostBack)
        {
            //updpnl22.ContentTemplateContainer.Controls.Clear();
            //if (Session["Project"].ToString() == "vt")
            //    objFCtrl = LoadControl("../UserControls/FileUploadDirectoryCtrk.ascx") as UserControls_FileUploadDirectoryCtrk;
            //else if (Session["Project"].ToString() == "tds")
            //    objFCtrl = LoadControl("../UserControls/fileuploadDirCtrl_TDS.ascx") as UserControls_FileUploadDirectoryCtrk;

            //updpnl22.ContentTemplateContainer.Controls.Add(objFCtrl);
            //pnlUCtrls.Controls.Add(objFCtrl);

            IsBackCont = "";
            if (Session["IncomeTax_VType"] != null)
            {
                ViewState["vtype"] = Session["IncomeTax_VType"].ToString();
                Session["VType"] = ViewState["vtype"].ToString();
                hdnVType.Value = ViewState["vtype"].ToString();
            }
            hdnNameID.Value = Session["NameID"].ToString();
            IsMasterEvents = true;
            hdnAY.Value = Session["AY"].ToString(); //Setting this Hidden Field so can be used further within JS Functions
            if (Session["IncomeTax_VType"] != null)
            {
                if (Session["IncomeTax_VType"].ToString() == "40" || Session["IncomeTax_VType"].ToString() == "3001")
                {
                    btnBack.Visible = false;
                }
            }
            //following code is to manage the MainID:
            if (Request.QueryString["Vtype"] != null)
            {
                Session["IncomeTax_VType"] = Request.QueryString["VType"].ToString();
                if (Request.QueryString["fn"] != null && Session["IsMasterPage"] != null)
                {
                    if (Request.QueryString["fn"].ToString() == "0" && Session["IsMasterPage"].ToString() == "1")
                    {
                        Session["E_NameID"] = null;
                        Session["E_Name"] = null;
                    }
                }
            }
            //No. of columns in class for size of textboxes in grid- jaipal - 01/07/2015
            if (objDenScreen.IsMaster == "1") //(Request.QueryString["Vtype"].ToString() == "106" || Request.QueryString["Vtype"].ToString() == "106#")
            {

                class_no = "large-5 columns";
                class_noo = "large-7 columns";
                class_tooltip = "tooltipDemo1";
            }
            //To get Tab Count that will be used to manage Continue/Back buttons on the pages with multiple Tabs/Dropdowns on it
            bllFloating objbllFloating = new bllFloating();
            int tabCnt = objbllFloating.getTabCnt(ViewState["vtype"].ToString(), Session["AY"].ToString()) - 1;
            hdnTabCount.Value = tabCnt.ToString();
            //if (Request.QueryString["Vtype"].ToString() == "40" || Request.QueryString["Vtype"].ToString() == "40#")
            //{
            //    class_no = "large-6 columns";
            //    class_noo = "large-5 columns";
            //}
            //No. of columns in class for size of textboxes in grid- jaipal - 01/07/2015
            if (objDenScreen.ScreenTitle != null && objDenScreen.IsComboAttach != null)
            {
                if (Request.QueryString["cb"] == null)
                {
                    ddlChallan.Visible = false;
                    couter = 0;
                    grd_row_cnt = 0;
                    //ViewState["code"] = "EE";
                    //Page.ClientScript.RegisterHiddenField("vCode", ViewState["code"].ToString());
                    Lst_T1000.Clear();
                    Lst_T00.Clear();
                    Lst_T4.Clear();
                    //ScriptManager1.SetFocus(ddlSelect);
                    if (Session["Common"] != null)
                        objFloatingDEO = (denFloating)Session["Common"];
                    try
                    {
                        ViewState["GridIndex"] = Convert.ToInt32(objDenScreen.GridIndex);
                        Label1.Text = objDenScreen.LabelText;
                        lblHeading.Text = objDenScreen.ScreenTitle;
                        ltTDSHeading.Text = objDenScreen.ScreenTitle;
                        if (Convert.ToChar(objDenScreen.RadioVisible) == 'N')
                        {
                            btnRadioSimple.Visible = false;
                            btnRadiodetailed.Visible = false;
                        }
                        if (Convert.ToChar(objDenScreen.IsComboAttach) == 'N')
                        {
                            ddlSelect.Style.Add("display", "none");
                            if (Session["project"] != null)
                            {
                                if (Session["project"].ToString() == "tds")
                                {
                                    hdnQtr.Value = Session["qtr"].ToString();
                                    bindChalan();       //this function is for TDS purpose and so as the else after it
                                    //This Code IS For TDS
                                    string heq = ViewState["vtype"].ToString();
                                    InsertTDSSpecificRules();

                                }
                            }
                        }
                        else if (Convert.ToChar(objDenScreen.IsComboAttach) == 'T') //for tab and not dropdown
                        {
                            ddlSelect.Style.Add("display", "none");
                            if (Session["project"] != null)
                            {
                                if (Session["project"].ToString() == "tds")
                                {
                                    hdnQtr.Value = Session["qtr"].ToString();
                                    bindChalan();       //this function is for TDS purpose and so as the else after it
                                    //This Code IS For TDS
                                    InsertTDSSpecificRules();
                                }
                            }
                            List<denScreen> LstCombo = new List<denScreen>();
                            //session ITR COnditionally added on 24/06/2015 for managing tabControl
                            LstCombo = objBllScreen.getComboData(Convert.ToInt16(ViewState["vtype"]), (Session["ITR"] != null) ? Session["ITR"].ToString() : "1", (Session["AY"] != null) ? Session["AY"].ToString() : "2014-2015");
                            if (LstCombo.Count > 0)
                            {
                                ltTab.Text = @"<ul class='cbdb-menu_new1' id='cbdb-menu_id'>";

                                for (int i = 0; i < LstCombo.Count; i++)
                                {
                                    //ltTab.Text += @"<li><a href='" + Request.Url.ToString() + "&cb=" + LstCombo[i].ID.ToString() + "' class='border_bot active'>" + LstCombo[i].ComboItems + "</a></li>";
                                    //ltTab.Text += @"<li><a href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")' class='border_bot active'>" + LstCombo[i].ComboItems + "</a></li>";
                                    //ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")' class='border_bot_new1 active_new1 '>" + LstCombo[i].ComboItems + "</a></li>";

                                    if (i == 0)
                                    {
                                        if (objDenScreen.IsMaster == "1")//(Request.QueryString["VType"].ToString() == "106" || Request.QueryString["VType"].ToString() == "107")
                                            ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")'  class='border_bot_new1 active_new1 '>" + LstCombo[i].ComboItems + "</a></li>";
                                        else
                                            ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")' class='border_bot_new1 active_new1 '>" + LstCombo[i].ComboItems + "</a></li>";
                                    }
                                    else
                                    {
                                        if (objDenScreen.IsMaster == "1")//(Request.QueryString["VType"].ToString() == "106" || Request.QueryString["VType"].ToString() == "107")
                                            ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")' >" + LstCombo[i].ComboItems + "</a></li>";
                                        else
                                            ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")'  >" + LstCombo[i].ComboItems + "</a></li>";
                                    }
                                }
                                ltTab.Text += "</ul>";
                                //ltTab.Text = "";
                                //ddlSelect.Visible = false;
                            }
                        }
                        else
                        {
                            if (Session["qtr"] != null)
                                hdnQtr.Value = Session["qtr"].ToString();
                            ddlChallan.Visible = false;//.Style.Add("display", "none");
                        }
                        if (Session["Mode"] == "Edit")
                        {
                            btnSaveMasterData.Text = "Update";
                        }

                    }
                    catch (Exception ex)
                    {
                        if (Session["Project"].ToString() == "tds")
                            bindChalan(); //throw ex;
                    }
                    //}

                    if (Session["GrdVal"] != null)
                    {
                        mltView.ActiveViewIndex = 0;
                        grdState.DataSourceID = "";
                        grdState.DataBind();

                        grdState.DataSourceID = "ObjectDataSource1";
                        grdState.DataBind();
                        btnSaveToMydatabase1.Text = "Update And Clear";
                        btnSaveToMydatabase12.Text = "Update";
                        if (Session["BookEntry"] != null)
                        {
                            if (Convert.ToInt16(Session["BookEntry"]) == 0)
                                ddlSelect.SelectedIndex = 1;
                            else
                                ddlSelect.SelectedIndex = 0;
                        }
                        Session["GrdVal"] = null;
                    }
                }
                else
                {
                    foreach (GridViewRow row1 in grdState.Rows)
                    {
                        if (Convert.ToInt32(row1.Cells[4].Text) == 0 && Convert.ToInt32(row1.Cells[6].Text) == 0)
                            row1.Cells[3].Text = "";
                    }
                }
            }
            else
            {
                mltView.ActiveViewIndex = 10;
            }

            //following lines of code is for implementation of validation on Javascript End so as to stop the page until there are validations popped up there
            if (Session["ITR"] == null)
                Session["ITR"] = "1";
            ddlSelect.DataSourceID = "";
            ddlSelect.DataBind();

            ddlSelect.DataSourceID = "ObjectDataSource3";
            ddlSelect.DataBind();
            if (Session["Project"].ToString() == "tds" && Session["TDS_ByBookEntry"] != null)
            {
                ddlSelect.SelectedValue = (Session["TDS_ByBookEntry"].ToString() == "Y") ? "1" : "0";
                Session["TDS_ByBookEntry"] = null;
            }
            fetchValidations();

            if (Session["Validation_Combo"] != null)
            {
                //ddlSelect.SelectedIndex = Convert.ToInt32(Session["Validation_Combo"]);
                dropdown_Indx = Convert.ToInt32(Session["Validation_Combo"]);
                Session["Validation_Combo"] = null;
                //PageMove();

                //moveNextTab();
                ClientScript.RegisterStartupScript(GetType(), "asd", "<script type='text/javascript'>getTabbedGrid(" + dropdown_Indx + ");</script>");
            }
        }
        else
        {
            foreach (GridViewRow row1 in grdState.Rows)
            {
                if (Convert.ToInt32(row1.Cells[4].Text) == 0 && Convert.ToInt32(row1.Cells[6].Text) == 0)
                    row1.Cells[3].Text = "";
            }
        }
        fetchValidations();
        //whether to show (Add) button for multiple items for this VType or not
        if (Request.QueryString["ml"] != null)
        {
            mltView.ActiveViewIndex = 8;
            ddTDSList.Visible = true;
        }
        if (Session["VType_Popup"] != null)
        {
            nextPage();
        }
        string x = hdnControlHide.Value.ToString();
        //to fire default rules w.r.t. T00 for the current screen
        fireRules();


        //if (objDenScreen.dbtnID != "")
        if (!IsPostBack)
        {
            if (Session["filepath"] != null)
            {
                DownloadFile();
            }
        }
    }

    private void fetchValidations()
    {
        hdnValidations.Value = "";
        bllSalary objbllSalary = new bllSalary();
        for (int k = 0; k < ddlSelect.Items.Count; k++)
        {
            DataTable dt = new DataTable();
            string strV_Type = "";
            object oo = new object();
            Type tt = hdnVType.Value.GetType();
            string sas = tt.Name;
            //hdnVType.Value.GetType().MemberType.ToString();
            if (hdnVType.Value != "" && hdnVType.Value != "redirectToMain()" && !hdnVType.Value.Contains("_"))
                strV_Type = hdnVType.Value;
            else if (ViewState["vtype"] != null)
                strV_Type = ViewState["vtype"].ToString();
            else if (Session["VType"] != null)
                strV_Type = Session["VType"].ToString();
            else
                strV_Type = Session["IncomeTax_VType"].ToString();

            dt = objbllSalary.getConstIDByVType(strV_Type, ddlSelect.Items[k].Value, Session["AY"].ToString());
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                Lst_T00 = objbllSalary.SelectT(Convert.ToString(dt.Rows[j]["c1"]), Session["AY"].ToString(), Session["ITR"].ToString());
                hdnValidations.Value += j.ToString();  //for Validation from Javascript (for Master Page)
                for (int i = 0; i < Lst_T00.Count; i++)
                {
                    if (dt.Rows[j]["c1"].ToString() == Lst_T00[i].t00_c1)
                    {
                        hdnValidations.Value += "_" + Lst_T00[i].Validation + "=" + Lst_T00[i].ValidationString;
                    }
                }
                hdnValidations.Value += "~";
            }
            if (hdnValidations.Value != "")
                hdnValidations.Value = hdnValidations.Value.Remove(hdnValidations.Value.Length - 1);
            hdnValidations.Value += "$";
        }
        if (hdnValidations.Value != "")
            hdnValidations.Value = hdnValidations.Value.Remove(hdnValidations.Value.Length - 1);
    }

    protected void btnNewCont_Click(object sender, EventArgs e)
    {
        ViewState["vtype"] = "42";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (db1.Client_NoAction == "N" && Session["MethodReturn"] != null)
        {
            if (Session["MethodReturn"] != "")
            {
                if (Session["MethodReturn"] != null)
                {
                    int falg = 0;
                    if (Session["Mode"] == "Edit")
                    {
                        falg = 1;
                    }

                    if (Session["Project"].ToString() == "vt")
                    {
                        int IsSuccess = 0;
                        balXML objbalXML = new balXML();
                        if (Session["MethodReturn"].ToString().Contains("SaveMainData"))
                        {
                            falg = 1;   //This is to make sure that the main page will not be considered for the Saving and so Save New User Points.
                            string[] arrMR = System.Text.RegularExpressions.Regex.Split(Session["MethodReturn"].ToString(), "~");
                            Session["MainID"] = arrMR[1];
                            ViewState["MainID"] = arrMR[1];
                            grdState.DataSourceID = "";
                            grdState.DataBind();

                            grdState.DataSourceID = "ObjectDataSource1";
                            grdState.DataBind();
                        }
                        else
                        {
                            IsSuccess = Convert.ToInt32(Session["MethodReturn"]);
                            objbalXML.Update_JobID_ByNameID(IsSuccess.ToString());
                        }
                        if (falg == 0)  //Adding Assessee as User only during first Time (i.e. when come on Profile Page to create the Assessee first time and not while updation)
                        {
                            //
                            common objcommon = new common();
                            objcommon.AddUser(IsSuccess.ToString());
                            if (Session["UserRole"] != null)
                            {
                                if (Session["UserRole"].ToString() == "Reception")
                                {
                                    objcommon.SaveJob(IsSuccess.ToString(), Session["username"].ToString(), objbalXML.getXML_Last_ID(IsSuccess.ToString()));
                                }
                            }
                            Response.Redirect("Main.aspx");
                        }
                        else
                            redirectPolicy();
                    }
                    else if (Session["Project"].ToString() == "tds")
                    {
                        if (Session["MethodReturn"].ToString().Contains("SaveMainData"))
                        {
                            string[] arrMR = System.Text.RegularExpressions.Regex.Split(Session["MethodReturn"].ToString(), "~");
                            Session["MainID"] = arrMR[1];
                            ViewState["MainID"] = arrMR[1];
                            grdState.DataSourceID = "";
                            grdState.DataBind();

                            grdState.DataSourceID = "ObjectDataSource1";
                            grdState.DataBind();
                        }
                        else if (Session["MethodReturn"].ToString().Contains("Redirect"))
                        {
                            Response.Redirect(Session["MethodReturn"].ToString());
                        }
                        else if (Session["MethodReturn"].ToString().Contains("FileDownload"))
                        {
                            if (!Session["MethodReturn"].ToString().Contains("Non-Validated"))
                            {
                                string[] arrMR = System.Text.RegularExpressions.Regex.Split(Session["MethodReturn"].ToString(), "~");
                                Session["filepath"] = arrMR[1];
                                Response.Redirect(Request.Url.ToString());
                            }
                            else
                            {
                                Response.Redirect("lstErrors.aspx");
                            }
                        }
                        else
                        {
                            grdState.DataSourceID = "";
                            grdState.DataSourceID = "ObjectDataSource1";
                            //Response.Redirect(Request.Url.ToString());
                        }
                    }
                    else if (Session["Project"].ToString() == "tds2")
                    {
                        if (Session["VType"].ToString() == "15074")
                        {
                            common objcommon = new common();
                            objcommon.resetStatus(Convert.ToInt64(Session["DataKey"]));
                            Response.Redirect("TDSClient.aspx");
                        }
                    }

                    //redirectPolicy();
                }
            }
        }

        if (hdnTabbed.Value != "" && IsTextChanged == false)
        {
            grdState.DataSourceID = "";
            grdState.DataSourceID = "ObjectDataSource1";

            foreach (ListItem lst in ddlSelect.Items)
            {
                if (lst.Value == hdnTabbed.Value)
                {
                    ddlSelect.SelectedValue = hdnTabbed.Value;
                    //ddlSelect.SelectedIndex = ((hdnTabbed.Value != "") ? Convert.ToInt32(hdnTabbed.Value) : 0);
                }
            }
            ViewState["ComboItem"] = hdnTabbed.Value;// Convert.ToString(cb_Val);


            ddlSelect.Style.Add("display", "none");
            if (Session["project"] != null)
            {
                if (Session["project"].ToString() == "tds")
                    bindChalan();       //this function is for TDS purpose and so as the else after it
            }
            List<denScreen> LstCombo2 = new List<denScreen>();
            string sss = ViewState["vtype"].ToString();
            if (!ViewState["vtype"].ToString().Contains(".aspx"))
                LstCombo2 = objBllScreen.getComboData(Convert.ToInt32(ViewState["vtype"]), Session["ITR"].ToString(), (Session["AY"] != null) ? Session["AY"].ToString() : "2014-2015");
            if (LstCombo2.Count > 0)
            {
                ltTab.Text = @"<ul class='cbdb-menu_new1' id='cbdb-menu_id'>";

                for (int i = 0; i < LstCombo2.Count; i++)
                {
                    //ltTab.Text += @"<li><a href='" + Request.Url.ToString() + "&cb=" + LstCombo[i].ID.ToString() + "' class='border_bot active'>" + LstCombo[i].ComboItems + "</a></li>";
                    //ltTab.Text += @"<li><a href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")' class='border_bot active'>" + LstCombo[i].ComboItems + "</a></li>";
                    if (LstCombo2[i].ComboItems != "")
                    {
                        if (i == ddlSelect.SelectedIndex)
                        {
                            if (objDenScreen.IsMaster == "1")//(Request.QueryString["VType"].ToString() == "106" || Request.QueryString["VType"].ToString() == "107")
                                ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#'  class='border_bot_new1 active_new1 ' onclick='getTabbedGrid(" + LstCombo2[i].ID.ToString() + ")'>" + LstCombo2[i].ComboItems + "</a></li>";
                            else
                                ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo2[i].ID.ToString() + ")' class='border_bot_new1 active_new1 '>" + LstCombo2[i].ComboItems + "</a></li>";

                        }
                        else
                        {
                            if (objDenScreen.IsMaster == "1")//(Request.QueryString["VType"].ToString() == "106" || Request.QueryString["VType"].ToString() == "107")
                                ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo2[i].ID.ToString() + ")' >" + LstCombo2[i].ComboItems + "</a></li>";
                            else
                                ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo2[i].ID.ToString() + ")' >" + LstCombo2[i].ComboItems + "</a></li>";
                        }
                    }
                }
                ltTab.Text += "</ul>";
            }

            //hdnValidations.Value = "";
        }

        //System.Threading.Timer tt=new System.Threading.Timer(
        if (grdState.Rows.Count > grdState_RowIndx && IsMasterEvents == false && (hdnTabbed.Value == "" || IsTextChanged == true))
        {
            //System.Threading.Thread.Sleep(5000);

            //TextBox txt = (TextBox)grdState.Rows[grdState_RowIndx].Cells[3].FindControl("txtAmount");
            //bool isVisible = txt.Visible;
            //if (txt.Visible)
            //    txt.Focus();
            //else
            //{
            //    txt = (TextBox)grdState.Rows[grdState_RowIndx].Cells[3].FindControl("txtDate");
            //    txt.Focus();
            //    if (!txt.Visible)
            //    {
            //        DropDownList ddl = new DropDownList();
            //        ddl = (DropDownList)grdState.Rows[grdState_RowIndx].Cells[3].FindControl("ddl1");
            //        ddl.Focus();
            //    }
            //}
        }
        else
        {
            IsMasterEvents = false;
            hdnTabbed.Value = "";
            if (Request.QueryString["vtype"] != null)
            {
                if (objDenScreen.IsMaster == "1" || objDenScreen.IsComboAttach == "T")//(Request.QueryString["vtype"].ToString() == "106")
                {
                    //if (ddlSelect.SelectedIndex == 2)
                    if (ddlSelect.SelectedIndex == Convert.ToInt32(hdnTabCount.Value))
                    {
                        //btnSaveMasterData.Style.Remove("display");
                        btnContinue.Style.Remove("display");
                        btnContinueMaster.Style.Add("display", "none");
                        hdnIsSave.Value = "DataSaved";
                    }
                    else
                    {
                        btnContinueMaster.Style.Remove("display");
                        //btnSaveMasterData.Style.Add("display", "none");
                        btnContinue.Style.Add("display", "none");
                    }
                }
            }
        }
        IsTextChanged = false;
        hdnTabbed.Value = "";
        if (!IsPostBack)
        {
            if (Session["vtypes"] != null)
            {
                arrVtypes = System.Text.RegularExpressions.Regex.Split(Session["vtypes"].ToString(), "~");
            }
            else
            {
                if (Session["Project"].ToString() == "stax")
                {
                    arrVtypes = new string[7] { "5001", "5006", "5002", "5003", "5004", "5007", "5008" };
                }
                else if (Session["Project"].ToString() == "vt")
                {
                    if (Session["ITR"].ToString() == "4")
                        arrVtypes = new string[] { "40", "42", "62", "15049", "15050", "15017", "15036", "15034", "15035", "15047", "15048", "15041", "15040", "15051", "44", "15037", "15039", "15045", "15046", "50", "15052", "15053", "15054", "15055", "46", "15021", "15023", "15025", "15022", "15024", "104", "49", "15015" };
                    else
                        arrVtypes = new string[7] { "3", "4", "5", "6", "7", "9", "49" };
                }
                else
                {
                    arrVtypes = new string[7] { "3001", "3002", "3003", "3004", "", "", "" };
                }
            }
        }

        //if (imgSpinner != null)
        //    imgSpinner.Visible = false;
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["Project"] != null)
        {
            if (Session["Project"].ToString() == "tds")
                bindListMenu();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
        string ssss = hdnVType.Value; //ViewState["GridIndex"].ToString();// ViewState["vtype"].ToString();
        //if (Request.QueryString["VType"] != null)
        if (Session["IncomeTax_VType"] != null)
        {
            string v = Session["IncomeTax_VType"].ToString();
            ViewState["vtype"] = Session["IncomeTax_VType"].ToString();
            Session["VType"] = ViewState["vtype"].ToString();
            //hdnVType.Value = ViewState["vtype"].ToString();
            string ddSelectiong = "";
            if (Request.QueryString["ml"] != null)
            {
                ddSelectiong = Request.QueryString["ml"].ToString();
                ddTDSList.SelectedValue = ddSelectiong;
            }
            if (Session["Listing_Page"] == null && Session["Master_VType"] == null)
            {
                //HttpCookie cookie_vtype = Request.Cookies["vtype"];
                //if (cookie_vtype != null)
                //{
                //    ViewState["vtype"] = cookie_vtype.Value;
                //    Session["IncomeTax_VType"] = cookie_vtype.Value;
                //    Request.Cookies.Remove("vtype");
                //}
            }
            else
                Session["Listing_Page"] = null;

            if (Session["Session_VType"] != null)
            {
                ViewState["vtype"] = Session["Session_VType"].ToString();
                Session["IncomeTax_VType"] = Session["Session_VType"].ToString();
                Session["Session_VType"] = null;
            }
            objDenScreen = objBllScreen.getSettings(Convert.ToInt16(ViewState["vtype"]));
            if (objDenScreen.IsMaster != null && objDenScreen.IsMaster != "" && objDenScreen.IsMaster != "0")
                Session["IsMaster"] = objDenScreen.IsMaster;
            else
            {
                Session["IsMaster"] = null;
                ViewState["MainID"] = Session["NameID"].ToString();
            }

            if (objDenScreen.Theme != "")
            {
                Page.Theme = objDenScreen.Theme; //Session["theme"].ToString();
            }
        }

        if (ViewState["vtype"] != null)
        {
            if (ViewState["vtype"].ToString() == "3004")
            {
                mltView.ActiveViewIndex = 9;
                Label6.Text = "Import From Excel";
            }
        }
        DataTable dtMain = new DataTable();
        string addLnk = "";
        string updLnk = "";
        System.Collections.ArrayList arrInfo = new System.Collections.ArrayList();
        arrInfo.Add(Session["NameID"].ToString());
        common obcommon = new common();
        dtMain = obcommon.Select(Session["IncomeTax_VType"].ToString(), arrInfo, out addLnk, out updLnk);
        Session["E_NameID"] = (dtMain.Rows.Count + 1).ToString();
        if (dtMain.Rows.Count > 0)
            IsPopup = true;
        if (objDenScreen.IsMaster == "2" && Session["MainID"] != null)
        {
            ViewState["MainID"] = Session["MainID"].ToString();
            string ss1 = Session["MainID"].ToString();
        }


        //if (ViewState["vtype"].ToString() == "106")
        if (objDenScreen.dbtnID != "")
        {
            //db1.Control_ID = "abc";
            db1.Control_ID = objDenScreen.dbtnID;
            db1.Page_ID = "100";
            db1.Page_ModuleID = "100";
        }
        //else
        //    db1.Control_ID = "pnl_testing";
        db1.btn_buttonClick += new EventHandler(db1_btn_buttonClick);
        //string sss = ViewState["MainID"].ToString();
        //dtMain = objpopup.Select(Session["VType"].ToString(), arrInfo, out addLnk, out updLnk);
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        int cnt = 0;
        foreach (GridViewRow row1 in gvDetails2.Rows)
        {
            if (row1.Visible)
            {
                DropDownList dd = new DropDownList();
                dd = (DropDownList)row1.FindControl("ddlYesNo");
                //dd.SelectedValue = "1";
                //DoYesNo2(dd);
            }
        }

        //Session["Def"] = "set";
        //Session["Def"] = null;
    }

    #endregion

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        string ss = ViewState["vtype"].ToString();
        for (int i = 0; i < arrVtypes.Length; i++)
        {
            if (arrVtypes[i] == ViewState["vtype"].ToString())
                cntVtype = i;
        }

        cntVtype += 1;

        if (cntVtype < arrVtypes.Length)
        {
            ViewState["vtype"] = arrVtypes[cntVtype];
            Session["VType"] = ViewState["vtype"].ToString();
            hdnVType.Value = ViewState["vtype"].ToString();
            //Session["vtype"] = arrVtypes[cntVtype];
            nextPage();
            //AbandonSession();
            //btnBack.Visible = true;
            IsMasterEvents = true;
            if (ViewState["vtype"].ToString() == "46" || ViewState["vtype"].ToString() == "49")
            {
                //calc80G();
            }
        }

        if (cntVtype == (arrVtypes.Length - 1))
        {
            btnContinue.Visible = false;
        }
        if (Session["Project"].ToString() == "tds")
            InsertTDSSpecificRules();
        btnSaveToMydatabase1.Text = "Save And Clear";
        btnSaveToMydatabase12.Text = "Save";
        bllFloating objbllFloating = new bllFloating();
        int tabCnt = objbllFloating.getTabCnt(ViewState["vtype"].ToString(), Session["AY"].ToString()) - 1;
        hdnTabCount.Value = tabCnt.ToString();

        btnBackMaster.Style.Add("display", "none");
    }

    protected void btnPageMove_Click(object sender, EventArgs e)
    {
        PageMove();
    }

    private void PageMove()
    {
        if (btnBack_Inp.Value == "")
            btnBack_Inp.Value = "Back";
        if (btnCont_Inp.Value == "")
            btnCont_Inp.Value = "Continue";
        IsBackCont = "true";
        string strData = "";
        string[] arrInfo = null;
        if (hdnVTypeStatus.Value == "1")
        {
            strData = objBllScreen.getNextPrevVType(ViewState["vtype"].ToString(), "next", Session["AY"].ToString(), Session["ITR"].ToString(), ddlSelect.SelectedValue);
            arrInfo = System.Text.RegularExpressions.Regex.Split(strData, "~");
            hdnVType.Value = arrInfo[0];
            btnCont_Inp.Value = arrInfo[1];
            // btnBack_Inp.Value = arrInfo[2];

            if (btnCont_Inp.Value == "")
                btnCont_Inp.Visible = false;
            else
                btnCont_Inp.Visible = true;
            //if (btnBack_Inp.Value == "")
            //    btnBack_Inp.Visible = false;
            //else
            btnBack_Inp.Visible = true;

            if (btnCont_Inp.Value != "Continue")
            {
                btnCont_Inp.Attributes.Add("onclick", "SubmitData();");
            }
        }
        else if (hdnVTypeStatus.Value == "2")
        {
            strData = objBllScreen.getNextPrevVType(ViewState["vtype"].ToString(), "prev", Session["AY"].ToString(), Session["ITR"].ToString(), ddlSelect.SelectedValue);
            arrInfo = System.Text.RegularExpressions.Regex.Split(strData, "~");
            hdnVType.Value = arrInfo[0];
            btnBack_Inp.Value = arrInfo[2];

            if (btnBack_Inp.Value == "")
                btnBack_Inp.Visible = false;
            else
                btnBack_Inp.Visible = true;

            btnCont_Inp.Visible = true;
            btnCont_Inp.Value = "Continue";

            btnCont_Inp.Attributes.Add("onclick", "setVTypeStatus(1);");
            //btnCont_Inp.Value = arrInfo[1];
            //if (btnCont_Inp.Value != "Continue")
            //{
            //    btnCont_Inp.Attributes.Add("onclick", "SubmitData();");
            //}
        }
        else
        {
            int IsFirstLast = objBllScreen.getFirstLast(hdnVType.Value, Session["AY"].ToString(), Session["ITR"].ToString());
            //arrInfo = System.Text.RegularExpressions.Regex.Split(strData, "~");
            ////hdnVType.Value = arrInfo[0];
            //btnCont_Inp.Value = arrInfo[1];
            //btnBack_Inp.Value = arrInfo[2];

            //if (hdnVType.Value == "48")
            if (IsFirstLast == 2)
                btnCont_Inp.Visible = false;
            else
                btnCont_Inp.Visible = true;


            //if (hdnVType.Value == "40")// || btnBack_Inp.Value == "")
            if (IsFirstLast == 3)
                btnBack_Inp.Visible = false;
            else
                btnBack_Inp.Visible = true;

        }
        //if (ViewState["vtype"].ToString() == "40")
        //    btnBack_Inp.Visible = false;
        //else
        //    btnBack_Inp.Visible = true;

        hdnVType1.Value = hdnVType.Value;

        if (hdnVType.Value != "")
        {
            if (hdnVType.Value.Contains("_"))
            {
                //ddlSelect.SelectedIndex = ddlSelect.SelectedIndex + 1;
                //if (dropdown_Indx == 0)
                //    dropdown_Indx = (Convert.ToInt32(ddlSelect.SelectedIndex) + 1);
                //else
                //    dropdown_Indx += dropdown_Indx;
                ////moveNextTab();
                //hdnTabbedIndx.Value = dropdown_Indx.ToString();
                //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>btnCont_Click(); </script>");
            }
            else
            {
                ViewState["vtype"] = hdnVType.Value;
                hdnVType.Value = ViewState["vtype"].ToString();
                Session["VType"] = hdnVType.Value;
                Session["popupID"] = objDenScreen.popupID.ToString();
                hdnVType.Value = "";
            }
        }
        if (hdnVType.Value.Contains("_") || hdnVType1.Value.Contains(".aspx"))
        {

        }
        else
        {
            string ss = dropdown_Indx.ToString();
            IsMasterEvents = true;
            nextPage();
            if (ViewState["vtype"].ToString() == "46" || ViewState["vtype"].ToString() == "49")
            {
                //calc80G();
            }
        }
        IsMasterEvents = true;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < arrVtypes.Length; i++)
        {
            if (arrVtypes[i] == ViewState["vtype"].ToString())
                cntVtype = i;
        }

        btnContinue.Visible = true;

        cntVtype -= 1;
        if (cntVtype.ToString().Contains("-"))
            cntVtype = 0;
        ViewState["vtype"] = arrVtypes[cntVtype];
        Session["VType"] = ViewState["vtype"].ToString();
        hdnVType.Value = ViewState["vtype"].ToString();
        //Session["vtype"] = arrVtypes[cntVtype];
        nextPage();
        //AbandonSession();
        if (ViewState["vtype"].ToString() == "40" || ViewState["vtype"].ToString() == "3001")
            btnBack.Visible = false;
        IsMasterEvents = true;

        if (ViewState["vtype"].ToString() == "46" || ViewState["vtype"].ToString() == "49")
        {
            //calc80G();
        }
        btnSaveToMydatabase1.Text = "Save And Clear";
        btnSaveToMydatabase12.Text = "Save";
    }

    private void nextPage()
    {
        if (Session["VType_Popup"] != null)
        {
            ViewState["vtype"] = Session["VType_Popup"].ToString();
            hdnVType.Value = ViewState["vtype"].ToString();
            Session["VType"] = Session["VType_Popup"].ToString();
            Session["popupID"] = objDenScreen.popupID.ToString();
            Session["VType_Popup"] = null;
        }
        //Follwing Code is Written By Mudit For TDS to Check IF Records Exists For Current Deductor Then Redirect To lstGrids on 30/11/2015 (Requirement OF Mago Sir)
        if (Session["Project"].ToString() == "tds" && ViewState["vtype"].ToString() == "3002" || ViewState["vtype"].ToString() == "3003")
        {
            bllMain objbllMain = new bllMain();
            int IsExists = 0;
            string TAN = Session["TAN"].ToString();
            string FY = Session["FY"].ToString();
            string FormNo = Session["FormType"].ToString();
            string Quarter = Session["qtr"].ToString();
            string Type = Session["Regular_Correction"].ToString();
            string Vtype = ViewState["vtype"].ToString();
            IsExists = objbllMain.IsDataExists(TAN, FY, FormNo, Quarter, Type, Vtype);
            if (IsExists != 0)
                Response.Redirect("lstGrids.aspx?vtype=" + ViewState["vtype"].ToString());

        }
        string ddSelectiong = "";
        if (Request.QueryString["ml"] != null)
        {
            ddSelectiong = Request.QueryString["ml"].ToString();
            ddTDSList.SelectedValue = ddSelectiong;
        }
        objDenScreen = objBllScreen.getSettings(Convert.ToInt16(ViewState["vtype"]));
        ViewState["GridIndex"] = Convert.ToInt32(objDenScreen.GridIndex);

        Label1.Text = objDenScreen.LabelText;
        lblHeading.Text = objDenScreen.ScreenTitle;
        ltTDSHeading.Text = objDenScreen.ScreenTitle;
        ltTab.Text = "";
        if (Convert.ToChar(objDenScreen.RadioVisible) == 'N')
        {
            btnRadioSimple.Visible = false;
            btnRadiodetailed.Visible = false;
        }
        if (Convert.ToChar(objDenScreen.IsComboAttach) == 'N')
        {
            ddlSelect.Style.Add("display", "none");
            if (Session["project"] != null)
            {
                if (Session["project"].ToString() == "tds")
                    bindChalan();       //this function is for TDS purpose and so as the else after it
            }
        }
        else if (Convert.ToChar(objDenScreen.IsComboAttach) == 'T') //for tab and not dropdown
        {
            ddlSelect.Style.Add("display", "none");
            if (Session["project"] != null)
            {
                if (Session["project"].ToString() == "tds")
                    bindChalan();       //this function is for TDS purpose and so as the else after it
            }
            List<denScreen> LstCombo = new List<denScreen>();
            LstCombo = objBllScreen.getComboData(Convert.ToInt16(ViewState["vtype"]), Session["ITR"].ToString(), (Session["AY"] != null) ? Session["AY"].ToString() : "2014-2015");
            if (LstCombo.Count > 0)
            {
                ltTab.Text = @"<ul class='cbdb-menu_new1' id='cbdb-menu_id'>";
                for (int i = 0; i < LstCombo.Count; i++)
                {
                    if (i == 0)
                    {
                        if (objDenScreen.IsMaster == "1")//(Request.QueryString["VType"].ToString() == "106" || Request.QueryString["VType"].ToString() == "107")
                            ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' class='border_bot_new1 active_new1 ' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")' >" + LstCombo[i].ComboItems + "</a></li>";
                        else
                            ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")' class='border_bot_new1 active_new1 '>" + LstCombo[i].ComboItems + "</a></li>";
                    }
                    else
                    {
                        if (objDenScreen.IsMaster == "1")//(Request.QueryString["VType"].ToString() == "106" || Request.QueryString["VType"].ToString() == "107")
                            ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")' >" + LstCombo[i].ComboItems + "</a></li>";
                        else
                            ltTab.Text += @"<li><a id='aTab_" + i.ToString() + "' href='#' onclick='getTabbedGrid(" + LstCombo[i].ID.ToString() + ")' >" + LstCombo[i].ComboItems + "</a></li>";

                    }
                }
                ltTab.Text += "</ul>";
            }
        }
        else
        {
            ddlChallan.Visible = false;//.Style.Add("display", "none");
            //Added by Mudit on 29/08/2015
            if (Convert.ToChar(objDenScreen.IsComboAttach) == 'Y')
            {
                ddlSelect.Style.Add("display", "block");
            }
        }


        ddlSelect.DataSourceID = "";
        ddlSelect.DataBind();

        ddlSelect.DataSourceID = "ObjectDataSource3";
        ddlSelect.DataBind();

        grdState.DataSourceID = "";
        grdState.DataBind();

        grdState.DataSourceID = "ObjectDataSource1";
        grdState.DataBind();

    }

    protected void btnDetails_Click(object sender, EventArgs e)
    {
        bllStoreTrans objbllStoretrans = new bllStoreTrans();
        //objbllStoretrans.deleteUser(Session["NameID"].ToString());
        //Response.Redirect(Request.Url.ToString());
        grdState.DataSourceID = "ObjectDataSource1";
        btnSaveToMydatabase1.Text = "Update And Clear";
        btnSaveToMydatabase12.Text = "Update";
        mltView.ActiveViewIndex = 8;
        ddTDSList.Visible = true;
        if (ViewState["vtype"] != null)
            Response.Redirect("lstGrids.aspx?vtype=" + ViewState["vtype"].ToString());
        else
            Response.Redirect("lstGrids.aspx?vtype=" + Session["IncomeTax_VType"].ToString());

    }

    public void bindChalan()
    {
        List<denScreen> lst = new List<denScreen>();
        int v = 0;
        if (ViewState["vtype"] != null)
            v = Convert.ToInt32(ViewState["vtype"]);
        else
            v = Convert.ToInt32(Request.QueryString["VType"]);
        string ITR = Session["ITR"].ToString();
        string Quarter = Session["qtr"].ToString();
        string AY = Session["AY"].ToString();
        string TAN = Session["TAN"].ToString();
        string FormNo = Session["FormType"].ToString();
        string Regular_Correction = Session["Regular_Correction"].ToString();//"Regular";
        string FY = Session["FY"].ToString();

        if (FormNo != "Form15G" && FormNo != "Form15H" && FormNo != "Form24G" && FormNo != "AIR")
        {
            //bllScreen objBllScreen = new bllScreen();
            lst = objBllScreen.getOtherComboData(v, ITR, AY, TAN, FormNo, Regular_Correction, FY, Quarter);

            ddlChallan.Visible = true;
            ddlChallan.DataSource = lst;
            ddlChallan.DataTextField = "ChallanID";
            ddlChallan.DataValueField = "ChallanID";
            ddlChallan.DataBind();
            if (lst.Count == 0)
                ddlChallan.Items.Add(new ListItem("No Challan Found", "0"));
            if (v.ToString() == "3002")
                GetChallanDetails();
            if (Session["SelChal"] != null && Session["ImCD"] != null)
                if (Session["ImCD"].ToString() == "1")
                    ddlChallan.SelectedValue = Session["SelChal"].ToString();
        }
    }

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
            objdenStoreTrans.FY = arrTemp2[0] + arrTemp2[1].Substring(2, 2);
        else
            objdenStoreTrans.FY = arrTemp2[0].ToString();
        objdenStoreTrans.Vtype = Convert.ToInt32(ViewState["vtype"]);

        DataTable dt = new DataTable();
        dt = objbllStoreTrans.getComboListData(objdenStoreTrans, "TDS");
        ddTDSList.DataSource = dt;
        ddTDSList.DataTextField = "title";
        ddTDSList.DataValueField = "id";
        ddTDSList.DataBind();
    }

    protected void ddlSelect_DataBound(object sender, EventArgs e)
    {
        if (Session["Project"].ToString() == "TDS")
        {
            if (ddlSelect.Items.Count <= 1)
                ddlSelect.Style.Add("display", "none");
            else
                ddlSelect.Style.Remove("display");
        }
        else
        {
            if (ddlSelect.Items.Count <= 1)
                ddlSelect.Enabled = false;
            else
                ddlSelect.Enabled = true;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        dropdown_Indx = Convert.ToInt32(ddlSelect.SelectedIndex);
        moveNextTab();




    }

    private void moveNextTab()
    {
        IsMasterEvents = true;
        grdState.DataSourceID = "";
        grdState.DataSourceID = "ObjectDataSource1";
        ViewState["ComboItem"] = ddlSelect.SelectedValue;
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["intIndex"] = (ddlSelect.SelectedValue == "") ? "0" : ddlSelect.SelectedValue;
        //e.InputParameters["intGindex"] = Convert.ToInt16(ViewState["GridIndex"]);
        e.InputParameters["intGindex"] = Convert.ToInt32(ViewState["GridIndex"]);
        e.InputParameters["strAssesseeType"] = Convert.ToString(Session["AssesseeType"]);
        string strAT = Convert.ToString(Session["AssesseeType"]);
        e.InputParameters["strAY"] = Convert.ToString(Session["AY"]);
        e.InputParameters["PAN"] = Convert.ToString(Session["PAN"]);
        e.InputParameters["ITR"] = Convert.ToString(Session["ITR"]);
        e.InputParameters["NameID"] = Session["NameID"].ToString();
        //following code is for Service Tax only and is added here as there was no such construct at DB Side

        if (Session["project"].ToString() == "stax")
        {
            e.InputParameters["ReturnPeriod"] = Session["RP"].ToString();
        }
        else
        {
            e.InputParameters["ReturnPeriod"] = "";
        }

        if (Session["IsMaster"] != null)
        {
            if (Session["IsMaster"].ToString() == "1")
            {
                string strData = "";
                string[] arrInfo = null;

                strData = objBllScreen.getNextPrevVType(ViewState["vtype"].ToString(), "next", Session["AY"].ToString(), Session["ITR"].ToString(), Convert.ToString(ddlSelect.SelectedValue));
                arrInfo = System.Text.RegularExpressions.Regex.Split(strData, "~");
                if (arrInfo.Length > 1)
                {
                    hdnVType.Value = arrInfo[0];
                    btnCont_Inp.Value = arrInfo[1];
                    if (btnCont_Inp.Value != "Continue")
                    {
                        btnCont_Inp.Attributes.Add("onclick", "SubmitData();");
                    }
                    else
                    {
                        btnCont_Inp.Attributes.Add("onclick", "setVTypeStatus(1);");
                    }
                }

                strData = objBllScreen.getNextPrevVType(ViewState["vtype"].ToString(), "prev", Session["AY"].ToString(), Session["ITR"].ToString(), Convert.ToString(ddlSelect.SelectedValue));
                arrInfo = System.Text.RegularExpressions.Regex.Split(strData, "~");
                if (arrInfo.Length > 1)
                {
                    hdnVType.Value = arrInfo[0];
                    btnCont_Inp.Value = arrInfo[1];
                    if (hdnVType.Value.Contains("()"))
                    {
                        if (Session["InternalSal"] != null)
                        {
                            if (Session["InternalSal"].ToString() == "true")
                            {
                                //Session["IncomeTax_VType"] = "40";
                                btnBack_Inp.Attributes.Add("onclick", "redirectHere('IncomeTax')");
                            }
                        }
                        else
                            btnBack_Inp.Attributes.Add("onclick", hdnVType.Value);
                    }
                    else
                    {
                        btnBack_Inp.Attributes.Add("onclick", "setVTypeStatus(2);");
                    }
                }

                //strData = objBllScreen.getNextPrevVType(ViewState["vtype"].ToString(), "prev", Session["AY"].ToString(), Session["ITR"].ToString(), ddlSelect.SelectedValue);
                //arrInfo = System.Text.RegularExpressions.Regex.Split(strData, "~");
                //hdnVType.Value = arrInfo[0];
            }
        }
    }
    protected void grdState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdState_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItemIndex != -1) //&& IsPostBack==false)
        {
            try
            {
                Control LnkButton;
                LnkButton = (LinkButton)e.Row.Cells[3].FindControl("btnLink");

                LinkButton lbtn = new LinkButton();
                lbtn = (LinkButton)e.Row.Cells[3].FindControl("btnLink");
                if (Convert.ToInt32(e.Row.Cells[11].Text) > 1)
                    lbtn.CssClass = "imgdetail2";


                GridViewRow row = (GridViewRow)LnkButton.NamingContainer;

                ViewState["ConstID"] = Convert.ToInt32(row.Cells[5].Text);
                Session["ConstID"] = Convert.ToInt32(row.Cells[5].Text);
                TextBox txtAmt2 = (TextBox)e.Row.Cells[2].FindControl("txtAmount");
                TextBox txtDate = (TextBox)e.Row.Cells[2].FindControl("txtDate");
                TextBox txtReadOnly = (TextBox)e.Row.Cells[2].FindControl("txtReadOnly");
                DropDownList ddl1 = (DropDownList)e.Row.Cells[2].FindControl("ddl1");
                txtAmt2.Visible = false;
                txtDate.Visible = false;
                txtReadOnly.Visible = false;
                ddl1.Visible = false;
                row.Cells[4].Width = 0;
                bllSalary objSalary = new bllSalary();
                Literal lt = new Literal();
                Literal lt2 = new Literal();
                lt = (Literal)e.Row.FindControl("ltTooltip");
                //lt2 = (Literal)e.Row.FindControl("ltTooltip2");
                if (lt.Text != "")
                {
                    //lt.Text = @"<a alt='" + lt.Text + "' class='" + class_tooltip + "' id='tip_tool' style='text-decoration:none' >";
                    lt.Text = @"<a alt='" + lt.Text + "' class='" + class_tooltip + "' id='tip_tool' style='text-decoration:none' />";
                }

                //txtAmt2.ToolTip = e.Row.RowIndex.ToString();
                //txtAmt2.TabIndex = Convert.ToInt16(e.Row.RowIndex);
                int key = Convert.ToInt32(row.Cells[7].Text);
                int IsReq = Convert.ToInt32(row.Cells[10].Text);
                if (key == 2 || key == 4 || key == 7)
                {
                    txtAmt2.Visible = true;
                    txtDate.Visible = false;
                    txtReadOnly.Visible = false;
                    ddl1.Visible = false;
                }
                else if (key == 5)
                {
                    txtAmt2.Visible = false;
                    txtDate.Visible = true;
                    txtReadOnly.Visible = false;
                    ddl1.Visible = false;
                }
                else if (key == 0)
                {
                    txtAmt2.Visible = false;
                    txtDate.Visible = false;
                    txtReadOnly.Visible = true;
                    ddl1.Visible = false;
                }
                else if (key == 15 || key == 25)
                {
                    txtAmt2.Visible = false;
                    txtDate.Visible = false;
                    txtReadOnly.Visible = false;
                    ddl1.Visible = true;
                    DataTable dtList = new DataTable();
                    List<denSalary> genList = new List<denSalary>();
                    ddl1.ToolTip = key.ToString();
                    if (Session["Project"].ToString() == "tds")
                        dtList = objSalary.GetComboValues(Convert.ToString(ViewState["ConstID"]), Convert.ToString(Session["AY"]), Session["FormType"].ToString(), Session["FY"].ToString());
                    else if (Session["Project"].ToString() == "tds2")
                        dtList = objSalary.GetComboValues(Convert.ToString(ViewState["ConstID"]), ((Session["AY"] != null) ? Convert.ToString(Session["AY"]) : "2016-2017"), "", ((Session["FY"] != null) ? Session["FY"].ToString() : "2015-2016"));
                    else
                        dtList = objSalary.GetComboValues(Convert.ToString(ViewState["ConstID"]), Convert.ToString(Session["AY"]), "", "");
                    //Following Code is used to fill the dropdowns within the Main Grid 
                    //and takes care of both the direct dropdown values and sql queries based approach from 
                    //comboitems table within dbMain
                    if (dtList.Rows.Count > 0)
                    {
                        ddl1.DataSource = dtList;
                        ddl1.DataTextField = dtList.Rows[0]["datatext"].ToString();
                        ddl1.DataValueField = dtList.Rows[0]["dataVal"].ToString();
                        ddl1.DataBind();

                        ddl1.CssClass = dtList.Rows[0]["IsIndSel"].ToString();
                    }
                    //ddl1.TabIndex = Convert.ToInt16(dtList.Rows[0]["IsIndSel"]);


                    ListItem LstSelect = new ListItem("Select", "-1");
                    ddl1.Items.Insert(0, LstSelect);
                    //ddl1.Items.Insert(0, "----------select----------");
                    Session["ddlgrdState"] = Convert.ToString(ddl1.SelectedValue);
                }

                denStoreTrans objdenStoreTrans = new denStoreTrans();
                dalStoreTrans objdalStoreTrans = new dalStoreTrans();
                if (ViewState["vtype"].ToString() != "105")
                {
                    if (ViewState["vtype"] != null && ViewState["ConstID"] != null)// && ViewState["MainID"] != null)
                    {
                        if (ViewState["MainID"] == null)
                            ViewState["MainID"] = Convert.ToString(Session["NameID"]);
                        if (key == 25)
                        {
                            if (ddl1.SelectedIndex == 0)
                                ViewState["MainID"] = "2";
                            else
                                ViewState["MainID"] = ddl1.SelectedIndex.ToString();
                            ViewState["MainID"] = hdnDDListSelection.Value;
                        }
                        objdenStoreTrans = objdalStoreTrans.GetMainGridData(Convert.ToString(Session["NameID"]), (ViewState["vtype"].ToString().Contains(".aspx") ? 0 : Convert.ToInt32(ViewState["vtype"])), Convert.ToInt32(ViewState["ConstID"]), ViewState["MainID"].ToString(), Session["AY"].ToString());
                        if (objdenStoreTrans.Col3 != "")
                            grdstate_row_cnt += 1;
                    }
                }
                else
                {
                    if (ViewState["vtype"] != null && ViewState["ConstID"] != null && ViewState["MainID"] != null)
                        objdenStoreTrans = objdalStoreTrans.GetMainGridData(Convert.ToString(Session["NameID"]), 49, Convert.ToInt32(ViewState["ConstID"]), ViewState["MainID"].ToString(), Session["AY"].ToString());
                }

                txtAmt2.Text = Convert.ToString(objdenStoreTrans.Col3);
                if (IsReq == 1)
                {
                    Label lblParticulars = new Label();
                    lblParticulars = (Label)e.Row.FindControl("lblParticulars");
                    lblParticulars.Text = lblParticulars.Text.Replace("*", "");
                    lblParticulars.Text += "<span style='color:Red;'>*</span>";
                }
                txtReadOnly.Text = Convert.ToString(objdenStoreTrans.Col3);
                //Checking C19 and C16 if both are 0 then Deatils button will not be shown
                /*This code is to set the text boxes to visible or not regarding the c41 column */

                //Code to implement Rules of T00 Structure based upon the ConstantID Value reflections w.r.t tbl_DataRules

                if (dsDataRules.Tables.Count > 0)
                {
                    if (dsDataRules.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] rows = dsDataRules.Tables[0].Select("Dest_ID = " + ViewState["ConstID"].ToString());
                        if (rows.Length > 0)
                        {
                            foreach (DataRow row1 in rows)
                            {
                                if (row1["Actions"].ToString() == "D")
                                {
                                    txtAmt2.Enabled = false;
                                    txtDate.Enabled = false;
                                    txtReadOnly.Enabled = false;
                                    ddl1.Enabled = false;
                                    LnkButton.Visible = false;
                                }
                                if (row1["Actions"].ToString() == "H")
                                {
                                    txtAmt2.Visible = false;
                                    txtDate.Visible = false;
                                    txtReadOnly.Visible = false;
                                    ddl1.Visible = false;
                                    LnkButton.Visible = false;
                                }
                            }
                        }
                    }
                }


                if (Convert.ToInt32(row.Cells[8].Text) == 0)
                    txtAmt2.Enabled = false;
                if (Convert.ToInt32(row.Cells[4].Text) == 0 && Convert.ToInt32(row.Cells[6].Text) == 0)
                    row.Cells[3].Text = "";
                else
                    detail_cnt += 1;

                if (row.Cells[5].Text == "794")
                {
                    txtDate.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    txtDate.Text = Convert.ToString(objdenStoreTrans.Col3);
                }
                if ((key == 15 || key == 25) && objdenStoreTrans.Col3 != "")// && ddlSelect.SelectedIndex == 1)        commented by mudit on 13-04-2015 for showing data in dropdown
                {
                    if (ddl1.CssClass == "1")
                    {
                        ddl1.SelectedItem.Text = Convert.ToString(objdenStoreTrans.Col3);
                    }
                    else if (ddl1.CssClass == "2")
                    {
                        ddl1.SelectedValue = Convert.ToString(objdenStoreTrans.Col3);
                    }
                    else if (ddl1.CssClass == "3")
                    {
                        ddl1.SelectedIndex = Convert.ToInt32(objdenStoreTrans.Col3);
                    }

                    //if (ddl1.SelectedItem != null)
                    //    ddl1.SelectedItem.Text = Convert.ToString(objdenStoreTrans.Col3);
                    //else 
                    if (ViewState["vtype"].ToString() == "5006")
                        ddl1.SelectedIndex = (ddl1.Items.Count - 1);
                }

                if (Convert.ToBoolean(ViewState["Entry"]) == true)
                {
                    ViewState["Entry"] = false;
                    if (Convert.ToInt32(ViewState["intC1"]) == Convert.ToInt32(e.Row.Cells[5].Text))
                    {
                        TextBox txtAmt;
                        txtAmt = (TextBox)e.Row.Cells[2].FindControl("txtAmount");
                        //txtAmt.Text = Convert.ToString(ViewState["Data"]);
                    }
                    //ViewState["Data"] = "";
                }
                //if (txtAmt2.Text.Contains("-"))
                //    txtAmt2.BorderColor = System.Drawing.Color.Red;

                if (row.Cells[0].Text.Contains("(a)"))
                {
                    row.Cells[0].Text = ((grdState.PageIndex * 20) + e.Row.RowIndex).ToString() + "(a)";
                    grd_row_cnt = 1;
                }
                else if (row.Cells[0].Text.Contains("(b)"))
                {
                    row.Cells[0].Text = ((grdState.PageIndex * 20) + e.Row.RowIndex - 1).ToString() + "(b)";
                    grd_row_cnt = 2;
                }
                else if (row.Cells[0].Text.Contains("(c)"))
                {
                    row.Cells[0].Text = ((grdState.PageIndex * 20) + e.Row.RowIndex - 2).ToString() + "(c)";
                    grd_row_cnt = 3;
                }
                else if (row.Cells[0].Text.Contains("(d)"))
                {
                    row.Cells[0].Text = ((grdState.PageIndex * 20) + e.Row.RowIndex - 3).ToString() + "(d)";
                    grd_row_cnt = 4;
                }
                else if (row.Cells[0].Text.Contains("(e)"))
                {
                    row.Cells[0].Text = ((grdState.PageIndex * 20) + e.Row.RowIndex - 4).ToString() + "(e)";
                    grd_row_cnt = 5;
                }
                else if (row.Cells[0].Text.Contains("(f)"))
                {
                    row.Cells[0].Text = ((grdState.PageIndex * 20) + e.Row.RowIndex - 5).ToString() + "(f)";
                    grd_row_cnt = 6;
                }
                else
                {
                    if (grdState.PageIndex != 0)
                        row.Cells[0].Text = ((grdState.PageIndex * 20) + e.Row.RowIndex + 1 - grd_row_cnt_Paging).ToString();
                    else
                        row.Cells[0].Text = ((grdState.PageIndex * 20) + e.Row.RowIndex + 1 - grd_row_cnt).ToString();


                    grd_row_cnt_Paging = grd_row_cnt;
                    //grd_row_cnt = 0;
                }
                bllSalary objbllSalary = new bllSalary();
                Lst_T00 = objbllSalary.SelectT(Convert.ToString(ViewState["ConstID"]), Session["AY"].ToString(), Session["ITR"].ToString());

                //txtAmt2.TabIndex = (ddlSelect.SelectedIndex == 0) ? Convert.ToInt16(e.Row.RowIndex + 1) : ((Convert.ToInt16(e.Row.RowIndex + 1)) * Convert.ToInt16(ddlSelect.SelectedIndex));
                //string strTextBox
                txtAmt2.TabIndex = Convert.ToInt16(((e.Row.RowIndex + 1)) + ((ddlSelect.SelectedIndex != -1) ? (ddlSelect.SelectedIndex * 20) : 0));
                txtDate.TabIndex = Convert.ToInt16(((e.Row.RowIndex + 1)) + ((ddlSelect.SelectedIndex != -1) ? (ddlSelect.SelectedIndex * 20) : 0)); //Convert.ToInt16(e.Row.RowIndex + 1);
                ddl1.TabIndex = Convert.ToInt16(((e.Row.RowIndex + 1)) + ((ddlSelect.SelectedIndex != -1) ? (ddlSelect.SelectedIndex * 20) : 0)); // Convert.ToInt16(e.Row.RowIndex + 1);
                latest_TabIndx = ddl1.TabIndex;
                //hdnValidations.Value += e.Row.RowIndex.ToString();  //for Validation from Javascript (for Master Page)
                for (int i = 0; i < Lst_T00.Count; i++)
                {
                    if (ViewState["ConstID"].ToString() == Lst_T00[i].t00_c1)
                    {
                        //hdnValidations.Value+="_"+Lst_T00[i].Validation+"="+Lst_T00[i].ValidationString;
                        //if (Lst_T00[i].IsRow == 1)
                        //{
                        //    e.Row.Attributes.Add(Lst_T00[i].Validation, Lst_T00[i].ValidationString);
                        //}
                        //else
                        //{
                        txtAmt2.Attributes.Add(Lst_T00[i].Validation, Lst_T00[i].ValidationString);
                        txtDate.Attributes.Add(Lst_T00[i].Validation, Lst_T00[i].ValidationString);
                        ddl1.Attributes.Add(Lst_T00[i].Validation, Lst_T00[i].ValidationString);
                        txtReadOnly.Attributes.Add(Lst_T00[i].Validation, Lst_T00[i].ValidationString);
                        //}
                    }
                }
                //if (e.Row.RowIndex == 0)
                //    txtAmt2.Focus();
                //hdnValidations.Value += "~";
            }
            catch (Exception ex)
            {
                throw ex;
            }


            //if (e.Row.RowIndex != -1)
            //{
            //    Control LnkButton;
            //    LnkButton = (LinkButton)e.Row.Cells[3].FindControl("btnLink");
            //    GridViewRow row = (GridViewRow)LnkButton.NamingContainer;

            //    ViewState["ConstID"] = Convert.ToInt32(row.Cells[5].Text);
            //    TextBox txtAmt2 = (TextBox)e.Row.Cells[2].FindControl("txtAmount");

            //    for (int i = 0; i < Lst_T00.Count; i++)
            //    {
            //        if (ViewState["ConstID"].ToString() == Lst_T00[i].t00_c1)
            //            txtAmt2.Attributes.Add(Lst_T00[i].Validation, Lst_T00[i].ValidationString);
            //    }
            //}
        }
    }

    //This function is to fire all the rules together after the complete Grid is loaded so all rules could work according to the values of all constantIDs with in the Screen
    public void fireRules()
    {
        bllSalary objbllSalary = new bllSalary();
        DataTable dt = new DataTable();
        dt = objbllSalary.loadRules(Session["AY"].ToString(), Session["ITR"].ToString());
        DataRow[] rows = null;
        string strScripts = "";
        DropDownList ddl1 = new DropDownList();
        for (int i = 0; i < grdState.Rows.Count; i++)
        {
            rows = dt.Select("t00_c1='" + grdState.Rows[i].Cells[5].Text + "'");
            if (rows.Length > 0)
            {
                //Response.Write(rows.Length.ToString());
                if (rows[0]["C10"].ToString() == "15")
                {
                    ddl1 = (DropDownList)grdState.Rows[i].FindControl("ddl1");
                    strScripts += rows[0]["ValidationString"].ToString().Replace("showSpinner(this)", "").Replace("this", "document.getElementById('" + ddl1.ClientID + "')") + ";";
                }
                //strScripts += rows[0]["C10"].ToString();
            }
        }
        if (strScripts.Length > 1)
            strScripts = strScripts.Remove(strScripts.Length - 1);
        //strScripts = strScripts.Replace("(", "('").Replace(")", "')").Replace(",", "','");
        //ClientScript.RegisterStartupScript(GetType(), "asd", "<script type='text/javascript'>" + strScripts + " </script>");
        //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>callEvents('" + ddl1.ClientID + "'); </script>");
        hdnScript.Value = strScripts;
        //strScripts = "return HideRows('document.getElementById(''grdState_ctl11_ddl1'')','11');showhideLinkBtn('document.getElementById(''grdState_ctl12_ddl1'')')";
        //strScripts = "HideRows(document.getElementById('grdState_ctl11_ddl1'),'11');showhideLinkBtn(document.getElementById('grdState_ctl12_ddl1'))";
        //Response.Write("<script type='text/javascript'>function scriptsAll(){try{alert('scripts all');showhideLinkBtn('grdState_ctl12_ddl1');}catch(e){alert(e)}}</script>");
        ltScript.Text = "<script type='text/javascript'>function scriptsAll(){" + strScripts.Replace("return", "") + "}</script>";
        //Response.Write("<script type='text/javascript'>function scriptsAll(){" + strScripts + "}}</script>");
        //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>setTimeout(scriptsAll,1200);</script>");
        //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>time_delay();HideRows('grdState_ctl11_ddl1',11);showhideLinkBtn('grdState_ctl12_ddl1'); </script>");
    }

    //This is the Details Button Click Event for Main Grid
    protected void btnLink_Click(object sender, EventArgs e)
    {
        FloatRowCnt = 0;
        ViewState["rowYN"] = null;
        Session["float"] = null;

        Control btnLnk = (Control)sender;
        GridViewRow row = (GridViewRow)btnLnk.NamingContainer;
        ViewState["C40"] = Convert.ToInt32(row.Cells[9].Text);
        ViewState["intC1"] = Convert.ToInt32(row.Cells[5].Text);

        //hdnValidations_Detail
        //ViewState["AY"]="2007-2008";
        ViewState["C16"] = Convert.ToInt16(row.Cells[6].Text);
        ViewState["C19"] = Convert.ToInt16(row.Cells[11].Text);
        if (row.Cells[0].Text.Contains("(") && row.Cells[0].Text.Contains(")"))
            ViewState["GRowNo"] = Convert.ToInt32(row.Cells[0].Text.Substring(0, row.Cells[0].Text.Length - 3));
        else
            ViewState["GRowNo"] = Convert.ToInt32(row.Cells[0].Text);
        Label lblSerial = new Label();
        lblSerial = (Label)row.FindControl("lblSerial");

        ViewState["GRowNo"] = Convert.ToInt32(lblSerial.Text);
        bllT4 objbllT4 = new bllT4();
        bllFloating objbllFloating = new bllFloating();

        Label lblInfo = new Label();
        string ss = "";
        for (int i = 0; i < row.Cells.Count; i++)
        {
            ss += row.Cells[i].Text;
        }

        lblInfo = (Label)grdState.Rows[row.RowIndex].FindControl("lblParticulars");
        Label2.Text = lblInfo.Text;

        if (Convert.ToInt16(ViewState["C16"]) == 0 && Convert.ToInt32(ViewState["C40"]) == 0)
        {
            if (Convert.ToInt16(ViewState["C19"]) == 2)
            {
                //updpnl22.ContentTemplateContainer.Controls.Clear();
                //UserControls_FileUploadDirectoryCtrk objUpldCtrl = LoadControl("../UserControls/FileUploadDirectoryCtrk.ascx") as UserControls_FileUploadDirectoryCtrk;
                ////WebUserControl objUpldCtrl = LoadControl("../UserControls/WebUserControl.ascx") as WebUserControl;
                //updpnl22.ContentTemplateContainer.Controls.Add(objUpldCtrl);
                hdnUploadPnl.Value = "2";
            }
            else if (Convert.ToInt16(ViewState["C19"]) == 3)
            {
                //updpnl22.ContentTemplateContainer.Controls.Clear();
                //WebUserControl objUpldCtrl = LoadControl("../UserControls/WebUserControl.ascx") as WebUserControl;
                //updpnl22.ContentTemplateContainer.Controls.Add(objUpldCtrl);
                hdnUploadPnl.Value = "2";
            }
            else
            {
                //Fetch T4 Rules to implement as Validations:
                bllSalary objbllSalary = new bllSalary();
                Lst_T4 = objbllSalary.SelectT4_Rules(ViewState["intC1"].ToString(), Session["AY"].ToString());

                //InsertDataDetailsGrid(Convert.ToInt32(ViewState["intC1"]));
                List<denT4> objList = new List<denT4>();
                objList = objbllT4.GetParticulars(Convert.ToInt32(ViewState["intC1"]), 2, Convert.ToString(Session["AY"]));

                if (ViewState["intC1"].ToString() == "808" || ViewState["intC1"].ToString() == "844" || ViewState["intC1"].ToString() == "9808" || ViewState["intC1"].ToString() == "152217" || ViewState["intC1"].ToString() == "152222" || ViewState["intC1"].ToString() == "152227")
                {

                    string strRes = "0";
                    //objbllT4.getRowYesNo(Convert.ToInt32(ViewState["intC1"]), Convert.ToString(Session["AY"]), out strRes);

                    //ViewState["rowYN"] = strRes;

                    gvDetails2.DataSourceID = "ObjectDataSource2";
                    mltView.ActiveViewIndex = 7;

                    DataTable dt = new DataTable();
                    bllStoreTrans objbllStoreTrans = new bllStoreTrans();
                    dt = objbllStoreTrans.Select(Convert.ToString(Session["NameID"]), 40, Convert.ToInt32(ViewState["intC1"]));
                    int cnt = 0;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (GridViewRow row1 in gvDetails2.Rows)
                        {
                            if (row1.Visible)
                            {
                                DropDownList dd = new DropDownList();
                                dd = (DropDownList)row1.FindControl("ddlYesNo");
                                if (dt.Rows.Count > cnt)
                                    dd.SelectedValue = (dt.Rows[cnt]["Col2"].ToString() == "Yes") ? "1" : "0";
                                DoYesNo2(dd);
                            }
                            cnt += 1;
                        }
                    }
                    //Response.Write("conter: " + cnt.ToString());
                }
                else
                {
                    GridViewDetails.DataSourceID = "ObjectDataSource2";
                    mltView.ActiveViewIndex = 3;
                }
            }
        }
        else if (Convert.ToInt16(ViewState["C16"]) == 0 && Convert.ToInt32(ViewState["C40"]) > 0)   //this condition applies to audit report data only
        {
            ViewState["intC1"] = ViewState["C40"];
            InsertDataDetailsGrid(Convert.ToInt32(ViewState["intC1"]));
            objbllT4.GetParticulars(Convert.ToInt32(ViewState["intC1"]), 2, Convert.ToString(Session["AY"]));

            GridViewDetails.DataSourceID = "ObjectDataSource2";
            mltView.ActiveViewIndex = 3;
        }
        else if (Convert.ToInt16(ViewState["C16"]) > 0)
        {
            //objbllFloating.GetFlaotingHeaders(Convert.ToString(ViewState["NameID"]),Convert.ToInt16(ViewState["C16"]),Convert.ToInt16(ViewState["intC1"]));
            //GridViewFlaoting.DataSourceID="ObjectDataSource4";
            Session["float"] = "true";
            mltView.ActiveViewIndex = 4;
            GridViewFlaoting.DataSourceID = "ObjectDataSource4";

            DataTable dtFloat_Rules = new DataTable();
            string ValCols = "";
            string strFloatRule = "";

            dtFloat_Rules = objbllFloating.SelectT1000_Rules(Convert.ToInt16(ViewState["C16"]), Session["AY"].ToString(), Session["ITR"].ToString());
            if (dtFloat_Rules.Rows.Count > 0)
            {
                ValCols = dtFloat_Rules.Rows[0]["ValidationColumns"].ToString();
                strFloatRule = dtFloat_Rules.Rows[0]["ValidationColumns"].ToString();
            }
            for (int i = 0; i < dtFloat_Rules.Rows.Count; i++)
            {
                if (ValCols != dtFloat_Rules.Rows[i]["ValidationColumns"].ToString())
                    strFloatRule += "~" + dtFloat_Rules.Rows[i]["ValidationColumns"].ToString();

                strFloatRule += "_" + dtFloat_Rules.Rows[i]["Validation"].ToString() + "=" + dtFloat_Rules.Rows[i]["ValidationString"].ToString();
            }
            hdnValidations_Detail.Value = strFloatRule;
            string strFloatData = objbllFloating.IsFloatSec(Convert.ToInt32(ViewState["C16"]));
            string[] arrFltDt = System.Text.RegularExpressions.Regex.Split(strFloatData, "~");
            bool IsSec = false;
            FloatRowCnt = Convert.ToInt32(arrFltDt[0]);

            if (arrFltDt[0] != "0" && arrFltDt[1] != "0")
                IsSec = true;
            //if (ViewState["intC1"].ToString() == "2054" || ViewState["intC1"].ToString() == "2055" || ViewState["intC1"].ToString() == "2056" || ViewState["intC1"].ToString() == "2057" || ViewState["intC1"].ToString() == "2058" || ViewState["intC1"].ToString() == "2059" || ViewState["intC1"].ToString() == "2060" || ViewState["intC1"].ToString() == "2061" || ViewState["intC1"].ToString() == "2062" || ViewState["intC1"].ToString() == "2063" || ViewState["intC1"].ToString() == "2064" || ViewState["intC1"].ToString() == "152522" || ViewState["intC1"].ToString() == "802")
            if (IsSec)
            {
                denFloating objdenFloating2 = new denFloating();
                objdenFloating2.NameID = Session["NameID"].ToString();
                objdenFloating2.AY = Session["AY"].ToString();
                objdenFloating2.HeaderID = ViewState["C16"].ToString();
                objbllFloating.InsertFloatManagedData(objdenFloating2);
                btnInsertFloatGrid.Visible = false;
                //addRow_Float();
            }
            else
                btnInsertFloatGrid.Visible = true;

            bllSalary objbllSalary = new bllSalary();
            Lst_T1000 = objbllSalary.Select(Convert.ToInt32(ViewState["C16"]), ViewState["vtype"].ToString(), Session["ITR"].ToString(), Session["AY"].ToString());
        }
        if (GridViewFlaoting.Rows.Count >= FloatRowCnt)
            btnInsertFloatGrid.Visible = false;
        denScreen objdenscreen = new denScreen();
        objdenscreen = objBllScreen.getSettings(Convert.ToInt16(ViewState["vtype"]));
        lblSubHeading.Text = "Details of  " + lblInfo.Text;// ddlSelect.SelectedItem;
        if (Convert.ToInt32(ViewState["C19"]) < 2)
            grdState.DataSourceID = "";
        bolTFCheck = false;
        //nishu 22/8/2015
        hdnValidate.Value = "false";
        btnInsertFloatGrid.Visible = true;
        if (ViewState["intC1"].ToString() == "3026")
            btnOK.Style.Add("display", "none");
        else
            btnOK.Style.Remove("display");
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["intIndex"] = ViewState["intC1"];
        if (Convert.ToInt32(ViewState["intC1"]) != 808 && Convert.ToInt32(ViewState["intC1"]) != 844 && Convert.ToInt32(ViewState["intC1"]) != 9808 && Convert.ToInt32(ViewState["intC1"]) != 152217 && Convert.ToInt32(ViewState["intC1"]) != 152222 && Convert.ToInt32(ViewState["intC1"]) != 152227)
        {
            if (Convert.ToString(ViewState["YesNo"]).Length != 0)
            {
                e.InputParameters["yn"] = Convert.ToInt16(ViewState["YesNo"]);
            }
            else
            {
                e.InputParameters["yn"] = 1;
            }
            e.InputParameters["AYear"] = Convert.ToString(Session["AY"]);
        }
        else
        {
            e.InputParameters["yn"] = 2;
            e.InputParameters["AYear"] = Convert.ToString(Session["AY"]);
        }
    }

    //Cancel Button of Second Grid
    protected void Button4_Click(object sender, EventArgs e)
    {
        //in case of capital gains
        GridAssetType.DataSourceID = "";
        GridAssetType.DataSourceID = "ObjectDataSource6";
        GridViewDetails.Columns[2].HeaderStyle.CssClass = "hiddencol";
        GridViewDetails.Columns[2].ItemStyle.CssClass = "hiddencol";
        GridViewFlaoting.DataSourceID = "";
        Session["Common"] = null;
        //if (Convert.ToInt32(ViewState["SaleID"]) == 5)
        //    //in case of capital gains
        //    mltView.ActiveViewIndex = 0;
        //else
        //rest all cases
        mltView.ActiveViewIndex = 0;

        btnRadioSimple.Checked = true;
        btnRadiodetailed.Checked = false;
    }

    //Ok Button of Second Grid (Float Grid)
    protected void Button2_Click(object sender, EventArgs e)
    {//nishu 24/8/2015
        hdnValidate.Value = "false";
        //TextBox TextAmount; 
        //if (ViewState["intC1"].ToString() == "1001" || ViewState["intC1"].ToString() == "1002" || ViewState["intC1"].ToString() == "1003" || ViewState["intC1"].ToString() == "1031")
        if (false)
        {
            GridViewDetails.Columns[2].HeaderStyle.CssClass = "hiddencol";
            GridViewDetails.Columns[2].ItemStyle.CssClass = "hiddencol";

            //calc80G();

            ViewState["Entry"] = true;
            grdState.DataSourceID = "ObjectDataSource1";
            mltView.ActiveViewIndex = 0;
            GridViewDetails.DataSourceID = "";
            GridViewFlaoting.DataSourceID = "";
            ViewState["Data"] = "";
            Session["Common"] = null;
        }
        else
        {


            hdnValidate.Value = "false";
            GridViewDetails.Columns[2].HeaderStyle.CssClass = "hiddencol";
            GridViewDetails.Columns[2].ItemStyle.CssClass = "hiddencol";

            denStoreTrans objStoreTransDEN, objstoreTransDEN2;
            bllStoreTrans objStoreTransBLL;

            objStoreTransDEN = new denStoreTrans();
            objstoreTransDEN2 = new denStoreTrans();
            objStoreTransBLL = new bllStoreTrans();

            objStoreTransDEN.ConstID = Convert.ToInt32(ViewState["intC1"]);
            objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
            objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
            objStoreTransDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
            objStoreTransDEN.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
            //string sss = ViewState["ComboItem"].ToString();
            if (ViewState["ComboItem"] != null)
                objStoreTransDEN.ComboItemNo = (ViewState["ComboItem"].ToString() == "NaN") ? 0 : Convert.ToInt32(ViewState["ComboItem"]);
            else
                objStoreTransDEN.ComboItemNo = 0;
            objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
            objStoreTransDEN.GRowNo = Convert.ToInt32(ViewState["GRowNo"]);
            objStoreTransDEN.IsEnterFDet = 1;
            objStoreTransDEN.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());

            objstoreTransDEN2.NameID = Convert.ToString(Session["NameID"]);
            objstoreTransDEN2.Vtype = Convert.ToInt32(ViewState["vtype"]);
            objstoreTransDEN2.MainID = Convert.ToInt32(ViewState["MainID"]);
            objstoreTransDEN2.ConstID = Convert.ToInt32(ViewState["intC1"]);
            objstoreTransDEN2.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
            if (Session["Status"] != null)
                objstoreTransDEN2.AssesseeType = (Session["Status"].ToString() != "") ? Convert.ToInt32(Session["Status"]) : 0;
            objstoreTransDEN2.AY = Convert.ToString(Session["AY"]);
            objstoreTransDEN2.GRowNo = Convert.ToInt32(ViewState["GRowNo"]);
            objstoreTransDEN2.IsEnterFDet = 1;
            objstoreTransDEN2.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());

            if (Session["float"] != null)
            {
                if (Session["float"].ToString() == "true")
                {
                    hdnValidate.Value = "false";
                    objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, ViewState["vtype"].ToString(), Convert.ToInt16(ViewState["C16"]));
                }
            }
            else
            {
                hdnValidate.Value = "false";
                objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 0, ViewState["vtype"].ToString(), Convert.ToInt16(ViewState["C16"]));
            }

            if (Convert.ToInt32(ViewState["vtype"]) == 62 || Convert.ToInt32(ViewState["vtype"]) == 3002 || Convert.ToInt32(ViewState["vtype"]) == 3003)
            {
                objStoreTransBLL.RunShowCalcOnOKButton(objstoreTransDEN2);
                grdState.DataSourceID = "";
                grdState.DataSourceID = "ObjectDataSource1";
                hdnValidate.Value = "false";
                if (objstoreTransDEN2.ConstID == 3024)
                {
                    objstoreTransDEN2.NameID = Session["NameID"].ToString();
                    objstoreTransDEN2.AY = Session["AY"].ToString();
                    objstoreTransDEN2.FY = Session["FY"].ToString();
                    objStoreTransBLL.TDSCalculation(objstoreTransDEN2, Session["Project"].ToString());
                    grdState.DataSourceID = "";
                    grdState.DataSourceID = "ObjectDataSource1";
                    hdnValidate.Value = "false";
                }
                //else
                //{

                //}
            }
            ViewState["Entry"] = true;
            grdState.DataSourceID = "ObjectDataSource1";
            mltView.ActiveViewIndex = 0;
            GridViewDetails.DataSourceID = "";
            GridViewFlaoting.DataSourceID = "";
            ViewState["Data"] = "";
            Session["Common"] = null;
            hdnValidate.Value = "false";
        }
        //addRow_Float();
    }

    protected void GridViewDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Control txt = (TextBox)e.Row.Cells[3].FindControl("txtAmount");
        //This code is used to fetch records from Database
        if (e.Row.DataItemIndex != -1)
        {
            int intSubConstantID = Convert.ToInt32(e.Row.Cells[5].Text);
            TextBox txtAmt2 = (TextBox)e.Row.Cells[3].FindControl("txtAmount");
            DropDownList dd1 = new DropDownList();
            dd1 = (DropDownList)e.Row.FindControl("dd1");

            denStoreTrans objdenStoreTrans = new denStoreTrans();
            dalStoreTrans objdalStoreTrans = new dalStoreTrans();

            //Applying Validations for T4:
            for (int cnt = 0; cnt < Lst_T4.Count; cnt++)
            {
                if (Lst_T4[cnt].t4_c1 == intSubConstantID.ToString())
                {
                    if (Lst_T4[cnt].DropdownQry != "0")
                    {

                        dd1.Visible = true;
                        txtAmt2.Visible = false;
                        bllSalary objbllSalary = new bllSalary();
                        DataTable dtDD = new DataTable();
                        dtDD = objbllSalary.Select(Lst_T4[cnt].DropdownQry);

                        dd1.DataSource = dtDD;
                        dd1.DataTextField = Lst_T4[cnt].ddText;
                        dd1.DataValueField = Lst_T4[cnt].ddVal;
                        dd1.DataBind();
                    }
                    else
                        txtAmt2.Attributes.Add(Lst_T4[cnt].Validation, Lst_T4[cnt].ValidationString);
                }
            }
            //Lst_T4

            objdenStoreTrans = objdalStoreTrans.GetSubGridData(Convert.ToString(Session["NameID"]), Convert.ToInt32(ViewState["vtype"]), Convert.ToInt32(ViewState["intC1"]), intSubConstantID, Convert.ToString(Session["AY"]));
            txtAmt2.Text = Convert.ToString(objdenStoreTrans.Col3);
            if (dd1.Visible == true)
                dd1.SelectedValue = Convert.ToString(objdenStoreTrans.Col3);
            e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();

            if (dsDataRules.Tables.Count > 0)
            {
                //int intSubConstantID = Convert.ToInt32(e.Row.Cells[5].Text);
                //TextBox txtAmt2 = (TextBox)e.Row.Cells[3].FindControl("txtAmount");
                if (dsDataRules.Tables[2].Rows.Count > 0)
                {
                    DataRow[] rows = dsDataRules.Tables[2].Select("T4_SubID = " + intSubConstantID);
                    if (rows.Length > 0)
                    {
                        foreach (DataRow row1 in rows)
                        {
                            if (row1["Actions"].ToString() == "D")
                                txtAmt2.Enabled = false;
                            if (row1["Actions"].ToString() == "H")
                                txtAmt2.Visible = false;
                        }
                    }
                }
            }
        }

        if ((ViewState["intC1"].ToString() == Convert.ToString(8209) || ViewState["intC1"].ToString() == Convert.ToString(803) || ViewState["intC1"].ToString() == Convert.ToString(821) || ViewState["intC1"].ToString() == Convert.ToString(829) || ViewState["intC1"].ToString() == Convert.ToString(852) || ViewState["intC1"].ToString() == Convert.ToString(869) || ViewState["intC1"].ToString() == Convert.ToString(107) || ViewState["intC1"].ToString() == Convert.ToString(126) || ViewState["intC1"].ToString() == Convert.ToString(9808) || ViewState["intC1"].ToString() == Convert.ToString(152217) || ViewState["intC1"].ToString() == Convert.ToString(152222) || ViewState["intC1"].ToString() == Convert.ToString(152227)) && bolTFCheck == false && e.Row.DataItemIndex != -1)
        {
            bllStoreTrans objStoreTransBLL = new bllStoreTrans();
            denStoreTrans objStoreTransDEN;
            objStoreTransDEN = objStoreTransBLL.GetSubGridData(Convert.ToString(Session["NameID"]), Convert.ToInt32(ViewState["vtype"]), Convert.ToInt32(ViewState["intC1"]), Convert.ToInt32(e.Row.Cells[5].Text), Convert.ToString(Session["AY"]));
            string str;
            str = objStoreTransDEN.col2;

            bolTFCheck = true;
            Control txt = (TextBox)e.Row.Cells[3].FindControl("txtAmount");
            DropDownList ddl = (DropDownList)e.Row.Cells[2].FindControl("ddlYesNo");
            ddl.Visible = true;
            if (str == "No")
                ddl.SelectedValue = "0";

            else
                ddl.SelectedValue = "1";

            ddl.SelectedValue = Convert.ToString(ViewState["YesNo"]);
            txt.Visible = false;
            GridViewDetails.Columns[2].HeaderStyle.CssClass = "";
            GridViewDetails.Columns[2].ItemStyle.CssClass = "";
        }
        else if (ViewState["intC1"].ToString() == Convert.ToString(808) && bolTFCheck == false && e.Row.DataItemIndex != -1 && e.Row.RowIndex == 1)
        {
            bolTFCheck = true;

            Control txt = (TextBox)e.Row.Cells[3].FindControl("txtAmount");
            DropDownList ddl = (DropDownList)e.Row.Cells[2].FindControl("ddlYesNo");
            //New code Try
            if (e.Row.Cells[4].Text == "1")
            {
                ddl.Visible = true;

            }
            else
                ddl.Visible = false;

            ddl.SelectedValue = Convert.ToString(ViewState["YesNo"]);
            txt.Visible = false;

            GridViewDetails.Columns[2].HeaderStyle.CssClass = "";
            GridViewDetails.Columns[2].ItemStyle.CssClass = "";
        }
        else if (e.Row.DataItemIndex != -1)
        {
            Control ddl = (DropDownList)e.Row.Cells[2].FindControl("ddlYesNo");
            ddl.Visible = false;
            if (Convert.ToString(ViewState["YesNo"]) == "0" && e.Row.RowIndex == 2 && Convert.ToInt32(ViewState["intC1"]) == 808)
                e.Row.Visible = false;
            else if (Convert.ToString(ViewState["YesNo"]) == "1" && e.Row.RowIndex == 2 && Convert.ToInt32(ViewState["intC1"]) == 808)
                e.Row.Visible = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GridViewDetails.Rows[1].Visible = false;
    }
    protected void GridViewDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvDetails2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            if (ViewState["intC1"].ToString() == Convert.ToString(808) && e.Row.RowIndex == 0)
            {
                e.Row.Visible = false;
            }
            else
            {
                gvDetails2.Columns[2].HeaderStyle.CssClass = "";
                gvDetails2.Columns[2].ItemStyle.CssClass = "";
                if (ViewState["YesNo"] == null)
                {
                    if (e.Row.Cells[0].Text.Contains("("))
                    {
                        e.Row.Visible = false;
                    }
                    else
                    {
                        e.Row.Visible = true;
                    }
                }
                Control txt = (TextBox)e.Row.Cells[3].FindControl("txtAmount");
                DropDownList ddl = (DropDownList)e.Row.Cells[2].FindControl("ddlYesNo");

                if (e.Row.Cells[4].Text == "1")
                {
                    ddl.Visible = true;

                    txt.Visible = false;
                }
                else
                {
                    ddl.Visible = false;
                    txt.Visible = true;
                }
            }
        }

        if (e.Row.DataItemIndex != -1)
        {
            int intSubConstantID = Convert.ToInt32(e.Row.Cells[13].Text);
            TextBox txtAmt2 = (TextBox)e.Row.Cells[3].FindControl("txtAmount");


            denStoreTrans objdenStoreTrans = new denStoreTrans();
            dalStoreTrans objdalStoreTrans = new dalStoreTrans();

            objdenStoreTrans = objdalStoreTrans.GetSubGridData(Convert.ToString(Session["NameID"]), Convert.ToInt32(ViewState["vtype"]), Convert.ToInt32(ViewState["intC1"]), intSubConstantID, Convert.ToString(Session["AY"]));
            txtAmt2.Text = Convert.ToString(objdenStoreTrans.Col3);

        }
    }

    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {

        denStoreTrans objdenStoreTrans2 = new denStoreTrans();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        DropDownList ddl1 = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl1.NamingContainer;
        if (ddl1.ToolTip != "25")
        {
            //if (ddl1.SelectedIndex > 0)
            //{
            int i;
            // ViewState["SubConstID"] = Convert.ToInt32(row.Cells[5].Text);
            ViewState["intC1"] = Convert.ToInt32(row.Cells[5].Text);

            Label lblSerial = new Label();
            lblSerial = (Label)row.FindControl("lblSerial");

            if (row.Cells[0].Text.Contains("("))
            {
                ViewState["GRowNo"] = Convert.ToInt32(row.Cells[0].Text.Remove(row.Cells[0].Text.Length - 3));
            }
            else
            {
                ViewState["GRowNo"] = Convert.ToInt32(row.Cells[0].Text);
            }
            ViewState["GRowNo"] = Convert.ToInt32(lblSerial.Text);
            objdenStoreTrans2.NameID = Convert.ToString(Session["NameID"]);
            objdenStoreTrans2.Vtype = Convert.ToInt32(ViewState["vtype"]);
            objdenStoreTrans2.MainID = Convert.ToInt32(ViewState["MainID"]);
            objdenStoreTrans2.ConstID = Convert.ToInt32(ViewState["intC1"]);
            objdenStoreTrans2.GRowNo = Convert.ToInt32(ViewState["GRowNo"]);
            //objdenStoreTrans.SubConstID = Convert.ToInt32(ViewState["SubConstID"]);

            objdenStoreTrans2.GIndex = Convert.ToInt32(ViewState["GridIndex"]);

            if (ddl1.CssClass == "1")
                objdenStoreTrans2.Col3 = Convert.ToString(ddl1.SelectedItem.Text);
            else if (ddl1.CssClass == "2")
                objdenStoreTrans2.Col3 = Convert.ToString(ddl1.SelectedValue);
            else if (ddl1.CssClass == "3")
                objdenStoreTrans2.Col3 = Convert.ToString(ddl1.SelectedIndex);

            objdenStoreTrans2.AY = Convert.ToString(Session["AY"]);
            objdenStoreTrans2.ComboItemNo = ddlSelect.SelectedIndex;
            objdenStoreTrans2.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());

            i = objbllStoreTrans.CheckMainGrid(objdenStoreTrans2);
            if (i <= 0)
                objbllStoreTrans.InsertDataMainGrid(objdenStoreTrans2, out msg_IIF);
            else
                objbllStoreTrans.UpdateMainGrid(objdenStoreTrans2, out msg_IIF);

            //if (grdState.Rows[grdState.Rows.Count - 1].RowIndex != row.RowIndex)
            //{
            //    TextBox txt = (TextBox)grdState.Rows[row.RowIndex + 1].Cells[3].FindControl("txtAmount");
            //    ScriptManager1.SetFocus(txt);
            //}
            //}
            //DataRules();
            IsTextChanged = true;
            grdState_RowIndx = row.RowIndex;// +1;
        }
        grdState.DataSourceID = "";
        grdState.DataSourceID = "ObjectDataSource1";
    }

    protected void DOYesNo(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        DoYesNo2(ddl);
    }

    private void DoYesNo2(DropDownList ddl)
    {
        denStoreTrans objStoreTransDEN;
        bllStoreTrans objStoreTransBLL;

        objStoreTransDEN = new denStoreTrans();
        objStoreTransBLL = new bllStoreTrans();
        if (ViewState["intC1"].ToString() == "808" || ViewState["intC1"].ToString() == "844" || ViewState["intC1"].ToString() == "9808" || ViewState["intC1"].ToString() == "152217" || ViewState["intC1"].ToString() == "152222" || ViewState["intC1"].ToString() == "152227")
        {

            ViewState["YesNo"] = ddl.SelectedValue;

            if (Convert.ToInt32(ViewState["YesNo"]) == 0)
            {
                YN = "No";
                GridViewRow row = (GridViewRow)ddl.NamingContainer;

                foreach (GridViewRow row1 in gvDetails2.Rows)
                {
                    if (row1.RowIndex >= Convert.ToInt32(row.Cells[11].Text) - 1 && row1.RowIndex <= Convert.ToInt32(row.Cells[12].Text) - 1)
                    {
                        row1.Visible = false;
                    }
                }
                foreach (GridViewRow row1 in gvDetails2.Rows)
                {
                    if (row1.RowIndex >= Convert.ToInt32(row.Cells[9].Text) - 1 && row1.RowIndex <= Convert.ToInt32(row.Cells[10].Text) - 1)
                    {
                        row1.Visible = true;
                    }
                }

            }
            else if (Convert.ToInt32(ViewState["YesNo"]) == 1)
            {
                YN = "Yes";
                GridViewRow row = (GridViewRow)ddl.NamingContainer;


                foreach (GridViewRow row1 in gvDetails2.Rows)
                {
                    if (row1.RowIndex >= Convert.ToInt32(row.Cells[5].Text) - 1 && row1.RowIndex <= Convert.ToInt32(row.Cells[6].Text) - 1)
                    {
                        row1.Visible = true;
                    }
                }
                foreach (GridViewRow row1 in gvDetails2.Rows)
                {
                    if (row1.RowIndex >= Convert.ToInt32(row.Cells[7].Text) - 1 && row1.RowIndex <= Convert.ToInt32(row.Cells[8].Text) - 1)
                    {
                        row1.Visible = false;
                    }
                }
            }
            GridViewRow roww = (GridViewRow)ddl.NamingContainer;

            objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
            objStoreTransDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
            objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
            objStoreTransDEN.ConstID = Convert.ToInt32(ViewState["intC1"]);
            objStoreTransDEN.SubConstID = Convert.ToInt32(roww.Cells[13].Text);
            objStoreTransDEN.col2 = YN;
            //objStoreTransDEN.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
            //objStoreTransDEN.Col3 = "0";
            objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
            //objStoreTransBLL.UpdateDetailsGrid(objStoreTransDEN);

            //DDL_SelectedIndexChanged(sender,e);
            objStoreTransBLL.UpdateDetailsGridYesNo(objStoreTransDEN);
        }
        else
        {
            GridViewDetails.DataSourceID = "";
            GridViewDetails.DataSourceID = "ObjectDataSource2";

            gvDetails2.DataSourceID = "";
            gvDetails2.DataSourceID = "ObjectDataSource2";

            ViewState["YesNo"] = ddl.SelectedValue;
            if (Convert.ToInt32(ViewState["YesNo"]) == 0)
            {
                YN = "No";
            }
            else if (Convert.ToInt32(ViewState["YesNo"]) == 1)
            {
                YN = "Yes";
            }


            //DropDownList ddlYN = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
            objStoreTransDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
            objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
            objStoreTransDEN.ConstID = Convert.ToInt32(ViewState["intC1"]);
            objStoreTransDEN.SubConstID = Convert.ToInt32(row.Cells[5].Text);
            objStoreTransDEN.col2 = YN;
            //objStoreTransDEN.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
            //objStoreTransDEN.Col3 = "0";
            objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
            //objStoreTransBLL.UpdateDetailsGrid(objStoreTransDEN);

            //DDL_SelectedIndexChanged(sender,e);
            objStoreTransBLL.UpdateDetailsGridYesNo(objStoreTransDEN);
        }
    }

    protected void ObjectDataSource4_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["strNameID"] = Convert.ToString(Session["NameID"]);
        e.InputParameters["intC16"] = Convert.ToInt16(ViewState["C16"]);
        //e.InputParameters["intconstID"] = Convert.ToInt16(ViewState["intC1"]);
        e.InputParameters["intconstID"] = Convert.ToInt32(ViewState["intC1"]);
        if (Convert.ToInt32(ViewState["Selection"]) != 1 && Convert.ToInt32(ViewState["Selection"]) != 0)
        {
            ViewState["Selection"] = 0;
        }
        e.InputParameters["mainID"] = Convert.ToString(ViewState["MainID"]);
        e.InputParameters["intSelection"] = Convert.ToInt32(ViewState["Selection"]);

    }

    protected void GridViewFlaoting_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            if (Lst_T1000.Count > 0)
            {
                DataTable dt = new DataTable();
                DataSet dsCond = new DataSet();
                bllSalary objbllSalary = new bllSalary();
                for (int j = 0; j < Lst_T1000.Count; j++)
                {
                    if (Lst_T1000[j].DropdownQry != "0")
                        dt = objbllSalary.Select(Lst_T1000[j].DropdownQry);
                    int cnt = 0;
                    cnt = 0;
                    int cntVal = 0;

                    for (int i = 1; i < GridViewFlaoting.Columns.Count; i++)
                    {
                        TextBox txtTotal = e.Row.Cells[i].Controls[1] as TextBox;
                        //txtTotal.TabIndex = Convert.ToInt16(i);
                        DropDownList dd = e.Row.Cells[i].Controls[3] as DropDownList;
                        if (Lst_T1000[j].DropDownColumns == (i).ToString())
                        {
                            dd.ClearSelection();
                            txtTotal.Visible = false;
                            dd.Visible = true;
                            dd.DataSource = dt;
                            dd.DataTextField = Lst_T1000[j].ddText;
                            dd.DataValueField = Lst_T1000[j].ddVal;
                            dd.DataBind();
                            dd.SelectedValue = txtTotal.Text;
                            // rows[0]["ID"].ToString();
                            //dd.SelectedIndex = dd.Items.Count - 1;
                            //if (i == 1)
                            //    dd.SelectedValue = dd.ToolTip;
                            //if (i == 1)
                            //if (dd.Items.Count > 0)
                            //    dd.SelectedValue = txtTotal.Text;
                            cnt += 1;
                        }
                        else
                        {
                            if (e.Row.RowIndex == 0 && j == 0)
                                txtTotal.Focus();

                            //txtTotal.Visible = true;
                            //dd.Visible = false;
                        }
                        if (txtTotal.Text == "NIL")// || txtTotal.Text == "0")
                            txtTotal.Text = "";
                        //following extra condition for constantids are to not disable the 0 record for special case where need to specify 8 records
                        if (txtTotal.Text == "0" && e.Row.DataItemIndex == 0 && ViewState["intC1"].ToString() != "2054" && ViewState["intC1"].ToString() != "2055" && ViewState["intC1"].ToString() != "2056" && ViewState["intC1"].ToString() != "2057" && ViewState["intC1"].ToString() != "2058" && ViewState["intC1"].ToString() != "2059" && ViewState["intC1"].ToString() != "2060")
                            txtTotal.Enabled = false;
                        //txtTotal.Attributes.Add("required", "");
                        if (Lst_T1000[j].ValidationColumns == (i).ToString())
                        {
                            //if val of validation and validation string is empty
                            if (Lst_T1000[j].Validation != "" && Lst_T1000[j].ValidationString != "")
                            {
                                txtTotal.Attributes.Add(Lst_T1000[j].Validation, Lst_T1000[j].ValidationString);
                                dd.Attributes.Add(Lst_T1000[j].Validation, Lst_T1000[j].ValidationString);
                                //txtTotal.Attributes.Add("required", "");
                                cntVal += 1;
                            }
                        }


                    }
                }
            }
            else
            {
                int cnt = 0;
                for (int i = 2; i < GridViewFlaoting.Columns.Count; i++)
                {
                    TextBox txtTotal = e.Row.Cells[i].Controls[1] as TextBox;
                    DropDownList dd = e.Row.Cells[i].Controls[3] as DropDownList;
                    if (txtTotal.Text == "NIL")
                        txtTotal.Text = "";
                    if (txtTotal.Text == "0" && e.Row.DataItemIndex == 0)
                        txtTotal.Enabled = false;
                    txtTotal.Attributes.Add("required", "");
                }
            }
            if (dsDataRules.Tables.Count > 0)
            {
                if (dsDataRules.Tables[1].Rows.Count > 0)
                {
                    DataRow[] rows = dsDataRules.Tables[1].Select("Dest_ID = " + ViewState["ConstID"].ToString() + " and HeaderID = " + ViewState["C16"].ToString());
                    if (rows.Length > 0)
                    {
                        foreach (DataRow row1 in rows)
                        {
                            string txtName = "txtC" + row1["T1000_Col"].ToString().Substring(3);
                            string ddName = "ddC" + row1["T1000_Col"].ToString().Substring(3);
                            TextBox txtCol = new TextBox();
                            DropDownList ddCol = new DropDownList();
                            txtCol = (TextBox)e.Row.FindControl(txtName);
                            ddCol = (DropDownList)e.Row.FindControl(ddName);
                            txtCol.Enabled = false;
                            ddCol.Enabled = false;
                            //if (row1["Actions"].ToString() == "D")
                            //    txtAmt2.Enabled = false;
                        }
                    }
                }
            }
        }
    }

    protected void GridViewFlaoting_DataBound(object sender, EventArgs e)
    {
        if (ViewState["C16"].ToString() != "0")
        {
            List<denFloating> genFloating = new List<denFloating>();
            bllFloating objbllFloating = new bllFloating();
            bllSalary objbllSalary = new bllSalary();
            //if (genFloating[e.Row.RowIndex].DropdownQry != "0")
            //Lst_T1000 = objbllSalary.Select(Convert.ToInt32(ViewState["C16"]), ViewState["vtype"].ToString(), Session["ITR"].ToString(), Session["AY"].ToString());

            //genFloating = objbllFloating.GetFlaotingHeaders(Convert.ToString(Session["NameID"]), Convert.ToInt16(ViewState["C16"]), Convert.ToInt16(ViewState["intC1"]), 0);
            genFloating = objbllFloating.GetFlaotingHeaders(Convert.ToString(Session["NameID"]), Convert.ToInt16(ViewState["C16"]), Convert.ToInt32(ViewState["intC1"]), 0, ViewState["MainID"].ToString());
            if (genFloating.Count > 0)
            {
                GridViewFlaoting.HeaderRow.Cells[0].Text = genFloating[0].C1.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[1].Text = genFloating[0].C2.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[2].Text = genFloating[0].C3.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[3].Text = genFloating[0].C4.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[4].Text = genFloating[0].C5.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[5].Text = genFloating[0].C6.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[6].Text = genFloating[0].C7.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[7].Text = genFloating[0].C8.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[8].Text = genFloating[0].C9.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[9].Text = genFloating[0].C10.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[10].Text = genFloating[0].C11.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[11].Text = genFloating[0].C12.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[12].Text = genFloating[0].C13.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[13].Text = genFloating[0].C14.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[14].Text = genFloating[0].C15.Replace("*", "<span style='color:Red;'>*</span>");


                GridViewFlaoting.HeaderRow.Cells[15].Text = genFloating[0].C16.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[16].Text = genFloating[0].C17.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[17].Text = genFloating[0].C18.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[18].Text = genFloating[0].C19.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[19].Text = genFloating[0].C20.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[20].Text = genFloating[0].C21.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[21].Text = genFloating[0].C22.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[22].Text = genFloating[0].C23.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[23].Text = genFloating[0].C24.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[24].Text = genFloating[0].C25.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[25].Text = genFloating[0].C26.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[26].Text = genFloating[0].C27.Replace("*", "<span style='color:Red;'>*</span>");
                GridViewFlaoting.HeaderRow.Cells[27].Text = genFloating[0].C28.Replace("*", "<span style='color:Red;'>*</span>");
            }
            int cnt_FloatingCols = 0;
            int v_number = Convert.ToInt32(ViewState["Number"]);

            for (int x = 0; x <= 27; x++)
            {
                if (GridViewFlaoting.HeaderRow.Cells[x].Text == "NIL")
                    GridViewFlaoting.Columns[x].Visible = false;
                else
                {
                    GridViewFlaoting.Columns[x].Visible = true;
                    if (x >= v_number)
                    {
                        cnt_FloatingCols = x;
                        v_number = 100;
                    }
                    cnt_FloatingCols_Global = x;
                }
                //if (genFloating[0].Col2 == "0" || genFloating[0].Col3 == "0" || genFloating[0].Col4 == "0" || genFloating[0].Col5 == "0" || genFloating[0].Col6 == "0" || genFloating[0].Col7 == "0" || genFloating[0].Col8 == "0" || genFloating[0].Col4 == "9" || genFloating[0].Col4 == "10")
                //{

                //}
                //else
                //{
                //    if (Session["Project"].ToString() == "stax")
                //    {
                //        //btnInsertFloatGrid.Visible = false;
                //        //btnDels.Visible = false;
                //    }
                //}

                foreach (GridViewRow row1 in GridViewFlaoting.Rows)
                {
                    DropDownList dd = new DropDownList();
                    dd = (DropDownList)row1.FindControl("ddC6");
                    //if (GridViewFlaoting.Rows.Count > x)
                    //{
                    if (dd.Visible)
                        dd.SelectedValue = genFloating[row1.RowIndex].Col6;
                    //}
                    if (x > 0)
                    {
                        if (ViewState["Gorder"] != null && ViewState["Number"] != null)
                        {
                            TextBox txtTotal = row1.Cells[x].Controls[1] as TextBox;
                            if (row1.RowIndex == (Convert.ToInt32(ViewState["Gorder"]) - 1) && x == cnt_FloatingCols)// txtTotal.TabIndex.ToString())
                            {
                                //txtTotal.Focus();
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Cursor_FloatGrid('" + hdnfloat.Value + "','GridViewFlaoting');", true);
                                cnt_FloatingCols = 100;
                            }
                        }
                    }
                }
            }
            if (FloatRowCnt != 0)
            {
                if (GridViewFlaoting.Rows.Count >= FloatRowCnt)
                {
                    btnInsertFloatGrid.Visible = false;
                }
                else
                    btnInsertFloatGrid.Visible = true;
            }
        }
    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        ViewState["vtype"] = "";
        hdnVType.Value = ViewState["vtype"].ToString();
        ddlSelect.DataSourceID = "";
        ddlSelect.DataBind();

        ddlSelect.DataSourceID = "ObjectDataSource3";
        ddlSelect.DataBind();

        grdState.DataSourceID = "";
        grdState.DataBind();

        grdState.DataSourceID = "ObjectDataSource1";
        grdState.DataBind();
    }

    protected void ObjectDataSource3_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        Int32 type = 0;
        DataTable dt = new DataTable();
        System.Collections.ArrayList arrInfo = new System.Collections.ArrayList();
        arrInfo.Add(Convert.ToString(Session["NameID"]));
        if (!IsPostBack)
        {
            ViewState["vtype"] = Session["IncomeTax_VType"].ToString();// Request.QueryString["vtype"].ToString();
            Session["VType"] = ViewState["vtype"].ToString();
            hdnVType.Value = ViewState["vtype"].ToString();
            bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            if (ViewState["vtype"].ToString() == "15052")
                objbllStoreTrans.setLosses(1200000, -250000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Session["NameID"].ToString(), Session["AY"].ToString(), Session["ITR"].ToString());
            //if (Request.QueryString["vtype"].ToString() == "49")
            if (ViewState["vtype"].ToString() == "49")
            {
                setEligibleDeductions();
                calcTax();

                DataTable dtFormula = new DataTable();
                denStoreTrans objdenStoreTrans2 = new denStoreTrans();
                dtFormula = objbllStoreTrans.getFormulaT00(Convert.ToInt32(ViewState["vtype"].ToString()), Session["AY"].ToString());
                if (dtFormula.Rows.Count > 0)
                {
                    objdenStoreTrans2.NameID = Convert.ToString(Session["NameID"]);
                    //objdenStoreTrans2.Vtype = (ViewState["vtype"].ToString() != "105") ? Convert.ToInt32(ViewState["vtype"]) : 49;        previous condition but not used any long as 105 vtype was no where in the database
                    objdenStoreTrans2.Vtype = Convert.ToInt32(ViewState["vtype"]);
                    objdenStoreTrans2.MainID = Convert.ToInt32(ViewState["MainID"]);
                    objdenStoreTrans2.ConstID = Convert.ToInt32(dtFormula.Rows[0]["c1"]); //917;// Convert.ToInt32(ViewState["intC1"]);
                    objdenStoreTrans2.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
                    objdenStoreTrans2.Col3 = "0";//Convert.ToString(txtbox.Text);
                    objdenStoreTrans2.AY = Convert.ToString(Session["AY"]);
                    objdenStoreTrans2.GRowNo = Convert.ToInt32(ViewState["GRowNo"]);
                    objdenStoreTrans2.AssesseeType = Convert.ToInt32(Session["Status"]);
                    objdenStoreTrans2.ComboItemNo = ddlSelect.SelectedIndex;
                    objdenStoreTrans2.IsEnterFDet = 0;

                    //objbllStoreTrans.UpdateMainGridBalanceSheet(objdenStoreTrans2);
                    //grdState.DataSourceID = "";
                    //grdState.DataSourceID = "ObjectDataSource1";
                }
                hdnTaxStatus.Value = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "33");
            }
        }
        else
        {
            if (ViewState["vtype"].ToString() == "49" || ViewState["vtype"].ToString() == "104")
            {
                setEligibleDeductions();
                calcTax();
            }
            if (ViewState["vtype"].ToString() == "49")
            {
                //calcTax();
                btnContinue.Visible = false;
                //btnBack.Visible = true;
                bllStoreTrans objbllStoreTrans = new bllStoreTrans();
                DataTable dtFormula = new DataTable();
                denStoreTrans objdenStoreTrans2 = new denStoreTrans();
                dtFormula = objbllStoreTrans.getFormulaT00(Convert.ToInt32(ViewState["vtype"].ToString()), Session["AY"].ToString());
                if (dtFormula.Rows.Count > 0)
                {
                    objdenStoreTrans2.NameID = Convert.ToString(Session["NameID"]);
                    //objdenStoreTrans2.Vtype = (ViewState["vtype"].ToString() != "105") ? Convert.ToInt32(ViewState["vtype"]) : 49;        previous condition but not used any long as 105 vtype was no where in the database
                    objdenStoreTrans2.Vtype = Convert.ToInt32(ViewState["vtype"]);
                    objdenStoreTrans2.MainID = Convert.ToInt32(ViewState["MainID"]);
                    objdenStoreTrans2.ConstID = Convert.ToInt32(dtFormula.Rows[0]["c1"]); //917;// Convert.ToInt32(ViewState["intC1"]);
                    objdenStoreTrans2.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
                    objdenStoreTrans2.Col3 = "0";//Convert.ToString(txtbox.Text);
                    objdenStoreTrans2.AY = Convert.ToString(Session["AY"]);
                    objdenStoreTrans2.GRowNo = Convert.ToInt32(ViewState["GRowNo"]);
                    objdenStoreTrans2.AssesseeType = Convert.ToInt32(Session["Status"]);
                    objdenStoreTrans2.ComboItemNo = ddlSelect.SelectedIndex;
                    objdenStoreTrans2.IsEnterFDet = 0;
                    objdenStoreTrans2.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
                    objbllStoreTrans.UpdateMainGridBalanceSheet(objdenStoreTrans2, out msg_IIF);
                    grdState.DataSourceID = "";
                    grdState.DataSourceID = "ObjectDataSource1";
                }
                btnPDF.Visible = true;
                hdnTaxStatus.Value = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "33");
            } //btnSubmit22.ServerClick += new EventHandler(btnSubmit22_ServerClick);
        }
        //following code is for the grid based formulas and works directly through DB Table formulas:


        //if (objDenScreen.IsMaster != "1")
        //{
        //    //dtFormula = objbllStoreTrans.getFormulaT00(Convert.ToInt32(ViewState["vtype"].ToString()), Session["AY"].ToString());
        //    //for (int i = 0; i < dtFormula.Rows.Count; i++)
        //    //{
        //        denStoreTrans objdenStoreTrans2 = new denStoreTrans();
        //        objdenStoreTrans2.NameID = Convert.ToString(Session["NameID"]);
        //        //objdenStoreTrans2.Vtype = (ViewState["vtype"].ToString() != "105") ? Convert.ToInt32(ViewState["vtype"]) : 49;        previous condition but not used any long as 105 vtype was no where in the database
        //        objdenStoreTrans2.Vtype = Convert.ToInt32(ViewState["vtype"]);
        //        objdenStoreTrans2.MainID = Convert.ToInt32(ViewState["MainID"]);
        //        objdenStoreTrans2.ConstID = Convert.ToInt32(dtFormula.Rows[i]["c1"]); //917;// Convert.ToInt32(ViewState["intC1"]);
        //        objdenStoreTrans2.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
        //        objdenStoreTrans2.Col3 = "0";//Convert.ToString(txtbox.Text);
        //        objdenStoreTrans2.AY = Convert.ToString(Session["AY"]);
        //        objdenStoreTrans2.GRowNo = Convert.ToInt32(ViewState["GRowNo"]);
        //        objdenStoreTrans2.AssesseeType = Convert.ToInt32(Session["Status"]);
        //        objdenStoreTrans2.ComboItemNo = ddlSelect.SelectedIndex;
        //        objdenStoreTrans2.IsEnterFDet = 0;
        //        objbllStoreTrans.UpdateMainGridBalanceSheet(objdenStoreTrans2);
        //        grdState.DataSourceID = "";
        //        grdState.DataSourceID = "ObjectDataSource1";
        //    //}
        //}
        dalEmployerMaster objdalEmployerMaster = new dalEmployerMaster();
        denEmployerMaster objdenEmployerMaster = new denEmployerMaster();

        dtMain.Rows.Clear();
        dtMain.Clear();
        popup objpopup = new popup();

        //dtMain = objpopup.Select(Request.QueryString["vtype"].ToString(), arrInfo);

        if (Session["restore"] != null && false)
        {
            Session["E_Name"] = Session["NameID"];
            ViewState["MainID"] = Session["NameID"].ToString();
        }
        else
        {
            if (dtMain.Rows.Count > 0)
            {
                if (Session["E_NameID"] == null && Session["E_Name"] == null || Request.UrlReferrer == null && ViewState["vtype"].ToString() != "13011" && ViewState["vtype"].ToString() != "13012" && ViewState["vtype"].ToString() != "5001")
                {
                    Session["E_NameID"] = dtMain.Rows[0]["id"].ToString();
                    Session["E_Name"] = dtMain.Rows[0]["title"].ToString();
                }
                else if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                {
                    Session["E_NameID"] = dtMain.Rows[0]["id"].ToString();
                    Session["E_Name"] = dtMain.Rows[0]["title"].ToString();
                }

                //gvEmp.DataSource = dtMain;
                //gvEmp.DataBind();
                //if (Request.QueryString["vtype"].ToString() == "41")
                //{
                //    gvEmp.Columns[2].Visible = false;
                //    gvEmp.Columns[1].HeaderText = "Business";
                //}
                //else
                //{
                //    gvEmp.Columns[2].Visible = true;
                //    gvEmp.Columns[1].HeaderText = "Employer";
                //    gvEmp.ShowHeader = true;
                //}
                //ltTitle.Text = dtMain.Rows[0]["screenTitle"].ToString();
                //aLnk.Visible = Convert.ToBoolean(dtMain.Rows[0]["IsAddButton"]);
                //aLnk.PostBackUrl = dtMain.Rows[0]["AddBtnURL"].ToString();
                //aLnkUpdate.Visible = Convert.ToBoolean(dtMain.Rows[0]["IsManageButton"]);
                //aLnkUpdate.PostBackUrl = dtMain.Rows[0]["AddBtnURL"].ToString() + "?id=" + Session["E_NameID"].ToString();

                if ((Session["ITR"].ToString() != "1" && Session["ITR"].ToString() != "8") || Session["project"].ToString() == "stax" && Session["IsMaster"].ToString() != "1" && Session["IsMaster"].ToString() != "2")
                    lbtnChange.Visible = true;

                lblHeading_Title.Text = Session["E_Name"].ToString();
            }
            else
            {
                //if (Request.QueryString["vtype"].ToString() == "40" || Request.QueryString["vtype"].ToString() == "41" || Request.QueryString["vtype"].ToString() == "42" || Request.QueryString["vtype"].ToString() == "5001")
                if (objDenScreen.popupID > 0)
                {
                    if (Session["E_Name"] != null && false)
                    {
                        lblHeading_Title.Text = Session["E_Name"].ToString();// "Default";    // hiding it for Default when No Name but Default was set as Name
                        lbtnChange.Text = "(Change)";
                    }
                    else
                    {
                        lblHeading_Title.Text = "";
                        lbtnChange.Text = "(Add)";
                        if (ViewState["vtype"] != null)
                        {
                            if (ViewState["vtype"].ToString() == "40")
                            {
                                lbtnChange.PostBackUrl = "lstGrids.aspx?VType=13011";
                                lbtnChange.Text = "Select Employer";
                                if (Session["E_Name"] != null)
                                    lbtnChange.Text = Session["E_Name"].ToString() + " (Change Employer)";
                            }
                            if (ViewState["vtype"].ToString() == "42")
                            {
                                lbtnChange.PostBackUrl = "lstGrids.aspx?VType=13012";
                                lbtnChange.Text = "Select Property";
                            }
                        }
                        //else if (Request.QueryString["VType"] != null)
                        else if (Session["IncomeTax_VType"] != null)
                        {
                            if (Session["IncomeTax_VType"].ToString() == "40")
                            {
                                lbtnChange.PostBackUrl = "lstGrids.aspx?VType=13011";
                                lbtnChange.Text = "Select Employer";
                                if (Session["E_Name"] != null)
                                    lbtnChange.Text = Session["E_Name"].ToString() + " (Change Employer)";
                            }
                            if (Session["IncomeTax_VType"].ToString() == "42")
                            {
                                lbtnChange.PostBackUrl = "lstGrids.aspx?VType=13012";
                                lbtnChange.Text = "Select Property";
                                if (Session["E_Name"] != null)
                                    lbtnChange.Text = Session["E_Name"].ToString() + " (Change Property)";
                            }
                        }
                    }
                    if ((Session["ITR"].ToString() != "1" && Session["ITR"].ToString() != "8") || Session["project"].ToString() == "stax" && Session["IsMaster"].ToString() != "1" && Session["IsMaster"].ToString() != "2")
                        lbtnChange.Visible = true;

                }
                else
                {
                    lbtnChange.Visible = false;
                }
                if (Session["IsMaster"] != null)
                {
                    if (Session["IsMaster"].ToString() == "1" || Session["IsMaster"].ToString() == "2")
                        lbtnChange.Visible = false;
                }
            }
            string sss = ViewState["vtype"].ToString();

            //if ((ViewState["vtype"].ToString() == "40" || ViewState["vtype"].ToString() == "41" || ViewState["vtype"].ToString() == "42" || ViewState["vtype"].ToString() == "5001" || Request.QueryString["vtype"].ToString() == "13011" || Request.QueryString["vtype"].ToString() == "13012") && Session["E_NameID"] != null)
            if (objDenScreen.popupID > 0 && Session["E_NameID"] != null)
            {
                sss = Session["E_NameID"].ToString();
                if (Session["MainID"] == null)
                    ViewState["MainID"] = Session["E_NameID"].ToString();   //Session["NameID"].ToString(); //1234567890;
                else
                    ViewState["MainID"] = Session["MainId"].ToString();//Tihs is for the Editing of records from Main Listings (from lstGrids)
            }
            //else if ((Request.QueryString["vtype"].ToString() == "42" || Request.QueryString["vtype"].ToString() == "43") && Session["AssetID"] != null)
            //{
            //    ViewState["MainID"] = Session["AssetID"].ToString();
            //}
            else
                ViewState["MainID"] = Session["NameID"].ToString();// "100";
        }

        e.InputParameters["intVtype"] = Convert.ToInt16(ViewState["vtype"]);
        e.InputParameters["ITR"] = Session["ITR"].ToString();
        if (Session["AY"] != null)
            e.InputParameters["AY"] = Session["AY"].ToString();
        else
            e.InputParameters["AY"] = "2014-2015";


        //Managing Screen Navigation:

        int IsFirstLast = objBllScreen.getFirstLast(ViewState["vtype"].ToString(), Session["AY"].ToString(), Session["ITR"].ToString());

        //if (hdnVType.Value == "48")
        if (IsFirstLast == 2)
            btnCont_Inp.Visible = false;
        else
            btnCont_Inp.Visible = true;


        //if (hdnVType.Value == "40")// || btnBack_Inp.Value == "")
        if (IsFirstLast == 3)
            btnBack_Inp.Visible = false;
        else
            btnBack_Inp.Visible = true;
    }

    public void setEligibleDeductions()
    {
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        objbllStoreTrans.setEligibleDeductions(Session["NameID"].ToString(), Session["AY"].ToString(), Session["NameID"].ToString(), Session["ITR"].ToString());
    }

    protected void btnSubmit22_ServerClick(object sender, EventArgs e)
    {

    }

    public void calcTax()
    {
        denDocTrans objdenDocTrans = new denDocTrans();
        bllDocTrans objDocTransBLL = new bllDocTrans();
        objdenDocTrans = objDocTransBLL.GetBankDetails(Convert.ToString(Session["PAN"]));


        decimal gIFS, gIFHP, gIFBUS, gIFSTCG, gIFLTCG, gIFOS, gDED, gDED1, gICE, gAI, gTDS, gTCS, gSelfAss, gATP, gCasuInc, gCLUB, gRelief, gTI, gGIT, gNIT, gSum_234, gSur, gEduCess, gRebate87A;
        gIFS = 0; gIFHP = 0; gIFBUS = 0; gIFSTCG = 0; gIFLTCG = 0; gIFOS = 0; gDED = 0; gDED1 = 0; gICE = 0; gAI = 0; gTDS = 0; gTCS = 0; gSelfAss = 0; gATP = 0; gCasuInc = 0; gCLUB = 0; gRelief = 0; gTI = 0; gGIT = 0; gNIT = 0; gSum_234 = 0;
        gSur = 0; gRebate87A = 0;
        gEduCess = 0;
        bllSalary objbllSalary = new bllSalary();
        objbllSalary.SetAllZero(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        //objbllSalary.calcSal("0", Session["NameID"].ToString(), Session["ay"].ToString(), (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString()), out gIFS, out  gIFHP, out  gIFBUS, out  gIFSTCG, out  gIFLTCG, out  gIFOS, out  gDED, out  gDED1, out  gICE, out  gAI, out  gTDS, out  gTCS, out  gSelfAss, out  gATP, out  gCasuInc, out  gCLUB, out  gRelief, out gTI, out gGIT, out gNIT, out gSum_234, out gEduCess, out gSur, out gRebate87A);
        //objbllSalary.calTaxNew(Session["NameID"].ToString(), Session["ay"].ToString(), 49, (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString()), Convert.ToInt32(((Session["Project"].ToString() != "vtax") ? 0 : 1)));
        objbllSalary.calTaxNew(Session["NameID"].ToString(), Session["ay"].ToString(), 49, (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString()), 0);

        //objbllSalary.calTaxNew(Session["NameID"].ToString(), Session["ay"].ToString(), 49, "31/07/2014", 0, Convert.ToInt32(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0));
        //Response.Write("gIFS = " + gIFS + ", gIFHP = " + gIFHP + " , gIFBUS = " + gIFBUS + ", gIFSTCG= " + gIFSTCG + " , gIFLTCG =" + gIFLTCG + " , gIFOS = " + gIFOS + " , gDED= " + gDED + " , gDED1= " + gDED1 + " , gICE= " + gICE + ", gAI = " + gAI + " , gTDS = " + gTDS + " , gTCS = " + gTCS + " , gSelfAss = " + gSelfAss + " , gATP = " + gATP + ", gCasuInc = " + gCasuInc + " , gCLUB = " + gCLUB + ", gRelief = " + gRelief + ", gTI = " + gTI + ", gGIT = " + gGIT + ", gNIT = " + gNIT + ", gSum_234 = " + gSum_234 + ", gEduCess = " + gEduCess + ", gSur = " + gSur);

        Label lblNetTaxPayable = new Label();
        lblNetTaxPayable.Text = gNIT.ToString(); //(gNIT + gSum_234).ToString();

        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gIFS.ToString(), Convert.ToDecimal(9001), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "L", Convert.ToDecimal(9002), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);   //for constantid=582 else s
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gIFHP.ToString(), Convert.ToDecimal(9003), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gIFOS.ToString(), Convert.ToDecimal(9004), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), (gIFBUS + gIFHP + gIFS + gIFOS + gIFLTCG + gIFSTCG).ToString(), Convert.ToDecimal(9005), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), (gIFBUS + gIFHP + gIFS + gIFOS + gIFLTCG + gIFSTCG - gDED - gDED1).ToString(), Convert.ToDecimal(9006), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);

        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), lblNetTaxPayable.Text, Convert.ToDecimal(9011), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9012), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);   // Rebate 87A
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9013), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);   //Tax Payable on Rebate

        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gSur.ToString(), Convert.ToDecimal(917), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 3, Convert.ToDecimal(0), 0);   //Surcharge
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gEduCess.ToString(), Convert.ToDecimal(1015), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 4, Convert.ToDecimal(0), 0);   //EducationCess

        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gRelief.ToString(), Convert.ToDecimal(881), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 6, Convert.ToDecimal(0), 0);   //Section89 - gRelief
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gSum_234.ToString(), Convert.ToDecimal(9019), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        //if (!lblNetTaxPayable.Text.Contains("-"))
        //{
        //    objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), lblNetTaxPayable.Text, Convert.ToDecimal(9025), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Balance Tax Payable
        //    objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9034), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Refund Due
        //}
        //else
        //{
        //    objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9025), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Balance Tax Payable
        //    objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), lblNetTaxPayable.Text, Convert.ToDecimal(9034), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Refund Due
        //}

        //double tot_tax_paid = Convert.ToDouble(gATP + gTDS + gSelfAss);
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), tot_tax_paid.ToString(), Convert.ToDecimal(9030), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Tot Tax Paid

        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), objdenDocTrans.AccountNumber, Convert.ToDecimal(9035), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Assessee Account Number

        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), lblNetTaxPayable.Text, Convert.ToDecimal(9065), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //IncChrgSal
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gTDS.ToString(), Convert.ToDecimal(9066), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Total TDS Sal


        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9016), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Gross Tax Liability   - no values known for now?
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9018), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Net Tax Liability   - no values known for now?

        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gGIT.ToString(), Convert.ToDecimal(1117), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 1, Convert.ToDecimal(0), 0);    //Income Tax
        //gRebate87A = gGIT - gRebate87A;
        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), (gRebate87A).ToString(), Convert.ToDecimal(918), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 5, Convert.ToDecimal(0), 0);    //Total Tax
        ////objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gGIT.ToString(), Convert.ToDecimal(1118), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 10, Convert.ToDecimal(0), 0);    //Total Tax Due

        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(1119), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 11, Convert.ToDecimal(0), 0);    //Tax Paid
        ////objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(1120), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 12, Convert.ToDecimal(0), 0);    //Tax Payable/Refund

        //objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), (gDED + gDED1).ToString(), Convert.ToDecimal(9077), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 12, Convert.ToDecimal(0), 0);    //Total Deductions
        ////objbllSalary.AddLeftOvers(Session["NameID"].ToString(), Session["ay"].ToString());

    }

    protected void gvAsset_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Text = "Asset Master:" + strTitle;
        }
        else if (e.Row.RowIndex != -1)
        {
            Label lblSNO = new Label();
            Label lblAssetID = new Label();

            lblSNO = (Label)e.Row.FindControl("lblSNO");
            lblSNO.Text = (e.Row.RowIndex + 1).ToString();
            lblAssetID = (Label)e.Row.FindControl("lblAssetID");
            if (Session["AssetID"] != null)
            {
                if (lblAssetID.Text == Session["AssetID"].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }
    }

    protected void gvAsset_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Session["AssetID"] = e.CommandArgument.ToString();
        LinkButton ltbn = new LinkButton();
        ltbn = (LinkButton)e.CommandSource;
        Session["Asset"] = ltbn.Text;
        Response.Redirect(Request.Url.ToString());
    }

    void SelectDataIndividual(string PAN)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objdalEmployerMaster.Select(Convert.ToInt64(Session["E_NameID"]));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void TextBox_Change(object sender, EventArgs e)
    {
        if (ViewState["vtype"].ToString() == "40" && Session["E_NameID"] == null)
        {
            ViewState["MainID"] = Session["NameID"];
            //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('Please Select an Employer First!!'); </script>");
        }
        //else
        //{
        denStoreTrans objdenStoreTrans1 = new denStoreTrans();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();


        TextBox txtbox = (TextBox)sender;
        GridViewRow row = (GridViewRow)txtbox.NamingContainer;

        //int i;
        if (ViewState["intC1"].ToString() == "808" || ViewState["intC1"].ToString() == "844" || ViewState["intC1"].ToString() == "9808" || ViewState["intC1"].ToString() == "152217" || ViewState["intC1"].ToString() == "152222" || ViewState["intC1"].ToString() == "152227")
        {
            ViewState["SubConstID"] = Convert.ToInt32(row.Cells[13].Text);
        }
        else
        {
            ViewState["SubConstID"] = Convert.ToInt32(row.Cells[5].Text);
        }
        //objdenStoreTrans.EntryID = 99999;
        //following 2 lines are for Serial (GRowNo as per T00 - C7 value)
        Label lblSerial = new Label();
        lblSerial = (Label)row.FindControl("lblSerial");

        objdenStoreTrans1.NameID = Convert.ToString(Session["NameID"]);
        objdenStoreTrans1.Vtype = Convert.ToInt32(ViewState["vtype"]);
        objdenStoreTrans1.MainID = Convert.ToInt32(ViewState["MainID"]);
        objdenStoreTrans1.ConstID = Convert.ToInt32(ViewState["intC1"]);
        objdenStoreTrans1.SubConstID = Convert.ToInt32(ViewState["SubConstID"]);
        objdenStoreTrans1.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
        objdenStoreTrans1.Col3 = Convert.ToString(txtbox.Text);
        objdenStoreTrans1.AY = Convert.ToString(Session["AY"]);
        objdenStoreTrans1.GRowNo = row.RowIndex;  //previous GRowNo Technique
        //objdenStoreTrans1.GRowNo = Convert.ToInt32(lblSerial.Text);

        int i = objbllStoreTrans.CheckDetailGrid(objdenStoreTrans1);
        if (i <= 0)
            objbllStoreTrans.InsertDataDetailsGrid(objdenStoreTrans1);

        objbllStoreTrans.UpdateDetailsGrid(objdenStoreTrans1);

        //objbllStoreTrans.InsertCustomerDetails(objdenStoreTrans);
        if (GridViewDetails.Rows[GridViewDetails.Rows.Count - 1].RowIndex != row.RowIndex)
        {
            TextBox txt = (TextBox)GridViewDetails.Rows[row.RowIndex + 1].Cells[3].FindControl("txtAmount");
            ScriptManager1.SetFocus(txt);
        }
        else
        {
            ScriptManager1.SetFocus(btnOK);
        }
        //}
        GridViewDetails.DataSourceID = "";
        GridViewDetails.DataSourceID = "ObjectDataSource2";
        DropDownList dd1 = new DropDownList();
    }

    protected void dd1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ViewState["vtype"].ToString() == "40" && Session["E_NameID"] == null)
        {
            ViewState["MainID"] = Session["NameID"];
            //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('Please Select an Employer First!!'); </script>");
        }
        //else
        //{
        denStoreTrans objdenStoreTrans1 = new denStoreTrans();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();


        //TextBox txtbox = (TextBox)sender;
        DropDownList dropdown = (DropDownList)sender;
        GridViewRow row = (GridViewRow)dropdown.NamingContainer;

        //int i;
        if (ViewState["intC1"].ToString() == "808" || ViewState["intC1"].ToString() == "844" || ViewState["intC1"].ToString() == "9808" || ViewState["intC1"].ToString() == "152217" || ViewState["intC1"].ToString() == "152222" || ViewState["intC1"].ToString() == "152227")
        {
            ViewState["SubConstID"] = Convert.ToInt32(row.Cells[13].Text);
        }
        else
        {
            ViewState["SubConstID"] = Convert.ToInt32(row.Cells[5].Text);
        }
        //objdenStoreTrans.EntryID = 99999;
        //following 2 lines are for Serial (GRowNo as per T00 - C7 value)
        Label lblSerial = new Label();
        lblSerial = (Label)row.FindControl("lblSerial");

        objdenStoreTrans1.NameID = Convert.ToString(Session["NameID"]);
        objdenStoreTrans1.Vtype = Convert.ToInt32(ViewState["vtype"]);
        objdenStoreTrans1.MainID = Convert.ToInt32(ViewState["MainID"]);
        objdenStoreTrans1.ConstID = Convert.ToInt32(ViewState["intC1"]);
        objdenStoreTrans1.SubConstID = Convert.ToInt32(ViewState["SubConstID"]);
        objdenStoreTrans1.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
        objdenStoreTrans1.Col3 = Convert.ToString(dropdown.SelectedValue);
        objdenStoreTrans1.AY = Convert.ToString(Session["AY"]);
        objdenStoreTrans1.GRowNo = row.RowIndex;  //previous GRowNo Technique
        //objdenStoreTrans1.GRowNo = Convert.ToInt32(lblSerial.Text);

        int i = objbllStoreTrans.CheckDetailGrid(objdenStoreTrans1);
        if (i <= 0)
            objbllStoreTrans.InsertDataDetailsGrid(objdenStoreTrans1);

        objbllStoreTrans.UpdateDetailsGrid(objdenStoreTrans1);

        //objbllStoreTrans.InsertCustomerDetails(objdenStoreTrans);
        if (GridViewDetails.Rows[GridViewDetails.Rows.Count - 1].RowIndex != row.RowIndex)
        {
            TextBox txt = (TextBox)GridViewDetails.Rows[row.RowIndex + 1].Cells[3].FindControl("txtAmount");
            ScriptManager1.SetFocus(txt);
        }
        else
        {
            ScriptManager1.SetFocus(btnOK);
        }
        //}
        GridViewDetails.DataSourceID = "";
        GridViewDetails.DataSourceID = "ObjectDataSource2";
    }



    protected void InsertDataDetailsGrid(int ConstID)
    {
        try
        {
            denStoreTrans objStoreTransDEN = new denStoreTrans();
            bllStoreTrans objStoreTransBLL = new bllStoreTrans();
            int i;
            //objdenStoreTrans.EntryID = 99999;
            objStoreTransDEN.NameID = Session["NameID"].ToString();// Convert.ToString(Session["NameID"]);
            objStoreTransDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
            objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
            objStoreTransDEN.ConstID = ConstID;//Convert.ToInt32(ViewState["intC1"]);

            objStoreTransDEN.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
            objStoreTransDEN.SubConstID = 1;                // line added by ankush - > for taking care of detail records
            objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
            i = objStoreTransBLL.CheckDetailGrid(objStoreTransDEN);
            if (i <= 0)
            {
                objStoreTransBLL.InsertDataDetailsGrid(objStoreTransDEN);
                objStoreTransDEN.Col3 = (ViewState["main_Price"] != null) ? ViewState["main_Price"].ToString() : "0";
                objStoreTransDEN.GRowNo = 1;
                objStoreTransBLL.UpdateDetailsGridByMain(objStoreTransDEN);
            }
            else
            {
                objStoreTransDEN.Col3 = (ViewState["main_Price"] != null) ? ViewState["main_Price"].ToString() : "0";
                objStoreTransDEN.GRowNo = 1;
                objStoreTransBLL.UpdateDetailsGridByMain(objStoreTransDEN);
                objStoreTransBLL.UpdateDetailsGrid(objStoreTransDEN);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void TextBox_Change_MainGrid(object sender, EventArgs e)
    {
        if (Session["IsMasterPage"] != null)
        {
            //if (Session["IsMasterPage"].ToString() == "2")
            if (IsPopup)
            {
                string str = ViewState["MainID"].ToString();
            }
        }
        //Session["IsMasterPage"].ToString() == "1"
        //ViewState["MainID"]
        denStoreTrans objdenStoreTrans2 = new denStoreTrans();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();

        TextBox txtbox = (TextBox)sender;
        ViewState["main_Price"] = txtbox.Text;
        GridViewRow row = (GridViewRow)txtbox.NamingContainer;
        Label lblParticulars = new Label();
        lblParticulars = (Label)row.FindControl("lblParticulars");
        int indx = Convert.ToInt32(txtbox.TabIndex);


        int i;
        string ss = row.Cells[9].Text;
        // ViewState["SubConstID"] = Convert.ToInt32(row.Cells[5].Text);
        ViewState["intC1"] = Convert.ToInt32(row.Cells[5].Text);
        Label lblSerial = new Label();
        lblSerial = (Label)row.FindControl("lblSerial");
        if (row.Cells[0].Text.Contains("("))
        {
            ViewState["GRowNo"] = Convert.ToInt32(row.Cells[0].Text.Remove(row.Cells[0].Text.Length - 3));
        }
        else
        {
            ViewState["GRowNo"] = Convert.ToInt32(row.Cells[0].Text);
        }
        ViewState["GRowNo"] = Convert.ToInt32(lblSerial.Text);

        imgSpinner = new Image();
        imgSpinner = (Image)row.FindControl("imgSpinner");
        imgSpinner.Visible = true;
        hdnSpinner.Value = imgSpinner.ClientID;

        objdenStoreTrans2.NameID = Convert.ToString(Session["NameID"]);
        //objdenStoreTrans2.Vtype = (ViewState["vtype"].ToString() != "105") ? Convert.ToInt32(ViewState["vtype"]) : 49;        previous condition but not used any long as 105 vtype was no where in the database
        objdenStoreTrans2.Vtype = Convert.ToInt32(ViewState["vtype"]);
        objdenStoreTrans2.MainID = Convert.ToInt32(ViewState["MainID"]);
        objdenStoreTrans2.ConstID = Convert.ToInt32(ViewState["intC1"]);
        //objdenStoreTrans.SubConstID = Convert.ToInt32(ViewState["SubConstID"]);
        objdenStoreTrans2.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
        objdenStoreTrans2.Col3 = Convert.ToString(txtbox.Text);
        objdenStoreTrans2.AY = Convert.ToString(Session["AY"]);
        objdenStoreTrans2.GRowNo = Convert.ToInt32(ViewState["GRowNo"]);
        if (Session["Status"] != null)
            objdenStoreTrans2.AssesseeType = (Session["Status"].ToString() != "") ? Convert.ToInt32(Session["Status"]) : 0;
        objdenStoreTrans2.ComboItemNo = ddlSelect.SelectedIndex;
        objdenStoreTrans2.IsEnterFDet = 0;

        // To set RecdAmount
        common objCommon = new common();
        // this function is to get the RecdAmount value for the current ConstantID that will be further used during calculations
        objdenStoreTrans2.RecdAmount = objCommon.getRecdAmount(ViewState["vtype"].ToString(), (ddlSelect.SelectedItem != null) ? ddlSelect.SelectedItem.Text : "", indx, ViewState["GRowNo"].ToString(), ViewState["intC1"].ToString());

        objdenStoreTrans2.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
        i = objbllStoreTrans.CheckMainGrid(objdenStoreTrans2);
        if (i <= 0)
        {
            objbllStoreTrans.InsertDataMainGrid(objdenStoreTrans2, out msg_IIF);
            //if (Session["IsMasterPage"].ToString() != "1")
            //{
            grdState.DataSourceID = "";
            grdState.DataSourceID = "ObjectDataSource1";
            //}
            //if (objdenStoreTrans2.ConstID == 1)           // by Ankush on 28-10-2014 to resove the issue that comes during calculation of income that causes double income as one from main and rest from sub-entries somehow
            //    InsertDataDetailsGrid(1);
        }
        else if (Convert.ToInt32(ViewState["vtype"]) != 62 && Convert.ToInt32(ViewState["vtype"]) != 49 && Convert.ToInt32(ViewState["vtype"]) != 3003 && Convert.ToInt32(ViewState["vtype"]) != 3002)
        {
            objbllStoreTrans.UpdateMainGrid(objdenStoreTrans2, out msg_IIF);
            if (objdenStoreTrans2.ConstID == 1)
                InsertDataDetailsGrid(1);

            //if (Session["IsMasterPage"].ToString() != "1")
            //{
            grdState.DataSourceID = "";
            grdState.DataSourceID = "ObjectDataSource1";
            //}
        }
        else if (Convert.ToInt32(ViewState["vtype"]) == 62 || Convert.ToInt32(ViewState["vtype"]) == 49 || Convert.ToInt32(ViewState["vtype"]) == 3003 || Convert.ToInt32(ViewState["vtype"]) == 3002)//105)
        {
            objbllStoreTrans.UpdateMainGridBalanceSheet(objdenStoreTrans2, out msg_IIF);

            grdState.DataSourceID = "";
            grdState.DataSourceID = "ObjectDataSource1";
        }
        //if (grdState.Rows[grdState.Rows.Count - 1].RowIndex != row.RowIndex)
        //{
        grdState_RowIndx = row.RowIndex + 1;
        IsTextChanged = true;
        //TextBox txt = (TextBox)grdState.Rows[row.RowIndex + 1].Cells[3].FindControl("txtAmount");
        //txt.Focus();
        //ScriptManager1.SetFocus(txt);
        //}

        //System.Threading.Thread.Sleep(5000);
        IsTextChanged = true;

        if (msg_IIF != "")
            hdnMsg.Value = msg_IIF;
    }

    protected void btnInsertFloatGrid_Click(object sender, EventArgs e)
    {
        //if (GridViewFlaoting.Rows.Count < FloatRowCnt)
        addRow_Float();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "setCursorFloatgrd();", true);
        //if (GridViewFlaoting.Rows.Count >= FloatRowCnt)
        //    btnInsertFloatGrid.Visible = false;
    }

    private void addRow_Float()
    {
        objFloatingDEO.NameID = Convert.ToString(Session["NameID"]);
        objFloatingDEO.HeaderID = Convert.ToString(ViewState["C16"]);
        objFloatingDEO.Vtype = Convert.ToString(ViewState["vtype"]);
        objFloatingDEO.ConstID = Convert.ToString(ViewState["intC1"]);
        objFloatingDEO.Gorder = Convert.ToString(ViewState["Gorder"]);
        objFloatingDEO.Number = Convert.ToInt32(ViewState["Number"]);
        objFloatingDEO.AY = Session["AY"].ToString();
        objFloatingDEO.Col9 = "";
        objFloatingDEO.MainId = (ViewState["MainID"] != null) ? ViewState["MainID"].ToString() : "0";

        objFloatingDEO.Col1 = "";
        objFloatingDEO.Col2 = "";
        objFloatingDEO.Col3 = "";
        objFloatingDEO.Col4 = "";
        objFloatingDEO.Col5 = "";
        objFloatingDEO.Col6 = "";
        objFloatingDEO.Col7 = "";
        objFloatingDEO.Col8 = "";
        objFloatingDEO.Col9 = "";
        objFloatingDEO.Col10 = "";
        objFloatingDEO.Col11 = "";
        objFloatingDEO.Col12 = "";
        objFloatingDEO.Col13 = "";
        objFloatingDEO.Col14 = "";
        objFloatingDEO.Col15 = "";
        objFloatingDEO.Col16 = "";
        objFloatingDEO.Col17 = "";
        objFloatingDEO.Col18 = "";
        objFloatingDEO.Col19 = "";

        bllFloating objFloatingBLO = new bllFloating();
        objFloatingBLO.InsertFloatGridData(objFloatingDEO);
        GridViewFlaoting.DataSourceID = "";
        GridViewFlaoting.DataSourceID = "ObjectDataSource4";
        Session["Common"] = null;

        // to delete code sample:
        if (Session["Project"].ToString() == "stax")
        {
            //btnInsertFloatGrid.Visible = false;
            //btnDels.Visible = false;
        }
    }

    protected void btnDels_Click(object sender, EventArgs e)
    {
        TextBox tt = new TextBox();
        DataControlRowState rr = GridViewFlaoting.Rows[0].RowState;

        //btnDels.Text = GridViewFlaoting.SelectedRow.RowIndex.ToString();
        //if (hdnGRowSel.Value != "")
        //{
        Int32 indx = Convert.ToInt32(hdnGRowSel.Value) - 2;
        denFloating objFloatingDEO2 = new denFloating();
        objFloatingDEO2.NameID = Convert.ToString(Session["NameID"]);
        objFloatingDEO2.HeaderID = Convert.ToString(ViewState["C16"]);
        objFloatingDEO2.Vtype = Convert.ToString(ViewState["vtype"]);
        objFloatingDEO2.ConstID = Convert.ToString(ViewState["intC1"]);
        objFloatingDEO2.Gorder = Convert.ToString(ViewState["Gorder"]);
        objFloatingDEO2.Number = Convert.ToInt32(ViewState["Number"]);
        objFloatingDEO2.Gorder = GridViewFlaoting.Rows[indx].Cells[0].Text;// (indx + 1).ToString();

        bllFloating objFloatingBLO = new bllFloating();
        objFloatingBLO.Delete(objFloatingDEO2);

        //objFloatingBLO.InsertOrUpdate(objFloatingDEO);
        GridViewFlaoting.DataSourceID = "";
        GridViewFlaoting.DataSourceID = "ObjectDataSource4";
        Session["Common"] = null;

        //if (GridViewFlaoting.Rows.Count < FloatRowCnt)
        //    btnInsertFloatGrid.Visible = true;
        //}
    }

    protected void GridViewFlaoting_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewFlaoting.SelectedRow;
        string ss = row.RowIndex.ToString();
    }
    //This function is to insert/update in the floating grid columns (textboxes)
    protected void InsertOrUpdate(denFloating objFloatingDEO)
    {
        objFloatingDEO.NameID = Convert.ToString(Session["NameID"]);
        objFloatingDEO.HeaderID = Convert.ToString(ViewState["C16"]);
        objFloatingDEO.Vtype = Convert.ToString(ViewState["vtype"]);
        objFloatingDEO.ConstID = Convert.ToString(ViewState["intC1"]);
        objFloatingDEO.Gorder = Convert.ToString(ViewState["Gorder"]);
        objFloatingDEO.Number = Convert.ToInt32(ViewState["Number"]);
        objFloatingDEO.AY = Convert.ToString(Session["AY"]);
        objFloatingDEO.MainId = (ViewState["MainID"] != null) ? ViewState["MainID"].ToString() : "0";

        bllFloating objFloatingBLO = new bllFloating();
        objFloatingBLO.InsertOrUpdate(objFloatingDEO);
        GridViewFlaoting.DataSourceID = "";
        GridViewFlaoting.DataSourceID = "ObjectDataSource4";
        Session["Common"] = null;
    }

    protected void txtc1_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col1 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
    }
    protected void ObjectDataSource4_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {

    }
    protected void txtC2_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col2 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 2;
        InsertOrUpdate(objFloatingDEO);
    }

    protected void ddC2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dd = new DropDownList();
        dd = (DropDownList)sender;

        objFloatingDEO.ColMain = dd.SelectedValue;

        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)dd.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = dd.ID.Substring(3);  //2;
        InsertOrUpdate(objFloatingDEO);
    }

    protected void txtC3_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col3 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 3;
        InsertOrUpdate(objFloatingDEO);
    }

    //main
    protected void txt_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.ColMain = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = txt.ID.Substring(4);
        InsertOrUpdate(objFloatingDEO);
    }

    protected void txtC4_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col4 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        string ss1 = txt.ID;
        ViewState["Number"] = 4;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void dd6_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dd;
        dd = (DropDownList)sender;
        objFloatingDEO.Col6 = dd.SelectedValue;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)dd.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 6;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC5_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col5 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 5;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC6_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col6 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 6;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC7_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col7 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 7;
        InsertOrUpdate(objFloatingDEO);

    }
    protected void txtC8_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col8 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 8;
        InsertOrUpdate(objFloatingDEO);
    }

    protected void txtC9_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col9 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 9;
        InsertOrUpdate(objFloatingDEO);
    }

    protected void txtC10_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col10 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 10;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC11_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col11 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 11;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC12_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col12 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 12;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC13_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col13 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 13;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC14_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col14 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 14;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC15_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col15 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 15;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC16_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col16 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 16;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC17_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col17 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 17;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC18_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col18 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 18;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC19_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col19 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 19;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC20_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col20 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 20;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC21_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col21 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 21;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC22_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col22 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 22;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC23_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col23 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 23;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC24_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col24 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 24;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC25_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col25 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 25;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC26_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col26 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 26;
        InsertOrUpdate(objFloatingDEO);
    }
    protected void txtC27_TextChanged(object sender, EventArgs e)
    {
        TextBox txt;
        txt = (TextBox)sender;
        objFloatingDEO.Col27 = txt.Text;
        Session["Common"] = objFloatingDEO;
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        ViewState["Gorder"] = Convert.ToInt32(row.Cells[0].Text);
        ViewState["Number"] = 27;
        InsertOrUpdate(objFloatingDEO);
    }

    protected void TextBox_Change_Date(object sender, EventArgs e)
    {
        denStoreTrans objdenStoreTrans2 = new denStoreTrans();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();


        TextBox txtboxDate = (TextBox)sender;
        GridViewRow row = (GridViewRow)txtboxDate.NamingContainer;

        // ViewState["SubConstID"] = Convert.ToInt32(row.Cells[5].Text);
        ViewState["intC1"] = Convert.ToInt32(row.Cells[5].Text);
        objdenStoreTrans2.NameID = Convert.ToString(Session["NameID"]);
        objdenStoreTrans2.Vtype = Convert.ToInt32(ViewState["vtype"]);
        objdenStoreTrans2.MainID = Convert.ToInt32(ViewState["MainID"]);
        objdenStoreTrans2.ConstID = Convert.ToInt32(ViewState["intC1"]);
        //objdenStoreTrans.SubConstID = Convert.ToInt32(ViewState["SubConstID"]);
        objdenStoreTrans2.GIndex = Convert.ToInt32(ViewState["GridIndex"]);
        objdenStoreTrans2.Col3 = Convert.ToString(txtboxDate.Text);
        objdenStoreTrans2.AY = Convert.ToString(Session["AY"]);
        objdenStoreTrans2.ComboItemNo = ddlSelect.SelectedIndex;
        objdenStoreTrans2.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());

        int i = objbllStoreTrans.CheckMainGrid(objdenStoreTrans2);
        if (i <= 0)
            objbllStoreTrans.InsertDataMainGrid(objdenStoreTrans2, out msg_IIF);
        else
            if (Convert.ToInt32(ViewState["vtype"]) != 3002)
            {
                objbllStoreTrans.UpdateMainGrid(objdenStoreTrans2, out msg_IIF);
            }
            else
            {
                objbllStoreTrans.UpdateMainGridBalanceSheet(objdenStoreTrans2, out msg_IIF);
                grdState.DataSourceID = "";
                grdState.DataSourceID = "ObjectDataSource1";
            }

        if (grdState.Rows[grdState.Rows.Count - 1].RowIndex != row.RowIndex)
        {
            TextBox txt = (TextBox)grdState.Rows[row.RowIndex + 1].Cells[3].FindControl("txtAmount");
            //ScriptManager1.SetFocus(txt);
        }
        grdState_RowIndx = row.RowIndex + 1;
    }

    protected void grdState_DataBound(object sender, EventArgs e)
    {
        if (detail_cnt == 0)
        {
            grdState.Columns[3].Visible = false;
            couter = -1;
        }
        else
        {
            if (couter == -1)
            {
                grd_row_cnt = 0;
                grdState.Columns[3].Visible = true;
            }
        }
        if (grdState.Rows.Count > grdState_RowIndx && IsMasterEvents == false && (hdnTabbed.Value == "" || IsTextChanged == true))
        {
            //System.Threading.Thread.Sleep(5000);
            //if (IsPostBack)
            //tabIndx_Mgmt();
        }
        else
        {
            if (Session["Project"].ToString() == "tds")
            {
                btnSaveToMydatabase1.TabIndex = latest_TabIndx;
                ddlChallan.TabIndex = Convert.ToInt16(btnSaveToMydatabase1.TabIndex + 1);
                //btnSaveToMydatabase1.Focus();
            }
            else if (IsBackCont == "")
            {
                if (!IsMasterEvents)
                {
                    btnCont_Inp.Attributes.Add("tabindex", latest_TabIndx.ToString());
                    //btnCont_Inp.Focus();
                }
                else
                {
                    btnCont_Inp.Attributes.Add("tabindex", latest_TabIndx.ToString());
                }
            }
        }
        //btnCont_Inp.Attributes.Add("tabindex", latest_TabIndx.ToString());
        btnSaveMasterData.TabIndex = latest_TabIndx;
        IsTextChanged = false;
        hdnTabbed.Value = "";
        this.MaintainScrollPositionOnPostBack = true;

        //if (grdState.Rows.Count == grdstate_row_cnt)
        //    Response.Redirect("lstGrids.aspx");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Cursor_FloatGrid('" + hdnfloat.Value + "','grdState');", true);
    }

    private void tabIndx_Mgmt()
    {
        if (grdState.Rows.Count > grdState_RowIndx && IsBackCont == "")
        {
            bool IsFocus = false;   //to manage the disabled/invisible controls
            TextBox txt = (TextBox)grdState.Rows[grdState_RowIndx].Cells[3].FindControl("txtAmount");
            bool isVisible = txt.Visible;
            if (txt.Visible)
            {
                txt.Focus();//hdnCtrlTabIndx.Value=txt.ClientID;

                IsFocus = true;
            }
            else
            {
                txt = (TextBox)grdState.Rows[grdState_RowIndx].Cells[3].FindControl("txtDate");
                txt.Focus();
                if (!txt.Visible)
                {
                    IsFocus = false;
                    DropDownList ddl = new DropDownList();
                    ddl = (DropDownList)grdState.Rows[grdState_RowIndx].Cells[3].FindControl("ddl1");
                    ddl.Focus();
                    IsFocus = true;
                    if (!ddl.Visible)
                    {
                        IsFocus = false;
                        LinkButton btnLink = new LinkButton();
                        btnLink = (LinkButton)grdState.Rows[grdState_RowIndx].Cells[3].FindControl("btnLink");
                        //IsFocus = true;
                        if (btnLink != null)
                        {
                            btnLink.Focus();
                            IsFocus = true;
                        }
                    }
                }
            }
            if (IsFocus == false)
            {
                if (grdState.Rows.Count > grdState_RowIndx)
                {
                    grdState_RowIndx += 1;
                    //tabIndx_Mgmt();
                }
            }
            btnCont_Inp.Attributes.Add("tabindex", latest_TabIndx.ToString());
        }
        IsBackCont = "";
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        //if (ddlSelect.SelectedIndex == 0)
        Session["MainID"] = ViewState["MainID"].ToString();
        Session["VType"] = ViewState["vtype"].ToString();
        Session["ComboItemNo"] = dropdown_Indx.ToString();
        //Response.Redirect("lstGrids.aspx?VType=" + Request.QueryString["VType"].ToString() + "&tabindx=" + ddlSelect.SelectedIndex.ToString());
        Response.Redirect("lstGrids.aspx?VType=" + ViewState["vtype"].ToString() + "&tabindx=" + ddlSelect.SelectedIndex.ToString());
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        denLogin objLoginDEN = new denLogin();
        bllLogin objLoginBLL = new bllLogin();

        objLoginDEN.UserName = Convert.ToString(Session["UserName"]);
        objLoginDEN.LogoutTime = DateTime.Now.ToShortTimeString();
        objLoginBLL.UpdateUserDetails(objLoginDEN);
        Response.Redirect("Login.aspx");
        Session["UserName"] = "";
    }
    protected void btnRadiodetailed_CheckedChanged(object sender, EventArgs e)
    {
        if (btnRadiodetailed.Checked == true)
        {
            mltView.ActiveViewIndex = 5;
            Label3.Text = "List of Eligible Deductions";
            btnAddAsset.Visible = false;
            // btnRdoCGains20.Checked = true;
        }
    }
    protected void ObjectDataSource5_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["NameID"] = Convert.ToString(Session["NameID"]);
        e.InputParameters["VType"] = ViewState["vtype"].ToString();
    }
    protected void btnAddAsset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetMaster.aspx");
        //Server.Transfer("AssetMaster.aspx");
    }
    protected void lnkAssetGid_Click(object sender, EventArgs e)
    {
        LinkButton lnkButton;
        lnkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lnkButton.NamingContainer;
        ViewState["SaleID"] = Convert.ToInt32(row.Cells[4].Text);
        mltView.ActiveViewIndex = 6;
        //btnRdoCGains20.Checked = true;
        if (Convert.ToInt32(ViewState["SaleID"]) == 5)
        {
            lblIncome.Visible = true;
            ddlHP.Visible = true;
            chkCompensation.Visible = false;
        }
        else
        {
            lblIncome.Visible = false;
            ddlHP.Visible = false;
            chkCompensation.Visible = false;
        }
        GridAssetType.DataSourceID = "ObjectDataSource6";
    }

    protected void ObjectDataSource6_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["SaleID"] = Convert.ToInt32(ViewState["SaleID"]);
        e.InputParameters["Gindex"] = 11;
        e.InputParameters["Ay"] = Convert.ToString(Session["AY"]);
    }

    protected void ddlHP_SelectedIndexChanged(object sender, EventArgs e)
    {
        bllSalary objSalaryBLL = new bllSalary();
        if (ddlHP.SelectedIndex == 0)
        {
            ViewState["ComboIndex"] = 0;
            chkCompensation.Visible = false;
            //objSalaryBLL.GetHousePropertyData(0, 0, 5, Convert.ToString(Session["AY"]));
            GridAssetType.DataSourceID = "ObjectDataSource7";
        }
        else if (ddlHP.SelectedIndex == 1)
        {
            ViewState["ComboIndex"] = 1;
            chkCompensation.Visible = true;
            //objSalaryBLL.GetHousePropertyData(1, 0, 5, Convert.ToString(Session["AY"]));
            GridAssetType.DataSourceID = "ObjectDataSource7";
        }
    }

    protected void chkCompensation_CheckedChanged(object sender, EventArgs e)
    {
        bllSalary objSalaryBLL = new bllSalary();
        GridAssetType.DataSourceID = "";
        if (chkCompensation.Checked == true)
        {
            ViewState["ChkBox"] = 1;
            GridAssetType.DataSourceID = "ObjectDataSource7";
            //objSalaryBLL.GetHousePropertyData(1,1,5,Convert.ToString(Session["AY"]));
        }
        else
            ViewState["ChkBox"] = 0;
        GridAssetType.DataSourceID = "ObjectDataSource7";
        //objSalaryBLL.GetHousePropertyData(1, 0, 5, Convert.ToString(Session["AY"]));
    }
    protected void ObjectDataSource7_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["ComboParameter"] = Convert.ToInt32(ViewState["ComboIndex"]);
        e.InputParameters["ChkBoxParameter"] = Convert.ToInt32(ViewState["ChkBox"]);
        e.InputParameters["SaleID"] = 5;
        e.InputParameters["AY"] = Convert.ToString(Session["AY"]);

    }
    protected void btnlnkLogout_Click(object sender, EventArgs e)
    {
        denLogin objLoginDEN = new denLogin();
        bllLogin objLoginBLL = new bllLogin();

        objLoginDEN.UserName = Convert.ToString(Session["UserName"]);
        objLoginDEN.LogoutTime = DateTime.Now.ToShortTimeString();
        objLoginBLL.UpdateUserDetails(objLoginDEN);
        Response.Redirect("Login.aspx");
        Session["UserName"] = "";
    }
    protected void btnlnkLogout2_Click(object sender, EventArgs e)
    {
        denLogin objLoginDEN = new denLogin();
        bllLogin objLoginBLL = new bllLogin();

        objLoginDEN.UserName = Convert.ToString(Session["UserName"]);
        objLoginDEN.LogoutTime = DateTime.Now.ToShortTimeString();
        objLoginBLL.UpdateUserDetails(objLoginDEN);
        Response.Redirect("Login.aspx");
        Session["UserName"] = "";
    }
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        denLogin objLoginDEN = new denLogin();
        bllLogin objLoginBLL = new bllLogin();

        objLoginDEN.UserName = Convert.ToString(Session["UserName"]);
        objLoginDEN.LogoutTime = DateTime.Now.ToShortTimeString();
        objLoginBLL.UpdateUserDetails(objLoginDEN);
        Response.Redirect("Login.aspx");
        Session["UserName"] = "";
    }

    //Added By Mudit For TDS on 16-3-15

    protected void btnSaveToMydatabase1_Click(object sender, EventArgs e)
    {
        denStoreTrans objdenStoreTrans = new denStoreTrans();
        bllStoreTrans objbllStoretrans = new bllStoreTrans();
        try
        {
            savemydatabase1();
            objbllStoretrans.deleteUser(Session["NameID"].ToString());
            //Response.Redirect(Request.Url.ToString());
            grdState.DataSourceID = "ObjectDataSource1";
            btnSaveToMydatabase1.Text = "Save And Clear";
            btnSaveToMydatabase12.Text = "Save";
        }
        catch (Exception ex)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ex + "');", true);
            //Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            string errorMsg = ex.Message.ToString();
            hdnMsg.Value = errorMsg;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + errorMsg + "');", true);
            //objbllStoretrans.deleteUser(Session["NameID"].ToString());
            //Response.Redirect(Request.Url.ToString());


            //grdState.DataSourceID = "ObjectDataSource1";
        }
    }

    protected void btnSaveToMydatabase12_Click(object sender, EventArgs e)
    {
        denStoreTrans objdenStoreTrans = new denStoreTrans();
        bllStoreTrans objbllStoretrans = new bllStoreTrans();
        try
        {
            savemydatabase1();
            //Response.Redirect(Request.Url.ToString());
            grdState.DataSourceID = "ObjectDataSource1";
            btnSaveToMydatabase1.Text = "Save And Clear";
            btnSaveToMydatabase12.Text = "Save";
        }
        catch (Exception ex)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ex + "');", true);
            //Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            string errorMsg = ex.Message.ToString();
            hdnMsg.Value = errorMsg.Substring(0, errorMsg.IndexOf("\n"));
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + errorMsg + "');", true);
            //objbllStoretrans.deleteUser(Session["NameID"].ToString());
            //Response.Redirect(Request.Url.ToString());


            //grdState.DataSourceID = "ObjectDataSource1";
        }
    }
    public void savemydatabase1()
    {
        denStoreTrans objdenStoreTrans = new denStoreTrans();
        bllStoreTrans objbllStoretrans = new bllStoreTrans();
        try
        {
            objdenStoreTrans.TAN = Session["TAN"].ToString();
            objdenStoreTrans.AY = Session["AY"].ToString();
            objdenStoreTrans.Quarter = Session["qtr"].ToString();
            objdenStoreTrans.FormNo = Session["FormType"].ToString();
            objdenStoreTrans.RegularCorrection = Session["Regular_Correction"].ToString();//"Regular";
            objdenStoreTrans.PAN = Session["PAN"].ToString();
            objdenStoreTrans.ChallanID = ddlChallan.SelectedValue;
            objdenStoreTrans.FY = Session["FY"].ToString();
            objdenStoreTrans.NameID = Session["NameID"].ToString();
            objdenStoreTrans.BookEntry = Convert.ToInt16(ddlSelect.SelectedValue);
            if (btnSaveToMydatabase1.Text == "Save And Clear" || btnSaveToMydatabase12.Text == "Save")
                objdenStoreTrans.Flag = 0;
            else
                objdenStoreTrans.Flag = 1;
            if (ViewState["vtype"].ToString() == "3001")
            {
                if (objdenStoreTrans.Flag == 1)
                {
                    objdenStoreTrans.ChallanID = Session["ChallanID"].ToString();
                }
                objdenStoreTrans.RecordNo = Convert.ToInt32(Session["TDS_JobNo"]);
                objbllStoretrans.InsertChalanDetails(objdenStoreTrans);
            }
            else if (ViewState["vtype"].ToString() == "3002")
            {
                string DeducteeID = "";
                if (objdenStoreTrans.Flag == 1)
                {
                    DeducteeID = Session["ChallanID"].ToString();
                }
                objbllStoretrans.InsertDeducteeDetails(objdenStoreTrans, DeducteeID);
            }
            else if (ViewState["vtype"].ToString() == "3003")
            {
                objdenStoreTrans.SalaryID = (Session["SalaryID"] != null) ? Convert.ToInt32(Session["SalaryID"]) : 0;
                objbllStoretrans.InsertSalaryDetails(objdenStoreTrans);
            }
            //else if (ViewState["vtype"].ToString() == "2001")
            //{
            //    objbllStoretrans.InsertTransData(objdenStoreTrans);
            //}
            if (objdenStoreTrans.Flag == 0)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Record Saved....!');", true);
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Record Updated....!');", true);
                Session["ddlChallanID"] = null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btngetTDS_Click(object sender, EventArgs e)
    {
        fetchTDSData();
    }

    //following code is for TDS based services to fill Tax Paid related data:

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
            // obj_ClientInfoType.assessmentYear = "2014-15";// Session["ay"].ToString();


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
            // //lblMsg.Visible = true;
            // //lblMessage.Text = ex.Message;
            // throw ex;
        // }
    }
    //Added By Mudit For Generic Procedures on 16/06/2015
    protected void btnCreateFile_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReceiptNo.aspx");
    }
    protected void btnSaveMasterData_Click(object sender, EventArgs e)
    {

        try
        {
            bllSalary objbllSalary = new bllSalary();
            bllStoreTrans objbllStoretrans = new bllStoreTrans();
            //string Vtype = 106
            //if (Session["Vtype"].ToString() == null || Session["Vtype"].ToString() == "")
            //    Session["Vtype"] = Session["NameID"].ToString();
            int falg = 0;
            if (Session["Mode"] == "Edit")
            {
                falg = 1;
                //btnSaveMasterData.Text = "Update";
            }
            int IsSuccess = 0;
            if (Session["IsMasterPage"].ToString() == "1")
            {
                IsSuccess = objbllSalary.SendTransData(ViewState["vtype"].ToString(), Session["NameID"].ToString(), Session["AY"].ToString(), Session["username"].ToString(), falg);
                if (Session["Project"].ToString() == "vt")
                {
                    balXML objbalXML = new balXML();
                    objbalXML.Update_JobID_ByNameID(IsSuccess.ToString());
                    if (falg == 0)  //Adding Assessee as User only during first Time (i.e. when come on Profile Page to create the Assessee first time and not while updation)
                    {
                        common objcommon = new common();
                        objcommon.AddUser(IsSuccess.ToString());

                        if (Session["UserRole"] != null)
                        {
                            if (Session["UserRole"].ToString() == "Reception")
                            {
                                objcommon.SaveJob(IsSuccess.ToString(), Session["username"].ToString(), objbalXML.getXML_Last_ID(IsSuccess.ToString()));
                            }
                        }
                        //objcommon.SaveJob(IsSuccess.ToString(),Session["username"].ToString(),
                    }
                }
                //if (IsSuccess == 0)
                //{
                //common objcommon = new common();
                //objcommon.SaveAccount(IsSuccess.ToString(), Session["UserName"].ToString());

                //}
            }
            //Response.Redirect("Main.aspx");
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + "Information Added/Updated Successfully" + "');", true);
            hdnIsSave.Value = "DataSaved";
            //Session["Mode"] = "New";
            redirectPolicy();
        }
        catch (Exception ex)
        {
            // throw ex;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ex + "');", true);
        }
        if (Session["IsMasterPage"].ToString() == "2")
        {
            bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            //string MainID = objbllStoreTrans.getMainID(Session["NameId"].ToString(), Request.QueryString["VType"].ToString());
            string MainID = objbllStoreTrans.getMainID(Session["NameId"].ToString(), ViewState["vtype"].ToString());

            Session["MainID"] = MainID.ToString();// (Convert.ToInt32(ViewState["MainID"]) + 1).ToString();
            ViewState["MainID"] = MainID.ToString();// (Convert.ToInt32(ViewState["MainID"]) + 1).ToString();
            string ss = ViewState["MainID"].ToString();
            //Response.Redirect(Request.Url.ToString());
            grdState.DataSourceID = "";
            grdState.DataBind();

            grdState.DataSourceID = "ObjectDataSource1";
            grdState.DataBind();
        }
    }

    private void redirectPolicy()
    {
        if (Session["Account_Type"] != null)
        {
            if (Session["Account_Type"].ToString() == "E")
            {
                Response.Redirect("ECA_Details.aspx");
            }
        }
        if (Session["UserRole"] != null)
        {
            if (Session["UserRole"].ToString() == "Reception")
                Response.Redirect("Reception/Default.aspx");
        }
        if (Session["IsMasterPage"].ToString() == "1")
        {
            if (Session["InternalSal"] != null)
            {
                Session["InternalSal"] = null;
                //Response.Redirect("Salary.aspx?VType=40");
                if (Session["IncomeTax_VType"].ToString() == "106")
                    Session["IncomeTax_VType"] = "40";
                else if (Session["IncomeTax_VType"].ToString() == "15077")
                    Session["IncomeTax_VType"] = "15078";

                Response.Redirect("IncomeTax");
            }
            else
            {
                if (Session["IncomeTax_VType"].ToString() == "15073")
                {
                    bllStoreTrans objbllStoreTrans = new bllStoreTrans();
                    objbllStoreTrans.deleteUser_VType(Session["NameID"].ToString(), Session["IncomeTax_VType"].ToString());
                    string strDirPath = Server.MapPath("~/UserDocs/") + Session["User_ID"].ToString();
                    if (!Directory.Exists(strDirPath))
                        Directory.CreateDirectory(strDirPath);

                    string[] arrDir = Directory.GetDirectories(strDirPath);
                    Directory.CreateDirectory(strDirPath + "/" + (arrDir.Length + 1).ToString());
                    Session["Dir_Path"] = strDirPath + "/" + (arrDir.Length + 1).ToString();
                    AddPath();

                    Response.Redirect("TDSClient.aspx");
                }
                else
                    Response.Redirect("Main.aspx");
            }
        }
        else if (Session["IsMasterPage"].ToString() == "2")
        {
            //ViewState["Main"] = (Convert.ToInt32(ViewState["Main"]) + 1).ToString();
            //Response.Redirect(Request.Url.ToString());
            if (Session["IncomeTax_VType"].ToString() == "15073")
            {
                if (ViewState["Button_Status"].ToString() == "AMR")
                {
                    bllStoreTrans objbllStoreTrans = new bllStoreTrans();
                    objbllStoreTrans.deleteUser_VType(Session["NameID"].ToString(), Session["IncomeTax_VType"].ToString());
                    string strDirPath = Server.MapPath("~/UserDocs/") + Session["User_ID"].ToString();
                    string[] arrDir = Directory.GetDirectories(strDirPath);
                    Directory.CreateDirectory(strDirPath + "/" + (arrDir.Length + 1).ToString());
                    Session["Dir_Path"] = strDirPath + "/" + (arrDir.Length + 1).ToString();
                    AddPath();

                    Response.Redirect(Request.RawUrl);
                }
                else
                    Response.Redirect("TDSClient.aspx");
            }
            else
            {
                //grdState.DataSourceID = "";
                //grdState.DataBind();

                //grdState.DataSourceID = "ObjectDataSource1";
                //grdState.DataBind();
                //Response.Redirect(Request.RawUrl);
            }
        }
        else
        {
            if (Session["IncomeTax_VType"].ToString() == "15077")
                Session["IncomeTax_VType"] = "15078";
            else
                Session["IncomeTax_VType"] = "40";
            Response.Redirect("IncomeTax");
        }
    }

    //To Add path in StoreTrans for TDS2
    public void AddPath()
    {
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        denStoreTrans objdenStoreTrans2 = new denStoreTrans();
        objdenStoreTrans2.NameID = Convert.ToString(Session["NameID"]);
        objdenStoreTrans2.Vtype = 15074;
        objdenStoreTrans2.MainID = Convert.ToInt32(Session["NameID"]);
        objdenStoreTrans2.ConstID = 1523995;
        //objdenStoreTrans.SubConstID = Convert.ToInt32(ViewState["SubConstID"]);
        objdenStoreTrans2.GIndex = 14073;
        objdenStoreTrans2.Col3 = Session["Dir_Path"].ToString();
        objdenStoreTrans2.AY = Convert.ToString(Session["AY"]);
        objdenStoreTrans2.GRowNo = 8;
        if (Session["Status"] != null)
            objdenStoreTrans2.AssesseeType = (Session["Status"].ToString() != "") ? Convert.ToInt32(Session["Status"]) : 0;
        objdenStoreTrans2.ComboItemNo = 0;
        objdenStoreTrans2.IsEnterFDet = 0;
        objdenStoreTrans2.RecdAmount = 0;
        objdenStoreTrans2.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
        string msg_IIF = "";
        objbllStoreTrans.InsertDataMainGrid(objdenStoreTrans2, out msg_IIF);
    }

    //following three events/functions are for window close management:
    //protected void Page_Unload(object sender, EventArgs e)
    //{
    //    Session["Def"] = "set";
    //}

    [WebMethod]
    public static void AbandonSession()
    {
        _Default objDef = new _Default();
        string ss = HttpContext.Current.Request.UrlReferrer.ToString();
        if (HttpContext.Current.Session["Def"] == null)
        {
            //HttpContext.Current.Response.Redirect("Logout.aspx");
            //HttpContext.Current.Session.Abandon();
            //Presentation_DisplayForm objPresentation_DisplayForm = new Presentation_DisplayForm();
            bllAssessee objbllAssessee = new bllAssessee();
            if (HttpContext.Current.Session["NameID"] != null && HttpContext.Current.Session["AY"] != null)
                objbllAssessee.DeleteFromStoreTrans(HttpContext.Current.Session["NameID"].ToString(), HttpContext.Current.Session["AY"].ToString());
            objDef.Logout();
        }
        else
            HttpContext.Current.Session["Def"] = null;
    }

    public void DeleteAssesseeData()
    {
        bllAssessee objbllAssessee = new bllAssessee();
        objbllAssessee.DeleteFromStoreTrans(Session["NameID"].ToString(), Session["AY"].ToString());
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
            Response.Redirect("Login.aspx");
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
        string strRedirect = "Login.aspx";
        if (reason_logout != "")
        {
            Session["reason_logout"] = reason_logout.ToString();
            strRedirect = "Login.aspx?reason_logout=sa";

        }
        //Response.Redirect("login.aspx");
        //Response.Redirect("../Default.aspx");
        //Response.Redirect(strRedirect);
    }

    //Function that will be called for 80G Calculations on specific conditions/events:

    public void calc80G()
    {
        denStoreTrans objStoreTransDEN;
        bllStoreTrans objStoreTransBLL;

        objStoreTransDEN = new denStoreTrans();
        objStoreTransBLL = new bllStoreTrans();



        bool Is_1003 = false;
        if (ViewState["intC1"] != null)
        {
            if (ViewState["intC1"].ToString() != "1003")
                Is_1003 = true;
        }

        //if (Is_1003)
        //{
        objStoreTransDEN.ConstID = 1001;
        objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
        objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
        objStoreTransDEN.Vtype = 46;
        objStoreTransDEN.GIndex = 4;
        objStoreTransDEN.ComboItemNo = 1;
        objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
        objStoreTransDEN.GRowNo = -1;
        objStoreTransDEN.IsEnterFDet = 1;
        objStoreTransDEN.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
        objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "46", 107);

        objStoreTransDEN.ConstID = 1002;
        objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
        objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
        objStoreTransDEN.Vtype = 46;
        objStoreTransDEN.GIndex = 4;
        objStoreTransDEN.ComboItemNo = 1;
        objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
        objStoreTransDEN.GRowNo = -1;
        objStoreTransDEN.IsEnterFDet = 1;
        objStoreTransDEN.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
        objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "46", 107);

        //objStoreTransDEN.ConstID = 1003;
        //objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
        //objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
        //objStoreTransDEN.Vtype = 46;
        //objStoreTransDEN.GIndex = 4;
        //objStoreTransDEN.ComboItemNo = 1;
        //objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
        //objStoreTransDEN.GRowNo = -1;
        //objStoreTransDEN.IsEnterFDet = 1;
        //objStoreTransDEN.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
        //objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "46", 108);
        bllSalary objbllSalary = new bllSalary();
        double amt = objbllSalary.getFloatDataForConstID("1003", Session["NameID"].ToString());
        if (amt > 0)
        {
            objStoreTransDEN.ConstID = 1031;
            objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
            objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
            objStoreTransDEN.Vtype = 46;
            objStoreTransDEN.GIndex = 4;
            objStoreTransDEN.ComboItemNo = 1;
            objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
            objStoreTransDEN.GRowNo = -1;
            objStoreTransDEN.IsEnterFDet = 1;
            objStoreTransDEN.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
            objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "46", 108);

            objStoreTransDEN.ConstID = 1003;
            objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
            objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
            objStoreTransDEN.Vtype = 46;
            objStoreTransDEN.GIndex = 4;
            objStoreTransDEN.ComboItemNo = 1;
            objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
            objStoreTransDEN.GRowNo = -1;
            objStoreTransDEN.IsEnterFDet = 1;
            objStoreTransDEN.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
            objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "46", 108);
        }
        else
        {
            objStoreTransDEN.ConstID = 1003;
            objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
            objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
            objStoreTransDEN.Vtype = 46;
            objStoreTransDEN.GIndex = 4;
            objStoreTransDEN.ComboItemNo = 1;
            objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
            objStoreTransDEN.GRowNo = -1;
            objStoreTransDEN.IsEnterFDet = 1;
            objStoreTransDEN.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
            objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "46", 108);
            objStoreTransDEN.ConstID = 1031;
            objStoreTransDEN.AY = Convert.ToString(Session["AY"]);
            objStoreTransDEN.NameID = Convert.ToString(Session["NameID"]);
            objStoreTransDEN.Vtype = 46;
            objStoreTransDEN.GIndex = 4;
            objStoreTransDEN.ComboItemNo = 1;
            objStoreTransDEN.MainID = Convert.ToInt32(ViewState["MainID"]);
            objStoreTransDEN.GRowNo = -1;
            objStoreTransDEN.IsEnterFDet = 1;
            objStoreTransDEN.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
            objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "46", 108);
        }
    }
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChallanPDF.aspx");
    }
    //Added By Mudit on 24/08/2015 for TDS To display Challan Details on the textBoxes
    protected void ddlChallan_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SelChal"] = ddlChallan.SelectedValue;
        GetChallanDetails();

    }
    //Function Added By Mudit on 24/08/2015 for TDS To display Challan Details on the textBoxes
    public void GetChallanDetails()
    {

        if (Session["SelChal"] != null)
        {
            ddlChallan.SelectedValue = Session["SelChal"].ToString();// Session["ddlChallanID"].ToString();
        }
        denStoreTrans objdenStoreTrans = new denStoreTrans();
        bllStoreTrans objbllStoreTtrans = new bllStoreTrans();
        int MasterID = 0;
        objdenStoreTrans.TAN = Session["TAN"].ToString();
        objdenStoreTrans.FY = Session["FY"].ToString();
        objdenStoreTrans.Quarter = Session["qtr"].ToString();
        objdenStoreTrans.FormNo = Session["FormType"].ToString();
        objdenStoreTrans.RegularCorrection = Session["Regular_Correction"].ToString();//"Regular";

        int ChallanID = Convert.ToInt32(ddlChallan.SelectedValue);
        MasterID = objbllStoreTtrans.GetIDFromMaster(objdenStoreTrans);
        //MasterID = Convert.ToInt32(Session["Job_ID"]);
        DataTable dtChallanDetails = new DataTable();
        dtChallanDetails = objbllStoreTtrans.GetTDSChallanDetails(MasterID, ChallanID, objdenStoreTrans);
        if (dtChallanDetails.Rows.Count > 0)
        {
            txtBSRCode.Text = dtChallanDetails.Rows[0][0].ToString();
            if (dtChallanDetails.Rows[0][1].ToString() == "")
                txtChequeNo.Text = "No Records";
            else
                txtChequeNo.Text = dtChallanDetails.Rows[0][1].ToString();
            txtChallanAmt.Text = dtChallanDetails.Rows[0][2].ToString();
            txtConsumedAmt.Text = dtChallanDetails.Rows[0][3].ToString();
        }
        Session["ImportChallanID"] = ddlChallan.SelectedValue;  //For Mudit on 09-12-15 for TDS
    }

    protected void btn_Imp_Click(object sender, EventArgs e)
    {
        Response.Redirect("ImportFromExcel.aspx");
    }

    //Function Added By Mudit On 18/12/2015 for TDS specific rules like insert dropdown value on page load
    public void InsertTDSSpecificRules()
    {
        int Vtype = Convert.ToInt32(ViewState["vtype"]);
        string AY = Session["AY"].ToString();
        string NameID = Session["NameID"].ToString();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        objbllStoreTrans.InsertTDSSpecificRules(Vtype, AY, NameID);
    }
    public void DataRules()
    {

        bllDataRules objbllDataRules = new bllDataRules();
        denDataRules objdenDataRules = new denDataRules();
        objdenDataRules.Vtype = Convert.ToInt32(ViewState["vtype"].ToString());
        objdenDataRules.NameID = Session["NameID"].ToString();
        objdenDataRules.AY = Session["AY"].ToString();

        dsDataRules = objbllDataRules.SelectRules(objdenDataRules, Session["ITR"].ToString());
    }
    protected void lbtnEditProf_Click(object sender, EventArgs e)
    {
        if (Session["Project"].ToString() == "vt")
        {
            Session["Master_VType"] = "true";
            Session["Mode"] = "Edit";
            Session["InternalSal"] = "true";
            Session["Listing_Page"] = "true";
            Session["IncomeTax_VType"] = "106";
            Response.Redirect("Profile");
        }
        else if (Session["Project"].ToString() == "tds")
        {
            Response.Redirect("TanMaster.aspx");
        }
        //Response.Redirect("Salary.aspx?vtype=106");

    }

    void db1_btn_buttonClick(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.Text == "Add More Returns")
        {
            db1.Client_NoAction = "N";
            db1.parameters = ViewState["vtype"].ToString() + "~" + Session["NameID"].ToString() + "~" + Session["AY"].ToString() + "~" + Session["username"].ToString() + "~" + ((Session["Mode"] == "Edit") ? 1 : 0) + "~" + Session["ITR"].ToString() + "~0";
            ViewState["Button_Status"] = "AMR";
            //bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            //objbllStoreTrans.deleteUser_VType(Session["NameID"].ToString(), Session["IncomeTax_VType"].ToString());
            //Response.Redirect(Request.RawUrl);
        }
        else if (btn.Text == "View")
        {
            ViewState["Button_Status"] = "";
            Response.Redirect((objDenScreen.ScreenListing != "") ? objDenScreen.ScreenListing : "lstGrids.aspx?vtype=" + Session["IncomeTax_VType"].ToString());
        }
        else
        {
            ViewState["Button_Status"] = "Save";
            db1.Client_NoAction = "N";
            Session["VType"] = ViewState["vtype"].ToString();
            ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<Script type='text/javascript'>alert('Testing only'); </script>");
            //db1.parameters = ViewState["vtype"].ToString() + "~" + Session["NameID"].ToString() + "~" + Session["AY"].ToString() + "~" + Session["username"].ToString() + "~" + ((Session["Mode"] == "Edit") ? 1 : 0) + "~" + Session["ITR"].ToString() + "~0~" + ((Session["Job_ID"] != null) ? Session["Job_ID"].ToString() : "0");
        }
        //System.Threading.Thread.Sleep(10000);
        //Response.Redirect("Main.aspx");
    }

    protected void DownloadFile()
    {
        //var  filePath = Request.Form["__EVENTARGUMENT"];
        string filePath = Session["filepath"].ToString();
        Session["filepath"] = null;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
        //ExprotFileList();
    }


}