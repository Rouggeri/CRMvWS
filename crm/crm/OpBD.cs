using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;


namespace crm
{
    public class OpBD
    {


        public static bool CambioIdioma { get; set; }
        public static string Idioma { get; set; }



        seguridad.bitacora bita = new seguridad.bitacora();
        

        public static DataTable SeleccionarPaises()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionM();
                OdbcCommand comando = new OdbcCommand("select * from pais", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }



        public static DataTable SeleccionarTipoC()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionM();
                OdbcCommand comando = new OdbcCommand("select * from tipo_precio", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable SeleccionarDatosRestantes(string id_negocio)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionM();
                OdbcCommand comando = new OdbcCommand("select n.detalles, n.etapa_negocio, n.fecha_inicio, n.id_empleado, concat(e.nombres, ' ', e.apellidos) as nom_emp, n.status from tbl_negocio n left join tbl_empleado e on n.id_empleado = e.id_empleado where id_negocio = "+id_negocio+"", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarDatosRestantesCaso(string id_caso)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionM();
                OdbcCommand comando = new OdbcCommand("select c.fecha_asignacion, c.estado_caso, c.descripcion, concat(e.nombres,' ', e.apellidos) as emp, c.id_empleado from caso c left join tbl_empleado e on c.id_empleado = e.id_empleado where id_caso = "+id_caso+"", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarNegocios()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select n.id_negocio, n.titulo, concat(c.nombres,' ',c.apellidos) as nombre_clie, e.nombre,concat(m.nombre,'(', m.simbolo,')') as mon, n.valor, n.fecha_est_cierre, ca.nombre_cat from tbl_negocio n left join tbl_cliente c on n.id_cliente = c.id_cliente left join empresa e on n.id_empresa = e.id_empresa inner join moneda m on n.id_moneda = m.id_moneda inner join categoria_neg ca on n.id_cat = ca.id_cat where n.estado = 'activo' ", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable SeleccionarNegocioEspecifico(string id_negocio)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select n.id_negocio, n.titulo, concat(c.nombres,' ',c.apellidos) as nombre_clie, e.nombre,concat(m.nombre,'(', m.simbolo,')') as mon, n.valor, n.fecha_est_cierre, ca.nombre_cat from tbl_negocio n left join tbl_cliente c on n.id_cliente = c.id_cliente left join empresa e on n.id_empresa = e.id_empresa inner join moneda m on n.id_moneda = m.id_moneda inner join categoria_neg ca on n.id_cat = ca.id_cat where n.id_negocio = "+id_negocio+" ", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable SeleccionarNegociosEtapa0()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select n.id_negocio, n.titulo, concat(c.nombres,' ',c.apellidos) as nombre_clie, e.nombre,concat(m.nombre,'(', m.simbolo,')') as mon, n.valor, n.fecha_est_cierre, ca.nombre_cat from tbl_negocio n left join tbl_cliente c on n.id_cliente = c.id_cliente left join empresa e on n.id_empresa = e.id_empresa inner join moneda m on n.id_moneda = m.id_moneda inner join categoria_neg ca on n.id_cat = ca.id_cat where n.estado = 'activo' and etapa_negocio = 0 ", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarNegociosEtapa1()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select n.id_negocio, n.titulo, concat(c.nombres,' ',c.apellidos) as nombre_clie, e.nombre,concat(m.nombre,'(', m.simbolo,')') as mon, n.valor, n.fecha_est_cierre, ca.nombre_cat from tbl_negocio n left join tbl_cliente c on n.id_cliente = c.id_cliente left join empresa e on n.id_empresa = e.id_empresa inner join moneda m on n.id_moneda = m.id_moneda inner join categoria_neg ca on n.id_cat = ca.id_cat where n.estado = 'activo' and etapa_negocio = 1 ", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarNegociosEtapa2()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select n.id_negocio, n.titulo, concat(c.nombres,' ',c.apellidos) as nombre_clie, e.nombre,concat(m.nombre,'(', m.simbolo,')') as mon, n.valor, n.fecha_est_cierre, ca.nombre_cat from tbl_negocio n left join tbl_cliente c on n.id_cliente = c.id_cliente left join empresa e on n.id_empresa = e.id_empresa inner join moneda m on n.id_moneda = m.id_moneda inner join categoria_neg ca on n.id_cat = ca.id_cat where n.estado = 'activo' and etapa_negocio = 2 ", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarNegociosEtapa3()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select n.id_negocio, n.titulo, concat(c.nombres,' ',c.apellidos) as nombre_clie, e.nombre,concat(m.nombre,'(', m.simbolo,')') as mon, n.valor, n.fecha_est_cierre, ca.nombre_cat from tbl_negocio n left join tbl_cliente c on n.id_cliente = c.id_cliente left join empresa e on n.id_empresa = e.id_empresa inner join moneda m on n.id_moneda = m.id_moneda inner join categoria_neg ca on n.id_cat = ca.id_cat where n.estado = 'activo' and etapa_negocio = 3 ", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarCategorias()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select nombre_cat from categoria_neg", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }
        public static DataTable SeleccionarCategoriascbo()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionM();
                OdbcCommand comando = new OdbcCommand("select * from categoria_neg", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable SeleccionarCategoriasCaso()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionM();
                OdbcCommand comando = new OdbcCommand("select * from categoria_caso", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarClientes()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select id_cliente, concat(nombres,' ',apellidos) as nom from tbl_cliente where estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarDatosRestantesEmpresa(string id_empresa)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select e.direccion, e.correo, e.telefono1, e.telefono2, p.nombre from empresa e inner join pais p on e.id_pais = p.id_pais where id_empresa = "+id_empresa+"", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable SeleccionarDatosRestantesPersona(string id_persona)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select c.puesto, e.nombre, c.telefono, c.movil, c.tipo, c.estatus, c.correo from tbl_cliente c left join empresa e on c.id_empresa = e.id_empresa where id_cliente = "+id_persona+"", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable SeleccionarDatosRestantesPersona2(string id_persona)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select c.puesto,c.nombres, c.apellidos, e.nombre, c.telefono, c.movil, c.tipo, c.estatus, c.correo from tbl_cliente c left join empresa e on c.id_empresa = e.id_empresa where id_cliente = " + id_persona + "", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }



        public static DataTable SeleccionarEmpleados()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select id_empleado, concat(id_empleado,' - ',nombres,' ',apellidos) as Empleado from tbl_empleado where estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarMonedas()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select id_moneda, concat(simbolo,' - ',nombre) as Moneda from moneda where estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarNotas(string id_negocio)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select * from notas where id_negocio = '"+id_negocio+"'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarNotasCaso(string id_caso)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select * from notas_caso where id_caso = " + id_caso + "", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarEmpresas()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select id_empresa, nombre from empresa where estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

   

        public int InsertarNegocioClie(string titulo, int perem, string detalles, int moneda, decimal valor, int cat, int empleado, int etapa, string fecha)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "insert into tbl_negocio(id_negocio, etapa_negocio, id_cliente, id_empleado, titulo, detalles, id_moneda, valor, fecha_est_cierre, fecha_inicio, id_cat, id_empresa, estado, status)" +
                   " values ( null ," + etapa + ", " + perem + "," + empleado + ",'" + titulo + "','" + detalles + "'," + moneda + ","+valor+",'"+fecha+"',curdate(),"+cat+",0,'activo', 'Proceso')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de negocio: " + titulo, "tbl_negocio");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int InsertarNegocioEmp(string titulo, int perem, string detalles, int moneda, decimal valor, int cat, int empleado, int etapa, string fecha)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "insert into tbl_negocio(id_negocio, etapa_negocio, id_empresa, id_empleado, titulo, detalles, id_moneda, valor, fecha_est_cierre, fecha_inicio, id_cat, id_cliente ,estado, status)" +
                   " values ( null ," + etapa + ", " + perem + "," + empleado + ",'" + titulo + "','" + detalles + "'," + moneda + "," + valor + ",'" + fecha + "',curdate()," + cat + ",0,'activo', 'Proceso')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de negocio: " + titulo, "tbl_negocio");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int InsertarEmpresa(string nombre, string direccion, string correo, string tel1, string tel2, int pais)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionM();
                string query = "insert into empresa(id_empresa, nombre, direccion, correo, telefono1, telefono2, id_pais,estado)"+
                   " values ( null ,'" + nombre + "', '" + direccion + "','"+correo+"','"+tel1+"','"+tel2+"',"+pais+",'activo')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de empresa: " + nombre, "empresa");
                }
                catch { MessageBox.Show("Error en bitacora"); }
                
                con.Close();
                return 1;
            }
            catch { return 0; }
        }


        public int ActualizarEmpresa(string nombre, string direccion, string correo, string tel1, string tel2, int pais, string id_empresa)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionM();
                string query = "update empresa " +
                   "set nombre = '" + nombre + "', direccion = '" + direccion + "',correo = '" + correo + "',telefono1='" + tel1 + "',telefono2='" + tel2 + "',id_pais = " + pais + " where id_empresa = "+id_empresa+"";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Modificacion de empresa: " + nombre, "empresa");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public  int InsertarCategoria(string nombre)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "insert into categoria_neg(id_cat, nombre_cat, estado)" +
                   " values ( null ,'" + nombre + "','activo')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de categoria: " + nombre, "categoria_neg");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int InsertarNota(string nota, string id_negocio, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "insert into notas(id_nota, id_negocio, nota)" +
                   " values ( null ," + id_negocio + ",'"+nota+"')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de una nota en el negocio: "+titulo, "notas");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int InsertarNotaCaso(string nota, string id_caso, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "insert into notas_caso(id_nota, id_caso, nota)" +
                   " values ( null ," + id_caso + ",'" + nota + "')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de una nota en el caso: " + titulo, "notas");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int ActualizarNota(string nota, string id_nota, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update notas set nota = '"+nota+"' where id_nota = "+id_nota+" ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Actualizacion de una nota en el negocio: " + titulo, "notas");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int ActualizarNotaCaso(string nota, string id_nota, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update notas_caso set nota = '" + nota + "' where id_nota = " + id_nota + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Actualizacion de una nota en el caso: " + titulo, "notas_caso");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int EliminarNota(string id_nota, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "delete from notas where id_nota = " + id_nota + "";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Eliminación de una nota en el negocio: " + titulo, "notas");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int EliminarNotaCaso(string id_nota, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "delete from notas_caso where id_nota = " + id_nota + "";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Eliminación de una nota en el caso: " + titulo, "notas_caso");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public static string VerificarTipoUsuario()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ConexionPermisos();
                OdbcCommand comando = new OdbcCommand("select tipo from usuario where usuario = '"+seguridad.Conexion.User+"'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);

                DataRow row = dt.Rows[0];
                string tipo = row[0].ToString();
                return tipo;
            }
            catch { return "error"; }
        }




        //public static DataTable PermisosDeUsuario(string id_negocio)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        OdbcConnection con = seguridad.Conexion.ConexionPermisos();
        //        OdbcCommand comando = new OdbcCommand("select ins, from notas where id_negocio = '" + id_negocio + "'", con);
        //        OdbcDataAdapter ad = new OdbcDataAdapter(comando);
        //        ad.Fill(dt);
        //        return dt;
        //    }
        //    catch { return null; }
        //}

        public int ActualizarEstatus(string estatus, string id_negocio, string nombre)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update tbl_negocio set status = '" + estatus + "' where id_negocio = " +id_negocio + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Actualizacion del estado del negocio: " + nombre, "negocio");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }





        public int InsertarTarea(string descripcion, string fechahora, int id_empleado, string tipo, string id_negocio, string titulo, string criticidad, string hora_terminacion)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "insert into tbl_tarea(id_tarea, estado_tarea, id_empleado, fecha_asignacion, fecha_establecida, descripcion_tarea, id_negocio, estado, id_tipo, id_caso, origen, criticidad, hora_fin)" +
                   " values ( null ,'Pendiente'," +id_empleado + ",curdate(),'"+fechahora+"','"+descripcion+"',"+id_negocio+", 'activo', "+tipo+",0, 'negocio', '"+criticidad+"', '"+hora_terminacion+"')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de tarea en el negocio: " + titulo , "tbl_tarea");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int InsertarTareaCaso(string descripcion, string fechahora, int id_empleado, string tipo, string id_caso, string titulo, string criticidad, string hora_terminacion)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "insert into tbl_tarea(id_tarea, estado_tarea, id_empleado, fecha_asignacion, fecha_establecida, descripcion_tarea, id_negocio, estado, id_tipo, id_caso, origen, criticidad, hora_fin)" +
                   " values ( null ,'Pendiente'," + id_empleado + ",curdate(),'" + fechahora + "','" + descripcion + "',0, 'activo', " + tipo + ","+id_caso+", 'caso', '" + criticidad + "','"+hora_terminacion+"')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de tarea en el caso: " + titulo, "tbl_tarea");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }


        public static DataTable SeleccionarTareasNEG(string id_negocio)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select t.descripcion_tarea, t.fecha_establecida, tt.tipo, concat(e.nombres,' ', e.apellidos) as empleado, t.estado_tarea, t.criticidad, t.id_tarea, concat(e.id_empleado,' - ',e.nombres,' ',e.apellidos) as Emp, t.hora_fin from tbl_tarea t left join tbl_empleado e on t.id_empleado = e.id_empleado inner join tipo_tarea tt on t.id_tipo = tt.id_tipo where t.estado = 'activo' and t.id_negocio = " + id_negocio+"", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable SeleccionarTareasCaso(string id_caso)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select t.descripcion_tarea, t.fecha_establecida, tt.tipo, concat(e.nombres,' ', e.apellidos) as empleado, t.estado_tarea, t.criticidad, t.id_tarea, concat(e.id_empleado,' - ',e.nombres,' ',e.apellidos) as Emp, t.hora_fin from tbl_tarea t left join tbl_empleado e on t.id_empleado = e.id_empleado inner join tipo_tarea tt on t.id_tipo = tt.id_tipo where t.estado = 'activo' and t.id_caso = " + id_caso + "", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable SeleccionarTipoTarea()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select * from tipo_tarea", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable SeleccionarIdEmpleado(string id_tarea)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select id_empleado from tbl_tarea where id_tarea = "+id_tarea+"", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }



        public int EliminarTarea(string tarea, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update tbl_tarea set estado = 'inactivo' where id_tarea = " + tarea + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("eliminación de tarea  del negocio: " + titulo, "tarea");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int EliminarTareaCaso(string tarea, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update tbl_tarea set estado = 'inactivo' where id_tarea = " + tarea + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("eliminación de tarea  del caso: " + titulo, "tarea");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }


        public int ActualizarTarea(string id_tarea, string descripcion, string fechahora, string empleado, string tipo, string criticidad, string titulo, string hora_terminacion )
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update tbl_tarea set descripcion_tarea = '"+descripcion+"', fecha_establecida = '"+fechahora+"', id_empleado = "+empleado+", id_tipo = "+tipo+", criticidad = '"+criticidad+"', hora_fin = '"+hora_terminacion+"' where id_tarea = " + id_tarea + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Mmodificacion de tarea  del negocio: " + titulo, "tarea");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }


        public int ActualizarTareaCaso(string id_tarea, string descripcion, string fechahora, string empleado, string tipo, string criticidad, string titulo, string hora_terminacion)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update tbl_tarea set descripcion_tarea = '" + descripcion + "', fecha_establecida = '" + fechahora + "', id_empleado = " + empleado + ", id_tipo = " + tipo + ", criticidad = '" + criticidad + "', hora_fin = '"+hora_terminacion+"' where id_tarea = " + id_tarea + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Mmodificacion de tarea  del caso: " + titulo, "tarea");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }











        //public static void DesbloquearMDI(MenuStrip MenuMDI)
        //{

        //    DataTable dt_permisos = new DataTable();
        //    OdbcConnection con = seguridad.Conexion.ConexionPermisos();
        //    OdbcCommand comando = new OdbcCommand("select p.id_aplicacion, a.id_modulo from usuario_privilegios p inner join aplicacion a on p.id_aplicacion = a.id_aplicacion where p.usuario = '"+seguridad.Conexion.User+"' ", con);
        //    OdbcDataAdapter ad = new OdbcDataAdapter(comando);
        //    ad.Fill(dt_permisos);

        //    foreach (ToolStripMenuItem menu_principal in MenuMDI.Items)
        //    {
        //        string modulo_menu = "0";
        //        if (menu_principal.Tag != null)
        //        {
        //             modulo_menu = menu_principal.Tag.ToString();
        //        }
        //        foreach (DataRow row_aplicaciones in dt_permisos.Rows)
        //        {
        //            string modulo_aplicacion = row_aplicaciones[1].ToString();
        //            if (modulo_aplicacion == modulo_menu)
        //            {
        //                menu_principal.Enabled = true;
        //                break;
        //            }
        //        }
        //    }

        //    foreach (ToolStripMenuItem menu_principal in MenuMDI.Items)
        //    {

        //        foreach (ToolStripMenuItem sub_menu in menu_principal.DropDownItems)
        //        {
        //            string aplicacion_menu = "0";
        //            if (sub_menu.Tag != null)
        //            {
        //                aplicacion_menu = sub_menu.Tag.ToString();
        //            }
        //            foreach (DataRow row_aplicaciones in dt_permisos.Rows)
        //            {
        //                string aplicacion = row_aplicaciones[0].ToString();
        //                if (aplicacion == aplicacion_menu)
        //                {
        //                    sub_menu.Enabled = true;
        //                    break;
        //                }
        //            }


        //        }

        //    }





        //}



        public int EliminarNegociacion(string id_negocio, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update tbl_negocio set estado = 'inactivo' where id_negocio = " + id_negocio + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("eliminación de negocio : " + titulo, "tbl_negocio");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }


        public int EliminarCaso(string id_caso, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update caso set estado = 'inactivo' where id_caso = " + id_caso + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("eliminación de caso : " + titulo, "caso");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }





        public int ActualizarNegocioClie(string titulo, int perem, string detalles, int moneda, decimal valor, int cat, int empleado, int etapa, string fecha, string id_negocio)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update tbl_negocio set etapa_negocio = " + etapa + ", id_cliente = " + perem + ", id_empresa = 0, id_empleado = " + empleado + ", titulo= '" + titulo + "', detalles = '" + detalles + "', id_moneda = " + moneda + ", valor = " + valor + ", fecha_est_cierre = '" + fecha + "', id_cat = " + cat + " where id_negocio = "+id_negocio+" ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("modificación de negocio: " + titulo, "tbl_negocio");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int ActualizarNegocioEmp(string titulo, int perem, string detalles, int moneda, decimal valor, int cat, int empleado, int etapa, string fecha, string id_negocio)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update tbl_negocio set etapa_negocio = " + etapa + ", id_empresa = " + perem + ", id_cliente = 0, id_empleado = " + empleado + ", titulo= '" + titulo + "', detalles = '" + detalles + "', id_moneda = " + moneda + ", valor = " + valor + ", fecha_est_cierre = '" + fecha + "', id_cat = " + cat + " where id_negocio = "+id_negocio+" ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("modificación de negocio: " + titulo, "tbl_negocio");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int ActualizarCasoClie(string titulo, int perem, string detalles, int cat, int empleado, string fecha, string id_caso)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update caso set  id_cliente = " + perem + ",id_empresa = 0, id_empleado = " + empleado + ", titulo= '" + titulo + "', descripcion = '" + detalles + "',  fecha_finalizacion = '" + fecha + "', id_cat_caso = " + cat + " where id_caso = " + id_caso + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("modificación de caso: " + titulo, "caso");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }


        public int ActualizarCasoEmp(string titulo, int perem, string detalles, int cat, int empleado, string fecha, string id_caso)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update caso set  id_cliente = 0,id_empresa = "+perem+", id_empleado = " + empleado + ", titulo= '" + titulo + "', descripcion = '" + detalles + "',  fecha_finalizacion = '" + fecha + "', id_cat_caso = " + cat + " where id_caso = " + id_caso + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("modificación de caso: " + titulo, "caso");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }


        public int InsertarCasoClie(string titulo, int perem, string descripcion,int cat,int empleado, string fecha)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "insert into caso(id_caso, id_empleado, id_cliente, id_empresa, titulo, estado_caso, fecha_finalizacion, fecha_asignacion,  descripcion, estado, id_cat_caso)" +
                   " values ( null ," + empleado + ", " + perem + ", 0 ,'" + titulo + "','Abierto','" + fecha + "',curdate(),'" + descripcion + "','activo'," + cat + ")";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de caso: " + titulo, "caso");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }


        public int InsertarCasoEmp(string titulo, int perem, string descripcion, int cat, int empleado, string fecha)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "insert into caso(id_caso, id_empleado, id_cliente, id_empresa, titulo, estado_caso, fecha_finalizacion, fecha_asignacion,  descripcion, estado, id_cat_caso)" +
                   " values ( null ," + empleado + ", 0, "+perem+" ,'" + titulo + "','Abierto','" + fecha + "',curdate(),'" + descripcion + "','activo'," + cat + ")";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("Registro de caso: " + titulo, "caso");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }



        public static DataTable SeleccionarCasos()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select c.id_caso, c.titulo, concat(p.nombres,' ',p.apellidos) as Persona, e.nombre, c.fecha_finalizacion, ct.nombre_caso, c.estado_caso from caso c left join tbl_cliente p on c.id_cliente = p.id_cliente left join empresa e on c.id_empresa = e.id_empresa inner join categoria_caso ct on c.id_cat_caso = ct.id_cat_caso where c.estado = 'activo' ", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }




        public int ActualizarEstadoCaso(string estado, string id_caso, string titulo)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update caso set estado_caso = '"+estado+"' where id_caso = " + id_caso + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("actualizacion de estado del caso : " + titulo, "caso");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }


        public static DataTable CNA_empresa(string id_empresa)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select count(*) from tbl_negocio where id_empresa = "+id_empresa+" and etapa_negocio <> 3 and estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable CNC_empresa(string id_empresa)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select count(*) from tbl_negocio where id_empresa = " + id_empresa + " and etapa_negocio = 3 and estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable CCA_empresa(string id_empresa)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select count(*) from caso where id_empresa = "+id_empresa+" and estado_caso = 'Abierto' and estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable CCC_empresa(string id_empresa)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select count(*) from caso where id_empresa = " + id_empresa + " and estado_caso = 'cerrado' and estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable CNA_persona(string id_persona)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select count(*) from tbl_negocio where id_cliente = "+id_persona+" and etapa_negocio <> 3 and estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public static DataTable CNC_persona(string id_persona)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select count(*) from tbl_negocio where id_cliente = " + id_persona + " and etapa_negocio = 3 and estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

        public static DataTable CCA_persona(string id_persona)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select count(*) from caso where id_cliente = "+id_persona+" and estado_caso = 'Abierto' and estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }



        public static DataTable CCC_persona(string id_persona)
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select count(*) from caso where id_cliente = " + id_persona + " and estado_caso = 'cerrado' and estado = 'activo'", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }


        public int EliminarEmpresa(string id_empresa, string nombre)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update empresa set estado = 'inactivo' where id_empresa = " + id_empresa + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("eliminación de empresa : " + nombre, "empresa");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }



        public int EliminarPersona(string id_persona, string persona)
        {
            try
            {

                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                string query = "update tbl_cliente set estado = 'inactivo' where id_cliente = " + id_persona + " ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    bita.Insertar("eliminación de persona : " + persona, "tbl_cliente");
                }
                catch { MessageBox.Show("Error en bitacora"); }

                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public static DataTable SeleccionarTareasCalendario()
        {
            try
            {
                DataTable dt = new DataTable();
                OdbcConnection con = seguridad.Conexion.ObtenerConexionODBC();
                OdbcCommand comando = new OdbcCommand("select t.descripcion_tarea, t.fecha_establecida, t.hora_fin, t.estado_tarea, t.origen, t.id_tipo, ti.tipo, n.titulo, c.titulo from tbl_tarea t inner join tipo_tarea ti on t.id_tipo = ti.id_tipo left join tbl_negocio n on t.id_negocio = n.id_negocio left join caso c on t.id_caso = c.id_caso where t.estado = 'activo' ", con);
                OdbcDataAdapter ad = new OdbcDataAdapter(comando);
                ad.Fill(dt);
                return dt;
            }
            catch { return null; }
        }

    }
}
