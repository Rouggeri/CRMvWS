using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
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

        private void button1_Click(object sender, EventArgs e)
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM bitacora";
           OdbcDataAdapter da = new OdbcDataAdapter(query, con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            else
                MessageBox.Show("Error");

        }

        private void Historial_Load(object sender, EventArgs e)
        {

           
        }
    }
}
