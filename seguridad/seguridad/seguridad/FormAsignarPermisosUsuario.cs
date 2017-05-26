using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace seguridad
{
    public partial class FormAsignarPermisosUsuario : Form
    {
        bitacora bitacora = new bitacora();
        public FormAsignarPermisosUsuario()
        {
            InitializeComponent();
        }
        
        DataTable dt = new DataTable();
        DataTable dg = new DataTable();

        DataTable dt_p = new DataTable();
        DataTable dg_p = new DataTable();

        DataTable dt_central = new DataTable();
        DataTable dg_central = new DataTable();
        int cont_e = 0;
        int cont_ec =0;
      

        private void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{
                btn_reporte.Enabled = false;
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                DataTable dtz = ss.ObtenerPerfiles();
                cbo_roles.DataSource = dtz;
                cbo_roles.DisplayMember = "nombre_perfil";
                cbo_roles.ValueMember = "id_perfil";
                cbo_roles.SelectedIndex = -1;

              //************************************************************************
                DataTable dt2 = ss.ObtenerAplicaciones();

                ((ListBox)chlb_aplicaciones).DataSource = dt2;
                ((ListBox)chlb_aplicaciones).ValueMember = "id_aplicacion";
                ((ListBox)chlb_aplicaciones).DisplayMember = "nombre_aplicacion";

                //  chlb_aplicaciones.CheckOnClick = true;
                // chlb_permisos.CheckOnClick = true;
                //-------------------------------------------------------
                trv_aplicaciones.CheckBoxes = true;

                //CARGAR NODOS RAIZ (MODULOS)
                DataTable dt_modulos = ss.ObtenerModulos();
                if (dt_modulos != null)
                {
                    foreach (DataRow row_modulos in dt_modulos.Rows)
                    {
                        TreeNode nodo_modulo = new TreeNode() { Text = row_modulos[1].ToString(), Tag = row_modulos[0].ToString() };
                        trv_aplicaciones.Nodes.Add(nodo_modulo);
                    }
                }
                //CARGAR APLICACIONES(FORMS) DENTRO DE NODOS RAIZ
                foreach (TreeNode nodo_modulo in trv_aplicaciones.Nodes)
                {
                    string id_modulo = nodo_modulo.Tag.ToString();
                    DataTable dt_aplicaciones = ss.ObtenerAplicacionesPorModulo(id_modulo);
                    foreach(DataRow row_aplicaciones in dt_aplicaciones.Rows)
                    {
                        TreeNode nodo_aplicacion = new TreeNode() { Text = row_aplicaciones[1].ToString(), Tag = row_aplicaciones[0].ToString() };
                        nodo_modulo.Nodes.Add(nodo_aplicacion);
                    }   
                }

                  
             //**************************************************************************
             
                 
                //---------------------------------------------------------
                DataColumn columna;
                //primera columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Int32");
                columna.ColumnName = "Aplicación";
                dt.Columns.Add(columna);

                //2 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Boolean");
                columna.ColumnName = "Insertar";
                dt.Columns.Add(columna);
                //3 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Boolean");
                columna.ColumnName = "Seleccionar";
                dt.Columns.Add(columna);
                //4 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Boolean");
                columna.ColumnName = "Modificar";
                dt.Columns.Add(columna);
                //5 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Boolean");
                columna.ColumnName = "Eliminar";
                dt.Columns.Add(columna);
                //*********columna perfiles******
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Int32");
                columna.ColumnName = "Perfil";
                dt.Columns.Add(columna);

                //------------------------------------------------------
                //primera columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Aplicación";
                dg.Columns.Add(columna);

                //2 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Insertar";
                dg.Columns.Add(columna);
                //3 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Seleccionar";
                dg.Columns.Add(columna);
                //4 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Modificar";
                dg.Columns.Add(columna);
                //5 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Eliminar";
                dg.Columns.Add(columna);
                //------------------------------------------------------
                //primera columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Aplicación";
                dg_p.Columns.Add(columna);

                //2 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Insertar";
                dg_p.Columns.Add(columna);
                //3 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Seleccionar";
                dg_p.Columns.Add(columna);
                //4 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Modificar";
                dg_p.Columns.Add(columna);
                //5 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Eliminar";
                dg_p.Columns.Add(columna);

                //------------------------------------------------


                //primera columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Int32");
                columna.ColumnName = "Aplicación";
                dt_central.Columns.Add(columna);

                //2 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Boolean");
                columna.ColumnName = "Insertar";
                dt_central.Columns.Add(columna);
                //3 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Boolean");
                columna.ColumnName = "Seleccionar";
                dt_central.Columns.Add(columna);
                //4 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Boolean");
                columna.ColumnName = "Modificar";
                dt_central.Columns.Add(columna);
                //5 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Boolean");
                columna.ColumnName = "Eliminar";
                dt_central.Columns.Add(columna);
                //*********columna perfiles******
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.Int32");
                columna.ColumnName = "Perfil";
                dt_central.Columns.Add(columna);
                //------------------------------------------------


                //primera columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Aplicación";
                dg_central.Columns.Add(columna);

                //2 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Insertar";
                dg_central.Columns.Add(columna);
                //3 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Seleccionar";
                dg_central.Columns.Add(columna);
                //4 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Modificar";
                dg_central.Columns.Add(columna);
                //5 columna
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "Eliminar";
                dg_central.Columns.Add(columna);

                //----Datos del colaborador

                try
                {
                    //DataTable dtjc = new DataTable();
                    //dtjc = ss.SeleccionaEmpresa();
                    //cmb_emp.DataSource = dtjc;
                    //cmb_emp.DisplayMember = "nombre";
                    //cmb_emp.ValueMember = "id_empresa_pk";

                    DataTable dtjc = new DataTable();
                    dtjc = ss.SeleccionaEmpleados();
                    cmb_colab.DataSource = dtjc;
                    cmb_colab.DisplayMember = "NOM";
                    cmb_colab.ValueMember = "id_empleado";

                }
                catch
                {
                    MessageBox.Show("Error al encontrar empresa");
                }


            //}
            //catch { MessageBox.Show("no tiene permisos"); }

        }

    

        private void cbo_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg_p.Clear();
            if (cbo_roles.SelectedValue is int)
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                DataTable dtm = new DataTable();
                DataRow rowdg;
                dt_p = ss.ObtenerPermisosPorPerfilesdt(cbo_roles.SelectedValue.ToString());//
                dtm = ss.ObtenerPermisosPorPerfilesdg(cbo_roles.SelectedValue.ToString());
                foreach (DataRow row in dtm.Rows)
                {
                    rowdg = dg_p.NewRow();
                    for (int i = 0; i < dtm.Columns.Count; i++)
                    {
                        
                        // MessageBox.Show(row[i].ToString());
                        if (row[i].ToString() == "1")
                        {
                            rowdg[i] = "X";
                        }
                        else if (row[i].ToString() == "0")
                         {
                            rowdg[i] = "";
                        }
                        else
                           {
                            rowdg[i] = row[i].ToString();
                        }
                    }
                    dg_p.Rows.Add(rowdg);
                }
               // dataGridView2.DataSource = dt_p;
                dgw_perfil.DataSource = dg_p;
                // MessageBox.Show(cbo_roles.SelectedValue.ToString());

            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < chlb_aplicaciones.Items.Count; i++)
            //{
            //    if (chlb_aplicaciones.GetItemCheckState(i) == CheckState.Checked)
            //    {
            //        //MessageBox.Show(chlb_aplicaciones.GetItemChecked(i).SelectedValue.ToString());
            //        MessageBox.Show(chlb_aplicaciones.CheckedItems[i]);
            //    }
            //}

            //foreach (object ap in chlb_aplicaciones.CheckedItems)
            //{
            //    //MessageBox.Show(((ListBox)chlb_aplicaciones).SelectedValue.ToString());
            //    //MessageBox.Show("valor es:"+ ap.ToString());
            //    MessageBox.Show("valor es:" +);
            //}

            //foreach (DataRowView ap in chlb_aplicaciones.CheckedItems)
            //{
            //    MessageBox.Show(((ListBox)chlb_aplicaciones).SelectedValue.ToString());
            //}

            //foreach (  ap in chlb_aplicaciones.CheckedItems)
            //{
            //    //MessageBox.Show(((ListBox)chlb_aplicaciones).SelectedValue.ToString());
            //    MessageBox.Show(ap.SelectedValue.ToString());
            //}

            //----------------------------------------------------------------------------
            //dgw1.Rows.Insert

            ValidarListaApp();

            DataRow row;
            DataRow rowdg;
         
            int cont = 1;
            foreach (int i in chlb_aplicaciones.CheckedIndices)
            {
                chlb_aplicaciones.SelectedIndex = i;
                row = dt.NewRow();
                row[0] = chlb_aplicaciones.SelectedValue.ToString();//

                rowdg = dg.NewRow();
                rowdg[0] = chlb_aplicaciones.Text;//

                for (int t = 0; t < chlb_permisos.Items.Count; t++)
                {
                    if (chlb_permisos.GetItemCheckState(t) == CheckState.Checked)
                     {
                        row[cont] = true;
                        rowdg[cont] = "X";
                        cont++;
                     }
                    else
                      {
                        row[cont] = false;
                        cont++;
                      }
                        if (t == chlb_permisos.Items.Count-1)
                        {
                        row["perfil"] = 0; //<----------------------------------------------------------------------------------------------
                        dt.Rows.Add(row);
                        dg.Rows.Add(rowdg);
                        cont = 1;
                        }
                }
            }

            dgw_permisos.DataSource = dg;
           // dataGridView1.DataSource = dt;

            BloquearCheck();
            BloquearExistentes();

            cont_e++;
            if (cont_e==1)
            {
                AgregarColEliminar();
            }
            //--------------------------------------------------------
            //foreach (int i in chlb_aplicaciones.SelectedIndices)
            //{
            //    DataRowView dr = (DataRowView)chlb_aplicaciones.Items;
            //}
        }


        public void ValidarListaApp()
        {
            string idp;
            foreach(DataRow  row in dt.Rows )
            {
                 idp = row[0].ToString();
                foreach (int i in chlb_aplicaciones.CheckedIndices)
                {
                    chlb_aplicaciones.SelectedIndex = i;
                    if (idp == chlb_aplicaciones.SelectedValue.ToString())
                    {
                        chlb_aplicaciones.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }


            }

        }


        public void BloquearExistentes()
        {
            string idp;
            foreach (DataRow row in dt.Rows)
            {
                idp = row[0].ToString();
                for (int t = 0; t < chlb_aplicaciones.Items.Count; t++)
                {
                    chlb_aplicaciones.SelectedIndex = t;
                    if (idp == chlb_aplicaciones.SelectedValue.ToString())
                    {
                        chlb_aplicaciones.SetItemCheckState(t, CheckState.Indeterminate);
                    }
                }


            }

        }

        public void AgregarColEliminar()
        {
            DataGridViewButtonColumn dg_columna = new DataGridViewButtonColumn();
            //dg_columna  
            dg_columna.HeaderText = "Quitar";
            dgw_permisos.Columns.Add(dg_columna);
        }

        public void AgregarColEliminarCentral()
        {
            DataGridViewButtonColumn dg_columna = new DataGridViewButtonColumn();
            //dg_columna  
            dg_columna.HeaderText = "Quitar";
            dgw_central.Columns.Add(dg_columna);
        }

        public void BloquearCheck()
        {
            for (int t = 0; t < chlb_aplicaciones.Items.Count; t++)
            {
                if (chlb_aplicaciones.GetItemCheckState(t) == CheckState.Checked)
                {

                    chlb_aplicaciones.SetItemCheckState(t, CheckState.Indeterminate);
                }
            }

            for (int r = 0; r < chlb_permisos.Items.Count; r++)
            {
                if (chlb_permisos.GetItemCheckState(r) == CheckState.Checked)
                {

                    chlb_permisos.SetItemCheckState(r, CheckState.Unchecked);
                }
            }


        }









      





        private void chlb_aplicaciones_MouseClick(object sender, MouseEventArgs e)
        {
            //int i = chlb_aplicaciones.SelectedIndex;
            //if (chlb_aplicaciones.GetItemCheckState(i) == CheckState.Indeterminate)
            //{

            //    chlb_aplicaciones.SetItemCheckState(i, CheckState.Indeterminate);

            //}
        }

        private void chlb_aplicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void chlb_aplicaciones_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
        }

        private void chlb_aplicaciones_ItemCheck(object sender, ItemCheckEventArgs e)
        {
          
        }

        private void chlb_aplicaciones_Click(object sender, EventArgs e)
        {
            
        }

        private void dgw_permisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgw_permisos.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex !=-1 && e.RowIndex != dt.Rows.Count)
            {
                DataRow row = dt.Rows[dgw_permisos.CurrentRow.Index];
                row.Delete();

                DataRow rowdg = dg.Rows[dgw_permisos.CurrentRow.Index];
                rowdg.Delete();

                // MessageBox.Show(dgw_permisos.CurrentRow.Index.ToString());
                dgw_permisos.DataSource = dg;
                //dataGridView1.DataSource = dt;
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            //******************************BOTON ACEPTAR******************************************
            //SistemaUsuarioNegocio su = new SistemaUsuarioNegocio();
            //SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
            //int u = su.ValidarChecklistVacia(dt);

            //if (!String.IsNullOrEmpty(txt_usuario.Text.Trim()) && u == 1 && !String.IsNullOrEmpty(txt_contraseña.Text.Trim()) && !String.IsNullOrEmpty(txt_rep_contraseña.Text.Trim()))
            //{
            //  if(txt_contraseña.Text.Trim() == txt_rep_contraseña.Text.Trim())
            //    {
            //        int x= ss.CrearUsuario(txt_usuario.Text.Trim(), txt_contraseña.Text.Trim());
            //        int y = ss.InsertarUsuario(txt_usuario.Text.Trim(), txt_contraseña.Text.Trim(), 0);
            //        int z = ss.InsertarPermisosUsuario(dt, txt_usuario.Text.Trim(), 0);
            //        if (x==1 && y==1 && z==1)
            //        {

            //            btn_aceptar_perfil.Enabled = false;
            //            btn_aceptar.Enabled = false;

            //            MessageBox.Show("usuario creado con exito"); }else { MessageBox.Show("error en la creacion del usuario"); }
            //    }
            //    else { MessageBox.Show("contraseñas no coinciden"); }

            //}
            //else { MessageBox.Show("Debe ingresar todos los campos y asignar permisos para el usuario!"); }
            //*************************************************************************************************

            //dt_central.Merge(dt);
            //dg_central.Merge(dg);
            //dgw_central.DataSource = dg_central;
            //dataGridView3.DataSource = dt_central;

            UnirdtCentral(dt);
            UnirdgCentral(dg);
            dgw_central.DataSource = dg_central;
           // dataGridView3.DataSource = dt_central;

            cont_ec++;
            if (cont_ec == 1)
            {
                AgregarColEliminarCentral();
            }

            dg.Clear();
            dt.Clear();
            dgw_permisos.DataSource = dg;
           // dataGridView1.DataSource = dt;
            DescheckearAplicaciones();
        }

        private void btn_aceptar_perfil_Click(object sender, EventArgs e)
        {
            //*************************************BOTON ACEPTAR PERFIL**************************************************
            //SistemaUsuarioNegocio su = new SistemaUsuarioNegocio();
            //SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
            //int u = su.ValidarChecklistVacia(dg_p);

            //if (!String.IsNullOrEmpty(txt_usuario.Text.Trim()) && u == 1 && !String.IsNullOrEmpty(txt_contraseña.Text.Trim()) && !String.IsNullOrEmpty(txt_rep_contraseña.Text.Trim()))
            //{
            //    if (txt_contraseña.Text.Trim() == txt_rep_contraseña.Text.Trim())
            //    {
            //        int x = ss.CrearUsuario(txt_usuario.Text.Trim(), txt_contraseña.Text.Trim());
            //       int y= ss.InsertarUsuario(txt_usuario.Text.Trim(), txt_contraseña.Text.Trim(), Convert.ToInt32(cbo_roles.SelectedValue));
            //        int z= ss.InsertarPermisosUsuario(dt_p, txt_usuario.Text.Trim(), Convert.ToInt32(cbo_roles.SelectedValue));
            //        if (x == 1 && y==1 && z==1)
            //        {

            //            btn_aceptar.Enabled = false;
            //            btn_aceptar_perfil.Enabled = false;
            //            MessageBox.Show("usuario creado con exito"); }
            //        else { MessageBox.Show("error en la creacion del usuario"); }
            //    }
            //    else { MessageBox.Show("contraseñas no coinciden"); }

            //}
            //else { MessageBox.Show("Debe ingresar todos los campos y un perfil para el usuario!"); }
            //**************************************************************************************************************

            //dt_central.Merge(dt_p);
            //dg_central.Merge(dg_p);
            //dgw_central.DataSource = dg_central;
            //dataGridView3.DataSource = dt_central;
            UnirdtCentral(dt_p);
            UnirdgCentral(dg_p);
            dgw_central.DataSource = dg_central;
            //dataGridView3.DataSource = dt_central;

            cont_ec++;
            if (cont_ec == 1)
            {
                AgregarColEliminarCentral();
            }
        }


        public void UnirdtCentral(DataTable dtx)
        {
            DataRow rowC;
            
            foreach(DataRow row in dtx.Rows)
            {


                if (dt_central.Rows.Count == 0)
                {
                    //row_agregar = dt_central.NewRow();
                    //row_agregar.
                    //dt_central.Rows.Add(row_agregar);
                    // dt_central.ImportRow(row);
                    AgregarFiladt(row);
                }
                else
                {

                    string app = row[0].ToString();

                    for (int i = 0; i < dt_central.Rows.Count; i++ )
                    {
                        rowC = dt_central.Rows[i];
                        //if (row_agregar[0].ToString() == rowC[0].ToString())
                       if (app == rowC[0].ToString())
                        {
                            //-----------------------
                            for (int z = 1; z < 5; z++ )
                            {
                                if (Convert.ToInt32(row[z]) == 1)
                                {
                                    rowC[z] = row[z];
                                }
                            }
                            //rowC[6] = row[6];
                            //-----------------------
                            break;
                        }

                        if (rowC == dt_central.Rows[dt_central.Rows.Count - 1])
                        {
                            //row_agregar = dt_central.NewRow();

                            //dt_central.ImportRow(row);
                            AgregarFiladt(row);
                            //  MessageBox.Show("hola");
                        }

                    }

                }



            }
        }

        public void AgregarFiladt(DataRow fila)
        {
            DataRow row;
            row = dt_central.NewRow(); 
            for(int i = 0; i < 6; i++)
            {
                row[i] = fila[i];
            }
            dt_central.Rows.Add(row);
        }

        public void AgregarFiladg(DataRow fila)
        {
            DataRow row;
            row = dg_central.NewRow();
            for (int i = 0; i < 5; i++)
            {
                row[i] = fila[i];
            }
            dg_central.Rows.Add(row);
        }

        public void UnirdgCentral(DataTable dgx)
        {
            DataRow rowC;
            foreach (DataRow row in dgx.Rows)
            {
                if (dg_central.Rows.Count == 0)
                {
                    AgregarFiladg(row);
                }
                else
                {
                    string app = row[0].ToString();

                    for (int i = 0; i < dg_central.Rows.Count; i++)
                    {
                        rowC = dg_central.Rows[i];
                        if (app == rowC[0].ToString())
                        {
                            //---------------------
                            for (int z = 1; z < 5; z++)
                            {
                                if (row[z].ToString() == "X")
                                {
                                    rowC[z] = "X";
                                }
                            }
                            //---------------------
                            break;
                        }

                        if (rowC == dg_central.Rows[dg_central.Rows.Count - 1])
                        {
                            AgregarFiladg(row);
                        }

                    }

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

         public void  DescheckearAplicaciones()
        {
            for (int t = 0; t < chlb_aplicaciones.Items.Count; t++)
            {
                if (chlb_aplicaciones.GetItemCheckState(t) == CheckState.Checked || chlb_aplicaciones.GetItemCheckState(t) == CheckState.Indeterminate)
                {
                    chlb_aplicaciones.SetItemCheckState(t, CheckState.Unchecked);
                }
            }
         }

        private void button1_Click(object sender, EventArgs e)
        {
           // AgregarFiladt();
        }

        private void dgw_central_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgw_central.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1 && e.RowIndex != dt_central.Rows.Count)
            {
                DataRow row = dt_central.Rows[dgw_central.CurrentRow.Index];
                row.Delete();

                DataRow rowdg = dg_central.Rows[dgw_central.CurrentRow.Index];
                rowdg.Delete();

                // MessageBox.Show(dgw_permisos.CurrentRow.Index.ToString());
                dgw_central.DataSource = dg_central;
               // dataGridView3.DataSource = dt_central;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                SistemaUsuarioNegocio su = new SistemaUsuarioNegocio();
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                int u = su.ValidarChecklistVacia(dt_central);

                if (!String.IsNullOrEmpty(txt_usuario.Text.Trim()) && u == 1 && !String.IsNullOrEmpty(txt_contraseña.Text.Trim()) && !String.IsNullOrEmpty(txt_rep_contraseña.Text.Trim()))
                {
                    if (txt_contraseña.Text.Trim() == txt_rep_contraseña.Text.Trim())
                    {
                        int x = 1;
                        if (chb_usuario.CheckState == CheckState.Checked) {
                             x = ss.CrearUsuario(txt_usuario.Text.Trim(), txt_contraseña.Text.Trim());
                              }
                        int y;
                        if (!check_admin.Checked)
                        {
                             y = ss.InsertarUsuario2(txt_usuario.Text.Trim(), txt_contraseña.Text.Trim(), cmb_colab.SelectedValue.ToString());
                        }
                        else
                        {
                             y = ss.InsertarUsuarioAdministrador(txt_usuario.Text.Trim(), txt_contraseña.Text.Trim(), cmb_colab.SelectedValue.ToString());
                        }
                        int z = ss.InsertarPermisosUsuario(dt_central, txt_usuario.Text.Trim());
                        if (x == 1 && y == 1 && z == 1)
                        {
                            btn_guardar.Enabled = false;
                            MessageBox.Show("usuario creado con exito");
                            btn_reporte.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("error en la creacion del usuario");
                        }
                    }
                    else { MessageBox.Show("contraseñas no coinciden"); }

                }
                else { MessageBox.Show("Debe ingresar todos los campos y asignar permisos para el usuario!"); }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private void txt_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            
               SistemaUsuarioNegocio.ValidarNoEspacios(e);
        }

        private void txt_contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            SistemaUsuarioNegocio.ValidarNoEspacios(e);
        }

        private void txt_rep_contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            SistemaUsuarioNegocio.ValidarNoEspacios(e);
        }

        private void cmb_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                DataTable dtjc2 = new DataTable();
                dtjc2 = ss.SeleccionaColaborador(Convert.ToString(cmb_emp.SelectedValue));
                if (dtjc2.Rows.Count != 0)
                {
                    cmb_colab.DataSource = dtjc2;
                    cmb_colab.DisplayMember = "nombre";
                    cmb_colab.ValueMember = "id_empleados_pk";
                }
                else
                {
                    cmb_colab.SelectedIndex = -1;
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void cmb_colab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            FormReporte f = new FormReporte();
            f.usuario = " la creación del usuario " + txt_usuario.Text.Trim();
            f.dgw_cen.DataSource = dg_central;
            f.Show();
        }

        private void trv_aplicaciones_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //TreeNode nodopadre = new TreeNode();
            // string id = e.Node.Parent.Tag.ToString();



            //if (e.Node.Parent != null)
            //{
            //    e.Node.Parent.Checked = true;
            //}
            //------------------------------------------
            foreach (TreeNode nodo_hijo in e.Node.Nodes)
            {
                nodo_hijo.Checked = true;
            }



            // MessageBox.Show(id);
            //nodopadre.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DescheckearExistentes();

            DataRow row;
            DataRow rowdg;

            int cont = 1;
            foreach (TreeNode nodo_raiz in trv_aplicaciones.Nodes)
            {

                foreach (TreeNode nodo_hijo in nodo_raiz.Nodes)
                {

                    if (nodo_hijo.Checked == true)
                    {
                        
                        row = dt.NewRow();
                        row[0] = nodo_hijo.Tag.ToString();//

                        rowdg = dg.NewRow();
                        rowdg[0] = nodo_hijo.Text;//

                        for (int t = 0; t < chlb_permisos.Items.Count; t++)
                        {
                            if (chlb_permisos.GetItemCheckState(t) == CheckState.Checked)
                            {
                                row[cont] = true;
                                rowdg[cont] = "X";
                                cont++;
                            }
                            else
                            {
                                row[cont] = false;
                                cont++;
                            }
                            if (t == chlb_permisos.Items.Count - 1)
                            {
                                row["perfil"] = 0; //<----------------------------------------------------------------------------------------------
                                dt.Rows.Add(row);
                                dg.Rows.Add(rowdg);
                                cont = 1;
                            }
                        }



                    }

                }


            }

            dgw_permisos.DataSource = dg;
            // dataGridView1.DataSource = dt;

            ArreglarCheck();
           // ChekearExistentes();

            cont_e++;
            if (cont_e == 1)
            {
                AgregarColEliminar();
            }
        }


        public void DescheckearExistentes()
        {
            string idp;
            foreach (DataRow row in dt.Rows)
            {
                idp = row[0].ToString();
                foreach (TreeNode nodo_raiz in trv_aplicaciones.Nodes)
                {
                    foreach (TreeNode nodo_hijo in nodo_raiz.Nodes)
                    {
                        if (nodo_hijo.Checked == true)
                        {   
                            if (idp == nodo_hijo.Tag.ToString())
                            {
                                nodo_hijo.Checked=false;
                            }
                        }

                    }

                }



            }

        }




        public void ArreglarCheck()
        {
            foreach(TreeNode nodo_raiz in trv_aplicaciones.Nodes)
            {
                foreach (TreeNode nodo_hijo in nodo_raiz.Nodes)
                {
                    if (nodo_hijo.Checked == true)
                    {

                        nodo_hijo.Checked = false;
                    }
                }
            }

            for (int r = 0; r < chlb_permisos.Items.Count; r++)
            {
                if (chlb_permisos.GetItemCheckState(r) == CheckState.Checked)
                {

                    chlb_permisos.SetItemCheckState(r, CheckState.Unchecked);
                }
            }


        }



        public void ChekearExistentes()
        {
            string idp;
            foreach (DataRow row in dt.Rows)
            {
                idp = row[0].ToString();
                foreach (TreeNode nodo_raiz in trv_aplicaciones.Nodes)
                {
                    foreach (TreeNode nodo_hijo in nodo_raiz.Nodes)
                    {

                        if (idp == nodo_hijo.Tag.ToString())
                        {
                            nodo_hijo.Checked = true;
                        }

                    }


                }


            }

        }

        private void trv_aplicaciones_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void trv_aplicaciones_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            //if (e.Node.Parent == null)
            //{
            //foreach (TreeNode nodo_hijo in e.Node.Nodes)
            //{
            //  nodo_hijo.Checked = true;
            // }
            //}

           //int cant_nodos = e.Node.Nodes.Count;
           // MessageBox.Show(cant_nodos.ToString());



            //for(int i = 0; i < cant_nodos; i++)
            //{

            //}

        }


    }
}
