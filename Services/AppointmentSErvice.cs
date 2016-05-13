using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeamY.Services
{
    public class AppointmentService : IAppointmentService
    {
        private HttpClient _exchangeService;

        public AppointmentService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential("user", "pass");
            _exchangeService = new HttpClient(handler);
            _exchangeService.BaseAddress = new Uri("https://mail.codehouse.com/ews/exchange.asmx");
        }


        public async Task<string>  GetCalendarFolder()
        {

            string getFolderSoap = "<?xml version=\"1.0\" encoding=\"utf-8\"?> <soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:t=\"http://schemas.microsoft.com/exchange/services/2006/types\"> <soap:Body> <GetFolder xmlns=\"http://schemas.microsoft.com/exchange/services/2006/messages\" xmlns:t=\"http://schemas.microsoft.com/exchange/services/2006/types\"> <FolderShape> <t:BaseShape>Default</t:BaseShape> </FolderShape> <FolderIds> <t:DistinguishedFolderId Id=\"calendar\"/> </FolderIds> </GetFolder> </soap:Body> </soap:Envelope>";
            var content = new StringContent(getFolderSoap, Encoding.UTF8, "text/xml");
            using (var response = await _exchangeService.PostAsync(_exchangeService.BaseAddress, content))
            {
                var calendarResponse = await response.Content.ReadAsStringAsync();
                return calendarResponse;
            }
        }

        public async Task<string>  GetAppointments()
        {
            string folderId = "AQARAHBzd0Bjb2RlaG91c2UuY29tAC4AAANtOpXZ/vVgTKR1/RkV1k6kAQD1CZls5EzDTKA+O1yVOugUAAABdJCcAAAA";
            string changeKey = "AgAAABYAAAByZXul6BIVRKtETaVoecENAAINfOFT";
            string from = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            string to = DateTime.Now.AddDays(5).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            int entries = 5;

            string getAppointmentsSoap = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?> <soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:m=\"http://schemas.microsoft.com/exchange/services/2006/messages\" xmlns:t=\"http://schemas.microsoft.com/exchange/services/2006/types\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Header> </soap:Header> <soap:Body> <m:FindItem Traversal=\"Shallow\"> <m:ItemShape> <t:BaseShape>IdOnly</t:BaseShape> <t:AdditionalProperties> <t:FieldURI FieldURI=\"item:Subject\" /> <t:FieldURI FieldURI=\"calendar:Start\" /> <t:FieldURI FieldURI=\"calendar:End\" /> </t:AdditionalProperties> </m:ItemShape> <m:CalendarView MaxEntriesReturned=\"{0}\" StartDate=\"{1}\" EndDate=\"{2}\" /> <m:ParentFolderIds> <t:FolderId Id=\"{3}\" ChangeKey=\"{4}\" /> </m:ParentFolderIds> </m:FindItem> </soap:Body> </soap:Envelope> ", entries, from, to,  folderId, changeKey);
            var content = new StringContent(getAppointmentsSoap, Encoding.UTF8, "text/xml");
            using (var response = await _exchangeService.PostAsync(_exchangeService.BaseAddress, content))
            {
                var calendarResponse = await response.Content.ReadAsStringAsync();
                return calendarResponse;
            }
        }
    }
} 