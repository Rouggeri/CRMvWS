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
using DevExpress.XtraCharts;


namespace crm
{
    public partial class frm_pronostico : DevExpress.XtraEditors.XtraForm
    {
        public frm_pronostico()
        {
            InitializeComponent();
        }
        // Variables globales
        CapaDatosPersonas CapaDatos = new CapaDatosPersonas();

        // funcion para llamar al formulario de nueva meta
        frm_meta_mantenimiento metas = new frm_meta_mantenimiento();
      

        // Funcion que hace capaz la creacion de un evento via codigo:
        public delegate void EventHandler(Object sender, EventArgs e);

        int num_filas_dt; // variable de numero de filas del dt_negos_importantes
        int num_filas_dt_hoy; // variable de numero de filas del dt_negos_hoy
        int num_filas_dt_acts; // variable de numero de filas del dt_actualizaciones



        DataTable dt_negos_importantes = new DataTable(); // tendra la consulta de Consulta_Negocios_importantes_proyecciones
        public DataTable dt_negos_importantes_hijo = new DataTable(); // dt que contiene una parte del dt padre
        DataTable dt_negos_hoy = new DataTable(); // Datatable para contener los negocios del dia de hoy
        DataTable dt_actualizaciones = new DataTable(); // dt que contiene las actualizaciones mas recientes de asignacion de trabajo
        DataTable dt_negos_mes = new DataTable(); // dt que contiene todos los negocios del mes
        DataTable dt_nego_pro = new DataTable();// dt que contiene todos los negocios del mes en proceso
        DataTable dt_nego_gana = new DataTable();// dt que contiene todos los negocios del mes ganados
        DataTable dt_nego_per = new DataTable();// dt que contiene todos los negocios del mes perdidos
        DataTable dt_negos_ganados = new DataTable();
        DataTable dt_negos_perdidos = new DataTable();
        DataTable dt_negos_proceso = new DataTable();
        DataTable dt_meta = new DataTable(); // contiene el valor ultimo asignado de la meta

        // VARIABLES DE TIEMPO:
        DateTime hoy = DateTime.Today;  //fecha del dia de hoy
        DateTime fecha_inicio_mes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // RETORNA FECHA DE INICIO DE MES
        ChartControl grafica_principal = new ChartControl(); // grafica en la cual se va a trabajar


        // Variables de control para columna acumulativa de graficacion de negocios ganados, perdidos y en proceso
        int control = 0;
        int control_gana = 0;
        int control_perd = 0;
        // Variableas para totales de negocios en dinero, de grafica
        double total_perdidas;
        double total_ganancias;
        double total_negocios;

        // Variable para medir meta del usuario
        double meta_mes;





        // Funcion que se llamará al darle click en el titulo de una tarea, para ver detalle
        private void evento_tareas_importantes(object sender, EventArgs e)
        {
            dt_negos_importantes_hijo.Clear(); // Limpieza de datagrid hijo de tareas importantes.
            //// Llamada al formulario frm_detalle_tareas_importantes
            //frm_detalle_tareas_importantes detalle_tareas = new frm_detalle_tareas_importantes();
            //detalle_tareas.Show();

            Label clickedLabel = sender as Label; // sirve para tomar la cadena que manda el sender del label clickeado, cuando se crea con codigo el label
            string texto = clickedLabel.Text; // extraemos la cadena de texto del label


            //Recorrido en busca de la tarea seleccionda:
            foreach (DataRow columna in dt_negos_importantes.Rows)
            {

                if (columna["titulo"].ToString() == texto)
                {
                    DataRow row = dt_negos_importantes_hijo.NewRow();

                    row["Empresa"] = columna["nombre"].ToString();
                    row["Nombre1_clt"] = columna["nombres1"].ToString();
                    row["Nombre2_clt"] = columna["apellidos1"].ToString();
                    row["Fecha_cierre"] = columna["fecha_establecida"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    row["Nombre1_resp"] = columna["nombres"].ToString();
                    row["Nombre2_resp"] = columna["apellidos"].ToString();
                    row["Titulo"] = columna["titulo"].ToString();


                    dt_negos_importantes_hijo.Rows.Add(row);
                }
                //dgv_hijo.DataSource = dt_negos_importantes_hijo;

            }
            dgv_hijo.DataSource = dt_negos_importantes_hijo;
            // Llamada al formulario frm_detalle_tareas_importantes
            frm_detalle_tareas_importantes detalle_tareas = new frm_detalle_tareas_importantes();
            detalle_tareas.dt_hijo = dt_negos_importantes_hijo;
            detalle_tareas.Show();
        }
        // **********************************************************************



        // Funcion que se llamará al darle click en el titulo de una tarea, para ver detalle
        private void evento_tareas_hoy(object sender, EventArgs e)
        {
            dt_negos_importantes_hijo.Clear(); // Limpieza de datagrid hijo de tareas importantes.

            Label clickedLabel = sender as Label; // sirve para tomar la cadena que manda el sender del label clickeado, cuando se crea con codigo el label
            string texto = clickedLabel.Text; // extraemos la cadena de texto del label


            //Recorrido en busca de la tarea seleccionda:
            foreach (DataRow columna in dt_negos_hoy.Rows)
            {

                if (columna["titulo"].ToString() == texto)
                {
                    DataRow row = dt_negos_importantes_hijo.NewRow();

                    row["Empresa"] = columna["nombre"].ToString();
                    row["Nombre1_clt"] = columna["nombres1"].ToString();
                    row["Nombre2_clt"] = columna["apellidos1"].ToString();
                    row["Fecha_cierre"] = columna["fecha_establecida"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    row["Nombre1_resp"] = columna["nombres"].ToString();
                    row["Nombre2_resp"] = columna["apellidos"].ToString();
                    row["Titulo"] = columna["titulo"].ToString();


                    dt_negos_importantes_hijo.Rows.Add(row);
                }

            }
            dgv_hijo.DataSource = dt_negos_importantes_hijo;
            // Llamada al formulario frm_detalle_tareas_importantes
            frm_detalle_tareas_importantes detalle_tareas = new frm_detalle_tareas_importantes();
            detalle_tareas.dt_hijo = dt_negos_importantes_hijo;
            detalle_tareas.Show();
        }


        // ******************************************************************************************************

        // Funcion que se llamará al darle click en el titulo de una tarea, para ver detalle
        private void evento_actualizaciones(object sender, EventArgs e)
        {
            dt_negos_importantes_hijo.Clear(); // Limpieza de datagrid hijo de tareas importantes.

            Label clickedLabel = sender as Label; // sirve para tomar la cadena que manda el sender del label clickeado, cuando se crea con codigo el label
            string texto = clickedLabel.Text; // extraemos la cadena de texto del label


            //Recorrido en busca de la tarea seleccionda:
            foreach (DataRow columna in dt_actualizaciones.Rows)
            {

                if (columna["titulo"].ToString() == texto)
                {
                    DataRow row = dt_negos_importantes_hijo.NewRow();

                    row["Empresa"] = columna["nombre"].ToString();
                    row["Nombre1_clt"] = columna["nombres1"].ToString();
                    row["Nombre2_clt"] = columna["apellidos1"].ToString();
                    row["Fecha_cierre"] = columna["fecha_establecida"].ToString();
                    row["Monto"] = columna["valor"].ToString();
                    row["Nombre1_resp"] = columna["nombres"].ToString();
                    row["Nombre2_resp"] = columna["apellidos"].ToString();
                    row["Titulo"] = columna["titulo"].ToString();


                    dt_negos_importantes_hijo.Rows.Add(row);
                }

            }
            dgv_hijo.DataSource = dt_negos_importantes_hijo;
            // Llamada al formulario frm_detalle_tareas_importantes
            frm_detalle_tareas_importantes detalle_tareas = new frm_detalle_tareas_importantes();
            detalle_tareas.dt_hijo = dt_negos_importantes_hijo;
            detalle_tareas.Show();
        }



        // *********************************************************************

        public void frm_pronostico_Load(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Maximized;

            // Marvin Rouggeri Yoque López, 0901-13-281
            this.AutoScroll = true; // agregar barra de desplazamiento si existe un elemento que no se puede ver por el tamaño de la pantalla
            gpc_tareas_importantes.AutoSize = true; // auto ajustar el contenedor de tareas importantes
            gpc_nego_hoy.AutoSize = true;

            //DataTable dt_negos_importantes = new DataTable(); // tendra la consulta de Consulta_Negocios_importantes_proyecciones
            dt_negos_importantes = CapaDatos.Consulta_Negocios_importantes_proyecciones();
            dgv_nego_importantes.DataSource = dt_negos_importantes;


            // Carga de datatable de negocios_hoy con consulta de la base de datos
            dt_negos_hoy = CapaDatos.Consulta_Negocios_Hoy(hoy.ToString("yyyy-MM-dd"));


            //Carga de dataable de actualizaciones
            dt_actualizaciones = CapaDatos.Consulta_Actualizaciones();
            // Carga de dt de negocios del mes
            dt_negos_mes = CapaDatos.Consulta_Negocios_Mes(fecha_inicio_mes.ToString("yyyy-MM-dd"), hoy.ToString("yyyy-MM-dd"));
            //Carga de monto en la grafica
            dt_meta = CapaDatos.consultar_meta_registro();

            meta_mes = Convert.ToDouble( dt_meta.Rows[0]["meta"].ToString());

            lbl_meta.Text = meta_mes.ToString();
            lbl_fecha_hoy.Text = hoy.ToShortDateString();

            //creacion de nuevo datatable hijo de tareas importantes
            DataColumn column_negos_imports = new DataColumn();


            column_negos_imports.DataType = System.Type.GetType("System.String");
            column_negos_imports.ColumnName = "Empresa";
            dt_negos_importantes_hijo.Columns.Add(column_negos_imports);


            column_negos_imports = new DataColumn();
            column_negos_imports.DataType = System.Type.GetType("System.String");
            column_negos_imports.ColumnName = "Nombre1_clt";
            dt_negos_importantes_hijo.Columns.Add(column_negos_imports);


            column_negos_imports = new DataColumn();
            column_negos_imports.DataType = System.Type.GetType("System.String");
            column_negos_imports.ColumnName = "Nombre2_clt";
            dt_negos_importantes_hijo.Columns.Add(column_negos_imports);

            column_negos_imports = new DataColumn();
            column_negos_imports.DataType = System.Type.GetType("System.String");
            column_negos_imports.ColumnName = "Fecha_cierre";
            dt_negos_importantes_hijo.Columns.Add(column_negos_imports);

            column_negos_imports = new DataColumn();
            column_negos_imports.DataType = System.Type.GetType("System.String");
            column_negos_imports.ColumnName = "Monto";
            dt_negos_importantes_hijo.Columns.Add(column_negos_imports);

            column_negos_imports = new DataColumn();
            column_negos_imports.DataType = System.Type.GetType("System.String");
            column_negos_imports.ColumnName = "Nombre1_resp";
            dt_negos_importantes_hijo.Columns.Add(column_negos_imports);

            column_negos_imports = new DataColumn();
            column_negos_imports.DataType = System.Type.GetType("System.String");
            column_negos_imports.ColumnName = "Nombre2_resp";
            dt_negos_importantes_hijo.Columns.Add(column_negos_imports);

            column_negos_imports = new DataColumn();
            column_negos_imports.DataType = System.Type.GetType("System.String");
            column_negos_imports.ColumnName = "Titulo";
            dt_negos_importantes_hijo.Columns.Add(column_negos_imports);



            //creacion de nuevo datatable hijo de negocios en proceso
            DataColumn column_nego_pro = new DataColumn();
            column_nego_pro.DataType = System.Type.GetType("System.String");
            column_nego_pro.ColumnName = "fecha";
            dt_nego_pro.Columns.Add(column_nego_pro);


            column_nego_pro = new DataColumn();
            column_nego_pro.DataType = System.Type.GetType("System.String");
            column_nego_pro.ColumnName = "valor";
            dt_nego_pro.Columns.Add(column_nego_pro);

            column_nego_pro = new DataColumn();
            column_nego_pro.DataType = System.Type.GetType("System.String");
            column_nego_pro.ColumnName = "acumulativa";
            dt_nego_pro.Columns.Add(column_nego_pro);

            //creacion de nuevo datatable hijo de negocios ganados
            DataColumn column_nego_gana = new DataColumn();

            column_nego_gana.DataType = System.Type.GetType("System.String");
            column_nego_gana.ColumnName = "fecha";
            dt_nego_gana.Columns.Add(column_nego_gana);


            column_nego_gana = new DataColumn();
            column_nego_gana.DataType = System.Type.GetType("System.String");
            column_nego_gana.ColumnName = "valor";
            dt_nego_gana.Columns.Add(column_nego_gana);

            column_nego_gana = new DataColumn();
            column_nego_gana.DataType = System.Type.GetType("System.String");
            column_nego_gana.ColumnName = "acumulativa";
            dt_nego_gana.Columns.Add(column_nego_gana);

            //creacion de nuevo datatable hijo de negocios perdidos
            DataColumn column_nego_per = new DataColumn();

            column_nego_per.DataType = System.Type.GetType("System.String");
            column_nego_per.ColumnName = "fecha";
            dt_nego_per.Columns.Add(column_nego_per);


            column_nego_per = new DataColumn();
            column_nego_per.DataType = System.Type.GetType("System.String");
            column_nego_per.ColumnName = "valor";
            dt_nego_per.Columns.Add(column_nego_per);

            column_nego_per = new DataColumn();
            column_nego_per.DataType = System.Type.GetType("System.String");
            column_nego_per.ColumnName = "acumulativa";
            dt_nego_per.Columns.Add(column_nego_per);





            // ***********************************************    INICIO DE AREA DE TRABAJO PARA GROUP BOX DE TAREAS PARA HOY: ******************************************
            foreach (DataRow row in dt_negos_hoy.Rows)
            {
                Font titulo = new Font("Tahoma", 10);

                // titulo:
                Label lbl_titulo = new Label();
                lbl_titulo.Cursor = Cursors.Hand;
                lbl_titulo.Font = titulo;
                lbl_titulo.Font = new Font(lbl_titulo.Font, FontStyle.Bold);
                lbl_titulo.Location = new Point(28, 30 + (60 * num_filas_dt_hoy));
                lbl_titulo.Text = row["titulo"].ToString();
                lbl_titulo.Width = 200;
                lbl_titulo.Height = 16;


                // Empresa:
                Label lbl_responsable = new Label();
                lbl_responsable.Location = new Point(30, 50 + (60 * num_filas_dt_hoy));
                lbl_responsable.Text = row["nombres"].ToString() + " " + row["apellidos"].ToString();
                lbl_responsable.Width = 200;
                lbl_responsable.Height = 12;

                // Cliente:
                Label lbl_fecha_valor = new Label();
                lbl_fecha_valor.Location = new Point(30, 65 + (60 * num_filas_dt_hoy));
                lbl_fecha_valor.Text = row["fecha_establecida"].ToString() + "          Q. " + row["valor"].ToString();
                lbl_fecha_valor.Width = 250;
                lbl_fecha_valor.Height = 12;

                // agregar labels al GroupBox:
                gpc_nego_hoy.Controls.Add(lbl_titulo);
                gpc_nego_hoy.Controls.Add(lbl_responsable);
                gpc_nego_hoy.Controls.Add(lbl_fecha_valor);
                num_filas_dt_hoy = num_filas_dt_hoy + 1;

                // Asignacion de evento al label de titulo
                lbl_titulo.Click += new System.EventHandler(this.evento_tareas_hoy);


            }


            // ***********************************************    INICIO DE AREA DE TRABAJO PARA GROUP BOX DE TAREAS IMPORTANTES: ******************************************
            foreach (DataRow row in dt_negos_importantes.Rows)
            {
                Font titulo = new Font("Tahoma", 10);

                // titulo:
                Label lbl_titulo = new Label();
                lbl_titulo.Cursor = Cursors.Hand;
                lbl_titulo.Font = titulo;
                lbl_titulo.Font = new Font(lbl_titulo.Font, FontStyle.Bold);
                lbl_titulo.Location = new Point(28, 30 + (60 * num_filas_dt));
                lbl_titulo.Text = row["titulo"].ToString();
                lbl_titulo.Width = 200;
                lbl_titulo.Height = 16;


                // Empresa:
                Label lbl_responsable = new Label();
                lbl_responsable.Location = new Point(30, 50 + (60 * num_filas_dt));
                lbl_responsable.Text = row["nombres"].ToString() + " " + row["apellidos"].ToString();
                lbl_responsable.Width = 200;
                lbl_responsable.Height = 12;

                // Cliente:
                Label lbl_fecha_valor = new Label();
                lbl_fecha_valor.Location = new Point(30, 65 + (60 * num_filas_dt));
                lbl_fecha_valor.Text = row["fecha_establecida"].ToString() + "          Q. " + row["valor"].ToString();
                lbl_fecha_valor.Width = 250;
                lbl_fecha_valor.Height = 12;

                // agregar labels al GroupBox:
                gpc_tareas_importantes.Controls.Add(lbl_titulo);
                gpc_tareas_importantes.Controls.Add(lbl_responsable);
                gpc_tareas_importantes.Controls.Add(lbl_fecha_valor);
                num_filas_dt = num_filas_dt + 1;

                // Asignacion de evento al label de titulo
                lbl_titulo.Click += new System.EventHandler(this.evento_tareas_importantes);


            }



            // ***********************************************    INICIO DE AREA DE TRABAJO PARA GROUP BOX DE ACTUALIZACIONES: ******************************************
            foreach (DataRow row in dt_actualizaciones.Rows)
            {
                Font titulo = new Font("Tahoma", 10);

                // titulo:
                Label lbl_titulo = new Label();
                lbl_titulo.Cursor = Cursors.Hand;
                lbl_titulo.Font = titulo;
                lbl_titulo.Font = new Font(lbl_titulo.Font, FontStyle.Bold);
                lbl_titulo.Location = new Point(28, 30 + (60 * num_filas_dt_acts));
                lbl_titulo.Text = row["titulo"].ToString();
                lbl_titulo.Width = 200;
                lbl_titulo.Height = 16;


                // Empresa:
                Label lbl_responsable = new Label();
                lbl_responsable.Location = new Point(30, 50 + (60 * num_filas_dt_acts));
                lbl_responsable.Text = row["nombres"].ToString() + " " + row["apellidos"].ToString();
                lbl_responsable.Width = 200;
                lbl_responsable.Height = 12;

                // Cliente:
                Label lbl_fecha_valor = new Label();
                lbl_fecha_valor.Location = new Point(30, 65 + (60 * num_filas_dt_acts));
                lbl_fecha_valor.Text = row["fecha_establecida"].ToString() + "          Q. " + row["valor"].ToString();
                lbl_fecha_valor.Width = 250;
                lbl_fecha_valor.Height = 12;

                // agregar labels al GroupBox:
                gpc_actis_recents.Controls.Add(lbl_titulo);
                gpc_actis_recents.Controls.Add(lbl_responsable);
                gpc_actis_recents.Controls.Add(lbl_fecha_valor);
                num_filas_dt_acts = num_filas_dt_acts + 1;

                // Asignacion de evento al label de titulo
                lbl_titulo.Click += new System.EventHandler(this.evento_actualizaciones);


            }
            // ***********************************************    INICIO DE AREA DE TRABAJO PARA GRAFICA DE NEGOCIOS ******************************************


            // Formato de grafico:
            grafica_principal.BackColor = Color.Transparent;
            grafica_principal.BorderOptions.Color = Color.Transparent;
            grafica_principal.Legend.BackColor = Color.Transparent;
            grafica_principal.Legend.Border.Color = Color.Transparent;



            // Asiganacion de series:
            Series series1 = new Series("Negocios Proceso", ViewType.Line);
            Series series2 = new Series("Negocios Ganados", ViewType.Line);
            Series series3 = new Series("Negocios Perdidos", ViewType.Line);
            Series meta = new Series("Meta", ViewType.Line);


            // -------------------------------- negocios en proceso -------------------------
            foreach (DataRow row in dt_negos_mes.Rows) // for each para negocios que estan en proceso
            {
                if (row["status"].ToString() == "proceso" || row["status"].ToString() == "Proceso")
                {
                    DataRow rows = dt_nego_pro.NewRow();

                    rows["fecha"] = row["fecha_est_cierre"].ToString();
                    rows["valor"] = row["valor"].ToString();


                    if (control == 0)
                    {
                        rows["acumulativa"] = rows["valor"].ToString();
                    }
                    else
                    {

                        //int resp = control - 1;
                        //int res = resp;
                        double ant = Convert.ToDouble(dt_nego_pro.Rows[control - 1]["acumulativa"]);
                        double izq = Convert.ToDouble(rows["valor"]);
                        total_negocios = ant + izq;
                        rows["acumulativa"] = total_negocios.ToString("N2");

                    }

                    dt_nego_pro.Rows.Add(rows);
                    control = control + 1;

                }

            }
            // asignacion de total de negocios en proceso a etiqueta
            lbl_total_proceso.Text = total_negocios.ToString("N2");

            foreach (DataRow row_per in dt_nego_pro.Rows) // Insercion de negocios en la grafica, que estan en proceso 
            {
                series1.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), row_per["acumulativa"].ToString()));
                meta.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), meta_mes));
            }
            grafica_principal.Series.Add(series1);

            // -------------------------------- negocios en ganados -------------------------
            foreach (DataRow row in dt_negos_mes.Rows) // for each para negocios que estan en proceso
            {
                if (row["status"].ToString() == "ganado" || row["status"].ToString() == "Ganado")
                {
                    DataRow rows = dt_nego_gana.NewRow();

                    rows["fecha"] = row["fecha_est_cierre"].ToString();
                    rows["valor"] = row["valor"].ToString();

                    if (control_gana == 0)
                    {
                        rows["acumulativa"] = rows["valor"].ToString();
                    }
                    else
                    {


                        double ant = Convert.ToDouble(dt_nego_gana.Rows[control_gana - 1]["acumulativa"]);
                        double izq = Convert.ToDouble(rows["valor"]);
                        total_ganancias = ant + izq;
                        rows["acumulativa"] = total_ganancias.ToString("N2");

                    }



                    dt_nego_gana.Rows.Add(rows);
                    control_gana = control_gana + 1;

                }


            }
            // asignacion de total de negocios en proceso a etiqueta
            lbl_total_ganado.Text = total_ganancias.ToString("N2");

            foreach (DataRow row_per in dt_nego_gana.Rows) // Insercion de negocios en la grafica, que estan en proceso 
            {
                series2.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), row_per["acumulativa"].ToString()));
                meta.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), meta_mes));


            }
            grafica_principal.Series.Add(series2);


            // -------------------------------- negocios perdidos -------------------------
            foreach (DataRow row in dt_negos_mes.Rows) // for each para negocios que estan en proceso
            {
                if (row["status"].ToString() == "perdido" || row["status"].ToString() == "Perdido")
                {
                    DataRow rows = dt_nego_per.NewRow();

                    rows["fecha"] = row["fecha_est_cierre"].ToString();
                    rows["valor"] = row["valor"].ToString();

                    if (control_perd == 0)
                    {
                        rows["acumulativa"] = rows["valor"].ToString();
                    }
                    else
                    {


                        double ant = Convert.ToDouble(dt_nego_per.Rows[control_perd - 1]["acumulativa"]);
                        double izq = Convert.ToDouble(rows["valor"]);
                        total_perdidas = ant + izq;
                        rows["acumulativa"] = total_perdidas.ToString("N2");

                    }



                    dt_nego_per.Rows.Add(rows);
                    control_perd = control_perd = 1;

                }


            }
            // asignacion de total de negocios en proceso a etiqueta
            lbl_total_perdidas.Text = total_perdidas.ToString("N2");

            foreach (DataRow row_per in dt_nego_per.Rows) // Insercion de negocios en la grafica, que estan en proceso 
            {
                series3.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), row_per["acumulativa"].ToString()));
                meta.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), meta_mes));


            }
            grafica_principal.Series.Add(series3);

            grafica_principal.Series.Add(meta);
            //dataGridView1.DataSource = dt_nego_pro;
            //dataGridView1.Rows.Add();

            //dataGridView2.DataSource = dt_negos_mes;


            series1.ArgumentScaleType = ScaleType.Auto;
            series2.ArgumentScaleType = ScaleType.Auto;
            series3.ArgumentScaleType = ScaleType.Auto;
            meta.ArgumentScaleType = ScaleType.Auto;



            //((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle; // marcador de triangulo
            ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            ((LineSeriesView)series2.View).LineMarkerOptions.Kind = MarkerKind.Circle;

            ((LineSeriesView)series3.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            ((LineSeriesView)meta.View).LineMarkerOptions.Kind = MarkerKind.Star;

            //((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada
            ((LineSeriesView)series1.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
            ((LineSeriesView)series2.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
             //((LineSeriesView)series3.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
            ((LineSeriesView)series3.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
            ((LineSeriesView)meta.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada

            ((LineSeriesView)meta.View).Color = Color.Gold; // linea solida perdida
            ((LineSeriesView)series3.View).Color = Color.Red; // linea solida perdida
            ((LineSeriesView)series2.View).Color = Color.CadetBlue; // linea solida ganada
            ((LineSeriesView)series1.View).Color = Color.YellowGreen; // linea solida proceso

            ((XYDiagram)grafica_principal.Diagram).EnableAxisXZooming = false; 

            //lineChart.CalcHitInfo(e.X,e.Y);


            
            grafica_principal.Legend.Visible = true;

            // Titulo:
            grafica_principal.Titles.Add(new ChartTitle());
            grafica_principal.Titles[0].Text = "Rendimiento Mensual";

            // Add the chart to the form.
            grafica_principal.Dock = DockStyle.Fill;
            ctc_metas_negocios.Controls.Add(grafica_principal);



            // ****************************************** CARGA DE DATATABLES CON NEGOCIOS GANADOS, PERDIDOS, O EN PROCESO************************
            dt_negos_proceso = CapaDatos.consultar_negocios_proceso(fecha_inicio_mes.ToString("yyyy-MM-dd"), hoy.ToString("yyyy-MM-dd"), "Proceso");
            dt_negos_ganados = CapaDatos.consultar_negocios_proceso(fecha_inicio_mes.ToString("yyyy-MM-dd"), hoy.ToString("yyyy-MM-dd"), "Ganado");
            dt_negos_perdidos = CapaDatos.consultar_negocios_proceso(fecha_inicio_mes.ToString("yyyy-MM-dd"), hoy.ToString("yyyy-MM-dd"), "Perdido");
            //dataGridView3.DataSource = dt_negos_proceso;
            // cambio de headers para datatable de negocios en proceso
            //dt_negos_proceso.Columns[0].ColumnName = "Titulo de negociación";
            //dt_negos_proceso.Columns[1].ColumnName = "Valor";
            //dt_negos_proceso.Columns[2].ColumnName = "Usuario";
            //dt_negos_proceso.Columns[3].ColumnName = "Apellidos";
            //dt_negos_proceso.Columns[4].ColumnName = "Empresa";
            //dt_negos_proceso.Columns[5].ColumnName = "Encargado";
            //dt_negos_proceso.Columns[6].ColumnName = "Apellidos";
            //dt_negos_proceso.Columns[7].ColumnName = "Estado actual";
            //dt_negos_proceso.Columns[8].ColumnName = "Fecha de cierre";

            // cambio de headers para datatable de negocios en proceso
            //dt_negos_perdidos.Columns[0].ColumnName = "Titulo de negociación";
            //dt_negos_perdidos.Columns[1].ColumnName = "Valor";
            //dt_negos_perdidos.Columns[2].ColumnName = "Usuario";
            //dt_negos_perdidos.Columns[3].ColumnName = "Apellidos";
            //dt_negos_perdidos.Columns[4].ColumnName = "Empresa";
            //dt_negos_perdidos.Columns[5].ColumnName = "Encargado";
            //dt_negos_perdidos.Columns[6].ColumnName = "Apellidos";
            //dt_negos_perdidos.Columns[7].ColumnName = "Estado actual";
            //dt_negos_perdidos.Columns[8].ColumnName = "Fecha de cierre";



            // cambio de headers para datatable de negocios en proceso
            //dt_negos_ganados.Columns[0].ColumnName = "Titulo de negociación";
            //dt_negos_ganados.Columns[1].ColumnName = "Valor";
            //dt_negos_ganados.Columns[2].ColumnName = "Usuario";
            //dt_negos_ganados.Columns[3].ColumnName = "Apellidos";
            //dt_negos_ganados.Columns[4].ColumnName = "Empresa";
            //dt_negos_ganados.Columns[5].ColumnName = "Encargado";
            //dt_negos_ganados.Columns[6].ColumnName = "Apellidos";
            //dt_negos_ganados.Columns[7].ColumnName = "Estado actual";
            //dt_negos_ganados.Columns[8].ColumnName = "Fecha de cierre";

            //dataGridView2.DataSource = dt_negos_proceso;  

           

        }



            // Actualizacion de grafica al asignar una meta






            // label de detalle de negocios en proceso
        private void label8_Click(object sender, EventArgs e)
        {
            string titulo = "Negocios en proceso";

            frm_estadistica_negocio_descripcion negocio_descripcion = new frm_estadistica_negocio_descripcion();
            negocio_descripcion.Show();
            negocio_descripcion.lbl_titulo.Text = titulo;
            negocio_descripcion.dgv_detalle_negocio.DataSource = dt_negos_proceso;
        }

        // label de detalle de negocios ganados

        private void lbl_ganados_Click(object sender, EventArgs e)
        {
            string titulo = "Negocios ganados";

            frm_estadistica_negocio_descripcion negocio_descripcion = new frm_estadistica_negocio_descripcion();
            negocio_descripcion.Show();
            negocio_descripcion.lbl_titulo.Text = titulo;
            negocio_descripcion.dgv_detalle_negocio.DataSource = dt_negos_ganados;
        }

        // label de detalle de negocios perdidos

        private void lbl_perdidos_Click(object sender, EventArgs e)
        {
            string titulo = "Negocios perdidos";

            frm_estadistica_negocio_descripcion negocio_descripcion = new frm_estadistica_negocio_descripcion();
            negocio_descripcion.Show();
            negocio_descripcion.lbl_titulo.Text = titulo;
            negocio_descripcion.dgv_detalle_negocio.DataSource = dt_negos_perdidos;
        }


        // COMENTE AQUI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



        // boton que servira para establecer, modificar la meta del mes
        private void btn_meta_acceso_Click(object sender, EventArgs e)
        {
            DialogResult res = metas.ShowDialog();

            if (res == DialogResult.OK)
            {
                meta_mes = metas.meta;
                //MessageBox.Show(meta_mes.ToString());
                lbl_meta.Text = meta_mes.ToString();

                // ***********************************************    INICIO DE AREA DE TRABAJO PARA GRAFICA DE NEGOCIOS ******************************************

                grafica_principal.Series.Clear();
                grafica_principal.Titles.Clear();
                control = 0;
                control_gana = 0;
                control_perd = 0;
                // Formato de grafico:
                grafica_principal.BackColor = Color.Transparent;
                grafica_principal.BorderOptions.Color = Color.Transparent;
                grafica_principal.Legend.BackColor = Color.Transparent;
                grafica_principal.Legend.Border.Color = Color.Transparent;



                // Asiganacion de series:
                Series series1 = new Series("Negocios Proceso", ViewType.Line);
                Series series2 = new Series("Negocios Ganados", ViewType.Line);
                Series series3 = new Series("Negocios Perdidos", ViewType.Line);
                Series meta = new Series("Meta", ViewType.Line);


                // -------------------------------- negocios en proceso -------------------------
                foreach (DataRow row in dt_negos_mes.Rows) // for each para negocios que estan en proceso
                {
                    if (row["status"].ToString() == "proceso" || row["status"].ToString() == "Proceso")
                    {
                        DataRow rows = dt_nego_pro.NewRow();

                        rows["fecha"] = row["fecha_est_cierre"].ToString();
                        rows["valor"] = row["valor"].ToString();


                        if (control == 0)
                        {
                            rows["acumulativa"] = rows["valor"].ToString();
                        }
                        else
                        {

                            //int resp = control - 1;
                            //int res = resp;
                            double ant = Convert.ToDouble(dt_nego_pro.Rows[control - 1]["acumulativa"]);
                            double izq = Convert.ToDouble(rows["valor"]);
                            total_negocios = ant + izq;
                            rows["acumulativa"] = total_negocios.ToString("N2");

                        }

                        dt_nego_pro.Rows.Add(rows);
                        control = control + 1;

                    }

                }
                // asignacion de total de negocios en proceso a etiqueta
                lbl_total_proceso.Text = total_negocios.ToString("N2");

                foreach (DataRow row_per in dt_nego_pro.Rows) // Insercion de negocios en la grafica, que estan en proceso 
                {
                    series1.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), row_per["acumulativa"].ToString()));
                    meta.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), meta_mes));
                }
                grafica_principal.Series.Add(series1);

                // -------------------------------- negocios en ganados -------------------------
                foreach (DataRow row in dt_negos_mes.Rows) // for each para negocios que estan en proceso
                {
                    if (row["status"].ToString() == "ganado" || row["status"].ToString() == "Ganado")
                    {
                        DataRow rows = dt_nego_gana.NewRow();

                        rows["fecha"] = row["fecha_est_cierre"].ToString();
                        rows["valor"] = row["valor"].ToString();

                        if (control_gana == 0)
                        {
                            rows["acumulativa"] = rows["valor"].ToString();
                        }
                        else
                        {


                            double ant = Convert.ToDouble(dt_nego_gana.Rows[control_gana - 1]["acumulativa"]);
                            double izq = Convert.ToDouble(rows["valor"]);
                            total_ganancias = ant + izq;
                            rows["acumulativa"] = total_ganancias.ToString("N2");

                        }



                        dt_nego_gana.Rows.Add(rows);
                        control_gana = control_gana + 1;

                    }


                }
                // asignacion de total de negocios en proceso a etiqueta
                lbl_total_ganado.Text = total_ganancias.ToString("N2");

                foreach (DataRow row_per in dt_nego_gana.Rows) // Insercion de negocios en la grafica, que estan en proceso 
                {
                    series2.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), row_per["acumulativa"].ToString()));
                    meta.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), meta_mes));


                }
                grafica_principal.Series.Add(series2);


                // -------------------------------- negocios perdidos -------------------------
                foreach (DataRow row in dt_negos_mes.Rows) // for each para negocios que estan en proceso
                {
                    if (row["status"].ToString() == "perdido" || row["status"].ToString() == "Perdido")
                    {
                        DataRow rows = dt_nego_per.NewRow();

                        rows["fecha"] = row["fecha_est_cierre"].ToString();
                        rows["valor"] = row["valor"].ToString();

                        if (control_perd == 0)
                        {
                            rows["acumulativa"] = rows["valor"].ToString();
                        }
                        else
                        {


                            double ant = Convert.ToDouble(dt_nego_per.Rows[control_perd - 1]["acumulativa"]);
                            double izq = Convert.ToDouble(rows["valor"]);
                            total_perdidas = ant + izq;
                            rows["acumulativa"] = total_perdidas.ToString("N2");

                        }



                        dt_nego_per.Rows.Add(rows);
                        control_perd = control_perd = 1;

                    }


                }
                // asignacion de total de negocios en proceso a etiqueta
                lbl_total_perdidas.Text = total_perdidas.ToString("N2");

                foreach (DataRow row_per in dt_nego_per.Rows) // Insercion de negocios en la grafica, que estan en proceso 
                {
                    series3.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), row_per["acumulativa"].ToString()));
                    meta.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), meta_mes));


                }
                grafica_principal.Series.Add(series3);

                grafica_principal.Series.Add(meta);
                //dataGridView1.DataSource = dt_nego_pro;
                //dataGridView1.Rows.Add();

                //dataGridView2.DataSource = dt_negos_mes;


                series1.ArgumentScaleType = ScaleType.Auto;
                series2.ArgumentScaleType = ScaleType.Auto;
                series3.ArgumentScaleType = ScaleType.Auto;
                meta.ArgumentScaleType = ScaleType.Auto;



                // Access the view-type-specific options of the series.
                //((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle; // marcador de triangulo
                ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;
                ((LineSeriesView)series2.View).LineMarkerOptions.Kind = MarkerKind.Circle;

                ((LineSeriesView)series3.View).LineMarkerOptions.Kind = MarkerKind.Circle;
                ((LineSeriesView)meta.View).LineMarkerOptions.Kind = MarkerKind.Star;

                //((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada
                ((LineSeriesView)series1.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
                ((LineSeriesView)series2.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
                                                                                                             //((LineSeriesView)series3.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
                ((LineSeriesView)series3.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
                ((LineSeriesView)meta.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada

                ((LineSeriesView)meta.View).Color = Color.Gold; // linea solida perdida
                ((LineSeriesView)series3.View).Color = Color.Red; // linea solida perdida
                ((LineSeriesView)series2.View).Color = Color.CadetBlue; // linea solida ganada
                ((LineSeriesView)series1.View).Color = Color.YellowGreen; // linea solida proceso

                //((XYDiagram)lineChart.Diagram).EnableAxisXZooming = true;
                ((XYDiagram)grafica_principal.Diagram).EnableAxisXZooming = false; // para que sirve ?

                //lineChart.CalcHitInfo(e.X,e.Y);


                // Hide the legend (if necessary).
                grafica_principal.Legend.Visible = true;

                //// Add a title to the chart (if necessary).
                grafica_principal.Titles.Add(new ChartTitle());
                grafica_principal.Titles[0].Text = "Rendimiento Mensual";

                // Add the chart to the form.
                grafica_principal.Dock = DockStyle.Fill;
                ctc_metas_negocios.Controls.Add(grafica_principal);



            }
            //else if (res == DialogResult.Cancel)
            //if (res == DialogResult.Cancel)
            //{
            //    meta_mes = metas.meta;
            //    //MessageBox.Show(meta_mes.ToString());
            //    lbl_meta.Text = meta_mes.ToString();

            //    // ***********************************************    INICIO DE AREA DE TRABAJO PARA GRAFICA DE NEGOCIOS ******************************************

            //    grafica_principal.Series.Clear();
            //    grafica_principal.Titles.Clear();
            //    control = 0;
            //    control_gana = 0;
            //    control_perd = 0;
            //    // Formato de grafico:
            //    grafica_principal.BackColor = Color.Transparent;
            //    grafica_principal.BorderOptions.Color = Color.Transparent;
            //    grafica_principal.Legend.BackColor = Color.Transparent;
            //    grafica_principal.Legend.Border.Color = Color.Transparent;



            //    // Asiganacion de series:
            //    Series series1 = new Series("Negocios Proceso", ViewType.Line);
            //    Series series2 = new Series("Negocios Ganados", ViewType.Line);
            //    Series series3 = new Series("Negocios Perdidos", ViewType.Line);
            //    Series meta = new Series("Meta", ViewType.Line);


            //    // -------------------------------- negocios en proceso -------------------------
            //    foreach (DataRow row in dt_negos_mes.Rows) // for each para negocios que estan en proceso
            //    {
            //        if (row["status"].ToString() == "proceso" || row["status"].ToString() == "Proceso")
            //        {
            //            DataRow rows = dt_nego_pro.NewRow();

            //            rows["fecha"] = row["fecha_est_cierre"].ToString();
            //            rows["valor"] = row["valor"].ToString();


            //            if (control == 0)
            //            {
            //                rows["acumulativa"] = rows["valor"].ToString();
            //            }
            //            else
            //            {

            //                //int resp = control - 1;
            //                //int res = resp;
            //                double ant = Convert.ToDouble(dt_nego_pro.Rows[control - 1]["acumulativa"]);
            //                double izq = Convert.ToDouble(rows["valor"]);
            //                total_negocios = ant + izq;
            //                rows["acumulativa"] = total_negocios.ToString("N2");

            //            }

            //            dt_nego_pro.Rows.Add(rows);
            //            control = control + 1;

            //        }

            //    }
            //    // asignacion de total de negocios en proceso a etiqueta
            //    lbl_total_proceso.Text = total_negocios.ToString("N2");

            //    foreach (DataRow row_per in dt_nego_pro.Rows) // Insercion de negocios en la grafica, que estan en proceso 
            //    {
            //        series1.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), row_per["acumulativa"].ToString()));
            //        meta.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), meta_mes));
            //    }
            //    grafica_principal.Series.Add(series1);

            //    // -------------------------------- negocios en ganados -------------------------
            //    foreach (DataRow row in dt_negos_mes.Rows) // for each para negocios que estan en proceso
            //    {
            //        if (row["status"].ToString() == "ganado" || row["status"].ToString() == "Ganado")
            //        {
            //            DataRow rows = dt_nego_gana.NewRow();

            //            rows["fecha"] = row["fecha_est_cierre"].ToString();
            //            rows["valor"] = row["valor"].ToString();

            //            if (control_gana == 0)
            //            {
            //                rows["acumulativa"] = rows["valor"].ToString();
            //            }
            //            else
            //            {


            //                double ant = Convert.ToDouble(dt_nego_gana.Rows[control_gana - 1]["acumulativa"]);
            //                double izq = Convert.ToDouble(rows["valor"]);
            //                total_ganancias = ant + izq;
            //                rows["acumulativa"] = total_ganancias.ToString("N2");

            //            }



            //            dt_nego_gana.Rows.Add(rows);
            //            control_gana = control_gana + 1;

            //        }


            //    }
            //    // asignacion de total de negocios en proceso a etiqueta
            //    lbl_total_ganado.Text = total_ganancias.ToString("N2");

            //    foreach (DataRow row_per in dt_nego_gana.Rows) // Insercion de negocios en la grafica, que estan en proceso 
            //    {
            //        series2.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), row_per["acumulativa"].ToString()));
            //        meta.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), meta_mes));


            //    }
            //    grafica_principal.Series.Add(series2);


            //    // -------------------------------- negocios perdidos -------------------------
            //    foreach (DataRow row in dt_negos_mes.Rows) // for each para negocios que estan en proceso
            //    {
            //        if (row["status"].ToString() == "perdido" || row["status"].ToString() == "Perdido")
            //        {
            //            DataRow rows = dt_nego_per.NewRow();

            //            rows["fecha"] = row["fecha_est_cierre"].ToString();
            //            rows["valor"] = row["valor"].ToString();

            //            if (control_perd == 0)
            //            {
            //                rows["acumulativa"] = rows["valor"].ToString();
            //            }
            //            else
            //            {


            //                double ant = Convert.ToDouble(dt_nego_per.Rows[control_perd - 1]["acumulativa"]);
            //                double izq = Convert.ToDouble(rows["valor"]);
            //                total_perdidas = ant + izq;
            //                rows["acumulativa"] = total_perdidas.ToString("N2");

            //            }



            //            dt_nego_per.Rows.Add(rows);
            //            control_perd = control_perd = 1;

            //        }


            //    }
            //    // asignacion de total de negocios en proceso a etiqueta
            //    lbl_total_perdidas.Text = total_perdidas.ToString("N2");

            //    foreach (DataRow row_per in dt_nego_per.Rows) // Insercion de negocios en la grafica, que estan en proceso 
            //    {
            //        series3.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), row_per["acumulativa"].ToString()));
            //        meta.Points.Add(new SeriesPoint(row_per["fecha"].ToString(), meta_mes));


            //    }
            //    grafica_principal.Series.Add(series3);

            //    grafica_principal.Series.Add(meta);
            //    //dataGridView1.DataSource = dt_nego_pro;
            //    //dataGridView1.Rows.Add();

            //    //dataGridView2.DataSource = dt_negos_mes;


            //    series1.ArgumentScaleType = ScaleType.Auto;
            //    series2.ArgumentScaleType = ScaleType.Auto;
            //    series3.ArgumentScaleType = ScaleType.Auto;
            //    meta.ArgumentScaleType = ScaleType.Auto;



            //    // Access the view-type-specific options of the series.
            //    //((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle; // marcador de triangulo
            //    ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            //    ((LineSeriesView)series2.View).LineMarkerOptions.Kind = MarkerKind.Circle;

            //    ((LineSeriesView)series3.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            //    ((LineSeriesView)meta.View).LineMarkerOptions.Kind = MarkerKind.Star;

            //    //((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada
            //    ((LineSeriesView)series1.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
            //    ((LineSeriesView)series2.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
            //                                                                                                 //((LineSeriesView)series3.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
            //    ((LineSeriesView)series3.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida
            //    ((LineSeriesView)meta.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada

            //    ((LineSeriesView)meta.View).Color = Color.Gold; // linea solida perdida
            //    ((LineSeriesView)series3.View).Color = Color.Red; // linea solida perdida
            //    ((LineSeriesView)series2.View).Color = Color.CadetBlue; // linea solida ganada
            //    ((LineSeriesView)series1.View).Color = Color.YellowGreen; // linea solida proceso

            //    //((XYDiagram)lineChart.Diagram).EnableAxisXZooming = true;
            //    ((XYDiagram)grafica_principal.Diagram).EnableAxisXZooming = false; // para que sirve ?

            //    //lineChart.CalcHitInfo(e.X,e.Y);


            //    // Hide the legend (if necessary).
            //    grafica_principal.Legend.Visible = true;

            //    //// Add a title to the chart (if necessary).
            //    grafica_principal.Titles.Add(new ChartTitle());
            //    grafica_principal.Titles[0].Text = "Rendimiento Mensual";

            //    // Add the chart to the form.
            //    grafica_principal.Dock = DockStyle.Fill;
            //    ctc_metas_negocios.Controls.Add(grafica_principal);

            //}
        }


        // link para ir a formulario de pronosticos
        private void lkl_pronostico_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_pronostico_ventas_secundario pronostico = new frm_pronostico_ventas_secundario();
            pronostico.Show();
            
        }
    }
}