using System.Data.Entity;
using CP.Repository.Models;

namespace CP.Repository.Services
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    }
}