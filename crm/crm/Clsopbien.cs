using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace crm
{
    class Clsopbien
    {
        public static List<entidades.Producto> Buscar(string prod) //Método tipo lista, que retornar el resultado dela busqueda
        {
            List<entidades.Producto> _lista = new List<entidades.Producto>();
            //MessageBox.Show(credi);
            OdbcCommand _comando = new OdbcCommand(String.Format(
           "select id_producto, id_marca, nombre, descripcion, precio_unidad, id_categoria from producto where nombre like '%{0}%'", prod), Conexion.ObtenerConexion());
            OdbcDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                entidades.Producto produc = new entidades.Producto();
                produc.codigo = _reader.GetString(0);
                produc.marca = _reader.GetInt32(1);
                produc.nombre = _reader.GetString(2);
                produc.descripcion = _reader.GetString(2);
                produc.precio = _reader.GetInt32(3);
                produc.categoria = _reader.GetInt32(4);
            

                _lista.Add(produc);
            }

            return _lista;
        }

        public static entidades.Producto Obtenerclte(int id_cl)
        {
            entidades.Producto cl = new entidades.Producto();

            OdbcConnection conexion = Conexion.ObtenerConexion();

            OdbcCommand _comando = new OdbcCommand(String.Format("select id_producto, nombre, id_marca from producto where id_producto= {0}", id_cl), conexion);
            OdbcDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                cl.codigo = _reader.GetString(0);
                cl.nombre = _reader.GetString(1);
                cl.marca = _reader.GetInt32(2);
            }

            conexion.Close();
            return cl;
        }

    }
}
