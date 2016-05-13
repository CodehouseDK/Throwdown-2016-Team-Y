using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamY.Domain;
using TeamY.Infrastructure;
using TeamY.Models;

namespace TeamY.Controllers
{
    public class LunchManagerController : Controller
    {
        private readonly TeamyDbContext _dbContext;

        public LunchManagerController(TeamyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Add()
        {
            var lunch = new LunchModel();
            lunch.Date = DateTime.Today;
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
            _dbContext.SaveChanges();
            return Ok();


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

        // GET: /<controller>/
        public IActionResult Index()
        {
            var lunches = _dbContext.Lunches.OrderByDescending(x => x.Date).Take(10);
            return View("Index", lunches);
        }
    }
}
