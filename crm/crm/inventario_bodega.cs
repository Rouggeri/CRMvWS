using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FuncionesNavegador;

namespace crm
{
    public partial class inventario_bodega : Form
    {
        public inventario_bodega()
        {
            InitializeComponent();
        }

        private void inventario_bodega_Load(object sender, EventArgs e)
        {
            txt_nombre.Enabled = false;
            txt_ubicacion.Enabled = false;
        }
        string id_form = "117";

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_bodega.DataSource = cnegocio.consultarbod();
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            String codi;
            Int32 selectedRowCount =
            dgv_bodega.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                codi = Convert.ToString(dgv_bodega.CurrentRow.Cells[0].Value);
                negocio neg = new negocio();
                neg.EliminarBodega(Convert.ToInt32(codi));
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            entidades.Bodega bodega = new entidades.Bodega();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            bodega.nombre = txt_nombre.Text;                                //Llenamos el objeto persona con la informacion de los cuadros de texto/
            bodega.direccion = txt_ubicacion.Text;
            cnegocio.InsertarBodega(bodega);                                    //Llamamos a la funcion Ninsertar a traves del objeto de la capa de negocio y le enviamos como parametro nuestro objeto persona
            limpiar();
            deshabilitar();
        }

        void limpiar()
        {
            txt_nombre.Clear();
            txt_ubicacion.Clear();
        }
        void deshabilitar()
        {
            txt_nombre.Enabled = false;
            txt_ubicacion.Enabled = false;
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(dgv_bodega);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(dgv_bodega);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(dgv_bodega);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(dgv_bodega);
        }


        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = false;
            txt_ubicacion.Enabled = false;
            txt_nombre.Clear();
            txt_ubicacion.Clear();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = true;
            txt_ubicacion.Enabled = true;
            txt_nombre.Clear();
            txt_ubicacion.Clear();
        }
    }
}
