using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace crm
{
    class Conexion
    {
        public static OdbcConnection ObtenerConexion()
        {

            try
            {
                OdbcConnection con = new OdbcConnection();
                //con.ConnectionString = "dsn=prueba2; database="+database+"; UID="+role+"; PWD="+password+"; ";
                con.ConnectionString = "dsn=crm;";
                con.Open();
                return con;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }
        }
    }
}
