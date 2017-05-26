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
    public partial class frm_categoria_caso : Form
    {
        public frm_categoria_caso()
        {
            InitializeComponent();
        }
        string id_form = "106";
        CapaDatosPersonas categoria_caso = new CapaDatosPersonas();
        string identificador = "";

        // boton para guardar nueva categoria
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                categoria_caso.Insertar_NuevaCategoria_Caso(txt_cat.Text.Trim());
                MessageBox.Show("Categoria Ingresada Exitosamente", "Categoria ingresada", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // boton para actualizar grid de categoria
        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            DataTable categorias = new DataTable();
            categorias = categoria_caso.cargar_categoria();
            dgv_categoria.DataSource = categorias;
        }

        // formulario de carga inicial
        private void frm_categoria_caso_Load(object sender, EventArgs e)
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



                DataTable categorias = new DataTable();
                categorias = categoria_caso.cargar_categoria();
                dgv_categoria.DataSource = categorias;
            }
            catch { MessageBox.Show("Sin permisos!!"); }
        }


        // seleccionar la categoria y colocarla en el textbox
        private void dgv_categoria_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear vector:
                int[] vector = ((GridView)dgv_categoria.MainView).GetSelectedRows();
                // Seleccionar las areas que tomará el vector del grid
                DataRowView id_categoria = (DataRowView)(((GridView)dgv_categoria.MainView).GetRow(vector[0]));
                DataRowView categoria = (DataRowView)(((GridView)dgv_categoria.MainView).GetRow(vector[0]));
                

                // asignacion de partes de vectores en cajas de texto
                txt_cat.Text = categoria["nombre_caso"].ToString();
                identificador = id_categoria["id_cat_caso"].ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // boton para modificar la categoria
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                categoria_caso.modificar_categoria(txt_cat.Text.Trim(), identificador);
                MessageBox.Show("Registro modificado con exito", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // boton para eliminar la categoria (cambiar de estado a inactivo)
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                categoria_caso.eliminar_categoria(identificador);
                MessageBox.Show("Registro eliminado con exito", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // boton para nueva categoria
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_cat.Text = "";
        }
    }
}
