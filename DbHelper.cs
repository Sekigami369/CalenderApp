using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace calenderApp
{
    internal class DbHelper
    {
        private string connectionString = "\"Server=localhost;Database=MyDatabase;Trusted_Connection=true;\";";

        public void ExecuteNonQuery(String query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(String query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return command.ExecuteScalar();

                }
            }
        }
    }
}
