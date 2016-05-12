<<<<<<< ef259d2b2f57b37757416f2d60a62c337cb1f0a0
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamY.Domain;
=======
﻿using System.Linq;
using Microsoft.AspNet.Mvc;
>>>>>>> added basic mood ts
using TeamY.Infrastructure;

namespace TeamY.Controllers
{
<<<<<<< ef259d2b2f57b37757416f2d60a62c337cb1f0a0
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
=======
    [Route("api/[controller]")]
    public class MoodController : Controller
    {
        private readonly TeamyDbContext _context;

        public MoodController(TeamyDbContext context)
        {
            _context = context;
        }

        [HttpGet("{mood}")]
        public IActionResult Get(string mood)
        {
            var user = _context.Users.SingleOrDefault(x => x.Name == User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound();
            }

            return Ok(user);
        }
    }
}
>>>>>>> added basic mood ts
