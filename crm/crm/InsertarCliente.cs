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
    public partial class InsertarCliente : Form
    {
        public InsertarCliente()
        {
            InitializeComponent();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDatos db = new CapaDatos();
                int Temp1 = Convert.ToInt32(txt_nit.Text);
                int Temp2 = Convert.ToInt32(txt_telefono.Text);
                int temp3 = Convert.ToInt32(txt_tipo.Text);
                db.GuardarCliente(Temp1, txt_nombre.Text, txt_apellido.Text, txt_direccion.Text, Temp2, temp3);
                MessageBox.Show("Correcta Insercion");
                this.Close();
            }
            catch {
                MessageBox.Show("Error al guardar resgitro");
            }
            
        }

    }
}
