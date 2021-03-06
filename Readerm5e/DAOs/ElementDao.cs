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
    class ElementDao
    {
        //Funcion para crear elementos.
        public static int CreateElement(Element Element)
        {
            int rsp;

            using (SqlConnection Conn = DBC.GetConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(
                    "INSERT INTO Element ( Epc, Name, Description, CreationDate, Status )" +
                    " VALUES ( '{0}', '{1}', '{2}', '{3}', '{4}' )",
                    Element.EPC, Element.Name, Element.Description, Element.CreationDate, Element.Status), Conn);

                rsp = Comando.ExecuteNonQuery();

                Conn.Close();
            }

            return rsp;
        }


        public static Element ReadElement(string epc)
        {
            using (SqlConnection Conn = DBC.GetConnection())
            {
                Element Element = new Element();

                SqlCommand Comando = new SqlCommand(string.Format("SELECT * FROM Element WHERE Epc = '{0}';", epc), Conn);

                SqlDataReader Reader = Comando.ExecuteReader();

                while (Reader.Read())
                {
                    Element.Id = Reader.GetInt32(0);
                    Element.EPC = Reader.GetString(1);
                    Element.Name = Reader.GetString(2);
                    Element.Description = Reader.GetString(3);
                    Element.CreationDate = Reader.GetString(4);
                    Element.Status = Reader.GetString(5);
                }

                Conn.Close();

                return Element;
            }
        }


        public static Element ReadElement(int id)
        {
            using (SqlConnection Conn = DBC.GetConnection())
            {
                Element Element = new Element();

                SqlCommand Comando = new SqlCommand(string.Format("SELECT * FROM Element WHERE ID = {0};", id), Conn);

                SqlDataReader Reader = Comando.ExecuteReader();

                while (Reader.Read())
                {
                    Element.Id = Reader.GetInt32(0);
                    Element.EPC = Reader.GetString(1);
                    Element.Name = Reader.GetString(2);
                    Element.Description = Reader.GetString(3);
                    Element.CreationDate = Reader.GetString(4);
                    Element.Status = Reader.GetString(5);
                }

                Conn.Close();

                return Element;
            }
        }



        public static List<Element> ReadAllElements()
        {
            List<Element> ListElements = new List<Element>();

            using (SqlConnection Conn = DBC.GetConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format("SELECT * FROM Element;"), Conn);

                SqlDataReader Reader = Comando.ExecuteReader();

                while (Reader.Read())
                {
                    Element Element = new Element();

                    Element.Id = Reader.GetInt32(0);
                    Element.EPC = Reader.GetString(1);
                    Element.Name = Reader.GetString(2);
                    Element.Description = Reader.GetString(3);
                    Element.CreationDate = Reader.GetString(4);
                    Element.Status = Reader.GetString(5);

                    ListElements.Add(Element);
                }

                Conn.Close();
            }

            return ListElements;
        }



        public static int UpdateElement(Element pElement)
        {
            using (SqlConnection Conn = DBC.GetConnection())
            {
                try
                {
                    int rsp = 0;

                    SqlCommand Comando = new SqlCommand(string.Format(
                        "UPDATE Element SET Epc = '{0}', Name = '{1}', Description = '{2}', Status = '{3}' WHERE ID = {4};",
                        pElement.EPC, pElement.Name, pElement.Description, pElement.Status, pElement.Id),
                    Conn);

                    rsp = Comando.ExecuteNonQuery();

                    Conn.Close();

                    return rsp;
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(err.Message);
                    throw;
                }
                
            }
        }
    }
}
