using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataEntity;
using System.Data;

public partial class Presentation_Supervisor_Verif : System.Web.UI.Page
{
    string Org = "5";
    static string ITRXML_ID = "";
    static int StateID = 26;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
            Response.Redirect("Logout.aspx");
        if (!IsPostBack)
        {
            if (Request.QueryString["act"] != null)
            {
                if (Request.QueryString["act"].ToString() == "n" && Session["ITRXML_ID"] != null)
                {
                    hdn1.Value = "callit";
                    Session["ITRXML_ID"] = null;
                    //objcommon.startProcessHistoryJob(Convert.ToInt64(dtGrid.Rows[0][1]), Convert.ToInt64(dtGrid.Rows[0][4]), "Supervisor", "N");
                }
                if (Request.QueryString["act"].ToString() == "n" && Session["AssesseeType"]!=null && Session["Project"].ToString()=="tds")
                {
                    hdn1.Value = "callit";
                    Session["AssesseeType"] = null;
                }
            }
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

    protected void btnMsg_Click(object sender, EventArgs e)
    {
        if (Session["Job_ID"] != null && Session["NextUserID"] != null)
        {
            common objcommon = new common();
            objcommon.updateProcessDetail(Convert.ToInt64(Session["Job_ID"]), Convert.ToInt64(Session["NextUserID"]), "N", hdnMsg.Value);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)VGrid1.SelectedRow;
    }

    public void BindNewGrid()
    {

        if (Session["Project"].ToString()=="vt")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";

            VGrid1.GridName = "grdAssesseeFirm_SupVerf";
            VGrid1.Parameters = Org;
            VGrid1.DropDownParameters = Org;
            VGrid1.DataBind();
        }
        else if (Session["Project"].ToString() == "tds")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";

            VGrid1.GridName = "grdDeducteeFirm_SuperVerif";
            VGrid1.Parameters = Org;
            VGrid1.DropDownParameters = Org;
            VGrid1.DataBind();
        }

        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        //}
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.SelectedRow;

        if (Session["Project"].ToString() == "vt")
        {
            string ss = dtGrid.Rows[0][2].ToString();
            ITRXML_ID = dtGrid.Rows[0][0].ToString();
            Session["UpdateXML"] = "sel";
            Session["ITR"] = dtGrid.Rows[0][2].ToString();
            Session["ay"] = dtGrid.Rows[0][10].ToString();
            Session["AY"] = dtGrid.Rows[0][10].ToString();
            Session["ReturnType"] = dtGrid.Rows[0][9].ToString();
            Session["NameID"] = dtGrid.Rows[0][3].ToString();
            Session["ITRXML_ID"] = ITRXML_ID.ToString();
            Session["AssesseeType"] = "0";
            Session["Job_ID"] = dtGrid.Rows[0][1].ToString();
            Session["NextUserID"] = dtGrid.Rows[0][12].ToString();
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
            Response.Redirect("Main.aspx?ut=o");
        }
        else if (Session["Project"].ToString() == "tds")
        {
            string detail = dtGrid.Rows[0][2].ToString();
            string Project = dtGrid.Rows[0][0].ToString() + "-" + Session["Project"].ToString().ToUpper();
            bllITR objbllITR = new bllITR();
            Session["ITR"] = objbllITR.getReturnType(detail, Project); // dtGrid.Rows[0][2].ToString();
            string[] arrAY = System.Text.RegularExpressions.Regex.Split(dtGrid.Rows[0][10].ToString(), "-");
            string strAY = ((Convert.ToInt32(arrAY[0]) + 1).ToString() + "-" + (Convert.ToInt32(arrAY[1]) + 1).ToString());
            Session["ay"] = ((Convert.ToInt32(arrAY[0]) + 1).ToString() + "-" + (Convert.ToInt32(arrAY[1]) + 1).ToString());
            Session["AY"] = Session["ay"].ToString();
            Session["Operator_JobID"] = dtGrid.Rows[0][1].ToString();
            Session["FormType"] = dtGrid.Rows[0][2].ToString();
            Session["FY"] = dtGrid.Rows[0][10].ToString();
            Session["qtr"] = dtGrid.Rows[0][0].ToString();
            Session["OC"] = dtGrid.Rows[0][9].ToString();
            Session["TAN"] = dtGrid.Rows[0][8].ToString();
            Session["PAN"] = dtGrid.Rows[0][8].ToString();
            Session["Name"] = dtGrid.Rows[0][7].ToString();
            Session["NameID"] = dtGrid.Rows[0][3].ToString();
            Session["Job_ID"] = dtGrid.Rows[0][1].ToString();
            Session["NextUserID"] = dtGrid.Rows[0][12].ToString();

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

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }
}