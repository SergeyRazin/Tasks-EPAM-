using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ScrumPocker.Domain
{
    public class Estimate
    {
        public int Id { get; set; }

        public virtual User VotedUser{ get; set; }

        public string Value { get; set; }
    }
}
