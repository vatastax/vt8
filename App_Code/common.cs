using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using Taxation.BusinessLogic;
using BALVatasETDS;
using BALVatasETDS.UserGroupManagement;
using DALVatasETDS;
using BALVatasETDS.User;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;

using BALVatasETDS.AccountGroups;
using BALVatasETDS.System_Config;
using BALVatasETDS.Vouchers;
using BALVatasETDS.UserGroupManagement;
using BALVatasETDS.RoleManagement;

using BALVatasETDS.Accounts;
using BALVatasETDS.Interface_By_Role;
using BALVatasETDS.JobWork1;
using BALVatasETDS.FileHeader;
using BALVatasETDS.ProcessHistoryofJob;
using Taxation.DataEntity;
using System.IO;
using BALVatasETDS.User_Admin;

using Ionic.Zip;
using System.Net;
using ClosedXML.Excel;

/// <summary>
/// Summary description for common
/// </summary>
public class common : dalConnection
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con_Poolable"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter adp;
    public common()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //For User Session Management:

    public static bool IsLoggedIn(out int reason)
    {
        reason = 0;
        if (HttpContext.Current.Session["user_name"] == null || HttpContext.Current.Session["Email_Id"] == null || HttpContext.Current.Session["User_ID"] == null || HttpContext.Current.Session["project"] == null || HttpContext.Current.Session["user_name"] == null || HttpContext.Current.Session["userEmail"] == null)
        {
            //balAdmin objbalAdmin = new balAdmin();
            //objbalAdmin.logoutUser();
            System.Web.UI.Page pp = new System.Web.UI.Page();
            //pp=(System.Web.UI.Page)
            //pp.Response.Redirect("~/Presentation/Logout.aspx");
            //HttpContext.Current.Session.Abandon();
            return false;
        }
        else
        {

            string strConnName_Admin, strConnectionString_Admin;

            //Connection  String For the Admin Process

            strConnName_Admin = HttpContext.Current.Application["DBEngine"].ToString();
            strConnectionString_Admin = ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString;

            string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
            DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

            strConnName_Admin = HttpContext.Current.Application["DBEngine"].ToString();
            strConnectionString_Admin = ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString;

            Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
            DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

            tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
            Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
            //objBltbl_UserGroupRegistration.Get_User_Data(objtbl_UserGroupRegistration);

            //to get user data:

            balAdmin objbalAdmin = new balAdmin();
            //tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
            //objtbl_UserGroupRegistration = objbalAdmin.SelectData(Convert.ToInt32(HttpContext.Current.Session["User_ID"]));



            //objtbl_UserGroupRegistration.EmailID = email;
            //objtbl_UserGroupRegistration.Password = password;
            //objtbl_UserGroupRegistration.Active_Login = "Y";
            //objBltbl_UserGroupRegistration.Set_Active_Login(objtbl_UserGroupRegistration);
            ////Now Check Wheter the Account is Locked or Not or whether it is deleted or Not
            Bltbl_User objBltbl_User = new Bltbl_User(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
            tbl_User objtbl_User = new tbl_User();
            DataTable dt = new DataTable();
            objtbl_UserGroupRegistration.Super_User_Id = Convert.ToInt32(HttpContext.Current.Session["User_ID"]);
            dt = objBltbl_UserGroupRegistration.GetSuper_UserByID(objtbl_UserGroupRegistration);

            objtbl_User.User_Name = dt.Rows[0]["EmailID"].ToString();
            objtbl_User.Password = dt.Rows[0]["Password"].ToString();

            bool Is_Locked = objBltbl_User.Check_Account_IsLocked(objtbl_User); //check if user is Locked
            if (Is_Locked)
            {
                reason = 1;
                return false;
            }
            else
                return true;
        }
    }

    static string Parse(string text)
    {
        string[] Formats = null;
        string[] arrDt = null;
        if (text.Contains("/"))
        {
            arrDt = System.Text.RegularExpressions.Regex.Split(text, "/");

        }
        else if (text.Contains("-"))
        {
            arrDt = System.Text.RegularExpressions.Regex.Split(text, "-");
        }

        for (int i = 0; i < arrDt.Length; i++)
        {
            if (arrDt[i].Length > 2)
            {

            }
            else
            {
                if (arrDt[i].Length < 2)
                {
                    arrDt[i] = "0" + arrDt[i];
                }
            }
        }
        text = arrDt[0] + "/" + arrDt[1] + "/" + arrDt[2];

        string strDate = "";
        // Adjust styles as per requirements
        DateTime result = DateTime.ParseExact(text, Formats,
                                              CultureInfo.InvariantCulture,
                                              DateTimeStyles.AssumeUniversal);
        strDate = result.ToShortDateString();
        return strDate;
    }

    public Int32 getRecdAmount(string VType, string SelectedItem, Int32 indx, string gRowNo, string ConstID)
    {
        int RecdAmount = 0;

        if (VType == "40" && SelectedItem == "Basic Details" && gRowNo == "0")
            RecdAmount = 0;
        else if (VType == "40" && SelectedItem == "Allowances" && indx == 0)
            RecdAmount = 7;
        else if (VType == "40" && SelectedItem == "Allowances" && indx == 1)
            RecdAmount = 8;
        else if (VType == "40" && SelectedItem == "Allowances" && indx == 2)
            RecdAmount = 7;
        else if (VType == "40" && SelectedItem == "Allowances" && indx == 3)
            RecdAmount = 7;
        else if (VType == "40" && SelectedItem == "Allowances" && indx == 4)
            RecdAmount = 7;
        else if (VType == "40" && SelectedItem == "Allowances" && indx == 5)
            RecdAmount = 7;
        else if (VType == "40" && SelectedItem == "Allowances" && indx == 6)
            RecdAmount = 1;
        else if (VType == "40" && SelectedItem == "Allowances" && indx == 7)
            RecdAmount = 2;
        else if (VType == "40" && SelectedItem == "Perquisites" && indx == 0)
            RecdAmount = 20;
        else if (VType == "40" && SelectedItem == "Perquisites" && indx > 0)
            RecdAmount = 4;
        else if (VType == "40" && SelectedItem == "Profit in Lieu of Salary")    //any index as there is only one record there (ankush)
            RecdAmount = 4;
        else if (VType == "40" && SelectedItem == "Retirement Benefits")
            RecdAmount = 3;
        else if (VType == "40" && SelectedItem == "Professionl Tax")
            RecdAmount = 9;
        else if (VType == "40" && SelectedItem == "Relief U/S 89")    //any index as there is only one record there (ankush)
            RecdAmount = 10;
        else if (VType == "42")
            RecdAmount = 5;
        else if (VType == "41" && SelectedItem == "Business & Profession")// && indx == 0)
            RecdAmount = 5;
        else if (VType == "41" && SelectedItem == "Business & Profession")// && (indx > 0 && indx < 4))
            RecdAmount = 11;
        else if (VType == "41" && SelectedItem == "Business & Profession")// && indx == 9)
            RecdAmount = 11;
        else if (VType == "41" && SelectedItem == "Business & Profession")// && (indx > 15 && indx < 19))
            RecdAmount = 12;
        else if (VType == "41" && SelectedItem == "Estimated Income u/s 44")// && (indx >= 0 && indx < 3))
            RecdAmount = 6;
        else if (VType == "41" && SelectedItem == "Estimated Income u/s 44")// && indx == 9)
            RecdAmount = 6;
        else if (VType == "41" && SelectedItem == "Income of Partner")// && indx == 3)
            RecdAmount = 12;
        else if (VType == "41" && SelectedItem == "Income of Partner")// && indx != 3)
            RecdAmount = 6;
        else if (VType == "41" && SelectedItem == "Income of Insurance Agent")// && indx == 3)
            RecdAmount = 12;
        else if (VType == "41" && SelectedItem == "Income of Insurance Agent")// && indx != 3)
            RecdAmount = 6;
        else if (VType == "41" && SelectedItem == "Speculation Business")// && indx == 0)
            RecdAmount = 5;
        else if (VType == "41" && SelectedItem == "Speculation Business")// && indx == 1)
            RecdAmount = 11;
        else if (VType == "41" && SelectedItem == "Speculation Business")// && indx == 2)
            RecdAmount = 0;
        else if (VType == "41") //added by ankush for 41 as there are various new options there those are not yet managed for the RecdAmount
            RecdAmount = 6;
        else if (VType == "44" && indx == 5)
            RecdAmount = 0;
        else if (VType == "44" && indx != 5)
            RecdAmount = 13;
        else if (VType == "43")
            RecdAmount = 0;
        else if (VType == "73")
            RecdAmount = 16;
        //else if (VType == "46" && ConstID == "569")
        //    RecdAmount = 15;
        else if (VType == "46")
            RecdAmount = 0;
        else if (VType == "48" && indx == 0)
            RecdAmount = 0;
        else if (VType == "48" && (indx > 0 && indx < 5))
            RecdAmount = 17;
        else if (VType == "48" && (indx > 4 && indx < 17))
            RecdAmount = 0;
        else if (VType == "48" && indx > 16)
            RecdAmount = 17;
        else if (VType == "51" && SelectedItem == "Income of Minor Child" && indx == 0)
            RecdAmount = 0;
        else if (VType == "51" && SelectedItem == "Income of Minor Child" && indx > 0)
            RecdAmount = 21;
        else if (VType == "51")
            RecdAmount = 18;
        else if (VType == "104" && (indx < 4))
            RecdAmount = 19;
        else if (VType == "104" && (indx > 4))
            RecdAmount = 0;
        else if (VType == "67")
            RecdAmount = 0;
        else if (VType == "84")
            RecdAmount = 0;
        //else if (VType == "13011")                  //for Master Page Employer
        //    RecdAmount = Convert.ToInt32(gRowNo);



        return RecdAmount;
    }

    public DataTable Select(string VType, ArrayList info, out string addLnk, out string updLnk)
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        try
        {
            this.pConnMain();
            string strSQL = "";// "select * from popup_screen where VType=@VType";
            if (VType == "")
                VType = "0";
            strSQL = @"select * from popup_screen where id = (select popupID from dbMain.dbo.screensettings where VType=@VType)";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@VType", VType);
            adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            addLnk = "";
            updLnk = "";
            if (dt.Rows.Count > 0)
            {
                addLnk = dt.Rows[0]["AddBtnURL"].ToString();
                updLnk = dt.Rows[0]["ManageBtnURL"].ToString();
                strSQL = dt.Rows[0]["SQLQry"].ToString();
                string[] arr = System.Text.RegularExpressions.Regex.Split(strSQL, "#");

                if (arr.Length > 2 && info.Count > 1)
                    strSQL = arr[0] + info[0].ToString() + arr[1] + info[1].ToString();
                else if (arr.Length > 1)
                    strSQL = arr[0] + info[0].ToString() + arr[1];

                // +arr[1] + VType;

                adp = new SqlDataAdapter(strSQL, con);

                adp.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    DataColumn col1 = new DataColumn("screenTitle", Type.GetType("System.String"));
                    DataColumn col2 = new DataColumn("IsAddButton", Type.GetType("System.String"));
                    DataColumn col3 = new DataColumn("IsManageButton", Type.GetType("System.String"));
                    DataColumn col4 = new DataColumn("AddBtnURL", Type.GetType("System.String"));
                    DataColumn col5 = new DataColumn("ManageBtnURL", Type.GetType("System.String"));
                    dt2.Columns.Add(col1);
                    dt2.Columns.Add(col2);
                    dt2.Columns.Add(col3);
                    dt2.Columns.Add(col4);
                    dt2.Columns.Add(col5);


                    dt2.Rows[0][3] = dt.Rows[0][3];
                    dt2.Rows[0][4] = dt.Rows[0][4];
                    dt2.Rows[0][5] = dt.Rows[0][5];
                    dt2.Rows[0][6] = dt.Rows[0][6];
                    dt2.Rows[0][7] = dt.Rows[0][7];
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
        return dt2;

    }

    public void resetStatus(Int64 ID)
    {
        try
        {
            this.pConnTDS();
            string strSQL = "update Tbl_Upload_Returns set Remarks = 'Pending' where ID=@ID";

            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@ID",ID);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //public void SaveAccount(string NameID_Assessee, string username)
    //{
    //    string NameID = HttpContext.Current.Session["NameID"].ToString();
    //    //To check whether the Assessee already connected with any AccountID (AccID)
    //    bllAssessee objbllAssessee = new bllAssessee();
    //    int AccID_From_NameID = objbllAssessee.IsAccIDExists(NameID_Assessee);
    //    if (AccID_From_NameID == 0)
    //    {

    //        //Intialize ConnectionString
    //        string strConnName = ConfigurationManager.AppSettings["DatabaseEngine4"].ToString();
    //        string strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;

    //        //ConnectionString Of Admin
    //        string strConnName_Admin = ConfigurationManager.AppSettings["DatabaseEngine5"].ToString();
    //        string strConnectionString_Admin = ConfigurationManager.ConnectionStrings[strConnName_Admin].ConnectionString;

    //        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
    //        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
    //        DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;


    //        DataTable dt_Voucher_Details_Accounts = new DataTable();
    //        DataTable dt_Voucher = new DataTable();
    //        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
    //        //Create Parameters For Checking the Existence of the Customer
    //        string AccName = objbllStoreTrans.SelectData_ConstID(NameID, "2") + " " + objbllStoreTrans.SelectData_ConstID(NameID, "4");


    //        tbl_Accounts1 objtbl_Accounts1 = new tbl_Accounts1();
    //        BLtbl_Accounts11 objBLtbl_Accounts11 = new BLtbl_Accounts11(strConnectionString, strConnName, strConnectionString_Admin);
    //        tbl_System_Config objtbl_System_Config = new tbl_System_Config();
    //        Bltbl_System_Config objBltbl_System_Config = new Bltbl_System_Config(strConnectionString, strConnName, strConnectionString_Admin);

    //        objtbl_Accounts1.AccName = AccName;
    //        objtbl_Accounts1.Name_of_Firm = "VatasInfotech-Online";
    //        bool Is_Exist = false;
    //        try
    //        {
    //            Is_Exist = objBLtbl_Accounts11.Check_Existence_Account(objtbl_Accounts1);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        if (!Is_Exist)
    //        {

    //            objtbl_Accounts1.AccName = AccName;
    //            objtbl_Accounts1.Opening_Bal = Convert.ToDouble(0.0);
    //            objtbl_Accounts1.A_Address1 = objbllStoreTrans.SelectData_ConstID(NameID, "9") + " " + objbllStoreTrans.SelectData_ConstID(NameID, "10") + " " + objbllStoreTrans.SelectData_ConstID(NameID, "11") + " " + objbllStoreTrans.SelectData_ConstID(NameID, "12") + ", " + objbllStoreTrans.SelectData_ConstID(NameID, "13");
    //            objtbl_Accounts1.A_Address2 = "";
    //            objtbl_Accounts1.A_Address3 = "";
    //            objtbl_Accounts1.A_Address4 = "";
    //            objtbl_Accounts1.A_Address5 = "";
    //            objtbl_Accounts1.A_Country_ID = 76; //CountryID = 76 for India
    //            objtbl_Accounts1.A_State_ID = Convert.ToInt32(objbllStoreTrans.SelectData_ConstID(NameID, "14"));
    //            objtbl_Accounts1.A_City_ID = 0;


    //            objtbl_Accounts1.A_Telephone1 = objbllStoreTrans.SelectData_ConstID(NameID, "17") + " " + objbllStoreTrans.SelectData_ConstID(NameID, "18");
    //            objtbl_Accounts1.A_Telephone2 = "";
    //            objtbl_Accounts1.A_Telephone3 = "";

    //            objtbl_Accounts1.A_Mobile1 = objbllStoreTrans.SelectData_ConstID(NameID, "19");
    //            objtbl_Accounts1.A_Mobile2 = "";

    //            objtbl_Accounts1.A_Email_ID1 = objbllStoreTrans.SelectData_ConstID(NameID, "21");
    //            objtbl_Accounts1.A_Email_ID2 = "";

    //            objtbl_Accounts1.P_Address1 = objtbl_Accounts1.A_Address1;
    //            objtbl_Accounts1.P_Address2 = "";
    //            objtbl_Accounts1.P_Address3 = "";
    //            objtbl_Accounts1.P_Address4 = "";
    //            objtbl_Accounts1.P_Address5 = "";
    //            objtbl_Accounts1.P_CountryID = objtbl_Accounts1.A_Country_ID;
    //            objtbl_Accounts1.P_StateID = objtbl_Accounts1.A_State_ID;
    //            objtbl_Accounts1.P_CityID = 0;


    //            objtbl_Accounts1.P_Telephone1 = objtbl_Accounts1.A_Telephone1;
    //            objtbl_Accounts1.P_Telephone2 = "";
    //            objtbl_Accounts1.P_Telephone3 = "";

    //            objtbl_Accounts1.P_Mobile1 = objtbl_Accounts1.A_Mobile1;
    //            objtbl_Accounts1.P_Mobile2 = "";

    //            objtbl_Accounts1.P_Email_ID1 = objtbl_Accounts1.A_Email_ID1;
    //            objtbl_Accounts1.P_Email_ID2 = "";

    //            objtbl_Accounts1.Father_Name = "";
    //            objtbl_Accounts1.FY = HttpContext.Current.Session["AY"].ToString();
    //            objtbl_Accounts1.Flag = "17";
    //            objtbl_Accounts1.TAN = "";
    //            objtbl_Accounts1.PAN = objbllStoreTrans.SelectData_ConstID(NameID, "5");
    //            objtbl_Accounts1.Contact_Person = AccName;
    //            objtbl_Accounts1.Reffered_By_ID = 0;
    //            objtbl_Accounts1.Name_of_Firm = "VatasInfotech-Online";
    //            objtbl_Accounts1.Category = "";
    //            objtbl_Accounts1.NonEditable = "N";
    //            objtbl_Accounts1.Page_ID = "1";
    //            objtbl_Accounts1.Page_SubModule_ID = "14";

    //            //Call the Query and Insert Data
    //            int success = objBLtbl_Accounts11.Insert_Record_Accounts(objtbl_Accounts1);
    //            if (success == 1)
    //            {
    //                objtbl_Accounts1.AccName = "-999999999";
    //                //objBLtbl_Accounts11.Insert_Record_Accounts(objtbl_Accounts1);

    //                //Create string Array Of Voucher Detail
    //                string[] arr_Voucher_field = new string[] { DateTime.Now.ToShortDateString(), "0", "" };
    //                objtbl_System_Config.Table_Name = "tbl_Vouchers";
    //                dt_Voucher = objBltbl_System_Config.Get_Column_Name_With_DataType(objtbl_System_Config);
    //                dt_Voucher.Columns.Remove(dt_Voucher.Columns[0]);
    //                dt_Voucher.TableName = "tbl_Vouchers";

    //                //Add New Datarow 
    //                DataRow dr_Voucher = dt_Voucher.NewRow();
    //                //Voucher Date Field
    //                dr_Voucher["Voucher_Date"] = arr_Voucher_field[0].ToString();
    //                //Voucher BillNo Field
    //                dr_Voucher["Bill_No"] = Convert.ToInt32(arr_Voucher_field[1]);
    //                //Voucher Receipt Field 
    //                dr_Voucher["Receipt_ID"] = 0;
    //                //Voucher Name_Of_Firm
    //                dr_Voucher["Name_Of_Firm"] = arr_Voucher_field[2].ToString();

    //                //Add the Row to the Voucher Table
    //                dt_Voucher.Rows.Add(dr_Voucher);
    //                dt_Voucher.AcceptChanges();


    //                //Create Voucher Details Table
    //                //objtbl_Accounts1.AccName = AccName;
    //                //int Acc_ID = objBLtbl_Accounts11.GetAccID(objtbl_Accounts1);
    //                //string[] arr_Voucher_Detail_Fields = new string[8];
    //                //objtbl_System_Config.Table_Name = "tbl_Voucher_Details";
    //                //dt_Voucher_Details_Accounts = objBltbl_System_Config.Get_Column_Name_With_DataType(objtbl_System_Config);
    //                //dt_Voucher_Details_Accounts.Columns.Remove(dt_Voucher_Details_Accounts.Columns[0]);
    //                //dt_Voucher_Details_Accounts.Columns.Remove(dt_Voucher_Details_Accounts.Columns[0]);
    //                //dt_Voucher_Details_Accounts.TableName = "tbl_Voucher_Details";


    //                objbllAssessee.UpdateAccID(NameID_Assessee, objtbl_Accounts1.PAN);
    //            }
    //        }
    //    }
    //}

    public void SaveAccount(Int64 Super_User_Id)
    {
        //To check whether the Assessee already connected with any AccountID (AccID)
        balAdmin objbalAdmin = new balAdmin();
        int AccID_From_Super_User_Id = objbalAdmin.IsAccIDExists(Super_User_Id);
        tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
        objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(Super_User_Id));

        if (AccID_From_Super_User_Id == 0)
        {

            //Intialize ConnectionString
            string strConnName = ConfigurationManager.AppSettings["DatabaseEngine4"].ToString();
            string strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;

            //ConnectionString Of Admin
            string strConnName_Admin = ConfigurationManager.AppSettings["DatabaseEngine5"].ToString();
            string strConnectionString_Admin = ConfigurationManager.ConnectionStrings[strConnName_Admin].ConnectionString;

            string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
            DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

            DataTable dt_Voucher_Details_Accounts = new DataTable();
            DataTable dt_Voucher = new DataTable();
            bllStoreTrans objbllStoreTrans = new bllStoreTrans();
            //Create Parameters For Checking the Existence of the Customer
            string AccName = objtbl_UserRegistration.Name + " " + objtbl_UserRegistration.Last_Name;

            tbl_Accounts1 objtbl_Accounts1 = new tbl_Accounts1();
            BLtbl_Accounts11 objBLtbl_Accounts11 = new BLtbl_Accounts11(strConnectionString, strConnName, strConnectionString_Admin);
            tbl_System_Config objtbl_System_Config = new tbl_System_Config();
            Bltbl_System_Config objBltbl_System_Config = new Bltbl_System_Config(strConnectionString, strConnName, strConnectionString_Admin);

            objtbl_Accounts1.AccName = AccName;
            objtbl_Accounts1.Name_of_Firm = "VatasInfotech-Online";
            bool Is_Exist = false;
            try
            {
                Is_Exist = objBLtbl_Accounts11.Check_Existence_Account(objtbl_Accounts1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (!Is_Exist)
            {

                objtbl_Accounts1.AccName = AccName;
                objtbl_Accounts1.Opening_Bal = Convert.ToDouble(0.0);
                objtbl_Accounts1.A_Address1 = objtbl_UserRegistration.Address1;
                objtbl_Accounts1.A_Address2 = "";
                objtbl_Accounts1.A_Address3 = "";
                objtbl_Accounts1.A_Address4 = "";
                objtbl_Accounts1.A_Address5 = "";
                objtbl_Accounts1.A_Country_ID = 76; //CountryID = 76 for India
                objtbl_Accounts1.A_State_ID = objtbl_UserRegistration.State;
                objtbl_Accounts1.A_City_ID = 0;


                objtbl_Accounts1.A_Telephone1 = objtbl_UserRegistration.Telephone;
                objtbl_Accounts1.A_Telephone2 = "";
                objtbl_Accounts1.A_Telephone3 = "";

                objtbl_Accounts1.A_Mobile1 = objtbl_UserRegistration.MobileNumber;
                objtbl_Accounts1.A_Mobile2 = "";

                objtbl_Accounts1.A_Email_ID1 = objtbl_UserRegistration.EmailID;
                objtbl_Accounts1.A_Email_ID2 = "";

                objtbl_Accounts1.P_Address1 = objtbl_Accounts1.A_Address1;
                objtbl_Accounts1.P_Address2 = "";
                objtbl_Accounts1.P_Address3 = "";
                objtbl_Accounts1.P_Address4 = "";
                objtbl_Accounts1.P_Address5 = "";
                objtbl_Accounts1.P_CountryID = objtbl_Accounts1.A_Country_ID;
                objtbl_Accounts1.P_StateID = objtbl_Accounts1.A_State_ID;
                objtbl_Accounts1.P_CityID = 0;


                objtbl_Accounts1.P_Telephone1 = objtbl_Accounts1.A_Telephone1;
                objtbl_Accounts1.P_Telephone2 = "";
                objtbl_Accounts1.P_Telephone3 = "";

                objtbl_Accounts1.P_Mobile1 = objtbl_Accounts1.A_Mobile1;
                objtbl_Accounts1.P_Mobile2 = "";

                objtbl_Accounts1.P_Email_ID1 = objtbl_Accounts1.A_Email_ID1;
                objtbl_Accounts1.P_Email_ID2 = "";

                objtbl_Accounts1.Father_Name = "";
                objtbl_Accounts1.FY = "2016-2017";
                objtbl_Accounts1.Flag = "17";
                objtbl_Accounts1.TAN = "";
                objtbl_Accounts1.PAN = "";
                objtbl_Accounts1.Contact_Person = AccName;
                objtbl_Accounts1.Reffered_By_ID = 0;
                objtbl_Accounts1.Name_of_Firm = "VatasInfotech-Online";
                objtbl_Accounts1.Category = "";
                objtbl_Accounts1.NonEditable = "N";
                objtbl_Accounts1.Page_ID = "1";
                objtbl_Accounts1.Page_SubModule_ID = "14";

                //Call the Query and Insert Data
                int success = objBLtbl_Accounts11.Insert_Record_Accounts(objtbl_Accounts1);
                if (success == 1)
                {
                    objtbl_Accounts1.AccName = "-999999999";
                    //objBLtbl_Accounts11.Insert_Record_Accounts(objtbl_Accounts1);

                    //Create string Array Of Voucher Detail
                    string[] arr_Voucher_field = new string[] { DateTime.Now.ToShortDateString(), "0", "" };
                    objtbl_System_Config.Table_Name = "tbl_Vouchers";
                    dt_Voucher = objBltbl_System_Config.Get_Column_Name_With_DataType(objtbl_System_Config);
                    dt_Voucher.Columns.Remove(dt_Voucher.Columns[0]);
                    dt_Voucher.TableName = "tbl_Vouchers";

                    //Add New Datarow 
                    DataRow dr_Voucher = dt_Voucher.NewRow();
                    //Voucher Date Field
                    dr_Voucher["Voucher_Date"] = arr_Voucher_field[0].ToString();
                    //Voucher BillNo Field
                    dr_Voucher["Bill_No"] = Convert.ToInt32(arr_Voucher_field[1]);
                    //Voucher Receipt Field 
                    dr_Voucher["Receipt_ID"] = 0;
                    //Voucher Name_Of_Firm
                    dr_Voucher["Name_Of_Firm"] = arr_Voucher_field[2].ToString();

                    //Add the Row to the Voucher Table
                    dt_Voucher.Rows.Add(dr_Voucher);
                    dt_Voucher.AcceptChanges();


                    //Create Voucher Details Table
                    //objtbl_Accounts1.AccName = AccName;
                    //int Acc_ID = objBLtbl_Accounts11.GetAccID(objtbl_Accounts1);
                    //string[] arr_Voucher_Detail_Fields = new string[8];
                    //objtbl_System_Config.Table_Name = "tbl_Voucher_Details";
                    //dt_Voucher_Details_Accounts = objBltbl_System_Config.Get_Column_Name_With_DataType(objtbl_System_Config);
                    //dt_Voucher_Details_Accounts.Columns.Remove(dt_Voucher_Details_Accounts.Columns[0]);
                    //dt_Voucher_Details_Accounts.Columns.Remove(dt_Voucher_Details_Accounts.Columns[0]);
                    //dt_Voucher_Details_Accounts.TableName = "tbl_Voucher_Details";

                    objbalAdmin.Update_User_AccID(Super_User_Id, objtbl_Accounts1.A_Email_ID1);
                    //objbllAssessee.UpdateAccID(Super_User_Id, objtbl_Accounts1.PAN);
                }
            }
        }
    }

    //public void SaveJob(string NameID, string username, string ITRXML_ID)
    //{
    //    balXML objbalXML = new balXML();
    //    string Job_ID = objbalXML.getXML_JobID(Convert.ToInt64(ITRXML_ID));

    //    if (Job_ID == "0")
    //    {
    //        //Intialize ConnectionString
    //        string strConnName = ConfigurationManager.AppSettings["DatabaseEngine4"].ToString();
    //        string strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;

    //        //ConnectionString Of Admin
    //        string strConnName_Admin = ConfigurationManager.AppSettings["DatabaseEngine5"].ToString();
    //        string strConnectionString_Admin = ConfigurationManager.ConnectionStrings[strConnName_Admin].ConnectionString;

    //        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
    //        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
    //        DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

    //        //Reset List
    //        DBtbl_Module.ArrayIndex = 0;
    //        DBtbl_Module.count = 0;
    //        DBtbl_Module.lst_Field = new Dictionary<string, int>();

    //        DBtbl_Module.lst_Query = new List<string>();
    //        DBtbl_Module.lst_update = new List<string[]>();
    //        DBtbl_Module.Previous_RecordNo = 0;
    //        DBtbl_Module.Previous_Table = "";
    //        DBtbl_Module.Project_Name = "";

    //        //Create Parameters
    //        //Get Customer_ID
    //        //Generate Serial No Firm
    //        tbl_JobWork1 objtbl_JobWork1 = new tbl_JobWork1();
    //        Bltbl_JobWork11 objBltbl_JobWork11 = new Bltbl_JobWork11(strConnectionString, strConnName, strConnectionString_Admin);
    //        tbl_FileHeader objtbl_FileHeader = new tbl_FileHeader();
    //        Bltbl_FileHeader objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName, strConnectionString_Admin);
    //        tbl_ProcessHistoryJob objtbl_ProcessHistoryJob = new tbl_ProcessHistoryJob();
    //        Bltbl_ProcessHistoryJob objBltbl_ProcessHistoryJob = new Bltbl_ProcessHistoryJob(strConnectionString, strConnName, strConnectionString_Admin);

    //        bllAssessee objbllAssessee = new bllAssessee();
    //        DataTable dtAssessee = new DataTable();
    //        balAdmin objbalAdmin = new balAdmin();
    //        tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
    //        objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(HttpContext.Current.Session["User_ID"]));

    //        //dtAssessee = objbllAssessee.SelectAll(NameID);

    //        objtbl_JobWork1.Cust_ID = Convert.ToInt32(objtbl_UserRegistration.AccID);    // Convert.ToInt32(dtAssessee.Rows[0]["AccID"]);

    //        string Acc_Fy = HttpContext.Current.Session["AY"].ToString();
    //        //TAN Field        
    //        objtbl_JobWork1.TAN = "";

    //        //PAN Field
    //        objtbl_JobWork1.PAN = HttpContext.Current.Session["PAN"].ToString();

    //        //Get Firm ID
    //        objtbl_JobWork1.Firm_ID = 5;

    //        //Job Name Field
    //        //Get JobID
    //        objtbl_JobWork1.JobName = 2;// Convert.ToInt32(HttpContext.Current.Session["ITR"]);

    //        //FY
    //        objtbl_JobWork1.FY = HttpContext.Current.Session["AY"].ToString();

    //        //Quarter

    //        objtbl_JobWork1.Quarter = "";

    //        //OC Field        
    //        objtbl_JobWork1.OC = "Regular";
    //        objtbl_JobWork1.Date = DateTime.Now.ToShortDateString();

    //        //Form Type
    //        objtbl_JobWork1.Form_Type = "ITR-1";
    //        //objtbl_JobWork1.Form_Type = HttpContext.Current.Session["ITR"].ToString();

    //        //Page_ID
    //        objtbl_JobWork1.PageID = 503;
    //        //Assignment ID
    //        objtbl_JobWork1.Assignment_ID = 0;

    //        //Return Completed ID
    //        objtbl_JobWork1.Return_Completed_ID = 0;

    //        //Payment ID
    //        objtbl_JobWork1.Payment_ID = 0;

    //        //Bill Id
    //        objtbl_JobWork1.Bill_ID = 0;

    //        //Return_SAM_Uploaded
    //        objtbl_JobWork1.Return_SAM_uploaded = 0;

    //        //Full Partial Completed
    //        objtbl_JobWork1.Full_Partial_Completed = "";
    //        //VID
    //        objtbl_JobWork1.VID = 0;

    //        //Page_ID and Page_SubModuleID
    //        objtbl_JobWork1.Page_ID = "503";
    //        objtbl_JobWork1.Page_SubModule_ID = "16";

    //        // Get The Serial Order No By Job and Firm
    //        objtbl_JobWork1.Job_Name_ID = 2;
    //        objtbl_JobWork1.Firm_ID = 5;
    //        objtbl_JobWork1.Accountant_FY = Acc_Fy;

    //        //Serial Number of Job----According to Job Name
    //        int Serial_No_Job_Firm = objBltbl_JobWork11.Get_SerialNo_ByFirmandJob(objtbl_JobWork1);
    //        if (Serial_No_Job_Firm == 0)
    //        {
    //            Serial_No_Job_Firm = 1;
    //        }
    //        objtbl_JobWork1.Serial_No_JobNoFirm = Serial_No_Job_Firm;
    //        //Serial Number of Job----According to Firm ID
    //        int Serial_No_Firm = objBltbl_JobWork11.Get_SerialNo_ByFirm(objtbl_JobWork1);
    //        if (Serial_No_Firm == 0)
    //        {
    //            Serial_No_Firm = 1;
    //        }
    //        objtbl_JobWork1.Serial_No_Firm = Serial_No_Firm;
    //        objtbl_JobWork1.Dir_Path = "";

    //        //Check the Existence in Case Of Original
    //        //Call the Query
    //        int success = objBltbl_JobWork11.InsertNewReturnsType(objtbl_JobWork1);
    //        if (success == 1)
    //        {
    //            objtbl_JobWork1.Date = "-999999999";
    //            int identity = objBltbl_JobWork11.InsertNewReturnsType(objtbl_JobWork1);
    //            //Return The JobID
    //            //objtbl_JobWork1.Cust_ID = Customre_ID;
    //            //objtbl_JobWork1.FinancialYear = drp_FinancialYear.SelectedValue.ToString();
    //            //objtbl_JobWork1.Quarter = drp_Quarter.SelectedValue.ToString();
    //            //objtbl_JobWork1.RetType = drp_ReturnType.SelectedValue.ToString();
    //            //objtbl_JobWork1.Form_Type = drp_FormType.SelectedValue.ToString();

    //            //get the jobId
    //            string Job_ID_msg = identity.ToString();
    //            //Get Serial Number By Job_Firm
    //            objtbl_JobWork1.Job_ID = Convert.ToInt32(Job_ID_msg);
    //            string SerialNo = objBltbl_JobWork11.Get_SerialNo_By_JobID(objtbl_JobWork1);
    //            //TAN Field
    //            objtbl_FileHeader.TAN = "";
    //            //Financial Year
    //            string FYMaster = HttpContext.Current.Session["AY"].ToString();
    //            FYMaster = FYMaster.Replace("-", "");
    //            FYMaster = FYMaster.Remove(4, 2);
    //            objtbl_FileHeader.FinancialYear = FYMaster;
    //            //Quarter
    //            objtbl_FileHeader.Quarter = "";

    //            //Form No
    //            objtbl_FileHeader.FormType = "ITR-1";// HttpContext.Current.Session["ITR"].ToString();

    //            //Original-Correction
    //            objtbl_FileHeader.Regular_Correction = "Regular";

    //            //Insert in Master Table - tbl-Master
    //            //objtbl_FileHeader.Job_ID = Convert.ToInt32(SerialNo);
    //            objtbl_FileHeader.Job_ID = Convert.ToInt32(Job_ID_msg);
    //            ////Check the Existence of the Record in the Master Table
    //            //bool Is_MasterExist = objBltbl_FileHeader.CheckMasterTableExistence(objtbl_FileHeader);
    //            //if (!Is_MasterExist)
    //            //{
    //            //    objtbl_FileHeader.Job_ID = Convert.ToInt32(Job_ID_msg);
    //            //int successM = objBltbl_FileHeader.Insert_Master_Record_JobID(objtbl_FileHeader);         -- Commenting it as Master_Record is in MyDataBase1
    //            //}
    //            //else
    //            //{
    //            //    objtbl_FileHeader.Job_ID = Convert.ToInt32(Job_ID_msg);
    //            //    int successM = objBltbl_FileHeader.Update_JobID_InMasterTabel(objtbl_FileHeader);
    //            //}

    //            //Add the New Return Received to the Process History of job Table

    //            objtbl_ProcessHistoryJob.Master_ID = Convert.ToInt32(Job_ID_msg);
    //            objtbl_ProcessHistoryJob.Next_User_ID = Convert.ToInt32(HttpContext.Current.Session["User_ID"]);    
    //            objtbl_ProcessHistoryJob.Previous_User_ID = 0;
    //            objtbl_ProcessHistoryJob.Priority_of_Job = 0;
    //            objtbl_ProcessHistoryJob.Job_Status = "BO";
    //            objtbl_ProcessHistoryJob.Reason_for_Delay = "";
    //            objtbl_ProcessHistoryJob.Date_Time_Stamp = DateTime.Now.ToString();
    //            //Call the Query and Fill the New Return in the Process Histroy of Job Table

    //            objBltbl_ProcessHistoryJob.Insert_Return(objtbl_ProcessHistoryJob);

    //            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('File Number:" + Job_ID_msg + "');", true);
    //            //Create  Directory
    //            objtbl_ProcessHistoryJob.Master_ID = Convert.ToInt32(Job_ID_msg);
    //            objtbl_ProcessHistoryJob.Directory_Status = "N";
    //            objBltbl_ProcessHistoryJob.Fill_Directories_Status(objtbl_ProcessHistoryJob);

    //            //string JobName = drp_NameofJob.SelectedItem.ToString();
    //            ////Get the Job Group Name By Jobname
    //            //objtbl_JobWork1.Job_Name = JobName;

    //            //Fil the Record in the Job Directory Table
    //            string Proj_Path = (HttpContext.Current.Session["Project"].ToString() == "vt") ? "ITR" : "TDS";
    //            string Path = "E:\\VatasSolution_Directories\\" + Acc_Fy.ToString() + "\\VatasInfotech-Online\\" + Proj_Path + "\\" + Job_ID_msg + "";

    //            objtbl_JobWork1.Dir_Path = Path;
    //            objBltbl_JobWork11.UpdateDirectoryPath(objtbl_JobWork1);

    //            using (ZipFile zip = new ZipFile())
    //            {
    //                //zip.AddFile(Path + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
    //                zip.Save(Path + ".zip");
    //            }

    //            //if (!File.Exists(Path + ".zip"))
    //            //    File.Create(Path + ".zip");
    //            //if (!Directory.Exists(Path))
    //            //{
    //            //    Directory.CreateDirectory(Path + ".zip");
    //            //}
    //            //else
    //            //{
    //            //    Directory.CreateDirectory(Path + ".zip");
    //            //}
    //            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "confirm('File Number:" + SerialNo + ", Directory is Successfully Created!');", true);
    //            //lbl_SRNo.Text = Job_ID_msg;
    //            //btn_Attachments.Attributes.Remove("style");
    //            //msg_Diretory.Confirm("Directory is Successfully Created At: " + Path + " ,Do you want to Upload Documents to it!");


    //            objbalXML.Update_JobID(ITRXML_ID, objtbl_JobWork1.PAN);
    //        }
    //    }
    //}

    public void SaveJob_TDS(string username)
    {
        balXML objbalXML = new balXML();     
        
        {
            //Intialize ConnectionString
            string strConnName = ConfigurationManager.AppSettings["DatabaseEngine4"].ToString();
            string strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;

            //ConnectionString Of Admin
            string strConnName_Admin = ConfigurationManager.AppSettings["DatabaseEngine5"].ToString();
            string strConnectionString_Admin = ConfigurationManager.ConnectionStrings[strConnName_Admin].ConnectionString;

            string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
            DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

            //Reset List
            DBtbl_Module.ArrayIndex = 0;
            DBtbl_Module.count = 0;
            DBtbl_Module.lst_Field = new Dictionary<string, int>();

            DBtbl_Module.lst_Query = new List<string>();
            DBtbl_Module.lst_update = new List<string[]>();
            DBtbl_Module.Previous_RecordNo = 0;
            DBtbl_Module.Previous_Table = "";
            DBtbl_Module.Project_Name = "";

            //Create Parameters
            //Get Customer_ID
            //Generate Serial No Firm
            tbl_JobWork1 objtbl_JobWork1 = new tbl_JobWork1();
            Bltbl_JobWork11 objBltbl_JobWork11 = new Bltbl_JobWork11(strConnectionString, strConnName, strConnectionString_Admin);
            tbl_FileHeader objtbl_FileHeader = new tbl_FileHeader();
            Bltbl_FileHeader objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName, strConnectionString_Admin);
            tbl_ProcessHistoryJob objtbl_ProcessHistoryJob = new tbl_ProcessHistoryJob();
            Bltbl_ProcessHistoryJob objBltbl_ProcessHistoryJob = new Bltbl_ProcessHistoryJob(strConnectionString, strConnName, strConnectionString_Admin);

            bllAssessee objbllAssessee = new bllAssessee();
            DataTable dtAssessee = new DataTable();
            balAdmin objbalAdmin = new balAdmin();
            tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
            objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(HttpContext.Current.Session["User_ID"]));

            //dtAssessee = objbllAssessee.SelectAll(NameID);

            objtbl_JobWork1.Cust_ID = Convert.ToInt32(objtbl_UserRegistration.AccID);    // Convert.ToInt32(dtAssessee.Rows[0]["AccID"]);

            string Acc_Fy = HttpContext.Current.Session["FY"].ToString();
            //TAN Field        
            objtbl_JobWork1.TAN = HttpContext.Current.Session["TAN"].ToString();

            //PAN Field
            objtbl_JobWork1.PAN = (HttpContext.Current.Session["PAN"] != null) ? HttpContext.Current.Session["PAN"].ToString() : "";

            //Get Firm ID
            objtbl_JobWork1.Firm_ID = 5;

            //Job Name Field
            //Get JobID
            objtbl_JobWork1.JobName = 2;// Convert.ToInt32(HttpContext.Current.Session["ITR"]);

            //FY
            objtbl_JobWork1.FY = HttpContext.Current.Session["FY"].ToString();

            //Quarter

            objtbl_JobWork1.Quarter = HttpContext.Current.Session["qtr"].ToString();

            //OC Field        
            objtbl_JobWork1.OC = HttpContext.Current.Session["OC"].ToString();
            objtbl_JobWork1.Date = DateTime.Now.ToShortDateString();

            //Form Type
            objtbl_JobWork1.Form_Type = HttpContext.Current.Session["FormType"].ToString();
            //objtbl_JobWork1.Form_Type = HttpContext.Current.Session["ITR"].ToString();

            //Page_ID
            objtbl_JobWork1.PageID = 503;
            //Assignment ID
            objtbl_JobWork1.Assignment_ID = 0;

            //Return Completed ID
            objtbl_JobWork1.Return_Completed_ID = 0;

            //Payment ID
            objtbl_JobWork1.Payment_ID = 0;

            //Bill Id
            objtbl_JobWork1.Bill_ID = 0;

            //Return_SAM_Uploaded
            objtbl_JobWork1.Return_SAM_uploaded = 0;

            //Full Partial Completed
            objtbl_JobWork1.Full_Partial_Completed = "";
            //VID
            objtbl_JobWork1.VID = 0;

            //Page_ID and Page_SubModuleID
            objtbl_JobWork1.Page_ID = "503";
            objtbl_JobWork1.Page_SubModule_ID = "16";

            // Get The Serial Order No By Job and Firm
            objtbl_JobWork1.Job_Name_ID = 2;
            objtbl_JobWork1.Firm_ID = 5;
            objtbl_JobWork1.Accountant_FY = Acc_Fy;

            //Serial Number of Job----According to Job Name
            int Serial_No_Job_Firm = objBltbl_JobWork11.Get_SerialNo_ByFirmandJob(objtbl_JobWork1);
            if (Serial_No_Job_Firm == 0)
            {
                Serial_No_Job_Firm = 1;
            }
            objtbl_JobWork1.Serial_No_JobNoFirm = Serial_No_Job_Firm;
            //Serial Number of Job----According to Firm ID
            int Serial_No_Firm = objBltbl_JobWork11.Get_SerialNo_ByFirm(objtbl_JobWork1);
            if (Serial_No_Firm == 0)
            {
                Serial_No_Firm = 1;
            }
            objtbl_JobWork1.Serial_No_Firm = Serial_No_Firm;
            objtbl_JobWork1.Dir_Path = "";

            //Check the Existence in Case Of Original
            //Call the Query
            int success = objBltbl_JobWork11.InsertNewReturnsType(objtbl_JobWork1);
            if (success == 1)
            {
                objtbl_JobWork1.Date = "-999999999";
                int identity = objBltbl_JobWork11.InsertNewReturnsType(objtbl_JobWork1);
                //Return The JobID
                //objtbl_JobWork1.Cust_ID = Customre_ID;
                //objtbl_JobWork1.FinancialYear = drp_FinancialYear.SelectedValue.ToString();
                //objtbl_JobWork1.Quarter = drp_Quarter.SelectedValue.ToString();
                //objtbl_JobWork1.RetType = drp_ReturnType.SelectedValue.ToString();
                //objtbl_JobWork1.Form_Type = drp_FormType.SelectedValue.ToString();

                //get the jobId
                string Job_ID_msg = identity.ToString();
                //Get Serial Number By Job_Firm
                objtbl_JobWork1.Job_ID = Convert.ToInt32(Job_ID_msg);
                string SerialNo = objBltbl_JobWork11.Get_SerialNo_By_JobID(objtbl_JobWork1);
                //TAN Field
                objtbl_FileHeader.TAN = "";
                //Financial Year
                string FYMaster = HttpContext.Current.Session["AY"].ToString();
                FYMaster = FYMaster.Replace("-", "");
                FYMaster = FYMaster.Remove(4, 2);
                objtbl_FileHeader.FinancialYear = FYMaster;
                //Quarter
                objtbl_FileHeader.Quarter = "";

                //Form No
                objtbl_FileHeader.FormType = HttpContext.Current.Session["FormType"].ToString();

                //Original-Correction
                objtbl_FileHeader.Regular_Correction = "Regular";

                //Insert in Master Table - tbl-Master
                //objtbl_FileHeader.Job_ID = Convert.ToInt32(SerialNo);
                objtbl_FileHeader.Job_ID = Convert.ToInt32(Job_ID_msg);
                ////Check the Existence of the Record in the Master Table
                //bool Is_MasterExist = objBltbl_FileHeader.CheckMasterTableExistence(objtbl_FileHeader);
                //if (!Is_MasterExist)
                //{
                //    objtbl_FileHeader.Job_ID = Convert.ToInt32(Job_ID_msg);
                //int successM = objBltbl_FileHeader.Insert_Master_Record_JobID(objtbl_FileHeader);         -- Commenting it as Master_Record is in MyDataBase1
                //}
                //else
                //{
                //    objtbl_FileHeader.Job_ID = Convert.ToInt32(Job_ID_msg);
                //    int successM = objBltbl_FileHeader.Update_JobID_InMasterTabel(objtbl_FileHeader);
                //}

                //Add the New Return Received to the Process History of job Table

                objtbl_ProcessHistoryJob.Master_ID = Convert.ToInt32(Job_ID_msg);
                objtbl_ProcessHistoryJob.Next_User_ID = Convert.ToInt32(HttpContext.Current.Session["User_ID"]);
                objtbl_ProcessHistoryJob.Previous_User_ID = 0;
                objtbl_ProcessHistoryJob.Priority_of_Job = 0;
                objtbl_ProcessHistoryJob.Job_Status = "BO";
                objtbl_ProcessHistoryJob.Reason_for_Delay = "";
                objtbl_ProcessHistoryJob.Date_Time_Stamp = DateTime.Now.ToString();
                //Call the Query and Fill the New Return in the Process Histroy of Job Table

                objBltbl_ProcessHistoryJob.Insert_Return(objtbl_ProcessHistoryJob);

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('File Number:" + Job_ID_msg + "');", true);
                //Create  Directory
                objtbl_ProcessHistoryJob.Master_ID = Convert.ToInt32(Job_ID_msg);
                objtbl_ProcessHistoryJob.Directory_Status = "N";
                objBltbl_ProcessHistoryJob.Fill_Directories_Status(objtbl_ProcessHistoryJob);

                //string JobName = drp_NameofJob.SelectedItem.ToString();
                ////Get the Job Group Name By Jobname
                //objtbl_JobWork1.Job_Name = JobName;

                //Fil the Record in the Job Directory Table
                string Path = "E:\\VatasSolution_Directories\\" + Acc_Fy.ToString() + "\\VatasInfotech-Online\\TDS\\" + Job_ID_msg + "";

                objtbl_JobWork1.Dir_Path = Path;
                objBltbl_JobWork11.UpdateDirectoryPath(objtbl_JobWork1);

                //using (ZipFile zip = new ZipFile())
                //{
                //    //zip.AddFile(Path + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
                //    zip.Save(Path + ".zip");
                //}

                //if (!File.Exists(Path + ".zip"))
                //    File.Create(Path + ".zip");
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "confirm('File Number:" + SerialNo + ", Directory is Successfully Created!');", true);
                //lbl_SRNo.Text = Job_ID_msg;
                //btn_Attachments.Attributes.Remove("style");
                //msg_Diretory.Confirm("Directory is Successfully Created At: " + Path + " ,Do you want to Upload Documents to it!");


               // objbalXML.Update_JobID(ITRXML_ID, objtbl_JobWork1.PAN);
            }
        }
    }

    public void SaveJob(string NameID, string username, string ITRXML_ID)
    {
        balXML objbalXML = new balXML();
        string Job_ID = "";
        Job_ID = (ITRXML_ID != "") ? objbalXML.getXML_JobID(Convert.ToInt64(ITRXML_ID)) : "0";

        if (Job_ID == "0")
        {
            //Intialize ConnectionString
            string strConnName = ConfigurationManager.AppSettings["DatabaseEngine4"].ToString();
            string strConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;

            //ConnectionString Of Admin
            string strConnName_Admin = ConfigurationManager.AppSettings["DatabaseEngine5"].ToString();
            string strConnectionString_Admin = ConfigurationManager.ConnectionStrings[strConnName_Admin].ConnectionString;

            string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
            DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

            //Reset List
            DBtbl_Module.ArrayIndex = 0;
            DBtbl_Module.count = 0;
            DBtbl_Module.lst_Field = new Dictionary<string, int>();

            DBtbl_Module.lst_Query = new List<string>();
            DBtbl_Module.lst_update = new List<string[]>();
            DBtbl_Module.Previous_RecordNo = 0;
            DBtbl_Module.Previous_Table = "";
            DBtbl_Module.Project_Name = "";

            //Create Parameters
            //Get Customer_ID
            //Generate Serial No Firm
            tbl_JobWork1 objtbl_JobWork1 = new tbl_JobWork1();
            Bltbl_JobWork11 objBltbl_JobWork11 = new Bltbl_JobWork11(strConnectionString, strConnName, strConnectionString_Admin);
            tbl_FileHeader objtbl_FileHeader = new tbl_FileHeader();
            Bltbl_FileHeader objBltbl_FileHeader = new Bltbl_FileHeader(strConnectionString, strConnName, strConnectionString_Admin);
            tbl_ProcessHistoryJob objtbl_ProcessHistoryJob = new tbl_ProcessHistoryJob();
            Bltbl_ProcessHistoryJob objBltbl_ProcessHistoryJob = new Bltbl_ProcessHistoryJob(strConnectionString, strConnName, strConnectionString_Admin);

            bllAssessee objbllAssessee = new bllAssessee();
            DataTable dtAssessee = new DataTable();
            balAdmin objbalAdmin = new balAdmin();
            tbl_UserRegistration objtbl_UserRegistration = new tbl_UserRegistration();
            objtbl_UserRegistration = objbalAdmin.SelectData(Convert.ToInt32(HttpContext.Current.Session["User_ID"]));

            //dtAssessee = objbllAssessee.SelectAll(NameID);

            objtbl_JobWork1.Cust_ID = Convert.ToInt32(objtbl_UserRegistration.AccID);    // Convert.ToInt32(dtAssessee.Rows[0]["AccID"]);

            string ssa1 = (HttpContext.Current.Session["FY"] != null) ? HttpContext.Current.Session["FY"].ToString() : "";
            ssa1 = HttpContext.Current.Session["AY"].ToString();
            string Acc_Fy = (HttpContext.Current.Session["FY"] != null) ? HttpContext.Current.Session["FY"].ToString() : HttpContext.Current.Session["AY"].ToString();
            //TAN Field        
            objtbl_JobWork1.TAN = (HttpContext.Current.Session["TAN"] != null) ? HttpContext.Current.Session["TAN"].ToString() : "";

            //PAN Field
            objtbl_JobWork1.PAN = (HttpContext.Current.Session["PAN"] != null) ? HttpContext.Current.Session["PAN"].ToString() : "";

            //Get Firm ID
            objtbl_JobWork1.Firm_ID = 5;

            //Job Name Field
            //Get JobID
            objtbl_JobWork1.JobName = 2;// Convert.ToInt32(HttpContext.Current.Session["ITR"]);

            //FY
            objtbl_JobWork1.FY = (HttpContext.Current.Session["FY"] != null) ? HttpContext.Current.Session["FY"].ToString() : HttpContext.Current.Session["AY"].ToString();

            //Quarter

            objtbl_JobWork1.Quarter = (HttpContext.Current.Session["Qtr"] != null) ? HttpContext.Current.Session["Qtr"].ToString() : "";

            //OC Field        
            objtbl_JobWork1.OC = (HttpContext.Current.Session["OC"] != null) ? HttpContext.Current.Session["OC"].ToString() : "Regular";
            objtbl_JobWork1.Date = DateTime.Now.ToShortDateString();

            //Form Type
            objtbl_JobWork1.Form_Type = (HttpContext.Current.Session["FormType"] != null) ? HttpContext.Current.Session["FormType"].ToString() : "ITR-1";
            //objtbl_JobWork1.Form_Type = HttpContext.Current.Session["ITR"].ToString();

            //Page_ID
            objtbl_JobWork1.PageID = 503;
            //Assignment ID
            objtbl_JobWork1.Assignment_ID = 0;

            //Return Completed ID
            objtbl_JobWork1.Return_Completed_ID = 0;

            //Payment ID
            objtbl_JobWork1.Payment_ID = 0;

            //Bill Id
            objtbl_JobWork1.Bill_ID = 0;

            //Return_SAM_Uploaded
            objtbl_JobWork1.Return_SAM_uploaded = 0;

            //Full Partial Completed
            objtbl_JobWork1.Full_Partial_Completed = "";
            //VID
            objtbl_JobWork1.VID = 0;

            //Page_ID and Page_SubModuleID
            objtbl_JobWork1.Page_ID = "503";
            objtbl_JobWork1.Page_SubModule_ID = "16";

            // Get The Serial Order No By Job and Firm
            objtbl_JobWork1.Job_Name_ID = 2;
            objtbl_JobWork1.Firm_ID = 5;
            objtbl_JobWork1.Accountant_FY = Acc_Fy;

            //Serial Number of Job----According to Job Name
            int Serial_No_Job_Firm = objBltbl_JobWork11.Get_SerialNo_ByFirmandJob(objtbl_JobWork1);
            if (Serial_No_Job_Firm == 0)
            {
                Serial_No_Job_Firm = 1;
            }
            objtbl_JobWork1.Serial_No_JobNoFirm = Serial_No_Job_Firm;
            //Serial Number of Job----According to Firm ID
            int Serial_No_Firm = objBltbl_JobWork11.Get_SerialNo_ByFirm(objtbl_JobWork1);
            if (Serial_No_Firm == 0)
            {
                Serial_No_Firm = 1;
            }
            objtbl_JobWork1.Serial_No_Firm = Serial_No_Firm;
            objtbl_JobWork1.Dir_Path = "";

            //Check the Existence in Case Of Original
            //Call the Query
            int success = objBltbl_JobWork11.InsertNewReturnsType(objtbl_JobWork1);
            if (success == 1)
            {
                objtbl_JobWork1.Date = "-999999999";
                int identity = objBltbl_JobWork11.InsertNewReturnsType(objtbl_JobWork1);
                
                //get the jobId
                string Job_ID_msg = identity.ToString();
                //Get Serial Number By Job_Firm
                objtbl_JobWork1.Job_ID = Convert.ToInt32(Job_ID_msg);
                string SerialNo = objBltbl_JobWork11.Get_SerialNo_By_JobID(objtbl_JobWork1);
                //TAN Field
                objtbl_FileHeader.TAN = "";
                //Financial Year
                string FYMaster = HttpContext.Current.Session["AY"].ToString();
                FYMaster = FYMaster.Replace("-", "");
                FYMaster = FYMaster.Remove(4, 2);
                objtbl_FileHeader.FinancialYear = FYMaster;
                //Quarter
                objtbl_FileHeader.Quarter = "";

                //Form No
                objtbl_FileHeader.FormType = (HttpContext.Current.Session["FormType"] != null) ? HttpContext.Current.Session["FormType"].ToString() : "ITR-1";// HttpContext.Current.Session["ITR"].ToString();

                //Original-Correction
                objtbl_FileHeader.Regular_Correction = "Regular";

                //Insert in Master Table - tbl-Master
                objtbl_FileHeader.Job_ID = Convert.ToInt32(Job_ID_msg);
               
                //Add the New Return Received to the Process History of job Table

                objtbl_ProcessHistoryJob.Master_ID = Convert.ToInt32(Job_ID_msg);
                objtbl_ProcessHistoryJob.Next_User_ID = Convert.ToInt32(HttpContext.Current.Session["User_ID"]);
                objtbl_ProcessHistoryJob.Previous_User_ID = 0;
                objtbl_ProcessHistoryJob.Priority_of_Job = 0;
                objtbl_ProcessHistoryJob.Job_Status = "BO";
                objtbl_ProcessHistoryJob.Reason_for_Delay = "";
                objtbl_ProcessHistoryJob.Date_Time_Stamp = DateTime.Now.ToString();
                //Call the Query and Fill the New Return in the Process Histroy of Job Table

                objBltbl_ProcessHistoryJob.Insert_Return(objtbl_ProcessHistoryJob);
                                
                //Create  Directory
                objtbl_ProcessHistoryJob.Master_ID = Convert.ToInt32(Job_ID_msg);
                objtbl_ProcessHistoryJob.Directory_Status = "N";
                objBltbl_ProcessHistoryJob.Fill_Directories_Status(objtbl_ProcessHistoryJob);
                
                //Fil the Record in the Job Directory Table
                string Proj_Path = (HttpContext.Current.Session["Project"].ToString() == "vt") ? "ITR" : "TDS";
                string Path = "E:\\VatasSolution_Directories\\" + Acc_Fy.ToString() + "\\VatasInfotech-Online\\" + Proj_Path + "\\" + Job_ID_msg + "";
                HttpContext.Current.Session["Common_JobID_Path"] = Path;
                HttpContext.Current.Session["Common_JobID"] = Job_ID_msg;
                objtbl_JobWork1.Dir_Path = Path;
                objBltbl_JobWork11.UpdateDirectoryPath(objtbl_JobWork1);

                if (HttpContext.Current.Session["Project"].ToString() != "tds" && HttpContext.Current.Session["Project"].ToString() != "tds2")
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        //zip.AddFile(Path + "/" + Session["PAN"].ToString() + "_" + strITR + "_" + (Session["AY"].ToString().Substring(0, 4)) + "_N_" + Session["PAN"].ToString().Substring(5, 4) + ".xml");
                        zip.Save(Path + ".zip");
                    }
                }
                else
                {
                    if (!Directory.Exists(Path))
                    {
                        Directory.CreateDirectory(Path);
                    }
                }               
                if (ITRXML_ID != "")
                    objbalXML.Update_JobID(ITRXML_ID, objtbl_JobWork1.PAN);
            }
        }
    }

    public string getDirectoryPath()
    {
        string path = "";
        if (HttpContext.Current.Session["ITRXML_ID"] != null)
        {
            try
            {
                this.pConn();
                string strSQL = "";
                strSQL = @"select Dir_Path from VatasSolution.dbo.Returns_Copy where Job_ID = (select Job_ID from Tbl_ITRXML where ID=@ITRXML_ID)";
                cmd = new SqlCommand(strSQL, this.SqlCon);
                cmd.Parameters.AddWithValue("@ITRXML_ID", Convert.ToInt64(HttpContext.Current.Session["ITRXML_ID"]));
                path = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        return path;
    }

    public string getDirectoryPath(string ITRXML_ID)
    {
        string path = "";
        if (ITRXML_ID != null)
        {
            try
            {
                this.pConn();
                string strSQL = "";
                strSQL = @"select Dir_Path from VatasSolution.dbo.Returns_Copy where Job_ID = (select Job_ID from Tbl_ITRXML where ID=@ITRXML_ID)";
                cmd = new SqlCommand(strSQL, this.SqlCon);
                cmd.Parameters.AddWithValue("@ITRXML_ID", Convert.ToInt64(ITRXML_ID));
                path = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        return path;
    }

    public string getDirectoryPath_ByJobID()
    {
        string path = "";
        if (HttpContext.Current.Session["Job_ID"] != null)
        {
            try
            {
                this.pConn();
                string strSQL = "";
                strSQL = @"select Dir_Path from VatasSolution.dbo.Returns_Copy where Job_ID = @Job_ID";
                cmd = new SqlCommand(strSQL, this.SqlCon);
                cmd.Parameters.AddWithValue("@Job_ID", HttpContext.Current.Session["Job_ID"].ToString());
                path = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        else
        {
            path = HttpContext.Current.Server.MapPath("~/UserDocs/") + HttpContext.Current.Session["User_ID"].ToString() + "/";
            if (HttpContext.Current.Session["Dir_Path"] != null)
                path = HttpContext.Current.Session["Dir_Path"].ToString() + "/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);            
        }
        return path;
    }

    public string getDirectoryPath_ByUsername()
    {
        string path = "";
        try
        {
            this.pConn();
            string strSQL = "";
            strSQL = @"select dir_path from vatassolution.dbo.returns_copy where Job_ID in(select Job_ID from tbl_itrxml where NameID in(select NameID from namemast where username=@userName))";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@userName", Convert.ToString(HttpContext.Current.Session["userEmail"]));
            path = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
        return path;
    }

    public void addError(tbl_ErrorLog objtbl_ErrorLog)
    {
        try
        {
            this.pConn();
            string strSQL = "";
            strSQL = @"insert into tbl_ErrorLog(ErrorMsg,methodName,className,pageName,ErrDateTime,IsDone,SolvedBy) values(@ErrorMsg,@methodName,@className,@pageName,@ErrDateTime,@IsDone,@SolvedBy)";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@ErrorMsg", objtbl_ErrorLog.ErrorMsg);
            cmd.Parameters.AddWithValue("@methodName", objtbl_ErrorLog.methodName);
            cmd.Parameters.AddWithValue("@className", objtbl_ErrorLog.className);
            cmd.Parameters.AddWithValue("@pageName", objtbl_ErrorLog.pageName);
            cmd.Parameters.AddWithValue("@ErrDateTime", objtbl_ErrorLog.ErrDateTime);
            cmd.Parameters.AddWithValue("@IsDone", "False");
            cmd.Parameters.AddWithValue("@SolvedBy", 0);
            //cmd.Parameters.AddWithValue("@SolvedOn", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
    }

    public void updateError(tbl_ErrorLog objtbl_ErrorLog)
    {
        try
        {
            this.pConn();
            string strSQL = "";
            strSQL = @"update tbl_ErrorLog set SolvedBy=@SolvedBy,SolvedOn=@SolvedOn,IsDone=@IsDone where id=@id";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@SolvedBy", objtbl_ErrorLog.methodName);
            cmd.Parameters.AddWithValue("@SolvedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", objtbl_ErrorLog.id);
            cmd.Parameters.AddWithValue("@IsDone", true);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
    }

    public void AddUser(string NameID)
    {
        string strConnName_Admin, strConnectionString_Admin;
        //Connection  String For the Admin Process
        strConnName_Admin = HttpContext.Current.Application["DBEngine"].ToString();
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString;

        string Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        string ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

        strConnName_Admin = HttpContext.Current.Application["DBEngine"].ToString();
        strConnectionString_Admin = ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString;

        Leftpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        ApplicationHost = HttpContext.Current.Request.Url.DnsSafeHost.ToString();
        DBtbl_Module.Project_Name = "Admin," + ApplicationHost + "," + Leftpath;

        Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(strConnectionString_Admin, strConnName_Admin, ConfigurationManager.ConnectionStrings["con_Admin2"].ConnectionString);
        tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        //objtbl_User = new tbl_User();

        //Get Assessee Data:
        //bllSalary objbllSalary = new bllSalary();
        bllAssessee objbllAssessee = new bllAssessee();
        denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
        objAssesseeIndividual = objbllAssessee.GetDataIndividualByNameID(NameID);

        string EmailID = objAssesseeIndividual.EMail; //objbllSalary.getDataForConstID_String("21", NameID);
        string password = "password";
        string UserName = objAssesseeIndividual.FirstName + " " + objAssesseeIndividual.LastName;
        //objbllSalary.getDataForConstID_String("2", NameID) + " " + objbllSalary.getDataForConstID_String("4", NameID);

        //To check whether the email already exists in the User Database:
        balAdmin objbalAdmin = new balAdmin();
        //Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration();

        objtbl_UserGroupRegistration.EmailID = EmailID;
        objtbl_UserGroupRegistration.Password = password;
        bool Is_Exist = objBltbl_UserGroupRegistration.CheckExistence(objtbl_UserGroupRegistration);

        if (!Is_Exist)
        {
            int Success = Save_User_Admin(EmailID, password, UserName);
            if (Success == 1)
            {
                string Email_ID = EmailID;
                objtbl_UserGroupRegistration.EmailID = Email_ID;
                DataTable dt = new DataTable();
                dt = objBltbl_UserGroupRegistration.GetUserId_Email(objtbl_UserGroupRegistration);
                Int64 ID = Convert.ToInt32(dt.Rows[0]["Super_User_Id"]);
                objbalAdmin.Update_User_AccID(ID);
            }
        }
        else
        {
            string UserPAN = objAssesseeIndividual.PANNO; //objbllSalary.getDataForConstID_String("5", NameID);
            string Email_ID = UserPAN + "@echarteredaccountants.com";
            int Success = Save_User_Admin(Email_ID, password, UserName);
            if (Success == 1)
            {
                objtbl_UserGroupRegistration.EmailID = Email_ID;
                DataTable dt = new DataTable();
                dt = objBltbl_UserGroupRegistration.GetUserId_Email(objtbl_UserGroupRegistration);
                Int64 ID = Convert.ToInt32(dt.Rows[0]["Super_User_Id"]);
                objbalAdmin.Update_User_AccID(ID);
            }
        }
    }

    public int Save_User_Admin(string EmailID, string password, string UserName)
    {
        DBtbl_Module.ArrayIndex = 0;
        DBtbl_Module.Previous_RecordNo = 0;
        DBtbl_Module.lst_Query = new List<string>();
        DBtbl_Module.lst_Field = new Dictionary<string, int>();
        DBtbl_Module.Previous_Table = "";
        string User_Name = UserName;
        string Password = password;
        string Confirm_Password = password;
        string Is_deleted = "N";
        string Change_Password = "No";
        string Select_Role = "user";// "Staff";
        string Attempt_Unlock = "No";
        int Consecutive_Attempts = Convert.ToInt32("0");

        tbl_UserGroupRegistration objtbl_UserGroupRegistration = new tbl_UserGroupRegistration();
        Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration = new Bltbl_UserGroupRegistration(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);
        tbl_UserInfo_Mangement objtbl_UserInfo_Mangement = new tbl_UserInfo_Mangement();
        Bltbl_UserInfo_Mangement objBltbl_UserInfo_Mangement = new Bltbl_UserInfo_Mangement(ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString, "SQLServer", ConfigurationManager.ConnectionStrings["con_Admin"].ConnectionString);

        objtbl_UserGroupRegistration.Name = User_Name;
        objtbl_UserGroupRegistration.Last_Name = "";
        objtbl_UserGroupRegistration.EmailID = EmailID;
        objtbl_UserGroupRegistration.Password = Password;
        objtbl_UserGroupRegistration.Confirm_Password = Confirm_Password;
        objtbl_UserGroupRegistration.Address1 = "";
        objtbl_UserGroupRegistration.Country = 0;
        objtbl_UserGroupRegistration.State = "0";
        objtbl_UserGroupRegistration.City = "";
        objtbl_UserGroupRegistration.PinCode = 0;
        objtbl_UserGroupRegistration.MobileNumber = "";
        objtbl_UserGroupRegistration.STDCODE = 0;
        objtbl_UserGroupRegistration.Telephone = "";
        objtbl_UserGroupRegistration.OrganizationName = "5";
        objtbl_UserGroupRegistration.SecurityQuestion = "";
        objtbl_UserGroupRegistration.Answer = "";
        objtbl_UserGroupRegistration.SelectPackage = "FREE";
        objtbl_UserGroupRegistration.ActivationCode = "";
        objtbl_UserGroupRegistration.STATUS = "";
        objtbl_UserGroupRegistration.Join_Date = DateTime.Now;
        objtbl_UserGroupRegistration.Account_Type = "US";
        objtbl_UserGroupRegistration.Page_ID = "504";
        objtbl_UserGroupRegistration.Page_SubModule_ID = "33";
        objtbl_UserGroupRegistration.Is_Login_Active = "Y";

        //Call Insert Function and Pass Parameter to the Function
        int Success = objBltbl_UserGroupRegistration.InsertRegistrationEntry(objtbl_UserGroupRegistration);
        int success1 = 0;
        if (Success == 1)
        {
            //Get the UserId
            int User_ID = objBltbl_UserGroupRegistration.Get_User_ID(objtbl_UserGroupRegistration);
            objtbl_UserInfo_Mangement.User_Id = User_ID;
            objtbl_UserInfo_Mangement.Can_Change_Password = Change_Password;
            objtbl_UserInfo_Mangement.Role = Select_Role.ToString();
            objtbl_UserInfo_Mangement.Is_Locked = Attempt_Unlock;
            objtbl_UserInfo_Mangement.Consecutive_Attempts = Consecutive_Attempts;
            objtbl_UserInfo_Mangement.Is_Deleted = Is_deleted;
            objtbl_UserInfo_Mangement.Page_ID = "504";
            objtbl_UserInfo_Mangement.Page_SubModule_ID = "33";
            //Call Insert Function and Pass Parameter to the Function
            success1 = objBltbl_UserInfo_Mangement.InsertUser_Info(objtbl_UserInfo_Mangement);
        }
        return success1;
    }

    public void startProcessHistoryJob(Int64 Job_ID, Int64 NextUserID, string Job_Status, string Is_Sent)
    {
        blltbl_ProcessesHistoryofjob objblltbl_ProcessesHistoryofjob = new blltbl_ProcessesHistoryofjob();
        dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob = new dentbl_ProcessesHistoryofjob();
        objdentbl_ProcessesHistoryofjob.Date_Time_Stamp = DateTime.Now.ToLongDateString();
        objdentbl_ProcessesHistoryofjob.Is_Sent = Is_Sent;
        objdentbl_ProcessesHistoryofjob.Job_Status = Job_Status;
        objdentbl_ProcessesHistoryofjob.MasterID = Job_ID;
        objdentbl_ProcessesHistoryofjob.Next_UserID = NextUserID;
        objdentbl_ProcessesHistoryofjob.Previous_UserID = 0;
        objdentbl_ProcessesHistoryofjob.Priority_of_Job = 0;
        objdentbl_ProcessesHistoryofjob.Reason_for_Delay = "";
        objdentbl_ProcessesHistoryofjob.Supervisor = "Ishwinder Singh";
        objblltbl_ProcessesHistoryofjob.InsertDataMainGrid(objdentbl_ProcessesHistoryofjob);
    }

    public void updateProcessStatus(Int64 Job_ID, Int64 NextUserID)
    {
        blltbl_ProcessesHistoryofjob objblltbl_ProcessesHistoryofjob = new blltbl_ProcessesHistoryofjob();
        dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob = new dentbl_ProcessesHistoryofjob();

        objdentbl_ProcessesHistoryofjob.MasterID = Job_ID;
        objdentbl_ProcessesHistoryofjob.Next_UserID = NextUserID;
        objblltbl_ProcessesHistoryofjob.updateProcess(objdentbl_ProcessesHistoryofjob);
    }

    public void updateProcessDetail(Int64 Job_ID, Int64 NextUserID, string Is_Sent, string Reason_for_Delay)
    {
        blltbl_ProcessesHistoryofjob objblltbl_ProcessesHistoryofjob = new blltbl_ProcessesHistoryofjob();
        dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob = new dentbl_ProcessesHistoryofjob();

        objdentbl_ProcessesHistoryofjob.MasterID = Job_ID;
        objdentbl_ProcessesHistoryofjob.Next_UserID = NextUserID;
        objdentbl_ProcessesHistoryofjob.Is_Sent = Is_Sent;
        objdentbl_ProcessesHistoryofjob.Reason_for_Delay = Reason_for_Delay;
        objblltbl_ProcessesHistoryofjob.updateProcessDetail(objdentbl_ProcessesHistoryofjob);
    }

    public bool IsJobExists(string TAN, string Accountant_FY, string FY, string RetType, string OC)
    {
        bool IsExists = false;
        try
        {
            this.pConn();
            string strSQL = @"select * from VatasSolution.dbo.Returns_Copy where TAN=@TAN and Accountant_FY=@Accountant_FY and FY = @FY and RetType = @RetType and OC=@OC";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@TAN", TAN);
            cmd.Parameters.AddWithValue("@Accountant_FY", Accountant_FY);
            cmd.Parameters.AddWithValue("@FY", FY);
            cmd.Parameters.AddWithValue("@RetType", RetType);
            cmd.Parameters.AddWithValue("@OC", OC);
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
                IsExists = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
        return IsExists;
    }

    public bool IsJobExists(string TAN, string Accountant_FY, string FY, string RetType, string OC, string Qtr)
    {
        bool IsExists = false;
        try
        {
            this.pConn();
            string strSQL = @"select * from VatasSolution.dbo.Returns_Copy where TAN=@TAN and Accountant_FY=@Accountant_FY and FY = @FY and RetType = @RetType and OC=@OC and Quarter=@Quarter";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@TAN", TAN);
            cmd.Parameters.AddWithValue("@Accountant_FY", Accountant_FY);
            cmd.Parameters.AddWithValue("@FY", FY);
            cmd.Parameters.AddWithValue("@RetType", RetType);
            cmd.Parameters.AddWithValue("@OC", OC);
            cmd.Parameters.AddWithValue("@Quarter", Qtr);
            
            adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
                IsExists = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
        return IsExists;
    }

    public void updateTDSClient_Returns(Int64 ID, Int64 Return_Copy_Id)
    {
        try
        {
            this.pConn();
            SqlCommand cmd3 = new SqlCommand("select Dir_Path from VatasSolution.dbo.Returns_Copy where Job_ID = @Job_ID", this.SqlCon);
            cmd3.Parameters.AddWithValue("@Job_ID", Return_Copy_Id);
            string dir_path = (string)cmd3.ExecuteScalar();

            string strSQL = "update Tbl_Upload_Returns set Pay_U_Money_ID=@Pay_U_Money_ID, Payment_Recd_Amt=Payment_Due, Return_Copy_Id=@Return_Copy_Id,Date_of_Payment=@Date_of_Payment,Remarks=@Remarks,Path_of_Directory=@Path_of_Directory where ID=@ID";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@Pay_U_Money_ID", "1111");
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Return_Copy_Id", Return_Copy_Id);
            cmd.Parameters.AddWithValue("@Date_of_Payment", DateTime.Now);
            cmd.Parameters.AddWithValue("@Remarks", "Pending");
            cmd.Parameters.AddWithValue("@Path_of_Directory", dir_path);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("delete from tbl_Upload_Returns_SC where ID=@ID", this.SqlCon);
            cmd2.Parameters.AddWithValue("@ID", ID);
            cmd2.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
    }

    public void updateTDSClient_Returns_Status(Int64 ID, string Remarks)
    {
        try
        {
            this.pConn();
            string strSQL = "update Tbl_Upload_Returns set Remarks=@Remarks where ID=@ID";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
    }

    public void updateTDSClient_Returns_Status(Int64 ID, string Remarks, string RemarksDetail)
    {
        try
        {
            this.pConnTDS();
            string strSQL = "update Tbl_Upload_Returns set Remarks=@Remarks, Remarks_Detail=@Remarks_Detail where ID=@ID";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Remarks_Detail", RemarksDetail);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
    }
    public void updateTDSClient_Returns_Status(Int64 ID, string Remarks, string RemarksDetail, string amt)
    {
        try
        {
            this.pConnTDS();
            string strSQL = "update Tbl_Upload_Returns set Remarks=@Remarks, Remarks_Detail=@Remarks_Detail, payment_left=@payment_left where ID=@ID";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Remarks_Detail", RemarksDetail);
            cmd.Parameters.AddWithValue("@payment_left", Convert.ToDouble(amt));
            
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
    }

    //To Add path in StoreTrans
    public void AddPath()
    {
        bllStoreTrans objbllStoreTrans = new bllStoreTrans();
        denStoreTrans objdenStoreTrans2 = new denStoreTrans();
        objdenStoreTrans2.NameID = Convert.ToString(HttpContext.Current.Session["NameID"]);
        objdenStoreTrans2.Vtype = 15074;
        objdenStoreTrans2.MainID = Convert.ToInt32(HttpContext.Current.Session["NameID"]);
        objdenStoreTrans2.ConstID = 1523995;
        //objdenStoreTrans.SubConstID = Convert.ToInt32(ViewState["SubConstID"]);
        objdenStoreTrans2.GIndex = 14073;
        objdenStoreTrans2.Col3 = HttpContext.Current.Session["Dir_Path"].ToString();
        objdenStoreTrans2.AY = Convert.ToString(HttpContext.Current.Session["AY"]);
        objdenStoreTrans2.GRowNo = 8;
        if (HttpContext.Current.Session["Status"] != null)
            objdenStoreTrans2.AssesseeType = (HttpContext.Current.Session["Status"].ToString() != "") ? Convert.ToInt32(HttpContext.Current.Session["Status"]) : 0;
        objdenStoreTrans2.ComboItemNo = 0;
        objdenStoreTrans2.IsEnterFDet = 0;
        objdenStoreTrans2.RecdAmount = 0;
        objdenStoreTrans2.DueDate = (HttpContext.Current.Session["duedate"] == null) ? DateTime.Now.ToShortDateString() : (HttpContext.Current.Session["duedate"].ToString());
        string msg_IIF = "";
        objbllStoreTrans.InsertDataMainGrid(objdenStoreTrans2, out msg_IIF);
    }

    public void ReverseGeneral(int NameID, string AY, int ITR, int Job_ID)
    {
        try
        {
            this.pConnMain();
            cmd = new SqlCommand("Proc_General_Reverse", this.SqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nameid", NameID);
            cmd.Parameters.AddWithValue("@ay", AY);
            cmd.Parameters.AddWithValue("@itr", ITR);
            cmd.Parameters.AddWithValue("@jobid", Job_ID);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
    }

    //For 15G and 15H
    public void SaveMainData(Int64 NameID, int ITR, string AY, string TAN, string Qtr, string FY, string FilingType)
    {
        try
        {
            this.pConn();
            cmd = new SqlCommand("Proc_Save_InitialData_15G_15H", this.SqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nameid", NameID);
            cmd.Parameters.AddWithValue("@Itrtype", ITR);            
            cmd.Parameters.AddWithValue("@ay", AY);
            cmd.Parameters.AddWithValue("@TAN", TAN);

            cmd.Parameters.AddWithValue("@Quarter", Qtr);
            cmd.Parameters.AddWithValue("@FY", FY);
            cmd.Parameters.AddWithValue("@FilingType", FilingType);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
    }

    public DataTable Select_AssesseeErrors(string NameID, string AY)
    {
        DataTable dt = new DataTable();
        try
        {
            this.pConn();
            cmd = new SqlCommand("select * from tbl_AssesseeErrors where NameID = @NameID and AY=@AY", this.SqlCon);
            cmd.Parameters.AddWithValue("@NameID", NameID);
            cmd.Parameters.AddWithValue("@AY", AY);
            adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
        return dt;
    }

    public void ExportToExcel(DataSet ds)
    {
        var wb = new XLWorkbook();
        string SheetName = string.Empty;
        for (int j = 0; j < ds.Tables.Count; j++)
        {
            DataTable dt_Sheet = ds.Tables[j];
            SheetName = dt_Sheet.TableName.ToString();
            wb.Worksheets.Add(dt_Sheet, SheetName);
        }
        
        wb.SaveAs(HttpContext.Current.Server.MapPath("./abc.xlsx"));
        byte[] Content = File.ReadAllBytes(HttpContext.Current.Server.MapPath("./abc.xlsx"));
        HttpContext.Current.Response.ContentType = "text/csv";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + HttpContext.Current.Server.MapPath("./abc.xlsx") + "");
        HttpContext.Current.Response.BufferOutput = true;
        HttpContext.Current.Response.OutputStream.Write(Content, 0, Content.Length);
        HttpContext.Current.Response.End();
    }

   
}
//Common Class Ends---

public class tbl_ErrorLog
{
    public Int64 id
    {
        get;
        set;
    }

    public string ErrorMsg
    { get; set; }

    public string methodName
    { get; set; }

    public string className
    { get; set; }

    public string pageName
    { get; set; }

    public DateTime ErrDateTime
    { get; set; }

    public bool IsDone
    { get; set; }
}

public class tbl_AY: dalConnection
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con_Poolable"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter adp;

    public int id
    { get; set; }

    public string AY
    { get; set; }

    public string FY
    { get; set; }

    //tbl_ErrorLog Functions:
    public DataTable Select()
    {
        DataTable dt = new DataTable();
        try
        {
            this.pConnMain();
            string strSQL = "select * from tbl_AY order by AY desc";
            cmd = new SqlCommand(strSQL, this.SqlCon);
            adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.SqlCon.Close();
        }
        return dt;
    }
}

public class Common_Receipt
{
    //Create variable accessible through out application
    public static String TAN;
    public static String FY;
    public static String Quarter;

    public static String Path;

    //Disable Control via ETDS old Return Path
    public static bool Disabled_Controls = true;
    public Common_Receipt()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
