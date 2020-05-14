namespace Design.Patterns.Bridge.Interfaces
{
    public interface IConnectionDataBase
    {
        void OpenConnection(string connectionString);
        void CloseConnection();
    }
}
