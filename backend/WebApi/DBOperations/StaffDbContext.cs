using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DBOperations
{
    public class StaffDbContext : DbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options)
        { }

        public DbSet<Staff> Staffs { get; set; }

    }
    
}