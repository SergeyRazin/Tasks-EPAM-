using Epam.ScrumPocker.Domain;
using Epam.ScrumPocker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ScrumPocker.WebApplication
{
    public class VotingRoomPoolStub: IRoomPool
    {
        private List<VotingRoom> _arr;

        public VotingRoomPoolStub()
        {
            _arr = new[]{
                new VotingRoom()
                {
                    Moderator = new User(){IdString = "1",Email = "test@mail.ru"},

                    IdString = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                            .Substring(0, 22)
                            .Replace("/", "_")
                            .Replace("+", "-"),
                    UserStory = new UserStory()
                    {
                        Id = 1,
                        Name = "testname1",
                        Description = "testDescription1"
                    },
                    Estimates = new List<Estimate>(){
                        new Estimate(){Id=1,  Value = "1", VotedUser = new User(){IdString = "6",Email = "hello@mail.ru"}},
                        new Estimate(){Id=2,  Value = "2", VotedUser = new User(){IdString = "8",Email = "Mark@epam.com"}},
                        new Estimate(){Id=3,  Value = "3", VotedUser = new User(){IdString = "3",Email = "Alex@mail.ru"}},
                        new Estimate(){Id=4,  Value = "4", VotedUser = new User(){IdString = "4",Email = "IvanIvanov@inbox.ru"}},
                        new Estimate(){Id=5,  Value = "5", VotedUser = new User(){IdString = "5",Email = "Tombov@gmail.com"}}
                    }
                },
                new VotingRoom()
                {
                    Moderator = new User(){IdString = "2",Email = "Pipkin@Epam.com"},

                    IdString = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                            .Substring(0, 22)
                            .Replace("/", "_")
                            .Replace("+", "-"),
                    UserStory = new UserStory()
                    {
                        Id = 2,
                        Name = "testname2",
                        Description = "testDescription2"
                    },
                    Estimates = new List<Estimate>(){
                        new Estimate(){Id=1,  Value = "1", VotedUser = new User(){IdString = "6",Email = "hello@mail.ru"}},
                        new Estimate(){Id=2,  Value = "2", VotedUser = new User(){IdString = "7",Email = "Mark@epam.com"}},
                        new Estimate(){Id=3,  Value = "3", VotedUser = new User(){IdString = "3",Email = "Alex@mail.ru"}},
                        new Estimate(){Id=4,  Value = "4", VotedUser = new User(){IdString = "4",Email = "IvanIvanov@inbox.ru"}},
                        new Estimate(){Id=5,  Value = "5", VotedUser = new User(){IdString = "5",Email = "Tombov@gmail.com"}}
                    }
                }
            }.ToList();
        }
        public VotingRoom GetById(string id)
        {
            return (from room in _arr
                    where room.IdString == id
                    select room).SingleOrDefault();   
        }

        public void Insert(VotingRoom votingRoom)
        {
            _arr.Add(votingRoom);
        }


        public bool IsFinished(string id)
        {
            return _arr.Where(e => e.IdString == id).Select(e => e.IsFinished).SingleOrDefault();
        }

        public void Update(VotingRoom votingRoom)
        {
            for (var i = 0; i < _arr.Count; i++)
                if (_arr[i].IdString == votingRoom.IdString)
                    _arr[i] = votingRoom;
        }

        public List<VotingRoom> GetAllVotingRooms()
        {
            return _arr;
        } 
    }
}