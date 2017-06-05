using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm
{
    public partial class frm_proveedor : Form
    {
        public frm_proveedor()
        {
            InitializeComponent();
        }

        private void frm_proveedor_Load(object sender, EventArgs e)
        {
            txt_telefono.Enabled = false;
            txt_nombre.Enabled = false;
            txt_direccion.Enabled = false;
            txt_nit.Enabled = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            entidades.Proveedor proveedor = new entidades.Proveedor();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            proveedor.nombre = txt_nombre.Text; //Llenamos el objeto persona con la informacion de los cuadros de texto/
            proveedor.nit = txt_nit.Text;
            proveedor.direccion = txt_direccion.Text;
            proveedor.telefono = txt_telefono.Text;
            cnegocio.InsertarProveedor(proveedor);
            txt_nombre.Clear();
            txt_nit.Clear();
            txt_direccion.Clear();
            txt_telefono.Clear();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_prov.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt16(dgv_prov.CurrentRow.Cells[0].Value);
                    negocio n = new negocio();
                    n.EliminarProveedor(id);

                }
                else
                    MessageBox.Show("Debe de seleccionar una fila");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_prov.DataSource = cnegocio.consultaprov();
           
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_telefono.Enabled = true;
            txt_nombre.Enabled = true;
            txt_direccion.Enabled = true;
            txt_nit.Enabled = true;
            txt_nombre.Clear();
            txt_telefono.Clear();
            txt_direccion.Clear();
            txt_nit.Clear();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_telefono.Enabled = false;
            txt_nombre.Enabled = false;
            txt_direccion.Enabled = false;
            txt_nit.Enabled = false;
            txt_nombre.Clear();
            txt_telefono.Clear();
            txt_direccion.Clear();
            txt_nit.Clear();
        }
    }
}
