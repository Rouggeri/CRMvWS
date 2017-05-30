using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace crm
{
    public partial class frmbuscorden : Form
    {
        public frmbuscorden()
        {
            InitializeComponent();
        }

        public void mostrar()
        {
            OdbcConnection conexion = Conexion.ObtenerConexion();
            OdbcDataAdapter dausuario = new OdbcDataAdapter("select compra.id_compra, producto.nombre, marca.nombre_marca, tbl_proveedor.nombre_proveedor, compra.cantidad, compra.fecha from compra inner join producto inner join marca inner join tbl_proveedor where compra.id_producto = producto.id_producto and compra.id_marca = marca.id_marca and compra.id_proveedor = tbl_proveedor.id_proveedor", conexion);
            DataSet dsuario = new DataSet();
            dausuario.Fill(dsuario, "Compra");
            dgv_bien.DataSource = dsuario;
            dgv_bien.DataMember = "Compra";
        }

        private void btn_buscbien_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_bien.DataSource = Clsoporden.Buscar(txt_bien.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmbuscorden_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        public entidades.Orden busq { get; set; }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_bien.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt16(dgv_bien.CurrentRow.Cells[0].Value);
                    busq = Clsoporden.Obtenerclte(id);
                    this.Close();
                }
                else
                    MessageBox.Show("Debe de seleccionar una fila");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
