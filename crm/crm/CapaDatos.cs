using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Data;


namespace proyectoUOne
{
    class CapaDatos
    {
        //-------------------SELVIN TINIGUAR RODRI - 0901 - 13 - 8887 ------------------------

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
        public void insertar_detalle_cotizacion(int cod_cotizacionP, int cod_productoP, int cantidadP, double precioP, double subtotalP)
        {
            try
            {
                String query = "insert into cotizacion_detalle(id_cotizacion, id_producto, cantidad, precioUnidad, subtotal, estado) values(" + cod_cotizacionP + "," + cod_productoP + ", " + cantidadP + ","+precioP+"," + subtotalP + ",'ACTIVO')";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        ///Insertar Encabezado Factura a base de datos
        public int GuardarFacturaEncabezado(string fechaP, string formaPagoP, double totalP, int codigoClienteP, string id_empleadoP)
        {
            try
            {
                int devolver = 0;
                String cadena = "insert into factura_encabezado(id_factura, fecha, forma_pago, tipo_documento, marca, total, estado, id_cliente, id_empleado_pk) values(null,'"+ fechaP+"','"+formaPagoP+"','FACTURA','X',"+totalP+",'ACTIVO',"+codigoClienteP+", '"+id_empleadoP+"')";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(cadena, con);
                devolver = cmd.ExecuteNonQuery();
                con.Close();
                return devolver;
            }
            catch { return 0; }

        }

        //Insertar Detalle Factura a base de datos
        public int insertar_detalle_factura(int codigoFacturaP, int codigoProductoP, int cantidadP, double precioP, double subtotalP)
        {
            try
            {
                int devolver = 0;
                String cadena = "insert into detalle_factura(id_factura, id_producto, cantidad, precioUnidad, subtotal, estado) values("+codigoFacturaP+","+codigoProductoP+","+cantidadP+",'"+precioP+"',"+subtotalP+",'ACTIVO')";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(cadena, con);
                devolver = cmd.ExecuteNonQuery();
                con.Close();
                return devolver;
            }
            catch { return 0; }

        }

       
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
            /*try
            {*/
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
                string query = "select p.id_producto, p.nombre, pr.precio, pr.id_bien, pr.id_tipo, pr.id_marca, pe.id_compra FROM producto p INNER JOIN precio pr ON p.id_producto = pr.id_bien INNER JOIN existencia pe ON p.id_producto = pe.id_producto WHERE pr.id_tipo='" + constaP+"' and p.id_producto like '%"+letraP+"%' or pr.id_tipo='"+constaP+"' and p.nombre like '%"+letraP+"%'";
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
                adaptador.Fill(dt);
                con.Close();
                return dt;
            /*}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }*/
        }

        //Consulta Producto cargar Inicio (Buscar Producto)
        public static DataTable CargaProducto2(string constaP)
        {
            /*try
            {*/
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
                string query = "select p.id_producto, p.nombre, pr.precio, pr.id_bien, pr.id_tipo, pr.id_marca, pe.id_compra FROM producto p INNER JOIN precio pr ON p.id_producto = pr.id_bien INNER JOIN existencia pe ON p.id_producto = pe.id_producto WHERE pr.id_tipo = '" + constaP+"' ORDER BY p.nombre ASC";
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataAdapter adaptador = new OdbcDataAdapter(comando);
                adaptador.Fill(dt);
                con.Close();
                return dt;
            /*}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }*/
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
                string queryd = "SELECT id_producto, cantidad, precioUnidad, subtotal FROM cotizacion_detalle WHERE id_cotizacion = '"+busquedaP+"'";
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
                string queryd = "select AUTO_INCREMENT from information_schema.TABLES where TABLE_SCHEMA='crmbd' and TABLE_NAME='cotizacion_encabezado';";
                OdbcCommand cmdd = new OdbcCommand(queryd, con);
                OdbcDataAdapter red = new OdbcDataAdapter(cmdd);
                DataTable tot = new DataTable();
                red.Fill(tot);
                DataRow rows = tot.Rows[0];
                int codigoObtenido = Convert.ToInt32(rows[0]);
                return codigoObtenido;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
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
                return codigoObtenido;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de novato");
                return 0;
            }
        }

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

        //Consulta Existencia Combobox
        public static DataTable Existencia(string idProductoIN, string idMarcaIN)
        {
            try
            {
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                string consulta = "select cantidad FROM existencia WHERE id_producto='"+idProductoIN+"' and id_marca='"+idMarcaIN+"';";
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

        ///Actualizar Existencia de productos
        public void ActualziarExistencia(int cantidadExiste,string idProductoP, string idMarcaP, string IdCompraP)
        {

            String cadena = "update existencia set cantidad='"+cantidadExiste+"' where id_producto='"+idProductoP+"' and id_marca='"+idMarcaP+"' and id_compra='"+IdCompraP+"'";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
