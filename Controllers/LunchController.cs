using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamY.Domain;
using TeamY.Infrastructure;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamY.Controllers
{
    [Route("api/[controller]")]
    public class LunchController : Controller
    {
        private readonly TeamyDbContext _dbContext;

        public LunchController(TeamyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/values
        [HttpGet]
        public Lunch Get()
        {
            return _dbContext.Lunches.FirstOrDefault(x => x.Date == DateTime.Today);
        }
        [HttpGet("{date}")]
        public Lunch Get(string date)
        {
            return _dbContext.Lunches.FirstOrDefault(x => x.Date == DateTime.Parse(date));
        }
    }
}
