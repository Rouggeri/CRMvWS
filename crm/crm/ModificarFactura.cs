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

                DataTable dt0 = CapaDatos.CargarGridAutoIncrement("select * from factura_encabezado where id_factura = " + cmb_cotizaciones.SelectedValue.ToString() + ";");
                DataRow fecha = dt0.Rows[0];
                DataRow formaPago = dt0.Rows[0];
                DataRow Total = dt0.Rows[0];
                DataRow id_cliente = dt0.Rows[0];


                DateTime fechaC = Convert.ToDateTime(fecha[1]);
                string formaPagoC = Convert.ToString(formaPago[2]);
                string totalC = Convert.ToString(Total[3]);
                string idCLiente = Convert.ToString(id_cliente[5]);
                int tempo = Convert.ToInt32(idCLiente);

                DataTable dt2 = CapaDatos.CargarGridAutoIncrement("select * from cliente_m where id_cliente = " + tempo + ";");
                DataRow codigoSS = dt2.Rows[0];
                DataRow nit = dt2.Rows[0];
                DataRow nombre = dt2.Rows[0];
                DataRow apellido = dt2.Rows[0];
                DataRow direccion = dt2.Rows[0];
                DataRow telefono = dt2.Rows[0];

                dtp_fecha.Text = fechaC.ToString();
                cmb_pago.Text = formaPagoC.ToString();
                txt_total.Text = totalC.ToString();

                txt_nit.Text = Convert.ToString(nit[1]);
                txt_nombre.Text = Convert.ToString(nombre[2]);
                txt_apellido.Text = Convert.ToString(apellido[3]);
                txt_direccion.Text = Convert.ToString(direccion[4]);
                txt_telefono.Text = Convert.ToString(telefono[5]);


                DataTable dt1 = CapaDatos.CargarGridAutoIncrement("select * from detalle_factura where id_factura = " + cmb_cotizaciones.SelectedValue.ToString() + ";");
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
            }
            catch {
                MessageBox.Show("Error al cargar");
            }

        }

        private void btn_buscarCliente_Click(object sender, EventArgs e)
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
                    txt_direccion.Text = abrir.direccionC;
                    txt_telefono.Text = abrir.telefonoC;

                    this.Show();
                }

                else
                {
                    MessageBox.Show("Para cotizar necesita seleccionar un cliente");
                }
            }
            catch {
                MessageBox.Show("Error al cargar");
            }
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //formato para los datatimepicker   
                dtp_fecha.Format = DateTimePickerFormat.Custom;
                dtp_fecha.CustomFormat = "yyyy-MM-dd";               
                    CapaDatos db = new CapaDatos();
                    string id_factura = cmb_cotizaciones.SelectedValue.ToString();
                    string factura_id = Convert.ToString(id_factura);
                    string temp = cmb_pago.SelectedItem.ToString();
                    string temp1 = Convert.ToString(txt_total.Text.Trim());
                    int temporales = Convert.ToInt32(txt_codigoTemporal.Text);
                    string temp3 = Convert.ToString(temporales);

                    db.ActualziarFacturaEncabezado(dtp_fecha.Text.Trim(), temp, temp1, temporales, factura_id);
                    MessageBox.Show("correcto");
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ModificarFactura_Load(object sender, EventArgs e)
        {
            ObtenerCodigoCliente();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

        }
    }
}
