using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlassCarLaguna.CapaDatos;

namespace GlassCarLaguna
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text == "" || txtcontra.Text == "")
            {
                MessageBox.Show("Debe ingresar un usuario y contraseña.", "Observación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Usuarios usuarios = new Usuarios();
                usuarios.Usuario = txtusuario.Text;
                usuarios.Contraseña = txtcontra.Text;
                usuarios.IniciarSesion(this);
                
            }
        }
    }
}
