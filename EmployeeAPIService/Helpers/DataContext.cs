using EmployeeAPIService.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIService.Helpers
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "EmployeeDb");
        }

        public DbSet<Employee> Employees { get; set; } = null!;
    }
}
