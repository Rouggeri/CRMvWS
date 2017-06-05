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
using System.Data;

namespace proyectoUOne
{
    public partial class Cotizacion : Form
    {
        public Cotizacion()
        {
            InitializeComponent();
            //llenarComboDescrpicion();
            Bodega();
            //LlenarProducto();
        }

        CapaDatos capa = new CapaDatos();
        public void Bodega()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = capa.CargarBodegas();
                cmb_bodega.DataSource = dt;
                cmb_bodega.DisplayMember = "nombre_bodega";
                cmb_bodega.ValueMember = "id_bodega";
            }
            catch
            {
                MessageBox.Show("");
            }
        }


        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                dtpFechaI.Format = DateTimePickerFormat.Custom;
                dtpFechaI.CustomFormat = "yyyy-MM-dd";

                dtpFechaT.Format = DateTimePickerFormat.Custom;
                dtpFechaT.CustomFormat = "yyyy-MM-dd";
                CapaDatos inserta = new CapaDatos();

                double totals = Convert.ToDouble(txt_total.Text);
                inserta.InsertarCotizacion(dtpFechaI.Text, dtpFechaT.Text, totals, temporalNumeroAdquirido);
            CapaDatos v = new CapaDatos();
            int codigoAutoIncremente = CapaDatos.ConsultaUatoIncrementCotizacion();    
            /*
                
                DataTable dt1 = CapaDatos.CargarGridAutoIncrement("select AUTO_INCREMENT from information_schema.TABLES where TABLE_SCHEMA='prueba' and TABLE_NAME='cotizacion_encabezado';");
                DataRow rows = dt1.Rows[0];
                int id_req = Convert.ToInt32(rows[0]);*/

                foreach (DataGridViewRow row in dgvCotizacion.Rows)
                {
                    int codigo_cotizacionN = codigoAutoIncremente - 1;
                    int codigo_productoN = Convert.ToInt32(row.Cells[0].Value);
                    int CodigoMarca = Convert.ToInt32(row.Cells[2].Value);
                    int cantidadN = Convert.ToInt32(row.Cells[4].Value);
                    double precio = Convert.ToDouble(row.Cells[5].Value);
                    double subttotalN = Convert.ToDouble(row.Cells[6].Value);
                    v.insertar_detalle_cotizacion(codigo_cotizacionN, codigo_productoN, CodigoMarca, cantidadN, precio, subttotalN);
                }
                MessageBox.Show("Cotizacion Guardada Exitosamente :) ");
                this.Close();
            }
            catch {
                MessageBox.Show("Error al guardar datos de insercion");
            }
        }

        
        public void button1_Click(object sender, EventArgs e)
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
                        dgvCotizacion.Rows.Add(ProductoID, Nombre, MarcaID, NombreMark, cantidad, PrecioUnidad1, SubTotal);
                        //dgv_facturaDetalle.Rows.Insert(0, cmb_codigo.SelectedValue.ToString(), cmb_descripcion.SelectedValue.ToString(), txt_cantidad.Text, cmb_prueba.SelectedValue.ToString(), subtotall);
                        int suma = 0;
                        foreach (DataGridViewRow row in dgvCotizacion.Rows)
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
            catch
            {
                MessageBox.Show("No se agrego ningun producto");
            }       
        }
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

        public void LlenarProducto()
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


        private void Cotizacion_Load(object sender, EventArgs e)
        {
            ControlProducto.Enabled = false;
            ClienteData.Enabled = false;
            CapaDatos cap = new CapaDatos();
            //cap.llenar_id_pro(cmbCodigo);
            int codigoAutoIncremente = CapaDatos.ConsultaUatoIncrementCotizacion();
            lbl_codigoAuto.Text = Convert.ToString(codigoAutoIncremente);
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

        }

        //Eliminar fila de datagrid con opcion de cancelar
        private void dgvCotizacion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Desea Eliminar la Fila? ", " Message of Option Delete ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgvCotizacion.Rows.RemoveAt(dgvCotizacion.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fila Vacia U Otro Error");
            }
        }


        private void btn_buscarCliente_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                BuscarCliente abir = new BuscarCliente();
                this.Hide();
                abir.ShowDialog();

                if (!String.IsNullOrEmpty(abir.codigoC) && !String.IsNullOrEmpty(abir.nitC) && !String.IsNullOrEmpty(abir.nombreC) &&
                            !String.IsNullOrEmpty(abir.apellidoC) && !String.IsNullOrEmpty(abir.direccionC) && !String.IsNullOrEmpty(abir.telefonoC))
                {
                    temporalNumeroAdquirido = abir.codigoC;
                    txtCliente.Text = abir.nombreC;
                    txtTelefono.Text = abir.apellidoC;
                    txt_tipo.Text = abir.tipo;
                    this.Show();
                    ControlProducto.Enabled = true;
                    LlenarProducto();
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar formulario");
            }*/
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Desea Eliminar la Fila? ", " Message of Option Delete ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgvCotizacion.Rows.RemoveAt(dgvCotizacion.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fila Vacia U Otro Error");
            }
        }

        private void ClienteData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Desea Salir de Esta Ventana? ", " Message of Option Delete ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de carga de formulario");
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

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
            catch { MessageBox.Show("Error de text changed de cmb_prodcuto"); }

        }

        private void cmb_bodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarProducto();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            ClienteData.Enabled = true;

        }

        public string temporalNumeroAdquirido;
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCliente abir = new BuscarCliente();
                this.Hide();
                abir.ShowDialog();

                if (!String.IsNullOrEmpty(abir.codigoC) && !String.IsNullOrEmpty(abir.nitC) && !String.IsNullOrEmpty(abir.nombreC) &&
                            !String.IsNullOrEmpty(abir.apellidoC) && !String.IsNullOrEmpty(abir.direccionC) && !String.IsNullOrEmpty(abir.telefonoC))
                {
                    temporalNumeroAdquirido = abir.codigoC;
                    txtCliente.Text = abir.nombreC;
                    txtTelefono.Text = abir.apellidoC;
                    txt_tipo.Text = abir.tipo;
                    this.Show();
                    ControlProducto.Enabled = true;
                    LlenarProducto();
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar formulario");
            }
        }
    }
}
