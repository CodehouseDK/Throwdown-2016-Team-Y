using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using TeamY.Domain;
using TeamY.Services;

namespace TeamY.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class CalendarController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public CalendarController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ////return Ok(_appointmentService.GetCalendarFolder());
            var appointments = _appointmentService.GetAppointments();
            return Ok(Test(appointments.Result));
        }

        private IEnumerable<CalendarItem> Test(string xml)
        {
            var entries = new List<CalendarItem>();

            var xDocument = XDocument.Parse(xml);

            var descendants = xDocument.Descendants().ToList();

            var items = descendants.Where(x => x.Name.LocalName.Equals("CalendarItem"));

            foreach (var item in items)
            {
                var subject = item.Elements().FirstOrDefault(x => x.Name.LocalName.Equals("Subject"))?.Value;

                entries.Add(new CalendarItem
                {
                    Subject = subject
                });
            }
            return entries;
        }
    }
}