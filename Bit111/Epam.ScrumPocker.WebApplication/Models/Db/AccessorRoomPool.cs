using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.ScrumPocker.Interfaces;
using Epam.ScrumPocker.Domain;

namespace Epam.ScrumPocker.WebApplication.Models.Db
{
    public class AccessorRoomPool:IRoomPool
    {
        private PokerContext db;

        public VotingRoom GetById(string id)
        {
            using (db=new PokerContext())
            {
                return db.VotingRoomSet.SingleOrDefault(e => e.IdString == id);
            }
        }

        public void Insert(VotingRoom votingRoom)
        {
            using (db=new PokerContext())
            {
                db.VotingRoomSet.Add(votingRoom);
                db.SaveChanges();
            }
            
        }


        public bool IsFinished(string id)
        {
            using (db=new PokerContext())
            {
               return db.VotingRoomSet.Where(e => e.IdString == id).Select(e => e.IsFinished).SingleOrDefault(); 
            }
           
        }


        public void Update(VotingRoom votingRoom)
        {
            throw new NotImplementedException();
        }
    }
}