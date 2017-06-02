using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Data;

namespace crm
{
    class datos
    {
        seguridad.bitacora bita = new seguridad.bitacora();
        /*-----------------------------------------------VARIABLES GLOBALES------------------------------------------------------------*/
        #region Variables Globales
        private static OdbcCommand mySqlComando;
        private static OdbcDataAdapter mySqlDAdAdaptador;
        #endregion

        #region Funciones de Manipulacion de Datos
        public void insertarproducto(string nombre, string descripcion, Int32 marca, double precio, Int32 id_categoria, Int32 comision)
        {
            try
            {
                mySqlComando = new OdbcCommand(
                string.Format("Insert into producto (id_marca, nombre, descripcion, precio_unidad, id_categoria, cporcentaje, estado) values ('{0}','{1}','{2}','{3}','{4}','{5}','ACTIVO')", marca, nombre, descripcion, precio, id_categoria, comision),
                seguridad.Conexion.ObtenerConexionODBC()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
            }
            catch (OdbcException e)
            {
                MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

        } //insertar producto

        #region
        public void insertarbodega(string nombre, string direccion)
        {
            try
            {
                mySqlComando = new OdbcCommand(
                string.Format("Insert into bodega (nombre_bodega, direccion_bodega) values ('{0}','{1}')", nombre, direccion),
                Conexion.ObtenerConexion()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
            }
            catch (OdbcException e)
            {
                MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

        } //insertar bodega


        public void insertarcategoria(string nombre)
        {
            try
            {
                mySqlComando = new OdbcCommand(
                string.Format("Insert into categoria (nombre) values ('{0}')", nombre),
                seguridad.Conexion.ObtenerConexionODBC()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
            }
            catch (OdbcException e)
            {
                MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

        } //insertar categoria


        public void insertarexistencia(Int32 compra,Int32 cantidad, Int32 producto, Int32 bodega, String ingreso, Int32 prov, Int32 marca)
        {
            try
            {
                MessageBox.Show(Convert.ToString(compra));
                mySqlComando = new OdbcCommand(
                string.Format("Insert into existencia (id_compra, cantidad, id_producto, id_bodega, id_proveedor, id_marca, fec_ingreso) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", compra, cantidad, producto, bodega, prov, marca, Convert.ToString(DateTime.Today)),
                Conexion.ObtenerConexion()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
            }
            catch (OdbcException e)
            {
                          

                mySqlComando = new OdbcCommand(
                string.Format("Update existencia set cantidad = '{0}' where id_producto = '{1}' and id_marca = '{2}' and id_proveedor = '{3}' and id_bodega = '{4}' and id_compra = '{5}'", cantidad, producto, marca, prov, bodega, compra),
                Conexion.ObtenerConexion()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se inserto con exito");
            }

        } //insertar bodega

        public void insertarmarca(string nombre, int porcentaje)
        {
            try
            {
                mySqlComando = new OdbcCommand(
                string.Format("Insert into marca (nombre_marca, porcentaje) values ('{0}','{1}')", nombre, porcentaje),
                Conexion.ObtenerConexion()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
            }
            catch (OdbcException e)
            {
                MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

        } //insertar marca

        public void insertarcompra(Int32 producto, Int32 marca, Int32 proveedor, Int32 cantidad, String fecha)
        {
            try
            {
                mySqlComando = new OdbcCommand(
                string.Format("Insert into compra (id_producto, id_marca, id_proveedor, cantidad, fecha) values ('{0}','{1}','{2}','{3}','{4}')", producto, marca, proveedor, cantidad, fecha),
                Conexion.ObtenerConexion()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
            }
            catch (OdbcException e)
            {
                MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

        } //insertar marca

        public void insertarcatalogo(string nombre)
        {
            try
            {
                mySqlComando = new OdbcCommand(
                string.Format("Insert into tipo_precio (tipo) values ('{0}')", nombre),
                Conexion.ObtenerConexion()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
            }
            catch (OdbcException e)
            {
                MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

        } //insertar categoria


        public static DataTable ObtenerCat()
        {
            DataTable dtCategoria = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                    string.Format("SELECT * FROM categoria"),      //query de consultas de categoria
                    Conexion.ObtenerConexion()              //llamada a clase conexion
                    );
                //-------------------------------------------------------------------------//
                mySqlDAdAdaptador = new OdbcDataAdapter();         //Llenando DataTable Categoria
                mySqlDAdAdaptador.SelectCommand = mySqlComando;
                mySqlDAdAdaptador.Fill(dtCategoria);
                //------------------------------------------------------------------------//
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible acceder a los registros en categoria producto");
            }
            return dtCategoria;
        }

        public static DataTable ObtenerBod()
        {
            DataTable dtBodega = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                    string.Format("SELECT * FROM bodega"),      //query de consultas de categoria
                    Conexion.ObtenerConexion()              //llamada a clase conexion
                    );
                //-------------------------------------------------------------------------//
                mySqlDAdAdaptador = new OdbcDataAdapter();         //Llenando DataTable Categoria
                mySqlDAdAdaptador.SelectCommand = mySqlComando;
                mySqlDAdAdaptador.Fill(dtBodega);
                //------------------------------------------------------------------------//
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible acceder a los registros en bodega");
            }
            return dtBodega;
        }

        public static DataTable ObtenerProveedor()
        {
            DataTable dtProveedor = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                    string.Format("SELECT * FROM tbl_proveedor"),      //query de consultas de categoria
                    Conexion.ObtenerConexion()              //llamada a clase conexion
                    );
                //-------------------------------------------------------------------------//
                mySqlDAdAdaptador = new OdbcDataAdapter();         //Llenando DataTable Categoria
                mySqlDAdAdaptador.SelectCommand = mySqlComando;
                mySqlDAdAdaptador.Fill(dtProveedor);
                //------------------------------------------------------------------------//
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible acceder a los registros en proveedor");
            }
            return dtProveedor;
        }

        public static DataTable ObtenerRegistros()
        {

            DataTable dtProducto = new DataTable();         //se crea el objeto dtProducto
            try
            {
                mySqlComando = new OdbcCommand(
                     string.Format("SELECT * FROM producto"),
                     seguridad.Conexion.ObtenerConexionODBC()
                 );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                mySqlDAdAdaptador.Fill(dtProducto);                 //poblamos el sqlDataAdaptor con el resultado del query

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No es posible obtener el registro", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dtProducto; //retornamos el sqlDataAdaptor con los datos del query
        } //mostrar registros

        public static DataTable ObtenerProductos()
        {

            DataTable dtProductos = new DataTable();         //se crea el objeto dtProducto
            try
            {
                mySqlComando = new OdbcCommand(
                     string.Format("SELECT producto.id_producto AS producto, marca.nombre_marca AS marca, producto.nombre AS nombre, producto.descripcion AS descripcion, producto.precio_unidad AS precio, categoria.nombre AS categoria, producto.cporcentaje AS comision FROM producto INNER JOIN marca INNER JOIN categoria ON marca.id_marca = producto.id_marca AND categoria.id = producto.id_categoria"),
                     seguridad.Conexion.ObtenerConexionODBC()
                 );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                mySqlDAdAdaptador.Fill(dtProductos);                 //poblamos el sqlDataAdaptor con el resultado del query

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No es posible obtener el registro", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dtProductos; //retornamos el sqlDataAdaptor con los datos del query
        } //mostrar registros

        public static DataTable ObtenerRegistrosbod()
        {
            DataTable dtBodega = new DataTable();         //se crea el objeto dtProducto
            try
            {
                mySqlComando = new OdbcCommand(
                     string.Format("SELECT * FROM bodega"),
                     Conexion.ObtenerConexion()
                 );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                mySqlDAdAdaptador.Fill(dtBodega);                 //poblamos el sqlDataAdaptor con el resultado del query

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No es posible obtener el registro", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dtBodega; //retornamos el sqlDataAdaptor con los datos del query
        } //mostrar registros

        public static DataTable ObtenerMarca()
        {
            DataTable dtMarca = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                    string.Format("SELECT * FROM marca"),      //query de consultas de categoria
                    Conexion.ObtenerConexion()              //llamada a clase conexion
                    );
                //-------------------------------------------------------------------------//
                mySqlDAdAdaptador = new OdbcDataAdapter();         //Llenando DataTable Categoria
                mySqlDAdAdaptador.SelectCommand = mySqlComando;
                mySqlDAdAdaptador.Fill(dtMarca);
                //------------------------------------------------------------------------//
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible acceder a los registros en bodega");
            }
            return dtMarca;
        }

        public static DataTable ObtenerRegistros2()
        {
            DataTable dtAbono = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                     string.Format("SELECT * FROM abonos"),
                     Conexion.ObtenerConexion()
                 );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                mySqlDAdAdaptador.Fill(dtAbono);                 //poblamos el sqlDataAdaptor con el resultado del query

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No es posible obtener el registro", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dtAbono; //retornamos el sqlDataAdaptor con los datos del query

        }

        public static DataTable ObtenerExistencia()
        {
            DataTable dtExistencia = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                     string.Format("SELECT producto.nombre, bodega.nombre_bodega, existencia.fec_ingreso, existencia.cantidad, tbl_proveedor.nombre_proveedor FROM producto INNER JOIN existencia INNER JOIN bodega INNER JOIN tbl_proveedor ON bodega.id_bodega = existencia.id_bodega AND producto.id_producto = existencia.id_producto AND existencia.id_proveedor = tbl_proveedor.id_proveedor"),
                     Conexion.ObtenerConexion()
                 );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                mySqlDAdAdaptador.Fill(dtExistencia);                 //poblamos el sqlDataAdaptor con el resultado del query

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No es posible obtener el registro", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dtExistencia; //retornamos el sqlDataAdaptor con los datos del query

        }

        public static DataTable ObtenerCompra()
        {
            DataTable dtCompra = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                     string.Format("SELECT compra.id_compra, producto.nombre, marca.nombre_marca, tbl_proveedor.nombre_proveedor, compra.cantidad, compra.fecha FROM compra INNER JOIN producto INNER JOIN marca INNER JOIN tbl_proveedor ON producto.id_producto = compra.id_producto AND marca.id_marca = compra.id_marca AND compra.id_proveedor = tbl_proveedor.id_proveedor"),
                     Conexion.ObtenerConexion()
                 );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                mySqlDAdAdaptador.Fill(dtCompra);                 //poblamos el sqlDataAdaptor con el resultado del query

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No es posible obtener el registro", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dtCompra; //retornamos el sqlDataAdaptor con los datos del query

        }

        public static DataTable ObtenerCatalogo()
        {
            DataTable dtCatalogo = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                    string.Format("SELECT * FROM tipo_precio"),      //query de consultas de categoria
                    Conexion.ObtenerConexion()              //llamada a clase conexion
                    );
                //-------------------------------------------------------------------------//
                mySqlDAdAdaptador = new OdbcDataAdapter();         //Llenando DataTable Categoria
                mySqlDAdAdaptador.SelectCommand = mySqlComando;
                mySqlDAdAdaptador.Fill(dtCatalogo);
                //------------------------------------------------------------------------//
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible acceder a los registros en tipo de precio");
            }
            return dtCatalogo;
        }

        public static DataTable ObtenerPrecio()
        {
            DataTable dtPrecio = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                    string.Format("SELECT * FROM tipo_precio"),      //query de consultas de categoria
                    Conexion.ObtenerConexion()              //llamada a clase conexion
                    );
                //-------------------------------------------------------------------------//
                mySqlDAdAdaptador = new OdbcDataAdapter();         //Llenando DataTable Categoria
                mySqlDAdAdaptador.SelectCommand = mySqlComando;
                mySqlDAdAdaptador.Fill(dtPrecio);
                //------------------------------------------------------------------------//
            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible acceder a los registros en categoria producto");
            }
            return dtPrecio;
        }


        public void eliminarproducto(string codigo)
        {
            try
            {
                OdbcCommand comando = new OdbcCommand(string.Format("delete from producto where id='{0}'",
                Convert.ToInt32(codigo)), Conexion.ObtenerConexion()
                );
                comando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Registro eliminado con exito");
            }
            catch (OdbcException e)
            {
                MessageBox.Show("Error de eliminacion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

        } //eliminar producto

        public void eliminarbodega(string codigo)
        {
            try
            {
                OdbcCommand comando = new OdbcCommand(string.Format("delete from bodega where id_bodega='{0}'",
                Convert.ToInt32(codigo)), Conexion.ObtenerConexion()
                );
                comando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Registro eliminado con exito");
            }
            catch (OdbcException e)
            {
                MessageBox.Show("Error de eliminacion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

        } //eliminar bodega
        #endregion
        public void insertarabono(string id_factura, string id_cliente, string forma_pago, double abono, string fecha)
        {
            try
            {
                mySqlComando = new OdbcCommand(
                string.Format("Insert into abonos (id_factura, id_cliente, forma_pago, abono, fecha) values ('{0}','{1}','{2}','{3}','{4}')", id_factura, id_cliente, forma_pago, abono, fecha),
                seguridad.Conexion.ObtenerConexionODBC()
                );                                              //se realiza el query con los datos que ser recibieron del objeto persona
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
            }
            catch (OdbcException e)
            {
                MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

        } //insertar abono




        #endregion
        public static DataTable ObtenerClientes(string nombres)
        {
            DataTable dtCliente = new DataTable();
            try
            {
                mySqlComando = new OdbcCommand(
                     string.Format("SELECT nombres,apellidos,incidencia FROM tbl_cliente where nombres ='{0}'", nombres),
                     Conexion.ObtenerConexion()
                 );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                mySqlDAdAdaptador.Fill(dtCliente);                 //poblamos el sqlDataAdaptor con el resultado del query

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dtCliente; //retornamos el sqlDataAdaptor con los datos del query


        }
        public static List<entidades.factura> Buscar(int id_factura)

        {

            List<entidades.factura> _lista = new List<entidades.factura>();



            mySqlComando = new OdbcCommand(String.Format(

           "SELECT factura_encabezado.id_factura, tbl_cliente.nombres , factura_encabezado.forma_pago, factura_encabezado.total, factura_encabezado.id_cliente FROM factura_encabezado, tbl_cliente WHERE factura_encabezado.id_cliente = tbl_cliente.id_cliente AND factura_encabezado.id_factura ={0}", id_factura), Conexion.ObtenerConexion());

            OdbcDataReader _reader = mySqlComando.ExecuteReader();

            while (_reader.Read())

            {

                entidades.factura factura = new entidades.factura();

                factura.id_factura = _reader.GetInt32(0);

                factura.nombre_cliente = _reader.GetString(1);

                factura.saldo_factura = _reader.GetString(2);

                factura.saldo_factura = _reader.GetString(3);
                factura.id_cliente = _reader.GetInt32(4);

                //factura.observ_prov = _reader.GetString(4);

                //proveedor.nit_prov = _reader.GetString(5);


                _lista.Add(factura);

            }

            return _lista;

        }
        /*public static List<entidades.Cliente> Buscar2(int nombres)

        {

            List<entidades.Cliente> _lista = new List<entidades.Cliente>();



            MySqlCommand _comando = new MySqlCommand(String.Format(

           "SELECT factura_encabezado.id_factura, tbl_cliente.nombres , factura_encabezado.forma_pago, factura_encabezado.total, factura_encabezado.id_cliente FROM factura_encabezado, tbl_cliente WHERE factura_encabezado.id_cliente = tbl_cliente.id_cliente AND factura_encabezado.id_factura ={0}", id_factura), claseConexion.funobtenerConexion());

            MySqlDataReader _reader = _comando.ExecuteReader();

            while (_reader.Read())

            {

                entidades.factura factura = new entidades.factura();

                factura.id_factura = _reader.GetInt32(0);

                factura.nombre_cliente = _reader.GetString(1);

                factura.saldo_factura = _reader.GetString(2);

                factura.saldo_factura = _reader.GetString(3);
                factura.id_cliente = _reader.GetInt32(4);

                //factura.observ_prov = _reader.GetString(4);

                //proveedor.nit_prov = _reader.GetString(5);


                _lista.Add(factura);

            }

            return _lista;

        }*/
        public static entidades.factura ObtenerFactura(int id_factura)

        {

            entidades.factura fact = new entidades.factura();
            OdbcConnection conexion = Conexion.ObtenerConexion();
            //OdbcConnection conexion = claseConexion.ObtenerConexionODBC();
            mySqlComando = new OdbcCommand(string.Format("SELECT factura_encabezado.id_factura, tbl_cliente.nombres , factura_encabezado.forma_pago, factura_encabezado.total, factura_encabezado.id_cliente FROM factura_encabezado, tbl_cliente WHERE factura_encabezado.id_cliente = tbl_cliente.id_cliente AND factura_encabezado.id_factura ={0}", id_factura), Conexion.ObtenerConexion());

            //OdbcCommand _comando = new OdbcCommand(String.Format("SELECT factura_encabezado.id_factura, tbl_cliente.nombres , factura_encabezado.forma_pago, factura_encabezado.total FROM factura_encabezado, tbl_cliente WHERE factura_encabezado.id_cliente = tbl_cliente.id_cliente AND factura_encabezado.id_factura ={0}", id_factura), conexion);

            OdbcDataReader _reader = mySqlComando.ExecuteReader();

            while (_reader.Read())

            {

                fact.id_factura = _reader.GetInt32(0);
                fact.nombre_cliente = _reader.GetString(1);
                fact.forma_pago = _reader.GetString(2);
                fact.saldo_factura = _reader.GetString(3);
                fact.id_cliente = _reader.GetInt32(4);
                //bien.cantidad = _reader.GetString(3);            
            }

            conexion.Close();
            return fact;

        }
    }
}
