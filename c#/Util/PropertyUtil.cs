using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Management
{
    public class PropertyUtil
    {
        public static string GetConnectionString(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);


                string server = lines[0].Trim();
                string database = lines[1].Trim();

                return $"Server={server};Database={database};Integrated Security=True;TrustServerCertificate=True;";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading property file: " + ex.Message);
                return null;
            }
        }
    }
}
