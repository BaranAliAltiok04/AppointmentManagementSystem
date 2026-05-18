using AppointmentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().Property(s => s.Price).HasColumnType("decimal(18,2)");
        }
    }
}