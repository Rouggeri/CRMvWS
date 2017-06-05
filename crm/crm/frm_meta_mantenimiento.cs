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
using DevExpress.XtraGrid.Views.Grid;


namespace crm
{
    public partial class frm_meta_mantenimiento : Form
    {
        public frm_meta_mantenimiento()
        {
            InitializeComponent();
        }

        int indicador = 0; // servira para cuando el cliente va modificar un registro, el estado va a cambiar a 1 cunado de clic en modificar de esta forma va a modificar un registro y no lo va a guardar nuevo, sino a modificar
        

        CapaDatosPersonas CapaDatos = new CapaDatosPersonas();
        public double meta;
        DataTable dt_meta = new DataTable();
        DateTime fecha_referencia = new DateTime(); // fecha de inicio de este mes
        DateTime fecha_fin_mes = new DateTime(); // fecha de fin de mes anterior
        string id_monto ="";

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (indicador == 0) {

                meta = Convert.ToDouble(txt_meta.Text.Trim());
                // Insercion en la tabla tbl_estadistica
                CapaDatos.Insertar_Nueva_meta(txt_meta.Text.Trim(), fecha_referencia.ToString("yyyy-MM-dd"), fecha_fin_mes.ToString("yyyy-MM-dd"));

                MessageBox.Show("Monto ingresado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (indicador == 1)
            {
                //Carga de monto en la grafica
                meta = Convert.ToDouble(txt_meta.Text.Trim());
                CapaDatos.modificar_meta_registro(id_monto, txt_meta.Text.Trim());
                MessageBox.Show("Monto modificado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //dgv_metas.DataSource = dt_meta;
            }



        }

        private void frm_meta_mantenimiento_Load(object sender, EventArgs e)
        {

            dgv_metas.Enabled = false;


            txt_meta.Text = "";
            // BLOQUEO DE BOTONES INNECESARIOS
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = false;
            btn_buscar.Enabled = false;
            btn_cancelar.Enabled = false;
            btn_actualizar.Enabled = false;
            btn_anterior.Enabled = false;
            btn_siguiente.Enabled = false;
            btn_primero.Enabled = false;
            btn_ultimo.Enabled = false;
            btn_nuevo.Enabled = false;

            // FECHA INICIO Y FIN DE MES:

             fecha_referencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // fecha de inicio de este mes
             fecha_fin_mes = fecha_referencia.AddMonths(1).AddDays(-1); // fecha de fin de mes anterior
            lbl_fecha_inicio.Text = fecha_referencia.ToShortDateString();
            lbl_fecha_fin.Text = fecha_fin_mes.ToShortDateString();

            //Carga de monto en la grafica
            dt_meta = CapaDatos.consultar_meta_registro();
            dgv_metas.DataSource = dt_meta;

            // cambio de nombre a las columnas del grid
            gridView1.Columns["meta"].Caption = "Meta";
            gridView1.Columns["fecha_inicio"].Caption = "Fecha de inicio";
            gridView1.Columns["fecha_fin"].Caption = "Fecha final";
            gridView1.Columns["id_estadistica"].Visible = false;



        }

        private void dgv_metas_Click(object sender, EventArgs e)
        {
            // habilar y desabilitar botones necesarios
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = false;
            btn_buscar.Enabled = false;
            btn_cancelar.Enabled = false;
            btn_actualizar.Enabled = false;
            btn_anterior.Enabled = false;
            btn_siguiente.Enabled = false;
            btn_primero.Enabled = false;
            btn_ultimo.Enabled = false;
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;


            // Crear vector:
            int[] vector = ((GridView)dgv_metas.MainView).GetSelectedRows();
            // Seleccionar las areas que tomará el vector del grid
            DataRowView id = (DataRowView)(((GridView)dgv_metas.MainView).GetRow(vector[0]));
            DataRowView fecha_inicio = (DataRowView)(((GridView)dgv_metas.MainView).GetRow(vector[0]));
            DataRowView fecha_finn = (DataRowView)(((GridView)dgv_metas.MainView).GetRow(vector[0]));
            DataRowView meta = (DataRowView)(((GridView)dgv_metas.MainView).GetRow(vector[0]));

            // asignacion de partes de vectores en cajas de texto
            txt_meta.Text = meta["meta"].ToString();
            lbl_fecha_fin.Text = fecha_finn["fecha_fin"].ToString();
            lbl_fecha_inicio.Text = fecha_inicio["fecha_inicio"].ToString();
            id_monto = id["id_estadistica"].ToString();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            ////Carga de monto en la grafica
            //meta = Convert.ToDouble(txt_meta.Text.Trim());
            //CapaDatos.modificar_meta_registro(id_monto, txt_meta.Text.Trim());
            //MessageBox.Show("Monto modificado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //dgv_metas.DataSource = dt_meta;
            btn_guardar.Enabled = true;
            dgv_metas.Enabled = true;
            indicador = 1;
        }
    }
}
