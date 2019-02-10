using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] arrD = new string[] { "Ankush", "Rohit", "Raman", "Aman", "Amit", "Rahul", "Vivek" };
        string[] arrG = new string[] { "Bhanot", "Sharma", "Kumar", "Singh", "Tripathi", "Dhawan", "Gupta" };
        //IQueryable<string> arrConc = (from name in arrD
        //                              select name).Concat(from lname in arrG
        //                                                  select lname);

        

        var arrD1 = from d in arrD
                    where d.StartsWith("A")
                    select d.Max();

        var arrD2 = arrD.Select(s => s.StartsWith("A"));
        foreach(var w1 in arrD1)
        {
            Response.Write(w1);
        }
        foreach (var w1 in arrD2)
        {
            Response.Write(w1);
        }
        int? a = null;

        List<int> nums = new List<int> { 1, 3, 4, 6, 10, 11, 14, 15 };
        List<int> oddnum = nums.Where(s => s % 2 == 1).ToList();
        int[] arr = new int[] { 1, 2, 3, 4 };
        double avg = arr.Average();
        Array.Reverse(arr);
        //string[] arr1 = new string { "abc", "asdasdas" };
        Response.Write("LINQ Multiple OR<br>");
        var arr2 = from m in arrD
                   where m.Equals("Ankush") || m.Equals("Rohit")
                   select m;
        foreach (var r in arr2)
        {
            Response.Write(r);
        }
        var arr3 = arrD.Where(s => s.StartsWith("A") || s.Equals("Rohit"));//.Where(s => s.Equals("Rohit"));
        string res = arrD.Where(s => s.StartsWith("A") || s.Equals("Rohit")).Aggregate((c, n) => c + "," + n);
        Response.Write("<br>One Line Listing");
        Response.Write(res);
        Response.Write("<br>");

        Response.Write("Lambda Multiple OR<br>");
        foreach (var rr in arr3)
        {
            Response.Write(rr);
        }
        btnSubmit.Click += new EventHandler(btnSubmit_Click);
    }

    void btnSubmit_Click(object sender, EventArgs e)
    {
        Page.Controls.Add(new LiteralControl(@"<form id='PostForm' name='PostForm' action='https://secure.payu.in/_payment/_payment' method='POST'><input type='hidden' name='lastname' value=''><input type='hidden' name='address2' value=''><input type='hidden' name='udf5' value=''><input type='hidden' name='curl' value=''><input type='hidden' name='udf4' value=''><input type='hidden' name='txnid' value='bfcb3aaed21efae16f6c'><input type='hidden' name='furl' value='http://localhost:1340/tfs_vatas/Presentation/ECA_Details.aspx?st=fail'><input type='hidden' name='state' value='PUNJAB'><input type='hidden' name='udf2' value=''><input type='hidden' name='udf1' value=''><input type='hidden' name='zipcode' value='0'><input type='hidden' name='amount' value='1'><input type='hidden' name='email' value='ankush@vatasinfotech.com'><input type='hidden' name='city' value='Jalandhar'><input type='hidden' name='country' value='India'><input type='hidden' name='udf3' value=''><input type='hidden' name='address1' value=''><input type='hidden' name='hash' value='5713b8ca78b4871978b5d39ae5f32867d9db11099c0cf80433c2ab57f4ad7c29b382b7e7f591ebf99a904a1ccd90f5de9bd66bab79946ccfcf5124f99f34ebad'><input type='hidden' name='key' value='j0SeMe'><input type='hidden' name='pg' value=''><input type='hidden' name='surl' value='http://localhost:1340/tfs_vatas/Presentation/ECA_Details.aspx?st=pass'><input type='hidden' name='firstname' value='ankush bhanot'><input type='hidden' name='productinfo' value='ITR Registration'><input type='hidden' name='phone' value='9123456789'></form><script language='javascript'>var vPostForm = document.PostForm;vPostForm.submit();</script>"));
    }
}