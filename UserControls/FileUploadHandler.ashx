<%@ WebHandler Language="C#" Class="FileUploadHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using Ionic.Zip;
using System.Net;

public class FileUploadHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    static string DirPath = "";
    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Files.Count > 0)
        {
            common objcommon = new common();
            if (HttpContext.Current.Session["Project"].ToString() == "vt")
                DirPath = objcommon.getDirectoryPath();
            else if (HttpContext.Current.Session["Project"].ToString() == "tds" || HttpContext.Current.Session["Project"].ToString() == "tds2")
                DirPath = objcommon.getDirectoryPath_ByJobID();

            HttpFileCollection files = context.Request.Files;
            String FilenameCollections = null;

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                // string fname = context.Server.MapPath("~/uploads/" + file.FileName);
                // file.SaveAs(fname);

                if (file.ContentLength > 0)
                {
                    //hpf.SaveAs(Server.MapPath("~/Upload/") + Path.GetFileName(hpf.FileName));
                    //string s= DirPath + "\\" + Path.GetFileName(hpf.FileName) + "_" + DateTime.Now.ToShortDateString().Replace("/","-") + "_" + DateTime.Now.ToShortTimeString().Replace("/","-").Replace(" ","");
                    string Time = DateTime.Now.ToShortTimeString().Replace(" ", "").Replace(":", "");
                    string FN = Path.GetFileName(file.FileName);
                    string[] FNarr = Path.GetFileName(file.FileName).Split('.');
                    FN = FNarr[0] + "_" + DateTime.Now.ToShortDateString().Replace("/", "-") + "_" + Time + "." + FNarr[1];
                    if (HttpContext.Current.Session["Project"].ToString() == "tds")
                        file.SaveAs(DirPath + "\\" + FN);
                    if (HttpContext.Current.Session["Project"].ToString() == "tds2")
                        file.SaveAs(DirPath + FN);
                    else
                    {
                        string FilePath_tmp = "";
                        if (DirPath.Length > 64)
                            FilePath_tmp = DirPath.Substring(0, 64) + "/" + FN;
                        else
                            FilePath_tmp = DirPath + FN;

                        //file.SaveAs(DirPath + "\\" + FN);
                        file.SaveAs(FilePath_tmp);
                        //using (ZipFile zip = new ZipFile())
                        //{
                        //    //zip.AddFile(FilePath_Upload_Dir + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
                        //    //zip.AddFile(FilePath_tmp, DirPath + ".zip");
                        //    //zip.AddItem(FilePath_tmp);
                        //    //zip.UpdateFile(FilePath_tmp);
                        //    //zip.UpdateDirectory(
                        //    zip.AddEntry(
                        //    zip.Save(DirPath + ".zip");
                        //}
                        using (var zip = ZipFile.Read(DirPath + ".zip"))
                        {
                            //zip.AddFile(FilePath_tmp, FN);
                            zip.AddFile(FilePath_tmp, "");
                            zip.Save();
                        }
                        File.Delete(FilePath_tmp);
                    }
                    //FilenameCollections = FilenameCollections + Path.GetFileName(file.FileName) + "<br/>";
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("File Uploaded Successfully!");
            //BindGridview();
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}