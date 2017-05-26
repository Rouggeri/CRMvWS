using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace seguridad
{
    public class Conexion
    {
       
        private static string dsn;

        public static string DSN
        {
            get
            {
                return dsn;
            }
            set
            {
                dsn = value;
            }
        }

        private static string user;
        private static string password;


        public static string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

        public static string PassWord
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


       

        public static OdbcConnection ObtenerConexionODBC()
        {

            try
            {
                OdbcConnection con = new OdbcConnection();
                //con.ConnectionString = "dsn=prueba2; database="+database+"; UID="+role+"; PWD="+password+"; ";
                con.ConnectionString = "dsn=crm; UID=" + user + "; PWD=" + password + "; ";
                //con.ConnectionString = "dsn=crm;";
                con.Open();
                return con;
            }
            catch (Exception ex) {

                //MessageBox.Show("Imposible establecer conexion");
                return null; }
        }

        public static OdbcConnection ObtenerConexionM()
        {

            try
            {
                OdbcConnection con = new OdbcConnection();
               
                con.ConnectionString = "dsn=crm;";
                con.Open();
                return con;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }
        }

        public static OdbcConnection DesconectarODBC()
        {
            OdbcConnection con = new OdbcConnection();
            //con.ConnectionString = "dsn=prueba2; database="+database+"; UID="+role+"; PWD="+password+"; ";
            con.ConnectionString = "dsn=hotelsancarlos; server=localhost; UID=" + user + "; PWD=" + password + "; ";
            con.Close();
            return con;
        }

        public static void EjecutarMySqlODBC(String Query)
        {
            OdbcCommand MiComando = new OdbcCommand(Query, ObtenerConexionODBC());
            int FilasAfectadas = MiComando.ExecuteNonQuery();
            if (FilasAfectadas > 0)
            {
                //MessageBox.Show("Operacion Realizada Exitosamente", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("No se pudo realizar la modificacion de la base de datos", "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static OdbcConnection ConexionPermisos()
        {

            try
            {
                OdbcConnection con = new OdbcConnection();
                //con.ConnectionString = "dsn=prueba2; database="+database+"; UID="+role+"; PWD="+password+"; ";
                con.ConnectionString = "dsn=crm; UID= dumpy; PWD=dumpy; ";
                con.Open();
                return con;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); return null; }
        }

        /*public static OdbcConnection ObtenerConexionNavegador()
        {
            OdbcConnection miconexion = new OdbcConnection("dsn=hotelsancarlos; server=localhost; database=hotelsancarlos; uid=root; pwd=;");
            miconexion.Open();
            return miconexion;
        }
        public static OdbcConnection DesconectarNavegador()
        {
            OdbcConnection miconexion = new OdbcConnection("dsn=hotelsancarlos; server=localhost; database=hotelsancarlos; uid=root; pwd=;");
            miconexion.Close();
            return miconexion;
        }

        public static void EjecutarMySqlNavegador(String Query)
        {
            OdbcCommand MiComando = new OdbcCommand(Query, ObtenerConexionNavegador());
            int FilasAfectadas = MiComando.ExecuteNonQuery();
            if (FilasAfectadas > 0)
            {
                //MessageBox.Show("Operacion Realizada Exitosamente", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("No se pudo realizar la modificacion de la base de datos", "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
    }
}
