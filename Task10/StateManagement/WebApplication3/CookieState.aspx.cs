using System;
using System.Web;

namespace WebApplication3
{
    public partial class CookieState : System.Web.UI.Page
    {
        private int counter;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie incomingCookie = Request.Cookies["counter"];
            counter = incomingCookie == null ? 0 : int.Parse(incomingCookie.Value);
            counter++;
            Response.Cookies.Add(new HttpCookie("counter", counter.ToString()));

            Label1.Text = "страница отображена: " + GetCounter() + " раз";
        }

        protected int GetCounter()
        {
            return counter;
        }
    }
}