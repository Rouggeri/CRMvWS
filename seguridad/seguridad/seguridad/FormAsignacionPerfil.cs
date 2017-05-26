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
    public partial class FormAsignacionPerfil : Form
    {
        public FormAsignacionPerfil()
        {
            InitializeComponent();
        }

        private void FormAsignacionPerfil_Load(object sender, EventArgs e)
        {
            try
            {
                btn_reporte.Enabled = false;
                SistemaUsuarioDatos ss = new SistemaUsuarioDatos();

                DataTable dt2 = ss.ObtenerAplicaciones();

                ((ListBox)chlb_aplicaciones).DataSource = dt2;
                ((ListBox)chlb_aplicaciones).ValueMember = "id_aplicacion";
                ((ListBox)chlb_aplicaciones).DisplayMember = "nombre_aplicacion";

                //  chlb_aplicaciones.CheckOnClick = true;
                // chlb_permisos.CheckOnClick = true;
                //****************************************************
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
            }
            catch { MessageBox.Show("no tiene permisos"); }
        }



        DataTable dt = new DataTable();
        DataTable dg = new DataTable();
        int cont_e = 0;



        public void ValidarListaApp()
        {
            string idp;
            foreach (DataRow row in dt.Rows)
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




        private void btn_agregar_Click_1(object sender, EventArgs e)
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
                        dt.Rows.Add(row);
                        dg.Rows.Add(rowdg);
                        cont = 1;
                    }
                }
            }

            dgw_permisos.DataSource = dg;


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
            if (dgw_permisos.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1 && e.RowIndex != dt.Rows.Count)
            {
                DataRow row = dt.Rows[dgw_permisos.CurrentRow.Index];
                row.Delete();

                DataRow rowdg = dg.Rows[dgw_permisos.CurrentRow.Index];
                rowdg.Delete();

                // MessageBox.Show(dgw_permisos.CurrentRow.Index.ToString());
                dgw_permisos.DataSource = dg;

            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SistemaUsuarioNegocio su = new SistemaUsuarioNegocio();
                int u = su.ValidarChecklistVacia(dt);

                if (!String.IsNullOrEmpty(txt_perfil.Text.Trim()) && u == 1)
                {
                    int perfil_enc;
                    int perfil_det;
                    SistemaUsuarioDatos ss = new SistemaUsuarioDatos();
                    perfil_enc = ss.InsertarPerfil(txt_perfil.Text.Trim());
                    //if(r== 1)
                    //{
                    //    MessageBox.Show("perfil creado existosamente!");
                    //}else { MessageBox.Show("error en la creacion del perfil"); }
                    perfil_det = ss.InsertarPermisosPerfil(dt);
                    if (perfil_enc == 1 && perfil_det == 1)
                    {
                        MessageBox.Show("ingresado con exito");
                        btn_reporte.Enabled = true;
                    }
                    else { MessageBox.Show("error al ingresar"); }

                }
                else { MessageBox.Show("Debe ingresar  nombre y permisos para el perfil!"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void group_box_pp_Enter(object sender, EventArgs e)
        {

        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            FormReporte f = new FormReporte();
            f.usuario = " la creación del perfil " + txt_perfil.Text.Trim();
            f.dgw_cen.DataSource = dg;
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
                               // row["perfil"] = 0; //<----------------------------------------------------------------------------------------------
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
