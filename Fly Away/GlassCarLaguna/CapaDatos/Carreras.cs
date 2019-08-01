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
    public class Carreras
    {
        private Conexion conection = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader readRows;

        //ATRIBUTOS
        private int idEscuela;
        private string nombre, nombre_escuela;

        //PROPIEDADES
        public int IdEscuela
        {
            get { return idEscuela; }
            set { idEscuela = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Nombre_escuela
        {
            get { return nombre_escuela; }
            set { nombre_escuela = value; }
        }

        //CONSTRUCTORES
        public Carreras()
        {
            
        }

        public Carreras(int idEscuela, string nombre)
        {
            this.idEscuela = idEscuela;
            this.nombre = nombre;
        }

        //MÉTODOS
        public bool InsertarCarrera()
        {
            try
            {
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "InsertarCarrera";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEscuela", idEscuela);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = conection.CloseConection();
                return true;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al insertar carrera.", "Error al insertar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable CargarCarreras()
        {
            try
            {
                DataTable table = new DataTable();
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "CargarCarreras";
                cmd.Parameters.AddWithValue("@nombre_escuela", Nombre_escuela);
                cmd.CommandType = CommandType.StoredProcedure;
                readRows = cmd.ExecuteReader();
                table.Load(readRows);
                readRows.Close();
                cmd.Connection = conection.CloseConection();
                return table;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al cargar carreras.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
