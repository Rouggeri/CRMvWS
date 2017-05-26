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
                inserta.InsertarCotizacion(txtCliente.Text.Trim(), txtTelefono.Text.Trim(), dtpFechaI.Text.Trim(), dtpFechaT.Text.Trim());

                CapaDatos v = new CapaDatos();
                DataTable dt1 = CapaDatos.CargarGridAutoIncrement("select AUTO_INCREMENT from information_schema.TABLES where TABLE_SCHEMA='crmbd' and TABLE_NAME='cotizacion_encabezado';");
                DataRow rows = dt1.Rows[0];
                int id_req = Convert.ToInt32(rows[0]);

                foreach (DataGridViewRow row in dgvCotizacion.Rows)
                {
                    int codigo_cotizacionN = id_req - 1;
                    int codigo_productoN = Convert.ToInt32(row.Cells[0].Value);
                    int cantidadN = Convert.ToInt32(row.Cells[3].Value);
                    double subttotalN = Convert.ToDouble(row.Cells[4].Value);
                    v.insertar_detalle_cotizacion(codigo_cotizacionN, codigo_productoN, cantidadN, subttotalN);
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
                //this.Hide();
                abir.ShowDialog();

                Factura fac = new Factura();
                CapaDatos nuev = new CapaDatos();
                string codigoP = abir.dgv_productosVista.CurrentRow.Cells[0].Value.ToString();
                string decripcionP = abir.dgv_productosVista.CurrentRow.Cells[1].Value.ToString();
                string precioUP = abir.dgv_productosVista.CurrentRow.Cells[2].Value.ToString();
                string precioMayor = abir.dgv_productosVista.CurrentRow.Cells[3].Value.ToString();
                  string decidido = "";
                int primero = Convert.ToInt32(txt_tipo.Text);
                                if (primero == 1)
                                {
                                    decidido = precioUP;
                                }
                                if (primero == 2)
                                {
                                    decidido = precioMayor;
                                }
                double temporal1 = Convert.ToDouble(abir.txt_cantidad.Text);
                int temporal2 = Convert.ToInt32(decidido);
                double subtot = temporal1 * temporal2;
                string SubtotalP = Convert.ToString(subtot);




                if (!String.IsNullOrEmpty(codigoP) && !String.IsNullOrEmpty(decripcionP) && !String.IsNullOrEmpty(precioUP) &&
                                                !String.IsNullOrEmpty(SubtotalP))
                {


                    dgvCotizacion.Rows.Add(codigoP, decripcionP, abir.txt_cantidad.Text, decidido, SubtotalP);
                    //dgv_facturaDetalle.Rows.Insert(0, cmb_codigo.SelectedValue.ToString(), cmb_descripcion.SelectedValue.ToString(), txt_cantidad.Text, cmb_prueba.SelectedValue.ToString(), subtotall);

                    int suma = 0;
                    foreach (DataGridViewRow row in dgvCotizacion.Rows)
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
                MessageBox.Show("Error al agregar a detalle");
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
                    //this.Close();
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
            
        }
    }
}
