using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITR_V_Status;

public partial class Retrieve_ITR_V_Status : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            for (int i = 11; i < 20; i++)
            {
                DDLYear.Items.Add("20" + i + "-" + (i + 1));
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lbl_status.Text = "";
        lblError.Text = "";
        try
        {
            //Sending PAN and AY Details
            ITR_V_Status.getITRVStatusRequest obj_getITRVStatusRequest = new getITRVStatusRequest();
            obj_getITRVStatusRequest.PAN = Txt_PAN.Text;
            obj_getITRVStatusRequest.AssessmentYear = DDLYear.SelectedItem.Text;

            //Providing Details Further
            ITR_V_Status.getITRVStatusRequest1 obj_getITRVStatusRequest1 = new getITRVStatusRequest1(obj_getITRVStatusRequest);

            //Getting Response from Income Tax India
            ITR_V_Status.getITRVStatusResponse obj_getITRVStatusResponse = new getITRVStatusResponse();
            ITR_V_Status.getITRVStatusResponse1 obj_getITRVStatusResponse1 = new getITRVStatusResponse1(obj_getITRVStatusResponse);


            //Connecting The Income Tax India via Endpoint Name and Remote Address
            ITR_V_Status.itrvstatusPortClient obj_itrvstatusPortClient = new itrvstatusPortClient("itrvstatusPortSoap11", "https://incometaxindiaefiling.gov.in/e-FilingWS/ditws");
            obj_itrvstatusPortClient.Open();
            obj_getITRVStatusResponse = obj_itrvstatusPortClient.getITRVStatus(obj_getITRVStatusRequest);

            lbl_status.Text = obj_getITRVStatusResponse.result;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}