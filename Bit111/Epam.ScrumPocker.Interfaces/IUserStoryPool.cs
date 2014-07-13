using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ScrumPocker.Domain;

namespace Epam.ScrumPocker.Interfaces
{
    public interface IUserStoryPool
    {
        void Insert(UserStory userStory);

        UserStory GetById(int id);

        IEnumerable<UserStory> GetAll();
    }
}
