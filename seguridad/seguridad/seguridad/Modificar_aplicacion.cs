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
    public partial class Modificar_aplicacion : Form
    {
        public Modificar_aplicacion()
        {
            InitializeComponent();
        }
        bitacora bitacora = new bitacora();
        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    //se abre conexion y se modifica la base de datos con los datos nuevos ingresados
                    OdbcConnection con = Conexion.ObtenerConexionODBC();
                    string id_aplicacion = textBox1.Text.Trim();
                    string nombre_aplicacion = textBox2.Text.Trim();
                    //string quey = "update asignacionprueba.salon set id_edificio='"+this.cbo_edificio.SelectedItem.ToString()+"',tamaño='"+this.txt_tamanio.Text+"',capacidad_aprox='"+this.txt_cantaprox.Text+"',estatus='"+this.cbo_estatus.SelectedItem.ToString()+"' where no_salon='"+no_salon+"';";
                    OdbcCommand comando = new OdbcCommand("update aplicacion set nombre_aplicacion='" + nombre_aplicacion  + "' where id_aplicacion='" + id_aplicacion + "';", Conexion.ObtenerConexionODBC());
                    comando.ExecuteNonQuery();
                    bitacora.Modificar("Modificacion de aplicacion: "+textBox1.Text.Trim()+"--"+textBox2.Text.Trim(),"aplicacion");
                    MessageBox.Show("Actualizacion Exitosa");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Modificar_aplicacion_Load(object sender, EventArgs e)
        {

        }
    }
}
  