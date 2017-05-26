using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.Odbc;

namespace seguridad
{
    public class Bloqueo
    {



        public static void DesbloquearMDI(MenuStrip MenuMDI)
        {

            DataTable dt_permisos = new DataTable();
            OdbcConnection con = seguridad.Conexion.ConexionPermisos();
            OdbcCommand comando = new OdbcCommand("select p.id_aplicacion, a.id_modulo from usuario_privilegios p inner join aplicacion a on p.id_aplicacion = a.id_aplicacion where p.usuario = '" + seguridad.Conexion.User + "' ", con);
            OdbcDataAdapter ad = new OdbcDataAdapter(comando);
            ad.Fill(dt_permisos);

            foreach (ToolStripMenuItem menu_principal in MenuMDI.Items)
            {
                string modulo_menu = "0";
                if (menu_principal.Tag != null)
                {
                    modulo_menu = menu_principal.Tag.ToString();
                }
                foreach (DataRow row_aplicaciones in dt_permisos.Rows)
                {
                    string modulo_aplicacion = row_aplicaciones[1].ToString();
                    if (modulo_aplicacion == modulo_menu)
                    {
                        menu_principal.Enabled = true;
                        break;
                    }
                }
            }

            foreach (ToolStripMenuItem menu_principal in MenuMDI.Items)
            {

                foreach (ToolStripMenuItem sub_menu in menu_principal.DropDownItems)
                {
                    string aplicacion_menu = "0";
                    if (sub_menu.Tag != null)
                    {
                        aplicacion_menu = sub_menu.Tag.ToString();
                    }
                    foreach (DataRow row_aplicaciones in dt_permisos.Rows)
                    {
                        string aplicacion = row_aplicaciones[0].ToString();
                        if (aplicacion == aplicacion_menu)
                        {
                            sub_menu.Enabled = true;
                            break;
                        }
                    }


                }

            }

        }






    }
}
