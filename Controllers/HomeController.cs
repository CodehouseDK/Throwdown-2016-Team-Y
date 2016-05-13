using Microsoft.AspNet.Mvc;
using TeamY.Models;
using TeamY.Services;

namespace TeamY.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserService _nameService;
        private readonly IOctopusService _octopusService;

        public HomeController(IUserService nameService, IOctopusService octopusService)
        {
            _nameService = nameService;
            _octopusService = octopusService;
        }

        public IActionResult Index()
        {
            var model = new HomeModel(_nameService.Current(User));
            model.LatestDeployments = _octopusService.GetDeployments(5);
            return View(model);
        }
    }
}