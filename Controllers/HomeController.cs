using Microsoft.AspNet.Mvc;
using TeamY.Infrastructure;
using TeamY.Models;
using TeamY.Services;

namespace TeamY.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserService _nameService;
        private readonly TeamyDbContext _teamyDbContext;

        public HomeController(IUserService nameService, TeamyDbContext teamyDbContext)
        {
            _nameService = nameService;
            _teamyDbContext = teamyDbContext;
        }

        public IActionResult Index()
        {
            var model = new HomeModel(_nameService.Current(User));
            var test = _teamyDbContext.Database.EnsureCreated();
            return View(model);
        }
    }
}