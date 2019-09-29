using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CSharpVendingMachine.Backend
{
    class DatabaseMethods
    {
        private static string connectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jamison\source\repos\CSharpVendingMachine\CSharpVendingMachine\Backend\VendingMachineDatabase.mdf;Integrated Security=True";

        public static List<Person> getAdmins()
        {
            string queryString = "SELECT * FROM admins;";
            List<Person> admins = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        string password = reader.GetString(2);

                        Admin admin = new Admin(id.ToString(),username,password);
                        admins.Add(admin);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            return admins;
        }

        public static List<Person> getStockers()
        {
            string queryString = "SELECT * FROM stockers;";
            List<Person> stockers = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        string password = reader.GetString(2);

                        Admin stocker = new Admin(id.ToString(), username, password);
                        stockers.Add(stocker);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            return stockers;
        }

        public static List<Item> getItems()
        {
            string queryString = "SELECT * FROM items;";
            List<Item> items = new List<Item>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string code = reader.GetString(2);
                        decimal cost = reader.GetDecimal(3);
                        string type = reader.GetString(4);
                        int quantity = reader.GetInt32(5);

                        Item item = new Item(id.ToString(), name, code, cost, type, quantity);
                        items.Add(item);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            return items;
        }
    }
}
