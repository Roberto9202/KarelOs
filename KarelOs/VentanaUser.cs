using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;

namespace KarelOs
{
    public partial class VentanaUser : FormBase
    {
        public VentanaUser()
        {
            InitializeComponent();
        }

        private void VentanaUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void VentanaUser_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM usuarios WHERE id = " + Login.codigo;
            DataSet ds = Utilerias.Ejecutar(cmd);

            lblNombre.Text = ds.Tables[0].Rows[0]["user"].ToString().Trim();
            lblUsuario.Text = ds.Tables[0].Rows[0]["user"].ToString().Trim();
            lblCodigo.Text = ds.Tables[0].Rows[0]["id"].ToString().Trim();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal cp = new ContenedorPrincipal();
            this.Hide();
            cp.Show();
        }
    }
}
