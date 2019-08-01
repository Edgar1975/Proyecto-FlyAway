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
    public class Paquetes
    {
        private Conexion conection = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader readRows;

        //ATRIBUTOS
        private int idTipoPaquete, idPaquete, num_camion, personas_habitacion;
        private double precio;
        private string destino, hotel;

        //PROPIEDADES
        public int IdTipoPaquete
        {
            get { return idTipoPaquete; }
            set { idTipoPaquete = value; }
        }

        public int IdPaquete
        {
            get { return idPaquete; }
            set { idPaquete = value; }
        }

        public int Num_camion
        {
            get { return num_camion; }
            set { num_camion = value; }
        }

        public int Personas_habitacion
        {
            get { return personas_habitacion; }
            set { personas_habitacion = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        public string Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }

        //CONSTRUCTORES
        public Paquetes()
        {

        }

        public Paquetes(int idTipoPaquete,
            string destino,
            int num_camion,
            string hotel,
            int personas_habitacion,
            double precio)
        {
            this.idTipoPaquete = idTipoPaquete;
            this.destino = destino;
            this.num_camion = num_camion;
            this.hotel = hotel;
            this.personas_habitacion = personas_habitacion;
            this.precio = precio;
        }

        public Paquetes(int idPaquete,
            int idTipoPaquete,
            string destino,
            int num_camion,
            string hotel,
            int personas_habitacion,
            double precio)
        {
            this.idPaquete = idPaquete;
            this.idTipoPaquete = idTipoPaquete;
            this.destino = destino;
            this.num_camion = num_camion;
            this.hotel = hotel;
            this.personas_habitacion = personas_habitacion;
            this.precio = precio;
        }

        public Paquetes(int idPaquete)
        {
            this.idPaquete = idPaquete;
        }

        //MÉTODOS
        public bool InsertarPaquete()
        {
            try
            {
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "InsertarPaquete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTipoPaquete", idTipoPaquete);
                cmd.Parameters.AddWithValue("@destino", destino);
                cmd.Parameters.AddWithValue("@num_camion", num_camion);
                cmd.Parameters.AddWithValue("@hotel", hotel);
                cmd.Parameters.AddWithValue("@personas_habitacion", personas_habitacion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = conection.CloseConection();
                return true;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al insertar paquete.", "Error al insertar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EditarPaquete()
        {
            try
            {
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "EditarPaquete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPaquete", idPaquete);
                cmd.Parameters.AddWithValue("@idTipoPaquete", idTipoPaquete);
                cmd.Parameters.AddWithValue("@destino", destino);
                cmd.Parameters.AddWithValue("@num_camion", num_camion);
                cmd.Parameters.AddWithValue("@hotel", hotel);
                cmd.Parameters.AddWithValue("@personas_habitacion", personas_habitacion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = conection.CloseConection();
                return true;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al editar paquete.", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EliminarPaquete()
        {
            try
            {
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "EliminarPaquete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPaquete", idPaquete);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = conection.CloseConection();
                return true;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al eliminar paquete.", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable CargarPaquetes()
        {
            try
            {
                DataTable table = new DataTable();
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "CargarPaquetes";
                cmd.CommandType = CommandType.StoredProcedure;
                readRows = cmd.ExecuteReader();
                table.Load(readRows);
                readRows.Close();
                cmd.Connection = conection.CloseConection();
                return table;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al cargar paquetes.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
