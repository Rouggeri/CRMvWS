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
    public partial class frm_tprecio : Form
    {
        public frm_tprecio()
        {
            InitializeComponent();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            entidades.Tprecio catalogo = new entidades.Tprecio();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            catalogo.tipo = txt_nombre.Text; //Llenamos el objeto persona con la informacion de los cuadros de texto/
            cnegocio.InsertarCatalogo(catalogo);
            txt_nombre.Clear();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_catalogo.DataSource = cnegocio.consultacatalogo();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = true;
            txt_nombre.Clear();
        }

        private void frm_tprecio_Load(object sender, EventArgs e)
        {
            txt_nombre.Enabled = false;
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(dgv_catalogo);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(dgv_catalogo);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(dgv_catalogo);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(dgv_catalogo);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = false;
            txt_nombre.Clear();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_catalogo.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt16(dgv_catalogo.CurrentRow.Cells[0].Value);
                    negocio n = new negocio();
                    n.EliminarCatalogo(id);

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
