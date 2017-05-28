using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm
{
    public partial class FormDetallesNegocio : Form
    {
        public FormDetallesNegocio()
        {
            InitializeComponent();
        }

        string id_nota_actual;
        int cont = 0;
        public string id_negocio;
        public string titulo;
        public string nombre_persona;
        public string nombre_empresa;
        public string moneda;
        public string valor;
        public string fecha_cierre;
        public string categoria;

        Color[] vector_colores = {Color.LightCoral, Color.Khaki, Color.LightGreen, Color.Plum, Color.LightPink, Color.Aquamarine, Color.Tan, Color.GreenYellow };
        int cont_color = 0;
        private void FormDetallesNegocio_Load(object sender, EventArgs e)
        {
            this.Text = titulo;

            DataTable dt = OpBD.SeleccionarDatosRestantes(id_negocio);
            DataRow row = dt.Rows[0];
            string detalles = row[0].ToString();
            string etapa = row[1].ToString();
            string fecha_inicio = row[2].ToString();
            string id_empleado = row[3].ToString();
            string nombre_empleado = row[4].ToString();
            string estado = row[5].ToString();
//-----------------------------------------------------------------
            string empleado_ws = "--";
            ServiceReference1.Service1Client srv = new ServiceReference1.Service1Client();
            DataSet ds = srv.ObtenerEmpleados();
            DataTable dt_empleadas = new DataTable();
            dt_empleadas = ds.Tables[0];
            foreach (DataRow roww in dt_empleadas.Rows)
            {
                if (roww[0].ToString() == id_empleado)
                {
                    empleado_ws = roww[6].ToString();
                }
            }
            lbl_encargado.Text = empleado_ws;
//--------------------------------------------------------
            groupControl1.Text = titulo;
            if(!String.IsNullOrEmpty(nombre_persona))
            {
                lbl_cliente.Text = nombre_persona;
            }
            else if (!String.IsNullOrEmpty(nombre_empresa))
                {
                lbl_cliente.Text = nombre_empresa;
                }

            decimal valor2 = Convert.ToDecimal(valor);
            lbl_valor.Text = moneda +" "+ valor2.ToString("#,###.##"); ;

            string[] fecha_inicio_separado = fecha_inicio.Split(' ');
            lbl_fecha_ini.Text = fecha_inicio_separado[0];
            string[] fecha_cierre_separado = fecha_cierre.Split(' ');
            lbl_fecha_cierre.Text = fecha_cierre_separado[0];

            lbl_categoria.Text = categoria;
            label5.Text = detalles;

            switch (etapa)
            {
                case "0":
                    lbl_etapa.Text = "Preparación";
                    break;
                case "1":
                    lbl_etapa.Text = "Discusión o Desarrollo";
                    break;
                case "2":
                    lbl_etapa.Text = "Propuesta realizada";
                    break;
                case "3":
                    lbl_etapa.Text = "Cierre o acuerdo";
                    break;
            }
            


           // lbl_encargado.Text = nombre_empleado;
            lbl_estado.Text = estado;
            if(estado == "Perdida")
            {
                btn_perdida.ForeColor = Color.White;
                
            }else if(estado == "Proceso")
                  {
                btn_proceso.ForeColor = Color.White;
                 }
            else if(estado == "Ganada")
                         {
                         btn_Ganada.ForeColor = Color.White;
                          }

            rtxt_notas.ForeColor = Color.Gray;
            rtxt_notas.Text = "Agrege una nota acerca de " + titulo; ;

            btn_Ganada.Image = Image.FromFile("like20.png");
            btn_perdida.Image = Image.FromFile("dislike20.png");

            ObtenerNotas();
            btn_eliminar_nota.Enabled = false;
            btn_eliminar_nota.Visible = false;

            //---------------------tareas--------------

             DataTable dt_tareasneg= OpBD.SeleccionarTareasNEG(id_negocio);
            if (dt_tareasneg != null)
            {
                gridControl_tareas.DataSource = dt_tareasneg;
                dgv_tareas.Columns[0].Caption = "Descripción";
                dgv_tareas.Columns[1].Caption = "Fecha";
                dgv_tareas.Columns[2].Caption = "Tipo";
                dgv_tareas.Columns[3].Caption = "Empleado";
                dgv_tareas.Columns[4].Caption = "Estado";
                dgv_tareas.Columns[5].Caption = "Criticidad";
                dgv_tareas.Columns[6].Visible = false;
                dgv_tareas.Columns[7].Visible = false;
                dgv_tareas.Columns[8].Visible = false;
                dgv_tareas.Columns[3].Visible = false;

                dgv_tareas.Columns[0].Width = 115;
                dgv_tareas.Columns[1].Width = 70;
                dgv_tareas.Columns[2].Width = 58;
                dgv_tareas.Columns[3].Width = 90;
                dgv_tareas.Columns[4].Width = 60;
                dgv_tareas.Columns[5].Width = 47;
            }
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            cont++;
            if(cont == 1 && rtxt_notas.Text == "Agrege una nota acerca de " + titulo)
            {
                rtxt_notas.Text = "";
                rtxt_notas.ForeColor = Color.Black;
            }
        }

        private void btn_perdida_MouseHover(object sender, EventArgs e)
        {
            btn_perdida.Appearance.BackColor = Color.Red;
        }

        private void btn_perdida_MouseLeave(object sender, EventArgs e)
        {
            btn_perdida.Appearance.BackColor = Color.Tomato;
        }

        private void btn_Ganada_MouseHover(object sender, EventArgs e)
        {
            btn_Ganada.Appearance.BackColor = Color.LimeGreen;
        }

        private void btn_Ganada_MouseLeave(object sender, EventArgs e)
        {
            btn_Ganada.Appearance.BackColor = Color.LightGreen;
        }

        private void btn_proceso_MouseHover(object sender, EventArgs e)
        {
            btn_proceso.Appearance.BackColor = Color.DodgerBlue;
        }

        private void btn_proceso_MouseLeave(object sender, EventArgs e)
        {
            btn_proceso.Appearance.BackColor = Color.SkyBlue;
        }

        private void btn_guardar_nota_Click(object sender, EventArgs e)
        {
            //******************************************************************
            //tileBar_notas.Groups.Add(new DevExpress.XtraEditors.TileGroup());
            //DevExpress.XtraBars.Navigation.TileBarItem item1 = new DevExpress.XtraBars.Navigation.TileBarItem() { Text=" MI Item1 oooooooooooooooooooooooooooooooo.",};
            //item1.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            //item1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            //item1.AppearanceItem.Normal.BackColor = vector_colores[cont_color];
            //item1.AppearanceItem.Normal.ForeColor = Color.Black;
            //tileBar_notas.Groups[0].Items.Add(item1);

            //cont_color++;
            //if(cont_color == 8)
            //{
            //    cont_color = 0;
            //}
            //********************************************************
            if (btn_guardar_nota.Text == "Guardar" )
            {
                if (!String.IsNullOrEmpty(rtxt_notas.Text) && rtxt_notas.Text.Trim() != "Agrege una nota acerca de " + titulo)
                {
                    string texto_nota = rtxt_notas.Text.Trim();
                    OpBD o = new OpBD();
                    int res = o.InsertarNota(texto_nota, id_negocio, titulo);
                    if (res == 1)
                    {
                        rtxt_notas.Text = "";
                    }
                    else { MessageBox.Show("Problema al ingresar nota"); }

                    tileBar_notas.Groups.Clear();
                    ObtenerNotas();
                }
            }else if(btn_guardar_nota.Text == "Aceptar")
                   {
                      if(!String.IsNullOrEmpty(rtxt_notas.Text))
                        {
                          OpBD o = new OpBD();
                          int res_a = o.ActualizarNota(rtxt_notas.Text.Trim(),id_nota_actual,titulo);
                           if(res_a == 1)
                            {
                              rtxt_notas.Text = "";
                              tileBar_notas.Groups.Clear();
                              ObtenerNotas();
                              btn_guardar_nota.Text = "Guardar";
                              btn_eliminar_nota.Enabled = false;
                              btn_eliminar_nota.Visible = false;
                            }
                            else { MessageBox.Show("problema al actualizar la nota"); }
                        }
                   }
            
        }

        private void ObtenerNotas()
        {
            DataTable dt_notas = OpBD.SeleccionarNotas(id_negocio);
            if(dt_notas != null && dt_notas.Rows.Count > 0)
            {
                tileBar_notas.Groups.Add(new DevExpress.XtraEditors.TileGroup());

                foreach (DataRow row_n in dt_notas.Rows)
                {
                    string id_nota = row_n[0].ToString();
                    string nota = row_n[2].ToString();

                    DevExpress.XtraBars.Navigation.TileBarItem item1 = new DevExpress.XtraBars.Navigation.TileBarItem() { Text = nota, Tag = id_nota};
                    item1.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
                    item1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
                    item1.AppearanceItem.Normal.BackColor = vector_colores[cont_color];
                    item1.AppearanceItem.Normal.ForeColor = Color.Black;
                    item1.ItemClick += Item1_ItemClick;
                    tileBar_notas.Groups[0].Items.Add(item1);

                    cont_color++;
                    if (cont_color == 8)
                    {
                        cont_color = 0;
                    }
                }

            }
        }

        private void Item1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            rtxt_notas.Text = e.Item.Text;
            rtxt_notas.ForeColor = Color.Black;
            id_nota_actual = e.Item.Tag.ToString();
            btn_guardar_nota.Text = "Aceptar";
            btn_eliminar_nota.Enabled = true;
            btn_eliminar_nota.Visible = true;
        }

        private void btn_eliminar_nota_Click(object sender, EventArgs e)
        {

            OpBD o = new OpBD();
            int res = o.EliminarNota(id_nota_actual,titulo);

            if (res == 1)
            {
                rtxt_notas.Text = "";
                btn_eliminar_nota.Enabled = false;
                btn_eliminar_nota.Visible = false;
                btn_guardar_nota.Text = "Guardar";
                tileBar_notas.Groups.Clear();
                ObtenerNotas();
                
            }
            else { MessageBox.Show("No se pudo eliminar la nota"); }
        }
        //---------------------------------------------------------------------------
        private void btn_nueva_tarea_Click(object sender, EventArgs e)
        {
            FormTareasNegocio f = new FormTareasNegocio();
            f.titulo = titulo;
            f.id_negocio = id_negocio;
            f.Show();
        }

        private void btn_perdida_Click(object sender, EventArgs e)
        {
           
            OpBD o = new OpBD();
            int res = o.ActualizarEstatus("Perdido",id_negocio,titulo);
            if(res == 1)
            {
               // MessageBox.Show("exito");
                lbl_estado.Text = "Perdida";
                btn_perdida.ForeColor = Color.White;

                btn_proceso.ForeColor = Color.Black;
                btn_Ganada.ForeColor = Color.Black;
            }
            
        }

        private void btn_proceso_Click(object sender, EventArgs e)
        {
            OpBD o = new OpBD();
            int res = o.ActualizarEstatus("Proceso", id_negocio, titulo);
            if (res == 1)
            {
                // MessageBox.Show("exito");
                lbl_estado.Text = "Proceso";
                btn_proceso.ForeColor = Color.White;

                btn_perdida.ForeColor = Color.Black;
                btn_Ganada.ForeColor = Color.Black;
            }
        }

        private void btn_Ganada_Click(object sender, EventArgs e)
        {
            OpBD o = new OpBD();
            int res = o.ActualizarEstatus("Ganado", id_negocio, titulo);
            if (res == 1)
            {
                // MessageBox.Show("exito");
                lbl_estado.Text = "Ganada";
                btn_Ganada.ForeColor = Color.White;

                btn_proceso.ForeColor = Color.Black;
                btn_perdida.ForeColor = Color.Black;
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DataRow fila = dgv_tareas.GetFocusedDataRow();
            string eliminada = fila[6].ToString();

            OpBD o = new OpBD();
           int res = o.EliminarTarea(eliminada,titulo);
            if(res == 1)
                {
                DataTable dt_tareasneg = OpBD.SeleccionarTareasNEG(id_negocio);
                if (dt_tareasneg != null)
                {
                    gridControl_tareas.DataSource = dt_tareasneg;
                    dgv_tareas.Columns[0].Caption = "Descripción";
                    dgv_tareas.Columns[1].Caption = "Fecha";
                    dgv_tareas.Columns[2].Caption = "Tipo";
                    dgv_tareas.Columns[3].Caption = "Empleado";
                    dgv_tareas.Columns[4].Caption = "Estado";
                    dgv_tareas.Columns[5].Caption = "Criticidad";
                    dgv_tareas.Columns[6].Visible = false;
                }
                MessageBox.Show("Eliminacion exitosa");
            }else
            {
                MessageBox.Show("No se elimino");
            }


        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            DataRow fila = dgv_tareas.GetFocusedDataRow();
            string id_tarea = fila[6].ToString();
            string descripcion = fila[0].ToString();
            string fecha = fila[1].ToString();
            string tipo = fila[2].ToString();
            string empleado = fila[7].ToString();
            string estado = fila[4].ToString();
            string criticidad = fila[5].ToString();
            string hora_fin = fila[8].ToString();

            string[] fecha_hora = fecha.Split(' ');
            DateTime solo_fecha = Convert.ToDateTime(fecha_hora[0]);
            DateTime solo_hora = Convert.ToDateTime(fecha_hora[1]);

            string[] hora_fin_Vec = hora_fin.Split(' ');
            DateTime hora_terminacion = Convert.ToDateTime(hora_fin_Vec[1]);

            //MessageBox.Show(solo_fecha.ToString() + solo_hora.ToString());

            FormTareasNegocio f = new FormTareasNegocio();
            f.te_hora.EditValue = solo_hora;
            f.dn_fecha.EditValue = solo_fecha;
            f.te_hora_fin.EditValue = hora_terminacion;
            f.txt_descripcion.Text = descripcion;
            f.cbo_criticidad.SelectedItem = criticidad;
            f.empleado = empleado;
            f.id_tarea = id_tarea;
            f.tipo = tipo;

            f.btn_guardar.Text = "Actualizar";
            f.Show();
        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            DataTable dt_tareasneg = OpBD.SeleccionarTareasNEG(id_negocio);
            if (dt_tareasneg != null)
            {
                gridControl_tareas.DataSource = dt_tareasneg;
                dgv_tareas.Columns[0].Caption = "Descripción";
                dgv_tareas.Columns[1].Caption = "Fecha";
                dgv_tareas.Columns[2].Caption = "Tipo";
                dgv_tareas.Columns[3].Caption = "Empleado";
                dgv_tareas.Columns[4].Caption = "Estado";
                dgv_tareas.Columns[5].Caption = "Criticidad";
                dgv_tareas.Columns[6].Visible = false;
                dgv_tareas.Columns[7].Visible = false;

                dgv_tareas.Columns[0].Width = 115;
                dgv_tareas.Columns[1].Width = 70;
                dgv_tareas.Columns[2].Width = 58;
                dgv_tareas.Columns[3].Width = 90;
                dgv_tareas.Columns[4].Width = 60;
                dgv_tareas.Columns[5].Width = 47;
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
