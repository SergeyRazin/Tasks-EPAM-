using System;
using System.Text;

namespace WebApplication3
{
    public partial class HiddenFields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //переводим строку в байты
            byte[] sourceBytes = UTF8Encoding.UTF8.GetBytes(TextBox1.Text);
            //кодируем в BASE64
            TextBox2.Text = Convert.ToBase64String(sourceBytes);
            TextBox1.Text = TextBox2.Text;
            


        }
    }
}