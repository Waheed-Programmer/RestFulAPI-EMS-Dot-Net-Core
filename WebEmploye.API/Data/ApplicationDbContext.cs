using Microsoft.EntityFrameworkCore;
using WebEmp_DLL.Entities;

namespace WebEmploye.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
