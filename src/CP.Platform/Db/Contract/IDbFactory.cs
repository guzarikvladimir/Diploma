using System.Data.Entity;

namespace CP.Platform.Db.Contract
{
    public interface IDbFactory
    {
        DbContext Create();
    }
}