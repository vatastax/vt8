using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taxation.BusinessLogic;
//using iTextSharp.text;
using Taxation.DataEntity;
using System.Data;
using System.Web.Services;
using System.Data.OleDb;

public partial class UserControls_ImportBalanceSheet : System.Web.UI.UserControl
{
    static string[] arrConstIDs = null;//{ "1522731_60258", "1522731_60261", "1522731_60265", "1522731_60270", "1522774_60375", "1522774_60378", "1522735_60272", "1522735_60275", "1522739_60277", "1522739_60280", "1522742_60287", "1522742_60290", "1522743_60292", "1522743_60295", "1522743_60299", "1522767_60356", "1522767_60359", "1522767_60363", "1522767_60368", "1522768_60370", "1522768_60373", "1522749_60301", "1522749_60304", "1522749_60308", "1522751_60310", "1522751_60313", "1522751_60317", "1522751_60322", "1522760_60324", "1522760_60327", "1522760_60331", "1522760_60336", "1522762_60347", "1522762_60350", "1522762_60354", "1522730_0", "1522733_0", "1522737_0", "1522740_0", "1522746_0", "1522747_0" };
    static string[] arrData = null;//{ "3_F8", "4_F8", "5_F8", "6_F8", "13_F8", "14_F8", "18_F8", "19_F8", "25_F8", "26_F8", "32_F8", "33_F8", "36_F8", "37_F8", "38_F8", "44_F8", "45_F8", "46_F8", "47_F8", "51_F8", "52_F8", "57_F8", "58_F8", "59_F8", "64_F8", "65_F8", "66_F8", "67_F8", "70_F8", "71_F8", "72_F8", "73_F8", "77_F8", "78_F8", "79_F8", "1_F10", "11_F8", "22_F10", "28_F8", "49_F10", "54_F10" };
    static int cnt = 0;
    static DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        //to prevent auto logout:
        Session["Def"] = "set";
        Session["DisplayForm"] = "set";
        Session["xmlRestore"] = "set";
        Session["inc"] = "set";

        if (!IsPostBack)
        {
            cnt = 0;
        }
    }
    protected void btnC_Click(object sender, EventArgs e)
    {
        string strConstIDs = @"1522731_60258,1522731_60261,1522731_60265,1522731_60270,1522774_60375,1522774_60378,1522735_60272,1522735_60275,1522739_60277,1522739_60280,1522742_60287,1522742_60290,1522743_60292,1522743_60295,1522743_60299,1522767_60356,1522767_60359,1522767_60363,1522767_60368,1522768_60370,1522768_60373,1522749_60301,1522749_60304,1522749_60308,1522751_60310,1522751_60313,1522751_60317,1522751_60322,1522760_60324,1522760_60327,1522760_60331,1522760_60336,1522762_60347,1522762_60350,1522762_60354,1522730_0,1522733_0,1522737_0,1522740_0,1522746_0,1522747_0";
        string strRows = @"3_F8,4_F8,5_F8,6_F8,13_F8,14_F8,18_F8,19_F8,25_F8,26_F8,32_F8,33_F8,36_F8,37_F8,38_F8,44_F8,45_F8,46_F8,47_F8,51_F8,52_F8,57_F8,58_F8,59_F8,64_F8,65_F8,66_F8,67_F8,70_F8,71_F8,72_F8,73_F8,77_F8,78_F8,79_F8,1_F10,11_F8,22_F10,28_F8,49_F10,54_F10";
        string SheetName = "BS";
        fetchData(strConstIDs, strRows, SheetName);

        strConstIDs = @"1522781_0,1522782_0,1522786_60389,1522786_60392,1522786_60396,1522786_60401,1522793_0,1522794_0,1522795_0,1522796_0,1522797_0,1522798_0,1522799_0,1522800_0,1522801_0,1523443_62979,1523443_62982,1523443_62986,1522822_60403,1522822_60406,1522822_60410,1522823_0,1522824_60412,1522824_60415,1522824_60419,1522824_60424,1522824_60430,1522824_60437,1522824_60445,1522825_0,1522826_0,1522827_0,1522828_0,1522829_0,1522830_0,1522831_60447,1522831_60450,1522831_60454,1522831_60459,1522831_60465,1522831_60472,1522831_60480,1522831_60489,1522831_60499,1522831_60510,1522832_0,1522833_0,1522841_60512,1522841_60515,1522841_60519,1522841_60524,1522842_0,1522843_0,1522844_0,1522845_0,1522846_0,1522847_0,1522848_60526,1522848_60529,1522849_60531,1522849_60534,1522850_60536,1522850_60539,1522851_0,1522852_0,1522853_0,1522854_0,1522855_0,1522856_0,1522857_0,1522858_0,1522859_0,1522860_0,1522861_0,1522862_60541,1522862_60544,1522862_60548,1522862_60553,1522862_60559,1522863_0,1522866_0,1522867_0,1522869_0,1522870_0,1522872_60561,1522872_60564,1522873_0,1522876_0,1522877_0,1522879_0,1522881_0";
        strRows = @"2_F8,3_F8,15_F8,16_F8,17_F8,18_F8,20_F8,21_F8,22_F8,23_F8,24_F8,25_F8,26_F8,27_F8,28_F8,38_F8,39_F8,40_F8,44_F8,45_F8,46_F8,48_F10,50_F8,51_F8,52_F8,53_F8,54_F8,55_F8,56_F8,58_F10,59_F10,60_F10,61_F10,62_F10,63_F10,65_F8,66_F8,67_F8,68_F8,69_F8,70_F8,71_F8,72_F8,73_F8,74_F8,76_F8,77_F8,79_F8,80_F8,81_F8,82_F8,84_F10,85_F10,86_F10,87_F10,88_F10,89_F10,91_F8,92_F8,95_F8,96_F8,99_F8,100_F8,102_F10,103_F10,104_F10,105_F10,106_F10,107_F10,108_F10,109_F10,110_F10,111_F10,112_F10,114_F8,115_F8,116_F8,117_F8,118_F8,120_F10,137_F8,138_F8,140_F10,141_F10,144_F8,145_F8,147_F10,149_F10,150_F10,152_F10,154_F10";
        SheetName = "PL";
        fetchData(strConstIDs, strRows, SheetName);
    }

    private void fetchData(string strConstIDs, string strRows, string SheetName)
    {
        arrConstIDs = System.Text.RegularExpressions.Regex.Split(strConstIDs, ",");
        arrData = System.Text.RegularExpressions.Regex.Split(strRows, ",");

        string filePath = "";
        if (fupl.FileName != "")
        {
            filePath = Server.MapPath("Upload/") + fupl.FileName;
            fupl.PostedFile.SaveAs(filePath);
            try
            {
                string connStr = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;";
                OleDbConnection MyConnection;
                OleDbDataAdapter MyCommand;
                MyConnection = new OleDbConnection(connStr);
                MyCommand = new OleDbDataAdapter("select * from [" + SheetName + "$]", MyConnection);
                ds = new System.Data.DataSet();
                MyCommand.Fill(ds);
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        for (int i = 0; i < arrConstIDs.Length; i++)
            addData();
    }

    public void addData()
    {
        string Col3 = "";
        string[] arrRows = System.Text.RegularExpressions.Regex.Split(arrData[cnt], "_");
        int row = Convert.ToInt32(arrRows[0]);
        string col = arrRows[1].ToString();
        Col3 = ds.Tables[0].Rows[row][col].ToString();

        int ConstID = 0;
        int subConstID = 0;

        string[] arrConstSub = System.Text.RegularExpressions.Regex.Split(arrConstIDs[cnt], "_");
        ConstID = Convert.ToInt32(arrConstSub[0]);
        subConstID = Convert.ToInt32(arrConstSub[1]);
        //int ConstID = arrConstIDs[cnt];

        bllMain objbllMain = new bllMain();
        DataTable dtT00 = new DataTable();
        dtT00 = objbllMain.getT00_Details(ConstID, Session["AY"].ToString(), Session["ITR"].ToString());

        denStoreTrans objdenStoreTrans2 = new denStoreTrans();
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        Label lblSerial = new Label();

        objdenStoreTrans2.NameID = Convert.ToString(Session["NameID"]);
        objdenStoreTrans2.Vtype = 62;
        objdenStoreTrans2.MainID = Convert.ToInt32(Session["NameID"]);
        objdenStoreTrans2.ConstID = ConstID;
        objdenStoreTrans2.SubConstID = subConstID;
        objdenStoreTrans2.GIndex = Convert.ToInt32(dtT00.Rows[0]["C6"]);
        objdenStoreTrans2.Col3 = Col3;
        objdenStoreTrans2.AY = Convert.ToString(Session["AY"]);
        objdenStoreTrans2.GRowNo = Convert.ToInt32(dtT00.Rows[0]["C7"]);
        objdenStoreTrans2.AssesseeType = Convert.ToInt32(Session["Status"]);
        objdenStoreTrans2.ComboItemNo = Convert.ToInt32(dtT00.Rows[0]["C5"]);
        objdenStoreTrans2.IsEnterFDet = 0;

        // To set RecdAmount
        common objCommon = new common();
        // this function is to get the RecdAmount value for the current ConstantID that will be further used during calculations
        objdenStoreTrans2.RecdAmount = 0;// objCommon.getRecdAmount(ViewState["vtype"].ToString(), (ddlSelect.SelectedItem != null) ? ddlSelect.SelectedItem.Text : "", indx, ViewState["GRowNo"].ToString(), ViewState["intC1"].ToString());

        objdenStoreTrans2.DueDate = (Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (Session["duedate"].ToString());
        int i = objbllStoreTrans.CheckMainGrid(objdenStoreTrans2);
        string msg_IIF = "";
        if (i <= 0)
        {
            objbllStoreTrans.InsertDataMainGrid(objdenStoreTrans2, out msg_IIF);
        }
        else
        {
            string msg = "";
            objbllStoreTrans.UpdateMainGridBalanceSheet(objdenStoreTrans2, out msg);
        }
        cnt += 1;
    }
    [WebMethod]
    public static void AbandonSession()
    {
        HttpContext.Current.Session.Abandon();
    }
}