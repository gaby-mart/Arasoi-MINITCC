using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arasoi.DatabaseManagement
{
    internal class ConnectionFactory
    {
        //This class exists to create connections to the database and remove unnecessary lines of code

        static string path = "Server=localhost;Database=arasoi;User Id=root;Password=";
        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(path);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error trying to connect to the database: " + ex.Message);
                return null;
            }
        }
    }
}
