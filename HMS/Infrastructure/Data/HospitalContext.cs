using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<DoctorPractice> DoctorPractices { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorSpecialty>()
                        .HasKey(ds => new { ds.DoctorId, ds.SpecialtyId });

            modelBuilder.Entity<DoctorSpecialty>()
                        .HasOne(ds => ds.Doctor)
                        .WithMany(d => d.Specialties)
                        .HasForeignKey(ds => ds.DoctorId);

            modelBuilder.Entity<DoctorSpecialty>()
                        .HasOne(ds => ds.Specialty)
                        .WithMany(s => s.DoctorSpecialties)
                        .HasForeignKey(ds => ds.SpecialtyId);

            modelBuilder.Entity<DoctorPractice>()
                        .HasKey(dp => new { dp.DoctorId, dp.PracticeId });

            modelBuilder.Entity<DoctorPractice>()
                        .HasOne(dp => dp.Doctor)
                        .WithMany(d => d.Practices)
                        .HasForeignKey(dp => dp.DoctorId);

            modelBuilder.Entity<DoctorPractice>()
                        .HasOne(dp => dp.Practice)
                        .WithMany(p => p.DoctorPractices)
                        .HasForeignKey(dp => dp.PracticeId);
        }
    }
}
