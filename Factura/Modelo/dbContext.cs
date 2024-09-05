using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura.Modelo
{
    internal class dbContext
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                string server = "LAPTOP-7SKAH6B6\\SQLEXPRESS";
                string database = "Farmacia_Higia_ExpoTecnica";
                SqlConnection conexion = new SqlConnection($"Server = {server}; Database = {database}; Integrated Security = true");

                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
