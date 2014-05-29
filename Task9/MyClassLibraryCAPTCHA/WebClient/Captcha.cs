using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace WebClient
{
    public class Сaptcha
    {
        public void CreateCaptcha(HttpContext context)
        {
            Bitmap b = new Bitmap(50, 26);
            Graphics g = Graphics.FromImage(b);
            Random r = new Random();
            string ss = (r.Next(8999) + 1000).ToString();
            context.Session["scap"] = ss;

            g.DrawString(ss, new Font("Courier New", 12), Brushes.Green, new PointF(2, 2));


            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace(@"file:\", "").Replace(@"bin", "Images");
            b.Save(path + @"\111.png", ImageFormat.Jpeg);
        }


    }
}
