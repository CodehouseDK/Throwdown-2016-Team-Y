using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using TeamY.Services;

namespace TeamY.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class CalendarController : Controller
    {
        private IAppointmentService _appointmentService;

        public CalendarController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_appointmentService.GetCalendarFolder());
            //return Ok(_appointmentService.GetAppointments());
        }
    }
}
