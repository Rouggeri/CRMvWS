using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seguridad
{
    public class CapaNegocio:Objetos
    {
        //capa de negocios
        public void Modificar(cuentas CuentaModificar)
        {
            //llamando a la capa de datos
            CapaDatos ModificaDato = new CapaDatos();
            ModificaDato.Modificar(CuentaModificar.usuario, CuentaModificar.Acontrasenia, CuentaModificar.Ncontrasenia, CuentaModificar.RNcontrasenia);
        }

    }
}
