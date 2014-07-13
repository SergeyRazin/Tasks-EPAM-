using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epam.ScrumPocker.Domain;
using Epam.ScrumPocker.WebApplication.Models.Db;

namespace Epam.ScrumPocker.WebApplication.Controllers
{
    public class OfficeController : Controller
    {

        public ActionResult Index(string id)
        {
            //получить все комнаты пользователя с индексом id
            UserStory story = new UserStory();
            story.Name = "testnameInic";
            story.Description = "testDescInic";
            

            PokerContext db;
            using (db=new PokerContext() )
            {
                 db.UserStorySet.Add(story);
                 db.SaveChanges();
            }
            return View();
        }
	}
}