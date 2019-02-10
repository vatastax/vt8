using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.IO;

public partial class Presentation_TDSClientPay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NameID"] == null)
            Response.Redirect("../pageRedirect.aspx?prj=tds2");
        if (Request.QueryString["st"] != null && Session["TDSClientStatus"] == null)
        {
            DataTable dt = new DataTable();
            if (Session["GridData"] != null)
            {
                DataTable dtt = new DataTable();
                dtt = (DataTable)Session["GridData"];
                string TAN_tmp = (Session["TAN"] != null) ? Session["TAN"].ToString() : "";
                string PAN_tmp = (Session["PAN"] != null) ? Session["PAN"].ToString() : "";
                
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    common objcommon = new common();
                    Session["TAN"] = dtt.Rows[i]["TAN"].ToString();
                    Session["Qtr"] = dtt.Rows[i]["Quarter"].ToString();
                    Session["OC"] = dtt.Rows[i]["Type"].ToString();
                    Session["FormType"] = dtt.Rows[i]["Form"].ToString();
                    Session["Dir_Path_Tmp"] = dtt.Rows[i]["Path_of_Directory"].ToString();
                                        
                    objcommon.SaveJob(Session["NameID"].ToString(), Session["userEmail"].ToString(), "");
                    objcommon.updateTDSClient_Returns(Convert.ToInt64(dtt.Rows[i]["ID"]), Convert.ToInt64(Session["Common_JobID"]));

                    string[] arrFiles = Directory.GetFiles(dtt.Rows[i]["Path_of_Directory"].ToString());
                    for (int k = 0; k < arrFiles.Length; k++)
                    {
                        File.Move(arrFiles[k], (Session["Common_JobID_Path"].ToString() + "\\" + (arrFiles[k].Substring(arrFiles[k].LastIndexOf("\\") + 1))));
                        //Session["Common_JobID_Path"]
                    }
                }
            }
            Session["TDSClientStatus"] = "done";
            pnlMain.Visible = false;
            pnlSec.Visible = true;
        }

        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grd_Clients_TDS2";        
        VGrid1.Parameters = Session["NameID"].ToString();
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
        VGrid1.VGrid_Delete += new EventHandler(VGrid1_VGrid_Delete);
        dny_BOBtn.btn_buttonClick += new EventHandler(dny_BOBtn_btn_buttonClick);
    }

    void VGrid1_VGrid_Delete(object sender, EventArgs e)
    {
        
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (ViewState["deletion"] == "true")
        {
            ViewState["deletion"] = "";
            Response.Redirect(Request.Url.ToString());
        }
        double amt = 0;
        DataTable dt = new DataTable();
        if (Session["GridData"] != null)
        {
            DataTable dtt = new DataTable();
            dtt = (DataTable)Session["GridData"];
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                amt += ((dtt.Rows[i][8] != "") ? Convert.ToDouble(dtt.Rows[i][8]) : 0);
            }
        }
        ltAmt.Text = amt.ToString() + ".00";
    }

    void dny_BOBtn_btn_buttonClick(object sender, EventArgs e)
    {
        Session["TDSClientStatus"] = null;
        Random rnd = new Random();
        string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
        string txnid1 = strHash.ToString().Substring(0, 20);
        string hash_string = "j0SeMe|" + txnid1 + "|" + ltAmt.Text + "|ITR Registration|" + Session["user_name"].ToString() + "|" + Session["UserName"].ToString() + "|||||||||||kKqhSjvn";
        string hash1 = Generatehash512(hash_string).ToLower();
        Page.Controls.Add(new LiteralControl(@"<form id='PostForm' name='PostForm' action='https://secure.payu.in/_payment/_payment' method='POST'><input type='hidden' name='lastname' value=''><input type='hidden' name='address2' value=''><input type='hidden' name='udf5' value=''><input type='hidden' name='curl' value=''><input type='hidden' name='udf4' value=''><input type='hidden' name='txnid' value='" + txnid1 + "'><input type='hidden' name='furl' value='" + Request.Url.ToString() + "?st=fail'><input type='hidden' name='state' value='PUNJAB'><input type='hidden' name='udf2' value=''><input type='hidden' name='udf1' value=''><input type='hidden' name='zipcode' value='0'><input type='hidden' name='amount' value=" + ltAmt.Text + "><input type='hidden' name='email' value='" + Session["UserName"].ToString() + "'><input type='hidden' name='city' value='Jalandhar'><input type='hidden' name='country' value='India'><input type='hidden' name='udf3' value=''><input type='hidden' name='address1' value=''><input type='hidden' name='hash' value='" + hash1 + "'><input type='hidden' name='key' value='j0SeMe'><input type='hidden' name='pg' value=''><input type='hidden' name='surl' value='http://localhost:1340/tfs_vatas/Presentation/ECA_Details.aspx?st=pass'><input type='hidden' name='firstname' value='" + Session["user_name"].ToString() + "'><input type='hidden' name='productinfo' value='ITR Registration'><input type='hidden' name='phone' value='9123456789'></form><script language='javascript'>var vPostForm = document.PostForm;vPostForm.submit();</script>"));
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
        throw new NotImplementedException();
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