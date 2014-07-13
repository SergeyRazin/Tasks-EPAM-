using Epam.ScrumPocker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ScrumPocker.Interfaces
{
    public interface INotificator
    {
        void Notify(User user, string link);
    }
}
