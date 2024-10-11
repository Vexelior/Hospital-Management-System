using Core.Entities.Appointments;

namespace Core.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByStatusAsync(char status);
        Task<IEnumerable<Appointment>> GetAppointmentsByTypeAsync(char type);
    }
}
