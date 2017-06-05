using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using FuncionesNavegador;


namespace crm
{
    public partial class FormContactos : Form
    {
        public FormContactos()
        {
            InitializeComponent();
        }
        string id_form = "103";
        string pagina;
        private void FormContactos_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //btn_opciones.Enabled = false;
            try
            {
                CapaNegocio fn = new CapaNegocio();
            DataTable seg = seguridad.ObtenerPermisos.Permisos(seguridad.Conexion.User, id_form);
            if (seg.Rows.Count > 0)
            {
                fn.desactivarPermiso(seg, btn_guardar, btn_eliminar, btn_editar, btn_nuevo, btn_cancelar, btn_actualizar, btn_buscar, btn_anterior, btn_siguiente, btn_primero, btn_ultimo);
            }
            else
            {
                btn_guardar.Enabled = false; btn_eliminar.Enabled = false; btn_editar.Enabled = false; btn_nuevo.Enabled = false; btn_actualizar.Enabled = false; btn_cancelar.Enabled = false; btn_buscar.Enabled = false;
            }



                pagina = tabPane1.SelectedPage.Caption;


                DataTable dt_org = OpBD.SeleccionarEmpresas();
                if(dt_org != null)
                {
                    gc_organizaciones.DataSource = dt_org;
                    //DataRow row = dt_org.Rows[0]
                    gv_organizaciones.Columns[0].Visible = false;
                    gv_organizaciones.Columns[1].Caption = "Empresas:";
                }


                DataTable dt_clie = OpBD.SeleccionarClientes();
                if (dt_clie != null)
                {
                    gc_personas.DataSource = dt_clie;
                    //DataRow row = dt_org.Rows[0]
                    gv_personas.Columns[0].Visible = false;
                    gv_personas.Columns[1].Caption = "Personas:";
                }

                lbl_direccion.Text = "";
                lbl_correo.Text = "";
                lbl_telefono1.Text = "";
                lbl_telefono2.Text = "";
                lbl_pais.Text = "";
                lbl_na.Text = "";
                lbl_nc.Text = "";
                lbl_ca.Text = "";
                lbl_cc.Text = "";

                lbl_p_ca.Text = "";
                lbl_p_cc.Text = "";
                lbl_p_correo.Text = "";
                lbl_p_empresa.Text = "";
                lbl_p_estado.Text = "";
                lbl_p_movil.Text = "";
                lbl_p_na.Text = "";
                lbl_p_nc.Text = "";
                lbl_p_puesto.Text = "";
                lbl_p_tel.Text = "";
                lbl_p_tipo.Text = "";
                

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



        }

        private void tabPane1_Click(object sender, EventArgs e)
        {

        }

        private void tabPane1_TabIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void tabPane1_DockChanged(object sender, EventArgs e)
        {
         
        }

        private void tabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            //dskfjalsdjask
            pagina = tabPane1.SelectedPage.Caption;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if( pagina == "Personas")
            {
                frm_cliente fc = new frm_cliente();
                fc.actualizar = false;
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }else if (pagina == "Organizaciones")
            {
                frm_empresa fe = new frm_empresa();
                fe.actualizar = false;
                fe.MdiParent = this.MdiParent;
                fe.Show();
            }
        }

        private void btn_empresa_Click(object sender, EventArgs e)
        {
            frm_empresa fe = new frm_empresa();
            fe.MdiParent = this.MdiParent;
            fe.Show();
        }

        private void btn_personas_Click(object sender, EventArgs e)
        {
            frm_cliente fc = new frm_cliente();
            fc.MdiParent = this.MdiParent;
            fc.Show();
        }

        private void gv_personas_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow row = gv_personas.GetFocusedDataRow();
            string id_persona = row[0].ToString();
            DataTable dt_per = OpBD.SeleccionarDatosRestantesPersona(id_persona);
            string puesto = "";
            string empresa = "";
            string telefono = "";
            string movil = "";
            string tipo = "";
            string estado = "";
            string correo = "";

            if (dt_per != null)
            {
                DataRow row_per = dt_per.Rows[0];
                puesto = row_per[0].ToString();
                empresa = row_per[1].ToString();
                telefono = row_per[2].ToString();
                movil = row_per[3].ToString();
                tipo = row_per[4].ToString();
                estado = row_per[5].ToString();
                correo = row_per[6].ToString();

            }

            
            lbl_p_correo.Text = correo;
            lbl_p_empresa.Text = empresa;
            lbl_p_estado.Text = estado;
            lbl_p_movil.Text = movil;
            lbl_p_puesto.Text = puesto;
            lbl_p_tel.Text = telefono;
            lbl_p_tipo.Text = tipo;

            DataTable dt1 = OpBD.CNA_persona(id_persona);
            lbl_p_na.Text = dt1.Rows[0][0].ToString();
            DataTable dt2 = OpBD.CNC_persona(id_persona);
            lbl_p_nc.Text = dt2.Rows[0][0].ToString();
            DataTable dt3 = OpBD.CCA_persona(id_persona);
            lbl_p_ca.Text = dt3.Rows[0][0].ToString();
            DataTable dt4 = OpBD.CCC_persona(id_persona);
            lbl_p_cc.Text = dt4.Rows[0][0].ToString();
        }

        private void gv_organizaciones_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow row = gv_organizaciones.GetFocusedDataRow();
            string id_empresa = row[0].ToString();
            DataTable dt_emp = OpBD.SeleccionarDatosRestantesEmpresa(id_empresa);
            string direccion ="";
            string correo="";
            string telefono1="";
            string telefono2="";
            string pais="";
            if (dt_emp != null)
            {
                DataRow row_emp = dt_emp.Rows[0];
                direccion = row_emp[0].ToString();
                correo = row_emp[1].ToString();
                telefono1 = row_emp[2].ToString();
                telefono2 = row_emp[3].ToString();
                pais = row_emp[4].ToString();

            }

            lbl_direccion.Text = direccion;
            lbl_correo.Text = correo;
            lbl_telefono1.Text = telefono1;
            lbl_telefono2.Text =telefono2;
            lbl_pais.Text = pais;

            DataTable dt1 = OpBD.CNA_empresa(id_empresa);
            lbl_na.Text = dt1.Rows[0][0].ToString();
            DataTable dt2 = OpBD.CNC_empresa(id_empresa);
            lbl_nc.Text = dt2.Rows[0][0].ToString();
            DataTable dt3 = OpBD.CCA_empresa(id_empresa);
            lbl_ca.Text = dt3.Rows[0][0].ToString();
            DataTable dt4 = OpBD.CCC_empresa(id_empresa);
            lbl_cc.Text = dt4.Rows[0][0].ToString();

        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            if (pagina == "Personas")
            {
                CapaNegociod fn = new CapaNegociod();
                fn.Anterior(gv_personas);
            }
            else if (pagina == "Organizaciones")
            {
                CapaNegociod fn = new CapaNegociod();
                fn.Anterior(gv_organizaciones);
            }
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            if (pagina == "Personas")
            {
                CapaNegociod fn = new CapaNegociod();
                fn.Siguiente(gv_personas);
            }
            else if (pagina == "Organizaciones")
            {
                CapaNegociod fn = new CapaNegociod();
                fn.Siguiente(gv_organizaciones);
            }
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            if (pagina == "Personas")
            {
                CapaNegociod fn = new CapaNegociod();
                fn.Primero(gv_personas);
            }
            else if (pagina == "Organizaciones")
            {
                CapaNegociod fn = new CapaNegociod();
                fn.Primero(gv_organizaciones);
            }
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            if (pagina == "Personas")
            {
                CapaNegociod fn = new CapaNegociod();
                fn.Ultimo(gv_personas);
            }
            else if (pagina == "Organizaciones")
            {
                CapaNegociod fn = new CapaNegociod();
                fn.Ultimo(gv_organizaciones);
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (pagina == "Personas")
            {
                DataTable dt_clie = OpBD.SeleccionarClientes();
                if (dt_clie != null)
                {
                    gc_personas.DataSource = dt_clie;
                    //DataRow row = dt_org.Rows[0]
                    gv_personas.Columns[0].Visible = false;
                    gv_personas.Columns[1].Caption = "Personas:";
                }
            }
            else if (pagina == "Organizaciones")
            {
                DataTable dt_org = OpBD.SeleccionarEmpresas();
                if (dt_org != null)
                {
                    gc_organizaciones.DataSource = dt_org;
                    //DataRow row = dt_org.Rows[0]
                    gv_organizaciones.Columns[0].Visible = false;
                    gv_organizaciones.Columns[1].Caption = "Empresas:";
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (pagina == "Personas")
            {
                DataRow row = gv_personas.GetFocusedDataRow();
                string id_persona = row[0].ToString();
                string persona = row[1].ToString();
                if (MessageBox.Show("¿Esta seguro de que desea eliminar la persona?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    OpBD o = new OpBD();
                    int res = o.EliminarPersona(id_persona, persona);
                    if (res == 1)
                    {
                        MessageBox.Show("Persona eliminada con exito");
                    }
                    else { MessageBox.Show("Persona no eliminada "); }

                }
            }
            else if (pagina == "Organizaciones")
            {
                DataRow row = gv_organizaciones.GetFocusedDataRow();
                string id_empresa = row[0].ToString();
                string empresa = row[1].ToString();
                if (MessageBox.Show("¿Esta seguro de que desea eliminar la organización?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    OpBD o = new OpBD();
                    int res = o.EliminarEmpresa(id_empresa,empresa);
                    if(res == 1)
                        {
                        MessageBox.Show("Empresa eliminada con exito");
                        }
                    else { MessageBox.Show("Empresa no eliminada "); }

                }

           }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (pagina == "Personas")
            {
                DataRow row = gv_personas.GetFocusedDataRow();
                string id_persona = row[0].ToString();

                frm_cliente f = new frm_cliente();
                f.id_cliente = id_persona; ;

                f.actualizar = true;
                f.MdiParent = this.MdiParent;
                f.Show();
            }
            else if (pagina == "Organizaciones")
            {
                DataRow row = gv_organizaciones.GetFocusedDataRow();
                string id_emp = row[0].ToString();
                string nom = row[1].ToString();

                frm_empresa f = new frm_empresa();
                f.id_empresa = id_emp; ;
                f.nombre_empresa = nom;
                f.actualizar = true;
                f.MdiParent = this.MdiParent;
                f.Show();
            }
        }


    }
}
