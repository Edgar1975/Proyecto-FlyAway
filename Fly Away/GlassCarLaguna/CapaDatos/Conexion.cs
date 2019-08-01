using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GlassCarLaguna.CapaDatos
{
    public class Conexion
    {
        static private string stringConection = "Data Source = EDGAR-SAAVEDRA1\\SQLEXPRESS; Initial Catalog = Fly_Away; Integrated Security = True";
        private SqlConnection conection = new SqlConnection(stringConection);

        public Conexion()
        {

        }

        public SqlConnection OpenConection()
        {
            try
            {
                if (conection.State == ConnectionState.Closed)
                {
                    conection.Open();
                }
                return conection;
            }
            catch
            {
                MessageBox.Show("Error al abrir conexión con la base de datos.", "Conexión fallída", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public SqlConnection CloseConection()
        {
            try
            {
                if (conection.State == ConnectionState.Open)
                {
                    conection.Close();
                }
                return conection;
            }
            catch
            {
                MessageBox.Show("Error al cerrar conexión con la base de datos.", "Conexión fallída", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
