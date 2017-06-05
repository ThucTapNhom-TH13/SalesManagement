using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.DAL
{
    class DatabaseHelper
    {
        public static SqlConnection getConnection()
        {
            string connectionString = @"Data Source=BUMBLEBEE\SQLEXPRESS;Initial Catalog=SalesManagement;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
