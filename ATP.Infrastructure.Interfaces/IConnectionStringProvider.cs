namespace ATP.Infrastructure.Interfaces
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
        void SetConnectionString(string connectionString);
    }
}
