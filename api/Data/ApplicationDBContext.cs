using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) 
        : base(dbContextOptions) 
        {
            // base() -> super()
        }
        // this registers the model with EntityFramework
        // it will handle db migrations
        // it will also create the db table for us
        // on app startup
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}