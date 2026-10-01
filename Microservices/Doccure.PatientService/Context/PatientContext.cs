using Doccure.PatientService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PatientService.Context
{
    public class PatientContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-SPG6ILB4\\SQLEXPRESS;initial catalog=DoccurePatientDb;integrated security=true;");
        }

        public DbSet<Patient> Patients { get; set; }

    }
}
