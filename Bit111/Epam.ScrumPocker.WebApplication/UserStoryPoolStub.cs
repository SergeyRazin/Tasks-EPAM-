using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.ScrumPocker.Domain;
using Epam.ScrumPocker.Interfaces;

namespace Epam.ScrumPocker.WebApplication
{
    public class UserStoryPoolStub : IUserStoryPool
    {
        private List<UserStory> _items;

        public UserStoryPoolStub()
        {
            _items = new List<UserStory>();

            _items.Add(new UserStory()
            {
                Id = 1,
                Name = "First US",
                Description = "First US DESCRIPTION"
            });

            _items.Add(new UserStory()
            {
                Id = 2,
                Name = "Second US",
                Description = "Second US DESCRIPTION"
            });
        }

        public UserStory GetById(int id)
        {
            try
            {
                return _items[id];
            }
            catch (Exception)
            {
                return _items[0];
            }
        }

        public void Insert(UserStory userStory)
        {
            _items.Add(userStory);
        }

        public IEnumerable<UserStory> GetAll()
        {
            return _items;
        }

    }
}