namespace Design.Patterns.Bridge.Repository
{
    public class RepositoryBase
    {
        public RepositoryBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected string ConnectionString { get; set; }
    }
}
