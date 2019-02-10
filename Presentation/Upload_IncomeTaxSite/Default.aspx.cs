using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataEntity;
using System.Data;
using System.IO;
using Ionic.Zip;
using System.Collections;

public partial class Presentation_Upload_IncomeTaxSite_Default : System.Web.UI.Page
{
    string Org = "5";
    static string ITRXML_ID = "";
    static int StateID = 26;

    protected void Page_Load(object sender, EventArgs e)
    {
        balAdmin objbalAdmin = new balAdmin();
        tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
        objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(Session["user_ID"]));
        Org = objtbl_UserRegistration.OrganizationName;
        BindNewGrid();
    }
    public void BindNewGrid()
    {
        VGrid1.CustomConnection = "Data Source=Dev1;Initial Catalog=ControlGrid;User Id=sa; Password=sql,.12345";
        VGrid1.GridName = "grdITRXML_Super";
        VGrid1.Parameters = "1";
        VGrid1.DataBind();
        VGrid1.AlternatingRowStyle = "bgo";
        VGrid1.VGrid_RowCommand += new EventHandler(VGrid1_VGrid_RowCommand);
        VGrid1.VGrid_SelectedIndexChanged += new EventHandler(VGrid1_VGrid_SelectedIndexChanged);
    }

    void VGrid1_VGrid_RowCommand(object sender, EventArgs e)
    {
        //GridControl.VGrid vg1 = (GridControl.VGrid)sender;       
    }

    void VGrid1_VGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.SelectedRow;
        string ss = dtGrid.Rows[0][2].ToString();
        ITRXML_ID = dtGrid.Rows[0][0].ToString();
        string fileName = dtGrid.Rows[0][6].ToString() + ".zip";
        string ITR = dtGrid.Rows[0][4].ToString();
        string PAN = dtGrid.Rows[0][1].ToString();
        string AY = dtGrid.Rows[0][3].ToString();
        string Dir_Path = dtGrid.Rows[0][6].ToString();

        string strITR = "";
        if (ITR == "1")
            strITR = "ITR-1";
        else if (ITR == "8")
            strITR = "ITR-4S";
        else if (ITR == "9")
            strITR = "ITR-2A";

        string FNam = PAN + "_" + strITR + "_" + (AY.Substring(0, 4)) + "_N_" + PAN.Substring(5, 4) + ".xml";
        //Dir_Path.Substring(0, 64)
        ArrayList arrLst = new ArrayList();
        using (ZipFile zip = new ZipFile())
        {
            ZipFile zippy = ZipFile.Read(fileName);
            foreach (ZipEntry zips in zippy)
            {
                if (zips.FileName == FNam)
                    zips.Extract(fileName.Substring(0, 64), ExtractExistingFileAction.OverwriteSilently);
            }

            zip.AddFile(fileName.Substring(0, 64) + FNam, "files");
            arrLst.Add(fileName.Substring(0, 64) + FNam);

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
            Response.ContentType = "application/zip";
            zip.Save(Response.OutputStream);
            for (int i = 0; i < arrLst.Count; i++)
            {
                File.Delete(arrLst[i].ToString());
            }
            Response.End();
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        DataTable dtGrid = new DataTable();
        dtGrid = VGrid1.GridCheckedRows();
        ArrayList arrLst = new ArrayList();


        using (ZipFile zip = new ZipFile())
        {
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                string ss = dtGrid.Rows[i][2].ToString();
                ITRXML_ID = dtGrid.Rows[i][0].ToString();
                string fileName = dtGrid.Rows[i][6].ToString() + ".zip";
                string ITR = dtGrid.Rows[i][4].ToString();
                string PAN = dtGrid.Rows[i][1].ToString();
                string AY = dtGrid.Rows[i][3].ToString();
                string Dir_Path = dtGrid.Rows[i][6].ToString();

                string strITR = "";
                if (ITR == "1")
                    strITR = "ITR-1";
                else if (ITR == "8")
                    strITR = "ITR-4S";
                else if (ITR == "9")
                    strITR = "ITR-2A";

                string FNam = PAN + "_" + strITR + "_" + (AY.Substring(0, 4)) + "_N_" + PAN.Substring(5, 4) + ".xml";
                ZipFile zippy = ZipFile.Read(fileName);
                foreach (ZipEntry zips in zippy)
                {
                    if (zips.FileName == FNam)
                        zips.Extract(fileName.Substring(0, 64), ExtractExistingFileAction.OverwriteSilently);
                }

                zip.AddFile(fileName.Substring(0, 64) + FNam, "files");
                arrLst.Add(fileName.Substring(0, 64) + FNam);

                balXML objbalXML = new balXML();
                objbalXML.Update_Status(ITRXML_ID, 2);
            }
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
            Response.ContentType = "application/zip";
            zip.Save(Response.OutputStream);
            for (int j = 0; j < arrLst.Count; j++)
            {
                File.Delete(arrLst[j].ToString());
            }
            Response.End();
        }
    }
}