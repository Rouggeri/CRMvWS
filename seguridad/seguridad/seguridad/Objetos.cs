using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seguridad
{
   public class Objetos
    {
        //capa de objetos
        public class cuentas
        {
            //variables det y set
            public string usuario { get; set; }
            public string Acontrasenia { get; set; }
            public string Ncontrasenia { get; set; }
            public string RNcontrasenia { get; set; }


            public cuentas() { }

            //cuentas
            public cuentas(string usuario, string Acontrasenia, string Ncontrasenia, string RNcontrasenia)
            {
                this.usuario = usuario;
                this.Acontrasenia = Acontrasenia;
                this.Ncontrasenia = Ncontrasenia;
                this.RNcontrasenia = RNcontrasenia;
            }
        }

    }
}
