using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GetTDSReference;
using System.Globalization;
using System.Data;
using System.Reflection;

public partial class Retrieve26ASInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            for (int i = 11; i < 30; i++)
            {
                DDLYear.Items.Add("20" + i + "-" + (i + 1));
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        GrdVw_TaxPayments.DataSource = ""; GrdVw_TaxPayments.DataBind();
        GrdVw_TCS.DataSource = ""; GrdVw_TCS.DataBind();
        GrdVw_TDSOnOthSal.DataSource = ""; GrdVw_TDSOnOthSal.DataBind();
        GrdVw_TDSonSal.DataSource = ""; GrdVw_TDSonSal.DataBind();

        try
        {

            //Providing Login Details
            GetTDSReference.LoginInfoType obj_LoginInfoType = new LoginInfoType();
            obj_LoginInfoType.userName = "ERIA100133";
            obj_LoginInfoType.password = "gill123456@";


            //Providing Client Details
            
            //DateTime Date_of_Birth = DateTime.ParseExact(TxtDOB.Text.TrimEnd().TrimStart(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime Date_of_Birth;
            string[] formats = { "yyyy-MM-dd" };
            DateTime.TryParseExact(TxtDOB.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out Date_of_Birth);

            GetTDSReference.ClientInfoType obj_ClientInfoType = new ClientInfoType();
            obj_ClientInfoType.pan = TxtPAN.Text.ToString();
            obj_ClientInfoType.dob = Date_of_Birth;
            obj_ClientInfoType.assessmentYear = DDLYear.SelectedItem.Text;


            //Fetching TDS Details via LoginInfo and ClientInfo
            GetTDSReference.getTDSDetails obj_getTDSDetails = new getTDSDetails();
            obj_getTDSDetails.ClientInfo = obj_ClientInfoType;
            obj_getTDSDetails.LoginInfo = obj_LoginInfoType;
            

            //Creating a TDS Request with GetTDSDetails Class Object
            GetTDSReference.GetTDSRequest obj_GetTDSRequest = new GetTDSRequest(obj_getTDSDetails);
            obj_GetTDSRequest.getTDSDetails = obj_getTDSDetails;

           //Getting TAN and TAN Name Details
            GetTDSReference.EmployerOrDeductorOrCollectDetl obj_EmployerOrDeductorOrCollectDetl = new EmployerOrDeductorOrCollectDetl();
            
            //Passing TDS Details as parameter in TDSPortClient
            GetTDSReference.GetTDSPortClient obj_GetTDSPortClient = new GetTDSPortClient("GetTDSPortSoap11", "https://incometaxindiaefiling.gov.in/e-FilingWS/ditws");
            obj_GetTDSPortClient.Open();

            GetTDSReference.GetTDSResponseType obj_GetTDSResponseType = new GetTDSResponseType();
            obj_GetTDSResponseType = obj_GetTDSPortClient.getTDSDetails(obj_getTDSDetails);

            //Getting The TDS Response
            GetTDSReference.GetTDSResponse obj_GetTDSResponse = new GetTDSResponse();
            obj_GetTDSResponse.GetTDSResponse1 = obj_GetTDSResponseType;

            //-----------------------------------------------------------------------------
            //Getting TDS on Salary Data.....
            //-----------------------------------------------------------------------------
            if (obj_GetTDSResponse.GetTDSResponse1.TDSonSalaries != null)
            {

                int Length_TDSOnSal_Array = obj_GetTDSResponseType.TDSonSalaries.Length;
                GetTDSReference.TDSonSalary[] obj_TDSonSalary =obj_GetTDSResponseType.TDSonSalaries ;


                
                DataTable dt_arr = new DataTable();
                dt_arr.Columns.Add("TAN",typeof(String));
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
                GetTDSReference.TDSonOthThanSal[] obj_TDSonOthThanSal = new TDSonOthThanSal[Length_TDSOnOthSal_Array];
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
                GetTDSReference.TCS[] obj_TCS = new TCS[length_TCS_Array];
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
                GetTDSReference.TaxPayment[] obj_TaxPayment = new TaxPayment[Length_Taxpayments_Array];
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
    
    /// <summary>
    /// Convert Objects Array into DataTable
    /// </summary>
    /// <param name="inArray"></param>
    /// <returns></returns>
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
}