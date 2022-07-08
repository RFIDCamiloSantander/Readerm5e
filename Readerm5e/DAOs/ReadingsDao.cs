using Readerm5e.BaseDatos;
using Readerm5e.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Readerm5e.DAOs
{
    class ReadingsDao
    {
        public static List<Reading> ReadAllReadings()
        {
            List<Reading> ListReadings = new List<Reading>();

            using (SqlConnection Conn = DBC.GetConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(
                    "SELECT Reading.TimeStamp, Element.Name, Reading.ElementoId, Element.Description FROM Reading INNER JOIN Element ON Reading.ElementoId=Element.Id"
                    ), Conn);

                SqlDataReader Reader = Comando.ExecuteReader();

                //System.Diagnostics.Debug.WriteLine("el JSon completo" + JsonConvert.SerializeObject(Reader));


                while (Reader.Read())
                {
                    System.Diagnostics.Debug.WriteLine("el JSon Dentro del reader: " + Reader.GetString(0) );
                    System.Diagnostics.Debug.WriteLine("el JSon Dentro del reader: " + Reader.GetString(1) );
                    Reading Reading = new Reading()
                    {
                        //Id = Reader.GetInt32(0),
                        ElementoId = Reader.GetInt32(2),
                        ElementoName = Reader.GetString(1),
                        TimeStamp = long.Parse(Reader.GetString(0)),
                        ElementoDescription = Reader.GetString(3),
                    };


                    ListReadings.Add(Reading);
                }

                Conn.Close();
            }

            return ListReadings;
        }


        public static int CreateReading(Reading Reading)
        {
            int rsp;

            using (SqlConnection Conn = DBC.GetConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(
                    "INSERT INTO Reading (ElementoId, TimeStamp)" +
                    " VALUES ( '{0}', '{1}' )",
                    Reading.ElementoId, Reading.TimeStamp ), Conn);

                rsp = Comando.ExecuteNonQuery();

                Conn.Close();
            }

            return rsp;
        }
    }
}
