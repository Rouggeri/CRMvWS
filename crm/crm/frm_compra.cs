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
    public partial class frm_compra : Form
    {
        int idprod;
        int idmarc;
        public frm_compra()
        {
            InitializeComponent();
        }

        private void llenarprov()
        {
            negocio cnegocio = new negocio();
            cbo_proveedor.ValueMember = "id_proveedor";
            cbo_proveedor.DisplayMember = "nombre_proveedor";
            cbo_proveedor.DataSource = cnegocio.consultaprov();
            txt_ingreso.Enabled = false;
            txt_ingreso.Text = Convert.ToString(DateTime.Today);
        }

        public entidades.Producto clspro { get; set; }
        private void btn_bproducto_Click(object sender, EventArgs e)
        {
            try
            {


                frmbuscproducto buscl = new frmbuscproducto();
                buscl.ShowDialog();


                if (buscl.busq != null)
                {
                    clspro = buscl.busq;

                    txt_prod.Text = Convert.ToString(buscl.busq.nombre);
                    idprod = Convert.ToInt16(buscl.busq.codigo);
                    idmarc = Convert.ToInt16(buscl.busq.marca);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void frm_compra_Load(object sender, EventArgs e)
        {
            llenarprov();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            entidades.Compra compra = new entidades.Compra();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            compra.producto = idprod;
            compra.marca = idmarc;
            compra.proveedor = Convert.ToInt32(cbo_proveedor.SelectedIndex + 1); ; //Llenamos el objeto persona con la informacion de los cuadros de texto/
            compra.cantidad = Convert.ToInt32(txt_cantidad.Text);
            compra.fecha = txt_ingreso.Text;
            cnegocio.InsertarCompra(compra);
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_compra.DataSource = cnegocio.consultacomp();
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(dgv_compra);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(dgv_compra);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(dgv_compra);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(dgv_compra);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_compra.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt16(dgv_compra.CurrentRow.Cells[0].Value);
                    negocio n = new negocio();
                    n.EliminarBodega(id);

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
