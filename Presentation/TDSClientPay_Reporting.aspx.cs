using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Taxation.BusinessLogic;
using System.IO;
using Ionic.Zip;
using System.Text;
using System.Security.Cryptography;

public partial class Presentation_TDSClientPay_Reporting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NameID"] == null)
            Response.Redirect("../pageRedirect.aspx?prj=tds2");
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grd_Clients_TDS_Reporting";        
        VGrid1.Parameters = Session["NameID"].ToString();
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);        
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);

        DataTable dt = new DataTable();
        dt = (DataTable)VGrid1.SelectedRow;
        if (hdnMP.Value != "")
            makePayment();
        if (Request.QueryString["st"] != null && Session["TDS_IDD"] != null)
        {
            common objcommon = new common();
            objcommon.resetStatus(Convert.ToInt64(Session["TDS_IDD"]));
            Session["TDS_IDD"] = null;
            Response.Redirect("TDSClientPay_Reporting.aspx");
        }
    }

    public void makePayment()
    {
        string amt = (hdnPayment.Value != "") ? hdnPayment.Value : "1";
        Session["TDS_IDD"] = hdnMP.Value;
        Session["TDSClientStatus"] = null;
        Random rnd = new Random();
        string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
        string txnid1 = strHash.ToString().Substring(0, 20);
        string hash_string = "j0SeMe|" + txnid1 + "|" + amt + "|ITR Registration|" + Session["user_name"].ToString() + "|" + Session["UserName"].ToString() + "|||||||||||kKqhSjvn";
        string hash1 = Generatehash512(hash_string).ToLower();
        Page.Controls.Add(new LiteralControl(@"<form id='PostForm' name='PostForm' action='https://secure.payu.in/_payment/_payment' method='POST'><input type='hidden' name='lastname' value=''><input type='hidden' name='address2' value=''><input type='hidden' name='udf5' value=''><input type='hidden' name='curl' value=''><input type='hidden' name='udf4' value=''><input type='hidden' name='txnid' value='" + txnid1 + "'><input type='hidden' name='furl' value='" + Request.Url.ToString() + "?st=fail'><input type='hidden' name='state' value='PUNJAB'><input type='hidden' name='udf2' value=''><input type='hidden' name='udf1' value=''><input type='hidden' name='zipcode' value='0'><input type='hidden' name='amount' value=" + amt + "><input type='hidden' name='email' value='" + Session["UserName"].ToString() + "'><input type='hidden' name='city' value='Jalandhar'><input type='hidden' name='country' value='India'><input type='hidden' name='udf3' value=''><input type='hidden' name='address1' value=''><input type='hidden' name='hash' value='" + hash1 + "'><input type='hidden' name='key' value='j0SeMe'><input type='hidden' name='pg' value=''><input type='hidden' name='surl' value='http://localhost:1340/tfs_vatas/Presentation/ECA_Details.aspx?st=pass'><input type='hidden' name='firstname' value='" + Session["user_name"].ToString() + "'><input type='hidden' name='productinfo' value='ITR Registration'><input type='hidden' name='phone' value='9123456789'></form><script language='javascript'>var vPostForm = document.PostForm;vPostForm.submit();</script>"));
        hdnMP.Value = "";
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
        Session["IncomeTax_VType"] = "101";
        Response.Redirect("IncomeTax");
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)VGrid1.SelectedRow;
        if (dt.Rows[0]["Remarks"].ToString() != "Uploaded")
        {
            bllSalary objbllSalary = new bllSalary();
            Session["DataKey"] = VGrid1.SelectedDataKey;
            objbllSalary.FetchTransData("15074", Session["NameID"].ToString(), Session["ay"].ToString(), Convert.ToInt32(VGrid1.SelectedDataKey));
            Session["IncomeTax_VType"] = "15074";
            Response.Redirect("IncomeTax");
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert_custom('Not Pending', 2, 'Error Message', '', '', '', ['OK', 'Cancel']); </script>");
        }
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["GridData"];

        GridViewCommandEventArgs ee = (GridViewCommandEventArgs)e;
        if (ee.CommandArgument != "")
        {
            int grdIndx = Convert.ToInt32(ee.CommandArgument);
            string Files_All = dt.Rows[grdIndx]["Path_of_Directory"].ToString();

            string[] arrFiles = Directory.GetFiles(Files_All);
            using (ZipFile zip = new ZipFile())
            {
                for (int i = 0; i < arrFiles.Length; i++)
                {
                    zip.AddFile(arrFiles[i], "files");
                }
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                Response.End();
            }            
        }
    }
}