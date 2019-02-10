using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
using Taxation.DataEntity;
using System.Data;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.Services;
using BALVatasETDS.UserGroupManagement;
using System.Configuration;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public partial class Presentation_income_statement : System.Web.UI.Page
{
    decimal gIFS, gIFHP, gIFBUS, gIFSTCG, gIFLTCG, gIFOS, gDED, gDED1, gICE, gAI, gTDS, gTCS, gSelfAss, gATP, gCasuInc, gCLUB, gRelief, gTI, gGIT, gNIT, gSum_234, gSur, gEduCess, gRebate87A;

    bllAssessee objAssesseeBLL;
    bllFloating objFloatingBLL;
    protected void Page_Load(object sender, EventArgs e)
    {
        getFloatData();
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
        Session["Def"] = "set";     //to prevent auto logout from Salary Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["DisplayForm"] = "set";     //to prevent auto logout from Display Form Web Method that was being called after this Page Load from this Page (in case coming directly from that page)
        Session["xmlRestore"] = "set";
        Session["Main"] = "set";

        //for managing window close from top:
        if (Request.UrlReferrer != null)
        {
            if (Request.UrlReferrer.ToString() != Request.Url.ToString())
                Session["inc"] = null;
            else
                Session["inc"] = "set";
        }
        else
            Session["inc"] = "set";

        if (Session["project"].ToString() == "vt")
        {
            Page.Title = "The Interactive Platform for free e-filing Income Tax Returns in India";
        }
        else if (Session["project"].ToString() == "tds")
        {
            Page.Title = "TDS";
        }

        if (Session["NameID"] == null)
            Response.Redirect("login.aspx");
        else
        {
            hdnNameID.Value = Session["NameID"].ToString();
        }

        //Re-Tax Calculation
        setEligibleDeductions();
        calcTax();

        gIFS = 0; gIFHP = 0; gIFBUS = 0; gIFSTCG = 0; gIFLTCG = 0; gIFOS = 0; gDED = 0; gDED1 = 0; gICE = 0; gAI = 0; gTDS = 0; gTCS = 0; gSelfAss = 0; gATP = 0; gCasuInc = 0; gCLUB = 0; gRelief = 0; gTI = 0; gGIT = 0; gNIT = 0; gSum_234 = 0;
        gSur = 0; gRebate87A = 0;
        gEduCess = 0;


        bllSalary objbllSalary = new bllSalary();

        Label lblNetTaxPayable = new Label();
        lblNetTaxPayable.Text = gNIT.ToString(); //(gNIT + gSum_234).ToString();               

        double amt = 0;


        DataTable dt = new DataTable();
        dt = objbllSalary.getStatementHeaders();
        string strData = "";
        string strStatement = "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'><tr><td style='text-align:center;font-size:17px;font-weight:bold'>STATEMENT OF INCOME</td></tr></table><table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'><tr><td></td><td style='font-size:15px;text-align:right;font-weight:bold'>Amount (Rs.)</td></tr>";
        amt = objbllSalary.getDataForConstID("1", Session["NameId"].ToString());    //Salary
        if (amt > 0)
            strStatement += @"<tr><td>Income from Salary</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        else
            strStatement += @"<tr><td>Income from Salary</td>
                    <td style='font-size:15px;text-align:right'>&nbsp;Nil
                    </td>
                    </tr>";

        amt = objbllSalary.getDataForConstID("582", Session["NameId"].ToString());    //HP
        if (amt > 0 || amt< 0)
            strStatement += @"<tr><td>Income from House Property</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        else
            strStatement += @"<tr><td>Income from House Property</td>
                    <td style='font-size:15px;text-align:right'>Nil
                    </td>
                    </tr>";

        amt = objbllSalary.getDataForConstID("9105", Session["NameId"].ToString());    //BUSINESS
        if (amt > 0)
            strStatement += @"<tr><td>Income from Business</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        else
            strStatement += @"<tr><td>Income from Business</td>
                    <td style='font-size:15px;text-align:right'>Nil
                    </td>
                    </tr>";

        amt = objbllSalary.getDataForConstID("329", Session["NameId"].ToString());    //OS
        if (amt > 0)
            strStatement += @"<tr><td>Income from Other Sources</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        else
            strStatement += @"<tr><td>Income from Other Sources</td>
                    <td style='font-size:15px;text-align:right'>Nil
                    </td>
                    </tr>";
        //
        amt = objbllSalary.getDataForConstID("57", Session["NameId"].ToString());    //OS
        if (amt > 0)
            strStatement += @"<tr><td>Exempt Income</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        else
            strStatement += @"<tr><td>Exempt Income</td>
                    <td style='font-size:15px;text-align:right'>Nil
                    </td>
                    </tr>";
        //
        amt = objbllSalary.getDataForConstID("68", Session["NameId"].ToString());    //Total
        if (amt > 0)
            strStatement += @"<tr><td STYLE='font-weight:bold;'>Gross Total Income</td>
                    <td style='font-weight:bold;font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                         amt.ToString() + @"
                    </td>
                    </tr>";
        else
            strStatement += @"<tr><td STYLE='font-weight:bold;'>Gross Total Income</td>
                    <td style='font-weight:bold;font-size:15px;text-align:right'>Nil
                    </td>
                    </tr>";

        strStatement += "</table>";
        strStatement += "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'>";
        if (objbllSalary.getDataForConstID("110", Session["NameId"].ToString()) > 0)
        {
            strStatement += "<tr><td>Deductions Under Chapter VI A </td><td></td><td></td></tr>";
            strStatement += "<tr><td></td><td style='font-size:15px;text-align:right;text-decoration:underline;font-weight:bold'>&nbsp;Deductions Claimed (Rs.)</td>   <td style='font-size:15px; text-decoration:underline;text-align:right;font-weight:bold'>Eligible Deductions (Rs.)</td> </tr>";
        }
        amt = objbllSalary.getDataForConstID("9070", Session["NameId"].ToString());    //80C
        if (amt > 0)
        {
            strStatement += @"<tr><td>Section 80C</td><td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"</td><td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1032", Session["NameId"].ToString()) + @"</td></tr>";
        }
        amt = objbllSalary.getDataForConstID("982", Session["NameId"].ToString());    //80CCC
        if (amt > 0)
            strStatement += @"<tr><td>Section 80CCC</td>
                   <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1033", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("983", Session["NameId"].ToString());    //80CCD1
        if (amt > 0)
            strStatement += @"<tr><td>Section 80CCD(1)</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1034", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("9082", Session["NameId"].ToString());    //80CCD1B
        if (amt > 0)
            strStatement += @"<tr><td>Section 80CCD(1B)</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("9083", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("988", Session["NameId"].ToString());    //80CCD2
        if (amt > 0)
            strStatement += @"<tr><td>Section 80CCD(2)</td>
                     <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1035", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("989", Session["NameId"].ToString());    //80CCG
        if (amt > 0)
            strStatement += @"<tr><td>Section 80CCG</td>
                   <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1036", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";

        amt = objbllSalary.getDataForConstID("158", Session["NameId"].ToString());    //80D
        if (amt > 0)
            strStatement += @"<tr><td>Section 80D</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1037", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("159", Session["NameId"].ToString());    //80DD
        if (amt > 0)
            strStatement += @"<tr><td>Section 80DD</td>
               <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1038", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("160", Session["NameId"].ToString());    //80DDB
        if (amt > 0)
            strStatement += @"<tr><td>Section 80DDB</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                   <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1039", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";

        amt = objbllSalary.getDataForConstID("161", Session["NameId"].ToString());    //80E
        if (amt > 0)
            strStatement += @"<tr><td>Section 80E</td>
                     <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                   <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1040", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("990", Session["NameId"].ToString());    //80E
        if (amt > 0)
            strStatement += @"<tr><td>Section 80EE</td>
                     <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                   <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1041", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("189", Session["NameId"].ToString());    //80EE
        if (amt > 0)
            strStatement += @"<tr><td>Section 80G</td>
          <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                           objbllSalary.getDataForConstID("1042", Session["NameId"].ToString()) + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
  amt.ToString() + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("191", Session["NameId"].ToString());    //80GG
        if (amt > 0)
            strStatement += @"<tr><td>Section 80GG</td>
               <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1043", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("569", Session["NameId"].ToString());    //80GGA
        if (amt > 0)
            strStatement += @"<tr><td>Section 80GGA</td>
               <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("106", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("987", Session["NameId"].ToString());    //80GGC
        if (amt > 0)
            strStatement += @"<tr><td>Section 80GGC</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                   <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1044", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("980", Session["NameId"].ToString());    //80QQB
        if (amt > 0)
            strStatement += @"<tr><td>Section 80QQB</td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                   <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1050", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("981", Session["NameId"].ToString());    //80RRB
        if (amt > 0)
            strStatement += @"<tr><td>Section 80RRB</td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                   <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1051", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        amt = objbllSalary.getDataForConstID("991", Session["NameId"].ToString());    //80TTA
        if (amt > 0)
            strStatement += @"<tr><td>Section 80TTA</td>
               <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                 <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1052", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";

        amt = objbllSalary.getDataForConstID("209", Session["NameId"].ToString());    //80U
        if (amt > 0)
            strStatement += @"<tr><td>Section 80U</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                  <td style='font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("1053", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";




        amt = objbllSalary.getDataForConstID("112", Session["NameId"].ToString());    //Total
        if (amt > 0)
            // strStatement += @"<tr><td colspan='3'><hr/></td></tr><tr><td>Total</td>
            //strStatement += @"<tr><td ></td><td style='text-align:right'>----------------</td><td style='text-align:right' >----------------</td></tr>";
            strStatement += @"<tr><td style='font-weight:bold;'>Total Deductions</td>
                  <td style='font-weight:bold; font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                   <td style='font-weight:bold; font-size:15px;text-align:right'><img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;" +
                                     objbllSalary.getDataForConstID("110", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
        //strStatement += @"<tr><td ></td><td style='text-align:right'>----------------</td><td style='text-align:right' >----------------</td></tr>";
        strStatement += "</table>";

        strStatement += "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 2px white;margin:0;padding:0'>";
        amt = objbllSalary.getDataForConstID("111", Session["NameId"].ToString());    //Salary
        strStatement += @"<tr><td style='font-weight:bold;'>Total Income [Rounded off u/s 288A] </td>
                     <td style='font-weight:bold; font-size:15px;text-align:right'>" +
                                                                                                                                                            (amt.ToString() == "0" ? "Nil" : @"<img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" + amt.ToString()) + @"
                    </td>
                    </tr>";
        strStatement += "</table>";

        strStatement += "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'><tr><td style='text-align:center;font-size:17px;font-weight:bold'>TAX COMPUTATION</td></tr></table><table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'><tr><td></td><td style='font-size:15px;text-align:right;font-weight:bold'>Amount (Rs.)</td></tr>";

        amt = objbllSalary.getDataForConstID("1117", Session["NameId"].ToString());    //Tax Payable on Total Income
        if (amt > 0)
        {
            strStatement += @"<tr><td>Tax Payable on Total Income</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        else
        {
            strStatement += @"<tr><td>Tax Payable on Total Income</td>
                    <td style='font-size:15px;text-align:right'>Nil
                    </td>
                    </tr>";
        }

        amt = objbllSalary.getDataForConstID("1121", Session["NameId"].ToString());    //Tax Payable on Total Income
        if (amt > 0)
        {
            strStatement += @"<tr><td>Rebate u/s 87A</td>
                   <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("46", Session["NameId"].ToString());    //Tax Payable after rebate
        if (amt > 0)
        {
            strStatement += @"<tr><td>Tax Payable after rebate</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("917", Session["NameId"].ToString());    //Surcharge
        if (amt > 0)
        {
            strStatement += @"<tr><td>Surcharge</td>
                     <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("1015", Session["NameId"].ToString());    //Education Cess
        if (amt > 0)
        {
            strStatement += @"<tr><td>Education Cess</td>
                     <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("918", Session["NameId"].ToString());    //Total Tax, Surcharge and Cess
        if (amt > 0)
        {
            //            strStatement += @"<tr><td></td>
            //                    <td style='text-align:right'> 
            //                                      --------------
            //                    </td>
            //                    </tr>";
            strStatement += @"<tr><td style='font-weight:bold;'>Total Tax, Surcharge and Cess</td>
                    <td style='font-weight:bold; font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("881", Session["NameId"].ToString());    //Relief u/s 89
        if (amt > 0)
        {
            strStatement += @"<tr><td>Relief u/s 89</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("51", Session["NameId"].ToString());    //Balance Tax after Relief
        if (amt > 0)
        {
            //            strStatement += @"<tr><td></td>
            //                    <td style='text-align:right'> 
            //                                      --------------
            //                    </td>
            //                    </tr>";
            strStatement += @"<tr><td style='font-weight:bold;'>Balance Tax after Relief</td>
                    <td style='font-weight:bold; font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
            //            strStatement += @"<tr><td></td>
            //                    <td style='text-align:right'> 
            //                                      --------------
            //                    </td>
            //                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("795", Session["NameId"].ToString());    //Total Interest u/s 234A
        if (amt > 0)
        {
            strStatement += @"<tr><td>Interest u/s 234A</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("796", Session["NameId"].ToString());    //Total Interest u/s 234B
        if (amt > 0)
        {
            strStatement += @"<tr><td>Interest u/s 234B</td>
                  <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("797", Session["NameId"].ToString());    //Total Interest u/s 234C
        if (amt > 0)
        {
            strStatement += @"<tr><td>Interest u/s 234C</td>
                     <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("52", Session["NameId"].ToString());    //Total Interest Payable
        if (amt > 0)
        {
            strStatement += @"<tr><td style='font-weight:bold;'>Total Interest Payable</td>
                   <td style='font-weight:bold; font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }

        amt = objbllSalary.getDataForConstID("1118", Session["NameId"].ToString());    //Total Tax & Interest
        if (amt > 0)
        {
            strStatement += @"<tr><td>Total Tax & Interest</td>
                   <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }

        ltStatement.Text = strStatement;

        //        amt = objbllSalary.getDataForConstID("118", Session["NameId"].ToString());    //Total Advance Tax Paid
        //        if (amt > 0)
        //        {
        //            strStatement += @"<tr><td>Total Advance Tax Paid</td>
        //                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
        //                                     amt.ToString() + @"
        //                    </td>
        //                    </tr>";
        //        }
        //        amt = objbllSalary.getDataForConstID("120", Session["NameId"].ToString());    //Total Self Assessment Tax Paid
        //        if (amt > 0)
        //        {
        //            strStatement += @"<tr><td>Total Self Assessment Tax Paid</td>
        //                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
        //                                     amt.ToString() + @"
        //                    </td>
        //                    </tr>";
        //        }
        //        amt = objbllSalary.getDataForConstID("119", Session["NameId"].ToString());    //Total TDS Claimed
        //        if (amt > 0)
        //        {
        //            strStatement += @"<tr><td>Total TDS Claimed</td>
        //                   <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
        //                                     amt.ToString() + @"
        //                    </td>
        //                    </tr>";
        //        }
        amt = objbllSalary.getDataForConstID("802", Session["NameId"].ToString());    //Tax Deducted at Source from Salary
        if (amt > 0)
        {
            strStatement += @"<tr><td>TDS on Salary</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("788", Session["NameId"].ToString());    //Tax Deducted at Source on Income other than Salary
        if (amt > 0)
        {
            strStatement += @"<tr><td>TDS on Income other than Salary</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("787", Session["NameId"].ToString());    //Advance Tax and Self Assessment Tax
        if (amt > 0)
        {
            strStatement += @"<tr><td>Advance Tax and Self Assessment Tax</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("801", Session["NameId"].ToString());    //Tax Collected at Source
        if (amt > 0)
        {
            strStatement += @"<tr><td>Tax Collected at Source</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("65", Session["NameId"].ToString());    //Total Taxes Paid
        if (amt > 0)
        {
            strStatement += @"<tr style='font-weight:bold;'><td>Total Taxes Paid	</td>
                    <td style='font-weight:bold; font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
//        amt = objbllSalary.getDataForConstID("9084", Session["NameId"].ToString());    //Total TCS Collected
//        if (amt > 0)
//        {
//            strStatement += @"<tr><td>Total TCS Collected	</td>
//                  <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
//                                     amt.ToString() + @"
//                    </td>
//                    </tr>";
//        }
        strStatement += @"<tr><td></td><td></td></tr>";

        amt = objbllSalary.getDataForConstID("66", Session["NameId"].ToString());    //Tax Payable
        if (amt > 0)
        {
            strStatement += @"<tr><td style='font-weight:bold;'>Tax Payable</td>
                    <td style='font-weight:bold; font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        amt = objbllSalary.getDataForConstID("67", Session["NameId"].ToString());    //Refund
        if (amt > 0)
        {
            strStatement += @"<tr><td>Refund</td>
                    <td style='font-size:15px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                     amt.ToString() + @"
                    </td>
                    </tr>";
        }
        strStatement += "</table>";
        ltStatement.Text = strStatement;

        //amt = objbllSalary.getDataForConstID("9106", Session["NameId"].ToString());
        //strStatement += @"<table><tr><td>Presumptive Income U/S 44AD (No books case)</td></tr></table>";
        //strStatement += @"<table><tr><td>Particulars</td><td>Amount</td></tr>";
        //if (amt > 0)
        //{

        //    strStatement += "<tr><td>Gross Turnover/Receipt</td><td>" + amt.ToString() + "/<td></tr>";
        //    //    strStatement += @"<table><tr><td>Gross Turnover/Receipt</td><td>"++@";</td><td>Sundry Debtors</td><td>Amount</td></tr>";
        //    //    strStatement += @"<table><tr><td>Net Profit</td><td>Amount</td><td>Sundry Creditors</td><td>Amount</td></tr>";
        //    //    strStatement += @"<table><tr><td></td><td>Amount</td><td>Stock-in-Trade</td><td>Amount</td></tr>";
        //    //    strStatement += @"<table><tr><td></td><td>Amount</td><td>Cash Balance</td><td>Amount</td></tr>";
        //    //}
        //}
        //amt = objbllSalary.getDataForConstID("9107", Session["NameId"].ToString());
        //if (amt > 0)
        //{
        //    strStatement += "<tr><td>Net Profit</td><td>" + amt.ToString() + "</td></tr>";
        //}
        //amt = objbllSalary.getDataForConstID("9094", Session["NameId"].ToString());
        //if (amt > 0)
        //{
        //    strStatement += "<tr><td>Sundry Debtors</td><td>" + amt.ToString() + "</td></tr>";
        //}
        //amt = objbllSalary.getDataForConstID("9095", Session["NameId"].ToString());
        //if (amt > 0)
        //{
        //    strStatement += "<tr><td>Sundry Creditors</td><td>" + amt.ToString() + "</td></tr>";
        //}
        //amt = objbllSalary.getDataForConstID("9096", Session["NameId"].ToString());
        //if (amt > 0)
        //{
        //    strStatement += "<tr><td>Stock-in-Trade</td><td>" + amt.ToString() + "</td></tr>";
        //}
        //amt = objbllSalary.getDataForConstID("9097", Session["NameId"].ToString());
        //if (amt > 0)
        //{
        //    strStatement += "<tr><td>Cash Balance</td><td>" + amt.ToString() + "</td></tr>";
        //}
        //strStatement += "</table>";
        //ltStatement.Text = strStatement;
        Document document = new Document();
    }

    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        common objcommon = new common();
        string strFilepath = objcommon.getDirectoryPath();

        string Status = "", Salute = "", Res = "", Add = "", CountryName = "", Statename = "", name = "";
        balCountry objCountrybll = new balCountry();
        objAssesseeBLL = new bllAssessee();
        DataTable dtnew = new DataTable();
        dtnew = objAssesseeBLL.getPdfData(Session["PAN"].ToString(), Convert.ToInt32(Session["Status"])).Copy();
        if (dtnew.Rows[0][2].ToString() == "0" || dtnew.Rows[0][2].ToString() == "1")
        {
            Status = "Individual";
        }
        else if (dtnew.Rows[0][2].ToString() == "2")
        {
            Status = "HUF";
        }
        if (dtnew.Rows[0][3].ToString() == "1")
        {
            Salute = "Male";
        }
        //else if (dtnew.Rows[0][3].ToString() == "1" || dtnew.Rows[0][3].ToString() == "2")
        else if (dtnew.Rows[0][3].ToString() == "2")
        {
            Salute = "Female";
        }
        if (dtnew.Rows[0][12].ToString() == "0")
        {
            Res = "Resident";
        }
        else if (dtnew.Rows[0][12].ToString() == "1")
        {
            Res = "None Resident";
        }

        //Add = dtnew.Rows[0][37].ToString() + dtnew.Rows[0][38].ToString() + dtnew.Rows[0][39].ToString() + dtnew.Rows[0][40].ToString() + dtnew.Rows[0][41].ToString();
        //string strDesc = "<table><tr><td ><img src='logo2.png'/></td></tr></table>";
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        bllStates objStatesBll = new bllStates();
        Statename = objStatesBll.SelectStateName(Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "14")));
        //objStatesBll.SelectStateName(Convert.ToInt32(dtnew.Rows[0][40]));

        Add = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "9") + ", " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "10") + " " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "11") + " " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "12") + ", " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "13") + ", " + Statename + ", India - " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "16");

        string strDesc = "<table><tr><td style='text-align:center;text-decoration:underline;font-size:12px;'></td></tr></table>";

        //strDesc = strDesc + "<table><tr><td style='text-align:center;text-decoration:underline;font-size:17px;'></td></tr></table>";
        name = dtnew.Rows[0][4].ToString() + dtnew.Rows[0][5].ToString() + " " + dtnew.Rows[0][6].ToString();
        strDesc = strDesc + "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 2px white;'> <tr><td style='font-size:10px;font-weight:bold'>Assesee Name</td><td style='font-size:9px;'>" + dtnew.Rows[0][4].ToString() + "  " + dtnew.Rows[0][5].ToString() + " " + dtnew.Rows[0][6].ToString() + @"</td><td style='font-size:10px;font-weight:bold'>PAN</td><td style='font-size:9px;'>" + dtnew.Rows[0][10].ToString() + @"</td>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Father's Name</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "8") + @"</td><td style='font-size:10px;font-weight:bold'>Gender</td><td style='font-size:9px;'>" + Salute + @"</td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Date of Birth</td><td style='font-size:9px;'>" + dtnew.Rows[0][8].ToString() + @"</td><td style='font-size:10px;font-weight:bold'>Status</td><td style='font-size:9px;'>" + Status + @"</td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Residential Status</td><td style='font-size:9px;'>" + Res + @"</td><td style='font-size:10px;font-weight:bold'>Assessment Year</td><td style='font-size:9px;'>" + Session["AY"].ToString() + @"</td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Mobile No.</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "19") + @"</td><td style='font-size:10px;font-weight:bold'>Aaadhar Card No.</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "9081") + @"</td></tr>";
        //strDesc = strDesc + "<tr><td style='font-size:10px;'>Address</td><td style='font-size:9px;'>" + dtnew.Rows[0][35].ToString() + "  " + dtnew.Rows[0][37].ToString() + "  " + dtnew.Rows[0][38].ToString() + "  " + dtnew.Rows[0][39].ToString() + "  " + Statename + " " + CountryName + " " + dtnew.Rows[0][41].ToString() + @"</td><td></td><td></td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Email</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "21") + @"</td><td style='font-size:10px;font-weight:bold'>Ward/Circle</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "22") + "</td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Address</td><td style='font-size:9px;' colspan='2'>" + Add + @"</td><td></td></tr>";


        strDesc = strDesc + "</table>";
        //strDesc = strDesc + "<table><tr><td>-------------------------------------------------------------------------------------------------------------------------------</td></tr></table>";
        // strDesc = strDesc + "<table><tr><td style='text-align:center;text-decoration:underline;font-size:11px;'>STATEMENT OF INCOME</td></tr></table>";
        //string Name = dtnew.Rows[0][4].ToString() + "  " + dtnew.Rows[0][5].ToString();
        string Footer = "<br/><br/><br/><table><tr><td style='text-align:center;font-size:9px;text-align:right'></td></tr></table><table><tr><td style='text-align:center;font-size:9px;text-align:right;font-weight:bold'>[" + name + @"]</td></tr></table>";
        Footer = Footer + "<table><tr><td style='text-align:center;text-decoration:underline;font-size:9px;font-style:italic;'>This pdf is generated by echarteredaccountants.com</td></tr></table>";

        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream(strFilepath + "/" + name + "_" + Session["AY"].ToString() + ".pdf", FileMode.Create));


        document.Open();




        HTMLWorker worker = new HTMLWorker(document);
        //ltStatement.Text = strDesc + ltStatement.Text;
        string strIncomeDesc = ltStatement.Text;
        //  strIncomeDesc = strIncomeDesc.Replace("<center><B>STATEMENT OF INCOME</B></center>", ");
        strIncomeDesc = strIncomeDesc.Replace("<td style='text-align:center;text-decoration:underline;font-size:11px;font-weight:bold'>STATEMENT OF INCOME</td>", "<td style='text-align:center;text-decoration:underline;font-size:15px;font-weight:bold'>STATEMENT OF INCOME</td>");
        strIncomeDesc = strIncomeDesc.Replace("<td style='text-align:center;text-decoration:underline;font-size:11px;font-weight:bold'>Tax Computation</td>", "<td style='text-align:center;text-decoration:underline;font-size:15px;font-weight:bold'>Tax Computation</td>");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;", "");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;", "<img src='../images/spacer.png' /><img src='../images/rupee-symbol_small.png' style='height:5px'/>&nbsp;");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;", "");
        //strIncomeDesc = strIncomeDesc.Replace("rupee-symbol_small.png", "rp.png");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;", "");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/spacer.png' >", "");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/spacer1.png'/>", "");
        strIncomeDesc = strIncomeDesc.Replace("<td style='font-size:15px;text-align:right'>", "<td style='font-size:14px;text-align:right;vertical-align:top'>");
        strIncomeDesc = strIncomeDesc.Replace("<td style='font-size:15px;text-align:right'>", "<td style='font-size:14px;text-align:right;vertical-align:top'>");
        strIncomeDesc = strIncomeDesc.Replace("12px", "9px;");
        strIncomeDesc = strIncomeDesc.Replace("14px", "10px;");
        strIncomeDesc = strIncomeDesc.Replace("17px", "10px;");
        strIncomeDesc = strIncomeDesc.Replace("15px", "10px;");
        strIncomeDesc = strIncomeDesc.Replace(" <td style='font-size:14px'>", "<td style='font-size:14px;width:1500px'>");
        strIncomeDesc = strIncomeDesc.Replace("  <td style='font-size:14px;'>", "<td style='font-size:14px;width:1500px'>");
        // strIncomeDesc = strIncomeDesc.Replace("<img src='../images/rupee-symbol_small.png' style='height:10px'/>", "<img src='../images/spacer.png' style='height:10px'/><img src='../images/rupee-symbol_small.png' style='height:9px; width:9px;' width='4px'/>");
        //strIncomeDesc.Replace("text-align:right", "text-align:left");

        // strIncomeDesc = strIncomeDesc.Replace("<td style=' font-size:15px;text-align:right;text-decoration:underline  '>&nbsp;Deductions Claimed</td>", "<td style=' font-size:15px;text-decoration:underline  '>&nbsp;Deductions Claimed</td>");
        strIncomeDesc = strIncomeDesc.Replace("&nbsp;", "");
        // strIncomeDesc = strIncomeDesc.Replace("text-align:right", "");
        strIncomeDesc = strIncomeDesc.Replace("font-weight:bold;", "font-weight:15px");
        strIncomeDesc = strIncomeDesc.Replace("15px", "10px;");
        strIncomeDesc = strIncomeDesc.Replace("<td>", "<td style='font-size:10px;'>");
        strIncomeDesc = strIncomeDesc.Replace("<td STYLE='font-weight:bold;'>", "<td STYLE='font-weight:bold;font-size:10px;'>");
        //strIncomeDesc = strIncomeDesc.Replace("td style='font-size:14px; text-align:right", "td style='font-size:12px; margin-left:300px");
        string FloatData = getFloatData();
        DataTable dt4 = new DataTable();
        dt4 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 9079);
        string BankDetails = "";
        if (dt4.Rows.Count > 0)
        {
            BankDetails = "<br/><table border='1'><tr><td style='font-size:10px;text-align:center;font-weight:bold'>Bank Name</td><td style='font-size:10px;text-align:center;font-weight:bold'>Account Number</td><td style='font-size:10px;text-align:center;font-weight:bold'>IFSC Code</td><td style='font-size:10px;text-align:center;font-weight:bold'>Account Type</td></tr>";
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                if (dt4.Rows[i]["col6"].ToString() == "SAV")
                {
                    dt4.Rows[i]["col6"] = "Saving";
                }
                else if (dt4.Rows[i]["col6"].ToString() == "CURR")
                {
                    dt4.Rows[i]["col6"] = "Current";
                }
                BankDetails = BankDetails + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:center'>" + dt4.Rows[i]["col4"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center'>" + dt4.Rows[i]["col5"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center'>" + dt4.Rows[i]["col3"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center'>" + dt4.Rows[i]["col6"].ToString() + "</td></tr>";
            }

            BankDetails = BankDetails + "</table>";
        }
        else if (Session["ay"].ToString() == "2014-2015")
           
        { bllSalary objbllSalary=new bllSalary();
        string BankType = objbllSalary.getDataForConstID_String("25", Session["NameId"].ToString());
        if (BankType == "SAV")
        {
            BankType = "Saving";
        }
        else if (BankType == "CURR")
        {
            BankType = "Current";
        }
            BankDetails = "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'><tr><td style='text-align:center;font-size:17px;font-weight:bold'>Bank Detail</td></tr></table><table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'><tr><td></td><td style='font-size:15px;text-align:right;font-weight:bold'>Amount (Rs.)</td></tr>";

            BankDetails += @"<tr><td style='font-size:10px'>Bank Account number</td>
                    <td style='font-size:10px;text-align:right'>" +
                                     objbllSalary.getDataForConstID_String("23", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
            BankDetails += @"<tr><td style='font-size:10px'>IFSC Code</td>
                    <td style='font-size:10px;text-align:right'>" +
                                     objbllSalary.getDataForConstID_String("24", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
            BankDetails += @"<tr><td style='font-size:10px'>Type of Account</td>
                    <td style='font-size:10px;text-align:right'>" +
                                     BankType + @"
                    </td>
                    </tr>";
                    BankDetails += "</table>";
        }
        string Schedule_AL = getScduleAL();
        worker.Parse(new StringReader(strDesc + BankDetails + strIncomeDesc + FloatData + Schedule_AL + Footer));
        document.Close();
        
        
        if (!File.Exists(strFilepath + "/" + name + "_" + Session["AY"].ToString() + ".pdf"))
            File.Create(strFilepath + "/" + name + "_" + Session["AY"].ToString() + ".pdf");

        FileStream fs = new FileStream(strFilepath + "/" + name + "_" + Session["AY"].ToString() + ".pdf", FileMode.Open, FileAccess.Read);
        byte[] ar = new byte[(int)fs.Length];
        fs.Read(ar, 0, (int)fs.Length);
        fs.Close();
        //string Extension = Path.GetExtension("d:\\IncomeStatement.pdf");
        string type = string.Empty;
        type = "application/pdf";
        
        //Response.AddHeader("content-disposition", "attachment;filename=" + name + "_" + Session["AY"].ToString() + ".pdf");
        //Response.ContentType = type;
        //Response.BinaryWrite(ar);
        //Response.End();
        //document.Close();
        Send_Email(strFilepath + "/" + name + "_" + Session["AY"].ToString() + ".pdf", name);
        //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('PDF Uploaded sucessfully');", true);
    }

    //Function to the Send the Email to the User Created. 
    public void Send_Email(string strFilePath, string AsseseeName)
    {
        bllSalary objbllSalary = new bllSalary();
        //Fill DataTable With Records
        string Account_Type = "U";
        string Email_ID = objbllSalary.getDataForConstID_String("21", Session["NameID"].ToString());// "cahoneyvig@gmail.com";// Session["userEmail"].ToString();        
        
        MailMessage mail = new MailMessage();
        mail.To.Add(Email_ID);
        
        mail.From = new MailAddress("info@echarteredaccountants.com");
        mail.Subject = "Income Computation Sheet of " + AsseseeName + " for the AY " + Session["AY"].ToString() + " from " + Session["user_name"].ToString();

        string Body = @"Hello " + AsseseeName + ",<br/>Welcome to eCharteredAccountants.com, Please find the attached as your Income Computation Sheet.</b><br/><br/>Warm Regards,<br/>Administartor,<br/>eCharteredAccountants.com.";
        mail.Body = Body;

        mail.IsBodyHtml = true;

        Attachment data = new Attachment(strFilePath);
        mail.Attachments.Add(data);

        SmtpClient smtp = new SmtpClient();
        //smtp.Host = "smtp.vatasinfotech.com"; //Or Your SMTP Server Address
        //smtp.Host = "smtp.mail.yahoo.com";
        smtp.Host = "smtp.vatasinfotech.com";
        smtp.Credentials = new System.Net.NetworkCredential
              ("register@vatasinfotech.com", "Save1234");

        //Or your Smtp Email ID and Password
        //smtp.EnableSsl = true;
        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
        smtp.Send(mail);
    }
    public void ShowPdf(string strFileName)
    {
        Response.ClearContent();
        Response.ClearHeaders();
        Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
        Response.ContentType = "application/pdf";
        Response.WriteFile(strFileName);
        Response.Flush();
        Response.Clear();
    }
    public string getEmp(Int32 indx)
    {
        string[] arrInfo = { "Employer", "Business", "House Property" };
        string[] arrData = { "Salary (Including All Allowances)", "Net Profit/Loss as per Profit & Loss Account", "Income From House Property" };
        string str = "";

        DataSet ds = new DataSet();
        bllSalary objbllSalary = new bllSalary();
        ds = objbllSalary.getStatementData(Session["NameID"].ToString(), Session["AY"].ToString());
        DataTable dtEmp = new DataTable();
        //dtEmp = objbllSalary.Select("select * from storetrans where vtype = 49 and NameID= " + Session["NameID"].ToString() + " and AY =" + Session["AY"].ToString());
        //DataRow[] rows = dtEmp.Compute("sum(cast(col3 as decimal))", "ConstantID ");
        int cnt = 0;
        if (ds.Tables[indx].Rows.Count > 0)
        {
            str = @"<tr style='background-color:white'>
                    <td>
                    <table width='100%' style='font-size:12px;   cellpadding='0' cellspacing='0'>";

            for (int i = 0; i < ds.Tables[indx].Rows.Count; i++)
            {
                if (ds.Tables[indx].Rows[i]["amt"].ToString() != "NULL" && ds.Tables[indx].Rows[i]["amt"].ToString() != "")
                {
                    cnt += 1;
                    if (ds.Tables[indx].Rows.Count > 1)
                    {
                        str += @"
                    <tr>
                    <td style=' width:60%; text-align:Center;font-size:16px; width:100%;'>
                    " + arrInfo[indx] + " " + (cnt).ToString() + ": <span style='text-transform:initial;'>" + ds.Tables[indx].Rows[i]["Name"].ToString() + @"</span>
                    </td>
                    <td style='text-align:left;font-size:12px'>
                    </td>
                    </tr>";
                    }
                    if (indx == 0 || indx == 2)
                    {
                        str += @"<tr style='background-color:white'>
                    <td style='font-size:14px;'>
                   " + arrData[indx] + @": 
                    </td>
                    <td style='font-size:12px;text-align:right;'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                  ds.Tables[indx].Rows[i]["amt"].ToString()
                                  + @"</td>
                                </tr>";
                    }
                    else if (indx == 1)
                    {
                        string strTemp = getBusiness(Convert.ToInt64(ds.Tables[indx].Rows[i]["EmpID"]), "41");
                        if (strTemp != "")
                            str += getBusiness(Convert.ToInt64(ds.Tables[indx].Rows[i]["EmpID"]), "41");
                        else
                            str = "";
                    }
                }
            }
            double grand_tot = 0;
            if (indx == 0)
                grand_tot = Convert.ToDouble(gIFS);
            else if (indx == 1)
                grand_tot = Convert.ToDouble(gIFBUS);
            else if (indx == 2)
                grand_tot = Convert.ToDouble(gIFHP);
            if (grand_tot > 0)
            {
                str += @"<tr style='background-color:white'>
                    <td style='font-size:14px'>
                    Grand Total:
                    </td>
                    <td style='font-size:12px;text-align:right;'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;&nbsp;" + (grand_tot).ToString() + @"</td>";
            }
            if (cnt == 0)
                str = "";
            else
            {
                str += @"</table>
                    </td>
                    </tr>";
            }
        }
        return str;
    }

    public string getBusiness(Int64 mainID, string vtype)
    {
        string str = "";
        DataTable dt = new DataTable();
        bllSalary objbllSalary = new bllSalary();
        dt = objbllSalary.getBusinessData(Session["NameID"].ToString(), mainID.ToString(), Session["AY"].ToString(), vtype);

        if (dt.Rows.Count > 0)
        {
            str = @"<tr style='background-color:white'>
                    <td>
                    <table width='100%' style='font-size:12px'  cellpadding='0' cellspacing='0';>";
            double grand_tot = 0;
            double grand_tot_Elg = 0;
            int cnti = 0;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                //                if (vtype == "49" && dt.Rows[j]["c4"].ToString() == "Total Tax")
                //                {
                //                    grand_tot = 0;
                //                    for (int kk = 0; kk < j; kk++)
                //                    {
                //                        if (dt.Rows[kk]["c4"].ToString().Contains("Rebate"))
                //                            grand_tot -= Convert.ToDouble(dt.Rows[kk]["col3"]);
                //                        else
                //                            grand_tot += Convert.ToDouble(dt.Rows[kk]["col3"]);
                //                        cnti += 1;
                //                    }
                //                    dt.Rows[j]["col3"] = grand_tot.ToString();
                //                    str += @"<tr style='background-color:white'>
                //                    <td style='font-size:14px;'>
                //                   " + dt.Rows[j]["c4"].ToString() + @": 
                //                    </td>
                //                    <td style='font-size:14px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                //                                  grand_tot.ToString()
                //                                  + @"</td>
                //                                </tr>";
                //                }
                //                else if (vtype == "49" && dt.Rows[j]["c4"].ToString().Contains("Total Tax Due"))
                //                {
                //                    grand_tot = 0;
                //                    for (int kk = cnti; kk < j; kk++)
                //                    {
                //                        grand_tot += Convert.ToDouble(dt.Rows[kk]["col3"]);
                //                    }
                //                    str += @"<tr style='background-color:white'>
                //                    <td style='font-size:14px'>
                //                   " + dt.Rows[j]["c4"].ToString() + @": 
                //                    </td>
                //                    <td style='font-size:14px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                //                                  grand_tot.ToString()
                //                                  + @"</td>
                //                                </tr>";
                //                }
                if (vtype == "46")
                {
                    if (j == 0)
                    {
                        //grand_tot += Convert.ToDouble(dt.Rows[j]["col3"]);
                        str += @"<tr style='background-color:white'>
                    <td style='font-size:14px;'>
                    </td>
                    <td><table width='100%' border='0' style='border:solid 0 white;'><tr>
                    <td style='font-size:14px; text-align:right'><b>Claimed</b></td>
                    <td style='font-size:14px; text-align:right'><b>Eligible</b></td></tr></table></td>
                                </tr>";
                    }
                    grand_tot += Convert.ToDouble(dt.Rows[j]["col3"]);
                    grand_tot_Elg += Convert.ToDouble(dt.Rows[j]["elgAmt"]);
                    str += @"<tr style='background-color:white'>
                    <td style='font-size:14px;'>
                   " + dt.Rows[j]["c4"].ToString() + @": 
                    </td>
                    <td><table width='100%' border='0' style='border:solid 0 white;'><tr>
                    <td style='font-size:14px; text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                  dt.Rows[j]["col3"].ToString()
                                  + @"</td>
                    <td style='font-size:14px; text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                  dt.Rows[j]["elgAmt"].ToString()
                                  + @"</td></tr></table></td>
                                </tr>";
                }
                else
                {
                    grand_tot += Convert.ToDouble(dt.Rows[j]["col3"]);
                    str += @"<tr style='background-color:white'>
                    <td style='font-size:14px;'>
                   " + dt.Rows[j]["c4"].ToString() + @": 
                    </td>
                    <td style='font-size:14px; text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;" +
                                  dt.Rows[j]["col3"].ToString()
                                  + @"</td>
                                </tr>";
                }
            }
            //grand_tot = Convert.ToDouble(gIFOS);
            if (vtype == "44")
            {
                str += @"<tr style='background-color:white'>
                    <td style='font-size:14px; font-weight:bold'>
                    Grand Total:
                    </td>
                    <td style='font-size:14px;text-align:right;'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;&nbsp;" + (grand_tot).ToString() + @"</td>";
            }
            else if (vtype == "46")
            {
                //grand_tot = Convert.ToDouble(gDED + gDED1);
                str += @"<tr style='background-color:white'>
                    <td style='font-size:14px'>
                    Grand Total of Deductions:
                    </td>
                    <td style='font-size:14px;text-align:right'><img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;&nbsp;" + (grand_tot_Elg).ToString() + @"</td>";
            }
            str += @"</table>
                    </td>
                    </tr>";
        }
        return str;
    }
    public string getHP()
    {
        string str = @"<tr style='background-color:white'>
                    <td>
                    <table width='100%' style='font-size:12px'>  <tr>
                    <td style=' width:60%; text-align:left;font-size:12px'>
                   Type of Propert is Let Out
                    </td>
                    <td style='width:40%; text-align:left;font-size:12px'>
                    </td>
                    </tr>
                    <tr style='background-color:white'>
                    <td style=' width:60%; text-align:left;font-size:12px'>
                   Income From House Property
                    </td>
                    <td style='width:40%; text-align:left;font-size:12px'>
                    " + gIFHP.ToString() + @"
                    </td>
                    </tr>";

        str += @"</table>
                    </td>
                    </tr>";
        return str;
    }

    public string getCG()
    {
        string str = "";
        if (gIFLTCG > 0)
        {
            str += @"<tr style='background-color:white'>
                    <td>
                    <table width='100%' style='font-size:12px'>  <tr>
                    <td style=' width:60%; text-align:left;font-size:12px'>
                   Long Term Capital Gain
                    </td>
                    <td style='width:40%; text-align:left;font-size:12px'>
                    " + gIFLTCG.ToString() + @"
                    </td>
                    </tr>";
        }
        if (gIFSTCG > 0)
        {
            str += @"<tr style='background-color:white'>
                    <td style=' width:60%; text-align:left;font-size:12px'>
                    Long Term Short Gain
                    </td>
                    <td style='width:40%; text-align:left;font-size:12px'>
                    " + gIFSTCG.ToString() + @"
                    </td>
                    </tr>";
        }
        if ((gIFSTCG + gIFLTCG) > 0)
        {
            str += @"
                    <tr style='background-color:white'>
                    <td style=' width:60%; text-align:left;font-size:12px'>
                    
                    </td>
                    <td style='width:40%; text-align:left;font-size:12px'>
                    " + (gIFSTCG + gIFLTCG).ToString() + @"
                    </td>
                    </tr>";
            str += @"</table>
                    </td>
                    </tr>";
        }

        return str;
    }
    public void getData()
    {
        objAssesseeBLL = new bllAssessee();
        DataTable dtnew = new DataTable();
        dtnew = objAssesseeBLL.getPdfData(Session["NameID"].ToString(), Convert.ToInt32(Session["Status"])).Copy();
        string strDesc = "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 2px white;'> <tr><td>NAME OF ASSESSEE</td><td>" + dtnew.Rows[0][6].ToString() + @"</td><td>PAN</td><td>" + dtnew.Rows[0][10].ToString() + @"</td>";
        strDesc = strDesc + "<tr><td>FATHER's NAME</td><td>" + dtnew.Rows[0][7].ToString() + @"</td><td>MALE/FEMALE</td><td>" + dtnew.Rows[0][3].ToString() + @"</td></tr>";
        strDesc = strDesc + "<tr><td>DATE OF BIRTH</td><td>" + dtnew.Rows[0][8].ToString() + @"</td><td>STATUS</td><td>" + dtnew.Rows[0][2].ToString() + @"</td></tr>";
        strDesc = strDesc + "<tr><td>RESIDENT</td><td>" + dtnew.Rows[0][12].ToString() + @"</td><td>FY</td><td>" + dtnew.Rows[0][2].ToString() + @"</td></tr>";
        strDesc = strDesc + "<tr><td>TELEPHONE NO.</td><td>" + dtnew.Rows[0][45].ToString() + @"</td><td>AaadharCard No.</td><td>" + dtnew.Rows[0]["AdharCardNo"].ToString() + @"</td></tr>";
        strDesc = strDesc + "</table>";
        // ltDesc.Text = strDesc;
    }
    //nishu for generate pdf
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        common objcommon = new common();
        string strFilepath = objcommon.getDirectoryPath();
        // string htmlContent = ...;
        // you html code (for example table from your page)
        string Status = "", Salute = "", Res = "", Add = "", CountryName = "", Statename = "", name = "";
        balCountry objCountrybll = new balCountry();
        objAssesseeBLL = new bllAssessee();
        DataTable dtnew = new DataTable();
        dtnew = objAssesseeBLL.getPdfData(Session["PAN"].ToString(), Convert.ToInt32(Session["Status"])).Copy();
        if (dtnew.Rows[0][2].ToString() == "0" || dtnew.Rows[0][2].ToString() == "1")
        {
            Status = "Individual";
        }
        else if (dtnew.Rows[0][2].ToString() == "2")
        {
            Status = "HUF";
        }
        if (dtnew.Rows[0][3].ToString() == "1")
        {
            Salute = "Male";
        }
        //else if (dtnew.Rows[0][3].ToString() == "1" || dtnew.Rows[0][3].ToString() == "2")
        else if (dtnew.Rows[0][3].ToString() == "2")
        {
            Salute = "Female";
        }
        if (dtnew.Rows[0][12].ToString() == "0")
        {
            Res = "Resident";
        }
        else if (dtnew.Rows[0][12].ToString() == "1")
        {
            Res = "None Resident";
        }

        //Add = dtnew.Rows[0][37].ToString() + dtnew.Rows[0][38].ToString() + dtnew.Rows[0][39].ToString() + dtnew.Rows[0][40].ToString() + dtnew.Rows[0][41].ToString();
        //string strDesc = "<table><tr><td ><img src='logo2.png'/></td></tr></table>";
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        bllStates objStatesBll = new bllStates();
        Statename = objStatesBll.SelectStateName(Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "14")));
        //objStatesBll.SelectStateName(Convert.ToInt32(dtnew.Rows[0][40]));

        Add = objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "9") + ", " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "10") + " " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "11") + " " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "12") + ", " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "13") + ", " + Statename + ", India - " + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "16");

        string strDesc = "<table><tr><td style='text-align:center;text-decoration:underline;font-size:12px;'></td></tr></table>";

        //strDesc = strDesc + "<table><tr><td style='text-align:center;text-decoration:underline;font-size:17px;'></td></tr></table>";
        name = dtnew.Rows[0][4].ToString() + dtnew.Rows[0][5].ToString() + " " + dtnew.Rows[0][6].ToString();
        strDesc = strDesc + "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 2px white;'> <tr><td style='font-size:10px;font-weight:bold'>Assesee Name</td><td style='font-size:9px;'>" + dtnew.Rows[0][4].ToString() + "  " + dtnew.Rows[0][5].ToString() + " " + dtnew.Rows[0][6].ToString() + @"</td><td style='font-size:10px;font-weight:bold'>PAN</td><td style='font-size:9px;'>" + dtnew.Rows[0][10].ToString() + @"</td>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Father's Name</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "8") + @"</td><td style='font-size:10px;font-weight:bold'>Gender</td><td style='font-size:9px;'>" + Salute + @"</td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Date of Birth</td><td style='font-size:9px;'>" + dtnew.Rows[0][8].ToString() + @"</td><td style='font-size:10px;font-weight:bold'>Status</td><td style='font-size:9px;'>" + Status + @"</td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Residential Status</td><td style='font-size:9px;'>" + Res + @"</td><td style='font-size:10px;font-weight:bold'>Assessment Year</td><td style='font-size:9px;'>" + Session["AY"].ToString() + @"</td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Mobile No.</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "19") + @"</td><td style='font-size:10px;font-weight:bold'>Aaadhar Card No.</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "9081") + @"</td></tr>";
        //strDesc = strDesc + "<tr><td style='font-size:10px;'>Address</td><td style='font-size:9px;'>" + dtnew.Rows[0][35].ToString() + "  " + dtnew.Rows[0][37].ToString() + "  " + dtnew.Rows[0][38].ToString() + "  " + dtnew.Rows[0][39].ToString() + "  " + Statename + " " + CountryName + " " + dtnew.Rows[0][41].ToString() + @"</td><td></td><td></td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Email</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "21") + @"</td><td style='font-size:10px;font-weight:bold'>Ward/Circle</td><td style='font-size:9px;'>" + objbllStoreTrans.SelectData_ConstID(Session["NameID"].ToString(), "22") + "</td></tr>";
        strDesc = strDesc + "<tr><td style='font-size:10px;font-weight:bold'>Address</td><td style='font-size:9px;' colspan='2'>" + Add + @"</td><td></td></tr>";


        strDesc = strDesc + "</table>";
        //strDesc = strDesc + "<table><tr><td>-------------------------------------------------------------------------------------------------------------------------------</td></tr></table>";
        // strDesc = strDesc + "<table><tr><td style='text-align:center;text-decoration:underline;font-size:11px;'>STATEMENT OF INCOME</td></tr></table>";
        //string Name = dtnew.Rows[0][4].ToString() + "  " + dtnew.Rows[0][5].ToString();
        string Footer = "<br/><br/><br/><table><tr><td style='text-align:center;font-size:9px;text-align:right'></td></tr></table><table><tr><td style='text-align:center;font-size:9px;text-align:right;font-weight:bold'>[" + name + @"]</td></tr></table>";
        Footer = Footer + "<table><tr><td style='text-align:center;text-decoration:underline;font-size:9px;font-style:italic;'>This pdf is generated by echarteredaccountants.com</td></tr></table>";

        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream(strFilepath + "/" + name + "_" + Session["AY"].ToString() + ".pdf", FileMode.Create));


        document.Open();




        HTMLWorker worker = new HTMLWorker(document);
        //ltStatement.Text = strDesc + ltStatement.Text;
        string strIncomeDesc = ltStatement.Text;
        //  strIncomeDesc = strIncomeDesc.Replace("<center><B>STATEMENT OF INCOME</B></center>", ");
        strIncomeDesc = strIncomeDesc.Replace("<td style='text-align:center;text-decoration:underline;font-size:11px;font-weight:bold'>STATEMENT OF INCOME</td>", "<td style='text-align:center;text-decoration:underline;font-size:15px;font-weight:bold'>STATEMENT OF INCOME</td>");
        strIncomeDesc = strIncomeDesc.Replace("<td style='text-align:center;text-decoration:underline;font-size:11px;font-weight:bold'>Tax Computation</td>", "<td style='text-align:center;text-decoration:underline;font-size:15px;font-weight:bold'>Tax Computation</td>");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;", "");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/rupee-symbol_small.png' style='height:10px'/>&nbsp;", "<img src='../images/spacer.png' /><img src='../images/rupee-symbol_small.png' style='height:5px'/>&nbsp;");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/spacer1.png' /><img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;", "");
        //strIncomeDesc = strIncomeDesc.Replace("rupee-symbol_small.png", "rp.png");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/rupee-symbol_small.png' style='height:9px'/>&nbsp;", "");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/spacer.png' >", "");
        strIncomeDesc = strIncomeDesc.Replace("<img src='../images/spacer1.png'/>", "");
        strIncomeDesc = strIncomeDesc.Replace("<td style='font-size:15px;text-align:right'>", "<td style='font-size:14px;text-align:right;vertical-align:top'>");
        strIncomeDesc = strIncomeDesc.Replace("<td style='font-size:15px;text-align:right'>", "<td style='font-size:14px;text-align:right;vertical-align:top'>");
        strIncomeDesc = strIncomeDesc.Replace("12px", "9px;");
        strIncomeDesc = strIncomeDesc.Replace("14px", "10px;");
        strIncomeDesc = strIncomeDesc.Replace("17px", "10px;");
        strIncomeDesc = strIncomeDesc.Replace("15px", "10px;");
        strIncomeDesc = strIncomeDesc.Replace(" <td style='font-size:14px'>", "<td style='font-size:14px;width:1500px'>");
        strIncomeDesc = strIncomeDesc.Replace("  <td style='font-size:14px;'>", "<td style='font-size:14px;width:1500px'>");
        // strIncomeDesc = strIncomeDesc.Replace("<img src='../images/rupee-symbol_small.png' style='height:10px'/>", "<img src='../images/spacer.png' style='height:10px'/><img src='../images/rupee-symbol_small.png' style='height:9px; width:9px;' width='4px'/>");
        //strIncomeDesc.Replace("text-align:right", "text-align:left");

        // strIncomeDesc = strIncomeDesc.Replace("<td style=' font-size:15px;text-align:right;text-decoration:underline  '>&nbsp;Deductions Claimed</td>", "<td style=' font-size:15px;text-decoration:underline  '>&nbsp;Deductions Claimed</td>");
        strIncomeDesc = strIncomeDesc.Replace("&nbsp;", "");
        // strIncomeDesc = strIncomeDesc.Replace("text-align:right", "");
        strIncomeDesc = strIncomeDesc.Replace("font-weight:bold;", "font-weight:15px");
        strIncomeDesc = strIncomeDesc.Replace("15px", "10px;");
        strIncomeDesc = strIncomeDesc.Replace("<td>", "<td style='font-size:10px;'>");
        strIncomeDesc = strIncomeDesc.Replace("<td STYLE='font-weight:bold;'>", "<td STYLE='font-weight:bold;font-size:10px;'>");
        //strIncomeDesc = strIncomeDesc.Replace("td style='font-size:14px; text-align:right", "td style='font-size:12px; margin-left:300px");
        string FloatData = getFloatData();
        DataTable dt4 = new DataTable();
        dt4 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 9079);
        string BankDetails = "";
        if (dt4.Rows.Count > 0)
        {
            BankDetails = "<br/><table border='1'><tr><td style='font-size:10px;text-align:center;font-weight:bold'>Bank Name</td><td style='font-size:10px;text-align:center;font-weight:bold'>Account Number</td><td style='font-size:10px;text-align:center;font-weight:bold'>IFSC Code</td><td style='font-size:10px;text-align:center;font-weight:bold'>Account Type</td></tr>";
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                if (dt4.Rows[i]["col6"].ToString() == "SAV")
                {
                    dt4.Rows[i]["col6"] = "Saving";
                }
                else if (dt4.Rows[i]["col6"].ToString() == "CURR")
                {
                    dt4.Rows[i]["col6"] = "Current";
                }
                BankDetails = BankDetails + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:center'>" + dt4.Rows[i]["col4"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center'>" + dt4.Rows[i]["col5"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center'>" + dt4.Rows[i]["col3"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center'>" + dt4.Rows[i]["col6"].ToString() + "</td></tr>";
            }

            BankDetails = BankDetails + "</table>";
        }
        else if (Session["ay"].ToString() == "2014-2015")
        {
            bllSalary objbllSalary = new bllSalary();
            string BankType = objbllSalary.getDataForConstID_String("25", Session["NameId"].ToString());
            if (BankType == "SAV")
            {
                BankType = "Saving";
            }
            else if (BankType == "CURR")
            {
                BankType = "Current";
            }
            BankDetails = "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'><tr><td style='text-align:center;font-size:10px;font-weight:bold'>Bank Detail</td></tr></table><table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'>";

            BankDetails += @"<tr><td style='font-size:10px;'>Bank Account number</td>
                    <td style='font-size:10px;text-align:right'>" +
                                     objbllSalary.getDataForConstID_String("23", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
            BankDetails += @"<tr><td style='font-size:10px;'>IFSC Code</td>
                    <td style='font-size:10px;text-align:right'>" +
                             objbllSalary.getDataForConstID_String("24", Session["NameId"].ToString()) + @"
                    </td>
                    </tr>";
            BankDetails += @"<tr><td style='font-size:10px;'>Type of Account</td>
                    <td style='font-size:10px;text-align:right'>" +
                             BankType + @"
                    </td>
                    </tr>";
            BankDetails += "</table>";
        }
        string Schedule_AL = getScduleAL();
        worker.Parse(new StringReader(strDesc + BankDetails + strIncomeDesc + FloatData +Schedule_AL+ Footer));

        document.Close();
        FileStream fs = new FileStream(strFilepath + "/" + name + "_" + Session["AY"].ToString() + ".pdf", FileMode.Open, FileAccess.Read);
        byte[] ar = new byte[(int)fs.Length];
        fs.Read(ar, 0, (int)fs.Length);
        fs.Close();
        //string Extension = Path.GetExtension("d:\\IncomeStatement.pdf");
        string type = string.Empty;
        type = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + name + "_" + Session["AY"].ToString() + ".pdf");
        Response.ContentType = type;
        Response.BinaryWrite(ar);
        Response.End();
        //document.Close();
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('PDF Uploaded sucessfully');", true);
    }

    [WebMethod]
    public static void AbandonSession()
    {
        Presentation_income_statement objPresentation_Main = new Presentation_income_statement();
        string ss = HttpContext.Current.Request.UrlReferrer.ToString();
        if (HttpContext.Current.Session["inc"] == null)
        {
            //HttpContext.Current.Response.Redirect("Logout.aspx");
            //HttpContext.Current.Session.Abandon();
            //Presentation_DisplayForm objPresentation_DisplayForm = new Presentation_DisplayForm();
            bllAssessee objbllAssessee = new bllAssessee();
            if (HttpContext.Current.Session["NameID"] != null && HttpContext.Current.Session["AY"] != null)
                objbllAssessee.DeleteFromStoreTrans(HttpContext.Current.Session["NameID"].ToString(), HttpContext.Current.Session["AY"].ToString());

            //HttpContext.Current.Response.Redirect("Logout.aspx");
            objPresentation_Main.Logout();
        }
        else
            HttpContext.Current.Session["inc"] = null;
    }

    public void Logout()
    {
        balAdmin objbalAdmin = new balAdmin();
        if (HttpContext.Current.Session.SessionID != null)
        {
            objbalAdmin.logoutUser();
        }
        string Project_Session = "";
        string reason_logout = "";

        if (Session["User_ID"] == null)
            Response.Redirect("Login.aspx");
        if (Session["Project"] != null)
            Project_Session = Session["Project"].ToString();
        if (Session["reason_logout"] != null)
            reason_logout = Session["reason_logout"].ToString();

        //balAdmin objbalAdmin = new balAdmin();
        int lastID = objbalAdmin.getLastLoginID(Convert.ToInt32(Session["User_ID"]));   // this is the last ID for tbl_User_Session_Details table and this to set the Logout Status for the same record for the user
        Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
        tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        objtbl_UserGroupRegistration.Logout_Time = DateTime.Now.ToString();
        objtbl_UserGroupRegistration.Logout_Nature = "LogOff";
        objtbl_UserGroupRegistration.Super_User_Id = Convert.ToInt32(Session["User_ID"]);
        objtbl_UserGroupRegistration.Time_OutID = lastID;
        objBltbl_UserGroupRegistration.Update_Logout_Time(objtbl_UserGroupRegistration);

        Session.Clear();
        Session.Abandon();
        Session["Project"] = Project_Session;
        string strRedirect = "Login.aspx";
        if (reason_logout != "")
        {
            Session["reason_logout"] = reason_logout.ToString();
            strRedirect = "Login.aspx?reason_logout=sa";
        }
        //Response.Redirect("login.aspx");
        //Response.Redirect("../Default.aspx");
        //Response.Redirect(strRedirect);
    }

    public void setEligibleDeductions()
    {
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        objbllStoreTrans.setEligibleDeductions(Session["NameID"].ToString(), Session["AY"].ToString(), Session["NameID"].ToString(), Session["ITR"].ToString());
    }

    public void calcTax()
    {
        decimal gIFS, gIFHP, gIFBUS, gIFSTCG, gIFLTCG, gIFOS, gDED, gDED1, gICE, gAI, gTDS, gTCS, gSelfAss, gATP, gCasuInc, gCLUB, gRelief, gTI, gGIT, gNIT, gSum_234, gSur, gEduCess, gRebate87A;
        gIFS = 0; gIFHP = 0; gIFBUS = 0; gIFSTCG = 0; gIFLTCG = 0; gIFOS = 0; gDED = 0; gDED1 = 0; gICE = 0; gAI = 0; gTDS = 0; gTCS = 0; gSelfAss = 0; gATP = 0; gCasuInc = 0; gCLUB = 0; gRelief = 0; gTI = 0; gGIT = 0; gNIT = 0; gSum_234 = 0;
        gSur = 0; gRebate87A = 0;
        gEduCess = 0;
        bllSalary objbllSalary = new bllSalary();
        objbllSalary.SetAllZero(Session["NameID"].ToString(), 49, Session["ay"].ToString(), Session["NameID"].ToString(), Convert.ToInt32(0), Convert.ToInt16(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(0), 0);
        objbllSalary.calTaxNew(Session["NameID"].ToString(), Session["ay"].ToString(), 49, (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString()), Convert.ToInt32(((Session["Project"].ToString() != "vtax") ? 0 : 1)));

        Label lblNetTaxPayable = new Label();
        lblNetTaxPayable.Text = gNIT.ToString(); //(gNIT + gSum_234).ToString();

    }
    public string getFloatData()
    {
        string Total = "", TDSonSalary_Detail = "", TDSonOthThanSalary_Detail = "", AdvanceTaxansSelfAssTax = "", TaxCollectedatSource = "", BankDetails = "", Donationsentitled = "", Donationsentitled50 = "", Donationsentitled100GTI = "", Donationsentitled50GTI = "", Presumptive_Income_44AD = "", Presumptive_Income_44AE = "";
        double amount = 0;
        objFloatingBLL = new bllFloating();
        DataTable dt = new DataTable();
        dt = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 802);
        if (dt.Rows.Count > 0)
        {
            TDSonSalary_Detail = "<table ><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Details of TDS on Salary</td></tr></table><br/><table style='border:2px solid black;' border='1'><tr style='border:2px solid black;'><td style='font-size:10px;text-align:center;;font-weight:bold;'>Name of the Employer</td><td style='font-size:10px;text-align:center;font-weight:bold;'>TAN</td><td style='font-size:10px;text-align:center;font-weight:bold;text-align:center'>Salary (Rs.)</td><td style='font-size:10px;text-align:center;font-weight:bold;'>TDS on Salary (Rs.)</td></tr>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TDSonSalary_Detail = TDSonSalary_Detail + "<tr style='border:2px solid black;'><td style='font-size:9px;text-align:center;'>" + dt.Rows[i]["col4"].ToString() + "</td><td style='font-size:9px;text-align:center'>" + dt.Rows[i]["col3"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt.Rows[i]["col7"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt.Rows[i]["col13"].ToString() + "</td></tr>";
            }

            TDSonSalary_Detail = TDSonSalary_Detail + "</table>";
        }
        //tds on income other than salary
        DataTable dt1 = new DataTable();
        dt1 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 788);
        if (dt1.Rows.Count > 0)
        {
            TDSonOthThanSalary_Detail = "<table><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Details of TDS on Income Other than Salary</td></tr></table><br/><table style='border:1px solid black;' border='1'><tr border:1px solid black;><td style='font-size:10px;text-align:center;font-weight:bold;'>Name of the Deductor</td><td style='font-size:10px;text-align:center;font-weight:bold;'>TAN</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Tax Deducted</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Claimed Tax (Rs.)</td></tr>";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                TDSonOthThanSalary_Detail = TDSonOthThanSalary_Detail + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:center;'>" + dt1.Rows[i]["col5"].ToString() + "</td><td style='font-size:9px;text-align:center'>" + dt1.Rows[i]["col3"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt1.Rows[i]["col13"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt1.Rows[i]["col13"].ToString() + "</td></tr>";
            }

            TDSonOthThanSalary_Detail = TDSonOthThanSalary_Detail + "</table>";
        }
        //Advance Tax and Self Assessment Tax
        DataTable dt2 = new DataTable();
        dt2 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 787);
        if (dt2.Rows.Count > 0)
        {
            AdvanceTaxansSelfAssTax = "<table><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Advance Tax and Self Assessment Tax</td></tr></table><br/><table style='border:1px solid black;' border='1'><tr><td style='font-size:10px;text-align:center;font-weight:bold;'>BSR Code</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Date of Deposit</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Challan Serial</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Amount (Rs.)</td></tr>";
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                AdvanceTaxansSelfAssTax = AdvanceTaxansSelfAssTax + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:center;'>" + dt2.Rows[i]["col4"].ToString() + "</td><td style='font-size:9px;text-align:center;'>" + dt2.Rows[i]["col6"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center;'>" + dt2.Rows[i]["col12"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt2.Rows[i]["col13"].ToString() + "</td></tr>";
            }

            AdvanceTaxansSelfAssTax = AdvanceTaxansSelfAssTax + "</table>";
        }
        //Tax Collected at Source 
        DataTable dt3 = new DataTable();
        dt3 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 801);
        if (dt3.Rows.Count > 0)
        {
            TaxCollectedatSource = "<table><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Tax Collected at Source</td></tr></table><br/><table style='border:1px solid black;' border='1'><tr><td style='font-size:10px;text-align:center;font-weight:bold;'>TAN</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Tax Collected</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Tax Claimed</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Amount Claimed by Spouse (Rs.)</td></tr>";
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                TaxCollectedatSource = TaxCollectedatSource + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:center;'>" + dt3.Rows[i]["col3"].ToString() + "</td><td style='font-size:9px;text-align:center;'>" + dt3.Rows[i]["col5"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt3.Rows[i]["col13"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt3.Rows[i]["col14"].ToString() + "</td></tr>";
            }

            TaxCollectedatSource = TaxCollectedatSource + "</table>";
        }
        //Bank Detail
        //DataTable dt4 = new DataTable();
        //dt4 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 9079);
        //if (dt4.Rows.Count > 0)
        //{
        //    BankDetails = "<table><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Bank Details</td></tr></table><br/><table border='1'><tr><td style='font-size:10px;text-align:center'>IFSC Code</td><td style='font-size:10px;text-align:center'>Bank Name</td><td style='font-size:10px;text-align:center'>Account Number</td><td style='font-size:10px;text-align:center'>Account Type</td></tr>";
        //    for (int i = 0; i < dt4.Rows.Count; i++)
        //    {
        //        BankDetails = BankDetails + "<tr style='border:1px solid black;'><td style='font-size:9px'>" + dt4.Rows[i]["col3"].ToString() + "</td><td style='font-size:9px'>" + dt4.Rows[i]["col4"].ToString() + "</td>" + "<td style='font-size:9px'>" + dt4.Rows[i]["col5"].ToString() + "</td>" + "<td style='font-size:9px'>" + dt4.Rows[i]["col6"].ToString() + "</td></tr>";
        //    }

        //    BankDetails = BankDetails + "</table>";
        //}
        //Donationsentitled for 100% deduction
        DataTable dt5 = new DataTable();
        dt5 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 1001);
        if (dt5.Rows.Count > 0)
        {
            Donationsentitled = "<table><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Donations entitled for 100% deduction</td></tr></table><br/><table style='border:1px solid black;' border='1'><tr style='border:1px solid black;'><td style='font-size:10px;text-align:center;font-weight:bold;'>Name of Donee</td><td style='font-size:10px;text-align:center;font-weight:bold;'>PAN</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Address</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Amount (Rs.)</td></tr>";
            for (int i = 0; i < dt5.Rows.Count; i++)
            {
                Donationsentitled = Donationsentitled + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:center;'>" + dt5.Rows[i]["col3"].ToString() + "</td><td style='font-size:9px;text-align:center;'>" + dt5.Rows[i]["col4"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center;'>" + dt5.Rows[i]["col5"].ToString() +", "+ dt5.Rows[i]["col6"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt5.Rows[i]["col10"].ToString() + "</td></tr>";
            }

            Donationsentitled = Donationsentitled + "</table>";
        }
        //Donationsentitled for 50% deduction
        DataTable dt6 = new DataTable();
        dt6 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 1002);
        if (dt6.Rows.Count > 0)
        {
            Donationsentitled50 = "<table><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Donations entitled for 50% deduction</td></tr></table><br/><table style='border:1px solid black;' border='1'><tr><td style='font-size:10px;text-align:center;font-weight:bold;'>Name of Donee</td><td style='font-size:10px;text-align:center;font-weight:bold;'>PAN</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Address</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Amount (Rs.)</td></tr>";
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                Donationsentitled50 = Donationsentitled50 + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:center;'>" + dt6.Rows[i]["col3"].ToString() + "</td><td style='font-size:9px;text-align:center;'>" + dt6.Rows[i]["col4"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center;'>" + dt6.Rows[i]["col5"].ToString() +", "+ dt6.Rows[i]["col6"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt6.Rows[i]["col10"].ToString() + "</td></tr>";
            }

            Donationsentitled50 = Donationsentitled50 + "</table>";
        }
        //Donationsentitled for 100% deduction subject to GTI
        DataTable dt7 = new DataTable();
        dt7 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 1003);
        if (dt7.Rows.Count > 0)
        {
            Donationsentitled100GTI = "<table><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Donations entitled for 100% deduction subject to GTI</td></tr></table><br/><table style='border:1px solid black;' border='1'><tr><td style='font-size:10px;text-align:center;font-weight:bold;'>Name of Donee</td><td style='font-size:10px;text-align:center;font-weight:bold;'>PAN</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Address</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Amount (Rs.)</td></tr>";
            for (int i = 0; i < dt7.Rows.Count; i++)
            {
                Donationsentitled100GTI = Donationsentitled100GTI + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:center;'>" + dt7.Rows[i]["col3"].ToString() + "</td><td style='font-size:9px;text-align:center;'>" + dt7.Rows[i]["col4"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center;'>" + dt7.Rows[i]["col5"].ToString() +", "+ dt7.Rows[i]["col6"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt7.Rows[i]["col10"].ToString() + "</td></tr>";
            }

            Donationsentitled100GTI = Donationsentitled100GTI + "</table>";
        }
        //Donationsentitled for 50% deduction subject to GTI
        DataTable dt8 = new DataTable();
        dt8 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 1031);
        if (dt8.Rows.Count > 0)
        {
            Donationsentitled50GTI = "<table><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Donations entitled for 50% deduction subject to GTI</td></tr></table><br/><table style='border:1px solid black;' border='1'><tr><td style='font-size:10px;text-align:center;font-weight:bold;'>Name of Donee</td><td style='font-size:10px;text-align:center;font-weight:bold;'>PAN</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Address</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Amount (Rs.)</td></tr>";
            for (int i = 0; i < dt8.Rows.Count; i++)
            {
                Donationsentitled50GTI = Donationsentitled50GTI + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:center;'>" + dt8.Rows[i]["col3"].ToString() + "</td><td style='font-size:9px;text-align:center;'>" + dt8.Rows[i]["col4"].ToString() + "</td>" + "<td style='font-size:9px;text-align:center;'>" + dt8.Rows[i]["col5"].ToString() +", "+ dt8.Rows[i]["col6"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt8.Rows[i]["col10"].ToString() + "</td></tr>";
            }

            Donationsentitled50GTI = Donationsentitled50GTI + "</table>";
        }
        //Presumptive_Income_44AE
        DataTable dt9 = new DataTable();
        dt9 = objFloatingBLL.SelectFloatData(Session["ay"].ToString(), Session["NameID"].ToString(), 9098);
        if (dt9.Rows.Count > 0)
        {
            Presumptive_Income_44AE = "<table><tr><td style='font-size:10px;text-decoration:underline;font-weight:bold;'>Presumptive_Income_44AE</td></tr></table><br/><table style='border:1px solid black;' border='1'><tr><td style='font-size:10px;text-align:center;font-weight:bold;'>Sr No.</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Holding Period (in months)</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Income per Vehicle</td><td style='font-size:10px;text-align:center;font-weight:bold;'>Deemed Income</td></tr>";
            for (int i = 0; i < dt9.Rows.Count; i++)
            {
                Presumptive_Income_44AE = Presumptive_Income_44AE + "<tr style='border:1px solid black;'><td style='font-size:9px;text-align:left;'>" + (i+1)+ "</td><td style='font-size:9px;text-align:left;'>" + dt9.Rows[i]["col3"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right;'>" + dt9.Rows[i]["col4"].ToString() + "</td>" + "<td style='font-size:9px;text-align:right'>" + dt9.Rows[i]["col5"].ToString() + "</td></tr>";
            }

            Presumptive_Income_44AE = Presumptive_Income_44AE + "</table>";
        }
        bllSalary objbllSalary = new bllSalary();
        amount = objbllSalary.getDataForConstID("9106", Session["NameId"].ToString());
        if (amount > 0)
        {

            Presumptive_Income_44AD += "<tr><td border='1' style='font-size:9px;text-align:left;'>Gross Turnover/Receipt</td><td border='1' style='font-size:9px;text-align:right;'>" + amount.ToString() + "</td></tr>";
            //    Presumptive_Income_44AD += @"<table><tr><td>Gross Turnover/Receipt</td><td>"++@";</td><td>Sundry Debtors</td><td>Amount</td></tr>";
            //    Presumptive_Income_44AD += @"<table><tr><td>Net Profit</td><td>Amount</td><td>Sundry Creditors</td><td>Amount</td></tr>";
            //    Presumptive_Income_44AD += @"<table><tr><td></td><td>Amount</td><td>Stock-in-Trade</td><td>Amount</td></tr>";
            //    Presumptive_Income_44AD += @"<table><tr><td></td><td>Amount</td><td>Cash Balance</td><td>Amount</td></tr>";
            //}
        }
        amount = objbllSalary.getDataForConstID("9107", Session["NameId"].ToString());
        if (amount > 0)
        {
            Presumptive_Income_44AD += "<tr><td border='1' style='font-size:9px;text-align:left;'>Net Profit</td><td border='1' style='font-size:9px;text-align:right;'>" + amount.ToString() + "</td></tr>";
        }
        amount = objbllSalary.getDataForConstID("9094", Session["NameId"].ToString());
        if (amount > 0)
        {
            Presumptive_Income_44AD += "<tr><td border='1' style='font-size:9px;text-align:left;'>Sundry Debtors</td><td border='1' style='font-size:9px;text-align:right;'>" + amount.ToString() + "</td></tr>";
        }
        amount = objbllSalary.getDataForConstID("9095", Session["NameId"].ToString());
        if (amount > 0)
        {
            Presumptive_Income_44AD += "<tr><td border='1' style='font-size:9px;text-align:left;'>Sundry Creditors</td><td border='1' style='font-size:9px;text-align:right;'>" + amount.ToString() + "</td></tr>";
        }
        amount = objbllSalary.getDataForConstID("9096", Session["NameId"].ToString());
        if (amount > 0)
        {
            Presumptive_Income_44AD += "<tr><td border='1' style='font-size:9px;text-align:left;'>Stock-in-Trade</td><td border='1' style='font-size:9px;text-align:right;'>" + amount.ToString() + "</td></tr>";
        }
        amount = objbllSalary.getDataForConstID("9097", Session["NameId"].ToString());
        if (amount > 0)
        {
            Presumptive_Income_44AD += "<tr><td border='1' style='font-size:9px;text-align:left;'>Cash Balance</td><td border='1' style='font-size:9px;text-align:right;'>" + amount.ToString() + "</td></tr>";
        }
        if (Presumptive_Income_44AD != "")
        {
            Presumptive_Income_44AD = "<table><tr><td style='font-weight:bold;text-decoration:underline;font-size:9px;' >Presumptive Income U/S 44AD (No books case)</td></tr></table> <table><tr><td border='1' style='font-size:9px;text-align:center;font-weight:bold'>Particulars</td><td border='1' style='font-size:9px;text-align:center;font-weight:bold'>Amount (Rs.)</td></tr>" + Presumptive_Income_44AD + "</table>";
        }
        Total = TDSonSalary_Detail + TDSonOthThanSalary_Detail + AdvanceTaxansSelfAssTax + TaxCollectedatSource + BankDetails + Donationsentitled + Donationsentitled50 + Donationsentitled100GTI + Donationsentitled50GTI + Presumptive_Income_44AD + Presumptive_Income_44AE;
        if (Total != "")
        {
            return "----------------------------------------------------------------------------------------------------------------------------------<table><tr><td style='text-align:center;text-decoration:underline;font-size:11px;font-weight:bold'>ANNXURES</td></tr></table>" + Total;
        }
        else
        {
            return Total;
        }
        //return Total;
    }
    protected void lbtnEditProf_Click(object sender, EventArgs e)
    {
        //Session["Mode"] = "Edit";
        //Session["InternalSal"] = "true";
        //Response.Redirect("Salary.aspx?vtype=106");

        Session["Mode"] = "Edit";
        Session["InternalSal"] = "true";
        Session["IncomeTax_VType"] = "106";
        Response.Redirect("Profile");
    }

    protected void btnCA_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../PersonalInfo.aspx");
        Response.Redirect("ECA_Details.aspx");
       // Response.Redirect("../PersonalInfo.aspx?page=1");
    }
  
    //get schedule AL
    public string getScduleAL()
    {
        string ScheduleAL = "";
        double amt = 0;
        bllSalary objbllSalary = new bllSalary();
        ScheduleAL += "<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0' >";
        if (objbllSalary.getDataForConstID("9085", Session["NameId"].ToString()) > 0)
        {
            ScheduleAL += "<tr><td style='font-size:12px;text-align:center;font-weight:bold;'>Schedule AL </td></tr></table>";

        }
        amt = objbllSalary.getDataForConstID("9085", Session["NameId"].ToString());    //Land
        if (amt > 0)
        {
            ScheduleAL += @"<table width='100%'  cellpadding='0' cellspacing='0'  style='border: solid 1px white;margin:0;padding:0'  ><tr><td style='font-size:9px;'></td><td style='font-size:9px;text-align:right; font-weight:bold'>Amount (Rs.)</td></tr><tr><td style='font-size:9px;'>Land</td><td style='font-size:9px;text-align:right'>" +
                                     amt.ToString() + @"</td></tr>";
        }
        amt = objbllSalary.getDataForConstID("9086", Session["NameId"].ToString());    //Building
        if (amt > 0)
            ScheduleAL += @"<tr><td style='font-size:9px;'>Building</td>
                   <td style='font-size:9px;text-align:right'>" +
                                     amt.ToString() + @"
                    </td>
                
                    </tr>";
        amt = objbllSalary.getDataForConstID("9087", Session["NameId"].ToString());    //Cash in hand
        if (amt > 0)
            ScheduleAL += @"<tr><td style='font-size:9px;'>Cash in hand</td>
                    <td style='font-size:9px;text-align:right'>" +
                                     amt.ToString() + @"
                    </td>
                
                    </tr>";
        amt = objbllSalary.getDataForConstID("9088", Session["NameId"].ToString());    //Jewellery, Bullion etc
        if (amt > 0)
            ScheduleAL += @"<tr><td style='font-size:9px;'>Jewellery, Bullion etc)</td>
                    <td style='font-size:9px;text-align:right'>" +
                                     amt.ToString() + @"
                    </td>
                 
                    </tr>";
        amt = objbllSalary.getDataForConstID("9089", Session["NameId"].ToString());    //Vehicles, Yachts, Boats and Aircrafts
        if (amt > 0)
            ScheduleAL += @"<tr><td style='font-size:9px;'>Vehicles, Yachts, Boats and Aircrafts</td>
                     <td style='font-size:9px;text-align:right'>" +
                                     amt.ToString() + @"
                    </td>
                 
                    </tr>";
        amt = objbllSalary.getDataForConstID("9091", Session["NameId"].ToString());    //Liability in relation to Assets
        if (amt > 0)
            ScheduleAL += @"<tr><td style='font-size:9px;'>Liability in relation to Assets</td>
                   <td style='font-size:9px;text-align:right'>" +
                                     amt.ToString() + @"
                    </td>
                
                    </tr>";
        ScheduleAL+="</table>";
        return ScheduleAL;

    }
}
