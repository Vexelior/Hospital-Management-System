using Core.Entities.Appointments;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HospitalContext context) : base(context) { }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByStatusAsync(char status)
        {
            return await _context.Appointments.Where(a => a.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByTypeAsync(char type)
        {
            return await _context.Appointments.Where(a => a.Type == type).ToListAsync();
        }
    }
}
