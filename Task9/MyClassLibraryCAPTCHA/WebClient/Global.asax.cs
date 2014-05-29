using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebClient
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            HttpContext.Current.Items.Add("sw", sw);
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Items["sw"] != null)
            {
                System.Diagnostics.Stopwatch sw = (System.Diagnostics.Stopwatch)HttpContext.Current.Items["sw"];

                sw.Stop();
                Response.Write("время генерации страницы: " + sw.Elapsed.Milliseconds + " миллисекунд");
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}