using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public partial class Presentation_GenerateCaptcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        int height = 30;
        int width = 100;
        Bitmap bmp = new Bitmap(width, height);

        RectangleF rectf = new RectangleF(10, 0, 0, 0);

        Graphics g = Graphics.FromImage(bmp);
        g.Clear(Color.White);
        g.SmoothingMode = SmoothingMode.HighSpeed;
        g.InterpolationMode = InterpolationMode.Low;
        g.PixelOffsetMode = PixelOffsetMode.Half;
        g.DrawString(Session["captcha"].ToString(), new Font("Courier", 15, FontStyle.Italic), Brushes.CadetBlue, rectf);
        //g.DrawRectangle(new Pen(Color.Red), 1, 1, width - 2, height - 2);
        g.Flush();
        Response.ContentType = "image/jpeg";
        bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
        g.Dispose();
        bmp.Dispose();
    }
}