using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamY.Domain;
using TeamY.Infrastructure;
using TeamY.Models;

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
            var lunch = new LunchModel();
            return View("Add", lunch);
        }

        [HttpPost]
        public IActionResult Add([Bind] LunchModel lunchModel)
        {
            if (string.IsNullOrEmpty(lunchModel.Menu) && string.IsNullOrEmpty(lunchModel.ImageSrc))
            {
                return RedirectToAction("Add", lunchModel);
            }
            if (lunchModel.Date <= DateTime.Today.AddYears(-1))
            {
                return RedirectToAction("Add", lunchModel);
            }
            var lunch = new Lunch() { Date = lunchModel.Date, Id = Guid.NewGuid(), Menu = lunchModel.Menu, ImageSrc = lunchModel.ImageSrc };
            _dbContext.Lunches.Add(lunch);
            return Ok(_dbContext.SaveChanges());
        }

        public IActionResult Delete(Guid id)
        {
            var lunch = _dbContext.Lunches.FirstOrDefault(x => x.Id == id);
            if (lunch == null)
            {
                return RedirectToAction("Index");
            }
            return View("Delete", lunch);
        }

        [HttpPost]
        public IActionResult Delete([Bind] Lunch lunch)
        {
            _dbContext.Lunches.Remove(lunch);
            return Ok(_dbContext.SaveChanges());
        }
    }
}
