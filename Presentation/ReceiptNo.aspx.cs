using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentation_ReceiptNo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msg_CsiFileDownload.btn_ok_click += new EventHandler(msg_CsiFileDownload_btn_ok_click);
        msg_CsiFileDownload.btn_Cancel_click += new EventHandler(msg_CsiFileDownload_btn_Cancel_click);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Session["REC"] != null)
        {
            Session["REC"] = null;
            CSI_FVU();
            ClientScript.RegisterClientScriptBlock(GetType(), "asd", "<script type='text/javascript'>endProcess();</script>");
        }
    }
    protected void msg_CsiFileDownload_btn_Cancel_click(object sender, EventArgs e)
    {

    }

    protected void msg_CsiFileDownload_btn_ok_click(object sender, EventArgs e)
    {
        CSI_FVU();
    }
    private void CSI_FVU2()
    {

    }
    private void CSI_FVU()
    {
        //Initialize Variables
        string TAN = Session["TAN"].ToString();
        string FY = Session["FY"].ToString();
        string Quarter = Session["qtr"].ToString();// ViewState["Quarter"].ToString();
        string Quarter_Date = string.Empty;
        string Quarter_Month = string.Empty;
        string Quarter_Year = string.Empty;

        //Get the Current Date,Month,Year
        DateTime dtCurrent = DateTime.Now;

        //Current Date
        string CurrentDT = dtCurrent.Date.Day.ToString();
        if (Convert.ToInt32(CurrentDT) < 10)
        {
            CurrentDT = "0" + CurrentDT;
        }
        CurrentDT = (Convert.ToInt32(CurrentDT)).ToString();

        //Current Month
        string mont = dtCurrent.Month.ToString();
        if (Convert.ToInt32(mont.ToString()) < 9)
        {
            mont = "0" + mont;
        }
        string CurrentMonth = Get_Month(mont);

        //Current Month
        string CurrentYear = dtCurrent.Year.ToString();

        //FROM Date and Year
        Quarter_Date = (Convert.ToInt32(CurrentDT) + 1).ToString();
        Quarter_Year = (Convert.ToInt32(CurrentYear) - 2).ToString();
        Quarter_Month = CurrentMonth;

        String[] SendDataArray = new string[] { TAN, FY, Quarter_Date, Quarter_Month, Quarter_Year, CurrentDT, CurrentMonth, CurrentYear };

        String Result = null;
        CSIDownloader objCSIDownloader = new CSIDownloader();
        try
        {
            Result = objCSIDownloader.Start_TRACES_Site();
            if (Result == "Server is Not Started")
            {
                Result = "Server is Not Started";
            }
            else
            {
                Result = objCSIDownloader.Get_CSI_File(SendDataArray);
            }
        }
        catch
        {
            Result = "Some Exception Occurred.";
        }

        //Show The Information
        //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + Result + "');", true);
        Exec_FVU();
        if (Session["UserRole"] != null)
        {
            if (Session["UserRole"].ToString() == "Supervisor")
            {
                common objcommon = new common();
                objcommon.startProcessHistoryJob(Convert.ToInt64(Session["Job_ID"]), Convert.ToInt64(Session["user_ID"]), "Completed", "Y");
            }
        }
    }

    protected void btnFVU_Click(object sender, EventArgs e)
    {
        Exec_FVU();
    }

    public void Exec_FVU()
    {
        String Result = null;
        //Creating Object of The Class
        FVUValidator objFVUvalidator = new FVUValidator();
        try
        {
            Result = "All Required Files are Found";// objFVUvalidator.CheckFile();
            if (Result == "All Required Files are Found")
            {
                Result = objFVUvalidator.ValidateFile();

            }
            //Flag_FVU = Result;
        }
        catch
        {
            Result = "Exception Occurred";

            //Set The FVU Flag also
            //Flag_FVU = Result;
        }

        String[] PagePath = null;
        //File Validated Successfully
        PagePath = new String[] { "hello" };
        //return PagePath;
    }

    public string Get_Month(string monthnumber)
    {
        string Month = string.Empty;
        if (monthnumber == "01")
        {
            Month = "JAN";
        }
        else if (monthnumber == "02")
        {
            Month = "FEB";
        }
        else if (monthnumber == "03")
        {
            Month = "MAR";
        }
        else if (monthnumber == "04")
        {
            Month = "APR";
        }
        else if (monthnumber == "05")
        {
            Month = "MAY";
        }
        else if (monthnumber == "06")
        {
            Month = "JUN";
        }
        else if (monthnumber == "07")
        {
            Month = "JUL";
        }
        else if (monthnumber == "08")
        {
            Month = "AUG";
        }
        else if (monthnumber == "09")
        {
            Month = "SEP";
        }
        else if (monthnumber == "10")
        {
            Month = "OCT";
        }
        else if (monthnumber == "11")
        {
            Month = "NOV";
        }
        else if (monthnumber == "12")
        {
            Month = "DEC";
        }
        return Month;

    }
}