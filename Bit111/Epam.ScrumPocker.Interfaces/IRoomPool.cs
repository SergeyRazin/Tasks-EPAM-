using Epam.ScrumPocker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ScrumPocker.Interfaces
{
    public interface IRoomPool
    {
        VotingRoom GetById(string id);

        void Insert(VotingRoom votingRoom);

        bool IsFinished(string id);

        void Update(VotingRoom votingRoom);
    }
}
