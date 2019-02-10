using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataAccess;
using Taxation.DataEntity;
using System.IO;
using System.Web.Services;
using BALVatasETDS.UserGroupManagement;
using System.Configuration;
using System.Data;
using Ionic.Zip;
using System.Net;

public partial class Presentation_XMLRestore : System.Web.UI.Page
{
    bllStoreTrans objbllStoreTrans = new bllStoreTrans();
    xmlFunctions objxmlFunction = new xmlFunctions();
    static bool IsPB = false;
    string strXMLData = ""; 
    string strXMLData_Extra = "";
    int IsValid = 0;
    static int StateID = 26;
    static DataTable dtErr = new DataTable();
    common objcommon = new common();
    static string FilePath = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        FilePath = objcommon.getDirectoryPath();
        ltTitleSub.Text = "";
        ////divErr.Visible = false;
        if (!IsPostBack)
        {
            dtErr.Rows.Clear();            
            bllDocTrans objbllDocTrans = new bllDocTrans();
            StateID = objbllDocTrans.getState(Session["NameID"].ToString());
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
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)        
        Session["xmlRestore"] = "set";
        Session["Main"] = "set";
        hdnNameID.Value = Session["NameID"].ToString();

        //for managing window close from top:
        if (Request.UrlReferrer != null)
        {
            if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                Session["xmlres"] = null;
            else
                Session["xmlres"] = "set";
        }
        else
            Session["xmlres"] = "set";

        if (Session["project"].ToString() == "vt")
        {
            Page.Title = "The Interactive Platform for free e-filing Income Tax Returns in India";
        }
        else if (Session["project"].ToString() == "tds")
        {
            Page.Title = "Tax Deducted At Souce";
            IsPB = true;
        }
        else if (Session["project"].ToString() == "stax")
        {
            Page.Title = "Generate XML - Service Tax";
        }

        if (hdnRestore.Value != "")
        {
            //restoreXML();
            hdnRestore.Value = "";
        }
        if (Request.QueryString["mode"] != null)
        {
            if (Request.QueryString["mode"].ToString() == "res")
            {
                pnlRestore.Visible = true;
                pnlGen.Visible = false;
                string message = "Popup on page load";
                ltTitle.Text = "Import XML";
                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                //pnlRestore.Visible = false;
            }
            else if (Request.QueryString["mode"].ToString() == "sub")
            {
                ltTitle.Text = "ITR Submission";
                pnlRestore.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('COMING SOON!!');", true);
            }
            else
            {
                pnlRestore.Visible = false;
                pnlGen.Visible = true;
            }
        }
        else
        {
            bllITR objbllITR = new bllITR();
            denITR objdenITR = new denITR();
            if (!IsPB)
            {
                IsPB = true;
                objdenITR = objbllITR.getITRData(Convert.ToInt64(Session["NameID"]), Session["AY"].ToString(), Session["ITR"].ToString());
                if (objdenITR.NameID != 0)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>IsConfirm();</script>");
                }
            }
            if (Session["Path_Excel"] != null)
            {
                FileStream fs = new FileStream(Session["Path_Excel"].ToString(), FileMode.Open, FileAccess.Read);
                byte[] ar = new byte[(int)fs.Length];
                fs.Read(ar, 0, (int)fs.Length);
                fs.Close();
                string Extension = Path.GetExtension(Session["Path_Excel"].ToString());
                string type = string.Empty;

               
                if (Extension.ToLower() == ".xls")
                {
                    type = "application/msexcel";
                }
                else if (Extension.ToLower() == ".xlsx")
                {
                    type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                Response.AddHeader("content-disposition", "attachment;filename=" + Session["TAN"].ToString() + ".xlsx");
                Response.ContentType = type;
                Response.BinaryWrite(ar);
                Session["Path_Excel"] = null;
                Response.End();
            } 
            if (Session["CreateFile"] != null)
            {
                FileStream fs = new FileStream(Session["CreateFile"].ToString(), FileMode.Open, FileAccess.Read);
                byte[] ar = new byte[(int)fs.Length];
                fs.Read(ar, 0, (int)fs.Length);
                fs.Close();
                if(Session["Regular_Correction"]=="Regular")
                    Response.AddHeader("content-disposition", "attachment;filename=\"" + Session["TAN"].ToString() + "\".txt");
                else if(Session["Regular_Correction"]=="Correction")
                    Response.AddHeader("content-disposition", "attachment;filename=\"" + Session["TAN"].ToString() + "\"_Correction.txt");
                Response.ContentType = "application/octectstream";
                Response.BinaryWrite(ar);

                Session["CreateFile"] = null;
                Response.End();
            }
            if (hdnNewXML.Value == "1" || objdenITR.NameID == 0 || Request.QueryString.Count==0)
            {
                balXML objbalxml = new balXML();
                try
                {
                    hdnNewXML.Value = "1";
                    
                    string strITR = "";
                    //bllStoreTrans objbllStoreTrans = new bllStoreTrans();
                    objbllStoreTrans.setEligibleDeductions(Session["NameID"].ToString(), Session["AY"].ToString(), Session["NameID"].ToString(), Session["ITR"].ToString());
                    calcTax();
                    bllSalary objbllSalary = new bllSalary();
                    //objbllSalary.AddLeftOvers(Session["NameID"].ToString(), Session["ay"].ToString());
                    if (Session["Project"].ToString() == "vt")
                    {
                        if (Session["ITR"].ToString() == "1" || Session["ITR"].ToString() == "8" || Session["ITR"].ToString() == "4" || Session["ITR"].ToString() == "9")
                        {
                            pnlRestore.Visible = false;
                            ltTitleSub.Text = "XML Generation";
                            
                            if (Session["ITR"].ToString() == "1")
                                strITR = "ITR-1";
                            else if (Session["ITR"].ToString() == "8")
                                strITR = "ITR-4S";
                            else if (Session["ITR"].ToString() == "9")
                                strITR = "ITR-2A";

                            //if (Session["ITR"].ToString() == "1")
                                string FilePath_tmp = FilePath.Substring(0,64) + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml";//    FilePath = (Server.MapPath("../xml/") + Session["AY"].ToString() + "/" + Session["NameID"].ToString() + "_1.xml");
                            //else if (Session["ITR"].ToString() == "8")
                            //    FilePath = FilePath + "/" + Session["AY"].ToString() + "/" + Session["NameID"].ToString() + "_4s.xml");
                            //else if (Session["ITR"].ToString() == "9")
                            //    FilePath = (Server.MapPath("../xml/") + Session["AY"].ToString() + "/" + Session["NameID"].ToString() + "_2A.xml");
                            //else
                            //    FilePath = (Server.MapPath("../xml/") + Session["AY"].ToString() + "/" + Session["NameID"].ToString() + "_4.xml");
                                File.WriteAllText(FilePath_tmp, "");
                                objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath_tmp, Session["ITR"].ToString(), Session["duedate"].ToString(), "-", Session["ReturnType"].ToString().Substring(0, 1), out strXMLData, out strXMLData_Extra);
                            //if (Session["AY"].ToString() == "2015-2016" || Session["AY"].ToString() == "2014-2015")
                            //{
                                string strhashCode = "";
                                strXMLData = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>" + strXMLData;  //(adding fisst row)
                                File.WriteAllText(FilePath_tmp, strXMLData);
                                if (Session["AY"].ToString() == "2015-2016")
                                {
                                    strhashCode = Convert.ToString(objbalxml.ExecuteCommandSync("java -jar C:/jhash/HashGen2.jar " + FilePath_tmp));
                                    strhashCode = strhashCode.Trim();
                                    strXMLData = strXMLData.Replace("<ITRForm:Digest>-</ITRForm:Digest>", "<ITRForm:Digest>" + strhashCode + "</ITRForm:Digest>");
                                }
                                else if (Session["AY"].ToString() == "2016-2017")
                                {
                                    strhashCode = Convert.ToString(objbalxml.ExecuteCommandSync("java -jar C:/jhash/Hash5.jar " + FilePath_tmp));
                                    strhashCode = strhashCode.Trim();
                                    strXMLData = strXMLData.Replace("<ITRForm:Digest>-</ITRForm:Digest>", "<ITRForm:Digest>" + strhashCode + "</ITRForm:Digest>");
                                }
                                
                                dtErr = objbllStoreTrans.SelectRequired(Session["NameID"].ToString(), Session["ITR"].ToString());
                                if (dtErr.Rows.Count > 0)
                                {
                                    ltTitleSub.Text = "Please rectify following <span style='color:Red; font-weight:Bold;'>Errors</span> before you proceed:";
                                    gvError.DataSource = dtErr;
                                    gvError.DataBind();
                                }
                                else
                                {
                                    //commenting the below line for now to stop validation for now:
                                    objbllStoreTrans.validateXML(strXMLData, Session["AY"].ToString(), 1, Session["NameID"].ToString(), Session["ITR"].ToString(), Session["ReturnType"].ToString(), "0", strXMLData_Extra, out IsValid);
                                }
                                //IsValid = 1;    //temp to ignore validation of xml for now (by ankush on 16-4-16)
                                if (File.Exists(FilePath_tmp))
                                    File.Delete(FilePath_tmp);
                            //}
                        }
                        //else
                        //{
                        //    FilePath = (Server.MapPath("../xml/") + Session["AY"].ToString() + "/" + Session["NameID"].ToString() + "_4s.xml");
                        //    File.WriteAllText(FilePath, "");
                        //    objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, "8", Session["duedate"].ToString(), "", Session["ReturnType"].ToString().Substring(0, 1), out strXMLData);
                        //    strXMLData = objbllStoreTrans.getXMLData(Session["NameID"].ToString(), Session["AY"].ToString(), "8");
                        //    strXMLData = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>" + strXMLData;
                        //    if (Session["AY"].ToString() == "2015-2016")
                        //    {
                        //        string strhashCode = "";
                        //        if (File.Exists(FilePath))
                        //            File.Delete(FilePath);
                        //        strhashCode = Convert.ToString(objxmlFunction.Base64_HMACSHA256(1832, strXMLData, "Cq9slulKbOyQyeM"));

                        //        objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, "8", Session["duedate"].ToString(), strhashCode, Session["ReturnType"].ToString().Substring(0, 1), out strXMLData);
                        //        strXMLData = objbllStoreTrans.getXMLData(Session["NameID"].ToString(), Session["AY"].ToString(), "8");
                        //        strXMLData = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>" + strXMLData;
                        //    }
                        //}
                    }
                    else if (Session["Project"].ToString() == "stax")
                    {
                        //FilePath = (Server.MapPath("../xml/") + Session["AY"].ToString() + "/" + Session["NameID"].ToString() + "stax.xml");
                        FilePath = FilePath + "/" + Session["AY"].ToString() + "/" + Session["NameID"].ToString() + "stax.xml";
                        File.WriteAllText(FilePath, "");
                        objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, "3", Session["duedate"].ToString(), "", Session["ReturnType"].ToString().Substring(0, 1), out strXMLData, out strXMLData_Extra);
                        strXMLData = objbllStoreTrans.getXMLData(Session["NameID"].ToString(), Session["AY"].ToString(), "3");
                        strXMLData = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>" + strXMLData;
                    }                   
                    if (Request.QueryString["mod"] != null)
                    {
                        if (dtErr.Rows.Count < 1)
                        {
                            //Uploading XML File to Assessee Folder
                            string path = FilePath;
                            if (IsValid == 1)
                            {
                                //File.WriteAllText(FilePath, strXMLData);

                                //FileStream fs2 = new FileStream(path, FileMode.Open, FileAccess.Read);
                                //byte[] ar = new byte[(int)fs2.Length];
                                //fs2.Read(ar, 0, (int)fs2.Length);
                                //fs2.Close();

                                ////Response.AddHeader("content-disposition", "attachment;filename=\"" + Session["NameID"].ToString() + "\".xml");
                                //Response.AddHeader("content-disposition", "attachment;filename=\"" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
                                //Response.ContentType = "application/octectstream";
                                //Response.BinaryWrite(ar);
                                //Response.End();

                                string FilePath_Upload_Dir = Server.MapPath("~/Upload/") + DateTime.Now.ToString("dd-MM-yyyy");
                                string FilePath_Upload = "";// Server.MapPath("~/Upload/") + DateTime.Now.ToString("dd-MM-yyyy");
                                //FilePath_Upload = objcommon.getDirectoryPath();
                                FilePath_Upload = FilePath;// +".zip";
                                //if (!Directory.Exists(FilePath_Upload))
                                //    Directory.CreateDirectory(FilePath_Upload);
                                if (!Directory.Exists(FilePath_Upload_Dir))
                                    Directory.CreateDirectory(FilePath_Upload_Dir);

                                //if (File.Exists(FilePath_Upload + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml"))
                                //    File.Delete(FilePath_Upload + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");

                                //File.Create(FilePath_Upload + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
                                //FileStream fs = File.OpenWrite(FilePath_Upload + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
                               // File.Open(FilePath_Upload + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml", FileMode.Append);

                                File.WriteAllText(FilePath_Upload_Dir + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml", strXMLData);

                                //using (ZipFile zip = new ZipFile())
                                //{
                                //    zip.AddFile(FilePath_Upload_Dir + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
                                //    zip.Save(FilePath_Upload + ".zip");
                                //}
                                using (var zip = ZipFile.Read(FilePath_Upload + ".zip"))
                                {
                                    string FNam = Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml";
                                    if (!zip.Any(entry => entry.FileName.EndsWith(FNam)))
                                    {
                                        zip.AddFile(FilePath_Upload_Dir + "/" + FNam, "");
                                        zip.Save();
                                    }
                                }
                                //File.WriteAllText(FilePath_Upload + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml", strXMLData);
                            }
                            string strDOB = "";
                            //bllStoreTrans objbllStoreTrans = new bllStoreTrans();
                            strDOB = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "6");

                            //divErr.Visible = true;
                            ltTitle.Text = "ITR Submission";
                            pnlRestore.Visible = false;
                            ltTitleSub.Text = "ITR Submitted Successfully!!";
                            ltTitleSub.Text = @"<b>""Your return has been submitted successfully. Check your email 24 hours after submitting your income tax return""</b>";
                            ltTitleSub.Text += @"<div style='text-align:justify;'><br><br>The Income Tax Department will send you acknowledgment to the address you provided in return. Your acknowledgment will protected by a password. Please enter your PAN (in small letters) and Date of Birth (in ddmmyyyy format), in combination, to view your acknowledgment (Eg: If your pan is " + Session["PAN"].ToString() + @" and the date of birth is " + strDOB + @", then the password will be " + Session["PAN"].ToString().ToLower() + strDOB.Replace("/","")  + @").<br><br>
                                            Please take a print out and send the signed copy by speed/ordinary post within 120 days to the following address:-<br><br>
                                            Income Tax Department – CPC,<br>
                                            Post Box No. – 1,<br>
                                            Electronic City Post Office,<br>
                                            Bengalore – 560100,<br>
                                            Karnataka.<br>

                            </div>";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('ITR Submitted Successfully!!');", true);
                            objbalxml.Update_Status(Session["ITRXML_ID"].ToString(), 1);
                            if (Session["UserRole"] != null)
                            {
                                if (Session["UserRole"].ToString() == "Supervisor")
                                {
                                    objcommon.startProcessHistoryJob(Convert.ToInt64(Session["Job_ID"]), Convert.ToInt64(Session["user_ID"]), "Completed", "Y");
                                }
                            }
                        }
                        //else
                        //{
                        //    dtErr = objbalxml.GetValidationErrors(Session["NameID"].ToString(), Session["Ay"].ToString(), Session["ITR"].ToString());
                        //    ltTitleSub.Text = "Please rectify following <span style='color:Red; font-weight:Bold;'>Errors</span> before you proceed:";
                        //    gvError.DataSource = dtErr;
                        //    gvError.DataBind();
                        //}
                    }
                    else if(dtErr.Rows.Count<1)
                    {
                        string path = Server.MapPath("~/xmlUpload/") + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml"; //FilePath;
                        if (IsValid == 1)
                        {
                            //File.WriteAllText(FilePath, strXMLData);
                            File.WriteAllText(path, strXMLData);
                            FileStream fs2 = new FileStream(path, FileMode.Open, FileAccess.Read);
                            byte[] ar = new byte[(int)fs2.Length];
                            fs2.Read(ar, 0, (int)fs2.Length);
                            fs2.Close();

                            //Response.AddHeader("content-disposition", "attachment;filename=\"" + Session["NameID"].ToString() + "\".xml");
                            Response.AddHeader("content-disposition", "attachment;filename=\"" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
                            Response.ContentType = "application/octectstream";
                            Response.BinaryWrite(ar);
                            Response.End();

                            objbalxml.DeleteErrors(Session["NameID"].ToString());
                        }
                        else
                        {
                            dtErr = objbalxml.GetValidationErrors(Session["NameID"].ToString(), Session["Ay"].ToString(), Session["ITR"].ToString());
                            ltTitleSub.Text = "Please rectify following <span style='color:Red; font-weight:Bold;'>Errors</span> before you proceed:";
                            gvError.DataSource = dtErr;
                            gvError.DataBind();
                        }
                    }

                    //objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xml/") + Session["NameID"].ToString() + "_4s.xml"), "4s");


                    //Response.Write(Server.MapPath("../xml/") + Session["NameID"].ToString() + ".xml");

                    //Response.ContentType = "Application/xml";

                    ////Write the file directly to the HTTP content output stream.
                    //Response.WriteFile(FilePath);
                    //Response.End();


                    //for file: (commented on 22-6-15)

                    //FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    //byte[] ar = new byte[(int)fs.Length];
                    //fs.Read(ar, 0, (int)fs.Length);
                    //fs.Close();

                    //Response.AddHeader("content-disposition", "attachment;filename=" + FilePath);
                    //Response.ContentType = "application/octectstream";
                    //Response.BinaryWrite(ar);
                    //Response.End();
                    if (IsValid == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('File Downloaded Sucessfully');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('XML Cannot be Generetaed Please Check Your Data');", true);
                    }
                }
                catch (Exception ex)
                {
                    //divErr.Visible = false;
                    dtErr = objbalxml.GetValidationErrors(Session["NameID"].ToString(), Session["Ay"].ToString(), Session["ITR"].ToString());
                    ltTitleSub.Text = "Please rectify following <span style='color:Red; font-weight:Bold;'>Errors</span> before you proceed:";
                    gvError.DataSource = dtErr;
                    gvError.DataBind();
                    if (dtErr.Rows.Count < 1)
                    {
                        AFinish.Visible = false;
                        //divErr.Visible = true;
                        ltTitleSub.Text = "<span style='font-weight:bold;'>Seems Like there is some unknown <span style='color:red;'>Error</span> in the script!!<br><center>Please Try Again Later!!!</center>";
                    }
                    //Error Log Code:
                    tbl_ErrorLog objtbl_ErrorLog = new tbl_ErrorLog();
                    objtbl_ErrorLog.className = "xmlrestore_catch";
                    objtbl_ErrorLog.ErrDateTime = DateTime.Now;
                    objtbl_ErrorLog.ErrorMsg = ex.Message;
                    objtbl_ErrorLog.methodName = "xmlrestore";
                    objtbl_ErrorLog.pageName = "xmlrestore";
                    objcommon.addError(objtbl_ErrorLog);
                    //throw ex;
                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('XML Cannot be Generetaed Please Check Your Data.');", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('XML Not Generated Due to some Technical Issues');", true);
                }
            }
        }
        if (dtErr.Rows.Count < 1)
            AFinish.Visible = true;
        else
            AFinish.Visible = false;
    }

    protected void gvError_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            Label lblSNO = new Label();
            lblSNO = (Label)e.Row.FindControl("lblSNO");
            lblSNO.Text = (e.Row.RowIndex + 1).ToString();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //restoreXML();

    }

    private void restoreXML()
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
        string xml = strXML;
        if (strXML.Contains("Form_ITR1"))
        {
            Session["ITR"] = "1";
            ITR = "1";
        }
        else
        {
            Session["ITR"] = "8";
            ITR = "8";
        }
        string[] arrAY = System.Text.RegularExpressions.Regex.Split(strXML, "</ITRForm:AssessmentYear>");
        strXML = arrAY[0].Substring(arrAY[0].Length - 4);
        Session["AY"] = strXML + "-" + (Convert.ToInt32(strXML) + 1).ToString();


        objbllStoreTrans.resXML(xml, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + fup1.FileName).ToString(), ITR, (Session["NameID"] == null) ? "0" : Session["NameID"].ToString(), out PAN, 1);
        bllAssessee objbllAssessee = new bllAssessee();
        denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
        objAssesseeIndividual = objbllAssessee.GetDataIndividual(PAN);
        Session["NameID"] = objAssesseeIndividual.NameID;
        Session["restore"] = "true";
        Session["PAN"] = PAN;


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


        Response.Redirect("DisplayForm.aspx");
    }

    public void calcTax()
    {
        bllSalary objbllSalary = new bllSalary();
        objbllSalary.SetAllZero(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.calTaxNew(Session["NameID"].ToString(), Session["ay"].ToString(), 49, (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString()), Convert.ToInt32(((Session["Project"].ToString() != "vtax") ? 0 : 1)));
    }

    [WebMethod]
    public static void AbandonSession()
    {
        Presentation_XMLRestore objPresentation_Main = new Presentation_XMLRestore();
        string ss = HttpContext.Current.Request.UrlReferrer.ToString();
        if (HttpContext.Current.Session["xmlres"] == null)
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
            HttpContext.Current.Session["xmlres"] = null;
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
    protected void lbtnEditProf_Click(object sender, EventArgs e)
    {
        //Session["Mode"] = "Edit";
        //Session["InternalSal"] = "true";
        //Response.Redirect("Salary.aspx?vtype=106");

        Session["Mode"] = "Edit";
        Session["InternalSal"] = "true";
        Session["IncomeTax_VType"] = "106";
        Response.Redirect("Profile");
    }
}
