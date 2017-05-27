using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;
using System.Xml;
using System.Globalization;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
//using System.Windows.Forms.DataVisualization.Charting;





namespace crm
{
    public partial class frm_estadistica_personal : DevExpress.XtraEditors.XtraForm
    {
        public frm_estadistica_personal()
        {
            InitializeComponent();
        }
        // ---------------------- MARVIN ROUGGERI YOQUE LOPEZ 0901-13-281


        CapaDatosPersonas CapaDatos = new CapaDatosPersonas();
        // -------------------------------------AREA DE VARIABLES GLOBALES

        // titulo de grafico
        string titulo = "";


        // grafica de pie para desempeño del usuario
        ChartControl pie = new ChartControl();
        // llamada a la clase de graficacion
        cls_grafica_pie grafica_pie = new cls_grafica_pie();


        string var_id_usuario = ""; // id de usuario para consultar en la base de datos, tomado del combobox
        // variables para determinar fecha y dia
        DateTime fecha_hoy = DateTime.Today; // fecha hoy
        DateTime fecha_fin_semana; // variable usada para calcular los valores de la semana anterior

        Calendar calendario = CultureInfo.InvariantCulture.Calendar;
        string nombre = ""; // nombre del dia de la semana
        DateTime fecha_inicio; // usada para determinar el inicio del rango de fechas


        // ------------------------ Variables para cuantificar las tareas
        //string tipo_tarea="";
        int cont_almuerzo_realiz = 0; int cont_almuerzo_pen = 0;
        int cont_tarea_realiz = 0; int cont_tarea_pen = 0;
        int cont_llamada_realiz = 0; int cont_llamada_pen = 0;
        int cont_reunion_realiz = 0; int cont_reunion_pen = 0;
        int cont_plazo_realiz = 0; int cont_plazo_pen = 0;
        //// ----------------------------- Variables para cuantificar los negocios
        double monto_proceso = 0; int cont_proceso=0;
        double monto_perdido = 0; int cont_perdido=0;
        double monto_ganado = 0; int cont_ganado = 0;

        // --------------------------------------------------------------------------------------------------
        string var_fecha_perz_ini="";
        string var_fecha_perz_fin="";
        //--------------------------------------------- Estado para tomar las variables de inicio y fin de fecha
        DataTable dt_nego_ganado = new DataTable();
        DataTable dt_nego_perdido = new DataTable();
        DataTable dt_nego_proceso = new DataTable();
        // ---------------------------------------------------- VARIABLES DE CONTADOR DE CASOS PENDIENTES O REALIZADOS PARA GRAFICA DE PIE DE CASOS - RENDIMIENTO DE EMPLEADO
        int cont_caso_fin = 0;
        int cont_caso_reali = 0;

              
        
        // LOAD del formulario de estadisticas personales:

        private void frm_estadistica_personal_Load(object sender, EventArgs e)
        {
          

            WindowState = FormWindowState.Maximized;
            pcb_foto.Image = Image.FromFile("andre.jpg");

            // carga de combobox de usuarios de la empresa
            DataTable empleados = new DataTable();
            empleados = CapaDatos.cargar_empleados();
            cmb_usuarios.DataSource = empleados;
            cmb_usuarios.DisplayMember = "nombres";
            cmb_usuarios.ValueMember = "id_empleado";



            // -----------------------------------------------
            //creacion de nuevo datatable hijo de negocios en proceso
            DataColumn column_nego_proces = new DataColumn();


            column_nego_proces.DataType = System.Type.GetType("System.String");
            column_nego_proces.ColumnName = "Titulo";
            dt_nego_proceso.Columns.Add(column_nego_proces);


            column_nego_proces = new DataColumn();
            column_nego_proces.DataType = System.Type.GetType("System.String");
            column_nego_proces.ColumnName = "Categoria";
            dt_nego_proceso.Columns.Add(column_nego_proces);


            column_nego_proces = new DataColumn();
            column_nego_proces.DataType = System.Type.GetType("System.String");
            column_nego_proces.ColumnName = "Tipo de tarea";
            dt_nego_proceso.Columns.Add(column_nego_proces);

            column_nego_proces = new DataColumn();
            column_nego_proces.DataType = System.Type.GetType("System.String");
            column_nego_proces.ColumnName = "Usuario";
            dt_nego_proceso.Columns.Add(column_nego_proces);

            column_nego_proces = new DataColumn();
            column_nego_proces.DataType = System.Type.GetType("System.String");
            column_nego_proces.ColumnName = "Apellidos";
            dt_nego_proceso.Columns.Add(column_nego_proces);

            column_nego_proces = new DataColumn();
            column_nego_proces.DataType = System.Type.GetType("System.String");
            column_nego_proces.ColumnName = "Empresa";
            dt_nego_proceso.Columns.Add(column_nego_proces);

            column_nego_proces = new DataColumn();
            column_nego_proces.DataType = System.Type.GetType("System.String");
            column_nego_proces.ColumnName = "Monto";
            dt_nego_proceso.Columns.Add(column_nego_proces);

            // creacion de nuevo datatable hijo de negocios perdidos
            DataColumn column_nego = new DataColumn();
            DataRow row1 = dt_nego_perdido.NewRow();
            column_nego.DataType = System.Type.GetType("System.String");
            column_nego.ColumnName = "Titulo";
            dt_nego_perdido.Columns.Add(column_nego);

            column_nego = new DataColumn();
            column_nego.DataType = System.Type.GetType("System.String");
            column_nego.ColumnName = "Categoria";
            dt_nego_perdido.Columns.Add(column_nego);


            column_nego = new DataColumn();
            column_nego.DataType = System.Type.GetType("System.String");
            column_nego.ColumnName = "Tipo de tarea";
            dt_nego_perdido.Columns.Add(column_nego);

            column_nego = new DataColumn();
            column_nego.DataType = System.Type.GetType("System.String");
            column_nego.ColumnName = "Usuario";
            dt_nego_perdido.Columns.Add(column_nego);

            column_nego = new DataColumn();
            column_nego.DataType = System.Type.GetType("System.String");
            column_nego.ColumnName = "Apellidos";
            dt_nego_perdido.Columns.Add(column_nego);

            column_nego = new DataColumn();
            column_nego.DataType = System.Type.GetType("System.String");
            column_nego.ColumnName = "Empresa";
            dt_nego_perdido.Columns.Add(column_nego);

            column_nego = new DataColumn();
            column_nego.DataType = System.Type.GetType("System.String");
            column_nego.ColumnName = "Monto";
            dt_nego_perdido.Columns.Add(column_nego);


            // creacion de nuevo datatable hijo de negocios ganados
            DataColumn column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "Titulo";
            dt_nego_ganado.Columns.Add(column_nego_ganados);

            column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "Categoria";
            dt_nego_ganado.Columns.Add(column_nego_ganados);


            column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "Tipo de tarea";
            dt_nego_ganado.Columns.Add(column_nego_ganados);

            column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "Usuario";
            dt_nego_ganado.Columns.Add(column_nego_ganados);

            column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "Apellidos";
            dt_nego_ganado.Columns.Add(column_nego_ganados);

            column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "Empresa";
            dt_nego_ganado.Columns.Add(column_nego_ganados);

            column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "Monto";
            dt_nego_ganado.Columns.Add(column_nego_ganados);

           

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_NuevoCaso caso = new frm_NuevoCaso();
            caso.Show();
        }


        // combobox de usuarios
        private void cmb_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // limpieza de variables para grafica de dona o pie:
            pie.DataSource = null;
            pie.Series.Clear();
            pie.Titles.Clear();
            //pie.Series.Clear();
            // inicializaciòn de variables contadores de casos activos o inactivos
            cont_caso_fin = 0;
            cont_caso_reali = 0;
            
            
            //pie.Update();
            //pie.Refresh();
           

            try
            {
                var_id_usuario = cmb_usuarios.SelectedValue.ToString();
              
                if (cmb_usuarios.SelectedValue.ToString() == "System.Data.DataRowView" || cmb_usuarios.Text=="")
                {
                    pcb_foto.Image = Image.FromFile("andre.jpg");

                }

                else
                {
                    
                    DataTable datos_usuario = new DataTable();
                    datos_usuario = CapaDatos.consultar_empleado_especifico(var_id_usuario);
                    DataRow fila = datos_usuario.Rows[0];
                    lbl_nombres.Text = fila["nombres"].ToString();
                    lbl_apellidos.Text = fila["apellidos"].ToString();
                    lbl_email.Text = fila["correo"].ToString();
                    pcb_foto.ImageLocation = fila["foto"].ToString();

                    // ---------------------------------------------------- CARGA DE CASOS EN PESTAÑA DE CASOS ------------------------------------------

                    // limpiar grid de casos
                    dgv_casos.DataSource = "";
                    // limpiar grid de historial
                    dgv_historial_actualizaciones.DataSource = "";




                    // headers de las columnas del grid de casos
                    gridView1.Columns["titulo"].Caption = "Caso";
                    gridView1.Columns["nombres"].Caption = "Usuario";
                    gridView1.Columns["apellidos"].Caption = "Apellidos";
                    gridView1.Columns["nombre"].Caption = "Empresa";
                    gridView1.Columns["fecha_limite"].Caption = "Fecha limite";
                    gridView1.Columns["estado"].Caption = "Estado";
                    gridView1.Columns["nombres1"].Caption = "Encargado";

                    // headers de las columnas del grid de tareas (historial)
                    gridView2.Columns["id_tarea"].Visible = false;
                    gridView2.Columns["id_empleado"].Visible = false;
                    gridView2.Columns["tipo"].Caption = "Tarea";
                    gridView2.Columns["titulo"].Caption = "Negociación";
                    gridView2.Columns["titulo1"].Caption = "Caso";
                    gridView2.Columns["estado_tarea"].Caption = "Estado";
                    gridView2.Columns["criticidad"].Caption = "Criticidad";
                    gridView2.Columns["fecha_asignacion"].Caption = "Fecha de asignación";
                    gridView2.Columns["fecha_establecida"].Caption = "Fecha límite";

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //DataRow casilla = datos_usuario.Rows[];

            // carga de gridcasos
            DataTable casos = new DataTable();
            casos = CapaDatos.consultar_caso(var_id_usuario);
            dgv_casos.DataSource = casos;

            // carga de gridhistorial (tareas) que contienen todas las negociaciones y tareas en general
            DataTable tareas = new DataTable();
            tareas = CapaDatos.consultar_tareas(var_id_usuario);
            dgv_historial_actualizaciones.DataSource = tareas;


            // ----------------- creacion de grafica de pie para casos rendimientos -----------------------
            // Fondo de grafica transparente y borde:
            pie.BackColor = Color.Transparent;
            pie.BorderOptions.Color = Color.Transparent;


            // seleccion de numero de casos finalizados y no finalizados para hacer grafica de pie en CASOS
            foreach (DataRow fila in casos.Rows)
            {
                if (fila["estado"].ToString() == "activo")
                {
                    cont_caso_reali = cont_caso_reali + 1;
                }
                else if (fila["estado"].ToString() == "inactivo")
                {
                    cont_caso_fin = cont_caso_fin + 1;
                }
            }
            //if (cont_caso_fin == 0 || cont_caso_reali == 0)
            //{
            //    MessageBox.Show("Datos insuficientes para generar grafico");
            //}
            //else
            //{
                    
                               
                DataTable dt_pie = new DataTable();

                dt_pie.Columns.Add("estado", typeof(string));
                dt_pie.Columns.Add("cantidad", typeof(Int32));

                
                dt_pie.Rows.Add(new object[] { "Casos Finalizados", cont_caso_fin });
                dt_pie.Rows.Add(new object[] { "Casos Activos", cont_caso_reali });


                Series serie1 = new Series("pie", ViewType.Doughnut3D);

                foreach (DataRow row in dt_pie.Rows)
                {
                    string estado = row["estado"].ToString();
                    string cantidad = row["cantidad"].ToString();
                    serie1.Points.Add(new SeriesPoint(estado, cantidad));
                }
                pie.Series.Add(serie1);
                
                serie1.PointOptions.ValueNumericOptions.Precision = 0;
                serie1.PointOptions.PointView = PointView.ArgumentAndValues;

                ((Pie3DSeriesView)serie1.View).Depth = 30;
                ((Pie3DSeriesView)serie1.View).ExplodedPoints.Add(serie1.Points[0]);
                ((Pie3DSeriesView)serie1.View).ExplodedDistancePercentage = 30;

                ((SimpleDiagram3D)pie.Diagram).RotationType = RotationType.UseAngles;
                ((SimpleDiagram3D)pie.Diagram).RotationAngleX = -35;

            ChartTitle titulo = new ChartTitle();
            titulo.Text = "Rendimiento de Usuario";
            pie.Titles.Add(titulo);
            pie.Legend.Visible = true;

                pie.Dock = DockStyle.Fill;
                blanco.Controls.Add(pie);

                
            //}
        }




        //-------------------------------------------------------------------------------------------------------------------------------------



        // boton para generar todos los resultados estadisticos generados el dia de hoy
        private void btn_hoy_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(fecha_hoy.ToString("yyyy-MM-dd"));
            nombre = calendario.GetDayOfWeek(fecha_hoy).ToString();

            //MessageBox.Show("Hoy es: " + nombre + " con fecha: " + fecha_hoy.ToString("yyyy-MM-dd"));


            //-------------------------------------------------------------------------------------------- Busqueda de negocios y tareas correspondientes:
            // variables de contadores negocio:
            cont_ganado = 0;
            cont_perdido = 0;
            cont_proceso = 0;
            // variables de montos de dinero del negocio:
            monto_ganado = 0;
            monto_perdido = 0;
            monto_proceso = 0;
            // variables para tareas
            cont_almuerzo_realiz = 0; cont_almuerzo_pen = 0;
            cont_tarea_realiz = 0; cont_tarea_pen = 0;
            cont_llamada_realiz = 0; cont_llamada_pen = 0;
            cont_reunion_realiz = 0; cont_reunion_pen = 0;
            cont_plazo_realiz = 0; cont_plazo_pen = 0;
            // limpiar datatables de negocios ganados, perdidos y en proceso:
            dt_nego_ganado.Rows.Clear();
            dt_nego_perdido.Rows.Clear();
            dt_nego_proceso.Rows.Clear();


            // -------------------- Envio de datos a clase capadatos
            DataTable negocios = CapaDatos.consultar_negocios(var_id_usuario, fecha_hoy.ToString("yyyy-MM-dd"), fecha_hoy.ToString("yyyy-MM-dd"));
            dgv_prueba.DataSource = negocios;
            // --------------------- CICLO PARA ELABORAR VISTA DE NEGOCIOS
            foreach (DataRow columna in negocios.Rows)
            {
                //cont_ganado = 0;
                //cont_perdido = 0;
                //cont_proceso = 0;

                if (columna["status"].ToString() == "proceso" || columna["status"].ToString() == "Proceso")
                {
                    cont_proceso = cont_proceso + 1;
                    monto_proceso += Convert.ToDouble(columna["valor"]);

                    //// creacion de nuevo datatable hijo
                    //DataRow row = dt_nego_ganado.NewRow();
                    //row["Titulo"] = columna["titulo"].ToString();
                    //dt_nego_ganado.Rows.Add(row);

                    DataRow row = dt_nego_proceso.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_proceso.Rows.Add(row);





                }
                else if (columna["status"].ToString() == "perdido" || columna["status"].ToString() == "Perdido")
                {
                    cont_perdido = cont_perdido + 1;
                    monto_perdido += Convert.ToDouble(columna["valor"]);


                    DataRow row = dt_nego_perdido.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_perdido.Rows.Add(row);
                }
                else if (columna["status"].ToString() == "ganado" || columna["status"].ToString() == "Ganado")
                {
                    cont_ganado = cont_ganado + 1;
                    monto_ganado += Convert.ToDouble(columna["valor"]);

                    DataRow row = dt_nego_ganado.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();

                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_ganado.Rows.Add(row);
                }
            }

            titulo = "Rendimiento de " + cmb_usuarios.Text;
            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios_emp.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
            // ---------------------------------------

            // grid de negocios ganados
            dgv_prueba.DataSource = dt_nego_ganado;
            // etiquetas de procesos iniciados:
            lbl_neg_ini1.Text = cont_proceso.ToString();
            lbl_neg_ini2.Text = cont_proceso.ToString();
            // etiquetas de procesos perdidos:
            lbl_neg_perdido1.Text = cont_perdido.ToString();
            lbl_neg_perdido2.Text = cont_perdido.ToString();
            // etiquetas de procesos ganados:
            lbl_neg_ganado1.Text = cont_ganado.ToString();
            lbl_neg_ganado2.Text = cont_ganado.ToString();
            // etiquetas de montos ganados:
            lbl_monto_gan1.Text = monto_ganado.ToString("N2");
            lbl_monto_gan2.Text = monto_ganado.ToString("N2");
            //etiquetas de montos perdidos:
            lbl_monto_per1.Text = monto_perdido.ToString("N2");
            lbl_monto_per2.Text = monto_perdido.ToString("N2");
            //etiquetas de montos en proceso:
            lbl_monto_ini1.Text = monto_proceso.ToString("N2");
            lbl_monto_ini2.Text = monto_proceso.ToString("N2");

            foreach (DataRow colum in negocios.Rows)
            {   // columna con llamada
                if (colum["tipo"].ToString() == "Llamada")
                {

                    // recorrer columna de estado_tarea para determinar si la tarea esta pendiente o realizada
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_llamada_pen = cont_llamada_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_llamada_realiz = cont_llamada_realiz + 1;
                    }
                }
                // columna con reunion
                else if (colum["tipo"].ToString() == "Reunion")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_reunion_pen = cont_reunion_pen + 1;
                        //MessageBox.Show("estoy en reunion pendiente");

                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        //MessageBox.Show("estoy en reunion realizado");

                        cont_reunion_realiz = cont_llamada_realiz + 1;
                    }
                }
                //// columna con tarea
                else if (colum["tipo"].ToString() == "Tarea")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_tarea_pen = cont_tarea_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_tarea_realiz = cont_tarea_realiz + 1;
                    }
                }
                //// columna con plazo
                else if (colum["tipo"].ToString() == "Plazo")
                {


                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_plazo_pen = cont_plazo_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_plazo_realiz = cont_plazo_realiz + 1;
                    }
                }
                //// columna con almuerzos
                else if (colum["tipo"].ToString() == "Almuerzo")
                {
                    //cont_almuerzo_pen = cont_almuerzo_pen+1;
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_almuerzo_pen = cont_almuerzo_pen + 1;
                        //MessageBox.Show("estoy en almuerzo pendiente");
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_almuerzo_realiz = cont_almuerzo_realiz + 1;
                        //MessageBox.Show("estoy en almuerzo realizado");
                    }
                }
            }
            // Etiquetas de tareas:
            lbl_almu_com1.Text = cont_almuerzo_realiz.ToString(); lbl_almu_com2.Text = cont_almuerzo_realiz.ToString();
            lbl_almu_pen1.Text = cont_almuerzo_pen.ToString(); lbl_almu_pen2.Text = cont_almuerzo_pen.ToString();

            lbl_llama_com1.Text = cont_llamada_realiz.ToString(); lbl_llama_com2.Text = cont_llamada_realiz.ToString();
            lbl_llama_pen1.Text = cont_llamada_pen.ToString(); lbl_llama_pen2.Text = cont_llamada_pen.ToString();

            lbl_plazo_com1.Text = cont_plazo_realiz.ToString(); lbl_plazo_com2.Text = cont_plazo_realiz.ToString();
            lbl_plazo_pen1.Text = cont_plazo_pen.ToString(); lbl_plazo_pen2.Text = cont_plazo_pen.ToString();

            lbl_reu_com1.Text = cont_reunion_realiz.ToString(); lbl_reu_com2.Text = cont_reunion_realiz.ToString();
            lbl_reu_pen1.Text = cont_reunion_pen.ToString(); lbl_reu_pen2.Text = cont_reunion_pen.ToString();

            lbl_tarea_com1.Text = cont_tarea_realiz.ToString(); lbl_tarea_com2.Text = cont_tarea_realiz.ToString();
            lbl_tarea_pen1.Text = cont_tarea_pen.ToString(); lbl_tarea_pen2.Text = cont_tarea_pen.ToString();




        }




        
        //----------------------------------------------------------------------------------------------------------------------------------------

           
        // Boton para generar todos los registros de ayer
        private void btn_ayer_Click(object sender, EventArgs e)
        {
            // ------ calculo de fecha de ayer:
             DateTime fecha_ayer = fecha_hoy.AddDays(-1);
            nombre = calendario.GetDayOfWeek(fecha_ayer).ToString();
            //MessageBox.Show(fecha_ayer.ToString("yyyy-MM-dd"),nombre);
            //MessageBox.Show("Ayer fue: " + nombre + " con fecha: " + fecha_ayer.ToString("yyyy-MM-dd"));

            //-------------------------------------------------------------------------------------------- Busqueda de negocios y tareas correspondientes:
            // variables de contadores negocio:
            cont_ganado = 0;
            cont_perdido = 0;
            cont_proceso = 0;
            // variables de montos de dinero del negocio:
            monto_ganado = 0;
            monto_perdido = 0;
            monto_proceso = 0;
            // variables para tareas
            cont_almuerzo_realiz = 0; cont_almuerzo_pen = 0;
            cont_tarea_realiz = 0; cont_tarea_pen = 0;
            cont_llamada_realiz = 0; cont_llamada_pen = 0;
            cont_reunion_realiz = 0; cont_reunion_pen = 0;
            cont_plazo_realiz = 0; cont_plazo_pen = 0;
            // limpiar datatables de negocios ganados, perdidos y en proceso:
            dt_nego_ganado.Rows.Clear();
            dt_nego_perdido.Rows.Clear();
            dt_nego_proceso.Rows.Clear();


            // -------------------- Envio de datos a clase capadatos
            DataTable negocios = CapaDatos.consultar_negocios(var_id_usuario, fecha_ayer.ToString("yyyy-MM-dd"), fecha_ayer.ToString("yyyy-MM-dd"));
            dgv_prueba.DataSource = negocios;
            // --------------------- CICLO PARA ELABORAR VISTA DE NEGOCIOS
            foreach (DataRow columna in negocios.Rows)
            {
                //cont_ganado = 0;
                //cont_perdido = 0;
                //cont_proceso = 0;

                if (columna["status"].ToString() == "proceso" || columna["status"].ToString() == "Proceso")
                {
                    cont_proceso = cont_proceso + 1;
                    monto_proceso += Convert.ToDouble(columna["valor"]);

                    DataRow row = dt_nego_proceso.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_proceso.Rows.Add(row);
                }
                else if (columna["status"].ToString() == "perdido" || columna["status"].ToString() == "Perdido")
                {
                    cont_perdido = cont_perdido + 1;
                    monto_perdido += Convert.ToDouble(columna["valor"]);


                    //Insercion de registros en  datatable hijo de negocios perdidos
                    DataRow row = dt_nego_perdido.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_perdido.Rows.Add(row);


                }
                else if (columna["status"].ToString() == "ganado" || columna["status"].ToString() == "Ganado")
                {
                    cont_ganado = cont_ganado + 1;
                    monto_ganado += Convert.ToDouble(columna["valor"]);

                    //Insercion de registros en  datatable hijo de negocios ganados
                    DataRow row = dt_nego_ganado.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();

                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_ganado.Rows.Add(row);
                }
            }

            titulo = "Rendimiento de " + cmb_usuarios.Text;
            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios_emp.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
            // ---------------------------------------


            // etiquetas de procesos iniciados:
            lbl_neg_ini1.Text = cont_proceso.ToString();
            lbl_neg_ini2.Text = cont_proceso.ToString();
            // etiquetas de procesos perdidos:
            lbl_neg_perdido1.Text = cont_perdido.ToString();
            lbl_neg_perdido2.Text = cont_perdido.ToString();
            // etiquetas de procesos ganados:
            lbl_neg_ganado1.Text = cont_ganado.ToString();
            lbl_neg_ganado2.Text = cont_ganado.ToString();
            // etiquetas de montos ganados:
            lbl_monto_gan1.Text = monto_ganado.ToString("N2");
            lbl_monto_gan2.Text = monto_ganado.ToString("N2");
            //etiquetas de montos perdidos:
            lbl_monto_per1.Text = monto_perdido.ToString("N2");
            lbl_monto_per2.Text = monto_perdido.ToString("N2");
            //etiquetas de montos en proceso:
            lbl_monto_ini1.Text = monto_proceso.ToString("N2");
            lbl_monto_ini2.Text = monto_proceso.ToString("N2");

            foreach (DataRow colum in negocios.Rows)
            {   // columna con llamada
                if (colum["tipo"].ToString() == "Llamada")
                {

                    // recorrer columna de estado_tarea para determinar si la tarea esta pendiente o realizada
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_llamada_pen = cont_llamada_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_llamada_realiz = cont_llamada_realiz + 1;
                    }
                }
                // columna con reunion
                else if (colum["tipo"].ToString() == "Reunion")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_reunion_pen = cont_reunion_pen + 1;
                        //MessageBox.Show("estoy en reunion pendiente");

                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        //MessageBox.Show("estoy en reunion realizado");

                        cont_reunion_realiz = cont_llamada_realiz + 1;
                    }
                }
                //// columna con tarea
                else if (colum["tipo"].ToString() == "Tarea")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_tarea_pen = cont_tarea_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_tarea_realiz = cont_tarea_realiz + 1;
                    }
                }
                //// columna con plazo
                else if (colum["tipo"].ToString() == "Plazo")
                {


                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_plazo_pen = cont_plazo_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_plazo_realiz = cont_plazo_realiz + 1;
                    }
                }
                //// columna con almuerzos
                else if (colum["tipo"].ToString() == "Almuerzo")
                {
                    //cont_almuerzo_pen = cont_almuerzo_pen+1;
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_almuerzo_pen = cont_almuerzo_pen + 1;
                        //MessageBox.Show("estoy en almuerzo pendiente");
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_almuerzo_realiz = cont_almuerzo_realiz + 1;
                        //MessageBox.Show("estoy en almuerzo realizado");
                    }
                }
            }
            // Etiquetas de tareas:
            lbl_almu_com1.Text = cont_almuerzo_realiz.ToString(); lbl_almu_com2.Text = cont_almuerzo_realiz.ToString();
            lbl_almu_pen1.Text = cont_almuerzo_pen.ToString(); lbl_almu_pen2.Text = cont_almuerzo_pen.ToString();

            lbl_llama_com1.Text = cont_llamada_realiz.ToString(); lbl_llama_com2.Text = cont_llamada_realiz.ToString();
            lbl_llama_pen1.Text = cont_llamada_pen.ToString(); lbl_llama_pen2.Text = cont_llamada_pen.ToString();

            lbl_plazo_com1.Text = cont_plazo_realiz.ToString(); lbl_plazo_com2.Text = cont_plazo_realiz.ToString();
            lbl_plazo_pen1.Text = cont_plazo_pen.ToString(); lbl_plazo_pen2.Text = cont_plazo_pen.ToString();

            lbl_reu_com1.Text = cont_reunion_realiz.ToString(); lbl_reu_com2.Text = cont_reunion_realiz.ToString();
            lbl_reu_pen1.Text = cont_reunion_pen.ToString(); lbl_reu_pen2.Text = cont_reunion_pen.ToString();

            lbl_tarea_com1.Text = cont_tarea_realiz.ToString(); lbl_tarea_com2.Text = cont_tarea_realiz.ToString();
            lbl_tarea_pen1.Text = cont_tarea_pen.ToString(); lbl_tarea_pen2.Text = cont_tarea_pen.ToString();


        }


        // Boton para genear todos los registros de esta semana
        private void btn_eshta_semana_Click(object sender, EventArgs e)
        {
            // variables de contadores negocio:
            cont_ganado = 0;
            cont_perdido = 0;
            cont_proceso = 0;
            // variables de montos de dinero del negocio:
            monto_ganado = 0;
            monto_perdido = 0;
            monto_proceso = 0;
            // variables para tareas
             cont_almuerzo_realiz = 0;  cont_almuerzo_pen = 0;
             cont_tarea_realiz = 0;  cont_tarea_pen = 0;
             cont_llamada_realiz = 0;  cont_llamada_pen = 0;
             cont_reunion_realiz = 0;  cont_reunion_pen = 0;
             cont_plazo_realiz = 0;  cont_plazo_pen = 0;

            // limpiar datatables de negocios ganados, perdidos y en proceso:
            dt_nego_ganado.Rows.Clear();
            dt_nego_perdido.Rows.Clear();
            dt_nego_proceso.Rows.Clear();
            


            nombre = calendario.GetDayOfWeek(fecha_hoy).ToString();
            string nombre_inicio = "";
            //DateTime fecha_inicio;

            switch (nombre)
            {

                case "Monday":
                    fecha_inicio = fecha_hoy.AddDays(0);
                    
                    break;

                case "Tuesday":
                    fecha_inicio = fecha_hoy.AddDays(-1);
                    break;

                case "Wednesday":
                    fecha_inicio = fecha_hoy.AddDays(-2);
                    break;

                case "Thursday":
                    fecha_inicio = fecha_hoy.AddDays(-3);
                    break;

                case "Friday":
                    fecha_inicio = fecha_hoy.AddDays(-4);
                    break;

                case "Saturday":
                    fecha_inicio = fecha_hoy.AddDays(-5);
                    break;

                case "Sunday":
                    fecha_inicio = fecha_hoy.AddDays(-6);
                    break;
                    

            }
            nombre_inicio = calendario.GetDayOfWeek(fecha_inicio).ToString();
            //MessageBox.Show("Toma de inicio de datos: " + nombre_inicio + ", " + fecha_inicio.ToString("yyyy-MM-dd") + " al " + nombre + ", " + fecha_hoy.ToString("yyyy-MM-dd"));


            // -------------------- Envio de datos a clase capadatos
            DataTable negocios =  CapaDatos.consultar_negocios(var_id_usuario,fecha_inicio.ToString("yyyy-MM-dd"),fecha_hoy.ToString("yyyy-MM-dd"));
            dgv_prueba.DataSource = negocios;
            // --------------------- CICLO PARA ELABORAR VISTA DE NEGOCIOS
            foreach (DataRow columna in negocios.Rows)
            {
                //cont_ganado = 0;
                //cont_perdido = 0;
                //cont_proceso = 0;
                    
                if (columna["status"].ToString() == "proceso" || columna["status"].ToString() == "Proceso")
                {
                    cont_proceso = cont_proceso + 1;
                    monto_proceso += Convert.ToDouble(columna["valor"]);


                    //Insercion de registros en  datatable hijo de negocios en proceso
                    DataRow row = dt_nego_proceso.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_proceso.Rows.Add(row);



                }
                else if (columna["status"].ToString() == "perdido" || columna["status"].ToString() == "Perdido")
                {
                    cont_perdido = cont_perdido + 1;
                    monto_perdido += Convert.ToDouble(columna["valor"]);



                    //Insercion de registros en  datatable hijo de negocios perdidos
                    DataRow row = dt_nego_perdido.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_perdido.Rows.Add(row);



                }
                else if (columna["status"].ToString() == "ganado" || columna["status"].ToString() == "Ganado")
                {
                    cont_ganado = cont_ganado + 1;
                    monto_ganado += Convert.ToDouble(columna["valor"]);


                    //Insercion de registros en  datatable hijo de negocios ganados
                    DataRow row = dt_nego_ganado.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();

                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_ganado.Rows.Add(row);



                }
            }

            titulo = "Rendimiento de " + cmb_usuarios.Text;
            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios_emp.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
            // ---------------------------------------

            // grid con los negocios ganados
            dgv_negocios_ganados.DataSource = dt_nego_ganado;
            dgv_nego_perdidos.DataSource = dt_nego_perdido;
            dgv_negos_proceso.DataSource = dt_nego_proceso;
            
            // etiquetas de procesos iniciados:
            lbl_neg_ini1.Text = cont_proceso.ToString();
            lbl_neg_ini2.Text = cont_proceso.ToString();
            // etiquetas de procesos perdidos:
            lbl_neg_perdido1.Text = cont_perdido.ToString();
            lbl_neg_perdido2.Text = cont_perdido.ToString();
            // etiquetas de procesos ganados:
            lbl_neg_ganado1.Text = cont_ganado.ToString();
            lbl_neg_ganado2.Text = cont_ganado.ToString();
            // etiquetas de montos ganados:
            lbl_monto_gan1.Text = monto_ganado.ToString("N2");
            lbl_monto_gan2.Text = monto_ganado.ToString("N2");
            //etiquetas de montos perdidos:
            lbl_monto_per1.Text = monto_perdido.ToString("N2");
            lbl_monto_per2.Text = monto_perdido.ToString("N2");
            //etiquetas de montos en proceso:
            lbl_monto_ini1.Text = monto_proceso.ToString("N2");
            lbl_monto_ini2.Text = monto_proceso.ToString("N2");

            foreach (DataRow colum in negocios.Rows)
            {   // columna con llamada
                if (colum["tipo"].ToString() == "Llamada")
                {

                    // recorrer columna de estado_tarea para determinar si la tarea esta pendiente o realizada
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_llamada_pen = cont_llamada_pen+1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_llamada_realiz = cont_llamada_realiz+1;
                    }
                }
                // columna con reunion
                else if (colum["tipo"].ToString() == "Reunion")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_reunion_pen = cont_reunion_pen + 1;
                        //MessageBox.Show("estoy en reunion pendiente");

                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        //MessageBox.Show("estoy en reunion realizado");

                        cont_reunion_realiz = cont_llamada_realiz + 1;
                    }
                }
                //// columna con tarea
                else if (colum["tipo"].ToString() == "Tarea")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_tarea_pen = cont_tarea_pen+1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_tarea_realiz = cont_tarea_realiz+1;
                    }
                }
                //// columna con plazo
                else if (colum["tipo"].ToString() == "Plazo")
                {


                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_plazo_pen = cont_plazo_pen+1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_plazo_realiz = cont_plazo_realiz+1;
                    }
                }
                //// columna con almuerzos
                else if(colum["tipo"].ToString() == "Almuerzo")
                {
                    //cont_almuerzo_pen = cont_almuerzo_pen+1;
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_almuerzo_pen = cont_almuerzo_pen+1;
                        //MessageBox.Show("estoy en almuerzo pendiente");
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_almuerzo_realiz = cont_almuerzo_realiz+1;
                        //MessageBox.Show("estoy en almuerzo realizado");
                    }
                }
            }
            // Etiquetas de tareas:
            lbl_almu_com1.Text = cont_almuerzo_realiz.ToString(); lbl_almu_com2.Text = cont_almuerzo_realiz.ToString();
            lbl_almu_pen1.Text = cont_almuerzo_pen.ToString(); lbl_almu_pen2.Text = cont_almuerzo_pen.ToString();

            lbl_llama_com1.Text = cont_llamada_realiz.ToString(); lbl_llama_com2.Text = cont_llamada_realiz.ToString();
            lbl_llama_pen1.Text = cont_llamada_pen.ToString(); lbl_llama_pen2.Text = cont_llamada_pen.ToString();

            lbl_plazo_com1.Text = cont_plazo_realiz.ToString(); lbl_plazo_com2.Text = cont_plazo_realiz.ToString();
            lbl_plazo_pen1.Text = cont_plazo_pen.ToString(); lbl_plazo_pen2.Text = cont_plazo_pen.ToString();

            lbl_reu_com1.Text = cont_reunion_realiz.ToString(); lbl_reu_com2.Text = cont_reunion_realiz.ToString();
            lbl_reu_pen1.Text = cont_reunion_pen.ToString(); lbl_reu_pen2.Text = cont_reunion_pen.ToString();

            lbl_tarea_com1.Text = cont_tarea_realiz.ToString(); lbl_tarea_com2.Text = cont_tarea_realiz.ToString();
            lbl_tarea_pen1.Text = cont_tarea_pen.ToString(); lbl_tarea_pen2.Text = cont_tarea_pen.ToString();



        }


        // boton para seleccionar los datos de la semana pasada
        private void btn_semana_pasada_Click(object sender, EventArgs e)
        {
            // variables de contadores negocio:
            cont_ganado = 0;
            cont_perdido = 0;
            cont_proceso = 0;
            // variables de montos de dinero del negocio:
            monto_ganado = 0;
            monto_perdido = 0;
            monto_proceso = 0;
            // variables para tareas
            cont_almuerzo_realiz = 0; cont_almuerzo_pen = 0;
            cont_tarea_realiz = 0; cont_tarea_pen = 0;
            cont_llamada_realiz = 0; cont_llamada_pen = 0;
            cont_reunion_realiz = 0; cont_reunion_pen = 0;
            cont_plazo_realiz = 0; cont_plazo_pen = 0;
            // limpiar datatables de negocios ganados, perdidos y en proceso:
            dt_nego_ganado.Rows.Clear();
            dt_nego_perdido.Rows.Clear();
            dt_nego_proceso.Rows.Clear();



            //DateTime fecha_inicio_mes = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day);
            //MessageBox.Show(fecha_inicio_mes.ToString("yyyy-MM-dd"));
            nombre = calendario.GetDayOfWeek(fecha_hoy).ToString();
            string nombre_inicio = "";
            //DateTime fecha_inicio;

            switch (nombre)
            {

                case "Monday":
                    fecha_inicio = fecha_hoy.AddDays(-7);
                    fecha_fin_semana = fecha_hoy.AddDays(-1);

                    break;

                case "Tuesday":
                    fecha_inicio = fecha_hoy.AddDays(-8);
                    fecha_fin_semana = fecha_hoy.AddDays(-2);

                    break;

                case "Wednesday":
                    fecha_inicio = fecha_hoy.AddDays(-9);
                    fecha_fin_semana = fecha_hoy.AddDays(-3);

                    break;

                case "Thursday":
                    fecha_inicio = fecha_hoy.AddDays(-10);
                    fecha_fin_semana = fecha_hoy.AddDays(-4);

                    break;

                case "Friday":
                    fecha_inicio = fecha_hoy.AddDays(-11);
                    fecha_fin_semana = fecha_hoy.AddDays(-5);

                    break;

                case "Saturday":
                    fecha_inicio = fecha_hoy.AddDays(-12);
                    fecha_fin_semana = fecha_hoy.AddDays(-6);

                    break;

                case "Sunday":
                    fecha_inicio = fecha_hoy.AddDays(-13);
                    fecha_fin_semana = fecha_hoy.AddDays(-7);

                    break;


            }
            nombre_inicio = calendario.GetDayOfWeek(fecha_inicio).ToString();
            //MessageBox.Show("Toma de inicio de datos: " + nombre_inicio + ", " + fecha_inicio.ToString("yyyy-MM-dd") + " al " + "Domingo" + ", " + fecha_fin_semana.ToString("yyyy-MM-dd"));



            // -------------------- Envio de datos a clase capadatos
            DataTable negocios = CapaDatos.consultar_negocios(var_id_usuario, fecha_inicio.ToString("yyyy-MM-dd"), fecha_fin_semana.ToString("yyyy-MM-dd"));
            dgv_prueba.DataSource = negocios;
            // --------------------- CICLO PARA ELABORAR VISTA DE NEGOCIOS
            foreach (DataRow columna in negocios.Rows)
            {
                //cont_ganado = 0;
                //cont_perdido = 0;
                //cont_proceso = 0;

                if (columna["status"].ToString() == "proceso" || columna["status"].ToString() == "Proceso")
                {
                    cont_proceso = cont_proceso + 1;
                    monto_proceso += Convert.ToDouble(columna["valor"]);

                    DataRow row = dt_nego_proceso.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_proceso.Rows.Add(row);

                }
                else if (columna["status"].ToString() == "perdido" || columna["status"].ToString() == "Perdido")
                {
                    cont_perdido = cont_perdido + 1;
                    monto_perdido += Convert.ToDouble(columna["valor"]);

                    //Insercion de registros en  datatable hijo de negocios perdidos
                    DataRow row = dt_nego_perdido.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_perdido.Rows.Add(row);
                }
                else if (columna["status"].ToString() == "ganado" || columna["status"].ToString() == "Ganado")
                {
                    cont_ganado = cont_ganado + 1;
                    monto_ganado += Convert.ToDouble(columna["valor"]);


                    //Insercion de registros en  datatable hijo de negocios ganados
                    DataRow row = dt_nego_ganado.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();

                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_ganado.Rows.Add(row);
                }
            }

            titulo = "Rendimiento de " + cmb_usuarios.Text;
            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios_emp.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
            // ---------------------------------------

            // etiquetas de procesos iniciados:
            lbl_neg_ini1.Text = cont_proceso.ToString();
            lbl_neg_ini2.Text = cont_proceso.ToString();
            // etiquetas de procesos perdidos:
            lbl_neg_perdido1.Text = cont_perdido.ToString();
            lbl_neg_perdido2.Text = cont_perdido.ToString();
            // etiquetas de procesos ganados:
            lbl_neg_ganado1.Text = cont_ganado.ToString();
            lbl_neg_ganado2.Text = cont_ganado.ToString();
            // etiquetas de montos ganados:
            lbl_monto_gan1.Text = monto_ganado.ToString("N2");
            lbl_monto_gan2.Text = monto_ganado.ToString("N2");
            //etiquetas de montos perdidos:
            lbl_monto_per1.Text = monto_perdido.ToString("N2");
            lbl_monto_per2.Text = monto_perdido.ToString("N2");
            //etiquetas de montos en proceso:
            lbl_monto_ini1.Text = monto_proceso.ToString("N2");
            lbl_monto_ini2.Text = monto_proceso.ToString("N2");

            foreach (DataRow colum in negocios.Rows)
            {   // columna con llamada
                if (colum["tipo"].ToString() == "Llamada")
                {

                    // recorrer columna de estado_tarea para determinar si la tarea esta pendiente o realizada
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_llamada_pen = cont_llamada_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_llamada_realiz = cont_llamada_realiz + 1;
                    }
                }
                // columna con reunion
                else if (colum["tipo"].ToString() == "Reunion")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_reunion_pen = cont_reunion_pen + 1;
                        //MessageBox.Show("estoy en reunion pendiente");

                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        //MessageBox.Show("estoy en reunion realizado");

                        cont_reunion_realiz = cont_llamada_realiz + 1;
                    }
                }
                //// columna con tarea
                else if (colum["tipo"].ToString() == "Tarea")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_tarea_pen = cont_tarea_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_tarea_realiz = cont_tarea_realiz + 1;
                    }
                }
                //// columna con plazo
                else if (colum["tipo"].ToString() == "Plazo")
                {


                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_plazo_pen = cont_plazo_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_plazo_realiz = cont_plazo_realiz + 1;
                    }
                }
                //// columna con almuerzos
                else if (colum["tipo"].ToString() == "Almuerzo")
                {
                    //cont_almuerzo_pen = cont_almuerzo_pen+1;
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_almuerzo_pen = cont_almuerzo_pen + 1;
                        //MessageBox.Show("estoy en almuerzo pendiente");
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_almuerzo_realiz = cont_almuerzo_realiz + 1;
                        //MessageBox.Show("estoy en almuerzo realizado");
                    }
                }
            }
            // Etiquetas de tareas:
            lbl_almu_com1.Text = cont_almuerzo_realiz.ToString(); lbl_almu_com2.Text = cont_almuerzo_realiz.ToString();
            lbl_almu_pen1.Text = cont_almuerzo_pen.ToString(); lbl_almu_pen2.Text = cont_almuerzo_pen.ToString();

            lbl_llama_com1.Text = cont_llamada_realiz.ToString(); lbl_llama_com2.Text = cont_llamada_realiz.ToString();
            lbl_llama_pen1.Text = cont_llamada_pen.ToString(); lbl_llama_pen2.Text = cont_llamada_pen.ToString();

            lbl_plazo_com1.Text = cont_plazo_realiz.ToString(); lbl_plazo_com2.Text = cont_plazo_realiz.ToString();
            lbl_plazo_pen1.Text = cont_plazo_pen.ToString(); lbl_plazo_pen2.Text = cont_plazo_pen.ToString();

            lbl_reu_com1.Text = cont_reunion_realiz.ToString(); lbl_reu_com2.Text = cont_reunion_realiz.ToString();
            lbl_reu_pen1.Text = cont_reunion_pen.ToString(); lbl_reu_pen2.Text = cont_reunion_pen.ToString();

            lbl_tarea_com1.Text = cont_tarea_realiz.ToString(); lbl_tarea_com2.Text = cont_tarea_realiz.ToString();
            lbl_tarea_pen1.Text = cont_tarea_pen.ToString(); lbl_tarea_pen2.Text = cont_tarea_pen.ToString();


        }


        // ----------------------------------------------------------------------------------------------------------------------------------------------------

        // boton para seleccionar los datos de este mes

        private  void btn_mensual_Click(object sender, EventArgs e)
        {
            
            DateTime fecha_inicio_mes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            string nombre_inicio_mes = calendario.GetDayOfWeek(fecha_inicio_mes).ToString(); ;
            //MessageBox.Show("Toma de inicio de datos: " + nombre_inicio_mes + ", " + fecha_inicio_mes.ToString("yyyy-MM-dd") + " al " + nombre + ", " + fecha_hoy.ToString("yyyy-MM-dd"));

            //-------------------------------------------------------------------------------------------- Busqueda de negocios y tareas correspondientes:
            // variables de contadores negocio:
            cont_ganado = 0;
            cont_perdido = 0;
            cont_proceso = 0;
            // variables de montos de dinero del negocio:
            monto_ganado = 0;
            monto_perdido = 0;
            monto_proceso = 0;
            // variables para tareas
            cont_almuerzo_realiz = 0; cont_almuerzo_pen = 0;
            cont_tarea_realiz = 0; cont_tarea_pen = 0;
            cont_llamada_realiz = 0; cont_llamada_pen = 0;
            cont_reunion_realiz = 0; cont_reunion_pen = 0;
            cont_plazo_realiz = 0; cont_plazo_pen = 0;
            // limpiar datatables de negocios ganados, perdidos y en proceso:
            dt_nego_ganado.Rows.Clear();
            dt_nego_perdido.Rows.Clear();
            dt_nego_proceso.Rows.Clear();




            // -------------------- Envio de datos a clase capadatos
            DataTable negocios = CapaDatos.consultar_negocios(var_id_usuario, fecha_inicio_mes.ToString("yyyy-MM-dd"), fecha_hoy.ToString("yyyy-MM-dd"));
            dgv_prueba.DataSource = negocios;
            // --------------------- CICLO PARA ELABORAR VISTA DE NEGOCIOS
            foreach (DataRow columna in negocios.Rows)
            {
                //cont_ganado = 0;
                //cont_perdido = 0;
                //cont_proceso = 0;

                if (columna["status"].ToString() == "proceso" || columna["status"].ToString() == "Proceso")
                {
                    cont_proceso = cont_proceso + 1;
                    monto_proceso += Convert.ToDouble(columna["valor"]);


                    DataRow row = dt_nego_proceso.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_proceso.Rows.Add(row);
                }
                else if (columna["status"].ToString() == "perdido" || columna["status"].ToString() == "Perdido")
                {
                    cont_perdido = cont_perdido + 1;
                    monto_perdido += Convert.ToDouble(columna["valor"]);

                    //Insercion de registros en  datatable hijo de negocios perdidos
                    DataRow row = dt_nego_perdido.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_perdido.Rows.Add(row);

                }
                else if (columna["status"].ToString() == "ganado" || columna["status"].ToString() == "Ganado")
                {
                    cont_ganado = cont_ganado + 1;
                    monto_ganado += Convert.ToDouble(columna["valor"]);


                    //Insercion de registros en  datatable hijo de negocios ganados
                    DataRow row = dt_nego_ganado.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();

                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_ganado.Rows.Add(row);
                }
            }

            titulo = "Rendimiento de " + cmb_usuarios.Text;
            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios_emp.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
            // ---------------------------------------

            // etiquetas de procesos iniciados:
            lbl_neg_ini1.Text = cont_proceso.ToString();
            lbl_neg_ini2.Text = cont_proceso.ToString();
            // etiquetas de procesos perdidos:
            lbl_neg_perdido1.Text = cont_perdido.ToString();
            lbl_neg_perdido2.Text = cont_perdido.ToString();
            // etiquetas de procesos ganados:
            lbl_neg_ganado1.Text = cont_ganado.ToString();
            lbl_neg_ganado2.Text = cont_ganado.ToString();
            // etiquetas de montos ganados:
            lbl_monto_gan1.Text = monto_ganado.ToString("N2");
            lbl_monto_gan2.Text = monto_ganado.ToString("N2");
            //etiquetas de montos perdidos:
            lbl_monto_per1.Text = monto_perdido.ToString("N2");
            lbl_monto_per2.Text = monto_perdido.ToString("N2");
            //etiquetas de montos en proceso:
            lbl_monto_ini1.Text = monto_proceso.ToString("N2");
            lbl_monto_ini2.Text = monto_proceso.ToString("N2");

            foreach (DataRow colum in negocios.Rows)
            {   // columna con llamada
                if (colum["tipo"].ToString() == "Llamada")
                {

                    // recorrer columna de estado_tarea para determinar si la tarea esta pendiente o realizada
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_llamada_pen = cont_llamada_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_llamada_realiz = cont_llamada_realiz + 1;
                    }
                }
                // columna con reunion
                else if (colum["tipo"].ToString() == "Reunion")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_reunion_pen = cont_reunion_pen + 1;
                        //MessageBox.Show("estoy en reunion pendiente");

                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        //MessageBox.Show("estoy en reunion realizado");

                        cont_reunion_realiz = cont_llamada_realiz + 1;
                    }
                }
                //// columna con tarea
                else if (colum["tipo"].ToString() == "Tarea")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_tarea_pen = cont_tarea_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_tarea_realiz = cont_tarea_realiz + 1;
                    }
                }
                //// columna con plazo
                else if (colum["tipo"].ToString() == "Plazo")
                {


                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_plazo_pen = cont_plazo_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_plazo_realiz = cont_plazo_realiz + 1;
                    }
                }
                //// columna con almuerzos
                else if (colum["tipo"].ToString() == "Almuerzo")
                {
                    //cont_almuerzo_pen = cont_almuerzo_pen+1;
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_almuerzo_pen = cont_almuerzo_pen + 1;
                        //MessageBox.Show("estoy en almuerzo pendiente");
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_almuerzo_realiz = cont_almuerzo_realiz + 1;
                        //MessageBox.Show("estoy en almuerzo realizado");
                    }
                }
            }
            // Etiquetas de tareas:
            lbl_almu_com1.Text = cont_almuerzo_realiz.ToString(); lbl_almu_com2.Text = cont_almuerzo_realiz.ToString();
            lbl_almu_pen1.Text = cont_almuerzo_pen.ToString(); lbl_almu_pen2.Text = cont_almuerzo_pen.ToString();

            lbl_llama_com1.Text = cont_llamada_realiz.ToString(); lbl_llama_com2.Text = cont_llamada_realiz.ToString();
            lbl_llama_pen1.Text = cont_llamada_pen.ToString(); lbl_llama_pen2.Text = cont_llamada_pen.ToString();

            lbl_plazo_com1.Text = cont_plazo_realiz.ToString(); lbl_plazo_com2.Text = cont_plazo_realiz.ToString();
            lbl_plazo_pen1.Text = cont_plazo_pen.ToString(); lbl_plazo_pen2.Text = cont_plazo_pen.ToString();

            lbl_reu_com1.Text = cont_reunion_realiz.ToString(); lbl_reu_com2.Text = cont_reunion_realiz.ToString();
            lbl_reu_pen1.Text = cont_reunion_pen.ToString(); lbl_reu_pen2.Text = cont_reunion_pen.ToString();

            lbl_tarea_com1.Text = cont_tarea_realiz.ToString(); lbl_tarea_com2.Text = cont_tarea_realiz.ToString();
            lbl_tarea_pen1.Text = cont_tarea_pen.ToString(); lbl_tarea_pen2.Text = cont_tarea_pen.ToString();



        }

        // boton para seleccionar los datos del mes anterior
        private void btn_mes_pasado_Click(object sender, EventArgs e)
        {
            DateTime fecha_referencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // fecha de inicio de este mes
            DateTime fecha_inicio_mes = fecha_referencia.AddMonths(-1); // fecha de inicio del mes anterior
            DateTime fecha_fin_mes = fecha_inicio_mes.AddMonths(1).AddDays(-1); // fecha de fin de mes anterior
            //MessageBox.Show("inicio: "+fecha_inicio_mes.ToString("yyy-MM-dd")+" fin: "+fecha_fin_mes.ToString("yyy-MM-dd"));



            //-------------------------------------------------------------------------------------------- Busqueda de negocios y tareas correspondientes:
            // variables de contadores negocio:
            cont_ganado = 0;
            cont_perdido = 0;
            cont_proceso = 0;
            // variables de montos de dinero del negocio:
            monto_ganado = 0;
            monto_perdido = 0;
            monto_proceso = 0;
            // variables para tareas
            cont_almuerzo_realiz = 0; cont_almuerzo_pen = 0;
            cont_tarea_realiz = 0; cont_tarea_pen = 0;
            cont_llamada_realiz = 0; cont_llamada_pen = 0;
            cont_reunion_realiz = 0; cont_reunion_pen = 0;
            cont_plazo_realiz = 0; cont_plazo_pen = 0;
            // limpiar datatables de negocios ganados, perdidos y en proceso:
            dt_nego_ganado.Rows.Clear();
            dt_nego_perdido.Rows.Clear();
            dt_nego_proceso.Rows.Clear();



            // -------------------- Envio de datos a clase capadatos
            DataTable negocios = CapaDatos.consultar_negocios(var_id_usuario, fecha_inicio_mes.ToString("yyyy-MM-dd"), fecha_fin_mes.ToString("yyyy-MM-dd"));
            dgv_prueba.DataSource = negocios;
            // --------------------- CICLO PARA ELABORAR VISTA DE NEGOCIOS
            foreach (DataRow columna in negocios.Rows)
            {
                //cont_ganado = 0;
                //cont_perdido = 0;
                //cont_proceso = 0;

                if (columna["status"].ToString() == "proceso" || columna["status"].ToString() == "Proceso")
                {
                    cont_proceso = cont_proceso + 1;
                    monto_proceso += Convert.ToDouble(columna["valor"]);

                    DataRow row = dt_nego_proceso.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_proceso.Rows.Add(row);
                }
                else if (columna["status"].ToString() == "perdido" || columna["status"].ToString() == "Perdido")
                {
                    cont_perdido = cont_perdido + 1;
                    monto_perdido += Convert.ToDouble(columna["valor"]);

                    //Insercion de registros en  datatable hijo de negocios perdidos
                    DataRow row = dt_nego_perdido.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();
                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_perdido.Rows.Add(row);
                }
                else if (columna["status"].ToString() == "ganado" || columna["status"].ToString() == "Ganado")
                {
                    cont_ganado = cont_ganado + 1;
                    monto_ganado += Convert.ToDouble(columna["valor"]);

                    //Insercion de registros en  datatable hijo de negocios ganados
                    DataRow row = dt_nego_ganado.NewRow();

                    row["Titulo"] = columna["titulo"].ToString();
                    row["Categoria"] = columna["nombre_cat"].ToString();
                    row["Tipo de tarea"] = columna["tipo"].ToString();

                    row["Usuario"] = columna["nombres"].ToString();
                    row["Apellidos"] = columna["apellidos"].ToString();
                    row["Empresa"] = columna["nombre"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    dt_nego_ganado.Rows.Add(row);
                }
            }

            titulo = "Rendimiento de " +cmb_usuarios.Text;
            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios_emp.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
            // ---------------------------------------


            // etiquetas de procesos iniciados:
            lbl_neg_ini1.Text = cont_proceso.ToString();
            lbl_neg_ini2.Text = cont_proceso.ToString();
            // etiquetas de procesos perdidos:
            lbl_neg_perdido1.Text = cont_perdido.ToString();
            lbl_neg_perdido2.Text = cont_perdido.ToString();
            // etiquetas de procesos ganados:
            lbl_neg_ganado1.Text = cont_ganado.ToString();
            lbl_neg_ganado2.Text = cont_ganado.ToString();
            // etiquetas de montos ganados:
            lbl_monto_gan1.Text = monto_ganado.ToString("N2");
            lbl_monto_gan2.Text = monto_ganado.ToString("N2");
            //etiquetas de montos perdidos:
            lbl_monto_per1.Text = monto_perdido.ToString("N2");
            lbl_monto_per2.Text = monto_perdido.ToString("N2");
            //etiquetas de montos en proceso:
            lbl_monto_ini1.Text = monto_proceso.ToString("N2");
            lbl_monto_ini2.Text = monto_proceso.ToString("N2");

            foreach (DataRow colum in negocios.Rows)
            {   // columna con llamada
                if (colum["tipo"].ToString() == "Llamada")
                {

                    // recorrer columna de estado_tarea para determinar si la tarea esta pendiente o realizada
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_llamada_pen = cont_llamada_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_llamada_realiz = cont_llamada_realiz + 1;
                    }
                }
                // columna con reunion
                else if (colum["tipo"].ToString() == "Reunion")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_reunion_pen = cont_reunion_pen + 1;
                        //MessageBox.Show("estoy en reunion pendiente");

                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        //MessageBox.Show("estoy en reunion realizado");

                        cont_reunion_realiz = cont_llamada_realiz + 1;
                    }
                }
                //// columna con tarea
                else if (colum["tipo"].ToString() == "Tarea")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_tarea_pen = cont_tarea_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_tarea_realiz = cont_tarea_realiz + 1;
                    }
                }
                //// columna con plazo
                else if (colum["tipo"].ToString() == "Plazo")
                {


                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_plazo_pen = cont_plazo_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_plazo_realiz = cont_plazo_realiz + 1;
                    }
                }
                //// columna con almuerzos
                else if (colum["tipo"].ToString() == "Almuerzo")
                {
                    //cont_almuerzo_pen = cont_almuerzo_pen+1;
                    if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                    {
                        cont_almuerzo_pen = cont_almuerzo_pen + 1;
                        //MessageBox.Show("estoy en almuerzo pendiente");
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                    {
                        cont_almuerzo_realiz = cont_almuerzo_realiz + 1;
                        //MessageBox.Show("estoy en almuerzo realizado");
                    }
                }
            }
            // Etiquetas de tareas:
            lbl_almu_com1.Text = cont_almuerzo_realiz.ToString(); lbl_almu_com2.Text = cont_almuerzo_realiz.ToString();
            lbl_almu_pen1.Text = cont_almuerzo_pen.ToString(); lbl_almu_pen2.Text = cont_almuerzo_pen.ToString();

            lbl_llama_com1.Text = cont_llamada_realiz.ToString(); lbl_llama_com2.Text = cont_llamada_realiz.ToString();
            lbl_llama_pen1.Text = cont_llamada_pen.ToString(); lbl_llama_pen2.Text = cont_llamada_pen.ToString();

            lbl_plazo_com1.Text = cont_plazo_realiz.ToString(); lbl_plazo_com2.Text = cont_plazo_realiz.ToString();
            lbl_plazo_pen1.Text = cont_plazo_pen.ToString(); lbl_plazo_pen2.Text = cont_plazo_pen.ToString();

            lbl_reu_com1.Text = cont_reunion_realiz.ToString(); lbl_reu_com2.Text = cont_reunion_realiz.ToString();
            lbl_reu_pen1.Text = cont_reunion_pen.ToString(); lbl_reu_pen2.Text = cont_reunion_pen.ToString();

            lbl_tarea_com1.Text = cont_tarea_realiz.ToString(); lbl_tarea_com2.Text = cont_tarea_realiz.ToString();
            lbl_tarea_pen1.Text = cont_tarea_pen.ToString(); lbl_tarea_pen2.Text = cont_tarea_pen.ToString();

        }

        private void btn_periodo_personalizado_Click(object sender, EventArgs e)
        {
            frm_busqueda_fecha_personalizada busqueda = new frm_busqueda_fecha_personalizada();
            DialogResult res = busqueda.ShowDialog();

            if (res == DialogResult.OK)
            {
                var_fecha_perz_ini = busqueda.fecha_personaliz_ini;
                var_fecha_perz_fin = busqueda.fecha_personaliz_fin;


                //-------------------------------------------------------------------------------------------- Busqueda de negocios y tareas correspondientes:
                // variables de contadores negocio:
                cont_ganado = 0;
                cont_perdido = 0;
                cont_proceso = 0;
                // variables de montos de dinero del negocio:
                monto_ganado = 0;
                monto_perdido = 0;
                monto_proceso = 0;
                // variables para tareas
                cont_almuerzo_realiz = 0; cont_almuerzo_pen = 0;
                cont_tarea_realiz = 0; cont_tarea_pen = 0;
                cont_llamada_realiz = 0; cont_llamada_pen = 0;
                cont_reunion_realiz = 0; cont_reunion_pen = 0;
                cont_plazo_realiz = 0; cont_plazo_pen = 0;
                // limpiar datatables de negocios ganados, perdidos y en proceso:
                dt_nego_ganado.Rows.Clear();
                dt_nego_perdido.Rows.Clear();
                dt_nego_proceso.Rows.Clear();



                // -------------------- Envio de datos a clase capadatos
                DataTable negocios = CapaDatos.consultar_negocios(var_id_usuario, var_fecha_perz_ini, var_fecha_perz_fin);
                dgv_prueba.DataSource = negocios;
                // --------------------- CICLO PARA ELABORAR VISTA DE NEGOCIOS
                foreach (DataRow columna in negocios.Rows)
                {
                    //cont_ganado = 0;
                    //cont_perdido = 0;
                    //cont_proceso = 0;

                    if (columna["status"].ToString() == "proceso" || columna["status"].ToString() == "Proceso")
                    {
                        cont_proceso = cont_proceso + 1;
                        monto_proceso += Convert.ToDouble(columna["valor"]);

                        DataRow row = dt_nego_proceso.NewRow();

                        row["Titulo"] = columna["titulo"].ToString();
                        row["Categoria"] = columna["nombre_cat"].ToString();
                        row["Tipo de tarea"] = columna["tipo"].ToString();
                        row["Usuario"] = columna["nombres"].ToString();
                        row["Apellidos"] = columna["apellidos"].ToString();
                        row["Empresa"] = columna["nombre"].ToString();
                        row["Monto"] = columna["valor"].ToString();
                        dt_nego_proceso.Rows.Add(row);

                    }
                    else if (columna["status"].ToString() == "perdido" || columna["status"].ToString() == "Perdido")
                    {
                        cont_perdido = cont_perdido + 1;
                        monto_perdido += Convert.ToDouble(columna["valor"]);


                        //Insercion de registros en  datatable hijo de negocios perdidos
                        DataRow row = dt_nego_perdido.NewRow();

                        row["Titulo"] = columna["titulo"].ToString();
                        row["Categoria"] = columna["nombre_cat"].ToString();
                        row["Tipo de tarea"] = columna["tipo"].ToString();
                        row["Usuario"] = columna["nombres"].ToString();
                        row["Apellidos"] = columna["apellidos"].ToString();
                        row["Empresa"] = columna["nombre"].ToString();
                        row["Monto"] = columna["valor"].ToString();
                        dt_nego_perdido.Rows.Add(row);
                    }
                    else if (columna["status"].ToString() == "ganado" || columna["status"].ToString() == "Ganado")
                    {
                        cont_ganado = cont_ganado + 1;
                        monto_ganado += Convert.ToDouble(columna["valor"]);


                        //Insercion de registros en  datatable hijo de negocios ganados
                        DataRow row = dt_nego_ganado.NewRow();

                        row["Titulo"] = columna["titulo"].ToString();
                        row["Categoria"] = columna["nombre_cat"].ToString();
                        row["Tipo de tarea"] = columna["tipo"].ToString();

                        row["Usuario"] = columna["nombres"].ToString();
                        row["Apellidos"] = columna["apellidos"].ToString();
                        row["Empresa"] = columna["nombre"].ToString();
                        row["Monto"] = columna["valor"].ToString();
                        dt_nego_ganado.Rows.Add(row);
                    }
                }

                titulo = "Rendimiento de " + cmb_usuarios.Text;
                // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
                ctc_negocios_emp.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
                // ---------------------------------------

                // etiquetas de procesos iniciados:
                lbl_neg_ini1.Text = cont_proceso.ToString();
                lbl_neg_ini2.Text = cont_proceso.ToString();
                // etiquetas de procesos perdidos:
                lbl_neg_perdido1.Text = cont_perdido.ToString();
                lbl_neg_perdido2.Text = cont_perdido.ToString();
                // etiquetas de procesos ganados:
                lbl_neg_ganado1.Text = cont_ganado.ToString();
                lbl_neg_ganado2.Text = cont_ganado.ToString();
                // etiquetas de montos ganados:
                lbl_monto_gan1.Text = monto_ganado.ToString("N2");
                lbl_monto_gan2.Text = monto_ganado.ToString("N2");
                //etiquetas de montos perdidos:
                lbl_monto_per1.Text = monto_perdido.ToString("N2");
                lbl_monto_per2.Text = monto_perdido.ToString("N2");
                //etiquetas de montos en proceso:
                lbl_monto_ini1.Text = monto_proceso.ToString("N2");
                lbl_monto_ini2.Text = monto_proceso.ToString("N2");

                foreach (DataRow colum in negocios.Rows)
                {   // columna con llamada
                    if (colum["tipo"].ToString() == "Llamada")
                    {

                        // recorrer columna de estado_tarea para determinar si la tarea esta pendiente o realizada
                        if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                        {
                            cont_llamada_pen = cont_llamada_pen + 1;
                        }
                        else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                        {
                            cont_llamada_realiz = cont_llamada_realiz + 1;
                        }
                    }
                    // columna con reunion
                    else if (colum["tipo"].ToString() == "Reunion")
                    {

                        if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                        {
                            cont_reunion_pen = cont_reunion_pen + 1;
                            //MessageBox.Show("estoy en reunion pendiente");

                        }
                        else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                        {
                            //MessageBox.Show("estoy en reunion realizado");

                            cont_reunion_realiz = cont_llamada_realiz + 1;
                        }
                    }
                    //// columna con tarea
                    else if (colum["tipo"].ToString() == "Tarea")
                    {

                        if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                        {
                            cont_tarea_pen = cont_tarea_pen + 1;
                        }
                        else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                        {
                            cont_tarea_realiz = cont_tarea_realiz + 1;
                        }
                    }
                    //// columna con plazo
                    else if (colum["tipo"].ToString() == "Plazo")
                    {


                        if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                        {
                            cont_plazo_pen = cont_plazo_pen + 1;
                        }
                        else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                        {
                            cont_plazo_realiz = cont_plazo_realiz + 1;
                        }
                    }
                    //// columna con almuerzos
                    else if (colum["tipo"].ToString() == "Almuerzo")
                    {
                        //cont_almuerzo_pen = cont_almuerzo_pen+1;
                        if (colum["estado_tarea"].ToString() == "pendiente" || colum["estado_tarea"].ToString() == "Pendiente")
                        {
                            cont_almuerzo_pen = cont_almuerzo_pen + 1;
                            //MessageBox.Show("estoy en almuerzo pendiente");
                        }
                        else if (colum["estado_tarea"].ToString() == "realizado" || colum["estado_tarea"].ToString() == "Realizado")
                        {
                            cont_almuerzo_realiz = cont_almuerzo_realiz + 1;
                            //MessageBox.Show("estoy en almuerzo realizado");
                        }
                    }
                }
                // Etiquetas de tareas:
                lbl_almu_com1.Text = cont_almuerzo_realiz.ToString(); lbl_almu_com2.Text = cont_almuerzo_realiz.ToString();
                lbl_almu_pen1.Text = cont_almuerzo_pen.ToString(); lbl_almu_pen2.Text = cont_almuerzo_pen.ToString();

                lbl_llama_com1.Text = cont_llamada_realiz.ToString(); lbl_llama_com2.Text = cont_llamada_realiz.ToString();
                lbl_llama_pen1.Text = cont_llamada_pen.ToString(); lbl_llama_pen2.Text = cont_llamada_pen.ToString();

                lbl_plazo_com1.Text = cont_plazo_realiz.ToString(); lbl_plazo_com2.Text = cont_plazo_realiz.ToString();
                lbl_plazo_pen1.Text = cont_plazo_pen.ToString(); lbl_plazo_pen2.Text = cont_plazo_pen.ToString();

                lbl_reu_com1.Text = cont_reunion_realiz.ToString(); lbl_reu_com2.Text = cont_reunion_realiz.ToString();
                lbl_reu_pen1.Text = cont_reunion_pen.ToString(); lbl_reu_pen2.Text = cont_reunion_pen.ToString();

                lbl_tarea_com1.Text = cont_tarea_realiz.ToString(); lbl_tarea_com2.Text = cont_tarea_realiz.ToString();
                lbl_tarea_pen1.Text = cont_tarea_pen.ToString(); lbl_tarea_pen2.Text = cont_tarea_pen.ToString();



            }

        }



        // ------------------------------------------------------------ Area para mostrar detalle de negocios al darle clic sobe la etiqueta de negocios (ganados,perdidos,en proceso)

        // etiqueta que muestra formulario con descripcion de negocios ganados
        private void lbl_negocios_ganados_Click(object sender, EventArgs e)
        {
            string titulo = "Negocios Ganados";

            frm_estadistica_negocio_descripcion negocio_descripcion = new frm_estadistica_negocio_descripcion();
            negocio_descripcion.Show();
            negocio_descripcion.lbl_titulo.Text = titulo;
            negocio_descripcion.dgv_detalle_negocio.DataSource = dt_nego_ganado;



        }
        // etiqueta que muestra formulario con descripcion de negocios perdidos

        private void lbl_negocios_perdidos_Click(object sender, EventArgs e)
        {
            string titulo = "Negocios Perdidos";

            frm_estadistica_negocio_descripcion negocio_descripcion = new frm_estadistica_negocio_descripcion();
            negocio_descripcion.Show();
            negocio_descripcion.lbl_titulo.Text = titulo;
            negocio_descripcion.dgv_detalle_negocio.DataSource = dt_nego_perdido;
        }

        // etiqueta que muestra formulario con descripcion de negocios en proceso

        private void lbl_negocios_iniciados_Click(object sender, EventArgs e)
        {
            string titulo = "Negocios Perdidos";

            frm_estadistica_negocio_descripcion negocio_descripcion = new frm_estadistica_negocio_descripcion();
            negocio_descripcion.Show();
            negocio_descripcion.lbl_titulo.Text = titulo;
            negocio_descripcion.dgv_detalle_negocio.DataSource = dt_nego_proceso;
        }
    }
}