using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamY.Domain;
using TeamY.Infrastructure;

namespace TeamY.Controllers
{
    public class MoodController
    {
        private TeamyDbContext _dbContext;

        public MoodController(TeamyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public MoodRegistration GetLatestMoodRegistration()
        {
            return _dbContext.MoodRegistrations.FirstOrDefault();
        }

        [HttpGet]
        public List<MoodRegistration> GetAllMoodRegistration()
        {
            return _dbContext.MoodRegistrations.ToList();
        }
        
        [HttpGet]
        public List<MoodRegistration> GetMoodRegistrationsByDate(string from, string to)
        {
            return _dbContext.MoodRegistrations.Where(x => x.Registered >= DateTime.Parse(from) && x.Registered >= DateTime.Parse(to)).ToList();
        }




    }
}
