using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace GlassCarLaguna.CapaDatos
{
    public class Usuarios
    {
        private Conexion conection = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader readRows;

        //ATRIBUTOS
        private string usuario, contraseña;

        //PROPIEDADES
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        //CONSTRUCTORES
        public Usuarios()
        {

        }

        //MÉTODOS
        public DataTable IniciarSesion(Form login)
        {
            try
            {
                DataTable table = new DataTable();
                cmd.Connection = conection.OpenConection();
                cmd.CommandText = "IniciarSesion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                readRows = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                table.Load(readRows);
                readRows.Close();
                cmd.Connection = conection.CloseConection();

                if(table.Rows.Count == 1)
                {
                    if (table.Rows[0][0].ToString() == "asesor")
                    {
                        login.Hide();
                        FormMenu asesor = new FormMenu();
                        asesor.ShowDialog();
                    }
                    else if (table.Rows[0][0].ToString() == "administrador")
                    {
                        login.Hide();
                        FormAdministrador admin = new FormAdministrador();
                        admin.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario y/o contraseña que ingresó son incorrectos.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return table;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al iniciar sesión.", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
