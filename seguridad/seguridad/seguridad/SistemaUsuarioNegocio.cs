using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace seguridad
{
    class SistemaUsuarioNegocio
    {
       public int  ValidarChecklistVacia(DataTable lista)
        {
            if( lista.Rows.Count != 0)
            {
                return 1;
            }
            else
               {
                return 0;
               }
        }

        public static void ValidarNoEspacios(KeyPressEventArgs t)
        {
            if (Char.IsSeparator(t.KeyChar))
            {
                MessageBox.Show("No se permite ingresar espacios");
                t.Handled = true;
            }
        }


    }
}
