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

        //Insertar Encabezado Cotizacion a base de datos
        public void InsertarCotizacion(string clienteP, string correoP, string fechaIniciosP, string fechaTerminasP)
        {

            String cadena = "insert into cotizacion_encabezado(id_cotizacion,cliente, correo, fechaInicio, fechaTermina, estadoCotizacion, estado) values(null,'" + clienteP + "','" + correoP + "','" + fechaIniciosP + "','" + fechaTerminasP + "','ESPERA','ACTIVO')";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Insertar Detalle Cotizacion a base de datos
        public void insertar_detalle_cotizacion(int cod_cotizacionP, int cod_productoP, int cantidadP, double subtotalP)
        {
            try
            {

                String query = "insert into cotizacion_detalle(id_cotizacion, id_producto, cantidad, subtotal, estado) values(" + cod_cotizacionP + "," + cod_productoP + ", " + cantidadP + "," + subtotalP + ",'ACTIVO')";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        ///Insertar Encabezado Factura a base de datos
        public int GuardarFacturaEncabezado(string fechaP, string formaPagoP, double totalP, int codigoClienteP)
        {
            try
            {
                int devolver = 0;
                String cadena = "insert into factura_encabezado(id_factura, fecha, forma_pago, total, estado, id_cliente) values(null,'" + fechaP + "','" + formaPagoP + "'," + totalP + ",'activo'," + codigoClienteP + ")";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(cadena, con);
                devolver = cmd.ExecuteNonQuery();
                con.Close();
                return devolver;
            }
            catch { return 0; }

        }

        //Insertar Detalle Factura a base de datos
        public int insertar_detalle_factura(int codigoFacturaP, int codigoProductoP, int cantidadP, double subtotalP)
        {
            try
            {
                int devolver = 0;
                String cadena = "insert into detalle_factura(id_factura, id_producto, cantidad, subtotal, estado) values(" + codigoFacturaP + "," + codigoProductoP + "," + cantidadP + "," + subtotalP + ",'activo')";
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand(cadena, con);
                devolver = cmd.ExecuteNonQuery();
                con.Close();
                return devolver;
            }
            catch { return 0; }

        }

        //Insertar Cliente a base de datos
        public int GuardarCliente(int nitP, string nombreP, string apellidoP, string direccionP, int telefonoP, int tipoP)
        {
            try
            {
                int devolver = 0;
                String cadena = "insert into cliente_m(id_cliente, nit, nombre, apellido, direccion, telefono, estado, tipo) values(null," + nitP + ",'" + nombreP + "','" + apellidoP + "','" + direccionP + "'," + telefonoP + ",'activo', "+tipoP+");";
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
        public void InsertarProducto(string descripcionP, double preciP, double precioMayorP)
        {

            String cadena = "insert into producto_m(id_producto, descripcion, precio_unidad, precio_mayorista, estado) values(null,'"+descripcionP+"',"+preciP+","+precioMayorP+",'ACTIVO')";
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            OdbcCommand cmd = new OdbcCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Consulta Precio_Unidad de Producto
        public DataTable query_precioUnidad(int codigoPP)
        {
            OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
            string query = "select precio_unidad from producto_m where id_producto= " + codigoPP + ";";
            OdbcCommand cmd = new OdbcCommand(query, con);
            OdbcDataAdapter da1 = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            return dt;
            //cmb_codigo.ValueMember = "cod_producto";
            //cmb_codigo.DisplayMember = "cod_producto";
            //cmb_codigo.DataSource = dt;
        }

        //Consulta Varios Campos, Codigo y Nombre de Cliente
        public static DataTable ConsultaCodigoYNombre(String busquedaP)
        {
            try
            {
                OdbcConnection conn = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "select * from cliente_m WHERE id_cliente like '%"+busquedaP+"%' or nombre like '%"+busquedaP+"%'";
                OdbcCommand cmdd = new OdbcCommand(queryd, conn);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                conn.Close();
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
                OdbcConnection conn = seguridad.Conexion.ObtenerConexionODBC();
                DataTable dtd = new DataTable();
                string queryd = "select id_producto, cantidad, subtotal from cotizacion_detalle WHERE id_cotizacion = " + busquedaP + "";
                OdbcCommand cmdd = new OdbcCommand(queryd, conn);
                OdbcDataAdapter adapd = new OdbcDataAdapter(cmdd);
                adapd.Fill(dtd);
                conn.Close();
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
        public void ActualziarCotizacionEncabezado(string clienteS, string correoS, string FechaIn, string fechaTer, string id_CotizacionS)
        {

            String cadena = "update cotizacion_encabezado set cliente='"+clienteS+"',correo='"+correoS+"',fechaInicio='"+FechaIn+"',fechaTermina='"+fechaTer+"'where id_cotizacion='"+id_CotizacionS+"'";
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

    }
}
