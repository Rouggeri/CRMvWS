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

namespace crm
{
    public partial class frmbuscproducto : Form
    {
        public frmbuscproducto()
        {
            InitializeComponent();
        }

        public void mostrar()
        {
            OdbcConnection conexion = Conexion.ObtenerConexion();
            OdbcDataAdapter dausuario = new OdbcDataAdapter("select * from producto", conexion);
            DataSet dsuario = new DataSet();
            dausuario.Fill(dsuario, "Producto");
            dgv_bien.DataSource = dsuario;
            dgv_bien.DataMember = "Producto";
        }

        private void btn_buscbien_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_bien.DataSource = Clsoporden.Buscar(txt_bien.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmbuscproducto_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        public entidades.Producto busq { get; set; }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_bien.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt16(dgv_bien.CurrentRow.Cells[0].Value);
                    busq = Clsopbien.Obtenerclte(id);
                    this.Close();
                }
                else
                    MessageBox.Show("Debe de seleccionar una fila");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_agregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgv_bien.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt16(dgv_bien.CurrentRow.Cells[0].Value);
                    busq = Clsopbien.Obtenerclte(id);

                    this.Close();
                }
                else
                    MessageBox.Show("Debe de seleccionar una fila");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
