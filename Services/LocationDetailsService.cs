using System;
using System.Collections.Generic;
using System.Linq;
using TeamY.Infrastructure;
using TeamY.Models.Rest;

namespace TeamY.Services
{
    public class LocationDetailsService : ILocationDetailsService
    {
        private readonly TeamyDbContext _dbContext;

        public LocationDetailsService(TeamyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<LocationDetailsModel> GetLocationDetails()
        {
            var teams = _dbContext.Teams.ToList();
            var users = _dbContext.Users.ToList();
            var userStates = _dbContext.UserStates.Where(_ => _.Current).ToList();
            var states = _dbContext.States.ToList();

            var locations = new List<LocationDetailsModel>();

            foreach (var team in teams)
            {
                foreach (var user in users.Where(x => x.TeamId == team.Id))
                {
                    var userState = userStates.FirstOrDefault(x => x.UserId == user.Id && x.Current)?.StateId ?? Guid.Parse("2DCDA41E-765C-4B0E-A890-15F7553823E2");
                    var currentState = states.FirstOrDefault(s => s.Id == userState);
                    var location = new LocationDetailsModel
                    {
                        Team = team.Name,
                        User = user.Name,
                        UserImage = $"/images/employees/{user.Initials}.jpg",
                        Mood = user.Mood ?? "happy",
                        State = currentState.Name,
                        StateClass = currentState.IconClass
                    };
                    locations.Add(location);
                }
            }
            return locations;
        }
    }
}
