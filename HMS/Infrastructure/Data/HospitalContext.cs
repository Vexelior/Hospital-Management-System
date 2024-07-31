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

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Add initializations for model creation \\
        }
    }
}
