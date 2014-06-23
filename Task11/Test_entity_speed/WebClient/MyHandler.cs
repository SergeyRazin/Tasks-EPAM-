using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebClient
{
    public class MyHandler:IHttpHandler,IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            Bitmap b = new Bitmap(50, 26);
            Graphics g = Graphics.FromImage(b);
            Random r = new Random();
            string ss = (r.Next(8999) + 1000).ToString();
            context.Session["scap"] = ss;

            g.DrawString(ss, new Font("Courier New", 12), Brushes.Green, new PointF(2, 2));

            context.Response.ContentType = "image/gif";
            b.Save(context.Response.OutputStream, ImageFormat.Gif);
        }
    }
}