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
    public partial class FormTareasCaso : Form
    {
        public FormTareasCaso()
        {
            InitializeComponent();
        }
        public string titulo;
        public string id_caso;

        public string empleado;
        public string id_tarea;
        public string tipo;
        private void FormTareasCaso_Load(object sender, EventArgs e)
        {
            this.Text = "Tareas de " + titulo;
            //dateNavigator1.EditValue;

            //LLENAR EMPLEADOS
            //DataTable dt_empleados = OpBD.SeleccionarEmpleados();
            //if (dt_empleados != null)
            //{
            //    DataRow row_emp = dt_empleados.NewRow();
            //    row_emp[0] = 0;
            //    row_emp[1] = "<Ninguno>";
            //    dt_empleados.Rows.InsertAt(row_emp, 0);
            //    cbo_empleado.DataSource = dt_empleados;
            //    cbo_empleado.ValueMember = "id_empleado";
            //    cbo_empleado.DisplayMember = "Empleado";
            //}

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
            //---------------------------------------------
            //Tipos
            DataTable dt_tipos = OpBD.SeleccionarTipoTarea();
            if (dt_tipos != null)
            {
                cbo_tareas.DataSource = dt_tipos;
                cbo_tareas.ValueMember = "id_tipo";
                cbo_tareas.DisplayMember = "tipo";
            }

            //------------------------------------
            if (btn_guardar.Text == "Actualizar")
            {
                int indice_empleado = cbo_empleado.FindString(empleado);
                cbo_empleado.SelectedIndex = indice_empleado;

                int indice_tipo = cbo_tareas.FindString(tipo);
                cbo_tareas.SelectedIndex = indice_tipo;

            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (btn_guardar.Text == "Guardar")
            {

                if (!String.IsNullOrEmpty(txt_descripcion.Text.Trim()) && cbo_criticidad.SelectedItem != null)
                {

                    string descripcion = txt_descripcion.Text.Trim();
                    DateTime fecha_establecida = Convert.ToDateTime(dn_fecha.EditValue);
                    DateTime hora = Convert.ToDateTime(te_hora.EditValue);
                    DateTime fechahora_final = new DateTime(fecha_establecida.Year, fecha_establecida.Month, fecha_establecida.Day, hora.Hour, hora.Minute, hora.Second);

                    DateTime hora_ter = Convert.ToDateTime(te_hora_fin.EditValue);
                    DateTime fechahora_terminacion = new DateTime(fecha_establecida.Year, fecha_establecida.Month, fecha_establecida.Day, hora_ter.Hour, hora_ter.Minute, hora_ter.Second);

                    int id_empleado = Convert.ToInt32(cbo_empleado.SelectedValue);
                    string tipo = cbo_tareas.SelectedValue.ToString();
                    string criticidad = cbo_criticidad.SelectedItem.ToString();

                    OpBD o = new OpBD();
                    int res = o.InsertarTareaCaso(descripcion, fechahora_final.ToString("yyyy-MM-dd HH:mm:ss"), id_empleado, tipo, id_caso, titulo, criticidad,fechahora_terminacion.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (res == 1)
                    {
                        MessageBox.Show("Tarea asignada con exito");
                    }
                    else { MessageBox.Show("Tarea no asignada"); }


                }
                else { MessageBox.Show("Debe llenar todos los campos"); }


            }
            else if (btn_guardar.Text == "Actualizar")
            {
                if (!String.IsNullOrEmpty(txt_descripcion.Text.Trim()) && cbo_criticidad.SelectedItem != null)
                {
                    string descripcion = txt_descripcion.Text.Trim();
                    DateTime fecha_establecida = Convert.ToDateTime(dn_fecha.EditValue);
                    DateTime hora = Convert.ToDateTime(te_hora.EditValue);
                    DateTime fechahora_final = new DateTime(fecha_establecida.Year, fecha_establecida.Month, fecha_establecida.Day, hora.Hour, hora.Minute, hora.Second);
                    int id_empleado = Convert.ToInt32(cbo_empleado.SelectedValue);
                    string tipo = cbo_tareas.SelectedValue.ToString();
                    string criticidad = cbo_criticidad.SelectedItem.ToString();

                    DateTime hora_ter = Convert.ToDateTime(te_hora_fin.EditValue);
                    DateTime fechahora_terminacion = new DateTime(fecha_establecida.Year, fecha_establecida.Month, fecha_establecida.Day, hora_ter.Hour, hora_ter.Minute, hora_ter.Second);

                    OpBD oa = new OpBD();
                    int res = oa.ActualizarTareaCaso(id_tarea, descripcion, fechahora_final.ToString("yyyy-MM-dd HH:mm:ss"), id_empleado.ToString(), tipo, criticidad, titulo,fechahora_terminacion.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (res == 1)
                    {
                        MessageBox.Show("actualización realizada con exito");
                    }
                    else { MessageBox.Show("Actualización no realizada"); }
                }
                else { MessageBox.Show("Debe llenar todos los campos"); }

            }
        }
    }
}
