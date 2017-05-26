using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;

namespace seguridad
{
    // clase capa datos
    public class CapaDatos
    {
        SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
        // void modificar 
        public void Modificar(string usuario, string Acontrasenia, string Ncontrasenia, string RNcontrasenia)
        {
            // try- catch para manejo de errores
            try
            {
                //consulta de actualizar en tabla usuario en la base de datos
                OdbcCommand cmd = new OdbcCommand(string.Format("update usuario set contrasenia = '" + Ncontrasenia + "' where  usuario ='" + usuario + "'"), Conexion.ConexionPermisos());
                //seguridad.Conexion.PassWord = Ncontrasenia;
                cmd.ExecuteNonQuery();

                // mostrando mensaje de que la contraseña fue actualizada con exito
               // MessageBox.Show("Password Modificada con exito");
            }
            // catch para manejo de errores
            catch (Exception ex)
            {
                //mensaje en caso de error
                MessageBox.Show(ex.Message);
            }

        }

        public int ActualizarContraseñaBD(string contraseñanueva)
        {
            try
            {
                string usuario = Conexion.User;
                OdbcConnection con = Conexion.ConexionPermisos();
                string query = "alter user "+usuario+" identified by '"+contraseñanueva+"' ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
        }
            catch { return 0; }
        }

        // string respuesta;
        //variable global respuesta
        public string RevisarContraseña(string usuario)
        {
            // try catch para manejo de errores
            //try
           // {
                //OdbcConnection con = Conexion.Conexion.ObtenerConexionODBC();
                //consulta para verificar usuario
                string sQuery = "select contrasenia from usuario where usuario = '" + usuario + "'";
                DataTable dt = new DataTable();
                OdbcCommand comando = new OdbcCommand(sQuery, Conexion.ConexionPermisos());
                OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
                adaptador.Fill(dt);
                // si e usuario existe 

               // if (dt.Rows.Count != 0)
               // {

                    DataRow fila = dt.Rows[0];
                   // String sUsuario = fila[0].ToString();
                   String sContra = fila[0].ToString().Trim();
                   // respuesta = sContra;


                    // DataRow fila = dt.Rows[0];
                    // String sUsuario = fila[0].ToString();
                    //  String sContra = fila[2].ToString();
                //}
                //returna variable respuesta que contiene la contraseña obtenida de la base de datos
                //return ss.Encriptar(sContra);
                 return sContra;
           // }
            //catch (Exception ex)
            //{
            //    //retorna error en caso de error
            //    MessageBox.Show(ex.Message); ;
            //}
        }
    }
}
