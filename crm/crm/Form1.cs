using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using seguridad;

namespace crm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


       

        string tipo;
        DataTable dt_permisos = new DataTable();
        

        FormActividadesCalendario cal = new FormActividadesCalendario();
        FormContactos con = new FormContactos();
        FormNegociaciones neg = new FormNegociaciones();
        frm_estadistica_empresa em = new frm_estadistica_empresa();
        frm_estadistica_personal per = new frm_estadistica_personal();
        frm_pronostico pro = new frm_pronostico();
        frm_cliente cliente_form = new frm_cliente();
        frm_empresa emp = new frm_empresa();
        Form_inicio ini = new Form_inicio();
        frm_NuevoEmpleado empleado_form = new frm_NuevoEmpleado();
        Form_Casos caso = new Form_Casos();
        Historial bitacora = new Historial();
        agregarapp ap = new agregarapp();
        Modificar_aplicacion modap = new Modificar_aplicacion();
        FormAsignarPermisosUsuario crearu = new FormAsignarPermisosUsuario();
        Form_EditarPrivilegios edi = new Form_EditarPrivilegios();
        FormDeshabilitarUsuario desh = new FormDeshabilitarUsuario();
        FormAsignacionPerfil asper = new FormAsignacionPerfil();
        Form_EditarPerfil edper = new Form_EditarPerfil();
        FormEliminarPerfil elper = new FormEliminarPerfil();
        frm_pronostico_ventas_secundario secundarios = new frm_pronostico_ventas_secundario();
        inventario inven = new inventario();
        CambioPass camb = new CambioPass();
        inventario_bodega inv_bod = new inventario_bodega();
        frmListadoPrecio precios = new frmListadoPrecio();
        frm_abonos abono = new frm_abonos();
        BALANCE balance = new BALANCE();
        frm_existencia exis = new frm_existencia();

        private void LimpiarMDI()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void ClearAllMDIs()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
               // f.Dispose();
            }
        }

        private void otroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void caToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // conexion odbc
            //try
            //{
            //    seguridad.Conexion.DSN = "crm";
            //    seguridad.Conexion.PassWord = "1234";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}


            BloquearMDI();
            Bloqueo.DesbloquearMDI(menuStrip1);

         

            //------------------------
            tipo = OpBD.VerificarTipoUsuario();
            if(tipo == "administrador")
            {
                //estadisticasToolStripMenuItem.Enabled = false;
                seguridadToolStripMenuItem.Enabled = true;
                foreach (ToolStripMenuItem item_seg in seguridadToolStripMenuItem.DropDownItems)
                {
                    item_seg.Enabled = true;
                }

            }


            cal = null;
            con = null;
            neg = null;
            em = null;
            per = null;
            pro = null;
            cliente_form = null;
            emp = null;
            ini = null;
            empleado_form = null;
            caso = null;
            bitacora = null;
            ap = null;
            modap = null;
            crearu = null;
            edi = null;
            desh = null;
            asper = null;
            edper = null;
            elper = null;
            camb = null;
            secundarios = null;
            inven = null;
            inv_bod = null;
            precios = null;
            abono = null;
            balance = null;
            exis = null;

            if (ini == null)
            {
                ini = new Form_inicio();
                ini.MdiParent = this;

                ini.FormClosed += new FormClosedEventHandler(frm_inicio_FormClosed);
                ini.Show();
            }
        }


        private void BloquearMDI()
        {
            foreach (ToolStripMenuItem menu_principal in menuStrip1.Items)
            {
                foreach (ToolStripMenuItem sub_menu in menu_principal.DropDownItems)
                {
                    sub_menu.Enabled = false;
                }
                 menu_principal.Enabled = false;
            }


            toolStripMenuItem1.Enabled = true;
            foreach(ToolStripMenuItem item_inicio in toolStripMenuItem1.DropDownItems)
            {
                item_inicio.Enabled = true;
            }

            ayudaToolStripMenuItem.Enabled = true;
        }





        private void actividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "104");
            //if (dt.Rows.Count > 0)
            //{
                // ClearAllMDIs();
                LimpiarMDI();
                if (cal == null)
                {
                    cal = new FormActividadesCalendario();
                    cal.MdiParent = this;

                    cal.FormClosed += new FormClosedEventHandler(FormActividadesCalendario_FormClosed);
                    cal.Show();
                }
            //}
            //else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

      

        private void FormActividadesCalendario_FormClosed(object sender, FormClosedEventArgs e)
        {
            cal = null;
        }

        private void contactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "103");
            //if (dt.Rows.Count > 0)
            //{
                // ClearAllMDIs();
                LimpiarMDI();
                if (con == null)
                {
                    con = new FormContactos();
                    con.MdiParent = this;

                    con.FormClosed += new FormClosedEventHandler(FormCotactos_FormClosed);
                    con.Show();
                }
            //}
            //else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void FormCotactos_FormClosed(object sender, FormClosedEventArgs e)
        {
            con = null;
        }


        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ClearAllMDIs();

           //DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User,"104");
           // if (dt.Rows.Count > 0)
           // {
                LimpiarMDI();
                if (neg == null)
                {
                    neg = new FormNegociaciones();
                    neg.MdiParent = this;

                    neg.FormClosed += new FormClosedEventHandler(FormNegociaciones_FormClosed);
                    neg.Show();
                }
            //}
            //else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void FormNegociaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            neg = null;
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "112");
            //if (dt.Rows.Count > 0)
            //{
                //ClearAllMDIs();
                LimpiarMDI();
                if (em == null)
                {
                    em = new frm_estadistica_empresa();
                    em.MdiParent = this;

                    em.FormClosed += new FormClosedEventHandler(frm_estadistica_empresa_FormClosed);
                    em.Show();
                }
            //}
            //else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void frm_estadistica_empresa_FormClosed(object sender, FormClosedEventArgs e)
        {
            em = null;
        }

        private void personalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "113");
            //if (dt.Rows.Count > 0)
            //{
                //ClearAllMDIs();
                LimpiarMDI();
                if (per == null)
                {
                    per = new frm_estadistica_personal();
                    per.MdiParent = this;

                    per.FormClosed += new FormClosedEventHandler(frm_estadistica_personal_FormClosed);
                    per.Show();
                }
            //}
            //else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void frm_estadistica_personal_FormClosed(object sender, FormClosedEventArgs e)
        {
            per = null;
        }

        private void proyeccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "114");
            //if (dt.Rows.Count > 0)
            //{
                //ClearAllMDIs();
                LimpiarMDI();
                if (pro == null)
                {
                    pro = new frm_pronostico();
                    pro.MdiParent = this;

                    pro.FormClosed += new FormClosedEventHandler(frm_pronostico_FormClosed);
                    pro.Show();
                }
            //}
            //else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void frm_pronostico_FormClosed(object sender, FormClosedEventArgs e)
        {
            pro = null;
        }


       


        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarMDI();
            if (cliente_form == null)
            {
                cliente_form = new frm_cliente();
                cliente_form.MdiParent = this;

                cliente_form.FormClosed += new FormClosedEventHandler(frm_cliente_FormClosed);
                cliente_form.Show();
            }

        }
        private void frm_cliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            cliente_form = null;
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // LimpiarMDI();
            if (emp == null)
            {
                emp = new frm_empresa();
                emp.MdiParent = this;

                emp.FormClosed += new FormClosedEventHandler(frm_empresa_FormClosed);
                emp.Show();
            }
        }

        private void frm_empresa_FormClosed(object sender, FormClosedEventArgs e)
        {
            emp = null;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //// LimpiarMDI();
            //if (ini == null)
            //{
            //    ini = new Form_inicio();
            //    ini.MdiParent = this;

            //    ini.FormClosed += new FormClosedEventHandler(frm_inicio_FormClosed);
            //    ini.Show();
            //}
        }

        private void frm_inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            ini = null;
        }


        // Pestaña de Empleados
        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (empleado_form == null)
            {
                empleado_form = new frm_NuevoEmpleado();
                empleado_form.MdiParent = this;

                empleado_form.FormClosed += new FormClosedEventHandler(frm_NuevoEmpleado_FormClosed);
                empleado_form.Show();
            }
        }
        private void frm_NuevoEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            empleado_form = null;
        }

        private void casosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "102");
            //if (dt.Rows.Count > 0)
            //{
                //LimpiarMDI();
                if (caso == null)
                {
                    caso = new Form_Casos();
                    caso.MdiParent = this;

                    caso.FormClosed += new FormClosedEventHandler(Form_Casos_FormClosed);
                    caso.Show();
                }

            //}else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void Form_Casos_FormClosed(object sender, FormClosedEventArgs e)
        {
            caso = null;
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LimpiarMDI();
            if (bitacora == null)
            {
                bitacora = new Historial();
                bitacora.MdiParent = this;

                bitacora.FormClosed += new FormClosedEventHandler(Historial_FormClosed);
                bitacora.Show();
            }
        }

        private void Historial_FormClosed(object sender, FormClosedEventArgs e)
        {
            bitacora = null;
        }

        private void agregarAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AGREGAR APLICACION
        //    if (ap == null)
        //    {
        //        ap = new agregarapp();
        //        ap.MdiParent = this;

        //        ap.FormClosed += new FormClosedEventHandler(agregarap_FormClosed);
        //        ap.Show();
        //    }
        }

        private void agregarap_FormClosed(object sender, FormClosedEventArgs e)
        {
            ap = null;
        }

        private void modificarAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MODIFICAR APLICACION 
            //if (modap == null)
            //{
            //    modap = new Modificar_aplicacion();
            //    modap.MdiParent = this;
            //    modap.FormClosed += new FormClosedEventHandler(ModificarAplicacion_FormClosed);
            //    modap.Show();
            //}
        }

        private void ModificarAplicacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            modap = null;
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (crearu == null)
            {
                crearu = new FormAsignarPermisosUsuario();
                crearu.MdiParent = this;

                crearu.FormClosed += new FormClosedEventHandler(FormAsignarPermisosUsuario_FormClosed);
                crearu.Show();
            }
        }

        private void FormAsignarPermisosUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            crearu = null;
        }

        private void editarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edi == null)
            {
                edi = new Form_EditarPrivilegios();
                edi.MdiParent = this;

                edi.FormClosed += new FormClosedEventHandler(FormEditarPrivilegios_FormClosed);
                edi.Show();
            }
        }

        private void FormEditarPrivilegios_FormClosed(object sender, FormClosedEventArgs e)
        {
            edi = null;
        }

        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (desh == null)
            {
                desh = new FormDeshabilitarUsuario();
                desh.MdiParent = this;
                desh.FormClosed += new FormClosedEventHandler(FormDeshabilitarUsuario_FormClosed);
                desh.Show();
            }
        }

        private void FormDeshabilitarUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            desh = null;
        }

        private void crearPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (asper == null)
            {
                asper = new FormAsignacionPerfil();
                asper.MdiParent = this;
                asper.FormClosed += new FormClosedEventHandler(FormAsignacionPerfil_FormClosed);
                asper.Show();
            }
        }

        private void FormAsignacionPerfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            asper = null;
        }

        private void editarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edper == null)
            {
                edper = new Form_EditarPerfil();
                edper.MdiParent = this;
                edper.FormClosed += new FormClosedEventHandler(Form_EditarPerfil_FormClosed);
                edper.Show();
            }
        }

        private void Form_EditarPerfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            edper = null;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (elper == null)
            {
                elper = new FormEliminarPerfil();
                elper.MdiParent = this;
                elper.FormClosed += new FormClosedEventHandler(FormEliminarPerfil_FormClosed);
                elper.Show();
            }
        }

        private void FormEliminarPerfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            elper = null;
        }

        private void gToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (camb == null)
            {
                camb = new CambioPass();
                camb.MdiParent = this;
                camb.FormClosed += new FormClosedEventHandler(CambioPass_FormClosed);
                camb.Show();
            }
        }

        private void CambioPass_FormClosed(object sender, FormClosedEventArgs e)
        {
            camb = null;
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Close();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // LimpiarMDI();
            if (ini == null)
            {
                ini = new Form_inicio();
                ini.MdiParent = this;

                ini.FormClosed += new FormClosedEventHandler(frm_inicio_FormClosed);
                ini.Show();
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Close();
        }

        private void metasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "115");
            if (dt.Rows.Count > 0)
            {
                //ClearAllMDIs();
                LimpiarMDI();
                if (secundarios == null)
                {
                    secundarios = new frm_pronostico_ventas_secundario();
                    secundarios.MdiParent = this;

                    secundarios.FormClosed += new FormClosedEventHandler(frm_pronostico_ventas_Secundario_form_closed);
                    secundarios.Show();
                }
            }
            else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void frm_pronostico_ventas_Secundario_form_closed(object sender, FormClosedEventArgs e)
        {
            secundarios = null;
        }

        private void ingresoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "116");
            if (dt.Rows.Count > 0)
            {
                //ClearAllMDIs();
                LimpiarMDI();
                if (inven == null)
                {
                    inven = new inventario();
                    inven.MdiParent = this;

                    inven.FormClosed += new FormClosedEventHandler(inventario_form_closed);
                    inven.Show();
                }
            }
            else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void inventario_form_closed(object sender, FormClosedEventArgs e)
        {
            inven = null;
        }

        private void bodegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "117");
            if (dt.Rows.Count > 0)
            {
                //ClearAllMDIs();
                LimpiarMDI();
                if (inv_bod == null)
                {
                    inv_bod = new inventario_bodega();
                    inv_bod.MdiParent = this;

                    inv_bod.FormClosed += new FormClosedEventHandler(inventario_bodega_form_closed);
                    inv_bod.Show();
                }
            }
            else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void inventario_bodega_form_closed(object sender, FormClosedEventArgs e)
        {
            inv_bod = null;
        }

        private void listaDePrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "117");
           // if (dt.Rows.Count > 0)
            //{
                //ClearAllMDIs();
                //LimpiarMDI();
                if (precios == null)
                {
                    precios = new frmListadoPrecio();
                    precios.MdiParent = this;

                    precios.FormClosed += new FormClosedEventHandler(lista_de_precios_form_closed);
                    precios.Show();
                }
            //}
            //else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void lista_de_precios_form_closed(object sender, FormClosedEventArgs e)
        {
            precios = null;
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarMDI();
               proyectoUOne. FacturaVista abrir = new proyectoUOne.FacturaVista();
                abrir.MdiParent = this;
                abrir.AutoSize = true;
                abrir.Show();
            }
            catch
            {
                MessageBox.Show("Error de llamada");
            }
        }

        private void cotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarMDI();
                proyectoUOne.CotizacionVista abrir = new proyectoUOne.CotizacionVista();
                abrir.MdiParent = this;
                abrir.AutoSize = true;
                abrir.Show();
            }
            catch
            {
                MessageBox.Show("Para facturar necesita seleccionar un cliente");
            }
        }

        private void aBONOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abono == null)
            {
                abono = new frm_abonos();
                abono.MdiParent = this;

                abono.FormClosed += new FormClosedEventHandler(frm_abonos_form_closed);
                abono.Show();
            }
        }

        private void frm_abonos_form_closed(object sender, FormClosedEventArgs e)
        {
            abono = null;
        }

        private void bALANCEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (balance == null)
            {
                balance = new BALANCE();
                balance.MdiParent = this;

                balance.FormClosed += new FormClosedEventHandler(frm_balance_form_closed);
                balance.Show();
            }
        }

        private void frm_balance_form_closed(object sender, FormClosedEventArgs e)
        {
            balance = null;
        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_configurar_idioma f = new frm_configurar_idioma();
            f.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

            if (OpBD.CambioIdioma == true)
            {
                this.Controls.Clear();
                InitializeComponent();
                OpBD.CambioIdioma = false;

                ini = null;
                if (ini == null)
                {
                    ini = new Form_inicio();
                    ini.MdiParent = this;

                    ini.FormClosed += new FormClosedEventHandler(frm_inicio_FormClosed);
                    ini.Show();
                }

               
                  
            }
        }

        private void morososToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cobros.frm_morosos moro = new Cobros.frm_morosos();
            moro.Show();
        }

        private void cuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cobros.Cuenta ct = new Cobros.Cuenta();
            ct.Show();
        }

        private void frm_existencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            exis = null;
        }

        private void ordenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = ObtenerPermisos.Permisos(seguridad.Conexion.User, "119");
            if (dt.Rows.Count > 0)
            {
                //ClearAllMDIs();
                LimpiarMDI();
                if (exis == null)
                {
                    exis = new frm_existencia();
                    exis.MdiParent = this;

                    exis.FormClosed += new FormClosedEventHandler(frm_existencia_FormClosed);
                    exis.Show();
                }
            }
            else { MessageBox.Show("No posee los permisos necesarios para acceder al modulo"); }
        }

        private void ingresoCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_categoria cat = new frm_categoria();
            cat.Show();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_marca m = new frm_marca();
            m.Show();
        }
    }
}
