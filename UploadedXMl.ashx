<%@ WebHandler Language="C#" Class="UploadedXMl" %>

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

public class UploadedXMl : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (context.Request.Files.Count > 0)
        {
            HttpFileCollection SelectedFiles = context.Request.Files;
            for (int i = 0; i < SelectedFiles.Count; i++)
            {
                HttpPostedFile PostedFile = SelectedFiles[i];
                string FileName = context.Server.MapPath("../xmlUpload/" + PostedFile.FileName);
                PostedFile.SaveAs(FileName);
            }
        }

        else
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Please Select Files");
        }

        context.Response.ContentType = "text/plain";
        context.Response.Write("Files Uploaded Successfully!!");
      
        //string PAN = "";
        //bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        ////Session["AY"] = txtAY.Text;
        //string ITR = "";
        //string strXML = File.ReadAllText((Server.MapPath("../xmlUpload/") + fup1.FileName).ToString());
        //if (strXML.Contains("Form_ITR1"))
        //{
        //    Session["ITR"] = "1";
        //    ITR = "1";
        //}
        //else
        //{
        //    Session["ITR"] = "8";
        //    ITR = "4s";
        //}
        //string[] arrAY = System.Text.RegularExpressions.Regex.Split(strXML, "</ITRForm:AssessmentYear>");
        //strXML = arrAY[0].Substring(arrAY[0].Length - 4);
        //Session["AY"] = strXML + "-" + (Convert.ToInt32(strXML) + 1).ToString();


        //objbllStoreTrans.resXML(Session["UserName"].ToString(), Session["AY"].ToString(), (Server.MapPath("../xmlUpload/") + fup1.FileName).ToString(), out PAN, ITR);
        //bllAssessee objbllAssessee = new bllAssessee();
        //denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
        //objAssesseeIndividual = objbllAssessee.GetDataIndividual(PAN);
        //Session["NameID"] = objAssesseeIndividual.NameID;
        //Session["restore"] = "true";
        //Session["PAN"] = PAN;


        //denMain objMainDEN = new denMain();
        //bllMain objMainBLL = new bllMain();

        //objMainDEN = objMainBLL.GetDueDate(Convert.ToString(Session["AY"]), 0, 0);
        //string[] arrDate = System.Text.RegularExpressions.Regex.Split(objMainDEN.DueDate, "/");

        //DateTime dtime = new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]));
        //// DateTime dtime = Convert.ToDateTime("21/02/2009", new CultureInfo("en-US", true));
        ////dtime.Month+"/"+dtime.Day+"/"+dtime.Year
        //Session["ITR"] = "1";
        //Session["ay"] = Session["AY"];
        //Session["duedate"] = objMainDEN.DueDate;


        //Response.Redirect("DisplayForm.aspx");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}