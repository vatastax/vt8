using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using Taxation.BusinessLogic;
using GetTDSReference;
using System.Globalization;
using System.Reflection;
using controlgrid;
using System.IO;
using System.Web.Services;
using BALVatasETDS.UserGroupManagement;

public partial class testpageaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btTest_Click(object sender, EventArgs e)
    {
        hdn1.Value = "hello";
        ScriptManager1.RegisterDataItem(hdn1, "I am Hidden Field");
    }
}
