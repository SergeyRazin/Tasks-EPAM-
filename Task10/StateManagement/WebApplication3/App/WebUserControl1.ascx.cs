using System;

namespace WebApplication3.App
{
    [Serializable]
    public class Counter
    {
        public int count;
    }

    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        private int value;
        Counter counter = new Counter();

        protected void Init(object sender, EventArgs e)
        {
            Page.RegisterRequiresControlState(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                counter.count++;
                this.value = counter.count;
                Label1.Text = value.ToString();
            }
        }

        protected override object SaveControlState()
        {
            return new Counter() {count = value};
            
        }

        protected override void LoadControlState(object savedState)
        {
            Counter c = savedState as Counter;
            this.counter = c;
            if (c != null)
            {
                value = c.count;
            }
        }
        
    }
}