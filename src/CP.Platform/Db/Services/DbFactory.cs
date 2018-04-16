using System.Data.Entity;
using CP.Platform.Db.Contract;
using CP.Repository.Services;

namespace CP.Platform.Db.Services
{
    internal class DbFactory : IDbFactory
    {
        public DbContext Create()
        {
            return new ApplicationContext();
        }
    }
}