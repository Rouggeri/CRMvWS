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

    public partial class Factura : Form
    {
        public int variable_temporal;
        public Factura()
        {
            try
            {
                InitializeComponent();
                //llenarCotizacion();
                cmb_cotizaciones.Enabled = false;
                llenarTipoPago();
                dgv_facturaDetalle.DataSource = null;
            }
            catch
            {
                MessageBox.Show("Error de Inicializacion");
            }
        }

        public void llenarCotizacion()
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "select id_cotizacion from cotizacion_encabezado WHERE estadoCotizacion='ESPERA';";
                OdbcCommand cmd = new OdbcCommand(query, con);
                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                cmb_cotizaciones.ValueMember = "id_cotizacion";
                cmb_cotizaciones.DisplayMember = "id_cotizacion";
                cmb_cotizaciones.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Error al llenar combobox codigo cotizacion");
            }

        }


        //cargar datagridview a traves del codigo cotizacion
        public void cargardetalle()
        {
            try
            {
                columnas();
                int tempo = Convert.ToInt32(cmb_cotizaciones.SelectedValue.ToString());
                DataTable dt;
                dt = CapaDatos.ConsultadetalleCotizacion(tempo);
                double suma = 0;
                foreach (DataRow row in dt.Rows)
                {
                    int codigoD = Convert.ToInt32(row[0].ToString().Trim());
                    DataTable dt2 = CapaDatos.CargarGridAutoIncrement("select descripcion from producto_m where id_producto = " + codigoD + ";");
                    DataRow rowi = dt2.Rows[0];
                    string ronald = Convert.ToString(rowi[0]);
                    int cantidadD = Convert.ToInt32(row[1].ToString().Trim());
                    DataTable dt5 = CapaDatos.CargarGridAutoIncrement("select precio_unidad from producto_m where id_producto = " + codigoD + ";");
                    DataRow dete = dt5.Rows[0];
                    string caris = Convert.ToString(dete[0]);
                    double final = Convert.ToDouble(caris);

                    double subtotalD = Convert.ToDouble(row[2].ToString().Trim());
                    //dgv_facturaDetalle.Rows.Insert(0, codigo_facturaM, codigoD, cantidadD, subtotalD);
                    dgv_facturaDetalle.Rows.Add(codigoD, ronald, cantidadD, final, subtotalD);
                    //suma += Convert.ToDouble(row.Cells[].Value);
                    suma += Convert.ToDouble(row[2].ToString().Trim());
                }
                txt_total.Text = Convert.ToString(suma);

            }
            catch
            {
                MessageBox.Show("error al llamdo de cotizacion detalle");
            }

        }

        //Guardar datos de factura, cliente y detalle factura
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //formato para los datatimepicker   
                dtp_fecha.Format = DateTimePickerFormat.Custom;
                dtp_fecha.CustomFormat = "yyyy-MM-dd";

                if (!String.IsNullOrEmpty(txt_nombre.Text.Trim()) && !String.IsNullOrEmpty(txt_apellido.Text.Trim()) &&
                    !String.IsNullOrEmpty(txt_direccion.Text.Trim()) && !String.IsNullOrEmpty(txt_telefono.Text.Trim()) &&
                    cmb_pago.SelectedIndex != -1)
                {
                    CapaDatos db = new CapaDatos();
                    //Manejo db = new Manejo();
                    string temp = cmb_pago.SelectedItem.ToString();
                    double temp1 = Convert.ToDouble(txt_total.Text.Trim());
                    int temp3 = Convert.ToInt32(txt_temporal.Text.Trim());
                    db.GuardarFacturaEncabezado(dtp_fecha.Text.Trim(), temp, temp1, temp3);

                    CapaDatos v = new CapaDatos();
                    DataTable dt1 = CapaDatos.CargarGridAutoIncrement("select AUTO_INCREMENT from information_schema.TABLES where TABLE_SCHEMA='crmbd' and TABLE_NAME='factura_encabezado';");
                    DataRow rows = dt1.Rows[0];
                    int id_req = Convert.ToInt32(rows[0]);

                    foreach (DataGridViewRow row in dgv_facturaDetalle.Rows)
                    {
                        int codigo_facturaM = id_req - 1;
                        int codigo_productoM = Convert.ToInt32(row.Cells[0].Value);
                        int cantidadM = Convert.ToInt32(row.Cells[3].Value);
                        double subtotalM = Convert.ToDouble(row.Cells[4].Value);
                        v.insertar_detalle_factura(codigo_facturaM, codigo_productoM, cantidadM, subtotalM);
                    } //termina mi foreach      

                            
                }
                if (chb_habilita.Checked) {
                        CapaDatos nuevo = new CapaDatos();
                        string temporales = cmb_cotizaciones.SelectedValue.ToString();
                        nuevo.ActualizaEstadoPedidoCotizacion(temporales);
                    }  
            }
            catch
            {
                MessageBox.Show("Error al Guardar datos de insercion");
            }
        }

        private void btn_buscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCliente abir = new BuscarCliente();
                //this.Hide();
                abir.ShowDialog();
                
                if (!String.IsNullOrEmpty(abir.codigoC) && !String.IsNullOrEmpty(abir.nitC) && !String.IsNullOrEmpty(abir.nombreC) &&
                            !String.IsNullOrEmpty(abir.apellidoC) && !String.IsNullOrEmpty(abir.direccionC) && !String.IsNullOrEmpty(abir.telefonoC))
                {
                    txt_temporal.Text = abir.codigoC;
                    txt_nit.Text = abir.nitC;
                    txt_nombre.Text = abir.nombreC;
                    txt_apellido.Text = abir.apellidoC;
                    txt_direccion.Text = abir.direccionC;
                    txt_telefono.Text = abir.telefonoC;
                    txt_tipo.Text = abir.tipo;
                    //this.Close();
                    //this.Show();
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar formulario");
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

        }

        //Llenar data
        private void cmb_cotizaciones_DataSourceChanged(object sender, EventArgs e)
        {
            //llenarCotizacion();
        }

        //Condicion de checkBox
        private void chb_habilita_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Factura non = new Factura();
                if (chb_habilita.Checked)
                {
                    llenarCotizacion();
                    eliminarCOlumndas();
                    cmb_cotizaciones.Enabled = true;
                    cargardetalle();
                    non.Refresh();
                }
                if (!chb_habilita.Checked)
                {
                    eliminarCOlumndas();
                    dgv_facturaDetalle.DataSource = null;
                    cmb_cotizaciones.Enabled = false;
                    columnas();
                    txt_total.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Error al abrir");
            }
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            dgv_facturaDetalle.DataSource = null;
        }

        //Poner encabezado a columnas de una tabla datagridview
        public void columnas()
        {
            try
            {
                dgv_facturaDetalle.ColumnCount = 5;
                dgv_facturaDetalle.ColumnHeadersVisible = true;

                // Set the column header style.
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("Arial", 8, FontStyle.Regular);
                dgv_facturaDetalle.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                // Set the column header names.
                dgv_facturaDetalle.Columns[0].Name = "codigo";
                dgv_facturaDetalle.Columns[1].Name = "descripcion";
                dgv_facturaDetalle.Columns[2].Name = "cantidad";
                dgv_facturaDetalle.Columns[3].Name = "precioU";
                dgv_facturaDetalle.Columns[4].Name = "subtotal";
            }
            catch
            {
                MessageBox.Show("Error al poner nombre a columnas");
            }

        }

        //Eliminar columnas de un datagridview
        public void eliminarCOlumndas()
        {
            try
            {
                dgv_facturaDetalle.Columns.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Eliminar fila de un datagrid con opcion de cancelar
        private void dgv_facturaDetalle_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Desea Eliminar la Fila? ", " Message of Option Delete ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgv_facturaDetalle.Rows.RemoveAt(dgv_facturaDetalle.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fila Vacia U Otro Error");
            }
        }

        //llenar combobox tipo pago
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

        private void cmb_cotizaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            eliminarCOlumndas();
            cargardetalle();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chb_habilita.Checked)
                {
                    eliminarCOlumndas();
                    cargardetalle();
                }
                if (!chb_habilita.Checked)
                {
                    eliminarCOlumndas();
                    dgv_facturaDetalle.DataSource = null;
                    cmb_cotizaciones.Enabled = false;
                    columnas();
                }
            }
            catch
            {
                MessageBox.Show("error al actulizar");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Desea Eliminar la Fila? ", " Message of Option Delete ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgv_facturaDetalle.Rows.RemoveAt(dgv_facturaDetalle.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fila Vacia U Otro Error");
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            ModificarFactura abrir = new ModificarFactura();
            abrir.Show();
            this.Close();
        }

        private void btn_agregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarProducto abir = new BuscarProducto();
                //this.Hide();
                abir.ShowDialog();

            Factura fac = new Factura();
            CapaDatos nuev = new CapaDatos();
            string codigoP = abir.dgv_productosVista.CurrentRow.Cells[0].Value.ToString();
            string decripcionP = abir.dgv_productosVista.CurrentRow.Cells[1].Value.ToString();
            string precioUP = abir.dgv_productosVista.CurrentRow.Cells[2].Value.ToString();
                string precioMayor = abir.dgv_productosVista.CurrentRow.Cells[3].Value.ToString();
            double temporal1 = Convert.ToDouble(abir.txt_cantidad.Text);
                string decidido = "";
                int primero = Convert.ToInt32(txt_tipo.Text);
                 if (primero == 1) {
                    decidido = precioUP;
                }
                if (primero == 2) {
                    decidido = precioMayor;
                }
          int temporal2 = Convert.ToInt32(decidido);
            double subtot = temporal1 * temporal2;
                string SubtotalP = Convert.ToString(subtot);
              

              
              

            if (!String.IsNullOrEmpty(codigoP) && !String.IsNullOrEmpty(decripcionP) && !String.IsNullOrEmpty(precioUP) &&
                                            !String.IsNullOrEmpty(SubtotalP) )
                                {


                    dgv_facturaDetalle.Rows.Add(codigoP, decripcionP, abir.txt_cantidad.Text, decidido, SubtotalP);
                    //dgv_facturaDetalle.Rows.Insert(0, cmb_codigo.SelectedValue.ToString(), cmb_descripcion.SelectedValue.ToString(), txt_cantidad.Text, cmb_prueba.SelectedValue.ToString(), subtotall);

                    int suma = 0;
                    foreach (DataGridViewRow row in dgv_facturaDetalle.Rows)
                    {
                        suma += Convert.ToInt32(row.Cells["subtotal"].Value);
                        //suma += (int)row.Cells["Subtotal"].Value;
                    }
                    txt_total.Text = Convert.ToString(suma);
                    abir.txt_cantidad.Text = "";
                    //this.Close();
                }
                //this.Show();
                
            }
            catch
            {
                MessageBox.Show("Error al cargar formulario");
            }
        }
    }
}
