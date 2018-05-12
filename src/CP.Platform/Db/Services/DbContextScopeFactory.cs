using System.Data.Entity;
using CP.Platform.Db.Contract;
using CP.Repository.Services;

namespace CP.Platform.Db.Services
{
    internal class DbContextScopeFactory : IDbContextScopeFactory
    {
        public DbContext Create()
        {
            return new ApplicationContext();
        }
    }
}