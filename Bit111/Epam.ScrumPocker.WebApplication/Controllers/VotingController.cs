using Epam.ScrumPocker.Domain;
using Epam.ScrumPocker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.ScrumPocker.WebApplication.Controllers
{
    public class VotingController : Controller
    {
        private IRoomPool _roomPool;

        public VotingController(IRoomPool roomPool)
        {
            _roomPool = roomPool;
        }


        [CustomAuthenticationAttribute]
        public ActionResult Index(string id)
        {
            VotingRoom room = _roomPool.GetById(id);
            User user = Session[SessionTags.User] as User;

            if (room.Moderator.IdString == user.IdString)
            {
                return View("ModeratorPage", room);
            }

            if (room.StartTime == null)
            {
                return View("Error");
            }

            Estimate estimate = (from est in room.Estimates where est.VotedUser.IdString == user.IdString select est).FirstOrDefault();
            if (estimate != null && !String.IsNullOrEmpty(estimate.Value) || room.IsFinished)
            {
                return View("Result", room);
            }

            return View(room.UserStory);
        }

        [HttpPost]
        [CustomAuthentication]
        public ActionResult Index(string id, FormCollection form)
        {
            User user = Session[SessionTags.User] as User;
            VotingRoom room = _roomPool.GetById(id);

            string voteResult = form["model.VoteResult"];
            if (room.Estimates.FirstOrDefault(est => est.VotedUser == user) == null)
            {
                room.Estimates.Add(new Estimate() { VotedUser = user, Value = voteResult });
            }

            //Todo create Estimate voter and add it to the room estimates

            return View("Result", room);
        }


        public ActionResult Results(string id)
        {
            User user = Session[SessionTags.User] as User;
            VotingRoom room = _roomPool.GetById(id);

            return PartialView("_ResultsPartial", room.Estimates);                               
        }
	}
}