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
    public partial class Form_EditarPrivilegios : Form
    {
        public Form_EditarPrivilegios()
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
        int contx = 0;
        int cont_ec = 0;
        bool agregada = false;

        private void Form_EditarPrivilegios_Load(object sender, EventArgs e)
        {
            try
            {
                btn_reporte.Enabled = false;
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                cbo_usuario.DataSource = ss.ObtenerUsuarios();
                cbo_usuario.DisplayMember = "usuario";
                cbo_usuario.ValueMember = "usuario";
                cbo_usuario.SelectedIndex = -1;

                DataTable dtz = ss.ObtenerPerfiles();
                cbo_roles.DataSource = dtz;
                cbo_roles.DisplayMember = "nombre_perfil";
                cbo_roles.ValueMember = "id_perfil";
                cbo_roles.SelectedIndex = -1;

                DataTable dt2 = ss.ObtenerAplicaciones();

                ((ListBox)chlb_aplicaciones).DataSource = dt2;
                ((ListBox)chlb_aplicaciones).ValueMember = "id_aplicacion";
                ((ListBox)chlb_aplicaciones).DisplayMember = "nombre_aplicacion";

                //  chlb_aplicaciones.CheckOnClick = true;
                // chlb_permisos.CheckOnClick = true;




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
                    foreach (DataRow row_aplicaciones in dt_aplicaciones.Rows)
                    {
                        TreeNode nodo_aplicacion = new TreeNode() { Text = row_aplicaciones[1].ToString(), Tag = row_aplicaciones[0].ToString() };
                        nodo_modulo.Nodes.Add(nodo_aplicacion);
                    }
                }

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
                //-----------------------------------
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
                //---------------------------------
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
            }
            catch { MessageBox.Show("no tiene permisos"); }
        }

        public void ValidarListaApp()
        {
            string idp;
            foreach (DataRow row in dt.Rows)
            {
                 //if (row.RowState != DataRowState.Deleted)
                  //{
                try
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
                catch { }
                //}

            }

        }

        public void BloquearExistentes()
        {
            string idp;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    //if (row.RowState != DataRowState.Deleted)
                    //{
                        idp = row[0].ToString();
                        for (int t = 0; t < chlb_aplicaciones.Items.Count; t++)
                        {
                            chlb_aplicaciones.SelectedIndex = t;
                            if (idp == chlb_aplicaciones.SelectedValue.ToString())
                            {
                                chlb_aplicaciones.SetItemCheckState(t, CheckState.Indeterminate);
                            }
                        }
                    //}
                }
                catch { }
            }
            
        
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
        public void AgregarColEliminar()
        {
        

            DataGridViewButtonColumn dg_columna = new DataGridViewButtonColumn();
            //dg_columna  
            dg_columna.HeaderText = "Quitar";
            dgw_permisos.Columns.Add(dg_columna);
        }

        private void group_box_pp_Enter(object sender, EventArgs e)
        {

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
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
                    if (t == chlb_permisos.Items.Count - 1)
                    {
                        row["perfil"] = 0;
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

            contx++;
            if (contx == 1)
            {
                AgregarColEliminar();
            }
        }

        private void dgw_permisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgw_permisos.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1 && e.RowIndex != dg.Rows.Count)//dg
            {

                DataRow row = dt.Rows[dgw_permisos.CurrentRow.Index];
                //if (row.RowState != DataRowState.Deleted)
                //{
                row.Delete();
                // row.AcceptChanges();
                /*
                 * PROBLEMA: cuando el datatable se llena con datos provenientes de una base de datos las filas
                 * no se pueden eliminar con row.delete() sino que solo se marcan como eliminadas, lo cual provoca que "dt"
                 * no las elimine de verdad y da problemas al tratar de acceder a los datos ya que la fila sigue ahi, o bien
                 * si logro no leer las filas eliminadas estas igual siguen ahi y el dt no se sincroniza con dg 
                 POSIBLE SOLUCION: validar en todos lados las filas con datarowstate!= datarowstate.delete
                 falta tambien ir a guardar a la base de datos los cambios en los permisos del usuario
                  */
                // }
                DataRow rowdg = dg.Rows[dgw_permisos.CurrentRow.Index];

                rowdg.Delete();


                // MessageBox.Show(dgw_permisos.CurrentRow.Index.ToString());
                dgw_permisos.DataSource = dg;
               // dataGridView1.DataSource = dt;
            }
        }

        private void cbo_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg.Clear();
            dt_central.Clear();
            dg_central.Clear();
           // lv_permisosactuales.Items.Clear();
            if (cbo_usuario.SelectedIndex != -1)
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                DataTable dtm = new DataTable();
                DataTable dth = new DataTable();
                DataRow rowdg;
                dth = ss.ObtenerPermisosPorUsuariodt(cbo_usuario.SelectedValue.ToString());
                dtm = ss.ObtenerPermisosPorUsuariodg(cbo_usuario.SelectedValue.ToString());
                foreach (DataRow row in dtm.Rows)
                {
                    rowdg = dg.NewRow();
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
                    dg.Rows.Add(rowdg);
                }
              

               
               foreach(DataRow rowx in dg.Rows)
                {

                    //     ListViewItem permi = new ListViewItem(rowx[0].ToString());
                    //     permi.SubItems.Add(rowx[1].ToString());
                    //     permi.SubItems.Add(rowx[2].ToString());
                    //     permi.SubItems.Add(rowx[3].ToString());
                    //     permi.SubItems.Add(rowx[4].ToString());
                    //    // lv_permisosactuales.Items.Add(permi);

                    DataRow rowt;
                    rowt = dg_central.NewRow();
                    for (int i = 0; i < 5; i++)
                    {
                        rowt[i] = rowx[i];
                    }
                    dg_central.Rows.Add(rowt);
                }

                foreach (DataRow rowa in dth.Rows)
                {
                    DataRow rowb;
                    rowb = dt_central.NewRow();
                    for (int i = 0; i < 6; i++)
                    {
                        rowb[i] = rowa[i];
                    }
                    dt_central.Rows.Add(rowb);
                }


                dg.Clear();//???
                dt.Clear();
                dg_p.Clear();
                dt_p.Clear();

               // dataGridView1.DataSource = dt;
                dgw_permisos.DataSource = dg;

                dgw_central.DataSource = dg_central;
               // dataGridView3.DataSource = dt_central;
                cont_e++;
                if (cont_e == 3 && agregada == false)
                {
                AgregarColEliminarCentral();
                    agregada = true;
             
                }
                // MessageBox.Show(cbo_roles.SelectedValue.ToString());

                if (cont_e >=3) {
                    //busar en cbo
                   // DataTable midt = ss.ObtenerPerfilDeUsuario(cbo_usuario.SelectedValue.ToString());
                    //if(midt.Rows.Count != 0)
                    //{
                    //    DataRow mirow = midt.Rows[0];
                    //    string nom_perfil = mirow[1].ToString();

                    //    int index = cbo_roles.FindString(nom_perfil);
                    //    cbo_roles.SelectedIndex = index;
                    //}
                      cbo_roles.SelectedIndex = -1; 
                 
                                }

            }
        }

        private void cbo_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dg_p.Clear();
            if (cbo_roles.SelectedValue is int)
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                DataTable dtm = new DataTable();
                DataRow rowdg;
                dt_p = ss.ObtenerPermisosPorPerfilesdt(cbo_roles.SelectedValue.ToString());
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
                 //dataGridView2.DataSource = dt_p;
                dgw_perfil.DataSource = dg_p;
                // MessageBox.Show(cbo_roles.SelectedValue.ToString());

            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            //********************************BOTON ACEPTAR***********************************************
            //SistemaUsuarioDatos ss = new SistemaUsuarioDatos();

            //if(cbo_usuario.SelectedIndex!=-1)
            //{
            //    if (dt.Rows.Count >=1)
            //    {
            //        int x = ss.EliminarPermisos(cbo_usuario.SelectedValue.ToString());
            //        int y = ss.InsertarPermisosUsuario(dt,cbo_usuario.SelectedValue.ToString());
            //        ss.ActualizarPerfil(cbo_usuario.SelectedValue.ToString(), 0);
            //        if(x == 1 && y ==1)
            //        {
            //            MessageBox.Show("Modificacion exitosa");
            //            btn_aceptar_perfil.Enabled = false;
            //            btn_aceptar.Enabled = false;
            //        }
            //        else
            //           {
            //            MessageBox.Show("No se pudo modificar permisos");
            //           }  
            //    }
            //    else
            //      {
            //        MessageBox.Show("No hay nuevos permisos");
            //      }
            //}
            // else
            // {
            //    MessageBox.Show("Debe seleccionar un usuario");
            // }
            //**************************************************************************************

            UnirdtCentral(dt);
            UnirdgCentral(dg);
            dgw_central.DataSource = dg_central;
           // dataGridView3.DataSource = dt_central;

            cont_ec++;
            if (cont_ec == 1 && agregada == false)
            {
                AgregarColEliminarCentral();
                agregada = true;
            }

            dg.Clear();
            dt.Clear();
            dgw_permisos.DataSource = dg;
           // dataGridView1.DataSource = dt;
            DescheckearAplicaciones();
        }

        private void btn_aceptar_perfil_Click(object sender, EventArgs e)
        {
            //***********************************BOTON ACEPTAR******************************************************
            //SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
            //if (cbo_usuario.SelectedIndex != -1)
            //{
            //    if(cbo_roles.SelectedIndex != -1)
            //    {
            //        int x = ss.EliminarPermisos(cbo_usuario.SelectedValue.ToString());
            //        int y = ss.InsertarPermisosUsuario(dt_p, cbo_usuario.SelectedValue.ToString());
            //        ss.ActualizarPerfil(cbo_usuario.SelectedValue.ToString(), Convert.ToInt32(cbo_roles.SelectedValue));
            //        if (x == 1 && y == 1)
            //        {
            //            MessageBox.Show("Modificacion exitosa");
            //            btn_aceptar_perfil.Enabled = false;
            //            btn_aceptar.Enabled = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("No se pudo modificar permisos");
            //        }
            //    }
            //    else
            //       {
            //        MessageBox.Show("Debe seleccionar un perfil");
            //       }
            //}else
            //   {
            //    MessageBox.Show("Debe seleccionar un usuario");
            //   }
            //***********************************************************************************************************
            UnirdtCentral(dt_p);
            UnirdgCentral(dg_p);
            dgw_central.DataSource = dg_central;
           // dataGridView3.DataSource = dt_central;

            cont_ec++;
            if (cont_ec == 1 && agregada == false)
            {
                AgregarColEliminarCentral();
                agregada = true;
            }
        }



        public void UnirdtCentral(DataTable dtx)
        {
            DataRow rowC;

            foreach (DataRow row in dtx.Rows)
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

                    for (int i = 0; i < dt_central.Rows.Count; i++)
                    {
                        rowC = dt_central.Rows[i];
                        //if (row_agregar[0].ToString() == rowC[0].ToString())
                        if (app == rowC[0].ToString())
                        {
                            for (int z = 1; z < 5; z++)
                            {
                                if (Convert.ToInt32(row[z]) == 1)
                                {
                                    rowC[z] = row[z];
                                }
                            }
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
            for (int i = 0; i < 6; i++)
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

                            for (int z = 1; z < 5; z++)
                            {
                                if (row[z].ToString() == "X")
                                {
                                    rowC[z] = "X";
                                }
                            }
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

        public void AgregarColEliminarCentral()
        {
            DataGridViewButtonColumn dg_columna = new DataGridViewButtonColumn();
            //dg_columna  
            dg_columna.HeaderText = "Quitar";
            dgw_central.Columns.Add(dg_columna);
        }


        public void DescheckearAplicaciones()
        {
            for (int t = 0; t < chlb_aplicaciones.Items.Count; t++)
            {
                if (chlb_aplicaciones.GetItemCheckState(t) == CheckState.Checked || chlb_aplicaciones.GetItemCheckState(t) == CheckState.Indeterminate)
                {
                    chlb_aplicaciones.SetItemCheckState(t, CheckState.Unchecked);
                }
            }
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

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();

                if (cbo_usuario.SelectedIndex != -1)
                {
                    if (dt_central.Rows.Count >= 1)
                    {
                        int x = ss.EliminarPermisos(cbo_usuario.SelectedValue.ToString());
                        int y = ss.InsertarPermisosUsuario(dt_central, cbo_usuario.SelectedValue.ToString());
                        // ss.ActualizarPerfil(cbo_usuario.SelectedValue.ToString(), 0);
                        if (x == 1 && y == 1)
                        {
                            MessageBox.Show("Modificacion exitosa");
                            btn_reporte.Enabled = true;
                            btn_Guardar.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar permisos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay nuevos permisos");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            FormReporte f = new FormReporte();
            f.usuario = " la modificación del usuario " + cbo_usuario.Text.Trim();
            f.dgw_cen.DataSource = dg_central;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
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

            contx++;
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
                                nodo_hijo.Checked = false;
                            }
                        }

                    }

                }



            }

        }




        public void ArreglarCheck()
        {
            foreach (TreeNode nodo_raiz in trv_aplicaciones.Nodes)
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

        private void trv_aplicaciones_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode nodo_hijo in e.Node.Nodes)
            {
                nodo_hijo.Checked = true;
            }
        }
    }
}
