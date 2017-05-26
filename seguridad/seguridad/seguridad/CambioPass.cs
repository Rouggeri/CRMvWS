using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace seguridad
{
    public partial class CambioPass : Form
    {
        public CambioPass()
        {
            InitializeComponent();
        }
        bitacora bitacora = new bitacora();
        SistemaUsuarioDatos suser = new SistemaUsuarioDatos();
        private void btn_aceptar_Click(object sender, EventArgs e)
        {

            if (txt_nombre_usuario.Text.Trim() == "" || txt_contra_actual.Text.Trim() == "" || txt_contra_nueva.Text.Trim() == "" || txt_contra_nueva_repetir.Text.Trim() == "")
            {
                // de lo cntrario mostrar error en campos, decir que estan vacios
                MessageBox.Show("campos vacios");
            }
            else {
                string usuario = Conexion.User;
                //llamando a capa de datos
                CapaDatos cd = new CapaDatos();
                string contra_actual = txt_contra_actual.Text.Trim();
                string contra_actual_enc = suser.Encriptar(contra_actual);
                string retorno_contraseña = cd.RevisarContraseña(usuario);
                // si la contraseña que la funcion nos retorno es igual a la contraseña que el usuario ingreso en la segunda linea entonces
                if (retorno_contraseña == "error")
                {
                    MessageBox.Show(" Error de conexion!");

                }
                else if (retorno_contraseña != contra_actual_enc)
                {
                    MessageBox.Show(" Contraseña Actual Erronea");

                }
                else {
                         if (txt_contra_nueva.Text.Trim() != txt_contra_nueva_repetir.Text.Trim())
                          {
                           // mensaje de errore en caso que las contraseñas no coincidan
                           MessageBox.Show("Las contraseñas no coinciden");
                           bitacora.ErrorOp("Cambio contraseña del usuario: '"+txt_nombre_usuario.Text+"'", "usuario");
                           }else
                              {
                        string contra_nueva = txt_contra_nueva.Text.Trim();
                        contra_nueva = suser.Encriptar(contra_nueva);
                        CapaDatos ss = new CapaDatos();
                        Objetos.cuentas cuentaModificar = new Objetos.cuentas();
                        CapaNegocio modifico = new CapaNegocio();
                        // mandarle parametros
                        cuentaModificar.usuario = txt_nombre_usuario.Text.Trim();
                        cuentaModificar.Acontrasenia = contra_actual.Trim();
                        cuentaModificar.Ncontrasenia = contra_nueva.Trim();
                        cuentaModificar.RNcontrasenia = suser.Encriptar(txt_contra_nueva_repetir.Text.Trim());
                        modifico.Modificar(cuentaModificar);

                       int x = ss.ActualizarContraseñaBD(contra_nueva);
                        if (x == 0)
                        {
                            bitacora.ErrorOp("Error de contraseña a nivel DBS usuario: '" + txt_nombre_usuario.Text + "'", "usuario");
                            MessageBox.Show("error al actualizar");
                        }
                        else
                        {
                            
                            
                            Conexion.PassWord = contra_nueva;
                            bitacora.Modificar("Actualizacion de contraseña de usuario: "+usuario, "usuario");
                            txt_contra_actual.Clear();
                            txt_contra_nueva.Clear();
                            txt_contra_nueva_repetir.Clear();
                            MessageBox.Show("Actualizada con exito");
                           

                        }

                        /*
                         * cambiar contraseña a nivel de base de datos
                         * mandar nueva contraseña a la clase conexion
                         */
                        //string v = "a";
                        // aparecera el texto de cambio de contraseña

                    }

                   }
            
              }
        }


       
        private void CambioPass_Load(object sender, EventArgs e)
        {
            txt_nombre_usuario.Enabled = false;
            txt_nombre_usuario.Text = Conexion.User;
            // para que los campos en los textbox no se vea
            txt_contra_actual.PasswordChar = '*';
            txt_contra_nueva.PasswordChar = '*';
            txt_contra_nueva_repetir.PasswordChar = '*';

            //mandando parametros a la dll de conexion
         
        }

        //private void llbl_bitacora_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    // llammando a bitacora para que al dar click mande al formulario de bitacora
        //    frmBitacora formula = new frmBitacora();
        //    formula.Show();
            
        //}
    }
}
