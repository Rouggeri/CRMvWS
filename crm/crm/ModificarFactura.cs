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

namespace proyectoUOne
{
    public partial class ModificarFactura : Form
    {
        public ModificarFactura()
        {

            InitializeComponent();
            llenarFacturaCombo();
            btn_buscar.Enabled = false;
        }
        public void llenarFacturaCombo()
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "select id_factura from factura_encabezado;";
                OdbcCommand cmd = new OdbcCommand(query, con);
                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                cmb_cotizaciones.ValueMember = "id_factura";
                cmb_cotizaciones.DisplayMember = "id_factura";
                cmb_cotizaciones.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Error al llenar combobox codigo cotizacion");
            }
        }

        public void ObtenerCodigoCliente() {
            try
            {
                int temporal = Convert.ToInt32(cmb_cotizaciones.SelectedValue.ToString());
                DataTable cargas = CapaDatos.CargarGridAutoIncrement("select id_cliente from factura_encabezado where id_factura="+cmb_cotizaciones.SelectedValue.ToString()+";");
                DataRow codigoS = cargas.Rows[0];
                string idCLientes = Convert.ToString(codigoS[0]);
                txt_codigoTemporal.Text = idCLientes;
            }
            catch {
                MessageBox.Show("Error de Carga");
            }
        }


        public void llenarTipoPago()
        {
            try
            {
                cmb_pago.Items.Add("Contado");
                cmb_pago.Items.Add("Credito");
            }
            catch
            {
                MessageBox.Show("Errorr al llenar combo manualmente");
            }
        }

        public void cargardetalleFacturaYEncabezado()
        {
            try
            {
                CapaDatos v = new CapaDatos();

                DataTable dt0 = CapaDatos.CargarGridAutoIncrement("select fecha, forma_pago, total, id_cliente from factura_encabezado where id_factura = " + cmb_cotizaciones.SelectedValue.ToString() + ";");
                DataRow fecha = dt0.Rows[0];
                DataRow formaPago = dt0.Rows[0];
                DataRow Total = dt0.Rows[0];
                DataRow id_cliente = dt0.Rows[0];


                DateTime fechaC = Convert.ToDateTime(fecha[0]);
                string formaPagoC = Convert.ToString(formaPago[1]);
                string totalC = Convert.ToString(Total[2]);
                string idCLiente = Convert.ToString(id_cliente[3]);
                int tempo = Convert.ToInt32(idCLiente);

                DataTable dt2 = CapaDatos.CargarGridAutoIncrement("select id_cliente, nit, nombres, apellidos, telefono from tbl_cliente where id_cliente = "+tempo+";");
                DataRow codigoSS = dt2.Rows[0];
                DataRow nit = dt2.Rows[0];
                DataRow nombre = dt2.Rows[0];
                DataRow apellido = dt2.Rows[0];
                DataRow telefono = dt2.Rows[0];

                dtp_fecha.Text = fechaC.ToString();
                //cmb_pago.Text = formaPagoC.ToString();
                txt_total.Text = totalC.ToString();
               

                txt_nit.Text = Convert.ToString(nit[1]);
                txt_nombre.Text = Convert.ToString(nombre[2]);
                txt_apellido.Text = Convert.ToString(apellido[3]);
                txt_telefono.Text = Convert.ToString(telefono[4]);

                DataTable dt1 = CapaDatos.CargarDetalleFactura(cmb_cotizaciones.SelectedValue.ToString());
                dgv_facturaDetalle.DataSource = dt1;
            }
            catch {
                MessageBox.Show("Error al cargar detalle Factura y encabezado");
            }
            
        }

        private void cmb_cotizaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_pago.Items.Clear();

                cargardetalleFacturaYEncabezado();
                llenarTipoPago();
                //cmb_empleado.Items.Clear();
                //llenarEmpleado();
            }
            catch {
                MessageBox.Show("Error al cargar");
            }
        }

        private void btn_buscarCliente_Click(object sender, EventArgs e)
        {
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //formato para los datatimepicker   
                dtp_fecha.Format = DateTimePickerFormat.Custom;
                dtp_fecha.CustomFormat = "yyyy-MM-dd";               
                    CapaDatos db = new CapaDatos();

                    string id_factura = Convert.ToString(cmb_cotizaciones.SelectedValue.ToString());
                    string tipo_pago =  Convert.ToString(cmb_pago.SelectedItem.ToString());
                    string total = Convert.ToString(txt_total.Text.Trim());
                    int codigoTempo = Convert.ToInt32(txt_codigoTemporal.Text);

                    db.ActualziarFacturaEncabezado(dtp_fecha.Text.Trim(), tipo_pago, total, codigoTempo, id_factura);
                    MessageBox.Show("Se Modifico el Registro de Factura");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ModificarFactura_Load(object sender, EventArgs e)
        {
            //llenarEmpleado();
            ObtenerCodigoCliente();
            
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCliente abrir = new BuscarCliente();
                this.Hide();
                abrir.ShowDialog();

                if (!String.IsNullOrEmpty(abrir.codigoC) && !String.IsNullOrEmpty(abrir.nitC) && !String.IsNullOrEmpty(abrir.nombreC) &&
                            !String.IsNullOrEmpty(abrir.apellidoC) && !String.IsNullOrEmpty(abrir.direccionC) && !String.IsNullOrEmpty(abrir.telefonoC))
                {
                    txt_codigoTemporal.Text = abrir.codigoC;
                    txt_nit.Text = abrir.nitC;
                    txt_nombre.Text = abrir.nombreC;
                    txt_apellido.Text = abrir.apellidoC;
                    txt_telefono.Text = abrir.direccionC;
                    txt_telefono.Text = abrir.telefonoC;

                    this.Show();
                }

                else
                {
                    MessageBox.Show("Para cotizar necesita seleccionar un cliente");
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar");
            }
        }
    }
}
