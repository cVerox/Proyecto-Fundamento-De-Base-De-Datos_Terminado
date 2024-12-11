using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Fundamento_De_Base_De_Datos
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btn_Empleados_Click(object sender, EventArgs e)
        {
            Consultas consultas = new Consultas();
            this.Hide();
            consultas.Show();
        }

        private void btn_Empresas_Click(object sender, EventArgs e)
        {
            Empresas consultas = new Empresas();
            this.Hide();
            consultas.Show();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
