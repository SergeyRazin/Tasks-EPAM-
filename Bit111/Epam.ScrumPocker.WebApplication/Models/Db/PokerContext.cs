using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Epam.ScrumPocker.Domain;

namespace Epam.ScrumPocker.WebApplication.Models.Db
{
    public class PokerContext:DbContext
    {
        public DbSet<Estimate> EstimateSet { get; set; }
        public DbSet<UserStory> UserStorySet { get; set; }
        public DbSet<VotingRoom> VotingRoomSet { get; set; }
        public DbSet<User> UserSet { get; set; }
    }
}