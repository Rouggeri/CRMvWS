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
    public partial class frm_morosos : Form
    {
        private OdbcDataAdapter OdbcDataAdapter;
        private OdbcCommand OdbcCommand;
        int conti;

        public frm_morosos()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string nombres = "";
            int cont = 0;
            nombres = textBox1.Text;
            DataTable fill = new DataTable();
            //MessageBox.Show(nombres);
            try
            {
                OdbcCommand = new OdbcCommand(
                     string.Format("SELECT id_cliente, nombres, apellidos, telefono, estado, incidencia FROM tbl_cliente WHERE nombres ='{0}'", nombres),
                     seguridad.Conexion.ObtenerConexionODBC()
                 );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                OdbcDataAdapter = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                OdbcDataAdapter.SelectCommand = OdbcCommand;      //ejecutamos el query de consulta
                OdbcDataAdapter.Fill(fill);                 //poblamos el sqlDataAdaptor con el resultado del query

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            dataGridView1.DataSource = fill;
            DataRow dt1 = fill.Rows[0];
            //DataColumn dt2 = fill.Columns[5];
             string incidencia = fill.Rows[0][5].ToString();
             string id_cliente = Convert.ToString(dt1[0]);
            textBox2.Text = Convert.ToString(dt1[0]);
            textBox3.Text = Convert.ToString(incidencia);
            //MessageBox.Show(Convert.ToString(dt1[0]));
            //MessageBox.Show(Convert.ToString(incidencia));
            
           // MessageBox.Show(Convert.ToString(dt2));

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            int id_cliente;
            int incidencia;
            

            if (conti == 0)
            { 
                id_cliente = Convert.ToInt32(textBox2.Text);
                incidencia = Convert.ToInt32(textBox3.Text);
                DataTable agrega = new DataTable();
                incidencia++;
                //MessageBox.Show(Convert.ToString(id_cliente));
                //MessageBox.Show(Convert.ToString(incidencia));
                //MessageBox.Show(nombres);
                try
                {
                
                    OdbcCommand = new OdbcCommand(
                         string.Format("UPDATE tbl_cliente SET incidencia = '"+incidencia+"' WHERE id_cliente  ='{0}'", id_cliente),
                         seguridad.Conexion.ObtenerConexionODBC()
                     );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                    OdbcDataAdapter = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                    OdbcDataAdapter.SelectCommand = OdbcCommand;      //ejecutamos el query de consulta
                    OdbcDataAdapter.Fill(agrega);                 //poblamos el sqlDataAdaptor con el resultado del query
                    conti++;


                }
                catch (Exception Ex)
                {
                    MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (conti != 0)
                {
                    dataGridView1.ClearSelection();
                    DataTable refresca = new DataTable();
                    OdbcCommand = new OdbcCommand(
                         string.Format("SELECT id_cliente, nombres, apellidos, telefono, estado, incidencia FROM tbl_cliente WHERE id_cliente ='{0}'", id_cliente),
                         seguridad.Conexion.ObtenerConexionODBC()
                     );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                    OdbcDataAdapter = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                    OdbcDataAdapter.SelectCommand = OdbcCommand;      //ejecutamos el query de consulta
                    OdbcDataAdapter.Fill(refresca);                 //poblamos el sqlDataAdaptor con el resultado del query
                    conti++;
                    dataGridView1.DataSource = refresca;
                }
          }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int id_cliente;
            int incidencia;
            int resta;
            dataGridView1.ClearSelection();

            id_cliente = Convert.ToInt32(textBox2.Text);
            incidencia = Convert.ToInt32(textBox3.Text);
            DataTable agrega = new DataTable();
            resta= incidencia - 1;
            //MessageBox.Show(Convert.ToString(incidencia));
            //MessageBox.Show(Convert.ToString(resta));

            //MessageBox.Show(nombres);
            if (conti == 0)
            { 
            try
            {

                OdbcCommand  = new OdbcCommand(
                     string.Format("UPDATE tbl_cliente SET incidencia = '" + resta + "' WHERE id_cliente  ='{0}'", id_cliente),
                     seguridad.Conexion.ObtenerConexionODBC()
                 );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                    OdbcDataAdapter = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                    OdbcDataAdapter.SelectCommand = OdbcCommand;      //ejecutamos el query de consulta
                    OdbcDataAdapter.Fill(agrega);                 //poblamos el sqlDataAdaptor con el resultado del query
                    conti++;


            }
            catch (Exception Ex)
            {
                MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                if (conti != 0)
                {
                    dataGridView1.ClearSelection();
                    DataTable refresca = new DataTable();
                    OdbcCommand  = new OdbcCommand(
                         string.Format("SELECT id_cliente, nombres, apellidos, telefono, estado, incidencia FROM tbl_cliente WHERE id_cliente ='{0}'", id_cliente),
                         seguridad.Conexion.ObtenerConexionODBC()
                     );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                    OdbcDataAdapter = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                    OdbcDataAdapter.SelectCommand = OdbcCommand;      //ejecutamos el query de consulta
                    OdbcDataAdapter.Fill(refresca);                 //poblamos el sqlDataAdaptor con el resultado del query
                    conti++;
                    dataGridView1.DataSource = refresca;
                }
          }
        }
    }
}
