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
    public partial class frm_existencia : Form
    {
        string id_form = "119";
        /******************************************/
        Int32 idprod;
        Int32 idmarc;
        /*******************************************/
        Int32 idcompra;
        Int32 idproducto;
        Int32 idmarca;
        Int32 idproveedor;
        Int32 cantidad;
        String fecha;



        public frm_existencia()
        {
            InitializeComponent();
        
        }

        public void llenar_encabezado()
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "Producto";
            c1.Width = 100;
            c1.ReadOnly = true;

            dgv_existencia.Columns.Add(c1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "Bodega";
            c2.Width = 50;
            c2.ReadOnly = true;

            dgv_existencia.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "Fecha_Ingreso";
            c3.Width = 75;
            c3.ReadOnly = true;

            dgv_existencia.Columns.Add(c3);

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.HeaderText = "Cantidad";
            c4.Width = 50;
            c4.ReadOnly = true;

            dgv_existencia.Columns.Add(c4);

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.HeaderText = "Proveedor";
            c5.Width = 50;
            c5.ReadOnly = true;

            dgv_existencia.Columns.Add(c5);
        }
       
        private void llenarbod()
        {
            negocio cnegocio = new negocio();
            cbo_bodega.DataSource = cnegocio.consultarbod();
            cbo_bodega.ValueMember = "id_bodega";
            cbo_bodega.DisplayMember = "nombre_bodega";
        }

        private void llenarprov()
        {
            negocio cnegocio = new negocio();
            cbo_proveedor.DataSource = cnegocio.consultaprov();
            cbo_proveedor.ValueMember = "id_proveedor";
            cbo_proveedor.DisplayMember = "nombre_proveedor";
        }

        private void frm_existencia_Load(object sender, EventArgs e)
        {
            txt_ingreso.Text = Convert.ToString(DateTime.Today);
            //llenar_encabezado();
           
            llenarbod();
            txt_ingreso.Enabled = false;
            txt_prod.Enabled = false;
            txt_orden.Enabled = false;
            btn_bproducto.Enabled = false;
            cbo_proveedor.Enabled = false;
            txt_cantidad.Enabled = false;

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guardarnuevo()
        {
            entidades.Existencia existencia = new entidades.Existencia();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            existencia.cantidad = Convert.ToInt32(txt_cantidad.Text); //Llenamos el objeto persona con la informacion de los cuadros de texto/
            existencia.producto = idprod;
            existencia.marca = idmarc;
            existencia.bodega = Convert.ToInt32(cbo_bodega.SelectedIndex + 1);
            existencia.ingreso = Convert.ToString(DateTime.Today);
            existencia.proveedor = Convert.ToInt32(cbo_proveedor.SelectedIndex + 1);
            cnegocio.InsertarExistencia(existencia);
        }

        private void guardarexistente()
        {
            entidades.Existencia existencia = new entidades.Existencia();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            existencia.codigo = txt_orden.Text;
            existencia.cantidad = cantidad; //Llenamos el objeto persona con la informacion de los cuadros de texto/
            existencia.producto = idproducto;
            existencia.marca = idmarca;
            existencia.bodega = Convert.ToInt32(cbo_bodega.SelectedIndex + 1);
            existencia.ingreso = fecha;
            existencia.proveedor = idproveedor;
            cnegocio.InsertarExistencia(existencia);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            
                if (check_correlativo.Checked)
            {

                btn_borden.Enabled = true;
                cbo_bodega.Enabled = true;

                guardarexistente();
                            

            }

            else
                        if (check_nuevo.Checked) {

                txt_ingreso.Enabled = true;
                txt_prod.Enabled = true;
                btn_bproducto.Enabled = true;
                cbo_proveedor.Enabled = true;
                cbo_bodega.Enabled = true;
                txt_cantidad.Enabled = true;
                cbo_bodega.Enabled = true;

                guardarnuevo(); }


            
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_existencia.DataSource = cnegocio.consultaex();
        }

        private void txt_ingreso_TextChanged(object sender, EventArgs e)
        {

        }

        public entidades.Producto clsprod { get; set; }
        private void btn_bproducto_Click(object sender, EventArgs e)
        {
            try
            {


                frmbuscproducto buscl = new frmbuscproducto();
                buscl.ShowDialog();


                if (buscl.busq != null)
                {
                    clsprod = buscl.busq;

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

        private void check_marca_CheckedChanged(object sender, EventArgs e)
        {
            switch (check_correlativo.CheckState.ToString())
            {
                case "Checked":
                    btn_bproducto.Enabled = false;
                    cbo_proveedor.Enabled = false;
                    txt_cantidad.Enabled = false;

                    //llenarmarca();

                    break;
                case "Uncheked":
                    //cbo_marca.Enabled = false;
                    btn_bproducto.Enabled = true;
                    cbo_proveedor.Enabled = true;
                    txt_cantidad.Enabled = true;
                    break;
                default:
                    //cbo_marca.Enabled = false;
                    btn_bproducto.Enabled = true;
                    cbo_proveedor.Enabled = true;
                    txt_cantidad.Enabled = true;

                    break;
            }
        }

        
        private void btn_borden_Click(object sender, EventArgs e)
        {
            existente();
        }

        public entidades.Orden clsord { get; set; }
        private void existente()
        {
            try
            {


                frmbuscorden busco = new frmbuscorden();
                busco.ShowDialog();


                if (busco.busq != null)
                {
                    clsord = busco.busq;

                    txt_orden.Text = Convert.ToString(busco.busq.codigo);
                    idcompra = Convert.ToInt32(busco.busq.codigo);
                    idmarca = busco.busq.marca;
                    idproducto = busco.busq.producto;
                    idproveedor = busco.busq.proveedor;
                    cantidad = busco.busq.cantidad;
                    fecha = Convert.ToString(DateTime.Today);

                    /*MessageBox.Show(Convert.ToString(idcompra));
                    MessageBox.Show(Convert.ToString(idproducto));
                    MessageBox.Show(Convert.ToString(idmarca));
                    MessageBox.Show(Convert.ToString(idproveedor));
                    MessageBox.Show(Convert.ToString(cantidad));
                    MessageBox.Show(Convert.ToString(fecha));*/

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void check_categoria_CheckedChanged(object sender, EventArgs e)
        {
            llenarprov();
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(dgv_existencia);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(dgv_existencia);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(dgv_existencia);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(dgv_existencia);
        }
    }
}
