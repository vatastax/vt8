using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;
using System.IO;

public partial class UserControls_fileuploadDirCtrl_TDS : System.Web.UI.UserControl
{
    static string DirPath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.Url.ToString().Contains("Profile"))
        {
            string ss = FileUpload1.FileName;
            if (!IsPostBack)
            {
                common objcommon = new common();
                if (Session["Job_ID"] != null)
                    ViewState["File_Path"] = objcommon.getDirectoryPath_ByJobID();
                BindGridview();
            }
            if (gvDetails.Rows.Count > 0)
            {
                btn_CloseDownload.Visible = true;
                btn_Download.Visible = true;
            }
        }
    }

    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Pnl_MultipleUpload.Visible = false;
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        String FilenameCollections = null;
        // Get the HttpFileCollection
        HttpFileCollection hfc = Request.Files;
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {
                //hpf.SaveAs(Server.MapPath("~/Upload/") + Path.GetFileName(hpf.FileName));
                //string s= DirPath + "\\" + Path.GetFileName(hpf.FileName) + "_" + DateTime.Now.ToShortDateString().Replace("/","-") + "_" + DateTime.Now.ToShortTimeString().Replace("/","-").Replace(" ","");
                string Time = DateTime.Now.ToShortTimeString().Replace(" ", "").Replace(":", "");
                string FN = Path.GetFileName(hpf.FileName);
                string[] FNarr = Path.GetFileName(hpf.FileName).Split('.');
                FN = FNarr[0] + "_" + DateTime.Now.ToShortDateString().Replace("/", "-") + "_" + Time + "." + FNarr[1];
                hpf.SaveAs(ViewState["File_Path"].ToString() + "\\" + FN);
                FilenameCollections = FilenameCollections + Path.GetFileName(hpf.FileName) + "<br/>";
            }
        }
        lblSuccess.Text = string.Format("{0} files have been uploaded successfully.", hfc.Count);
        BindGridview();
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>openDialog();</script>");
    }

    protected void BindGridview()
    {
        try
        {
            string[] filesPath = null;
            if (ViewState["File_Path"] != null)
            {
                if (Directory.Exists(ViewState["File_Path"].ToString()))
                    filesPath = Directory.GetFiles(ViewState["File_Path"].ToString());
                else if (Directory.Exists(Server.MapPath("~/UserDocs/") + Session["User_ID"].ToString()))
                    filesPath = Directory.GetFiles(Session["Dir_Path"].ToString());
                    //filesPath = Directory.GetFiles(Server.MapPath("~/UserDocs/") + Session["User_ID"].ToString());
            }
            else if (Directory.Exists(Server.MapPath("~/UserDocs/") + Session["User_ID"].ToString()))
                filesPath = Directory.GetFiles(Session["Dir_Path"].ToString());     //filesPath = Directory.GetFiles(Server.MapPath("~/UserDocs/") + Session["User_ID"].ToString());  

            List<ListItem> files = new List<ListItem>();

            foreach (string path in filesPath)
            {
                files.Add(new ListItem(Path.GetFileName(path), File.GetCreationTime(path).ToLongDateString()));

            }
            gvDetails.DataSource = files;
            gvDetails.DataBind();

            int countrows = gvDetails.Rows.Count;
            if (countrows <= 0)
            {
                div_Grd_download_null.Visible = true;
            }
            else
            {
                btn_Download.Attributes.Remove("style");
            }
        }
        catch
        {
            gvDetails.DataSource = null;
            gvDetails.DataBind();
            div_Grd_download_null.Visible = true;
        }
        finally
        {
            //Pnl_Details_div.Visible = true;
            gvDetails.Visible = true;
            btn_CloseDownload.Attributes.Remove("style");
        }
    }

    protected void btn_Download_Click(object sender, EventArgs e)
    {
        string Path_File = ViewState["File_Path"].ToString();
        using (ZipFile zip = new ZipFile())
        {
            foreach (GridViewRow gvrow in gvDetails.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");
                if (chk.Checked)
                {
                    string fileName = gvrow.Cells[1].Text;
                    string filePath = Path_File + "//" + fileName;
                    zip.AddFile(filePath, "files");
                }
            }
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
            Response.ContentType = "application/zip";
            zip.Save(Response.OutputStream);
            Response.End();
        }
    }
    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

        int RowIndex = gvr.RowIndex;
        string Filename = gvDetails.Rows[RowIndex].Cells[1].Text;
        if (e.CommandName == "Download")//download file
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Filename);
            Response.TransmitFile(ViewState["File_Path"].ToString() + "//" + Filename);
            Response.End();
        }
        else if (e.CommandName == "xyz")
        {
            if (System.IO.File.Exists(ViewState["File_Path"].ToString() + "//" + Filename))
            {
                try
                {
                    System.IO.File.Delete(ViewState["File_Path"].ToString() + "//" + Filename);
                    BindGridview();
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>openDialog();</script>");
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        BindGridview();
    }
}