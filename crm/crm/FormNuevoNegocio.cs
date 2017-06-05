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
    public partial class FormNuevoNegocio : Form
    {
        public FormNuevoNegocio()
        {
            InitializeComponent();
        }
        string id_form = "105";

        public string id_negocio_e;
        public string titulo_e; 
        public string persona_e;
        public string empresa_e;
        public string moneda_e;
        public string valor_e;
        public string fecha_cierre_e;
        public string categoria_e;

        private void FormNuevoNegocio_Load(object sender, EventArgs e)
        {
            try
            {
               // txt_valor.Text = String.Format("#,###.##");
                //WindowState = FormWindowState.Normal;
                //LLENAR MONEDA
                cbo_monedas.DataSource = OpBD.SeleccionarMonedas();
                cbo_monedas.ValueMember = "id_moneda";
                cbo_monedas.DisplayMember = "Moneda";
                //cbo_moneda.Properties.PopulateColumns();
                //cbo_moneda.Properties.Columns[0].Visible = false;

                //LLENAR CATEGORIAS
                cbo_cat.DataSource = OpBD.SeleccionarCategoriascbo();
                cbo_cat.ValueMember = "id_cat";
                cbo_cat.DisplayMember = "nombre_cat";
                //LLENAR EMPLEADOS
                //DataTable dt_empleados = OpBD.SeleccionarEmpleados();
                //DataRow row_emp = dt_empleados.NewRow();
                //row_emp[0] = 0;
                //row_emp[1] = "<Ninguno>";
                //dt_empleados.Rows.InsertAt(row_emp, 0);
                //cbo_empleado.DataSource = dt_empleados;
                //cbo_empleado.ValueMember = "id_empleado";
                //cbo_empleado.DisplayMember = "Empleado";

                ServiceReference1.Service1Client srv = new ServiceReference1.Service1Client();
                DataSet ds = srv.ObtenerEmpleados();
                DataTable dt_empleados = ds.Tables[0];
                DataRow row_emp = dt_empleados.NewRow();
                row_emp[0] = 0;
                row_emp[6] = "<Ninguno>";
                dt_empleados.Rows.InsertAt(row_emp, 0);
                cbo_empleado.DataSource = dt_empleados;
                cbo_empleado.ValueMember = "id_empleado_pk";
                cbo_empleado.DisplayMember = "NOMBRE";


                if (btn_guardar.Text == "Actualizar")
                {
                    txt_titulo.Text = titulo_e;

                    if (!String.IsNullOrEmpty(persona_e))
                    {
                        comboBox1.SelectedItem = "Persona";
                        int indice_per = cbo_perem.FindString(persona_e);
                        cbo_perem.SelectedIndex = indice_per;
                    }
                    else if (!String.IsNullOrEmpty(empresa_e))
                    {
                        comboBox1.SelectedItem = "Empresa";
                        int indice_emp = cbo_perem.FindString(empresa_e);
                        cbo_perem.SelectedIndex = indice_emp;
                    }

                    DataTable dt_rest = OpBD.SeleccionarDatosRestantes(id_negocio_e);
                    DataRow row = dt_rest.Rows[0];
                    string detalles = row[0].ToString();
                    string etapa = row[1].ToString();
                    string fecha_inicio = row[2].ToString();
                    string id_empleado = row[3].ToString();
                  //  string nombre_empleado = row[4].ToString();
                    string estado = row[5].ToString();
                    txt_detalles.Text = detalles;
                    //---------------WS--------------
                    string empleado_ws = "--";
                    foreach (DataRow roww in dt_empleados.Rows)
                    {
                        if (roww[0].ToString() == id_empleado)
                        {
                            empleado_ws = roww[6].ToString();
                        }
                    }

                    //------------------------------
                    string[] moneda_dividida = moneda_e.Split('(',')');
                    string nombre_moneda = moneda_dividida[0];
                    string signo_moneda = moneda_dividida[1];
                    string moneda_final = signo_moneda + " - " + nombre_moneda;
                    int indice_moneda = cbo_monedas.FindString(moneda_final);
                    cbo_monedas.SelectedIndex = indice_moneda;

                    txt_valor.Text = valor_e;

                    int indice_categoria = cbo_cat.FindString(categoria_e);
                    cbo_cat.SelectedIndex = indice_categoria;

                    dtp_fecha_cierre.EditValue = Convert.ToDateTime(fecha_cierre_e);

                    if (id_empleado != "0")
                    {
                        int indice_empleado = cbo_empleado.FindString(empleado_ws);
                        cbo_empleado.SelectedIndex = indice_empleado;
                    }
                    else
                    {
                        cbo_empleado.SelectedIndex = 0;
                    }

                    tb_etapa.Value = Convert.ToInt32(etapa);
                }




            }
            catch { MessageBox.Show("sin permisos!!"); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Persona")
            {
                cbo_perem.DataSource = OpBD.SeleccionarClientes();
                cbo_perem.ValueMember = "id_cliente";
                cbo_perem.DisplayMember = "nom";
            }
            else if (comboBox1.SelectedItem.ToString() == "Empresa")
              {
                cbo_perem.DataSource = OpBD.SeleccionarEmpresas();
                cbo_perem.ValueMember = "id_empresa";
                cbo_perem.DisplayMember = "nombre";
            }
        }

        private void btn_nueva_mon_Click(object sender, EventArgs e)
        {
            //frm_moneda f = new frm_moneda();
            //f.MdiParent = this.MdiParent;
            //f.Show();

            frm_moneda f = new frm_moneda();
            f.Show();

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_nueva_Click(object sender, EventArgs e)
        {
            Form_categoria_neg f = new Form_categoria_neg();
           // f.MdiParent = this.MdiParent;
            //f.WindowState = FormWindowState.Normal;
            f.Show();
        }

        private void btn_refesh_cat_Click(object sender, EventArgs e)
        {
            cbo_cat.DataSource = OpBD.SeleccionarCategoriascbo();
            cbo_cat.ValueMember = "id_cat";
            cbo_cat.DisplayMember = "nombre_cat";
        }

        private void btn_nuevo_emp_Click(object sender, EventArgs e)
        {
            frm_NuevoEmpleado f = new frm_NuevoEmpleado();
             f.MdiParent = this.MdiParent;
            
            f.Show();
        }

        private void btn_actualizar_emp_Click(object sender, EventArgs e)
        {
            cbo_empleado.DataSource = OpBD.SeleccionarEmpleados();
            cbo_empleado.ValueMember = "id_empleado";
            cbo_empleado.DisplayMember = "Empleado";
        }

        private void btn_actualizar_mon_Click(object sender, EventArgs e)
        {
            cbo_monedas.DataSource = OpBD.SeleccionarMonedas();
            cbo_monedas.ValueMember = "id_moneda";
            cbo_monedas.DisplayMember = "Moneda";
            //cbo_moneda.Properties.PopulateColumns();
            //cbo_moneda.Properties.Columns[0].Visible = false;
        }

        private void btn_nuevo_perem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1) {
                if (comboBox1.SelectedItem.ToString() == "Persona")
                {
                    frm_cliente f = new frm_cliente();
                    f.MdiParent = this.MdiParent;

                    f.Show();
                } else if (comboBox1.SelectedItem.ToString() == "Empresa")
                {
                    frm_empresa f = new frm_empresa();
                    f.MdiParent = this.MdiParent;

                    f.Show();
                }
            }
        }

        private void btn_refresh_perem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
            {
                if (comboBox1.SelectedItem.ToString() == "Persona")
                {
                    cbo_perem.DataSource = OpBD.SeleccionarClientes();
                    cbo_perem.ValueMember = "id_cliente";
                    cbo_perem.DisplayMember = "nom";
                }
                else if (comboBox1.SelectedItem.ToString() == "Empresa")
                {
                    cbo_perem.DataSource = OpBD.SeleccionarEmpresas();
                    cbo_perem.ValueMember = "id_empresa";
                    cbo_perem.DisplayMember = "nombre";
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            if (btn_guardar.Text == "Guardar")
            {

                if (!String.IsNullOrEmpty(txt_titulo.Text) && comboBox1.SelectedItem != null && !String.IsNullOrEmpty(txt_detalles.Text) && !String.IsNullOrEmpty(txt_valor.Text) && dtp_fecha_cierre.EditValue != null)
                {
                    string titulo = txt_titulo.Text.Trim();
                    int perem = Convert.ToInt32(cbo_perem.SelectedValue);
                    string detalles = txt_detalles.Text.Trim();
                    int moneda = Convert.ToInt32(cbo_monedas.SelectedValue);
                    decimal valor = Convert.ToDecimal(txt_valor.Text.Trim());
                    int cat = Convert.ToInt32(cbo_cat.SelectedValue);
                    int empleado = Convert.ToInt32(cbo_empleado.SelectedValue);
                    int etapa = tb_etapa.Value;
                    DateTime fecha = dtp_fecha_cierre.DateTime;

                    int res = 3;
                    OpBD o = new OpBD();
                    if (comboBox1.SelectedItem.ToString() == "Persona")
                    {
                        res = o.InsertarNegocioClie(titulo, perem, detalles, moneda, valor, cat, empleado, etapa, fecha.ToString("yyyy-MM-dd"));
                    } else if (comboBox1.SelectedItem.ToString() == "Empresa")
                    {
                        res = o.InsertarNegocioEmp(titulo, perem, detalles, moneda, valor, cat, empleado, etapa, fecha.ToString("yyyy-MM-dd"));
                    }

                    if (res == 1)
                    {
                        MessageBox.Show("Ingreso Exitoso!");
                    }
                    else if (res == 0)
                    {
                        MessageBox.Show("Ingreso fallido!");
                    }
                    else {
                        MessageBox.Show("Ingrese con quien será la negociación!");
                    }




                }
                else { MessageBox.Show("Debe llenar todos los campos!!!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            }else if (btn_guardar.Text=="Actualizar")
            {
                if (!String.IsNullOrEmpty(txt_titulo.Text) && comboBox1.SelectedItem != null && !String.IsNullOrEmpty(txt_detalles.Text) && !String.IsNullOrEmpty(txt_valor.Text) && dtp_fecha_cierre.EditValue != null)
                {

                    string titulo = txt_titulo.Text.Trim();
                    int perem = Convert.ToInt32(cbo_perem.SelectedValue);
                    string detalles = txt_detalles.Text.Trim();
                    int moneda = Convert.ToInt32(cbo_monedas.SelectedValue);
                    decimal valor = Convert.ToDecimal(txt_valor.Text.Trim());
                    int cat = Convert.ToInt32(cbo_cat.SelectedValue);
                    int empleado = Convert.ToInt32(cbo_empleado.SelectedValue);
                    int etapa = tb_etapa.Value;
                    DateTime fecha = dtp_fecha_cierre.DateTime;

                    int res = 3;
                    OpBD o = new OpBD();
                    if (comboBox1.SelectedItem.ToString() == "Persona")
                    {
                        res = o.ActualizarNegocioClie(titulo, perem, detalles, moneda, valor, cat, empleado, etapa, fecha.ToString("yyyy-MM-dd"),id_negocio_e);
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Empresa")
                    {
                        res = o.ActualizarNegocioEmp(titulo, perem, detalles, moneda, valor, cat, empleado, etapa, fecha.ToString("yyyy-MM-dd"),id_negocio_e);
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

        private void txt_valor_TextChanged(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(txt_valor.Text))
            //{
            //    decimal valor = Convert.ToDecimal(txt_valor.Text);
            //    txt_valor.Text = valor.ToString("#,###.##");
            //}
        }

        private void txt_valor_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_valor.Text))
            {
                decimal valor = Convert.ToDecimal(txt_valor.Text);
                txt_valor.Text = valor.ToString("#,###.##");
            }
        }

        private void cbo_perem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
