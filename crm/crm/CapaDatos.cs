using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Data;
using System.Configuration;


namespace proyectoUOne
{
    class CapaDatos
    {
        //-------------------SELVIN TINIGUAR RODRI - 0901 - 13 - 8887 ------------------------
        // ---------------------------- COTIZACIONES -------------------------
        //Insertar Encabezado Cotizacion a base de datos
        public void InsertarCotizacion(string fechaIniciosP, string fechaTerminasP, double totalP, string idClienteP)
        {

            String cadena = "insert into cotizacion_encabezado(id_cotizacion, fechaInicio, fechaTermina, estadoCotizacion, total, estado, id_cliente) values(null,'" + fechaIniciosP + "','" + fechaTerminasP + "','ESPERA', "+totalP+",'ACTIVO', "+idClienteP+")";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Insertar Detalle Cotizacion a base de datos
        public void insertar_detalle_cotizacion(int cod_cotizacionP, int cod_productoP, int idMArca, int cantidadP, double precioP, double subtotalP)
        {
            try
            {
                String query = "insert into cotizacion_detalle(id_detalleCotizacion,id_cotizacion, id_producto, id_marca, cantidad, precioUnidad, subtotal, estado) values(null, " + cod_cotizacionP + "," + cod_productoP + ","+idMArca+" ," + cantidadP + ","+precioP+"," + subtotalP + ",'ACTIVO')";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        // ------------------------------------ TERMINA COTIZACIONES -------------------------------------
        // -------------------------------- FACTURACION -----------------------------------------

        ///Insertar Encabezado Factura a base de datos
        public int GuardarFacturaEncabezado(string fechaP, string formaPagoP, double totalP, int codigoClienteP, string id_empleadoP, string IDBodega)
        {
            try
            {
                int devolver = 0;
                String cadena = "insert into factura_encabezado(id_factura, fecha, forma_pago, tipo_documento, marca, total, estado, id_cliente, id_empleado_pk, id_bodega) values(null,'"+ fechaP+"','"+formaPagoP+"','FACTURA','X',"+totalP+",'ACTIVO',"+codigoClienteP+", '"+id_empleadoP+"','"+IDBodega+"')";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(cadena, con);
                devolver = cmd.ExecuteNonQuery();
                con.Close();
                return devolver;
            }
            catch { return 0; }

        }

        //Insertar Detalle Factura a base de datos
        public int insertar_detalle_factura(int codigoFacturaP, int codigoProductoP, int CodigoMarca, int cantidadP, double precioP, double subtotalP)
        {
            try
            {
                int devolver = 0;
                String cadena = "insert into detalle_factura(id_detalleFactura, id_factura, id_producto, id_marca, cantidad, precioUnidad, subtotal, estado) values(null, "+codigoFacturaP+","+codigoProductoP+","+CodigoMarca+","+cantidadP+",'"+precioP+"',"+subtotalP+",'ACTIVO')";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(cadena, con);
                devolver = cmd.ExecuteNonQuery();
                con.Close();
                return devolver;
            }
            catch { return 0; }

        }
        // ------------------------------------------ TERMINA FACTURACION --------------------------------------------

       
        //Insertar Cliente a base de datos
        public int GuardarCliente(string nitP, string nombreP, string apellidoP, string movil, string telefonoP, string tipoP, string correoP)
        {
            try
            {
                int devolver = 0;
                String cadena = "insert into tbl_cliente(id_cliente, estado, nombres, apellidos, tipo, telefono, movil, correo, nit) values(null,'ACTIVO','" + nombreP + "','" + apellidoP + "','"+tipoP+"','" + telefonoP + "','" +movil + "','"+correoP+"', '"+nitP+"');";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(cadena, con);
                devolver = cmd.ExecuteNonQuery();
                con.Close();
                return devolver;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        
        //Insertar Productos a base de datos
        public int InsertarProducto(string descripcionP, int existenciaS, string marcaS, double precioS, string fechaPS, int id_categoriaPS )
        {
            int devolver = 0;
            string cadena = "insert into producto(id, nombre, existencia, marca, precio, fecha_ingreso, id_categoria) values(null,'"+descripcionP+"',"+existenciaS+",'"+marcaS+"',"+precioS+", '"+fechaPS+"',"+id_categoriaPS+");";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            devolver = cmd.ExecuteNonQuery();
            con.Close();
            return devolver;
        }

        //Consulta Precio_Unidad de Producto
        public DataTable query_precioUnidad(int codigoPP)
        {
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            string query = "select precio_unidad from producto where id= " + codigoPP + ";";
            OdbcCommand cmd = new OdbcCommand(query, con);
            OdbcDataAdapter da1 = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            return dt;
        }

        //Consulta Producto TextChanged (Buscar Producto)
        public static DataTable CargaProducto(int constaP, string letraP)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                string query = "select p.id_producto, p.nombre, pr.precio, pr.id_bien, pr.id_tipo, pr.id_marca, pe.id_compra FROM producto p INNER JOIN precio pr ON p.id_producto = pr.id_bien INNER JOIN existencia pe ON p.id_producto = pe.id_producto WHERE pr.id_tipo='" + constaP+"' and p.id_producto like '%"+letraP+"%' or pr.id_tipo='"+constaP+"' and p.nombre like '%"+letraP+"%'";
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
                adaptador.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //Consulta Producto cargar Inicio (Buscar Producto)
        public static DataTable CargaProducto2(string constaP)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                string query = "select p.id_producto, p.nombre, pr.precio, pr.id_bien, pr.id_tipo, pr.id_marca, pe.id_compra FROM producto p INNER JOIN precio pr ON p.id_producto = pr.id_bien INNER JOIN existencia pe ON p.id_producto = pe.id_producto WHERE pr.id_tipo = '"+ constaP+"' ORDER BY p.nombre ASC";
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
                adaptador.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //Consulta Codigo y Nombre de Cliente
        public static DataTable ConsultaCodigoYNombre(String busquedaP)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "select id_cliente, nombres, apellidos, movil, telefono, tipo, nit FROM tbl_cliente WHERE id_cliente like '%"+busquedaP+"%' or nombres like '%"+busquedaP+"%'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                con.Close();
                return dtd;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //Consulta Auto Incremento (Consulta Normal)
        public static DataTable CargarGridAutoIncrement(String query)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
                adaptador.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //Consulta Detalle cotizacion de exitentes
        public static DataTable ConsultadetalleCotizacion(int busquedaP)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "select id_producto, cantidad, precioUnidad, subtotal from cotizacion_detalle WHERE id_cotizacion = "+busquedaP+"";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                con.Close();
                return dtd;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        ///Actualizar Encabezado Factura a base de datos
        public void ActualziarFacturaEncabezado(string fechaP, string formaPagoP, string totalP, int codigoClienteP, string id_facturaP)
        {

            String cadena = "update factura_encabezado set fecha='"+fechaP+"',forma_pago='"+formaPagoP+"',total='"+totalP+"',id_cliente='"+codigoClienteP+"' where id_factura='"+id_facturaP+"'";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        ///Actualizar Encabezado Cotizacion a base de datos
        public void ActualziarCotizacionEncabezado(string FechaIn, string fechaTer, string codigoCl,string id_CotizacionS)
        {

            String cadena = "update cotizacion_encabezado set fechaInicio='"+FechaIn+"',fechaTermina='"+fechaTer+"', id_cliente='"+codigoCl+"' where id_cotizacion='"+id_CotizacionS+"'";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        ///Actualizar Estado cotizacion a base de datos
        public void ActualizaEstado(string id_CotizacionS)
        {

            String cadena = "update cotizacion_encabezado set estado='INACTIVO' WHERE id_cotizacion='"+id_CotizacionS+"'";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        ///Actualizar Estado factura a base de datos
        public void ActualizaEstadoFactura(string id_FacturaS)
        {

            String cadena = "update factura_encabezado set estado='INACTIVO' WHERE id_factura='"+id_FacturaS+"'";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        ///Actualizar Estado_pedido cotizacion a base de datos
        public void ActualizaEstadoPedidoCotizacion(string id_Cotizacions)
        {

            String cadena = "update cotizacion_encabezado set estadoCotizacion='FACTURADA' WHERE id_cotizacion='"+id_Cotizacions+"'";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Consulta Empleados Combobox
        public DataTable CargarEmpleados()
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                string consulta = "select id_empleado, nombres FROM tbl_empleado;";
                OdbcCommand comando = new OdbcCommand(consulta, con);
                OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
                adaptador.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        // ----------------------------- CARGAR COTIZACION ---------------------
        //Consulta Cotizacion_Encabezado Combobox
        public DataTable CargarCotizacion()
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                string consulta = "SELECT id_cotizacion FROM cotizacion_encabezado WHERE estadoCotizacion='ESPERA';";
                OdbcCommand comando = new OdbcCommand(consulta, con);
                OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
                adaptador.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //Consulta Detalle cotizacion de exitentes
        public static DataTable CargarDetalleCotiza(string busquedaP)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT d.id_producto, p.nombre, p.id_marca, m.nombre_marca, d.cantidad, d.precioUnidad, d.subtotal FROM cotizacion_detalle d INNER JOIN producto p ON d.id_producto=p.id_producto INNER JOIN marca m ON p.id_marca=m.id_marca WHERE id_cotizacion = '"+busquedaP+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                con.Close();
                return dtd;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        
        //consulta de total para factura de cotizacion
        public static Double ConsultaTotal(string codigoCotiza)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string queryd = "SELECT total FROM cotizacion_encabezado where id_cotizacion='"+codigoCotiza+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter red = new OdbcDataAdapter(cmdd);
                DataTable tot = new DataTable();
                red.Fill(tot);
                DataRow rows = tot.Rows[0];
                double codigoObtenido = Convert.ToInt32(rows[0]);
                con.Close();
                return codigoObtenido;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de novato");
                return 0;
            }
        }
        // --------------------------- TERMINA CARGAR COTIZACION ----------------

            // ---------------------------- CONSULTAR AUTOINCREMENT ---------------
        //Consulta Auto Increment Siguiente Factura
        public static Int32 ConsultaUatoIncrementFactura()
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string queryd = "select AUTO_INCREMENT from information_schema.TABLES where TABLE_SCHEMA='crmbd' and TABLE_NAME='factura_encabezado';";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter red = new OdbcDataAdapter(cmdd);
                DataTable tot = new DataTable();
                red.Fill(tot);
                DataRow rows = tot.Rows[0];
                int codigoObtenido = Convert.ToInt32(rows[0]);
                con.Close();
                return codigoObtenido;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }     
        }

        //Consutla Auto Increment Siguiente Cotizacion
        public static Int32 ConsultaUatoIncrementCotizacion()
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string queryd = "select AUTO_INCREMENT from information_schema.TABLES where TABLE_SCHEMA='crmb' and TABLE_NAME='cotizacion_encabezado';";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter red = new OdbcDataAdapter(cmdd);
                DataTable tot = new DataTable();
                red.Fill(tot);
                DataRow rows = tot.Rows[0];
                int codigoObtenido = Convert.ToInt32(rows[0]);
                con.Close();
                return codigoObtenido;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
          //------------------------------ TERMINA CONSULTA AUTOINCREMENT

        

        //Consutla codigoCliente de Cotizacion
        public static Int32 ConsultacodigoClienteCotizacion(string codigoCotiza)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string queryd = "select id_cliente FROM cotizacion_encabezado WHERE id_cotizacion='"+codigoCotiza+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter red = new OdbcDataAdapter(cmdd);
                DataTable tot = new DataTable();
                red.Fill(tot);
                DataRow rows = tot.Rows[0];
                int codigoObtenido = Convert.ToInt32(rows[0]);
                con.Close();
                return codigoObtenido;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }


        //Consulta cliente por cotizacion obtenida
        public static DataTable ConsultaClientePaFactura(string busquedaP)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "select id_cliente, nombres, apellidos, nit FROM tbl_cliente WHERE id_cliente='"+busquedaP+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                con.Close();
                return dtd;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        //---------------------------- ACTUALIZA EXISTENCIA -------------------------------
        ///Actualizar Existencia de productos
        public void ActualziarExistencia(int cantidadNueva,int idProductoP, int idMarcaP, int IdBodegaP)
        {

            String cadena = "update existencia_bodega set cantidad='"+cantidadNueva+"' where id_producto='"+idProductoP+"' and id_marca='"+idMarcaP+"' and id_bodega='"+IdBodegaP+"';";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // ----------------------- TERMINA ACTUALIZA EXISTENCIA ----------------------

        // ------------------------------ AUTO COMPLETE PRODUCTOS ------------------

            //metodo para cargar los datos de la bd
            public DataTable Datos(string BodegaG)
            {
                DataTable dt = new DataTable();

                OdbcConnection conexion = seguridad.Conexion.ObtenerConexionODBC();//cadena conexion
                string consulta = "SELECT eb.id_producto, p.nombre FROM existencia_bodega eb INNER JOIN producto p ON eb.id_producto=p.id_producto WHERE eb.id_bodega='"+BodegaG+"'"; //consulta a la tabla productos
                OdbcCommand comando = new OdbcCommand(consulta, conexion);
                OdbcDataAdapter adap = new OdbcDataAdapter(comando);
                adap.Fill(dt);
                conexion.Close();
                return dt;
            }

            //metodo para cargar la coleccion de datos para el autocomplete
            public AutoCompleteStringCollection Autocomplete()
            {
            CapaDatos nu = new CapaDatos();
            DataTable dt2 = new DataTable();
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //recorrer y cargar los items para el autocompletado
                foreach (DataRow row in dt2.Rows)
                {
                    coleccion.Add(Convert.ToString(row["nombre"]));
                }
                return coleccion;
            }

        // ---------------------- AGREGAR PRODUCTO ------------------------
        // CARGAR TABLA BODEGA
        //Consulta Empleados Combobox
        public DataTable CargarBodegas()
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                string consulta = "select id_bodega, nombre_bodega FROM bodega;";
                OdbcCommand comando = new OdbcCommand(consulta, con);
                OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
                adaptador.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // CONSULTAR CODIGO Y NOMBRE DE PRODUCTO --> DEPENDIENDO BODEGA
        public static DataTable ConsultarCodigoNombreProducto(string IdBodegaP)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT eb.id_producto, p.nombre FROM existencia_bodega eb INNER JOIN producto p ON eb.id_producto=p.id_producto WHERE id_bodega='"+IdBodegaP+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                con.Close();
                return dtd;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // CONSULTA EXISTENCIA DE PRODUCTO
        public static Int32 ConsultaExistenciav1(string ProductoID, string bodegasID)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT cantidad FROM existencia_bodega WHERE id_producto='"+ProductoID+"' and id_bodega='"+bodegasID+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                DataRow rows = dtd.Rows[0];
                int cantidadExistencia = Convert.ToInt32(rows[0]);
                con.Close();
                return cantidadExistencia;
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        // CONSULTA ID_MARCA Y NOMBRE MARCA -- DEPENDIENDO PRODUCTO
        public static DataTable ConsultarMarca(string productoIDD)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT p.id_marca, m.nombre_marca FROM producto p INNER JOIN marca m ON p.id_marca = m.id_marca WHERE p.id_producto='"+productoIDD+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                con.Close();
                return dtd;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // CONSULTA PRECIO UNIDAD DEPENDIENDO DE TIPO CLIENTE
        public static Double ConsultATipoPrecio(string TipoCliente, string IdProductoS)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT precio FROM precio WHERE id_bien='"+IdProductoS+"' and id_tipo='"+TipoCliente+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                DataRow rows = dtd.Rows[0];
                double precioUnidad = Convert.ToDouble(rows[0]);
                con.Close();
                return precioUnidad;
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        // ---------------------------- TERMINA QUERYS DE AGREGAR PRODUCTO ---------------------------------
        // ------------------------QUERIS DE NOMBRES ---------------------
        public static String DescripcionP( string IdProducto)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT nombre FROM producto WHERE id_producto='"+IdProducto+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                DataRow rows = dtd.Rows[0];
                string NombreProducto = Convert.ToString(rows[0]);
                con.Close();
                return NombreProducto;
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static String NombreMarka(string IdMarka)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT nombre_marca FROM marca WHERE id_marca='"+IdMarka+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                DataRow rows = dtd.Rows[0];
                string NombreMarks = Convert.ToString(rows[0]);
                con.Close();
                return NombreMarks;
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        // -------------------- TERMINA QUERIS DE NOMBRES ----------------------
        //------------------------- CONSULTA INSIDENCIA ---------------------
        public static Int32 ConsultaInsidencia(string IDClienteD)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT incidencia FROM tbl_cliente WHERE id_cliente='"+IDClienteD+"'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                DataRow rows = dtd.Rows[0];
                string incidenciass = Convert.ToString(rows[0]);
                int returnIncidencia = Convert.ToInt32(incidenciass);
                con.Close();
                return returnIncidencia;
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        //Consulta Detalle cotizacion de exitentes
        public static DataTable CargarDetalleFactura(string busquedaP)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT d.id_producto, p.nombre, p.id_marca, m.nombre_marca, d.cantidad, d.precioUnidad, d.subtotal FROM detalle_factura d INNER JOIN producto p ON d.id_producto=p.id_producto INNER JOIN marca m ON p.id_marca=m.id_marca WHERE id_factura = '" + busquedaP + "'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                con.Close();
                return dtd;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // ----------------------------
        /*public static String EmpleadoNombre(string IdEmpleado)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT nombres FROM tbl_empleado WHERE id_empleado='" + IdEmpleado + "'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                DataRow rows = dtd.Rows[0];
                string Nombreempleado = Convert.ToString(rows[0]);
                con.Close();
                return Nombreempleado;
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        */
        public static String ClienteNombre(string IdCliente)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "SELECT nombres FROM tbl_cliente WHERE id_cliente='" + IdCliente + "'";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                DataRow rows = dtd.Rows[0];
                string Nombrecliente = Convert.ToString(rows[0]);
                con.Close();
                return Nombrecliente;
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}
