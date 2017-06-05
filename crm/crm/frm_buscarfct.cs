using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm
{
    public partial class frm_buscarfct : Form
    {
        public frm_buscarfct()
        {
            InitializeComponent();
        }
        public crm.entidades.factura facturaselec { get; set; }
       // public entidades.factura facturaselec { get; set;}
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = crm.datos.Buscar(Convert.ToInt32(textBox1.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id_factura = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                facturaselec = crm.datos.ObtenerFactura(id_factura);
                //MessageBox.Show();

                this.Close();
            }
            else
                MessageBox.Show("debe de seleccionar una fila");
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_buscarfct_Load(object sender, EventArgs e)
        {

        }
    }
}
