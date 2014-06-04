using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ViewState : System.Web.UI.Page
    {
        private int counter;
        protected void Page_Load(object sender, EventArgs e)
        {
            counter = (int) (ViewState["counter"] ?? 0);
            ViewState["counter"] = ++counter;

            Label1.Text = "страница отображена: " + GetCounter() + " раз";
        }

        protected int GetCounter()
        {
            return counter;
        }
    }
}