using System;
using System.Web.Profile;

namespace WebApplication3
{
    public partial class ProfileState : System.Web.UI.Page
    {
        private string user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = this.requestedUser.Text ?? "Joe";
            Label1.Text = "эта страница для пользователя " + requestedUser.Text + " была показана " + GetCounter() +" раз";
        }

        protected int GetCounter()
        {
            ProfileBase profile = ProfileBase.Create(user);
            int counter = (int) (profile["counter"]);
            profile["counter"] = ++counter;
            profile.Save();
            return counter;
        }
    }
}