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
    public partial class frm_abonos : Form
    {
        public frm_abonos()
        {
            InitializeComponent();
        }

        string id_form = "121";
        public crm.entidades.factura FacturaActual { get; set; }
        private void frm_abonos_Load(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            //textBox1.Clear();
            //textBox7.Clear();
            textBox2.Clear();
            textBox4.Clear();
            //textBox3.Clear();
            comboBox1.ResetText();
            textBox6.Clear();
            //textBox8.Clear();
            dtp1.ResetText();
        }

        private void habilitar()
        {
            //textBox1.Enabled = true;
            //textBox7.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            //textBox3.Enabled = true;
            comboBox1.Enabled = true;
            textBox6.Enabled = true;
            //textBox8.Enabled = true;
            dtp1.Enabled = true;
        }

        private void deshabilitar()
        {
            //textBox1.Enabled = false;
            //textBox7.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            //textBox3.Enabled = false;
            comboBox1.Enabled = false;
            textBox6.Enabled = false;
            //textBox8.Enabled = false;
            dtp1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            crm.negocio cnegocio = new crm.negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dataGridView1.DataSource = cnegocio.consultar();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            crm.entidades.Abono abono = new crm.entidades.Abono();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            crm.negocio cnegocio = new crm.negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            abono.id_factura = textBox3.Text;                                //Llenamos el objeto persona con la informacion de los cuadros de texto/
            //abono.serie = textBox7.Text;
            abono.id_cliente = textBox5.Text;
            //abono.saldo_factura = Convert.ToDouble(textBox6.Text);
            //abono.forma_pago = textBox3.Text;
            abono.forma_pago = comboBox1.Text;
            abono.abono = Convert.ToDouble(textBox6.Text);
            abono.fecha = Convert.ToString(dtp1);
            cnegocio.InsertarAbono(abono);                                    //Llamamos a la funcion Ninsertar a traves del objeto de la capa de negocio y le enviamos como parametro nuestro objeto persona
            limpiar();
            deshabilitar();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            frm_buscarfct BuscarFactura = new frm_buscarfct();
            BuscarFactura.ShowDialog();
            if (BuscarFactura.facturaselec != null)
            {
                FacturaActual = BuscarFactura.facturaselec;
                textBox2.Text = BuscarFactura.facturaselec.nombre_cliente;
                textBox4.Text = BuscarFactura.facturaselec.saldo_factura;
                textBox3.Text = Convert.ToString(BuscarFactura.facturaselec.id_factura);
                textBox5.Text = Convert.ToString(BuscarFactura.facturaselec.id_cliente);
                //txt_telefono.Text = frm.ProveedorSeleccionado.
                comboBox1.Text = BuscarFactura.facturaselec.forma_pago;
                //txt_observaciones.Text = frm.ProveedorSeleccionado.observ_prov;
               // txt_nit.Text = frm.ProveedorSeleccionado.nit_prov;


            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            crm.negocio cnegocio = new crm.negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dataGridView1.DataSource = cnegocio.consultar();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            crm.entidades.Abono abono = new crm.entidades.Abono();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            crm.negocio cnegocio = new crm.negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            abono.id_factura = textBox3.Text;                                //Llenamos el objeto persona con la informacion de los cuadros de texto/
            //abono.serie = textBox7.Text;
            abono.id_cliente = textBox5.Text;
            //abono.saldo_factura = Convert.ToDouble(textBox6.Text);
            //abono.forma_pago = textBox3.Text;
            abono.forma_pago = comboBox1.Text;
            abono.abono = Convert.ToDouble(textBox6.Text);
            abono.fecha = Convert.ToString(dtp1);
            cnegocio.InsertarAbono(abono);                                    //Llamamos a la funcion Ninsertar a traves del objeto de la capa de negocio y le enviamos como parametro nuestro objeto persona
            limpiar();
            deshabilitar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_buscarfct BuscarFactura = new frm_buscarfct();
            BuscarFactura.ShowDialog();
            if (BuscarFactura.facturaselec != null)
            {
                FacturaActual = BuscarFactura.facturaselec;
                textBox2.Text = BuscarFactura.facturaselec.nombre_cliente;
                textBox4.Text = BuscarFactura.facturaselec.saldo_factura;
                textBox3.Text = Convert.ToString(BuscarFactura.facturaselec.id_factura);
                textBox5.Text = Convert.ToString(BuscarFactura.facturaselec.id_cliente);
                //txt_telefono.Text = frm.ProveedorSeleccionado.
                comboBox1.Text = BuscarFactura.facturaselec.forma_pago;
                //txt_observaciones.Text = frm.ProveedorSeleccionado.observ_prov;
                // txt_nit.Text = frm.ProveedorSeleccionado.nit_prov;


            }

        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(dataGridView1);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(dataGridView1);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(dataGridView1);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(dataGridView1);
        }
    }
}
