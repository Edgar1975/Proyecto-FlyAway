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
    public partial class FormAdministrador : Form
    {
        TiposPaquetes tiposPaquetes = new TiposPaquetes();
        Paquetes paquetes = new Paquetes();
        Clientes clientes = new Clientes();

        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void CargarEscuelas()
        {
            Escuelas escuelas = new Escuelas();
            cbSchool.DataSource = escuelas.CargarEscuelas();
            cbSchool.DisplayMember = "nombre";
            cbSchool.ValueMember = "idEscuela";

            cbEscuelasReportes.DataSource = escuelas.CargarEscuelas();
            cbEscuelasReportes.DisplayMember = "nombre";
            cbEscuelasReportes.ValueMember = "idEscuela";
        }

        private void CargarCarreras()
        {
            Carreras carreras = new Carreras();
            carreras.Nombre_escuela = cbSchool.Text;
            cbCarrera.DataSource = carreras.CargarCarreras();
            cbCarrera.DisplayMember = "nombre";
            cbCarrera.ValueMember = "idCarrera";
        }

        private void CargarReportes()
        {
            Escuelas escuelas = new Escuelas();
            escuelas.Nombre = cbEscuelasReportes.Text;
            gvReportes.DataSource = escuelas.CargarReportes();
        }

        private void CargarPaquetes()
        {
            Paquetes paquetes = new Paquetes();
            gvPaquetes.DataSource = paquetes.CargarPaquetes();
        }

        private void CargarTiposPaquetes()
        {
            TiposPaquetes tiposPaquetes = new TiposPaquetes();
            cbTipoPaquete.DataSource = tiposPaquetes.CargarTiposPaquetes();
            cbTipoPaquete.DisplayMember = "nombre";
            cbTipoPaquete.ValueMember = "idTipoPaquete";
        }

        private void CargarClientes()
        {
            Clientes clientes = new Clientes();
            gvClientes.DataSource = clientes.CargarClientes();
        }

        private void LimpiarCamposClientes()
        {
            txtNombreCliente.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtEdad.Text = "";
            txtMatricula.Text = "";
            txtClave.Text = "";
        }

        private void LimpiarCamposPaquetes()
        {
            txtDestino.Text = "";
            txtNumCamion.Text = "";
            txtHotel.Text = "";
            txtHabitacion.Text = "";
            txtPrecio.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

            CargarEscuelas();
            CargarPaquetes();
            CargarTiposPaquetes();
            CargarClientes();

            btnEditarPaquete.Visible = false;
            panelPaquetes.Visible = true;
            panelClientes.Visible = false;
            panelReportes.Visible = false;
            panelNuevoPaquete.Visible = false;
            gvPaquetes.Visible = true;
            btnCloseMenu.Visible = true;
            btnOpenMenu.Visible = false;
            mousePaquetes.Visible = false;
            mouseClientes.Visible = false;
            mouseLogout.Visible = false;
            mouseReportes.Visible = false;
        }

        private void btnAddPaquete_Click(object sender, EventArgs e)
        {
            if (txtDestino.Text == "" || txtNumCamion.Text == "" || txtHotel.Text == "" || txtHabitacion.Text == "" || txtPrecio.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos obligatorios para registrar un paquete.", "Observación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                paquetes.IdTipoPaquete = Convert.ToInt32(cbTipoPaquete.SelectedValue);
                paquetes.Destino = txtDestino.Text;
                paquetes.Num_camion = Convert.ToInt32(txtNumCamion.Text);
                paquetes.Hotel = txtHotel.Text;
                paquetes.Personas_habitacion = Convert.ToInt32(txtHabitacion.Text);
                paquetes.Precio = Convert.ToDouble(txtPrecio.Text);
                paquetes.InsertarPaquete();
                CargarPaquetes();
                LimpiarCamposPaquetes();
                MessageBox.Show("El paquete se ha registrado con éxito.", "Paquete registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
        }

        private void btnPaquetes_Click(object sender, EventArgs e)
        {
            panelPaquetes.Visible = true;
            panelNuevoPaquete.Visible = false;
            gvPaquetes.Visible = true;
            panelClientes.Visible = false;
        }

        private void btnCloseMenu_Click(object sender, EventArgs e)
        {
            btnOpenMenu.Visible = true;
            btnCloseMenu.Visible = false;
            if (panelMenu.Width == 248)
            {
                panelMenu.Width = 58;
                btnPaquetes.Text = "";
                btnClientes.Text = "";
                pbLogo.Visible = false;
                labelLogo.Visible = false;
            }
        }

        private void btnOpenMenu_Click(object sender, EventArgs e)
        {
            btnCloseMenu.Visible = true;
            btnOpenMenu.Visible = false;
            if (panelMenu.Width == 58)
            {
                panelMenu.Width = 248;
                btnPaquetes.Text = "PAQUETES";
                btnClientes.Text = "CLIENTES";
                pbLogo.Visible = true;
                labelLogo.Visible = true;
            }
        }

        private void btnNuevoPaquete_Click(object sender, EventArgs e)
        {
            LimpiarCamposPaquetes();
            btnEditarPaquete.Visible = false;
            panelNuevoPaquete.Visible = true;
            panelNuevoTipoPaquete.Visible = false;
            gvPaquetes.Visible = false;
            labelPaquete.Visible = true;
            labelPaquete.Text = "Nuevo Paquete";
            labelTipoPaquete.Visible = false;
        }

        private void btnNuevoTipoPaquete_Click(object sender, EventArgs e)
        {
            panelNuevoPaquete.Visible = true;
            panelNuevoTipoPaquete.Visible = true;
            gvPaquetes.Visible = false;
            btnEditarPaquete.Visible = false;
            labelPaquete.Visible = false;
            labelTipoPaquete.Visible = true;
        }

        private void btnPaquetes_MouseEnter(object sender, EventArgs e)
        {
            if (!mousePaquetes.Visible)
            {
                mousePaquetes.Visible = true;
            }
        }

        private void btnPaquetes_MouseLeave(object sender, EventArgs e)
        {
            if(mousePaquetes.Visible)
            {
                mousePaquetes.Visible = false;
            }
        }

        private void btnClientes_MouseEnter(object sender, EventArgs e)
        {
            if (!mouseClientes.Visible)
            {
                mouseClientes.Visible = true;
            }
        }

        private void btnClientes_MouseLeave(object sender, EventArgs e)
        {
            if(mouseClientes.Visible)
            {
                mouseClientes.Visible = false;
            }
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            if(!mouseLogout.Visible)
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

        private void btnAddTipoPaquete_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del tipo de paquete.", "Observación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tiposPaquetes.Nombre = txtNombre.Text;
                tiposPaquetes.InsertarTipoPaquete();
                txtNombre.Text = "";
                CargarTiposPaquetes();
                MessageBox.Show("El tipo de paquete se ha registrado con éxito.", "Tipo de paquete registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelNuevoTipoPaquete.Visible = false;
            panelNuevoPaquete.Visible = false;
            gvPaquetes.Visible = true;
        }

        private void btnBackNuevoPaquete_Click(object sender, EventArgs e)
        {
            LimpiarCamposPaquetes();
            panelNuevoPaquete.Visible = false;
            gvPaquetes.Visible = true;
        }

        private void btnModificarPaquete_Click(object sender, EventArgs e)
        {
            if(gvPaquetes.Rows.Count == 0)
            {
                MessageBox.Show("No hay paquetes que editar por ahora.", "Observación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cbTipoPaquete.Text = gvPaquetes.CurrentRow.Cells[1].Value.ToString();
                txtDestino.Text = gvPaquetes.CurrentRow.Cells[2].Value.ToString();
                txtNumCamion.Text = gvPaquetes.CurrentRow.Cells[3].Value.ToString();
                txtHotel.Text = gvPaquetes.CurrentRow.Cells[4].Value.ToString();
                txtHabitacion.Text = gvPaquetes.CurrentRow.Cells[5].Value.ToString();
                txtPrecio.Text = gvPaquetes.CurrentRow.Cells[6].Value.ToString();
                gvPaquetes.Visible = false;
                panelNuevoPaquete.Visible = true;
                panelNuevoTipoPaquete.Visible = false;
                btnEditarPaquete.Visible = true;
                labelPaquete.Visible = true;
                labelPaquete.Text = "Editar Paquete";
                labelTipoPaquete.Visible = false;
            }
        }

        private void btnEliminarPaquete_Click(object sender, EventArgs e)
        {
            if (gvPaquetes.Rows.Count == 0)
            {
                MessageBox.Show("No hay paquetes que eliminar por ahora.", "Observación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if(MessageBox.Show("¿Está seguro que desea eliminar el paquete?", "Eliminar paquete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    paquetes.IdPaquete = Convert.ToInt32(gvPaquetes.CurrentRow.Cells[0].Value.ToString());
                    paquetes.EliminarPaquete();
                    CargarPaquetes();
                    CargarReportes();
                    MessageBox.Show("El paquete se ha eliminado con éxito.", "Paquete eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    
                }
            }
        }

        private void btnEditarPaquete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea editar el paquete?", "Editar paquete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                paquetes.IdPaquete = Convert.ToInt32(gvPaquetes.CurrentRow.Cells[0].Value.ToString());
                paquetes.IdTipoPaquete = Convert.ToInt32(cbTipoPaquete.SelectedValue);
                paquetes.Destino = txtDestino.Text;
                paquetes.Num_camion = Convert.ToInt32(txtNumCamion.Text);
                paquetes.Hotel = txtHotel.Text;
                paquetes.Personas_habitacion = Convert.ToInt32(txtHabitacion.Text);
                paquetes.Precio = Convert.ToDouble(txtPrecio.Text);
                paquetes.EditarPaquete();
                CargarPaquetes();
                CargarReportes();
                LimpiarCamposPaquetes();
                MessageBox.Show("El paquete se ha editado con éxito.", "Paquete editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            panelPaquetes.Visible = true;
            panelClientes.Visible = true;
            panelReportes.Visible = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if(gvClientes.Rows.Count == 0)
            {
                MessageBox.Show("No hay clientes que editar por ahora.", "Observación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtNombreCliente.Text = gvClientes.CurrentRow.Cells[1].Value.ToString();
                txtApellidoP.Text = gvClientes.CurrentRow.Cells[2].Value.ToString();
                txtApellidoM.Text = gvClientes.CurrentRow.Cells[3].Value.ToString();
                txtEdad.Text = gvClientes.CurrentRow.Cells[4].Value.ToString();
                cbSchool.Text = gvClientes.CurrentRow.Cells[5].Value.ToString();
                cbCarrera.Text = gvClientes.CurrentRow.Cells[6].Value.ToString();
                txtMatricula.Text = gvClientes.CurrentRow.Cells[7].Value.ToString();
                txtClave.Text = gvClientes.CurrentRow.Cells[8].Value.ToString();
                gvClientes.Visible = false;
                panelModificarCliente.Visible = true;
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea editar el cliente?", "Editar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clientes.IdCliente = Convert.ToInt32(gvClientes.CurrentRow.Cells[0].Value.ToString());
                clientes.IdEscuela = Convert.ToInt32(cbSchool.SelectedValue);
                clientes.IdCarrera = Convert.ToInt32(cbCarrera.SelectedValue);
                clientes.Nombre = txtNombreCliente.Text;
                clientes.A_paterno = txtApellidoP.Text;
                clientes.A_materno = txtApellidoM.Text;
                clientes.Edad = Convert.ToInt32(txtEdad.Text);
                clientes.Matricula = txtMatricula.Text;
                clientes.Clave_elector = txtClave.Text;
                clientes.EditarCliente();
                CargarClientes();
                CargarReportes();
                LimpiarCamposClientes();
                MessageBox.Show("El cliente se ha editado con éxito.", "Cliente editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(gvClientes.Rows.Count == 0)
            {
                MessageBox.Show("No hay clientes que eliminar por ahora.", "Observación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Eliminar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clientes.IdCliente = Convert.ToInt32(gvClientes.CurrentRow.Cells[0].Value.ToString());
                    clientes.EliminarCliente();
                    CargarClientes();
                    CargarReportes();
                    MessageBox.Show("El cliente se ha eliminado con éxito.", "Cliente eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }
            }
        }

        private void btnBackEditarCliente_Click(object sender, EventArgs e)
        {
            LimpiarCamposClientes();
            panelModificarCliente.Visible = false;
            gvClientes.Visible = true;
        }

        private void cbSchool_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CargarCarreras();
        }

        private void btnReportes_MouseEnter(object sender, EventArgs e)
        {
            if(!mouseReportes.Visible)
            {
                mouseReportes.Visible = false;
            }
        }

        private void btnReportes_MouseLeave(object sender, EventArgs e)
        {
            if(mouseReportes.Visible)
            {
                mouseReportes.Visible = false;
            }
        }

        private void cbEscuelasReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReportes();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelPaquetes.Visible = true;
            panelClientes.Visible = true;
            panelReportes.Visible = true;
        }
    }
}
