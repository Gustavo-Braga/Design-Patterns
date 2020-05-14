using Design.Patterns.Bridge.Interfaces;
using System;

namespace Design.Patterns.Bridge.Repository
{
    public class NoSqlConnection : IConnectionDataBase
    {
        public void OpenConnection(string connectionString)
        {
            Console.WriteLine($"Abre conexão com banco de dados NoSQL {connectionString}");
        }

        public void CloseConnection()
        {
            Console.WriteLine($"Fecha conexão com banco de dados NoSQL");
        }
    }
}
