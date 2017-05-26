using MySql.Data.MySqlClient;
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

namespace Cobros
{
    public partial class Cuenta : Form
    {
        public Cuenta()
        {
            InitializeComponent();
        }
        private static OdbcCommand odbcComando;
        private static OdbcDataAdapter odbcDataAdapter;
        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string cte = "";
                cte = textBox1.Text;
                DataTable fill = new DataTable();
                MessageBox.Show(cte);
                try
                {
                      odbcComando  = new OdbcCommand(
                         string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'activo'  AND tbl_cliente.nombres ='{0}'", cte),
                         seguridad.Conexion.ObtenerConexionODBC()
                     );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                    odbcDataAdapter = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                    odbcDataAdapter.SelectCommand = odbcComando;      //ejecutamos el query de consulta
                    odbcDataAdapter.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dataGridView1.DataSource = fill;
            }
            else
            {
                if (radioButton2.Checked)
                {
                    string cte = "";
                    cte = textBox1.Text;
                    DataTable fill = new DataTable();
                    MessageBox.Show(cte);
                    try
                    {
                        odbcComando  = new OdbcCommand(
                             string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'cancelado'  AND tbl_cliente.nombres ='{0}'", cte),
                             seguridad.Conexion.ObtenerConexionODBC()
                         );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                        odbcDataAdapter = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                        odbcDataAdapter.SelectCommand = odbcComando;      //ejecutamos el query de consulta
                        odbcDataAdapter.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dataGridView1.DataSource = fill;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string cte = "";
                cte = textBox1.Text;
                DataTable fill = new DataTable();
                MessageBox.Show(cte);
                try
                {
                     odbcComando = new OdbcCommand(
                         string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'activo'  AND tbl_cliente.nombres ='{0}'", cte),
                         seguridad.Conexion.ObtenerConexionODBC()
                     );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                    odbcDataAdapter = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                    odbcDataAdapter.SelectCommand = odbcComando;      //ejecutamos el query de consulta
                    odbcDataAdapter.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dataGridView1.DataSource = fill;
            }
            else
            {
                if (radioButton2.Checked)
                {
                    string cte = "";
                    cte = textBox1.Text;
                    DataTable fill = new DataTable();
                    MessageBox.Show(cte);
                    try
                    {
                         odbcComando = new OdbcCommand(
                             string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'cancelado'  AND tbl_cliente.nombres ='{0}'", cte),
                             seguridad.Conexion.ObtenerConexionODBC()
                         );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                        odbcDataAdapter = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                        odbcDataAdapter.SelectCommand = odbcComando;      //ejecutamos el query de consulta
                        odbcDataAdapter.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dataGridView1.DataSource = fill;
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
