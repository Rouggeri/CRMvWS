using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seguridad
{
    public partial class Form_infouser : Form
    {
        public Form_infouser()
        {
            InitializeComponent();
        }

        private void Form_infouser_Load(object sender, EventArgs e)
        {
            try
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                DataTable dt = new DataTable();
                label6.Text = Conexion.User;
                dt = ss.encuentra_colaborador(Conexion.User);
                //DataRow dr= dt.Rows[0];
                //MessageBox.Show(dr["id_empleados_pk"].ToString());
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBox1.Text = (dr["empresa"].ToString() + '-' + dr["empleado"].ToString());
                        textBox2.Text = dr["nombre"].ToString();
                        textBox3.Text = dr["dpi"].ToString();
                        textBox4.Text = dr["fecha_nacimiento"].ToString();
                        textBox5.Text = dr["fecha_ingreso"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar datos de colaborador");
                }
            }
            catch { }

        }
    }
}
