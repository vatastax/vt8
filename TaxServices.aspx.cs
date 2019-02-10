using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Serviceitrvstatus;
using System.Data;
using ServiceGet26As;
using System.Reflection;
using System.Globalization;
using ServiceReFUNDSTATUS;
public partial class TaxServices : System.Web.UI.Page
{
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

        if (!Page.IsPostBack)
        {
            for (int i = 11; i < 30; i++)
            {
                DDLYear1.Items.Add("20" + i + "-" + (i + 1));
                DDLYear.Items.Add("20" + i + "-" + (i + 1));
                //DDL_AY.Items.Add("20" + i + "-" + (i + 1));
            }
            if (Request.QueryString["service"].ToString() == "ITRV")
            {
                MultiView1.SetActiveView(VwITRV);
            }
            else if (Request.QueryString["service"].ToString() == "26AS")
            {
                MultiView1.SetActiveView(Vw26AS);
            }
            else if (Request.QueryString["service"].ToString() == "RefundStatus")
            {
                MultiView1.SetActiveView(VwRefundStatus);
            }
        }

        ltWelcome.Text = "Welcome <a href='Presentation/'>" + Session["user_name"].ToString() + "</a>";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        lbl_status_Itr.Text = "";
        lblError.Text = "";
        try
        {
            //Sending PAN and AY Details
            getITRVStatusRequest obj_getITRVStatusRequest = new getITRVStatusRequest();
            obj_getITRVStatusRequest.PAN = Txt_PAN.Text;
            obj_getITRVStatusRequest.AssessmentYear = DDLYear.SelectedItem.Text;

            //Providing Details Further
            getITRVStatusRequest1 obj_getITRVStatusRequest1 = new getITRVStatusRequest1(obj_getITRVStatusRequest);

            //Getting Response from Income Tax India
            getITRVStatusResponse obj_getITRVStatusResponse = new getITRVStatusResponse();
            getITRVStatusResponse1 obj_getITRVStatusResponse1 = new getITRVStatusResponse1(obj_getITRVStatusResponse);


            //Connecting The Income Tax India via Endpoint Name and Remote Address
            itrvstatusPortClient obj_itrvstatusPortClient = new itrvstatusPortClient("itrvstatusPortSoap11", "https://incometaxindiaefiling.gov.in/e-FilingWS/ditws");
            obj_itrvstatusPortClient.Open();
            obj_getITRVStatusResponse = obj_itrvstatusPortClient.getITRVStatus(obj_getITRVStatusRequest);

            lbl_status_Itr.Text = obj_getITRVStatusResponse.result;
        }
        catch (Exception ex)
        {
            lblError.Text = "Sorry!!!!!!please try after some time";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        GrdVw_TaxPayments.DataSource = ""; GrdVw_TaxPayments.DataBind();
        GrdVw_TCS.DataSource = ""; GrdVw_TCS.DataBind();
        GrdVw_TDSOnOthSal.DataSource = ""; GrdVw_TDSOnOthSal.DataBind();
        GrdVw_TDSonSal.DataSource = ""; GrdVw_TDSonSal.DataBind();

        try
        {

            //Providing Login Details
            ServiceGet26As.LoginInfoType obj_LoginInfoType = new ServiceGet26As.LoginInfoType();
            obj_LoginInfoType.userName = "ERIA100133";
            obj_LoginInfoType.password = "gill123456@";


            //Providing Client Details

            //DateTime Date_of_Birth = DateTime.ParseExact(TxtDOB.Text.TrimEnd().TrimStart(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime Date_of_Birth;
            string[] formats = { "yyyy-MM-dd" };
            DateTime.TryParseExact(txtDob1.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out Date_of_Birth);

            ServiceGet26As.ClientInfoType obj_ClientInfoType = new ClientInfoType();
            obj_ClientInfoType.pan = txtPan11.Text.ToString();
            obj_ClientInfoType.dob = Date_of_Birth;
            obj_ClientInfoType.assessmentYear = DDLYear1.SelectedItem.Text;


            //Fetching TDS Details via LoginInfo and ClientInfo
            ServiceGet26As.getTDSDetails obj_getTDSDetails = new getTDSDetails();
            obj_getTDSDetails.ClientInfo = obj_ClientInfoType;
            obj_getTDSDetails.LoginInfo = obj_LoginInfoType;

            
            //Creating a TDS Request with GetTDSDetails Class Object
            ServiceGet26As.GetTDSRequest obj_GetTDSRequest = new GetTDSRequest(obj_getTDSDetails);
            obj_GetTDSRequest.getTDSDetails = obj_getTDSDetails;

            //Getting TAN and TAN Name Details
            ServiceGet26As.EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDetl = new EmployerOrDeductorOrCollectDetl();

            //Passing TDS Details as parameter in TDSPortClient
            ServiceGet26As.GetTDSPortClient obj_GetTDSPortClient = new GetTDSPortClient("GetTDSPortSoap11", "https://incometaxindiaefiling.gov.in/e-FilingWS/ditws");
            obj_GetTDSPortClient.Open();

            ServiceGet26As.GetTDSResponseType obj_GetTDSResponseType = new GetTDSResponseType();
            obj_GetTDSResponseType = obj_GetTDSPortClient.getTDSDetails(obj_getTDSDetails);

            //Getting The TDS Response
            ServiceGet26As.GetTDSResponse obj_GetTDSResponse = new GetTDSResponse();
            obj_GetTDSResponse.GetTDSResponse1 = obj_GetTDSResponseType;

            //-----------------------------------------------------------------------------
            //Getting TDS on Salary Data.....
            //-----------------------------------------------------------------------------
            if (obj_GetTDSResponse.GetTDSResponse1.TDSonSalaries != null)
            {

                int Length_TDSOnSal_Array = obj_GetTDSResponseType.TDSonSalaries.Length;
                ServiceGet26As.TDSonSalary[] obj_TDSonSalary = obj_GetTDSResponseType.TDSonSalaries;



                DataTable dt_arr = new DataTable();
                dt_arr.Columns.Add("TAN", typeof(String));
                dt_arr.Columns.Add("TAN Name", typeof(String));
                dt_arr.Columns.Add("Income Chargeable on Salary", typeof(String));
                dt_arr.Columns.Add("Total TDS Salary", typeof(String));

                for (int i = 0; i < obj_GetTDSResponseType.TDSonSalaries.Length; i++)
                {
                    var x = obj_TDSonSalary[i].IncChrgSal.ToString();
                    var y = obj_TDSonSalary[i].TotalTDSSal.ToString();
                    obj_EmployerOrDeductorOrCollectDetl = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl;

                    DataRow Dr = dt_arr.NewRow();
                    Dr["TAN"] = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.TAN;
                    Dr["TAN Name"] = obj_TDSonSalary[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    Dr["Income Chargeable on Salary"] = x;
                    Dr["Total TDS Salary"] = y;
                    dt_arr.Rows.Add(Dr);
                }
                //TDS on Salary Retrieved in Grid View
                GrdVw_TDSonSal.DataSource = dt_arr;
                GrdVw_TDSonSal.DataBind();




            }

            //------------------------------------------------------------------------------------
            //Getting TDS On Other Than Salary Data......
            //--------------------------------------------------------------------------------
            if (obj_GetTDSResponse.GetTDSResponse1.TDSonOthThanSals != null)
            {

                int Length_TDSOnOthSal_Array = obj_GetTDSResponseType.TDSonOthThanSals.Length;
                ServiceGet26As.TDSonOthThanSal[] obj_TDSonOthThanSal = new TDSonOthThanSal[Length_TDSOnOthSal_Array];
                obj_TDSonOthThanSal = obj_GetTDSResponseType.TDSonOthThanSals;

                DataTable dt_arr = new DataTable();
                dt_arr.Columns.Add("TAN", typeof(String));
                dt_arr.Columns.Add("TAN Name", typeof(String));
                dt_arr.Columns.Add("Total TDS On Amt Paid", typeof(String));
                dt_arr.Columns.Add("Claim Out Of Tot. TDS On Amt Paid", typeof(String));
                for (int i = 0; i < obj_GetTDSResponseType.TDSonOthThanSals.Length; i++)
                {
                    var x = obj_TDSonOthThanSal[i].TotTDSOnAmtPaid.ToString();
                    var y = obj_TDSonOthThanSal[i].ClaimOutOfTotTDSOnAmtPaid.ToString();
                    EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDet1_2 = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl;





                    DataRow Dr = dt_arr.NewRow();
                    Dr["TAN"] = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.TAN;
                    Dr["TAN Name"] = obj_TDSonOthThanSal[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    Dr["Total TDS On Amt Paid"] = x;
                    Dr["Claim Out Of Tot. TDS On Amt Paid"] = y;
                    dt_arr.Rows.Add(Dr);
                }
                //TDS on Other Than Salary Retrieved in Grid View
                GrdVw_TDSOnOthSal.DataSource = dt_arr;
                GrdVw_TDSOnOthSal.DataBind();

            }

            //--------------------------------------------------------------------------------------
            //Getting TCS Details Array
            //---------------------------------------------------------------------------------------
            if (obj_GetTDSResponse.GetTDSResponse1.ScheduleTCS != null)
            {

                int length_TCS_Array = obj_GetTDSResponse.GetTDSResponse1.ScheduleTCS.Length;
                ServiceGet26As.TCS[] obj_TCS = new TCS[length_TCS_Array];
                obj_TCS = obj_GetTDSResponseType.ScheduleTCS;

                DataTable dt = new DataTable();
                dt.Columns.Add("TAN", typeof(String));
                dt.Columns.Add("TAN Name", typeof(String));
                dt.Columns.Add("Total TCS", typeof(String));
                dt.Columns.Add("Amt TC Claimed This Year", typeof(String));

                for (int i = 0; i < obj_GetTDSResponseType.ScheduleTCS.Length; i++)
                {

                    var x = obj_TCS[i].AmtTCSClaimedThisYear.ToString();
                    var y = obj_TCS[i].TotalTCS.ToString();
                    EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDet1_3 = obj_TCS[i].EmployerOrDeductorOrCollectDetl;

                    DataRow dr = dt.NewRow();
                    dr["TAN"] = obj_TCS[i].EmployerOrDeductorOrCollectDetl.TAN;
                    dr["TAN Name"] = obj_TCS[i].EmployerOrDeductorOrCollectDetl.EmployerOrDeductorOrCollecterName;
                    dr["Total TCS"] = x;
                    dr["Amt TC Claimed This Yeard"] = y;
                }

                //TCS Data Retrieved in GridView
                GrdVw_TCS.DataSource = dt;
                GrdVw_TCS.DataBind();
            }

            //------------------------------------------------------------------------------------------
            //Getting Tax Payments Arrays.
            //-------------------------------------------------------------------------------------------
            if (obj_GetTDSResponse.GetTDSResponse1.TaxPayments != null)
            {

                int Length_Taxpayments_Array = obj_GetTDSResponseType.TaxPayments.Length;
                ServiceGet26As.TaxPayment[] obj_TaxPayment = new TaxPayment[Length_Taxpayments_Array];
                obj_TaxPayment = obj_GetTDSResponseType.TaxPayments;


                //Tax Payment Data Retrieved in Grid View
                GrdVw_TaxPayments.DataSource = ConvertArrayToDataTable(obj_TaxPayment);
                GrdVw_TaxPayments.DataBind();
                GrdVw_TaxPayments.HeaderRow.Cells[0].Text = "BSR Code";
                GrdVw_TaxPayments.HeaderRow.Cells[1].Text = "Dt. Deposited";
                GrdVw_TaxPayments.HeaderRow.Cells[2].Text = "Sr. No. of Challan";
                GrdVw_TaxPayments.HeaderRow.Cells[3].Text = "Amount";
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    public DataTable ConvertArrayToDataTable(object[] inArray)
    {

        //create our datatable
        DataTable dt = new DataTable();


        if (inArray.Length == 0)
            return new DataTable();
        //initialize a new type of our inArray type
        Type type = inArray[0].GetType();

        
        //extract all our properties (public & static) from our type (generic)
        PropertyInfo[] proInfo = type.GetProperties();


        //create the columns for each property setting the name & type (generic)
        foreach (PropertyInfo i in proInfo)
            dt.Columns.Add(i.Name, i.PropertyType);


        //loop through each object in the array
        foreach (object o in inArray)
        {
            //create a new datarow
            DataRow r = dt.NewRow();
            //loop through each property in order and set our row columns to the value of the property
            for (int i = 0; i < proInfo.Length; i++)
                r[i] = o.GetType().InvokeMember(proInfo[i].Name, BindingFlags.GetProperty, null, o, null);


            //add the row to our table
            dt.Rows.Add(r);
        }

        return dt;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        lblRefundDemand.Text = getrefund(TextBox3.Text, TextBox4.Text);
    }
    public string getrefund(string pan, string assyear)
    {
        try
        {
            //create object of logininfo
            ServiceReFUNDSTATUS.LoginInfoType obj_Login = new ServiceReFUNDSTATUS.LoginInfoType();
            obj_Login.userName = "ERIA100133";
            obj_Login.password = "gill123456@";

            //create object of refund input

            ServiceReFUNDSTATUS.RefundInputType obj_RefundInputType = new RefundInputType();
            obj_RefundInputType.panNo = pan;
            obj_RefundInputType.asseessmentyear = assyear;


            //client

            ServiceReFUNDSTATUS.refundstatusPortClient client = new refundstatusPortClient("refundstatusPortSoap11", "https://incometaxindiaefiling.gov.in/e-FilingWS/ditws");
            client.Open();

            //request


            ServiceReFUNDSTATUS.getRefundStatusRequest obj_getRefundStatusRequest = new getRefundStatusRequest();
            obj_getRefundStatusRequest.LoginInfo = obj_Login;
            obj_getRefundStatusRequest.RefundInput = obj_RefundInputType;

            //requset2

            ServiceReFUNDSTATUS.getRefundStatusRequest1 obj_getRefundStatusRequest1 = new getRefundStatusRequest1();
            obj_getRefundStatusRequest1.getRefundStatusRequest = obj_getRefundStatusRequest;

            //response

            ServiceReFUNDSTATUS.getRefundStatusResponse obj_getRefundStatusResponse = new getRefundStatusResponse();
            obj_getRefundStatusResponse.result = client.getRefundStatus(obj_getRefundStatusRequest).result;


            //response2


            ServiceReFUNDSTATUS.getRefundStatusResponse1 obj_getRefundStatusresponse1 = new getRefundStatusResponse1();
            obj_getRefundStatusresponse1.getRefundStatusResponse = obj_getRefundStatusResponse;

            string result = obj_getRefundStatusresponse1.getRefundStatusResponse.result.ToString();
            return result;
        }
        catch (Exception ex)
        {
            //return ex.Message;
            lblRefundDemand.ForeColor = System.Drawing.Color.Red;
           return lblRefundDemand.Text = "Sorry!!!!!!please try after some time";
           
        }





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