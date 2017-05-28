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
using DevExpress.XtraGrid.Views.Grid;


namespace crm
{
    public partial class frm_NuevoCaso : Form
    {
        public frm_NuevoCaso()
        {
            InitializeComponent();
        }
        string id_form = "110";
        CapaDatosPersonas peticionescapa = new CapaDatosPersonas();
        OpBD o = new OpBD();
        string fecha = "";
        string open = "Abierto";
        string close = "Cerrado";
        string estado = "";
        string var_idcaso="";

        public bool actualizar;


        public string id_caso_e;
        public string titulo_e;
        public string persona_e;
        public string empresa_e;
        public string fecha_fin_e;
        public string categoria_e;

        // formulario de Nuevo Caso
        private void frm_NuevoCaso_Load(object sender, EventArgs e)
        {
            try
            {

                //CapaNegocio fn = new CapaNegocio();
                //DataTable seg = seguridad.ObtenerPermisos.Permisos(seguridad.Conexion.User, id_form);
                //if (seg.Rows.Count > 0)
                //{
                //    fn.desactivarPermiso(seg, btn_guardar, btn_eliminar, btn_editar, btn_nuevo, btn_cancelar, btn_actualizar, btn_buscar, btn_anterior, btn_siguiente, btn_primero, btn_ultimo);
                //}
                //else
                //{
                //    btn_guardar.Enabled = false; btn_eliminar.Enabled = false; btn_editar.Enabled = false; btn_nuevo.Enabled = false; btn_actualizar.Enabled = false; btn_cancelar.Enabled = false; btn_buscar.Enabled = false;
                //}


                // Cargar combo box de categoria de casos
                //DataTable dt_categoria_casos = new DataTable();
                //dt_categoria_casos = peticionescapa.cargar_categoria_caso();
                //cmb_categoria.DataSource = dt_categoria_casos;
                //cmb_categoria.ValueMember = "id_cat_caso";
                //cmb_categoria.DisplayMember = "nombre_caso";

                //LLENAR CATEGORIAS
                DataTable dt_catcaso = OpBD.SeleccionarCategoriasCaso();
                if(dt_catcaso != null)
                {
                    cmb_categoria.DataSource = dt_catcaso;
                cmb_categoria.ValueMember = "id_cat_caso";
                    cmb_categoria.DisplayMember = "nombre_caso";
                }

                // Cargar combo box de empleados
                //DataTable dt_empleados = new DataTable();
                //dt_empleados = peticionescapa.cargar_empleados();
                //cmb_responsable.DataSource = dt_empleados;
                //cmb_responsable.ValueMember = "id_empleado";
                //cmb_responsable.DisplayMember = "nombres";

                //LLENAR EMPLEADOS
                //DataTable dt_empleados = OpBD.SeleccionarEmpleados();
                //DataRow row_emp = dt_empleados.NewRow();
                //row_emp[0] = 0;
                //row_emp[1] = "<Ninguno>";
                //dt_empleados.Rows.InsertAt(row_emp, 0);
                //cmb_responsable.DataSource = dt_empleados;
                //cmb_responsable.ValueMember = "id_empleado";
                //cmb_responsable.DisplayMember = "Empleado";
                ServiceReference1.Service1Client srv = new ServiceReference1.Service1Client();
                DataSet ds = srv.ObtenerEmpleados();
                DataTable dt_empleados = ds.Tables[0];
                DataRow row_emp = dt_empleados.NewRow();
                row_emp[0] = 0;
                row_emp[6] = "<Ninguno>";
                dt_empleados.Rows.InsertAt(row_emp, 0);
                cmb_responsable.DataSource = dt_empleados;
                cmb_responsable.ValueMember = "id_empleado_pk";
                cmb_responsable.DisplayMember = "NOMBRE";

                //// Cargar GridView de casos
                //DataTable dt_casos = new DataTable();
                //dt_casos = peticionescapa.cargar_casos();
                //dgv_casos.DataSource = dt_casos;
                //// columnas ocultas
                //gridView1.Columns["id_empresa"].Visible = false;
                //gridView1.Columns["id_empleado"].Visible = false;
                //gridView1.Columns["id_cliente"].Visible = false;
                //gridView1.Columns["id_cat_caso"].Visible = false;
                //gridView1.Columns["id_caso"].Visible = false;

                //// headers de las columnas
                //gridView1.Columns["nombre"].Caption = "Empresa";
                //gridView1.Columns["nombres"].Caption = "Nombre del cliente";
                //gridView1.Columns["apellidos"].Caption = "Apellido del cliente";
                //gridView1.Columns["nombres1"].Caption = "Nombre del encargado";
                //gridView1.Columns["apellidos1"].Caption = "Apellido del encargado";
                //gridView1.Columns["fecha_asignacion"].Caption = "Asignacion";
                //gridView1.Columns["fecha_limite"].Caption = "Fecha limite";
                //gridView1.Columns["nombre_caso"].Caption = "Categoria";
                //gridView1.Columns["estado_caso"].Caption = "Estado";


                //gridView1.Columns["id_cat_caso"].Visible = false;

                if (actualizar == true)

                {

                    txt_titulo.Text = "";
                    txt_titulo.Text = titulo_e;
                    txt_titulo.ForeColor = Color.Black;

                    if (!String.IsNullOrEmpty(persona_e))
                    {
                        cmb_ente.SelectedItem = "Persona";
                        int indice_per = cbo_perem.FindString(persona_e);
                        cbo_perem.SelectedIndex = indice_per;
                    }
                    else if (!String.IsNullOrEmpty(empresa_e))
                    {
                        cmb_ente.SelectedItem = "Empresa";
                        int indice_emp = cbo_perem.FindString(empresa_e);
                        cbo_perem.SelectedIndex = indice_emp;
                    }

                    DataTable dt = OpBD.SeleccionarDatosRestantesCaso(id_caso_e);

                    DataRow row = dt.Rows[0];
                    string fecha_asignacion = row[0].ToString();
                    string estado_caso = row[1].ToString();
                    string descripcion = row[2].ToString();
                    string empleado = row[3].ToString();
                    string id_empleado = row[4].ToString();

                    txt_descripcion.Text = descripcion;
                    txt_descripcion.ForeColor = Color.Black;
                    

                    int indice_categoria = cmb_categoria.FindString(categoria_e);
                    cmb_categoria.SelectedIndex = indice_categoria;

                    dtp_fecha_cierre.EditValue = Convert.ToDateTime(fecha_fin_e);
                    
                    if (id_empleado != "0")
                    {
                        int indice_empleado = cmb_responsable.FindString(id_empleado + " - " + empleado);
                        cmb_responsable.SelectedIndex = indice_empleado;
                    }
                    else
                    {
                        cmb_responsable.SelectedIndex = 0;
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        

        private void cmb_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }


        // habiliar combo box de empresas y clientes segun opcion seleccionada
        private void cmb_ente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmb_ente.SelectedItem.ToString() == "Empresa")
            //{
            //    DataTable dt_empresas = new DataTable();
            //    dt_empresas = peticionescapa.cargar_empresas();
            //    cmb_empresa.DataSource = dt_empresas;
            //    cmb_empresa.ValueMember = "id_empresa";
            //    cmb_empresa.DisplayMember = "nombre";
            //    cmb_empresa.Enabled = true;

            //}
            //else if(cmb_ente.SelectedItem.ToString() == "Persona")
            //    {

            //    DataTable dt_empresas = new DataTable();
            //    dt_empresas = peticionescapa.cargar_empresas();
            //    cmb_empresa.DataSource = dt_empresas;
            //    cmb_empresa.ValueMember = "id_empresa";
            //    cmb_empresa.DisplayMember = "nombre";
            //    // Limpiar combo box de empresa ya que no se va a usar

            //    //cmb_cliente.DataSource = null;
            //    //cmb_cliente.Items.Clear();

            //    //cmb_empresa.DataSource = null;
            //    //cmb_empresa.Items.Clear();


            //    // carga de clientes sin empresa:
            //    DataTable clientes = new DataTable();
            //    //peticionescapa.cargar_clientes(cmb_cliente.SelectedValue.ToString());
            //    clientes = OpBD.SeleccionarClientes();
            //    cmb_cliente.DataSource = clientes;
            //    cmb_cliente.ValueMember = "id_cliente";
            //    cmb_cliente.DisplayMember = "nombres";
            //    cmb_empresa.Enabled = false;


            //}


            if (cmb_ente.SelectedItem.ToString() == "Persona")
            {
                cbo_perem.DataSource = OpBD.SeleccionarClientes();
                cbo_perem.ValueMember = "id_cliente";
                cbo_perem.DisplayMember = "nom";
            }
            else if (cmb_ente.SelectedItem.ToString() == "Empresa")
            {
                cbo_perem.DataSource = OpBD.SeleccionarEmpresas();
                cbo_perem.ValueMember = "id_empresa";
                cbo_perem.DisplayMember = "nombre";
            }



        }



        // habilita los usuarios pertenecientes a la empresa seleccionada
        private void cmb_empresa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if (cmb_empresa.SelectedValue.ToString() == "System.Data.DataRowView")
            //{
            //    MessageBox.Show("error");
            //}
            //else if (cmb_empresa.SelectedValue.ToString() == "")
            //{

            //    cmb_cliente.DataSource = null;
            //    cmb_cliente.Items.Clear();

            //}
            //else
            //{

            //    DataTable clientes = new DataTable();
            //    peticionescapa.cargar_clientes(cmb_cliente.SelectedValue.ToString());
            //    clientes = peticionescapa.cargar_clientes(cmb_empresa.SelectedValue.ToString());
            //    cmb_cliente.DataSource = clientes;
            //    cmb_cliente.ValueMember = "id_cliente";
            //    cmb_cliente.DisplayMember = "nombres";


            //}
        }


        // BOTON PARA INGRESAR NUEVO ENTE SEGUN OPCION SELECCIONADA
        private void btn_nuevo_ente_Click(object sender, EventArgs e)
        {
            //string opcion = cmb_ente.Text;

            //MessageBox.Show(opcion);

            //if (cmb_ente.Text == "")
            //{
            //    MessageBox.Show("No se ha seleccionado ninguna opción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
            //else if (cmb_ente.Text == "Empresa")
            //{
            //    frm_empresa empresa = new frm_empresa();
            //    empresa.Show();
            //}
            //else if (cmb_ente.Text == "Persona")
            //{
            //    frm_cliente cliente = new frm_cliente();
            //    cliente.Show();
            //}

            //--------------------
            if (cmb_ente.SelectedIndex == 0 || cmb_ente.SelectedIndex == 1)
            {
                if (cmb_ente.SelectedItem.ToString() == "Persona")
                {
                    frm_cliente f = new frm_cliente();
                    f.MdiParent = this.MdiParent;

                    f.Show();
                }
                else if (cmb_ente.SelectedItem.ToString() == "Empresa")
                {
                    frm_empresa f = new frm_empresa();
                    f.MdiParent = this.MdiParent;

                    f.Show();
                }
            }

        }

        // boton para crear una nueva categoria
        private void btn_nueva_categoria_Click(object sender, EventArgs e)
        {
            frm_categoria_caso caso = new frm_categoria_caso();
            caso.Show();
        }

        // boton para crear un nuevo empleado
        private void btn_nuevo_emp_Click(object sender, EventArgs e)
        {
            frm_NuevoEmpleado empleado = new frm_NuevoEmpleado();
            empleado.Show();
        }

        // boton actualizar ente (empresa o empleado)
        private void btn_actualizar_ente_Click(object sender, EventArgs e)
        {
            //if (cmb_ente.SelectedItem.ToString() == "Empresa")
            //{
            //    DataTable dt_empresas = new DataTable();
            //    dt_empresas = peticionescapa.cargar_empresas();
            //    cmb_empresa.DataSource = dt_empresas;
            //    cmb_empresa.ValueMember = "id_empresa";
            //    cmb_empresa.DisplayMember = "nombre";
            //    cmb_empresa.Enabled = true;

            //}
            //else if (cmb_ente.SelectedItem.ToString() == "Persona")
            //{

            //    // Limpiar combo box de empresa ya que no se va a usar

            //                // carga de clientes sin empresa:
            //    DataTable clientes = new DataTable();
            //    //peticionescapa.cargar_clientes(cmb_cliente.SelectedValue.ToString());
            //    clientes = peticionescapa.cargar_clientes_SinEmpresa();
            //    cmb_cliente.DataSource = clientes;
            //    cmb_cliente.ValueMember = "id_cliente";
            //    cmb_cliente.DisplayMember = "nombres";
            //    cmb_empresa.Enabled = false;


            //}

            if (cmb_ente.SelectedIndex == 0 || cmb_ente.SelectedIndex == 1)
            {
                if (cmb_ente.SelectedItem.ToString() == "Persona")
                {
                    cbo_perem.DataSource = OpBD.SeleccionarClientes();
                    cbo_perem.ValueMember = "id_cliente";
                    cbo_perem.DisplayMember = "nom";
                }
                else if (cmb_ente.SelectedItem.ToString() == "Empresa")
                {
                    cbo_perem.DataSource = OpBD.SeleccionarEmpresas();
                    cbo_perem.ValueMember = "id_empresa";
                    cbo_perem.DisplayMember = "nombre";
                }
            }


        }

        // boton para actualizar empleados
        private void btn_actualizar_emp_Click(object sender, EventArgs e)
        {


            // Cargar combo box de empleados
            //DataTable dt_empleados = new DataTable();
            //dt_empleados = peticionescapa.cargar_empleados();
            //cmb_responsable.DataSource = dt_empleados;
            //cmb_responsable.ValueMember = "id_empleado";
            //cmb_responsable.DisplayMember = "nombres";

            cmb_responsable.DataSource = OpBD.SeleccionarEmpleados();
            cmb_responsable.ValueMember = "id_empleado";
            cmb_responsable.DisplayMember = "Empleado";
        }

        // boton para actualizar categoria de casos
        private void btn_actualizar_cat_Click(object sender, EventArgs e)
        {
            //// Cargar combo box de categoria de casos
            //DataTable dt_categoria_casos = new DataTable();
            //dt_categoria_casos = peticionescapa.cargar_categoria_caso();
            //cmb_categoria.DataSource = dt_categoria_casos;
            //cmb_categoria.ValueMember = "id_cat_caso";
            //cmb_categoria.DisplayMember = "nombre_caso";

            //cmb_categoria.DataSource = OpBD.SeleccionarCategoriasCaso();
            //cmb_categoria.ValueMember = "id_cat";
            //cmb_categoria.DisplayMember = "nombre_cat";

            DataTable dt_catcaso = OpBD.SeleccionarCategoriasCaso();
            if (dt_catcaso != null)
            {
                cmb_categoria.DataSource = dt_catcaso;
                cmb_categoria.ValueMember = "id_cat_caso";
                cmb_categoria.DisplayMember = "nombre_caso";
            }
        }

        // boton de prueba
        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            fecha = dtp_fecha_cierre.DateTime.ToString("yyyy-MM-dd");
            //MessageBox.Show(fecha);
        }


        // boton para eliminar
        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    peticionescapa.eliminar_caso(var_idcaso);
            //    MessageBox.Show("Caso eliminado correctamente", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }


        private void btn_siguiente_Click(object sender, EventArgs e)
        {
       


            //MessageBox.Show("holii");
            
            


        }

        private void switch_caso_Toggled(object sender, EventArgs e)
        {
            ////switch_caso toggle = (ToggleSwitch)sender;
            ////toggle.Toggled += ToggleSwitch_Toggled;


            ////if (var_idcaso == "")
            ////{
            ////    MessageBox.Show("No se ha seleccionado ningun registro", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                
            ////}
            ////else
            ////{

            //    if (switch_caso.IsOn)
            //    {
            //        switch_caso.BackColor = Color.MediumSeaGreen;
            //        estado = open;
            //    }
            //    else
            //    {


            //        var decision = MessageBox.Show("¿Desea dar por cerrado el caso?", "Cerrar caso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (decision == DialogResult.Yes)
            //        {
            //            switch_caso.BackColor = Color.Red;
            //            estado = close;
            //            // envio de variables para cerrar el caso en la base de datos mysql
            //            peticionescapa.cerrar_caso(var_idcaso);
            //            MessageBox.Show("Caso cerrado satisfactoriamente", "Caso cerrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else if (decision == DialogResult.No)
            //        {
            //            switch_caso.IsOn = true;
            //            switch_caso.BackColor = Color.MediumSeaGreen;
            //            estado = open;
            //        }
            //    }
            ////}
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            //if (switch_caso.IsOn)
            //{
            //    estado = close;
            //}
            //else
            //{
            //    estado = open;
            //}


        }

       

        // boton para almacenar en la base de datos un nuevo caso
        private void btn_guardar_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    string valor_empresa = cmb_empresa.SelectedValue.ToString();

            //    if (valor_empresa == "")
            //    {
            //        valor_empresa = "0";
            //    }

            //    // conversion de fecha para que sea aceptada por mysql
            //    fecha = dtp_fecha_cierre.DateTime.ToString("yyyy-MM-dd");
            //    if (txt_titulo.Text.Trim() == "" || txt_descripcion.Text.Trim() == "" ||cmb_responsable.Text==""||cmb_categoria.Text==""||cmb_cliente.Text=="" || switch_caso.IsOn == false)
            //    {
            //        MessageBox.Show("Uno o más campos estan vacios","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            //        switch_caso.IsOn = false;
            //    }
            //    else
            //    {
            //        peticionescapa.Insertar_NuevoCaso(cmb_responsable.SelectedValue.ToString(), cmb_cliente.SelectedValue.ToString(), valor_empresa
            //        , txt_titulo.Text.Trim(), estado, fecha, txt_descripcion.Text.Trim(), cmb_categoria.SelectedValue.ToString());
            //        MessageBox.Show("Caso asignado correctamente", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}


            if (actualizar == false)
            {

                if (!String.IsNullOrEmpty(txt_titulo.Text) && cmb_ente.SelectedItem != null && !String.IsNullOrEmpty(txt_descripcion.Text) &&  dtp_fecha_cierre.EditValue != null)
                {
                    string titulo = txt_titulo.Text.Trim();
                    int perem = Convert.ToInt32(cbo_perem.SelectedValue);
                    string descripcion = txt_descripcion.Text.Trim();
                    int cat = Convert.ToInt32(cmb_categoria.SelectedValue);
                    int empleado = Convert.ToInt32(cmb_responsable.SelectedValue);
                    DateTime fecha = dtp_fecha_cierre.DateTime;

                    int res = 3;
                    OpBD o = new OpBD();
                    if (cmb_ente.SelectedItem.ToString() == "Persona")
                    {
                        res = o.InsertarCasoClie(titulo, perem, descripcion, cat, empleado, fecha.ToString("yyyy-MM-dd"));
                    }
                    else if (cmb_ente.SelectedItem.ToString() == "Empresa")
                    {
                        res = o.InsertarCasoEmp(titulo, perem, descripcion, cat, empleado, fecha.ToString("yyyy-MM-dd"));
                    }

                    if (res == 1)
                    {
                        MessageBox.Show("Ingreso Exitoso!");
                    }
                    else if (res == 0)
                    {
                        MessageBox.Show("Ingreso fallido!");
                    }
                    else
                    {
                        MessageBox.Show("Ingrese con quien será la negociación!");
                    }




                }
                else { MessageBox.Show("Debe llenar todos los campos!!!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            }
            else if (actualizar == true)
            {
                if (!String.IsNullOrEmpty(txt_titulo.Text) && cmb_ente.SelectedItem != null && !String.IsNullOrEmpty(txt_descripcion.Text) && dtp_fecha_cierre.EditValue != null)
                {

                    string titulo = txt_titulo.Text.Trim();
                    int perem = Convert.ToInt32(cbo_perem.SelectedValue);
                    string descripcion = txt_descripcion.Text.Trim();
                    int cat = Convert.ToInt32(cmb_categoria.SelectedValue);
                    int empleado = Convert.ToInt32(cmb_responsable.SelectedValue);
                    DateTime fecha = dtp_fecha_cierre.DateTime;

                    int res = 3;
                    OpBD o = new OpBD();
                    if (cmb_ente.SelectedItem.ToString() == "Persona")
                    {
                        res = o.ActualizarCasoClie(titulo, perem, descripcion,  cat, empleado,  fecha.ToString("yyyy-MM-dd"), id_caso_e);
                    }
                    else if (cmb_ente.SelectedItem.ToString() == "Empresa")
                    {
                        res = o.ActualizarCasoEmp(titulo, perem, descripcion,  cat, empleado,  fecha.ToString("yyyy-MM-dd"), id_caso_e);
                    }

                    if (res == 1)
                    {
                        MessageBox.Show("Modificación Exitosa!");
                    }
                    else if (res == 0)
                    {
                        MessageBox.Show("Ingreso fallido!");
                    }
                }
                else { MessageBox.Show("Debe llenar todos los campos!!!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }


        // boton actualizar gridview casos
        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            //// Cargar GridView de casos
            //DataTable dt_casos = new DataTable();
            //dt_casos = peticionescapa.cargar_casos();
            //dgv_casos.DataSource = dt_casos;

            //gridView1.Columns["id_empresa"].Visible = false;
            //gridView1.Columns["id_empleado"].Visible = false;
            //gridView1.Columns["id_cliente"].Visible = false;
            //gridView1.Columns["id_cat_caso"].Visible = false;

            //// headers de las columnas
            //gridView1.Columns["nombre"].Caption = "Empresa";
            //gridView1.Columns["nombres"].Caption = "Nombre_cliente";
            //gridView1.Columns["apellidos"].Caption = "Apellido_cliente";
            //gridView1.Columns["nombres1"].Caption = "Nombre_encargado";
            //gridView1.Columns["apellidos1"].Caption = "Apellido_encargado";
            //gridView1.Columns["fecha_asignacion"].Caption = "Asignacion";
            //gridView1.Columns["fecha_limite"].Caption = "Fecha_limite";

        }


        // grid view de casos
        private void dgv_casos_Click(object sender, EventArgs e)
        {
            //string valor_empresa = "";
            ////string fechaCierre = "";
            //try
            //{
            //    // Crear vector:
            //    int[] vector = ((GridView)dgv_casos.MainView).GetSelectedRows();
            //    // Seleccionar las areas que tomará el vector del grid
            //    DataRowView Empresa = (DataRowView)(((GridView)dgv_casos.MainView).GetRow(vector[0]));
            //    DataRowView Nombre_encargado = (DataRowView)(((GridView)dgv_casos.MainView).GetRow(vector[0]));
            //    DataRowView Nombre_cliente = (DataRowView)(((GridView)dgv_casos.MainView).GetRow(vector[0]));
            //    DataRowView titulo = (DataRowView)(((GridView)dgv_casos.MainView).GetRow(vector[0]));
            //    DataRowView descripcion = (DataRowView)(((GridView)dgv_casos.MainView).GetRow(vector[0]));
            //    DataRowView fecha_cierre = (DataRowView)(((GridView)dgv_casos.MainView).GetRow(vector[0]));
            //    DataRowView id_caso = (DataRowView)(((GridView)dgv_casos.MainView).GetRow(vector[0]));
            //    DataRowView categoria = (DataRowView)(((GridView)dgv_casos.MainView).GetRow(vector[0]));


            //    // definir si el cliente esta ligado a una empresa o no? :
            //    valor_empresa = Empresa["nombre"].ToString();

            //    if (valor_empresa == "")
            //    {
            //        cmb_ente.Text = "Persona";
            //    }
            //    else 
            //    {
            //        cmb_ente.Text = "Empresa";
            //    }

            //    // convertir fecha para que sea detectada en el calendario de c#:
            //    //fechaCierre = dtp_fecha_cierre.DateTime.ToString("yyyy-MM-dd");

            //    // asignacion de partes de vectores en cajas de texto o combo boxes
            //    cmb_empresa.Text = valor_empresa;
            //    cmb_responsable.Text = Nombre_encargado["nombres1"].ToString();
            //    cmb_cliente.Text = Nombre_cliente["nombres"].ToString();
            //    txt_titulo.Text = titulo["titulo"].ToString();
            //    txt_descripcion.Text = descripcion["descripcion"].ToString();
            //    dtp_fecha_cierre.Text = fecha_cierre["fecha_limite"].ToString();
            //    var_idcaso = id_caso["id_caso"].ToString();
            //    cmb_categoria.Text = categoria["nombre_caso"].ToString();

            //    //MessageBox.Show(var_idcaso);



            //    //MessageBox.Show(cmb_responsable.SelectedValue.ToString());

            //    // activacion de switch
            //    switch_caso.IsOn = true;


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }


        // boton para editar registros
        private void btn_editar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string valor_empresa = cmb_empresa.SelectedValue.ToString();

            //    if (valor_empresa == "")
            //    {
            //        valor_empresa = "0";
            //    }

            //    // conversion de fecha para que sea aceptada por mysql
            //    fecha = dtp_fecha_cierre.DateTime.ToString("yyyy-MM-dd");
            //    if (txt_titulo.Text.Trim() == "" || txt_descripcion.Text.Trim() == "" || cmb_responsable.Text == "" || cmb_categoria.Text == "" || cmb_cliente.Text == "")
            //    {
            //        MessageBox.Show("Uno o más campos estan vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //    else
            //    {
            //        peticionescapa.modificar_caso(cmb_responsable.SelectedValue.ToString(), cmb_cliente.SelectedValue.ToString(), valor_empresa
            //        , txt_titulo.Text.Trim(), estado, fecha, txt_descripcion.Text.Trim(), cmb_categoria.SelectedValue.ToString(),var_idcaso);
            //        MessageBox.Show("Caso modificado correctamente", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        // boton de nuevo caso
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_descripcion.Text = "";
            txt_titulo.Text = "";
            //switch_caso.IsOn = false;
        }


        // boton de eliminar 
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            //    try
            //    {
            //        peticionescapa.eliminar_caso(var_idcaso);
            //        MessageBox.Show("Caso eliminado correctamente", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
        }

        private void txt_titulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_titulo_MouseClick(object sender, MouseEventArgs e)
        {
            if(txt_titulo.Text == "Ingrese un titulo para el caso...")
            {
                txt_titulo.Text = "";
                txt_titulo.ForeColor = Color.Black;
            }
        }

        private void txt_descripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_descripcion_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_descripcion.Text == "Asigne una descripción al caso...")
            {
                txt_descripcion.Text = "";
                txt_descripcion.ForeColor = Color.Black;
            }
        }
    }
    
}
