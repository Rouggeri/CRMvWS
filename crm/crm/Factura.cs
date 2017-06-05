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
using System.Configuration;

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
                //Bodega();
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
                /*DataTable emp = new DataTable();
                emp = capa.CargarEmpleados();
                cmb_empleado.DataSource = emp;
                cmb_empleado.ValueMember = "id_empleado";
                cmb_empleado.DisplayMember = "nombres";*/

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
           
                Factura fac = new Factura();
                CapaDatos nuev = new CapaDatos();
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
                    string BodegaID = Convert.ToString(cmb_bodega.SelectedValue.ToString());
                    db.GuardarFacturaEncabezado(dtp_fecha.Text.Trim(), formaPago, sumaTotal, IdCliente, empleados, BodegaID);

                    int codigoAutoIncrement = CapaDatos.ConsultaUatoIncrementFactura();
                    CapaDatos v = new CapaDatos();
                    /*DataTable dt1 = CapaDatos.CargarGridAutoIncrement("select AUTO_INCREMENT from information_schema.TABLES where TABLE_SCHEMA='prueba' and TABLE_NAME='factura_encabezado';");
                    DataRow rows = dt1.Rows[0];
                    int codigoObtenido = Convert.ToInt32(rows[0]);*/
                    int MiBodega2 = Convert.ToInt32(BodegaID);
                    foreach (DataGridViewRow row in dgv_facturaDetalle.Rows)
                    {
                        int codigo_facturaM = codigoAutoIncrement - 1;
                        int codigo_productoM = Convert.ToInt32(row.Cells[0].Value);
                        int idMarca = Convert.ToInt32(row.Cells[2].Value);
                        int Existencia2 = Convert.ToInt32(CapaDatos.ConsultaExistenciav1(Convert.ToString(codigo_productoM), BodegaID));
                        int cantidadM = Convert.ToInt32(row.Cells[4].Value);
                        int existenciaNueva = Existencia2 - cantidadM;
                        double precioM = Convert.ToDouble(row.Cells[5].Value);
                        double subtotalM = Convert.ToDouble(row.Cells[6].Value);
                        v.ActualziarExistencia(existenciaNueva, codigo_productoM, idMarca, MiBodega2);
                        v.insertar_detalle_factura(codigo_facturaM, codigo_productoM, idMarca, cantidadM, precioM, subtotalM);
                    } //termina mi foreach
                    MessageBox.Show("Se Actualizo Existencia");     
                }
                
                if (chb_habilita.Checked) {
                        CapaDatos nuevo = new CapaDatos();
                        string temporales = cmb_cotizaciones.SelectedValue.ToString();
                        nuevo.ActualizaEstadoPedidoCotizacion(temporales);
                    }
                MessageBox.Show(" Se Guardo Factura Exitosamente ");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error al Guardar datos de insercion");
            }
        }
        public int IncidenciaFinal;
        public void BuscarCliente()
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
                    ProductoControl.Enabled = true;
                    TextLLeno();
                    int incidenciaParcial = CapaDatos.ConsultaInsidencia(txt_temporal.Text);
                    IncidenciaFinal = incidenciaParcial;
                    
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar formulario");
            }
        }

        private void btn_buscarCliente_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            cmb_marca.Enabled = false;
            ClienteControl.Enabled = true;
            //ProductoControl.Enabled = true;
            Bodega();
            //TextLLeno();
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
                    ProductoControl.Enabled = false;
                    controlCotizacion.Enabled = true;
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
                    //cmb_cotizaciones.Items.Clear();
                    //ProductoControl.Enabled = true;
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
            try
            {
                string enviaCodigo = Convert.ToString(cmb_cotizaciones.SelectedValue.ToString());
                int codigoRecibe = CapaDatos.ConsultacodigoClienteCotizacion(enviaCodigo);
                globalCodigo = Convert.ToString(codigoRecibe);
            }
            catch { MessageBox.Show("No hay Cotizaciones"); }
        }

        //metodo para cargar la coleccion de datos para el autocomplete
        public AutoCompleteStringCollection AutocompleteV2()
        {
            string BodegaF = cmb_bodega.SelectedValue.ToString();
            CapaDatos nu = new CapaDatos();
            DataTable dt2 = nu.Datos(BodegaF);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt2.Rows)
            {
                coleccion.Add(Convert.ToString(row["nombre"]));
            }
            return coleccion;
        }

        public void TextLLeno()
        {
            //cargar los datos para el autocomplete del textbox
            CapaDatos capa = new CapaDatos();
            /*txt_codigo.AutoCompleteCustomSource = capa.Autocomplete();
            txt_codigo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_codigo.AutoCompleteSource = AutoCompleteSource.CustomSource;*/

            string bodegaSS = cmb_bodega.SelectedValue.ToString();
            // Cargo los datos que tendra el combobox
            cmb_producto.DataSource = capa.Datos(bodegaSS);
            cmb_producto.DisplayMember = "nombre";
            cmb_producto.ValueMember = "id_producto";
            

            // cargo la lista de items para el autocomplete dle combobox
            cmb_producto.AutoCompleteCustomSource = AutocompleteV2();
            cmb_producto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_producto.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }



        public void Factura_Load(object sender, EventArgs e)
        {
            int IDFACtura = CapaDatos.ConsultaUatoIncrementFactura();
            txt_motrarID.Text = Convert.ToString(IDFACtura);
            ProductoControl.Enabled = false;
            controlCotizacion.Enabled = false;
            ClienteControl.Enabled = false;
            //TextLLeno();
            FuncionCodigo();
            dgv_facturaDetalle.DataSource = null;
        }

        //Poner encabezado a columnas de una tabla datagridview
        public void columnas()
        {
            try
            {
                dgv_facturaDetalle.ColumnCount = 7;
                dgv_facturaDetalle.ColumnHeadersVisible = true;

                // Set the column header style.
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("Arial", 8, FontStyle.Regular);
                dgv_facturaDetalle.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                // Set the column header names.
                dgv_facturaDetalle.Columns[0].Name = "codigo";
                dgv_facturaDetalle.Columns[1].Name = "descripcion";
                dgv_facturaDetalle.Columns[2].Name = "Id Marca";
                dgv_facturaDetalle.Columns[3].Name = "Marca";
                dgv_facturaDetalle.Columns[4].Name = "Cantidad";
                dgv_facturaDetalle.Columns[5].Name = "PrecioUnidad";
                dgv_facturaDetalle.Columns[6].Name = "subtotal";
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


        public void Productos()
        {


        }

        public void Bodega() {
            try
            {
                DataTable dt = new DataTable();
                dt = capa.CargarBodegas();
                cmb_bodega.DataSource = dt;
                cmb_bodega.DisplayMember = "nombre_bodega";
                cmb_bodega.ValueMember = "id_bodega";
            }
            catch {
                MessageBox.Show("");
            }
        }

        public void btn_agregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int ProductoID = Convert.ToInt32(txt_codigo.Text);
                string Nombre = CapaDatos.DescripcionP(cmb_producto.SelectedValue.ToString());
                int MarcaID = Convert.ToInt32(cmb_marca.SelectedValue.ToString());
                string NombreMark = CapaDatos.NombreMarka(cmb_marca.SelectedValue.ToString());
                if (!String.IsNullOrEmpty(txt_cantidad.Text))
                {
                    int cantidad = Convert.ToInt32(txt_cantidad.Text);

                    double PrecioUnidad1 = Convert.ToDouble(txt_precioUnidad.Text);
                    double SubTotal = cantidad * PrecioUnidad1;

                    int ExistenciaF = Convert.ToInt32(txt_existencia.Text);

                    if (cantidad > ExistenciaF)
                    {
                        MessageBox.Show("Existencia Baja");
                    }
                    if (cantidad <= ExistenciaF)
                    {
                        dgv_facturaDetalle.Rows.Add(ProductoID, Nombre, MarcaID, NombreMark, cantidad, PrecioUnidad1, SubTotal);
                        //dgv_facturaDetalle.Rows.Insert(0, cmb_codigo.SelectedValue.ToString(), cmb_descripcion.SelectedValue.ToString(), txt_cantidad.Text, cmb_prueba.SelectedValue.ToString(), subtotall);
                        int suma = 0;
                        foreach (DataGridViewRow row in dgv_facturaDetalle.Rows)
                        {
                            suma += Convert.ToInt32(row.Cells["subtotal"].Value);
                            //suma += (int)row.Cells["Subtotal"].Value;
                        }
                        txt_total.Text = Convert.ToString(suma);
                        txt_cantidad.Text = "";
                    }
                }
                else { MessageBox.Show("Agrege Cantidad de Producto"); }
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

        private void ClienteData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void cmb_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_codigo.Text = Convert.ToString(cmb_producto.SelectedValue.ToString());


                DataTable dt = new DataTable();
                dt = CapaDatos.ConsultarMarca(cmb_producto.SelectedValue.ToString());
                cmb_marca.DataSource = dt;
                cmb_marca.DisplayMember = "nombre_marca";
                cmb_marca.ValueMember = "id_marca";
                string productoPP = Convert.ToString(cmb_producto.SelectedValue.ToString());

                double precioUN = CapaDatos.ConsultATipoPrecio(txt_tipo.Text, productoPP);
                string precioPP = Convert.ToString(precioUN);
                txt_precioUnidad.Text = precioPP;

                string bodegasP = Convert.ToString(cmb_bodega.SelectedValue.ToString());
                string recibeExistencia = Convert.ToString(CapaDatos.ConsultaExistenciav1(productoPP, bodegasP));
                txt_existencia.Text = recibeExistencia;
            }
            catch { MessageBox.Show("Error de text changed de cmb_producto"); }


        }

        private void cmb_bodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chb_habilita.Checked)
                    {
                    TextLLeno();
            }

        }

        private void btn_verifica_Click(object sender, EventArgs e)
        {
            btn_guardar.Enabled = true;
            cargardetalle();
            string BodegaID1 = Convert.ToString(cmb_bodega.SelectedValue.ToString());
            foreach (DataGridViewRow row in dgv_facturaDetalle.Rows)
            {
                string ProductoID1 = Convert.ToString(dgv_facturaDetalle.CurrentRow.Cells[0].Value.ToString());              
                int cantidad1 = Convert.ToInt32(dgv_facturaDetalle.CurrentRow.Cells[4].Value.ToString());
                int existencia1 = Convert.ToInt32(CapaDatos.ConsultaExistenciav1(ProductoID1, BodegaID1));
                if (cantidad1 > existencia1)
                {
                    dgv_facturaDetalle.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow;
                    btn_guardar.Enabled = false;
                }
            }
        }
    }
}
