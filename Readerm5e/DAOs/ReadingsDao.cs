using Readerm5e.BaseDatos;
using Readerm5e.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerm5e.DAOs
{
    class ReadingsDao
    {
        public static List<Reading> ReadAllReadings()
        {
            List<Reading> ListReadings = new List<Reading>();

            using (SqlConnection Conn = DBC.GetConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format("SELECT * FROM Readings;"), Conn);

                SqlDataReader Reader = Comando.ExecuteReader();

                while (Reader.Read())
                {
                    Reading Reading = new Reading()
                    {
                        Id = Reader.GetInt32(0),
                        ElementoId = Reader.GetInt32(1),
                    };


                    ListReadings.Add(Reading);
                }

                Conn.Close();
            }

            return ListReadings;
        }
    }
}
