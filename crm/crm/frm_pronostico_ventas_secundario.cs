using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraCharts;


namespace crm
{
    public partial class frm_pronostico_ventas_secundario : Form
    {
        public frm_pronostico_ventas_secundario()
        {
            InitializeComponent();
        }
        // Llamada a la capaDeDatos 
        CapaDatosPersonas capadatos = new CapaDatosPersonas();
        // Funcion para llamar a la clase de nombre de meses para graficar
        cls_nombre_mes nombre_mes = new cls_nombre_mes();



        string if_form = "115";

        // Datatables:
        DataTable dt_cat_negos = new DataTable(); // dt que sirve para cargar las categorias de negocios
        DataTable dt_negos_finalizados = new DataTable(); //dt que sirve para almacenar los negocios en estado finalizado
        DataTable dt_nego_ganado_hijo = new DataTable(); // dt que almacenara la matriz de la grafica
        DataTable dt_nego_ganado_hijo_complemento= new DataTable(); // dt que almacenara la matriz de la grafica

        // Variables Globales
        string id_nego_venta = ""; // variable para almacenar el id de la categoria del negocio o venta
        string uno = "1";
        string dos = "2";
        string tres = "3";
        //double contador_negos_este_mes = 0; // contador para determinar la cantidad de ventas "Y"
        //double contador_negos_ant_mes = 0; // contador para determinar la cantidad de ventas "Y"
        //double contador_negos_2ant_mes = 0; // contador para determinar la cantidad de ventas "Y"

        double contador_negos_este_mes = 0; // contador para determinar la cantidad de ventas "Y"
        double contador_negos_ant_mes = 0; // contador para determinar la cantidad de ventas "Y"
        double contador_negos_2ant_mes = 0; // contador para determinar la cantidad de ventas "Y"




        //double xm = 0;
        //double ym = 0;
        //double x2m = 0;
        //double y2m = 0;
        //double xym = 0;

        double xm = 0;
        double ym = 0;
        double x2m = 0;
        double y2m = 0;
        double xym = 0;



        ChartControl grafica_principal = new ChartControl(); // grafica en la cual se va a trabajar


        // variables para calcular formulas a y b y "Y" (minimos cuadrados)
        Double b = 0;
        Double a = 0;
        Double y = 0;

        // variables para calcular promedio movil
        double divi = 0;
        int p_movil = 0;


        int cont_meses =0; // variable que tomara el valor elegido en los radio buttons 1,3 0 12 (meses).


        Double suma_x = 0; // sumatoria de columna x
        Double suma_y = 0; // sumatoria de columna y
        Double suma_x2 = 0; // sumatoria de columna x2
        Double suma_y2 = 0; // sumatoria de columna y2
        Double suma_xy = 0; // sumatoria de columna xy

        int N = 1; // valor N para formula

        // Variables de tiempo
        DateTime hoy = DateTime.Today;  // Fecha de hoy
        DateTime fecha_inicio_mes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        // Fecha de inicio de mes


        // Clasificacion es para Negocios o Ventas de productos
        // Categoria es para subcategoria de negocios o subcategoria de productos


        // Radio button para seleccionar negocios O ventas en especifico
        private void rbt_seleccionar_clasificacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_seleccionar_clasificacion.Checked)
            {
                //cmb_clasificacion.Enabled = true;
                //rbt_seleccionar_categoria.Enabled = true;
                dt_negos_finalizados.Clear();
                dt_nego_ganado_hijo.Clear();
                dt_nego_ganado_hijo_complemento.Clear();



                btn_promedio_moviles.Enabled = true;
                btn_pronosticar.Enabled = true;
                cmb_categoria.Enabled = true;
                cmb_clasificacion.Enabled = true;
                rbt_seleccionar_categoria.Enabled = true;
                rbt_siguiente_mes.Enabled = true;
                rbt_sig_anio.Enabled = true;
                rbt_sig_trimestre.Enabled = true;
            }
            
        }

        // Radio button para seleccionar negocios Y ventas en especifico
        private void rbt_todos_clasificacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_todos_clasificacion.Checked)
            {
                cmb_clasificacion.Enabled = false;
                cmb_categoria.Enabled = false;
                cmb_clasificacion.Text = "";

                rbt_todos_categoria.Checked = true;
                rbt_seleccionar_categoria.Enabled = false;

                dt_cat_negos.Clear();

            }
            
        }
        // Radio button para seleccionar un producto o servicio en especifico
        private void rbt_seleccionar_categoria_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_seleccionar_categoria.Enabled)
            {
                cmb_categoria.Enabled = true;
            }
        }

        // Radio button para seleccionar un producto Y servicios
        private void rbt_todos_categoria_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_todos_categoria.Enabled)
            {
                cmb_categoria.Enabled = false;
            }


            dgv_consulta_negos_ventas.DataSource = ""; // limpieza de dtgrid de prueba
            dt_negos_finalizados.Clear(); // limpieza de dtable de negocios para ir a seleccionar todos los negocios sin excepcion, que tengan estado de ganado

            

            if (cmb_clasificacion.SelectedItem.ToString() == "Negocios")
            {
                dt_negos_finalizados = capadatos.seleccionar_negos_historial_general(); // envio de solicitud a la cantidad de negocios vendidos en general 
                dgv_consulta_negos_ventas.DataSource = dt_negos_finalizados;
                dgv_detalle.DataSource = dt_negos_finalizados;

                gridView1.Columns["nombre_cat"].Caption = "Categoria";
                gridView1.Columns["titulo"].Caption = "Titulo";
                gridView1.Columns["valor"].Caption = "Valor";
                gridView1.Columns["fecha_est_cierre"].Caption = "Finalización";
                gridView1.Columns["nombre"].Caption = "Empresa";
                gridView1.Columns["nombres"].Caption = "Usuario";
                gridView1.Columns["apellidos"].Caption = "Apellido";
                gridView1.Columns["id_negocio"].Visible = false;
                gridView1.Columns["id_cat"].Visible = false;

            }
        }



        // ComboBox, sirve para llamar a las categorias
        private void cmb_clasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_clasificacion.SelectedItem.ToString() == "Negocios")
            {
                rbt_todos_categoria.Enabled = true;
                cmb_categoria.Enabled = true;

                dt_cat_negos = capadatos.seleccionar_cat_negos();

                cmb_categoria.DataSource = dt_cat_negos;
                cmb_categoria.ValueMember = "id_cat";
                cmb_categoria.DisplayMember = "nombre_cat";

            } else if (cmb_clasificacion.SelectedItem.ToString() == "Ventas")
            {
                gridView1.Columns.Clear();
                //// bloquear opciones de escoger categorias
                cmb_categoria.Enabled = false;
                cmb_categoria.Enabled = false;
                //// mando a llamar todos los datos a la BD de la tabla encabezado de factura
                dgv_tabla_result.DataSource = "";
                dgv_complemento.DataSource = "";
                dt_cat_negos.Clear();
                cmb_categoria.DisplayMember = "";
                dt_negos_finalizados.Clear();
                dt_negos_finalizados = capadatos.seleccionar_ventas_historial_general();
                dgv_consulta_negos_ventas.DataSource = dt_negos_finalizados;
                dgv_detalle.DataSource = dt_negos_finalizados;




                gridView1.Columns["fecha"].Caption = "Fecha";
                gridView1.Columns["forma_pago"].Caption = "Tipo de pago";
                gridView1.Columns["total"].Caption = "Valor";

                //// mandar a cargar los gridviews con los totales de las facturas
            }

        }

        // ComboBox, para subcategorias
        private void cmb_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //id_nego_venta = cmb_categoria.SelectedValue.ToString(); // id de la categoria que va a ser enviada al dt para almacenar negocios por fecha
            //MessageBox.Show(id_nego_venta);

            if (cmb_clasificacion.SelectedItem.ToString() == "" || cmb_clasificacion.SelectedItem.ToString() == "System.Data.DataRowView")
            {
                
            }
            else if (cmb_clasificacion.SelectedItem.ToString() == "Negocios")
            {
                id_nego_venta = "";
                gridView1.Columns.Clear();


                dt_nego_ganado_hijo.Clear();
                dt_nego_ganado_hijo_complemento.Clear();
                dt_negos_finalizados.Clear();
                dgv_complemento.DataSource = "";
                dgv_tabla_result.DataSource = "";
                //dgv_detalle.DataSource = "";


                id_nego_venta = cmb_categoria.SelectedValue.ToString(); // id de la categoria que va a ser enviada al dt para almacenar negocios por fecha
                //MessageBox.Show(id_nego_venta);


                dt_negos_finalizados = capadatos.seleccionar_negos_historial(id_nego_venta); // envio de solicitud a la cantidad de productos vendidos segun producto seleccionado
                dgv_consulta_negos_ventas.DataSource = dt_negos_finalizados;
                dgv_detalle.DataSource = dt_negos_finalizados;

                gridView1.Columns["nombre_cat"].Caption = "Categoria";
                gridView1.Columns["titulo"].Caption = "Titulo";
                gridView1.Columns["valor"].Caption = "Valor";
                gridView1.Columns["fecha_est_cierre"].Caption = "Finalización";
                gridView1.Columns["nombre"].Caption = "Empresa";
                gridView1.Columns["nombres"].Caption = "Usuario";
                gridView1.Columns["apellidos"].Caption = "Apellido";
                gridView1.Columns["id_negocio"].Visible = false;
                gridView1.Columns["id_cat"].Visible = false;


            }
        }


        // Boton para generar todos los calculos de la proyección
        private void btn_pronosticar_Click(object sender, EventArgs e)
        {
            if (cmb_clasificacion.Text == "Negocios")
            {

                // inicializacion de variables
                dt_nego_ganado_hijo.Clear();
                dt_nego_ganado_hijo_complemento.Clear();
                dgv_complemento.DataSource = "";
                dgv_tabla_result.DataSource = "";
                cont_meses = 0;
                grafica_principal.Series.Clear();
                grafica_principal.Titles.Clear();

                suma_x2 = 0;
                suma_y2 = 0;
                suma_xy = 0;
                suma_x = 0;
                suma_y = 0;

                b = 0;
                a = 0;
                y = 0;

                contador_negos_2ant_mes = 0;
                contador_negos_ant_mes = 0;
                contador_negos_este_mes = 0;

                //uno = "1";
                //dos = "2";
                //tres = "3";
                N = 1;

                xm = 0;
                ym = 0;
                x2m = 0;
                y2m = 0;
                xym = 0;

                //if (rbt_seleccionar_categoria.Checked)
                //{ 
                DataRow columna1 = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados
                DataRow columna = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados
                DataRow columna3 = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados

                //DataRow columna_x2 = dt_nego_ganado_hijo.NewRow(); // columna x2, 1,3


                DateTime fecha_inicio_mes_ant = fecha_inicio_mes.AddMonths(-1); // fecha de inicio del mes anterior
                DateTime fecha_fin_mes = fecha_inicio_mes_ant.AddMonths(1).AddDays(-1); // fecha de fin de mes anterior

                DateTime fecha_inicio_2mes_ant = fecha_inicio_mes.AddMonths(-2); // fecha de inicio de 2 meses anteriores
                DateTime fecha_fin_2mes = fecha_inicio_2mes_ant.AddMonths(1).AddDays(-1); // fecha de fin de 2 meses anteriores

                //MessageBox.Show("mes pasado inicio: " + fecha_inicio_mes_ant.ToString() + " fin: " + fecha_fin_mes.ToString());
                //MessageBox.Show(" 2 meses anteriores inicio: " + fecha_inicio_2mes_ant.ToString() + " fin: " + fecha_fin_2mes.ToString());


                // foreach que va a elaborar las columnas x,y
                foreach (DataRow row in dt_negos_finalizados.Rows) // foreach que va a recorrer todo el dt_negos_finalizados para ir clasificando por meses y creando el nuevo datatable
                {
                    if (Convert.ToDateTime(row["fecha_est_cierre"].ToString()) >= Convert.ToDateTime(fecha_inicio_2mes_ant.ToString()) && Convert.ToDateTime(row["fecha_est_cierre"].ToString()) <= Convert.ToDateTime(fecha_fin_2mes.ToString())) // si la fecha de cierre esta entre inicio de mes y fin de mes de 2 meses antes entonces:
                    {
                        contador_negos_2ant_mes = contador_negos_2ant_mes + 1;
                        //contador_negos_2ant_mes = Convert.ToDouble(row["valor"]) + contador_negos_2ant_mes;



                    }

                    else if (Convert.ToDateTime(row["fecha_est_cierre"].ToString()) >= Convert.ToDateTime(fecha_inicio_mes_ant.ToString()) && Convert.ToDateTime(row["fecha_est_cierre"].ToString()) <= Convert.ToDateTime(fecha_fin_mes.ToString()))
                    {
                        contador_negos_ant_mes = contador_negos_ant_mes + 1;
                        //contador_negos_ant_mes = Convert.ToDouble(row["valor"]) + contador_negos_ant_mes;


                    }


                    else if (Convert.ToDateTime(row["fecha_est_cierre"].ToString()) >= Convert.ToDateTime(fecha_inicio_mes.ToString()) && Convert.ToDateTime(row["fecha_est_cierre"].ToString()) <= Convert.ToDateTime(hoy.ToString()))
                    {
                        contador_negos_este_mes = contador_negos_este_mes + 1;
                        //contador_negos_este_mes = Convert.ToDouble(row["valor"]) + contador_negos_este_mes;


                    }
                    N = N + 1; // valor N de la tabla

                }
                //MessageBox.Show(N.ToString());

                // relleno de la primera fila, mes ante-pasado
                //columna1["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(uno) + 1);
                columna1["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(uno) + 2);
                columna1["x"] = uno;
                columna1["y"] = contador_negos_2ant_mes;
                dt_nego_ganado_hijo.Rows.Add(columna1);

                // relleno de la segunda fila, mes pasado
                columna["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(dos) + 2);
                columna["x"] = dos;
                columna["y"] = contador_negos_ant_mes;
                dt_nego_ganado_hijo.Rows.Add(columna);

                // relleno de la tercera fila, este mes
                columna3["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(tres) + 2);
                columna3["x"] = tres;
                columna3["y"] = contador_negos_este_mes;
                dt_nego_ganado_hijo.Rows.Add(columna3);

                dgv_tabla_result.DataSource = dt_nego_ganado_hijo;


                // foreach que va a elaborar las columnas x2,y2,xy
                foreach (DataRow row_hijo in dt_nego_ganado_hijo.Rows)
                {
                    DataRow columna_x2 = dt_nego_ganado_hijo_complemento.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados


                    //columna_x2["x2"] = Convert.ToDouble( columna_x2["x"].ToString()) * Convert.ToDouble( columna_x2["x"].ToString());
                    //columna_x2["x2"] = columna_x2["x"].ToString() + columna_x2["x"].ToString();
                    //columna_x2["x2"] = row_hijo["x"].ToString() + row_hijo["x"].ToString();
                    xm = Convert.ToDouble(row_hijo["x"].ToString());
                    ym = Convert.ToDouble(row_hijo["y"].ToString());

                    xym = xm * ym;
                    x2m = xm * xm;
                    y2m = ym * ym;

                    columna_x2["x2"] = x2m.ToString();
                    columna_x2["y2"] = y2m.ToString();
                    columna_x2["xy"] = xym.ToString();

                    dt_nego_ganado_hijo_complemento.Rows.Add(columna_x2);



                    // sumatorias de "X" y "Y"
                    suma_x = Convert.ToDouble(row_hijo["x"]) + suma_x;
                    suma_y = Convert.ToDouble(row_hijo["y"]) + suma_y;


                    //MessageBox.Show("x: "+x + "y: "+ y);
                    //MessageBox.Show("x2: " + x2);
                }

                dgv_complemento.DataSource = dt_nego_ganado_hijo_complemento;
                //MessageBox.Show("sumatoria x: " + suma_x);
                //MessageBox.Show("sumatoria y: " + suma_y);


                // sumatoria de totales de dt_nego_ganado_hijo_complemento
                foreach (DataRow sum in dt_nego_ganado_hijo_complemento.Rows)
                {
                    suma_x2 = Convert.ToDouble(sum["x2"]) + suma_x2;
                    suma_y2 = Convert.ToDouble(sum["y2"]) + suma_y2;
                    suma_xy = Convert.ToDouble(sum["xy"]) + suma_xy;


                }
                //MessageBox.Show("sumatoria x2: "+suma_x2.ToString());
                //MessageBox.Show("sumatoria y2: "+suma_y2.ToString());
                //MessageBox.Show("sumatoria xy: "+suma_xy.ToString());



                // Obteniendo el Valor de "b":


                b = ((Convert.ToDouble(N) * Convert.ToDouble(suma_xy)) - (Convert.ToDouble(suma_x) * Convert.ToDouble(suma_y))) / ((N * Convert.ToDouble(suma_x2)) - (Convert.ToDouble(suma_x) * Convert.ToDouble(suma_x)));
                //MessageBox.Show("b: " + b.ToString("N4"));

                a = (Convert.ToDouble(suma_y) - (b * Convert.ToDouble(suma_x))) / N;
                //MessageBox.Show("a: " + a.ToString("N4"));

                //MessageBox.Show("Formula: y= a + bx   y="+a.ToString("N4") +" + "+b.ToString("N4") +"x");



                if (rbt_sig_trimestre.Checked)
                {
                    //rbt_siguiente_mes.Enabled = false;
                    //rbt_sig_anio.Enabled = false;

                    cont_meses = 4;

                    for (double i = cont_meses; cont_meses <= 6; cont_meses++)
                    {
                        y = a + b * (cont_meses);

                        DataRow nueva_fila = dt_nego_ganado_hijo.NewRow(); // nueva fila para insercion de complemento de x y Y

                        nueva_fila["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(cont_meses) + 2); //***********++ NOTA++******* SUMAR +2 EN MAYO +3 EN JUNIO
                        nueva_fila["x"] = cont_meses;
                        nueva_fila["y"] = y.ToString("N2");

                        dt_nego_ganado_hijo.Rows.Add(nueva_fila);

                        //MessageBox.Show(cont_meses +": "+  y.ToString("N3"));
                    }

                }

                // DECISIÓN PARA BOTON SELECCIONADO DE SIGUIENTE MES
                else if (rbt_siguiente_mes.Checked)
                {
                    //rbt_sig_trimestre.Enabled = false;
                    //rbt_sig_anio.Enabled = false;

                    cont_meses = 4;

                    for (double i = cont_meses; cont_meses <= 4; cont_meses++)
                    {
                        y = a + b * (cont_meses);

                        DataRow nueva_fila = dt_nego_ganado_hijo.NewRow(); // nueva fila para insercion de complemento de x y Y

                        nueva_fila["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(cont_meses) + 2);//***********++ NOTA++******* SUMAR +2 EN MAYO +3 EN JUNIO
                        nueva_fila["x"] = cont_meses;
                        nueva_fila["y"] = y.ToString("N2");

                        dt_nego_ganado_hijo.Rows.Add(nueva_fila);

                        //MessageBox.Show(cont_meses +": "+  y.ToString("N3"));
                    }

                }
                // DECISIÓN PARA BOTON SELECCIONADO DE SIGUIENTE AÑO
                else if (rbt_sig_anio.Checked)
                {
                    //rbt_sig_trimestre.Enabled = false;
                    //rbt_siguiente_mes.Enabled = false;

                    cont_meses = 4;

                    for (double i = cont_meses; cont_meses <= 10; cont_meses++) // CAMBIOS AQUI EL OTRO MES ES 9
                    {
                        y = a + b * (cont_meses);

                        DataRow nueva_fila = dt_nego_ganado_hijo.NewRow(); // nueva fila para insercion de complemento de x y Y

                        nueva_fila["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(cont_meses) + 2);//***********++ NOTA++******* SUMAR +2 EN MAYO +3 EN JUNIO
                        nueva_fila["x"] = cont_meses;
                        nueva_fila["y"] = y.ToString("N2");

                        dt_nego_ganado_hijo.Rows.Add(nueva_fila);

                        //MessageBox.Show(cont_meses +": "+  y.ToString("N3"));
                    }





                    dgv_tabla_result.DataSource = dt_nego_ganado_hijo;

                }
                else
                {
                    MessageBox.Show("Serie de tiempo no establecida");
                    // lo que hay que cambiar es la fecha de cierre de la factura para que haga los contadores correspondientes despues todo es igual
                }

                //} // fin de decision boton de radio si esta seleccionado la opcion de seleccionar

                // ***********************************************    INICIO DE AREA DE TRABAJO PARA GRAFICA DE NEGOCIOS ******************************************


                // Formato de grafico:
                grafica_principal.BackColor = Color.Transparent;
                grafica_principal.BorderOptions.Color = Color.Transparent;
                grafica_principal.Legend.BackColor = Color.Transparent;
                grafica_principal.Legend.Border.Color = Color.Transparent;



                // Asiganacion de series:
                Series series1 = new Series("Ventas en dinero", ViewType.Line);





                foreach (DataRow row_per in dt_nego_ganado_hijo.Rows) // Insercion de negocios en la grafica, que estan en proceso 
                {
                    series1.Points.Add(new SeriesPoint(row_per["nom_mes"].ToString(), row_per["y"].ToString()));
                }
                grafica_principal.Series.Add(series1);




                series1.ArgumentScaleType = ScaleType.Auto;




                //((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle; // marcador de triangulo
                ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;



                //((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada
                ((LineSeriesView)series1.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida


                ((LineSeriesView)series1.View).Color = Color.YellowGreen; // linea solida proceso

                ((XYDiagram)grafica_principal.Diagram).EnableAxisXZooming = false;



                grafica_principal.Legend.Visible = true;

                // Titulo:
                grafica_principal.Titles.Add(new ChartTitle());
                grafica_principal.Titles[0].Text = "Grafica de proyección";

                // Add the chart to the form.
                grafica_principal.Dock = DockStyle.Fill;
                ctc_pronostico.Controls.Add(grafica_principal);


            } // llave que cierra "if" correspondiente a los negocios


            else if (cmb_clasificacion.Text == "Ventas") // ************************************************** AREA DE VENTAS
            {
                //MessageBox.Show("Area de ventas");

                // inicializacion de variables
                dt_nego_ganado_hijo.Clear();
                dt_nego_ganado_hijo_complemento.Clear();
                dgv_complemento.DataSource = "";
                dgv_tabla_result.DataSource = "";
                cont_meses = 0;
                grafica_principal.Series.Clear();
                grafica_principal.Titles.Clear();

                suma_x2 = 0;
                suma_y2 = 0;
                suma_xy = 0;
                suma_x = 0;
                suma_y = 0;

                b = 0;
                a = 0;
                y = 0;

                contador_negos_2ant_mes = 0;
                contador_negos_ant_mes = 0;
                contador_negos_este_mes = 0;

                //uno = "1";
                //dos = "2";
                //tres = "3";
                N = 1;

                xm = 0;
                ym = 0;
                x2m = 0;
                y2m = 0;
                xym = 0;

                //if (rbt_seleccionar_categoria.Checked)
                //{ 
                DataRow columna1 = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados
                DataRow columna = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados
                DataRow columna3 = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados

                //DataRow columna_x2 = dt_nego_ganado_hijo.NewRow(); // columna x2, 1,3


                DateTime fecha_inicio_mes_ant = fecha_inicio_mes.AddMonths(-1); // fecha de inicio del mes anterior
                DateTime fecha_fin_mes = fecha_inicio_mes_ant.AddMonths(1).AddDays(-1); // fecha de fin de mes anterior

                DateTime fecha_inicio_2mes_ant = fecha_inicio_mes.AddMonths(-2); // fecha de inicio de 2 meses anteriores
                DateTime fecha_fin_2mes = fecha_inicio_2mes_ant.AddMonths(1).AddDays(-1); // fecha de fin de 2 meses anteriores

                //MessageBox.Show("mes pasado inicio: " + fecha_inicio_mes_ant.ToString() + " fin: " + fecha_fin_mes.ToString());
                //MessageBox.Show(" 2 meses anteriores inicio: " + fecha_inicio_2mes_ant.ToString() + " fin: " + fecha_fin_2mes.ToString());


                // foreach que va a elaborar las columnas x,y
                foreach (DataRow row in dt_negos_finalizados.Rows) // foreach que va a recorrer todo el dt_negos_finalizados para ir clasificando por meses y creando el nuevo datatable
                {
                    if (Convert.ToDateTime(row["fecha"].ToString()) >= Convert.ToDateTime(fecha_inicio_2mes_ant.ToString()) && Convert.ToDateTime(row["fecha"].ToString()) <= Convert.ToDateTime(fecha_fin_2mes.ToString())) // si la fecha de cierre esta entre inicio de mes y fin de mes de 2 meses antes entonces:
                    {
                        contador_negos_2ant_mes = contador_negos_2ant_mes + 1;
                        //contador_negos_2ant_mes = Convert.ToDouble(row["valor"]) + contador_negos_2ant_mes;



                    }

                    else if (Convert.ToDateTime(row["fecha"].ToString()) >= Convert.ToDateTime(fecha_inicio_mes_ant.ToString()) && Convert.ToDateTime(row["fecha"].ToString()) <= Convert.ToDateTime(fecha_fin_mes.ToString()))
                    {
                        contador_negos_ant_mes = contador_negos_ant_mes + 1;
                        //contador_negos_ant_mes = Convert.ToDouble(row["valor"]) + contador_negos_ant_mes;


                    }


                    else if (Convert.ToDateTime(row["fecha"].ToString()) >= Convert.ToDateTime(fecha_inicio_mes.ToString()) && Convert.ToDateTime(row["fecha"].ToString()) <= Convert.ToDateTime(hoy.ToString()))
                    {
                        contador_negos_este_mes = contador_negos_este_mes + 1;
                        //contador_negos_este_mes = Convert.ToDouble(row["valor"]) + contador_negos_este_mes;


                    }
                    N = N + 1; // valor N de la tabla

                }
                //MessageBox.Show(N.ToString());

                // relleno de la primera fila, mes ante-pasado
                //columna1["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(uno) + 1);
                columna1["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(uno) + 2);
                columna1["x"] = uno;
                columna1["y"] = contador_negos_2ant_mes;
                dt_nego_ganado_hijo.Rows.Add(columna1);

                // relleno de la segunda fila, mes pasado
                columna["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(dos) + 2);
                columna["x"] = dos;
                columna["y"] = contador_negos_ant_mes;
                dt_nego_ganado_hijo.Rows.Add(columna);

                // relleno de la tercera fila, este mes
                columna3["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(tres) + 2);
                columna3["x"] = tres;
                columna3["y"] = contador_negos_este_mes;
                dt_nego_ganado_hijo.Rows.Add(columna3);

                dgv_tabla_result.DataSource = dt_nego_ganado_hijo;


                // foreach que va a elaborar las columnas x2,y2,xy
                foreach (DataRow row_hijo in dt_nego_ganado_hijo.Rows)
                {
                    DataRow columna_x2 = dt_nego_ganado_hijo_complemento.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados


                    //columna_x2["x2"] = Convert.ToDouble( columna_x2["x"].ToString()) * Convert.ToDouble( columna_x2["x"].ToString());
                    //columna_x2["x2"] = columna_x2["x"].ToString() + columna_x2["x"].ToString();
                    //columna_x2["x2"] = row_hijo["x"].ToString() + row_hijo["x"].ToString();
                    xm = Convert.ToDouble(row_hijo["x"].ToString());
                    ym = Convert.ToDouble(row_hijo["y"].ToString());

                    xym = xm * ym;
                    x2m = xm * xm;
                    y2m = ym * ym;

                    columna_x2["x2"] = x2m.ToString();
                    columna_x2["y2"] = y2m.ToString();
                    columna_x2["xy"] = xym.ToString();

                    dt_nego_ganado_hijo_complemento.Rows.Add(columna_x2);



                    // sumatorias de "X" y "Y"
                    suma_x = Convert.ToDouble(row_hijo["x"]) + suma_x;
                    suma_y = Convert.ToDouble(row_hijo["y"]) + suma_y;


                    //MessageBox.Show("x: "+x + "y: "+ y);
                    //MessageBox.Show("x2: " + x2);
                }

                dgv_complemento.DataSource = dt_nego_ganado_hijo_complemento;
                //MessageBox.Show("sumatoria x: " + suma_x);
                //MessageBox.Show("sumatoria y: " + suma_y);


                // sumatoria de totales de dt_nego_ganado_hijo_complemento
                foreach (DataRow sum in dt_nego_ganado_hijo_complemento.Rows)
                {
                    suma_x2 = Convert.ToDouble(sum["x2"]) + suma_x2;
                    suma_y2 = Convert.ToDouble(sum["y2"]) + suma_y2;
                    suma_xy = Convert.ToDouble(sum["xy"]) + suma_xy;


                }
                //MessageBox.Show("sumatoria x2: "+suma_x2.ToString());
                //MessageBox.Show("sumatoria y2: "+suma_y2.ToString());
                //MessageBox.Show("sumatoria xy: "+suma_xy.ToString());



                // Obteniendo el Valor de "b":


                b = ((Convert.ToDouble(N) * Convert.ToDouble(suma_xy)) - (Convert.ToDouble(suma_x) * Convert.ToDouble(suma_y))) / ((N * Convert.ToDouble(suma_x2)) - (Convert.ToDouble(suma_x) * Convert.ToDouble(suma_x)));
                //MessageBox.Show("b: " + b.ToString("N4"));

                a = (Convert.ToDouble(suma_y) - (b * Convert.ToDouble(suma_x))) / N;
                //MessageBox.Show("a: " + a.ToString("N4"));

                //MessageBox.Show("Formula: y= a + bx   y="+a.ToString("N4") +" + "+b.ToString("N4") +"x");



                if (rbt_sig_trimestre.Checked)
                {
                    //rbt_siguiente_mes.Enabled = false;
                    //rbt_sig_anio.Enabled = false;

                    cont_meses = 4;

                    for (double i = cont_meses; cont_meses <= 6; cont_meses++)
                    {
                        y = a + b * (cont_meses);

                        DataRow nueva_fila = dt_nego_ganado_hijo.NewRow(); // nueva fila para insercion de complemento de x y Y

                        nueva_fila["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(cont_meses) + 2); //***********++ NOTA++******* SUMAR +2 EN MAYO +3 EN JUNIO
                        nueva_fila["x"] = cont_meses;
                        nueva_fila["y"] = y.ToString("N2");

                        dt_nego_ganado_hijo.Rows.Add(nueva_fila);

                        //MessageBox.Show(cont_meses +": "+  y.ToString("N3"));
                    }

                }

                // DECISIÓN PARA BOTON SELECCIONADO DE SIGUIENTE MES
                else if (rbt_siguiente_mes.Checked)
                {
                    //rbt_sig_trimestre.Enabled = false;
                    //rbt_sig_anio.Enabled = false;

                    cont_meses = 4;

                    for (double i = cont_meses; cont_meses <= 4; cont_meses++)
                    {
                        y = a + b * (cont_meses);

                        DataRow nueva_fila = dt_nego_ganado_hijo.NewRow(); // nueva fila para insercion de complemento de x y Y

                        nueva_fila["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(cont_meses) + 2);//***********++ NOTA++******* SUMAR +2 EN MAYO +3 EN JUNIO
                        nueva_fila["x"] = cont_meses;
                        nueva_fila["y"] = y.ToString("N2");

                        dt_nego_ganado_hijo.Rows.Add(nueva_fila);

                        //MessageBox.Show(cont_meses +": "+  y.ToString("N3"));
                    }

                }
                // DECISIÓN PARA BOTON SELECCIONADO DE SIGUIENTE AÑO
                else if (rbt_sig_anio.Checked)
                {
                    //rbt_sig_trimestre.Enabled = false;
                    //rbt_siguiente_mes.Enabled = false;

                    cont_meses = 4;

                    for (double i = cont_meses; cont_meses <= 10; cont_meses++) // CAMBIOS AQUI EL OTRO MES ES 9
                    {
                        y = a + b * (cont_meses);

                        DataRow nueva_fila = dt_nego_ganado_hijo.NewRow(); // nueva fila para insercion de complemento de x y Y

                        nueva_fila["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(cont_meses) + 2);//***********++ NOTA++******* SUMAR +2 EN MAYO +3 EN JUNIO
                        nueva_fila["x"] = cont_meses;
                        nueva_fila["y"] = y.ToString("N2");

                        dt_nego_ganado_hijo.Rows.Add(nueva_fila);

                        //MessageBox.Show(cont_meses +": "+  y.ToString("N3"));
                    }





                    dgv_tabla_result.DataSource = dt_nego_ganado_hijo;

                }
                else
                {
                    MessageBox.Show("Serie de tiempo no establecida");
                    // lo que hay que cambiar es la fecha de cierre de la factura para que haga los contadores correspondientes despues todo es igual
                }

                //} // fin de decision boton de radio si esta seleccionado la opcion de seleccionar

                // ***********************************************    INICIO DE AREA DE TRABAJO PARA GRAFICA DE NEGOCIOS ******************************************


                // Formato de grafico:
                grafica_principal.BackColor = Color.Transparent;
                grafica_principal.BorderOptions.Color = Color.Transparent;
                grafica_principal.Legend.BackColor = Color.Transparent;
                grafica_principal.Legend.Border.Color = Color.Transparent;



                // Asiganacion de series:
                Series series1 = new Series("Ventas en dinero", ViewType.Line);





                foreach (DataRow row_per in dt_nego_ganado_hijo.Rows) // Insercion de negocios en la grafica, que estan en proceso 
                {
                    series1.Points.Add(new SeriesPoint(row_per["nom_mes"].ToString(), row_per["y"].ToString()));
                }
                grafica_principal.Series.Add(series1);




                series1.ArgumentScaleType = ScaleType.Auto;




                //((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle; // marcador de triangulo
                ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;



                //((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada
                ((LineSeriesView)series1.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; // linea solida


                ((LineSeriesView)series1.View).Color = Color.YellowGreen; // linea solida proceso

                ((XYDiagram)grafica_principal.Diagram).EnableAxisXZooming = false;



                grafica_principal.Legend.Visible = true;

                // Titulo:
                grafica_principal.Titles.Add(new ChartTitle());
                grafica_principal.Titles[0].Text = "Grafica de proyección";

                // Add the chart to the form.
                grafica_principal.Dock = DockStyle.Fill;
                ctc_pronostico.Controls.Add(grafica_principal);



            }


        }


        // LOAD DE PRONOSTICO VENTAS-NEGOCIOS
        private void frm_pronostico_ventas_secundario_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            //btn_promedio_moviles.Enabled = false;
            btn_pronosticar.Enabled = false;
            cmb_categoria.Enabled = false;
            cmb_clasificacion.Enabled = false;
            rbt_seleccionar_categoria.Enabled = false;
            rbt_siguiente_mes.Enabled = false;
            rbt_sig_anio.Enabled = false;
            rbt_sig_trimestre.Enabled = false;
                
            
            
            // creacion de nuevo datatable hijo de negocios ganados
            DataColumn column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "nom_mes";
            dt_nego_ganado_hijo.Columns.Add(column_nego_ganados);

            column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "x"; // num de mes
            dt_nego_ganado_hijo.Columns.Add(column_nego_ganados);


            column_nego_ganados = new DataColumn();
            column_nego_ganados.DataType = System.Type.GetType("System.String");
            column_nego_ganados.ColumnName = "y"; // cant de negocios ganados
            dt_nego_ganado_hijo.Columns.Add(column_nego_ganados);


            // creacion de nuevo datatable hijo de negocios ganados complemento
            DataColumn column_nego_ganados_complento = new DataColumn();
            column_nego_ganados_complento = new DataColumn();
            column_nego_ganados_complento.DataType = System.Type.GetType("System.String");
            column_nego_ganados_complento.ColumnName = "x2";
            dt_nego_ganado_hijo_complemento.Columns.Add(column_nego_ganados_complento);

            column_nego_ganados_complento = new DataColumn();
            column_nego_ganados_complento.DataType = System.Type.GetType("System.String");
            column_nego_ganados_complento.ColumnName = "y2";
            dt_nego_ganado_hijo_complemento.Columns.Add(column_nego_ganados_complento);

            column_nego_ganados_complento = new DataColumn();
            column_nego_ganados_complento.DataType = System.Type.GetType("System.String");
            column_nego_ganados_complento.ColumnName = "xy";
            dt_nego_ganado_hijo_complemento.Columns.Add(column_nego_ganados_complento);
        }

        private void cmb_metodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        // BOTON DE PROMEDIOS MOVILES:

        private void btn_promedio_moviles_Click(object sender, EventArgs e)
        {
            if (cmb_clasificacion_p_movil.Text == "Negocios")
            {
                // inicializacion de variables
                dt_nego_ganado_hijo.Clear();
                dt_nego_ganado_hijo_complemento.Clear();
                dgv_complemento.DataSource = "";
                dgv_tabla_result.DataSource = "";
                cont_meses = 0;
                grafica_principal.Series.Clear();
                grafica_principal.Titles.Clear();

                suma_x2 = 0;
                suma_y2 = 0;
                suma_xy = 0;
                suma_x = 0;
                suma_y = 0;

                b = 0;
                a = 0;
                y = 0;

                contador_negos_2ant_mes = 0;
                contador_negos_ant_mes = 0;
                contador_negos_este_mes = 0;

                //uno = "1";
                //dos = "2";
                //tres = "3";
                N = 1;

                xm = 0;
                ym = 0;
                x2m = 0;
                y2m = 0;
                xym = 0;

                //if (rbt_seleccionar_categoria.Checked)
                //{ 
                DataRow columna1 = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados
                DataRow columna = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados
                DataRow columna3 = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados

                //DataRow columna_x2 = dt_nego_ganado_hijo.NewRow(); // columna x2, 1,3


                DateTime fecha_inicio_mes_ant = fecha_inicio_mes.AddMonths(-1); // fecha de inicio del mes anterior
                DateTime fecha_fin_mes = fecha_inicio_mes_ant.AddMonths(1).AddDays(-1); // fecha de fin de mes anterior

                DateTime fecha_inicio_2mes_ant = fecha_inicio_mes.AddMonths(-2); // fecha de inicio de 2 meses anteriores
                DateTime fecha_fin_2mes = fecha_inicio_2mes_ant.AddMonths(1).AddDays(-1); // fecha de fin de 2 meses anteriores

                //MessageBox.Show("mes pasado inicio: " + fecha_inicio_mes_ant.ToString() + " fin: " + fecha_fin_mes.ToString());
                //MessageBox.Show(" 2 meses anteriores inicio: " + fecha_inicio_2mes_ant.ToString() + " fin: " + fecha_fin_2mes.ToString());


                // foreach que va a elaborar las columnas x,y
                foreach (DataRow row in dt_negos_finalizados.Rows) // foreach que va a recorrer todo el dt_negos_finalizados para ir clasificando por meses y creando el nuevo datatable
                {
                    if (Convert.ToDateTime(row["fecha_est_cierre"].ToString()) >= Convert.ToDateTime(fecha_inicio_2mes_ant.ToString()) && Convert.ToDateTime(row["fecha_est_cierre"].ToString()) <= Convert.ToDateTime(fecha_fin_2mes.ToString()))
                    {
                        contador_negos_2ant_mes = contador_negos_2ant_mes + 1;
                        //contador_negos_2ant_mes = Convert.ToDouble(row["valor"]) + contador_negos_2ant_mes;



                    }

                    else if (Convert.ToDateTime(row["fecha_est_cierre"].ToString()) >= Convert.ToDateTime(fecha_inicio_mes_ant.ToString()) && Convert.ToDateTime(row["fecha_est_cierre"].ToString()) <= Convert.ToDateTime(fecha_fin_mes.ToString()))
                    {
                        contador_negos_ant_mes = contador_negos_ant_mes + 1;
                        //contador_negos_ant_mes = Convert.ToDouble(row["valor"]) + contador_negos_ant_mes;


                    }


                    else if (Convert.ToDateTime(row["fecha_est_cierre"].ToString()) >= Convert.ToDateTime(fecha_inicio_mes.ToString()) && Convert.ToDateTime(row["fecha_est_cierre"].ToString()) <= Convert.ToDateTime(hoy.ToString()))
                    {
                        contador_negos_este_mes = contador_negos_este_mes + 1;
                        //contador_negos_este_mes = Convert.ToDouble(row["valor"]) + contador_negos_este_mes;


                    }
                    N = N + 1; // valor N de la tabla

                }
                //MessageBox.Show(N.ToString());

                // relleno de la primera fila, mes ante-pasado
                columna1["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(uno) + 2);
                columna1["x"] = uno;
                columna1["y"] = contador_negos_2ant_mes;
                dt_nego_ganado_hijo.Rows.Add(columna1);

                // relleno de la segunda fila, mes pasado
                columna["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(dos) + 2);
                columna["x"] = dos;
                columna["y"] = contador_negos_ant_mes;
                dt_nego_ganado_hijo.Rows.Add(columna);

                // relleno de la tercera fila, este mes
                columna3["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(tres) + 2);
                columna3["x"] = tres;
                columna3["y"] = contador_negos_este_mes;
                dt_nego_ganado_hijo.Rows.Add(columna3);

                dgv_tabla_result.DataSource = dt_nego_ganado_hijo;


                // ******************************** Area de tabla de promedios moviles para graficar: 

                DataRow nueva_fila_moviles = dt_nego_ganado_hijo.NewRow();

                suma_y = 0;
                foreach (DataRow rwo in dt_nego_ganado_hijo.Rows)
                {

                    suma_y = Convert.ToDouble(rwo["y"]) + suma_y;
                }
                divi = suma_y / 3;



                //nueva_fila_moviles["nom_mes"] = nombre_mes.nombre_mes(5); // el siguiente mes hay que cambiarlo a 6 para que sea junio
                nueva_fila_moviles["nom_mes"] = nombre_mes.nombre_mes(6); // el siguiente mes hay que cambiarlo a 7 para que sea julio
                nueva_fila_moviles["x"] = Convert.ToInt32(tres) + 1;
                nueva_fila_moviles["y"] = divi.ToString("N2");

                dt_nego_ganado_hijo.Rows.Add(nueva_fila_moviles);
                dgv_tabla_result.DataSource = dt_nego_ganado_hijo;






                // ***********************************************    INICIO DE AREA DE TRABAJO PARA GRAFICA DE NEGOCIOS ******************************************


                // Formato de grafico:
                grafica_principal.BackColor = Color.Transparent;
                grafica_principal.BorderOptions.Color = Color.Transparent;
                grafica_principal.Legend.BackColor = Color.Transparent;
                grafica_principal.Legend.Border.Color = Color.Transparent;



                // Asiganacion de series:
                Series series1 = new Series("Ventas", ViewType.Line);





                foreach (DataRow row_per in dt_nego_ganado_hijo.Rows) // Insercion de negocios en la grafica, que estan en proceso 
                {
                    series1.Points.Add(new SeriesPoint(row_per["nom_mes"].ToString(), row_per["y"].ToString()));
                }
                grafica_principal.Series.Add(series1);




                series1.ArgumentScaleType = ScaleType.Auto;




                //((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle; // marcador de triangulo
                ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Plus;



                //((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada
                ((LineSeriesView)series1.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped; // linea solida


                ((LineSeriesView)series1.View).Color = Color.YellowGreen; // linea solida proceso

                ((XYDiagram)grafica_principal.Diagram).EnableAxisXZooming = false;



                grafica_principal.Legend.Visible = true;

                // Titulo:
                grafica_principal.Titles.Add(new ChartTitle());
                grafica_principal.Titles[0].Text = "Grafica de proyección";

                // Add the chart to the form.
                grafica_principal.Dock = DockStyle.Fill;
                ctc_pronostico.Controls.Add(grafica_principal);


            }// finalizacion de if de negocios
            else if (cmb_clasificacion_p_movil.Text == "Ventas") // ************************************************** AREA DE VENTAS
            {

                // inicializacion de variables
                dt_nego_ganado_hijo.Clear();
                dt_nego_ganado_hijo_complemento.Clear();
                dgv_complemento.DataSource = "";
                dgv_tabla_result.DataSource = "";
                cont_meses = 0;
                grafica_principal.Series.Clear();
                grafica_principal.Titles.Clear();

                suma_x2 = 0;
                suma_y2 = 0;
                suma_xy = 0;
                suma_x = 0;
                suma_y = 0;

                b = 0;
                a = 0;
                y = 0;

                contador_negos_2ant_mes = 0;
                contador_negos_ant_mes = 0;
                contador_negos_este_mes = 0;

                //uno = "1";
                //dos = "2";
                //tres = "3";
                N = 1;

                xm = 0;
                ym = 0;
                x2m = 0;
                y2m = 0;
                xym = 0;

                //if (rbt_seleccionar_categoria.Checked)
                //{ 
                DataRow columna1 = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados
                DataRow columna = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados
                DataRow columna3 = dt_nego_ganado_hijo.NewRow(); // llamada a columna de dt de dt creado hijo de negos ganados

                //DataRow columna_x2 = dt_nego_ganado_hijo.NewRow(); // columna x2, 1,3


                DateTime fecha_inicio_mes_ant = fecha_inicio_mes.AddMonths(-1); // fecha de inicio del mes anterior
                DateTime fecha_fin_mes = fecha_inicio_mes_ant.AddMonths(1).AddDays(-1); // fecha de fin de mes anterior

                DateTime fecha_inicio_2mes_ant = fecha_inicio_mes.AddMonths(-2); // fecha de inicio de 2 meses anteriores
                DateTime fecha_fin_2mes = fecha_inicio_2mes_ant.AddMonths(1).AddDays(-1); // fecha de fin de 2 meses anteriores

                //MessageBox.Show("mes pasado inicio: " + fecha_inicio_mes_ant.ToString() + " fin: " + fecha_fin_mes.ToString());
                //MessageBox.Show(" 2 meses anteriores inicio: " + fecha_inicio_2mes_ant.ToString() + " fin: " + fecha_fin_2mes.ToString());


                // foreach que va a elaborar las columnas x,y
                foreach (DataRow row in dt_negos_finalizados.Rows) // foreach que va a recorrer todo el dt_negos_finalizados para ir clasificando por meses y creando el nuevo datatable
                {
                    if (Convert.ToDateTime(row["fecha"].ToString()) >= Convert.ToDateTime(fecha_inicio_2mes_ant.ToString()) && Convert.ToDateTime(row["fecha"].ToString()) <= Convert.ToDateTime(fecha_fin_2mes.ToString()))
                    {
                        contador_negos_2ant_mes = contador_negos_2ant_mes + 1;
                        //contador_negos_2ant_mes = Convert.ToDouble(row["valor"]) + contador_negos_2ant_mes;



                    }

                    else if (Convert.ToDateTime(row["fecha"].ToString()) >= Convert.ToDateTime(fecha_inicio_mes_ant.ToString()) && Convert.ToDateTime(row["fecha"].ToString()) <= Convert.ToDateTime(fecha_fin_mes.ToString()))
                    {
                        contador_negos_ant_mes = contador_negos_ant_mes + 1;
                        //contador_negos_ant_mes = Convert.ToDouble(row["valor"]) + contador_negos_ant_mes;


                    }


                    else if (Convert.ToDateTime(row["fecha"].ToString()) >= Convert.ToDateTime(fecha_inicio_mes.ToString()) && Convert.ToDateTime(row["fecha"].ToString()) <= Convert.ToDateTime(hoy.ToString()))
                    {
                        contador_negos_este_mes = contador_negos_este_mes + 1;
                        //contador_negos_este_mes = Convert.ToDouble(row["valor"]) + contador_negos_este_mes;


                    }
                    N = N + 1; // valor N de la tabla

                }
                //MessageBox.Show(N.ToString());

                // relleno de la primera fila, mes ante-pasado
                columna1["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(uno) + 2);
                columna1["x"] = uno;
                columna1["y"] = contador_negos_2ant_mes;
                dt_nego_ganado_hijo.Rows.Add(columna1);

                // relleno de la segunda fila, mes pasado
                columna["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(dos) + 2);
                columna["x"] = dos;
                columna["y"] = contador_negos_ant_mes;
                dt_nego_ganado_hijo.Rows.Add(columna);

                // relleno de la tercera fila, este mes
                columna3["nom_mes"] = nombre_mes.nombre_mes(Convert.ToInt32(tres) + 2);
                columna3["x"] = tres;
                columna3["y"] = contador_negos_este_mes;
                dt_nego_ganado_hijo.Rows.Add(columna3);

                dgv_tabla_result.DataSource = dt_nego_ganado_hijo;


                // ******************************** Area de tabla de promedios moviles para graficar: 

                DataRow nueva_fila_moviles = dt_nego_ganado_hijo.NewRow();

                suma_y = 0;
                foreach (DataRow rwo in dt_nego_ganado_hijo.Rows)
                {

                    suma_y = Convert.ToDouble(rwo["y"]) + suma_y;
                }
                divi = suma_y / 3;



                //nueva_fila_moviles["nom_mes"] = nombre_mes.nombre_mes(5); // el siguiente mes hay que cambiarlo a 6 para que sea junio
                nueva_fila_moviles["nom_mes"] = nombre_mes.nombre_mes(6); // el siguiente mes hay que cambiarlo a 7 para que sea julio
                nueva_fila_moviles["x"] = Convert.ToInt32(tres) + 1;
                nueva_fila_moviles["y"] = divi.ToString("N2");

                dt_nego_ganado_hijo.Rows.Add(nueva_fila_moviles);
                dgv_tabla_result.DataSource = dt_nego_ganado_hijo;






                // ***********************************************    INICIO DE AREA DE TRABAJO PARA GRAFICA DE NEGOCIOS ******************************************


                // Formato de grafico:
                grafica_principal.BackColor = Color.Transparent;
                grafica_principal.BorderOptions.Color = Color.Transparent;
                grafica_principal.Legend.BackColor = Color.Transparent;
                grafica_principal.Legend.Border.Color = Color.Transparent;



                // Asiganacion de series:
                Series series1 = new Series("Ventas", ViewType.Line);





                foreach (DataRow row_per in dt_nego_ganado_hijo.Rows) // Insercion de negocios en la grafica, que estan en proceso 
                {
                    series1.Points.Add(new SeriesPoint(row_per["nom_mes"].ToString(), row_per["y"].ToString()));
                }
                grafica_principal.Series.Add(series1);




                series1.ArgumentScaleType = ScaleType.Auto;




                //((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle; // marcador de triangulo
                ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Plus;



                //((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash; // linea punteada
                ((LineSeriesView)series1.View).LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped; // linea solida


                ((LineSeriesView)series1.View).Color = Color.YellowGreen; // linea solida proceso

                ((XYDiagram)grafica_principal.Diagram).EnableAxisXZooming = false;



                grafica_principal.Legend.Visible = true;

                // Titulo:
                grafica_principal.Titles.Add(new ChartTitle());
                grafica_principal.Titles[0].Text = "Grafica de proyección";

                // Add the chart to the form.
                grafica_principal.Dock = DockStyle.Fill;
                ctc_pronostico.Controls.Add(grafica_principal);

            }

            }



        // PROMEDIOS MOVILES:

        private void cmb_clasificacion_p_movil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmb_clasificacion_p_movil.SelectedItem.ToString() == "Negocios")
            //{
            //    dt_cat_negos = capadatos.seleccionar_cat_negos();
            //    cmb_categoria_p_movil.DataSource = dt_cat_negos;
            //    cmb_categoria_p_movil.ValueMember = "id_cat";
            //    cmb_categoria_p_movil.DisplayMember = "nombre_cat";

            //}
            if (cmb_clasificacion_p_movil.SelectedItem.ToString() == "Negocios")
            {
                rbt_todos_categoria.Enabled = true;
                cmb_categoria_p_movil.Enabled = true;

                dt_cat_negos = capadatos.seleccionar_cat_negos();

                cmb_categoria_p_movil.DataSource = dt_cat_negos;
                cmb_categoria_p_movil.ValueMember = "id_cat";
                cmb_categoria_p_movil.DisplayMember = "nombre_cat";

            }
            else if (cmb_clasificacion_p_movil.SelectedItem.ToString() == "Ventas")
            {
                gridView1.Columns.Clear();
                //// bloquear opciones de escoger categorias
                cmb_categoria_p_movil.Enabled = false;
                cmb_categoria_p_movil.Enabled = false;
                //// mando a llamar todos los datos a la BD de la tabla encabezado de factura
                dgv_tabla_result.DataSource = "";
                dgv_complemento.DataSource = "";
                dt_cat_negos.Clear();
                cmb_categoria_p_movil.DisplayMember = "";
                dt_negos_finalizados.Clear();
                dt_negos_finalizados = capadatos.seleccionar_ventas_historial_general();
                dgv_consulta_negos_ventas.DataSource = dt_negos_finalizados;
                dgv_detalle.DataSource = dt_negos_finalizados;




                gridView1.Columns["fecha"].Caption = "Fecha";
                gridView1.Columns["forma_pago"].Caption = "Tipo de pago";
                gridView1.Columns["total"].Caption = "Valor";

                //// mandar a cargar los gridviews con los totales de las facturas
            }
        }

        private void cmb_categoria_p_movil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //id_nego_venta = cmb_categoria.SelectedValue.ToString(); // id de la categoria que va a ser enviada al dt para almacenar negocios por fecha
            //MessageBox.Show(id_nego_venta);

            if (cmb_clasificacion_p_movil.SelectedItem.ToString() == "" || cmb_clasificacion_p_movil.SelectedItem.ToString() == "System.Data.DataRowView")
            {

            }
            else if (cmb_clasificacion_p_movil.SelectedItem.ToString() == "Negocios")
            {
                gridView1.Columns.Clear();
                id_nego_venta = cmb_categoria_p_movil.SelectedValue.ToString(); // id de la categoria que va a ser enviada al dt para almacenar negocios por fecha
                //MessageBox.Show(id_nego_venta);


                dt_negos_finalizados = capadatos.seleccionar_negos_historial(id_nego_venta); // envio de solicitud a la cantidad de productos vendidos segun producto seleccionado
                dgv_consulta_negos_ventas.DataSource = dt_negos_finalizados;
                dgv_detalle.DataSource = dt_negos_finalizados;

                gridView1.Columns["nombre_cat"].Caption = "Categoria";
                gridView1.Columns["titulo"].Caption = "Titulo";
                gridView1.Columns["valor"].Caption = "Valor";
                gridView1.Columns["fecha_est_cierre"].Caption = "Finalización";
                gridView1.Columns["nombre"].Caption = "Empresa";
                gridView1.Columns["nombres"].Caption = "Usuario";
                gridView1.Columns["apellidos"].Caption = "Apellido";
                gridView1.Columns["id_negocio"].Visible = false;
                gridView1.Columns["id_cat"].Visible = false;



            }
        }

        private void rbt_categproa_p_movil_todos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_categproa_p_movil_todos.Enabled)
            {
                cmb_categoria.Enabled = false;
            }


            dgv_consulta_negos_ventas.DataSource = ""; // limpieza de dtgrid de prueba
            dt_negos_finalizados.Clear(); // limpieza de dtable de negocios para ir a seleccionar todos los negocios sin excepcion, que tengan estado de ganado

            if (cmb_clasificacion_p_movil.SelectedItem.ToString() == "Negocios")
            {
                dt_negos_finalizados = capadatos.seleccionar_negos_historial_general(); // envio de solicitud a la cantidad de negocios vendidos en general 
                dgv_consulta_negos_ventas.DataSource = dt_negos_finalizados;
                dgv_detalle.DataSource = dt_negos_finalizados;

                gridView1.Columns["nombre_cat"].Caption = "Categoria";
                gridView1.Columns["titulo"].Caption = "Titulo";
                gridView1.Columns["valor"].Caption = "Valor";
                gridView1.Columns["fecha_est_cierre"].Caption = "Finalización";
                gridView1.Columns["nombre"].Caption = "Empresa";
                gridView1.Columns["nombres"].Caption = "Usuario";
                gridView1.Columns["apellidos"].Caption = "Apellido";
                gridView1.Columns["id_negocio"].Visible = false;
                gridView1.Columns["id_cat"].Visible = false;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
