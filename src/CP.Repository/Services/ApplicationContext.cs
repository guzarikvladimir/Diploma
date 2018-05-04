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

        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<JobFunctionPosition> JobFunctionPositions { get; set; }

        public DbSet<JobFunctionTitle> JobFunctionTitles { get; set; }

        public DbSet<JobFunction> JobFunctions { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<SalaryPromotion> SalaryPromotions { get; set; }

        public DbSet<BonusPromotion> BonusPromotions { get; set; }

        public DbSet<CompensationPromotion> CompensationPromotions { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<LegalEntity> LegalEntities { get; set; }

        public DbSet<EmployeeToLegalEntity> EmployeeToLegalEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompensationPromotion>()
                .HasRequired(cp => cp.CreatedByEmployee)
                .WithMany(e => e.CreatedCompensationPromotions)
                .HasForeignKey(cp => cp.CreatedById);
        }
    }
}