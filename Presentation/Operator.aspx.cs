using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Taxation.BusinessLogic;
using Taxation.DataEntity;

public partial class Presentation_Operator : System.Web.UI.Page
{
    static string ITRXML_ID = "";
    static int StateID = 26;
    string Org = "5";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["act"] != null && Session["OperatorAct"] == null)
        {
            if (Request.QueryString["act"].ToString() == "1")
            {
                if (Session["ITR"].ToString() == "1" || Session["ITR"].ToString() == "8")
                {
                    bllStoreTrans objbllStoreTrans = new bllStoreTrans();
                    bllSalary objbllSalary = new bllSalary();
                    string strXMLData = "";
                    string strXMLData_Extra = "";
                    string FilePath = "";
                    objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, Session["ITR"].ToString(), Session["duedate"].ToString(), "", "", out strXMLData, out strXMLData_Extra);
                    objbllSalary.SaveAssessee(2, Session["NameID"].ToString(), Session["AY"].ToString(), strXMLData, Session["ITR"].ToString(), strXMLData_Extra);
                }

                common objcommon = new common();
                if (Session["Operator_JobID"] != null && Session["user_ID"] != null)
                    objcommon.updateProcessStatus(Convert.ToInt64(Session["Operator_JobID"]), Convert.ToInt64(Session["user_ID"]));
            }
            Session["OperatorAct"] = "Acted";
        }
        if (Session["NameID"] != null && Session["AY"] != null)
        {
            bllAssessee objbllAssessee = new bllAssessee();
            objbllAssessee.DeleteFromStoreTrans(Session["NameID"].ToString(), Session["AY"].ToString());
        }
        balAdmin objbalAdmin = new balAdmin();
        tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
        objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(Session["user_ID"]));
        Org = objtbl_UserRegistration.OrganizationName;
        BindNewGrid();
    }
    public void BindNewGrid()
    {

        if (Session["Project"].ToString()=="vt")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grdAssesseeFirm_Operator";
            VGrid1.Parameters = Org + "," + Session["user_ID"].ToString();
            VGrid1.DataBind();
            VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
            VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        }
        else if (Session["Project"].ToString() == "tds")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grdDeducteeFirm_Operator";
            VGrid1.Parameters = Org + "," + Session["user_ID"].ToString();
            VGrid1.DataBind();
            VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
            VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        }
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.SelectedRow;
        if (Session["Project"].ToString() == "vt")
            exec_ITR(dtGrid);
        else if (Session["Project"].ToString() == "tds")
            exec_TDS(dtGrid);


        //setDataTransfer();
    }    
    private void exec_ITR(DataTable dtGrid)
    {
        ITRXML_ID = dtGrid.Rows[0][0].ToString();
        Session["UpdateXML"] = "sel";
        Session["ITR"] = dtGrid.Rows[0][2].ToString();
        Session["ay"] = dtGrid.Rows[0][9].ToString();
        Session["AY"] = dtGrid.Rows[0][9].ToString();
        Session["PAN"] = dtGrid.Rows[0][3].ToString();
        Session["ReturnType"] = dtGrid.Rows[0][8].ToString();
        Session["NameID"] = dtGrid.Rows[0][3].ToString();
        Session["ITRXML_ID"] = ITRXML_ID.ToString();
        Session["Operator_JobID"] = dtGrid.Rows[0][1].ToString();
        Session["AssesseeType"] = "0";

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
        Session["OperatorAct"] = null;
        Response.Redirect("Main.aspx?ut=o");
    }

    public void exec_TDS(DataTable dtGrid)
    {
        string detail = dtGrid.Rows[0][2].ToString();
        string Project = dtGrid.Rows[0][0].ToString() + "-" + Session["Project"].ToString().ToUpper();
        bllITR objbllITR = new bllITR();
        Session["ITR"] = objbllITR.getReturnType(detail, Project); // dtGrid.Rows[0][2].ToString();
        string[] arrAY = System.Text.RegularExpressions.Regex.Split(dtGrid.Rows[0][9].ToString(), "-");
        string strAY = ((Convert.ToInt32(arrAY[0]) + 1).ToString() + "-" + (Convert.ToInt32(arrAY[1]) + 1).ToString());
        Session["ay"] = ((Convert.ToInt32(arrAY[0]) + 1).ToString() + "-" + (Convert.ToInt32(arrAY[1]) + 1).ToString());
        Session["AY"] = Session["ay"].ToString();
        Session["Operator_JobID"] = dtGrid.Rows[0][1].ToString();
        Session["FormType"] = dtGrid.Rows[0][2].ToString();
        Session["FY"] = dtGrid.Rows[0][9].ToString();
        Session["qtr"] = dtGrid.Rows[0][0].ToString();
        Session["OC"] = dtGrid.Rows[0][8].ToString();
        Session["TAN"] = dtGrid.Rows[0][7].ToString();
        Session["PAN"] = dtGrid.Rows[0][7].ToString();
        Session["Name"] = dtGrid.Rows[0][6].ToString();
        Session["NameID"] = dtGrid.Rows[0][3].ToString();
        string Type = "";
        if (Session["Regular_Correction"] != null)
            Type = Session["Regular_Correction"].ToString();
        Session["OperatorAct"] = null;
        bllMain objbllMain = new bllMain();
        objbllMain.TDSMasterDetails(Session["TAN"].ToString(), Session["FY"].ToString(), "Regular", Session["qtr"].ToString(), Session["FormType"].ToString(), Session["AY"].ToString());
        Session["AssesseeType"] = "999999"; //Default Assessee Type for TDS as there is no Assessee Type in TDS
        //Response.Redirect("DisplayForm.aspx");
        Session["IncomeTax_VType"] = "3001";
        Response.Redirect("IncomeTax");
    }

    public void restoreXML(string strXML, Int64 ID)
    {
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        string ITR = "";
        string PAN = "";
        string ss = Session["AY"].ToString();
        ss = Session["NameID"].ToString();
        ss = Session["ITR"].ToString();

        if (Session["ITR"].ToString() == "8")
            ITR = "4s";
        else
            ITR = Session["ITR"].ToString();

        objbllStoreTrans.resXMLInv(Session["NameID"].ToString(), Session["AY"].ToString(), out PAN, Convert.ToInt32(Session["ITR"]));
        bllAssessee objbllAssessee = new bllAssessee();
        denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
        Session["restore"] = "true";
        Session["PAN"] = PAN;
        denMain objMainDEN = new denMain();
        bllMain objMainBLL = new bllMain();
        objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), 0, 0, StateID);
        string[] arrDate = System.Text.RegularExpressions.Regex.Split(objMainDEN.DueDate, "/");
        DateTime dtime = new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]));
    }

    private void setDataTransfer()
    {
        //setEditMode();
        try
        {
            string strDueDate = "";
            if (Session["ay"].ToString() == "2014-2015")
                Session["duedate"] = "31/07/2014";
            else if (Session["ay"].ToString() == "2015-2016")
                Session["duedate"] = "31/08/2015";
            else if (Session["ay"].ToString() == "2016-2017")
                Session["duedate"] = "31/07/2016";

            

            bllITR objbllITR = new bllITR();
            denITR objdenITR = new denITR();
            int if_Exists = 0;  // objbllITR.getITRData_Main(Convert.ToInt64(Session["NameID"]), Session["AY"].ToString());    //to check if the assessee data exists in the storetrans_main
                       
                objdenITR = objbllITR.getITRData(Convert.ToInt64(Session["NameID"]), Session["AY"].ToString(), Session["ITR"].ToString());
                if (objdenITR.NameID != 0 && objdenITR.ITRType != "")
                {
                    if (Session["AY"] != null)
                    {
                        restoreXML(objdenITR.XML_Data, objdenITR.ID);
                    }
                }
                //updateMiscInfo(objDocTransDEN);                      

            bllAssessee objbllAssessee = new bllAssessee();
            objbllAssessee.Add_AssesseeITR();   //To add Assessee Return Details
            //objbllAssessee.addEmployerCategory(Convert.ToString(Session["NameID"]), ddEmployer.SelectedIndex);

            //Added by Mudit ON 01/09/2015 for Inserting Main Page Data in StoreTrans

            //objbllMain.SetMainPageData(Session["NameID"].ToString(), Session["AY"].ToString(), Session["NameID"].ToString(), ddEmployer.SelectedValue, "", ddlWhichSection.SelectedValue, ddCivilCode.SelectedValue, txtPAN.Text, ddlReturnType.SelectedValue, txtRecieptNo.Text, txtDateofReturn.Text, txtDateofReturn.Text, txtRecieptNo.Text, txtNotice.Text, txtDON.Text, txtTRP_PIN.Text, txtTRPName.Text, txtTRPPaid.Text);
            //txtDateofReturn.Text = "";
            Session["FormType"] = "";
            Session["FY"] = "";
        }
        catch (Exception ex)
        {
            //throw ex;            
        }

        //Adding tbl_ITRXML if not already exists
        balXML objbalXML = new balXML();
        Int64 xmlID = objbalXML.AddXMLData(Session["NameID"].ToString(), Session["ITR"].ToString(), Session["AY"].ToString(), Session["ReturnType"].ToString());
        if (xmlID > 0)
            ITRXML_ID = Convert.ToString(xmlID);

        if (ITRXML_ID != "0")
        {
            Session["ITRXML_ID"] = ITRXML_ID.ToString();           

            //To find the first URL to be opened after going to Salary Page from Menu Proc:
            //bllMain objbllMain = new bllMain();
            DataTable dtMenu = new DataTable();
            bllMain objbllMain = new bllMain();
            bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            dtMenu = objbllMain.getMenu(Session["ay"].ToString(), Session["ITR"].ToString(), Session["AssesseeType"].ToString(), Session["Project"].ToString(), Convert.ToInt64(Session["User_ID"]));

            Session["IncomeTax_VType"] = "40";
            if (Session["UpdateXML"] == "edt" || Session["Mode"] == "Edit")
            {
                bllSalary objbllSalary = new bllSalary();
                //string Vtype = Session["Vtype"].ToString();
                objbllSalary.FetchTransData("106", Session["NameID"].ToString(), Session["ay"].ToString(), 0);
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
                if (objbllStoreTrans.getDataCount(Session["NameID"].ToString()) > 0)
                {
                    if (dtMenu.Rows.Count > 0)
                    {
                        if (Session["project"].ToString() == "vt")
                            Session["IncomeTax_VType"] = (dtMenu.Rows[0]["Menu_Link"].ToString().Contains("40")) ? "40" : "42";
                        else
                            Session["IncomeTax_VType"] = (dtMenu.Rows[0]["Menu_Link"].ToString().Contains("3001")) ? "3001" : "3001";
                    }
                    else
                        Session["IncomeTax_VType"] = "40";
                    Response.Redirect("IncomeTax");
                }
                else
                    Response.Redirect("DisplayForm.aspx");
            }
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "Error", "<script type='text/javascript'>getPopup(); </script>");
        }
    }
  
    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }
}