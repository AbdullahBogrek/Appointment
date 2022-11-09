using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DBOperations
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        { }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Staff> Staffs { get; set; }

    }
    
}
