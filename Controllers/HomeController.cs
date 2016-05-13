using Microsoft.AspNet.Mvc;
using TeamY.Models;
using TeamY.Services;

namespace TeamY.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserService _nameService;
        readonly IOctopusService _octopusService;
        readonly ILocationDetailsService _locationDetailsService;

        public HomeController(IUserService nameService, IOctopusService octopusService, ILocationDetailsService locationDetailsService)
        {
            _nameService = nameService;
            _octopusService = octopusService;
            _locationDetailsService = locationDetailsService;
        }

        public IActionResult Index()
        {
            var model = new HomeModel(_nameService.Current(User))
            {
                LatestDeployments = _octopusService.GetDeployments(5),
                LocationDetails = _locationDetailsService.GetLocationDetails()
            };
            return View(model);
        }

        public IActionResult LocationDetails()
        {
            return View("LocationDetails", _locationDetailsService.GetLocationDetails());
        }
    }
}