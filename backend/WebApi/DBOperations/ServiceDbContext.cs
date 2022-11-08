using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DBOperations
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        { }

        public DbSet<Service> Services { get; set; }

    }
    
}