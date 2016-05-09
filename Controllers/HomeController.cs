using Microsoft.AspNet.Mvc;
using TeamY.Models;
using TeamY.Services;

namespace TeamY.Controllers
{
    public class HomeController : Controller
    {
        INameService _nameService;
        public HomeController(INameService nameService){
          _nameService = nameService;   
        }
        public IActionResult Index()
        {
            var model = new HomeModel(_nameService.GetName());
            return View(model);
        }

       
    }
}