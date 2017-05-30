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
    public partial class frmbuscexistencia : Form
    {
        public frmbuscexistencia()
        {
            InitializeComponent();
        }

        private void btn_buscexis_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_exis.DataSource = Clsopexis.Buscar(txt_exis.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

        }
    }
}
