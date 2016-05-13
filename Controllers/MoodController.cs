using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using TeamY.Domain;
using TeamY.Infrastructure;
using TeamY.Services;

namespace TeamY.Controllers
{
    [Route("api/[controller]")]
    public class MoodController : Controller
    {
        private readonly TeamyDbContext _context;
        private readonly IUserService _userService;

        public MoodController(TeamyDbContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        public MoodRegistration GetLatestMoodRegistration()
        {
            return _context.MoodRegistrations.FirstOrDefault();
        }

        [HttpGet]
        public List<MoodRegistration> GetAllMoodRegistration()
        {
            return _context.MoodRegistrations.ToList();
        }

        [HttpGet]
        public List<MoodRegistration> GetMoodRegistrationsByDate(string from, string to)
        {
            return _context.MoodRegistrations.Where(x => x.Registered >= DateTime.Parse(from) && x.Registered >= DateTime.Parse(to)).ToList();
        }

        [HttpPost("{mood}")]
        public IActionResult Get(string mood)
        {
            var user = _userService.Current(User);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.Mood = mood;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("getmoods")]
        public IActionResult GetMoods()
        {
            return Ok(_context.Moods.ToList());
        }
    }
}