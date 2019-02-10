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
public partial class Presentation_DirectorAddress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertAddress();

    }
    void InsertAddress()
    {
        try
        {
            denAddress objAddressDEN = new denAddress();
            bllAddress objAddressBLL = new bllAddress();
            objAddressDEN.Vtype = Convert.ToInt32(ViewState["vtype"]);
            objAddressDEN.NameID = Convert.ToString(Session["PAN"]);
            objAddressDEN.Flat = txtFlat.Text;
            objAddressDEN.Premises = txtPremises.Text;
            objAddressDEN.Road = txtRoad.Text;
            objAddressDEN.City = txtCity.Text;
            objAddressDEN.State = ddlStates.SelectedValue;
            objAddressDEN.PIN = txtPIN.Text;
            string stateName = ddlStates.Items[ddlStates.SelectedIndex].Text;
            objAddressDEN.Address = objAddressDEN.Flat + "," + objAddressDEN.Premises + "," + objAddressDEN.Road + "," + objAddressDEN.Area + "," + objAddressDEN.City + "," + stateName + "," + objAddressDEN.PIN;

            objAddressBLL.InsertAddress(objAddressDEN);
            txtFlat.Text = "";
            txtRoad.Text = "";
            txtCity.Text = "";
            txtPIN.Text = "";
            txtPremises.Text = "";
            txtArea.Text = "";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    
}
