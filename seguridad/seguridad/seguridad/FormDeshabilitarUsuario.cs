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
    public partial class FormDeshabilitarUsuario : Form
    {
        public FormDeshabilitarUsuario()
        {
            InitializeComponent();
        }
        bitacora bitacora = new bitacora();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                cbo_usuario.DataSource = ObtenerUsuarios();
                cbo_usuario.DisplayMember = "usuario";
                cbo_usuario.ValueMember = "usuario";
                cbo_usuario.SelectedIndex = -1;
            }
            catch { MessageBox.Show("no tiene permisos"); }
        }

        public DataTable ObtenerUsuarios()
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select usuario from usuario", con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;
        }
        private void cbo_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_deshabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                int x = EliminarUsuarioBD(cbo_usuario.SelectedValue.ToString());
                int y = EliminarUsuario(cbo_usuario.SelectedValue.ToString());
                int z = EliminarPermisosPerfil(cbo_usuario.SelectedValue.ToString());
                if (x == 1 && y == 1 && z == 1)
                {

                    MessageBox.Show("deshabilitado con exito");
                }
                else
                {
                    MessageBox.Show("error al deshabilitar usuario");
                    bitacora.ErrorOp("Error al deshabilitar el usuario: " + cbo_usuario.SelectedValue, "usuario");
                }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }  

        }

        public int EliminarUsuarioBD(string usuario)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(" drop user '" + usuario + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                
                return 1;
        }
            catch { return 0; }

        }

        public int EliminarUsuario(string usuario)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand("delete from usuario where usuario = '" + usuario + "'", con);
                cmd.ExecuteNonQuery();
                bitacora.Eliminar("Se deshabilitò el usuario: " + cbo_usuario.Text, "usuario");
                con.Close();
                return 1;
        }
            catch { return 0; }

        }

        public int EliminarPermisosPerfil(string usuario)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand("delete from usuario_privilegios where usuario = '" + usuario + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                return 1;
        }
            catch { return 0; }

        }
    }
}
