using Epam.ScrumPocker.Domain;
using Epam.ScrumPocker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ScrumPocker.WebApplication
{
    public class UserPoolStub: IUserPool
    {
        private ICollection<User> _users = new LinkedList<User>();

        public Domain.User GetOrCreate(string id)
        {
            User res = (from u in _users where u.IdString == id select u).SingleOrDefault();
            if (res == null)            
            {
                res = new User() { IdString = id };
            }
            return res;
        }

        public void Save(User user)
        {
            GetOrCreate(user.IdString).Email = user.Email;
        }
    }
}