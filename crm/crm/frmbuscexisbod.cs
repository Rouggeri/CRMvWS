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
    public partial class frmbuscexisbod : Form
    {
        public frmbuscexisbod()
        {
            InitializeComponent();
        }



        private void dgv_exis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmbuscexisbod_Load(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_exis.DataSource = cnegocio.consultaexistenciabod();
        }

        private void btn_buscexis_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_exis.DataSource = null;
                dgv_exis.DataSource = datos.BuscarExis(txt_exis.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
