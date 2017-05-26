using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Net;
using System.Windows.Forms;

/*
 Autor: 
 Marvin Yoque
 Gabriela Zimery

     */

namespace seguridad
{
    public class bitacora
    {
        // --------------- Metodo para registrar en la bitacora lo que se esta insertando ----------------------- 

        public void Insertar(string accion, string tabla)
        {
            
            // describe la operacion a insertar en la base de datos
            string descrip = "Insertar";
            ClaseTomaIp ip = new ClaseTomaIp();
            string localIP = ip.direccion();
            // try - catch para manejo de errores
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string consulta = "select registraroperacion('" + Conexion.User + "', '" + accion + "', '" + descrip + "', '" + tabla + "','" + localIP + "') ";
                OdbcCommand comando = new OdbcCommand(consulta, con);
                object resultado = comando.ExecuteScalar();
                if (Convert.ToInt16(resultado) == 1) //esto nos indica que la validaciòn ha sido correcta por parte de la funciòn almacenada
                {
                    //MessageBox.Show("Registrado en bitacora con exito");

                }
                else
                {
                    MessageBox.Show("Error al registrar en bitacora"); //De lo contrario, si hay algun tipo de error al registrar

                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Problema con Bitacora");
            }
        }



        // --------------- Metodo para registrar en la bitacora lo que se esta Modificando ----------------------- 

        //void modificar
        public void Modificar(string accion, string tabla)
        {
            string descrip = "Modificar ";
            ClaseTomaIp ip = new ClaseTomaIp();
            string localIP = ip.direccion();
            // try - catch para manejo de errores
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string consulta = "select registraroperacion('" + Conexion.User + "', '" + accion + "', '" + descrip + "', '" + tabla + "','" + localIP + "') ";
                OdbcCommand comando = new OdbcCommand(consulta, con);
                object resultado = comando.ExecuteScalar();
                if (Convert.ToInt16(resultado) == 1) //esto nos indica que la validaciòn ha sido correcta por parte de la funciòn almacenada
                {
                    //MessageBox.Show("Registrado en bitacora con exito");

                }
                else
                {
                    MessageBox.Show("Error al registrar en bitacora"); //De lo contrario, si hay algun tipo de error al registrar

                }
                con.Close();
            }
            catch
            {

                MessageBox.Show("Problema con Bitacora");
            }

        }


        // --------------- Metodo para registrar en la bitacora lo que se esta Eliminando ----------------------- 
        public void ErrorOp(string accion, string tabla)
        {

            //en descripcion pondra modificar si se escoje este paso
            string descrip = "Intento Operacion";
            ClaseTomaIp ip = new ClaseTomaIp();
            string localIP = ip.direccion();
            // try - catch para manejo de errores


            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string consulta = "select registraroperacion('" + Conexion.User + "', '" + accion + "', '" + descrip + "', '" + tabla + "','" + localIP + "') ";
                OdbcCommand comando = new OdbcCommand(consulta, con);
                object resultado = comando.ExecuteScalar();
                if (Convert.ToInt16(resultado) == 1) //esto nos indica que la validaciòn ha sido correcta por parte de la funciòn almacenada
                {
                    //MessageBox.Show("Registrado en bitacora con exito");

                }
                else
                {
                    MessageBox.Show("Error al registrar en bitacora"); //De lo contrario, si la contraseña es incorrecta o el usuario, nos devuelve el fallo

                }
                con.Close();
            }
            catch
            {

                MessageBox.Show("Problema con Bitacora");
            }

        }
        public void Registro(string accion, string tabla)
        {

            //en descripcion pondra modificar si se escoje este paso
            string descrip = "Operacion exitosa";
            ClaseTomaIp ip = new ClaseTomaIp();
            string localIP = ip.direccion();
            // try - catch para manejo de errores
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string consulta = "select registraroperacion('" + Conexion.User + "', '" + accion + "', '" + descrip + "', '" + tabla + "','" + localIP + "') ";
                OdbcCommand comando = new OdbcCommand(consulta, con);
                object resultado = comando.ExecuteScalar();
                if (Convert.ToInt16(resultado) == 1) //esto nos indica que la validaciòn ha sido correcta por parte de la funciòn almacenada
                {
                    //MessageBox.Show("Registrado en bitacora con exito");

                }
                else
                {
                    MessageBox.Show("Error al registrar en bitacora"); //De lo contrario, si hay algun tipo de error al registrar

                }
                con.Close();
            }
            catch
            {

                MessageBox.Show("Problema con Bitacora");
            }
        }

        public void Eliminar(string accion, string tabla)
        {
            
            //define en descripcion la descripcion a ingresar en base de datos
            string descrip = "Eliminar ";
            ClaseTomaIp ip = new ClaseTomaIp();
            string localIP = ip.direccion();
            // try - catch para manejo de errores
            try
            {
                OdbcConnection con = Conexion.ObtenerConexionODBC();
                string consulta = "SELECT registraroperacion('"+Conexion.User+ "','"+accion+ "','"+descrip+ "','"+tabla+ "','"+localIP+"')";
                OdbcCommand comando = new OdbcCommand(consulta, con);
                object resultado = comando.ExecuteScalar();
                if (Convert.ToInt16(resultado) == 1)
                {
                    //MessageBox.Show("Registrado en bitacora con exito");

                }
                else
                {
                    MessageBox.Show("Error al registrar en bitacora"); //De lo contrario, si hay algun tipo de error al registrar

                }
                con.Close();
            }
            catch
            {
                
                MessageBox.Show("Problema con bitacora");
            }

        }
        public void Permisos(string accion, string tabla)
        {

            //en descripcion pondra modificar si se escoje este paso
            string descrip = "Asignacion/cambio permisos";
            ClaseTomaIp ip = new ClaseTomaIp();
            string localIP = ip.direccion();
            // try - catch para manejo de errores
            OdbcConnection con = Conexion.ObtenerConexionODBC();
            try
            {
                string consulta = "select registraroperacion('" + Conexion.User + "', '" + accion + "', '" + descrip + "', '" + tabla + "','" + localIP + "') ";
                OdbcCommand comando = new OdbcCommand(consulta, con);
                object resultado = comando.ExecuteScalar();
                if (Convert.ToInt16(resultado) == 1) //esto nos indica que la validaciòn ha sido correcta por parte de la funciòn almacenada
                {
                    //MessageBox.Show("Registrado en bitacora con exito");

                }
                else
                {
                    MessageBox.Show("Error al registrar en bitacora"); //De lo contrario, si hay algun tipo de error al registrar

                }
                con.Close();
            }
            catch
            {
                con.Close();
                MessageBox.Show("Problema con bitacora");
            }
        }
    }
}

