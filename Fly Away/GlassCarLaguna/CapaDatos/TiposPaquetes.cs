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
    public class TiposPaquetes
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
        public TiposPaquetes()
        {

        }

        public TiposPaquetes(string nombre)
        {
            this.nombre = nombre;
        }

        //MÉTODOS
        public bool InsertarTipoPaquete()
        {
            try
            {
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "InsertarTipoPaquete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = conection.CloseConection();
                return true;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al insertar tipo de paquete.", "Error al insertar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable CargarTiposPaquetes()
        {
            try
            {
                DataTable table = new DataTable();
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "CargarTiposPaquetes";
                cmd.CommandType = CommandType.StoredProcedure;
                readRows = cmd.ExecuteReader();
                table.Load(readRows);
                readRows.Close();
                cmd.Connection = conection.CloseConection();
                return table;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al cargar tipos de paquetes.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
