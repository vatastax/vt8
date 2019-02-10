using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataEntity;
using System.Data;

public partial class Presentation_Reception : System.Web.UI.Page
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

        //if (Session["NameID"] != null)
        //{
            VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";

            VGrid1.GridName = "grdAssessee";
            VGrid1.Parameters = Org;
            VGrid1.DataBind();

            //VGrid1.VGrid_Delete += new EventHandler(VGrid1_VGrid_Delete);
            VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
            VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        //}
        
    }

    protected void btnProcess_Click(object sender, EventArgs e)
    {
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";

        VGrid1.GridName = "grdAssesseeFirm";
        VGrid1.Parameters = Org;
        VGrid1.DataBind();

        //VGrid1.VGrid_Delete += new EventHandler(VGrid1_VGrid_Delete);
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.SelectedRow;
        string ss = dtGrid.Rows[0][2].ToString();
        ITRXML_ID = dtGrid.Rows[0][0].ToString();
        Session["UpdateXML"] = "sel";
        Session["ITR"] = dtGrid.Rows[0][2].ToString();
        Session["ay"] = dtGrid.Rows[0][9].ToString();
        Session["ReturnType"] = dtGrid.Rows[0][8].ToString();
        Session["NameID"] = dtGrid.Rows[0][3].ToString();
        Session["ITRXML_ID"] = ITRXML_ID.ToString();
        Session["AssesseeType"] = "0";
        //Response.Redirect("Main.aspx?ut=o");
        common objcommon = new common();
        objcommon.startProcessHistoryJob(Convert.ToInt64(dtGrid.Rows[0][1]), 0, "Reception", "Y");
        Response.Redirect(Request.Url.ToString());       
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