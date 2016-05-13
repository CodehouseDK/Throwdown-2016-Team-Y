using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamY.Domain;
using TeamY.Infrastructure;
using TeamY.Models.Rest;
using TeamY.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamY.Controllers
{
    [Route("api/[controller]")]
    public class StateController : Controller
    {
        private readonly TeamyDbContext _context;
        private readonly IUserService _userService;

        public StateController(TeamyDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet]
        [Route("getlist")]
        public JsonResult GetList()
        {
            var output =_context.States.Select(_ => new StateModel
            {
                Id = _.Id,
                Name = _.Name,
                IconClass = _.IconClass
            }).ToList();
            return Json(output);
        }

        [HttpGet]
        [Route("getforuser")]
        public JsonResult GetForUser()
        {
            var userId = _userService.Current(User).Id;
            var userState = _context.UserStates.SingleOrDefault(_ => _.Current && _.UserId == userId);
            var stateId = userState?.StateId;
            var state = _context.States.SingleOrDefault(_ => _.Id == stateId);
            var output = state == null 
            ? new StateModel()
            : new StateModel
            {
                Id = state.Id,
                Name = state.Name,
                IconClass = state.IconClass
            };
            return Json(output);
        } 
        
        [HttpGet]
        [Route("getoverview")]
        public JsonResult GetOverview()
        {
            IList<UserStateOutputModel> outputList = new List<UserStateOutputModel>();

            var userStates = _context.UserStates.Where(_ => _.Current).Select(_ => new UserStateModel
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
                    User = new UserModel
                    {
                        Id = user.Id,
                        TeamId = user.TeamId,
                        Name = user.Name,
                        Initials = user.Initials
                    },
                    State = new StateModel
                    {
                        Id = state.Id,
                        Name = state.Name,
                        IconClass = state.IconClass
                    }
                });
            }
            return Json(outputList.OrderBy(_ => _.User.Name));
        }

        [HttpGet]
        [Route("getaggregate")]
        public JsonResult GetAggregate()
        {
            var output = new Collection<StateAggregateModel>();
            var states = _context.States.ToList();
            var userStates = _context.UserStates.Where(_ => _.Current).ToList();
            foreach (var state in states)
            {
                var count = userStates.Count(_ => _.StateId == state.Id);
                output.Add(new StateAggregateModel
                {
                    Id = state.Id,
                    Name = state.Name,
                    Count = count,
                    IconClass = state.IconClass
                });
            }

            return Json(output);
        }


        [HttpPost]
        [Route("set")]
        public void Set([FromBody]UserStateModel model)
        {
            var userId = _userService.Current(User).Id;
            foreach (var state in _context.UserStates.Where(_ => _.UserId == userId))
            {
                state.Current = false;
            }
            _context.UserStates.Add(new UserState
            {
                UserId = userId,
                StateId = new Guid(model.StateId),
                Set = DateTime.Now,
                Current = true
            });
            _context.SaveChanges(true);
        }
    }
}
