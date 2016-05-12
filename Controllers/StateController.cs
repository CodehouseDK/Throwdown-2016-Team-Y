using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamY.Domain;
using TeamY.Infrastructure;
using TeamY.Models.Rest;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamY.Controllers
{
    [Route("api/[controller]")]
    public class StateController : Controller
    {
        private readonly TeamyDbContext _context;

        public StateController(TeamyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getall")]
        public JsonResult GetAll()
        {
            IList<UserStateOutputModel> outputList = new List<UserStateOutputModel>();

            var userStates = _context.UserStates.Where(_ => _.Current).Select(_ => new UserStateInputModel
            {
                UserId = _.UserId.ToString(),
                StateId = _.StateId.ToString()
            }).ToList();
            
            foreach (var item in userStates)
            {
                var user = _context.Users.Single(_ => _.Id.ToString() == item.UserId);
                var state = _context.States.Single(_ => _.Id.ToString() == item.StateId);
                outputList.Add(new UserStateOutputModel
                {
                    User = new User
                    {
                        Id = user.Id,
                        TeamId = user.TeamId,
                        Name = user.Name,
                        Initials = user.Initials
                    },
                    State = new State
                    {
                        Id = state.Id,
                        Name = state.Name
                    }
                });
            }
            return Json(outputList.OrderBy(_ => _.User.Name));
        }

        [HttpPost]
        [Route("set")]
        public void Set([FromBody]UserStateInputModel model)
        {
            foreach (var state in _context.UserStates.Where(_ => _.UserId == new Guid(model.UserId)))
            {
                state.Current = false;
            }
            _context.UserStates.Add(new UserState
            {
                UserId = new Guid(model.UserId),
                StateId = new Guid(model.StateId),
                Set = DateTime.Now,
                Current = true
            });
            _context.SaveChanges(true);
        }
    }
}
