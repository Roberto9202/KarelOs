using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MiLibreria;
using System.Data;
namespace KarelOs
{
    public partial class Login : FormBase
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string codigo;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("SELECT * FROM usuarios WHERE user='{0}' AND password='{1}'", txtUserLogin.Text.Trim(), txtPassLogin.Text.Trim());
                DataSet ds = Utilerias.Ejecutar(cmd);

                codigo = ds.Tables[0].Rows[0]["id"].ToString().Trim();
                string user = ds.Tables[0].Rows[0]["user"].ToString().Trim();
                string pass = ds.Tables[0].Rows[0]["password"].ToString().Trim();

                if(user == txtUserLogin.Text.Trim() && pass == txtPassLogin.Text.Trim())
                {
                    if(Convert.ToBoolean(ds.Tables[0].Rows[0]["statusAdmin"]) == true){
                        VentanaAdmin va = new VentanaAdmin();
                        this.Hide();
                        va.Show();
                    }
                    else
                    {
                        VentanaUser vu = new VentanaUser();
                        this.Hide();
                        vu.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show("Error al ingresar los datos");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
