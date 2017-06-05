using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using FuncionesNavegador;

namespace crm
{
    public partial class Form_categoria_neg : Form
    {
        public Form_categoria_neg()
        {
            InitializeComponent();
        }

        string id_form = "101";
        private void Form_categoria_neg_Load(object sender, EventArgs e)
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


                OpBD o = new OpBD();
                DataTable dt = OpBD.SeleccionarCategorias();
                grid_cat.DataSource = dt;
                gridView1.Columns[0].Caption = "Categoría";

            }
            catch { MessageBox.Show("Sin permisos!!"); }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string categoria = txt_cat.Text.Trim();
            OpBD o = new OpBD();
            int result = o.InsertarCategoria(categoria);
            if (result == 1)
            {
                MessageBox.Show("Categoria registrada exitosamente!");
            }
              else
               {
                MessageBox.Show("Categoria no ingresada");
               }
            grid_cat.DataSource = OpBD.SeleccionarCategorias();
            gridView1.Columns[0].Caption = "Categoría";
        }
    }
}
