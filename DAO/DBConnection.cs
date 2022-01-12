using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DAO
{
    public class DBConnection
    {
        public DBConnection()
        {
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-GCTJS0D\SQLEXPRESS;" +
    "Initial Catalog=HR;Persist Security Info=True;User ID=sa;Password=sa";
            return conn;
        }
    }
}
