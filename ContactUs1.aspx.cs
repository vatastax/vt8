using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Query.BusinessLogic;
using Query.DataEntity;

public partial class ContactUs1 : System.Web.UI.Page
{
    string File;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Create object for BAL
        balquery objQuery = new balquery();

        //Create object of Data Entity Class
        denquery objdenquery = new denquery();
        //Assign value to variables of data entity class
        objdenquery.name = txtname.Text;
        objdenquery.email = txtemail.Text;
        objdenquery.subject = txtsubject.Text;
        objdenquery.query = txtComment.Text;
        objdenquery.Attachment = File;
        //call function of BAL Class
        try
        {

            objQuery.Insertquery(objdenquery);
            txtname.Text = "";
            txtemail.Text = "";
            txtsubject.Text = "";
            txtComment.Text = "";
            string message = "Your query has been sent successfuly";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
       
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FUpload1.HasFile)
        {
            string[] validFileTypes = { "pdf" };
            string ext = System.IO.Path.GetExtension(FUpload1.PostedFile.FileName);
            bool isValidFile = false;

            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                string message = "Please upload only PDF File.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                File = "../UserUploads/" + FUpload1.FileName;
                FUpload1.SaveAs(Server.MapPath(File));
            }


        }
        else
        {
            string message = "Please select file to be upload";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}