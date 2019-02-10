using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataEntity;
using System.Data;

public partial class Presentation_Reception_Reporting : System.Web.UI.Page
{
    string Org = "5";
    static string ITRXML_ID = "";
    static int StateID = 26;

    protected void Page_Load(object sender, EventArgs e)
    {
        balAdmin objbalAdmin = new balAdmin();
        tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
        objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(Session["user_ID"]));
        Org = objtbl_UserRegistration.OrganizationName;
        BindNewGrid();
    }
    public void BindNewGrid()
    {
        if (Session["Project"].ToString() == "vt")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";

            VGrid1.GridName = "grdAssessee";
            VGrid1.Parameters = Org;
            VGrid1.DataBind();
            VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
            VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        }
        else if (Session["Project"].ToString() == "tds")
        {
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
            VGrid1.GridName = "grd_DeducteeReport";
            VGrid1.Parameters = Org;
            VGrid1.DataBind();
            VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
            VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        }
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtGrid = new DataTable();
        dtGrid = (DataTable)VGrid1.SelectedRow;

        if (Session["Project"].ToString() == "vt")
        {
            ITRXML_ID = dtGrid.Rows[0]["ID"].ToString();
            Session["UpdateXML"] = "sel";
            Session["ITR"] = dtGrid.Rows[0]["ITRType"].ToString();
            Session["ay"] = dtGrid.Rows[0]["AY"].ToString();
            Session["AY"] = dtGrid.Rows[0]["AY"].ToString();
            Session["PAN"] = dtGrid.Rows[0]["PANNo"].ToString();
            Session["ReturnType"] = dtGrid.Rows[0]["ReturnType"].ToString();
            Session["NameID"] = dtGrid.Rows[0]["NameID"].ToString();
            Session["ITRXML_ID"] = ITRXML_ID.ToString();
            Session["Operator_JobID"] = dtGrid.Rows[0]["Job_ID"].ToString();
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
            Response.Redirect("../Main.aspx?ut=o");
        }
        else if (Session["Project"].ToString() == "tds")
        {
            string[] arrAY = System.Text.RegularExpressions.Regex.Split(dtGrid.Rows[0][7].ToString(), "-");
            Session["ay"] = ((Convert.ToInt32(arrAY[0]) + 1).ToString() + "-" + (Convert.ToInt32(arrAY[1]) + 1).ToString());
            Session["AY"] = Session["ay"].ToString();
            Session["FormType"] = dtGrid.Rows[0][8].ToString();
            Session["FY"] = dtGrid.Rows[0][7].ToString();
            Session["qtr"] = dtGrid.Rows[0][10].ToString();
            Session["OC"] = dtGrid.Rows[0][9].ToString();
            Session["TAN"] = dtGrid.Rows[0][5].ToString();

            Session["PAN"] = dtGrid.Rows[0][5].ToString();
            Session["Name"] = dtGrid.Rows[0][4].ToString();
            Session["NameID"] = dtGrid.Rows[0][1].ToString();
            Session["Job_ID"] = dtGrid.Rows[0][0].ToString();
            string Type = "";

            if (Session["Regular_Correction"] != null)
                Type = Session["Regular_Correction"].ToString();

            bllMain objbllMain = new bllMain();
            DataTable dt = new DataTable();
            dt = objbllMain.FormQuaeterMapping(Session["FormType"].ToString(), Session["qtr"].ToString(), Type);
            if (dt.Rows.Count > 0)
            {
                Session["ITR"] = dt.Rows[0][0].ToString();
            }

            common objcommon = new common();
            bool IsJobExists = false;
            IsJobExists = objcommon.IsJobExists(Session["TAN"].ToString(), Session["FY"].ToString(), Session["FY"].ToString(), Session["FormType"].ToString(), Session["OC"].ToString());
            if (!IsJobExists)
                objcommon.SaveJob_TDS(Session["userEmail"].ToString());

            objbllMain.TDSMasterDetails(Session["TAN"].ToString(), Session["FY"].ToString(), "Regular", Session["qtr"].ToString(), Session["FormType"].ToString(), Session["AY"].ToString());
            Session["AssesseeType"] = "999999"; //Default Assessee Type for TDS as there is no Assessee Type in TDS
            //Response.Redirect("DisplayForm.aspx");
            Session["IncomeTax_VType"] = "3001";
            Response.Redirect("../IncomeTax");
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
        bllSalary objbllSalary = new bllSalary();


        denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
        Session["restore"] = "true";
        Session["PAN"] = PAN;

        denMain objMainDEN = new denMain();
        bllMain objMainBLL = new bllMain();


        objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), 0, 0, Convert.ToInt32(objbllSalary.getDataForConstID("14", Session["NameID"].ToString())));
        string[] arrDate = System.Text.RegularExpressions.Regex.Split(objMainDEN.DueDate, "/");
        DateTime dtime = new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]));

    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

    protected void btnAddAssessee_Click(object sender, EventArgs e)
    {
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
}