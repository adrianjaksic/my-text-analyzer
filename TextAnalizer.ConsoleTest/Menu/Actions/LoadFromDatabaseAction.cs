using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TextAnalizer.ConsoleTest.Menu.Actions
{
    public class LoadFromDatabaseAction : IAppAction
    {
        public string Name => "Load from database";

        public string GetText()
        {
            Console.WriteLine("Enter database connection string:");
            var connectionString = Console.ReadLine();
            Console.WriteLine("Enter query:");
            var query = Console.ReadLine();

            var result = new DataTable();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    result.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
                }
            }

            var sb = new StringBuilder();
            foreach (DataRow row in result.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    sb.AppendLine(item.ToString());
                }                
            }
            return sb.ToString();
        }
    }
}
