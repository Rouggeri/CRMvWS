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
    public partial class frm_busqueda_fecha_personalizada : Form
    {
        public frm_busqueda_fecha_personalizada()
        {
            InitializeComponent();
        }

        public  string fecha_personaliz_ini;
        public  string fecha_personaliz_fin;

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
             fecha_personaliz_ini = dtp_fecha_inicial.DateTime.ToString("yyyy-MM-dd");
             fecha_personaliz_fin = dtp_fecha_final.DateTime.ToString("yyyy-MM-dd");
        }
    }
}
