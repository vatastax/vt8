using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;

public partial class WebUserControl : System.Web.UI.UserControl
{
    string path;
    SqlConnection con = new SqlConnection();
    string[] code = new string[10];
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = (ConfigurationManager.ConnectionStrings["Con_Poolable"].ConnectionString);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string[] validFileTypes = { "pdf" };
            string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
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
            }
            else
            {
                path = "../pdfupload/" + FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath(path));
                SqlDataAdapter da = new SqlDataAdapter("select * from tblpdf", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    StringBuilder text = new StringBuilder();
                    if (File.Exists(Server.MapPath(path)))
                    {
                        PdfReader pdfReader = new PdfReader(Server.MapPath(path));

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
                            string ss = tmp.Replace("\n", " ");
                            int ix = tmp.Replace("\n", " ").IndexOf(tobesearched.Trim());

                            if (ix != -1)
                            {
                                code = new string[ds.Tables[0].Rows.Count];
                                code[i] = tmp.Substring(ix + tobesearched.Length);
                                code[i] = code[i].Trim().Substring(0, sublength);
                                Response.Write(code[i]);


                            }
                        }
                        else
                        {
                            code[i] = Between(tmp, ds.Tables[0].Rows[i][3].ToString().Trim(), ds.Tables[0].Rows[i][4].ToString().Trim());
                            if (!(ds.Tables[0].Rows[i][5]).Equals(DBNull.Value) && (!(ds.Tables[0].Rows[i][6]).Equals(DBNull.Value)))
                            {
                                code[i] = code[i].Remove(Convert.ToInt32(ds.Tables[0].Rows[i][5]), Convert.ToInt32(ds.Tables[0].Rows[i][6]));
                            }
                        
                            Response.Write(code[i]);
                        }
                    }

                }
            }

            Label1.ForeColor = System.Drawing.Color.Green;
            Label1.Text = "File uploaded successfully.";



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
}