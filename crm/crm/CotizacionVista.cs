using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoUOne
{
    public partial class CotizacionVista : Form
    {
        public CotizacionVista()
        {
            InitializeComponent();
            cargarDetalle();
            Modificacion.Enabled = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Cotizacion nuevo = new Cotizacion();
            nuevo.Show();
        }

        public void cargarDetalle() {
            try
            {
                DataTable cargas = CapaDatos.CargarGridAutoIncrement("select * from cotizacion_encabezado;");
                dgv_CotizacionVista.DataSource = cargas;
            }
            catch {
                MessageBox.Show("Error al cargar");
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            cargarDetalle();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try { 
            Modificacion.Enabled = true;

            string CodigoC = this.dgv_CotizacionVista.CurrentRow.Cells[0].Value.ToString();

            string clienteC = this.dgv_CotizacionVista.CurrentRow.Cells[1].Value.ToString();
            string correoC = this.dgv_CotizacionVista.CurrentRow.Cells[2].Value.ToString();
            string fechaInicioC = this.dgv_CotizacionVista.CurrentRow.Cells[3].Value.ToString();
            string fechaTerminaC = this.dgv_CotizacionVista.CurrentRow.Cells[4].Value.ToString();

            txt_codigoTemporal.Text = CodigoC.Trim();
            txtCliente.Text = clienteC.Trim();
            txtTelefono.Text = correoC.Trim();
            dtpFechaI.Text = fechaInicioC.Trim();
            dtpFechaT.Text = fechaTerminaC.Trim();
        }
        catch{
                MessageBox.Show("Error al cargar");
        }

        }
        
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
                    //txt_codigoTemporal.Text = abir.codigoC;
                    txtCliente.Text = abir.nombreC;
                    txtTelefono.Text = abir.apellidoC;
                    //this.Close();
                    this.Show();
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar formulario");
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //formato para los datatimepicker   
                dtpFechaI.Format = DateTimePickerFormat.Custom;
                dtpFechaI.CustomFormat = "yyyy-MM-dd";
                dtpFechaT.Format = DateTimePickerFormat.Custom;
                dtpFechaT.CustomFormat = "yyyy-MM-dd";
                CapaDatos db = new CapaDatos();

                string id_cotizacionO = txt_codigoTemporal.Text;
                string nombreT = txtCliente.Text;
                string TelefonoT = txtTelefono.Text;
                string fechaInn = dtpFechaI.Text;
                string fechaTerr = dtpFechaT.Text;

                db.ActualziarCotizacionEncabezado(nombreT, TelefonoT, dtpFechaI.Text.Trim(), dtpFechaT.Text.Trim(), id_cotizacionO);
                MessageBox.Show("correcto");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Desea Eliminar la Fila? ", " Message of Option Delete ", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        CapaDatos abrir = new CapaDatos();
                        string CodigoC = this.dgv_CotizacionVista.CurrentRow.Cells[0].Value.ToString();
                        abrir.ActualizaEstado(CodigoC);
                    }              
            }
            catch {
                MessageBox.Show("Error al borrar");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
