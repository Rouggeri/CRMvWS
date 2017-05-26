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
    public partial class agregarapp : Form
    {
        public agregarapp()
        {
            InitializeComponent();
        }
        Clasemanejo cm = new Clasemanejo();
        bitacora bitacora = new bitacora();
        private void button1_Click(object sender, EventArgs e)
        {
            try

            {
                int resultado = Clasemanejo.agregaraplicacion(textBox1.Text, textBox2.Text);
                DataTable dt = new DataTable();
                if (resultado > 0)
                {
                    bitacora.Insertar("Registro de aplicacion: "+textBox1.Text.Trim() +"--"+ textBox2.Text.Trim(), "aplicacion");
                    MessageBox.Show("Aplicacion Agregada Exitosamente");
                    dt = cm.Refrescar();
                    dataGridView1.DataSource = dt;
                    
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la Aplicacion");
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    


        private void button2_Click(object sender, EventArgs e)
        {
            //envia como parametro a el formulario de modificacion los datos seleccionados en el gridview
            Modificar_aplicacion ed = new Modificar_aplicacion();
            try
            {
                string id_aplicacion = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                string nombre_aplicacion = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
               
                ed.textBox1.Text= id_aplicacion;
                ed.textBox2.Text = nombre_aplicacion;
                //ed.cbo_edificio.Items.Add(id_edificio);
                // ed.cbo_edificio.SelectedIndex = 0;
              


                ed.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    //se abre la conexion a la base de datos y se elemina el campo seleccionado de la base de datos
                    OdbcConnection con = Conexion.ObtenerConexionODBC();

                    string id_aplicacion = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                    DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar La aplicaciòn?", "Aceptar", MessageBoxButtons.OKCancel);
                    if (resultado == DialogResult.OK)
                    {
                        string query = "delete from aplicacion where id_aplicacion = '" + id_aplicacion + "'";
                        OdbcCommand comando = new OdbcCommand(query, con);
                        comando.ExecuteNonQuery();
                        bitacora.Eliminar("Eliminacion de aplicacion: " + id_aplicacion, "aplicacion");
                        DataTable dtd = new DataTable();
                        string query1 = "select * from aplicacion";
                        OdbcCommand cmd = new OdbcCommand(query1, con);
                        OdbcDataAdapter ad = new OdbcDataAdapter(cmd);
                        ad.Fill(dtd);
                        dataGridView1.DataSource = dtd;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void agregarapp_Load(object sender, EventArgs e)
        {
             try
             {

                {
                    DataTable dt = Clasemanejo.cargar("select * from aplicacion");
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Id Aplicacion";
                    dataGridView1.Columns[1].HeaderText = "Nombre Aplicacion";

                }
            }
            catch { MessageBox.Show("no tiene permisos"); }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
