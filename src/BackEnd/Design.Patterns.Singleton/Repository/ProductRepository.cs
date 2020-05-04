namespace Design.Patterns.Singleton.Repository
{
    public class ProductRepository
    {
        public string TableName { get; set; }
        public static ProductRepository _instance;
        public static readonly object _lock = new object();

        private ProductRepository(string tableName)
        {
            TableName = tableName;
        }

        public static ProductRepository GetInstance(string tableName)
        {
            if (_instance == null)
                lock (_lock)
                    _instance = new ProductRepository(tableName);

            return _instance;
        }
    }
}
