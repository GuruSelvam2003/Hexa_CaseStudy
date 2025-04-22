using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Financial_Management
{
    public class DBConnection
    {
        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            try
            {
                string path = "D:\\Hexaware\\dbpath\\db_props.txt";
                string connectionString = PropertyUtil.GetConnectionString(path);
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed: " + ex.Message);
            }

            return connection;
        }
    }
}
