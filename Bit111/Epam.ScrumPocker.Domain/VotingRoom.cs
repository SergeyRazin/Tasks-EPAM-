using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ScrumPocker.Domain
{
    public class VotingRoom
    {
        public int Id { get; set; }
        public string IdString { get; set; }

        public UserStory UserStory { get; set; }

        public virtual ICollection<Estimate> Estimates { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? FinishTime { get; set; }

        public virtual User Moderator { get; set; }

        public bool IsFinished { get; set; }

        public VotingRoom()
        {
            Estimates = new List<Estimate>();
        }
    }
}
