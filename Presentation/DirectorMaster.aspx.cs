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

public partial class Presentation_DirectorMaster : System.Web.UI.Page
{
    denEmployerMaster objEmployerMasterDEN;
    bllEmployerMaster objEmployerMasterBLL;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        objEmployerMasterDEN = new denEmployerMaster();
        objEmployerMasterBLL = new bllEmployerMaster();
        objEmployerMasterBLL.InsertDirectorDetails(objEmployerMasterDEN);
    }
}