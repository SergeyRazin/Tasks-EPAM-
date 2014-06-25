using System;
using System.Web;

namespace WebClient
{
    public class MyModule1 : IHttpModule
    {
        //объект для подстчета времени выполнения
        System.Diagnostics.Stopwatch _sw = new System.Diagnostics.Stopwatch();

        public void Dispose()
        {
            //удалите здесь код.
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.EndRequest += context_EndRequest;
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;

            if (HttpContext.Current.Items["sw"] != null)
            {
                _sw.Stop();
                app.Context.Response.Write("время генерации страницы: " + _sw.Elapsed.Milliseconds + " миллисекунд");
            }
        }

        private void OnBeginRequest(Object source, EventArgs e)
        {
            _sw.Start();
            HttpContext.Current.Items.Add("sw", _sw);
        }
    }
}
