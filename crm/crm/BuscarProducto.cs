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
    public partial class BuscarProducto : Form
    {
        public BuscarProducto()
        {
            InitializeComponent();
        }

        private void txt_buscarP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable carga = CapaDatos.CargarGridAutoIncrement("select id_producto, descripcion, precio_unidad, precio_mayorista from producto_m WHERE id_producto like '%" + txt_buscarP.Text + "%' or descripcion like '%" + txt_buscarP.Text + "%'");
                dgv_productosVista.DataSource = carga;
            }
            catch {
                MessageBox.Show("Error al cargar");
            }

        }
        public string codigoP;
        public string decripcionP;
        public string precioUP;
        public string SubtotalP;

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            /*
            Factura fac = new Factura();
            CapaDatos nuev = new CapaDatos();
            codigoP = this.dgv_productosVista.CurrentRow.Cells[0].Value.ToString();
            decripcionP = this.dgv_productosVista.CurrentRow.Cells[1].Value.ToString();
            precioUP = this.dgv_productosVista.CurrentRow.Cells[2].Value.ToString();
            double temporal1 = Convert.ToDouble(txt_cantidad.Text);
            int temporal2 = Convert.ToInt32(precioUP);
            double subtot = temporal1 * temporal2;
            SubtotalP = Convert.ToString(subtot);
            */
            this.Close();
            
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable carga = CapaDatos.CargarGridAutoIncrement("select id_producto, descripcion, precio_unidad, precio_mayorista from producto_m ORDER BY descripcion ASC");
                dgv_productosVista.DataSource = carga;

            }
            catch {
                MessageBox.Show("Error al cargar");
            }
            
        }
    }
}
