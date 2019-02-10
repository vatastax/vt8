using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text;
using System.Data;

public partial class Presentation_UploadForm16B : System.Web.UI.Page
{
    balPDF obj_PDF = new balPDF();
    string Path;

    string[] code = new string[10];
    List<string> lstPdf = new List<string>();
    string PAN_Deductor, TAN_Deductor, PAN_Employee, AY, Total, Employer_Add, Employee_Add;
    protected void Page_Load(object sender, EventArgs e)
    {
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
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //upload file from user
        if (FilePdfUpload.HasFile)
        {
            string[] validFileTypes = { "pdf" };
            string ext = System.IO.Path.GetExtension(FilePdfUpload.PostedFile.FileName);
            bool isValidFile = false;

            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Invalid File. Please upload a File with extension " +
                               string.Join(",", validFileTypes);
                Label1.Visible = true;
            }
            else
            {
                Path = "~/pdfupload/" + FilePdfUpload.FileName;
                //  Path = "~\\pdfupload\\" + FilePdfUpload.FileName;
                FilePdfUpload.SaveAs(Server.MapPath(Path));
                DataTable dt = new DataTable();
                dt = obj_PDF.getPDF_Data();

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                //check fields to be searched
                if (ds.Tables[0].Rows.Count > 0)
                {


                    StringBuilder text = new StringBuilder();

                    if (File.Exists(Server.MapPath(Path)))
                    {
                        PdfReader pdfReader = new PdfReader(Server.MapPath(Path));

                        for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                        {
                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                            string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);


                            currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                            //Response.Write(currentText + "<br/>" + "<br/>");


                            text.Append(currentText);

                        }
                        pdfReader.Close();
                    }
                    string tmp = text.ToString();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (!(ds.Tables[0].Rows[i][1]).Equals(DBNull.Value) && (!(ds.Tables[0].Rows[i][2]).Equals(DBNull.Value)))
                        {
                            string tobesearched = ds.Tables[0].Rows[i][1].ToString().Trim();
                            int sublength = Convert.ToInt32(ds.Tables[0].Rows[i][2]);
                            int ix = tmp.IndexOf(tobesearched);

                            if (ix != -1)
                            {
                                code = new string[ds.Tables[0].Rows.Count];
                                code[i] = tmp.Substring(ix + tobesearched.Length);
                                code[i] = code[i].Substring(0, sublength);
                                Response.Write(code[i]);
                                lstPdf.Add(code[i]);

                            }
                        }
                        else
                        {
                            code[i] = Between(tmp, ds.Tables[0].Rows[i][3].ToString().Trim(), ds.Tables[0].Rows[i][4].ToString().Trim());
                            //if (!(ds.Tables[0].Rows[i][5]).Equals(DBNull.Value) && (!(ds.Tables[0].Rows[i][6]).Equals(DBNull.Value)))
                            //{
                            //    code[i] = code[i].Remove(Convert.ToInt32(ds.Tables[0].Rows[i][5]), Convert.ToInt32(ds.Tables[0].Rows[i][6]));
                            //}
                            lstPdf.Add(code[i]);

                            Response.Write(code[i]);
                        }
                    }

                }
                PAN_Deductor = lstPdf.ElementAt(0).ToString();
                TAN_Deductor = lstPdf.ElementAt(1).ToString();
                PAN_Employee = lstPdf.ElementAt(2).ToString();
                AY = lstPdf.ElementAt(3).ToString();
                Total = lstPdf.ElementAt(6).ToString();
                Employer_Add = lstPdf.ElementAt(5).ToString();
                //Employer_Add = lstPdf.ElementAt(6).ToString();

            }

            Label1.ForeColor = System.Drawing.Color.Green;
            Label1.Text = "File uploaded successfully.";
            Label1.Visible = true;
            string message = "Do you want to upload Part B";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);


        }
    }
    public string Between(string value, string a, string b)
    {
        int posA = value.IndexOf(a);
        int posB = value.LastIndexOf(b);
        if (posA == -1)
        {
            return "";
        }
        if (posB == -1)
        {
            return "";
        }
        int adjustedPosA = posA + a.Length;
        if (adjustedPosA >= posB)
        {
            return "";
        }
        return value.Substring(adjustedPosA, posB - adjustedPosA);
    }
    protected void lbtnLogout1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    protected void lbtnLogout11_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}