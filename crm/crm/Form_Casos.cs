using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FuncionesNavegador;

namespace crm
{
    public partial class Form_Casos : Form
    {
        public Form_Casos()
        {
            InitializeComponent();
        }
        CapaDatosPersonas peticionescapa = new CapaDatosPersonas();
        string id_form = "102";
        private void btn_nuevocaso_Click(object sender, EventArgs e)
        {
            frm_NuevoCaso f = new frm_NuevoCaso();
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void Form_Casos_Load(object sender, EventArgs e)
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

            //// carga de datos en formulario
            //// Cargar GridView de casos
            //DataTable dt_casos = new DataTable();
            //dt_casos = peticionescapa.cargar_casos();
            //dgv_casos.DataSource = dt_casos;
            //// columnas ocultas
            //gv_casos.Columns["id_empresa"].Visible = false;
            //gv_casos.Columns["id_empleado"].Visible = false;
            //gv_casos.Columns["id_cliente"].Visible = false;
            //gv_casos.Columns["id_cat_caso"].Visible = false;
            //gv_casos.Columns["id_caso"].Visible = false;

            //// headers de las columnas
            //gv_casos.Columns["nombre"].Caption = "Empresa";
            //gv_casos.Columns["nombres"].Caption = "Nombre del cliente";
            //gv_casos.Columns["apellidos"].Caption = "Apellido del cliente";
            //gv_casos.Columns["nombres1"].Caption = "Nombre del encargado";
            //gv_casos.Columns["apellidos1"].Caption = "Apellido del encargado";
            //gv_casos.Columns["fecha_asignacion"].Caption = "Asignacion";
            //gv_casos.Columns["fecha_limite"].Caption = "Fecha limite";
            //gv_casos.Columns["nombre_caso"].Caption = "Categoria";
            //gv_casos.Columns["estado_caso"].Caption = "Estado";

            dgv_casos.DataSource = OpBD.SeleccionarCasos();
            if (dgv_casos.DataSource != null)
            {
                gv_casos.Columns[0].Caption = "No.";
                gv_casos.Columns[1].Caption = "Titulo";
                gv_casos.Columns[2].Caption = "Persona";
                gv_casos.Columns[3].Caption = "Organización";
                gv_casos.Columns[4].Caption = "Fecha finalización";
                gv_casos.Columns[5].Caption = "Categoria";
                gv_casos.Columns[6].Visible = false;
                gv_casos.Columns[6].Caption = "Estado";

                gv_casos.Columns[0].Width = 28;
                gv_casos.RowClick += Gv_casos_RowClick;
            }
            gv_casos.OptionsBehavior.ReadOnly = true;

        }

        private void Gv_casos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //DataRow row = gv_casos.GetFocusedDataRow();
            //string id_caso = row[0].ToString();
            //string titulo = row[1].ToString();
            //string persona = row[2].ToString();
            //string organizacion = row[3].ToString();
            //string fecha_fin = row[4].ToString();
            //string categoria = row[5].ToString();

            //FormDetallesCaso f = new FormDetallesCaso();
            //f.id_caso = id_caso;
            //f.titulo = titulo;
            //f.persona = persona;
            //f.organizacion = organizacion;
            //f.fecha_fin = fecha_fin;
            //f.categoria = categoria;

            //f.MdiParent = this.MdiParent;
            //f.Show();

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            frm_NuevoCaso f = new frm_NuevoCaso();
            f.actualizar = false;
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            //DataTable dt_casos = new DataTable();
            //dt_casos = peticionescapa.cargar_casos();
            //dgv_casos.DataSource = dt_casos;
            //// columnas ocultas
            //gv_casos.Columns["id_empresa"].Visible = false;
            //gv_casos.Columns["id_empleado"].Visible = false;
            //gv_casos.Columns["id_cliente"].Visible = false;
            //gv_casos.Columns["id_cat_caso"].Visible = false;
            //gv_casos.Columns["id_caso"].Visible = false;

            //// headers de las columnas
            //gv_casos.Columns["nombre"].Caption = "Empresa";
            //gv_casos.Columns["nombres"].Caption = "Nombre del cliente";
            //gv_casos.Columns["apellidos"].Caption = "Apellido del cliente";
            //gv_casos.Columns["nombres1"].Caption = "Nombre del encargado";
            //gv_casos.Columns["apellidos1"].Caption = "Apellido del encargado";
            //gv_casos.Columns["fecha_asignacion"].Caption = "Asignacion";
            //gv_casos.Columns["fecha_limite"].Caption = "Fecha limite";
            //gv_casos.Columns["nombre_caso"].Caption = "Categoria";
            //gv_casos.Columns["estado_caso"].Caption = "Estado";

            dgv_casos.DataSource = OpBD.SeleccionarCasos();
            if (dgv_casos.DataSource != null)
            {
                gv_casos.Columns[0].Caption = "No.";
                gv_casos.Columns[1].Caption = "Titulo";
                gv_casos.Columns[2].Caption = "Persona";
                gv_casos.Columns[3].Caption = "Organización";
                gv_casos.Columns[4].Caption = "Fecha finalización";
                gv_casos.Columns[5].Caption = "Categoria";

            
            }
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegociod fn = new CapaNegociod();
            fn.Anterior(gv_casos);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegociod fn = new CapaNegociod();
            fn.Siguiente(gv_casos);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegociod fn = new CapaNegociod();
            fn.Primero(gv_casos);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegociod fn = new CapaNegociod();
            fn.Ultimo(gv_casos);
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DataRow row = gv_casos.GetFocusedDataRow();

            if (row != null)
            {

                if (MessageBox.Show("¿Esta seguro de que desea eliminar el caso?", "Eliminar caso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string id_caso = row[0].ToString();
                    string titulo = row[1].ToString();

                    OpBD o = new OpBD();
                    int res = o.EliminarCaso(id_caso, titulo);

                    if (res == 1)
                    {
                        MessageBox.Show("Caso eliminado con exito");

                        dgv_casos.DataSource = OpBD.SeleccionarCasos();
                        if (dgv_casos.DataSource != null)
                        {
                            gv_casos.Columns[0].Caption = "No.";
                            gv_casos.Columns[1].Caption = "Titulo";
                            gv_casos.Columns[2].Caption = "Persona";
                            gv_casos.Columns[3].Caption = "Organización";
                            gv_casos.Columns[4].Caption = "Fecha finalización";
                            gv_casos.Columns[5].Caption = "Categoria";

                            gv_casos.Columns[0].Width = 28;
                        }
                    }
                    else { MessageBox.Show("Eliminación no realizada"); }

                }

            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            DataRow row = gv_casos.GetFocusedDataRow();
            string id_caso = row[0].ToString();
            string titulo = row[1].ToString();
            string persona = row[2].ToString();
            string empresa = row[3].ToString();
            string fecha_fin = row[4].ToString();
            string categoria = row[5].ToString();
           
            frm_NuevoCaso f = new frm_NuevoCaso();
            f.id_caso_e = id_caso;
            f.titulo_e = titulo;
            f.persona_e = persona;
            f.empresa_e = empresa;
            f.fecha_fin_e = fecha_fin;
            f.categoria_e = categoria;
            f.actualizar = true;

            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void btn_cat_Click(object sender, EventArgs e)
        {
            gv_casos.Columns[2].GroupIndex = -1;
            gv_casos.Columns[3].GroupIndex = -1;
            gv_casos.Columns[6].GroupIndex = -1;

            gv_casos.Columns[5].GroupIndex = 1;
        }

        private void btn_clie_Click(object sender, EventArgs e)
        {
            gv_casos.Columns[5].GroupIndex = -1;
            gv_casos.Columns[3].GroupIndex = -1;
            gv_casos.Columns[6].GroupIndex = -1;

            gv_casos.Columns[2].GroupIndex = 1;
        }

        private void btn_empresa_Click(object sender, EventArgs e)
        {
            gv_casos.Columns[2].GroupIndex = -1;
            gv_casos.Columns[5].GroupIndex = -1;
            gv_casos.Columns[6].GroupIndex = -1;

            gv_casos.Columns[3].GroupIndex = 1;
        }

        private void btn_normal_Click(object sender, EventArgs e)
        {
            gv_casos.Columns[2].GroupIndex = -1;
            gv_casos.Columns[5].GroupIndex = -1;
            gv_casos.Columns[3].GroupIndex = -1;
            gv_casos.Columns[6].GroupIndex = -1;
        }

        private void dgv_casos_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gv_casos.GetFocusedDataRow();
            string id_caso = row[0].ToString();
            string titulo = row[1].ToString();
            string persona = row[2].ToString();
            string organizacion = row[3].ToString();
            string fecha_fin = row[4].ToString();
            string categoria = row[5].ToString();

            FormDetallesCaso f = new FormDetallesCaso();
            f.id_caso = id_caso;
            f.titulo = titulo;
            f.persona = persona;
            f.organizacion = organizacion;
            f.fecha_fin = fecha_fin;
            f.categoria = categoria;

            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void btn_abiertos_cerrados_Click(object sender, EventArgs e)
        {
            gv_casos.Columns[2].GroupIndex = -1;
            gv_casos.Columns[5].GroupIndex = -1;
            gv_casos.Columns[3].GroupIndex = -1;

            gv_casos.Columns[6].GroupIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Reporte_caso f = new Form_Reporte_caso();
            f.dataGridView1.DataSource = OpBD.SeleccionarCasos();
            f.Show();
        }
    }
}
