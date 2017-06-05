using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace crm
{
    class Clsoporden
    {
        public static List<entidades.Orden> Buscar(string prod) //Método tipo lista, que retornar el resultado dela busqueda
        {
            List<entidades.Orden> _lista = new List<entidades.Orden>();
            //MessageBox.Show(credi);
            OdbcCommand _comando = new OdbcCommand(String.Format(
           "select compra.id_compra, compra.id_producto, compra.id_marca, compra.id_proveedor, compra.cantidad, compra.fecha from compra inner join producto where producto.nombre like '%{0}%' and compra.id_producto = producto.id_producto", prod), Conexion.ObtenerConexion());
            OdbcDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                entidades.Orden ord = new entidades.Orden();
                ord.codigo = _reader.GetString(0);
                ord.producto = _reader.GetInt32(1);
                ord.marca = _reader.GetInt32(2);
                ord.proveedor = _reader.GetInt32(3);
                ord.cantidad = _reader.GetInt32(4);
                ord.fecha = _reader.GetString(5);


                _lista.Add(ord);
            }

            return _lista;
        }

        public static entidades.Orden Obtenerclte(int id_cl)
        {
            entidades.Orden cl = new entidades.Orden();

            OdbcConnection conexion = Conexion.ObtenerConexion();

            OdbcCommand _comando = new OdbcCommand(String.Format("select id_compra, id_producto, id_marca, id_proveedor, cantidad, fecha from compra where id_compra= {0}", id_cl), conexion);
            OdbcDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                cl.codigo = _reader.GetString(0);
                cl.producto = _reader.GetInt32(1);
                cl.marca = _reader.GetInt32(2);
                cl.proveedor = _reader.GetInt32(3);
                cl.cantidad = _reader.GetInt32(4);
                cl.fecha = _reader.GetString(5);
            }

            conexion.Close();
            return cl;
        }

    }
}
