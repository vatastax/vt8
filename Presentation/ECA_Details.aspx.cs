using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.BusinessLogic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Configuration;
using Taxation.DataEntity;
using Newtonsoft.Json.Linq;
using System.Data;

public partial class Presentation_ECA_Details : System.Web.UI.Page
{
    bllStates objbllStates;
    public string action1 = string.Empty;
    public string hash1 = string.Empty;
    public string txnid1 = string.Empty;
    static string path = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["st"] != null)
        //    GetTxnStatus();
        if (Session["user_id"] == null)
            Response.Redirect("../Default.aspx");
        if (!IsPostBack)
        {
           

            //path = Server.MapPath("~/UserDocs/" + Session["user_id"].ToString());
            common objcommon = new common();
            if (Session["Account_Type"] != null)
            {
                if (Session["Account_Type"].ToString() == "E")
                    path = objcommon.getDirectoryPath_ByUsername();
                else
                    path = objcommon.getDirectoryPath();
            }
            bindStates();
            bindgrd(path);
        }
        try
        {
            if (Session["Account_Type"] != null)
            {
                if (Session["Account_Type"].ToString() == "E")
                {
                    balAdmin objbalAdmin = new balAdmin();
                    tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
                    objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(Session["User_ID"]));
                    firstname.Text = objtbl_UserRegistration.Name;
                    lastname.Text = objtbl_UserRegistration.Last_Name;
                    email.Text = objtbl_UserRegistration.EmailID;
                    phone.Text = (objtbl_UserRegistration.Telephone != "") ? objtbl_UserRegistration.Telephone : "9123456789";
                    address1.Text = objtbl_UserRegistration.Address1;
                    city.Text = "Jalandhar";// objtbl_UserRegistration.City;
                    //state.Text = objtbl_UserRegistration.State;
                    bllStates objbllStates = new bllStates();
                    state.Text = objbllStates.SelectStateName((objtbl_UserRegistration.State == 0) ? 26 : objtbl_UserRegistration.State);
                    country.Text = "India";
                    zipcode.Text = objtbl_UserRegistration.PinCode.ToString();
                    key.Value = ConfigurationManager.AppSettings["MERCHANT_KEY"];
                    surl.Text = Request.Url.ToString() + "?st=pass";
                    furl.Text = Request.Url.ToString() + "?st=fail";
                    amount.Text = "1";
                    productinfo.Text = "ITR Registration";
                }
            }
            else if (Session["NameID"] != null)
            {
                bllAssessee objbllAssessee = new bllAssessee();
                denAssesseeIndividual objdenAssesseeIndividual = new denAssesseeIndividual();
                objdenAssesseeIndividual = objbllAssessee.GetDataIndividualByNameID(Session["NameID"].ToString());

                firstname.Text = objdenAssesseeIndividual.FirstName;
                lastname.Text = objdenAssesseeIndividual.LastName;
                email.Text = objdenAssesseeIndividual.EMail;
                phone.Text = (objdenAssesseeIndividual.PhoneNo != "") ? objdenAssesseeIndividual.PhoneNo : "9123456789";
                address1.Text = objdenAssesseeIndividual.Address;
                
                city.Text = "Jalandhar";// objtbl_UserRegistration.City;
                bllStates objbllStates = new bllStates();
                bllStoreTrans objbllStoreTrans = new bllStoreTrans();
                string State = "";
                State = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "14");
                state.Text = objbllStates.SelectStateName((State == "") ? 26 : Convert.ToInt32(State));
                country.Text = "India";
                zipcode.Text = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "16");
                key.Value = ConfigurationManager.AppSettings["MERCHANT_KEY"];
                surl.Text = Request.Url.ToString() + "?st=pass";
                furl.Text = Request.Url.ToString() + "?st=fail";
                amount.Text = "1";
                productinfo.Text = "ITR Registration";
            }
            if (!IsPostBack)
            {
                frmError.Visible = false; // error form
            }
            else
            {
                //frmError.Visible = true;
            }
            if (string.IsNullOrEmpty(Request.Form["hash"]))
            {
                submit.Visible = true;
            }
            else
            {
                submit.Visible = false;
            }

        }
        catch (Exception ex)
        {
            Response.Write("<span style='color:red'>" + ex.Message + "</span>");
        }
        //goPay();
    }
    //bind states
    private void bindStates()
    {
        objbllStates = new bllStates();
        
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            // +FileUpload1.FileName;// +txtPAN.Text;  // Give the specific path
            if (!(Directory.Exists(path)))
            {
                try
                {
                    Directory.CreateDirectory((path));
                }
                catch (Exception ex)
                {
                    throw ex;
                }              
            }
            FileUpload1.PostedFile.SaveAs((path) + "/" + fileName);
            bindgrd(path);
        }
    }
    //bind grid with uploaded documnets
    private void bindgrd(string path)
    {
        //string path = "~/UserDocs/";// +txtPAN.Text + "/";
        string[] filePaths = (Directory.Exists(path)) ? Directory.GetFiles(path) : null;
        if (filePaths != null)
        {
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }
            GridView1.DataSource = files;
            GridView1.DataBind();
        }
    }
    //function for delete fils
    protected void DeleteFile(object sender, EventArgs e)
    {
        string filePath = "";// (sender as LinkButton).CommandArgument;
        filePath = (sender as Button).ToolTip;
        File.Delete(filePath);
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    //function for download files
    protected void DownloadFile(object sender, EventArgs e)
    {
        string filePath = "";// (sender as LinkButton).CommandArgument;
        filePath = (sender as Button).ToolTip;
        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        byte[] ar = new byte[(int)fs.Length];
        fs.Read(ar, 0, (int)fs.Length);
        fs.Close();
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filePath);
        Response.BinaryWrite(ar);
        Response.End();
    }
    private void goPay()
    {
        
        try
        {
            string[] hashVarsSeq;
            string hash_string = string.Empty;

            if (string.IsNullOrEmpty(Request.Form["txnid"])) // generating txnid
            {
                Random rnd = new Random();
                string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
                txnid1 = strHash.ToString().Substring(0, 20);
            }
            else
            {
                txnid1 = Request.Form["txnid"];
            }
            if (string.IsNullOrEmpty(Request.Form["hash"])) // generating hash value
            {
                if(string.IsNullOrEmpty(ConfigurationManager.AppSettings["MERCHANT_KEY"]))
                {

                }
                 if(string.IsNullOrEmpty(txnid1))
                 {

                 }
                if(string.IsNullOrEmpty(Request.Form["amount"]))
                {

                }
                if(string.IsNullOrEmpty(Request.Form["firstname"]))
                {

                }
                if(string.IsNullOrEmpty(Request.Form["email"]))
                {

                }
                if(string.IsNullOrEmpty(Request.Form["phone"]))
                {

                }
                if(string.IsNullOrEmpty(Request.Form["productinfo"]))
                {
                    
                }
                if(string.IsNullOrEmpty(Request.Form["surl"]))
                {

                }
                if (string.IsNullOrEmpty(Request.Form["furl"]))
                {

                }
                if (
                    string.IsNullOrEmpty(ConfigurationManager.AppSettings["MERCHANT_KEY"]) ||
                    string.IsNullOrEmpty(txnid1) ||
                    string.IsNullOrEmpty(Request.Form["amount"]) ||
                    string.IsNullOrEmpty(Request.Form["firstname"]) ||
                    string.IsNullOrEmpty(Request.Form["email"]) ||
                    string.IsNullOrEmpty(Request.Form["phone"]) ||
                    string.IsNullOrEmpty(Request.Form["productinfo"]) ||
                    string.IsNullOrEmpty(Request.Form["surl"]) ||
                    string.IsNullOrEmpty(Request.Form["furl"])
                    )
                {
                    //error

                    frmError.Visible = true;
                    return;
                }

                else
                {
                    //Request.Form["surl"] = Request.Url.ToString() + "?st=pass";
                    //Request.Form["furl"] = Request.Url.ToString() + "?st=fail";
                    frmError.Visible = false;
                    hashVarsSeq = ConfigurationManager.AppSettings["hashSequence"].Split('|'); // spliting hash sequence from config
                    hash_string = "";
                    foreach (string hash_var in hashVarsSeq)
                    {
                        if (hash_var == "key")
                        {
                            hash_string = hash_string + ConfigurationManager.AppSettings["MERCHANT_KEY"];
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "txnid")
                        {
                            hash_string = hash_string + txnid1;
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "amount")
                        {
                            hash_string = hash_string + Convert.ToDecimal(Request.Form[hash_var]).ToString("g29");
                            hash_string = hash_string + '|';
                        }
                        else
                        {
                            hash_string = hash_string + (Request.Form[hash_var] != null ? Request.Form[hash_var] : "");// isset if else
                            hash_string = hash_string + '|';
                        }
                    }

                    hash_string += ConfigurationManager.AppSettings["SALT"];// appending SALT

                    hash1 = Generatehash512(hash_string).ToLower();         //generating hash
                    action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";// setting URL
                }
            }
            else if (!string.IsNullOrEmpty(Request.Form["hash"]))
            {
                hash1 = Request.Form["hash"];
                action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";
            }

            if (!string.IsNullOrEmpty(hash1))
            {
                hash.Value = hash1;
                txnid.Value = txnid1;
                Session["txnid"] = txnid1.ToString();
                Session["hash"] = hash1;
                //Adding Record to tbl_OnlinePaymentRecd
                balAdmin objbalAdmin = new balAdmin();
                tbl_OnlinePaymentRecd objtbl_OnlinePaymentRecd = new tbl_OnlinePaymentRecd();
                objtbl_OnlinePaymentRecd.Merchant_Transaction_Id = txnid.Value;
                objtbl_OnlinePaymentRecd.Date_of_Transaction = DateTime.Now;
                objtbl_OnlinePaymentRecd.Amount = Convert.ToDecimal(amount.Text.Trim());
                if (Session["Account_Type"] != null)
                {
                    if (Session["Account_Type"].ToString() == "E")
                    {
                        objtbl_OnlinePaymentRecd.Customer_Name = Session["user_id"].ToString();
                        objtbl_OnlinePaymentRecd.Customer_Email = Session["userEmail"].ToString();
                    }
                    else
                    {
                        bllSalary objbllSalary = new bllSalary();
                        objtbl_OnlinePaymentRecd.Customer_Name = Session["Name"].ToString();
                        objtbl_OnlinePaymentRecd.Customer_Email = objbllSalary.getDataForConstID_String("21", Session["NameID"].ToString());
                    }
                }

                objbalAdmin.Add_OnlinePayment(objtbl_OnlinePaymentRecd);

                System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                data.Add("hash", hash.Value);
                data.Add("txnid", txnid.Value);
                data.Add("key", key.Value);
                string AmountForm = Convert.ToDecimal(amount.Text.Trim()).ToString("g29");// eliminating trailing zeros
                amount.Text = AmountForm;
                data.Add("amount", AmountForm);
                data.Add("firstname", firstname.Text.Trim());
                data.Add("email", email.Text.Trim());
                data.Add("phone", phone.Text.Trim());
                data.Add("productinfo", productinfo.Text.Trim());
                data.Add("surl", surl.Text.Trim());
                data.Add("furl", furl.Text.Trim());
                data.Add("lastname", lastname.Text.Trim());
                data.Add("curl", curl.Text.Trim());
                data.Add("address1", address1.Text.Trim());
                data.Add("address2", address2.Text.Trim());
                data.Add("city", city.Text.Trim());
                data.Add("state", state.Text.Trim());
                data.Add("country", country.Text.Trim());
                data.Add("zipcode", zipcode.Text.Trim());
                data.Add("udf1", udf1.Text.Trim());
                data.Add("udf2", udf2.Text.Trim());
                data.Add("udf3", udf3.Text.Trim());
                data.Add("udf4", udf4.Text.Trim());
                data.Add("udf5", udf5.Text.Trim());
                data.Add("pg", pg.Text.Trim());
                //data.Add("service_provider", service_provider.Text.Trim());

                string strForm = PreparePOSTForm(action1, data);
                Page.Controls.Add(new LiteralControl(strForm));
            }
            else
            {
                //no hash
            }
        }
        catch (Exception ex)
        {
            Response.Write("<span style='color:red'>" + ex.Message + "</span>");
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

    private void GetTxnStatus()
    {

        string Url = "https://info.payu.in/merchant/postservice?form=1";

        string method = "verify_payment";
        string salt = ConfigurationManager.AppSettings["SALT"].ToString();// "TKLA3Zgf";
        string key = ConfigurationManager.AppSettings["MERCHANT_KEY"].ToString();  //"nDmZR3";
        string var1 = Session["txnid"].ToString();// txnid1; //"1610900"; //Transaction ID of the merchant
        

        string toHash = key + "|" + method + "|" + var1 + "|" + salt;

        string Hashed = Generatehash512(toHash);

        string postString = "key=" + key +
            "&command=" + method +
            "&hash=" + Hashed +
            "&var1=" + var1;

        WebRequest myWebRequest = WebRequest.Create(Url);
        myWebRequest.Method = "POST";
        myWebRequest.ContentType = "application/x-www-form-urlencoded";
        myWebRequest.Timeout = 180000;
        StreamWriter requestWriter = new StreamWriter(myWebRequest.GetRequestStream());
        requestWriter.Write(postString);
        requestWriter.Close();

        StreamReader responseReader = new StreamReader(myWebRequest.GetResponse().GetResponseStream());
        WebResponse myWebResponse = myWebRequest.GetResponse();
        Stream ReceiveStream = myWebResponse.GetResponseStream();
        Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
        StreamReader readStream = new StreamReader(ReceiveStream, encode);

        string response = readStream.ReadToEnd();

        if (response.Contains("Transactions Fetched Successfully"))
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>Payment Successfull</script>");
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>Payment Un-Successfull</script>");
        }

        //JObject account = JObject.Parse(response);
        //String status = (string)account.SelectToken("transaction_details." + var1 + ".status");

    }

    private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
    {
        //Set a name for the form
        string formID = "PostForm";
        //Build the form using the specified data to be posted.
        StringBuilder strForm = new StringBuilder();
        strForm.Append("<form id=\"" + formID + "\" name=\"" +
                       formID + "\" action=\"" + url +
                       "\" method=\"POST\">");

        foreach (System.Collections.DictionaryEntry key in data)
        {

            strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                           "\" value=\"" + key.Value + "\">");
        }


        strForm.Append("</form>");
        //Build the JavaScript which will do the Posting operation.
        StringBuilder strScript = new StringBuilder();
        strScript.Append("<script language='javascript'>");
        strScript.Append("var v" + formID + " = document." +
                         formID + ";");
        strScript.Append("v" + formID + ".submit();");
        strScript.Append("</script>");
        //Return the form and the script concatenated.
        //(The order is important, Form then JavaScript)
        return strForm.ToString() + strScript.ToString();
    }




    protected void btnPay3_Click(object sender, EventArgs e)
    {
        key.Value = ConfigurationManager.AppSettings["MERCHANT_KEY"];

        if (!IsPostBack)
        {
            frmError.Visible = false; // error form
        }
        else
        {
            //frmError.Visible = true;
        }
        if (string.IsNullOrEmpty(Request.Form["hash"]))
        {
            submit.Visible = true;
        }
        else
        {
            submit.Visible = false;
        }
        
        goPay();
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        goPay();
    }

    protected void btnEnrollNow3_Click(object sender, EventArgs e)
    {
        goPay();
    }
}