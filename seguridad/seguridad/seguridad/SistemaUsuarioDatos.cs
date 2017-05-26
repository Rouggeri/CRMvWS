using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;


namespace seguridad
{
    public class SistemaUsuarioDatos
    {


        bitacora bitacora = new bitacora();
        public DataTable ObtenerPerfiles()
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select id_perfil, nombre_perfil from perfil",con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable ObtenerAplicaciones()
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select * from aplicacion", con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable ObtenerPermisosPorPerfilesdg(string perfil)
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            
            DataTable dt = new DataTable();
            string query = "select a.nombre_aplicacion, p.ins, p.sel, p.upd, p.del from aplicacion a inner join perfil_privilegios p on a.id_aplicacion = p.id_aplicacion where p.id_perfil = " + perfil;
            OdbcCommand cmd = new OdbcCommand(query, con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);

            
            con.Close();
            return dt;
            
        }

        public DataTable ObtenerPermisosPorPerfilesdt(string perfil)
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            string query = "select id_aplicacion, ins, sel, upd, del, id_perfil from  perfil_privilegios where id_perfil = " + perfil;
            OdbcCommand cmd = new OdbcCommand(query, con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;

        }

        public int InsertarPerfil(string nombre_perfil)
        {

            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string query = "insert into perfil (id_perfil, nombre_perfil) values (null, '" + nombre_perfil + "')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                bitacora.Registro("Creacion de perfil:" +nombre_perfil, "perfil");
                con.Close();
                return 1;
                
            }
            catch { return 0; }
        }
        public int InsertarUsuario(string usuario, string contraseña)
        {

            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string query = "insert into usuario (usuario, contrasenia, fecha_creacion) values ('" + usuario + "', '" + contraseña + "', curdate())";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int InsertarUsuario2(string usuario,  string contraseña, string empleado)
        {

            try
           {
                contraseña = Encriptar(contraseña);
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string query = "insert into usuario (usuario, contrasenia, fecha_creacion, id_empleado) values ('"+usuario+"', '" + contraseña + "', curdate(),'"+empleado+"')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                bitacora.Registro("Asignacion del usuario: " +usuario+ " al empleado: " +empleado, "usuario");
                return 1;
            }
            catch {
                bitacora.ErrorOp("Error al crear usuario" + usuario, "usuario");
                    return 0;
            }
        }


        public int InsertarUsuarioAdministrador(string usuario, string contraseña, string empleado)
        {

            try
            {
                contraseña = Encriptar(contraseña);
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string query = "insert into usuario (usuario, contrasenia, fecha_creacion, id_empleado, tipo) values ('" + usuario + "', '" + contraseña + "', curdate(),'" + empleado + "', 'administrador')";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                bitacora.Registro("Asignacion del usuario: " + usuario + " al empleado: " + empleado, "usuario");
                return 1;
            }
            catch
            {
                bitacora.ErrorOp("Error al crear usuario" + usuario, "usuario");
                return 0;
            }
        }

        public int CrearUsuario(string usuario, string contraseña)
        {
            try
            {
                contraseña = Encriptar(contraseña);
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string query = "create user " + usuario + " identified by '" + contraseña + "' ";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                bitacora.Insertar("Creacion usuario: " + usuario, "usuario");
                PermisoBitacora(usuario);
                return 1;
            }
            catch {
                bitacora.ErrorOp("Error al crear usuario a nivel DBS" + usuario, "dbo.users");
                return 0;
            }
        }
        public void PermisoBitacora(string usuario)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string query = "grant insert on bitacora to '"+usuario+"'";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    
                    string query2 = "grant execute on function registraroperacion to '"+usuario+"'";
                    OdbcCommand cmd2 = new OdbcCommand(query2, con);
                    cmd.ExecuteNonQuery();
                    
                }
                catch
                {
                    MessageBox.Show("Error en funcion de registro");
                }
                con.Close();
                bitacora.Registro("Se otorga permiso sobre bitacora al usuario: " + usuario, "bitacora");
            }
            catch
            {
                MessageBox.Show("Error al asignar permisos a usuario: " + usuario + " con la bitacora");
            }
        }

        public int InsertarPermisosPerfil( DataTable permisos)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();

                DataTable dt = new DataTable();
                string querys = "select max(id_perfil)from perfil";
                OdbcCommand cmds = new OdbcCommand(querys, con);
                OdbcDataAdapter adap = new OdbcDataAdapter(cmds);
                adap.Fill(dt);
                DataRow row2 = dt.Rows[0];
                string id_perfil = row2[0].ToString();

                foreach (DataRow row in permisos.Rows)
                {
                    string query = "insert into perfil_privilegios (id_perfil, id_aplicacion, ins, sel, upd, del) values (" + id_perfil + ", " + row[0].ToString() + ", " + row[1] + "," + row[2] + "," + row[3] + ", " + row[4] + " )";
                    bitacora.Permisos("Asignacion de permiso: "+"ins: "+ row[1].ToString() +" sel: "+ row[2].ToString() + " upd: "+row[3].ToString() + " del: " + row[4].ToString() + " a perfil: "+id_perfil+" Sobre aplicacion: "+row[0].ToString(), "perfil_privilegios");
                    OdbcCommand cmd = new OdbcCommand(query, con);
                    cmd.ExecuteNonQuery();
                    
                }
                //con.Close();
                return 1;
            }
            catch { return 0; }
        }



        public DataTable ObtenerUsuarios()
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select usuario from usuario", con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable SeleccionaEmpleados()
        {
            OdbcConnection con = Conexion.ConexionPermisos();
            DataTable dt = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select id_empleado, concat(nombres,' ', apellidos) as NOM from tbl_empleado where estado = 'activo'", con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;
        }

        public int InsertarPermisosUsuario(DataTable permisos, string usuario)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();

                foreach (DataRow row in permisos.Rows)
                {
                    string query = "insert into usuario_privilegios (usuario, id_aplicacion, ins, sel, upd, del, id_perfil) values ('" + usuario + "', " + row[0].ToString() + ", " + row[1] + "," + row[2] + "," + row[3] + ", " + row[4] + ","+ row[5] + " )";
                    OdbcCommand cmd = new OdbcCommand(query, con);
                    cmd.ExecuteNonQuery();
                    bitacora.Permisos("Asignacion de permiso: " + "ins: " + row[1].ToString() + " sel: " + row[2].ToString() + " upd: " + row[3].ToString() + " del: " + row[4].ToString() + " a usuario: "+usuario+" Sobre aplicacion: "+row[0].ToString(), "usuario_privilegios");
                    
                }
                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public DataTable ObtenerPermisosPorUsuariodg(string usuario)
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();

            DataTable dt = new DataTable();
            string query = "select a.nombre_aplicacion, p.ins, p.sel, p.upd, p.del from aplicacion a inner join usuario_privilegios p on a.id_aplicacion = p.id_aplicacion where p.usuario = '" + usuario+"'";
            OdbcCommand cmd = new OdbcCommand(query, con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);


            con.Close();
            return dt;

        }

        public DataTable ObtenerPermisosPorUsuariodt(string usuario)
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            string query = "select id_aplicacion, ins, sel, upd, del, id_perfil from  usuario_privilegios where usuario = '" +usuario+"'";
            OdbcCommand cmd = new OdbcCommand(query, con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable ObtenerPerfilDeUsuario(string usuario)
        {
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            string query = "select u.usuario, p.nombre_perfil from usuario u inner join perfil p on u.id_perfil = p.id_perfil where u.usuario = '" + usuario + "'";
            OdbcCommand cmd = new OdbcCommand(query, con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;

        }


        public int EliminarPermisos(string usuario)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand("delete from usuario_privilegios where usuario = '" + usuario + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                bitacora.Permisos("Eliminacion de privilegios para usuario: " + usuario, "usuario_privilegios");
                return 1;
            }
            catch
            {
                bitacora.ErrorOp("Error al eliminar privilegios para el usuario: " + usuario, "usuario_privilegios");
                return 0;
            }
           
        }

        public int EliminarPermisosPerfil(string perfil)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand("delete from perfil_privilegios where id_perfil = " + perfil + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                bitacora.Permisos("Eliminacion de privilegios a perfil: " + perfil, "perfil_privilegios");
                return 1;
            }
            catch
            {
                bitacora.ErrorOp("Error al revocar privilegios al perfil: " +perfil, "perfil_privilegios");
                return 0;
            }

        }


        //public int ActualizarPerfil(string usuario, int perfil)
        //{
        //    try
        //    {
        //        OdbcConnection con = Conexion.ObtenerConexionODBC();
        //        OdbcCommand cmd = new OdbcCommand("update  usuario set  id_perfil = "+perfil+" where usuario = '" + usuario + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        bitacora.Permisos("Actualizacion de permisos de perfil: " + perfil + " para el usuario: " + usuario,"usuario");
        //        return 1;

        //    }
        //    catch {
        //        bitacora.ErrorOp("Error actualizar privilegios para el usuario: " + usuario+ " Con el perfil: "+perfil, "usuario");
        //        return 0;
        //    }

        //}

        public int InsertarPermisosPerfilEditar(DataTable permisos, int perfil)
        {
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                foreach (DataRow row in permisos.Rows)
                {
                    string query = "insert into perfil_privilegios (id_perfil, id_aplicacion, ins, sel, upd, del) values (" + perfil + ", " + row[0].ToString() + ", " + row[1] + "," + row[2] + "," + row[3] + ", " + row[4] + " )";
                    OdbcCommand cmd = new OdbcCommand(query, con);
                    cmd.ExecuteNonQuery();
                    bitacora.Permisos("Actualizacion de permisos: ins: " + row[1].ToString() + " sel: "+row[2].ToString()+" upd: "+row[3].ToString()+" del: " + row[4].ToString(), "privilegios_perfil");
                }
                con.Close();
                return 1;
            }
            catch { return 0; }
        }

        public int RevocarPermisoUs (string usuario, string perfil)
        {
            try
            {

                OdbcConnection con = Conexion.ObtenerConexionODBC();
                OdbcCommand cmd = new OdbcCommand("delete from usuario_privilegios where id_perfil = " + perfil + " and usuario = '"+usuario+"'", con);
                cmd.ExecuteNonQuery();
                bitacora.Permisos("Se revocaron permisos del perfil: " + perfil + " al usuario:" + usuario, "usuario_privilegios");
                con.Close();

                return 1;
            }
            catch {
                bitacora.ErrorOp("Error al revocar permisos del perfil: " + perfil + " Con el usuario: " + usuario, "usuario_privilegios");
                return 0;
            }
        }

        public DataTable SeleccionarUsuariosPorPerfil(string perfil)
        {
            
            
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                OdbcCommand cmd = new OdbcCommand("select distinct usuario from usuario_privilegios where id_perfil = "+perfil, con);
                OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;
            
            
        }

        public int OtorgarPerfil(string usuario, DataTable permisos, string perfil)
        {
            //try
            //{
                OdbcConnection con = Conexion.ObtenerConexionODBC();

                foreach (DataRow row in permisos.Rows)
                {
                try
                {
                    string query = "insert into usuario_privilegios (usuario, id_aplicacion, ins, sel, upd, del, id_perfil) values ('" + usuario + "', " + row[0].ToString() + ", " + row[1] + "," + row[2] + "," + row[3] + ", " + row[4] + ", " + perfil + ")";
                    OdbcCommand cmd = new OdbcCommand(query, con);
                    cmd.ExecuteNonQuery();
                    bitacora.Permisos("Asignacion de permiso: " + "ins: " + row[1].ToString() + " sel: " + row[2].ToString() + " upd: " + row[3].ToString() + " del: " + row[4].ToString() + " a usuario: " + usuario + " Sobre aplicacion: " + row[0].ToString()+ "Con el perfil: "+perfil, "usuario_privilegios");
                }
                catch {
                    bitacora.ErrorOp("Error al otorgar permisos del perfil: " + perfil + "al usuario: " + usuario, "usuario_privilegios");
                }
                }
                con.Close();
                return 1;
           // }
           //catch { return 0; }
        }
        public DataTable SeleccionaEmpresa()
        {


            OdbcConnection con = Conexion.ObtenerConexionODBC();
            DataTable dt = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select distinct id_empresa_pk, nombre from empresa", con);
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;
           
        }
        public DataTable SeleccionaColaborador(string id_emp)
        {
           
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                OdbcCommand cmd = new OdbcCommand("select distinct id_empleados_pk, nombre from empleado where id_empresa_pk ='" + id_emp + "' ", con);
                OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;
        }
        public string Encriptar(string psw)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(psw.Trim());
            result = Convert.ToBase64String(encryted);
            return result;
        }
        //public DataTable datos_colaborador(string id_emp, string id_colab)
        //{
        //    try
        //    {
        //        OdbcConnection con = Conexion.ObtenerConexionODBC();
        //        DataTable dt = new DataTable();
        //        OdbcCommand cmd = new OdbcCommand("Select nombre, dpi, fecha_nacimiento, fecha_ingreso FROM empleado where id_empresa_pk ='" + id_emp + "' and id_empleados_pk='" + id_emp + "'", con);
        //        OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
        //        adp.Fill(dt);
        //        con.Close();
        //        return dt;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("No se pueden cargar los datos del colaborador");
        //        return null;
        //    }
           
        //}
        public DataTable encuentra_colaborador(string usuario)
        {
            try
            {
                OdbcConnection con = Conexion.ConexionPermisos();
                DataTable dt = new DataTable();
                OdbcCommand cmd = new OdbcCommand("Select u.id_empresa_pk as empresa, u.id_empleados_pk as empleado, e.nombre as nombre,e.dpi as dpi,e.fecha_nacimiento as fecha_nacimiento, e.fecha_ingreso as fecha_ingreso from usuario u, empleado e where u.usuario='" + usuario + "' and u.id_empresa_pk=e.id_empresa_pk and u.id_empleados_pk = e.id_empleados_pk;", con);
                OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;
            }
            catch
            {
                MessageBox.Show("No se pueden cargar los datos de colaborador");
                return null;
            }
        }



        public DataTable ObtenerModulos()
        {

            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                OdbcCommand cmd = new OdbcCommand("select * from modulo ", con);
                OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;
            }
            catch { return null; }
        }


        public DataTable ObtenerAplicacionesPorModulo(string id_modulo)
        {

            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                DataTable dt = new DataTable();
                OdbcCommand cmd = new OdbcCommand("select id_aplicacion, nombre_aplicacion from aplicacion where id_modulo = '"+id_modulo+"' ", con);
                OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;
            }
            catch { return null; }
        }
    }
}
