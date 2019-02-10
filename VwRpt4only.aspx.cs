using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Xml;

public partial class VwRpt4only : System.Web.UI.Page
{
    string filePath,filepathdemo;
    DataSet ds = new DataSet();
    DataSet dsdemo = new DataSet();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filePath = Server.MapPath(Request.QueryString["nid"].ToString()+".xml");
            filepathdemo = Server.MapPath("~/DemoXMLs/itr4demo.xml");
            ds.ReadXml(filePath);
            dsdemo.ReadXml(filepathdemo);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ITR4.rdlc");
            //get personal info data
            ReportDataSource datasourcePersonalInfo = new ReportDataSource("PersonalInfo", ds.Tables["PersonalInfo"]);
            //get assessee name data
            ReportDataSource datasourceAssesseeName = new ReportDataSource("AssesseeName", ds.Tables["AssesseeName"]);
            ReportDataSource datasourceA = new ReportDataSource("Address", ds.Tables["Address"]);
            //get filing status
            ReportDataSource datasourceFS;
            if (ds.Tables.Contains("FilingStatus"))
            {
                 datasourceFS = new ReportDataSource("FilingStatus", ds.Tables["FilingStatus"]);
            }
            else
            {
                 datasourceFS = new ReportDataSource("FilingStatus", dsdemo.Tables["FilingStatus"]);
            }
            //interest Pay
            ReportDataSource datasourceIntrstPay;
            if (ds.Tables.Contains("IntrstPay"))
            {
               datasourceIntrstPay = new ReportDataSource("IntrstPay", ds.Tables["IntrstPay"]);
            }
            else
            {
                datasourceIntrstPay = new ReportDataSource("IntrstPay", dsdemo.Tables["IntrstPay"]);
            }
            //TaxesPaid
            ReportDataSource datasourceTaxesPaid;
            if (ds.Tables.Contains("TaxesPaid"))
            {
               datasourceTaxesPaid = new ReportDataSource("TaxesPaid", ds.Tables["TaxesPaid"]);
            }
            else
            {
                 datasourceTaxesPaid = new ReportDataSource("TaxesPaid", dsdemo.Tables["TaxesPaid"]);
            }
            //TaxesPaid
            ReportDataSource datasourceTaxPaid;
            if (ds.Tables.Contains("TaxPaid"))
            {
                datasourceTaxPaid = new ReportDataSource("TaxPaid", ds.Tables["TaxPaid"]);
            }
            else
            {
                 datasourceTaxPaid = new ReportDataSource("TaxPaid", dsdemo.Tables["TaxPaid"]);
            }
            //BankAccountDtls
            ReportDataSource datasourceBankAccountDtls;
            if (ds.Tables.Contains("BankAccountDtls"))
            {
                 datasourceBankAccountDtls = new ReportDataSource("BankAccountDtls", ds.Tables["BankAccountDtls"]);
            }
            else
            {
                 datasourceBankAccountDtls = new ReportDataSource("BankAccountDtls", dsdemo.Tables["BankAccountDtls"]);
            }
            //PriBankDetails
            ReportDataSource datasourcePriBankDetails;
            if (ds.Tables.Contains("PriBankDetails"))
            {
                 datasourcePriBankDetails = new ReportDataSource("PriBankDetails", ds.Tables["PriBankDetails"]);
            }
            else
            {
                 datasourcePriBankDetails = new ReportDataSource("PriBankDetails", dsdemo.Tables["PriBankDetails"]);
            }
            //  AddtnlBankDetails
            ReportDataSource datasourceAddtnlBankDetails;
            if (ds.Tables.Contains("AddtnlBankDetails"))
            {
                 datasourceAddtnlBankDetails = new ReportDataSource("AddtnlBankDetails", ds.Tables["AddtnlBankDetails"]);
            }
            else
            {
                 datasourceAddtnlBankDetails = new ReportDataSource("AddtnlBankDetails", dsdemo.Tables["AddtnlBankDetails"]);
            }
            //BankAccountsDtls
            ReportDataSource datasourceBankAccountsDtls;
            if (ds.Tables.Contains("BankAccountsDtls"))
            {
               datasourceBankAccountsDtls = new ReportDataSource("BankAccountsDtls", ds.Tables["BankAccountsDtls"]);
            }
            else
            {
              datasourceBankAccountsDtls = new ReportDataSource("BankAccountsDtls", dsdemo.Tables["BankAccountsDtls"]);
            }
            //Declaration
            ReportDataSource datasourceDeclaration = new ReportDataSource("Declaration", ds.Tables["Declaration"]);
            //Verification
            ReportDataSource datasourceVerification = new ReportDataSource("Verification", ds.Tables["Verification"]);
            //TaxPayment
            ReportDataSource datasourceTaxPayment;
            if (ds.Tables.Contains("TaxPayment"))
            {
                datasourceTaxPayment = new ReportDataSource("TaxPayment", ds.Tables["TaxPayment"]);
            }
            else
            {
               
                datasourceTaxPayment = new ReportDataSource("TaxPayment", dsdemo.Tables["TaxPayment"]);
            }
            //EmployerorDeductor
            ReportDataSource datasourceEmployerorDeductor;
            if (ds.Tables.Contains("EmployerOrDeductorOrCollectDetl"))
            {
                 datasourceEmployerorDeductor = new ReportDataSource("EmployerorDeductor", ds.Tables["EmployerOrDeductorOrCollectDetl"]);
            }
            else
            {
                 datasourceEmployerorDeductor = new ReportDataSource("EmployerorDeductor", dsdemo.Tables["EmployerOrDeductorOrCollectDetl"]);
            }
            // TDSonSalary
             ReportDataSource datasourceTDSonSalary;
            if (ds.Tables.Contains("TDSonSalary"))
            {
                 datasourceTDSonSalary = new ReportDataSource("TDSonSalary", ds.Tables["TDSonSalary"]);
            }
            else
            {
               datasourceTDSonSalary = new ReportDataSource("TDSonSalary", dsdemo.Tables["TDSonSalary"]);
            }
            //Refund
             ReportDataSource datasourceRefund;
            if (ds.Tables.Contains("Refund"))
            {
               datasourceRefund = new ReportDataSource("Refund", ds.Tables["Refund"]);

            }
            else
            {
                 datasourceRefund = new ReportDataSource("Refund", dsdemo.Tables["Refund"]);
            }
            //TDSonOthThanSal
            ReportDataSource datasourceTDSonOthThanSal;
            if (ds.Tables.Contains("TDSonOthThanSal"))
            {
                 datasourceTDSonOthThanSal = new ReportDataSource("TDSonOthThanSal", ds.Tables["TDSonOthThanSal"]);
            }
            else
            {
               datasourceTDSonOthThanSal = new ReportDataSource("TDSonOthThanSal", dsdemo.Tables["TDSonOthThanSal"]);
            }
            //Business
            ReportDataSource datasourceBusiness;
            if (ds.Tables.Contains("Business"))
            {
                 datasourceBusiness = new ReportDataSource("Business", ds.Tables["Business"]);
            }
            else
            {
                datasourceBusiness = new ReportDataSource("Business", dsdemo.Tables["Business"]);
            }
            // TaxReturnPreparer
            ReportDataSource datasourceTaxReturnPreparer;
            if (ds.Tables.Contains("TaxReturnPreparer"))
            {
                datasourceTaxReturnPreparer = new ReportDataSource("TaxReturnPreparer", ds.Tables["TaxReturnPreparer"]);
            }
            else
            {
                 datasourceTaxReturnPreparer = new ReportDataSource("TaxReturnPreparer", dsdemo.Tables["TaxReturnPreparer"]);
            }
            //Trade
            ReportDataSource datasourceTrade;
            if (ds.Tables.Contains("Trade"))
            {
                 datasourceTrade = new ReportDataSource("Trade", ds.Tables["Trade"]);
            }
            else
            {
                 datasourceTrade = new ReportDataSource("Trade", dsdemo.Tables["Trade"]);
            }
            // PersumptiveInc44AD
            ReportDataSource datasourcePersumptiveInc44AD;
            if (ds.Tables.Contains("PersumptiveInc44AD"))
            {
                 datasourcePersumptiveInc44AD = new ReportDataSource("PersumptiveInc44AD", ds.Tables["PersumptiveInc44AD"]);
            }
            else
            {
                datasourcePersumptiveInc44AD = new ReportDataSource("PersumptiveInc44AD", dsdemo.Tables["PersumptiveInc44AD"]);
            }
            //NoBooksOfAccBS
             ReportDataSource datasourceNoBooksOfAccBS;
            if (ds.Tables.Contains("NoBooksOfAccBS"))
            {
                datasourceNoBooksOfAccBS = new ReportDataSource("NoBooksOfAccBS", ds.Tables["NoBooksOfAccBS"]);
            }
            else
            {
                 datasourceNoBooksOfAccBS = new ReportDataSource("NoBooksOfAccBS", dsdemo.Tables["NoBooksOfAccBS"]);
            }
            //IncFromOS
             ReportDataSource datasourceIncFromOS;
            if (ds.Tables.Contains("IncFromOS"))
            {
            datasourceIncFromOS = new ReportDataSource("IncFromOS", ds.Tables["IncFromOS"]);
            }
            else
            {
                datasourceIncFromOS = new ReportDataSource("IncFromOS", dsdemo.Tables["IncFromOS"]);
            }
            //IncCYLA
            ReportDataSource datasourceIncCYLA ;
            if (ds.Tables.Contains("IncCYLA"))
            {
              datasourceIncCYLA = new ReportDataSource("IncCYLA", ds.Tables["IncCYLA"]);
            }
            else
            {
               datasourceIncCYLA = new ReportDataSource("IncCYLA", dsdemo.Tables["IncCYLA"]);
            }
            //PartBTI
             ReportDataSource datasourcePartBTI;
            if (ds.Tables.Contains("PartB-TI"))
            {
                 datasourcePartBTI = new ReportDataSource("PartBTI", ds.Tables["PartB-TI"]);
            }
            else
            {
               datasourcePartBTI = new ReportDataSource("PartBTI", dsdemo.Tables["PartB-TI"]);
            }
            ReportDataSource datasourceAssesseeRep;
            if (ds.Tables.Contains("AssesseeRep"))
            {
                 datasourceAssesseeRep = new ReportDataSource("AssesseeRep", ds.Tables["AssesseeRep"]);

            }
            else
            {
                datasourceAssesseeRep = new ReportDataSource("AssesseeRep", dsdemo.Tables["AssesseeRep"]);
            }
            //ComputationOfTaxLiability
             ReportDataSource datasourceComputationOfTaxLiability;
            if (ds.Tables.Contains("ComputationOfTaxLiability"))
            {
               datasourceComputationOfTaxLiability = new ReportDataSource("ComputationOfTaxLiability", ds.Tables["ComputationOfTaxLiability"]);
            }
            else
            {
              datasourceComputationOfTaxLiability = new ReportDataSource("ComputationOfTaxLiability", dsdemo.Tables["ComputationOfTaxLiability"]);
            }
            //TaxPayableOnTI
            ReportDataSource datasourceTaxPayableOnTI;
            if (ds.Tables.Contains("TaxPayableOnTI"))
            {

                 datasourceTaxPayableOnTI = new ReportDataSource("TaxPayableOnTI", ds.Tables["TaxPayableOnTI"]);
            }
            else
            {
                 datasourceTaxPayableOnTI = new ReportDataSource("TaxPayableOnTI", dsdemo.Tables["TaxPayableOnTI"]);
            }
            //Salaries
             ReportDataSource datasourceSalaries;
            if (ds.Tables.Contains("Salaries"))
            {
           datasourceSalaries
     = new ReportDataSource("Salaries", ds.Tables["Salaries"]);
            }
            else
            {
              datasourceSalaries
 = new ReportDataSource("Salaries", dsdemo.Tables["Salaries"]);
            }
            //AddressDetail
            ReportDataSource datasourceAddressDetail;
            if (ds.Tables.Contains("AddressDetail"))
            {
                 datasourceAddressDetail = new ReportDataSource("AddressDetail", ds.Tables["AddressDetail"]);
            }
            else
            {
                datasourceAddressDetail = new ReportDataSource("AddressDetail", dsdemo.Tables["AddressDetail"]);
            }
            // AuditInfo
            ReportDataSource datasourceAuditInfo;
            if (ds.Tables.Contains("AuditInfo"))
            {
                 datasourceAuditInfo = new ReportDataSource("AuditInfo", ds.Tables["AuditInfo"]);
            }
            else
            {
                 datasourceAuditInfo = new ReportDataSource("AuditInfo", dsdemo.Tables["AuditInfo"]);
            }
             ReportDataSource datasourceAuditDetails;
            if (ds.Tables.Contains("AuditDetails"))
            {
                 datasourceAuditDetails = new ReportDataSource("AuditDetails", ds.Tables["AuditDetails"]);
            }
            else
            {
                 datasourceAuditDetails = new ReportDataSource("AuditDetails", dsdemo.Tables["AuditDetails"]);
            }
            // TradeName
            ReportDataSource datasourceTradeName;
            if (ds.Tables.Contains("TradeName"))
            {
               datasourceTradeName = new ReportDataSource("TradeName", ds.Tables["TradeName"]);
            }
            else
            {
           datasourceTradeName = new ReportDataSource("TradeName", dsdemo.Tables["TradeName"]);
            }
            // PropFund
            ReportDataSource datasourcePropFund;
            if (ds.Tables.Contains("PropFund"))
            {
               datasourcePropFund = new ReportDataSource("PropFund", ds.Tables["PropFund"]);
            }
            else
            {
                 datasourcePropFund = new ReportDataSource("PropFund", dsdemo.Tables["PropFund"]);
            }
            // ResrNSurp
            ReportDataSource datasourceResrNSurp;
            if (ds.Tables.Contains("ResrNSurp"))
            {
                 datasourceResrNSurp = new ReportDataSource("ResrNSurp", ds.Tables["ResrNSurp"]);
            }
            else
            {
                 datasourceResrNSurp = new ReportDataSource("ResrNSurp", dsdemo.Tables["ResrNSurp"]);
            }
            //LoanFunds
            ReportDataSource datasourceLoanFunds;
            if (ds.Tables.Contains("LoanFunds"))
            {
                datasourceLoanFunds = new ReportDataSource("LoanFunds", ds.Tables["LoanFunds"]);
            }
            else
            {
              datasourceLoanFunds = new ReportDataSource("LoanFunds", dsdemo.Tables["LoanFunds"]);
            }
            //SecrLoan
            ReportDataSource datasourceSecrLoan;
            if (ds.Tables.Contains("SecrLoan"))
            {

                 datasourceSecrLoan = new ReportDataSource("SecrLoan", ds.Tables["SecrLoan"]);
            }
            else
            {
                datasourceSecrLoan = new ReportDataSource("SecrLoan", dsdemo.Tables["SecrLoan"]);
            }

            //RupeeLoan
            ReportDataSource datasourceRupeeLoan;
            if (ds.Tables.Contains("RupeeLoan"))
            {
         datasourceRupeeLoan = new ReportDataSource("RupeeLoan", ds.Tables["RupeeLoan"]);
            }
            else
            { datasourceRupeeLoan = new ReportDataSource("RupeeLoan", dsdemo.Tables["RupeeLoan"]);
            }
            // UnsecrLoan
            ReportDataSource datasourceUnsecrLoan;
            if (ds.Tables.Contains("UnsecrLoan"))
            {
           datasourceUnsecrLoan = new ReportDataSource("UnsecrLoan", ds.Tables["UnsecrLoan"]);
            }
            else{
                datasourceUnsecrLoan = new ReportDataSource("UnsecrLoan", dsdemo.Tables["UnsecrLoan"]);
            }

            // FundSrc
            ReportDataSource datasourceFundSrc;
             if (ds.Tables.Contains("FundSrc"))
            {
             datasourceFundSrc = new ReportDataSource("FundSrc", ds.Tables["FundSrc"]);
             }
             else
             {
                 datasourceFundSrc = new ReportDataSource("FundSrc", dsdemo.Tables["FundSrc"]);
             }
            //FixedAsset
            ReportDataSource datasourceFixedAsset;
             if (ds.Tables.Contains("FixedAsset"))
            {
            datasourceFixedAsset = new ReportDataSource("FixedAsset", ds.Tables["FixedAsset"]);
             }
             else
             {
                 datasourceFixedAsset = new ReportDataSource("FixedAsset", dsdemo.Tables["FixedAsset"]);
             }

            //Investments
            ReportDataSource datasourceInvestments;
             if (ds.Tables.Contains("Investments"))
            {
           datasourceInvestments = new ReportDataSource("Investments", ds.Tables["Investments"]);
             }
             else
             {
                 datasourceInvestments = new ReportDataSource("Investments", dsdemo.Tables["Investments"]);
             }
            //LongTermInv
             ReportDataSource datasourceLongTermInv;
             if (ds.Tables.Contains("LongTermInv"))
            {
            datasourceLongTermInv = new ReportDataSource("LongTermInv", ds.Tables["LongTermInv"]);
             }
             else
             {datasourceLongTermInv = new ReportDataSource("LongTermInv", dsdemo.Tables["LongTermInv"]);
             }
            //TradeInv
            ReportDataSource datasourceTradeInv;
            if (ds.Tables.Contains("TradeInv"))
            {
             datasourceTradeInv = new ReportDataSource("TradeInv", ds.Tables["TradeInv"]);
            }
            else{
                datasourceTradeInv = new ReportDataSource("TradeInv", dsdemo.Tables["TradeInv"]);
            }
            //Inventories
            ReportDataSource datasourceInventories;
             if (ds.Tables.Contains("Inventories"))
            {
            datasourceInventories = new ReportDataSource("Inventories", ds.Tables["Inventories"]);
             }
             else
             { datasourceInventories = new ReportDataSource("Inventories", dsdemo.Tables["Inventories"]);
             }
            // CashOrBankBal
            ReportDataSource datasourceCashOrBankBal;
            if (ds.Tables.Contains("CashOrBankBal"))
            {
            datasourceCashOrBankBal = new ReportDataSource("CashOrBankBal", ds.Tables["CashOrBankBal"]);
            }
            else
            {
                datasourceCashOrBankBal = new ReportDataSource("CashOrBankBal", dsdemo.Tables["CashOrBankBal"]);
            }
            //CurrAssetLoanAdv
            ReportDataSource datasourceCurrAssetLoanAdv;
             if (ds.Tables.Contains("CurrAssetLoanAdv"))
            {
             datasourceCurrAssetLoanAdv = new ReportDataSource("CurrAssetLoanAdv", ds.Tables["CurrAssetLoanAdv"]);
             }
             else
             {datasourceCurrAssetLoanAdv = new ReportDataSource("CurrAssetLoanAdv", dsdemo.Tables["CurrAssetLoanAdv"]);
             }
            // LoanAdv
            ReportDataSource datasourceLoanAdv;
             if (ds.Tables.Contains("LoanAdv"))
            {
             datasourceLoanAdv = new ReportDataSource("LoanAdv", ds.Tables["LoanAdv"]);
             }
             else
             {datasourceLoanAdv = new ReportDataSource("LoanAdv", dsdemo.Tables["LoanAdv"]);
             }
            //CurrLiabilities
            ReportDataSource datasourceCurrLiabilities;
            if (ds.Tables.Contains("CurrLiabilities"))
            {
            datasourceCurrLiabilities = new ReportDataSource("CurrLiabilities", ds.Tables["CurrLiabilities"]);
            }
            else{
                datasourceCurrLiabilities = new ReportDataSource("CurrLiabilities", dsdemo.Tables["CurrLiabilities"]);
            }
            //Provision
            ReportDataSource datasourceProvisions;
            if (ds.Tables.Contains("Provisions"))
            {
            datasourceProvisions = new ReportDataSource("Provisions", ds.Tables["Provisions"]);
            }
            else{
                 datasourceProvisions = new ReportDataSource("Provisions", dsdemo.Tables["Provisions"]);
            }
            //MiscAdjust
             ReportDataSource datasourceMiscAdjust;
             if (ds.Tables.Contains("MiscAdjust"))
            {
            datasourceMiscAdjust = new ReportDataSource("MiscAdjust", ds.Tables["MiscAdjust"]);
             }
             else
             {
                  datasourceMiscAdjust = new ReportDataSource("MiscAdjust", dsdemo.Tables["MiscAdjust"]);
             }
            // CreditsToPL
            ReportDataSource datasourceCreditsToPL;
             if (ds.Tables.Contains("CreditsToPL"))
            {
             datasourceCreditsToPL = new ReportDataSource("CreditsToPL", ds.Tables["CreditsToPL"]);
             }
             else
             {
             datasourceCreditsToPL = new ReportDataSource("CreditsToPL", dsdemo.Tables["CreditsToPL"]);
             }

            // OtherOperatingRevenueDtls
            ReportDataSource datasourceOtherOperatingRevenueDtls;
             if (ds.Tables.Contains("OtherOperatingRevenueDtls"))
            {
            datasourceOtherOperatingRevenueDtls = new ReportDataSource("OtherOperatingRevenueDtls", ds.Tables["OtherOperatingRevenueDtls"]);
             }
             else
             {datasourceOtherOperatingRevenueDtls = new ReportDataSource("OtherOperatingRevenueDtls", dsdemo.Tables["OtherOperatingRevenueDtls"]);
             }
            //OthIncome
            ReportDataSource datasourceOthIncome;
            if (ds.Tables.Contains("OthIncome"))
            {
             datasourceOthIncome = new ReportDataSource("OthIncome", ds.Tables["OthIncome"]);
            }
            else
            {
                datasourceOthIncome = new ReportDataSource("OthIncome", dsdemo.Tables["OthIncome"]);
            }
            //OtherIncDtls
            ReportDataSource datasourceOtherIncDtls;
            if (ds.Tables.Contains("OtherIncDtls"))
            {
         datasourceOtherIncDtls = new ReportDataSource("OtherIncDtls", ds.Tables["OtherIncDtls"]);
            }
            else{
                datasourceOtherIncDtls = new ReportDataSource("OtherIncDtls", dsdemo.Tables["OtherIncDtls"]);
            }
            // ClosingStockDtls
             ReportDataSource datasourceClosingStockDtls;
             if (ds.Tables.Contains("losingStockDtls"))
            {
             datasourceClosingStockDtls = new ReportDataSource("ClosingStockDtls", ds.Tables["ClosingStockDtls"]);
             }
             else
             {
                 datasourceClosingStockDtls = new ReportDataSource("ClosingStockDtls", dsdemo.Tables["ClosingStockDtls"]);
             }
            //DebitsToPL
            ReportDataSource datasourceDebitsToPL;
             if (ds.Tables.Contains("DebitsToPL"))
            {
             datasourceDebitsToPL = new ReportDataSource("DebitsToPL", ds.Tables["DebitsToPL"]);
             }
             else
             {
               datasourceDebitsToPL = new ReportDataSource("DebitsToPL", dsdemo.Tables["DebitsToPL"]);
             }
            //OpeningStockDtls
            ReportDataSource datasourceOpeningStockDtls;
             if (ds.Tables.Contains("OpeningStockDtls"))
            {
            datasourceOpeningStockDtls = new ReportDataSource("OpeningStockDtls", ds.Tables["OpeningStockDtls"]);
             }
             else
             {
                 datasourceOpeningStockDtls = new ReportDataSource("OpeningStockDtls", dsdemo.Tables["OpeningStockDtls"]);
             }
            // EmployeeComp
            ReportDataSource datasourceEmployeeComp;
             if (ds.Tables.Contains("EmployeeComp"))
            {
            datasourceEmployeeComp = new ReportDataSource("EmployeeComp", ds.Tables["EmployeeComp"]);
             }
             else
             {datasourceEmployeeComp = new ReportDataSource("EmployeeComp", dsdemo.Tables["EmployeeComp"]);
             }
            //Insurances
            ReportDataSource datasourceInsurances;
             if (ds.Tables.Contains("Insurances"))
            {
            datasourceInsurances = new ReportDataSource("Insurances", ds.Tables["Insurances"]);
             }
             else
             {
                   datasourceInsurances = new ReportDataSource("Insurances", dsdemo.Tables["Insurances"]);
             }
            //CommissionExpdrDtls
             ReportDataSource datasourceCommissionExpdrDtls;
            if (ds.Tables.Contains("CommissionExpdrDtls"))
            {
           datasourceCommissionExpdrDtls = new ReportDataSource("CommissionExpdrDtls", ds.Tables["CommissionExpdrDtls"]);
            }
            else{
                datasourceCommissionExpdrDtls = new ReportDataSource("CommissionExpdrDtls", dsdemo.Tables["CommissionExpdrDtls"]);
            }
            //RoyalityDtls
            ReportDataSource datasourceRoyalityDtls;
            if (ds.Tables.Contains("RoyalityDtls"))
            {
           datasourceRoyalityDtls = new ReportDataSource("RoyalityDtls", ds.Tables["RoyalityDtls"]);
            }
            else{
                datasourceRoyalityDtls = new ReportDataSource("RoyalityDtls", dsdemo.Tables["RoyalityDtls"]);
            }
            // ProfessionalConstDtls
            ReportDataSource datasourceProfessionalConstDtls;
             if (ds.Tables.Contains("ProfessionalConstDtls"))
            {
             datasourceProfessionalConstDtls = new ReportDataSource("ProfessionalConstDtls", ds.Tables["ProfessionalConstDtls"]);
             }
             else
             { datasourceProfessionalConstDtls = new ReportDataSource("ProfessionalConstDtls", dsdemo.Tables["ProfessionalConstDtls"]);
             }
            //ExciseCustomsVAT
            ReportDataSource datasourceExciseCustomsVAT;
             if (ds.Tables.Contains("ExciseCustomsVAT"))
            {
            datasourceExciseCustomsVAT = new ReportDataSource("ExciseCustomsVAT", ds.Tables["ExciseCustomsVAT"]);
             }
             else
             {
                  datasourceExciseCustomsVAT = new ReportDataSource("ExciseCustomsVAT", dsdemo.Tables["ExciseCustomsVAT"]);
             }
            //OtherExpensesDtls
            ReportDataSource datasourceOtherExpensesDtls;
            if (ds.Tables.Contains("OtherExpensesDtls"))
            {
            datasourceOtherExpensesDtls = new ReportDataSource("OtherExpensesDtls", ds.Tables["OtherExpensesDtls"]);
            }
            else
            {  datasourceOtherExpensesDtls = new ReportDataSource("OtherExpensesDtls", dsdemo.Tables["OtherExpensesDtls"]);
            }
            //NoBooksOfAccPL
             ReportDataSource datasourceNoBooksOfAccPL;
             if (ds.Tables.Contains("NoBooksOfAccPL"))
            {
             datasourceNoBooksOfAccPL = new ReportDataSource("NoBooksOfAccPL", ds.Tables["NoBooksOfAccPL"]);
             }
             else
             {   datasourceNoBooksOfAccPL = new ReportDataSource("NoBooksOfAccPL", dsdemo.Tables["NoBooksOfAccPL"]);
             }
            //TaxProvAppr
            ReportDataSource datasourceTaxProvApprL;
             if (ds.Tables.Contains("TaxProvAppr"))
            {
            datasourceTaxProvApprL = new ReportDataSource("TaxProvAppr", ds.Tables["TaxProvAppr"]);
             }
             else
             {
                 datasourceTaxProvApprL = new ReportDataSource("TaxProvAppr", dsdemo.Tables["TaxProvAppr"]);
             }
            //InterestExpdrtDtls
            ReportDataSource datasourceInterestExpdrtDtls;
             if (ds.Tables.Contains("InterestExpdrtDtls"))
            {
             datasourceInterestExpdrtDtls = new ReportDataSource("InterestExpdrtDtls", ds.Tables["InterestExpdrtDtls"]);
             }
             else
             {datasourceInterestExpdrtDtls = new ReportDataSource("InterestExpdrtDtls", dsdemo.Tables["InterestExpdrtDtls"]);
             }
            //BadDebtDtls
            ReportDataSource datasourceBadDebtDtls;
             if (ds.Tables.Contains("BadDebtDtls"))
            {
             datasourceBadDebtDtls = new ReportDataSource("BadDebtDtls", ds.Tables["BadDebtDtls"]);
             }else{
                 datasourceBadDebtDtls = new ReportDataSource("BadDebtDtls", dsdemo.Tables["BadDebtDtls"]);
             }
            //BadDebtAmtDtls
            ReportDataSource datasourceBadDebtAmtDtls;
             if (ds.Tables.Contains("BadDebtAmtDtls"))
            {
      datasourceBadDebtAmtDtls = new ReportDataSource("BadDebtAmtDtls", ds.Tables["BadDebtAmtDtls"]);
             }
             else
             {datasourceBadDebtAmtDtls = new ReportDataSource("BadDebtAmtDtls", dsdemo.Tables["BadDebtAmtDtls"]);
             }
            //PARTAOI
            ReportDataSource datasourcePARTAOI ;
            if (ds.Tables.Contains("PARTAOI"))
            {
            datasourcePARTAOI = new ReportDataSource("PARTAOI", ds.Tables["PARTA_OI"]);
            }else
            {
                datasourcePARTAOI = new ReportDataSource("PARTAOI", dsdemo.Tables["PARTA_OI"]);
            }
            //MethodOfValClgStk
            ReportDataSource datasourceMethodOfValClgStk;
            if (ds.Tables.Contains("MethodOfValClgStk"))
            {
             datasourceMethodOfValClgStk = new ReportDataSource("MethodOfValClgStk", ds.Tables["MethodOfValClgStk"]);
            }
            else
            {
                datasourceMethodOfValClgStk = new ReportDataSource("MethodOfValClgStk", dsdemo.Tables["MethodOfValClgStk"]);
            }
            //NoCredToPLAAmt
          ReportDataSource datasourceNoCredToPLAAmt;
              if(ds.Tables.Contains("NoCredToPLAAmt"))
            {
            datasourceNoCredToPLAAmt = new ReportDataSource("NoCredToPLAAmt", ds.Tables["NoCredToPLAmt"]);
              }
              else
              {datasourceNoCredToPLAAmt = new ReportDataSource("NoCredToPLAAmt", dsdemo.Tables["NoCredToPLAmt"]);
              }
            //AmtDisallUs36
            ReportDataSource datasourceAmtDisallUs36;
             if(ds.Tables.Contains("AmtDisallUs36"))
            {
            datasourceAmtDisallUs36 = new ReportDataSource("AmtDisallUs36", ds.Tables["AmtDisallUs36"]);
             }
             else
             { datasourceAmtDisallUs36 = new ReportDataSource("AmtDisallUs36", dsdemo.Tables["AmtDisallUs36"]);
             }
            //AmtDisallUs36
            ReportDataSource datasourceAmtDisallUs37;
             if(ds.Tables.Contains("AmtDisallUs37"))
            {
             datasourceAmtDisallUs37 = new ReportDataSource("AmtDisallUs37", ds.Tables["AmtDisallUs37"]);

             }else{
                 datasourceAmtDisallUs37 = new ReportDataSource("AmtDisallUs37", dsdemo.Tables["AmtDisallUs37"]);
             }
            //AmtDisallUs40
             ReportDataSource datasourceAmtDisallUs40;
             if(ds.Tables.Contains("AmtDisallUs40"))
            {
            datasourceAmtDisallUs40 = new ReportDataSource("AmtDisallUs40", ds.Tables["AmtDisallUs40"]);
             }
else{
                  datasourceAmtDisallUs40 = new ReportDataSource("AmtDisallUs40", dsdemo.Tables["AmtDisallUs40"]);
             }
            // AmtDisallUs40A
            ReportDataSource datasourceAmtDisallUs40A;
              if(ds.Tables.Contains("AmtDisallUs40A"))
            {
            datasourceAmtDisallUs40A = new ReportDataSource("AmtDisallUs40A", ds.Tables["AmtDisallUs40A"]);
              }
              else
              {datasourceAmtDisallUs40A = new ReportDataSource("AmtDisallUs40A", dsdemo.Tables["AmtDisallUs40A"]);
              }
            //AmtUs43B1
            ReportDataSource datasourceAmtUs43B1;
              if(ds.Tables.Contains("AmtUs43B"))
            {
             datasourceAmtUs43B1 = new ReportDataSource("AmtUs43B1", ds.Tables["AmtUs43B"]);
              }
              else
              {datasourceAmtUs43B1 = new ReportDataSource("AmtUs43B1", dsdemo.Tables["AmtUs43B"]);
              }
            ReportDataSource datasourceAmtUs43B2;
             if(ds.Tables.Contains("AmtUs43B2"))
            {
            datasourceAmtUs43B2 = new ReportDataSource("AmtUs43B2", ds.Tables["AmtUs43B"]);
             }
             else
             { datasourceAmtUs43B2 = new ReportDataSource("AmtUs43B2", dsdemo.Tables["AmtUs43B"]);
             }
            //QuantitDet
            ReportDataSource datasourceQuantitDet;
             if(ds.Tables.Contains("QuantitDet"))
            {
           datasourceQuantitDet = new ReportDataSource("QuantitDet", ds.Tables["QuantitDet"]);
             }
             else
             { datasourceQuantitDet = new ReportDataSource("QuantitDet", dsdemo.Tables["QuantitDet"]);
             }
            ReportDataSource datasourceQuantitDet1;
            if(ds.Tables.Contains("QuantitDet"))
            {
            datasourceQuantitDet1 = new ReportDataSource("QuantitDet1", ds.Tables["QuantitDet"]);
            }
            else{
                 datasourceQuantitDet1 = new ReportDataSource("QuantitDet1", dsdemo.Tables["QuantitDet"]);
            }
            ReportDataSource datasourceQuantitDet2;
            if (ds.Tables.Contains("QuantitDet2"))
            {
                datasourceQuantitDet2 = new ReportDataSource("QuantitDet2", ds.Tables["QuantitDet"]);
            }
            else
            {
                datasourceQuantitDet2 = new ReportDataSource("QuantitDet2", dsdemo.Tables["QuantitDet"]);
            }
            // AmtDisallUs43BPyNowAll
            ReportDataSource datasourceAmtDisallUs43BPyNowAll;
             if(ds.Tables.Contains("AmtDisallUs43BPyNowAll"))
            {
          datasourceAmtDisallUs43BPyNowAll = new ReportDataSource("AmtDisallUs43BPyNowAll", ds.Tables["AmtDisallUs43BPyNowAll"]);
             }
             else
             {     datasourceAmtDisallUs43BPyNowAll = new ReportDataSource("AmtDisallUs43BPyNowAll", dsdemo.Tables["AmtDisallUs43BPyNowAll"]);
             }
            //AmtDisall43B
             ReportDataSource datasourceAmtDisall43B;
             if(ds.Tables.Contains("AmtDisall43B"))
            {
       datasourceAmtDisall43B = new ReportDataSource("AmtDisall43B", ds.Tables["AmtDisall43B"]);
             }
             else
             { datasourceAmtDisall43B = new ReportDataSource("AmtDisall43B", dsdemo.Tables["AmtDisall43B"]);
             }
            //ProfBusGain
            ReportDataSource datasourceProfBusGain;
             if(ds.Tables.Contains("ProfBusGain"))
            {
             datasourceProfBusGain = new ReportDataSource("ProfBusGain", ds.Tables["ProfBusGain"]);
             }
             else
             {  datasourceProfBusGain = new ReportDataSource("ProfBusGain", dsdemo.Tables["ProfBusGain"]);
             }
            //ShortTerm
            ReportDataSource datasourceLongTerm;
             if(ds.Tables.Contains("LongTerm"))
            {
           
            datasourceLongTerm = new ReportDataSource("LongTerm", ds.Tables["LongTerm"]);
             }
             else
             { datasourceLongTerm = new ReportDataSource("LongTerm", dsdemo.Tables["LongTerm"]);
             }
             ReportDataSource datasourceShortTerm;
             if(ds.Tables.Contains("ShortTerm"))
            {
           
            datasourceShortTerm = new ReportDataSource("ShortTerm", ds.Tables["ShortTerm"]);
             }
             else
             { datasourceShortTerm = new ReportDataSource("ShortTerm", dsdemo.Tables["ShortTerm"]);
            
             }
            ReportDataSource datasourceCapGain;
             if(ds.Tables.Contains("CapGain"))
            {
           datasourceCapGain = new ReportDataSource("CapGain", ds.Tables["CapGain"]);
             }
             else
             {datasourceCapGain = new ReportDataSource("CapGain", dsdemo.Tables["CapGain"]);
             }
            //DeductionsUndSchVIADtl
            ReportDataSource datasourceDeductionsUndSchVIADtl;
            if(ds.Tables.Contains("DeductionsUndSchVIADtl"))
            {
             datasourceDeductionsUndSchVIADtl = new ReportDataSource("DeductionsUndSchVIADtl", ds.Tables["DeductionsUndSchVIADtl"]);
            }
            else
            {
                datasourceDeductionsUndSchVIADtl = new ReportDataSource("DeductionsUndSchVIADtl", dsdemo.Tables["DeductionsUndSchVIADtl"]);
            }
            //TaxPayableOnDeemedTI
            ReportDataSource datasourceTaxPayableOnDeemedTI;
            if(ds.Tables.Contains("TaxPayableOnDeemedTI"))
            {
             datasourceTaxPayableOnDeemedTI = new ReportDataSource("TaxPayableOnDeemedTI", ds.Tables["TaxPayableOnDeemedTI"]);
            }
            else
            {  datasourceTaxPayableOnDeemedTI = new ReportDataSource("TaxPayableOnDeemedTI", dsdemo.Tables["TaxPayableOnDeemedTI"]);
            }

            //TaxRelief
            ReportDataSource datasourceTaxRelief;
               if(ds.Tables.Contains("TaxRelief"))
            {
             datasourceTaxRelief = new ReportDataSource("TaxRelief", ds.Tables["TaxRelief"]);
               }
               else
               {    datasourceTaxRelief = new ReportDataSource("TaxRelief", dsdemo.Tables["TaxRelief"]);
               }
            //PartBTTI
            ReportDataSource datasourcePartBTTI;
             if(ds.Tables.Contains("PartB_TTI"))
            {
          datasourcePartBTTI = new ReportDataSource("PartBTTI", ds.Tables["PartB_TTI"]);
             }else{
                 datasourcePartBTTI = new ReportDataSource("PartBTTI", dsdemo.Tables["PartB_TTI"]);
             }
            //TCS
             ReportDataSource datasourceTCS;
              if(ds.Tables.Contains("TCS"))
            {
            datasourceTCS = new ReportDataSource("TCS", ds.Tables["TCS"]);
              }
              else
              {
                  datasourceTCS = new ReportDataSource("TCS", dsdemo.Tables["TCS"]);
              }
            // PropertyDetails
            ReportDataSource datasourcePropertyDetails;
             if(ds.Tables.Contains("PropertyDetails"))
            {
            datasourcePropertyDetails = new ReportDataSource("PropertyDetails", ds.Tables["PropertyDetails"]);
             }
             else
             {
                 datasourcePropertyDetails = new ReportDataSource("PropertyDetails", dsdemo.Tables["PropertyDetails"]);
             }
            //AddressDetailHp
            ReportDataSource datasourceAddressDetailHp;
             if(ds.Tables.Contains("AddressDetailHp"))
            {
          datasourceAddressDetailHp = new ReportDataSource("AddressDetailHp", ds.Tables["AddressDetail"]);
             }
             else
             {datasourceAddressDetailHp = new ReportDataSource("AddressDetailHp", dsdemo.Tables["AddressDetail"]);
             }
            //BusinessIncOthThanSpec
              ReportDataSource datasourceBusinessIncOthThanSpec;
             if(ds.Tables.Contains("BusinessIncOthThanSpec"))
            {
           datasourceBusinessIncOthThanSpec = new ReportDataSource("BusinessIncOthThanSpec", ds.Tables["BusinessIncOthThanSpec"]);
             }
             else
             {   datasourceBusinessIncOthThanSpec = new ReportDataSource("BusinessIncOthThanSpec", dsdemo.Tables["BusinessIncOthThanSpec"]);
             }
            //IncRecCredPLOthHeadDtls
            ReportDataSource datasourceIncRecCredPLOthHeadDtls;
              if(ds.Tables.Contains("IncRecCredPLOthHeadDtls"))
            {
          datasourceIncRecCredPLOthHeadDtls = new ReportDataSource("IncRecCredPLOthHeadDtls", ds.Tables["IncRecCredPLOthHeadDtls"]);
              }
              else
              {
                   datasourceIncRecCredPLOthHeadDtls = new ReportDataSource("IncRecCredPLOthHeadDtls", dsdemo.Tables["IncRecCredPLOthHeadDtls"]);
              }
            //IncCredPL
             ReportDataSource datasourceIncCredPL;
            if(ds.Tables.Contains("IncCredPL"))
            {
            datasourceIncCredPL = new ReportDataSource("IncCredPL", ds.Tables["IncCredPL"]);
            }
            else
            {
                 datasourceIncCredPL = new ReportDataSource("IncCredPL", dsdemo.Tables["IncCredPL"]);
            }
            //OtherExmptIncDtls
             ReportDataSource datasourceOtherExmptIncDtls;
             if(ds.Tables.Contains("OtherExmptIncDtls"))
            {
           datasourceOtherExmptIncDtls = new ReportDataSource("OtherExmptIncDtls", ds.Tables["OtherExmptIncDtls"]);
             }
            else
             {  datasourceOtherExmptIncDtls = new ReportDataSource("OtherExmptIncDtls", dsdemo.Tables["OtherExmptIncDtls"]);
             }
            //ExpDebToPLOthHeadDtls
            ReportDataSource datasourceExpDebToPLOthHeadDtls;
             if(ds.Tables.Contains("ExpDebToPLOthHeadDtls"))
            {
             datasourceExpDebToPLOthHeadDtls = new ReportDataSource("ExpDebToPLOthHeadDtls", ds.Tables["ExpDebToPLOthHeadDtls"]);
             }
             else
             {  datasourceExpDebToPLOthHeadDtls = new ReportDataSource("ExpDebToPLOthHeadDtls", dsdemo.Tables["ExpDebToPLOthHeadDtls"]);
             }
            //DepreciationAllowITAct32
            ReportDataSource datasourceDepreciationAllowITAct32;
              if(ds.Tables.Contains("DepreciationAllowITAct32"))
            {
             datasourceDepreciationAllowITAct32 = new ReportDataSource("DepreciationAllowITAct32", ds.Tables["DepreciationAllowITAct32"]);
              }
              else
              {datasourceDepreciationAllowITAct32 = new ReportDataSource("DepreciationAllowITAct32", dsdemo.Tables["DepreciationAllowITAct32"]);
              }
            //DeductUndChapVIA
             ReportDataSource datasourceDeductUndChapVIA;
            if(ds.Tables.Contains("DeductUndChapVIA"))
            {
           datasourceDeductUndChapVIA = new ReportDataSource("DeductUndChapVIA", ds.Tables["DeductUndChapVIA"]);
            }
            else{datasourceDeductUndChapVIA = new ReportDataSource("DeductUndChapVIA", dsdemo.Tables["DeductUndChapVIA"]);
            }
            //DeemedProfitBusUs
            ReportDataSource datasourceDeemedProfitBusUs;
            if(ds.Tables.Contains("DeemedProfitBusUs"))
            {
             datasourceDeemedProfitBusUs = new ReportDataSource("DeemedProfitBusUs", ds.Tables["DeemedProfitBusUs"]);
            }
            else{datasourceDeemedProfitBusUs = new ReportDataSource("DeemedProfitBusUs", dsdemo.Tables["DeemedProfitBusUs"]);
            }
            //SpecBusinessInc
             ReportDataSource datasourceSpecBusinessInc;
             if(ds.Tables.Contains("SpecBusinessInc"))
            {
           datasourceSpecBusinessInc = new ReportDataSource("SpecBusinessInc", ds.Tables["SpecBusinessInc"]);
             }
             else
             {   datasourceSpecBusinessInc = new ReportDataSource("SpecBusinessInc", dsdemo.Tables["SpecBusinessInc"]);
             }
            //SpecifiedBusinessInc
            ReportDataSource datasourceSpecifiedBusinessInc;
            if(ds.Tables.Contains("SpecifiedBusinessInc"))
            {
             datasourceSpecifiedBusinessInc = new ReportDataSource("SpecifiedBusinessInc", ds.Tables["SpecifiedBusinessInc"]);
            }
            else
            {
                 datasourceSpecifiedBusinessInc = new ReportDataSource("SpecifiedBusinessInc", dsdemo.Tables["SpecifiedBusinessInc"]);
            }
            //SpecifiedInc
            ReportDataSource datasourceSpecifiedInc;
            if(ds.Tables.Contains("SpecifiedInc"))
            {
             datasourceSpecifiedInc = new ReportDataSource("SpecifiedInc", ds.Tables["SpecifiedInc"]);
            }
            else
            { datasourceSpecifiedInc = new ReportDataSource("SpecifiedInc", dsdemo.Tables["SpecifiedInc"]);
            }
            //BusSetoffCurrYr
            ReportDataSource datasourceBusSetoffCurrYr;
             if(ds.Tables.Contains("BusSetoffCurrYr"))
            {
            datasourceBusSetoffCurrYr = new ReportDataSource("BusSetoffCurrYr", ds.Tables["BusSetoffCurrYr"]);
             }
             else
             {  datasourceBusSetoffCurrYr = new ReportDataSource("BusSetoffCurrYr", dsdemo.Tables["BusSetoffCurrYr"]);
             }
            //DeductUs35AC
            ReportDataSource datasourceDeductUs35AC;
             if(ds.Tables.Contains("DeductUs35AC"))
            {
            datasourceDeductUs35AC = new ReportDataSource("DeductUs35AC", ds.Tables["DeductUs35AC"]);
             }else
             { datasourceDeductUs35AC = new ReportDataSource("DeductUs35AC", dsdemo.Tables["DeductUs35AC"]);
             }
            //SpeculativeInc
            ReportDataSource datasourceSpeculativeInc;
             if(ds.Tables.Contains("SpeculativeInc"))
            {
           datasourceSpeculativeInc = new ReportDataSource("SpeculativeInc", ds.Tables["SpeculativeInc"]);
             }
             else
             { datasourceSpeculativeInc = new ReportDataSource("SpeculativeInc", dsdemo.Tables["SpeculativeInc"]);
             }
            //DepreciationDetail
            ReportDataSource datasourceDepreciationDetail;
             if(ds.Tables.Contains("DepreciationDetail"))
            {
             datasourceDepreciationDetail = new ReportDataSource("DepreciationDetail", ds.Tables["DepreciationDetail"]);
             }
             else
             { datasourceDepreciationDetail = new ReportDataSource("DepreciationDetail", dsdemo.Tables["DepreciationDetail"]);
             }
            //PlantMachinerySummaryCG
             ReportDataSource datasourcePlantMachinerySummaryCG;
             if(ds.Tables.Contains("PlantMachinerySummaryCG"))
            {
            datasourcePlantMachinerySummaryCG = new ReportDataSource("PlantMachinerySummaryCG", ds.Tables["PlantMachinerySummaryCG"]);
             }
             else
             {          datasourcePlantMachinerySummaryCG = new ReportDataSource("PlantMachinerySummaryCG", dsdemo.Tables["PlantMachinerySummaryCG"]);
             }
            ReportDataSource datasourcePlantMachinerySummary;
             if(ds.Tables.Contains("PlantMachinerySummary"))
            {
          datasourcePlantMachinerySummary = new ReportDataSource("PlantMachinerySummary", ds.Tables["PlantMachinerySummary"]);
             }
             else
             {  datasourcePlantMachinerySummary = new ReportDataSource("PlantMachinerySummary", dsdemo.Tables["PlantMachinerySummary"]);
             }
            //BuildingSummaryCG
            ReportDataSource datasourceBuildingSummaryCG;
             if(ds.Tables.Contains("BuildingSummaryCG"))
            {
         datasourceBuildingSummaryCG = new ReportDataSource("BuildingSummaryCG", ds.Tables["BuildingSummaryCG"]);
             }
             else
             { datasourceBuildingSummaryCG = new ReportDataSource("BuildingSummaryCG", dsdemo.Tables["BuildingSummaryCG"]);
             }
            //SummaryFromDeprSchCG
            ReportDataSource datasourceSummaryFromDeprSchCG;
             if(ds.Tables.Contains("SummaryFromDeprSchCG"))
            {
             datasourceSummaryFromDeprSchCG = new ReportDataSource("SummaryFromDeprSchCG", ds.Tables["SummaryFromDeprSchCG"]);
             }
             else
             { datasourceSummaryFromDeprSchCG = new ReportDataSource("SummaryFromDeprSchCG", dsdemo.Tables["SummaryFromDeprSchCG"]);
             }
            ReportDataSource datasourceSummaryFromDeprSch;
             if(ds.Tables.Contains("SummaryFromDeprSch"))
            {
            datasourceSummaryFromDeprSch = new ReportDataSource("SummaryFromDeprSch", ds.Tables["SummaryFromDeprSch"]);
             }
             else
             {
                    datasourceSummaryFromDeprSch = new ReportDataSource("SummaryFromDeprSch", dsdemo.Tables["SummaryFromDeprSch"]);
             }
            //BuildingSummary
             ReportDataSource datasourceBuildingSummary;
             if(ds.Tables.Contains("BuildingSummary"))
            {
            datasourceBuildingSummary = new ReportDataSource("BuildingSummary", ds.Tables["BuildingSummary"]);
             }
            else
             {
                 datasourceBuildingSummary = new ReportDataSource("BuildingSummary", dsdemo.Tables["BuildingSummary"]);
             }
            //DeductUs35
             ReportDataSource datasourceDeductUs35;
             if(ds.Tables.Contains("DeductUs35"))
            {
           datasourceDeductUs35 = new ReportDataSource("DeductUs35", ds.Tables["DeductUs35"]);
             }
             else
             {datasourceDeductUs35 = new ReportDataSource("DeductUs35", dsdemo.Tables["DeductUs35"]);
             }
            //SlumpSaleInStcg
            //CurrAssetLoanAdv
            ReportDataSource datasourceSaleofLandBuild;
             if(ds.Tables.Contains("SaleofLandBuild"))
            {
            datasourceSaleofLandBuild = new ReportDataSource("SaleofLandBuild", ds.Tables["SaleofLandBuild"]);
             }
             else
             {
                  datasourceSaleofLandBuild = new ReportDataSource("SaleofLandBuild", dsdemo.Tables["SaleofLandBuild"]);
             }
            ReportDataSource datasourceSlumpSaleInStcg;
            if(ds.Tables.Contains("SlumpSaleInStcg"))
            {
            datasourceSlumpSaleInStcg = new ReportDataSource("SlumpSaleInStcg", ds.Tables["SlumpSaleInStcg"]);
            }
            else{ datasourceSlumpSaleInStcg = new ReportDataSource("SlumpSaleInStcg", dsdemo.Tables["SlumpSaleInStcg"]);
            }
          ReportDataSource datasourceSlumpSaleInLtcg;
              if(ds.Tables.Contains("SlumpSaleInLtcg"))
            {
            datasourceSlumpSaleInLtcg = new ReportDataSource("SlumpSaleInLtcg", ds.Tables["SlumpSaleInLtcg"]);
              }
              else
              {
                    datasourceSlumpSaleInLtcg = new ReportDataSource("SlumpSaleInLtcg", dsdemo.Tables["SlumpSaleInLtcg"]);
              }
            // EquityMFonSTT
            ReportDataSource datasourceEquityMFonSTT;
             if(ds.Tables.Contains("EquityMFonSTT"))
            {
       datasourceEquityMFonSTT = new ReportDataSource("EquityMFonSTT", ds.Tables["EquityMFonSTT"]);
             }
             else
             {
                 datasourceEquityMFonSTT = new ReportDataSource("EquityMFonSTT", dsdemo.Tables["EquityMFonSTT"]);
             }
            // EquityMFonSTTDtls
             ReportDataSource datasourceEquityMFonSTTDtls;
            if(ds.Tables.Contains("EquityMFonSTTDtls"))
            {
             datasourceEquityMFonSTTDtls = new ReportDataSource("EquityMFonSTTDtls", ds.Tables["EquityMFonSTTDtls"]);
            }
            else{
               datasourceEquityMFonSTTDtls = new ReportDataSource("EquityMFonSTTDtls", dsdemo.Tables["EquityMFonSTTDtls"]);
            }
            //DeductSec48
             ReportDataSource datasourceDeductSec48;
             if(ds.Tables.Contains("DeductSec48"))
            {
            datasourceDeductSec48 = new ReportDataSource("DeductSec48", ds.Tables["DeductSec48"]);
             }
            else
             {    datasourceDeductSec48 = new ReportDataSource("DeductSec48", dsdemo.Tables["DeductSec48"]);
             }
            //NRITransacSec48Dtl
            ReportDataSource datasourceNRITransacSec48Dtl;
            if(ds.Tables.Contains("NRITransacSec48Dtl"))
            {
             datasourceNRITransacSec48Dtl = new ReportDataSource("NRITransacSec48Dtl", ds.Tables["NRITransacSec48Dtl"]);
            }
            else{
                  datasourceNRITransacSec48Dtl = new ReportDataSource("NRITransacSec48Dtl", dsdemo.Tables["NRITransacSec48Dtl"]);
            }
            //NRISecur115AD
            ReportDataSource datasourceNRISecur115AD;
             if(ds.Tables.Contains("NRISecur115AD"))
            {
            datasourceNRISecur115AD = new ReportDataSource("NRISecur115AD", ds.Tables["NRISecur115AD"]);
             }
             else
             {datasourceNRISecur115AD = new ReportDataSource("NRISecur115AD", dsdemo.Tables["NRISecur115AD"]);
             }
            //SaleOnOtherAssets
            ReportDataSource datasourceSaleOnOtherAssets;
             if(ds.Tables.Contains("SaleOnOtherAssets"))
            {
             
         datasourceSaleOnOtherAssets = new ReportDataSource("SaleOnOtherAssets", ds.Tables["SaleOnOtherAssets"]);
             }
             else
             {
                    datasourceSaleOnOtherAssets = new ReportDataSource("SaleOnOtherAssets", dsdemo.Tables["SaleOnOtherAssets"]);
             }
            //ExemptionOrDednUs54Dtls
            ReportDataSource datasourceExemptionOrDednUs54Dtls;
             if(ds.Tables.Contains("ExemptionOrDednUs54Dtls"))
            {
          datasourceExemptionOrDednUs54Dtls = new ReportDataSource("ExemptionOrDednUs54Dtls", ds.Tables["ExemptionOrDednUs54Dtls"]);
             }
             else
             {datasourceExemptionOrDednUs54Dtls = new ReportDataSource("ExemptionOrDednUs54Dtls", dsdemo.Tables["ExemptionOrDednUs54Dtls"]);
             }
            //UnutilizedCgPrvYrDtls
            ReportDataSource datasourceUnutilizedCgPrvYrDtls;
            if(ds.Tables.Contains("UnutilizedCgPrvYrDtls"))
            {
           datasourceUnutilizedCgPrvYrDtls = new ReportDataSource("UnutilizedCgPrvYrDtls", ds.Tables["UnutilizedCgPrvYrDtls"]);
            }
            else{
                 datasourceUnutilizedCgPrvYrDtls = new ReportDataSource("UnutilizedCgPrvYrDtls", dsdemo.Tables["UnutilizedCgPrvYrDtls"]);
            }
            //UnutilizedCgPrvYrDtlsConst
            ReportDataSource datasourceUnutilizedCgPrvYrDtlsConst;
            if(ds.Tables.Contains("UnutilizedCgPrvYrDtlsConst"))
            {
            datasourceUnutilizedCgPrvYrDtlsConst = new ReportDataSource("UnutilizedCgPrvYrDtlsConst", ds.Tables["UnutilizedCgPrvYrDtlsConst"]);
            }else{datasourceUnutilizedCgPrvYrDtlsConst = new ReportDataSource("UnutilizedCgPrvYrDtlsConst", dsdemo.Tables["UnutilizedCgPrvYrDtlsConst"]);
            }
            //NRIDTAADtls
            ReportDataSource datasourceNRIDTAADtls;
            if(ds.Tables.Contains("NRIDTAADtls"))
            {
           datasourceNRIDTAADtls = new ReportDataSource("NRIDTAADtls", ds.Tables["NRIDTAADtls"]);
            }
            else{
                  datasourceNRIDTAADtls = new ReportDataSource("NRIDTAADtls", dsdemo.Tables["NRIDTAADtls"]);
            }
            //ExemptionOrDednUs54
            ReportDataSource datasourceExemptionOrDednUs54;
            if(ds.Tables.Contains("ExemptionOrDednUs54"))
            {
             datasourceExemptionOrDednUs54 = new ReportDataSource("ExemptionOrDednUs54", ds.Tables["ExemptionOrDednUs54"]);
            }
            else
            {
                datasourceExemptionOrDednUs54 = new ReportDataSource("ExemptionOrDednUs54", dsdemo.Tables["ExemptionOrDednUs54"]);
            }
            //DateRange
             ReportDataSource datasourceDateRange;
            if(ds.Tables.Contains("DateRange"))
            {
             datasourceDateRange = new ReportDataSource("DateRange", ds.Tables["DateRange"]);
            }
            else{
                datasourceDateRange = new ReportDataSource("DateRange", dsdemo.Tables["DateRange"]);
            }
            //LossRemainSetOff
            ReportDataSource datasourceLossRemainSetOff;
            if(ds.Tables.Contains("LossRemainSetOff"))
            {
           datasourceLossRemainSetOff = new ReportDataSource("LossRemainSetOff", ds.Tables["LossRemainSetOff"]);
            }
            else
            { datasourceLossRemainSetOff = new ReportDataSource("LossRemainSetOff", dsdemo.Tables["LossRemainSetOff"]);
            }
            //TotLossSetOff
            ReportDataSource datasourceTotLossSetOff;
             if(ds.Tables.Contains("TotLossSetOff"))
            {
             datasourceTotLossSetOff = new ReportDataSource("TotLossSetOff", ds.Tables["TotLossSetOff"]);
             }
             else
             { datasourceTotLossSetOff = new ReportDataSource("TotLossSetOff", dsdemo.Tables["TotLossSetOff"]);
             }
            //InLtcg20Per
            ReportDataSource datasourceInLtcg20Per;
            if(ds.Tables.Contains("InLtcg20Per"))
            {
             datasourceInLtcg20Per = new ReportDataSource("InLtcg20Per", ds.Tables["InLtcg20Per"]);
            }
            else
            {
                 datasourceInLtcg20Per = new ReportDataSource("InLtcg20Per", ds.Tables["InLtcg20Per"]);
            }
             ReportDataSource datasourceInLtcg10Per;
             if(ds.Tables.Contains("InLtcg10Per"))
            {
            datasourceInLtcg10Per = new ReportDataSource("InLtcg10Per", ds.Tables["InLtcg10Per"]);
             }
             else
             {datasourceInLtcg10Per = new ReportDataSource("InLtcg10Per", dsdemo.Tables["InLtcg10Per"]);
             }
            //InStcgAppRate
            ReportDataSource datasourceInStcgAppRate;
            if(ds.Tables.Contains("InStcgAppRate"))
            {
             datasourceInStcgAppRate = new ReportDataSource("InStcgAppRate", ds.Tables["InStcgAppRate"]);
            }
            else
            {
                 datasourceInStcgAppRate = new ReportDataSource("InStcgAppRate", dsdemo.Tables["InStcgAppRate"]);
            }
            //InStcg30Per
            ReportDataSource datasourceInStcg30Per;
             if(ds.Tables.Contains("InStcg30Per"))
            {
         datasourceInStcg30Per = new ReportDataSource("InStcg30Per", ds.Tables["InStcg30Per"]);
             }
else{
             datasourceInStcg30Per = new ReportDataSource("InStcg30Per", dsdemo.Tables["InStcg30Per"]);}
            ReportDataSource datasourceInStcg15Per;
             if(ds.Tables.Contains("InStcg15Per"))
            {
         datasourceInStcg15Per = new ReportDataSource("InStcg15Per", ds.Tables["InStcg15Per"]);
             }
             else
             {  datasourceInStcg15Per = new ReportDataSource("InStcg15Per", ds.Tables["InStcg15Per"]);
             }
            //InLossSetOff
            ReportDataSource datasourceInLossSetOff;
             if(ds.Tables.Contains("InLossSetOff"))
            {
           datasourceInLossSetOff = new ReportDataSource("InLossSetOff", ds.Tables["InLossSetOff"]);
             }
             else
             { datasourceInLossSetOff = new ReportDataSource("InLossSetOff", dsdemo.Tables["InLossSetOff"]);
             }
            //DeducClaimDtls
            ReportDataSource datasourceDeducClaimDtls;
              if(ds.Tables.Contains("DeducClaimDtls"))
            {
             datasourceDeducClaimDtls = new ReportDataSource("DeducClaimDtls", ds.Tables["DeducClaimDtls"]);
              }
              else
              { datasourceDeducClaimDtls = new ReportDataSource("DeducClaimDtls", dsdemo.Tables["DeducClaimDtls"]);
              }
            //ShortTermCapGainFor23
            ReportDataSource datasourceShortTermCapGainFor23;
             if(ds.Tables.Contains("ShortTermCapGainFor23"))
            {
             datasourceShortTermCapGainFor23 = new ReportDataSource("ShortTermCapGainFor23", ds.Tables["ShortTermCapGainFor23"]);
             }
             else
             {
                   datasourceShortTermCapGainFor23 = new ReportDataSource("ShortTermCapGainFor23", dsdemo.Tables["ShortTermCapGainFor23"]);
             }
            //NRIProvisoSec48
             ReportDataSource datasourceNRIProvisoSec48;
             if(ds.Tables.Contains("NRIProvisoSec48"))
            {
          datasourceNRIProvisoSec48 = new ReportDataSource("NRIProvisoSec48", ds.Tables["NRIProvisoSec48"]);
             }
             else
             {
                   datasourceNRIProvisoSec48 = new ReportDataSource("NRIProvisoSec48", dsdemo.Tables["NRIProvisoSec48"]);
             }
            //DeducClaimInfo
            ReportDataSource datasourceDeducClaimInfo;
            if(ds.Tables.Contains("DeducClaimInfo"))
            {
        datasourceDeducClaimInfo = new ReportDataSource("DeducClaimInfo", ds.Tables["DeducClaimInfo"]);
            }
            else{
                   datasourceDeducClaimInfo = new ReportDataSource("DeducClaimInfo", dsdemo.Tables["DeducClaimInfo"]);
            }
            //LongTermCapGain23
            ReportDataSource datasourceLongTermCapGain23;
             if(ds.Tables.Contains("LongTermCapGain23"))
            {
            datasourceLongTermCapGain23 = new ReportDataSource("LongTermCapGain23", ds.Tables["LongTermCapGain23"]);
             }
             else
             {  datasourceLongTermCapGain23 = new ReportDataSource("LongTermCapGain23", dsdemo.Tables["LongTermCapGain23"]);
             }
            //SaleofAssetNA
             ReportDataSource datasourceSaleofAssetNA;
            if(ds.Tables.Contains("SaleofAssetNA"))
            {
            datasourceSaleofAssetNA = new ReportDataSource("SaleofAssetNA", ds.Tables["SaleofAssetNA"]);
            }
            else
            {   datasourceSaleofAssetNA = new ReportDataSource("SaleofAssetNA", dsdemo.Tables["SaleofAssetNA"]);
            }
            //NRISaleofForeignAsset
            ReportDataSource datasourceNRISaleofForeignAsset;
             if(ds.Tables.Contains("NRISaleofForeignAsset"))
            {
         datasourceNRISaleofForeignAsset = new ReportDataSource("NRISaleofForeignAsset", ds.Tables["NRISaleofForeignAsset"]);
             }
             else
             { datasourceNRISaleofForeignAsset = new ReportDataSource("NRISaleofForeignAsset", dsdemo.Tables["NRISaleofForeignAsset"]);
             }
            //Proviso112Applicabledtls
            ReportDataSource datasourceProviso112Applicabledtls;
             if(ds.Tables.Contains("Proviso112Applicabledtls"))
            {
            datasourceProviso112Applicabledtls = new ReportDataSource("Proviso112Applicabledtls", ds.Tables["Proviso112Applicabledtls"]);
             }
             else
             {
                 datasourceProviso112Applicabledtls = new ReportDataSource("Proviso112Applicabledtls", dsdemo.Tables["Proviso112Applicabledtls"]);
             }
            //SlumpSaleInStcg
            //IncOthThanOwnRaceHorse
            ReportDataSource datasourceIncOthThanOwnRaceHorse;
             if(ds.Tables.Contains("OthersGrossDtls"))
            {
            datasourceIncOthThanOwnRaceHorse = new ReportDataSource("IncOthThanOwnRaceHorse", ds.Tables["IncOthThanOwnRaceHorse"]);
             }
             else
             {  datasourceIncOthThanOwnRaceHorse = new ReportDataSource("IncOthThanOwnRaceHorse", dsdemo.Tables["IncOthThanOwnRaceHorse"]);
             }
            //OthersGrossDtls
            ReportDataSource datasourceOthersGrossDtls;
             if(ds.Tables.Contains("OthersGrossDtls"))
            {
            datasourceOthersGrossDtls = new ReportDataSource("OthersGrossDtls", ds.Tables["OthersGrossDtls"]);
             }
            else
             {  datasourceOthersGrossDtls = new ReportDataSource("OthersGrossDtls", dsdemo.Tables["OthersGrossDtls"]);
             }
            //IncChargblSplRateOS
             ReportDataSource datasourceIncChargblSplRateOS ;
            if(ds.Tables.Contains("IncChargblSplRateOS"))
            {
             datasourceIncChargblSplRateOS = new ReportDataSource("IncChargblSplRateOS", ds.Tables["IncChargblSplRateOS"]);
            }
            else{ datasourceIncChargblSplRateOS = new ReportDataSource("IncChargblSplRateOS", dsdemo.Tables["IncChargblSplRateOS"]);
            }
            //NRIDTAADtlsSchOS
             ReportDataSource datasourceNRIDTAADtlsSchOS;
            if(ds.Tables.Contains("NRIDTAADtlsSchOS"))
            {
            datasourceNRIDTAADtlsSchOS = new ReportDataSource("NRIDTAADtlsSchOS", ds.Tables["NRIDTAADtlsSchOS"]);
            }
            else
            {datasourceNRIDTAADtlsSchOS = new ReportDataSource("NRIDTAADtlsSchOS", dsdemo.Tables["NRIDTAADtlsSchOS"]);
            }
            //Deductions
            ReportDataSource datasourceDeductions;
            if(ds.Tables.Contains("Deductions"))
            {
           datasourceDeductions = new ReportDataSource("Deductions", ds.Tables["Deductions"]);
            }
            else
            { datasourceDeductions = new ReportDataSource("Deductions", dsdemo.Tables["Deductions"]);
            }
            ReportDataSource datasourceIncFromOwnHorse;
            if(ds.Tables.Contains("IncFromOwnHorse"))
            {
            datasourceIncFromOwnHorse = new ReportDataSource("IncFromOwnHorse", ds.Tables["IncFromOwnHorse"]);
            }
            else
            {  datasourceIncFromOwnHorse = new ReportDataSource("IncFromOwnHorse", dsdemo.Tables["IncFromOwnHorse"]);
            }
            //ScheduleOS
            ReportDataSource datasourceScheduleOS;
            if(ds.Tables.Contains("ScheduleOS"))
            {
     datasourceScheduleOS = new ReportDataSource("ScheduleOS", ds.Tables["ScheduleOS"]);
            }
            else
            {   datasourceScheduleOS = new ReportDataSource("ScheduleOS", dsdemo.Tables["ScheduleOS"]);
            }
            //TotalLossSetOff
            ReportDataSource datasourceTotalLossSetOff;
             if(ds.Tables.Contains("TotalLossSetOff"))
            {
             datasourceTotalLossSetOff = new ReportDataSource("TotalLossSetOff", ds.Tables["TotalLossSetOff"]);
             }
             else
             {  datasourceTotalLossSetOff = new ReportDataSource("TotalLossSetOff", dsdemo.Tables["TotalLossSetOff"]);
             }
            //LossRemAftSetOff
            ReportDataSource datasourceLossRemAftSetOff;
            if(ds.Tables.Contains("LossRemAftSetOff"))
            {
            datasourceLossRemAftSetOff = new ReportDataSource("LossRemAftSetOff", ds.Tables["LossRemAftSetOff"]);
            }
            else
            {datasourceLossRemAftSetOff = new ReportDataSource("LossRemAftSetOff", dsdemo.Tables["LossRemAftSetOff"]);
            }

            //  IncBFLA
            ReportDataSource datasourceIncBFLA;
            if(ds.Tables.Contains("IncBFLA"))
            {
       datasourceIncBFLA = new ReportDataSource("IncBFLA", ds.Tables["IncBFLA"]);
            }
            else
            {datasourceIncBFLA = new ReportDataSource("IncBFLA", dsdemo.Tables["IncBFLA"]);
            }
            //TTotalBFLossSetOff
            ReportDataSource datasourceTotalBFLossSetOff;
             if(ds.Tables.Contains("TotalBFLossSetOff"))
            {
             datasourceTotalBFLossSetOff = new ReportDataSource("TotalBFLossSetOff", ds.Tables["TotalBFLossSetOff"]);
             }
             else
             {   datasourceTotalBFLossSetOff = new ReportDataSource("TotalBFLossSetOff", dsdemo.Tables["TotalBFLossSetOff"]);
             }
            //LossRemAftSetOff
            //ScheduleUD
             ReportDataSource datasourceScheduleUD;
            if(ds.Tables.Contains("ScheduleUD"))
            {
          datasourceScheduleUD = new ReportDataSource("ScheduleUD", ds.Tables["ScheduleUD"]);
            }
            else
            { datasourceScheduleUD = new ReportDataSource("ScheduleUD", dsdemo.Tables["ScheduleUD"]);
            }
            //ITR4ScheduleUD
            ReportDataSource datasourceITR4ScheduleUD;
            if(ds.Tables.Contains("ITR4ScheduleUD"))
            {
            datasourceITR4ScheduleUD = new ReportDataSource("ITR4ScheduleUD", ds.Tables["ITR4ScheduleUD"]);
            }
            else{
                 datasourceITR4ScheduleUD = new ReportDataSource("ITR4ScheduleUD", dsdemo.Tables["ITR4ScheduleUD"]);
            }
         ReportDataSource datasourceDedFromUndertakingWithAy;
           // ReportDataSource datasourceDedUs10Detail;
            if(ds.Tables.Contains("DedFromUndertakingWithAy"))
            {
            datasourceDedFromUndertakingWithAy = new ReportDataSource("DedFromUndertakingWithAy", ds.Tables["DedFromUndertakingWithAy"]);
            }
            else
            {datasourceDedFromUndertakingWithAy = new ReportDataSource("DedFromUndertakingWithAy", dsdemo.Tables["DedFromUndertakingWithAy"]);
            }
            //DedUs10Detail
            ReportDataSource datasourceDedUs10Detail;
            if(ds.Tables.Contains("DedUs10Detail"))
            {
            datasourceDedUs10Detail = new ReportDataSource("DedUs10Detail", ds.Tables["DedUs10Detail"]);
            }
            else
            {datasourceDedUs10Detail = new ReportDataSource("DedUs10Detail", dsdemo.Tables["DedUs10Detail"]);
            }
            //DoneeWithPan
            ReportDataSource datasourceDoneeWithPan;
             if(ds.Tables.Contains("DoneeWithPan"))
            {
        datasourceDoneeWithPan = new ReportDataSource("DoneeWithPan", ds.Tables["DoneeWithPan"]);
             }
             else
             {
                  datasourceDoneeWithPan = new ReportDataSource("DoneeWithPan", dsdemo.Tables["DoneeWithPan"]);
             }
            //AddressDetail
            //Don100Percent
            ReportDataSource datasourceDon100Percent;
             if(ds.Tables.Contains("Don100Percent"))
            {
            datasourceDon100Percent = new ReportDataSource("Don100Percent", ds.Tables["Don100Percent"]);
             }
             else
             {     datasourceDon100Percent = new ReportDataSource("Don100Percent", dsdemo.Tables["Don100Percent"]);
             }
            //Don50PercentNoApprReqd
             ReportDataSource datasourceDon50PercentNoApprReqd;
             if(ds.Tables.Contains("Don50PercentNoApprReqd"))
            {
  datasourceDon50PercentNoApprReqd = new ReportDataSource("Don50PercentNoApprReqd", ds.Tables["Don50PercentNoApprReqd"]);
             }
             else
             {  datasourceDon50PercentNoApprReqd = new ReportDataSource("Don50PercentNoApprReqd", dsdemo.Tables["Don50PercentNoApprReqd"]);
             }
            //Don100PercentApprReqd
             ReportDataSource datasourceDon100PercentApprReqd;
            if(ds.Tables.Contains("Don100PercentApprReqd"))
            {
             datasourceDon100PercentApprReqd = new ReportDataSource("Don100PercentApprReqd", ds.Tables["Don100PercentApprReqd"]);
            }
            else
            {  datasourceDon100PercentApprReqd = new ReportDataSource("Don100PercentApprReqd", dsdemo.Tables["Don100PercentApprReqd"]);
            }
            //Don50PercentApprReqd
            ReportDataSource datasourceDon50PercentApprReqd;
            if(ds.Tables.Contains("Don50PercentApprReqd"))
            { 
            datasourceDon50PercentApprReqd = new ReportDataSource("Don50PercentApprReqd", ds.Tables["Don50PercentApprReqd"]);
            }
            else
            { datasourceDon50PercentApprReqd = new ReportDataSource("Don50PercentApprReqd", dsdemo.Tables["Don50PercentApprReqd"]);
            }
            //Schedule80G
             ReportDataSource datasourceSchedule80G; 
            if(ds.Tables.Contains("Schedule80G"))
            { 
            datasourceSchedule80G = new ReportDataSource("Schedule80G", ds.Tables["Schedule80G"]);
            }
            else
            {  datasourceSchedule80G = new ReportDataSource("Schedule80G", dsdemo.Tables["Schedule80G"]);
            }
            //Schedule80_IA
             ReportDataSource datasourceSchedule80_IA;
           
            if(ds.Tables.Contains("Schedule80_IA"))
            { 
                datasourceSchedule80_IA = new ReportDataSource("Schedule80_IA", ds.Tables["Schedule80_IA"]);
            }
            else
            {
                 datasourceSchedule80_IA = new ReportDataSource("Schedule80_IA", dsdemo.Tables["Schedule80_IA"]);
            }
            //DeductUs80_IA_4_ii
            ReportDataSource datasourceDeductUs80_IA_4_ii;
             if(ds.Tables.Contains("DeductUs80_IA_4_ii"))
            {
            datasourceDeductUs80_IA_4_ii = new ReportDataSource("DeductUs80_IA_4_ii", ds.Tables["DeductUs80_IA_4_ii"]);
             }
             else
             { datasourceDeductUs80_IA_4_ii = new ReportDataSource("DeductUs80_IA_4_ii", dsdemo.Tables["DeductUs80_IA_4_ii"]);
             }
            ReportDataSource datasourceDeductUs80_IA_4_iii;
             if(ds.Tables.Contains("DeductUs80_IA_4_iii"))
            {
            datasourceDeductUs80_IA_4_iii = new ReportDataSource("DeductUs80_IA_4_iii", ds.Tables["DeductUs80_IA_4_iii"]);
             }
             else
             {      datasourceDeductUs80_IA_4_iii = new ReportDataSource("DeductUs80_IA_4_iii", dsdemo.Tables["DeductUs80_IA_4_iii"]);
             }
            ReportDataSource datasourceDeductUs80_IA_4_iv;
             if(ds.Tables.Contains("DeductUs80_IA_4_iv"))
            {
             datasourceDeductUs80_IA_4_iv = new ReportDataSource("DeductUs80_IA_4_iv", ds.Tables["DeductUs80_IA_4_iv"]);
             }
             else
             { datasourceDeductUs80_IA_4_iv = new ReportDataSource("DeductUs80_IA_4_iv", dsdemo.Tables["DeductUs80_IA_4_iv"]);
             }
            //DeductUs80_IA_4_v
            ReportDataSource datasourceDeductUs80_IA_4_v;
             if(ds.Tables.Contains("DeductUs80_IA_4_v"))
            {
            datasourceDeductUs80_IA_4_v = new ReportDataSource("DeductUs80_IA_4_v", ds.Tables["DeductUs80_IA_4_v"]);
             }
             else
             { datasourceDeductUs80_IA_4_v = new ReportDataSource("DeductUs80_IA_4_v", dsdemo.Tables["DeductUs80_IA_4_v"]);
             }
            //Sch80DeductAmtDtls
            ReportDataSource datasourceSch80DeductAmtDtls;
             if(ds.Tables.Contains("Sch80DeductAmtDtls"))
            {
             datasourceSch80DeductAmtDtls = new ReportDataSource("Sch80DeductAmtDtls", ds.Tables["Sch80DeductAmtDtls"]);
             }
             else
             {   datasourceSch80DeductAmtDtls = new ReportDataSource("Sch80DeductAmtDtls", dsdemo.Tables["Sch80DeductAmtDtls"]);
             }
            //DeductHousUs80_IB_10_Und
            ReportDataSource datasourceDeductHousUs80_IB_10_Und;
             if(ds.Tables.Contains("DeductHousUs80_IB_10_Und"))
            {
             datasourceDeductHousUs80_IB_10_Und = new ReportDataSource("DeductHousUs80_IB_10_Und", ds.Tables["DeductHousUs80_IB_10_Und"]);
             }
             else
             {
                  datasourceDeductHousUs80_IB_10_Und = new ReportDataSource("DeductHousUs80_IB_10_Und", dsdemo.Tables["DeductHousUs80_IB_10_Und"]);
             }
            ReportDataSource datasourceDeductHospAnyAreaUs80IB_11C_Und ;
             if(ds.Tables.Contains("DeductHospAnyAreaUs80IB_11C_Und"))
            {
             datasourceDeductHospAnyAreaUs80IB_11C_Und = new ReportDataSource("DeductHospAnyAreaUs80IB_11C_Und", ds.Tables["DeductHospAnyAreaUs80IB_11C_Und"]);
             }
             else
             {             datasourceDeductHospAnyAreaUs80IB_11C_Und = new ReportDataSource("DeductHospAnyAreaUs80IB_11C_Und", dsdemo.Tables["DeductHospAnyAreaUs80IB_11C_Und"]);
             }
            ReportDataSource datasourceDeductRurHospUs80_IB_11B_Und;

             if(ds.Tables.Contains("DeductRurHospUs80_IB_11B_Und"))
            {
             datasourceDeductRurHospUs80_IB_11B_Und = new ReportDataSource("DeductRurHospUs80_IB_11B_Und", ds.Tables["DeductRurHospUs80_IB_11B_Und"]);
             }
            else
             {datasourceDeductRurHospUs80_IB_11B_Und = new ReportDataSource("DeductRurHospUs80_IB_11B_Und", dsdemo.Tables["DeductRurHospUs80_IB_11B_Und"]);
             }
            //DeductFoodGrainUs80_IB_11A_Und
            ReportDataSource datasourceDeductFoodGrainUs80_IB_11A_Und;
             if(ds.Tables.Contains("DeductFoodGrainUs80_IB_11A_Und"))
            {
         datasourceDeductFoodGrainUs80_IB_11A_Und = new ReportDataSource("DeductFoodGrainUs80_IB_11A_Und", ds.Tables["DeductFoodGrainUs80_IB_11A_Und"]);
             }
             else
             { datasourceDeductFoodGrainUs80_IB_11A_Und = new ReportDataSource("DeductFoodGrainUs80_IB_11A_Und", dsdemo.Tables["DeductFoodGrainUs80_IB_11A_Und"]);
             }
            //DeductFruitVegUs80_IB_11A_Und
            ReportDataSource datasourceDeductFruitVegUs80_IB_11A_Und;
             if(ds.Tables.Contains("DeductFruitVegUs80_IB_11A_Und"))
            {
            datasourceDeductFruitVegUs80_IB_11A_Und = new ReportDataSource("DeductFruitVegUs80_IB_11A_Und", ds.Tables["DeductFruitVegUs80_IB_11A_Und"]);
             }
             else
             { datasourceDeductFruitVegUs80_IB_11A_Und = new ReportDataSource("DeductFruitVegUs80_IB_11A_Und", dsdemo.Tables["DeductFruitVegUs80_IB_11A_Und"]);
             }
            //DeductColdChainUs80_IB_11_Und
             ReportDataSource datasourceDeductColdChainUs80_IB_11_Und;
             if(ds.Tables.Contains("DeductColdChainUs80_IB_11_Und"))
            {
         datasourceDeductColdChainUs80_IB_11_Und = new ReportDataSource("DeductColdChainUs80_IB_11_Und", ds.Tables["DeductColdChainUs80_IB_11_Und"]);
             }
             else
             {datasourceDeductColdChainUs80_IB_11_Und = new ReportDataSource("DeductColdChainUs80_IB_11_Und", dsdemo.Tables["DeductColdChainUs80_IB_11_Und"]);
             }
            //DeductMinOilUs80_IB_9_Und
            ReportDataSource datasourceDeductMinOilUs80_IB_9_Und;
             if(ds.Tables.Contains("DeductMinOilUs80_IB_9_Und"))
            {
            datasourceDeductMinOilUs80_IB_9_Und = new ReportDataSource("DeductMinOilUs80_IB_9_Und", ds.Tables["DeductMinOilUs80_IB_9_Und"]);
             }
             else
             { datasourceDeductMinOilUs80_IB_9_Und = new ReportDataSource("DeductMinOilUs80_IB_9_Und", dsdemo.Tables["DeductMinOilUs80_IB_9_Und"]);
             }
            //DeductConvCentUs80_IB_7B_Und
            ReportDataSource datasourceDeductConvCentUs80_IB_7B_Und;
             if(ds.Tables.Contains("DeductConvCentUs80_IB_7B_Und"))
            {
          datasourceDeductConvCentUs80_IB_7B_Und = new ReportDataSource("DeductConvCentUs80_IB_7B_Und", ds.Tables["DeductConvCentUs80_IB_7B_Und"]);
             }
             else
             {datasourceDeductConvCentUs80_IB_7B_Und = new ReportDataSource("DeductConvCentUs80_IB_7B_Und", dsdemo.Tables["DeductConvCentUs80_IB_7B_Und"]);
             }
            //DeductMultiplexUs80_IB_7A_Und
            ReportDataSource datasourceDeductMultiplexUs80_IB_7A_Und;
             if(ds.Tables.Contains("DeductMultiplexUs80_IB_7A_Und"))
            {
             datasourceDeductMultiplexUs80_IB_7A_Und = new ReportDataSource("DeductMultiplexUs80_IB_7A_Und", ds.Tables["DeductMultiplexUs80_IB_7A_Und"]);
             }
             else
             {datasourceDeductMultiplexUs80_IB_7A_Und = new ReportDataSource("DeductMultiplexUs80_IB_7A_Und", dsdemo.Tables["DeductMultiplexUs80_IB_7A_Und"]);
             }
            //DeductBackDisttUs80_IB_5_Und
            ReportDataSource datasourceDeductBackDisttUs80_IB_5_Und;
             if(ds.Tables.Contains("DeductBackDisttUs80_IB_5_Und"))
            {
           datasourceDeductBackDisttUs80_IB_5_Und = new ReportDataSource("DeductBackDisttUs80_IB_5_Und", ds.Tables["DeductBackDisttUs80_IB_5_Und"]);}
             else
             {           datasourceDeductBackDisttUs80_IB_5_Und = new ReportDataSource("DeductBackDisttUs80_IB_5_Und", dsdemo.Tables["DeductBackDisttUs80_IB_5_Und"]);
             }
            //DeductBackStatesUs80_IB_4_Und
             ReportDataSource datasourceDeductBackStatesUs80_IB_4_Und;
             if(ds.Tables.Contains("DeductBackStatesUs80_IB_4_Und"))
            {
             datasourceDeductBackStatesUs80_IB_4_Und = new ReportDataSource("DeductBackStatesUs80_IB_4_Und", ds.Tables["DeductBackStatesUs80_IB_4_Und"]);
             }
             else
             {datasourceDeductBackStatesUs80_IB_4_Und = new ReportDataSource("DeductBackStatesUs80_IB_4_Und", dsdemo.Tables["DeductBackStatesUs80_IB_4_Und"]);
             }
            //DeductJKLocUs80_IB_4_Und
            ReportDataSource datasourceDeductJKLocUs80_IB_4_Und;
            if(ds.Tables.Contains("DeductJKLocUs80_IB_4_Und"))
            {
             datasourceDeductJKLocUs80_IB_4_Und = new ReportDataSource("DeductJKLocUs80_IB_4_Und", ds.Tables["DeductJKLocUs80_IB_4_Und"]);
            }
            else{
                datasourceDeductJKLocUs80_IB_4_Und = new ReportDataSource("DeductJKLocUs80_IB_4_Und", dsdemo.Tables["DeductJKLocUs80_IB_4_Und"]);
            }
            //Schedule80_IB
            ReportDataSource datasourceSchedule80_IB;
             if(ds.Tables.Contains("Schedule80_IB"))
            {
           datasourceSchedule80_IB = new ReportDataSource("Schedule80_IB", ds.Tables["Schedule80_IB"]);
             }
             else
             { datasourceSchedule80_IB = new ReportDataSource("Schedule80_IB", dsdemo.Tables["Schedule80_IB"]);
             }
            // Schedule80_IC
            ReportDataSource datasourceSchedule80_IC;
             if(ds.Tables.Contains("DeductInSikkim_Und"))
            {
             datasourceSchedule80_IC = new ReportDataSource("Schedule80_IC", ds.Tables["Schedule80_IC"]);
             }
             else
             {datasourceSchedule80_IC = new ReportDataSource("Schedule80_IC", dsdemo.Tables["Schedule80_IC"]);
             }
            //DeductInSikkim_Und
            ReportDataSource datasourceDeductInSikkim_Und;
             if(ds.Tables.Contains("DeductInSikkim_Und"))
            {
            datasourceDeductInSikkim_Und = new ReportDataSource("DeductInSikkim_Und", ds.Tables["DeductInSikkim_Und"]);
             }
             else
             {datasourceDeductInSikkim_Und = new ReportDataSource("DeductInSikkim_Und", dsdemo.Tables["DeductInSikkim_Und"]);
             }
            //DeductInHimachalP_Und
            ReportDataSource datasourceDeductInHimachalP_Und;
             if(ds.Tables.Contains("DeductInHimachalP_Und"))
            {
             datasourceDeductInHimachalP_Und = new ReportDataSource("DeductInHimachalP_Und", ds.Tables["DeductInHimachalP_Und"]);
             }
             else
             {datasourceDeductInHimachalP_Und = new ReportDataSource("DeductInHimachalP_Und", dsdemo.Tables["DeductInHimachalP_Und"]);
             }
            //DeductInUttaranchal_Und
            ReportDataSource datasourceDeductInUttaranchal_Und;
             if(ds.Tables.Contains("DeductInUttaranchal_Und"))
            {
             datasourceDeductInUttaranchal_Und = new ReportDataSource("DeductInUttaranchal_Und", ds.Tables["DeductInUttaranchal_Und"]);
             }
             else
             { datasourceDeductInUttaranchal_Und = new ReportDataSource("DeductInUttaranchal_Und", dsdemo.Tables["DeductInUttaranchal_Und"]);
             }
            //DeductInNorthEast
            ReportDataSource datasourceDeductInNorthEast;
             if(ds.Tables.Contains("DeductInNorthEast"))
            {
            datasourceDeductInNorthEast = new ReportDataSource("DeductInNorthEast", ds.Tables["DeductInNorthEast"]);
             }
             else
             { datasourceDeductInNorthEast = new ReportDataSource("DeductInNorthEast", dsdemo.Tables["DeductInNorthEast"]);
             }
            //Assam_Und
            ReportDataSource datasourceAssam_Und;
            if(ds.Tables.Contains("Assam_Und"))
            {
             datasourceAssam_Und = new ReportDataSource("Assam_Und", ds.Tables["Assam_Und"]);
            }
            else
            {datasourceAssam_Und = new ReportDataSource("Assam_Und", dsdemo.Tables["Assam_Und"]);
            }
            //ArunachalPradesh_Und
            ReportDataSource datasourceArunachalPradesh_Und;
             if(ds.Tables.Contains("ArunachalPradesh_Und"))
            {
             datasourceArunachalPradesh_Und = new ReportDataSource("ArunachalPradesh_Und", ds.Tables["ArunachalPradesh_Und"]);
             }
             else
             { datasourceArunachalPradesh_Und = new ReportDataSource("ArunachalPradesh_Und", dsdemo.Tables["ArunachalPradesh_Und"]);
             }
            //Manipur_Und
            ReportDataSource datasourceManipur_Und;
             if(ds.Tables.Contains("Manipur_Und"))
            {
           datasourceManipur_Und = new ReportDataSource("Manipur_Und", ds.Tables["Manipur_Und"]);
             }
             else
             {datasourceManipur_Und = new ReportDataSource("Manipur_Und", dsdemo.Tables["Manipur_Und"]);
             }
            //Meghalaya_Und
            ReportDataSource datasourceMeghalaya_Und;
            if(ds.Tables.Contains("Meghalaya_Und"))
            {
             datasourceMeghalaya_Und = new ReportDataSource("Meghalaya_Und", ds.Tables["Meghalaya_Und"]);
            }
            else{
                datasourceMeghalaya_Und = new ReportDataSource("Meghalaya_Und", dsdemo.Tables["Meghalaya_Und"]);
            }
            //Nagaland_Und
            ReportDataSource datasourceNagaland_Und;
            if(ds.Tables.Contains("Nagaland_Und"))
            {
             datasourceNagaland_Und = new ReportDataSource("Nagaland_Und", ds.Tables["Nagaland_Und"]);
            }
            else
            { datasourceNagaland_Und = new ReportDataSource("Nagaland_Und", dsdemo.Tables["Nagaland_Und"]);
            }
            //Tripura_Und
            ReportDataSource datasourceTripura_Und;
            if(ds.Tables.Contains("Tripura_Und"))
            {
             datasourceTripura_Und = new ReportDataSource("Tripura_Und", ds.Tables["Tripura_Und"]);
            }
            else{
                datasourceTripura_Und = new ReportDataSource("Tripura_Und", dsdemo.Tables["Tripura_Und"]);
            }
            //Mizoram_Und
            ReportDataSource datasourceMizoram_Und;
            if(ds.Tables.Contains("Mizoram_Und"))
            {
             datasourceMizoram_Und = new ReportDataSource("Mizoram_Und", ds.Tables["Mizoram_Und"]);
            }
            else{
                datasourceMizoram_Und = new ReportDataSource("Mizoram_Und", dsdemo.Tables["Mizoram_Und"]);
            }
            //UsrDeductUndChapVIA
            ReportDataSource datasourceUsrDeductUndChapVIA;
            if(ds.Tables.Contains("UsrDeductUndChapVIA"))
            {
           datasourceUsrDeductUndChapVIA = new ReportDataSource("UsrDeductUndChapVIA", ds.Tables["UsrDeductUndChapVIA"]);
            }
            else
            {
                datasourceUsrDeductUndChapVIA = new ReportDataSource("UsrDeductUndChapVIA", dsdemo.Tables["UsrDeductUndChapVIA"]);
            }
            //ITRScheduleAMT
            ReportDataSource datasourceITRScheduleAMT;
            if(ds.Tables.Contains("ITRScheduleAMT"))
            {
             datasourceITRScheduleAMT = new ReportDataSource("ITRScheduleAMT", ds.Tables["ITRScheduleAMT"]);
            }
            else
            {
                datasourceITRScheduleAMT = new ReportDataSource("ITRScheduleAMT", dsdemo.Tables["ITRScheduleAMT"]);
            }
            //AdjustmentSec115JC
            ReportDataSource datasourceAdjustmentSec115JC;
                if(ds.Tables.Contains("AdjustmentSec115JC"))
                {
             datasourceAdjustmentSec115JC = new ReportDataSource("AdjustmentSec115JC", ds.Tables["AdjustmentSec115JC"]);
                }
                else
                {
                    datasourceAdjustmentSec115JC = new ReportDataSource("AdjustmentSec115JC", dsdemo.Tables["AdjustmentSec115JC"]);
                }
            //ITRScheduleAMT
            ReportDataSource datasourceITRScheduleAMTC;
            if(ds.Tables.Contains("ITRScheduleAMTC"))
            {
            datasourceITRScheduleAMTC = new ReportDataSource("ITRScheduleAMTC", ds.Tables["ITRScheduleAMTC"]);
            }
            else{
                datasourceITRScheduleAMTC = new ReportDataSource("ITRScheduleAMTC", dsdemo.Tables["ITRScheduleAMTC"]);
            }
            //ScheduleAMTC
            ReportDataSource datasourceScheduleAMTC;
             if(ds.Tables.Contains("ScheduleAMTC"))
            {
           datasourceScheduleAMTC = new ReportDataSource("ScheduleAMTC", ds.Tables["ScheduleAMTC"]);
             }
else{ datasourceScheduleAMTC = new ReportDataSource("ScheduleAMTC", dsdemo.Tables["ScheduleAMTC"]);
             }
            //SpecifiedPerson
            ReportDataSource datasourceSpecifiedPerson;
            if(ds.Tables.Contains("SpecifiedPerson"))
            {
            datasourceSpecifiedPerson = new ReportDataSource("SpecifiedPerson", ds.Tables["SpecifiedPerson"]);
            }
            else{
                datasourceSpecifiedPerson = new ReportDataSource("SpecifiedPerson", dsdemo.Tables["SpecifiedPerson"]);
            }
            //ScheduleEI
            ReportDataSource datasourceScheduleEI;
            if(ds.Tables.Contains("ScheduleEI"))
            {
             datasourceScheduleEI = new ReportDataSource("ScheduleEI", ds.Tables["ScheduleEI"]);
            }
            else{
                datasourceScheduleEI = new ReportDataSource("ScheduleEI", dsdemo.Tables["ScheduleEI"]);
            }
            //ScheduleFsiAy2014
             ReportDataSource datasourceScheduleFsiAy2014;
             if(ds.Tables.Contains("ScheduleFsiAy2014"))
            {
            datasourceScheduleFsiAy2014 = new ReportDataSource("ScheduleFsiAy2014", ds.Tables["ScheduleFsiAy2014"]);
             }
             else
             {
                 datasourceScheduleFsiAy2014 = new ReportDataSource("ScheduleFsiAy2014", dsdemo.Tables["ScheduleFsiAy2014"]);
             }
            //IncFromSal
            ReportDataSource datasourceIncFromSal;
             if(ds.Tables.Contains("IncFromSal"))
            {
          datasourceIncFromSal = new ReportDataSource("IncFromSal", ds.Tables["IncFromSal"]);
             }
             else
             {
                 datasourceIncFromSal = new ReportDataSource("IncFromSal", dsdemo.Tables["IncFromSal"]);
             }
            //IncFromHP
            ReportDataSource datasourceIncFromHP;
             if(ds.Tables.Contains("IncFromHP"))
            {
             datasourceIncFromHP = new ReportDataSource("IncFromHP", ds.Tables["IncFromHP"]);
             }
             else
             { datasourceIncFromHP = new ReportDataSource("IncFromHP", dsdemo.Tables["IncFromHP"]);
             }
            //IncFromBusiness
            ReportDataSource datasourceIncFromBusiness;
            if(ds.Tables.Contains("IncFromBusiness"))
            {
            datasourceIncFromBusiness = new ReportDataSource("IncFromBusiness", ds.Tables["IncFromBusiness"]);
            }
            else{
                  datasourceIncFromBusiness = new ReportDataSource("IncFromBusiness", dsdemo.Tables["IncFromBusiness"]);
            }
            //IncCapGain
            ReportDataSource datasourceIncCapGain;
             if(ds.Tables.Contains("IncCapGain"))
            {
           datasourceIncCapGain = new ReportDataSource("IncCapGain", ds.Tables["IncCapGain"]);
             }
             else
             {datasourceIncCapGain = new ReportDataSource("IncCapGain", dsdemo.Tables["IncCapGain"]);
             }
            //IncOthSrc
            ReportDataSource datasourceIncOthSrc;
             if(ds.Tables.Contains("IncOthSrc"))
            {
             datasourceIncOthSrc = new ReportDataSource("IncOthSrc", ds.Tables["IncOthSrc"]);
             }
             else
             {datasourceIncOthSrc = new ReportDataSource("IncOthSrc", dsdemo.Tables["IncOthSrc"]);
             }
            //TotalCountryWise
            ReportDataSource datasourceTotalCountryWise;
             if(ds.Tables.Contains("TotalCountryWise"))
            {
        datasourceTotalCountryWise = new ReportDataSource("TotalCountryWise", ds.Tables["TotalCountryWise"]);
             }
             else
             {datasourceTotalCountryWise = new ReportDataSource("TotalCountryWise", dsdemo.Tables["TotalCountryWise"]);
             }
            //ScheduleTR1
            //ScheduleFsiAy2014
            ReportDataSource datasourceScheduleTR1;
            if(ds.Tables.Contains("ScheduleTR1"))
            {
            datasourceScheduleTR1 = new ReportDataSource("ScheduleTR1", ds.Tables["ScheduleTR1"]);
            }
            else{ datasourceScheduleTR1 = new ReportDataSource("ScheduleTR1", dsdemo.Tables["ScheduleTR1"]);
            }
            ReportDataSource datasourceScheduleTR;
             if(ds.Tables.Contains("ScheduleTR"))
            {
        datasourceScheduleTR = new ReportDataSource("ScheduleTR", ds.Tables["ScheduleTR"]);
             }
             else
             {
                 datasourceScheduleTR = new ReportDataSource("ScheduleTR", dsdemo.Tables["ScheduleTR"]);
             }
            ReportDataSource datasourceDetailsForiegnBank;
             if(ds.Tables.Contains("DetailsForiegnBank"))
            {
             datasourceDetailsForiegnBank = new ReportDataSource("DetailsForiegnBank", ds.Tables["DetailsForiegnBank"]);
             }
             else
             {datasourceDetailsForiegnBank = new ReportDataSource("DetailsForiegnBank", dsdemo.Tables["DetailsForiegnBank"]);
             }
            //DetailsFinancialInterest
            ReportDataSource datasourceDetailsFinancialInterest;
             if(ds.Tables.Contains("DetailsFinancialInterest"))
            {
            datasourceDetailsFinancialInterest = new ReportDataSource("DetailsFinancialInterest", ds.Tables["DetailsFinancialInterest"]);
             }
             else
             {datasourceDetailsFinancialInterest = new ReportDataSource("DetailsFinancialInterest", dsdemo.Tables["DetailsFinancialInterest"]);
             }
            //DetailsImmovableProperty
            ReportDataSource datasourceDetailsImmovableProperty;
             if(ds.Tables.Contains("DetailsImmovableProperty"))
            {
           datasourceDetailsImmovableProperty = new ReportDataSource("DetailsImmovableProperty", ds.Tables["DetailsImmovableProperty"]);
             }
             else
             {datasourceDetailsImmovableProperty = new ReportDataSource("DetailsImmovableProperty", dsdemo.Tables["DetailsImmovableProperty"]);
             }
            //DetailsOthAssets
            ReportDataSource datasourceDetailsOthAssets;
             if(ds.Tables.Contains("DetailsOthAssets"))
            {
             datasourceDetailsOthAssets = new ReportDataSource("DetailsOthAssets", ds.Tables["DetailsOthAssets"]);
             }
             else
             {datasourceDetailsOthAssets = new ReportDataSource("DetailsOthAssets", dsdemo.Tables["DetailsOthAssets"]);
             }
            //DetailsOfAccntsHvngSigningAuth
            ReportDataSource datasourceDetailsOfAccntsHvngSigningAuth;
             if(ds.Tables.Contains("DetailsOfAccntsHvngSigningAuth"))
            {
             datasourceDetailsOfAccntsHvngSigningAuth = new ReportDataSource("DetailsOfAccntsHvngSigningAuth", ds.Tables["DetailsOfAccntsHvngSigningAuth"]);
             }
             else
             {datasourceDetailsOfAccntsHvngSigningAuth = new ReportDataSource("DetailsOfAccntsHvngSigningAuth", dsdemo.Tables["DetailsOfAccntsHvngSigningAuth"]);
             }
            //DetailsOfTrustOutIndiaTrustee
            ReportDataSource datasourceDetailsOfTrustOutIndiaTrustee;
             if(ds.Tables.Contains("DetailsOfTrustOutIndiaTrustee"))
            {
            datasourceDetailsOfTrustOutIndiaTrustee = new ReportDataSource("DetailsOfTrustOutIndiaTrustee", ds.Tables["DetailsOfTrustOutIndiaTrustee"]);
             }
             else
             { datasourceDetailsOfTrustOutIndiaTrustee = new ReportDataSource("DetailsOfTrustOutIndiaTrustee", dsdemo.Tables["DetailsOfTrustOutIndiaTrustee"]);
             }
            //DetailsOfOthSourcesIncOutsideIndia
           ReportDataSource datasourceDetailsOfOthSourcesIncOutsideIndia;
             if(ds.Tables.Contains("DetailsOfOthSourcesIncOutsideIndia"))
            {
            datasourceDetailsOfOthSourcesIncOutsideIndia = new ReportDataSource("DetailsOfOthSourcesIncOutsideIndia", ds.Tables["DetailsOfOthSourcesIncOutsideIndia"]);
             }
             else
             {datasourceDetailsOfOthSourcesIncOutsideIndia = new ReportDataSource("DetailsOfOthSourcesIncOutsideIndia", dsdemo.Tables["DetailsOfOthSourcesIncOutsideIndia"]);
             }
            //HPHeadIncome
             ReportDataSource datasourceHPHeadIncome;
            if(ds.Tables.Contains("HPHeadIncome"))
            {
             datasourceHPHeadIncome = new ReportDataSource("HPHeadIncome", ds.Tables["HPHeadIncome"]);
            }
            else
            {datasourceHPHeadIncome = new ReportDataSource("HPHeadIncome", dsdemo.Tables["HPHeadIncome"]);
            }
            //BusHeadIncome
            ReportDataSource datasourceBusHeadIncome;
             if(ds.Tables.Contains("BusHeadIncome"))
            {
           datasourceBusHeadIncome = new ReportDataSource("BusHeadIncome", ds.Tables["BusHeadIncome"]);
             }
             else
             { datasourceBusHeadIncome = new ReportDataSource("BusHeadIncome", dsdemo.Tables["BusHeadIncome"]);
             }
            ReportDataSource datasourceCapGainHeadIncome;
            if(ds.Tables.Contains("CapGainHeadIncome"))
            {
             datasourceCapGainHeadIncome = new ReportDataSource("CapGainHeadIncome", ds.Tables["CapGainHeadIncome"]);
            }
            else{
                datasourceCapGainHeadIncome = new ReportDataSource("CapGainHeadIncome", dsdemo.Tables["CapGainHeadIncome"]);
            }
            ReportDataSource datasourceOtherSourcesHeadIncome;
             if(ds.Tables.Contains("OtherSourcesHeadIncome"))
             {
             datasourceOtherSourcesHeadIncome = new ReportDataSource("OtherSourcesHeadIncome", ds.Tables["OtherSourcesHeadIncome"]);
             }
             else
             {  datasourceOtherSourcesHeadIncome = new ReportDataSource("OtherSourcesHeadIncome", dsdemo.Tables["OtherSourcesHeadIncome"]);
             }
            //TotalHeadIncome
            ReportDataSource datasourceTotalHeadIncome;
             if(ds.Tables.Contains("TotalHeadIncome"))
             {
            datasourceTotalHeadIncome = new ReportDataSource("TotalHeadIncome", ds.Tables["TotalHeadIncome"]);
             }
             else
             {
                 datasourceTotalHeadIncome = new ReportDataSource("TotalHeadIncome", dsdemo.Tables["TotalHeadIncome"]);
             }
            //Schedule5A2014
            ReportDataSource datasourceSchedule5A2014;
             if(ds.Tables.Contains("Schedule5A2014"))
             {
            datasourceSchedule5A2014 = new ReportDataSource("Schedule5A2014", ds.Tables["Schedule5A2014"]);
        }
        else{
            datasourceSchedule5A2014 = new ReportDataSource("Schedule5A2014", dsdemo.Tables["Schedule5A2014"]);
        }
            //MovableAsset
            ReportDataSource datasourceMovableAsset;
            if(ds.Tables.Contains("MovableAsset"))
            {
            datasourceMovableAsset = new ReportDataSource("MovableAsset", ds.Tables["MovableAsset"]);
            }
            else{
                 datasourceMovableAsset = new ReportDataSource("MovableAsset", dsdemo.Tables["MovableAsset"]);
            }
            //MovableAsset
             ReportDataSource datasourceScheduleAL;
            if(ds.Tables.Contains("ScheduleAL"))
            {
      datasourceScheduleAL = new ReportDataSource("ScheduleAL", ds.Tables["ScheduleAL"]);
            }
            else
            { 
                datasourceScheduleAL = new ReportDataSource("ScheduleAL", dsdemo.Tables["ScheduleAL"]);
            }

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasourceMovableAsset);
            ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleAL);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSchedule5A2014);
            ReportViewer1.LocalReport.DataSources.Add(datasourceHPHeadIncome);
            ReportViewer1.LocalReport.DataSources.Add(datasourceOtherSourcesHeadIncome);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBusHeadIncome);
            ReportViewer1.LocalReport.DataSources.Add(datasourceCapGainHeadIncome);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTotalHeadIncome);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDetailsForiegnBank);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDetailsFinancialInterest);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDetailsImmovableProperty);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDetailsOthAssets);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDetailsOfTrustOutIndiaTrustee);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDetailsOfAccntsHvngSigningAuth);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDetailsOfOthSourcesIncOutsideIndia);
            ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleTR1);
            ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleTR);
            ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleFsiAy2014);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncCapGain);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncFromSal);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncFromHP);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncFromBusiness);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncOthSrc);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTotalCountryWise);
            ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleEI);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSpecifiedPerson);
            ReportViewer1.LocalReport.DataSources.Add(datasourceITRScheduleAMTC);
            ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleAMTC);
            ReportViewer1.LocalReport.DataSources.Add(datasourceITRScheduleAMT);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAdjustmentSec115JC);
            ReportViewer1.LocalReport.DataSources.Add(datasourceUsrDeductUndChapVIA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSchedule80_IC);
            ReportViewer1.LocalReport.DataSources.Add(datasourceMizoram_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductInNorthEast);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductInSikkim_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductInHimachalP_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductInUttaranchal_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAssam_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceManipur_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceArunachalPradesh_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceMeghalaya_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNagaland_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTripura_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSch80DeductAmtDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductHospAnyAreaUs80IB_11C_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductMultiplexUs80_IB_7A_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSch80DeductAmtDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductRurHospUs80_IB_11B_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductFoodGrainUs80_IB_11A_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductFruitVegUs80_IB_11A_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductColdChainUs80_IB_11_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductMinOilUs80_IB_9_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductConvCentUs80_IB_7B_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductBackDisttUs80_IB_5_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductBackStatesUs80_IB_4_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductJKLocUs80_IB_4_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSchedule80_IB);

            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductUs80_IA_4_v);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductHousUs80_IB_10_Und);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductUs80_IA_4_iv);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductUs80_IA_4_iii);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSchedule80_IA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductUs80_IA_4_ii);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSch80DeductAmtDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDon50PercentNoApprReqd);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSchedule80G);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDon100PercentApprReqd);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDoneeWithPan);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDon100Percent);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAddressDetail);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDon50PercentApprReqd);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDedFromUndertakingWithAy);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDedUs10Detail);
            ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleUD);
            ReportViewer1.LocalReport.DataSources.Add(datasourceITR4ScheduleUD);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTotalBFLossSetOff);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncBFLA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceLossRemAftSetOff);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTotalLossSetOff);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncCYLA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncFromOwnHorse);
            ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleOS);
            ReportViewer1.LocalReport.DataSources.Add(datasourceOthersGrossDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNRIDTAADtlsSchOS);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncOthThanOwnRaceHorse);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncChargblSplRateOS);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductions);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBuildingSummary);
            ReportViewer1.LocalReport.DataSources.Add(datasourceUnutilizedCgPrvYrDtlsConst);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSaleofAssetNA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNRISaleofForeignAsset);
            ReportViewer1.LocalReport.DataSources.Add(datasourceProviso112Applicabledtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceLongTermCapGain23);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeducClaimInfo);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNRIProvisoSec48);
            ReportViewer1.LocalReport.DataSources.Add(datasourceLossRemainSetOff);
            ReportViewer1.LocalReport.DataSources.Add(datasourceShortTermCapGainFor23);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeducClaimDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTotLossSetOff);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSaleofLandBuild);
            ReportViewer1.LocalReport.DataSources.Add(datasourceEquityMFonSTT);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSlumpSaleInStcg);
            ReportViewer1.LocalReport.DataSources.Add(datasourceEquityMFonSTTDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductSec48);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNRITransacSec48Dtl);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNRISecur115AD);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSaleOnOtherAssets);
            ReportViewer1.LocalReport.DataSources.Add(datasourceExemptionOrDednUs54Dtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceUnutilizedCgPrvYrDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNRIDTAADtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceExemptionOrDednUs54);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDateRange);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInLtcg20Per);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInStcgAppRate);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInStcg30Per);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInStcg15Per);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInLossSetOff);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInLtcg10Per);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDepreciationDetail);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSummaryFromDeprSch);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePlantMachinerySummaryCG);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePlantMachinerySummary);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBuildingSummaryCG);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSummaryFromDeprSchCG);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductUs35);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBusinessIncOthThanSpec);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSpeculativeInc);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductUs35AC);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSpecifiedInc);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBusSetoffCurrYr);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSpecifiedBusinessInc);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSpecBusinessInc);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductUndChapVIA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeemedProfitBusUs);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncCredPL);
            ReportViewer1.LocalReport.DataSources.Add(datasourceExpDebToPLOthHeadDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDepreciationAllowITAct32);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncRecCredPLOthHeadDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncCredPL);
            ReportViewer1.LocalReport.DataSources.Add(datasourceOtherExmptIncDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePersonalInfo);
            ReportViewer1.LocalReport.DataSources.Add(datasourceOtherExmptIncDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePropertyDetails);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAssesseeName);
            ReportViewer1.LocalReport.DataSources.Add(datasourceA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceFS);
            //  ReportViewer1.LocalReport.DataSources.Add(datasourceID);
            //  ReportViewer1.LocalReport.DataSources.Add(datasourceUDUC);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIntrstPay);
            //  ReportViewer1.LocalReport.DataSources.Add(datasourceTC);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBankAccountDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePriBankDetails);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAddtnlBankDetails);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeclaration);
            ReportViewer1.LocalReport.DataSources.Add(datasourceVerification);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBusiness);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxReturnPreparer);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTrade);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePersumptiveInc44AD);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNoBooksOfAccBS);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBankAccountsDtls);
            // ReportViewer1.LocalReport.DataSources.Add(datasourceScheduleBPForITR4S);
            // ReportViewer1.LocalReport.DataSources.Add(datasourcePersumptiveInc44AE);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxPayment);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTDSonSalary);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTDSonOthThanSal);
            ReportViewer1.LocalReport.DataSources.Add(datasourceEmployerorDeductor);
            // ReportViewer1.LocalReport.DataSources.Add(datasourceForm_ITR);
            // ReportViewer1.LocalReport.DataSources.Add(datasourceIncOthThanOwnRaceHorce);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncFromOS);
            //ReportViewer1.LocalReport.DataSources.Add(datasourceIncChargblSplRateOS);
            //ReportViewer1.LocalReport.DataSources.Add(datasourceIncFromOwnHorse);
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncCYLA);
            ReportViewer1.LocalReport.DataSources.Add(datasourceShortTerm);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePartBTI);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAssesseeRep);
            ReportViewer1.LocalReport.DataSources.Add(datasourceComputationOfTaxLiability);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxPayableOnTI);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxesPaid);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSalaries);
            //ReportViewer1.LocalReport.DataSources.Add(datasourceSalarys);
            //  ReportViewer1.LocalReport.DataSources.Add(datasourceAddressDetail);
            //ReportViewer1.LocalReport.DataSources.Add(datasourcePropertyDetails);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAuditInfo);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAuditDetails);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTradeName);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePropFund);
            ReportViewer1.LocalReport.DataSources.Add(datasourceResrNSurp);
            ReportViewer1.LocalReport.DataSources.Add(datasourceLoanFunds);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSecrLoan);
            ReportViewer1.LocalReport.DataSources.Add(datasourceRupeeLoan);
            ReportViewer1.LocalReport.DataSources.Add(datasourceUnsecrLoan);
            ReportViewer1.LocalReport.DataSources.Add(datasourceFundSrc);
            ReportViewer1.LocalReport.DataSources.Add(datasourceFixedAsset);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInvestments);
            ReportViewer1.LocalReport.DataSources.Add(datasourceLongTermInv);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTradeInv);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInventories);
            ReportViewer1.LocalReport.DataSources.Add(datasourceCashOrBankBal);
            ReportViewer1.LocalReport.DataSources.Add(datasourceCurrAssetLoanAdv);
            ReportViewer1.LocalReport.DataSources.Add(datasourceLoanAdv);
            ReportViewer1.LocalReport.DataSources.Add(datasourceCurrLiabilities);
            ReportViewer1.LocalReport.DataSources.Add(datasourceProvisions);
            ReportViewer1.LocalReport.DataSources.Add(datasourceMiscAdjust);
            ReportViewer1.LocalReport.DataSources.Add(datasourceCreditsToPL);
            ReportViewer1.LocalReport.DataSources.Add(datasourceOtherOperatingRevenueDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceOthIncome);
            ReportViewer1.LocalReport.DataSources.Add(datasourceOtherIncDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceClosingStockDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceSlumpSaleInLtcg);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDebitsToPL);
            ReportViewer1.LocalReport.DataSources.Add(datasourceOpeningStockDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceEmployeeComp);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInsurances);
            ReportViewer1.LocalReport.DataSources.Add(datasourceCommissionExpdrDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceRoyalityDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceProfessionalConstDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceExciseCustomsVAT);
            ReportViewer1.LocalReport.DataSources.Add(datasourceCreditsToPL);
            ReportViewer1.LocalReport.DataSources.Add(datasourceOtherExpensesDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNoBooksOfAccPL);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxProvApprL);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBadDebtDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceBadDebtAmtDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourceInterestExpdrtDtls);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePARTAOI);
            ReportViewer1.LocalReport.DataSources.Add(datasourceMethodOfValClgStk);
            ReportViewer1.LocalReport.DataSources.Add(datasourceNoCredToPLAAmt);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAmtDisallUs36);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAmtDisallUs37);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAmtDisallUs40);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAmtDisallUs40A);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAmtUs43B1);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAmtUs43B2);
            ReportViewer1.LocalReport.DataSources.Add(datasourceQuantitDet);
            ReportViewer1.LocalReport.DataSources.Add(datasourceQuantitDet1);
            ReportViewer1.LocalReport.DataSources.Add(datasourceQuantitDet2);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAmtDisallUs43BPyNowAll);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAmtDisall43B);
            ReportViewer1.LocalReport.DataSources.Add(datasourceProfBusGain);
            ReportViewer1.LocalReport.DataSources.Add(datasourceShortTerm);
            ReportViewer1.LocalReport.DataSources.Add(datasourceLongTerm);
            ReportViewer1.LocalReport.DataSources.Add(datasourceCapGain);
            ReportViewer1.LocalReport.DataSources.Add(datasourceDeductionsUndSchVIADtl);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxPayableOnDeemedTI);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxRelief);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTaxPaid);
            ReportViewer1.LocalReport.DataSources.Add(datasourceRefund);
            ReportViewer1.LocalReport.DataSources.Add(datasourceTCS);
            ReportViewer1.LocalReport.DataSources.Add(datasourcePartBTTI);
            ReportViewer1.LocalReport.DataSources.Add(datasourceAddressDetailHp);
            //ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(AddressDetailHpSubReportProcessing);

            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(COownerSubReportProcessing);

            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(TenantDetailsSubReportProcessing);

            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(RentdetailsSubReportProcessing);
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(AddressDetailSubReportProcessing);

            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SalarysSubReportProcessing);
           
            ReportViewer1.LocalReport.Refresh();


        }


    }
    void COownerSubReportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        if (e.Parameters.Count != 0)
        {
            if (e.Parameters[0].Name == "PropertyDetails_Id")
            {
                int PropertyDetails_Id = int.Parse(e.Parameters["PropertyDetails_Id"].Values[0].ToString());
                DataTable dtCoOwner = GetCOownerByPropertyDetails_Id(PropertyDetails_Id);
                ReportDataSource ds = new ReportDataSource("CoOwner", dtCoOwner);
                e.DataSources.Add(ds);
            }
            // ReportViewer1.LocalReport.Refresh();
        }
    }
    void TenantDetailsSubReportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        if (e.Parameters.Count != 0)
        {
            if (e.Parameters[0].Name == "PropertyDetails_Id")
            {
                int PropertyDetails_Id = int.Parse(e.Parameters["PropertyDetails_Id"].Values[0].ToString());
                DataTable dtTenant = GetTenantPropertyDetails_Id(PropertyDetails_Id);
                ReportDataSource ds = new ReportDataSource("Tenant", dtTenant);
                e.DataSources.Add(ds);
                //ReportViewer1.LocalReport.Refresh();
            }
        }
    }
    void RentdetailsSubReportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        if (e.Parameters.Count != 0)
        {
            if (e.Parameters[0].Name == "PropertyDetails_Id")
            {
                int PropertyDetails_Id = int.Parse(e.Parameters["PropertyDetails_Id"].Values[0].ToString());
                DataTable dtRentdetails = GetRentdetailsPropertyDetails_Id(PropertyDetails_Id);
                ReportDataSource ds = new ReportDataSource("Rentdetails", dtRentdetails);
                e.DataSources.Add(ds);
            }
            // ReportViewer1.LocalReport.Refresh();
        }
    }
    void SalarysSubReportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        if (e.Parameters.Count != 0)
        {
            if (e.Parameters[0].Name == "Salaries_Id")
            {
                int Salaries_id = int.Parse(e.Parameters["Salaries_Id"].Values[0].ToString());
                DataTable dtSalarys = GetSalarysBySalariesID(Salaries_id);
                ReportDataSource ds = new ReportDataSource("Salarys", dtSalarys);
                e.DataSources.Add(ds);
                // ReportViewer1.LocalReport.Refresh();
            }
        }
    }

    void AddressDetailSubReportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        if (e.Parameters.Count != 0)
        {
            if (e.Parameters[0].Name == "Salaries_Id")
            {
                int Salaries_id = int.Parse(e.Parameters["Salaries_Id"].Values[0].ToString());
                DataTable dtAddressDetail = GetAddressDetailBySalariesID(Salaries_id);
                ReportDataSource ds = new ReportDataSource("AddressDetail", dtAddressDetail);
                e.DataSources.Add(ds);
                // ReportViewer1.LocalReport.Refresh();
            }
        }
    }
    private DataTable GetCOownerByPropertyDetails_Id(int PropertyDetails_Id)
    {
        DataRow[] dr;
        if (ds.Tables.Contains("CoOwners"))
        {
            dr = ds.Tables["CoOwners"].Select("PropertyDetails_Id=" + PropertyDetails_Id);
        }
        else
        {
            dr = dsdemo.Tables["CoOwners"].Select("PropertyDetails_Id=" + PropertyDetails_Id);
        }
        DataTable dt = new DataTable();
        dt.Columns.Add("CoOwnersSNo", typeof(int));
        dt.Columns.Add("NameCoOwner", typeof(string));
        dt.Columns.Add("PAN_CoOwner", typeof(string));
        dt.Columns.Add("PercentShareProperty", typeof(string));
        dt.Columns.Add("PropertyDetails_Id", typeof(int));
        if (dr.Length > 0)
        {
            dt.ImportRow(dr[0]);
        }
        return dt;
    }
    private DataTable GetAddressDetailBySalariesID(int SalariesId)
    {
        DataRow[] dr;
        if (ds.Tables.Contains("AddressDetail"))
        {
            dr = ds.Tables["AddressDetail"].Select("Salaries_Id=" + SalariesId);
        }
        else
        {
            dr = dsdemo.Tables["AddressDetail"].Select("Salaries_Id=" + SalariesId);
        }
        DataTable dt = new DataTable();
        dt.Columns.Add("AddrDetail", typeof(string));
        dt.Columns.Add("CityOrTownOrDistrict", typeof(string));
        dt.Columns.Add("StateCode", typeof(string));
        dt.Columns.Add("PinCode", typeof(int));
        dt.Columns.Add("Salaries_Id", typeof(int));
        dt.ImportRow(dr[0]);
        return dt;
    }
    private DataTable GetSalarysBySalariesID(int SalariesId)
    {
        DataRow[] dr;
        if (ds.Tables.Contains("Salarys"))
        {
            dr = ds.Tables["Salarys"].Select("Salaries_Id=" + SalariesId);
        }
        else
        {
            dr = dsdemo.Tables["Salarys"].Select("Salaries_Id=" + SalariesId);
        }
        DataTable dt = new DataTable();
        dt.Columns.Add("Salary", typeof(string));
        dt.Columns.Add("ExemptUSection10Travel", typeof(string));
        dt.Columns.Add("ExemptUSection10NonMonetary", typeof(string));
        dt.Columns.Add("ExemptUSection10HouseRent", typeof(string));
        dt.Columns.Add("ExemptUSection10Oth", typeof(string));
        dt.Columns.Add("AllowancesNotExempt", typeof(string));
        dt.Columns.Add("ValueOfPerquisites", typeof(string));
        dt.Columns.Add("ProfitsinLieuOfSalary", typeof(string));
        dt.Columns.Add("DeductionUnderSection16", typeof(string));
        dt.Columns.Add("IncomeFromSalary", typeof(string));
        dt.Columns.Add("Salaries_Id", typeof(int));
        dt.ImportRow(dr[0]);
        return dt;
    }
    private DataTable GetTenantPropertyDetails_Id(int PropertyDetails_Id)
    {
        DataRow[] dr;
        if (ds.Tables.Contains("TenantDetails"))
        {
            dr = ds.Tables["TenantDetails"].Select("PropertyDetails_Id=" + PropertyDetails_Id);
        }
        else
        {
            dr = dsdemo.Tables["TenantDetails"].Select("PropertyDetails_Id=" + PropertyDetails_Id);
        }
        DataTable dt = new DataTable();
        dt.Columns.Add("TenantSNo", typeof(int));
        dt.Columns.Add("NameofTenant", typeof(string));
        dt.Columns.Add("PANofTenant", typeof(string));
        dt.Columns.Add("PropertyDetails_Id", typeof(int));
        if (dr.Length > 0)
        {
            dt.ImportRow(dr[0]);
        }
        return dt;
    }
    private DataTable GetRentdetailsPropertyDetails_Id(int PropertyDetails_Id)
    {DataRow[] dr;
    if (ds.Tables.Contains("Rentdetails"))
    {
        dr = ds.Tables["Rentdetails"].Select("PropertyDetails_Id=" + PropertyDetails_Id);
    }
    else
    {
        dr = dsdemo.Tables["Rentdetails"].Select("PropertyDetails_Id=" + PropertyDetails_Id);
    }
        DataTable dt = new DataTable();
        dt.Columns.Add("AnnualLetableValue", typeof(string));
        dt.Columns.Add("RentNotRealized", typeof(string));
        dt.Columns.Add("LocalTaxes", typeof(string));
        dt.Columns.Add("TotalUnrealizedAndTax", typeof(string));
        dt.Columns.Add("BalanceALV", typeof(string));
        dt.Columns.Add("AnnualOfPropOwned", typeof(string));
        dt.Columns.Add("ThirtyPercentOfBalance", typeof(string));
        dt.Columns.Add("IntOnBorwCap", typeof(string));
        dt.Columns.Add("TotalDeduct", typeof(string));
        dt.Columns.Add("IncomeOfHP", typeof(string));
        dt.Columns.Add("PropertyDetails_Id", typeof(int));
        if (dr.Length > 0)
        {
            dt.ImportRow(dr[0]);
        }
        return dt;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Presentation/salary.aspx?vtype=40");
    }
}