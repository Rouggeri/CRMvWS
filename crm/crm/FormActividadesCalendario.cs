using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace crm
{
    public partial class FormActividadesCalendario : Form
    {
        public FormActividadesCalendario()
        {
            InitializeComponent();
        }

        private void FormActividadesCalendario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'baseDatosCalendarioDataSet.Resources' Puede moverla o quitarla según sea necesario.
            this.resourcesTableAdapter.Fill(this.baseDatosCalendarioDataSet.Resources);
            // TODO: esta línea de código carga datos en la tabla 'baseDatosCalendarioDataSet.Appointments' Puede moverla o quitarla según sea necesario.
            this.appointmentsTableAdapter.Fill(this.baseDatosCalendarioDataSet.Appointments);
            //WindowState = FormWindowState.Maximized;

            DataTable dt_AppointmentsCalendario = baseDatosCalendarioDataSet.Appointments;
            int ultimoappointment = dt_AppointmentsCalendario.Rows.Count;
            int ultimo_uniqueID;
            if (ultimoappointment > 0)
            {
                DataRow row_appointment = dt_AppointmentsCalendario.Rows[ultimoappointment - 1];
                 ultimo_uniqueID = Convert.ToInt32(row_appointment[0]);
            }
            else
              {
                ultimo_uniqueID = 0;
              }

            DataTable dt_tareas = OpBD.SeleccionarTareasCalendario();
            if (dt_tareas != null && dt_tareas.Rows.Count > 0)
            {
                foreach( DataRow tarea in dt_tareas.Rows)
                {
                    ultimo_uniqueID++;
                    string descripcion = tarea[0].ToString();
                    DateTime fechahora_inicio = Convert.ToDateTime(tarea[1]);
                    DateTime fechahora_fin = Convert.ToDateTime(tarea[2]);
                    string estado = tarea[3].ToString();
                    string origen = tarea[4].ToString();
                    string id_tipo = tarea[5].ToString();
                    string tipo = tarea[6].ToString();
                    string titulo_negocio = tarea[7].ToString();
                    string titulo_caso = tarea[8].ToString();

                    BaseDatosCalendarioDataSet.AppointmentsRow row = baseDatosCalendarioDataSet.Appointments.NewAppointmentsRow();
                    
                    row.UniqueID = ultimo_uniqueID;
                    row.Type = 0;
                    if (origen == "negocio")
                    {
                        row.Subject = descripcion + " - " + tipo + "(" +titulo_negocio+ ")";
                        row.Label = 3;
                    }
                    else 
                    {
                        row.Subject = descripcion + " - " + tipo + "(" +titulo_caso+ ")";
                        row.Label = 10;
                    }
                    row.StartDate = fechahora_inicio;
                    row.EndDate = fechahora_fin;
                    if (estado == "Pendiente")
                    {
                        row.Status = 3;
                    }
                    else
                    {
                        row.Status = 2;
                    }
                    
                    baseDatosCalendarioDataSet.Appointments.Rows.Add(row);

                    //dataGridView1.DataSource = baseDatosCalendarioDataSet.Appointments;
                }
            }

        }

        private void ContenedorCalendario_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(baseDatosCalendarioDataSet);
            baseDatosCalendarioDataSet.AcceptChanges();
        }

        private void ContenedorCalendario_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(baseDatosCalendarioDataSet);
            baseDatosCalendarioDataSet.AcceptChanges();
        }

        private void ContenedorCalendario_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(baseDatosCalendarioDataSet);
            baseDatosCalendarioDataSet.AcceptChanges();
        }
    }
}
