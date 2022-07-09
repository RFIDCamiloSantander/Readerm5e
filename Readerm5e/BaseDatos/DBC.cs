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
            //Original
            //SqlConnection Conn = new SqlConnection("Data source=localhost; Initial Catalog=m5eReader; User Id=sa; Password=sql987;");


            SqlConnection Conn = new SqlConnection("Data source=localhost; Initial Catalog=m5eReader; Trusted_Connection=True;");
            Conn.Open();
            return Conn;
        }
    }
}
