using Core.Entities.Claims;
using Core.Entities.Patient;
using Core.Entities.Provider;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class HospitalContext : DbContext {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderServiceLocation> ProviderServiceLocations { get; set; }
    }
}
