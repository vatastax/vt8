using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Taxation.BusinessLogic;

public partial class Presentation_frmBulkUpload : System.Web.UI.Page
{
    bllStoreTrans objbllStoreTrans = new bllStoreTrans();
    bllAssessee objbllAssessee = new bllAssessee();
    protected void Page_Load(object sender, EventArgs e)
    {
        BulkUpload();
    }
    public void BulkUpload()
    {
        try
        {
            int IsExists = 0;
            string PAN = "";
            Session["UserName"] = "xmlbulkupload@vatasinfotech.com.com";
            Session["AY"] = "2014-2015";
            Session["Project"] = "vt";
            string FilePath = @"E:\Mudit\XMLTest\";
            string Path1 = Server.MapPath("../xmlUpload/");
            //string FileName = Path.GetFileName(Path.GetDirectoryName(FilePath));
            string[] DirectoryName = Directory.GetDirectories(FilePath);
            for (int i = 0; i < DirectoryName.Length; i++)
            {
                FilePath = DirectoryName[i];
                string[] FileName = Directory.GetFiles(FilePath, "*.xml");

                if (FileName.Length > 0)
                {
                    for (int j = 0; j < FileName.Length; j++)
                    {
                        string Name = Path.GetFileName(FileName[j]);

                        File.Copy(FileName[j], Path1 + Name, true);
                        //Session["AY"] = txtAY.Text;
                        string ITR = "";
                        string strXML = File.ReadAllText((Server.MapPath("../xmlUpload/") + Name).ToString());
                        string[] arrPan = System.Text.RegularExpressions.Regex.Split(strXML, "</ITRForm:PAN>");
                        PAN = arrPan[0].Substring(arrPan[0].Length - 10);
                        string xml = strXML;
                        string IsEmlExists = objbllAssessee.IsPANExists(PAN);
                        string[] arr = System.Text.RegularExpressions.Regex.Split(IsEmlExists, "~");
                        IsExists = Convert.ToInt32(arr[0]);
                        string NameID = arr[1];
                        if (IsExists == 0)
                        {
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
                            objbllStoreTrans.resXML(xml, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + Name).ToString(), ITR, (Session["NameID"] == null) ? "0" : Session["NameID"].ToString(), out PAN, 1);
                            string DirectoryPath = DirectoryName[i]+"\\" + Name;
                            File.Delete(DirectoryPath);
                            
                        }
                        else
                        {
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
                            objbllStoreTrans.resXMLNoMasterUpdate(xml, Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + Name).ToString(), ITR, (Session["NameID"] == null) ? NameID : Session["NameID"].ToString(), out PAN, 1);
                            //File.Delete(Path1 + Name);
                        }
                    }
                }
                if (Directory.Exists(DirectoryName[i]))
                {
                    Directory.Delete(DirectoryName[i],true);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}