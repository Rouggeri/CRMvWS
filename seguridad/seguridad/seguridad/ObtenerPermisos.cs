using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace seguridad
{
    public class ObtenerPermisos
    {

        public static DataTable Permisos(string usuario, string app)
        {
            try
            {
                OdbcConnection con = Conexion.ConexionPermisos();
                DataTable dt = new DataTable();
                OdbcCommand cmd = new OdbcCommand("select ins, sel, upd, del from usuario_privilegios where usuario = '" + usuario + "' and id_aplicacion =" + app, con);
                OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;
            }
            catch { DataTable dte = new DataTable();
                return dte;        }
        }






    }
}
