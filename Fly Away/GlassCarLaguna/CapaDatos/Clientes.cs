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
    public class Clientes
    {
        private Conexion conection = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader readRows;

        //ATRIBUTOS
        private int idCliente, idEscuela, idCarrera, idPaquete, edad;
        private string nombre, a_paterno, a_materno, matricula, clave_elector;

        //PROPIEDADES
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public int IdEscuela
        {
            get { return idEscuela; }
            set { idEscuela = value; }
        }

        public int IdCarrera
        {
            get { return idCarrera; }
            set { idCarrera = value; }
        }

        public int IdPaquete
        {
            get { return idPaquete; }
            set { idPaquete = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string A_paterno
        {
            get { return a_paterno; }
            set { a_paterno = value; }
        }

        public string A_materno
        {
            get { return a_materno; }
            set { a_materno = value; }
        }

        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        public string Clave_elector
        {
            get { return clave_elector; }
            set { clave_elector = value; }
        }

        //CONSTRUCTORES
        public Clientes()
        {

        }

        public Clientes(int idEscuela,
            int idCarrera,
            int idPaquete,
            string nombre,
            string a_paterno,
            string a_materno,
            int edad,
            string matricula,
            string clave_elector)
        {
            this.idEscuela = idEscuela;
            this.idCarrera = idCarrera;
            this.idPaquete = idPaquete;
            this.nombre = nombre;
            this.a_paterno = a_paterno;
            this.a_materno = a_materno;
            this.edad = edad;
            this.matricula = matricula;
            this.clave_elector = clave_elector;
        }

        public Clientes(int idCliente,
            int idEscuela,
            int idCarrera,
            int idPaquete,
            string nombre,
            string a_paterno,
            string a_materno,
            int edad,
            string matricula,
            string clave_elector)
        {
            this.idCliente = idCliente;
            this.idEscuela = idEscuela;
            this.idCarrera = idCarrera;
            this.idPaquete = idPaquete;
            this.nombre = nombre;
            this.a_paterno = a_paterno;
            this.a_materno = a_materno;
            this.edad = edad;
            this.matricula = matricula;
            this.clave_elector = clave_elector;
        }

        public Clientes(int idCliente)
        {
            this.idCliente = idCliente;
        }

        //MÉTODOS
        public bool InsertarCliente()
        {
            try
            {
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "InsertarCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEscuela", idEscuela);
                cmd.Parameters.AddWithValue("@idCarrera", idCarrera);
                cmd.Parameters.AddWithValue("@idPaquete", idPaquete);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@a_paterno", a_paterno);
                cmd.Parameters.AddWithValue("@a_materno", a_materno);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@matricula", matricula);
                cmd.Parameters.AddWithValue("@clave_elector", clave_elector);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = conection.CloseConection();
                return true;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al insertar cliente.", "Error al insertar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EditarCliente()
        {
            try
            {
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "EditarCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idCliente", IdCliente);
                cmd.Parameters.AddWithValue("@idEscuela", idEscuela);
                cmd.Parameters.AddWithValue("@idCarrera", idCarrera);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@a_paterno", a_paterno);
                cmd.Parameters.AddWithValue("@a_materno", a_materno);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@matricula", matricula);
                cmd.Parameters.AddWithValue("@clave_elector", clave_elector);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = conection.CloseConection();
                return true;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al editar cliente.", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EliminarCliente()
        {
            try
            {
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "EliminarCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idCliente", IdCliente);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = conection.CloseConection();
                return true;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al eliminar cliente.", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable CargarClientes()
        {
            try
            {
                DataTable table = new DataTable();
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "CargarClientes";
                cmd.CommandType = CommandType.StoredProcedure;
                readRows = cmd.ExecuteReader();
                table.Load(readRows);
                readRows.Close();
                cmd.Connection = conection.CloseConection();
                return table;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al cargar clientes.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
