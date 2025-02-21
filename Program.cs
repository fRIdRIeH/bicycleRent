using MySql.Data.MySqlClient;

namespace bicycleRent
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            const string server = "localhost";
            const string database = "bicycleRentQFW";
            const string user = "root";
            const string password = "";
            const string port = "3306";

            string connectionString = $"Server={server};Database={database};User={user};Password={password};Port={port};";

            using (MySqlConnection connection = new MySqlConnection(connectionString)) 
            {
                try
                {
                    connection.Open();
                    ApplicationConfiguration.Initialize();
                    Application.Run(new MainForm(connection));
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Произошла ошибка! Ошибка: " + ex.Message);
                }
            }
        }
    }
}