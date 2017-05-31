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
                    int cantidadN = Convert.ToInt32(row.Cells[2].Value);
                    double precio = Convert.ToDouble(row.Cells[3].Value);
                    double subttotalN = Convert.ToDouble(row.Cells[4].Value);
                    v.insertar_detalle_cotizacion(codigo_cotizacionN, codigo_productoN, cantidadN, precio, subttotalN);
                }

            }
            catch {
                MessageBox.Show("Error al guardar datos de insercion");
            }
        }

        
        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarProducto abir = new BuscarProducto();
                string temporales = txt_tipo.Text;         
                abir.txt_ratos.Text = temporales;   //Enviar datos a formulario buscar producto
                abir.ShowDialog(); //abrir formulario BuscarProducto

                Factura fac = new Factura();
                CapaDatos nuev = new CapaDatos();
                string codigoP = abir.dgv_productosVista.CurrentRow.Cells[0].Value.ToString();
                string decripcionP = abir.dgv_productosVista.CurrentRow.Cells[1].Value.ToString();
                string precioUP = abir.dgv_productosVista.CurrentRow.Cells[2].Value.ToString();

                double precios = Convert.ToDouble(precioUP);
                double temporal1 = Convert.ToDouble(abir.txt_cantidad.Text);
                double subtot = temporal1 * precios;
                string SubtotalP = Convert.ToString(subtot);

                if (!String.IsNullOrEmpty(codigoP) && !String.IsNullOrEmpty(decripcionP) && !String.IsNullOrEmpty(precioUP) &&
                                               !String.IsNullOrEmpty(SubtotalP))
                {
                    string cantidadD = Convert.ToString(abir.cmb_existencia.SelectedValue.ToString());
                    int cantidadOri = Convert.ToInt32(cantidadD);
                    int cantidadPuesta = Convert.ToInt32(abir.txt_cantidad.Text);
                    if (cantidadOri < cantidadPuesta)
                    {
                        MessageBox.Show("Existencia Baja");
                    }
                    if (cantidadPuesta <= cantidadOri)
                    {
                    dgvCotizacion.Rows.Add(codigoP, decripcionP, abir.txt_cantidad.Text, precioUP, SubtotalP);
                    //dgv_facturaDetalle.Rows.Insert(0, cmb_codigo.SelectedValue.ToString(), cmb_descripcion.SelectedValue.ToString(), txt_cantidad.Text, cmb_prueba.SelectedValue.ToString(), subtotall);

                    int suma = 0;
                    foreach (DataGridViewRow row in dgvCotizacion.Rows)
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
            catch
            {
                MessageBox.Show("No se agrego ningun producto");
            }       
        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {

            CapaDatos cap = new CapaDatos();
            //cap.llenar_id_pro(cmbCodigo);
            
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


        public string temporalNumeroAdquirido;
        private void btn_buscarCliente_Click(object sender, EventArgs e)
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
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar formulario");
            }
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
    }
}
