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
    public partial class FormNegociaciones : Form
    {
        public FormNegociaciones()
        {
            InitializeComponent();
        }
        string id_form = "104";
        private void FormNegociaciones_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;


                //------------------------------
                if(OpBD.Idioma == "ingles")
                {
                    pag_estado.Caption = "Phases";
                    pag_lista.Caption = "List";
                }else
                   {
                    pag_estado.Caption = "Etapa";
                    pag_lista.Caption = "Lista";
                   }


                //------------------------------

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




                dgv_negocios.DataSource = OpBD.SeleccionarNegocios();
                if (dgv_negocios.DataSource != null)
                {
                    if (OpBD.Idioma == "ingles")
                    {
                        dgv_neg.Columns[0].Caption = "No.";
                        dgv_neg.Columns[1].Caption = "Title";
                        dgv_neg.Columns[2].Caption = "Person";
                        dgv_neg.Columns[3].Caption = "Company";
                        dgv_neg.Columns[4].Caption = "Currency";
                        dgv_neg.Columns[5].Caption = "Amount";
                        dgv_neg.Columns[6].Caption = "Deadline";
                        dgv_neg.Columns[7].Caption = "Category";
                    } else
                       {
                        dgv_neg.Columns[0].Caption = "No.";
                        dgv_neg.Columns[1].Caption = "Titulo";
                        dgv_neg.Columns[2].Caption = "Persona";
                        dgv_neg.Columns[3].Caption = "Organización";
                        dgv_neg.Columns[4].Caption = "Moneda";
                        dgv_neg.Columns[5].Caption = "Valor";
                        dgv_neg.Columns[6].Caption = "Fecha de cierre estimada";
                        dgv_neg.Columns[7].Caption = "Categoría";
                      }

                    dgv_neg.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    dgv_neg.Columns[5].DisplayFormat.FormatString = "n2";
                    dgv_neg.Columns[0].Width = 28;
                    dgv_neg.RowClick += Dgv_neg_RowClick;
                    
                }
                dgv_neg.OptionsBehavior.ReadOnly = true;
               
               
                //************************ESTADOS********************
                DataTable dt_etapa0 = OpBD.SeleccionarNegociosEtapa0();
                ObtenerNegociosPorEtapa(dt_etapa0, tileBar0);


                DataTable dt_etapa1 = OpBD.SeleccionarNegociosEtapa1();
                ObtenerNegociosPorEtapa(dt_etapa1, tileBar1);
                DataTable dt_etapa2 = OpBD.SeleccionarNegociosEtapa2();
                ObtenerNegociosPorEtapa(dt_etapa2, tileBar2);
                DataTable dt_etapa3 = OpBD.SeleccionarNegociosEtapa3();
                ObtenerNegociosPorEtapa(dt_etapa3, tileBar3);

            }
            catch { MessageBox.Show("Imposible cargar datos"); }

        }

        private void ObtenerNegociosPorEtapa(DataTable dt_etapa, DevExpress.XtraBars.Navigation.TileBar tilebar)
        {
            if (dt_etapa != null && dt_etapa.Rows.Count > 0)
            {
                tilebar.Groups.Add(new DevExpress.XtraEditors.TileGroup());

                foreach (DataRow row_n in dt_etapa.Rows)
                {
                    string id_neg = row_n[0].ToString();
                    string titulo_neg = row_n[1].ToString();
                    string cliente;
                      if(String.IsNullOrEmpty(row_n[2].ToString()))
                        {
                        cliente = row_n[3].ToString();
                       }
                      else{
                        cliente = row_n[2].ToString();
                          }
                    

                    DevExpress.XtraBars.Navigation.TileBarItem item1 = new DevExpress.XtraBars.Navigation.TileBarItem() { Text = titulo_neg+"("+cliente+")", Tag = id_neg };
                    item1.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
                    item1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
                    item1.AppearanceItem.Normal.BackColor = Color.DarkSeaGreen;
                    item1.AppearanceItem.Normal.ForeColor = Color.Black;
                    item1.ItemClick += Item1_ItemClick;
                    tilebar.Groups[0].Items.Add(item1);

                 
                }

            }

        }

        private void Item1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            string id_negocio = e.Item.Tag.ToString();
            DataTable dt = OpBD.SeleccionarNegocioEspecifico(id_negocio);
            DataRow row = dt.Rows[0];
            string id = row[0].ToString();
            string titulo = row[1].ToString();
            string persona = row[2].ToString();
            string empresa = row[3].ToString();
            string moneda = row[4].ToString();
            string valor = row[5].ToString();
            string fecha_cierre = row[6].ToString();
            string categoria = row[7].ToString();

            FormDetallesNegocio f = new FormDetallesNegocio();
            f.id_negocio = id;
            f.titulo = titulo;
            f.nombre_persona = persona;
            f.nombre_empresa = empresa;
            f.moneda = moneda;
            f.valor = valor;
            f.fecha_cierre = fecha_cierre;
            f.categoria = categoria;

            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void Dgv_neg_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //DataRow row = dgv_neg.GetFocusedDataRow();
            //string id_negocio = row[0].ToString();
            //string titulo = row[1].ToString();
            //string cliente = row[2].ToString();
            //string empresa = row[3].ToString();
            //string moneda = row[4].ToString();
            //string valor = row[5].ToString();
            //string fecha_cierre = row[6].ToString();
            //string categoria = row[7].ToString();

            //FormDetallesNegocio f = new FormDetallesNegocio();
            //f.id_negocio = id_negocio;
            //f.titulo = titulo;
            //f.nombre_persona = cliente;
            //f.nombre_empresa = empresa;
            //f.moneda = moneda;
            //f.valor= valor;
            //f.fecha_cierre = fecha_cierre;
            //f.categoria = categoria;

            //f.MdiParent = this.MdiParent;
            //f.Show();
    }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            FormNuevoNegocio f = new FormNuevoNegocio();
            f.MdiParent = this.MdiParent;
            f.Show();
            
        }

        private void dgv_negocios_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = dgv_neg.GetFocusedDataRow();
            string id_negocio = row[0].ToString();
            string titulo = row[1].ToString();
            string cliente = row[2].ToString();
            string empresa = row[3].ToString();
            string moneda = row[4].ToString();
            string valor = row[5].ToString();
            string fecha_cierre = row[6].ToString();
            string categoria = row[7].ToString();

            FormDetallesNegocio f = new FormDetallesNegocio();
            f.id_negocio = id_negocio;
            f.titulo = titulo;
            f.nombre_persona = cliente;
            f.nombre_empresa = empresa;
            f.moneda = moneda;
            f.valor = valor;
            f.fecha_cierre = fecha_cierre;
            f.categoria = categoria;

            f.MdiParent = this.MdiParent;
            f.Show();

        }

        private void btn_nuevo_Click_1(object sender, EventArgs e)
        {
            FormNuevoNegocio f = new FormNuevoNegocio();
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DataRow row = dgv_neg.GetFocusedDataRow();

            if (row != null)
            {
                
                if (MessageBox.Show("¿Esta seguro de que desea eliminar la negociación?","Eliminar negociación",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    string id_negocio = row[0].ToString();
                    string titulo = row[1].ToString();

                    OpBD o = new OpBD();
                    int res = o.EliminarNegociacion(id_negocio, titulo);

                    if (res == 1)
                    {
                        MessageBox.Show("Negociación eliminada con exito");

                        dgv_negocios.DataSource = OpBD.SeleccionarNegocios();
                        if (dgv_negocios.DataSource != null)
                        {
                            dgv_neg.Columns[0].Caption = "No.";
                            dgv_neg.Columns[1].Caption = "Titulo";
                            dgv_neg.Columns[2].Caption = "Persona";
                            dgv_neg.Columns[3].Caption = "Organización";
                            dgv_neg.Columns[4].Caption = "Moneda";
                            dgv_neg.Columns[5].Caption = "Valor";
                            dgv_neg.Columns[6].Caption = "Fecha de cierre estimada";
                            dgv_neg.Columns[7].Caption = "Categoría";

                            dgv_neg.Columns[0].Width = 28;
                            dgv_neg.RowClick += Dgv_neg_RowClick;
                        }
                    }
                    else { MessageBox.Show("Eliminación no realizada"); }

                }

            }




        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegociod fn = new CapaNegociod();
            fn.Anterior(dgv_neg);




            //int indice = dgv_neg.FocusedRowHandle;
            //MessageBox.Show(indice.ToString());
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegociod fn = new CapaNegociod();
            fn.Siguiente(dgv_neg);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegociod fn = new CapaNegociod();
            fn.Primero(dgv_neg);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegociod fn = new CapaNegociod();
            fn.Ultimo(dgv_neg);
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            dgv_negocios.DataSource = OpBD.SeleccionarNegocios();
            //if (dgv_negocios.DataSource != null)
            //{
            //    dgv_neg.Columns[0].Caption = "No.";
            //    dgv_neg.Columns[1].Caption = "Titulo";
            //    dgv_neg.Columns[2].Caption = "Persona";
            //    dgv_neg.Columns[3].Caption = "Organización";
            //    dgv_neg.Columns[4].Caption = "Moneda";
            //    dgv_neg.Columns[5].Caption = "Valor";
            //    dgv_neg.Columns[6].Caption = "Fecha de cierre estimada";
            //    dgv_neg.Columns[7].Caption = "Categoría";

            //    dgv_neg.Columns[0].Width = 28;
            //    dgv_neg.RowClick += Dgv_neg_RowClick;
            //}

            tileBar0.Groups.Clear();
            tileBar1.Groups.Clear();
            tileBar2.Groups.Clear();
            tileBar3.Groups.Clear();

            //************************ESTADOS********************
            DataTable dt_etapa0 = OpBD.SeleccionarNegociosEtapa0();
            ObtenerNegociosPorEtapa(dt_etapa0, tileBar0);


            DataTable dt_etapa1 = OpBD.SeleccionarNegociosEtapa1();
            ObtenerNegociosPorEtapa(dt_etapa1, tileBar1);
            DataTable dt_etapa2 = OpBD.SeleccionarNegociosEtapa2();
            ObtenerNegociosPorEtapa(dt_etapa2, tileBar2);
            DataTable dt_etapa3 = OpBD.SeleccionarNegociosEtapa3();
            ObtenerNegociosPorEtapa(dt_etapa3, tileBar3);
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            DataRow row = dgv_neg.GetFocusedDataRow();
            string id_negocio = row[0].ToString();
            string titulo = row[1].ToString();
            string persona = row[2].ToString();
            string empresa = row[3].ToString();
            string moneda = row[4].ToString();
            string valor = row[5].ToString();
            string fecha_cierre = row[6].ToString();
            string categoria = row[7].ToString();
            FormNuevoNegocio f = new FormNuevoNegocio();
            f.id_negocio_e = id_negocio;
            f.titulo_e = titulo;
            f.persona_e = persona;
            f.empresa_e = empresa;
            f.moneda_e = moneda;
            f.valor_e = valor;
            f.fecha_cierre_e = fecha_cierre;
            f.categoria_e = categoria;
            f.btn_guardar.Text = "Actualizar";

            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void btn_clie_Click(object sender, EventArgs e)
        {
            dgv_neg.Columns[3].GroupIndex = -1;
            dgv_neg.Columns[7].GroupIndex = -1;

            dgv_neg.Columns[2].GroupIndex = 1;
            
        }

        private void btn_cat_Click(object sender, EventArgs e)
        {
            dgv_neg.Columns[2].GroupIndex = -1;
            dgv_neg.Columns[3].GroupIndex = -1;

            dgv_neg.Columns[7].GroupIndex = 1;
        }

        private void btn_normal_Click(object sender, EventArgs e)
        {
            dgv_neg.Columns[2].GroupIndex = -1;
            dgv_neg.Columns[3].GroupIndex = -1;
            dgv_neg.Columns[7].GroupIndex = -1;
        }

        private void dgv_negocios_Click(object sender, EventArgs e)
        {

        }

        private void btn_empresa_Click(object sender, EventArgs e)
        {
            dgv_neg.Columns[2].GroupIndex = -1;
            dgv_neg.Columns[7].GroupIndex = -1;

            dgv_neg.Columns[3].GroupIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Reporte_Negocios r = new Form_Reporte_Negocios();
            r.dataGridView1.DataSource = OpBD.SeleccionarNegocios();
            r.Show();
        }
    }
}
