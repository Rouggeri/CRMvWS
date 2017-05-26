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

namespace seguridad
{
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
        }
        bitacora bitacora = new bitacora();
        string parametro1;
        string parametro2;
        string parametro3;
        string query = "";
        string consulta = "Select * from bitacora where ";
        private void button1_Click(object sender, EventArgs e)
        {

            cmb_usuario.Enabled = false;
            cmb_operacion.Enabled = false;
            cmb_tabla.Enabled = false;
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;

            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                creaquery();
                MessageBox.Show(query);
                OdbcDataAdapter da = new OdbcDataAdapter(query, con);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    parametro1 = "";
                    parametro2 = "";
                    parametro3 = "";
                }
                else
                {
                    MessageBox.Show("No se tienen datos del usuario");
                }
                cmb_usuario.SelectedIndex = -1;
                cmb_operacion.SelectedIndex = -1;
                cmb_tabla.SelectedIndex = -1;
            }
            catch
            {
                MessageBox.Show("Sin privilegios", "¡Seguridad!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                button1.Enabled = false;
            }
        }
        
        
            private void Historial_Load(object sender, EventArgs e)
        {
            try {
            parametro1 = "";
            parametro2 = "";
            parametro3 = "";
            }
            catch
            {
                MessageBox.Show("Sin privilegios", "¡Seguridad!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        
            
        }

        private void cmb_operacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cmb_usuario_SelectedValueChanged(object sender, EventArgs e)
        {


        }

        private void cmb_operacion_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmb_usuario.Enabled = true;
            label1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            label2.Enabled = true;
            try
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                DataTable dt = new DataTable();
                dt = ss.ObtenerUsuarios();
                cmb_usuario.DataSource = dt;
                cmb_usuario.DisplayMember = "usuario";
                cmb_usuario.ValueMember = "usuario";
            }

            catch
            {
                MessageBox.Show("Sin privilegios", "¡Seguridad!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Enabled = true;
            cmb_operacion.Enabled = true;
            try
            {
                DataTable dt = new DataTable();
                dt = bitacora.ObtenerOperaciones();
                if (dt.Rows.Count != 0)
                {
                    cmb_operacion.DataSource = dt;
                    cmb_operacion.DisplayMember = "descripcion";
                    cmb_operacion.ValueMember = "descripcion";
                }
                else
                {
                    cmb_operacion.SelectedIndex = -1;
                }
            }
            catch
            {
                MessageBox.Show("Sin privilegios", "¡Seguridad!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled=false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Enabled = true;
            cmb_tabla.Enabled = true;
            try
            {
                DataTable dt = new DataTable();
                dt = bitacora.ObtenerTablas();
                if (dt.Rows.Count != 0)
                {
                    cmb_tabla.DataSource = dt;
                    cmb_tabla.DisplayMember = "tabla";
                    cmb_tabla.ValueMember = "tabla";
                }
                else
                {
                    cmb_tabla.SelectedIndex = -1;
                }
            }
            catch
            {
                MessageBox.Show("Sin privilegios", "¡Seguridad!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = false;
            }
        }

        private void cmb_tabla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_tabla_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        public void creaquery()
        {

            if (cmb_usuario.SelectedIndex != -1)
            {
                parametro1 = "usuario='" + cmb_usuario.SelectedValue + "'";
            }
            else
            {
                parametro1 = "";
            }
            if (cmb_operacion.SelectedIndex != -1)
            {
                if (cmb_usuario.SelectedIndex != -1)
                {
                    parametro2 = " AND descripcion='" + cmb_operacion.SelectedValue + "'";
                }
                else
                {
                    parametro2 = "descripcion='" + cmb_operacion.SelectedValue + "'";
                }

            }
            else
            {
                parametro2 = "";
            }
            if (cmb_tabla.SelectedIndex != -1)
            {
                if ((cmb_usuario.SelectedIndex != -1)||(cmb_operacion.SelectedIndex != -1))
                {
                    parametro3 = " AND tabla='" + cmb_tabla.SelectedValue + "'";
                }
                else
                {
                    parametro3 = "tabla='" + cmb_tabla.SelectedValue + "'";
                }

            }
            else
            {
                parametro3 = "";
            }
            if (parametro1 =="" && parametro2 =="" && parametro3 =="")
                query = "Select * from bitacora order by id_bit DESC";
            else
            query = consulta + parametro1 + parametro2 + parametro3 +"Order by id_bit DESC";

        }
    }
}

