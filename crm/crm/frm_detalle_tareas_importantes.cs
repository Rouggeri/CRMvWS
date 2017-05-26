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
    public partial class frm_detalle_tareas_importantes : Form
    {
        public frm_detalle_tareas_importantes()
        {
            InitializeComponent();
        }


        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        public DataTable dt_hijo = new DataTable();

        public void frm_detalle_tareas_importantes_Load(object sender, EventArgs e)
        {
            frm_pronostico pronostico = new frm_pronostico();
            dgv_hijo_secundario.DataSource = dt_hijo;

            DataRow row = dt_hijo.Rows[0];
            lbl_empresa.Text = row["Empresa"].ToString();
            lbl_clt_nom1.Text = row["Nombre1_clt"].ToString()+" "+ row["Nombre2_clt"].ToString();           
            lbl_fecha_cierre.Text = row["Fecha_cierre"].ToString();
            lbl_monto_real.Text = "Q. "+ row["Monto"].ToString();
            lbl_rep_nom1.Text = row["Nombre1_resp"].ToString()+" "+ row["Nombre2_resp"].ToString();
            lbl_titulo.Text = row["Titulo"].ToString();
            


        }
    }
}
