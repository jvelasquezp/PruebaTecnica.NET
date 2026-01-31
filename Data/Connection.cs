using System.Data.SqlClient;

namespace App2.Data
{
    public class Connection
    {
        private string _connectionString = string.Empty;

        public Connection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            _connectionString = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public string getConnectionString()
        {
            return _connectionString;                                      
        }
    }
}
