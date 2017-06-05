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
        private static OdbcCommand mySqlComando;
        private static OdbcDataAdapter mySqlDAdAdaptador;
        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        /*private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string cte = "";
                cte = textBox1.Text;
                DataTable fill = new DataTable();
                MessageBox.Show(cte);
                try
                {
                    OdbcCommand mySqlComando = new OdbcCommand(
                         string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'activo'  AND tbl_cliente.nombres ='{0}'", cte),
                         seguridad.Conexion.ObtenerConexionODBC()
                     );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                    mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                    mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                    mySqlDAdAdaptador.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

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
                        OdbcCommand mySqlComando = new OdbcCommand(
                             string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'cancelado'  AND tbl_cliente.nombres ='{0}'", cte),
                             seguridad.Conexion.ObtenerConexionODBC()
                         );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                        mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                        mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                        mySqlDAdAdaptador.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dataGridView1.DataSource = fill;
                }
            }
        }

       /* private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string cte = "";
                cte = textBox1.Text;
                DataTable fill = new DataTable();
                MessageBox.Show(cte);
                try
                {
                    OdbcCommand mySqlComando = new OdbcCommand(
                         string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'activo'  AND tbl_cliente.nombres ='{0}'", cte),
                         seguridad.Conexion.ObtenerConexionODBC()
                     );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                    mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                    mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                    mySqlDAdAdaptador.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dataGridView1.DataSource = fill;
            }
            else
            {
                /*if (radioButton2.Checked)
                {
                    string cte = "";
                    cte = textBox1.Text;
                    DataTable fill = new DataTable();
                    MessageBox.Show(cte);
                    try
                    {
                        OdbcCommand mySqlComando = new OdbcCommand(
                             string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'cancelado'  AND tbl_cliente.nombres ='{0}'", cte),
                             seguridad.Conexion.ObtenerConexionODBC()
                         );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                        mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                        mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                        mySqlDAdAdaptador.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dataGridView1.DataSource = fill;
                }*/
            //}
       // }

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

        private void button2_Click(object sender, EventArgs e)
        {
            int contador = 0;
            int cliente = 0;
            string inicio = "";
            string final = "";
            inicio = dateTimePicker1.Text;
            final = dateTimePicker2.Text;
            /*
             * 
*/

            if (textBox1.Text != null)
            {
                string cte = "";
                cte = textBox1.Text;
                int identificador = 0;
                DataTable id = new DataTable();
                try
                {
                    OdbcCommand mySqlComando = new OdbcCommand(
                                string.Format("SELECT id_cliente FROM tbl_cliente WHERE nombres = '" + cte + "'")
                                , crm.Conexion.ObtenerConexion()
                        );

                    mySqlDAdAdaptador = new OdbcDataAdapter();
                    mySqlDAdAdaptador.SelectCommand = mySqlComando;
                    mySqlDAdAdaptador.Fill(id);
                    //dataGridView1.DataSource = id;
                    DataRow dt1 = id.Rows[0];
                    identificador = Convert.ToInt32(dt1[0]);
                    cliente = identificador;
                    contador++;

                }
                catch (OdbcException exception)
                {
                    MessageBox.Show(Convert.ToString(exception));
                }if(contador != 0)
                {
                    DataTable full = new DataTable();
                    try
                    {
                        OdbcCommand mySqlComando = new OdbcCommand(
                                    string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, factura_encabezado.forma_pago, factura_encabezado.total, factura_encabezado.tipo_documento FROM factura_encabezado, tbl_cliente WHERE factura_encabezado.id_cliente ='" + cliente + "' UNION SELECT abonos.id_abono, abonos.fecha, abonos.forma_pago, abonos.abono, abonos.tipo_documento FROM factura_encabezado,abonos, tbl_cliente WHERE abonos.id_cliente ='" + cliente + "' ORDER BY fecha")
                                    , crm.Conexion.ObtenerConexion()
                            );

                        mySqlDAdAdaptador = new OdbcDataAdapter();
                        mySqlDAdAdaptador.SelectCommand = mySqlComando;
                        mySqlDAdAdaptador.Fill(full);
                        dataGridView1.DataSource = full;

                    }
                    catch (MySqlException exception)
                    {
                        MessageBox.Show(Convert.ToString(exception));
                    }
                }
            }
            /*if (radioButton1.Checked)
            {
                string cte = "";
                cte = textBox1.Text;
                DataTable fill = new DataTable();
                MessageBox.Show(cte);
                try
                {
                    OdbcCommand mySqlComando = new OdbcCommand(
                         string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'activo'  AND tbl_cliente.nombres ='{0}'", cte),
                         seguridad.Conexion.ObtenerConexionODBC()
                     );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                    mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                    mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                    mySqlDAdAdaptador.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

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
                        OdbcCommand mySqlComando = new OdbcCommand(
                             string.Format("SELECT factura_encabezado.id_factura, factura_encabezado.fecha, tbl_cliente.nombres, tbl_cliente.apellidos, factura_encabezado.forma_pago, factura_encabezado.estado from factura_encabezado,tbl_cliente WHERE factura_encabezado.estado = 'cancelado'  AND tbl_cliente.nombres ='{0}'", cte),
                             seguridad.Conexion.ObtenerConexionODBC()
                         );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                        mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                        mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                        mySqlDAdAdaptador.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    dataGridView1.DataSource = fill;
                }
            }*/

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
