using Design.Patterns.Bridge.Interfaces;

namespace Design.Patterns.Bridge.Repository
{
    public class RepositoryBase
    {
        protected readonly IConnectionDataBase _connectionDataBase;

        public RepositoryBase(string connectionString, IConnectionDataBase connectionDataBase)
        {
            ConnectionString = connectionString;
            _connectionDataBase = connectionDataBase;
        }

        protected string ConnectionString { get; set; }
    }
}
