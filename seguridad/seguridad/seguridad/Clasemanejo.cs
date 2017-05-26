using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;

namespace seguridad
{
    public class Clasemanejo
    {
        bitacora bitacora = new bitacora();
        public static int agregaraplicacion(String id_aplicacion, String nombre_aplicacion)
        {
            try
            {

                int devolver = 0;
                OdbcConnection con = Conexion.ObtenerConexionODBC();

                OdbcCommand comando = new OdbcCommand(string.Format("insert into aplicacion(id_aplicacion,nombre_aplicacion) values('" + id_aplicacion + "','" + nombre_aplicacion + "')"), con);
                devolver = comando.ExecuteNonQuery();

                return devolver;
            }
            catch { return 0; }

        }
        public static DataTable cargar(string query)
        {
            // llenado del data grid view 
            DataTable dt = new DataTable();
            OdbcCommand cmd = new OdbcCommand(query, Conexion.ObtenerConexionODBC());
            OdbcDataAdapter adap = new OdbcDataAdapter(cmd);
            adap.Fill(dt);
            return dt;



        }
        public DataTable Refrescar()
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            string query = "select * from aplicacion order by id_aplicacion";
            OdbcCommand cmd = new OdbcCommand(query, con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;

        }


    }
}
