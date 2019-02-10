using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Taxation.BusinessLogic;
using System.IO;
using System.Data;

public partial class Presentation_SelectITRV : System.Web.UI.Page
{
    balXML objbalXML = new balXML();
    static bool IsErrors = false;
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            //string s = objbalXML.GetXML(Convert.ToInt64(Session["NameID"]), Session["ITR"].ToString(), Session["AY"].ToString());
            //string s = objbalXML.GetXML(1982163115, Session["ITR"].ToString(), Session["AY"].ToString());
            //GenerateXML();
            //if (!IsErrors)
            //{
            int IsValid = objbalXML.Get_IsValidated(Convert.ToInt64(Session["NameID"]), Session["ITR"].ToString(), Session["AY"].ToString());
            if (IsValid == 1)
            {
                string s = objbalXML.GetXML(Convert.ToInt64(Session["NameID"]), Session["ITR"].ToString(), Session["AY"].ToString());
                if (s.Length > 0)
                {
                    s = "<root>" + s + "</root>";
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(s);
                    // xdoc.Save(Server.MapPath("../" + Session["NameID"].ToString() + ".xml"));
                    //xdoc.Save(Server.MapPath("../1982163115" + ".xml"));
                    xdoc.Save(Server.MapPath("../GetXMLs/" + Session["NameID"].ToString() + "_" + Session["AY"].ToString() + ".xml"));
                    if (Session["ITR"].ToString() == "4")
                    {
                        //Response.Redirect("../VwRpt4only.aspx?itr=1982163115");
                        Response.Redirect("../VwRpt4only.aspx?nid=" + Session["NameID"].ToString());
                    }
                    else if (Session["ITR"].ToString() == "1")
                    {
                        if (Session["AY"].ToString() == "2014-2015")
                            Response.Redirect("../Reports/VwITRVforITR12014-15.aspx?nid=~/GetXMLs/" + Session["NameID"].ToString() + "_" + Session["AY"].ToString());
                        else if (Session["AY"].ToString() == "2015-2016")
                            Response.Redirect("../Reports/VwITRVforITR12015-16.aspx?nid=~/GetXMLs/" + Session["NameID"].ToString() + "_" + Session["AY"].ToString());
                        else if (Session["AY"].ToString() == "2016-2017")
                            Response.Redirect("../Reports/VwITRVforITR12016-17.aspx?nid=~/GetXMLs/" + Session["NameID"].ToString() + "_" + Session["AY"].ToString());

                    }
                    else if (Session["ITR"].ToString() == "8")
                    {
                        if (Session["AY"].ToString() == "2014-2015")
                            Response.Redirect("../Reports/VwITRVforITR4S2014-2015.aspx?nid=~/GetXMLs/" + Session["NameID"].ToString() + "_" + Session["AY"].ToString());
                        else if (Session["AY"].ToString() == "2015-2016")
                            Response.Redirect("../Reports/VwITRVforITR4S2015-2016.aspx?nid=~/GetXMLs/" + Session["NameID"].ToString() + "_" + Session["AY"].ToString());
                        else if (Session["AY"].ToString() == "2016-2017")
                            Response.Redirect("../Reports/VwITRVforITR4S2016-2017.aspx?nid=~/GetXMLs/" + Session["NameID"].ToString() + "_" + Session["AY"].ToString());

                    }

                }
                else
                {
                    lblMsg.Text = "No Records Found!!!!";

                }
                //}
            }
            else
            {
                divErrMsg.Visible = true;
            }
        }
    }

    public void calcTax()
    {
        bllSalary objbllSalary = new bllSalary();
        objbllSalary.SetAllZero(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.calTaxNew(Session["NameID"].ToString(), Session["ay"].ToString(), 49, (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString()), Convert.ToInt32(((Session["Project"].ToString() != "vtax") ? 0 : 1)));
    }

    public void GenerateXML()
    {
        DataTable dtErr = new DataTable();
        string strXMLData = "";
        string strXMLData_Extra = "";
        balXML objbalxml = new balXML();
        int IsValid = 0;
        common objcommon = new common();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        string FilePath = objcommon.getDirectoryPath();
        string strITR = "";
        //bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        objbllStoreTrans.setEligibleDeductions(Session["NameID"].ToString(), Session["AY"].ToString(), Session["NameID"].ToString(), Session["ITR"].ToString());
        calcTax();
        bllSalary objbllSalary = new bllSalary();
        if (Session["Project"].ToString() == "vt")
        {
            if (Session["ITR"].ToString() == "1" || Session["ITR"].ToString() == "8" || Session["ITR"].ToString() == "4" || Session["ITR"].ToString() == "9")
            {
                if (Session["ITR"].ToString() == "1")
                    strITR = "ITR-1";
                else if (Session["ITR"].ToString() == "8")
                    strITR = "ITR-4S";
                else if (Session["ITR"].ToString() == "9")
                    strITR = "ITR-2A";

                FilePath = FilePath + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml";//    FilePath = (Server.MapPath("../xml/") + Session["AY"].ToString() + "/" + Session["NameID"].ToString() + "_1.xml");                
                File.WriteAllText(FilePath, "");

                objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, Session["ITR"].ToString(), Session["duedate"].ToString(), "-", Session["ReturnType"].ToString().Substring(0, 1), out strXMLData, out strXMLData_Extra);

                string strhashCode = "";
                strXMLData = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>" + strXMLData;  //(adding fisst row)
                File.WriteAllText(FilePath, strXMLData);
                if (Session["AY"].ToString() == "2015-2016")
                {
                    strhashCode = Convert.ToString(objbalxml.ExecuteCommandSync("java -jar C:/jhash/HashGen2.jar " + FilePath));
                    strhashCode = strhashCode.Trim();
                    strXMLData = strXMLData.Replace("<ITRForm:Digest>-</ITRForm:Digest>", "<ITRForm:Digest>" + strhashCode + "</ITRForm:Digest>");
                }
                else if (Session["AY"].ToString() == "2016-2017")
                {
                    strhashCode = Convert.ToString(objbalxml.ExecuteCommandSync("java -jar C:/jhash/Hash5.jar " + FilePath));
                    strhashCode = strhashCode.Trim();
                    strXMLData = strXMLData.Replace("<ITRForm:Digest>-</ITRForm:Digest>", "<ITRForm:Digest>" + strhashCode + "</ITRForm:Digest>");
                }

                dtErr = objbllStoreTrans.SelectRequired(Session["NameID"].ToString(), Session["ITR"].ToString());
                if (dtErr.Rows.Count > 0)
                {
                    IsErrors = true;
                    ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('There are Errors in the Data');</script>");
                }
                else
                {
                    //commenting the below line for now to stop validation for now:
                    objbllStoreTrans.validateXML(strXMLData, Session["AY"].ToString(), 1, Session["NameID"].ToString(), Session["ITR"].ToString(), Session["ReturnType"].ToString(), "0", strXMLData_Extra, out IsValid);
                }
                if (File.Exists(FilePath))
                    File.Delete(FilePath);
            }

            if (dtErr.Rows.Count < 1)
            {
                //string path = FilePath;
                //if (IsValid == 1)
                //{
                //    File.WriteAllText(FilePath, strXMLData);

                //    FileStream fs2 = new FileStream(path, FileMode.Open, FileAccess.Read);
                //    byte[] ar = new byte[(int)fs2.Length];
                //    fs2.Read(ar, 0, (int)fs2.Length);
                //    fs2.Close();

                //    //Response.AddHeader("content-disposition", "attachment;filename=\"" + Session["NameID"].ToString() + "\".xml");
                //    Response.AddHeader("content-disposition", "attachment;filename=\"" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
                //    Response.ContentType = "application/octectstream";
                //    Response.BinaryWrite(ar);
                //    Response.End();

                objbalxml.DeleteErrors(Session["NameID"].ToString());
            }
            else
            {
                IsErrors = true;
                dtErr = objbalxml.GetValidationErrors(Session["NameID"].ToString(), Session["Ay"].ToString(), Session["ITR"].ToString());
                if (dtErr.Rows.Count > 0)
                    ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>alert('There are Errors in the Data');</script>");
            }
        }
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("salary.aspx?vtype=40");
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignatoryDetails.aspx?gen=true");
    }
    
}