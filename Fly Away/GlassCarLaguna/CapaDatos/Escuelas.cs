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
    public class Escuelas
    {
        private Conexion conection = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader readRows;

        //ATRIBUTOS
        private string nombre;

        //PROPIEDADES
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        //CONSTRUCTORES
        public Escuelas()
        {

        }

        public Escuelas(string nombre)
        {
            this.nombre = nombre;
        }

        //MÉTODOS
        public bool InsertarEscuela()
        {
            try
            {
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "InsertarEscuela";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = conection.CloseConection();
                return true;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al insertar escuela.", "Error al insertar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable CargarEscuelas()
        {
            try
            {
                DataTable table = new DataTable();
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "CargarEscuelas";
                cmd.CommandType = CommandType.StoredProcedure;
                readRows = cmd.ExecuteReader();
                table.Load(readRows);
                readRows.Close();
                cmd.Connection = conection.CloseConection();
                return table;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al cargar escuelas.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable CargarReportes()
        {
            try
            {
                DataTable table = new DataTable();
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "CargarReportes";
                cmd.Parameters.AddWithValue("@escuela_nombre", nombre);
                cmd.CommandType = CommandType.StoredProcedure;
                readRows = cmd.ExecuteReader();
                table.Load(readRows);
                readRows.Close();
                cmd.Connection = conection.CloseConection();
                return table;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al cargar reportes.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
