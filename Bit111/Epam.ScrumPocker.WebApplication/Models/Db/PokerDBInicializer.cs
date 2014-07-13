using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Epam.ScrumPocker.Domain;

namespace Epam.ScrumPocker.WebApplication.Models.Db
{
    public class PokerDBInicializer : DropCreateDatabaseAlways<PokerContext>
    {

        public List<Estimate> GetListEstimates()
        {
             List<Estimate> listEstimates = new List<Estimate>()
                                               {
                                                   new Estimate()
                                                   {
                                                       Id = 1,
                                                       Value = "1",
                                                       VotedUser =
                                                           new User()
                                                           {
                                                               IdString = "1",
                                                               Email = "hello1@mail.ru"
                                                           }
                                                   },
                                                   new Estimate()
                                                   {
                                                       Id = 2,
                                                       Value = "3",
                                                       VotedUser =
                                                           new User()
                                                           {
                                                               IdString = "2",
                                                               Email = "hello2@mail.ru"
                                                           }
                                                   },
                                                   new Estimate()
                                                   {
                                                       Id = 3,
                                                       Value = "3",
                                                       VotedUser =
                                                           new User()
                                                           {
                                                               IdString = "3",
                                                               Email = "hello3@mail.ru"
                                                           }
                                                   },
                                                   new Estimate()
                                                   {
                                                       Id = 4,
                                                       Value = "4",
                                                       VotedUser =
                                                           new User()
                                                           {
                                                               IdString = "4",
                                                               Email = "hello4@mail.ru"
                                                           }
                                                   },
                                                   new Estimate()
                                                   {
                                                       Id = 5,
                                                       Value = "5",
                                                       VotedUser =
                                                           new User()
                                                           {
                                                               IdString = "5",
                                                               Email = "hello5@mail.ru"
                                                           }
                                                   }
                                               };
            return listEstimates;
        } 
        
        protected override void Seed(PokerContext context)
        {
            base.Seed(context);

            context.VotingRoomSet.Add(new VotingRoom() { Id = 1, Estimates = GetListEstimates(), IsFinished = false, Moderator = new User() { Id = 1, Email = "1@mail" }, UserStory = new UserStory() { Id = 1, Description = "descr1...", Name = "UserStoryName1" } });
            context.VotingRoomSet.Add(new VotingRoom() { Id = 2, Estimates = GetListEstimates(), IsFinished = false, Moderator = new User() { Id = 2, Email = "2@mail" }, UserStory = new UserStory() { Id = 2, Description = "descr2...", Name = "UserStoryName2" } });

        }
    }
}