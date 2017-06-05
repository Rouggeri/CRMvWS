using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoUOne
{
    public partial class FacturaVista : Form
    {
        public FacturaVista()
        {
            InitializeComponent();
            btn_guardar.Enabled = false;
            CargarDetalle();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Factura abrir = new Factura();
            abrir.Show();        
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            ModificarFactura abrir = new ModificarFactura();
            abrir.Show();
            this.Close();
        }

        public void CargarDetalle() {
            try
            {

                DataTable cargas = CapaDatos.CargarGridAutoIncrement("select * from factura_encabezado;");
                dgv_FacturaVista.DataSource = cargas;
            }
            catch {
                MessageBox.Show("Error de carga");
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Desea Eliminar la Fila de la base de datos? ", " Message of Option Delete ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    CapaDatos abrir = new CapaDatos();
                    string CodigoC = this.dgv_FacturaVista.CurrentRow.Cells[0].Value.ToString();
                    abrir.ActualizaEstadoFactura(CodigoC);
                }
            }
            catch
            {
                MessageBox.Show("Error al borrar");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
