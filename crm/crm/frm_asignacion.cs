using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cobros
{
    public partial class frm_asignacion : Form
    {
        public frm_asignacion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = crm.datos.ObtenerClientes(textBox1.Text);
        }
    }
}
