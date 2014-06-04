using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class CacheState2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToString("G");
            if(!IsPostBack)
                Cache.Insert("Time", time,null,DateTime.Now.AddSeconds(5),TimeSpan.Zero);

            if (Cache["Time"] == null)
            {
                Cache.Insert("Time", time, null, DateTime.Now.AddSeconds(5), TimeSpan.Zero);
            }

            Label1.Text = Cache["Time"].ToString() ?? DateTime.Now.ToString("G");

        }
    }
}