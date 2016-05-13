using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TeamY.Infrastructure;
using TeamY.Models.Rest;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamY.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly TeamyDbContext _context;

        public TeamController(TeamyDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("getall")]
        public JsonResult GetAll()
        {
            var teams = _context.Teams;
            var users = _context.Users;
            var userStates = _context.UserStates.Where(_ => _.Current);
            var states = _context.States;

            var output = new TeamOutputModel
            {
                Teams = teams.Select(team => new TeamModel
                {
                    Id = team.Id,
                    Name = team.Name,
                    Users = users.Where(_ => _.TeamId == team.Id).Select(__ =>
                        new UserModel
                        {
                            Id = __.Id,
                            TeamId = __.TeamId,
                            Name = __.Name,
                            Initials = __.Initials
                        }).ToList()
                }).ToList()
            };

            foreach (var team in output.Teams)
            {
                foreach (var user in team.Users)
                {
                    var userState = userStates.SingleOrDefault(_ => _.UserId == user.Id);
                    if (userState == null)
                    {
                        continue;
                    }
                    var state = states.Single(_ => _.Id == userState.StateId);
                    user.State = new StateModel
                    {
                        Id = state.Id,
                        Name = state.Name
                        
                    };
                }
            }

            return Json(output);
        }
    }
}

