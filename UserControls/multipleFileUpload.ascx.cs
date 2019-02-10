using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AjaxControlToolkit;
using System.IO;
using Ionic;
using System.Collections.Generic;
using Ionic.Zip;

public partial class User_Control_multipleFileUpload : System.Web.UI.UserControl
{
    public event MultipleFileUploadClick Click;
    public event EventHandler btn_close_click;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void btn_Save_Click(object sender, EventArgs e)
    //{
    //    // Fire the event.
    //    Click(this, new FileCollectionEventArgs(this.Request));
    //}</center>

    protected void File_Upload(object sender, AjaxFileUploadEventArgs e)
    {
        string destdir = string.Empty;
        string NewPath = string.Empty;
        using (var zip = new ZipFile())
        {
            zip.Encryption = EncryptionAlgorithm.WinZipAes256;
            string filename = e.FileName;
            if (Session["Path"] != null)
            {
                destdir = Session["Path"].ToString();
                NewPath = Server.MapPath("../Upload Files//" + filename);
            }
          //  string filenameWitoutextension = Path.GetFileNameWithoutExtension(filename);
        
            AsyncFileUpload1.SaveAs(destdir+"//"+filename);
            zip.AddDirectory(destdir);
            destdir = destdir + ".Zip";
            zip.Save(destdir);      
            //foreach (string f in files)
            //{
            //    System.IO.File.Delete(f);
            //}

        }
    
       
    }
    private static List<string> GenerateFileList(string Dir)
    {
        //list<string> fils = new list<string>();
        List<string> fils = new List<string>();
        bool Empty = true;
        foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
        {
            fils.Add(file);
            Empty = false;
        }

        if (Empty)
        {
            if (Directory.GetDirectories(Dir).Length == 0)
            // if directory is completely empty, add it
            {
                fils.Add(Dir + @"/");
            }
        }

        
        return fils; // return file list
    }

    //Click Event of Close button
    protected void btn_Close_Click(object sender, EventArgs e)
    {
        btn_close_click(sender, e);
    }
}

public class FileCollectionEventArgs : EventArgs
{
    private HttpRequest _HttpRequest;

    public HttpFileCollection PostedFiles
    {
        get
        {
            return _HttpRequest.Files;
        }
    }

    public int Count
    {
        get { return _HttpRequest.Files.Count; }
    }

    public bool HasFiles
    {
        get { return _HttpRequest.Files.Count > 0 ? true : false; }
    }

    public double TotalSize
    {
        get
        {
            double Size = 0D;
            for (int n = 0; n < _HttpRequest.Files.Count; ++n)
            {
                if (_HttpRequest.Files[n].ContentLength < 0)
                    continue;
                else
                    Size += _HttpRequest.Files[n].ContentLength;
            }

            return Math.Round(Size / 1024D, 2);
        }
    }

    public FileCollectionEventArgs(HttpRequest oHttpRequest)
    {
        _HttpRequest = oHttpRequest;
    }
}

//Delegate that represents the Click event signature for MultipleFileUpload control.
public delegate void MultipleFileUploadClick(object sender, FileCollectionEventArgs e);
