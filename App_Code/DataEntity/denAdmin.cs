using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for denAdmin
/// </summary>

namespace Taxation.DataEntity
{
    public class denAdmin
    {
        public denAdmin()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    public class denPath
    {
        public denPath()
        {

        }

        public int Path_ID
        {
            get;set;}

        public string Path_Name
        {get;set;}

        public string Host
        {get;set;}

        public string Path
        {get;set;}

        public string Path_Project
        {get;set;}

        public int ID_Admin
        {
            get;
            set;
        }
        public string DBName
        { get; set; }

        public string username
        { get; set; }

        public string password
        { get; set; }

 
    }

    public class tbl_UserRegistration
    {
        //Create Parameters
        public int User_Id { get; set; }
        public int User_Info_ID { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public int Module_ID { get; set; }
        public string Is_Deleted { get; set; }
        public string Can_Change_Password { get; set; }
        public string Role { get; set; }
        public string Is_Locked { get; set; }
        public int Consecutive_Attempts { get; set; }
        public int Role_ID { get; set; }
        public string Page_ID { get; set; }
        public string Page_SubModule_ID { get; set; }

        public int Super_User_Id
        { get; set; }

        public string Name
        { get; set; }

        public string Last_Name
        { get; set; }

        public string EmailID
        { get; set; }


        public string Confirm_Password
        { get; set; }

        public string Address1
        {
            get;
            set;
        }

        public string Country
        { get; set; }

        public int State
        { get; set; }

        public string City
        { get; set; }

        public int PinCode
        { get; set; }

        public string MobileNumber
        { get; set; }

        public int STDCODE
        { get; set; }

        public string Telephone
        { get; set; }

        public string OrganizationName
        { get; set; }

        public string SecurityQuestion
        { get; set; }

        public string Answer
        { get; set; }

        public string SelectPackage
        { get; set; }

        public string ActivationCode
        { get; set; }

        public string STATUS
        { get; set; }

        public string Join_Date
        { get; set; }

        public string Account_Type
        { get; set; }

        public string Is_Login_Active
        { get; set; }

        public int ID_Admin
        { get; set; }

        public Int64 AccID
        { get; set; }
    }

    public class tbl_OnlinePaymentRecd
    {
        public Int64 id
        { get; set; }

        public Int64 Payment_Id
        { get; set; }

        public decimal Amount
        { get; set; }

        public DateTime Date_of_Transaction
        { get; set; }

        public string Merchant_Transaction_Id
        { get; set; }

        public DateTime Date_of_Settlement
        { get; set; }

        public decimal Amount_Settled
        { get; set; }

        public string NEFT_UTR_Number
        { get; set; }

        public string Customer_Name
        { get; set; }

        public string Customer_Email
        { get; set; }

        public string Customer_Phone
        { get; set; }

        public string Product_Info
        { get; set; }

        public string Payment_Source
        { get; set; }

        public string payment_parts
        { get; set; }

        public string payee_info
        { get; set; }

        public decimal Service_Tax
        { get; set; }

        public decimal Commission
        { get; set; }

        public decimal NetAmount
        { get; set; }




    }
}