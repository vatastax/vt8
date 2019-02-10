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

public partial class Presentation_TDS_Staff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grd_Staff_TDS";
        VGrid1.DataBind();
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);

        dny_BOBtn.btn_buttonClick += new EventHandler(dny_BOBtn_btn_buttonClick);

    }

    protected void btn11_Click(object sender, EventArgs e)
    {
        
    }
    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    void dny_BOBtn_btn_buttonClick(object sender, EventArgs e)
    {
        hdn1.Value = "";
        if (Session["GridData"] != null)
        {
            //hdn1.Value = "1";
            DataTable dt = new DataTable();
            dt = (DataTable)Session["GridData"];
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                common objcommon = new common();
                
                objcommon.updateTDSClient_Returns_Status(Convert.ToInt64(dt.Rows[i]["ID"]), dt.Rows[i]["Remarks"].ToString());
                if (dt.Rows[i]["Remarks"].ToString() == "Short Payment")
                {
                    hdnID.Value = dt.Rows[i]["ID"].ToString();
                    hdn1.Value = "Short Payment";
                    //hdn1.Value = "A Link has been sent to this Client regarding making the balance payment";
                }
                else if (dt.Rows[i]["Remarks"].ToString() == "Uploaded")
                {
                    Session["Job_ID"] = dt.Rows[i]["Job_ID"];
                    hdnID.Value = dt.Rows[i]["ID"].ToString();
                    hdn1.Value = "Uploaded";
                }
                else if (dt.Rows[i]["Remarks"].ToString() == "Error")
                {
                    hdnID.Value = dt.Rows[i]["ID"].ToString();
                    hdn1.Value = "Error";
                }
                else if (dt.Rows[i]["Remarks"].ToString() == "Pending")
                {

                }
                else
                {
                    if (hdn1.Value == "1")
                        hdn1.Value = "";
                }
            }
        }
        //ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript>alert('clicked');</script>");    
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