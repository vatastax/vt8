using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using controlgrid;
using System.Configuration;
using Taxation.BusinessLogic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Taxation.DataEntity;

public partial class Presentation_TDSClient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NameID"] == null)
            Response.Redirect("../pageRedirect.aspx?prj=tds2");
        Button Button12 = (Button)Master.FindControl("Button12");
        string ss = Button12.Text;
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grd_Clients_TDS";        
        VGrid1.Parameters = Session["NameID"].ToString();
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        VGrid1.VGrid_Delete += new EventHandler(VGrid1_VGrid_Delete);

        //For Dynamic Buttons:
        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DynamicControl.Project_Name = ConfigurationManager.ConnectionStrings["SQLServer6"].ConnectionString;
        DynamicControl.k = 2;
        DynamicControl.h = 1;
        if (!Page.IsPostBack)
        {
            if (true)
            {
                DynamicControl.Flag_Update = "";
                DynamicControl.Flag_Search = "";
                DynamicControl.Flag_Delete = "";
                DynamicControl.Flag_Filter = "";
                DynamicControl.dt_DeletedData = new DataTable();
                DynamicControl.Flag_Paging = "";
            }
            DynamicControl.count_Check = "F";
        }
        dny_BOBtn.btn_buttonClick += new EventHandler(dny_BOBtn_btn_buttonClick);

        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        objbllStoreTrans.deleteUser_VType(Session["NameID"].ToString(), "15074");
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (dny_BOBtn.Client_NoAction == "N")
        {
            Response.Redirect("TDSClientPay.aspx");
        }
        if (ViewState["deletion"] == "true")
        {
            ViewState["deletion"] = "";
            Response.Redirect(Request.Url.ToString());
        }
    }

    //Click Event of Back  Office Button
    protected void dny_BOBtn_btn_buttonClick(object sender, EventArgs e)
    {   
        
        Button btn = (Button)sender;
        if (btn.Text == "Add Return")
        {
            bllStoreTrans objbllStoreTrans = new bllStoreTrans();            
            string strDirPath = Server.MapPath("~/UserDocs/") + Session["User_ID"].ToString();
            if (!Directory.Exists(strDirPath))
                Directory.CreateDirectory(strDirPath);

            string[] arrDir = Directory.GetDirectories(strDirPath);
            Directory.CreateDirectory(strDirPath + "/" + (arrDir.Length + 1).ToString());
            Session["Dir_Path"] = strDirPath + "/" + (arrDir.Length + 1).ToString();
            common objcommon = new common();
            objcommon.AddPath();
            //Session["IncomeTax_VType"] = "15074";
            //Response.Redirect("IncomeTax");
            Response.Redirect("manageLinking.aspx?vtype=15074");
        }
        else if (btn.Text == "Pay")
        {
            dny_BOBtn.Client_NoAction = "N";
            dny_BOBtn.parameters = Session["NameID"].ToString();
            //Response.Redirect("TDSClientPay.aspx");   
        }
    }

    public string Generatehash512(string text)
    {

        byte[] message = Encoding.UTF8.GetBytes(text);
        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] hashValue;
        SHA512Managed hashString = new SHA512Managed();
        string hex = "";
        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["IncomeTax_VType"] = "15074";
        Response.Redirect("IncomeTax");        
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)VGrid1.SelectedRow;
        
        bllSalary objbllSalary = new bllSalary();
        objbllSalary.FetchTransData("15074", Session["NameID"].ToString(), Session["ay"].ToString(), Convert.ToInt32(VGrid1.SelectedDataKey));
        Session["IncomeTax_VType"] = "15074";
        Response.Redirect("IncomeTax");
    }

    void VGrid1_VGrid_Delete(object sender, EventArgs e)
    {

    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        try
        {
            GridViewCommandEventArgs ee = (GridViewCommandEventArgs)e;
            GridView gv = new GridView();
            gv = (GridView)sender;
            int indx = (Convert.ToInt32(ee.CommandArgument) + (gv.PageIndex * gv.PageSize));
            DataTable dt = new DataTable();
            dt = ((DataTable)HttpContext.Current.Session["GridData"]);
            string datakey = dt.Rows[indx][gv.DataKeyNames[0]].ToString();
            VGrid1.DeleteParameters = datakey;
            ViewState["deletion"] = "true";
        }
        catch (Exception ex)
        {

        }
        finally
        {
            //Response.Redirect(Request.RawUrl);
        }
        //throw new NotImplementedException();
    }
}