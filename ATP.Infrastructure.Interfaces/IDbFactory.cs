using NPoco;

namespace ATP.Infrastructure.Interfaces
{
    public interface IDbFactory
    {
        IDatabase GetConnection();
    }
}
