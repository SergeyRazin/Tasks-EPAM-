using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.ScrumPocker.Interfaces;
using  Epam.ScrumPocker.Domain;

namespace Epam.ScrumPocker.WebApplication.Models.Db
{
    public class AccessorUserStoryPool:IUserStoryPool
    {
        private PokerContext db;
        public void Insert(UserStory userStory)
        {
            using (db = new PokerContext())
            {
                db.UserStorySet.Add(userStory);
                db.SaveChanges();
            }
        }

        public UserStory GetById(int id)
        {
            using (db = new PokerContext())
            {
                return db.UserStorySet.SingleOrDefault(e => e.Id == id);
            }
        }

        public IEnumerable<UserStory> GetAll()
        {
            using (db = new PokerContext())
            {
                return db.UserStorySet.AsEnumerable();
            }
        }
    }
}