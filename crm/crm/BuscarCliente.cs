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
    public partial class BuscarCliente : Form
    {
        public string codigoC;
        public string nitC;
        public string nombreC;
        public string apellidoC;
        public string direccionC;
        public string telefonoC;
        public string tipo;
        public BuscarCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void dgv_buscarCliente_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Factura vista = new Factura();
                //Ponemos los valores del datagridview en variables globales publicas
                codigoC = this.dgv_buscarCliente.CurrentRow.Cells[0].Value.ToString();              
                nombreC = this.dgv_buscarCliente.CurrentRow.Cells[1].Value.ToString();
                apellidoC = this.dgv_buscarCliente.CurrentRow.Cells[2].Value.ToString();
                direccionC = this.dgv_buscarCliente.CurrentRow.Cells[3].Value.ToString();
                telefonoC = this.dgv_buscarCliente.CurrentRow.Cells[4].Value.ToString();
                tipo = this.dgv_buscarCliente.CurrentRow.Cells[5].Value.ToString();
                nitC = this.dgv_buscarCliente.CurrentRow.Cells[6].Value.ToString();
                //Despues se llamara desde otro formulario las variables globales decalaradas aqui

                if (!String.IsNullOrEmpty(codigoC) && !String.IsNullOrEmpty(nitC) && !String.IsNullOrEmpty(nombreC) &&
                    !String.IsNullOrEmpty(apellidoC) && !String.IsNullOrEmpty(direccionC) && !String.IsNullOrEmpty(telefonoC))
                {                  
                    this.Close();
                }
                else {
                    MessageBox.Show("Campos vacíos");
                }
            }
            catch {
                MessageBox.Show("No se cargo ningun cliente de la base de datos");
            }
            
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable carga = CapaDatos.ConsultaCodigoYNombre(txt_buscar.Text);
                dgv_buscarCliente.DataSource = carga;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
