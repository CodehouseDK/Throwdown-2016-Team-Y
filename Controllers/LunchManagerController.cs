using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamY.Domain;
using TeamY.Infrastructure;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamY.Controllers
{
    public class LunchManagerController : Controller
    {
        private TeamyDbContext _dbContext;

        public LunchManagerController(TeamyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var lunches = _dbContext.Lunches.OrderByDescending(x => x.Date).Take(10);
            return View("Index", lunches);
        }

        public IActionResult Add()
        {
            var lunch = new LunchCreate();
            return View("Add", lunch);
        }

        [HttpPost]
        public IActionResult Add([Bind] LunchCreate lunchCreate)
        {
            if (string.IsNullOrEmpty(lunchCreate.Menu) && string.IsNullOrEmpty(lunchCreate.ImageSrc))
            {
                return RedirectToAction("Add", lunchCreate);
            }
            if (lunchCreate.Date <= DateTime.Today.AddYears(-1))
            {
                return RedirectToAction("Add", lunchCreate);
            }
            var lunch = new Lunch() { Date = lunchCreate.Date, Id = Guid.NewGuid(), Menu = lunchCreate.Menu, ImageSrc = lunchCreate.ImageSrc };
            _dbContext.Lunches.Add(lunch);
            return Ok(_dbContext.SaveChanges());
        }
    }
}
