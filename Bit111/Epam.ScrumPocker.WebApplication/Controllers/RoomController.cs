using Epam.ScrumPocker.Domain;
using Epam.ScrumPocker.WebApplication;
using Epam.ScrumPocker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace Epam.ScrumPocker.WebApplication.Controllers
{
    public class RoomController : Controller
    {
        private IRoomPool _roomPool;
        private INotificator _notificator;

        public RoomController(IRoomPool roomPool, INotificator notificator)
        {
            _roomPool = roomPool;
            _notificator = notificator;
        }


        [CustomAuthentication]
        public ActionResult Create()
        {                       
            return View();
        }

        [HttpPost]
        [CustomAuthentication]
        public ActionResult Create(UserStory userStory)
        {
            User user = Session[SessionTags.User] as User;
            VotingRoom room = new VotingRoom();
            room.IdString = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                            .Substring(0, 9)
                            .Replace("/", "_")
                            .Replace("+", "-");

            room.UserStory = new UserStory()
            {
                Name = userStory.Name,
                Description = userStory.Description
            };

            room.Moderator = user;

            _roomPool.Insert(room);

            return Json(new { id = room.IdString });
        }

        [HttpPost]
        [CustomAuthentication]
        public void StartEstimating(string id)
        {
            var room = _roomPool.GetById(id);

            //ThreadPool.QueueUserWorkItem((o) =>
            //{
            //    foreach (var estimate in room.Estimates)
            //    {
            //        _notificator.Notify(estimate.VotedUser, Request.UrlReferrer.Authority + "/" + votingRoom.Id);
            //    }
            //});

            room.StartTime = DateTime.Now;
            _roomPool.Update(room);
        }

        [HttpPost]
        [CustomAuthentication]
        public void StopEstimating(string id)
        {
            var room = _roomPool.GetById(id);

            //ThreadPool.QueueUserWorkItem((o) =>
            //{
            //    foreach (var estimate in room.Estimates)
            //    {
            //        _notificator.Notify(estimate.VotedUser, Request.UrlReferrer.Authority + "/" + votingRoom.Id);
            //    }
            //});

            room.FinishTime = DateTime.Now;
            room.IsFinished = true;
            _roomPool.Update(room);

            //Redirect on results page
        }
    }
}