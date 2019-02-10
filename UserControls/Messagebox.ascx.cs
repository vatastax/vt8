using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_Messagebox : System.Web.UI.UserControl
{
    #region Declarations
    public event EventHandler btn_ok_click;
    public event EventHandler btn_Cancel_click;
    public event EventHandler btn_Other_click;
    public string message { get; set; }

    public string OkButtonText { get; set; }
    public string CancelButtonText { get; set; }
    public string OtherButtonText { get; set; }
    public enum SelectButtons
    {
        One, Two, Three
    }
    public SelectButtons SelectNoButtons { get; set; }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SelectNoButtons==SelectButtons.One)
        {
            btn_Ok.Visible = true;
        }
        else if (SelectNoButtons==SelectButtons.Two)
        {
            btn_Ok.Visible = true;
            btn_Cancel.Visible = true;
        }
        else if (SelectNoButtons == SelectButtons.Three)
        {
            btn_Ok.Visible = true;
            btn_Cancel.Visible = true;
            btn_Other.Visible = true;
        }

        btn_Ok.Text = OkButtonText;
        btn_Cancel.Text = CancelButtonText;
        btn_Other.Text = OtherButtonText;
        pnl_msg.Attributes.Remove("style");
        lbl_msg.Text = message;
        
        
            mdl_popmsg.Show();
     

    }
    //Click Event of Ok Button
    protected void btn_Ok_Click(object sender, EventArgs e)
    {
        pnl_msg.Attributes.Add("style", "display:none"); 
        mdl_popmsg.Hide();
        btn_ok_click(sender, e);
     

    }

    //Click Event of Cancel Button
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        pnl_msg.Attributes.Add("style", "display:none"); 
        mdl_popmsg.Hide();
        btn_Cancel_click(sender, e);
        
    }

    //Click Event of Other Button
    protected void btn_Other_Click(object sender, EventArgs e)
    {
        pnl_msg.Attributes.Add("style", "display:none"); 
        mdl_popmsg.Hide();
        btn_Other_click(sender, e);
        
    }
}