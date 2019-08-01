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
    public partial class FormMenu : Form
    {
        Escuelas escuelas = new Escuelas();
        Carreras carreras = new Carreras();
        Paquetes proveedores = new Paquetes();
        Clientes clientes = new Clientes();

        public FormMenu()
        {
            InitializeComponent();
        }

        private void CargarEscuelas()
        {
            Escuelas escuelas = new Escuelas();
            cbEscuela.DataSource = escuelas.CargarEscuelas();
            cbEscuela.DisplayMember = "nombre";
            cbEscuela.ValueMember = "idEscuela";

            cbSchool.DataSource = escuelas.CargarEscuelas();
            cbSchool.DisplayMember = "nombre";
            cbSchool.ValueMember = "idEscuela";
        }

        private void CargarCarreras()
        {
            Carreras carreras = new Carreras();
            carreras.Nombre_escuela = cbSchool.Text;
            cbCarrera.DataSource = carreras.CargarCarreras();
            cbCarrera.DisplayMember = "nombre";
            cbCarrera.ValueMember = "idCarrera";
        }

        private void CargarPaquetes()
        {
            Paquetes paquetes = new Paquetes();
            gvPaquetes.DataSource = paquetes.CargarPaquetes();
            gvSeleccionarPaquete.DataSource = paquetes.CargarPaquetes();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnOpenMenu_Click(object sender, EventArgs e)
        {
            btnCloseMenu.Visible = true;
            btnOpenMenu.Visible = false;
            if (panelMenu.Width == 58)
            {
                panelMenu.Width = 248;
                btnEscuelas.Text = "ESCUELAS";
                btnCarreras.Text = "CARRERAS";
                btnPaquetes.Text = "PAQUETES";
                btnClientes.Text = "CLIENTES";
                pbLogo.Visible = true;
                labelLogo.Visible = true;
            }
        }

        private void btnCloseMenu_Click(object sender, EventArgs e)
        {
            btnOpenMenu.Visible = true;
            btnCloseMenu.Visible = false;
            if(panelMenu.Width == 248)
            {
                panelMenu.Width = 58;
                btnEscuelas.Text = "";
                btnCarreras.Text = "";
                btnPaquetes.Text = "";
                btnClientes.Text = "";
                pbLogo.Visible = false;
                labelLogo.Visible = false;
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            if(mouseAseguradora.Visible == false)
            {
                mouseAseguradora.Visible = true;
            }
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            if (mouseAseguradora.Visible == true)
            {
                mouseAseguradora.Visible = false;
            }
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            if (mouseServicio.Visible == false)
            {
                mouseServicio.Visible = true;
            }
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            if (mouseServicio.Visible == true)
            {
                mouseServicio.Visible = false;
            }
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            if (mouseProveedor.Visible == false)
            {
                mouseProveedor.Visible = true;
            }
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            if (mouseProveedor.Visible == true)
            {
                mouseProveedor.Visible = false;
            }
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            if (mouseProducto.Visible == false)
            {
                mouseProducto.Visible = true;
            }
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            if (mouseProducto.Visible == true)
            {
                mouseProducto.Visible = false;
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

            CargarEscuelas();
            CargarCarreras();
            CargarPaquetes();

            btnOpenMenu.Visible = false;
            mouseAseguradora.Visible = false;
            mouseServicio.Visible = false;
            mouseProveedor.Visible = false;
            mouseProducto.Visible = false;
            mouseLogout.Visible = false;

            panelEscuelas.Visible = true;
            panelCarreras.Visible = false;
            panelPaquetes.Visible = false;
            panelClientes.Visible = false;
        }

        private void btnAseguradoras_Click(object sender, EventArgs e)
        {
            panelEscuelas.Visible = true;
            panelCarreras.Visible = false;
        }

        private void btnAddAseguradora_Click(object sender, EventArgs e)
        {
            if (txtEscuela.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de una escuela.", "Observación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    escuelas.Nombre = txtEscuela.Text;
                    escuelas.InsertarEscuela();
                    txtEscuela.Text = "";
                    CargarEscuelas();
                    MessageBox.Show("La escuela se ha registrado con éxito.", "Escuela registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Imposible agregar la escuela.", "Error al agregar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            panelCarreras.Visible = true;
            panelPaquetes.Visible = false;
        }

        private void btnAddServicio_Click(object sender, EventArgs e)
        {
            if (txtCarrera.Text == "")
            {
                MessageBox.Show("Debe llenar los campos obligatorios para registrar una carrera.", "Observación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    carreras.IdEscuela = Convert.ToInt32(cbEscuela.SelectedValue);
                    carreras.Nombre = txtCarrera.Text;
                    carreras.InsertarCarrera();
                    CargarCarreras();
                    txtCarrera.Text = "";
                    MessageBox.Show("La carrera se ha registrado con éxito.", "Servicio registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Imposible registrar la carrera.", "Error al registrar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            panelCarreras.Visible = true;
            panelPaquetes.Visible = true;
            panelClientes.Visible = false;
        }

        private void btnAutomoviles_Click(object sender, EventArgs e)
        {
            panelCarreras.Visible = true;
            panelPaquetes.Visible = true;
            panelClientes.Visible = true;
            panelNuevoCliente.Visible = false;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            panelCarreras.Visible = true;
            panelPaquetes.Visible = true;
            panelClientes.Visible = true;
            panelSeleccionarPaquete.Visible = false;
        }

        private void btnAddAutomovil_Click(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text == "" || txtApellidoP.Text == "" || txtEdad.Text == "" || txtClave.Text == "" || txtMatricula.Text == "")
            {
                MessageBox.Show("Debe llenar los campos obligatorios para registrar un cliente.", "Observación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                panelSeleccionarPaquete.Visible = true;
            }
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            if (!mouseLogout.Visible)
            {
                mouseLogout.Visible = true;
            }
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            if (mouseLogout.Visible)
            {
                mouseLogout.Visible = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form5 form = new Form5();
                form.ShowDialog();
            }
            else
            {

            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            clientes.IdEscuela = Convert.ToInt32(cbSchool.SelectedValue);
            clientes.IdCarrera = Convert.ToInt32(cbCarrera.SelectedValue);
            clientes.IdPaquete = Convert.ToInt32(gvSeleccionarPaquete.CurrentRow.Cells[0].Value.ToString());
            clientes.Nombre = txtNombreCliente.Text;
            clientes.A_paterno = txtApellidoP.Text;
            clientes.A_materno = txtApellidoM.Text;
            clientes.Edad = Convert.ToInt32(txtEdad.Text);
            clientes.Matricula = txtMatricula.Text;
            clientes.Clave_elector = txtClave.Text;
            clientes.InsertarCliente();
            txtNombreCliente.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtEdad.Text = "";
            txtMatricula.Text = "";
            txtClave.Text = "";
            panelSeleccionarPaquete.Visible = false;
            MessageBox.Show("El cliente y su compra se han registrado con éxito.", "Cliente y compra registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbSchool_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CargarCarreras();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSeleccionarPaquete.Visible = false;
        }
    }
}
