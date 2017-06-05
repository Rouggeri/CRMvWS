using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace crm
{
    class Clsopexis
    {
        public static List<entidades.Existencia> Buscar(string bod) //Método tipo lista, que retornar el resultado dela busqueda
        {
            List<entidades.Existencia> _lista = new List<entidades.Existencia>();
            //MessageBox.Show(credi);
            OdbcCommand _comando = new OdbcCommand(String.Format(
           "select compra.id_compra, compra.id_producto, compra.id_marca, compra.id_proveedor, compra.cantidad, compra.fecha from compra inner join producto where bodega.nombre like '%{0}%' and bodega.id_bodega = existencia.id_bodega", bod), Conexion.ObtenerConexion());
            OdbcDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                entidades.Existencia ord = new entidades.Existencia();
                ord.codigo = _reader.GetString(0);
                ord.producto = _reader.GetInt32(1);
                ord.marca = _reader.GetInt32(2);
                ord.proveedor = _reader.GetInt32(3);
                ord.cantidad = _reader.GetInt32(4);
                ord.ingreso = _reader.GetString(5);


                _lista.Add(ord);
            }

            return _lista;
        }
    }
}
