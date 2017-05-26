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
    public partial class Form_EditarPerfil : Form
    {
        public Form_EditarPerfil()
        {

          
            InitializeComponent();
        }


        DataTable dt = new DataTable();
        DataTable dg = new DataTable();
        int cont_e = 0;
        int contx = 0;
        bool agregada = false;

        DataTable dtEliminados = new DataTable();
        DataTable dtAgregados = new DataTable();

        private void Form_EditarPerfil_Load(object sender, EventArgs e)
        {
            try
            {
                btn_reporte.Enabled = false;

                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                cbo_perfil.DataSource = ss.ObtenerPerfiles();
                cbo_perfil.DisplayMember = "nombre_perfil";
                cbo_perfil.ValueMember = "id_perfil";
                cbo_perfil.SelectedIndex = -1;



                DataTable dt2 = ss.ObtenerAplicaciones();

                ((ListBox)chlb_aplicaciones).DataSource = dt2;
                ((ListBox)chlb_aplicaciones).ValueMember = "id_aplicacion";
                ((ListBox)chlb_aplicaciones).DisplayMember = "nombre_aplicacion";

                //  chlb_aplicaciones.CheckOnClick = true;
                // chlb_permisos.CheckOnClick = true;
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
                //----------------dtEliminados-------------------------------
                ////primera columna
                //columna = new DataColumn();
                //columna.DataType = System.Type.GetType("System.String");
                //columna.ColumnName = "Perfil";
                //dtEliminados.Columns.Add(columna);

                ////2 columna
                //columna = new DataColumn();
                //columna.DataType = System.Type.GetType("System.String");
                //columna.ColumnName = "Aplicacion";
                //dtEliminados.Columns.Add(columna);
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
                        dt.Rows.Add(row);//<----------------------------------------------------------------------------------
                        dg.Rows.Add(rowdg);
                        cont = 1;
                    }
                }
            }

            dgw_permisos.DataSource = dg;
            //dataGridView1.DataSource = dt;

            BloquearCheck();
            BloquearExistentes();

            cont_e++;
            if (cont_e == 1)
            {
                AgregarColEliminar();
            }
        }

        private void dgw_permisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgw_permisos.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1 && e.RowIndex != dg.Rows.Count)//dg
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();

                DataRow row = dt.Rows[dgw_permisos.CurrentRow.Index];
                //if (row.RowState != DataRowState.Deleted)
                //{
                //*******************************************************
                //string aplicacion = row[0].ToString();
                //string perfil = cbo_perfil.SelectedValue.ToString();
                //DataRow rowe = dtEliminados.NewRow();
                //rowe[0] = perfil;
                //rowe[1] = aplicacion;
                //dtEliminados.Rows.Add(rowe);
                //dataGridView2.DataSource = dtEliminados;
                //*******************************************************
                row.Delete();
                // row.AcceptChanges();
             
                // }
                DataRow rowdg = dg.Rows[dgw_permisos.CurrentRow.Index];

                rowdg.Delete();


                // MessageBox.Show(dgw_permisos.CurrentRow.Index.ToString());
                dgw_permisos.DataSource = dg;
                //dataGridView1.DataSource = dt;
            }
        }

        private void cbo_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg.Clear();
            dt.Clear();
           // lv_permisosactuales.Items.Clear();
            if (cbo_perfil.SelectedValue is int && cbo_perfil.SelectedIndex != -1)//(cbo_perfil.SelectedIndex != -1)
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                DataTable dtm = new DataTable();
                DataTable dth = new DataTable();
                DataRow rowdg;
                dth = ss.ObtenerPermisosPorPerfilesdt(cbo_perfil.SelectedValue.ToString());
                dtm = ss.ObtenerPermisosPorPerfilesdg(cbo_perfil.SelectedValue.ToString());
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



                //foreach (DataRow rowx in dg.Rows)
                //{

                //    //ListViewItem permi = new ListViewItem(rowx[0].ToString());
                //    //permi.SubItems.Add(rowx[1].ToString());
                //    //permi.SubItems.Add(rowx[2].ToString());
                //    //permi.SubItems.Add(rowx[3].ToString());
                //    //permi.SubItems.Add(rowx[4].ToString());
                //    // lv_permisosactuales.Items.Add(permi);
             
                //}

                foreach (DataRow rowa in dth.Rows)
                {
                    DataRow rowb;
                    rowb = dt.NewRow();
                    for (int i = 0; i < 5; i++)
                    {
                        rowb[i] = rowa[i];
                    }
                    dt.Rows.Add(rowb);
                }

                //dg.Clear();//???
                //dt.Clear();
                // dataGridView1.DataSource = dt;
               // dataGridView1.DataSource = dt;
                dgw_permisos.DataSource = dg;

                cont_e++;
                if (cont_e == 1 )
                {
                 AgregarColEliminar();
                   

                }
                // MessageBox.Show(cbo_roles.SelectedValue.ToString());

                //if (cont_e >= 3)
                //{
                //    //busar en cbo
                //    DataTable midt = ss.ObtenerPerfilDeUsuario(cbo_usuario.SelectedValue.ToString());
                //    if (midt.Rows.Count != 0)
                //    {
                //        DataRow mirow = midt.Rows[0];
                //        string nom_perfil = mirow[1].ToString();

                //        int index = cbo_roles.FindString(nom_perfil);
                //        cbo_roles.SelectedIndex = index;
                //    }
                //    else { cbo_roles.SelectedIndex = -1; }

                //}

            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();

                if (cbo_perfil.SelectedIndex != -1)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        int x = ss.EliminarPermisosPerfil(cbo_perfil.SelectedValue.ToString());

                        int y = ss.InsertarPermisosPerfilEditar(dt, Convert.ToInt32(cbo_perfil.SelectedValue));
                        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        DataTable dtj = ss.SeleccionarUsuariosPorPerfil(cbo_perfil.SelectedValue.ToString());
                        foreach (DataRow fila in dtj.Rows)
                        {
                            ss.RevocarPermisoUs(fila[0].ToString(), cbo_perfil.SelectedValue.ToString());
                            ss.OtorgarPerfil(fila[0].ToString(), dt, cbo_perfil.SelectedValue.ToString());
                        }
                        //ss.RevocarPermisoUs(perfil, aplicacion);z----------------------------------------------------

                        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        if (x == 1 && y == 1)
                        {
                            MessageBox.Show("Modificacion exitosa");
                            btn_reporte.Enabled = true;
                            btn_aceptar.Enabled = false;
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
                    MessageBox.Show("Debe seleccionar un perfil");
                }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
            //DataTable dtj;
            //    dataGridView3.DataSource = ss.SeleccionarUsuariosPorPerfil(cbo_perfil.SelectedValue.ToString());
            
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            FormReporte f = new FormReporte();
            f.usuario = " la modificación del perfil " + cbo_perfil.Text.Trim();
            f.dgw_cen.DataSource = dg;
            f.Show();
        }

        private void buttonaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();

                if (cbo_perfil.SelectedIndex != -1)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        int x = ss.EliminarPermisosPerfil(cbo_perfil.SelectedValue.ToString());

                        int y = ss.InsertarPermisosPerfilEditar(dt, Convert.ToInt32(cbo_perfil.SelectedValue));
                        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        DataTable dtj = ss.SeleccionarUsuariosPorPerfil(cbo_perfil.SelectedValue.ToString());
                        foreach (DataRow fila in dtj.Rows)
                        {
                            ss.RevocarPermisoUs(fila[0].ToString(), cbo_perfil.SelectedValue.ToString());
                            ss.OtorgarPerfil(fila[0].ToString(), dt, cbo_perfil.SelectedValue.ToString());
                        }
                        //ss.RevocarPermisoUs(perfil, aplicacion);z----------------------------------------------------

                        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        if (x == 1 && y == 1)
                        {
                            MessageBox.Show("Modificacion exitosa");
                            btn_reporte.Enabled = true;
                            btn_aceptar.Enabled = false;
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
                    MessageBox.Show("Debe seleccionar un perfil");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
