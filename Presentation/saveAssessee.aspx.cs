using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
//using GetTDSReference;
using System.Globalization;
using System.Reflection;
using controlgrid;
using System.IO;
using System.Web.Services;
using BALVatasETDS.UserGroupManagement;

public partial class Presentation_saveAssessee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NameID"] != null)
        {
            balAdmin objbalAdmin = new balAdmin();
            bllAssessee objbllAssessee = new bllAssessee();
            bllStoreTrans objbllStoreTrans = new bllStoreTrans();

            if (Request.QueryString["wx"] != null)
            {
                try
                {
                    string FilePath = "";
                    //calcTax();
                    string strXMLData = "";
                    string strXMLData_Extra = "";
                    xmlFunctions objxmlFunction = new xmlFunctions();
                    bllSalary objbllSalary = new bllSalary();

                    if (Session["ITR"].ToString() == "1" || Session["ITR"].ToString() == "8" || Session["ITR"].ToString() == "50" || Session["ITR"].ToString() == "51" || Session["ITR"].ToString() == "55")
                    {
                        //objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, "1", Session["duedate"].ToString(), 0);
                        objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, Session["ITR"].ToString(), ((Session["duedate"] != null) ? Session["duedate"].ToString() : ""), "", "", out strXMLData, out strXMLData_Extra);
                        //(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, "1", Session["duedate"].ToString(), 0);
                        //strXMLData = objbllStoreTrans.getXMLData(Session["NameID"].ToString(), Session["AY"].ToString(), "1");
                        objbllSalary.SaveAssessee(2, Session["NameID"].ToString(), Session["AY"].ToString(), strXMLData, Session["ITR"].ToString(), strXMLData_Extra);    //IsValidated=2 for an assessee with no other than just personal data in his/her xml
                    }
                    else
                    {
                        //objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, "4s", Session["duedate"].ToString(), 0);
                        //objbllStoreTrans.genXML(Session["NameID"].ToString(), Session["AY"].ToString(), FilePath, "4s", Session["duedate"].ToString(), "", "", out strXMLData, out strXMLData_Extra);
                        //strXMLData = objbllStoreTrans.getXMLData(Session["NameID"].ToString(), Session["AY"].ToString(), "1");

                        //objbllSalary.SaveAssessee(0, Session["NameID"].ToString(), Session["AY"].ToString(), strXMLData, "8");
                        objbllSalary.SaveAssessee_Main(Session["NameID"].ToString(), Session["AY"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            objbllAssessee.DeleteFromStoreTrans(Session["NameID"].ToString(), Session["AY"].ToString());
        }
        if (Request.QueryString["lg"] != null)
            Response.Redirect("Logout.aspx");
        if (Request.QueryString["ay"] != null)
            Response.Redirect("Main.aspx?ai=1");
        else
            Response.Redirect("Main.aspx");
    }

    public void calcTax()
    {
        denDocTrans objdenDocTrans = new denDocTrans();
        bllDocTrans objDocTransBLL = new bllDocTrans();
        objdenDocTrans = objDocTransBLL.GetBankDetails(Convert.ToString(Session["PAN"]));

        bllSalary objbllSalary = new bllSalary();
        decimal gIFS, gIFHP, gIFBUS, gIFSTCG, gIFLTCG, gIFOS, gDED, gDED1, gICE, gAI, gTDS, gTCS, gSelfAss, gATP, gCasuInc, gCLUB, gRelief, gTI, gGIT, gNIT, gSum_234, gSur, gEduCess, gRebate87A;
        gIFS = 0; gIFHP = 0; gIFBUS = 0; gIFSTCG = 0; gIFLTCG = 0; gIFOS = 0; gDED = 0; gDED1 = 0; gICE = 0; gAI = 0; gTDS = 0; gTCS = 0; gSelfAss = 0; gATP = 0; gCasuInc = 0; gCLUB = 0; gRelief = 0; gTI = 0; gGIT = 0; gNIT = 0; gSum_234 = 0;
        gSur = 0; gRebate87A = 0;
        gEduCess = 0;
        objbllSalary.SetAllZero(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.calcSal("0", Session["NameID"].ToString(), Session["ay"].ToString(), (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString()), out gIFS, out  gIFHP, out  gIFBUS, out  gIFSTCG, out  gIFLTCG, out  gIFOS, out  gDED, out  gDED1, out  gICE, out  gAI, out  gTDS, out  gTCS, out  gSelfAss, out  gATP, out  gCasuInc, out  gCLUB, out  gRelief, out gTI, out gGIT, out gNIT, out gSum_234, out gEduCess, out gSur, out gRebate87A);

        //Response.Write("gIFS = " + gIFS + ", gIFHP = " + gIFHP + " , gIFBUS = " + gIFBUS + ", gIFSTCG= " + gIFSTCG + " , gIFLTCG =" + gIFLTCG + " , gIFOS = " + gIFOS + " , gDED= " + gDED + " , gDED1= " + gDED1 + " , gICE= " + gICE + ", gAI = " + gAI + " , gTDS = " + gTDS + " , gTCS = " + gTCS + " , gSelfAss = " + gSelfAss + " , gATP = " + gATP + ", gCasuInc = " + gCasuInc + " , gCLUB = " + gCLUB + ", gRelief = " + gRelief + ", gTI = " + gTI + ", gGIT = " + gGIT + ", gNIT = " + gNIT + ", gSum_234 = " + gSum_234 + ", gEduCess = " + gEduCess + ", gSur = " + gSur);

        Label lblNetTaxPayable = new Label();
        lblNetTaxPayable.Text = gNIT.ToString(); //(gNIT + gSum_234).ToString();

        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gIFS.ToString(), Convert.ToDecimal(9001), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "L", Convert.ToDecimal(9002), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);   //for constantid=582 else s
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gIFHP.ToString(), Convert.ToDecimal(9003), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gIFOS.ToString(), Convert.ToDecimal(9004), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), (gIFBUS + gIFHP + gIFS + gIFOS + gIFLTCG + gIFSTCG).ToString(), Convert.ToDecimal(9005), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), (gIFBUS + gIFHP + gIFS + gIFOS + gIFLTCG + gIFSTCG - gDED - gDED1).ToString(), Convert.ToDecimal(9006), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);

        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), lblNetTaxPayable.Text, Convert.ToDecimal(9011), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9012), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);   // Rebate 87A
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9013), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);   //Tax Payable on Rebate

        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gSur.ToString(), Convert.ToDecimal(917), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 3, Convert.ToDecimal(0), 0);   //Surcharge
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gEduCess.ToString(), Convert.ToDecimal(1015), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 4, Convert.ToDecimal(0), 0);   //EducationCess

        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gRelief.ToString(), Convert.ToDecimal(881), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 6, Convert.ToDecimal(0), 0);   //Section89 - gRelief
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gSum_234.ToString(), Convert.ToDecimal(9019), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        if (!lblNetTaxPayable.Text.Contains("-"))
        {
            objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), lblNetTaxPayable.Text, Convert.ToDecimal(9025), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Balance Tax Payable
            objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9034), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Refund Due
        }
        else
        {
            objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9025), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Balance Tax Payable
            objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), lblNetTaxPayable.Text, Convert.ToDecimal(9034), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Refund Due
        }

        double tot_tax_paid = Convert.ToDouble(gATP + gTDS + gSelfAss);
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), tot_tax_paid.ToString(), Convert.ToDecimal(9030), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Tot Tax Paid

        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), objdenDocTrans.AccountNumber, Convert.ToDecimal(9035), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Assessee Account Number

        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), lblNetTaxPayable.Text, Convert.ToDecimal(9065), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //IncChrgSal
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gTDS.ToString(), Convert.ToDecimal(9066), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Total TDS Sal


        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9016), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Gross Tax Liability   - no values known for now?
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(9018), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);    //Net Tax Liability   - no values known for now?

        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gGIT.ToString(), Convert.ToDecimal(1117), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 1, Convert.ToDecimal(0), 0);    //Income Tax
        gRebate87A = gGIT - gRebate87A;
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), (gRebate87A).ToString(), Convert.ToDecimal(918), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 5, Convert.ToDecimal(0), 0);    //Total Tax
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), gGIT.ToString(), Convert.ToDecimal(1118), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 10, Convert.ToDecimal(0), 0);    //Total Tax Due

        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(1119), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 11, Convert.ToDecimal(0), 0);    //Tax Paid
        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), "0", Convert.ToDecimal(1120), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 12, Convert.ToDecimal(0), 0);    //Tax Payable/Refund

        objbllSalary.AddTaxDetails(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), (gDED + gDED1).ToString(), Convert.ToDecimal(9077), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 12, Convert.ToDecimal(0), 0);    //Total Deductions


    }
}