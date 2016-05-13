
using System.Threading.Tasks;

namespace TeamY.Services
{
    public interface IAppointmentService
    {
        Task<string>  GetCalendarFolder();
        Task<string>  GetAppointments();
    }
}
