using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
using DALVatasETDS;
using BALVatasETDS;
using BALVatasETDS.User_Admin;
using BALVatasETDS.RoleManagement;
using BALVatasETDS.Assign_Role_To_User;
using System.Data.SqlClient;
using System.Configuration;
using System;
using controlgrid;
using BALVatasETDS.UserGroupManagement;
using System.Data;
using System.Text;
using BALVatasETDS.Menu;
using BALVatasETDS.User;
using System.Web.Services;

public partial class MasterPage : System.Web.UI.MasterPage
{
    int i;
    //tbl_UserGroupRegistration objtbl_UserGroupRegistration;
    //Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration;
    Bltbl_UserInfo_Mangement objBltbl_UserInfo_Mangement;
    tbl_UserInfo_Mangement objtbl_UserInfo_Mangement;

    //for integration of all logins:
    DataTable dt;
    DBtbl_Module objdbmodule;
    //Create the Object of User Group Management
    Bltbl_UserGroupRegistration objBltbl_UserGroupRegistration;
    tbl_UserGroupRegistration objtbl_UserGroupRegistration;
    //Create The Object of the Menus
    //Initialise the Object of the Menu
    Bltbl_Menu objBltbl_Menu;
    tbl_Menu objtbl_Menu;
    //Intialize the Object of the User
    Bltbl_User objBltbl_User;
    tbl_User objtbl_User;
    //Intialize the Object of Role Management Module

    Bltbl_RoleManagement objBltbl_RoleManagement;
    tbl_RoleManagement objtbl_RoleManagement;

    protected void Page_Load(object sender, EventArgs e)
    {
        
       
    }
   
}
