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
using System.Globalization;

// --------------------------------------------- Marvin Rouggeri Yoque Lopez. 0901-13-281
namespace crm
{
    public partial class frm_estadistica_empresa : DevExpress.XtraEditors.XtraForm
    {
        public frm_estadistica_empresa()
        {
            InitializeComponent();
        }


        // ----------------------- VARIABLES GLOBALES:
        DateTime fecha_inicio; // usada para determinar el inicio del rango de fechas
        DateTime fecha_fin_semana; // variable usada para calcular los valores de la semana anterior

        String titulo = "Rendimiento empresarial";

        //// ----------------------------- Variables para cuantificar los negocios
        double monto_proceso = 0; int cont_proceso = 0;
        double monto_perdido = 0; int cont_perdido = 0;
        double monto_ganado = 0; int cont_ganado = 0;

        //--------------------------------------------- Datatables que almacenarán los negocios ganados, perdidos y en proceso
        DataTable dt_nego_ganado = new DataTable();
        DataTable dt_nego_perdido = new DataTable();
        DataTable dt_nego_proceso = new DataTable();

        // ------------------------ Variables para cuantificar las tareas
        //string tipo_tarea="";
        int cont_almuerzo_realiz = 0; int cont_almuerzo_pen = 0;
        int cont_tarea_realiz = 0; int cont_tarea_pen = 0;
        int cont_llamada_realiz = 0; int cont_llamada_pen = 0;
        int cont_reunion_realiz = 0; int cont_reunion_pen = 0;
        int cont_plazo_realiz = 0; int cont_plazo_pen = 0;



        CapaDatosPersonas CapaDatos = new CapaDatosPersonas();
        string var_id_usuario = "";
        // variables para determinar fecha y dia
        DateTime fecha_hoy = DateTime.Today;
        Calendar calendario = CultureInfo.InvariantCulture.Calendar;
        string nombre = "";

        // -----------------------------------------------FECHAS PERSONALIZADAS---------------------------------------------------
        string var_fecha_perz_ini = "";
        string var_fecha_perz_fin = "";

        // --------------------------------------------- datatable de empresa que carga al combobox de empresas---------------------------
        DataTable dt_empresa = new DataTable();

        // llamada a la clase de graficacion
        cls_grafica_pie grafica_pie = new cls_grafica_pie();

        // BOTON PARA GENERAR LOS RESULTADOS DE INICIO DE LA SEMANA HASTA LO QUE VA AL DIA DE HOY
        private void btn_semanal_Click(object sender, EventArgs e)
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
            DataTable negocios = CapaDatos.consultar_negocios_empresa(var_id_usuario, fecha_inicio.ToString("yyyy-MM-dd"), fecha_hoy.ToString("yyyy-MM-dd"));
            dgv_prueba.DataSource = negocios;
            // --------------------- CICLO PARA ELABORAR VISTA DE NEGOCIOS
            foreach (DataRow columna in negocios.Rows)
            {
                //cont_ganado = 0;
                //cont_perdido = 0;
                //cont_proceso = 0;

                if (columna["status"].ToString() == "proceso")
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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

                    dt_nego_proceso.Rows.Add(row);



                }
                else if (columna["status"].ToString() == "perdido")
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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

                    dt_nego_perdido.Rows.Add(row);



                }
                else if (columna["status"].ToString() == "ganado")
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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

                    dt_nego_ganado.Rows.Add(row);



                }
            }
            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(),titulo.ToString()));
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
                    if (colum["estado_tarea"].ToString() == "pendiente")
                    {
                        cont_llamada_pen = cont_llamada_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado")
                    {
                        cont_llamada_realiz = cont_llamada_realiz + 1;
                    }
                }
                // columna con reunion
                else if (colum["tipo"].ToString() == "Reunion")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente")
                    {
                        cont_reunion_pen = cont_reunion_pen + 1;
                        //MessageBox.Show("estoy en reunion pendiente");

                    }
                    else if (colum["estado_tarea"].ToString() == "realizado")
                    {
                        //MessageBox.Show("estoy en reunion realizado");

                        cont_reunion_realiz = cont_llamada_realiz + 1;
                    }
                }
                //// columna con tarea
                else if (colum["tipo"].ToString() == "Tarea")
                {

                    if (colum["estado_tarea"].ToString() == "pendiente")
                    {
                        cont_tarea_pen = cont_tarea_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado")
                    {
                        cont_tarea_realiz = cont_tarea_realiz + 1;
                    }
                }
                //// columna con plazo
                else if (colum["tipo"].ToString() == "Plazo")
                {


                    if (colum["estado_tarea"].ToString() == "pendiente")
                    {
                        cont_plazo_pen = cont_plazo_pen + 1;
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado")
                    {
                        cont_plazo_realiz = cont_plazo_realiz + 1;
                    }
                }
                //// columna con almuerzos
                else if (colum["tipo"].ToString() == "Almuerzo")
                {
                    //cont_almuerzo_pen = cont_almuerzo_pen+1;
                    if (colum["estado_tarea"].ToString() == "pendiente")
                    {
                        cont_almuerzo_pen = cont_almuerzo_pen + 1;
                        //MessageBox.Show("estoy en almuerzo pendiente");
                    }
                    else if (colum["estado_tarea"].ToString() == "realizado")
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frm_estadistica_empresa_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            // llamada a la capa de datos 
            CapaDatosPersonas CapaDatos = new CapaDatosPersonas();

         

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

            column_nego_proces = new DataColumn();
            column_nego_proces.DataType = System.Type.GetType("System.String");
            column_nego_proces.ColumnName = "Responsable del negocio";
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

            column_nego = new DataColumn();
            column_nego.DataType = System.Type.GetType("System.String");
            column_nego.ColumnName = "Responsable del negocio";
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

            column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "Responsable del negocio";
            dt_nego_ganado.Columns.Add(column_nego_ganados);

        }


        // BOTON PARA GENERAR TODOS LOS CALCULOS DEL DIA DE HOY
        private void btn_hoy_Click(object sender, EventArgs e)
        {
            //nombre = calendario.GetDayOfWeek(fecha_hoy).ToString();

            //MessageBox.Show("Hoy es: " + nombre + " con fecha: " + fecha_hoy.ToString("yyyy-MM-dd"));

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
            DataTable negocios = CapaDatos.consultar_negocios_empresa(var_id_usuario, fecha_hoy.ToString("yyyy-MM-dd"), fecha_hoy.ToString("yyyy-MM-dd"));
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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

                    dt_nego_ganado.Rows.Add(row);
                }
            }

            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(),cont_perdido.ToString(),cont_proceso.ToString(), titulo.ToString()));
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


        // Combobox con las opciones de seleccionar a todas las empresas o a todos los clientes sin empresas
        private void cmb_empreOclte_SelectedIndexChanged(object sender, EventArgs e)
        {
            var_id_usuario = "";
            var_id_usuario = cmb_empreOclte.Text;
            
            if (cmb_empreOclte.SelectedItem.ToString() == "Empresa")
            {

                
                //dt_empresa = CapaDatos.cargar_empresas();
                dt_empresa = CapaDatos.consultar_empresas();
                cmb_ente.DataSource = dt_empresa;
                cmb_ente.ValueMember = "id_empresa";
                cmb_ente.DisplayMember = "nombre";
                cmb_ente.Enabled = true;

            } else if(cmb_empreOclte.SelectedItem.ToString() == "Cliente sin empresa")
            {
                dt_empresa.Clear();
                cmb_ente.Enabled = false;
            }
        }

        private void cmb_ente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string valor_cmb_empresaOclt = cmb_empreOclte.SelectedValue.ToString();
            if (cmb_empreOclte.Text == "Cliente sin empresa")
            {
                dt_empresa.Clear();
                var_id_usuario = "0";
            }
            else
            {


                var_id_usuario = cmb_ente.SelectedValue.ToString();
                if (var_id_usuario == "" || var_id_usuario == "System.Data.DataRowView")
                {

                }
                else
                {
                    //MessageBox.Show(var_id_usuario);
                }
            }
        }

        private void btn_sem_pasada_Click(object sender, EventArgs e)
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
            DataTable negocios = CapaDatos.consultar_negocios_empresa(var_id_usuario, fecha_inicio.ToString("yyyy-MM-dd"), fecha_fin_semana.ToString("yyyy-MM-dd"));
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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();
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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

                    dt_nego_ganado.Rows.Add(row);
                }
            } //foreach (DataRow columna in negocios.Rows)

              // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
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


            // ----------------------------------- FOREACH DE ACTIVIDADES O TAREAS SEGUN NEGOCIO
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


        // BOTON PARA GENERAR LOS CALCULAR DEL DIA DE AYER
        private void simpleButton5_Click(object sender, EventArgs e)
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
            DataTable negocios = CapaDatos.consultar_negocios_empresa(var_id_usuario, fecha_ayer.ToString("yyyy-MM-dd"), fecha_ayer.ToString("yyyy-MM-dd"));
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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

                    dt_nego_ganado.Rows.Add(row);
                }
            }
            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
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


        // BOTON PARA GENERAR TODOS LOS DATOS DE ESTE MES LO QUE VA DE ESTE MES
        private void simpleButton2_Click(object sender, EventArgs e)
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
            DataTable negocios = CapaDatos.consultar_negocios_empresa(var_id_usuario, fecha_inicio_mes.ToString("yyyy-MM-dd"), fecha_hoy.ToString("yyyy-MM-dd"));
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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

                    dt_nego_ganado.Rows.Add(row);
                }
            }

            // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
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


        // BOTON PARA GENERAR TODOS LOS DATOS DEL MES PASADO
        private void btn_mes_pasado_Click(object sender, EventArgs e)
        {
            DateTime fecha_referencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // fecha de inicio de este mes
            DateTime fecha_inicio_mes = fecha_referencia.AddMonths(-1); // fecha de inicio del mes anterior
            DateTime fecha_fin_mes = fecha_inicio_mes.AddMonths(1).AddDays(-1); // fecha de fin de mes anterior
            //MessageBox.Show("inicio: " + fecha_inicio_mes.ToString("yyy-MM-dd") + " fin: " + fecha_fin_mes.ToString("yyy-MM-dd"));



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
            DataTable negocios = CapaDatos.consultar_negocios_empresa(var_id_usuario, fecha_inicio_mes.ToString("yyyy-MM-dd"), fecha_fin_mes.ToString("yyyy-MM-dd"));
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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                    row["Responsable del negocio"] = columna["nombres1"].ToString();

                    dt_nego_ganado.Rows.Add(row);
                }
            }

             // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
            ctc_negocios.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(),cont_perdido.ToString(),cont_proceso.ToString(), titulo.ToString()));
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


        // BOTON PARA GENERAR LOS DATOS POR FECHA PERSONALIZADO
        private void btn_periodo_perzonalizado_Click(object sender, EventArgs e)
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
                DataTable negocios = CapaDatos.consultar_negocios_empresa(var_id_usuario, var_fecha_perz_ini, var_fecha_perz_fin);
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
                        row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                        row["Responsable del negocio"] = columna["nombres1"].ToString();

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
                        row["Responsable del negocio"] = columna["nombres1"].ToString();

                        dt_nego_ganado.Rows.Add(row);
                    }
                }

                // ------------------------- ENVIO DE DATOS (NEGOCIOS GANADOS,PERDIDOS,EN PROCESO) PARA SER GRAFICADOS EN FORMA DE PIE ------------------
                ctc_negocios.Controls.Add(grafica_pie.grafica_pie(cont_ganado.ToString(), cont_perdido.ToString(), cont_proceso.ToString(), titulo.ToString()));
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