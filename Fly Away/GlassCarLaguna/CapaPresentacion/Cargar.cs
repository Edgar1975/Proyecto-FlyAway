using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlassCarLaguna
{
    public partial class Cargar : Form
    {
        public Cargar()
        {
            InitializeComponent();
        }

        public void Cargando()
        {
            progressBar1.Increment(1);
            label4.Text = progressBar1.Value.ToString() + "%";
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
                Form5 f5 = new Form5();
                f5.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cargando();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
