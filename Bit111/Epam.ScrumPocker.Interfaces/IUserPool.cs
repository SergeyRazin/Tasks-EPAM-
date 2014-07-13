using Epam.ScrumPocker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ScrumPocker.Interfaces
{
    public interface IUserPool
    {
        User GetOrCreate(string id);
        void Save(User user);
    }
}
