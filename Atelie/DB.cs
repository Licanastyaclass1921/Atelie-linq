using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace Atelie
{
    public class DB
    {
      static string connectionString = ConfigurationManager.ConnectionStrings["Atelie.Properties.Settings.AtelieConnectionString"].ConnectionString;
        SqlConnection connect = new
            SqlConnection(connectionString);
        public void ConnectOpen()
        {
            connect.Open();
        }
        public SqlConnection GetConnect()
        {
            return connect;
        }
        public string getString()
        {
            return connectionString;
        }

    }
}
