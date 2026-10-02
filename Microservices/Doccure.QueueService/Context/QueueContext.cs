using Doccure.QueueService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Doccure.QueueService.Context
{
    public class QueueContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-SPG6ILB4\\SQLEXPRESS;initial catalog=DoccureQueueDb;integrated security=true;");
        }

        public DbSet<PatientQueue> PatientQueues { get; set; }


    }
}
