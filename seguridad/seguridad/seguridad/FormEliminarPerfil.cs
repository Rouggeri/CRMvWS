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
    public partial class FormEliminarPerfil : Form
    {
        public FormEliminarPerfil()
        {
            InitializeComponent();
        }
        bitacora bitacora = new bitacora();
        private void FormEliminarPerfil_Load(object sender, EventArgs e)
        {
            try
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                cbo_perfil.DataSource = ss.ObtenerPerfiles();
                cbo_perfil.DisplayMember = "nombre_perfil";
                cbo_perfil.ValueMember = "id_perfil";
                cbo_perfil.SelectedIndex = -1;
            }
            catch { MessageBox.Show("no tiene permisos"); }
        }

        private void btn_deshabilitar_Click(object sender, EventArgs e)
        {
            try
            {
               // int x = EliminarPerfilBD(cbo_usuario.SelectedValue.ToString());
                int y = EliminarPerfil(cbo_perfil.SelectedValue.ToString());
                int z = EliminarPermisosPerfil(cbo_perfil.SelectedValue.ToString());
                if (y == 1 && y == 1 && z == 1)
                {

                    MessageBox.Show("deshabilitado con exito");
                }
                else
                {
                    MessageBox.Show("error al deshabilitar perfil");
                    bitacora.ErrorOp("Error al deshabilitar el perfil: " + cbo_perfil.SelectedValue, "usuario");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        public int EliminarPerfil(string perfil)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand("delete from perfil where id_perfil = " + perfil , con);
                cmd.ExecuteNonQuery();
                bitacora.Eliminar("Se deshabilitó el usuario: " + cbo_perfil.Text, "usuario");
                con.Close();
                return 1;
            }
            catch { return 0; }

        }


        public int EliminarPermisosPerfil(string perfil)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand("delete from perfil_privilegios where id_perfil = " + perfil , con);
                cmd.ExecuteNonQuery();

                con.Close();
                return 1;
            }
            catch { return 0; }

        }




    }
}
