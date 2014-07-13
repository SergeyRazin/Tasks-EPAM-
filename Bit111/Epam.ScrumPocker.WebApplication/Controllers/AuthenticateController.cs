using Epam.ScrumPocker.Domain;
using Epam.ScrumPocker.Interfaces;
using Facebook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Epam.ScrumPocker.WebApplication.Controllers
{
    public class AuthenticateController : Controller
    {
        private IUserPool _userPool;

        public AuthenticateController(IUserPool userPool)
        {
            _userPool = userPool;
        }

        public ActionResult Index()
        {
            // app settings
            string app_id = "231637920379530"; //"1562917020602277";
            string app_secret = "6949e698a8efb523d8ac21f628913f0c"; //"665853a377c69f3f64edb0f2dbc30170";

            // permissions
            string scope = "user_friends,email";

            if (Request["code"] == null)
            {
                return Redirect(string.Format(
                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    app_id, Request.Url.AbsoluteUri, scope));
            }
            else
            {               
                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                Dictionary<string, string> tokens = new Dictionary<string, string>();
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string vals = reader.ReadToEnd();
                        foreach (string token in vals.Split('&'))
                        {
                            string[] parseToken = token.Split('=');
                            tokens.Add(parseToken[0], parseToken[1]);
                        }
                    }
                }

                string accessToken = tokens["access_token"];
                var fb = new FacebookClient(accessToken);

                // get user name and id
                dynamic data = fb.Get("/me");
                string name = data.name;
                string id = data.id;

                //get email
                data = fb.Get("me?fields=email");
                string email = data.email;

                User user = _userPool.GetOrCreate(id);

                if (String.IsNullOrEmpty(email) && String.IsNullOrEmpty(user.Email))
                {
                    // TODO get email from other page
                    user.Email = "Mark_Martynov@epam.com";
                    _userPool.Save(user);
                }

                Session[SessionTags.User] = user;

                string redirectUrl = Session[SessionTags.RedirectUrl] as string;
                if (String.IsNullOrEmpty(redirectUrl))
                {
                    return Redirect("/");
                }
                else
                {
                    Session.Remove(SessionTags.RedirectUrl);
                    return Redirect(redirectUrl);
                }
            }
        }
	}
}