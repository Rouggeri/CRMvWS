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
        public string globalCodigo;
        CapaDatos capa = new CapaDatos();
        public int variable_temporal;
        public Factura()
        {
            try
            {
                InitializeComponent();
                llenarCotizacion();
                cmb_cotizaciones.Enabled = false;
                llenarTipoPago();
                dgv_facturaDetalle.DataSource = null;
                llenarEmpleado();
                columnas();
            }
            catch
            {
                MessageBox.Show("Error de Inicializacion");
            }
        }

        //Metodo para llenar combobox Empleado - Vendedor
        private void llenarEmpleado() {
            try
            {
                crm.ServiceReference1.Service1Client srv = new crm.ServiceReference1.Service1Client();
                DataSet ds = srv.ObtenerEmpleados();
                DataTable dt_empleados = ds.Tables[0];
                DataRow row_emp = dt_empleados.NewRow();
                row_emp[0] = 0;
                row_emp[6] = "<Ninguno>";
                dt_empleados.Rows.InsertAt(row_emp, 0);
                cmb_empleado.DataSource = dt_empleados;
                cmb_empleado.ValueMember = "id_empleado_pk";
                cmb_empleado.DisplayMember = "NOMBRE";
            }
            catch
            {
                MessageBox.Show("No existe ningun empleado...");
            }
        }

        //Metodo para llenar Detalle y encabezado por Cotizacion
        public void LLamado() {
            try
            {
                llenarCotizacion();
                if (cmb_cotizaciones.Items.Count <= 0)
                {
                    MessageBox.Show("No hay detalle sin Encabezado");
                }
                else
                {
                    cargardetalle();
                    total();
                }
            }
            catch {
                MessageBox.Show("Error de try catch - pero se pudo");
            }
        }

        //Metodo para llenar combobox Cotizaciones Encabezado
        private void llenarCotizacion()
        {
            try
            {
                DataTable cotizacion = new DataTable();
                cotizacion = capa.CargarCotizacion();
                cmb_cotizaciones.DataSource = cotizacion;
                cmb_cotizaciones.ValueMember = "id_cotizacion";
                cmb_cotizaciones.DisplayMember = "id_cotizacion";
            }
            catch
            {
                MessageBox.Show("No hay cotizaciones registradas...");
            }
        }

        //Cargar datagridview a traves del codigo cotizacion
        public void cargardetalle()
        {
            /*try
            {*/   
            string tempo = Convert.ToString(cmb_cotizaciones.SelectedValue.ToString());
            DataTable dt = CapaDatos.CargarDetalleCotiza(tempo);
            dgv_facturaDetalle.DataSource = dt;

            /*}
            catch
            {
                MessageBox.Show("No hay Cotizacion en base de datos");
            }*/

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
                                         cmb_pago.SelectedIndex != -1)
                {
                    CapaDatos db = new CapaDatos();
                    //Manejo db = new Manejo();
                    string formaPago = cmb_pago.SelectedItem.ToString();
                    double sumaTotal = Convert.ToDouble(txt_total.Text.Trim());
                    int IdCliente = Convert.ToInt32(txt_temporal.Text.Trim());
                    string empleados = Convert.ToString(cmb_empleado.SelectedValue.ToString());
                    db.GuardarFacturaEncabezado(dtp_fecha.Text.Trim(), formaPago, sumaTotal, IdCliente, empleados);

                    int codigoAutoIncrement = CapaDatos.ConsultaUatoIncrementFactura();
                    CapaDatos v = new CapaDatos();
                    /*DataTable dt1 = CapaDatos.CargarGridAutoIncrement("select AUTO_INCREMENT from information_schema.TABLES where TABLE_SCHEMA='prueba' and TABLE_NAME='factura_encabezado';");
                    DataRow rows = dt1.Rows[0];
                    int codigoObtenido = Convert.ToInt32(rows[0]);*/

                    foreach (DataGridViewRow row in dgv_facturaDetalle.Rows)
                    {
                        int codigo_facturaM = codigoAutoIncrement - 1;
                        int codigo_productoM = Convert.ToInt32(row.Cells[0].Value);
                        int cantidadM = Convert.ToInt32(row.Cells[2].Value);
                        double precioM = Convert.ToDouble(row.Cells[3].Value);
                        double subtotalM = Convert.ToDouble(row.Cells[4].Value);
                        v.insertar_detalle_factura(codigo_facturaM, codigo_productoM, cantidadM, precioM, subtotalM);
                    } //termina mi foreach      
                }
                if (chb_habilita.Checked) {
                        CapaDatos nuevo = new CapaDatos();
                        string temporales = cmb_cotizaciones.SelectedValue.ToString();
                        nuevo.ActualizaEstadoPedidoCotizacion(temporales);
                    }
                
                BuscarProducto abir = new BuscarProducto();              
                Factura fac = new Factura();
                CapaDatos nuev = new CapaDatos();
                string IdProducto = abir.dgv_productosVista.CurrentRow.Cells[0].Value.ToString();
                string IdMarca = abir.dgv_productosVista.CurrentRow.Cells[5].Value.ToString();
                string IdCompra = abir.dgv_productosVista.CurrentRow.Cells[6].Value.ToString();
                string ExistenciaVieja = Convert.ToString(abir.cmb_existencia.SelectedValue.ToString());
                string Venta = Convert.ToString(abir.txt_cantidad.Text);
                int ventaF = Convert.ToInt32(Venta);
                int Existencia = Convert.ToInt32(ExistenciaVieja);
                int existenciaNueva = Existencia - ventaF;
                nuev.ActualziarExistencia(existenciaNueva, IdProducto, IdMarca, IdCompra);
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
                            !String.IsNullOrEmpty(abir.apellidoC))
                {
                    txt_temporal.Text = abir.codigoC;
                    txt_nit.Text = abir.nitC;
                    txt_nombre.Text = abir.nombreC;
                    txt_apellido.Text = abir.apellidoC;
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

        //Metodod de total cotizacion
        public void total() {
                if (cmb_cotizaciones.Items.Count <= 0)
                {
                    MessageBox.Show("No hay totales");
                }
                else
                {
            string envia = Convert.ToString(cmb_cotizaciones.SelectedValue.ToString());
            double recibe = CapaDatos.ConsultaTotal(envia);
            string recibeConvert = Convert.ToString(recibe);
            txt_total.Text = recibeConvert;
                }
        }

        public string codigoFi;
        public string nombreFi;
        public string apellidoFi;
        public string nitFi;
        //Metodo para cargar cliente por medio cotizacion
        public void ClientesCotizacion() {
            try
            {
                string codigoFac = globalCodigo;
                DataTable cliente = new DataTable();
                DataGridView contiene = new DataGridView();
                cliente = CapaDatos.ConsultaClientePaFactura(codigoFac);
                contiene.DataSource = cliente;

                DataRow rows = cliente.Rows[0];
                DataRow rows2 = cliente.Rows[0];
                DataRow rows3 = cliente.Rows[0];
                DataRow rows4 = cliente.Rows[0];

                string codigoOss = Convert.ToString(rows[0]);
                string nombress = Convert.ToString(rows2[1]);
                string apellidoss = Convert.ToString(rows3[2]);
                string nitss = Convert.ToString(rows4[3]);

                txt_temporal.Text = codigoOss;
                txt_nombre.Text = nombress;
                txt_apellido.Text = apellidoss;
                txt_nit.Text = nitss;
            }
            catch {
                MessageBox.Show("Errro de Llamado");
            }
        }

        // Limpiar datos de Cliente
        public void LimpiarCliente() {
            txt_temporal.Text = "";
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_nit.Text = "";
        }

        //Condicion de checkBox
        public void chb_habilita_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Factura non = new Factura();
                if (chb_habilita.Checked)
                {
                eliminarCOlumndas();
                    //llenarCotizacion();
                    cmb_cotizaciones.Enabled = true;
                    //cargardetalle();
                    LLamado();
                    ClientesCotizacion();
                    btn_agregarProducto.Enabled = false;
                    non.Refresh();
                }
                if (!chb_habilita.Checked)
                {
                    eliminarCOlumndas();
                    LimpiarCliente();
                    dgv_facturaDetalle.DataSource = null;
                    cmb_cotizaciones.Enabled = false;
                    columnas();
                    txt_total.Text = "";
                    btn_agregarProducto.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Error al abrir");
            }
        }
        public void FuncionCodigo() {
                string enviaCodigo = Convert.ToString(cmb_empleado.SelectedValue.ToString());
                int codigoRecibe = CapaDatos.ConsultacodigoClienteCotizacion(enviaCodigo);
                globalCodigo = Convert.ToString(codigoRecibe);
        }

        public void Factura_Load(object sender, EventArgs e)
        {
            FuncionCodigo();
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
                MessageBox.Show("Error al llenar combo manualmente");
            }
        }

        private void cmb_cotizaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            eliminarCOlumndas();
            cargardetalle();
            total();
            FuncionCodigo();
            ClientesCotizacion();
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

        public void btn_agregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarProducto abir = new BuscarProducto();
                string temporales = txt_tipo.Text; //ORDER BY nombre ASC               
                abir.txt_ratos.Text = temporales;
                //this.Hide();
                abir.ShowDialog();

                Factura fac = new Factura();
                CapaDatos nuev = new CapaDatos();
                string codigoP = abir.dgv_productosVista.CurrentRow.Cells[0].Value.ToString();
                string decripcionP = abir.dgv_productosVista.CurrentRow.Cells[1].Value.ToString();
                string precioUP = abir.dgv_productosVista.CurrentRow.Cells[2].Value.ToString();
                double cantidadP = Convert.ToDouble(abir.txt_cantidad.Text);
                double PrecioPP = Convert.ToDouble(precioUP);            
                double subtot = PrecioPP * cantidadP;
                string SubtotalP = Convert.ToString(subtot);

                if (!String.IsNullOrEmpty(codigoP) && !String.IsNullOrEmpty(decripcionP) && !String.IsNullOrEmpty(precioUP) &&
                                                !String.IsNullOrEmpty(SubtotalP))
                {
                string cantidadD = Convert.ToString(abir.cmb_existencia.SelectedValue.ToString());
                int cantidadOri = Convert.ToInt32(cantidadD);
                int cantidadPuesta = Convert.ToInt32(abir.txt_cantidad.Text);
                if(cantidadOri < cantidadPuesta)
                {
                    MessageBox.Show("Existencia Baja");
                }if (cantidadPuesta <= cantidadOri)
                {
                    dgv_facturaDetalle.Rows.Add(codigoP, decripcionP,  abir.txt_cantidad.Text, precioUP, SubtotalP);
                    //dgv_facturaDetalle.Rows.Insert(0, cmb_codigo.SelectedValue.ToString(), cmb_descripcion.SelectedValue.ToString(), txt_cantidad.Text, cmb_prueba.SelectedValue.ToString(), subtotall);
                    int suma = 0;
                    foreach (DataGridViewRow row in dgv_facturaDetalle.Rows)
                    {
                        suma += Convert.ToInt32(row.Cells["subtotal"].Value);
                        //suma += (int)row.Cells["Subtotal"].Value;
                    }
                    txt_total.Text = Convert.ToString(suma);
                    abir.txt_cantidad.Text = "";
                }
                    
                    //this.Close();
                }
                //this.Show();
            }
            catch {
                MessageBox.Show("No se agrego ningun producto");
            }
        }

        private void dgv_facturaDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            ClientesCotizacion();
        }
    }
}
