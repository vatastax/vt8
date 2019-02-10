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
using Taxation.DataAccess;
using Taxation.DataEntity;


public partial class Presentation_UploadForm16 : System.Web.UI.Page
{
    balPDF obj_PDF = new balPDF();
    string Path;

    string[] code = new string[10];
    List<string> lstPdf = new List<string>();
    string PAN_Deductor, TAN_Deductor, PAN_Employee, AY, Total, Employer_Add, Employee_Add, strData,incomechargeablesalary;
    static string[] arrData = null;

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
        if (Session["UploadForm16Details"] != null)
        {
            strData = Session["UploadForm16Details"].ToString();
            //uploadData();
            Session["UploadForm16Details"] = null;
            string message = "Do you want to upload Part B";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }
        ltWelcome.Text = "Welcome <a href='../Presentation/'>" + Session["user_name"].ToString() + "</a>";
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
                dt = obj_PDF.getPDF_Data("PartA");

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
                                strData += code[i] + "~";
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
                            strData += code[i] + "~";
                            //Response.Write(code[i]);
                        }
                    }

                }
                string[] data = strData.Split('~');
                PAN_Deductor = lstPdf.ElementAt(0).ToString();
                TAN_Deductor = lstPdf.ElementAt(1).ToString();
                PAN_Employee = lstPdf.ElementAt(2).ToString();
                AY = lstPdf.ElementAt(3).ToString();
                string TaxDeducted = data[7].Trim();
                var a = (int)Convert.ToDouble(TaxDeducted);
                Total = a.ToString();
                string[] data1 = data[8].Split(' ');
                string[] incomechargeable = data1[20].Split('\n');
                incomechargeablesalary = incomechargeable[0].Trim();
                var b = (int)Convert.ToDouble(incomechargeablesalary);
                incomechargeablesalary = b.ToString();
                Employer_Add = lstPdf.ElementAt(5).ToString().Trim();
                //Employer_Add = lstPdf.ElementAt(6).ToString();

            }

            Label1.ForeColor = System.Drawing.Color.Green;
            Label1.Text = "File uploaded successfully.";
            Label1.Visible = true;

            arrData = System.Text.RegularExpressions.Regex.Split(strData, "~");
            dalAssessee objAssesseeDAL = new dalAssessee();
            denAssesseeIndividual objAssesseeIndividualDEN = new denAssesseeIndividual();
            objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(arrData[2].Replace("\\n", "").Trim());
            denFloating objFloatingDEO = new denFloating();
            objFloatingDEO.NameID = Session["NameID"].ToString();
            objFloatingDEO.HeaderID = "1";
            objFloatingDEO.Vtype = "104";
            objFloatingDEO.ConstID = "802";
            objFloatingDEO.Gorder = "1";
            objFloatingDEO.Number = 3;
            objFloatingDEO.Col3 = TAN_Deductor;
            objFloatingDEO.ColMain = TAN_Deductor;
            objFloatingDEO.AY = Convert.ToString(Session["AY"]);
            objFloatingDEO.MainId = Session["NameID"].ToString();

            bllFloating objFloatingBLO = new bllFloating();
            objFloatingBLO.InsertOrUpdate(objFloatingDEO);
            string[] strAdd = Employer_Add.Split('\n');
            objFloatingDEO.ColMain = strAdd[0];
            objFloatingDEO.Col4 = strAdd[1];
            objFloatingDEO.ColMain = strAdd[1];
            objFloatingDEO.Number = 4;
            objFloatingBLO.InsertOrUpdate(objFloatingDEO);
            objFloatingDEO.Col7 =  incomechargeablesalary;
            objFloatingDEO.ColMain = incomechargeablesalary;
            objFloatingDEO.Number = 7;
            objFloatingBLO.InsertOrUpdate(objFloatingDEO);
            objFloatingDEO.ColMain = Total;
            objFloatingDEO.Col13 = Total;
            objFloatingDEO.Number = 13;
            objFloatingBLO.InsertOrUpdate(objFloatingDEO);
          //  string message = "Do you want to upload Part B";
           // ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }
        else
        {
           
        }
    }

    private void uploadData(int num)
    {
        arrData = System.Text.RegularExpressions.Regex.Split(strData, "~");
        dalAssessee objAssesseeDAL = new dalAssessee();
        denAssesseeIndividual objAssesseeIndividualDEN = new denAssesseeIndividual();
        objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(arrData[2].Replace("\\n", "").Trim());
        denFloating objFloatingDEO = new denFloating();
        objFloatingDEO.NameID = Session["NameID"].ToString();
        objFloatingDEO.HeaderID = "1";
        objFloatingDEO.Vtype = "104";
        objFloatingDEO.ConstID = "802";
        objFloatingDEO.Gorder = "1";
        objFloatingDEO.Number = num;
    
        objFloatingDEO.AY = Convert.ToString(Session["AY"]);
        objFloatingDEO.MainId = Session["NameID"].ToString();

        bllFloating objFloatingBLO = new bllFloating();
        objFloatingBLO.InsertOrUpdate(objFloatingDEO);
      
        Session["Common"] = null;
   
        //if (objAssesseeIndividualDEN.NameID != null)
        //{
        //    InsertOrUpdate(objAssesseeIndividualDEN.NameID, 5, "2014-2015", arrData[5]);    // dummy entry to insert and move it for update further
        //    InsertOrUpdate(objAssesseeIndividualDEN.NameID, 4, "2014-2015", arrData[5]);
        //    InsertOrUpdate(objAssesseeIndividualDEN.NameID, 7, "2014-2015", arrData[7]);
        //    InsertOrUpdate(objAssesseeIndividualDEN.NameID, 9, "2014-2015", arrData[1]);
        //    InsertOrUpdate(objAssesseeIndividualDEN.NameID, 13, "2014-2015", arrData[4]);
        //    InsertOrUpdate(objAssesseeIndividualDEN.NameID, 14, "2014-2015", arrData[4]);

         //  denStoreTrans objStoreTransDEN;
          /// bllStoreTrans objStoreTransBLL;

          // objStoreTransDEN = new denStoreTrans();
           // objStoreTransBLL = new bllStoreTrans();

        //    objStoreTransDEN.ConstID = 802;
        //    objStoreTransDEN.AY = "2014-2015";
        //    objStoreTransDEN.NameID = objAssesseeIndividualDEN.NameID;
        //    objStoreTransDEN.Vtype = 104;
        //    objStoreTransDEN.GIndex = 5003;
        //    objStoreTransDEN.ComboItemNo = 0;
        //    objStoreTransDEN.MainID = Convert.ToInt32(objAssesseeIndividualDEN.NameID);  //for inidividual user
        //    objStoreTransDEN.GRowNo = -1;
        //    objStoreTransDEN.IsEnterFDet = 1;
        //    objStoreTransDEN.DueDate = "31/07/2014";

          // objStoreTransBLL.ProcCalculationDtlsGrid(objStoreTransDEN, 1, "104", 102);
        //}
        //else
        //{
        //    Session["PAN"] = arrData[2].Replace("\\n", "").Trim();
        //    Session["UploadForm16Details"] = strData;
        //    Session["Mode"] = "New";
        //    Session["Bool"] = "False";
        //    //Response.Redirect("Assesseeselect.aspx");

        //    string message2 = "This Assessee is not added to your list before. Would you like to add now?";
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopupAssessee('" + message2 + "');", true);
        //}
    }

    protected void InsertOrUpdate(string NameID, int num, string AY,string colMain)
    {
        denFloating objFloatingDEO = new denFloating();
        objFloatingDEO.ColMain = colMain;
        objFloatingDEO.NameID = NameID;
        objFloatingDEO.HeaderID = "102";
        objFloatingDEO.Vtype = "104";
        objFloatingDEO.ConstID = "802";
        objFloatingDEO.Gorder = "1";
        objFloatingDEO.Number = num;
        objFloatingDEO.AY = AY;

        bllFloating objFloatingBLO = new bllFloating();
        objFloatingBLO.InsertOrUpdate(objFloatingDEO);
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
