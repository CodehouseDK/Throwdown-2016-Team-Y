using System;
using System.Net;
using System.Net.Http;

namespace TeamY.Services
{
    public class AppointmentService : IAppointmentService
    {
        private HttpClient _exchangeService;

        public AppointmentService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential("user", "password");
            _exchangeService = new HttpClient(handler);
            _exchangeService.BaseAddress = new Uri("https://mail.codehouse.com/ews/exchange.asmx");
        }
    }
}
