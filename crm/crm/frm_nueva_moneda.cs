using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using FuncionesNavegador;

namespace crm
{
    public partial class frm_nueva_moneda : Form
    {
        public frm_nueva_moneda()
        {
            InitializeComponent();
        }
        CapaDatosPersonas moneda = new CapaDatosPersonas();
        string identificador = "";
        string id_form = "109";
        // boton guardar moneda
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_moneda.Text.Trim() == "" || txt_simbolo.Text.Trim() == "")
                {
                    MessageBox.Show("Tipo de moneda no ingresado, Uno o más campos estan vacíos", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    moneda.Insertar_moneda(txt_moneda.Text.Trim(), txt_simbolo.Text.Trim());
                    MessageBox.Show("Tipo de moneda ingresada correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    // refresh de gridchart
                   
                        DataTable almacen = new DataTable();
                        almacen = moneda.Consulta_moneda();
                        dgv_moneda_nueva.DataSource = almacen;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        // cargar gridchart con el form de carga
        private void frm_nueva_moneda_Load(object sender, EventArgs e)
        {
            try
            {

                CapaNegocio fn = new CapaNegocio();
                DataTable seg = seguridad.ObtenerPermisos.Permisos(seguridad.Conexion.User, id_form);
                if (seg.Rows.Count > 0)
                {
                    fn.desactivarPermiso(seg, btn_guardar, btn_eliminar, btn_editar, btn_nuevo, btn_cancelar, btn_actualizar, btn_buscar, btn_anterior, btn_siguiente, btn_primero, btn_ultimo);
                }
                else
                {
                    btn_guardar.Enabled = false; btn_eliminar.Enabled = false; btn_editar.Enabled = false; btn_nuevo.Enabled = false; btn_actualizar.Enabled = false; btn_cancelar.Enabled = false; btn_buscar.Enabled = false;
                }


                pcb_moneda.Image = Image.FromFile("tipomoneda.jpg");
                DataTable almacen = new DataTable();
                almacen = moneda.Consulta_moneda();
                dgv_moneda_nueva.DataSource = almacen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }


        // boton actualizar
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable almacen = new DataTable();
                almacen = moneda.Consulta_moneda();
                dgv_moneda_nueva.DataSource = almacen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // gridchart de monedas registradas
        private void dgv_moneda_nueva_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear vector:
                int[] vector = ((GridView)dgv_moneda_nueva.MainView).GetSelectedRows();
                // Seleccionar las areas que tomará el vector del grid
                DataRowView id_moneda = (DataRowView)(((GridView)dgv_moneda_nueva.MainView).GetRow(vector[0]));
                DataRowView nombre_moneda = (DataRowView)(((GridView)dgv_moneda_nueva.MainView).GetRow(vector[0]));
                DataRowView simbolo = (DataRowView)(((GridView)dgv_moneda_nueva.MainView).GetRow(vector[0]));
               
                // asignacion de partes de vectores en cajas de texto
                txt_moneda.Text = nombre_moneda["nombre"].ToString();
                txt_simbolo.Text = simbolo["simbolo"].ToString();
                identificador = id_moneda["id_moneda"].ToString();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // boton de limpiar
        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                txt_moneda.Text = "";
                txt_simbolo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // boton modificar
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try {
                moneda.modificar_moneda(txt_moneda.Text.Trim(), txt_simbolo.Text.Trim(), identificador);
                MessageBox.Show("Tipo de moneda modificada correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                // refresh a gridchart
                DataTable almacen = new DataTable();
                almacen = moneda.Consulta_moneda();
                dgv_moneda_nueva.DataSource = almacen;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {

                var opcion = MessageBox.Show("¿Desea eliminar este registro?","Eliminar Registro",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    moneda.Eliminar_Moneda(identificador);
                    MessageBox.Show("Tipo de moneda eliminada correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                    // refresh a gridchart
                    DataTable almacen = new DataTable();
                    almacen = moneda.Consulta_moneda();
                    dgv_moneda_nueva.DataSource = almacen;
                }

                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
