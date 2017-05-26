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
    public partial class frm_puesto_nuevo : Form
    {
        public frm_puesto_nuevo()
        {
            InitializeComponent();
        }
        CapaDatosPersonas capadatos = new CapaDatosPersonas();

        private void button7_Click(object sender, EventArgs e)
        {
            capadatos.InsertarNuevoPuesto(txt_puesto.Text.Trim(),txt_descripcion.Text.Trim());
        }
    }
}
