using System;

namespace WebApplication3
{
    public partial class QueryString : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["hello"] != null)
            {
                TextBox1.Text = Request["hello"];
            }
        }
    }
}