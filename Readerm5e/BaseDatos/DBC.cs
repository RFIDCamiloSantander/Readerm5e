using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerm5e.BaseDatos
{
    internal class DBC
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection Conn = new SqlConnection("Data source=localhost; Initial Catalog=CSTest; User Id=sa; Password=sql987;");
            Conn.Open();
            return Conn;
        }
    }
}
