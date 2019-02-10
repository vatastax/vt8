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

public partial class Presentation_Benefecial : System.Web.UI.Page
{
    #region Variables
    bllEmployerMaster objEmployerMasterBLL;
    denEmployerMaster objEmployerMasterDEN;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        objEmployerMasterDEN = new denEmployerMaster();
        objEmployerMasterBLL = new bllEmployerMaster();

        objEmployerMasterBLL.InsertBenefeciaryDetails(objEmployerMasterDEN);

    }
}
