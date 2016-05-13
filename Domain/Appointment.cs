using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Server.Kestrel.Http;
using Microsoft.Exchange.WebServices.Data;

namespace TeamY.Domain
{
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the start time of the appointment.
        /// 
        /// </summary>
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
        public bool IsAllDayEvent { get; set; }
        public string Location { get; set; }

        /// <summary>
        /// Gets a text indicating when this appointment occurs. The text returned by When is localized using the Exchange Server culture or using the culture specified in the PreferredCulture property of the ExchangeService object this appointment is bound to.
        /// 
        /// </summary>
        public string When { get; set; }

        public bool IsMeeting { get; set; }
        public bool IsCancelled { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsOnlineMeeting { get; set; }
    }
}