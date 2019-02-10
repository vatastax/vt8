using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using Taxation.BusinessLogic;
using System.Globalization;
using System.Data;

public partial class Presentation_ChallanPDF : System.Web.UI.Page
{
    int var234A, var234B, var234C, varTotal, Interest, Surcharge, EduCess, IncomeTax, TaxPayable, x;
    protected void Page_Load(object sender, EventArgs e)
    {
        ChallanData();
        tick_ADVT.Visible = false;
        tick_SAT.Visible = false;
        tick_ST.Visible = false;
        tick_TDC.Visible = false;
        tick_TRA.Visible = false;
        tick_UH.Visible = false;
    }

    protected void btnEmail_Click(object sender, EventArgs e)
    {
        
    }

    protected void ChallanData()
    {
       dalAssessee objAssesseeDAL = new dalAssessee();
            denAssesseeIndividual objAssesseeIndividualDEN = new denAssesseeIndividual();
            objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(Session["PAN"].ToString(), Convert.ToString(Session["UserName"]));
        //check that pan is of company
        int len1=Session["PAN"].ToString().Length;
        string pan = Session["PAN"].ToString();
        char[] pan1 = new char[Session["PAN"].ToString().Length];
        pan1 = pan.ToArray();
        for (int i = 0; i < len1; i++)
        {
            if (i == 3)
            {
                char Pan4 = pan1[i];
                if (Pan4 == 'c')
                {
                    tick_0021.Visible = false;
                    tick_0020.Visible = true;
                }
                else
                {
                    tick_0020.Visible = false;
                    tick_0021.Visible = true;
                }
            }
        }
        denAddress objAddressDEN = new denAddress();
        bllAddress objAddressBLL = new bllAddress();
        objAddressDEN = objAddressBLL.GetAddress(Convert.ToString(Session["PAN"]));
        data_AY.InnerHtml = Session["AY"].ToString();
        forAY.InnerText = Session["AY"].ToString();
      //  string Name = objAssesseeIndividualDEN.FirstName + " " + objAssesseeIndividualDEN.LastName;
         bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        string Name=(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "2") +" "+objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "3")+" "+objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "4"));
        data_NAME.InnerText = Name;
      //  t_for_Name.InnerText = Name;
        boxRecieved.InnerText = Name;
        bllStates objStatesBll = new bllStates();
       


        balCountry objbalCountry = new balCountry();
        
        string Statename = objStatesBll.SelectStateName(Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "14")));
        string Countryname = objbalCountry.SelectCountryName(Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "15")));
        data_ADD.InnerText = (objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "9") + ", " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "12") + ", " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "13") + ", " + Statename + ", " + Countryname).ToUpper();
        data_TEL.InnerText = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "19");
        data_PIN.InnerText = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "16");
        data6.InnerText =Session["PAN"].ToString();
        //bllStoreTrans objStoretRansBLL = new bllStoreTrans();
        //DataTable dt = new DataTable();
        //dt = objStoretRansBLL.Selectcol3(Session["NameID"].ToString());
        //DataSet ds1 = new DataSet();
        //ds1.Tables.Add(dt);
        //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        //{//for 234A
        //    if (ds1.Tables[0].Rows[i][0] != "" && ds1.Tables[0].Rows[i][0] != DBNull.Value)
        //    {
        //        if (Convert.ToInt32(ds1.Tables[0].Rows[i][0]) == 795)
        //        {
                //    var234A = Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "16"));
                ////}
                //////for 234B
                ////else if (Convert.ToInt32(ds1.Tables[0].Rows[i][0]) == 796)
                ////{
                //    var234B = Convert.ToInt32(ds1.Tables[0].Rows[i][1]);
                ////}
                //////for 234C
                ////else if (Convert.ToInt32(ds1.Tables[0].Rows[i][0]) == 797)
                ////{
                //    var234C = Convert.ToInt32(ds1.Tables[0].Rows[i][1]);
                //}

                //else if (Convert.ToInt32(ds1.Tables[0].Rows[i][0]) == 797)
                //{
                    //var234C = Convert.ToInt32(ds1.Tables[0].Rows[i][1]);
                //}
                ////Total Tax
                //else if (Convert.ToInt32(ds1.Tables[0].Rows[i][0]) == 918)
                //{
        //varTotal = Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "52"));
                //}
                ////Surcharge
                //else if (Convert.ToInt32(ds1.Tables[0].Rows[i][0]) == 917)
                //{
        Surcharge = Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "917"));
                //}
                ////Educess
                //else if (Convert.ToInt32(ds1.Tables[0].Rows[i][0]) == 1015)
                //{
        EduCess = Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "1015"));
                //}
                ////Income Tax
                //else if (Convert.ToInt32(ds1.Tables[0].Rows[i][0]) == 1117)
                //{
        IncomeTax = Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "1117"));
                //}
                //else if (Convert.ToInt32(ds1.Tables[0].Rows[i][0]) == 1120)
                //{
        TaxPayable = Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "66"));
                //}
        //    }
        //}
        //if (TaxPayable > 0)
        //{
            //x = TaxPayable - (var234A + var234B + var234C);
                    Interest = Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "52"));
                    x = TaxPayable - Interest;
                    IncomeTax = Convert.ToInt32(x / 1.03);
       // }
        //else if (TaxPayable <= 0)
        //{
        //    Interest = var234A + var234B + var234C;
        //}
                    if (Surcharge.ToString() == "0")
                    { data1.InnerText = ""; }
                    else
                    {
                        data1.InnerText = Surcharge.ToString();
                    }
       
        data2.InnerText = EduCess.ToString();
        data3.InnerText = IncomeTax.ToString();
        data4.InnerText = Interest.ToString();

        data5.InnerText = (Surcharge + EduCess + IncomeTax + Interest).ToString();
        dataAmt.InnerText = ConvertNumbertoWords(Convert.ToInt32(data5.InnerText));
        dataAmt.InnerText = dataAmt.InnerText + " ONLY";
        tforRs.InnerText = (Surcharge + EduCess + IncomeTax + Interest).ToString() ; ;
        string strlen = data5.InnerText;
        int len = strlen.Length;
        if (len > 7)
        {
            int quotient = Convert.ToInt32(data5.InnerText) / 10000000;
            int remainder = Convert.ToInt32(data5.InnerText) % 10000000;
            int quotient1 = remainder / 1000000;
            int remainder1 = remainder % 1000000;
            int quotient2 = remainder1 / 100000;
            int remainder2 = remainder1 % 100000;
            int quotient3 = remainder2 / 10000;
            int remainder3 = remainder2 % 10000;
            int quotient4 = remainder3 / 1000;
            int remainder4 = remainder3 % 1000;
            int quotient5 = remainder4 / 100;
            int remainder5 = remainder4 % 100;
            int quotient6 = remainder5 / 100;
            int remainder6 = remainder5 % 100;
            int quotient7 = remainder6 / 10;
            int remainder7 = remainder6 % 10;

        }
        else if (len > 6)
        {
            int quotient = Convert.ToInt32(data5.InnerText) / 100000;
            int remainder = Convert.ToInt32(data5.InnerText) % 100000;
            int quotient1 = remainder / 1000;
            int remainder1 = remainder % 1000;
            int quotient2 = remainder1 / 100;
            int remainder2 = remainder1 % 100;
            int quotient3 = remainder2 / 10;
            int remainder3 = remainder2 % 10;
            int quotient4 = remainder3 / 1;
            int remainder4 = remainder3 % 1;
            int quotient5 = remainder4 / 1;
            int remainder5 = remainder4 % 1;
          //  data_CRORES.InnerText = quotient.ToString();
            data_LACS.InnerText = quotient.ToString();
            data_THOUSAND.InnerText = quotient1.ToString();
            data_HUNDRED.InnerText = quotient2.ToString();
            data_TENS.InnerText = quotient3.ToString();
            data_UNITS.InnerText = quotient4.ToString();


        }
        else if (len > 5)
        {
            int quotient = Convert.ToInt32(data5.InnerText) / 100000;
            int remainder = Convert.ToInt32(data5.InnerText) % 100000;
            int quotient1 = remainder / 1000;
            int remainder1 = remainder % 1000;
            int quotient2 = remainder1 / 100;
            int remainder2 = remainder1 % 100;
            int quotient3 = remainder2 / 10;
            int remainder3 = remainder2 % 10;
            int quotient4 = remainder3 / 1;
            int remainder4 = remainder3 % 1;
            //int quotient5 = remainder4 / 10;
            //int remainder5 = remainder4 % 10;
            //lblCrore.Text = quotient.ToString();
            data_LACS.InnerText = quotient.ToString();
            data_THOUSAND.InnerText = quotient1.ToString();
            data_HUNDRED.InnerText = quotient2.ToString();
            data_TENS.InnerText = quotient3.ToString();
            data_UNITS.InnerText = quotient4.ToString();


        }
        else if (len > 4)
        {
            int quotient = Convert.ToInt32(data5.InnerText) / 1000;
            int remainder = Convert.ToInt32(data5.InnerText) % 1000;
            int quotient1 = remainder / 100;
            int remainder1 = remainder % 100;
            int quotient2 = remainder1 / 10;
            int remainder2 = remainder1 % 10;
            int quotient3 = remainder2 / 10;
            int remainder3 = remainder2 % 10;
            //int quotient4 = remainder3 / 10;
            //int remainder4 = remainder3 % 10;
            //int quotient5 = remainder4 / 10;
            //int remainder5 = remainder4 % 10;
            //lblCrore.Text = quotient.ToString();
            //lblLac.Text = quotient.ToString();
            data_THOUSAND.InnerText = quotient.ToString();
            data_HUNDRED.InnerText = quotient1.ToString();
            data_TENS.InnerText = quotient2.ToString();
            data_UNITS.InnerText = quotient3.ToString();


        }
        else if (len > 3)
        {
            int quotient = Convert.ToInt32(data5.InnerText) / 100;
            int remainder = Convert.ToInt32(data5.InnerText) % 100;
            int quotient1 = remainder / 10;
            int remainder1 = remainder % 10;
            int quotient2 = remainder1 / 10;
            int remainder2 = remainder1 % 10;
            int quotient3 = remainder2 / 10;
            int remainder3 = remainder2 % 10;
            //int quotient4 = remainder3 / 10;
            //int remainder4 = remainder3 % 10;
            //int quotient5 = remainder4 / 10;
            //int remainder5 = remainder4 % 10;
            //lblCrore.Text = quotient.ToString();
            //lblLac.Text = quotient.ToString();
            //lblThousand.Text = quotient.ToString();
            data_HUNDRED.InnerText = quotient.ToString();
           data_TENS.InnerText= quotient1.ToString();


        }
        DataTable dtBank = new DataTable();
        bllAssessee objAssesseeBLL = new bllAssessee();
        dtBank=objAssesseeBLL.GetBankDetail(Session["PAN"].ToString());
        //data_BANK.InnerText = (dtBank.Rows[0][1].ToString()).ToUpper() + " " + (dtBank.Rows[0][2].ToString()).ToUpper();
        //data_DATE.InnerText = System.DateTime.Now.ToShortDateString();
        data_PAN.InnerText = Session["PAN"].ToString();
        dataAmt2.InnerText = objAssesseeIndividualDEN.FirstName + " " + objAssesseeIndividualDEN.LastName;
        data_NAME2.InnerText = ConvertNumbertoWords(Convert.ToInt32(data5.InnerText))+" ONLY";

    }
    protected void btnPrintPDf_Click(object sender, EventArgs e)
    {

    }
    public static string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "ZERO";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 10000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000) + " CRORE ";
            number %= 1000000;
        }
        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAC ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "AND ";
            var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
}