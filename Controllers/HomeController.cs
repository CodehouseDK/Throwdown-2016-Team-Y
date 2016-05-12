using Microsoft.AspNet.Mvc;
using TeamY.Models;
using TeamY.Services;

namespace TeamY.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserService _nameService;

        public HomeController(IUserService nameService)
        {
            _nameService = nameService;
        }

        public IActionResult Index()
        {
            var model = new HomeModel(_nameService.Current(User));
            return View(model);
        }
    }
}