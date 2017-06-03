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
    public partial class frm_marca : Form
    {
        public frm_marca()
        {
            InitializeComponent();
        }

        private void frm_marca_Load(object sender, EventArgs e)
        {
            txt_comision.Enabled = false;
            txt_nombre.Enabled = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            entidades.Marca marca = new entidades.Marca();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            marca.nombre = txt_nombre.Text; //Llenamos el objeto persona con la informacion de los cuadros de texto/
            marca.porcentaje = Convert.ToInt32(txt_comision.Text);
            cnegocio.InsertarMarca(marca);
            txt_comision.Clear();
            txt_nombre.Clear();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_marca.DataSource = cnegocio.consultamarca();
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(dgv_marca);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(dgv_marca);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(dgv_marca);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(dgv_marca);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_comision.Enabled = false;
            txt_nombre.Enabled = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = true;
            txt_comision.Enabled = true;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_marca.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt16(dgv_marca.CurrentRow.Cells[0].Value);
                    negocio n = new negocio();
                    n.EliminarMarca(id);

                }
                else
                    MessageBox.Show("Debe de seleccionar una fila");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            txt_comision.Enabled = false;
            txt_nombre.Enabled = false;
        }
    }
}
