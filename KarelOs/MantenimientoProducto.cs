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
    public partial class MantenimientoProducto : Mantenimiento
    {
        public MantenimientoProducto()
        {
            InitializeComponent();
        }

        private void MantenimientoProducto_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM articulos";
            DataTable ds = Utilerias.LlenarGrid(cmd);

            dataGridView1.DataSource = ds;
            
        }

        public override Boolean Guardar()
        {
            try
            {
                string cmd = string.Format("CALL ActualizarArticulos('{0}','{1}')", txtNombreProducto.Text.Trim(), txtPrecioProducto.Text.Trim());
                Utilerias.Ejecutar(cmd);
                MessageBox.Show("Registro Exitoso");
                return true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public override void Eliminar()
        {
            try
            {
                string cmd = string.Format("CALL EliminarArticulo('{0}')", txtNombreProducto.Text.Trim());
                Utilerias.Ejecutar(cmd);
                MessageBox.Show("Registro Eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
